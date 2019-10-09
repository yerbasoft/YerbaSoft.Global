using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSWork.DTO.JiraObjs;

namespace CSWork.DTO.WorkDatas
{
    public class Transition
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Transition() { }
        public Transition(JiraObjs.Transition obj)
        {
            this.Id = obj.id;
            this.Name = obj.name;
        }
    }
}
