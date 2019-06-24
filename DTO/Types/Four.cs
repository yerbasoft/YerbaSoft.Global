using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.DTO.Types
{
    public class FourList<T1, T2, T3, T4> : List<Four<T1, T2, T3, T4>>
    {
        public void Add(T1 v1, T2 v2, T3 v3, T4 v4)
        {
            base.Add(new Four<T1, T2, T3, T4>(v1, v2, v3, v4));
        }

        public void RemoveRange(IEnumerable<Four<T1, T2, T3, T4>> elements)
        {
            var delete = elements.ToArray();
            foreach (var del in delete)
                this.Remove(del);
        }
    }

    public class Four<T1, T2, T3, T4>
    {
        public T1 V1 { get; set; }
        public T2 V2 { get; set; }
        public T3 V3 { get; set; }
        public T4 V4 { get; set; }

        public Four() { }
        public Four(T1 v1, T2 v2, T3 v3, T4 v4)
        {
            this.V1 = v1;
            this.V2 = v2;
            this.V3 = v3;
            this.V4 = v4;
        }
    }
}
