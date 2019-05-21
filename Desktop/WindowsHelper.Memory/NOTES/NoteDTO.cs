using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Mapping;

namespace WindowsHelper.Memory.NOTES
{
    public class NoteDTO : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        [Direct]
        public Guid? Id { get; set; }

        [Direct]
        public string Title { get; set; }

        [Direct]
        public bool AutoOpen { get; internal set; }

        [Direct]
        public int FormX { get; set; }
        
        [Direct]
        public int FormY { get; set; }

        [Direct]
        public int FormWidth { get; set; }

        [Direct]
        public int FormHeight { get; set; }

        [Direct]
        public int BackColor { get; internal set; }

        [Direct]
        public string Content { get; set; }
    }
}
