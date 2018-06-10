using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.DAL
{
    public static class IQueryableExtensions
    {
        /*
                public static IQueryable<T> OrderBy<T>(this IQueryable<T> items, string propertyName, bool isAscending)
                {
                    var typeOfT = typeof(T);
                    var parameter = Expression.Parameter(typeOfT, "parameter");
                    var propertyType = typeOfT.GetProperty(propertyName).PropertyType;
                    var propertyAccess = Expression.PropertyOrField(parameter, propertyName);
                    var orderExpression = Expression.Lambda(propertyAccess, parameter);
                    var orderMethod = isAscending ? "OrderBy" : "OrderByDescending";
                    var expression = Expression.Call(typeof(Queryable), orderMethod, new Type[] { typeOfT, propertyType }, items.Expression, Expression.Quote(orderExpression));
                    return items.Provider.CreateQuery<T>(expression);
                }
        */

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
                throw new NoNullAllowedException("sortString");
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
    }
}
