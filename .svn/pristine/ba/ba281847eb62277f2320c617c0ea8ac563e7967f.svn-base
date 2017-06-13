using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.IO;
using System.Configuration;
using System.Xml.Linq;

namespace USPDHUB.Business.MyAccount
{
    public partial class EditBulletin : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        static BulletinBLL objBulletin = new BulletinBLL();
        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        BusinessBLL objBus = new BusinessBLL();
        USPDHUBBLL.MobileAppSettings objMobileApp = new USPDHUBBLL.MobileAppSettings();
        CommonBLL objCommon = new CommonBLL();
        public DataTable Dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        public int CUserID = 0;

        bool isPhoneNumber = true;
        bool isContatUs = true;
        public string RootPath = "";
        public string DomainName = "";
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        public string ListDescription = string.Empty;
        public bool IsScheduleEmails = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "EditBulletin.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                hdnRootPath.Value = RootPath;
                int saveProcessID = 0;
                UserID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
                ProfileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
                /*** Store Module Functionality ***/
                if (objBus.CheckModulePermission(WebConstants.Purchase_ScheduleEmailsSetup, ProfileID))
                {
                    IsScheduleEmails = true;
                }
                if (!IsPostBack)
                {
                    if (Request.QueryString["BulletinID"] != null)
                    {
                        Session["BulletinID"] = Request.QueryString["BulletinID"];
                        hdnBulletinID.Value = Request.QueryString["BulletinID"].ToString();
                    }


                    //Show Header Agenecy Name & Logo etc..



                    #region Fill Bulletin Categories


                    DataTable dtLabelData = objInBuiltData.GetBulletinLabelData();
                    DataTable dtCategories = objCommon.GetBulletinCategoriesByVertical(ProfileID);
                    if (dtCategories.Rows.Count > 0)
                    {
                        ddlCategories.DataSource = dtCategories;
                        ddlCategories.DataTextField = "Category_Name";
                        ddlCategories.DataValueField = "Category_Name";
                        ddlCategories.DataBind();

                        if (Session["BulletinCategoryName"] != null)
                        {
                            ddlCategories.SelectedValue = Session["BulletinCategoryName"].ToString();
                        }
                    }


                    #endregion

                    #region Checking Global mobile app settings

                    // *** Checking Global mobile app settings *** //
                    DataTable dtSelectedTools = USPDHUBDAL.MServiceDAL.GetMobileAppSetting(Convert.ToInt32(UserID));
                    if (dtSelectedTools.Rows.Count > 0)
                    {
                        string xmlSettings = Convert.ToString(dtSelectedTools.Rows[0]["M_SettingValue"]);
                        var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                        isPhoneNumber = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("PhoneNumber").Value);
                        isContatUs = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsContatUs").Value);
                        if (isPhoneNumber)
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

                    if (Convert.ToInt32(Session["BulletinID"]) == 0 && Session["BulletinID"] != null && Session["BulletinID"].ToString() != "")
                    {
                        //New Bulletin
                        lblBulletinName.Text = Convert.ToString(Session["BulletinName"]);

                        DataTable dtBulletin = objBulletin.CheckBulletin(UserID, string.Empty, Convert.ToInt32(Session["TemplateBID"]), string.Empty);
                        //lblBulletinedit.Text = Convert.ToString(dtBulletin.Rows[0]["Template"]);
                        Session["TemplateName"] = Convert.ToString(dtBulletin.Rows[0]["Template_Name"]);
                    }
                    else
                    {
                        GetBulletinDetails();
                        saveProcessID++;
                    }

                    string tempName = Convert.ToString(Session["TemplateName"]);
                    tempName = tempName.Replace("Template", "");
                    hdnBTempID.Value = tempName;

                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Bulletins");
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            UpdatePanel1.Visible = true;
                            UpdatePanel3.Visible = UpdatePanel2.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create or edit bulletins.</font>";
                        }
                        else if (hdnPermissionType.Value == "A")
                            hdnPublishTitle.Value = Resources.LabelMessages.AuthorPublishTitle;
                    }
                    //ends here
                    GetAutoShareRecordStatus();
                }
                lblPublish.Text = hdnPublishTitle.Value;
                string preview = string.Empty;
                preview = objCommon.GetHeaderForBulletins(UserID, ProfileID);
                hdnBulletinHeader.Value = preview;

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditBulletin.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        private void GetAutoShareRecordStatus()
        {
            int bulletinID = 0;
            if (Session["BulletinID"] != null && Convert.ToString(Session["BulletinID"]) != "")
                bulletinID = Convert.ToInt32(Session["BulletinID"]);
            if (bulletinID > 0)
            {
                DataTable dtShareRecords = objCommon.CheckAutoShareRecordExists("Bulletin", bulletinID, lblBulletinName.Text);
                for (int i = 0; i < dtShareRecords.Rows.Count; i++)
                {
                    if (Convert.ToString(dtShareRecords.Rows[i]["Media_TYPE"]) == "Facebook")
                        hdnFacebook.Value = "true";

                    if (Convert.ToString(dtShareRecords.Rows[i]["Media_TYPE"]) == "Twitter")
                        hdnTwitter.Value = "true";
                }
            }
            if (hdnFacebook.Value != "false")
            {
                DataTable dtExistingFbUsersData = smb.GetExistingUserData(ProfileID);
                if (dtExistingFbUsersData.Rows.Count > 0)
                {
                    chkFbAutoPost.Visible = true;
                    for (int i = 0; i < 1; i++) // To Share on Facebook Timeline
                    {
                        if (Convert.ToBoolean(dtExistingFbUsersData.Rows[i]["IsAutoShare"].ToString()) == true)
                        {
                            chkFbAutoPost.Checked = true;
                        }
                    }
                }
                else
                    hdnFacebook.Value = "false";
            }
            if (hdnTwitter.Value != "false")
            {
                DataTable dtExistingTwrUserData = smb.GetTwitterDataByUserID(ProfileID);
                if (dtExistingTwrUserData.Rows.Count > 0)
                {
                    chkTwrAutoPost.Visible = true;
                    for (int j = 0; j < dtExistingTwrUserData.Rows.Count; j++)
                    {
                        if (Convert.ToBoolean(dtExistingTwrUserData.Rows[j]["IsAutoPost"].ToString()) == true)
                        {
                            chkTwrAutoPost.Checked = true;
                        }
                    }
                }
                else
                    hdnTwitter.Value = "false";
            }
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "EditBulletin.aspx.cs", "BtnCancel_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx");
                HttpContext.Current.Response.Redirect(urlinfo);

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditBulletin.aspx.cs", "BtnCancel_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MPEProgress.Show();

                //Log
                objInBuiltData.ErrorHandling("LOG", "EditBulletin.aspx.cs", "BtnSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                if (ValidatePublishDate())
                {
                    //Save & Update Bulletins
                    Save_Update_BulletinDetails();
                    //Getting Bulletin Details
                    GetBulletinDetails();
                    lblmess.Text = "Bulletin saved successfully.";
                }

                MPEProgress.Hide();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditBulletin.aspx.cs", "BtnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnPublish_Click(object sender, EventArgs e)
        {
            string publishValue = "1";
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "EditBulletin.aspx.cs", "BtnPublish_Click", string.Empty, string.Empty, string.Empty, string.Empty);
                if (rbPublic.Checked)
                    publishValue = "2";
                if (ValidatePublishDate())
                {
                    //Save & Update Bulletins
                    Save_Update_BulletinDetails();

                    //
                    string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/managebulletins.aspx");
                    HttpContext.Current.Response.Redirect(urlinfo);
                }

                lblBulletinedit.Text = "";
                lblBulletinedit.Text = hdnEditHTML.Value;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditBulletin.aspx.cs", "BtnPublish_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowPublishSave('" + publishValue + "');", true);
        }

        private void GetBulletinDetails()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "EditBulletin.aspx.cs", "GetBulletinDetails", string.Empty, string.Empty, string.Empty, string.Empty);

                //Edit Bulletin
                DataTable dtBulletinDetails = objBulletin.GetBulletinDetailsByID(Convert.ToInt32(Session["BulletinID"]));

                if (dtBulletinDetails.Rows.Count > 0)
                {
                    Session["BulletinName"] = dtBulletinDetails.Rows[0]["Bulletin_Title"].ToString();

                    lblBulletinName.Text = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_Title"]);
                    lblBulletinedit.Text = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_XML"]);
                    hdnEditHTML.Value = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_XML"]);
                    string previewHtml = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_HTML"]);

                    if (Convert.ToString(dtBulletinDetails.Rows[0]["Expiration_Date"]) != string.Empty)
                    {
                        txtExDate.Text = Convert.ToDateTime(dtBulletinDetails.Rows[0]["Expiration_Date"]).ToShortDateString();
                        txtExHours.Enabled = true;
                        txtExMinutes.Enabled = true;
                        ddlExSS.Enabled = true;

                        DateTime expiryTime = Convert.ToDateTime(dtBulletinDetails.Rows[0]["Expiration_Date"]);

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

                    chkCall.Checked = Convert.ToBoolean(dtBulletinDetails.Rows[0]["IsCall"].ToString());
                    chkContact.Checked = Convert.ToBoolean(dtBulletinDetails.Rows[0]["IsContactUs"].ToString());
                    if (isPhoneNumber == false)
                        chkCall.Checked = false;
                    if (isContatUs == false)
                        chkContact.Checked = false;

                    Session["TemplateName"] = Convert.ToString(dtBulletinDetails.Rows[0]["Template_Name"]);

                    bool isPrivate = Convert.ToBoolean(dtBulletinDetails.Rows[0]["IsPrivate"]);

                    if (!string.IsNullOrEmpty(dtBulletinDetails.Rows[0]["Bulletin_Category"].ToString()))
                        ddlCategories.SelectedValue = dtBulletinDetails.Rows[0]["Bulletin_Category"].ToString();
                    DateTime dtNow = objCommon.ConvertToUserTimeZone(ProfileID);
                    if (!string.IsNullOrEmpty(dtBulletinDetails.Rows[0]["Publish_Date"].ToString()))
                    {
                        DateTime dtPublish = Convert.ToDateTime(dtBulletinDetails.Rows[0]["Publish_Date"]);
                        if (DateTime.Compare(dtPublish, dtNow) < 0)
                            txtPublishDate.Text = dtNow.ToShortDateString();
                        else
                            txtPublishDate.Text = dtPublish.ToShortDateString();
                    }

                    rbPrivate.Checked = true;
                    if (Convert.ToBoolean(dtBulletinDetails.Rows[0]["IsPrivate"].ToString()) == false)
                    {
                        rbPublic.Checked = true;
                        hdnIsAlreadyPublished.Value = "1";
                    }

                    //Create Bulletin Image
                    string bulletinImgPath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\Bulletins\\" + Convert.ToString(Session["ProfileID"]) + "\\" + Convert.ToString(Session["BulletinID"]) + ".jpg";
                    if (!File.Exists(bulletinImgPath))
                    {
                        objInBuiltData.CreateImage(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\Bulletins\\", Convert.ToInt32(Session["ProfileID"]),
                            UserID, Convert.ToInt32(Session["BulletinID"]), previewHtml);
                    }
                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditBulletin.aspx.cs", "GetBulletinDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void Save_Update_BulletinDetails()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "EditBulletin.aspx.cs", "Save_Update_BulletinDetails", string.Empty, string.Empty, string.Empty, string.Empty);

                //Type 1 == Preview 
                //Type 2 == Save
                //Type 3 == Save & Publish 

                string editHtmlText = hdnEditHTML.Value.ToString();
                string previewHtml = hdnPreviewHTML.Value.ToString();
                string exDate = hdnExDate.Value.ToString();
                DateTime? datePublish;
                datePublish = null;

                int bulletinID = Convert.ToInt32(System.Web.HttpContext.Current.Session["BulletinID"]);
                int templateBid = Convert.ToInt32(System.Web.HttpContext.Current.Session["TemplateBID"]);
                string bulletinTitle = Convert.ToString(System.Web.HttpContext.Current.Session["BulletinName"]);
                int userID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
                bool isArchive = false;
                int profileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                bool isCall = chkCall.Checked;
                bool isPhotoCapture = false;
                bool isContactUs = chkContact.Checked;
                int? id = null;
                bool isPublish = Convert.ToBoolean(hdnPrivate.Value);

                ListDescription = Convert.ToString(hdnDescription.Value);

                if (txtPublishDate.Text.Trim() != "")
                {
                    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                }

                string exHour = "";
                string exMin = "";
                string exSS = "AM";
                var exTime = "";

                bool isPrivate = true;
                if (rbPrivate.Checked)
                    isPrivate = false;
                int bulletinCheckID = bulletinID;
                if (exDate == string.Empty)
                {
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish,
                            ddlCategories.SelectedValue, false, id, "", "", ListDescription);
                            if (isPrivate == true)
                                objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), bulletinID, PageNames.BULLETIN, userID, Session["username"].ToString(), PageNames.BULLETIN, DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            if (isPrivate == true)
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null,
                                datePublish, ddlCategories.SelectedValue, isPrivate, CUserID, "", "", ListDescription);
                            }
                            else
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null,
                                datePublish, ddlCategories.SelectedValue, isPrivate, id, "", "", ListDescription);
                            }
                        }
                    }
                    else
                    {
                        if (isPrivate == true)
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish,
                            ddlCategories.SelectedValue, isPrivate, CUserID, "", "", ListDescription);
                        }
                        else
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish,
                            ddlCategories.SelectedValue, isPrivate, id, "", "", ListDescription);
                        }
                    }
                }
                else
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
                    DateTime expiryDate = Convert.ToDateTime(txtExDate.Text.Trim() + " " + exTime);
                    //                    DateTime expiryDate = Convert.ToDateTime(exDate);

                    //Insert & Update Bulletin Details
                    //BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinTitle, previewHTML,
                    //     editHTMLText, UserID, UserID, IsArchive, UserID, ProfileID, IsCall, IsPhotoCapture, IsContactUs, IsPublish, expiryDate, datePublish, ddlCategories.SelectedValue);

                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        string returnvalue = string.Empty;
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate,
                            datePublish, ddlCategories.SelectedValue, false, id, ListDescription);
                            if (isPrivate == true)
                                returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), bulletinID, "Bulletin", userID, Session["username"].ToString(), "Bulletin", DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            if (isPrivate == true)
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate,
                                datePublish, ddlCategories.SelectedValue, isPrivate, CUserID, ListDescription);
                            }
                            else
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate,
                                datePublish, ddlCategories.SelectedValue, isPrivate, id, ListDescription);
                            }
                        }
                    }
                    else
                    {
                        if (isPrivate == true)
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate,
                            datePublish, ddlCategories.SelectedValue, isPrivate, CUserID, ListDescription);
                        }
                        else
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish,
                            expiryDate, datePublish, ddlCategories.SelectedValue, isPrivate, id, ListDescription);
                        }
                    }
                }
                /************************************ Auto Share ***************************************/
                if (!(Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "") || hdnPermissionType.Value == "P")
                {
                    if (isPrivate)
                    {
                        if (chkFbAutoPost.Checked)
                            objCommon.InsertUpdateAutoShareDetails("Bulletin", bulletinID, 0, Convert.ToDateTime(txtPublishDate.Text), "Facebook", UserID, CUserID, bulletinTitle);
                        if (chkTwrAutoPost.Checked)
                            objCommon.InsertUpdateAutoShareDetails("Bulletin", bulletinID, 0, Convert.ToDateTime(txtPublishDate.Text), "Twitter", UserID, CUserID, bulletinTitle);
                    }
                }
                if (bulletinCheckID > 0)
                {
                    if (rbPrivate.Checked && hdnIsAlreadyPublished.Value == "1")
                        objCommon.UpdateSentFlag(bulletinID, 2, 0, "Bulletin");
                }
                /****** Auto Share Completed ******/
                //Create Bulletin Image
                objInBuiltData.CreateImage(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\Bulletins\\", profileID, userID, Convert.ToInt32(bulletinID), previewHtml);

                //Messages
                if (Convert.ToInt32(System.Web.HttpContext.Current.Session["BulletinID"]) == 0)
                {
                    System.Web.HttpContext.Current.Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", bulletinTitle);
                }
                else
                {
                    System.Web.HttpContext.Current.Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", bulletinTitle);
                }

                #region Save User Activity Log

                if (System.Web.HttpContext.Current.Session["BulletinSuccess"].ToString().Contains("created"))
                {
                    objCommon.InsertUserActivityLog("has created a bulletin titled <b>" + bulletinTitle + "</b>", string.Empty, userID, profileID, DateTime.Now, UserID);
                }
                else
                {
                    objCommon.InsertUserActivityLog("has updated a bulletin named <b>" + bulletinTitle + "</b>", string.Empty, userID, profileID, DateTime.Now, UserID);
                }

                #endregion

                System.Web.HttpContext.Current.Session["BulletinID"] = bulletinID;

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditBulletin.aspx.cs", "Save_Update_BulletinDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private bool ValidatePublishDate()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "EditBulletin.aspx.cs", "ValidatePublishDate", string.Empty, string.Empty, string.Empty, string.Empty);

                bool addflag = true;
                int ProfilID = ProfileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfilID);
                if (txtPublishDate.Text.Trim() != "")
                {
                    DateTime publishDate = Convert.ToDateTime(txtPublishDate.Text.Trim());
                    if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && Convert.ToInt32(System.Web.HttpContext.Current.Session["BulletinID"]) == 0)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.PublishDateAlert + "</font>";
                        // txt.Focus();
                        addflag = false;
                    }
                }
                if (txtExDate.Text.Trim() != "")
                {
                    string ExpDateTime = "";
                    if (!string.IsNullOrEmpty(txtExDate.Text.Trim()))
                    {
                        txtExHours.Enabled = true;
                        txtExMinutes.Enabled = true;
                        ddlExSS.Enabled = true;
                        if (!string.IsNullOrEmpty(txtExHours.Text) && !string.IsNullOrEmpty(txtExMinutes.Text))
                        {
                            ExpDateTime = txtExDate.Text.Trim() + " " + txtExHours.Text + ":" + txtExMinutes.Text + ":00" + " " + ddlExSS.SelectedValue.ToString();
                        }
                        else if (!string.IsNullOrEmpty(txtExHours.Text) && string.IsNullOrEmpty(txtExMinutes.Text))
                        {
                            ExpDateTime = txtExDate.Text.Trim() + " " + txtExHours.Text + ":00:00" + " " + ddlExSS.SelectedValue.ToString();
                        }
                        else if (string.IsNullOrEmpty(txtExHours.Text) && !string.IsNullOrEmpty(txtExMinutes.Text))
                        {
                            ExpDateTime = txtExDate.Text.Trim() + " 12:" + txtExMinutes.Text + ":00" + " " + ddlExSS.SelectedValue.ToString();
                        }
                        else
                        {
                            ExpDateTime = txtExDate.Text.Trim() + " 12:00:00 AM";
                        }
                    }

                    if (Convert.ToDateTime(ExpDateTime) < dtToday)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.ExpirationDate + "</font>";
                        addflag = false;
                    }
                }

                return addflag;

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditBulletin.aspx.cs", "ValidatePublishDate", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return false;
            }
        }


        private string BuildHeader()
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "EditBulletin.aspx.cs", "BuildHeader", string.Empty, string.Empty, string.Empty, string.Empty);


                UserID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);

                int ProfileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                string appSettings = string.Empty;

                bool IsBName = false;
                bool IsLogo = false;
                bool IsEmergencyNumber = false;
                string EmergencyPhoneNumber = "";

                string strHeader = "";
                string strfilepath = Server.MapPath("~") + "\\BulletinPreview\\CommonHeader.txt";
                StreamReader re = File.OpenText(strfilepath);
                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    strHeader = strHeader + input;
                }
                re.Close();
                re.Dispose();
                strHeader = strHeader.Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);

                //Getting Business Details
                DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                //Getting Mobile App Settings
                DataTable dtMobileAppSettings = objMobileApp.GetMobileAppSetting(UserID);
                if (dtMobileAppSettings.Rows.Count > 0)
                {
                    appSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                    var XMLTools = XElement.Parse(appSettings, LoadOptions.PreserveWhitespace);

                    IsBName = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("BName").Value);
                    IsLogo = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("Logo").Value);
                    IsEmergencyNumber = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsEmergencyNumber").Value);

                    EmergencyPhoneNumber = Convert.ToString(XMLTools.Element("Tools").Attribute("EmergencyNumber").Value);
                }
                //

                if (dtProfile.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_name"].ToString()) && IsBName == true)
                    {
                        strHeader = strHeader.Replace("#BusinessProfileName#", dtProfile.Rows[0]["Profile_name"].ToString());
                    }
                    else
                    {
                        strHeader = strHeader.Replace("#BusinessProfileName#", "");
                    }

                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_logo_path"].ToString()) && IsLogo == true)
                    {
                        strHeader = strHeader.Replace("#HeaderLogo#", objInBuiltData.GetLogoPath(dtProfile.Rows[0]["Profile_logo_path"].ToString(), RootPath, ProfileID));
                    }
                    else
                    {
                        strHeader = strHeader.Replace("#HeaderLogo#", "");
                    }
                    if (EmergencyPhoneNumber != string.Empty && IsEmergencyNumber == true)
                    {
                        strHeader = strHeader.Replace("#EmergencyNumber#", EmergencyPhoneNumber);
                    }
                    else
                    {
                        strHeader = strHeader.Replace("#EmergencyNumber#", "");
                    }
                }
                else
                {
                    strHeader = strHeader.Replace("#HeaderLogo#", "").Replace("#BusinessProfileName#", "").Replace("#EmergencyNumber#", "");
                }
                return strHeader;

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditBulletin.aspx.cs", "BuildHeader", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }
        }
    }
}