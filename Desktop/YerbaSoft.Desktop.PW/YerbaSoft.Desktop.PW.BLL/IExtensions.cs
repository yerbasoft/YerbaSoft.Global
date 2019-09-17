using System;
using System.Drawing;
using System.Windows.Forms;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;

namespace YerbaSoft.Desktop.PW.BLL
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

        public static Point3D GetOffset(this Point3D obj, float x, float y, float z)
        {
            return new Point3D() { X = obj.X + x, Y = obj.Y + y, Z = obj.Z + z };
        }

        public static bool InRange(this Point3D obj, Point3D oRef, float radius)
        {
            return YerbaSoft.DTO.Math.Between(obj.X, oRef.X - radius, oRef.X + radius) &&
                    YerbaSoft.DTO.Math.Between(obj.Y, oRef.Y - radius, oRef.Y + radius) &&
                    YerbaSoft.DTO.Math.Between(obj.Z, oRef.Z - radius, oRef.Z + radius);
        }

        public static bool InRange2D(this Point3D obj, Point3D oRef, float radius)
        {
            return YerbaSoft.DTO.Math.Between(obj.X, oRef.X - radius, oRef.X + radius) &&
                    YerbaSoft.DTO.Math.Between(obj.Z, oRef.Z - radius, oRef.Z + radius);
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