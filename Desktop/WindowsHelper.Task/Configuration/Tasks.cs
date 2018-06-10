using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using YerbaSoft.DTO;

namespace WindowsHelper.Task.Configuration
{
    internal class Tasks
    {
        [YerbaSoft.DTO.Mapping.SubList]
        public List<Task> Task { get; set; }        
    }
}