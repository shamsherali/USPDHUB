using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using USPDHUBBLL;
using System.Drawing;
using ideaBubbling.FlvConverter;
using System.Text.RegularExpressions;
using System.Xml;
using Winnovative.WnvHtmlConvert;
using System.Text;
using System.Drawing.Imaging;
using Neodynamic.WebControls.ImageDraw;


public partial class Business_MyAccount_ManagePhotosAlbum : BaseWeb
{
    public int UserID = 0;
    public int C_UserID = 0;
    public int ProfileID = 0;
    public int ImageSizeFlag = 0;
    public string SmallFilename = string.Empty;
    bool PrimaryImageFlag = true;
    DataTable dtobj = new DataTable();
    BusinessBLL busobj = new BusinessBLL();
    USPDHUBBLL.UtilitiesBLL utlObj = new USPDHUBBLL.UtilitiesBLL();
    public bool CheckMobileApp = true;
    public static DataTable dtpermissions = new DataTable();
    AgencyBLL agencyobj = new AgencyBLL();
    CommonBLL objCommon = new CommonBLL();
    public string RootPath = "";
    public string DomainName = "";
    public string titleName = "";
    int intGalleryOrder = 1;
    USPDHUBBLL.MobileAppSettings objApp = new USPDHUBBLL.MobileAppSettings();

