using System;
using System.Data;
using System.Data.SqlClient;


namespace UserFormsDAL
{
    public class Consumer:DataAccess
    {
        /// <summary>
        /// validates consumer
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>data table</returns>
        public static DataTable ValidateConsumer(string username, string password)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ValidateUser", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@username", username);
                sqlCmd.Parameters.AddWithValue("@password", password);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                return vtable;
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
        /// <summary>
        /// for retrieving active associates
        /// </summary>
        /// <param name="pUserID">userid</param>
        /// <returns>datatable</returns>
        public static DataTable GetActiveAssociates(int pUserID)
        {
            DataTable dt = new DataTable("ActiveAssociate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetActiveAssociates", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
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
