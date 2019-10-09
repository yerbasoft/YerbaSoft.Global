using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSWork.DTO.GlobalConfigs
{
    public class AmbienteWeb
    {
        public string Name { get; set; }
        public string RelativeUrl { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public AmbienteWeb Clone()
        {
            return new AmbienteWeb()
            {
                Name = this.Name,
                RelativeUrl = this.RelativeUrl
            };
        }
    }
}
