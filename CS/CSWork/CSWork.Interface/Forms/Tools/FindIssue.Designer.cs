namespace CSWork.Interface.Forms.Tools
{
    partial class FindIssue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindIssue));
            this.tFilter = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.cbFilterComments = new System.Windows.Forms.CheckBox();
            this.cbFilterDesc = new System.Windows.Forms.CheckBox();
            this.cbFilterTitle = new System.Windows.Forms.CheckBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.mGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mOpenWeb = new System.Windows.Forms.ToolStripMenuItem();
            this.mAddWork = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pSearching = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.preview = new CSWork.Interface.Forms.Tools.CommentHtml();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.mGridMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pSearching.SuspendLayout();
            this.SuspendLayout();
            // 
            // tFilter
            // 
            this.tFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tFilter.Location = new System.Drawing.Point(6, 21);
            this.tFilter.Name = "tFilter";
            this.tFilter.Size = new System.Drawing.Size(612, 22);
            this.tFilter.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.bSearch);
            this.groupBox1.Controls.Add(this.cbFilterComments);
            this.groupBox1.Controls.Add(this.cbFilterDesc);
            this.groupBox1.Controls.Add(this.cbFilterTitle);
            this.groupBox1.Controls.Add(this.tFilter);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 106);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscador";
            // 
            // bSearch
            // 
            this.bSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSearch.Location = new System.Drawing.Point(514, 68);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(104, 32);
            this.bSearch.TabIndex = 4;
            this.bSearch.Text = "Buscar";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.BSearch_Click);
            // 
            // cbFilterComments
            // 
            this.cbFilterComments.AutoSize = true;
            this.cbFilterComments.Location = new System.Drawing.Point(177, 49);
            this.cbFilterComments.Name = "cbFilterComments";
            this.cbFilterComments.Size = new System.Drawing.Size(103, 20);
            this.cbFilterComments.TabIndex = 3;
            this.cbFilterComments.Text = "Comentarios";
            this.cbFilterComments.UseVisualStyleBackColor = true;
            // 
            // cbFilterDesc
            // 
            this.cbFilterDesc.AutoSize = true;
            this.cbFilterDesc.Checked = true;
            this.cbFilterDesc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFilterDesc.Location = new System.Drawing.Point(72, 49);
            this.cbFilterDesc.Name = "cbFilterDesc";
            this.cbFilterDesc.Size = new System.Drawing.Size(99, 20);
            this.cbFilterDesc.TabIndex = 2;
            this.cbFilterDesc.Text = "Descripción";
            this.cbFilterDesc.UseVisualStyleBackColor = true;
            // 
            // cbFilterTitle
            // 
            this.cbFilterTitle.AutoSize = true;
            this.cbFilterTitle.Checked = true;
            this.cbFilterTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFilterTitle.Location = new System.Drawing.Point(6, 49);
            this.cbFilterTitle.Name = "cbFilterTitle";
            this.cbFilterTitle.Size = new System.Drawing.Size(60, 20);
            this.cbFilterTitle.TabIndex = 1;
            this.cbFilterTitle.Text = "Título";
            this.cbFilterTitle.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(12, 124);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(624, 275);
            this.grid.TabIndex = 2;
            this.grid.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.Grid_CellContextMenuStripNeeded);
            this.grid.CurrentCellChanged += new System.EventHandler(this.Grid_CurrentCellChanged);
            // 
            // mGridMenu
            // 
            this.mGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mOpenWeb,
            this.mAddWork});
            this.mGridMenu.Name = "mGridMenu";
            this.mGridMenu.Size = new System.Drawing.Size(170, 48);
            // 
            // mOpenWeb
            // 
            this.mOpenWeb.Image = ((System.Drawing.Image)(resources.GetObject("mOpenWeb.Image")));
            this.mOpenWeb.Name = "mOpenWeb";
            this.mOpenWeb.Size = new System.Drawing.Size(169, 22);
            this.mOpenWeb.Text = "Abrir en Web";
            this.mOpenWeb.Click += new System.EventHandler(this.MOpenWeb_Click);
            // 
            // mAddWork
            // 
            this.mAddWork.Image = ((System.Drawing.Image)(resources.GetObject("mAddWork.Image")));
            this.mAddWork.Name = "mAddWork";
            this.mAddWork.Size = new System.Drawing.Size(169, 22);
            this.mAddWork.Text = "Agregar a Mi Lista";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(116, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pSearching
            // 
            this.pSearching.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pSearching.BackColor = System.Drawing.Color.White;
            this.pSearching.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSearching.Controls.Add(this.label1);
            this.pSearching.Controls.Add(this.pictureBox1);
            this.pSearching.Location = new System.Drawing.Point(196, 159);
            this.pSearching.Name = "pSearching";
            this.pSearching.Size = new System.Drawing.Size(268, 193);
            this.pSearching.TabIndex = 5;
            this.pSearching.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Buscando";
            // 
            // preview
            // 
            this.preview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preview.BackColor = System.Drawing.Color.White;
            this.preview.Location = new System.Drawing.Point(12, 406);
            this.preview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(624, 162);
            this.preview.TabIndex = 6;
            // 
            // FindIssue
            // 
            this.AcceptButton = this.bSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 581);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.pSearching);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FindIssue";
            this.Text = "Buscar Issue";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.mGridMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pSearching.ResumeLayout(false);
            this.pSearching.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbFilterComments;
        private System.Windows.Forms.CheckBox cbFilterDesc;
        private System.Windows.Forms.CheckBox cbFilterTitle;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.ContextMenuStrip mGridMenu;
        private System.Windows.Forms.ToolStripMenuItem mOpenWeb;
        private System.Windows.Forms.ToolStripMenuItem mAddWork;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pSearching;
        private System.Windows.Forms.Label label1;
        private CommentHtml preview;
    }
}