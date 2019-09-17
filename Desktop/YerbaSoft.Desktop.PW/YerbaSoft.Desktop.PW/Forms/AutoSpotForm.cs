using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerbaSoft.Desktop.PW.BLL.Mem.NPCs;
using YerbaSoft.Desktop.PW.Properties;

namespace YerbaSoft.Desktop.PW.Forms
{
    public partial class AutoSpotForm : PopUpForm
    {
        protected override string Title => "Auto Spot";

        private BLL.PWClient Client { get; set; }

        private Helper.InputValues Values = new Helper.InputValues();
        private List<KeyValuePair<int, string>> NPCs;

        public AutoSpotForm() : base() { }
        public AutoSpotForm(ClientForm parent, BLL.PWClient client) : base(parent, new PopUpCoords(client.dbConfig.AutoSpot.WinPinned, client.dbConfig.AutoSpot.WinShowAttachParent, client.dbConfig.AutoSpot.ScreenX, client.dbConfig.AutoSpot.ScreenY))
        {
            InitializeComponent();
            this.Client = client;

            this.Activated += (sender, e) => { PAssistMobRefresh_Click(this.pAssistMobRefresh, null); };

            this.lBuffKey.MouseWheel += (sender, e) =>
            {
                this.Client.dbConfig.AutoSpot.BuffKey = e.Delta > 0 ? Values.GetAllKeyPost(this.Client.dbConfig.AutoSpot.BuffKey, true) : Values.GetAllKeyPrev(this.Client.dbConfig.AutoSpot.BuffKey, true);
                this.Client.dbConfig.PendingChanges = true;
                DoDrawControls();
            };
            this.lBuffExpire.MouseWheel += (sender, e) =>
            {
                this.Client.dbConfig.AutoSpot.BuffExpireTime = e.Delta > 0 ? Values.GetTimesPost(this.Client.dbConfig.AutoSpot.BuffExpireTime) : Values.GetTimesPrev(this.Client.dbConfig.AutoSpot.BuffExpireTime);
                this.Client.dbConfig.PendingChanges = true;
                DoDrawControls();
            };
            this.lBuffCast.MouseWheel += (sender, e) =>
            {
                this.Client.dbConfig.AutoSpot.BuffCastTime = e.Delta > 0 ? Values.GetTimesPost(this.Client.dbConfig.AutoSpot.BuffCastTime) : Values.GetTimesPrev(this.Client.dbConfig.AutoSpot.BuffCastTime);
                this.Client.dbConfig.PendingChanges = true;
                DoDrawControls();
            };
            this.lAssist.MouseWheel += (sender, e) =>
            {
                this.Client.dbConfig.AutoSpot.AssistKey = e.Delta > 0 ? Values.GetAllKeyPost(this.Client.dbConfig.AutoSpot.AssistKey, true) : Values.GetAllKeyPrev(this.Client.dbConfig.AutoSpot.AssistKey, true);
                this.Client.dbConfig.PendingChanges = true;
                DoDrawControls();
            };
            this.lPickKey.MouseWheel += (sender, e) =>
            {
                this.Client.dbConfig.AutoSpot.PickKey = e.Delta > 0 ? Values.GetAllKeyPost(this.Client.dbConfig.AutoSpot.PickKey, true) : Values.GetAllKeyPrev(this.Client.dbConfig.AutoSpot.PickKey, true);
                this.Client.dbConfig.PendingChanges = true;
                DoDrawControls();
            };
            this.lPickTime.MouseWheel += (sender, e) =>
            {
                this.Client.dbConfig.AutoSpot.PickTime = e.Delta > 0 ? Values.GetTimesPost(this.Client.dbConfig.AutoSpot.PickTime) : Values.GetTimesPrev(this.Client.dbConfig.AutoSpot.PickTime);
                this.Client.dbConfig.PendingChanges = true;
                DoDrawControls();
            };
            this.lAssitMob.MouseWheel += (sender, e) =>
            {
                var values = this.NPCs.Select(p => Convert.ToInt32(p.Key)).ToList();
                this.Client.dbConfig.AutoSpot.AssistMob = (e.Delta > 0) ? Values.GetPost(this.Client.dbConfig.AutoSpot.AssistMob, values) : Values.GetPrev(this.Client.dbConfig.AutoSpot.AssistMob, values);
                //this.Client.dbConfig.PendingChanges = true;
                DoDrawControls();
            };


            DoDrawControls();
        }
        
        private void DoDrawControls()
        {
            lBuffKey.Text = $"Key: {Values.GetAllKeyText(this.Client.dbConfig.AutoSpot.BuffKey)}";
            lBuffExpire.Text = $"Expire Time: {Values.GetTimesText(this.Client.dbConfig.AutoSpot.BuffExpireTime)}";
            lBuffCast.Text = $"Cast Time: {Values.GetTimesText(this.Client.dbConfig.AutoSpot.BuffCastTime)}";
            lAssist.Text = $"Assist: {Values.GetAllKeyText(this.Client.dbConfig.AutoSpot.AssistKey)}";
            lAssitMob.Text = $"Mob: {this.NPCs?.Single(p => p.Key == this.Client.dbConfig.AutoSpot.AssistMob).Value}";
            lPickKey.Text = $"Key: {Values.GetAllKeyText(this.Client.dbConfig.AutoSpot.PickKey)}";
            lPickTime.Text = $"Time: {Values.GetTimesText(this.Client.dbConfig.AutoSpot.PickTime)}";
        }

        protected override void CoordsChanges(PopUpCoords coords)
        {
            if (this.Client != null)
            {
                this.Client.dbConfig.AutoSpot.WinPinned = coords.IsPinned;
                this.Client.dbConfig.AutoSpot.WinShowAttachParent = coords.IsAttach;
                this.Client.dbConfig.AutoSpot.ScreenX = coords.X;
                this.Client.dbConfig.AutoSpot.ScreenY = coords.Y;
                this.Client.dbConfig.PendingChanges = true;
            }
        }

        private void PAssistMobRefresh_Click(object sender, EventArgs e)
        {
            this.NPCs = new List<KeyValuePair<int, string>>() { new KeyValuePair<int, string>(0, "none") };  // "none"
            var npcs = this.Client.Mem.Link.NPC.GetAll().Where(p => p.IsMob).Select(p => new KeyValuePair<uint, int>(p.Data.pName, Convert.ToInt32(p.Data.dbCode))).Distinct();
            foreach (var npc in npcs)
            {
                if (!this.NPCs.Any(p => p.Key == npc.Value))
                    this.NPCs.Add(new KeyValuePair<int, string>(npc.Value, this.Client.MemMgr.ReadString(npc.Key, 250)));
            }
            this.NPCs = this.NPCs.OrderBy(p => p.Key == 0 ? 0 : 1).ThenBy(p => p.Value).ToList();

            this.Client.dbConfig.AutoSpot.AssistMob = 0;
            DoDrawControls();
        }
    }
}
