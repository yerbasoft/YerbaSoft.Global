using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SIR.Common
{
    public static class IExtensions
    {
        #region Exceptions

        public static string GetFullDescription(this Exception ex, string tab = "")
        {
            var sb = new StringBuilder();

            var _ex = ex;
            tab = (tab ?? "") + "";
            while (_ex != null)
            {
                if (_ex is AggregateException)
                {
                    sb.AppendLine($"{tab}\t- Aggregate Exception -");
                    sb.AppendLine($"{tab}\tType:    {_ex.GetType().FullName}");
                    sb.AppendLine($"{tab}\tMessage: {_ex.Message}");
                    sb.AppendLine($"{tab}\tSource:  {_ex.Source}");
                    sb.AppendLine($"{tab}\tTarget:  {_ex.TargetSite?.ToString()}");
                    sb.AppendLine($"{tab}\tTrace:   {_ex.StackTrace}");

                    foreach (var iex in ((AggregateException)_ex).InnerExceptions)
                    {
                        sb.AppendLine($"{tab}\t\t- Aggregate Inner Exception -");
                        sb.Append(GetFullDescription(iex, $"{tab}\t"));
                    }

                    _ex = null; // el bucle por Agregate ya se está haciendo
                }
                else
                {
                    if (_ex != ex)
                        sb.AppendLine($"{tab}\t- Inner Exception -");
                    sb.AppendLine($"{tab}\tType:    {_ex.GetType().FullName}");
                    sb.AppendLine($"{tab}\tMessage: {_ex.Message}");
                    sb.AppendLine($"{tab}\tSource:  {_ex.Source}");
                    sb.AppendLine($"{tab}\tTarget:  {_ex.TargetSite?.ToString()}");
                    sb.AppendLine($"{tab}\tTrace:   {_ex.StackTrace}");

                    tab += "\t";
                    _ex = _ex.InnerException;
                }
            }

            return sb.ToString();
        }

        #endregion

        #region Guid

        public static string ToRaw(this Guid value)
        {
            return BitConverter.ToString(value.ToByteArray()).Replace("-", "");
        }

        #endregion

        #region Expression

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
        
        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> query, string propertyName, bool isAscending = true)
        {
            var sortExpression = BuildSearchExpression<T>(propertyName);

            return isAscending
                ? query.OrderBy(sortExpression)
                : query.OrderByDescending(sortExpression);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> query, string propertyName, bool isAscending = true)
        {
            var sortExpression = BuildSearchExpression<T>(propertyName);

            return isAscending
                ? query.ThenBy(sortExpression)
                : query.ThenByDescending(sortExpression);
        }

        public static Expression<Func<T, object>> BuildSearchExpression<T>(string propertyName)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName");
            }

            /* Se puede pasar Propiedad.Propiedad.Propiedad... */
            var arg = Expression.Parameter(typeof(T), "p");
            Expression propertyAccess = arg;
            var type = typeof(T);
            PropertyInfo property = null;

            foreach (var prop in propertyName.Split('.'))
            {
                property = type.GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (property == null)
                {
                    throw new IndexOutOfRangeException("No se encontró la propiedad " + prop);
                }

                propertyAccess = Expression.PropertyOrField(propertyAccess, property.Name);

                type = property.PropertyType;
            }

            if (property == null)
            {
                return null;
            }

            if (!property.PropertyType.IsValueType)
            {
                return Expression.Lambda<Func<T, object>>(propertyAccess, arg);
            }

            Expression conversion = Expression.Convert(propertyAccess, typeof(object));
            return Expression.Lambda<Func<T, object>>(conversion, arg);
        }

        public static IQueryable<T> SortBySQLExpression<T>(this IQueryable<T> query, string sortString)
        {
            if (sortString == null)
            {
                throw new ArgumentNullException("sortString");
            }

            var sorts = sortString.Split(',');

            if (sorts.Length == 0 ||
                String.IsNullOrWhiteSpace(sorts[0]))
            {
                throw new System.Data.NoNullAllowedException("sortString");
            }

            string col = sorts[0],
                   sortCol = col;

            if (col.ToLower()
                   .EndsWith(" desc"))
            {
                sortCol = col.Substring(0, col.Length - 5);
                query = query.SortBy(sortCol.Trim(), false);
            }
            else
            {
                if (col.ToLower()
                       .EndsWith(" asc"))
                {
                    sortCol = col.Substring(0, col.Length - 4);
                }
                query = query.SortBy(sortCol.Trim());
            }

            for (var i = 1; i < sorts.Length; i++)
            {
                col = sorts[i];

                if (col.ToLower()
                       .EndsWith(" desc"))
                {
                    sortCol = col.Substring(0, col.Length - 5);
                    query = query.SortBy(sortCol.Trim(), false);
                }
                else
                {
                    if (col.ToLower()
                           .EndsWith(" asc"))
                    {
                        sortCol = col.Substring(0, col.Length - 4);
                    }
                    query = query.SortBy(sortCol.Trim());
                }
            }

            return query;
        }

        #endregion

        public static Attribute BuildAttribute(this CustomAttributeData cad)
        {
            var obj = (Attribute)cad.Constructor.Invoke(cad.ConstructorArguments.Select(x => x.Value).ToArray());

            foreach (var ap in cad.NamedArguments)
            {
                obj.GetType().GetProperty(ap.MemberName).SetValue(obj, ap.TypedValue.Value);
            }

            return obj;
        }
    }
}
