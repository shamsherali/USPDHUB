using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using USPDHUBBLL;
using USPDHUBDAL;

namespace USPDHUB.Business.MyAccount
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnSubAppsCount.Value = System.Configuration.ConfigurationManager.AppSettings.Get("SubAppsCount").ToString();
            if (!IsPostBack)
            {

            }
        }

        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/CheckStore.aspx"));
        }

        protected void lnkPay_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessDAL.SubAppsBilling objSubAppsBilling = new BusinessDAL.SubAppsBilling();
                objSubAppsBilling.NumberofSubApps = Convert.ToInt32(txtSubAppsCount.Text);
                objSubAppsBilling.SubAppsAmount = Convert.ToInt32(txtSubAppsBill.Text);
                Session["SubAppsBilling"] = objSubAppsBilling;
                Response.Redirect("EnhanceBill.aspx?Type=43dHWwwJOs8=");
            }
            catch (Exception ex)
            {
                //Error 
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "Checkout.aspx.cs", "lnkPay_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}