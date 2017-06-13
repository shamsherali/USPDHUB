using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using USPDHUBBLL;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.Services;
using System.Xml.Linq;
using System.Xml;
using System.Drawing;
using Winnovative.PdfCreator;
using Facebook;
using Newtonsoft.Json;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageBulletins : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;

        public string ShowButtons = string.Empty;
        public string ShowFilter = string.Empty;

        DataTable DtBulletins = new DataTable();
        DataTable dtCampaign = new DataTable();
        DataTable DtHis = new DataTable();
        DataTable dtBulletinCheck;

        public int SortDir = 0;

        public string ArchiveValue = string.Empty;
        public string articleTitle = string.Empty;
        public string articleSummary = string.Empty;
        public string articleSource = string.Empty;
        public string Mailtourlinfo = string.Empty;
        public string linkedInurlinfo = string.Empty;
        public string FacebookInurlinfo = string.Empty;
        public string Twitterurlinfo = string.Empty;
        public string RootPath = "";
        public string DomainName = "";
        string BullitenId = "";
        BulletinBLL objBulletin = new BulletinBLL();
        BusinessBLL objBus = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        EventCalendarBLL objEvents = new EventCalendarBLL();
        BusinessUpdatesBLL objBusUpdate = new BusinessUpdatesBLL();
        USPDHUBBLL.MobileAppSettings objApp = new USPDHUBBLL.MobileAppSettings();
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        AddOnBLL objAddOn = new AddOnBLL();
        public int BulletinUsageCount = 0;
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
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            GetFacebookAppDetails();
            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            C_UserID = UserID;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
            lblmess.Text = "";
            /*** Store Module Functionality ***/
            if (objBus.CheckModulePermission(WebConstants.Purchase_ScheduleEmailsSetup, ProfileID))
            {
                //IsEmail = true;
                IsScheduleEmails = true;
            }
            if (objBus.CheckModulePermission(WebConstants.Purchase_Contacts_Reports, ProfileID))
            {
                IsReport = true;
            }
            DataTable DtUnlimiteduser = new DataTable();
            DtUnlimiteduser = objEvents.CheckForUnlimtedUserEmail(UserID);
            if (DtUnlimiteduser.Rows.Count > 0)
            {
                if (Convert.ToBoolean(DtUnlimiteduser.Rows[0]["Event_Unlimited"].ToString()) == true)
                {
                    BulletinUsageCount = Convert.ToInt32(ConfigurationManager.AppSettings.Get("UnlimtedUserEmailsCount").Replace(",", ""));
                }
                else
                {
                    BulletinUsageCount = Convert.ToInt32(ConfigurationManager.AppSettings.Get("BulletinUsageCount").Replace(",", ""));
                }
            }
            else
            {
                BulletinUsageCount = Convert.ToInt32(ConfigurationManager.AppSettings.Get("BulletinUsageCount").Replace(",", ""));
            }
            if (Session["BulletinSend"] != null)
            {
                if (Session["BulletinSend"].ToString() != "")
                {
                    if (Session["BulletinSend"].ToString() == "1")
                    {
                        if (Session["CheckBulletinMess"] != null)
                        {
                            if (Session["CheckBulletinMess"].ToString() != "")
                            {
                                if (Session["CheckBulletinMess"].ToString() == "1")
                                {
                                    lblmess.Text = "<font color='green'>We could not send this content as there are no valid email ids.</font>";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "2")
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
                                    lblmess.Text = "<font color='green'>Content has been scheduled successfully except to the following ids as they appear to be invalid:</font><br>" + "<font color=#424242>" + invalidIds + "</font";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "3")
                                {
                                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.SendEmailContacts + "</font>";

                                }
                                else if (Session["CheckBulletinMess"].ToString() == "4")
                                {
                                    lblmess.Text = "<font color='green'>Content has been scheduled successfully. Some recipients have opted out of receiving future emails from you.</font>";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "5")
                                {
                                    lblmess.Text = "<font color='green'>We could not send this content because the recipients have opted out of receiving future emails from you.</font>";
                                }
                            }
                            else
                            {
                                lblmess.Text = "<font color='green'>" + Resources.LabelMessages.SendEmailContacts + "</font>";
                            }
                            Session["CheckBulletinMess"] = null;
                        }
                        else
                        {
                            lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessEventmail.Replace("event", "content") + "</font>";
                        }
                    }
                    else if (Session["BulletinSend"].ToString() == "2")
                    {
                        if (Session["CheckBulletinMess"] != null)
                        {
                            if (Session["CheckBulletinMess"].ToString() != "")
                            {
                                if (Session["CheckBulletinMess"].ToString() == "1")
                                {
                                    lblmess.Text = "<font color='green'>We could not schedule this content as there are no valid email ids.</font>";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "2")
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
                                    lblmess.Text = "<font color='green'>Content has been scheduled successfully except to the following ids as they appear to be invalid:</font><br>" + "<font color=#424242>" + invalidIds + "</font";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "3")
                                {
                                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessEventmail.Replace("event", "content") + "</font>";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "4")
                                {
                                    lblmess.Text = "<font color='green'>Content has been scheduled successfully. Some recipients have opted out of receiving future emails from you.</font>";
                                }
                                else if (Session["CheckBulletinMess"].ToString() == "5")
                                {
                                    lblmess.Text = "<font color='green'>We could not schedule this content because the recipients have opted out of receiving future emails from you.</font>";
                                }
                            }
                            else
                            {
                                lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessEventmail.Replace("event", "content") + "</font>";
                            }
                            Session["CheckBulletinMess"] = null;
                        }
                        else
                        {
                            lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessEvent.Replace("event", "bulletin") + "</font>";
                        }

                    }
                }
                Session["BulletinSend"] = null;
            }

            titleName = objApp.GetMobileAppSettingTabName(UserID, "Bulletins", DomainName);
            lblTitle.Text = titleName;
            ddlPageSize = (DropDownList)PageSizes.FindControl("ddlPageSize");
            ddlPageSize.AutoPostBack = true;
            ddlPageSize.SelectedIndexChanged += ddlPageSize_SelectedIndexChanged;
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
                        lblmess.Text = "<span style='color:green;'>Your content has been posted on facebook successfully.</span>";
                    }
                    if (Convert.ToInt32(Request.QueryString["fbStatus"]) == 0)
                    {
                        objCommon.UpdateSocialShareStatus(UserID, 0, "Facebook", Convert.ToInt32(Session["ContentID"]), 0);//updating status flag for report
                        lblmess.Text = "<span style='color:red;'>Facebook server is not responding. Please try again later.</span>";
                    }
                }

                lblOff.Visible = true;
                if (objCommon.DisplayOn_OffSettingsContent(UserID, WebConstants.Tab_Bulletins))
                {
                    lblOn.Visible = true;
                    lblOff.Visible = false;
                }

                RBAppOrder.SelectedValue = objCommon.DisplayOrderType(UserID, "Bulletins");

                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Bulletins");
                    if (string.IsNullOrEmpty(hdnPermissionType.Value))
                    {
                        UpdatePanel2.Visible = true;
                        UpdatePanel1.Visible = false;
                        lblerrormessage.Text = "<font face=arial size=2>You do not have permissions to access content.</font>";
                    }
                }
                //ends here

                //  Hdn control for Sorting
                hdnsortdire.Value = "";
                hdnsortcount.Value = "0";
                BindBulletinCategories();
                GetBulletins();
                if (Request.QueryString["SID"] != null)
                    Session["BulletinSuccess"] = EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["SID"]));
                if (Session["BulletinSuccess"] != null)
                {
                    lblmess.Text = Session["BulletinSuccess"].ToString();
                    Session.Remove("BulletinSuccess");
                    Session.Remove("BulletinID");
                }
                DataTable dtConfigPageKeys = objCommon.GetVerticalConfigsByType(DomainName, "Social");
                if (dtConfigPageKeys.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigPageKeys.Rows)
                    {
                        if (row[0].ToString() == "FacebookAPIKey")
                            hdnFacebookAppId.Value = row[1].ToString();
                    }
                }
                //Hide the Email Status for Lite Version
                if (Convert.ToBoolean(Session["IsLiteVersion"]) == false)
                {
                    GrdBulletins.Columns[8].Visible = true;
                }
                else
                {
                    GrdBulletins.Columns[8].Visible = false;
                }

            }
            //ShowCurrentArchive();
        }
        DropDownList ddlPageSize;
        private void ShowCurrentArchive()
        {
            lnkArchive.Visible = false;
            lnkChangeCurrent.Visible = false;
            if (hdnarchive.Value != "Archive")
                lnkArchive.Visible = true;
            else
                lnkChangeCurrent.Visible = true;
        }
        private void GetBulletins()
        {
            trPublish.Visible = false;
            trUnPublish.Visible = false;
            trCrisisExport.Visible = false;
            trShareOn1.Visible = true;
            hdnCommandArg.Value = "";
            string BulletinFilter = drpfilter.SelectedItem.Value;
            string BulletinCategory = ddlCategory.SelectedValue;
            DtBulletins = objBulletin.GetManageBulletins(Convert.ToInt32(BulletinFilter), BulletinCategory, UserID);
            if (hdnarchive.Value == "Archive")
            {
                GrdBulletins.Columns[2].Visible = true;
                GrdBulletins.Columns[1].Visible = false;
                ArchiveValue = "Archive";
            }
            else
            {
                GrdBulletins.Columns[2].Visible = false;
                GrdBulletins.Columns[1].Visible = true;
                ArchiveValue = "NoArchive";
            }
            int TotalBulletins = DtBulletins.Rows.Count;
            DtBulletins = RemoveArchive(DtBulletins, ArchiveValue);
            if (DtBulletins.Rows.Count > 0)
            {
                DtBulletins.Columns.Add("Sent_Flag", typeof(string));
                for (int i = 0; i < DtBulletins.Rows.Count; i++)
                {
                    DataTable dtScheduleEmails = objBusUpdate.CheckBusinessUpdateCampaignCountByID(Convert.ToInt32(DtBulletins.Rows[i]["Bulletin_ID"].ToString()), "Bulletins");
                    if (dtScheduleEmails.Rows.Count > 0)
                    {
                        if (dtScheduleEmails.Rows[0]["Count"].ToString() != "0")
                        {

                            if (Convert.ToInt32(dtScheduleEmails.Rows[0]["Scheduled"].ToString()) > 0 && Convert.ToInt32(dtScheduleEmails.Rows[0]["Sent"].ToString()) > 0)
                            {
                                DtBulletins.Rows[i]["Sent_Flag"] = "Sending";
                            }
                            else if (Convert.ToInt32(dtScheduleEmails.Rows[0]["Scheduled"].ToString()) > 0)
                            {
                                DtBulletins.Rows[i]["Sent_Flag"] = "Scheduled";
                            }
                            else if (Convert.ToInt32(dtScheduleEmails.Rows[0]["Scheduled"].ToString()) == 0 && Convert.ToInt32(dtScheduleEmails.Rows[0]["Sent"].ToString()) > 0)
                            {
                                DtBulletins.Rows[i]["Sent_Flag"] = "Sent";
                            }
                            else
                            {
                                DtBulletins.Rows[i]["Sent_Flag"] = "Cancelled";
                            }
                        }
                        else
                        {
                            //if (Convert.ToBoolean(DtBulletins.Rows[i]["IsPublished"].ToString()) == false)
                            //    DtBulletins.Rows[i]["Sent_Flag"] = "Work in Progress";
                            //else
                            //    DtBulletins.Rows[i]["Sent_Flag"] = "Completed";
                        }
                    }
                    else
                    {
                        //if (Convert.ToBoolean(DtBulletins.Rows[i]["IsPublished"].ToString()) == false)
                        //    DtBulletins.Rows[i]["Sent_Flag"] = "Work in Progress";
                        //else
                        //    DtBulletins.Rows[i]["Sent_Flag"] = "Completed";
                    }
                }
            }
            GetSavedUserData();
            Session["DtBulletins"] = DtBulletins;
            hdnShowButtons.Value = "1";
            showCurrArchives(true);
            if (TotalBulletins == 0)
                showCurrArchives(false);
            if (DtBulletins.Rows.Count == 0 && BulletinFilter == "0")
                hdnShowButtons.Value = "";
            else if (DtBulletins.Rows.Count == 0 && BulletinFilter != "0")
                ShowFilter = "1";
            GrdBulletins.PageSize = GetPageSize();
            GrdBulletins.DataSource = DtBulletins;
            GrdBulletins.DataBind();
        }
        private void showCurrArchives(bool Flag)
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
        protected void lnkCurrent_Click(object sender, EventArgs e)
        {
            CancelCamp.Visible = false;
            drpfilter.SelectedIndex = 0;
            lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>";
            lnkCurrent.Text = "<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>";
            hdnCommandArg.Value = "";
            hdnRowIndex.Value = "";
            hdnarchive.Value = "NoArchive";
            Session["ViewBGrid"] = null;
            //ShowCurrentArchive();
            GetBulletins();
        }
        protected void lnkGetArchive_Click(object sender, EventArgs e)
        {
            CancelCamp.Visible = false;
            drpfilter.SelectedIndex = 0;
            lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive.gif' title='Archive' border='0'/>";
            lnkCurrent.Text = "<img src='../../Images/Dashboard/current.gif' title='Current' border='0'/>";
            hdnCommandArg.Value = "";
            hdnRowIndex.Value = "";
            hdnarchive.Value = "Archive";
            Session["ViewBGrid"] = "Archive";
            //ShowCurrentArchive();
            GetBulletins();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowButtons = "1";
            Session["DtBulletins"] = null;
            GrdBulletins.PageIndex = 0;
            GetBulletins();
        }
        protected void drpfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowButtons = "1";
            Session["DtBulletins"] = null;
            GetBulletins();
        }
        protected void GrdBulletins_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = e.Row.Cells.Count;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkcam = e.Row.FindControl("lnkruncampaion") as LinkButton;
                Label lblcam = e.Row.FindControl("lblcam") as Label;
                LinkButton lb = e.Row.FindControl("lnkTitle") as LinkButton;
                Label lblbulletinthumb = e.Row.FindControl("lblbulletinthumb") as Label;
                Label lblApprovalStatus = e.Row.FindControl("lblApprovalStatus") as Label;
                string BulletinID = lb.CommandArgument;

                string ImageDisID = Guid.NewGuid().ToString();
                if (File.Exists(Server.MapPath("~") + "\\Upload\\Bulletins\\" + ProfileID.ToString() + "\\" + BulletinID + ".jpg"))
                    lblbulletinthumb.Text = "<img src='" + RootPath + "/Upload/Bulletins/" + ProfileID.ToString() + "/" + BulletinID + ".jpg?Guid=" + ImageDisID + "' border='1' width='100' height='50'/>";
                else
                    lblbulletinthumb.Text = "";
                if (lblcam.Text == "Scheduled" || lblcam.Text == "Cancelled")
                {
                    lnkcam.Text = lblcam.Text;
                    lnkcam.Visible = true;
                    lblcam.Visible = false;
                }
                else
                {
                    lnkcam.Visible = false;
                    lblcam.Visible = true;
                }
                if (lblApprovalStatus.Text.ToLower().Contains(Convert.ToString(Resources.ValidationValues.CheckScheduledPublish)))
                    lblApprovalStatus.CssClass = "schedulepublish";
                else
                    lblApprovalStatus.CssClass = "scheduleunpublish";
            }
            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[10].Visible = false;
                if (DomainName.ToLower().Contains("uspdhub"))
                    e.Row.Cells[10].Visible = true;
            }
        }
        protected void GrdBulletins_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            trUnPublish.Visible = false;
            trPublish.Visible = false;
            trCrisisExport.Visible = false;
            hdnShowButtons.Value = "1"; ; // *** To show all buttons ex: Preview, edit etc. *** //
            hdnCommandArg.Value = "";
            DtBulletins = (DataTable)Session["DtBulletins"];
            GrdBulletins.PageIndex = e.NewPageIndex;
            GrdBulletins.DataSource = DtBulletins;
            GrdBulletins.DataBind();
        }
        protected void GrdBulletins_Sorting(object sender, GridViewSortEventArgs e)
        {
            trUnPublish.Visible = trPublish.Visible = false;
            trCrisisExport.Visible = false;
            SortDir = Convert.ToInt32(hdnsortcount.Value);
            string SortExp = e.SortExpression.ToString();
            DtBulletins = (DataTable)Session["DtBulletins"];
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
            DataView Dv = new DataView(DtBulletins);
            if (SortDir == 0)
            {
                if (SortExp == "Name")
                {
                    Dv.Sort = "Bulletin_Title desc";
                }
                else if (SortExp == "Display")
                {
                    Dv.Sort = "IsDisplay desc";
                }
                else if (SortExp == "Date")
                {
                    Dv.Sort = "Modified_Date desc";
                }
                else if (SortExp == "Status")
                {
                    Dv.Sort = "IsDisplay desc";
                }
                else if (SortExp == "ExpDate")
                {
                    Dv.Sort = "Expiration_Date desc";
                }
                else if (SortExp == "CateID")
                {
                    Dv.Sort = "Bulletin_Category desc";
                }
                else if (SortExp == "CampaignStatus")
                {
                    Dv.Sort = "Sent_Flag desc";
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
                    Dv.Sort = "Bulletin_Title ASC";
                }
                else if (SortExp == "Display")
                {
                    Dv.Sort = "IsDisplay ASC";
                }
                else if (SortExp == "Date")
                {
                    Dv.Sort = "Modified_Date ASC";
                }
                else if (SortExp == "Status")
                {
                    Dv.Sort = "IsDisplay ASC";
                }
                else if (SortExp == "ExpDate")
                {
                    Dv.Sort = "Expiration_Date ASC";
                }
                else if (SortExp == "CateID")
                {
                    Dv.Sort = "Bulletin_Category ASC";
                }
                else if (SortExp == "CampaignStatus")
                {
                    Dv.Sort = "Sent_Flag ASC";
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
            Session["DtBulletins"] = Dv.ToTable();
            GrdBulletins.DataSource = Dv;
            GrdBulletins.DataBind();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
        protected void rbBulletin_CheckedChanged(object sender, EventArgs e)
        {
            hdnIsPusblished.Value = "";
            trCrisisExport.Visible = false;
            CheckBox rb = (CheckBox)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            LinkButton lnkTitle = (LinkButton)row.FindControl("lnkTitle");
            LinkButton lnkcamp = (LinkButton)row.FindControl("lnkruncampaion");
            Label lblStatus = (Label)row.FindControl("lblStatus");
            trShareOn1.Visible = true;
            trShareOn2.Visible = true;
            hdnCommandArg.Value = lnkTitle.CommandArgument;
            hdnRowIndex.Value = row.RowIndex.ToString();
            foreach (GridViewRow row1 in GrdBulletins.Rows)
            {
                if (((CheckBox)row1.FindControl("chkBulletinID")).Checked)
                {
                    hdnCommandArg.Value = (((LinkButton)row1.FindControl("lnkTitle")).CommandArgument);
                    lnkTitle = (LinkButton)row1.FindControl("lnkTitle");
                    hdnRowIndex.Value = row1.RowIndex.ToString();
                    lblStatus = (Label)row1.FindControl("lblStatus");
                    BullitenId = lnkTitle.CommandArgument;
                    break;
                }
            }

            hdnBulletinTitle.Value = lnkTitle.Text;
            GetSharestrings(Convert.ToInt32(hdnCommandArg.Value), lnkTitle.Text);
            int templateID = Convert.ToInt32(GrdBulletins.DataKeys[Convert.ToInt32(hdnRowIndex.Value)].Values["Template_BID"].ToString());

            trUnPublish.Visible = true;
            trPublish.Visible = true;


            DataTable dtCrisis = objBulletin.CheckBulletin(UserID, "", templateID, "");
            if (dtCrisis.Rows.Count > 0)
            {
                if (dtCrisis.Rows[0]["Template_Name"].ToString() == ConfigurationManager.AppSettings["CrisisExport"])
                {
                    trCrisisExport.Visible = true;
                }
            }

            if (lblStatus.Text == "True")
            {
                hdnIsPusblished.Value = "true";
            }
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

            lblerrormessage.Text = "";
            var expiryDate = Convert.ToString(GrdBulletins.DataKeys[Convert.ToInt32(hdnRowIndex.Value)].Values["Expiration_Date"].ToString());
            if (expiryDate != string.Empty)
            {
                if (Convert.ToDateTime(expiryDate) < DateTime.Now)
                {
                    trPublish.Visible = false;
                    lblerrormessage.Text = "Expired content is not allowed to publish.";
                }
            }
        }
        private void GetSharestrings(int BulletinID, string Bulletin_Title)
        {
            string description = string.Empty;
            articleTitle = Bulletin_Title.ToString();
            articleSummary = "What's on your mind?";
            //DataTable dtBulletin = new DataTable();
            //dtBulletin = objBulletin.GetBulletinByID(BulletinID);
            //description = Convert.ToString(dtBulletin.Rows[0]["Bulletin_HTML"]);
            //if (dtBulletin.Rows[0]["Form_Type"].ToString() == "Form")
            description = Bulletin_Title;
            GetAutoShareRecordStatus(BulletinID, Bulletin_Title);
            description = objCommon.GetSocialDescription(description);
            description = objCommon.ReplaceShortURltoHtmlString(description);
            string redirecturl = RootPath + "/OnlineBulletin.aspx?BLID=" + EncryptDecrypt.DESEncrypt(BulletinID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
            redirecturl = objCommon.longurlToshorturl(redirecturl);
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
            txtFacebookdes.Text = description;
            FacebookInurlinfo = "<a href='javascript:Display_FB_Popup()'><img src='../../images/Dashboard/facebooknew.gif' alt='Share on Facebook' width='55' height='36' title='Share on Facebook' border='0' /></a>";
            lblFacebookShare.Text = FacebookInurlinfo;
            //lblFacebookPageShare.Text = "<a href='javascript:post_on_page()'><img src='../../images/Dashboard/facebooknew.gif' alt='Share on Facebook Page' width='55' height='36' title='Share on Facebook Page' border='0' /></a>";
            //Facebook

            //Pinterest
            string PinterestUrl = "http://pinterest.com/pin/create/button/?url=" + RootPath + "/OnlineBulletin.aspx?BLID=" + EncryptDecrypt.DESEncrypt(BulletinID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&media=" + RootPath + "/Images/VerticalLogos/" + DomainName + "logo.png&description=" + tweetDesc;
            string PinterestUrlshare = "<a count-layout='horizontal' href='" + PinterestUrl + "'  target='_blank'><img border='0' src='../../images/Dashboard/PinterestLogo.gif' title='Pin It' alt='Share on Pinterest' width='55' height='36' /></a>";
            lblPinShare.Text = PinterestUrlshare;
            //Pinterest

            //***************** Commented by Suneel(Updates sharing via Linkedin)******************//
            //LinkedIN
            string update = EncryptDecrypt.DESEncrypt(BulletinID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
            string articleUrl = RootPath + "/OnlineBulletin.aspx?BLID=" + update;
            string articleSource = RootPath + "/OnlineBulletin.aspx?BLID=" + update;
            //string linkedInurlinfo1 = "http://www.linkedin.com/shareArticle?mini=true&url=" + HttpUtility.UrlEncode(articleUrl) + "&title=" + HttpUtility.UrlEncode(articleTitle) + "&summary=" + HttpUtility.UrlEncode(articleSummary) + "&source=" + HttpUtility.UrlEncode(articleSource) + "";
            //linkedInurlinfo = "<a href='" + linkedInurlinfo1.ToString() + "' target='_blank'><img src='../../images/Dashboard/linkedinnew.gif' title='Share on Linkedin' border='0' width='46' height='36'/></a>";
            //lbllinkedinShare.Text = linkedInurlinfo;
            //LinkedIn

            //Twitter
            string Twitterurlinfo1 = "http://www.twitter.com/share?url=" + redirecturl + "&text=" + tweetDesc;
            //string Twitterurlinfo1 = "http://twitter.com/home?status=" + articleTitle + " - " + articleUrl;
            //Twitterurlinfo = "<a href=\"javascript:TwitterShare('" + Twitterurlinfo1 + "')\" ><img src='../../images/Dashboard/twitternew.gif' alt='Share on Twitter' title='Share on Twitter' border='0' width='39' height='38'/></a>";
            Twitterurlinfo = "<a href='javascript:void(0);' onclick='TwitterShare(\"" + Twitterurlinfo1 + "\");' title='Click to share this post on Twitter'><img src='../../images/Dashboard/twitternew.gif' alt='Share on Twitter' title='Share on Twitter' border='0' width='39' height='38'/></a>";
            //lblTwitterShare.Text = Twitterurlinfo;
            //Twitter

            //Mail TO Url
            string ur = RootPath + "/OnlineBulletin.aspx?BLID=" + update;
            string url = RootPath + "/Business/Myaccount/ShareEmail.aspx?BL=" + update;
            Mailtourlinfo = "<a href=\"javascript:openEmailwindow('" + url + "')\"><img src='../../images/Dashboard/emailnew.gif' title='Share on Email' width='30' height='38' alt='Share on Email'/></a";
            lblEmailShare.Text = Mailtourlinfo;
            //Mail TO Url
        }
        private void GetAutoShareRecordStatus(int bulletinID, string bulletinTitle)
        {
            DataTable dtShareRecords = objCommon.CheckAutoShareRecordExists("Bulletin", bulletinID, bulletinTitle);
            for (int i = 0; i < dtShareRecords.Rows.Count; i++)
            {
                if (Convert.ToString(dtShareRecords.Rows[i]["Media_TYPE"]) == "Facebook")
                    hdnFacebook.Value = "false";

                if (Convert.ToString(dtShareRecords.Rows[i]["Media_TYPE"]) == "Twitter")
                    hdnTwitter.Value = "false";
            }
        }
        protected void chkBulletin_CheckedChanged(object sender, EventArgs e)
        {
            int SelectCount = 0;
            hdnCommandArg.Value = "";
            hdnRowIndex.Value = "";
            //Identify CheckBox is checked or not
            foreach (GridViewRow grdrow in GrdBulletins.Rows)
            {
                if (((CheckBox)grdrow.FindControl("chkBulletin")).Checked)
                {
                    SelectCount = SelectCount + 1;
                    LinkButton lnkname = (LinkButton)grdrow.FindControl("lnkTitle");
                    if (SelectCount == 1)
                    {
                        hdnCommandArg.Value = lnkname.CommandArgument;
                        hdnRowIndex.Value = grdrow.RowIndex.ToString();
                        LinkButton lnkcamp = (LinkButton)grdrow.FindControl("lnkruncampaion");
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
        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            if (hdnCommandArg.Value != "")
            {
                ShowPreview(Convert.ToInt32(hdnCommandArg.Value));

            }
        }
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            /** This is for allowing creators only 26/06/2013**/
            string authorPermission = string.Empty;
            string pubPermission = string.Empty;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                for (int i = 0; i < dtpermissions.Rows.Count; i++)
                {
                    if (dtpermissions.Rows[i]["ButtonType"].ToString() == "Bulletins")
                    {
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                            authorPermission = "A";
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                            pubPermission = "P";
                        break;
                    }
                }
            }
            if (((authorPermission == "A") || (authorPermission == "A" && pubPermission == "P") && hdnCommandArg.Value != "") || (Convert.ToString(Session["C_USER_ID"]) == "" || Session["C_USER_ID"] == null))
            {
                int Template_BID = Convert.ToInt32(GrdBulletins.DataKeys[Convert.ToInt32(hdnRowIndex.Value)].Values["Template_BID"].ToString());
                dtBulletinCheck = objBulletin.CheckBulletin(UserID, "", Template_BID, ""); // *** Check means user tries to create new bulletin *** //
                if (dtBulletinCheck.Rows.Count > 0)
                {
                    string RedirectUrl = string.Empty;
                    Session["BulletinID"] = hdnCommandArg.Value;
                    bool IsUserForms = false;
                    if (String.Equals(Convert.ToString(dtBulletinCheck.Rows[0]["IsUserForms"]), "true", StringComparison.OrdinalIgnoreCase))
                    {
                        IsUserForms = true;
                    }

                    if (IsUserForms)
                    {
                        //For Local RootPath
                        string userFormsUrl = "";
                        if (RootPath.ToLower().Contains("localhost"))
                        {
                            userFormsUrl = ConfigurationManager.AppSettings.Get("UserFormsRootPath") + "?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString())
                                  + "&UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&TempID=" + EncryptDecrypt.DESEncrypt(Template_BID.ToString()) + "&BID=" + EncryptDecrypt.DESEncrypt(hdnCommandArg.Value) + (Session["C_USER_ID"] != null ? ("&CUID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(Session["C_USER_ID"]))) : "");
                        }
                        else
                        {
                            //For Test RootPath
                            userFormsUrl = RootPath + "/UserForms/Default.aspx" + "?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString())
                                   + "&UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&TempID=" + EncryptDecrypt.DESEncrypt(Template_BID.ToString()) + "&BID=" + EncryptDecrypt.DESEncrypt(hdnCommandArg.Value) + (Session["C_USER_ID"] != null ? ("&CUID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(Session["C_USER_ID"]))) : "");
                        }

                        RedirectUrl = Page.ResolveClientUrl(userFormsUrl);
                    }
                    else
                    {
                        if (Convert.ToBoolean(dtBulletinCheck.Rows[0]["IsUrl"].ToString()))
                            RedirectUrl = Page.ResolveClientUrl("~" + dtBulletinCheck.Rows[0]["Template"].ToString());
                        else
                        {
                            var dtBulletinDetails = objBulletin.GetBulletinDetailsByID(Convert.ToInt32(hdnCommandArg.Value));
                            DateTime bulletinsModuleDate = Convert.ToDateTime(ConfigurationManager.AppSettings.Get("BulletinModifyDate"));
                            if (Convert.ToDateTime(dtBulletinDetails.Rows[0]["Created_Date"]) > bulletinsModuleDate)
                            {
                                RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/EditBulletin2.aspx?BulletinID=" + hdnCommandArg.Value);
                            }
                            else
                            {
                                RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/EditBulletin.aspx?BulletinID=" + hdnCommandArg.Value);
                            }
                        }
                    }

                    Response.Redirect(RedirectUrl);
                }
            }
            else
                lblmess.Text = "You don't have permission to edit Content.";
        }
        protected void lnkCopy_Click(object sender, EventArgs e)
        {
            CopyBulletin();
        }
        private void CopyBulletin()
        {
            if (hdnCommandArg.Value != "")
            {
                if (File.Exists(Server.MapPath("~") + "\\Upload\\Bulletins\\" + ProfileID.ToString() + "\\" + hdnCommandArg.Value + ".jpg"))
                    lblBulletinImage.Text = "<img src='" + RootPath + "/Upload/Bulletins/" + ProfileID.ToString() + "/" + hdnCommandArg.Value + ".jpg' border='1' width='350' height='350'/>";
                else
                    lblBulletinImage.Text = "<font size='3' weight='bold'>No Thumbnail</font>";
                MPECopy.Show();
                txtBulletinName.Text = "";
            }
        }
        protected void lnkRename_Click(object sender, EventArgs e)
        {
            RenameContent();
        }
        private void RenameContent()
        {
            lblExisting.Text = "";
            lblRenameMsg.Text = "";
            if (hdnCommandArg.Value != "")
            {
                DataTable dtBulletin = objBulletin.GetBulletinByID(Convert.ToInt32(hdnCommandArg.Value));
                if (dtBulletin.Rows.Count > 0)
                {
                    lblExisting.Text = Convert.ToString(dtBulletin.Rows[0]["Bulletin_Title"]);
                }
                if (File.Exists(Server.MapPath("~") + "\\Upload\\Bulletins\\" + ProfileID.ToString() + "\\" + hdnCommandArg.Value + ".jpg"))
                    lblRenameImage.Text = "<img src='" + RootPath + "/Upload/Bulletins/" + ProfileID.ToString() + "/" + hdnCommandArg.Value + ".jpg' border='1' width='350' height='350'/>";
                else
                    lblRenameImage.Text = "<font size='3' weight='bold'>No Thumbnail</font>";
                modalRename.Show();
                txtNewName.Text = "";
            }
        }
        protected void lnkdelete_Click(object sender, EventArgs e)
        {
            if (hdnarchive.Value != "Archive")
            {
                foreach (GridViewRow row in GrdBulletins.Rows)
                {
                    if (((CheckBox)row.FindControl("chkBulletinID")).Checked)
                    {
                        int BulletinID = int.Parse(((LinkButton)(row.FindControl("lnkTitle"))).CommandArgument);
                        #region Save User Activity Log
                        string bulletinTitle = ((LinkButton)(row.FindControl("lnkTitle"))).Text;
                        objCommon.InsertUserActivityLog("has deleted a content named <b>" + bulletinTitle + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);
                        #endregion
                        objBulletin.DeleteBulletin(BulletinID);
                    }
                }
            }
            else
            {
                //Identify CheckBox is checked or not
                foreach (GridViewRow row in GrdBulletins.Rows)
                {
                    if (((CheckBox)row.FindControl("chkBulletin")).Checked)
                    {
                        int BulletinID = int.Parse(((LinkButton)(GrdBulletins.Rows[row.RowIndex].FindControl("lnkTitle"))).CommandArgument);
                        #region Save User Activity Log
                        string bulletinTitle = ((LinkButton)(GrdBulletins.Rows[row.RowIndex].FindControl("lnkTitle"))).Text;
                        objCommon.InsertUserActivityLog("has deleted a content named <b>" + bulletinTitle + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);
                        #endregion
                        objBulletin.DeleteBulletin(BulletinID);
                    }
                }
            }
            CancelCamp.Visible = false;
            lblmess.Text = "<font size='3'>Your selection(s) have been deleted successfully.</font>";
            GrdBulletins.PageIndex = 0;
            GetBulletins();
        }
        protected void lnkArchive_Click(object sender, EventArgs e)
        {
            string controlID = "";
            bool ArchiveFlag = true;
            LinkButton lnkCurrArchive = sender as LinkButton;
            string lnkText = lnkCurrArchive.Text;
            if (lnkText.Contains("Current"))
            {
                controlID = "chkBulletin";
                ArchiveFlag = false;
            }
            else
            {
                controlID = "chkBulletinID";
                ArchiveFlag = true;
            }
            //Identify CheckBox is checked or not
            foreach (GridViewRow row in GrdBulletins.Rows)
            {
                if (((CheckBox)row.FindControl(controlID)).Checked)
                {
                    int ArchiveID = Convert.ToInt32(((LinkButton)(row.FindControl("lnkTitle"))).CommandArgument);
                    objCommon.ArchiveSelectedNewsletter(ArchiveID, ArchiveFlag, "Bulletin", C_UserID);
                }
            }

            if (ArchiveFlag == false)
                lblmess.Text = Resources.LabelMessages.ArchiveCurrentSuccess.Replace("#type#", "selected content");
            else
                lblmess.Text = Resources.LabelMessages.ArchiveSuccess.Replace("#type#", "selected content");
            GetBulletins();
        }
        protected void btnCopycancel_Click(object sender, EventArgs e)
        {
            MPECopy.Hide();
        }
        protected void btnCopyBulletin_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnCommandArg.Value != "")
                {
                    int Template_BID = Convert.ToInt32(GrdBulletins.DataKeys[Convert.ToInt32(hdnRowIndex.Value)].Values["Template_BID"].ToString());
                    dtBulletinCheck = objBulletin.CheckBulletin(UserID, txtBulletinName.Text.Trim(), Template_BID, "Check"); // *** Check means user tries to create new bulletin *** //
                    if (dtBulletinCheck.Rows.Count > 0)
                    {
                        string RedirectUrl = string.Empty;

                        int CopyBullentinID = objBulletin.CopyBulletin(Convert.ToInt32(hdnCommandArg.Value), txtBulletinName.Text.Trim(), UserID, Convert.ToInt32(Session["ProfileID"].ToString()));
                        if (CopyBullentinID > 0)
                        {
                            Session["BulletinID"] = CopyBullentinID;

                            bool IsUserForms = false;
                            if (String.Equals(Convert.ToString(dtBulletinCheck.Rows[0]["IsUserForms"]), "true", StringComparison.OrdinalIgnoreCase))
                            {
                                IsUserForms = true;
                            }

                            //For New Project UserForms
                            if (IsUserForms)
                            {
                                //For Local RootPath

                                string userFormsUrl = "";
                                if (RootPath.ToLower().Contains("localhost"))
                                {
                                    userFormsUrl = ConfigurationManager.AppSettings.Get("UserFormsRootPath") + "?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString())
                                          + "&UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&CUID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(Session["C_USER_ID"]))
                                          + "&TempID=" + EncryptDecrypt.DESEncrypt(Template_BID.ToString()) + "&BID=" + EncryptDecrypt.DESEncrypt(CopyBullentinID.ToString());
                                }
                                else
                                {
                                    //For Test RootPath

                                    userFormsUrl = RootPath + "/UserForms/Default.aspx" + "?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString())
                                           + "&UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&CUID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(Session["C_USER_ID"]))
                                           + "&TempID=" + EncryptDecrypt.DESEncrypt(Template_BID.ToString()) + "&BID=" + EncryptDecrypt.DESEncrypt(CopyBullentinID.ToString());
                                }

                                RedirectUrl = Page.ResolveClientUrl(userFormsUrl);
                            }
                            else
                            {
                                if (Convert.ToBoolean(dtBulletinCheck.Rows[0]["IsUrl"].ToString()))
                                    RedirectUrl = Page.ResolveClientUrl("~" + dtBulletinCheck.Rows[0]["Template"].ToString());
                                else
                                {
                                    //   RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/EditBulletin.aspx?BulletinID=" + CopyBullentinID);
                                    var dtBulletinDetails = objBulletin.GetBulletinDetailsByID(Convert.ToInt32(hdnCommandArg.Value));
                                    DateTime bulletinsModuleDate = Convert.ToDateTime(ConfigurationManager.AppSettings.Get("BulletinModifyDate"));
                                    if (Convert.ToDateTime(dtBulletinDetails.Rows[0]["Created_Date"]) > bulletinsModuleDate)
                                    {
                                        RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/EditBulletin2.aspx?BulletinID=" + CopyBullentinID);
                                    }
                                    else
                                    {
                                        RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/EditBulletin.aspx?BulletinID=" + CopyBullentinID);
                                    }
                                }
                            }


                            // Save User Activity Log
                            objCommon.InsertUserActivityLog("has created a bulletin titled <b>" + txtBulletinName.Text + "</b> by copying <b>" + hdnBulletinTitle.Value + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);

                            Response.Redirect(RedirectUrl);


                        }
                        else
                        {
                            lbleditext.Text = "Sorry, an error has been occurred while copy the content. Please try again.";
                            MPECopy.Show();
                        }
                    }
                    else
                    {
                        lbleditext.Text = "Sorry, you already have  content with this name; please enter another name.";
                        MPECopy.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                lbleditext.Text = ex.Message.ToString();
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
                    if (txtNewName.Text.Trim() != "")
                    {
                        int outputID = objBulletin.RenameContent(Convert.ToInt32(hdnCommandArg.Value), txtNewName.Text.Trim(), C_UserID, "Bulletins", ProfileID);
                        if (outputID > 0)
                        {
                            // *** Silent PushNotification  *** //
                            objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, Convert.ToInt32(hdnCommandArg.Value), "Bulletins", "Rename");
                            lblmess.Text = "<font color='Green' size='3'>" + Resources.LabelMessages.RenameSuccess.Replace("#ExistingContentName#", lblExisting.Text.Trim()).Replace("#NewContentName#", txtNewName.Text.Trim()) + "</font>";
                            GetBulletins();
                            modalRename.Hide();

                        }
                        else
                        {
                            lbleditext.Text = "Sorry, you already have  content with this name; please enter another name.";
                            MPECopy.Show();
                        }
                    }
                    else
                        lbleditext.Text = Resources.LabelMessages.ItemTitleEmpty;
                }
            }
            catch (Exception ex)
            {
                lblRenameMsg.Text = "<font color='red' size='3'>" + ex.Message.ToString() + "</font>";
            }
        }
        protected void lnkPublish_Click(object sender, EventArgs e)
        {
            /** This is for allowing publishers only 26/06/2013**/
            string authorPermission = string.Empty;
            string pubPermission = string.Empty;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                for (int i = 0; i < dtpermissions.Rows.Count; i++)
                {
                    if (dtpermissions.Rows[i]["ButtonType"].ToString() == "Bulletins")
                    {
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                            authorPermission = "A";
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                            pubPermission = "P";
                        break;
                    }

                }
                if (((pubPermission == "P") || (authorPermission == "A" && pubPermission == "P")) && hdnCommandArg.Value != "")
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
                        foreach (GridViewRow row in GrdBulletins.Rows)
                        {
                            if (((CheckBox)row.FindControl("chkBulletinID")).Checked)
                            {
                                hdnCommandArg.Value = ((LinkButton)(row.FindControl("lnkTitle"))).CommandArgument;
                                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "" && hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //roles & permissions...
                                {
                                    UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), false);
                                    int templateBid = Convert.ToInt32(GrdBulletins.DataKeys[Convert.ToInt32(hdnRowIndex.Value)].Values["Template_BID"].ToString());
                                    dtBulletinCheck = objBulletin.CheckBulletin(UserID, "", templateBid, ""); // *** Check means user tries to create new bulletin *** //
                                    if (dtBulletinCheck.Rows.Count > 0)
                                    {
                                        string returnvalue = string.Empty;
                                        if (Convert.ToBoolean(dtBulletinCheck.Rows[0]["IsUrl"].ToString()))
                                            returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.BULLETIN, UserID, Session["username"].ToString(), dtBulletinCheck.Rows[0]["Template_Name"].ToString(), DomainName);
                                        else
                                            returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.BULLETIN, UserID, Session["username"].ToString(), PageNames.BULLETIN, DomainName);
                                    }
                                }
                                else
                                    UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), true);
                            }
                        }// END foreach
                        hdnCommandArg.Value = "";

                        //ends here...
                        lblmess.Text = "<font color='green'>Your content has been published successfully.</font>";
                        GetBulletins();

                    }

                }
                else
                    lblmess.Text = "You don't have permission to publish Content.";
            }
            else
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
                    foreach (GridViewRow row in GrdBulletins.Rows)
                    {
                        if (((CheckBox)row.FindControl("chkBulletinID")).Checked)
                        {
                            hdnCommandArg.Value = ((LinkButton)(row.FindControl("lnkTitle"))).CommandArgument;
                            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "" && hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //roles & permissions...
                            {
                                UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), false);
                                int templateBid = Convert.ToInt32(GrdBulletins.DataKeys[Convert.ToInt32(hdnRowIndex.Value)].Values["Template_BID"].ToString());
                                dtBulletinCheck = objBulletin.CheckBulletin(UserID, "", templateBid, ""); // *** Check means user tries to create new bulletin *** //
                                if (dtBulletinCheck.Rows.Count > 0)
                                {
                                    string returnvalue = string.Empty;
                                    if (Convert.ToBoolean(dtBulletinCheck.Rows[0]["IsUrl"].ToString()))
                                        returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.BULLETIN, UserID, Session["username"].ToString(), dtBulletinCheck.Rows[0]["Template_Name"].ToString(), DomainName);
                                    else
                                        returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.BULLETIN, UserID, Session["username"].ToString(), PageNames.BULLETIN, DomainName);
                                }
                            }
                            else
                                UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), true);
                        }
                    }// END foreach
                    hdnCommandArg.Value = "";

                    //ends here...
                    lblmess.Text = "<font color='green'>Your content has been published successfully.</font>";
                    GetBulletins();

                }
            }
        }
        private void ShowPublishModal()
        {
            txtPublishDate.Text = objCommon.ConvertToUserTimeZone(ProfileID).ToString("MM/dd/yyyy");
            ModalPopupPublish.Show();
        }
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (txtPublishDate.Text.Trim() != "")
            {
                DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
                DateTime? datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
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
                //Identify CheckBox is checked or not
                foreach (GridViewRow row in GrdBulletins.Rows)
                {
                    if (((CheckBox)row.FindControl("chkBulletinID")).Checked)
                    {
                        hdnCommandArg.Value = ((LinkButton)(row.FindControl("lnkTitle"))).CommandArgument;
                        if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "" && hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //roles & permissions...
                        {
                            UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), false);
                            int templateBid = Convert.ToInt32(GrdBulletins.DataKeys[Convert.ToInt32(hdnRowIndex.Value)].Values["Template_BID"].ToString());
                            dtBulletinCheck = objBulletin.CheckBulletin(UserID, "", templateBid, ""); // *** Check means user tries to create new bulletin *** //
                            if (dtBulletinCheck.Rows.Count > 0)
                            {
                                string returnvalue = string.Empty;
                                if (Convert.ToBoolean(dtBulletinCheck.Rows[0]["IsUrl"].ToString()))
                                    returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.BULLETIN, UserID, Session["username"].ToString(), dtBulletinCheck.Rows[0]["Template_Name"].ToString(), DomainName);
                                else
                                    returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.BULLETIN, UserID, Session["username"].ToString(), PageNames.BULLETIN, DomainName);
                            }
                        }
                        else
                            UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), true);
                    }
                }// END foreach
                hdnCommandArg.Value = "";

                //ends here...
                lblmess.Text = "<font color='green'>Your content has been published successfully.</font>";
                GetBulletins();
                ModalPopupPublish.Hide();
            }

        }
        protected void btnPublishCancel_Click(object sender, EventArgs e)
        {
        }
        protected void lnkUnpublish_Click(object sender, EventArgs e)
        {
            DateTime? PublishDate = null;
            //Identify CheckBox is checked or not
            foreach (GridViewRow row in GrdBulletins.Rows)
            {
                if (((CheckBox)row.FindControl("chkBulletinID")).Checked)
                {
                    hdnCommandArg.Value = ((LinkButton)(row.FindControl("lnkTitle"))).CommandArgument;
                    UpdatePublish(false, Convert.ToInt32(hdnCommandArg.Value), PublishDate, false);
                }
            }
            hdnCommandArg.Value = "";
            lblmess.Text = "<font color='green'>Your content has been made private successfully.</font>";
            GetBulletins();
        }
        private void UpdatePublish(bool flag, int bulletinID, DateTime? publishDate, bool isPublished)
        {
            objBulletin.UpdateBulletinPublish(flag, UserID, C_UserID, bulletinID, publishDate, isPublished);
        }
        protected void lnkTitle_Click(object sender, EventArgs e)
        {
            LinkButton lnkTitle = sender as LinkButton;
            ShowPreview(Convert.ToInt32(lnkTitle.CommandArgument));
        }
        private void ShowPreview(int bulletinID)
        {
            dtBulletinCheck = objBulletin.GetBulletinByID(bulletinID); // *** Check means user tries to create new bulletin *** //
            if (dtBulletinCheck.Rows.Count > 0)
            {
                string templateTitle = Convert.ToString(dtBulletinCheck.Rows[0]["Template_Name"]);
                string preview = string.Empty;
                if (templateTitle.ToLower().Contains("Weekly Report".ToLower()) || templateTitle.ToLower().Contains("Crime Report".ToLower()))
                {
                    preview = objCommon.GetHeaderForBulletins(UserID, ProfileID, true);
                }
                else
                {
                    preview = objCommon.GetHeaderForBulletins(UserID, ProfileID, false);
                }

                lblbulletinamme.Text = dtBulletinCheck.Rows[0]["Bulletin_Title"].ToString();
                string htmlString = preview.Replace("#BuildHtmlForForm#", dtBulletinCheck.Rows[0]["Bulletin_HTML"].ToString().Replace("padding-top: 100px; padding-left: 50px;", "padding-top: 100px; padding-left: 150px;"));
                lblPreviewHTML.Text = htmlString;
                MPEPreview.Show();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>LoadEventForPlayVideo()</script>", false);
            }
        }
        protected void lnkSend_Click(object sender, EventArgs e)
        {
            int CheckSch = 0;
            CheckSch = objBulletin.CheckforBulletinSchedule(UserID);

            int CheckCam = 0;
            if (CheckSch > 0)
            {
                CheckCam = 1;
            }

            CheckSch = BulletinUsageCount - CheckSch;
            if (CheckSch > 0)
            {
                Session["BulletinID"] = null;
                Session["BulletinDes"] = null;
                int BulletinID = 0;
                DataTable DtGetBulletin = new DataTable();
                BulletinID = Convert.ToInt32(hdnCommandArg.Value);
                DtGetBulletin = objBulletin.GetBulletinDetailsByID(BulletinID);

                Session["BulletinID"] = BulletinID.ToString();
                Session["BulletinDes"] = DtGetBulletin.Rows[0]["Bulletin_HTML"].ToString();
                if (hdnarchive.Value == "Archive")
                    Session["ViewGrid"] = hdnarchive.Value;
                string url = Page.ResolveClientUrl("~/Business/MyAccount/SendBulletins.aspx");
                Response.Redirect(url);
            }
            else
            {
                if (CheckCam > 0)
                {
                    string MaxSchDate = string.Empty;
                    MaxSchDate = objBulletin.GetBulletinMaxScheduleingDate(UserID);
                    MaxSchDate = MaxSchDate.Replace("12:00:00 AM", "");
                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.AlreadyHaveBulletinCampaign + " " + MaxSchDate + ".</font>";
                }
                else
                {
                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendaffiliatecountExceeded + "</font>";
                }
            }

        }
