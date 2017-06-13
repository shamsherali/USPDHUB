using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ResellersDAL
{
    public class CommonDAL
    {
        public static DataTable GetVerticalConfigsByType(string verticalDomain, string type)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetDomainConfigsByType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@VerticalDomain", verticalDomain);
                sqlCmd.Parameters.AddWithValue("@Type", type);
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
