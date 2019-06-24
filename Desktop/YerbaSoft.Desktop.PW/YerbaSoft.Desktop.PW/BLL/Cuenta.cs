using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerbaSoft.DTO.Types;
using YerbaSoft.Windows.API;

namespace YerbaSoft.Desktop.PW.BLL
{
    public class Cuenta : IDisposable
    {
        // Tools
        public ProcessManager Manager;  /// TODO: GGR - poner private
        public Configuration.Cuenta Config;
        public DAL.CuentaConfig Dal;
        public Forms.CuentaForm CuentaForm { get; set; }

        // Eventos
        public event EventHandler<Cuenta> OnDispose;
        public event EventHandler<bool> OnAutoFollowStatusChange;
        public event EventHandler<bool> OnAutoKeyStatusChange;
        public event EventHandler<bool> OnAutoSpotStatusChange;
        public event EventHandler<bool> OnAutoPickStatusChange;
        public event EventHandler<bool> OnAutoAssistStatusChange;

        // Threads
        private Dictionary<Keys, Thread> AutoKeyThreads = new Dictionary<Keys, Thread>();
        private Thread AutoFollowThread;
        private Thread AutoPickThread;
        private Thread AutoSpotThread;
        private Thread AutoAssistThread;
        private Dictionary<Keys, Thread> AutoSpotKeysThreads = new Dictionary<Keys, Thread>();
        private Dictionary<Keys, Thread> AutoAssistKeysThreads = new Dictionary<Keys, Thread>();

        // Propiedades
        public Structs.Base BaseMem { get; set; }

        public bool IsAutoFollowRunning => this.AutoFollowThread != null;
        public bool IsAnyAutoKeyRunning => this.AutoKeyThreads.Count > 0;
        public bool IsAutoSpotRunning => this.AutoSpotThread?.IsAlive ?? false;
        public bool IsAutoPickRunning => this.AutoPickThread != null;
        public bool IsAutoAssistRunning => this.AutoAssistThread != null;
        public bool IsPJLoaded => this.BaseMem?.Barco1?.PJInfo != null;
        public BLL.Structs.PJInfo.Structure PJInfoData => this.BaseMem.Barco1.PJInfo.Info;
        
        public Cuenta(Process proc, Configuration.Cuenta config = null)
        {
            this.Config = config ?? new Configuration.Cuenta();
            this.Manager = new ProcessManager(proc);
            
            this.Manager.SetWindowTitle(config.Name ?? config.Login);

            this.Dal = DAL.CuentaConfig.Get(config.Name ?? config.Login) ?? new DAL.CuentaConfig() { Login = config.Name ?? config.Login };
            this.BaseMem = new Structs.Base(this.Manager, this.Config);
        }

        public void DoLogin(bool includeFirstEnter = false)
        {
            if (includeFirstEnter)
            {
                this.Manager.KeyPress(System.Windows.Forms.Keys.Enter);
                Thread.Sleep(1000);
            }

            // recorro el login
            foreach (var l in Config.Login)
            {
                string letter;
                if (int.TryParse(l.ToString(), out int aux))
                    letter = $"D{l}";
                else
                    letter = l.ToString().ToUpper();
                var key = (Keys)Enum.Parse(typeof(Keys), letter);

                this.Manager.KeyUp(key);
            }
            Thread.Sleep(1000);
            this.Manager.KeyDown(System.Windows.Forms.Keys.Tab);
            // recorro el pass
            foreach (var l in Config.Pass)
            {
                string letter;
                if (int.TryParse(l.ToString(), out int aux))
                    letter = $"D{l}";
                else
                    letter = l.ToString().ToUpper();
                var key = (Keys)Enum.Parse(typeof(Keys), letter);

                this.Manager.KeyUp(key);
            }

            Thread.Sleep(1000);
            this.Manager.KeyPress(System.Windows.Forms.Keys.Enter);
            Thread.Sleep(3500);
            this.Manager.KeyPress(System.Windows.Forms.Keys.Enter);
        }
        
        #region AutoFollow

