namespace WindowsHelper.Cuentas.Forms
{
    partial class Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCodigo = new System.Windows.Forms.ComboBox();
            this.lMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.bAddPlus = new System.Windows.Forms.Button();
            this.bFindFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.bScreenShot = new System.Windows.Forms.Button();
            this.bAddAndClose = new System.Windows.Forms.Button();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lConceptoObs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // cmbCodigo
            // 
            this.cmbCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCodigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodigo.FormattingEnabled = true;
            this.cmbCodigo.Location = new System.Drawing.Point(74, 42);
            this.cmbCodigo.Name = "cmbCodigo";
            this.cmbCodigo.Size = new System.Drawing.Size(432, 26);
            this.cmbCodigo.TabIndex = 1;
            this.cmbCodigo.SelectedIndexChanged += new System.EventHandler(this.CmbCodigo_SelectedIndexChanged);
            // 
            // lMonto
            // 
            this.lMonto.AutoSize = true;
            this.lMonto.Location = new System.Drawing.Point(13, 95);
            this.lMonto.Name = "lMonto";
            this.lMonto.Size = new System.Drawing.Size(51, 18);
            this.lMonto.TabIndex = 2;
            this.lMonto.Text = "Monto";
            // 
            // txtMonto
            // 
            this.txtMonto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMonto.Location = new System.Drawing.Point(75, 92);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(432, 24);
            this.txtMonto.TabIndex = 2;
            this.txtMonto.TextChanged += new System.EventHandler(this.TxtMonto_TextChanged);
            this.txtMonto.Validating += new System.ComponentModel.CancelEventHandler(this.TxtMonto_Validating);
            // 
            // bAddPlus
            // 
            this.bAddPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bAddPlus.Image = ((System.Drawing.Image)(resources.GetObject("bAddPlus.Image")));
            this.bAddPlus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAddPlus.Location = new System.Drawing.Point(406, 207);
            this.bAddPlus.Name = "bAddPlus";
            this.bAddPlus.Size = new System.Drawing.Size(101, 30);
            this.bAddPlus.TabIndex = 7;
            this.bAddPlus.Text = "Agregar +";
            this.bAddPlus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bAddPlus.UseVisualStyleBackColor = true;
            this.bAddPlus.Click += new System.EventHandler(this.BAddPlus_Click);
            // 
            // bFindFile
            // 
            this.bFindFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bFindFile.Image = ((System.Drawing.Image)(resources.GetObject("bFindFile.Image")));
            this.bFindFile.Location = new System.Drawing.Point(440, 122);
            this.bFindFile.Name = "bFindFile";
            this.bFindFile.Size = new System.Drawing.Size(31, 24);
            this.bFindFile.TabIndex = 3;
            this.bFindFile.UseVisualStyleBackColor = true;
            this.bFindFile.Click += new System.EventHandler(this.BFindFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Comprobante";
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(118, 122);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(316, 24);
            this.txtFile.TabIndex = 7;
            // 
            // bScreenShot
            // 
            this.bScreenShot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bScreenShot.Image = ((System.Drawing.Image)(resources.GetObject("bScreenShot.Image")));
            this.bScreenShot.Location = new System.Drawing.Point(477, 122);
            this.bScreenShot.Name = "bScreenShot";
            this.bScreenShot.Size = new System.Drawing.Size(29, 24);
            this.bScreenShot.TabIndex = 4;
            this.bScreenShot.UseVisualStyleBackColor = true;
            this.bScreenShot.Click += new System.EventHandler(this.BScreenShot_Click);
            // 
            // bAddAndClose
            // 
            this.bAddAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bAddAndClose.Image = ((System.Drawing.Image)(resources.GetObject("bAddAndClose.Image")));
            this.bAddAndClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAddAndClose.Location = new System.Drawing.Point(299, 207);
            this.bAddAndClose.Name = "bAddAndClose";
            this.bAddAndClose.Size = new System.Drawing.Size(101, 30);
            this.bAddAndClose.TabIndex = 6;
            this.bAddAndClose.Text = "Agregar";
            this.bAddAndClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bAddAndClose.UseVisualStyleBackColor = true;
            this.bAddAndClose.Click += new System.EventHandler(this.BAddAndClose_Click);
            // 
            // dtFecha
            // 
            this.dtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFecha.Location = new System.Drawing.Point(75, 12);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(431, 24);
            this.dtFecha.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Fecha";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtObs
            // 
            this.txtObs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObs.Location = new System.Drawing.Point(74, 152);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(432, 49);
            this.txtObs.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Obs.";
            // 
            // lConceptoObs
            // 
            this.lConceptoObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lConceptoObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lConceptoObs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lConceptoObs.Location = new System.Drawing.Point(13, 71);
            this.lConceptoObs.Name = "lConceptoObs";
            this.lConceptoObs.Size = new System.Drawing.Size(494, 18);
            this.lConceptoObs.TabIndex = 14;
            this.lConceptoObs.Text = "Concepto Observaciones";
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 249);
            this.Controls.Add(this.lConceptoObs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.bAddAndClose);
            this.Controls.Add(this.bScreenShot);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bFindFile);
            this.Controls.Add(this.bAddPlus);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lMonto);
            this.Controls.Add(this.cmbCodigo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Movimiento";
            this.Load += new System.EventHandler(this.Add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCodigo;
        private System.Windows.Forms.Label lMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button bAddPlus;
        private System.Windows.Forms.Button bFindFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button bScreenShot;
        private System.Windows.Forms.Button bAddAndClose;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lConceptoObs;
    }
}