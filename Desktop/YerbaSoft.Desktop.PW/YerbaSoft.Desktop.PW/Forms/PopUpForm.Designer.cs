namespace YerbaSoft.Desktop.PW.Forms
{
    partial class PopUpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopUpForm));
            this.pAttachParent = new System.Windows.Forms.PictureBox();
            this.pPinned = new System.Windows.Forms.PictureBox();
            this.lTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pAttachParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pPinned)).BeginInit();
            this.SuspendLayout();
            // 
            // pAttachParent
            // 
            this.pAttachParent.Image = ((System.Drawing.Image)(resources.GetObject("pAttachParent.Image")));
            this.pAttachParent.Location = new System.Drawing.Point(34, 12);
            this.pAttachParent.Name = "pAttachParent";
            this.pAttachParent.Size = new System.Drawing.Size(16, 16);
            this.pAttachParent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pAttachParent.TabIndex = 4;
            this.pAttachParent.TabStop = false;
            this.pAttachParent.Click += new System.EventHandler(this.PAttachParent_Click);
            // 
            // pPinned
            // 
            this.pPinned.Image = ((System.Drawing.Image)(resources.GetObject("pPinned.Image")));
            this.pPinned.Location = new System.Drawing.Point(12, 12);
            this.pPinned.Name = "pPinned";
            this.pPinned.Size = new System.Drawing.Size(16, 16);
            this.pPinned.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pPinned.TabIndex = 3;
            this.pPinned.TabStop = false;
            this.pPinned.Click += new System.EventHandler(this.PPinned_Click);
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.Location = new System.Drawing.Point(56, 8);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(128, 20);
            this.lTitle.TabIndex = 5;
            this.lTitle.Text = "Título del Form";
            // 
            // PopUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 293);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.pAttachParent);
            this.Controls.Add(this.pPinned);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopUpForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopUpForm";
            ((System.ComponentModel.ISupportInitialize)(this.pAttachParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pPinned)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pAttachParent;
        private System.Windows.Forms.PictureBox pPinned;
        private System.Windows.Forms.Label lTitle;
    }
}