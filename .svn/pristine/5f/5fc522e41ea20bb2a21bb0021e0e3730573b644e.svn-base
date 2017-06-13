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
using System.Text.RegularExpressions;
using System.Web;

namespace USPDHUB.Business.MyAccount
{
    public partial class CAEventsCalendar : BaseWeb
    {
        public int CalendarId = 0;
        public int CalendarAddOnId = 0;
        public int UserID = 0;
        public int ProfileId = 0;
        public int MaxEventId = 0;
        public string EventDesc = string.Empty;
        public int BusinessEventUsageCount = 0;
        public int CUserID = 0;
        public int AppStatus = 0;

        DataTable Dtpermissions = new DataTable();

        public string RootPath = "";
        public string DomainName = "";
        public string titleName = "";
        public bool isCall = true;
        public bool isContatUs = true;

        CalendarAddOnBLL objCalendarAddOn = new CalendarAddOnBLL();
        CommonBLL objCommon = new CommonBLL();
        USPDHUBBLL.MobileAppSettings objApp = new USPDHUBBLL.MobileAppSettings();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        AgencyBLL agencyobj = new AgencyBLL();
        AddOnBLL objAddOn = new AddOnBLL();
        BusinessBLL objBus = new BusinessBLL();
        EventCalendarBLL objEventCalendar = new EventCalendarBLL();
        public bool IsScheduleEmails = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                if (Session["CalendarAddOnID"] != null)
                    CalendarAddOnId = Convert.ToInt32(Session["CalendarAddOnID"].ToString());
                else
                    Response.Redirect(RootPath + "/Business/MyAccount/Default.aspx");

                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileId = Convert.ToInt32(Session["ProfileID"].ToString());
                CUserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                if (Request.QueryString["CalId"] != null)
                {
                    if (Request.QueryString["CalId"].ToString() != "")
                    {
                        CalendarId = Convert.ToInt32(Request.QueryString["CalId"]);
                    }
                    else
                        CalendarId = 0;
                }
                else
                {
                    btnSaveExit.ValidationGroup = "group";
                    CalendarId = 0;
                }
                // *** Make back button visible and disable by query string 26-03-2013 *** //
                if (!string.IsNullOrEmpty(Request.QueryString["App"]))
                    AppStatus = 1;

