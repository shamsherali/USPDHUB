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

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageCallIndexAddOns : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;

        public int SortDir = 0;

        AddOnBLL objAddOn = new AddOnBLL();
        BulletinBLL objBulletin = new BulletinBLL();
        BusinessBLL objBus = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        CommonBLL objCommon = new CommonBLL();
        public string RootPath = "";
        public string DomainName = "";

        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        SocialMediaAutoShareBLL smb = new SocialMediaAutoShareBLL();
        string appID = string.Empty;    //Facebook App ID and Secret
        string appSecret = string.Empty;

        public int CustomModuleId = 0;
        public string ArchiveValue = string.Empty;

        public DataTable dtCallIndexDetails = new DataTable();
        DataTable dtAddOn = new DataTable();



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();

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


            if (!IsPostBack)
            {
                if (Session["FormID"] != null)
                    Session.Remove("FormID");
                dtAddOn = objAddOn.GetAddOnById(CustomModuleId);
                if (dtAddOn.Rows.Count == 1)
                {
                    hdnAddOnName.Value = dtAddOn.Rows[0]["TabName"].ToString();
                    if (dtAddOn.Rows[0]["ButtonType"].ToString() == WebConstants.Tab_PrivateContentAddOns)
                    {
                        hdnIsPrivateModule.Value = "1";
                        Session["IsPrivate"] = "1";
                    }
                    else
                        Session["IsPrivate"] = null;
                }


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
                AddDefultPrivateCallImages();

                //  Hdn control for Sorting
                hdnsortdire.Value = "";
                hdnsortcount.Value = "0";
                GetAllManageCallIndexAddOns();
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
                                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessEventmail.Replace("event", "content") + "</font>";
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
                                lblmess.Text = "<font color='green'>" + Resources.LabelMessages.sendBusinessEventmail.Replace("event", "content") + "</font>";
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
                                    lblmess.Text = "<font color='green'>" + Resources.LabelMessages.ScheduleBusinessEvent.Replace("event", "content") + "</font>";
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
            //

        }

        /// <summary>
        /// 
        /// </summary>
        public void GetAllManageCallIndexAddOns()
        {
            //trShareOn1.Visible = true;

            hdnCommandArg.Value = "";
            dtCallIndexDetails = objAddOn.GetAllManageCallIndexAddOns(UserID, CustomModuleId);
            //if (hdnarchive.Value == "Archive")
            //{
            //    GrdCallIndex.Columns[2].Visible = true;
            //    GrdCallIndex.Columns[1].Visible = false;
            //    ArchiveValue = "Archive";
            //}
            //else
            //{
            //    GrdCallIndex.Columns[2].Visible = false;
            //    GrdCallIndex.Columns[1].Visible = true;
            //    ArchiveValue = "NoArchive";
            //}
            int TotalBulletins = dtCallIndexDetails.Rows.Count;
            Session["dtCallIndexDetails"] = dtCallIndexDetails;
            hdnShowButtons.Value = "1";
            GetSavedUserData();
            GrdCallIndex.PageSize = GetPageSize();
            GrdCallIndex.DataSource = dtCallIndexDetails;
            GrdCallIndex.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdCallIndex_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = e.Row.Cells.Count;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = e.Row.FindControl("lnkTitle") as LinkButton;
                Label lblbulletinthumb = e.Row.FindControl("lblthumb") as Label;
                string customID = lb.CommandArgument;
                string ImageDisID = Guid.NewGuid().ToString();

                /*
                if (File.Exists(Server.MapPath("~") + "\\Upload\\CustomModules\\" + ProfileID.ToString() + "\\" + customID + ".jpg"))
                    lblbulletinthumb.Text = "<img src='" + RootPath + "/Upload/CustomModules/" + ProfileID.ToString() + "/" + customID + ".jpg?Guid=" + ImageDisID + "' border='1' width='100' height='50'/>";
                else
                    lblbulletinthumb.Text = "";
                */

                if (File.Exists(Server.MapPath("~") + "\\Upload\\AppThumbs\\PrivateCallModules\\" + ProfileID.ToString() + "\\" + customID + ".jpg"))
                    lblbulletinthumb.Text = "<img src='" + RootPath + "/Upload/AppThumbs/PrivateCallModules/" + ProfileID.ToString() + "/" + customID + ".jpg?Guid=" + ImageDisID + "' />";
                else
                    lblbulletinthumb.Text = "";

                //if (lblcam.Text == "Scheduled" || lblcam.Text == "Cancelled")
                //{
                //    lnkcam.Text = lblcam.Text;
                //    lnkcam.Visible = true;
                //    lblcam.Visible = false;
                //}
                //else
                //{
                //    lnkcam.Visible = false;
                //    lblcam.Visible = true;
                //}
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdCallIndex_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            hdnShowButtons.Value = "1"; ; // *** To show all buttons ex: Preview, edit etc. *** //
            hdnCommandArg.Value = "";
            dtCallIndexDetails = (DataTable)Session["dtCallIndexDetails"];
            GrdCallIndex.PageIndex = e.NewPageIndex;
            GrdCallIndex.DataSource = dtCallIndexDetails;
            GrdCallIndex.DataBind();
        }


        protected void GrdCallIndex_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDir = Convert.ToInt32(hdnsortcount.Value);
            string SortExp = e.SortExpression.ToString();
            dtCallIndexDetails = (DataTable)Session["dtCallIndexDetails"];
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
            DataView Dv = new DataView(dtCallIndexDetails);
            if (SortDir == 0)
            {
                if (SortExp == "Title")
                {
                    Dv.Sort = "Title desc";
                }
                else if (SortExp == "MobileNumber")
                {
                    Dv.Sort = "MobileNumber desc";
                }
                hdnsortcount.Value = "1";
            }
            else
            {
                if (SortExp == "Title")
                {
                    Dv.Sort = "Title ASC";
                }
                else if (SortExp == "MobileNumber")
                {
                    Dv.Sort = "MobileNumber ASC";
                }
                hdnsortcount.Value = "0";
            }
            Session["dtCallIndexDetails"] = Dv.ToTable();
            GrdCallIndex.DataSource = Dv;
            GrdCallIndex.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chkCurrentTabCustomID_CheckedChanged(object sender, EventArgs e)
        {
            hdnIsPusblished.Value = "";
            CheckBox rb = (CheckBox)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            LinkButton lnkTitle = (LinkButton)row.FindControl("lnkTitle");
            LinkButton lnkcamp = (LinkButton)row.FindControl("lnkruncampaion");
            Label lblStatus = (Label)row.FindControl("lblStatus");
            //trShareOn1.Visible = true;
            //trShareOn2.Visible = true;

            hdnCommandArg.Value = lnkTitle.CommandArgument;
            hdnRowIndex.Value = row.RowIndex.ToString();

            // Selected Checkbox details for Preview, Edit, Copy, Send Mail
            foreach (GridViewRow row1 in GrdCallIndex.Rows)
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
            //if (lblStatus.Text == "True")
            //{
            //    hdnIsPusblished.Value = "true";
            //}
            //if (lnkcamp.Visible == true)
            //{
            //    //if (lnkcamp.Text == "Scheduled" || lnkcamp.Text == "Sending")
            //    //    CancelCamp.Visible = true;
            //    //else
            //    //    CancelCamp.Visible = false;
            //}
            //else
            //{
            //    // CancelCamp.Visible = false;
            //}

            //var expiryDate = Convert.ToString(GrdCallIndex.DataKeys[Convert.ToInt32(hdnRowIndex.Value)].Values["Expiration_Date"].ToString());
            //if (expiryDate != string.Empty)
            //{
            //    if (Convert.ToDateTime(expiryDate) < DateTime.Now)
            //    {
            //        // trUnPublish.Visible = false;
            //        //trPublish.Visible = false;
            //        lblerrormessage.Text = "Expired content is not allowed to publish.";
            //    }
            //}
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            //CancelCamp.Visible = false;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
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
            DataTable dtCallIndexDetails = objAddOn.GetCallIndexDetailsByID(customID);
            if (dtCallIndexDetails.Rows.Count > 0)
            {
                string preview = string.Empty;
                lblNamme.Text = hdnAddOnName.Value;
                string htmlString = BuildHTML(dtCallIndexDetails).Replace("padding-top: 100px; padding-left: 50px;", "padding-top: 100px; padding-left: 150px;");
                lblPreviewHTML.Text = htmlString;
                MPEPreview.Show();
            }
        }
        private string BuildHTML(DataTable dtCallIndexDetails)
        {
            StringBuilder strHtml = new StringBuilder();
            try
            {
                string previewText = objCommon.GetCallPreviewText();
                if (Convert.ToString(dtCallIndexDetails.Rows[0]["ImageUrls"]) != "")
                    previewText = previewText.Replace("#IMGTag#", "<div id='divImage1' style='border: 0px soild #dddddd;'><span class=\"imgStyle\"><img src=\"" + Convert.ToString(dtCallIndexDetails.Rows[0]["ImageUrls"]) + "\"  /></span></div>");
                else
                    previewText = previewText.Replace("#IMGTag#", "");
                previewText = previewText.Replace("#Title#", Convert.ToString(dtCallIndexDetails.Rows[0]["Title"]));
                if (Convert.ToString(dtCallIndexDetails.Rows[0]["MobileNumber"]) != "")
                {
                    previewText = previewText.Replace("#PhoneNumber#", "<tr><td style='page-break-inside: avoid;'>Phone: <span style='color:#FF6600; font-weight: bold;'>" + Convert.ToString(dtCallIndexDetails.Rows[0]["MobileNumber"]) + "</span></td></tr>");

                }
                else
                {

                    previewText = previewText.Replace("#PhoneNumber#", "");
                }
                previewText = previewText.Replace("#Description#", Convert.ToString(dtCallIndexDetails.Rows[0]["Description"]));
                StringBuilder Rows = new StringBuilder();

                if (Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsAutoEmail"]))
                {
                    Rows.Append("<tr>");
                    Rows.Append("<td>");
                    Rows.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"padding:4px; border-top: 1px solid #6d6d6d;\"");
                    Rows.Append("<tr>");
                    Rows.Append("<td style='page-break-inside: avoid; text-align:center;'><b>Email: </b></td></tr>");
                    Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Subject: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dtCallIndexDetails.Rows[0]["Email_Subject"]) + "\"</span></td></tr>");
                    if (!Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsCustomPredefinedMessage"]))
                        Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Message: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dtCallIndexDetails.Rows[0]["Email_Description"]) + "\"</span><td></tr>");
                    if (Convert.ToString(dtCallIndexDetails.Rows[0]["Email_GroupIDs"]) != "")
                    {
                        DataSet dsGroup = objAddOn.GetGroupByID(Convert.ToInt32(dtCallIndexDetails.Rows[0]["Email_GroupIDs"]));
                        if (dsGroup.Tables[0].Rows.Count > 0)
                        {
                            Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Contact Group: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dsGroup.Tables[0].Rows[0]["GroupName"]) + "\"</span></td></tr>");
                        }
                    }
                    Rows.Append("</table>");
                    Rows.Append("</td></tr>");
                }
                if (Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsAutoPushNotification"]))
                {
                    Rows.Append("<tr>");
                    Rows.Append("<td>");
                    Rows.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-top: 1px solid #6d6d6d; padding:4px;\">");
                    Rows.Append("<tr>");
                    Rows.Append("<td style='page-break-inside: avoid; text-align:center;'><b>Push Notification:</b></td></tr>");
                    Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Summary: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dtCallIndexDetails.Rows[0]["PushNotification_Subject"]) + "\"</span></td></tr>");
                    if (!Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsCustomPredefinedMessage"]))
                        Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Message: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dtCallIndexDetails.Rows[0]["PushNotification_Description"]) + "\"</span></td></tr>");
                    if (Convert.ToString(dtCallIndexDetails.Rows[0]["PushNotification_GroupIDs"]) != "")
                    {
                        DataSet dsGroup = objAddOn.GetGroupByID(Convert.ToInt32(dtCallIndexDetails.Rows[0]["PushNotification_GroupIDs"]));
                        if (dsGroup.Tables[0].Rows.Count > 0)
                        {
                            Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Contact Group: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dsGroup.Tables[0].Rows[0]["GroupName"]) + "\"</span></td></tr>");
                        }
                    }
                    Rows.Append("</table>");
                    Rows.Append("</td></tr>");
                }
                if (Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsAutoTextMessage"]))
                {
                    Rows.Append("<tr>");
                    Rows.Append("<td>");
                    Rows.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-top: 1px solid #6d6d6d; padding:4px;\">");
                    Rows.Append("<tr>");
                    Rows.Append("<td style='page-break-inside: avoid; text-align:center;'><b>Text Message:</b> <br/><br/></td></tr>");
                    Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Subject: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dtCallIndexDetails.Rows[0]["SMS_Subject"]) + "\"</span></td></tr>");
                    if (!Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsCustomPredefinedMessage"]))
                        Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Message: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dtCallIndexDetails.Rows[0]["SMS_Description"]) + "\"</span></td></tr>");
                    if (Convert.ToString(dtCallIndexDetails.Rows[0]["SMS_GroupIDs"]) != "")
                    {
                        DataSet dsGroup = objAddOn.GetGroupByID(Convert.ToInt32(dtCallIndexDetails.Rows[0]["SMS_GroupIDs"]));
                        if (dsGroup.Tables[0].Rows.Count > 0)
                        {
                            Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Contact Group: <span style=\"color:#FF6600; font-weight: bold;\">\"" + Convert.ToString(dsGroup.Tables[0].Rows[0]["GroupName"]) + "\"</span></td></tr>");
                        }
                    }
                    Rows.Append("</table>");
                    Rows.Append("</td></tr>");
                }
                previewText = previewText.Replace("#ROWS#", Rows.ToString());
                string deviceInfo = "";
                if (Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsGPSInformation"]) || Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsAllPhoneInformation"]))
                {
                    deviceInfo = "<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\" style=\"border-top: 1px solid #6d6d6d;\"><tr>";
                    if (Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsGPSInformation"]))
                        deviceInfo = deviceInfo + "<td width=\"50%\"><input type=\"checkbox\" checked=\"checked\" disabled=\"disabled\"/> GPS Information</td>";
                    if (Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsAllPhoneInformation"]))
                        deviceInfo = deviceInfo + "<td width=\"50%\"><input type=\"checkbox\" checked=\"checked\" disabled=\"disabled\"/> Phone Information</td>";
                    if (Convert.ToBoolean(dtCallIndexDetails.Rows[0]["IsUploadImage"]))
                        deviceInfo = deviceInfo + "<tr><td width=\"50%\"><input type=\"checkbox\" checked=\"checked\" disabled=\"disabled\"/> Include Image</td>";
                    deviceInfo = deviceInfo + "<tr></table>";
                }
                previewText = previewText.Replace("##DeviceInfo##", deviceInfo);
                strHtml.Append(previewText);
                strHtml.Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);
            }
            catch (Exception ex)
            {

            }
            return strHtml.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkTitle_Click(object sender, EventArgs e)
        {
            LinkButton lnkTitle = sender as LinkButton;
            ShowPreview(Convert.ToInt32(lnkTitle.CommandArgument));
        }
        protected void chkVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (hdnCommandArg.Value != "")
            {
                int _result = objAddOn.ChangeCallAddOnVisiblity(Convert.ToInt32(hdnCommandArg.Value), C_UserID);
                if (_result == 0)
                    lblerrormessage.Text = Resources.LabelMessages.CallAddOnVisibilityFailed;
                else if (_result == 1) // *** MAKING VISINLE *** //
                    lblmess.Text = Resources.LabelMessages.CallAddOnVisibilityOn;
                else if (_result == 2) // *** MAKING INVISINLE *** //
                    lblmess.Text = Resources.LabelMessages.CallAddOnVisibilityOff;

            }
            GetAllManageCallIndexAddOns();
            hdnCommandArg.Value = "";
        }
        protected void linkEdit_Click(object sender, EventArgs e)
        {
            LinkButton linkEdit = sender as LinkButton;
            int hdnCommandArg = Convert.ToInt32(linkEdit.CommandArgument);


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

            if ((hdnCommandArg.ToString() != "" && ((authorPermission == "A") || (authorPermission == "A" && pubPermission == "P"))) || (Convert.ToString(Session["C_USER_ID"]) == "" || Session["C_USER_ID"] == null))
            {
                string RedirectUrl = Page.ResolveClientUrl("~/Business/MyAccount/CallIndexAutoMessage.aspx?CustomID=" + EncryptDecrypt.DESEncrypt(hdnCommandArg.ToString()));
                Response.Redirect(RedirectUrl);

            }
            else
            {
                //You don't have permission to edit Content
            }


        }
        protected void linkDelete_Click(object sender, EventArgs e)
        {
            LinkButton linkDelete = sender as LinkButton;
            int hdnCommandArg = Convert.ToInt32(linkDelete.CommandArgument);
            objCommon.InsertUserActivityLog("has deleted a custom module", string.Empty, UserID, ProfileID, DateTime.Now, UserID);
            objAddOn.DeleteCallIndexItem(hdnCommandArg, UserID);
            DataTable dtCallIndexDetails = objAddOn.GetAllManageCallIndexAddOns(UserID, CustomModuleId);
            Session["dtCallIndexDetails"] = dtCallIndexDetails;
            GrdCallIndex.DataSource = dtCallIndexDetails;
            GrdCallIndex.DataBind();
            lblmess.Text = "<font size='3'>Call Index Auto Message deleted successfully.</font>";

        }
        private void AddDefultPrivateCallImages()
        {
            try
            {
                int GroupID = 0;
                string callModuleDirectory = Server.MapPath("~/Upload/CallModule/" + ProfileID);
                if (!System.IO.Directory.Exists(callModuleDirectory))
                {
                    System.IO.Directory.CreateDirectory(callModuleDirectory);
                }
                callModuleDirectory = callModuleDirectory + "/" + CustomModuleId;
                if (!System.IO.Directory.Exists(callModuleDirectory))
                {
                    System.IO.Directory.CreateDirectory(callModuleDirectory);
                    string sourcePath = Server.MapPath("~/Upload/DefaultCallModule/" + DomainName);
                    string fileName = "";
                    string destFile = "";

                    /*
                    if (Directory.Exists(sourcePath))
                    {
                        foreach (var srcPath in Directory.GetFiles(sourcePath))
                        {
                            fileName = System.IO.Path.GetFileName(srcPath);
                            destFile = System.IO.Path.Combine(callModuleDirectory, fileName);
                            File.Copy(srcPath, destFile, true);
                        }
                    }
                    objCommon.AddCallModuleDefaultImages(CustomModuleId, ProfileID, UserID, C_UserID, WebConstants.Purchase_PrivateCallAddOns);
                    */

                    DataTable dtCallModuleDefaultItems = objAddOn.GetCallModuleDefaultitems(DomainName, WebConstants.Purchase_PrivateCallAddOns);
                    if (dtCallModuleDefaultItems.Rows.Count > 0)
                    {

                        bool IsIntiatePhoneCall = true;
                        bool IsCustomPredefinedMessage = false;
                        string imagePath = RootPath + "/Upload/CallModule/" + ProfileID + "/" + CustomModuleId + "/";
                        for (int i = 0; i < dtCallModuleDefaultItems.Rows.Count; i++)
                        {
                            try
                            {
                                string srcPath = sourcePath + "/" + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"]);
                                if (File.Exists(srcPath))
                                {
                                    destFile = System.IO.Path.Combine(callModuleDirectory, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"]));
                                    File.Copy(srcPath, destFile, true);
                                }
                            }
                            catch (Exception ex)
                            { }


                            objAddOn.InsertUpdateCallIndexData(0, ProfileID, UserID, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["CallTitle"]), imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["MobileNumber"]), false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailDescription"]), GroupID.ToString(),
                                    false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PushNotificationDescription"]), GroupID.ToString(), false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSDescription"]), GroupID.ToString(), false, false,
                                    true, C_UserID, C_UserID, CustomModuleId, false, false, false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PushNotificationSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["Description"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PreviewHtml"]).Replace("##Rootpath##", RootPath).Replace("##ImagePathUrl##", imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"])), false, IsIntiatePhoneCall, IsCustomPredefinedMessage,false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageCallIndexAddOns.aspx.cs", "AddDefultPrivateCallImages()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        DropDownList ddlPageSize;
        private void SaveUserSettings()
        {
            try
            {
                string XMLdata = "<ManagePrivateCalls MessagePageSize='" + PageSizes.SelectedPage + "'  /> ";
                var dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, WebConstants.Tab_PrivateCallAddOns, CustomModuleId);
                if (dtDisplayReadFirst.Rows.Count == 0)
                    objBus.UserCustomizeSettings(0, ProfileID, UserID, WebConstants.Tab_PrivateCallAddOns, XMLdata, CustomModuleId);
                else
                    objBus.UserCustomizeSettings(Convert.ToInt32(dtDisplayReadFirst.Rows[0]["CustomizeSettingsID"].ToString()), ProfileID, UserID, WebConstants.Tab_PrivateCallAddOns, XMLdata, CustomModuleId);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageCallIndexAddOns.aspx.cs", "SaveUserSettings()", ex.Message,
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
            dtDisplayReadFirst = objBus.GetDisplayReadFirst(ProfileID, WebConstants.Tab_PrivateCallAddOns, CustomModuleId);
            if (dtDisplayReadFirst.Rows.Count > 0)
            {
                XMLValue = Convert.ToString(dtDisplayReadFirst.Rows[0]["XMLValue"]);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(XMLValue);
                if (XMLValue != "")
                {
                    if (xmldoc.SelectSingleNode("ManagePrivateCalls/@MessagePageSize") != null)
                    {
                        PageSizes.SelectedPage = xmldoc.SelectSingleNode("ManagePrivateCalls/@MessagePageSize").Value;
                    }
                }
            }
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveUserSettings();
            GrdCallIndex.PageSize = GetPageSize();
            GrdCallIndex.DataSource = (DataTable)Session["dtCallIndexDetails"];
            GrdCallIndex.DataBind();
        }
    }
}