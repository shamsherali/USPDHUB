using System;
using System.Data;
using System.Data.SqlClient;

namespace UserFormsDAL
{
    public class Utilities : DataAccess
    {
        /// <summary>
        /// getting states by countryname
        /// </summary>
        /// <param name="countyname">countyname</param>
        /// <returns>data table</returns>
        public static DataTable GetAllShortStatesByCountry(string countyname)
        {
            DataTable states = new DataTable("states");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetShortStatesByCountry", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@countryname", countyname);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(states);

                return states;
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
