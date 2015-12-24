namespace Scalextric.Controls 
{
    partial class CarController
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCar = new System.Windows.Forms.Label();
            this.tbThrottle1 = new System.Windows.Forms.TrackBar();
            this.pnlLc = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBrake = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbThrottle1)).BeginInit();
            this.pnlLc.SuspendLayout();
            this.pnlBrake.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCar
            // 
            this.lblCar.AutoSize = true;
            this.lblCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCar.Location = new System.Drawing.Point(4, 7);
            this.lblCar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new System.Drawing.Size(55, 20);
            this.lblCar.TabIndex = 7;
            this.lblCar.Text = "Car 1";
            // 
            // tbThrottle1
            // 
            this.tbThrottle1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbThrottle1.Location = new System.Drawing.Point(92, 4);
            this.tbThrottle1.Margin = new System.Windows.Forms.Padding(4);
            this.tbThrottle1.Maximum = 63;
            this.tbThrottle1.Name = "tbThrottle1";
            this.tbThrottle1.Size = new System.Drawing.Size(320, 56);
            this.tbThrottle1.TabIndex = 6;
            this.tbThrottle1.ValueChanged += new System.EventHandler(this.tbThrottle1_ValueChanged);
            // 
            // pnlLc
            // 
            this.pnlLc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLc.BackColor = System.Drawing.Color.LightGray;
            this.pnlLc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLc.Controls.Add(this.label1);
            this.pnlLc.Location = new System.Drawing.Point(499, 7);
            this.pnlLc.Name = "pnlLc";
            this.pnlLc.Size = new System.Drawing.Size(74, 31);
            this.pnlLc.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "LC";
            // 
            // pnlBrake
            // 
            this.pnlBrake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBrake.BackColor = System.Drawing.Color.LightGray;
            this.pnlBrake.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBrake.Controls.Add(this.label3);
            this.pnlBrake.Location = new System.Drawing.Point(419, 7);
            this.pnlBrake.Name = "pnlBrake";
            this.pnlBrake.Size = new System.Drawing.Size(74, 31);
            this.pnlBrake.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Brake";
            // 
            // CarController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBrake);
            this.Controls.Add(this.pnlLc);
            this.Controls.Add(this.lblCar);
            this.Controls.Add(this.tbThrottle1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CarController";
            this.Size = new System.Drawing.Size(576, 45);
            ((System.ComponentModel.ISupportInitialize)(this.tbThrottle1)).EndInit();
            this.pnlLc.ResumeLayout(false);
            this.pnlLc.PerformLayout();
            this.pnlBrake.ResumeLayout(false);
            this.pnlBrake.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCar;
        private System.Windows.Forms.TrackBar tbThrottle1;
        private System.Windows.Forms.Panel pnlLc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlBrake;
        private System.Windows.Forms.Label label3;
    }
}
