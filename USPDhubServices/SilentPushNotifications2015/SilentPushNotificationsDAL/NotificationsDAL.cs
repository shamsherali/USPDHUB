using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SilentPushNotificationsDAL
{
    public class NotificationsDAL
    {
        public string Conn = ConfigurationManager.AppSettings.Get("USPDhubDevServer");
        public int AddLogInDetails(DateTime LogDate, DateTime LogTime)
        {
            int LogID;
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_AddNotificationLogin_Details", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCon.Open();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Log_Date", LogDate);
                sqlCmd.Parameters.AddWithValue("@LogIn_Time", LogTime);
                LogID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                sqlCon.Close();
                return LogID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
        public void AddLogOutDetails(int LogID, DateTime LogOutTime)
        {
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_AddNotificationLogOut_Details", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCon.Open();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Log_ID", LogID);
                sqlCmd.Parameters.AddWithValue("@LogOut_Time", LogOutTime);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
        public DataTable GetScheduledSilentNotifications(DateTime SendingDate)
        {
            DataTable schNotifications = new DataTable();
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_GetScheduledSilentNotifications", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchDate", SendingDate);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(schNotifications);
                return schNotifications;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
        public DataTable GetMobileDevices(int profileID)
        {
            DataTable mobDevices = new DataTable();
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_GetMobileDevicesByIdForSilentPush", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(mobDevices);
                return mobDevices;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
        public string GetPushTypeTabName(int profileID, string pushType, int pushTypeID)
        {
            string tabName = "";
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_GetPushTypeTabName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@PushType", pushType);
                sqlCmd.Parameters.AddWithValue("@PushTypeID", pushTypeID);
                tabName = Convert.ToString(sqlCmd.ExecuteScalar());
                return tabName;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
        public void UpdateSentFlag(int pSilentPushHistoryID)
        {
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_UpdateSilentNotificationSentFlag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                sqlCmd.Parameters.AddWithValue("@SilentPushHistoryID", pSilentPushHistoryID);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
        public void UpdateReceiveStatus(int pushScheduledId, int receiveFlag)
        {
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_UpdateSilentNotificationSentFlag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                sqlCmd.Parameters.AddWithValue("@SilentPushHistoryID", pushScheduledId);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }

        public DataTable GetHubDetails(int app_id)
        {

            DataTable dtHubDetails = new DataTable();
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("ser_GetHubDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                sqlCmd.Parameters.AddWithValue("@App_Id", app_id);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtHubDetails);
                return dtHubDetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }

        public DataTable GetHubDetailsByProfileId(int profileId)
        {

            DataTable dtHubDetails = new DataTable();
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_GetGenericAppAzureHubDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtHubDetails);
                return dtHubDetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }

        public void InsertExceptionDetails(string dataTablename, string errorMessage, string innerException, string data, string typeOfService)
        {
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Azure_InsertExceptionDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                sqlCmd.Parameters.AddWithValue("@dataTablename", dataTablename);
                sqlCmd.Parameters.AddWithValue("@errorMessage", errorMessage);
                sqlCmd.Parameters.AddWithValue("@innerException", innerException);
                sqlCmd.Parameters.AddWithValue("@data", data);
                sqlCmd.Parameters.AddWithValue("@typeOfService", typeOfService);
                sqlCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }

        }

        public int GetTotalSlotCountByAppID(int profileID, int appID)
        {

            int totalSlotCount = 0;
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_GetTotalSlotCountByAppID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileID);
                sqlCmd.Parameters.AddWithValue("@AppID", appID);
                totalSlotCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }

            return totalSlotCount;
        }

    }
}
