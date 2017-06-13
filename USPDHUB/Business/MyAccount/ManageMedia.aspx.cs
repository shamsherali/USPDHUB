using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using USPDHUBBLL;

public partial class Business_MyAccount_ManageMedia : BaseWeb
{
    public int ProfileID = 0;
    public int UserID = 0;
    public string upgradeurl = string.Empty;
    BusinessBLL objBus = new BusinessBLL();
    public bool ShowBulletins = false;
    public string RootPath = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        // *** Chcking for user session ***
        if (Session["UserID"] == null || Session["ProfileID"] == null)
        {
            string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
            Response.Redirect(urlinfo);
        }
        // *** Get Domain Name *** //
        RootPath = Session["RootPath"].ToString();
        UserID = Convert.ToInt32(Session["UserID"].ToString());
        ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
        upgradeurl = "<a href=" + "\\'" + RootPath + "/Business/UpgradeTools.aspx?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString()) + "&U=T" + "\\'" + "><img src=" + "\\'" + RootPath + "/images/btn_upgrade1.gif" + "\\'" + " border=" + "\\'0\\' /></a>";
        if (!IsPostBack)
        {
            DataTable dtSelectedTools = objBus.GetSelectedToolsByUserID(UserID);
            if (dtSelectedTools.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtSelectedTools.Rows[0]["Package_Number"].ToString()))
                {
                    if (Convert.ToInt32(dtSelectedTools.Rows[0]["Package_Number"].ToString()) > 4)
                        ShowBulletins = true;
                }
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
    }
}