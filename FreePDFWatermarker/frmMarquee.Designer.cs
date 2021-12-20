namespace FreePDFWatermarker
{
    partial class frmMarquee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarquee));
            this.timProgessTime = new System.Windows.Forms.Timer(this.components);
            this.lblRemainingValue = new System.Windows.Forms.Label();
            this.lblElapsedValue = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timProgessTime
            // 
            this.timProgessTime.Interval = 1000;
            this.timProgessTime.Tick += new System.EventHandler(this.timProgessTime_Tick);
            // 
            // lblRemainingValue
            // 
            resources.ApplyResources(this.lblRemainingValue, "lblRemainingValue");
            this.lblRemainingValue.BackColor = System.Drawing.Color.Transparent;
            this.lblRemainingValue.ForeColor = System.Drawing.Color.Black;
            this.lblRemainingValue.Name = "lblRemainingValue";
            // 
            // lblElapsedValue
            // 
            resources.ApplyResources(this.lblElapsedValue, "lblElapsedValue");
            this.lblElapsedValue.BackColor = System.Drawing.Color.Transparent;
            this.lblElapsedValue.ForeColor = System.Drawing.Color.Black;
            this.lblElapsedValue.Name = "lblElapsedValue";
            // 
            // lblRemaining
            // 
            resources.ApplyResources(this.lblRemaining, "lblRemaining");
            this.lblRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblRemaining.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblRemaining.Name = "lblRemaining";
            // 
            // lblElapsed
            // 
            resources.ApplyResources(this.lblElapsed, "lblElapsed");
            this.lblElapsed.BackColor = System.Drawing.Color.Transparent;
            this.lblElapsed.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblElapsed.Name = "lblElapsed";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // lblDesc
            // 
            resources.ApplyResources(this.lblDesc, "lblDesc");
            this.lblDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblDesc.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDesc.Name = "lblDesc";
            // 
            // frmMarquee
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lblRemainingValue);
            this.Controls.Add(this.lblElapsedValue);
            this.Controls.Add(this.lblRemaining);
            this.Controls.Add(this.lblElapsed);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblDesc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMarquee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblDesc;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label lblElapsed;
        public System.Windows.Forms.Label lblRemaining;
        public System.Windows.Forms.Label lblElapsedValue;
        public System.Windows.Forms.Label lblRemainingValue;
        private System.Windows.Forms.Timer timProgessTime;
    }
}
