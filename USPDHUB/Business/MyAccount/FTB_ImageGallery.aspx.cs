using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;
using System.Configuration;

public partial class Business_MyAccount_FTB_ImageGallery : System.Web.UI.Page
{
    int profileID = 0;
    DataTable dtUserImages = new DataTable();
    public string TempFolderPath = string.Empty;
    public string TempSesPath = string.Empty;
    public string RootPath = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        lblerrormsg.Text = "";
        lblresizemess.Text = "&nbsp;";

        if (Session["ProfileID"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Javascript", "CloseModalPopup()", true);
        }
        else
        {
            if (Session["ProfileID"].ToString() != "")
            {
                profileID = Convert.ToInt32(Session["ProfileID"].ToString());
                TempSesPath = profileID.ToString();
            }
            if (Convert.ToString(Session["TemplateName"]) != "")
            {
                TempSesPath = Session["TemplateName"].ToString();
                TempSesPath = TempSesPath.Replace(" ", "");
            }
        }
        // *** Get Domain Name *** //
        RootPath = Session["RootPath"].ToString();
        if (Request.QueryString["fitblockwidth"] != null)
        {
            Session["fitblockwidth"] = Request.QueryString["fitblockwidth"];
        }       

        if (!IsPostBack)
        {
            pnlResize.Visible = false;
            pnlallimage.Visible = false;
            DeleteImagesForUser();
            Session["OrgImageName"] = null;
            hdnResizeImageValue.Value = "";
            hdnClose.Value = "";
            hdnCheck.Value = "";
            if (Session["ImgUrlvalue"] != null)
            {
                if (Session["ImgUrlvalue"].ToString() != "")
                {
                    pnlallimage.Visible = false;
                    pnlResize.Visible = true;
                    string currentLoadImgUrl = string.Empty;
                    Regex regex = new Regex("(?<first><img[\\s\\w]+?.*?src=[\"|'])(?<link>.*?)(?<last>[\"|'].*?[/]?>)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
                    Regex reSrc = new Regex(@"src=(?:(['""])(?<src>(?:(?!\1).)*)\1|(?<src>[^\s>]+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    MatchCollection results1 = regex.Matches(Session["ImgUrlvalue"].ToString());
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
                    Session["ImgUrlvalue"] = null;
                }
                else
                {
                    pnlallimage.Visible = true;
                    pnlResize.Visible = false;
                    GetUserImages();
                }
            }
            else
            {
                pnlResize.Visible = false;
                pnlallimage.Visible = true;
                GetUserImages();
            }
        }      
    }

    public void GetUserImages()
    {
        //User Images Path
        string userImagesVirtualPath = string.Empty;
        string orgImageLocation = string.Empty;
        string userImagesPath = Server.MapPath("~") + "/Upload/Common/" + profileID.ToString();
        if (!Directory.Exists(userImagesPath))
        {
            Directory.CreateDirectory(userImagesPath);
        }
        // We'll read all files from Images subfolder
        DirectoryInfo diFiles = new DirectoryInfo(userImagesPath);
        dtUserImages.Columns.Add("UserImagePath", typeof(string));
        dtUserImages.Columns.Add("UserImageDim", typeof(string));
        dtUserImages.Columns.Add("UserImageName", typeof(string));
        FileInfo[] fi = diFiles.GetFiles();
        foreach (FileInfo f in fi)
        {
            if (f.Name != "Thumbs.db")
            {
                string userImageName = f.Name;
                string userNameExt = f.Extension;
                userImageName = userImageName.Replace(userNameExt, "");
                if (userImageName.Length > 15)
                {
                    userImageName = userImageName.Remove(13);
                    userImageName = userImageName + "..";
                }
                userImagesVirtualPath = RootPath + "/Upload/Common/" + profileID.ToString() + "/" + f.Name.ToString();
                orgImageLocation = userImagesVirtualPath.Replace(RootPath, Server.MapPath("~"));
                orgImageLocation = orgImageLocation.Replace("/", "\\");
                try
                {
                    System.Drawing.Image imgname = System.Drawing.Image.FromFile(orgImageLocation);
                    DataRow drImages = dtUserImages.NewRow();
                    drImages["UserImagePath"] = userImagesVirtualPath;
                    drImages["UserImageDim"] = imgname.Width.ToString() + " x " + imgname.Height.ToString();
                    drImages["UserImageName"] = userImageName;
                    dtUserImages.Rows.Add(drImages);
                    imgname.Dispose();
                }
                catch
                {
                }
            }
        }
        DListUserImages.DataSource = dtUserImages;
        DListUserImages.DataBind();
        cbSelectAll.Checked = false;
        if (dtUserImages.Rows.Count > 0)
        {
            cbSelectAll.Visible = true;
        }
        else
        {
            cbSelectAll.Visible = false;
        }
    }

    protected void BtnUpload_Click(object sender, EventArgs e)
    {

        hdnCheck.Value = "";
        if (FUUserImages.HasFile)
        {
            string imageExtension = string.Empty;
            string imagename = txtimagname.Text;
            imagename = imagename.Replace(" ", "");
            imageExtension = Path.GetExtension(FUUserImages.FileName);
            if (imageExtension == ".jpg" || imageExtension == ".JPG" || imageExtension == ".JPEG" || imageExtension == ".jpeg" || imageExtension == ".GIF" || imageExtension == ".gif" || imageExtension == ".png" || imageExtension == ".PNG")
            {           
                imagename = imagename + imageExtension;
                string imagepath = string.Empty;
                string saveimagepath = string.Empty;
                if (Session["ProfileID"] != null)
                {
                    if (Session["ProfileID"].ToString() != "")
                    {
                        imagepath = Server.MapPath("~") + "\\Upload\\Common\\" + profileID.ToString();
                        if (Directory.Exists(imagepath))
                        {
                            saveimagepath = imagepath + "\\" + imagename;
                            FUUserImages.SaveAs(saveimagepath);
                        }
                        else
                        {
                            Directory.CreateDirectory(imagepath);
                            saveimagepath = imagepath + "\\" + imagename;
                            FUUserImages.SaveAs(saveimagepath);
                        }
                    }
                }
                GetUserImages();
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

    protected void ImgUserImg_Click(object sender, EventArgs e)
    {
        hdnClose.Value = "";
        hdnCheck.Value = "";
        Session["OrgImageName"] = null;
        ImageButton imgResizeButton = sender as ImageButton;
        ShowImageResizePanel(imgResizeButton.ImageUrl, "2");
    }

    private void ShowImageResizePanel(string rLoadImageUrl, string resize)
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
                rsizeimagepath = Server.MapPath("~") + "\\Upload\\Common\\" + profileID.ToString() + "\\" + rsizeimagepath;
            }
            else
            {
                rsizeimagepath = Server.MapPath("~") + "\\Upload\\Newsletters\\" + profileID.ToString() + "\\" + TempSesPath + "\\" + rsizeimagepath;
                if (!File.Exists(rsizeimagepath))
                {
                    rsizeimagepath = Server.MapPath("~") + "\\Upload\\Common\\" + profileID.ToString() + "\\" + rsizeimagepath;
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
            string tempSavePath = Server.MapPath("~") + "\\Upload\\tempnewswork\\" + profileID + "" + extension;
            rsizeimagepath = rsizeimagepath.Replace("%20", " ");
            FileInfo fisave = new FileInfo(rsizeimagepath);
            fisave.CopyTo(tempSavePath, true);
            tempSavePath = RootPath + "/Upload/tempnewswork/" + profileID + "" + extension + "?" + Guid.NewGuid();
            hdnResizeImageValue.Value = tempSavePath;
            FileStream fs = new FileStream(rsizeimagepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
            fs.Flush();
            fs.Close();
            fs.Dispose();


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
            pnlallimage.Visible = false;
            pnlResize.Visible = true;
            hdnOrgDivDim.Value = "1";
            lblload.Text = "";
        }
        else
        {
            pnlallimage.Visible = true;
            pnlResize.Visible = false;
            lblload.Text = "Your image is not available in the gallery. Please select again.";
            GetUserImages();

        }
    }

    public void SaveResizeImage()
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
            imageUrl = "\\Upload\\tempnewswork\\" + imageUrl;
            imageUrl = Server.MapPath("~") + (imageUrl);
            Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
            uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(imageUrl);
            Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
            actResize.Width = imageWidth;
            actResize.Height = imageHeight;
            actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.None;
            uploadedImage.Actions.Add(actResize);
            Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
            imgDraw.Elements.Add(uploadedImage);
            imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
            imgDraw.JpegCompressionLevel = 100;
            //We need to create a unique filename for each generated image        
            string myString = string.Empty;
            myString = profileID + Session["ImgExt"].ToString();
            //Save the thumbnail in PNG format. 
            //You may change it to a diff format with the ImageFormat property
            imageUrl = "\\Upload\\tempnewswork\\" + myString;
            imageUrl = Server.MapPath("~") + (imageUrl);
            imgDraw.Save(imageUrl);
            hdnResizeImageValue.Value = RootPath + "/Upload/tempnewswork/" + myString.ToString() + "?" + Guid.NewGuid();
            txtimageheight1.Value = hdnimgheight2.Value;
            txtimagewidth1.Value = hdnimgwidth2.Value;
            lblresizemess.Text = "The image has been resized to fit the block width.";

        }
        catch (Exception ex)
        {
            Response.Write("An error occurred - " + ex.ToString());
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string tempImagePath = string.Empty;
        string rVirtualPath = string.Empty;
        string myString = string.Empty;
        TempFolderPath = Server.MapPath("~") + "\\Upload\\Newsletters\\" + profileID.ToString() + "\\" + TempSesPath;
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
            myString = myString + "_" + myDate.ToString("ddMMyyhhmmss") + Session["ImgExt"].ToString();
            TempFolderPath = TempFolderPath + "\\" + myString;
            tempImagePath = Server.MapPath("~") + "\\Upload\\tempnewswork\\" + profileID + Session["ImgExt"].ToString();
            FileInfo fisave = new FileInfo(tempImagePath);
            rVirtualPath = RootPath + "/Upload/Newsletters/" + profileID.ToString() + "/" + TempSesPath + "/" + myString;
            fisave.CopyTo(TempFolderPath);
            FileStream fs = new FileStream(TempFolderPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
            fs.Flush();
            fs.Close();
            fs.Dispose();
            try
            {
                hdnwidth.Value = image.Width.ToString();
                hdnheight.Value = image.Height.ToString();
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
            TempFolderPath = TempFolderPath + "\\" + myString;
            tempImagePath = Server.MapPath("~") + "\\Upload\\tempnewswork\\" + profileID + unChangedImage;
            Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
            uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromFile(tempImagePath);
            Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();
            actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.None;
            if (hdnheight.Value == string.Empty)
            {
                FileStream fs = new FileStream(tempImagePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                fs.Flush();
                fs.Close();
                fs.Dispose();

                hdnheight.Value = image.Height.ToString();
                hdnwidth.Value = image.Width.ToString();
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
            rVirtualPath = RootPath + "/Upload/Newsletters/" + profileID.ToString() + "/" + TempSesPath + "/" + myString;
        }
        hdnResizeImageValue.Value = rVirtualPath;
        Session["OrgImageName"] = null;
        hdnClose.Value = "1";
        hdnCheck.Value = "";
        hdnChangeResize.Value = "";
        CheckWidth.Value = "";
        string changedImage = Session["Rsizeimagepath"].ToString();
        File.SetCreationTime(changedImage, DateTime.Now);
    }

    protected void btnSaveResizeImage_Click(object sender, EventArgs e)
    {
        hdnCheck.Value = "1";
        SaveResizeImage();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        hdnClose.Value = "";
        hdnChangeResize.Value = "";
        Session["OrgImageName"] = null;
        GetUserImages();
        pnlallimage.Visible = true;
        pnlResize.Visible = false;
        hdnResizeImageValue.Value = "";
        hdnOrgDivDim.Value = "";
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < DListUserImages.Items.Count; i++)
        {
            CheckBox chkImage = DListUserImages.Items[i].FindControl("ChekImage") as CheckBox;
            if (chkImage.Checked == true)
            {
                ImageButton imgChecked = DListUserImages.Items[i].FindControl("ImgUserImg") as ImageButton;
                string deleteImagePath = string.Empty;
                deleteImagePath = Path.GetFileName(imgChecked.ImageUrl);
                deleteImagePath = Server.MapPath("~") + "\\Upload\\Common\\" + profileID.ToString() + "\\" + deleteImagePath;

                if (File.Exists(deleteImagePath))
                {
                    File.Delete(deleteImagePath);
                }
                lblerrormsg.Text = "<font color=red face=arial size=2><b>The selected image(s) were deleted successfully.</b></font>";
            }
        }
        GetUserImages();
    }

    private void DeleteImagesForUser()
    {
        if (File.Exists(Server.MapPath("~") + "\\Upload\\Common\\" + profileID.ToString()))
        {
            string[] allImages = Directory.GetFiles(Server.MapPath("~") + "\\Upload\\Common\\" + profileID.ToString());
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
}