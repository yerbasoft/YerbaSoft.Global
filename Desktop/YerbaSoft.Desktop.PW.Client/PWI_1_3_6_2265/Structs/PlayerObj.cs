using System.Runtime.InteropServices;

namespace YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs
{
    [StructLayout(LayoutKind.Explicit, Size = 0xE64, Pack = 1, CharSet = CharSet.Unicode)]
    public struct PlayerObj
    {
        [FieldOffset(0x0C)] public float PlayerAngle0;

        [FieldOffset(0x14)] public float PlayerAngle1;

        [FieldOffset(0x3C)] public Point3D Pos;
        [FieldOffset(0x7C)] public Point3D Pos2;

        [FieldOffset(0x458)] public uint Id;

        [FieldOffset(0x464)] public uint Level;

        [FieldOffset(0x46C)] public uint CurrHP;
        [FieldOffset(0x470)] public uint CurrMP;
        [FieldOffset(0x474)] public uint XP;
        [FieldOffset(0x478)] public uint Spirit;
        [FieldOffset(0x47C)] public uint AvailablePoints;
        [FieldOffset(0x480)] public uint Chi;

        [FieldOffset(0x494)] public uint Con;
        [FieldOffset(0x498)] public uint Int;
        [FieldOffset(0x49C)] public uint Str;
        [FieldOffset(0x4A0)] public uint Agi;
        [FieldOffset(0x4A4)] public uint MaxHP;
        [FieldOffset(0x4A8)] public uint MaxMP;

        [FieldOffset(0x4B8)] public float Speed;

        [FieldOffset(0x4c4)] public uint Accuracy;
        [FieldOffset(0x4c8)] public uint MinPhysAtk;
        [FieldOffset(0x4cc)] public uint MaxPhysAtk;

        [FieldOffset(0x508)] public uint MetalRes;
        [FieldOffset(0x50c)] public uint WoodRes;
        [FieldOffset(0x510)] public uint WaterRes;
        [FieldOffset(0x514)] public uint FireRes;
        [FieldOffset(0x518)] public uint EarthRes;
        [FieldOffset(0x51c)] public uint PhysDef;
        [FieldOffset(0x520)] public uint Evasion;

        [FieldOffset(0x528)] public uint Money;

        [FieldOffset(0x590)] public uint Reputation;
        [FieldOffset(0x594)] public uint TransformState;       //0: human; 1: fox

        [FieldOffset(0x608)] public uint NamePointer;

        [FieldOffset(0x610)] public uint ClassId;
        [FieldOffset(0x614)] public uint Gender;

        [FieldOffset(0x61c)] public uint TransportMode;        //0: ground; 1: swim; 2: fly

        [FieldOffset(0x638)] public Point3D Coords;
        [FieldOffset(0x650)] public Point3D Pos3;
        [FieldOffset(0x65C)] public Point3D Pos4;

        [FieldOffset(0x67c)] public uint Aggro;                // bool

        [FieldOffset(0x6C4)] public uint CastId;

        /* 0x760 a 0x7D8 son datos de la camara */
        [FieldOffset(0x790)] public Point3D CamCoords;
        [FieldOffset(0x7D0)] public Point3D CamCoords2;         // son siempre iguales a 0x790

        [FieldOffset(0x834)] public float CamAngleY;        //     -90 (arriba) a 90 (abajo) - editable
        [FieldOffset(0x83C)] public float CamAngleXZ;        //     0 a 360 - editable
        [FieldOffset(0x844)] public float CamDist;        //     0 a 20 - editable

        [FieldOffset(0x8C0)] public Point3D Pos5;
        [FieldOffset(0x8D4)] public Point3D Pos6;
        [FieldOffset(0x8E4)] public Point3D Pos7;

        [FieldOffset(0x904)] public uint MouseStatus;        //     0 nada, 2 - MouseRDown (NO editable)
        [FieldOffset(0x908)] public uint KeyboardStatus;        //  (NO editable) 1-W, 2-D, 4-S, 8-A, 16-Space/Up(subir), 32-Down(bajar)

        [FieldOffset(0xaf0)] public uint TargetId;
        [FieldOffset(0xaf4)] public uint TmpTargetId;
        [FieldOffset(0xaf8)] public uint PickingItem;           // se marca mientras corro a agarrarlo (pero no se desmarca y cancelo)

        [FieldOffset(0xB00)] public uint TargetIdWithTalking;

        [FieldOffset(0xB08)] public uint TargetIdOnMouse;       // incluye PJ/NPC/MOV y mats del piso (piedras y oro)
        [FieldOffset(0xB0C)] public uint MovimientoBloqueado;   // 1 - bloqueado, 0 - se puede mover (editable)

        [FieldOffset(0xB50)] public Point3D Pos8;

        [FieldOffset(0xbec)] public uint JumpState;            // 0, 1, 2

        [FieldOffset(0xe48)] public uint pActionBase0;

        [FieldOffset(0xe60)] public uint pPetList;
    }
}

/*
 * 
            [FieldOffset(0x4A4)]
            public uint MaxHP;
            [FieldOffset(0x4A4-56)]
            public uint CurrentHP;
            [FieldOffset(0x4A4+4)]
            public uint MaxMP;
            [FieldOffset(0x4A4-52)]
            public uint CurrentMP;

            // Stats
            [FieldOffset(0x4A4 + 36)]
            public uint PAtkMin;
            [FieldOffset(0x4A4 + 40)]
            public uint PAtkMax;
            [FieldOffset(0x4A4 + 44)]   // a confirmar
            public uint MAtkMin;
            [FieldOffset(0x4A4 + 48)]   // a confirmar
            public uint MAtkMax;
            [FieldOffset(0x4A4 + 32)]
            public uint Accuracy;
            [FieldOffset(0x4A4 + 124)]
            public uint Dodge;
            [FieldOffset(0x4A4 + 120)]
            public uint PDef;
            [FieldOffset(0x4A4 + 100)]
            public uint MDefMetal;
            [FieldOffset(0x4A4 + 104)]
            public uint MDefWood;
            [FieldOffset(0x4A4 + 108)]
            public uint MDefWater;
            [FieldOffset(0x4A4 + 112)]
            public uint MDefFire;
            [FieldOffset(0x4A4 + 116)]
            public uint MDefEarth;

            // Puntos
            [FieldOffset(0x4A4 - 40)]
            public uint PuntosDisponibles;
            [FieldOffset(0x4A4 - 8)]
            public uint PuntosSTR;
            [FieldOffset(0x4A4 - 4)]
            public uint PuntosAGI;
            [FieldOffset(0x4A4 - 16)]
            public uint PuntosVIT;
            [FieldOffset(0x4A4 - 12)]
            public uint PuntosMAG;
                       
            [FieldOffset(0x4A4+132)]
            public uint InventoryGold;

            [FieldOffset(0x4A4+1864)]
            public uint FlagSalto;

            [FieldOffset(0x61C)]
            public uint FlagFly;

            [FieldOffset(0xAF0)]
            public uint TargetId;
            [FieldOffset(0x6C4)]
            public uint CastId;

            [FieldOffset(0x790)]
            public float CamX;
            [FieldOffset(0x794)]
            public float CamZ;
            [FieldOffset(0x798)]
            public float CamY;




    [FieldOffset(0x654)]
            public float Zdown;
            [FieldOffset(0x660)]
            public float Zup;
            [FieldOffset(0x650)]
            public float Xwest;
            [FieldOffset(0x65C)]
            public float Xeast;
            [FieldOffset(0x658)]
            public float Ynorte;
            [FieldOffset(0x664)]
            public float Ysur;
 * */
