using System;
using System.Configuration;
using USPDHUBBLL;
using System.IO;


public partial class ProfileIframes_UrlShortCut : System.Web.UI.Page
{
    public int ProfileID = 0;
    public int UserID = 0;
    public int CUserID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null || Session["ProfileID"] == null)
        {
            string urlinfo = System.Configuration.ConfigurationManager.AppSettings.Get("RootPath") + "/Login.aspx?sflag=1";
            Response.Redirect(urlinfo);
        }
        else
        {
            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());

            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                CUserID = Convert.ToInt32(Session["C_USER_ID"]);
            else
                CUserID = UserID;
        }
        if (!IsPostBack)
        {
            chkCreate.Checked = false;
        }
    }

    protected void BtnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            if (chkCreate.Checked == false)
                UrlShortcutToDesktop(ConfigurationManager.AppSettings["RootPath"] + "/login.aspx?UID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(CUserID)) + "&flag=0");
            else
                UrlShortcutToDesktop(ConfigurationManager.AppSettings["RootPath"] + "/login.aspx?UID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(CUserID)) + "&flag=1");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }

    private void UrlShortcutToDesktop(string linkUrl)
    {
        try
        {
            String fileName = "USPDHub.url";
            String filePath = Server.MapPath("~/Upload/USPDHub.url");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=" + linkUrl);
                writer.Flush();
                writer.Close();
            }
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            Response.ClearHeaders();
            response.ContentType = "application/internet-shortcut";
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ";");
            Context.Response.TransmitFile(filePath);
            response.Flush();
            response.Close();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
}
