namespace SlotRacer
{
    partial class FormRace
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
            this.pnlRaceDisplay = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblRaceTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLaps = new System.Windows.Forms.Label();
            this.pbCheckeredFlag = new System.Windows.Forms.PictureBox();
            this.pbYellowFlag = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheckeredFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYellowFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRaceDisplay
            // 
            this.pnlRaceDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRaceDisplay.AutoScroll = true;
            this.pnlRaceDisplay.Location = new System.Drawing.Point(12, 59);
            this.pnlRaceDisplay.Name = "pnlRaceDisplay";
            this.pnlRaceDisplay.Size = new System.Drawing.Size(1259, 907);
            this.pnlRaceDisplay.TabIndex = 15;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblRaceTime
            // 
            this.lblRaceTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaceTime.Location = new System.Drawing.Point(135, 20);
            this.lblRaceTime.Name = "lblRaceTime";
            this.lblRaceTime.Size = new System.Drawing.Size(87, 24);
            this.lblRaceTime.TabIndex = 16;
            this.lblRaceTime.Text = "0:00:00";
            this.lblRaceTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "Race Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(260, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Laps:";
            // 
            // lblLaps
            // 
            this.lblLaps.AutoSize = true;
            this.lblLaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaps.Location = new System.Drawing.Point(326, 20);
            this.lblLaps.Name = "lblLaps";
            this.lblLaps.Size = new System.Drawing.Size(38, 24);
            this.lblLaps.TabIndex = 17;
            this.lblLaps.Text = "0/0";
            // 
            // pbCheckeredFlag
            // 
            this.pbCheckeredFlag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCheckeredFlag.Image = global::SlotRacer.Properties.Resources.CheckerdFlag;
            this.pbCheckeredFlag.Location = new System.Drawing.Point(1187, 12);
            this.pbCheckeredFlag.Name = "pbCheckeredFlag";
            this.pbCheckeredFlag.Size = new System.Drawing.Size(39, 41);
            this.pbCheckeredFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCheckeredFlag.TabIndex = 18;
            this.pbCheckeredFlag.TabStop = false;
            this.pbCheckeredFlag.Visible = false;
            // 
            // pbYellowFlag
            // 
            this.pbYellowFlag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbYellowFlag.Image = global::SlotRacer.Properties.Resources.YellowFlag;
            this.pbYellowFlag.Location = new System.Drawing.Point(1232, 12);
            this.pbYellowFlag.Name = "pbYellowFlag";
            this.pbYellowFlag.Size = new System.Drawing.Size(39, 41);
            this.pbYellowFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbYellowFlag.TabIndex = 18;
            this.pbYellowFlag.TabStop = false;
            this.pbYellowFlag.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(980, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // FormRace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 978);
            this.Controls.Add(this.pbCheckeredFlag);
            this.Controls.Add(this.pbYellowFlag);
            this.Controls.Add(this.lblRaceTime);
            this.Controls.Add(this.lblLaps);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnlRaceDisplay);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormRace";
            this.Text = "Race";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRace_FormClosing);
            this.Load += new System.EventHandler(this.FormRace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCheckeredFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYellowFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlRaceDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblRaceTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLaps;
        private System.Windows.Forms.PictureBox pbYellowFlag;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbCheckeredFlag;

    }
}