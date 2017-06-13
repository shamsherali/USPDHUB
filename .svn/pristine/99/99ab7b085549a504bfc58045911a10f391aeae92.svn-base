using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using USPDHUBBLL;
using System.Text.RegularExpressions;
using System.Web.Services;

namespace USPDHUB.Business.MyAccount
{
    public partial class SendCalendar : BaseWeb
    {
        public string DomainName = "";
        public string RootPath = "";
        public int UserID = 0;
        public int ProfileID = 0;
        public int CUserID = 0;
        public int AppStatus = 0;
        public int MaxBusEventsCampaigns = 0;
        public string BusinessEventUsageCountstr = string.Empty;
        public int BusinessEventUsageCount = 0;
        public string ShowSocialIcons = string.Empty;
        public int CalendarAddOnID = 0;
        public DateTime dtToday;
        public int BusinessEventCount = 0;
        public int BusinessEventUsage = 0;
        public int CountTotalEmails = 0;
        public int CheckUnlimited = 0;
        public int CheckSendCount = 0;
        public int SchHisID = 0;
        public string InvalidIds = string.Empty;
        DataTable dtContacts = new DataTable();
        DataTable dtSelectedContactList = new DataTable();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        DataTable dtStoreLinks;
        DataTable dtUnlimiteduser = new DataTable("dtUnlimiteduser");
        CalendarAddOnBLL objCalendarAddOn = new CalendarAddOnBLL();
        BusinessBLL objBusinessBll = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        UtilitiesBLL objUtilitiesBll = new UtilitiesBLL();
        EventCalendarBLL objEventCalendarBll = new EventCalendarBLL();
        public bool IsEmailContact = false;
        public bool IsScheduleEmail = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                if (Session["CalendarAddOnID"] == null)
                {
                    Response.Redirect(RootPath + "/Business/MyAccount/Default.aspx");
                }
                else
                    CalendarAddOnID = Convert.ToInt32(Session["CalendarAddOnID"].ToString());
                lblmess.Text = "";
                lblEmailsch.Text = "";
                lblsendingDate.Text = "";
                lblerror.Text = "";
                UserID = Convert.ToInt32(Session["userid"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
                hdnURLPath.Value = RootPath;
                // *** Make back button visible and disable by query string 26-03-2013 *** //
                if (!string.IsNullOrEmpty(Request.QueryString["App"]))
                    AppStatus = 1;
                // Check For Unlimted Users
                lblerror.Text = "";
                MaxBusEventsCampaigns = Convert.ToInt32(ConfigurationManager.AppSettings.Get("MaxEventscampaignlimit"));

                BusinessEventUsageCount = Convert.ToInt32(GetUnlimitedEmailsCount().Replace(",", ""));
                hdnlimit.Value = BusinessEventUsageCount.ToString();
                GetRemainingEmailsCount();
                pnlApprSendDays.Attributes.Add("style", "display:none");
                pnltext.Attributes.Add("style", "display:none");

                // End
                if (objBusinessBll.CheckModulePermission(WebConstants.Purchase_Contacts_Reports, ProfileID))
                {
                    IsEmailContact = true;
                }
                if (objBusinessBll.CheckModulePermission(WebConstants.Purchase_ScheduleEmailsSetup, ProfileID))
                {
                    IsScheduleEmail = true;
                }
                else
                {
                    txtSendingDate.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy");
                    txtSendingDate.Enabled = false;
                }
                if (!IsPostBack)
                {
                    hdnuserid.Value = UserID.ToString();
                    hdnCalAddOnId.Value = CalendarAddOnID.ToString();
                    dtSelectedContactList.Columns.Clear();
                    dtSelectedContactList.Rows.Clear();
                    dtSelectedContactList.Columns.Add("contactid", typeof(Int32));
                    dtSelectedContactList.Columns.Add("firstName", typeof(string));
                    dtSelectedContactList.Columns.Add("email", typeof(string));
                    dtSelectedContactList.Columns.Add("group", typeof(string));
                    lnkSchEmail.Attributes.Add("style", "display:none");
                    dtStoreLinks = objBusinessBll.GetStoreDetailsById(UserID);
                    if (dtStoreLinks.Rows.Count > 0 && Convert.ToString(dtStoreLinks.Rows[0]["IOS_Url"]) != "")
                        chkStoreLinks.Visible = true;
                    // monthly emails
                    int totalemails = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ExistingUserEmails"));
                    DataTable dtSelectedTools = objBusinessBll.GetSelectedToolsByUserID(UserID);
                    string remaingEmailsmsg = string.Empty;
                    if (dtUnlimiteduser.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dtUnlimiteduser.Rows[0]["Event_Unlimited"].ToString()) == true)
                        {
                            totalemails = Convert.ToInt32(ConfigurationManager.AppSettings.Get("UlimitedExistingUserEmails"));
                        }
                        else if (dtSelectedTools.Rows.Count > 0)
                        {
                            totalemails = Convert.ToInt32(dtSelectedTools.Rows[0]["Total_Emails"].ToString());
                        }
                    }
                    else if (dtSelectedTools.Rows.Count > 0)
                    {
                        totalemails = Convert.ToInt32(dtSelectedTools.Rows[0]["Total_Emails"].ToString());
                    }
                    remaingEmailsmsg = "Allowed - " + totalemails.ToString() + " &nbsp;&nbsp;&nbsp;Sent - #Sent &nbsp;&nbsp;&nbsp;Remaining - #Remaining";
                    int remainingEmails = 0;
                    objCommon.RemainingScheduledEmailsCount(UserID, ProfileID, totalemails, out remainingEmails);
                    //lblRemainingEmailsCount.Text = remaingEmailsmsg.Replace("#Remaining", remainingEmails.ToString()).Replace("#Sent", (totalemails - remainingEmails).ToString());

                    hdnRemainingEmails.Value = remainingEmails.ToString();


                    string flyerPath = HttpContext.Current.Server.MapPath("~") + "\\Upload\\CalendarAddOns\\" + ProfileID.ToString();
                    flyerPath = flyerPath + "\\" + Session["CalendarId"].ToString() + ".jpg";
                    if (!System.IO.File.Exists(flyerPath))
                    {
                        lblUpdatethumb.Text = "No Event Thumbnail";
                    }
                    else
                    {
                        string imageDisID = Guid.NewGuid().ToString();
                        lblUpdatethumb.Text = "<img src='" + RootPath + "/Upload/CalendarAddOns/" + ProfileID.ToString() + "/" + Session["CalendarId"].ToString() + ".jpg?Guid=" + imageDisID + "' border='0' width='200' height='160'/>";
                    }

                }
                if (hdncheckpostback.Value != "")
                {
                    hdncheckpostback.Value = "";
                    Validateradiobutton();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetRemainingEmailsCount()
        {
            try
            {
                int countSch = objEventCalendarBll.CheckforBusinessEventSchedule(UserID);
                if (countSch > MaxBusEventsCampaigns)
                {
                    string maxSchDate = string.Empty;
                    maxSchDate = objEventCalendarBll.GetBusinessEventMaxScheduleingDate(UserID);
                    maxSchDate = maxSchDate.Replace("12:00:00 AM", "");
                    lblmess.Text = Resources.LabelMessages.AlreadyHaveBusinessEventCampaign + " " + maxSchDate + ".";
                    txtto.Enabled = false;
                }
                else
                {
                    txtto.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "GetRemainingEmailsCount", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private string GetUnlimitedEmailsCount()
        {
            DataTable dtUnlimiteduser = objEventCalendarBll.CheckForUnlimtedUserEmail(UserID);
            if (dtUnlimiteduser.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtUnlimiteduser.Rows[0]["Event_Unlimited"].ToString()) == true)
                {
                    BusinessEventUsageCountstr = ConfigurationManager.AppSettings.Get("UnlimtedUserEmailsCount");
                }
                else
                {
                    BusinessEventUsageCountstr = ConfigurationManager.AppSettings.Get("EventUsageCount");
                }
            }
            else
            {
                BusinessEventUsageCountstr = ConfigurationManager.AppSettings.Get("EventUsageCount");
            }
            return BusinessEventUsageCountstr;
        }
        protected void Validateradiobutton()
        {
            if (rbtnall.Checked == true)
            {
                ScriptManager.RegisterClientScriptBlock(lblc, this.GetType(), "CheckContr", "validateradiobutton(0)", true);
                if (txtto.Text != "")
                {
                    lnkSendmail.Attributes.Add("style", "display:''");
                    lnkSchEmail.Attributes.Add("style", "display:none");
                }
            }
            else if (rbtnemailsperday.Checked == true)
            {
                ScriptManager.RegisterClientScriptBlock(lblc, this.GetType(), "CheckContr", "validateradiobutton(1)", true);
                if (txtto.Text != "")
                {
                    lnkSendmail.Attributes.Add("style", "display:none");
                    lnkSchEmail.Attributes.Add("style", "display:''");
                }
            }
        }
        protected void lnkimportcontacts_Click(object sender, EventArgs e)
        {
            try
            {
                txtto.Text = "";
                Session["NoContact"] = null;
                dtContacts = objBusinessBll.GetAllUserContactsbyUserID(UserID, 0, "All");
                if (dtContacts.Rows.Count > 0)
                {
                    pnldiscontact.Visible = true;
                    pnlnocotnact.Visible = false;
                    ModalPopupExtender1.Show();
                }
                else
                {
                    pnldiscontact.Visible = false;
                    pnlnocotnact.Visible = true;
                    ModalPopupExtender1.Show();
                }
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "lnkimportcontacts_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void imclose_Click(object sender, ImageClickEventArgs e)
        {
            dtSelectedContactList.Dispose();
            dtSelectedContactList.Rows.Clear();
        }
        protected void btnclick_Click(object sender, EventArgs e)
        {
            try
            {
                txtto.Text = "";
                dtSelectedContactList = (DataTable)(Session["ContactTable"]);
                DataRow[] drChecked = dtSelectedContactList.Select("checkvalue=0");
                for (int i = 0; i < drChecked.Length; i++)
                {
                    dtSelectedContactList.Rows.Remove(drChecked[i]);
                }
                if (dtSelectedContactList.Rows.Count > 0)
                {

                    string contactList = string.Empty;
                    for (int i = 0; i < dtSelectedContactList.Rows.Count; i++)
                    {
                        if (contactList != "")
                        {
                            contactList = contactList + dtSelectedContactList.Rows[i]["name"].ToString() + " '" + dtSelectedContactList.Rows[i]["email"].ToString() + "'" + ", ";
                        }
                        else
                        {
                            contactList = dtSelectedContactList.Rows[i]["name"].ToString() + " '" + dtSelectedContactList.Rows[i]["email"].ToString() + "'" + ", ";
                        }
                    }
                    if (contactList != "")
                    {
                        contactList = contactList.Remove(contactList.Length - 1);
                        txtto.Text = contactList;
                    }
                }
                Session["NoContact"] = "1";
                int checkForSelectedDateCount = 0;
                int checkSch = 0;
                dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                checkForSelectedDateCount = objCalendarAddOn.CheckCalendarSendingCountforSendingDate(UserID, dtToday.Date, CalendarAddOnID);
                checkSch = objCalendarAddOn.CheckforCalendarSchedule(UserID, CalendarAddOnID);
                int checkCam = 0;
                if (checkSch > MaxBusEventsCampaigns)
                {
                    checkCam = 1;
                }

                checkSch = BusinessEventUsageCount - checkForSelectedDateCount;
                if (checkSch > 0 && checkCam != 1)
                {
                    if (BusinessEventCount < BusinessEventUsageCount)
                    {
                        string address = string.Empty;
                        address = txtto.Text;
                        address = address.Replace("\n", "");
                        address = address.Replace("\r", "");
                        CountTotalEmails = dtSelectedContactList.Rows.Count;
                        BusinessEventCount = BusinessEventUsage + CountTotalEmails + checkForSelectedDateCount;
                        if (BusinessEventCount < BusinessEventUsageCount)
                        {
                            hdncheckcontact.Value = "2";
                            ScriptManager.RegisterClientScriptBlock(btnclick, this.GetType(), "CheckContr", "CheckControls()", true);
                        }
                        else
                        {
                            hdncheckcontact.Value = "1";
                            ScriptManager.RegisterClientScriptBlock(btnclick, this.GetType(), "CheckContr", "CheckControls()", true);
                        }
                        lblselectedcontactcount.Text = CountTotalEmails.ToString();
                        hdnSelectedEmails.Value = CountTotalEmails.ToString();
                    }
                }
                else
                {
                    if (checkCam > 0)
                    {
                        string maxSchDate = string.Empty;
                        maxSchDate = objCalendarAddOn.GetCalendarMaxScheduledDate(UserID);
                        maxSchDate = maxSchDate.Replace("12:00:00 AM", "");
                        lblmess.Text = Resources.LabelMessages.AlreadyHaveBusinessUpdateCampaign + " " + maxSchDate + ".";
                    }
                    else
                    {
                        lblmess.Text = Resources.LabelMessages.sendBusinessUpdatecountExceeded;
                    }
                    txtsubject.Text = "";
                    txtto.Text = "";
                    dtSelectedContactList.Rows.Clear();
                    lnkSendmail.Attributes.Add("style", "display:none");
                    lnkSchEmail.Attributes.Add("style", "display:none");
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "btnclick_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btncancelpop_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
        protected void btnenhance_Click(object sender, EventArgs e)
        {
            string urlinfo2 = Page.ResolveClientUrl("~/Business/Myaccount/ManageContacts.aspx");
            Response.Redirect(urlinfo2);
        }
        protected void btndashboard_Click(object sender, EventArgs e)
        {
        }
        protected void rbtnemailsperday_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validateradiobutton();
        }
        protected void rbtnall_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validateradiobutton();
        }
        protected void lnkSchEmail_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToInt32(hdnRemainingEmails.Value) >= Convert.ToInt32(hdnSelectedEmails.Value))
                //{
                string emilsperdayCount = string.Empty;
                emilsperdayCount = txtemailsperday.Text.Replace(",", "");
                string strRegex = @"^(\d{0,9}(\.\d{4})?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(emilsperdayCount))
                {
                    DateTime DateSent1;
                    DateSent1 = Convert.ToDateTime(txtSendingDate.Text.Trim());
                    dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                    int showflag = CheckAvailableTimeAndEmailCount(DateSent1, dtToday);
                    if (showflag > 0)
                    {
                        SendEventSchedule(DateSent1, dtToday);
                        lnkSendmail.Attributes.Add("style", "display:''");
                        lnkSchEmail.Attributes.Add("style", "display:none");
                        txtsubject.Text = "";
                        dtSelectedContactList.Rows.Clear();
                        txtto.Text = "";
                        Response.Redirect(GetUrl());
                    }
                }
                else
                {
                    lblEmailsch.Text = ConfigurationManager.AppSettings.Get("EmailsperdayError");
                }
                //}
                //else
                //{
                //    lblerror.Text = Resources.LabelMessages.EMailsCountExceeded.Replace("#Available", lblRemainingEmailsCount.Text).Replace("#Selected", lblselectedcontactcount.Text);
                //}
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "lnkSchEmail_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private int CheckAvailableTimeAndEmailCount(DateTime dateSent, DateTime dateNow)
        {
            int showFlag = 0;
            try
            {

                int checkBusinessEventCount = 0;
                if (dateSent >= Convert.ToDateTime(dateNow.ToShortDateString()))
                {
                    CountTotalEmails = ValidateemailIDs(txtto.Text);
                    lblselectedcontactcount.Text = CountTotalEmails.ToString();
                    if (txtemailsperday.Text != "" && ddltime.SelectedIndex > 0)
                    {

                        checkBusinessEventCount = CheckEmailsCountForEvent(dateSent);
                        if (checkBusinessEventCount == 0)
                        {
                            int availableEmailCount = 0;
                            availableEmailCount = BusinessEventUsageCount - (BusinessEventUsage + Convert.ToInt32(txtemailsperday.Text.Replace(",", "")));
                            if (availableEmailCount >= 0)
                            {
                                lblEmailsch.Text = Resources.LabelMessages.SelectedBusinessEventlimitlessthanAvailablevalue;
                                if (dateSent <= dateNow)
                                {
                                    int nexthour = dateNow.Hour; // *** Removing 1 hr bacause of engine running with 3 mins interval + 1;
                                    dateSent = dateSent.AddHours(nexthour).AddMinutes(dateNow.Minute + 2);
                                }
                                if (dateNow < dateSent)
                                {
                                    showFlag = 1;
                                }
                                else
                                {
                                    showFlag = 0;
                                    lblEmailsch.Text = "Please select a date later than or equal to the current date.";
                                }
                            }
                            else
                            {
                                string availableEmailCountstr;
                                availableEmailCount = BusinessEventUsageCount - BusinessEventUsage;
                                string mess = Resources.LabelMessages.SelectedbusinesseventlimitExceedstheAvailablevalue;
                                mess = mess.Replace("#day_lmit", BusinessEventUsageCountstr);
                                mess = mess.Replace("#used", BusinessEventUsage.ToString());
                                if (availableEmailCount == 5000)
                                    availableEmailCountstr = "5,000";
                                else
                                    availableEmailCountstr = availableEmailCount.ToString();
                                mess = mess.Replace("#available", availableEmailCountstr.ToString());
                                lblEmailsch.Text = mess.ToString();
                                showFlag = 0;
                            }
                        }
                        else
                        {
                            lblEmailsch.Text = "The schedule of another item is clashing with the dates of this item. Please either choose a different date or click the \"History\" link above to view the details of all the scheduled item.";
                            showFlag = 0;
                        }
                    }
                    else
                    {
                        showFlag = 0;
                        if (txtemailsperday.Text == "" && ddltime.SelectedIndex == 0)
                        {
                            lblerror.Text = "Emails per day are mandatory.<br/>Send time is mandatory.";
                        }
                        else if (txtemailsperday.Text == "")
                        {
                            lblerror.Text = "Emails per day are mandatory.";
                        }
                        else if (ddltime.SelectedIndex == 0)
                        {
                            lblerror.Text = "Sending time is mandatory.";
                        }
                    }

                }
                else
                {
                    showFlag = 0;
                    lblEmailsch.Text = "Please select a date later than or equal to the current date.";
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "CheckAvailableTimeAndEmailCount", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return showFlag;
        }
        private int CheckEmailsCountForEvent(DateTime dateSent)
        {

            int retCountNews = 0;
            DateTime sendingDate;
            int checkSchEventEmailCount = 0;
            sendingDate = dateSent;
            string address = string.Empty;
            string[] totalAddress1;
            string splitType1 = ",";
            address = txtto.Text;
            address = address.Replace("\n", "");
            address = address.Replace("\r", "");
            totalAddress1 = address.Split(splitType1.ToCharArray());
            try
            {
                checkSchEventEmailCount = objCalendarAddOn.CheckCalendarSendingCountforSendingDate(UserID, sendingDate, CalendarAddOnID);
                if (checkSchEventEmailCount == 0 || CheckUnlimited == 1)
                {
                    if (totalAddress1.Length > 0)
                    {
                        for (int i = 0; i < totalAddress1.Length; i++)
                        {
                            if (totalAddress1[i].Length > 0)
                            {
                                string splitVal = "'";
                                string[] currentvalues;
                                string eA = totalAddress1[i].ToString();
                                currentvalues = eA.Split(splitVal.ToCharArray());
                                if (currentvalues.Length > 0)
                                {
                                    if (currentvalues.Length != 1)
                                    {
                                        if (currentvalues[1].Length > 0)
                                        {
                                            CheckSendCount++;
                                        }
                                    }
                                    else
                                    {
                                        if (currentvalues.Length == 1)
                                        {
                                            if (currentvalues[0].Length > 1)
                                            {

                                                string emailsent = currentvalues[0].ToString();
                                                emailsent = emailsent.Replace(" ", "");
                                                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                                                Regex re = new Regex(strRegex);
                                                if (re.IsMatch(emailsent))
                                                {
                                                    CheckSendCount++;
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    int value = BusinessEventUsageCount - checkSchEventEmailCount;
                    BusinessEventUsage = checkSchEventEmailCount;
                    if (value > 0)
                    {
                        retCountNews = 0;
                    }
                    else
                    {
                        retCountNews = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "CheckEmailsCountForEvent", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return retCountNews;
        }
        private string GetUrl()
        {
            string url = Page.ResolveClientUrl("~/Business/MyAccount/" + WebConstants.ManageUrl_CalendarAddOns);
            if (AppStatus == 1)
                url = Page.ResolveClientUrl("~/Business/MyAccount/" + WebConstants.ManageUrl_CalendarAddOns + "?App=1");
            return url;
        }
        private void SendEventSchedule(DateTime dateSent, DateTime dateNow)
        {
            try
            {
                int optoutCount = 0;
                DataTable dtDupContacts = new DataTable();
                DataColumn email = new DataColumn("Receiver_Email", typeof(string));
                dtDupContacts.Columns.Add(email);
                #region variable declaration
                string subject = string.Empty;
                string address = string.Empty;
                string mailids = string.Empty;
                string toEmailAdd = string.Empty;
                string eA = string.Empty;
                string groupID = string.Empty;
                string[] totalAddress;
                string[] currentvalues;
                string splitType = ",";
                string splitVal = "'";
                int schCount = Convert.ToInt32(txtemailsperday.Text.Replace(",", ""));
                int countSchEmails = 0;
                int addDays = 0;
                DateTime schDate;
                DateTime schCurrrent = dateSent;
                string shareCalendar = string.Empty;

                string selectedtime = string.Empty;
                int domainID = 1;
                #endregion
                DataTable dtDomain = objCommon.GetDomainDetails(DomainName);
                if (dtDomain.Rows.Count == 1)
                {
                    domainID = Convert.ToInt32(dtDomain.Rows[0]["Domain_ID"].ToString());
                }

                address = txtto.Text;
                address = address.Replace("\n", "");
                address = address.Replace("\r", "");
                subject = txtsubject.Text;

                totalAddress = address.Split(splitType.ToCharArray());
                if (totalAddress.Length > 0)
                {
                    DataTable dtcurrentcontacts = Session["ContactTable"] == null ? null : (DataTable)(Session["ContactTable"]);
                    if (dtcurrentcontacts != null)
                    {
                        if (dtcurrentcontacts.Rows.Count > 0)
                        {
                            DataRow[] drChecked = dtcurrentcontacts.Select("checkvalue=0");
                            for (int i = 0; i < drChecked.Length; i++)
                            {
                                dtcurrentcontacts.Rows.Remove(drChecked[i]);
                            }
                        }
                    }
                    SchHisID = Convert.ToInt32(Session["CalendarId"].ToString());
                    bool contactusChecked = true;
                    if (chkContactus.Checked == false)
                    {
                        contactusChecked = false;
                    }
                    if (schCurrrent <= dateNow)
                    {
                        int nexthour = dateNow.Hour; // *** Removing 1 hr bacause of engine running with 3 mins interval + 1;
                        schCurrrent = schCurrrent.AddHours(nexthour).AddMinutes(dateNow.Minute + 2); ;
                    }
                    schCurrrent = objCommon.GetScheduleDateInPST(ProfileID, schCurrrent);
                    for (int i = 0; i < totalAddress.Length; i++)
                    {
                        if (countSchEmails >= schCount)
                        {
                            countSchEmails = 0;
                            addDays++;
                        }
                        if (totalAddress[i].Length > 0)
                        {


                            eA = totalAddress[i].ToString();
                            currentvalues = eA.Split(splitVal.ToCharArray());
                            if (addDays != 0)
                            {
                                schDate = schCurrrent.AddDays(addDays);
                            }
                            else
                            {
                                schDate = schCurrrent;
                            }
                            if (currentvalues.Length > 0)
                            {
                                if (currentvalues.Length != 1)
                                {
                                    if (currentvalues[1].Length > 0)
                                    {
                                        toEmailAdd = currentvalues[1].ToString();
                                        groupID = string.Empty;
                                        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                                        Regex re = new Regex(strRegex);
                                        if (re.IsMatch(toEmailAdd))
                                        {
                                            if (dtcurrentcontacts != null)
                                            {
                                                if (dtcurrentcontacts.Rows.Count > 0)
                                                {
                                                    DataRow[] dr = dtcurrentcontacts.Select("email='" + toEmailAdd + "' and checkvalue=1");
                                                    if (dtcurrentcontacts.Rows.Count > 0)
                                                    {

                                                        int chVa = 0;
                                                        for (chVa = 0; chVa < dr.Length; chVa++)
                                                        {
                                                            string findChValue = dr[chVa]["checkvalue"].ToString();
                                                            groupID = dr[chVa]["Contact_group_ID"].ToString();
                                                            if (findChValue == "1")
                                                            {
                                                                DataRow dRUpdate = dtcurrentcontacts.Rows.Find(dr[chVa]["contactid"]);

                                                                if (dRUpdate != null)
                                                                {
                                                                    dRUpdate["checkvalue"] = 0;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (toEmailAdd != "")
                                            {
                                                int optFlag = 0;
                                                optFlag = objBusinessBll.CheckForEmailOptFlagCount(toEmailAdd, Convert.ToInt32(Session["UserID"].ToString()));

                                                if (optFlag == 0)
                                                {
                                                    if (groupID == "")
                                                    {
                                                        groupID = "13";
                                                    }
                                                    // *** Issue 986 *** //
                                                    int dupflag = 0;
                                                    if (chkduplicatecont.Checked)
                                                    {
                                                        string dupcontact = "0";
                                                        DataRow[] filterDupcontact = dtDupContacts.Select("Receiver_Email='" + toEmailAdd + "'");
                                                        dupcontact = filterDupcontact.Length.ToString();
                                                        if (dupcontact == "0")
                                                        {
                                                            dupflag = 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        dupflag = 1;
                                                    }
                                                    if (dupflag == 1)
                                                    {
                                                        DataRow dr = dtDupContacts.NewRow();
                                                        dr["Receiver_Email"] = toEmailAdd;
                                                        dtDupContacts.Rows.Add(dr);
                                                        objCalendarAddOn.InsertCalendarScheduleDetails(SchHisID, ProfileID, UserID, subject, toEmailAdd, schDate, schDate.Date, 0, false, groupID, contactusChecked, shareCalendar, CUserID, domainID, chkStoreLinks.Checked);
                                                        countSchEmails++;
                                                        CountTotalEmails++;
                                                    }
                                                }
                                                else
                                                {
                                                    optoutCount = optoutCount + 1;
                                                }
                                                if (mailids.Length == 0)
                                                {
                                                    mailids = toEmailAdd;
                                                }
                                                else
                                                {
                                                    mailids = mailids + ", " + toEmailAdd;
                                                }


                                            }
                                        }
                                        else
                                        {
                                            if (InvalidIds.Length == 0)
                                            {
                                                InvalidIds = currentvalues[0].ToString();
                                            }
                                            else
                                            {
                                                InvalidIds = InvalidIds + ", " + currentvalues[0].ToString();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (currentvalues.Length == 1)
                                    {
                                        if (currentvalues[0].Length > 1)
                                        {

                                            string emailsent = currentvalues[0].ToString();
                                            emailsent = emailsent.Replace(" ", "");
                                            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                                            Regex re = new Regex(strRegex);
                                            if (re.IsMatch(emailsent))
                                            {
                                                string groupID1 = string.Empty;
                                                DataTable dtcon = new DataTable();
                                                dtcon = objCommon.GetcontactgroupnameforEmailID(emailsent, UserID);
                                                if (dtcon.Rows.Count > 0)
                                                {
                                                    groupID1 = dtcon.Rows[0]["Contact_Group_ID"].ToString();
                                                }
                                                else
                                                {
                                                    groupID1 = "13";
                                                }
                                                int checkEmail = 0;
                                                checkEmail = objBusinessBll.CheckEmailIDForDefaultGroup(emailsent, UserID);
                                                if (checkEmail == 0)
                                                {
                                                    char[] seperator = new char[1];
                                                    seperator[0] = '@';
                                                    string[] emailid = new string[2];
                                                    emailid = emailsent.Split(seperator);
                                                    string firstname = emailid[0].ToString();
                                                    objBusinessBll.AddUserContactDetails(firstname, string.Empty, emailsent, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "Self", UserID, DateTime.Today.Date, "13", string.Empty, CUserID);
                                                }
                                                int optFlag = 0;

                                                optFlag = objBusinessBll.CheckForEmailOptFlagCount(emailsent, Convert.ToInt32(Session["UserID"].ToString()));
                                                if (optFlag == 0)
                                                {
                                                    // *** Issue 986 *** //
                                                    int dupflag = 0;
                                                    if (chkduplicatecont.Checked)
                                                    {
                                                        string dupcontact = "0";
                                                        DataRow[] filterDupcontact = dtDupContacts.Select("Receiver_Email='" + emailsent + "'");
                                                        dupcontact = filterDupcontact.Length.ToString();
                                                        if (dupcontact == "0")
                                                        {
                                                            dupflag = 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        dupflag = 1;
                                                    }
                                                    if (dupflag == 1)
                                                    {
                                                        DataRow dr = dtDupContacts.NewRow();
                                                        dr["Receiver_Email"] = emailsent;
                                                        dtDupContacts.Rows.Add(dr);
                                                        objCalendarAddOn.InsertCalendarScheduleDetails(SchHisID, ProfileID, UserID, subject, emailsent, schDate, schDate.Date, 0, false, groupID1, contactusChecked, shareCalendar, CUserID, domainID, chkStoreLinks.Checked);
                                                        countSchEmails++;
                                                        CountTotalEmails++;
                                                    }
                                                }
                                                else
                                                {
                                                    optoutCount = optoutCount + 1;
                                                }
                                                if (mailids.Length == 0)
                                                {
                                                    mailids = emailsent;
                                                }
                                                else
                                                {
                                                    mailids = mailids + ", " + emailsent;
                                                }
                                            }
                                            else
                                            {
                                                if (InvalidIds.Length == 0)
                                                {
                                                    InvalidIds = currentvalues[0].ToString();
                                                }
                                                else
                                                {
                                                    InvalidIds = InvalidIds + ", " + currentvalues[0].ToString();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    objEventCalendarBll.UpdateAutoEmailToAdminFalg(UserID, SchHisID, "CA", CUserID);
                    Session["CalendarId"] = null;
                    Session["CalendarDes"] = null;
                    Session["EventSend"] = "2";
                    if (countSchEmails == 0 & InvalidIds.Length > 0)
                    {
                        Session["CheckEventMess"] = "1";
                    }
                    else if (countSchEmails == 0 & optoutCount > 0)
                    {
                        Session["CheckEventMess"] = "5";
                    }
                    else if (countSchEmails > 0 & InvalidIds.Length > 0)
                    {
                        Session["CheckEventMess"] = "2";
                        Session["invalidEventEmailID"] = InvalidIds;
                    }
                    else if (countSchEmails > 0 & optoutCount > 0)
                    {
                        Session["CheckEventMess"] = "4";
                    }
                    else if (countSchEmails > 0 & InvalidIds.Length == 0 & optoutCount == 0)
                    {
                        Session["CheckEventMess"] = "3";
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "SendEventSchedule", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkSendmail_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToInt32(hdnRemainingEmails.Value) >= Convert.ToInt32(hdnSelectedEmails.Value))
                //{
                if (ddltime.SelectedIndex > 0)
                {
                    DateTime dateSent1;
                    dateSent1 = Convert.ToDateTime(txtSendingDate.Text.Trim());
                    dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                    if (dateSent1 <= dtToday)
                    {
                        int nexthour = dtToday.Hour; // *** Removing 1 hr bacause of engine running with 3 mins interval + 1;
                        dateSent1 = dateSent1.AddHours(nexthour).AddMinutes(dtToday.Minute + 2); ;
                    }
                    if (dateSent1 > dtToday)
                    {
                        ValidateCampaign(dateSent1, dtToday);
                    }
                    else
                    {
                        lblerror.Text = "Please select a date later than or equal to the current date.";
                    }
                }
                else
                {
                    lblerror.Text = "Sending time is mandatory.";
                }
                //}
                //else
                //{
                //    lblerror.Text = Resources.LabelMessages.EMailsCountExceeded.Replace("#Available", lblRemainingEmailsCount.Text).Replace("#Selected", lblselectedcontactcount.Text);
                //}
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "lnkSendmail_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void ValidateCampaign(DateTime dateSent, DateTime dateNow)
        {
            try
            {
                if (dateSent.Date >= dateNow.Date)
                {
                    int checkForSelectedDateCount = 0;
                    int checkSch = 0;
                    checkForSelectedDateCount = objCalendarAddOn.CheckCalendarSendingCountforSendingDate(UserID, dateSent, CalendarAddOnID);
                    checkSch = objCalendarAddOn.CheckforCalendarSchedule(UserID);
                    int checkCam = 0;
                    if (checkSch > MaxBusEventsCampaigns)
                    {
                        checkCam = 1;
                    }

                    checkSch = BusinessEventUsageCount - checkForSelectedDateCount;
                    if (checkSch > 0 && checkCam != 1)
                    {
                        string address = string.Empty;
                        address = txtto.Text;
                        address = address.Replace("\n", "");
                        address = address.Replace("\r", "");
                        CountTotalEmails = ValidateemailIDs(address);
                        BusinessEventCount = BusinessEventUsage + CountTotalEmails + checkForSelectedDateCount;
                        if (BusinessEventCount < BusinessEventUsageCount)
                        {
                            BusinessEventCount = BusinessEventUsage;
                            BusinessEventUsage = 0;
                            SendMailtoSelectedContacts(dateSent);
                            dtSelectedContactList.Rows.Clear();
                            txtsubject.Text = "";
                            txtto.Text = "";
                            Response.Redirect(GetUrl());
                        }
                        else
                        {
                            lblselectedcontactcount.Text = CheckSendCount.ToString();
                            hdncheckcontact.Value = "1";
                            ScriptManager.RegisterClientScriptBlock(btnclick, this.GetType(), "CheckContr", "CheckControls()", true);
                        }
                    }
                    else
                    {
                        if (checkCam > 0)
                        {
                            string maxSchDate = string.Empty;
                            maxSchDate = objCalendarAddOn.GetCalendarMaxScheduledDate(UserID);
                            maxSchDate = maxSchDate.Replace("12:00:00 AM", "");
                            lblmess.Text = Resources.LabelMessages.AlreadyHaveBusinessEventCampaign + " " + maxSchDate + ".";
                        }
                        else
                        {
                            lblmess.Text = Resources.LabelMessages.sendBusinessEventcountExceeded;
                        }
                        txtsubject.Text = "";
                        txtto.Text = "";
                        dtSelectedContactList.Rows.Clear();

                    }
                }
                else
                {
                    lblmess.Text = "Please select a date later than or equal to the current date.";
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "ValidateCampaign", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void SendMailtoSelectedContacts(DateTime dateSent)
        {
            string subject = string.Empty;
            subject = txtsubject.Text;
            int sendCount = 0;
            int optoutCount = 0;
            DataTable dtDupContacts = new DataTable();
            DataColumn email = new DataColumn("Receiver_Email", typeof(string));
            dtDupContacts.Columns.Add(email);
            DateTime schCurrent;
            schCurrent = dateSent;
            int domainID = 1;
            try
            {
                DataTable dtDomain = objCommon.GetDomainDetails(DomainName);
                if (dtDomain.Rows.Count == 1)
                {
                    domainID = Convert.ToInt32(dtDomain.Rows[0]["Domain_ID"].ToString());
                }
                string address = string.Empty;
                string[] totalAddress;
                string splitType = ",";
                address = txtto.Text;
                address = address.Replace("\n", "");
                address = address.Replace("\r", "");
                totalAddress = address.Split(splitType.ToCharArray());
                if (totalAddress.Length > 0)
                {
                    BusinessEventUsage = 0;
                    DataTable dtcurrentcontacts = new DataTable();
                    dtcurrentcontacts = (DataTable)(Session["ContactTable"]);
                    if (dtcurrentcontacts != null)
                    {
                        if (dtcurrentcontacts.Rows.Count > 0)
                        {
                            DataRow[] drChecked = dtcurrentcontacts.Select("checkvalue=0");
                            for (int i = 0; i < drChecked.Length; i++)
                            {
                                dtcurrentcontacts.Rows.Remove(drChecked[i]);
                            }
                        }
                    }
                    SchHisID = Convert.ToInt32(Session["CalendarId"].ToString());
                    bool contactusChecked = true;
                    if (chkContactus.Checked == false)
                    {
                        contactusChecked = false;
                    }
                    schCurrent = objCommon.GetScheduleDateInPST(ProfileID, schCurrent);
                    for (int i = 0; i < totalAddress.Length; i++)
                    {
                        if (totalAddress[i].Length > 0)
                        {
                            string splitVal = "'";
                            string[] currentvalues;
                            string eA = totalAddress[i].ToString();
                            currentvalues = eA.Split(splitVal.ToCharArray());

                            if (currentvalues.Length > 0)
                            {
                                if (currentvalues.Length != 1)
                                {
                                    if (currentvalues[1].Length > 0)
                                    {
                                        string toEmailAdd = currentvalues[1].ToString();
                                        string groupID = string.Empty;
                                        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                                        Regex re = new Regex(strRegex);
                                        if (re.IsMatch(toEmailAdd))
                                        {
                                            if (dtcurrentcontacts != null)
                                            {
                                                if (dtcurrentcontacts.Rows.Count > 0)
                                                {
                                                    DataRow[] dr = dtcurrentcontacts.Select("email='" + toEmailAdd + "' and checkvalue=1");
                                                    if (dtcurrentcontacts.Rows.Count > 0)
                                                    {

                                                        int chVa = 0;
                                                        for (chVa = 0; chVa < dr.Length; chVa++)
                                                        {
                                                            string findChValue = dr[chVa]["checkvalue"].ToString();
                                                            groupID = dr[chVa]["Contact_group_ID"].ToString();
                                                            if (findChValue == "1")
                                                            {
                                                                DataRow dRUpdate = dtcurrentcontacts.Rows.Find(dr[chVa]["contactid"]);

                                                                if (dRUpdate != null)
                                                                {
                                                                    dRUpdate["checkvalue"] = 0;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (toEmailAdd != "")
                                            {
                                                if (BusinessEventUsage < BusinessEventUsageCount)
                                                {
                                                    if (groupID == "")
                                                    {
                                                        groupID = "13";
                                                    }
                                                    int optFlag = 0;
                                                    optFlag = objBusinessBll.CheckForEmailOptFlagCount(toEmailAdd, Convert.ToInt32(Session["UserID"].ToString()));
                                                    if (optFlag == 0)
                                                    {
                                                        // *** Issue 986 *** //
                                                        int dupflag = 0;
                                                        if (chkduplicatecont.Checked)
                                                        {
                                                            string dupcontact = "0";
                                                            DataRow[] filterDupcontact = dtDupContacts.Select("Receiver_Email='" + toEmailAdd + "'");
                                                            dupcontact = filterDupcontact.Length.ToString();
                                                            if (dupcontact == "0")
                                                            {
                                                                dupflag = 1;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            dupflag = 1;
                                                        }
                                                        if (dupflag == 1)
                                                        {
                                                            DataRow dr = dtDupContacts.NewRow();
                                                            dr["Receiver_Email"] = toEmailAdd;
                                                            dtDupContacts.Rows.Add(dr);
                                                            objCalendarAddOn.InsertCalendarScheduleDetails(SchHisID, ProfileID, UserID, subject, toEmailAdd, schCurrent, DateTime.Now.Date, 0, true, groupID, contactusChecked, "", CUserID, domainID, chkStoreLinks.Checked);
                                                            BusinessEventUsage++;
                                                            sendCount++;
                                                        }
                                                        // *** End Issue 986 *** //
                                                    }
                                                    else
                                                    {
                                                        optoutCount = optoutCount + 1;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (InvalidIds.Length == 0)
                                            {
                                                InvalidIds = currentvalues[0].ToString();
                                            }
                                            else
                                            {
                                                InvalidIds = InvalidIds + ", " + currentvalues[0].ToString();
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    if (currentvalues.Length == 1)
                                    {
                                        if (currentvalues[0].Length > 1)
                                        {

                                            string emailsent = currentvalues[0].ToString();
                                            emailsent = emailsent.Replace(" ", "");
                                            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                                            Regex re = new Regex(strRegex);
                                            if (re.IsMatch(emailsent))
                                            {
                                                string groupID = string.Empty;
                                                DataTable dtcon = objCommon.GetcontactgroupnameforEmailID(emailsent, UserID);
                                                if (dtcon.Rows.Count > 0)
                                                {
                                                    groupID = dtcon.Rows[0]["Contact_Group_ID"].ToString();
                                                }
                                                else
                                                {
                                                    groupID = "13";
                                                }
                                                if (BusinessEventUsage < BusinessEventUsageCount)
                                                {
                                                    int checkEmail = 0;
                                                    checkEmail = objBusinessBll.CheckEmailIDForDefaultGroup(emailsent, UserID);
                                                    if (checkEmail == 0)
                                                    {
                                                        char[] seperator = new char[1];
                                                        seperator[0] = '@';
                                                        string[] emailid = new string[2];
                                                        emailid = emailsent.Split(seperator);
                                                        string firstname = emailid[0].ToString();
                                                        objBusinessBll.AddUserContactDetails(firstname, string.Empty, emailsent, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "Self", UserID, DateTime.Today.Date, "13", string.Empty, CUserID);
                                                    }
                                                    int optFlag = 0;
                                                    optFlag = objBusinessBll.CheckForEmailOptFlagCount(emailsent, Convert.ToInt32(Session["UserID"].ToString()));
                                                    if (optFlag == 0)
                                                    {
                                                        int dupflag = 0;
                                                        if (chkduplicatecont.Checked)
                                                        {
                                                            string dupcontact = "0";
                                                            DataRow[] filterDupcontact = dtDupContacts.Select("Receiver_Email='" + emailsent + "'");
                                                            dupcontact = filterDupcontact.Length.ToString();
                                                            if (dupcontact == "0")
                                                            {
                                                                dupflag = 1;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            dupflag = 1;
                                                        }
                                                        if (dupflag == 1)
                                                        {
                                                            DataRow dr = dtDupContacts.NewRow();
                                                            dr["Receiver_Email"] = emailsent;
                                                            dtDupContacts.Rows.Add(dr);
                                                            objCalendarAddOn.InsertCalendarScheduleDetails(SchHisID, ProfileID, UserID, subject, emailsent, schCurrent, DateTime.Now.Date, 0, true, groupID, contactusChecked, "", CUserID, domainID, chkStoreLinks.Checked);
                                                            BusinessEventUsage++;
                                                            sendCount++;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        optoutCount = optoutCount + 1;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (InvalidIds.Length == 0)
                                                {
                                                    InvalidIds = currentvalues[0].ToString();
                                                }
                                                else
                                                {
                                                    InvalidIds = InvalidIds + ", " + currentvalues[0].ToString();
                                                }

                                            }

                                        }
                                    }
                                }
                            }
                        }
                        objEventCalendarBll.UpdateAutoEmailToAdminFalg(UserID, SchHisID, "EC", CUserID);
                        Session["CalendarId"] = null;
                        Session["CalendarDes"] = null;
                        Session["EventSend"] = "1";
                        if (sendCount == 0 & InvalidIds.Length > 0)
                        {
                            Session["CheckEventMess"] = "1";
                        }
                        else if (sendCount == 0 & optoutCount > 0)
                        {
                            Session["CheckEventMess"] = "5";
                        }
                        else if (sendCount > 0 & InvalidIds.Length > 0)
                        {
                            Session["CheckEventMess"] = "2";
                            Session["invalidEventEmailID"] = InvalidIds;
                        }
                        else if (sendCount > 0 & optoutCount > 0)
                        {
                            Session["CheckEventMess"] = "4";
                        }
                        else if (sendCount > 0 & InvalidIds.Length == 0 & optoutCount == 0)
                        {
                            Session["CheckEventMess"] = "3";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "SendMailtoSelectedContacts", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnktestbusinessUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                txttestemail.Text = "";
                ModalPopupExtender4.Show();
                DataTable dt = objBusinessBll.GetUserDetailsByUserID(UserID);
                if (dt.Rows.Count > 0)
                {
                    txttestemail.Text = dt.Rows[0]["User_email"].ToString();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "lnktestbusinessUpdate_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btntestsend_Click(object sender, EventArgs e)
        {
            DataTable dtEventDetails = new DataTable();
            string contactus = string.Empty;
            string previewHtml = string.Empty;
            string unUsbscribeLink = string.Empty;
            string eventTitle = string.Empty;
            string dtEventStartDate = string.Empty;
            string dtEventEndDate = string.Empty;
            try
            {
                dtEventDetails = objCalendarAddOn.GetCalendarAddOnDetails(Convert.ToInt32(Session["CalendarId"].ToString()));
                if (dtEventDetails.Rows.Count > 0)
                {
                    previewHtml = dtEventDetails.Rows[0]["EventDesc"].ToString();
                    previewHtml = objCommon.ReplaceShortURltoHtmlString(previewHtml);
                    eventTitle = dtEventDetails.Rows[0]["EventTitle"].ToString();
                    dtEventStartDate = Convert.ToDateTime(dtEventDetails.Rows[0]["EventStartDate"].ToString()).ToString("MMM dd yyyy hh:mm tt");
                    dtEventEndDate = Convert.ToDateTime(dtEventDetails.Rows[0]["EventEndDate"].ToString()).ToString("MMM dd yyyy hh:mm tt");
                    unUsbscribeLink = UserProfileUnsubscribeLink();
                    contactus = "<a href=\"" + RootPath + "/ContactUser.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&SID=" + EncryptDecrypt.DESEncrypt(Session["CalendarId"].ToString()) + "&ET=CA\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/contactus.gif' alt='Contact Us' border='0'/></a>";
                    previewHtml = "<html><head></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='border: solid 2px #F4EBEB;'><tr><td colspan='2' align='center' style='height: 30px; padding: 7px;'>Problems viewing? Click <a href=\"" + RootPath + "/ViewCalendar.aspx?SID=" + EncryptDecrypt.DESEncrypt(Session["CalendarId"].ToString()) + "&REA=" + EncryptDecrypt.DESEncrypt(txttestemail.Text.Trim()) + "&SI=#ShowSocialIcons#\"><span style='color: Green;'>here</span></a> to view it online.</td></tr><tr><td colspan='2' style='padding:10px;'>" + eventTitle + "</td></tr> <tr><td colspan='2' style='padding:10px;'>" + dtEventStartDate + " to " + dtEventEndDate + "</td></tr><tr><td colspan='2' style='padding:20px;'>" + previewHtml + "</td></tr>";
                    if (chkContactus.Checked == true)
                    {
                        ShowSocialIcons = "1-" + ShowSocialIcons;
                        previewHtml = previewHtml + @"<tr><td colspan='2' align='center' style='padding:10px;'>" + contactus + "</td></tr>";
                    }
                    else
                    {
                        ShowSocialIcons = "0-" + ShowSocialIcons;
                    }
                    if (chkStoreLinks.Checked)
                    {
                        string storelinks = "";
                        dtStoreLinks = objBusinessBll.GetStoreDetailsById(UserID);
                        if (dtStoreLinks.Rows.Count > 0)
                        {
                            if (Convert.ToString(dtStoreLinks.Rows[0]["IOS_Url"]) != "")
                                storelinks = "<a href=\"" + Convert.ToString(dtStoreLinks.Rows[0]["IOS_Url"]) + "\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/iosemail.png' alt='iOS Store' border='0'/></a>";
                            if (Convert.ToString(dtStoreLinks.Rows[0]["Android_Url"]) != "")
                                storelinks = storelinks + "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + Convert.ToString(dtStoreLinks.Rows[0]["Android_Url"]) + "\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/androidemail.png' alt='Android Store' border='0'/></a>";
                            if (Convert.ToString(dtStoreLinks.Rows[0]["Windows_Url"]) != "")
                                storelinks = storelinks + "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + Convert.ToString(dtStoreLinks.Rows[0]["Windows_Url"]) + "\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/windowsemail.png' alt='Windows Phone Store' border='0'/></a>";
                            previewHtml = previewHtml + @"<tr><td style='padding:10px;' colspan='2' align='center'>" + Convert.ToString(dtStoreLinks.Rows[0]["StoreLinksTitle"]) + "</td></tr><tr><td style='padding:10px; padding:left: 50px;' colspan='2' align='center'>" + storelinks + "</td></tr>";
                            ShowSocialIcons = ShowSocialIcons + "1";
                        }
                        else
                            ShowSocialIcons = ShowSocialIcons + "0";
                    }
                    else
                        ShowSocialIcons = ShowSocialIcons + "0";
                    previewHtml = previewHtml + @"<tr><td style='font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; padding:10px; border-top: solid 1px #F4EBEB;'>" + unUsbscribeLink + "</td><td align='right'style='font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; border-top: solid 1px #F4EBEB;'><a href=\"" + RootPath + "\" target=\"_blank\"><img src='" + RootPath + "/images/VerticalLogos/" + DomainName + "emailby.gif' border='0' /></a></td></tr></table></body></html>";
                    previewHtml = previewHtml.Replace("#ShowSocialIcons#", ShowSocialIcons);
                    string businessEventBody = previewHtml;
                    string emailAddress = string.Empty;
                    string emailSubject = string.Empty;
                    emailAddress = txttestemail.Text.Trim();
                    string fromEmailsupport = "";
                    DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                    if (dtConfigsemails.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtConfigsemails.Rows)
                        {
                            if (row[0].ToString() == "EmailFrom")
                                fromEmailsupport = row[1].ToString();
                        }
                    }
                    businessEventBody = businessEventBody.Replace("&#60;recipient's email address&#62;", emailAddress);
                    emailSubject = txtMailSubject.Text;
                    bool result = objUtilitiesBll.SendCompaignMail(fromEmailsupport, emailAddress, emailSubject, businessEventBody, string.Empty, Convert.ToString(Session["ProfileName"]), DomainName);
                    if (result)
                    {
                        ModalPopupExtender4.Hide();
                        lblmess.Text = "Your test item has been sent successfully.";
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "btntestsend_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkCancelMail_Click(object sender, EventArgs e)
        {
            Session["CalendarId"] = null;
            Session["CalendarDes"] = null;
            Response.Redirect(GetUrl());
        }
        private string UserProfileUnsubscribeLink()
        {
            string unSubscribeLinkText = string.Empty;
            try
            {
                DataTable dtProfileAddress = objBusinessBll.GetProfileDetailsByProfileID(ProfileID);
                string totalAddress = string.Empty;

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

                unSubscribeLinkText = "This message was sent from " + profileName + " to &#60;recipient's email address&#62;. It was sent from: " + totalAddress + ". If you no longer wish to receive our events, <a href=\"" + RootPath + "/UnsubscribeCalendar.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&SID=" + EncryptDecrypt.DESEncrypt(Session["CalendarId"].ToString()) + "\">Click here</a> to unsubscribe.";

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "UserProfileUnsubscribeLink", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return unSubscribeLinkText;
        }
        protected int ValidateemailIDs(string address)
        {

            string[] totalAddress1;
            string mailids = string.Empty;
            string splitType1 = ",";
            totalAddress1 = address.Split(splitType1.ToCharArray());
            //----Check wether No of Emails are greater than or equal to daylimit or not--
            int countTotalEmails1 = 0;
            try
            {
                if (totalAddress1.Length > 0)
                {
                    for (int i = 0; i < totalAddress1.Length; i++)
                    {
                        if (totalAddress1[i].Length > 0)
                        {
                            string splitVal = "'";
                            string[] currentvalues;
                            string eA = totalAddress1[i].ToString();
                            currentvalues = eA.Split(splitVal.ToCharArray());
                            if (currentvalues.Length > 0)
                            {
                                if (currentvalues.Length != 1)
                                {
                                    if (currentvalues[1].Length > 0)
                                    {
                                        string toEmailAdd = currentvalues[1].ToString();
                                        countTotalEmails1++;
                                        if (mailids.Length == 0)
                                        {
                                            mailids = toEmailAdd;
                                        }
                                        else
                                        {
                                            mailids = mailids + ", " + toEmailAdd;
                                        }

                                    }
                                }
                                else
                                {
                                    if (currentvalues.Length == 1)
                                    {
                                        if (currentvalues[0].Length > 1)
                                        {

                                            string emailsent = currentvalues[0].ToString();
                                            emailsent = emailsent.Replace(" ", "");
                                            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                                            Regex re = new Regex(strRegex);
                                            if (re.IsMatch(emailsent))
                                            {
                                                if (mailids.Length == 0)
                                                {
                                                    mailids = emailsent;
                                                }
                                                else
                                                {
                                                    mailids = mailids + ", " + emailsent;
                                                }
                                                countTotalEmails1++;
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendCalendar.aspx.cs", "ValidateemailIDs", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return countTotalEmails1;
        }
        [WebMethod]
        public static int ValidateSendrSchedule(string address, string userid, string calAddOnId, string daylimit)
        {
            SendCalendar bms = new SendCalendar();
            int userID1 = Convert.ToInt32(userid);
            int checkForSelectedDateCount = 0;
            CalendarAddOnBLL cal = new CalendarAddOnBLL();
            CommonBLL objCommon = new CommonBLL();
            DateTime dtToday = objCommon.ConvertToUserTimeZone(Convert.ToInt32(HttpContext.Current.Session["ProfileID"].ToString()));
            checkForSelectedDateCount = cal.CheckCalendarSendingCountforSendingDate(userID1, dtToday.Date, Convert.ToInt32(calAddOnId));
            int businessEventUsageCount1 = Convert.ToInt32(daylimit);
            address = address.Replace("\n", "");
            address = address.Replace("\r", "");
            int countTotalEmails1 = bms.ValidateemailIDs(address);
            int businessEventCount1 = countTotalEmails1 + checkForSelectedDateCount;
            if (businessEventCount1 < businessEventUsageCount1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
    }
}