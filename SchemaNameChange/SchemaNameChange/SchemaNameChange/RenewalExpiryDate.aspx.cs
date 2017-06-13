using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SchemaNameChange
{
    public partial class RenewalExpiryDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (txtUid.Text != "" && txtRDate.Text.Trim() != "")
            {
                DateTime renewalExpiryDate = Convert.ToDateTime(txtRDate.Text.Trim());
                string constrng = ConfigurationManager.ConnectionStrings["WOWZYDevServer"].ToString();
                using (SqlConnection sqlCon = new SqlConnection(constrng))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("UPDATE T_Profile_Subcriptions SET subscription_renewal_date='" + renewalExpiryDate + "' WHERE Active_flag=1 AND USER_ID=" + txtUid.Text, sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCon.Open();
                        num = sqlCmd.ExecuteNonQuery();
                    }
                }
                if (num > 0)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Renewal Date Updated Successfully";
                }
                
                txtUid.Text = "";
                txtRDate.Text = "";
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Submission fails";
            }
            lblMsg.Visible = true;
        }
    }
}