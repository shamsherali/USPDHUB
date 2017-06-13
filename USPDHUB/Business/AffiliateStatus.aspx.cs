using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;

namespace USPDHUB.Business
{
    public partial class AffiliateStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AffiliateStatus.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}