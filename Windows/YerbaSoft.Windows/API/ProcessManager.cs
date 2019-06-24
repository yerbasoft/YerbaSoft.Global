using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YerbaSoft.Windows.API
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct RECT
    {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner
    }

    public class ProcessManager
    {
        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);
        
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);


        public Process Process;
        private MemoryManager _Memory;
        public MemoryManager Memory => _Memory = _Memory ?? new MemoryManager(this.Process);

        /// <summary>
        /// Cambia el titulo de una ventana
        /// </summary>
        public int SetWindowTitle(string newtext) => SetWindowText(this.Process.MainWindowHandle, newtext);

        public void SetWindowRect(int x, int y, int width, int height)
        {
            const short SWP_NOMOVE = 0X2;
            const short SWP_NOSIZE = 1;
            const short SWP_NOZORDER = 0X4;
            const int SWP_SHOWWINDOW = 0x0040;

            var flags = SWP_NOZORDER | SWP_SHOWWINDOW;
            if (width == 0 || height == 0)
                flags = flags | SWP_NOSIZE;

            SetWindowPos(this.Process.MainWindowHandle, 0, x, y, width, height, flags);
        }

        public Rectangle GetWindowRect()
        {
            GetWindowRect(this.Process.MainWindowHandle, out var rect);
            return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
        }


        public ProcessManager(Process proc)
        {
            this.Process = proc;
        }
        
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_LBUTTONDOWN = 0x0201;
        const int WM_LBUTTONUP = 0x0202;
        const int WM_LBUTTONDBLCLK = 0x0203;

        public void KeyDown(Keys key)
        {
            PostMessage(this.Process.MainWindowHandle, WM_KEYDOWN, (int)key, 0);
        }
        public void KeyUp(Keys key)
        {
            PostMessage(this.Process.MainWindowHandle, WM_KEYUP, (int)key, 0);
        }
        public void KeyPress(Keys key)
        {
            PostMessage(this.Process.MainWindowHandle, WM_KEYDOWN, (int)key, 0);
            Thread.Sleep(10);
            PostMessage(this.Process.MainWindowHandle, WM_KEYUP, (int)key, 0);
        }
        public void MouseDown(int x, int y)
        {
            var coords = (int)((y << 16) | (x & 0xFFFF));
            PostMessage(this.Process.MainWindowHandle, WM_LBUTTONDOWN, 1, coords);
        }
        public void MouseUp(int x, int y)
        {
            var coords = (int)((y << 16) | (x & 0xFFFF));
            PostMessage(this.Process.MainWindowHandle, WM_LBUTTONUP, 0, coords);
        }
        public void MouseDblClick(int x, int y)
        {
            var coords = (int)((y << 16) | (x & 0xFFFF));
            PostMessage(this.Process.MainWindowHandle, WM_LBUTTONDBLCLK, 1, coords);
        }
    }
}
