using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB.Admin
{
    public partial class ManageCSUsers : System.Web.UI.Page
    {
        AdminBLL objAdmin = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DataTable dtobj = new DataTable();
                    dtobj = objAdmin.GetCSUsers();
                    ConsumersGrid.DataSource = dtobj;
                    ConsumersGrid.DataBind();
                }
                catch (Exception ex)
                {
                    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                    //Error 
                    objInBuiltData.ErrorHandling("ERROR", "ManageCSUsers.aspx.cs", "Page_Load", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateCSUser.aspx");
        }
    }
}