using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace FreePDFWatermarker
{
    public class ImageHelper
    {
        public static Image LoadImage(string filepath)
        {
            //frmMain.Instance.Cursor = Cursors.WaitCursor;

            try
            {

                return ImageFromFile(filepath);
            }
            catch
            {
                try
                {
                    Image bmp1 = FreeImageHelper.LoadImage(filepath);

                    Image bmp = (Image)bmp1.Clone();
                    bmp1.Dispose();
                    bmp1 = null;

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    return bmp;
                }
                catch
                {
                    throw new Exception("Could not load Image ! " + filepath);
                }
            }
            finally
            {
                //frmMain.Instance.Cursor = null;
            }
        }

        public static Image ImageFromFile(string path)
        {
            if (!System.IO.File.Exists(path)) return null;

            var bytes = System.IO.File.ReadAllBytes(path);
            var ms = new System.IO.MemoryStream(bytes);
            Image img = null;

            try
            {
                img = Image.FromStream(ms);
                return img;
                /*
                using (var ms = new System.IO.MemoryStream(bytes))
                {
                    var img = Image.FromStream(ms);
                    return img;
                }*/
            }
            catch
            {
                if (ms != null)
                {
                    ms.Dispose();
                    ms = null;
                }

                if (img != null)
                {
                    try
                    {
                        ((Image)img).Dispose();
                        img = null;
                    }
                    catch { }

                }

                bytes = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();

                throw new Exception("Could not load Image ! " + path);

                //3return null;
            }

        }

        /*
        public static bool FixFileDates(string filepath, string originalFilepath)
        {
            if (Properties.Settings.Default.OKeepCreationDate || Properties.Settings.Default.OKeepLastModDate)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(originalFilepath);

                System.IO.FileInfo fi2 = new System.IO.FileInfo(filepath);

                if (Properties.Settings.Default.OKeepCreationDate)
                {
                    fi2.CreationTime = fi.CreationTime;
                    fi2.CreationTimeUtc = fi.CreationTimeUtc;
                }

                if (Properties.Settings.Default.OKeepLastModDate)
                {
                    fi2.LastWriteTime = fi.LastWriteTime;
                    fi2.LastWriteTimeUtc = fi.LastWriteTimeUtc;
                }
            }

            return true;
        }
        */

        /*
        public static bool SaveImage(string filepath, System.Drawing.Image bmp,string originalFilepath)
        {
            if (Properties.Settings.Default.ORotateEXIF)
            {
                bmp = RotateImageEXIF.RotateImageBasedOnExif(bmp);
            }

            string ext = System.IO.Path.GetExtension(filepath).ToLower().Substring(1);

            if (ext=="png")
            {
                bmp.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (ext=="jpg" || ext=="jpeg")
            {
                ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

                System.Drawing.Imaging.Encoder myEncoder =
                System.Drawing.Imaging.Encoder.Quality;

                // Create an EncoderParameters object.
                // An EncoderParameters object has an array of EncoderParameter
                // objects. In this case, there is only one
                // EncoderParameter object in the array.
                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, (long)Properties.Settings.Default.OJPGQuality);

                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp.Save(filepath, jgpEncoder, myEncoderParameters);
            }
            else if (ext=="gif")
            {
                bmp.Save(filepath, System.Drawing.Imaging.ImageFormat.Gif);
            }
            else if (ext=="bmp")
            {
                bmp.Save(filepath, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            else if (ext == "tiff")
            {
                bmp.Save(filepath, System.Drawing.Imaging.ImageFormat.Tiff);
            }            

            return true;
        }        
        */

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

    }
}
