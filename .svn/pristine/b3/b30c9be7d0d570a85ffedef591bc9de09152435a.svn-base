using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Configuration;
using System.Data;

namespace USPDHUB.OP.inschoolhubcom
{
    public partial class AddTools : System.Web.UI.Page
    {
        public string RootPath = "";
        CommonBLL objCommon = new CommonBLL();
        public string EncryptAffilateID = string.Empty;
        public string SaleCode = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            // *** Get Domain Name *** //
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }
            RootPath = Session["RootPath"].ToString();
            if (!string.IsNullOrEmpty(Request.QueryString["AID"]))
            {
                EncryptAffilateID = Request.QueryString["AID"].ToString();

            }
            if (!string.IsNullOrEmpty(Request.QueryString["SC"]))
            {
                SaleCode = Request.QueryString["SC"].ToString();
            }
        }
        protected void lnkSubscription_Click(object sender, EventArgs e)
        {

            LinkButton lnkSubscription = sender as LinkButton;
            string urlRedirect = ConfigurationManager.AppSettings.Get("ShoppingCartRootPath") + "/RedirectStore.aspx?VC=" + EncryptDecrypt.DESEncrypt(Session["VerticalDomain"].ToString())
                                                + "&IsSignUp=" + EncryptDecrypt.DESEncrypt("true") + "&PackID=" + lnkSubscription.CommandArgument + "&SC=" + EncryptDecrypt.DESEncrypt(SaleCode);
            Response.Redirect(urlRedirect);
        }
    }
}