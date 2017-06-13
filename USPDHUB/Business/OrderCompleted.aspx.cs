using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using USPDHUBBLL;

public partial class OrderCompleted : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblEmailID1.Text = Resources.LabelMessages.OrderCompletedMessage.ToString();
        //"We have received your information and will be contacting you soon.";
        lblEmailID2.Text = "Thank you.";
    }
}
