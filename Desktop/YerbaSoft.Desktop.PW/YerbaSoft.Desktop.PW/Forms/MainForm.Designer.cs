namespace YerbaSoft.Desktop.PW.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.asociarAPWAbiertoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bAutoFollow = new System.Windows.Forms.ToolStripMenuItem();
            this.bAutoSpot = new System.Windows.Forms.ToolStripMenuItem();
            this.bStopAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "PW";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asociarAPWAbiertoToolStripMenuItem,
            this.abrirNuevoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.commandsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cerrarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 126);
            // 
            // asociarAPWAbiertoToolStripMenuItem
            // 
            this.asociarAPWAbiertoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("asociarAPWAbiertoToolStripMenuItem.Image")));
            this.asociarAPWAbiertoToolStripMenuItem.Name = "asociarAPWAbiertoToolStripMenuItem";
            this.asociarAPWAbiertoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.asociarAPWAbiertoToolStripMenuItem.Text = "Attach";
            // 
            // abrirNuevoToolStripMenuItem
            // 
            this.abrirNuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abrirNuevoToolStripMenuItem.Image")));
            this.abrirNuevoToolStripMenuItem.Name = "abrirNuevoToolStripMenuItem";
            this.abrirNuevoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.abrirNuevoToolStripMenuItem.Text = "Open";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bAutoFollow,
            this.bAutoSpot,
            this.bStopAll});
            this.commandsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("commandsToolStripMenuItem.Image")));
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.commandsToolStripMenuItem.Text = "Commands";
            // 
            // bAutoFollow
            // 
            this.bAutoFollow.Image = ((System.Drawing.Image)(resources.GetObject("bAutoFollow.Image")));
            this.bAutoFollow.Name = "bAutoFollow";
            this.bAutoFollow.Size = new System.Drawing.Size(180, 22);
            this.bAutoFollow.Text = "AutoFollow";
            this.bAutoFollow.Click += new System.EventHandler(this.BAutoFollow_Click);
            // 
            // bAutoSpot
            // 
            this.bAutoSpot.Image = ((System.Drawing.Image)(resources.GetObject("bAutoSpot.Image")));
            this.bAutoSpot.Name = "bAutoSpot";
            this.bAutoSpot.Size = new System.Drawing.Size(180, 22);
            this.bAutoSpot.Text = "AutoSpot";
            this.bAutoSpot.Click += new System.EventHandler(this.BAutoSpot_Click);
            // 
            // bStopAll
            // 
            this.bStopAll.Image = ((System.Drawing.Image)(resources.GetObject("bStopAll.Image")));
            this.bStopAll.Name = "bStopAll";
            this.bStopAll.Size = new System.Drawing.Size(180, 22);
            this.bStopAll.Text = "STOP ALL";
            this.bStopAll.Click += new System.EventHandler(this.BStopAll_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cerrarToolStripMenuItem.Image")));
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarToolStripMenuItem.Text = "Close";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.CerrarToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 198);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "PW";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem asociarAPWAbiertoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirNuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bAutoFollow;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bAutoSpot;
        private System.Windows.Forms.ToolStripMenuItem bStopAll;
    }
}

