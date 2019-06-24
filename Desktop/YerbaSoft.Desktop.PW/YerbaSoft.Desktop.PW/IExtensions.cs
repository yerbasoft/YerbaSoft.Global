using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YerbaSoft.Desktop.PW
{
    public static class IExtensions
    {
        public static Rectangle MoveDown(this Rectangle obj, int value)
        {
            return new Rectangle(obj.X, obj.Y + value, obj.Width, obj.Height);
        }
        public static Rectangle MoveRigth(this Rectangle obj, int value)
        {
            return new Rectangle(obj.X + value, obj.Y, obj.Width, obj.Height);
        }
        public static Rectangle SetSize(this Rectangle obj, int w, int h)
        {
            return new Rectangle(obj.X, obj.Y, w, h);
        }
        public static Rectangle SetPos(this Rectangle obj, int x, int y)
        {
            return new Rectangle(x, y, obj.Width, obj.Height);
        }
        public static Rectangle SetOffset(this Rectangle obj, int x, int y)
        {
            return new Rectangle(obj.X + x, obj.Y + y, obj.Width, obj.Height);
        }
        public static Rectangle SetHeight(this Rectangle obj, int h)
        {
            obj.Height = h;
            return obj;
        }

        public static Keys GetKey(this string value)
        {
            if (Enum.TryParse<Keys>(value, out Keys key))
                return key;
            else
                return default(Keys);
        }
    }
}