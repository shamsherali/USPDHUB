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
using System.Text.RegularExpressions;
using System.Web.Services;
using System.IO;
using System.Xml.Linq;
using System.Text;

namespace USPDHUB.Business.MyAccount
{
    public partial class SendBulletins : BaseWeb
    {
        public int C_UserID = 0;
        public int UserID = 0;
        DataTable DtContacts = new DataTable();
        DataTable DtSelectedContactList = new DataTable();
        public int BulletinUsageCount = 0;
        public int BulletinCount = 0;
        public int BulletinUsage = 0;
        public int ProfileID = 0;
        public string invalidIds = string.Empty;
        public int CountTotalEmails = 0;
        public int SchHisID = 0;
        public int CheckSendCount = 0;
        public int CheckUnlimited = 0;
        public int MaxBulletinCampaigns = 0;
        public string BulletinUsageCountstr = string.Empty;
        public string ShowSocialIcons = string.Empty;
        public int AppStatus = 0; // *** From app request 26-03-2013 ***
        public string RootPath = "";
        public string DomainName = "";
        public DateTime dtToday;
        #region Variable Declaration
        UtilitiesBLL _ObjUtilitiesBLL = new UtilitiesBLL();
        EventCalendarBLL _ObjEventCalendarBLL = new EventCalendarBLL();
        BusinessBLL _ObjBusinessBLL = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        BulletinBLL objBulletin = new BulletinBLL();
        DataTable dtStoreLinks;
        #endregion

        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public bool IsEmailContact = false;
        public bool IsScheduleEmail = false;
        BusinessBLL objBus = new BusinessBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                GetObjects();
                lblmess.Text = "";
                lblEmailsch.Text = "";
                lblsendingDate.Text = "";
                lblerror.Text = "";



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
                        C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        C_UserID = UserID;
                }
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                hdnURLPath.Value = RootPath;
                // Check For Unlimted Users
                lblerror.Text = "";
                MaxBulletinCampaigns = Convert.ToInt32(ConfigurationManager.AppSettings.Get("MaxBulletinscampaignlimit"));

