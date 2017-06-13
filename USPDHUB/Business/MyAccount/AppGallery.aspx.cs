using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Configuration;

namespace USPDHUB.Business.MyAccount
{
    public partial class AppGallery : BaseWeb
    {
        public int UserID = 0;
        public int C_UserID = 0;
        public int ProfileID = 0;

        CommonBLL objCommon = new CommonBLL();
        public string Permission_Type = string.Empty;
        public int Permission_Value = 0;
        public string RootPath = "";
        public string DomainName = "";
        public string titleName = "";

        USPDHUBBLL.MobileAppSettings objApp = new USPDHUBBLL.MobileAppSettings();

        public string AlbumName = "";
        public string AlbumUniqueName = "";

        public string ImageName = "";
        public string ImageUniqueName = "";
        public string imgExt = "";
        public string ImageCaption = "";

        BusinessBLL objBusinessBLL = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

        DataTable dtActiveAlbums = new DataTable();
        DataTable dtGalleryImages = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "AppGallery.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

                if (Session["UserName"] == null)
                    Response.Redirect(Page.ResolveClientUrl("~/login.aspx?sflag=1"));
                else
                {
                    UserID = Convert.ToInt32(Session["UserID"]);
                    if (Session["ProfileID"] != null)
                        ProfileID = Convert.ToInt32(Session["ProfileID"]);

                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                        C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        C_UserID = UserID;
                }
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                titleName = objApp.GetMobileAppSettingTabName(UserID, "Gallery", DomainName);
                lblTitle.Text = titleName;
                lblMessage.Text = "";


                if (!IsPostBack)
                {
                    lblOff.Visible = true;

                    if (objCommon.DisplayOn_OffSettingsContent(UserID, "Gallery"))
                    {
                        lblOn.Visible = true;
                        lblOff.Visible = false;
                    }
                    LoadAlbumDetails();
                }

