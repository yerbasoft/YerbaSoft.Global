using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSWork.DTO.GlobalConfigs
{
    public class Working
    {
        public bool AllowTaskWithoutIssue { get; set; } = true;

        public List<JiraFilter> Filters { get; set; } = new List<JiraFilter>();

        public WorkingClonning Clonning { get; set; } = new WorkingClonning();
    }
}
