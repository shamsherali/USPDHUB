using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using USPDHUBDAL;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class temp_QRConnectScan : System.Web.UI.Page
    {
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Get_temp_QRScannDetails();
        }
        public void Get_temp_QRScannDetails() 
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_temp_GETQRConnectScan_History", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dt);
                Session["QRConnectScan_History"] = dt;
                grdQRConnectMsg.DataSource = dt;
                grdQRConnectMsg.DataBind();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "temp_QRConnectScan.aspx.cs", "Get_temp_QRScannDetails()", ex.Message,
                       Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        protected void grdQRConnectMsg_OnPageIndexChanging(object sender, GridViewPageEventArgs e) 
        {
            try
            {
                grdQRConnectMsg.PageIndex = e.NewPageIndex;
                grdQRConnectMsg.DataSource = (DataTable)Session["QRConnectScan_History"];
                grdQRConnectMsg.DataBind();
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "temp_QRConnectScan.aspx.cs", "grdQRConnectMsg_OnPageIndexChanging", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}