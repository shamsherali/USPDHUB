using System;
using System.Data;
using System.Web.UI.HtmlControls;
using USPDHUBBLL;
using System.Web;

public partial class SecurePage : System.Web.UI.MasterPage
{
    public string RootPath = System.Configuration.ConfigurationManager.AppSettings.Get("RootPath");
    public string DomainName = "";
    public static string MarketingCode = string.Empty;
    public DataTable DtAll = new DataTable();
    public DataTable DtCoup = new DataTable();
    public static DataTable DtCouTemp = new DataTable();
    public int ProfileID = 0;
    public int UserID = 0;
    public int ProfileID1 = 0;
    public string Txtwhat2 = string.Empty;
    public string Txtwhere3 = string.Empty;
    public string Tmpvarpath = string.Empty;
    public static string Htprefval = string.Empty;
    public string Ptnt = string.Empty;
    public string Cid = string.Empty;
    public string JmnProfileID = string.Empty;
    public int CheckUserSession = 0;
    public int RoleID = 0;
    public string Pagesession = string.Empty;
    public string LogoName = "";
    CommonBLL objCommon = new CommonBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Vertical"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            //Start Check for pagename sessions.
            if (Session["Menulinkspagename"] != null)
            {
                if (Session["Menulinkspagename"].ToString() != "")
                {
                    if (Session["Menulinkspagename"].ToString() == "featurespage")
                    {
                        Pagesession = "featurespage";
                    }
                    if (Session["Menulinkspagename"].ToString() == "aboutuspage")
                    {
                        Pagesession = "aboutuspage";
                    }
                    if (Session["Menulinkspagename"].ToString() == "loginpage")
                    {
                        Pagesession = "loginpage";
                    }
                    Session["Menulinkspagename"] = "";
                }

            }
            //End Check for pagename sessions.

            // Adding Reseller Session

            if (Request.QueryString["RSID"] != null)
            {
                if (Request.QueryString["RSID"].ToString() != "")
                {
                    Session["RSID"] = Request.QueryString["RSID"].ToString();
                }
            }

            //End of Reseller
            //Issue No 


            //  Show DashBoard Link If User Session Available

            if (Session["ProfileID"] != null)
            {
                if (Session["ProfileID"].ToString() != "")
                {
                    CheckUserSession = 1;
                }
            }
            if (Session["RoleID"] != null)
            {
                if (Session["RoleID"].ToString() != "")
                {
                    if (Session["RoleID"].ToString() == "2")
                    {
                        RoleID = 2;
                    }
                    if (Session["RoleID"].ToString() == "1")
                    {
                        RoleID = 1;
                    }
                }
            }
            //  Show DashBoard Link If User Session Available

            if (Request.QueryString["TID"] != null)
            {
                MarketingCode = Request.QueryString["TID"].ToString();
            }
            if (!IsPostBack)
            {
                // *** Adding page title and meta keys for page *** //
                DataTable dtConfigPageKeys = objCommon.GetVerticalConfigsByType(DomainName, "DashboardKeys");
                if (dtConfigPageKeys.Rows.Count > 0)
                {
                    HtmlMeta htmlMeta = new HtmlMeta();
                    foreach (DataRow row in dtConfigPageKeys.Rows)
                    {
                        if (row[0].ToString() == "Title")
                            this.Page.Title = row[1].ToString();
                        else if (row[0].ToString() == "author")
                            htmlMeta.Attributes.Add("author", row[1].ToString());
                        else if (row[0].ToString() == "description")
                            htmlMeta.Attributes.Add("description", row[1].ToString());
                        else if (row[0].ToString() == "keywords")
                            htmlMeta.Attributes.Add("keywords", row[1].ToString());
                    }
                    HtmlHead header = new HtmlHead();
                    header.Controls.Add(htmlMeta);
                }
                if (MarketingCode != "")
                {
                    //string clientIPval = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    //HttpSessionState ss = HttpContext.Current.Session;
                    //string sesID = ss.SessionID.ToString();
                    //Marketing ObjMar = new Marketing();
                    //ObjMar.InsertMarketingCodes(MarketingCode, clientIPval, sesID);
                }
            }
            LogoName = Page.ResolveClientUrl("~/images/VerticalLogos/") + DomainName + "logo.png";

        }
        catch (Exception ex)
        {

            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "SecurePage.master.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
}
