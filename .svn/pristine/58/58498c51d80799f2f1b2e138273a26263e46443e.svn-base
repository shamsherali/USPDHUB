using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageCalDirect : System.Web.UI.Page
    {
        AddOnBLL objAddOn = new AddOnBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["UserID"]) == "" || Session["VerticalDomain"] == null)
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx?sflag=1"));
            }
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString() != "")
            {
                DataTable dtAddOn = objAddOn.GetAddOnById(Convert.ToInt32(Request.QueryString["ID"].ToString()));
                if (dtAddOn.Rows.Count == 1)
                {
                    if (Convert.ToString(dtAddOn.Rows[0]["ManageUrl"]) != "" && Session["RootPath"] != null)
                    {
                        Session["CalendarAddOnID"] = Request.QueryString["ID"].ToString();
                        Response.Redirect(Session["RootPath"].ToString() + dtAddOn.Rows[0]["ManageUrl"].ToString());
                    }
                }
            }
        }
    }
}