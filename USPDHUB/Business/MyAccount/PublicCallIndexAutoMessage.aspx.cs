using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Text;
using System.IO;

namespace USPDHUB.Business.MyAccount
{
    public partial class PublicCallIndexAutoMessage : System.Web.UI.Page
    {
        AddOnBLL objAddOns = new AddOnBLL();
        public int UserID = 0;
        public int ProfileID = 0;
        public int CUserID = 0;
        public int UserModuleID = 0;
        public int CustomID = 0;
        public int AppUserAnonymousType = 0;
        public string PreviewHtml = string.Empty;
        StringBuilder strPrintHtml;
        public string RootPath = "";
        CommonBLL objCommon = new CommonBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        BusinessBLL objBus = new BusinessBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                UserModuleID = Convert.ToInt32(Session["CustomModuleID"].ToString());
                RootPath = Session["RootPath"].ToString();
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
                if (Request.QueryString["CustomID"] != null)
                {
                    CustomID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["CustomID"].ToString()));
                }

                if (!IsPostBack)
                {
                    Session["ContentContacts"] = null;
                    Session["tempContactList"] = null;
                    BindGroupData();
                    BindManageContacts();
                    BindSmartConnectCategories();
                    if (CustomID > 0)
                    {
                        GetContacts();
                        BindCallIndexData();
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Display Image", "DisplayImage();", true);
                        btnSubmit.Text = "Update";
                        DataTable dtAddOn = objAddOns.GetAddOnById(UserModuleID);
                        if (dtAddOn.Rows.Count > 0)
                        {
                            lblCallModuleName.Text = lblName.Text = Convert.ToString(dtAddOn.Rows[0]["TabName"]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "PublicCallIndexAutoMessage.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void BindSmartConnectCategories()
        {
            try
            {
                DataTable dtCategories = objBus.GetSmartConnectCategoriesList(ProfileID, UserModuleID);
                if (dtCategories.Rows.Count > 0)
                {
                    ddlCategory.DataSource = dtCategories;
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataBind();
                }

            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "PublicCallIndexAutoMessage.aspx.cs", "BindSmartConnectCategories", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void BindCallIndexData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objAddOns.GetPublicCallIndexByID(CustomID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCallBtnIdentity.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();

                    txtDesc.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                    hdnImage.Value = ds.Tables[0].Rows[0]["ImageUrls"].ToString();
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsAutoEmail"].ToString()))
                        chkEmail.Checked = true;
                    else
                        chkEmail.Checked = false;
                    txtEmailSub.Text = ds.Tables[0].Rows[0]["Email_Subject"].ToString();
                    txtEDesc.Text = ds.Tables[0].Rows[0]["Email_Description"].ToString();
                    ddlEGroup.SelectedValue = ds.Tables[0].Rows[0]["Email_GroupIDs"].ToString();
                    //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsAutoPushNotification"].ToString()))
                    //    chkPush.Checked = true;
                    //else
                    //    chkPush.Checked = false;
                    //txtPushSub.Text = ds.Tables[0].Rows[0]["PushNotification_Subject"].ToString();
                    //txtPDesc.Text = ds.Tables[0].Rows[0]["PushNotification_Description"].ToString();
                    //ddlPushGroup.SelectedValue = ds.Tables[0].Rows[0]["PushNotification_GroupIDs"].ToString();
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsAutoTextMessage"].ToString()))
                        chkText.Checked = true;
                    else
                        chkText.Checked = false;
                    txtTextSub.Text = ds.Tables[0].Rows[0]["SMS_Subject"].ToString();
                    txtTDesc.Text = ds.Tables[0].Rows[0]["SMS_Description"].ToString();
                    ddlTextGroup.SelectedValue = ds.Tables[0].Rows[0]["SMS_GroupIDs"].ToString();
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsGPSInformation"].ToString()))
                        chkGPS.Checked = true;
                    else
                        chkGPS.Checked = false;
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsAllPhoneInformation"].ToString()))
                        chkPhone.Checked = true;
                    else
                        chkPhone.Checked = false;
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsVisible"].ToString()))
                        chkVisible.Checked = true;
                    else
                        chkVisible.Checked = false;
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsIntiatesPhoneCall"].ToString()))
                        ChkIsInitiatesPhoneCall.Checked = true;
                    else
                        ChkIsInitiatesPhoneCall.Checked = false;
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsCustomPredefinedMessage"].ToString()))
                        rdPredefined.SelectedValue = "true";
                    else
                        rdPredefined.SelectedValue = "false";
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsAnonymous"].ToString()))
                        chkAnonymous.Checked = true;
                    else
                        chkAnonymous.Checked = false;
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsUploadImage"].ToString()))
                        chkUploadImage.Checked = true;
                    else
                        chkUploadImage.Checked = false;
                    rbAnonymously.SelectedValue = ds.Tables[0].Rows[0]["AppUserAnonymousType"].ToString();
                    ddlCategory.SelectedValue = ds.Tables[0].Rows[0]["CategoryID"].ToString();
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "PublicCallIndexAutoMessage.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void BindGroupData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objAddOns.GetPublicGroupsData(UserModuleID);
                //Email Group
                ddlEGroup.DataSource = ds;
                ddlEGroup.DataTextField = "GroupName";
                ddlEGroup.DataValueField = "GroupID";
                ddlEGroup.DataBind();
                ddlEGroup.Items.Insert(0, "Select Group");
                //Push Notification Group
                //ddlPushGroup.DataSource = ds;
                //ddlPushGroup.DataTextField = "GroupName";
                //ddlPushGroup.DataValueField = "GroupID";
                //ddlPushGroup.DataBind();
                //ddlPushGroup.Items.Insert(0, "Select Group");
                //Text Message Group
                ddlTextGroup.DataSource = ds;
                ddlTextGroup.DataTextField = "GroupName";
                ddlTextGroup.DataValueField = "GroupID";
                ddlTextGroup.DataBind();
                ddlTextGroup.Items.Insert(0, "Select Group");
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "PublicCallIndexAutoMessage.aspx.cs", "BindGroupData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManagePublicCallIndexAddOns.aspx"));
        }


        protected void lnkPreview_Click(object sender, EventArgs e)
        {
            try
            {
                string htmlString = BuildHTML();
                string previewHTML = objCommon.ReplaceShortURltoHtmlString(htmlString);
                lblPreviewHTML.Text = htmlString;
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "PublicCallIndexAutoMessage.aspx.cs", "lnkPreview_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private string BuildHTML()
        {
            StringBuilder strHtml = new StringBuilder();
            try
            {
                strPrintHtml = new StringBuilder();
                string previewText = objCommon.GetPublicCallPreviewText();
                if (hdnDPLink.Value == "")
                {
                    previewText = previewText.Replace("#IMGTag#", "<div id='divImage1' style='border: 0px soild #dddddd;'><span class=\"imgStyle\"><img src=\"" + hdnImage.Value + "\"  /></span></div>");
                }
                else
                {
                    previewText = previewText.Replace("#IMGTag#", "<div id='divImage1' style='border: 0px soild #dddddd;'><a href='" + hdnDPLink.Value + "' target='_blank'><span class=\"imgStyle\"><img src='" + hdnImage.Value + "' /></span></a></div>");
                }
                previewText = previewText.Replace("#Title#", txtCallBtnIdentity.Text.Trim());
                if (txtPhone.Text.Trim() != "")
                {
                    previewText = previewText.Replace("#PhoneNumber#", "<tr><td style='page-break-inside: avoid;'>Phone: <span style='color:#FF6600; font-weight: bold;'>" + txtPhone.Text.Trim() + "</span></td></tr>");

                }
                else
                {

                    previewText = previewText.Replace("#PhoneNumber#", "");
                }
                previewText = previewText.Replace("#Description#", txtDesc.Text.Trim());
                StringBuilder Rows = new StringBuilder();
                if (chkEmail.Checked)
                {
                    Rows.Append("<tr>");
                    Rows.Append("<td>");
                    Rows.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"padding:4px; border-top: 1px solid #6d6d6d;\"");
                    Rows.Append("<tr>");
                    Rows.Append("<td style='page-break-inside: avoid; text-align:center;'><b>Email: </b></td></tr>");
                    Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Subject: <span style=\"color:#FF6600; font-weight: bold;\">\"" + txtEmailSub.Text.Trim() + "\"</span></td></tr>");
                    if (!Convert.ToBoolean(rdPredefined.SelectedValue))
                        Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Message: <span style=\"color:#FF6600; font-weight: bold;\">\"" + txtEDesc.Text.Trim() + "\"</span><td></tr>");
                    if (ddlEGroup.SelectedItem.Text != "Select Group")
                        Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Contact Group: <span style=\"color:#FF6600; font-weight: bold;\">\"" + ddlEGroup.SelectedItem.Text.Trim() + "\"</span></td></tr>");
                    Rows.Append("</table>");
                    Rows.Append("</td></tr>");
                }
                //if (chkPush.Checked)
                //{
                //    Rows.Append("<tr>");
                //    Rows.Append("<td>");
                //    Rows.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-top: 1px solid #6d6d6d; padding:4px;\">");
                //    Rows.Append("<tr>");
                //    Rows.Append("<td style='page-break-inside: avoid; text-align:center;'><b>Push Notification:</b></td></tr>");
                //    Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Summary: <span style=\"color:#FF6600; font-weight: bold;\">\"" + txtPushSub.Text.Trim() + "\"</span></td></tr>");
                //    Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Message: <span style=\"color:#FF6600; font-weight: bold;\">\"" + txtPDesc.Text.Trim() + "\"</span></td></tr>");
                //    if (ddlPushGroup.SelectedItem.Text != "Select Group")
                //        Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Contact Group: <span style=\"color:#FF6600; font-weight: bold;\">\"" + ddlPushGroup.SelectedItem.Text.Trim() + "\"</span></td></tr>");
                //    Rows.Append("</table>");
                //    Rows.Append("</td></tr>");
                //}
                if (chkText.Checked)
                {
                    Rows.Append("<tr>");
                    Rows.Append("<td>");
                    Rows.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-top: 1px solid #6d6d6d; padding:4px;\">");
                    Rows.Append("<tr>");
                    Rows.Append("<td style='page-break-inside: avoid; text-align:center;'><b>Text Message:</b></td></tr>");
                    Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Subject: <span style=\"color:#FF6600; font-weight: bold;\">\"" + txtTextSub.Text.Trim() + "\"</span></td></tr>");
                    if (!Convert.ToBoolean(rdPredefined.SelectedValue))
                        Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Message: <span style=\"color:#FF6600; font-weight: bold;\">\"" + txtTDesc.Text.Trim() + "\"</span></td></tr>");
                    if (ddlTextGroup.SelectedItem.Text != "Select Group")
                        Rows.Append("<tr><td style='page-break-inside: avoid; line-height:20px;'>Contact Group: <span style=\"color:#FF6600; font-weight: bold;\">\"" + ddlTextGroup.SelectedItem.Text.Trim() + "\"</span></td></tr>");
                    Rows.Append("</table>");
                    Rows.Append("</td></tr>");
                }
                previewText = previewText.Replace("#ROWS#", Rows.ToString());
                string deviceInfo = "";
                if (chkGPS.Checked || chkPhone.Checked)
                {
                    deviceInfo = "<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\" style=\"border-top: 1px solid #6d6d6d;\"><tr>";
                    if (chkGPS.Checked)
                        deviceInfo = deviceInfo + "<td width=\"50%\"><input type=\"checkbox\" checked=\"checked\" disabled=\"disabled\"/> GPS Information</td>";
                    if (chkPhone.Checked)
                        deviceInfo = deviceInfo + "<td width=\"50%\"><input type=\"checkbox\" checked=\"checked\" disabled=\"disabled\"/> Phone Information</td>";
                    deviceInfo = deviceInfo + "<tr></table>";
                }
                previewText = previewText.Replace("##DeviceInfo##", deviceInfo);
                string Anonymous = "";
                if (chkAnonymous.Checked || chkUploadImage.Checked)
                {
                    Anonymous = "<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\" ><tr>";
                    if (chkAnonymous.Checked)
                        Anonymous = Anonymous + "<td width=\"50%\"><input type=\"checkbox\" checked=\"checked\" disabled=\"disabled\"/> Anonymous</td>";
                    if (chkUploadImage.Checked)
                        Anonymous = Anonymous + "<td width=\"50%\"><input type=\"checkbox\" checked=\"checked\" disabled=\"disabled\"/> Include Image</td>";
                    Anonymous = Anonymous + "<tr></table>";
                }
                previewText = previewText.Replace("##Anonymous##", Anonymous);
                strHtml.Append(previewText);
                PreviewHtml = strHtml.ToString().Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "PublicCallIndexAutoMessage.aspx.cs", "BuildHTML", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

            return PreviewHtml;
        }


        protected void lnkEmailViewContacts_OnClick(object sender, EventArgs e)
        {
            ShowContactsModalPopup(ddlEGroup.SelectedValue.ToString(), ddlEGroup.SelectedItem.Text);
        }


        protected void lnkMessageViewContacts_OnClick(object sender, EventArgs e)
        {
            ShowContactsModalPopup(ddlTextGroup.SelectedValue.ToString(), ddlTextGroup.SelectedItem.Text);
        }

        private void ShowContactsModalPopup(string pGroupID, string pGroupName)
        {
            try
            {
                modalViewContacts.Show();
                lblViewGroupName.Text = pGroupName;
                DataTable dtContacts = objAddOns.GetActiveContacts(UserModuleID, pGroupID);
                grdViewContacts.DataSource = dtContacts;
                grdViewContacts.DataBind();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "PublicCallIndexAutoMessage.aspx.cs", "ShowContactsModalPopup", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }



        }


        protected void lnkViewContacts_Click(object sender, EventArgs e)
        {

            string reditectUrl = Page.ResolveClientUrl("~/Business/Myaccount/ManageCallIndexContacts.aspx");
            Response.Redirect(reditectUrl);

        }

        protected void GetContacts()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objAddOns.GetPublicCallGroupContactsByID(CustomID);
                grdListContacts.Visible = true;
                grdListContacts.DataSource = dt;
                grdListContacts.DataBind();
                Session["ContentContacts"] = dt;
                ViewState["ContentContacts"] = dt;
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "PublicCallIndexAutoMessage.aspx.cs", "GetContacts", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int chkContactId, groupId, customId;

                PreviewHtml = BuildHTML();
                bool isPublished = false;
                if (chkVisible.Checked)
                    isPublished = true;
                for (int i = 0; i < rbAnonymously.Items.Count; i++)
                {
                    if (rbAnonymously.Items[i].Selected)
                    {
                        if (Convert.ToInt32(rbAnonymously.Items[i].Value) == Convert.ToInt32(USPDHUBDAL.AddOnDAL.AppUserAnonymousType.AppIdentityMandatory) || Convert.ToInt32(rbAnonymously.Items[i].Value) == Convert.ToInt32(USPDHUBDAL.AddOnDAL.AppUserAnonymousType.AppIdentityChoose))
                            chkAnonymous.Checked = false;
                        if (Convert.ToInt32(rbAnonymously.Items[i].Value) == Convert.ToInt32(USPDHUBDAL.AddOnDAL.AppUserAnonymousType.AppAnonymous))
                            chkAnonymous.Checked = true;
                        AppUserAnonymousType = Convert.ToInt32(rbAnonymously.Items[i].Value.ToString());
                        break;
                    }
                }
                if (CustomID > 0)
                {
                    customId = objAddOns.InsertUpdatePublicCallIndexData(CustomID, ProfileID, UserID, txtCallBtnIdentity.Text, hdnImage.Value, txtPhone.Text, chkEmail.Checked, txtEDesc.Text, ddlEGroup.SelectedValue,
                      chkText.Checked, txtTDesc.Text, ddlTextGroup.SelectedValue, chkGPS.Checked, chkPhone.Checked, true, CUserID, CUserID, UserModuleID, false, isPublished, isPublished, txtEmailSub.Text,
                      txtTextSub.Text, txtDesc.Text, PreviewHtml, chkVisible.Checked, ChkIsInitiatesPhoneCall.Checked, Convert.ToBoolean(rdPredefined.SelectedValue), chkAnonymous.Checked, chkUploadImage.Checked, AppUserAnonymousType, Convert.ToInt32(ddlCategory.SelectedValue));

                    Session["BulletinSuccess"] = Resources.LabelMessages.SmartConnectUpdated;
                }
                else
                {
                    customId = objAddOns.InsertUpdatePublicCallIndexData(CustomID, ProfileID, UserID, txtCallBtnIdentity.Text, hdnImage.Value, txtPhone.Text, chkEmail.Checked, txtEDesc.Text, ddlEGroup.SelectedValue,
                        chkText.Checked, txtTDesc.Text, ddlTextGroup.SelectedValue, chkGPS.Checked, chkPhone.Checked, true, CUserID, CUserID, UserModuleID, false, isPublished, isPublished, txtEmailSub.Text,
                        txtTextSub.Text, txtDesc.Text, PreviewHtml, chkVisible.Checked, ChkIsInitiatesPhoneCall.Checked, Convert.ToBoolean(rdPredefined.SelectedValue), chkAnonymous.Checked, chkUploadImage.Checked, AppUserAnonymousType, Convert.ToInt32(ddlCategory.SelectedValue));

                    Session["BulletinSuccess"] = Resources.LabelMessages.SmartConnectCreated;

                }
                //Inserting checked contacts and deleting unchecked contacts
                groupId = GetGroupIDByCustomID(customId);
                BindManageContacts();
                foreach (GridViewRow row in gvManageContacts.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkContacts") as CheckBox);
                        chkContactId = Convert.ToInt32((row.Cells[1].FindControl("lblContactID") as Label).Text);
                        int contactExist = objAddOns.CheckPublicAssignGroupToContact(chkContactId, groupId, UserModuleID);
                        if (chkRow.Checked)
                        {
                            if (contactExist == 0)
                            {
                                objAddOns.AssignPublicCallIndexGroupContactID(0, groupId, chkContactId);
                                objAddOns.CheckPublicAssignGroupToContact(chkContactId, groupId, UserModuleID);
                            }

                        }
                        else
                        {
                            chkRow.Checked = false;
                            objAddOns.AssignPublicCallIndexGroupContactID(1, groupId, chkContactId);
                        }
                    }
                }
                //Assign to Not Assigned when contact unchecked for all groups
                if (ViewState["ContentContacts"] != null)
                {
                    int CID, GID;
                    DataTable dtExistContacts = (DataTable)ViewState["ContentContacts"];
                    for (int i = 0; i < dtExistContacts.Rows.Count; i++)
                    {
                        CID = Convert.ToInt32(dtExistContacts.Rows[i]["ContactID"].ToString());
                        GID = Convert.ToInt32(dtExistContacts.Rows[i]["GroupID"].ToString());
                        objAddOns.CheckPublicAssignGroupToContact(CID, GID, UserModuleID);
                    }

                }

                MPEProgress.Hide();

                string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/ManagePublicCallIndexAddOns.aspx");
                Response.Redirect(urlinfo);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "PublicCallIndexAutoMessage.aspx.cs", "btnSubmit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        //Getting GroupID by using CustomID for Manage Contacts
        private int GetGroupIDByCustomID(int customId)
        {
            int groupId;
            DataSet dsCustom = new DataSet();
            dsCustom = objAddOns.GetPublicCallIndexByID(customId);
            groupId = Convert.ToInt32(dsCustom.Tables[0].Rows[0]["Email_GroupIDs"].ToString());
            return groupId;
        }

        private void BindManageContacts()
        {
            try
            {
                int chkContactId, groupId, checkedCount = 0;
                //Get all smartconnect contacts by using usermoduleid
                DataTable dtContacts = new DataTable();
                dtContacts = objAddOns.GetSmartConnectContactsbyUserModuleID(UserModuleID);
                gvManageContacts.DataSource = dtContacts;
                gvManageContacts.DataBind();
                CheckBox chkBxHeader = (CheckBox)gvManageContacts.HeaderRow.FindControl("chkSelectAll");
                if (CustomID > 0)
                {

                    groupId = GetGroupIDByCustomID(CustomID);
                    foreach (GridViewRow row in gvManageContacts.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chkContacts") as CheckBox);
                            chkContactId = Convert.ToInt32((row.Cells[1].FindControl("lblContactID") as Label).Text);
                            int contactExist = objAddOns.CheckPublicAssignGroupToContact(chkContactId, groupId, UserModuleID);
                            if (contactExist > 0)
                            {
                                chkRow.Checked = true;
                                checkedCount++;
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }
                        }
                    }
                    if (checkedCount == gvManageContacts.Rows.Count)
                    {

                        chkBxHeader.Checked = true;
                    }
                    else
                    {
                        chkBxHeader.Checked = false;
                    }
                }
                int chkCount = 0;
                if (Session["tempContactList"] != null)
                {
                    foreach (GridViewRow row in gvManageContacts.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            DataTable dtTempContacts = (DataTable)Session["tempContactList"];
                            CheckBox chkRow = (row.Cells[0].FindControl("chkContacts") as CheckBox);

                            chkContactId = Convert.ToInt32((row.Cells[1].FindControl("lblContactID") as Label).Text);
                            DataRow[] rows = dtTempContacts.Select("ContactID='" + chkContactId + "'");
                            if (rows.Length > 0)
                            {
                                chkRow.Checked = true;
                                chkCount++;
                            }

                            else
                            {
                                chkRow.Checked = false;
                            }
                        }

                    }
                    if (chkCount == gvManageContacts.Rows.Count)
                    {
                        chkBxHeader.Checked = true;
                    }
                    else
                    {
                        chkBxHeader.Checked = false;
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }
        //Search,Clear and Submit for Manage Contacts Popup 
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dtTemp = new DataTable();
                int chkContactId, groupId;
                string fname, lname;
                if (Session["tempContactList"] == null)
                {
                    dtTemp.Clear();
                    dtTemp.Columns.AddRange(new DataColumn[3] { new DataColumn("FirstName"), new DataColumn("LastName"), new DataColumn("ContactID") });
                    foreach (GridViewRow row in gvManageContacts.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            CheckBox chkRow = (row.Cells[0].FindControl("chkContacts") as CheckBox);
                            fname = (row.Cells[1].FindControl("lblFCName") as Label).Text;
                            lname = (row.Cells[1].FindControl("lblLCName") as Label).Text;
                            chkContactId = Convert.ToInt32((row.Cells[1].FindControl("lblContactID") as Label).Text);
                            DataRow[] rows = dtTemp.Select("ContactID='" + chkContactId + "'");
                            if (chkRow.Checked)
                            {
                                if (rows.Length == 0)
                                    dtTemp.Rows.Add(fname, lname, chkContactId);
                            }
                            else
                            {
                                chkRow.Checked = false;
                                foreach (DataRow r in rows)
                                    r.Delete();
                            }
                        }
                    }
                    dtTemp.AcceptChanges();
                    Session["tempContactList"] = dtTemp;
                }

                DataTable dt = new DataTable();
                dt = objAddOns.GetSmartConnectContactsbyUserModuleID(UserModuleID, txtSearch.Text);
                gvManageContacts.DataSource = dt;
                gvManageContacts.DataBind();
                if (CustomID > 0)
                {

                    groupId = GetGroupIDByCustomID(CustomID);
                    foreach (GridViewRow row in gvManageContacts.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chkContacts") as CheckBox);
                            chkContactId = Convert.ToInt32((row.Cells[1].FindControl("lblContactID") as Label).Text);
                            int contactExist = objAddOns.CheckPublicAssignGroupToContact(chkContactId, groupId, UserModuleID);
                            if (contactExist > 0)
                            {
                                if (!string.IsNullOrEmpty(txtSearch.Text))
                                {
                                    chkRow.Checked = false;
                                }
                                else
                                {
                                    chkRow.Checked = true;
                                }
                            }
                            else
                            {
                                chkRow.Checked = false;
                            }

                        }
                    }
                }


                modalContactsList.Show();
            }
            catch (Exception ex)
            {
            }

        }
        protected void btnClear_Click(object sender, EventArgs e)
        {

            try
            {
                txtSearch.Text = "";
                BindManageContacts();
                modalContactsList.Show();
            }
            catch (Exception ex)
            {
            }

        }
        protected void btnContactSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string fname, lname; int cid;
                DataTable dtTemp = new DataTable();
                if (Session["tempContactList"] == null)
                {
                    dtTemp.Clear();
                    dtTemp.Columns.AddRange(new DataColumn[3] { new DataColumn("FirstName"), new DataColumn("LastName"), new DataColumn("ContactID") });
                }
                else
                {
                    dtTemp = (DataTable)Session["tempContactList"];
                }
                foreach (GridViewRow row in gvManageContacts.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        CheckBox chkRow = (row.Cells[0].FindControl("chkContacts") as CheckBox);
                        fname = (row.Cells[1].FindControl("lblFCName") as Label).Text;
                        lname = (row.Cells[1].FindControl("lblLCName") as Label).Text;
                        cid = Convert.ToInt32((row.Cells[1].FindControl("lblContactID") as Label).Text);
                        DataRow[] rows = dtTemp.Select("ContactID='" + cid + "'");
                        if (chkRow.Checked)
                        {
                            if (rows.Length == 0)
                                dtTemp.Rows.Add(fname, lname, cid);
                        }
                        else
                        {
                            chkRow.Checked = false;
                            foreach (DataRow r in rows)
                                r.Delete();
                        }
                    }
                }
                dtTemp.AcceptChanges();
                BindSelectedContacts(dtTemp);
                txtSearch.Text = "";

            }
            catch (Exception ex)
            {
            }
        }
        private void BindSelectedContacts(DataTable dtContacts)
        {
            Session["tempContactList"] = dtContacts;
            grdListContacts.Visible = true;
            grdListContacts.DataSource = Session["tempContactList"];
            grdListContacts.DataBind();
        }
        protected void lnkContacts_Click(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = "";
                modalContactsList.Show();
                BindManageContacts();
            }
            catch (Exception ex)
            {
            }
        }
        //Add Contact
        protected void lnkAddContact_Click(object sender, EventArgs e)
        {
            try
            {
                txtFirstname.Text = "";
                txtLastname.Text = "";
                txtEmail.Text = "";
                txtcompanyname.Text = "";
                txtAddress.Text = "";
                txtCity.Text = "";
                txtState.Text = "";
                txtZipcode.Text = "";
                txtContactPhone.Text = "";
                txtMobile.Text = "";
                txtFax.Text = "";
                txtPosition.Text = "";
                txtOrganization.Text = "";
                BindActiveGroups();
                hdnContactID.Value = "";
                btnContactAdd.Text = "Add";
                chkMobile.Checked = false;
                // chkSendInvitation.Checked = false;
                MPEContacts.Show();
                lblmsg1.Text = "";
            }
            catch (Exception ex)
            {
            }
        }
        private void BindActiveGroups()
        {
            DataSet dsGroups = new DataSet();
            dsGroups = objAddOns.GetPublicCallIndexGroups(UserModuleID);
            if (dsGroups.Tables[0].Rows.Count > 0)
            {
                chkGroupList.DataSource = dsGroups.Tables[0];
                chkGroupList.DataTextField = "GroupName_Count";
                chkGroupList.DataValueField = "GroupID";
                chkGroupList.DataBind();
            }

        }
        protected void btnContactAdd_Click(object sender, EventArgs e)
        {
            string SelectedGroups = string.Empty;
            string UnCheckedGroups = string.Empty;
            int contactID = 0;
            int insertId = 0;
            string contactGroups = "";
            List<int> objExtContactgroups = new List<int>();
            if (!string.IsNullOrEmpty(hdnContactID.Value))
                contactID = Convert.ToInt32(hdnContactID.Value);
            int existingContactId = objAddOns.CheckEmailExistsForPublicCall(txtEmail.Text.Trim(), UserModuleID, contactID, txtMobile.Text.Trim());
            if (existingContactId >= 0)
            {
                contactGroups = objAddOns.GetCallContactGroupsForPublicCallIndex(contactID);
                if (contactGroups != string.Empty)
                {
                    contactGroups = contactGroups.TrimEnd(',');
                    objExtContactgroups = contactGroups.Split(',').Select(int.Parse).ToList();
                }
                if (contactID == 0 && existingContactId > 0)
                    insertId = existingContactId;
                else if (existingContactId == 0)
                    insertId = contactID;
                insertId = objAddOns.InsertUpdatePublicCallContacts(insertId, txtFirstname.Text, txtLastname.Text, txtEmail.Text, txtcompanyname.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZipcode.Text, txtPhone.Text, txtMobile.Text, txtFax.Text, true, false, UserModuleID, ProfileID, UserID, CUserID, txtPosition.Text, txtOrganization.Text, true, false);
                if (insertId > 0)
                {

                    if (chkGroupList.Items.Count > 0)
                    {
                        for (int i = 0; i < chkGroupList.Items.Count; i++)
                        {
                            if (chkGroupList.Items[i].Selected)
                            {
                                if (objExtContactgroups.Contains(Convert.ToInt32(chkGroupList.Items[i].Value.ToString())))
                                    objExtContactgroups.Remove(Convert.ToInt32(chkGroupList.Items[i].Value.ToString()));
                                else
                                    objAddOns.AssignPublicCallIndexGroupContactID(0, Convert.ToInt32(chkGroupList.Items[i].Value), insertId);
                            }
                        }
                    }
                    if (contactID == 0 && existingContactId > 0)
                        objExtContactgroups = new List<int>();
                    if (objExtContactgroups.Count > 0)
                    {
                        for (int i = 0; i < objExtContactgroups.Count; i++)
                        {
                            objAddOns.AssignPublicCallIndexGroupContactID(1, objExtContactgroups[i], contactID);
                        }
                    }
                    hdnContactID.Value = "";

                    if (btnContactAdd.Text == "Add")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Contact Saved Successfully')", true);
                        // *** Adding new contact to current group *** //
                        DataTable dtSelContacts = new DataTable();
                        if (Session["tempContactList"] == null)
                        {
                            dtSelContacts.Clear();
                            if (Session["ContentContacts"] != null)
                                dtSelContacts = (DataTable)Session["ContentContacts"];
                            else
                                dtSelContacts.Columns.AddRange(new DataColumn[3] { new DataColumn("FirstName"), new DataColumn("LastName"), new DataColumn("ContactID") });
                        }
                        else
                        {
                            dtSelContacts = (DataTable)Session["tempContactList"];
                        }
                        dtSelContacts.Rows.Add(txtFirstname.Text, txtLastname.Text, insertId);
                        dtSelContacts.AcceptChanges();
                        BindSelectedContacts(dtSelContacts);
                    }

                }
                else
                {
                    MPEContacts.Show();
                }
            }
            else
            {
                if (existingContactId == -2)
                    lblmsg1.Text = Resources.LabelMessages.DuplicateEmail;
                MPEContacts.Show();
            }

        }

        [System.Web.Services.WebMethod]
        public static string Insert_SearchCategory(string CatName, string CatDescription)
        {
            string returnStr = "";
            BusinessBLL objBus = new BusinessBLL();

            try
            {
                int catID = objBus.Insert_Update_SmartConnectCategory(0, CatName, CatDescription, Convert.ToInt32(HttpContext.Current.Session["CustomModuleID"].ToString()), Convert.ToInt32(HttpContext.Current.Session["ProfileID"].ToString()), Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString()), SmartConnectCategoryType.User.ToString());
                returnStr = catID.ToString();
            }
            catch (Exception ex)
            {
                returnStr = "failure";

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

                //Error 
                objInBuiltData.ErrorHandling("ERROR", "PublicCallIndexAutoMessage.aspx.cs", "Insert_SearchCategory", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return returnStr;
        }
    }
}