using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs
{
    [StructLayout(LayoutKind.Explicit, Size = 0x160, Pack = 1, CharSet = CharSet.Unicode)]
    public struct CoordPointsBase0
    {
        [FieldOffset(0x158)] public uint pCoordPointsBase1;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x160, Pack = 1, CharSet = CharSet.Unicode)]
    public struct CoordPointsBase1
    {
        [FieldOffset(0x570)] public uint pCoordPunto;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x160, Pack = 1, CharSet = CharSet.Unicode)]
    public struct CoordPointObj
    {
        [FieldOffset(0x0)] public uint uk0;     // parece que siempre es 0xFFFFFFFF
        [FieldOffset(0x4)] public uint pName;
        [FieldOffset(0x8)] public float X;
        [FieldOffset(0xC)] public float unknow_Y;
        [FieldOffset(0x10)] public float Z;
    }
}
