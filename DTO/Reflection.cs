using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.DTO
{
    public class Reflection
    {
        /// <summary>
        /// Obtiene una propiedad estática de una clase y devuelve el valor con un tipo especificado
        /// </summary>
        /// <param name="from">typo de origen de la propiedad</param>
        /// <param name="resultType">tipo de resultado</param>
        /// <param name="propertyName">nombre de la propiedad a acceder</param>
        /// <returns></returns>
        public static object GetStaticProperty(Type from, Type resultType, string propertyName)
        {
            var prop = from.GetProperty(propertyName);
            var value = prop.GetValue(null);
            return Convert.To(resultType, value);
        }

        public static object GetStaticProperty(Type from, string propertyName)
        {
            var prop = from.GetProperty(propertyName);
            var value = prop.GetValue(null);
            return value;
        }

        public static R GetStaticProperty<T, R>(string propertyName)
        {
            var t = typeof(T);
            var prop = t.GetProperty(propertyName);
            return Convert.To<R>(prop.GetValue(null));
        }
    }
}
