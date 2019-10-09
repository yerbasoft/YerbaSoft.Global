using CSWork.Interface.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.Interface
{
    public static class Recursos
    {
        public enum Types
        {
            Priority,
            Status
        }

        public static Bitmap GetBitmap(Types type, string key, string url)
        {
            var filename = GetFileName(type, key, url);
            
            if (!System.IO.File.Exists(filename))
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(url, filename);
                }
            }

            return new Bitmap(filename);
        }

        private static string GetFileName(Types type, string key, string url)
        {
            var extension = url.Substring(url.LastIndexOf('.') + 1);

            if (!System.IO.Directory.Exists(Path.Combine(AppContext.BaseDirectory, "Resources")))
                System.IO.Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, "Resources"));

            return Path.Combine(AppContext.BaseDirectory, "Resources", $"res_{type}_{key}_{url.GetHashCode()}.{extension}");
        }

        internal static T Get<T>(string key)
        {
            var local = typeof(Resources).GetProperty(key, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            if (local != null)
                return (T)local.GetValue(null);

            return default;
        }

        internal static Image GetImageForFile(string filename, string mimeType)
        {
            var point = filename.LastIndexOf('.');
            var extension = point > 1 ? filename.Substring(point) : "";

            if (mimeType.Contains("image/"))
                return Resources.ext_image;

            if (extension == ".doc" || extension == ".docx" || mimeType.Contains("vnd.openxmlformats-officedocument.wordprocessingml.document"))
                return Resources.ext_word;

            if (extension == ".xls" || extension == ".xlsx" || mimeType.Contains("vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
                return Resources.ext_excel;

            if (extension == ".sql")
                return Resources.ext_sql;

            if (extension == ".txt" || extension == ".log" || mimeType.Contains("vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
                return Resources.ext_text;

            if (extension == ".msg")
                return Resources.ext_mail;

            if (extension == ".json" || mimeType.Contains("application/json"))
                return Resources.ext_json;

            if (extension == ".pdf" || mimeType.Contains("application/pdf"))
                return Resources.ext_pdf;

            if (mimeType.Contains("binary/octet-stream"))
                return Resources.ext_binary;

            return Resources.book_blue.ToBitmap();

        }

        internal static Image GetImageForFile(string filename, object mimeType)
        {
            throw new NotImplementedException();
        }

        internal static object GetBitmap(Types status, string id, object iconUrl)
        {
            throw new NotImplementedException();
        }




        internal static Dictionary<string, Bitmap> GetAllImages()
        {
            var res = new Dictionary<string, Bitmap>();
            var props = typeof(Resources).GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            foreach(var p in props)
            {
                Bitmap img = null;
                if (p.PropertyType == typeof(Bitmap))
                    img = (Bitmap)p.GetValue(null);
                if (p.PropertyType == typeof(Icon))
                    img = ((Icon)p.GetValue(null)).ToBitmap();

                if (img != null)
                    res.Add(p.Name, img);
            }
            return res;
        }

        internal static Image GetImage(string data)
        {
            var p = typeof(Resources).GetProperty(data, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            if (p != null)
            {
                if (p.PropertyType == typeof(Bitmap))
                    return (Bitmap)p.GetValue(null);
                if (p.PropertyType == typeof(Icon))
                    return ((Icon)p.GetValue(null)).ToBitmap();
            }

            if (System.IO.File.Exists(data))
            {
                return Icon.ExtractAssociatedIcon(data).ToBitmap();
            }

            return null;
        }
    }
}
