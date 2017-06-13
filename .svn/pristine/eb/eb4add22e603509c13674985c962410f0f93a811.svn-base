using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace USPDHUB.Business.MyAccount
{
    public partial class LandingPage : System.Web.UI.Page
    {
        public string RootPath = "";
        public string DomainName = "";
        public string LogoName = "";
        public string App_DisplayName = "";

        public string verticalName = "";

        public string agencyType = "organization";
        public string lbltext = "a tip";

        protected void Page_Load(object sender, EventArgs e)
        {
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();

            LogoName = Page.ResolveClientUrl("~/images/VerticalLogos/") + DomainName + "logo.png";

            /*** App Display Name  ***/
            if (DomainName.ToLower().Contains("uspdhub"))
            {
                App_DisplayName = Convert.ToString(ConfigurationManager.AppSettings.Get("UspdhubAppName"));
                verticalName = "uspdhub";
                agencyType = "agency";
            }
            else if (DomainName.ToLower().Contains("twovie"))
            {
                App_DisplayName = Convert.ToString(ConfigurationManager.AppSettings.Get("TwovieAppName"));
                verticalName = "twovie";
                lbltext = "feedback";
            }
            else if (DomainName.ToLower().Contains("myyouth"))
            {
                App_DisplayName = Convert.ToString(ConfigurationManager.AppSettings.Get("MyYouthHubAppName"));
                verticalName = "myyouthhub";
                lbltext = "feedback";
            }
            else if (DomainName.ToLower().Contains("inschoolhub"))
            {
                App_DisplayName = Convert.ToString(ConfigurationManager.AppSettings.Get("InschoolhubAppName"));
                verticalName = "inschoolhub";
                agencyType = "school";
                lbltext = "feedback";
            }
            else
                App_DisplayName = Convert.ToString(ConfigurationManager.AppSettings.Get("UspdhubAppName"));


        }

        protected void btncontinue_OnClick(object sender, EventArgs e)
        {
            string urlinfo1 = Page.ResolveClientUrl("~/Business/Myaccount/Default.aspx");
            Response.Redirect(urlinfo1);
        }

    }
}