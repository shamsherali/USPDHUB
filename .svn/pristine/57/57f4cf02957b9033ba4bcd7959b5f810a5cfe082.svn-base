using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace MyWorkingSamples.Reports
{
    public class AgencyBLL
    {
        public static DataTable GetActiveVerticals()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAllActiveVerticals", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
    }
}