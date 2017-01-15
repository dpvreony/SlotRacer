namespace SlotRacerGui
{
    partial class FormSettings
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmboPortName = new System.Windows.Forms.ComboBox();
            this.nudRaceTime = new System.Windows.Forms.NumericUpDown();
            this.textbox1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudRaceTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Location = new System.Drawing.Point(145, 125);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(64, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial Port";
            // 
            // cmboPortName
            // 
            this.cmboPortName.FormattingEnabled = true;
            this.cmboPortName.Location = new System.Drawing.Point(73, 34);
            this.cmboPortName.Name = "cmboPortName";
            this.cmboPortName.Size = new System.Drawing.Size(135, 21);
            this.cmboPortName.TabIndex = 2;
            // 
            // nudRaceTime
            // 
            this.nudRaceTime.Location = new System.Drawing.Point(73, 78);
            this.nudRaceTime.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudRaceTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRaceTime.Name = "nudRaceTime";
            this.nudRaceTime.Size = new System.Drawing.Size(66, 20);
            this.nudRaceTime.TabIndex = 3;
            this.nudRaceTime.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // textbox1
            // 
            this.textbox1.AutoSize = true;
            this.textbox1.Location = new System.Drawing.Point(12, 80);
            this.textbox1.Name = "textbox1";
            this.textbox1.Size = new System.Drawing.Size(55, 13);
            this.textbox1.TabIndex = 1;
            this.textbox1.Text = "Race time";
            // 
            // FormSettings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(232, 160);
            this.ControlBox = false;
            this.Controls.Add(this.nudRaceTime);
            this.Controls.Add(this.cmboPortName);
            this.Controls.Add(this.textbox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nudRaceTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboPortName;
        private System.Windows.Forms.NumericUpDown nudRaceTime;
        private System.Windows.Forms.Label textbox1;
    }
}