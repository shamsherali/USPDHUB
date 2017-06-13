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
using System.Xml;


public partial class Business_MyAccount_ManageEventsCalendar : BaseWeb
{
    public static string urlreferer = string.Empty;

    int ProfileID = 0;
    public int UserID = 0;
    public int BusinessUpdatesCount = 0;
    public int BusinessEventUsageCount = 0;

    BusinessBLL objBus = new BusinessBLL();
    BusinessUpdatesBLL adminobj = new BusinessUpdatesBLL();
    EventCalendarBLL Eventsadminobj = new EventCalendarBLL();
    CommonBLL objCommon = new CommonBLL();
    SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
    USPDHUBBLL.MobileAppSettings objApp = new USPDHUBBLL.MobileAppSettings();

    CalendarService service;
    public string gFolder = "";

    public DataTable DtHis = new DataTable();
    public DataTable dtCampaign = new DataTable();
    public DataTable dtEventCalender = new DataTable();
    List<string> lst = new List<string>();

    public int EventsCount = 0;
    public int SortDir = 0;

    public DataTable dtobj = new DataTable();
    public DataTable DtOptOuts = new DataTable();

    public string articleTitle = string.Empty;
    public string articleSummary = string.Empty;
    public int divnum = 1;
    public string linkedInurlinfo = string.Empty;
    public string FacebookInurlinfo = string.Empty;
    public string Twitterurlinfo = string.Empty;
    public string Mailtourlinfo = string.Empty;
    public string profilename = string.Empty;
    public string ShowButtons = string.Empty;
    public string ArchiveValue = string.Empty;

    public int C_UserID = 0;

    DataTable dtpermissions = new DataTable();
    AgencyBLL agencyobj = new AgencyBLL();

    public string RootPath = "";
    public string DomainName = "";
    public string titleName = "";

