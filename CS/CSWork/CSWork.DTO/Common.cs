using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork
{
    public delegate void Event();
    public delegate void Event<T>(T e);
    public delegate void Event<T1, T2>(T1 e1, T2 e2);
    public delegate void Event<T1, T2, T3>(T1 e1, T2 e2, T3 e3);

    public static class IExtensions
    {
    }
}
