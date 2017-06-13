using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using USPDHUBBLL;
using System.Drawing;

public partial class Business_MyAccount_ModifyLogo : BaseWeb
{
    public int UserID = 0;
    public int ProfileID = 0;
    public string Browsername = string.Empty;
    public string Errormsg = string.Empty;
    public string Temp = string.Empty;
    public string Thumbimg = string.Empty;
    public string Wflag = string.Empty;
    DataTable dtobj = new DataTable();
    BusinessBLL busobj = new BusinessBLL();
    USPDHUBBLL.UtilitiesBLL utlObj = new USPDHUBBLL.UtilitiesBLL();
    public int CUserID = 0;
    public static bool IsResizeLogo = false;

    public static object Lock = new object();

    public DataTable Dtpermissions = new DataTable();
    AgencyBLL agencyobj = new AgencyBLL();
    public string PermissionType = string.Empty;
    public int PermissionValue = 0;
    public string RootPath = "";
    public string DomainName = "";
    public bool isShortLogo = false;

    CommonBLL objCommonBLL = new CommonBLL();
    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

    public bool IsLongLogo = false;

    # region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] == null)
                Response.Redirect(Page.ResolveClientUrl("~/login.aspx?sflag=1"));
            else
            {
                UserID = Convert.ToInt32(Session["UserID"]);
                if (Session["ProfileID"] != null)
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);

                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
            }
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            popnewsletterimage.Hide();

            IsLongLogo = objCommonBLL.IsPackageIncludeSetting(PackageIncludeSettingsAttributes.IsLongLogo);

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.ViewState.Clear();
            lblLogoMsg.Text = "";
            this.Server.ScriptTimeout = 3600;
            string wflag = string.Empty;
            // *** Make back button visible and disable by query string 26-03-2013 *** //
            if (!string.IsNullOrEmpty(Request.QueryString["App"] as string))
                btnBack.Visible = true;
            else
                btnBack.Visible = false;
            if (Request.QueryString["WFlag"] != null)
            {
                wflag = Request.QueryString["WFlag"];
                if (wflag.Length > 0)
                {
                    btnwizard.Visible = true;
                    btndashboard1.Visible = false;
                }
                else
                {
                    btnwizard.Visible = false;
                    btndashboard1.Visible = true;
                }
            }
            else
            {
                btnwizard.Visible = false;
                btndashboard1.Visible = true;
            }
            if (!IsPostBack)
            {
                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    hdnPermissionType.Value = objCommonBLL.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                }
                //ends here

                if (Request.Browser.Browser == "IE")
                {
                    Browsername = "IE";
                }
                else
                {
                    Browsername = "other";//like Firefox,Opera,Safari,Netscape Navigator Browsers.
                }
                btnLogoDelete.Visible = false;
                //deletelogohelp.Visible = false;
                LoadIntialMediaFiles();

            }
            if (Request.Browser.Browser == "IE")
            {
                Browsername = "IE";
            }
            else
            {
                Browsername = "other";//like Firefox,Opera,Safari,Netscape Navigator Browsers.
            }
            if (Session["LogoSuccess"] != null)
            {
                if (Session["LogoSuccess"].ToString() != "")
                {
                    lblLogoMsg.Text = "<font color=green face=arial size=2><b>" + Session["LogoSuccess"] + "</b></font>";
                    Session["LogoSuccess"] = null;
                }
            }

            if (Session["TempName"] == null)
            {
                Session["TempName"] = ProfileID;
            }
        }
        catch (TimeoutException ex)
        {
            // Timeout doesn't get caught. Must be a different type of timeout.
            // So far, timeout is only caught by HttpException.
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "Page_Load - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "Page_Load - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "Page_Load", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }

    # endregion

    # region Load Media Files
    private void LoadIntialMediaFiles()
    {
        try
        {

            string logourl = string.Empty;
            int logoProfileID = ProfileID; // *** Parent profileID *** //
            dtobj = busobj.GetProfileDetailsByProfileID(ProfileID);
            if (dtobj.Rows.Count == 1)
            {
                hdnIsLiteVersion.Value = Convert.ToString(dtobj.Rows[0]["IsLiteVersion"]);
                //if (!string.IsNullOrEmpty(dtobj.Rows[0]["Parent_ProfileID"].ToString()))
                //{
                //    hdnSubAcc.Value = "1";
                //    logoProfileID = Convert.ToInt32(dtobj.Rows[0]["Parent_ProfileID"].ToString());
                //    DataTable dtParent = busobj.GetProfileDetailsByProfileID(logoProfileID);
                //    if (dtParent.Rows.Count == 1)
                //    {
                //        if (dtParent.Rows[0]["Profile_logo_path"].ToString().Length > 0)
                //            logourl = dtParent.Rows[0]["Profile_logo_path"].ToString();
                //    }
                //}
                //else  if (dtobj.Rows[0]["Profile_logo_path"].ToString().Length > 0)
                if (dtobj.Rows[0]["Profile_logo_path"].ToString().Length > 0)
                    logourl = dtobj.Rows[0]["Profile_logo_path"].ToString();
                if (logourl.Length > 0)
                {
                    logo.Visible = true;

                    string originalfilename = logourl;
                    string extension = System.IO.Path.GetExtension(Server.MapPath(originalfilename));

                    string junk = ".";
                    string[] ret = originalfilename.Split(junk.ToCharArray());
                    string thumbimg1 = ret[0];
                    thumbimg1 = thumbimg1 + "_thumb" + extension;
                    string url = Server.MapPath("~") + "\\Upload\\Logos\\" + logoProfileID + "\\" + thumbimg1;
                    FileInfo obj = new FileInfo(url);
                    DeleteCache();

                    if (obj.Exists)
                    {
                        string imageDisID = Guid.NewGuid().ToString();
                        logo.ImageUrl = RootPath + "/Upload/Logos/" + logoProfileID + "/" + thumbimg1 + "?Guid=" + imageDisID;

                    }
                    else
                    {
                        string imageDisID = Guid.NewGuid().ToString();
                        logo.ImageUrl = RootPath + "/Upload/Logos/" + logoProfileID + "/" + logourl + "?Guid=" + imageDisID;

                    }
                    logoimage.Enabled = false;
                    BtnUpdateLogo.Enabled = false;
                    //if (ProfileID == logoProfileID)
                    btnLogoDelete.Visible = true;
                    pnlLogoUpload.Style["display"] = "none";
                    logo.Visible = true;
                    obj = null;
                }
                else
                {
                    if (Convert.ToBoolean(dtobj.Rows[0]["IsShortLogo"]))
                    {
                        rbShortLogo.Checked = true;
                    }
                    else
                    {
                        rbLongLogo.Checked = true;
                    }

                    if (ProfileID == logoProfileID)
                    {
                        logoimage.Enabled = true;
                        BtnUpdateLogo.Enabled = true;
                        pnlLogoUpload.Style["display"] = "block";
                    }
                    else
                        DisplayActions();
                }
            }
            else
                DisplayActions();
        }
        catch (TimeoutException ex)
        {
            // Timeout doesn't get caught. Must be a different type of timeout.
            // So far, timeout is only caught by HttpException.
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "LoadIntialMediaFiles - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "LoadIntialMediaFiles - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "LoadIntialMediaFiles", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    # endregion
    private void DisplayActions()
    {
        logoimage.Enabled = false;
        BtnUpdateLogo.Enabled = false;
        btnLogoDelete.Visible = false;
        pnlLogoUpload.Style["display"] = "none";
    }
    # region Delete Logo
    protected void btnLogoDelete_Click(object sender, EventArgs e)
    {
        try
        {
            DeleteLogo();
            chkImageGallery.Checked = false;
            lblLogoMsg.Text = "<font color=red face=arial size=2><b>Your logo has been deleted successfully.</b></font>";
        }
        catch (TimeoutException ex)
        {
            // Timeout doesn't get caught. Must be a different type of timeout.
            // So far, timeout is only caught by HttpException.
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "btnLogoDelete_Click - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "btnLogoDelete_Click - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "btnLogoDelete_Click", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    private void DeleteLogo()
    {
        try
        {
            GC.Collect();
            Response.Clear();
            Response.ClearContent();
            Response.Clear();
            Response.Cache.SetExpires(DateTime.Now);
            string strlogoPath = Server.MapPath("~") + "\\Upload\\Logos\\" + ProfileID + "\\";
            DataTable dtobj = new DataTable();
            string logourl = string.Empty;
            dtobj = busobj.GetProfileDetailsByProfileID(ProfileID);
            if (dtobj.Rows.Count == 1)
            {
                logourl = strlogoPath + dtobj.Rows[0]["Profile_logo_path"].ToString();
                int UFlag = busobj.UpdateBusinessProfileLogo(string.Empty, ProfileID, UserID, CUserID);
                logoimage.Visible = true;
                logoimage.Enabled = true;
                BtnUpdateLogo.Enabled = true;
                string imagename1 = dtobj.Rows[0]["Profile_logo_path"].ToString();

                string extension = System.IO.Path.GetExtension(Server.MapPath(imagename1));
                logo.Visible = false;
                string junk = ".";
                string[] ret = logourl.Split(junk.ToCharArray());
                string thumbimg = ret[0];
                thumbimg = thumbimg + "_thumb" + extension;

                if (dtobj.Rows[0]["Profile_logo_path"].ToString().Length > 0)
                {
                    if (System.IO.File.Exists(logourl))
                    {
                        System.Threading.Thread.Sleep(500);
                        System.IO.File.Delete(logourl);
                    }

                    if (System.IO.File.Exists(thumbimg))
                    {
                        System.Threading.Thread.Sleep(500);
                        File.Delete(thumbimg);
                    }

                    btnLogoDelete.Visible = false;
                    //deletelogohelp.Visible = false;
                    //btnResizeLogo.Visible = false;
                }
                else
                {
                    lblLogoMsg.Text = "<font color=red face=arial size=2>There is no logo available to delete.</font>";
                }

            }

            Response.Clear();
            Response.ClearContent();
            Response.Clear();
            Response.Cache.SetExpires(DateTime.Now);
            LoadIntialMediaFiles();
            Updateprofilecouponimage();
        }
        catch (TimeoutException ex)
        {
            // Timeout doesn't get caught. Must be a different type of timeout.
            // So far, timeout is only caught by HttpException.
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "DeleteLogo - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "DeleteLogo - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "DeleteLogo", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    # endregion

    #region Update Logo

    protected void BtnUpdateLogo_Click(object sender, EventArgs e)
    {
        try
        {

            if (logoimage.FileName != "")
            {
                if (logoimage.PostedFile != null)
                {
                    if (logoimage.PostedFile.FileName.ToString().Length > 1)
                    {
                        int logoMinWidth = 0;
                        int logoMinHeight = 0;
                        if (rbShortLogo.Checked)
                        {
                            logoMinWidth = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShortLogoWidth"));
                            logoMinHeight = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShortLogoHeight"));
                        }
                        else
                        {
                            logoMinWidth = Convert.ToInt32(ConfigurationManager.AppSettings.Get("LongLogoWidth"));
                            logoMinHeight = Convert.ToInt32(ConfigurationManager.AppSettings.Get("LongLogoHeight"));
                        }

                        FileInfo logoobj = new FileInfo(logoimage.PostedFile.FileName);
                        if (logoobj.Extension == ".jpg" || logoobj.Extension == ".JPG" || logoobj.Extension == ".JPEG" || logoobj.Extension == ".jpeg" ||
                            logoobj.Extension == ".GIF" || logoobj.Extension == ".gif" || logoobj.Extension == ".bmp" || logoobj.Extension == ".BMP" ||
                            logoobj.Extension == ".png" || logoobj.Extension == ".PNG")
                        {

                            System.Drawing.Image myImage = System.Drawing.Image.FromStream(logoimage.PostedFile.InputStream);
                            if ((myImage.Height >= logoMinHeight) && (myImage.Width >= logoMinWidth))
                            {
                                UploadAndSaveFile(logoimage, 1, logoMinWidth, logoMinHeight); // 1 is for logo 2 for photos, 3 for commerical.
                                Response.ContentType = "text/HTML";
                                Temp = "LOGO & ";
                            }
                            else
                            {
                                if (rbShortLogo.Checked)
                                    lblLogoMsg.Text = "<font color=red face=arial size=2><b>" + Resources.LabelMessages.ShortlogoUploadMessage + " " + logoMinWidth + "px X " + logoMinHeight + "px</b>.</font>";
                                else
                                    lblLogoMsg.Text = "<font color=red face=arial size=2><b>" + Resources.LabelMessages.LonglogoUploadMessage + " " + logoMinWidth + "px X " + logoMinHeight + "px</b>.</font>";
                            }
                        }
                        else
                        {
                            Errormsg = Errormsg.ToString() + "Your logo is in an incorrect file format. Please try again.";
                            lblLogoMsg.Text = "<font color=red face=arial size=2><b>" + Errormsg + "</b></font>";
                        }
                        logoobj = null;
                    }
                }
            }
            else
            {
                lblLogoMsg.Text = "<font color=red face=arial size=2><b>You have not selected a logo file to upload. Please try again.</b></font>";
            }

        }
        catch (TimeoutException ex)
        {
            // Timeout doesn't get caught. Must be a different type of timeout.
            // So far, timeout is only caught by HttpException.
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "BtnUpdateLogo_Click - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "BtnUpdateLogo_Click - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "BtnUpdateLogo_Click", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }

    # endregion

    #region UpdateProfileCouponImage
    private void Updateprofilecouponimage()
    {
        try
        {
            Response.Clear();
            Response.ClearContent();
            Response.Clear();
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.ViewState.Clear();
            // Start Issue 799
            Response.Cache.SetNoStore();
            string url = string.Empty;
            url = Server.MapPath("~").ToString();
            utlObj = new USPDHUBBLL.UtilitiesBLL();
            utlObj = null;
            // End issue 799
        }
        catch (TimeoutException ex)
        {
            // Timeout doesn't get caught. Must be a different type of timeout.
            // So far, timeout is only caught by HttpException.
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "Updateprofilecouponimage - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "Updateprofilecouponimage - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "Updateprofilecouponimage", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    #endregion

    private void UploadAndSaveFile(FileUpload file, int imagetype, int minWidth, int minHeight)
    {
        try
        {
            string tempSaveFilePath = Server.MapPath("~") + "\\Upload";
            string folderPath = string.Empty;
            if (imagetype == 1) //logo folder
                folderPath = tempSaveFilePath + "\\TempLogos\\" + ProfileID;
            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }

            FileInfo logoobj = new FileInfo(file.PostedFile.FileName);
            string logoExtension = logoobj.Extension;
            if (logoExtension == ".bmp" || logoExtension == ".BMP")
            {
                logoExtension = ".jpg";
            }

            string logoName = ProfileID + "_thumb" + logoExtension;
            Session["logoName"] = logoName;
            string LogoVartualPath = folderPath + "\\" + logoName;
            file.SaveAs(LogoVartualPath);

            System.Drawing.Image myImage = System.Drawing.Image.FromFile(LogoVartualPath);
            hdnOriginalWidth.Value = myImage.Width.ToString();
            hdnOriginalHeight.Value = myImage.Height.ToString();

            myImage.Dispose();
            myImage.Dispose();


            string logoRootPath = RootPath + "/Upload/TempLogos/" + ProfileID + "/" + logoName;
            hdnImgURL.Value = logoRootPath + "?id=" + Guid.NewGuid();

            // *** If no need to show the automatically resized image for long logo uncomment if condtion *** //
            //if (rbShortLogo.Checked)
            //{
            string tempShortLogoName = ProfileID + "_Short_thumb" + logoExtension;
            Session["tempShortLogoName"] = tempShortLogoName;
            //LogoResize(Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShortLogoMaxAllowWidth")), Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShortLogoMaxAllowWidth")),
            //    folderPath, tempShortLogoName, LogoVartualPath);

            LogoResize(minWidth, minHeight, folderPath, tempShortLogoName, LogoVartualPath);

            hdbTempShortLogoURL.Value = RootPath + "/Upload/TempLogos/" + ProfileID + "/" + tempShortLogoName + "?id=" + Guid.NewGuid();
            //}


            LogoModalPopup.Show();

        }
        catch (TimeoutException ex)
        {
            // Timeout doesn't get caught. Must be a different type of timeout.
            // So far, timeout is only caught by HttpException.
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "UploadAndSaveFile - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "UploadAndSaveFile - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "UploadAndSaveFile", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        finally
        {
            file.Dispose();
            utlObj = null;
        }
    }

    private void LogoResize(int pWidth, int pHeight, string folderLocation, string LogoName, string oldLogoLocation)
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


            string SavelogoLocation = folderLocation + "\\" + LogoName;

            if (!Directory.Exists(folderLocation))
            {
                Directory.CreateDirectory(folderLocation);
            }

            if (File.Exists(oldLogoLocation))
            {
                Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(oldLogoLocation);
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

                if (File.Exists(SavelogoLocation))
                {
                    File.Delete(SavelogoLocation);
                }
                imgDraw.Save(SavelogoLocation);
                imgDraw.Dispose();

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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "LogoResize - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "LogoResize - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "LogoResize", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void btndashboard1_Click(object sender, EventArgs e)
    {
        try
        {
            string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/Default.aspx");
            Response.Redirect(urlinfo);
        }
        catch (TimeoutException ex)
        {
            // Timeout doesn't get caught. Must be a different type of timeout.
            // So far, timeout is only caught by HttpException.
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "btndashboard1_Click - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "btndashboard1_Click - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "btndashboard1_Click", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void btnwizard_Click(object sender, EventArgs e)
    {
        try
        {
            string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/ManageBusinessDetails.aspx");
            Response.Redirect(urlinfo);
        }
        catch (TimeoutException ex)
        {
            // Timeout doesn't get caught. Must be a different type of timeout.
            // So far, timeout is only caught by HttpException.
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "btnwizard_Click - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "btnwizard_Click - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "btnwizard_Click", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    //Logo Modal Popup events Crop Logo
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        /*
        int resizelogoHeight = Convert.ToInt32(hdheight.Value);
        int resizelogoWidth = Convert.ToInt32(hdwidth.Value);

        SaveResizeLogo(resizelogoWidth, resizelogoHeight);
        CreateLogoInImageGallery(".jpg");
        */
    }

    protected void btnCropLogo_OnClick(object sende, EventArgs e)
    {
        try
        {
            //Log
            objInBuiltData.ErrorHandling("LOG", "Business_MyAccount_ModifyLogo.aspx.cs", "btnCropLogo_OnClick", string.Empty,
                string.Empty, string.Empty, string.Empty);

            string fname = Session["logoName"].ToString();
            string fpath = Path.Combine(Server.MapPath("~/Upload/TempLogos/" + ProfileID.ToString()), fname);

            string logoExtension = "";
            GC.Collect();

            if (!System.IO.Directory.Exists(Server.MapPath("~") + "\\Upload\\Logos\\" + ProfileID))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("~") + "\\Upload\\Logos\\" + ProfileID);
            }


            using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(fpath)))
            {
                using (System.Drawing.Image img = System.Drawing.Image.FromStream(ms))
                {
                    Rectangle cropcords = new Rectangle(Convert.ToInt32(hdnx.Value),
                    Convert.ToInt32(hdny.Value),
                    Convert.ToInt32(hdnw.Value),
                    Convert.ToInt32(hdnh.Value));

                    string cfpath;
                    using (Bitmap bitMap = new Bitmap(cropcords.Width, cropcords.Height, img.PixelFormat))
                    {
                        Graphics grph = Graphics.FromImage(bitMap);
                        grph.DrawImage(img, new Rectangle(0, 0, bitMap.Width, bitMap.Height), cropcords, GraphicsUnit.Pixel);

                        logoExtension = "" + fname.Substring(fname.LastIndexOf('.'));


                        GC.Collect();
                        Response.Clear();
                        Response.ClearContent();
                        Response.Clear();
                        Response.Cache.SetExpires(DateTime.Now);
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        this.ViewState.Clear();

                        string originalLogoPath = "";
                        // *** If no need to show the automatically resized image for long logo uncomment if condtion and whole else *** //
                        //if (rbShortLogo.Checked)
                        //{
                        //string folderPath = Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID;
                        //string fileName = ProfileID + "_Short_thumb" + logoExtension;
                        //string newFileName = ProfileID + "_thumb" + logoExtension;
                        //originalLogoPath = folderPath + "\\" + fileName;
                        //cfpath = Path.Combine(originalLogoPath);
                        //if (File.Exists(originalLogoPath))
                        //{
                        //    File.Delete(originalLogoPath);
                        //}
                        //bitMap.Save(cfpath);


                        if (rbSystemResizeLogo.Checked)
                        {
                            string TempLogoLocation = Server.MapPath("~") + "\\Upload\\TempLogos\\" + ProfileID + "\\" + Session["tempShortLogoName"].ToString();
                            originalLogoPath = Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID + "\\" + ProfileID + "_thumb" + logoExtension;

                            File.Copy(TempLogoLocation, originalLogoPath, true);
                        }
                        else
                        {
                            //LogoResize(Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShortLogoWidth")),
                            //    Convert.ToInt32(ConfigurationManager.AppSettings.Get("ShortLogoHeight")), folderPath, newFileName, cfpath);

                            originalLogoPath = Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID + "\\" + ProfileID + "_thumb" + logoExtension;
                            cfpath = Path.Combine(originalLogoPath);
                            if (File.Exists(originalLogoPath))
                            {
                                File.Delete(originalLogoPath);
                            }
                            bitMap.Save(cfpath);
                        }
                        //}
                        //else
                        //{
                        //    originalLogoPath = Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID + "\\" + ProfileID + "_thumb" + logoExtension;
                        //    cfpath = Path.Combine(originalLogoPath);
                        //    if (File.Exists(originalLogoPath))
                        //    {
                        //        File.Delete(originalLogoPath);
                        //    }
                        //    bitMap.Save(cfpath);
                        //}
                    }
                }
                ms.Flush();
                ms.Close();
                ms.Dispose();
            }

            string photoFileName = ProfileID + logoExtension;
            busobj.UpdateBusinessProfileLogo(photoFileName, ProfileID, UserID, CUserID);
            if (rbShortLogo.Checked)
                isShortLogo = true;
            busobj.UpdateShortorLongLogo(UserID, isShortLogo);
            lblLogoMsg.Text = "";

            var tempFileLog = Server.MapPath("~") + "\\Upload\\TempLogos\\" + ProfileID + "\\" + ProfileID + "_thumb" + logoExtension;
            if (File.Exists(tempFileLog))
            {
                File.Delete(tempFileLog);
            }

            Session["LogoSuccess"] = "Your logo has been uploaded successfully.";

            busobj.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "Logo", "Upload");

            // Save User Activity Log
            objCommonBLL.InsertUserActivityLog("has got a new profile picture", string.Empty, UserID, ProfileID, DateTime.Now, UserID);
            CreateLogoInImageGallery(logoExtension);

            string reidrectUrl = Page.ResolveClientUrl("~/Business/Myaccount/ModifyLogo.aspx");
            if (Request.QueryString["App"] != null)
                reidrectUrl = reidrectUrl + "?App=" + Request.QueryString["App"].ToString();
            Response.Redirect(reidrectUrl);

            Response.Clear();
            Response.ClearContent();
            Response.Clear();
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.ViewState.Clear();
            LoadIntialMediaFiles();
            Updateprofilecouponimage();

        }
        catch (TimeoutException ex)
        {
            // Timeout doesn't get caught. Must be a different type of timeout.
            // So far, timeout is only caught by HttpException.
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "btnCropLogo_OnClick - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "btnCropLogo_OnClick - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "Business_MyAccount_ModifyLogo.aspx.cs", "btnCropLogo_OnClick", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void btnResizeCancel_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsResizeLogo == false)
            {
                DeleteLogo();
            }

            LogoModalPopup.Hide();
            lblLogoMsg.Text = "";
        }
        catch (TimeoutException ex)
        {
            // Timeout doesn't get caught. Must be a different type of timeout.
            // So far, timeout is only caught by HttpException.
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "btnResizeCancel_Click - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "btnResizeCancel_Click - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "btnResizeCancel_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    private void DeleteCache()
    {
        try
        {
            Response.Clear();
            Response.ClearContent();
            Response.Clear();
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.ViewState.Clear();
            Response.Cache.SetNoStore();
        }
        catch (TimeoutException ex)
        {
            // Timeout doesn't get caught. Must be a different type of timeout.
            // So far, timeout is only caught by HttpException.
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "DeleteCache - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "DeleteCache - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "DeleteCache", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void chkImageGallery_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CreateLogoInImageGallery(".jpg");
        }
        catch (TimeoutException ex)
        {
            // Timeout doesn't get caught. Must be a different type of timeout.
            // So far, timeout is only caught by HttpException.
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "chkImageGallery_CheckedChanged - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "chkImageGallery_CheckedChanged - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "chkImageGallery_CheckedChanged", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        string url = Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx");
        Response.Redirect(url);
    }

    private void CreateLogoInImageGallery(string logoExtension)
    {
        try
        {
            string oldLogoFileName = Server.MapPath("~") + "\\Upload\\Logos\\" + +ProfileID + "\\" + ProfileID + "_thumb" + logoExtension;
            if (File.Exists(oldLogoFileName))
            {
                string imgName = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + logoExtension;
                string savefileName = Server.MapPath("~") + "\\Upload\\common\\" + +ProfileID + "\\" + imgName;

                Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(oldLogoFileName);

                Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();

                System.Drawing.Image imgname = System.Drawing.Image.FromFile(oldLogoFileName);
                actResize.Width = imgname.Width;
                actResize.Height = imgname.Height;

                actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.None;
                uploadedImage.Actions.Add(actResize);
                actResize = null;
                Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();

                imgDraw.Elements.Add(uploadedImage);

                imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                imgDraw.JpegCompressionLevel = 90;

                uploadedImage = null;
                //Now, save the output image on disk

                imgDraw.Save(savefileName);
                imgDraw.Dispose();


            }
        }
        catch (TimeoutException ex)
        {
            // Timeout doesn't get caught. Must be a different type of timeout.
            // So far, timeout is only caught by HttpException.
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "CreateLogoInImageGallery - timeout is only caught by HttpException.", ex.Message,
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
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "CreateLogoInImageGallery - Took too long. Please upload a smaller image.", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyLogo.aspx.cs", "CreateLogoInImageGallery", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }


    public string dummyLogoFIle { get; set; }
}


