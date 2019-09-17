using System.Runtime.InteropServices;

namespace YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs
{
    [StructLayout(LayoutKind.Explicit, Size = 0x0C, Pack = 1, CharSet = CharSet.Unicode)]
    public struct Point3D
    {
        [FieldOffset(0x00)] public float X;
        [FieldOffset(0x04)] public float Y;
        [FieldOffset(0x08)] public float Z;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x30, Pack = 1, CharSet = CharSet.Unicode)]
    public struct Base0
    {
        [FieldOffset(0x00)] public uint pBase1;
        [FieldOffset(0x04)] public uint uk04;
        [FieldOffset(0x0C)] public uint uk0c;
        [FieldOffset(0x20)] public uint pInventarioContainer;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x24, Pack = 1, CharSet = CharSet.Unicode)]
    public struct Base1
    {
        [FieldOffset(0x04)] public uint pGUIBase0;
        [FieldOffset(0x08)] public uint pDataContainer;

        [FieldOffset(0x20)] public uint pPlayerObj;    // Current PJ
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10, Pack = 1, CharSet = CharSet.Unicode)]
    public struct StrNames
    {
        [FieldOffset(0x0)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)] public char[] Text;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Unicode)]
    public struct DataContainer
    {
        [FieldOffset(0x24)] public uint pNPCHeader;
    }

}
