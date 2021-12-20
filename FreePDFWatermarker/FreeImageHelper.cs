using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FreeImageAPI;

using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace FreePDFWatermarker
{
    class FreeImageHelper
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct RGBQUAD
        {
    public byte rgbBlue;
    public byte rgbGreen;
    public byte rgbRed;
    public byte rgbReserved;
        }
        [DllImport("gdi32.dll")]
static extern IntPtr CreateDIBSection(IntPtr hdc, [In] ref BITMAPINFO pbmi,
   uint pila, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

        const int DIB_RGB_COLORS=0;

        private static FIBITMAP dib = new FIBITMAP();
        private static FIBITMAP dib2 = new FIBITMAP();

        public static LoadImageReturn LoadImageWithFileType(string filepath)
        {
            if (!dib.IsNull)
                FreeImage.Unload(dib);

            dib = new FIBITMAP();

            // Safely unload to prevent memory leak.
            FreeImage.UnloadEx(ref dib);

            // Load the example bitmap.
            dib = FreeImage.LoadEx(filepath);

            // Check whether loading succeeded.
            if (dib.IsNull)
            {
                throw new Exception("No Image");
            }

            // Convert the FreeImage-Bitmap into a .NET bitmap

            /*
            if (FreeImage.GetPalette(dib) != IntPtr.Zero)
            {
                byte[] Transparency = new byte[1];
                Transparency[0] = 0x00;
                FreeImage.SetTransparencyTable(dib, Transparency);
                FreeImage.SetTransparent(dib, true);
            }
            */

            Bitmap bitmap = FreeImage.GetBitmap(dib);

            LoadImageReturn lr = new LoadImageReturn();
            lr.img = bitmap;
            lr.FileType = FreeImage.GetFileType(filepath, 0);

            return lr;
        }

        public static Bitmap LoadImageOld(string filepath)
        {
            if (!dib.IsNull)
                FreeImage.Unload(dib);

            dib = new FIBITMAP();                        

            // Safely unload to prevent memory leak.
            FreeImage.UnloadEx(ref dib);

            // Load the example bitmap.
            //1dib = FreeImage.LoadEx(filepath);
            //dib = FreeImage.Load(FREE_IMAGE_FORMAT.FIF_JPEG, filepath, FREE_IMAGE_LOAD_FLAGS.JPEG_ACCURATE);
            dib = FreeImage.Load(FREE_IMAGE_FORMAT.FIF_RAW, filepath, FREE_IMAGE_LOAD_FLAGS.RAW_DISPLAY);
                        
            // Check whether loading succeeded.
            if (dib.IsNull)
            {
                throw new Exception("No Image");
            }

            /*
            if (FreeImage.GetPalette(dib) != IntPtr.Zero)
            {
                byte[] Transparency = new byte[1];
                Transparency[0] = 0x00;
                FreeImage.SetTransparencyTable(dib, Transparency);
                FreeImage.SetTransparent(dib, true);
            }
            */
            // Convert the FreeImage-Bitmap into a .NET bitmap

            FreeImage.Save(FREE_IMAGE_FORMAT.FIF_JPEG, dib, @"c:\1\testfreeimage.jpg", FREE_IMAGE_SAVE_FLAGS.DEFAULT);
            
            if (!dib.IsNull)
                FreeImage.Unload(dib);

            dib = new FIBITMAP();

            // Safely unload to prevent memory leak.
            FreeImage.UnloadEx(ref dib);

            // Load the example bitmap.
            //dib = FreeImage.LoadEx(filepath);
            dib = FreeImage.LoadEx(@"c:\1\testfreeimage.jpg");
            
            // Check whether loading succeeded.
            if (dib.IsNull)
            {
                throw new Exception("No Image");
            }

            Bitmap bitmap = FreeImage.GetBitmap(dib);

            return bitmap;
        }

        public static Bitmap LoadImage(string filepath)
        {
            try
            {

                if (!dib.IsNull)
                    FreeImage.Unload(dib);

                dib = new FIBITMAP();

                // Safely unload to prevent memory leak.
                FreeImage.UnloadEx(ref dib);

                // Load the example bitmap.
                //1dib = FreeImage.LoadEx(filepath);
                //dib = FreeImage.Load(FREE_IMAGE_FORMAT.FIF_JPEG, filepath, FREE_IMAGE_LOAD_FLAGS.JPEG_ACCURATE);
                dib = FreeImage.Load(FREE_IMAGE_FORMAT.FIF_RAW, filepath, FREE_IMAGE_LOAD_FLAGS.RAW_DISPLAY);

                // Check whether loading succeeded.
                if (dib.IsNull)
                {
                    throw new Exception("No Image");
                }

                /*
                if (FreeImage.GetPalette(dib) != IntPtr.Zero)
                {
                    byte[] Transparency = new byte[1];
                    Transparency[0] = 0x00;
                    FreeImage.SetTransparencyTable(dib, Transparency);
                    FreeImage.SetTransparent(dib, true);
                }
                */
                // Convert the FreeImage-Bitmap into a .NET bitmap

                Bitmap bitmap = FreeImage.GetBitmap(dib);

                FreeImage.UnloadEx(ref dib);

                return bitmap;
            }
            catch
            {
                if (!dib.IsNull)
                    FreeImage.Unload(dib);

                dib = new FIBITMAP();

                // Safely unload to prevent memory leak.
                FreeImage.UnloadEx(ref dib);

                // Load the example bitmap.
                dib = FreeImage.LoadEx(filepath);

                // Check whether loading succeeded.
                if (dib.IsNull)
                {
                    throw new Exception("No Image");
                }

                // Convert the FreeImage-Bitmap into a .NET bitmap

                /*
                if (FreeImage.GetPalette(dib) != IntPtr.Zero)
                {
                    byte[] Transparency = new byte[1];
                    Transparency[0] = 0x00;
                    FreeImage.SetTransparencyTable(dib, Transparency);
                    FreeImage.SetTransparent(dib, true);
                }
                */

                Bitmap bitmap = FreeImage.GetBitmap(dib);

                return bitmap;
            }
        }

        public static Bitmap LoadImage2(string filepath)
        {
            if (!dib.IsNull)
                FreeImage.Unload(dib);

            if (!dib2.IsNull)
                FreeImage.Unload(dib2);

            //1dib = new FIBITMAP();            

            // Safely unload to prevent memory leak.
            //1FreeImage.UnloadEx(ref dib);

            FREE_IMAGE_FORMAT fif = FREE_IMAGE_FORMAT.FIF_UNKNOWN;

            fif = FreeImage.GetFIFFromFilename(filepath);

            //1dib = FreeImage.LoadEx(filepath, ref fif);
            dib=FreeImage.Load(fif, filepath, 0);

            // Load the example bitmap.
            //1dib = FreeImage.LoadEx(filepath);

            // Check whether loading succeeded.
            if (dib.IsNull)
            {
                throw new Exception("No Image");
            }

            uint bpp_dst=FreeImage.GetBPP(dib);

            if(bpp_dst == 1) {
	    	// convert output to 8-bit
		        bpp_dst = 8;		
	        }

            //IntPtr pbi0 = FreeImage.GetInfo(dib);

            //BITMAPINFO pbi_info0 = (BITMAPINFO)Marshal.PtrToStructure(pbi0, typeof(BITMAPINFO));

            //FIBITMAP dib2 = FreeImage.AllocateT(FreeImage.GetImageType(dib), pbi_info0.bmiHeader.biWidth, pbi_info0.bmiHeader.biHeight, (int)bpp_dst, FreeImage.GetRedMask(dib), FreeImage.GetGreenMask(dib), FreeImage.GetBlueMask(dib));

            dib2 = FreeImage.AllocateT(FreeImage.GetImageType(dib), 1,1, (int)bpp_dst, FreeImage.GetRedMask(dib), FreeImage.GetGreenMask(dib), FreeImage.GetBlueMask(dib));

            if (dib2.IsNull)
            {
                throw new Exception("No Image");
            }

            IntPtr pbih=FreeImage.GetInfoHeader(dib2);

            IntPtr pbi = FreeImage.GetInfo(dib2);            

            Palette pdst_pal = FreeImage.GetPaletteEx(dib2);

            FreeImageAPI.RGBQUAD[] dst_pal = pdst_pal.AsArray;

            //1FreeImageAPI.RGBQUAD[] dst_pal = (FreeImageAPI.RGBQUAD[])Marshal.PtrToStructure(hdst_pal, typeof(FreeImageAPI.RGBQUAD));
            //1RGBQUAD[] dst_pal = (RGBQUAD[])Marshal.PtrToStructure(hdst_pal, typeof(RGBQUAD));
            
            //FreeImageAPI.RGBQUAD[] dst_pal=(FreeImageAPI.RGBQUAD[])new Palette(dib2).AsArray;

            if (bpp_dst == 8)  // build the palette if needed
            {
                if (FreeImage.GetColorType(dib2) == FreeImageAPI.FREE_IMAGE_COLOR_TYPE.FIC_MINISWHITE)
                {
                    // build an inverted greyscale palette			
                    for (int i = 0; i < 256; i++)
                    {
                        dst_pal[i].rgbRed = dst_pal[i].rgbGreen =
                            dst_pal[i].rgbBlue = (byte)(255 - i);
                    }
                }
                else
                {

                    // build a greyscale palette			
                    for (int i = 0; i < 256; i++)
                    {
                        dst_pal[i].rgbRed = dst_pal[i].rgbGreen =
                            dst_pal[i].rgbBlue = (byte)i;
                    }
                }
            }

            IntPtr ppvBits;

            BITMAPINFO pbi_info = (BITMAPINFO)Marshal.PtrToStructure(pbi, typeof(BITMAPINFO));

            //1IntPtr hBitmap=CreateDIBSection(IntPtr.Zero,ref pbi_info,(uint)DIB_RGB_COLORS,out ppvBits,IntPtr.Zero,(uint)0);

             Bitmap bitmap = new Bitmap(pbi_info.bmiHeader.biWidth, pbi_info.bmiHeader.biHeight, PixelFormat.Format8bppIndexed);
            /*
    ColorPalette ncp = bitmap.Palette;
    for (int i = 0; i < 256; i++)
        ncp.Entries[i] = Color.FromArgb(255, i, i, i);
    b.Palette = ncp;
            */

             Color[] col = new Color[dst_pal.GetUpperBound(0)];

             for (int m = 0; m < col.Length; m++)
             {
                 col[m] = Color.FromArgb(dst_pal[m].rgbRed, dst_pal[m].rgbGreen, dst_pal[m].rgbBlue);
             }

            ColorPalette ncp = bitmap.Palette;
    for (int m = 0; m < 256; m++)
        ncp.Entries[m] = Color.FromArgb(dst_pal[m].rgbRed, dst_pal[m].rgbGreen, dst_pal[m].rgbBlue);
    bitmap.Palette = ncp;
             
    Rectangle BoundsRect = new Rectangle(0, 0, pbi_info.bmiHeader.biWidth, pbi_info.bmiHeader.biHeight);

    BitmapData bmpData = bitmap.LockBits(BoundsRect,
                                    ImageLockMode.WriteOnly,
                                    bitmap.PixelFormat);

    IntPtr ptr = bmpData.Scan0;

    int bytes = bmpData.Stride*bitmap.Height;
    var rgbValues = new byte[bytes];

    // fill in rgbValues, e.g. with a for loop over an input array

    Marshal.Copy(rgbValues, 0, ptr, bytes);
    bitmap.UnlockBits(bmpData);
    
            /*
            if (hBitmap == IntPtr.Zero)
            {
                throw new Exception("No Image");
            }
            */
                        
            /*
            if (FreeImage.GetPalette(dib) != IntPtr.Zero)
            {
                byte[] Transparency = new byte[1];
                Transparency[0] = 0x00;
                FreeImage.SetTransparencyTable(dib, Transparency);
                FreeImage.SetTransparent(dib, true);
            }
            */
            // Convert the FreeImage-Bitmap into a .NET bitmap
            //1Bitmap bitmap = FreeImage.GetBitmap(dib);            

            return bitmap;
        }

        /*
         FIBITMAP* CFi_testDoc::GenericLoader(const char* lpszPathName, int flag)
{	
	FREE_IMAGE_FORMAT fif = FIF_UNKNOWN;
	// check the file signature and deduce its format
	// (the second argument is currently not used by FreeImage)
	
	fif = FreeImage_GetFileType(lpszPathName, 0);
	
	if(fif == FIF_UNKNOWN)
	{
		// no signature ?
		// try to guess the file format from the file extension
		fif = FreeImage_GetFIFFromFilename(lpszPathName);
	}
	
	// check that the plugin has reading capabilities ...
	if((fif != FIF_UNKNOWN) && FreeImage_FIFSupportsReading(fif))
	{
		// ok, let's load the file
		FIBITMAP *dib = FreeImage_Load(fif, lpszPathName, flag);
		
		// unless a bad file format, we are done !
		return dib;
	}
	
    m_pThread = new CDisplayThread(m_dib, pView->m_dcOffscreen.GetSafeHdc(), pView->m_dcOffscreenScroll.GetSafeHdc(), m_pFr->m_hWnd, pView);

	m_pThread->CreateThread();


	m_pThread->PostThreadMessage(WM_DRAW_BITMAP, 0, (LPARAM)1); // Zoom Fit

	return NULL;
         * 
         //-----------------
        	m_dcOffscreen.SetViewportOrg(0, 0); // restore the original 
	//position (changed by previous call to this function)

	// this code chunk is taken out of the CResizeEngine::scale method
	// (called from FreeImage_Rescale)
	unsigned bpp_dst = FreeImage_GetBPP(m_dib);
	if(bpp_dst == 1) {
		// convert output to 8-bit
		bpp_dst = 8;		
	}

	// Calculate the zoomed image width
	m_zdib_width = (unsigned)(m_dib_w/zoom + 0.5);
	
	// Calculate the zoomed image height
    m_zdib_height = (unsigned)(m_dib_h/zoom + 0.5);

	m_OffscreenSize.x = m_view_init_width;
	
	m_OffscreenSize.y = m_view_init_height;


	if (m_zdib_width > m_view_init_width)

		m_OffscreenSize.y = m_view_init_height - m_horz_scrollbar_width;


	if (m_zdib_height > m_view_init_height)

		m_OffscreenSize.x = m_view_init_width - m_vert_scrollbar_width;


	// Allocate the "empty" FIBITMAP - just as a BITMAPINFO holder
	m_dib2 = FreeImage_AllocateT(FreeImage_GetImageType(m_dib),
		
		1, 1, // this is a one-by-one pixel sized bitmap ("empty")
		
		bpp_dst,		

		FreeImage_GetRedMask(m_dib),
		
		FreeImage_GetGreenMask(m_dib),

		FreeImage_GetBlueMask(m_dib));

	if (!m_dib2) return false;

	m_pbih = FreeImage_GetInfoHeader(m_dib2);	

	m_pbih->biWidth = m_OffscreenSize.x; // replace 1 by the real backbitmap width

	m_pbih->biHeight = m_OffscreenSize.y; // replace 1 by the real backbitmap height

	m_pbi = FreeImage_GetInfo(m_dib2);	// now we have a full-fledged
	// BITMAPINFO structure for our rescaled image

	// this code chunk is taken out of the CResizeEngine::scale method
	// (called from FreeImage_Rescale)

	m_dst_pal = FreeImage_GetPalette(m_dib2);

	if(bpp_dst == 8)  // build the palette if needed
	{
		if(FreeImage_GetColorType(m_dib2) == FIC_MINISWHITE)
		
			// build an inverted greyscale palette			
			for(int i = 0; i < 256; i++)
			
				m_dst_pal[i].rgbRed = m_dst_pal[i].rgbGreen =
					m_dst_pal[i].rgbBlue = (BYTE)(255 - i);			
		 else 
		
			// build a greyscale palette			
			for(int i = 0; i < 256; i++) 
			
				m_dst_pal[i].rgbRed = m_dst_pal[i].rgbGreen =
					m_dst_pal[i].rgbBlue = (BYTE)i;		
	}

	// Create the DIB Section
	
	HBITMAP hBitmap = CreateDIBSection (NULL, m_pbi, DIB_RGB_COLORS, (void**)&m_pBits, NULL, 0) ;
	
	if (hBitmap == NULL) return false;

	m_OffscreenBitmap.Attach(hBitmap);

	m_pOldBitmap = m_dcOffscreen.SelectObject(&m_OffscreenBitmap);	

	// Fill the background bitmap with a backcolor
	m_dcOffscreen.FillSolidRect(0, 0, m_OffscreenSize.x,
		m_OffscreenSize.y, RGB(160, 160, 160));		

	// Fill the DIB Section bitmap buffer (e.g. content to be displayed)

	BOOL res = false;

	switch (m_ResampleMode)
	{

	case 1:

//	res = FilterRcg(m_dib, m_zdib_width, m_zdib_height, m_OffscreenSize, m_pBits, dst_pal, 2);

//  break;

	if (zoom > 1.0)

	res = LeptonicaScaleAreaMapLow(0, m_dib, m_zdib_width, m_zdib_height, m_OffscreenSize, m_pBits, m_dst_pal, NULL, NULL);

	else

	res = LeptonicaScaleLILow(0, m_dib, m_zdib_width, m_zdib_height, m_OffscreenSize, m_pBits, m_dst_pal, true, NULL, NULL);
	
	break;

	case 2:

	;//res = LeptonicaScaleAreaMapLow(m_dib, m_zdib_width, m_zdib_height, m_OffscreenSize, m_pBits, m_dst_pal);

	break;

	case 3:

	res = LeptonicaScaleBySamplingLow(m_dib, m_zdib_width, m_zdib_height, m_OffscreenSize, m_pBits, m_dst_pal);

	break;

	case 4:	

	res = LeptonicaScaleSmoothLow(m_dib, m_zdib_width, m_zdib_height, m_OffscreenSize, 3, m_pBits, m_dst_pal);

	break;

	case 5:	

//	res = LeptonicaScaleLILow(m_dib, m_zdib_width, m_zdib_height, m_OffscreenSize, m_pBits, m_dst_pal, true);

	break;

	case 6:	

//	res = LeptonicaScaleLILow(m_dib, m_zdib_width, m_zdib_height, m_OffscreenSize, m_pBits, m_dst_pal, false);

	break;

	case 7:

	if(bpp_dst == 8)

	res = RescalePnm8(m_dib, m_zdib_width, m_zdib_height, m_OffscreenSize, m_pBits, m_dst_pal);

	else

	res = RescalePnm(m_dib, m_zdib_width, m_zdib_height, m_OffscreenSize, m_pBits);

	case 8:	

	res = FI_Rescale2(m_dib, m_zdib_width, m_zdib_height, FILTER_BILINEAR, bpp_dst, m_OffscreenSize, m_pBits);

	break;

	case 9:	

	res = FI_Rescale2(m_dib, m_zdib_width, m_zdib_height, FILTER_BOX, bpp_dst, m_OffscreenSize, m_pBits);

	break;

	}

	if (!res)
	{
		FreeImage_Unload(m_dib2);
		
		m_dib2 = NULL;		
		
		return false;
	}


	unsigned m_dev_zdib_width, m_dev_zdib_height;

	// In the MM_TEXT map mode the logical coordinates
	// are exactly the same as the device coordinates
	// so the direct 1-to-1 conversion is possible
	// (in other modes you must use LPtoDP functions).
	m_dev_zdib_width = m_zdib_width;

	m_dev_zdib_height = m_zdib_height;

	if (m_zdib_width > 32767) // Win 95, Win 98 and Win ME limitation
	
	m_dev_zdib_width = 32767;

	if (m_zdib_height > 32767) // Win 95, Win 98 and Win ME limitation
	
	m_dev_zdib_height = 32767;

	m_pCsView->SetScrollSizes(MM_TEXT, CSize(m_dev_zdib_width-1, m_dev_zdib_height-1)); // equal to the image width and height
	// minus 1 - so that the background 1-pixel-wide line would not be visible 
	// at the bitmap right side by the max scroll-right

	// Set the initial screen position of an image to be displayed

	unsigned m_width_shift, m_height_shift;
	
	if (m_zdib_width > m_OffscreenSize.x)
	{ // the image width is bigger than the client area width

		// Width-center the image
		m_width_shift = -(m_dev_zdib_width-m_OffscreenSize.x + 0.5)/2;
		
		// Scroll an image half-width so that it would be width-centered	
		m_pCsView->SetScrollPos(SB_HORZ, (m_dev_zdib_width-m_OffscreenSize.x)/2);
	}

	else
		
		m_width_shift = 0; // 1 param for SetViewportOrg function
			
	if (m_zdib_height > m_OffscreenSize.y)
	{ // the image height is bigger than the client area height

		// Height-center the image
		m_height_shift = -(m_dev_zdib_height-m_OffscreenSize.y + 0.5)/2;
		
		// Scroll an image half-height so that it would be height-centered
		m_pCsView->SetScrollPos(SB_VERT, (m_dev_zdib_height-m_OffscreenSize.y)/2);
	}

	else

		m_height_shift = 0; // 2 param for SetViewportOrg function


	m_dcOffscreen.SetViewportOrg(m_width_shift, m_height_shift);	

	m_zoom = zoom; // Remember the current zoom value

	DWORD dw_temp_zoom;

	// packing float into DWORD without any fractional part loss
	memcpy(&dw_temp_zoom, &zoom, sizeof(float));

	::SendMessage(m_hFr, WM_SHOW_ZOOM_ON_SCROLLBAR, dw_temp_zoom, 0);

	m_pCsView->Invalidate(false);

	m_pCsView->UpdateWindow();	

	return true;
}
}
    */
        public static void SaveBitmap(string filepath, Bitmap img,FREE_IMAGE_FORMAT fmt)
        {            
            if (filepath.ToLower().EndsWith(".png"))
            {
                Color c = img.GetPixel(0, 0);
                img.MakeTransparent(c);
                img.Save(filepath, ImageFormat.Png);

            }
            else if (filepath.ToLower().EndsWith(".gif"))
            {
                Color c2 = img.GetPixel(0, 0);
                //1img=ChangeFormatHelper.MakeTransparentGif(img,c2);
                img.Save(filepath, ImageFormat.Gif);
            }
            else if (filepath.ToLower().EndsWith(".jpg") || filepath.ToLower().EndsWith(".jpeg"))
            {                
                img.Save(filepath, ImageFormat.Jpeg);
            }
            else if (filepath.ToLower().EndsWith(".bmp"))
            {
                img.Save(filepath, ImageFormat.Bmp);
            }
            /*1
            else if (filepath.ToLower().EndsWith(".ico"))
            {                                    
                    Color c3 = img.GetPixel(0, 0);
                    img.MakeTransparent(c3);
                    IconHelper.SaveAsIcon(filepath, img);
            }*/
            else
            {

                //FreeImageAPI.FreeImageBitmap fb=new FreeImageAPI.FreeImageBitmap(img);
                //fb.MakeTransparent(Color.White);

                //fb.BackgroundColor = Color.White;
                // fb.MakeTransparent();

                //fb.Save(filepath, fmt, FREE_IMAGE_SAVE_FLAGS.DEFAULT);


                //if (!dib.IsNull)
                //  FreeImage.Unload(dib);

                //dib = FreeImage.CreateFromBitmap(img);

                //FreeImageAPI.FreeImageBitmap fb = FreeImageAPI.FreeImageBitmap.c

                /*
                if (FreeImage.GetPalette(dib) != IntPtr.Zero)
                {
                    Palette pal = new Palette(dib);
                    byte[] Transparency = new byte[pal.Length];

                    for (int k = 0; k < pal.Length; k++)
                    {
                        Transparency[0] = 0xFF;
                    }

                    FreeImage.SetTransparencyTable(dib, Transparency);
                    FreeImage.SetTransparent(dib, true);
                }
                  */

                //FreeImage.Save(fmt, dib, filepath, FREE_IMAGE_SAVE_FLAGS.DEFAULT);


                //img.MakeTransparent(Color.White);
                                
                FreeImage.SaveBitmap(img, filepath, fmt, FREE_IMAGE_SAVE_FLAGS.DEFAULT);
            }
        }

        public static List<string> GetSupportedFileExtensions()
        {
            Array valf=Enum.GetValues(typeof(FREE_IMAGE_FORMAT));

            List<string> lst = new List<string>();

            for (int k=0;k<valf.Length;k++)
            {
                string str = FreeImage.GetFIFExtensionList((FREE_IMAGE_FORMAT)valf.GetValue(k));

                if (str == null) continue;

                string[] sz = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                for (int m = 0; m < sz.Length; m++)
                {
                    lst.Add(sz[m]);
                }
            }

            return lst;            
        }

        public static string GetSupportedFileExtensionsFilter()
        {
            Array valf = Enum.GetValues(typeof(FREE_IMAGE_FORMAT));

            string ff = "All Supported Image Types (";

            string ffall = "";

            for (int k = 0; k < valf.Length; k++)
            {
                string str = FreeImage.GetFIFExtensionList((FREE_IMAGE_FORMAT)valf.GetValue(k));

                if (str == null) continue;

                string[] sz = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                for (int m = 0; m < sz.Length; m++)
                {
                    ff += "*." + sz[m] + ";";
                    ffall += "*." + sz[m] + ";";
                }
            }

            if (ff.EndsWith(";"))
            {
                ff = ff.Substring(0, ff.Length - 1);
            }

            if (ffall.EndsWith(";"))
            {
                ffall = ffall.Substring(0, ffall.Length - 1);
            }

            ff += ")|" + ffall + "|All Files (*.*)|*.*";

            for (int k = 0; k < valf.Length; k++)
            {
                string str = FreeImage.GetFIFExtensionList((FREE_IMAGE_FORMAT)valf.GetValue(k));

                if (str == null) continue;

                string fd = FreeImage.GetFIFDescription((FREE_IMAGE_FORMAT)valf.GetValue(k));

                ff += "|" + fd + " (";                               

                string ffe = "";

                string[] sz = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                for (int m = 0; m < sz.Length; m++)
                {
                    ff += "*." + sz[m] + ";";
                    ffe += "*." + sz[m] + ";";
                }

                if (ff.EndsWith(";"))
                {
                    ff = ff.Substring(0, ff.Length - 1);
                }

                if (ffe.EndsWith(";"))
                {
                    ffe = ffe.Substring(0, ffe.Length - 1);
                }

                ff+=")|"+ffe;
            }

            return ff;
        }

        public static string GetSupportedFileExtensionsFilterHtml()
        {
            Array valf = Enum.GetValues(typeof(FREE_IMAGE_FORMAT));

            string ff = "<ul>";                        

            for (int k = 0; k < valf.Length; k++)
            {
                string str = FreeImage.GetFIFExtensionList((FREE_IMAGE_FORMAT)valf.GetValue(k));

                if (str == null) continue;

                string fd = FreeImage.GetFIFDescription((FREE_IMAGE_FORMAT)valf.GetValue(k));

                ff += "<li>" + fd + " (" + str + ")</li>";
            }

            ff += "</ul>";

            return ff;
        }
    }

    public class LoadImageReturn
    {
        public Bitmap img = null;
        public FREE_IMAGE_FORMAT FileType = FREE_IMAGE_FORMAT.FIF_JPEG;
    }
}
