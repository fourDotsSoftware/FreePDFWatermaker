using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FreePDFWatermarker
{
    public partial class frmPreviewImage : FreePDFWatermarker.CustomForm
    {
        public frmPreviewImage(string filepath)
        {
            InitializeComponent();

            this.Text = filepath;

            Image img = ImageHelper.LoadImage(filepath);

            picImage.Image = img;            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
