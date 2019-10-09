using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSWork.Interface.Forms;

namespace CSWork.Interface.Model.Configuration
{
    public abstract class ConfigBase
    {
        protected Forms.Configuration Form;
        protected Control Container;
        protected BLL.Managers.Config Config => BLL.Factory.Config;

        protected ConfigBase(Forms.Configuration form, Control container)
        {
            this.Form = form;
            this.Container = container;
        }

        protected T GetControl<T>(params string[] path) where T : Control
        {
            Control result = Container;

            foreach(var p in path)
            {
                result = result.Controls[p];
            }

            return (T)result;
        }

    }
}
