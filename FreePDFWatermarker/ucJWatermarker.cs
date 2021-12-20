using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;

namespace FreePDFWatermarker
{
    public partial class ucJWatermarker : UserControl
    {
        public List<string> lstPosition = new List<string>();

        public ucJWatermarker()
        {
            InitializeComponent();            
                        
            cmbPosition.Items.Add(TranslateHelper.Translate("Top Center"));
            cmbPosition.Items.Add(TranslateHelper.Translate("Middle Center"));
            cmbPosition.Items.Add(TranslateHelper.Translate("Bottom Center"));

            cmbPosition.Items.Add(TranslateHelper.Translate("Top Left"));
            cmbPosition.Items.Add(TranslateHelper.Translate("Middle Left"));            
            cmbPosition.Items.Add(TranslateHelper.Translate("Bottom Left"));

            cmbPosition.Items.Add(TranslateHelper.Translate("Top Right"));
            cmbPosition.Items.Add(TranslateHelper.Translate("Middle Right"));            
            cmbPosition.Items.Add(TranslateHelper.Translate("Bottom Right"));
            
            cmbPosition.SelectedIndex = 0;            

            lstPosition.Add("Top Center");
            lstPosition.Add("Middle Center");
            lstPosition.Add("Bottom Center");
            
            lstPosition.Add("Top Left");
            lstPosition.Add("Middle Left");  
            lstPosition.Add("Bottom Left");
            
            lstPosition.Add("Top Right");
            lstPosition.Add("Middle Right"); 
            lstPosition.Add("Bottom Right");
        }

        private void tbAngle_Scroll(object sender, EventArgs e)
        {
            lblAngle.Text = tbAngle.Value.ToString();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg;*.jpeg;*.gif;*.png;*.bmp)|*.jpg;*.jpeg;*.gif;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtWatermarkImage.Text = ofd.FileName;

                try
                {
                    picPreview.Image = null;

                    picPreview.Image = Image.FromFile(ofd.FileName);
                }
                catch { }
            }
        }

        private void picPreview_Click(object sender, EventArgs e)
        {
            btnBrowse_Click(null, null);
        }

        private void btnFontColor_Click(object sender, EventArgs e)
        {
            ColorDialog cld = new ColorDialog();
            cld.Color = btnFontColor.BackColor;

            if (cld.ShowDialog() == DialogResult.OK)
            {
                btnFontColor.BackColor = cld.Color;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtWatermarkImage.Text = "";
            picPreview.Image = null;
        }
    }
}
