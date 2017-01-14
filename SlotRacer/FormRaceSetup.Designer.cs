namespace SlotRacer
{
    partial class FormRaceSetup
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
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmboActivation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbSpeedAfterRace = new System.Windows.Forms.TrackBar();
            this.lblSpeedAfterRace = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbGhostCar = new System.Windows.Forms.TrackBar();
            this.lblGhostCarSpeed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmboGhostCarLaneChangeOption = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedAfterRace)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGhostCar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(521, 366);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 38);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Yellow Flag Activiation";
            // 
            // cmboActivation
            // 
            this.cmboActivation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboActivation.FormattingEnabled = true;
            this.cmboActivation.Items.AddRange(new object[] {
            "Yellow flag Disabled",
            "Activate on any brake button",
            "Activate on start button"});
            this.cmboActivation.Location = new System.Drawing.Point(209, 22);
            this.cmboActivation.Name = "cmboActivation";
            this.cmboActivation.Size = new System.Drawing.Size(300, 32);
            this.cmboActivation.TabIndex = 7;
            this.cmboActivation.SelectedIndexChanged += new System.EventHandler(this.cmboActivation_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Yellow Flag Delay";
            // 
            // nudDelay
            // 
            this.nudDelay.Location = new System.Drawing.Point(181, 84);
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(92, 29);
            this.nudDelay.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Yellow Flag Speed";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(181, 147);
            this.trackBar1.Maximum = 63;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(267, 45);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.Value = 63;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(454, 147);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(55, 24);
            this.lblSpeed.TabIndex = 9;
            this.lblSpeed.Text = "100%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "ms";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(585, 348);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.trackBar1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.lblSpeed);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.nudDelay);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.cmboActivation);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(577, 311);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Yellow Flag";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbSpeedAfterRace);
            this.tabPage1.Controls.Add(this.lblSpeedAfterRace);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(577, 311);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Race";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbSpeedAfterRace
            // 
            this.tbSpeedAfterRace.Location = new System.Drawing.Point(160, 25);
            this.tbSpeedAfterRace.Maximum = 63;
            this.tbSpeedAfterRace.Name = "tbSpeedAfterRace";
            this.tbSpeedAfterRace.Size = new System.Drawing.Size(267, 45);
            this.tbSpeedAfterRace.TabIndex = 13;
            this.tbSpeedAfterRace.Value = 63;
            this.tbSpeedAfterRace.ValueChanged += new System.EventHandler(this.tbSpeedAfterRace_ValueChanged);
            // 
            // lblSpeedAfterRace
            // 
            this.lblSpeedAfterRace.AutoSize = true;
            this.lblSpeedAfterRace.Location = new System.Drawing.Point(433, 25);
            this.lblSpeedAfterRace.Name = "lblSpeedAfterRace";
            this.lblSpeedAfterRace.Size = new System.Drawing.Size(55, 24);
            this.lblSpeedAfterRace.TabIndex = 12;
            this.lblSpeedAfterRace.Text = "100%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Speed after race";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cmboGhostCarLaneChangeOption);
            this.tabPage3.Controls.Add(this.tbGhostCar);
            this.tabPage3.Controls.Add(this.lblGhostCarSpeed);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(577, 311);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ghost Car";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbGhostCar
            // 
            this.tbGhostCar.Location = new System.Drawing.Point(157, 25);
            this.tbGhostCar.Maximum = 63;
            this.tbGhostCar.Name = "tbGhostCar";
            this.tbGhostCar.Size = new System.Drawing.Size(267, 45);
            this.tbGhostCar.TabIndex = 16;
            this.tbGhostCar.Value = 35;
            this.tbGhostCar.ValueChanged += new System.EventHandler(this.tbGhostCar_ValueChanged);
            // 
            // lblGhostCarSpeed
            // 
            this.lblGhostCarSpeed.AutoSize = true;
            this.lblGhostCarSpeed.Location = new System.Drawing.Point(430, 25);
            this.lblGhostCarSpeed.Name = "lblGhostCarSpeed";
            this.lblGhostCarSpeed.Size = new System.Drawing.Size(55, 24);
            this.lblGhostCarSpeed.TabIndex = 15;
            this.lblGhostCarSpeed.Text = "100%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 24);
            this.label8.TabIndex = 14;
            this.label8.Text = "Ghost car speed";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 24);
            this.label9.TabIndex = 14;
            this.label9.Text = "Lane change options";
            // 
            // cmboGhostCarLaneChangeOption
            // 
            this.cmboGhostCarLaneChangeOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboGhostCarLaneChangeOption.FormattingEnabled = true;
            this.cmboGhostCarLaneChangeOption.Items.AddRange(new object[] {
            "Never change",
            "Aways change",
            "Random Change"});
            this.cmboGhostCarLaneChangeOption.Location = new System.Drawing.Point(199, 83);
            this.cmboGhostCarLaneChangeOption.Name = "cmboGhostCarLaneChangeOption";
            this.cmboGhostCarLaneChangeOption.Size = new System.Drawing.Size(225, 32);
            this.cmboGhostCarLaneChangeOption.TabIndex = 17;
            this.cmboGhostCarLaneChangeOption.SelectedIndexChanged += new System.EventHandler(this.cmboGhostCarLaneChangeOption_SelectedIndexChanged);
            // 
            // FormYellowFlagSetup
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 416);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormYellowFlagSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yellow Flag Setup";
            this.Load += new System.EventHandler(this.FormYellowFlagSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeedAfterRace)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGhostCar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboActivation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDelay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TrackBar tbSpeedAfterRace;
        private System.Windows.Forms.Label lblSpeedAfterRace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cmboGhostCarLaneChangeOption;
        private System.Windows.Forms.TrackBar tbGhostCar;
        private System.Windows.Forms.Label lblGhostCarSpeed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;

    }
}