                //EventCalendar ObjEventCalendar = new EventCalendar();
                DataTable DtUnlimiteduser = _ObjEventCalendarBLL.CheckForUnlimtedUserEmail(UserID);
                if (DtUnlimiteduser.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(DtUnlimiteduser.Rows[0]["Bulletin_Unlimited"].ToString()) == true)
                    {
                        BulletinUsageCountstr = ConfigurationManager.AppSettings.Get("UnlimtedUserEmailsCount");
                    }
                    else
                    {
                        BulletinUsageCountstr = ConfigurationManager.AppSettings.Get("BulletinUsageCount");
                    }
                }
                else
                {
                    BulletinUsageCountstr = ConfigurationManager.AppSettings.Get("BulletinUsageCount");
                }
                BulletinUsageCount = Convert.ToInt32(BulletinUsageCountstr.Replace(",", ""));
                hdnlimit.Value = BulletinUsageCount.ToString();
                hdnuserid.Value = UserID.ToString();
                int CountSch = objBulletin.CheckforBulletinSchedule(UserID);
                if (CountSch > MaxBulletinCampaigns)
                {
                    string MaxSchDate = string.Empty;
                    MaxSchDate = objBulletin.GetBulletinMaxScheduleingDate(UserID);
                    MaxSchDate = MaxSchDate.Replace("12:00:00 AM", "");
                    lblmess.Text = Resources.LabelMessages.AlreadyHaveBulletinCampaign + " " + MaxSchDate + ".";
                    txtto.Enabled = false;
                }
                else
                {
                    txtto.Enabled = true;
                }

                pnlApprSendDays.Attributes.Add("style", "display:none");
                pnltext.Attributes.Add("style", "display:none");

                // End
                if (objBus.CheckModulePermission(WebConstants.Purchase_Contacts_Reports, ProfileID))
                {
                    IsEmailContact = true;
                }
                if (objBus.CheckModulePermission(WebConstants.Purchase_ScheduleEmailsSetup, ProfileID))
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
                    DtSelectedContactList.Columns.Clear();
                    DtSelectedContactList.Rows.Clear();
                    DtSelectedContactList.Columns.Add("contactid", typeof(Int32));
                    DtSelectedContactList.Columns.Add("firstName", typeof(string));
                    DtSelectedContactList.Columns.Add("email", typeof(string));
                    DtSelectedContactList.Columns.Add("group", typeof(string));
                    lnkSchEmail.Attributes.Add("style", "display:none");
                    dtStoreLinks = _ObjBusinessBLL.GetStoreDetailsById(UserID);
                    if (dtStoreLinks.Rows.Count > 0 && Convert.ToString(dtStoreLinks.Rows[0]["IOS_Url"]) != "")
                        chkStoreLinks.Visible = true;

                    // monthly emails
                    int totalemails = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ExistingUserEmails"));
                    DataTable dtSelectedTools = _ObjBusinessBLL.GetSelectedToolsByUserID(UserID);
                    string RemaingEmailsmsg = string.Empty;
                    if (DtUnlimiteduser.Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(DtUnlimiteduser.Rows[0]["Bulletin_Unlimited"].ToString()) == true)
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
                    RemaingEmailsmsg = "Allowed - " + totalemails.ToString() + " &nbsp;&nbsp;&nbsp;Sent - #Sent &nbsp;&nbsp;&nbsp;Remaining - #Remaining";
                    int RemainingEmails = 0;
                    objCommon.RemainingScheduledEmailsCount(UserID, ProfileID, totalemails, out RemainingEmails);
                    //lblRemainingEmailsCount.Text = RemaingEmailsmsg.Replace("#Remaining", RemainingEmails.ToString()).Replace("#Sent", (totalemails - RemainingEmails).ToString());

                    hdnRemainingEmails.Value = RemainingEmails.ToString();
                    string FlyerPath = HttpContext.Current.Server.MapPath("~") + "\\Upload\\Bulletins\\" + ProfileID.ToString();
                    FlyerPath = FlyerPath + "\\" + Session["BulletinID"].ToString() + ".jpg";
                    if (!System.IO.File.Exists(FlyerPath))
                    {
                        lblUpdatethumb.Text = "No Content Thumbnail";
                    }
                    else
                    {
                        string ImageDisID = Guid.NewGuid().ToString();
                        lblUpdatethumb.Text = "<img src='" + RootPath + "/Upload/Bulletins/" + ProfileID.ToString() + "/" + Session["BulletinID"].ToString() + ".jpg?Guid=" + ImageDisID + "' border='0' width='200' height='160'/>";
                    }
                }
                if (hdncheckpostback.Value != "")
                {
                    hdncheckpostback.Value = "";
                    validateradiobutton();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        # region Add Contacts

        protected void lnkimportcontacts_Click(object sender, EventArgs e)
        {
            try
            {
                GetObjects();
                txtto.Text = "";
                Session["NoContact"] = null;
                DtContacts = _ObjBusinessBLL.GetAllUserContactsbyUserID(UserID, 0, "All");
                if (DtContacts.Rows.Count > 0)
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
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "lnkimportcontacts_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void imclose_Click(object sender, ImageClickEventArgs e)
        {
            DtSelectedContactList.Dispose();
            DtSelectedContactList.Rows.Clear();
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



        protected void lnkSchEmail_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToInt32(hdnRemainingEmails.Value) >= Convert.ToInt32(hdnSelectedEmails.Value))
                //{
                string EmilsperdayCount = string.Empty;
                EmilsperdayCount = txtemailsperday.Text.Replace(",", "");
                string strRegex = @"^(\d{0,9}(\.\d{4})?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(EmilsperdayCount))
                {
                    DateTime DateSent1;
                    DateSent1 = Convert.ToDateTime(txtSendingDate.Text.Trim());
                    dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                    int showflag = CheckAvailableTimeAndEmailCount(DateSent1, dtToday);
                    if (showflag > 0)
                    {
                        SendBulletinSchedule(DateSent1, dtToday);
                        lnkSendmail.Attributes.Add("style", "display:''");
                        lnkSchEmail.Attributes.Add("style", "display:none");
                        txtsubject.Text = "";
                        DtSelectedContactList.Rows.Clear();
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
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "lnkSchEmail_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private int CheckAvailableTimeAndEmailCount(DateTime dateSent, DateTime dateNow)
        {
            int ShowFlag = 0;
            try
            {

                int CheckBulletinCount = 0;
                if (dateSent >= Convert.ToDateTime(dateNow.ToShortDateString()))
                {
                    CountTotalEmails = validateemailIDs(txtto.Text);
                    lblselectedcontactcount.Text = CountTotalEmails.ToString();
                    if (txtemailsperday.Text != "" && ddltime.SelectedIndex > 0)
                    {
                        CheckBulletinCount = CheckEmailsCountForBulletin(dateSent);
                        if (CheckBulletinCount == 0)
                        {
                            int AvailableEmailCount = 0;
                            AvailableEmailCount = BulletinUsageCount - (BulletinUsage + Convert.ToInt32(txtemailsperday.Text.Replace(",", "")));
                            if (AvailableEmailCount >= 0)
                            {
                                lblEmailsch.Text = Resources.LabelMessages.SelectedBusinessEventlimitlessthanAvailablevalue.Replace("event", "bulletin");
#if fixme
                                    string sendingdate = selectedtime;
                                    sendingdate = sendingdate.Replace(" ", "");
                                    if (sendingdate == "3AM")
                                    {
                                        CurrentDateTime = BulletinSendingDate.AddHours(3);
                                    }
                                    else if (sendingdate == "9AM")
                                    {
                                        CurrentDateTime = BulletinSendingDate.AddHours(9);
                                    }
                                    else if (sendingdate == "3PM")
                                    {
                                        CurrentDateTime = BulletinSendingDate.AddHours(15);
                                    }
                                    else if (sendingdate == "9PM")
                                    {
                                        CurrentDateTime = BulletinSendingDate.AddHours(21);
                                    }
#endif
                                if (dateSent <= dateNow)
                                {
                                    int nexthour = dateNow.Hour; // *** Removing 1 hr bacause of engine running with 3 mins interval + 1;
                                    dateSent = dateSent.AddHours(nexthour).AddMinutes(dateNow.Minute + 2);
                                }
                                if (dateNow < dateSent)
                                {
                                    ShowFlag = 1;
                                }
                                else
                                {
                                    ShowFlag = 0;
                                    lblEmailsch.Text = "Please select a date later than or equal to the current date.";
                                }
                            }
                            else
                            {
                                string AvailableEmailCountstr;
                                AvailableEmailCount = BulletinUsageCount - BulletinUsage;
                                string Mess = Resources.LabelMessages.SelectedbusinesseventlimitExceedstheAvailablevalue.Replace("event", "content");
                                Mess = Mess.Replace("#day_lmit", BulletinUsageCountstr);
                                Mess = Mess.Replace("#used", BulletinUsage.ToString());
                                if (AvailableEmailCount == 5000)
                                    AvailableEmailCountstr = "5,000";
                                else
                                    AvailableEmailCountstr = AvailableEmailCount.ToString();
                                Mess = Mess.Replace("#available", AvailableEmailCountstr.ToString());
                                lblEmailsch.Text = Mess.ToString();
                                ShowFlag = 0;
                            }
                        }
                        else
                        {
                            lblEmailsch.Text = "The schedule of another content is clashing with the dates of this bulletin. Please either choose a different date or click the \"Content History\" link above to view the details of all the scheduled content.";
                            ShowFlag = 0;
                        }
                    }
                    else
                    {
                        ShowFlag = 0;
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
                    ShowFlag = 0;
                    lblEmailsch.Text = "Please select a date later than or equal to the current date.";
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "CheckAvailableTimeAndEmailCount", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return ShowFlag;
        }
        private string GetUrl()
        {
            string url = Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx");
            if (AppStatus == 1)
                url = Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx?App=1");
            return url;
        }
        protected void lnkSendmail_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToInt32(hdnRemainingEmails.Value) >= Convert.ToInt32(hdnSelectedEmails.Value))
                //{
                if (ddltime.SelectedIndex > 0)
                {
                    DateTime DateSent1;
                    DateSent1 = Convert.ToDateTime(txtSendingDate.Text.Trim());
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
                        DateSent1 = DateSent1.AddHours(3);

                    }
                    else if (sendingtime == "9AM")
                    {
                        DateSent1 = DateSent1.AddHours(9);
                    }
                    else if (sendingtime == "3PM")
                    {
                        DateSent1 = DateSent1.AddHours(15);
                    }
                    else if (sendingtime == "9PM")
                    {
                        DateSent1 = DateSent1.AddHours(21);
                    }
#endif
                    dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                    if (DateSent1 <= dtToday)
                    {
                        int nexthour = dtToday.Hour; // *** Removing 1 hr bacause of engine running with 3 mins interval + 1;
                        DateSent1 = DateSent1.AddHours(nexthour).AddMinutes(dtToday.Minute + 2);
                    }
                    if (DateSent1 > dtToday)
                    {
                        ValidateCampaign(DateSent1, dtToday);
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
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "lnkSendmail_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkCancelMail_Click(object sender, EventArgs e)
        {
            Session["BusinessEventID"] = null;
            Response.Redirect(GetUrl());
        }

        private void SendBulletinSchedule(DateTime dateSent, DateTime dateNow)
        {
            try
            {
                GetObjects();
                int OptoutCount = 0;
                DataTable dtDupContacts = new DataTable();
                DataColumn Email = new DataColumn("Receiver_Email", typeof(string));
                dtDupContacts.Columns.Add(Email);
                #region variable declaration
                string message = string.Empty;
                string bodymsg = string.Empty;
                string subject = string.Empty;
                string Address = string.Empty;
                string mailids = string.Empty;
                string HTMLSubject = string.Empty;
                string mailedflag = string.Empty;
                string ToEmailAdd = string.Empty;
                string BU = string.Empty;
                string groupID = string.Empty;
                string[] TotalAddress;
                string[] Currentvalues;
                string SplitType = ",";
                string SplitVal = "'";
                int SchCount = Convert.ToInt32(txtemailsperday.Text.Replace(",", ""));
                int CountSchEmails = 0;
                int AddDays = 0;
                DateTime SchDate;
                DateTime SchDate1;
                DateTime SchCurrent = dateSent;
                string ShareEvent = string.Empty;
                string selectedtime = string.Empty;
                int domainID = 1;
                #endregion
                DataTable dtDomain = objCommon.GetDomainDetails(Session["VerticalDomain"].ToString());
                if (dtDomain.Rows.Count == 1)
                {
                    domainID = Convert.ToInt32(dtDomain.Rows[0]["Domain_ID"].ToString());
                }
                Address = txtto.Text;
                Address = Address.Replace("\n", "");
                Address = Address.Replace("\r", "");
                subject = txtsubject.Text;

                TotalAddress = Address.Split(SplitType.ToCharArray());
                if (TotalAddress.Length > 0)
                {
                    DataTable dtcurrentcontacts = Session["ContactTable"] == null ? null : (DataTable)(Session["ContactTable"]);
                    if (dtcurrentcontacts != null)
                    {
                        if (dtcurrentcontacts.Rows.Count > 0)
                        {
                            DataRow[] DrChecked = dtcurrentcontacts.Select("checkvalue=0");
                            for (int i = 0; i < DrChecked.Length; i++)
                            {
                                dtcurrentcontacts.Rows.Remove(DrChecked[i]);
                            }
                        }
                    }
                    SchHisID = Convert.ToInt32(Session["BulletinID"].ToString());
                    bool ContactusChecked = true;
                    if (chkContactus.Checked == false)
                    {
                        ContactusChecked = false;
                    }
                    if (SchCurrent <= dateNow)
                    {
                        int nexthour = dateNow.Hour; // *** Removing 1 hr bacause of engine running with 3 mins interval + 1;
                        SchCurrent = SchCurrent.AddHours(nexthour).AddMinutes(dateNow.Minute + 2);
                    }
                    SchCurrent = objCommon.GetScheduleDateInPST(ProfileID, SchCurrent);
                    for (int i = 0; i < TotalAddress.Length; i++)
                    {
                        if (CountSchEmails >= SchCount)
                        {
                            CountSchEmails = 0;
                            AddDays++;
                        }
                        if (TotalAddress[i].Length > 0)
                        {
                            BU = TotalAddress[i].ToString();
                            Currentvalues = BU.Split(SplitVal.ToCharArray());
                            if (AddDays != 0)
                            {
                                SchDate = SchCurrent.AddDays(AddDays);
                                SchDate1 = SchDate.Date;
                            }
                            else
                            {
                                SchDate = SchCurrent;
                                SchDate1 = SchCurrent.Date;
                            }
# if fixme
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
                                SchDate = SchDate.AddHours(3);
                            }
                            else if (selectedtime == "9AM")
                            {
                                SchDate = SchDate.AddHours(9);
                            }
                            else if (selectedtime == "3PM")
                            {
                                SchDate = SchDate.AddHours(15);
                            }
                            else if (selectedtime == "9PM")
                            {
                                SchDate = SchDate.AddHours(21);
                            }
#endif
                            if (Currentvalues.Length > 0)
                            {
                                if (Currentvalues.Length != 1)
                                {
                                    if (Currentvalues[1].Length > 0)
                                    {
                                        ToEmailAdd = Currentvalues[1].ToString();
                                        groupID = string.Empty;
                                        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                                        Regex re = new Regex(strRegex);
                                        if (re.IsMatch(ToEmailAdd))
                                        {
                                            if (dtcurrentcontacts != null)
                                            {
                                                if (dtcurrentcontacts.Rows.Count > 0)
                                                {
                                                    DataRow[] Dr = dtcurrentcontacts.Select("email='" + ToEmailAdd + "' and checkvalue=1");
                                                    if (dtcurrentcontacts.Rows.Count > 0)
                                                    {
                                                        int ChVa = 0;
                                                        for (ChVa = 0; ChVa < Dr.Length; ChVa++)
                                                        {
                                                            string FindChValue = Dr[ChVa]["checkvalue"].ToString();
                                                            groupID = Dr[ChVa]["Contact_group_ID"].ToString();
                                                            if (FindChValue == "1")
                                                            {
                                                                DataRow DRUpdate = dtcurrentcontacts.Rows.Find(Dr[ChVa]["contactid"]);

                                                                if (DRUpdate != null)
                                                                {
                                                                    DRUpdate["checkvalue"] = 0;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (ToEmailAdd != "")
                                            {
                                                int OptFlag = 0;
                                                OptFlag = _ObjBusinessBLL.CheckForEmailOptFlagCount(ToEmailAdd, Convert.ToInt32(Session["UserID"].ToString()));

                                                if (OptFlag == 0)
                                                {
                                                    if (groupID == "")
                                                    {
                                                        groupID = "13";
                                                    }
                                                    int SchemailID = 0;
                                                    // *** Issue 986 *** //
                                                    int dupflag = 0;
                                                    if (chkduplicatecont.Checked)
                                                    {
                                                        string dupcontact = "0";
                                                        DataRow[] FilterDupcontact = dtDupContacts.Select("Receiver_Email='" + ToEmailAdd + "'");
                                                        dupcontact = FilterDupcontact.Length.ToString();
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
                                                        dr["Receiver_Email"] = ToEmailAdd;
                                                        dtDupContacts.Rows.Add(dr);
                                                        SchemailID = objBulletin.InsertBulletinScheduleDetails(SchHisID, ProfileID, UserID, subject, ToEmailAdd, SchDate, SchDate.Date, 0, false, groupID, ContactusChecked, ShareEvent, C_UserID, domainID, chkStoreLinks.Checked);
                                                        CountSchEmails++;
                                                        CountTotalEmails++;
                                                    }
                                                }
                                                else
                                                {
                                                    OptoutCount = OptoutCount + 1;
                                                }
                                                if (mailids.Length == 0)
                                                {
                                                    mailids = ToEmailAdd;
                                                }
                                                else
                                                {
                                                    mailids = mailids + ", " + ToEmailAdd;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (invalidIds.Length == 0)
                                            {
                                                invalidIds = Currentvalues[0].ToString();
                                            }
                                            else
                                            {
                                                invalidIds = invalidIds + ", " + Currentvalues[0].ToString();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (Currentvalues.Length == 1)
                                    {
                                        if (Currentvalues[0].Length > 1)
                                        {

                                            string Emailsent = Currentvalues[0].ToString();
                                            Emailsent = Emailsent.Replace(" ", "");
                                            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                                            Regex re = new Regex(strRegex);
                                            if (re.IsMatch(Emailsent))
                                            {
                                                string GroupID = string.Empty;
                                                DataTable dtcon = new DataTable();
                                                dtcon = objCommon.GetcontactgroupnameforEmailID(Emailsent, UserID);
                                                if (dtcon.Rows.Count > 0)
                                                {
                                                    GroupID = dtcon.Rows[0]["Contact_Group_ID"].ToString();
                                                }
                                                else
                                                {
                                                    GroupID = "13";
                                                }
                                                int CheckEmail = 0;
                                                CheckEmail = _ObjBusinessBLL.CheckEmailIDForDefaultGroup(Emailsent, UserID);
                                                if (CheckEmail == 0)
                                                {
                                                    char[] Seperator = new char[1];
                                                    Seperator[0] = '@';
                                                    string[] emailid = new string[2];
                                                    emailid = Emailsent.Split(Seperator);
                                                    string Firstname = emailid[0].ToString();
                                                    _ObjBusinessBLL.AddUserContactDetails(Firstname, string.Empty, Emailsent, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "Self", UserID, DateTime.Today.Date, "13", string.Empty, C_UserID);
                                                }
                                                int OptFlag = 0;

                                                OptFlag = _ObjBusinessBLL.CheckForEmailOptFlagCount(Emailsent, Convert.ToInt32(Session["UserID"].ToString()));
                                                if (OptFlag == 0)
                                                {
                                                    int SchemailID = 0;
                                                    // *** Issue 986 *** //
                                                    int dupflag = 0;
                                                    if (chkduplicatecont.Checked)
                                                    {
                                                        string dupcontact = "0";
                                                        DataRow[] FilterDupcontact = dtDupContacts.Select("Receiver_Email='" + Emailsent + "'");
                                                        dupcontact = FilterDupcontact.Length.ToString();
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
                                                        dr["Receiver_Email"] = Emailsent;
                                                        dtDupContacts.Rows.Add(dr);
                                                        SchemailID = objBulletin.InsertBulletinScheduleDetails(SchHisID, ProfileID, UserID, subject, Emailsent, SchDate, SchDate.Date, 0, false, GroupID, ContactusChecked, ShareEvent, C_UserID, domainID, chkStoreLinks.Checked);
                                                        CountSchEmails++;
                                                        CountTotalEmails++;
                                                    }
                                                }
                                                else
                                                {
                                                    OptoutCount = OptoutCount + 1;
                                                }
                                                if (mailids.Length == 0)
                                                {
                                                    mailids = Emailsent;
                                                }
                                                else
                                                {
                                                    mailids = mailids + ", " + Emailsent;
                                                }
                                            }
                                            else
                                            {
                                                if (invalidIds.Length == 0)
                                                {
                                                    invalidIds = Currentvalues[0].ToString();
                                                }
                                                else
                                                {
                                                    invalidIds = invalidIds + ", " + Currentvalues[0].ToString();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Session["BulletinID"] = null;
                    Session["BulletinSend"] = "2";
                    if (CountSchEmails == 0 & invalidIds.Length > 0)
                    {
                        Session["CheckBulletinMess"] = "1";
                    }
                    else if (CountSchEmails == 0 & OptoutCount > 0)
                    {
                        Session["CheckBulletinMess"] = "5";
                    }
                    else if (CountSchEmails > 0 & invalidIds.Length > 0)
                    {
                        Session["CheckBulletinMess"] = "2";
                        Session["invalidEventEmailID"] = invalidIds;
                    }
                    else if (CountSchEmails > 0 & OptoutCount > 0)
                    {
                        Session["CheckBulletinMess"] = "4";
                    }
                    else if (CountSchEmails > 0 & invalidIds.Length == 0 & OptoutCount == 0)
                    {
                        Session["CheckBulletinMess"] = "3";
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "SendBulletinSchedule", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void SendMailtoSelectedContacts(DateTime dateSent)
        {
            try
            {
                GetObjects();
                string message = string.Empty;
                string bodymsg = string.Empty;
                string subject = string.Empty;
                subject = txtsubject.Text;
                string SenderEmail = string.Empty;
                int SendCount = 0;
                int OptoutCount = 0;
                int domainID = 1;
                DataTable DtGetUserDetails = new DataTable();
                DataTable dtDupContacts = new DataTable();
                DataColumn Email = new DataColumn("Receiver_Email", typeof(string));
                dtDupContacts.Columns.Add(Email);
                DtGetUserDetails = _ObjBusinessBLL.GetUserDetailsByUserID(UserID);
                if (DtGetUserDetails.Rows.Count > 0)
                {
                    SenderEmail = DtGetUserDetails.Rows[0]["User_email"].ToString();
                }
                DataTable dtDomain = objCommon.GetDomainDetails(DomainName);
                if (dtDomain.Rows.Count == 1)
                {
                    domainID = Convert.ToInt32(dtDomain.Rows[0]["Domain_ID"].ToString());
                }

                string mailedflag = string.Empty;
                DateTime SchCurrent;
# if fixme
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
                SchCurrent = EventSendingDate.AddHours(3);

            }
            else if (sendingtime == "9AM")
            {
                SchCurrent = EventSendingDate.AddHours(9);
            }
            else if (sendingtime == "3PM")
            {
                SchCurrent = EventSendingDate.AddHours(15);
            }
            else if (sendingtime == "9PM")
            {
                SchCurrent = EventSendingDate.AddHours(21);
            }
#endif

                SchCurrent = dateSent;
                string Address = string.Empty;
                string[] TotalAddress;
                string mailids = string.Empty;
                string SplitType = ",";
                Address = txtto.Text;
                Address = Address.Replace("\n", "");
                Address = Address.Replace("\r", "");
                TotalAddress = Address.Split(SplitType.ToCharArray());
                if (TotalAddress.Length > 0)
                {
                    BulletinUsage = 0;
                    DataTable dtcurrentcontacts = new DataTable();
                    dtcurrentcontacts = (DataTable)(Session["ContactTable"]);
                    if (dtcurrentcontacts != null)
                    {
                        if (dtcurrentcontacts.Rows.Count > 0)
                        {
                            DataRow[] DrChecked = dtcurrentcontacts.Select("checkvalue=0");
                            for (int i = 0; i < DrChecked.Length; i++)
                            {
                                dtcurrentcontacts.Rows.Remove(DrChecked[i]);
                            }
                        }
                    }
                    //----------------------------------------------------------
                    SchHisID = Convert.ToInt32(Session["BulletinID"].ToString());
                    bool ContactusChecked = true;
                    if (chkContactus.Checked == false)
                    {
                        ContactusChecked = false;
                    }
                    SchCurrent = objCommon.GetScheduleDateInPST(ProfileID, SchCurrent);
                    for (int i = 0; i < TotalAddress.Length; i++)
                    {
                        if (TotalAddress[i].Length > 0)
                        {
                            string SplitVal = "'";
                            string[] Currentvalues;
                            string EA = TotalAddress[i].ToString();
                            Currentvalues = EA.Split(SplitVal.ToCharArray());

                            if (Currentvalues.Length > 0)
                            {
                                if (Currentvalues.Length != 1)
                                {
                                    if (Currentvalues[1].Length > 0)
                                    {
                                        string ToEmailAdd = Currentvalues[1].ToString();
                                        string groupID = string.Empty;
                                        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                                        Regex re = new Regex(strRegex);
                                        if (re.IsMatch(ToEmailAdd))
                                        {
                                            if (dtcurrentcontacts != null)
                                            {
                                                if (dtcurrentcontacts.Rows.Count > 0)
                                                {
                                                    DataRow[] Dr = dtcurrentcontacts.Select("email='" + ToEmailAdd + "' and checkvalue=1");
                                                    if (dtcurrentcontacts.Rows.Count > 0)
                                                    {

                                                        int ChVa = 0;
                                                        for (ChVa = 0; ChVa < Dr.Length; ChVa++)
                                                        {
                                                            string FindChValue = Dr[ChVa]["checkvalue"].ToString();
                                                            groupID = Dr[ChVa]["Contact_group_ID"].ToString();
                                                            if (FindChValue == "1")
                                                            {
                                                                DataRow DRUpdate = dtcurrentcontacts.Rows.Find(Dr[ChVa]["contactid"]);

                                                                if (DRUpdate != null)
                                                                {
                                                                    DRUpdate["checkvalue"] = 0;
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (ToEmailAdd != "")
                                            {
                                                if (BulletinUsage < BulletinUsageCount)
                                                {
                                                    if (groupID == "")
                                                    {
                                                        groupID = "13";
                                                    }
                                                    int OptFlag = 0;
                                                    OptFlag = _ObjBusinessBLL.CheckForEmailOptFlagCount(ToEmailAdd, Convert.ToInt32(Session["UserID"].ToString()));
                                                    string Adddis = string.Empty;
                                                    if (OptFlag == 0)
                                                    {
                                                        int SchID = 0;
                                                        // *** Issue 986 *** //
                                                        int dupflag = 0;
                                                        if (chkduplicatecont.Checked)
                                                        {
                                                            string dupcontact = "0";
                                                            DataRow[] FilterDupcontact = dtDupContacts.Select("Receiver_Email='" + ToEmailAdd + "'");
                                                            dupcontact = FilterDupcontact.Length.ToString();
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
                                                            dr["Receiver_Email"] = ToEmailAdd;
                                                            dtDupContacts.Rows.Add(dr);
                                                            SchID = objBulletin.InsertBulletinScheduleDetails(SchHisID, ProfileID, UserID, subject, ToEmailAdd, SchCurrent, DateTime.Now.Date, 0, true, groupID, ContactusChecked, "", C_UserID, domainID, chkStoreLinks.Checked);
                                                            BulletinUsage++;
                                                            SendCount++;
                                                        }
                                                        // *** End Issue 986 *** //
                                                    }
                                                    else
                                                    {
                                                        OptoutCount = OptoutCount + 1;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (invalidIds.Length == 0)
                                            {
                                                invalidIds = Currentvalues[0].ToString();
                                            }
                                            else
                                            {
                                                invalidIds = invalidIds + ", " + Currentvalues[0].ToString();
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    if (Currentvalues.Length == 1)
                                    {
                                        if (Currentvalues[0].Length > 1)
                                        {

                                            string Emailsent = Currentvalues[0].ToString();
                                            Emailsent = Emailsent.Replace(" ", "");
                                            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                                            Regex re = new Regex(strRegex);
                                            if (re.IsMatch(Emailsent))
                                            {
                                                string GroupID = string.Empty;
                                                DataTable dtcon = objCommon.GetcontactgroupnameforEmailID(Emailsent, UserID);
                                                if (dtcon.Rows.Count > 0)
                                                {
                                                    GroupID = dtcon.Rows[0]["Contact_Group_ID"].ToString();
                                                }
                                                else
                                                {
                                                    GroupID = "13";
                                                }
                                                if (BulletinUsage < BulletinUsageCount)
                                                {
                                                    int CheckEmail = 0;
                                                    CheckEmail = _ObjBusinessBLL.CheckEmailIDForDefaultGroup(Emailsent, UserID);
                                                    if (CheckEmail == 0)
                                                    {
                                                        char[] Seperator = new char[1];
                                                        Seperator[0] = '@';
                                                        string[] emailid = new string[2];
                                                        emailid = Emailsent.Split(Seperator);
                                                        string Firstname = emailid[0].ToString();
                                                        _ObjBusinessBLL.AddUserContactDetails(Firstname, string.Empty, Emailsent, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "Self", UserID, DateTime.Today.Date, "13", string.Empty, C_UserID);
                                                    }
                                                    int OptFlag = 0;
                                                    OptFlag = _ObjBusinessBLL.CheckForEmailOptFlagCount(Emailsent, Convert.ToInt32(Session["UserID"].ToString()));
                                                    string Adddis = string.Empty;
                                                    if (OptFlag == 0)
                                                    {
                                                        int SchID = 0;

                                                        int dupflag = 0;
                                                        if (chkduplicatecont.Checked)
                                                        {
                                                            string dupcontact = "0";
                                                            DataRow[] FilterDupcontact = dtDupContacts.Select("Receiver_Email='" + Emailsent + "'");
                                                            dupcontact = FilterDupcontact.Length.ToString();
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
                                                            dr["Receiver_Email"] = Emailsent;
                                                            dtDupContacts.Rows.Add(dr);
                                                            SchID = objBulletin.InsertBulletinScheduleDetails(SchHisID, ProfileID, UserID, subject, Emailsent, SchCurrent, DateTime.Now.Date, 0, true, GroupID, ContactusChecked, "", C_UserID, domainID, chkStoreLinks.Checked);
                                                            BulletinUsage++;
                                                            SendCount++;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        OptoutCount = OptoutCount + 1;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (invalidIds.Length == 0)
                                                {
                                                    invalidIds = Currentvalues[0].ToString();
                                                }
                                                else
                                                {
                                                    invalidIds = invalidIds + ", " + Currentvalues[0].ToString();
                                                }

                                            }

                                        }
                                    }
                                }
                            }
                        }
                        Session["BulletinID"] = null;
                        Session["BulletinSend"] = "1";
                        if (SendCount == 0 & invalidIds.Length > 0)
                        {
                            Session["CheckBulletinMess"] = "1";
                        }
                        else if (SendCount == 0 & OptoutCount > 0)
                        {
                            Session["CheckBulletinMess"] = "5";
                        }
                        else if (SendCount > 0 & invalidIds.Length > 0)
                        {
                            Session["CheckBulletinMess"] = "2";
                            Session["invalidEventEmailID"] = invalidIds;
                        }
                        else if (SendCount > 0 & OptoutCount > 0)
                        {
                            Session["CheckBulletinMess"] = "4";
                        }
                        else if (SendCount > 0 & invalidIds.Length == 0 & OptoutCount == 0)
                        {
                            Session["CheckBulletinMess"] = "3";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnktestBulletin_Click(object sender, EventArgs e)
        {
            try
            {
                txttestemail.Text = "";
                ModalPopupExtender4.Show();
                DataTable dt = _ObjBusinessBLL.GetUserDetailsByUserID(UserID);
                if (dt.Rows.Count > 0)
                {
                    txttestemail.Text = dt.Rows[0]["User_email"].ToString();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "lnktestBulletin_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btntestsend_Click(object sender, EventArgs e)
        {
            try
            {
                GetObjects();

                string Contactus = string.Empty;
                UtilitiesBLL ObjUtl = new UtilitiesBLL();
                Contactus = "<a href=\"" + RootPath + "/ContactUser.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&SID=" + EncryptDecrypt.DESEncrypt(Session["BulletinID"].ToString()) + "&ET=BL\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/contactus.gif' alt='Contact Us' border='0'/></a>";
                StringBuilder builderHtml = new StringBuilder();
                string BulletinBody = string.Empty;
                string EmailAddress = string.Empty;
                string EmailSubject = string.Empty;
                string FromEmail = string.Empty;
                EmailAddress = txttestemail.Text.Trim();
                string FromEmailsupport = "";
                DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailFrom")
                            FromEmailsupport = row[1].ToString();
                    }
                }
                // *** Issue 1167 *** //
                string UnsubscribeContent = UserProfileUnsubscribeLink();
                DataTable dtBulletinCheck = objBulletin.GetBulletinByID(Convert.ToInt32(Session["BulletinID"].ToString()));
                string previewHeader = string.Empty;
                BusinessBLL objBus = new BusinessBLL();
                USPDHUBBLL.MobileAppSettings objMobileApp = new USPDHUBBLL.MobileAppSettings();
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                previewHeader = objCommon.GetLogoHeaderText(UserID, ProfileID, RootPath).Replace("style='margin-left:160px;'", "");
                builderHtml.Append("<html><head></head><body><table border='0' cellspacing='0' cellpadding='0' align='center'");
                builderHtml.Append("style='width:650px; border: solid 2px #F4EBEB; font-family: Arial, Helvetica, sans-serif;'>");
                builderHtml.Append("<tr><td colspan='2' align='center' style='height: 30px; padding: 7px;'>Problems viewing? Click ");
                builderHtml.Append("<a href='" + RootPath + "/ViewBulletin.aspx?SID=" + EncryptDecrypt.DESEncrypt(Session["BulletinID"].ToString()) + "&REA=" + EncryptDecrypt.DESEncrypt(EmailAddress) + "&SI=#SocialIcons#'><span style='color: Green;'>here</span></a> to view it online.</td></tr><tr><td colspan='2' style='font-weight: bold; font-size: 14px; padding-left: 10px; color: green; padding-top: 20px' align='center'>" + dtBulletinCheck.Rows[0]["Bulletin_Title"].ToString() + "</td></tr>");
                builderHtml.Append("<tr><td colspan='2' style='padding: 0px 0px; text-align:left;'>" + previewHeader + "</td></tr>");
                builderHtml.Append("<tr><td colspan='2' style='padding: 0px; padding:0px 175px;'>" + Session["BulletinDes"].ToString() + "</td></tr>");


                if (chkContactus.Checked == true)
                {
                    builderHtml.Append("<tr><td align='center' style='padding:10px;' colspan='2'>" + Contactus + "</td></tr>");
                    ShowSocialIcons = "1-" + ShowSocialIcons;
                }
                else
                    ShowSocialIcons = "0-" + ShowSocialIcons;
                if (chkStoreLinks.Checked)
                {
                    string storelinks = "";
                    dtStoreLinks = _ObjBusinessBLL.GetStoreDetailsById(UserID);
                    if (dtStoreLinks.Rows.Count > 0)
                    {
                        if (Convert.ToString(dtStoreLinks.Rows[0]["IOS_Url"]) != "")
                            storelinks = "<a href=\"" + Convert.ToString(dtStoreLinks.Rows[0]["IOS_Url"]) + "\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/iosemail.png' alt='iOS Store' border='0'/></a>";
                        if (Convert.ToString(dtStoreLinks.Rows[0]["Android_Url"]) != "")
                            storelinks = storelinks + "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + Convert.ToString(dtStoreLinks.Rows[0]["Android_Url"]) + "\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/androidemail.png' alt='Android Store' border='0'/></a>";
                        if (Convert.ToString(dtStoreLinks.Rows[0]["Windows_Url"]) != "")
                            storelinks = storelinks + "&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + Convert.ToString(dtStoreLinks.Rows[0]["Windows_Url"]) + "\" target=\"_blank\"><img src='" + RootPath + "/images/Dashboard/windowsemail.png' alt='Windows Phone Store' border='0'/></a>";
                        builderHtml.Append("<tr><td style='padding:10px;' colspan='2' align='center'>" + Convert.ToString(dtStoreLinks.Rows[0]["StoreLinksTitle"]) + "</td></tr><tr><td style='padding:10px; padding:left: 50px;' colspan='2' align='center'>" + storelinks + "</td></tr>");
                        ShowSocialIcons = ShowSocialIcons + "1";
                    }
                    else
                        ShowSocialIcons = ShowSocialIcons + "0";
                }
                else
                    ShowSocialIcons = ShowSocialIcons + "0";
                builderHtml.Replace("#SocialIcons#", ShowSocialIcons);
                builderHtml.Append("<tr><td style='font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; padding:10px; border-top: solid 1px #F4EBEB;'>" + UnsubscribeContent + "</td>");
                builderHtml.Append("<td align='right' valign='top' style='font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; border-top: solid 1px #F4EBEB; padding:10px;'>");
                builderHtml.Append("<a href=\"" + RootPath + "\" target=\"_blank\"><img src='" + RootPath + "/images/VerticalLogos/" + DomainName + "emailby.gif' border='0' /></a></td></tr></table></body></html>");
                builderHtml.Replace("&#60;recipient's email address&#62;", EmailAddress);

                FromEmail = Session["UserName"].ToString();
                EmailSubject = txtMailSubject.Text;
                BulletinBody = objCommon.ReplaceShortURltoHtmlString(builderHtml.ToString());
                bool result = ObjUtl.SendCompaignMail(FromEmailsupport, EmailAddress, EmailSubject, BulletinBody, string.Empty, Convert.ToString(Session["ProfileName"]), DomainName);
                ModalPopupExtender4.Hide();
                lblmess.Text = "Your test content has been sent successfully.";
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "btntestsend_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private int CheckEmailsCountForBulletin(DateTime dateSent)
        {

            GetObjects();
            //----Check wether No of Emails are greater than or equal to daylimit or not--
            int RetCountNews = 0;
            DateTime SendingDate;
            int SchCount = 0;
            int CheckSchBulletinEmailCount = 0;
            SendingDate = dateSent;
            SchCount = Convert.ToInt32(txtemailsperday.Text.Replace(",", ""));
            string Address = string.Empty;
            string[] TotalAddress1;
            string mailids = string.Empty;
            string SplitType1 = ",";
            Address = txtto.Text;
            Address = Address.Replace("\n", "");
            Address = Address.Replace("\r", "");
            TotalAddress1 = Address.Split(SplitType1.ToCharArray());
            try
            {
                CheckSchBulletinEmailCount = objBulletin.CheckBulletinSendingCountforSendingDate(UserID, SendingDate);
                if (CheckSchBulletinEmailCount == 0 || CheckUnlimited == 1)
                {
                    if (TotalAddress1.Length > 0)
                    {
                        for (int i = 0; i < TotalAddress1.Length; i++)
                        {
                            if (TotalAddress1[i].Length > 0)
                            {
                                string SplitVal = "'";
                                string[] Currentvalues;
                                string EA = TotalAddress1[i].ToString();
                                Currentvalues = EA.Split(SplitVal.ToCharArray());
                                if (Currentvalues.Length > 0)
                                {
                                    if (Currentvalues.Length != 1)
                                    {
                                        if (Currentvalues[1].Length > 0)
                                        {
                                            string ToEmailAdd = Currentvalues[1].ToString();
                                            CheckSendCount++;
                                        }
                                    }
                                    else
                                    {
                                        if (Currentvalues.Length == 1)
                                        {
                                            if (Currentvalues[0].Length > 1)
                                            {

                                                string Emailsent = Currentvalues[0].ToString();
                                                Emailsent = Emailsent.Replace(" ", "");
                                                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                                                Regex re = new Regex(strRegex);
                                                if (re.IsMatch(Emailsent))
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
                    int value = BulletinUsageCount - CheckSchBulletinEmailCount;
                    BulletinUsage = CheckSchBulletinEmailCount;
                    if (value > 0)
                    {
                        RetCountNews = 0;
                    }
                    else
                    {
                        RetCountNews = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "CheckEmailsCountForBulletin", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return RetCountNews;
            //---End

        }

        private string UserProfileUnsubscribeLink()
        {
            string UnSubscribeLinkText = string.Empty;
            try
            {
                GetObjects();
                //   Business ObjBus = new Business();
                DataTable DtProfileAddress = _ObjBusinessBLL.GetProfileDetailsByProfileID(ProfileID);
                string TotalAddress = string.Empty;

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
                UnSubscribeLinkText = "This message was sent from " + ProfileName + " to &#60;recipient's email address&#62;. It was sent from: " + TotalAddress + ". If you no longer wish to receive our events, <a href=\"" + RootPath + "/UnsubscribeBulletin.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&SID=" + EncryptDecrypt.DESEncrypt(Session["BulletinID"].ToString()) + "\" target=\"_blank\">Click here</a> to unsubscribe.";
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "UserProfileUnsubscribeLink", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return UnSubscribeLinkText;
        }

        protected void btnclick_Click(object sender, EventArgs e)
        {
            try
            {
                txtto.Text = "";
                DtSelectedContactList = (DataTable)(Session["ContactTable"]);
                DataRow[] DrChecked = DtSelectedContactList.Select("checkvalue=0");
                for (int i = 0; i < DrChecked.Length; i++)
                {
                    DtSelectedContactList.Rows.Remove(DrChecked[i]);
                }
                if (DtSelectedContactList.Rows.Count > 0)
                {

                    string ContactList = string.Empty;
                    for (int i = 0; i < DtSelectedContactList.Rows.Count; i++)
                    {
                        if (ContactList != "")
                        {
                            ContactList = ContactList + DtSelectedContactList.Rows[i]["name"].ToString() + " '" + DtSelectedContactList.Rows[i]["email"].ToString() + "'" + ", ";
                        }
                        else
                        {
                            ContactList = DtSelectedContactList.Rows[i]["name"].ToString() + " '" + DtSelectedContactList.Rows[i]["email"].ToString() + "'" + ", ";
                        }
                    }
                    if (ContactList != "")
                    {
                        ContactList = ContactList.Remove(ContactList.Length - 1);
                        txtto.Text = ContactList;
                    }
                }
                Session["NoContact"] = "1";


                //  BusinessUpdates objbusupdates = new BusinessUpdates();
                int CheckForSelectedDateCount = 0;
                int CheckSch = 0;
                dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                CheckForSelectedDateCount = objBulletin.CheckBulletinSendingCountforSendingDate(UserID, dtToday.Date);
                CheckSch = objBulletin.CheckforBulletinSchedule(UserID);
                int CheckCam = 0;
                if (CheckSch > MaxBulletinCampaigns)
                {
                    CheckCam = 1;
                }

                CheckSch = BulletinUsageCount - CheckForSelectedDateCount;
                if (CheckSch > 0 && CheckCam != 1)
                {
                    if (BulletinCount < BulletinUsageCount)
                    {
                        string Address = string.Empty;
                        Address = txtto.Text;
                        Address = Address.Replace("\n", "");
                        Address = Address.Replace("\r", "");
                        CountTotalEmails = DtSelectedContactList.Rows.Count;
                        BulletinCount = BulletinUsage + CountTotalEmails + CheckForSelectedDateCount;
                        if (BulletinCount < BulletinUsageCount)
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
                    if (CheckCam > 0)
                    {
                        string MaxSchDate = string.Empty;
                        MaxSchDate = objBulletin.GetBulletinMaxScheduleingDate(UserID);
                        MaxSchDate = MaxSchDate.Replace("12:00:00 AM", "");
                        lblmess.Text = Resources.LabelMessages.AlreadyHaveBusinessUpdateCampaign + " " + MaxSchDate + ".";
                    }
                    else
                    {
                        lblmess.Text = Resources.LabelMessages.sendBusinessUpdatecountExceeded;
                    }
                    txtsubject.Text = "";
                    txtto.Text = "";
                    DtSelectedContactList.Rows.Clear();
                    lnkSendmail.Attributes.Add("style", "display:none");
                    lnkSchEmail.Attributes.Add("style", "display:none");
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "btnclick_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btncancelpop_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        protected int validateemailIDs(string Address)
        {
            string[] TotalAddress1;
            string mailids = string.Empty;
            string SplitType1 = ",";
            TotalAddress1 = Address.Split(SplitType1.ToCharArray());
            //---------Email Scheduling--------------

            //----Check wether No of Emails are greater than or equal to daylimit or not--
            int CountTotalEmails1 = 0;
            try
            {
                if (TotalAddress1.Length > 0)
                {
                    for (int i = 0; i < TotalAddress1.Length; i++)
                    {
                        if (TotalAddress1[i].Length > 0)
                        {
                            string SplitVal = "'";
                            string[] Currentvalues;
                            string EA = TotalAddress1[i].ToString();
                            Currentvalues = EA.Split(SplitVal.ToCharArray());
                            if (Currentvalues.Length > 0)
                            {
                                if (Currentvalues.Length != 1)
                                {
                                    if (Currentvalues[1].Length > 0)
                                    {
                                        string ToEmailAdd = Currentvalues[1].ToString();
                                        CountTotalEmails1++;
                                        if (mailids.Length == 0)
                                        {
                                            mailids = ToEmailAdd;
                                        }
                                        else
                                        {
                                            mailids = mailids + ", " + ToEmailAdd;
                                        }

                                    }
                                }
                                else
                                {
                                    if (Currentvalues.Length == 1)
                                    {
                                        if (Currentvalues[0].Length > 1)
                                        {

                                            string Emailsent = Currentvalues[0].ToString();
                                            Emailsent = Emailsent.Replace(" ", "");
                                            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                                            Regex re = new Regex(strRegex);
                                            if (re.IsMatch(Emailsent))
                                            {
                                                if (mailids.Length == 0)
                                                {
                                                    mailids = Emailsent;
                                                }
                                                else
                                                {
                                                    mailids = mailids + ", " + Emailsent;
                                                }
                                                CountTotalEmails1++;
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
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "validateemailIDs", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return CountTotalEmails1;
            //---End

        }

        // Issue 780
        protected void validateradiobutton()
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
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "validateradiobutton", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void ValidateCampaign(DateTime dateSent, DateTime dateNow)
        {
            try
            {
                GetObjects();
                if (dateSent.Date >= dateNow.Date)
                {
                    int CheckForSelectedDateCount = 0;
                    int CheckSch = 0;
                    CheckForSelectedDateCount = objBulletin.CheckBulletinSendingCountforSendingDate(UserID, dateSent);
                    CheckSch = objBulletin.CheckforBulletinSchedule(UserID);
                    int CheckCam = 0;
                    if (CheckSch > MaxBulletinCampaigns)
                    {
                        CheckCam = 1;
                    }

                    CheckSch = BulletinUsageCount - CheckForSelectedDateCount;
                    if (CheckSch > 0 && CheckCam != 1)
                    {

                        string Address = string.Empty;
                        string[] TotalAddress1;
                        string mailids = string.Empty;
                        string SplitType1 = ",";
                        Address = txtto.Text;
                        Address = Address.Replace("\n", "");
                        Address = Address.Replace("\r", "");
                        TotalAddress1 = Address.Split(SplitType1.ToCharArray());

                        CountTotalEmails = validateemailIDs(Address);
                        BulletinCount = BulletinUsage + CountTotalEmails + CheckForSelectedDateCount;
                        if (BulletinCount < BulletinUsageCount)
                        {
                            BulletinCount = BulletinUsage;
                            BulletinUsage = 0;
                            SendMailtoSelectedContacts(dateSent);
                            DtSelectedContactList.Rows.Clear();
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
                        if (CheckCam > 0)
                        {
                            string MaxSchDate = string.Empty;
                            MaxSchDate = objBulletin.GetBulletinMaxScheduleingDate(UserID);
                            MaxSchDate = MaxSchDate.Replace("12:00:00 AM", "");
                            lblmess.Text = Resources.LabelMessages.AlreadyHaveBulletinCampaign + " " + MaxSchDate + ".";
                        }
                        else
                        {
                            lblmess.Text = Resources.LabelMessages.sendBusinessEventcountExceeded;
                        }
                        txtsubject.Text = "";
                        txtto.Text = "";
                        DtSelectedContactList.Rows.Clear();

                    }
                }
                else
                {
                    lblmess.Text = "Please select a date later than or equal to the current date.";
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "SendBulletins.aspx.cs", "ValidateCampaign", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void rbtnemailsperday_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateradiobutton();
        }
        protected void rbtnall_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateradiobutton();
        }



        [WebMethod]
        public static int ValidateSendrSchedule(string Address, string userid, string daylimit)
        {
            SendBulletins BMS = new SendBulletins();
            int UserID1 = Convert.ToInt32(userid);
            int CheckForSelectedDateCount = 0;
            BulletinBLL objBulletin = new BulletinBLL();
            CommonBLL objCommon = new CommonBLL();

            DateTime dtToday = objCommon.ConvertToUserTimeZone(Convert.ToInt32(HttpContext.Current.Session["ProfileID"].ToString()));

            CheckForSelectedDateCount = objBulletin.CheckBulletinSendingCountforSendingDate(UserID1, dtToday.Date);
            int BulletinUsageCount1 = Convert.ToInt32(daylimit);
            Address = Address.Replace("\n", "");
            Address = Address.Replace("\r", "");
            int CountTotalEmails1 = BMS.validateemailIDs(Address);
            int BulletinCount1 = CountTotalEmails1 + CheckForSelectedDateCount;
            if (BulletinCount1 < BulletinUsageCount1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        private void GetObjects()
        {
            if (this._ObjUtilitiesBLL == null)
            {
                this._ObjUtilitiesBLL = new UtilitiesBLL();
            }
            if (this._ObjEventCalendarBLL == null)
            {
                this._ObjEventCalendarBLL = new EventCalendarBLL();
            }
            if (this._ObjBusinessBLL == null)
            {
                this._ObjBusinessBLL = new BusinessBLL();
            }


        }
    }
}