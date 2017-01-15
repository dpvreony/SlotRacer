namespace SlotRacerGui
{
    partial class FormMain
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLap = new System.Windows.Forms.Label();
            this.carDisplay6 = new SlotRacerGui.Controls.CarStatusDisplay();
            this.carDisplay5 = new SlotRacerGui.Controls.CarStatusDisplay();
            this.carDisplay4 = new SlotRacerGui.Controls.CarStatusDisplay();
            this.carDisplay3 = new SlotRacerGui.Controls.CarStatusDisplay();
            this.carDisplay2 = new SlotRacerGui.Controls.CarStatusDisplay();
            this.carDisplay1 = new SlotRacerGui.Controls.CarStatusDisplay();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStart = new System.Windows.Forms.ToolStripMenuItem();
            this.cmboRaceType = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnectionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 366);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(539, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(79, 17);
            this.lblConnectionStatus.Text = "Disconnected";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Time";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(96, 35);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(112, 31);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "0:00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(320, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lap";
            // 
            // lblLap
            // 
            this.lblLap.AutoSize = true;
            this.lblLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLap.Location = new System.Drawing.Point(388, 35);
            this.lblLap.Name = "lblLap";
            this.lblLap.Size = new System.Drawing.Size(30, 31);
            this.lblLap.TabIndex = 7;
            this.lblLap.Text = "0";
            // 
            // carDisplay6
            // 
            this.carDisplay6.BestTime = 0F;
            this.carDisplay6.BrakeOn = false;
            this.carDisplay6.DisplayHeadings = false;
            this.carDisplay6.GhostPower = 0;
            this.carDisplay6.IdText = "6";
            this.carDisplay6.LaneChangeOn = false;
            this.carDisplay6.LapCount = 100;
            this.carDisplay6.LapTime = 0F;
            this.carDisplay6.LedOn = false;
            this.carDisplay6.Location = new System.Drawing.Point(441, 106);
            this.carDisplay6.MaxPower = 100;
            this.carDisplay6.Name = "carDisplay6";
            this.carDisplay6.Power = "0";
            this.carDisplay6.Size = new System.Drawing.Size(64, 257);
            this.carDisplay6.TabIndex = 6;
            this.carDisplay6.LedChanged += new System.EventHandler(this.chkLed_CheckedChanged);
            this.carDisplay6.MaxPowerChanged += new System.EventHandler(this.carDisplay_MaxPowerChanged);
            this.carDisplay6.GhostPowerChanged += new System.EventHandler(this.carDisplay_GhostPowerChanged);
            // 
            // carDisplay5
            // 
            this.carDisplay5.BestTime = 0F;
            this.carDisplay5.BrakeOn = false;
            this.carDisplay5.DisplayHeadings = false;
            this.carDisplay5.GhostPower = 0;
            this.carDisplay5.IdText = "5";
            this.carDisplay5.LaneChangeOn = false;
            this.carDisplay5.LapCount = 100;
            this.carDisplay5.LapTime = 0F;
            this.carDisplay5.LedOn = false;
            this.carDisplay5.Location = new System.Drawing.Point(371, 106);
            this.carDisplay5.MaxPower = 100;
            this.carDisplay5.Name = "carDisplay5";
            this.carDisplay5.Power = "0";
            this.carDisplay5.Size = new System.Drawing.Size(64, 257);
            this.carDisplay5.TabIndex = 6;
            this.carDisplay5.LedChanged += new System.EventHandler(this.chkLed_CheckedChanged);
            this.carDisplay5.MaxPowerChanged += new System.EventHandler(this.carDisplay_MaxPowerChanged);
            this.carDisplay5.GhostPowerChanged += new System.EventHandler(this.carDisplay_GhostPowerChanged);
            // 
            // carDisplay4
            // 
            this.carDisplay4.BestTime = 0F;
            this.carDisplay4.BrakeOn = false;
            this.carDisplay4.DisplayHeadings = false;
            this.carDisplay4.GhostPower = 0;
            this.carDisplay4.IdText = "4";
            this.carDisplay4.LaneChangeOn = false;
            this.carDisplay4.LapCount = 100;
            this.carDisplay4.LapTime = 0F;
            this.carDisplay4.LedOn = false;
            this.carDisplay4.Location = new System.Drawing.Point(301, 106);
            this.carDisplay4.MaxPower = 100;
            this.carDisplay4.Name = "carDisplay4";
            this.carDisplay4.Power = "0";
            this.carDisplay4.Size = new System.Drawing.Size(64, 257);
            this.carDisplay4.TabIndex = 6;
            this.carDisplay4.LedChanged += new System.EventHandler(this.chkLed_CheckedChanged);
            this.carDisplay4.MaxPowerChanged += new System.EventHandler(this.carDisplay_MaxPowerChanged);
            this.carDisplay4.GhostPowerChanged += new System.EventHandler(this.carDisplay_GhostPowerChanged);
            // 
            // carDisplay3
            // 
            this.carDisplay3.BestTime = 0F;
            this.carDisplay3.BrakeOn = false;
            this.carDisplay3.DisplayHeadings = false;
            this.carDisplay3.GhostPower = 0;
            this.carDisplay3.IdText = "3";
            this.carDisplay3.LaneChangeOn = false;
            this.carDisplay3.LapCount = 100;
            this.carDisplay3.LapTime = 0F;
            this.carDisplay3.LedOn = false;
            this.carDisplay3.Location = new System.Drawing.Point(231, 106);
            this.carDisplay3.MaxPower = 30;
            this.carDisplay3.Name = "carDisplay3";
            this.carDisplay3.Power = "0";
            this.carDisplay3.Size = new System.Drawing.Size(64, 257);
            this.carDisplay3.TabIndex = 6;
            this.carDisplay3.LedChanged += new System.EventHandler(this.chkLed_CheckedChanged);
            this.carDisplay3.MaxPowerChanged += new System.EventHandler(this.carDisplay_MaxPowerChanged);
            this.carDisplay3.GhostPowerChanged += new System.EventHandler(this.carDisplay_GhostPowerChanged);
            // 
            // carDisplay2
            // 
            this.carDisplay2.BestTime = 0F;
            this.carDisplay2.BrakeOn = false;
            this.carDisplay2.DisplayHeadings = false;
            this.carDisplay2.GhostPower = 0;
            this.carDisplay2.IdText = "2";
            this.carDisplay2.LaneChangeOn = false;
            this.carDisplay2.LapCount = 100;
            this.carDisplay2.LapTime = 0F;
            this.carDisplay2.LedOn = false;
            this.carDisplay2.Location = new System.Drawing.Point(161, 106);
            this.carDisplay2.MaxPower = 100;
            this.carDisplay2.Name = "carDisplay2";
            this.carDisplay2.Power = "0";
            this.carDisplay2.Size = new System.Drawing.Size(64, 257);
            this.carDisplay2.TabIndex = 6;
            this.carDisplay2.LedChanged += new System.EventHandler(this.chkLed_CheckedChanged);
            this.carDisplay2.MaxPowerChanged += new System.EventHandler(this.carDisplay_MaxPowerChanged);
            this.carDisplay2.GhostPowerChanged += new System.EventHandler(this.carDisplay_GhostPowerChanged);
            // 
            // carDisplay1
            // 
            this.carDisplay1.BestTime = 0F;
            this.carDisplay1.BrakeOn = false;
            this.carDisplay1.DisplayHeadings = true;
            this.carDisplay1.GhostPower = 0;
            this.carDisplay1.IdText = "1";
            this.carDisplay1.LaneChangeOn = false;
            this.carDisplay1.LapCount = 100;
            this.carDisplay1.LapTime = 0F;
            this.carDisplay1.LedOn = false;
            this.carDisplay1.Location = new System.Drawing.Point(12, 106);
            this.carDisplay1.MaxPower = 30;
            this.carDisplay1.Name = "carDisplay1";
            this.carDisplay1.Power = "0";
            this.carDisplay1.Size = new System.Drawing.Size(143, 257);
            this.carDisplay1.TabIndex = 6;
            this.carDisplay1.LedChanged += new System.EventHandler(this.chkLed_CheckedChanged);
            this.carDisplay1.MaxPowerChanged += new System.EventHandler(this.carDisplay_MaxPowerChanged);
            this.carDisplay1.GhostPowerChanged += new System.EventHandler(this.carDisplay_GhostPowerChanged);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSettings});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // btnSettings
            // 
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(116, 22);
            this.btnSettings.Text = "Settings";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(64, 23);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnStart
            // 
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(43, 23);
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cmboRaceType
            // 
            this.cmboRaceType.AutoCompleteCustomSource.AddRange(new string[] {
            "Practice",
            "Qualifying",
            "F1",
            "Endurance"});
            this.cmboRaceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRaceType.Items.AddRange(new object[] {
            "Practice",
            "Qualifying",
            "F1",
            "Endurance"});
            this.cmboRaceType.Name = "cmboRaceType";
            this.cmboRaceType.Size = new System.Drawing.Size(121, 23);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.btnConnect,
            this.btnStart,
            this.cmboRaceType});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(539, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 388);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblLap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.carDisplay6);
            this.Controls.Add(this.carDisplay5);
            this.Controls.Add(this.carDisplay4);
            this.Controls.Add(this.carDisplay3);
            this.Controls.Add(this.carDisplay2);
            this.Controls.Add(this.carDisplay1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Scalextric Racer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionStatus;
        private System.Windows.Forms.Timer timer1;
        private Controls.CarStatusDisplay carDisplay1;
        private Controls.CarStatusDisplay carDisplay2;
        private Controls.CarStatusDisplay carDisplay3;
        private Controls.CarStatusDisplay carDisplay4;
        private Controls.CarStatusDisplay carDisplay5;
        private Controls.CarStatusDisplay carDisplay6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLap;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnSettings;
        private System.Windows.Forms.ToolStripMenuItem btnConnect;
        private System.Windows.Forms.ToolStripMenuItem btnStart;
        private System.Windows.Forms.ToolStripComboBox cmboRaceType;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

