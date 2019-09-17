using System.Collections.Generic;
using System.Linq;

namespace YerbaSoft.DTO.Types
{
    public class TwoList<T1, T2> : List<Two<T1, T2>>
    {
        public TwoList() { }
        public TwoList(T1 v1, T2 v2)
        {
            this.Add(v1, v2);
        }
        public TwoList(Two<T1, T2> two)
        {
            this.Add(two);
        }
        public TwoList(IEnumerable<Two<T1, T2>> list)
        {
            this.AddRange(list);
        }

        public void RemoveRange(IEnumerable<Two<T1, T2>> elements)
        {
            var delete = elements.ToArray();
            foreach (var del in delete)
                this.Remove(del);
        }

        public TwoList<T1,T2> Add(T1 v1, T2 v2)
        {
            this.Add(new Two<T1, T2>(v1, v2));
            return this;
        }
    }

    public class Two<T1, T2>
    {
        public T1 V1 { get; set; }
        public T2 V2 { get; set; }

        public Two() { }
        public Two(T1 v1, T2 v2)
        {
            this.V1 = v1;
            this.V2 = v2;
        }
    }
}
