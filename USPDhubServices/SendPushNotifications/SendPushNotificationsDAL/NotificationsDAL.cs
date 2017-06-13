using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SendPushNotificationsDAL
{
    public class NotificationsDAL
    {
        public string Conn = ConfigurationSettings.AppSettings["USPDhubDevServer"].ToString();
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
                SqlCommand sqlCmd = new SqlCommand("Ser_GetMobileDevices", sqlCon);
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
    }
}
