using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class SalesCodeDAL
    {
        public static bool validateSalesCode(string SalesCode)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_P_ValidateSalesCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SalesCode", SalesCode);
                return Convert.ToBoolean(sqlCmd.ExecuteScalar());
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
