using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YerbaSoft.DTO;

namespace WindowsHelper
{
    public static class Global
    {
        public enum HotKeyModifiers
        {
            MOD_NONE= 0x0,
            MOD_ALT = 0x1,
            MOD_CONTROL = 0x2,
            MOD_SHIFT = 0x4,
            MOD_WIN = 0x8
        }

        public const string AppName = "WindowsHelper";
        public static string Instalacion { get; private set; }
        internal static Form MainForm { get; private set; }
        private static NLog.ILogger Logger { get; set; }
        public static bool IsDebugMode { get { return Instalacion.ToUpper() == "DEBUG"; } }
        public delegate void HotKeyDelegate(Keys key);
        private static Dictionary<Keys, HotKeyDelegate> HotKeys = new Dictionary<Keys, HotKeyDelegate>();

        public static void Iniciar(string instalacion, Form mainForm)
        {
            Instalacion = instalacion;
            MainForm = mainForm;
            MainForm.Text += " - " + instalacion;
            Logger = NLog.LogManager.GetLogger(AppName);
        }

        public static void IniciarApps()
        {
            foreach(var app in Config.Applications.App)
            {
                var iapp = (Interfaces.IApp)Type.GetType($"{app.IAppClass}, {app.AssemblyName}").GetConstructor(new Type[] { }).Invoke(new Type[] { });
                iapp.Inicializar(app);
            }
        }

        #region Log

        public static void Log(string text, LogLevel level = LogLevel.Info)
        {
            var fechahora = $"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")} [{level.GetDescripcion()}] :: ";
            var tab = new string(' ', fechahora.Length);
            var formatedText = fechahora + text.Replace(Environment.NewLine, Environment.NewLine + tab);

            if (MainForm != null)
                MainForm.GetType().GetMethod("Log", new Type[] { typeof(string) }).Invoke(MainForm, new object[] { formatedText });
            //MainForm.Log(formatedText);
            Logger.Info(formatedText);
        }

        public static void Log(Exception ex)
        {
            Log(ex.GetFullDescription(), LogLevel.Error);
        }

        #endregion

        #region Events

        public delegate IEnumerable<ToolStripItem> CreateMenuHandler();
        public static event CreateMenuHandler OnCreateMenu;

        public static IEnumerable<ToolStripItem> RaiseOnCreateMenu()
        {
            Log("OnCreateMenu");

            if (OnCreateMenu == null)
                return new ToolStripItem[] { };

            return OnCreateMenu.GetInvocationList().SelectMany(x => ((CreateMenuHandler)x)());
        }

        #endregion

        public static string GetIconByExtension(string extension)
        {
            switch (extension.ToLower())
            {
                case ".txt": return @".\EasyOpen\file_text.ico";
                case ".pdf": return @".\EasyOpen\pdf.ico";
                case ".xml": return @".\EasyOpen\XML.ico";
                case ".gif": return @".\EasyOpen\file_gif.ico";
                case ".jpg":
                case ".png":
                case ".jpeg":
                    return @".\EasyOpen\file_jpg.ico";
                case ".bmp": return @".\EasyOpen\file_bmp.ico";
                case ".wav":
                case ".mp3":
                    return @".\EasyOpen\file_audio.ico";
                case ".avi":
                case ".mkv":
                case ".mpg":
                case ".mp4":
                    return @".\EasyOpen\file_video.ico";
                case ".zip":
                case ".rar":
                    return @"C:\Program Files\WinRAR\WinRAR.exe";
                case ".epub":
                case ".azw3":
                    return @".\EasyOpen\epub.ico";
                case ".csv":
                case ".xls":
                case ".xlsx":
                    return @"C:\Program Files\Microsoft Office\root\Office16\EXCEL.EXE";
                case ".doc":
                case ".docx":
                    return @"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE";
                case ".sln":
                    return @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv.exe";
                case ".sql":
                    return @"W:\app\SQL Developer\sqldeveloper.exe";
                case ".htm":
                case ".html":
                    return @".\EasyOpen\web.png";
                default: return null;
            }
        }
        
        /// <summary>
        /// registra una tecla para que se dispare al momento de presionarla (HotKey)
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="key"></param>
        public static void RegisterHotKey(Keys key, HotKeyDelegate callback)
        {
            if (!HotKeys.ContainsKey(key))
            {
                HotKeys.Add(key, callback);
                Common.WinAPI.RegisterHotKey(MainForm, key);
            }
        }

        public static void RaiseHotKey(Keys key)
        {
            if (HotKeys.ContainsKey(key))
            {
                HotKeys[key].Invoke(key);
            }
        }
    }
}
