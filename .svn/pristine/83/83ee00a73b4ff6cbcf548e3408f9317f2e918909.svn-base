using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using USPDHUBDAL;
using System.Web;

namespace USPDHUBBLL
{
    public class BulletinBLL
    {
        CommonBLL objCommon = new CommonBLL();

        /// <summary>
        /// Get Bulletin Categories
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <param name="vertical">vertical</param>
        /// <returns>DataTable</returns>
        public DataTable GetBulletinCategories(int UserID, string vertical)
        {
            return BulletinDAL.GetBulletinCategories(UserID, vertical);
        }

        /// <summary>
        /// Get Bulletins
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <param name="CategoryID">CategoryID</param>
        /// <param name="vertical">vertical</param>
        /// <returns>DataTable</returns>
        public DataTable GetBulletins(int UserID, int CategoryID, string vertical)
        {
            return BulletinDAL.GetBulletins(UserID, CategoryID, vertical);
        }

        /// <summary>
        /// Check Bulletin
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <param name="BulletinName">BulletinName</param>
        /// <param name="TemplateBID">TemplateBID</param>
        /// <param name="Type">Type</param>
        /// <returns>DataTable</returns>
        public DataTable CheckBulletin(int UserID, string BulletinName, int TemplateBID, string Type)
        {
            return BulletinDAL.CheckBulletin(UserID, BulletinName, TemplateBID, Type);
        }

        /// <summary>
        /// Get Manage Bulletins
        /// </summary>
        /// <param name="Filter">Filter</param>
        /// <param name="Category">Category</param>
        /// <param name="UserID">UserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetManageBulletins(int Filter, string Category, int UserID)
        {
            return BulletinDAL.GetManageBulletins(Filter, Category, UserID);
        }

        /// <summary>
        /// Delete Bulletin by BulletinID
        /// </summary>
        /// <param name="BulletinID">BulletinID</param>
        public void DeleteBulletin(int BulletinID)
        {
            BulletinDAL.DeleteBulletin(BulletinID);
        }

        /// <summary>
        /// Copy Bulletin
        /// </summary>
        /// <param name="BulletinID">BulletinID</param>
        /// <param name="BulletinTitle">BulletinTitle</param>
        /// <param name="UserID">UserID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>Int</returns>
        public int CopyBulletin(int BulletinID, string BulletinTitle, int UserID, int pProfileID)
        {
            int copyNewBID = BulletinDAL.CopyBulletin(BulletinID, BulletinTitle, UserID);

            #region MyRegion Update Long URL to Short URL

            // Update Long URL to Short URL
            string outerURL = objCommon.GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");
            string bulletinURL = outerURL + "/OnlineBulletin.aspx?BLID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(copyNewBID)).Replace("=", "irhmalli").Replace("+", "irhPASS");

            bulletinURL = objCommon.longurlToshorturl(bulletinURL);
            CommonDAL.UpdateShortenURl(copyNewBID, bulletinURL, "BULLETINS");

            #endregion

            #region    Genarate  Thumb

            DataTable dtCopyBulletinDetails = GetBulletinDetailsByID(copyNewBID);
            if (dtCopyBulletinDetails.Rows.Count > 0)
            {
                // Genarate App Thumb 
                objCommon.GenarateThumbnailForApp(copyNewBID, pProfileID, "Bulletins", dtCopyBulletinDetails.Rows[0]["Bulletin_HTML"].ToString());

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Web Thumb
                objInBuiltData.CreateImage(HttpContext.Current.Server.MapPath("~") + "\\Upload\\Bulletins\\", pProfileID, UserID, copyNewBID, dtCopyBulletinDetails.Rows[0]["Bulletin_HTML"].ToString());
            }

            #endregion

            return copyNewBID;
        }

        /// <summary>
        /// Rename Content
        /// </summary>
        /// <param name="contentID">contentID</param>
        /// <param name="contentTitle">contentTitle</param>
        /// <param name="modifiedUser">modifiedUser</param>
        /// <param name="contentType">contentType</param>
        /// <returns>Int</returns>
        public int RenameContent(int contentID, string contentTitle, int modifiedUser, string contentType,int profileid)
        {
            return BulletinDAL.RenameContent(contentID, contentTitle, modifiedUser, contentType,profileid);
        }

        /// <summary>
        /// Get Bulletin By BulletinID
        /// </summary>
        /// <param name="BulletinID">BulletinID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBulletinByID(int BulletinID)
        {
            return BulletinDAL.GetBulletinByID(BulletinID);
        }

