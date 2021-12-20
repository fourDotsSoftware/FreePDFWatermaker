using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FreePDFWatermarker
{ 
    class ArgsHelper
    {        
        public static bool ExamineArgs(string[] args)
        {
            if (args.Length == 0) return true;
                        
            Module.args = args;

            try
            {
                if (args[0].ToLower().Trim().StartsWith("-tempfile:"))
                {                                       
                    string tempfile = GetParameter(args[0]);

                    //MessageBox.Show(tempfile);

                    using (StreamReader sr = new StreamReader(tempfile, Encoding.Unicode))
                    {
                        string scont = sr.ReadToEnd();

                        //args = scont.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        args = SplitArguments(scont);
                        Module.args = args;

                        // MessageBox.Show(scont);
                    }

                    Module.IsFromWindowsExplorer = true;
                }
                else if (args.Length>0 && (Module.args.Length==1 && (System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0]))))
                {

                }
                else
                {
                    Module.IsCommandLine = true;

                    //System.Windows.Forms.MessageBox.Show("0");

                    frmMain f=new frmMain();

                    string password = "";

                    frmMain.Instance.dt.Rows.Clear();

                    for (int k = 0; k < Module.args.Length; k++)
                    {
                        if (System.IO.File.Exists(Module.args[k]))
                        {
                            frmMain.Instance.AddFile(Module.args[k],password);

                            password = "";
                        }
                        else if (System.IO.Directory.Exists(Module.args[k]))
                        {
                            frmMain.Instance.SilentAdd = true;

                            frmMain.Instance.AddFolder(Module.args[k],password);

                            password = "";
                        }
                        else if (Module.args[k].ToLower().Trim() == "-keeptimestamp"
                            || Module.args[k].ToLower().Trim() == "/keeptimestamp")
                        {
                            frmMain.Instance.retainTimestampToolStripMenuItem.Checked = true;

                            password = "";
                        }                        
                        else if (Module.args[k].ToLower().StartsWith("/outfolder:") ||
    Module.args[k].ToLower().StartsWith("-outfolder:"))
                        {
                            string outfile = GetParameter(Module.args[k]);

                            //3RecentFilesHelper.AddRecentOutputFile(outfile);

                            //3frmMain.Instance.cmbOutputDir.SelectedIndex = 0;

                            //Module.OutputFilepath = outfile;

                            RecentFilesHelper.AddRecentOutputFile(outfile);

                            frmMain.Instance.cmbOutputDir.SelectedIndex = 4;

                            password = "";
                        }
                        else if (Module.args[k].ToLower().StartsWith("/outputfolder:") ||
    Module.args[k].ToLower().StartsWith("-outputfolder:"))
                        {
                            string outfile = GetParameter(Module.args[k]);

                            //3RecentFilesHelper.AddRecentOutputFile(outfile);

                            //3frmMain.Instance.cmbOutputDir.SelectedIndex = 0;

                            //Module.OutputFilepath = outfile;

                            RecentFilesHelper.AddRecentOutputFile(outfile);

                            frmMain.Instance.cmbOutputDir.SelectedIndex = 4;

                            password = "";
                        }
                        else if (Module.args[k].ToLower().StartsWith("/watermarktext:") ||
        Module.args[k].ToLower().StartsWith("-watermarktext:"))
                        {
                            string ds = GetParameter(Module.args[k]);

                            frmMain.Instance.ucJWatermarker1.txtWatermarkText.Text = ds;
                        }
                        else if (Module.args[k].ToLower().StartsWith("/watermarkimage:") ||
    Module.args[k].ToLower().StartsWith("-watermarkimage:"))
                        {
                            string ds = GetParameter(Module.args[k]);

                            frmMain.Instance.ucJWatermarker1.txtWatermarkImage.Text = ds;
                        }
                        else if (Module.args[k].ToLower().StartsWith("/userpassword:") ||
Module.args[k].ToLower().StartsWith("-userpassword:"))
                        {
                            string ds = GetParameter(Module.args[k]);

                            frmMain.Instance.ucJWatermarker1.txtUserPassword.Text = ds;
                        }
                        else if (Module.args[k].ToLower().StartsWith("/filename:") ||
Module.args[k].ToLower().StartsWith("-filename:"))
                        {
                            string ds = GetParameter(Module.args[k]);

                            frmMain.Instance.txtFilename.Text = ds;
                        }
                        else if (Module.args[k].ToLower().StartsWith("/fontsize:") ||
Module.args[k].ToLower().StartsWith("-fontsize:"))
                        {
                            try
                            {
                                string ds = GetParameter(Module.args[k]);

                                int ids = int.Parse(ds);

                                frmMain.Instance.ucJWatermarker1.nudFontSize.Value = ids;
                            }
                            catch
                            {
                                throw new Exception("Please specify font size in the correct foramt e.g. /fontsize:\"25\"");
                            }
                        }
                        else if (Module.args[k].ToLower().StartsWith("/rotate:") ||
Module.args[k].ToLower().StartsWith("-rotate:"))
                        {
                            try
                            {

                                string ds = GetParameter(Module.args[k]);

                                int ids = int.Parse(ds);

                                frmMain.Instance.ucJWatermarker1.tbAngle.Value = ids;

                            }
                            catch
                            {
                                throw new Exception("Please specify font size in the correct foramt e.g. /rotate:\"25\"");
                            }
                        }
                        else if (Module.args[k].ToLower().StartsWith("/position:") ||
Module.args[k].ToLower().StartsWith("-position:"))
                        {
                            try {
                            string ds = GetParameter(Module.args[k]);

                            int ids = int.Parse(ds);

                            frmMain.Instance.ucJWatermarker1.cmbPosition.SelectedIndex = ids;

                            }
                            catch
                            {
                                throw new Exception("Please specify position in the correct foramt e.g. /position:\"1\"");
                            }
                        }
                        else if (Module.args[k].ToLower().StartsWith("/fontcolor:") ||
Module.args[k].ToLower().StartsWith("-fontcolor:"))
                        {
                            try
                            {
                                string ds = GetParameter(Module.args[k]);

                                int ids1 = ds.IndexOf(",", 0);

                                string r = ds.Substring(0, ids1);

                                int ir = int.Parse(r);

                                int ids2 = ds.IndexOf(",", ids1 + 1);

                                string g = ds.Substring(ids1 + 1, ids2 - ids1 - 1);

                                int ig = int.Parse(g);

                                string b = ds.Substring(ids2 + 1);

                                int ib = int.Parse(b);

                                frmMain.Instance.ucJWatermarker1.btnFontColor.BackColor = System.Drawing.Color.FromArgb(ir, ig, ib);
                            }
                            catch
                            {
                                throw new Exception("Please specify a color in the correct format e.g. /fontcolor:\"137,135,135\"");
                            }
                        }                                                                        
                    }                                      
                }
            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not parse Arguments !", ex.ToString());
                return false;
            }

            return true;
        }

        private static string RemoveQuotes(string str)
        {
            if ((str.StartsWith("\"") && str.EndsWith("\"")) ||
                    (str.StartsWith("'") && str.EndsWith("'")))
            {
                if (str.Length > 2)
                {
                    str = str.Substring(1, str.Length - 2);
                }
                else
                {
                    str = "";
                }
            }

            return str;
        }

        private static string GetParameter(string arg)
        {
            int spos = arg.IndexOf(":");
            if (spos == arg.Length - 1) return "";
            else
            {
                string str=arg.Substring(spos + 1);

                if ((str.StartsWith("\"") && str.EndsWith("\"")) ||
                    (str.StartsWith("'") && str.EndsWith("'")))
                {
                    if (str.Length > 2)
                    {
                        str = str.Substring(1, str.Length - 2);
                    }
                    else
                    {
                        str = "";
                    }
                }

                return str;
            }
        }

        public static string[] SplitArguments(string commandLine)
        {
            char[] parmChars = commandLine.ToCharArray();
            bool inSingleQuote = false;
            bool inDoubleQuote = false;
            for (int index = 0; index < parmChars.Length; index++)
            {
                if (parmChars[index] == '"' && !inSingleQuote)
                {
                    inDoubleQuote = !inDoubleQuote;
                    parmChars[index] = '\n';
                }
                if (parmChars[index] == '\'' && !inDoubleQuote)
                {
                    inSingleQuote = !inSingleQuote;
                    parmChars[index] = '\n';
                }
                if (!inSingleQuote && !inDoubleQuote && parmChars[index] == ' ')
                    parmChars[index] = '\n';
            }
            return (new string(parmChars)).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static void ShowCommandUsage()
        {
            string msg = GetCommandUsage();

            Module.ShowMessage(msg);

            Environment.Exit(0);
        }
        public static string GetCommandUsage()
        {
            string msg = "Add Watermark to PDF Documents.\n\n" +
            "FreePDFWatermarker.exe [file|directory]\n" +
            "[/cmd]\n" +
            "[/keeptimestamp]\n" +
            "[/outfolder:OUTPUT_FOLDER]\n" +
            "[/watermarktext:WATERMARK_TEXT]\n" +
            "[/watermarkimage:WATERMARK_IMAGE]\n" +
            "[/userpassword:USER_PASSWORD]\n" +
            "[/filename:FILENAME_PATTERN]\n" +
            "[/fontsize:FONT_SIZE]\n" +
            "[/rotate:ROTATE_VALUE]\n" +
            "[/position:POSITION_INDEX_VALUE]\n" +
            "[/fontcolor:FONT_COLOR]\n" +
            "[/?]\n\n\n" +
            "cmd : use the command line\n" +
            "file : one or more Microsoft Word documents to be processed.\n" +
            "directory : one or more directories containing files to be processed.\n" +
            "outfolder  : Output folder.\n" +
            "keeptimestamp : (optional) keep document timestamp.\n" +
            "watermarktext : Watermark Text\n" +
            "watermarkimage : Watermark image filepath\n" +
            "userpassword : PDF user password (for open)\n" +
            "filename : output filename pattern\n" +
            "fontsize : font size (integer value)\n" +
            "rotate : rotation angle (integer value)\n" +
            "position : position index value e.g. 0=top center, 1=middle center e.t.c.\n" +
            "fontcolor : font color e.g \"137,135,135\"\n" +
            "/? : show help\n\n\n" +
            "Example :\n" +
            "FreePDFWatermarker.exe \"c:\\invoices\\invoice1.pdf\" \"c:\\invoices\\invoice2.pdf\" \"c:\\invoices\\invoice3.pdf\"" +
            " /outfolder:\"c:\\documents\\watermarkedinvoices\" /position:3 /watermarktext:\"Invoices 2020\"" +
            "/watermarkimage:\"c:\\images\\watermarkimage.jpg\" /fontsize:25 /filename:\"[FILENAME]_watermarked\"" +
            "/fontcolor:\"137,135,135\"";

            return msg;
        }

        public static bool IsFromFolderWatcher
        {
            get
            {                
                // new
                if (Module.args.Length > 0 && Module.args[0].ToLower().Trim() == "/cmdfw")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsFromWindowsExplorer
        {
            get
            {
                if (Module.IsFromWindowsExplorer) return true;

                // new
                if (Module.args.Length > 0 && (Module.args[0].ToLower().Trim().Contains("-tempfile:")
                    || (Module.args.Length==1 && (System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0])))))
                {
                    Module.IsFromWindowsExplorer = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsFromCommandLine
        {
            get
            {
                if (Module.args == null || Module.args.Length == 0)
                {
                    return false;
                }

                if (ArgsHelper.IsFromWindowsExplorer)
                {
                    Module.IsCommandLine = false;
                    return false;
                }
                else if (Module.args.Length > 0 && (Module.args.Length == 1 && (System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0]))))
                {
                    Module.IsCommandLine = false;
                    return false;
                }
                else
                {
                    Module.IsCommandLine = true;
                    return true;
                }
            }
        }

        /*
        public static bool IsFromWindowsExplorer()
        {
            if (Module.args == null || Module.args.Length == 0)
            {
                return false;
            }

            for (int k = 0; k < Module.args.Length; k++)
            {
                if (Module.args[k] == "-visual")
                {
                    Module.IsFromWindowsExplorer = true;
                    return true;
                }
            }

            Module.IsFromWindowsExplorer = false;
            return false;
        }
        */

        public static void ExecuteCommandLine()
        {
            string err = "";
            bool finished = false;

            try
            {
                /*
                if (Module.CmdLogFile != string.Empty)
                {
                    try
                    {
                        Module.CmdLogFileWriter = new StreamWriter(Module.CmdLogFile, true);
                        Module.CmdLogFileWriter.AutoFlush = true;
                        Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] Started compressing PDF files !");
                    }
                    catch (Exception exl)
                    {
                        Module.ShowMessage("Error could not start log writer !");
                        ShowCommandUsage();
                        Environment.Exit(0);
                        return;
                    }
                }                

                if (Module.CmdImportListFile != string.Empty)
                {
                    frmMain.Instance.ImportList(Module.CmdImportListFile);

                    err += frmMain.Instance.SilentAddErr;

                }
                */

                if (Module.args[0].ToLower() == "/h" ||
                        Module.args[0].ToLower() == "-h" ||
                        Module.args[0].ToLower() == "-?" ||
                        Module.args[0].ToLower() == "/?")
                {
                    ShowCommandUsage();
                    Environment.Exit(1);
                    return;
                }

                if (frmMain.Instance.dt.Rows.Count == 0)
                {
                    Module.ShowMessage("Please specify at least one PDF document !");
                    ShowCommandUsage();
                    Environment.Exit(0);
                    return;
                }                
                
                frmMain.Instance.tsbWatermarkPDF_Click(null,null);
                
            }
            finally
            {
                
            }
            Environment.Exit(0);
        }                                       
    }

    public class ReadListsResult
    {
        public bool Success = true;
        public string err = "";
    }
}
