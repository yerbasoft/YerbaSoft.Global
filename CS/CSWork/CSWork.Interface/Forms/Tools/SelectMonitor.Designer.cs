namespace CSWork.Interface.Forms.Tools
{
    partial class SelectMonitor
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
            this.Canvas = new System.Windows.Forms.Panel();
            this.bOk = new System.Windows.Forms.Button();
            this.bUsePrincipal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Canvas.BackColor = System.Drawing.Color.Silver;
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Canvas.Location = new System.Drawing.Point(12, 12);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(342, 154);
            this.Canvas.TabIndex = 0;
            // 
            // bOk
            // 
            this.bOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOk.Location = new System.Drawing.Point(261, 172);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(93, 31);
            this.bOk.TabIndex = 1;
            this.bOk.Text = "Seleccionar";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.BOk_Click);
            // 
            // bUsePrincipal
            // 
            this.bUsePrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bUsePrincipal.Location = new System.Drawing.Point(12, 172);
            this.bUsePrincipal.Name = "bUsePrincipal";
            this.bUsePrincipal.Size = new System.Drawing.Size(93, 31);
            this.bUsePrincipal.TabIndex = 2;
            this.bUsePrincipal.Text = "Usar Principal";
            this.bUsePrincipal.UseVisualStyleBackColor = true;
            this.bUsePrincipal.Click += new System.EventHandler(this.BUsePrincipal_Click);
            // 
            // SelectMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 215);
            this.Controls.Add(this.bUsePrincipal);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.Canvas);
            this.MinimumSize = new System.Drawing.Size(290, 210);
            this.Name = "SelectMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione el Monitor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bUsePrincipal;
    }
}