using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Xml;

namespace YerbaSoft.DTO.Mapping
{
    /// <summary>
    /// Se Mapea directamente contra un campo en particular
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Direct : AttributeClass, IMappingPropertyAttribute
    {
        public string RemoteName { get; set; }
        public bool UseComplexConvert { get; set; }

        /// <summary>
        /// Indica que el mapeo es directo
        /// </summary>
        public Direct() { }
        public Direct(string remoteName) : this(remoteName, false) { }
        public Direct(bool useComplexConvert) : this(null, useComplexConvert) { }
        public Direct(string remoteName, bool useComplexConvert)
        {
            this.RemoteName = remoteName;
            this.UseComplexConvert = useComplexConvert;
        }

        public void Map(Type tConfig, Type tOri, object oOri, Type tDes, object oDes, PropertyInfo configProp, Config.AutoMappingConfig config)
        {
            #region Obtengo la propiedad de Destino

            PropertyInfo dProp = configProp;    // default: tDes == tConfig 

            if (tOri == tConfig)     //configProp es parte de tOri (utilizar el RemoteName, en caso de no tener, utilizar el mosmo nombre de la propiedad)
            {
                dProp = tDes.GetProperty(this.RemoteName ?? configProp.Name);
                if (dProp == null)
                    if (config.ThrowErrorOnDirect)
                        throw new ApplicationException(string.Format("AutoMapping[Direct] No se encuentra la propiedad '{0}' para el Objeto {1}", this.RemoteName ?? configProp.Name, tDes.FullName));
                    else
                        return;
            }

            #endregion

            #region Obtengo el valor a guardar

            var oProp = tOri == tConfig ? configProp : tOri.GetProperty(this.RemoteName ?? configProp.Name);
            if (oProp == null)
            {
                if (config.ThrowErrorOnDirect)
                    throw new ApplicationException(string.Format("AutoMapping[Direct] No se encuentra la propiedad '{0}' para el Objeto {1}", this.RemoteName ?? configProp.Name, tOri.FullName));
                else
                    return;
            }

            var value = oProp.GetValue(oOri);

            #endregion

            #region Guardo el valor en la propiedad

            try
            {
                if (dProp.UseComplexConvert())
                    dProp.SetValue(oDes, Convert.To(dProp.PropertyType, value));
                else
                    dProp.SetValue(oDes, value);
            }
            catch (Exception ex)
            {
                if (config.ThrowErrorOnDirect)
                    throw new ApplicationException(string.Format("AutoMapping[Direct] Error al copiar un dato de {0}.{1} a {2}.{3}", tOri.FullName, oProp.Name, tDes.FullName, dProp.Name), ex);
            }

            #endregion
        }

        public void Map(Dictionary<string, object> values, Type tDes, object oDes, PropertyInfo pDes, Config.AutoMappingConfig config)
        {
            if (!ExistsProperty(values, this.RemoteName ?? pDes.Name, config))
            {
                if (config.ThrowErrorOnDirect)
                    throw new ApplicationException(string.Format("AutoMapping[Direct][ValueList] No se encuentra el valor '{0}' en la lista de valores", this.RemoteName ?? pDes.Name));
                else
                    return;
            }

            var value = GetPropertyValue(values, this.RemoteName ?? pDes.Name, config);

            try
            {
                if (pDes.UseComplexConvert())
                    pDes.SetValue(oDes, Convert.To(pDes.PropertyType, value));
                else
                    pDes.SetValue(oDes, value);
            }
            catch (Exception ex)
            {
                if (config.ThrowErrorOnDirect)
                    throw new ApplicationException(string.Format("AutoMapping[Direct][ValueList] Error al copiar un dato '{0}' a {1}.{2}", value, tDes.FullName, pDes.Name), ex);
            }
        }

        public void Map(XmlNode ori, Type tDes, object oDes, PropertyInfo pDes, Config.AutoMappingConfig config)
        {
            if (!ExistsProperty(ori, this.RemoteName ?? pDes.Name, config))
            {
                if (config.ThrowErrorOnDirect)
                    throw new ApplicationException(string.Format("AutoMapping[Direct][XmlNode] No se encuentra el atributo '{0}' en el nodo de Xml", this.RemoteName ?? pDes.Name));
                else
                    return;
            }

            var value = GetPropertyValue(ori, this.RemoteName ?? pDes.Name, config);

            try
            {
                if (pDes.UseComplexConvert())
                    pDes.SetValue(oDes, Convert.To(pDes.PropertyType, value));
                else
                    pDes.SetValue(oDes, value);
            }
            catch (Exception ex)
            {
                if (config.ThrowErrorOnDirect)
                    throw new ApplicationException(string.Format("AutoMapping[Direct][XmlNode] Error al copiar un dato '{0}' a {1}.{2}", value, tDes.FullName, pDes.Name), ex);
            }
        }

        public void Map(DataRow ori, Type tDes, object oDes, PropertyInfo pDes, Config.AutoMappingConfig config)
        {
            if (!ExistsProperty(ori, this.RemoteName ?? pDes.Name, config))
            {
                if (config.ThrowErrorOnDirect)
                    throw new ApplicationException(string.Format("AutoMapping[Direct][DataRow] No se encuentra la columna '{0}' en el DataRow para la clase", this.RemoteName ?? pDes.Name, tDes.FullName));
                else
                    return;
            }

            var value = GetPropertyValue(ori, this.RemoteName ?? pDes.Name, config);

            try
            {
                if (pDes.UseComplexConvert())
                    pDes.SetValue(oDes, Convert.To(pDes.PropertyType, value));
                else
                    pDes.SetValue(oDes, value);
            }
            catch (Exception ex)
            {
                if (config.ThrowErrorOnDirect)
                    throw new ApplicationException(string.Format("AutoMapping[Direct][DataRow] Error al copiar un dato '{0}' a {1}.{2}", value, tDes.FullName, pDes.Name), ex);
            }
        }
    }
}
