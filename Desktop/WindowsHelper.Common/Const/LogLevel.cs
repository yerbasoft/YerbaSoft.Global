using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper
{
    public enum LogLevel
    {
        [Description("DEBUG")]
        Debug,
        [Description("INFO")]
        Info,
        [Description("ERROR")]
        Error,
        [Description("WARN")]
        Warn
    }
}
