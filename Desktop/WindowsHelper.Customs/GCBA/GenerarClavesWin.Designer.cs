namespace WindowsHelper.Customs.GCBA
{
    partial class GenerarClavesWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerarClavesWin));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bologin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bopass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bogenerar = new System.Windows.Forms.Button();
            this.bolog = new System.Windows.Forms.TextBox();
            this.bulog = new System.Windows.Forms.TextBox();
            this.buauth = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bupass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bulogin = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(341, 242);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bolog);
            this.tabPage1.Controls.Add(this.bogenerar);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.bopass);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.bologin);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(333, 216);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SIR / BO";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bulog);
            this.tabPage2.Controls.Add(this.buauth);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.bupass);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.bulogin);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(333, 216);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "BUI";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bologin
            // 
            this.bologin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bologin.Location = new System.Drawing.Point(111, 16);
            this.bologin.Name = "bologin";
            this.bologin.Size = new System.Drawing.Size(214, 20);
            this.bologin.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Login";
            // 
            // bopass
            // 
            this.bopass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bopass.Location = new System.Drawing.Point(111, 42);
            this.bopass.Name = "bopass";
            this.bopass.Size = new System.Drawing.Size(214, 20);
            this.bopass.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Contraseña";
            // 
            // bogenerar
            // 
            this.bogenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bogenerar.Location = new System.Drawing.Point(204, 68);
            this.bogenerar.Name = "bogenerar";
            this.bogenerar.Size = new System.Drawing.Size(121, 32);
            this.bogenerar.TabIndex = 10;
            this.bogenerar.Text = "Generar Clave SLM";
            this.bogenerar.UseVisualStyleBackColor = true;
            this.bogenerar.Click += new System.EventHandler(this.bogenerar_Click);
            // 
            // bolog
            // 
            this.bolog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bolog.Location = new System.Drawing.Point(8, 106);
            this.bolog.Multiline = true;
            this.bolog.Name = "bolog";
            this.bolog.Size = new System.Drawing.Size(317, 102);
            this.bolog.TabIndex = 11;
            // 
            // bulog
            // 
            this.bulog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bulog.Location = new System.Drawing.Point(8, 108);
            this.bulog.Multiline = true;
            this.bulog.Name = "bulog";
            this.bulog.Size = new System.Drawing.Size(317, 100);
            this.bulog.TabIndex = 17;
            // 
            // buauth
            // 
            this.buauth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buauth.Location = new System.Drawing.Point(170, 70);
            this.buauth.Name = "buauth";
            this.buauth.Size = new System.Drawing.Size(155, 32);
            this.buauth.TabIndex = 16;
            this.buauth.Text = "Generar Clave Auth Basic";
            this.buauth.UseVisualStyleBackColor = true;
            this.buauth.Click += new System.EventHandler(this.buauth_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Contraseña";
            // 
            // bupass
            // 
            this.bupass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bupass.Location = new System.Drawing.Point(109, 44);
            this.bupass.Name = "bupass";
            this.bupass.Size = new System.Drawing.Size(216, 20);
            this.bupass.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Login";
            // 
            // bulogin
            // 
            this.bulogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bulogin.Location = new System.Drawing.Point(109, 18);
            this.bulogin.Name = "bulogin";
            this.bulogin.Size = new System.Drawing.Size(216, 20);
            this.bulogin.TabIndex = 12;
            // 
            // GenerarClavesWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 242);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GenerarClavesWin";
            this.Text = "Generador de Claves";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox bolog;
        private System.Windows.Forms.Button bogenerar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox bopass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bologin;
        private System.Windows.Forms.TextBox bulog;
        private System.Windows.Forms.Button buauth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox bupass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bulogin;
    }
}