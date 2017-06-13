using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using USPDHUBBLL;
using System.Web.UI;
using System.Collections.Generic;
using Facebook;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Xml;

namespace USPDHUB.Business.MyAccount
{
    public partial class SendAppNotifications : BaseWeb
    {
        //SslStream sslStream;
        public int ProfileID = 0;
        public int UserID = 0;
        public int CUserID = 0;
        public int TotalSendCount = 0;
        public string DeviceIds = string.Empty;
        public string RootPath = string.Empty;
        MServiceBLL objMobile = new MServiceBLL();
        BusinessBLL objBus = new BusinessBLL();
        public int SortDir = 0;
        DataTable dtProfile = new DataTable();
        string profilename = "";
        public DataTable Dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        public string PermissionType = string.Empty;
        public int PermissionValue = 0;
        public string PushType = "General";
        public int PushTypeID = 0;
        public string DomainName = "";
        BulletinBLL objBulletin = new BulletinBLL();
        EventCalendarBLL eventsadminobj = new EventCalendarBLL();
        BusinessUpdatesBLL objUpdate = new BusinessUpdatesBLL();
        SurveyBLL objSurveyBLL = new SurveyBLL();
        AddOnBLL objAddOn = new AddOnBLL();
        CalendarAddOnBLL objCalendarAddOn = new CalendarAddOnBLL();
        CommonBLL objCommon = new CommonBLL();
        SMSBLL objSMS = new SMSBLL();
        USPDHUBBLL.MobileAppSettings objApp = new USPDHUBBLL.MobileAppSettings();
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        public string FacebookInurlinfo = string.Empty;
        public string Twitterurlinfo = string.Empty;
        public string titleName = "";
        public int CustomModuleId = 0;
        bool IsPrivateModule = false;

        string appID = string.Empty;    //Facebook App ID and Secret
        string appSecret = string.Empty;
        string fbScope = ConfigurationManager.AppSettings.Get("FBScopes");//"public_profile,publish_actions,publish_stream,manage_pages";
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

        public bool IsScheduledPushNotification = false;
        public bool IsSurveys = false;

        public int contactsCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Chcking for user session ***
                if (Session["UserID"] == null || Session["ProfileID"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    if (Session["ProfileID"] != null)
                        ProfileID = Convert.ToInt32(Session["ProfileID"]);

                    UserID = Convert.ToInt32(Session["UserID"]);

                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                        CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        CUserID = UserID;
                }
                //Checking Private Module or not for SMS Notification
                if (Session["CustomModuleID"] != null)
                {
                    CustomModuleId = Convert.ToInt32(Session["CustomModuleID"].ToString());
                    DataTable dtAddOn = new DataTable();
                    dtAddOn = objAddOn.GetAddOnById(CustomModuleId);
                    if (dtAddOn.Rows.Count == 1)
                    {
                        if (dtAddOn.Rows[0]["ButtonType"].ToString() == WebConstants.Tab_PrivateContentAddOns)
                            IsPrivateModule = true;

                    }
                    if (File.Exists(Server.MapPath("~") + "\\Upload\\CustomModules\\" + ProfileID.ToString() + "\\" + Request.QueryString["CustomID"] + ".jpg"))
                        lblbulletinthumb.Text = "<img src='" + RootPath + "/Upload/CustomModules/" + ProfileID.ToString() + "/" + Request.QueryString["CustomID"] + ".jpg?' width='100' height='150'/>";
                }
                else
                {
                    if (File.Exists(Server.MapPath("~") + "\\Upload\\Bulletins\\" + ProfileID.ToString() + "\\" + Request.QueryString["bullitenID"] + ".jpg"))
                        lblbulletinthumb.Text = "<img src='" + RootPath + "/Upload/Bulletins/" + ProfileID.ToString() + "/" + Request.QueryString["bullitenID"] + ".jpg' border='1' width='100' height='150'/>";

                }

                //Store Module Functionality
                if (objBus.CheckModulePermission(WebConstants.Purchase_ScheduleEmailsSetup, ProfileID))
                {
                    IsScheduledPushNotification = true;
                }


                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                lnkSend.Visible = true;
                GetFacebookAppDetails();
                titleName = objApp.GetMobileAppSettingTabName(UserID, "Notifications", DomainName);
                lblTitle.Text = titleName;

                lblSuccess.Text = "";
                if (!IsPostBack)
                {
                    if (Request["code"] != null)
                    {
                        ShareOnFacebook();
                    }
                    if (Request.QueryString["fbStatus"] != null)
                    {
                        if (Convert.ToInt32(Request.QueryString["fbStatus"]) == 1)
                        {
                            objCommon.UpdateSocialShareStatus(UserID, 1, "Facebook", Convert.ToInt32(Session["ContentID"]), 1);//updating status flag for report
                            lblSuccess.Text = "<font size='2' color='green'>Your content has been posted on facebook successfully.</font>";
                        }
                        if (Convert.ToInt32(Request.QueryString["fbStatus"]) == 0)
                        {
                            objCommon.UpdateSocialShareStatus(UserID, 0, "Facebook", Convert.ToInt32(Session["ContentID"]), 0);//updating status flag for report
                            lblSuccess.Text = "<font size='2' color='red'>Facebook server is not responding. Please try again later.</font>";
                        }
                    }


                    lblOff.Visible = true;
                    if (objCommon.DisplayOn_OffSettingsContent(UserID, "Notifications"))
                    {
                        lblOn.Visible = true;
                        lblOff.Visible = false;
                    }

                    LoadAutoShare();
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "PushNotifications");
                        if (hdnPermissionType.Value == "A")
                        {
                            lnkSend.Visible = false;
                            NotificationGrid.Enabled = lnkSend.Enabled = txtNoticication.Enabled = false;
                            lblSuccess.Text = "<font face=arial size=2 color=red>You do not have permission to send notifications.</font>";
                        }
                    }
                    //ends here

