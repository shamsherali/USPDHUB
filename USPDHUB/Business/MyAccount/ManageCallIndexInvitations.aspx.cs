using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageCallIndexInvitations : BaseWeb
    {
        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;

        public string RootPath = "";
        public string DomainName = "";
        public int SortDir = 0;
        public USPDHUBBLL.PrivateModuleBLL objPrivateModuleBLL = new USPDHUBBLL.PrivateModuleBLL();
        CommonBLL objCommonBLL = new CommonBLL();
        DataTable dtInvitations = new DataTable("dt");
        AddOnBLL objAddOn = new AddOnBLL();
        public int UserModuleID = 0;

        public string InvitateeUsername = "";

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


            UserModuleID = Convert.ToInt32(Session["CustomModuleID"]);
            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            C_UserID = UserID;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                C_UserID = Convert.ToInt32(Session["C_USER_ID"]);

            lblMessage1.Text = "";
            lblmess.Text = "";

            if (!IsPostBack)
            {
                hdnsortdire.Value = "";
                hdnsortcount.Value = "0";
                BindInvitaions();

                DataTable dtAddOn = objAddOn.GetAddOnById(UserModuleID);
                //ltrlTitleImage.Text = "<img style='width:auto;height:auto;vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtAddOn.Rows[0]["AppIcon"].ToString() + ".png'/>";
                if (dtAddOn.Rows.Count == 1)
                {
                    hdnAddOnName.Value = dtAddOn.Rows[0]["TabName"].ToString();
                    if (dtAddOn.Rows[0]["ButtonType"].ToString() == WebConstants.Tab_PrivateContentAddOns)
                    {
                        //hdnIsPrivateModule.Value = "1";
                    }
                }

            }


        }


        private void BindInvitaions()
        {
            dtInvitations = objPrivateModuleBLL.GetPrivateModuleInvitaions(ProfileID, UserModuleID);
            GrdInviters.DataSource = null;
            GrdInviters.DataSource = dtInvitations;
            Session["dtInvitations"] = dtInvitations;
            GrdInviters.DataBind();
        }

        protected void GrdInviters_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblIsActive = e.Row.FindControl("lblIsActive") as Label;
                LinkButton lnkDisable = e.Row.FindControl("lnkDisable") as LinkButton;

                LinkButton lnkDeviceCount = e.Row.FindControl("lnkDeviceCount") as LinkButton;
                //lnkDeviceCount.Text = "<span style=\"background: url(../../images/Dashboard/side_icons.png) no-repeat 6px 5px;\">View (" + lnkDeviceCount.Text + ")</span> ";
                lnkDeviceCount.Text = "View (" + lnkDeviceCount.Text + ")";

                if (Convert.ToBoolean(lblIsActive.Text))
                {
                    lblIsActive.Text = "Active";
                    lnkDisable.Text = "Disable";
                }
                else
                {
                    lblIsActive.Text = "Inactive";
                    lnkDisable.Text = "Enable";
                }



            }
        }

        protected void GrdInviters_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtInvitations = (DataTable)Session["dtInvitations"];
            GrdInviters.PageIndex = e.NewPageIndex;
            GrdInviters.DataSource = dtInvitations;
            GrdInviters.DataBind();
        }
        protected void GrdInviters_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDir = Convert.ToInt32(hdnsortcount.Value);
            string SortExp = e.SortExpression.ToString();
            dtInvitations = (DataTable)Session["dtInvitations"];
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
            DataView Dv = new DataView(dtInvitations);
            if (SortDir == 0)
            {
                if (SortExp == "FirstName")
                {
                    Dv.Sort = "FirstName DESC";
                }
                else if (SortExp == "LastName")
                {
                    Dv.Sort = "LastName DESC";
                }
                else if (SortExp == "Email")
                {
                    Dv.Sort = "EmailID DESC";
                }
                else if (SortExp == "Status")
                {
                    Dv.Sort = "IsActive DESC";
                }
                hdnsortcount.Value = "1";
            }
            else
            {
                if (SortExp == "FirstName")
                {
                    Dv.Sort = "FirstName ASC";
                }
                else if (SortExp == "LastName")
                {
                    Dv.Sort = "LastName ASC";
                }
                else if (SortExp == "Email")
                {
                    Dv.Sort = "EmailID ASC";
                }
                else if (SortExp == "Status")
                {
                    Dv.Sort = "IsActive ASC";
                }
                hdnsortcount.Value = "0";
            }
            Session["dtInvitations"] = Dv.ToTable();
            GrdInviters.DataSource = Dv;
            GrdInviters.DataBind();
        }
        protected void btnSendInviation_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(RootPath + "/Business/MyAccount/SendCallIndexInvitation.aspx");
        }

        protected void lnkDelete_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkDelete = sender as LinkButton;
            int InviterID = Convert.ToInt32(lnkDelete.CommandArgument);
            objPrivateModuleBLL.InvitationsAction("DELETE", 0, true, InviterID);
            lblmess.Text = "<font color='red'>" + Resources.LabelMessages.PrivateinvitationDeleteMSG + "</font>";
            BindInvitaions();

        }

        protected void lnkDisable_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkDisable = sender as LinkButton;
            int InviterID = Convert.ToInt32(lnkDisable.CommandArgument);
            if (lnkDisable.Text == "Enable")
            {
                lblmess.Text = Resources.LabelMessages.PrivateInvitationEnableMSG.ToString();
                objPrivateModuleBLL.InvitationsAction("DISABLE", 0, true, InviterID);
            }
            else
            {
                lblmess.Text = Resources.LabelMessages.PrivateInvitationDisableMSG.ToString();
                objPrivateModuleBLL.InvitationsAction("ENABLE", 0, false, InviterID);
            }
            BindInvitaions();


        }

        protected void lnkResend_OnClick(object sender, EventArgs e)
        {
            try
            {
                //Log
                objInBuiltData.ErrorHandling("LOG", "EditBulletin.aspx.cs", "Page_Load", string.Empty, string.Empty, string.Empty, string.Empty);

                LinkButton lnkResend = sender as LinkButton;
                int inviteesID = Convert.ToInt32(lnkResend.CommandArgument);

                string pOTP = Guid.NewGuid().ToString();
                // Invitations Details
                int invitationID = objPrivateModuleBLL.Insert_Update_Invitation(inviteesID, "Invited", string.Empty, string.Empty,
                    pOTP, string.Empty, 0, UserModuleID, ProfileID, "", ButtonTypes.PrivateCall);

                GridViewRow gvr = (GridViewRow)lnkResend.NamingContainer;
                string mobileNumber = Convert.ToString(GrdInviters.DataKeys[gvr.RowIndex].Value);

                objCommonBLL.SendPrivateModule_InvitationMails("", DomainName, invitationID.ToString(), ProfileID, "", UserID, RootPath, mobileNumber,true);

                BindInvitaions();
                lblmess.Text = "<font color='green' size='3'>" + Resources.LabelMessages.PrivateInvitationSentMSG.ToString() + "</font>";

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EditBulletin.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkDeviceCount_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkDisable = sender as LinkButton;
            int InviterID = Convert.ToInt32(lnkDisable.CommandArgument);
            Session["InviterID"] = InviterID;


            GridViewRow row = (GridViewRow)lnkDisable.NamingContainer;
            Label lblFirstName = (Label)row.FindControl("lblFirstName");
            // Label lblLastName = (Label)row.FindControl("lblLastName");


            lblx.Text = lblFirstName.Text;// +" " + lblLastName.Text;
            LoadEachDeviceStatusDetails();
        }

        #region Each Device Details with Action in Modal Popup

        protected void lnkDelete1_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkDelete = sender as LinkButton;
            int InvitationID = Convert.ToInt32(lnkDelete.CommandArgument);
            objPrivateModuleBLL.InvitationsAction("DELETE", InvitationID, true, 0);

            LoadEachDeviceStatusDetails();

            lblMessage1.Text = "<font color='red' size='3'>" + Resources.LabelMessages.PrivateInvitationDelete.ToString() + "</font>"; ;
        }

        protected void lnkDisable1_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkDisable = sender as LinkButton;
            int InvitationID = Convert.ToInt32(lnkDisable.CommandArgument);
            if (lnkDisable.Text == "Enable")
            {
                objPrivateModuleBLL.InvitationsAction("ENABLE", InvitationID, true, 0);
                lblMessage1.Text = "<font color='green' size='3'>" + Resources.LabelMessages.PrivateInvitationDeviceEnable.ToString() + "</font>"; ;
            }
            else
            {
                objPrivateModuleBLL.InvitationsAction("DISABLE", InvitationID, false, 0);
                lblMessage1.Text = "<font color='green' size='3'>" + Resources.LabelMessages.PrivateInvitationDeviceDisable.ToString() + "</font>"; ;
            }

            LoadEachDeviceStatusDetails();

        }

        protected void Grd_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblIsActive = e.Row.FindControl("lblIsActive") as Label;
                Label lblIsEnable = e.Row.FindControl("lblIsEnable") as Label;
                Label lblStatus = e.Row.FindControl("lblStatus") as Label;
                LinkButton lnkDisable = e.Row.FindControl("lnkDisable1") as LinkButton;
                Label lblOTP = e.Row.FindControl("lblOTP") as Label;

                if (lblStatus.Text == PrivateModule_InvitedStatus.CancelledStatus.ToString())
                {
                    lnkDisable.Visible = false;
                }
                else
                {
                    lnkDisable.Visible = true;
                }

                if (lblStatus.Text.Trim() == PrivateModule_InvitedStatus.CancelledStatus.ToString())
                {
                    lblStatus.Text = PrivateModule_InvitedStatus.CancelledStatus.ToString();
                }
                else if (Convert.ToBoolean(lblIsEnable.Text) == false)
                {
                    lblStatus.Text = PrivateModule_InvitedStatus.DisabledStatus.ToString();
                }
                else if (Convert.ToBoolean(lblIsEnable.Text) == true && lblOTP.Text.Trim() == string.Empty)
                {
                    lblStatus.Text = "Enabled"; //PrivateModule_InvitedStatus.AcceptedStatus.ToString();
                }
                else if (Convert.ToBoolean(lblIsEnable.Text) == true && lblOTP.Text.Trim() != string.Empty)
                {
                    lblStatus.Text = PrivateModule_InvitedStatus.InvitedStatus.ToString();
                }

                if (Convert.ToBoolean(lblIsEnable.Text))
                {
                    lnkDisable.Text = "Disable";
                }
                else
                {
                    lnkDisable.Text = "Enable";
                }



            }
        }

        #endregion

        private void LoadEachDeviceStatusDetails()
        {
            DataTable dtInvitation1 = objPrivateModuleBLL.GetInvitationsByInvitorID(Convert.ToInt32(Session["InviterID"]));
            grdDeviceDetails.DataSource = dtInvitation1;
            grdDeviceDetails.DataBind();

            lblMessage1.Text = "";
            lblmess.Text = "";
            ModalPopupExtender1.Show();
        }

        protected void btnDashboard_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(RootPath + "/Business/MyAccount/default.aspx");
        }

        protected void btnSepupInvitations_OnClick(object sender, EventArgs e)
        {
            if (Request.QueryString["retflag"] != null && Convert.ToString(Request.QueryString["retflag"]) == "1")
                Response.Redirect(RootPath + "/Business/MyAccount/SendCallIndexInvitation.aspx");
            Response.Redirect(RootPath + "/Business/MyAccount/SetupCallIndexInvitation.aspx");
        }

        protected void btn_OnClick(object sender, EventArgs e)
        {
            BindInvitaions();
            ModalPopupExtender1.Hide();
        }

    }
}