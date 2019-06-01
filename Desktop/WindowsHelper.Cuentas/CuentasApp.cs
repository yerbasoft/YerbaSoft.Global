using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsHelper.Configuration;

namespace WindowsHelper.Cuentas
{
    public class CuentasApp : Interfaces.IApp
    {
        public const string DBPath = @"W:\YerbaSoft\Desktop\WindowsHelper.Cuentas";
        internal static System.Drawing.Icon DefaultIcon => Properties.Resources.cashier;
        public const string AppName = "Cuentas";

        private App AppConfig;
        private ToolStripMenuItem HeadMenu { get; set; }

        public void Inicializar(App app)
        {
            AppConfig = app;
            Global.OnCreateMenu += OnCreateMenu;
        }

        private IEnumerable<ToolStripItem> OnCreateMenu()
        {
            HeadMenu = new ToolStripMenuItem(AppConfig.Name, DefaultIcon.ToBitmap());

            var factory = new BLL.Service();

            HeadMenu.DropDownItems.AddRange(
                new ToolStripItem[] {
                    new ToolStripMenuItem("Agregar Movimiento", Properties.Resources.book_blue_add.ToBitmap(), factory.Add),
                    new ToolStripMenuItem("Movimientos", Properties.Resources.book_blue_view.ToBitmap(), factory.VerMovimientos),
                    new ToolStripSeparator(),
                    new ToolStripMenuItem("Ahorros", Properties.Resources.money.ToBitmap(), factory.Ahorros),
                    new ToolStripSeparator(),
                    new ToolStripMenuItem("Ver Mes (Excel)", Properties.Resources.book_open.ToBitmap(), factory.VerUltimoMesExcel),
                    new ToolStripMenuItem("Ver Ultimo Año (Excel)", Properties.Resources.book_open.ToBitmap(), factory.VerUltimoAnioExcel),
                    new ToolStripMenuItem("Ver Todas Cuentas (Excel)", Properties.Resources.book_open.ToBitmap(), factory.VerTodoExcel),
                    new ToolStripSeparator(),
                    new ToolStripMenuItem("Configuración", Properties.Resources.creditcards.ToBitmap(), factory.OpenConfig),
                }
            );

            return new ToolStripItem[] { HeadMenu };
        }
    }
}
