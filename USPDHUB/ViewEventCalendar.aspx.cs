using System;
using System.Linq;
using System.Data;
using USPDHUBBLL;
using System.Configuration;
using System.Web;
using System.Web.UI.HtmlControls;


public partial class ViewEventCalendar : System.Web.UI.Page
{
    public int EventID = 0;
    public int SchEventID = 0;
    public int UserID = 0;
    public int ProfileID = 0;
    public string EventPreview = string.Empty;
    EventCalendarBLL objEvents = new EventCalendarBLL();
    BusinessBLL objBus = new BusinessBLL();
    public string EmailAddress = string.Empty;
    public string[] Split;
    public string RootPath = "";
    CommonBLL objCommon = new CommonBLL();
    public string DomainName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // *** Get Domain Name *** //
            if (!IsPostBack)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            if (Request.QueryString["SID"] != null)
            {
                if (Request.QueryString["SID"].ToString() != "")
                {
                    string iD = EncryptDecrypt.DESDecrypt(Request.QueryString["SID"].ToString());
                    EventID = Convert.ToInt32(iD);
                }
            }
            if (Request.QueryString["SchID"] != null)
            {
                if (Request.QueryString["SchID"].ToString() != "")
                {
                    string schID = EncryptDecrypt.DESDecrypt(Request.QueryString["SchID"].ToString());
                    SchEventID = Convert.ToInt32(schID);
                }
            }
            if (Request.QueryString["REA"] != null)
            {
                if (Request.QueryString["REA"].ToString() != "")
                {
                    EmailAddress = EncryptDecrypt.DESDecrypt(Request.QueryString["REA"].ToString());
                }
            }
            if (!IsPostBack)
            {
                // *** Adding page title and meta keys for page *** //
                DataTable dtConfigPageKeys = objCommon.GetVerticalConfigsByType(DomainName, "DashboardKeys");
                if (dtConfigPageKeys.Rows.Count > 0)
                {
                    HtmlMeta htmlMeta = new HtmlMeta();
                    foreach (DataRow row in dtConfigPageKeys.Rows)
                    {
                        if (row[0].ToString() == "Title")
                            this.Page.Title = row[1].ToString();
                        else if (row[0].ToString() == "author")
                            htmlMeta.Attributes.Add("author", row[1].ToString());
                        else if (row[0].ToString() == "description")
                            htmlMeta.Attributes.Add("description", row[1].ToString());
                        else if (row[0].ToString() == "keywords")
                            htmlMeta.Attributes.Add("keywords", row[1].ToString());
                    }
                    HtmlHead header = new HtmlHead();
                    header.Controls.Add(htmlMeta);
                }
                GetEventDetails();
            }
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "ViewEventCalendar.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    public void GetEventDetails()
    {
        try
        {
            string unsubscribeContent = string.Empty;
            DataTable dtSchEventDetails;
            bool contactusFlag = false;
            bool storelinksShare = false;
            string eventTitle = string.Empty;
            string eventDesc = string.Empty;
            string shareEvent = string.Empty;
            string eventBody = string.Empty;
            string eventDate = "";
            if (SchEventID != 0)
            {
                dtSchEventDetails = objEvents.GetEventCalendarDetailsBySchID(SchEventID);
            }
            else
            {
                dtSchEventDetails = objEvents.GetCalendarEventDetails(EventID);
            }
            if (dtSchEventDetails.Rows.Count > 0)
            {
                eventTitle = dtSchEventDetails.Rows[0]["EventTitle"].ToString();
                eventDesc = dtSchEventDetails.Rows[0]["EventDesc"].ToString();
                eventDate = objCommon.GetEventAdjustDate(Convert.ToDateTime(dtSchEventDetails.Rows[0]["EventStartDate"].ToString()), Convert.ToDateTime(dtSchEventDetails.Rows[0]["EventEndDate"].ToString()));

                if (SchEventID != 0)
                {
                    EventID = Convert.ToInt32(dtSchEventDetails.Rows[0]["Event_ID"].ToString());
                    UserID = Convert.ToInt32(dtSchEventDetails.Rows[0]["Sender_UserID"].ToString());
                    ProfileID = Convert.ToInt32(dtSchEventDetails.Rows[0]["Sender_ProfileID"].ToString());
                    contactusFlag = Convert.ToBoolean(dtSchEventDetails.Rows[0]["Contactuschecked"].ToString());
                    storelinksShare = Convert.ToBoolean(dtSchEventDetails.Rows[0]["StoreLinksChecked"].ToString());
                    if (!string.IsNullOrEmpty(dtSchEventDetails.Rows[0]["ShareEvent"].ToString()))
                    {
                        if (Request.QueryString["SI"] == null)
                        {
                            shareEvent = dtSchEventDetails.Rows[0]["ShareEvent"].ToString();
                        }
                    }
                }
                else
                {
                    ProfileID = Convert.ToInt32(dtSchEventDetails.Rows[0]["ProfileID"].ToString());
                    UserID = Convert.ToInt32(dtSchEventDetails.Rows[0]["UserID"].ToString());
                }
            }
            eventBody = "<table border='0' cellpadding='0' cellspacing='0' width='100%'><tr><td style='padding:10px;'>" + eventTitle + "</td></tr><tr><td style='padding:10px;'>" + eventDate + "</span></td></tr>";
            eventBody = eventBody + "<tr><td style='padding:20px;'>" + eventDesc + "</td></tr></table>";
            EventPreview = "<html><head></head><body><table width='750px' border='0' cellspacing='0' cellpadding='0' align='center' style='border: solid 2px #F4EBEB;'><tr><td align='right' style='padding: 10px;' colspan='2'><a href='#' onclick='CloseWindow()'><img src='" + RootPath + "/images/Dashboard/btn-close.gif' border='0' /><a></td></tr><tr><td colspan='2' style='padding: 30px;'>" + eventBody + "</td></tr>";
            unsubscribeContent = UserProfileUnsubscribeLink(ProfileID, UserID);
            if (contactusFlag == true)
            {
                string contactus = "<a href=\"" + RootPath + "/ContactUser.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&SID=" + EncryptDecrypt.DESEncrypt(EventID.ToString()) + "&ET=EC\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/contactus.gif' alt='Contact Us' border='0'/></a>";
                EventPreview = EventPreview + @"<tr><td colspan='2' align='center' style='padding:10px;'>" + contactus + "</td></tr>";
            }
            if (Request.QueryString["SI"] != null)
            {
                if (Request.QueryString["SI"].ToString() != "")
                {
                    char[] separator = new char[] { '-' };
                    string socialIcons = Request.QueryString["SI"].ToString();
                    Split = socialIcons.Split(separator);
                    if (Split[0] == "1")
                    {
                        string contactus = "<a href=\"" + RootPath + "/ContactUser.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&SID=" + EncryptDecrypt.DESEncrypt(EventID.ToString()) + "&ET=EC\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/contactus.gif' alt='Contact Us' border='0'/></a>";
                        EventPreview = EventPreview + @"<tr><td colspan='2' align='center' style='padding:10px;'>" + contactus + "</td></tr>";
                    }
                    if (Split.Length > 1 && Split[Split.Length - 1] == "1")
                    {
                        StoreLinks();
                    }
                }
            }
            else if (storelinksShare)
                StoreLinks();
            if (shareEvent != "")
            {
                EventPreview = EventPreview + @"<tr><td colspan='2' align='center' style='padding-top: 5px;'><table border='0' cellpadding='0' cellspacing='0' width='100%'><tr><td align='center'>" + shareEvent + "</td><td></td></tr></table></td></tr>";
            }
            EventPreview = EventPreview + @"<tr><td style='font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; padding:10px; width:700px; border-top: solid 1px #F4EBEB;'>" + unsubscribeContent + "</td><td align='right' valign='top' style='font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; border-top: solid 1px #F4EBEB;'><a href=\"" + RootPath + "\" target=\"_blank\"><img src='" + RootPath + "/images/VerticalLogos/" + DomainName + "emailby.gif' border='0' /></a></td></tr></table></body></html>";
            EventPreview = EventPreview.Replace("&#60;recipient's email address&#62;", EmailAddress);

            EventPreview = objCommon.ReplaceShortURltoHtmlString(EventPreview);
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "ViewEventCalendar.aspx.cs", "GetEventDetails", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private void StoreLinks()
    {
        try
        {
            string storelinks = "";
            DataTable dtStoreLinks = objBus.GetStoreDetailsById(UserID);
            if (dtStoreLinks.Rows.Count > 0)
            {
                if (Convert.ToString(dtStoreLinks.Rows[0]["IOS_Url"]) != "")
                    storelinks = "<a href=\"" + Convert.ToString(dtStoreLinks.Rows[0]["IOS_Url"]) + "\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/iosemail.png' alt='iOS Store' border='0'/></a>";
                if (Convert.ToString(dtStoreLinks.Rows[0]["Android_Url"]) != "")
                    storelinks = storelinks + "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + Convert.ToString(dtStoreLinks.Rows[0]["Android_Url"]) + "\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/androidemail.png' alt='Android Store' border='0'/></a>";
                if (Convert.ToString(dtStoreLinks.Rows[0]["Windows_Url"]) != "")
                    storelinks = storelinks + "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + Convert.ToString(dtStoreLinks.Rows[0]["Windows_Url"]) + "\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/windowsemail.png' alt='Windows Phone Store' border='0'/></a>";
                EventPreview = EventPreview + @"<tr><td style='padding:10px;' colspan='2' align='center'>" + Convert.ToString(dtStoreLinks.Rows[0]["StoreLinksTitle"]) + "</td></tr><tr><td style='padding:10px; padding:left: 50px;' colspan='2' align='center'>" + storelinks + "</td></tr>";
            }
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "ViewEventCalendar.aspx.cs", "StoreLinks", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private string UserProfileUnsubscribeLink(int profileID, int userID)
    {
        string unSubscribeLinkText = "";
        try
        {
            DataTable dtProfileAddress = objBus.GetProfileDetailsByProfileID(profileID);
            string totalAddress = "";
            string profileName = "";
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
            unSubscribeLinkText = "This message was sent from " + profileName + " to &#60;recipient's email address&#62;. It was sent from: " + totalAddress + ". If you no longer wish to receive our updates, <a href=\"" + RootPath + "/Unsubscribeupdate.aspx?ID=" + EncryptDecrypt.DESEncrypt(userID.ToString()) + "&SID=" + EncryptDecrypt.DESEncrypt(EventID.ToString()) + "\" target=\"_blank\">Click here</a> to unsubscribe.";
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "ViewEventCalendar.aspx.cs", "UserProfileUnsubscribeLink", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        return unSubscribeLinkText;
    }
}