using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB
{
    public partial class SortOrder : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        BulletinBLL objBulletin = new BulletinBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                // *** Get Domain Name *** //
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                if (!IsPostBack)
                {
                    DataTable dtobj = new DataTable();
                    dtobj = objBulletin.GetBulletins(UserID);
                    if (dtobj.Rows.Count > 0)
                    {
                        ItemsListView.DataSource = null;
                        ItemsListView.DataSource = dtobj;
                        ItemsListView.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "SortOrder.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}