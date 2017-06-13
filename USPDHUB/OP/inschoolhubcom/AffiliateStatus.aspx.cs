using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USPDHUB.OP.inschoolhubcom
{
    public partial class AffiliateStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["sts"] != null)
            {
                string statusmsg = "";
                if (Request.QueryString["sts"].ToString() == "1")
                    statusmsg = Resources.LabelMessages.InvitationCancelled;
                else if (Request.QueryString["sts"].ToString() == "2")
                    statusmsg = Resources.LabelMessages.InvitationActivated;
                lblStatus.Text = statusmsg;
            }
        }
    }
}