        /// <summary>
        /// Get Bulletin Details By BulletinID
        /// </summary>
        /// <param name="pBulletinID">pBulletinID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBulletinDetailsByID(int pBulletinID)
        {
            return BulletinDAL.GetBulletinDetailsByID(pBulletinID);
        }

        /// <summary>
        /// Insert and Update BulletinDetails
        /// </summary>
        /// <param name="pBulletinID">pBulletinID</param>
        /// <param name="pTemplateBID">pTemplateBID</param>
        /// <param name="pBulletinTitle">pBulletinTitle</param>
        /// <param name="pBulletinHTML">pBulletinHTML</param>
        /// <param name="pBulletinXML">pBulletinXML</param>
        /// <param name="pCreatedUser">pCreatedUser</param>
        /// <param name="pModifyUser">pModifyUser</param>
        /// <param name="pIsArchive">pIsArchive</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pIsCall">pIsCall</param>
        /// <param name="pIsPhotoCapture">pIsPhotoCapture</param>
        /// <param name="pIsContactUs">pIsContactUs</param>
        /// <param name="pIsPrivate">pIsPrivate</param>
        /// <param name="pExpiryDate">pExpiryDate</param>
        /// <param name="pPublishDate">pPublishDate</param>
        /// <param name="Category">Category</param>
        /// <param name="IsPublic">IsPublic</param>
        /// <param name="PublishedBy">PublishedBy</param>
        /// <param name="printerHtml">printerHtml</param>
        /// <param name="pCustomXML">pCustomXML</param>
        /// <param name="pListDescription">pListDescription</param>
        /// <returns>Int</returns>
        public int Insert_Update_BulletinDetails(int pBulletinID, int pTemplateBID, string pBulletinTitle, string pBulletinHTML, string pBulletinXML,
            int pCreatedUser, int pModifyUser, bool pIsArchive, int pUserID, int pProfileID, bool pIsCall, bool pIsPhotoCapture, bool pIsContactUs,
            bool pIsPrivate, DateTime? pExpiryDate, DateTime? pPublishDate, string Category, bool IsPublic, int? PublishedBy,
            string printerHtml = "", string pCustomXML = "", string pListDescription = "")
        {
            if (pCustomXML == null)
            {
                pCustomXML = "";
            }

            // Get Shorten Url from Long Url
            pBulletinHTML = objCommon.ReplaceShortURltoHtmlString(pBulletinHTML);


            int BID = BulletinDAL.Insert_Update_BulletinDetails(pBulletinID, pTemplateBID, pBulletinTitle, pBulletinHTML, pBulletinXML, pCreatedUser, pModifyUser,
                pIsArchive, pUserID, pProfileID, pIsCall, pIsPhotoCapture, pIsContactUs, pIsPrivate, pExpiryDate, pPublishDate, Category, IsPublic,
                PublishedBy, printerHtml, pCustomXML, pListDescription);

            #region MyRegion Update Long URL to Short URL
            if (pBulletinID == 0)
            {
                // Update Long URL to Short URL
                string outerURL = objCommon.GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");
                string bulletinURL = outerURL + "/OnlineBulletin.aspx?BLID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(BID)).Replace("=", "irhmalli").Replace("+", "irhPASS");

                bulletinURL = objCommon.longurlToshorturl(bulletinURL);
                CommonDAL.UpdateShortenURl(BID, bulletinURL, "BULLETINS");
            }
            #endregion

            // Genarate App Thumb 
            objCommon.GenarateThumbnailForApp(BID, pProfileID, "Bulletins", pBulletinHTML);

            return BID;
        }


        /// <summary>
        /// Get Bulletins by UserId
        /// </summary>
        /// <param name="UserId">UserId</param>
        /// <returns>DataTable</returns>
        public DataTable GetBulletins(int UserId)
        {
            return BulletinDAL.GetBulletins(UserId);
        }

        /// <summary>
        /// Update Bulletins Order
        /// </summary>
        /// <param name="BulletinID">BulletinID</param>
        /// <param name="OrderNo">OrderNo</param>
        /// <param name="ID">ID</param>
        /// <returns>Int</returns>
        public int UpdateBulletinsOrder(int BulletinID, int OrderNo, int ID)
        {
            return BulletinDAL.UpdateBulletinsOrder(BulletinID, OrderNo, ID);
        }

