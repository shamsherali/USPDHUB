using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Configuration;
using System.Data;

public partial class Business_MyAccount_ManageReports : System.Web.UI.Page
{
    public bool Update = false;
    public bool Event = false;
    BusinessBLL objBus = new BusinessBLL();
    public int ProfileID = 0;
    public int UserID = 0;
    public string encProfileID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        // *** Chcking for user session ***
        if (Session["UserID"] == null)
        {
            string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
            Response.Redirect(urlinfo);
        }
        else
        {
            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            encProfileID = EncryptDecrypt.DESEncrypt(ProfileID.ToString());

        }
        if (!IsPostBack)
        {
            DataTable dtSelectedTools = objBus.GetSelectedToolsByUserID(UserID);
            if (dtSelectedTools.Rows.Count > 0)
            {
                if (Session["Free"] == null)
                {
                    Update = Convert.ToBoolean(dtSelectedTools.Rows[0]["IsUpdate"].ToString());
                    Event = Convert.ToBoolean(dtSelectedTools.Rows[0]["IsEventCalendar"].ToString());  
                }                
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
    }
}