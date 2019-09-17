using System.Runtime.InteropServices;

namespace YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs
{
    public enum GUIBase1Ids
    {
        ShortCutFs = 9305996,
        WinSkills = 9308372
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x0C /* len confirmado*/, Pack = 1, CharSet = CharSet.Unicode)]
    public struct GUIBase0
    {
        [FieldOffset(0x08)] public uint pGUIBase1;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x350, Pack = 1, CharSet = CharSet.Unicode)]
    public struct GUIBase1
    {
        [FieldOffset(0x0)] public uint id;

        [FieldOffset(0x18)] public uint pLastCmdSent;           // the gui obj that was sent the last cmd

        [FieldOffset(0xd4)] public uint pFocus;                 // the gui obj that the mouse is over (has the mouse focus)

        [FieldOffset(0xF4)] public uint pWinAction;

        [FieldOffset(0xFC)] public uint pWinParty;

        [FieldOffset(0x11C)] public uint pWinAutoPathing;

        [FieldOffset(0x1A0)] public uint pWinFashionPreview;

        [FieldOffset(0x124)] public uint pWinInventoryExtend;

        [FieldOffset(0x134)] public uint pWinPlayerStall;       // Ventana de compra a otro jugador (en gatito)

        [FieldOffset(0x13C)] public uint pWinChat;

        [FieldOffset(0x14C)] public uint pWinPJInfo;

        [FieldOffset(0x174)] public uint pWinShowOtherPJInfo;

        [FieldOffset(0x1B0)] public uint pWinFriend;

        [FieldOffset(0x204)] public uint pWinPJFace;                // ventana superior-izq con la cara del pj y la info principal

        [FieldOffset(0x210)] public uint pWinNotification;              // ventana de notificaciones [!]

        [FieldOffset(0x2A0)] public uint pWinPJOptions;              // boton derecho sobre otro pj (ventana de opciones)
        [FieldOffset(0x2A4)] public uint pWinMain;              // hago click para caminar y parece  qes ésta

        [FieldOffset(0x224)] public uint pWinInventary;

        [FieldOffset(0x23C)] public uint pWinPoints;

        [FieldOffset(0x270)] public uint pWinTakeQuest;

        [FieldOffset(0x27c)] public uint pPetBag;

        [FieldOffset(0x2A4)] public uint pNumsShortCuts;        // solo el vertical
        [FieldOffset(0x2A8)] public uint pFsShortCuts;          // solo el horizontal

        [FieldOffset(0x2B0)] public uint pPetSkill;
        [FieldOffset(0x2B4)] public uint pWinShop;
        [FieldOffset(0x2B8)] public uint pPetBar;

        [FieldOffset(0x300)] public uint pWinSkills;

        [FieldOffset(0x348)] public uint pMainBar;
        [FieldOffset(0x34C)] public uint pPublicRelationBar;
        [FieldOffset(0x350)] public uint pWinQuestList;
        [FieldOffset(0x354)] public uint pWinQuestListOnScreen;     // lista de quest flotante

        [FieldOffset(0x36C)] public uint pWinPartyInfo;
        [FieldOffset(0x370)] public uint pWinPartyInfoPJ1;
        [FieldOffset(0x374)] public uint pWinPartyInfoPJ2;
        [FieldOffset(0x378)] public uint pWinPartyInfoPJ3;
        [FieldOffset(0x37C)] public uint pWinPartyInfoPJ4;
        [FieldOffset(0x380)] public uint pWinPartyInfoPJ5;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x350, Pack = 1, CharSet = CharSet.Unicode)]
    public struct GUIObj
    {
        [FieldOffset(0x54)] public uint Left;
        [FieldOffset(0x58)] public uint Top;
        [FieldOffset(0x60)] public uint Status;         // 256 = quieto / 257 = moviendo (será de 2 bytes?)
        [FieldOffset(0x64)] public uint MouseDownX;
        [FieldOffset(0x68)] public uint MouseDownY;
        [FieldOffset(0x6C)] public ushort Open;         // editable y abre y cierra efectivamente
        [FieldOffset(0x70)] public uint Width;
        [FieldOffset(0x74)] public uint Height;

        [FieldOffset(0x16C)] public uint pGUIWinInfoAutoPath;
        [FieldOffset(0x148)] public uint pGUIWinTakeQuest_BaseQuest;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x350, Pack = 1, CharSet = CharSet.Unicode)]
    public struct GUIWinPartyInfoPJ // : GUIObj
    {
        [FieldOffset(0x54)] public uint Left;
        [FieldOffset(0x58)] public uint Top;

        [FieldOffset(0x9C)] public uint IdPJ;

        [FieldOffset(0x128)] public uint MemberStatus;     // ¿23 Lider / 22 miembro?
        [FieldOffset(0x130)] public uint MemberStatus2;     // ¿23 Lider / 22 miembro?

        public bool IsLider() => this.MemberStatus == 23;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x200, Pack = 1, CharSet = CharSet.Unicode)]
    public struct GUIWinInfoAutoPath
    {
        [FieldOffset(0x40)] public uint StopOnArrive;
    }

    //take quest
    [StructLayout(LayoutKind.Explicit, Size = 0x710, Pack = 1, CharSet = CharSet.Unicode)]
    public struct GUIWinTakeQuest_BaseQuest
    {
        [FieldOffset(0x8)] public uint pGUIWinTakeQuest_QuestListParent;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x710, Pack = 1, CharSet = CharSet.Unicode)]
    public struct GUIWinTakeQuest_QuestListParent
    {
        [FieldOffset(0xD4)] public uint pArrayGUIWinTakeQuest_QuestScreenItem;   // apunta a un array de GUIWinTakeQuest_QuestScreenItem[] (una estructura al lado de la otra)
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x98, Pack = 1, CharSet = CharSet.Unicode)]
    public struct GUIWinTakeQuest_QuestScreenItem // sin probar, es pposible que falte un barco 0x0
    {
        [FieldOffset(0x000)] public uint pQuest1Name; 
        [FieldOffset(0x098)] public uint pQuest2Name;
        [FieldOffset(0x130)] public uint pQuest3Name;
        [FieldOffset(0x1c8)] public uint pQuest4Name;
        [FieldOffset(0x260)] public uint pQuest5Name;
    }

}
