using System;
using System.Linq;
using System.Configuration;


namespace UserForms
{
    public partial class PaidTools : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Free"] != null)
                {
                    string prevPage = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : ConfigurationManager.AppSettings.Get("RootPath") + "/Business/MyAccount/Default.aspx";
                    Response.Redirect(prevPage);
                }
            }
        }
    }
}