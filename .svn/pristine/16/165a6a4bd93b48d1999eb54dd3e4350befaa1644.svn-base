using System;
using System.Data;
using USPDHUBDAL;

namespace USPDHUBBLL
{
    public class BusinessUpdatesBLL
    {
        /// <summary>
        /// Get All Business Updates
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllBusinessUpdates(int profileid)
        {
            return BusinessUpdatesDAL.GetAllBusinessUpdates(profileid);
        }
        //-------------listing all active business udpates-----------------
        /// <summary>
        /// Get Active Business Updates
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>DataTable</returns>
        public DataTable GetActiveBusinessUpdates(int profileid)
        {
            return BusinessUpdatesDAL.GetActiveBusinessUpdates(profileid);
        }
        //--------------------- inserting  business update details------------------
        /// <summary>
        /// Insert Business Update Details
        /// </summary>
        /// <param name="updateID">updateID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="title">title</param>
        /// <param name="businessType">businessType</param>
        /// <param name="status">status</param>
        /// <param name="businessDesc">businessDesc</param>
        /// <param name="updateName">updateName</param>
        /// <returns>Int</returns>
        public int InsertBusinessUpdateDetails(int updateID, int profileID, string title, string businessType, bool status, string businessDesc, string updateName)
        {

            return BusinessUpdatesDAL.InsertBusinessUpdateDetails(updateID, profileID, title, businessType, status, businessDesc, updateName);
        }
        //--------------------- inserting  business update details------------------

        //----------------------editing  business update details------------------------
        /// <summary>
        /// Update Business Update Details
        /// </summary>
        /// <param name="updateID">updateID</param>
        /// <returns>DataTable</returns>
        public DataTable UpdateBusinessUpdateDetails(int updateID)
        {
            return BusinessUpdatesDAL.UpdateBusinessUpdateDetails(updateID);
        }

        /// <summary>
        /// Delete Business Update Details
        /// </summary>
        /// <param name="updateID">updateID</param>
        /// <returns>Int</returns>
        public static int DeleteBusinessUpdateDetails(int updateID)
        {
            return BusinessUpdatesDAL.DeleteBusinessUpdateDetails(updateID);
        }

        /// <summary>
        /// Update Business Updates Text
        /// </summary>
        /// <param name="updateID">updateID</param>
        /// <returns>DataTable</returns>
        public DataTable UpdateBusinessUpdatesText(int updateID)
        {
            return BusinessUpdatesDAL.UpdateBusinessUpdatesText(updateID);
        }

        /// <summary>
        /// Status Business Update Details
        /// </summary>
        /// <param name="updateID">updateID</param>
        /// <param name="statusChg">statusChg</param>
        /// <returns>Int</returns>
        public static int StatusBusinessUpdateDetails(int updateID, bool statusChg)
        {
            return BusinessUpdatesDAL.StatusBusinessUpdateDetails(updateID, statusChg);
        }
        // --------------------------------- Adding Contact Management to BusinessUpdate Module -----------------------------------//
        /// <summary>
        /// Insert Business Update Schedule Details
        /// </summary>
        /// <param name="businessUpdateID">businessUpdateID</param>
        /// <param name="senderProfileID">senderProfileID</param>
        /// <param name="senderUserID">senderUserID</param>
        /// <param name="businessUpdateSubject">businessUpdateSubject</param>
        /// <param name="receiverEmailID">receiverEmailID</param>
        /// <param name="sendingDate">sendingDate</param>
        /// <param name="scheduleDate">scheduleDate</param>
        /// <param name="sentFlag">sentFlag</param>
        /// <param name="isToday">isToday</param>
        /// <param name="contactusChecked">contactusChecked</param>
        /// <param name="shareUpdate">shareUpdate</param>
        /// <param name="id">id</param>
        /// <param name="verticalID">verticalID</param>
        /// <returns>Int</returns>
        public int InsertBusinessUpdateScheduleDetails(int businessUpdateID, int senderProfileID, int senderUserID, string businessUpdateSubject, string receiverEmailID, DateTime sendingDate, DateTime scheduleDate, int sentFlag, bool isToday, bool contactusChecked, string shareUpdate, int id, int verticalID)
        {
            return BusinessUpdatesDAL.InsertBusinessUpdateScheduleDetails(businessUpdateID, senderProfileID, senderUserID, businessUpdateSubject, receiverEmailID, sendingDate, scheduleDate, sentFlag, isToday, contactusChecked, shareUpdate, id, verticalID);
        }