    string appID = string.Empty;    //Facebook App ID and Secret
    string appSecret = string.Empty;
    string fbScope = ConfigurationManager.AppSettings.Get("FBScopes");//"public_profile,publish_actions,publish_stream,manage_pages";
    public bool IsEmail = false;
    public bool IsReport = false;
    public bool IsScheduleEmails = false;
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
            ProfileID = Convert.ToInt32(Session["ProfileID"]);

            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
            else
                C_UserID = UserID;

        }

        gFolder = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/MyGoogleStorage");
        // *** Get Domain Name *** //
        DomainName = Session["VerticalDomain"].ToString();
        RootPath = Session["RootPath"].ToString();
        GetFacebookAppDetails();
        hdnURLPath.Value = RootPath;
        lblmess.Text = "";
        //Store Module Functionality
        if (objBus.CheckModulePermission(WebConstants.Purchase_ScheduleEmailsSetup, ProfileID))
        {
            //IsEmail = true;
            IsScheduleEmails = true;
        }
        if (objBus.CheckModulePermission(WebConstants.Purchase_Contacts_Reports, ProfileID))
        {
            IsReport = true;
        }
        // *** Make back button visible and disable by query string 26-03-2013 *** //
        if (!string.IsNullOrEmpty(Request.QueryString["App"] as string))
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
        BusinessBLL busobj = new BusinessBLL();
        DataTable dtprofiledetails = busobj.GetProfileDetailsByProfileID(ProfileID);
        if (dtprofiledetails.Rows.Count > 0)
        {
            profilename = dtprofiledetails.Rows[0]["Profile_name"].ToString();

        }
        titleName = objApp.GetMobileAppSettingTabName(UserID, "Events", DomainName);
        lblTitle.Text = titleName;
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
                                lblmess.Text = "<font color='green'>" + Resources.LabelMessages.SendEmailContacts.Replace("content", "event") + "</font>";
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
                            lblmess.Text = "<font color='green'>" + Resources.LabelMessages.SendEmailContacts.Replace("content", "event") + "</font>";
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

        DataTable DtUnlimiteduser = new DataTable();
        DtUnlimiteduser = Eventsadminobj.CheckForUnlimtedUserEmail(UserID);
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


        if (!IsPostBack)
        {
            #region If not Postback
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
            if (objCommon.DisplayOn_OffSettingsContent(UserID, "EventCalendar"))
            {
                lblOn.Visible = true;
                lblOff.Visible = false;
            }

            //RBAppOrder.SelectedValue = objCommon.DisplayOrderType(UserID, "EventCalendar");

            //roles & permissions..
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Events");
                if (string.IsNullOrEmpty(hdnPermissionType.Value))
                {
                    UpdatePanel2.Visible = true;
                    UpdatePanel1.Visible = false;
                    lblerrormessage.Text = "<font face=arial size=2>You do not have permission to manage " + titleName.Replace("Manage ", "").ToLower() + ".</font>";
                }
            }
            //ends here

            ProfileID = Convert.ToInt32(Session["ProfileID"]);
            Session["BusinessEventID"] = null;
            Session["BusinessEventDes"] = null;
            // *** Issue 1128 *** //
            if (Session["EventSuccess"] != null)
            {
                lblmess.Text = Session["EventSuccess"].ToString();
                Session["EventSuccess"] = null;
            }
            if (Session["ViewGrid"] != null)
            {
                lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive.gif' title='Archive' border='0'/>";
                lnkCurrent.Text = "<img src='../../Images/Dashboard/current.gif' title='Current' border='0'/>";
                hdnarchive.Value = Session["ViewGrid"].ToString();
                Session["ViewGrid"] = null;
            }
            //  Hdn control for Sorting
            hdnsortdire.Value = "";
            hdnsortcount.Value = "0";
            FillDatalist();
            if (Session["BulletinSuccess"] != null)
            {
                lblmess.Text = Session["BulletinSuccess"].ToString();
                Session.Remove("BulletinSuccess");
            }
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
            #endregion Not Postback completed
        }
        ddlPageSize = (DropDownList)PageSizes.FindControl("ddlPageSize");
        ddlPageSize.AutoPostBack = true;
        ddlPageSize.SelectedIndexChanged += ddlPageSize_SelectedIndexChanged;

    }
    private void ShowGoogleSyncDate()
    {
        /***** Display Last Sync Date *****/
        DateTime lastSyncDate = Eventsadminobj.GetLastSyncDate(UserID);
        DateTime strDate = Convert.ToDateTime("01/01/0001");
        if (lastSyncDate.ToShortDateString() != strDate.ToShortDateString())
            lblLastSyncDate.Text = "<font face=arial size=2>" + Resources.LabelMessages.LastSyncDate + lastSyncDate.ToString("MM/dd/yyyy hh:mm tt") + "</font>";
    }
    private void DisplaySyncButtons()
    {
        bool SyncOn = true;
        DataTable Data_GoogleEvents = Eventsadminobj.CheckForGoogleEvents(ProfileID);
        if (Data_GoogleEvents.Rows.Count != 0)
        {
            if (Convert.ToBoolean(Data_GoogleEvents.Rows[0]["Sync"].ToString()) == true)
                SyncOn = false;
        }
        btnSyncOn.Visible = SyncOn;
        btnSyncOff.Visible = SyncOn ? false : true;
    }

    protected void lnkHis_Click(object sender, EventArgs e)
    {
        LinkButton lnkrun = sender as LinkButton;
        EventCalendarBLL ObjEventCalendar = new EventCalendarBLL();

        dtCampaign = ObjEventCalendar.GetCampaignBusinessEventDetailsByDates(Convert.ToInt32(lnkrun.CommandArgument));
        Session["dtCampaign"] = dtCampaign;
    }

    protected void lblhistroy_Click(object sender, EventArgs e)
    {
        LinkButton lnkHis = sender as LinkButton;
        EventCalendarBLL ObjEventcalendar = new EventCalendarBLL();
        DtHis = ObjEventcalendar.GetBusinessEventDetailsByBusinessEventID(Convert.ToInt32(lnkHis.CommandArgument));
        if (DtHis.Rows.Count > 0)
        {
            grdviewsenthis.PageIndex = 0;
            grdviewsenthis.DataSource = DtHis;
            grdviewsenthis.DataBind();

            DataTable dtEvents = new DataTable();
            dtEvents = ObjEventcalendar.GetBusinessEventDetails(Convert.ToInt32(lnkHis.CommandArgument));
            if (dtEvents.Rows.Count > 0)
            {
                lblviewsentnewlettername.Text = dtEvents.Rows[0]["EventTitle"].ToString();
            }
            ModalPopupExtender3.Show();
        }
    }

    protected void grdviewsenthis_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdviewsenthis.PageIndex = e.NewPageIndex;
        grdviewsenthis.DataSource = DtHis;
        grdviewsenthis.DataBind();
        ModalPopupExtender3.Show();
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

    public void FillDatalist()
    {
        trPublish.Visible = trUnPublish.Visible = false;
        hdnCommandArg.Value = "";
        dtobj = Eventsadminobj.GetAllEventsByProfileId(Convert.ToInt32(Session["ProfileID"]));
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
                DataTable dtScheduleEmails = objUpdate.CheckBusinessUpdateCampaignCountByID(Convert.ToInt32(dtobj.Rows[i]["EventId"].ToString()), "Events");
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
                        //if (Convert.ToBoolean(dtobj.Rows[i]["IsPublished"]) == false)
                        //    dtobj.Rows[i]["Sent_Flag"] = "Work in Progress";
                        //else
                        //    dtobj.Rows[i]["Sent_Flag"] = "Completed";
                    }
                }
                else
                {
                    //if (Convert.ToBoolean(dtobj.Rows[i]["IsPublished"]) == false)
                    //    dtobj.Rows[i]["Sent_Flag"] = "Work in Progress";
                    //else
                    //    dtobj.Rows[i]["Sent_Flag"] = "Completed";
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
        GetSavedUserData();
        GrdEvents.PageSize = GetPageSize();
        GrdEvents.DataSource = dtobj.DefaultView;
        GrdEvents.DataBind();
    }

    protected void GrdEvents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblcam = e.Row.FindControl("lblcam") as Label;
            LinkButton lnkcam = e.Row.FindControl("lnkruncampaion") as LinkButton;
            Label lblupdatethub = e.Row.FindControl("lblupdatethub") as Label;
            Label lblApprovalStatus = e.Row.FindControl("lblApprovalStatus") as Label;
            string UpdateID = lnkcam.CommandArgument;
            string ImageDisID = Guid.NewGuid().ToString();
            string file = lblupdatethub.Text == "" ? UpdateID : lblupdatethub.Text;
            if (File.Exists(Server.MapPath("~") + "\\Upload\\Events\\" + ProfileID.ToString() + "\\" + file + ".jpg"))
                lblupdatethub.Text = "<img src='" + RootPath + "/Upload/Events/" + ProfileID.ToString() + "/" + file + ".jpg?Guid=" + ImageDisID + "' border='0' width='100' height='50'/>";
            else
                lblupdatethub.Text = "";

            if (e.Row.Cells[5].Text.Contains("12:00 AM") || e.Row.Cells[5].Text.Contains("00:00"))
            {
                e.Row.Cells[5].Text = e.Row.Cells[5].Text.ToString().Replace("12:00 AM", "12:00:00 AM");
                e.Row.Cells[5].Text = Convert.ToDateTime(e.Row.Cells[5].Text).ToString("MM/dd/yyyy");
            }
            if (e.Row.Cells[6].Text.Contains("12:00 AM") || e.Row.Cells[6].Text.Contains("0:00 AM"))
            {
                e.Row.Cells[6].Text = e.Row.Cells[6].Text.ToString().Replace("12:00 AM", "12:00:00 AM");
                e.Row.Cells[6].Text = Convert.ToDateTime(e.Row.Cells[6].Text).ToString("MM/dd/yyyy");
            }
            int SchCount = 0;
            SchCount = Eventsadminobj.CheckEventCampaignCount(Convert.ToInt32(lnkcam.CommandArgument));
            if (SchCount > 0)
            {
                lnkcam.Visible = true;
            }
            else
            {
                lnkcam.Visible = false;
            }
            Label lblstatus = e.Row.FindControl("lblstatus") as Label;
            //LinkButton lnkStatus = e.Row.FindControl("lnkStatus") as LinkButton;
            Label lnkStatus = e.Row.FindControl("lnkStatus") as Label;
            if (lblstatus.Text == "True")
            {
                lnkStatus.Text = "Public";
            }
            else
            {
                lnkStatus.Text = "Private";
            }
            if (lblcam.Text == "Work in Progress" || lblcam.Text == "Completed" || lblcam.Text == "")
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
            if (lblApprovalStatus.Text.ToLower().Contains(Convert.ToString(Resources.ValidationValues.CheckScheduledPublish)))
                lblApprovalStatus.CssClass = "schedulepublish";
            else
                lblApprovalStatus.CssClass = "scheduleunpublish";
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
    protected void lnkUpdateName_Click(object sender, EventArgs e)
    {
        LinkButton lnkdetails = sender as LinkButton;
        ShowPreviewHTML(Convert.ToInt32(lnkdetails.CommandArgument));
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        LinkButton lnkmodifyUpdate = sender as LinkButton;
        int EventId = Convert.ToInt32(lnkmodifyUpdate.CommandArgument);
        string url = Page.ResolveClientUrl("~/Business/MyAccount/EventsCalendar.aspx?EventId=" + EventId);
        if (btnBack.Visible)
            url = Page.ResolveClientUrl("~/Business/MyAccount/EventsCalendar.aspx?EventId=" + EventId + "&App=1");
        Response.Redirect(url);
    }
    protected void imclose_Click(object sender, ImageClickEventArgs e)
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
    protected string GetSharestrings(int UpdateID, string Update_title)
    {
        GetAutoShareRecordStatus(UpdateID, Update_title);
        #region Sharelinks with Facebook, LinkedIn, Twitter and Email
        articleTitle = Update_title.ToString();
        articleSummary = Update_title.ToString();
        //DataTable dtEvent = new DataTable();
        //dtEvent = Eventsadminobj.GetCalendarEventDetails(UpdateID);
        string description = Update_title;//Convert.ToString(dtEvent.Rows[0]["EventDesc"]);
        description = objCommon.GetSocialDescription(description);
        description = objCommon.ReplaceShortURltoHtmlString(description);
        string redirecturl = RootPath + "/printevents.aspx?EID=" + EncryptDecrypt.DESEncrypt(UpdateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
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
        //lblFacebookPageShare.Text = "<a href='javascript:post_on_page()'><img src='../../images/Dashboard/facebooknew.gif' alt='Share on Facebook Page' width='55' height='36' title='Share on Facebook Page' border='0' /></a>";
        //Facebook


        //Pinterest
        string PinterestUrl = "http://pinterest.com/pin/create/button/?url=" + RootPath + "/printevents.aspx?EID=" + EncryptDecrypt.DESEncrypt(UpdateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&media=" + RootPath + "/Images/VerticalLogos/" + DomainName + "logo.png&description=" + tweetDesc;
        string PinterestUrlshare = "<a count-layout='horizontal' href='" + PinterestUrl + "'  target='_blank'><img border='0' src='../../images/Dashboard/PinterestLogo.gif' title='Pin It' alt='Share on Pinterest' width='55' height='36' /></a>";
        lblPinShare.Text = PinterestUrlshare;
        //Pinterest

        //***************** Commented by Suneel(Updates sharing via Linkedin)******************//
        //LinkedIN
        string update = EncryptDecrypt.DESEncrypt(UpdateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
        string articleUrl1 = RootPath + "/printevents.aspx?EID=" + update;
        string articleSource = RootPath;
        //string linkedInurlinfo1 = "http://www.linkedin.com/shareArticle?mini=true&url=" + HttpUtility.UrlEncode(articleUrl1) + "&title=" + HttpUtility.UrlEncode(articleTitle) + "&summary=" + HttpUtility.UrlEncode(articleSummary) + "&source=" + HttpUtility.UrlEncode(articleSource);
        //linkedInurlinfo = "<a href='" + linkedInurlinfo1.ToString() + "' target='_blank'><img src='../../images/Dashboard/linkedinnew.gif' title='Share on Linkedin' border='0' width='46' height='36'/></a>";
        //lbllinkedinShare.Text = linkedInurlinfo;
        //LinkedIn

        //Twitter
        string Twitterurlinfo1 = "http://www.twitter.com/share?url=" + redirecturl + "&text=" + tweetDesc;
        Twitterurlinfo = "<a href='javascript:void(0);' onclick='TwitterShare(\"" + Twitterurlinfo1 + "\");' title='Click to share this post on Twitter'><img src='../../images/Dashboard/twitternew.gif' alt='Share on Twitter' title='Share on Twitter' border='0' width='39' height='38'/></a>";
        //lblTwitterShare.Text = Twitterurlinfo;
        //Twitter

        //Mail TO Url
        string ur = RootPath + "/printevents.aspx?EID=" + EncryptDecrypt.DESEncrypt(UpdateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
        string url = RootPath + "/Business/Myaccount/ShareEmail.aspx?EC=" + EncryptDecrypt.DESEncrypt(UpdateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
        Mailtourlinfo = "<a href=\"javascript:openEmailwindow('" + url + "')\"><img src='../../images/Dashboard/emailnew.gif' title='Share on Email' width='30' height='38' alt='Share on Email'/></a>";
        lblEmailShare.Text = Mailtourlinfo;
        //Mail TO Url
        string returunurl = Mailtourlinfo + FacebookInurlinfo + Twitterurlinfo + linkedInurlinfo;
        return returunurl;
        #endregion
    }
    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        EventCalendarBLL ObjEventCalendar = new EventCalendarBLL();
        int ScheduledCount = 0;
        //Identify CheckBox is checked or not
        foreach (GridViewRow row in GrdEvents.Rows)
        {
            if (((CheckBox)row.FindControl("CheckBox1")).Checked)
            {
                int EventID = int.Parse(((LinkButton)(GrdEvents.Rows[row.RowIndex].FindControl("lnkdelete"))).CommandArgument);
                int CountCampaign = ObjEventCalendar.CheckEventCampaignCount(EventID);

                // Save User Activity Log
                objCommon.InsertUserActivityLog("has deleted an event named <b>" + hdnEventTitle.Value + "</b> from the Events", string.Empty, UserID, ProfileID, DateTime.Now, UserID);

                if (CountCampaign == 0)
                {
                    ObjEventCalendar.DeleteEventTemplate(EventID);
                }
                else
                {
                    ScheduledCount = ScheduledCount + 1;
                }
            }
        }
        if (ScheduledCount > 0)
        {
            lblmess.Text = "<font size='3' >Your selection(s) have been deleted successfully except the ones that are being scheduled.</font>";
        }
        else
        {
            lblmess.Text = "<font size='3'>Your selection(s) have been deleted successfully.</font>";
        }
        GrdEvents.PageIndex = 0;
        FillDatalist();
    }
    protected void GrdEvents_Sorting(object sender, GridViewSortEventArgs e)
    {
        trUnPublish.Visible = trPublish.Visible = false;
        SortDir = Convert.ToInt32(hdnsortcount.Value);
        string SortExp = e.SortExpression.ToString();
        dtEventCalender = (DataTable)Session["DtEvents"];

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

        DataView Dv = new DataView(dtEventCalender);
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
    protected void grdviewsenthis_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    //*************************************************************************************
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
                lblisCompleted = (Label)row1.FindControl("lblisCompleted");
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
                lblerrormessage.Text = "Expired event is not allowed to publish.";
            }
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
    //protected void lnkStatus_Click(object sender, EventArgs e)
    //{
    //    LinkButton lnkStatus = (LinkButton)sender;
    //    int i = 0;
    //    i = Eventsadminobj.UpdateBusinessEventStatus(Convert.ToInt32(lnkStatus.CommandArgument), lnkStatus.Text == "Public" ? false : true, ProfileID);
    //    if (i > 0)
    //        lblmess.Text = "<font color='green'>Status Updated Successfully.</font>";

    //    FillDatalist();
    //}
    protected void lnkPreviewCalendar_Click(object sender, EventArgs e)
    {
        BusinessBLL Busobj = new BusinessBLL();
        string CSS = string.Empty;
        string URL = string.Empty;
        URL = RootPath + "/ProfileIframes/UserActions.aspx?PID=" + ProfileID + "&Svalue=10";
        Iframeevent.Attributes["src"] = URL;

        CSS = ConfigurationManager.AppSettings.Get("Template1");
        DataTable dtConfigPageKeys = objCommon.GetVerticalConfigsByType(DomainName, "EventCalendar");
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
    protected void lnkNewEvent_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/EventsCalendar.aspx"));
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        /** This is for allowing creators only 26/06/2013**/
        string authorPermission = string.Empty;
        string pubPermission = string.Empty;
        List<string> PermissionList = new List<string>();
        if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
        {
            //dtpermissions = agencyobj.GetPermissionsById(Convert.ToInt32(Session["C_USER_ID"]));
            dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
            for (int i = 0; i < dtpermissions.Rows.Count; i++)
            {
                if (dtpermissions.Rows[i]["ButtonType"].ToString() == "EventCalendar")
                {
                    if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                        authorPermission = "A";
                    if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                        pubPermission = "P";
                    break;
                }
            }
            if ((authorPermission == "A") || (authorPermission == "A" && pubPermission == "P"))
                EditEvent();
            else
                lblmess.Text = "You don't have permission to edit an Event.";
        }
        else
            EditEvent();
        PermissionList.Clear();
    }
    private void EditEvent()
    {
        if (hdnCommandArg.Value != "")
        {
            int EventId = Convert.ToInt32(hdnCommandArg.Value);
            dtobj = Eventsadminobj.GetCalendarEventDetails(EventId);
            if (dtobj.Rows[0]["EventType"].ToString() != "Google")
            {
                DataTable DtChekHis = Eventsadminobj.GetBusinessEventDetailsByBusinessEventID(EventId);
                DataRow[] rows = DtChekHis.Select("Sent_Flag=0");
                if (rows.Length > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(lnkEdit, this.GetType(), "JavaScrtiptAlert", "javascript: fnShowMessage(" + EventId + ");", true);
                }
                else
                {
                    string url = Page.ResolveClientUrl("~/Business/MyAccount/EventsCalendar.aspx?EventId=" + EventId);
                    if (btnBack.Visible)
                        url = Page.ResolveClientUrl("~/Business/MyAccount/EventsCalendar.aspx?EventId=" + EventId + "&App=1");
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
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        EventCalendarBLL ObjEventCalendar = new EventCalendarBLL();
        int ScheduledCount = 0;
        int EventID = 0;
        var title = "";
        //Identify CheckBox is checked or not
        if (hdnarchive.Value != "Archive")
        {
            // Selected Checkbox details for Preview, Edit, Copy, Send Mail
            foreach (GridViewRow row1 in GrdEvents.Rows)
            {
                if (((CheckBox)row1.FindControl("chkCurrentTabEventID")).Checked)
                {
                    hdnCommandArg.Value = (((LinkButton)row1.FindControl("lnkEventName")).CommandArgument);
                    EventID = Convert.ToInt32(hdnCommandArg.Value);
                    int CountCampaign = Eventsadminobj.CheckEventCampaignCount(Convert.ToInt32(hdnCommandArg.Value));
                    if (CountCampaign == 0)
                    {
                        // Save User Activity Log
                        title = ((LinkButton)(GrdEvents.Rows[row1.RowIndex].FindControl("lnkEventName"))).Text;
                        objCommon.InsertUserActivityLog("has deleted an event named <b>" + hdnEventTitle.Value + "</b> from the Events", string.Empty, UserID, ProfileID, DateTime.Now, UserID);
                        ObjEventCalendar.DeleteEventTemplate(EventID);
                    }
                    else
                        ScheduledCount = ScheduledCount + 1;

                }
            }
        }
        else
        {
            //Identify CheckBox is checked or not
            foreach (GridViewRow row in GrdEvents.Rows)
            {
                if (((CheckBox)row.FindControl("chkUpdate")).Checked)
                {
                    EventID = int.Parse(((LinkButton)(GrdEvents.Rows[row.RowIndex].FindControl("lnkEventName"))).CommandArgument);
                    int CountCampaign = ObjEventCalendar.CheckEventCampaignCount(EventID);
                    if (CountCampaign == 0)
                    {
                        #region Save User Activity Log
                        title = ((LinkButton)(GrdEvents.Rows[row.RowIndex].FindControl("lnkEventName"))).Text;
                        objCommon.InsertUserActivityLog("has deleted an event named <b>" + title + "</b> from the Events", string.Empty, UserID, ProfileID, DateTime.Now, UserID);
                        #endregion
                        ObjEventCalendar.DeleteEventTemplate(EventID);
                    }
                    else
                        ScheduledCount = ScheduledCount + 1;
                }
            }
        }
        if (ScheduledCount > 0)
            lblmess.Text = "<font  color='red'>Your selection(s) have been deleted successfully except the ones that are being scheduled.</font>";
        else
            lblmess.Text = "<font  color='red'>Your selection(s) have been deleted successfully.</font>";
        CancelCamp.Visible = false;
        GrdEvents.PageIndex = 0;
        FillDatalist();
    }
    protected void lnkSend_Click(object sender, EventArgs e)
    {
        //CancelCamp.Visible = false;
        EventCalendarBLL ObjEventCalendar = new EventCalendarBLL();
        BusinessBLL ObjBus = new BusinessBLL();
        int CheckSch = 0;

        CheckSch = ObjEventCalendar.CheckforBusinessEventSchedule(UserID);

        int CheckCam = 0;
        if (CheckSch > 0)
        {
            CheckCam = 1;
        }

        CheckSch = BusinessEventUsageCount - CheckSch;
        if (CheckSch > 0)
        {
            Session["BusinessEventID"] = null;
            Session["BusinessEventDes"] = null;
            int EventId = 0;
            DataTable DtGetBusUpate = new DataTable();
            EventId = Convert.ToInt32(hdnCommandArg.Value);
            DtGetBusUpate = ObjEventCalendar.GetCalendarEventDetails(EventId);
            string BusinessUpdateDes = DtGetBusUpate.Rows[0]["EventDesc"].ToString();
            Session["BusinessEventID"] = EventId.ToString();
            Session["BusinessEventDes"] = BusinessUpdateDes;
            if (hdnarchive.Value == "Archive")
                Session["ViewGrid"] = hdnarchive.Value;
            string url = Page.ResolveClientUrl("~/Business/MyAccount/SendEvent.aspx");
            if (btnBack.Visible)
                url = Page.ResolveClientUrl("~/Business/MyAccount/SendEvent.aspx?App=1");
            Response.Redirect(url);

            /*
            if (DtGetBusUpate.Rows.Count > 0)
            {
                if (DtGetBusUpate.Rows[0]["IsPublished"] == null)
                {
                    DtGetBusUpate.Rows[0]["IsPublished"] = true;
                }

                if (DtGetBusUpate.Rows[0]["IsPublic"] == null)
                {
                    DtGetBusUpate.Rows[0]["IsPublic"] = true;
                }


                if (Convert.ToString(DtGetBusUpate.Rows[0]["IsPublished"]) == "False")
                {
                    lblmess.Text = "<font color='red'>You cannot send a work in progress event.</font>";
                }
                else
                {
                    string BusinessUpdateDes = DtGetBusUpate.Rows[0]["EventDesc"].ToString();
                    Session["BusinessEventID"] = EventId.ToString();
                    Session["BusinessEventDes"] = BusinessUpdateDes;
                    if (hdnarchive.Value == "Archive")
                        Session["ViewGrid"] = hdnarchive.Value;
                    string url = Page.ResolveClientUrl("~/Business/MyAccount/SendEvent.aspx");
                    if (btnBack.Visible)
                        url = Page.ResolveClientUrl("~/Business/MyAccount/SendEvent.aspx?App=1");
                    Response.Redirect(url);
                }
                
            }
             * */
        }
        else
        {
            if (CheckCam > 0)
            {
                string MaxSchDate = string.Empty;
                MaxSchDate = ObjEventCalendar.GetBusinessEventMaxScheduleingDate(UserID);
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
        EventCalendarBLL ObjEventCalendar = new EventCalendarBLL();
        if (hdnCommandArg.Value == "")
        {
            hdnCommandArg.Value = "0";
        }
        int ArchiveID = Convert.ToInt32(hdnCommandArg.Value);
        int CountCampaign = ObjEventCalendar.CheckEventCampaignCount(Convert.ToInt32(hdnCommandArg.Value));
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
                    objCommon.ArchiveSelectedNewsletter(ArchiveID, ArchiveFlag, WebConstants.Tab_EventCalendar, C_UserID);
                }
            }

            if (ArchiveFlag == false)
            {
                lblmess.Text = "Your selected items(s) has been reinstated successfully.";
            }
            else
            {
                lblmess.Text = "Your selected items(s) has been archived successfully.";
            }
            FillDatalist();
        }
        else
        {
            string MaxSchDate = string.Empty;
            MaxSchDate = ObjEventCalendar.GetBusinessEventMaxScheduleingDate(UserID);
            MaxSchDate = MaxSchDate.Replace("12:00:00 AM", "");
            if (ArchiveFlag == false)
                lblmess.Text = (Resources.LabelMessages.ArchiveSchedulenewsletter).Replace("flyer", "event").Replace("archive", "reinstate");
            else
                lblmess.Text = (Resources.LabelMessages.ArchiveSchedulenewsletter).Replace("flyer", "event");
        }
    }
    protected void lnkCancelCamp_Click(object sender, EventArgs e)
    {
        LinkButton lnkrun = sender as LinkButton;
        //  Newsletter objNews = new Newsletter();
        EventCalendarBLL ObjEventCalendar = new EventCalendarBLL();

        dtCampaign = ObjEventCalendar.GetCampaignBusinessEventDetailsByDates(Convert.ToInt32(hdnCommandArg.Value));
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
    protected void lnkReports_Click(object sender, EventArgs e)
    {
        string RedirectUrl = string.Empty;
        if (hdnarchive.Value == "Archive")
            RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/EventsReports.aspx?Flag=Archive");
        else
            RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/EventsReports.aspx?Flag=Current");
        if (btnBack.Visible)
            RedirectUrl = RedirectUrl + "&App=1";
        Response.Redirect(RedirectUrl);
    }
    private void ShowPreviewHTML(int EventId)
    {
        string PreviewHTML = string.Empty;
        string UnUsbscribeLink = string.Empty;
        DataTable DtCalendarEventDetails = new DataTable();
        string EventTitle = string.Empty;
        string dtEventStartDate = string.Empty;
        string dtEventEndDate = string.Empty;
        DtCalendarEventDetails = Eventsadminobj.GetCalendarEventDetails(EventId);
        if (DtCalendarEventDetails.Rows.Count > 0)
        {
            PreviewHTML = DtCalendarEventDetails.Rows[0]["EventDesc"].ToString();
            string fullDate = "";
            if (Convert.ToString(DtCalendarEventDetails.Rows[0]["EventEndDate"]) == string.Empty)
                fullDate = Convert.ToDateTime(DtCalendarEventDetails.Rows[0]["EventStartDate"]).ToString("MMM dd yyyy") + "" + " (All day)";
            else
                fullDate = objCommon.GetEventAdjustDate(Convert.ToDateTime(DtCalendarEventDetails.Rows[0]["EventStartDate"].ToString()), Convert.ToDateTime(DtCalendarEventDetails.Rows[0]["EventEndDate"].ToString()));

            UnUsbscribeLink = UserProfileUnsubscribeLink();
            PreviewHTML = "<html><head></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='border: solid 2px #F4EBEB;'>  <tr><td colspan='2' style='padding:10px;'>" + fullDate + "</td></tr><tr><td colspan='2' style='padding:20px;'>" + PreviewHTML + "</td></tr></table></body></html>";

            //PreviewHTML = objCommon.ReplaceShortURltoHtmlString(PreviewHTML);
            lblPreviewHTML.Text = PreviewHTML;
            lblupdatename.Text = DtCalendarEventDetails.Rows[0]["EventTitle"].ToString();
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
        UnSubscribeLinkText = "This message was sent by " + ProfileName + " to &#60;recipient's email address&#62;. It was sent from &#60; sender's email address&#62;" + TotalAddress + ". If you no longer wish to receive our events, <a href='" + RootPath + "/UnsubscribeEvent.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "' target='_blank'>click here</a> to unsubscribe.";
        return UnSubscribeLinkText;
    }
    [WebMethod]
    public static string ServerSidefill(string EventName, int ProfileID)
    {
        string FlyerPath = "";

        try
        {
            FlyerPath = HttpContext.Current.Server.MapPath("~") + "\\Upload\\Events\\" + ProfileID.ToString();
            if (!System.IO.Directory.Exists(FlyerPath))
            {
                System.IO.Directory.CreateDirectory(FlyerPath);
            }
            FlyerPath = FlyerPath + "\\" + EventName + ".jpg";
            if (!System.IO.File.Exists(FlyerPath))
            {
                FlyerPath = "No Image";
            }
            else
            {
                FlyerPath = "<img src='" + HttpContext.Current.Session["RootPath"].ToString() + "/Upload/Events/" + ProfileID.ToString() + "/" + EventName + ".jpg' border='0' width='100' height='100'/>";
            }
        }
        catch
        {
            FlyerPath = "No Image";
        }

        return FlyerPath;

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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
    }
    protected void lnkPreview_Click(object sender, EventArgs e)
    {
        LinkButton lnkdetails = sender as LinkButton;
        ShowPreviewHTML(Convert.ToInt32(hdnCommandArg.Value));
    }
    private void CopyEventCalendar()
    {
        if (hdnCommandArg.Value != "")
        {
            if (File.Exists(Server.MapPath("~") + "\\Upload\\Events\\" + ProfileID.ToString() + "\\" + hdnCommandArg.Value + ".jpg"))
                lblFlyerimage.Text = "<img src='" + RootPath + "/Upload/Events/" + ProfileID.ToString() + "/" + hdnCommandArg.Value + ".jpg' border='1' width='350' height='350'/>";
            else
                lblFlyerimage.Text = "<font size='3' weight='bold'>No Thumbnail</font>";
        }
        else
            lblFlyerimage.Text = "<font size='3' weight='bold'>No Thumbnail</font>";
        ModalPopupExtender4.Show();

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
            DataTable dtEvent = Eventsadminobj.GetBusinessEventDetails(Convert.ToInt32(hdnCommandArg.Value));
            if (dtEvent.Rows.Count > 0)
            {
                lblExisting.Text = Convert.ToString(dtEvent.Rows[0]["EventTitle"]);
            }
            if (File.Exists(Server.MapPath("~") + "\\Upload\\Events\\" + ProfileID.ToString() + "\\" + hdnCommandArg.Value + ".jpg"))
                lblRenameImage.Text = "<img src='" + RootPath + "/Upload/Events/" + ProfileID.ToString() + "/" + hdnCommandArg.Value + ".jpg' border='1' width='350' height='350'/>";
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
                int outputID = objBulletin.RenameContent(Convert.ToInt32(hdnCommandArg.Value), txtNewName.Text.Trim(), C_UserID, WebConstants.Tab_EventCalendar, ProfileID);
                // *** Silent PushNotification  *** //
                objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, Convert.ToInt32(hdnCommandArg.Value), "EventCalendar", "Rename");
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
    protected void btneditcancel_Click(object sender, EventArgs e)
    {
        ModalPopupExtender4.Hide();
    }
    protected void BtneditTemplate_Click(object sender, EventArgs e)
    {
        USPDHUBBLL.EventCalendarBLL adminobj = new USPDHUBBLL.EventCalendarBLL();
        int EventId = Convert.ToInt32(hdnCommandArg.Value);
        DataTable dtobj = new DataTable();
        dtobj = adminobj.GetCalendarEventDetails(EventId);
        int? publishedby = null;
        DateTime? publisheddate = null;
        string eventTitle = txteventname.Text.Trim();
        string eventDesc = dtobj.Rows[0]["EventDesc"].ToString();
        string startdate = Convert.ToDateTime(dtobj.Rows[0]["EventStartDate"]).ToString();
        string enddate = null;
        if (Convert.ToString(dtobj.Rows[0]["EventEndDate"]) != string.Empty)
            enddate = Convert.ToDateTime(dtobj.Rows[0]["EventEndDate"]).ToString();

        bool Status = Convert.ToBoolean(dtobj.Rows[0]["Status"]);
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
        OldName = EventId + ".jpg";

        EventId = adminobj.InsertEventDetails(0, ProfileID, UserID, eventTitle, eventDesc, Status, startdate, enddate, false, 0, false, false,
            C_UserID, EditHTML, publishedby, publisheddate, ListDescription, ExDate, isCall, isContatUs, isRepeat, null);

        // Save User Activity Log
        objCommon.InsertUserActivityLog("has created an event titled <b>" + eventTitle + "</b> by copying <b>" + hdnEventTitle.Value + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);


        //new event id name
        NewName = EventId + ".jpg";

        string OldTemplatePath = string.Empty;
        string NewTemplatePath = string.Empty;

        OldTemplatePath = (Server.MapPath("~") + "\\Upload\\Events\\" + Session["ProfileID"].ToString() + "\\" + OldName);
        NewTemplatePath = (Server.MapPath("~") + "\\Upload\\Events\\" + Session["ProfileID"].ToString() + "\\" + NewName);

        if (File.Exists(OldTemplatePath))
        {
            File.Copy(OldTemplatePath, NewTemplatePath, true);
        }
        string url = Page.ResolveClientUrl("~/Business/MyAccount/EventsCalendar.aspx?EventId=" + EventId);
        if (btnBack.Visible)
            url = Page.ResolveClientUrl("~/Business/MyAccount/EventsCalendar.aspx?EventId=" + EventId + "&App=1");
        Response.Redirect(url);
    }
    protected void drpfilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnCommandArg.Value = "";
        CancelCamp.Visible = false;
        ShowButtons = "1";
        string EventFilter = drpfilter.SelectedItem.Value;

        if (EventFilter != "0")
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
                if (EventFilter == "1")
                {
                    EventCampStatus = "Work in Progress";
                }
                else if (EventFilter == "2")
                    EventCampStatus = "Scheduled";
                else if (EventFilter == "3")
                    EventCampStatus = "Sending";
                else if (EventFilter == "4")
                    EventCampStatus = "Sent";
                else if (EventFilter == "6")
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
    protected void grdschemail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdschemail.PageIndex = e.NewPageIndex;
        grdschemail.DataSource = dtCampaign;
        grdschemail.DataBind();
        ModalPopupExtender5.Show();
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
            BusinessUpdatesBLL ObjBusUpdate = new BusinessUpdatesBLL();
            EventCalendarBLL ObjEventCalendar = new EventCalendarBLL();
            int Count = 0;
            Count = ObjEventCalendar.GetEventCountforDayforUserDateAndEventID(UserID, Convert.ToDateTime(lbldate.Text), Convert.ToInt32(lblp.Text));
            lblCount.Text = Count.ToString();
        }
    }
    protected void btnstopcampain_Click(object sender, EventArgs e)
    {
        CancelCamp.Visible = false;

        BusinessUpdatesBLL ObjBusUpdate = new BusinessUpdatesBLL();
        EventCalendarBLL ObjEventCalendar = new EventCalendarBLL();
        ObjEventCalendar.CancelEventCampaign(Convert.ToInt32(lblp.Text));
        FillDatalist();
        lblmess.Text = "<font color='green'>Your event campaign has been cancelled successfully.</font>";
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
    }
    protected void lnkCreate_Click(object sender, EventArgs e)
    {
        /** This is for allowing creators only 26/06/2013**/
        string url = "";
        string authorPermission = string.Empty;
        string pubPermission = string.Empty;
        List<string> PermissionList = new List<string>();
        if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
        {
            dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
            for (int i = 0; i < dtpermissions.Rows.Count; i++)
            {
                if (dtpermissions.Rows[i]["ButtonType"].ToString() == "EventCalendar")
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
                url = Page.ResolveClientUrl("~/Business/MyAccount/EventsCalendar.aspx");
                if (btnBack.Visible)
                    url = Page.ResolveClientUrl("~/Business/MyAccount/EventsCalendar.aspx?App=1");
                Response.Redirect(url);
            }
            else
            {
                lblmess.Text = "You don't have permission to create an Event.";
            }
        }
        else
        {
            url = Page.ResolveClientUrl("~/Business/MyAccount/EventsCalendar.aspx");
            if (btnBack.Visible)
                url = Page.ResolveClientUrl("~/Business/MyAccount/EventsCalendar.aspx?App=1");
            Response.Redirect(url);
        }
        PermissionList.Clear();
    }
    protected void lnkNotification_Click(object sender, EventArgs e)
    {
        Session["PushNotifyType"] = "Event," + hdnCommandArg.Value;
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SendAppNotifications.aspx"));
    }
    protected void lnkPublish_Click(object sender, EventArgs e)
    {
        /** This is for allowing publishers only 26/06/2013**/
        string authorPermission = string.Empty;
        string pubPermission = string.Empty;
        List<string> PermissionList = new List<string>();
        if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
        {
            dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
            for (int i = 0; i < dtpermissions.Rows.Count; i++)
            {
                if (dtpermissions.Rows[i]["ButtonType"].ToString() == "EventCalendar")
                {
                    if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                        authorPermission = "A";
                    if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                        pubPermission = "P";
                    break;
                }
            }
            if ((pubPermission == "P") || (authorPermission == "A" && pubPermission == "P"))
            {
                if (hdnCommandArg.Value != "")
                {
                    //Checking Schedule Emails for Publish
                    if (IsScheduleEmails)
                    {
                        ShowPublishModal();
                    }
                    else
                    {
                        DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                        txtPublishDate.Text = dtToday.ToShortDateString();
                        //Identify CheckBox is checked or not
                        foreach (GridViewRow row in GrdEvents.Rows)
                        {
                            if (((CheckBox)row.FindControl("chkCurrentTabEventID")).Checked)
                            {
                                hdnCommandArg.Value = ((LinkButton)(GrdEvents.Rows[row.RowIndex].FindControl("lnkEventName"))).CommandArgument;

                                //roles & permissions..
                                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "" && hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))  // A for approve...
                                {
                                    UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), false);
                                    objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.EVENT, UserID, Session["username"].ToString(), PageNames.EVENT, DomainName);
                                }
                                else
                                    UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), true);
                                //ends here...
                            }
                        } // EnD foreach

                        hdnCommandArg.Value = "";
                        lblmess.Text = Resources.LabelMessages.PublishStatusChange.Replace("#Type#", "event").Replace("#Status#", "published");
                        FillDatalist();
                    }
                }
            }
            else
                lblmess.Text = "You don't have permission to publish an Event.";
        }
        else
        {
            if (hdnCommandArg.Value != "")
            {
                //Checking Schedule Emails for Publish
                if (IsScheduleEmails)
                {
                    ShowPublishModal();
                }
                else
                {
                    DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                    txtPublishDate.Text = dtToday.ToShortDateString();
                    //Identify CheckBox is checked or not
                    foreach (GridViewRow row in GrdEvents.Rows)
                    {
                        if (((CheckBox)row.FindControl("chkCurrentTabEventID")).Checked)
                        {
                            hdnCommandArg.Value = ((LinkButton)(GrdEvents.Rows[row.RowIndex].FindControl("lnkEventName"))).CommandArgument;

                            //roles & permissions..
                            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "" && hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))  // A for approve...
                            {
                                UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), false);
                                objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.EVENT, UserID, Session["username"].ToString(), PageNames.EVENT, DomainName);
                            }
                            else
                                UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), true);
                            //ends here...
                        }
                    } // EnD foreach

                    hdnCommandArg.Value = "";
                    lblmess.Text = Resources.LabelMessages.PublishStatusChange.Replace("#Type#", "event").Replace("#Status#", "published");
                    FillDatalist();
                }
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
                        objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.EVENT, UserID, Session["username"].ToString(), PageNames.EVENT, DomainName);
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
    }
    private void UpdatePublish(bool flag, int EventId, DateTime? PublishDate, bool IsPublished)
    {
        Eventsadminobj.UpdatePublishedEvents(flag, UserID, C_UserID, EventId, PublishDate, IsPublished);
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

            lblmess.Text = Resources.LabelMessages.PublishStatusChange.Replace("#Type#", "event").Replace("#Status#", "made private");
            FillDatalist();
        }
    }
    protected void btnSyncOff_Click(object sender, EventArgs e)
    {
        EventCalendarBLL ObjEventCalendar = new EventCalendarBLL();
        ObjEventCalendar.InsertUpdateGMailUserDetails(" ", " ", true, false, ProfileID);
        DisplaySyncButtons();
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
    protected void btnSyncOn_Click(object sender, EventArgs e)
    {
        Session["ResponseCodeType"] = "Google";

        RemoveGoogleResponseCodeQueryStr();

        string UserId = "user__" + DateTime.Now.ToString("yyyyMMddhhMMss");
        Session["GUserId"] = UserId;
        FillGoogleCalendarEvents();

        /*
        Random random = new Random();
        ClientSecrets secrets = new ClientSecrets
        {
            ClientId = ConfigurationManager.AppSettings.Get("GoogleClientID"),
            ClientSecret = ConfigurationManager.AppSettings.Get("GoogleClientSecret")
        };
        string userEmail = "user" + Guid.NewGuid();
        UserCredential credential = null;
        try
        {
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, new string[] { CalendarService.Scope.Calendar }, userEmail, CancellationToken.None).Result;
        }
        catch (Exception ex)
        {
        }

        var initializer = new BaseClientService.Initializer();
        initializer.HttpClientInitializer = credential;
        initializer.ApplicationName = "MyAppTest";
        Session["Credentials"] = credential;

        service = new CalendarService(initializer);
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
        MPELoginforGoogleEvents.Show();*/
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

            for (int i = 0; i < lstGoogleCalenders.Items.Count; i++)
            {
                if (lstGoogleCalenders.Items[i].Selected == true)
                {
                    lst.Add(lstGoogleCalenders.Items[i].Text);
                }
            }
            if (lst.Count() > 0)
            {
                Eventsadminobj.InsertLastSyncDate(ProfileID, UserID, C_UserID, DateTime.Now, "EventCalendar");
                for (int j = 0; j < lst.Count(); j++)
                {
                    string selectedItem = lst[j];
                    foreach (CalendarListEntry calendar in list)
                    {
                        string caledarname = calendar.Summary;
                        if (caledarname == selectedItem)
                        {
                            Eventsadminobj.RemoveGoogleEvents(calendar.Id);    //Remove any existing google events from present day of current import to future before import happens 
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
            objInBuiltData.ErrorHandling("ERROR", "ManageEventsCalendar.aspx.cs", "btnGo_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private int GetGoogleEvents(string pageToken, string calId, int countcalEvents, string CalendarName)
    {
        var description = string.Empty;
        int eventID = 0;
        EventsResource.ListRequest requeust = service.Events.List(calId);
        requeust.SingleEvents = true;
        if (pageToken != "")
            requeust.PageToken = pageToken;
        DateTime dtSyncStartTime = objCommon.ConvertToUserTimeZone(ProfileID);
        DateTime dtSyncEndTime = new DateTime(dtSyncStartTime.Year, dtSyncStartTime.Month, 1).AddMonths(12);
        requeust.TimeMax = dtSyncEndTime;
        requeust.TimeMin = dtSyncStartTime;
        Events result = requeust.Execute();

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
                    eventID = Eventsadminobj.InsertGMailEventDetails(0, ProfileID, UserID, EventTitle, description, true, startTime, endTime, false, 0, true, true, C_UserID, description, C_UserID, DateTime.Now, location, "Google", calId, CalendarName);
                    EventHtmlConvertImage(description, eventID);
                    countcalEvents++;
                }
            }
            if (result.NextPageToken != null)
                GetGoogleEvents(result.NextPageToken, calId, countcalEvents, CalendarName);

        }

        return countcalEvents;
    }
    private void EventHtmlConvertImage(string desc, int EventId)
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
            string saveFilePath = Server.MapPath("~") + "\\Upload\\Events\\" + ProfileID.ToString();
            if (!System.IO.Directory.Exists(saveFilePath))
            {
                System.IO.Directory.CreateDirectory(saveFilePath);
            }
            string savelocation = saveFilePath + "\\" + EventId.ToString() + ".jpg";
            string tempimagepath = Server.MapPath("~") + "\\Upload\\Events\\" + ProfileID.ToString() + "\\" + ProfileID.ToString() + UserID.ToString() + ".jpg";
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
            objInBuiltData.ErrorHandling("ERROR", "ManageEventsCalendar.aspx.cs", "ConvertHTMLtoImage", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
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

        var uri = RootPath + "/Business/MyAccount/ManageEventsCalendar.aspx";
        var code = Request["code"];

        string UserId = Session["GUserId"].ToString();

        if (code != null)
        {
            try
            {
                var token = flow.ExchangeCodeForTokenAsync(UserId, code, uri.ToString(), CancellationToken.None).Result;
                //var oauthState = AuthWebUtility.ExtracRedirectFromState(flow.DataStore, UserId, Request["state"]).Result;
                //Response.Redirect(oauthState);

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
    protected void lnkShareBtn_Click(object sender, EventArgs e)
    {
        RemoveGoogleResponseCodeQueryStr();
        Session["ResponseCodeType"] = "FB";
        string description = string.Empty;
        string articleTitle = hdnEventTitle.Value.ToString();
        //DataTable dtEvent = new DataTable();
        //dtEvent = Eventsadminobj.GetCalendarEventDetails(Convert.ToInt32(hdnCommandArg.Value));
        //description = Convert.ToString(dtEvent.Rows[0]["EventDesc"]);
        description = articleTitle;
        description = objCommon.GetSocialDescription(description);
        string redirecturl = RootPath + "/printevents.aspx?Timespan=" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + "&EID=" + EncryptDecrypt.DESEncrypt(Convert.ToInt32(hdnCommandArg.Value).ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
        redirecturl = objCommon.longurlToshorturl(redirecturl);
        //Facebook     
        Session["ContentID"] = hdnCommandArg.Value;
        string tweetDesc = description.Replace("#", "");
        if ((description.Length + redirecturl.Length) > 137)
        {
            tweetDesc = description.Substring(0, 140 - (redirecturl.Length + 3)).Replace("#", "");
        }

        DataTable dtExistingFbUsersData = smb.GetExistingUserData(ProfileID);
        if (dtExistingFbUsersData.Rows.Count > 0)
        {
            //smb.FacebookAutoShare(ProfileID, tweetDesc, articleTitle, redirecturl);
           
            objCommon.InsertUpdateAutoShareDetails("EventCalendar", Convert.ToInt32(hdnCommandArg.Value), 0, DateTime.Now, "Facebook", UserID, C_UserID, articleTitle);
            lblmess.Text = "<font color='green'>Your selected item has been posted on facebook successfully.</font>";
        }
        else
        {
            Dictionary<string, object> args = new Dictionary<string, object>();
            args["description"] = tweetDesc;
            args["name"] = articleTitle;
            args["link"] = redirecturl;
            Session["PageContent"] = args;
            //GetSharestrings(Convert.ToInt32(hdnCommandArg.Value), articleTitle);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "post_on_page();", true);
            //if (Request["code"] == null)
            Response.Redirect("https://graph.facebook.com/oauth/authorize?client_id=" + appID + "&redirect_uri=" + RootPath + "/Business/MyAccount/ManageEventsCalendar.aspx" + "&scope=" + fbScope);
            //else
            //    ShareOnFacebook();
        }
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
    private void ShareOnFacebook()
    {
        int pageCount = 0;
        Dictionary<string, string> tokens = new Dictionary<string, string>();
        try
        {
            string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}", appID, RootPath + "/Business/MyAccount/ManageEventsCalendar.aspx", fbScope, Request["code"].ToString(), appSecret);
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
                lblLength.Text = (txtDesc.MaxLength - txtDesc.Text.Length).ToString();
                mpeFbPages.Show();
            }
        }
        catch (Exception /*ex*/)
        {
            Response.Redirect(RootPath + "/Business/MyAccount/ManageEventsCalendar.aspx");
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
        try
        {
            lblLength.Text = (txtDesc.MaxLength - txtDesc.Text.Length).ToString();
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
            args.Add("message", txtDesc.Text.Trim());
            if (selectedPage != "")
                postID = fb.Post("/" + selectedPage + "/feed", args).ToString();
            if (postID != "")
            {
                mpeFbPages.Hide();
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageEventsCalendar.aspx?fbStatus=1"));
            }
            else
            {
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageEventsCalendar.aspx?fbStatus=0"));
            }
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            objInBuiltData.ErrorHandling("ERROR", "ManageEventsCalender.aspx.cs", "ShareOnPage()", ex.Message,
                   Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private void GetAutoShareRecordStatus(int eventID, string eventTitle)
    {
        EventCalendarBLL adminobj = new EventCalendarBLL();
        DataTable dtobj = new DataTable();
        dtobj = adminobj.GetCalendarEventDetails(eventID);
        if (dtobj.Rows.Count > 0)
            eventTitle = dtobj.Rows[0]["EventTitle"].ToString();

        DataTable dtShareRecords = objCommon.CheckAutoShareRecordExists("EventCalendar", eventID, eventTitle);
        for (int i = 0; i < dtShareRecords.Rows.Count; i++)
        {
            if (Convert.ToString(dtShareRecords.Rows[i]["Media_TYPE"]) == "Facebook")
                hdnFacebook.Value = "false";

            if (Convert.ToString(dtShareRecords.Rows[i]["Media_TYPE"]) == "Twitter")
                hdnTwitter.Value = "false";
        }
    }
    protected void lnkTwrShare_Click(object sender, EventArgs e)
    {
        try
        {
            string description = string.Empty;
            string articleTitle = hdnEventTitle.Value.ToString();
            //DataTable dtEvent = new DataTable();
            //dtEvent = Eventsadminobj.GetCalendarEventDetails(Convert.ToInt32(hdnCommandArg.Value));
            //description = Convert.ToString(dtEvent.Rows[0]["EventDesc"]);
            description = articleTitle;
            description = objCommon.GetSocialDescription(description);
            string redirecturl = RootPath + "/printevents.aspx?EID=" + EncryptDecrypt.DESEncrypt(Convert.ToInt32(hdnCommandArg.Value).ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
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
                objCommon.InsertUpdateAutoShareDetails("EventCalendar", Convert.ToInt32(hdnCommandArg.Value), 0, DateTime.Now, "Twitter", UserID, C_UserID, articleTitle);
                lblmess.Text = "<font color='green'>Your selected item has been posted on twitter successfully.</font>";
            }
            else
            {
                string url = "http://www.twitter.com/share?url=" + redirecturl + "&text=" + tweetDesc;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + url + "', '_blank');", true);
                objCommon.InsertUpdateAutoShareDetails("EventCalendar", Convert.ToInt32(Session["ContentID"]), 1, DateTime.Now, "Twitter", UserID, C_UserID, articleTitle);
                objCommon.UpdateSocialShareStatus(UserID, 1, "Twitter", Convert.ToInt32(Session["ContentID"]), 1);//updating status flag for report
            }
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            objInBuiltData.ErrorHandling("ERROR", "ManageEventsCalender.aspx.cs", "lnkTwrShare_Click()", ex.Message,
                   Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void RBAppOrder_OnSelectedIndexChanged(object sender, EventArgs e)
    {/*
        int selectedOrderType = Convert.ToInt32(RBAppOrder.SelectedValue);

        //objCommon.UpdateDisplayOrderType(ProfileID, Convert.ToInt32(Session["CustomModuleID"]), selectedOrderType, "Bulletins");
        objCommon.UpdateDisplayOrderType(ProfileID, 0, selectedOrderType, "EventCalendar");

        */
    }

    DropDownList ddlPageSize;
    private void SaveUserSettings()
    {
        try
        {
            string XMLdata = "<ManageEventCalendar MessagePageSize='" + PageSizes.SelectedPage + "'  /> ";
            var dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, WebConstants.Tab_EventCalendar, 0);
            if (dtDisplayReadFirst.Rows.Count == 0)
                objBus.UserCustomizeSettings(0, ProfileID, UserID, WebConstants.Tab_EventCalendar, XMLdata, 0);
            else
                objBus.UserCustomizeSettings(Convert.ToInt32(dtDisplayReadFirst.Rows[0]["CustomizeSettingsID"].ToString()), ProfileID, UserID, WebConstants.Tab_EventCalendar, XMLdata, 0);
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            objInBuiltData.ErrorHandling("ERROR", "ManageEventsCalender.aspx.cs", "SaveUserSettings()", ex.Message,
                   Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    public int GetPageSize()
    {
        int ReturnValue = 5;
        if (!string.IsNullOrEmpty(PageSizes.SelectedPage))
            ReturnValue = Convert.ToInt32(PageSizes.SelectedPage);
        return ReturnValue;
    }
    public void GetSavedUserData()
    {
        string XMLValue = string.Empty;
        DataTable dtDisplayReadFirst = new DataTable();
        dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, WebConstants.Tab_EventCalendar, 0);
        if (dtDisplayReadFirst.Rows.Count > 0)
        {
            XMLValue = Convert.ToString(dtDisplayReadFirst.Rows[0]["XMLValue"]);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(XMLValue);
            if (XMLValue != "")
            {
                if (xmldoc.SelectSingleNode("ManageEventCalendar/@MessagePageSize") != null)
                {
                    PageSizes.SelectedPage = xmldoc.SelectSingleNode("ManageEventCalendar/@MessagePageSize").Value;
                }
            }
        }
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        SaveUserSettings();
        GrdEvents.PageSize = GetPageSize();
        GrdEvents.DataSource = (DataTable)Session["DtEvents"];
        GrdEvents.DataBind();
    }
}