        /// <summary>
        /// Update Bulletin Publish
        /// </summary>
        /// <param name="flag">flag</param>
        /// <param name="UserID">UserID</param>
        /// <param name="MUserID">MUserID</param>
        /// <param name="BulletinID">BulletinID</param>
        /// <param name="PublishDate">PublishDate</param>
        /// <param name="IsPublished">IsPublished</param>
        public void UpdateBulletinPublish(bool flag, int UserID, int MUserID, int BulletinID, DateTime? PublishDate, bool IsPublished)
        {
            BulletinDAL.UpdateBulletinPublish(flag, UserID, MUserID, BulletinID, PublishDate, IsPublished);
        }
        // *** Schedulling bulletins 24-06-2013 *** //
        /// <summary>
        /// Check for Bulletin Schedule by UserID
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns>Int</returns>
        public int CheckforBulletinSchedule(int UserID)
        {
            return BulletinDAL.CheckforBulletinSchedule(UserID);
        }

        /// <summary>
        /// Get Bulletin Max Scheduling Date by UserID
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns>String</returns>
        public string GetBulletinMaxScheduleingDate(int UserID)
        {
            return BulletinDAL.GetBulletinMaxScheduleingDate(UserID);
        }

        /// <summary>
        /// Check Bulletin Sending Count for Sending Date
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <param name="EventSendingDate">EventSendingDate</param>
        /// <returns>Int</returns>
        public int CheckBulletinSendingCountforSendingDate(int UserID, DateTime EventSendingDate)
        {
            return BulletinDAL.CheckBulletinSendingCountforSendingDate(UserID, EventSendingDate);
        }

        /// <summary>
        /// Insert Bulletin Schedule Details
        /// </summary>
        /// <param name="BulletinID">BulletinID</param>
        /// <param name="SenderProfileID">SenderProfileID</param>
        /// <param name="SenderUserID">SenderUserID</param>
        /// <param name="SchduleEventSubject">SchduleEventSubject</param>
        /// <param name="ReceiverEmailID">ReceiverEmailID</param>
        /// <param name="SendingDate">SendingDate</param>
        /// <param name="ScheduleDate">ScheduleDate</param>
        /// <param name="SentFlag">SentFlag</param>
        /// <param name="IsToday">IsToday</param>
        /// <param name="GroupID">GroupID</param>
        /// <param name="ContactusChecked">ContactusChecked</param>
        /// <param name="ShareBulletin">ShareBulletin</param>
        /// <param name="ID">ID</param>
        /// <param name="verticalID">verticalID</param>
        /// <param name="storeLinksChecked">storeLinksChecked</param>
        /// <returns>Int</returns>
        public int InsertBulletinScheduleDetails(int BulletinID, int SenderProfileID, int SenderUserID, string SchduleEventSubject, string ReceiverEmailID, DateTime SendingDate, DateTime ScheduleDate, int SentFlag, bool IsToday, string GroupID, bool ContactusChecked, string ShareBulletin, int ID, int verticalID, bool storeLinksChecked)
        {
            return BulletinDAL.InsertBulletinScheduleDetails(BulletinID, SenderProfileID, SenderUserID, SchduleEventSubject, ReceiverEmailID, SendingDate, ScheduleDate, SentFlag, IsToday, GroupID, ContactusChecked, ShareBulletin, ID, verticalID, storeLinksChecked);
        }

        /// <summary>
        /// Get Campaign Bulletin Details By Dates
        /// </summary>
        /// <param name="BulletinID">BulletinID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCampaignBulletinDetailsByDates(int BulletinID)
        {
            return BulletinDAL.GetCampaignBulletinDetailsByDates(BulletinID);
        }

        /// <summary>
        /// Cancel Bulletin Campaign
        /// </summary>
        /// <param name="BulletinID">BulletinID</param>
        public void CancelBulletinCampaign(int BulletinID)
        {
            BulletinDAL.CancelBulletinCampaign(BulletinID);
        }

        /// <summary>
        /// Get Bulletin Details By BulletinID
        /// </summary>
        /// <param name="BulletinID">BulletinID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBulletinDetailsByBulletinID(int BulletinID)
        {
            return BulletinDAL.GetBulletinDetailsByBulletinID(BulletinID);
        }

        /// <summary>
        /// Get Bulletin Count for Day for UserDate And BulletinID
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <param name="SendingDate">SendingDate</param>
        /// <param name="BulletinID">BulletinID</param>
        /// <returns>Int</returns>
        public int GetBulletinCountforDayforUserDateAndBulletinID(int UserID, DateTime SendingDate, int BulletinID)
        {
            return BulletinDAL.GetBulletinCountforDayforUserDateAndBulletinID(UserID, SendingDate, BulletinID);
        }

        /// <summary>
        /// Get Bulletin Details By ScheduleID
        /// </summary>
        /// <param name="SchID">SchID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBulletinDetailsBySchID(int SchID)
        {
            return BulletinDAL.GetBulletinDetailsBySchID(SchID);
        }