        /// <summary>
        /// Check for Business Update Schedule
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int CheckforBusinessUpdateSchedule(int userID)
        {
            return BusinessUpdatesDAL.CheckforBusinessUpdateSchedule(userID);
        }

        /// <summary>
        /// Get Business Update Max Scheduleing Date
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>String</returns>
        public string GetBusinessUpdateMaxScheduleingDate(int userID)
        {
            return BusinessUpdatesDAL.GetBusinessUpdateMaxScheduleingDate(userID);
        }

        /// <summary>
        /// Cancel Business Update Campaign
        /// </summary>
        /// <param name="businessUpdateID">businessUpdateID</param>
        public void CancelBusinessUpdateCampaign(int businessUpdateID)
        {
            BusinessUpdatesDAL.CancelBusinessUpdateCampaign(businessUpdateID);
        }

        /// <summary>
        /// Update Business Update Usage By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="usageDate">usageDate</param>
        public void UpdateBusinessUpdateUsageByUserID(int userID, DateTime usageDate)
        {
            BusinessUpdatesDAL.UpdateBusinessUpdateUsageByUserID(userID, usageDate);
        }

        /// <summary>
        /// Get Campaign Business Details By Dates
        /// </summary>
        /// <param name="businessUpdateID">businessUpdateID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCampaignBusinessDetailsByDates(int businessUpdateID)
        {
            return BusinessUpdatesDAL.GetCampaignBusinessDetailsByDates(businessUpdateID);
        }

        /// <summary>
        /// Get Business update Count for Day for User Date And UpdateID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="sendingDate">sendingDate</param>
        /// <param name="businessUpdateID">businessUpdateID</param>
        /// <returns>Int</returns>
        public int GetBusinessupdateCountforDayforUserDateAndUpdateID(int userID, DateTime sendingDate, int businessUpdateID)
        {
            return BusinessUpdatesDAL.GetBusinessupdateCountforDayforUserDateAndUpdateID(userID, sendingDate, businessUpdateID);
        }

        /// <summary>
        /// Unsubscribe Business Update For Scheduled MasterID and UserID
        /// </summary>
        /// <param name="businessUpdateID">businessUpdateID</param>
        /// <param name="userID">userID</param>
        /// <param name="userEmail">userEmail</param>
        /// <returns>Int</returns>
        public int UnsubscribeBusinessUpdateForSchMasterHisIDandUserID(int businessUpdateID, int userID, string userEmail)
        {
            return BusinessUpdatesDAL.UnsubscribeBusinessUpdateForSchMasterHisIDandUserID(businessUpdateID, userID, userEmail);
        }

        /// <summary>
        /// Get Opt Count For Business UpdateID
        /// </summary>
        /// <param name="businessUpdateID">businessUpdateID</param>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int GetOptCountForBusinessUpdateHisID(int businessUpdateID, int userID)
        {
            return BusinessUpdatesDAL.GetOptCountForBusinessUpdateHisID(businessUpdateID, userID);
        }

        /// <summary>
        /// Update Business and Update Master Sent Count
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="businessUpdateID">businessUpdateID</param>
        /// <param name="totalCount">totalCount</param>
        /// <param name="selectedCount">selectedCount</param>
        /// <param name="sendingDate">sendingDate</param>
        /// <param name="id">id</param>
        public void UpdateBusinessUpdateMasterSentCount(int userID, int businessUpdateID, int totalCount, int selectedCount, DateTime sendingDate, int id)
        {
            BusinessUpdatesDAL.UpdateBusinessUpdateMasterSentCount(userID, businessUpdateID, totalCount, selectedCount, sendingDate, id);
        }

        /// <summary>
        /// Check Business Updates Sending Count for Sending Date
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="businessUpdateSendingDate">businessUpdateSendingDate</param>
        /// <returns>Int</returns>
        public int CheckBusinessUpdatesSendingCountforSendingDate(int userID, DateTime businessUpdateSendingDate)
        {
            return BusinessUpdatesDAL.CheckBusinessUpdatesSendingCountforSendingDate(userID, businessUpdateSendingDate);
        }

        /// <summary>
        /// Update Business and Update Sending Date
        /// </summary>
        /// <param name="businessUpdateID">businessUpdateID</param>
        /// <param name="sendindDate">sendindDate</param>
        public void UpdateBusinessUpdateSendingDate(int businessUpdateID, DateTime sendindDate)
        {
            BusinessUpdatesDAL.UpdateBusinessUpdateSendingDate(businessUpdateID, sendindDate);
        }

