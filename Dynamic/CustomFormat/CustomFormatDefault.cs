using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Dynamic.CustomFormat
{
    public class CustomFormatDefault : CustomFormatBase
    {
        protected override string BlockIni { get { return "{"; } }
        protected override string BlockFin { get { return "}"; } }
        protected override string ModeSeparator { get { return "::"; } }
        protected override bool OnlyEventWhenError { get { return false; } }
    }
}
