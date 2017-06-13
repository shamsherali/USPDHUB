using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace UserFormsDAL
{
    public class MServiceDAL
    {

        /// <summary>
        /// retrieving mobile app settings
        /// </summary>
        /// <param name="pUserID">userid</param>
        /// <returns>data table</returns>
        public static DataTable GetMobileAppSetting(int pUserID)
        {
            DataTable dtMSettings = new DataTable("MSettings");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {

                SqlCommand sqlCmd = new SqlCommand("usp_M_GetMobileSettings", sqlCon);
                sqlCmd.Parameters.AddWithValue("@User_ID", pUserID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtMSettings);

                return dtMSettings;
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
        /// retrieving vertial name by profile id
        /// </summary>
        /// <param name="pProfileID">profileid</param>
        /// <returns>string</returns>
        public static string GetVerticalNameByProfileID(int pProfileID)
        {
            string verticalName = "USPD";
            DataTable vtable = new DataTable("getverticalname");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetVerticalNameByPID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@PID", pProfileID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                if (vtable.Rows.Count > 0)
                {
                    verticalName = Convert.ToString(vtable.Rows[0]["Vertical_Name"]);
                }
                return verticalName;
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
