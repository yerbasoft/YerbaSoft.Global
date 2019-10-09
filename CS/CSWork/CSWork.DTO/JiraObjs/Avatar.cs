using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.JiraObjs
{
    public class Avatar : Base.IJiraObject
    {
        [Newtonsoft.Json.JsonProperty("48x48")]
        public string s48x48 { get; set; }

        [Newtonsoft.Json.JsonProperty("24x24")]
        public string s24x24 { get; set; }

        [Newtonsoft.Json.JsonProperty("16x16")]
        public string s16x16 { get; set; }

        [Newtonsoft.Json.JsonProperty("32x32")]
        public string s32x32 { get; set; }
    }
}
