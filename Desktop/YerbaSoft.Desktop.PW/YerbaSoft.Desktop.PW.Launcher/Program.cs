using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace YerbaSoft.Desktop.PW.Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var origen = ConfigurationManager.AppSettings["Origen"];
            var destino = ConfigurationManager.AppSettings["Destino"];
            var app = ConfigurationManager.AppSettings["App"];

            // cierro la app si está abierta
            foreach (var proc in Process.GetProcesses().Where(p => p.ProcessName == "YerbaSoft.Desktop.PW"))
                proc.Kill();

            // copio los archivos

            var exclude = new string[]
            {
                "YerbaSoft.Desktop.PW.CuentaConfigs.xml",
                "YerbaSoft.Desktop.PW.WinModes.xml"
            };
            foreach (var f in Directory.GetFiles(origen))
            {
                var info = new FileInfo(f);
                if (info.Exists)
                {
                    if (!exclude.Contains(info.Name))
                        File.Copy(info.FullName, Path.Combine(destino, info.Name), true);
                }
            }

            // abro la app
            //Process.Start(new ProcessStartInfo(Path.Combine(destino, app)) { });
        }
    }
}
