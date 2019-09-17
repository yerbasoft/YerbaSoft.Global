namespace YerbaSoft.Desktop.PW.Forms
{
    partial class AutoSpotForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoSpotForm));
            this.lPickTime = new System.Windows.Forms.Label();
            this.lPickKey = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lAssist = new System.Windows.Forms.Label();
            this.lBuffCast = new System.Windows.Forms.Label();
            this.lBuffExpire = new System.Windows.Forms.Label();
            this.lBuffKey = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lAssitMob = new System.Windows.Forms.Label();
            this.pAssistMobRefresh = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pAssistMobRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // lPickTime
            // 
            this.lPickTime.AutoSize = true;
            this.lPickTime.Location = new System.Drawing.Point(12, 275);
            this.lPickTime.Name = "lPickTime";
            this.lPickTime.Size = new System.Drawing.Size(33, 13);
            this.lPickTime.TabIndex = 21;
            this.lPickTime.Text = "Time:";
            // 
            // lPickKey
            // 
            this.lPickKey.AutoSize = true;
            this.lPickKey.Location = new System.Drawing.Point(12, 253);
            this.lPickKey.Name = "lPickKey";
            this.lPickKey.Size = new System.Drawing.Size(28, 13);
            this.lPickKey.TabIndex = 20;
            this.lPickKey.Text = "Key:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Pick Up";
            // 
            // lAssist
            // 
            this.lAssist.AutoSize = true;
            this.lAssist.Location = new System.Drawing.Point(12, 169);
            this.lAssist.Name = "lAssist";
            this.lAssist.Size = new System.Drawing.Size(37, 13);
            this.lAssist.TabIndex = 18;
            this.lAssist.Text = "Assist:";
            // 
            // lBuffCast
            // 
            this.lBuffCast.AutoSize = true;
            this.lBuffCast.Location = new System.Drawing.Point(12, 115);
            this.lBuffCast.Name = "lBuffCast";
            this.lBuffCast.Size = new System.Drawing.Size(57, 13);
            this.lBuffCast.TabIndex = 17;
            this.lBuffCast.Text = "Cast Time:";
            // 
            // lBuffExpire
            // 
            this.lBuffExpire.AutoSize = true;
            this.lBuffExpire.Location = new System.Drawing.Point(12, 92);
            this.lBuffExpire.Name = "lBuffExpire";
            this.lBuffExpire.Size = new System.Drawing.Size(65, 13);
            this.lBuffExpire.TabIndex = 16;
            this.lBuffExpire.Text = "Expire Time:";
            // 
            // lBuffKey
            // 
            this.lBuffKey.AutoSize = true;
            this.lBuffKey.Location = new System.Drawing.Point(12, 70);
            this.lBuffKey.Name = "lBuffKey";
            this.lBuffKey.Size = new System.Drawing.Size(28, 13);
            this.lBuffKey.TabIndex = 15;
            this.lBuffKey.Text = "Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Selección de Mobs";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Buffs";
            // 
            // lAssitMob
            // 
            this.lAssitMob.AutoSize = true;
            this.lAssitMob.Location = new System.Drawing.Point(40, 190);
            this.lAssitMob.Name = "lAssitMob";
            this.lAssitMob.Size = new System.Drawing.Size(58, 13);
            this.lAssitMob.TabIndex = 22;
            this.lAssitMob.Text = "Mob: none";
            // 
            // pAssistMobRefresh
            // 
            this.pAssistMobRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pAssistMobRefresh.Image")));
            this.pAssistMobRefresh.Location = new System.Drawing.Point(15, 187);
            this.pAssistMobRefresh.Name = "pAssistMobRefresh";
            this.pAssistMobRefresh.Size = new System.Drawing.Size(19, 19);
            this.pAssistMobRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pAssistMobRefresh.TabIndex = 23;
            this.pAssistMobRefresh.TabStop = false;
            this.pAssistMobRefresh.Click += new System.EventHandler(this.PAssistMobRefresh_Click);
            // 
            // AutoSpotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(183, 324);
            this.Controls.Add(this.pAssistMobRefresh);
            this.Controls.Add(this.lAssitMob);
            this.Controls.Add(this.lPickTime);
            this.Controls.Add(this.lPickKey);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lAssist);
            this.Controls.Add(this.lBuffCast);
            this.Controls.Add(this.lBuffExpire);
            this.Controls.Add(this.lBuffKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AutoSpotForm";
            this.Opacity = 0.75D;
            this.Text = "AutoSpotForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pAssistMobRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lBuffKey;
        private System.Windows.Forms.Label lBuffExpire;
        private System.Windows.Forms.Label lBuffCast;
        private System.Windows.Forms.Label lAssist;
        private System.Windows.Forms.Label lPickTime;
        private System.Windows.Forms.Label lPickKey;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lAssitMob;
        private System.Windows.Forms.PictureBox pAssistMobRefresh;
    }
}