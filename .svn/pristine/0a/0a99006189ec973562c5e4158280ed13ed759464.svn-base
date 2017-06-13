using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SchemaNameChange
{
    public partial class CountryCodeChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUid.Text != "" && txtCountryCode.Text != "")
            {                
                string constrng = ConfigurationManager.ConnectionStrings["WOWZYDevServer"].ToString();
                SqlConnection sqlCon = new SqlConnection(constrng);
                SqlCommand sqlCmd = new SqlCommand("UPDATE T_Business_Profiles SET Country_Code='" + txtCountryCode.Text + "' WHERE USER_ID=" + txtUid.Text, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCon.Open();
                int num= sqlCmd.ExecuteNonQuery();
                if (num > 0)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Country Code Changed Successfully";
                }
                sqlCon.Close();
                txtUid.Text = "";
                txtCountryCode.Text = "";
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