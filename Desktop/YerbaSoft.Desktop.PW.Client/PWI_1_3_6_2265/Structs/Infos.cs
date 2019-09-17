using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs
{
    [StructLayout(LayoutKind.Explicit, Size = 0x24, Pack = 1, CharSet = CharSet.Unicode)]
    public struct AutoPathInfo
    {
        [FieldOffset(0x0)] public uint uk0;
        [FieldOffset(0x40)] public uint CancelFly;  // booleano
    }
}
