using System;
using System.Configuration;
using USPDHUBBLL;

public partial class AdminHome : System.Web.UI.MasterPage
{
    public string Dburl = string.Empty;
    public string Checkdburl = string.Empty;
    public string RootPath = "";
    public string DomainName = "";
    public string LogoName = "";
    protected override void OnInit(EventArgs e)
    {
        try
        {
            base.OnInit(e);
            if (Session["AdminVertical"] == null || Session["adminuserid"] == null)
            {
                Response.Redirect(Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1"));
            }
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "AdminHome.master.cs", "OnInit", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Dburl = Request.Url.ToString();
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            Checkdburl = RootPath + "/Admin/Default.aspx";
            LogoName = Page.ResolveClientUrl("~/images/VerticalLogos/") + DomainName + "logo.png";
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "AdminHome.master.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
}