        /// <summary>
        /// Check Business Update Campaign Count
        /// </summary>
        /// <param name="businessUpdateID">businessUpdateID</param>
        /// <returns>Int</returns>
        public int CheckBusinessUpdateCampaignCount(int businessUpdateID)
        {
            return BusinessUpdatesDAL.CheckBusinessUpdateCampaignCount(businessUpdateID);
        }

        /// <summary>
        /// Get Business Update Details By Business UpdateID
        /// </summary>
        /// <param name="businessUpdateID">businessUpdateID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessUpdateDetailsByBusinessUpdateID(int businessUpdateID)
        {
            return BusinessUpdatesDAL.GetBusinessUpdateDetailsByBusinessUpdateID(businessUpdateID);
        }

        /// <summary>
        /// Check For Unsent Business Update Emails for Delete
        /// </summary>
        /// <param name="businessUpdateID">businessUpdateID</param>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int CheckForUnsentBusinessUpdateEmailsforDelete(int businessUpdateID, int userID)
        {
            return BusinessUpdatesDAL.CheckForUnsentBusinessUpdateEmailsforDelete(businessUpdateID, userID);
        }

        /// <summary>
        /// Get Max Business Update UpdateID
        /// </summary>
        /// <returns>Int</returns>
        public int GetMaxBusinessUpdateUpdateID()
        {
            return BusinessUpdatesDAL.GetMaxBusinessUpdateUpdateID();
        }
        // --------------------------------- Adding Contact Management to BusinessUpdate Module -----------------------------------//
        /// <summary>
        /// Get Opt Out Count For UpdateID
        /// </summary>
        /// <param name="businessUpdateID">businessUpdateID</param>
        /// <returns>DataTable</returns>
        public DataTable GetOptOutCountForUpdateID(int businessUpdateID)
        {
            return BusinessUpdatesDAL.GetOptOutCountForUpdateID(businessUpdateID);
        }

        /// <summary>
        /// Get Opened Mails For ID
        /// </summary>
        /// <param name="moduleID">moduleID</param>
        /// <param name="userID">userID</param>
        /// <param name="mailType">mailType</param>
        /// <returns>Int</returns>
        public int GetOpenedMailsForID(int moduleID, int userID, string mailType)
        {
            return BusinessUpdatesDAL.GetOpenedMailsForID(moduleID, userID, mailType);
        }

        /// <summary>
        /// Get Opened Mails For UpdateID
        /// </summary>
        /// <param name="mailID">mailID</param>
        /// <param name="mailType">mailType</param>
        /// <returns>DataTable</returns>
        public DataTable GetOpenedMailsForUpdateID(int mailID, string mailType)
        {
            return BusinessUpdatesDAL.GetOpenedMailsForUpdateID(mailID, mailType);
        }

        /// <summary>
        /// Get Top 1 Profile Business Updates Info By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTop1ProfileBusinessUpdatesInfoByProfileID(int profileID)
        {
            return BusinessUpdatesDAL.GetTop1ProfileBusinessUpdatesInfoByProfileID(profileID);
        }
        // -------------------------Get Active Events Count ----------------------------- //
        /// <summary>
        /// Get Active Business Updates Count
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>Int</returns>
        public int GetActiveBusinessUpdatesCount(int profileid)
        {
            return BusinessUpdatesDAL.GetActiveBusinessUpdatesCount(profileid);
        }
        //issue 1095
        /// <summary>
        /// Update Business and Update Status
        /// </summary>
        /// <param name="updateID">updateID</param>
        /// <param name="status">status</param>
        /// <param name="profileID">profileID</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int UpdateBusinessUpdateStatus(int updateID, bool status, int profileID, int id)
        {

            return BusinessUpdatesDAL.UpdateBusinessUpdateStatus(updateID, status, profileID, id);
        }
        // *** Issue 1247 *** //
        /// <summary>
        /// Get Business Update Details By ScheduledID
        /// </summary>
        /// <param name="schID">schID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessUpdateDetailsBySchID(int schID)
        {
            return BusinessUpdatesDAL.GetBusinessUpdateDetailsBySchID(schID);
        }
        // *** Functionality Changes in Updates *** //
        /// <summary>
        /// Insert Business Update Details New
        /// </summary>
        /// <param name="updateID">updateID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="title">title</param>
        /// <param name="status">status</param>
        /// <param name="businessDesc">businessDesc</param>
        /// <param name="updateName">updateName</param>
        /// <param name="progressLevel">progressLevel</param>
        /// <param name="isPublic">isPublic</param>
        /// <param name="id">id</param>
        /// <param name="pPublishDate">pPublishDate</param>
        /// <param name="pEditHtml">pEditHtml</param>
        /// <param name="publishedBy">publishedBy</param>
        /// <param name="pListDescription">pListDescription</param>
        /// <param name="pExDate">pExDate</param>
        /// <param name="pIsCall">pIsCall</param>
        /// <param name="pIsContactUs">pIsContactUs</param>
        /// <returns>Int</returns>
        public int InsertBusinessUpdateDetailsNew(int updateID, int profileID, string title, bool status, string businessDesc, string updateName,
            bool progressLevel, bool isPublic, int id, DateTime? pPublishDate, string pEditHtml, int? publishedBy, string pListDescription,
            DateTime? pExDate, bool pIsCall, bool pIsContactUs)
        {

            return BusinessUpdatesDAL.InsertBusinessUpdateDetailsNew(updateID, profileID, title, status, businessDesc, updateName, progressLevel, isPublic,
                id, pPublishDate, pEditHtml, publishedBy, pListDescription, pExDate, pIsCall, pIsContactUs);
        }

