using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO;

namespace YerbaSoft.Desktop.OracleCloner
{
    public static class Log
    {
        private static string FileName { get { return $"{DateTime.Now.ToString("yyyyMMdd")}-script.sql"; } }

        public static void Script(string sql)
        {
            System.IO.File.AppendAllText(FileName, $"{sql};{Environment.NewLine}");
        }

        public static void Trace(string txt)
        {
            var text = $"//{DateTime.Now.ToString("yyyyMMdd HH:mm")} *** {txt} ***{Environment.NewLine}";
            Console.WriteLine(txt);
            System.IO.File.AppendAllText(FileName, text);
        }

        public static void Error(Exception ex)
        {
            Console.WriteLine(ex.GetFullDescription());
            System.IO.File.AppendAllText(FileName, ex.GetFullDescription() + Environment.NewLine);
        }
    }
}
