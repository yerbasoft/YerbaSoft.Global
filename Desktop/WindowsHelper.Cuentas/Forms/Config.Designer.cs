namespace WindowsHelper.Cuentas.Forms
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbIncluyeEliminados = new System.Windows.Forms.CheckBox();
            this.bDel = new System.Windows.Forms.Button();
            this.bNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbEsCredito = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bOk = new System.Windows.Forms.Button();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esCreditoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.creaFechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bajaFechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conceptoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(740, 537);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.Grid);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(732, 506);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Conceptos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbIncluyeEliminados);
            this.panel2.Controls.Add(this.bDel);
            this.panel2.Controls.Add(this.bNew);
            this.panel2.Location = new System.Drawing.Point(6, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 37);
            this.panel2.TabIndex = 2;
            // 
            // cbIncluyeEliminados
            // 
            this.cbIncluyeEliminados.AutoSize = true;
            this.cbIncluyeEliminados.Location = new System.Drawing.Point(589, 7);
            this.cbIncluyeEliminados.Name = "cbIncluyeEliminados";
            this.cbIncluyeEliminados.Size = new System.Drawing.Size(126, 22);
            this.cbIncluyeEliminados.TabIndex = 6;
            this.cbIncluyeEliminados.Text = "Ver Eliminados";
            this.cbIncluyeEliminados.UseVisualStyleBackColor = true;
            this.cbIncluyeEliminados.CheckedChanged += new System.EventHandler(this.CbIncluyeEliminados_CheckedChanged);
            // 
            // bDel
            // 
            this.bDel.Image = ((System.Drawing.Image)(resources.GetObject("bDel.Image")));
            this.bDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bDel.Location = new System.Drawing.Point(118, 3);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(109, 29);
            this.bDel.TabIndex = 5;
            this.bDel.Text = "Eliminar";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.BDel_Click);
            // 
            // bNew
            // 
            this.bNew.Image = ((System.Drawing.Image)(resources.GetObject("bNew.Image")));
            this.bNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bNew.Location = new System.Drawing.Point(3, 3);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(109, 29);
            this.bNew.TabIndex = 4;
            this.bNew.Text = "Nuevo";
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.BNew_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtObservaciones);
            this.panel1.Controls.Add(this.cbEsCredito);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bOk);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 138);
            this.panel1.TabIndex = 1;
            // 
            // cbEsCredito
            // 
            this.cbEsCredito.AutoSize = true;
            this.cbEsCredito.Location = new System.Drawing.Point(127, 75);
            this.cbEsCredito.Name = "cbEsCredito";
            this.cbEsCredito.Size = new System.Drawing.Size(97, 22);
            this.cbEsCredito.TabIndex = 2;
            this.cbEsCredito.Text = "Es Crédito";
            this.cbEsCredito.UseVisualStyleBackColor = true;
            this.cbEsCredito.CheckedChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(127, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(588, 24);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // bOk
            // 
            this.bOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOk.Location = new System.Drawing.Point(613, 102);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(102, 31);
            this.bOk.TabIndex = 3;
            this.bOk.Text = "Agregar";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.BOk_Click);
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid.AutoGenerateColumns = false;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.esCreditoDataGridViewCheckBoxColumn,
            this.creaFechaDataGridViewTextBoxColumn,
            this.bajaFechaDataGridViewTextBoxColumn});
            this.Grid.DataSource = this.conceptoBindingSource;
            this.Grid.Location = new System.Drawing.Point(6, 193);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(720, 307);
            this.Grid.TabIndex = 7;
            this.Grid.SelectionChanged += new System.EventHandler(this.Grid_SelectionChanged);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservaciones.Location = new System.Drawing.Point(127, 45);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(588, 24);
            this.txtObservaciones.TabIndex = 1;
            this.txtObservaciones.TextChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Observaciones";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 350;
            // 
            // esCreditoDataGridViewCheckBoxColumn
            // 
            this.esCreditoDataGridViewCheckBoxColumn.DataPropertyName = "EsCredito";
            this.esCreditoDataGridViewCheckBoxColumn.HeaderText = "EsCredito";
            this.esCreditoDataGridViewCheckBoxColumn.Name = "esCreditoDataGridViewCheckBoxColumn";
            this.esCreditoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // creaFechaDataGridViewTextBoxColumn
            // 
            this.creaFechaDataGridViewTextBoxColumn.DataPropertyName = "CreaFecha";
            this.creaFechaDataGridViewTextBoxColumn.HeaderText = "CreaFecha";
            this.creaFechaDataGridViewTextBoxColumn.Name = "creaFechaDataGridViewTextBoxColumn";
            this.creaFechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bajaFechaDataGridViewTextBoxColumn
            // 
            this.bajaFechaDataGridViewTextBoxColumn.DataPropertyName = "BajaFecha";
            this.bajaFechaDataGridViewTextBoxColumn.HeaderText = "BajaFecha";
            this.bajaFechaDataGridViewTextBoxColumn.Name = "bajaFechaDataGridViewTextBoxColumn";
            this.bajaFechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // conceptoBindingSource
            // 
            this.conceptoBindingSource.DataSource = typeof(WindowsHelper.Cuentas.DTO.Concepto);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 537);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Config";
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.Config_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.BindingSource conceptoBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.CheckBox cbEsCredito;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn esCreditoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creaFechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bajaFechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.CheckBox cbIncluyeEliminados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObservaciones;
    }
}