using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using YerbaSoft.DTO;

namespace WindowsHelper.Launcher
{
    class Program
    {
        const string CONFIG_FILE_NAME = "WindowsHelper.Launcher.xml";

        static void Main(string[] args)
        {
            var xml = new XmlDocument();
            xml.Load(CONFIG_FILE_NAME);
            var mainConfig = (XmlNode)xml.DocumentElement;
            var source = mainConfig.SubNode("Source").InnerText;
            var mainapp = mainConfig.SubNode("MainApp").InnerText;
            var instalacion = mainConfig.SubNode("Instalacion").InnerText;
            
            if (string.IsNullOrEmpty(instalacion))
            {
                Console.Write("Ingrese el nombre de la instalación: ");
                var newinstalation = Console.ReadLine();

                mainConfig.SubNode("Instalacion").InnerText = newinstalation;
                xml.Save(CONFIG_FILE_NAME);
                instalacion = newinstalation;
            }

            var sMainFile = new System.IO.FileInfo(System.IO.Path.Combine(source, mainapp));
            var dMainFile = new System.IO.FileInfo(System.IO.Path.Combine(System.Environment.CurrentDirectory, mainapp));
                        
            if (sMainFile.CreationTime > dMainFile.CreationTime)   // Actualizar
            {
                Process.Start(new ProcessStartInfo("taskkill.exe", "/im \"WindowsHelper.exe\" /f /t") { UseShellExecute = true, CreateNoWindow = true }).WaitForExit();

                xcopy(source, source, System.Environment.CurrentDirectory);

                Process.Start(new ProcessStartInfo(dMainFile.FullName, instalacion) { UseShellExecute = true });
            }
        }

        private static void xcopy(string rootSource, string source, string rootTarget)
        {
            var subfolder = source.Substring(rootSource.Length);
            if (subfolder.StartsWith("\\")) subfolder = "." + subfolder;

            var destiny = System.IO.Path.Combine(rootTarget, subfolder);

            Process.Start(new ProcessStartInfo("xcopy", $"\"{System.IO.Path.Combine(source, "*.*")}\" \"{destiny}\" /E /H /R /Y /I") { UseShellExecute = true, CreateNoWindow = true }).WaitForExit();

            foreach (var dir in System.IO.Directory.GetDirectories(source))
                xcopy(rootSource, dir, rootTarget);
        }
    }
}
