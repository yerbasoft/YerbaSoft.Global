using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using YerbaSoft.DTO.Types;

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
        static extern IntPtr GetActiveWindow();

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        // HOOKS
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);



        public Process Process;
        private MemoryManager _Memory;
        public MemoryManager Memory => _Memory = _Memory ?? new MemoryManager(this.Process);

        public ProcessManager(Process proc)
        {
            this.Process = proc;
        }

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

        public void CloseApp()
        {
            try
            {
                this.Process.Kill();
            }
            catch(Exception ex) { }
        }

        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const uint WM_SYSKEYDOWN = 0x0104;
        const uint WM_SYSKEYUP = 0x0105;
        //const int WM_MOUSEMOVE = 0x00A0;
        const int WM_MOUSEMOVE = 0x0200;
        const int WM_LBUTTONDOWN = 0x0201;
        const int WM_LBUTTONUP = 0x0202;
        const int WM_LBUTTONDBLCLK = 0x0203;
        const int WM_RBUTTONDOWN = 0x0204;
        const int WM_RBUTTONUP = 0x0205;
        const int WM_RBUTTONDBLCLK = 0x0206;
        const int WM_MOUSEHWHEEL = 0x020E;

        const int WH_KEYBOARD_LL = 13;

        const int MK_SHIFT = 0x0004;

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
        public void MouseMove(uint x, uint y) => MouseMove(Convert.ToInt32(x), Convert.ToInt32(y));
        public void MouseMove(int x, int y)
        {
            var coords = (int)((y << 16) | (x & 0xFFFF));
            PostMessage(this.Process.MainWindowHandle, WM_MOUSEMOVE, 1, coords);
        }
        public void MouseDown(uint x, uint y, bool shift=false) => MouseDown(Convert.ToInt32(x), Convert.ToInt32(y), shift);
        public void MouseDown(int x, int y, bool shift = false)
        {
            var coords = (int)((y << 16) | (x & 0xFFFF));
            var par = 0;
            if (shift) par = MK_SHIFT;
            PostMessage(this.Process.MainWindowHandle, WM_LBUTTONDOWN, par, coords);
        }
        public void MouseUp(uint x, uint y, bool shift = false) => MouseUp(Convert.ToInt32(x), Convert.ToInt32(y), shift);
        public void MouseUp(int x, int y, bool shift = false)
        {
            var coords = (int)((y << 16) | (x & 0xFFFF));
            var par = 0;
            if (shift) par = MK_SHIFT;
            PostMessage(this.Process.MainWindowHandle, WM_LBUTTONUP, par, coords);
        }
        public void MouseRDown(int x, int y)
        {
            var coords = (int)((y << 16) | (x & 0xFFFF));
            PostMessage(this.Process.MainWindowHandle, WM_RBUTTONDOWN, 1, coords);
        }
        public void MouseRUp(int x, int y)
        {
            var coords = (int)((y << 16) | (x & 0xFFFF));
            PostMessage(this.Process.MainWindowHandle, WM_RBUTTONUP, 0, coords);
        }
        public void MouseDblClick(uint x, uint y) => MouseDblClick(Convert.ToInt32(x), Convert.ToInt32(y));
        public void MouseDblClick(int x, int y)
        {
            var coords = (int)((y << 16) | (x & 0xFFFF));
            PostMessage(this.Process.MainWindowHandle, WM_LBUTTONDBLCLK, 1, coords);
        }

        public void ShiftKeyDown()
        {
            (new WindowsInput.InputSimulator()).Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LSHIFT);
        }
        public void ShiftKeyUp()
        {
            (new WindowsInput.InputSimulator()).Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LSHIFT);
        }

        public void OnKeyboard(Keys capture, EventHandler<Keys> @event)
        {
            OnKeyboard(this.Process.MainWindowHandle, capture, @event);
        }

        private static IntPtr HookKeyboardHandler = IntPtr.Zero;
        private static LowLevelKeyboardProc DoHook = _DoHook;
        private static ThreeList<IntPtr, Keys, EventHandler<Keys>> Hooks = new ThreeList<IntPtr, Keys, EventHandler<Keys>>();
        public static void OnKeyboard(IntPtr hWin, Keys capture, EventHandler<Keys> @event)
        {
            if (HookKeyboardHandler == IntPtr.Zero)
                HookKeyboardHandler = SetWindowsHookEx(WH_KEYBOARD_LL, DoHook, System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle, 0);

            lock (Hooks)
                Hooks.Add(hWin, capture, @event);
        }

        private static IntPtr _DoHook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                var key = (Keys)Enum.Parse(typeof(Keys), vkCode.ToString());

                if (System.Windows.Input.Keyboard.Modifiers.HasFlag(System.Windows.Input.ModifierKeys.Shift))
                    key |= Keys.Shift;
                if (System.Windows.Input.Keyboard.Modifiers.HasFlag(System.Windows.Input.ModifierKeys.Alt))
                    key |= Keys.Alt;
                if (System.Windows.Input.Keyboard.Modifiers.HasFlag(System.Windows.Input.ModifierKeys.Control))
                    key |= Keys.Control;

                var hWin = GetForegroundWindow();

                IEnumerable<Three<IntPtr, Keys, EventHandler<Keys>>> hooks;
                lock (Hooks)
                {
                    foreach (var hook in Hooks.Where(p => (p.V1 == IntPtr.Zero || p.V1 == hWin) && p.V2 == key))
                        hook.V3.Invoke(null, key);
                }
            }

            return CallNextHookEx(HookKeyboardHandler, nCode, wParam, lParam);
        }

        public Bitmap CaptureScreen()
        {
            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(this.Process.MainWindowHandle);

            var rect = GetWindowRect();

            // create a device context we can copy to
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);

            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, rect.Width, rect.Height);

            // select the bitmap object
            IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);

            // bitblt over
            GDI32.BitBlt(hdcDest, 0, 0, rect.Width, rect.Height, hdcSrc, 0, 0, GDI32.SRCCOPY);

            // restore selection
            GDI32.SelectObject(hdcDest, hOld);

            // clean up 
            GDI32.DeleteDC(hdcDest);

            // get a .NET image object for it
            var img = Image.FromHbitmap(hBitmap);

            // free up the Bitmap object
            GDI32.DeleteObject(hBitmap);

            return img;
        }

        public void SetWindowForeground()
        {
            var b = User32.SetForegroundWindow(this.Process.MainWindowHandle);
            var err = Marshal.GetLastWin32Error();
            var err2 = Kernel.GetLastError();
        }

        public void SetWindowActive()
        {
            var b = User32.SetActiveWindow(this.Process.MainWindowHandle);
            var err = Marshal.GetLastWin32Error();
            var err2 = Kernel.GetLastError();
        }

        public void KeyDownSimulator(Keys key)
        {
            var code = (WindowsInput.Native.VirtualKeyCode)Enum.Parse(typeof(WindowsInput.Native.VirtualKeyCode), ((int)key).ToString());
            var dll = new WindowsInput.InputSimulator();
            dll.Keyboard.KeyDown(code);
        }

        public void KeyUpSimulator(Keys key)
        {
            var code = (WindowsInput.Native.VirtualKeyCode)Enum.Parse(typeof(WindowsInput.Native.VirtualKeyCode), ((int)key).ToString());
            var dll = new WindowsInput.InputSimulator();
            dll.Keyboard.KeyUp(code);
        }
    }
}
