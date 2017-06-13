using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SchemaNameChange
{
    public partial class SchemaNameChange : System.Web.UI.Page
    {
        public  DataTable dtAppNames = new DataTable("validate");


        protected void Page_Load(object sender, EventArgs e)
        {
            lblmess.Text = "";
            if (!IsPostBack)
            { 
                LoadAPpNames();
                ddlAppName.DataSource = dtAppNames;
                ddlAppName.DataTextField = "Profile_name";
                ddlAppName.DataValueField = "App_Name";
                ddlAppName.DataBind();

                if (dtAppNames.Rows.Count > 0)
                {
                    ddlAppName.SelectedValue = dtAppNames.Rows[0]["App_Name"].ToString();
                }
            }
        }


        private void LoadAPpNames()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetTestingBrandedAppNames", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtAppNames);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        protected void ddlAppName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAPpNames();
            txtUserID.Text = "";
            DataRow[] rows = dtAppNames.Select("Profile_name='" + ddlAppName.SelectedItem.Text.Trim().Replace("'","''") + "' ");
            if (rows.Length > 0)
            {
                txtUserID.Text = rows[0]["User_ID"].ToString();
            }

            lblmess.Text = "";
        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            string AppName = ddlAppName.SelectedValue.ToString();

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateAppSchemaName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AppName", AppName);
                sqlCmd.Parameters.AddWithValue("@SchemeName", txtSchemaName.Text.Trim());
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

            lblmess.Text = "<font size='3' color='green'>Scheme name has been successfully updated.</font>";
        }


    }
}