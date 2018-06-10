using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.Visual
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var p = Monitors.GetLeftMonitorCoords();
            var win = new Detector();
            win.StartPosition = FormStartPosition.Manual;
            win.Left = p.left - 5;
            win.Top = p.top - 5;
            win.AllowTransparency = true;
            win.TransparencyKey = win.BackColor;
            win.TopMost = true;
            win.DesktopBounds = new System.Drawing.Rectangle(p.left, p.top, 500, 500);
            
            Application.Run(win);
        }
    }
}
