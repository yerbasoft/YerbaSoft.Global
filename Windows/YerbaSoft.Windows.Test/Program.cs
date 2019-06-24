using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YerbaSoft.Windows.API;

namespace YerbaSoft.Windows.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Procesos Abiertos...");
            Process[] procesos = null;
            foreach(var p in procesos = Process.GetProcesses().Where(p => !string.IsNullOrEmpty(p.MainWindowTitle)).ToArray())
                Console.WriteLine($"{p.ProcessName} :: {p.Id} :: '{p.MainWindowTitle}' :: {p.MainWindowHandle}");

            var proc = procesos.SingleOrDefault(p => p.MainWindowTitle.Contains("pwclassic.net"));

            if (proc == null)
                proc = procesos.SingleOrDefault(p => p.MainWindowTitle.Contains("Gayston"));


            var app = new ProcessManager(proc);
            app.SetWindowTitle("Gayston");

            var mem = app.GetMemoryManager();


            var block = new IntPtr(0x009B4A04);

            mem.OnMemoryChange(block, (b) => { mem.Write(block, (byte)1);  Console.WriteLine("set 1"); });

            /*
            Thread.Sleep(1000);
            app.KeyUp(System.Windows.Forms.Keys.Y);
            app.KeyUp(System.Windows.Forms.Keys.E);
            app.KeyUp(System.Windows.Forms.Keys.R);
            app.KeyUp(System.Windows.Forms.Keys.B);
            app.KeyUp(System.Windows.Forms.Keys.A);
            Thread.Sleep(1000);
            app.KeyDown(System.Windows.Forms.Keys.Tab);
            app.KeyUp(System.Windows.Forms.Keys.X);
            app.KeyUp(System.Windows.Forms.Keys.Z);
            app.KeyUp(System.Windows.Forms.Keys.Y);
            app.KeyUp(System.Windows.Forms.Keys.D2);
            app.KeyUp(System.Windows.Forms.Keys.D9);
            app.KeyUp(System.Windows.Forms.Keys.D5);
            app.KeyUp(System.Windows.Forms.Keys.D4);
            app.KeyUp(System.Windows.Forms.Keys.A);
            Thread.Sleep(1000);
            app.KeyPress(System.Windows.Forms.Keys.Enter);
            Thread.Sleep(3500);
            app.KeyPress(System.Windows.Forms.Keys.Enter);
            */

            IntPtr h = IntPtr.Zero;
            var hora = DateTime.Now;
            while (true)
            {
                app.KeyDown(System.Windows.Forms.Keys.F1);
                Thread.Sleep(100);
                app.KeyDown(System.Windows.Forms.Keys.F2);
                Thread.Sleep(100);

                if (hora.AddSeconds(30) < DateTime.Now )
                {
                    hora = DateTime.Now;
                    app.KeyDown(System.Windows.Forms.Keys.Tab);
                    Thread.Sleep(100);
                }

                /*
                var status = mem.ReadByte(new IntPtr(0x009B4A04));
                if (status == 0)
                {
                    Console.WriteLine("0");
                    mem.Write(block, (byte)1);
                    Console.WriteLine("1");
                }
                */
            }
        }

    }
}
