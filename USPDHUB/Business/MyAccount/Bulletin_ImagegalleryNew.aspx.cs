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
    public partial class Bulletin_ImagegalleryNew : BaseWeb
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
                objInBuiltData.ErrorHandling("LOG", "ContentGallery.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

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
                ////lblTitle.Text = titleName;
                lblMessage.Text = "";



                if (Request.QueryString["fitblockwidth"] != null)
                    Session["fitblockwidth"] = Request.QueryString["fitblockwidth"];
                if (Request.QueryString["imgSrc"] != null)
                    Session["imgSrc"] = Request.QueryString["imgSrc"];

                if (!IsPostBack)
                {
                    //Img SrC
                    if (Session["imgSrc"] != null)
                    {
                        if (Session["imgSrc"].ToString() != "")
                        {
                            string regUrl = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
                            string currentLoadImgUrl = string.Empty;
                            Regex r = new Regex(regUrl);
                            MatchCollection results = r.Matches(Session["imgSrc"].ToString());
                            foreach (Match m in results)
                            {
                                if (m.Value.Contains("Bulletins") == false)
                                {
                                    if (m.Value.Contains("Upload/Logos") == false)
                                    {
                                        txtwebaddress.Text = m.Value.ToString();
                                    }
                                }
                            }

                            Regex regex = new Regex("(?<first><img[\\s\\w]+?.*?src=[\"|'])(?<link>.*?)(?<last>[\"|'].*?[/]?>)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
                            Regex reSrc = new Regex(@"src=(?:(['""])(?<src>(?:(?!\1).)*)\1|(?<src>[^\s>]+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                            MatchCollection results1 = regex.Matches(Session["imgSrc"].ToString());
                            foreach (Match m1 in results1)
                            {
                                Match mSrc = reSrc.Match(m1.Value);
                                currentLoadImgUrl = mSrc.Value.ToString();
                                currentLoadImgUrl = currentLoadImgUrl.Replace("src=", "");
                                currentLoadImgUrl = currentLoadImgUrl.Replace("SRC=", "");
                                currentLoadImgUrl = currentLoadImgUrl.Replace("\"", "");
                                break;
                            }
                            ShowPanel("2", currentLoadImgUrl); Session["imgSrc"] = null;
                        }
                        else
                        {
                            ShowPanel("1", "");

                        }
                    }
                    else
                    {
                        ShowPanel("1", "");

                    }
                }

                if (hdnOpenMasterWindow.Value == "1")
                {
                    modalWindowMasterGallery.Show();
                }
                else
                {
                    modalWindowMasterGallery.Hide();
                }


            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "Page_Load - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "Page_Load - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void LoadAlbumDetails()
        {
            try
            {
                dtActiveAlbums = objBusinessBLL.GetActiveAlbumsByGalleryType(ProfileID, ImageGalleryTypes.ContentGalleryType.ToString());

                if (dtActiveAlbums.Rows.Count > 0)
                {
                    hdnAlbumID.Value = dtActiveAlbums.Rows[0]["Album_ID"].ToString();
                    LoadGalleryImages();

                }
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "LoadAlbumDetails - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "LoadAlbumDetails - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "LoadAlbumDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public void LoadGalleryImages()
        {
            try
            {
                if (hdnUploadingType.Value == "Drop")
                { Thread.Sleep(1000 * 2); hdnUploadingType.Value = ""; }

                dtGalleryImages = objBusinessBLL.GetGalleryImagesByAlbumID(Convert.ToInt32(hdnAlbumID.Value));
                // Bind Images
                dtlistImages.DataSource = dtGalleryImages;
                dtlistImages.DataBind();

                if (dtGalleryImages.Rows.Count > 0)
                {
                    btnDeleteImages.Visible = true;
                }
                else
                {
                    btnDeleteImages.Visible = false;
                }
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "LoadGalleryImages - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "LoadGalleryImages - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "LoadGalleryImages", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>displaypanel();</script>", false);

        }

        protected void dtlistImages_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                ImageButton ImgUserImg = e.Item.FindControl("ImgUserImg") as ImageButton;
                Label imgpreview = e.Item.FindControl("imgpreview") as Label;
                //Label lblAlbumUniqueName = e.Item.FindControl("lblImageUniqueName") as Label;


                string previewImgPath = RootPath + "/Upload/ContentGallery/" + ProfileID + "/" + imgpreview.Text.Trim() + "?id=" + Guid.NewGuid();
                ImgUserImg.ImageUrl = previewImgPath;

                /*
            
                imgpreview.Text = "";
                imgpreview.Text = "<a href=" + previewImgPath + " ><IMG border='0' width='150px' height='150px' src=" + previewImgPath + " /></a>";

                */
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "dtlistImages_ItemDataBound - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "dtlistImages_ItemDataBound - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "dtlistImages_ItemDataBound", ex.Message,
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
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnUpload1_OnClick - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnUpload1_OnClick - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnUpload1_OnClick", ex.Message,
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

                                string RootFolder = "";
                                RootFolder = Server.MapPath("~/Upload/ContentGallery/") + ProfileID;
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
                                    Convert.ToInt32(0), C_UserID);


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

                                LoadGalleryImages();
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
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "FromSystemImageUploading - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "FromSystemImageUploading - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "FromSystemImageUploading", ex.Message,
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



        protected void btnCropCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeleteImages_OnClick(object sender, EventArgs e)
        {
            try
            {
                foreach (DataListItem listItem in dtlistImages.Items)
                {
                    CheckBox chkBox = (CheckBox)listItem.FindControl("chk");
                    Label lblImgID = (Label)listItem.FindControl("lblImgID");
                    Label lblImageUniqueName = (Label)listItem.FindControl("lblImageUniqueName");

                    if (chkBox.Checked)
                    {
                        string RootFolder = "";

                        RootFolder = Server.MapPath("~/Upload/ContentGallery/") + ProfileID;

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
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnDeleteImages_OnClick - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnDeleteImages_OnClick - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ContentGallery.aspx.cs", "btnDeleteImages_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }


        #endregion

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

                if (imgPath.Contains("?"))
                {
                    imgPath = imgPath.Substring(0, imgPath.LastIndexOf("?"));
                }
                string SaveImgLocation = newImgfolderLocation + "\\" + imgPath;

                if (!Directory.Exists(newImgfolderLocation))
                {
                    Directory.CreateDirectory(newImgfolderLocation);
                }

                if (oldImgLocation.Contains("?"))
                {
                    oldImgLocation = oldImgLocation.Substring(0, oldImgLocation.LastIndexOf("?"));
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
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ImageResize - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ImageResize - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ImageResize", ex.Message,
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
                        previewImgPath = RootPath + "/Upload/ContentGallery/" + ProfileID + "/" + lblImageUniqueName.Text.Trim();

                        break;
                    }
                }
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "GetSelectedImageID - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "GetSelectedImageID - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "GetSelectedImageID", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

            return imgID;
        }

        private void ClearCaches()
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
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ClearCaches - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ClearCaches - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ClearCaches", ex.Message,
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
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnMasterGallery_OnClick - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnMasterGallery_OnClick - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnMasterGallery_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void ImgCloseMasterGalleryWindow_OnClick(object sender, EventArgs e)
        {
            try
            {
                hdnOpenMasterWindow.Value = "";
                modalWindowMasterGallery.Hide();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>displaypanel();</script>", false);
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ImgCloseMasterGalleryWindow_OnClick - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ImgCloseMasterGalleryWindow_OnClick - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ImgCloseMasterGalleryWindow_OnClick", ex.Message,
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
                            copyImgPath = Server.MapPath("~/Upload/ContentGallery/") + ProfileID + "/" + ImageUniqueName;
                        }
                        else
                        {
                            previewImgPath = Server.MapPath("~/Upload/MasterGallery/") + ProfileID + "/" + AlbumDetails.Rows[0]["Album_Unique_name"].ToString() + "/" + lblImageUniqueName.Text.Trim();
                            copyImgPath = Server.MapPath("~/Upload/ContentGallery/") + ProfileID + "/" + ImageUniqueName;
                        }
                        break;
                    }
                }

                // Now Selected Image Copy to App Gallery 
                try
                {
                    if (File.Exists(previewImgPath))
                    {
                        File.Copy(previewImgPath, copyImgPath);
                    }

                    dtActiveAlbums = objBusinessBLL.GetActiveAlbumsByGalleryType(ProfileID, ImageGalleryTypes.ContentGalleryType.ToString());
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
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnSubmit_OnClick - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnSubmit_OnClick - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnSubmit_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnOpenMasterGalleryWindow_OnClick(object sender, EventArgs e)
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
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnOpenMasterGalleryWindow_OnClick - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnOpenMasterGalleryWindow_OnClick - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnOpenMasterGalleryWindow_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void ImgUserImg_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton imgResizeButton = sender as ImageButton;
                ShowPanel("2", imgResizeButton.ImageUrl);
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ImgUserImg_Click - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ImgUserImg_Click - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ImgUserImg_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public void ShowPanel(string pType, string pImageUrl)
        {
            // Show All Images Panel
            try
            {
                if (pType == "1")
                {
                    Session["imgSrc"] = "";
                    pnlImages.Visible = true;
                    pnlImgResize.Visible = false;

                    LoadAlbumDetails();

                } // Image Crop Window
                else if (pType == "2")
                {
                    pnlImages.Visible = false;
                    pnlImgResize.Visible = true;
                    hdnImgURL.Value = pImageUrl;

                    // Original Image Folder & Image Names
                    string imgUniqueName = Path.GetFileName(pImageUrl);
                    imgUniqueName = RemoveQuestionMark(imgUniqueName);
                    Session["OriginalImgName"] = imgUniqueName;


                    string oldImgVirtualPath = "";
                    // Image Edit Mode Getting IMGSRC from Edit Block
                    if (!pImageUrl.ToString().Contains("TempContentGalleryWorks"))
                    {
                        oldImgVirtualPath = Server.MapPath("~/Upload/ContentGallery/") + ProfileID + "\\" + imgUniqueName;
                    }
                    else
                    {
                        oldImgVirtualPath = Server.MapPath("~/Upload/TempContentGalleryWorks/") + ProfileID + "\\" + imgUniqueName;
                    }


                    // System Resize Image Resulation like 300x300px
                    string SystemResizeImgFolder = Server.MapPath("/Upload/TempContentGallery/") + ProfileID;
                    string SystemResizeImgName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + Path.GetExtension(imgUniqueName);
                    SystemResizeImgName = RemoveQuestionMark(SystemResizeImgName);
                    Session["SystemResizeImgName"] = SystemResizeImgName;

                    int ImgHeight = 0;
                    int imgWidth = 0;
                    using (FileStream fs = new FileStream(oldImgVirtualPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                        imgWidth = image.Width;
                        ImgHeight = image.Height;
                    }
                    // Based on Block Width Resize 
                    if (imgWidth > Convert.ToInt32(Session["fitblockwidth"]))
                    {
                        ImageResize(SystemResizeImgFolder, SystemResizeImgName, Convert.ToInt32(Session["fitblockwidth"]), 0, oldImgVirtualPath);
                    }
                    else
                    {
                        ImageResize(SystemResizeImgFolder, SystemResizeImgName, imgWidth, ImgHeight, oldImgVirtualPath);
                    }

                    // Display orginal Image for User Crop
                    lblimgMain.Text = "<IMG id='imgMain'  src=" + pImageUrl + " />";

                    // System Resize Image
                    string newImgRootPath = RootPath + "/Upload/TempContentGallery/" + ProfileID + "/" + SystemResizeImgName + "?id=" + Guid.NewGuid();
                    lblTempShortImg.Text = "<IMG src=" + newImgRootPath + " />";


                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>LoadImgSettings('" + Session["fitblockwidth"].ToString() + "','" + ImgHeight + "');</script>", false);

                }
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ShowPanel - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ShowPanel - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "ShowPanel", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        // Back Image Gallery
        protected void btnImageGallery_OnClick(object sender, EventArgs e)
        {
            try
            {
                ShowPanel("1", "");
                hdbTempShortLogoURL.Value = "";
                hdnImgURL.Value = "";
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnImageGallery_OnClick - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnImageGallery_OnClick - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnImageGallery_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnCropLogo_OnClick(object sender, EventArgs e)
        {
            try
            {

                string saveRootFolder = "";
                string saveImgName = "";
                string saveImgPath = "";

                saveRootFolder = Server.MapPath("~/Upload/TempContentGalleryWorks/") + ProfileID;
                if (!Directory.Exists(saveRootFolder))
                {
                    Directory.CreateDirectory(saveRootFolder);
                }

                if (rbSystemResizeLogo.Checked)
                {
                    // Copy new Img from Previous System Resize image 
                    string SystemResizeImgName = Session["SystemResizeImgName"].ToString();
                    SystemResizeImgName = RemoveQuestionMark(SystemResizeImgName);
                    string SystemResizeRootFolder = Server.MapPath("/Upload/TempContentGallery/") + ProfileID;
                    string systemResizeImgPath = SystemResizeRootFolder + "\\" + SystemResizeImgName;

                    saveImgName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + Path.GetExtension(SystemResizeImgName);
                    saveImgPath = saveRootFolder + "\\" + saveImgName;
                    File.Copy(systemResizeImgPath, saveImgPath, true);

                    hdnResizeImageValue.Value = RootPath + "/Upload/TempContentGalleryWorks/" + ProfileID + "/" + saveImgName;
                }
                else
                {
                    string OriginalRootFolder = "";
                    if (!lblimgMain.Text.ToString().Contains("TempContentGalleryWorks"))
                    {
                        OriginalRootFolder = Server.MapPath("~/Upload/ContentGallery/") + ProfileID;
                    }
                    else
                    {
                        OriginalRootFolder = Server.MapPath("~/Upload/TempContentGalleryWorks/") + ProfileID;
                    }

                    string OriginalImgName = Session["OriginalImgName"].ToString();
                    OriginalImgName = RemoveQuestionMark(OriginalImgName);
                    string originalImgPath = OriginalRootFolder + "\\" + OriginalImgName;


                    // Crop Img from Orginal Image
                    using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(originalImgPath)))
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

                                ClearCaches();

                                // Display Image to Selected Block generate duplicate img
                                saveImgName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + Path.GetExtension(OriginalImgName);
                                saveImgPath = saveRootFolder + "\\" + saveImgName;
                                if (File.Exists(saveImgPath))
                                {
                                    File.Delete(saveImgPath);
                                }
                                bitMap.Save(saveImgPath);
                                hdnResizeImageValue.Value = RootPath + "/Upload/TempContentGalleryWorks/" + ProfileID + "/" + saveImgName;


                            }// third using
                        }// Scond Using
                    } // Frist Using

                } //end else

                Session["imgSrc"] = null;
                txtimagname.Text = "";

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>ImageAddtoBlock();</script>", false);

            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnCropLogo_OnClick - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnCropLogo_OnClick - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "btnCropLogo_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string RemoveQuestionMark(string inputString)
        {
            try
            {
                if (inputString.Contains("?"))
                {
                    inputString = inputString.Substring(0, inputString.LastIndexOf("?"));
                }
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "RemoveQuestionMark - timeout is only caught by HttpException.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (HttpException ex)
            {
                // What can we check to know if this is a timeout exception?
                // if (ex == TimeOutError)
                // {
                //      return "Took too long. Please upload a smaller image.";
                // }
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "RemoveQuestionMark - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Bulletin_ImagegalleryNew.aspx.cs", "RemoveQuestionMark", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

            return inputString;
        }

    }
}