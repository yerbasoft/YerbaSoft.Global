using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;

namespace YerbaSoft.DTO.Mapping
{
    public abstract class AttributeClass : Attribute
    {
        /// <summary>
        /// Indica si existe una propiedad en un objeto
        /// </summary>
        protected bool ExistsProperty(object obj, string propertyName, Config.AutoMappingConfig config)
        {
            if (obj == null)
                return false;

            var tObj = obj.GetType();
            if (typeof(XmlNode).IsAssignableFrom(tObj))
            {
                return ((XmlNode)obj).Attributes.OfType<XmlAttribute>().Any(p => p.Name == propertyName);
            }
            else if (typeof(Dictionary<string, object>).IsAssignableFrom(tObj))
            {
                return ((Dictionary<string, object>)obj).Keys.Any(p => p == propertyName);
            }
            else if (typeof(DataRow).IsAssignableFrom(tObj))
            {
                if (((DataRow)obj).Table == null || ((DataRow)obj).Table.Columns == null)
                    return false;

                return ((DataRow)obj).Table.Columns.OfType<DataColumn>().Any(p => p.ColumnName == propertyName);
            }
            else
            {
                return tObj.GetProperties().Any(p => p.Name == propertyName);
            }
        }

        /// <summary>
        /// devuelve el valor de una propiedad
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        protected object GetPropertyValue(object obj, string propertyName, Config.AutoMappingConfig config)
        {
            if (obj == null)
                return false;

            var tObj = obj.GetType();
            if (typeof(XmlNode).IsAssignableFrom(tObj))
            {
                var v = ((XmlNode)obj).Attributes.OfType<XmlAttribute>().SingleOrDefault(p => p.Name == propertyName);
                return v == null ? null : v.Value;
            }
            else if (typeof(Dictionary<string, object>).IsAssignableFrom(tObj))
            {
                var v = ((Dictionary<string, object>)obj).Keys.SingleOrDefault(p => p == propertyName);
                return v == null ? null : ((Dictionary<string, object>)obj)[v];
            }
            else if (typeof(DataRow).IsAssignableFrom(tObj))
            {
                if (((DataRow)obj).Table == null || ((DataRow)obj).Table.Columns == null)
                    return false;

                var c = ((DataRow)obj).Table.Columns.OfType<DataColumn>().SingleOrDefault(p => p.ColumnName == propertyName);
                return ((DataRow)obj)[c];
            }
            else
            {
                var pr = tObj.GetProperties().SingleOrDefault(p => p.Name == propertyName);
                if (pr == null)
                    return null;

                return pr.GetValue(obj);
            }
        }
    }
}
