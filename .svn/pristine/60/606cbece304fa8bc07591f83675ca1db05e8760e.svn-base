using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;

namespace USPDHUB.Video
{
    public partial class Default : System.Web.UI.Page
    {
        CommonBLL objCommon = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;

            string domainName = objCommon.CreateDomainUrlString(url);
            if (!domainName.ToLower().Contains("uspd"))
            {
                if (domainName.ToLower().Contains("inschool"))
                    Response.Redirect("Defaultish.aspx");
                else if (domainName.ToLower().Contains("twovie"))
                    Response.Redirect("Defaulttvh.aspx");
                if (domainName.ToLower().Contains("myyouth"))
                    Response.Redirect("Defaultmyh.aspx");
            }
        }
    }
}