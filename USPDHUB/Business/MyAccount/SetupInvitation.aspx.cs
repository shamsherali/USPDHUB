using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;

namespace USPDHUB.Business.MyAccount
{
    public partial class SetupInvitation : System.Web.UI.Page
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public int CUserID = 0;
        public bool IsAdmin = true;
        public string DomainName = "";
        BusinessBLL objBus = new BusinessBLL();
        AgencyBLL objAgency = new AgencyBLL();
        CommonBLL objCommon = new CommonBLL();
        public bool IsDownloadAccess = true;
        public string RootPath = "";
        AddOnBLL objAddOn = new AddOnBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public int UserModuleID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                if (Session["CustomModuleID"] == null)
                {
                    Response.Redirect(RootPath + "/Business/MyAccount/Default.aspx");
                }
                UserModuleID = Convert.ToInt32(Session["CustomModuleID"]);
                if (!IsPostBack)
                {
                    DataTable dtAddOn = objAddOn.GetAddOnById(UserModuleID);
                    if (dtAddOn.Rows.Count == 1)
                    {
                        lblButtonName.Text = dtAddOn.Rows[0]["TabName"].ToString();
                        if (dtAddOn.Rows[0]["ButtonType"].ToString() == WebConstants.Tab_PrivateContentAddOns)
                        {
                            //hdnIsPrivateModule.Value = "1";
                        }
                    }

                    #region  roles & permissions..
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "PrivateInvitation");
                        if (hdnPermissionType.Value == "A")
                        {
                            // IsHasPrivilege = false;
                            lblstatusmessage.Text = "<font face=arial size=2 color=red>" + Resources.ProfileAccessMessages.PrivateInvotationNoAccess + "</font>";
                            pnlSetup.Visible = false;
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SetupInvitation.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnSetupcontact_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(RootPath + "/Business/MyAccount/ManageContacts.aspx?IsScr=1");
        }

        protected void btnSendInvitation_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(RootPath + "/Business/MyAccount/SendInvitationPrivateModule.aspx");
        }

        protected void btnManageInvitation_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(RootPath + "/Business/MyAccount/ManagePrivateInvitations.aspx");
        }

    }
}