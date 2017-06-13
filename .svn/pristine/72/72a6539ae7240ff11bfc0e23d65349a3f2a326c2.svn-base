using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using USPDHUBBLL;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Xml;


namespace USPDHUB.Business.MyAccount
{
    public partial class MostWanted : System.Web.UI.Page
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public int CUserID = 0;
        public int BulletinID = 0;
        public int BulletinCheckID = 0;
        public string RootPath = "";
        public string DomainName = "";
        public int TemplateBID = 0;
        public string BulletinName = string.Empty;
        public string BulletinXML = string.Empty;
        public string urlinfo = string.Empty;
        bool IsPhoneNumber = true;
        bool IsContatUs = true;
        DateTime dtToday;
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        BulletinBLL objBulletin = new BulletinBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        BusinessBLL objBus = new BusinessBLL();
        public bool IsScheduleEmails = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserID = Convert.ToInt32(Session["userid"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                CUserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                if (Session["BulletinID"] != null)
                {
                    BulletinID = Convert.ToInt32(Session["BulletinID"]);
                    BulletinCheckID = Convert.ToInt32(Session["BulletinID"]);
                }
                else
                {
                    //urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx");
                    //Response.Redirect(urlinfo);
                }
                if (Session["TemplateBID"] != null)
                    TemplateBID = Convert.ToInt32(Session["TemplateBID"]);
                if (Session["BulletinName"] != null)
                    BulletinName = Session["BulletinName"].ToString();
                /*** Store Module Functionality ***/
                if (objBus.CheckModulePermission(WebConstants.Purchase_ScheduleEmailsSetup, ProfileID))
                {
                    IsScheduleEmails = true;
                }
                if (!IsPostBack)
                {
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Bulletins");
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            UpdatePanel3.Visible = true;
                            UpdatePanel2.Visible = UpdatePanel1.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create content.</font>";
                        }
                        else if (hdnPermissionType.Value == "A")
                            hdnPublishTitle.Value = Resources.LabelMessages.AuthorPublishTitle;
                    }
                    //ends here
                    LoadFormDefaultData();
                    if (BulletinID > 0)
                        LoadFormData();
                    GetAutoShareRecordStatus();
                }
                lblPublish.Text = hdnPublishTitle.Value;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MostWanted.aspx.cs", "Page_Load", ex.Message,
                 Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadFormDefaultData()
        {
            try
            {
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
                lblLogoHeader.Text = objCommon.GetLogoHeaderText(UserID, ProfileID, RootPath);
                string preview = string.Empty;
                preview = objCommon.GetHeaderForBulletins(UserID, ProfileID, true);
                hdnBulletinHeader.Value = preview;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MostWanted.aspx.cs", "LoadFormDefaultData", ex.Message,
                 Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetAutoShareRecordStatus()
        {
            try
            {
                int bulletinID = 0;
                if (Session["BulletinID"] != null && Convert.ToString(Session["BulletinID"]) != "")
                    bulletinID = Convert.ToInt32(Session["BulletinID"]);
                if (bulletinID > 0)
                {
                    DataTable dtShareRecords = objCommon.CheckAutoShareRecordExists("Bulletin", bulletinID, BulletinName);
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
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MostWanted.aspx.cs", "GetAutoShareRecordStatus", ex.Message,
                 Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadFormData()
        {
            try
            {
                DataTable dtFormData = objBulletin.GetBulletinDetailsByID(BulletinID);
                if (dtFormData.Rows.Count > 0)
                {
                    BulletinID = Convert.ToInt32(dtFormData.Rows[0]["Bulletin_ID"]);
                    Session["BulletinName"] = BulletinName = dtFormData.Rows[0]["Bulletin_Title"].ToString();
                    Session["TemplateBID"] = TemplateBID = Convert.ToInt32(dtFormData.Rows[0]["Template_BID"]);
                    //BulletinXML = Convert.ToString(dtFormData.Rows[0]["Bulletin_XML"]);
                    //var XMLForm = XElement.Parse(BulletinXML, LoadOptions.PreserveWhitespace);
                    hdnEditHTML.Value = Convert.ToString(dtFormData.Rows[0]["Bulletin_XML"]).Replace("undefined", "").Replace("id=\"trheader", "class=\"trheader\" id=\"trheader");
                    lblBulletinedit.Text = hdnEditHTML.Value;
                    string previewHtml = Convert.ToString(dtFormData.Rows[0]["Bulletin_HTML"]);
                    hdnPreviewHTML.Value = previewHtml;

                    lbldummy.Text = previewHtml;
                    DateTime dtNow = objCommon.ConvertToUserTimeZone(ProfileID);
                    if (!string.IsNullOrEmpty(dtFormData.Rows[0]["Publish_Date"].ToString()))
                    {
                        DateTime dtPublish = Convert.ToDateTime(dtFormData.Rows[0]["Publish_Date"]);
                        if (DateTime.Compare(dtPublish, dtNow) < 0)
                            txtPublishDate.Text = dtNow.ToShortDateString();
                        else
                            txtPublishDate.Text = dtPublish.ToShortDateString();
                    }
                    rbPrivate.Checked = true;
                    if (Convert.ToBoolean(dtFormData.Rows[0]["IsPrivate"].ToString()) == false)
                    {
                        rbPublic.Checked = true;
                        hdnIsAlreadyPublished.Value = "1";
                    }


                    if (!File.Exists(Server.MapPath("~") + "\\Upload\\Bulletins\\" + ProfileID.ToString() + "\\" + BulletinID.ToString() + ".jpg"))
                    {
                        objInBuiltData.CreateImage(Server.MapPath("~") + "\\Upload\\Bulletins\\", ProfileID, UserID, BulletinID, dtFormData.Rows[0]["Bulletin_HTML"].ToString());
                    }
                    if (!string.IsNullOrEmpty(txtExDate.Text.Trim()))
                    {
                        txtExHours.Enabled = true;
                        txtExMinutes.Enabled = true;
                        ddlExSS.Enabled = true;
                    }
                    else
                    {
                        txtExHours.Enabled = false;
                        txtExMinutes.Enabled = false;
                        ddlExSS.Enabled = false;
                    }
                    if (Convert.ToString(dtFormData.Rows[0]["Expiration_Date"]) != string.Empty)
                    {
                        txtExDate.Text = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]).ToShortDateString();
                        txtExHours.Enabled = true;
                        txtExMinutes.Enabled = true;
                        ddlExSS.Enabled = true;
                        DateTime expiryTime = Convert.ToDateTime(dtFormData.Rows[0]["Expiration_Date"]);
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
                    chkCall.Checked = Convert.ToBoolean(dtFormData.Rows[0]["IsCall"].ToString());
                    chkContact.Checked = Convert.ToBoolean(dtFormData.Rows[0]["IsContactUs"].ToString());
                    if (IsPhoneNumber == false)
                        chkCall.Checked = false;
                    if (IsContatUs == false)
                        chkContact.Checked = false;
                    if (!string.IsNullOrEmpty(dtFormData.Rows[0]["Bulletin_Category"].ToString()))
                        ddlCategories.SelectedValue = dtFormData.Rows[0]["Bulletin_Category"].ToString();
                    hdnEditXML.Value = Convert.ToString(dtFormData.Rows[0]["Custom_XML"]);
                    XmlDocument xmldoc = new XmlDocument();
                    if (hdnEditXML.Value.Trim() != "")
                    {
                        if (xmldoc.SelectSingleNode("Bulletins/Details/@Description") != null)
                        {
                            if (!string.IsNullOrEmpty(xmldoc.SelectSingleNode("Bulletins/Details/@Description").Value.ToString()))
                                txtDesc.Text = xmldoc.SelectSingleNode("Bulletins/Details/@Description").Value.ToString();
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "LoadData();", true);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MostWanted.aspx.cs", "LoadFormData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePublishDate())
                {
                    Save_Update_Details();
                    Session["msgSave"] = "Content has been saved successfully.";
                    string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx");
                    Response.Redirect(urlinfo);
                }
                lblBulletinedit.Text = "";
                lblBulletinedit.Text = hdnEditHTML.Value;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MostWanted.aspx.cs", "BtnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private bool ValidatePublishDate()
        {
            try
            {
                bool addflag = true;
                dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                if (txtPublishDate.Text.Trim() != "")
                {
                    DateTime publishDate = Convert.ToDateTime(txtPublishDate.Text.Trim());
                    if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && Convert.ToInt32(System.Web.HttpContext.Current.Session["BulletinID"]) == 0)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.PublishDateAlert + "</font>";
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
                objInBuiltData.ErrorHandling("ERROR", "MostWanted.aspx.cs", "ValidatePublishDate", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return false;
            }
        }
        private bool Save_Update_Details()
        {
            bool isSuccess = true;
            try
            {
                //Type 1 == Preview 
                //Type 2 == Save
                //Type 3 == Save & Publish 

                string editHtmlText = hdnEditHTML.Value.ToString().Replace("class=\"trheader\" id=\"trheader", "id=\"trheader");
                string previewHtml = hdnPreviewHTML.Value.ToString();
                string exDate = hdnExDate.Value.ToString();
                string customXML = hdnEditXML.Value;

                DateTime? datePublish;
                datePublish = null;

                int bulletinID = Convert.ToInt32(System.Web.HttpContext.Current.Session["BulletinID"]);
                int templateBid = Convert.ToInt32(System.Web.HttpContext.Current.Session["TemplateBID"]);
                string bulletinTitle = Convert.ToString(System.Web.HttpContext.Current.Session["BulletinName"]);
                int userID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
                bool isArchive = false;
                int profileID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
                bool isCall = false;
                bool isPhotoCapture = false;
                bool isContactUs = false;
                int? id = null;
                bool isPublish = false;

                if (hdnPrivate.Value.ToString().Trim() != string.Empty)
                {
                    isPublish = Convert.ToBoolean(hdnPrivate.Value.ToString().Trim());
                }

                string printHTML = "";
                string CategoryName = ddlCategories.SelectedValue;

                if (rbPublic.Checked)
                {
                    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                }


                string exHour = "";
                string exMin = "";
                string exSS = "AM";
                var exTime = "";

                bool isPrivate = true;
                if (rbPrivate.Checked)
                {
                    isPrivate = false;
                    // isPublish = false;
                }
                int bulletinCheckID = 0;
                if (exDate == string.Empty)
                {
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, false, id, printHTML, customXML);
                            if (isPrivate == true)
                                objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), bulletinID, PageNames.BULLETIN, userID, Session["username"].ToString(), PageNames.BULLETIN, DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            if (isPrivate == true)
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, isPrivate, CUserID, printHTML, customXML);
                            }
                            else
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, isPrivate, id, printHTML, customXML);
                            }
                        }
                    }
                    else
                    {
                        if (isPrivate == true)
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, isPrivate, CUserID, printHTML, customXML);
                        }
                        else
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, CUserID, CUserID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, null, datePublish, CategoryName, isPrivate, id, printHTML, customXML);
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
                    bulletinCheckID = bulletinID;
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        string returnvalue = string.Empty;
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate, datePublish, CategoryName, false, id, printHTML, customXML);
                            if (isPrivate == true)
                                returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), bulletinID, "Bulletin", userID, Session["username"].ToString(), "Bulletin", DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))
                        {
                            if (isPrivate == true)
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate, datePublish, CategoryName, isPrivate, CUserID, printHTML, customXML);
                            }
                            else
                            {
                                bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                                editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate, datePublish, CategoryName, isPrivate, id, printHTML, customXML);
                            }
                        }
                    }
                    else
                    {
                        if (isPrivate == true)
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate, datePublish, CategoryName, isPrivate, CUserID, printHTML, customXML);
                        }
                        else
                        {
                            bulletinID = objBulletin.Insert_Update_BulletinDetails(bulletinID, templateBid, bulletinTitle, previewHtml,
                            editHtmlText, userID, userID, isArchive, userID, profileID, isCall, isPhotoCapture, isContactUs, isPublish, expiryDate, datePublish, CategoryName, isPrivate, id, printHTML, customXML);
                        }
                    }
                }

                //Create Bulletin Image
                objInBuiltData.CreateImage(System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\Bulletins\\", profileID, userID, Convert.ToInt32(bulletinID), previewHtml);

                /************************************ Auto Share ***************************************/
                if (!(Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "") || hdnPermissionType.Value == "P")
                {
                    if (isPrivate)
                    {
                        if (txtPublishDate.Text == "")
                        { txtPublishDate.Text = dtToday.ToShortDateString(); }


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

                //Messages
                if (Convert.ToInt32(Session["BulletinID"]) == 0)
                {
                    Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", bulletinTitle);
                }
                else
                {
                    Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", bulletinTitle);
                }
                Session["BulletinID"] = bulletinID;
            }
            catch (Exception ex)
            {
                //Error 
                isSuccess = false;
                objInBuiltData.ErrorHandling("ERROR", "MostWanted.aspx.cs", "Save_Update_Details", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return isSuccess;
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx");
                HttpContext.Current.Response.Redirect(urlinfo);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MostWanted.aspx.cs", "BtnCancel_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        [WebMethod]
        public static string LoadDefaultData(string pType)
        {
            InBuiltDataBLL objInBuiltDataMW = new InBuiltDataBLL();
            DataTable dtLabelData = objInBuiltDataMW.GetBulletinLabelData();

            // type: Gender
            // 
            DataRow[] drRows = dtLabelData.Select("Type='" + pType + "'");


            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (System.Data.DataRow dr in drRows)
            {
                row = new Dictionary<string, object>();
                foreach (System.Data.DataColumn col in dtLabelData.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);

        }
        [WebMethod]
        public static string LoadFeetList()
        {
            InBuiltDataBLL objInBuiltDataMW = new InBuiltDataBLL();
            List<HeightFeet> heightFeet = objInBuiltDataMW.GetHeightFeet();
            DataTable dtLabelData = ConvertToDatatable(heightFeet);
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (System.Data.DataRow dr in dtLabelData.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (System.Data.DataColumn col in dtLabelData.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }

        [WebMethod]
        public static string LoadInchesList()
        {
            InBuiltDataBLL objInBuiltDataMW = new InBuiltDataBLL();
            List<HeightInches> heightInches = objInBuiltDataMW.GetHeightInches();
            DataTable dtLabelData = ConvertToDatatable(heightInches);
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (System.Data.DataRow dr in dtLabelData.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (System.Data.DataColumn col in dtLabelData.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }

        private static DataTable ConvertToDatatable<T>(List<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            try
            {
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                    else
                        table.Columns.Add(prop.Name, prop.PropertyType);
                }
                object[] values = new object[props.Count];
                foreach (T item in data)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MostWanted.aspx.cs", "ConvertToDatatable", ex.Message,
                 Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return table;
        }

        [System.Web.Services.WebMethod]
        public static string ReplaceShortURltoHmlString(string htmlString)
        {
            CommonBLL objCommonBll = new CommonBLL();
            htmlString = objCommonBll.ReplaceShortURltoHtmlString(htmlString);

            return htmlString;
        }
    }
}