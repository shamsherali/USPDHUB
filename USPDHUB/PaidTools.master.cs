using System;
using System.Linq;
using System.Configuration;
using USPDHUBBLL;

public partial class PaidTools : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["Free"] != null)
                {
                    string prevPage = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : ConfigurationManager.AppSettings.Get("RootPath") + "/Business/MyAccount/Default.aspx";
                    Response.Redirect(prevPage);
                }
            }
        }

        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "PaidTools.master.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
}
