using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWork
{
    public static class IExtensions
    {
        public static ToolStripMenuItem Do(this ToolStripMenuItem menu, Action<ToolStripMenuItem> action)
        {
            action.Invoke(menu);
            return menu;
        }

        public static IEnumerable<ToolStripMenuItem> SubMenus(this ToolStripMenuItem menu, Func<ToolStripMenuItem, bool> where = null)
        {
            var result = menu.DropDownItems.OfType<ToolStripMenuItem>();

            if (where != null)
                result = result.Where(where);

            return result;
        }
        public static IEnumerable<ToolStripMenuItem> SubMenus(this ToolStripDropDownItem menu, Func<ToolStripMenuItem, bool> where = null)
        {
            var result = menu.DropDownItems.OfType<ToolStripMenuItem>();

            if (where != null)
                result = result.Where(where);

            return result;
        }
        
        public static void RemoveMenus(this ToolStripMenuItem menu, Func<ToolStripMenuItem, bool> filter = null)
        {
            var items = menu.DropDownItems.OfType<ToolStripMenuItem>();
            if (filter != null)
                items = items.Where(filter);

            foreach (var m in items.ToArray())
                menu.DropDownItems.Remove(m);
        }
        public static void RemoveMenus(this ToolStripDropDownItem menu, Func<ToolStripMenuItem, bool> filter = null)
        {
            var items = menu.DropDownItems.OfType<ToolStripMenuItem>();
            if (filter != null)
                items = items.Where(filter);

            foreach (var m in items.ToArray())
                menu.DropDownItems.Remove(m);
        }

        public static T GetTag<T>(this object control)
        {
            if (control == null)
                return default;

            //return (T)((dynamic)sender).Tag;

            return (T)control.GetType().GetProperty("Tag").GetValue(control);            
        }

        public static Bitmap ZoomForControl(this Bitmap obj, Control control)
        {
            var side = Math.Min(control.Height, control.Width);
            return new Bitmap(obj, new Size(side - 10, side - 10));
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public ComboBoxItem() { }
        public ComboBoxItem(string text, object value)
        {
            this.Text = text;
            this.Value = value;
        }

        public T Get<T>()
        {
            return (T)Value;
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
