using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SendSMSNotificationsDAL;
using System.Data;
namespace SendSMSNotificationsBLL
{
    public class SMSBLL
    {
        public DataTable GetProfileDetailsByProfileID(int pProfileID)
        {
            SMSDAL objWowLog = new SMSDAL();
            return objWowLog.GetProfileDetailsByProfileID(pProfileID);
        }
        public int AddLogInDetails(DateTime LogDate, DateTime LogTime)
        {
            SMSDAL objWowLog = new SMSDAL();
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
            SMSDAL objWowLog = new SMSDAL();

            try
            {
                objWowLog.AddLogOutDetails(LogID, LogOutTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable GetSheduledSMSNotifications()
        {
            SMSDAL objWowLog = new SMSDAL();
            DataTable schSMSNotifications = new DataTable();
            try
            {
                schSMSNotifications = objWowLog.GetSheduledSMSNotifications();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return schSMSNotifications;
        }
        public void UpdateSMSSentStatus(int smsId)
        {
            SMSDAL objWowLog = new SMSDAL();

            try
            {
                objWowLog.UpdateSMSSentStatus(smsId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertExceptionDetails(string dataTablename, string errorMessage, string innerException, string data, string typeOfService)
        {
            SMSDAL objWowLog = new SMSDAL();
            try
            {
                objWowLog.InsertExceptionDetails(dataTablename, errorMessage, innerException, data, typeOfService);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public void ErrorHandling(string pMessage)
        {
            
        }
    }
}
