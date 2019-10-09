using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.GlobalConfigs
{
    public class Alarmas
    {
        public string ShowInMonitor { get; set; }
        public int ShowInPosition { get; set; }
        public int ShowAnimation { get; set; }

        public bool IssueAlarmEnabled { get; set; } = true;
        public bool IssuePriorityChanged { get; set; } = true;
        public bool IssueAdjuntoChanged { get; set; } = true;
        public bool IssueCommentChanged { get; set; } = true;

        public bool TempoAtEndDay { get; set; } = true;
        public bool TempoAtEndWeek { get; set; } = true;
        public bool TempoAtEndPeriod { get; set; } = true;
    }
}
