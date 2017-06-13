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
    public partial class SendUpdates : BaseWeb
    {
        public int UserID = 0;
        DataTable dtContacts = new DataTable();
        DataTable dtSelectedContactList = new DataTable();
        public int BusinessUpdateUsageCount = 0;
        public int BusinessUpdateCount = 0;
        public int BusinessUpdateUsage = 0;
        public int ProfileID = 0;
        public string InvalidIds = string.Empty;
        public int CountTotalEmails = 0;
        public int SchHisID = 0;
        public int CheckSendCount = 0;
        public int CheckUnlimited = 0;
        public int MaxBusUpdatesCampaigns = 0;
        public string BusinessUpdateUsageCountstr = string.Empty;
        BusinessBLL objBus = new BusinessBLL();
        BusinessUpdatesBLL objBusUpdate = new BusinessUpdatesBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        public string ShowSocialIcons = string.Empty;
        public int CUserID = 0;
        public int AppStatus = 0;
        public string RootPath = "";
        public string DomainName = "";
        public DateTime dtToday;
        protected void Page_Load(object sender, EventArgs e)
        {

            lblmess.Text = "";
            lblEmailsch.Text = "";
            lblsendingDate.Text = "";
            lblerror.Text = "";
            try
            {

                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    UserID = Convert.ToInt32(Session["userid"].ToString());
                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());

                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                        CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        CUserID = UserID;
                }
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                // *** Make back button visible and disable by query string 26-03-2013 *** //
                if (!string.IsNullOrEmpty(Request.QueryString["App"]))
                    AppStatus = 1;
                MaxBusUpdatesCampaigns = Convert.ToInt32(ConfigurationManager.AppSettings.Get("MaxBusUpdatescampaignlimit"));
                BusinessUpdateUsageCountstr = ConfigurationManager.AppSettings.Get("BusinessUpdateUsageCount");
                BusinessUpdateUsageCount = Convert.ToInt32(BusinessUpdateUsageCountstr.Replace(",", ""));
                hdnlimit.Value = BusinessUpdateUsageCount.ToString();
                hdnuserid.Value = UserID.ToString();
                int countSch = objBusUpdate.CheckforBusinessUpdateSchedule(UserID);
                if (countSch > MaxBusUpdatesCampaigns)
                {
                    string maxSchDate = string.Empty;
                    maxSchDate = objBusUpdate.GetBusinessUpdateMaxScheduleingDate(UserID);
                    maxSchDate = maxSchDate.Replace("12:00:00 AM", "");
                    lblmess.Text = Resources.LabelMessages.AlreadyHaveBusinessUpdateCampaign + " " + maxSchDate + ".";
                    txtto.Enabled = false;
                }
                else
                {
                    txtto.Enabled = true;
                }
                pnlApprSendDays.Attributes.Add("style", "display:none");
                pnltext.Attributes.Add("style", "display:none");
                hdnURLPath.Value = RootPath;
                // End
                if (!IsPostBack)
                {
                    dtSelectedContactList.Columns.Clear();
                    dtSelectedContactList.Rows.Clear();
                    dtSelectedContactList.Columns.Add("contactid", typeof(Int32));
                    dtSelectedContactList.Columns.Add("firstName", typeof(string));
                    dtSelectedContactList.Columns.Add("email", typeof(string));
                    dtSelectedContactList.Columns.Add("group", typeof(string));
                    lnkSchEmail.Attributes.Add("style", "display:none");
                    string flyerPath = HttpContext.Current.Server.MapPath("~") + "\\Upload\\Updates\\" + ProfileID.ToString();
                    flyerPath = flyerPath + "\\" + Session["BusinessUpdateID"].ToString() + ".jpg";
                    if (!System.IO.File.Exists(flyerPath))
                    {
                        lblUpdatethumb.Text = "No Flyer Thumbnail";
                    }
                    else
                    {
                        string imageDisID = Guid.NewGuid().ToString();
                        lblUpdatethumb.Text = "<img src='" + RootPath + "/Upload/Updates/" + ProfileID.ToString() + "/" + Session["BusinessUpdateID"].ToString() + ".jpg?Guid=" + imageDisID + "' border='0' width='200' height='160'/>";
                    }
                    // monthly emails
                    int totalemails = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ExistingUserEmails"));
                    DataTable dtSelectedTools = objBus.GetSelectedToolsByUserID(UserID);
                    string remaingEmailsmsg = string.Empty;
                    if (dtSelectedTools.Rows.Count > 0)
                    {
                        totalemails = Convert.ToInt32(dtSelectedTools.Rows[0]["Total_Emails"].ToString());
                    }
                    remaingEmailsmsg = "Allowed - " + totalemails.ToString() + " &nbsp;&nbsp;&nbsp;Sent - #Sent &nbsp;&nbsp;&nbsp;Remaining - #Remaining";
                    int remainingEmails = 0;
                    objCommon.RemainingScheduledEmailsCount(UserID, ProfileID, totalemails, out remainingEmails);
                    lblRemainingEmailsCount.Text = remaingEmailsmsg.Replace("#Remaining", remainingEmails.ToString()).Replace("#Sent", (totalemails - remainingEmails).ToString());

                    hdnRemainingEmails.Value = remainingEmails.ToString();


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
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        # region Add Contacts
        protected void lnkimportcontacts_Click(object sender, EventArgs e)
        {
            try
            {
                txtto.Text = "";
                Session["NoContact"] = null;
                dtContacts = objBus.GetAllUserContactsbyUserID(UserID, 0, "All");
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
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "lnkimportcontacts_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void imclose_Click(object sender, ImageClickEventArgs e)
        {
            dtSelectedContactList.Dispose();
            dtSelectedContactList.Rows.Clear();

        }
        protected void btnenhance_Click(object sender, EventArgs e)
        {
            string urlinfo2 = Page.ResolveClientUrl("~/Business/Myaccount/ManageContacts.aspx");
            Response.Redirect(urlinfo2);

        }
        protected void btndashboard_Click(object sender, EventArgs e)
        {

        }
        # endregion

        private int CheckAvailableTimeAndEmailCount(DateTime dateSent, DateTime dateNow)
        {
            int showFlag = 0;
            try
            {
                int checkBusinessUpdateCount = 0;
                if (dateSent >= Convert.ToDateTime(dateNow.ToShortDateString()))
                {
                    CountTotalEmails = ValidateemailIDs(txtto.Text);
                    lblselectedcontactcount.Text = CountTotalEmails.ToString();

                    if (txtemailsperday.Text != "" && ddltime.SelectedIndex > 0)
                    {

                        checkBusinessUpdateCount = CheckEmailsCountForNewsletter(dateSent);
                        if (checkBusinessUpdateCount == 0)
                        {
                            int availableEmailCount = 0;
                            availableEmailCount = BusinessUpdateUsageCount - (BusinessUpdateUsage + Convert.ToInt32(txtemailsperday.Text.Replace(",", "")));
                            if (availableEmailCount >= 0)
                            {
                                lblEmailsch.Text = Resources.LabelMessages.SelectedBusinessUpdatelimitlessthanAvailablevalue;

#if fixme
                                string sendingdate = selectedtime;


                                sendingdate = sendingdate.Replace(" ", "");
                                if (sendingdate == "3AM")
                                {
                                    currentDateTime = businessUpdateSendingDate.AddHours(3);
                                }
                                else if (sendingdate == "9AM")
                                {
                                    currentDateTime = businessUpdateSendingDate.AddHours(9);
                                }
                                else if (sendingdate == "3PM")
                                {
                                    currentDateTime = businessUpdateSendingDate.AddHours(15);
                                }
                                else if (sendingdate == "9PM")
                                {
                                    currentDateTime = businessUpdateSendingDate.AddHours(21);
                                }
#endif
                                if (dateSent <= dateNow)
                                {
                                    int nexthour = dateNow.Hour; // *** Removing 1 hr bacause of engine running with 3 mins interval + 1;
                                    dateSent = dateSent.AddHours(nexthour).AddMinutes(dateNow.Minute + 2);
                                }
                                if (dtToday < dateSent)
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
                                availableEmailCount = BusinessUpdateUsageCount - BusinessUpdateUsage;
                                string mess = Resources.LabelMessages.SelectedbusinessupdatelimitExceedstheAvailablevalue;
                                mess = mess.Replace("#day_lmit", BusinessUpdateUsageCountstr);
                                mess = mess.Replace("#used", BusinessUpdateUsage.ToString());
                                if (availableEmailCount == 5000)
                                    availableEmailCountstr = "5,000";
                                else
                                    availableEmailCountstr = availableEmailCount.ToString();
                                mess = mess.Replace("#available", availableEmailCountstr);
                                lblEmailsch.Text = mess.ToString();
                                showFlag = 0;
                            }
                        }
                        else
                        {
                            lblEmailsch.Text = "The schedule of another update is clashing with the dates of this update. Please choose a different date.";
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
                    lblEmailsch.Text = "Please select a date later than or equal to the current date."; //Please select a date later than or equal to the current date
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "CheckAvailableTimeAndEmailCount", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return showFlag;
        }
        protected void lnkSchEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(hdnRemainingEmails.Value) >= Convert.ToInt32(hdnSelectedEmails.Value))
                {
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
                            SendNewsletterSchedule(DateSent1, dtToday);
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
                }
                else
                {
                    lblerror.Text = Resources.LabelMessages.EMailsCountExceeded.Replace("#Available", lblRemainingEmailsCount.Text).Replace("#Selected", lblselectedcontactcount.Text);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "lnkSchEmail_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkSendmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(hdnRemainingEmails.Value) >= Convert.ToInt32(hdnSelectedEmails.Value))
                {
                    if (ddltime.SelectedIndex > 0)
                    {
                        DateTime dateSent1;
                        dateSent1 = Convert.ToDateTime(txtSendingDate.Text.Trim());
#if fixme
                    string sendingtime = ddltime.SelectedValue;
                    string date = DateTime.Today.ToShortDateString();
                    if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(date + " 9:00:00 PM")) > 0)
                    {
                        sendingtime = "3AM";
                    }
                    else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(date + " 3:00:00 AM")) < 0)
                    {
                        sendingtime = "3AM";
                    }
                    else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(date + " 9:00:00 AM")) < 0)
                    {
                        sendingtime = "9AM";
                    }
                    else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(date + " 3:00:00 PM")) < 0)
                    {
                        sendingtime = "3PM";
                    }
                    else
                    {
                        sendingtime = "9PM";
                    }


                    if (sendingtime == "3AM")
                    {
                        dateSent1 = dateSent1.AddHours(3);
                    }
                    else if (sendingtime == "9AM")
                    {
                        dateSent1 = dateSent1.AddHours(9);
                    }
                    else if (sendingtime == "3PM")
                    {
                        dateSent1 = dateSent1.AddHours(15);
                    }
                    else if (sendingtime == "9PM")
                    {
                        dateSent1 = dateSent1.AddHours(21);
                    }
#endif
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
                }
                else
                {
                    lblerror.Text = Resources.LabelMessages.EMailsCountExceeded.Replace("#Available", lblRemainingEmailsCount.Text).Replace("#Selected", lblselectedcontactcount.Text);
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "lnkSendmail_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private string GetUrl()
        {
            string url = Page.ResolveClientUrl("~/Business/MyAccount/ManageUpdates.aspx");
            if (AppStatus == 1)
                url = Page.ResolveClientUrl("~/Business/MyAccount/ManageUpdates.aspx?App=1");
            return url;
        }
        protected void lnkCancelMail_Click(object sender, EventArgs e)
        {
            Session["BusinessUpdateID"] = null;
            Session["BusinessUpdateDes"] = null;
            Response.Redirect(GetUrl());
        }
        private void SendNewsletterSchedule(DateTime dateSent, DateTime dateNow)
        {
            try
            {
                int optoutCount = 0;
                DataTable dtDupContacts = new DataTable();
                DataColumn email = new DataColumn("Receiver_Email", typeof(string));
                dtDupContacts.Columns.Add(email);
                string subject = string.Empty;
                string address = string.Empty;
                address = txtto.Text;
                address = address.Replace("\n", "");
                address = address.Replace("\r", "");
                subject = txtsubject.Text;
                string mailids = string.Empty;
                int schCount = Convert.ToInt32(txtemailsperday.Text.Replace(",", ""));
                int countSchEmails = 0;
                int addDays = 0;
                DateTime schDate;
                DateTime schDate1;
                DateTime schCurrrent = dateSent;
                string selectedtime = string.Empty;
                int domainID = 1;
                DataTable dtDomain = objCommon.GetDomainDetails(DomainName);
                if (dtDomain.Rows.Count == 1)
                {
                    domainID = Convert.ToInt32(dtDomain.Rows[0]["Domain_ID"].ToString());
                }
                string[] totalAddress;
                string splitType = ",";
                totalAddress = address.Split(splitType.ToCharArray());
                if (totalAddress.Length > 0)
                {
                    objBusUpdate.UpdateBusinessUpdateSendingDate(SchHisID, dateSent.Date);
                    DataTable dtcurrentcontacts = (DataTable)(Session["ContactTable"]);
                    if (dtcurrentcontacts != null && dtcurrentcontacts.Rows.Count > 0)
                    {
                        DataRow[] drChecked = dtcurrentcontacts.Select("checkvalue=0");
                        for (int i = 0; i < drChecked.Length; i++)
                        {
                            dtcurrentcontacts.Rows.Remove(drChecked[i]);
                        }
                    }
                    SchHisID = Convert.ToInt32(Session["BusinessUpdateID"].ToString());
                    // *** Issue 1167 *** //

                    bool contactusChecked = true;
                    if (chkContactus.Checked == false)
                    {
                        contactusChecked = false;
                    }
                    if (schCurrrent <= dtToday)
                    {
                        int nexthour = dtToday.Hour; // *** Removing 1 hr bacause of engine running with 3 mins interval + 1;
                        schCurrrent = schCurrrent.AddHours(nexthour).AddMinutes(dateNow.Minute + 2);
                    }
                    for (int i = 0; i < totalAddress.Length; i++)
                    {
                        if (countSchEmails >= schCount)
                        {
                            countSchEmails = 0;
                            addDays++;
                        }
                        if (totalAddress[i].Length > 0)
                        {
                            string splitVal = "'";
                            string[] currentvalues;
                            string eA = totalAddress[i].ToString();
                            currentvalues = eA.Split(splitVal.ToCharArray());
                            if (addDays != 0)
                            {
                                schDate = schCurrrent.AddDays(addDays);
                                schDate1 = schDate.Date;
                            }
                            else
                            {
                                schDate = schCurrrent;
                                schDate1 = schCurrrent.Date;
                            }
#if fixme
                            string date = DateTime.Today.ToShortDateString();
                            if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(date + " 9:00:00 PM")) > 0)
                            {
                                selectedtime = "3AM";
                            }
                            else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(date + " 3:00:00 AM")) < 0)
                            {
                                selectedtime = "3AM";
                            }
                            else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(date + " 9:00:00 AM")) < 0)
                            {
                                selectedtime = "9AM";
                            }
                            else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(date + " 3:00:00 PM")) < 0)
                            {
                                selectedtime = "3PM";
                            }
                            else
                            {
                                selectedtime = "9PM";
                            }


                            if (selectedtime == "3AM")
                            {
                                schDate = schDate.AddHours(3);
                            }
                            else if (selectedtime == "9AM")
                            {
                                schDate = schDate.AddHours(9);
                            }
                            else if (selectedtime == "3PM")
                            {
                                schDate = schDate.AddHours(15);
                            }
                            else if (selectedtime == "9PM")
                            {
                                schDate = schDate.AddHours(21);
                            }

