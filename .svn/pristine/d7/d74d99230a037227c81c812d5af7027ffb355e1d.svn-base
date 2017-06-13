using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web;

namespace CopyPaste_POC
{
    public partial class Bulletin_Imagegallery : System.Web.UI.Page
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public int C_UserID = 0;
        DataTable dtBulletinImages = new DataTable();
        public string TempFolderPath = string.Empty;
        public string TempSesPath = string.Empty;
        public string FolderName = "Templates";


        public string RootPath = ConfigurationManager.AppSettings.Get("RootPath");

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
 
                 
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
                            TempSesPath = TempSesPath.Remove(TempSesPath.Length - 1);
                    }
                }
                if (Request.QueryString["fitblockwidth"] != null)
                    Session["fitblockwidth"] = Request.QueryString["fitblockwidth"];
                if (Request.QueryString["imgSrc"] != null)
                    Session["imgSrc"] = Request.QueryString["imgSrc"];
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

                            //Display Image Resizer Panel
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
                        //Display Image Gallery Panel
                        pnlallimage.Visible = true;
                        GetBulletinImages();

                    }
                }
            }
            catch (Exception ex)
            {
                 
            }
        }
        public void GetBulletinImages()
        {
            try
            {
                //User Images Path
                string bulletinImagesVirtualPath = string.Empty;
                string orgImageLocation = string.Empty;
                string bulletinImagesPath = Server.MapPath("~") + "/Upload/Common/" + ProfileID.ToString();

                if (!Directory.Exists(bulletinImagesPath))
                {
                    Directory.CreateDirectory(bulletinImagesPath);
                }
                // We'll read all files from Images subfolder
                DirectoryInfo diFiles = new DirectoryInfo(bulletinImagesPath);
                dtBulletinImages.Columns.Add("BulletinImagePath", typeof(string));
                dtBulletinImages.Columns.Add("BulletinImageDim", typeof(string));
                dtBulletinImages.Columns.Add("BulletinImageName", typeof(string));
                FileInfo[] fi = diFiles.GetFiles();
                //int length = Convert.ToInt32(fi.Length.ToString());
                //string imgname = fi[length - 1].Name.ToString();
                foreach (FileInfo f in fi)
                {
                    if (f.Name != "Thumbs.db")
                    {
                        string userImageName = f.Name;
                        string userNameExt = f.Extension;
                        if (userNameExt != "")
                            userImageName = userImageName.Replace(userNameExt, "");
                        if (userImageName.Length > 15)
                        {
                            userImageName = userImageName.Remove(13);
                            userImageName = userImageName + "..";
                        }
                        bulletinImagesVirtualPath = RootPath + "/Upload/Common/" + ProfileID.ToString() + "/" + f.Name.ToString();
                        orgImageLocation = bulletinImagesVirtualPath.Replace(RootPath, Server.MapPath("~"));
                        orgImageLocation = orgImageLocation.Replace("/", "\\");
                        try
                        {
                            System.Drawing.Image imgname = System.Drawing.Image.FromFile(orgImageLocation);
                            DataRow drImages = dtBulletinImages.NewRow();
                            drImages["BulletinImagePath"] = bulletinImagesVirtualPath;// +"?guid=" + System.Guid.NewGuid();
                            drImages["BulletinImageDim"] = imgname.Width.ToString() + " x " + imgname.Height.ToString();
                            drImages["BulletinImageName"] = userImageName;
                            dtBulletinImages.Rows.Add(drImages);
                        }
                        catch
                        {
                        }
                    }
                }
                DListBulletinImages.DataSource = dtBulletinImages;
                DListBulletinImages.DataBind();

                cbSelectAll.Checked = false;
                if (dtBulletinImages.Rows.Count > 0)
                {
                    cbSelectAll.Visible = true;
                }
                else
                {
                    cbSelectAll.Visible = false;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        private void DeleteBulletinImages()
        {
            try
            {
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
                            File.Delete(fileName);
                        }
                    }
                }
                cbSelectAll.Checked = false;

            }
            catch (Exception ex)
            {
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
                                //imagename = GetUserProfileImageName(imagename, imageExtension);
                                imagepath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString();
                                if (!Directory.Exists(imagepath))
                                    Directory.CreateDirectory(imagepath);
                                saveimagepath = imagepath + "\\" + imagename + imageExtension;
                                FUUserImages.SaveAs(saveimagepath);
                            }
                        }
                        GetBulletinImages();
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
                 }
        }
        
        protected void ImgUserImg_Click(object sender, EventArgs e)
        {
            try
            {
              hdnClose.Value = "";
                hdnCheck.Value = "";
                Session["OrgImageName"] = null;
                ImageButton imgResizeButton = sender as ImageButton;
                ShowImageResizePanel(imgResizeButton.ImageUrl, "2");
            }
            catch (Exception ex)
            {
                 }
        }
        private void ShowImageResizePanel(string rLoadImageUrl, string resize)
        {
            try
            {
               
                string rsizeimagepath = string.Empty;
                rsizeimagepath = Path.GetFileName(rLoadImageUrl);
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
                        rsizeimagepath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString() + "\\" + rsizeimagepath;
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
                    string tempSavePath = "";
                    Session["TempName"] = "_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;

                    //Create Temp folder for Commonwork
                    string tempbulletinswork = Server.MapPath("~") + "/Upload/tempbulletinswork/" + FolderName + "/";
                    if (!Directory.Exists(tempbulletinswork))
                    {
                        Directory.CreateDirectory(tempbulletinswork);
                    }

                    tempSavePath = Server.MapPath("~") + "\\Upload\\tempbulletinswork\\" + FolderName + "\\" + ProfileID + Session["TempName"] + "" + extension;
                    rsizeimagepath = rsizeimagepath.Replace("%20", " ");


                    FileInfo fisave = new FileInfo(rsizeimagepath);
                    fisave.CopyTo(tempSavePath, true);
                    //
                    tempSavePath = RootPath + "/Upload/tempbulletinswork/" + FolderName + "/" + ProfileID + Session["TempName"] + "" + extension + "?" + Guid.NewGuid();

                    hdnResizeImageValue.Value = tempSavePath;
                    using (FileStream fs = new FileStream(rsizeimagepath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(fs))
                        {
                            //GETTING BLOCK SIZE 
                            rbfittoblock.Text = "Fit to width <strong>" + Session["fitblockwidth"].ToString() + "px X " + image.Height.ToString() + "px</strong>";
                            //

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

                    //  lblload.Text = "Your image is not available in the gallery. Please select again.";
                    GetBulletinImages();

                }
            }
            catch (Exception ex)
            {
                  
            }
        }
        public void SaveResizeImage()
        {
            try
            {
                
                //thumbnail creation starts
                try
                {
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
                    string myString = ProfileID + Session["TempName"].ToString() + Session["ImgExt"].ToString();
                    using (Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw())
                    {
                        imgDraw.Elements.Add(uploadedImage);
                        imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                        imgDraw.JpegCompressionLevel = 100;
                        //We need to create a unique filename for each generated image    
                        //Save the thumbnail in PNG format. 
                        //You may change it to a diff format with the ImageFormat property
                        imageUrl = "\\Upload\\tempbulletinswork\\" + FolderName + "\\" + myString;
                        imageUrl = Server.MapPath("~") + (imageUrl);
                        imgDraw.Save(imageUrl);
                    }
                    hdnResizeImageValue.Value = RootPath + "/Upload/tempbulletinswork/" + FolderName + "/" + myString.ToString() + "?" + Guid.NewGuid();

                    //For Width Based image resize after getting img Height
                    if (imageWidth >= Convert.ToInt32(CheckWidth.Value))
                    {
                        try
                        {
                            using (FileStream fs = new FileStream(imageUrl, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                using (System.Drawing.Image image = System.Drawing.Image.FromStream(fs))
                                {
                                    txtimageheight2.Text = image.Height.ToString();
                                    hdnimgheight2.Value = image.Height.ToString();

                                    rbfittoblock.Text = "Fit to width <strong>" + Session["fitblockwidth"].ToString() + "px X " + image.Height.ToString() + "px</strong>";
                                }
                            }
                            GC.Collect();
                        }
                        catch (Exception /*ex*/)
                        {
                        }
                    }

                    txtimageheight1.Value = hdnimgheight2.Value;
                    txtimagewidth1.Value = hdnimgwidth2.Value;
                    lblresizemess.Text = "The image has been resized to fit the block width.";

                }
                catch (Exception ex)
                {
                    Response.Write("An error occurred - " + ex.ToString());
                }
            }
            catch (Exception ex)
            {
                 }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
               
                string savePath = string.Empty;
                string tempImagePath = string.Empty;
                string rVirtualPath = string.Empty;
                string myString = string.Empty;
                //
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

                    //MyString = MyString.Replace(" ", "");
                    myString = myString + "_" + myDate.ToString("ddMMyyhhmmss") + Session["ImgExt"].ToString();
                    savePath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID + "\\" + myString;
                    TempFolderPath = TempFolderPath + "\\" + myString;

                    //
                    tempImagePath = Server.MapPath("~") + "\\Upload\\tempbulletinswork\\" + FolderName + "\\" + ProfileID + Session["TempName"] + Session["ImgExt"].ToString();
                    try
                    {
                        FileInfo fisave = new FileInfo(tempImagePath);
                        rVirtualPath = RootPath + "/Upload/Bulletins/" + FolderName + "/" + ProfileID.ToString() + "/" + TempSesPath + "/" + myString;
                        fisave.CopyTo(TempFolderPath);
                        if (chkAddtoGallery.Checked == true)
                        {
                            fisave.CopyTo(savePath);
                        }
                        using (FileStream fs = new FileStream(TempFolderPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                            hdnwidth.Value = image.Width.ToString();
                            hdnheight.Value = image.Height.ToString();
                        }
                        GC.Collect();
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

                    savePath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID + "\\" + myString;
                    TempFolderPath = TempFolderPath + "\\" + myString;

                    //
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
                        GC.Collect();
                    }

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
            }
            catch (Exception ex)
            {
                }
        }
        protected void btnSaveResizeImage_Click(object sender, EventArgs e)
        {
            try
            {
               
                hdnCheck.Value = "1";
                SaveResizeImage();
            }
            catch (Exception ex)
            {
                }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            try
            {
              
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
                 }
        }
        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            try
            {
                GC.Collect();
                Response.Clear();
                Response.ClearContent();
                Response.Clear();
                Response.Cache.SetExpires(DateTime.Now);
                GC.Collect();
                GC.WaitForPendingFinalizers();
               
                for (int i = 0; i < DListBulletinImages.Items.Count; i++)
                {
                    CheckBox chkImage = DListBulletinImages.Items[i].FindControl("ChekImage") as CheckBox;
                    if (chkImage.Checked == true)
                    {
                        ImageButton imgChecked = DListBulletinImages.Items[i].FindControl("ImgUserImg") as ImageButton;
                        string deleteImagePath = string.Empty;
                        deleteImagePath = Path.GetFileName(imgChecked.ImageUrl);
                        deleteImagePath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString() + "\\" + deleteImagePath;
                        if (File.Exists(deleteImagePath))
                        {
                            File.Delete(deleteImagePath);
                            // *** Delete goes here ***//
                            System.Threading.Thread.Sleep(100);
                            Response.Clear();
                            Response.ClearContent();
                            Response.Clear();
                            Response.Cache.SetExpires(DateTime.Now);
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }
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
                }
        }
        private void ResizeImage(string orgImageName)
        {
            try
            {
                
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
                GC.Collect();

            }
            catch (Exception ex)
            {
                 }
        }
    }
}