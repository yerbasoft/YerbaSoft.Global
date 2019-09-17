using System.Collections.Generic;
using System.Linq;

namespace YerbaSoft.DAL
{
    public class OrderBy
    {
        private Dictionary<string, bool> Orders { get; set; } = new Dictionary<string, bool>();

        public OrderBy() { }
        public OrderBy(string sqlOrderByFormat)
        {
            this.Orders = sqlOrderByFormat.Split(',').Select(p => p.Trim()).ToDictionary(k => k.Split(' ')[0].Trim(), v => v.Split(' ')[1].ToUpper() == "ASC");
        }
        public OrderBy(Dictionary<string, bool> orders)
        {
            this.Orders = orders;
        }

        public OrderBy Add(string field, bool isAscendent)
        {
            this.Orders.Add(field, isAscendent);

            return this;
        }

        public OrderBy Remove(string field)
        {
            if (this.Orders.ContainsKey(field))
                this.Orders.Remove(field);

            return this;
        }

        public OrderBy Remove(int index)
        {
            if (this.Orders.Count >= index)
                this.Orders.Remove(this.Orders.Keys.ToArray()[index]);

            return this;
        }

        internal IQueryable<T> Apply<T>(IQueryable<T> exec)
        {
            IOrderedQueryable<T> result = null;

            for (var i = 0; i < this.Orders.Count; i++)
            {
                var field = this.Orders.Keys.ToArray()[i];
                var asc = this.Orders[field];

                if (i == 0)
                    result = exec.SortBy(field, asc);
                else
                    result = result.ThenBy(field, asc);
            }

            return result != null ? result : exec;
        }
    }
}
