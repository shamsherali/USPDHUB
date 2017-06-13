using System;
using System.Web;
using System.Configuration;
using USPDHUBBLL;
public partial class Login : System.Web.UI.Page
{
    CommonBLL objCommon = new CommonBLL();
    public string RootPath = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            // *** Get Domain Name *** //
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }
            string vertical = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            string queryIds = "";
            if (Request.QueryString["sflag"] != null)
            {
                if (queryIds == "")
                    queryIds = "sflag=" + Request.QueryString["sflag"];
                else
                    queryIds = queryIds + "&sflag=" + Request.QueryString["sflag"];
            }
            if (Request.QueryString["MProfile"] != null)
            {
                if (queryIds == "")
                    queryIds = "MProfile=" + Request.QueryString["MProfile"];
                else
                    queryIds = queryIds + "&MProfile=" + Request.QueryString["MProfile"];
            }
            if (Request.QueryString["PTNT"] != null)
            {
                if (queryIds == "")
                    queryIds = "PTNT=" + Request.QueryString["PTNT"];
                else
                    queryIds = queryIds + "&PTNT=" + Request.QueryString["PTNT"];
            }
            if (Request.QueryString["PID"] != null)
            {
                if (queryIds == "")
                    queryIds = "PID=" + Request.QueryString["PID"];
                else
                    queryIds = queryIds + "&PID=" + Request.QueryString["PID"];
            }
            if (Request.QueryString["Type"] != null)
            {
                if (queryIds == "")
                    queryIds = "Type=" + Request.QueryString["Type"];
                else
                    queryIds = queryIds + "&Type=" + Request.QueryString["Type"];
            }
            if (Request.QueryString["activate"] != null)
            {
                if (queryIds == "")
                    queryIds = "activat=" + Request.QueryString["activate"];
                else
                    queryIds = queryIds + "&activat=" + Request.QueryString["activate"];
            }
            if (Request.QueryString["TID"] != null)
            {
                if (queryIds == "")
                    queryIds = "TID=" + Request.QueryString["TID"];
                else
                    queryIds = queryIds + "&TID=" + Request.QueryString["TID"];
            }
            if (Request.QueryString["UID"] != null)
            {
                if (queryIds == "")
                    queryIds = "UID=" + Request.QueryString["UID"];
                else
                    queryIds = queryIds + "&UID=" + Request.QueryString["UID"];
            }
            if (Request.QueryString["flag"] != null)
            {
                if (queryIds == "")
                    queryIds = "flag=" + Request.QueryString["flag"];
                else
                    queryIds = queryIds + "&flag=" + Request.QueryString["flag"];
            }
            if (Request.QueryString["ID"] != null)
            {
                if (queryIds == "")
                    queryIds = "ID=" + Request.QueryString["ID"];
                else
                    queryIds = queryIds + "&ID=" + Request.QueryString["ID"];
            }
            if (Request.QueryString["PName"] != null)
            {
                if (queryIds == "")
                    queryIds = "PName=" + Request.QueryString["PName"];
                else
                    queryIds = queryIds + "&PName=" + Request.QueryString["PName"];
            }
            if (Request.QueryString["al"] != null)
            {
                if (queryIds == "")
                    queryIds = "al=" + Request.QueryString["al"];
                else
                    queryIds = queryIds + "&al=" + Request.QueryString["al"];
            }
            string redirectUrl = RootPath + "/OP/" + vertical + "/Login.aspx";
            if (queryIds != "")
                redirectUrl = redirectUrl + "?" + queryIds;
            Response.Redirect(redirectUrl);
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "Login.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
}
