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
using USPDHUBBLL;
using System.Web.Services;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using System.Net;
using Winnovative.WnvHtmlConvert;
using System.Text;
using System.Drawing;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Web;
using System.Reflection;
using Facebook;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageCalAddOns : BaseWeb
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public int C_UserID = 0;
        public int BusinessUpdatesCount = 0;
        public int BusinessEventUsageCount = 0;
        public string RootPath = "";
        public string DomainName = "";
        public string titleName = "";
        public int CalendarAddOnID = 0;
        public string gFolder = "";
        public string ShowButtons = string.Empty;
        List<string> lst = new List<string>();
        string appID = string.Empty;    //Facebook App ID and Secret
        string appSecret = string.Empty;
        string fbScope = "public_profile,publish_actions,publish_stream,manage_pages";
        public string ArchiveValue = string.Empty;
        public int SortDir = 0;
        public string articleTitle = string.Empty;
        public string articleSummary = string.Empty;
        public string linkedInurlinfo = string.Empty;
        public string FacebookInurlinfo = string.Empty;
        public string Twitterurlinfo = string.Empty;
        public string Mailtourlinfo = string.Empty;

        CommonBLL objCommon = new CommonBLL();
        CalendarAddOnBLL objCalendarAddOn = new CalendarAddOnBLL();
        AddOnBLL objAddOn = new AddOnBLL();
        CalendarService service;
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        AgencyBLL objAgency = new AgencyBLL();

        DataTable dtAddOn = new DataTable();
        DataTable dtpermissions = new DataTable();
        DataTable dtobj = new DataTable();
        DataTable dtCalenderAddOn = new DataTable();
        DataTable DtHis = new DataTable();
        DataTable dtCampaign = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            gFolder = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/MyGoogleStorage");
            GetFacebookAppDetails();
            if (Session["CalendarAddOnID"] == null)
            {
                Response.Redirect(RootPath + "/Business/MyAccount/Default.aspx");
            }
            else
                CalendarAddOnID = Convert.ToInt32(Session["CalendarAddOnID"].ToString());
            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            C_UserID = UserID;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
            // *** Make back button visible and disable by query string 26-03-2013 *** //
            if (!string.IsNullOrEmpty(Request.QueryString["App"] as string))
                btnBack.Visible = true;
            else
                btnBack.Visible = false;
            if (!IsPostBack)
            {
                if (Request.QueryString["code"] != null && Request.QueryString["State"] != null && Convert.ToString(Session["ResponseCodeType"]) != "FB")
                {
                    FillGoogleCalendarEvents();
                }
                else if (Request["code"] != null)
                {
                    ShareOnFacebook();
                }

                if (Request.QueryString["fbStatus"] != null)
                {
                    if (Convert.ToInt32(Request.QueryString["fbStatus"]) == 1)
                    {
                        objCommon.UpdateSocialShareStatus(UserID, 1, "Facebook", Convert.ToInt32(Session["ContentID"]),1);//updating status flag for report
                        lblmess.Text = "<span style='color:green;'>Your content has been posted on facebook successfully.</span>";
                    }
                    if (Convert.ToInt32(Request.QueryString["fbStatus"]) == 0)
                    {
                        objCommon.UpdateSocialShareStatus(UserID, 0, "Facebook", Convert.ToInt32(Session["ContentID"]),0);//updating status flag for report
                        lblmess.Text = "<span style='color:red;'>Facebook server is not responding. Please try again later.</span>";
                    }
                }
                lblOff.Visible = true;
                dtAddOn = objAddOn.GetAddOnById(CalendarAddOnID);
                ltrlTitleImage.Text = "<img style='width:auto;height:auto;vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtAddOn.Rows[0]["AppIcon"].ToString() + ".png'/>";
                if (dtAddOn.Rows.Count == 1)
                {
                    hdnAddOnName.Value = dtAddOn.Rows[0]["TabName"].ToString();
                    if (Convert.ToBoolean(dtAddOn.Rows[0]["IsVisible"]))
                    {
                        lblOn.Visible = true;
                        lblOff.Visible = false;
                    }
                }
                //RBAppOrder.SelectedValue = objCommon.DisplayOrderType(UserID, WebConstants.Tab_CalendarAddOns, CalendarAddOnID);
                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), CalendarAddOnID, "CalendarAddon");
                    if (string.IsNullOrEmpty(hdnPermissionType.Value))
                    {
                        UpdatePanel2.Visible = true;
                        UpdatePanel1.Visible = false;
                        lblerrormessage.Text = "<font face=arial size=2>You do not have permission to manage addons.</font>";
                    }
                }
                Session["CalendarId"] = null;
                Session["CalendarDes"] = null;
                // *** Issue 1128 *** //
                if (Session["CalendarSuccess"] != null)
                {
                    lblmess.Text = Session["CalendarSuccess"].ToString();
                    Session["CalendarSuccess"] = null;
                }
                if (Session["ViewGrid"] != null)
                {
                    lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive.gif' title='Archive' border='0'/>";
                    lnkCurrent.Text = "<img src='../../Images/Dashboard/current.gif' title='Current' border='0'/>";
                    hdnarchive.Value = Session["ViewGrid"].ToString();
                    Session["ViewGrid"] = null;
                }
                if (Session["BulletinSuccess"] != null)
                {
                    lblmess.Text = Session["BulletinSuccess"].ToString();
                    Session.Remove("BulletinSuccess");
                }
                hdnsortdire.Value = "";
                hdnsortcount.Value = "0";
                FillDatalist();
                DisplaySyncButtons();
                DataTable dtConfigPageKeys = objCommon.GetVerticalConfigsByType(DomainName, "Social");
                if (dtConfigPageKeys.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigPageKeys.Rows)
                    {
                        if (row[0].ToString() == "FacebookAPIKey")
                            hdnFacebookAppId.Value = row[1].ToString();
                    }
                }
                ShowGoogleSyncDate();
                ShowLoadMessages();
            }
        }
        public void FillDatalist()
        {
            trPublish.Visible = trUnPublish.Visible = false;
            hdnCommandArg.Value = "";
            dtobj = objCalendarAddOn.GetAllCalendarsByProfileId(ProfileID, CalendarAddOnID);
            // ** show Current and Archive tabs *** //
            if (dtobj.Rows.Count > 0)
            {
                showCurrArcives(true);
            }
            else
            {
                showCurrArcives(false);
            }
            if (hdnarchive.Value == "Archive")
            {
                GrdEvents.Columns[2].Visible = true;
                GrdEvents.Columns[1].Visible = false;
                ArchiveValue = "Archive";

            }
            else
            {
                GrdEvents.Columns[1].Visible = true;
                GrdEvents.Columns[2].Visible = false;
                ArchiveValue = "NoArchive";
            }
            dtobj = RemoveArchive(dtobj, ArchiveValue);
            if (dtobj.Rows.Count > 0)
            {
                BusinessUpdatesBLL objUpdate = new BusinessUpdatesBLL();
                dtobj.Columns.Add("Sent_Flag", typeof(string));
                for (int i = 0; i < dtobj.Rows.Count; i++)
                {
                    DataTable dtScheduleEmails = objUpdate.CheckBusinessUpdateCampaignCountByID(Convert.ToInt32(dtobj.Rows[i]["CalendarId"].ToString()), WebConstants.Tab_CalendarAddOns);
                    if (dtScheduleEmails.Rows.Count > 0)
                    {
                        if (dtScheduleEmails.Rows[0]["Count"].ToString() != "0")
                        {

                            if (Convert.ToInt32(dtScheduleEmails.Rows[0]["Scheduled"].ToString()) > 0 && Convert.ToInt32(dtScheduleEmails.Rows[0]["Sent"].ToString()) > 0)
                            {
                                dtobj.Rows[i]["Sent_Flag"] = "Sending";
                            }
                            else if (Convert.ToInt32(dtScheduleEmails.Rows[0]["Scheduled"].ToString()) > 0)
                            {
                                dtobj.Rows[i]["Sent_Flag"] = "Scheduled";
                            }
                            else if (Convert.ToInt32(dtScheduleEmails.Rows[0]["Scheduled"].ToString()) == 0 && Convert.ToInt32(dtScheduleEmails.Rows[0]["Sent"].ToString()) > 0)
                            {
                                dtobj.Rows[i]["Sent_Flag"] = "Sent";
                            }
                            else
                            {
                                dtobj.Rows[i]["Sent_Flag"] = "Cancelled";
                            }
                        }
                        else
                        {
                            if (Convert.ToBoolean(dtobj.Rows[i]["IsPublished"]) == false)
                                dtobj.Rows[i]["Sent_Flag"] = "Work in Progress";
                            else
                                dtobj.Rows[i]["Sent_Flag"] = "Completed";
                        }
                    }
                    else
                    {
                        if (Convert.ToBoolean(dtobj.Rows[i]["IsPublished"]) == false)
                            dtobj.Rows[i]["Sent_Flag"] = "Work in Progress";
                        else
                            dtobj.Rows[i]["Sent_Flag"] = "Completed";
                    }
                }
            }
            Session["DtEvents"] = dtobj;
            BusinessUpdatesCount = dtobj.Rows.Count;
            if (BusinessUpdatesCount > 0)
            {
                hdnShowButtons.Value = "1";
            }
            else
            {
                hdnShowButtons.Value = "";
            }
            GrdEvents.DataSource = dtobj.DefaultView;
            GrdEvents.DataBind();
        }
        private void showCurrArcives(bool Flag)
        {
            lnkGetArchive.Visible = Flag;
            lnkCurrent.Visible = Flag;
        }
        private DataTable RemoveArchive(DataTable dt, string Archive)
        {
            // *** Get Newsletter without Achrive *** //
            DataTable DtData = dt;
            string SelectQuery = string.Empty;
            if (Archive == "NoArchive")
            {
                SelectQuery = "IsArchive='True'";
            }
            else
            {
                SelectQuery = "IsArchive='False'";
            }
            DataRow[] DRSelectArcive;
            DRSelectArcive = DtData.Select(SelectQuery);
            DataTable dtupdatedarcive = DtData.Clone();
            foreach (DataRow dr in DRSelectArcive)
            {
                dtupdatedarcive.ImportRow(dr);
                DtData.Rows.Remove(dr);
            }
            DtData.AcceptChanges();
            return DtData;
        }
        private DataTable RemoveStatus(DataTable dt, string Status)
        {
            // *** Get Newsletter without Achrive *** //
            DataTable DtData = dt;
            string SelectQuery = string.Empty;
            SelectQuery = "Sent_Flag = '" + Status + "'";
            DataRow[] DRSelectArcive;
            DRSelectArcive = DtData.Select(SelectQuery);
            DataTable dtupdatedarcive = DtData.Clone();
            foreach (DataRow dr in DRSelectArcive)
            {
                dtupdatedarcive.ImportRow(dr);
                DtData.Rows.Remove(dr);
            }
            DtData.AcceptChanges();
            return dtupdatedarcive;
        }
        protected void RBAppOrder_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedOrderType = 1; // Convert.ToInt32(RBAppOrder.SelectedValue);
            objCommon.UpdateDisplayOrderType(ProfileID, CalendarAddOnID, selectedOrderType, WebConstants.Tab_CalendarAddOns);
        }
        protected void lnkCurrent_Click(object sender, EventArgs e)
        {
            drpfilter.SelectedIndex = -1;
            CancelCamp.Visible = false;
            lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>";
            lnkCurrent.Text = "<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>";
            hdnCommandArg.Value = "";
            hdnarchive.Value = "NoArchive";
            FillDatalist();
        }
        protected void lnkGetArchive_Click(object sender, EventArgs e)
        {
            drpfilter.SelectedIndex = -1;
            CancelCamp.Visible = false;
            lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive.gif' title='Archive' border='0'/>";
            lnkCurrent.Text = "<img src='../../Images/Dashboard/current.gif' title='Current' border='0'/>";
            hdnCommandArg.Value = "";
            hdnarchive.Value = "Archive";
            FillDatalist();
        }
        protected void drpfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnCommandArg.Value = "";
            CancelCamp.Visible = false;
            ShowButtons = "1";
            string calendarFilter = drpfilter.SelectedItem.Value;

            if (calendarFilter != "0")
            {
                FillDatalist(); //*** Added for session renew ***//
                DataTable dtfilter = new DataTable();
                dtfilter = (DataTable)Session["DtEvents"];
                // *** Get Newsletter without Achrive *** //
                if (hdnarchive.Value == "Archive")
                {
                    ArchiveValue = "Archive";
                }
                else
                {
                    ArchiveValue = "NoArchive";
                }
                dtfilter = RemoveArchive(dtfilter, ArchiveValue);
                if (dtfilter.Rows.Count > 0)
                {
                    string EventCampStatus = string.Empty;
                    if (calendarFilter == "1")
                    {
                        EventCampStatus = "Work in Progress";
                    }
                    else if (calendarFilter == "2")
                        EventCampStatus = "Scheduled";
                    else if (calendarFilter == "3")
                        EventCampStatus = "Sending";
                    else if (calendarFilter == "4")
                        EventCampStatus = "Sent";
                    else if (calendarFilter == "6")
                        EventCampStatus = "Completed";
                    else
                        EventCampStatus = "Cancelled";

                    dtfilter = RemoveStatus(dtfilter, EventCampStatus);
                    if (dtfilter.Rows.Count > 0)
                    {
                        Session["DtEvents"] = dtfilter;
                        hdnShowButtons.Value = "1";
                        GrdEvents.PageIndex = 0;
                    }
                    else
                    {
                        hdnShowButtons.Value = "";
                    }
                }
                else
                {
                    hdnShowButtons.Value = "";
                }
                GrdEvents.DataSource = dtfilter;
                GrdEvents.DataBind();
            }
            else
            {
                GrdEvents.PageIndex = 0;
                FillDatalist();
            }
        }
        protected void btnSyncOn_Click(object sender, EventArgs e)
        {
            Session["ResponseCodeType"] = "Google";

            RemoveGoogleResponseCodeQueryStr();

            string UserId = "user__" + DateTime.Now.ToString("yyyyMMddhhMMss");
            Session["GUserId"] = UserId;
            FillGoogleCalendarEvents();
        }
        protected void btnSyncOff_Click(object sender, EventArgs e)
        {
            EventCalendarBLL ObjEventCalendar = new EventCalendarBLL();
            ObjEventCalendar.InsertUpdateGMailUserDetails(" ", " ", true, false, ProfileID);
            DisplaySyncButtons();
        }
        private void FillGoogleCalendarEvents()
        {
            string googleStorage = Server.MapPath("~/App_Data");
            try
            {
                googleStorage = googleStorage + "\\GoogleStorage";
                if (Directory.Exists(googleStorage))
                {
                    Directory.Delete(googleStorage, true);
                }
                Directory.CreateDirectory(googleStorage);
            }
            catch (Exception /*ex*/)
            {
            }

            IAuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow(
                   new GoogleAuthorizationCodeFlow.Initializer
                   {
                       ClientSecrets = GetClientConfiguration(DomainName).Secrets,
                       DataStore = new FileDataStore(googleStorage),
                       Scopes = new[] { CalendarService.Scope.Calendar },

                   });

            var uri = RootPath + "/Business/MyAccount/" + WebConstants.ManageUrl_CalendarAddOns;
            var code = Request["code"];

            string UserId = Session["GUserId"].ToString();

            if (code != null)
            {
                try
                {
                    var token = flow.ExchangeCodeForTokenAsync(UserId, code, uri.ToString(), CancellationToken.None).Result;

                    // Extract the right state.
                    var result = new AuthorizationCodeWebApp(flow, uri, uri).AuthorizeAsync(UserId,
                        CancellationToken.None).Result;

                    Session["Credentials"] = result.Credential;

                    // The data store contains the user credential, so the user has been already authenticated.
                    string appName = string.Empty;
                    if (DomainName.ToLower().Contains("uspdhub"))
                        appName = ConfigurationManager.AppSettings.Get("UspdhubAppName");
                    else if (DomainName.ToLower().Contains("twovie"))
                        appName = ConfigurationManager.AppSettings.Get("TwovieAppName");
                    else if (DomainName.ToLower().Contains("myyouthhub"))
                        appName = ConfigurationManager.AppSettings.Get("MyYouthHubAppName");
                    else if (DomainName.ToLower().Contains("inschool"))
                        appName = ConfigurationManager.AppSettings.Get("InschoolhubAppName");
                    else
                        appName = ConfigurationManager.AppSettings.Get("LocalhostAppName");

                    service = new CalendarService(new BaseClientService.Initializer
                    {
                        ApplicationName = appName,
                        HttpClientInitializer = result.Credential
                    });
                    IList<CalendarListEntry> list = service.CalendarList.List().Execute().Items;    // Fetch the list of calendar list
                    List<string> lstgooglecal = new List<string>();
                    foreach (CalendarListEntry item in list)
                    {
                        lstgooglecal.Add(item.Summary);
                    }
                    lstGoogleCalenders.DataSource = list;
                    lstGoogleCalenders.DataTextField = "Summary";
                    lstGoogleCalenders.DataValueField = "Id";
                    lstGoogleCalenders.DataBind();
                    MPELoginforGoogleEvents.PopupControlID = "PnlGoogleCalendars";
                    MPELoginforGoogleEvents.Show();

                    Session["ResponseCodeType"] = null;
                }
                catch (Exception /*ex*/)
                {
                    Response.Redirect(uri);
                }
            }
            else
            {
                var result = new AuthorizationCodeWebApp(flow, uri, uri).AuthorizeAsync(UserId, CancellationToken.None).Result;
                if (result.RedirectUri != null)
                    Response.Redirect(result.RedirectUri);
                else
                {
                    Session["Credentials"] = result.Credential;

                    // The data store contains the user credential, so the user has been already authenticated.
                    string appName = string.Empty;
                    if (DomainName.ToLower().Contains("uspdhub"))
                        appName = ConfigurationManager.AppSettings.Get("UspdhubAppName");
                    else if (DomainName.ToLower().Contains("twovie"))
                        appName = ConfigurationManager.AppSettings.Get("TwovieAppName");
                    else if (DomainName.ToLower().Contains("myyouthhub"))
                        appName = ConfigurationManager.AppSettings.Get("MyYouthHubAppName");
                    else if (DomainName.ToLower().Contains("inschool"))
                        appName = ConfigurationManager.AppSettings.Get("InschoolhubAppName");
                    else
                        appName = ConfigurationManager.AppSettings.Get("LocalhostAppName");

                    service = new CalendarService(new BaseClientService.Initializer
                    {
                        ApplicationName = appName,
                        HttpClientInitializer = result.Credential
                    });
                    IList<CalendarListEntry> list = service.CalendarList.List().Execute().Items;    // Fetch the list of calendar list
                    List<string> lstgooglecal = new List<string>();
                    foreach (CalendarListEntry item in list)
                    {
                        lstgooglecal.Add(item.Summary);
                    }
                    lstGoogleCalenders.DataSource = list;
                    lstGoogleCalenders.DataTextField = "Summary";
                    lstGoogleCalenders.DataValueField = "Id";
                    lstGoogleCalenders.DataBind();
                    MPELoginforGoogleEvents.PopupControlID = "PnlGoogleCalendars";
                    MPELoginforGoogleEvents.Show();
                }
            }

            RemoveGoogleResponseCodeQueryStr();
        }
        private void RemoveGoogleResponseCodeQueryStr()
        {
            if (Request.QueryString["code"] != null)
            {
                PropertyInfo isreadonly =
      typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
      "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                // make collection editable
                isreadonly.SetValue(this.Request.QueryString, false, null);
                // remove
                this.Request.QueryString.Remove("code");
                this.Request.QueryString.Remove("state");
                if (this.Request.QueryString.ToString() != string.Empty)
                {
                    string[] separateURL = this.Request.QueryString.ToString().Split('?');
                    NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(separateURL[1]); // 
                    queryString.Remove("code");
                    queryString.Remove("state");
                }
            }

        }
        private GoogleClientSecrets GetClientConfiguration(string DomainName)
        {
            if (DomainName.ToLower().Contains("uspdhub"))
            {
                using (var stream = new FileStream(gFolder + @"\uspdhub_client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    return GoogleClientSecrets.Load(stream);
                }
            }
            else if (DomainName.ToLower().Contains("twovie"))
            {
                using (var stream = new FileStream(gFolder + @"\twovie_client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    return GoogleClientSecrets.Load(stream);
                }
            }
            else if (DomainName.ToLower().Contains("myyouthhub"))
            {
                using (var stream = new FileStream(gFolder + @"\myyouthhub_client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    return GoogleClientSecrets.Load(stream);
                }
            }
            else if (DomainName.ToLower().Contains("inschool"))
            {
                using (var stream = new FileStream(gFolder + @"\inschool_client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    return GoogleClientSecrets.Load(stream);
                }
            }
            else
            {
                using (var stream = new FileStream(gFolder + @"\localhost_client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    return GoogleClientSecrets.Load(stream);
                }
            }
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveGoogleResponseCodeQueryStr();

                string CalendarID = string.Empty;
                int countcalEvents = 0;
                UserCredential credential = (UserCredential)Session["Credentials"];
                var initializer = new BaseClientService.Initializer();
                initializer.HttpClientInitializer = credential;
                initializer.ApplicationName = ConfigurationManager.AppSettings.Get("GoogleAppName");
                service = new CalendarService(initializer);
                IList<CalendarListEntry> list = service.CalendarList.List().Execute().Items;
                EventCalendarBLL objEventCalendar = new EventCalendarBLL();
                for (int i = 0; i < lstGoogleCalenders.Items.Count; i++)
                {
                    if (lstGoogleCalenders.Items[i].Selected == true)
                    {
                        lst.Add(lstGoogleCalenders.Items[i].Text);
                    }
                }
                if (lst.Count() > 0)
                {
                    objEventCalendar.InsertLastSyncDate(ProfileID, UserID, C_UserID, DateTime.Now, WebConstants.Tab_CalendarAddOns);
                    for (int j = 0; j < lst.Count(); j++)
                    {
                        string selectedItem = lst[j];
                        foreach (CalendarListEntry calendar in list)
                        {
                            string caledarname = calendar.Summary;
                            if (caledarname == selectedItem)
                            {
                                countcalEvents += GetGoogleEvents("", calendar.Id, 0, caledarname);
                            }
                        }

                    }
                    ShowGoogleSyncDate();
                    if (countcalEvents == 0)
                        lblmess.Text = "<font color='red' size='2'>" + Resources.LabelMessages.GoogleEventsNotExists + "</font>";
                    else
                    {
                        FillDatalist();
                        lblmess.Text = Resources.LabelMessages.GoogleEventsImportSuccess;
                    }
                }
                else
                {
                    lblpopupgooglecal.Text = "Please select at least one google calendar.";
                    MPELoginforGoogleEvents.PopupControlID = "PnlGoogleCalendars";
                    MPELoginforGoogleEvents.Show();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "ManageCalAddOns.aspx.cs", "btnGo_Click", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private int GetGoogleEvents(string pageToken, string calId, int countcalEvents, string CalendarName)
        {
            var description = string.Empty;
            int calendarId = 0;
            EventsResource.ListRequest requeust = service.Events.List(calId);
            requeust.SingleEvents = true;
            if (pageToken != "")
                requeust.PageToken = pageToken;
            DateTime dtSyncStartTime = objCommon.ConvertToUserTimeZone(ProfileID);
            DateTime dtSyncEndTime = new DateTime(dtSyncStartTime.Year, dtSyncStartTime.Month, 1).AddMonths(12);
            requeust.TimeMax = dtSyncEndTime;
            requeust.TimeMin = dtSyncStartTime;
            Events result = requeust.Execute();
            objCalendarAddOn.RemoveGoogleEvents(calId);    //Remove any existing google events from present day of current import to future before import happens 
            if (result.Items.Count > 0)
            {
                foreach (Event calendarEvent in result.Items)   // Fetch the list of events
                {
                    var EventTitle = calendarEvent.Summary ?? "";
                    description = calendarEvent.Description ?? "";
                    var location = calendarEvent.Location ?? "";
                    EventDateTime start = calendarEvent.Start;
                    EventDateTime end = calendarEvent.End;
                    string startTime = string.Empty;
                    string endTime = string.Empty;
                    if (Convert.ToString(start.DateTime) != "")
                        startTime = (start.DateTime).ToString();
                    else
                        startTime = (start.Date).ToString();

                    if (Convert.ToString(end.DateTime) != "")
                        endTime = (end.DateTime).ToString();
                    else
                        endTime = (end.Date).ToString();
                    if (EventTitle != "")
                    {
                        calendarId = objCalendarAddOn.InsertGMailCalendarDetails(0, ProfileID, UserID, EventTitle, description, startTime, endTime, true, C_UserID, description, C_UserID, DateTime.Now, location, "Google", calId, CalendarName, CalendarAddOnID);
                        EventHtmlConvertImage(description, calendarId);
                        countcalEvents++;
                    }
                }
                if (result.NextPageToken != null)
                    GetGoogleEvents(result.NextPageToken, calId, countcalEvents, CalendarName);

            }

            return countcalEvents;
        }
        private void EventHtmlConvertImage(string desc, int calendarId)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
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
                string saveFilePath = Server.MapPath("~") + "\\Upload\\CalendarAddOns\\" + ProfileID.ToString();
                if (!System.IO.Directory.Exists(saveFilePath))
                {
                    System.IO.Directory.CreateDirectory(saveFilePath);
                }
                string savelocation = saveFilePath + "\\" + calendarId.ToString() + ".jpg";
                string tempimagepath = Server.MapPath("~") + "\\Upload\\CalendarAddOns\\" + ProfileID.ToString() + "\\" + ProfileID.ToString() + UserID.ToString() + ".jpg";
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
                objInBuiltData.ErrorHandling("ERROR", "ManageCalAddOns.aspx.cs", "ConvertHTMLtoImage", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void ShowGoogleSyncDate()
        {
            /***** Display Last Sync Date *****/
            EventCalendarBLL objEvents = new EventCalendarBLL();
            DateTime lastSyncDate = objEvents.GetLastSyncDate(UserID);
            DateTime strDate = Convert.ToDateTime("01/01/0001");
            if (lastSyncDate.ToShortDateString() != strDate.ToShortDateString())
                lblLastSyncDate.Text = "<font face=arial size=2>" + Resources.LabelMessages.LastSyncDate + lastSyncDate.ToString("MM/dd/yyyy hh:mm tt") + "</font>";
        }
        private void DisplaySyncButtons()
        {
            EventCalendarBLL objEventCalendar = new EventCalendarBLL();
            bool SyncOn = true;
            DataTable Data_GoogleEvents = objEventCalendar.CheckForGoogleEvents(ProfileID);
            if (Data_GoogleEvents.Rows.Count != 0)
            {
                if (Convert.ToBoolean(Data_GoogleEvents.Rows[0]["Sync"].ToString()) == true)
                    SyncOn = false;
            }
            btnSyncOn.Visible = SyncOn;
            btnSyncOff.Visible = SyncOn ? false : true;
        }
        protected void GrdEvents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblcam = e.Row.FindControl("lblcam") as Label;
                LinkButton lnkcam = e.Row.FindControl("lnkruncampaion") as LinkButton;
                Label lblupdatethub = e.Row.FindControl("lblupdatethub") as Label;
                string UpdateID = lnkcam.CommandArgument;
                string ImageDisID = Guid.NewGuid().ToString();
                string file = lblupdatethub.Text == "" ? UpdateID : lblupdatethub.Text;
                if (File.Exists(Server.MapPath("~") + "\\Upload\\CalendarAddOns\\" + ProfileID.ToString() + "\\" + file + ".jpg"))
                    lblupdatethub.Text = "<img src='" + RootPath + "/Upload/CalendarAddOns/" + ProfileID.ToString() + "/" + file + ".jpg?Guid=" + ImageDisID + "' border='0' width='100' height='50'/>";
                else
                    lblupdatethub.Text = "";

                if (e.Row.Cells[5].Text.Contains("12:00 AM") || e.Row.Cells[5].Text.Contains("00:00"))
                    e.Row.Cells[5].Text = Convert.ToDateTime(e.Row.Cells[5].Text).ToString("MM/dd/yyyy");
                if (e.Row.Cells[6].Text.Contains("12:00 AM") || e.Row.Cells[6].Text.Contains("0:00 AM"))
                    e.Row.Cells[6].Text = Convert.ToDateTime(e.Row.Cells[6].Text).ToString("MM/dd/yyyy");
                int SchCount = 0;
                SchCount = objCalendarAddOn.CheckCalendarCampaignCount(Convert.ToInt32(lnkcam.CommandArgument));
                if (SchCount > 0)
                {
                    lnkcam.Visible = true;
                }
                else
                {
                    lnkcam.Visible = false;
                }
                Label lblstatus = e.Row.FindControl("lblstatus") as Label;
                Label lnkStatus = e.Row.FindControl("lnkStatus") as Label;
                if (lblstatus.Text == "True")
                {
                    lnkStatus.Text = "Public";
                }
                else
                {
                    lnkStatus.Text = "Private";
                }
                if (lblcam.Text == "Work in Progress" || lblcam.Text == "Completed")
                {
                    lnkcam.Visible = false;
                    lblcam.Visible = true;
                }
                else
                {
                    lnkcam.Text = lblcam.Text;
                    lnkcam.Visible = true;
                    lblcam.Visible = false;
                }
                string strScript = "SelectDeSelectHeader(" + ((CheckBox)e.Row.Cells[2].FindControl("chkUpdate")).ClientID + ");";
                ((CheckBox)e.Row.Cells[2].FindControl("chkUpdate")).Attributes.Add("onclick", strScript);
            }
        }
        protected void GrdEvents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            hdnShowButtons.Value = "1"; ; // *** To show all buttons ex: Preview, edit etc. *** //
            hdnCommandArg.Value = "";

            GrdEvents.PageIndex = e.NewPageIndex;
            GrdEvents.DataSource = (DataTable)Session["DtEvents"];
            GrdEvents.DataBind();
        }
        protected void GrdEvents_Sorting(object sender, GridViewSortEventArgs e)
        {
            trUnPublish.Visible = trPublish.Visible = false;
            SortDir = Convert.ToInt32(hdnsortcount.Value);
            string SortExp = e.SortExpression.ToString();
            dtCalenderAddOn = (DataTable)Session["DtEvents"];

            if (hdnsortdire.Value != "")
            {
                if (hdnsortdire.Value != SortExp)
                {
                    hdnsortdire.Value = SortExp;
                    SortDir = 0;
                    hdnsortcount.Value = "0";
                }
            }
            else
            {
                hdnsortdire.Value = SortExp;
            }

            DataView Dv = new DataView(dtCalenderAddOn);
            if (SortDir == 0)
            {

                if (SortExp == "Name")
                {
                    Dv.Sort = "EventTitle desc";
                }
                else if (SortExp == "IsPublic")
                {
                    Dv.Sort = "IsDisplay desc";
                }
                else if (SortExp == "EventStartDate")
                {
                    Dv.Sort = "EventStartDate desc";
                }
                else if (SortExp == "EventEndDate")
                {
                    Dv.Sort = "EventEndDate desc";
                }
                else if (SortExp == "Status")
                {
                    Dv.Sort = "Sent_Flag desc";
                }
                else if (SortExp == "EventType")
                {
                    Dv.Sort = "Event_Type desc";
                }
                else if (SortExp == "Username")
                {
                    Dv.Sort = "Username desc";
                }
                else if (SortExp == "CreatedUsername")
                {
                    Dv.Sort = "CreatedUsername desc";
                }
                else if (SortExp == "ApproveReject")
                {
                    Dv.Sort = "CreatedUsername desc, Username desc";
                }
                hdnsortcount.Value = "1";
            }
            else
            {
                if (SortExp == "Name")
                {
                    Dv.Sort = "EventTitle asc";
                }
                else if (SortExp == "IsPublic")
                {
                    Dv.Sort = "IsDisplay asc";
                }
                else if (SortExp == "EventStartDate")
                {
                    Dv.Sort = "EventStartDate asc";
                }
                else if (SortExp == "EventEndDate")
                {
                    Dv.Sort = "EventEndDate asc";
                }
                else if (SortExp == "Status")
                {
                    Dv.Sort = "Sent_Flag asc";
                }
                else if (SortExp == "EventType")
                {
                    Dv.Sort = "Event_Type asc";
                }
                else if (SortExp == "Username")
                {
                    Dv.Sort = "Username ASC";
                }
                else if (SortExp == "CreatedUsername")
                {
                    Dv.Sort = "CreatedUsername ASC";
                }
                else if (SortExp == "ApproveReject")
                {
                    Dv.Sort = "CreatedUsername ASC, Username ASC";
                }
                hdnsortcount.Value = "0";
            }

            Session["DtEvents"] = Dv.ToTable();
            GrdEvents.DataSource = Dv;
            GrdEvents.DataBind();
        }
        protected void chkEventID_CheckedChanged(object sender, EventArgs e)
        {
            hdnIsPusblished.Value = "";
            trUnPublish.Visible = trPublish.Visible = true;
            CheckBox rb = (CheckBox)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            LinkButton lnk = (LinkButton)row.FindControl("lnkEventName");
            LinkButton lnkcamp = (LinkButton)row.FindControl("lnkruncampaion");
            Label lblisCompleted = (Label)row.FindControl("lblisCompleted");
            Label lnkStatus = (Label)row.FindControl("lnkStatus");
            var expiryDate = Convert.ToString(GrdEvents.DataKeys[Convert.ToInt32(row.RowIndex)].Values["Expiration_Date"].ToString());

            if (lnkcamp.Visible == true)
            {
                if (lnkcamp.Text == "Scheduled" || lnkcamp.Text == "Sending")
                    CancelCamp.Visible = true;
                else
                    CancelCamp.Visible = false;
            }
            else
            {
                CancelCamp.Visible = false;
            }
            hdnCommandArg.Value = lnk.CommandArgument;

            // Selected Checkbox details for Preview, Edit, Copy, Send Mail
            foreach (GridViewRow row1 in GrdEvents.Rows)
            {
                if (((CheckBox)row1.FindControl("chkCurrentTabEventID")).Checked)
                {
                    hdnCommandArg.Value = (((LinkButton)row1.FindControl("lnkEventName")).CommandArgument);
                    lnk = (((LinkButton)row1.FindControl("lnkEventName")));
                    expiryDate = Convert.ToString(GrdEvents.DataKeys[Convert.ToInt32(row1.RowIndex)].Values["Expiration_Date"].ToString());
                    break;
                }
            }

            hdnEventTitle.Value = lnk.Text;
            GetSharestrings(Convert.ToInt32(hdnCommandArg.Value), lnk.Text);
            trShareOn1.Visible = true;
            if (lblisCompleted.Text == "True")
                hdnIsPusblished.Value = "true";
            if (expiryDate != string.Empty)
            {
                if (Convert.ToDateTime(expiryDate) < DateTime.Now)
                {
                    lblerrormessage.Text = "Expired item is not allowed to publish.";
                }
            }
        }
        protected string GetSharestrings(int UpdateID, string Update_title)
        {
            GetAutoShareRecordStatus(UpdateID, Update_title);
            #region Sharelinks with Facebook, LinkedIn, Twitter and Email
            articleTitle = Update_title.ToString();
            articleSummary = Update_title.ToString();
            string description = Update_title;
            description = objCommon.GetSocialDescription(description);
            description = objCommon.ReplaceShortURltoHtmlString(description);
            string redirecturl = RootPath + "/printevents.aspx?CalId=1&EID=" + EncryptDecrypt.DESEncrypt(UpdateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
            redirecturl = objCommon.longurlToshorturl(redirecturl);
            //Facebook     
            string tweetDesc = description.Replace("#", "");
            if ((description.Length + redirecturl.Length) > 137)
            {
                tweetDesc = description.Substring(0, 140 - (redirecturl.Length + 3)).Replace("#", "");
            }
            hdnLinkShareFB.Value = "";
            hdnLinkShareFB.Value = redirecturl;
            hdnMessageDes.Value = "";
            hdnMessageDes.Value = description;
            txtFacebookdes.Text = description;
            FacebookInurlinfo = "<a href='javascript:Display_FB_Popup()'><img src='../../images/Dashboard/facebooknew.gif' alt='Share on Facebook' width='55' height='36' title='Share on Facebook' border='0' /></a>";
            lblFacebookShare.Text = FacebookInurlinfo;


            //Pinterest
            string PinterestUrl = "http://pinterest.com/pin/create/button/?url=" + RootPath + "/printevents.aspx?CalId=1&EID=" + EncryptDecrypt.DESEncrypt(UpdateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&media=" + RootPath + "/Images/VerticalLogos/" + DomainName + "logo.png&description=" + tweetDesc;
            string PinterestUrlshare = "<a count-layout='horizontal' href='" + PinterestUrl + "'  target='_blank'><img border='0' src='../../images/Dashboard/PinterestLogo.gif' title='Pin It' alt='Share on Pinterest' width='55' height='36' /></a>";
            lblPinShare.Text = PinterestUrlshare;
            //Pinterest

            //***************** Commented by Suneel(Updates sharing via Linkedin)******************//
            //LinkedIN
            string update = EncryptDecrypt.DESEncrypt(UpdateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
            string articleUrl1 = RootPath + "/printevents.aspx?CalId=1&EID=" + update;
            string articleSource = RootPath;


            //Twitter
            string Twitterurlinfo1 = "http://www.twitter.com/share?url=" + redirecturl + "&text=" + tweetDesc;
            Twitterurlinfo = "<a href='javascript:void(0);' onclick='TwitterShare(\"" + Twitterurlinfo1 + "\");' title='Click to share this post on Twitter'><img src='../../images/Dashboard/twitternew.gif' alt='Share on Twitter' title='Share on Twitter' border='0' width='39' height='38'/></a>";

            //Twitter

            //Mail TO Url
            string ur = RootPath + "/printevents.aspx?CalId=1&EID=" + EncryptDecrypt.DESEncrypt(UpdateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
            string url = RootPath + "/Business/Myaccount/ShareEmail.aspx?CA=" + EncryptDecrypt.DESEncrypt(UpdateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
            Mailtourlinfo = "<a href=\"javascript:openEmailwindow('" + url + "')\"><img src='../../images/Dashboard/emailnew.gif' title='Share on Email' width='30' height='38' alt='Share on Email'/></a>";
            lblEmailShare.Text = Mailtourlinfo;
            //Mail TO Url
            string returunurl = Mailtourlinfo + FacebookInurlinfo + Twitterurlinfo + linkedInurlinfo;
            return returunurl;
            #endregion
        }
        private void GetAutoShareRecordStatus(int calendarId, string eventTitle)
        {
            DataTable dtobj = new DataTable();
            dtobj = objCalendarAddOn.GetCalendarAddOnDetails(calendarId);
            if (dtobj.Rows.Count > 0)
                eventTitle = dtobj.Rows[0]["EventTitle"].ToString();

            DataTable dtShareRecords = objCommon.CheckAutoShareRecordExists(WebConstants.Tab_CalendarAddOns, calendarId, eventTitle);
            for (int i = 0; i < dtShareRecords.Rows.Count; i++)
            {
                if (Convert.ToString(dtShareRecords.Rows[i]["Media_TYPE"]) == "Facebook")
                    hdnFacebook.Value = "false";

                if (Convert.ToString(dtShareRecords.Rows[i]["Media_TYPE"]) == "Twitter")
                    hdnTwitter.Value = "false";
            }
        }
        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CancelCamp.Visible = false;
        }
        protected void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            int SelectCount = 0;
            //Identify CheckBox is checked or not
            foreach (GridViewRow grdrow in GrdEvents.Rows)
            {
                if (((CheckBox)grdrow.FindControl("chkUpdate")).Checked)
                {
                    SelectCount = SelectCount + 1;
                    LinkButton lnkname = (LinkButton)grdrow.FindControl("lnkEventName");
                    if (SelectCount == 1)
                    {
                        LinkButton lnkcamp = (LinkButton)grdrow.FindControl("lnkruncampaion");
                        hdnCommandArg.Value = lnkname.CommandArgument;
                        if (lnkcamp.Visible == true)
                        {
                            if (lnkcamp.Text == "Scheduled" || lnkcamp.Text == "Sending")
                                CancelCamp.Visible = true;
                            else
                                CancelCamp.Visible = false;
                        }
                        else
                        {
                            CancelCamp.Visible = false;
                        }
                    }
                    else
                    {
                        hdnCommandArg.Value = "";
                        CancelCamp.Visible = false;
                    }
                }
                else
                {
                    LinkButton lnkcamp = (LinkButton)grdrow.FindControl("lnkruncampaion");
                    if (lnkcamp.Visible == true)
                    {
                        if (SelectCount > 1 || SelectCount == 0)
                        {
                            hdnCommandArg.Value = "";
                            CancelCamp.Visible = false;
                        }
                    }
                }
            }

        }
        protected void lnkUpdateName_Click(object sender, EventArgs e)
        {
            LinkButton lnkdetails = sender as LinkButton;
            ShowPreviewHTML(Convert.ToInt32(lnkdetails.CommandArgument));
        }
        private void ShowPreviewHTML(int calendarId)
        {
            string PreviewHTML = string.Empty;
            string UnUsbscribeLink = string.Empty;
            DataTable DtCalendarDetails = new DataTable();
            string EventTitle = string.Empty;
            string dtEventStartDate = string.Empty;
            string dtEventEndDate = string.Empty;
            DtCalendarDetails = objCalendarAddOn.GetCalendarAddOnDetails(calendarId);
            if (DtCalendarDetails.Rows.Count > 0)
            {
                PreviewHTML = DtCalendarDetails.Rows[0]["EventDesc"].ToString();
                string fullDate = objCommon.GetEventAdjustDate(Convert.ToDateTime(DtCalendarDetails.Rows[0]["EventStartDate"].ToString()), Convert.ToDateTime(DtCalendarDetails.Rows[0]["EventEndDate"].ToString()));

                UnUsbscribeLink = UserProfileUnsubscribeLink();
                PreviewHTML = "<html><head></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='border: solid 2px #F4EBEB;'>  <tr><td colspan='2' style='padding:10px;'>" + fullDate + "</td></tr><tr><td colspan='2' style='padding:20px;'>" + PreviewHTML + "</td></tr></table></body></html>";

                lblPreviewHTML.Text = PreviewHTML;
                lblupdatename.Text = DtCalendarDetails.Rows[0]["EventTitle"].ToString();
                ModalPopupExtender2.Show();
            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>LoadEventForPlayVideo()</script>", false);
        }
        private string UserProfileUnsubscribeLink()
        {
            BusinessBLL ObjBus = new BusinessBLL();
            DataTable DtProfileAddress = new DataTable();
            DtProfileAddress = ObjBus.GetProfileDetailsByProfileID(ProfileID);
            string TotalAddress = string.Empty;
            string UnSubscribeLinkText = string.Empty;
            string ProfileName = string.Empty;
            if (DtProfileAddress.Rows.Count > 0)
            {
                if (DtProfileAddress.Rows[0]["Profile_name"].ToString() != "")
                {
                    ProfileName = DtProfileAddress.Rows[0]["Profile_name"].ToString();
                }
                if (DtProfileAddress.Rows[0]["Profile_StreetAddress1"].ToString() != "")
                {
                    TotalAddress = DtProfileAddress.Rows[0]["Profile_StreetAddress1"].ToString();
                }
                if (DtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString() != "")
                {
                    if (TotalAddress != "")
                    {
                        TotalAddress = TotalAddress + ", " + DtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString();
                    }
                    else
                    {
                        TotalAddress = DtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString();
                    }
                }
                if (DtProfileAddress.Rows[0]["Profile_City"].ToString() != "")
                {
                    if (TotalAddress != "")
                    {
                        TotalAddress = TotalAddress + ", " + DtProfileAddress.Rows[0]["Profile_City"].ToString();
                    }
                    else
                    {
                        TotalAddress = DtProfileAddress.Rows[0]["Profile_City"].ToString();
                    }
                }
                if (DtProfileAddress.Rows[0]["Profile_State"].ToString() != "")
                {
                    if (TotalAddress != "")
                    {
                        TotalAddress = TotalAddress + ", " + DtProfileAddress.Rows[0]["Profile_State"].ToString();
                    }
                    else
                    {
                        TotalAddress = DtProfileAddress.Rows[0]["Profile_State"].ToString();
                    }
                }
                if (DtProfileAddress.Rows[0]["Profile_Zipcode"].ToString() != "")
                {
                    if (TotalAddress != "")
                    {
                        TotalAddress = TotalAddress + ", " + DtProfileAddress.Rows[0]["Profile_Zipcode"].ToString();
                    }
                    else
                    {
                        TotalAddress = DtProfileAddress.Rows[0]["Profile_Zipcode"].ToString();
                    }
                }
            }
            UnSubscribeLinkText = "This message was sent by " + ProfileName + " to &#60;recipient's email address&#62;. It was sent from &#60; sender's email address&#62;" + TotalAddress + ". If you no longer wish to receive our events, <a href='" + RootPath + "/UnsubscribeCalendar.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "' target='_blank'>click here</a> to unsubscribe.";
            return UnSubscribeLinkText;
        }
        protected void lblhistroy_Click(object sender, EventArgs e)
        {
            LinkButton lnkHis = sender as LinkButton;
            DtHis = objCalendarAddOn.GetScheduledItemsByCalendarId(Convert.ToInt32(lnkHis.CommandArgument));
            if (DtHis.Rows.Count > 0)
            {
                grdviewsenthis.PageIndex = 0;
                grdviewsenthis.DataSource = DtHis;
                grdviewsenthis.DataBind();

                DataTable dtCalendarAddon = new DataTable();
                dtCalendarAddon = objCalendarAddOn.GetCalendarAddOnDetails(Convert.ToInt32(lnkHis.CommandArgument));
                if (dtCalendarAddon.Rows.Count > 0)
                {
                    lblviewsentnewlettername.Text = dtCalendarAddon.Rows[0]["EventTitle"].ToString();
                }
                ModalPopupExtender3.Show();
            }
        }
        protected void grdviewsenthis_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblstatus = e.Row.FindControl("Label2") as Label;
                if (lblstatus.Text == "1")
                {
                    lblstatus.Text = "Sent";
                }
                else if (lblstatus.Text == "0")
                {
                    lblstatus.Text = "Scheduled";
                }
                else if (lblstatus.Text == "2")
                {
                    lblstatus.Text = "Cancel";
                }
            }
        }
        protected void grdviewsenthis_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdviewsenthis.PageIndex = e.NewPageIndex;
            grdviewsenthis.DataSource = DtHis;
            grdviewsenthis.DataBind();
            ModalPopupExtender3.Show();
        }
        protected void grdviewsenthis_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
        protected void lnkCreate_Click(object sender, EventArgs e)
        {
            string url = "";
            List<string> PermissionList = new List<string>();
            string ModuleName = string.Empty;
            string authorPermission = string.Empty;
            string pubPermission = string.Empty;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                //dtpermissions = objAgency.GetPermissionsById(Convert.ToInt32(Session["C_USER_ID"]));                
                dtpermissions = objAgency.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                DataTable dtAddOn = objAddOn.GetAddOnById(CalendarAddOnID);
                if (dtAddOn.Rows.Count == 1)
                    ModuleName = dtAddOn.Rows[0]["TabName"].ToString();
                for (int i = 0; i < dtpermissions.Rows.Count; i++)
                {
                    if (dtpermissions.Rows[i]["ModuleName"].ToString() == ModuleName)
                    {
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                            authorPermission = "A";
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                            pubPermission = "P";
                        break;
                    }
                }
                if ((authorPermission == "A") || (authorPermission == "A" && pubPermission == "P"))
                {
                    url = Page.ResolveClientUrl("~/Business/MyAccount/CAEventsCalendar.aspx");
                    if (btnBack.Visible)
                        url = Page.ResolveClientUrl("~/Business/MyAccount/CAEventsCalendar.aspx?App=1");
                    Response.Redirect(url);
                }
                else
                {
                    lblmess.Text = "You don't have permission to create an item.";
                }
            }
            else
            {
                url = Page.ResolveClientUrl("~/Business/MyAccount/CAEventsCalendar.aspx");
                if (btnBack.Visible)
                    url = Page.ResolveClientUrl("~/Business/MyAccount/CAEventsCalendar.aspx?App=1");
                Response.Redirect(url);
            }
            PermissionList.Clear();
        }
        protected void lnkPreviewCalendar_Click(object sender, EventArgs e)
        {
            BusinessBLL Busobj = new BusinessBLL();
            string CSS = string.Empty;
            string URL = string.Empty;
            URL = RootPath + "/ProfileIframes/UserActions.aspx?CalId=1&PID=" + ProfileID + "&Svalue=10";
            Iframeevent.Attributes["src"] = URL;

            CSS = ConfigurationManager.AppSettings.Get("Template1");
            DataTable dtConfigPageKeys = objCommon.GetVerticalConfigsByType(DomainName, WebConstants.Tab_EventCalendar);
            if (dtConfigPageKeys.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigPageKeys.Rows)
                {
                    if (row[0].ToString() == "PopCss")
                    {
                        CSS = row[1].ToString();
                        break;
                    }
                }
            }
            pnlpopup.Attributes.Add("style", CSS);
            ModalPopupExtender1.Show();
        }
        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            LinkButton lnkdetails = sender as LinkButton;
            ShowPreviewHTML(Convert.ToInt32(hdnCommandArg.Value));
        }
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            List<string> PermissionList = new List<string>();
            string ModuleName = string.Empty;
            string authorPermission = string.Empty;
            string pubPermission = string.Empty;
            if (Session["C_USER_ID"] != null && Convert.ToString(Session["C_USER_ID"]) != "")
            {
                dtpermissions = objAgency.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                DataTable dtAddOn = objAddOn.GetAddOnById(CalendarAddOnID);
                if (dtAddOn.Rows.Count == 1)
                    ModuleName = dtAddOn.Rows[0]["TabName"].ToString();
                for (int i = 0; i < dtpermissions.Rows.Count; i++)
                {
                    if (dtpermissions.Rows[i]["ModuleName"].ToString() == ModuleName)
                    {
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                            authorPermission = "A";
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                            pubPermission = "P";
                        break;
                    }
                }
                if (authorPermission == "A" || (authorPermission == "A" && pubPermission == "P"))
                {
                    EditEvent();
                }
                else
                    lblmess.Text = "You don't have permission to edit an item.";
            }
            else
                EditEvent();
            PermissionList.Clear();
        }
        private void EditEvent()
        {
            if (hdnCommandArg.Value != "")
            {
                int calendarId = Convert.ToInt32(hdnCommandArg.Value);
                dtobj = objCalendarAddOn.GetCalendarAddOnDetails(calendarId);
                if (dtobj.Rows[0]["EventType"].ToString() != "Google")
                {
                    DataTable DtChekHis = objCalendarAddOn.GetScheduledItemsByCalendarId(calendarId);
                    DataRow[] rows = DtChekHis.Select("Sent_Flag=0");
                    if (rows.Length > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(lnkEdit, this.GetType(), "JavaScrtiptAlert", "javascript: fnShowMessage(" + calendarId + ");", true);
                    }
                    else
                    {
                        string url = Page.ResolveClientUrl("~/Business/MyAccount/CAEventsCalendar.aspx?CalId=" + calendarId);
                        if (btnBack.Visible)
                            url = Page.ResolveClientUrl("~/Business/MyAccount/CAEventsCalendar.aspx?CalId=" + calendarId + "&App=1");
                        Response.Redirect(url);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You cannot edit a google event.')", true);
                }
            }
        }
        protected void lnkCopy_Click(object sender, EventArgs e)
        {
            CopyEventCalendar();
        }
        private void CopyEventCalendar()
        {
            if (hdnCommandArg.Value != "")
            {
                if (File.Exists(Server.MapPath("~") + "\\Upload\\CalendarAddOns\\" + ProfileID.ToString() + "\\" + hdnCommandArg.Value + ".jpg"))
                    lblFlyerimage.Text = "<img src='" + RootPath + "/Upload/CalendarAddOns/" + ProfileID.ToString() + "/" + hdnCommandArg.Value + ".jpg' border='1' width='350' height='350'/>";
                else
                    lblFlyerimage.Text = "<font size='3' weight='bold'>No Thumbnail</font>";
            }
            else
                lblFlyerimage.Text = "<font size='3' weight='bold'>No Thumbnail</font>";
            ModalPopupExtender4.Show();
        }
        protected void btneditcancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender4.Hide();
        }
        protected void BtneditTemplate_Click(object sender, EventArgs e)
        {
            int calendarId = Convert.ToInt32(hdnCommandArg.Value);
            DataTable dtobj = new DataTable();
            dtobj = objCalendarAddOn.GetCalendarAddOnDetails(calendarId);
            int? publishedby = null;
            DateTime? publisheddate = null;
            string eventTitle = txteventname.Text.Trim();
            string eventDesc = dtobj.Rows[0]["EventDesc"].ToString();
            string startdate = Convert.ToDateTime(dtobj.Rows[0]["EventStartDate"]).ToString();
            string enddate = Convert.ToDateTime(dtobj.Rows[0]["EventEndDate"]).ToString();
            string EditHTML = Convert.ToString(dtobj.Rows[0]["Edit_HTML"]);
            string ListDescription = Convert.ToString(dtobj.Rows[0]["List_Description"]);

            bool isCall = false;
            bool isContatUs = false;
            bool isRepeat = false;
            if (!string.IsNullOrEmpty(dtobj.Rows[0]["IsCall"].ToString()))
                isCall = Convert.ToBoolean(dtobj.Rows[0]["IsCall"]);
            if (!string.IsNullOrEmpty(dtobj.Rows[0]["IsContactUs"].ToString()))
                isContatUs = Convert.ToBoolean(dtobj.Rows[0]["IsContactUs"]);
            if (!string.IsNullOrEmpty(dtobj.Rows[0]["IsRepeat"].ToString()))
                isRepeat = Convert.ToBoolean(dtobj.Rows[0]["IsRepeat"]);
            DateTime? ExDate;
            ExDate = null;
            if (Convert.ToString(dtobj.Rows[0]["Expiration_Date"]) != string.Empty)
            {
                ExDate = Convert.ToDateTime(dtobj.Rows[0]["Expiration_Date"]);
            }

            string NewName = string.Empty;
            string OldName = string.Empty;

            //old event id name
            OldName = calendarId + ".jpg";

            calendarId = objCalendarAddOn.InsertCalendarAddOnDetails(0, ProfileID, UserID, eventTitle, eventDesc, startdate, enddate, C_UserID, isCall, isContatUs, false, EditHTML,
                ListDescription, false, publishedby, publisheddate, ExDate, isRepeat, null, CalendarAddOnID);

            // Save User Activity Log
            objCommon.InsertUserActivityLog("has created an event titled <b>" + eventTitle + "</b> by copying <b>" + hdnEventTitle.Value + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);


            //new event id name
            NewName = calendarId + ".jpg";

            string OldTemplatePath = string.Empty;
            string NewTemplatePath = string.Empty;

            OldTemplatePath = (Server.MapPath("~") + "\\Upload\\CalendarAddOns\\" + Session["ProfileID"].ToString() + "\\" + OldName);
            NewTemplatePath = (Server.MapPath("~") + "\\Upload\\CalendarAddOns\\" + Session["ProfileID"].ToString() + "\\" + NewName);

            if (File.Exists(OldTemplatePath))
            {
                File.Copy(OldTemplatePath, NewTemplatePath, true);
            }
            string url = Page.ResolveClientUrl("~/Business/MyAccount/CAEventsCalendar.aspx?CalId=" + calendarId);
            if (btnBack.Visible)
                url = Page.ResolveClientUrl("~/Business/MyAccount/CAEventsCalendar.aspx?CalId=" + calendarId + "&App=1");
            Response.Redirect(url);
        }
        protected void lnkRename_Click(object sender, EventArgs e)
        {
            RenameContent();
        }
        private void RenameContent()
        {
            lblExisting.Text = "";
            lblRenameMsg.Text = "";
            lblRenameImage.Text = "";
            if (hdnCommandArg.Value != "")
            {
                DataTable dtEvent = objCalendarAddOn.GetCalendarAddOnDetails(Convert.ToInt32(hdnCommandArg.Value));
                if (dtEvent.Rows.Count > 0)
                {
                    lblExisting.Text = Convert.ToString(dtEvent.Rows[0]["EventTitle"]);
                }
                if (File.Exists(Server.MapPath("~") + "\\Upload\\CalendarAddOns\\" + ProfileID.ToString() + "\\" + hdnCommandArg.Value + ".jpg"))
                    lblRenameImage.Text = "<img src='" + RootPath + "/Upload/CalendarAddOns/" + ProfileID.ToString() + "/" + hdnCommandArg.Value + ".jpg' border='1' width='350' height='350'/>";
                else
                    lblRenameImage.Text = "<font size='3' weight='bold'>No Thumbnail</font>";
                modalRename.Show();
                txtNewName.Text = "";
            }
        }
        protected void btnRenameCancel_Click(object sender, EventArgs e)
        {
            modalRename.Hide();
        }
        protected void btnRenameBulletin_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnCommandArg.Value != "")
                {
                    BulletinBLL objBulletin = new BulletinBLL();
                    objBulletin.RenameContent(Convert.ToInt32(hdnCommandArg.Value), txtNewName.Text.Trim(), C_UserID, WebConstants.Tab_CalendarAddOns, ProfileID);
                    lblmess.Text = "<font color='Green' size='3'>" + Resources.LabelMessages.RenameSuccess.Replace("#ExistingContentName#", lblExisting.Text.Trim()).Replace("#NewContentName#", txtNewName.Text.Trim()) + "</font>";
                    FillDatalist();
                    modalRename.Hide();
                }
            }
            catch (Exception ex)
            {
                lblRenameMsg.Text = "<font color='red' size='3'>" + ex.Message.ToString() + "</font>";
            }
        }
        protected void lnkPublish_Click(object sender, EventArgs e)
        {
            List<string> PermissionList = new List<string>();
            string ModuleName = string.Empty;
            string authorPermission = string.Empty;
            string pubPermission = string.Empty;
            DataTable dtAddOn = objAddOn.GetAddOnById(CalendarAddOnID);
            if (dtAddOn.Rows.Count == 1)
                ModuleName = dtAddOn.Rows[0]["TabName"].ToString();
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                dtpermissions = objAgency.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                for (int i = 0; i < dtpermissions.Rows.Count; i++)
                {
                    if (dtpermissions.Rows[i]["ModuleName"].ToString() == ModuleName)
                    {
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                            authorPermission = "A";
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                            pubPermission = "P";
                        break;
                    }
                }
                if (pubPermission == "P" || (authorPermission == "A" && pubPermission == "P"))
                {
                    if (hdnCommandArg.Value != "")
                    {
                        ShowPublishModal();
                    }
                }
                else
                {
                    lblmess.Text = "You don't have permission to publish an item.";
                }
            }
            else
            {
                if (hdnCommandArg.Value != "")
                {
                    ShowPublishModal();
                }
            }
            PermissionList.Clear();
        }
        private void ShowPublishModal()
        {
            txtPublishDate.Text = objCommon.ConvertToUserTimeZone(ProfileID).ToString("MM/dd/yyyy");
            ModalPopupPublish.Show();
        }
        protected void btnPublish_Click(object sender, EventArgs e)
        {

            bool flag = false;
            DateTime? datePublish;
            if (txtPublishDate.Text.Trim() != "")
            {
                DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), Convert.ToDateTime(dtToday.ToShortDateString())) < 0)
                {
                    lblPublishError.Text = "<font size='2' color='red'>" + Resources.LabelMessages.PublishDateAlert + "</font>";
                    ModalPopupPublish.Show();
                }
                else
                    flag = true;
            }
            if (flag)
            {
                foreach (GridViewRow row in GrdEvents.Rows)
                {
                    if (((CheckBox)row.FindControl("chkCurrentTabEventID")).Checked)
                    {
                        hdnCommandArg.Value = ((LinkButton)(GrdEvents.Rows[row.RowIndex].FindControl("lnkEventName"))).CommandArgument;

                        //roles & permissions..
                        if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "" && hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))  // A for approve...
                        {
                            UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), false);
                            objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.CALENDARADDON, UserID, Session["username"].ToString(), PageNames.CALENDARADDON, DomainName);
                        }
                        else
                            UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), true);
                        //ends here...
                    }
                } // EnD foreach

                hdnCommandArg.Value = "";
                lblmess.Text = Resources.LabelMessages.PublishStatusChange.Replace("#Type#", "event").Replace("#Status#", "published");
                FillDatalist();
                ModalPopupPublish.Hide();
            }

        }
        protected void btnPublishCancel_Click(object sender, EventArgs e)
        {
            ModalPopupPublish.Hide();
        }
        private void UpdatePublish(bool flag, int calendarId, DateTime? PublishDate, bool IsPublished)
        {
            objCalendarAddOn.UpdateCalendarPublish(flag, UserID, C_UserID, calendarId, PublishDate, IsPublished);
        }
        protected void lnkUnpublish_Click(object sender, EventArgs e)
        {
            if (hdnCommandArg.Value != "")
            {
                DateTime? PublishDate = null;
                //Identify CheckBox is checked or not
                foreach (GridViewRow row in GrdEvents.Rows)
                {
                    if (((CheckBox)row.FindControl("chkCurrentTabEventID")).Checked)
                    {
                        hdnCommandArg.Value = ((LinkButton)(GrdEvents.Rows[row.RowIndex].FindControl("lnkEventName"))).CommandArgument;
                        UpdatePublish(false, Convert.ToInt32(hdnCommandArg.Value), PublishDate, false);
                    }
                }//END foreach

                lblmess.Text = Resources.LabelMessages.PublishStatusChange.Replace("#Type#", "event").Replace("#Status#", "private");
                FillDatalist();
            }
        }
        protected void lnkNotification_Click(object sender, EventArgs e)
        {
            Session["PushNotifyType"] = WebConstants.Tab_CalendarAddOns + "," + hdnCommandArg.Value;
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SendAppNotifications.aspx"));
        }
        protected void lnkdelete_Click(object sender, EventArgs e)
        {
            int scheduledCount = 0;
            int calendarId = 0;
            if (hdnarchive.Value != "Archive")
            {
                foreach (GridViewRow row1 in GrdEvents.Rows)
                {
                    if (((CheckBox)row1.FindControl("chkCurrentTabEventID")).Checked)
                    {
                        hdnCommandArg.Value = (((LinkButton)row1.FindControl("lnkEventName")).CommandArgument);
                        calendarId = Convert.ToInt32(hdnCommandArg.Value);
                        int CountCampaign = objCalendarAddOn.CheckCalendarCampaignCount(Convert.ToInt32(hdnCommandArg.Value));

                        // Save User Activity Log
                        objCommon.InsertUserActivityLog("has deleted an event named <b>" + hdnEventTitle.Value + "</b> from the Events", string.Empty, UserID, ProfileID, DateTime.Now, UserID);

                        if (CountCampaign == 0)
                        {
                            objCalendarAddOn.DeleteCalendarById(calendarId);
                            FillDatalist();
                            lblmess.Text = "<font  color='red'>Your selection(s) have been deleted successfully.</font>";
                        }
                        else
                        {
                            string MaxSchDate = string.Empty;
                            MaxSchDate = objCalendarAddOn.GetCalendarMaxScheduledDate(UserID);
                            MaxSchDate = MaxSchDate.Replace("12:00:00 AM", "");
                            lblmess.Text = "<font color='green'>Sorry, you cannot delete your event now as you have a event scheduled till" + " " + MaxSchDate + ".</font>";
                        }
                    }
                }
            }
            else
            {
                scheduledCount = 0;
                //Identify CheckBox is checked or not
                foreach (GridViewRow row in GrdEvents.Rows)
                {
                    if (((CheckBox)row.FindControl("chkUpdate")).Checked)
                    {

                        calendarId = int.Parse(((LinkButton)(GrdEvents.Rows[row.RowIndex].FindControl("lnkEventName"))).CommandArgument);
                        int CountCampaign = objCalendarAddOn.CheckCalendarCampaignCount(calendarId);

                        #region Save User Activity Log

                        var title = ((LinkButton)(GrdEvents.Rows[row.RowIndex].FindControl("lnkEventName"))).Text;
                        objCommon.InsertUserActivityLog("has deleted an event named <b>" + title + "</b> from the Events", string.Empty, UserID, ProfileID, DateTime.Now, UserID);

                        #endregion

                        if (CountCampaign == 0)
                        {
                            objCalendarAddOn.DeleteCalendarById(calendarId);
                        }
                        else
                        {
                            scheduledCount = scheduledCount + 1;
                        }
                    }
                }
                if (scheduledCount > 0)
                {
                    lblmess.Text = "<font  color='red'>Your selection(s) have been deleted successfully except the ones that are being scheduled.</font>";
                }
                else
                {
                    lblmess.Text = "<font  color='red'>Your selection(s) have been deleted successfully.</font>";
                }
                CancelCamp.Visible = false;
                GrdEvents.PageIndex = 0;
                FillDatalist();
            }
        }
        protected void lnkSend_Click(object sender, EventArgs e)
        {
            int CheckSch = 0;

            CheckSch = objCalendarAddOn.CheckforCalendarSchedule(UserID);

            int CheckCam = 0;
            if (CheckSch > 0)
            {
                CheckCam = 1;
            }

            CheckSch = RemiangScheduleCount() - CheckSch;
            if (CheckSch > 0)
            {
                Session["CalendarId"] = null;
                Session["CalendarDes"] = null;
                int calendarId = 0;
                DataTable DtGetBusUpate = new DataTable();
                calendarId = Convert.ToInt32(hdnCommandArg.Value);
                DtGetBusUpate = objCalendarAddOn.GetCalendarAddOnDetails(calendarId);
                string BusinessUpdateDes = DtGetBusUpate.Rows[0]["EventDesc"].ToString();
                Session["CalendarId"] = calendarId.ToString();
                Session["CalendarDes"] = BusinessUpdateDes;
                if (hdnarchive.Value == "Archive")
                    Session["ViewGrid"] = hdnarchive.Value;
                string url = Page.ResolveClientUrl("~/Business/MyAccount/SendCalendar.aspx");
                if (btnBack.Visible)
                    url = Page.ResolveClientUrl("~/Business/MyAccount/SendCalendar.aspx?App=1");
                Response.Redirect(url);
            }
            else
            {
                if (CheckCam > 0)
                {
                    string MaxSchDate = string.Empty;
                    MaxSchDate = objCalendarAddOn.GetCalendarMaxScheduledDate(UserID);
                    MaxSchDate = MaxSchDate.Replace("12:00:00 AM", "");
                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.AlreadyHaveBusinessUpdateCampaign + " " + MaxSchDate + ".</font>";
                }
                else
                {
                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendaffiliatecountExceeded + "</font>";
                }
            }

        }
        protected void lnkArchive_Click(object sender, EventArgs e)
        {
            string controlID = "";
            bool ArchiveFlag = true;
            LinkButton lnkCurrArchive = sender as LinkButton;
            string lnkText = lnkCurrArchive.Text;
            if (hdnCommandArg.Value == "")
            {
                hdnCommandArg.Value = "0";
            }
            int ArchiveID = Convert.ToInt32(hdnCommandArg.Value);
            int CountCampaign = objCalendarAddOn.CheckCalendarCampaignCount(Convert.ToInt32(hdnCommandArg.Value));
            if (lnkText.Contains("Current"))
            {
                controlID = "chkUpdate";
                ArchiveFlag = false;
            }
            else
            {
                controlID = "chkCurrentTabEventID";
                ArchiveFlag = true;
            }

            if (CountCampaign == 0)
            {
                //Identify CheckBox is checked or not
                foreach (GridViewRow row in GrdEvents.Rows)
                {
                    if (((CheckBox)row.FindControl(controlID)).Checked)
                    {
                        ArchiveID = Convert.ToInt32(((LinkButton)(GrdEvents.Rows[row.RowIndex].FindControl("lnkEventName"))).CommandArgument);
                        objCommon.ArchiveSelectedNewsletter(ArchiveID, ArchiveFlag, WebConstants.Tab_CalendarAddOns, C_UserID);
                    }
                }

                if (ArchiveFlag == false)
                    lblmess.Text = "Your selected items(s) has been reinstated successfully.";
                else
                    lblmess.Text = "Your selected items(s) has been archived successfully.";
                FillDatalist();
            }
            else
            {
                string MaxSchDate = string.Empty;
                MaxSchDate = objCalendarAddOn.GetCalendarMaxScheduledDate(UserID);
                MaxSchDate = MaxSchDate.Replace("12:00:00 AM", "");
                if (ArchiveFlag == false)
                    lblmess.Text = (Resources.LabelMessages.ArchiveSchedulenewsletter).Replace("flyer", "item").Replace("archive", "reinstate");
                else
                    lblmess.Text = (Resources.LabelMessages.ArchiveSchedulenewsletter).Replace("flyer", "item");
            }
        }
        protected void lnkCancelCamp_Click(object sender, EventArgs e)
        {
            LinkButton lnkrun = sender as LinkButton;
            dtCampaign = objCalendarAddOn.GetCalendarCampaignByDates(Convert.ToInt32(hdnCommandArg.Value));
            Session["dtCampaign"] = dtCampaign;
            lblp.Text = hdnCommandArg.Value;
            if (dtCampaign.Rows.Count > 0)
            {
                CancelCampaign.Visible = true;

                grdschemail.PageIndex = 0;
                grdschemail.DataSource = dtCampaign;
                grdschemail.DataBind();

                ModalPopupExtender5.Show();
            }
        }
        protected void grdschemail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbldate = e.Row.FindControl("lblscheduleddate") as Label;
                Label lblCount = e.Row.FindControl("Label4") as Label;
                Label lblstatus = e.Row.FindControl("Label6") as Label;
                if (lblstatus.Text == "1")
                {
                    lblstatus.Text = "Sent";
                }
                else if (lblstatus.Text == "0")
                {
                    lblstatus.Text = "Scheduled";
                }
                else if (lblstatus.Text == "2")
                {
                    lblstatus.Text = "Cancel";
                }
                int Count = 0;
                Count = objCalendarAddOn.GetCalendarCountForSendingDate(UserID, Convert.ToDateTime(lbldate.Text), Convert.ToInt32(lblp.Text));
                lblCount.Text = Count.ToString();
            }
        }
        protected void grdschemail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdschemail.PageIndex = e.NewPageIndex;
            grdschemail.DataSource = dtCampaign;
            grdschemail.DataBind();
            ModalPopupExtender5.Show();
        }
        protected void btnstopcampain_Click(object sender, EventArgs e)
        {
            CancelCamp.Visible = false;
            objCalendarAddOn.CancelCalendarCampaign(Convert.ToInt32(lblp.Text));
            FillDatalist();
            lblmess.Text = "<font color='green'>Your item campaign has been cancelled successfully.</font>";
        }
        protected void imclose_Click(object sender, ImageClickEventArgs e)
        {
        }
        protected void lnkReports_Click(object sender, EventArgs e)
        {
            string RedirectUrl = string.Empty;
            if (hdnarchive.Value == "Archive")
                RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/CAEventsReports.aspx?Flag=Archive");
            else
                RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/CAEventsReports.aspx?Flag=Current");
            if (btnBack.Visible)
                RedirectUrl = RedirectUrl + "&App=1";
            Response.Redirect(RedirectUrl);
        }
        private void GetFacebookAppDetails()
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
        protected void lnkTwrShare_Click(object sender, EventArgs e)
        {
            string description = string.Empty;
            string articleTitle = hdnEventTitle.Value.ToString();
            description = articleTitle;
            description = objCommon.GetSocialDescription(description);
            string redirecturl = RootPath + "/printevents.aspx?CalId=1&EID=" + EncryptDecrypt.DESEncrypt(Convert.ToInt32(hdnCommandArg.Value).ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
            redirecturl = objCommon.longurlToshorturl(redirecturl);
            string tweetDesc = description.Replace("#", "");
            Session["ContentID"] = hdnCommandArg.Value;
            if ((description.Length + redirecturl.Length) > 137)
            {
                tweetDesc = description.Substring(0, 140 - (redirecturl.Length + 3)).Replace("#", "");
            }
            DataTable dtTwitterUser = smb.GetTwitterDataByUserID(ProfileID);
            if (dtTwitterUser.Rows.Count > 0)
            {
                objCommon.InsertUpdateAutoShareDetails(WebConstants.Tab_CalendarAddOns, Convert.ToInt32(hdnCommandArg.Value), 0, DateTime.Now, "Twitter", UserID, C_UserID, articleTitle);
                lblmess.Text = "<font color='green'>Your selected item has been posted on twitter successfully.</font>";
            }
            else
            {
                string url = "http://www.twitter.com/share?url=" + redirecturl + "&text=" + tweetDesc;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + url + "', '_blank');", true);
                objCommon.InsertUpdateAutoShareDetails(WebConstants.Tab_CalendarAddOns, Convert.ToInt32(Session["ContentID"]), 1, DateTime.Now, "Twitter", UserID, C_UserID, articleTitle);// if user manually tweets inserting the record
                objCommon.UpdateSocialShareStatus(UserID, 1, "Twitter", Convert.ToInt32(hdnCommandArg.Value),1);//updating status flag for report
            }
        }
        protected void lnkShareBtn_Click(object sender, EventArgs e)
        {
            RemoveGoogleResponseCodeQueryStr();
            Session["ResponseCodeType"] = "FB";
            string description = string.Empty;
            string articleTitle = hdnEventTitle.Value.ToString();
            description = articleTitle;
            description = objCommon.GetSocialDescription(description);
            string redirecturl = RootPath + "/printevents.aspx?CalId=1&EID=" + EncryptDecrypt.DESEncrypt(Convert.ToInt32(hdnCommandArg.Value).ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
            redirecturl = objCommon.longurlToshorturl(redirecturl);
            //Facebook     
            string tweetDesc = description.Replace("#", "");
            Session["ContentID"] = hdnCommandArg.Value;
            if ((description.Length + redirecturl.Length) > 137)
            {
                tweetDesc = description.Substring(0, 140 - (redirecturl.Length + 3)).Replace("#", "");
            }

            DataTable dtExistingFbUsersData = smb.GetExistingUserData(ProfileID);
            if (dtExistingFbUsersData.Rows.Count > 0)
            {
                objCommon.InsertUpdateAutoShareDetails(WebConstants.Tab_CalendarAddOns, Convert.ToInt32(hdnCommandArg.Value), 0, DateTime.Now, "Facebook", UserID, C_UserID, articleTitle);
                lblmess.Text = "<font color='green'>Your selected item has been posted on facebook successfully.</font>";
            }
            else
            {
                Dictionary<string, object> args = new Dictionary<string, object>();
                args["message"] = tweetDesc;
                args["name"] = articleTitle;
                args["link"] = redirecturl;
                Session["PageContent"] = args;
                Response.Redirect("https://graph.facebook.com/oauth/authorize?client_id=" + appID + "&redirect_uri=" + RootPath + "/Business/MyAccount/" + WebConstants.ManageUrl_CalendarAddOns + "&scope=" + fbScope);
            }
        }
        private void ShareOnFacebook()
        {
            int pageCount = 0;
            Dictionary<string, string> tokens = new Dictionary<string, string>();
            try
            {
                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}", appID, RootPath + "/Business/MyAccount/" + WebConstants.ManageUrl_CalendarAddOns, fbScope, Request["code"].ToString(), appSecret);
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
                    lblmess.Text = "<font color='green'>There are no pages in your account.</font>";
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
                Response.Redirect(RootPath + "/Business/MyAccount/" + WebConstants.ManageUrl_CalendarAddOns);
            }
        }
        protected void btnShareOnPage_Click(object sender, EventArgs e)
        {
            RemoveGoogleResponseCodeQueryStr();
            Session["ResponseCodeType"] = "FB";
            ShareOnPage();
        }
        private void ShareOnPage()
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
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/" + WebConstants.ManageUrl_CalendarAddOns + "?fbStatus=1"));
            }
            else
            {
              Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/" + WebConstants.ManageUrl_CalendarAddOns + "?fbStatus=0"));
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
        private void ShowLoadMessages()
        {
            Session["HtmlText"] = null;

            if (Session["EventSend"] != null)
            {
                if (Session["EventSend"].ToString() != "")
                {
                    if (Session["EventSend"].ToString() == "1")
                    {
                        if (Session["CheckEventMess"] != null)
                        {
                            if (Session["CheckEventMess"].ToString() != "")
                            {
                                if (Session["CheckEventMess"].ToString() == "1")
                                {
                                    lblmess.Text = "<font color='green'>We could not send this event as there are no valid email ids.</font>";
                                }
                                else if (Session["CheckEventMess"].ToString() == "2")
                                {
                                    string invalidIds = string.Empty;
                                    if (Session["invalidEventEmailID"] != null)
                                    {
                                        if (Session["invalidEventEmailID"].ToString() != "")
                                        {
                                            invalidIds = Session["invalidEventEmailID"].ToString().ToString();
                                        }
                                        Session["invalidEventEmailID"] = null;
                                    }
                                    lblmess.Text = "<font color='green'>Item has been scheduled successfully except to the following ids as they appear to be invalid:</font><br>" + "<font color=#424242>" + invalidIds + "</font";
                                }
                                else if (Session["CheckEventMess"].ToString() == "3")
                                {
                                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessEventmail + "</font>";
                                }
                                else if (Session["CheckEventMess"].ToString() == "4")
                                {
                                    lblmess.Text = "<font color='green'>Item has been scheduled successfully. Some recipients have opted out of receiving future emails from you.</font>";
                                }
                                else if (Session["CheckEventMess"].ToString() == "5")
                                {
                                    lblmess.Text = "<font color='green'>We could not send this event because the recipients have opted out of receiving future emails from you.</font>";
                                }
                            }
                            else
                            {
                                lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessEventmail + "</font>";
                            }
                            Session["CheckEventMess"] = null;
                        }
                        else
                        {
                            lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessEventmail + "</font>";
                        }
                    }
                    else if (Session["EventSend"].ToString() == "2")
                    {
                        if (Session["CheckEventMess"] != null)
                        {
                            if (Session["CheckEventMess"].ToString() != "")
                            {
                                if (Session["CheckEventMess"].ToString() == "1")
                                {
                                    lblmess.Text = "<font color='green'>We could not schedule this item as there are no valid email ids.</font>";
                                }
                                else if (Session["CheckEventMess"].ToString() == "2")
                                {
                                    string invalidIds = string.Empty;
                                    if (Session["invalidEventEmailID"] != null)
                                    {
                                        if (Session["invalidEventEmailID"].ToString() != "")
                                        {
                                            invalidIds = Session["invalidEventEmailID"].ToString().ToString();
                                        }
                                        Session["invalidEventEmailID"] = null;
                                    }
                                    lblmess.Text = "<font color='green'>Item has been scheduled successfully except to the following ids as they appear to be invalid:</font><br>" + "<font color=#424242>" + invalidIds + "</font";
                                }
                                else if (Session["CheckEventMess"].ToString() == "3")
                                {
                                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessEvent + "</font>";
                                }
                                else if (Session["CheckEventMess"].ToString() == "4")
                                {
                                    lblmess.Text = "<font color='green'>Item has been scheduled successfully. Some recipients have opted out of receiving future emails from you.</font>";
                                }
                                else if (Session["CheckEventMess"].ToString() == "5")
                                {
                                    lblmess.Text = "<font color='green'>We could not schedule this item because the recipients have opted out of receiving future emails from you.</font>";
                                }
                            }
                            else
                            {
                                lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessEvent + "</font>";
                            }
                            Session["CheckEventMess"] = null;
                        }
                        else
                        {
                            lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessEvent + "</font>";
                        }

                    }
                }
                Session["EventSend"] = null;
            }
        }
        private int RemiangScheduleCount()
        {
            EventCalendarBLL objEventCalendar = new EventCalendarBLL();
            DataTable DtUnlimiteduser = new DataTable();
            DtUnlimiteduser = objEventCalendar.CheckForUnlimtedUserEmail(UserID);
            if (DtUnlimiteduser.Rows.Count > 0)
            {
                if (Convert.ToBoolean(DtUnlimiteduser.Rows[0]["Event_Unlimited"].ToString()) == true)
                {
                    BusinessEventUsageCount = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("UnlimtedUserEmailsCount").Replace(",", ""));
                }
                else
                {
                    BusinessEventUsageCount = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("EventUsageCount").Replace(",", ""));
                }
            }
            else
            {
                BusinessEventUsageCount = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("EventUsageCount").Replace(",", ""));
            }
            return BusinessEventUsageCount;
        }
    }
}