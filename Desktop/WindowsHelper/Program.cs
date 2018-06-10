using System;
using System.Windows.Forms;

namespace WindowsHelper
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var instalacion = args.Length > 0 ? args[0] : "DEBUG";

            var form = new Forms.MainForm();
            Global.Iniciar(instalacion, form);
            Global.Log("Iniciando Aplicación...");

            Config.Iniciar(Application.StartupPath);
            Global.IniciarApps();

            Application.Run(form);
            Global.Log("Finalizando Aplicación...");
        }
    }
}
