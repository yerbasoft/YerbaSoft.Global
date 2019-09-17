using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;

namespace YerbaSoft.DTO.Mapping
{
    /// <summary>
    /// Se Mapea una clase directamente contra un campo en particular que se espera que sea una clase
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SubClass : AttributeClass, IMappingPropertyAttribute
    {
        public string RemoteName { get; set; }
        public bool MustExists { get; set; }

        /// <summary>
        /// Indica que el mapping es una subclase.
        /// </summary>
        public SubClass() { }
        public SubClass(string remoteName) : this(false, remoteName) { }
        public SubClass(bool mustExists) : this(mustExists, null) { }
        public SubClass(bool mustExists, string remoteName)
        {
            this.MustExists = mustExists;
            this.RemoteName = remoteName;
        }

        public void Map(Type tConfig, Type tOri, object oOri, Type tDes, object oDes, System.Reflection.PropertyInfo configProp, Config.AutoMappingConfig config)
        {
            var pOri = tConfig == tOri ? configProp : tOri.GetProperty(RemoteName ?? configProp.Name);
            var pDes = tConfig == tDes ? configProp : tDes.GetProperty(RemoteName ?? configProp.Name);

            if (pOri == null)
                throw new ApplicationException(string.Format("AutoMapping[SubClass] No se encuentra la propiedad {0} en {1}", RemoteName ?? configProp.Name, tOri.FullName));
            if (pDes == null)
                throw new ApplicationException(string.Format("AutoMapping[SubClass] No se encuentra la propiedad {0} en {1}", RemoteName ?? configProp.Name, tDes.FullName));

            var vOri = pOri.GetValue(oOri);
            if (vOri == null && MustExists)
                throw new ApplicationException(string.Format("AutoMapping[SubClass] La propiedad de origen {0}.{1} debe tener un valor", tOri.FullName, pOri.Name));

            var vDes = pDes.PropertyType.GetConstructor(new Type[] { }).Invoke(null);
            Mapping.Map.CopyTo(vOri, vDes, config);

            pDes.SetValue(oDes, vDes);
        }

        public void Map(Dictionary<string, object> values, Type tDes, object oDes, System.Reflection.PropertyInfo pDes, Config.AutoMappingConfig config)
        {
            if (!values.Keys.Contains(RemoteName ?? pDes.Name))
                throw new ApplicationException(string.Format("AutoMapping[SubClass][Dictionary] La lista de valores no contiene la clave {0}", RemoteName ?? pDes.Name));

            var vOri = values[RemoteName ?? pDes.Name];
            if (vOri == null && MustExists)
                throw new ApplicationException(string.Format("AutoMapping[SubClass][Dictionary] La lista de valores contiene valor null en la clave {0}", RemoteName ?? pDes.Name));

            var ctpDes = pDes.PropertyType.GetConstructor(new Type[] { });
            if (ctpDes == null)
                throw new ApplicationException(string.Format("AutoMapping[SubClass][Dictionary] La clase {0} no posee un constructor accesible sin argumentos", pDes.PropertyType.FullName));

            var vDes = ctpDes.Invoke(null);
            Mapping.Map.CopyTo(vOri, vDes, config);

            pDes.SetValue(oDes, vDes);
        }

        public void Map(XmlNode ori, Type tDes, object oDes, System.Reflection.PropertyInfo pDes, Config.AutoMappingConfig config)
        {
            XmlNode vOri = null;
            var childs = ori.ChildNodes.OfType<XmlNode>().Where(p => p.Name == (RemoteName ?? pDes.Name));
            if (childs.Count() > 1)
                throw new ApplicationException(string.Format("AutoMapping[SubClass][XMLNode] El nodo {0} posee más de un subnodo con el atributo {1}", ori.Name, RemoteName ?? pDes.Name));

            vOri = childs.SingleOrDefault();
            if (vOri == null)
            {
                if (MustExists)
                    throw new ApplicationException(string.Format("AutoMapping[SubClass][XMLNode] El nodo {0} no posee un subnodo con el atributo {1}", ori.Name, RemoteName ?? pDes.Name));
                else
                    return;
            }

            var ctpDes = pDes.PropertyType.GetConstructor(new Type[] { });
            if (ctpDes == null)
                throw new ApplicationException(string.Format("AutoMapping[SubClass][Dictionary] La clase {0} no posee un constructor accesible sin argumentos", pDes.PropertyType.FullName));

            var vDes = ctpDes.Invoke(null);
            Mapping.Map.CopyTo(vOri, vDes, config);

            if (config.UseExtraMapping && typeof(Mapping.IExtraMapping).IsAssignableFrom(pDes.PropertyType))
                ((Mapping.IExtraMapping)vDes).ExtraMappingWhenGet(vOri, null);

            pDes.SetValue(oDes, vDes);
        }

        public void Map(DataRow oOri, Type tDes, object oDes, System.Reflection.PropertyInfo pDes, Config.AutoMappingConfig config)
        {
            var col = oOri.Table.Columns.OfType<DataColumn>().SingleOrDefault(p => p.ColumnName == (RemoteName ?? pDes.Name));
            if (col == null)
                throw new ApplicationException(string.Format("AutoMapping[SubClass][DataRow] No se encuentra la columna {0} en DataRow de origen de datos para la clase {1}", RemoteName ?? pDes.Name, tDes.FullName));

            var vOri = oOri[col];
            if (vOri == null && MustExists)
                throw new ApplicationException(string.Format("AutoMapping[SubClass][Datarow] El valor de la columna {0} en el DataRow debe tener un valor para la clase {1}", RemoteName ?? pDes.Name, tDes.FullName));

            var ctpDes = pDes.PropertyType.GetConstructor(new Type[] { });
            if (ctpDes == null)
                throw new ApplicationException(string.Format("AutoMapping[SubClass][DataRow] La clase {0} no posee un constructor accesible sin argumentos", pDes.PropertyType.FullName));

            var vDes = ctpDes.Invoke(null);
            Mapping.Map.CopyTo(vOri, vDes, config);

            pDes.SetValue(oDes, vDes);
        }
    }
}