                /*** Store Module Functionality ***/
                if (objBus.CheckModulePermission(WebConstants.Purchase_ScheduleEmailsSetup, ProfileId))
                {
                    IsScheduleEmails = true;
                }
                if (!IsPostBack)
                {
                    DataTable dtAddOn = objAddOn.GetAddOnById(CalendarAddOnId);
                    if (dtAddOn.Rows.Count == 1)
                    {
                        lblTitle.Text = dtAddOn.Rows[0]["TabName"].ToString();
                    }
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

                    //**** Showing Bulletins and Updates in Events View ****//
                    if (Request.QueryString["Name"] != null)
                    {
                        txtEventName.Text = Request.QueryString["Name"];
                    }
                    if (Request.QueryString["URL"] != null)
                    {
                        string populateHtml = "<table width='400' id='maintable' style='border: 0px solid gray; border-image: none; min-height: 100px;'";
                        populateHtml = populateHtml + "cellspacing='2' cellpadding='2'> <tbody><tr id='tr1'><td><div class='textdivStyle' id='edit1'";
                        populateHtml = populateHtml + "style='padding: 5px; min-height: 100px;'><span style='color: black; font-family: Arial; font-size: 12px; font-style: normal; font-weight: normal; text-decoration: none;'>";
                        populateHtml = populateHtml + Request.QueryString["URL"];
                        populateHtml = populateHtml + "</span></div></td><td><img style='cursor: pointer;' onclick='ShowPopup(edit1)' src='../../Images/EditText.png'><br><img style='padding-top: 5px; cursor: pointer;' onclick='RemoveBlock(edit1)' src='../../Images/Remove.png'></td></tr></tbody></table>";
                        lblEditText.Text = populateHtml;
                    }
                    //******************************************************//
                    string tempNewsletterPath = Server.MapPath("~") + "\\Upload\\Common\\" + ProfileId.ToString();
                    if (Directory.Exists(tempNewsletterPath) == false)
                        Directory.CreateDirectory(tempNewsletterPath);
                    if (CalendarId > 0)
                    {
                        DataTable dtobj = new DataTable();
                        dtobj = objCalendarAddOn.GetCalendarAddOnDetails(CalendarId);
                        if (dtobj != null)
                        {
                            if (dtobj.Rows.Count > 0)
                            {
                                hdnChangeStartDate.Value = "1";
                                PopulateCalendarEventDetails(dtobj);
                            }
                            else
                                lblerror.Text = "<font color=red face=arial size=2> There are no User details available right now.</font>";
                        }
                        else
                            lblerror.Text = "<font color=red face=arial size=2> There are no User details right now.</font>";
                    }
                    else
                    {
                        rbPrivate.Checked = true;
                        rbPublic.Checked = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript", "javascript: ShowPublish(1,0);", true);
                    }
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), CalendarAddOnId, "CalendarAddon");
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            UpdatePanel1.Visible = true;
                            UpdatePanel2.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to create or edit app content.</font>";
                        }
                        else if (hdnPermissionType.Value == "A")
                        {
                            hdnPublishTitle.Value = Resources.LabelMessages.AuthorPublishTitle;
                        }
                    }
                    //ends roles & permissions..
                    GetAutoShareRecordStatus();

                    DataTable dtProfileAddress = new DataTable();
                    dtProfileAddress = objBus.GetProfileDetailsByProfileID(ProfileId);
                    if (dtProfileAddress.Rows.Count > 0 && Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]) != "")
                    {
                        hdnUserFont.Value = Convert.ToString(dtProfileAddress.Rows[0]["FontFamily"]);
                    }
                }
                hdnURLPath.Value = RootPath;
                lblPublish.Text = hdnPublishTitle.Value;
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CAEventsCalendar.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetAutoShareRecordStatus()
        {
            try
            {
                if (CalendarId > 0)
                {
                    string eventTitle = string.Empty;
                    DataTable dtobj = new DataTable();
                    dtobj = objCalendarAddOn.GetCalendarAddOnDetails(CalendarId);
                    if (dtobj.Rows.Count > 0)
                        eventTitle = dtobj.Rows[0]["EventTitle"].ToString();
                    DataTable dtShareRecords = objCommon.CheckAutoShareRecordExists(WebConstants.Tab_CalendarAddOns, CalendarId, eventTitle);
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
                    DataTable dtExistingFbUsersData = smb.GetExistingUserData(ProfileId);
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
                    DataTable dtExistingTwrUserData = smb.GetTwitterDataByUserID(ProfileId);
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
                objInBuiltData.ErrorHandling("ERROR", "CAEventsCalendar.aspx.cs", "GetAutoShareRecordStatus", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void PopulateCalendarEventDetails(DataTable dtobj)
        {
            try
            {
                MaxEventId = Convert.ToInt32(dtobj.Rows[0]["CalendarId"]);
                txtEventName.Text = dtobj.Rows[0]["EventTitle"].ToString();
                lblEditText.Text = dtobj.Rows[0]["Edit_HTML"].ToString();

                hdnEventID.Value = MaxEventId.ToString();
                txtStartDate.Text = Convert.ToDateTime(dtobj.Rows[0]["EventStartDate"].ToString()).ToShortDateString();
                txtStrHours.Text = Convert.ToDateTime(dtobj.Rows[0]["EventStartDate"].ToString()).ToString("hh");
                txtStrMins.Text = Convert.ToDateTime(dtobj.Rows[0]["EventStartDate"].ToString()).ToString("mm");
                ddlStrAPM.SelectedValue = Convert.ToDateTime(dtobj.Rows[0]["EventStartDate"].ToString()).ToString("tt");
                txtStrHours.Enabled = true;
                txtStrMins.Enabled = true;
                ddlStrAPM.Enabled = true;

                txtEndDate.Text = Convert.ToDateTime(dtobj.Rows[0]["EventEndDate"].ToString()).ToShortDateString();
                txtEndHours.Text = Convert.ToDateTime(dtobj.Rows[0]["EventEndDate"].ToString()).ToString("hh");
                txtEndMins.Text = Convert.ToDateTime(dtobj.Rows[0]["EventEndDate"].ToString()).ToString("mm");
                ddlEndAPM.SelectedValue = Convert.ToDateTime(dtobj.Rows[0]["EventEndDate"].ToString()).ToString("tt");
                txtEndHours.Enabled = true;
                txtEndMins.Enabled = true;
                ddlEndAPM.Enabled = true;
                hdnEventDates.Value = String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(dtobj.Rows[0]["EventStartDate"].ToString())) + "##SP##" + String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(dtobj.Rows[0]["EventEndDate"].ToString()));
                DateTime dtNow = objCommon.ConvertToUserTimeZone(ProfileId);
                if (!string.IsNullOrEmpty(dtobj.Rows[0]["Publish_Date"].ToString()))
                {
                    DateTime dtPublish = Convert.ToDateTime(dtobj.Rows[0]["Publish_Date"]);
                    if (DateTime.Compare(dtPublish, dtNow) < 0)
                        txtPublishDate.Text = dtNow.ToShortDateString();
                    else
                        txtPublishDate.Text = dtPublish.ToShortDateString();
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
                if (Convert.ToBoolean(dtobj.Rows[0]["ShowRepeat"].ToString()))
                {
                    if (Convert.ToBoolean(dtobj.Rows[0]["IsRepeat"].ToString()))
                    {
                        int parentID = CalendarId;
                        if (Convert.ToString(dtobj.Rows[0]["ParentCalendarID"]) != "")
                            parentID = Convert.ToInt32(dtobj.Rows[0]["ParentCalendarID"]);
                        DataTable dtRepeat = objEventCalendar.GetRepeatEventByEventID(parentID, WebConstants.Tab_CalendarAddOns);
                        if (dtRepeat.Rows.Count > 0)
                        {
                            chkRepeat.Checked = true;
                            hdnAlreadyRepeat.Value = "1";
                            string str3Items = Convert.ToString(dtRepeat.Rows[0]["Repeats"]) + "##SP##" + Convert.ToString(dtRepeat.Rows[0]["RepeatsEvery"]) + "##SP##" + Convert.ToDateTime(dtRepeat.Rows[0]["StartsOn"]).ToShortDateString();
                            hdn3Itemsold.Value = str3Items;
                            string strEndsOn = Convert.ToString(dtRepeat.Rows[0]["EndsType"]) + "##SP##" + Convert.ToString(dtRepeat.Rows[0]["EndsAt"]);
                            hdnEndOnold.Value = strEndsOn;
                            hdnRepeatByold.Value = Convert.ToString(dtRepeat.Rows[0]["RepeatBy"]);
                            hdnRepeatOnold.Value = Convert.ToString(dtRepeat.Rows[0]["ReapeatsOn"]);
                        }
                    }
                }
                else
                    pnlRepeatShow.Visible = false;
                rbPrivate.Checked = true;
                if (txtPublishDate.Text != "")
                {
                    rbPublic.Checked = true;
                    hdnIsAlreadyPublished.Value = "1";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript", "javascript: ShowPublish(2,1);", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "javascript", "javascript: ShowPublish(1,1);", true);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CAEventsCalendar.aspx.cs", "PopulateCalendarEventDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(GetUrl(WebConstants.ManageUrl_CalendarAddOns));
        }
        private string GetUrl(string file)
        {
            string url = Page.ResolveClientUrl("~/Business/MyAccount/" + file);
            try
            {
                if (AppStatus == 1)
                    url = Page.ResolveClientUrl("~/Business/MyAccount/" + file + "?App=1");
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CAEventsCalendar.aspx.cs", "GetUrl", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return url;
        }
        private string UserProfileUnsubscribeLink()
        {
            string totalAddress = string.Empty;
            string unSubscribeLinkText = string.Empty;
            string profileName = string.Empty;
            try
            {
                DataTable dtProfileAddress = new DataTable();
                dtProfileAddress = objBus.GetProfileDetailsByProfileID(ProfileId);
             
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
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CAEventsCalendar.aspx.cs", "UserProfileUnsubscribeLink", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            unSubscribeLinkText = "This message was sent " + profileName + " to &#60;recipient's email address&#62;. It was sent from &#60;sender's email address&#62;" + totalAddress + ". If you no longer wish to receive our updates, <a href='" + RootPath + "/UnsubscribeCalendar.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "' target='_blank'>click here</a> to unsubscribe.";
            return unSubscribeLinkText;
        }
        protected void imclose_Click(object sender, ImageClickEventArgs e)
        {
            string redirecturl = string.Empty;
            try
            {
                if (Request.QueryString["CalId"] != null)
                {
                    redirecturl = Page.ResolveClientUrl("~/Business/MyAccount/CAEventsCalendar.aspx?CalId=" + Request.QueryString["CalId"]);
                }
                else
                {
                    redirecturl = Page.ResolveClientUrl("~/Business/MyAccount/CAEventsCalendar.aspx");
                }
                Response.Redirect(redirecturl);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CAEventsCalendar.aspx.cs", "imclose_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnSaveExit_Click(object sender, EventArgs e)
        {
            try
            {
                #region Date and time
                /***************************Start Date Time*************************************/
                string strDate = txtStartDate.Text.Trim();
                string strHour = string.Empty;
                string strMins = string.Empty;
                string strDayHalfs = string.Empty;
                string strDateTime = string.Empty;
                strHour = "12";
                strMins = "00";
                int sdCount = 2;
                if (txtStrHours.Text.Trim() != "" && txtStrHours.Text.Trim() != "Hour")
                {
                    sdCount = sdCount - 1;
                    strHour = txtStrHours.Text.Trim();
                }
                if (txtStrMins.Text.Trim() != "" && txtStrMins.Text.Trim() != "Minutes")
                {
                    sdCount = sdCount - 1;
                    strMins = txtStrMins.Text.Trim();
                }

                strDayHalfs = ddlStrAPM.SelectedItem.Text.ToString();
                if (strHour == "12" && strMins == "00" && sdCount == 2)
                    strDayHalfs = "AM";
                strDateTime = strDate + " " + strHour + ":" + strMins + " " + strDayHalfs;
                /*******************************************************************************/

                /***************************End Date Time***************************************/
                string endDate = txtEndDate.Text.Trim();
                string endHour = string.Empty;
                string endMins = string.Empty;
                string endDayHalfs = string.Empty;
                string endDateTime = string.Empty;
                endHour = "12";
                endMins = "00";
                int edCount = 2;
                if (txtEndHours.Text.Trim() != "" && txtEndHours.Text.Trim() != "Hour")
                {
                    edCount = edCount - 1;
                    endHour = txtEndHours.Text.Trim();
                }
                if (txtEndMins.Text.Trim() != "" && txtEndMins.Text.Trim() != "Minutes")
                {
                    edCount = edCount - 1;
                    endMins = txtEndMins.Text.Trim();
                }
                endDayHalfs = ddlEndAPM.SelectedItem.Text.ToString();
                if (endHour == "00" && endMins == "00" && edCount == 2)
                    strDayHalfs = "AM";
                endDateTime = endDate + " " + endHour + ":" + endMins + " " + endDayHalfs;
                /*******************************************************************************/
                #endregion Date and Time
                if (ValidatePublishDate())
                {
                    if (Convert.ToDateTime(endDateTime) >= Convert.ToDateTime(strDateTime))
                    {
                        string eventTitle = string.Empty;
                        int? id = null;
                        bool isPublic = false;
                        if (rbPublic.Checked)
                        {
                            isPublic = true;
                        }
                        eventTitle = txtEventName.Text.Trim();
                        EventDesc = hdnPreviewHTML.Value.ToString();
                        string eventStartDate = strDateTime;
                        string eventEndDate = endDateTime;
                        string editHtml = hdnEditHTML.Value.ToString();
                        string ListDescription = Convert.ToString(hdnDescription.Value);

                        DateTime? publishDate = null;

                        if (txtPublishDate.Text != string.Empty)
                        {
                            publishDate = Convert.ToDateTime(txtPublishDate.Text);
                        }

                        isCall = chkCall.Checked;
                        isContatUs = chkContact.Checked;


                        #region Expiry Date Code

                        DateTime? ExpiryDate;
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

                        if (CalendarId == 0)
                            Session["CalendarSuccess"] = eventTitle + " has been saved successfully.";
                        else
                            Session["CalendarSuccess"] = eventTitle + " has been updated successfully.";
                        //Create  duplicates images
                        EventDesc = CreateBusinessEventsFolderandChangePaths(EventDesc, ListDescription, ExpiryDate);
                        bool isRepeat = false;
                        int? parentEventID = null;
                        if (hdn3Items.Value == "")
                        {
                            hdn3Items.Value = hdn3Itemsold.Value;
                            hdnRepeatOn.Value = hdnRepeatOnold.Value;
                            hdnRepeatBy.Value = hdnRepeatByold.Value;
                            hdnEndOn.Value = hdnEndOnold.Value;
                        }
                        string[] str3ItemsArray = Regex.Split(hdn3Items.Value, @"##SP##");
                        string[] strEndsOn = Regex.Split(hdnEndOn.Value, @"##SP##");
                        if (chkRepeat.Checked)
                            isRepeat = true;
                        bool showRepeat = true;
                        //roles & permissions..
                        int addflag = -1; // *** -1 means no repeat operations do not do *** || *** 0 means first time repeat started *** //
                        #region
                        if (hdnAlreadyRepeat.Value == "1")
                        {
                            if (isRepeat == false)
                                objCalendarAddOn.DeleteRepeatForCalendar(CalendarId, UserID, 1, CUserID); // *** 1 means delete all events except this event *** // 
                            else
                            {
                                DataTable dtExistingEvent = objCalendarAddOn.GetCalendarAddOnDetails(CalendarId);
                                DataTable dtParent = new DataTable();
                                if (dtExistingEvent.Rows.Count > 0)
                                {
                                    if (Convert.ToString(dtExistingEvent.Rows[0]["ParentCalendarID"]) != "")
                                        dtParent = objCalendarAddOn.GetCalendarAddOnDetails(Convert.ToInt32(dtExistingEvent.Rows[0]["ParentCalendarID"]));
                                    if (Convert.ToDateTime(dtExistingEvent.Rows[0]["EventStartDate"]).ToShortDateString() != Convert.ToDateTime(txtStartDate.Text).ToShortDateString())
                                    {
                                        if (hdnSeriesChangeType.Value == "2")
                                        {
                                            objCalendarAddOn.DeleteRepeatForCalendar(CalendarId, UserID, 2, CUserID); // *** 2 means delete following events except this event *** // 
                                            addflag = 0;
                                        }
                                        else
                                        {
                                            if (Convert.ToString(dtExistingEvent.Rows[0]["ParentCalendarID"]) == "")
                                                objCalendarAddOn.ChangeParentCalendar(CalendarId, true, CUserID);
                                            showRepeat = false;
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToDateTime(dtExistingEvent.Rows[0]["EventEndDate"]).ToShortDateString() != Convert.ToDateTime(txtEndDate.Text).ToShortDateString())
                                        {
                                            if (hdnSeriesChangeType.Value == "1")
                                            {
                                                if (Convert.ToString(dtExistingEvent.Rows[0]["ParentCalendarID"]) == "")
                                                    objCalendarAddOn.ChangeParentCalendar(CalendarId, true, CUserID);
                                                showRepeat = false;
                                            }
                                            else
                                            {
                                                if (hdnSeriesChangeType.Value == "0")
                                                {
                                                    if (Convert.ToString(dtExistingEvent.Rows[0]["ParentCalendarID"]) != "")
                                                    {
                                                        CalendarId = Convert.ToInt32(dtExistingEvent.Rows[0]["ParentCalendarID"]);
                                                        if (dtParent.Rows.Count > 0)
                                                        {
                                                            CalendarId = Convert.ToInt32(dtExistingEvent.Rows[0]["ParentCalendarID"]);
                                                            eventStartDate = Convert.ToDateTime(Convert.ToDateTime(dtParent.Rows[0]["EventStartDate"]).ToShortDateString()).AddHours(Convert.ToDateTime(eventStartDate).Hour).AddMinutes(Convert.ToDateTime(eventStartDate).Hour).ToString();
                                                            TimeSpan ts = Convert.ToDateTime(txtEndDate.Text) - Convert.ToDateTime(txtStartDate.Text);
                                                            int eventdays = ts.Days;
                                                            eventEndDate = Convert.ToDateTime(Convert.ToDateTime(dtParent.Rows[0]["EventStartDate"]).ToShortDateString()).AddDays(eventdays).AddHours(Convert.ToDateTime(eventEndDate).Hour).AddMinutes(Convert.ToDateTime(eventEndDate).Hour).ToString();
                                                        }
                                                    }
                                                }
                                                if ((hdn3Items.Value != hdn3Itemsold.Value || hdnEndOn.Value != hdnEndOnold.Value || hdnRepeatOn.Value != hdnRepeatOnold.Value || hdnRepeatBy.Value != hdnRepeatByold.Value) && hdnCalChanged.Value == "1")
                                                {
                                                    objCalendarAddOn.DeleteRepeatForCalendar(CalendarId, UserID, 2, CUserID); // *** 2 means delete following events except this event *** //
                                                    addflag = 0;
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(dtExistingEvent.Rows[0]["ParentCalendarID"]) != "")
                                                    {
                                                        if (hdnSeriesChangeType.Value == "2")
                                                            objCalendarAddOn.ChangeParentCalendar(CalendarId, false, CUserID);
                                                    }

                                                    objEventCalendar.AddRepeatEventDetails(CalendarId, Convert.ToInt32(str3ItemsArray[0]), Convert.ToInt32(str3ItemsArray[1]), Convert.ToDateTime(eventStartDate), Convert.ToInt32(strEndsOn[0]), strEndsOn[1], hdnRepeatOn.Value, hdnRepeatBy.Value, CUserID, WebConstants.Tab_CalendarAddOns);
                                                    addflag = 1; // *** update end date and timings if changes *** //
                                                }
                                            }
                                        }
                                        else if ((hdn3Items.Value != hdn3Itemsold.Value || hdnEndOn.Value != hdnEndOnold.Value || hdnRepeatOn.Value != hdnRepeatOnold.Value || hdnRepeatBy.Value != hdnRepeatByold.Value) && hdnCalChanged.Value == "1")
                                        {
                                            if (hdnSeriesChangeType.Value == "1")
                                            {
                                                if (Convert.ToString(dtExistingEvent.Rows[0]["ParentCalendarID"]) == "")
                                                    objCalendarAddOn.ChangeParentCalendar(CalendarId, true, CUserID);
                                                showRepeat = false;
                                            }
                                            else
                                            {
                                                if (hdnSeriesChangeType.Value == "0")
                                                {
                                                    if (Convert.ToString(dtExistingEvent.Rows[0]["ParentCalendarID"]) != "")
                                                    {
                                                        if (dtParent.Rows.Count > 0)
                                                        {
                                                            CalendarId = Convert.ToInt32(dtExistingEvent.Rows[0]["ParentCalendarID"]);
                                                            eventStartDate = Convert.ToDateTime(Convert.ToDateTime(dtParent.Rows[0]["EventStartDate"]).ToShortDateString()).AddHours(Convert.ToDateTime(eventStartDate).Hour).AddMinutes(Convert.ToDateTime(eventStartDate).Hour).ToString();
                                                            eventEndDate = Convert.ToDateTime(Convert.ToDateTime(dtParent.Rows[0]["EventEndDate"]).ToShortDateString()).AddHours(Convert.ToDateTime(eventEndDate).Hour).AddMinutes(Convert.ToDateTime(eventEndDate).Hour).ToString();
                                                        }
                                                    }
                                                }
                                                objCalendarAddOn.DeleteRepeatForCalendar(CalendarId, UserID, 2, CUserID); // *** 2 means delete following events except this event *** //
                                                addflag = 0;
                                            }
                                        }
                                        else if (Convert.ToDateTime(dtExistingEvent.Rows[0]["EventStartDate"]).Hour != Convert.ToDateTime(eventStartDate).Hour || Convert.ToDateTime(dtExistingEvent.Rows[0]["EventStartDate"]).Minute != Convert.ToDateTime(eventStartDate).Minute || Convert.ToDateTime(dtExistingEvent.Rows[0]["EventEndDate"]).Hour != Convert.ToDateTime(eventEndDate).Hour || Convert.ToDateTime(dtExistingEvent.Rows[0]["EventEndDate"]).Minute != Convert.ToDateTime(eventEndDate).Minute)
                                        {
                                            if (hdnSeriesChangeType.Value == "1")
                                            {
                                                if (Convert.ToString(dtExistingEvent.Rows[0]["ParentCalendarID"]) == "")
                                                    objCalendarAddOn.ChangeParentCalendar(CalendarId, true, CUserID);
                                                showRepeat = false;
                                            }
                                            else
                                            {
                                                if (hdnSeriesChangeType.Value == "0")
                                                {
                                                    if (Convert.ToString(dtExistingEvent.Rows[0]["ParentCalendarID"]) != "")
                                                    {
                                                        if (dtParent.Rows.Count > 0)
                                                        {
                                                            CalendarId = Convert.ToInt32(dtExistingEvent.Rows[0]["ParentCalendarID"]);
                                                            eventStartDate = Convert.ToDateTime(Convert.ToDateTime(dtParent.Rows[0]["EventStartDate"]).ToShortDateString()).AddHours(Convert.ToDateTime(eventStartDate).Hour).AddMinutes(Convert.ToDateTime(eventStartDate).Hour).ToString();
                                                            eventEndDate = Convert.ToDateTime(Convert.ToDateTime(dtParent.Rows[0]["EventEndDate"]).ToShortDateString()).AddHours(Convert.ToDateTime(eventEndDate).Hour).AddMinutes(Convert.ToDateTime(eventEndDate).Hour).ToString();
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(dtExistingEvent.Rows[0]["ParentCalendarID"]) != "")
                                                        objCalendarAddOn.ChangeParentCalendar(CalendarId, false, CUserID);
                                                }
                                                objEventCalendar.AddRepeatEventDetails(CalendarId, Convert.ToInt32(str3ItemsArray[0]), Convert.ToInt32(str3ItemsArray[1]), Convert.ToDateTime(eventStartDate), Convert.ToInt32(strEndsOn[0]), strEndsOn[1], hdnRepeatOn.Value, hdnRepeatBy.Value, CUserID, WebConstants.Tab_CalendarAddOns);
                                                addflag = 2; // *** Update timings *** //
                                            }
                                        }
                                        else
                                        {
                                            if (Convert.ToString(dtExistingEvent.Rows[0]["ParentCalendarID"]) != "")
                                            {
                                                if (dtParent.Rows.Count > 0)
                                                {
                                                    CalendarId = Convert.ToInt32(dtExistingEvent.Rows[0]["ParentCalendarID"]);
                                                    eventStartDate = Convert.ToDateTime(Convert.ToDateTime(dtParent.Rows[0]["EventStartDate"]).ToShortDateString()).AddHours(Convert.ToDateTime(eventStartDate).Hour).AddMinutes(Convert.ToDateTime(eventStartDate).Hour).ToString();
                                                    eventEndDate = Convert.ToDateTime(Convert.ToDateTime(dtParent.Rows[0]["EventEndDate"]).ToShortDateString()).AddHours(Convert.ToDateTime(eventEndDate).Hour).AddMinutes(Convert.ToDateTime(eventEndDate).Hour).ToString();
                                                }
                                            }
                                            addflag = 3; // *** update content only *** //
                                        }
                                    }
                                }
                            }
                        }
                        else if (isRepeat)
                            addflag = 0;
                        #endregion
                        CalendarId = AddUpdateEvent(CalendarId, eventTitle, EventDesc, eventStartDate, eventEndDate, isPublic, editHtml, id, publishDate, ListDescription, ExpiryDate, isRepeat, parentEventID);
                        if (addflag >= 0)
                            AddRepeatEvents(addflag, CalendarId, str3ItemsArray, strEndsOn, Convert.ToDateTime(eventStartDate), Convert.ToDateTime(eventEndDate));



                        /************************************ Auto Share ***************************************/
                        if (!(Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "") || hdnPermissionType.Value == "P")
                        {
                            if (isPublic)
                            {
                                if (chkFbAutoPost.Checked)
                                    objEventCalendar.InsertUpdateAutoShareDetails(WebConstants.Tab_CalendarAddOns, CalendarId, 0, Convert.ToDateTime(txtPublishDate.Text), "Facebook", UserID, CUserID, eventTitle);
                                if (chkTwrAutoPost.Checked)
                                    objEventCalendar.InsertUpdateAutoShareDetails(WebConstants.Tab_CalendarAddOns, CalendarId, 0, Convert.ToDateTime(txtPublishDate.Text), "Twitter", UserID, CUserID, eventTitle);
                            }
                        }
                        if (Request.QueryString["CalId"] != null && Request.QueryString["CalId"].ToString() != "")
                        {
                            CalendarId = Convert.ToInt32(Request.QueryString["CalId"]);
                            if (rbPrivate.Checked && hdnIsAlreadyPublished.Value == "1")
                                objEventCalendar.UpdateSentFlag(CalendarId, 2, 0, WebConstants.Tab_CalendarAddOns);
                        }


                        /****** Auto Share Completed ******/

                        if (hdnSeriesChangeType.Value == "0" || hdnSeriesChangeType.Value == "2")
                        {
                            if (addflag > 0)
                                objCalendarAddOn.UpdateContentForCalFollowing(CalendarId);
                        }
                        // *** Convert to image ***//
                        EventHtmlConvertImage(EventDesc);
                        if (showRepeat == false)
                            objCalendarAddOn.UpdateShowRepeatByAddOn(CalendarId, false);
                        #region Save User Activity Log

                        if (System.Web.HttpContext.Current.Session["CalendarSuccess"].ToString().Contains("saved"))
                        {
                            objCommon.InsertUserActivityLog("has created an event titled <b>" + eventTitle + "</b>", string.Empty, UserID, ProfileId, DateTime.Now, UserID);
                        }
                        else
                        {
                            objCommon.InsertUserActivityLog("has updated an event named <b>" + eventTitle + "</b>", string.Empty, UserID, ProfileId, DateTime.Now, UserID);
                        }

                        #endregion

                        Response.Redirect(GetUrl(WebConstants.ManageUrl_CalendarAddOns));
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Bind Repeat", "BindChanges('Bind');", true);
                        lblerror.Text = "<font color='red'>" + "Event End Date and Time should be later than or equal to Event Start Date and Time." + "</font>";
                    }
                }

                MPEProgress.Hide();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CAEventsCalendar.aspx.cs", "btnSaveExit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public int AddUpdateEvent(int eventId, string eventTitle, string eventDesc, string eventStartDate, string eventEndDate, bool isPublish, string editHtml, int? id, DateTime? publishDate, string listDescription, DateTime? expiryDate, bool isRepeat, int? parentEventID)
        {
            try
            {
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    if (hdnPermissionType.Value == "P" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //P for publisher
                    {
                        CalendarId = objCalendarAddOn.InsertCalendarAddOnDetails(eventId, ProfileId, UserID, eventTitle, EventDesc, eventStartDate, eventEndDate, CUserID, chkCall.Checked, chkContact.Checked, false,
                            editHtml, listDescription, isPublish, isPublish == false ? id : CUserID, publishDate, expiryDate, isRepeat, parentEventID, CalendarAddOnId);
                    }
                    else   // for author
                    {
                        CalendarId = objCalendarAddOn.InsertCalendarAddOnDetails(eventId, ProfileId, UserID, eventTitle, EventDesc, eventStartDate, eventEndDate, CUserID, chkCall.Checked, chkContact.Checked, false,
                            editHtml, listDescription, isPublish, id, publishDate, expiryDate, isRepeat, parentEventID, CalendarAddOnId);
                        if (isPublish)
                            objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), eventId, PageNames.CALENDARADDON, UserID, Session["username"].ToString(), PageNames.CALENDARADDON, DomainName);
                    }
                }
                else
                {
                    CalendarId = objCalendarAddOn.InsertCalendarAddOnDetails(eventId, ProfileId, UserID, eventTitle, EventDesc, eventStartDate, eventEndDate, CUserID, chkCall.Checked, chkContact.Checked, false,
                            editHtml, listDescription, isPublish, isPublish == false ? id : CUserID, publishDate, expiryDate, isRepeat, parentEventID, CalendarAddOnId);
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CAEventsCalendar.aspx.cs", "AddUpdateEvent", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return eventId;
        }
        public void AddRepeatEvents(int addflag, int parentEventID, string[] str3ItemsArray, string[] strEndsOn, DateTime eventStartDate, DateTime eventEndDate)
        {
            try
            {
                if (addflag == 0)
                {
                    objEventCalendar.AddRepeatEventDetails(parentEventID, Convert.ToInt32(str3ItemsArray[0]), Convert.ToInt32(str3ItemsArray[1]), eventStartDate, Convert.ToInt32(strEndsOn[0]), strEndsOn[1], hdnRepeatOn.Value, hdnRepeatBy.Value, CUserID, WebConstants.Tab_CalendarAddOns);
                    objCalendarAddOn.AddRepeatEventsForCalendarAddOn(parentEventID, str3ItemsArray, strEndsOn, hdnRepeatOn.Value, hdnRepeatBy.Value, eventStartDate, eventEndDate, CUserID);
                }
                else
                {
                    objCalendarAddOn.UpdateRepeatCalendarDetails(parentEventID, addflag, eventStartDate, eventEndDate, CUserID);
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CAEventsCalendar.aspx.cs", "AddRepeatEvents", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void EventHtmlConvertImage(string desc)
        {
            try
            {
                Session["HtmlText"] = null;
                // *** Convert to image ***//
                string strhtml = "<html><head></head><body><table width='650px' border='0' cellspacing='0' cellpadding='0'><tr><td style='padding:30px;'>" + desc + "</td></tr><tr></table></body></html>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(strhtml.ToString());
                ImgConverter imgConverter = new ImgConverter();
                MemoryStream msval = new MemoryStream(buffer);
                imgConverter.LicenseKey = ConfigurationManager.AppSettings.Get("imgkeyval");
                imgConverter.PageWidth = 650;
                string saveFilePath = Server.MapPath("~") + "\\Upload\\CalendarAddOns\\" + ProfileId.ToString();
                if (!System.IO.Directory.Exists(saveFilePath))
                {
                    System.IO.Directory.CreateDirectory(saveFilePath);
                }
                string savelocation = saveFilePath + "\\" + CalendarId.ToString() + ".jpg";
                string tempimagepath = Server.MapPath("~") + "\\Upload\\CalendarAddOns\\" + ProfileId.ToString() + "\\" + ProfileId.ToString() + UserID.ToString() + ".jpg";
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
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CAEventsCalendar.aspx.cs", "EventHtmlConvertImage", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        [WebMethod]
        public static string ShowPreview(string updateBody, string profileID1, string userID1, string startdate, string enddate)
        {
            string previewHtml = string.Empty;
            try
            {
                CommonBLL objCommon = new CommonBLL();
                
                string eventdate = "";
                try
                {
                    eventdate = objCommon.GetEventAdjustDate(Convert.ToDateTime(startdate.Trim()), Convert.ToDateTime(enddate.Trim()));
                }
                catch (Exception /*ex*/)
                {

                }

                previewHtml = "<html><head></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='border: solid 2px #F4EBEB;'> <tr><td colspan='2' style='padding:10px;'>" + eventdate + "</td></tr><tr><td colspan='2' style='padding:30px;'>" + updateBody + "</td></tr></table></body></html>";

                previewHtml = objCommon.ReplaceShortURltoHtmlString(previewHtml);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "CAEventsCalendar.aspx.cs", "ShowPreview", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return previewHtml;
        }
        private string CreateBusinessEventsFolderandChangePaths(string updateHtmlText, string LstDescription, DateTime? ExpiryDate)
        {
            try
            {
                //Create Photo and Video Upload Folder
                if (CalendarId > 0)
                {
                    MaxEventId = CalendarId;
                    string checkFolderPath = Server.MapPath("~") + "\\Upload\\CalendarAddOns\\" + ProfileId.ToString() + "\\" + MaxEventId.ToString();
                    if (Directory.Exists(checkFolderPath) == false)
                    {
                        Directory.CreateDirectory(checkFolderPath);
                    }
                }
                else
                {
                    bool isRepeat = false;
                    if (chkRepeat.Checked)
                        isRepeat = true;
                    CalendarId = objCalendarAddOn.InsertCalendarAddOnDetails(CalendarId, ProfileId, UserID, txtEventName.Text.Trim(), string.Empty, DateTime.Now.ToShortDateString(),
                        DateTime.Now.ToShortDateString(), CUserID, chkCall.Checked, chkContact.Checked, false, hdnEditHTML.Value.ToString(), LstDescription, false, null, null, ExpiryDate, isRepeat, null, CalendarAddOnId);
                    MaxEventId = CalendarId;

                    string checkFolderPath = Server.MapPath("~") + "\\Upload\\CalendarAddOns\\" + ProfileId.ToString() + "\\" + MaxEventId.ToString();
                    if (Directory.Exists(checkFolderPath) == false)
                    {
                        Directory.CreateDirectory(checkFolderPath);
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CAEventsCalendar.aspx.cs", "CreateBusinessEventsFolderandChangePaths", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return updateHtmlText;
            // End
        }
        private bool ValidatePublishDate()
        {
            bool addflag = true;
            try
            {
                if (txtPublishDate.Text.Trim() != "")
                {
                    DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileId);
                    if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0)
                    {
                        lblerror.Text = "<font size='2' color='red'>" + Resources.LabelMessages.PublishDateAlert + "</font>";
                        addflag = false;
                    }
                    if (rbPublic.Checked)
                    {
                        int publishValue = 2;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowPublish('" + publishValue + "','0');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "CAEventsCalendar.aspx.cs", "ValidatePublishDate", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return addflag;
        }
        [System.Web.Services.WebMethod]
        public static bool CheckDataChanges(string eventId, string eventTitle, string startDate, string endDate, string expireDate, bool isPublished, string publishDate)
        {
            bool isChanged = false;
            return isChanged;
        }
        [System.Web.Services.WebMethod]
        public static string ReplaceShortURltoHmlString(string htmlString)
        {
            try
            {
                CommonBLL objCommonBll = new CommonBLL();
                htmlString = objCommonBll.ReplaceShortURltoHtmlString(htmlString);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "CAEventsCalendar.aspx.cs", "ReplaceShortURltoHmlString", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return htmlString;
        }
    }
}