using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.IO;
using System.Configuration;
using USPDHUBDAL;
using ThoughtWorks.QRCode.Codec;
using System.Drawing;
using System.Drawing.Imaging;
using ThoughtWorks.QRCode.Codec.Data;
using System.Text;
using ZXing;

namespace USPDHUB.Admin
{
    public partial class EditAppOrderStatus : System.Web.UI.Page
    {
        int UserID = 0;
        USPDHUBBLL.AdminBLL objAdminBLL = new USPDHUBBLL.AdminBLL();
        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

        DataTable dtOrderStatusDetails = new DataTable();

        USPDHUBBLL.BusinessBLL objBusinessBLL = new BusinessBLL();
        public CommonBLL objCommonBLL = new CommonBLL();
        public DataTable dtConfigs = new DataTable("configsettings");

        public string QRCode_StoreUrl = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Tab Type ::1 == Customer Service 
            // Tab Type ::2 == Engineering
            // Tab Type ::3 == Completed

            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "EditAppOrderStatus.aspx.cs", "Page_Load()", string.Empty, string.Empty, string.Empty, string.Empty);

                if (Session["adminuserid"] != null)
                {
                    UserID = Convert.ToInt32(Session["adminuserid"]);
                }
                else
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }


                lblMsg.Text = "";
                if (!IsPostBack)
                {
                    pnlFirst.Visible = false;
                    pnlSecond.Visible = false;
                    //Branded App OrderStatusID
                    if (Request.QueryString["OSID"] != null)
                    {
                        hdnTabType.Value = Request.QueryString["TabType"].ToString();
                        dtOrderStatusDetails = objBusinessBLL.GetBrandedAppOrderStatusDetails(Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["OSID"].ToString())));

                        if (Convert.ToInt32(dtOrderStatusDetails.Rows[0]["StatusID"]) > Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.InDesigning))
                        {
                            pnlSecond.Visible = true;
                        }
                        else
                            pnlFirst.Visible = true;

                        //Data Fill in Textboxes
                        txtSplashContent.Text = Convert.ToString(dtOrderStatusDetails.Rows[0]["SplashContent"]).Replace("<br/>", "\r\n");
                        lblSplashContent.Text = Convert.ToString(dtOrderStatusDetails.Rows[0]["SplashContent"]);
                        txtShortDesc.Text = lblShortDescription.Text = Convert.ToString(dtOrderStatusDetails.Rows[0]["App_ShortDescription"]).Replace("<br/>", "\r\n");
                        txtDescription.Text = Convert.ToString(dtOrderStatusDetails.Rows[0]["App_Description"]).Replace("<br/>", "\r\n");
                        lblAppDescription.Text = Convert.ToString(dtOrderStatusDetails.Rows[0]["App_Description"]);
                        txtKeywords.Text = lblAppKeywords.Text = Convert.ToString(dtOrderStatusDetails.Rows[0]["App_Keywords"]);
                        txtIOS_URL.Text = Convert.ToString(dtOrderStatusDetails.Rows[0]["IOS_Url"]);
                        txtAndroid_URL.Text = Convert.ToString(dtOrderStatusDetails.Rows[0]["Android_Url"]);
                        txtWindows_URL.Text = Convert.ToString(dtOrderStatusDetails.Rows[0]["Windows_Url"]);
                        txtWebSite_URL.Text = Convert.ToString(dtOrderStatusDetails.Rows[0]["Website_Url"]);
                        hdnAppOrderStatus.Value = Convert.ToString(dtOrderStatusDetails.Rows[0]["StatusID"]);

                        if (string.IsNullOrEmpty(dtOrderStatusDetails.Rows[0]["App_DisplayName"].ToString()))
                        {
                            txtAppName.Text = Convert.ToString(dtOrderStatusDetails.Rows[0]["Profile_name"]);
                        }
                        else
                        {
                            txtAppName.Text = lblAppName.Text = dtOrderStatusDetails.Rows[0]["App_DisplayName"].ToString();
                        }

                        ViewState["UserID"] = dtOrderStatusDetails.Rows[0]["UserID"];
                        ViewState["ProfileID"] = dtOrderStatusDetails.Rows[0]["ProfileID"];
                        ViewState["Logo"] = dtOrderStatusDetails.Rows[0]["Logo"];
                        ViewState["AppIcon"] = dtOrderStatusDetails.Rows[0]["App_Icon"];

                        ViewState["AppStoreIcon"] = dtOrderStatusDetails.Rows[0]["App_Store_Icon"];
                        ViewState["PrintableAppStoreIcon"] = dtOrderStatusDetails.Rows[0]["Printable_App_Store_Icon"];
                        ViewState["BackgroundIcon"] = dtOrderStatusDetails.Rows[0]["Background_Icon"];

                        string rootPath = GetConfigSettings(ViewState["ProfileID"].ToString(), "Paths", "RootPath");

                        if (Convert.ToString(ViewState["Logo"]) != string.Empty)
                        {
                            if (File.Exists(ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestLogos\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["Logo"]))
                            {
                                string LogoPath = rootPath + "/Upload/BrandedAppRequestLogos/" + ViewState["ProfileID"].ToString() + "/" + ViewState["Logo"];
                                lblLogo.Text = lblSLogo.Text = "<img src='" + LogoPath + "' width='100px' height='100px' />";
                            }
                        }
                        if (lblLogo.Text.Trim() == string.Empty)
                        {
                            btnDeleteLogo.Visible = false;
                            btnDownloadLogo.Visible = false;
                        }
                        if (Convert.ToString(ViewState["AppIcon"]) != string.Empty)
                        {
                            if (File.Exists(ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestIcons\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["AppIcon"]))
                            {
                                string AppIconPath = rootPath + "/Upload/BrandedAppRequestIcons/" + ViewState["ProfileID"].ToString() + "/" + ViewState["AppIcon"];
                                lblAppIcon.Text = lblSApp.Text = "<img src='" + AppIconPath + "' width='100px' height='100px' />";
                            }
                        }
                        if (lblAppIcon.Text.Trim() == string.Empty)
                        {
                            btnDeleteAppIcon.Visible = false;
                            btnDownloadAppIcon.Visible = false;
                        }

                        if (Convert.ToString(ViewState["AppStoreIcon"]) != string.Empty)
                        {
                            if (File.Exists(ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestAppStoreIcons\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["AppStoreIcon"]))
                            {
                                string AppIconPath = rootPath + "/Upload/BrandedAppRequestAppStoreIcons/" + ViewState["ProfileID"].ToString() + "/" + ViewState["AppStoreIcon"];
                                lblAppStoreIcon.Text = "<img src='" + AppIconPath + "' width='100px' height='100px' />";
                            }
                        }
                        if (lblAppStoreIcon.Text.Trim() == string.Empty)
                        {
                            btnDeleteAppStoreIcon.Visible = false;
                            btDownloadAppStoreIcon.Visible = false;
                        }

                        if (Convert.ToString(ViewState["PrintableAppStoreIcon"]) != string.Empty)
                        {
                            if (File.Exists(ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestPrintableAppStoreIcons\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["PrintableAppStoreIcon"]))
                            {
                                string AppIconPath = rootPath + "/Upload/BrandedAppRequestPrintableAppStoreIcons/" + ViewState["ProfileID"].ToString() + "/" + ViewState["PrintableAppStoreIcon"];
                                lblPrintableAppStoreIcon.Text = "<img src='" + AppIconPath + "' width='100px' height='100px' />";
                            }
                        }
                        if (lblPrintableAppStoreIcon.Text.Trim() == string.Empty)
                        {
                            btnDeletePrintableAppStoreIcon.Visible = false;
                            btnDowloadPrintableAppStoreIcon.Visible = false;
                        }
                        if (Convert.ToString(ViewState["BackgroundIcon"]) != string.Empty)
                        {
                            if (File.Exists(ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestBackgroundIcons\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["BackgroundIcon"]))
                            {
                                string backgroundIconPath = rootPath + "/Upload/BrandedAppRequestBackgroundIcons/" + ViewState["ProfileID"].ToString() + "/" + ViewState["BackgroundIcon"];
                                lblBackground.Text = lblSBackground.Text = "<img src='" + backgroundIconPath + "' width='100px' height='100px' />";
                            }
                        }
                        if (lblBackground.Text.Trim() == string.Empty)
                        {
                            btnDeleteBackground.Visible = false;
                            btnDownloadBackground.Visible = false;
                        }
                        // QR Code Image
                        if (File.Exists(ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\QRCodes\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["ProfileID"] + "_QRCode.jpg"))
                        {
                            string QRCodeImagePatgh = rootPath + "/Upload/QRCodes/" + ViewState["ProfileID"].ToString() + "/" + ViewState["ProfileID"] + "_QRCode.jpg";
                            lblQRCode.Text = "<img src='" + QRCodeImagePatgh + "' width='100px' height='100px' />";
                        }
                        if (lblQRCode.Text.Trim() == string.Empty)
                        {
                            btnDownloadQRCode.Visible = false;
                        }

                        //Fill Status
                        FillStatus(Convert.ToInt32(dtOrderStatusDetails.Rows[0]["StatusID"]));
                        FillNotes();
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "Page_Load()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public string GetConfigSettings(string pProfileID, string pType, string pConfigName)
        {
            string returnValue = "";
            try
            {

                string verticalCode = MServiceDAL.GetVerticalNameByProfileID(Convert.ToInt32(pProfileID));

                DataTable dtProfileDetails = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
                string countryName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);

                string domain = objCommonBLL.GetDomainNameByCountryVertical(verticalCode, countryName.Trim());

                dtConfigs = objCommonBLL.GetVerticalConfigsByType(domain, pType);
                if (dtConfigs.Rows.Count > 0)
                {
                    for (int i = 0; i < dtConfigs.Rows.Count; i++)
                    {
                        if (Convert.ToString(dtConfigs.Rows[i]["Name"]) == pConfigName)
                        {
                            returnValue = Convert.ToString(dtConfigs.Rows[i]["Value"]).Trim();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "GetConfigSettings()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return returnValue;
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlStatus.SelectedValue.Trim() == string.Empty)
                {
                    ddlStatus.SelectedValue = hdnAppOrderStatus.Value;
                }
                //Log
                objInBuiltData.ErrorHandling("LOG", "EditAppOrderStatus.aspx.cs", "lnkSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);


                // Just Warning Message for Logo Size
                if (fileLogo.HasFile == true)
                {
                    //System.Drawing.Image myImage = System.Drawing.Image.FromStream(fileLogo.PostedFile.InputStream);
                    //if ((myImage.Height > 150) || (myImage.Width > 150))
                    //{
                    //    lblMsg.Text = "<font color='red'>Your logo size less than or equal to 150px X 150px.</font>";
                    //    return;
                    //}
                    //else
                    //{
                    #region Logo Uploading

                    var Extension = Path.GetExtension(fileLogo.FileName);
                    if (Extension == ".jpg" || Extension == ".JPG" || Extension == ".JPEG" || Extension == ".jpeg"
                        || Extension == ".GIF" || Extension == ".gif" || Extension == ".png" || Extension == ".PNG")
                    {

                        string LogoPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestLogos\\" + ViewState["ProfileID"].ToString();

                        if (!Directory.Exists(LogoPath))
                        {
                            Directory.CreateDirectory(LogoPath);
                        }

                        //var LogoFileName = ViewState["ProfileID"] + "_" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" +
                        //    DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + "" + Extension;
                        var LogoFileName = fileLogo.FileName;
                        LogoFileName = LogoFileName.Replace(" ", "");

                        // Delete Previous Logo
                        if (File.Exists(LogoPath + "\\" + ViewState["Logo"]))
                        {
                            File.Delete(LogoPath + "\\" + ViewState["Logo"]);
                        }

                        LogoPath = LogoPath + "\\" + LogoFileName;
                        ////myImage = System.Drawing.Image.FromStream(fileLogo.PostedFile.InputStream);
                        ////if ((myImage.Height <= 65) || (myImage.Width <= 65))
                        ////{
                        ////    LogoPath = LogoPath + "\\" + LogoFileName;
                        ////}
                        ////else
                        ////{
                        ////    LogoPath = LogoPath + "\\dummy_" + LogoFileName;
                        ////}
                        fileLogo.SaveAs(LogoPath);
                        //
                        ////if ((myImage.Height > 65) || (myImage.Width > 65))
                        ////{
                        ////    // Mobile App Logo Size 65*65
                        ////    LogoResize(65, 65, LogoFileName);
                        ////}

                        ViewState["Logo"] = LogoFileName;
                    }
                    else
                    {
                        lblMsg.Text = "<font color='red'>Your logo is not in the correct file format; please use .jpeg,.jpg,.gif or .png only.</font>";
                        return;
                    }


                    #endregion
                    //}
                }


                if (FileAppIcon.HasFile == true)
                {
                    System.Drawing.Image myImage = System.Drawing.Image.FromStream(FileAppIcon.PostedFile.InputStream);
                    if ((myImage.Height > 1024) || (myImage.Width > 1024))
                    {
                        lblMsg.Text = "<font color='red'>Your app icon size less than or equal to 1024px X 1024px.</font>";
                        return;
                    }
                    else
                    {
                        #region App Icon Uploading

                        if (FileAppIcon.HasFile == true)
                        {
                            var Extension = Path.GetExtension(FileAppIcon.FileName);
                            if (Extension == ".jpg" || Extension == ".JPG" || Extension == ".JPEG" || Extension == ".jpeg"
                                || Extension == ".GIF" || Extension == ".gif" || Extension == ".png" || Extension == ".PNG")
                            {
                                string IconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestIcons\\" + ViewState["ProfileID"].ToString();

                                if (!Directory.Exists(IconPath))
                                {
                                    Directory.CreateDirectory(IconPath);
                                }

                                //var IconFileName = ViewState["ProfileID"] + "_" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" +
                                //    DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + "" + Extension;

                                var IconFileName = FileAppIcon.FileName;
                                IconFileName = IconFileName.Replace(" ", "");

                                // Delete Previous Logo
                                if (File.Exists(IconPath + "\\" + ViewState["AppIcon"]))
                                {
                                    File.Delete(IconPath + "\\" + ViewState["AppIcon"]);
                                }
                                IconPath = IconPath + "\\" + IconFileName;
                                FileAppIcon.SaveAs(IconPath);

                                ViewState["AppIcon"] = IconFileName;
                            }
                            else
                            {
                                lblMsg.Text = "<font color='red'>Your app icon is not in the correct file format; please use .jpeg,.jpg,.gif or .png only.</font>";
                                return;
                            }
                        }

                        #endregion
                    }
                }


                #region App Store Icon Uploading

                if (fileupload_AppstoreIcon.HasFile == true)
                {
                    var Extension = Path.GetExtension(fileupload_AppstoreIcon.FileName);
                    if (Extension == ".jpg" || Extension == ".JPG" || Extension == ".JPEG" || Extension == ".jpeg"
                        || Extension == ".GIF" || Extension == ".gif" || Extension == ".png" || Extension == ".PNG")
                    {
                        string IconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestAppStoreIcons\\" + ViewState["ProfileID"].ToString();

                        if (!Directory.Exists(IconPath))
                        {
                            Directory.CreateDirectory(IconPath);
                        }

                        var IconFileName = fileupload_AppstoreIcon.FileName;
                        IconFileName = IconFileName.Replace(" ", "");

                        // Delete Previous Logo
                        if (File.Exists(IconPath + "\\" + ViewState["AppStoreIcon"]))
                        {
                            File.Delete(IconPath + "\\" + ViewState["AppStoreIcon"]);
                        }
                        IconPath = IconPath + "\\" + IconFileName;
                        fileupload_AppstoreIcon.SaveAs(IconPath);

                        ViewState["AppStoreIcon"] = IconFileName;
                    }
                    else
                    {
                        lblMsg.Text = "<font color='red'>Your app store icon is not in the correct file format; please use .jpeg,.jpg,.gif or .png only.</font>";
                        return;
                    }
                }

                #endregion

                #region Printable App Store Icon Uploading

                if (fileuploadPrintableAppStoreIcon.HasFile == true)
                {
                    var Extension = Path.GetExtension(fileuploadPrintableAppStoreIcon.FileName);
                    if (Extension == ".jpg" || Extension == ".JPG" || Extension == ".JPEG" || Extension == ".jpeg"
                        || Extension == ".GIF" || Extension == ".gif" || Extension == ".png" || Extension == ".PNG")
                    {
                        string IconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestPrintableAppStoreIcons\\" + ViewState["ProfileID"].ToString();

                        if (!Directory.Exists(IconPath))
                        {
                            Directory.CreateDirectory(IconPath);
                        }

                        var IconFileName = fileuploadPrintableAppStoreIcon.FileName;
                        IconFileName = IconFileName.Replace(" ", "");

                        // Delete Previous Logo
                        if (File.Exists(IconPath + "\\" + ViewState["PrintableAppStoreIcon"]))
                        {
                            File.Delete(IconPath + "\\" + ViewState["PrintableAppStoreIcon"]);
                        }
                        IconPath = IconPath + "\\" + IconFileName;
                        fileuploadPrintableAppStoreIcon.SaveAs(IconPath);

                        ViewState["PrintableAppStoreIcon"] = IconFileName;
                    }
                    else
                    {
                        lblMsg.Text = "<font color='red'>Your printable app store icon is not in the correct file format; please use .jpeg,.jpg,.gif or .png only.</font>";
                        return;
                    }
                }

                #endregion
                #region Background image
                if (FileBackground.HasFile == true)
                {
                    var Extension = Path.GetExtension(FileBackground.FileName);
                    if (Extension == ".jpg" || Extension == ".JPG" || Extension == ".JPEG" || Extension == ".jpeg"
                        || Extension == ".GIF" || Extension == ".gif" || Extension == ".png" || Extension == ".PNG")
                    {
                        string backgroundPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestBackgroundIcons\\" + ViewState["ProfileID"].ToString();

                        if (!Directory.Exists(backgroundPath))
                        {
                            Directory.CreateDirectory(backgroundPath);
                        }

                        var backgroundFileName = FileBackground.FileName;
                        backgroundFileName = backgroundFileName.Replace(" ", "");

                        // Delete Previous Logo
                        if (File.Exists(backgroundPath + "\\" + ViewState["BackgroundIcon"]))
                        {
                            File.Delete(backgroundPath + "\\" + ViewState["BackgroundIcon"]);
                        }
                        backgroundPath = backgroundPath + "\\" + backgroundFileName;
                        FileBackground.SaveAs(backgroundPath);

                        ViewState["BackgroundIcon"] = backgroundFileName;
                    }
                    else
                    {
                        lblMsg.Text = "<font color='red'>Your background image is not in the correct file format; please use .jpeg,.jpg,.gif or .png only.</font>";
                        return;
                    }
                }

                #endregion
                if (Convert.ToInt32(ddlStatus.SelectedValue) == Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.SubmitStore))
                {
                    if (lblAppStoreIcon.Text.Trim() == string.Empty && fileupload_AppstoreIcon.HasFile == false)
                    {
                        lblMsg.Text = "<font color='red'>App store icon is mandatory.</font>";
                        return;
                    }
                    else if (lblPrintableAppStoreIcon.Text.Trim() == string.Empty && fileuploadPrintableAppStoreIcon.HasFile == false)
                    {
                        lblMsg.Text = "<font color='red'>Printable app store icon is mandatory.</font>";
                        return;
                    }
                }

                #region QR Uploading

                if (fileupload_QRCode.HasFile == true)
                {
                    var Extension = Path.GetExtension(fileupload_QRCode.FileName);
                    if (Extension == ".jpg" || Extension == ".JPG" || Extension == ".JPEG" || Extension == ".jpeg"
                        || Extension == ".GIF" || Extension == ".gif" || Extension == ".png" || Extension == ".PNG")
                    {
                        string IconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\QRCodes\\" + ViewState["ProfileID"].ToString();

                        if (!Directory.Exists(IconPath))
                        {
                            Directory.CreateDirectory(IconPath);
                        }

                        //var IconFileName = ViewState["ProfileID"] + "_" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" +
                        //    DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + "" + Extension;

                        var IconFileName = fileupload_QRCode.FileName;
                        IconFileName = IconFileName.Replace(" ", "");
                        IconFileName = ViewState["ProfileID"].ToString() + "_QRCode.jpg";

                        // Delete Previous Logo
                        if (File.Exists(IconPath + "\\" + IconFileName))
                        {
                            File.Delete(IconPath + "\\" + IconFileName);
                        }
                        IconPath = IconPath + "\\" + IconFileName;
                        fileupload_QRCode.SaveAs(IconPath);

                        #region QR Decode to Store Url

                        try
                        {
                            var reader = new BarcodeReader();
                            var result = reader.Decode(new Bitmap(IconPath));
                            QRCode_StoreUrl = result.Text;
                        }
                        catch (Exception ex)
                        { }

                        #endregion

                        //// QR Code Image Copy to Image Gallery
                        string imageGalleryPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\Common\\" + ViewState["ProfileID"].ToString();
                        // Delete Previous Logo from Image Gallery
                        if (File.Exists(imageGalleryPath + "\\" + IconFileName))
                        {
                            File.Delete(imageGalleryPath + "\\" + IconFileName);
                        }

                        if (!Directory.Exists(imageGalleryPath))
                        {
                            Directory.CreateDirectory(imageGalleryPath);
                        }
                        imageGalleryPath = imageGalleryPath + "\\" + IconFileName;


                        string copyQRCodePath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\QRCodes\\" + ViewState["ProfileID"].ToString() + "\\" + IconFileName;
                        if (File.Exists(copyQRCodePath))
                        {
                            File.Copy(copyQRCodePath, imageGalleryPath, true);
                        }
                        //

                    }
                    else
                    {
                        lblMsg.Text = "<font color='red'>Your QR code image is not in the correct file format; please use .jpeg,.jpg,.gif or .png only.</font>";
                        return;
                    }
                }

                #endregion

                #region these images are move Common Image Gallery

                if (Convert.ToInt32(ddlStatus.SelectedValue) == Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.Completed))
                {
                    if (fileupload_QRCode.HasFile == false)
                    {
                        lblMsg.Text = "<font color='red'>QR Code is mandatory.</font>";
                        return;
                    }


                    //// Logo Uploadig
                    string imageGalleryPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\Common\\" + ViewState["ProfileID"].ToString();
                    // Delete Previous Logo from Image Gallery
                    if (File.Exists(imageGalleryPath + "\\" + ViewState["Logo"]))
                    {
                        File.Delete(imageGalleryPath + "\\" + ViewState["Logo"]);
                    }

                    if (!Directory.Exists(imageGalleryPath))
                    {
                        Directory.CreateDirectory(imageGalleryPath);
                    }
                    imageGalleryPath = imageGalleryPath + "\\" + ViewState["Logo"];


                    string copyLogoPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestLogos\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["Logo"];
                    if (File.Exists(copyLogoPath))
                    {
                        File.Copy(copyLogoPath, imageGalleryPath, true);
                    }


                    //// App Icon Uploading
                    imageGalleryPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\Common\\" + ViewState["ProfileID"].ToString();
                    // Delete Previous Logo from Image Gallery
                    if (File.Exists(imageGalleryPath + "\\" + ViewState["AppIcon"]))
                    {
                        File.Delete(imageGalleryPath + "\\" + ViewState["AppIcon"]);
                    }
                    imageGalleryPath = imageGalleryPath + "\\" + ViewState["AppIcon"];

                    string copyAppIconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestIcons\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["AppIcon"];
                    if (File.Exists(copyAppIconPath))
                    {
                        File.Copy(copyAppIconPath, imageGalleryPath, true);
                    }


                    # region QR Code Generation
                    /* 
                    for (int i = 1; i <= 3; i++)
                    {
                        string GenerateQRCodeText = "";
                        string QRCodeimgFileName = "";

                        //// QR Code Generating 
                        QRCodeEncoder encoder = new QRCodeEncoder();
                        if (i == 1)
                        {
                            GenerateQRCodeText = txtIOS_URL.Text.Trim();
                            QRCodeimgFileName = "IOS";
                        }
                        else if (i == 2)
                        {
                            GenerateQRCodeText = txtAndroid_URL.Text.Trim();
                            QRCodeimgFileName = "Android";
                        }
                        else if (i == 3)
                        {
                            GenerateQRCodeText = txtWindows_URL.Text.Trim();
                            QRCodeimgFileName = "Windows";
                        }

                        Bitmap img = encoder.Encode(GenerateQRCodeText);
                        QRCodeimgFileName = ViewState["ProfileID"] + "_" + QRCodeimgFileName + ".jpg";
                        string QRCodeImgPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\QRCodes\\" + ViewState["ProfileID"].ToString();
                        if (!Directory.Exists(QRCodeImgPath))
                        {
                            Directory.CreateDirectory(QRCodeImgPath);
                        }
                        QRCodeImgPath = QRCodeImgPath + "\\" + QRCodeimgFileName;
                        img.Save(QRCodeImgPath, ImageFormat.Jpeg);


                        // New QR Code Image Copy to User Image Gallery. 
                        imageGalleryPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\Common\\" + ViewState["ProfileID"].ToString();

                        if (File.Exists(imageGalleryPath + "\\" + QRCodeimgFileName))
                        {
                            File.Delete(imageGalleryPath + "\\" + QRCodeimgFileName);
                        }
                        imageGalleryPath = imageGalleryPath + "\\" + QRCodeimgFileName;
                        File.Copy(QRCodeImgPath, imageGalleryPath, true);
                    }
                  
                    //// QR Code Scaning
                    ////QRCodeDecoder decoder = new QRCodeDecoder();
                    ////String decodedString = decoder.decode(new QRCodeBitmapImage(new Bitmap(Server.MapPath("~/Upload/") + Session["imgName"])));
                    ////lblDecodeText.Text = decodedString;
                   
                     */
                    #endregion

                }


                #endregion

                // Update Branded App Order Status 
                string splashCotent = txtSplashContent.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>");
                objBusinessBLL.Insert_Update_AppProcessStatus(Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["OSID"].ToString())),
                    Convert.ToInt32(ViewState["UserID"]), Convert.ToInt32(ViewState["ProfileID"]),
                    Convert.ToString(ViewState["Logo"]), Convert.ToString(ViewState["AppIcon"]), txtDescription.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"),
                    splashCotent, txtShortDesc.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>"), txtAppName.Text.Trim(),
                    txtKeywords.Text.Trim(), txtIOS_URL.Text.Trim(), txtAndroid_URL.Text.Trim(), txtWindows_URL.Text.Trim(), txtWebSite_URL.Text.Trim(),
                    Convert.ToInt32(ddlStatus.SelectedValue), null, Convert.ToString(ViewState["AppStoreIcon"]),
                    Convert.ToString(ViewState["PrintableAppStoreIcon"]), Convert.ToString(ViewState["BackgroundIcon"]), QRCode_StoreUrl);

                // This Email sent to dev team.
                if (Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.Developement) == Convert.ToInt32(ddlStatus.SelectedValue))
                {
                    int PID = Convert.ToInt32(ViewState["ProfileID"]);
                    string verticalCode = MServiceDAL.GetVerticalNameByProfileID(Convert.ToInt32(PID));
                    DataTable dtProfileDetails = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(PID));
                    string countryName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);
                    string domain = objCommonBLL.GetDomainNameByCountryVertical(verticalCode, countryName.Trim());

                    SendEmailDeveloper((PID), domain);
                }


                Session["Msg"] = "<span style='color:green;'>App order status has been updated successfully.</span>";

                string urlinfo = Page.ResolveClientUrl("~/Admin/ManageBrandedAppProcessStatus.aspx?TabType=" + Request.QueryString["TabType"]);
                Response.Redirect(urlinfo);
                //

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "lnkSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void SendEmailDeveloper(int ProfileID, string DomainName)
        {
            try
            {
                DataTable dtProfileDetails = objBusinessBLL.GetProfileDetailsByProfileID(ProfileID);
                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
                string RootPath = ConfigurationManager.AppSettings["RootPath"];

                #region Mail Body
                StreamReader re = File.OpenText(strfilepath + "BrandedAppOrderStatus.txt");
                string emailmessage = string.Empty;
                string content = string.Empty;

                while ((content = re.ReadLine()) != null)
                {
                    emailmessage = emailmessage + content + "<BR>";
                }

                re.Close();
                re.Dispose();

                emailmessage = emailmessage.Replace("##ProfileName##", dtProfileDetails.Rows[0]["Profile_name"].ToString());
                emailmessage = emailmessage.Replace("##UserID##", dtProfileDetails.Rows[0]["User_ID"].ToString());


                #endregion

                #region Mail Header

                StreamReader re1 = File.OpenText(strfilepath + "CommonNotes.txt");
                string emailmessage1 = string.Empty;
                string content1 = string.Empty;

                while ((content1 = re1.ReadLine()) != null)
                {
                    emailmessage1 = emailmessage1 + content1;
                }
                emailmessage1 = emailmessage1.Replace("#msgBody#", emailmessage);



                #endregion

                DataTable dtConfigs = objCommonBLL.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                string FromEmailsupport = "";
                re1 = File.OpenText(strfilepath + "BrandedAppDeveloperIDs.txt");
                string ToEMailID = string.Empty;
                while ((content1 = re1.ReadLine()) != null)
                {
                    ToEMailID = ToEMailID + content1;
                }
                re1.Close();
                re1.Dispose();
                string Subject = "Branded App Order Status";

                for (int i = 0; i < dtConfigs.Rows.Count; i++)
                {
                    if (Convert.ToString(dtConfigs.Rows[i]["Name"]) == "EmailInfo")
                    {
                        FromEmailsupport = Convert.ToString(dtConfigs.Rows[i]["Value"]);
                        break;
                    }
                }


                objCommonBLL.SendWowzzyEmail(FromEmailsupport, ToEMailID, Subject, emailmessage1, string.Empty, "", DomainName, ProfileID.ToString(), "");
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "SendEmailDeveloper()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        private void SendNotesToDeveloper(int ProfileID, string DomainName)
        {
            try
            {
                DataTable dtProfileDetails = objBusinessBLL.GetProfileDetailsByProfileID(ProfileID);
                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";

                #region Mail Body
                StreamReader re = File.OpenText(strfilepath + "NotesDescription.txt");
                string emailmessage = string.Empty;
                string content = string.Empty;

                while ((content = re.ReadLine()) != null)
                {
                    emailmessage = emailmessage + content + "<BR>";
                }

                re.Close();
                re.Dispose();

                emailmessage = emailmessage.Replace("##ProfileName##", dtProfileDetails.Rows[0]["Profile_name"].ToString());
                emailmessage = emailmessage.Replace("##UserID##", dtProfileDetails.Rows[0]["User_ID"].ToString());
                emailmessage = emailmessage.Replace("##NotesDescription##", TxtBxNotes.Text);
                emailmessage = emailmessage.Replace("##NotesBy##", txtNotesBy.Text);
                #endregion

                #region Mail Header

                StreamReader re1 = File.OpenText(strfilepath + "CommonNotes.txt");
                string emailmessage1 = string.Empty;
                string content1 = string.Empty;

                while ((content1 = re1.ReadLine()) != null)
                {
                    emailmessage1 = emailmessage1 + content1;
                }
                emailmessage1 = emailmessage1.Replace("#msgBody#", emailmessage);



                #endregion
                re1 = File.OpenText(strfilepath + "NotesTo.txt");
                DataTable dtConfigs = objCommonBLL.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                string FromEmailsupport = "";
                string ToEMailID = string.Empty;
                while ((content1 = re1.ReadLine()) != null)
                {
                    ToEMailID = ToEMailID + content1;
                }
                re1.Close();
                re1.Dispose();
                string Subject = "Branded App Notes";

                for (int i = 0; i < dtConfigs.Rows.Count; i++)
                {
                    if (Convert.ToString(dtConfigs.Rows[i]["Name"]) == "EmailInfo")
                    {
                        FromEmailsupport = Convert.ToString(dtConfigs.Rows[i]["Value"]);
                        break;
                    }
                }


                objCommonBLL.SendWowzzyEmail(FromEmailsupport, ToEMailID, Subject, emailmessage1, string.Empty, "", DomainName, ProfileID.ToString(), "");
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "SendNotesToDeveloper()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void FillStatus(int StatusID)
        {
            try
            {
                if (hdnTabType.Value == "1" && (Convert.ToInt32(hdnAppOrderStatus.Value) == Convert.ToInt32(BusinessDAL.BranedAppProcessStatus.DeviceTesting)))
                {
                    lblEditStatus.Visible = true;
                    ddlStatus.Visible = false;
                    lblEditStatus.Text = "<strong> Device Testing </strong>";
                }
                else if (hdnTabType.Value == "1" && (Convert.ToInt32(hdnAppOrderStatus.Value) == Convert.ToInt32(BusinessDAL.BranedAppProcessStatus.Developement)))
                {
                    lblEditStatus.Visible = true;
                    ddlStatus.Visible = false;
                    lblEditStatus.Text = "<strong> Development </strong>";
                }
                else
                {
                    lblEditStatus.Visible = false;
                    ddlStatus.Visible = true;
                }

                #region Status Fill

                DataTable dtStatus = objBusinessBLL.GetAppOrderStatusByStatusID(StatusID, Convert.ToInt32(hdnTabType.Value));
                ddlStatus.DataSource = dtStatus;
                ddlStatus.DataTextField = "Status_Name";
                ddlStatus.DataValueField = "Status_ID";
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = StatusID.ToString();

                #endregion

                if (Convert.ToInt32(hdnAppOrderStatus.Value) == Convert.ToInt32(BusinessDAL.BranedAppProcessStatus.Completed))
                {
                    btnDeleteAppIcon.Visible = false;
                    fileLogo.Visible = false;

                    btnDeleteAppStoreIcon.Visible = false;
                    FileAppIcon.Visible = false;

                    btnDeleteLogo.Visible = false;
                    fileupload_AppstoreIcon.Visible = false;

                    fileuploadPrintableAppStoreIcon.Visible = false;
                    btnDeletePrintableAppStoreIcon.Visible = false;

                    pnlFirst.Visible = true;
                    lnkSave.Visible = false;
                    btnDeleteAppStoreIcon.Visible = false;
                    btnDeletePrintableAppStoreIcon.Visible = false;

                    fileupload_AppstoreIcon.Visible = false;
                    fileuploadPrintableAppStoreIcon.Visible = false;
                    ddlStatus.Visible = false;

                    txtIOS_URL.ReadOnly = true;
                    txtAndroid_URL.ReadOnly = true;
                    txtWindows_URL.ReadOnly = true;
                    txtWebSite_URL.ReadOnly = true;

                    /*
                    string rootPath = GetConfigSettings(ViewState["ProfileID"].ToString(), "Paths", "RootPath");
                    string QRCodeIOSimgFileName = rootPath + "/Upload/QRCodes/" + ViewState["ProfileID"].ToString() + "/" + ViewState["ProfileID"] + "_IOS.jpg";
                    string QRCodeAndriodimgFileName = rootPath + "/Upload/QRCodes/" + ViewState["ProfileID"].ToString() + "/" + ViewState["ProfileID"] + "_Android.jpg";
                    string QRCodeWindowsimgFileName = rootPath + "/Upload/QRCodes/" + ViewState["ProfileID"].ToString() + "/" + ViewState["ProfileID"] + "_Windows.jpg";

                    lblIOS.Text = "<img src='" + QRCodeIOSimgFileName + "' width='100px' height='100px' />";
                    lblAndriod.Text = "<img src='" + QRCodeAndriodimgFileName + "' width='100px' height='100px' />";
                    lblWindows.Text = "<img src='" + QRCodeWindowsimgFileName + "' width='100px' height='100px' />";
                    */

                    lblEditStatus.Visible = true;
                    lblEditStatus.Text = "<strong> Completed </strong>";

                    fileupload_QRCode.Visible = false;
                }
                if (hdnTabType.Value == "1" && ((Convert.ToInt32(hdnAppOrderStatus.Value) == Convert.ToInt32(BusinessDAL.BranedAppProcessStatus.New)) ||
                    Convert.ToInt32(hdnAppOrderStatus.Value) == Convert.ToInt32(BusinessDAL.BranedAppProcessStatus.DataCollection) ||
                    Convert.ToInt32(hdnAppOrderStatus.Value) == Convert.ToInt32(BusinessDAL.BranedAppProcessStatus.InDesigning) ||
                    Convert.ToInt32(hdnAppOrderStatus.Value) == Convert.ToInt32(BusinessDAL.BranedAppProcessStatus.Developement)))
                {
                    pnlFirst.Visible = true;
                    lblAppDescription.Visible = false;
                    lblAppKeywords.Visible = false;
                    lblAppName.Visible = false;
                    lblShortDescription.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "FillStatus()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            string urlinfo = Page.ResolveClientUrl("~/Admin/ManageBrandedAppProcessStatus.aspx?TabType=" + Request.QueryString["TabType"]);
            Response.Redirect(urlinfo);
        }

        protected void btnDeleteLogo_OnClick(object sender, EventArgs e)
        {
            try
            {
                lblLogo.Text = "";
                string LogoPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestLogos\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["Logo"];
                if (File.Exists(LogoPath))
                {
                    File.Delete(LogoPath);
                }
                btnDeleteLogo.Visible = false;
                btnDownloadLogo.Visible = false;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "btnDeleteLogo_OnClick()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnDownloadLogo_OnClick(object sender, EventArgs e)
        {
            try
            {
                string LogoPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestLogos\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["Logo"];
                if (File.Exists(LogoPath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + ViewState["Logo"]);
                    Response.TransmitFile(LogoPath);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "btnDownloadLogo_OnClick()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnDeleteAppIcon_OnClick(object sender, EventArgs e)
        {
            try
            {
                lblAppIcon.Text = "";
                string AppIconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestIcons\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["AppIcon"];
                if (File.Exists(AppIconPath))
                {
                    File.Delete(AppIconPath);
                }
                btnDeleteAppIcon.Visible = false;
                btnDownloadAppIcon.Visible = false;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "btnDeleteAppIcon_OnClick()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnDownloadAppIcon_OnClick(object sender, EventArgs e)
        {
            try
            {
                string AppIconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestIcons\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["AppIcon"];
                // Delete Previous Logo
                if (File.Exists(AppIconPath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + ViewState["AppIcon"]);
                    Response.TransmitFile(AppIconPath);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "btnDownloadAppIcon_OnClick()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnDeleteBackground_OnClick(object sender, EventArgs e)
        {
            try
            {
                lblBackground.Text = "";
                string baclgroundIconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestBackgroundIcons\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["BackgroundIcon"];
                if (File.Exists(baclgroundIconPath))
                {
                    File.Delete(baclgroundIconPath);
                }
                btnDeleteBackground.Visible = false;
                btnDownloadBackground.Visible = false;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "btnDeleteBackground_OnClick()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnDownloadBackground_OnClick(object sender, EventArgs e)
        {
            try
            {
                string backgroundIconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestBackgroundIcons\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["BackgroundIcon"];
                if (File.Exists(backgroundIconPath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + ViewState["BackgroundIcon"]);
                    Response.TransmitFile(backgroundIconPath);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "btnDownloadBackground_OnClick()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }




        private void LogoResize(int pWidth, int pHeight, string LogoFileName)
        {
            try
            {
                string LogoPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestLogos\\" + ViewState["ProfileID"].ToString();
                GC.Collect();
                string dummyFIleName = null;

                // Duplicate Logo Save Path
                dummyFIleName = LogoPath + "\\dummy_" + LogoFileName;

                // Original Logo Save Path
                string LogoSavePath = LogoPath + "\\" + LogoFileName;

                if (File.Exists(dummyFIleName))
                {
                    string imageUrl = dummyFIleName;
                    imageUrl = Path.GetFileName(imageUrl);
                    //Read in the width and height 

                    string dummyFileName = "";
                    if (imageUrl.Contains("?"))
                    {
                        var urls = imageUrl.Split('?');
                        dummyFileName = urls[0].ToString();
                    }
                    else
                    {
                        dummyFileName = imageUrl;
                    }

                    imageUrl = LogoPath + "\\" + dummyFileName;

                    Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                    uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(imageUrl);

                    Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                    actResize.Width = pWidth;
                    actResize.Height = pHeight;
                    actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.None;
                    uploadedImage.Actions.Add(actResize);
                    actResize = null;
                    Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();

                    imgDraw.Elements.Add(uploadedImage);

                    imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                    imgDraw.JpegCompressionLevel = 90;

                    uploadedImage = null;
                    //Now, save the output image on disk

                    imgDraw.Save(LogoSavePath);
                    imgDraw.Dispose();

                }

                // Delete Dummy Logo :: Resize before logo
                if (File.Exists(dummyFIleName))
                {
                    File.Delete(dummyFIleName);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "LogoResize()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnNotes_Click(object sender, EventArgs e)
        {
            try
            {
                string notes = TxtBxNotes.Text;
                string notesBy = txtNotesBy.Text;

                int IDforNotes = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["OSID"].ToString()));
                DataTable adminUserDtobj = new DataTable();
                //adminUserDtobj = adminobj.GetAdminDetails(CsrID);
                adminUserDtobj = objAdminBLL.GetAdminDetailsCheck(UserID);
                string adminUserName = adminUserDtobj.Rows[0]["First_Name"].ToString();
                objBusinessBLL.InsertBrandedAppDeskNotes(IDforNotes, notes, notesBy, adminUserName);
                int PID = Convert.ToInt32(ViewState["ProfileID"]);
                string verticalCode = MServiceDAL.GetVerticalNameByProfileID(Convert.ToInt32(PID));
                DataTable dtProfileDetails = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(PID));
                string countryName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);
                string domain = objCommonBLL.GetDomainNameByCountryVertical(verticalCode, countryName.Trim());
                SendNotesToDeveloper((PID), domain);
                FillNotes();
                NotesTable.Visible = true;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "BtnNotes_Click()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                //lblerror.Text = ex.Message.ToString();
            }
        }

        protected void FillNotes()
        {
            try
            {
                DataTable dtobj = new DataTable();
                int IDforNotes = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["OSID"].ToString()));
                dtobj = objBusinessBLL.GetBrandedAppDeskNotes(IDforNotes);
                string emptyTextBx = string.Empty;
                TxtBxNotes.Text = emptyTextBx;
                txtNotesBy.Text = emptyTextBx;
                DataList_CustomerNotes.DataSource = dtobj;
                DataList_CustomerNotes.DataBind();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "FillNotes()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        #region Delete & Download App Store Icon Events

        protected void btnDeleteAppStoreIcon_OnClick(object sender, EventArgs e)
        {
            try
            {
                lblAppStoreIcon.Text = "";
                string AppStoreIconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestAppStoreIcons\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["AppStoreIcon"];
                if (File.Exists(AppStoreIconPath))
                {
                    File.Delete(AppStoreIconPath);
                }
                btnDeleteAppStoreIcon.Visible = false;
                btDownloadAppStoreIcon.Visible = false;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "btnDeleteAppStoreIcon_OnClick()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btDownloadAppStoreIcon_OnClick(object sender, EventArgs e)
        {
            try
            {
                string AppStoreIconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestAppStoreIcons\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["AppStoreIcon"];
                // Delete Previous Logo
                if (File.Exists(AppStoreIconPath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + ViewState["AppStoreIcon"]);
                    Response.TransmitFile(AppStoreIconPath);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "btDownloadAppStoreIcon_OnClick()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        #endregion

        #region Delete & Download Printabel App Store Icon Events

        protected void btnDeletePrintableAppStoreIcon_OnClick(object sender, EventArgs e)
        {
            try
            {
                lblPrintableAppStoreIcon.Text = "";
                string AppStoreIconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestPrintableAppStoreIcons\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["PrintableAppStoreIcon"];
                if (File.Exists(AppStoreIconPath))
                {
                    File.Delete(AppStoreIconPath);
                }
                btnDeletePrintableAppStoreIcon.Visible = false;
                btnDowloadPrintableAppStoreIcon.Visible = false;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "btnDeletePrintableAppStoreIcon_OnClick()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnDowloadPrintableAppStoreIcon_OnClick(object sender, EventArgs e)
        {
            try
            {
                string AppStoreIconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\BrandedAppRequestPrintableAppStoreIcons\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["PrintableAppStoreIcon"];
                // Delete Previous Logo
                if (File.Exists(AppStoreIconPath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + ViewState["PrintableAppStoreIcon"]);
                    Response.TransmitFile(AppStoreIconPath);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "btnDowloadPrintableAppStoreIcon_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        #endregion

        protected void btnDowloadIOS_OnClick(object sender, EventArgs e)
        {
            try
            {
                string IOS_QRCodePath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\QRCodes\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["ProfileID"] + "_IOS.jpg";
                // Delete Previous Logo
                if (File.Exists(IOS_QRCodePath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + ViewState["ProfileID"] + "_IOS.jpg");
                    Response.TransmitFile(IOS_QRCodePath);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "btnDowloadIOS_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnDowloadAndriod_OnClick(object sender, EventArgs e)
        {
            try
            {
                string Andriod_QRCodePath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\QRCodes\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["ProfileID"] + "_Android.jpg";
                // Delete Previous Logo
                if (File.Exists(Andriod_QRCodePath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + ViewState["ProfileID"] + "_Android.jpg");
                    Response.TransmitFile(Andriod_QRCodePath);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "btnDowloadAndriod_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnDowloadWindows_OnClick(object sender, EventArgs e)
        {
            try
            {
                string Windows_QRCodePath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\QRCodes\\" + ViewState["ProfileID"].ToString() + "\\" + ViewState["ProfileID"] + "_Windows.jpg";
                // Delete Previous Logo
                if (File.Exists(Windows_QRCodePath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + ViewState["ProfileID"] + "_Windows.jpg");
                    Response.TransmitFile(Windows_QRCodePath);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "btnDowloadWindows_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnDownloadQRCode_OnClick(object sender, EventArgs e)
        {
            try
            {
                string IconFileName = ViewState["ProfileID"].ToString() + "_QRCode.jpg";
                string IconPath = ConfigurationManager.AppSettings.Get("BrandedAppRequestPath") + "\\QRCodes\\" + ViewState["ProfileID"].ToString() + "\\" + IconFileName;

                if (File.Exists(IconPath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + IconFileName);
                    Response.TransmitFile(IconPath);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditAppOrderStatus.aspx.cs", "btnDownloadQRCode_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}