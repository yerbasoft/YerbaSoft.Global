using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Dynamic.Exceptions
{
    public class CompileExceptionParams : System.Collections.IDictionary
    {
        private Dictionary<string, object> Data;

        public CompileExceptionParams(Dictionary<string, object> parms)
        {
            this.Data = parms;
        }
        
        #region System.Collections.IDictionary

        public void Add(object key, object value)
        {
            Data.Add((key ?? "").ToString(), value);
        }

        public void Clear()
        {
            Data.Clear();
        }

        public bool Contains(object key)
        {
            return Data.ContainsKey((key ?? "").ToString());
        }

        public System.Collections.IDictionaryEnumerator GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public System.Collections.ICollection Keys
        {
            get { return Data.Keys; }
        }

        public void Remove(object key)
        {
            Data.Remove((key ?? "").ToString());
        }

        public System.Collections.ICollection Values
        {
            get { return Data.Values; }
        }

        public object this[object key]
        {
            get
            {
                return Data[(key ?? "").ToString()];
            }
            set
            {
                Data[(key ?? "").ToString()] = value;
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return Data.Count; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return null; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        #endregion
    }
}
