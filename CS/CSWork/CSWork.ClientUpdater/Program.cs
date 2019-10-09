using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.ClientUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            var origen = System.Configuration.ConfigurationManager.AppSettings["origin"];
            var destino = System.Configuration.ConfigurationManager.AppSettings["destination"];
            var exclude = System.Configuration.ConfigurationManager.AppSettings["exclude"].Split(';');
            if (origen.StartsWith("."))
                origen = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, origen);
            if (destino.StartsWith("."))
                destino = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, destino);

            CopyDirectory(origen, destino, exclude.Select(e => e.ToUpper()));
        }

        private static void CopyDirectory(string origen, string destino, IEnumerable<string> exclude)
        {
            var files = System.IO.Directory.GetFiles(origen)
                            .Select(p => p.Substring(p.LastIndexOf('\\') + 1))
                            .Where(f => !exclude.Contains(f.ToUpper()));

            if (!System.IO.Directory.Exists(destino))
                System.IO.Directory.CreateDirectory(destino);

            foreach (var file in files)
            {
                System.IO.File.Copy(System.IO.Path.Combine(origen, file), System.IO.Path.Combine(destino, file), true);
            }

            foreach(var dir in System.IO.Directory.GetDirectories(origen))
            {
                CopyDirectory(origen, destino, exclude);
            }
        }
    }
}
