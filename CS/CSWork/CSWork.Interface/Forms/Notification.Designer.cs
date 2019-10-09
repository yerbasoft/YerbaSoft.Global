namespace CSWork.Interface.Forms
{
    partial class Notification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notification));
            this.lHeader = new System.Windows.Forms.Label();
            this.iIcon = new System.Windows.Forms.PictureBox();
            this.lBody = new System.Windows.Forms.Label();
            this.iClose = new System.Windows.Forms.PictureBox();
            this.tAutoClose = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.iIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lHeader
            // 
            this.lHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lHeader.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHeader.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lHeader.Location = new System.Drawing.Point(54, 12);
            this.lHeader.Name = "lHeader";
            this.lHeader.Size = new System.Drawing.Size(358, 36);
            this.lHeader.TabIndex = 0;
            this.lHeader.Text = "Titulo de la Notificación y soy demaciado largo asiqe no sé como va a entrar";
            this.lHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iIcon
            // 
            this.iIcon.Location = new System.Drawing.Point(12, 12);
            this.iIcon.Name = "iIcon";
            this.iIcon.Size = new System.Drawing.Size(36, 36);
            this.iIcon.TabIndex = 1;
            this.iIcon.TabStop = false;
            // 
            // lBody
            // 
            this.lBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBody.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lBody.Location = new System.Drawing.Point(12, 51);
            this.lBody.Name = "lBody";
            this.lBody.Size = new System.Drawing.Size(424, 62);
            this.lBody.TabIndex = 2;
            this.lBody.Text = resources.GetString("lBody.Text");
            this.lBody.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iClose
            // 
            this.iClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iClose.Image = ((System.Drawing.Image)(resources.GetObject("iClose.Image")));
            this.iClose.Location = new System.Drawing.Point(418, 12);
            this.iClose.Name = "iClose";
            this.iClose.Size = new System.Drawing.Size(18, 18);
            this.iClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iClose.TabIndex = 5;
            this.iClose.TabStop = false;
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(448, 204);
            this.Controls.Add(this.iClose);
            this.Controls.Add(this.lBody);
            this.Controls.Add(this.iIcon);
            this.Controls.Add(this.lHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notification";
            this.Opacity = 0.3D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Notification";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.iIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lHeader;
        private System.Windows.Forms.PictureBox iIcon;
        private System.Windows.Forms.Label lBody;
        private System.Windows.Forms.PictureBox iClose;
        private System.Windows.Forms.Timer tAutoClose;
    }
}