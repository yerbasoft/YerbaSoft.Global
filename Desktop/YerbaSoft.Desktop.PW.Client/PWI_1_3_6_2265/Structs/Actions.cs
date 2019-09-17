using System.Runtime.InteropServices;

namespace YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs
{
    public enum ActionsStates
    {
        None = 0,
        Move = 1,
        MoveIntoRange = 2,
        Attack = 3,
        Cast = 4,
        Meditate = 0x0A,
        Gather = 0x0B,
    }


    [StructLayout(LayoutKind.Explicit, Size = 0x30, Pack = 1, CharSet = CharSet.Unicode)]
    public struct ActionObjMoveTo
    {
        [FieldOffset(0x20)] public float X;
        [FieldOffset(0x24)] public float Z;
        [FieldOffset(0x28)] public float Y;
        [FieldOffset(0x2C)] public uint Action;                       // 0: move
    }


    [StructLayout(LayoutKind.Explicit, Size = 0x14, Pack = 1, CharSet = CharSet.Unicode)]
    public struct DoActionParam
    {
        [FieldOffset(0x0C)] public float p;
        [FieldOffset(0x10)] public uint Action;
    }


    [StructLayout(LayoutKind.Explicit, Size = 0x1C, Pack = 1, CharSet = CharSet.Unicode)]
    public struct ActionBase0
    {
        [FieldOffset(0x04)] public uint pObj;   // pointer to player object (if mobs have this too, it would probably be pointer to mob object ;) )
        [FieldOffset(0x14)] public uint pActionBase1;   // dynamically changed for every action (=> current action base)
        [FieldOffset(0x18)] public uint PerformingAction;   // (bool) careful with this one, if you cast a spell and are out of range
                                                            // it will be set to 1 when walking, set to 0 when stop walking, then
                                                            // the attack command is sent to the server and when confirmation is
                                                            // received, it will be set back to 1 for casting (same for attacking)
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x1C, Pack = 1, CharSet = CharSet.Unicode)]
    public struct ActionBase1
    {
        /// <summary>
        /// AS_ constants
        /// </summary>
        [FieldOffset(0x04)] public uint ActionState;
    }

}
