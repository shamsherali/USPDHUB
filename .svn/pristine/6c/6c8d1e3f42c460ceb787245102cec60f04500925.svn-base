using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserFormsBLL;

namespace UserForms
{
    public partial class Logout : System.Web.UI.Page
    {
        public string DomainName = "";
        CommonBLL objCommon = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                DomainName = objCommon.CreateDomainUrl(url);
            }
            Response.Redirect(Convert.ToString(Session["RootPath"]) + "/Logout.aspx");
        }
    }
}