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

namespace USPDHUB.Business.MyAccount
{
    public partial class CallModuleImageGallery : System.Web.UI.Page
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public int C_UserID = 0;
        public int UserModuleId = 0;
        public string TempFolderPath = string.Empty;
        public string TempSesPath = string.Empty;
        public string FolderName = "Forms";
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public string RootPath = "";
        CommonBLL objCommonBLL = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Get Domain Name *** //
                if (Convert.ToString(Session["UserID"]) == "" || Session["VerticalDomain"] == null)
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Login.aspx?sflag=1"));
                }
                RootPath = Session["RootPath"].ToString();
                if (Session["ProfileID"] == null || Session["CustomModuleID"] == null)
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Javascript", "CloseModalPopup()", true);
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
                            TempSesPath = TempSesPath.Remove(TempSesPath.Length - 1);
                    }
                    if (Session["CustomModuleID"].ToString() != "")
                        UserModuleId = Convert.ToInt32(Session["CustomModuleID"].ToString());

                }

                if (Request.QueryString["fitblockwidth"] != null)
                    Session["fitblockwidth"] = Request.QueryString["fitblockwidth"];
                if (Request.QueryString["imgSrc"] != null)
                    Session["imgSrc"] = Request.QueryString["imgSrc"];
                if (Request.QueryString["ModuleName"] != null)
                {
                    Session["ModuleName"] = Request.QueryString["ModuleName"];
                }
                Session["Directory"] = Request.QueryString["Directory"];
                UserID = Convert.ToInt32(Session["UserID"]);
                C_UserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                if (!IsPostBack)
                {
                    pnlResize.Visible = false;
                    pnlallimage.Visible = false;
                    hdnResizeImageValue.Value = "";
                    hdnClose.Value = "";
                    hdnCheck.Value = "";

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
                                    if (m.Value.Contains("NewsletterTemplates") == false)
                                    {
                                        if (m.Value.Contains("Upload/Logos") == false)
                                        {
                                            txtwebaddress.Text = m.Value.ToString();
                                        }
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
                            ShowImageResizePanel(currentLoadImgUrl, "1");
                            Session["imgSrc"] = null;
                        }
                        else
                        {
                            pnlResize.Visible = false;
                            pnlallimage.Visible = true;
                            GetBulletinImages();

                        }
                    }
                    else
                    {
                        pnlResize.Visible = false;
                        pnlallimage.Visible = true;
                        GetBulletinImages();

                    }
                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CallModuleImageGallery.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public void GetBulletinImages()
        {
            try
            {

                //User Images Path
                string bulletinImagesPath = Server.MapPath("~") + "/Upload/CallModule/" + ProfileID.ToString();
                if (!Directory.Exists(bulletinImagesPath))
                {
                    Directory.CreateDirectory(bulletinImagesPath);
                }
                bulletinImagesPath = bulletinImagesPath + "/" + Convert.ToString(Session["CustomModuleID"]);
                if (!Directory.Exists(bulletinImagesPath))
                {
                    Directory.CreateDirectory(bulletinImagesPath);
                }
                DataTable dtImages = objCommonBLL.GetCallModuleProfileImages(Convert.ToInt32(Session["CustomModuleID"]), txtSearch.Text.Trim());
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
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CallModuleImageGallery.aspx.aspx.cs", "GetBulletinImages", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void DeleteBulletinImages()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CallModuleImageGallery.aspx.cs", "DeleteBulletinImages", string.Empty, string.Empty, string.Empty, string.Empty);

                if (File.Exists(Server.MapPath("~") + "\\Upload\\CallModule\\" + ProfileID.ToString() + "\\" + UserModuleId))
                {
                    string[] allImages = Directory.GetFiles(Server.MapPath("~") + "\\Upload\\CallModule\\" + ProfileID.ToString() + "\\" + UserModuleId);
                    string currentDate = DateTime.Now.ToShortDateString();
                    foreach (string fileName in allImages)
                    {
                        string imgCreatedDate = File.GetCreationTime(fileName).ToShortDateString();
                        TimeSpan ts = Convert.ToDateTime(currentDate) - Convert.ToDateTime(imgCreatedDate);
                        int dateDiff = ts.Days;
                        if (dateDiff > 180)
                        {
                            File.Delete(fileName);
                        }
                    }
                }

                cbSelectAll.Checked = false;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CallModuleImageGallery.aspx.aspx.cs", "DeleteBulletinImages", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                hdnCheck.Value = "";
                if (FUUserImages.HasFile)
                {
                    string imageExtension = string.Empty;
                    string imagename = txtimagname.Text.Replace(" ", "_");
                    imageExtension = Path.GetExtension(FUUserImages.FileName);
                    if (imageExtension == ".jpg" || imageExtension == ".JPG" || imageExtension == ".JPEG" || imageExtension == ".jpeg" || imageExtension == ".GIF" || imageExtension == ".gif" || imageExtension == ".png" || imageExtension == ".PNG")
                    {
                        string imagepath = string.Empty;
                        string saveimagepath = string.Empty;
                        if (Session["ProfileID"] != null)
                        {
                            if (Session["ProfileID"].ToString() != "")
                            {
                                if (imageExtension == ".GIF" || imageExtension == ".gif")
                                {
                                    imageExtension = ".png";
                                }

                                imagename = GetCallModuleProfileImageName(imagename, imageExtension);
                                imagepath = Server.MapPath("~") + "\\Upload\\CallModule\\" + ProfileID.ToString() + "\\" + UserModuleId.ToString();
                                if (!Directory.Exists(imagepath))
                                    Directory.CreateDirectory(imagepath);
                                saveimagepath = imagepath + "\\" + imagename;
                                objCommonBLL.GetImageRotateFlip(FUUserImages, saveimagepath, true);
                                System.Drawing.Image imgname = System.Drawing.Image.FromFile(saveimagepath);
                                objCommonBLL.InsertCallModuleProfileImage(UserModuleId, ProfileID, UserID, C_UserID, imagename, txtimagname.Text, imgname.Width.ToString() + " x " + imgname.Height.ToString());
                                string newImg = imagepath + "/" + Path.GetFileNameWithoutExtension(saveimagepath) + "_thumb" + Path.GetExtension(saveimagepath);


                                using (var reader = ImageReader.Create(saveimagepath))
                                using (var resize = new Resize(100, 100, ResizeInterpolationMode.High, ResizeMode.Fit))
                                using (var writer = ImageWriter.Create(newImg))
                                {
                                    Pipeline.Run(reader + resize + writer);
                                }

                            }//if

                        }//if


                        System.Threading.Thread.Sleep(8000);
                        lblerrormsg.Text = "<font color='green' face=arial size=3>Your image has been uploaded successfully.</font>";
                        txtimagname.Text = "";
                    }
                    else
                    {
                        lblerrormsg.Text = "<font color='red'>Your image is not in the correct file format; please use .jpeg,.jpg,.gif or .png only.</font>";
                    }
                }
                else
                {
                    lblerrormsg.Text = "<font color='red'>Please select a file to upload.</font>";
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CallModuleImageGallery.aspx.cs", "BtnUpload_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                GetBulletinImages();
            }
        }
        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            lblerrormsg.Text = "";
            GetBulletinImages();
        }
        protected void lnkClear_Click(object sender, EventArgs e)
        {
            lblerrormsg.Text = "";
            txtSearch.Text = "";
            GetBulletinImages();
        }
        private string GetCallModuleProfileImageName(string imagename, string imageExtension)
        {
            try
            {
                bool isAvailable = false;
                isAvailable = objCommonBLL.CheckCallModuleProfileImage(UserModuleId, imagename + imageExtension);
                if (!isAvailable)
                    GetCallModuleProfileImageName(imagename + "_1", imageExtension);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CallModuleImageGallery.aspx.cs", "GetCallModuleProfileImageName", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return (imagename + imageExtension);
        }
        protected void ImgUserImg_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CallModuleImageGallery.aspx.cs", "ImgUserImg_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                hdnClose.Value = "";
                hdnCheck.Value = "";
                Session["OrgImageName"] = null;
                ImageButton imgResizeButton = sender as ImageButton;
                ShowImageResizePanel(imgResizeButton.ImageUrl, "2");

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CallModuleImageGallery.aspx.cs", "ImgUserImg_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void ShowImageResizePanel(string rLoadImageUrl, string resize)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CallModuleImageGallery.aspx.cs", "ShowImageResizePanel", string.Empty, string.Empty, string.Empty, string.Empty);

                string rsizeimagepath = string.Empty;
                rsizeimagepath = Path.GetFileName(rLoadImageUrl);
                int length = rsizeimagepath.LastIndexOf('_');
                if (length > 0)
                    rsizeimagepath = rsizeimagepath.Substring(0, length) + Path.GetExtension(rsizeimagepath);
                if ((rLoadImageUrl.Contains("NewsletterTemplates")) || (rLoadImageUrl.Contains("Upload/Logos")))
                {
                    rsizeimagepath = rLoadImageUrl.Replace(RootPath, Server.MapPath("~"));
                    rsizeimagepath = rsizeimagepath.Replace("/", "\\");
                    rsizeimagepath = rsizeimagepath.Replace("%20", " ");
                }
                else
                {
                    if (resize == "2")
                    {
                        rsizeimagepath = Server.MapPath("~") + "\\Upload\\CallModule\\" + ProfileID.ToString() + "\\" + UserModuleId + "\\" + rsizeimagepath;
                    }
                    else
                    {
                        rsizeimagepath = Server.MapPath("~") + "\\Upload\\Bulletins\\" + FolderName + "\\" + ProfileID.ToString() + "\\" + TempSesPath + "\\" + rsizeimagepath;
                        if (!File.Exists(rsizeimagepath))
                        {
                            rsizeimagepath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString() + "\\" + rsizeimagepath;
                        }
                    }
                    rsizeimagepath = rsizeimagepath.Replace("%20", " ");
                }
                if (File.Exists(rsizeimagepath))
                {
                    string orgImagename = string.Empty;
                    Session["Rsizeimagepath"] = rsizeimagepath;
                    orgImagename = Path.GetFileName(rsizeimagepath);
                    string orgExt = Path.GetExtension(rsizeimagepath);
                    orgImagename = orgImagename.Replace(orgExt, "");
                    Session["OrgImageName"] = orgImagename;
                    Session["ImgExt"] = orgExt;
                    string extension = string.Empty;
                    extension = Path.GetExtension(rsizeimagepath);
                    //
                    string tempSavePath = "";// Server.MapPath("~") + "\\Upload\\tempbulletinswork\\" + ProfileID + Session["TempName"] + "" + Extension;

                    Session["TempName"] = "_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;

                    //Create Temp folder for tempbulletinswork
                    string tempbulletinswork = Server.MapPath("~") + "/Upload/tempbulletinswork/" + FolderName + "/";
                    if (!Directory.Exists(tempbulletinswork))
                    {
                        Directory.CreateDirectory(tempbulletinswork);
                    }
                    tempSavePath = Server.MapPath("~") + "\\Upload\\tempbulletinswork\\" + FolderName + "\\" + ProfileID + Session["TempName"] + "" + extension;
                    rsizeimagepath = rsizeimagepath.Replace("%20", " ");
                    FileInfo fisave = new FileInfo(rsizeimagepath);
                    fisave.CopyTo(tempSavePath, true);
                    tempSavePath = RootPath + "/Upload/tempbulletinswork/" + FolderName + "/" + ProfileID + Session["TempName"] + "" + extension + "?" + Guid.NewGuid();

                    hdnResizeImageValue.Value = tempSavePath;
                    using (FileStream fs = new FileStream(rsizeimagepath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(fs))
                        {
                            fs.Flush();
                            fs.Close();
                            fs.Dispose();
                            //GETTING BLOCK SIZE 
                            rbfittoblock.Text = "Fit to width <strong>" + Session["fitblockwidth"].ToString() + "px X " + image.Height.ToString() + "px</strong>";
                            if (resize == "1")
                            {
                                try
                                {
                                    txtimagewidth1.Value = image.Width.ToString();
                                    txtimageheight1.Value = image.Height.ToString();
                                    ChangedHeight.Value = "";

                                    txtimageheight2.Text = image.Height.ToString();
                                    txtimagewidth2.Text = image.Width.ToString();
                                }
                                catch (Exception /*ex*/)
                                {
                                }
                            }
                            else
                            {
                                if (image.Width > Convert.ToInt32(CheckWidth.Value))
                                {
                                    txtimageheight2.Text = image.Height.ToString();
                                    txtimagewidth2.Text = CheckWidth.Value;
                                    hdnimgheight2.Value = image.Height.ToString();
                                    hdnimgwidth2.Value = CheckWidth.Value;
                                    ChangedHeight.Value = "1";
                                    SaveResizeImage();
                                }
                                else
                                {
                                    try
                                    {
                                        ChangedHeight.Value = "";
                                        txtimagewidth1.Value = image.Width.ToString();
                                        txtimageheight1.Value = image.Height.ToString();

                                        txtimageheight2.Text = image.Height.ToString();
                                        txtimagewidth2.Text = image.Width.ToString();
                                    }
                                    catch (Exception /*ex*/)
                                    {
                                    }
                                }
                            }
                        }
                    }
                    Response.Clear();
                    Response.ClearContent();
                    Response.Clear();
                    Response.Cache.SetExpires(DateTime.Now);
                    GC.Collect();
                    pnlallimage.Visible = false;
                    pnlResize.Visible = true;

                    hdnOrgDivDim.Value = "1";
                    lblload.Text = "";
                }
                else
                {
                    pnlResize.Visible = false;
                    pnlallimage.Visible = true;
                    GetBulletinImages();

                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CallModuleImageGallery.aspx.cs", "ShowImageResizePanel", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public void SaveResizeImage()
        {
            //thumbnail creation starts
            try
            {   //Log
                objInBuiltData.ErrorHandling("LOG", "CallModuleImageGallery.aspx.cs", "SaveResizeImage", string.Empty, string.Empty, string.Empty, string.Empty);
                //Retrieve the image filename whose thumbnail has to be created
                string imageUrl = hdnResizeImageValue.Value;
                int removeIndVal = imageUrl.IndexOf("?");
                imageUrl = imageUrl.Remove(removeIndVal);
                imageUrl = Path.GetFileName(imageUrl);
                //Read in the width and height
                int imageHeight = Convert.ToInt32(hdnimgheight2.Value);
                int imageWidth = Convert.ToInt32(hdnimgwidth2.Value);

                //the uploaded image will be stored in the Pics folder.
                //to get resize the image, the original image has to be
                //accessed from the Pics folder
                imageUrl = "\\Upload\\tempbulletinswork\\" + FolderName + "\\" + imageUrl;
                imageUrl = Server.MapPath("~") + (imageUrl);
                Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(imageUrl);
                Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                actResize.Width = imageWidth;
                actResize.Height = imageHeight;
                actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.WidthBased;
                uploadedImage.Actions.Add(actResize);
                Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                imgDraw.Elements.Add(uploadedImage);
                imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                imgDraw.JpegCompressionLevel = 100;
                //We need to create a unique filename for each generated image        
                string myString = string.Empty;
                myString = ProfileID + Session["TempName"].ToString() + Session["ImgExt"].ToString();
                //Save the thumbnail in PNG format. 
                //You may change it to a diff format with the ImageFormat property
                imageUrl = "\\Upload\\tempbulletinswork\\" + FolderName + "\\" + myString;
                imageUrl = Server.MapPath("~") + (imageUrl);
                imgDraw.Save(imageUrl);
                hdnResizeImageValue.Value = RootPath + "/Upload/tempbulletinswork/" + FolderName + "/" + myString.ToString() + "?" + Guid.NewGuid();

                //For Width Based image resize after getting img Height
                if (imageWidth >= Convert.ToInt32(CheckWidth.Value))
                {
                    using (FileStream fs = new FileStream(imageUrl, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(fs))
                        {
                            fs.Flush();
                            fs.Close();
                            fs.Dispose();
                            try
                            {
                                txtimageheight2.Text = image.Height.ToString();
                                hdnimgheight2.Value = image.Height.ToString();

                                rbfittoblock.Text = "Fit to width <strong>" + Session["fitblockwidth"].ToString() + "px X " + image.Height.ToString() + "px</strong>";
                            }
                            catch (Exception /*ex*/)
                            {
                            }
                        }
                    }
                }
                txtimageheight1.Value = hdnimgheight2.Value;
                txtimagewidth1.Value = hdnimgwidth2.Value;
                lblresizemess.Text = "The image has been resized to fit the block width.";

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CallModuleImageGallery.aspx.cs", "SaveResizeImage", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CallModuleImageGallery.aspx.cs", "btnsubmit_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                string savePath = string.Empty;
                string tempImagePath = string.Empty;
                string rVirtualPath = string.Empty;
                string myString = string.Empty;
                TempFolderPath = Server.MapPath("~") + "\\Upload\\Bulletins\\" + FolderName + "\\" + ProfileID.ToString() + "\\" + TempSesPath;
                if (!Directory.Exists(TempFolderPath))
                {
                    Directory.CreateDirectory(TempFolderPath);
                }
                if (hdnChangeResize.Value != "")
                {
                    SaveResizeImage();
                    hdnCheck.Value = "1";
                }
                if (hdnCheck.Value != "")
                {
                    DateTime myDate = DateTime.Now;
                    myString = Session["OrgImageName"].ToString();
                    //Remove Special characters
                    myString = Regex.Replace(myString, "[^0-9a-zA-Z-._]+", "");
                    myString = myString + "_" + myDate.ToString("ddMMyyhhmmss") + Session["ImgExt"].ToString();
                    savePath = Server.MapPath("~") + "\\Upload\\CallModule\\" + ProfileID + "\\" + UserModuleId + "\\" + myString;
                    TempFolderPath = TempFolderPath + "\\" + myString;
                    tempImagePath = Server.MapPath("~") + "\\Upload\\tempbulletinswork\\" + FolderName + "\\" + ProfileID + Session["TempName"] + Session["ImgExt"].ToString();
                    FileInfo fisave = new FileInfo(tempImagePath);
                    rVirtualPath = RootPath + "/Upload/Bulletins/" + FolderName + "/" + ProfileID.ToString() + "/" + TempSesPath + "/" + myString;
                    fisave.CopyTo(TempFolderPath);
                    if (chkAddtoGallery.Checked == true)
                    {
                        fisave.CopyTo(savePath);
                    }
                    try
                    {
                        using (FileStream fs = new FileStream(TempFolderPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            using (System.Drawing.Image image = System.Drawing.Image.FromStream(fs))
                            {
                                fs.Flush();
                                fs.Close();
                                fs.Dispose();

                                hdnwidth.Value = image.Width.ToString();
                                hdnheight.Value = image.Height.ToString();

                            }
                        }
                    }
                    catch (Exception /*ex*/)
                    {
                    }
                }
                else
                {
                    string unChangedImage = string.Empty;
                    unChangedImage = hdnResizeImageValue.Value;
                    int removeIndVal = unChangedImage.IndexOf("?");
                    unChangedImage = unChangedImage.Remove(removeIndVal);
                    unChangedImage = Path.GetExtension(unChangedImage);
                    DateTime myDate = DateTime.Now;
                    myString = Convert.ToString(Session["OrgImageName"]) + "_" + myDate.ToString("ddMMyyhhmmss") + unChangedImage;
                    //Remove Special characters
                    myString = Regex.Replace(myString, "[^0-9a-zA-Z-._]+", "");

                    savePath = Server.MapPath("~") + "\\Upload\\CallModule\\" + ProfileID + "\\" + UserModuleId + "\\" + myString;
                    TempFolderPath = TempFolderPath + "\\" + myString;
                    tempImagePath = Server.MapPath("~") + "\\Upload\\tempbulletinswork\\" + FolderName + "\\" + ProfileID + Session["TempName"] + unChangedImage;
                    Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                    uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(tempImagePath);
                    Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                    actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.None;
                    if (hdnheight.Value == string.Empty)
                    {
                        using (FileStream fs = new FileStream(tempImagePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            using (System.Drawing.Image image = System.Drawing.Image.FromStream(fs))
                            {
                                fs.Flush();
                                fs.Close();
                                fs.Dispose();
                                hdnheight.Value = image.Height.ToString();
                                hdnwidth.Value = image.Width.ToString();
                            }
                        }
                    }
                    GC.Collect();
                    if (rbfittoblock.Checked == true)
                    {
                        actResize.Width = Convert.ToInt32(Session["fitblockwidth"]);
                        if (hdnheight.Value == string.Empty)
                        {
                            actResize.Height = Convert.ToInt32(hdnheight.Value);
                        }
                        else
                        {
                            actResize.Height = Convert.ToInt32(txtimageheight1.Value);
                            hdnheight.Value = txtimageheight1.Value;
                        }
                        hdnwidth.Value = Convert.ToString(Session["fitblockwidth"]);
                    }
                    else
                    {
                        actResize.Width = Convert.ToInt32(hdnwidth.Value);
                        actResize.Height = Convert.ToInt32(hdnheight.Value);
                    }
                    uploadedImage.Actions.Add(actResize);
                    Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                    imgDraw.Elements.Add(uploadedImage);
                    imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                    imgDraw.JpegCompressionLevel = 100;
                    imgDraw.Save(TempFolderPath);
                    imgDraw.Dispose();
                    GC.Collect();
                    Session["MissionPersonRiskimgSize"] = actResize.Width + "_" + actResize.Height;
                    //duplicate image save
                    if (chkAddtoGallery.Checked == true)
                    {
                        uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(tempImagePath);
                        actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                        actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.None;
                        actResize.Width = Convert.ToInt32(hdnwidth.Value);
                        actResize.Height = Convert.ToInt32(hdnheight.Value);
                        uploadedImage.Actions.Add(actResize);
                        imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                        imgDraw.Elements.Add(uploadedImage);
                        imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                        imgDraw.JpegCompressionLevel = 100;
                        imgDraw.Save(savePath);
                        imgDraw.Dispose();
                        GC.Collect();
                    }
                    rVirtualPath = RootPath + "/Upload/Bulletins/" + FolderName + "/" + ProfileID.ToString() + "/" + TempSesPath + "/" + myString;
                }
                hdnResizeImageValue.Value = rVirtualPath;
                hdnClose.Value = "1";
                hdnCheck.Value = "";
                hdnChangeResize.Value = "";
                CheckWidth.Value = "";
                chkAddtoGallery.Checked = false;
                string changedImage = Session["Rsizeimagepath"].ToString();
                File.SetCreationTime(changedImage, DateTime.Now);

                if (File.Exists(tempImagePath))
                {
                    File.Delete(tempImagePath);
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CallModuleImageGallery.aspx.cs", "btnsubmit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnSaveResizeImage_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CallModuleImageGallery.aspx.cs", "btnSaveResizeImage_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                hdnCheck.Value = "1";
                SaveResizeImage();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CallModuleImageGallery.aspx.cs", "btnSaveResizeImage_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CallModuleImageGallery.aspx.cs", "btnSaveResizeImage_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                hdnClose.Value = "";
                hdnChangeResize.Value = "";
                Session["OrgImageName"] = null;
                GetBulletinImages();
                pnlallimage.Visible = true;
                pnlResize.Visible = false;
                hdnResizeImageValue.Value = "";
                hdnOrgDivDim.Value = "";
                chkAddtoGallery.Checked = false;

                Response.Clear();
                Response.ClearContent();
                Response.Clear();
                Response.Cache.SetExpires(DateTime.Now);
                GC.Collect();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CallModuleImageGallery.aspx.cs", "btnSaveResizeImage_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = "";
                GC.Collect();
                Response.Clear();
                Response.ClearContent();
                Response.Clear();
                Response.Cache.SetExpires(DateTime.Now);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //Log
                objInBuiltData.ErrorHandling("LOG", "CallModuleImageGallery.aspx.cs", "lnkDelete_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                for (int i = 0; i < DListBulletinImages.Items.Count; i++)
                {
                    CheckBox chkImage = DListBulletinImages.Items[i].FindControl("ChekImage") as CheckBox;
                    if (chkImage.Checked == true)
                    {
                        ImageButton imgChecked = DListBulletinImages.Items[i].FindControl("ImgUserImg") as ImageButton;
                        Label lblImageId = DListBulletinImages.Items[i].FindControl("lblImageId") as Label;
                        string deleteImagePath = string.Empty;
                        string thumbPath = string.Empty;
                        thumbPath = Path.GetFileName(imgChecked.ImageUrl);
                        int length = thumbPath.LastIndexOf('_');
                        if (length > 0)
                            deleteImagePath = thumbPath.Substring(0, length) + Path.GetExtension(thumbPath);
                        deleteImagePath = Server.MapPath("~") + "\\Upload\\CallModule\\" + ProfileID.ToString() + "\\" + UserModuleId + "\\" + deleteImagePath;
                        if (File.Exists(deleteImagePath))
                        {
                            File.Delete(deleteImagePath);
                        }

                        objCommonBLL.DeleteCallModuleProfileImage(Convert.ToInt32(lblImageId.Text), C_UserID);
                        thumbPath = Server.MapPath("~") + "\\Upload\\CallModule\\" + ProfileID.ToString() + "\\" + UserModuleId + "\\" + thumbPath;
                        if (File.Exists(thumbPath))
                            File.Delete(thumbPath);
                        System.Threading.Thread.Sleep(100);
                        Response.Clear();
                        Response.ClearContent();
                        Response.Clear();
                        Response.Cache.SetExpires(DateTime.Now);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
                lblerrormsg.Text = "<font color=green face=arial size=2><b>The selected image(s) were deleted successfully.</b></font>";
                GetBulletinImages();
                Response.Clear();
                Response.ClearContent();
                Response.Clear();
                Response.Cache.SetExpires(DateTime.Now);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                lblerrormsg.Text = "<font color=red face=arial size=2><b>We have encountered a problem while deleting your image(s). Please try again after some time.</b></font>";
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CallModuleImageGallery.aspx.cs", "lnkDelete_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void ResizeImage(string orgImageName)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "CallModuleImageGallery.aspx.cs", "ResizeImage", string.Empty, string.Empty, string.Empty, string.Empty);

                string tempFolderPath = Server.MapPath("~") + "\\Upload\\Bulletins\\" + FolderName + "\\" + ProfileID.ToString() + "\\" + TempSesPath;
                string unChangedImage = ".jpg";
                DateTime myDate = DateTime.Now;
                string myString = orgImageName + "_" + myDate.ToString("ddMMyyhhmmss") + unChangedImage;
                tempFolderPath = tempFolderPath + "\\" + myString;
                string tempImagePath = Server.MapPath("~") + "\\Upload\\tempbulletinswork\\" + FolderName + "\\" + ProfileID + Session["TempName"] + unChangedImage;
                Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(tempImagePath);
                Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
                actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.None;

                if (hdnheight.Value == string.Empty)
                {
                    using (FileStream fs = new FileStream(tempImagePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(fs))
                        {
                            fs.Flush();
                            fs.Close();
                            fs.Dispose();

                            hdnheight.Value = image.Height.ToString();
                            hdnwidth.Value = image.Width.ToString();
                        }
                    }
                }
                actResize.Width = Convert.ToInt32(hdnwidth.Value);
                actResize.Height = Convert.ToInt32(hdnheight.Value);
                uploadedImage.Actions.Add(actResize);
                Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                imgDraw.Elements.Add(uploadedImage);
                imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                imgDraw.JpegCompressionLevel = 100;

                imgDraw.Save(tempFolderPath);
                imgDraw.Dispose();

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CallModuleImageGallery.aspx.cs", "ResizeImage", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnSystemImages_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SystemImageGallery.aspx?fitblockwidth=" + Session["fitblockwidth"].ToString() + "&ModuleName=" + Session["ModuleName"].ToString() + "&Directory=" + Session["Directory"].ToString() + "&imgSrc=" + Session["imgSrc"].ToString()));
        }
    }
}