using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Desktop.PW
{
    public static class Global
    {
        public static Configuration.PWConfig Config { get; set; }
        public static bool Debug { get; set; }

        public static List<BLL.Cuenta> Cuentas { get; set; } = new List<BLL.Cuenta>();

        public static BLL.Cuenta AttachPW(Configuration.Cuenta config)
        {
            var proc = Process.GetProcesses().SingleOrDefault(p => p.MainWindowTitle.ToUpper().Contains("PWCLASSIC.NET"));
            if (proc == null)
                proc = Process.GetProcesses().SingleOrDefault(p => p.MainWindowTitle == (config.Name ?? config.Login));

            if (proc == null)
                return null;

            var cuenta = new BLL.Cuenta(proc, config);
            lock (Cuentas)
                Cuentas.Add(cuenta);
            cuenta.OnDispose += Cuenta_OnDispose;
            return cuenta;
        }

        public static BLL.Cuenta OpenPW(Configuration.Cuenta config)
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

            var cuenta = new BLL.Cuenta(proc, config);
            lock (Cuentas)
                Cuentas.Add(cuenta);
            cuenta.OnDispose += Cuenta_OnDispose;
            return cuenta;
        }

        private static void Cuenta_OnDispose(object sender, BLL.Cuenta e)
        {
            lock (Cuentas)
                if (Cuentas.Contains(e))
                    Cuentas.Remove(e);
        }
    }
}
