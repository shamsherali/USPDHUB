using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace SendPushNotificationsDAL
{
    public class NotificationsDAL
    {
       
       string Conn = ConfigurationManager.AppSettings.Get("USPDhubDevServer");

              public int AddLogInDetails(DateTime LogDate, DateTime LogTime)
        {
            int LogID;
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_AddSchPushNotificationLogin_Details", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCon.Open();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Log_Date", LogDate);
                sqlCmd.Parameters.AddWithValue("@LogIn_Time", LogTime);
                LogID = Convert.ToInt32(sqlCmd.ExecuteScalar());               
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
                SqlCommand sqlCmd = new SqlCommand("Ser_AddSchPushNotificationLogOut_Details", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCon.Open();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Log_ID", LogID);
                sqlCmd.Parameters.AddWithValue("@LogOut_Time", LogOutTime);
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
        public DataTable GetScheduledNotifications(DateTime SendingDate)
        {
            DataTable schNotifications = new DataTable();
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_GetScheduledNotifications", sqlCon);
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
        public DataTable GetMobileDevices(int profileID, int pushNotifyID, string pushType, int pushTypeId)
        {
            DataTable mobDevices = new DataTable();
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_GetMobileDevicesById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@PushNotifyID", pushNotifyID);
                sqlCmd.Parameters.AddWithValue("@PushType", pushType);
                sqlCmd.Parameters.AddWithValue("@PushTypeId", pushTypeId);
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
        public DataTable GetPrivateMobileDevices(int profileID, int pushNotifyID, string pushType, int pushTypeId)
        {
            DataTable mobDevices = new DataTable();
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_GetPrivateMobileDevicesById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@PushNotifyID", pushNotifyID);
                sqlCmd.Parameters.AddWithValue("@PushType", pushType);
                sqlCmd.Parameters.AddWithValue("@PushTypeId", pushTypeId);
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
        public void UpdatePushNotificationDevices(int profileID, int pushNotifyID, string pushType, int pushTypeId)
        {
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_UpdatePushNotificationDevices", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCon.Open();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@PushNotifyID", pushNotifyID);
                sqlCmd.Parameters.AddWithValue("@PushType", pushType);
                sqlCmd.Parameters.AddWithValue("@PushTypeId", pushTypeId);
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
        public void UpdateSentFlag(int pushNotifyID)
        {
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_UpdateNotificationSentFlag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                sqlCmd.Parameters.AddWithValue("@PushNotifyID", pushNotifyID);
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
                SqlCommand sqlCmd = new SqlCommand("Ser_UpdateReceiveStatusForPush", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                sqlCmd.Parameters.AddWithValue("@PushScheduledId", pushScheduledId);
                sqlCmd.Parameters.AddWithValue("@ReceiveFlag", receiveFlag);
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

        public  int GetNHPushAvailableSlot(int profileId, int appId)
        {
            SqlConnection sqlCon = new SqlConnection(Conn);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_M_GetAzureAvailableSlotNumber", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCon.Open();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@App_Id", appId);
                return Convert.ToInt32(sqlCmd.ExecuteScalar());
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

        public int GetTotalSlotCountByAppID(int profileID,int appID)
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
