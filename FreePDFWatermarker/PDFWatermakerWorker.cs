using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using System.Diagnostics;

namespace FreePDFWatermarker
{
    class PDFWatermakerWorker
    {
        public static Process pr = null;

        public static void WatermarkPDF(string inputFile, string outputFile, string password, int r, int g, int b, int fontSize,
            int angle, string position, string watermarkText, string imageFilepath)
        {
            string tmpfn = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + ".pdf");

            FileInfo fi4 = new FileInfo(inputFile);
            DateTime dtcreated = fi4.CreationTime;
            DateTime dtlastmod = fi4.LastWriteTime;

            System.IO.File.Copy(inputFile, tmpfn);

            inputFile = tmpfn;

            if (System.IO.File.Exists(outputFile))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(outputFile);
                fi.Attributes = System.IO.FileAttributes.Normal;
                fi.Delete();
            }

            if (password == string.Empty)
            {
                password = null;
            }

            pr = new Process();
            pr.StartInfo.CreateNoWindow = true;
            pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pr.StartInfo.FileName = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "PDFUtilitiesNew.exe");
            pr.StartInfo.Arguments = "/watermark " +
                "\"" + tmpfn + "\" \"" + outputFile + "\" \"" + password + "\" \"" + r + "\" \"" + g + "\" \"" + b + "\" \"" + fontSize
                + "\" \"" + angle + "\" \"" + position + "\" \"" + watermarkText + "\" \"" + imageFilepath + "\"";

            pr.Start();
            pr.WaitForExit();

            while (!pr.HasExited)
            {
                System.Windows.Forms.Application.DoEvents();
            }

            try
            {
                System.IO.FileInfo fi2 = new System.IO.FileInfo(tmpfn);
                fi2.Attributes = System.IO.FileAttributes.Normal;
                fi2.Delete();
            }
            catch { }

            if (System.IO.File.Exists(outputFile))
            {
                FileInfo fi3 = new FileInfo(outputFile);

                if (Properties.Settings.Default.KeepCreationDate)
                {
                    fi3.CreationTime = dtcreated;
                }

                if (Properties.Settings.Default.KeepLastModificationDate)
                {
                    fi3.LastWriteTime = dtlastmod;
                }
            }
        }
    }
}
