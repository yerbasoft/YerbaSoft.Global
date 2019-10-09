namespace CSWork.Interface.Forms
{
    partial class Login
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
            this.tUser = new System.Windows.Forms.TextBox();
            this.tToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bOk = new System.Windows.Forms.Button();
            this.bObtener = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tUser
            // 
            this.tUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tUser.Location = new System.Drawing.Point(79, 43);
            this.tUser.Margin = new System.Windows.Forms.Padding(4);
            this.tUser.Name = "tUser";
            this.tUser.Size = new System.Drawing.Size(339, 22);
            this.tUser.TabIndex = 0;
            this.tUser.Text = "@cardinalsystems.com.ar";
            this.tUser.Enter += new System.EventHandler(this.TUser_Enter);
            // 
            // tToken
            // 
            this.tToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tToken.Location = new System.Drawing.Point(79, 75);
            this.tToken.Margin = new System.Windows.Forms.Padding(4);
            this.tToken.Name = "tToken";
            this.tToken.Size = new System.Drawing.Size(309, 22);
            this.tToken.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Token:";
            // 
            // bOk
            // 
            this.bOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bOk.Location = new System.Drawing.Point(300, 105);
            this.bOk.Margin = new System.Windows.Forms.Padding(4);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(118, 38);
            this.bOk.TabIndex = 4;
            this.bOk.Text = "Acceder";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.BOk_Click);
            // 
            // bObtener
            // 
            this.bObtener.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bObtener.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bObtener.Location = new System.Drawing.Point(396, 75);
            this.bObtener.Margin = new System.Windows.Forms.Padding(4);
            this.bObtener.Name = "bObtener";
            this.bObtener.Size = new System.Drawing.Size(22, 22);
            this.bObtener.TabIndex = 5;
            this.bObtener.UseVisualStyleBackColor = true;
            this.bObtener.Click += new System.EventHandler(this.BObtener_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Url:";
            // 
            // tUrl
            // 
            this.tUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tUrl.Location = new System.Drawing.Point(79, 13);
            this.tUrl.Margin = new System.Windows.Forms.Padding(4);
            this.tUrl.Name = "tUrl";
            this.tUrl.Size = new System.Drawing.Size(339, 22);
            this.tUrl.TabIndex = 6;
            this.tUrl.Text = "https://cardinalconsulting.atlassian.net";
            // 
            // Login
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 153);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tUrl);
            this.Controls.Add(this.bObtener);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tToken);
            this.Controls.Add(this.tUser);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceder a Atlassian";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tUser;
        private System.Windows.Forms.TextBox tToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bObtener;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tUrl;
    }
}