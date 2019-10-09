namespace CSWork.Interface.Forms
{
    partial class IssueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bOpenUrl = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mAdjuntos = new System.Windows.Forms.ToolStripDropDownButton();
            this.mIssues = new System.Windows.Forms.ToolStripDropDownButton();
            this.mTransitions = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bAddComment = new System.Windows.Forms.ToolStripButton();
            this.bWork = new System.Windows.Forms.ToolStripButton();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.lSummary = new System.Windows.Forms.Label();
            this.wDescription = new System.Windows.Forms.WebBrowser();
            this.wComentarios = new System.Windows.Forms.WebBrowser();
            this.toolStrip1.SuspendLayout();
            this.table.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bOpenUrl,
            this.toolStripSeparator1,
            this.mAdjuntos,
            this.mIssues,
            this.mTransitions,
            this.toolStripSeparator2,
            this.bAddComment,
            this.bWork});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(757, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bOpenUrl
            // 
            this.bOpenUrl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bOpenUrl.Image = ((System.Drawing.Image)(resources.GetObject("bOpenUrl.Image")));
            this.bOpenUrl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bOpenUrl.Name = "bOpenUrl";
            this.bOpenUrl.Size = new System.Drawing.Size(23, 22);
            this.bOpenUrl.Text = "toolStripButton1";
            this.bOpenUrl.ToolTipText = "Abrir en Explorador";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // mAdjuntos
            // 
            this.mAdjuntos.Image = ((System.Drawing.Image)(resources.GetObject("mAdjuntos.Image")));
            this.mAdjuntos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mAdjuntos.Name = "mAdjuntos";
            this.mAdjuntos.Size = new System.Drawing.Size(84, 22);
            this.mAdjuntos.Text = "Adjuntos";
            // 
            // mIssues
            // 
            this.mIssues.Image = ((System.Drawing.Image)(resources.GetObject("mIssues.Image")));
            this.mIssues.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mIssues.Name = "mIssues";
            this.mIssues.Size = new System.Drawing.Size(92, 22);
            this.mIssues.Text = "Relaciones";
            // 
            // mTransitions
            // 
            this.mTransitions.Image = ((System.Drawing.Image)(resources.GetObject("mTransitions.Image")));
            this.mTransitions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mTransitions.Name = "mTransitions";
            this.mTransitions.Size = new System.Drawing.Size(70, 22);
            this.mTransitions.Text = "Mover";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bAddComment
            // 
            this.bAddComment.Image = ((System.Drawing.Image)(resources.GetObject("bAddComment.Image")));
            this.bAddComment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bAddComment.Name = "bAddComment";
            this.bAddComment.Size = new System.Drawing.Size(80, 22);
            this.bAddComment.Text = "Comentar";
            // 
            // bWork
            // 
            this.bWork.Image = ((System.Drawing.Image)(resources.GetObject("bWork.Image")));
            this.bWork.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bWork.Name = "bWork";
            this.bWork.Size = new System.Drawing.Size(65, 22);
            this.bWork.Text = "Trabajo";
            this.bWork.ToolTipText = "Registrar Trabajo";
            this.bWork.Click += new System.EventHandler(this.BWork_Click);
            // 
            // table
            // 
            this.table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.table.ColumnCount = 1;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Controls.Add(this.lSummary, 0, 0);
            this.table.Controls.Add(this.wDescription, 0, 1);
            this.table.Controls.Add(this.wComentarios, 0, 2);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 25);
            this.table.Name = "table";
            this.table.RowCount = 3;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.21053F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.78947F));
            this.table.Size = new System.Drawing.Size(757, 509);
            this.table.TabIndex = 6;
            // 
            // lSummary
            // 
            this.lSummary.BackColor = System.Drawing.Color.White;
            this.lSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSummary.Location = new System.Drawing.Point(5, 2);
            this.lSummary.Name = "lSummary";
            this.lSummary.Size = new System.Drawing.Size(747, 30);
            this.lSummary.TabIndex = 0;
            this.lSummary.Text = "label1";
            this.lSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wDescription
            // 
            this.wDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wDescription.IsWebBrowserContextMenuEnabled = false;
            this.wDescription.Location = new System.Drawing.Point(5, 37);
            this.wDescription.MinimumSize = new System.Drawing.Size(20, 20);
            this.wDescription.Name = "wDescription";
            this.wDescription.Size = new System.Drawing.Size(747, 145);
            this.wDescription.TabIndex = 1;
            // 
            // wComentarios
            // 
            this.wComentarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wComentarios.Location = new System.Drawing.Point(5, 190);
            this.wComentarios.MinimumSize = new System.Drawing.Size(20, 20);
            this.wComentarios.Name = "wComentarios";
            this.wComentarios.Size = new System.Drawing.Size(747, 314);
            this.wComentarios.TabIndex = 2;
            this.wComentarios.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.WComentarios_Navigating);
            // 
            // IssueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(757, 534);
            this.Controls.Add(this.table);
            this.Controls.Add(this.toolStrip1);
            this.Name = "IssueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.table.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Label lSummary;
        private System.Windows.Forms.WebBrowser wDescription;
        private System.Windows.Forms.WebBrowser wComentarios;
        private System.Windows.Forms.ToolStripDropDownButton mTransitions;
        private System.Windows.Forms.ToolStripButton bOpenUrl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton mAdjuntos;
        private System.Windows.Forms.ToolStripDropDownButton mIssues;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bWork;
        private System.Windows.Forms.ToolStripButton bAddComment;
    }
}