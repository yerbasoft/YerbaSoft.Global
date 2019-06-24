using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.DTO.Types
{
    public class FiveList<T1, T2, T3, T4, T5> : List<Five<T1, T2, T3, T4, T5>>
    {
        public void Add(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5)
        {
            base.Add(new Five<T1, T2, T3, T4, T5>(v1, v2, v3, v4, v5));
        }

        public void RemoveRange(IEnumerable<Five<T1, T2, T3, T4, T5>> elements)
        {
            var delete = elements.ToArray();
            foreach (var del in delete)
                this.Remove(del);
        }
    }

    public class Five<T1, T2, T3, T4, T5>
    {
        public T1 V1 { get; set; }
        public T2 V2 { get; set; }
        public T3 V3 { get; set; }
        public T4 V4 { get; set; }
        public T5 V5 { get; set; }

        public Five() { }
        public Five(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5)
        {
            this.V1 = v1;
            this.V2 = v2;
            this.V3 = v3;
            this.V4 = v4;
            this.V5 = v5;
        }
    }
}
