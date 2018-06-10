using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace YerbaSoft.DTO.Mapping
{
    /// <summary>
    /// Se Mapea una clase directamente contra un campo en particular que se espera que sea una clase
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SubList : AttributeClass, IMappingPropertyAttribute
    {
        public string RemoteName { get; set; }
        public bool MustExists { get; set; }

        /// <summary>
        /// Indica que el mapping es una subclase.
        /// </summary>
        public SubList() { }
        public SubList(string remoteName) : this(false, remoteName) { }
        public SubList(bool mustExists) : this(mustExists, null) { }
        public SubList(bool mustExists, string remoteName)
        {
            this.MustExists = mustExists;
            this.RemoteName = remoteName;
        }
        
        public void Map(Type tConfig, Type tOri, object oOri, Type tDes, object oDes, System.Reflection.PropertyInfo cProp, Config.AutoMappingConfig config)
        {
            var pOri = tConfig == tOri ? cProp : tOri.GetProperty(RemoteName ?? cProp.Name);
            var pDes = tConfig == tDes ? cProp : tDes.GetProperty(RemoteName ?? cProp.Name);

            if (pOri == null)
                throw new ApplicationException(string.Format("AutoMapping[SubList] No se encuentra la propiedad {0} en {1}", RemoteName ?? cProp.Name, tOri.FullName));
            if (pDes == null)
                throw new ApplicationException(string.Format("AutoMapping[SubList] No se encuentra la propiedad {0} en {1}", RemoteName ?? cProp.Name, tDes.FullName));

            var tpDes = pDes.PropertyType;

            // Tipos Soportados
            bool isIList = false;
            bool isICollection = false;

            if (tpDes.GenericTypeArguments.Length > 0)
            {
                var tList = typeof(IList<>).MakeGenericType(tpDes.GenericTypeArguments);
                isIList = tList.IsAssignableFrom(tpDes);
                var tCollection = typeof(ICollection<>).MakeGenericType(tpDes.GenericTypeArguments);
                isICollection = tCollection.IsAssignableFrom(tpDes);
            }

            if (!isIList && !isICollection)
                throw new ApplicationException(string.Format("AutoMapping[SubList] La propiedad de destino debe ser de tipo IList o ICollection {1}.{0}", RemoteName ?? cProp.Name, tDes.FullName));

            dynamic vDes = (dynamic)Activator.CreateInstance(tpDes);

            var vOri = (dynamic)pOri.GetValue(oOri);
            if (vOri == null)
            {
                if (MustExists)
                    throw new ApplicationException(string.Format("AutoMapping[SubList] El valor de la propiedad de origen {0} debe tener algún valor para {1}", RemoteName ?? cProp.Name, tDes.FullName));
                else
                    vDes = null;
            }
            else
            {
                int i = 0;
                foreach(var oItem in vOri)
                {
                    var ctpDes = tpDes.GetConstructor(new Type[] { });
                    if (ctpDes == null)
                        throw new ApplicationException(string.Format("AutoMapping[SubList] El sub-tipo de la lista de la propiedad de destino '{0}' de la clase '{1}' no tiene un constructor accesible sin parámetros", RemoteName ?? cProp.Name, tDes.FullName));

                    var dItem = Activator.CreateInstance(tpDes.GenericTypeArguments[0]);
                    Mapping.Map.CopyTo((object)oItem, dItem, config);

                    if (isIList)
                        vDes.Insert(i++, (dynamic)dItem);
                    else if (isICollection)
                        vDes.Add((dynamic)dItem);
                }
            }

            pDes.SetValue(oDes, vDes);
        }

        public void Map(Dictionary<string, object> values, Type tDes, object oDes, System.Reflection.PropertyInfo pDes, Config.AutoMappingConfig config)
        {
            var tpDes = pDes.PropertyType;

            // Tipos Soportados
            bool isIList = false;
            bool isICollection = false;

            if (tpDes.GenericTypeArguments.Length > 0)
            {
                var tList = typeof(IList<>).MakeGenericType(tpDes.GenericTypeArguments);
                isIList = tList.IsAssignableFrom(tpDes);
                var tCollection = typeof(ICollection<>).MakeGenericType(tpDes.GenericTypeArguments);
                isICollection = tCollection.IsAssignableFrom(tpDes);
            }

            if (!isIList && !isICollection)
                throw new ApplicationException(string.Format("AutoMapping[SubList] La propiedad de destino debe ser de tipo IList o ICollection {1}.{0}", RemoteName ?? pDes.Name, tDes.FullName));

            dynamic vDes = (dynamic)Activator.CreateInstance(tpDes);

            if (!values.Keys.Contains(RemoteName ?? pDes.Name))
                throw new ApplicationException(string.Format("AutoMapping[SubList][ValueList] No se encuentra el valor {0} en la lista de valores para mapear {1}", RemoteName ?? pDes.Name, tDes.FullName));

            var vOri = (dynamic)values[RemoteName ?? pDes.Name];
            if (vOri == null)
            {
                if (MustExists)
                    throw new ApplicationException(string.Format("AutoMapping[SubList][ValueList] El valor '{0}' en la lista de valores debe tener algún valor para mapear {1}", RemoteName ?? pDes.Name, tDes.FullName));
                else
                    vDes = null;
            }
            else
            {
                int i = 0;
                foreach (var oItem in vOri)
                {
                    var ctpDes = tpDes.GetConstructor(new Type[] { });
                    if (ctpDes == null)
                        throw new ApplicationException(string.Format("AutoMapping[SubList] El sub-tipo de la lista de la propiedad de destino '{0}' de la clase '{1}' no tiene un constructor accesible sin parámetros", RemoteName ?? pDes.Name, tDes.FullName));

                    var dItem = Activator.CreateInstance(tpDes.GenericTypeArguments[0]);
                    Mapping.Map.CopyTo((object)oItem, dItem, config);

                    if (isIList)
                    {
                        var mDes = tpDes.GetMethod("Insert", new Type[] { typeof(int), tpDes.GenericTypeArguments[0] });
                        mDes.Invoke(vDes, new object[] { i++, dItem });
                    }
                    else if (isICollection)
                    {
                        var mDes = tpDes.GetMethod("Add", new Type[] { tpDes.GenericTypeArguments[0] });
                        mDes.Invoke(vDes, new object[] { dItem });
                    }
                }
            }

            pDes.SetValue(oDes, vDes);
        }

        public void Map(XmlNode ori, Type tDes, object oDes, System.Reflection.PropertyInfo pDes, Config.AutoMappingConfig config)
        {
            var tpDes = pDes.PropertyType;

            // Tipos Soportados
            bool isIList = false;
            bool isICollection = false;

            if (tpDes.GenericTypeArguments.Length > 0)
            {
                var tList = typeof(IList<>).MakeGenericType(tpDes.GenericTypeArguments);
                isIList = tList.IsAssignableFrom(tpDes);
                var tCollection = typeof(ICollection<>).MakeGenericType(tpDes.GenericTypeArguments);
                isICollection = tCollection.IsAssignableFrom(tpDes);
            }

            if (!isIList && !isICollection)
                throw new ApplicationException(string.Format("AutoMapping[XmlNode] La propiedad de destino debe ser de tipo IList o ICollection {1}.{0}", RemoteName ?? pDes.Name, tDes.FullName));

            dynamic vDes = (dynamic)Activator.CreateInstance(tpDes);

            var vOri = ori.ChildNodes.OfType<XmlNode>().Where(p => p.Name == (RemoteName ?? pDes.Name));
            if (vOri.Count() == 0 && this.MustExists)
                throw new ApplicationException(string.Format("AutoMapping[XmlNode] No se encuentra el valor {0} en la lista de valores para mapear {1}", RemoteName ?? pDes.Name, tDes.FullName));


            int i = 0;
            foreach (var oItem in vOri)
            {
                var ctpDes = tpDes.GetConstructor(new Type[] { });
                if (ctpDes == null)
                    throw new ApplicationException(string.Format("AutoMapping[XmlNode] El sub-tipo de la lista de la propiedad de destino '{0}' de la clase '{1}' no tiene un constructor accesible sin parámetros", RemoteName ?? pDes.Name, tDes.FullName));

                var dItem = Activator.CreateInstance(tpDes.GenericTypeArguments[0]);
                Mapping.Map.CopyTo(oItem, dItem, config);

                if (config.UseExtraMapping && typeof(Mapping.IExtraMapping).IsAssignableFrom(tpDes.GenericTypeArguments[0]))
                    ((Mapping.IExtraMapping)dItem).ExtraMappingWhenGet(oItem, null);

                if (isIList)
                {
                    var mDes = tpDes.GetMethod("Insert", new Type[]{ typeof(int), tpDes.GenericTypeArguments[0] });
                    mDes.Invoke(vDes, new object[] { i++, dItem });
                }
                else if (isICollection)
                {
                    var mDes = tpDes.GetMethod("Add", new Type[] { tpDes.GenericTypeArguments[0] });
                    mDes.Invoke(vDes, new object[] { dItem });
                }
            }

            pDes.SetValue(oDes, vDes);
        }

        public void Map(DataRow ori, Type tDes, object oDes, System.Reflection.PropertyInfo pDes, Config.AutoMappingConfig config)
        {
            var tpDes = pDes.PropertyType;

            // Tipos Soportados
            bool isIList = false;
            bool isICollection = false;

            if (tpDes.GenericTypeArguments.Length > 0)
            {
                var tList = typeof(IList<>).MakeGenericType(tpDes.GenericTypeArguments);
                isIList = tList.IsAssignableFrom(tpDes);
                var tCollection = typeof(ICollection<>).MakeGenericType(tpDes.GenericTypeArguments);
                isICollection = tCollection.IsAssignableFrom(tpDes);
            }

            if (!isIList && !isICollection)
                throw new ApplicationException(string.Format("AutoMapping[DataRow] La propiedad de destino debe ser de tipo IList o ICollection {1}.{0}", RemoteName ?? pDes.Name, tDes.FullName));

            dynamic vDes = (dynamic)Activator.CreateInstance(tpDes);

            var col = ori.Table.Columns.OfType<DataColumn>().SingleOrDefault(p => p.ColumnName == (RemoteName ?? pDes.Name));
            if (col == null)
                throw new ApplicationException(string.Format("AutoMapping[DataRow] No se encuentra la columna {0} en el data row para mapear {1}", RemoteName ?? pDes.Name, tDes.FullName));

            var vOri = (dynamic)ori[col];
            if (vOri == null && this.MustExists)
                throw new ApplicationException(string.Format("AutoMapping[DataRow] La columna {0} no posee un valor válido para mapear {1}", RemoteName ?? pDes.Name, tDes.FullName));
            
            int i = 0;
            foreach (var oItem in vOri)
            {
                var ctpDes = tpDes.GetConstructor(new Type[] { });
                if (ctpDes == null)
                    throw new ApplicationException(string.Format("AutoMapping[DataRow] El sub-tipo de la lista de la propiedad de destino '{0}' de la clase '{1}' no tiene un constructor accesible sin parámetros", RemoteName ?? pDes.Name, tDes.FullName));

                var dItem = Activator.CreateInstance(tpDes.GenericTypeArguments[0]);
                Mapping.Map.CopyTo(oItem, dItem, config);

                if (isIList)
                {
                    var mDes = tpDes.GetMethod("Insert", new Type[] { typeof(int), tpDes.GenericTypeArguments[0] });
                    mDes.Invoke(vDes, new object[] { i++, dItem });
                }
                else if (isICollection)
                {
                    var mDes = tpDes.GetMethod("Add", new Type[] { tpDes.GenericTypeArguments[0] });
                    mDes.Invoke(vDes, new object[] { dItem });
                }
            }

            pDes.SetValue(oDes, vDes);
        }
    }
}
