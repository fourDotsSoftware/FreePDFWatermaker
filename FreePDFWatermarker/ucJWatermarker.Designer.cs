namespace FreePDFWatermarker
{
    partial class ucJWatermarker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucJWatermarker));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWatermarkText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudFontSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFontColor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAngle = new System.Windows.Forms.TrackBar();
            this.lblAngle = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWatermarkImage = new System.Windows.Forms.TextBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // cmbPosition
            // 
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbPosition, "cmbPosition");
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Name = "cmbPosition";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // txtWatermarkText
            // 
            resources.ApplyResources(this.txtWatermarkText, "txtWatermarkText");
            this.txtWatermarkText.Name = "txtWatermarkText";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // nudFontSize
            // 
            resources.ApplyResources(this.nudFontSize, "nudFontSize");
            this.nudFontSize.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFontSize.Name = "nudFontSize";
            this.nudFontSize.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // btnFontColor
            // 
            this.btnFontColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(135)))), ((int)(((byte)(135)))));
            resources.ApplyResources(this.btnFontColor, "btnFontColor");
            this.btnFontColor.Name = "btnFontColor";
            this.btnFontColor.UseVisualStyleBackColor = false;
            this.btnFontColor.Click += new System.EventHandler(this.btnFontColor_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Name = "label5";
            // 
            // tbAngle
            // 
            resources.ApplyResources(this.tbAngle, "tbAngle");
            this.tbAngle.Maximum = 360;
            this.tbAngle.Name = "tbAngle";
            this.tbAngle.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbAngle.Scroll += new System.EventHandler(this.tbAngle_Scroll);
            // 
            // lblAngle
            // 
            resources.ApplyResources(this.lblAngle, "lblAngle");
            this.lblAngle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblAngle.Name = "lblAngle";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Name = "label6";
            // 
            // txtUserPassword
            // 
            resources.ApplyResources(this.txtUserPassword, "txtUserPassword");
            this.txtUserPassword.Name = "txtUserPassword";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Name = "label7";
            // 
            // txtWatermarkImage
            // 
            resources.ApplyResources(this.txtWatermarkImage, "txtWatermarkImage");
            this.txtWatermarkImage.Name = "txtWatermarkImage";
            // 
            // picPreview
            // 
            resources.ApplyResources(this.picPreview, "picPreview");
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPreview.Name = "picPreview";
            this.picPreview.TabStop = false;
            this.picPreview.Click += new System.EventHandler(this.picPreview_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Name = "label8";
            // 
            // btnBrowse
            // 
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ucJWatermarker
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.txtWatermarkImage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblAngle);
            this.Controls.Add(this.tbAngle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnFontColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudFontSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWatermarkText);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "ucJWatermarker";
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cmbPosition;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtWatermarkText;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown nudFontSize;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnFontColor;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TrackBar tbAngle;
        public System.Windows.Forms.Label lblAngle;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtUserPassword;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtWatermarkImage;
        public System.Windows.Forms.PictureBox picPreview;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button btnBrowse;
        public System.Windows.Forms.Button btnClear;
    }
}
