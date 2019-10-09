using CSWork.DTO.WorkDatas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO
{
    public class WorkData
    {
        public List<Issue> Issues { get; set; } = new List<Issue>();
    }
}
