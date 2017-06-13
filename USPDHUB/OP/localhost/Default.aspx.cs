using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;

namespace USPDHUB.OP.localhost
{
    public partial class Default : System.Web.UI.Page
    {
        CommonBLL objCommon = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }
        }
    }
}