        /// <summary>
        /// Unsubscribe Bulletin For Schedule Master ID and UserID
        /// </summary>
        /// <param name="BulletinID">BulletinID</param>
        /// <param name="UserID">UserID</param>
        /// <param name="UserEmail">UserEmail</param>
        /// <returns>Int</returns>
        public int UnsubscribeBulletinForSchMasterHisIDandUserID(int BulletinID, int UserID, string UserEmail)
        {
            return BulletinDAL.UnsubscribeBulletinForSchMasterHisIDandUserID(BulletinID, UserID, UserEmail);
        }
        /****************************Entered By Suneel Kumar**********************************/
        /// <summary>
        /// Get Send Bulletins By ProfileID
        /// </summary>
        /// <param name="Profile_ID">Profile_ID</param>
        /// <returns>DataTable</returns>
        public DataTable GetSendBulletinsByProfileID(int Profile_ID)
        {
            return BulletinDAL.GetSendBulletinsByProfileID(Profile_ID);
        }
        /// <summary>
        /// Update Business Bulletin Status
        /// </summary>
        /// <param name="BulletinID">BulletinID</param>
        /// <param name="Status">Status</param>
        /// <param name="ProfileId">ProfileId</param>
        /// <param name="ID">ID</param>
        /// <returns>Int</returns>
        public int UpdateBusinessBulletinStatus(int BulletinID, bool Status, int ProfileId, int ID)
        {
            return BulletinDAL.UpdateBusinessBulletinStatus(BulletinID, Status, ProfileId, ID);
        }

        /// <summary>
        /// Update Business Bulletin Details by BulletinID
        /// </summary>
        /// <param name="BulletinID">BulletinID</param>
        /// <returns>DataTable</returns>
        public DataTable UpdateBusinessBulletinDetails(int BulletinID)
        {
            return BulletinDAL.UpdateBusinessBulletinDetails(BulletinID);
        }

        /// <summary>
        /// Get Opened Mails For BulletinID
        /// </summary>
        /// <param name="MailID">MailID</param>
        /// <param name="MailType">MailType</param>
        /// <returns>DataTable</returns>
        public DataTable GetOpenedMailsForBulletinID(int MailID, string MailType)
        {
            return BulletinDAL.GetOpenedMailsForBulletinID(MailID, MailType);
        }

        /// <summary>
        /// Get Bulletins Counts
        /// </summary>
        /// <param name="BulletinID">BulletinID</param>
        /// <param name="flag">flag</param>
        /// <param name="ProfileID">ProfileID</param>
        /// <returns>DataSet</returns>
        public DataSet GetBulletinsCounts(int BulletinID, int flag, int ProfileID)
        {
            return BulletinDAL.GetBulletinsCounts(BulletinID, flag, ProfileID);
        }

        /// <summary>
        /// Get OptOut Count For BulletinID
        /// </summary>
        /// <param name="BulletinID">BulletinID</param>
        /// <returns>DataTable</returns>
        public DataTable GetOptOutCountForBulletinID(int BulletinID)
        {
            return BulletinDAL.GetOptOutCountForBulletinID(BulletinID);
        }

        /// <summary>
        /// Get Business Bulletin Details By Business BulletinID
        /// </summary>
        /// <param name="BulletinID">BulletinID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessBulletinDetailsByBusinessBulletinID(int BulletinID)
        {
            return BulletinDAL.GetBusinessBulletinDetailsByBusinessBulletinID(BulletinID);
        }

        /// <summary>
        /// Get Bounced Emails For BulletinID
        /// </summary>
        /// <param name="MailID">MailID</param>
        /// <param name="MailType">MailType</param>
        /// <returns>DataTable</returns>
        public DataTable GetBouncedEMailsForBulletinID(int MailID, string MailType)
        {
            return BulletinDAL.GetBouncedEMailsForBulletinID(MailID, MailType);
        }
        /****************************Entered By Suneel Kumar**********************************/

        #region Crisis Call Log Master Data ---- Regions & Agency & Officers
        /// <summary>
        /// Get Caller Agency By ProfileID
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCallerAgencyByPID(int pProfileID)
        {
            return BulletinDAL.GetCallerAgencyByPID(pProfileID);
        }

        /// <summary>
        /// Get All Regions By ProfileID
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pType">pType</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllRegionsByPID(int pProfileID, string pType)
        {
            return BulletinDAL.GetAllRegionsByPID(pProfileID, pType);
        }

