using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace YerbaSoft.DTO.Mapping
{
    internal interface IMappingPropertyAttribute
    {
        /// <summary>
        /// Mapea un dato entre 2 clases desconocidas
        /// </summary>
        /// <returns></returns>
        void Map(Type tConfig, Type tOri, object oOri, Type tDes, object oDes, PropertyInfo configProp, Config.AutoMappingConfig config);

        /// <summary>
        /// Mapea el dato entre un diccionario de datos (origen) y una clase desconocida configurada (destino)
        /// </summary>
        void Map(Dictionary<string, object> values, Type tDes, object des, PropertyInfo dProp, Config.AutoMappingConfig config);

        /// <summary>
        /// Mapea el dato entre un XmlNode (origen) y una clase desconocida configurada (destino)
        /// </summary>
        void Map(XmlNode ori, Type tDes, object oDes, PropertyInfo dProp, Config.AutoMappingConfig config);

        /// <summary>
        /// Mapea el dato entre un DataRow (origen) y una clase desconocida configurada (destino)
        /// </summary>
        void Map(DataRow ori, Type tDes, object oDes, PropertyInfo dProp, Config.AutoMappingConfig config);
    }
}
