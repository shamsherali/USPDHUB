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
    public partial class MasterGallery : BaseWeb
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
                objInBuiltData.ErrorHandling("LOG", "MasterGallery.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

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
                //titleName = objApp.GetMobileAppSettingTabName(UserID, "Gallery", DomainName);
                //lblTitle.Text = titleName;
                lblMessage.Text = "";

                if (!IsPostBack)
                {
                    LoadAlbumDetails();
                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MasterGallery.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public void LoadAlbumDetails()
        {
            try
            {
                dtActiveAlbums = objBusinessBLL.GetActiveAlbumsByGalleryType(ProfileID, ImageGalleryTypes.MasterGalleryType.ToString());

                // Add Root (Main Parent Folder)

                AddNodes(TVAlbums.Nodes, "True", dtActiveAlbums);
                if (TVAlbums.Nodes.Count > 0)
                {
                    // Child Nodes
                    AddNodes(TVAlbums.Nodes[0].ChildNodes, "False", dtActiveAlbums);
                }

                TVAlbums.ExpandAll();
                if (TVAlbums.Nodes.Count > 0)
                {
                    if (hdnAlbumID.Value == "0")
                    {
                        TVAlbums.Nodes[0].Select();

                        TreeNode item = TVAlbums.Nodes[0];
                        hdnAlbumID.Value = item.Value;
                        Session["SelectedNode"] = item.ValuePath;
                        hdnAlbumUniqueName.Value = ReplaceSpecialCharacters(item.Text);
                        hdnIsParent.Value = "1";
                    }
                    else
                    {
                        if (Session["SelectedNode"] != null)
                        {
                            TreeNode node = TVAlbums.FindNode(Session["SelectedNode"].ToString());
                            //node.Selected = true;
                        }
                    }
                    LoadGalleryImages();


                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MasterGallery.aspx.cs", "LoadAlbumDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void AddNodes(TreeNodeCollection nodes, string level, System.Data.DataTable dt)
        {
            try
            {
                nodes.Clear();
                string filterExp = string.Format("IsRoot='{0}'", level);
                foreach (System.Data.DataRow r in dt.Select(filterExp))
                {
                    TreeNode item = new TreeNode()
                    {
                        Text = r["Album_Name"].ToString(),
                        Value = r["Album_ID"].ToString(),

                    };
                    //this.AddNodes(item.ChildNodes, int.Parse(r[0].ToString()), dt);
                    //item. = TVAlbums.Nodes[0] as TreeNode;
                    nodes.Add(item);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MasterGallery.aspx.cs", "AddNodes", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void TVAlbums_OnSelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                var item = TVAlbums.SelectedNode;
                if (item != null)
                {
                    Session["SelectedNode"] = item.ValuePath;
                    hdnAlbumID.Value = item.Value;
                    hdnAlbumUniqueName.Value = ReplaceSpecialCharacters(item.Text);

                    if (item.Parent == null)
                    {
                        // This is parent (Root) 
                        hdnIsParent.Value = "1";
                        btnDeleteAlbum.Visible = false;
                    }
                    else
                    {
                        btnDeleteAlbum.Visible = true;
                        hdnIsParent.Value = "2";
                        // Child Nodes
                    }
                    LoadGalleryImages();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MasterGallery.aspx.cs", "TVAlbums_OnSelectedNodeChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        private void LoadGalleryImages()
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

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>displaypanel()</script>", false);

                if (dtGalleryImages.Rows.Count > 0)
                {
                    btnDeleteImages.Visible = true;
                }
                else
                {
                    btnDeleteImages.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MasterGallery.aspx.cs", "LoadGalleryImages", ex.Message,
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
                if (hdnIsParent.Value == "1")
                {
                    previewImgPath = RootPath + "/Upload/MasterGallery/" + ProfileID + "/" + imgpreview.Text.Trim();
                }
                else if (hdnIsParent.Value == "2")
                {
                    previewImgPath = RootPath + "/Upload/MasterGallery/" + ProfileID + "/" + hdnAlbumUniqueName.Value.ToString() + "/" + imgpreview.Text.Trim();
                }

                imgpreview.Text = "";
                imgpreview.Text = "<a href=" + previewImgPath + " ><IMG border='0' width='150px' height='150px' src=" + previewImgPath + " /></a>";
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MasterGallery.aspx.cs", "dtlistImages_ItemDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnAlbumSubmit_OnClick(object sender, EventArgs e)
        {
            try
            {
                string AlbumName = txtAlbumName.Text.Trim();
                string AlbumUniqueName = ReplaceSpecialCharacters(AlbumName);

                string albumVirtualFolderPath = Server.MapPath("~/Upload/MasterGallery/") + ProfileID + "/" + AlbumUniqueName;
                if (Directory.Exists(albumVirtualFolderPath))
                {
                    lblMessage.Text = "<font color='red'>" + AlbumName + " album is already existed.</font>";
                }
                else
                {
                    ClearCaches();
                    Directory.CreateDirectory(albumVirtualFolderPath);
                    objBusinessBLL.Insert_Update_AlbumDetails(0, ProfileID, UserID, AlbumName, AlbumUniqueName, ImageGalleryTypes.MasterGalleryType.ToString());

                    lblMessage.Text = "<font color='green'>" + AlbumName + " album is created successfully.</font>";
                    LoadAlbumDetails();
                }

                txtAlbumName.Text = "";
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MasterGallery.aspx.cs", "btnAlbumSubmit_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnUpload1_OnClick(object sender, EventArgs e)
        {
            if (rbSingleUpload.Checked)
            {
                SingleImageUploading();
            }
            else
            {
                MultipleImagesUploading();
            }
        }

        private void SingleImageUploading()
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

                                string RootFolder = "";
                                if (hdnIsParent.Value == "1")
                                {
                                    RootFolder = Server.MapPath("~/Upload/MasterGallery/") + ProfileID;
                                }
                                else if (hdnIsParent.Value == "2")
                                {
                                    RootFolder = Server.MapPath("~/Upload/MasterGallery/") + ProfileID + "/" + hdnAlbumUniqueName.Value;
                                }

                                if (!Directory.Exists(RootFolder))
                                {
                                    Directory.CreateDirectory(RootFolder);
                                }

                                ImageName = txtimagname.Text.Trim();
                                ImageUniqueName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + imgExt;
                                Session["TempImageUniqueName"] = ImageUniqueName;
                                string imagePath = RootFolder + "//" + ImageUniqueName;
                                SingleFileUploadControl.SaveAs(imagePath);

                                objBusinessBLL.InsertGalleryImages(txtimagname.Text.Trim(), ImageUniqueName, "", Convert.ToInt32(hdnAlbumID.Value),
                                    0, C_UserID);

                                txtimagname.Text = "";
                                LoadGalleryImages();

                                lblMessage.Text = "<font color=green face=arial size=2>Your image is uploaded successfully.</font>";
                            }
                            else
                            {
                                lblMessage.Text = "<font color=red face=arial size=2>Your image is not in the correct file format.</font>";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "<font color=red face=arial size=2>Please select a image to upload.</font>";
                        }
                    }

                    else
                    {
                        lblMessage.Text = "<font color=red face=arial size=2>Please select a image to upload.</font>";
                    }
                }
                else
                {
                    LoadGalleryImages();
                    lblMessage.Text = "<font color=green face=arial size=2>Your image is uploaded successfully.</font>";
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MasterGallery.aspx.cs", "SingleFileUploading", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void MultipleImagesUploading()
        {
            try
            {
                if (hdnUploadingType.Value == "Browse")
                {
                    string RootFolder = "";
                    if (hdnIsParent.Value == "1")
                        RootFolder = Server.MapPath("~/Upload/MasterGallery/") + ProfileID;
                    else if (hdnIsParent.Value == "2")
                        RootFolder = Server.MapPath("~/Upload/MasterGallery/") + ProfileID + "\\" + hdnAlbumUniqueName.Value;

                    bool IsUpload = false;
                    HttpFileCollection filecolln = Request.Files;
                    for (int i = 0; i < filecolln.Count; i++)
                    {
                        HttpPostedFile file = filecolln[i];
                        if (file.ContentLength > 0)
                        {
                            IsUpload = true;
                            break;
                        }
                    }

                    var TotalFilesCount = 0;
                    var TotalFileSize = 0;
                    for (int i = 0; i < filecolln.Count; i++)
                    {
                        HttpPostedFile file = filecolln[i];
                        if (file.ContentLength > 0)
                        {
                            TotalFilesCount++;
                            TotalFileSize = TotalFileSize + file.ContentLength;
                        }
                    }

                    var Size_MB = (TotalFileSize / 1024) / 1024;


                    if (IsUpload == false)
                    {
                        lblMessage.Text = "<font color=red face=arial size=2>Please select a images to upload.</font>";
                    }
                    else if (TotalFilesCount > Int32.Parse(ConfigurationManager.AppSettings.Get("UploadMaxGalleryImagesCount")))
                    {
                        lblMessage.Text = "<font color=red face=arial size=2>You can upload max 10 files or 10 MB size files at time.</font>";
                    }
                    else if (Size_MB > Int32.Parse(ConfigurationManager.AppSettings.Get("UploadMaxGalleryImagesSize")))
                    {
                        lblMessage.Text = "<font color=red face=arial size=2>You can upload max 10 files or 10 MB size files at time.</font>";
                    }
                    else
                    {
                        for (int i = 0; i < filecolln.Count; i++)
                        {
                            HttpPostedFile file = filecolln[i];
                            if (file.ContentLength > 0)
                            {
                                ImageName = Path.GetFileName(file.FileName);
                                imgExt = Path.GetExtension(ImageName);
                                ImageUniqueName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + i.ToString() + imgExt;

                                string imagePath = RootFolder + "\\" + ImageUniqueName;
                                file.SaveAs(imagePath);

                                objBusinessBLL.InsertGalleryImages(ImageName, ImageUniqueName, "", Convert.ToInt32(hdnAlbumID.Value), 0, C_UserID);
                            }
                        }

                        LoadGalleryImages();
                        lblMessage.Text = "<font color=green face=arial size=2>Selected images are uploaded successfully.</font>";
                    }
                }
                else
                {
                    LoadAlbumDetails();
                    lblMessage.Text = "<font color=green face=arial size=2>Selected images are uploaded successfully.</font>";
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MasterGallery.aspx.cs", "MultipleImagesUploading", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>displaypanel()</script>", false);
        }

        protected void btnDeleteAlbum_OnClick(object sender, EventArgs e)
        {
            /*
            foreach (TreeNode node in TVAlbums.Nodes[0].ChildNodes)
            {
                if (node.Checked)
                {
                    int albumID = Convert.ToInt32(node.Value);
                    AlbumName = node.Text;
                    AlbumUniqueName = ReplaceSpecialCharacters(AlbumName);

                    // Delete from Folder
                    string albumVirtualFolderPath = Server.MapPath("~/Upload/MasterGallery/") + ProfileID + "/" + AlbumUniqueName;
                    if (Directory.Exists(albumVirtualFolderPath))
                    {
                        ClearCaches();
                        Directory.Delete(albumVirtualFolderPath, true);
                    }

                    // Delete from DB
                    objBusinessBLL.DeleteAlbum(albumID);
                }
            } // END foreach

            */

            if (hdnIsParent.Value == "1")
            {
                lblMessage.Text = "<font color='green'>You can't delete root album.</font>";
            }
            else
            {
                int albumID = Convert.ToInt32(hdnAlbumID.Value);
                AlbumUniqueName = hdnAlbumUniqueName.Value;

                // Delete from Folder
                string albumVirtualFolderPath = Server.MapPath("~/Upload/MasterGallery/") + ProfileID + "/" + AlbumUniqueName;
                if (Directory.Exists(albumVirtualFolderPath))
                {
                    ClearCaches();
                    Directory.Delete(albumVirtualFolderPath, true);
                }

                // Delete from DB
                objBusinessBLL.DeleteAlbum(albumID);

                hdnAlbumID.Value = "0";
                LoadAlbumDetails();

                btnDeleteAlbum.Visible = false;
            }
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
                if (hdnIsParent.Value == "1")
                    TempRootFolder = Server.MapPath("~/Upload/TempMasterGallery/") + ProfileID;
                else if (hdnIsParent.Value == "2")
                {
                    TempRootFolder = Server.MapPath("~/Upload/TempMasterGallery/") + ProfileID + "/" + hdnAlbumUniqueName.Value;
                }
                string tempImgPath = TempRootFolder + "\\" + Session["TempImageUniqueName"].ToString();



                string RootFolder = "";
                if (hdnIsParent.Value == "1")
                {
                    RootFolder = Server.MapPath("~/Upload/MasterGallery/") + ProfileID;
                }
                else if (hdnIsParent.Value == "2")
                {
                    RootFolder = Server.MapPath("~/Upload/MasterGallery/") + ProfileID + "/" + hdnAlbumUniqueName.Value;
                }

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


                objBusinessBLL.InsertGalleryImages(txtimagname.Text.Trim(), ImageUniqueName, "", Convert.ToInt32(hdnAlbumID.Value),
                    Convert.ToInt32(0), C_UserID);

                txtimagname.Text = "";

                //LoadAlbumDetails();

                LoadGalleryImages();

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MasterGallery.aspx.cs", "btnCropLogo_OnClick", ex.Message,
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
                        if (hdnIsParent.Value == "1")
                        {
                            RootFolder = Server.MapPath("~/Upload/MasterGallery/") + ProfileID;
                        }
                        else if (hdnIsParent.Value == "2")
                        {
                            RootFolder = Server.MapPath("~/Upload/MasterGallery/") + ProfileID + "/" + hdnAlbumUniqueName.Value;
                        }

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
                objInBuiltData.ErrorHandling("ERROR", "MasterGallery.aspx.cs", "btnDeleteImages_OnClick", ex.Message,
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
        }

        protected void btnEditImgCaption_OnClick(object sender, EventArgs e)
        {
            modalWidnowEditCaption.Show();
            btnEditImgCaption.CommandArgument = GetSelectedImageID();
        }

        protected void btnEditImgCaptionUpdate_OnClick(object sender, EventArgs e)
        {

            objBusinessBLL.Update_ImgOrderNo_ImgCaption(Convert.ToInt32(btnEditImgCaption.CommandArgument), 0, txtEditImageCaption.Text, "IMG_CAPTION");

            LoadGalleryImages();
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
                objInBuiltData.ErrorHandling("ERROR", "MasterGallery.aspx.cs", "ImageResize", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string GetSelectedImageID()
        {
            string imgID = "";
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
                    if (hdnIsParent.Value == "1")
                    {
                        previewImgPath = RootPath + "/Upload/MasterGallery/" + ProfileID + "/" + lblImageUniqueName.Text.Trim();
                    }
                    else if (hdnIsParent.Value == "2")
                    {
                        previewImgPath = RootPath + "/Upload/MasterGallery/" + ProfileID + "/" + hdnAlbumUniqueName.Value.ToString() + "/" + lblImageUniqueName.Text.Trim();
                    }

                    lblEditOrderNoImgPreview.Text = "";
                    lblEditOrderNoImgPreview.Text = "<IMG border='0' width='150px' height='150px' src=" + previewImgPath + " />";
                    txteditordernumber.Text = lblOrderNo.Text.Trim();

                    lblCaptionImgPreview.Text = "";
                    lblCaptionImgPreview.Text = "<IMG border='0' width='150px' height='150px' src=" + previewImgPath + " />";

                    txtEditImageCaption.Text = lblCaption.Text;
                    break;
                }
            }

            return imgID;
        }

        private void ClearCaches()
        {
            GC.Collect();
        }


    }
}