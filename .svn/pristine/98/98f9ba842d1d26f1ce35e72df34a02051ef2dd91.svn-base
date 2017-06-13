using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using USPDHUBDAL;

namespace USPDHUBBLL
{
    public class SMSBLL
    {
        /// <summary>
        /// Get Manage SMS
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetManageSMS(int pProfileID)
        {
            return SMSDAL.GetManageSMS(pProfileID);
        }

        /// <summary>
        /// Insert SMS Details
        /// </summary>
        /// <param name="pMessage">pMessage</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pMobileNumbers">pMobileNumbers</param>
        /// <returns>Int</returns>
        public int InsertSMSDetails(string pMessage, int pUserID, int pProfileID, string pMobileNumbers)
        {
            return SMSDAL.InsertSMSDetails(pMessage, pUserID, pProfileID, pMobileNumbers);
        }

        /// <summary>
        /// Delete SMS
        /// </summary>
        /// <param name="pSMSID">pSMSID</param>
        public  void DeleteSMS(int pSMSID)
        {
            SMSDAL.DeleteSMS(pSMSID);
        }

        /// <summary>
        /// Get SMS Details By SMSID
        /// </summary>
        /// <param name="pSMSID">pSMSID</param>
        /// <returns>DataTable</returns>
        public  DataTable GetSMSDetailsBySMSID(int pSMSID)
        {
            return SMSDAL.GetSMSDetailsBySMSID(pSMSID);
        }

        /// <summary>
        /// Get Groups By UserID
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <param name="IsPrivateModule">IsPrivateModule</param>
        /// <returns>DataTable</returns>
        public DataTable GetGroupsByUserID(int UserID, bool IsPrivateModule)
        {
            return SMSDAL.GetGroupsByUserID(UserID, IsPrivateModule);
        }

        /// <summary>
        /// Get Contacts By Contact GroupID
        /// </summary>
        /// <param name="ContactGroupIDs">ContactGroupIDs</param>
        /// <param name="UserID">UserID</param>
        /// <param name="checkflag">checkflag</param>
        /// <returns>DataTable</returns>
        public DataTable GetContactsByContactGroupID(string ContactGroupIDs, int UserID, bool checkflag)
        {
            return SMSDAL.GetContactsByContactGroupID(ContactGroupIDs, UserID, checkflag);
        }

        /// <summary>
        /// Add SMS Notification
        /// </summary>
        /// <param name="pushMessage">pushMessage</param>
        /// <param name="ContactID">ContactID</param>
        /// <param name="GroupID">GroupID</param>
        /// <param name="pushID">pushID</param>
        /// <param name="dtSentDate">dtSentDate</param>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="sentFlag">sentFlag</param>
        /// <returns>Int</returns>
        public int AddSMSNotification(string pushMessage, int ContactID, int GroupID, int pushID, DateTime dtSentDate, int ProfileID, int sentFlag)
        {
            return SMSDAL.AddSMSNotification(pushMessage, ContactID, GroupID, pushID, dtSentDate, ProfileID, sentFlag);
        }

        /// <summary>
        /// Get All SMS Count
        /// </summary>
        /// <param name="ProfileID">ProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllSMSCount(int ProfileID)
        {
            return SMSDAL.GetAllSMSCount(ProfileID);
        }

        /// <summary>
        /// Check Purchase SMS Exists
        /// </summary>
        /// <param name="ProfileID">ProfileID</param>
        /// <returns>Boolean</returns>
        public bool CheckPurchaseSMSExists(int ProfileID)
        {
            return SMSDAL.CheckPurchaseSMSExists(ProfileID);
        }
    }
}