        /// <summary>
        /// Get Officers By Region Name
        /// </summary>
        /// <param name="pRegionName">pRegionName</param>
        /// <returns>DataTable</returns>
        public DataTable GetOfficersByRegionName(string pRegionName)
        {
            return BulletinDAL.GetOfficersByRegionName(pRegionName);
        }

        #endregion

        /// <summary>
        /// Get Bulletin Details By Dates
        /// </summary>
        /// <param name="pFromDate">pFromDate</param>
        /// <param name="pToDate">pToDate</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBulletinDetailsByDates(string pFromDate, string pToDate, int pProfileID)
        {
            return BulletinDAL.GetBulletinDetailsByDates(pFromDate, pToDate, pProfileID);
        }

        /// <summary>
        /// Insert Crisis Log Downloads
        /// </summary>
        /// <param name="pStartDate">pStartDate</param>
        /// <param name="pEndDate">pEndDate</param>
        /// <param name="pIsActive">pIsActive</param>
        /// <param name="pUserID">pUserID</param>
        /// <returns>Int</returns>
        public int InsertCrisisLogDownloads(DateTime pStartDate, DateTime pEndDate, bool pIsActive, int pUserID)
        {
            return BulletinDAL.InsertCrisisLogDownloads(pStartDate, pEndDate, pIsActive, pUserID);
        }

        /// <summary>
        /// Get Crisis Log Downloads
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCrisisLogDownloads(int pUserID)
        {
            return BulletinDAL.GetCrisiLogDownloads(pUserID);
        }

        /// <summary>
        /// Get Officer Types
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="DepartmentType">DepartmentType</param>
        /// <returns>DataTable</returns>
        public DataTable GetOfficerTypes(int pProfileID, string DepartmentType)
        {
            return BulletinDAL.GetOfficerTypes(pProfileID, DepartmentType);
        }

        /// <summary>
        /// Get Crime Weekly Reports Details By Dates
        /// </summary>
        /// <param name="pFromDate">pFromDate</param>
        /// <param name="pToDate">pToDate</param>
        /// <param name="pPID">pPID</param>
        /// <param name="pStatus">pStatus</param>
        /// <returns>DataTable</returns>
        public DataTable GetCrimeWeeklyReportsDetailsByDates(DateTime pFromDate, DateTime pToDate, int pPID, bool pStatus)
        {
            return BulletinDAL.GetCrimeWeeklyReportsDetailsByDates(pFromDate, pToDate, pPID, pStatus);

        }
        #region Favourite
        /// <summary>
        /// Get Favorite Categories
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetFavoriteCategories(int UserID)
        {
            return BulletinDAL.GetFavoriteCategories(UserID);
        }
        /// <summary>
        /// Get Available Favorites
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>DataSet</returns>
        public DataSet GetAvailableFavorites(int userId)
        {
            return BulletinDAL.GetAvailableFavorites(userId);
        }

        /// <summary>
        /// Add Favorite Template
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="userId">userId</param>
        /// <param name="createduser">createduser</param>
        /// <param name="templateId">templateId</param>
        /// <param name="moduleType">moduleType</param>
        /// <returns>Int</returns>
        public int AddFavoriteTemplate(int profileId, int userId, int createduser, int templateId, string moduleType)
        {
            return BulletinDAL.AddFavoriteTemplate(profileId, userId, createduser, templateId, moduleType);
        }

        /// <summary>
        /// Get Favorite Bulletins
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="categoryId">categoryId</param>
        /// <returns>DataTable</returns>
        public DataTable GetFavoriteBulletins(int userId, int categoryId)
        {
            return BulletinDAL.GetFavoriteBulletins(userId, categoryId);
        }

        /// <summary>
        /// Get Remove Favorites List
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns>DataSet</returns>
        public DataSet GetRemoveFavoritesList(int UserID)
        {
            return BulletinDAL.GetRemoveFavoritesList(UserID);
        }

        /// <summary>
        /// Remove Favorite Template by TemplateId
        /// </summary>
        /// <param name="TemplateId">TemplateId</param>
        public void RemoveFavoriteTemplate(int TemplateId)
        {
            BulletinDAL.RemoveFavoriteTemplate(TemplateId);
        }
        #endregion


        /// <summary>
        /// Get All Category Templates
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns>DataSet</returns>
        public DataSet GetAllCategoryTemplates(int UserID)
        {
            return BulletinDAL.GetAllCategoryTemplates(UserID);
        }

        /// <summary>
        /// Get Bulletin Blank Template Details
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBulletinBlankTemplateDetails(string profileID)
        {
            return BulletinDAL.GetBulletinBlankTemplateDetails(profileID);
        }
    }
}
