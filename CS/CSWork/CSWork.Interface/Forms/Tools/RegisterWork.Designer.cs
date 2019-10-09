namespace CSWork.Interface.Forms.Tools
{
    partial class RegisterWork
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
            this.dtFecha = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.tComment = new System.Windows.Forms.TextBox();
            this.tTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tRestante = new System.Windows.Forms.TextBox();
            this.cbIssues = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dtFecha
            // 
            this.dtFecha.BackColor = System.Drawing.SystemColors.Window;
            this.dtFecha.Location = new System.Drawing.Point(12, 50);
            this.dtFecha.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Comentario";
            // 
            // tComment
            // 
            this.tComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tComment.Location = new System.Drawing.Point(276, 70);
            this.tComment.Margin = new System.Windows.Forms.Padding(4);
            this.tComment.Multiline = true;
            this.tComment.Name = "tComment";
            this.tComment.Size = new System.Drawing.Size(320, 50);
            this.tComment.TabIndex = 3;
            // 
            // tTime
            // 
            this.tTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tTime.Location = new System.Drawing.Point(276, 144);
            this.tTime.Margin = new System.Windows.Forms.Padding(4);
            this.tTime.Name = "tTime";
            this.tTime.Size = new System.Drawing.Size(320, 22);
            this.tTime.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tiempo";
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOK.Location = new System.Drawing.Point(496, 230);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(101, 30);
            this.bOK.TabIndex = 6;
            this.bOK.Text = "Aceptar";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.BOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 170);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Restante (Opcional)";
            // 
            // tRestante
            // 
            this.tRestante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tRestante.Location = new System.Drawing.Point(276, 190);
            this.tRestante.Margin = new System.Windows.Forms.Padding(4);
            this.tRestante.Name = "tRestante";
            this.tRestante.Size = new System.Drawing.Size(321, 22);
            this.tRestante.TabIndex = 7;
            // 
            // cbIssues
            // 
            this.cbIssues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIssues.FormattingEnabled = true;
            this.cbIssues.Location = new System.Drawing.Point(12, 12);
            this.cbIssues.Name = "cbIssues";
            this.cbIssues.Size = new System.Drawing.Size(585, 24);
            this.cbIssues.TabIndex = 9;
            this.cbIssues.TextChanged += new System.EventHandler(this.CbIssues_TextChanged);
            // 
            // RegisterWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 272);
            this.Controls.Add(this.cbIssues);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tRestante);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tTime);
            this.Controls.Add(this.tComment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFecha);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(422, 245);
            this.Name = "RegisterWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Trabajo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar dtFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tComment;
        private System.Windows.Forms.TextBox tTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tRestante;
        private System.Windows.Forms.ComboBox cbIssues;
    }
}