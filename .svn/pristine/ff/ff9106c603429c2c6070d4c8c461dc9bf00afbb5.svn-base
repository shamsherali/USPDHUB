using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace UserFormsDAL
{
    public class CalendarAddOnDAL
    {
        /// <summary>
        /// for retrieving custom module calender detaails
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        /// <returns>datatable</returns>
        public static DataTable GetCalendarAddOnDetails(int calendarId)
        {
            DataTable dtCalendar = new DataTable("CalendarAddOn");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCalendarAddOnDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtCalendar);
                return dtCalendar;
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
