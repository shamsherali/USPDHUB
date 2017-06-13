using System;
using System.Linq;
using System.Web.UI;
using USPDHUBBLL;
using System.Configuration;
using System.Data;
using System.Web;

namespace USPDHUB.OP.twoviecom
{
    public partial class AddToolsOld : System.Web.UI.Page
    {
        public string RootPath = "";
        CommonBLL objCommon = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            // *** Get Domain Name *** //
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }
            RootPath = Session["RootPath"].ToString();
        }
    }
}