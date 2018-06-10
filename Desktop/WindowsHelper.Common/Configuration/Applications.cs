using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.Configuration
{
    public class Applications 
    {
        [YerbaSoft.DTO.Mapping.SubList]
        public List<App> App { get; set; } = new List<Configuration.App>();
    }
}
