using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.DAL
{
    [DataContract]
    public class Pager
    {
        [DataMember]
        public int PageNum { get; set; }
        [DataMember]
        public int PageSize { get; set; }

        public Pager() { }
        public Pager(int pageNum, int pageSize)
        {
            SetInfo(pageNum, pageSize);
        }

        public Pager SetInfo(int pageNum, int pageSize)
        {
            this.PageNum = pageNum;
            this.PageSize = PageSize;
            return this;
        }

        public bool IsValid()
        {
            return this.PageNum > 0 && this.PageSize > 0;
        }
    }

    [DataContract]
    public abstract class PagerResult
    {
        [DataMember]
        public int PageNum { get; set; }
        [DataMember]
        public int PageSize { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
        
        public PagerResult SetInfo(int pageNum, int pageSize, int totalCount)
        {
            this.PageNum = pageNum;
            this.PageSize = PageSize;
            this.TotalCount = totalCount;
            return this;
        }
    }

    [DataContract]
    public class PagerResult<T> : PagerResult
    {
        [DataMember]
        public IEnumerable<T> Data { get; set; }

        public PagerResult() { }
        public PagerResult(IEnumerable<T> data)
        {
            this.Data = data;
        }

        public new PagerResult<T> SetInfo(int pageNum, int pageSize, int totalCount)
        {
            base.SetInfo(pageNum, pageSize, totalCount);

            return this;
        }
    }
}
