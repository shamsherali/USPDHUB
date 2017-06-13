using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Aurigma.GraphicsMill.Transforms;
using Aurigma.GraphicsMill.Codecs;
using Aurigma.GraphicsMill;
using System.Threading;
using System.Data;
using USPDHUBBLL;
using System.Text;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace USPDHUB.Business.MyAccount
{

    public class ImageList
    {
        public string ImgPath { get; set; }
        public string ImageSize { get; set; }
    }

    public partial class ManageBGImages : BaseWeb
    {
        public string RootPath = "";
        public string DomainName = "";
        public int UserID = 0;
        public int C_UserID = 0;
        public int ProfileID = 0;
        BusinessBLL objBus = new BusinessBLL();
        public string ProfileBGImagesPath = "ProfileBGImages";
        public string TempBGImagesPath = "TempBGImages";
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        public string VerticalCodeFolderName = "";
        public string xmlSettings = "";
        DataTable dtCustomModules;
        USPDHUBBLL.MobileAppSettings objMobileSettings = new USPDHUBBLL.MobileAppSettings();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = Convert.ToInt32(Session["UserID"]);
            if (Session["ProfileID"] != null)
                ProfileID = Convert.ToInt32(Session["ProfileID"]);

            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
            else
                C_UserID = UserID;
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();

            lblerrormsg.Text = "";
            lblError.Text = "";
            if (!IsPostBack)
            {
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    string Permission_Type = string.Empty;
                    Permission_Type = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, CommonModules.AppBackgroundImage);
                    if (Permission_Type == "")
                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
                }
                hdnUploadTye.Value = "";
                LoadCurrentBGImagesPreview(ProfileBGImagesPath, false);
            }
        }
        private void LoadCurrentBGImagesPreview(string bgPath, bool isUpload)
        {
            hdnToggle.Value = "0";
            DisableAllPanels();
            StringBuilder objImgPreview = new StringBuilder();
            ltrBGImagePreview.Text = "";
            string strfilepath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\BGImagePreview.txt";
            System.IO.StreamReader re = System.IO.File.OpenText(strfilepath);
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                objImgPreview.Append(input);
            }
            re.Close();
            string displayMobResolution = Resources.ValidationValues.DisplayMobileResolution;
            string ImageDirectory = Server.MapPath("~/Upload/" + bgPath + "/" + ProfileID + "/" + ProfileID + "_bg_" + displayMobResolution + ".png");
            string img320Preview = "";
            if (File.Exists(ImageDirectory))
            {
                EnablePanels(isUpload);
                img320Preview = " background-image: url('" + RootPath + "/Upload/" + bgPath + "/" + ProfileID + "/" + ProfileID + "_bg_" + displayMobResolution + ".png?id=" + Guid.NewGuid() + "');";
            }
            objImgPreview.Replace("#BackgroundBGImage#", img320Preview).Replace("##BindAppIcons##", LoadButtonsOnApp(displayMobResolution));
            objImgPreview = LoadBanners(objImgPreview);
            LoadProfileAddress(objImgPreview);
        }
        private string LoadButtonsOnApp(string displayMobResolution)
        {
            StringBuilder objFooter = new StringBuilder();
            VerticalCodeFolderName = USPDHUBDAL.MServiceDAL.GetVerticalNameByProfileID(ProfileID);
            dtCustomModules = objBus.DashboardIcons(UserID);
            if (dtCustomModules.Rows.Count > 0)
            {
                string TimeStampGUID = DateTime.Now.ToString("yyyyMMddHHmmss");
                objFooter.Append("<table class='footerNav' id=\"app_navigation_bar\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr>");
                int tabsCount = 0;
                for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtCustomModules.Rows[i]["IsVisible"]))
                    {
                        if (tabsCount > 0)
                            objFooter.Append("<td class=\"ui-btn-separator\"></td>");
                        objFooter.Append("<td class=\"ui-btn-up\"><a href=\"javascript:void(0);\" data-role=\"button\" class=\"navigation_bar_item clr_navBar_item_bg clr_navBar_item_brdr clr_navBar_item_hdlTxt ui-btn-up\"><div class=\"navigation_bar_item_bubble clr_navBar_item_bubbleBg\">");
                        objFooter.Append(" <img class=\"item_image\" src=\"" + RootPath + "/Upload/ProfileTabIcons2.0/" + VerticalCodeFolderName + "/" + displayMobResolution + "/" + Convert.ToString(dtCustomModules.Rows[i]["AppIcon"]) + "_n_" + displayMobResolution + ".png?id=" + TimeStampGUID + "\" alt=\"\">");
                        objFooter.Append("<div class=\"navigation_bar_item_text item_text\">" + Convert.ToString(dtCustomModules.Rows[i]["TabName"]) + "</div></div></a></td>");
                        tabsCount++;
                    }
                    if (tabsCount == 4)
                        break;
                }
                objFooter.Append("</tr></table>");
            }
            return objFooter.ToString();
        }
        private void LoadProfileAddress(StringBuilder strHTML)
        {
            //<div class="Address">##ProfileAddress##</div>
            string profileAddress = "";
            string logoimg = "<div class=\"logo\" style=\"width:52px;\"><img class=\"cominglogo\" src=\"../../images/MobileDevice/logo.jpg\" width=\"52\" height=\"52\" alt=\"\"></div>";
            DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
            bool IsShortLogo = Convert.ToBoolean(dtProfile.Rows[0]["IsShortLogo"]);

            DataTable dtMobileAppSettings = objMobileSettings.GetMobileAppSetting(UserID);
            if (dtMobileAppSettings.Rows.Count > 0)
            {
                xmlSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                if (IsShortLogo)
                {
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Address").Value))
                    {
                        profileAddress = dtProfile.Rows[0]["Profile_StreetAddress1"].ToString();
                        if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_StreetAddress2"].ToString()))
                            profileAddress += "," + dtProfile.Rows[0]["Profile_StreetAddress2"].ToString();
                    }
                    string city = "";
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("City").Value))
                        city = profileAddress += "<br/>" + dtProfile.Rows[0]["Profile_City"].ToString();
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("State").Value))
                    {
                        if (city == "")
                            profileAddress += "<br/>" + dtProfile.Rows[0]["State_Code"].ToString();
                        else
                            profileAddress += ", " + dtProfile.Rows[0]["State_Code"].ToString();
                    }
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("ZipCode").Value))
                        profileAddress += " " + dtProfile.Rows[0]["Profile_Zipcode"].ToString();
                    if (xmlTools.Element("Tools").Attribute("IsEmergencyNumber") != null)
                    {
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsEmergencyNumber").Value) == true)
                            profileAddress += "<br/>" + Convert.ToString(xmlTools.Element("Tools").Attribute("EmergencyNumber").Value);
                    }
                }
                if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_logo_path"].ToString()) && Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Logo").Value) == true)
                {
                    string imageDisID = Guid.NewGuid().ToString();
                    string fileName = dtProfile.Rows[0]["Profile_logo_path"].ToString();
                    string extension = System.IO.Path.GetExtension(Server.MapPath(fileName));
                    string filePath = Server.MapPath("~/Upload/Logos/" + ProfileID + "/" + fileName.Replace(extension, "") + "_thumb" + extension);
                    if (File.Exists(filePath))
                        fileName = fileName.Replace(extension, "_thumb" + extension);
                    logoimg = "<div class=\"logo\" + style=\"width:" + (IsShortLogo ? "52px;" : "300px;") + "\"><img class=\"" + (IsShortLogo ? "shortlogo" : "longlogo") + "\" src='" + RootPath + "/Upload/Logos/" + ProfileID + "/" + fileName + "?Guid=" + imageDisID + "'/></div>";
                }
            }
            profileAddress = logoimg + (IsShortLogo ? "<div class=\"Address\">" + profileAddress + "</div>" : "");
            string profileName = Convert.ToString(dtProfile.Rows[0]["Profile_name"]);
            if (profileName.Length > 30)
                profileName = profileName.Substring(0, 30) + "...";
            strHTML.Replace("##ProfileName##", profileName).Replace("##LogoAddress##", profileAddress).Replace("##DomainName##", DomainName);
            ltrBGImagePreview.Text = strHTML.ToString();
        }
        public StringBuilder LoadBanners(StringBuilder objImgPreview)
        {
            string displayMobResolution = Resources.ValidationValues.DisplayMobileResolution;
            string BannerAdspath = RootPath + "/Upload/BannerAds/" + ProfileID;
            StringBuilder strBanners = new StringBuilder();
            DataTable dtBanners = objBus.GetUserBannerAds(ProfileID);
            DataRow[] drAdd;
            strBanners.Clear();
            for (int i = 0; i < dtBanners.Rows.Count; i++)
            {
                drAdd = dtBanners.Select("Order_No=" + (i + 1));
                if (drAdd.Length > 0)
                {
                    if (Convert.ToBoolean(drAdd[0]["App_Display"]))
                        strBanners.Append("<div><a href=\"" + (Convert.ToString(drAdd[0]["Hyperlink_Url"]) != "" ? Convert.ToString(drAdd[0]["Hyperlink_Url"]) + "\" target=\"_blank\"" : "javascript:void(0);\"") + "><img class=\"banneraddrotator\" src=\"" + BannerAdspath + "/" + Convert.ToString(drAdd[0]["Ads_Timespan"]) + "_" + displayMobResolution + ".png?id=" + Guid.NewGuid() + "\"" + "/></a></div>");
                }
            }
            objImgPreview = objImgPreview.Replace("##BindBanners##", strBanners.ToString() != "" ? ("<div id=\"slideshow\">" + strBanners.ToString() + "</div>") : "");
            return objImgPreview;
        }
        private void DisableAllPanels()
        {
            pnlSubmit.Style.Add("display", "none");
            pnlDeleteTop.Visible = false;
            pnlCancelTop.Visible = false;
            lnkTryAgain.Visible = false;
        }
        private void EnablePanels(bool isUpload)
        {
            if (isUpload)
            {
                pnlSubmit.Style.Add("display", "block");
                pnlCancelTop.Visible = true;
            }
            else
                pnlDeleteTop.Visible = true;
        }
        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            try
            {
                pnlShowLoader.Style.Add("display", "block");
                string TempBGDire = Server.MapPath("~/Upload/" + TempBGImagesPath + "/" + ProfileID);
                if (FUUserImages.HasFile)
                {
                    string imgFilename = objCommon.RemoveSpecialCharacters(FUUserImages.FileName);
                    string imageExtension = Path.GetExtension(FUUserImages.FileName).ToLower();
                    hdnImageName.Value = imgFilename.Replace(imageExtension, "-ResizeReference" + imageExtension);
                    if (imageExtension == ".jpg" || imageExtension == ".jpeg" || imageExtension == ".gif" || imageExtension == ".png" || imageExtension == ".bmp")
                    {
                        DeleteProfilePath(TempBGImagesPath);
                        if (!Directory.Exists(TempBGDire))
                            Directory.CreateDirectory(TempBGDire);
                        SaveToLocal();
                        UploadBGImage();
                    }
                    else
                        lblerrormsg.Text = "<font color='red'>Your image is not in the correct file format; please use .jpeg, .jpg, .gif, .png or .bmp only.</font>";
                }
                else
                    lblerrormsg.Text = "<font color='red'>" + Resources.LabelMessages.FileNotSelected + "</font>";

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageBGImages.aspx.cs", "btnUpload_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                pnlShowLoader.Style.Add("display", "none");
            }
        }



        private void SaveToLocal()
        {
            string TempBGDire = Server.MapPath("~/Upload/" + TempBGImagesPath + "/" + ProfileID);
            string saveimagepath = TempBGDire + "\\" + hdnImageName.Value;
            FUUserImages.SaveAs(saveimagepath);
        }
        private void UploadBGImage()
        {
            try
            {
                int CropWidth = 0;
                int CropHeight = 0;
                int definedWidth = Convert.ToInt32(Resources.ValidationValues.BackGroundImageMinWidth);
                int definedHeight = Convert.ToInt32(Resources.ValidationValues.BackGroundImageMinHeight);
                bool IsCrop = false;
                string TempBGDire = Server.MapPath("~/Upload/" + TempBGImagesPath + "/" + ProfileID);
                int Height = 0;
                int Width = 0;
                decimal minHeightPercent = Convert.ToDecimal(Resources.ValidationValues.BGImageMinHeightPercent);
                decimal maxHeightPercent = Convert.ToDecimal(Resources.ValidationValues.BGImageMaxHeightPercent);
                using (System.Drawing.Image myImage = System.Drawing.Image.FromFile(TempBGDire + "/" + hdnImageName.Value))
                {
                    Height = myImage.Height;
                    Width = myImage.Width;
                }
                if (Width >= definedWidth && Height >= definedHeight)
                {
                    int endMinHeight = (int)(Width * minHeightPercent + 0.5m);
                    int endMaxHeight = (int)(Width * maxHeightPercent + 0.5m);
                    if (Height > endMaxHeight)
                    {
                        IsCrop = true;
                        CropWidth = Width;
                        CropHeight = (int)(Width * Convert.ToDecimal(Resources.ValidationValues.CropHeightPercentage) + 0.5m);
                    }
                    else if (Height < endMinHeight)
                    {
                        IsCrop = true;
                        CropHeight = Height;
                        CropWidth = (int)((Height / Convert.ToDecimal(Resources.ValidationValues.CropHeightPercentage)) + 0.5m);
                    }
                    if (IsCrop)
                    {
                        hdnCropImgName.Value = hdnImageName.Value;
                        hdnImgURL.Value = RootPath + "/Upload/" + TempBGImagesPath + "/" + ProfileID + "/" + hdnImageName.Value + "?id=" + Guid.NewGuid();
                        BGModalPopup.Show();
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>BGImgSettings(" + definedWidth + "," + definedHeight + "," + CropWidth + "," + CropHeight + "," + Width + "," + Height + ")</script>", false);
                    }
                    else
                        BindMobileImages(Width, Height, false);
                }
                else
                    OverlayWhiteImage(Width, Height);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageBGImages.aspx.cs", "BindMobileImages()", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void OverlayWhiteImage(int width, int height)
        {
            try
            {
                int definedWidth = Convert.ToInt32(Resources.ValidationValues.BackGroundImageMinWidth);
                int definedHeight = Convert.ToInt32(Resources.ValidationValues.BackGroundImageMinHeight);
                int genereatedimgWidth = 0;
                int generatedimgHeight = 0;
                int originX = 0;
                int originY = 0;
                string filepath = Server.MapPath("~/Upload/" + TempBGImagesPath + "/" + ProfileID);
                string uploadedfilepath = Server.MapPath("~/Upload/" + TempBGImagesPath + "/" + ProfileID + "/" + hdnImageName.Value);
                string imgext = Path.GetExtension(uploadedfilepath).ToLower();
                if (width < definedWidth && height < definedHeight)
                {
                    genereatedimgWidth = definedWidth;
                    generatedimgHeight = definedHeight;
                    originX = (int)((genereatedimgWidth - width) / 2 + 0.5m);
                    //originY = (int)((generatedimgHeight - height) / 2 + 0.5m);
                }
                else if (width < definedWidth && height >= definedHeight)
                {
                    genereatedimgWidth = (int)((height / Convert.ToDecimal(Resources.ValidationValues.CropHeightPercentage)) + 0.5m);
                    generatedimgHeight = height;
                    originX = (int)((genereatedimgWidth - width) / 2 + 0.5m);
                }
                else if (width >= definedWidth && height < definedHeight)
                {
                    generatedimgHeight = (int)(width * Convert.ToDecimal(Resources.ValidationValues.CropHeightPercentage) + 0.5m);
                    genereatedimgWidth = width;
                    //originY = (int)((generatedimgHeight - height) / 2 + 0.5m);
                }
                string generatedImgpath = filepath + "/" + ProfileID + ".jpg";
                using (var generator = new ImageGenerator(genereatedimgWidth, generatedimgHeight, PixelFormat.Format24bppRgb, RgbColor.White))
                using (var drawer = new Aurigma.GraphicsMill.Drawing.GdiPlusGraphicsDrawer())
                using (var writer = ImageWriter.Create(generatedImgpath))
                {
                    Pipeline.Run(generator + drawer + writer);
                }
                filepath = filepath + "/" + hdnImageName.Value.Replace("-ResizeReference", "");

                if (imgext == ".png")
                    PngImageWritter(generatedImgpath, uploadedfilepath, filepath, originX, originY);
                else if (imgext == ".bmp")
                    BmpImageWritter(generatedImgpath, uploadedfilepath, filepath, originX, originY);
                else
                    JpegImageWritter(generatedImgpath, uploadedfilepath, filepath, originX, originY);
                hdnImageName.Value = hdnImageName.Value.Replace("-ResizeReference", "");
                BindMobileImages(genereatedimgWidth, generatedimgHeight, false);
                if (File.Exists(generatedImgpath))
                    File.Delete(generatedImgpath);
                if (File.Exists(uploadedfilepath))
                    File.Delete(uploadedfilepath);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageBGImages.aspx.cs", "BindMobileImages()", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void PngImageWritter(string generatedImgpath, string uploadedfilepath, string filepath, int originX, int originY)
        {
            using (var reader = new JpegReader(generatedImgpath))
            using (var watermark = new PngReader(uploadedfilepath))
            using (var combiner = new Combiner())
            using (var writer = new PngWriter(filepath))
            {
                var overlay = new Aurigma.GraphicsMill.Pipeline();
                overlay.Add(watermark);
                overlay.Add(new Aurigma.GraphicsMill.Transforms.ScaleAlpha(0.8f));
                combiner.Mode = Aurigma.GraphicsMill.Transforms.CombineMode.Alpha;
                combiner.TopImage = overlay;
                combiner.X = originX;
                combiner.Y = originY;
                combiner.AutoDisposeTopImage = true;
                Pipeline.Run(reader + combiner + writer);
            }
        }
        private void JpegImageWritter(string generatedImgpath, string uploadedfilepath, string filepath, int originX, int originY)
        {
            using (var reader = new JpegReader(generatedImgpath))
            using (var watermark = new JpegReader(uploadedfilepath))
            using (var combiner = new Combiner())
            using (var writer = new JpegWriter(filepath))
            {
                var overlay = new Aurigma.GraphicsMill.Pipeline();
                overlay.Add(watermark);
                overlay.Add(new Aurigma.GraphicsMill.Transforms.ScaleAlpha(0.8f));
                combiner.Mode = Aurigma.GraphicsMill.Transforms.CombineMode.Alpha;
                combiner.TopImage = overlay;
                combiner.X = originX;
                combiner.Y = originY;
                combiner.AutoDisposeTopImage = true;
                Pipeline.Run(reader + combiner + writer);
            }
        }
        private void BmpImageWritter(string generatedImgpath, string uploadedfilepath, string filepath, int originX, int originY)
        {
            using (var reader = new JpegReader(generatedImgpath))
            using (var watermark = new BmpReader(uploadedfilepath))
            using (var combiner = new Combiner())
            using (var writer = new BmpWriter(filepath))
            {
                var overlay = new Aurigma.GraphicsMill.Pipeline();
                overlay.Add(watermark);
                overlay.Add(new Aurigma.GraphicsMill.Transforms.ScaleAlpha(0.8f));
                combiner.Mode = Aurigma.GraphicsMill.Transforms.CombineMode.Alpha;
                combiner.TopImage = overlay;
                combiner.X = originX;
                combiner.Y = originY;
                combiner.AutoDisposeTopImage = true;
                Pipeline.Run(reader + combiner + writer);
            }
        }
        private void BindMobileImages(int Width, int Height, bool IsCrop)
        {
            try
            {
                string ImageDirectory = Server.MapPath("~/Upload/" + TempBGImagesPath + "/" + ProfileID);
                string saveimagepath = ImageDirectory + "/" + hdnImageName.Value;
                if (IsCrop)
                {
                    var Ext = Path.GetExtension(hdnImageName.Value);
                    hdnImageName.Value = DateTime.Now.ToString("yyyyMMddHHmmssffff") + Ext;
                    string newCropImgPath = ImageDirectory + "\\" + hdnImageName.Value;
                    using (var reader = ImageReader.Create(saveimagepath))
                    using (var crop = new Crop(Convert.ToInt32(hdnx.Value), Convert.ToInt32(hdny.Value), Convert.ToInt32(hdnw.Value), Convert.ToInt32(hdnh.Value)))
                    using (var writer = ImageWriter.Create(newCropImgPath))
                    {
                        Pipeline.Run(reader + crop + writer);
                    }
                }
                hdnImgURL.Value = RootPath + "/Upload/" + TempBGImagesPath + "/" + ProfileID + "/" + hdnImageName.Value + "?id=" + Guid.NewGuid();
                lblImg.Text = "<IMG width='150px' SRC='" + RootPath + "/Upload/" + TempBGImagesPath + "/" + ProfileID + "/" + hdnImageName.Value + "?id=" + Guid.NewGuid() + "' />";
                lbloriginalWidthk.Text = "Your Image Specification: " + Width + "x" + Height;
                ResizeThumbnail();
                LoadCurrentBGImagesPreview(TempBGImagesPath, true);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageBGImages.aspx.cs", "BindMobileImages()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void dtlistphotos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lblimgpreview = e.Item.FindControl("imgpreview") as Label;
            Label IMGWidth = e.Item.FindControl("IMGWidth") as Label;
        }
        protected void lnkResizeImage_OnClick(object sender, EventArgs e)
        {
            UploadBGImage();

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>LoaddropzoneEvents();</script>", false);
        }
        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string ProfileBGImgDire = Server.MapPath("~/Upload/" + ProfileBGImagesPath + "/" + ProfileID);
            string ProfileBGImgDireCopy = Server.MapPath("~/Upload/" + ProfileBGImagesPath + "/" + ProfileID + " - Copy");
            try
            {
                if (Directory.Exists(ProfileBGImgDire))
                {
                    if (Directory.Exists(ProfileBGImgDireCopy))
                        Directory.Delete(ProfileBGImgDireCopy, true);
                    Directory.Move(ProfileBGImgDire, ProfileBGImgDireCopy);
                }
                ResizeAllBGImages(ProfileBGImagesPath);
                objBus.UpdateModifieddateforBGImages(ProfileID);
                objBus.SaveProfileBGImage(ProfileID, true, C_UserID);
                LoadCurrentBGImagesPreview(ProfileBGImagesPath, false);
                if (System.IO.Directory.Exists(ProfileBGImgDireCopy))
                {
                    System.IO.Directory.Delete(ProfileBGImgDireCopy, true);
                }
                lblerrormsg.Text = "<font color='green'>" + Resources.LabelMessages.BGImageSubmitted.ToString() + "</font>";
                objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "BGImage", "Upload");
                EnablePanels(false);
                DeleteProfilePath(TempBGImagesPath);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageBGImages.aspx.cs", "btnSubmit_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                objBus.UpdateModifieddateforBGImages(ProfileID);
            }
            finally
            {
                lblImg.Text = "";
            }
        }
        public void IMG_Resize(string filename, Stream outputStream, WriterSettings writerSettings, int width, int height, ResizeInterpolationMode interpolationMode)
        {
            using (var reader = ImageReader.Create(filename))
            using (var resize = new Resize(width, height, interpolationMode, ResizeMode.Fit))
            using (var writer = ImageWriter.Create(outputStream, writerSettings))
            {
                Pipeline.Run(reader + resize + writer);
            }
        }
        private void ResizeThumbnail()
        {
            hdnUploadTye.Value = "";
            string ImageDirectory = Server.MapPath("~/Upload/" + TempBGImagesPath + "/" + ProfileID);
            try
            {
                string OriginalImage = Server.MapPath("~/Upload/" + TempBGImagesPath + "/" + ProfileID + "/") + hdnImageName.Value;
                string previewImgName = ProfileID + "_bg_" + Resources.ValidationValues.DisplayMobileResolution + ".png";
                string newImg = ImageDirectory + "/" + previewImgName;
                using (var reader = ImageReader.Create(OriginalImage))
                using (var resize = new Resize(Convert.ToInt32(Resources.ValidationValues.CreateImageWidth), Convert.ToInt32(Resources.ValidationValues.CreateImageHeight), ResizeInterpolationMode.High, ResizeMode.Fit))
                using (var writer = ImageWriter.Create(newImg))
                {
                    Pipeline.Run(reader + resize + writer);
                }
                lblImg.Text = "<IMG width='180px' SRC='" + RootPath + "/Upload/" + TempBGImagesPath + "/" + ProfileID + "/" + hdnImageName.Value + "?id=" + Guid.NewGuid() + "' />";
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageBGImages.aspx.cs", "ResizeThumbnail()", ex.Message,
               Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        /// <summary>
        /// Resize All Images
        /// </summary>
        private void ResizeAllBGImages(string bgPath)
        {
            #region All Resolutions images are resize
            string ImageDirectory = Server.MapPath("~/Upload/" + bgPath + "/" + ProfileID);
            try
            {
                if (!System.IO.Directory.Exists(ImageDirectory))
                {
                    System.IO.Directory.CreateDirectory(ImageDirectory);
                }
                Thread.Sleep(2 * 1000);
                string OriginalImage = Server.MapPath("~/Upload/" + TempBGImagesPath + "/" + ProfileID + "/") + hdnImageName.Value;
                string previewImgName_320 = ProfileID + "_bg_320x480.png";
                string newImg = ImageDirectory + "/" + previewImgName_320;
                using (var reader = ImageReader.Create(OriginalImage))
                using (var resize = new Resize(320, 400, ResizeInterpolationMode.High, ResizeMode.Fit))
                using (var writer = ImageWriter.Create(newImg))
                {
                    Pipeline.Run(reader + resize + writer);
                }

                string previewImgName_480 = ProfileID + "_bg_480x800.png"; ;
                newImg = ImageDirectory + "/" + previewImgName_480;
                using (var reader = ImageReader.Create(OriginalImage))
                using (var resize = new Resize(380, 470, ResizeInterpolationMode.High, ResizeMode.Fit))
                using (var writer = ImageWriter.Create(newImg))
                {
                    Pipeline.Run(reader + resize + writer);
                }

                string previewImgName_640 = ProfileID + "_bg_640x960.png";
                newImg = ImageDirectory + "/" + previewImgName_640;
                using (var reader = ImageReader.Create(OriginalImage))
                using (var resize = new Resize(640, 840, ResizeInterpolationMode.High, ResizeMode.Fit))
                using (var writer = ImageWriter.Create(newImg))
                {
                    Pipeline.Run(reader + resize + writer);
                }

                string previewImgName_800 = ProfileID + "_bg_800x1280.png";
                newImg = ImageDirectory + "/" + previewImgName_800;
                using (var reader = ImageReader.Create(OriginalImage))
                using (var resize = new Resize(720, 1100, ResizeInterpolationMode.High, ResizeMode.Fit))
                using (var writer = ImageWriter.Create(newImg))
                {
                    Pipeline.Run(reader + resize + writer);
                }

                string previewImgName_1080 = ProfileID + "_bg_1080x1920.png";
                newImg = ImageDirectory + "/" + previewImgName_1080;
                using (var reader = ImageReader.Create(OriginalImage))
                using (var resize = new Resize(1080, 1440, ResizeInterpolationMode.High, ResizeMode.Fit))
                using (var writer = ImageWriter.Create(newImg))
                {
                    Pipeline.Run(reader + resize + writer);
                }

                string previewImgName_2560 = ProfileID + "_bg_2560x1440.png";
                newImg = ImageDirectory + "/" + previewImgName_2560;
                using (var reader = ImageReader.Create(OriginalImage))
                using (var resize = new Resize(1440, 1920, ResizeInterpolationMode.High, ResizeMode.Fit))
                using (var writer = ImageWriter.Create(newImg))
                {
                    Pipeline.Run(reader + resize + writer);
                }
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>CallingLightBox()</script>", false);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageBGImages.aspx.cs", "ResizeAllBGImages()", ex.Message,
               Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            #endregion
        }
        protected void lnkDelete_OnClick(object sender, EventArgs e)
        {
            try
            {
                DeleteProfilePath(ProfileBGImagesPath);
                DeleteProfilePath(TempBGImagesPath);
                LoadCurrentBGImagesPreview(ProfileBGImagesPath, false);
                lblerrormsg.Text = "<font color='green'>Your image has been deleted successfully.</font>";
                objBus.UpdateModifieddateforBGImages(ProfileID);
                objBus.SaveProfileBGImage(ProfileID, false, C_UserID);
            }
            catch (Exception /*ex*/)
            {

            }
        }
        private void DeleteProfilePath(string bgPath)
        {
            string ProfileBGImgDire = Server.MapPath("~/Upload/" + bgPath + "/" + ProfileID);
            if (System.IO.Directory.Exists(ProfileBGImgDire))
            {
                System.IO.Directory.Delete(ProfileBGImgDire, true);
            }
        }
        protected void lnkCancel_OnClick(object sender, EventArgs e)
        {
            DeleteProfilePath(TempBGImagesPath);
            LoadCurrentBGImagesPreview(ProfileBGImagesPath, false);
        }
        protected void btnCrop_OnClick(object sender, EventArgs e)
        {
            BindMobileImages(Convert.ToInt32(hdnw.Value), Convert.ToInt32(hdnh.Value), true);
            lnkTryAgain.Visible = true;
        }
        protected void btnCropCancel_Click(object sender, EventArgs e)
        {
        }
        protected void lnkTryAgain_OnClick(object sender, EventArgs e)
        {
            hdnImageName.Value = hdnCropImgName.Value;
            UploadBGImage();
        }
        public int generatedimgHeight { get; set; }
    }
}