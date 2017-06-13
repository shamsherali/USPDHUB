using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using USPDHUBBLL;
using System.Text;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Configuration;

namespace USPDHUB.Admin
{
    public partial class ManageSalesCode : BaseWeb
    {
        AdminBLL objAdmin = new AdminBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                
                if (!IsPostBack)
                {
                    BindSalesCode();
                }

            }
            catch
            {
            }
        }

        private void BindSalesCode()
        {
            DataTable dtSalesCode = new DataTable();
            dtSalesCode = objAdmin.GetManageSalesCode();
            gvSalesCode.DataSource = dtSalesCode;
            gvSalesCode.DataBind();
            Session["SalesCode"] = dtSalesCode;
        }

        protected void gvSalesCode_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSalesCode.PageIndex = e.NewPageIndex;
            gvSalesCode.DataSource = (DataTable)Session["SalesCode"];
            gvSalesCode.DataBind();
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            int ConfigId = Convert.ToInt32(lnk.CommandArgument);
            objAdmin.DeleteSalesCode(ConfigId);
            lblmsg.Text = Resources.AdminResource.SaleCodeDeleteSuccess;
            BindSalesCode();
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/CreateSalesCode.aspx?AdminID=" + EncryptDecrypt.DESEncrypt(Session["adminuserid"].ToString()));
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnk = (LinkButton)sender;
                int ConfigID = Convert.ToInt32(lnk.CommandArgument);
                DataTable dt = new DataTable();
                dt = objAdmin.GetResellerDetailsByConfigID(ConfigID);
                Response.Redirect("~/Admin/SalesCode.aspx?ConfigID=" + EncryptDecrypt.DESEncrypt(ConfigID.ToString()) + "&SC=" + EncryptDecrypt.DESEncrypt(dt.Rows[0]["SalesCode"].ToString()));
            }

            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "ManageSalesCode.aspx.cs", "btnView_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
          
        }
    }
}