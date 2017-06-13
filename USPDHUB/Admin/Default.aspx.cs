using System;
using USPDHUBBLL;
using System.Configuration;
using System.Web;

namespace USPDHUB.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        AdminBLL objAdmin = new AdminBLL();
        public string RootPath = "";
        CommonBLL cmbobj = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Get Domain Name *** //
                if (Session["VerticalDomain"] == null)
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    cmbobj.CreateDomainUrl(url);
                }

                RootPath = Session["RootPath"].ToString();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkUserManagement_Click(object sender, EventArgs e)
        {
            lblHeader.Text = Resources.AdminResource.UserManagement;
            hdnPage.Value = "ConsumerManagement.aspx";
            mpeCheckPermission.Show();
        }
        protected void lnkSalesPeople_Click(object sender, EventArgs e)
        {
            lblHeader.Text = Resources.AdminResource.SalesPeople;
            hdnPage.Value = "ManageSalesPeople.aspx";
            mpeCheckPermission.Show();
        }
        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text.Trim();
                string password = txtPassword.Text.Trim();
                int validUser = objAdmin.CheckAdminUser(userName, password);
                if (validUser == 1)
                    Response.Redirect(RootPath + "/Admin/" + hdnPage.Value);
                else
                {
                    lblerror.Text = Resources.AdminResource.AdminCheckFailed;
                    mpeCheckPermission.Show();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "btnSumbit_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void ClearValues()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            lblerror.Text = "";
            hdnPage.Value = "";
        }
    }
}