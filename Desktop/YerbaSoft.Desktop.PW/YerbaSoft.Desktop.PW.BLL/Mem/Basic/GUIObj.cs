using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;

namespace YerbaSoft.Desktop.PW.BLL.Mem.Basic
{
    public class GUIObj : IDisposable
    {
        public enum GUIs
        {
            Focus = 0xD4,
            LastCmdSend = 0x18,

            WinAction = 0xF4,
            WinInventoryExtend = 0x124,
            WinPlayerStall = 0x134,
            WinPJInfo = 0x14C,
            WinFriend = 0x1B0,
            WinPJFace = 0x204,
            WinMain = 0x2A4,
            WinInventary = 0x224,
            WinTakeQuest = 0x270,
            WinQuestList = 0x350,
            WinSkills = 0x300,
            WinShop = 0x2B4,
            WinParty = 0xFC,
            WinChat = 0x13C,
            WinPoints = 0x23C,
            WinAutoPathing = 0x11C,

            BtnNotification = 0x210,

            PetBag = 0x27c,
            NumsShortCuts = 0x2a4,
            FsShortCuts = 0x2a8,
            PetSkill = 0x2B0,
            PetBar = 0x2b8,
            MainBar = 0x348,
            PublicRelationBar = 0x34c,
        }

        private PWClient Client;
        public uint BasePointer { get; internal set; }

        public Client.PWI_1_3_6_2265.Structs.GUIObj Data { get; set; }

        public GUIObj(PWClient client, uint basePointer)
        {
            this.Client = client;
            this.BasePointer = basePointer;

            ReLoadData();
        }

        public void ReLoadData() => this.Data = this.Client.MemMgr.ReadStruct<Client.PWI_1_3_6_2265.Structs.GUIObj>(this.BasePointer);

        public void Show(bool show)
        {
            this.Client.MemMgr.Write(new IntPtr(this.BasePointer + 0x6C), (uint)(show ? 1 : 0));
        }

        public void SetCoord(uint x, uint y)
        {
            this.Client.MemMgr.Write(new IntPtr(this.BasePointer + 0x54), x);
            this.Client.MemMgr.Write(new IntPtr(this.BasePointer + 0x58), y);
        }

        public void Dispose()
        {
        }
    }
}
