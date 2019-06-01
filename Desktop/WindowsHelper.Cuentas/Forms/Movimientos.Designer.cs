namespace WindowsHelper.Cuentas.Forms
{
    partial class Movimientos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Movimientos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bOpenRef = new System.Windows.Forms.Button();
            this.bScreenShot = new System.Windows.Forms.Button();
            this.bFindFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.lMonto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbConcepto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.bDelete = new System.Windows.Forms.Button();
            this.bOk = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conceptoNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creaFechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movimientoDataSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bRemoveRef = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimientoDataSourceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.bRemoveRef);
            this.panel1.Controls.Add(this.bOpenRef);
            this.panel1.Controls.Add(this.bScreenShot);
            this.panel1.Controls.Add(this.bFindFile);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtRef);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtObs);
            this.panel1.Controls.Add(this.lMonto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbConcepto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtFecha);
            this.panel1.Controls.Add(this.txtMonto);
            this.panel1.Controls.Add(this.bDelete);
            this.panel1.Controls.Add(this.bOk);
            this.panel1.Location = new System.Drawing.Point(18, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 239);
            this.panel1.TabIndex = 0;
            // 
            // bOpenRef
            // 
            this.bOpenRef.Image = ((System.Drawing.Image)(resources.GetObject("bOpenRef.Image")));
            this.bOpenRef.Location = new System.Drawing.Point(117, 158);
            this.bOpenRef.Name = "bOpenRef";
            this.bOpenRef.Size = new System.Drawing.Size(31, 24);
            this.bOpenRef.TabIndex = 15;
            this.bOpenRef.UseVisualStyleBackColor = true;
            this.bOpenRef.Click += new System.EventHandler(this.BOpenRef_Click);
            // 
            // bScreenShot
            // 
            this.bScreenShot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bScreenShot.Image = ((System.Drawing.Image)(resources.GetObject("bScreenShot.Image")));
            this.bScreenShot.Location = new System.Drawing.Point(845, 158);
            this.bScreenShot.Name = "bScreenShot";
            this.bScreenShot.Size = new System.Drawing.Size(29, 24);
            this.bScreenShot.TabIndex = 14;
            this.bScreenShot.UseVisualStyleBackColor = true;
            this.bScreenShot.Click += new System.EventHandler(this.BScreenShot_Click);
            // 
            // bFindFile
            // 
            this.bFindFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bFindFile.Image = ((System.Drawing.Image)(resources.GetObject("bFindFile.Image")));
            this.bFindFile.Location = new System.Drawing.Point(808, 158);
            this.bFindFile.Name = "bFindFile";
            this.bFindFile.Size = new System.Drawing.Size(31, 24);
            this.bFindFile.TabIndex = 13;
            this.bFindFile.UseVisualStyleBackColor = true;
            this.bFindFile.Click += new System.EventHandler(this.BFindFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Comprobante";
            // 
            // txtRef
            // 
            this.txtRef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRef.Location = new System.Drawing.Point(154, 158);
            this.txtRef.Name = "txtRef";
            this.txtRef.ReadOnly = true;
            this.txtRef.Size = new System.Drawing.Size(611, 24);
            this.txtRef.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(656, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 30);
            this.button1.TabIndex = 10;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Observaciones";
            // 
            // txtObs
            // 
            this.txtObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObs.Location = new System.Drawing.Point(117, 95);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(757, 57);
            this.txtObs.TabIndex = 8;
            // 
            // lMonto
            // 
            this.lMonto.AutoSize = true;
            this.lMonto.Location = new System.Drawing.Point(3, 68);
            this.lMonto.Name = "lMonto";
            this.lMonto.Size = new System.Drawing.Size(51, 18);
            this.lMonto.TabIndex = 7;
            this.lMonto.Text = "Monto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Concepto";
            // 
            // cbConcepto
            // 
            this.cbConcepto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConcepto.FormattingEnabled = true;
            this.cbConcepto.Location = new System.Drawing.Point(117, 33);
            this.cbConcepto.Name = "cbConcepto";
            this.cbConcepto.Size = new System.Drawing.Size(757, 26);
            this.cbConcepto.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha";
            // 
            // dtFecha
            // 
            this.dtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFecha.Location = new System.Drawing.Point(117, 3);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(757, 24);
            this.dtFecha.TabIndex = 3;
            // 
            // txtMonto
            // 
            this.txtMonto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMonto.Location = new System.Drawing.Point(117, 65);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(757, 24);
            this.txtMonto.TabIndex = 2;
            this.txtMonto.TextChanged += new System.EventHandler(this.TxtMonto_TextChanged);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(3, 206);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(106, 30);
            this.bDelete.TabIndex = 1;
            this.bDelete.Text = "Eliminar";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.BDelete_Click);
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(768, 206);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(106, 30);
            this.bOk.TabIndex = 0;
            this.bOk.Text = "Grabar";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.BOk_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.Grid);
            this.panel3.Location = new System.Drawing.Point(18, 264);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(877, 244);
            this.panel3.TabIndex = 2;
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.AllowUserToOrderColumns = true;
            this.Grid.AutoGenerateColumns = false;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaDataGridViewTextBoxColumn,
            this.conceptoNameDataGridViewTextBoxColumn,
            this.montoDataGridViewTextBoxColumn,
            this.observacionesDataGridViewTextBoxColumn,
            this.creaFechaDataGridViewTextBoxColumn});
            this.Grid.DataSource = this.movimientoDataSourceBindingSource;
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.Location = new System.Drawing.Point(0, 0);
            this.Grid.Margin = new System.Windows.Forms.Padding(4);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(877, 244);
            this.Grid.TabIndex = 0;
            this.Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellContentClick);
            this.Grid.SelectionChanged += new System.EventHandler(this.Grid_SelectionChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // conceptoNameDataGridViewTextBoxColumn
            // 
            this.conceptoNameDataGridViewTextBoxColumn.DataPropertyName = "ConceptoName";
            this.conceptoNameDataGridViewTextBoxColumn.HeaderText = "Concepto";
            this.conceptoNameDataGridViewTextBoxColumn.Name = "conceptoNameDataGridViewTextBoxColumn";
            this.conceptoNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.conceptoNameDataGridViewTextBoxColumn.Width = 250;
            // 
            // montoDataGridViewTextBoxColumn
            // 
            this.montoDataGridViewTextBoxColumn.DataPropertyName = "Monto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.montoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.montoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoDataGridViewTextBoxColumn.Name = "montoDataGridViewTextBoxColumn";
            this.montoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // observacionesDataGridViewTextBoxColumn
            // 
            this.observacionesDataGridViewTextBoxColumn.DataPropertyName = "Observaciones";
            this.observacionesDataGridViewTextBoxColumn.HeaderText = "Observaciones";
            this.observacionesDataGridViewTextBoxColumn.Name = "observacionesDataGridViewTextBoxColumn";
            this.observacionesDataGridViewTextBoxColumn.ReadOnly = true;
            this.observacionesDataGridViewTextBoxColumn.Width = 250;
            // 
            // creaFechaDataGridViewTextBoxColumn
            // 
            this.creaFechaDataGridViewTextBoxColumn.DataPropertyName = "CreaFecha";
            this.creaFechaDataGridViewTextBoxColumn.HeaderText = "Creación";
            this.creaFechaDataGridViewTextBoxColumn.Name = "creaFechaDataGridViewTextBoxColumn";
            this.creaFechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.creaFechaDataGridViewTextBoxColumn.Width = 115;
            // 
            // movimientoDataSourceBindingSource
            // 
            this.movimientoDataSourceBindingSource.DataSource = typeof(WindowsHelper.Cuentas.DTO.DataSource.MovimientoDataSource);
            // 
            // bRemoveRef
            // 
            this.bRemoveRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRemoveRef.Image = ((System.Drawing.Image)(resources.GetObject("bRemoveRef.Image")));
            this.bRemoveRef.Location = new System.Drawing.Point(771, 158);
            this.bRemoveRef.Name = "bRemoveRef";
            this.bRemoveRef.Size = new System.Drawing.Size(31, 24);
            this.bRemoveRef.TabIndex = 16;
            this.bRemoveRef.UseVisualStyleBackColor = true;
            this.bRemoveRef.Click += new System.EventHandler(this.BRemoveRef_Click);
            // 
            // Movimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 521);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Movimientos";
            this.Text = "Movimientos";
            this.Load += new System.EventHandler(this.Movimientos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimientoDataSourceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.BindingSource movimientoDataSourceBindingSource;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label lMonto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbConcepto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conceptoNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creaFechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRef;
        private System.Windows.Forms.Button bScreenShot;
        private System.Windows.Forms.Button bFindFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bOpenRef;
        private System.Windows.Forms.Button bRemoveRef;
    }
}