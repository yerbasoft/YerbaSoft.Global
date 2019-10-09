using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIR.Common
{
    public static class Reflection
    {
        /// <summary>
        /// Indica si un Type es Nulleable
        /// </summary>
        /// <typeparam name="T">Tipo a verificar</typeparam>
        public static bool IsNulleable<T>() => IsNulleable(typeof(T));
        /// <summary>
        /// Indica si un Type es Nulleable
        /// </summary>
        /// <param name="type">tipo a verificar</param>
        public static bool IsNulleable(Type type) => Nullable.GetUnderlyingType(type) != null;

        /// <summary>
        /// Convierte un valor object a un tipo especificado utilizando la clase System.Convert de forma generica
        /// </summary>
        /// <typeparam name="T">Tipo a retornar</typeparam>
        /// <param name="value">valor a convertir</param>
        public static T ConvertTo<T>(object value)
        {
            return ConvertTo<T>(value, null);
        }
        /// <summary>
        /// Convierte un valor object a un tipo especificado utilizando la clase System.Convert de forma generica
        /// </summary>
        /// <param name="value">valor a convertir</param>
        /// <param name="returnType">tipo a retornar</param>
        public static object ConvertTo(object value, Type returnType)
        {
            return ConvertTo(value, returnType, null);
        }
        /// <summary>
        /// Convierte un valor object a un tipo especificado utilizando la clase System.Convert de forma generica
        /// </summary>
        /// <typeparam name="T">Tipo a retornar</typeparam>
        /// <param name="value">valor a convertir</param>
        /// <param name="datetimeformat">formato a utilizar en caso de que T sea de tipo DateTime</param>
        /// <returns></returns>
        public static T ConvertTo<T>(object value, string datetimeformat)
        {
            return (T)ConvertTo(value, typeof(T), datetimeformat);
        }
        /// <summary>
        /// Convierte un valor object a un tipo especificado utilizando la clase System.Convert de forma generica
        /// </summary>
        /// <typeparam name="T">Tipo a retornar</typeparam>
        /// <param name="value">valor a convertir</param>
        /// <param name="returnType">tipo a retornar</param>
        /// <param name="datetimeformat">formato a utilizar en caso de que T sea de tipo DateTime</param>
        /// <returns></returns>
        public static object ConvertTo(object value, Type returnType, string datetimeformat)
        {
            if (value == null)
            {
                if (IsNulleable(returnType))
                    return default;
                else
                    throw new FormatException($"El tipo {returnType.FullName} no admite valores nulos.");
            }

            var valueType = value.GetType();

            if (returnType.IsAssignableFrom(valueType))
            {
                return value;   // es cast directo
            }

            if (returnType.IsAssignableFrom(typeof(DateTime)) && !string.IsNullOrEmpty(datetimeformat))
            {
                // DateTime :: trato especial por el formato
                DateTime aux;
                if (DateTime.TryParseExact(value.ToString(), datetimeformat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out aux))
                {
                    return aux;
                }
                else
                {
                    throw new FormatException($"El valor '{value}' no se puede convertir a DateTime utilizando el formato '{datetimeformat}'.");
                }
            }

            var methods = typeof(System.Convert).GetMethods().Where(p => returnType.IsAssignableFrom(p.ReturnType)).Select(p => new { m = p, ps = p.GetParameters() });

            // Con IFormatProvider
            var method = methods.FirstOrDefault(p => p.ps.Length == 2 && p.ps[0].ParameterType.IsAssignableFrom(valueType) && p.ps[1].ParameterType == typeof(IFormatProvider));
            if (method != null)
            {
                try
                {
                    return method.m.Invoke(null, new object[] { value, System.Globalization.CultureInfo.InvariantCulture });
                }
                catch (Exception ex)
                {
                    throw new FormatException($"Error al intentar convertir el valor '{value}' a '{returnType.FullName}'.", ex);
                }
            }
            else
            {
                // Sin IFormatProvider
                method = methods.SingleOrDefault(p => p.ps.Length == 1 && p.ps[0].ParameterType.IsAssignableFrom(valueType));
                if (method != null)
                {
                    try
                    {
                        return method.m.Invoke(null, new object[] { value });
                    }
                    catch (Exception ex)
                    {
                        throw new FormatException($"Error al intentar convertir el valor '{value}' a '{returnType.FullName}'.", ex);
                    }
                }
                else
                {
                    throw new FormatException($"No se encontró una función en System.Convert para obtener el tipo de dato '{returnType}'.");
                }
            }
        }

        /// <summary>
        /// Crea una nueva instancia de un objeto y copia los valores de las propiedades
        /// </summary>
        /// <typeparam name="T">Tipo del objeto a clonar</typeparam>
        /// <param name="origen">objeto origen de la clonación</param>
        /// <returns></returns>
        public static T CloneObject<T>(T origen) where T : new()
        {
            if (origen == default)
                return default;

            var obj = new T();

            CopyPropertiesTo(origen, obj);

            return obj;
        }

        /// <summary>
        /// Copia los valores de las propiedades de un objeto a otro cuando las propiedades tienen el mismo nombre
        /// </summary>
        /// <typeparam name="T">Tipo del objeto a copiar</typeparam>
        /// <param name="origen">objeto origen de datos</param>
        /// <param name="destino">objeto destino a editar</param>
        public static void CopyPropertiesTo<T>(T origen, T destino) where T : new()
        {
            CopyPropertiesTo(origen, destino);
        }
        /// <summary>
        /// Copia los valores de las propiedades de un objeto a otro cuando las propiedades tienen el mismo nombre
        /// </summary>
        /// <param name="origen">objeto origen de datos</param>
        /// <param name="destino">objeto destino a editar</param>
        public static void CopyPropertiesTo(object origen, object destino)
        {
            if (origen == null)
                throw new ArgumentNullException("origen", "Objeto de origen de copia no puede ser null.");
            if (destino == null)
                throw new ArgumentNullException("destino", "Objeto de destino de copia no puede ser null.");

            var tOri = origen.GetType();
            var tDes = destino.GetType();

            var pOri = tOri.GetProperties().Where(p => p.CanRead);
            var pDes = tDes.GetProperties().Where(p => p.CanWrite);

            //mapea las propiedades que coinciden en el nombre
            foreach (var po in pOri)
            {
                var pd = pDes.Where(p => p.Name.ToUpper() == po.Name.ToUpper()).SingleOrDefault();
                if (pd != null)
                {
                    var value = po.GetValue(origen);
                    pd.SetValue(destino, value);
                }
            }
        }

        /// <summary>
        /// Devuelve la información de las propiedades que cumplen con un atributo custom
        /// </summary>
        /// <typeparam name="Obj">tipo del objeto con propiedades</typeparam>
        /// <typeparam name="Attr">tipo del attributo custom</typeparam>
        /// <returns></returns>
        public static DTO.PropAttribute<Attr>[] GetPropertiesWithAttribute<Obj, Attr>() where Attr : Attribute
        {
            return (from ps in typeof(Obj).GetProperties()    //Busco atributos en la clase de destino de copia
                    from at in ps.CustomAttributes
                    where typeof(Attr).IsAssignableFrom(at.AttributeType)
                    select new DTO.PropAttribute<Attr>
                    {
                        Prop = ps,
                        Type = ps.PropertyType,
                        Attr = (Attr)at.BuildAttribute()
                    }).ToArray();
        }
    }
}