#endif

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
                                                int optFlag = 0;
                                                optFlag = objBus.CheckForEmailOptFlagCount(toEmailAdd, Convert.ToInt32(Session["UserID"].ToString()));

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
                                                        objBusUpdate.InsertBusinessUpdateScheduleDetails(SchHisID, ProfileID, UserID, subject, toEmailAdd, schDate, schDate1, 0, false, contactusChecked, "", CUserID, domainID);
                                                        countSchEmails++;
                                                        CountTotalEmails++;
                                                    }
                                                    // *** End Issue 986 *** //
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
                                                int checkEmail = 0;
                                                checkEmail = objBus.CheckEmailIDForDefaultGroup(emailsent, UserID);
                                                if (checkEmail == 0)
                                                {
                                                    char[] seperator = new char[1];
                                                    seperator[0] = '@';
                                                    string[] emailid = new string[2];
                                                    emailid = emailsent.Split(seperator);
                                                    string firstname = emailid[0].ToString();
                                                    objBus.AddUserContactDetails(firstname, string.Empty, emailsent, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "Self", UserID, DateTime.Today.Date, "13", string.Empty, CUserID);
                                                }
                                                int optFlag = 0;

                                                optFlag = objBus.CheckForEmailOptFlagCount(emailsent, Convert.ToInt32(Session["UserID"].ToString()));
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
                                                        objBusUpdate.InsertBusinessUpdateScheduleDetails(SchHisID, ProfileID, UserID, subject, emailsent, schDate, schDate1, 0, false, contactusChecked, "", CUserID, domainID);
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
                    objBusUpdate.UpdateBusinessUpdateMasterSentCount(UserID, SchHisID, CountTotalEmails, schCount, dtToday.Date, CUserID);
                    Session["BusinessUpdateID"] = null;
                    Session["BusinessUpdateDes"] = null;
                    Session["Send"] = "2";
                    if (countSchEmails == 0 & InvalidIds.Length > 0)
                    {
                        Session["CheckMess"] = "1";
                    }
                    else if (countSchEmails == 0 & optoutCount > 0)
                    {
                        Session["CheckMess"] = "5";
                    }
                    else if (countSchEmails > 0 & InvalidIds.Length > 0)
                    {
                        Session["CheckMess"] = "2";
                        Session["invalid"] = InvalidIds;
                    }
                    else if (countSchEmails > 0 & optoutCount > 0)
                    {
                        Session["CheckMess"] = "4";
                    }
                    else if (countSchEmails > 0 & InvalidIds.Length == 0 & optoutCount == 0)
                    {
                        Session["CheckMess"] = "3";
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "SendNewsletterSchedule", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void SendMailtoSelectedContacts(DateTime dateSent)
        {
            try
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
                DataTable dtDomain = objCommon.GetDomainDetails(DomainName);
                if (dtDomain.Rows.Count == 1)
                {
                    domainID = Convert.ToInt32(dtDomain.Rows[0]["Domain_ID"].ToString());
                }
#if fixme
            string sendingtime = string.Empty;
            string date = DateTime.Today.ToShortDateString();
            if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(date + " 9:00:00 PM")) > 0)
            {
                sendingtime = "3AM";
            }
            else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(date + " 3:00:00 AM")) < 0)
            {
                sendingtime = "3AM";
            }
            else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(date + " 9:00:00 AM")) < 0)
            {
                sendingtime = "9AM";
            }
            else if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(date + " 3:00:00 PM")) < 0)
            {
                sendingtime = "3PM";
            }
            else
            {
                sendingtime = "9PM";
            }
            if (sendingtime == "3AM")
            {
                schCurrent = newsletterSendingDate.AddHours(3);
            }
            else if (sendingtime == "9AM")
            {
                schCurrent = newsletterSendingDate.AddHours(9);
            }
            else if (sendingtime == "3PM")
            {
                schCurrent = newsletterSendingDate.AddHours(15);
            }
            else if (sendingtime == "9PM")
            {
                schCurrent = newsletterSendingDate.AddHours(21);
            }
