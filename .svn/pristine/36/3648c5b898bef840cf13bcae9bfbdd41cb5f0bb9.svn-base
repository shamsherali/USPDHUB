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
    public partial class ManageSponsorAdUsers : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        DataTable dtSponserAdUsers;
        BusinessBLL objBusinessBLL = new BusinessBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
          
        }

        protected void bindGrid()
        {
            dtSponserAdUsers = objBusinessBLL.GetSponsorAdUsers();
            grdSponsorAdUsers.DataSource = dtSponserAdUsers;
            grdSponsorAdUsers.DataBind();
        }

        protected void btnManageAds_Click(object sender, EventArgs e)
        {
            Button btnManageAds = (Button)sender as Button;

            string[] commandArgs = btnManageAds.CommandArgument.ToString().Split(new char[] { ',' });
            UserID = Convert.ToInt32(commandArgs[0]);
            ProfileID = Convert.ToInt32(commandArgs[1]);
            Session["UserID"] = UserID;
            Session["ProfileID"] = ProfileID;
            string redirectURL = "SponsorAdsPreview.aspx?userid=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&profileid=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString());
            Response.Redirect(redirectURL);

        }

        protected void grdSponsorAdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSponsorAdUsers.PageIndex = e.NewPageIndex;
            bindGrid();
        }
    }
}