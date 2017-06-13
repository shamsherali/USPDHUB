using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using USPDHUBBLL;
using Aurigma.GraphicsMill.Transforms;
using Aurigma.GraphicsMill.Codecs;
using Aurigma.GraphicsMill;
using System.Web;

namespace USPDHUB.Business.MyAccount
{
    public partial class ImageGallery : System.Web.UI.Page
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public int C_UserID = 0;
        public string TempFolderPath = string.Empty;
        public string TempSesPath = string.Empty;
        public string FolderName = "Templates";
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public string RootPath = "";
        CommonBLL objCommonBLL = new CommonBLL();
        public string ImageVirtualPath = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["UserID"]) == "" || Session["VerticalDomain"] == null)
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Login.aspx?sflag=1"));
                }
                // *** Get Domain Name *** // 
                RootPath = Session["RootPath"].ToString();

                if (Session["ProfileID"] == null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Javascript", "CloseModalPopup()", true);
                }
                else
                {
                    if (Session["ProfileID"].ToString() != "")
                    {
                        ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                        TempSesPath = ProfileID.ToString();
                    }
                    if (Session["TemplateName"] != null && Convert.ToString(Session["TemplateName"]) != "")
                    {
                        TempSesPath = Session["TemplateName"].ToString();
                        TempSesPath = TempSesPath.Replace(" ", "");
                        if (TempSesPath.EndsWith("."))
                        {
                            TempSesPath = TempSesPath.Remove(TempSesPath.Length - 1);
                        }
                    }

                }
                UserID = Convert.ToInt32(Session["UserID"]);
                C_UserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                if (!IsPostBack)
                {
                    pnlallimage.Visible = true;
                    GetBulletinImages();
                    if (Request.QueryString["TipsimgName"] != null)
                    {
                        Session["ImgName"] = Request.QueryString["TipsimgName"];
                        string imgName = Session["ImgName"].ToString();
                        imgName = Path.GetFileNameWithoutExtension(imgName);
                        txtimagname.Text = imgName;
                        Session["ImageVirtualPath"] = ConfigurationManager.AppSettings.Get("AppContactUsPhotosFolderName") + "\\DevicePhotos\\" + ProfileID + "\\";
                        
                    }
                    if (Request.QueryString["SmartConnectimgName"] != null)
                    {
                        Session["ImgName"] = Request.QueryString["SmartConnectimgName"];
                        string imgName = Session["ImgName"].ToString();
                        imgName = Path.GetFileNameWithoutExtension(imgName);
                        txtimagname.Text = imgName;
                        Session["ImageVirtualPath"] = ConfigurationManager.AppSettings.Get("AppContactUsPhotosFolderName") + "\\PublicCallDirectoryTapImages\\" + ProfileID + "\\";
                    }
                    if (Request.QueryString["PSCimgName"] != null)
                    {
                        Session["ImgName"] = Request.QueryString["PSCimgName"];
                        string imgName = Session["ImgName"].ToString();
                        imgName = Path.GetFileNameWithoutExtension(imgName);
                        txtimagname.Text = imgName;
                        Session["ImageVirtualPath"] = ConfigurationManager.AppSettings.Get("AppContactUsPhotosFolderName") + "\\PrivateSmartConnectTapImages\\" + ProfileID + "\\";
                    }
                  
                   

                }
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "Page_Load - timeout is only caught by HttpException.", ex.Message,
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
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "Page_Load - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        public void GetBulletinImages()
        {
            try
            {
                //User Images Path
                string bulletinImagesPath = Server.MapPath("~") + "/Upload/Common/" + ProfileID.ToString();
                if (!Directory.Exists(bulletinImagesPath))
                {
                    Directory.CreateDirectory(bulletinImagesPath);
                }
                DataTable dtImages = objCommonBLL.GetUserProfileImages(ProfileID, txtSearch.Text.Trim());
                DListBulletinImages.DataSource = dtImages;
                DListBulletinImages.DataBind();
                cbSelectAll.Checked = false;
                if (dtImages.Rows.Count > 0)
                {
                    cbSelectAll.Visible = true;
                }
                else
                {
                    cbSelectAll.Visible = false;
                    if (txtSearch.Text.Trim() == "")
                        pnlSelectSearch.Visible = false;
                }
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "GetBulletinImages - timeout is only caught by HttpException.", ex.Message,
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
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "GetBulletinImages - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "GetBulletinImages", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void DeleteBulletinImages()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "Imagegallery.aspx.cs", "DeleteBulletinImages", string.Empty, string.Empty, string.Empty, string.Empty);

                if (File.Exists(Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString()))
                {
                    string[] allImages = Directory.GetFiles(Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString());
                    string currentDate = DateTime.Now.ToShortDateString();
                    foreach (string fileName in allImages)
                    {
                        string imgCreatedDate = File.GetCreationTime(fileName).ToShortDateString();
                        TimeSpan ts = Convert.ToDateTime(currentDate) - Convert.ToDateTime(imgCreatedDate);
                        int dateDiff = ts.Days;
                        if (dateDiff > 180)
                        {
                            GC.Collect();
                            File.Delete(fileName);
                            GC.Collect();
                        }
                    }
                }

                cbSelectAll.Checked = false;
                Response.Clear();
                Response.ClearContent();
                Response.Clear();
                Response.Cache.SetExpires(DateTime.Now);
                GC.Collect();
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "DeleteBulletinImages - timeout is only caught by HttpException.", ex.Message,
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
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "DeleteBulletinImages - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "DeleteBulletinImages", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                // Copy Tips Images from Mobile App Alerts . that Page pass param modulename as 'mobileappalerts'
                if (Session["imgName"] != null)
                {
                    // Mobile App Alerts -- Tips Images
                    var TipsImageVirtualPath = Session["ImageVirtualPath"] + Session["imgName"].ToString().Trim();

                    string imgExt = Path.GetExtension(Session["imgName"].ToString());

                    string imagename = txtimagname.Text.Trim() + imgExt;
                    var NewImagePath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString();
                    string saveimagepath = NewImagePath + "\\" + imagename;

                    try
                    {
                        imagename = GetUserProfileImageName(txtimagname.Text.Trim(), imgExt);
                        if (!Directory.Exists(NewImagePath))
                            Directory.CreateDirectory(NewImagePath);
                        saveimagepath = NewImagePath + "\\" + imagename;
                        File.Copy(TipsImageVirtualPath, saveimagepath, true);
                        System.Drawing.Image imgname = System.Drawing.Image.FromFile(saveimagepath);
                        objCommonBLL.InsertUserProfileImage(ProfileID, UserID, C_UserID, imagename, txtimagname.Text, imgname.Width.ToString() + " x " + imgname.Height.ToString());
                        string newImg = NewImagePath + "/" + Path.GetFileNameWithoutExtension(saveimagepath) + "_thumb" + Path.GetExtension(saveimagepath);
                        using (var reader = ImageReader.Create(saveimagepath))
                        using (var resize = new Resize(100, 100, ResizeInterpolationMode.High, ResizeMode.Fit))
                        using (var writer = ImageWriter.Create(newImg))
                        {
                            Pipeline.Run(reader + resize + writer);
                        }
                    }
                    catch (Exception ex)
                    
                    
                    {//Error 
                        objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "BtnUpload_Click1", ex.Message,
                        Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                    }

                    GetBulletinImages();
                    System.Threading.Thread.Sleep(8000);
                    lblerrormsg.Text = "<font color='green' face=arial size=3>Your image has been uploaded successfully.</font>";
                    txtimagname.Text = "";
                    GC.Collect();
                }

                if (FUUserImages.HasFile && Session["imgName"] == null)
                {
                    string imageExtension = string.Empty;
                    string imagename = txtimagname.Text;
                    //imagename = imagename.Replace(" ", "");
                    imageExtension = Path.GetExtension(FUUserImages.FileName);
                    if (imageExtension == ".jpg" || imageExtension == ".JPG" || imageExtension == ".JPEG" || imageExtension == ".jpeg" || imageExtension == ".GIF" || imageExtension == ".gif" || imageExtension == ".png" || imageExtension == ".PNG")
                    {
                        string imagepath = string.Empty;
                        string saveimagepath = string.Empty;
                        if (Session["ProfileID"] != null)
                        {
                            if (Session["ProfileID"].ToString() != "")
                            {
                                imagename = GetUserProfileImageName(imagename, imageExtension);
                                imagepath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString();
                                if (!Directory.Exists(imagepath))
                                    Directory.CreateDirectory(imagepath);

                                saveimagepath = imagepath + "\\" + imagename;
                                objCommonBLL.GetImageRotateFlip(FUUserImages, saveimagepath, true);
                                System.Drawing.Image imgname = System.Drawing.Image.FromFile(saveimagepath);
                                objCommonBLL.InsertUserProfileImage(ProfileID, UserID, C_UserID, imagename, txtimagname.Text, imgname.Width.ToString() + " x " + imgname.Height.ToString());
                                string newImg = imagepath + "/" + Path.GetFileNameWithoutExtension(saveimagepath) + "_thumb" + Path.GetExtension(saveimagepath);
                                using (var reader = ImageReader.Create(saveimagepath))
                                using (var resize = new Resize(100, 100, ResizeInterpolationMode.High, ResizeMode.Fit))
                                using (var writer = ImageWriter.Create(newImg))
                                {
                                    Pipeline.Run(reader + resize + writer);
                                }
                            }
                        }
                        System.Threading.Thread.Sleep(8000);
                        lblerrormsg.Text = "<font color='green' face=arial size=3>Your image has been uploaded successfully.</font>";
                        txtimagname.Text = "";
                    }
                    else
                    {
                        if (Session["imgName"] == null)
                            lblerrormsg.Text = "<font color='red'>Your image is not in the correct file format; please use .jpeg,.jpg,.gif or .png only.</font>";
                    }
                }
                else
                {
                    if (Session["imgName"] == null)
                        lblerrormsg.Text = "<font color='red'>Please select a file to upload.</font>";
                }
                Session["imgName"] = null;
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "BtnUpload_Click - timeout is only caught by HttpException.", ex.Message,
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
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "BtnUpload_Click - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "BtnUpload_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                GetBulletinImages();
            }
        }
        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lblerrormsg.Text = "";
                GetBulletinImages();
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "lnkSearch_Click - timeout is only caught by HttpException.", ex.Message,
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
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "lnkSearch_Click - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "lnkSearch_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkClear_Click(object sender, EventArgs e)
        {
            try
            {
                lblerrormsg.Text = "";
                txtSearch.Text = "";
                GetBulletinImages();
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "lnkClear_Click - timeout is only caught by HttpException.", ex.Message,
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
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "lnkClear_Click - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "lnkClear_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private string GetUserProfileImageName(string imagename, string imageExtension)
        {
            try
            {
                bool isAvailable = false;
                isAvailable = objCommonBLL.CheckUserProfileImage(ProfileID, imagename + imageExtension);
                if (!isAvailable)
                    GetUserProfileImageName(imagename + "_1", imageExtension);
                
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "GetUserProfileImageName - timeout is only caught by HttpException.", ex.Message,
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
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "GetUserProfileImageName - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "GetUserProfileImageName", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return (imagename + imageExtension);
        }
        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = "";
                //Log
                objInBuiltData.ErrorHandling("LOG", "Imagegallery.aspx.cs", "lnkDelete_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                GC.Collect();
                Response.Clear();
                Response.ClearContent();
                Response.Clear();
                Response.Cache.SetExpires(DateTime.Now);
                for (int i = 0; i < DListBulletinImages.Items.Count; i++)
                {
                    CheckBox chkImage = DListBulletinImages.Items[i].FindControl("ChekImage") as CheckBox;
                    if (chkImage.Checked == true)
                    {
                        Image imgChecked = DListBulletinImages.Items[i].FindControl("ImgUserImg") as Image;
                        Label lblImageId = DListBulletinImages.Items[i].FindControl("lblImageId") as Label;
                        string deleteImagePath = string.Empty;
                        string thumbPath = string.Empty;
                        thumbPath = Path.GetFileName(imgChecked.ImageUrl);
                        int length = thumbPath.LastIndexOf('_');
                        if (length > 0)
                            deleteImagePath = thumbPath.Substring(0, length) + Path.GetExtension(thumbPath);
                        deleteImagePath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString() + "\\" + deleteImagePath;
                        if (File.Exists(deleteImagePath))
                        {
                            File.Delete(deleteImagePath);
                            objCommonBLL.DeleteUserProfileImage(Convert.ToInt32(lblImageId.Text), C_UserID);
                        }
                        thumbPath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString() + "\\" + thumbPath;
                        if (File.Exists(thumbPath))
                            File.Delete(thumbPath);
                        Response.Clear();
                        Response.ClearContent();
                        Response.Clear();
                        Response.Cache.SetExpires(DateTime.Now);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
                lblerrormsg.Text = "<font color=red face=arial size=2><b>The selected image(s) were deleted successfully.</b></font>";
                Response.Clear();
                Response.ClearContent();
                Response.Clear();
                Response.Cache.SetExpires(DateTime.Now);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GetBulletinImages();
            }
            catch (TimeoutException ex)
            {
                // Timeout doesn't get caught. Must be a different type of timeout.
                // So far, timeout is only caught by HttpException.
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "lnkDelete_Click - timeout is only caught by HttpException.", ex.Message,
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
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "lnkDelete_Click - Took too long. Please upload a smaller image.", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
           
            catch (Exception ex)
            {
                lblerrormsg.Text = "<font color=red face=arial size=2><b>We have encountered a problem while deleting your image(s). Please try again after some time.</b></font>";
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Imagegallery.aspx.cs", "lnkDelete_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}