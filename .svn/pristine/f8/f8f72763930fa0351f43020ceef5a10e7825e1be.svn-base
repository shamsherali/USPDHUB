using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using USPDHUBBLL;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace USPDHUB.Business.MyAccount
{
    public partial class MediaRelease : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        UtilitiesBLL objUtilities = new UtilitiesBLL();
        BulletinBLL objBulletin = new BulletinBLL();
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        public string RootPath = "";
        public string DomainName = "";
        public string BulletinXML = string.Empty;
        string BulletinHtml = string.Empty;
        public int BulletinID = 0;
        public int BulletinCheckID = 0;
        public int TemplateBID = 0;
        public string BulletinName = string.Empty;
        public string urlinfo = string.Empty;
        public int C_UserID = 0;
        bool IsPhoneNumber = true;
        bool IsContatUs = true;
        public DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        StringBuilder strPrintHtml;
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        public bool IsScheduleEmails = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null || Session["ProfileID"] == null)
                {
                    urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    UserID = Convert.ToInt32(Session["userid"].ToString());
                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                }
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                C_UserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                if (Session["BulletinID"] != null)
                {
                    BulletinID = Convert.ToInt32(Session["BulletinID"]);
                    BulletinCheckID = Convert.ToInt32(Session["BulletinID"]);
                }
                else
                {
                    urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx");
                    Response.Redirect(urlinfo);
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
                    LoadDefaultData();
                    if (BulletinID > 0)
                        LoadFormData();
                    GetAutoShareRecordStatus();

                    if (lblEditText.Text.Trim() == string.Empty)
                    {
                        lblEditText.Text = "<div id='watermark'>Your block goes here!!!</div>";
                    }

                    //Font-Family Profile Base
                    DataTable dtProfileAddress = new DataTable();
                    dtProfileAddress = objBus.GetProfileDetailsByProfileID(ProfileID);
                    if (dtProfileAddress.Rows.Count > 0 && Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]) != "")
                    {
                        hdnUserFont.Value = Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]);
                    }
                }
                lblPublish.Text = hdnPublishTitle.Value;
                ScriptManager.RegisterStartupScript(lnkPreview, this.GetType(), "Display Publish", "DisplayComplete();", true);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MediaRelease.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetAutoShareRecordStatus()
        {
            try
            {
                if (BulletinID > 0)
                {
                    DataTable dtShareRecords = objCommon.CheckAutoShareRecordExists("Bulletin", BulletinID, BulletinName);
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
                objInBuiltData.ErrorHandling("ERROR", "MediaRelease.aspx.cs", "GetAutoShareRecordStatus", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadDefaultData()
        {
            try
            {
                DataTable dtColors = objInBuiltData.GetBulletinLabelData();
                DataTable dtCategories = objCommon.GetBulletinCategoriesByVertical(ProfileID);
                if (dtCategories.Rows.Count > 0)
                {
                    ddlCategories.DataSource = dtCategories;
                    ddlCategories.DataTextField = "Category_Name";
                    ddlCategories.DataValueField = "Category_Name";
                    ddlCategories.DataBind();

                    if (Session["BulletinCategoryName"] != null)
                        ddlCategories.SelectedValue = Session["BulletinCategoryName"].ToString();
                }
                // *** Checking Global mobile app settings *** //
                DataTable dtSelectedTools = USPDHUBDAL.MServiceDAL.GetMobileAppSetting(Convert.ToInt32(UserID));
                if (dtSelectedTools.Rows.Count > 0)
                {
                    string xmlSettings = Convert.ToString(dtSelectedTools.Rows[0]["M_SettingValue"]);
                    var XMLTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                    IsPhoneNumber = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("PhoneNumber").Value);
                    IsContatUs = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsContatUs").Value);
                    if (IsPhoneNumber)
                    {
                        divSettings.Visible = true;
                    }
                    else
                    {
                        divSettings.Visible = false;
                        chkCall.Checked = false;
                    }
                    if (IsContatUs)
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
                hdnArchive.Value = "false";
                lblLogoHeader.Text = objCommon.GetLogoHeaderText(UserID, ProfileID, RootPath);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MediaRelease.aspx.cs", "LoadDefaultData", ex.Message,
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
                    BulletinXML = Convert.ToString(dtFormData.Rows[0]["Bulletin_XML"]);
                    var XMLForm = XElement.Parse(BulletinXML, LoadOptions.PreserveWhitespace);
                    txtlocation.Text = XMLForm.Element("Bulletin").Attribute("Location").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    txtCrimeOffence.Text = XMLForm.Element("Bulletin").Attribute("CrimeOffence").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    txtSuspects.Text = XMLForm.Element("Bulletin").Attribute("Suspects").Value.Replace("&apos;", "'").Replace("&amp;", "&").Replace("##NewLineSeparator##", "\n");
                    txtExpires.Text = XMLForm.Element("Bulletin").Attribute("ExpDate").Value;
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
                    hdnArchive.Value = dtFormData.Rows[0]["IsArchive"].ToString();
                    if (!File.Exists(Server.MapPath("~") + "\\Upload\\Bulletins\\" + ProfileID.ToString() + "\\" + BulletinID.ToString() + ".jpg"))
                    {
                        objInBuiltData.CreateImage(Server.MapPath("~") + "\\Upload\\Bulletins\\", ProfileID, UserID, BulletinID, dtFormData.Rows[0]["Bulletin_HTML"].ToString());
                    }
                    if (!string.IsNullOrEmpty(txtExpires.Text.Trim()))
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
                    txtExHours.Text = XMLForm.Element("Bulletin").Attribute("ExHours").Value;
                    txtExMinutes.Text = XMLForm.Element("Bulletin").Attribute("ExMinutes").Value;
                    chkCall.Checked = Convert.ToBoolean(dtFormData.Rows[0]["IsCall"].ToString());
                    chkContact.Checked = Convert.ToBoolean(dtFormData.Rows[0]["IsContactUs"].ToString());
                    if (IsPhoneNumber == false)
                        chkCall.Checked = false;
                    if (IsContatUs == false)
                        chkContact.Checked = false;
                    if (!string.IsNullOrEmpty(dtFormData.Rows[0]["Bulletin_Category"].ToString()))
                        ddlCategories.SelectedValue = dtFormData.Rows[0]["Bulletin_Category"].ToString();
                    lblEditText.Text = "";
                    lblEditText.Text = Convert.ToString(dtFormData.Rows[0]["Custom_XML"]);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MediaRelease.aspx.cs", "LoadFormData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RemoveSession();
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx"));
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string publishValue = "1";
            try
            {
                objInBuiltData.ErrorHandling("LOG", "MediaRelease.aspx.cs", "btnSave_Click", string.Empty, string.Empty, string.Empty, string.Empty);

                string LSMonth = string.Empty;
                string LSDay = string.Empty;
                string LSYear = string.Empty;
                bool addflag = true;
                DateTime? dateExpires;
                DateTime? datePublish;
                dateExpires = null;
                datePublish = null;

                string ExHour = "";
                string ExMin = "";
                string ExSS = "AM";
                var ExTime = "";
                bool IsPublish = true;
                bool IsPrivate = true;
                int? id = null;
                if (rbPublic.Checked)
                {
                    IsPublish = false;
                    publishValue = "2";
                }
                if (rbPrivate.Checked)
                    IsPrivate = false;
                DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                if (txtPublishDate.Text.Trim() != "")
                {
                    datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                    if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0 && BulletinID == 0)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.PublishDateAlert + "</font>";
                        txt.Focus();
                        addflag = false;
                    }
                }
                if (txtExpires.Text.Trim() != "")
                {
                    string ExpDateTime = "";
                    if (!string.IsNullOrEmpty(txtExpires.Text.Trim()))
                    {
                        txtExHours.Enabled = true;
                        txtExMinutes.Enabled = true;
                        ddlExSS.Enabled = true;
                        if (!string.IsNullOrEmpty(txtExHours.Text) && !string.IsNullOrEmpty(txtExMinutes.Text))
                        {
                            ExpDateTime = txtExpires.Text.Trim() + " " + txtExHours.Text + ":" + txtExMinutes.Text + ":00" + " " + ddlExSS.SelectedValue.ToString();
                        }
                        else if (!string.IsNullOrEmpty(txtExHours.Text) && string.IsNullOrEmpty(txtExMinutes.Text))
                        {
                            ExpDateTime = txtExpires.Text.Trim() + " " + txtExHours.Text + ":00:00" + " " + ddlExSS.SelectedValue.ToString();
                        }
                        else if (string.IsNullOrEmpty(txtExHours.Text) && !string.IsNullOrEmpty(txtExMinutes.Text))
                        {
                            ExpDateTime = txtExpires.Text.Trim() + " 12:" + txtExMinutes.Text + ":00" + " " + ddlExSS.SelectedValue.ToString();
                        }
                        else
                        {
                            ExpDateTime = txtExpires.Text.Trim() + " 12:00:00 AM";
                        }
                    }
                    if (Convert.ToDateTime(ExpDateTime) < dtToday)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.ExpirationDate + "</font>";
                        txt.Focus();
                        addflag = false;
                    }
                    else
                    {
                        if (txtExHours.Text.Trim() != "" || txtExMinutes.Text.Trim() != "")
                        {
                            ExHour = txtExHours.Text;
                            if (ExHour == "")
                                ExHour = "12";
                            ExMin = txtExMinutes.Text;
                            if (ExMin == "")
                                ExMin = "00";
                            ExSS = ddlExSS.SelectedValue.ToString();

                            ExTime = ExHour + ":" + ExMin + ":00 " + ExSS;
                        }
                        else
                        {
                            ExHour = "12";
                            ExMin = "00";
                            ExSS = "AM";

                            ExTime = ExHour + ":" + ExMin + ":00 " + ExSS;
                        }
                        dateExpires = Convert.ToDateTime(txtExpires.Text.Trim() + " " + ExTime);
                    }
                }

                if (addflag)
                {

                    Image objImgage = new Image();
                    objImgage.ImageUrl =
                    BulletinXML = "<Bulletin Location='" + txtlocation.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' CrimeOffence='" + txtCrimeOffence.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "' Suspects='" + txtSuspects.Text.Trim().Replace("'", "&apos;").Replace("&", "&amp;") + "'" +
                                    "  ExpDate='" + txtExpires.Text.Trim() + "'" +
                                    "  ExHours='" + ExHour + "' ExMinutes='" + ExMin + "' ExSS='" + ExSS + "' />";
                    BulletinXML = "<Bulletins>" + BulletinXML + "</Bulletins>";

                    BulletinHtml = BuildHTML();
                    string customFormHeader = objCommon.GetCustomFormHeader(UserID);

                    string printerHtml = strPrintHtml.ToString().Replace("###CustomFormHeader###", customFormHeader);
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        string returnvalue = string.Empty;
                        if (hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //A for author
                        {
                            BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML, C_UserID, C_UserID,
                                Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked, IsPublish, dateExpires,
                                datePublish, ddlCategories.SelectedValue, false, id, printerHtml, hdnEditHTML.Value.ToString());
                            if (IsPrivate == true)
                                returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), BulletinID, PageNames.BULLETIN,
                                    UserID, Session["username"].ToString(), PageNames.PRELEASE, DomainName);
                        }
                        else if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //P for publisher
                        {
                            if (IsPrivate == true)
                                BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML,
                                    C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked,
                                    IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, C_UserID, printerHtml, hdnEditHTML.Value.ToString());
                            else
                                BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML,
                                    C_UserID, C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked,
                                    IsPublish, dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, id, printerHtml, hdnEditHTML.Value.ToString());
                        }
                    }
                    else
                    {
                        if (IsPrivate == true)
                            BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML, C_UserID,
                                C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked, IsPublish,
                                dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, C_UserID, printerHtml, hdnEditHTML.Value.ToString());
                        else
                            BulletinID = objBulletin.Insert_Update_BulletinDetails(BulletinID, TemplateBID, BulletinName, BulletinHtml, BulletinXML, C_UserID,
                                C_UserID, Convert.ToBoolean(hdnArchive.Value), UserID, ProfileID, chkCall.Checked, false, chkContact.Checked, IsPublish,
                                dateExpires, datePublish, ddlCategories.SelectedValue, IsPrivate, id, printerHtml, hdnEditHTML.Value.ToString());
                    }
                    /************************************ Auto Share ***************************************/
                    if (!(Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "") || hdnPermissionType.Value == "P")
                    {
                        if (IsPrivate)
                        {
                            if (chkFbAutoPost.Checked)
                                objCommon.InsertUpdateAutoShareDetails("Bulletin", BulletinID, 0, Convert.ToDateTime(txtPublishDate.Text), "Facebook", UserID, C_UserID, BulletinName);
                            if (chkTwrAutoPost.Checked)
                                objCommon.InsertUpdateAutoShareDetails("Bulletin", BulletinID, 0, Convert.ToDateTime(txtPublishDate.Text), "Twitter", UserID, C_UserID, BulletinName);
                        }
                    }
                    if (BulletinCheckID > 0)
                    {
                        if (rbPrivate.Checked && hdnIsAlreadyPublished.Value == "1")
                            objCommon.UpdateSentFlag(BulletinID, 2, 0, "Bulletin");
                    }
                    /****** Auto Share Completed ******/
                    objInBuiltData.CreateImage(Server.MapPath("~") + "\\Upload\\Bulletins\\", ProfileID, UserID, BulletinID, BulletinHtml);
                    Session["BulletinSuccess"] = Resources.LabelMessages.BulletingCreateSuccess.Replace("#BulletinName#", BulletinName);
                    if (BulletinCheckID > 0)
                        Session["BulletinSuccess"] = Resources.LabelMessages.BulletingUpdateSuccess.Replace("#BulletinName#", BulletinName);
                    RemoveSession();
                    urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx");
                    Response.Redirect(urlinfo);
                }

                MPEProgress.Hide();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MediaRelease.aspx.cs", "btnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowPublish('" + publishValue + "');", true);
        }
        private void RemoveSession()
        {
            Session.Remove("BulletinID");
            Session.Remove("BulletinName");
            Session.Remove("TemplateBID");
        }
        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            lblbulletinamme.Text = BulletinName;
            string htmlString = objCommon.GetHeaderForBulletins(UserID, ProfileID).Replace("#BuildHtmlForForm#", BuildHTML());
            lblPreview.Text = objCommon.ReplaceShortURltoHtmlString(htmlString);
            ModalPopupExtenderPrev.Show();

            lblEditText.Text = hdnEditHTML.Value.ToString();

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>LoadEventForPlayVideo()</script>", false);
        }
        private string BuildHTML()
        {
            try
            {
                StringBuilder strHtml = new StringBuilder();
                strPrintHtml = new StringBuilder();
                strHtml.Append("<div style=\"background: #fffdfb; overflow: hidden; width: 315px; margin: 0px; padding: 15px 0px 0px 0px;\">");
                strHtml.Append("<div style=\"font-size: 26px; line-height: 28px; font-weight: normal; color: #f15b29; text-align: center; padding: 0px 0px 10px 0px; border-bottom: 1px dashed #d1d1d1;\">Media Release</div>");

                strPrintHtml.Append("<div style=\"font-family: Arial, Helvetica, sans-serif; font-size: 14px; width: 675px; margin: 0 auto; padding: 10px; text-align: left;\">");
                strPrintHtml.Append("###CustomFormHeader###");
                strPrintHtml.Append("<h1 style=\"font-size: 14px; text-align: center; color: #444444; text-decoration: underline; font-weight: bold;\">MEDIA RELEASE</h1>");
                strHtml.Append("<table border='0' cellspacing='0' cellpadding='0' style='background: #fffdfb; overflow: hidden; width: 300px; margin: 0px; padding: 10px 0px 10px 0px;  text-align:left;'>");

                strPrintHtml.Append("<div style=\"font-size: 14px; line-height: 25px; font-weight: normal; margin-left:50px;\">");
                // Dynamic Boxes
                strHtml.Append("<tr>");
                strHtml.Append("<td colspan='4' style='padding: 6px 4px 4px 4px;'>" + hdnPreviewHTML.Value.ToString() + "</td></tr><tr>");
                strPrintHtml.Append("<div style=\"font-weight: bold; width: 600px; margin:0px auto;\">" + hdnPreviewHTML.Value.ToString() + "</div>");
                //*** Location
                if (txtlocation.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='vpadding: 6px 4px 0px 4px;'>Location :</td></tr><tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtlocation.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");

                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 110px; margin-right: 10px; margin-bottom: 10px;\">Location:</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 490px; margin-bottom: 10px;\">" + txtlocation.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                //*** Crime/Offence
                if (txtCrimeOffence.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 6px 4px 0px 4px;'>Crime/Offense :</td></tr><tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtCrimeOffence.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 110px; margin-right: 10px; margin-bottom: 10px;\">Crime/Offense:</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 490px; margin-bottom: 10px;\">" + txtCrimeOffence.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                //*** Suspects
                if (txtSuspects.Text.Trim() != "")
                {
                    strHtml.Append("<tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; padding: 6px 4px 0px 4px;'>Suspect(s) :</td></tr><tr>");
                    strHtml.Append("<td colspan='2' style='page-break-inside: avoid; color: #353535; padding-left: 8px;'>" + txtSuspects.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</td></tr>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; font-weight: bold; float: left; width: 110px; margin-right: 10px; margin-bottom: 10px;\">Suspect(s):</div>");
                    strPrintHtml.Append("<div style=\"page-break-inside: avoid; float: left; width: 490px; margin-bottom: 10px;\">" + txtSuspects.Text.Trim().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</div>");
                }
                strHtml.Append("</table></div>");
                strPrintHtml.Append("</div></div>");
                BulletinHtml = strHtml.ToString().Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);
                return BulletinHtml;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "MediaRelease.aspx.cs", "BuildHTML", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }
        }
        private string BuildHeader()
        {
            try
            {
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
                DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                if (dtProfile.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_name"].ToString()))
                        strHeader = strHeader.Replace("#BusinessProfileName#", dtProfile.Rows[0]["Profile_name"].ToString());
                    else
                        strHeader = strHeader.Replace("#BusinessProfileName#", "");
                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_logo_path"].ToString()))
                        strHeader = strHeader.Replace("#HeaderLogo#", objInBuiltData.GetLogoPath(dtProfile.Rows[0]["Profile_logo_path"].ToString(), RootPath, ProfileID));
                    else
                        strHeader = strHeader.Replace("#HeaderLogo#", "");
                    strHeader = strHeader.Replace("#EmergencyNumber#", "");
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
                objInBuiltData.ErrorHandling("ERROR", "MediaRelease.aspx.cs", "BuildHeader", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return string.Empty;
            }
        }
    }
}