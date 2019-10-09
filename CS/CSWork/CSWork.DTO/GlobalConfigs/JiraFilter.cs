using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSWork.DTO.GlobalConfigs
{
    public class JiraFilter
    {
        public JiraFilter() { }
        public JiraFilter(CSWork.DTO.JiraObjs.Filter obj)
        {
            this.Code = obj.id;
            this.Name = obj.name;
            this.Jql = obj.jql;
            this.SearchUrl = obj.searchUrl;
        }

        public int Code { get; set; }
        public string Name { get; set; }
        public string Jql { get; set; }
        public string SearchUrl { get; set; }
    }
}
