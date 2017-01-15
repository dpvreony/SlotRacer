namespace SlotRacerGui
{
    partial class FormRaceWindow
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
            this.pnlCarDisplay = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLap = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlCountDown = new System.Windows.Forms.Panel();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlCountDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCarDisplay
            // 
            this.pnlCarDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCarDisplay.Location = new System.Drawing.Point(12, 57);
            this.pnlCarDisplay.Name = "pnlCarDisplay";
            this.pnlCarDisplay.Size = new System.Drawing.Size(1026, 494);
            this.pnlCarDisplay.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLap);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1050, 51);
            this.panel1.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(96, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(112, 31);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "0:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Time";
            // 
            // lblLap
            // 
            this.lblLap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLap.AutoSize = true;
            this.lblLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLap.Location = new System.Drawing.Point(930, 9);
            this.lblLap.Name = "lblLap";
            this.lblLap.Size = new System.Drawing.Size(30, 31);
            this.lblLap.TabIndex = 10;
            this.lblLap.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(862, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 31);
            this.label2.TabIndex = 11;
            this.label2.Text = "Lap";
            // 
            // pnlCountDown
            // 
            this.pnlCountDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCountDown.BackColor = System.Drawing.Color.White;
            this.pnlCountDown.Controls.Add(this.lblCountDown);
            this.pnlCountDown.Location = new System.Drawing.Point(418, 114);
            this.pnlCountDown.Name = "pnlCountDown";
            this.pnlCountDown.Size = new System.Drawing.Size(296, 314);
            this.pnlCountDown.TabIndex = 0;
            this.pnlCountDown.Visible = false;
            // 
            // lblCountDown
            // 
            this.lblCountDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 200F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.Location = new System.Drawing.Point(14, 6);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(276, 302);
            this.lblCountDown.TabIndex = 0;
            this.lblCountDown.Text = "5";
            // 
            // FormRaceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 563);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlCountDown);
            this.Controls.Add(this.pnlCarDisplay);
            this.Name = "FormRaceWindow";
            this.Text = "Race Window";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlCountDown.ResumeLayout(false);
            this.pnlCountDown.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCarDisplay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlCountDown;
        private System.Windows.Forms.Label lblCountDown;
    }
}