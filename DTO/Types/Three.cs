using System.Collections.Generic;
using System.Linq;

namespace YerbaSoft.DTO.Types
{
    public class ThreeList<T1, T2, T3> : List<Three<T1, T2, T3>>
    {
        public void Add(T1 v1, T2 v2, T3 v3)
        {
            base.Add(new Three<T1, T2, T3>(v1, v2, v3));
        }

        public void RemoveRange(IEnumerable<Three<T1, T2, T3>> elements)
        {
            var delete = elements.ToArray();
            foreach (var del in delete)
                this.Remove(del);
        }
    }

    public class Three<T1, T2, T3>
    {
        public T1 V1 { get; set; }
        public T2 V2 { get; set; }
        public T3 V3 { get; set; }

        public Three() { }
        public Three(T1 v1, T2 v2, T3 v3)
        {
            this.V1 = v1;
            this.V2 = v2;
            this.V3 = v3;
        }
    }
}