        /// <summary>
        /// Get Updates Counts
        /// </summary>
        /// <param name="updateID">updateID</param>
        /// <param name="flag">flag</param>
        /// <param name="profileID">profileID</param>
        /// <returns>DataSet</returns>
        public DataSet GetUpdatesCounts(int updateID, int flag, int profileID)
        {
            return BusinessUpdatesDAL.GetUpdatesCounts(updateID, flag, profileID);
        }
        /// <summary>
        /// Get Send Updates By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetSendUpdatesByProfileID(int profileID)
        {
            return BusinessUpdatesDAL.GetSendUpdatesByProfileID(profileID);
        }
        // *** Get Update Schedule Emails Count *** //
        /// <summary>
        /// Check Business Update Campaign Count By ID
        /// </summary>
        /// <param name="updateID">updateID</param>
        /// <param name="moduleType">moduleType</param>
        /// <returns>DataTable</returns>
        public DataTable CheckBusinessUpdateCampaignCountByID(int updateID, string moduleType)
        {
            return BusinessUpdatesDAL.CheckBusinessUpdateCampaignCountByID(updateID, moduleType);
        }

        /// <summary>
        /// Check Update Name Available
        /// </summary>
        /// <param name="updateName">updateName</param>
        /// <param name="userID">userID</param>
        /// <returns>Boolean</returns>
        public bool CheckUpdateNameAvailable(string updateName, int userID)
        {
            return BusinessUpdatesDAL.CheckUpdateNameAvailable(updateName, userID);
        }

        /// <summary>
        /// Copy Update Details
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="updateID">updateID</param>
        /// <param name="updateName">updateName</param>
        /// <returns>Int</returns>
        public Int32 CopyUpdateDetails(int userID, int updateID, string updateName)
        {
            return BusinessUpdatesDAL.CopyUpdateDetails(userID, updateID, updateName);
        }

        /// <summary>
        /// Get Bounced Emails For UpdateID
        /// </summary>
        /// <param name="mailID">mailID</param>
        /// <param name="mailType">mailType</param>
        /// <returns>DataTable</returns>
        public DataTable GetBouncedEailsForUpdateID(int mailID, string mailType)
        {
            return BusinessUpdatesDAL.GetBouncedEailsForUpdateID(mailID, mailType);
        }

        /// <summary>
        /// Update Published Updates
        /// </summary>
        /// <param name="flag">flag</param>
        /// <param name="userID">userID</param>
        /// <param name="mUserID">mUserID</param>
        /// <param name="updateID">updateID</param>
        /// <param name="publishDate">publishDate</param>
        /// <param name="isPublished">isPublished</param>
        public void UpdatePublishedUpdates(bool flag, int userID, int mUserID, int updateID, DateTime? publishDate, bool isPublished)
        {
            BusinessUpdatesDAL.UpdatePublishedUpdates(flag, userID, mUserID, updateID, publishDate, isPublished);
        }

        /// <summary>
        /// Get Updates by UserId
        /// </summary>
        /// <param name="UserId">UserId</param>
        /// <returns>DataTable</returns>
        public DataTable GetUpdates(int UserId)
        {
            return BusinessUpdatesDAL.GetUpdates(UserId);
        }

        /// <summary>
        /// Update Business and Updates Order
        /// </summary>
        /// <param name="updateID">updateID</param>
        /// <param name="OrderNo">OrderNo</param>
        /// <param name="ID">ID</param>
        /// <returns>Int</returns>
        public int UpdateBusinessUpdatesOrder(int updateID, int OrderNo, int ID)
        {
            return BusinessUpdatesDAL.UpdateBusinessUpdatesOrder(updateID, OrderNo, ID);
        }
    }
}
