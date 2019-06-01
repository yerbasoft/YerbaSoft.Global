using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.Cuentas.BLL
{
    internal class Service
    {
        internal void Add(object sender, System.EventArgs e)
        {
            new Forms.Add().Show();
        }

        internal void Ahorros(object sender, EventArgs e)
        {
            new Forms.Ahorros().Show();
        }

        internal void VerTodoExcel(object sender, EventArgs e)
        {
            new ExcelHelper().BuildExcelAnual(new DateTime(2017, 6, 1));
        }

        internal void VerUltimoAnioExcel(object sender, EventArgs e)
        {
            new ExcelHelper().BuildExcelAnual(DateTime.Now.AddMonths(-11));
        }

        internal void VerUltimoMesExcel(object sender, EventArgs e)
        {
            new ExcelHelper().BuildExcelMensual(DateTime.Now);
        }

        internal void OpenConfig(object sender, EventArgs e)
        {
            new Forms.Config().Show();
        }

        internal void VerMovimientos(object sender, EventArgs e)
        {
            new Forms.Movimientos().Show();
        }
    }
}
