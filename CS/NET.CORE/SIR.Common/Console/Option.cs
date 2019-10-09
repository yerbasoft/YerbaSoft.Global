using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.Console
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class Option : Attribute
    {
        public string Name { get; private set; }
        public string Descripcion { get; private set; }

        public bool Required { get; set; } = false;
        public string DateTimeFormat { get; set; } = "yyyyMMdd";

        public Option(string name, string description)
        {
            this.Name = name;
            this.Descripcion = description;
        }
    }
}
