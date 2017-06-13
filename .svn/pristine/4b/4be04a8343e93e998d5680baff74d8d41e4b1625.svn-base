using System;
using System.Configuration;
using System.Web;
using USPDHUBBLL;
using System.Data;

namespace USPDHUB
{
    public partial class Logout : System.Web.UI.Page
    {
        AdminBLL adminobj = new AdminBLL();
        public int Adminid;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int userid = 0;
                if (Request.QueryString["Admin"] == null)
                {
                    if (Session["userid"] != null || Session["C_User_ID"] != null)
                    {
                        userid = Convert.ToInt32(Session["userid"].ToString());
                        if (Session["C_USER_ID"] != null)
                            userid = Convert.ToInt32(Session["C_User_ID"].ToString());
                        USPDHUBBLL.BusinessBLL bobj = new USPDHUBBLL.BusinessBLL();
                        string date = string.Empty;
                        string time = string.Empty;
                        date = System.DateTime.Now.ToShortDateString();
                        time = System.DateTime.Now.ToShortTimeString();
                        string ipaddress = Request.Params["REMOTE_ADDR"].ToString();
                        string userLoginBrowser = Request.Browser.Browser.ToString();
                        string userBrowserVer = Request.Browser.Version.ToString();
                        if (Session["GoMemDashboard"] == null)
                        {
                            bobj.Usertracking(userid, ipaddress, "", time, "", date, 2, userLoginBrowser, userBrowserVer);
                        }
                        else
                        {
                            Session["GoMemDashboard"] = null;
                        }
                    }
                    string[] sessionNames = new string[Session.Keys.Count];
                    int i = 0;
                    string sessionVariableName;
                    if (Session.Keys.Count > 0)
                    {
                        foreach (string sessionVariable in Session.Keys)
                        {
                            sessionVariableName = sessionVariable;
                            if (sessionVariableName != "adminuserid" && sessionVariableName != "AdminVertical")
                            {
                                sessionNames[i] = sessionVariableName;
                                i = i + 1;
                            }
                        }
                    }
                    foreach (string name in sessionNames)
                    {
                        Session.Remove(name);
                    }
                }
                else
                {
                    Session["adminuserid"] = null;
                    Session["AdminVertical"] = null;
                }
                Response.Redirect(Page.ResolveClientUrl("~/Default.aspx"));
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "Logout.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}