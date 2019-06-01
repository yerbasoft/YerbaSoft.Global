namespace WindowsHelper.Cuentas.Forms
{
    partial class Ahorros
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ahorros));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.tipoAhorroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TazaAnual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ganancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDesdeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaHastaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ahorroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lTaza = new System.Windows.Forms.Label();
            this.lMonto = new System.Windows.Forms.Label();
            this.txtTaza = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.bNew = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.txtEntidad = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahorroBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1040, 553);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Grid);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1032, 520);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ABM Ahorros";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.AllowUserToOrderColumns = true;
            this.Grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid.AutoGenerateColumns = false;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoAhorroDataGridViewTextBoxColumn,
            this.entidadDataGridViewTextBoxColumn,
            this.Monto,
            this.TazaAnual,
            this.Dias,
            this.Ganancia,
            this.fechaDesdeDataGridViewTextBoxColumn,
            this.fechaHastaDataGridViewTextBoxColumn,
            this.observacionesDataGridViewTextBoxColumn});
            this.Grid.DataSource = this.ahorroBindingSource;
            this.Grid.Location = new System.Drawing.Point(6, 273);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(1020, 241);
            this.Grid.TabIndex = 0;
            this.Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellContentClick);
            this.Grid.SelectionChanged += new System.EventHandler(this.Grid_SelectionChanged);
            // 
            // tipoAhorroDataGridViewTextBoxColumn
            // 
            this.tipoAhorroDataGridViewTextBoxColumn.DataPropertyName = "TipoAhorro";
            this.tipoAhorroDataGridViewTextBoxColumn.HeaderText = "Tipo de Ahorro";
            this.tipoAhorroDataGridViewTextBoxColumn.Name = "tipoAhorroDataGridViewTextBoxColumn";
            this.tipoAhorroDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoAhorroDataGridViewTextBoxColumn.Width = 150;
            // 
            // entidadDataGridViewTextBoxColumn
            // 
            this.entidadDataGridViewTextBoxColumn.DataPropertyName = "Entidad";
            this.entidadDataGridViewTextBoxColumn.HeaderText = "Entidad";
            this.entidadDataGridViewTextBoxColumn.Name = "entidadDataGridViewTextBoxColumn";
            this.entidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.entidadDataGridViewTextBoxColumn.Width = 150;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.Monto.DefaultCellStyle = dataGridViewCellStyle1;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // TazaAnual
            // 
            this.TazaAnual.DataPropertyName = "TazaAnual";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "##.##\'%\'";
            dataGridViewCellStyle2.NullValue = null;
            this.TazaAnual.DefaultCellStyle = dataGridViewCellStyle2;
            this.TazaAnual.HeaderText = "TazaAnual";
            this.TazaAnual.Name = "TazaAnual";
            this.TazaAnual.ReadOnly = true;
            // 
            // Dias
            // 
            this.Dias.DataPropertyName = "Dias";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Dias.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dias.HeaderText = "Dias";
            this.Dias.Name = "Dias";
            this.Dias.ReadOnly = true;
            // 
            // Ganancia
            // 
            this.Ganancia.DataPropertyName = "InteresEstimado";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.Ganancia.DefaultCellStyle = dataGridViewCellStyle4;
            this.Ganancia.HeaderText = "Ganancia";
            this.Ganancia.Name = "Ganancia";
            this.Ganancia.ReadOnly = true;
            // 
            // fechaDesdeDataGridViewTextBoxColumn
            // 
            this.fechaDesdeDataGridViewTextBoxColumn.DataPropertyName = "FechaDesde";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.fechaDesdeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaDesdeDataGridViewTextBoxColumn.HeaderText = "Inicio";
            this.fechaDesdeDataGridViewTextBoxColumn.Name = "fechaDesdeDataGridViewTextBoxColumn";
            this.fechaDesdeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaHastaDataGridViewTextBoxColumn
            // 
            this.fechaHastaDataGridViewTextBoxColumn.DataPropertyName = "FechaHasta";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.fechaHastaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.fechaHastaDataGridViewTextBoxColumn.HeaderText = "Fin";
            this.fechaHastaDataGridViewTextBoxColumn.Name = "fechaHastaDataGridViewTextBoxColumn";
            this.fechaHastaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // observacionesDataGridViewTextBoxColumn
            // 
            this.observacionesDataGridViewTextBoxColumn.DataPropertyName = "Observaciones";
            this.observacionesDataGridViewTextBoxColumn.HeaderText = "Observaciones";
            this.observacionesDataGridViewTextBoxColumn.Name = "observacionesDataGridViewTextBoxColumn";
            this.observacionesDataGridViewTextBoxColumn.ReadOnly = true;
            this.observacionesDataGridViewTextBoxColumn.Width = 250;
            // 
            // ahorroBindingSource
            // 
            this.ahorroBindingSource.DataSource = typeof(WindowsHelper.Cuentas.DTO.Ahorro);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lTaza);
            this.panel1.Controls.Add(this.lMonto);
            this.panel1.Controls.Add(this.txtTaza);
            this.panel1.Controls.Add(this.txtMonto);
            this.panel1.Controls.Add(this.bNew);
            this.panel1.Controls.Add(this.bDel);
            this.panel1.Controls.Add(this.bSave);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbTipo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtFechaHasta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtFechaDesde);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtObs);
            this.panel1.Controls.Add(this.txtEntidad);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 261);
            this.panel1.TabIndex = 0;
            // 
            // lTaza
            // 
            this.lTaza.AutoSize = true;
            this.lTaza.Location = new System.Drawing.Point(3, 138);
            this.lTaza.Name = "lTaza";
            this.lTaza.Size = new System.Drawing.Size(89, 20);
            this.lTaza.TabIndex = 18;
            this.lTaza.Text = "Taza Anual";
            // 
            // lMonto
            // 
            this.lMonto.AutoSize = true;
            this.lMonto.Location = new System.Drawing.Point(3, 109);
            this.lMonto.Name = "lMonto";
            this.lMonto.Size = new System.Drawing.Size(54, 20);
            this.lMonto.TabIndex = 17;
            this.lMonto.Text = "Monto";
            // 
            // txtTaza
            // 
            this.txtTaza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaza.Location = new System.Drawing.Point(140, 135);
            this.txtTaza.Name = "txtTaza";
            this.txtTaza.Size = new System.Drawing.Size(877, 26);
            this.txtTaza.TabIndex = 16;
            this.txtTaza.TextChanged += new System.EventHandler(this.TxtTaza_TextChanged);
            // 
            // txtMonto
            // 
            this.txtMonto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMonto.Location = new System.Drawing.Point(140, 103);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(877, 26);
            this.txtMonto.TabIndex = 15;
            this.txtMonto.TextChanged += new System.EventHandler(this.TxtMonto_TextChanged);
            // 
            // bNew
            // 
            this.bNew.Image = ((System.Drawing.Image)(resources.GetObject("bNew.Image")));
            this.bNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bNew.Location = new System.Drawing.Point(7, 222);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(81, 36);
            this.bNew.TabIndex = 14;
            this.bNew.Text = "Nuevo";
            this.bNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.BNew_Click);
            // 
            // bDel
            // 
            this.bDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bDel.Image = ((System.Drawing.Image)(resources.GetObject("bDel.Image")));
            this.bDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bDel.Location = new System.Drawing.Point(827, 222);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(91, 36);
            this.bDel.TabIndex = 13;
            this.bDel.Text = "Eliminar";
            this.bDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bDel.UseVisualStyleBackColor = true;
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSave.Image = ((System.Drawing.Image)(resources.GetObject("bSave.Image")));
            this.bSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSave.Location = new System.Drawing.Point(924, 222);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(93, 36);
            this.bSave.TabIndex = 12;
            this.bSave.Text = "Guardar";
            this.bSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tipo Ahorro";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Plazo Fijo",
            "Dolares"});
            this.cmbTipo.Location = new System.Drawing.Point(140, 5);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(877, 28);
            this.cmbTipo.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fin";
            // 
            // dtFechaHasta
            // 
            this.dtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaHasta.Location = new System.Drawing.Point(382, 71);
            this.dtFechaHasta.Name = "dtFechaHasta";
            this.dtFechaHasta.ShowCheckBox = true;
            this.dtFechaHasta.Size = new System.Drawing.Size(139, 26);
            this.dtFechaHasta.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Inicio";
            // 
            // dtFechaDesde
            // 
            this.dtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaDesde.Location = new System.Drawing.Point(192, 71);
            this.dtFechaDesde.Name = "dtFechaDesde";
            this.dtFechaDesde.Size = new System.Drawing.Size(129, 26);
            this.dtFechaDesde.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Observaciones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Entidad Bancaria";
            // 
            // txtObs
            // 
            this.txtObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObs.Location = new System.Drawing.Point(140, 167);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(877, 49);
            this.txtObs.TabIndex = 1;
            // 
            // txtEntidad
            // 
            this.txtEntidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntidad.Location = new System.Drawing.Point(140, 39);
            this.txtEntidad.Name = "txtEntidad";
            this.txtEntidad.Size = new System.Drawing.Size(877, 26);
            this.txtEntidad.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1032, 520);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ver Ahorros";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Ahorros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 553);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ahorros";
            this.Text = "Ahorros";
            this.Load += new System.EventHandler(this.Ahorros_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahorroBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFechaHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFechaDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.TextBox txtEntidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.BindingSource ahorroBindingSource;
        private System.Windows.Forms.Label lTaza;
        private System.Windows.Forms.Label lMonto;
        private System.Windows.Forms.TextBox txtTaza;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoAhorroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn TazaAnual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ganancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDesdeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaHastaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacionesDataGridViewTextBoxColumn;
    }
}