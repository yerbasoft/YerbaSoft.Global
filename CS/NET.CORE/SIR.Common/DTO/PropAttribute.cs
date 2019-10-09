using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SIR.Common.DTO
{
    public class PropAttribute<T> where T : Attribute
    {
        public PropertyInfo Prop { get; internal set; }
        public Type Type { get; internal set; }
        public T Attr { get; internal set; }
    }
}
