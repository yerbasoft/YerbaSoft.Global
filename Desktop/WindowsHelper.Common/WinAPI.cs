using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.Common
{
    public class WinAPI
    {
        public enum ShoWindowOptions
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_FORCEMINIMIZE = 11
        }

        private static int keyId;
        public static int WM_HOTKEY = 0x312;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(string lpClassName, string lpWindowName);
        [DllImport("User32")]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static IntPtr FindWin(string title, string exe)
        {
            return FindWindowByCaption(IntPtr.Zero, title);
        }

        public static IntPtr FindWindow(string value)
        {
            var res = FindWindowEx(value, null);
            if (res == null || res == default(IntPtr))
                res = FindWindowEx(string.Empty, value);

            return res;
        }

        public static void RegisterHotKey(Form f, Keys key)
        {
            int modifiers = 0;
            if ((key & Keys.Alt) == Keys.Alt)
                modifiers = modifiers | (int)Global.HotKeyModifiers.MOD_ALT;
            if ((key & Keys.Control) == Keys.Control)
                modifiers = modifiers | (int)Global.HotKeyModifiers.MOD_CONTROL;
            if ((key & Keys.Shift) == Keys.Shift)
                modifiers = modifiers | (int)Global.HotKeyModifiers.MOD_SHIFT;
            Keys k = key & ~Keys.Control & ~Keys.Shift & ~Keys.Alt;

            f.Invoke(new Action(() =>
            {
                keyId = f.GetHashCode();
                RegisterHotKey((IntPtr)f.Handle, keyId, modifiers, (int)k);
            }));
        }

        public static void UnregisterHotKey(Form f)
        {
            try
            {
                f.Invoke(new Action(() =>
                {
                    UnregisterHotKey(f.Handle, keyId);
                }));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ShowWindow(IntPtr hWin, ShoWindowOptions option)
        {
            ShowWindow(hWin, (int)option);
        }

        public static void SetFocusWin(IntPtr hwin)
        {
            SetForegroundWindow(hwin);
        }
    }
}
