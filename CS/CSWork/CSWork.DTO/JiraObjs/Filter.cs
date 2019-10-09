using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs
{
    public class Filter : Base.IJiraObject
    {
        public string self { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Author owner { get; set; }
        public string jql { get; set; }
        public string viewUrl { get; set; }
        public string searchUrl { get; set; }   // url con la búsqueda de issues del filtro
        public bool favourite { get; set; }
    }
}
