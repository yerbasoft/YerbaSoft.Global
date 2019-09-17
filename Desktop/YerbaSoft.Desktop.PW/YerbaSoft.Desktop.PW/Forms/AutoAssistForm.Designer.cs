namespace YerbaSoft.Desktop.PW.Forms
{
    partial class AutoAssistForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lFollow = new System.Windows.Forms.Label();
            this.lAssistPlayer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lAssistKey = new System.Windows.Forms.Label();
            this.lAssistTime = new System.Windows.Forms.Label();
            this.lPickKey = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lPickTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Follow";
            // 
            // lFollow
            // 
            this.lFollow.AutoSize = true;
            this.lFollow.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFollow.Location = new System.Drawing.Point(12, 73);
            this.lFollow.Name = "lFollow";
            this.lFollow.Size = new System.Drawing.Size(85, 13);
            this.lFollow.TabIndex = 1;
            this.lFollow.Text = "Orden Party: ";
            // 
            // lAssistPlayer
            // 
            this.lAssistPlayer.AutoSize = true;
            this.lAssistPlayer.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAssistPlayer.Location = new System.Drawing.Point(12, 133);
            this.lAssistPlayer.Name = "lAssistPlayer";
            this.lAssistPlayer.Size = new System.Drawing.Size(49, 13);
            this.lAssistPlayer.TabIndex = 3;
            this.lAssistPlayer.Text = "Party: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Assist";
            // 
            // lAssistKey
            // 
            this.lAssistKey.AutoSize = true;
            this.lAssistKey.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAssistKey.Location = new System.Drawing.Point(12, 156);
            this.lAssistKey.Name = "lAssistKey";
            this.lAssistKey.Size = new System.Drawing.Size(37, 13);
            this.lAssistKey.TabIndex = 4;
            this.lAssistKey.Text = "Key: ";
            // 
            // lAssistTime
            // 
            this.lAssistTime.AutoSize = true;
            this.lAssistTime.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAssistTime.Location = new System.Drawing.Point(12, 179);
            this.lAssistTime.Name = "lAssistTime";
            this.lAssistTime.Size = new System.Drawing.Size(73, 13);
            this.lAssistTime.TabIndex = 5;
            this.lAssistTime.Text = "Frecuency: ";
            // 
            // lPickKey
            // 
            this.lPickKey.AutoSize = true;
            this.lPickKey.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPickKey.Location = new System.Drawing.Point(12, 236);
            this.lPickKey.Name = "lPickKey";
            this.lPickKey.Size = new System.Drawing.Size(31, 13);
            this.lPickKey.TabIndex = 7;
            this.lPickKey.Text = "Key:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "PickUp";
            // 
            // lPickTime
            // 
            this.lPickTime.AutoSize = true;
            this.lPickTime.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPickTime.Location = new System.Drawing.Point(12, 258);
            this.lPickTime.Name = "lPickTime";
            this.lPickTime.Size = new System.Drawing.Size(37, 13);
            this.lPickTime.TabIndex = 8;
            this.lPickTime.Text = "Time:";
            // 
            // AutoAssistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(220, 291);
            this.Controls.Add(this.lPickTime);
            this.Controls.Add(this.lPickKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lAssistTime);
            this.Controls.Add(this.lAssistKey);
            this.Controls.Add(this.lAssistPlayer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lFollow);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AutoAssistForm";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoAsssitForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lFollow;
        private System.Windows.Forms.Label lAssistPlayer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lAssistKey;
        private System.Windows.Forms.Label lAssistTime;
        private System.Windows.Forms.Label lPickKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lPickTime;
    }
}