using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.Configuration;
using System.IO;

namespace USPDHUB.Business.MyAccount
{
    public partial class ModifyAppBGImage : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;


        BusinessBLL busobj = new BusinessBLL();
        USPDHUBBLL.UtilitiesBLL utlObj = new USPDHUBBLL.UtilitiesBLL();
        public int CUserID = 0;


        public DataTable Dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        public string PermissionType = string.Empty;
        public int PermissionValue = 0;
        public string RootPath = "";
        public string DomainName = "";

        CommonBLL objCommonBLL = new CommonBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();



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

                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                this.ViewState.Clear();
                lblBGImageMsg.Text = "";
                this.Server.ScriptTimeout = 3600;

                // *** Make back button visible and disable by query string 26-03-2013 *** //
                if (!string.IsNullOrEmpty(Request.QueryString["App"] as string))
                    btnBack.Visible = true;
                else
                    btnBack.Visible = false;

                if (!IsPostBack)
                {
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommonBLL.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                    }// End Roles       

                    // Show BG Image
                    LoadBGImage();

                }

                if (Session["BGImgSuccess"] != null)
                {
                    if (Session["BGImgSuccess"].ToString() != "")
                    {
                        lblBGImageMsg.Text = "<font color=green face=arial size=2><b>" + Session["BGImgSuccess"] + "</b></font>";
                        Session["BGImgSuccess"] = null;
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ModifyAppBGImage.aspx.cs", "Page_Load", ex.Message,
                 Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/Default.aspx");
            Response.Redirect(urlinfo);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string url = Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx");
            Response.Redirect(url);
        }

        protected void BtnUpdateBGImg_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (fileuploadBGImage.FileName != "")
                {
                    if (fileuploadBGImage.PostedFile != null)
                    {
                        if (fileuploadBGImage.PostedFile.FileName.ToString().Length > 1)
                        {
                            int minBGImageWidth = Convert.ToInt32(ConfigurationManager.AppSettings.Get("BGImageWidth"));
                            int minBGImageHeight = Convert.ToInt32(ConfigurationManager.AppSettings.Get("BGImageHeight"));

                            FileInfo logoobj = new FileInfo(fileuploadBGImage.PostedFile.FileName);
                            if (logoobj.Extension == ".jpg" || logoobj.Extension == ".JPG" || logoobj.Extension == ".JPEG" || logoobj.Extension == ".jpeg" ||
                                logoobj.Extension == ".GIF" || logoobj.Extension == ".gif" || logoobj.Extension == ".bmp" || logoobj.Extension == ".BMP" ||
                                logoobj.Extension == ".png" || logoobj.Extension == ".PNG")
                            {

                                System.Drawing.Image myImage = System.Drawing.Image.FromStream(fileuploadBGImage.PostedFile.InputStream);
                                if ((myImage.Height >= minBGImageHeight) && (myImage.Width >= minBGImageWidth))
                                {
                                    UploadBGImage();
                                    Response.ContentType = "text/HTML";

                                }
                                else
                                {
                                    string warningMessage = Resources.LabelMessages.LonglogoUploadMessage.Replace("long logo", "image");
                                    lblBGImageMsg.Text = "";
                                    lblBGImageMsg.Text = "<font color=red face=arial size=2><b>" + warningMessage + " " + minBGImageWidth + "px X " + minBGImageHeight + "px</b>.</font>";
                                }
                            }
                            else
                            {
                                string Errormsg = "Your image is in an incorrect file format. Please try again.";
                                lblBGImageMsg.Text = "<font color=red face=arial size=2><b>" + Errormsg + "</b></font>";
                            }
                            fileuploadBGImage = null;

                        }
                    }
                }
                else
                {
                    lblBGImageMsg.Text = "<font color=red face=arial size=2><b>You have not selected a image file to upload. Please try again.</b></font>";
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ModifyAppBGImage.aspx.cs", "BtnUpdateBGImg_OnClick", ex.Message,
                 Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }


        protected void btnBGImgDelete(object sender, EventArgs e)
        {
            string VirtualBGImgFolder = Server.MapPath("~/Upload") + "/ProfileBGImages/" + ProfileID;
            foreach (string path in System.IO.Directory.GetFiles(VirtualBGImgFolder))
            {
                System.IO.File.Delete(path);
            }
            GC.Collect();


            LoadBGImage();
        }

        private void LoadBGImage()
        {
            string VirtualBGImgPath = Server.MapPath("~/Upload") + "/ProfileBGImages/" + ProfileID + "/" + ProfileID + "_BG.png";
            if (System.IO.File.Exists(VirtualBGImgPath))
            {
                imgBGImage.ImageUrl = RootPath + "/Upload/ProfileBGImages/" + ProfileID + "/" + ProfileID + "_BG.png?id=" + Guid.NewGuid();
                imgBGImage.Visible = true;
                btnBGImgDelete1.Visible = true;

                fileuploadBGImage.Visible = false;
                BtnUpdateBGImg.Visible = false;
            }
            else
            {
                imgBGImage.Visible = false;
                btnBGImgDelete1.Visible = false;

                fileuploadBGImage.Visible = true;
                BtnUpdateBGImg.Visible = true;
            }
        }

        private string UploadBGImage()
        {
            try
            {
                string VirtualBGImgFolder = Server.MapPath("~/Upload") + "/ProfileBGImages/" + ProfileID;
                if (!System.IO.Directory.Exists(VirtualBGImgFolder))
                {
                    System.IO.Directory.CreateDirectory(VirtualBGImgFolder);
                }

                string BGImagePath = VirtualBGImgFolder + "/" + ProfileID + "_BG.png";
                fileuploadBGImage.SaveAs(BGImagePath);

                // // Resize BG image for app resultion 
                // // Andriod 320x480
                ResizeBGImages(320, 480);

                // // Windows Phone 480x800
                ResizeBGImages(480, 800);

                // // IPhone 640x960
                ResizeBGImages(640, 960);

                // // Andriod 800x1280
                ResizeBGImages(800, 1280);

                // // Andriod 1080x1920
                ResizeBGImages(1080, 1920);

                // END Resize BG Image  **************************************************

                // Success Message
                Session["BGImgSuccess"] = "Your image has been uploaded successfully.";

                string reidrectUrl = Page.ResolveClientUrl("~/Business/Myaccount/ModifyAppBGImage.aspx");
                if (Request.QueryString["App"] != null)
                    reidrectUrl = reidrectUrl + "?App=" + Request.QueryString["App"].ToString();
                Response.Redirect(reidrectUrl);

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
                objInBuiltData.ErrorHandling("ERROR", "ModifyAppBGImage.aspx.cs", "UploadBGImage", ex.Message,
                 Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

            return "";
        }

        private void ResizeBGImages(int pWidth, int pHeight)
        {
            string ImageSize = pWidth + "x" + pHeight;
            string originalBGImagePath = Server.MapPath("~/Upload") + "/ProfileBGImages/" + ProfileID + "/" + ProfileID + "_BG.png";
            string newImagePath = Server.MapPath("~/Upload") + "/ProfileBGImages/" + ProfileID + "/" + ProfileID + "_BG_" + ImageSize + ".png";

            try
            {

                Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(originalBGImagePath);

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

                imgDraw.Save(newImagePath);
                imgDraw.Dispose();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ModifyAppBGImage.aspx.cs", "ResizeBGImages", ex.Message,
                 Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}