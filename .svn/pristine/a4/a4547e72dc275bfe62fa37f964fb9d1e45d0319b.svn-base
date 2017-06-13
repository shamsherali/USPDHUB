using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.IO;
using System.Text;
using System.Drawing;


namespace USPDHUB.Business.MyAccount
{
    public partial class SendInvitation : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;
        public bool IsSuperAdmin = true;
        BusinessBLL objBus = new BusinessBLL();
        AgencyBLL objAgency = new AgencyBLL();
        CommonBLL objCommon = new CommonBLL();
        DataTable dtInvitations = new DataTable();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public string DomainName = "";
        public bool IsBlockedSendAccess = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    UserID = Convert.ToInt32(Session["UserID"]);
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);

                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                        C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        C_UserID = UserID;
                }
                DomainName = Session["VerticalDomain"].ToString();
                lblsuccess.Text = "";
                if (!IsPostBack)
                {
                    DataTable dtProfiles = objBus.GetProfileDetailsByProfileID(ProfileID);
                    if (!string.IsNullOrEmpty(dtProfiles.Rows[0]["Parent_ProfileID"].ToString()))
                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
                    if (Session["C_USER_ID"] != null)
                    {
                        IsBlockedSendAccess = objCommon.GetPermissionAccess(Convert.ToInt32(Session["C_USER_ID"]), PageNames.BLOCKEDSENDERS);
                        DataTable dtUserDetails = objBus.GetUserDtlsByUserID(Convert.ToInt32(Session["C_USER_ID"]));
                        if (!string.IsNullOrEmpty(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"].ToString()))
                            IsSuperAdmin = Convert.ToBoolean(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"]);
                    }
                    BindInvitations();
                    if (Session["SubAppReqCodesSuccessMsg"] != null)
                    {
                        string ReqSuccessMessage = (string)(Session["SubAppReqCodesSuccessMsg"]);
                        lblsuccess.Text = ReqSuccessMessage;
                        Session["SubAppReqCodesSuccessMsg"] = null;
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitation.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BindInvitations()
        {
            try
            {
                dtInvitations = objAgency.GetActiveInvitations(ProfileID);
                if (dtInvitations.Rows.Count > 0)
                    Session["DtInvitations"] = dtInvitations;
                InvitationGrid.DataSource = dtInvitations;
                InvitationGrid.DataBind();

                DataTable dtSubApps = objAgency.GetSubAppsByPID(ProfileID);
                if (dtSubApps.Rows.Count > 0)
                { btnViewApps.Visible = true; }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitation.aspx.cs", "BindInvitations", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void lnkSend_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtFirtsName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string msgBody = txtMessage.Text.Trim().Replace("\n\r", "<br/>").Replace("\n", "<br/>");
                int codeID = Convert.ToInt32(hdnCommandArg.Value);
                bool isModalHide = false;
                bool isSendinv = false;
                int affID = 0;
                if (hdnResend.Value == "")
                {
                    if (objAgency.CheckSendInvitationEmail(email) == 0) // *** 0 means not send yet *** //
                    {
                        affID = objAgency.AddInvitation(firstName, lastName, email, ProfileID, C_UserID, codeID);
                        if (affID > 0)
                        {
                            isSendinv = true;
                            BindInvitations();
                            txtEmail.Text = "";
                            txtFirtsName.Text = "";
                            txtLastName.Text = "";
                            txtMessage.Text = "";
                            lblsuccess.Text = "<font color='green' size='2'>" + Resources.LabelMessages.SubInvitationSuccess + "</font>";
                            isModalHide = true;
                            hdnCommandArg.Value = "";
                        }
                        else
                            lblerror.Text = "<font color='red' size='2'>" + Resources.LabelMessages.SubInvitationFailed + "</font>";
                    }
                    else
                        lblerror.Text = "<font color='red' size='2'>" + Resources.LabelMessages.AlreadySent.Replace("##Email##", email) + "</font>";
                }
                else
                {
                    isModalHide = true;
                    isSendinv = true;
                    affID = codeID;
                    lblsuccess.Text = "<font color='green' size='2'>" + Resources.LabelMessages.ResendSuccess + "</font>";
                }
                if (isSendinv)
                    SendSubInvitation(affID, email, msgBody);
                if (isModalHide == false)
                    modalSend.Show();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitation.aspx.cs", "lnkSend_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnRequestCodes_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["ShoppingCartRootPath"] + "/RedirectPage.aspx?MID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&MPID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString()) + "&CID=" + EncryptDecrypt.DESEncrypt(C_UserID.ToString()) + "&VC=" + EncryptDecrypt.DESEncrypt(DomainName) + "&ReqType=2&RType=2");
        }
        private void SendSubInvitation(int affID, string email, string msgBody)
        {
            try
            {
                string emailInfo = "";
                DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                            emailInfo = row[1].ToString();
                    }
                }
                string secureRootPath = "";
                DataTable dtConfigs = objCommon.GetVerticalConfigsByType(DomainName, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "SRootPath")
                            secureRootPath = row[1].ToString();
                    }
                }
                string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
                StreamReader re = File.OpenText(strfilepath + "SubInvitationEmail.txt");
                StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
                string msgbody = string.Empty;
                string content = string.Empty;
                string desclaimer = string.Empty;
                while ((desclaimer = reDeclaimer.ReadLine()) != null)
                {
                    msgbody = msgbody + desclaimer;
                }
                desclaimer = "";
                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    content = content + input + "<BR/>";
                }
                re.Close();
                re.Dispose();
                msgbody = msgbody.Replace("#RootUrl#", Session["RootPath"].ToString());
                msgbody = msgbody.Replace("#msgBody#", content);
                msgbody = msgbody.Replace("#MessageBody#", msgBody);
                msgbody = msgbody.Replace("#InvitationLink#", "<a href='" + secureRootPath + "/OP/" + DomainName + "/AgencyListing.aspx?AID=" + EncryptDecrypt.DESEncrypt(affID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "' target=_new>" + secureRootPath + "/OP/" + DomainName + "/AgencyListing.aspx?AID=" + EncryptDecrypt.DESEncrypt(affID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "</a>");

                reDeclaimer.Close();
                reDeclaimer.Dispose();
                USPDHUBBLL.UtilitiesBLL utlobj = new USPDHUBBLL.UtilitiesBLL();
                utlobj.SendWowzzyEmail(emailInfo, email, "Registration Invitation", msgbody, "", "", DomainName);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitation.aspx.cs", "SendSubInvitation", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void InvitationGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblStatus = e.Row.FindControl("lblStatus") as Label;
                    LinkButton lnkStatus = e.Row.FindControl("lnkStatus") as LinkButton;
                    LinkButton lnkResend = e.Row.FindControl("lnkResend") as LinkButton;
                    LinkButton lnkCancel = e.Row.FindControl("lnkCancel") as LinkButton;

                    lblStatus.Visible = true;
                    lnkStatus.Visible = false;
                    lnkCancel.Visible = false;
                    lnkResend.Visible = false;
                    lblStatus.ForeColor = Color.Green;
                    if (lblStatus.Text == "Invite")
                    {
                        lblStatus.Visible = false;
                        lnkStatus.Visible = true;
                    }
                    else if (lblStatus.Text == "Invited")
                    {
                        lnkCancel.Visible = true;
                        lnkResend.Visible = true;
                        lblStatus.ForeColor = ColorTranslator.FromHtml("#9E3B33");
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitation.aspx.cs", "InvitationGrid_RowDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void InvitationGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtInvitations = (DataTable)Session["DtInvitations"];
            InvitationGrid.PageIndex = e.NewPageIndex;
            InvitationGrid.DataSource = dtInvitations;
            InvitationGrid.DataBind();
        }
        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            LinkButton lnkCancel = sender as LinkButton;
            objAgency.CancelInvitation(Convert.ToInt32(lnkCancel.CommandArgument), C_UserID);
            lblsuccess.Text = Resources.LabelMessages.InvitationCancelled;
            BindInvitations();
        }
        protected void lnkStatus_Click(object sender, EventArgs e)
        {
            LinkButton lnkStatus = sender as LinkButton;
            hdnCommandArg.Value = lnkStatus.CommandArgument;
            hdnResend.Value = "";
            BindMessage(Convert.ToInt32(hdnCommandArg.Value));
            EnableBoxes(true);
        }
        protected void lnkResend_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkStatus = sender as LinkButton;
                hdnCommandArg.Value = lnkStatus.CommandArgument;
                DataTable dtAffiliate = objAgency.GetInvitationDetailsByID(Convert.ToInt32(hdnCommandArg.Value));
                hdnResend.Value = "1"; // 1 means user trying to resend the same invitation *** //            
                txtMessage.Text = "";
                BindMessage(Convert.ToInt32(dtAffiliate.Rows[0]["InvitationCodeID"].ToString()));
                EnableBoxes(false);
                txtEmail.Text = dtAffiliate.Rows[0]["Email_Address"].ToString();
                txtFirtsName.Text = dtAffiliate.Rows[0]["First_Name"].ToString();
                txtLastName.Text = dtAffiliate.Rows[0]["Last_Name"].ToString();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitation.aspx.cs", "lnkResend_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BindMessage(int invCodeID)
        {
            try
            {
                string strBuild = "";
                string strPaid = "";
                string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
                StreamReader re = File.OpenText(strfilepath + "SubInvitation.txt");
                string desclaimer = string.Empty;
                while ((desclaimer = re.ReadLine()) != null)
                {
                    strBuild = strBuild + desclaimer + "\n";
                }
                string secureRootPath = "";
                DataTable dtConfigs = objCommon.GetVerticalConfigsByType(DomainName, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "SRootPath")
                            secureRootPath = row[1].ToString();
                    }
                }
                DataTable dtPaid = objAgency.GetInvitatioCodeDetailsByID(invCodeID);
                if (Convert.ToBoolean(dtPaid.Rows[0]["IsPaid"].ToString()))
                    strPaid = ConfigurationManager.AppSettings["IsPaidApp"];
                DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                strBuild = strBuild.Replace("#OrganizationOwner#", dtProfile.Rows[0]["Profile_name"].ToString()).Replace("#PaidApp#", strPaid);
                lblerror.Text = "";
                txtMessage.Text = strBuild.ToString();
                lblLink.Text = secureRootPath + "/OP/" + DomainName + "/AgencyListing.aspx?AID=" + EncryptDecrypt.DESEncrypt(hdnCommandArg.Value).Replace("=", "irhmalli").Replace("+", "irhPASS");
                txtFirtsName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                re.Close();
                re.Dispose();
                modalSend.Show();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitation.aspx.cs", "BindMessage", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void EnableBoxes(bool flag)
        {
            txtEmail.Enabled = flag;
            txtFirtsName.Enabled = flag;
            txtLastName.Enabled = flag;
        }

        protected void btnViewApps_OnClick(object sender, EventArgs e)
        {
            DataTable dtSubApps = objAgency.GetSubAppsByPID(ProfileID);
            grdSubApps.DataSource = dtSubApps;
            grdSubApps.DataBind();

            modalPopupSubapp.Show();
        }


    }
}