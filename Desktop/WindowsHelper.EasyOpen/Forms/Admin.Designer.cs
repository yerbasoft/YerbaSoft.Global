namespace WindowsHelper.EasyOpen.Forms
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.lLinks = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOpenWith = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIcono = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.bUp = new System.Windows.Forms.Button();
            this.bDown = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtParams = new System.Windows.Forms.TextBox();
            this.bDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lLinks
            // 
            this.lLinks.Dock = System.Windows.Forms.DockStyle.Left;
            this.lLinks.FormattingEnabled = true;
            this.lLinks.ItemHeight = 24;
            this.lLinks.Location = new System.Drawing.Point(0, 0);
            this.lLinks.Margin = new System.Windows.Forms.Padding(6);
            this.lLinks.Name = "lLinks";
            this.lLinks.Size = new System.Drawing.Size(255, 244);
            this.lLinks.TabIndex = 0;
            this.lLinks.SelectedIndexChanged += new System.EventHandler(this.lLinks_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "Abrir Con:";
            // 
            // txtOpenWith
            // 
            this.txtOpenWith.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOpenWith.Location = new System.Drawing.Point(454, 117);
            this.txtOpenWith.Name = "txtOpenWith";
            this.txtOpenWith.Size = new System.Drawing.Size(350, 29);
            this.txtOpenWith.TabIndex = 7;
            this.txtOpenWith.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "Icono:";
            // 
            // txtIcono
            // 
            this.txtIcono.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIcono.Location = new System.Drawing.Point(454, 82);
            this.txtIcono.Name = "txtIcono";
            this.txtIcono.Size = new System.Drawing.Size(350, 29);
            this.txtIcono.TabIndex = 6;
            this.txtIcono.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(454, 47);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(350, 29);
            this.txtPath.TabIndex = 5;
            this.txtPath.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Path:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(454, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(350, 29);
            this.txtName.TabIndex = 4;
            this.txtName.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(607, 191);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(197, 41);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bUp
            // 
            this.bUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bUp.Location = new System.Drawing.Point(264, 12);
            this.bUp.Name = "bUp";
            this.bUp.Size = new System.Drawing.Size(36, 36);
            this.bUp.TabIndex = 1;
            this.bUp.UseVisualStyleBackColor = true;
            this.bUp.Click += new System.EventHandler(this.bUp_Click);
            // 
            // bDown
            // 
            this.bDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bDown.Location = new System.Drawing.Point(264, 54);
            this.bDown.Name = "bDown";
            this.bDown.Size = new System.Drawing.Size(36, 36);
            this.bDown.TabIndex = 2;
            this.bDown.UseVisualStyleBackColor = true;
            this.bDown.Click += new System.EventHandler(this.bDown_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(337, 155);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 24);
            this.label6.TabIndex = 21;
            this.label6.Text = "Parametros:";
            // 
            // txtParams
            // 
            this.txtParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParams.Location = new System.Drawing.Point(454, 152);
            this.txtParams.Name = "txtParams";
            this.txtParams.Size = new System.Drawing.Size(350, 29);
            this.txtParams.TabIndex = 8;
            this.txtParams.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // bDelete
            // 
            this.bDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bDelete.Location = new System.Drawing.Point(264, 121);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(36, 36);
            this.bDelete.TabIndex = 3;
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(816, 244);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtParams);
            this.Controls.Add(this.bDown);
            this.Controls.Add(this.bUp);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOpenWith);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIcono);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lLinks);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Admin";
            this.Text = "Administración de Links Útiles";
            this.Load += new System.EventHandler(this.AdminLinks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lLinks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOpenWith;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIcono;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button bUp;
        private System.Windows.Forms.Button bDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtParams;
        private System.Windows.Forms.Button bDelete;
    }
}