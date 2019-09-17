using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;
using YerbaSoft.DTO.Types;

namespace YerbaSoft.Desktop.PW.BLL.Auto
{
    public class AutoManager
    {
        private PWClient Client;

        // Flags
        public bool IsAutoFollowRunning => this.AutoFollowThread != null;
        public bool IsAnyAutoKeyRunning => this.AutoKeyThreads.Count > 0;
        public bool IsAutoSpotRunning => this.AutoSpotThread?.IsAlive ?? false;
        public bool IsAutoAssistRunning => this.AutoAssistThread != null;
        public bool IsVillaRunning => this.VillaThread?.IsAlive ?? false;

        // Events
        public event EventHandler<bool> OnAutoKeyStatusChange;
        public event EventHandler<bool> OnAutoSpotStatusChange;
        public event EventHandler<bool> OnAutoFollowStatusChange;
        public event EventHandler<bool> OnAutoAssistStatusChange;
        public event EventHandler<bool> OnVillaStatusChange;

        // Threads
        private Dictionary<Keys, Thread> AutoKeyThreads = new Dictionary<Keys, Thread>();
        private Thread AutoFollowThread;
        private Thread AutoSpotThread;
        private Thread AutoAssistThread;
        private Thread VillaThread;
        private Dictionary<Keys, Thread> AutoSpotKeysThreads = new Dictionary<Keys, Thread>();
        private Dictionary<Keys, Thread> AutoAssistKeysThreads = new Dictionary<Keys, Thread>();

