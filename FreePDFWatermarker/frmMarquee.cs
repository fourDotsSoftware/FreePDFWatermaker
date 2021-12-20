using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FreePDFWatermarker
{
    public partial class frmMarquee : FreePDFWatermarker.CustomForm
    {
        public static frmMarquee Instance = null;

        private int Tick = 0;

        private int FormType = 0;

        public frmMarquee()
        {
            InitializeComponent();

            Instance = this;

            lblDesc.Left = this.Width / 2 - lblDesc.Width / 2;

            this.progressBar1.Style = ProgressBarStyle.Marquee;

            Tick = 0;

            timProgessTime.Enabled = true;

            lblElapsed.Visible = true;
            lblElapsedValue.Visible = true;
            
        }                                

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //3FFMpegHelper.OperationCancelled = true;
            /*
            try
            {
                if (FFMpegHelper.psImage != null)
                {
                    FFMpegHelper.psImage.Kill();
                }
            }
            catch { }*/

            try
            {
                frmMain.Instance.OperationStopped = true;

                PDFWatermakerWorker.pr.Kill();
                PDFWatermakerWorker.pr.Dispose();
                PDFWatermakerWorker.pr = null;
            }
            catch { }
        }

        private void timProgessTime_Tick(object sender, EventArgs e)
        {
            try
            {
                Tick++;

                TimeSpan ts = new TimeSpan(0, 0, Tick);

                lblElapsedValue.Text = ts.Hours > 0 ? ts.Hours.ToString("D2") + ":" : "" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");

                if (FormType!=3)
                {
                    try
                    {

                        decimal d1 = (decimal)progressBar1.Value;
                        decimal d2 = (decimal)progressBar1.Maximum;
                        decimal d3 = (decimal)Tick;

                        // tick value
                        // x     max

                        decimal d = (d2 * d3) / d1;

                        int totaltime = (int)d;
                        int remaining = totaltime - Tick;

                        TimeSpan tsr = new TimeSpan(0, 0, remaining);

                        lblRemainingValue.Text = (tsr.Hours > 0) ? tsr.Hours.ToString("D2") + ":" : "" + tsr.Minutes.ToString("D2") + ":" + tsr.Seconds.ToString("D2");
                    }
                    catch { }
                }

            }
            catch { }

        }
    }
}
