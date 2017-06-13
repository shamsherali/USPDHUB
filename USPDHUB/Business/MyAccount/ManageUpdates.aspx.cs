using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Web.Services;
using System.Collections.Generic;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageUpdates : BaseWeb
    {
        public static string Urlreferer = string.Empty;
        public int ProfileID = 0;
        public int UserID = 0;
        public int BusinessUpdatesCount = 0;

        BusinessBLL busobj = new BusinessBLL();
        BusinessUpdatesBLL objUpdate = new BusinessUpdatesBLL();
        CommonBLL objCommon = new CommonBLL();
        DataTable dtHis = new DataTable();
        DataTable dtBusinessUpdates = new DataTable();
        public DataTable DtCampaign = new DataTable();

        public int BusinessUpdateUsageCount = 0;

        DataTable dtobj = new DataTable();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public string ArticleTitle = string.Empty;
        public string ArticleSummary = string.Empty;
        public int Divnum = 1;
        public string LinkedInurlinfo = string.Empty;
        public string FacebookInurlinfo = string.Empty;
        public string Twitterurlinfo = string.Empty;
        public string Mailtourlinfo = string.Empty;
        public int SortDir = 0;
        public string ArchiveValue = string.Empty;
        public int CUserID = 0;
        public string RootPath = "";

        public static DataTable Dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        USPDHUBBLL.MobileAppSettings objApp = new USPDHUBBLL.MobileAppSettings();
        public string PermissionType = string.Empty;
        public int PermissionValue = 0;
        public string DomainName = "";
        public string titleName = "";
        AddOnBLL objAddOn = new AddOnBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblmess.Text = "";
                if (Session["userid"] == null)
                {

                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                else
                {
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);
                    UserID = Convert.ToInt32(Session["UserID"].ToString());

                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                        CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        CUserID = UserID;
                }
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                hdnURLPath.Value = RootPath;
                // *** Make back button visible and disable by query string 26-03-2013 *** //
                if (!string.IsNullOrEmpty(Request.QueryString["App"]))
                    btnBack.Visible = true;
                else
                    btnBack.Visible = false;
                if (Session["Send"] != null)
                {
                    if (Session["Send"].ToString() != "")
                    {
                        if (Session["Send"].ToString() == "1")
                        {
                            if (Session["CheckMess"] != null)
                            {
                                if (Session["CheckMess"].ToString() != "")
                                {
                                    if (Session["CheckMess"].ToString() == "1")
                                    {
                                        lblmess.Text = "<font color='green'>We could not send this update as there are no valid email ids.</font>";
                                    }
                                    else if (Session["CheckMess"].ToString() == "2")
                                    {
                                        string invalidIds = string.Empty;
                                        if (Session["invalid"] != null)
                                        {
                                            if (Session["invalid"].ToString() != "")
                                            {
                                                invalidIds = Session["invalid"].ToString().ToString();
                                            }
                                            Session["invalid"] = null;
                                        }
                                        lblmess.Text = "<font color='green'>Update has been scheduled successfully except to the following ids as they appear to be invalid:</font><br>" + "<font color=#424242>" + invalidIds + "</font";
                                    }
                                    else if (Session["CheckMess"].ToString() == "3")
                                    {
                                        lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessUpdatemail + "</font>";
                                    }
                                    else if (Session["CheckMess"].ToString() == "4")
                                    {
                                        lblmess.Text = "<font color='green'>Update has been scheduled successfully. Some recipients have opted out of receiving future emails from you.</font>";
                                    }
                                    else if (Session["CheckMess"].ToString() == "5")
                                    {
                                        lblmess.Text = "<font color='green'>We could not send this update because the recipients have opted out of receiving future emails from you.</font>";
                                    }
                                }
                                else
                                {
                                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessUpdatemail + "</font>";
                                }
                                Session["CheckMess"] = null;
                            }
                            else
                            {
                                lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessUpdatemail + "</font>";
                            }
                        }
                        else if (Session["Send"].ToString() == "2")
                        {
                            if (Session["CheckMess"] != null)
                            {
                                if (Session["CheckMess"].ToString() != "")
                                {
                                    if (Session["CheckMess"].ToString() == "1")
                                    {
                                        lblmess.Text = "<font color='green'>We could not schedule this update as there are no valid email ids.</font>";
                                    }
                                    else if (Session["CheckMess"].ToString() == "2")
                                    {
                                        string invalidIds = string.Empty;
                                        if (Session["invalid"] != null)
                                        {
                                            if (Session["invalid"].ToString() != "")
                                            {
                                                invalidIds = Session["invalid"].ToString().ToString();
                                            }
                                            Session["invalid"] = null;
                                        }
                                        lblmess.Text = "<font color='green'>Update has been scheduled successfully except to the following ids as they appear to be invalid:</font><br>" + "<font color=#424242>" + invalidIds + "</font";
                                    }
                                    else if (Session["CheckMess"].ToString() == "3")
                                    {
                                        lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessUpdate + "</font>";
                                    }
                                    else if (Session["CheckMess"].ToString() == "4")
                                    {
                                        lblmess.Text = "<font color='green'>Update has been scheduled successfully. Some recipients have opted out of receiving future emails from you.</font>";
                                    }
                                    else if (Session["CheckMess"].ToString() == "5")
                                    {
                                        lblmess.Text = "<font color='green'>We could not schedule this update because the recipients have opted out of receiving future emails from you.</font>";
                                    }
                                }
                                else
                                {
                                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessUpdate + "</font>";
                                }
                                Session["CheckMess"] = null;
                            }
                            else
                            {
                                lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessUpdate + "</font>";
                            }

                        }
                    }
                    Session["Send"] = null;
                }


                // Check For Unlimted Users


                BusinessUpdateUsageCount = Convert.ToInt32(ConfigurationManager.AppSettings.Get("BusinessUpdateUsageCount").Replace(",", ""));

                titleName = objApp.GetMobileAppSettingTabName(UserID, "Updates", DomainName);
                lblTitle.Text = titleName;

                if (!IsPostBack)
                {

                    lblOff.Visible = true;
                    if (objCommon.DisplayOn_OffSettingsContent(UserID, "Updates"))
                    {
                        lblOn.Visible = true;
                        lblOff.Visible = false;
                    }
                    //roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        Dtpermissions = agencyobj.GetPermissionsById(Convert.ToInt32(Session["C_USER_ID"]));
                        if (Dtpermissions.Rows.Count > 0)
                        {
                            for (int i = 0; i < Dtpermissions.Rows.Count; i++)
                            {
                                PermissionValue = Convert.ToInt32(Dtpermissions.Rows[i]["Permission_Values"].ToString());
                                if (Convert.ToBoolean(PermissionValue & Constants.UPDATES))
                                {
                                    PermissionType = Dtpermissions.Rows[i]["Permission_Type"].ToString();
                                    hdnPermissionType.Value = PermissionType;
                                }
                            }
                        }
                        if (string.IsNullOrEmpty(hdnPermissionType.Value))
                        {
                            UpdatePanel2.Visible = true;
                            UpdatePanel1.Visible = false;
                            lblerrormessage.Text = "<font face=arial size=2>You do not have permission to manage updates.</font>";
                        }
                    }
                    //ends here

                    if (Session["ViewGrid"] != null)
                    {
                        hdnarchive.Value = Session["ViewGrid"].ToString();
                        lnkGetArchive.Text = "<img src='../../Images/Dshboard/archive.gif' title='Archive' border='0'/>";
                        lnkCurrent.Text = "<img src='../../Images/Dshboard/current.gif' title='Current' border='0'/>";
                        Session["ViewGrid"] = null;
                    }
                    Session["BusinessUpdateID"] = null;
                    Session["BusinessUpdateDes"] = null;
                    //  Hdn control for Sorting
                    hdnsortdire.Value = "";
                    hdnsortcount.Value = "0";
                    if (Session["UpdateSuccess"] != null)
                    {
                        lblmess.Text = "<font color='green'>" + Session["UpdateSuccess"].ToString() + "</font>";
                        Session["UpdateSuccess"] = null;
                    }
                    FillDatalist();
                    if (Session["BulletinSuccess"] != null)
                    {
                        lblmess.Text = Session["BulletinSuccess"].ToString();
                        Session.Remove("BulletinSuccess");
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
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "Page_Load", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public void FillDatalist()
        {
            try
            {
                trPublish.Visible = trUnPublish.Visible = false;
                trSendNotification.Visible = false;
                hdnCommandArg.Value = "";
                //lblFlyerthub.Text = "Update Thumbnail";
                dtobj = objUpdate.GetAllBusinessUpdates(Convert.ToInt32(Session["ProfileID"]));
                // ** show Current and Archive tabs *** //
                if (dtobj.Rows.Count > 0)
                {
                    ShowCurrArcives(true);
                }
                else
                {
                    ShowCurrArcives(false);
                }
                if (hdnarchive.Value == "Archive")
                {
                    GrdbusinessUpdates.Columns[2].Visible = true;
                    GrdbusinessUpdates.Columns[1].Visible = false;
                    ArchiveValue = "Archive";
                }
                else
                {
                    GrdbusinessUpdates.Columns[1].Visible = true;
                    GrdbusinessUpdates.Columns[2].Visible = false;
                    ArchiveValue = "NoArchive";
                }
                dtobj = RemoveArchive(dtobj, ArchiveValue);
                if (dtobj.Rows.Count > 0)
                {
                    dtobj.Columns.Add("Sent_Flag", typeof(string));
                    for (int i = 0; i < dtobj.Rows.Count; i++)
                    {
                        DataTable dtScheduleEmails = objUpdate.CheckBusinessUpdateCampaignCountByID(Convert.ToInt32(dtobj.Rows[i]["UpdateId"].ToString()), "Updates");
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
                                if (Convert.ToBoolean(dtobj.Rows[i]["IsPublished"].ToString()) == false)
                                    dtobj.Rows[i]["Sent_Flag"] = "Work in Progress";
                                else
                                    dtobj.Rows[i]["Sent_Flag"] = "Completed";
                            }
                        }
                        else
                        {
                            if (Convert.ToBoolean(dtobj.Rows[i]["IsPublished"].ToString()) == false)
                                dtobj.Rows[i]["Sent_Flag"] = "Work in Progress";
                            else
                                dtobj.Rows[i]["Sent_Flag"] = "Completed";
                        }
                    }
                }
                Session["DtGetBusinessUpdates"] = dtobj;
                BusinessUpdatesCount = dtobj.Rows.Count;
                if (BusinessUpdatesCount > 0)
                {
                    hdnShowButtons.Value = "1";
                }
                else
                {
                    hdnShowButtons.Value = "";
                }
                GrdbusinessUpdates.DataSource = dtobj.DefaultView;
                GrdbusinessUpdates.DataBind();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "FillDatalist", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void GrdbusinessUpdates_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkcam = e.Row.FindControl("lnkruncampaion") as LinkButton;
                    Label lblupdatethub = e.Row.FindControl("lblupdatethub") as Label;
                    Label lblcam = e.Row.FindControl("lblcam") as Label;
                    string updateID = lnkcam.CommandArgument;
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
                    string imageDisID = Guid.NewGuid().ToString();
                    if (File.Exists(Server.MapPath("~") + "\\Upload\\Updates\\" + ProfileID.ToString() + "\\" + updateID + ".jpg"))
                        lblupdatethub.Text = "<img src='" + RootPath + "/Upload/Updates/" + ProfileID.ToString() + "/" + updateID + ".jpg?Guid=" + imageDisID + "' border='0' width='100' height='50'/>";
                    else
                        lblupdatethub.Text = "";
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
                    //DataTable dtScheduleEmails=objUpdate.CheckBusinessUpdateCampaignCountByID(Convert.ToInt32(lnkcam.CommandArgument));
                    //if (dtScheduleEmails.Rows.Count > 0)
                    //{
                    //    if (dtScheduleEmails.Rows[0]["Count"].ToString() != "0")
                    //    {
                    //        lnkcam.Visible = true;
                    //        lblcam.Visible = false;
                    //        if (Convert.ToInt32(dtScheduleEmails.Rows[0]["Scheduled"].ToString()) > 0 && Convert.ToInt32(dtScheduleEmails.Rows[0]["Sent"].ToString()) > 0)
                    //        {
                    //            lnkcam.Text = "Sending";                                             
                    //        }
                    //        else if (Convert.ToInt32(dtScheduleEmails.Rows[0]["Scheduled"].ToString()) > 0)
                    //        {
                    //            lnkcam.Text = "Scheduled";                        
                    //        }
                    //        else if (Convert.ToInt32(dtScheduleEmails.Rows[0]["Scheduled"].ToString()) == 0 && Convert.ToInt32(dtScheduleEmails.Rows[0]["Sent"].ToString()) > 0)
                    //        {
                    //            lnkcam.Text = "Sent";
                    //        }                    
                    //        else
                    //        {
                    //            lnkcam.Text = "Cancelled";
                    //        }
                    //    }
                    //    else
                    //    {
                    //        lblcam.Visible = true;
                    //        lnkcam.Visible = false;
                    //    }
                    //}            
                    //else
                    //{
                    //    lblcam.Visible = true;
                    //    lnkcam.Visible = false;
                    //}

                    string strScript = "SelectDeSelectHeader(" + ((CheckBox)e.Row.Cells[2].FindControl("chkUpdate")).ClientID + ");";
                    ((CheckBox)e.Row.Cells[2].FindControl("chkUpdate")).Attributes.Add("onclick", strScript);
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "GrdbusinessUpdates_RowDataBound", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void GrdbusinessUpdates_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                trSendNotification.Visible = false;
                hdnShowButtons.Value = "1"; // *** To show all buttons ex: Preview, edit etc. *** //
                hdnCommandArg.Value = "";
                //lblFlyerthub.Text = "Update Thumbnail";
                GrdbusinessUpdates.PageIndex = e.NewPageIndex;
                GrdbusinessUpdates.DataSource = (DataTable)Session["DtGetBusinessUpdates"];
                GrdbusinessUpdates.DataBind();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "GrdbusinessUpdates_PageIndexChanging", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void GrdbusinessUpdates_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                trUnPublish.Visible = trPublish.Visible = false;
                trSendNotification.Visible = false;
                SortDir = Convert.ToInt32(hdnsortcount.Value);
                string sortExp = e.SortExpression.ToString();
                dtBusinessUpdates = (DataTable)Session["DtGetBusinessUpdates"];
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
                DataView dv = new DataView(dtBusinessUpdates);
                if (SortDir == 0)
                {

                    if (sortExp == "Name")
                    {
                        dv.Sort = "updatetitle desc";
                    }
                    else if (sortExp == "IsPublic")
                    {
                        dv.Sort = "IsDisplay desc";
                    }
                    else if (sortExp == "UpdateTime")
                    {
                        dv.Sort = "UpdateTime desc";
                    }
                    else if (sortExp == "Status")
                    {
                        dv.Sort = "Sent_Flag desc";
                    }
                    hdnsortcount.Value = "1";
                }
                else
                {
                    if (sortExp == "Name")
                    {
                        dv.Sort = "updatetitle ASC";
                    }
                    else if (sortExp == "IsPublic")
                    {
                        dv.Sort = "IsDisplay ASC";
                    }
                    else if (sortExp == "UpdateTime")
                    {
                        dv.Sort = "UpdateTime asc";
                    }
                    else if (sortExp == "Status")
                    {
                        dv.Sort = "Sent_Flag asc";
                    }
                    hdnsortcount.Value = "0";
                }

                Session["DtGetBusinessUpdates"] = dv.ToTable();
                GrdbusinessUpdates.DataSource = dv;
                GrdbusinessUpdates.DataBind();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "GrdbusinessUpdates_Sorting", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        //protected void lnkStatus_Click(object sender, EventArgs e)
        //{
        //    LinkButton lnkStatus = (LinkButton)sender;
        //    int i = 0;
        //    i = objUpdate.UpdateBusinessUpdateStatus(Convert.ToInt32(lnkStatus.CommandArgument), lnkStatus.Text == "Public" ? false : true, ProfileID, C_UserID);
        //    if (i > 0)
        //        lblmess.Text = "<font color='green'>Status Updated Successfully.</font>";

        //    FillDatalist();
        //}

        protected void RbUpdateCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                trUnPublish.Visible = trPublish.Visible = false;
                trSendNotification.Visible = false;
                RadioButton rb = (RadioButton)sender;
                GridViewRow row = (GridViewRow)rb.NamingContainer;
                LinkButton lnk = (LinkButton)row.FindControl("lnkUpdateName");
                LinkButton lnkcamp = (LinkButton)row.FindControl("lnkruncampaion");
                Label lblisCompleted = (Label)row.FindControl("lblisCompleted");
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
                hdnUpdateTitle.Value = lnk.Text;
                GetSharestrings(Convert.ToInt32(hdnCommandArg.Value), lnk.Text);
                if (lblisCompleted.Text == "True")
                {
                    trSendNotification.Visible = true;
                    trUnPublish.Visible = true;
                }
                else
                    trPublish.Visible = true;


                var expiryDate = Convert.ToString(GrdbusinessUpdates.DataKeys[Convert.ToInt32(row.RowIndex)].Values["Expiration_Date"].ToString());
                if (expiryDate != string.Empty)
                {
                    if (Convert.ToDateTime(expiryDate) < DateTime.Now)
                    {
                        trUnPublish.Visible = false;
                        trSendNotification.Visible = false;
                        trPublish.Visible = false;
                    }
                }
                //string UpdatePath = HttpContext.Current.Server.MapPath("~") + "\\Upload\\Updates\\" + ProfileID.ToString();
                //if (!System.IO.Directory.Exists(UpdatePath))
                //{
                //    System.IO.Directory.CreateDirectory(UpdatePath);
                //}
                //UpdatePath = UpdatePath + "\\" + hdnCommandArg.Value + ".jpg";
                //hdnflyerthumb.Value = "";
                //if (!System.IO.File.Exists(UpdatePath))
                //{
                //    lblFlyerthub.Text = "Update Thumbnail";
                //}
                //else
                //{
                //    string ImageDisID = Guid.NewGuid().ToString();
                //    hdnflyerthumb.Value = "<img src='" + ConfigurationManager.AppSettings.Get("SRootpath") + "/Upload/Updates/" + ProfileID.ToString() + "/" + hdnCommandArg.Value + ".jpg?Guid=" + ImageDisID + "' border='0' width='100' height='100'/>";
                //}
                //ShowFlyerThumb();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "RbUpdateCheckedChanged", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void ChkUpdateCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int selectCount = 0;
                //Identify CheckBox is checked or not
                foreach (GridViewRow grdrow in GrdbusinessUpdates.Rows)
                {
                    if (((CheckBox)grdrow.FindControl("chkUpdate")).Checked)
                    {
                        selectCount = selectCount + 1;
                        LinkButton lnkname = (LinkButton)grdrow.FindControl("lnkUpdateName");
                        if (selectCount == 1)
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
                            if (selectCount > 1 || selectCount == 0)
                            {
                                hdnCommandArg.Value = "";
                                CancelCamp.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "ChkUpdateCheckedChanged", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void ChkSelectAllCheckedChanged(object sender, EventArgs e)
        {
            CancelCamp.Visible = false;
        }

        protected void LnkUpdateNameClick(object sender, EventArgs e)
        {
            //ShowFlyerThumb();
            LinkButton lnkdetails = sender as LinkButton;
            ShowPreview(lnkdetails.CommandArgument);
        }

        protected void LblhistroyClick(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkHis = sender as LinkButton;
                BusinessUpdatesBLL objBusUpdates = new BusinessUpdatesBLL();
                dtHis = objBusUpdates.GetBusinessUpdateDetailsByBusinessUpdateID(Convert.ToInt32(lnkHis.CommandArgument));
                if (dtHis.Rows.Count > 0)
                {
                    // *** Issue 1031 *** //
                    DataView dtcampview = dtHis.DefaultView;
                    dtcampview.Sort = "sent_Flag ASC";
                    dtHis = dtcampview.ToTable();
                    Session["DtHis"] = dtHis;
                    // *** End Issue 1031 ***  //
                    grdviewsenthis.DataSource = dtHis;
                    grdviewsenthis.DataBind();
                    DataTable dtNewMaster = new DataTable();
                    dtNewMaster = objBusUpdates.UpdateBusinessUpdateDetails(Convert.ToInt32(lnkHis.CommandArgument));
                    if (dtNewMaster.Rows.Count > 0)
                    {
                        lblviewsentnewlettername.Text = dtNewMaster.Rows[0]["UpdateTitle"].ToString();
                    }
                    ModalPopupExtender3.Show();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "LblhistroyClick", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void GrdviewsenthisRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "GrdviewsenthisRowDataBound", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void GrdviewsenthisPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdviewsenthis.PageIndex = e.NewPageIndex;
                grdviewsenthis.DataSource = (DataTable)Session["DtHis"];
                grdviewsenthis.DataBind();
                ModalPopupExtender3.Show();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "GrdviewsenthisPageIndexChanging", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void LnkPreviewClick(object sender, EventArgs e)
        {
            //ShowFlyerThumb();
            ShowPreview(hdnCommandArg.Value);
        }

        protected void LnkEditClick(object sender, EventArgs e)
        {
            try
            {
                /** This is for allowing creators only 26/06/2013**/
                List<string> permissionList = new List<string>();
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    Dtpermissions = agencyobj.GetPermissionsById(Convert.ToInt32(Session["C_USER_ID"]));
                    for (int i = 0; i < Dtpermissions.Rows.Count; i++)
                    {
                        PermissionValue = Convert.ToInt32(Dtpermissions.Rows[i]["Permission_Values"].ToString());
                        if (Convert.ToBoolean(PermissionValue & Constants.UPDATES))
                        {
                            PermissionType = Dtpermissions.Rows[i]["Permission_Type"].ToString();
                            permissionList.Add(PermissionType);
                        }
                    }
                    if ((permissionList.Count == 2) || (PermissionType == "A" && permissionList.Count == 1 && permissionList[0] == "A"))
                    {
                        if (hdnCommandArg.Value != "")
                        {
                            int updateID = Convert.ToInt32(hdnCommandArg.Value);
                            BusinessUpdatesBLL objBusUpdate = new BusinessUpdatesBLL();
                            DataTable dtChekHis = objBusUpdate.GetBusinessUpdateDetailsByBusinessUpdateID(updateID);
                            DataRow[] rows = dtChekHis.Select("Sent_Flag=0");
                            if (rows.Length > 0)
                            {
                                ScriptManager.RegisterClientScriptBlock(lnkEdit, this.GetType(), "JavaScrtiptAlert", "javascript: fnShowMessage(" + updateID + ");", true);
                            }
                            else
                            {
                                string url = Page.ResolveClientUrl("~/Business/MyAccount/EditUpdate.aspx?Update_ID=" + updateID);
                                if (btnBack.Visible)
                                    url = Page.ResolveClientUrl("~/Business/MyAccount/EditUpdate.aspx?Update_ID=" + updateID + "&App=1");
                                Response.Redirect(url);
                            }
                        }
                    }
                    else if (permissionList[0] == "P" && PermissionType == "P" && permissionList.Count == 1)
                    {
                        lblmess.Text = "You don't have permission to edit an Update.";
                    }
                }
                else
                {
                    if (hdnCommandArg.Value != "")
                    {
                        int updateID = Convert.ToInt32(hdnCommandArg.Value);
                        BusinessUpdatesBLL objBusUpdate = new BusinessUpdatesBLL();
                        DataTable dtChekHis = objBusUpdate.GetBusinessUpdateDetailsByBusinessUpdateID(updateID);
                        DataRow[] rows = dtChekHis.Select("Sent_Flag=0");
                        if (rows.Length > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(lnkEdit, this.GetType(), "JavaScrtiptAlert", "javascript: fnShowMessage(" + updateID + ");", true);
                        }
                        else
                        {
                            string url = Page.ResolveClientUrl("~/Business/MyAccount/EditUpdate.aspx?Update_ID=" + updateID);
                            if (btnBack.Visible)
                                url = Page.ResolveClientUrl("~/Business/MyAccount/EditUpdate.aspx?Update_ID=" + updateID + "&App=1");
                            Response.Redirect(url);
                        }
                    }
                }
                permissionList.Clear();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "LnkEditClick", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnclickClick(object sender, EventArgs e)
        {
            if (hdnCommandArg.Value != "")
            {
                int updateID = Convert.ToInt32(hdnCommandArg.Value);
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/EditUpdate.aspx?Update_ID=" + updateID));
            }
        }

        protected void LnkdeleteClick(object sender, EventArgs e)
        {
            try
            {
                if (hdnarchive.Value != "Archive")
                {
                    if (hdnCommandArg.Value != "")
                    {
                        int countCampaign = objUpdate.CheckBusinessUpdateCampaignCount(Convert.ToInt32(hdnCommandArg.Value));
                        if (countCampaign == 0)
                        {

                            // Save User Activity Log
                            objCommon.InsertUserActivityLog("has deleted an update named <b>" + hdnUpdateTitle.Value + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);

                            USPDHUBBLL.BusinessUpdatesBLL.DeleteBusinessUpdateDetails(Convert.ToInt32(hdnCommandArg.Value));
                            FillDatalist();
                            lblmess.Text = "<font color='red'>Your update has been deleted successfully.</font>";
                        }
                        else
                        {
                            string maxSchDate = string.Empty;
                            maxSchDate = objUpdate.GetBusinessUpdateMaxScheduleingDate(UserID);
                            maxSchDate = maxSchDate.Replace("12:00:00 AM", "");
                            lblmess.Text = "<font color='green'>Sorry, you cannot delete your update now as you have a update campaign scheduled till" + " " + maxSchDate + ".</font>";
                        }
                    }
                }
                else
                {
                    int scheduledCount = 0;
                    //Identify CheckBox is checked or not
                    foreach (GridViewRow row in GrdbusinessUpdates.Rows)
                    {
                        if (((CheckBox)row.FindControl("chkUpdate")).Checked)
                        {
                            int updateID = int.Parse(((LinkButton)(GrdbusinessUpdates.Rows[row.RowIndex].FindControl("lnkUpdateName"))).CommandArgument);
                            int countCampaign = objUpdate.CheckBusinessUpdateCampaignCount(updateID);

                            #region Save User Activity Log

                            string Title = ((LinkButton)(GrdbusinessUpdates.Rows[row.RowIndex].FindControl("lnkUpdateName"))).Text;
                            objCommon.InsertUserActivityLog("has deleted an update named <b>" + Title + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);

                            #endregion

                            if (countCampaign == 0)
                            {
                                USPDHUBBLL.BusinessUpdatesBLL.DeleteBusinessUpdateDetails(updateID);
                            }
                            else
                            {
                                scheduledCount = scheduledCount + 1;
                            }
                        }
                    }
                    if (scheduledCount > 0)
                    {
                        lblmess.Text = "<font size='3'>Your selection(s) have been deleted successfully except the ones that are being scheduled.</font>";
                    }
                    else
                    {
                        lblmess.Text = "<font size='3'>Your selection(s) have been deleted successfully.</font>";
                    }
                    CancelCamp.Visible = false;
                    GrdbusinessUpdates.PageIndex = 0;
                    FillDatalist();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "LnkdeleteClick", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void LnkSendClick(object sender, EventArgs e)
        {
            try
            {
                BusinessBLL objBus = new BusinessBLL();
                int checkSch = 0;
                checkSch = objUpdate.CheckforBusinessUpdateSchedule(UserID);
                int cntUsage = 0;
                int checkCam = 0;
                if (checkSch > 0)
                {
                    checkCam = 1;
                }
                DataTable dtGetuserUsage = new DataTable();
                dtGetuserUsage = objBus.GetUserContactDetailsUsage(DateTime.Now.Date, UserID);
                if (dtGetuserUsage.Rows.Count > 0)
                {
                    cntUsage = Convert.ToInt32(dtGetuserUsage.Rows[0]["BusinessUpdate_Usage"].ToString());
                }
                int chek = cntUsage + checkSch;
                checkSch = BusinessUpdateUsageCount - chek;
                if (checkSch > 0)
                {
                    Session["BusinessUpdateID"] = null;
                    Session["BusinessUpdateDes"] = null;
                    int businessUpdateID = 0;
                    DataTable dtGetBusUpate = new DataTable();
                    businessUpdateID = Convert.ToInt32(hdnCommandArg.Value);
                    dtGetBusUpate = objUpdate.UpdateBusinessUpdateDetails(businessUpdateID);

                    string businessUpdateDes = dtGetBusUpate.Rows[0]["UpdatedText"].ToString();
                    Session["BusinessUpdateID"] = businessUpdateID.ToString();
                    Session["BusinessUpdateDes"] = businessUpdateDes;
                    if (hdnarchive.Value == "Archive")
                        Session["ViewGrid"] = hdnarchive.Value;
                    string url = Page.ResolveClientUrl("~/Business/MyAccount/SendUpdates.aspx");
                    if (btnBack.Visible)
                        url = Page.ResolveClientUrl("~/Business/MyAccount/SendUpdates.aspx?App=1");
                    Response.Redirect(url);

                    /*if (dtGetBusUpate.Rows.Count > 0)
                    {

                        if (dtGetBusUpate.Rows[0]["IsPublished"].ToString() == "False")
                        {
                            lblmess.Text = "<font color='red'>You cannot send an unpublished update.</font>";
                        }
                        else
                        {
                            string businessUpdateDes = dtGetBusUpate.Rows[0]["UpdatedText"].ToString();
                            Session["BusinessUpdateID"] = businessUpdateID.ToString();
                            Session["BusinessUpdateDes"] = businessUpdateDes;
                            if (hdnarchive.Value == "Archive")
                                Session["ViewGrid"] = hdnarchive.Value;
                            string url = Page.ResolveClientUrl("~/Business/MyAccount/SendUpdates.aspx");
                            if (btnBack.Visible)
                                url = Page.ResolveClientUrl("~/Business/MyAccount/SendUpdates.aspx?App=1");
                            Response.Redirect(url);
                        }

                    }
                    */
                }
                else
                {
                    if (checkCam > 0)
                    {
                        string maxSchDate = string.Empty;
                        maxSchDate = objUpdate.GetBusinessUpdateMaxScheduleingDate(UserID);
                        maxSchDate = maxSchDate.Replace("12:00:00 AM", "");
                        lblmess.Text = "<font color='green'>" + Resources.LabelMessages.AlreadyHaveBusinessUpdateCampaign + " " + maxSchDate + ".</font>";
                    }
                    else
                    {
                        lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendaffiliatecountExceeded + "</font>";
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "LnkSendClick", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void LnkArchiveClick(object sender, EventArgs e)
        {
            try
            {
                bool archiveFlag = true;
                LinkButton lnkCurrArchive = sender as LinkButton;
                string lnkText = lnkCurrArchive.Text;
                int archiveID = Convert.ToInt32(hdnCommandArg.Value);
                int countCampaign = objUpdate.CheckBusinessUpdateCampaignCount(Convert.ToInt32(hdnCommandArg.Value));
                if (lnkText.Contains("Current"))
                    archiveFlag = false;
                if (countCampaign == 0)
                {
                    objCommon.ArchiveSelectedNewsletter(archiveID, archiveFlag, "Update", CUserID);
                    if (archiveFlag == false)
                        lblmess.Text = "Your update has been reinstated successfully.";
                    else
                        lblmess.Text = "Your update has been archived successfully.";
                    FillDatalist();
                }
                else
                {
                    string maxSchDate = string.Empty;
                    maxSchDate = objUpdate.GetBusinessUpdateMaxScheduleingDate(UserID);
                    maxSchDate = maxSchDate.Replace("12:00:00 AM", "");
                    if (archiveFlag == false)
                        lblmess.Text = (Resources.LabelMessages.ArchiveSchedulenewsletter + " " + maxSchDate + ".").Replace("flyer", "update").Replace("archive", "reinstate");
                    else
                        lblmess.Text = (Resources.LabelMessages.ArchiveSchedulenewsletter + " " + maxSchDate + ".").Replace("flyer", "update");
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "LnkArchiveClick", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void LnkCancelCampClick(object sender, EventArgs e)
        {
            try
            {
                DtCampaign = objUpdate.GetCampaignBusinessDetailsByDates(Convert.ToInt32(hdnCommandArg.Value));
                DataView dtcampview = DtCampaign.DefaultView;
                dtcampview.Sort = "sent_Flag ASC";
                DtCampaign = dtcampview.ToTable();
                Session["dtCampaign"] = DtCampaign;
                lblp.Text = hdnCommandArg.Value;
                if (DtCampaign.Rows.Count > 0)
                {
                    grdschemail.DataSource = DtCampaign;
                    grdschemail.DataBind();
                    ModalPopupExtender1.Show();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "LnkCancelCampClick", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void LnkReportsClick(object sender, EventArgs e)
        {
            string redirectUrl = string.Empty;
            if (hdnarchive.Value == "Archive")
                redirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/UpdatesReports.aspx?Flag=Archive");
            else
                redirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/UpdatesReports.aspx?Flag=Current");
            if (btnBack.Visible)
                redirectUrl = redirectUrl + "&App=1";
            Response.Redirect(redirectUrl);
        }

        protected void GrdschemailRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
                    int count = 0;
                    count = objUpdate.GetBusinessupdateCountforDayforUserDateAndUpdateID(UserID, Convert.ToDateTime(lbldate.Text), Convert.ToInt32(lblp.Text));
                    lblCount.Text = count.ToString();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "GrdschemailRowDataBound", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void GrdschemailPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdschemail.PageIndex = e.NewPageIndex;
                grdschemail.DataSource = (DataTable)Session["dtCampaign"];
                grdschemail.DataBind();
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "GrdschemailPageIndexChanging", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnstopcampainClick(object sender, EventArgs e)
        {
            try
            {
                objUpdate.UpdateBusinessUpdateUsageByUserID(UserID, DateTime.Today);
                objUpdate.CancelBusinessUpdateCampaign(Convert.ToInt32(lblp.Text));
                CancelCamp.Visible = false;
                FillDatalist();
                lblmess.Text = "<font color='green'>Your update campaign has been cancelled successfully.</font>";
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "BtnstopcampainClick", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void LnkGetArchiveClick(object sender, EventArgs e)
        {
            CancelCamp.Visible = false;
            lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive.gif' title='Archive' border='0'/>";
            lnkCurrent.Text = "<img src='../../Images/Dashboard/current.gif' title='Current' border='0'/>";
            hdnCommandArg.Value = "";
            hdnarchive.Value = "Archive";
            FillDatalist();
        }

        protected void LnkCurrentClick(object sender, EventArgs e)
        {
            CancelCamp.Visible = false;
            lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>";
            lnkCurrent.Text = "<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>";
            hdnCommandArg.Value = "";
            hdnarchive.Value = "NoArchive";
            FillDatalist();
        }

        protected void BtnCancelClick(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }

        protected void ImcloseClick(object sender, ImageClickEventArgs e)
        {
            //ShowFlyerThumb();
        }

        private void ShowPreview(string updateID)
        {
            try
            {
                string previewHtml = string.Empty;
                DataTable dtBusinessUpdateDetails = objUpdate.UpdateBusinessUpdateDetails(Convert.ToInt32(updateID));
                if (dtBusinessUpdateDetails.Rows.Count > 0)
                {
                    previewHtml = dtBusinessUpdateDetails.Rows[0]["UpdatedText"].ToString();
                    previewHtml = "<html><head></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='border: solid 2px #F4EBEB;'><tr><td colspan='2' style='padding:30px;'>" + previewHtml + "</td></tr></table></body></html>";
                    lblPreviewHTML.Text = previewHtml;
                    lblupdatename.Text = dtBusinessUpdateDetails.Rows[0]["UpdateTitle"].ToString();
                    ModalPopupExtender2.Show();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "ShowPreview", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string UserProfileUnsubscribeLink()
        {
            string unSubscribeLinkText = string.Empty;
            try
            {
                BusinessBLL objBus = new BusinessBLL();
                DataTable dtProfileAddress = new DataTable();
                dtProfileAddress = objBus.GetProfileDetailsByProfileID(ProfileID);
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
                unSubscribeLinkText = "This message was sent by " + profileName + " to &#60;recipient's email address&#62;. It was sent from &#60;sender's email address&#62;" + totalAddress + ". If you no longer wish to receive our updates, <a href='" + RootPath + "/Unsubscribeupdate.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "' target='_blank'>click here</a> to unsubscribe.";
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "UserProfileUnsubscribeLink", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return unSubscribeLinkText;
        }

        protected void GetSharestrings(int updateID, string updateTitle)
        {
            try
            {
                #region Sharelinks with Facebook, LinkedIn, Twitter, MySpace and Email
                ArticleTitle = updateTitle.ToString();
                ArticleSummary = updateTitle.ToString();
                DataTable dtUpdate = new DataTable();
                dtUpdate = objUpdate.UpdateBusinessUpdateDetails(updateID);
                string description = Convert.ToString(dtUpdate.Rows[0]["UpdatedText"]);
                description = objCommon.GetSocialDescription(description);
                string redirecturl = RootPath + "/OnlineUpdate.aspx?BID=" + EncryptDecrypt.DESEncrypt(updateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
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

                lblFacebookPageShare.Text = "<a href='javascript:post_on_page()'><img src='../../images/Dashboard/facebooknew.gif' alt='Share on Facebook Page' width='55' height='36' title='Share on Facebook Page' border='0' /></a>";
                //Facebook

                //Pinterest

                string PinterestUrl = "http://pinterest.com/pin/create/button/?url=" + RootPath + "/OnlineUpdate.aspx?BID=" + EncryptDecrypt.DESEncrypt(updateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&media=" + RootPath + "/Images/VerticalLogos/" + DomainName + "logo.png&description=" + tweetDesc;
                string PinterestUrlshare = "<a count-layout='horizontal' href='" + PinterestUrl + "'  target='_blank'><img border='0' src='../../images/Dashboard/PinterestLogo.gif' title='Pin It' alt='Share on Pinterest' width='55' height='36' /></a>";
                lblPinShare.Text = PinterestUrlshare;
                //Pinterest

                //***************** Commented by Suneel(Updates sharing via Linkedin)******************//
                //LinkedIN
                string update = EncryptDecrypt.DESEncrypt(updateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
                string articleUrl1 = RootPath + "/OnlineUpdate.aspx?BID=" + update;
                string articleSource = RootPath;

                //string linkedInurlinfo1 = "http://www.linkedin.com/shareArticle?mini=true&url=" + HttpUtility.UrlEncode(articleUrl1) + "&title=" + HttpUtility.UrlEncode(ArticleTitle) + "&summary=" + HttpUtility.UrlEncode(ArticleSummary) + "&source=" + HttpUtility.UrlEncode(articleSource);
                //LinkedInurlinfo = "<a href='" + linkedInurlinfo1.ToString() + "' target='_blank'><img src='../../images/Dashboard/linkedinnew.gif' title='Share on Linkedin' border='0' width='46' height='36'/></a>";
                //lbllinkedinShare.Text = LinkedInurlinfo;
                //LinkedIn

                //Twitter
                string twitterurlinfo1 = "http://www.twitter.com/share?url=" + redirecturl + "&text=" + tweetDesc;
                Twitterurlinfo = "<a href='" + twitterurlinfo1 + "' title='Click to share this post on Twitter' target='_blank'><img src='../../images/Dashboard/twitternew.gif' alt='Share on Twitter' title='Share on Twitter' border='0' width='39' height='38'/></a>";
                lblTwitterShare.Text = Twitterurlinfo;
                //Twitter

                //Mail TO Url

                string url = RootPath + "/Business/Myaccount/ShareEmail.aspx?BU=" + update;
                Mailtourlinfo = "<a href=\"javascript:openEmailwindow('" + url + "')\"><img src='../../images/Dashboard/emailnew.gif' title='Share on Email' width='30' height='38' alt='Share on Email'/></a>";
                lblEmailShare.Text = Mailtourlinfo;
                #endregion
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "GetSharestrings", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        [WebMethod]
        public static string ServerSidefill(string updateName, int profileID)
        {
            string flyerPath = "";

            try
            {
                flyerPath = HttpContext.Current.Server.MapPath("~") + "\\Upload\\Updates\\" + profileID.ToString();
                if (!System.IO.Directory.Exists(flyerPath))
                {
                    System.IO.Directory.CreateDirectory(flyerPath);
                }
                flyerPath = flyerPath + "\\" + updateName + ".jpg";
                if (!System.IO.File.Exists(flyerPath))
                {
                    flyerPath = "No Image";
                }
                else
                {
                    flyerPath = "<img src='" + HttpContext.Current.Session["RootPath"].ToString() + "/Upload/Updates/" + profileID.ToString() + "/" + updateName + ".jpg' border='0' width='100' height='100'/>";
                }
            }
            catch
            {
                flyerPath = "No Image";
            }

            return flyerPath;

        }

        private void ShowCurrArcives(bool flag)
        {
            lnkGetArchive.Visible = flag;
            lnkCurrent.Visible = flag;
        }

        private DataTable RemoveArchive(DataTable dt, string archive)
        {
            // *** Get Newsletter without Achrive *** //
            DataTable dtData = dt;
            string selectQuery = string.Empty;
            if (archive == "NoArchive")
            {
                selectQuery = "IsArchive='True'";
            }
            else
            {
                selectQuery = "IsArchive='False'";
            }
            DataRow[] dRSelectArcive;
            dRSelectArcive = dtData.Select(selectQuery);
            DataTable dtupdatedarcive = dtData.Clone();
            foreach (DataRow dr in dRSelectArcive)
            {
                dtupdatedarcive.ImportRow(dr);
                dtData.Rows.Remove(dr);
            }
            dtData.AcceptChanges();
            return dtData;
        }

        protected void LnkCopyClick(object sender, EventArgs e)
        {
            lbleditext.Text = "";
            txtCampName.Text = "";
            lblFlyerimage.Text = "";
            if (hdnCommandArg.Value != "")
            {
                int masterCampaignID = Convert.ToInt32(hdnCommandArg.Value);
                string imgSrc = "";
                lblFlyerimage.Text = "<table border='0' cellpadding='0' cellspacing='0' width='100%' class='imggrid'><tr>";
                imgSrc = "<td><img src='" + RootPath + "/Upload/Updates" + "/" + ProfileID.ToString() + "/" + masterCampaignID + ".jpg' Height='250px' Width='400px'/></td>";
                lblFlyerimage.Text = lblFlyerimage.Text + imgSrc;
                lblFlyerimage.Text = lblFlyerimage.Text + "</tr></Table>";
                ModalPopupExtender6.Show();
            }
        }

        protected void BtneditTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                bool checkCampaignName = true;
                checkCampaignName = objUpdate.CheckUpdateNameAvailable(txtCampName.Text.Trim(), UserID);
                if (checkCampaignName)
                {
                    if (hdnCommandArg.Value != "")
                    {
                        int updateID;
                        updateID = objUpdate.CopyUpdateDetails(UserID, Convert.ToInt32(hdnCommandArg.Value), txtCampName.Text.Trim());
                        string shortenUrl = RootPath + "/OnlineUpdate.aspx?BID=" + EncryptDecrypt.DESEncrypt(updateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
                        shortenUrl = objCommon.longurlToshorturl(shortenUrl);
                        objCommon.UpdateShortenURl(updateID, shortenUrl, "UPDATES");
                        int masterCampaignID = Convert.ToInt32(hdnCommandArg.Value);
                        if (File.Exists(Server.MapPath("~") + "\\Upload\\Updates\\" + ProfileID.ToString() + "\\" + masterCampaignID.ToString() + ".jpg"))
                            File.Copy(Server.MapPath("~") + "\\Upload\\Updates\\" + ProfileID.ToString() + "\\" + masterCampaignID.ToString() + ".jpg", Server.MapPath("~") + "\\Upload\\Updates\\" + ProfileID.ToString() + "\\" + updateID + ".jpg");

                        // Save User Activity Log
                        objCommon.InsertUserActivityLog("has created an update titled <b>" + txtCampName.Text + "</b> by copying <b>" + hdnUpdateTitle.Value + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);


                        string url = Page.ResolveClientUrl("~/Business/MyAccount/EditUpdate.aspx?Update_ID=" + updateID);
                        if (btnBack.Visible)
                            url = Page.ResolveClientUrl("~/Business/MyAccount/EditUpdate.aspx?Update_ID=" + updateID + "&App=1");
                        Response.Redirect(url);
                    }
                }
                else
                {
                    lbleditext.Text = "Sorry, you already have a update with this name, please enter another name.";
                    ModalPopupExtender6.Show();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "BtneditTemplate_Click", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnBackClick(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }

        protected void LnkCreateClick(object sender, EventArgs e)
        {
            try
            {
                /** This is for allowing creators only 26/06/2013**/
                string url = "";
                List<string> permissionList = new List<string>();
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    Dtpermissions = agencyobj.GetPermissionsById(Convert.ToInt32(Session["C_USER_ID"]));
                    for (int i = 0; i < Dtpermissions.Rows.Count; i++)
                    {
                        PermissionValue = Convert.ToInt32(Dtpermissions.Rows[i]["Permission_Values"].ToString());
                        if (Convert.ToBoolean(PermissionValue & Constants.UPDATES))
                        {
                            PermissionType = Dtpermissions.Rows[i]["Permission_Type"].ToString();
                            permissionList.Add(PermissionType);
                        }
                    }
                    if ((permissionList.Count == 2) || (PermissionType == "A" && permissionList.Count == 1 && permissionList[0] == "A"))
                    {
                        url = Page.ResolveClientUrl("~/Business/MyAccount/EditUpdate.aspx");
                        if (btnBack.Visible)
                            url = Page.ResolveClientUrl("~/Business/MyAccount/EditUpdate.aspx?App=1");
                        Response.Redirect(url);
                    }
                    else if (permissionList[0] == "P" && PermissionType == "P" && permissionList.Count == 1)
                    {
                        lblmess.Text = "You don't have permission to create an Update.";
                    }
                }
                else
                {
                    url = Page.ResolveClientUrl("~/Business/MyAccount/EditUpdate.aspx");
                    if (btnBack.Visible)
                        url = Page.ResolveClientUrl("~/Business/MyAccount/EditUpdate.aspx?App=1");
                    Response.Redirect(url);
                }
                permissionList.Clear();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "LnkCreateClick", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void LnkNotificationClick(object sender, EventArgs e)
        {
            Session["PushNotifyType"] = "Update," + hdnCommandArg.Value;
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SendAppNotifications.aspx"));
        }

        protected void LnkPublishClick(object sender, EventArgs e)
        {
            try
            {
                /** This is for allowing publishers only 26/06/2013**/
                List<string> permissionList = new List<string>();
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    Dtpermissions = agencyobj.GetPermissionsById(Convert.ToInt32(Session["C_USER_ID"]));
                    for (int i = 0; i < Dtpermissions.Rows.Count; i++)
                    {
                        PermissionValue = Convert.ToInt32(Dtpermissions.Rows[i]["Permission_Values"].ToString());
                        if (Convert.ToBoolean(PermissionValue & Constants.UPDATES))
                        {
                            PermissionType = Dtpermissions.Rows[i]["Permission_Type"].ToString();
                            permissionList.Add(PermissionType);
                        }
                    }
                    if (PermissionType == "A" && permissionList.Count == 1 && permissionList[0] == "A")
                    {
                        lblmess.Text = "You don't have permission to publish an Update.";
                    }
                    else if ((permissionList[0] == "P" && PermissionType == "P" && permissionList.Count == 1) || (permissionList.Count == 2))
                    {
                        if (hdnCommandArg.Value != "")
                        {
                            ShowPublishModal();
                        }
                    }
                }
                else
                {
                    if (hdnCommandArg.Value != "")
                    {
                        ShowPublishModal();
                    }
                }
                permissionList.Clear();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "LnkPublishClick", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void ShowPublishModal()
        {
            txtPublishDate.Text = objCommon.ConvertToUserTimeZone(ProfileID).ToString("MM/dd/yyyy");
            ModalPopupPublish.Show();
        }
        protected void BtnPublishClick(object sender, EventArgs e)
        {
            try
            {
                if (hdnCommandArg.Value != "")
                {
                    bool flag = false;
                    if (txtPublishDate.Text.Trim() != "")
                    {
                        DateTime dtToday = objCommon.ConvertToUserTimeZone(ProfileID);
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
                        //roles & permissions...
                        if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "" && hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value)))  // A for approve...
                        {
                            UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), false);
                            objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.UPDATE, UserID, Session["username"].ToString(), PageNames.UPDATE, DomainName);
                        }
                        else
                            UpdatePublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), true);

                        //ends here...

                        lblmess.Text = Resources.LabelMessages.PublishChange.Replace("#Type#", "update").Replace("#Status#", "published");
                        FillDatalist();
                        ModalPopupPublish.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "BtnPublishClick", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnPublishCancelClick(object sender, EventArgs e)
        {
        }

        private void UpdatePublish(bool flag, int updateId, DateTime? publishDate, bool isPublished)
        {
            objUpdate.UpdatePublishedUpdates(flag, UserID, CUserID, updateId, publishDate, isPublished);
        }

        protected void LnkUnpublishClick(object sender, EventArgs e)
        {
            if (hdnCommandArg.Value != "")
            {
                DateTime? publishDate = null;
                UpdatePublish(false, Convert.ToInt32(hdnCommandArg.Value), publishDate, false);
                lblmess.Text = Resources.LabelMessages.PublishChange.Replace("#Type#", "update").Replace("#Status#", "private");
                FillDatalist();
            }
        }
        protected void lnkCalendar_Click(object sender, EventArgs e)
        {
            int updateID = Convert.ToInt32(hdnCommandArg.Value);
            string update = EncryptDecrypt.DESEncrypt(updateID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS");
            string url = RootPath + "/OnlineUpdate.aspx?BID=" + update;

            string updateName = Convert.ToString(hdnUpdateTitle.Value);

            Response.Redirect(RootPath + "/Business/MyAccount/EventsCalendar.aspx?Name=" + updateName + "&URL=" + url);
        }

        protected void btnEditOrderNumber_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtobj = new DataTable();
                lbl2.Text = string.Empty;
                dtobj = objUpdate.GetUpdates(UserID);
                if (dtobj.Rows.Count > 0)
                {
                    OrderListView.DataSource = null;
                    OrderListView.DataSource = dtobj;
                    OrderListView.DataBind();
                    ModalPopupImgOrderNo.Show();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowOrderScript();", true);
                }
                else
                    lblmess.Text = "<font color=red face=arial size=2><b>You have no active update(s) to change the order to display.</b></font>";
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "btnEditOrderNumber_Click", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

                throw new Exception(ex.Message);
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
                        objUpdate.UpdateBusinessUpdatesOrder(Convert.ToInt32(lblKey.Text), i + 1, CUserID);
                    }
                    lblmess.Text = "<font color=green face=arial size=2><b>The order of your updates has been updated successfully.</b></font>";
                    FillDatalist();
                    ModalPopupImgOrderNo.Hide();

                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageUpdates.aspx.cs", "btnUpdateImgOrderNumber_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

                throw new Exception(ex.Message);
            }
        }

        protected void btnCancelImgOrderNumber_Click(object sender, EventArgs e)
        {

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
                if (File.Exists(Server.MapPath("~") + "\\Upload\\Updates\\" + ProfileID.ToString() + "\\" + lblKey.Text + ".jpg"))
                    lblOrderThumb.Text = "<img src='" + RootPath + "/Upload/Updates/" + ProfileID.ToString() + "/" + lblKey.Text + ".jpg?Guid=" + ImageDisID + "' border='1' width='50' height='20'/>";
                else
                    lblOrderThumb.Text = "";
            }
        }

        [WebMethod]
        public static string UpdateItemsOrder(string itemOrder)
        {
            string _result = "failed";
            try
            {
                BusinessUpdatesBLL objUpdate = new BusinessUpdatesBLL();
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
                            objUpdate.UpdateBusinessUpdatesOrder(Convert.ToInt32(strBulletinOrder[i]), i + 1, CUserID);
                        }
                    }

                }
                _result = "success";
            }
            catch (Exception /*ex*/)
            { }
            return _result;
        }
    }
}