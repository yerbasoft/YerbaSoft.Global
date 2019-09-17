using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Xml;
using YerbaSoft.DTO.Mapping.Config;

namespace YerbaSoft.DTO.Mapping
{
    /// <summary>
    /// No mapea la propiedad
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NoMap : AttributeClass, IMappingPropertyAttribute
    {
        public void Map(Type tConfig, Type tOri, object oOri, Type tDes, object oDes, PropertyInfo configProp, AutoMappingConfig config)
        {

        }

        public void Map(Dictionary<string, object> values, Type tDes, object des, PropertyInfo dProp, AutoMappingConfig config)
        {

        }

        public void Map(XmlNode ori, Type tDes, object oDes, PropertyInfo dProp, AutoMappingConfig config)
        {

        }

        public void Map(DataRow ori, Type tDes, object oDes, PropertyInfo dProp, AutoMappingConfig config)
        {

        }
    }
}
