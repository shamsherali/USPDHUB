using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.IO;
using Winnovative.PdfCreator;
using System.Configuration;
using AjaxControlToolkit;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.Services;
using System.Xml;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageSurvey : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;

        public string Mailtourlinfo = string.Empty;
        public string linkedInurlinfo = string.Empty;
        public string FacebookInurlinfo = string.Empty;
        public string Twitterurlinfo = string.Empty;
        public string RootPath = "";
        public string DomainName = "";
        public int SortDir = 0;

        BusinessBLL objBus = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        SurveyBLL objSurveyBLL = new SurveyBLL();
        USPDHUBBLL.MobileAppSettings objApp = new USPDHUBBLL.MobileAppSettings();

        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        public string titleName = "";

        DataTable dtSurveys = new DataTable();
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
            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            C_UserID = UserID;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
            lblmess.Text = "";
            lblerrormessage.Text = "";

            titleName = objApp.GetMobileAppSettingTabName(UserID, "Surveys", DomainName);
            lblTitle.Text = titleName;
            /*** Store Module Functionality ***/
            if (objBus.CheckModulePermission(WebConstants.Purchase_ScheduleEmailsSetup, ProfileID))
            {
                IsScheduleEmails = true;
            }
            if (!IsPostBack)
            {
                lblOff.Visible = true;
                if (objCommon.DisplayOn_OffSettingsContent(UserID, WebConstants.Tab_SurveySetup))
                {
                    lblOn.Visible = true;
                    lblOff.Visible = false;
                }
                RBAppOrder.SelectedValue = objCommon.DisplayOrderType(UserID, "Surveys");

                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Surveys");
                    if (string.IsNullOrEmpty(hdnPermissionType.Value))
                    {
                        UpdatePanel2.Visible = true;
                        UpdatePanel1.Visible = false;
                        lblerrormessage.Text = "<font face=arial size=2>You do not have permission to manage surveys.</font>";
                    }
                }
                //ends here

                //  Hdn control for Sorting
                hdnsortdire.Value = "";
                hdnsortcount.Value = "0";

                GetManageSurveys();
                if (Session["SurveySuccess"] != null)
                {
                    lblmess.Text = Session["SurveySuccess"].ToString();
                    Session.Remove("SurveySuccess");
                    Session.Remove("CurrentQuestionNumber");
                    Session.Remove("SurveyID");
                    Session.Remove("QID");
                }
                if (Session["BulletinSuccess"] != null)
                {
                    lblmess.Text = Session["BulletinSuccess"].ToString();
                    Session.Remove("BulletinSuccess");
                }
            }
            ddlPageSize = (DropDownList)PageSizes.FindControl("ddlPageSize");
            ddlPageSize.AutoPostBack = true;
            ddlPageSize.SelectedIndexChanged += ddlPageSize_SelectedIndexChanged;
        }

        private void GetManageSurveys()
        {
            hdnCommandArg.Value = "";
            dtSurveys = objSurveyBLL.GetManageSurveys(Convert.ToInt32(Session["ProfileID"]));
            Session["dtSurveys"] = dtSurveys;
            hdnShowButtons.Value = "1";

            if (dtSurveys.Rows.Count == 0)
                hdnShowButtons.Value = "";

            dtSurveys = RemoveArchive(dtSurveys, hdnarchive.Value);
            if (hdnarchive.Value == "Archive")
            {
                GrdSurveys.Columns[1].Visible = true;
                GrdSurveys.Columns[0].Visible = false;
            }
            else
            {
                GrdSurveys.Columns[1].Visible = false;
                GrdSurveys.Columns[0].Visible = true;
            }
            GetSavedUserData();
            GrdSurveys.PageSize = GetPageSize();
            GrdSurveys.DataSource = dtSurveys;
            GrdSurveys.DataBind();

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
            lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>";
            lnkCurrent.Text = "<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>";
            hdnCommandArg.Value = "";
            hdnRowIndex.Value = "";
            hdnarchive.Value = "NoArchive";
            Session["ViewBGrid"] = null;
            //ShowCurrentArchive();
            GetManageSurveys();
        }
        protected void lnkGetArchive_Click(object sender, EventArgs e)
        {
            lnkGetArchive.Text = "<img src='../../Images/Dashboard/archive.gif' title='Archive' border='0'/>";
            lnkCurrent.Text = "<img src='../../Images/Dashboard/current.gif' title='Current' border='0'/>";
            hdnCommandArg.Value = "";
            hdnRowIndex.Value = "";
            hdnarchive.Value = "Archive";
            Session["ViewBGrid"] = "Archive";
            //ShowCurrentArchive();
            GetManageSurveys();
        }
        protected void GrdSurveys_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //LinkButton lnkcam = e.Row.FindControl("lnkruncampaion") as LinkButton;
                PopupControlExtender pce = e.Row.FindControl("PopupControlExtender1") as PopupControlExtender;

                string behaviorID = "pce_" + e.Row.RowIndex;
                pce.BehaviorID = behaviorID;

                Image img = (Image)e.Row.FindControl("Image1");

                string OnMouseOverScript = string.Format("$find('{0}').showPopup();", behaviorID);
                string OnMouseOutScript = string.Format("$find('{0}').hidePopup();", behaviorID);

                img.Attributes.Add("onmouseover", OnMouseOverScript);
                img.Attributes.Add("onmouseout", OnMouseOutScript);
                Label lblDisplay = e.Row.FindControl("lblDisplay") as Label;
                if (lblDisplay.Text != "Published")
                    img.Visible = false;
                Label lblApprovalStatus = e.Row.FindControl("lblApprovalStatus") as Label;
                if (lblApprovalStatus.Text.ToLower().Contains(Convert.ToString(Resources.ValidationValues.CheckScheduledPublish)))
                    lblApprovalStatus.CssClass = "schedulepublish";
                else
                    lblApprovalStatus.CssClass = "scheduleunpublish";
            }
        }
        protected void GrdSurveys_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtSurveys = (DataTable)Session["dtSurveys"];
            GrdSurveys.PageIndex = e.NewPageIndex;
            GrdSurveys.DataSource = dtSurveys;
            GrdSurveys.DataBind();
        }
        protected void GrdSurveys_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDir = Convert.ToInt32(hdnsortcount.Value);
            string SortExp = e.SortExpression.ToString();
            dtSurveys = (DataTable)Session["dtSurveys"];
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
            DataView Dv = new DataView(dtSurveys);
            if (SortDir == 0)
            {
                if (SortExp == "Name")
                {
                    Dv.Sort = "Name desc";
                }
                else if (SortExp == "Type_Name")
                {
                    Dv.Sort = "Type_Name desc";
                }
                else if (SortExp == "Expiration_Date")
                {
                    Dv.Sort = "Expiration_Date desc";
                }
                else if (SortExp == "IsDisplay")
                {
                    Dv.Sort = "IsDisplay desc";
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
                    Dv.Sort = "Name ASC";
                }
                else if (SortExp == "Type_Name")
                {
                    Dv.Sort = "Type_Name ASC";
                }
                else if (SortExp == "Expiration_Date")
                {
                    Dv.Sort = "Expiration_Date ASC";
                }
                else if (SortExp == "IsDisplay")
                {
                    Dv.Sort = "IsDisplay ASC";
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
            Session["dtSurveys"] = Dv.ToTable();
            GrdSurveys.DataSource = Dv;
            GrdSurveys.DataBind();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
        protected void rbSurvey_CheckedChanged(object sender, EventArgs e)
        {
            hdnIsPusblished.Value = "";
            trUnPublish.Visible = true;
            trPublish.Visible = true;
            CheckBox rb = (CheckBox)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            LinkButton lnkTitle = (LinkButton)row.FindControl("lnkName");
            Label lblStatus = (Label)row.FindControl("lblStatus");
            hdnCommandArg.Value = lnkTitle.CommandArgument;
            hdnRowIndex.Value = row.RowIndex.ToString();
            hdnSName.Value = lnkTitle.Text;

            // Selected Checkbox details for Preview, Edit, Copy, Send Mail
            foreach (GridViewRow row1 in GrdSurveys.Rows)
            {
                if (((CheckBox)row1.FindControl("chkCurrentTabSurveyID")).Checked)
                {
                    hdnCommandArg.Value = (((LinkButton)row1.FindControl("lnkName")).CommandArgument);
                    lnkTitle = (((LinkButton)row1.FindControl("lnkName")));
                    hdnRowIndex.Value = row1.RowIndex.ToString();
                    hdnSName.Value = lnkTitle.Text;
                    lblStatus = (Label)row1.FindControl("lblStatus");
                    break;
                }
            }

            //***For getting count of Answered Question.***//
            hdnParticipation.Value = objSurveyBLL.GetSurveyAnswersCount(Convert.ToInt32(hdnCommandArg.Value)).ToString();
            //************************************************//
            /** This is for allowing creators only 26/06/2013**/
            
            if (lblStatus.Text == "True")
                hdnIsPusblished.Value = "true";
            //Getting Survey Type
            Label lblSurveyType = (Label)row.FindControl("lblSurveyType");
            hdnSurveyType.Value = lblSurveyType.Text;

            var expiryDate = Convert.ToString(GrdSurveys.DataKeys[Convert.ToInt32(row.RowIndex)].Values["Expiration_Date"].ToString());
            if (expiryDate != string.Empty)
            {
                if (Convert.ToDateTime(expiryDate) < DateTime.Now)
                {
                    trUnPublish.Visible = false;
                    trPublish.Visible = false;
                }
            }
        }
        protected void lnkCreate_Click(object sender, EventArgs e)
        {
            /** This is for allowing creators only 26/06/2013**/
            List<string> PermissionList = new List<string>();
            string authorPermission = string.Empty;
            string pubPermission = string.Empty;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                for (int i = 0; i < dtpermissions.Rows.Count; i++)
                {
                    if (dtpermissions.Rows[i]["ButtonType"].ToString() == "Surveys")
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
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SurveyEntry.aspx"));
                }
                else //if (PermissionList[0] == "P" && Permission_Type == "P" && PermissionList.Count == 1)
                {
                    lblmess.Text = "You don't have permission to create Survey.";
                }
            }
            else
            {
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SurveyEntry.aspx"));
            }
            PermissionList.Clear();
        }
        protected void lnkName_Click(object sender, EventArgs e)
        {
            LinkButton lnkTitle = sender as LinkButton;
            ShowPreview(lnkTitle.CommandArgument, lnkTitle.Text);
        }
        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            if (hdnCommandArg.Value != "")
            {
                ShowPreview(hdnCommandArg.Value, hdnSName.Value);
            }
        }
        private void ShowPreview(string SurveyID, string name)
        {
            string previewHtml = objCommon.BuildSurveyPreview(Convert.ToInt32(SurveyID));
            //previewHtml = objCommon.ReplaceShortURltoHtmlString(previewHtml);
            lblPreviewHTML.Text = previewHtml;
            lblupdatename.Text = name;
            ModalPopupExtender2.Show();
        }
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            /** This is for allowing creators only 26/06/2013**/
            List<string> PermissionList = new List<string>();
            string authorPermission = string.Empty;
            string pubPermission = string.Empty;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                for (int i = 0; i < dtpermissions.Rows.Count; i++)
                {
                    if (dtpermissions.Rows[i]["ButtonType"].ToString() == "Surveys")
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
                    if (hdnParticipation.Value == "0")
                    {
                        if (hdnCommandArg.Value != "")
                        {
                            string RedirectUrl = string.Empty;
                            RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/SurveyEntry.aspx?SurveyID=" + EncryptDecrypt.DESEncrypt(hdnCommandArg.Value));
                            Response.Redirect(RedirectUrl);
                        }

                    }
                    else
                    {
                        lblmess.Text = "<font face=arial size=2>Participation in progress. Alternatively, create a copy.</font>";
                    }
                }
                else //if (PermissionList[0] == "P" && Permission_Type == "P" && PermissionList.Count == 1)
                {
                    lblmess.Text = "You don't have permission to edit Bulletin.";
                }
            }
            else
            {
                if (hdnParticipation.Value == "0")
                {
                    if (hdnCommandArg.Value != "")
                    {
                        string RedirectUrl = string.Empty;
                        RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/SurveyEntry.aspx?SurveyID=" + EncryptDecrypt.DESEncrypt(hdnCommandArg.Value));
                        Response.Redirect(RedirectUrl);
                    }
                }
                else
                {
                    lblmess.Text = "<font face=arial size=2>Participation in progress. Alternatively, create a <a href='javascript:void(0)' style='color:blue;' onclick = 'return Showpopup()' >copy</a>.</font>";
                }
            }
            PermissionList.Clear();
        }
        protected void lnkCopy_Click(object sender, EventArgs e)
        {
            lbleditext.Text = "";
            txtCampName.Text = "";
            if (hdnCommandArg.Value != "")
            {
                int masterCampaignID = Convert.ToInt32(hdnCommandArg.Value);
                ModalPopupExtender6.Show();
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
                DataTable dtSurvey = objSurveyBLL.GetSurveyDetailsByID(Convert.ToInt32(hdnCommandArg.Value));
                if (dtSurvey.Rows.Count > 0)
                {
                    lblExisting.Text = Convert.ToString(dtSurvey.Rows[0]["Name"]);
                }
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
                    objBulletin.RenameContent(Convert.ToInt32(hdnCommandArg.Value), txtNewName.Text.Trim(), C_UserID, "Surveys",ProfileID);
                    // *** Silent PushNotification  *** //
                    objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, Convert.ToInt32(hdnCommandArg.Value), "Surveys", "Rename");
                    lblmess.Text = "<font color='Green' size='3'>" + Resources.LabelMessages.RenameSuccess.Replace("#ExistingContentName#", lblExisting.Text.Trim()).Replace("#NewContentName#", txtNewName.Text.Trim()) + "</font>";
                    GetManageSurveys();
                    modalRename.Hide();
                }
            }
            catch (Exception ex)
            {
                lblRenameMsg.Text = "<font color='red' size='3'>" + ex.Message.ToString() + "</font>";
            }
        }
        protected void lnkdelete_Click(object sender, EventArgs e)
        {

            if (hdnarchive.Value != "Archive")
            {
                foreach (GridViewRow row1 in GrdSurveys.Rows)
                {
                    if (((CheckBox)row1.FindControl("chkCurrentTabSurveyID")).Checked)
                    {
                        hdnCommandArg.Value = (((LinkButton)row1.FindControl("lnkName")).CommandArgument);
                        objSurveyBLL.DeleteSurvey(Convert.ToInt32(hdnCommandArg.Value));
                    }
                }
            }
            else
            {
                foreach (GridViewRow row1 in GrdSurveys.Rows)
                {
                    if (((CheckBox)row1.FindControl("chkSurveyID")).Checked)
                    {
                        hdnCommandArg.Value = (((LinkButton)row1.FindControl("lnkName")).CommandArgument);
                        objSurveyBLL.DeleteSurvey(Convert.ToInt32(hdnCommandArg.Value));
                    }
                }
            }
            hdnCommandArg.Value = "";
            GetManageSurveys();
            lblmess.Text = "<font size='3'>Your selected " + hdnSurveyType.Value.ToLower() + "(s) has been deleted successfully.</font>";
        }
        protected void lnkReports_Click(object sender, EventArgs e)
        {
            int sID = Convert.ToInt32(hdnCommandArg.Value);
            string ReportHTML = "";
            // Generate Report
            DataTable dtQuestion = objSurveyBLL.GetQuestionsBySurveyID(sID);
            if (dtQuestion.Rows.Count > 0)
            {
                //getting Report HTML
                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\Upload\\ReportsHTML\\";
                //Survey nam Header
                StreamReader re = File.OpenText(strfilepath + "SurveyReport2.htm");
                string htmlStr = string.Empty;
                string content = string.Empty;
                while ((content = re.ReadLine()) != null)
                {
                    htmlStr = htmlStr + content;
                }
                re.Close();
                re.Dispose();
                // Child Table
                string strfilepath2 = HttpContext.Current.Server.MapPath("~") + "\\Upload\\ReportsHTML\\";
                StreamReader re2 = File.OpenText(strfilepath2 + "SurveyReport1.htm");
                string htmlStr2 = string.Empty;
                string content2 = string.Empty;
                while ((content2 = re2.ReadLine()) != null)
                {
                    htmlStr2 = htmlStr2 + content2;
                }
                re2.Close();
                re2.Dispose();
                //int answersSkipCount = objSurveyBLL.GetAnswersSkipCount(sID);
                DataTable dtAnswerSkips = objSurveyBLL.GetAnswersSkipCount(sID);
                int answersSkipCount = 0;
                if (dtAnswerSkips.Rows.Count > 0)
                {
                    answersSkipCount = Convert.ToInt32(dtAnswerSkips.Rows[0]["TotalUsersCount"]);
                }

                // 1: Checkboxes
                // 2: Radio Buttons
                // 3: Free TextBoxes
                for (int i = 0; i < dtQuestion.Rows.Count; i++)
                {
                    var subHTML = "";
                    if (Convert.ToString(dtQuestion.Rows[i]["Type_NameNumber"]) == "3")
                    {
                        subHTML = htmlStr;

                        subHTML = subHTML.Replace("#SURVEY_NAME#", hdnSName.Value);
                        subHTML = subHTML.Replace("#QUESTION_NO#", "Q" + (i + 1));
                        subHTML = subHTML.Replace("#QUESTION_NAME#", Convert.ToString(dtQuestion.Rows[i]["Text"]));
                        //Get Correct ANswers by QID (Responses)
                        DataTable dtAnswers = objSurveyBLL.GetSurveyAnswersByQID(Convert.ToInt32(dtQuestion.Rows[i]["Question_ID"]));
                        subHTML = subHTML.Replace("#ANSWER_COUNT#", "Answered: " + dtAnswers.Rows.Count + "&nbsp; Skipped: " + (answersSkipCount - dtAnswers.Rows.Count));
                        subHTML = subHTML.Replace("#REPORT_IMAGE#", "");
                        if (dtAnswers.Rows.Count > 0)
                        {
                            string AnswersString = @"<table width='100%' border='0' cellpadding='3' cellspacing='0' style='font-size: 12px; border-top: solid 2 #C5C5C5; border-bottom: solid 2 #C5C5C5;'>
                                                     <colgroup>
                                                       <col width='7%' />
                                                       <col width='*' />
                                                       <col width='25%' />
                                                    </colgroup>
                            <tr style='background-color: #EAEAE8; font-weight: bold; height:30px;'>
                            <td style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5;'>
                                #
                            </td>
                            <td style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5;'>
                                Responses
                            </td>
                            <td  style='text-align: left; padding-left: 5px;'>
                                Date
                            </td>
                            </tr>";

                            var rows = "";
                            for (int j = 0; j < dtAnswers.Rows.Count; j++)
                            {
                                rows = rows + @"<tr>
                                                    <td style='text-align: left; padding-left: 5px; border-right: solid 2# C5C5C5; border-top: solid 2 #C5C5C5; font-size: 11px;'>
                                                        " + (j + 1) + @"
                                                    </td>
                                                    <td style='text-align: left; padding-left: 5px; border-right: solid 2# C5C5C5; border-top: solid 2 #C5C5C5; font-size: 11px;'>
                                                        " + Convert.ToString(dtAnswers.Rows[j]["Answer"]) + @"
                                                    </td>
                                                    <td style='text-align: left; padding-left: 5px; border-top: solid 2 #D0C6B1; font-size: 11px;'>
                                                        " + Convert.ToString(dtAnswers.Rows[j]["Created_Date"]) + @"
                                                    </td>
                                                </tr>";
                            }
                            AnswersString = AnswersString + rows + "</table>";
                            subHTML = subHTML.Replace("#ANSWERS#", AnswersString);
                        }
                        else
                        {
                            subHTML = subHTML.Replace("#ANSWERS#", "");
                        }
                    }
                    else if (Convert.ToString(dtQuestion.Rows[i]["Type_NameNumber"]) == "2")
                    {
                        subHTML = htmlStr;

                        subHTML = subHTML.Replace("#SURVEY_NAME#", hdnSName.Value);
                        subHTML = subHTML.Replace("#QUESTION_NO#", "Q" + (i + 1));
                        subHTML = subHTML.Replace("#QUESTION_NAME#", Convert.ToString(dtQuestion.Rows[i]["Text"]));

                        //Get Correct ANswers by QID (Responses)
                        DataTable dtOptions = objSurveyBLL.GetQuestionOptionsByQID(Convert.ToInt32(dtQuestion.Rows[i]["Question_ID"]));
                        DataTable mainANswers = objSurveyBLL.GetSurveyAnswersByQID(Convert.ToInt32(dtQuestion.Rows[i]["Question_ID"]));

                        subHTML = subHTML.Replace("#ANSWER_COUNT#", "Answered: " + mainANswers.Rows.Count + "&nbsp; Skipped: " + (answersSkipCount - mainANswers.Rows.Count));

                        string[] xAxis = new string[dtOptions.Rows.Count];
                        int[] yAxis = new int[dtOptions.Rows.Count];

                        if (mainANswers.Rows.Count > 0)
                        {
                            var row = "";
                            for (int j = 0; j < dtOptions.Rows.Count; j++)
                            {
                                DataTable dtAnswers = objSurveyBLL.GetAnswersByOptionID(Convert.ToInt32(dtOptions.Rows[j]["Option_ID"]));
                                xAxis[j] = Convert.ToString(dtOptions.Rows[j]["Answer_Option"]);
                                var value = dtAnswers.Rows.Count * 100 / answersSkipCount;
                                if (value == 66)
                                { value = 67; }
                                yAxis[j] = value;
                                row = row + @"<tr>
                                                    <td style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5; border-top: solid 2 #D0C6B1; font-size: 11px;'>
                                                        " + Convert.ToString(dtOptions.Rows[j]["Answer_Option"]) + @"
                                                    </td>
                                                    <td style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5; border-top: solid 2 #D0C6B1; font-size: 11px;'>
                                                        " + value + @"%
                                                    </td>
                                                    <td  style='text-align: left; padding-left: 5px; border-top: solid 2 #C5C5C5;'>
                                                        " + dtAnswers.Rows.Count + @"
                                                    </td>
                                                </tr>";
                            }
                            #region Save Report as Img

                            // Save Image
                            Chart1.Series["Legend"].Points.DataBindXY(xAxis, yAxis);
                            Chart1.Series["Legend"].Points[0].Color = System.Drawing.Color.LightBlue;
                            Chart1.Series["Legend"].Points[1].Color = System.Drawing.Color.LightYellow;
                            // Export FileName
                            string imgName = sID + "" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + ""
                + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".jpg";
                            string imgFullPath = Server.MapPath("~/Upload/ReportsHTML/") + imgName;
                            // Save image.
                            Chart1.SaveImage(imgFullPath, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Jpeg);

                            #endregion

                            string radioButtonHTML = @"<table width='100%' border='0' cellpadding='3' cellspacing='0' style='font-size: 12px; border-top: solid 2 #C5C5C5; border-bottom: solid 2 #C5C5C5;'>
                                                            <colgroup>
                                                            <col width='40%' />
                                                            <col width='*' />
                                                            <col width='20%' />
                                                            </colgroup>
                                                        <tr style='background-color: #EAEAE8; font-weight: bold; height:30px;'>
                                                            <td  style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5;'>
                                                                Answer Choices
                                                            </td>
                                                            <td  style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5;'>
                                                                Responses
                                                            </td>
                                                            <td style='text-align: left; padding-left: 5px;'>
                                                            </td>
                                                        </tr>" + row + @"<tr style='background-color: #EAEAE8; font-weight: bold; height:30px;'>
                                                            <td  style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5; border-top: solid 2 #C5C5C5; font-size: 11px;'>
                                                                Total
                                                            </td>
                                                            <td  style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5; border-top: solid 2 #C5C5C5; font-size: 11px;'>
                                                            &nbsp;
                                                            </td>
                                                            <td style='text-align: left; padding-left: 5px; border-top: solid 2 #C5C5C5;'>
                                                                " + answersSkipCount + @"
                                                            </td>
                                                        </tr>
                                                    </table>";

                            #region Getting Rooth Path

                            string RootPath = "";
                            string verticalCode = USPDHUBDAL.MServiceDAL.GetVerticalNameByProfileID(Convert.ToInt32(Session["ProfileID"]));
                            DataTable dtProfileDetails = USPDHUBDAL.BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(Session["ProfileID"]));
                            string countryName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);
                            string domain = objCommon.GetDomainNameByCountryVertical(verticalCode, countryName.Trim());
                            DataTable dtConfigs = objCommon.GetVerticalConfigsByType(domain, "Paths");
                            if (dtConfigs.Rows.Count > 0)
                            {
                                for (int k = 0; k < dtConfigs.Rows.Count; k++)
                                {
                                    if (Convert.ToString(dtConfigs.Rows[k]["Name"]).ToLower() == "RootPath".ToLower())
                                    {
                                        RootPath = Convert.ToString(dtConfigs.Rows[k]["Value"]).Trim();
                                        break;
                                    }
                                }
                            }
                            #endregion

                            string reportImgTag = "<img src='" + RootPath + "/Upload/ReportsHTML/" + imgName + "' />";
                            subHTML = subHTML.Replace("#REPORT_IMAGE#", reportImgTag);
                            //subHTML = subHTML.Replace("#REPORT_IMAGE#", "");
                            subHTML = subHTML.Replace("#ANSWERS#", radioButtonHTML);
                        }
                        else
                        {
                            subHTML = subHTML.Replace("#ANSWERS#", "");
                            subHTML = subHTML.Replace("#REPORT_IMAGE#", "");
                        }

                    }
                    else if (Convert.ToString(dtQuestion.Rows[i]["Type_NameNumber"]) == "1")
                    {
                        subHTML = htmlStr;

                        subHTML = subHTML.Replace("#SURVEY_NAME#", hdnSName.Value);
                        subHTML = subHTML.Replace("#QUESTION_NO#", "Q" + (i + 1));
                        subHTML = subHTML.Replace("#QUESTION_NAME#", Convert.ToString(dtQuestion.Rows[i]["Text"]));
                        //Get Correct ANswers by QID (Responses)
                        DataTable dtAnswers = objSurveyBLL.GetSurveyAnswersByQID(Convert.ToInt32(dtQuestion.Rows[i]["Question_ID"]), "CheckBoxes");
                        subHTML = subHTML.Replace("#ANSWER_COUNT#", "Answered: " + dtAnswers.Rows.Count + "&nbsp; Skipped: " + (answersSkipCount - dtAnswers.Rows.Count));
                        subHTML = subHTML.Replace("#REPORT_IMAGE#", "");
                        if (dtAnswers.Rows.Count > 0)
                        {
                            var row = "";
                            for (int k = 0; k < dtAnswers.Rows.Count; k++)
                            {
                                row = row + "<tr><td style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5; border-top: solid 2 #C5C5C5;'>" + Convert.ToString(dtAnswers.Rows[k]["Answer"]) + "</td><td style='text-align: left; padding-left: 5px; border-top: solid 2 #C5C5C5;'>" + Convert.ToString(dtAnswers.Rows[k]["Created_Date"]) + "</td></tr>";
                            }
                            string checkboxesHTML = @"<table width='100%' border='0' cellpadding='3' cellspacing='0' style='font-size: 12px; border-top: solid 2 #C5C5C5; border-bottom: solid 2 #C5C5C5;'>
                                                            <colgroup>
                                                            <col width='75%' />
                                                            <col width='25%' /> 
                                                            </colgroup>
                                                        <tr style='background-color: #EAEAE8; font-weight: bold; height:30px;'>
                                                            <td style='text-align: left; padding-left: 5px; border-right: solid 2 #C5C5C5;'>
                                                                Answers
                                                            </td>
                                                            <td  style='text-align: left; padding-left: 5px;'>
                                                                Date
                                                            </td>
                                                        </tr>" + row + @"
                                                    </table>";
                            subHTML = subHTML.Replace("#ANSWERS#", checkboxesHTML);
                        }
                        else
                        {
                            subHTML = subHTML.Replace("#ANSWERS#", "");
                        }
                    }

                    // Total Question Append
                    ReportHTML = ReportHTML + "" + subHTML;
                }
                ReportHTML = htmlStr2.Replace("#SURVEY_NAME#", hdnSName.Value) + "" + ReportHTML;
                ReportHTML = ReportHTML.Replace("<br>", "");
                // ReportHTML = @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head></head><body>" + ReportHTML + "</body></html>";
                //
                GenerateHTMLtoPDF(ReportHTML, sID.ToString());
            }

            // Generate PDF Based Report HTML String
        }
        protected void lnkSurveyReport_Click(object sender, EventArgs e)
        {
            int surveyAnsCount = objSurveyBLL.GetSurveyAnswersCount(Convert.ToInt32(hdnCommandArg.Value));
            if (surveyAnsCount > 0)
            {
                string url = Page.ResolveClientUrl("~/Business/MyAccount/SurveyReport.aspx?SurveyID=" + EncryptDecrypt.DESEncrypt(hdnCommandArg.Value));
                Response.Redirect(url);
            }
            else
                lblerrormessage.Text = Resources.LabelMessages.ReportError.Replace("survey", hdnSurveyType.Value.ToLower()); ;
        }
        private void GenerateHTMLtoPDF(string reportHTML, string surveyID)
        {
            /*
            //set the license key
            LicensingManager.LicenseKey = ConfigurationManager.AppSettings.Get("pdfkeyval");

            //create a PDF document
            Document document = new Document();
            document.CompressionLevel = CompressionLevel.NormalCompression;
            document.Margins = new Margins(10, 10, 0, 0);
            document.Security.CanPrint = true;
            document.Security.UserPassword = "";
            document.DocumentInformation.Author = "Logictree IT Solutions, Inc";
            document.ViewerPreferences.HideToolbar = false;

            //PageSize.A4, new Margins(0, 0, 0, 0), PageOrientation.Portrait
            PdfPage page = document.Pages.AddNewPage(PageSize.A4, new Margins(0, 0, 0, 0), PageOrientation.Portrait);
            PdfFont font = document.Fonts.Add(new System.Drawing.Font(new System.Drawing.FontFamily("Arial"), 14, System.Drawing.GraphicsUnit.Point));
            AddElementResult addResult;

            float xLocation = 5;
            float yLocation = 5;
            float width = -1;
            float height = -1;

            // convert HTML to PDF
            HtmlToPdfElement htmlToPdfElement;

            htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, width, height, reportHTML.ToString(), null);
            string pdfilenameval = hdnSName.Value.ToString() + "_" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + ""
                + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".pdf"; ;
            // add theHTML to PDF converter element to page
            htmlToPdfElement.HtmlViewerWidth = 793;
            addResult = page.AddElement(htmlToPdfElement);
            string savelocation = Server.MapPath("~/Upload/").ToString() + pdfilenameval;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            document.Save(Response, false, pdfilenameval);

            string VirtualPath = savelocation;
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + pdfilenameval);
            Response.TransmitFile(VirtualPath);
            */

            objCommon.HtmlToPDF_Print(reportHTML.ToString(), hdnSName.Value.ToString(), "", true);
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void ImcloseClick(object sender, ImageClickEventArgs e)
        {

        }
        protected void btnCopyContinue_Click(object sender, EventArgs e)
        {
            if (hdnCommandArg.Value != "")
            {
                int newSurveyID = objSurveyBLL.CopySurvey(UserID, C_UserID, Convert.ToInt32(hdnCommandArg.Value), txtCampName.Text.Trim());
                if (newSurveyID > 0)
                {
                    /*int SurveyID = Convert.ToInt32(hdnCommandArg.Value);
                    //int InsertedSurveyID = objSurveyBLL.Copy_Survey(UserID, SurveyID, txtCampName.Text);
                    DataTable dtQuestions = objSurveyBLL.CopySurveyQuestions(SurveyID, newSurveyID);
                    DataTable dtQuestion = objSurveyBLL.GetQuestionsBySurveyID(SurveyID);
                    for (int i = 0; i < dtQuestions.Rows.Count; i++)
                    {
                        int QuestionID = Convert.ToInt32(dtQuestion.Rows[i]["Question_ID"].ToString());
                        int CopyQuestionID = Convert.ToInt32(dtQuestions.Rows[i]["Question_ID"].ToString());
                        objSurveyBLL.CopySurveyQuestionsOptions(UserID, newSurveyID, SurveyID, QuestionID, CopyQuestionID);
                    }*/
                    string url = Page.ResolveClientUrl("~/Business/MyAccount/SurveyEntry.aspx?SurveyID=" + EncryptDecrypt.DESEncrypt(newSurveyID.ToString()));
                    Response.Redirect(url);
                }
                else
                {
                    lbleditext.Text = "Sorry, you already have a " + hdnSurveyType.Value.ToLower() + " with this name; please enter another name.";
                    ModalPopupExtender6.Show();
                }
            }
        }
        protected void lnkPublish_Click(object sender, EventArgs e)
        {
            /** This is for allowing publishers only 26/06/2013**/
            List<string> PermissionList = new List<string>();
            string authorPermission = string.Empty;
            string pubPermission = string.Empty;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                dtpermissions = agencyobj.GetPermissionsByAssociateId(Convert.ToInt32(Session["C_USER_ID"]));
                for (int i = 0; i < dtpermissions.Rows.Count; i++)
                {
                    if (dtpermissions.Rows[i]["ButtonType"].ToString() == "Surveys")
                    {
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                            authorPermission = "A";
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                            pubPermission = "P";
                        break;
                    }
                }
                if ((pubPermission == "P") || (authorPermission == "A" && pubPermission == "P") && hdnCommandArg.Value != "")
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
                            foreach (GridViewRow row1 in GrdSurveys.Rows)
                            {
                                if (((CheckBox)row1.FindControl("chkCurrentTabSurveyID")).Checked)
                                {
                                    hdnCommandArg.Value = (((LinkButton)row1.FindControl("lnkName")).CommandArgument);
                                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "" && hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //roles & permissions...
                                    {
                                        SurveyPublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), false);
                                        objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.SURVEY, UserID, Session["username"].ToString(), PageNames.SURVEY, DomainName);
                                    }
                                    else
                                        SurveyPublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), true);
                                }
                            }
                            hdnCommandArg.Value = "";
                            //ends here...

                            lblmess.Text = Resources.LabelMessages.PublishStatusChange.Replace("#Type#", "survey").Replace("#Status#", "published");
                            GetManageSurveys();
                        }
                    }
                }
                else
                    lblmess.Text = "You don't have permission to publish survey.";
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
                        foreach (GridViewRow row1 in GrdSurveys.Rows)
                        {
                            if (((CheckBox)row1.FindControl("chkCurrentTabSurveyID")).Checked)
                            {
                                hdnCommandArg.Value = (((LinkButton)row1.FindControl("lnkName")).CommandArgument);
                                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "" && hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //roles & permissions...
                                {
                                    SurveyPublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), false);
                                    objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.SURVEY, UserID, Session["username"].ToString(), PageNames.SURVEY, DomainName);
                                }
                                else
                                    SurveyPublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), true);
                            }
                        }
                        hdnCommandArg.Value = "";
                        //ends here...

                        lblmess.Text = Resources.LabelMessages.PublishStatusChange.Replace("#Type#", "survey").Replace("#Status#", "published");
                        GetManageSurveys();
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
            if (txtPublishDate.Text.Trim() != "")
            {
                DateTime? datePublish = Convert.ToDateTime(txtPublishDate.Text.Trim());
                if (DateTime.Compare(Convert.ToDateTime(txtPublishDate.Text.Trim()), DateTime.Today) < 0)
                {
                    lblPublishError.Text = "<font size='2' color='red'>" + Resources.LabelMessages.PublishDateAlert + "</font>";
                    ModalPopupPublish.Show();
                }
                else
                    flag = true;
            }

            if (flag)
            {
                foreach (GridViewRow row1 in GrdSurveys.Rows)
                {
                    if (((CheckBox)row1.FindControl("chkCurrentTabSurveyID")).Checked)
                    {
                        hdnCommandArg.Value = (((LinkButton)row1.FindControl("lnkName")).CommandArgument);
                        if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "" && hdnPermissionType.Value == "A" && (!string.IsNullOrEmpty(hdnPermissionType.Value))) //roles & permissions...
                        {
                            SurveyPublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), false);
                            objCommon.SendAuthorNotifications(Session["C_USER_NAME"].ToString(), Convert.ToInt32(hdnCommandArg.Value), PageNames.SURVEY, UserID, Session["username"].ToString(), PageNames.SURVEY, DomainName);
                        }
                        else
                            SurveyPublish(true, Convert.ToInt32(hdnCommandArg.Value), Convert.ToDateTime(txtPublishDate.Text), true);
                    }
                }
                hdnCommandArg.Value = "";
                //ends here...

                lblmess.Text = Resources.LabelMessages.PublishStatusChange.Replace("#Type#", "survey").Replace("#Status#", "published");
                GetManageSurveys();
                ModalPopupPublish.Hide();
            }

        }
        protected void btnPublishCancel_Click(object sender, EventArgs e)
        {
        }
        protected void lnkUnpublish_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow row1 in GrdSurveys.Rows)
            {
                if (((CheckBox)row1.FindControl("chkCurrentTabSurveyID")).Checked)
                {
                    hdnCommandArg.Value = (((LinkButton)row1.FindControl("lnkName")).CommandArgument);
                    DateTime? PublishDate = null;
                    SurveyPublish(false, Convert.ToInt32(hdnCommandArg.Value), PublishDate, false);
                }
            }

            hdnCommandArg.Value = "";
            lblmess.Text = Resources.LabelMessages.PublishChange.Replace("#Type#", hdnSurveyType.Value.ToLower()).Replace("#Status#", "private");
            GetManageSurveys();

        }
        private void SurveyPublish(bool flag, int sID, DateTime? publishDate, bool isPublished)
        {
            objSurveyBLL.SurveyPublish_Unpublish(flag, UserID, C_UserID, sID, publishDate, isPublished);

        }
        protected void lnkNotification_Click(object sender, EventArgs e)
        {
            Session["PushNotifyType"] = "Survey," + hdnCommandArg.Value;
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SendAppNotifications.aspx"));
        }
        protected void lnkArchive_Click(object sender, EventArgs e)
        {
            string controlID = "";
            bool ArchiveFlag = true;
            LinkButton lnkCurrArchive = sender as LinkButton;
            string lnkText = lnkCurrArchive.Text;
            if (lnkText.Contains("Current"))
            {
                controlID = "chkSurveyID";
                ArchiveFlag = false;
            }
            else
            {
                controlID = "chkCurrentTabSurveyID";
                ArchiveFlag = true;
            }

            //Identify CheckBox is checked or not
            foreach (GridViewRow row in GrdSurveys.Rows)
            {
                if (((CheckBox)row.FindControl(controlID)).Checked)
                {
                    int ArchiveID = Convert.ToInt32(((LinkButton)(row.FindControl("lnkName"))).CommandArgument);
                    objCommon.ArchiveSelectedNewsletter(ArchiveID, ArchiveFlag, "Survey", C_UserID);
                }
            }

            if (ArchiveFlag == false)
                lblmess.Text = Resources.LabelMessages.ArchiveCurrentSuccess.Replace("#type#", "selected content");
            else
                lblmess.Text = Resources.LabelMessages.ArchiveSuccess.Replace("#type#", "selected content");

            GetManageSurveys();
        }
        [System.Web.Services.WebMethodAttribute(),
        System.Web.Script.Services.ScriptMethodAttribute()]
        public static string GetDynamicContent(string contextKey)
        {
            string[] surveyDetails = Regex.Split(contextKey, "##SP##");
            int surveyID = Convert.ToInt32(surveyDetails[0]);
            string surveyName = Convert.ToString(surveyDetails[1]);
            SurveyBLL objSurveyBLL = new SurveyBLL();
            int IOS_All = 0;
            int Android_All = 0;
            int Windows_All = 0;

            int IOS_Answered = 0;
            int Android_Answered = 0;
            int Windows_Answered = 0;

            int IOS_Completed = 0;
            int Android_Completed = 0;
            int Windows_Completed = 0;
            int completedusers = 0;
            int newusers = 0;
            int inprogusers = 0;
            DataTable dtDevicesCount = objSurveyBLL.GetDeviceCountByPID(Convert.ToInt32(HttpContext.Current.Session["ProfileID"]));
            int deviceCountByPID = 0;
            if (dtDevicesCount.Rows.Count > 0)
            {
                deviceCountByPID = Convert.ToInt32(dtDevicesCount.Rows[0]["TotalCount"]);

                IOS_All = Convert.ToInt32(dtDevicesCount.Rows[0]["IPhoneCount"]);
                Android_All = Convert.ToInt32(dtDevicesCount.Rows[0]["AndroidCount"]);
                Windows_All = Convert.ToInt32(dtDevicesCount.Rows[0]["WindowsCount"]);
            }

            DataTable dtAnswerSkips = objSurveyBLL.GetAnswersSkipCount(surveyID);
            int TotalAnswerCount = 0;
            if (dtAnswerSkips.Rows.Count > 0)
            {
                TotalAnswerCount = Convert.ToInt32(dtAnswerSkips.Rows[0]["TotalUsersCount"]);

                IOS_Answered = Convert.ToInt32(dtAnswerSkips.Rows[0]["IOSCount"]);
                Android_Answered = Convert.ToInt32(dtAnswerSkips.Rows[0]["AndroidCount"]);
                Windows_Answered = Convert.ToInt32(dtAnswerSkips.Rows[0]["WindowsCount"]);
            }

            DataTable dtCompletedAnswersCount = objSurveyBLL.GetCompletedAnswersCountBySurveyID(surveyID);
            completedusers = 0;
            if (dtCompletedAnswersCount.Rows.Count > 0)
            {
                completedusers = Convert.ToInt32(dtCompletedAnswersCount.Rows[0]["TotalCompletedAnswerCount"]);

                IOS_Completed = Convert.ToInt32(dtCompletedAnswersCount.Rows[0]["IOSCount"]);
                Android_Completed = Convert.ToInt32(dtCompletedAnswersCount.Rows[0]["AndroidCount"]);
                Windows_Completed = Convert.ToInt32(dtCompletedAnswersCount.Rows[0]["WindowsCount"]);
            }

            if (deviceCountByPID > TotalAnswerCount)
            {
                newusers = deviceCountByPID - TotalAnswerCount;
            }
            inprogusers = TotalAnswerCount - completedusers;

            StringBuilder b = new StringBuilder();

            b.Append("<table style='background-color:#f3f3f3; border: #336699 1px solid; ");
            b.Append("width:200px; font-size:10pt; font-family:Verdana;' cellspacing='0' cellpadding='3'>");

            b.Append("<tr><td colspan='3' style='background-color:#336699; color:white;'>");
            b.Append("<b>" + surveyName + "</b>"); b.Append("</td></tr>");
            // *** USPD-1259 - Changes to survey summary and survey manage page *** //
            //b.Append("<tr><td style='width:120px;'><b>Total Users:</b></td> <td>  " + deviceCountByPID + "</td></tr>");
            //b.Append("<tr><td style='width:120px; color:#3366cc;'><b>Not Started:</b></td></td> <td>  " + newusers + "</td></tr>");
            b.Append("<tr><td style='width:120px; color:#dc3912;'><b>In Progress:</b></td></td> <td>  " + inprogusers + "</td></tr><tr><td style='width:120px; color:#ff9900;'><b>Completed:</b></td></td> <td>  " + completedusers + "</td></tr>");


            b.Append("</table>");

            return b.ToString();
        }
        protected void btnEditOrderNumber_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtobj = new DataTable();
                lbl2.Text = string.Empty;
                dtobj = objSurveyBLL.GetSurveys(UserID);
                if (dtobj.Rows.Count > 0)
                {
                    OrderListView.DataSource = null;
                    OrderListView.DataSource = dtobj;
                    OrderListView.DataBind();
                    ModalPopupImgOrderNo.Show();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Save button", "ShowOrderScript();", true);
                }
                else
                    lblmess.Text = "<font color=red face=arial size=2><b>"+Resources.LabelMessages.OrderChangedPublishedContent+"</b></font>";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [WebMethod]
        public static string UpdateItemsOrder(string itemOrder)
        {
            string _result = "failed";
            try
            {
                SurveyBLL objSurveyBLL = new SurveyBLL();
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
                            objSurveyBLL.UpdateSurveysOrder(Convert.ToInt32(strBulletinOrder[i]), i + 1, CUserID);
                        }
                        objBus.Insert_SilentPushMessages(Convert.ToInt32(HttpContext.Current.Session["ProfileID"].ToString()), DateTime.Now, false, 0, "Surveys", "OrderNumberUpdate");
                    }

                }
                _result = "success";
            }
            catch (Exception /*ex*/)
            { }
            return _result;
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

                string RootFolder = Server.MapPath("~/Upload/Surveys/") + ProfileID;
                if (!Directory.Exists(RootFolder))
                    Directory.CreateDirectory(RootFolder);

                if (File.Exists(Server.MapPath("~") + "\\Upload\\Surveys\\" + ProfileID.ToString() + "\\" + lblKey.Text + ".jpg"))
                    lblOrderThumb.Text = "<img src='" + RootPath + "/Upload/Surveys/" + ProfileID.ToString() + "/" + lblKey.Text + ".jpg?Guid=" + ImageDisID + "' border='1' width='50' height='20'/>";
                else
                    lblOrderThumb.Text = "";
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
                        objSurveyBLL.UpdateSurveysOrder(Convert.ToInt32(lblKey.Text), i + 1, C_UserID);
                    }
                    lblmess.Text = "<font color=green face=arial size=2><b>The order of your contents has been updated successfully.</b></font>";
                    objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "Surveys", "OrderNumberUpdate");
                    GetManageSurveys();
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
        protected void RBAppOrder_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedOrderType = Convert.ToInt32(RBAppOrder.SelectedValue);

            //objCommon.UpdateDisplayOrderType(ProfileID, Convert.ToInt32(Session["CustomModuleID"]), selectedOrderType, "Bulletins");
            objCommon.UpdateDisplayOrderType(ProfileID, 0, selectedOrderType, "Surveys");
        }


        DropDownList ddlPageSize;
        private void SaveUserSettings()
        {
            try
            {
                string XMLdata = "<ManageSurveys MessagePageSize='" + PageSizes.SelectedPage + "'  /> ";
                var dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, WebConstants.Tab_SurveySetup, 0);
                if (dtDisplayReadFirst.Rows.Count == 0)
                    objBus.UserCustomizeSettings(0, ProfileID, UserID, WebConstants.Tab_SurveySetup, XMLdata, 0);
                else
                    objBus.UserCustomizeSettings(Convert.ToInt32(dtDisplayReadFirst.Rows[0]["CustomizeSettingsID"].ToString()), ProfileID, UserID, WebConstants.Tab_SurveySetup, XMLdata, 0);
            }
            catch (Exception ex)
            {
                
                objInBuiltData.ErrorHandling("ERROR", "ManageSurvey.aspx.cs", "SaveUserSettings()", ex.Message,
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
            dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, WebConstants.Tab_SurveySetup, 0);
            if (dtDisplayReadFirst.Rows.Count > 0)
            {
                XMLValue = Convert.ToString(dtDisplayReadFirst.Rows[0]["XMLValue"]);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(XMLValue);
                if (XMLValue != "")
                {
                    if (xmldoc.SelectSingleNode("ManageSurveys/@MessagePageSize") != null)
                    {
                        PageSizes.SelectedPage = xmldoc.SelectSingleNode("ManageSurveys/@MessagePageSize").Value;
                    }
                }
            }
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveUserSettings();
            GrdSurveys.PageSize = GetPageSize();
            GrdSurveys.DataSource = (DataTable)Session["dtSurveys"];
            GrdSurveys.DataBind();
        }
    }
}