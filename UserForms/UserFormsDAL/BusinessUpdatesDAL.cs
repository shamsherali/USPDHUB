using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace UserFormsDAL
{
    public class BusinessUpdatesDAL
    {
        //----------editing business udpates---------------
        /// <summary>
        /// updating businessupdate details
        /// </summary>
        /// <param name="updateID">updateid</param>
        /// <returns>datatable</returns>
        public static DataTable UpdateBusinessUpdateDetails(int updateID)
        {
            DataTable vtable = new DataTable("UpdateId");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBusinessUpdateWithUpdateId", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UpdateId", updateID);

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





        //--------------ends editing business updates---------------------
    }
}
