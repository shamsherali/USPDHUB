using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB.Admin
{
    public partial class UpdateUserAppVersion : System.Web.UI.Page
    {
        AdminBLL adminobj = new AdminBLL();
        BusinessBLL objBusinessBLL = new BusinessBLL();
        DataTable dtBranded;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["adminuserid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                lblerror.Text = "";
                if (!IsPostBack)
                {
                    ShowPanels(true);
                    GetSearchDetails();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "UpdateUserAppVersion.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void DrpcategorySelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPanels(true);
            txtcategory.Text = "";
        }
        protected void BtnClick(object sender, EventArgs e)
        {
            GetSearchDetails();
            ShowPanels(true);
        }
        private void GetSearchDetails()
        {
            try
            {
                int? UserId = null;
                string profileName = "";
                int selCategoryID = Convert.ToInt32(drpcategory.SelectedValue.ToString());
                Session["BrandedAppV"] = null;
                if (selCategoryID == 1)
                    UserId = Convert.ToInt32(txtcategory.Text.Trim());
                else if (selCategoryID == 6)
                    profileName = txtcategory.Text.Trim();
                dtBranded = adminobj.GetBrandedAppUsers("", UserId, profileName);
                if (dtBranded.Rows.Count > 0)
                    Session["BrandedAppV"] = dtBranded;
                GrdBrandedApps.DataSource = dtBranded;
                GrdBrandedApps.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "UpdateUserAppVersion.aspx.cs", "GetSearchDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnUpdateVersion_Click(object sender, EventArgs e)
        {
            try
            {
                adminobj.UpdateMemberAppVersion(Convert.ToInt32(hdnSelectId.Value), txtNewVersion.Text.Trim());
                lblerror.Text = "<font color='green'>" + Resources.AdminResource.VerionUpdateSuccess + "</font>";
                CallSearch();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "UpdateUserAppVersion.aspx.cs", "btnUpdateVersion_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void GrdBrandedApps_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtBranded = (DataTable)Session["BrandedAppV"];
                GrdBrandedApps.PageIndex = e.NewPageIndex;
                GrdBrandedApps.DataSource = dtBranded;
                GrdBrandedApps.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "UpdateUserAppVersion.aspx.cs", "GrdBrandedApps_PageIndexChanging", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void ShowPanels(bool showType)
        {
            pnlBrandedApps.Visible = showType;
            pnlMember.Visible = showType == true ? false : true;
        }
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkEditV = sender as LinkButton;
                hdnSelectId.Value = lnkEditV.CommandArgument.ToString();
                DataTable dtBrandedOrder = objBusinessBLL.GetBrandedAppOrderStatusDetails(Convert.ToInt32(hdnSelectId.Value));
                if (dtBrandedOrder.Rows.Count > 0)
                {
                    lblMemberId.Text = Convert.ToString(dtBrandedOrder.Rows[0]["UserID"]);
                    lblCurrentVersion.Text = Convert.ToString(dtBrandedOrder.Rows[0]["App_Version"]);
                }
                ShowPanels(false);
                txtNewVersion.Text = "";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "UpdateUserAppVersion.aspx.cs", "lnkEdit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CallSearch();
        }
        private void CallSearch()
        {
            try
            {
                ShowPanels(true);
                drpcategory.SelectedIndex = 0;
                txtcategory.Text = "";
                GetSearchDetails();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "UpdateUserAppVersion.aspx.cs", "CallSearch", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}