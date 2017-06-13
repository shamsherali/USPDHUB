using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.IO;
using USPDHUBBLL;
using Winnovative.WnvHtmlConvert;
using System.Text;
using System.Drawing;
using System.Web.Services;
using System.Xml.Linq;

public partial class Business_MyAccount_EditUpdate : BaseWeb
{
    public int UpdateID = 0;
    BusinessUpdatesBLL adminobj = new BusinessUpdatesBLL();
    public int ProfileID = 0;
    public int UserID = 0;
    public int MaxBusinessUpdateID = 0;
    public string BusinessDesc = string.Empty;
    public int BusinessUpdateUsageCount = 0;
    public string PreviewTable = string.Empty;
    public int CUserID = 0;
    public int AppStatus = 0; // *** From app request 26-03-2013 ***
    public string EditHtml = "";
    AgencyBLL agencyobj = new AgencyBLL();
    public string PermissionType = string.Empty;
    public int PermissionValue = 0;
    public DataTable Dtpermissions = new DataTable();
    CommonBLL objCommon = new CommonBLL();
    public string RootPath = "";
    public string DomainName = "";


    public string ListDescription = string.Empty;

    DateTime? ExpiryDate;

    public bool isCall = true;
    public bool isContatUs = true;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {

            string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
            Response.Redirect(urlinfo);
        }
        else
        {
            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());

            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                CUserID = Convert.ToInt32(Session["C_USER_ID"]);
            else
                CUserID = UserID;
        }
        // *** Get Domain Name *** //
        DomainName = Session["VerticalDomain"].ToString();
        RootPath = Session["RootPath"].ToString();
        if (Request.QueryString["Update_ID"] != null)
        {
            if (Request.QueryString["Update_ID"].ToString() != "")
            {
                UpdateID = Convert.ToInt32(Request.QueryString["Update_ID"]);
            }
            else
            {
                UpdateID = 0;
            }
        }
        else
        {
            btnSave.ValidationGroup = "group";
            UpdateID = 0;
        }
        // *** Make back button visible and disable by query string 26-03-2013 *** //
        if (!string.IsNullOrEmpty(Request.QueryString["App"]))
            AppStatus = 1;

        BusinessUpdateUsageCount = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("BusinessUpdateUsageCount").Replace(",", ""));


        

        if (!IsPostBack)
        {

            #region Checking Global mobile app settings

            // *** Checking Global mobile app settings *** //
            DataTable dtSelectedTools = USPDHUBDAL.MServiceDAL.GetMobileAppSetting(Convert.ToInt32(UserID));
            if (dtSelectedTools.Rows.Count > 0)
            {
                string xmlSettings = Convert.ToString(dtSelectedTools.Rows[0]["M_SettingValue"]);
                var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                isCall = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("PhoneNumber").Value);
                isContatUs = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsContatUs").Value);
                if (isCall)
                    divCall.Visible = true;
                else
                {
                    divCall.Visible = false;
                    chkCall.Checked = false;
                }
                if (isContatUs)
                    divContactUs.Visible = true;
                else
                {
                    divContactUs.Visible = false;
                    chkContact.Checked = false;
                }
            }
            else
            {
                divCall.Visible = false;
                chkCall.Checked = false;
                divContactUs.Visible = false;
                chkContact.Checked = false;
            }

            #endregion


            string tempNewsletterPath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileID.ToString();

            if (Directory.Exists(tempNewsletterPath) == false)
            {
                Directory.CreateDirectory(tempNewsletterPath);
            }
            if (UpdateID > 0)
            {
                DataTable dtobj = new DataTable();
                dtobj = adminobj.UpdateBusinessUpdateDetails(UpdateID);
                if (dtobj != null)
                {
                    if (dtobj.Rows.Count > 0)
                    {
                        // Populate the existing values
                        PopulateBusinessUpdateDetails(dtobj);
                    }
                    else
                    {
                        lblerror.Text = "<font color=red face=arial size=2> There are no User details available right now.</font>";
                    }
                }
                else
                {
                    lblerror.Text = "<font color=red face=arial size=2> There are no User details right now.</font>";
                }
            }
            else
            {
                rbPublic.Checked = false;
                rbPrivate.Checked = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript", "javascript: ShowPublish(1);", true);
            }

            //roles & permissions..
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                Dtpermissions = agencyobj.GetPermissionsById(Convert.ToInt32(Session["C_USER_ID"]));
                if (Dtpermissions.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtpermissions.Rows.Count; i++)
                    {
                        PermissionValue = Convert.ToInt32(Dtpermissions.Rows[i]["Permission_Values"].ToString());
                        if (Convert.ToBoolean(PermissionValue & Constants.UPDATES))
                        {
                            PermissionType = Dtpermissions.Rows[i]["Permission_Type"].ToString();
                            // if (Permission_Type == "A")
                            hdnPermissionType.Value = PermissionType;
                        }
                    }
                }
                if (string.IsNullOrEmpty(hdnPermissionType.Value))
                {
                    UpdatePanel1.Visible = true;
                    UpdatePanel2.Visible = false;
                    lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create or edit contents.</font>";
                }
                else if (hdnPermissionType.Value == "A")
                    hdnPublishTitle.Value = Resources.LabelMessages.AuthorPublishTitle;
            }
            //ends here
        }
        lblPublish.Text = hdnPublishTitle.Value;
    }

    //TO FILL THE VALUES WITH THE PREVIOUS VALUES
    private void PopulateBusinessUpdateDetails(DataTable dtobj)
    {
        txtUpdateName.Text = dtobj.Rows[0]["UpdateTitle"].ToString();

        if (Convert.ToBoolean(dtobj.Rows[0]["IsPublic"].ToString()))
        {
            rbPublic.Checked = true;
            rbPrivate.Checked = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript", "javascript: ShowPublish(2);", true);
        }
        else
        {
            rbPrivate.Checked = true;
            rbPublic.Checked = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript", "javascript: ShowPublish(1);", true);
        }

        if (!string.IsNullOrEmpty(dtobj.Rows[0]["IsCall"].ToString()))
            chkCall.Checked = Convert.ToBoolean(dtobj.Rows[0]["IsCall"]);
        if (!string.IsNullOrEmpty(dtobj.Rows[0]["IsContactUs"].ToString()))
        chkContact.Checked = Convert.ToBoolean(dtobj.Rows[0]["IsContactUs"]);
        
        // Global Settings
        if (isCall == false)
            chkCall.Checked = false;
        if (isContatUs == false)
            chkContact.Checked = false;

        EditHtml = Convert.ToString(dtobj.Rows[0]["Edit_HTML"]);
        DateTime dtNow = objCommon.ConvertToUserTimeZone(ProfileID);
        if (!string.IsNullOrEmpty(dtobj.Rows[0]["Publish_Date"].ToString()))
        {
            DateTime dtPublish = Convert.ToDateTime(dtobj.Rows[0]["Publish_Date"]);
            if (DateTime.Compare(dtPublish, dtNow) < 0)
                txtPublishDate.Text = dtNow.ToShortDateString();
            else
                txtPublishDate.Text = dtPublish.ToShortDateString();
        }

        lblEditText.Text = EditHtml;

        //ExDate
        if (Convert.ToString(dtobj.Rows[0]["Expiration_Date"]) != string.Empty)
        {
            txtExDate.Text = Convert.ToDateTime(dtobj.Rows[0]["Expiration_Date"]).ToShortDateString();
            txtExHours.Enabled = true;
            txtExMinutes.Enabled = true;
            ddlExSS.Enabled = true;

            DateTime expiryTime = Convert.ToDateTime(dtobj.Rows[0]["Expiration_Date"]);

            if (expiryTime.ToString().Contains("PM"))
            {
                if (expiryTime.Hour > 12)
                {
                    txtExHours.Text = (expiryTime.Hour - 12).ToString();
                }
                else
                {
                    txtExHours.Text = (expiryTime.Hour).ToString();
                }
                ddlExSS.SelectedValue = "PM";
            }
            else
            {
                if (expiryTime.Hour == 0)
                {
                    txtExHours.Text = "12";
                }
                else
                {
                    txtExHours.Text = (expiryTime.Hour).ToString();
                }
                ddlExSS.SelectedValue = "AM";
            }
            txtExMinutes.Text = expiryTime.Minute.ToString();

        }
        else
        {
            txtExHours.Enabled = false;
            txtExMinutes.Enabled = false;
            ddlExSS.Enabled = false;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(GetUrl("ManageUpdates.aspx"));
    }

    private string GetUrl(string file)
    {
        string url = Page.ResolveClientUrl("~/Business/MyAccount/" + file);
        if (AppStatus == 1)
            url = Page.ResolveClientUrl("~/Business/MyAccount/" + file + "?App=1");
        return url;
    }

    //end of issue 998

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidatePublishDate())
        {
            InsertUpdateBusUpdate();

            Response.Redirect(GetUrl("ManageUpdates.aspx"));
        }
        else
        {
            lblEditText.Text = hdnEditHTML.Value;
        }

        MPEProgress.Hide();
    }

    private void InsertUpdateBusUpdate()
    {
        string title = string.Empty;
        string updateName = string.Empty;
        bool updateStatus = true;
        bool isPublic = false;

        DateTime? publishDate;
        publishDate = null;
        int? id = null;
        title = txtUpdateName.Text.Trim();
        EditHtml = hdnEditHTML.Value.ToString();
        BusinessDesc = hdnPreviewHTML.Value.ToString();
        ListDescription = Convert.ToString(hdnDescription.Value);

        isCall = chkCall.Checked;
        isContatUs = chkContact.Checked;


        #region Expiry Date Code

        ExpiryDate = null;
        string exHour = "";
        string exMin = "";
        string exSS = "AM";
        var exTime = "";

        if (txtExDate.Text.Trim() != string.Empty)
        {
            if (txtExHours.Text.Trim() != "" || txtExMinutes.Text.Trim() != "")
            {
                exHour = txtExHours.Text;
                if (exHour == "")
                    exHour = "12";
                exMin = txtExMinutes.Text;
                if (exMin == "")
                    exMin = "00";
                exSS = ddlExSS.SelectedValue.ToString();

                exTime = exHour + ":" + exMin + ":00 " + exSS;
            }
            else
            {
                exHour = "12";
                exMin = "00";
                exSS = "AM";

                exTime = exHour + ":" + exMin + ":00 " + exSS;
            }

            ExpiryDate = Convert.ToDateTime(txtExDate.Text.Trim() + " " + exTime);
        }

        #endregion

        //**added by suneel to show confirmation message in ManageUpdates Page 26/06/2013 **//
        int insertedID = 0;
        if (UpdateID == 0)
            Session["UpdateSuccess"] = "Content has been saved successfully.";
        else
            Session["UpdateSuccess"] = "Content has been updated successfully.";
        //Ends here
        if (UpdateID <= 0)
        {
            UpdateID = adminobj.GetMaxBusinessUpdateUpdateID();
            insertedID = UpdateID;
        }

        if (rbPublic.Checked)
            isPublic = true;

        if (txtPublishDate.Text != string.Empty)
        {
            publishDate = Convert.ToDateTime(txtPublishDate.Text);
        }
        //roles & permissions..

        if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
        {
            if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
            {
                adminobj.InsertBusinessUpdateDetailsNew(UpdateID, ProfileID, title, updateStatus, BusinessDesc, updateName, false, isPublic,
                    CUserID, publishDate, EditHtml, id, ListDescription, ExpiryDate, isCall, isContatUs);
                if (isPublic == true)
                    objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), UpdateID, PageNames.UPDATE, UserID, Session["username"].ToString(), PageNames.UPDATE, DomainName);
            }
            else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
            {
                if (isPublic == true)
                    adminobj.InsertBusinessUpdateDetailsNew(UpdateID, ProfileID, title, updateStatus, BusinessDesc, updateName, isPublic, isPublic,
                        CUserID, publishDate, EditHtml, CUserID, ListDescription, ExpiryDate, isCall, isContatUs);
                else
                    adminobj.InsertBusinessUpdateDetailsNew(UpdateID, ProfileID, title, updateStatus, BusinessDesc, updateName, isPublic, isPublic,
                        CUserID, publishDate, EditHtml, id, ListDescription, ExpiryDate, isCall, isContatUs);
            }
        }
        else
        {
            if (isPublic == true)
                adminobj.InsertBusinessUpdateDetailsNew(UpdateID, ProfileID, title, updateStatus, BusinessDesc, updateName, isPublic, isPublic,
                    CUserID, publishDate, EditHtml, CUserID, ListDescription, ExpiryDate, isCall, isContatUs);
            else
                adminobj.InsertBusinessUpdateDetailsNew(UpdateID, ProfileID, title, updateStatus, BusinessDesc, updateName, isPublic, isPublic,
                    CUserID, publishDate, EditHtml, id, ListDescription, ExpiryDate, isCall, isContatUs);
        }
        if (insertedID > 0)
        {
            try
            {
                string shortenUrl = RootPath + "/OnlineUpdate.aspx?BID=" + EncryptDecrypt.DESEncrypt(insertedID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
                shortenUrl = objCommon.longurlToshorturl(shortenUrl);
                // *** Update shorten url *** //
                objCommon.UpdateShortenURl(insertedID, shortenUrl, "UPDATES");

            }
            catch (Exception /*ex*/)
            {

            }
        }

        // *** Convert to image ***//
        string strhtml = "<html><head></head><body><table width='650px' border='0' cellspacing='0' cellpadding='0'><tr><td style='padding:30px;'>" + hdnPreviewHTML.Value.ToString() + "</td></tr><tr></table></body></html>";
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(strhtml.ToString());
        ImgConverter imgConverter = new ImgConverter();
        MemoryStream msval = new MemoryStream(buffer);
        imgConverter.LicenseKey = ConfigurationManager.AppSettings.Get("imgkeyval");
        imgConverter.PageWidth = 650;
        string saveFilePath = Server.MapPath("~") + "\\Upload\\Updates\\" + ProfileID.ToString();
        if (!System.IO.Directory.Exists(saveFilePath))
        {
            System.IO.Directory.CreateDirectory(saveFilePath);
        }
        string savelocation = saveFilePath + "\\" + UpdateID.ToString() + ".jpg";
        string tempimagepath = Server.MapPath("~") + "\\Upload\\Updates\\" + ProfileID.ToString() + "\\" + ProfileID.ToString() + UserID.ToString() + ".jpg";
        if (File.Exists(savelocation))
        {
            File.Delete(savelocation);
        }
        imgConverter.SaveImageFromHtmlStreamToFile(msval, Encoding.UTF8, System.Drawing.Imaging.ImageFormat.Jpeg, tempimagepath);
        //msval = null;
        buffer = null;

        // *** Creating Thmb image *** //
        string srcfile = tempimagepath;
        string destfile = savelocation;
        int thumbWidth = 350;
        System.Drawing.Image image = System.Drawing.Image.FromFile(srcfile);
        int srcWidth = image.Width;
        int srcHeight = image.Height;
        Decimal sizeRatio = ((Decimal)srcHeight / srcWidth);
        int thumbHeight = Decimal.ToInt32(sizeRatio * thumbWidth);
        Bitmap bmp = new Bitmap(thumbWidth, thumbHeight);
        System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
        gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, thumbWidth, thumbHeight);
        gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);
        bmp.Save(destfile);
        bmp.Dispose();
        image.Dispose();
        if (File.Exists(tempimagepath))
        {
            File.Delete(tempimagepath);
        }
        msval.Flush();
        msval.Close();
        msval.Dispose();
    }

    private bool ValidatePublishDate()
    {
        bool addflag = true;
        if (txtPublishDate.Text.Trim() != "")
        {
            DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
            if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0)
            {
                lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.PublishDateAlert + "</font>";
                addflag = false;
            }
            if (rbPublic.Checked)
            {
                int publishValue = 2;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowPublish('" + publishValue + "');", true);
            }
        }
        return addflag;
    }

    private string UserProfileUnsubscribeLink()
    {
        BusinessBLL objBus = new BusinessBLL();
        DataTable dtProfileAddress = new DataTable();
        dtProfileAddress = objBus.GetProfileDetailsByProfileID(ProfileID);
        string totalAddress = string.Empty;
        string unSubscribeLinkText = string.Empty;
        string profileName = string.Empty;
        if (dtProfileAddress.Rows.Count > 0)
        {
            if (dtProfileAddress.Rows[0]["Profile_name"].ToString() != "")
            {
                profileName = dtProfileAddress.Rows[0]["Profile_name"].ToString();
            }
            if (dtProfileAddress.Rows[0]["Profile_StreetAddress1"].ToString() != "")
            {
                totalAddress = dtProfileAddress.Rows[0]["Profile_StreetAddress1"].ToString();
            }
            if (dtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString() != "")
            {
                if (totalAddress != "")
                {
                    totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString();
                }
                else
                {
                    totalAddress = dtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString();
                }
            }
            if (dtProfileAddress.Rows[0]["Profile_City"].ToString() != "")
            {
                if (totalAddress != "")
                {
                    totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_City"].ToString();
                }
                else
                {
                    totalAddress = dtProfileAddress.Rows[0]["Profile_City"].ToString();
                }
            }
            if (dtProfileAddress.Rows[0]["Profile_State"].ToString() != "")
            {
                if (totalAddress != "")
                {
                    totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_State"].ToString();
                }
                else
                {
                    totalAddress = dtProfileAddress.Rows[0]["Profile_State"].ToString();
                }
            }
            if (dtProfileAddress.Rows[0]["Profile_Zipcode"].ToString() != "")
            {
                if (totalAddress != "")
                {
                    totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_Zipcode"].ToString();
                }
                else
                {
                    totalAddress = dtProfileAddress.Rows[0]["Profile_Zipcode"].ToString();
                }
            }
        }
        unSubscribeLinkText = "This message was sent " + profileName + " to &#60;recipient's email address&#62;. It was sent from &#60;sender's email address&#62;" + totalAddress + ". If you no longer wish to receive our contents, <a href='" + RootPath + "/Unsubscribeupdate.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "' target='_blank'>click here</a> to unsubscribe.";
        return unSubscribeLinkText;
    }

    protected void imclose_Click(object sender, ImageClickEventArgs e)
    {
        string redirecturl = string.Empty;
        if (Request.QueryString["Update_ID"] != null)
        {
            redirecturl = Page.ResolveClientUrl("~/Business/MyAccount/EditUpdate.aspx?Update_ID=" + Request.QueryString["Update_ID"]);
        }
        else
        {
            redirecturl = Page.ResolveClientUrl("~/Business/MyAccount/EditUpdate.aspx");
        }
        Response.Redirect(redirecturl);
    }

    [WebMethod]
    public static string GetPreviewTable(string updateBody, string profileID, string userID)
    {
        string previewHtml = string.Empty;
        previewHtml = "<html><head></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='border: solid 2px #F4EBEB;'><tr><td colspan='2' style='padding:30px;'>" + updateBody + "</td></tr></table></body></html>";
        return previewHtml;
    }
}