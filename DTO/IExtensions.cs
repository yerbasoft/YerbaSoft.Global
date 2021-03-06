﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace YerbaSoft.DTO
{
    public static class IExtensions
    {
        #region Xml Extensions

        public static XmlNode SubNode(this XmlNode node)
        {
            return node.SubNodes().SingleOrDefault();
        }
        public static XmlNode SubNode(this XmlNode node, string name)
        {
            return node.SubNodes(name).SingleOrDefault();
        }
        public static XmlNode SubNode(this XmlNode node, string name, KeyValuePair<string, string> attr)
        {
            return node.SubNodes(name, attr).SingleOrDefault();
        }
        public static XmlNode SubNode(this XmlNode node, string name, IEnumerable<KeyValuePair<string, string>> attrs)
        {
            return node.SubNodes(name, attrs).SingleOrDefault();
        }

        public static IEnumerable<XmlNode> SubNodes(this XmlNode node)
        {
            return node.SubNodes(null, null);
        }
        public static IEnumerable<XmlNode> SubNodes(this XmlNode node, string name)
        {
            return node.SubNodes(name, null);
        }
        public static IEnumerable<XmlNode> SubNodes(this XmlNode node, string name, KeyValuePair<string, string> attr)
        {
            return node.SubNodes(name, new KeyValuePair<string, string>[] { attr });
        }
        public static IEnumerable<XmlNode> SubNodes(this XmlNode node, string name, IEnumerable<KeyValuePair<string, string>> attrs)
        {
            var result = node.ChildNodes.OfType<XmlNode>().Where(p => !(p.GetType().IsAssignableFrom(typeof(XmlComment))));

            if (!string.IsNullOrEmpty(name))
                result = result.Where(n => n.Name == name);

            if (attrs != null)
                foreach (var attr in attrs)
                    result = result.Where(n => n.Attr(attr.Key) == attr.Value);

            return result;

            //var xpath = string.Join(" | ", attrs.Select(attr => $"//{name ?? node.Name}[@{attr.Key}='{attr.Value}']"));   // no funciona porque no es un xpath relativo
            //return node.SelectNodes(xpath).OfType<XmlNode>();
        }

        public static object Cast(this XmlNode node, Type type)
        {
            var o = type.GetConstructor(new Type[] { }).Invoke(new object[] { });

            foreach (var p in type.GetProperties().Where(p => p.CanRead && p.CanWrite))
            {
                // Busco Propiedades en Atributos
                var a = node.Attr(p.Name);
                if (!string.IsNullOrEmpty(a))
                {
                    var value = YerbaSoft.DTO.Convert.To(p.PropertyType, a);
                    p.SetValue(o, value);
                }

                // Busco propiedades en SubNodos
                var n = node.SubNodes(p.Name).SingleOrDefault();
                if (n != null)
                {
                    object value = null;
                    int i = 0;

                    if (p.PropertyType.GenericTypeArguments.Count() > 0 && (p.PropertyType.IsGenericList() || p.PropertyType.IsGenericCollection()))
                    {
                        value = (dynamic)Activator.CreateInstance(p.PropertyType);

                        foreach (var item in n.SubNodes())
                        {
                            var obj = (dynamic)item.Cast(p.PropertyType.GenericTypeArguments[0]);

                            if (p.PropertyType.IsGenericList())
                                ((dynamic)value).Insert(i++, obj);
                            else if (p.PropertyType.IsGenericCollection())
                                ((dynamic)value).Add(obj);
                        }
                    }
                    else
                    {
                        try
                        {
                            value = YerbaSoft.DTO.Convert.To(p.PropertyType, YerbaSoft.DTO.Convert.NullIf(string.IsNullOrEmpty(n.InnerText), n.InnerText));
                        }
                        catch (FormatException)
                        {
                            value = n.Cast(p.PropertyType);
                        }
                    }

                    p.SetValue(o, value);
                }
            }

            return o;
        }

        public static T Cast<T>(this XmlNode node) where T : new()
        {
            return (T)node.Cast(typeof(T));
        }

        public static IEnumerable<XmlAttribute> Attrs(this XmlNode node)
        {
            return node.Attributes.OfType<XmlAttribute>();
        }

        public static string Attr(this XmlNode node, string name)
        {
            try
            {
                var attr = node.Attrs().SingleOrDefault(p => p.Name.ToLower() == name.ToLower());
                if (attr != null)
                    return attr.Value;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static T Attr<T>(this XmlNode node, string name)
        {
            var attr = node.Attrs().SingleOrDefault(p => p.Name.ToLower() == name.ToLower());
            if (attr != null)
                return Convert.To<T>(attr.Value);

            return default(T);
        }

        public static XmlNode SetProperties(this XmlNode node, object obj)
        {
            var oProps = obj.GetType().GetProperties().Where(p => p.CanRead);
            foreach (var p in oProps)
            {
                var a = node.Attrs().SingleOrDefault(x => x.Name == p.Name);
                if (a == null)
                {
                    if (p.GetValue(obj) != null)
                    {
                        a = node.OwnerDocument.CreateAttribute(p.Name);
                        a.Value = p.GetValue(obj).ToString();
                        node.Attributes.Append(a);
                    }
                }
                else
                {
                    if (p.GetValue(obj) != null)
                    {
                        a.Value = p.GetValue(obj).ToString();
                    }
                    else
                    {
                        node.Attributes.Remove(a);
                    }
                }
            }

            return node;
        }

        #endregion

        #region Array Extensions

        public static List<T> Random<T>(this List<T> a)
        {
            var ori = a.ToList();
            var res = new List<T>();

            Random rnd = new Random();
            while (ori.Count > 0)
            {
                int i = rnd.Next(0, ori.Count - 1);
                res.Add(ori[i]);
                ori.RemoveAt(i);
            }

            return res;
        }

        public static List<T> Shuffle<T>(this List<T> input)
        {
            List<T> arr = input.Select(p => p).ToList();
            List<T> arrDes = new List<T>();

            Random randNum = new Random();
            while (arr.Count > 0)
            {
                int val = randNum.Next(0, arr.Count - 1);
                arrDes.Add(arr[val]);
                arr.RemoveAt(val);
            }

            return arrDes;
        }

        /// <summary>
        /// Devuelve un item aleatorio de un array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T GetRandomValue<T>(this IEnumerable<T> input)
        {
            var rnd = new Random();
            var index = rnd.Next(0, input.Count() - 1);

            return input.Select((p, i) => new { value = p, i = i }).Single(p => p.i == index).value;
        }

        /// <summary>
        /// Devuelve el índice del primer elemento encontrado según el filtro establecido
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this IEnumerable<T> input, Func<T, bool> filter)
        {
            var founded = input.Select((p, i) => new { obj = p, i }).Where(p => filter.Invoke(p.obj)).FirstOrDefault();

            return (founded == null) ? -1 : founded.i;
        }

        #endregion

        #region enums Extensions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetDescripcion(this Enum source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0) return attributes[0].Description; else return source.ToString();
        }
        #endregion

        #region Exceptions
        /// <summary>
        /// Devuelve la descripción completa de un Exception
        /// </summary>
        /// <param name="ex">excepción</param>
        /// <returns>texto completo del error</returns>
        public static string GetFullDescription(this Exception ex)
        {
            var sb = new StringBuilder();

            // Inner Exception
            var _ex = ex;
            var tab = "";
            while (_ex != null)
            {
                if (_ex != ex)
                    sb.AppendLine($"\n{tab}- Inner Exception -");
                sb.AppendLine($"{tab}Type:    {_ex.GetType().FullName}");
                sb.AppendLine($"{tab}Message: {_ex.Message}");
                sb.AppendLine($"{tab}Source:  {_ex.Source}");
                sb.AppendLine($"{tab}Target:  {_ex.TargetSite?.ToString()}");
                sb.AppendLine($"{tab}Trace:   {_ex.StackTrace?.Replace("\n", $"\n{tab}")}");
                /*
                if (_ex is OracleException)
                {
                    if ((_ex as OracleException).Errors != null)
                    {
                        foreach (var err in (_ex as OracleException).Errors.OfType<OracleError>())
                        {
                            sb.AppendLine($"\n{tab}\t- Oracle Exception Inner Error -");
                            sb.AppendLine($"{tab}\tMessage: {err.Message}");
                            sb.AppendLine($"{tab}\tNumber: {err.Number}");
                            sb.AppendLine($"{tab}\tArrayBindIndex: {err.ArrayBindIndex}");
                            sb.AppendLine($"{tab}\tDataSource: {err.DataSource}");
                            sb.AppendLine($"{tab}\tProcedure: {err.Procedure}");
                            sb.AppendLine($"{tab}\tSource: {err.Source}");
                        }
                    }
                }
                */
                if (_ex is AggregateException)
                {
                    ((AggregateException)_ex).Handle((iex) =>
                    {
                        sb.AppendLine($"\n{tab}\t- Aggregate Inner Exception -");
                        sb.AppendLine($"{tab}\tType:    {iex.GetType().FullName}");
                        sb.AppendLine($"{tab}\tMessage: {iex.Message}");
                        sb.AppendLine($"{tab}\tSource:  {iex.Source}");
                        sb.AppendLine($"{tab}\tTarget:  {iex.TargetSite?.ToString()}");
                        sb.AppendLine($"{tab}\tTrace:   {iex.StackTrace?.Replace("\n", $"\n{tab}")}");
                        return true;
                    });
                }

                tab += "\t";
                _ex = _ex.InnerException;
            }

            return sb.ToString();
        }
        #endregion


        #region PropertyInfo (internal)
        internal static bool UseComplexConvert(this PropertyInfo prop)
        {
            var direct = prop.CustomAttributes.Where(p => (typeof(YerbaSoft.DTO.Mapping.Direct)).IsAssignableFrom(p.AttributeType)).SingleOrDefault();
            if (direct != null)
            {
                var complex = direct.NamedArguments.Where(p => p.MemberName == "UseComplexConvert").SingleOrDefault();
                if (complex != null && complex.TypedValue.Value != null)
                    return (bool)complex.TypedValue.Value;
            }
            return false;
        }
        #endregion

        #region Type
        /// <summary>
        /// Indica si el tipo es un IList<>
        /// </summary>
        public static bool IsGenericList(this Type type)
        {
            if (type.GenericTypeArguments != null && type.GenericTypeArguments.Count() > 0)
            {
                var tList = typeof(IList<>).MakeGenericType(type.GenericTypeArguments);
                return tList.IsAssignableFrom(type);
            }
            return false;
        }

        /// <summary>
        /// Indica si el tipo es un ICollection<>
        /// </summary>
        public static bool IsGenericCollection(this Type type)
        {
            if (type.GenericTypeArguments != null && type.GenericTypeArguments.Count() > 0)
            {
                var tList = typeof(ICollection<>).MakeGenericType(type.GenericTypeArguments);
                return tList.IsAssignableFrom(type);
            }
            return false;
        }
        #endregion
    }
}
