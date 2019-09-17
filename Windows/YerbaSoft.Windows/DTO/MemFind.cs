using System.Collections.Generic;
using System.Linq;

namespace YerbaSoft.Windows.DTO
{
    public class MemFindInt
    {
        /// <summary>
        /// Valor que se está buscando
        /// </summary>
        public uint Value { get; private set; }

        /// <summary>
        /// Al momento de buscar, agregar un offset
        /// </summary>
        public int offset { get; private set; }

        public MemFindInt(uint value) : this(value, 0) { }
        public MemFindInt(uint value, int offset)
        {
            this.Value = value;
            this.offset = offset / 4;
        }
    }

    public class MemFindComplex : List<MemFindInt>
    {
        public string Name { get; set; }
        public int MaxSize => this.Max(p => p.offset);

        public MemFindComplex(string name) { }
        public MemFindComplex(string name, uint value, int offset) : this(name, new MemFindInt(value, offset)) { }
        public MemFindComplex(string name, MemFindInt find) : this(name, new MemFindInt[] { find }) { }
        public MemFindComplex(string name, IEnumerable<MemFindInt> list)
        {
            this.Name = name;
            this.AddRange(list);
        }

        internal List<int> FindIn(uint[] buffer, uint len)
        {
            var res = new List<int>();
            for (var i = 0; i < len - MaxSize; i++)
            {
                if (this.All(p => buffer[i + p.offset] == p.Value))
                    res.Add(i);
            }
            return res;
        }
    }

}
