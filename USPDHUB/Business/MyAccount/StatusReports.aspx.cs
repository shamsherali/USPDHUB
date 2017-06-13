using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.Drawing;

namespace USPDHUB.Business.MyAccount
{
    public partial class StatusReports : System.Web.UI.Page
    {

        public string MediaType = string.Empty;
        CommonBLL objcmmon = new CommonBLL();
        int UserID;
        int ProfileID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx?sflag=1"));
            else
            {
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"]);
             }
            if (Request.QueryString["MediaType"] != "")
                MediaType = EncryptDecrypt.DESDecrypt(Request.QueryString["MediaType"]);
            if (!IsPostBack) {
                BindData();
            
            }

        }

        public void BindData() {

            DataTable dtStatus = objcmmon.GetSocialShareDetails(UserID, MediaType);
            grdMediaStatusReport.DataSource = dtStatus;
            grdMediaStatusReport.DataBind();
        
        }

        protected void grdMediaStatusReport_rowDatabound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[3].Text.Contains("Success"))
                {
                    e.Row.Cells[3].ForeColor = Color.Green;
                }
                else if (e.Row.Cells[3].Text.Contains("In Progress"))
                    e.Row.Cells[3].ForeColor = Color.Orange;
                else
                    e.Row.Cells[3].ForeColor = Color.Red;
            }
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }

        protected void grdMediaStatusReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMediaStatusReport.PageIndex = e.NewPageIndex;
            BindData();
        }
    }
}