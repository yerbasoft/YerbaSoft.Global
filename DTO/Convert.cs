using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.DTO
{
    public class Convert
    {
        public static IFormatProvider DeafultFormatProvider = CultureInfo.InvariantCulture;

        private static Dictionary<string, string> _DateTimeExpressions;
        public static Dictionary<string, string> DateTimeExpressions
        {
            get 
            { 
                if (_DateTimeExpressions == null)
                {
                    _DateTimeExpressions = new Dictionary<string, string>();

                    _DateTimeExpressions.Add("yyyyMMdd", @"([0-9]){8}$");
                    _DateTimeExpressions.Add("yyyyMMdd hh:mm", @"([0-9]){8} ([0-9]){2}:([0-9]){2}$");
                    _DateTimeExpressions.Add("yyyyMMdd hh:mm:ss", @"([0-9]){8} ([0-9]){2}:([0-9]){2}:([0-9]){2}$");

                    _DateTimeExpressions.Add("dd/MM/yyyy", @"([0-9]){2}/([0-9]){2}/([0-9]){4}$");
                    _DateTimeExpressions.Add("d/MM/yyyy", @"([0-9]){1}/([0-9]){2}/([0-9]){4}$");
                    _DateTimeExpressions.Add("d/M/yyyy", @"([0-9]){1}/([0-9]){1}/([0-9]){4}$");
                    _DateTimeExpressions.Add("dd/M/yyyy", @"([0-9]){2}/([0-9]){1}/([0-9]){4}$");

                    _DateTimeExpressions.Add("dd/MM/yyyy HH:mm", @"([0-9]){2}/([0-9]){2}/([0-9]){4} ([0-9]){2}:([0-9]){2}$");
                    _DateTimeExpressions.Add("d/MM/yyyy HH:mm", @"([0-9]){1}/([0-9]){2}/([0-9]){4} ([0-9]){2}:([0-9]){2}$");
                    _DateTimeExpressions.Add("d/M/yyyy HH:mm", @"([0-9]){1}/([0-9]){1}/([0-9]){4} ([0-9]){2}:([0-9]){2}$");
                    _DateTimeExpressions.Add("dd/M/yyyy HH:mm", @"([0-9]){2}/([0-9]){1}/([0-9]){4} ([0-9]){2}:([0-9]){2}$");
                    _DateTimeExpressions.Add("dd/MM/yyyy HH:mm:ss", @"([0-9]){2}/([0-9]){2}/([0-9]){4} ([0-9]){2}:([0-9]){2}:([0-9]){2}$");
                    _DateTimeExpressions.Add("d/MM/yyyy HH:mm:ss", @"([0-9]){1}/([0-9]){2}/([0-9]){4} ([0-9]){2}:([0-9]){2}:([0-9]){2}$");
                    _DateTimeExpressions.Add("d/M/yyyy HH:mm:ss", @"([0-9]){1}/([0-9]){1}/([0-9]){4} ([0-9]){2}:([0-9]){2}:([0-9]){2}$");
                    _DateTimeExpressions.Add("dd/M/yyyy HH:mm:ss", @"([0-9]){2}/([0-9]){1}/([0-9]){4} ([0-9]){2}:([0-9]){2}:([0-9]){2}$");
                }
                return _DateTimeExpressions;
            }
            set { _DateTimeExpressions = value; }
        }

        /// <summary>
        /// Si el valor es null o DBNull devuelve el valorDefault, sino devuelve valor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static object IsNull(object value, object defaultValue)
        {
            return value == null || value == DBNull.Value ? defaultValue : value;
        }

        /// <summary>
        /// Si se cumple la condición devuelve null, caso contrario devuelve el valor
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object NullIf(bool condition, object value)
        {
            return condition ? null : value;
        }

        /// <summary>
        /// Si el valor es null o DBNull devuelve el valorDefault, sino devuelve valor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T IsNull<T>(T value, T defaultValue)
        {
            return value == null || (object)value == DBNull.Value ? defaultValue : value;
        }

        /// <summary>
        /// Fuerza la conversión si es posible a un tipo de datos específico
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T To<T>(object value)
        {
            return (T)To(typeof(T), value);
        }

        /// <summary>
        /// Fuerza la conversión si es posible a un tipo de datos específico
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object To(Type type, object value)
        {
            if ((value = IsNull(value, null)) == null)
                return null;

            var tValue = value.GetType();
            if (tValue == type)
                return value;


            if (Math.In(type, typeof(bool), typeof(bool?)))
            {
                if (Math.In(tValue, typeof(bool), typeof(bool?)))
                    return value;
                else if (tValue == typeof(string))
                    return Math.In((string)value, "Y", "y", "Yes", "yes", "YES", "S", "s", "si", "Si", "SI", "T", "t", "true", "True", "TRUE", "1");
                else if (Math.IsNumber(tValue))
                    return System.Convert.ToDouble(value) != 0; // si es número. 0:false 'no cero':true
                else
                    throw new InvalidCastException(string.Format("No se pudo convertir {0} en el tipo de datos System.Bool", value));
            }


            else if (Math.In(type, typeof(Guid), typeof(Guid?)))
            {
                if (Math.In(tValue, typeof(Guid), typeof(Guid?)))
                    return value;
                else if (tValue == typeof(byte[]))
                    return new Guid((byte[])value);
                else if (tValue == typeof(string))
                    return new Guid((string)value);
                else
                    throw new InvalidCastException(string.Format("No se pudo convertir {0} en el tipo de datos System.Guid", value));
            }

            else if (Math.In(type, typeof(string)))
                return value.ToString();

            else if (Math.In(type, typeof(char), typeof(char?)))
            {
                if (Math.In(tValue, typeof(char), typeof(char?)))
                    return value;
                else if (tValue == typeof(string))
                    if (value.ToString().Length == 1)
                        return value.ToString()[0];
                    else
                        throw new InvalidCastException(string.Format("No se pudo convertir '{0}' en el tipo de datos System.Char", value));
                else
                    throw new InvalidCastException(string.Format("No se pudo convertir {0} en el tipo de datos System.Guid", value));
            }
            

            else if (Math.In(type, typeof(byte), typeof(byte?)))
                return System.Convert.ToByte(value, DeafultFormatProvider);
            else if (Math.In(type, typeof(sbyte), typeof(sbyte?)))
                return System.Convert.ToSByte(value, DeafultFormatProvider);
            else if (Math.In(type, typeof(short), typeof(short?)))
                return System.Convert.ToInt16(value, DeafultFormatProvider);
            else if (Math.In(type, typeof(int), typeof(int?)))
                return System.Convert.ToInt32(value, DeafultFormatProvider);
            else if (Math.In(type, typeof(long), typeof(long?)))
                return System.Convert.ToInt64(value, DeafultFormatProvider);

            else if (Math.In(type, typeof(float), typeof(float?)))
                return System.Convert.ToSingle(value, DeafultFormatProvider);
            else if (Math.In(type, typeof(double), typeof(double?)))
                return System.Convert.ToDouble(value, DeafultFormatProvider);
            else if (Math.In(type, typeof(decimal), typeof(decimal?)))
                return System.Convert.ToDouble(value, DeafultFormatProvider);
                
            else if (Math.In(type, typeof(ushort), typeof(ushort?)))
                return System.Convert.ToUInt16(value, DeafultFormatProvider);
            else if (Math.In(type, typeof(uint), typeof(uint?)))
                return System.Convert.ToUInt32(value, DeafultFormatProvider);
            else if (Math.In(type, typeof(ulong), typeof(ulong?)))
                return System.Convert.ToUInt64(value, DeafultFormatProvider);

            else if (Math.In(type, typeof(DateTime), typeof(DateTime?)))
            {
                if (Math.In(tValue, typeof(DateTime), typeof(DateTime?)))
                    return value;
                else if (Math.IsNumber(tValue))
                    return new DateTime(System.Convert.ToInt64(value));
                else if (Math.In(tValue, typeof(string)))
                {
                    foreach(var exp in DateTimeExpressions)
                    {
                        if (new System.Text.RegularExpressions.Regex(exp.Value).IsMatch(value.ToString()))
                            return DateTime.ParseExact(value.ToString(), exp.Key, DeafultFormatProvider);
                    }
                    throw new InvalidCastException(string.Format("No se pudo convertir {0} en el tipo de datos System.DateTime", value));
                }
                else
                    throw new InvalidCastException(string.Format("No se pudo convertir {0} en el tipo de datos System.DateTime", value));
            }

            else if (type.IsEnum)
                return Enum.Parse(type, (value ?? "").ToString());
 
            else
                throw new FormatException("No se reconoce el formato de salida");
        }
    }
}
