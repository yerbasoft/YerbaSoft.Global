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

        internal void Ver(object sender, EventArgs e)
        {
        }

        internal void OpenConfig(object sender, EventArgs e)
        {
            new Forms.Config().Show();
        }
    }
}
