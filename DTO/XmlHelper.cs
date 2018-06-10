using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace YerbaSoft.DTO
{
    public static class XmlHelper
    {
        public static Result<Types.TwoList<XmlSeverityType, string>> ValidateXMLFromFiles(string xmlFilePath, string xsdFilePath)
        {
            var result = new Result<Types.TwoList<XmlSeverityType, string>>(true);

            var schemas = new XmlSchemaSet();
            schemas.Add("", xsdFilePath);
            
            var xml = System.Xml.Linq.XDocument.Load(xmlFilePath);

            xml.Validate(schemas, (o, e) =>
            {
                var msg = e.Message;
                if (o is System.Xml.Linq.XAttribute)
                {
                    var a = (System.Xml.Linq.XAttribute)o;
                    msg += $" in Attribute '{a.Name}' in Element {a.Parent.Name}";
                }
                else if (o is System.Xml.Linq.XElement)
                {
                    msg += $" in Element {((System.Xml.Linq.XElement)o).Name}";
                }

                result.Success = false;
                result.Data = result.Data ?? new Types.TwoList<XmlSeverityType, string>();
                result.Data.Add(new Types.Two<XmlSeverityType, string>(e.Severity, msg));
            });

            return result;
        }
    }
}
