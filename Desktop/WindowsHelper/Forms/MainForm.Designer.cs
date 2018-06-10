namespace WindowsHelper.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.WinIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainMenuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.MainMenuContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // WinIcon
            // 
            this.WinIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.WinIcon.BalloonTipText = "y yo un texto";
            this.WinIcon.BalloonTipTitle = "Soy un título";
            this.WinIcon.ContextMenuStrip = this.MainMenuContext;
            this.WinIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("WinIcon.Icon")));
            this.WinIcon.Text = "Windows Helper";
            this.WinIcon.Visible = true;
            this.WinIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.WinIcon_MouseDoubleClick);
            // 
            // MainMenuContext
            // 
            this.MainMenuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mTitle,
            this.toolStripMenuItem1});
            this.MainMenuContext.Name = "MainMenuContext";
            this.MainMenuContext.Size = new System.Drawing.Size(181, 54);
            // 
            // mTitle
            // 
            this.mTitle.BackColor = System.Drawing.Color.Black;
            this.mTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mTitle.ForeColor = System.Drawing.Color.Yellow;
            this.mTitle.Name = "mTitle";
            this.mTitle.Size = new System.Drawing.Size(180, 22);
            this.mTitle.Text = "Windows Helper";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.Black;
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.Lime;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(836, 406);
            this.txtLog.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 406);
            this.Controls.Add(this.txtLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "Windows Helper";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenuContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon WinIcon;
        private System.Windows.Forms.ContextMenuStrip MainMenuContext;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ToolStripMenuItem mTitle;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}