                if (hdnOpenMasterWindow.Value == "1")
                {
                    modalWindowMasterGallery.Show();
                }
                else
                {
                    modalWindowMasterGallery.Hide();
                }


                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>displaypanel();</script>", false);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void LoadAlbumDetails()
        {
            try
            {
                dtActiveAlbums = objBusinessBLL.GetActiveAlbumsByGalleryType(ProfileID, ImageGalleryTypes.AppGalleryType.ToString());

                if (dtActiveAlbums.Rows.Count > 0)
                {
                    hdnAlbumID.Value = dtActiveAlbums.Rows[0]["Album_ID"].ToString();
                    LoadGalleryImages();

                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "LoadAlbumDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        public void LoadGalleryImages()
        {
            try
            {
                cbSelectAll.Checked = false;
                if (hdnUploadingType.Value == "Drop")
                { Thread.Sleep(1000 * 2); hdnUploadingType.Value = ""; }

                dtGalleryImages = objBusinessBLL.GetGalleryImagesByAlbumID(Convert.ToInt32(hdnAlbumID.Value));
                // Bind Images
                dtlistImages.DataSource = dtGalleryImages;
                dtlistImages.DataBind();

                if (dtGalleryImages.Rows.Count > 0)
                {
                    btnDeleteImages.Visible = true;
                    btnEditImgCaption.Visible = true;
                    btnEditImgOrder.Visible = true;
                }
                else
                {
                    btnDeleteImages.Visible = false;
                    btnEditImgCaption.Visible = false;
                    btnEditImgOrder.Visible = false;
                }

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>displaypanel();</script>", false);


                int count = objBusinessBLL.CheckingExistedImgOrderNo(0, 0, Convert.ToInt32(hdnAlbumID.Value), "GetMaxOrderNo");
                txtOrderNumber.Text = count.ToString();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "LoadGalleryImages", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        protected void dtlistImages_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                Label imgpreview = e.Item.FindControl("imgpreview") as Label;
                Label lblAlbumUniqueName = e.Item.FindControl("lblImageUniqueName") as Label;
                string previewImgPath = "";

                previewImgPath = RootPath + "/Upload/AppGallery/" + ProfileID + "/" + imgpreview.Text.Trim();

                imgpreview.Text = "";
                imgpreview.Text = "<a href=" + previewImgPath + " ><IMG border='0' width='150px' height='150px' src=" + previewImgPath + " /></a>";

                Label lbldesc = e.Item.FindControl("lbldesc") as Label;
                string description = lbldesc.Text;
                string photodesc = lbldesc.Text;
                if (description.Length > 22)
                {
                    description = description.Remove(19);
                    description = description.Insert(19, "...");
                    description = description.Insert(22, "<br/>");
                    string title = string.Empty;

                    title = title + " <img src=" + RootPath + "/images/more.gif title=\"" + photodesc + "\"/>";
                    description = description.Insert(27, title);
                }
                lbldesc.Text = description;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "dtlistImages_ItemDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnUpload1_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (rbSystem.Checked)
                {
                    FromSystemImageUploading();
                }
                else
                {
                    FromMasterGalleryImagesUploading();
                }

                txtimagname.Text = "";
                //txtOrderNumber.Text = "";
                txtImgCaption.Text = "";
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "btnUpload1_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void FromSystemImageUploading()
        {
            try
            {
                if (hdnUploadingType.Value == "Browse")
                {
                    if (SingleFileUploadControl.PostedFile != null)
                    {
                        if (SingleFileUploadControl.PostedFile.FileName.ToString().Length > 1)
                        {
                            imgExt = Path.GetExtension(SingleFileUploadControl.PostedFile.FileName);
                            if (imgExt == ".jpg" || imgExt == ".JPG" || imgExt == ".JPEG" || imgExt == ".jpeg" || imgExt == ".GIF" ||
                                imgExt == ".gif" || imgExt == ".bmp" || imgExt == ".BMP" || imgExt == ".png" || imgExt == ".PNG")
                            {
                                if (txtOrderNumber.Text.Trim() != "")
                                {
                                    int count = objBusinessBLL.CheckingExistedImgOrderNo(0, Convert.ToInt32(txtOrderNumber.Text), Convert.ToInt32(hdnAlbumID.Value), "new");
                                    if (count > 0)
                                    {
                                        lblMessage.Text = "<font color=red face=arial size=2>This image order is number already existed.</font>";
                                        return;
                                    }
                                }

                                string RootFolder = "";
                                RootFolder = Server.MapPath("~/Upload/AppGallery/") + ProfileID;
                                if (!Directory.Exists(RootFolder))
                                {
                                    Directory.CreateDirectory(RootFolder);
                                }

                                ImageName = txtimagname.Text.Trim();
                                ImageUniqueName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + imgExt;
                                Session["TempImageUniqueName"] = ImageUniqueName;
                                string imagePath = RootFolder + "//" + ImageUniqueName;
                                SingleFileUploadControl.SaveAs(imagePath);

                                if (txtOrderNumber.Text == "")
                                { txtOrderNumber.Text = "0"; }
                                objBusinessBLL.InsertGalleryImages(txtimagname.Text.Trim(), ImageUniqueName, txtImgCaption.Text.Trim(), Convert.ToInt32(hdnAlbumID.Value),
                                    Convert.ToInt32(txtOrderNumber.Text), C_UserID);


                                #region This One More Copy to Master Galley

                                // One more copy Master Gallery Also
                                DataTable dtRootAlbumDetails = objBusinessBLL.GetRootAlbumDetailsByGallerType(ProfileID, USPDHUBBLL.ImageGalleryTypes.MasterGalleryType.ToString());
                                int RootAlbumID = Convert.ToInt32(dtRootAlbumDetails.Rows[0]["Album_ID"]);

                                string MasterRootFolder1 = HttpContext.Current.Server.MapPath("~/Upload/MasterGallery/") + ProfileID;
                                imagePath = MasterRootFolder1 + "\\" + ImageUniqueName;
                                SingleFileUploadControl.SaveAs(imagePath);
                                objBusinessBLL.InsertGalleryImages(ImageName, ImageUniqueName, "", Convert.ToInt32(RootAlbumID), 0, Convert.ToInt32(ProfileID));


                                #endregion


                                txtimagname.Text = "";
                                txtImgCaption.Text = "";
                                txtOrderNumber.Text = "";

                                LoadGalleryImages();
                                lblMessage.Text = "<font color=green face=arial size=2>Your image has uploaded successfully.</font>";
                            }
                            else
                            {
                                lblMessage.Text = "<font color=red face=arial size=2>Your image is not in the correct file format.</font>";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "<font color=red face=arial size=2>Please select an image to upload.</font>";
                        }
                    }

                    else
                    {
                        lblMessage.Text = "<font color=red face=arial size=2>Please select an image to upload.</font>";
                    }
                }
                else
                {
                    LoadGalleryImages();
                    lblMessage.Text = "<font color=green face=arial size=2>Your image has uploaded successfully.</font>";
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "FromSystemImageUploading", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void FromMasterGalleryImagesUploading()
        {

        }

        private string ReplaceSpecialCharacters(string inputString)
        {
            //inputString = Regex.Replace(inputString, @"[^0-9a-zA-Z]+", "");

            return inputString;
        }


        #region Crop Images

        protected void btnCropLogo_OnClick(object sender, EventArgs e)
        {
            try
            {
                string TempRootFolder = "";
                TempRootFolder = Server.MapPath("~/Upload/TempAppGallery/") + ProfileID;
                string tempImgPath = TempRootFolder + "\\" + Session["TempImageUniqueName"].ToString();

                string RootFolder = "";
                RootFolder = Server.MapPath("~/Upload/AppGallery/") + ProfileID;


                string newImgPath = "";
                if (rbSystemResizeLogo.Checked)
                {
                    ImageUniqueName = Session["resizeTempImgUniqueName"].ToString();
                    string resizeTempImgPath = TempRootFolder + "\\" + Session["resizeTempImgUniqueName"].ToString();
                    newImgPath = RootFolder + "\\" + Session["resizeTempImgUniqueName"].ToString();
                    File.Copy(resizeTempImgPath, newImgPath, true);
                }
                else
                {
                    // Crop Img from Orginal Image
                    using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(tempImgPath)))
                    {
                        using (System.Drawing.Image img = System.Drawing.Image.FromStream(ms))
                        {
                            Rectangle cropcords = new Rectangle(Convert.ToInt32(hdnx.Value),
                            Convert.ToInt32(hdny.Value),
                            Convert.ToInt32(hdnw.Value),
                            Convert.ToInt32(hdnh.Value));

                            using (Bitmap bitMap = new Bitmap(cropcords.Width, cropcords.Height, img.PixelFormat))
                            {
                                Graphics grph = Graphics.FromImage(bitMap);
                                grph.DrawImage(img, new Rectangle(0, 0, bitMap.Width, bitMap.Height), cropcords, GraphicsUnit.Pixel);

                                GC.Collect();
                                Response.Clear();
                                Response.ClearContent();
                                Response.Clear();
                                Response.Cache.SetExpires(DateTime.Now);
                                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                                this.ViewState.Clear();

                                newImgPath = RootFolder + "\\" + Session["TempImageUniqueName"].ToString();
                                ImageUniqueName = Session["TempImageUniqueName"].ToString();

                                if (File.Exists(newImgPath))
                                {
                                    File.Delete(newImgPath);
                                }
                                bitMap.Save(newImgPath);
                            }// third using
                        }// Scond Using
                    } // Frist Using

                } //end else


                if (txtOrderNumber.Text.Trim() == "")
                { txtOrderNumber.Text = "0"; }
                objBusinessBLL.InsertGalleryImages(txtimagname.Text.Trim(), ImageUniqueName, txtImgCaption.Text.Trim(), Convert.ToInt32(hdnAlbumID.Value),
                    Convert.ToInt32(txtOrderNumber.Text), C_UserID);


                txtimagname.Text = "";
                txtImgCaption.Text = "";
                txtOrderNumber.Text = "";

                LoadGalleryImages();

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "btnCropLogo_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnCropCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeleteImages_OnClick(object sender, EventArgs e)
        {
            try
            {
                cbSelectAll.Checked = false;
                foreach (DataListItem listItem in dtlistImages.Items)
                {
                    CheckBox chkBox = (CheckBox)listItem.FindControl("chk");
                    Label lblImgID = (Label)listItem.FindControl("lblImgID");
                    Label lblImageUniqueName = (Label)listItem.FindControl("lblImageUniqueName");

                    if (chkBox.Checked)
                    {
                        string RootFolder = "";

                        RootFolder = Server.MapPath("~/Upload/AppGallery/") + ProfileID;

                        objBusinessBLL.DeleteGalleryImagesbyImgID(Convert.ToInt32(lblImgID.Text));
                        string imgPath = RootFolder + "\\" + lblImageUniqueName.Text.Trim();
                        if (File.Exists(imgPath))
                        {
                            File.Delete(imgPath);
                        }
                    }
                }

                //LoadAlbumDetails();
                LoadGalleryImages();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "btnDeleteImages_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }


        #endregion

        protected void btnEditImgOrder_OnClick(object sender, EventArgs e)
        {
            try
            {
                ModalPopupImgOrderNo.Show();
                btnUpdateImgOrderNumber.CommandArgument = GetSelectedImageID();
            }
            catch (Exception /*ex*/)
            {
            }
        }

        protected void btnUpdateImgOrderNumber_OnClick(object sender, EventArgs e)
        {
            try
            {
                lblEditOrderNumberErrorMessage.Text = "";

                int count = objBusinessBLL.CheckingExistedImgOrderNo(Convert.ToInt32(btnUpdateImgOrderNumber.CommandArgument),
                    Convert.ToInt32(txteditordernumber.Text), Convert.ToInt32(hdnAlbumID.Value), "update");
                if (count > 0)
                {
                    lblEditOrderNumberErrorMessage.Text = "<font color=red face=arial size=2>This image order number is already existed.</font>";
                    ModalPopupImgOrderNo.Show();
                    return;
                }


                int EditOrderNo = Convert.ToInt32(txteditordernumber.Text);
                objBusinessBLL.Update_ImgOrderNo_ImgCaption(Convert.ToInt32(btnUpdateImgOrderNumber.CommandArgument), EditOrderNo, "", "IMG_ORDER_NO");

                LoadGalleryImages();

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>displaypanel();</script>", false);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "btnUpdateImgOrderNumber_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnEditImgCaption_OnClick(object sender, EventArgs e)
        {
            try
            {
                modalWidnowEditCaption.Show();
                btnEditImgCaption.CommandArgument = GetSelectedImageID();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "btnEditImgCaption_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnEditImgCaptionUpdate_OnClick(object sender, EventArgs e)
        {
            try
            {
                objBusinessBLL.Update_ImgOrderNo_ImgCaption(Convert.ToInt32(btnEditImgCaption.CommandArgument), 0, txtEditImageCaption.Text, "IMG_CAPTION");

                LoadGalleryImages();

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>displaypanel();</script>", false);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "btnEditImgCaptionUpdate_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void ImageResize(string newImgfolderLocation, string imgPath, int pWidth, int pHeight, string oldImgLocation)
        {
            try
            {
                GC.Collect();
                Response.Clear();
                Response.ClearContent();
                Response.Clear();
                Response.Cache.SetExpires(DateTime.Now);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                this.ViewState.Clear();


                string SaveImgLocation = newImgfolderLocation + "\\" + imgPath;

                if (!Directory.Exists(newImgfolderLocation))
                {
                    Directory.CreateDirectory(newImgfolderLocation);
                }

                if (File.Exists(oldImgLocation))
                {
                    Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                    uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(oldImgLocation);

                    Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                    actResize.Width = pWidth;

                    if (pHeight == 0)
                    {
                        actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.WidthBased;
                    }
                    else
                    {
                        actResize.Height = pHeight;
                        actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.None;
                    }
                    uploadedImage.Actions.Add(actResize);
                    actResize = null;
                    Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                    imgDraw.Elements.Add(uploadedImage);
                    imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                    imgDraw.JpegCompressionLevel = 90;

                    //Now, save the output image on disk
                    if (File.Exists(SaveImgLocation))
                    {
                        File.Delete(SaveImgLocation);
                    }
                    imgDraw.Save(SaveImgLocation);
                    imgDraw.Dispose();

                    uploadedImage = null;
                }

                Response.Clear();
                Response.ClearContent();
                Response.Clear();
                Response.Cache.SetExpires(DateTime.Now);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                this.ViewState.Clear();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "ImageResize", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string GetSelectedImageID()
        {
            string imgID = "";
            try
            {
                
                foreach (DataListItem row1 in dtlistImages.Items)
                {
                    CheckBox chk1 = row1.FindControl("chk") as CheckBox;
                    if (chk1.Checked)
                    {
                        imgID = dtlistImages.DataKeys[row1.ItemIndex].ToString();
                        Label lblOrderNo = (Label)row1.FindControl("lblOrderNo");
                        Label lblImageUniqueName = (Label)row1.FindControl("lblImageUniqueName");
                        Label lblCaption = (Label)row1.FindControl("lbldesc");

                        string previewImgPath = "";
                        previewImgPath = RootPath + "/Upload/AppGallery/" + ProfileID + "/" + lblImageUniqueName.Text.Trim();

                        lblEditOrderNoImgPreview.Text = "";
                        lblEditOrderNoImgPreview.Text = "<IMG border='0' width='150px' height='150px' src=" + previewImgPath + " />";
                        txteditordernumber.Text = lblOrderNo.Text.Trim();

                        lblCaptionImgPreview.Text = "";
                        lblCaptionImgPreview.Text = "<IMG border='0' width='150px' height='150px' src=" + previewImgPath + " />";

                        txtEditImageCaption.Text = lblCaption.Text;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "GetSelectedImageID", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

            return imgID;
        }

        private void ClearCaches()
        {
            try
            {
                GC.Collect();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "ClearCaches", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnMasterGallery_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataList dl = CommonMasterGallery1.FindControl("dtlistImages") as DataList;
                foreach (DataListItem row1 in dl.Items)
                {
                    CheckBox chk1 = row1.FindControl("chk") as CheckBox;
                    chk1.Checked = false;
                }
                modalWindowMasterGallery.Show();

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "btnMasterGallery_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void ImgCloseMasterGalleryWindow_OnClick(object sender, EventArgs e)
        {
            try
            {
                hdnOpenMasterWindow.Value = "";
                modalWindowMasterGallery.Hide();
                rbSystem.Checked = true;
                rbMasterGallery.Checked = false;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "ImgCloseMasterGalleryWindow_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataList dl = CommonMasterGallery1.FindControl("dtlistImages") as DataList;
                TreeView selectedTreeview = CommonMasterGallery1.FindControl("TVAlbums") as TreeView;

                var AID = Convert.ToInt32(selectedTreeview.SelectedNode.Value);

                var AlbumDetails = objBusinessBLL.GetAlbumDetailsByAlbumID(AID);

                string previewImgPath = "";
                string copyImgPath = "";
                string imgTitle = "";

                foreach (DataListItem row1 in dl.Items)
                {
                    CheckBox chk1 = row1.FindControl("chk") as CheckBox;
                    if (chk1.Checked)
                    {
                        string imgID = dl.DataKeys[row1.ItemIndex].ToString();
                        Label lblOrderNo = (Label)row1.FindControl("lblOrderNo");
                        Label lblImageUniqueName = (Label)row1.FindControl("lblImageUniqueName");
                        Label lblimgName = (Label)row1.FindControl("lblimgName");
                        imgTitle = lblimgName.Text;

                        imgExt = Path.GetExtension(lblImageUniqueName.Text);
                        ImageUniqueName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + imgExt;

                        if (Convert.ToBoolean(AlbumDetails.Rows[0]["IsRoot"]) == true)
                        {
                            previewImgPath = Server.MapPath("~/Upload/MasterGallery/") + ProfileID + "/" + lblImageUniqueName.Text.Trim();
                            copyImgPath = Server.MapPath("~/Upload/AppGallery/") + ProfileID + "/" + ImageUniqueName;
                        }
                        else
                        {
                            previewImgPath = Server.MapPath("~/Upload/MasterGallery/") + ProfileID + "/" + AlbumDetails.Rows[0]["Album_Unique_name"].ToString() + "/" + lblImageUniqueName.Text.Trim();
                            copyImgPath = Server.MapPath("~/Upload/AppGallery/") + ProfileID + "/" + ImageUniqueName;
                        }


                        //

                        // Now Selected Image Copy to App Gallery 
                        try
                        {
                            if (File.Exists(previewImgPath))
                            {
                                File.Copy(previewImgPath, copyImgPath);
                            }

                            dtActiveAlbums = objBusinessBLL.GetActiveAlbumsByGalleryType(ProfileID, ImageGalleryTypes.AppGalleryType.ToString());
                            int copyAlbumID = 0;
                            if (dtActiveAlbums.Rows.Count > 0)
                            {
                                copyAlbumID = Convert.ToInt32(dtActiveAlbums.Rows[0]["Album_ID"]);
                            }
                            objBusinessBLL.InsertGalleryImages(imgTitle, ImageUniqueName, "", copyAlbumID, 0, C_UserID);

                            LoadAlbumDetails();
                            hdnOpenMasterWindow.Value = "";

                            //GC.Collect();
                        }

                        catch (Exception /*ex*/)
                        {

                        }

                        break;
                    }
                }// END loop

                rbSystem.Checked = true;
                rbMasterGallery.Checked = false;
                lblMessage.Text = "<font color=green face=arial size=2>Your image has uploaded successfully.</font>";
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppGallery.aspx.cs", "btnSubmit_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }




    }
}