using System;
using System.Configuration;
using USPDHUBBLL;
using System.Web;

namespace USPDHUB
{
    public partial class AdminInterface : System.Web.UI.MasterPage
    {
        public string RootPath = "";
        public string DomainName = "";
        public string LogoName = "";
        CommonBLL objCommon = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    Session["AdminVertical"] = objCommon.CreateDomainUrl(url);
                }
                DomainName = Session["AdminVertical"].ToString();
                RootPath = Session["RootPath"].ToString();
                LogoName = Page.ResolveClientUrl("~/images/VerticalLogos/") + DomainName + "logo.png";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AdminInterface.master.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}