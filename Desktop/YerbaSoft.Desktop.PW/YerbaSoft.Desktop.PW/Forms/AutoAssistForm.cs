using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerbaSoft.Desktop.PW.Properties;

namespace YerbaSoft.Desktop.PW.Forms
{
    public partial class AutoAssistForm : PopUpForm
    {
        protected override string Title => "Auto Assist";

        private BLL.PWClient Client { get; set; }

        private Helper.InputValues Values = new Helper.InputValues();

        public AutoAssistForm() : base() { }
        public AutoAssistForm(ClientForm parent, BLL.PWClient client) : base(parent, new PopUpCoords(client.dbConfig.AutoAssist.WinPinned, client.dbConfig.AutoAssist.WinShowAttachParent, client.dbConfig.AutoAssist.ScreenX, client.dbConfig.AutoAssist.ScreenY))
        {
            InitializeComponent();
            this.Client = client;

            this.lFollow.MouseWheel += (sender, e) =>
            {
                this.Client.dbConfig.AutoAssist.FollowParty = e.Delta > 0 ? Values.GetPartysPost(this.Client.dbConfig.AutoAssist.FollowParty) : Values.GetPartysPrev(this.Client.dbConfig.AutoAssist.FollowParty);
                this.Client.dbConfig.PendingChanges = true;
                DoDrawControls();
            };

            this.lAssistPlayer.MouseWheel += (sender, e) =>
            {
                this.Client.dbConfig.AutoAssist.AssistPJKey = e.Delta > 0 ? Values.GetPartysPost(this.Client.dbConfig.AutoAssist.AssistPJKey) : Values.GetPartysPrev(this.Client.dbConfig.AutoAssist.AssistPJKey);
                this.Client.dbConfig.PendingChanges = true;
                DoDrawControls();
            };
            this.lAssistKey.MouseWheel += (sender, e) =>
            {
                this.Client.dbConfig.AutoAssist.AssistKey = e.Delta > 0 ? Values.GetAllKeyPost(this.Client.dbConfig.AutoAssist.AssistKey) : Values.GetAllKeyPrev(this.Client.dbConfig.AutoAssist.AssistKey);
                this.Client.dbConfig.PendingChanges = true;
                DoDrawControls();
            };
            this.lAssistTime.MouseWheel += (sender, e) =>
            {
                this.Client.dbConfig.AutoAssist.AssistTime = e.Delta > 0 ? Values.GetTimesPost(this.Client.dbConfig.AutoAssist.AssistTime) : Values.GetTimesPrev(this.Client.dbConfig.AutoAssist.AssistTime);
                this.Client.dbConfig.PendingChanges = true;
                DoDrawControls();
            };

            this.lPickKey.MouseWheel += (sender, e) =>
            {
                this.Client.dbConfig.AutoAssist.PickKey = e.Delta > 0 ? Values.GetAllKeyPost(this.Client.dbConfig.AutoAssist.PickKey, true) : Values.GetAllKeyPrev(this.Client.dbConfig.AutoAssist.PickKey, true);
                this.Client.dbConfig.PendingChanges = true;
                DoDrawControls();
            };
            this.lPickTime.MouseWheel += (sender, e) =>
            {
                this.Client.dbConfig.AutoAssist.PickTime = e.Delta > 0 ? Values.GetTimesPost(this.Client.dbConfig.AutoAssist.PickTime) : Values.GetTimesPrev(this.Client.dbConfig.AutoAssist.PickTime);
                this.Client.dbConfig.PendingChanges = true;
                DoDrawControls();
            };
            DoDrawControls();
        }

        private void DoDrawControls()
        {
            if (string.IsNullOrEmpty(this.Client.dbConfig.AutoAssist.FollowParty))
            {
                this.Client.dbConfig.AutoAssist.FollowParty = Values.GetPartysFirst();
                this.Client.dbConfig.PendingChanges = true;
            }
            if (string.IsNullOrEmpty(this.Client.dbConfig.AutoAssist.AssistPJKey))
            {
                this.Client.dbConfig.AutoAssist.AssistPJKey = Values.GetPartysFirst();
                this.Client.dbConfig.PendingChanges = true;
            }
            if (string.IsNullOrEmpty(this.Client.dbConfig.AutoAssist.AssistKey))
            {
                this.Client.dbConfig.AutoAssist.AssistKey = Values.GetAllKeyFirst();
                this.Client.dbConfig.PendingChanges = true;
            }

            lFollow.Text = $"Party: {Values.GetPartysText(this.Client.dbConfig.AutoAssist.FollowParty)}";
            lAssistPlayer.Text = $"Party: {Values.GetPartysText(this.Client.dbConfig.AutoAssist.AssistPJKey)}";
            lAssistKey.Text = $"Key: {Values.GetAllKeyText(this.Client.dbConfig.AutoAssist.AssistKey)}";
            lAssistTime.Text = $"Frecuency: {Values.GetTimesText(this.Client.dbConfig.AutoAssist.AssistTime)}";
            lPickKey.Text = $"Key: {Values.GetAllKeyText(this.Client.dbConfig.AutoAssist.PickKey)}";
            lPickTime.Text = $"Time: {Values.GetTimesText(this.Client.dbConfig.AutoAssist.PickTime)}";
        }
        protected override void CoordsChanges(PopUpCoords coords)
        {
            if (this.Client != null)
            {
                this.Client.dbConfig.AutoAssist.WinPinned = coords.IsPinned;
                this.Client.dbConfig.AutoAssist.WinShowAttachParent = coords.IsAttach;
                this.Client.dbConfig.AutoAssist.ScreenX = coords.X;
                this.Client.dbConfig.AutoAssist.ScreenY = coords.Y;
                this.Client.dbConfig.PendingChanges = true;
            }
        }
    }
}
