using System.Runtime.InteropServices;

namespace YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs
{
    public enum MobTypes
    {
        Mob = 6,
        NPC = 7,
        Pet = 9
    }

    public enum MobEnchancedTypes
    {
        Normal = 0,
        MoveSpeedIncrease = 1,
        SayToYourself = 2,
        DefenseEnhanced = 3,
        MagicResistance = 4,
        AttackEnhanced = 5,
        MagicEnhanced = 6,
        LifeRiskingAttack = 7,
        HPEnhanced = 8,
        Weaken = 9,

        Empty = 10,

        PhysicalImmune = 11,
        MetalImmune = 12,
        WoodImmune = 13,
        WaterImmune = 14,
        FireImmune = 15,
        EarthImmune = 16,
        FiveElementImmune = 17,
        IgnoreInjury = 19
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x3C, Pack = 1, CharSet = CharSet.Unicode)]
    public struct MobObj
    {
        [FieldOffset(0x0C)] public float Angle0;

        [FieldOffset(0x14)] public float Angle1;

        [FieldOffset(0x3c)] public Point3D Pos;

        [FieldOffset(0xb4)] public uint Type;   // 9: pet; 7: npc; 6: monster (check MOBTYPE_ constants)

        [FieldOffset(0x11c)] public uint Id;

        [FieldOffset(0x124)] public uint Level;

        [FieldOffset(0x12c)] public uint CurrHP;

        [FieldOffset(0x15c)] public uint MaxHP;


        [FieldOffset(0x238)] public uint OwnerId;   // 0: no owner; else pet owner id
        [FieldOffset(0x23C)] public uint pName;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Unicode)]
    public struct NPCHeader
    {
        [FieldOffset(0x4C)] public NPCHeaderList HeaderList;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10, Pack = 1, CharSet = CharSet.Unicode)]
    public struct NPCHeaderList
    {
        [FieldOffset(0x00)] public uint uk0;
        [FieldOffset(0x04)] public uint pNPCArray;
        [FieldOffset(0x08)] public uint Cantidad;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Unicode)]
    public struct NPCObj
    {
        [FieldOffset(0x3C)] public Point3D Coord;
        [FieldOffset(0xB4)] public uint Tipo;       // 9:PET / 7:NPC / 6:MOB

        [FieldOffset(0x11C)] public uint Id;

        [FieldOffset(0x120)] public uint dbCode;
        [FieldOffset(0x124)] public uint Level;     // noconfirmado (NPC tienen lvl 60?)-

        [FieldOffset(0x12C)] public uint CurrHP;
        [FieldOffset(0x164)] public uint MaxHP;

        [FieldOffset(0x208)] public Point3D CoordBottom;
        [FieldOffset(0x214)] public Point3D CoordHead;

        /// <summary>
        /// Type: MobEnchancedTypes // "Buff" del mob, HP, def, etc. (verificado solo por tonja)
        /// </summary>
        [FieldOffset(0x23C)] public uint EnchancedType; // Type: MobEnchancedTypes

        [FieldOffset(0x248)] public uint OwnerId;    // id del dueño del PET
        [FieldOffset(0x24C)] public uint pName;

        [FieldOffset(0x274)] public float DistAlPJ;     //solo distancia X-Z (no incluye distancia con la altura)

        [FieldOffset(0x2C0)] public uint Status;        // 1:quieto / 4:caminando(fuera de combate) / 5:Atacando(basicos) / 6:Atacando(Casteando) / 7:PersiguiendoUnObjetivo

        [FieldOffset(0x2D4)] public uint TargetId;
    }
}
