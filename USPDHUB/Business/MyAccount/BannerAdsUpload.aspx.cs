using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.IO;
using Aurigma.GraphicsMill.Transforms;
using Aurigma.GraphicsMill.Codecs;
using Aurigma.GraphicsMill;
using System.Threading;
using System.Data;
using System.Text;
using System.Xml.Linq;

namespace USPDHUB.Business.MyAccount
{
    public partial class BannerAdsUpload : BaseWeb
    {
        public string RootPath = "";
        public string DomainName = "";
        public int UserID = 0;
        public int C_UserID = 0;
        public int ProfileID = 0;
        BusinessBLL objBus = new BusinessBLL();
        public string ProfileBannerAdsPath = "BannerAds";
        public string TempBannerImagesPath = "TempBannerImages";
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        public string VerticalCodeFolderName = "";
        public int definedWidth = Convert.ToInt32(Resources.ValidationValues.BannerAdImageMinWidth);
        public int definedHeight = Convert.ToInt32(Resources.ValidationValues.BannerAdImageMinHeight);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                    Session.Remove("SaveMessage");
                    if (Request.QueryString["slot"] == null && Request.QueryString["banid"] == null)
                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/BannerAdsPreview.aspx"));
                    else
                    {
                        if (Request.QueryString["slot"] != null)
                            hdnSlotNumber.Value = EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["slot"]));
                        if (Request.QueryString["banid"] != null)
                            hdnBannerId.Value = EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["banid"]));
                    }
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        string Permission_Type = string.Empty;
                        Permission_Type = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, CommonModules.BannerAds);
                        if (Permission_Type == "")
                            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
                    }
                    hdnUploadTye.Value = "";
                    DisableAllPanels();
                    if (Convert.ToInt32(hdnBannerId.Value) > 0)
                    {
                        lblHeader.Text = Resources.LabelMessages.BannerAdLinkEdit;
                        pnlLink.Style.Add("display", "block");
                        ShowBannerPreview();
                    }
                    else
                        pnlUpload.Style.Add("display", "block");
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void DisableAllPanels()
        {
            try
            {
                lblShowPreview.Text = "";
                pnlUpload.Style.Add("display", "none");
                pnlSubmit.Style.Add("display", "none");
                pnlLink.Style.Add("display", "none");
                lnkTryAgain.Visible = false;
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "DisableAllPanels", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void EnablePanels(bool isUpload)
        {
            try
            {
                if (isUpload)
                {
                    //pnlUpload.Style.Add("display", "block");
                    pnlSubmit.Style.Add("display", "block");
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "EnablePanels", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void ShowBannerPreview()
        {
            try
            {
                DataTable dtBanner = objBus.GetBannerAdById(Convert.ToInt32(hdnBannerId.Value));
                if (dtBanner.Rows.Count > 0)
                {
                    lblShowPreview.Text = "<img src=\"" + RootPath + "/Upload/BannerAds/" + ProfileID + "/" + Convert.ToString(dtBanner.Rows[0]["Ads_Timespan"]) + "_" + Resources.ValidationValues.DisplayMobileResolution + ".png?id=" + Guid.NewGuid() + "\"/>";
                    txtAdLink.Text = txtLinkUrl.Text = Convert.ToString(dtBanner.Rows[0]["Hyperlink_Url"]);
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "ShowBannerPreview", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            try
            {
                pnlShowLoader.Style.Add("display", "block");
                string TempBGDire = Server.MapPath("~/Upload/" + TempBannerImagesPath + "/" + ProfileID);
                if (FUUserImages.HasFile)
                {
                    string imgFilename = objCommon.RemoveSpecialCharacters(FUUserImages.FileName);
                    string imageExtension = Path.GetExtension(FUUserImages.FileName).ToLower();
                    hdnImageName.Value = imgFilename.Replace(imageExtension, "-ResizeReference" + imageExtension);
                    if (imageExtension == ".jpg" || imageExtension == ".jpeg" || imageExtension == ".gif" || imageExtension == ".png" || imageExtension == ".bmp")
                    {
                        DeleteProfilePath(TempBannerImagesPath);
                        if (!Directory.Exists(TempBGDire))
                            Directory.CreateDirectory(TempBGDire);
                        SaveToLocal();
                        UploadBannerImage();
                    }
                    else
                        lblerrormsg.Text = "<font color='red'>Your image is not in the correct file format; please use .jpeg, .jpg, .gif, .png or .bmp only.</font>";
                }
                else
                    lblerrormsg.Text = "<font color='red'>" + Resources.LabelMessages.FileNotSelected + "</font>";

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "btnUpload_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                pnlShowLoader.Style.Add("display", "none");
            }
        }
        private void DeleteProfilePath(string bgPath)
        {
            try
            {
                string ProfileBGImgDire = Server.MapPath("~/Upload/" + bgPath + "/" + ProfileID);
                if (System.IO.Directory.Exists(ProfileBGImgDire))
                {
                    System.IO.Directory.Delete(ProfileBGImgDire, true);
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "DeleteProfilePath", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void SaveToLocal()
        {
            try
            {
                string TempBGDire = Server.MapPath("~/Upload/" + TempBannerImagesPath + "/" + ProfileID);
                string saveimagepath = TempBGDire + "\\" + hdnImageName.Value;
                FUUserImages.SaveAs(saveimagepath);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "SaveToLocal", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void UploadBannerImage()
        {
            try
            {
                string TempBanneradDire = Server.MapPath("~/Upload/" + TempBannerImagesPath + "/" + ProfileID);
                int Height = 0;
                int Width = 0;
                using (System.Drawing.Image myImage = System.Drawing.Image.FromFile(TempBanneradDire + "/" + hdnImageName.Value))
                {
                    Height = myImage.Height;
                    Width = myImage.Width;
                }
                if (Width >= definedWidth && Height >= definedHeight)
                    MakeCropOrSubmit(Width, Height);
                else
                    OverlayWhiteImage(Width, Height);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "UploadBannerImage()", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void MakeCropOrSubmit(int imgWidth, int imgHeight)
        {
            try
            {
                int CropWidth = 0;
                int CropHeight = 0;
                bool IsCrop = false;
                decimal minWidthPercent = Convert.ToDecimal(Resources.ValidationValues.BannerAdImageMinWidthPercent);
                decimal maxWidthPercent = Convert.ToDecimal(Resources.ValidationValues.BannerAdImageMaxWidthPercent);
                int endMinWidth = (int)(imgHeight * minWidthPercent + 0.5m);
                int endMaxWidth = (int)(imgHeight * maxWidthPercent + 0.5m);
                if (imgWidth > endMaxWidth)
                {
                    IsCrop = true;
                    CropHeight = imgHeight;
                    CropWidth = (int)(imgHeight * Convert.ToDecimal(Resources.ValidationValues.BannerCropWidthPercentage) + 0.5m);
                }
                else if (imgWidth < endMinWidth)
                {
                    IsCrop = true;
                    CropWidth = imgWidth;
                    CropHeight = (int)((imgWidth / Convert.ToDecimal(Resources.ValidationValues.BannerCropWidthPercentage)) + 0.5m);
                }
                if (IsCrop)
                {
                    hdnCropImgName.Value = hdnImageName.Value;
                    hdnImgURL.Value = RootPath + "/Upload/" + TempBannerImagesPath + "/" + ProfileID + "/" + hdnImageName.Value + "?id=" + Guid.NewGuid();
                    BannerAdModalPopup.Show();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>BGImgSettings(" + definedWidth + "," + definedHeight + "," + CropWidth + "," + CropHeight + "," + imgWidth + "," + imgHeight + ")</script>", false);
                }
                else
                    BindBannerImages(imgWidth, imgHeight, false);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "MakeCropOrSubmit", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void OverlayWhiteImage(int width, int height)
        {
            try
            {
                int genereatedimgWidth = 0;
                int generatedimgHeight = 0;
                int originX = 0;
                int originY = 0;
                string filepath = Server.MapPath("~/Upload/" + TempBannerImagesPath + "/" + ProfileID);
                string uploadedfilepath = Server.MapPath("~/Upload/" + TempBannerImagesPath + "/" + ProfileID + "/" + hdnImageName.Value);
                string imgext = Path.GetExtension(uploadedfilepath).ToLower();
                if (width < definedWidth && height < definedHeight)
                {
                    genereatedimgWidth = definedWidth;
                    generatedimgHeight = definedHeight;
                    originX = (int)((genereatedimgWidth - width) / 2 + 0.5m);
                    originY = (int)((generatedimgHeight - height) / 2 + 0.5m);
                }
                else if (width < definedWidth && height >= definedHeight)
                {
                    genereatedimgWidth = definedWidth;
                    generatedimgHeight = height;
                    originX = (int)((genereatedimgWidth - width) / 2 + 0.5m);
                }
                else if (width >= definedWidth && height < definedHeight)
                {
                    generatedimgHeight = definedHeight;
                    genereatedimgWidth = width;
                    originY = (int)((generatedimgHeight - height) / 2 + 0.5m);
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
                MakeCropOrSubmit(genereatedimgWidth, generatedimgHeight);
                if (File.Exists(generatedImgpath))
                    File.Delete(generatedImgpath);
                if (File.Exists(uploadedfilepath))
                    File.Delete(uploadedfilepath);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "OverlayWhiteImage()", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void PngImageWritter(string generatedImgpath, string uploadedfilepath, string filepath, int originX, int originY)
        {
            try
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
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "PngImageWritter", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void JpegImageWritter(string generatedImgpath, string uploadedfilepath, string filepath, int originX, int originY)
        {
            try
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
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "JpegImageWritter", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BmpImageWritter(string generatedImgpath, string uploadedfilepath, string filepath, int originX, int originY)
        {
            try
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
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "BmpImageWritter", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BindBannerImages(int Width, int Height, bool IsCrop)
        {
            try
            {
                
                string ImageDirectory = Server.MapPath("~/Upload/" + TempBannerImagesPath + "/" + ProfileID);
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
                hdnImgURL.Value = RootPath + "/Upload/" + TempBannerImagesPath + "/" + ProfileID + "/" + hdnImageName.Value + "?id=" + Guid.NewGuid();
                lblImg.Text = "<IMG width='320px' SRC='" + RootPath + "/Upload/" + TempBannerImagesPath + "/" + ProfileID + "/" + hdnImageName.Value + "?id=" + Guid.NewGuid() + "' />";
                ResizeThumbnail();
                DisableAllPanels();
                EnablePanels(true);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "BindBannerImages()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void ResizeThumbnail()
        {
            
            hdnUploadTye.Value = "";
            string ImageDirectory = Server.MapPath("~/Upload/" + TempBannerImagesPath + "/" + ProfileID);
            try
            {
                string OriginalImage = Server.MapPath("~/Upload/" + TempBannerImagesPath + "/" + ProfileID + "/") + hdnImageName.Value;
                string previewImgName = ProfileID + "_banner_" + Resources.ValidationValues.DisplayMobileResolution + ".png";
                string newImg = ImageDirectory + "/" + previewImgName;
                using (var reader = ImageReader.Create(OriginalImage))
                using (var resize = new Resize(Convert.ToInt32(Resources.ValidationValues.BannerCreateImageWidth), Convert.ToInt32(Resources.ValidationValues.BannerCreateImageHeight), ResizeInterpolationMode.High, ResizeMode.Fit))
                using (var writer = ImageWriter.Create(newImg))
                {
                    Pipeline.Run(reader + resize + writer);
                }
                lblImg.Text = "<img width='320px' SRC='" + RootPath + "/Upload/" + TempBannerImagesPath + "/" + ProfileID + "/" + previewImgName + "?id=" + Guid.NewGuid() + "' />";
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "ResizeThumbnail()", ex.Message,
               Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string ProfileBannerImgDire = Server.MapPath("~/Upload/" + ProfileBannerAdsPath + "/" + ProfileID);
            try
            {
                string fileWith = DateTime.Now.ToString("yyyyMMddHHmmss");
                ResizeAllBannerAds(ProfileBannerAdsPath, fileWith);
                objBus.Insert_BannerAds(Convert.ToInt32(hdnBannerId.Value), ProfileID, UserID, txtLinkUrl.Text.Trim(), Convert.ToInt32(hdnSlotNumber.Value), fileWith, true, C_UserID);
                Session["SaveMessage"] = "<font color='green'>" + Resources.LabelMessages.BGImageSubmitted.ToString() + "</font>";
                DeleteProfilePath(TempBannerImagesPath);
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/BannerAdsPreview.aspx"));
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "btnSubmit_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                objBus.UpdateModifieddateforBGImages(ProfileID);
            }
            finally
            {
                lblImg.Text = "";
            }
        }
        protected void lnkUpadteLink_OnClick(object sender, EventArgs e)
        {
            try
            {
                int slotNo = 0;
                if (hdnSlotNumber.Value != "")
                    slotNo = Convert.ToInt32(hdnSlotNumber.Value);
                if (Convert.ToInt32(hdnBannerId.Value) > 0)
                {
                    objBus.Insert_BannerAds(Convert.ToInt32(hdnBannerId.Value), ProfileID, UserID, txtAdLink.Text.Trim(), slotNo, "", true, C_UserID);
                    Session["SaveMessage"] = "<font color='green'>" + Resources.LabelMessages.BannerAdLinkSaved + "</font>";
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/BannerAdsPreview.aspx"));
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "lnkUpadteLink_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void ResizeAllBannerAds(string bgPath, string fileWith)
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
                string OriginalImage = Server.MapPath("~/Upload/" + TempBannerImagesPath + "/" + ProfileID + "/") + hdnImageName.Value;
                string previewImgName_320 = fileWith + "_320x480.png";
                string newImg = ImageDirectory + "/" + previewImgName_320;
                using (var reader = ImageReader.Create(OriginalImage))
                using (var resize = new Resize(320, 51, ResizeInterpolationMode.High, ResizeMode.Resize))
                using (var writer = ImageWriter.Create(newImg))
                {
                    Pipeline.Run(reader + resize + writer);
                }

                string previewImgName_480 = fileWith + "_480x800.png"; ;
                newImg = ImageDirectory + "/" + previewImgName_480;
                using (var reader = ImageReader.Create(OriginalImage))
                using (var resize = new Resize(480, 76, ResizeInterpolationMode.High, ResizeMode.Resize))
                using (var writer = ImageWriter.Create(newImg))
                {
                    Pipeline.Run(reader + resize + writer);
                }

                string previewImgName_640 = fileWith + "_640x960.png";
                newImg = ImageDirectory + "/" + previewImgName_640;
                using (var reader = ImageReader.Create(OriginalImage))
                using (var resize = new Resize(640, 101, ResizeInterpolationMode.High, ResizeMode.Resize))
                using (var writer = ImageWriter.Create(newImg))
                {
                    Pipeline.Run(reader + resize + writer);
                }

                string previewImgName_800 = fileWith + "_800x1280.png";
                newImg = ImageDirectory + "/" + previewImgName_800;
                using (var reader = ImageReader.Create(OriginalImage))
                using (var resize = new Resize(800, 126, ResizeInterpolationMode.High, ResizeMode.Resize))
                using (var writer = ImageWriter.Create(newImg))
                {
                    Pipeline.Run(reader + resize + writer);
                }

                string previewImgName_1080 = fileWith + "_1080x1920.png";
                newImg = ImageDirectory + "/" + previewImgName_1080;
                using (var reader = ImageReader.Create(OriginalImage))
                using (var resize = new Resize(1080, 170, ResizeInterpolationMode.High, ResizeMode.Resize))
                using (var writer = ImageWriter.Create(newImg))
                {
                    Pipeline.Run(reader + resize + writer);
                }

                string previewImgName_2560 = fileWith + "_2560x1440.png";
                newImg = ImageDirectory + "/" + previewImgName_2560;
                using (var reader = ImageReader.Create(OriginalImage))
                using (var resize = new Resize(1080, 170, ResizeInterpolationMode.High, ResizeMode.Resize))
                using (var writer = ImageWriter.Create(newImg))
                {
                    Pipeline.Run(reader + resize + writer);
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "ResizeAllBGImages()", ex.Message,
               Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            #endregion
        }
        protected void lnkTryAgain_OnClick(object sender, EventArgs e)
        {
            try
            {
                hdnImageName.Value = hdnCropImgName.Value;
                UploadBannerImage();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "lnkTryAgain_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCrop_OnClick(object sender, EventArgs e)
        {
            try
            {
                BindBannerImages(Convert.ToInt32(hdnw.Value), Convert.ToInt32(hdnh.Value), true);
                lnkTryAgain.Visible = true;
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "btnCrop_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCropCancel_Click(object sender, EventArgs e)
        {
        }
        protected void lnkResizeImage_OnClick(object sender, EventArgs e)
        {
            try
            {
                UploadBannerImage();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>LoaddropzoneEvents();</script>", false);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "lnkResizeImage_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/BannerAdsPreview.aspx"));
        }

        protected void lnkCancel_OnClick(object sender, EventArgs e)
        {
            try
            {
                pnlUpload.Style.Add("display", "block");
                pnlSubmit.Style.Add("display", "none");
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "BannerAdsUpload.aspx.cs", "lnkCancel_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


    }
}