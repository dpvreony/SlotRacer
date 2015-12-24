namespace Scalextric
{
    partial class FormCarSetup
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblCarNr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDriverName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmboBrakeBehaviour = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlColour = new System.Windows.Forms.Panel();
            this.cmboColour = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Car Number";
            // 
            // lblCarNr
            // 
            this.lblCarNr.AutoSize = true;
            this.lblCarNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCarNr.Location = new System.Drawing.Point(131, 23);
            this.lblCarNr.Name = "lblCarNr";
            this.lblCarNr.Size = new System.Drawing.Size(21, 24);
            this.lblCarNr.TabIndex = 0;
            this.lblCarNr.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Driver";
            // 
            // lblDriverName
            // 
            this.lblDriverName.AutoSize = true;
            this.lblDriverName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblDriverName.Location = new System.Drawing.Point(291, 23);
            this.lblDriverName.Name = "lblDriverName";
            this.lblDriverName.Size = new System.Drawing.Size(17, 24);
            this.lblDriverName.TabIndex = 0;
            this.lblDriverName.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Max Speed";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(125, 126);
            this.trackBar1.Maximum = 63;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(337, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 63;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(468, 128);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(55, 24);
            this.lblSpeed.TabIndex = 0;
            this.lblSpeed.Text = "100%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 24);
            this.label6.TabIndex = 2;
            this.label6.Text = "Brake behaviour";
            // 
            // cmboBrakeBehaviour
            // 
            this.cmboBrakeBehaviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboBrakeBehaviour.FormattingEnabled = true;
            this.cmboBrakeBehaviour.Items.AddRange(new object[] {
            "Brake on button press",
            "Brake on throttle release",
            "Brake on button and throttle release",
            "No braking"});
            this.cmboBrakeBehaviour.Location = new System.Drawing.Point(165, 184);
            this.cmboBrakeBehaviour.Name = "cmboBrakeBehaviour";
            this.cmboBrakeBehaviour.Size = new System.Drawing.Size(358, 32);
            this.cmboBrakeBehaviour.TabIndex = 3;
            this.cmboBrakeBehaviour.SelectedIndexChanged += new System.EventHandler(this.cmboBrakeBehaviour_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(447, 269);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 38);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AllowFullOpen = false;
            this.colorDialog1.SolidColorOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Colour";
            // 
            // pnlColour
            // 
            this.pnlColour.BackColor = System.Drawing.Color.White;
            this.pnlColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColour.Location = new System.Drawing.Point(282, 62);
            this.pnlColour.Name = "pnlColour";
            this.pnlColour.Size = new System.Drawing.Size(49, 48);
            this.pnlColour.TabIndex = 5;
            this.pnlColour.Click += new System.EventHandler(this.pnlColour_Click);
            // 
            // cmboColour
            // 
            this.cmboColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboColour.FormattingEnabled = true;
            this.cmboColour.Items.AddRange(new object[] {
            "Yellow",
            "Blue",
            "Red",
            "Green",
            "Orange",
            "White"});
            this.cmboColour.Location = new System.Drawing.Point(135, 70);
            this.cmboColour.Name = "cmboColour";
            this.cmboColour.Size = new System.Drawing.Size(121, 32);
            this.cmboColour.TabIndex = 6;
            this.cmboColour.SelectedIndexChanged += new System.EventHandler(this.cmboColour_SelectedIndexChanged);
            // 
            // FormCarSetup
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 319);
            this.ControlBox = false;
            this.Controls.Add(this.cmboColour);
            this.Controls.Add(this.pnlColour);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmboBrakeBehaviour);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lblCarNr);
            this.Controls.Add(this.lblDriverName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormCarSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Car Setup";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCarNr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDriverName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmboBrakeBehaviour;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlColour;
        private System.Windows.Forms.ComboBox cmboColour;
    }
}