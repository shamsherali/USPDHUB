using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;

namespace USPDHUB
{
    public partial class WebnairRegister : System.Web.UI.Page
    {
        CommonBLL objCommon = new CommonBLL();
        public string LogoName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;

                string domainName = objCommon.GetDomainUrlWithOut(url);

                LogoName = Page.ResolveClientUrl("~/images/VerticalLogos/") + domainName + "logo.png";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "WebnairRegister.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkSubmit_Click(object sender, EventArgs e)
        { }
    }
}