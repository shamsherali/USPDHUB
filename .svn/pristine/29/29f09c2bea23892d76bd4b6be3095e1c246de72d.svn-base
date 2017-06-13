using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using USPDHUBBLL;
using System.Web.Routing;

namespace USPDHUB
{
    public partial class SignUp : System.Web.UI.Page
    {
        CommonBLL objCommon = new CommonBLL();
        SalesCodeBLL objSales = new SalesCodeBLL();
        public string SalesCode = "";

        protected void Page_Load(object sender, EventArgs e)
        { 
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }

            // http://www.uspdhub.com/signup/smb10001
            /*** First Index: SalesCode ***/
            int i = 1;
            /***  GetFriendlyUrlSegments : Receving QueryString Parameters ***/
            foreach (var segment in Request.GetFriendlyUrlSegments())
            {
                if (i == 1)
                {
                    SalesCode = Convert.ToString(segment);
                    break;
                }
            }
            string Url = Session["RootPath"].ToString() + "/OP/" + Session["VerticalDomain"].ToString() + "/AddTools.aspx";
            if (SalesCode.Trim() != "")
            {
                if (objSales.validateSalesCode(SalesCode))
                    Url += "?SC=" + SalesCode;     // SC=sales code
            }
            Response.Redirect(Url);
        }
    }
}