        public AutoManager(PWClient client)
        {
            this.Client = client;
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
                this.Client.Manager.MouseDblClick(30, 218);
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

            while (true)
            {
                Thread.Sleep(time);
                this.Client.Manager.KeyPress(key);
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

        public void SetAutoKeyAll(bool active)
        {
            if (active)
            {
                foreach (var keys in this.Client.dbConfig.AutoKey.Keys)
                    SetAutoKey(keys.Key.GetKey(), keys.Time, true);
            }
            else
            {
                this.StopAll();
            }
        }

        #endregion

        #region AutoSpot

        public void SetAutoSpot(bool active)
        {
            if (this.Client.dbConfig.AutoSpot == null)
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
                AutoSpotThread.Start(this.Client.dbConfig);
            }

            this.OnAutoSpotStatusChange?.Invoke(this, active);
        }
        private void _DoAutoSpot(object input)
        {
            var config = ((DAL.CuentaConfig)input).AutoSpot;
            var atkKeys = ((DAL.CuentaConfig)input).AutoKey.Keys;

            uint? target = 0;
            var lastBuffTime = DateTime.MinValue;
            while (true)
            {
                //ETAPA 0: BUFF
                if (config.HasBuff && target == 0 && lastBuffTime.AddSeconds(config.BuffExpireTime / 1000) < DateTime.Now)
                {
                    var skills = new TwoList<Keys, int>(config.BuffKey.GetKey(), config.BuffCastTime);
                    if (this.Client.Action.Skills.DoBuff(true, skills))
                        lastBuffTime = DateTime.Now;
                }

                // ETAPA 1: BUSCAR TARGET
                while (target == 0)
                {
                    Thread.Sleep(500);

                    if (this.Client.Mem.Base1?.PJInfo == null)
                    {
                        this.OnAutoSpotStatusChange?.Invoke(this, false);
                        return;
                    }

                    if (500000 < (target = this.Client.Mem.Base1?.PJInfo?.Data.TargetId))
                        break;

                    // modos de seleción de Target
                    if (config.AssistMob > 0)
                    {
                        // Selección por dbCode
                        var mob = this.Client.Mem.Link.NPC.GetAll().Where(p => p.IsMob && p.Data.dbCode == config.AssistMob).OrderBy(p => p.Data.DistAlPJ).FirstOrDefault();
                        if (mob != null)
                        {
                            this.Client.Mem.Link.PJInfo.SetTarget(mob.Data.Id); // lo marca pero es intargeteable
                        }
                    }
                    else if (!string.IsNullOrEmpty(config.AssistKey) && config.AssistKey != "Tab")
                    {
                        // Seleccion por asistencia (con tecla de assist)
                        var tecla = (int)Keys.NumPad0;
                        for (var partynum = 1; partynum <= 5; partynum++)
                        {
                            this.Client.Manager.KeyPress((Keys)(tecla + partynum - 1));
                            Thread.Sleep(500);

                            if (0 < (target = this.Client.Mem.Base1?.PJInfo?.Data.TargetId))
                            {
                                this.Client.Manager.KeyPress(config.AssistKey.GetKey());
                                Thread.Sleep(1000);
                                target = this.Client.Mem.Base1?.PJInfo?.Data.TargetId;
                            }

                            if (target < 500000) // es un pj
                                target = 0;

                            if (target > 0)
                                break;
                        }
                    }
                    else
                    {
                        // Seleccion por TAB
                        lock (this.Client.Mem.Base1.PJInfo)
                            if (0 == (target = this.Client.Mem.Base1?.PJInfo?.Data.TargetId))
                                this.Client.Manager.KeyPress(Keys.Tab);
                    }
                }

                // ETAPA 2: ATACAR
                var atkrunning = false;
                while (target > 0)
                {
                    if (!atkrunning)
                    {
                        lock (AutoSpotKeysThreads)
                        {
                            foreach(var key in atkKeys)
                            {
                                AutoSpotKeysThreads.Add(key.Key.GetKey(), new Thread(_DoAutoKey));
                                AutoSpotKeysThreads[key.Key.GetKey()].Start(new { key = key.Key.GetKey(), time = key.Time });
                            }
                        }
                        atkrunning = true;
                    }

                    Thread.Sleep(500);

                    if (this.Client.Mem.Base1?.PJInfo == null)
                    {
                        StopAutoSpotAtk();
                        this.OnAutoSpotStatusChange?.Invoke(this, false);
                        return;
                    }

                    lock (this.Client.Mem.Base1.PJInfo)
                        target = this.Client.Mem.Base1?.PJInfo?.Data.TargetId;
                }
                StopAutoSpotAtk();

                // ETAPA: AUTO-PICK
                var time = DateTime.Now;
                while (config.HasPick && time.AddSeconds(config.PickTime / 1000) > DateTime.Now && target == 0)
                {
                    this.Client.Manager.KeyPress(config.PickKey.GetKey()); //picking
                    Thread.Sleep(100);

                    if (this.Client.Mem.Base1?.PJInfo == null)
                    {
                        this.OnAutoSpotStatusChange?.Invoke(this, false);
                        return;
                    }

                    lock (this.Client.Mem.Base1.PJInfo)
                        target = this.Client.Mem.Base1?.PJInfo?.Data.TargetId;
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
                AutoAssistThread.Start(this.Client.dbConfig);
            }

            this.OnAutoAssistStatusChange?.Invoke(this, active);
        }
        private void _DoAutoAssist(object info)
        {
            var config = ((DAL.CuentaConfig)info).AutoAssist;
            var atkKeys = ((DAL.CuentaConfig)info).AutoKey.Keys;

            uint? target = 0;
            var followTime = DateTime.Now;
            var assistTime = DateTime.Now;
            while (true)
            {
                // ETAPA 1: etapa de espera de instrucciones (follow o assist)
                var attack = false;
                while (!attack && (target ?? 0) == 0)
                {
                    // ETAPA 1: follow a un pj (si tiene el FollowOrden > 0
                    if (followTime.AddSeconds(2) < DateTime.Now)    // pasaron 2 segs desde el último follow
                    {
                        // activo el follow
                        var x = 30;
                        var y = 218 + (config.FollowPartyNum * 30);
                        this.Client.Manager.MouseDblClick(x, y);
                        followTime = DateTime.Now;
                    }

                    // ETAPA 2: Verifico si el pj assist tiene un target
                    if (config.AssistTime > 0 && assistTime.AddSeconds(config.AssistTime / 1000.0) < DateTime.Now)         // paso el tiempo configurado como tiempo entre asistencias
                    {
                        if (!string.IsNullOrEmpty(config.AssistPJKey) && !string.IsNullOrEmpty(config.AssistKey))
                        {
                            this.Client.Manager.KeyPress(config.AssistPJKey.GetKey()); // selecciono el pj
                            Thread.Sleep(500);
                            this.Client.Manager.KeyPress(config.AssistKey.GetKey());   // presiono la tecla de assist in atack
                            Thread.Sleep(1000);

                            assistTime = DateTime.Now;
                        }
                    }

                    if (this.Client.Mem?.Base1?.PJInfo == null)
                    {
                        this.OnAutoAssistStatusChange?.Invoke(this, false);
                        return;
                    }
                    lock (this.Client.Mem?.Link?.PJInfo)
                        target = this.Client.Mem?.Link?.PJInfo?.Data.TargetId;

                    target = (target ?? 0) > 500000 ? target : 0;
                    attack = target > 500000;
                }

                // ETAPA 2: si hay target, ataco hasta q muera
                var atkrunning = false;
                while (target > 0)
                {
                    if (!atkrunning)
                    {
                        lock (AutoAssistKeysThreads)
                        {
                            foreach(var atk in atkKeys.Where(p => p.Time > 0))
                            {
                                AutoAssistKeysThreads.Add(atk.Key.GetKey(), new Thread(_DoAutoKey));
                                AutoAssistKeysThreads[atk.Key.GetKey()].Start(new { key = atk.Key.GetKey(), time = atk.Time });
                            }
                        }
                        atkrunning = true;
                    }

                    Thread.Sleep(500);

                    if (this.Client.Mem.Base1?.PJInfo == null)
                    {
                        StopAutoAssistAtk();
                        this.OnAutoAssistStatusChange?.Invoke(this, false);
                        return;
                    }

                    lock (this.Client.Mem.Base1.PJInfo)
                        target = this.Client.Mem.Base1?.PJInfo?.Data.TargetId;
                    target = (target ?? 0) > 500000 ? target : 0;
                }
                StopAutoAssistAtk();


                // ETAPA: AUTO-PICK
                var time = DateTime.Now;
                while (config.HasPick && time.AddSeconds(config.PickTime / 1000) > DateTime.Now && target == 0)
                {
                    this.Client.Manager.KeyPress(config.PickKey.GetKey()); //picking
                    Thread.Sleep(100);

                    if (this.Client.Mem.Base1?.PJInfo == null)
                    {
                        this.OnAutoSpotStatusChange?.Invoke(this, false);
                        return;
                    }

                    lock (this.Client.Mem.Base1.PJInfo)
                        target = this.Client.Mem.Base1?.PJInfo?.Data.TargetId;
                    target = (target ?? 0) > 500000 ? target : 0;
                }
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

        #region Villa

        public void SetVilla(bool active)
        {
            if (!active && (VillaThread?.IsAlive ?? false))
            {
                VillaThread.Abort();
                VillaThread = null;
            }

            if (active && !(VillaThread?.IsAlive ?? false))
            {
                StopAll();

                VillaThread = new Thread(_DoVilla) { Priority = ThreadPriority.Lowest };
                VillaThread.Start();
            }

            this.OnVillaStatusChange?.Invoke(this, active);
        }
        private void _DoVilla()
        {
            try
            {
                while (true)
                {
                    // reviso que item tengo a ver donde tengo que ir
                    var dbcodes = this.Client.Mem.Link.InventoryQuestItem.GetItems().Where(p => p != null).Select(p => p.Data.dbCode);
                    var toPoint = BLL.DataManager.Villa.VillaPoint.Where(p => dbcodes.Contains(p.RequestItem)).FirstOrDefault();
                    if (toPoint == null)
                        StopVilla(true, "Sin Item");

                    // Ir al nuevo NPC
                    if (!this.Client.Action.Move.GoTo(true, toPoint.NPC_X, toPoint.NPC_Z - 1, toPoint.MinFlyForArrive, true, BLL.DataManager.Villa.FreezeDuringFly))
                        StopVilla(true, "Error On GoTo");

                    this.Client.Action.Move.DoFly(false);

                    if (!this.Client.Action.Interact.DoTalkNearNPC(toPoint.NPC_dbCode, toPoint.QuestName))
                        StopVilla(true, "Error On Talk");

                    // mover antes de salir 
                    if (!string.IsNullOrEmpty(toPoint.MoveOnExit))
                    {
                        var x = Convert.ToSingle(toPoint?.MoveOnExit.Split(';')[0], CultureInfo.InvariantCulture);
                        var z = Convert.ToSingle(toPoint?.MoveOnExit.Split(';')[1], CultureInfo.InvariantCulture);
                        this.Client.Action.Move.GoTo(false, x, z, 0, true, BLL.DataManager.Villa.FreezeDuringFly);
                    }

                    // volar antes de salir
                    if ((toPoint?.MinYOnExit ?? 0) > 0)
                        this.Client.Action.Move.DoFly(true, toPoint.MinYOnExit);
                    
                    // espero a que me dé otro item de villa
                    Thread.Sleep(1000); // éste timer es para esperar que desaparezca el anterior (a veces tarda en desaparecer de la lista)
                    var start = DateTime.Now;
                    while (start.AddSeconds(20) > DateTime.Now)
                    {
                        var items = this.Client.Mem.Link.InventoryQuestItem.GetItems().Where(p => p != null).Select(p => p.Data.dbCode);

                        var exists = BLL.DataManager.Villa.VillaPoint.Any(p => items.Contains(p.RequestItem));
                        if (exists)
                            break;

                        Thread.Sleep(600);
                    }
                }
            }
            catch
            {
                StopAll();
            }
        }
        public void StopVilla(bool wait = true, string msg = null)
        {
            new Thread((message) => {
                VillaThread?.Abort();
                VillaThread = null;
                OnVillaStatusChange?.Invoke(this, false);
                this.Client.SetMessage((string)message);
            }).Start(msg);

            while (wait) { Thread.Sleep(200); if (VillaThread == null) return; } // me quedo en bucle esperando que cierre
        }

        #endregion

        public void StopAll(params string[] except)
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

            if (!(except?.Contains("AutoAssist") ?? false))
            {
                // AUTO ASSIST
                StopAutoAssistAtk();

                AutoAssistThread?.Abort();
                AutoAssistThread = null;
                OnAutoAssistStatusChange?.Invoke(this, false);
            }

            if (!(except?.Contains("Villa") ?? false))
            {
                StopVilla(wait:true);
            }
        }

        public void Dispose()
        {
            StopAll();
        }
    }
}
