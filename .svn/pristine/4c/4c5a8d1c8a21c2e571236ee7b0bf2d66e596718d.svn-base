using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;

namespace USPDHUB.OP.myyouthhubcom
{
    public partial class Login : System.Web.UI.Page
    {
        public static int ProfileID = 0;
        public string Mynetwork = string.Empty;
        CommonBLL objCommon = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["VerticalDomain"] = "localhost";
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }
            //Assign session for menulinks change
            Session["Menulinkspagename"] = "loginpage";
            //End Assign session for menulinks change
            if (Request.QueryString["sflag"] != null)
            {
                if (Request.QueryString["sflag"].ToString() == "1")
                    lblmsg.Text = "<Font face=Arial color=Red size=2>Your session has expired.</Font>";
                if (Request.QueryString["sflag"].ToString() == "2")
                    lblmsg.Text = "<Font face=Arial color=Red size=2>Your session has expired. Please login into to make plan change.</Font>";
            }

            if (Request.QueryString["MProfile"] != null)
            {
                if (Request.QueryString["MProfile"].ToString() == "1")
                {
                    lblmsg.Text = "<Font face=Arial color=Red size=2>Thanks for attempting to manage your profile, please login to continue.</Font>";
                }
            }
            if (Request.QueryString["PTNT"] != null)
            {
                if (Request.QueryString["PID"] != null)
                {
                    ProfileID = Convert.ToInt32(Request.QueryString["PID"].ToString());
                }
            }
            else
            {
                if (Request.QueryString["PID"] != null)
                {
                    Mynetwork = Request.QueryString["PID"].ToString();
                }
            }
            if (Request.QueryString["Type"] != null)
            {
                if (Request.QueryString["Type"].ToString() == "JMN")
                {
                    lblmsg.Text = "You must be a member to join into a network.<a href=" + System.Configuration.ConfigurationManager.AppSettings.Get("RootPath") + "/sf/features.aspx><b>Click here</b></a> to read about member benefits";
                }
            }

            if (Request.QueryString["activate"] != null)
            {
                lblmsg.Text = "<font color='green'>Thanks for activating your 30-day free trial. Login to your USPDhub by using the credentials that have been emailed to your registered email ID.</font> ";
            }

        }
    }
}