#endif
                string address = string.Empty;
                string[] totalAddress;
                string splitType = ",";
                address = txtto.Text;
                address = address.Replace("\n", "");
                address = address.Replace("\r", "");
                totalAddress = address.Split(splitType.ToCharArray());
                if (totalAddress.Length > 0)
                {
                    BusinessUpdateUsage = 0;
                    objBusUpdate.UpdateBusinessUpdateSendingDate(SchHisID, dtToday.Date);
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
                    //----------------------------------------------------------
                    SchHisID = Convert.ToInt32(Session["BusinessUpdateID"].ToString());
                    // *** Issue 1167 *** //           
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
                                                if (BusinessUpdateUsage < BusinessUpdateUsageCount)
                                                {
                                                    if (groupID == "")
                                                    {
                                                        groupID = "13";
                                                    }
                                                    int optFlag = 0;
                                                    optFlag = objBus.CheckForEmailOptFlagCount(toEmailAdd, Convert.ToInt32(Session["UserID"].ToString()));
                                                    if (optFlag == 0)
                                                    {

                                                        // *** Issue 986 *** //
                                                        int dupflag = 0;
                                                        if (chkduplicatecont.Checked)
                                                        {
                                                            string dupcontact = "0";
                                                            //dupcontact = ObjNews.GetDuplicateContact(SchHisID, ToEmailAdd, UserID, "BU");
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
                                                            objBusUpdate.InsertBusinessUpdateScheduleDetails(SchHisID, ProfileID, UserID, subject, toEmailAdd, schCurrent, DateTime.Now.Date, 0, true, contactusChecked, "", CUserID, domainID);
                                                            BusinessUpdateUsage++;
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
                                                if (BusinessUpdateUsage < BusinessUpdateUsageCount)
                                                {
                                                    int checkEmail = 0;
                                                    checkEmail = objBus.CheckEmailIDForDefaultGroup(emailsent, UserID);
                                                    if (checkEmail == 0)
                                                    {
                                                        char[] seperator = new char[1];
                                                        seperator[0] = '@';
                                                        string[] emailid = new string[2];
                                                        emailid = emailsent.Split(seperator);
                                                        string firstname = emailid[0].ToString();
                                                        objBus.AddUserContactDetails(firstname, string.Empty, emailsent, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "Self", UserID, DateTime.Today.Date, "13", string.Empty, CUserID);
                                                    }
                                                    int optFlag = 0;
                                                    optFlag = objBus.CheckForEmailOptFlagCount(emailsent, Convert.ToInt32(Session["UserID"].ToString()));
                                                    if (optFlag == 0)
                                                    {
                                                        // *** Issue 986 *** //
                                                        int dupflag = 0;
                                                        if (chkduplicatecont.Checked)
                                                        {
                                                            string dupcontact = "0";
                                                            //dupcontact = ObjNews.GetDuplicateContact(SchHisID, Emailsent, UserID, "BU");
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
                                                            objBusUpdate.InsertBusinessUpdateScheduleDetails(SchHisID, ProfileID, UserID, subject, emailsent, schCurrent, DateTime.Now.Date, 0, true, contactusChecked, "", CUserID, domainID);
                                                            BusinessUpdateUsage++;
                                                            sendCount++;
                                                        }
                                                        // *** Issue 986 *** //
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
                        objBusUpdate.UpdateBusinessUpdateMasterSentCount(UserID, SchHisID, sendCount, sendCount, dtToday.Date, CUserID);
                        Session["BusinessUpdateID"] = null;
                        Session["BusinessUpdateDes"] = null;
                        Session["Send"] = "1";
                        if (sendCount == 0 & InvalidIds.Length > 0)
                        {
                            Session["CheckMess"] = "1";
                        }
                        else if (sendCount == 0 & optoutCount > 0)
                        {
                            Session["CheckMess"] = "5";
                        }
                        else if (sendCount > 0 & InvalidIds.Length > 0)
                        {
                            Session["CheckMess"] = "2";
                            Session["invalid"] = InvalidIds;
                        }
                        else if (sendCount > 0 & optoutCount > 0)
                        {
                            Session["CheckMess"] = "4";
                        }
                        else if (sendCount > 0 & InvalidIds.Length == 0 & optoutCount == 0)
                        {
                            Session["CheckMess"] = "3";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "SendMailtoSelectedContacts", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnedit_Click(object sender, EventArgs e)
        {
            Session["UpdateSuccess"] = null;
            string urlinfo = RootPath + "/Business/MyAccount/EditUpdate.aspx?Update_ID=" + Session["BusinessUpdateID"].ToString();
            Response.Redirect(urlinfo);
        }
        protected void btnpreview_Click(object sender, EventArgs e)
        {
            try
            {
                string contactus = string.Empty;
                contactus = "<a href='" + RootPath + "/ContactUser.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&SID=" + EncryptDecrypt.DESEncrypt(Session["BusinessUpdateID"].ToString()) + "&ET=BU' target='_blank'><img src='" + RootPath + "/images/Dashboard/contactus.gif' alt='Contact Us' border='0'/></a>";
                string businessUpdatePreview = string.Empty;
                businessUpdatePreview = Session["BusinessUpdateDes"].ToString();
                // *** Issue 1167 *** //
                string unsubscribeContent = UserProfileUnsubscribeLink();
                businessUpdatePreview = "<html><head></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='border: solid 2px #F4EBEB;'><tr><td colspan='2' style='padding:30px;'>" + businessUpdatePreview + "</td></tr>";
                if (chkContactus.Checked == true)
                {
                    if (txtto.Text.Trim() != "")
                    {
                        businessUpdatePreview = businessUpdatePreview + @"<tr><td align='center' style='padding:10px;' colspan='2'>" + contactus + "</td></tr>";
                    }
                }
                businessUpdatePreview = businessUpdatePreview + @"<tr><td style='font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; padding:10px; border-top: solid 1px #F4EBEB;'>" + unsubscribeContent + "</td><td align='right'style='font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; border-top: solid 1px #F4EBEB;'><a href='" + RootPath + "' target='_blank'><img src='" + RootPath + "/images/VerticalLogos/" + DomainName + "emailby.gif' border='0' /></a></td></tr></table></body></html>";
                lblPreviewHTML.Text = businessUpdatePreview;
                ModalPopupExtender2.Show();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "btnpreview_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnktestbusinessUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                txttestemail.Text = "";
                ModalPopupExtender4.Show();
                DataTable dt = objBus.GetUserDetailsByUserID(UserID);
                if (dt.Rows.Count > 0)
                {
                    txttestemail.Text = dt.Rows[0]["User_email"].ToString();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "lnktestbusinessUpdate_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btntestsend_Click(object sender, EventArgs e)
        {
            try
            {
                string contactus = string.Empty;
                UtilitiesBLL objUtl = new UtilitiesBLL();
                contactus = "<a href='" + RootPath + "/ContactUser.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&SID=" + EncryptDecrypt.DESEncrypt(Session["BusinessUpdateID"].ToString()) + "&ET=BU' target='_blank'><img src='" + RootPath + "/images/Dashboard/contactus.gif' alt='Contact Us' border='0'/></a>";
                string businessUpdateBody = string.Empty;
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
                businessUpdateBody = Session["BusinessUpdateDes"].ToString();
                // *** Issue 1167 *** //

                string unsubscribeContent = UserProfileUnsubscribeLink();
                DataTable dtBusinessUpdateDetails = objBusUpdate.UpdateBusinessUpdateDetails(Convert.ToInt32(Session["BusinessUpdateID"].ToString()));
                businessUpdateBody = "<html><head></head><body><table width='750px' border='0' cellspacing='0' cellpadding='0' align='center' style='border: solid 2px #F4EBEB;'><tr><td colspan='2' align='center' style='height: 30px; padding: 7px;'>Problems viewing? Click <a href='" + RootPath + "/ViewUpdate.aspx?SID=" + EncryptDecrypt.DESEncrypt(Session["BusinessUpdateID"].ToString()) + "&REA=" + EncryptDecrypt.DESEncrypt(emailAddress) + "&SI=#SocialIcons#'><span style='color: Green;'>here</span></a> to view it online.</td></tr><tr><td colspan='2' style='font-weight: bold; font-size: 14px; padding-left: 10px; color: green; padding-top: 20px' align='center'>" + dtBusinessUpdateDetails.Rows[0]["UpdateTitle"].ToString() + "</td></tr><tr><td colspan='2' style='padding: 10px 30px;'>" + businessUpdateBody + "</td></tr>";
                if (chkContactus.Checked == true)
                {
                    businessUpdateBody = businessUpdateBody + @"<tr><td align='center' style='padding:10px;' colspan='2'>" + contactus + "</td></tr>";
                    ShowSocialIcons = "1-" + ShowSocialIcons;
                }
                else
                    ShowSocialIcons = "0-" + ShowSocialIcons;
                businessUpdateBody = businessUpdateBody.Replace("#SocialIcons#", ShowSocialIcons);
                businessUpdateBody = businessUpdateBody + @"<tr><td style='font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; padding:10px; width:700px; border-top: solid 1px #F4EBEB;'>" + unsubscribeContent + "</td><td align='right' valign='top' style='font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; border-top: solid 1px #F4EBEB;'><a href='" + RootPath + "' target='_blank'><img src='" + RootPath + "/images/VerticalLogos/" + DomainName + "emailby.gif' border='0' /></a></td></tr></table></body></html>";
                businessUpdateBody = businessUpdateBody.Replace("&#60;recipient's email address&#62;", emailAddress);
                emailSubject = txtMailSubject.Text;

                objUtl.SendCompaignMail(fromEmailsupport, emailAddress, emailSubject, businessUpdateBody, string.Empty, Convert.ToString(Session["ProfileName"]), DomainName);
                ModalPopupExtender4.Hide();
                lblmess.Text = "Your test content has been sent successfully.";
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "btntestsend_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private int CheckEmailsCountForNewsletter(DateTime dateSent)
        {
            int retCountNews = 0;
            DateTime sendingDate;
            int checkSchNewsEmailCount = 0;
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
                checkSchNewsEmailCount = objBusUpdate.CheckBusinessUpdatesSendingCountforSendingDate(UserID, sendingDate);
                if (checkSchNewsEmailCount == 0 || CheckUnlimited == 1)
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
                    int value = BusinessUpdateUsageCount - checkSchNewsEmailCount;
                    BusinessUpdateUsage = checkSchNewsEmailCount;
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
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "CheckEmailsCountForNewsletter", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return retCountNews;
            //---End

        }
        private string UserProfileUnsubscribeLink()
        {
            string unSubscribeLinkText = "";
            try
            {
                DataTable dtProfileAddress = objBus.GetProfileDetailsByProfileID(ProfileID);
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
                unSubscribeLinkText = "This message was sent from " + profileName + " to &#60;recipient's email address&#62;. It was sent from: " + totalAddress + ". If you no longer wish to receive our business updates, <a href='" + RootPath + "/Unsubscribeupdate.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&SID=" + EncryptDecrypt.DESEncrypt(Session["BusinessUpdateID"].ToString()) + "' target='_blank'>Click here</a> to unsubscribe.";
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "UserProfileUnsubscribeLink", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return unSubscribeLinkText;
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
                checkForSelectedDateCount = objBusUpdate.CheckBusinessUpdatesSendingCountforSendingDate(UserID, dtToday.Date);
                checkSch = objBusUpdate.CheckforBusinessUpdateSchedule(UserID);
                int checkCam = 0;
                if (checkSch > MaxBusUpdatesCampaigns)
                {
                    checkCam = 1;
                }

                checkSch = BusinessUpdateUsageCount - checkForSelectedDateCount;
                if (checkSch > 0 && checkCam != 1)
                {
                    if (BusinessUpdateCount < BusinessUpdateUsageCount)
                    {
                        string address = string.Empty;
                        address = txtto.Text;
                        address = address.Replace("\n", "");
                        address = address.Replace("\r", "");
                        CountTotalEmails = dtSelectedContactList.Rows.Count;
                        BusinessUpdateCount = BusinessUpdateUsage + CountTotalEmails + checkForSelectedDateCount;
                        if (BusinessUpdateCount < BusinessUpdateUsageCount)
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
                        maxSchDate = objBusUpdate.GetBusinessUpdateMaxScheduleingDate(UserID);
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
                    lnkSchEmail.Attributes.Add("style", "display:none");
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "btnclick_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btncancelpop_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        protected int ValidateemailIDs(string address)
        {
            int countTotalEmails1 = 0;
            try
            {
                string[] totalAddress1;
                string mailids = string.Empty;
                string splitType1 = ",";
                totalAddress1 = address.Split(splitType1.ToCharArray());
                //---------Email Scheduling--------------

                //----Check wether No of Emails are greater than or equal to daylimit or not--


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
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "ValidateemailIDs", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return countTotalEmails1;
            //---End

        }

        // Issue 780
        protected void Validateradiobutton()
        {
            try
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
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "Validateradiobutton", ex.Message,
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
                    checkForSelectedDateCount = objBusUpdate.CheckBusinessUpdatesSendingCountforSendingDate(UserID, dateSent);
                    checkSch = objBusUpdate.CheckforBusinessUpdateSchedule(UserID);
                    int checkCam = 0;
                    if (checkSch > MaxBusUpdatesCampaigns)
                    {
                        checkCam = 1;
                    }

                    checkSch = BusinessUpdateUsageCount - checkForSelectedDateCount;
                    if (checkSch > 0 && checkCam != 1)
                    {

                        string address = string.Empty;
                        address = txtto.Text;
                        address = address.Replace("\n", "");
                        address = address.Replace("\r", "");

                        CountTotalEmails = ValidateemailIDs(address);
                        BusinessUpdateCount = BusinessUpdateUsage + CountTotalEmails + checkForSelectedDateCount;
                        if (BusinessUpdateCount < BusinessUpdateUsageCount)
                        {
                            BusinessUpdateCount = BusinessUpdateUsage;
                            BusinessUpdateUsage = 0;
                            SendMailtoSelectedContacts(dateSent);
                            dtSelectedContactList.Rows.Clear();
                            txtsubject.Text = "";
                            txtto.Text = "";
                            Response.Redirect(GetUrl());
                        }
                        else
                        {
                            //lnkSendmail.Attributes.Add("style", "display:none");
                            lblselectedcontactcount.Text = CheckSendCount.ToString();
                            hdncheckcontact.Value = "1";
                            ScriptManager.RegisterClientScriptBlock(btnclick, this.GetType(), "CheckContr", "CheckControls()", true);
                            //lbldaylimit.Text = BusinessUpdateUsageCount.ToString();
                        }
                    }
                    else
                    {
                        if (checkCam > 0)
                        {
                            string maxSchDate = string.Empty;
                            maxSchDate = objBusUpdate.GetBusinessUpdateMaxScheduleingDate(UserID);
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
                objInBuiltData.ErrorHandling("ERROR", "SendUpdates.aspx.cs", "ValidateCampaign", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void rbtnemailsperday_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validateradiobutton();
        }
        protected void rbtnall_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validateradiobutton();
        }
        //End Issue 780


        [WebMethod]
        public static int ValidateSendrSchedule(string address, string userid, string daylimit)
        {
            int userID1 = Convert.ToInt32(userid);
            int checkForSelectedDateCount = 0;
            BusinessUpdatesBLL objBusUpd = new BusinessUpdatesBLL();
            CommonBLL objCommon = new CommonBLL();
            DateTime dtToday = objCommon.ConvertToUserTimeZone(Convert.ToInt32(HttpContext.Current.Session["ProfileID"].ToString()));
            checkForSelectedDateCount = objBusUpd.CheckBusinessUpdatesSendingCountforSendingDate(userID1, dtToday.Date);
            int businessUpdateUsageCount1 = Convert.ToInt32(daylimit);
            address = address.Replace("\n", "");
            address = address.Replace("\r", "");
            SendUpdates bms = new SendUpdates();

            int countTotalEmails1 = bms.ValidateemailIDs(address);
            int businessUpdateCount1 = countTotalEmails1 + checkForSelectedDateCount;
            if (businessUpdateCount1 < businessUpdateUsageCount1)
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
