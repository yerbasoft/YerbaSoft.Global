using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using YerbaSoft.DTO;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.DAL.Repositories
{
    [AutoMapping]
    public abstract class XmlSimpleClass
    {
        internal const string UniqueKeyName = "UniqueKey";
        internal enum OperationType
        {
            New = 0,        // Nuevo objeto
            Get = 99,       // En DB
            ToUpsert = 1,   // Pendiente de Update/Insert
            ToDelete = 2    // Pendiente de Delete
        }

        [NoMap]
        internal string UniqueKey { get; set; }
        [NoMap]
        internal OperationType State { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (typeof(XmlSimpleClass).IsAssignableFrom(obj.GetType()))
                return this.Equals((XmlSimpleClass)obj);

            return base.Equals(obj);
        }

        public bool Equals(XmlSimpleClass obj)
        {
            if (obj == null) return false;
            if (this.State == OperationType.New && obj.State == OperationType.New)
                return false;

            return this.UniqueKey == obj.UniqueKey;
        }

        internal bool Equals(XmlNode node)
        {
            return node.Attr(UniqueKeyName) == this.UniqueKey;
        }

        public override int GetHashCode()
        {
            return string.IsNullOrEmpty(UniqueKey) ? base.GetHashCode() : UniqueKey.GetHashCode();
        }

        internal string GetXPath<T>(string uniqueKey)
        {
            return $"//{typeof(T).FullName}[{UniqueKeyName}='{uniqueKey}']";
        }

        internal void CopyToNode(XmlNode node)
        {
            var T = this.GetType();

            if (node.Attr(UniqueKeyName) == null)
            {
                // New element
                var newUniqueKey = (Guid.NewGuid().ToString() + Guid.NewGuid().ToString()).Replace("-", "");
                node.Attributes.Append(node.OwnerDocument.CreateAttribute(UniqueKeyName)).Value = newUniqueKey;
                this.UniqueKey = newUniqueKey;
            }

            foreach (var p in T.GetProperties().Where(p => p.CanRead && p.CanWrite))
            {
                var value = p.GetValue(this);
                var propNode = node.SubNodes(p.Name).SingleOrDefault();

                if (propNode == null)
                {
                    propNode = node.OwnerDocument.CreateNode(XmlNodeType.Element, p.Name, node.OwnerDocument.NamespaceURI);
                    node.AppendChild(propNode);
                }
                propNode.RemoveAll();   // borra los atributos actuales y los subnodos

                if (value == null)
                {
                    propNode.InnerText = "";
                }
                else if (p.CustomAttributes.Any(at => typeof(Direct).IsAssignableFrom(at.AttributeType)))
                {
                    string finalValue = "";
                    var usesProvider = p.PropertyType.GetMethod("ToString", new Type[] { typeof(IFormatProvider) });

                    if (DTO.Math.In(p.PropertyType, typeof(DateTime), typeof(DateTime?)))
                        finalValue = ((DateTime?)value).Value.Ticks.ToString();
                    else if (usesProvider == null)
                        finalValue = value.ToString();
                    else
                        finalValue = (string)usesProvider.Invoke(value, new object[] { System.Globalization.CultureInfo.InvariantCulture });

                    propNode.InnerText = finalValue;
                }
                else if (p.CustomAttributes.Any(at => typeof(SubClass).IsAssignableFrom(at.AttributeType)))
                {
                    ((XmlSimpleClass)value).CopyToNode(propNode);
                }
                else if (p.CustomAttributes.Any(at => typeof(SubList).IsAssignableFrom(at.AttributeType)))
                {
                    foreach (var item in (IEnumerable)value)
                    {
                        var itemListNode = node.OwnerDocument.CreateNode(XmlNodeType.Element, p.Name, node.OwnerDocument.NamespaceURI);
                        propNode.AppendChild(itemListNode);

                        ((XmlSimpleClass)item).CopyToNode(itemListNode);
                    }
                }
            }
        }

        internal XmlSimpleClass SetInfo(string uniqueKey, OperationType state)
        {
            this.UniqueKey = uniqueKey;
            this.State = state;
            return this;
        }
    }

    public class XmlSimpleRepository<T> : QueryableRepository<T> where T : XmlSimpleClass, new()
    {
        public override bool UseTransaction { get { return true; } }
        private string FileName { get; set; }
        private List<T> Cache { get; set; }
        private IQueryable<T> Query
        {
            get
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(this.FileName);
                var nodes = xml.SelectNodes($"//{typeof(T).FullName}").OfType<XmlNode>();
                var db = nodes.Select(n => (T)n.Cast<T>().SetInfo(n.Attr(XmlSimpleClass.UniqueKeyName), XmlSimpleClass.OperationType.Get)).Where(o => !Cache.Any(c => c.UniqueKey == o.UniqueKey));
                return Cache.Concat(db).AsQueryable<T>();
            }
        }

        public XmlSimpleRepository(string xmlFile) : base(null)
        {
            this.FileName = xmlFile;

            if (!new System.IO.FileInfo(this.FileName).Exists)
                System.IO.File.WriteAllText(this.FileName, "<?xml version=\"1.0\" encoding=\"utf-8\" ?><XmlSimpleRepository></XmlSimpleRepository>", Encoding.UTF8);

            base.SetSpecialQueriable(((System.Reflection.TypeInfo)(this.GetType())).DeclaredProperties.Single(p => p.Name == "Query"));
            this.Cache = new List<T>();
        }

        public override T UpsertEntity(T entity)
        {
            var inCache = Cache.SingleOrDefault(p => p.UniqueKey == entity.UniqueKey && !string.IsNullOrEmpty(entity.UniqueKey));
            Cache.Remove(inCache);
            entity.State = XmlSimpleClass.OperationType.ToUpsert;
            Cache.Add(entity);
            return entity;
        }

        public override void DeleteEntity(T entity)
        {
            var inCache = Cache.SingleOrDefault(p => p.UniqueKey == entity.UniqueKey);
            Cache.Remove(inCache);
            entity.State = XmlSimpleClass.OperationType.ToDelete;
            Cache.Add(entity);
        }

        public override T GetNew()
        {
            return new T();
        }

        public override void Commit()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(this.FileName);

            // Ejecuto las operaciones del cache
            foreach (var e in Cache)
            {
                var node = xml.SelectSingleNode($"/XmlSimpleRepository/{typeof(T).FullName}[@{XmlSimpleClass.UniqueKeyName}='{e.UniqueKey}']");

                // Upsert
                if (e.State == XmlSimpleClass.OperationType.ToUpsert)
                {
                    if (node == null)
                        node = xml.CreateElement(typeof(T).FullName);

                    e.CopyToNode(node);

                    xml.DocumentElement.AppendChild(node);
                }
                // Delete
                else if (e.State == XmlSimpleClass.OperationType.ToDelete)
                {
                    if (!string.IsNullOrEmpty(e.UniqueKey)) // Si UniqueKey es null es porque se borró una entidad que se creó en la misma transacción
                    {
                        if (node == null)
                            throw new OperationCanceledException("El registro que intenta eliminar no existe");

                        xml.DocumentElement.RemoveChild(node);
                    }
                }
            }

            xml.Save(this.FileName);
            Cache = new List<T>();
        }

        public override void RollBack()
        {
            Cache = new List<T>();
        }
    }
}
