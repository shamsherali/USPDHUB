using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace UserFormsDAL
{
    public class InBuiltDataBLL
    {
        /// <summary>
        /// for retrieving bulletn label data
        /// </summary>
        /// <returns>datatable</returns>
        public static DataTable GetBulletinLabelData()
        {
            DataTable dtLabel = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBulletinLabelData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtLabel);
                return dtLabel;
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
