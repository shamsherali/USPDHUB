using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB.OP.inschoolhubcom
{
    public partial class OrderCompleted : System.Web.UI.Page
    {
        public int passwordchange = 0;
        public int CheckCJCoockie = 0;
        public string Upgrade = string.Empty;

        protected string RootPath = "";
        public string DomainName = "";
        CommonBLL objCommon = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            // *** Get Domain Name *** //
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }
            DomainName = Session["VerticalDomain"].ToString();
            if (Session["RootPath"] != null)
            {
                RootPath = Session["RootPath"].ToString();
            }


            string profileID = string.Empty;
            if (Request.QueryString["PID"] != null)
            {
                profileID = Request.QueryString["PID"].ToString();

                DataTable dtprofiledetails = new DataTable();
                BusinessBLL objbus = new BusinessBLL();
                profileID = EncryptDecrypt.DESDecrypt(profileID);
                dtprofiledetails = objbus.GetuserdetailsByProfileID(Convert.ToInt32(profileID));
                if (dtprofiledetails.Rows.Count > 0)
                {
                    passwordchange = Convert.ToInt32(dtprofiledetails.Rows[0]["Password_Changed"].ToString());
                }

            }
            string username = string.Empty;
            string statustext = string.Empty;
            if (Session["UName"] != null)
            {
                username = Session["UName"].ToString();
            }
            if (passwordchange == 0)
            {
                statustext = " Thank you for registering for inSchoolHub. An email has been sent to " + username + " with your user name and password.";
            }
            else
            {
                // *** Start Issue 899 ***
                if (Request.QueryString["U"] != null && Request.QueryString["U"].ToString() != "")
                {
                    Upgrade = "1";
                    statustext = " Thank you for upgrading your inSchoolHub. In order to complete your upgrade, please re-login.<br /><a href=" + RootPath + "/OP/" + Session["VerticalDomain"] + "/login.aspx ><img src='" + RootPath + "/secure/images/loginupgrade.gif' border='0'/></a> <br /><br />An email has been sent to " + username + " with your user name and password.";
                }
                else
                {
                    statustext = " Thank you for upgrading your inSchoolHub. An email has been sent to " + username + "&nbsp <br />with your user name and password.";
                }
                // *** End Issue 899 ***
            }
            lblEmailID1.Text = statustext;
            if (Request.Cookies["cjuser"] != null)
            {
                CheckCJCoockie = 1;
            }

            if (!IsPostBack)
            {
                // Check for CJ Code

                if (Session["OID"] != null)
                {
                    if (Session["OID"].ToString() != "")
                    {
                        hdnorderid.Value = Session["OID"].ToString();
                    }
                }
                if (Session["Amt"] != null)
                {
                    if (Session["Amt"].ToString() != "")
                    {
                        hdnamount.Value = Session["Amt"].ToString();
                    }
                }

                // End 
                Session.Clear();
                Session.Abandon();
                // End              
            }
        }
    }
}
