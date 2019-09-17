using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerbaSoft.Desktop.PW.BLL.Mem.Items;

namespace YerbaSoft.Desktop.PW.Forms
{
    public partial class ShowInfoForm : PopUpForm
    {
        protected override string Title => "Show Info";

        private BLL.PWClient Client;


        public ShowInfoForm(ClientForm parent, BLL.PWClient client) : base(parent, new PopUpCoords(client.dbConfig.ShowInfo.WinPinned, client.dbConfig.ShowInfo.WinShowAttachParent, client.dbConfig.ShowInfo.ScreenX, client.dbConfig.ShowInfo.ScreenY))
        {
            InitializeComponent();
            this.timer1.Enabled = false;
            this.Client = client;

            this.VisibleChanged += (sender, e) => { timer1.Enabled = this.Visible; };
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var pj = this.Client.Mem.Link.PJInfo.Data;
                this.lPJInfoOffset.Text = $"PJInfo: {this.Client.Mem?.Base1?.BasePointer:X} => {this.Client.Mem?.Base1?.PJInfo?.BasePointer:X}";
                this.lPJInfoTargetId.Text = $"TargetId: {this.Client.Mem.Link.PJInfo.Data.TargetId} (Mouse: {this.Client.Mem.Link.PJInfo.Data.TargetIdOnMouse}) (Pj: {pj.Id})";

                this.lCoordPJ.Text = $"Player: {pj.Coords.X} / {pj.Coords.Y} / {pj.Coords.Z}";
                this.lCoordCam.Text = $"Camara: {pj.CamCoords.X} / {pj.CamCoords.Y} / {pj.CamCoords.Z}";

                this.lGUILast.Text = $"Last          : {string.Join(" => ", this.Client.Mem?.Link?.GetGUIPointers(BLL.Mem.Basic.GUIObj.GUIs.LastCmdSend)?.Select(p => p.ToString("X")))}";
                this.lGUIFocus.Text = $"Focus         : {string.Join(" => ", this.Client.Mem?.Link?.GetGUIPointers(BLL.Mem.Basic.GUIObj.GUIs.Focus)?.Select(p => p.ToString("X")))}";
                this.lWinTakeQuest.Text = $"Win Take Quest: {string.Join(" => ", this.Client.Mem?.Link?.GetGUIPointers(BLL.Mem.Basic.GUIObj.GUIs.WinTakeQuest)?.Select(p => p.ToString("X")))}";

                this.lItemInventario.Text = $"Inventory: {string.Join(" => ", this.Client.Mem.Link.InventorySlots.GetPointerMap().Select(p => p.ToString("X")))}";
                this.lNPCOffset.Text = $"Offset: {string.Join(" => ", this.Client.Mem.Link.NPC.GetPointerMap().Select(p => p.ToString("X")))}";
                var currNPC = this.Client.Mem.Link.NPC.GetAll().SingleOrDefault(p => p.Data.Id == this.Client.Mem.Link.PJInfo.Data.TargetId);
                this.lNPCTarget.Text = $"Target: {currNPC.BasePointer.ToString("X")}";
            }
            catch { }
        }
    }
}
