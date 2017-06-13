﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data;
using System.IO;
using System.Web;
using System.Configuration;
using System.Drawing;
using UserFormsDAL;
using Winnovative.WnvHtmlConvert;
using Winnovative.HtmlToPdfClient;

namespace UserFormsBLL
{
    public class InBuiltDataBLL
    {
        public List<Months> GetMonths()
        {
            List<Months> objMonths = new List<Months>();
            for (int i = 0; i < 12; i++)
            {
                objMonths.Add(new Months
                {
                    Text = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[i],
                    Value = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[i]
                });
            }
            objMonths.Insert(0, new Months { Text = "Select", Value = "" });
            return objMonths;
        }
        public List<Months> GetMonthsWithNumber()
        {
            List<Months> objMonths = new List<Months>();
            for (int i = 0; i < 12; i++)
            {
                objMonths.Add(new Months
                {
                    Text = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[i],
                    Value = (i + 1).ToString()
                });
            }
            objMonths.Insert(0, new Months { Text = "Select", Value = "" });
            return objMonths;
        }
        public List<Dates> GetDates()
        {
            List<Dates> objDates = new List<Dates>();
            for (int i = 01; i <= 31; i++)
            {
                objDates.Add(new Dates
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }
            objDates.Insert(0, new Dates { Text = "Select", Value = "" });
            return objDates;
        }
        public List<Years> GetYears()
        {
            List<Years> objYears = new List<Years>();
            DateTime dtYear = DateTime.Today;
            dtYear = dtYear.AddYears(-100);
            for (int i = 1; i <= 100; i++)
            {
                objYears.Add(new Years
                {
                    Text = dtYear.AddYears(i).Year.ToString(),
                    Value = dtYear.AddYears(i).Year.ToString()
                });
            }
            objYears.Insert(0, new Years { Text = "Select", Value = "" });
            return objYears;
        }
        public List<Years> GetManufacturedYears()
        {
            List<Years> objYears = new List<Years>();
            DateTime dtYear = DateTime.Today;
            dtYear = dtYear.AddYears(-25);
            for (int i = 1; i <= 25; i++)
            {
                objYears.Add(new Years
                {
                    Text = dtYear.AddYears(i).Year.ToString(),
                    Value = dtYear.AddYears(i).Year.ToString()
                });
            }
            objYears.Insert(0, new Years { Text = "Select", Value = "" });
            return objYears;
        }
        public List<HeightFeet> GetHeightFeet()
        {
            List<HeightFeet> objHeightFeet = new List<HeightFeet>();
            for (int i = 0; i <= 10; i++)
            {
                objHeightFeet.Add(new HeightFeet
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }
            return objHeightFeet;
        }
        public List<HeightInches> GetHeightInches()
        {
            List<HeightInches> objHeightInches = new List<HeightInches>();
            for (int i = 0; i <= 11; i++)
            {
                objHeightInches.Add(new HeightInches
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }
            objHeightInches.Insert(0, new HeightInches { Text = "Select", Value = "" });
            return objHeightInches;
        }
        public string CreateFolder(string folderName, string profileID)
        {
            string serverpath = ConfigurationManager.AppSettings.Get("USPDFolderPath") + "Upload\\" + folderName + "\\";
            string sDirPath = serverpath + profileID;
            DirectoryInfo objSearchDir = new DirectoryInfo(sDirPath);

            if (!objSearchDir.Exists)
            {
                objSearchDir.Create();
            }
            return sDirPath;
        }
        public string GetLogoPath(string logourl, string rootPath, int profileID, bool IsShortLogo = true, bool IsAdditionalLogo = false)
        {
            int defaultlogoWidth = 150;



            string logoPath = "";
            string originalfilename = logourl;
            string extension = System.IO.Path.GetExtension(originalfilename);

            string junk = ".";
            string[] ret = originalfilename.Split(junk.ToCharArray());
            string thumbimg1 = ret[0];
            thumbimg1 = thumbimg1 + "_thumb" + extension;
            string url = ConfigurationManager.AppSettings.Get("USPDFolderPath") + "\\Upload\\Logos\\" + profileID + "\\" + thumbimg1;
            FileInfo obj = new FileInfo(url);
            logoPath = "";
            if (File.Exists(url))
            {
                FileStream fs = new FileStream(url, FileMode.Open, FileAccess.Read, FileShare.Read);
                System.Drawing.Image originalLogo = System.Drawing.Image.FromStream(fs);
                fs.Flush();
                fs.Close();
                fs.Dispose();

                if (originalLogo.Width < defaultlogoWidth)
                {
                    defaultlogoWidth = originalLogo.Width;
                }


                string styles = "";
                if (IsShortLogo == false && IsAdditionalLogo == true)
                {
                    styles = "style='margin-left:10px;'";
                }
                else if (IsShortLogo == false)
                {
                    styles = "style='margin-left:30px;'";
                }

                if (obj.Exists)
                {
                    string imageDisID = Guid.NewGuid().ToString();
                    logoPath = "<img align='center' " + styles + "  src='" + rootPath + "/Upload/Logos/" + profileID + "/" + thumbimg1 + "?Guid=" + imageDisID + "'/>";
                }
                else
                {
                    string imageDisID = Guid.NewGuid().ToString();
                    logoPath = "<img  align='center' " + styles + "  src='" + rootPath + "/Upload/Logos/" + profileID + "/" + logourl + "?Guid=" + imageDisID + "'/>";
                }
            }
            return logoPath;
        }
        #region Error Log

        public void ErrorHandling(string errorType, string pPageName, string methodName, string message, string strackTrace, string innerException, string data)
        {
            CommonDAL.InsertExceptionDetails(errorType, pPageName, methodName, message, strackTrace, innerException, data);
        }

        #endregion
        public void CreateImage(string path, int profileID, int userID, int bulletinID, string html)
        {
            try
            {
                // Get the server IP and port
                string serverIP = ConfigurationManager.AppSettings.Get("Winnovative_serverIP");
                uint serverPort = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("Winnovative_serverPort"));

                // Create a HTML to Image converter object with default settings
                HtmlToImageConverter htmlToImageConverter = new HtmlToImageConverter(serverIP, serverPort);

                // Set license key received after purchase to use the converter in licensed mode
                // Leave it not set to use the converter in demo mode
                htmlToImageConverter.LicenseKey = ConfigurationManager.AppSettings.Get("WinnovativePDFKey");

                // Set HTML Viewer width in pixels which is the equivalent in converter of the browser window width
                htmlToImageConverter.HtmlViewerWidth = 650;
                // Set if the created image has a transparent background
                htmlToImageConverter.TransparentBackground = false;

                htmlToImageConverter.NavigationTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Winnovative_NavigationTimeout"));
                htmlToImageConverter.ConversionDelay = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Winnovative_ConversionDelay"));
                string strhtml = html;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(strhtml.ToString());
                string saveFilePath = path + profileID.ToString();
                if (!System.IO.Directory.Exists(saveFilePath))
                {
                    System.IO.Directory.CreateDirectory(saveFilePath);
                }
                string savelocation = saveFilePath + "\\" + bulletinID.ToString() + ".jpg";
                string tempimagepath = path + profileID.ToString() + "\\" + profileID.ToString() + userID.ToString() + ".jpg";
                if (File.Exists(savelocation))
                {
                    File.Delete(savelocation);
                }
                string baseUrl = "";

                htmlToImageConverter.ConvertHtmlToFile(strhtml, baseUrl, ImageType.Jpeg, tempimagepath);

                string srcfile = tempimagepath;
                string destfile = savelocation;
                int thumbWidth = 350;
                System.Drawing.Image image = System.Drawing.Image.FromFile(srcfile);
                int srcWidth = image.Width;
                int srcHeight = image.Height;
                Decimal sizeRatio = ((Decimal)srcHeight / srcWidth);
                int thumbHeight = Decimal.ToInt32(sizeRatio * thumbWidth);
                Bitmap bmp = new Bitmap(thumbWidth, thumbHeight);
                System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, thumbWidth, thumbHeight);
                gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);
                bmp.Save(destfile);
                bmp.Dispose();
                image.Dispose();
                if (File.Exists(tempimagepath))
                {
                    File.Delete(tempimagepath);
                }
            }
            catch (Exception ex)
            {
                //Error 
                ErrorHandling("ERROR", "InBuiltDataBLL", "CreateImage", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public void CreateImageForVirtual(string path, int profileID, int userID, int bulletinID, string html)
        {
            try
            {
                // *** Convert to image ***//
                string strhtml = html;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(strhtml.ToString());
                ImgConverter imgConverter = new ImgConverter();
                MemoryStream msval = new MemoryStream(buffer);
                imgConverter.LicenseKey = ConfigurationManager.AppSettings.Get("imgkeyval");
                imgConverter.PageWidth = 650;
                string saveFilePath = path + profileID.ToString();
                if (!System.IO.Directory.Exists(saveFilePath))
                {
                    System.IO.Directory.CreateDirectory(saveFilePath);
                }
                string savelocation = saveFilePath + "\\" + bulletinID.ToString() + ".jpg";
                string tempimagepath = path + profileID.ToString() + "\\" + profileID.ToString() + userID.ToString() + ".jpg";
                if (File.Exists(savelocation))
                {
                    File.Delete(savelocation);
                }
                imgConverter.SaveImageFromHtmlStreamToFile(msval, Encoding.UTF8, System.Drawing.Imaging.ImageFormat.Jpeg, tempimagepath);
                //msval = null;
                buffer = null;

                // *** Creating Thmb image *** //
                string srcfile = tempimagepath;
                string destfile = savelocation;
                int thumbWidth = 350;
                System.Drawing.Image image = System.Drawing.Image.FromFile(srcfile);
                int srcWidth = image.Width;
                int srcHeight = image.Height;
                Decimal sizeRatio = ((Decimal)srcHeight / srcWidth);
                int thumbHeight = Decimal.ToInt32(sizeRatio * thumbWidth);
                Bitmap bmp = new Bitmap(thumbWidth, thumbHeight);
                System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, thumbWidth, thumbHeight);
                gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);
                bmp.Save(destfile);
                bmp.Dispose();
                image.Dispose();
                if (File.Exists(tempimagepath))
                {
                    File.Delete(tempimagepath);
                }
                msval.Flush();
                msval.Close();
                msval.Dispose();
            }
            catch (Exception ex)
            {
                //Error 
                ErrorHandling("ERROR", "CrimeHighlights.aspx.cs", "Save_Update_BulletinDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public DataTable GetBulletinLabelData()
        {
            return BulletinDAL.GetBulletinLabelData();
        }
    }

    public class Months
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public class Dates
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public class Years
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public class HeightFeet
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public class HeightInches
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}