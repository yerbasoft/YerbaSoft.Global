namespace YerbaSoft.Desktop.PW.Forms
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.bAutoFollow = new System.Windows.Forms.ToolStripMenuItem();
            this.bAutoKey = new System.Windows.Forms.ToolStripMenuItem();
            this.bAutoSpot = new System.Windows.Forms.ToolStripMenuItem();
            this.bAutoAssist = new System.Windows.Forms.ToolStripMenuItem();
            this.bAutoVilla = new System.Windows.Forms.ToolStripMenuItem();
            this.bAntiFreeze = new System.Windows.Forms.ToolStripMenuItem();
            this.bShowWins = new System.Windows.Forms.ToolStripMenuItem();
            this.bShowWinChat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.bPartyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.bPartyCreateNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.bGoTo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.bStopAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.bClose = new System.Windows.Forms.ToolStripMenuItem();
            this.bCloseClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrSave = new System.Windows.Forms.Timer(this.components);
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bLogin,
            this.toolStripMenuItem2,
            this.bAutoFollow,
            this.bAutoKey,
            this.bAutoSpot,
            this.bAutoAssist,
            this.bAutoVilla,
            this.bAntiFreeze,
            this.bShowWins,
            this.toolStripMenuItem1,
            this.bPartyMenu,
            this.bGoTo,
            this.toolStripMenuItem4,
            this.bStopAll,
            this.toolStripMenuItem3,
            this.bClose,
            this.bCloseClient});
            this.Menu.Name = "contextMenuStrip1";
            this.Menu.Size = new System.Drawing.Size(181, 336);
            // 
            // bLogin
            // 
            this.bLogin.Image = ((System.Drawing.Image)(resources.GetObject("bLogin.Image")));
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(180, 22);
            this.bLogin.Text = "Ingresar Login";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // bAutoFollow
            // 
            this.bAutoFollow.Image = ((System.Drawing.Image)(resources.GetObject("bAutoFollow.Image")));
            this.bAutoFollow.Name = "bAutoFollow";
            this.bAutoFollow.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.bAutoFollow.Size = new System.Drawing.Size(180, 22);
            this.bAutoFollow.Text = "Auto Follow";
            // 
            // bAutoKey
            // 
            this.bAutoKey.Image = ((System.Drawing.Image)(resources.GetObject("bAutoKey.Image")));
            this.bAutoKey.Name = "bAutoKey";
            this.bAutoKey.ShortcutKeyDisplayString = "";
            this.bAutoKey.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.bAutoKey.Size = new System.Drawing.Size(180, 22);
            this.bAutoKey.Text = "Auto Key";
            // 
            // bAutoSpot
            // 
            this.bAutoSpot.Image = ((System.Drawing.Image)(resources.GetObject("bAutoSpot.Image")));
            this.bAutoSpot.Name = "bAutoSpot";
            this.bAutoSpot.ShortcutKeyDisplayString = "";
            this.bAutoSpot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.bAutoSpot.Size = new System.Drawing.Size(180, 22);
            this.bAutoSpot.Text = "Auto Spot";
            // 
            // bAutoAssist
            // 
            this.bAutoAssist.Image = ((System.Drawing.Image)(resources.GetObject("bAutoAssist.Image")));
            this.bAutoAssist.Name = "bAutoAssist";
            this.bAutoAssist.ShortcutKeyDisplayString = "";
            this.bAutoAssist.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.bAutoAssist.Size = new System.Drawing.Size(180, 22);
            this.bAutoAssist.Text = "Auto Assist";
            // 
            // bAutoVilla
            // 
            this.bAutoVilla.Image = ((System.Drawing.Image)(resources.GetObject("bAutoVilla.Image")));
            this.bAutoVilla.ImageTransparentColor = System.Drawing.Color.White;
            this.bAutoVilla.Name = "bAutoVilla";
            this.bAutoVilla.Size = new System.Drawing.Size(180, 22);
            this.bAutoVilla.Text = "Villa";
            // 
            // bAntiFreeze
            // 
            this.bAntiFreeze.Checked = true;
            this.bAntiFreeze.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bAntiFreeze.Image = ((System.Drawing.Image)(resources.GetObject("bAntiFreeze.Image")));
            this.bAntiFreeze.Name = "bAntiFreeze";
            this.bAntiFreeze.Size = new System.Drawing.Size(180, 22);
            this.bAntiFreeze.Text = "Anti Freeze";
            // 
            // bShowWins
            // 
            this.bShowWins.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bShowWinChat});
            this.bShowWins.Image = ((System.Drawing.Image)(resources.GetObject("bShowWins.Image")));
            this.bShowWins.Name = "bShowWins";
            this.bShowWins.Size = new System.Drawing.Size(180, 22);
            this.bShowWins.Text = "Show";
            // 
            // bShowWinChat
            // 
            this.bShowWinChat.Image = ((System.Drawing.Image)(resources.GetObject("bShowWinChat.Image")));
            this.bShowWinChat.Name = "bShowWinChat";
            this.bShowWinChat.Size = new System.Drawing.Size(123, 22);
            this.bShowWinChat.Text = "Win Chat";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // bPartyMenu
            // 
            this.bPartyMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bPartyCreateNew,
            this.toolStripMenuItem5});
            this.bPartyMenu.Image = ((System.Drawing.Image)(resources.GetObject("bPartyMenu.Image")));
            this.bPartyMenu.Name = "bPartyMenu";
            this.bPartyMenu.Size = new System.Drawing.Size(180, 22);
            this.bPartyMenu.Text = "Party";
            // 
            // bPartyCreateNew
            // 
            this.bPartyCreateNew.Image = ((System.Drawing.Image)(resources.GetObject("bPartyCreateNew.Image")));
            this.bPartyCreateNew.Name = "bPartyCreateNew";
            this.bPartyCreateNew.Size = new System.Drawing.Size(169, 22);
            this.bPartyCreateNew.Text = "Crear Nueva Party";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(166, 6);
            // 
            // bGoTo
            // 
            this.bGoTo.Image = ((System.Drawing.Image)(resources.GetObject("bGoTo.Image")));
            this.bGoTo.Name = "bGoTo";
            this.bGoTo.Size = new System.Drawing.Size(180, 22);
            this.bGoTo.Text = "Go To";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(177, 6);
            // 
            // bStopAll
            // 
            this.bStopAll.Image = ((System.Drawing.Image)(resources.GetObject("bStopAll.Image")));
            this.bStopAll.Name = "bStopAll";
            this.bStopAll.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.bStopAll.Size = new System.Drawing.Size(180, 22);
            this.bStopAll.Text = "STOP ALL";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // bClose
            // 
            this.bClose.Image = ((System.Drawing.Image)(resources.GetObject("bClose.Image")));
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(180, 22);
            this.bClose.Text = "Cerrar";
            // 
            // bCloseClient
            // 
            this.bCloseClient.Image = ((System.Drawing.Image)(resources.GetObject("bCloseClient.Image")));
            this.bCloseClient.Name = "bCloseClient";
            this.bCloseClient.Size = new System.Drawing.Size(180, 22);
            this.bCloseClient.Text = "Cerrar Cliente";
            // 
            // tmrSave
            // 
            this.tmrSave.Enabled = true;
            this.tmrSave.Interval = 10000;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(100, 100);
            this.ContextMenuStrip = this.Menu;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClientForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ClientForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem bLogin;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem bAutoFollow;
        private System.Windows.Forms.ToolStripMenuItem bAutoKey;
        private System.Windows.Forms.ToolStripMenuItem bAutoSpot;
        private System.Windows.Forms.ToolStripMenuItem bAutoAssist;
        private System.Windows.Forms.ToolStripMenuItem bAntiFreeze;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bStopAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem bClose;
        private System.Windows.Forms.Timer tmrSave;
        private System.Windows.Forms.ToolStripMenuItem bGoTo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem bAutoVilla;
        private System.Windows.Forms.ToolStripMenuItem bPartyMenu;
        private System.Windows.Forms.ToolStripMenuItem bPartyCreateNew;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem bShowWins;
        private System.Windows.Forms.ToolStripMenuItem bShowWinChat;
        private System.Windows.Forms.ToolStripMenuItem bCloseClient;
    }
}