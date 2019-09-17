namespace YerbaSoft.Desktop.PW.Forms
{
    partial class ShowInfoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lPJInfoOffset = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lCoordPJ = new System.Windows.Forms.Label();
            this.lCoordCam = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lGUILast = new System.Windows.Forms.Label();
            this.lGUIFocus = new System.Windows.Forms.Label();
            this.lWinTakeQuest = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lItemInventario = new System.Windows.Forms.Label();
            this.lPJInfoTargetId = new System.Windows.Forms.Label();
            this.lNPCOffset = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lNPCTarget = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Offsets";
            // 
            // lPJInfoOffset
            // 
            this.lPJInfoOffset.AutoSize = true;
            this.lPJInfoOffset.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPJInfoOffset.Location = new System.Drawing.Point(12, 55);
            this.lPJInfoOffset.Name = "lPJInfoOffset";
            this.lPJInfoOffset.Size = new System.Drawing.Size(181, 13);
            this.lPJInfoOffset.TabIndex = 3;
            this.lPJInfoOffset.Text = "PJ Info: FFFFFFFF => FFFFFFFF";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Coords";
            // 
            // lCoordPJ
            // 
            this.lCoordPJ.AutoSize = true;
            this.lCoordPJ.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCoordPJ.Location = new System.Drawing.Point(12, 105);
            this.lCoordPJ.Name = "lCoordPJ";
            this.lCoordPJ.Size = new System.Drawing.Size(253, 13);
            this.lCoordPJ.TabIndex = 6;
            this.lCoordPJ.Text = "Player: 1233.1234 / 1234.1234 / 1234.1234";
            // 
            // lCoordCam
            // 
            this.lCoordCam.AutoSize = true;
            this.lCoordCam.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCoordCam.Location = new System.Drawing.Point(12, 118);
            this.lCoordCam.Name = "lCoordCam";
            this.lCoordCam.Size = new System.Drawing.Size(253, 13);
            this.lCoordCam.TabIndex = 7;
            this.lCoordCam.Text = "Camara: 1233.1234 / 1234.1234 / 1234.1234";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "GUI";
            // 
            // lGUILast
            // 
            this.lGUILast.AutoSize = true;
            this.lGUILast.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGUILast.Location = new System.Drawing.Point(12, 160);
            this.lGUILast.Name = "lGUILast";
            this.lGUILast.Size = new System.Drawing.Size(313, 13);
            this.lGUILast.TabIndex = 9;
            this.lGUILast.Text = "Last : FFFFFFFF => FFFFFFFF => FFFFFFFF => FFFFFFFF";
            // 
            // lGUIFocus
            // 
            this.lGUIFocus.AutoSize = true;
            this.lGUIFocus.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lGUIFocus.Location = new System.Drawing.Point(12, 173);
            this.lGUIFocus.Name = "lGUIFocus";
            this.lGUIFocus.Size = new System.Drawing.Size(313, 13);
            this.lGUIFocus.TabIndex = 10;
            this.lGUIFocus.Text = "Focus: FFFFFFFF => FFFFFFFF => FFFFFFFF => FFFFFFFF";
            // 
            // lWinTakeQuest
            // 
            this.lWinTakeQuest.AutoSize = true;
            this.lWinTakeQuest.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lWinTakeQuest.Location = new System.Drawing.Point(12, 186);
            this.lWinTakeQuest.Name = "lWinTakeQuest";
            this.lWinTakeQuest.Size = new System.Drawing.Size(367, 13);
            this.lWinTakeQuest.TabIndex = 11;
            this.lWinTakeQuest.Text = "Win Take Quest: FFFFFFFF => FFFFFFFF => FFFFFFFF => FFFFFFFF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "Items";
            // 
            // lItemInventario
            // 
            this.lItemInventario.AutoSize = true;
            this.lItemInventario.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lItemInventario.Location = new System.Drawing.Point(12, 231);
            this.lItemInventario.Name = "lItemInventario";
            this.lItemInventario.Size = new System.Drawing.Size(265, 13);
            this.lItemInventario.TabIndex = 13;
            this.lItemInventario.Text = "Inventory: FFFFFFFF => FFFFFFFF => FFFFFFFF";
            // 
            // lPJInfoTargetId
            // 
            this.lPJInfoTargetId.AutoSize = true;
            this.lPJInfoTargetId.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPJInfoTargetId.Location = new System.Drawing.Point(12, 68);
            this.lPJInfoTargetId.Name = "lPJInfoTargetId";
            this.lPJInfoTargetId.Size = new System.Drawing.Size(55, 13);
            this.lPJInfoTargetId.TabIndex = 14;
            this.lPJInfoTargetId.Text = "TargetId";
            // 
            // lNPCOffset
            // 
            this.lNPCOffset.AutoSize = true;
            this.lNPCOffset.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNPCOffset.Location = new System.Drawing.Point(12, 272);
            this.lNPCOffset.Name = "lNPCOffset";
            this.lNPCOffset.Size = new System.Drawing.Size(247, 13);
            this.lNPCOffset.TabIndex = 16;
            this.lNPCOffset.Text = "Offset: FFFFFFFF => FFFFFFFF => FFFFFFFF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "NPC / Mob";
            // 
            // lNPCTarget
            // 
            this.lNPCTarget.AutoSize = true;
            this.lNPCTarget.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNPCTarget.Location = new System.Drawing.Point(12, 285);
            this.lNPCTarget.Name = "lNPCTarget";
            this.lNPCTarget.Size = new System.Drawing.Size(127, 13);
            this.lNPCTarget.TabIndex = 17;
            this.lNPCTarget.Text = "Target NPC: FFFFFFFF";
            // 
            // ShowInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(393, 319);
            this.Controls.Add(this.lNPCTarget);
            this.Controls.Add(this.lNPCOffset);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lPJInfoTargetId);
            this.Controls.Add(this.lItemInventario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lWinTakeQuest);
            this.Controls.Add(this.lGUIFocus);
            this.Controls.Add(this.lGUILast);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lCoordCam);
            this.Controls.Add(this.lCoordPJ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lPJInfoOffset);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowInfoForm";
            this.Opacity = 0.75D;
            this.Text = "ShowInfoForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lPJInfoOffset;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lCoordPJ;
        private System.Windows.Forms.Label lCoordCam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lGUILast;
        private System.Windows.Forms.Label lGUIFocus;
        private System.Windows.Forms.Label lWinTakeQuest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lItemInventario;
        private System.Windows.Forms.Label lPJInfoTargetId;
        private System.Windows.Forms.Label lNPCOffset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lNPCTarget;
    }
}