    BusinessBLL BusObj = new BusinessBLL();
    AddOnBLL objAddOn = new AddOnBLL();
    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            lblPhotoMsg.Text = "";
            if (Session["UserName"] == null)
                Response.Redirect(Page.ResolveClientUrl("~/login.aspx?sflag=1"));
            else
            {
                UserID = Convert.ToInt32(Session["UserID"]);
                if (Session["ProfileID"] != null)
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);

                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    C_UserID = UserID;
            }
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            titleName = objApp.GetMobileAppSettingTabName(UserID, "Gallery", DomainName);
            lblTitle.Text = titleName;

            if (!IsPostBack)
            {
                lblOff.Visible = true;
                if (objCommon.DisplayOn_OffSettingsContent(UserID, "Gallery"))
                {
                    lblOn.Visible = true;
                    lblOff.Visible = false;
                }

                // *** Adding page title and meta keys for page *** //
                DataTable dtConfigPageKeys = objCommon.GetVerticalConfigsByType(DomainName, "VerticalNames");
                if (dtConfigPageKeys.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigPageKeys.Rows)
                    {
                        if (row[0].ToString() == "NameForDisplay")
                            hdnVerticalName.Value = row[1].ToString();
                    }
                }

                //rbGalleryOrder.SelectedValue = objCommon.DisplayOrderType(UserID, "Gallery");
                //intGalleryOrder = Convert.ToInt32(rbGalleryOrder.SelectedValue);
                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Gallery");
                    if (hdnPermissionType.Value == "" || hdnPermissionType.Value == "A")
                        Response.Redirect("Default.aspx");
                }
                //ends here
                hdnGallerySelectedOrder.Value = objCommon.DisplayOrderType(UserID, "Gallery");
                intGalleryOrder = Convert.ToInt32(hdnGallerySelectedOrder.Value);

                if (hdnGallerySelectedOrder.Value == "1" || hdnGallerySelectedOrder.Value == "3")
                {
                    rbGalleryOrder.SelectedValue = hdnGallerySelectedOrder.Value;
                    rbBydate.Checked = true;
                }
                else
                {
                    rbByCustom.Checked = true;
                }
                filldata();
                dtobj = busobj.GetProfilePhotosByProfileID(ProfileID);
            }
            BtnDelePhoto.Attributes.Add("onclick", " return alertMe();");

            if (Session["image"] != null)
            {
                btnAddToGooglePlaces.Visible = true;
                Session["image"] = null;
            }
            //intGalleryOrder = Convert.ToInt32(rbGalleryOrder.SelectedValue);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>CallingLightBox()</script>", false);

        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "ManagePhotosAlbum.aspx.cs", "Page_Load", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    # region Update Photo

    protected void dtlistphotos_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            string uploadphotosPath = RootPath + "/Upload/Photos/" + ProfileID + "/";
            Label lblphotoId1 = e.Item.FindControl("lblphotoId") as Label;
            Label lblpnum = e.Item.FindControl("lblpnum") as Label;
            Label lblphpath = e.Item.FindControl("lblppath") as Label;
            Label lbldesc = e.Item.FindControl("lbldesc") as Label;

            Label lblprimary = e.Item.FindControl("lblprimary") as Label;
            Label lblppreview = e.Item.FindControl("imgpreview") as Label;
            Label lblhiddenorder = e.Item.FindControl("lblhiddenorder") as Label;
            Label lblOrder = e.Item.FindControl("lblOrder") as Label;
            if (lblhiddenorder.Text.Trim() == "0.0")
            {
                lblOrder.Text = "";
            }
            else
            {
                lblOrder.Text = lblOrder.Text + " " + lblhiddenorder.Text;
            }
            string photoid = lblphotoId1.Text;
            string photonum = lblpnum.Text;
            string photopath = lblphpath.Text;
            string originalfilename = photopath;
            string extension = System.IO.Path.GetExtension(Server.MapPath(originalfilename));
            string description = lbldesc.Text;
            string photodesc = lbldesc.Text;
            string desclimit = string.Empty;
            if (lblprimary.Text.Length > 0)
            {
                if (Convert.ToBoolean(lblprimary.Text) == true)
                {
                    lblprimary.Text = "Homepage Image";
                    hdnHomepage.Value = "1";
                    hdnHomePageID.Value = photoid;
                }
                else
                {
                    lblprimary.Text = "";
                }
            }
            if (description.Length > 22)
            {
                description = description.Remove(19);
                description = description.Insert(19, "...");
                description = description.Insert(22, "<br/>");
                string title = string.Empty;
                title = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                title = title + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                title = title + " <img src='" + RootPath + "/images/more.gif' title='" + photodesc.Replace("'", "&#39;") + "'/>";
                description = description.Insert(27, title);
            }
            lbldesc.Text = description;
            string junk = ".";
            string[] ret = originalfilename.Split(junk.ToCharArray());
            string thumbimg1 = ret[0];
            string BigImage = string.Empty;
            BigImage = uploadphotosPath + photopath;
            thumbimg1 = thumbimg1 + "_thumb" + extension;
            string ThumbImage = uploadphotosPath + thumbimg1 + "?" + Guid.NewGuid();
            string url = Server.MapPath("~") + "\\Upload\\Photos\\" + ProfileID + "\\" + thumbimg1;
            FileInfo obj4 = new FileInfo(url);
            if (obj4.Exists)
            {
                string ImageDisID = Guid.NewGuid().ToString();
                lblppreview.Text = "<a href='" + BigImage + "' title='" + photodesc.Replace("'", "&#39;") + "'><img src=" + ThumbImage + "/></a>";
            }
            else
            {
                string ImageDisID = Guid.NewGuid().ToString();
                lblppreview.Text = "";
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "ManagePhotosAlbum.aspx.cs", "dtlistphotos_ItemDataBound", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void BtnUpdatePhoto_Click(object sender, EventArgs e)
    {
        try
        {
            bool isfree = false;
            if (Session["Free"] != null)
            {
                isfree = true;
            }
            dtobj = busobj.GetProfilePhotosByProfileID(ProfileID);
            if ((isfree == true && dtobj.Rows.Count < 5) || isfree == false)
            {
                if (Picture1.PostedFile != null)
                {
                    if (Picture1.PostedFile.FileName.ToString().Length > 1)
                    {
                        //if (Picture1.PostedFile.ContentLength <= 2097152)
                        //{
                        FileInfo pict1obj = new FileInfo(Picture1.PostedFile.FileName);
                        if (pict1obj.Extension == ".jpg" || pict1obj.Extension == ".JPG" || pict1obj.Extension == ".JPEG" || pict1obj.Extension == ".jpeg" || pict1obj.Extension == ".GIF" || pict1obj.Extension == ".gif" || pict1obj.Extension == ".bmp" || pict1obj.Extension == ".BMP" || pict1obj.Extension == ".png" || pict1obj.Extension == ".PNG")
                        {
                            DataView SortDt = new DataView(dtobj);
                            SortDt.Sort = "Photo_Num DESC";
                            dtobj = SortDt.ToTable();
                            int Photonum = 0;
                            decimal imageOrderNo = 0.0M;
                            if (dtobj.Rows.Count > 0)
                            {
                                Photonum = Convert.ToInt32(dtobj.Rows[0]["Photo_Num"].ToString());
                            }
                            Photonum = Photonum + 1;

                            //start Balaji Date 20-06-2012, For Image Order Number
                            DataView SortDt1 = new DataView(dtobj);
                            SortDt1.Sort = "Image_OrderNo DESC";
                            dtobj = SortDt1.ToTable();

                            if (dtobj.Rows.Count > 0)
                            {
                                imageOrderNo = Convert.ToDecimal(dtobj.Rows[0]["Image_OrderNo"].ToString().Split(".".ToCharArray())[0].ToString());
                            }
                            imageOrderNo = imageOrderNo + 1;

                            //end

                            bool primary = false;
                            if (ckbprimaryphoto.Checked == true)
                            {
                                primary = true;

                                chkbxImgPublicPrivate.Checked = true;
                                busobj.UpdatePhotoPrimaryflagByProfileID(ProfileID, true, C_UserID);
                                imageOrderNo = 0.0M;
                            }
                            else
                            {
                                if (txtOrderNumber.Text.Trim() != string.Empty)
                                {
                                    imageOrderNo = Convert.ToDecimal(txtOrderNumber.Text.Trim());
                                }
                            }

                            Session["imgCaption"] = picture1Text.Text;
                            UploadAndSaveFile(Picture1, 2, string.Empty, primary, Photonum, picture1Text.Text, imageOrderNo); // 2 for photos
                            Response.ContentType = "text/HTML";



                            if (ImageSizeFlag == 0)
                            {
                                lblPhotoMsg.Text = "<font color=green face=arial size=2><b>Your image has been uploaded successfully.</b></font>";
                                ckbprimaryphoto.Checked = false;
                                busobj.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "ImageGallery", "Upload");
                            }
                            else if (ImageSizeFlag == 3)
                            {
                                return;
                            }
                            else
                            {
                                string urlvalue = RootPath + "/showimag.aspx?Na=" + SmallFilename + "&PID=" + ProfileID;
                                ScriptManager.RegisterClientScriptBlock(lblPhotoMsg, this.GetType(), "Open", "window.open('" + urlvalue + "','coupon','toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,height=500,width=500')", true);
                            }

                        }
                        else
                        {
                            string errormsg = "<b>Your image is not in the correct file format. Please note the image requirements and try again.</b>";
                            lblPhotoMsg.Text = "<font color=red face=arial size=2>" + errormsg + "</font>";
                        }
                        //}
                        //else
                        //{
                        //    lblPhotoMsg.Text = "<font color=red face=arial size=2>Your file was not uploaded because it exceeds the 2 MB size limit.</font>";
                        //}
                    }
                    else
                    {
                        lblPhotoMsg.Text = "<font color=red face=arial size=2>Please select a photo to upload.</font>";
                    }
                }
                else
                {
                    lblPhotoMsg.Text = "<font color=red face=arial size=2>Please select a photo to upload.</font>";
                }
            }
            ckbprimaryphoto.Checked = false;
            picture1Text.Text = "";
            txtOrderNumber.Text = "";
            filldata();

        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "ManagePhotosAlbum.aspx.cs", "BtnUpdatePhoto_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void Btnupdateprimaryflag_Click(object sender, EventArgs e)
    {
        try
        {
            int UFlag;
            foreach (DataListItem row1 in dtlistphotos.Items)
            {
                HtmlInputCheckBox chk1 = row1.FindControl("chk") as HtmlInputCheckBox;
                //  CheckBox chk1 = row1.FindControl("chk") as CheckBox;
                if (((HtmlInputCheckBox)row1.FindControl("chk")).Checked)
                {
                    int photoID = int.Parse(dtlistphotos.DataKeys[row1.ItemIndex].ToString());
                    UFlag = busobj.UpdatePhotoPrimaryflagbyPhotoID(photoID, true, ProfileID, C_UserID);
                    chkbxImgPublicPrivate.Checked = true;
                    break;
                }
            }
            if (chkbxImgPublicPrivate.Checked == true)
            {
                PrimaryImageFlag = true;
            }
            else
            {
                PrimaryImageFlag = false;
                UFlag = busobj.UpdatePhotoPrimaryflagbyPhotoID(int.Parse(hdnHomePageID.Value), false, ProfileID, C_UserID);
                hdnHomepage.Value = "0";
                hdnHomePageID.Value = "0";
            }
            busobj.UpdatePhotoPrimaryflagByProfileID(ProfileID, PrimaryImageFlag, C_UserID);
            lblPhotoMsg.Text = "<font color=green face=arial size=2><b>Your Homepage settings have been saved successfully.</b></font>";

        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "ManagePhotosAlbum.aspx.cs", "Btnupdateprimaryflag_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        filldata();
    }

    protected void BtnVieworEdit_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (DataListItem row1 in dtlistphotos.Items)
            {
                HtmlInputCheckBox chk1 = row1.FindControl("chk") as HtmlInputCheckBox;
                if (((HtmlInputCheckBox)row1.FindControl("chk")).Checked)
                {

                    int photoID = int.Parse(dtlistphotos.DataKeys[row1.ItemIndex].ToString());
                    DataTable dtphotodetails = new DataTable();
                    dtphotodetails = busobj.GetPhotodetailsByPhotoID(photoID);
                    string desc = string.Empty;

                    if (dtphotodetails.Rows.Count > 0)
                    {
                        desc = dtphotodetails.Rows[0]["Photo_Desc"].ToString();
                    }

                    txtphotodesc.Text = desc;
                    ModalPopupExtender2.Show();
                    btnupdate.CommandArgument = photoID.ToString();
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "ManagePhotosAlbum.aspx.cs", "BtnVieworEdit_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    # endregion

    # region Dispaly Photos
    protected void filldata()
    {
        bool isfree = false;
        if (Session["Free"] != null)
        {
            isfree = true;
        }
        pnlphotos.Enabled = true;
        intGalleryOrder = Convert.ToInt32(hdnGallerySelectedOrder.Value);
        dtobj = busobj.GetProfilePhotosByProfileID(ProfileID, intGalleryOrder);
        if (isfree == true)
        {
            if (dtobj.Rows.Count >= 5)
            {
                pnlphotos.Enabled = false;
            }
        }
        if (dtobj.Rows.Count > 0)
        {
            BtnDelePhoto.Visible = true;
            BtnVieworEdit.Visible = true;
            btnEditOrderNumber.Visible = true;
            Btnupdateprimaryflag.Visible = true;
            lblCount.Text = dtobj.Rows.Count.ToString();
        }
        else
        {
            BtnDelePhoto.Visible = false;
            BtnVieworEdit.Visible = false;
            btnEditOrderNumber.Visible = false;
            Btnupdateprimaryflag.Visible = false;
        }
        dtlistphotos.DataSource = null;
        dtlistphotos.DataSource = dtobj;
        dtlistphotos.DataBind();

        int MaxOrderNumber = busobj.GetMaxImageOrderNo(ProfileID);
        txtOrderNumber.Text = MaxOrderNumber.ToString();
        maxordernumber.Value = MaxOrderNumber.ToString();
        ckbprimaryphoto.Checked = false;
        if (hdnHomepage.Value == "1")
            btnRemoveHomeImg.Visible = true;
        else
            btnRemoveHomeImg.Visible = false;

    }
    # endregion

    # region Delete Photo
    protected void BtnDelePhoto_Click(object sender, EventArgs e)
    {
        try
        {
            string strlogoPath = Server.MapPath("~") + "\\Upload\\Photos\\" + ProfileID + "\\";
            string StrFileName = string.Empty;
            string StrFileName1 = string.Empty;
            string photourl = string.Empty;
            string PhotoName = string.Empty;
            string selectexp = string.Empty;
            foreach (DataListItem row1 in dtlistphotos.Items)
            {
                HtmlInputCheckBox chk1 = row1.FindControl("chk") as HtmlInputCheckBox;
                if (((HtmlInputCheckBox)row1.FindControl("chk")).Checked)
                {
                    Label lblpath = row1.FindControl("lblppath") as Label;
                    Label lblid = row1.FindControl("lbl") as Label;
                    int photoID = int.Parse(dtlistphotos.DataKeys[row1.ItemIndex].ToString());
                    Label lblhiddenorder = row1.FindControl("lblhiddenorder") as Label;
                    decimal imgOrderNo = 0.0M;
                    if (lblhiddenorder.Text.Trim() == string.Empty)
                    {
                        imgOrderNo = 0.0M;
                    }
                    else
                    {
                        imgOrderNo = Convert.ToDecimal(lblhiddenorder.Text.Trim());
                    }

                    int UFlag = busobj.ManageBusinessProfilePhotos(ProfileID, string.Empty, 1, string.Empty, false, true, UserID, photoID, 2, picture1Text.Text, imgOrderNo, C_UserID);
                    PhotoName = lblpath.Text;
                    string extension = System.IO.Path.GetExtension(Server.MapPath(PhotoName));
                    string junk = ".";
                    string[] ret = PhotoName.Split(junk.ToCharArray());
                    string thumbimg = ret[0];
                    thumbimg = thumbimg + "_thumb" + extension;
                    StrFileName = strlogoPath + PhotoName;
                    StrFileName1 = strlogoPath + thumbimg;
                    if (System.IO.File.Exists(StrFileName))
                    {
                        System.IO.File.Delete(StrFileName);
                    }
                    if (System.IO.File.Exists(StrFileName1))
                    {
                        System.IO.File.Delete(StrFileName1);
                    }
                    lblPhotoMsg.Text = "<font color=red face=arial size=2><b>The selected image(s) were deleted successfully.</b></font>";
                    busobj.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "ImageGallery", "Delete");
                }
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "ManagePhotosAlbum.aspx.cs", "BtnDelePhoto_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        filldata();
        ScriptManager.RegisterClientScriptBlock(BtnDelePhoto, this.GetType(), "ClientScriptFunction", "displaypanel()", true);



    }

    # endregion

    private void UploadAndSaveFile(FileUpload File, int imagetype, string Imagetext, bool primary, int imageno, string imagedesc, decimal imageOrderNo)
    {
        try
        {
            USPDHUBBLL.UtilitiesBLL utlObj = new USPDHUBBLL.UtilitiesBLL();
            string currenttime = DateTime.Now.Millisecond.ToString() + DateTime.Now.Ticks.ToString();
            try
            {
                string SaveFilePath = Server.MapPath("~") + "\\Upload";
                string FolderPath = string.Empty;
                if (imagetype == 2) //Photos folder
                    FolderPath = SaveFilePath + "\\Photos\\" + ProfileID;

                if (!System.IO.Directory.Exists(FolderPath))
                {
                    System.IO.Directory.CreateDirectory(FolderPath);
                }
                string tempfolder = FolderPath = SaveFilePath + "\\tempnewsletter\\" + ProfileID;
                if (!System.IO.Directory.Exists(tempfolder))
                {
                    System.IO.Directory.CreateDirectory(tempfolder);
                }
                if (imagetype == 2)
                {
                    int Height = 0;
                    int Width = 0;
                    using (System.Drawing.Image myImage = System.Drawing.Image.FromStream(File.PostedFile.InputStream))
                    {
                        Height = myImage.Height;
                        Width = myImage.Width;
                    }
                    if (Width >= 320)
                    {
                        Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;
                        uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromBinary(this.Picture1.FileBytes);
                        Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();

                        int maxPhotWidth = Convert.ToInt32(ConfigurationManager.AppSettings.Get("MaxPhotAlbumPhotoWidth"));
                        if (Width > maxPhotWidth)
                        {
                            actResize.Width = maxPhotWidth;
                            actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.WidthBased;

                            uploadedImage.Actions.Add(actResize);
                            Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                            imgDraw.Elements.Add(uploadedImage);
                            imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                            imgDraw.JpegCompressionLevel = 100;
                            string fileName1 = Server.MapPath("~/tempimages/") + currenttime + ".jpg";
                            imgDraw.Save(fileName1);
                            Session["currenttime"] = currenttime;

                            FileStream fs = new FileStream(fileName1, FileMode.Open, FileAccess.Read, FileShare.Read);
                            System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                            fs.Flush();
                            fs.Close();
                            fs.Dispose();
                            objCommon.GetImageRotateFlipByPath(fileName1, fileName1, false);
                            //lblResizeImageWidth.Text = "This image resized by Width:" + image.Width + "px   Height:" + image.Height + "px";
                            lblimgpreview.Text = "<img src='" + RootPath + "/tempimages/" + currenttime + ".jpg' />";
                            popupResizeImagepreview.Show();
                            ImageSizeFlag = 3;

                        }

                        //if (Width > 580)
                        //{
                        //    actResize.Width = 580;
                        //    actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.WidthBased;
                        //}
                        //else
                        //{
                        //    actResize.Width = Width;
                        //    actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.WidthBased;
                        //}                    
                        else
                        {
                            actResize.Width = Width;
                            actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.WidthBased;

                            uploadedImage.Actions.Add(actResize);
                            Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                            imgDraw.Elements.Add(uploadedImage);
                            imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                            imgDraw.JpegCompressionLevel = 100;
                            string fileName1 = Server.MapPath("~/Upload/Photos/") + ProfileID + "/" + ProfileID + "_" + imageno + "_" + currenttime + ".jpg";
                            imgDraw.Save(fileName1);
                            Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage2;
                            uploadedImage2 = Neodynamic.WebControls.ImageDraw.ImageElement.FromBinary(this.Picture1.FileBytes);
                            Neodynamic.WebControls.ImageDraw.Resize actResize2 = new Neodynamic.WebControls.ImageDraw.Resize();
                            actResize2.Width = 150;
                            actResize2.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.WidthBased;
                            uploadedImage2.Actions.Add(actResize2);
                            Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw2 = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                            imgDraw2.Elements.Add(uploadedImage2);
                            imgDraw2.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                            imgDraw2.JpegCompressionLevel = 100;
                            string fileName2 = Server.MapPath("~/Upload/Photos/") + ProfileID + "/" + ProfileID + "_" + imageno + "_" + currenttime + "_thumb.jpg";
                            imgDraw2.Save(fileName2);
                            objCommon.GetImageRotateFlipByPath(fileName2, fileName2, false);
                        }
                    }
                    else
                    {
                        // Convert Small Image into specified size
                        Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage1;
                        uploadedImage1 = Neodynamic.WebControls.ImageDraw.ImageElement.FromBinary(this.Picture1.FileBytes);
                        SmallFilename = System.IO.Path.GetFileNameWithoutExtension(Picture1.PostedFile.FileName.Replace(" ", ""));
                        SmallFilename = SmallFilename + ".jpg";
                        Neodynamic.WebControls.ImageDraw.Resize actResize1 = new Neodynamic.WebControls.ImageDraw.Resize();
                        //actResize1.Height = 300;
                        //actResize1.Width = 400;
                        actResize1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        actResize1.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.None;
                        uploadedImage1.Actions.Add(actResize1);
                        Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw1 = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                        imgDraw1.Elements.Add(uploadedImage1);
                        imgDraw1.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                        imgDraw1.JpegCompressionLevel = 90;
                        Neodynamic.WebControls.ImageDraw.MakeTransparent makeTransparent = new Neodynamic.WebControls.ImageDraw.MakeTransparent();
                        makeTransparent.ColorTolerance = 0;
                        string fileName1 = Server.MapPath("~/tempimages/") + SmallFilename;
                        imgDraw1.Save(fileName1);
                        ImageSizeFlag = 1;
                    }
                }


                int UFlag = 0;

                //Update the data base with relevant name & profile ID            
                if (imagetype == 2) //Photos folder
                {
                    if (ImageSizeFlag == 0)
                    {
                        string PhotoFileName = ProfileID + "_" + imageno + "_" + currenttime + ".jpg";

                        UFlag = BusObj.ManageBusinessProfilePhotos(ProfileID, Imagetext, imageno, PhotoFileName, primary, true, UserID, 0, 1, imagedesc, imageOrderNo, C_UserID);
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManagePhotosAlbum.aspx.cs", "UploadAndSaveFile1", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            finally
            {
                File.Dispose();
                utlObj = null;
                BusObj = null;
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "ManagePhotosAlbum.aspx.cs", "UploadAndSaveFile2", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {

        Button btnupdate1 = sender as Button;
        int photoid = Convert.ToInt32(btnupdate1.CommandArgument);
        int value = busobj.UpdatePhotoDescbyPhotoID(photoid, txtphotodesc.Text, ProfileID, C_UserID);
        if (value > 0)
        {
            lblPhotoMsg.Text = "<font color=green face=arial size=2><b>Your image caption has been successfully updated.</b></font>";
            filldata();
            busobj.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "ImageGallery", "Caption");
        }
        ModalPopupExtender2.Hide();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {

    }
    protected void btndashboard1_Click(object sender, EventArgs e)
    {
        string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/Default.aspx");
        Response.Redirect(urlinfo);
    }

    protected void btnwizard_Click(object sender, EventArgs e)
    {
        string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/ManageBusinessDetails.aspx");
        Response.Redirect(urlinfo);
    }
    //protected void chkbxImgPublicPrivate_CheckedChanged(object sender, EventArgs e)
    //{

    //    if(chkbxImgPublicPrivate.Checked==true)
    //    {
    //    PrimaryImageFlag=true;
    //    }
    //    else
    //    {
    //     PrimaryImageFlag=false;
    //    }
    //    busobj.UpdatePhotoPrimaryflagByProfileID(ProfileID, PrimaryImageFlag);
    //}
    protected void btnAddToGooglePlaces_Click(object sender, EventArgs e)
    {

        //string ImagePath = string.Empty;
        //int count = 0;
        //StringBuilder strXml = new StringBuilder("<IMAGES>");
        //int TotalnumberofImagesExisting = Convert.ToInt32(Session["image"]);
        //DataTable dtImages = new DataTable();
        //dtImages.Columns.Add("Image_Path");
        ////dtImages.Columns.Add("Image_Path", Type.GetType("string"));
        //foreach (DataListItem row1 in dtlistphotos.Items)
        //{
        //    HtmlInputCheckBox chk1 = row1.FindControl("chk") as HtmlInputCheckBox;
        //    if (((HtmlInputCheckBox)row1.FindControl("chk")).Checked)
        //    {
        //        Label lblimgpath = (Label)row1.FindControl("lblppath");
        //        //if (ImagePath == "")
        //        //{
        //        //    ImagePath = lblimgpath.Text;
        //        //}
        //        //else
        //        //{
        //        //    ImagePath = ImagePath + "," + lblimgpath.Text;
        //        //}
        //        strXml.AppendFormat("<IMAGE><NAME>{0}</NAME><TYPE>{1}</TYPE></IMAGE>", lblimgpath.Text, "photo");
        //        DataRow dtrow = dtImages.NewRow();
        //        dtrow["Image_Path"] = lblimgpath.Text;
        //        dtImages.Rows.Add(dtrow);
        //        count++;
        //    }
        //}
        //if (dtImages.Rows.Count > 0)
        //{
        //    if ((count + TotalnumberofImagesExisting) > 10)
        //    {
        //        if ((TotalnumberofImagesExisting) == 0)
        //        {
        //            System.Windows.Forms.MessageBox.Show("Select maximum of " + (10 - TotalnumberofImagesExisting) + " Photos.");
        //        }
        //        else
        //        {
        //            System.Windows.Forms.MessageBox.Show("You have already " + TotalnumberofImagesExisting + " Photos. You can select maximum of " + (10 - TotalnumberofImagesExisting) + " Photos.");
        //        }
        //    }
        //    else
        //    {
        //        strXml.Append("</IMAGES>");
        //        for (int i = 0; i < dtImages.Rows.Count; i++)
        //        {
        //            string OriginalImagePath = Server.MapPath("~") + "\\Upload//Photos\\" + ProfileID.ToString() + "\\" + dtImages.Rows[i]["Image_Path"].ToString();
        //            string GooglePlaceImagePath = Server.MapPath("~") + "\\Upload//GooglePlaces\\" + ProfileID.ToString();
        //            if (!Directory.Exists(GooglePlaceImagePath))
        //            {
        //                Directory.CreateDirectory(GooglePlaceImagePath);
        //            }
        //            GooglePlaceImagePath = GooglePlaceImagePath + "\\" + dtImages.Rows[i]["Image_Path"].ToString();
        //            FileInfo SaveImage = new FileInfo(OriginalImagePath);
        //            if (!File.Exists(GooglePlaceImagePath))
        //                SaveImage.CopyTo(GooglePlaceImagePath);
        //        }
        //        string strImages = strXml.ToString();
        //        USPDHUBBLL.GooglePlaces gp = new GooglePlaces();
        //        gp.InsertGooglePlacesImageVideoDetails(strImages, ProfileID, C_UserID);
        //    }
        //    //Session["image"] = null;
        //    Session["image1"] = "image";
        //    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/GooglePlacesSubmitter.aspx"));
        //}
        //else
        //{

        //}

    }


    protected void btnEditOrderNumber_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (DataListItem row1 in dtlistphotos.Items)
            {
                HtmlInputCheckBox chk1 = row1.FindControl("chk") as HtmlInputCheckBox;
                if (((HtmlInputCheckBox)row1.FindControl("chk")).Checked)
                {

                    int photoID = int.Parse(dtlistphotos.DataKeys[row1.ItemIndex].ToString());
                    DataTable dtphotodetails = new DataTable();
                    dtphotodetails = busobj.GetPhotodetailsByPhotoID(photoID);
                    decimal Image_OrderNo = 0.0M;
                    string ImagePath = string.Empty;


                    if (dtphotodetails.Rows.Count > 0)
                    {
                        if (dtphotodetails.Rows[0]["Image_OrderNo"].ToString() == string.Empty)
                        {
                            txteditordernumber.Text = "";
                            Image_OrderNo = 0.0M;
                        }
                        else
                        {
                            Image_OrderNo = Convert.ToDecimal(dtphotodetails.Rows[0]["Image_OrderNo"].ToString());
                            txteditordernumber.Text = Image_OrderNo.ToString();
                        }
                    }
                    if (dtphotodetails.Rows.Count > 0)
                    {
                        ImagePath = dtphotodetails.Rows[0]["Photo_image_path"].ToString();
                        string extension = System.IO.Path.GetExtension(Server.MapPath(ImagePath));
                        string junk = ".";
                        string[] ret = ImagePath.Split(junk.ToCharArray());
                        string thumbimg1 = ret[0];
                        string BigImage = string.Empty;
                        thumbimg1 = thumbimg1 + "_thumb" + extension;
                        ImagePath = thumbimg1 + "?" + Guid.NewGuid();
                    }

                    ImagePath = RootPath + "/Upload/Photos/" + ProfileID + "/" + ImagePath;
                    ImgOrder.ImageUrl = ImagePath;

                    ModalPopupImgOrderNo.Show();
                    btnUpdateImgOrderNumber.CommandArgument = photoID.ToString();

                    break;
                }
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "ManagePhotosAlbum.aspx.cs", "btnEditOrderNumber_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }

    protected void btnUpdateImgOrderNumber_Click(object sender, EventArgs e)
    {
        Button btnupdate1 = sender as Button;
        int photoid = Convert.ToInt32(btnUpdateImgOrderNumber.CommandArgument);

        decimal imageOrderNo = 0.0M;
        if (txteditordernumber.Text.Trim() == string.Empty)
        {
            dtobj = busobj.GetProfilePhotosByProfileID(ProfileID);
            DataView SortDt1 = new DataView(dtobj);
            SortDt1.Sort = "Image_OrderNo DESC";
            dtobj = SortDt1.ToTable();

            if (dtobj.Rows.Count > 0)
            {
                if (dtobj.Rows[0]["Image_OrderNo"].ToString() == string.Empty)
                {
                    imageOrderNo = 0.0M;
                }
                else
                {
                    imageOrderNo = Convert.ToInt32(dtobj.Rows[0]["Image_OrderNo"]);
                }
            }
            imageOrderNo = imageOrderNo + 1;
        }
        else
        {
            imageOrderNo = Convert.ToDecimal(txteditordernumber.Text.Trim());
        }

        int value = busobj.UpdateImageOrderNumber(photoid, imageOrderNo, ProfileID, C_UserID);
        if (value > 0)
        {
            lblPhotoMsg.Text = "<font color=green face=arial size=2><b>Your image order number has been successfully updated.</b></font>";
            filldata();
            busobj.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "ImageGallery", "OrderNumberChange");
        }
        ModalPopupImgOrderNo.Hide();
    }
    protected void btnCancelImgOrderNumber_Click(object sender, EventArgs e)
    {

    }
    protected void btnRemoveHomeImg_Click(object sender, EventArgs e)
    {
        int imgnum = 0;
        imgnum = busobj.GetMaxImageOrderNo(ProfileID);
        busobj.RemovePrimaryFlag(ProfileID, imgnum, Convert.ToInt32(hdnHomePageID.Value), C_UserID);
        hdnHomepage.Value = "0";
        hdnHomePageID.Value = "0";
        filldata();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageMedia.aspx"));
    }


    protected void btnSubmitResizeImage_OnClick(object sender, EventArgs e)
    {
        try
        {
            dtobj = busobj.GetProfilePhotosByProfileID(ProfileID);
            string currenttime = Session["currenttime"].ToString();
            int Photonum = 0;
            decimal imageOrderNo = 0.0M;
            if (dtobj.Rows.Count > 0)
            {
                Photonum = Convert.ToInt32(dtobj.Rows[0]["Photo_Num"].ToString());
            }
            Photonum = Photonum + 1;

            //start Balaji Date 20-06-2012, For Image Order Number
            DataView SortDt1 = new DataView(dtobj);
            SortDt1.Sort = "Image_OrderNo DESC";
            dtobj = SortDt1.ToTable();

            if (dtobj.Rows.Count > 0)
            {
                imageOrderNo = Convert.ToDecimal(dtobj.Rows[0]["Image_OrderNo"].ToString().Split(".".ToCharArray())[0].ToString());
            }
            imageOrderNo = imageOrderNo + 1;

            //end

            bool primary = false;
            if (ckbprimaryphoto.Checked == true)
            {
                primary = true;

                chkbxImgPublicPrivate.Checked = true;
                busobj.UpdatePhotoPrimaryflagByProfileID(ProfileID, true, C_UserID);
                imageOrderNo = 0.0M;
            }
            else
            {
                if (txtOrderNumber.Text.Trim() != string.Empty)
                {
                    imageOrderNo = Convert.ToDecimal(txtOrderNumber.Text.Trim());
                }
            }


            Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage;

            string savedFileName = Server.MapPath("~/tempimages/") + currenttime + ".jpg";
            if (File.Exists(savedFileName))
            {
                FileStream fs = new FileStream(savedFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                fs.Flush();
                fs.Close();
                fs.Dispose();

                uploadedImage = Neodynamic.WebControls.ImageDraw.ImageElement.FromImage(image);
                Neodynamic.WebControls.ImageDraw.Resize actResize = new Neodynamic.WebControls.ImageDraw.Resize();

                int maxPhotWidth = Convert.ToInt32(ConfigurationManager.AppSettings.Get("MaxPhotAlbumPhotoWidth"));

                // Full Image
                actResize.Width = maxPhotWidth;
                actResize.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.WidthBased;
                uploadedImage.Actions.Add(actResize);
                Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                imgDraw.Elements.Add(uploadedImage);
                imgDraw.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                imgDraw.JpegCompressionLevel = 100;
                string fileName1 = Server.MapPath("~/Upload/Photos/") + ProfileID + "/" + ProfileID + "_" + Photonum + "_" + currenttime + ".jpg";
                imgDraw.Save(fileName1);


                // Thumb Image
                Neodynamic.WebControls.ImageDraw.ImageElement uploadedImage2;
                uploadedImage2 = Neodynamic.WebControls.ImageDraw.ImageElement.FromImage(image);
                Neodynamic.WebControls.ImageDraw.Resize actResize2 = new Neodynamic.WebControls.ImageDraw.Resize();
                actResize2.Width = 150;
                actResize2.LockAspectRatio = Neodynamic.WebControls.ImageDraw.LockAspectRatio.WidthBased;
                uploadedImage2.Actions.Add(actResize2);
                Neodynamic.WebControls.ImageDraw.ImageDraw imgDraw2 = new Neodynamic.WebControls.ImageDraw.ImageDraw();
                imgDraw2.Elements.Add(uploadedImage2);
                imgDraw2.ImageFormat = Neodynamic.WebControls.ImageDraw.ImageDrawFormat.Jpeg;
                imgDraw2.JpegCompressionLevel = 100;
                string fileName2 = Server.MapPath("~/Upload/Photos/") + ProfileID + "/" + ProfileID + "_" + Photonum + "_" + currenttime + "_thumb.jpg";
                imgDraw2.Save(fileName2);

                lblPhotoMsg.Text = "<font color=green face=arial size=2><b>Your image has been uploaded successfully.</b></font>";
                ckbprimaryphoto.Checked = false;

                ckbprimaryphoto.Checked = false;
                picture1Text.Text = "";
                txtOrderNumber.Text = "";

                string PhotoFileName = ProfileID + "_" + Photonum + "_" + currenttime + ".jpg";

                var UFlag = BusObj.ManageBusinessProfilePhotos(ProfileID, "", Photonum, PhotoFileName, primary, true, UserID, 0, 1, Convert.ToString(Session["imgCaption"]), imageOrderNo, C_UserID);
                Session["imgCaption"] = "";

                if (File.Exists(savedFileName))
                {
                    File.Delete(savedFileName);
                }
            }

            filldata();

        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "ManagePhotosAlbum.aspx.cs", "btnSubmitResizeImage_OnClick", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void rbGalleryOrder_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {


            intGalleryOrder = Convert.ToInt32(rbGalleryOrder.SelectedValue);
            hdnGallerySelectedOrder.Value = intGalleryOrder.ToString();
            // intGalleryOrder = Convert.ToInt32(hdnGallerySelectedOrder.Value);
            objCommon.UpdateDisplayOrderType(ProfileID, 0, intGalleryOrder, "Gallery");
            filldata();
            // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "setSelectedGalleryOrderCheck()", true);

        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "ManagePhotosAlbum.aspx.cs", "rbGalleryOrder_OnSelectedIndexChanged", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }

    }
    protected void lnkHdnCustDate_OnClick(object sender, EventArgs e)
    {
        try
        {
            intGalleryOrder = Convert.ToInt32(hdnGallerySelectedOrder.Value);
            objCommon.UpdateDisplayOrderType(ProfileID, 0, intGalleryOrder, "Gallery");
            filldata();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "setSelectedGalleryOrderCheck()", true);
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "ManagePhotosAlbum.aspx.cs", "lnkHdnCustDate_OnClick", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    /*
    protected void ckbprimaryphoto_CheckedChanged(object sender, EventArgs e)
    {
        var chkBox = sender as CheckBox;
        if (chkBox.Checked == true)
        {
            txtOrderNumber.Text = "0";
            txtOrderNumber.Enabled = false;
        }
        else
        {
            txtOrderNumber.Enabled = true;
            int MaxOrderNumber = busobj.GetMaxImageOrderNo(ProfileID);
            txtOrderNumber.Text = MaxOrderNumber.ToString();
        }
    }
     * */



    public class ImageList
    {
        public string ImgPath { get; set; }
        public string ImageSize { get; set; }
    }

    protected void rbBydate_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            hdnGallerySelectedOrder.Value = rbGalleryOrder.SelectedValue;
            //intGalleryOrder = 1;
            objCommon.UpdateDisplayOrderType(ProfileID, 0, Convert.ToInt32(rbGalleryOrder.SelectedValue), "Gallery");
            filldata();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "setSelectedGalleryOrderCheck()", true);

        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "ManagePhotosAlbum.aspx.cs", "rbGalleryOrder_OnSelectedIndexChanged", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }


    }

    protected void rbByCustom_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            hdnGallerySelectedOrder.Value = "2";
            //  intGalleryOrder = Convert.ToInt32(hdnGallerySelectedOrder.Value);
            intGalleryOrder = 2;
            hdnGallerySelectedOrder.Value = "2";
            objCommon.UpdateDisplayOrderType(ProfileID, 0, intGalleryOrder, "Gallery");
            filldata();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "setSelectedGalleryOrderCheck()", true);
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "ManagePhotosAlbum.aspx.cs", "lnkHdnCustDate_OnClick", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void dateChecked()
    {

    }
}
