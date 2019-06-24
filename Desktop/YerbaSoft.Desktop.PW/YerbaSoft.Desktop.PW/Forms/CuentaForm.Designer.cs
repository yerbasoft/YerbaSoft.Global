namespace YerbaSoft.Desktop.PW.Forms
{
    partial class CuentaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuentaForm));
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.bAutoFollow = new System.Windows.Forms.ToolStripMenuItem();
            this.bAutoKey = new System.Windows.Forms.ToolStripMenuItem();
            this.bAutoSpot = new System.Windows.Forms.ToolStripMenuItem();
            this.bAutoAssist = new System.Windows.Forms.ToolStripMenuItem();
            this.bAutoPick = new System.Windows.Forms.ToolStripMenuItem();
            this.bAntiFreeze = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.bStopAll = new System.Windows.Forms.ToolStripMenuItem();
            this.bMinimize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.bClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tAutoSave = new System.Windows.Forms.Timer(this.components);
            this.tDraw = new System.Windows.Forms.Timer(this.components);
            this.HideIcon = new System.Windows.Forms.NotifyIcon(this.components);
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
            this.bAutoPick,
            this.bAntiFreeze,
            this.toolStripMenuItem1,
            this.bStopAll,
            this.bMinimize,
            this.toolStripMenuItem3,
            this.bClose});
            this.Menu.Name = "contextMenuStrip1";
            this.Menu.Size = new System.Drawing.Size(150, 242);
            // 
            // bLogin
            // 
            this.bLogin.Image = ((System.Drawing.Image)(resources.GetObject("bLogin.Image")));
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(149, 22);
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
            this.bAutoFollow.Size = new System.Drawing.Size(180, 22);
            this.bAutoFollow.Text = "Auto Follow";
            // 
            // bAutoKey
            // 
            this.bAutoKey.Image = ((System.Drawing.Image)(resources.GetObject("bAutoKey.Image")));
            this.bAutoKey.Name = "bAutoKey";
            this.bAutoKey.Size = new System.Drawing.Size(180, 22);
            this.bAutoKey.Text = "Auto Key";
            // 
            // bAutoSpot
            // 
            this.bAutoSpot.Image = ((System.Drawing.Image)(resources.GetObject("bAutoSpot.Image")));
            this.bAutoSpot.Name = "bAutoSpot";
            this.bAutoSpot.Size = new System.Drawing.Size(180, 22);
            this.bAutoSpot.Text = "Auto Spot";
            // 
            // bAutoAssist
            // 
            this.bAutoAssist.Image = ((System.Drawing.Image)(resources.GetObject("bAutoAssist.Image")));
            this.bAutoAssist.Name = "bAutoAssist";
            this.bAutoAssist.Size = new System.Drawing.Size(149, 22);
            this.bAutoAssist.Text = "Auto Assist";
            // 
            // bAutoPick
            // 
            this.bAutoPick.Image = ((System.Drawing.Image)(resources.GetObject("bAutoPick.Image")));
            this.bAutoPick.Name = "bAutoPick";
            this.bAutoPick.Size = new System.Drawing.Size(180, 22);
            this.bAutoPick.Text = "Auto Pick";
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // bStopAll
            // 
            this.bStopAll.Image = ((System.Drawing.Image)(resources.GetObject("bStopAll.Image")));
            this.bStopAll.Name = "bStopAll";
            this.bStopAll.Size = new System.Drawing.Size(180, 22);
            this.bStopAll.Text = "STOP ALL";
            // 
            // bMinimize
            // 
            this.bMinimize.Image = ((System.Drawing.Image)(resources.GetObject("bMinimize.Image")));
            this.bMinimize.Name = "bMinimize";
            this.bMinimize.Size = new System.Drawing.Size(180, 22);
            this.bMinimize.Text = "Ocultar";
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
            // tAutoSave
            // 
            this.tAutoSave.Enabled = true;
            this.tAutoSave.Interval = 10000;
            // 
            // tDraw
            // 
            this.tDraw.Enabled = true;
            this.tDraw.Interval = 500;
            // 
            // HideIcon
            // 
            this.HideIcon.ContextMenuStrip = this.Menu;
            this.HideIcon.Text = "notifyIcon1";
            this.HideIcon.Visible = true;
            // 
            // CuentaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(437, 412);
            this.ContextMenuStrip = this.Menu;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(34, 34);
            this.Name = "CuentaForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.Load += new System.EventHandler(this.CuentaForm_Load);
            this.Click += new System.EventHandler(this.CuentaForm_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CuentaForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CuentaForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CuentaForm_MouseUp);
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem bLogin;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bClose;
        private System.Windows.Forms.Timer tAutoSave;
        private System.Windows.Forms.ToolStripMenuItem bAntiFreeze;
        public System.Windows.Forms.ToolStripMenuItem bAutoFollow;
        private System.Windows.Forms.ToolStripMenuItem bAutoSpot;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bStopAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.Timer tDraw;
        private System.Windows.Forms.ToolStripMenuItem bAutoPick;
        private System.Windows.Forms.ToolStripMenuItem bMinimize;
        private System.Windows.Forms.NotifyIcon HideIcon;
        private System.Windows.Forms.ToolStripMenuItem bAutoKey;
        private System.Windows.Forms.ToolStripMenuItem bAutoAssist;
    }
}