using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Desktop.PW.BLL.Properties;

namespace YerbaSoft.Desktop.PW.BLL
{
    public static class ClientManager
    {
        public static EventHandler<PWParty> OnPartyCreated;
        public static EventHandler<PWParty> OnPartyDeleted;

        public static DTO.Configuration.PWCuentaConfig Config { get; set; }
        public static string AppIcon { get; set; }

        public static List<PWClient> Cuentas { get; set; } = new List<PWClient>();
        public static List<PWParty> Partys { get; set; } = new List<PWParty>();

        public static object TakeControlMouse { get; set; } = "Tomar Control del Mouse";
        public static object TakeControlKeyboard { get; set; } = "Tomar Control del Teclado";

        public static PWClient AttachPW(YerbaSoft.Desktop.PW.DTO.Configuration.Cuenta config)
        {
            var proc = Process.GetProcesses().FirstOrDefault(p => p.MainWindowTitle == (config.Name ?? config.Login));
            if (proc == null)
                proc = Process.GetProcesses().FirstOrDefault(p => p.MainWindowTitle.ToUpper().Contains("PWCLASSIC.NET"));
            if (proc == null)
                return null;

            return GetClient(proc, config);
        }

        public static PWClient OpenPW(DTO.Configuration.Cuenta config)
        {
            Process proc = null;

            var reintentos = 0;
            do
            {
                var pi = new ProcessStartInfo(Config.AppPath)
                {
                    WorkingDirectory = System.IO.Path.GetDirectoryName(Config.AppPath),
                    UseShellExecute = true
                };
                proc = Process.Start(pi);

                proc.WaitForInputIdle(10000);
                if (!proc.Responding)
                {
                    proc.Kill();
                    proc.Dispose();
                    proc = null;
                }

                reintentos++;
            } while (proc == null && reintentos < 5);

            if (proc == null)
                return null;

            return GetClient(proc, config);
        }

        private static PWClient GetClient(Process proc, DTO.Configuration.Cuenta config)
        {
            var dbConfig = DAL.CuentaConfig.Get(config.Name ?? config.Login) ?? new DAL.CuentaConfig() { Id = Guid.NewGuid(), Login = config.Name ?? config.Login };
            var cuenta = new PWClient(proc, config, dbConfig);
            cuenta.Manager.SetWindowTitle(config.Name ?? config.Login);

            lock (Cuentas)
                Cuentas.Add(cuenta);

            cuenta.OnDisposing += (sender, c) =>
            {
                lock (Cuentas)
                    if (Cuentas.Contains(c))
                        Cuentas.Remove(c);
            };

            return cuenta;
        }

        public static Image GetIcon(string type)
        {
            switch (type ?? "ER")
            {
                case "WR": return Resources.WR;
                case "MG": return Resources.MG;
                case "WB": return Resources.WB;
                case "WF": return Resources.WF;
                case "EA": return Resources.EA;
                case "EP": return Resources.EP;
                case "AS": return Resources.AS;
                case "PS": return Resources.PS;
                case "SE": return Resources.SE;
                case "MY": return Resources.MY;
                case "SB": return Resources.SB;
                case "DB": return Resources.DB;
                case "TE": return Resources.TE;
                default: return Resources.ER;
            }
        }

        public static PWParty CreateParty(PWClient client)
        {
            PWParty party = new PWParty(client);
            Partys.Add(party);
            OnPartyCreated?.Invoke(null, party);
            return party;
        }

        public static void RemoveParty(PWParty party)
        {
            Partys.Remove(party);
            OnPartyDeleted?.Invoke(null, party);
        }

    }
}
