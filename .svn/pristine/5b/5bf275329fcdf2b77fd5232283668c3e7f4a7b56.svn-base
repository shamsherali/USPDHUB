using System;
using System.Linq;
using System.Web.UI;
using System.Data;
using USPDHUBBLL;
using System.Web;

namespace USPDHUB.OP.inschoolhubcom
{
    public partial class AddToolsold : System.Web.UI.Page
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