        public void SetAutoFollow(bool active)
        {
            if (!active && AutoFollowThread != null)
            {
                AutoFollowThread.Abort();
                AutoFollowThread = null;
            }

            if (active && AutoFollowThread == null)
            {
                StopAll();

                AutoFollowThread = new Thread(_DoAutoFollow) { Priority = ThreadPriority.Lowest };
                AutoFollowThread.Start();
            }

            this.OnAutoFollowStatusChange?.Invoke(this, active);
        }
        private void _DoAutoFollow()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                this.Manager.MouseDblClick(30, 218);
            }
        }

        #endregion

        #region AutoKeys

        public void SetAutoKey(Keys key, int time, bool active)
        {
            if (time == 0)
                active = false;

            if (active)
            {
                if (AutoKeyThreads.Keys.Contains(key))
                    return;

                StopAll("AutoKey");

                var t = new Thread(_DoAutoKey);
                AutoKeyThreads.Add(key, t);
                t.Start(new { key, time });
            }
            else
            {
                if (AutoKeyThreads.ContainsKey(key))
                {
                    var thr = AutoKeyThreads[key];
                    thr.Abort();
                    AutoKeyThreads.Remove(key);
                }
            }

            this.OnAutoKeyStatusChange?.Invoke(this, active);
        }
        private void _DoAutoKey(object info)
        {
            Keys key = ((dynamic)info).key;
            int time = ((dynamic)info).time;

            while(true)
            {
                Thread.Sleep(time);
                this.Manager.KeyPress(key);
            }
        }
        
        public bool IsAutoKeyRunning(Keys key)
        {
            return AutoKeyThreads.Keys.Contains(key);
        }

        public Keys[] GetAutoKeyRunningKeys()
        {
            return AutoKeyThreads.Keys.ToArray();
        }

        #endregion

        #region AutoSpot

        public void SetAutoSpot(bool active)
        {
            if (this.Dal.AutoSpot == null)
                return;

            if (!active)
            {
                StopAutoSpotAtk();

                if (AutoSpotThread?.IsAlive ?? false)
                    AutoSpotThread?.Abort();
                AutoSpotThread = null;
            }

            if (active && !IsAutoSpotRunning)
            {
                StopAll();

                AutoSpotThread = new Thread(_DoAutoSpot) { Priority = ThreadPriority.Lowest };
                AutoSpotThread.Start(this.Dal);
            }

            this.OnAutoSpotStatusChange?.Invoke(this, active);
        }
        private void _DoAutoSpot(object input)
        {
            var config = ((DAL.CuentaConfig)input).AutoSpot;

            uint? target = 0;
            var lastBuffTime = DateTime.MinValue;
            while (true)
            {

                //ETAPA 0: BUFF
                if (config.HasBuff && target == 0 && lastBuffTime.AddSeconds((config.BuffExpireTime ?? 300000) / 1000) < DateTime.Now)
                {
                    this.Manager.KeyPress(config.BuffKey.GetKey());

                    var startBuffing = DateTime.Now;
                    while (startBuffing.AddSeconds((config.BuffCastTime ?? 5000) / 1000) > DateTime.Now && target == 0)
                    {
                        Thread.Sleep(500);

                        if (this.BaseMem?.Barco1?.PJInfo == null)
                        {
                            this.OnAutoSpotStatusChange?.Invoke(this, false);
                            return;
                        }

                        lock (this.BaseMem.Barco1.PJInfo)
                            target = this.BaseMem?.Barco1?.PJInfo?.Info.TargetId;
                    }
                    if (target == 0)
                        lastBuffTime = DateTime.Now;
                }

                // ETAPA 1: BUSCAR TARGET
                while (target == 0)
                {
                    Thread.Sleep(500);

                    if (this.BaseMem?.Barco1?.PJInfo == null)
                    {
                        this.OnAutoSpotStatusChange?.Invoke(this, false);
                        return;
                    }

                    if (500000 < (target = this.BaseMem?.Barco1?.PJInfo?.Info.TargetId))
                        break;

                    if (!string.IsNullOrEmpty(config.AssistKey) && config.AssistKey != "Tab")
                    {
                        var tecla = (int)Keys.NumPad0;
                        for (var partynum = 1; partynum <= 5; partynum++)
                        {
                            this.Manager.KeyPress((Keys)(tecla + partynum - 1));
                            Thread.Sleep(500);

                            if (0 < (target = this.BaseMem?.Barco1?.PJInfo?.Info.TargetId))
                            {
                                this.Manager.KeyPress(config.AssistKey.GetKey());
                                Thread.Sleep(1000);
                                target = this.BaseMem?.Barco1?.PJInfo?.Info.TargetId;
                            }

                            if (target < 500000) // es un pj
                                target = 0;

                            if (target > 0)
                                break;
                        }
                    }
                    else
                    {
                        // Tab
                        lock (this.BaseMem.Barco1.PJInfo)
                            if (0 == (target = this.BaseMem?.Barco1?.PJInfo?.Info.TargetId))
                                this.Manager.KeyPress(Keys.Tab);
                    }
                }

                // ETAPA 2: ATACAR
                var atkrunning = false;
                while(target > 0)
                {
                    if (!atkrunning)
                    {
                        lock (AutoSpotKeysThreads)
                        {
                            for(var i = 1; i <= 6; i++)
                            {
                                var atk = config.GetAtk(i);

                                if (atk != null)
                                {
                                    AutoSpotKeysThreads.Add(atk.V1, new Thread(_DoAutoKey));
                                    AutoSpotKeysThreads[atk.V1].Start(new { key = atk.V1, time = atk.V2 });
                                }
                            }
                        }
                        atkrunning = true;
                    }

                    Thread.Sleep(500);

                    if (this.BaseMem?.Barco1?.PJInfo == null)
                    {
                        StopAutoSpotAtk();
                        this.OnAutoSpotStatusChange?.Invoke(this, false);
                        return;
                    }

                    lock (this.BaseMem.Barco1.PJInfo)
                        target = this.BaseMem?.Barco1?.PJInfo?.Info.TargetId;
                }
                StopAutoSpotAtk();

                // ETAPA: AUTO-PICK
                var time = DateTime.Now;
                while(config.HasPick && time.AddSeconds((config.PickTime ?? 4000) / 1000) > DateTime.Now && target == 0)
                {
                    this.Manager.KeyPress(config.PickKey.GetKey()); //picking
                    Thread.Sleep(100);

                    if (this.BaseMem?.Barco1?.PJInfo == null)
                    {
                        this.OnAutoSpotStatusChange?.Invoke(this, false);
                        return;
                    }

                    lock (this.BaseMem.Barco1.PJInfo)
                        target = this.BaseMem?.Barco1?.PJInfo?.Info.TargetId;
                }
            }
        }
        private void StopAutoSpotAtk()
        {
            lock (AutoSpotKeysThreads)
            {
                foreach (var thr in AutoSpotKeysThreads.Values)
                    thr.Abort();
                AutoSpotKeysThreads.Clear();
            }
        }

        #endregion

        #region AutoPick

        public void SetAutoPick(bool active)
        {
            if (!active && AutoPickThread != null)
            {
                AutoPickThread.Abort();
                AutoPickThread = null;
            }

            if (active && AutoFollowThread == null)
            {
                StopAll();

                AutoPickThread = new Thread(_DoAutoPick) { Priority = ThreadPriority.Lowest };
                AutoPickThread.Start();
            }

            this.OnAutoPickStatusChange?.Invoke(this, active);
        }
        private void _DoAutoPick()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(5000);
                // click en el centro de la pantalla
                var rect = this.Manager.GetWindowRect();
                this.Manager.MouseDown(rect.Width / 2, rect.Height / 2);
                Thread.Sleep(50);
                this.Manager.MouseUp(rect.Width / 2, rect.Height / 2);
            }
        }

        #endregion

        #region Auto Assist

        public void SetAutoAssist(bool active)
        {
            if (!active && AutoAssistThread != null)
            {
                AutoAssistThread.Abort();
                AutoAssistThread = null;
            }

            if (active && AutoAssistThread == null)
            {
                StopAll();

                AutoAssistThread = new Thread(_DoAutoAssist) { Priority = ThreadPriority.Lowest };
                AutoAssistThread.Start(this.Dal);
            }

            this.OnAutoAssistStatusChange?.Invoke(this, active);
        }
        private void _DoAutoAssist(object info)
        {
            var config = ((DAL.CuentaConfig)info).AutoAssist;

            uint? target = null;
            var followTime = DateTime.Now;
            var assistTime = DateTime.Now;
            while (true)
            {
                // etapa de espera de instrucciones (follow o assist)
                var attack = false;
                while(!attack)
                {
                    // ETAPA 1: follow a un pj (si tiene el FollowOrden > 0
                    if (config.FollowOrden > 0 && (followTime.AddSeconds(2) < DateTime.Now))    // pasaron 2 segs desde el último follow
                    {
                        // activo el follow
                        var x = 30;
                        var y = 218 + ((config.FollowOrden - 1) * 30);
                        this.Manager.MouseDblClick(x, y);
                        followTime = DateTime.Now;
                    }

                    // ETAPA 2: Verifico si el pj assist tiene un target
                    if (config.AssistTime > 0 && assistTime.AddSeconds(config.AssistTime / 1000) < DateTime.Now)         // paso el tiempo configurado como tiempo entre asistencias
                    {
                        if (!string.IsNullOrEmpty(config.AssistPJKey) && !string.IsNullOrEmpty(config.AssistKey))
                        {
                            this.Manager.KeyPress(config.AssistPJKey.GetKey()); // selecciono el pj
                            Thread.Sleep(500);
                            this.Manager.KeyPress(config.AssistKey.GetKey());   // presiono la tecla de assist in atack
                            Thread.Sleep(1000);

                            if (this.BaseMem?.Barco1?.PJInfo == null)
                            {
                                this.OnAutoAssistStatusChange?.Invoke(this, false);
                                return;
                            }

                            lock (this.BaseMem.Barco1.PJInfo)
                                target = this.BaseMem?.Barco1?.PJInfo?.Info.TargetId;

                            assistTime = DateTime.Now;
                        }
                    }

                    attack = target > 500000;
                }

                // ETAPA 3: si hay target, ataco hasta q muera
                var atkrunning = false;
                while (target > 0)
                {
                    if (!atkrunning)
                    {
                        lock (AutoAssistKeysThreads)
                        {
                            for (var i = 1; i <= 6; i++)
                            {
                                var atk = config.GetAtk(i);

                                if (atk != null)
                                {
                                    AutoAssistKeysThreads.Add(atk.V1, new Thread(_DoAutoKey));
                                    AutoAssistKeysThreads[atk.V1].Start(new { key = atk.V1, time = atk.V2 });
                                }
                            }
                        }
                        atkrunning = true;
                    }

                    Thread.Sleep(500);

                    if (this.BaseMem?.Barco1?.PJInfo == null)
                    {
                        StopAutoAssistAtk();
                        this.OnAutoAssistStatusChange?.Invoke(this, false);
                        return;
                    }

                    lock (this.BaseMem.Barco1.PJInfo)
                        target = this.BaseMem?.Barco1?.PJInfo?.Info.TargetId;
                }
                StopAutoAssistAtk();
            }
        }

        private void StopAutoAssistAtk()
        {
            lock (AutoAssistKeysThreads)
            {
                foreach (var thr in AutoAssistKeysThreads.Values)
                    thr.Abort();
                AutoAssistKeysThreads.Clear();
            }
        }

        #endregion
        internal void StopAll(params string[] except)
        {
            if (!(except?.Contains("AutoKey") ?? false))
            {
                // AUTO KEY
                foreach (var thr in AutoKeyThreads.Values)
                    thr.Abort();
                AutoKeyThreads.Clear();
                OnAutoKeyStatusChange?.Invoke(this, false);
            }

            if (!(except?.Contains("AutoFollow") ?? false))
            {
                // AUTO FOLLOW
                AutoFollowThread?.Abort();
                AutoFollowThread = null;
                OnAutoFollowStatusChange?.Invoke(this, false);
            }

            if (!(except?.Contains("AutoSpot") ?? false))
            {
                // AUTO SPOT
                StopAutoSpotAtk();

                AutoSpotThread?.Abort();
                AutoSpotThread = null;
                OnAutoSpotStatusChange?.Invoke(this, false);
            }

            if (!(except?.Contains("AutoPick") ?? false))
            {
                // AUTO SPOT
                AutoPickThread?.Abort();
                AutoPickThread = null;
                OnAutoPickStatusChange?.Invoke(this, false);
            }

            if (!(except?.Contains("AutoAssist") ?? false))
            {
                // AUTO ASSIST
                StopAutoAssistAtk();

                AutoAssistThread?.Abort();
                AutoAssistThread = null;
                OnAutoAssistStatusChange?.Invoke(this, false);
            }
        }

        public void Dispose()
        {
            StopAll();
            this.BaseMem.Dispose();
            this.BaseMem = null;

            OnDispose?.Invoke(this, this);
        }
    }
}
