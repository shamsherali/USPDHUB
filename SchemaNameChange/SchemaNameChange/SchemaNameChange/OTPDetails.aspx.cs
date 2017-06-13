using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;


namespace SchemaNameChange
{
    public partial class OTPDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid()
        {
            string constrng = ConfigurationManager.ConnectionStrings["WOWZYDevServer"].ToString();
            SqlConnection sqlCon = new SqlConnection(constrng);
            DataTable dtOTPDetails=  new  DataTable();
            SqlCommand sqlCmd = new SqlCommand("Get_OTP_Details", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            sda.Fill(dtOTPDetails);
            grdOPTDetails.DataSource = dtOTPDetails;
            grdOPTDetails.DataBind();
            
           
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}