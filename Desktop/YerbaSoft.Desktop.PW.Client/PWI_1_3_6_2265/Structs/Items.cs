using System.Runtime.InteropServices;

namespace YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs
{
    [StructLayout(LayoutKind.Explicit, Size = 0x3C, Pack = 1, CharSet = CharSet.Unicode)]
    public struct WorldItemObj
    {
        [FieldOffset(0x14)] public uint Amount;
        [FieldOffset(0x18)] public uint MaxAmount;
        [FieldOffset(0x1c)] public uint Price;

        [FieldOffset(0x10c)] public uint Id;

        [FieldOffset(0x164)] public uint pName;
    }


    [StructLayout(LayoutKind.Explicit, Size = 0x0C, Pack = 1, CharSet = CharSet.Unicode)]
    public struct WorldObjListEntry
    {
        [FieldOffset(0x00)] public uint pNext;  // puntero a otra estructura WorldObjListEntry (Listas/arboles/grafos)
        [FieldOffset(0x04)] public uint pObj;   // puntero al objeto en sí
        [FieldOffset(0x08)] public uint Id;     // Id del objeto
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28, Pack = 1, CharSet = CharSet.Unicode)]
    public struct WorldObjListHeader
    {
        [FieldOffset(0x14)] public uint Objects;                // number of (valid) list entries (they are scattered over the entire list); invalid list entries == 0
        [FieldOffset(0x18)] public uint ppListEntry;            // ¿puntero de punteros? comment: pointer to sequential list of WORLDOBJLISTENTRYs
        [FieldOffset(0x1c)] public uint pEndOfList;             // either end of list or pointer to another structure
        [FieldOffset(0x20)] public uint ListEntrySize;          // the size of the list in number of entries
        [FieldOffset(0x24)] public uint IdEntryConversion;      // Id / dwIdEntryConversion = List Entry to start
    }


    [StructLayout(LayoutKind.Explicit, Size = 0x28, Pack = 1, CharSet = CharSet.Unicode)]
    public struct WorldObjDB
    {
        [FieldOffset(0x20)] public uint pPlayerList;        // puntero a WorldObjListHeader
        [FieldOffset(0x24)] public uint pMobList;           // puntero a WorldObjListHeader
        [FieldOffset(0x28)] public uint pItemList;          // puntero a WorldObjListHeader
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x110 + 0x54 + 0x4, Pack = 1, CharSet = CharSet.Unicode)]
    public struct InvItemObj
    {
        [FieldOffset(0x14)] public uint Amount;
        [FieldOffset(0x18)] public uint MaxAmount;
        [FieldOffset(0x1c)] public uint Price;

        [FieldOffset(0x50)] public uint pName;          // ¿¿puntero o texto?? (revisar porque ocupa mucho lugar aparente)
        //[FieldOffset(0x50)] [MarshalAs(UnmanagedType.HString, SizeConst = 20)] public char[] Name;

        [FieldOffset(0x10c)] public uint Id;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x14, Pack = 1, CharSet = CharSet.Unicode)]
    public struct InvObjListHeader
    {
        [FieldOffset(0x0C)] public uint ppItems;        // ¿puntero de punteros?    comment: pointer to sequential list of pointers to inv item objects
        [FieldOffset(0x10)] public uint TotalSlots;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x14, Pack = 1, CharSet = CharSet.Unicode)]
    public struct InvObjDB
    {
        [FieldOffset(0x34)] public uint pInveItemList;              // comment: list id: 0    inventory items
        [FieldOffset(0x38)] public uint pNormalEquipItemList;
        [FieldOffset(0x3C)] public uint pList2;

        [FieldOffset(0xc70)] public uint pList3;
        [FieldOffset(0xc74)] public uint pList4;
        [FieldOffset(0xc78)] public uint pList5;
        [FieldOffset(0xc7c)] public uint pList6;
    }


    [StructLayout(LayoutKind.Explicit, Size = 0x04, Pack = 1, CharSet = CharSet.Unicode)]
    public struct ObjDBBase0
    {
        [FieldOffset(0x00)] public uint pObjDBBase1;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x24, Pack = 1, CharSet = CharSet.Unicode)]
    public struct ObjDBBase1
    {
        [FieldOffset(0x1c)] public uint pObjDBBase2;    // (struct ObjDBBase1) lista de lista ?? (como el Next de las listas?)
        [FieldOffset(0x20)] public uint pObjDBBase3;    // (void?) (será ObjDBBase2??)
    }

    [StructLayout(LayoutKind.Explicit, /*Size = 0x24?,*/ Pack = 1, CharSet = CharSet.Unicode)]
    public struct ObjDBBase2
    {
        [FieldOffset(0x08)] public uint pWorldObjDB;

        [FieldOffset(0x20)] public uint pInvItemDB;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xD00, Pack = 1, CharSet = CharSet.Unicode)]
    public struct InventarioContainer
    {
        [FieldOffset(0x388)] public uint pNPCs;

        [FieldOffset(0xC34)] public uint pInventarioSlots;
        [FieldOffset(0xC38)] public uint pInventarioSet;
        [FieldOffset(0xC3C)] public uint pInventarioQuestSlots;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x14, Pack = 1, CharSet = CharSet.Unicode)]
    public struct Inventario
    {
        [FieldOffset(0x0C)] public uint pInventarioItemArray;   //array de punteros
        [FieldOffset(0x10)] public uint Cantidad;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x4 * 100, Pack = 1, CharSet = CharSet.Unicode)]
    public struct InventarioItemArray
    {
        [FieldOffset(0x00)] public uint pInvObj_1;
        [FieldOffset(0x04)] public uint pInvObj_2;
        [FieldOffset(0x08)] public uint pInvObj_3;
        [FieldOffset(0x0C)] public uint pInvObj_4;
        [FieldOffset(0x10)] public uint pInvObj_5;
        [FieldOffset(0x14)] public uint pInvObj_6;
        [FieldOffset(0x18)] public uint pInvObj_7;
        [FieldOffset(0x1C)] public uint pInvObj_8;
        [FieldOffset(0x20)] public uint pInvObj_9;
        [FieldOffset(0x24)] public uint pInvObj_10;
        [FieldOffset(0x28)] public uint pInvObj_11;
        [FieldOffset(0x2C)] public uint pInvObj_12;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58, Pack = 1, CharSet = CharSet.Unicode)]
    public struct InventarioItem
    {
        [FieldOffset(0x00)] public ulong uk0;
        [FieldOffset(0x08)] public uint dbCode;
        [FieldOffset(0x10)] public uint Cantidad;
        [FieldOffset(0x14)] public uint MaxStack;
        [FieldOffset(0x1C)] public uint Precio;
        [FieldOffset(0x40)] public uint pTextoDescriptivo;

        [FieldOffset(0x18)] public uint uk18;
        [FieldOffset(0x20)] public uint uk20;
        [FieldOffset(0x24)] public uint uk24;
        [FieldOffset(0x28)] public uint uk28;
        [FieldOffset(0x2C)] public uint uk2C;
        [FieldOffset(0x30)] public uint uk30;
        [FieldOffset(0x34)] public uint uk34;
        [FieldOffset(0x38)] public uint uk38;
        [FieldOffset(0x3C)] public uint uk3C;
        [FieldOffset(0x44)] public uint uk44;
        [FieldOffset(0x48)] public uint uk48;
        [FieldOffset(0x50)] public uint uk50;
        [FieldOffset(0x54)] public uint uk54;
    }
}
