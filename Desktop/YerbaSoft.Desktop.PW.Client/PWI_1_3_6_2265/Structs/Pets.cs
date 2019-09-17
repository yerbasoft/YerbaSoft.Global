using System.Runtime.InteropServices;

namespace YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs
{
    public enum PetHungerStates
    {
        Full = 0,
        Satisfied = 1,
        Peckish = 2,
        Hungry0 = 3,
        Hungry1 = 4,
        Starving = 5
    }

    public enum PetModes
    {
        Defend = 0,
        Auto = 1,
        Manual = 2
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x3C, Pack = 1, CharSet = CharSet.Unicode)]
    public struct PetObj
    {
        [FieldOffset(0x04)] public uint Loyalty;
        [FieldOffset(0x08)] public uint Hunger;
        [FieldOffset(0x20)] public uint Level;
        [FieldOffset(0x28)] public uint XP;
        [FieldOffset(0x34)] public uint pName;
        [FieldOffset(0x38)] public uint HP;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x44, Pack = 1, CharSet = CharSet.Unicode)]
    public struct PetListHeader
    {
        [FieldOffset(0x08)] public uint CurrentPet;     // 0xFFFFFFFF: ninguno || 0 a 9 con el índice
        [FieldOffset(0x0C)] public uint PetBagSize;     // cantidad de pets disponibles
        [FieldOffset(0x10)] public uint pPet1;
        [FieldOffset(0x14)] public uint pPet2;
        [FieldOffset(0x18)] public uint pPet3;
        [FieldOffset(0x1C)] public uint pPet4;
        [FieldOffset(0x20)] public uint pPet5;
        [FieldOffset(0x24)] public uint pPet6;
        [FieldOffset(0x28)] public uint pPet7;
        [FieldOffset(0x2C)] public uint pPet8;
        [FieldOffset(0x30)] public uint pPet9;
        [FieldOffset(0x34)] public uint pPet10;
        [FieldOffset(0x38)] public uint CurrentPetId;
        [FieldOffset(0x40)] public uint PetMode;
    }
}
