using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.Visual
{
    public static class Monitors
    {
        public static Rect GetLeftMonitorCoords()
        {
            Rect res = new Rect();
            var list = new List<Rect>();
            MonitorEnumProc callback = (IntPtr hDesktop, IntPtr hdc, ref Rect prect, int d) => { list.Add(prect); return true; };

            if (EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, callback, 0))
                res = list.OrderBy(p => p.left).ThenBy(p => p.top).First();
            return res;
        }
        [DllImport("user32")]
        private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lpRect, MonitorEnumProc callback, int dwData);

        private delegate bool MonitorEnumProc(IntPtr hDesktop, IntPtr hdc, ref Rect pRect, int dwData);

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
    }
}
