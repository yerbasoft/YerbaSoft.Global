using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSWork.DTO.Base
{
    public interface ILazyLoadable { }
    public interface ILazyLoadable<T, J> : ILazyLoadable 
        where T : ILazyLoadable
        where J : IJiraObject
    {
        event Event<T> OnCompleteLoad;
        bool IsCompleteLoad { get; }

        T SetLazyData(J data);
    }
}
