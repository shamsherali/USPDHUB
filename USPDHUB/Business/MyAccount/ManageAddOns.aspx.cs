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
    public partial class ManageAddOns : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;

        public string ShowButtons = string.Empty;
        public string ShowFilter = string.Empty;

        DataTable DtBulletins = new DataTable();
        DataTable dtCampaign = new DataTable();
        DataTable DtHis = new DataTable();
        DataTable dtAddOn = new DataTable();
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
        AddOnBLL objAddOn = new AddOnBLL();
        BulletinBLL objBulletin = new BulletinBLL();
        BusinessBLL objBus = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        EventCalendarBLL objEvents = new EventCalendarBLL();
        BusinessUpdatesBLL objBusUpdate = new BusinessUpdatesBLL();
        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        string appID = string.Empty;    //Facebook App ID and Secret
        string appSecret = string.Empty;
        string fbScope = ConfigurationManager.AppSettings.Get("FBScopes");//"public_profile,publish_actions,publish_stream,manage_pages";

        public int BulletinUsageCount = 0;
        public int CustomModuleId = 0;

        public bool IsEmail = false;
        public bool IsReport = false;

        public string ButtonType = string.Empty;
        public bool IsScheduleEmails = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            GetFacebookAppDetails();
            if (Session["CustomModuleID"] == null)
            {
                Response.Redirect(RootPath + "/Business/MyAccount/Default.aspx");
            }
            else
                CustomModuleId = Convert.ToInt32(Session["CustomModuleID"].ToString());
            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            C_UserID = UserID;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
            lblmess.Text = "";
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

            if (!IsPostBack)
            {
                if (Request["code"] != null)
                {
                    ShareOnFacebook();
                }
                if (Request.QueryString["fbStatus"] != null)
                {
                    if (Convert.ToInt32(Request.QueryString["fbStatus"]) == 1)
                        lblmess.Text = "<span style='color:green;'>Your content has been posted on facebook successfully.</span>";
                    if (Convert.ToInt32(Request.QueryString["fbStatus"]) == 0)
                        lblmess.Text = "<span style='color:red;'>Facebook server is not responding. Please try again later.</span>";
                }
                if (Session["FormID"] != null)
                    Session.Remove("FormID");
                dtAddOn = objAddOn.GetAddOnById(CustomModuleId);
                ltrlTitleImage.Text = "<img style='width:auto;height:auto;vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtAddOn.Rows[0]["AppIcon"].ToString() + ".png'/>";
                if (dtAddOn.Rows.Count == 1)
                {
                    hdnAddOnName.Value = dtAddOn.Rows[0]["TabName"].ToString();
                    if (dtAddOn.Rows[0]["ButtonType"].ToString() == WebConstants.Tab_PrivateContentAddOns)
                    {
                        hdnIsPrivateModule.Value = "1";
                        Session["IsPrivate"] = "1";
                        ButtonType = WebConstants.Store_PrivateContentAddOns;
                    }
                    else
                    {
                        Session["IsPrivate"] = null;
                        ButtonType = WebConstants.Store_ContentAddOns;
                    }
                }
                /*
                DataTable dtAppSettings = new DataTable("dtapp");
                DataSet dtAddOns = objAddOn.GetManageAddOns(UserID, null);
                if (dtAddOns.Tables.Count > 0 && dtAddOns.Tables[0].Rows.Count > 0)
                {
                    DataRelation relation;
                    DataColumn table1Column;
                    DataColumn table2Column;
                    //retrieve column 
                    table1Column = dtAddOns.Tables[0].Columns["UserModuleID"];
                    table2Column = dtAddOns.Tables[1].Columns["UserModuleID"];
                    //relating tables 
                    relation = new DataRelation("relation", table1Column, table2Column);
                    //assign relation to dataset 
                    dtAddOns.Relations.Add(relation);

                    dtAppSettings = dtAddOns.Tables[0];
                }

                var rows = dtAppSettings.Select("TabName='" + hdnAddOnName.Value + "' AND IsVisible='True' ");
                lblOff.Visible = true;
                if (rows.Length > 0)
                {
                    lblOn.Visible = true;
                    lblOff.Visible = false;
                }
                */
                lblOff.Visible = true;
                if (objCommon.DisplayOn_OffSettingsContent(UserID, ButtonType, CustomModuleId))
                {
                    lblOn.Visible = true;
                    lblOff.Visible = false;
                }

                RBAppOrder.SelectedValue = objCommon.DisplayOrderType(UserID, hdnAddOnName.Value, Convert.ToInt32(Session["CustomModuleID"].ToString()));

                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), CustomModuleId, "ContentModule");
                    if (string.IsNullOrEmpty(hdnPermissionType.Value))
                    {
                        UpdatePanel2.Visible = true;
                        UpdatePanel1.Visible = false;
                        lblerrormessage.Text = "<font face=arial size=2>You do not have permission to manage addons.</font>";
                    }
                }
                //ends here

                //  Hdn control for Sorting
                hdnsortdire.Value = "";
                hdnsortcount.Value = "0";
                BindAddOnCategories();
                GetAllManageAddOns();
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
                                lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessEvent.Replace("event", "content") + "</font>";
                            }
                            Session["CheckBulletinMess"] = null;
                        }
                        else
                        {
                            lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessEvent.Replace("event", "content") + "</font>";
                        }

                    }
                }
                Session["BulletinSend"] = null;
            }
            ddlPageSize = (DropDownList)PageSizes.FindControl("ddlPageSize");
            ddlPageSize.AutoPostBack = true;
            ddlPageSize.SelectedIndexChanged += ddlPageSize_SelectedIndexChanged;
        }
        private void ShowCurrentArchive()
        {
            lnkArchive.Visible = false;
            lnkChangeCurrent.Visible = false;
            if (hdnarchive.Value != "Archive")
                lnkArchive.Visible = true;
            else
                lnkChangeCurrent.Visible = true;
        }
        private void BindAddOnCategories()
        {
            DataTable dtCategories = objCommon.GetBulletinCategoriesByVertical(ProfileID, true);
            if (dtCategories.Rows.Count > 0)
            {
                ddlCategory.DataSource = dtCategories;
                ddlCategory.DataTextField = "Category_Name";
                ddlCategory.DataValueField = "Category_Name";
                ddlCategory.DataBind();
            }
            ddlCategory.Items.Insert(0, new ListItem("All", "0"));
        }
        private void GetAllManageAddOns()
        {
            trPublish.Visible = false;
            trUnPublish.Visible = false;
            trShareOn1.Visible = true;
            hdnCommandArg.Value = "";
            string BulletinFilter = drpfilter.SelectedItem.Value;
            string BulletinCategory = ddlCategory.SelectedValue;
            DtBulletins = objAddOn.GetAllManageAddOns(Convert.ToInt32(BulletinFilter), BulletinCategory, UserID, CustomModuleId);
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
                    DataTable dtScheduleEmails = objBusUpdate.CheckBusinessUpdateCampaignCountByID(Convert.ToInt32(DtBulletins.Rows[i]["Custom_ID"].ToString()), "CustomModule");
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
            Session["DtBulletins"] = DtBulletins;
            hdnShowButtons.Value = "1";
            showCurrArchives(true);
            if (TotalBulletins == 0)
                showCurrArchives(false);
            if (DtBulletins.Rows.Count == 0 && BulletinFilter == "0")
                hdnShowButtons.Value = "";
            else if (DtBulletins.Rows.Count == 0 && BulletinFilter != "0")
                ShowFilter = "1";
            GetSavedUserData();
            GrdBulletins.PageSize = GetPageSize();
            GrdBulletins.DataSource = DtBulletins;
            GrdBulletins.DataBind();
        }
        private void showCurrArchives(bool Flag)
        {
            lnkGetArchive.Visible = Flag;
            lnkCurrent.Visible = Flag;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowButtons = "1";
            Session["DtBulletins"] = null;
            GrdBulletins.PageIndex = 0;
            GetAllManageAddOns();
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
            lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>";
            lnkCurrent.Text = "<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>";
            hdnCommandArg.Value = "";
            hdnRowIndex.Value = "";
            hdnarchive.Value = "NoArchive";
            Session["ViewBGrid"] = null;
            GetAllManageAddOns();
        }
        protected void lnkGetArchive_Click(object sender, EventArgs e)
        {
            CancelCamp.Visible = false;
            lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive.gif' title='Archive' border='0'/>";
            lnkCurrent.Text = "<img src='../../Images/Dashboard/current.gif' title='Current' border='0'/>";
            hdnCommandArg.Value = "";
            hdnRowIndex.Value = "";
            hdnarchive.Value = "Archive";
            Session["ViewBGrid"] = "Archive";
            GetAllManageAddOns();
        }
        protected void GrdBulletins_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = e.Row.Cells.Count;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkcam = e.Row.FindControl("lnkruncampaion") as LinkButton;
                Label lblcam = e.Row.FindControl("lblcam") as Label;
                Label lblApprovalStatus = e.Row.FindControl("lblApprovalStatus") as Label;
                LinkButton lb = e.Row.FindControl("lnkTitle") as LinkButton;
                Label lblbulletinthumb = e.Row.FindControl("lblbulletinthumb") as Label;
                string customID = lb.CommandArgument;
                string ImageDisID = Guid.NewGuid().ToString();
                if (File.Exists(Server.MapPath("~") + "\\Upload\\CustomModules\\" + ProfileID.ToString() + "\\" + customID + ".jpg"))
                    lblbulletinthumb.Text = "<img src='" + RootPath + "/Upload/CustomModules/" + ProfileID.ToString() + "/" + customID + ".jpg?Guid=" + ImageDisID + "' border='1' width='100' height='50'/>";
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
        }
        protected void GrdBulletins_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            trUnPublish.Visible = false;
            trPublish.Visible = false;
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
        protected void chkCurrentTabCustomID_CheckedChanged(object sender, EventArgs e)
        {
            hdnIsPusblished.Value = "";
            trUnPublish.Visible = true;
            trPublish.Visible = true;
            CheckBox rb = (CheckBox)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            LinkButton lnkTitle = (LinkButton)row.FindControl("lnkTitle");
            LinkButton lnkcamp = (LinkButton)row.FindControl("lnkruncampaion");
            Label lblStatus = (Label)row.FindControl("lblStatus");
            trShareOn1.Visible = true;
            trShareOn2.Visible = true;

            hdnCommandArg.Value = lnkTitle.CommandArgument;
            hdnRowIndex.Value = row.RowIndex.ToString();

            // Selected Checkbox details for Preview, Edit, Copy, Send Mail
            foreach (GridViewRow row1 in GrdBulletins.Rows)
            {
                if (((CheckBox)row1.FindControl("chkCurrentTabCustomID")).Checked)
                {
                    hdnCommandArg.Value = (((LinkButton)row1.FindControl("lnkTitle")).CommandArgument);
                    lnkTitle = (LinkButton)row1.FindControl("lnkTitle");
                    hdnRowIndex.Value = row1.RowIndex.ToString();
                    lblStatus = (Label)row1.FindControl("lblStatus");
                    break;
                }
            }


            hdnBulletinTitle.Value = lnkTitle.Text;
            GetSharestrings(Convert.ToInt32(hdnCommandArg.Value), lnkTitle.Text);
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

            var expiryDate = Convert.ToString(GrdBulletins.DataKeys[Convert.ToInt32(hdnRowIndex.Value)].Values["Expiration_Date"].ToString());
            if (expiryDate != string.Empty)
            {
                if (Convert.ToDateTime(expiryDate) < DateTime.Now)
                {
                    trUnPublish.Visible = false;
                    trPublish.Visible = false;
                    lblerrormessage.Text = "Expired content is not allowed to publish.";
                }
            }
        }
        protected void lnkCreate_Click(object sender, EventArgs e)
        {
            string ModuleName = string.Empty;
            string authorPermission = string.Empty;
            string pubPermission = string.Empty;
            DataTable dtAddOn = objAddOn.GetAddOnById(CustomModuleId);
            if (dtAddOn.Rows.Count == 1)
                ModuleName = dtAddOn.Rows[0]["TabName"].ToString();
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                if (dtpermissions.Rows.Count > 0)
                {
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
                }
                if ((authorPermission == "A") || (authorPermission == "A" && pubPermission == "P"))
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SelectItem.aspx"));
                else
                    lblmess.Text = "You do not have permission to create content.";
            }
            else
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SelectItem.aspx"));

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
        private void GetSharestrings(int customID, string Bulletin_Title)
        {
            GetAutoShareRecordStatus(customID, Bulletin_Title);
            articleTitle = Bulletin_Title.ToString();
            articleSummary = "What's on your mind?";
            //DataTable dtBulletin = new DataTable();
            //dtBulletin = objAddOn.GetCustomModuleByID(customID);
            //string description = Convert.ToString(dtBulletin.Rows[0]["Bulletin_HTML"]);
            //if (dtBulletin.Rows[0]["Form_Type"].ToString() == "Form")
            string description = Bulletin_Title;
            description = objCommon.GetSocialDescription(description);
            description = objCommon.ReplaceShortURltoHtmlString(description);
            string redirecturl = RootPath + "/OnlineItem.aspx?CMID=" + EncryptDecrypt.DESEncrypt(customID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
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
            //lblFacebookSharePage.Text = "<a href='javascript:post_on_page()'><img src='../../images/Dashboard/facebooknew.gif' alt='Share on Facebook Page' width='55' height='36' title='Share on Facebook Page' border='0' /></a>";
            //Facebook

            //Pinterest
            string PinterestUrl = "http://pinterest.com/pin/create/button/?url=" + RootPath + "/OnlineItem.aspx?CMID=" + EncryptDecrypt.DESEncrypt(customID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&media=" + RootPath + "/Images/VerticalLogos/" + DomainName + "logo.png&description=" + tweetDesc;
            string PinterestUrlshare = "<a count-layout='horizontal' href='" + PinterestUrl + "'  target='_blank'><img border='0' src='../../images/Dashboard/PinterestLogo.gif' title='Pin It' alt='Share on Pinterest' width='55' height='36' /></a>";
            lblPinShare.Text = PinterestUrlshare;
            //Pinterest

            //***************** Commented by Suneel(Updates sharing via Linkedin)******************//
            //LinkedIN
            string update = EncryptDecrypt.DESEncrypt(customID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
            string articleUrl = RootPath + "/OnlineItem.aspx?CMID=" + update;
            string articleSource = RootPath + "/OnlineItem.aspx?CMID=" + update;
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
            string ur = RootPath + "/OnlineItem.aspx?CMID=" + update;
            string url = RootPath + "/Business/Myaccount/ShareEmail.aspx?CM=" + update;
            Mailtourlinfo = "<a href=\"javascript:openEmailwindow('" + url + "')\"><img src='../../images/Dashboard/emailnew.gif' title='Share on Email' width='30' height='38' alt='Share on Email'/></a>";
            lblEmailShare.Text = Mailtourlinfo;
            //Mail TO Url
        }
        private void GetAutoShareRecordStatus(int customID, string customTitle)
        {
            DataTable dtShareRecords = objCommon.CheckAutoShareRecordExists("ContentModule", customID, customTitle);
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
        private void ShowPreview(int customID)
        {
            dtBulletinCheck = objAddOn.GetCustomModuleByID(customID);
            if (dtBulletinCheck.Rows.Count > 0)
            {
                string preview = string.Empty;
                preview = objCommon.GetHeaderForBulletins(UserID, ProfileID, false);
                lblbulletinamme.Text = dtBulletinCheck.Rows[0]["Bulletin_Title"].ToString();
                string htmlString = preview.Replace("#BuildHtmlForForm#", dtBulletinCheck.Rows[0]["Bulletin_HTML"].ToString().Replace("padding-top: 100px; padding-left: 50px;", "padding-top: 100px; padding-left: 150px;"));

                lblPreviewHTML.Text = htmlString;//objCommon.ReplaceShortURltoHtmlString(htmlString);
                MPEPreview.Show();


                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>LoadEventForPlayVideo()</script>", false);
            }
        }
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            /** This is for allowing creators only 26/06/2013**/
            string ModuleName = string.Empty;
            string authorPermission = string.Empty;
            string pubPermission = string.Empty;
            DataTable dtAddOn = objAddOn.GetAddOnById(CustomModuleId);
            if (dtAddOn.Rows.Count == 1)
                ModuleName = dtAddOn.Rows[0]["TabName"].ToString();
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                if (dtpermissions.Rows.Count > 0)
                {
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
                }
            }
            if ((hdnCommandArg.Value != "" && ((authorPermission == "A") || (authorPermission == "A" && pubPermission == "P"))) || (Convert.ToString(Session["C_USER_ID"]) == "" || Session["C_USER_ID"] == null))
            {
                dtAddOn = objAddOn.GetActiveForms(CustomModuleId, Convert.ToInt32(hdnCommandArg.Value));
                if (dtAddOn.Rows.Count > 0)
                {
                    string navigationUrl = Convert.ToString(dtAddOn.Rows[0]["NavigationUrl"]);
                    if (navigationUrl != "")
                    {
                        string RedirectUrl = string.Empty;
                        Session["FormID"] = Convert.ToString(dtAddOn.Rows[0]["ModuleID"]);
                        Session["BulletinID"] = hdnCommandArg.Value;

                        bool IsUserForms = false;
                        string userFormsUrl = "";
                        if (String.Equals(Convert.ToString(dtAddOn.Rows[0]["IsUserForms"]), "true", StringComparison.OrdinalIgnoreCase))
                        {
                            IsUserForms = true;
                        }

                        if (IsUserForms)
                        {
                            if (RootPath.ToLower().Contains("localhost"))
                            {
                                //For Local RootPath
                                userFormsUrl = ConfigurationManager.AppSettings.Get("UserFormsRootPath") + "?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString())
                                  + "&UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString())
                                   + "&TempID=" + EncryptDecrypt.DESEncrypt(Session["FormID"].ToString()) + "&BID=" + EncryptDecrypt.DESEncrypt(Session["BulletinID"].ToString())
                                   + "&CMID=" + EncryptDecrypt.DESEncrypt(Session["CustomModuleID"].ToString()) + (Session["C_USER_ID"] != null ? ("&CUID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(Session["C_USER_ID"]))) : "");
                            }
                            else
                            {
                                //For Test RootPath 
                                userFormsUrl = RootPath + "/UserForms/Default.aspx" + "?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString())
                                  + "&UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString())
                                   + "&TempID=" + EncryptDecrypt.DESEncrypt(Session["FormID"].ToString()) + "&BID=" + EncryptDecrypt.DESEncrypt(Session["BulletinID"].ToString())
                                   + "&CMID=" + EncryptDecrypt.DESEncrypt(Session["CustomModuleID"].ToString()) + (Session["C_USER_ID"] != null ? ("&CUID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(Session["C_USER_ID"]))) : "");
                            }
                            RedirectUrl = Page.ResolveClientUrl(userFormsUrl);
                        }
                        else
                        {

                            RedirectUrl = Page.ResolveClientUrl("~" + navigationUrl);

                        }

                        Response.Redirect(RedirectUrl);
                    }

                }
                else
                    lblmess.Text = "<font color='red'>Your selection has been deactivated to edit.</font>";
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
                if (File.Exists(Server.MapPath("~") + "\\Upload\\CustomModules\\" + ProfileID.ToString() + "\\" + hdnCommandArg.Value + ".jpg"))
                    lblBulletinImage.Text = "<img src='" + RootPath + "/Upload/CustomModules/" + ProfileID.ToString() + "/" + hdnCommandArg.Value + ".jpg' border='1' width='350' height='350'/>";
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
            lblRenameImage.Text = "";
            if (hdnCommandArg.Value != "")
            {
                DataTable dtAddOn = objAddOn.GetCustomModuleByID(Convert.ToInt32(hdnCommandArg.Value));
                if (dtAddOn.Rows.Count > 0)
                {
                    lblExisting.Text = Convert.ToString(dtAddOn.Rows[0]["Bulletin_Title"]);
                }
                if (File.Exists(Server.MapPath("~") + "\\Upload\\CustomModules\\" + ProfileID.ToString() + "\\" + hdnCommandArg.Value + ".jpg"))
                    lblRenameImage.Text = "<img src='" + RootPath + "/Upload/CustomModules/" + ProfileID.ToString() + "/" + hdnCommandArg.Value + ".jpg' border='1' width='350' height='350'/>";
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
                //Identify CheckBox is checked or not
                foreach (GridViewRow row in GrdBulletins.Rows)
                {
                    if (((CheckBox)row.FindControl("chkCurrentTabCustomID")).Checked)
                    {
                        hdnCommandArg.Value = ((LinkButton)(row.FindControl("lnkTitle"))).CommandArgument;
                        string bulletinTitle = ((LinkButton)(row.FindControl("lnkTitle"))).Text;
                        // Save User Activity Log
                        objCommon.InsertUserActivityLog("has deleted a custom module named <b>" + bulletinTitle + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);
                        objAddOn.DeleteCustomModule(Convert.ToInt32(hdnCommandArg.Value));
                    }
                }


                hdnCommandArg.Value = "";
                GetAllManageAddOns();
                lblmess.Text = "<font size='3'>Your selection has been deleted successfully.</font>";
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
                        objCommon.InsertUserActivityLog("has deleted a custom module named <b>" + bulletinTitle + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);
                        #endregion
                        objAddOn.DeleteCustomModule(BulletinID);
                    }
                }
                CancelCamp.Visible = false;
                lblmess.Text = "<font size='3'>Your selection(s) have been deleted successfully.</font>";
                GrdBulletins.PageIndex = 0;
                GetAllManageAddOns();
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
            if (lnkText.Contains("Current"))
            {
                controlID = "chkBulletin";
                ArchiveFlag = false;
            }
            else
            {
                controlID = "chkCurrentTabCustomID";
                ArchiveFlag = true;
            }
            //Identify CheckBox is checked or not
            foreach (GridViewRow row in GrdBulletins.Rows)
            {
                if (((CheckBox)row.FindControl(controlID)).Checked)
                {
                    ArchiveID = Convert.ToInt32(((LinkButton)(GrdBulletins.Rows[row.RowIndex].FindControl("lnkTitle"))).CommandArgument);
                    objCommon.ArchiveSelectedNewsletter(ArchiveID, ArchiveFlag, "CustomeModule", C_UserID);
                }
            }

            if (ArchiveFlag == false)
            {
                lblmess.Text = Resources.LabelMessages.ArchiveCurrentSuccess.Replace("#type#", hdnAddOnName.Value);
            }
            else
            {
                lblmess.Text = Resources.LabelMessages.ArchiveSuccess.Replace("#type#", hdnAddOnName.Value);

            }
            GetAllManageAddOns();
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
                    string RedirectUrl = string.Empty;

                    int CopiedID = objAddOn.CopyItem(Convert.ToInt32(hdnCommandArg.Value), txtBulletinName.Text.Trim(), UserID, ProfileID, C_UserID);
                    dtAddOn = objAddOn.GetActiveForms(CustomModuleId, Convert.ToInt32(hdnCommandArg.Value));
                    if (CopiedID > 0 && dtAddOn.Rows.Count > 0)
                    {
                        Session["FormID"] = dtAddOn.Rows[0]["ModuleID"].ToString();
                        Session["BulletinID"] = CopiedID;

                        bool IsUserForms = false;
                        string userFormsUrl = "";

                        if (String.Equals(Convert.ToString(dtAddOn.Rows[0]["IsUserForms"]), "true", StringComparison.OrdinalIgnoreCase))
                        {
                            IsUserForms = true;
                        }

                        if (IsUserForms)
                        {
                            if (RootPath.ToLower().Contains("localhost"))
                            {
                                //For Local RootPath
                                userFormsUrl = ConfigurationManager.AppSettings.Get("UserFormsRootPath") + "?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString())
                                  + "&UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&CUID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(Session["C_USER_ID"]))
                                   + "&TempID=" + EncryptDecrypt.DESEncrypt(Session["FormID"].ToString()) + "&BID=" + EncryptDecrypt.DESEncrypt(CopiedID.ToString())
                                   + "&CMID=" + EncryptDecrypt.DESEncrypt(Session["CustomModuleID"].ToString());
                            }
                            else
                            {
                                //For Test RootPath 
                                userFormsUrl = RootPath + "/UserForms/Default.aspx" + "?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString())
                                  + "&UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&CUID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(Session["C_USER_ID"]))
                                   + "&TempID=" + EncryptDecrypt.DESEncrypt(Session["FormID"].ToString()) + "&BID=" + EncryptDecrypt.DESEncrypt(CopiedID.ToString())
                                   + "&CMID=" + EncryptDecrypt.DESEncrypt(Session["CustomModuleID"].ToString());
                            }

                            RedirectUrl = Page.ResolveClientUrl(userFormsUrl);
                        }
                        else
                        {
                            RedirectUrl = Page.ResolveClientUrl("~" + dtAddOn.Rows[0]["NavigationUrl"].ToString());
                        }

                        // Save User Activity Log
                        objCommon.InsertUserActivityLog("has created a content titled <b>" + txtBulletinName.Text + "</b> by copying <b>" + hdnBulletinTitle.Value + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);
                        Response.Redirect(RedirectUrl);
                    }
                    else
                    {
                        lbleditext.Text = "Sorry, an error has been occurred while copying. Please try again.";
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
                        int outputID = objBulletin.RenameContent(Convert.ToInt32(hdnCommandArg.Value), txtNewName.Text.Trim(), C_UserID, "AddOn", ProfileID);
                        if (outputID > 0)
                        { // *** Silent PushNotification  *** //
                            objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, Convert.ToInt32(hdnCommandArg.Value), "ContentModule", "Rename");
                            lblmess.Text = "<font color='Green' size='3'>" + Resources.LabelMessages.RenameSuccess.Replace("#ExistingContentName#", lblExisting.Text.Trim()).Replace("#NewContentName#", txtNewName.Text.Trim()) + "</font>";
                            GetAllManageAddOns();
                            modalRename.Hide();
                        }
                        else
                        {
                            lbleditext.Text = "Sorry, you already have a content with this name; please enter another name.";
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
            string ModuleName = string.Empty;
            string authorPermission = string.Empty;
            string pubPermission = string.Empty;
            DataTable dtAddOn = objAddOn.GetAddOnById(CustomModuleId);
            if (dtAddOn.Rows.Count == 1)
                ModuleName = dtAddOn.Rows[0]["TabName"].ToString();
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                if (dtpermissions.Rows.Count > 0)
                {
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
                }
                if ((pubPermission == "P") || (authorPermission == "A" && pubPermission == "P") && hdnCommandArg.Value != "")
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
                            if (((CheckBox)row.FindControl("chkCurrentTabCustomID")).Checked)
                            {
                                hdnCommandArg.Value = ((LinkButton)(row.FindControl("lnkTitle"))).CommandArgument;
                                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "" && hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //roles & permissions...
                                {
                                    UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), false);
                                    string returnvalue = string.Empty;
                                    returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.CustomModule, UserID, Session["username"].ToString(), PageNames.CustomModule, DomainName);
                                }
                                else
                                    UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), true);
                            }
                        }// Foreach
                        hdnCommandArg.Value = "";

                        lblmess.Text = Resources.LabelMessages.PublishStatusChange.Replace("#Type#", hdnAddOnName.Value).Replace("#Status#", "published");
                        GetAllManageAddOns();
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
                        if (((CheckBox)row.FindControl("chkCurrentTabCustomID")).Checked)
                        {
                            hdnCommandArg.Value = ((LinkButton)(row.FindControl("lnkTitle"))).CommandArgument;
                            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "" && hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //roles & permissions...
                            {
                                UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), false);
                                string returnvalue = string.Empty;
                                returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.CustomModule, UserID, Session["username"].ToString(), PageNames.CustomModule, DomainName);
                            }
                            else
                                UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), true);
                        }
                    }// Foreach
                    hdnCommandArg.Value = "";

                    lblmess.Text = Resources.LabelMessages.PublishStatusChange.Replace("#Type#", hdnAddOnName.Value).Replace("#Status#", "published");
                    GetAllManageAddOns();
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
                    if (((CheckBox)row.FindControl("chkCurrentTabCustomID")).Checked)
                    {
                        hdnCommandArg.Value = ((LinkButton)(row.FindControl("lnkTitle"))).CommandArgument;
                        if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "" && hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //roles & permissions...
                        {
                            UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), false);
                            string returnvalue = string.Empty;
                            returnvalue = objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.CustomModule, UserID, Session["username"].ToString(), PageNames.CustomModule, DomainName);
                        }
                        else
                            UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), true);
                    }
                }// Foreach
                hdnCommandArg.Value = "";

                lblmess.Text = Resources.LabelMessages.PublishStatusChange.Replace("#Type#", hdnAddOnName.Value).Replace("#Status#", "published");
                GetAllManageAddOns();
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
                if (((CheckBox)row.FindControl("chkCurrentTabCustomID")).Checked)
                {
                    hdnCommandArg.Value = ((LinkButton)(row.FindControl("lnkTitle"))).CommandArgument;
                    UpdatePublish(false, Convert.ToInt32(hdnCommandArg.Value), PublishDate, false);
                }
            }
            hdnCommandArg.Value = "";

            lblmess.Text = Resources.LabelMessages.PublishChange.Replace("#Type#", hdnAddOnName.Value).Replace("#Status#", "private");
            GetAllManageAddOns();

        }
        private void UpdatePublish(bool flag, int bulletinID, DateTime? publishDate, bool isPublished)
        {
            objAddOn.UpdateCustomModulePublish(flag, UserID, C_UserID, bulletinID, publishDate, isPublished);
        }
        protected void lnkTitle_Click(object sender, EventArgs e)
        {
            LinkButton lnkTitle = sender as LinkButton;
            ShowPreview(Convert.ToInt32(lnkTitle.CommandArgument));
        }
        protected void lnkSend_Click(object sender, EventArgs e)
        {
            int CheckSch = 0;
            CheckSch = objAddOn.CheckforItemSchedule(UserID, CustomModuleId);

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
                int customID = 0;
                DataTable DtGetBulletin = new DataTable();
                customID = Convert.ToInt32(hdnCommandArg.Value);
                DtGetBulletin = objAddOn.GetCustomModuleByID(customID);

                Session["BulletinID"] = customID.ToString();
                Session["BulletinDes"] = DtGetBulletin.Rows[0]["Bulletin_HTML"].ToString();
                if (hdnarchive.Value == "Archive")
                    Session["ViewGrid"] = hdnarchive.Value;
                string url = Page.ResolveClientUrl("~/Business/MyAccount/SendItems.aspx");
                Response.Redirect(url);
            }
            else
            {
                if (CheckCam > 0)
                {
                    string MaxSchDate = string.Empty;
                    MaxSchDate = objAddOn.GetItemMaxScheduleingDate(UserID, CustomModuleId);
                    MaxSchDate = MaxSchDate.Replace("12:00:00 AM", "");
                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.AlreadyHaveBulletinCampaign + " " + MaxSchDate + ".</font>";
                }
                else
                {
                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendaffiliatecountExceeded + "</font>";
                }
            }
        }
        protected void btnUpdateImgOrderNumber_Click(object sender, EventArgs e)
        {
            try
            {
                if (OrderListView.Items.Count > 0)
                {
                    for (int i = 0; i < OrderListView.Items.Count; i++)
                    {
                        Label lblKey = OrderListView.Items[i].FindControl("lblKey") as Label;
                        objAddOn.UpdateOrder(Convert.ToInt32(lblKey.Text), i + 1, C_UserID);
                    }
                    lblmess.Text = "<font color=green face=arial size=2><b>The order of your contents has been updated successfully.</b></font>";
                    objBus.Insert_SilentPushMessages(Convert.ToInt32(HttpContext.Current.Session["ProfileID"].ToString()), DateTime.Now, false, 0, "ContentModule", "OrderNumberUpdate");
                    GetAllManageAddOns();
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
                dtobj = objAddOn.GetPublishedItemsByID(UserID, CustomModuleId);
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
                if (File.Exists(Server.MapPath("~") + "\\Upload\\CustomModules\\" + ProfileID.ToString() + "\\" + lblKey.Text + ".jpg"))
                    lblOrderThumb.Text = "<img src='" + RootPath + "/Upload/CustomModules/" + ProfileID.ToString() + "/" + lblKey.Text + ".jpg?Guid=" + ImageDisID + "' border='1' width='50' height='20'/>";
                else
                    lblOrderThumb.Text = "";
            }
        }
        protected void lnkPrint_Click(object sender, EventArgs e)
        {
            int customID = Convert.ToInt32(hdnCommandArg.Value);
            var dtBulletinDetails = objAddOn.GetCustomModuleByID(customID);

            string PrintHTML = "";
            if (string.IsNullOrEmpty(dtBulletinDetails.Rows[0]["Printer_Html"].ToString()))
                PrintHTML = Convert.ToString(dtBulletinDetails.Rows[0]["Bulletin_HTML"]);
            else
                PrintHTML = Convert.ToString(dtBulletinDetails.Rows[0]["Printer_Html"]);

            string preview = string.Empty;
            preview = objCommon.GetHeaderForBulletins(UserID, ProfileID, false);
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
        protected void lblhistroy_Click(object sender, EventArgs e)
        {
            LinkButton lnkHis = sender as LinkButton;
            DtHis = objAddOn.GetScheduledDetailsByCustomID(Convert.ToInt32(lnkHis.CommandArgument));
            if (DtHis.Rows.Count > 0)
            {
                DataView dtcampview = DtHis.DefaultView;
                dtcampview.Sort = "sent_Flag ASC";
                DtHis = dtcampview.ToTable();
                Session["DtHis"] = DtHis;
                // *** End Issue 1031 ***  //
                grdviewsenthis.DataSource = DtHis;
                grdviewsenthis.DataBind();
                DataTable DtNewMaster = new DataTable();
                DtNewMaster = objAddOn.GetCustomModuleByID(Convert.ToInt32(lnkHis.CommandArgument));
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
            dtCampaign = objAddOn.GetCampaignItemDetailsByDates(Convert.ToInt32(hdnCommandArg.Value));
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
                Count = objAddOn.GetItemCountforDayforUserDateAndCustomID(UserID, Convert.ToDateTime(lbldate.Text), Convert.ToInt32(lblp.Text));
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
            objAddOn.CancelItemCampaign(Convert.ToInt32(lblp.Text));
            CancelCamp.Visible = false;
            GetAllManageAddOns();
            lblmess.Text = "<font color='green'>Your content campaign has been cancelled successfully.</font>";
        }
        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CancelCamp.Visible = false;
        }
        private void ShowPrintFlyer()
        {
            Session["Printnewletters"] = "fdgfj ";
            string URL = Page.ResolveClientUrl("~/Business/MyAccount/Printer.aspx?CMID=" + hdnCommandArg.Value);
            ScriptManager.RegisterClientScriptBlock(this.lnkPrint, this.GetType(), "Print", "window.open('" + URL + "');", true);
        }
        protected void lnkNotification_Click(object sender, EventArgs e)
        {
            Session["PushNotifyType"] = "CustomModule," + hdnCommandArg.Value;
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SendAppNotifications.aspx?CustomID=" + hdnCommandArg.Value));
        }
        protected void lnkReports_Click(object sender, EventArgs e)
        {
            string RedirectUrl = string.Empty;
            if (hdnarchive.Value == "Archive")
                RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/AddOnsReports.aspx?Flag=Archive");
            else
                RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/AddOnsReports.aspx?Flag=Current");
            Response.Redirect(RedirectUrl);
        }
        protected void lnkPrvInvitations_Click(object sender, EventArgs e)
        {
            bool isRedirect = true;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                string InvitesAccess = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "PrivateInvitation");
                if (InvitesAccess == "A")
                    isRedirect = false;
            }
            if (isRedirect)
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SetupInvitation.aspx?Manage=1"));
            else
                lblmess.Text = "<font face=arial size=2 color=red>" + Resources.ProfileAccessMessages.PrivateInvotationNoAccess + "</font>";
        }
        [WebMethod]
        public static string UpdateItemsOrder(string itemOrder)
        {
            string _result = "failed";
            try
            {
                AddOnBLL objAddOn = new AddOnBLL();
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
                            objAddOn.UpdateOrder(Convert.ToInt32(strBulletinOrder[i]), i + 1, CUserID);
                        }
                        objBus.Insert_SilentPushMessages(Convert.ToInt32(HttpContext.Current.Session["ProfileID"].ToString()), DateTime.Now, false, 0, "ContentModule", "OrderNumberUpdate");
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
            string articleTitle = hdnBulletinTitle.Value.ToString();
            //DataTable dtBulletin = new DataTable();
            //dtBulletin = objAddOn.GetCustomModuleByID(Convert.ToInt32(hdnCommandArg.Value));
            //string description = Convert.ToString(dtBulletin.Rows[0]["Bulletin_HTML"]);
            //if (dtBulletin.Rows[0]["Form_Type"].ToString() == "Form")
            string description = hdnBulletinTitle.Value;
            description = objCommon.GetSocialDescription(description);
            string redirecturl = RootPath + "/OnlineItem.aspx?Timespan=" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + "&CMID=" + EncryptDecrypt.DESEncrypt(Convert.ToInt32(hdnCommandArg.Value).ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
            redirecturl = objCommon.longurlToshorturl(redirecturl);
            //Facebook
            string tweetDesc = description.Replace("#", "");
            if ((description.Length + redirecturl.Length) > 137)
            {
                tweetDesc = description.Substring(0, 140 - (redirecturl.Length + 3)).Replace("#", "");
            }

            DataTable dtExistingFbUsersData = smb.GetExistingUserData(ProfileID);
            if (dtExistingFbUsersData.Rows.Count > 0)
            {
                //smb.FacebookAutoShare(ProfileID, tweetDesc, articleTitle, redirecturl);
                objCommon.InsertUpdateAutoShareDetails("ContentModule", Convert.ToInt32(hdnCommandArg.Value), 0, DateTime.Now, "Facebook", UserID, C_UserID, articleTitle);
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
                Response.Redirect("https://graph.facebook.com/oauth/authorize?client_id=" + appID + "&redirect_uri=" + RootPath + "/Business/MyAccount/ManageAddOns.aspx" + "&scope=" + fbScope);
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
                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}", appID, RootPath + "/Business/MyAccount/ManageAddOns.aspx", fbScope, Request["code"].ToString(), appSecret);
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
                Response.Redirect(RootPath + "/Business/MyAccount/ManageAddOns.aspx");
            }
        }
        protected void btnShareOnPage_Click(object sender, EventArgs e)
        {
            ShareOnPage();
        }
        private void ShareOnPage()
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
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAddOns.aspx?fbStatus=1"));
            }
            else
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAddOns.aspx?fbStatus=0"));
        }
        protected void lnkTwrShare_Click(object sender, EventArgs e)
        {
            string articleTitle = hdnBulletinTitle.Value.ToString();
            string description = hdnBulletinTitle.Value;
            description = objCommon.GetSocialDescription(description);
            string redirecturl = RootPath + "/OnlineItem.aspx?CMID=" + EncryptDecrypt.DESEncrypt(Convert.ToInt32(hdnCommandArg.Value).ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
            redirecturl = objCommon.longurlToshorturl(redirecturl);
            string tweetDesc = description.Replace("#", "");
            if ((description.Length + redirecturl.Length) > 137)
                tweetDesc = description.Substring(0, 140 - (redirecturl.Length + 3)).Replace("#", "");

            DataTable dtTwitterUser = smb.GetTwitterDataByUserID(ProfileID);
            if (dtTwitterUser.Rows.Count > 0)
            {
                objCommon.InsertUpdateAutoShareDetails("ContentModule", Convert.ToInt32(hdnCommandArg.Value), 0, DateTime.Now, "Twitter", UserID, C_UserID, articleTitle);
                lblmess.Text = "<font color='green'>Your selected item has been posted on twitter successfully.</font>";
            }
            else
            {
                string url = "http://www.twitter.com/share?url=" + redirecturl + "&text=" + tweetDesc;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + url + "', '_blank');", true);
            }
        }
        protected void RBAppOrder_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedOrderType = Convert.ToInt32(RBAppOrder.SelectedValue);

            //objCommon.UpdateDisplayOrderType(ProfileID, Convert.ToInt32(Session["CustomModuleID"]), selectedOrderType, "Bulletins");
            objCommon.UpdateDisplayOrderType(ProfileID, Convert.ToInt32(Session["CustomModuleID"].ToString()), selectedOrderType, "AddOn");
        }

        DropDownList ddlPageSize;
        private void SaveUserSettings()
        {
            try
            {
                string XMLdata = "<ManageAddOns MessagePageSize='" + PageSizes.SelectedPage + "'  /> ";
                var dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, "ManageAddOns", CustomModuleId);
                if (dtDisplayReadFirst.Rows.Count == 0)
                    objBus.UserCustomizeSettings(0, ProfileID, UserID, "ManageAddOns", XMLdata, CustomModuleId);
                else
                    objBus.UserCustomizeSettings(Convert.ToInt32(dtDisplayReadFirst.Rows[0]["CustomizeSettingsID"].ToString()), ProfileID, UserID, "ManageAddOns", XMLdata, CustomModuleId);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageAddOns.aspx.cs", "SaveUserSettings()", ex.Message,
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
            dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, "ManageAddOns", CustomModuleId);
            if (dtDisplayReadFirst.Rows.Count > 0)
            {
                XMLValue = Convert.ToString(dtDisplayReadFirst.Rows[0]["XMLValue"]);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(XMLValue);
                if (XMLValue != "")
                {
                    if (xmldoc.SelectSingleNode("ManageAddOns/@MessagePageSize") != null)
                    {
                        PageSizes.SelectedPage = xmldoc.SelectSingleNode("ManageAddOns/@MessagePageSize").Value;
                    }
                }
            }
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveUserSettings();
            GrdBulletins.PageSize = GetPageSize();
            GrdBulletins.DataSource = (DataTable)Session["DtBulletins"];
            GrdBulletins.DataBind();
        }

    }
}