                    DataTable dtConfigPageKeys = objCommon.GetVerticalConfigsByType(DomainName, "Social");
                    if (dtConfigPageKeys.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtConfigPageKeys.Rows)
                        {
                            if (row[0].ToString() == "FacebookAPIKey")
                                hdnFacebookAppId.Value = row[1].ToString();
                        }
                    }

                    hdnsortdire.Value = "";
                    hdnsortcount.Value = "0";
                    GetPrepoulateSettings();
                    LoadProfileName();
                    LoadSendNotifications();
                    CheckSMSPurchase();
                    visibilitySMSCount();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void visibilitySMSCount()
        {
            DataTable dtSMSCount = new DataTable();
            dtSMSCount = objSMS.GetAllSMSCount(ProfileID);
            foreach (DataRow row in dtSMSCount.Rows)
            {
                lblSMSCount.Text = Convert.ToString(row["SMS_Sent_Count"]);
                lblScheduleCount.Text = Convert.ToString(row["SMS_Scheduled_Sent_Count"]);
                string temp = Convert.ToString(row["Remaining_SMS_Count"]);
                if (Convert.ToInt32(temp) <= 0)
                {
                    chkSMS.Enabled = false;
                    lblSMSExceed.Text = Resources.LabelMessages.SMSAvailableExceeded.ToString();
                    lnkBuyMoreSMS.Style.Add("display", "block");
                }
                else
                    chkSMS.Enabled = true;
            }
        }
        private void CheckSMSPurchase()
        {
            pnlSMS.Visible = false;
            pnlPsuh.Visible = false;
            if (string.IsNullOrEmpty(Convert.ToString(ViewState["PushType"])))
            {
                if (Convert.ToBoolean(hdnIsSMS.Value))
                {
                    pnlSMS.Visible = true;
                    pnlPsuh.Visible = true;
                }
            }
        }
        private void LoadAutoShare()
        {
            try
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
                    chkFbAutoPost.Visible = false;
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
                    chkTwrAutoPost.Visible = false;
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "LoadAutoShare", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ViewState["PushType"])))
                    PushType = Convert.ToString(ViewState["PushType"]);
                if (PushType == "Bulletin")
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx"));
                else if (PushType == "Update")
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageUpdates.aspx"));
                else if (PushType == "Event")
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageEventsCalendar.aspx"));
                else if (PushType == "Survey")
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageSurvey.aspx"));
                else if (PushType == "CustomModule") // *** Change usp_Mob_GetFavoriteDevices procedure if change the type 'CustomModule' *** //
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAddOns.aspx"));
                else if (PushType == WebConstants.Tab_CalendarAddOns)
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/" + WebConstants.ManageUrl_CalendarAddOns));
                else
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "lnkCancel_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string messageSendType = "";
                int SMSID = 0;
                int GroupID = 0;
                DataTable dtContactIds = new DataTable();
                int ContactID = 0;
                bool isSend = false;
                int sentFlag = 0;
                int pushID = 0;
                DateTime dtSentDate = DateTime.Now;
                string pushMessage = "";
                string ContentTitle = txtNoticication.Text.Trim();
                try
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ViewState["PushType"])))
                        PushType = Convert.ToString(ViewState["PushType"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(ViewState["PushTypeID"])))
                        PushTypeID = Convert.ToInt32(ViewState["PushTypeID"]);
                    pushMessage = txtNoticication.Text.Trim();
                    if (rbSchedule.Checked)
                    {
                        if (txtSendingDate.Text.Trim() != string.Empty && txtStrHours.Text.Trim() != "" && txtStrMins.Text.Trim() != "")
                        {
                            dtSentDate = Convert.ToDateTime(txtSendingDate.Text.Trim() + " " + txtStrHours.Text.Trim() + ":" + txtStrMins.Text.Trim() + " " + ddlStrAPM.SelectedValue);
                            dtSentDate = objCommon.GetScheduleDateInPST(ProfileID, dtSentDate);
                            isSend = true;
                        }
                    }
                    else
                    {
                        //sentFlag = 1; // *** Uncomment this line if client want to send notification through web service means send right away *** //
                        isSend = true;
                    }
                    if (isSend)
                    {
                        string pushSendType = "PushNotification";
                        if (!chkPush.Checked)
                        {
                            messageSendType = "(T)";
                            pushSendType = "SMSNotification";
                        }
                        else if (!chkSMS.Checked)
                            messageSendType = "(P)";
                        else if (chkSMS.Checked == true && chkPush.Checked == true)
                            messageSendType = "(P)(T)";
                        else
                            messageSendType = "";

                        pushID = objMobile.AddPushNotifications(pushMessage, ProfileID, CUserID, 0, TotalSendCount, DeviceIds, pushID, PushType, PushTypeID, sentFlag, dtSentDate, pushSendType, messageSendType);
                        if (pushID > 0)
                        {
                            if (string.IsNullOrEmpty(dtSentDate.ToString()))
                            {
                                dtSentDate = DateTime.Now;
                            }
                            if (chkSMS.Checked)
                            {
                                // Checking Contacts less that Number SMS
                                if (GVContacts.Rows.Count <= Convert.ToInt32(lblRemainingCount.Text))
                                {
                                    foreach (GridViewRow row in GVContacts.Rows)
                                    {
                                        if (row.RowType == DataControlRowType.DataRow)
                                        {
                                            CheckBox chkRow = (row.Cells[0].FindControl("cbSelect") as CheckBox);
                                            if (chkRow.Checked)
                                            {
                                                ContactID = Convert.ToInt32(GVContacts.DataKeys[row.RowIndex].Value);
                                                GroupID = Convert.ToInt32((row.Cells[3].FindControl("lblGroupID") as Label).Text);

                                                SMSID = objSMS.AddSMSNotification(pushMessage, ContactID, GroupID, pushID, dtSentDate, ProfileID, 0);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    lblSMSExceed.Text = Resources.LabelMessages.SMSAvailableExceeded.Replace("#SelectedContacts#", GVContacts.Rows.Count.ToString()).Replace("#AvailableSMSCredits#", lblRemainingCount.Text);
                                }//
                            }
                        }
                        if (sentFlag == 1 && pushSendType == "PushNotification")
                        {
                            PushNotificationService.SendNitificationsSoapClient objPushNoficationSer = new PushNotificationService.SendNitificationsSoapClient();
                            string notificationUrl = ConfigurationManager.AppSettings.Get("PushNotificationServiceURL");
                            objPushNoficationSer.Endpoint.Address = new System.ServiceModel.EndpointAddress(notificationUrl);
                            objPushNoficationSer.SendAppNotifications(ProfileID, pushMessage, dtSentDate, PushType, PushTypeID);
                        }
                        BindDefaults();

                    }
                    chkSMS.Checked = false;
                    chkPush.Checked = true;
                    if (GVContacts.Rows.Count > 0)
                    {
                        DataTable dtContacts = new DataTable();
                        GVContacts.DataSource = dtContacts;
                        GVContacts.DataBind();
                        contactsCount = 0;
                        Session["DtContacts"] = null;
                    }
                    SMSSentCount();
                    BindSMSGroups();

                }
                catch (Exception /*Exception*/)
                {

                }
                if (isSend)
                {
                    AutoShareOnSocialMedia(dtSentDate, pushID,ContentTitle);
                    objCommon.InsertUserActivityLog("has " + (sentFlag == 1 ? "sent " : "scheduled") + " a pushnotification on <b>" + dtSentDate + "</b> " + (pushMessage.Length < 50 ? pushMessage : (pushMessage.Substring(0, 50) + "...")), string.Empty, UserID, ProfileID, DateTime.Now, CUserID);
                    if (sentFlag == 1)
                        Session["BulletinSuccess"] = "<font color='green' size='2'>" + Resources.LabelMessages.SentPushNotification + "</font>";
                    else
                        Session["BulletinSuccess"] = "<font color='green' size='2'>" + Resources.LabelMessages.SchedulePushNotification + "</font>";

                    if (PushType == "Bulletin")
                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx"));
                    else if (PushType == "Update")
                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageUpdates.aspx"));
                    else if (PushType == "Event")
                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageEventsCalendar.aspx"));
                    else if (PushType == "Survey")
                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageSurvey.aspx"));
                    if (PushType == "CustomModule") // *** Change usp_Mob_GetFavoriteDevices procedure if change the type 'CustomModule' *** //
                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAddOns.aspx"));
                    if (PushType == WebConstants.Tab_CalendarAddOns)
                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/" + WebConstants.ManageUrl_CalendarAddOns));
                    LoadSendNotifications();
                    MPEProgress.Hide();
                    lblSuccess.Text = Session["BulletinSuccess"].ToString();
                    Session.Remove("BulletinSuccess");
                    LoadAutoShare();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "ChangeSchedule('1');", true);
                }
                lnkSend.Visible = true;
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "btnSend_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BindDefaults()
        {
            txtSendingDate.Text = "";
            txtStrHours.Text = "";
            txtStrMins.Text = "";
            rbSchedule.Checked = false;
            rbSendNow.Checked = true;
            ddlStrAPM.SelectedIndex = 0;
        }
        public void LoadProfileName()
        {
            try
            {
                DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                if (dtProfile.Rows.Count > 0)
                {
                    hdbProfileName.Value = profilename = dtProfile.Rows[0]["Profile_name"].ToString();
                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["IsSms"].ToString()))
                        hdnIsSMS.Value = dtProfile.Rows[0]["IsSms"].ToString();
                    hdnIsLiteVersion.Value = Convert.ToString(dtProfile.Rows[0]["IsLiteVersion"]);
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "LoadProfileName", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public void LoadSendNotifications()
        {
            try
            {
                DataTable dtSendNotifications = objBus.GetSendNotifications(ProfileID);
                Session["DtSendNotifications"] = dtSendNotifications;
                NotificationGrid.DataSource = dtSendNotifications;
                NotificationGrid.DataBind();
                if (dtSendNotifications.Rows.Count > 0)
                    hdnMessageType.Value = dtSendNotifications.Rows[0]["MessageType"].ToString();

                if (dtSendNotifications.Rows.Count > 0)
                    pnlShareSocial.Visible = true;
                else
                    pnlShareSocial.Visible = false;

                string defaultstr = hdbProfileName.Value + " - ";
                // *** Concatinating bulletin, event or update title 04-06-2013 *** //
                DataTable dtBulletinCheck = new DataTable(); // *** Check means user tries to create new bulletin *** //
                if (Session["PushNotifyType"] != null)
                {
                    string[] typesplit = Session["PushNotifyType"].ToString().Split(',');
                    PushType = typesplit[0];
                    PushTypeID = Convert.ToInt32(typesplit[1]);
                    ViewState["PushType"] = PushType;
                    ViewState["PushTypeID"] = PushTypeID;
                    if (PushType == "Bulletin")
                    {
                        dtBulletinCheck = objBulletin.GetBulletinByID(PushTypeID);
                        if (dtBulletinCheck.Rows.Count > 0)
                            defaultstr = defaultstr + dtBulletinCheck.Rows[0]["Bulletin_Title"].ToString();
                    }
                    else if (PushType == "Update")
                    {
                        dtBulletinCheck = objUpdate.UpdateBusinessUpdateDetails(Convert.ToInt32(PushTypeID));
                        if (dtBulletinCheck.Rows.Count > 0)
                            defaultstr = defaultstr + dtBulletinCheck.Rows[0]["UpdateTitle"].ToString();
                    }
                    else if (PushType == "Event")
                    {
                        dtBulletinCheck = eventsadminobj.GetCalendarEventDetails(PushTypeID);
                        if (dtBulletinCheck.Rows.Count > 0)
                            defaultstr = defaultstr + dtBulletinCheck.Rows[0]["EventTitle"].ToString();
                    }
                    else if (PushType == "Survey")
                    {
                        dtBulletinCheck = objSurveyBLL.GetSurveyDetailsByID(PushTypeID);
                        if (dtBulletinCheck.Rows.Count > 0)
                            defaultstr = defaultstr + dtBulletinCheck.Rows[0]["Name"].ToString();
                        //Disable and Unchecked the FB and Twitter for Survey
                        chkFbAutoPost.Style.Add("display", "none");
                        chkTwrAutoPost.Style.Add("display", "none");
                        chkFbAutoPost.Checked = false;
                        chkTwrAutoPost.Checked = false;
                    }
                    else if (PushType == "CustomModule")
                    {
                        dtBulletinCheck = objAddOn.GetCustomModuleByID(PushTypeID);
                        if (dtBulletinCheck.Rows.Count > 0)
                        {
                            if (dtBulletinCheck.Rows[0]["ButtonType"].ToString() == WebConstants.Tab_PrivateContentAddOns)
                            {
                                hdnIsPrivate.Value = "true";
                                chkFbAutoPost.Checked = false;
                                chkTwrAutoPost.Checked = false;
                            }
                            defaultstr = defaultstr + dtBulletinCheck.Rows[0]["Bulletin_Title"].ToString();
                        }
                    }
                    else if (PushType == WebConstants.Tab_CalendarAddOns)
                    {
                        dtBulletinCheck = objCalendarAddOn.GetCalendarAddOnDetails(PushTypeID);
                        if (dtBulletinCheck.Rows.Count > 0)
                            defaultstr = defaultstr + dtBulletinCheck.Rows[0]["EventTitle"].ToString();
                    }
                }
                if (chkPrepop.Checked)
                {
                    txtNoticication.Text = defaultstr;
                }
                else
                {
                    txtNoticication.Text = "";
                }
                Session.Remove("PushNotifyType");
                lblLength.Text = (txtNoticication.MaxLength - txtNoticication.Text.Length).ToString();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "LoadSendNotifications", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnSchCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnSchNotifyID.Value != "")
                {
                    objMobile.CancelNotificationSchedule(Convert.ToInt32(hdnSchNotifyID.Value), CUserID);
                    lblSuccess.Text = "<font size='2' color='green'>Notification has been cancelled successfully.</font>";
                    ModalPopupExtender3.Hide();
                    LoadSendNotifications();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "btnSchCancel_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void NotificationGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataTable dtSendNotifications = (DataTable)Session["DtSendNotifications"];
                NotificationGrid.PageIndex = e.NewPageIndex;
                NotificationGrid.DataSource = dtSendNotifications;
                NotificationGrid.DataBind();
                BindDefaults();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "NotificationGrid_PageIndexChanging", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void NotificationGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                BindDefaults();
                int pushNotifyID = 0;
                pushNotifyID = Convert.ToInt32(e.CommandArgument);
                if (pushNotifyID > 0)
                {
                    if (e.CommandName.CompareTo("Delete") == 0)//Delete Process.
                    {
                        objMobile.AddPushNotifications(string.Empty, ProfileID, CUserID, 0, TotalSendCount, DeviceIds, pushNotifyID, PushType, pushNotifyID, 1, DateTime.Now, "PushNotification", string.Empty);

                        lblSuccess.Text = "<font size='2' color='green'>Notification has been deleted successfully.</font>";
                        LoadSendNotifications();

                    }
                    else if (e.CommandName.CompareTo("History") == 0)
                    {
                        hdnSchNotifyID.Value = pushNotifyID.ToString();
                        DataTable dtSendNotifications = (DataTable)Session["DtSendNotifications"];
                        string SelectQuery = "PushNotifyID=" + pushNotifyID;
                        DataRow[] drNotification;
                        drNotification = dtSendNotifications.Select(SelectQuery);
                        if (drNotification.Length > 0)
                        {
                            lblMessage.Text = drNotification[0]["Message"].ToString();
                            lblSendDate.Text = Convert.ToDateTime(drNotification[0]["Sending_Date"]).ToString("MM/dd/yyyy hh:mm tt");
                            ModalPopupExtender3.Show();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                lblSuccess.Text = "<font size='2' color='red'>" + ex.Message.ToString() + "</font>";

                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "NotificationGrid_RowCommand", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void NotificationGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void NotificationGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                BindDefaults();
                lblSuccess.Text = string.Empty;
                SortDir = Convert.ToInt32(hdnsortcount.Value);
                string sortExp = e.SortExpression.ToString();
                DataTable dtSendNotifications = (DataTable)Session["DtSendNotifications"];
                if (hdnsortdire.Value != "")
                {
                    if (hdnsortdire.Value != sortExp)
                    {
                        hdnsortdire.Value = sortExp;
                        SortDir = 0;
                        hdnsortcount.Value = "0";
                    }
                }
                else
                {
                    hdnsortdire.Value = sortExp;
                }
                DataView dv = new DataView(dtSendNotifications);
                if (SortDir == 0)
                {
                    if (sortExp == "CreatedDate")
                    {
                        dv.Sort = "Created_Date ASC";
                    }

                    hdnsortcount.Value = "1";
                }
                else
                {
                    if (sortExp == "CreatedDate")
                    {
                        dv.Sort = "Created_Date desc";
                    }

                    hdnsortcount.Value = "0";
                }
                Session["DtSendNotifications"] = dv.ToTable();
                NotificationGrid.DataSource = dv;
                NotificationGrid.DataBind();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "NotificationGrid_Sorting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void NotificationGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblImage = e.Row.FindControl("lblImage") as Label;
                    string imgsrc = "";

                    if (lblImage.Text == "(P)(T)")
                    {
                        imgsrc = "<img src='" + RootPath + "/Images/PushNotification_15x15.png' />  <img src='" + RootPath + "/Images/TextSMS_15x15.png' />";
                        lblImage.Text = imgsrc;
                    }
                    else if (lblImage.Text == "(P)")
                    {
                        imgsrc = "<img src='" + RootPath + "/Images/PushNotification_15x15.png' />";
                        lblImage.Text = imgsrc;
                    }
                    else if (lblImage.Text == "(T)")
                    {
                        imgsrc = "<img src='" + RootPath + "/Images/TextSMS_15x15.png' />";
                        lblImage.Text = imgsrc;
                    }
                    else
                    {
                        lblImage.Text = "";
                    }

                    LinkButton btnDelete = e.Row.FindControl("btnDelete") as LinkButton;
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        if (!string.IsNullOrEmpty(hdnPermissionType.Value))
                            btnDelete.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "NotificationGrid_RowDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void rbNotificationCheckedChanged(object sender, EventArgs e)
        {
            BindDefaults();
            RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            Label lnkCommand = (Label)row.FindControl("lblCommand");
            Label lnkTitle = (Label)row.FindControl("lblTitle");
            hdnCommandArg.Value = lnkCommand.Text;
            GetSharestrings(Convert.ToInt32(hdnCommandArg.Value), lnkTitle.Text);


        }
        private void GetSharestrings(int pushNotifyID, string description)
        {
            try
            {
                GetAutoShareRecordStatus(pushNotifyID, "Push Notification");
                DataTable dtPush = objBus.GetSendNotificationByID(pushNotifyID);
                string rootPath = Session["RootPath"].ToString();
                string redirecturl = "";
                int sentFlag = Convert.ToInt32(dtPush.Rows[0]["Sent_Flag"]);
                if (sentFlag == 1)
                {
                    if (dtPush.Rows[0]["IsPrivateButton"] != null)
                    {
                        pnlShareSocial.Visible = Convert.ToBoolean(dtPush.Rows[0]["IsPrivateButton"].ToString()) ? false : true;
                    }
                    if (dtPush.Rows[0]["Type"] != null && dtPush.Rows[0]["Type"].ToString() != "" && Convert.ToString(dtPush.Rows[0]["Type"]) != "General")
                    {
                        if (Convert.ToString(dtPush.Rows[0]["Type"]) == "Update")
                            redirecturl = rootPath + "/OnlineUpdate.aspx?BID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(dtPush.Rows[0]["Type_ID"])).Replace("=", "irhmalli").Replace("+", "irhPASS");
                        else if (Convert.ToString(dtPush.Rows[0]["Type"]) == "Bulletin")
                            redirecturl = rootPath + "/OnlineBulletin.aspx?BLID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(dtPush.Rows[0]["Type_ID"])).Replace("=", "irhmalli").Replace("+", "irhPASS");
                        else if (Convert.ToString(dtPush.Rows[0]["Type"]) == "Event")
                            redirecturl = rootPath + "/printevents.aspx?EID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(dtPush.Rows[0]["Type_ID"])).Replace("=", "irhmalli").Replace("+", "irhPASS");
                        else if (Convert.ToString(dtPush.Rows[0]["Type"]) == "CustomModule")
                            redirecturl = rootPath + "/OnlineItem.aspx?CMID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(dtPush.Rows[0]["Type_ID"])).Replace("=", "irhmalli").Replace("+", "irhPASS");
                    }
                    else
                    {
                        redirecturl = "";
                    }
                    if (redirecturl != "")
                        redirecturl = objCommon.longurlToshorturl(redirecturl);
                    hdnRedirectUrl.Value = redirecturl;
                    //Facebook
                    string tweetDesc = description.Replace("#", "");
                    if ((description.Length + redirecturl.Length) > 137)
                    {
                        tweetDesc = description.Substring(0, 140 - (redirecturl.Length + 3)).Replace("#", "");
                    }
                    //Facebook            
                    hdnLinkShareFB.Value = "";
                    hdnLinkShareFB.Value = redirecturl;
                    hdnMessageDes.Value = "";
                    hdnMessageDes.Value = description;

                    //lblFacebookSharePage.Text = "<a href='javascript:post_on_page()'><img src='../../images/Dashboard/facebook.png' alt='Share on Facebook Page'  title='Share on Facebook Page' border='0' /></a>";
                    //Facebook

                    //Twitter 
                    string Twitterurlinfo1 = "https://www.twitter.com/intent/tweet?url=" + redirecturl + "&text=" + tweetDesc;
                    //string Twitterurlinfo1 = "http://twitter.com/home?status=" + articleTitle + " - " + articleUrl;
                    //Twitterurlinfo = "<a href='" + Twitterurlinfo1 + "' title='Click to share this post on Twitter' target='_blank'><img src='../../images/Dashboard/twitter.png' alt='Share on Twitter' title='Share on Twitter' border='0'/></a>";
                    Twitterurlinfo = "<a href='javascript:void(0);' onclick='TwitterShare(\"" + Twitterurlinfo1 + "\");' title='Click to share this post on Twitter'><img src='../../images/Dashboard/twitter.png' alt='Share on Twitter' title='Share on Twitter' border='0'/></a>";
                    //lblTwitterShare.Text = Twitterurlinfo;
                    //Twitter
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "GetSharestrings", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetAutoShareRecordStatus(int pushId, string pushTitle)
        {
            try
            {
                DataTable dtShareRecords = objCommon.CheckAutoShareRecordExists("PushNotification", pushId, pushTitle);
                for (int i = 0; i < dtShareRecords.Rows.Count; i++)
                {
                    if (Convert.ToString(dtShareRecords.Rows[i]["Media_TYPE"]) == "Facebook")
                        hdnFacebook.Value = "false";

                    if (Convert.ToString(dtShareRecords.Rows[i]["Media_TYPE"]) == "Twitter")
                        hdnTwitter.Value = "false";
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "GetAutoShareRecordStatus", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void AutoShareOnSocialMedia(DateTime dtSendDate, int pushnotifyID,string ContentTitle)
        {
            try
            {
                /****** Auto Share ******/
                if (chkFbAutoPost.Checked)
                    objCommon.InsertUpdateAutoShareDetails("PushNotification", pushnotifyID, 0, dtSendDate, "Facebook", UserID, CUserID, ContentTitle);
                if (chkTwrAutoPost.Checked)
                    objCommon.InsertUpdateAutoShareDetails("PushNotification", pushnotifyID, 0, dtSendDate, "Twitter", UserID, CUserID, ContentTitle);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "AutoShareOnSocialMedia", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkShareBtn_Click(object sender, EventArgs e)
        {
            try
            {
                EventCalendarBLL adminobj = new EventCalendarBLL();
                Session["ContentID"] = hdnCommandArg.Value;
                DataTable dtPush = objBus.GetSendNotificationByID(Convert.ToInt32(hdnCommandArg.Value));
                if (Convert.ToInt32(dtPush.Rows[0]["Sent_Flag"].ToString()) == 1)
                {
                    string description = hdnMessageDes.Value;
                    string redirecturl = hdnRedirectUrl.Value;
                    string tweetDesc = description.Replace("#", "");
                    if ((description.Length + redirecturl.Length) > 137)
                    {
                        tweetDesc = description.Substring(0, 140 - (redirecturl.Length + 3)).Replace("#", "");
                    }

                    DataTable dtExistingFbUsersData = smb.GetExistingUserData(ProfileID);
                    if (dtExistingFbUsersData.Rows.Count > 0)
                    {
                        //smb.FacebookAutoShare(ProfileID, tweetDesc, "", redirecturl);
                        objCommon.InsertUpdateAutoShareDetails("PushNotification", Convert.ToInt32(hdnCommandArg.Value), 0, DateTime.Now, "Facebook", UserID, CUserID, tweetDesc);
                        lblSuccess.Text = "<font color='green' size='2'>Your selected item has been posted on facebook successfully.</font>";
                    }
                    else
                    {
                        Dictionary<string, object> args = new Dictionary<string, object>();
                        args["message"] = tweetDesc;
                        args["name"] = "Push Notification";
                        args["link"] = redirecturl;
                        Session["PageContent"] = args;
                        //GetSharestrings(Convert.ToInt32(hdnCommandArg.Value), articleTitle);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "post_on_page();", true);
                        //if (Request["code"] == null)
                        Response.Redirect("https://graph.facebook.com/oauth/authorize?client_id=" + appID + "&redirect_uri=" + RootPath + "/Business/MyAccount/SendAppNotifications.aspx" + "&scope=" + fbScope);
                        //else
                        //    ShareOnFacebook();
                    }
                }
                else
                {
                    string stsMessage = string.Empty;
                    if (Convert.ToInt32(dtPush.Rows[0]["Sent_Flag"].ToString()) == 0)
                        stsMessage = "You cannot post scheduled content.";
                    else
                        stsMessage = "You cannot post cancelled content.";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "ShowNotShareMessage('" + stsMessage + "');", true);
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "lnkShareBtn_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetFacebookAppDetails()
        {
            try
            {
                if (DomainName.ToLower().Contains("uspdhub"))
                {
                    appID = ConfigurationManager.AppSettings.Get("FacebookUSPDAppID");
                    appSecret = ConfigurationManager.AppSettings.Get("FacebookUSPDAppSecret");
                }
                else if (DomainName.ToLower().Contains("twovie"))
                {
                    appID = ConfigurationManager.AppSettings.Get("FacebookTwovieAppID");
                    appSecret = ConfigurationManager.AppSettings.Get("FacebookTwovieAppSecret");
                }
                else if (DomainName.ToLower().Contains("myyouthhub"))
                {
                    appID = ConfigurationManager.AppSettings.Get("FacebookMYHAppID");
                    appSecret = ConfigurationManager.AppSettings.Get("FacebookMYHAppSecret");
                }
                else if (DomainName.ToLower().Contains("inschoolhub"))
                {
                    appID = ConfigurationManager.AppSettings.Get("FacebookISHAppID");
                    appSecret = ConfigurationManager.AppSettings.Get("FacebookISHAppSecret");
                }
                else
                {
                    appID = ConfigurationManager.AppSettings.Get("FacebookAppID");    //Facebook App ID and Secret
                    appSecret = ConfigurationManager.AppSettings.Get("FacebookAppSecret");
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "GetFacebookAppDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void ShareOnFacebook()
        {
            int pageCount = 0;
            Dictionary<string, string> tokens = new Dictionary<string, string>();
            try
            {
                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}", appID, RootPath + "/Business/MyAccount/SendAppNotifications.aspx", fbScope, Request["code"].ToString(), appSecret);
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string vals = reader.ReadToEnd();
                    tokens = JsonConvert.DeserializeObject<Dictionary<string, string>>(vals);
                    //foreach (string token in vals.Split('&'))
                    //    tokens.Add(token.Substring(0, token.IndexOf("=")), token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                }
                string access_token = tokens["access_token"];
                var client = new FacebookClient(access_token);
                dynamic userDetails = client.Get("/me");
                var FBID = userDetails.id;

                //Get List Of Facebook Pages
                Dictionary<string, string> fbPages = new Dictionary<string, string>();
                dynamic listOfPages = client.Get("/me/accounts");
                foreach (var page in listOfPages.data)
                {
                    fbPages.Add(page.id, page.name);
                    pageCount++;
                }
                if (pageCount == 0)
                {
                    lblSuccess.Text = "<font color='red' size='2'>There are no pages in your account.</font>";
                }
                else
                {
                    Session["DataCollections"] = listOfPages;
                    ddlFbPagesList.DataSource = fbPages;
                    ddlFbPagesList.DataValueField = "Key";
                    ddlFbPagesList.DataTextField = "Value";
                    ddlFbPagesList.DataBind();
                    mpeFbPages.Show();
                }
            }
            catch (Exception /*ex*/)
            {
                Response.Redirect(RootPath + "/Business/MyAccount/SendAppNotifications.aspx");
            }
        }
        protected void btnShareOnPage_Click(object sender, EventArgs e)
        {
            ShareOnPage();
        }
        private void ShareOnPage()
        {
            try
            {
                mpeFbPages.Show();
                string selectedPage = ddlFbPagesList.SelectedValue.ToString();
                string accessToken = string.Empty;
                dynamic pagesFb = (dynamic)Session["DataCollections"];
                foreach (var page in pagesFb.data)
                {
                    if (page.id == selectedPage)
                    {
                        accessToken = page.access_token;
                        break;
                    }
                }
                var result = smb.GetExtendedAccessToken(accessToken, appID, appSecret);
                var extendedToken = result.access_token;    // Get Long Lived Access Token.
                var fb = new FacebookClient();
                fb.AccessToken = extendedToken;
                var postID = "";
                var args = (Dictionary<string, object>)Session["PageContent"];
                if (selectedPage != "")
                    postID = fb.Post("/" + selectedPage + "/feed", args).ToString();
                if (postID != "")
                {
                    mpeFbPages.Hide();
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SendAppNotifications.aspx?fbStatus=1"));
                }
                else
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SendAppNotifications.aspx?fbStatus=0"));
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "ShareOnPage", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkTwrShare_Click(object sender, EventArgs e)
        {
            try
            {
                EventCalendarBLL adminobj = new EventCalendarBLL();
                Session["ContentID"] = hdnCommandArg.Value;
                DataTable dtPush = objBus.GetSendNotificationByID(Convert.ToInt32(hdnCommandArg.Value));
                if (Convert.ToInt32(dtPush.Rows[0]["Sent_Flag"].ToString()) == 1)
                {
                    string description = hdnMessageDes.Value;
                    string redirecturl = hdnRedirectUrl.Value;
                    string tweetDesc = description.Replace("#", "");
                    if ((description.Length + redirecturl.Length) > 137)
                    {
                        tweetDesc = description.Substring(0, 140 - (redirecturl.Length + 3)).Replace("#", "");
                    }

                    DataTable dtTwitterUser = smb.GetTwitterDataByUserID(ProfileID);
                    if (dtTwitterUser.Rows.Count > 0)
                    {
                        objCommon.InsertUpdateAutoShareDetails("PushNotification", Convert.ToInt32(hdnCommandArg.Value), 0, DateTime.Now, "Twitter", UserID, CUserID, tweetDesc);
                        lblSuccess.Text = "<font color='green' size='2'>Your selected item has been posted on twitter successfully.</font>";
                    }
                    else
                    {
                        string url = "http://www.twitter.com/share?url=" + redirecturl + "&text=" + tweetDesc;
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + url + "', '_blank');", true);
                        objCommon.InsertUpdateAutoShareDetails("PushNotification", Convert.ToInt32(Session["ContentID"]), 1, DateTime.Now, "Twitter", UserID, CUserID, tweetDesc);
                        objCommon.UpdateSocialShareStatus(UserID, 1, "Twitter", Convert.ToInt32(Session["ContentID"]), 1);//updating status flag for report
                    }
                }
                else
                {
                    string stsMessage = string.Empty;
                    if (Convert.ToInt32(dtPush.Rows[0]["Sent_Flag"].ToString()) == 0)
                        stsMessage = "You cannot post scheduled content.";
                    else
                        stsMessage = "You cannot post cancelled content.";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "ShowNotShareMessage('" + stsMessage + "');", true);
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "lnkTwrShare_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        //Send SMS Notification
        protected void chkSMS_CheckedChanged(object sender, EventArgs e)
        {
            BindSMSGroups();
        }

        private void BindSMSGroups()
        {
            // Display Total SMS, Sent SMS, Remaing SMS
            SMSSentCount();

            try
            {

                pnlSMSGroups.Visible = chkSMS.Checked ? true : false;
                DataTable dtGroups = new DataTable();
                if (chkSMS.Checked)
                {
                    dtGroups = objSMS.GetGroupsByUserID(UserID, IsPrivateModule);
                    if (dtGroups.Rows.Count > 0)
                    {
                        string filterQuery = string.Empty;
                        filterQuery = "contact_group_id='0'";
                        DataRow[] dRRemove = dtGroups.Select(filterQuery);
                        // remvoe Opt-out group from table
                        if (dRRemove != null)
                        {
                            if (dRRemove.Length > 0)
                            {
                                for (int i = 0; i < dRRemove.Length; i++)
                                {
                                    dtGroups.Rows.Remove(dRRemove[i]);
                                }
                            }
                        }
                    }
                }

                chkGroupList.DataSource = dtGroups;
                chkGroupList.DataTextField = "Contact_Group_Name_Count";
                chkGroupList.DataValueField = "Contact_Group_ID";
                chkGroupList.DataBind();
                if (dtGroups.Rows.Count > 0 && chkSMS.Checked)
                {
                    string result = String.Join(Environment.NewLine, dtGroups.AsEnumerable().Select(row => row.Field<int>("Contact_Group_ID")));
                    lblSMSOptinCount.Text = Convert.ToString(dtGroups.Rows[0]["Contact_Group_Name_Count"]) + " - View";
                    BindContactsByContactGroupID(result);
                }

                //Displaying Sent SMS Count Label           
                tdlblmsg.Visible = false;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "BindSMSGroups()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

            }
        }

        /// <summary>
        /// Display Total SMS, Sent SMS, Remaing SMS
        /// </summary>
        private void SMSSentCount()
        {
            try
            {
                DataTable dtSMSCount = new DataTable();
                dtSMSCount = objSMS.GetAllSMSCount(ProfileID);
                foreach (DataRow row in dtSMSCount.Rows)
                {
                    lblSMSCount.Text = Convert.ToString(row["SMS_Sent_Count"]);
                    lblScheduleCount.Text = Convert.ToString(row["SMS_Scheduled_Sent_Count"]);
                    string temp = Convert.ToString(row["Remaining_SMS_Count"]);
                    if (Convert.ToInt32(temp) <= 0)
                    {
                        int i = 0;
                        lblRemainingCount.Text = i.ToString();
                    }
                    else
                    {
                        lblRemainingCount.Text = Convert.ToString(row["Remaining_SMS_Count"]);
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "SMSSentCount()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void chkGroups_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                String ContactGroupIDs = "";
                if (chkGroups.Checked == true)
                {
                    for (int i = 0; i < chkGroupList.Items.Count; i++)
                    {
                        chkGroupList.Items[i].Selected = true;
                        if (chkGroupList.Items[i].Selected)
                        {
                            if (ContactGroupIDs == "")
                            {
                                ContactGroupIDs = chkGroupList.Items[i].Value;
                            }
                            else
                            {
                                ContactGroupIDs += "," + chkGroupList.Items[i].Value;
                            }
                        }
                    }
                    BindContactsByContactGroupID(ContactGroupIDs);
                    chckcount();

                }
                else
                {
                    for (int i = 0; i < chkGroupList.Items.Count; i++)
                    {
                        chkGroupList.Items[i].Selected = false;
                        GVContacts.Visible = false;
                        tdlblmsg.Visible = false;
                        lnkSend.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "chkGroups_CheckedChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        protected void chkGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String ContactGroupIDs = "";
                for (int i = 0; i <= chkGroupList.Items.Count - 1; i++)
                {
                    if (chkGroupList.Items[i].Selected)
                    {
                        if (ContactGroupIDs == "")
                        {
                            ContactGroupIDs = chkGroupList.Items[i].Value;
                        }
                        else
                        {
                            ContactGroupIDs += "," + chkGroupList.Items[i].Value;
                        }
                    }
                }
                BindContactsByContactGroupID(ContactGroupIDs);
                chckcount();
                if (chkGroups.Checked == true)
                    chkGroups.Checked = false;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "chkGroupList_SelectedIndexChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BindContactsByContactGroupID(string ContactGroupIDs)
        {
            try
            {
                DataTable dtContacts = new DataTable();
                dtContacts = objSMS.GetContactsByContactGroupID(ContactGroupIDs, UserID, true);
                GVContacts.DataSource = dtContacts;
                GVContacts.DataBind();
                GVContacts.Visible = true;
                contactsCount = dtContacts.Rows.Count;

                if (dtContacts.Rows.Count <= Convert.ToInt32(lblRemainingCount.Text))
                {
                    if (GVContacts.Rows.Count > 0)
                    {
                        CheckBox chkBxHeader = (CheckBox)this.GVContacts.HeaderRow.FindControl("chkSelectAll");
                        chkBxHeader.Checked = true;
                    }
                    Session["DtContacts"] = dtContacts;
                }
                else
                {
                    lblSMSExceed.Text = Resources.LabelMessages.SMSAvailableExceeded.Replace("#SelectedContacts#", dtContacts.Rows.Count.ToString()).Replace("#AvailableSMSCredits#", lblRemainingCount.Text);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "BindContactsByContactGroupID", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void GVContacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataTable dtContacts = (DataTable)Session["DtContacts"];
                GVContacts.PageIndex = e.NewPageIndex;
                GVContacts.DataSource = dtContacts;
                GVContacts.DataBind();

                modalContacts.Show();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "GVContacts_PageIndexChanging", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        protected void chckcount()
        {
            try
            {
                int selectedCount = 0;
                foreach (GridViewRow row in GVContacts.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("cbSelect") as CheckBox);
                        if (chkRow != null)
                        {
                            if (chkRow.Checked)
                                selectedCount += 1;
                        }
                    }
                }
                if (selectedCount > Convert.ToInt32(lblRemainingCount.Text))
                {
                    tdlblmsg.Visible = true;
                    lnkSend.Visible = false;
                }
                else
                {
                    tdlblmsg.Visible = false;
                    lnkSend.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "chckcount", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        protected void lnkBuyMore_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["ShoppingCartRootPath"] + "/RedirectPage.aspx?MID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&MPID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString()) + "&CID=" + EncryptDecrypt.DESEncrypt(CUserID.ToString()) + "&VC=" + EncryptDecrypt.DESEncrypt(DomainName) + "&ReqType=4&RType=4");
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // gridview select all check box
                CheckBox chkBxHeader = (CheckBox)this.GVContacts.HeaderRow.FindControl("chkSelectAll");
                bool checkAllFlag = false;
                if (chkBxHeader.Checked)
                    checkAllFlag = true;
                foreach (GridViewRow row in GVContacts.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("cbSelect") as CheckBox);
                        chkRow.Checked = checkAllFlag;
                    }
                }
                chckcount();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotifications.aspx.cs", "chkSelectAll_CheckedChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked == false)
            {
                CheckBox chkBxHeader = (CheckBox)this.GVContacts.HeaderRow.FindControl("chkSelectAll");
                chkBxHeader.Checked = false;
            }
            chckcount();
        }


        protected void lnkViewContacts_OnClick(object sender, EventArgs e)
        {
            modalContacts.Show();
        }

        protected void GetPrepoulateSettings()
        {
            try
            {
                string settingsXML = "";
                DataTable dtprepopulate = new DataTable();
                dtprepopulate = objBus.GetPrepoulatesettings(ProfileID, "PushNotification");
                if (dtprepopulate.Rows.Count > 0)
                {
                    settingsXML = Convert.ToString(dtprepopulate.Rows[0]["XMLValue"]);
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(settingsXML);

                    if (settingsXML != string.Empty)
                    {
                        if (xmldoc.SelectSingleNode("PushNotification/@IsAppNameChecked") != null)
                        {
                            chkPrepop.Checked = Convert.ToBoolean(xmldoc.SelectSingleNode("PushNotification/@IsAppNameChecked").Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendAppNotification.aspx.cs", "GetPrepoulateSettings", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void chkPrepop_CheckedChanged(object sender, EventArgs e)
        {
            string xmlValue = "<PushNotification IsAppNameChecked='" + chkPrepop.Checked + "'  />";

            DataTable dtprepopulate = new DataTable();
            dtprepopulate = objBus.GetPrepoulatesettings(ProfileID, "PushNotification");
            if (dtprepopulate.Rows.Count > 0)
                objBus.UserCustomizeSettings(Convert.ToInt32(dtprepopulate.Rows[0]["CustomizeSettingsID"].ToString()), ProfileID, UserID, "PushNotification", xmlValue);
            else
                objBus.UserCustomizeSettings(0, ProfileID, UserID, "PushNotification", xmlValue);
            
            LoadSendNotifications();
        }
    }
}

