using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace YerbaSoft.DTO
{
    public class ConfigurationManager
    {
        private string FilePath { get; set; }
        public XmlDocument Xml { get; set; }

        public ConfigurationManager(string filePath)
        {
            this.FilePath = filePath;
            this.Xml = new XmlDocument();
        }

        /// <summary>
        /// Devuelve el XmlNode principal del XML
        /// </summary>
        /// <returns></returns>
        public XmlNode GetMainElement()
        {
            this.Xml.Load(this.FilePath);
            return Xml.DocumentElement;
        }

        /// <summary>
        /// Devuelve el XmlNode principal del XML convertido en T
        /// </summary>
        /// <returns></returns>
        public T GetMainElement<T>() where T : class, new()
        {
            this.Xml.Load(this.FilePath);
            return Get<T>(Xml.DocumentElement, new Mapping.Config.DefaultAutomappingConfig());
        }
        /// <summary>
        /// Devuelve el XmlNode principal del XML convertido en T
        /// </summary>
        /// <returns></returns>
        public T GetMainElement<T>(Mapping.Config.AutoMappingConfig config) where T : class, new()
        {
            this.Xml.Load(this.FilePath);
            return Get<T>(Xml.DocumentElement, config);
        }


        /// <summary>
        /// Devuelve los subnodos de un nodo
        /// </summary>
        /// <param name="nodo"></param>
        /// <returns></returns>
        public XmlNode[] GetSubNodes(XmlNode nodo)
        {
            if (nodo == default(XmlNode))
                return null;

            return nodo.ChildNodes.OfType<XmlNode>().ToArray();
        }
        /// <summary>
        /// Devuelve los SubNodos de un nodo Tipeado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodo"></param>
        /// <returns></returns>
        public T[] GetSubNodes<T>(XmlNode nodo, Mapping.Config.AutoMappingConfig config) where T : class, new()
        {
            var r = new List<T>();

            foreach (var n in GetSubNodes(nodo))
                r.Add(Get<T>(n, config));

            return r.ToArray();
        }


        /// <summary>
        /// Devuelve una clase con a estructura del nodo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodo"></param>
        /// <returns></returns>
        public T Get<T>(XmlNode nodo) where T : class, new()
        {
            return Get<T>(nodo, new Mapping.Config.DefaultAutomappingConfig());
        }
        /// <summary>
        /// Devuelve una clase con a estructura del nodo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodo"></param>
        /// <returns></returns>
        public T Get<T>(XmlNode nodo, Mapping.Config.AutoMappingConfig config) where T : class, new()
        {
            if (nodo == default(XmlNode))
                return null;

            var r = YerbaSoft.DTO.Mapping.Map.Get<T>(nodo, config);

            return r;
        }
    }
}
