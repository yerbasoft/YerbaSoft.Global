using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.DTO.Types
{
    public class TwoList<T1, T2> : List<Two<T1, T2>>
    {
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
