using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace YerbaSoft.DTO.Mapping
{
    public static class Map
    {
        #region Class to Class

        /// <summary>
        /// Obtiene un objeto T mapeando desde "ori"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static T Get<T>(object ori) where T : new()
        {
            return Get<T>(ori, null, new Config.DefaultAutomappingConfig());
        }
        public static T Get<T>(object ori, object extraInfo) where T : new()
        {
            return Get<T>(ori, extraInfo, new Config.DefaultAutomappingConfig());
        }
        public static T Get<T>(object ori, object extraInfo, Config.AutoMappingConfig config) where T : new()
        {
            if (ori == null) return default(T);
            config = config ?? new Config.DefaultAutomappingConfig();

            object des = new T();
            CopyTo(ori, des, config);

            if (config.UseExtraMapping && typeof(Mapping.IExtraMapping).IsAssignableFrom(typeof(T)))
                ((Mapping.IExtraMapping)des).ExtraMappingWhenGet(ori, extraInfo);

            return (T)des;
        }

        /// <summary>
        /// Copia las propiedades que puede y se configuraron desde "ori" a "des"
        /// </summary>
        public static void CopyTo(object ori, object des)
        {
            CopyTo(ori, des, new Config.DefaultAutomappingConfig());
        }
        public static void CopyTo(object ori, object des, Config.AutoMappingConfig config)
        {
            if (des == null)
                throw new Exception("El objeto destino a copiar no puede ser null. Utilice 'Get' de no tener el objeto instanciado");
            if (ori == null)
                return; //no copio nada
            config = config ?? new Config.DefaultAutomappingConfig();

            var tOri = ori.GetType();
            var tDes = des.GetType();

            Type tConfig = null;    //ori o des que contiene la configuración de AutoMapping (Ori por default)
            if (tOri.CustomAttributes.Any(at => at.AttributeType == typeof(AutoMapping)))
                tConfig = tOri;
            else if (tDes.CustomAttributes.Any(at => at.AttributeType == typeof(AutoMapping)))
                tConfig = tDes;
            else
                throw new Exception("Ni el objeto de origen ni el de destino poseen el atributo de clase 'AutoMapping'");

            var props = (from ps in tConfig.GetProperties()    //Busco atributos en la clase de destino de copia
                         from at in ps.CustomAttributes
                         where typeof(IMappingPropertyAttribute).IsAssignableFrom(at.AttributeType)
                         select new
                         {
                             Type = at.AttributeType,
                             ConfigProp = ps,
                             Attr = (IMappingPropertyAttribute)at.Constructor.Invoke(at.ConstructorArguments.Select(x => x.Value).ToArray())
                         });

            // Copio los datos
            foreach (var x in props)
            {
                try
                {
                    x.Attr.Map(tConfig, tOri, ori, tDes, des, x.ConfigProp, config);
                }
                catch (Exception eee)
                {
                    throw eee;
                }
            }
        }

        #endregion

        #region Value List to Class

        /// <summary>
        /// Obtiene un objeto T mapeando las propiedades desde una lista de valores
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static T Get<T>(Dictionary<string, object> values) where T : new()
        {
            return Get<T>(values, null, new Config.DefaultAutomappingConfig());
        }
        public static T Get<T>(Dictionary<string, object> values, object extraInfo) where T : new()
        {
            return Get<T>(values, extraInfo, new Config.DefaultAutomappingConfig());
        }
        public static T Get<T>(Dictionary<string, object> values, object extraInfo, Config.AutoMappingConfig config) where T : new()
        {
            if (values == null) return default(T);
            config = config ?? new Config.DefaultAutomappingConfig();
                        
            object des = new T();
            CopyTo(values, des, config);

            if (config.UseExtraMapping && typeof(Mapping.IExtraMapping).IsAssignableFrom(typeof(T)))
                ((Mapping.IExtraMapping)des).ExtraMappingWhenGet(values, extraInfo);

            return (T)des;
        }
        
        /// <summary>
        /// Copia las propiedades que puede y se configuraron desde una lista de valores "values" al objeto "des"
        /// </summary>
        public static void CopyTo(Dictionary<string, object> values, object des)
        {
            CopyTo(values, des, new Config.DefaultAutomappingConfig());
        }
        public static void CopyTo(Dictionary<string, object> values, object des, Config.AutoMappingConfig config)
        {
            if (des == null)
                throw new Exception("El objeto destino a copiar no puede ser null. Utilice 'Get' de no tener el objeto instanciado");
            config = config ?? new Config.DefaultAutomappingConfig();

            var tDes = des.GetType();

            var props = (from ps in tDes.GetProperties()    //Busco atributos en la clase de destino de copia
                         from at in ps.CustomAttributes
                         where typeof(IMappingPropertyAttribute).IsAssignableFrom(at.AttributeType)
                         select new
                         {
                             Type = at.AttributeType,
                             ConfigProp = ps,
                             Attr = (IMappingPropertyAttribute)at.Constructor.Invoke(at.ConstructorArguments.Select(x => x.Value).ToArray())
                         });


            // Copio los datos
            foreach (var x in props)
                x.Attr.Map(values, tDes, des, x.ConfigProp, config);
        }

        #endregion

        #region XmlNode to Class

        /// <summary>
        /// Obtiene un objeto T mapeando desde "ori"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static T Get<T>(XmlNode ori) where T : new()
        {
            return Get<T>(ori, null, new Config.DefaultAutomappingConfig());
        }
        public static T Get<T>(XmlNode ori, object info) where T : new()
        {
            return Get<T>(ori, info, new Config.DefaultAutomappingConfig());
        }
        public static T Get<T>(XmlNode ori, object extraInfo, Config.AutoMappingConfig config) where T : new()
        {
            if (ori == null) return default(T);
            config = config ?? new Config.DefaultAutomappingConfig();

            object des = new T();
            CopyTo(ori, des, config);

            if (config.UseExtraMapping && typeof(Mapping.IExtraMapping).IsAssignableFrom(typeof(T)))
                ((Mapping.IExtraMapping)des).ExtraMappingWhenGet(ori, extraInfo);

            return (T)des;
        }

        /// <summary>
        /// Copia las propiedades que puede y se configuraron desde "ori" a "des"
        /// </summary>
        public static void CopyTo(XmlNode ori, object des)
        {
            CopyTo(ori, des, new Config.DefaultAutomappingConfig());
        }
        public static void CopyTo(XmlNode ori, object des, Config.AutoMappingConfig config)
        {
            if (des == null)
                throw new Exception("El objeto destino a copiar no puede ser null. Utilice 'Get' de no tener el objeto instanciado");
            config = config ?? new Config.DefaultAutomappingConfig();

            var tDes = des.GetType();
            
            // Tiene Automapping
            var props = (from ps in tDes.GetProperties()    //Busco atributos en la clase de destino de copia
                         from at in ps.CustomAttributes
                         where typeof(IMappingPropertyAttribute).IsAssignableFrom(at.AttributeType)
                         select new
                         {
                             Type = at.AttributeType,
                             ConfigProp = ps,
                             Attr = (IMappingPropertyAttribute)at.Constructor.Invoke(at.ConstructorArguments.Select(x => x.Value).ToArray())
                         });


            // Copio los datos
            foreach (var x in props)
                x.Attr.Map(ori, tDes, des, x.ConfigProp, config);
        }

        #endregion

        #region DataRow to Class

        /// <summary>
        /// Obtiene un objeto T mapeando desde "ori"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ori"></param>
        /// <returns></returns>
        public static T Get<T>(DataRow ori) where T : new()
        {
            return Get<T>(ori, null, new Config.DefaultAutomappingConfig());
        }
        public static T Get<T>(DataRow ori, object extraInfo) where T : new()
        {
            return Get<T>(ori, extraInfo, new Config.DefaultAutomappingConfig());
        }
        public static T Get<T>(DataRow ori, object extraInfo, Config.AutoMappingConfig config) where T : new()
        {
            if (ori == null) return default(T);
            config = config ?? new Config.DefaultAutomappingConfig();

            object des = new T();
            CopyTo(ori, des, config);

            if (config.UseExtraMapping && typeof(Mapping.IExtraMapping).IsAssignableFrom(typeof(T)))
                ((Mapping.IExtraMapping)des).ExtraMappingWhenGet(ori, extraInfo);

            return (T)des;
        }

        /// <summary>
        /// Copia las propiedades que puede y se configuraron desde "ori" a "des"
        /// </summary>
        public static void CopyTo(DataRow ori, object des)
        {
            CopyTo(ori, des, new Config.DefaultAutomappingConfig());
        }
        public static void CopyTo(DataRow ori, object des, Config.AutoMappingConfig config)
        {
            if (des == null)
                throw new Exception("El objeto destino a copiar no puede ser null. Utilice 'Get' de no tener el objeto instanciado");
            config = config ?? new Config.DefaultAutomappingConfig();

            var tDes = des.GetType();

            // Tiene Automapping
            var props = (from ps in tDes.GetProperties()    //Busco atributos en la clase de destino de copia
                         from at in ps.CustomAttributes
                         where typeof(IMappingPropertyAttribute).IsAssignableFrom(at.AttributeType)
                         select new
                         {
                             Type = at.AttributeType,
                             ConfigProp = ps,
                             Attr = (IMappingPropertyAttribute)at.Constructor.Invoke(at.ConstructorArguments.Select(x => x.Value).ToArray())
                         });


            // Copio los datos
            foreach (var x in props)
                x.Attr.Map(ori, tDes, des, x.ConfigProp, config);
        }

        #endregion
    }
}
