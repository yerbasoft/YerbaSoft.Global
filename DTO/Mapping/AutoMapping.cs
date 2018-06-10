using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.DTO.Mapping
{
    /// <summary>
    /// Se Mapea contra otra clase y ésta clase contendrá la información de mapeo
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoMapping : Attribute
    {
        public AutoMapping() { }
    }
}
