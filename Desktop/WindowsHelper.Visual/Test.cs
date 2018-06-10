using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.Visual
{
    public class Test
    {
        private const int MONITOR_DEFAULTTONEAREST = 2;

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern UInt32 MonitorFromPoint(Point pt, UInt32 dwFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern bool GetMonitorInfo(UInt32 monitorHandle, ref MonitorInfo mInfo);
        
        public static void GetMonitorInfoNow(MonitorInfo mi, Point pt)
        {
            UInt32 mh = MonitorFromPoint(pt, 0);
            mi.cbSize = (UInt32)System.Runtime.InteropServices.Marshal.SizeOf(typeof(MonitorInfo));
            mi.dwFlags = 0;
            bool result = GetMonitorInfo(mh, ref mi);

        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class MonitorInfo
    {
        public UInt32 cbSize;
        public Rectangle2 rcMonitor;
        public Rectangle2 rcWork;
        public UInt32 dwFlags;

        public MonitorInfo()
        {
            rcMonitor = new Rectangle2();
            rcWork = new Rectangle2();

            cbSize = (UInt32)System.Runtime.InteropServices.Marshal.SizeOf(typeof(MonitorInfo));
            dwFlags = 0;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Rectangle2
    {
        public UInt64 left;
        public UInt64 top;
        public UInt64 right;
        public UInt64 bottom;

        public Rectangle2()
        {
            left = 0;
            top = 0;
            right = 0;
            bottom = 0;
        }
    }
}
