using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Configuration;
using System.Net;
using System.IO;
using Winnovative.PdfCreator;
using Aurigma.GraphicsMill.Transforms;
using Aurigma.GraphicsMill.Codecs;
using Aurigma.GraphicsMill;
using QRCoder;
using Aurigma.GraphicsMill.AdvancedDrawing;

namespace USPDHUB.Business.MyAccount
{
    public partial class DownloadInstallers : BaseWeb
    {
        public int ProfileID = 0;
        public int UserID = 0;
        BusinessBLL objBus = new BusinessBLL();
        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public bool ShowBulletins = false;
        public string RootPath = "";
        public string DomainName = "";
        public DataTable dtUserDetails = new DataTable();
        public DataTable dtProfiles = new DataTable();
        public bool IsSuperAdmin = true;
        public bool IsParent = true;
        public bool IsBlockedSendAccess = true;
        CommonBLL objCommon = new CommonBLL();
        public string fstext = "";

        public string App_DisplayName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Chcking for user session ***
                if (Session["UserID"] == null || Session["ProfileID"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());

                /*** App Display Name  ***/
                if (DomainName.ToLower().Contains("uspdhub"))
                    App_DisplayName = Convert.ToString(ConfigurationManager.AppSettings.Get("UspdhubAppName"));
                else if (DomainName.ToLower().Contains("twovie"))
                    App_DisplayName = Convert.ToString(ConfigurationManager.AppSettings.Get("TwovieAppName"));
                else if (DomainName.ToLower().Contains("myyouth"))
                    App_DisplayName = Convert.ToString(ConfigurationManager.AppSettings.Get("MyYouthHubAppName"));
                else if (DomainName.ToLower().Contains("inschoolhub"))
                    App_DisplayName = Convert.ToString(ConfigurationManager.AppSettings.Get("InschoolhubAppName"));
                else
                    App_DisplayName = Convert.ToString(ConfigurationManager.AppSettings.Get("UspdhubAppName"));


                if (!IsPostBack)
                {
                    dtProfiles = objBus.GetProfileDetailsByProfileID(ProfileID);
                    hdnIsLiteVersion.Value = Convert.ToString(dtProfiles.Rows[0]["IsLiteVersion"]);
                    string IconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\QRCodes\\" + ProfileID.ToString();
                    if (Directory.Exists(IconPath))
                    {
                        Session["IsBranded"] = dtProfiles.Rows[0]["IsBranded_App"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dtProfiles.Rows[0]["Parent_ProfileID"].ToString()))
                        IsParent = false;
                    if (Session["C_USER_ID"] != null)
                    {
                        dtUserDetails = objBus.GetUserDtlsByUserID(Convert.ToInt32(Session["C_USER_ID"]));
                        if (!string.IsNullOrEmpty(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"].ToString()))
                            IsSuperAdmin = Convert.ToBoolean(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"]);
                        IsBlockedSendAccess = objCommon.GetPermissionAccess(Convert.ToInt32(Session["C_USER_ID"]), PageNames.BLOCKEDSENDERS);
                    }

                    DataTable dtSelectedTools = objBus.GetSelectedToolsByUserID(UserID);
                    if (dtSelectedTools.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dtSelectedTools.Rows[0]["Package_Number"].ToString()))
                        {
                            if (Convert.ToInt32(dtSelectedTools.Rows[0]["Package_Number"].ToString()) > 4)
                                ShowBulletins = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DownloadInstallers.aspx.cs", "Page_Load", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }

        protected void btnshortcut_OnClick(object sender, EventArgs e)
        {
            try
            {
                DomainName = Session["VerticalDomain"].ToString();
                DomainName = DomainName + "_ShortcutURL.exe";

                string VirtualPath = Server.MapPath("~/Upload/DownloadInstallers/" + DomainName);
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + DomainName);
                Response.TransmitFile(VirtualPath);


                /*
                if (DomainName.ToLower() == "uspdhubcom".ToLower())
                {
                    string VirtualPath = Server.MapPath("~/Upload/DownloadInstallers/USPDShortcutURL.exe");
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=USPDShortcutURL.exe");
                    Response.TransmitFile(VirtualPath);
                }
                else if (DomainName.ToLower() == "mgivein".ToLower() || DomainName.ToLower() == "inschoolhubcom".ToLower())
                {
                    string VirtualPath = Server.MapPath("~/Upload/DownloadInstallers/SchoolHubShortcutURL.exe");
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=SchoolHubShortcutURL.exe");
                    Response.TransmitFile(VirtualPath);
                }
                */
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DownloadInstallers.aspx.cs", "btnshortcut_OnClick", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnTipsmanager_OnClick(object sender, EventArgs e)
        {
            try
            {
                DomainName = Session["VerticalDomain"].ToString();
                DomainName = DomainName + "_DesktopAlerts.exe";
                string VirtualPath = Server.MapPath("~/Upload/DownloadInstallers/" + DomainName);
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + DomainName);
                Response.TransmitFile(VirtualPath);

                /*
                if (DomainName.ToLower() == "uspdhubcom".ToLower())
                {
                    string VirtualPath = Server.MapPath("~/Upload/DownloadInstallers/USPDTipsManager.exe");
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=USPDTipsManager.exe");
                    Response.TransmitFile(VirtualPath);
                }
                else if (DomainName.ToLower() == "mgivein".ToLower() || DomainName.ToLower() == "inschoolhubcom".ToLower())
                {
                    string VirtualPath = Server.MapPath("~/Upload/DownloadInstallers/SchoolHubTipsManager.exe");
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=SchoolHubTipsManager.exe");
                    Response.TransmitFile(VirtualPath);
                }
                 * */
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DownloadInstallers.aspx.cs", "btnTipsmanager_OnClick", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void imgBtnQRcodeDownload_OnClick(object sender, EventArgs e)
        {
            // Write Your Stuff here for QR Code Download as Image.
            try
            {
                string QRCodeFOlderPath = Server.MapPath("~/Upload/QRCodes/" + ProfileID + "/" + ProfileID + "_QRCode.jpg");
                string smallImg = QRCodeFOlderPath.Replace("_QRCode", "_QRCode_small");
                string imgThumb = QRCodeFOlderPath.Replace("_QRCode", "_QRCode_thumb");
                if (File.Exists(QRCodeFOlderPath))
                {
                    if (File.Exists(smallImg))
                    {
                        File.Delete(smallImg);
                    }

                    using (System.Drawing.Image src = System.Drawing.Image.FromFile(QRCodeFOlderPath))
                    {
                        using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(220, 280))
                        {
                            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
                            g.Clear(System.Drawing.Color.White);
                            g.DrawImageUnscaled(src, 10, 0, 171, 171);
                            bmp.Save(smallImg);
                        }
                    }



                    DataTable dtAppStoresLinks = objBus.GetAppStoresLinks(ProfileID);
                    string appname_Image = DrawRotatedAppNameText_QRCode(dtAppStoresLinks.Rows[0]["App_DisplayName"].ToString());

                    #region QR code with App Name

                    try
                    {
                         

                        //Load background image
                        Aurigma.GraphicsMill.Bitmap bitmap =
                            new Aurigma.GraphicsMill.Bitmap(smallImg);
                        int orgImgWidth = bitmap.Width;
                        int orgImgHeight = bitmap.Height;
                        //Load small image (foreground image)
                        Aurigma.GraphicsMill.Bitmap smallBitmap =
                            new Aurigma.GraphicsMill.Bitmap(appname_Image);

                        int newImgWidth = smallBitmap.Width;
                        int newImgHeight = smallBitmap.Height;
                        int locatedX = ((orgImgWidth - newImgWidth) / 2) - dtAppStoresLinks.Rows[0]["App_DisplayName"].ToString().Length;
                        int locatedY = ((orgImgHeight - newImgHeight) / 2) + 140;


                         
                        //Draw foreground image on background with transparency
                        bitmap.Draw(smallBitmap, locatedX, locatedY,
                           smallBitmap.Width, smallBitmap.Height,
                            Aurigma.GraphicsMill.Transforms.CombineMode.Alpha, 0.7f, Aurigma.GraphicsMill.Transforms.ResizeInterpolationMode.High);

                        bitmap.Save(imgThumb);
                    }
                    catch (Exception ex)
                    {
                        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                        //Error 
                        objInBuiltData.ErrorHandling("ERROR", "Utilities.cs", "imgBtnQRcodeDownload_OnClick", ex.Message,
                        Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                    }

                    #endregion

                    Response.ContentType = "image/jpg";
                    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + ProfileID + "_QRCode.jpg" + "\"");
                    Response.TransmitFile(imgThumb);
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DownloadInstallers.aspx.cs", "imgBtnQRcodeDownload_OnClick", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

                throw new Exception(ex.Message);

            }
        }

        //Branded App
        protected void btnBranded_OnClick(object sender, EventArgs e)
        {
            ConvertHtmlToPdf();
        }

        private void ConvertHtmlToPdf()
        {
            try
            {
                /*** ~/Business/MyAccount/DownloadBrandedApp.htm file not using ***/

                FileStream fs = File.OpenRead(Server.MapPath("~/BulletinPreview/DownloadBrandedApp.htm")); //File.OpenRead(Server.MapPath("~/Business/MyAccount/DownloadBrandedApp.htm"));
                byte[] byt = new byte[(int)fs.Length];
                char[] chr = new char[byt.Length];
                fs.Read(byt, 0, (int)fs.Length);
                byt.CopyTo(chr, 0);
                fstext = new string(chr);
                fs.Close();
                fstext = fstext.Replace("ï»¿", "");
                DataTable dt = new DataTable();
                dt = objBus.GetBusinessProfileByProfileID(ProfileID);
                string Logo = "";
                string imagepath = string.Empty;
                if (dt.Rows.Count > 0)
                {

                    fstext = fstext.Replace("##Profile_Name##", dt.Rows[0]["Profile_name"].ToString());

                    string orginialPrintableIcon = Server.MapPath("~/Upload/BrandedAppRequestPrintableAppStoreIcons/" + ProfileID + "/" + dt.Rows[0]["Printable_App_Store_Icon"].ToString());

                    if (File.Exists(orginialPrintableIcon))
                    {
                        int BrandedAppFlyerLogoWidth = Convert.ToInt32(ConfigurationManager.AppSettings.Get("BrandedAppFlyerLogoWidth"));
                        int BrandedAppFlyerLogoHeight = Convert.ToInt32(ConfigurationManager.AppSettings.Get("BrandedAppFlyerLogoHeight"));
                        int resizeWidth = Convert.ToInt32(ConfigurationManager.AppSettings.Get("BrandedAppFlyerLogoWidth"));
                        imagepath = Server.MapPath("~") + "Upload\\TempPrintable_App_Store_Icon\\" + ProfileID.ToString();
                        if (!Directory.Exists(imagepath))
                            Directory.CreateDirectory(imagepath);

                        string newImg = imagepath + "\\" + dt.Rows[0]["Printable_App_Store_Icon"].ToString();
                        using (var reader = ImageReader.Create(orginialPrintableIcon))
                        using (var resize = new Resize(BrandedAppFlyerLogoWidth, BrandedAppFlyerLogoHeight, ResizeInterpolationMode.High, ResizeMode.Fit))
                        using (var writer = ImageWriter.Create(newImg))
                        {
                            Pipeline.Run(reader + resize + writer);
                        }
                        Logo = "<img style=\"vertical-align: middle; border: 0;\" src=\"" + RootPath + "\\Upload\\TempPrintable_App_Store_Icon\\" + ProfileID + "\\" + dt.Rows[0]["Printable_App_Store_Icon"].ToString() + "\" alt=\"Logo\" />";

                    }

                    fstext = fstext.Replace("##Logo##", Logo);
                    fstext = fstext.Replace("##IOS_Url##", dt.Rows[0]["IOS_Url"].ToString());
                    fstext = fstext.Replace("##Android_Url##", dt.Rows[0]["Android_Url"].ToString());
                    fstext = fstext.Replace("##Windows_Url##", dt.Rows[0]["Windows_Url"].ToString());
                    string QRCodeFOlderPath = Server.MapPath("~/Upload/QRCodes/" + ProfileID + "/");
                    string QRCode = "";
                    if (File.Exists(QRCodeFOlderPath + ProfileID + "_QRCode.png"))
                    {
                        QRCode = RootPath + "/Upload/QRCodes/" + ProfileID + "/" + ProfileID + "_QRCode.png";
                    }
                    else if (File.Exists(QRCodeFOlderPath + ProfileID + "_QRCode.jpg"))
                    {
                        QRCode = RootPath + "/Upload/QRCodes/" + ProfileID + "/" + ProfileID + "_QRCode.jpg";
                    }
                    fstext = fstext.Replace("##QRCode##", QRCode);
                    fstext = fstext.Replace("##Android##", RootPath + "/Images/android.jpg");
                    fstext = fstext.Replace("##Apple##", RootPath + "/Images/apple.jpg");
                    fstext = fstext.Replace("##Windows##", RootPath + "/Images/windows.jpg");
                }


                /*
                //set the license key
                LicensingManager.LicenseKey = ConfigurationManager.AppSettings.Get("pdfkeyval");

                //create a PDF document
                Document document = new Document();
                document.CompressionLevel = CompressionLevel.NormalCompression;
                document.Margins = new Margins(10, 10, 0, 0);
                document.Security.CanPrint = true;
                document.Security.UserPassword = "";
                document.DocumentInformation.Author = "Logictree IT Solutions, Inc";
                document.ViewerPreferences.HideToolbar = false;

                float xLocation = 5;
                float yLocation = 5;
                float width = -1;
                float height = -1;

                AddElementResult addResult;
                PdfPage page = document.Pages.AddNewPage(PageSize.A4, new Margins(10, 10, 10, 10), PageOrientation.Portrait);
                HtmlToPdfElement htmlToPdfElement;
                htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, width, height, fstext, null);
                htmlToPdfElement.HtmlViewerWidth = 793;
                addResult = page.AddElement(htmlToPdfElement);

                string pdfilenameval = objCommon.ReplaceSpecialCharacter(Convert.ToString(dt.Rows[0]["Profile_name"])) + " - Flyer Download.pdf";
                document.Save(Response, false, pdfilenameval);
                */

                string pdfilenameval = objCommon.ReplaceSpecialCharacter(Convert.ToString(dt.Rows[0]["Profile_name"])) + " - Flyer Download";
                string savelocation = HttpContext.Current.Server.MapPath("~/Upload/").ToString() + pdfilenameval + ".pdf";
                objCommon.HtmlToPDF_Print(fstext.ToString(), pdfilenameval, savelocation, true);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DownloadInstallers.aspx.cs", "ConvertHtmlToPdf", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnISAFlyer_OnClick(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = File.OpenRead(Server.MapPath("~/BulletinPreview/inSchoolAlertFlyer.htm"));
                byte[] byt = new byte[(int)fs.Length];
                char[] chr = new char[byt.Length];
                fs.Read(byt, 0, (int)fs.Length);
                byt.CopyTo(chr, 0);
                fstext = new string(chr);
                fs.Close();
                fstext = fstext.Replace("ï»¿", "");
                DataTable dt = new DataTable();
                dt = objBus.GetBusinessProfileByProfileID(ProfileID);
                string Logo = "";
                string imagepath = string.Empty;
                if (dt.Rows.Count > 0)
                {
                    fstext = fstext.Replace("##Profile_Name##", dt.Rows[0]["Profile_name"].ToString());
                    string sourceLogo = Server.MapPath("/Images/VerticalLogos/" + DomainName + "logo.png");
                    if (File.Exists(sourceLogo))
                    {
                        Logo = "<img style=\"vertical-align: middle; border: 0;\" src=\"" + RootPath + "\\Images\\VerticalLogos\\" + DomainName + "logo.png" + "\" alt=\"Logo\" />";
                    }
                    fstext = fstext.Replace("##Logo##", Logo);
                    fstext = fstext.Replace("##IOS_Url##", ConfigurationManager.AppSettings["inSchoolAlertLiteAppurl"]);
                    fstext = fstext.Replace("##Android_Url##", ConfigurationManager.AppSettings["inSchoolAlertLiteAppurl"]);
                    fstext = fstext.Replace("##Windows_Url##", ConfigurationManager.AppSettings["inSchoolAlertLiteAppurl"]);
                    string QRCodeFOlderPath = Server.MapPath("~/Upload/DefaultQRCodes/");
                    if (File.Exists(QRCodeFOlderPath + DomainName + "_QRCode.png"))
                    {
                        QRCodeFOlderPath = RootPath + "/Upload/DefaultQRCodes/" + DomainName + "_QRCode.png";
                    }
                    else if (File.Exists(QRCodeFOlderPath + DomainName + "_QRCode.jpg"))
                    {
                        QRCodeFOlderPath = RootPath + "/Upload/DefaultQRCodes/" + DomainName + "_QRCode.jpg";
                    }
                    fstext = fstext.Replace("##QRCode##", QRCodeFOlderPath);
                    fstext = fstext.Replace("##Android##", RootPath + "/Images/android.jpg");
                    fstext = fstext.Replace("##Apple##", RootPath + "/Images/apple.jpg");
                    fstext = fstext.Replace("##Windows##", RootPath + "/Images/windows.jpg");
                }


                /*
                //set the license key
                LicensingManager.LicenseKey = ConfigurationManager.AppSettings.Get("pdfkeyval");

                //create a PDF document
                Document document = new Document();
                document.CompressionLevel = CompressionLevel.NormalCompression;
                document.Margins = new Margins(10, 10, 0, 0);
                document.Security.CanPrint = true;
                document.Security.UserPassword = "";
                document.DocumentInformation.Author = "Logictree IT Solutions, Inc";
                document.ViewerPreferences.HideToolbar = false;

                float xLocation = 5;
                float yLocation = 5;
                float width = -1;
                float height = -1;

                AddElementResult addResult;
                PdfPage page = document.Pages.AddNewPage(PageSize.A4, new Margins(10, 10, 10, 10), PageOrientation.Portrait);
                HtmlToPdfElement htmlToPdfElement;
                htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, width, height, fstext, null);
                htmlToPdfElement.HtmlViewerWidth = 793;
                addResult = page.AddElement(htmlToPdfElement);

                string filename = objCommon.ReplaceSpecialCharacter(Convert.ToString(dt.Rows[0]["Profile_name"])) + " - Flyer Download.pdf";
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                document.Save(Response, false, filename);
                */

                string filename = objCommon.ReplaceSpecialCharacter(Convert.ToString(dt.Rows[0]["Profile_name"])) + " - Flyer Download";
                string savelocation = HttpContext.Current.Server.MapPath("~/Upload/").ToString() + filename;
                objCommon.HtmlToPDF_Print(fstext.ToString(), filename, savelocation, true);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DownloadInstallers.aspx.cs", "btnISAFlyer_OnClick", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnISANotifications_OnClick(object sender, EventArgs e)
        {
            try
            {
                DomainName = Session["VerticalDomain"].ToString();
                DomainName = DomainName + "_NotificationAlerts.exe";
                string VirtualPath = Server.MapPath("~/Upload/DownloadInstallers/" + DomainName);
                if (File.Exists(VirtualPath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + DomainName);
                    Response.TransmitFile(VirtualPath);
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DownloadInstallers.aspx.cs", "btnISANotifications_OnClick", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnUSPDFlyer_OnClick(object sender, EventArgs e)
        {
            try
            {
                #region USPDhub Lite Version QR Code

                //string code = RootPath + "/QRCodeResponse.aspx?ProfileID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString()) + "&VC=" + EncryptDecrypt.DESEncrypt(DomainName) + "&Type=" + EncryptDecrypt.DESEncrypt("QRCode");

                string Parent_ProfileID = "";
                DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                if (dtProfile.Rows[0]["Parent_ProfileID"] != null)
                { Parent_ProfileID = dtProfile.Rows[0]["Parent_ProfileID"].ToString(); }

                string vcode = "1";
                if (DomainName.ToLower().Contains("uspdhub"))
                {
                    vcode = "1";
                }
                else if (DomainName.ToLower().Contains("inschoolhub"))
                {
                    vcode = "3";
                }
                else if (DomainName.ToLower().Contains("twovie"))
                {
                    vcode = "4";
                }
                else if (DomainName.ToLower().Contains("myyouthhub"))
                {
                    vcode = "5";
                }



                string additionalParamter = "";
                if (Parent_ProfileID.Trim() != string.Empty)
                { additionalParamter = "&PPID=" + Parent_ProfileID; }


                string code = RootPath + "/QRCodeResponse.aspx?ProfileID=" + ProfileID.ToString()
                    + "&VerticalCode=" + vcode + additionalParamter + "&Type=" + "QRCode";



                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);

                string qrcode_Img_Path = Server.MapPath("/Upload/QRCode_Fav");
                if (!Directory.Exists(qrcode_Img_Path))
                    Directory.CreateDirectory(qrcode_Img_Path);

                qrcode_Img_Path = qrcode_Img_Path + "/" + ProfileID + "_QRCode.png";
                try
                {
                    if (File.Exists(qrcode_Img_Path))
                    { File.Delete(qrcode_Img_Path); }
                }
                catch (Exception ex)
                { }

                if (!File.Exists(qrcode_Img_Path))
                {
                    using (System.Drawing.Bitmap bitMap = qrCode.GetGraphic(3))
                    {
                        bitMap.Save(qrcode_Img_Path, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }

                #endregion

                DataTable dt = new DataTable();
                dt = objBus.GetBusinessProfileByProfileID(ProfileID);

                using (FileStream fs = File.OpenRead(Server.MapPath("~/BulletinPreview/USPDhubFlyer.htm")))
                {
                    byte[] byt = new byte[(int)fs.Length];
                    char[] chr = new char[byt.Length];
                    fs.Read(byt, 0, (int)fs.Length);
                    byt.CopyTo(chr, 0);
                    fstext = new string(chr);
                    fs.Close();
                    fstext = fstext.Replace("ï»¿", "");

                    string Logo = "";
                    string imagepath = string.Empty;
                    if (dt.Rows.Count > 0)
                    {
                        fstext = fstext.Replace("##Profile_Name##", dt.Rows[0]["Profile_name"].ToString());
                        string sourceLogo = Server.MapPath("/Images/VerticalLogos/" + DomainName + "logo.png");
                        if (File.Exists(sourceLogo))
                        {
                            Logo = "<img style=\"vertical-align: middle; border: 0;\" src=\"" + RootPath + "\\Images\\VerticalLogos\\" + DomainName + "logo.png" + "\" alt=\"Logo\" />";

                        }

                        if (DomainName.ToLower().Contains("uspdhub"))
                            fstext = fstext.Replace("#organizationtype#", "agency");
                        else if (DomainName.ToLower().Contains("inschoolhub"))
                            fstext = fstext.Replace("#organizationtype#", "school");
                        else
                            fstext = fstext.Replace("#organizationtype#", "organization");

                        fstext = fstext.Replace("##Logo##", Logo);
                        fstext = fstext.Replace("#AppDisplayName#", App_DisplayName);
                        fstext = fstext.Replace("##IOS_Url##", ConfigurationManager.AppSettings["USPDhubLiteAppurl"]);
                        fstext = fstext.Replace("##Android_Url##", ConfigurationManager.AppSettings["USPDhubLiteAppurl"]);
                        fstext = fstext.Replace("##Windows_Url##", ConfigurationManager.AppSettings["USPDhubLiteAppurl"]);

                        string QRCodeFOlderPath = Server.MapPath("~/Upload/QRCode_Fav/");
                        if (File.Exists(QRCodeFOlderPath + ProfileID + "_QRCode.png"))
                        {
                            QRCodeFOlderPath = RootPath + "/Upload/QRCode_Fav/" + ProfileID + "_QRCode.png";
                        }

                        fstext = fstext.Replace("##QRCode##", QRCodeFOlderPath);
                        fstext = fstext.Replace("##Android##", RootPath + "/Images/android.jpg");
                        fstext = fstext.Replace("##Apple##", RootPath + "/Images/apple.jpg");
                        fstext = fstext.Replace("##Windows##", RootPath + "/Images/windows.jpg");

                    }
                }


                string filename = objCommon.ReplaceSpecialCharacter(Convert.ToString(dt.Rows[0]["Profile_name"])) + " - Flyer Download";
                string savelocation = HttpContext.Current.Server.MapPath("~/Upload/").ToString() + filename + ".pdf";
                objCommon.HtmlToPDF_Print(fstext.ToString(), filename, savelocation, true);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DownloadInstallers.aspx.cs", "btnISAFlyer_OnClick", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void imgBtnGetStarted_OnClick(object sender, EventArgs e)
        {
            try
            {
                string strVertoclDomain = Session["VerticalDomain"].ToString();
                strVertoclDomain = strVertoclDomain + "_GettingStarted.pdf";
                string VirtualPath = Server.MapPath("~/Upload/GettingStarted/" + strVertoclDomain);
                if (File.Exists(VirtualPath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + strVertoclDomain);
                    Response.TransmitFile(VirtualPath);
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DownloadInstallers.aspx.cs", "imgBtnGetStarted_OnClick", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        internal string DrawRotatedAppNameText_QRCode(string inputText)
        {
            string ImgName = string.Empty;
            string uspdVirtualFolder = ConfigurationManager.AppSettings.Get("USPDFolderPath");

            using (var bitmap = new Aurigma.GraphicsMill.Bitmap(165, 181, Aurigma.GraphicsMill.PixelFormat.Format32bppArgb, Aurigma.GraphicsMill.RgbColor.Transparent))
            using (var graphics = bitmap.GetAdvancedGraphics())
            {
                using (var m = new System.Drawing.Drawing2D.Matrix())
                {
                    //m.Rotate(-45);
                    /*
                    var plainText = new Aurigma.GraphicsMill.AdvancedDrawing.PlainText(inputText, graphics.CreateFont("Arial", "Bold", 20),
                        new Aurigma.GraphicsMill.AdvancedDrawing.SolidBrush(System.Drawing.Color.Black),
                        new System.Drawing.PointF(100, 125));
                    plainText.Transform = m;
                    plainText.Alignment = TextAlignment.Center;
                    graphics.DrawText(plainText);
                    */

                    Aurigma.GraphicsMill.AdvancedDrawing.Brush objBrush = new SolidBrush(System.Drawing.Color.Black);
                    System.Drawing.PointF objPointF = new System.Drawing.PointF(100, 125);

                    var boundedText = new BoundedText(inputText, graphics.CreateFont("Arial", "Bold", 20), new System.Drawing.RectangleF(20, 10, 140, 70));
                    boundedText.Alignment = TextAlignment.Center;
                    boundedText.Transform = m;
                    graphics.DrawText(boundedText);


                    string AppNamesFolder = uspdVirtualFolder + "/Upload/QRCodes_AppNames/" + Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                    if (Directory.Exists(AppNamesFolder))
                    {
                        Directory.Delete(AppNamesFolder, true);
                        Directory.CreateDirectory(AppNamesFolder);
                    }
                    else
                        Directory.CreateDirectory(AppNamesFolder);

                    ImgName = AppNamesFolder + "\\" + Session["ProfileID"].ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";
                    bitmap.Save(ImgName);
                }
            }

            return ImgName;
        }
    }
}