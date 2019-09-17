using System;
using System.Linq;

namespace YerbaSoft.DTO
{
    public class Math
    {
        /// <summary>
        /// Devuelve si un valor se encuentra dentro de una lista de valores
        /// </summary>
        /// <param name="value"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool In(object value, params object[] values)
        {
            return values.Contains(value);
        }

        /// <summary>
        /// repite una cadena una cantidad de veces específica
        /// </summary>
        /// <param name="value"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public static string Repeat(string value, int times)
        {
            var result = "";
            for (var i = 0; i < times; i++)
                result += value;
            return result;
        }

        #region Is Number

        /// <summary>
        /// Devuelve si un Type es numérico o no
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNumber(Type type)
        {
            return IsIntNumber(type) ||
                   In(type,
                    typeof(float), typeof(float?),
                    typeof(double), typeof(double?),
                    typeof(decimal), typeof(decimal?)
                   );
        }

        /// <summary>
        /// Indica si un valor es numérico
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumber(object value)
        {
            if (Convert.IsNull(value, null) == null)
                throw new FormatException("No se puede establecer si el valor es un número ya que es null");

            return IsNumber(value.GetType());
        }

        /// <summary>
        /// Devuelve si un Type es numérico y entero
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsIntNumber(Type type)
        {
            return In(type,
                typeof(byte), typeof(byte?),
                typeof(int), typeof(int?),
                typeof(short), typeof(short?),
                typeof(long), typeof(long?),
                typeof(sbyte), typeof(sbyte?),
                typeof(ushort), typeof(ushort?),
                typeof(uint), typeof(uint?),
                typeof(ulong), typeof(ulong?)
                );
        }

        /// <summary>
        /// Indica si un valor es numérico y entero
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsIntNumber(object value)
        {
            if (Convert.IsNull(value, null) == null)
                throw new FormatException("No se puede establecer si el valor es un número ya que es null");

            return IsIntNumber(value.GetType());
        }

        /// <summary>
        /// Devuelve si un Type es numérico y sin signo
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsUnSignedNumber(Type type)
        {
            return In(type,
                typeof(sbyte), typeof(sbyte?),
                typeof(ushort), typeof(ushort?),
                typeof(uint), typeof(uint?),
                typeof(ulong), typeof(ulong?)
                );
        }

        public static bool Between(float x, float v1, float v2)
        {
            return x >= v1 && x <= v2;
        }

        /// <summary>
        /// Indica si un valor es numérico y sin signo
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsUnSignedNumber(object value)
        {
            if (Convert.IsNull(value, null) == null)
                throw new FormatException("No se puede establecer si el valor es un número ya que es null");

            return IsUnSignedNumber(value.GetType());
        }

        #endregion
    }
}
