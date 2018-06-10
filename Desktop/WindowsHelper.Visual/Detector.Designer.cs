namespace WindowsHelper.Visual
{
    partial class Detector
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
            this.animation = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // animation
            // 
            this.animation.Interval = 10;
            this.animation.Tick += new System.EventHandler(this.animation_Tick);
            // 
            // Detector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 271);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Detector";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Detector";
            this.Load += new System.EventHandler(this.Detector_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Detector_Paint);
            this.MouseEnter += new System.EventHandler(this.Detector_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Detector_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer animation;
    }
}