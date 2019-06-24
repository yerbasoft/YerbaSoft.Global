using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Desktop.PW.Properties;
using YerbaSoft.DTO.Mapping;

namespace YerbaSoft.Desktop.PW.Configuration
{
    public class Cuenta
    {
        [Direct]
        public string Name { get; internal set; }

        [Direct]
        public string Login { get; set; }

        [Direct]
        public string Pass { get; set; }

        [Direct]
        public string Type { get; set; }

        [Direct(UseComplexConvert = true)]
        public bool? AntiFreeze { get; set; }

        [Direct(UseComplexConvert = true)]
        public bool? ShowInfo { get; set; }

        [NoMap]
        public Image TypeImg
        {
            get
            {
                switch (this.Type ?? "ER")
                {
                    case "WR": return Resources.WR;
                    case "MG": return Resources.MG;
                    case "WB": return Resources.WB;
                    case "WF": return Resources.WF;
                    case "EA": return Resources.EA;
                    case "EP": return Resources.EP;
                    case "AS": return Resources.AS;
                    case "PS": return Resources.PS;
                    case "SE": return Resources.SE;
                    case "MY": return Resources.MY;
                    case "SB": return Resources.SB;
                    case "DB": return Resources.DB;
                    case "TE": return Resources.TE;
                    default: return Resources.ER;
                }
            }

        }
    }
}
