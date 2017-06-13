using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace UserFormsDAL
{
    public class EventCalendarDAL
    {
        /// <summary>
        /// for retrievin calender event details.
        /// </summary>
        /// <param name="eventID">event id</param>
        /// <returns>datatable</returns>
        public static DataTable GetCalendarEventDetails(int eventID)
        {
            DataTable vtable = new DataTable("EventId");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCalendarEventDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventId", eventID);

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
        /// for inserting and updating auto share content details
        /// </summary>
        /// <param name="contentType">contenttype</param>
        /// <param name="contentID">contetid</param>
        /// <param name="send_Status">sendstatus</param>
        /// <param name="send_Date">end date</param>
        /// <param name="media_Type">media</param>
        /// <param name="userID">user id</param>
        /// <param name="createdUserId">created userid</param>
        /// <param name="contentTitle">content title</param>
        public static void InsertUpdateAutoShareDetails(string contentType, int contentID, int send_Status, DateTime send_Date, string media_Type, int userID, int createdUserId, string contentTitle)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertUpdateAutoShareDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@contentType", contentType);
                sqlCmd.Parameters.AddWithValue("@contentID", contentID);
                sqlCmd.Parameters.AddWithValue("@sendStatus", send_Status);
                sqlCmd.Parameters.AddWithValue("@sendDate", send_Date);
                sqlCmd.Parameters.AddWithValue("@mediaType", media_Type);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CreatedUserID", userID);
                sqlCmd.Parameters.AddWithValue("@ContentTitle", contentTitle);
                sqlCmd.ExecuteNonQuery();
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
        /// for updating sent flag
        /// </summary>
        /// <param name="contentId">contentid</param>
        /// <param name="flag">flag</param>
        /// <param name="existingFlag">existing flag</param>
        /// <param name="contentType">content type</param>
        public static void UpdateSentFlag(int contentId, int flag, int existingFlag, string contentType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateSentFlagStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContentId", contentId);
                sqlCmd.Parameters.AddWithValue("@SentFlagStatus", flag);
                sqlCmd.Parameters.AddWithValue("@ExistingFlag", existingFlag);
                sqlCmd.Parameters.AddWithValue("@ContentType", contentType);
                sqlCmd.Parameters.AddWithValue("@MediaType", null);
                sqlCmd.ExecuteNonQuery();
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

        public static DataTable CheckingModuleExists(int pProfileID, string pButtonType)
        {
            DataTable dt = new DataTable("dt");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckingModuleExists", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@ButtonType", pButtonType);
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
