using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SendPushNotificationsDAL;
using System.Data;

namespace SendPushNotificationsBLL
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
        public DataTable GetScheduledNotifications(DateTime SendingDate)
        {
            NotificationsDAL objWOW = new NotificationsDAL();
            DataTable schNotifications = new DataTable();
            try
            {
                schNotifications = objWOW.GetScheduledNotifications(SendingDate);
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
        public DataTable GetMobileDevices(int profileID, int pushNotifyID, string pushType, int pushTypeId)
        {
            NotificationsDAL objWOW = new NotificationsDAL();
            DataTable mobDevices = new DataTable();
            try
            {
                mobDevices = objWOW.GetMobileDevices(profileID, pushNotifyID, pushType, pushTypeId);
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
        public DataTable GetPrivateMobileDevices(int profileID, int pushNotifyID, string pushType, int pushTypeId)
        {
            NotificationsDAL objWOW = new NotificationsDAL();
            DataTable mobDevices = new DataTable();
            try
            {
                mobDevices = objWOW.GetPrivateMobileDevices(profileID, pushNotifyID, pushType, pushTypeId);
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
        public void UpdatePushNotificationDevices(int profileID, int pushNotifyID, string pushType, int pushTypeId)
        {
            NotificationsDAL objWOW = new NotificationsDAL();
            try
            {
                objWOW.UpdatePushNotificationDevices(profileID, pushNotifyID, pushType, pushTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
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
        public void UpdateSentFlag(int pushNotifyID)
        {
            NotificationsDAL objWOW = new NotificationsDAL();
            try
            {
                objWOW.UpdateSentFlag(pushNotifyID);
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

        public DataTable GetHubDetails(int App_ID)
        {
            NotificationsDAL objWOW = new NotificationsDAL();
            DataTable dtHubDetails = new DataTable();
            try
            {
                dtHubDetails=objWOW.GetHubDetails(App_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return dtHubDetails;

        }

        public void InsertExceptionDetails(string dataTablename, string errorMessage, string innerException, string data, string typeOfService)
        {
            NotificationsDAL objWOW = new NotificationsDAL();
            try
            {
                objWOW.InsertExceptionDetails(dataTablename,errorMessage, innerException,data,typeOfService);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public int GetNHPushAvailableSlot(int profileId, int appId)
        {
            int availableSlot;
            NotificationsDAL objWOW = new NotificationsDAL();
            try
            {
                availableSlot= objWOW.GetNHPushAvailableSlot(profileId, appId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return availableSlot;
        }

        public DataTable GetHubDetailsByProfileId(int profileId)
        {
            NotificationsDAL objWOW = new NotificationsDAL();
            DataTable dtHubDetails = new DataTable();
            try
            {
                dtHubDetails = objWOW.GetHubDetailsByProfileId(profileId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return dtHubDetails;
        }

        public int GetTotalSlotCountByAppID(int profileID, int appID)
        {
            NotificationsDAL objWOW = new NotificationsDAL();
            return objWOW.GetTotalSlotCountByAppID(profileID, appID);
        }
    }
}
