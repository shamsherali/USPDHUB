using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SilentPushNotificationsDAL;

namespace SilentPushNotificationsBLL
{
    public class NotificationsBLL
    {
        public int AddLogInDetails(DateTime LogDate, DateTime LogTime)
        {
            NotificationsDAL objWowLog = new NotificationsDAL();
            int LogID;
            try
            {
                LogID = objWowLog.AddLogInDetails(LogDate, LogTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LogID;
        }
        public void AddLogOutDetails(int LogID, DateTime LogOutTime)
        {
            NotificationsDAL objWowLog = new NotificationsDAL();

            try
            {
                objWowLog.AddLogOutDetails(LogID, LogOutTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable GetScheduledSilentNotifications(DateTime SendingDate)
        {
            NotificationsDAL objWOW = new NotificationsDAL();
            DataTable schNotifications = new DataTable();
            try
            {
                schNotifications = objWOW.GetScheduledSilentNotifications(SendingDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return schNotifications;
        }
        public DataTable GetMobileDevices(int profileID)
        {
            NotificationsDAL objWOW = new NotificationsDAL();
            DataTable mobDevices = new DataTable();
            try
            {
                mobDevices = objWOW.GetMobileDevices(profileID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return mobDevices;
        }
        public string GetPushTypeTabName(int profileID, string pushType, int pushTypeID)
        {
            NotificationsDAL objWOW = new NotificationsDAL();
            string tabName = "";
            try
            {
                tabName = objWOW.GetPushTypeTabName(profileID, pushType, pushTypeID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return tabName;
        }
        public void UpdateSentFlag(int pSilentPushHistoryID)
        {
            NotificationsDAL objWOW = new NotificationsDAL();
            try
            {
                objWOW.UpdateSentFlag(pSilentPushHistoryID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public void UpdateReceiveStatus(int pushScheduledId, int receiveFlag)
        {
            NotificationsDAL objWOW = new NotificationsDAL();
            try
            {
                objWOW.UpdateReceiveStatus(pushScheduledId, receiveFlag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
    }
}