#if fixme
        protected void btnUpdateImgOrderNumber_Click(object sender, EventArgs e)
        {
            try
            {
                int cnt = 0;
                int cont = 0;
                int rcont = 0;
                int conts = 0;
                if (DataList1.Items.Count > 0)
                {
                    for (int i = 0; i < DataList1.Items.Count; i++)
                    {
                        TextBox hiddenorder = DataList1.Items[i].FindControl("lblhiddenorder") as TextBox;
                        if (hiddenorder.Text != "")
                        {
                            string pattern = @"^[0-9]+$";
                            Match match = Regex.Match(hiddenorder.Text, pattern);
                            if (!(match.Success))
                                rcont = rcont + 1;
                            if (hiddenorder.Text == "0")
                                conts = conts + 1;
                        }
                    }
                    if (rcont > 0)
                    {
                        lbl2.Text = "<font color=red face=arial size=2><b>Please enter only numbers in order number.</b></font>";
                        ModalPopupImgOrderNo.Show();
                    }
                    else if (conts > 0)
                    {
                        lbl2.Text = "<font color=red face=arial size=2><b>Bulletin(s) order number must be greater than zero.</b></font>";
                        ModalPopupImgOrderNo.Show();
                    }
                    else
                    {
                        for (int i = 0; i < DataList1.Items.Count; i++)
                        {
                            TextBox lblhiddenorder = DataList1.Items[i].FindControl("lblhiddenorder") as TextBox;
                            Label lblphotoId = DataList1.Items[i].FindControl("lblprimary") as Label;
                            for (int j = 0; j < DataList1.Items.Count; j++)
                            {
                                int value = 0;
                                if (lblhiddenorder.Text != "")
                                    value = Convert.ToInt32(lblhiddenorder.Text);
                                TextBox lblhiddenorders = DataList1.Items[j].FindControl("lblhiddenorder") as TextBox;
                                Label lblphotoId1 = DataList1.Items[j].FindControl("lblprimary") as Label;
                                if (lblphotoId.Text != lblphotoId1.Text)
                                {
                                    int hdnval = 0;
                                    if (lblhiddenorders.Text != "")
                                        hdnval = Convert.ToInt32(lblhiddenorders.Text);
                                    if (value == hdnval)
                                        cnt = cnt + 1;
                                }
                            }

                            if (lblhiddenorder.Text == "")
                                cont = cont + 1;
                        }
                        if (cont > 0)
                        {
                            lbl2.Text = "<font color=red face=arial size=2><b>Please enter order number for bulletin(s).</b></font>";
                            ModalPopupImgOrderNo.Show();
                        }
                        else if (cnt > 0)
                        {
                            lbl2.Text = "<font color=red face=arial size=2><b>Please check the order sequence, duplicates are not allowed.</b></font>";
                            ModalPopupImgOrderNo.Show();
                        }
                        else
                        {
                            int val = 0;
                            for (int i = 0; i < DataList1.Items.Count; i++)
                            {
                                Label lblphotoId1 = DataList1.Items[i].FindControl("lblprimary") as Label;
                                TextBox lblhiddenorder = DataList1.Items[i].FindControl("lblhiddenorder") as TextBox;
                                val = objBulletin.UpdateBulletinsOrder(Convert.ToInt32(lblphotoId1.Text), Convert.ToInt32(lblhiddenorder.Text), C_UserID);
                            }
                            if (val > 0)
                            {
                                lblmess.Text = "<font color=green face=arial size=2><b>The order of your bulletins has been updated successfully.</b></font>";
                            }
                            GetBulletins();
                            ModalPopupImgOrderNo.Hide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
#endif
        protected void btnUpdateImgOrderNumber_Click(object sender, EventArgs e)
        {
            try
            {
                if (OrderListView.Items.Count > 0)
                {
                    for (int i = 0; i < OrderListView.Items.Count; i++)
                    {
                        Label lblKey = OrderListView.Items[i].FindControl("lblKey") as Label;
                        objBulletin.UpdateBulletinsOrder(Convert.ToInt32(lblKey.Text), i + 1, C_UserID);
                    }
                    lblmess.Text = "<font color=green face=arial size=2><b>The order of your contents has been updated successfully.</b></font>";
                    objBus.Insert_SilentPushMessages(Convert.ToInt32(HttpContext.Current.Session["ProfileID"].ToString()), DateTime.Now, false, 0, "Bulletins", "OrderNumberUpdate");
                    GetBulletins();
                    ModalPopupImgOrderNo.Hide();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void btnCancelImgOrderNumber_Click(object sender, EventArgs e)
        {

        }
        protected void btnEditOrderNumber_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtobj = new DataTable();
                lbl2.Text = string.Empty;
                dtobj = objBulletin.GetBulletins(UserID);
                if (dtobj.Rows.Count > 0)
                {
                    OrderListView.DataSource = null;
                    OrderListView.DataSource = dtobj;
                    OrderListView.DataBind();
                    ModalPopupImgOrderNo.Show();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowOrderScript();", true);
                }
                else
                    lblmess.Text = "<font color=red face=arial size=2><b>" + Resources.LabelMessages.OrderChangedPublishedContent + "</b></font>";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        protected void OrderListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label lblOrderThumb;
            Label lblKey;
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                lblOrderThumb = (Label)e.Item.FindControl("lblOrderThumb");
                lblKey = (Label)e.Item.FindControl("lblKey");
                string ImageDisID = Guid.NewGuid().ToString();
                if (File.Exists(Server.MapPath("~") + "\\Upload\\Bulletins\\" + ProfileID.ToString() + "\\" + lblKey.Text + ".jpg"))
                    lblOrderThumb.Text = "<img src='" + RootPath + "/Upload/Bulletins/" + ProfileID.ToString() + "/" + lblKey.Text + ".jpg?Guid=" + ImageDisID + "' border='1' width='50' height='20'/>";
                else
                    lblOrderThumb.Text = "";
            }
        }
        protected void lnkPrint_Click(object sender, EventArgs e)
        {
            //ShowPrintFlyer();
            int BID = Convert.ToInt32(hdnCommandArg.Value);
            var dtBulletinDetails = objBulletin.GetBulletinByID(BID);
            string templateTitle = Convert.ToString(dtBulletinDetails.Rows[0]["Template_Name"]);

            string PrintHTML = "";
            if (string.IsNullOrEmpty(dtBulletinDetails.Rows[0]["Printer_Html"].ToString()))
            {
                PrintHTML = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_HTML"]);
            }
            else
            {
                PrintHTML = Convert.ToString(dtBulletinDetails.Rows[0]["Printer_Html"]);
            }
            string preview = string.Empty;
            if (templateTitle.ToLower().Contains("Weekly Report".ToLower()) || templateTitle.ToLower().Contains("Crime Report".ToLower()))
            {
                preview = objCommon.GetHeaderForBulletins(UserID, ProfileID, true);
            }
            else
            {
                preview = objCommon.GetHeaderForBulletins(UserID, ProfileID, false);
            }
            preview = preview.Replace("background: url(" + RootPath + "/images/BulletinThumbs/dotted.png) repeat;", "");
            preview = preview.Replace("background: #eeeeee url(" + RootPath + "/images/header_bg.gif) repeat-x;", "");
            PrintHTML = preview.Replace("#BuildHtmlForForm#", PrintHTML.Replace("padding-top: 100px; padding-left: 50px;", "padding-top: 100px; padding-left: 150px;"));
            GenerateHTMLtoPDF(PrintHTML, objCommon.MakeValidFileName(Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_Title"])));
        }
        private void GenerateHTMLtoPDF(string reportHTML, string bulletinTitle)
        {
            //set the license key
            reportHTML = "<div style='padding-left:40px;'>" + reportHTML + "</div>";
            objCommon.HtmlToPDF_Print(reportHTML, bulletinTitle);

            /*
            LicensingManager.LicenseKey = ConfigurationManager.AppSettings.Get("pdfkeyval");
            //create a PDF document
            Document document = new Document();
            document.CompressionLevel = CompressionLevel.NormalCompression;
            document.Margins = new Margins(10, 10, 0, 0);
            document.Security.CanPrint = true;
            document.Security.UserPassword = "";
            document.DocumentInformation.Author = "Logictree IT Solutions, Inc";
            document.ViewerPreferences.HideToolbar = false;
            PdfPage page = document.Pages.AddNewPage(PageSize.A4, new Margins(0, 0, 0, 0), PageOrientation.Portrait);
            page.ShowFooterTemplate = true;
            page.ShowHeaderTemplate = true;
            string headerHtmlUrl = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td style=\"height:30pt;\">&nbsp;</td></tr></table>";
            HtmlToPdfElement headerHtmlToPdf = new HtmlToPdfElement(0, 0, 0, 30, headerHtmlUrl, null, 1024, 0);
            HtmlToPdfElement footerHtmlToPdf = new HtmlToPdfElement(0, 0, 0, 30, headerHtmlUrl, null, 1024, 0);
            document.HeaderTemplate = document.AddTemplate(document.Pages[0].ClientRectangle.Width, 30);
            document.FooterTemplate = document.AddTemplate(document.Pages[0].ClientRectangle.Width, 30);
            // create a HTML to PDF converter element to be added to the header template
            document.HeaderTemplate.AddElement(headerHtmlToPdf);
            document.FooterTemplate.AddElement(footerHtmlToPdf);
            PdfFont font = document.Fonts.Add(new System.Drawing.Font(new System.Drawing.FontFamily("Arial"), 14, System.Drawing.GraphicsUnit.Point));
            AddElementResult addResult;
            float xLocation = 5;
            float yLocation = 5;
            float width = -1;
            float height = -1;
            // convert HTML to PDF
            HtmlToPdfElement htmlToPdfElement;
            htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, width, height, reportHTML.ToString(), null);
            string pdfilenameval = bulletinTitle.ToString() + "_" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + ""
                + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".pdf"; ;
            // add theHTML to PDF converter element to page
            htmlToPdfElement.HtmlViewerWidth = 793;
            htmlToPdfElement.AvoidImageBreak = true;
            htmlToPdfElement.AvoidTextBreak = true;
            addResult = page.AddElement(htmlToPdfElement);
            string savelocation = Server.MapPath("~/Upload/").ToString() + pdfilenameval;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            document.Save(Response, false, pdfilenameval);
            string VirtualPath = savelocation;
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + pdfilenameval);
            Response.TransmitFile(VirtualPath);
            */
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void lnkCrisisExport_Click(object sender, EventArgs e)
        {
            DataTable dtBulletinDetails = objBulletin.GetBulletinDetailsByID(Convert.ToInt32(hdnCommandArg.Value));
            if (dtBulletinDetails.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtBulletinDetails.Rows[0]["Custom_XML"].ToString()))
                {
                    string reportTitle = "";
                    string associate = "";
                    string logInDate = "";
                    string logInTime = "";
                    string logInTimeNoon = "";
                    string logOutDate = "";
                    string logOutTime = "";
                    string logOutTimeNoon = "";
                    string transferTo = "";
                    string xml = dtBulletinDetails.Rows[0]["Custom_XML"].ToString();
                    DataTable dtexportCrisis = new DataTable();
                    dtexportCrisis.Columns.Add("Report Title", typeof(string));
                    dtexportCrisis.Columns.Add("Associate", typeof(string));
                    dtexportCrisis.Columns.Add("Log In Date", typeof(string));
                    dtexportCrisis.Columns.Add("Log In Time", typeof(string));
                    dtexportCrisis.Columns.Add("AM / PM", typeof(string));
                    dtexportCrisis.Columns.Add("Log Out Date", typeof(string));
                    dtexportCrisis.Columns.Add("Log Out Time", typeof(string));
                    dtexportCrisis.Columns.Add("AM / PM ", typeof(string));
                    dtexportCrisis.Columns.Add("Transfer To", typeof(string));
                    dtexportCrisis.Columns.Add("Call Number", typeof(string));
                    dtexportCrisis.Columns.Add("Call Time", typeof(string));
                    dtexportCrisis.Columns.Add("AM / PM  ", typeof(string));
                    dtexportCrisis.Columns.Add("Caller Type", typeof(string));
                    dtexportCrisis.Columns.Add("Caller Type Agency Name", typeof(string));
                    dtexportCrisis.Columns.Add("Caller Type Law Region Name", typeof(string));
                    dtexportCrisis.Columns.Add("Caller Request Agency", typeof(string));
                    dtexportCrisis.Columns.Add("Caller Request Counceling", typeof(string));
                    dtexportCrisis.Columns.Add("Caller Request Legal", typeof(string));
                    dtexportCrisis.Columns.Add("Caller Request Shelter", typeof(string));
                    dtexportCrisis.Columns.Add("Caller Request Social Work", typeof(string));
                    dtexportCrisis.Columns.Add("Caller Request Other", typeof(string));
                    dtexportCrisis.Columns.Add("Caller Request DVRT", typeof(string));
                    dtexportCrisis.Columns.Add("DVRT Request CPS", typeof(string));
                    dtexportCrisis.Columns.Add("DVRT Kids on Scene", typeof(string));
                    dtexportCrisis.Columns.Add("DVRT Kids in Household", typeof(string));
                    dtexportCrisis.Columns.Add("DVRT Request Follow Up", typeof(string));
                    dtexportCrisis.Columns.Add("DVRT Request Hospital", typeof(string));
                    dtexportCrisis.Columns.Add("DVRT Request Scene", typeof(string));
                    dtexportCrisis.Columns.Add("DVRT Request Other", typeof(string));
                    dtexportCrisis.Columns.Add("DVRT Request Law", typeof(string));
                    dtexportCrisis.Columns.Add("DVRT Law Region", typeof(string));
                    dtexportCrisis.Columns.Add("DVRT Law Personnel", typeof(string));
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xml);
                    XmlNode xmlCall = doc.SelectNodes("/Bulletins/CallLogDetails").Item(0);
                    reportTitle = xmlCall.Attributes["BulletinName"].Value;
                    associate = xmlCall.Attributes["Associate1"].Value;
                    logInDate = xmlCall.Attributes["LoginDate"].Value;
                    logInTime = xmlCall.Attributes["LoginHour"].Value + ":" + xmlCall.Attributes["LoginMin"].Value;
                    logInTimeNoon = xmlCall.Attributes["LoginSection"].Value;
                    logOutDate = xmlCall.Attributes["LogOutDate"].Value;
                    logOutTime = xmlCall.Attributes["LogOutHour"].Value + ":" + xmlCall.Attributes["LogOutMin"].Value;
                    logOutTimeNoon = xmlCall.Attributes["LogOutSection"].Value;
                    transferTo = xmlCall.Attributes["TransferredPhoneTo"].Value;
                    XmlNodeList xnList = doc.SelectNodes("/Bulletins/ChildCallerDetails");
                    foreach (XmlNode xn in xnList)
                    {
                        DataRow dr = dtexportCrisis.NewRow();
                        dr["Report Title"] = reportTitle;
                        dr["Associate"] = associate;
                        dr["Log In Date"] = logInDate;
                        dr["Log In Time"] = logInTime;
                        dr["AM / PM"] = logInTimeNoon;
                        dr["Log Out Date"] = logOutDate;
                        dr["Log Out Time"] = logOutTime;
                        dr["AM / PM "] = logOutTimeNoon;
                        dr["Transfer To"] = transferTo;
                        dr["Call Number"] = xn.Attributes["PhoneNumber"].Value;
                        dr["Call Time"] = xn.Attributes["CallHour"].Value + ":" + xn.Attributes["CallMin"].Value;
                        dr["AM / PM  "] = xn.Attributes["CallSection"].Value;
                        dr["DVRT Kids on Scene"] = xn.Attributes["CPSIsChildrenScene"] != null ? "Yes" : "";
                        dr["DVRT Kids in Household"] = xn.Attributes["CPSIsChildrenHouseHold"] != null ? "Yes" : "";
                        string callertType = xn.Attributes["CallerType"].Value;
                        if (callertType != "")
                        {
                            string[] strCTypes = callertType.Split(':');
                            dr["Caller Type"] = strCTypes[0].ToString();
                            if (strCTypes.Length > 1)
                            {
                                if (strCTypes[0].ToString().Contains("Law"))
                                    dr["Caller Type Law Region Name"] = strCTypes[1].ToString();
                                else
                                    dr["Caller Type Agency Name"] = strCTypes[1].ToString();
                            }
                        }
                        string requestType = xn.Attributes["CallRequest"].Value;
                        if (requestType != "")
                        {
                            string[] reqTypes = requestType.Split(',');
                            foreach (var item in reqTypes)
                            {
                                if (item.ToString().Contains("DVRT"))
                                {
                                    dr["Caller Request DVRT"] = "Yes";
                                    string[] reqDVRT = item.ToString().Replace("DVRT:", "").Split('|');
                                    foreach (var dvrtitem in reqDVRT)
                                    {
                                        if (dvrtitem.ToString() == "CPS")
                                            dr["DVRT Request CPS"] = "Yes";
                                        if (dvrtitem.ToString().ToLower().Contains("follow up"))
                                            dr["DVRT Request Follow Up"] = "Yes";
                                        if (dvrtitem.ToString().ToLower().Contains("hospital"))
                                            dr["DVRT Request Hospital"] = "Yes";
                                        if (dvrtitem.ToString() == "Scene")
                                            dr["DVRT Request Scene"] = "Yes";
                                        if (dvrtitem.ToString().ToLower().Contains("other:"))
                                            dr["DVRT Request Other"] = dvrtitem.ToString().Replace("Other:", "");
                                        if (dvrtitem.ToString().ToLower().Contains("law enforcement"))
                                        {
                                            dr["DVRT Request Law"] = "Yes";
                                            string[] dvrtReqLaw = dvrtitem.ToString().Split(':');
                                            dr["DVRT Law Region"] = dvrtReqLaw[1].ToString();
                                            dr["DVRT Law Personnel"] = dvrtReqLaw[2].ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    if (item.ToString().ToLower().Contains("agency"))
                                        dr["Caller Request Agency"] = "Yes";
                                    if (item.ToString().ToLower().Contains("counseling"))
                                        dr["Caller Request Counceling"] = "Yes";
                                    if (item.ToString().ToLower().Contains("legal"))
                                        dr["Caller Request Legal"] = "Yes";
                                    if (item.ToString().ToLower().Contains("shelter"))
                                        dr["Caller Request Shelter"] = "Yes";
                                    if (item.ToString().ToLower().Contains("social worker"))
                                        dr["Caller Request Social Work"] = "Yes";
                                    if (item.ToString().ToLower().Contains("other"))
                                        dr["Caller Request Other"] = "Yes";
                                }

                            }
                        }
                        dtexportCrisis.Rows.Add(dr);
                    }
                    string attachment = "attachment; filename=" + dtBulletinDetails.Rows[0]["Bulletin_Title"].ToString().Replace(" ", "") + ".xls";
                    System.Web.UI.WebControls.GridView grid = new GridView();
                    grid.AutoGenerateColumns = true;
                    grid.RowStyle.Wrap = true;
                    grid.AlternatingRowStyle.Wrap = true;
                    grid.DataSource = dtexportCrisis;
                    grid.DataBind();
                    grid.HeaderRow.Font.Bold = true;
                    grid.HeaderRow.ForeColor = Color.White;
                    grid.HeaderRow.BackColor = Color.FromName("#657383");
                    try
                    {
                        Response.Clear();
                        Response.AddHeader("content-disposition", attachment);
                        Response.ContentType = "application/vnd.ms-excel";

                        StringWriter stw = new StringWriter();

                        HtmlTextWriter htextw = new HtmlTextWriter(stw);

                        grid.RenderControl(htextw);

                        Response.Write(stw.ToString());

                        Response.End();
                    }
                    catch (Exception /*ex*/)
                    {

                    }
                }
            }
        }
        protected void lblhistroy_Click(object sender, EventArgs e)
        {
            LinkButton lnkHis = sender as LinkButton;
            DtHis = objBulletin.GetBulletinDetailsByBulletinID(Convert.ToInt32(lnkHis.CommandArgument));
            if (DtHis.Rows.Count > 0)
            {
                // *** Issue 1031 *** //
                DataView dtcampview = DtHis.DefaultView;
                dtcampview.Sort = "sent_Flag ASC";
                DtHis = dtcampview.ToTable();
                Session["DtHis"] = DtHis;
                // *** End Issue 1031 ***  //
                grdviewsenthis.DataSource = DtHis;
                grdviewsenthis.DataBind();
                DataTable DtNewMaster = new DataTable();
                DtNewMaster = objBulletin.GetBulletinByID(Convert.ToInt32(lnkHis.CommandArgument));
                if (DtNewMaster.Rows.Count > 0)
                {
                    lblviewsentnewlettername.Text = DtNewMaster.Rows[0]["Bulletin_Title"].ToString();
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
            grdviewsenthis.DataSource = (DataTable)Session["DtHis"];
            grdviewsenthis.DataBind();
            ModalPopupExtender3.Show();
        }
        protected void lnkCancelCamp_Click(object sender, EventArgs e)
        {
            dtCampaign = objBulletin.GetCampaignBulletinDetailsByDates(Convert.ToInt32(hdnCommandArg.Value));
            DataView dtcampview = dtCampaign.DefaultView;
            dtcampview.Sort = "sent_Flag ASC";
            dtCampaign = dtcampview.ToTable();
            Session["dtCampaign"] = dtCampaign;
            lblp.Text = hdnCommandArg.Value;
            if (dtCampaign.Rows.Count > 0)
            {
                grdschemail.DataSource = dtCampaign;
                grdschemail.DataBind();
                ModalPopupExtender1.Show();
            }
        }
        protected void grdschemail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbldate = e.Row.FindControl("Label2") as Label;
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
                Count = objBulletin.GetBulletinCountforDayforUserDateAndBulletinID(UserID, Convert.ToDateTime(lbldate.Text), Convert.ToInt32(lblp.Text));
                lblCount.Text = Count.ToString();
            }
        }
        protected void grdschemail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdschemail.PageIndex = e.NewPageIndex;
            grdschemail.DataSource = (DataTable)Session["dtCampaign"];
            grdschemail.DataBind();
            ModalPopupExtender1.Show();
        }
        protected void btnstopcampain_Click(object sender, EventArgs e)
        {
            objBulletin.CancelBulletinCampaign(Convert.ToInt32(lblp.Text));
            CancelCamp.Visible = false;
            GetBulletins();
            lblmess.Text = "<font color='green'>Your content campaign has been cancelled successfully.</font>";
        }
        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CancelCamp.Visible = false;
        }
        private void ShowPrintFlyer()
        {
            Session["Printnewletters"] = "fdgfj ";
            string URL = Page.ResolveClientUrl("~/Business/MyAccount/Printer.aspx?BLID=" + hdnCommandArg.Value);
            ScriptManager.RegisterClientScriptBlock(this.lnkPrint, this.GetType(), "Print", "window.open('" + URL + "');", true);
        }
        protected void lnkNotification_Click(object sender, EventArgs e)
        {
            Session["PushNotifyType"] = "Bulletin," + hdnCommandArg.Value;

            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SendAppNotifications.aspx?bullitenID=" + hdnCommandArg.Value));
        }
        private void BindBulletinCategories()
        {
            DataTable dtCategories = objCommon.GetBulletinCategoriesByVertical(ProfileID);
            if (dtCategories.Rows.Count > 0)
            {
                ddlCategory.DataSource = dtCategories;
                ddlCategory.DataTextField = "Category_Name";
                ddlCategory.DataValueField = "Category_Name";
                ddlCategory.DataBind();
            }
            ddlCategory.Items.Insert(0, new ListItem("All", "0"));
        }
        protected void lnkCreate_Click(object sender, EventArgs e)
        {
            /** This is for allowing creators only 26/06/2013**/
            string authorPermission = string.Empty;
            string pubPermission = string.Empty;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                for (int i = 0; i < dtpermissions.Rows.Count; i++)
                {
                    if (dtpermissions.Rows[i]["ButtonType"].ToString() == "Bulletins")
                    {
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                            authorPermission = "A";
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                            pubPermission = "P";
                        break;
                    }
                }
                if ((authorPermission == "A") || (authorPermission == "A" && pubPermission == "P"))
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SelectBulletin.aspx"));
                else
                    lblmess.Text = "You do not have permission to create content.";
            }
            else
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SelectBulletin.aspx"));
        }
        protected void lnkReports_Click(object sender, EventArgs e)
        {
            string RedirectUrl = string.Empty;
            if (hdnarchive.Value == "Archive")
                RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/BulletinsReports.aspx?Flag=Archive");
            else
                RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/BulletinsReports.aspx?Flag=Current");
            Response.Redirect(RedirectUrl);
        }
        protected void lnkCalendar_Click(object sender, EventArgs e)
        {
            int bulletinID = Convert.ToInt32(hdnCommandArg.Value);
            string bulletin = EncryptDecrypt.DESEncrypt(bulletinID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
            string url = RootPath + "/OnlineBulletin.aspx?BLID=" + bulletin;
            string bulletinName = Convert.ToString(hdnBulletinTitle.Value);
            Response.Redirect(RootPath + "/Business/MyAccount/EventsCalendar.aspx?Name=" + bulletinName + "&URL=" + url);
        }
        [WebMethod]
        public static string UpdateItemsOrder(string itemOrder)
        {
            string _result = "failed";
            try
            {
                BulletinBLL objBulletin = new BulletinBLL();
                BusinessBLL objBus = new BusinessBLL();

                if (itemOrder.Length > 0)
                {
                    if (HttpContext.Current.Session["UserID"] != null)
                    {
                        int CUserID = Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString());
                        if (HttpContext.Current.Session["C_USER_ID"] != null && HttpContext.Current.Session["C_USER_ID"].ToString() != "")
                            CUserID = Convert.ToInt32(HttpContext.Current.Session["C_USER_ID"]);
                        string[] strBulletinOrder = itemOrder.Split(',');
                        for (int i = 0; i < strBulletinOrder.Length; i++)
                        {
                            objBulletin.UpdateBulletinsOrder(Convert.ToInt32(strBulletinOrder[i]), i + 1, CUserID);
                        }
                        objBus.Insert_SilentPushMessages(Convert.ToInt32(HttpContext.Current.Session["ProfileID"].ToString()), DateTime.Now, false, 0, "Bulletins", "OrderNumberUpdate");
                    }
                }
                _result = "success";
            }
            catch (Exception /*ex*/)
            { }
            return _result;
        }
        protected void lnkShareBtn_Click(object sender, EventArgs e)
        {
            string description = string.Empty;
            string articleTitle = hdnBulletinTitle.Value.ToString();
            description = articleTitle;
            description = objCommon.GetSocialDescription(description);
            string redirecturl = RootPath + "/OnlineBulletin.aspx?Timespan=" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + "&BLID=" + EncryptDecrypt.DESEncrypt(Convert.ToInt32(hdnCommandArg.Value).ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
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
                objCommon.InsertUpdateAutoShareDetails("Bulletin", Convert.ToInt32(hdnCommandArg.Value), 0, DateTime.Now, "Facebook", UserID, C_UserID, articleTitle);
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
                Response.Redirect("https://graph.facebook.com/oauth/authorize?client_id=" + appID + "&redirect_uri=" + RootPath + "/Business/MyAccount/ManageBulletins.aspx" + "&scope=" + fbScope);
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
                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}", appID, RootPath + "/Business/MyAccount/ManageBulletins.aspx", fbScope, Request["code"].ToString(), appSecret);
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
                Session["FBaccess_token"] = access_token;
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
                Response.Redirect(RootPath + "/Business/MyAccount/ManageBulletins.aspx");
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

                /*
                if (accessToken == string.Empty)
                    accessToken = Session["FBaccess_token"].ToString();
                 * */

                var result = smb.GetExtendedAccessToken(accessToken, appID, appSecret);
                var extendedToken = result.access_token;    // Get Long Lived Access Token.
                var fb = new FacebookClient();
                fb.AccessToken = extendedToken;
                var postID = "";
                var args = (Dictionary<string, object>)Session["PageContent"];
                if (args.ContainsKey("message"))
                    args.Remove("message");
                args.Add("message", txtDesc.Text.Trim());

                //postID = fb.Post("/" + "balaji.mada" + "/feed", args).ToString();

                // code for sharing selected image to facebook

                //string fpath = Server.MapPath("~/Upload/") + "//HowToVideosThumbs//AddChangeAppBackgroundImage.png";
           
                //// ————————set the parameters
                //byte[] photo = File.ReadAllBytes(fpath);
               
                //var mediaObject = new FacebookMediaObject
                //{
                //ContentType = "image/png",
                //FileName = "AddChangeAppBackgroundImage.png"
                //};
                //mediaObject.SetValue(photo);
                //args.Add("source", mediaObject);
                //args.Add("picture", mediaObject);
                
                // ————————Post on Facebook
                //fb.Post("/"+selectedPage+"/photos", args);
              

                if (selectedPage != "")
                    postID = fb.Post("/" + selectedPage + "/feed", args).ToString();

                if (postID != "")
                {
                    mpeFbPages.Hide();
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx?fbStatus=1"));
                }
                else
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageBulletins.aspx?fbStatus=0"));
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "Test_ManageBuletins.aspx.cs", "ShareOnPage()", ex.Message,
                       Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkTwrShare_Click(object sender, EventArgs e)
        {
            try
            {
            string description = string.Empty;
            string articleTitle = hdnBulletinTitle.Value.ToString();
            description = articleTitle;
            description = objCommon.GetSocialDescription(description);
            string redirecturl = RootPath + "/OnlineBulletin.aspx?BLID=" + EncryptDecrypt.DESEncrypt(Convert.ToInt32(hdnCommandArg.Value).ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
            redirecturl = objCommon.longurlToshorturl(redirecturl);
            string tweetDesc = description.Replace("#", "");
            Session["ContentID"] = hdnCommandArg.Value;
            if ((description.Length + redirecturl.Length) > 137)
                tweetDesc = description.Substring(0, 140 - (redirecturl.Length + 3)).Replace("#", "");

            DataTable dtTwitterUser = smb.GetTwitterDataByUserID(ProfileID);
            if (dtTwitterUser.Rows.Count > 0)
            {
                objCommon.InsertUpdateAutoShareDetails("Bulletin", Convert.ToInt32(hdnCommandArg.Value), 0, DateTime.Now, "Twitter", UserID, C_UserID, articleTitle);
                lblmess.Text = "<font color='green'>Your selected item has been posted on twitter successfully.</font>";
            }
            else
            {
                string url = "http://www.twitter.com/share?url=" + redirecturl + "&text=" + tweetDesc;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + url + "', '_blank');", true);
                objCommon.InsertUpdateAutoShareDetails("Bulletin", Convert.ToInt32(Session["ContentID"]), 1, DateTime.Now, "Twitter", UserID, C_UserID, articleTitle);// if user manually tweets inserting the record
                objCommon.UpdateSocialShareStatus(UserID, 1, "Twitter", Convert.ToInt32(Session["ContentID"]),1);//updating status flag for report
            }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageBuletins.aspx.cs", "lnkTwrShare_Click()", ex.Message,
                       Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void RBAppOrder_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedOrderType = Convert.ToInt32(RBAppOrder.SelectedValue);

            //objCommon.UpdateDisplayOrderType(ProfileID, Convert.ToInt32(Session["CustomModuleID"]), selectedOrderType, "Bulletins");
            objCommon.UpdateDisplayOrderType(ProfileID, 0, selectedOrderType, "Bulletins");

        }


        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveUserSettings();
            GrdBulletins.PageSize = GetPageSize();
            GrdBulletins.DataSource = (DataTable)Session["DtBulletins"];
            GrdBulletins.DataBind();
        }
        private void SaveUserSettings()
        {
            try
            {
                string XMLdata = "<ManageBulletins MessagePageSize='" + PageSizes.SelectedPage + "'  /> ";
                var dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, "Bulletins");
                if (dtDisplayReadFirst.Rows.Count == 0)
                    objBus.UserCustomizeSettings(0, ProfileID, UserID, "Bulletins", XMLdata);
                else
                    objBus.UserCustomizeSettings(Convert.ToInt32(dtDisplayReadFirst.Rows[0]["CustomizeSettingsID"].ToString()), ProfileID, UserID, "Bulletins", XMLdata);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageBuletins.aspx.cs", "SaveUserSettings()", ex.Message,
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
            string XMLValue = "";
            DataTable dtDisplayReadFirst = new DataTable();
            dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, "Bulletins");
            if (dtDisplayReadFirst.Rows.Count > 0)
            {
                XMLValue = Convert.ToString(dtDisplayReadFirst.Rows[0]["XMLValue"]);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(XMLValue);
                if (XMLValue != "")
                {
                    if (xmldoc.SelectSingleNode("ManageBulletins/@MessagePageSize") != null)
                    {
                        PageSizes.SelectedPage = xmldoc.SelectSingleNode("ManageBulletins/@MessagePageSize").Value;
                    }
                }
            }
        }
    }
}