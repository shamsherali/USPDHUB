using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;

namespace USPDHUB.OP.twoviecom
{
    public partial class OrderCompleted : System.Web.UI.Page
    {
        CommonBLL objCommon = new CommonBLL();
        BusinessBLL objbus = new BusinessBLL();
        public int passwordchange = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string username = string.Empty;
                string statustext = string.Empty;
                string profileID = string.Empty;
                if (Request.QueryString["PID"] != null)
                {
                    profileID = Request.QueryString["PID"].ToString();

                    DataTable dtprofiledetails = new DataTable();
                    
                    profileID = EncryptDecrypt.DESDecrypt(profileID);
                    dtprofiledetails = objbus.GetuserdetailsByProfileID(Convert.ToInt32(profileID));
                    if (dtprofiledetails.Rows.Count > 0)
                    {
                        passwordchange = Convert.ToInt32(dtprofiledetails.Rows[0]["Password_Changed"].ToString());
                        username = dtprofiledetails.Rows[0]["Username"].ToString();
                    }

                }
                if (passwordchange == 0)
                {
                    statustext = " Thank you for registering for TwoVie. An email has been sent to " + username + " with your user name and password.";
                }
                lblEmailID1.Text = statustext;
            }
        }
    }
}