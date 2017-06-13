using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using USPDHUBDAL;
using System.Web;

namespace USPDHUBBLL
{
    public class AddOnBLL
    {
        CommonBLL objCommon = new CommonBLL();
        /// <summary>
        /// Getting Content Module data by using Custom Module ID
        /// </summary>
        /// <param name="customModuleId">customModuleId</param>
        /// <returns>DataTable</returns>
        public DataTable GetAddOnById(int customModuleId)
        {
            return AddOnDAL.GetAddOnById(customModuleId);
        }
        /// <summary>
        /// Getting all content module data by using UserID and CustomModuleID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="customModuleId">customModuleId</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllManageAddOns(int Filter, string Category, int userID, int customModuleId)
        {
            return AddOnDAL.GetAllManageAddOns(Filter, Category, userID, customModuleId);
        }
        /// <summary>
        /// Getting Custom Module data by using CustomID
        /// </summary>
        /// <param name="customID">customID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCustomModuleByID(int customID)
        {
            return AddOnDAL.GetCustomModuleByID(customID);
        }
        /// <summary>
        /// Deleting Custom Module reocrd by using CustomID
        /// </summary>
        /// <param name="customID">customID</param>
        public void DeleteCustomModule(int customID)
        {
            AddOnDAL.DeleteCustomModule(customID);
        }
        /// <summary>
        /// Updating Custom Module record when published
        /// </summary>
        /// <param name="flag">flag</param>
        /// <param name="UserID">UserID</param>
        /// <param name="MUserID">MUserID</param>
        /// <param name="customID">customID</param>
        /// <param name="PublishDate">PublishDate</param>
        /// <param name="IsPublished">IsPublished</param>
        public void UpdateCustomModulePublish(bool flag, int UserID, int MUserID, int customID, DateTime? PublishDate, bool IsPublished)
        {
            AddOnDAL.UpdateCustomModulePublish(flag, UserID, MUserID, customID, PublishDate, IsPublished);
        }
        /// <summary>
        /// Updating Order
        /// </summary>
        /// <param name="customID">customID</param>
        /// <param name="OrderNo">OrderNo</param>
        /// <param name="ID">ID</param>
        /// <returns>Int</returns>
        public int UpdateOrder(int customID, int OrderNo, int ID)
        {
            return AddOnDAL.UpdateOrder(customID, OrderNo, ID);
        }
        /// <summary>
        /// Getting Published Items by using UserID and CustomModuleID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="customModuleID">customModuleID</param>
        /// <returns>DataTable</returns>
        public DataTable GetPublishedItemsByID(int userID, int customModuleID)
        {
            return AddOnDAL.GetPublishedItemsByID(userID, customModuleID);
        }
        /// <summary>
        /// Checking the availability of record 
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <param name="BulletinName">BulletinName</param>
        /// <param name="Type">Type</param>
        /// <param name="customModuleID">customModuleID</param>
        /// <returns>DataTable</returns>
        public DataTable CheckAvailability(int UserID, string BulletinName, string Type, int customModuleID)
        {
            return AddOnDAL.CheckAvailability(UserID, BulletinName, Type, customModuleID);
        }
        /// <summary>
        /// Copying the record
        /// </summary>
        /// <param name="customID">customID</param>
        /// <param name="BulletinTitle">BulletinTitle</param>
        /// <param name="UserID">UserID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="cUserID">cUserID</param>
        /// <returns>Int</returns>
        public int CopyItem(int customID, string BulletinTitle, int UserID, int pProfileID, int cUserID)
        {
            int copyNewID = AddOnDAL.CopyItem(customID, BulletinTitle, UserID, cUserID);

            #region MyRegion Update Long URL to Short URL

            // Update Long URL to Short URL
            string outerURL = objCommon.GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");
            string bulletinURL = outerURL + "/OnlineItem.aspx?CMID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(copyNewID)).Replace("=", "irhmalli").Replace("+", "irhPASS");

            bulletinURL = objCommon.longurlToshorturl(bulletinURL);
            CommonDAL.UpdateShortenURl(copyNewID, bulletinURL, "CUSTOMMODULE");

            #endregion

            #region    Genarate  Thumb

            DataTable dtCopyContentDetails = GetCustomModuleByID(copyNewID);
            if (dtCopyContentDetails.Rows.Count > 0)
            {
                // Genarate App Thumb 
                objCommon.GenarateThumbnailForApp(copyNewID, pProfileID, "CustomModules", dtCopyContentDetails.Rows[0]["Bulletin_HTML"].ToString());

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Web Thumb
                objInBuiltData.CreateImage(HttpContext.Current.Server.MapPath("~") + "\\Upload\\CustomModules\\", pProfileID, UserID, copyNewID, dtCopyContentDetails.Rows[0]["Bulletin_HTML"].ToString());
            }

            #endregion

            return copyNewID;
        }
        /// <summary>
        /// Checking for schedule record by using UserID and CustomModuleID
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <param name="customModuleID">customModuleID</param>
        /// <returns>Int</returns>
        public int CheckforItemSchedule(int UserID, int customModuleID)
        {
            return AddOnDAL.CheckforItemSchedule(UserID, customModuleID);
        }
        /// <summary>
        /// Getting Max Schedule dates of the record by using UserID and CustomModuleID
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <param name="customModuleID">customModuleID</param>
        /// <returns>String</returns>
        public string GetItemMaxScheduleingDate(int UserID, int customModuleID)
        {
            return AddOnDAL.GetItemMaxScheduleingDate(UserID, customModuleID);
        }
        /// <summary>
        /// Checking the record sending count for sending date
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <param name="EventSendingDate">EventSendingDate</param>
        /// <param name="customModuleID">customModuleID</param>
        /// <returns>Int</returns>
        public int CheckItemSendingCountforSendingDate(int UserID, DateTime EventSendingDate, int customModuleID)
        {
            return AddOnDAL.CheckItemSendingCountforSendingDate(UserID, EventSendingDate, customModuleID);
        }
        /// <summary>
        /// Inserting Schedule Details of the record
        /// </summary>
        /// <param name="customID">customID</param>
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
        public int InsertItemScheduleDetails(int customID, int SenderProfileID, int SenderUserID, string SchduleEventSubject, string ReceiverEmailID, DateTime SendingDate, DateTime ScheduleDate, int SentFlag, bool IsToday, string GroupID, bool ContactusChecked, string ShareBulletin, int ID, int verticalID, bool storeLinksChecked)
        {
            return AddOnDAL.InsertItemScheduleDetails(customID, SenderProfileID, SenderUserID, SchduleEventSubject, ReceiverEmailID, SendingDate, ScheduleDate, SentFlag, IsToday, GroupID, ContactusChecked, ShareBulletin, ID, verticalID, storeLinksChecked);
        }
        /// <summary>
        /// Unsubscribe records for schedule master ID and user ID
        /// </summary>
        /// <param name="customID">customID</param>
        /// <param name="UserID">UserID</param>
        /// <param name="UserEmail">UserEmail</param>
        /// <returns>Int</returns>
        public int UnsubscribeItemForSchMasterHisIDandUserID(int customID, int UserID, string UserEmail)
        {
            return AddOnDAL.UnsubscribeItemForSchMasterHisIDandUserID(customID, UserID, UserEmail);
        }
        /// <summary>
        /// Cancel the record from Campaign
        /// </summary>
        /// <param name="customID">customID</param>
        public void CancelItemCampaign(int customID)
        {
            AddOnDAL.CancelItemCampaign(customID);
        }
        /// <summary>
        /// Getting Scheduled Details by using CustomID
        /// </summary>
        /// <param name="customID">customID</param>
        /// <returns>DataTable</returns>
        public DataTable GetScheduledDetailsByCustomID(int customID)
        {
            return AddOnDAL.GetScheduledDetailsByCustomID(customID);
        }
        /// <summary>
        /// Getting Campaign records details by using Dates
        /// </summary>
        /// <param name="customID">customID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCampaignItemDetailsByDates(int customID)
        {
            return AddOnDAL.GetCampaignItemDetailsByDates(customID);
        }
        /// <summary>
        /// Getting record count for day for user date and customID
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <param name="SendingDate">SendingDate</param>
        /// <param name="BulletinID">BulletinID</param>
        /// <returns>Int</returns>
        public int GetItemCountforDayforUserDateAndCustomID(int UserID, DateTime SendingDate, int BulletinID)
        {
            return AddOnDAL.GetItemCountforDayforUserDateAndCustomID(UserID, SendingDate, BulletinID);
        }
        /// <summary>
        /// Getting send records ny using ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="customerModuleID">customerModuleID</param>
        /// <returns>DataTable</returns>
        public DataTable GetSendItemsByProfileID(int profileID, int customerModuleID)
        {
            return AddOnDAL.GetSendItemsByProfileID(profileID, customerModuleID);
        }
        /// <summary>
        /// Get the opt out count for records using CustomID
        /// </summary>
        /// <param name="customId">customId</param>
        /// <returns>DataTable</returns>
        public DataTable GetOptOutCountForItems(int customId)
        {
            return AddOnDAL.GetOptOutCountForItems(customId);
        }
        /// <summary>
        /// Getting records count
        /// </summary>
        /// <param name="customID">customID</param>
        /// <param name="flag">flag</param>
        /// <param name="ProfileID">ProfileID</param>
        /// <returns>DataSet</returns>
        public DataSet GetItemsCounts(int customID, int flag, int ProfileID)
        {
            return AddOnDAL.GetItemsCount(customID, flag, ProfileID);
        }
        /// <summary>
        /// Getting record details by using Schedule ID
        /// </summary>
        /// <param name="schID">schID</param>
        /// <returns>DataTable</returns>
        public DataTable GetItemDetailsBySchID(int schID)
        {
            return AddOnDAL.GetItemDetailsBySchID(schID);
        }
        /// <summary>
        /// Inserting and Updating records
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="cUserID">cUserID</param>
        /// <param name="customID">customID</param>
        /// <param name="customModuleId">customModuleId</param>
        /// <param name="moduleID">moduleID</param>
        /// <param name="bulletinTitle">bulletinTitle</param>
        /// <param name="bulletinHtml">bulletinHtml</param>
        /// <param name="bulletinXml">bulletinXml</param>
        /// <param name="isArchive">isArchive</param>
        /// <param name="isCall">isCall</param>
        /// <param name="isPhotoCapture">isPhotoCapture</param>
        /// <param name="isContactUs">isContactUs</param>
        /// <param name="expiryDate">expiryDate</param>
        /// <param name="isPublished">isPublished</param>
        /// <param name="publishDate">publishDate</param>
        /// <param name="publishedBy">publishedBy</param>
        /// <param name="printerHtml">printerHtml</param>
        /// <param name="customXML">customXML</param>
        /// <param name="listDescription">listDescription</param>
        /// <returns>Int</returns>
        public int AddUpdateItem(int profileID, int userID, int cUserID, int customID, int customModuleId, int moduleID, string bulletinTitle, string bulletinHtml, string bulletinXml,
            bool isArchive, bool isCall, bool isPhotoCapture, bool isContactUs, DateTime? expiryDate, bool isPublished, DateTime? publishDate, int? publishedBy, string categoryName,
            string printerHtml = "", string customXML = "", string listDescription = "")
        {
            if (customXML == null)
            {
                customXML = "";
            }

            // Get Shorten Url from Long Url
            bulletinHtml = objCommon.ReplaceShortURltoHtmlString(bulletinHtml);


            int returnID = AddOnDAL.AddUpdateItem(profileID, userID, cUserID, customID, customModuleId, moduleID, bulletinTitle, bulletinHtml, bulletinXml,
                  isArchive, isCall, isPhotoCapture, isContactUs, expiryDate, isPublished, publishDate, publishedBy, categoryName, printerHtml, customXML, listDescription);

            #region MyRegion Update Long URL to Short URL

            if (customID == 0)
            {
                string outerURL = objCommon.GetConfigSettings(Convert.ToString(profileID), "Paths", "RootPath");
                string bulletinURL = outerURL + "/OnlineItem.aspx?CMID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(returnID)).Replace("=", "irhmalli").Replace("+", "irhPASS");

                bulletinURL = objCommon.longurlToshorturl(bulletinURL);
                CommonDAL.UpdateShortenURl(returnID, bulletinURL, "CUSTOMMODULE");
            }
            #endregion


            // Genarate App Thumb 
            objCommon.GenarateThumbnailForApp(returnID, profileID, "CustomModules", bulletinHtml);

            return returnID;
        }
        /// <summary>
        /// Get user custom modules by using UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserCustomModules(int userID)
        {
            return AddOnDAL.GetUserCustomModules(userID);
        }
        /// <summary>
        /// Get user custom modules by using UserModuleID
        /// </summary>
        /// <param name="userModuleID">userModuleID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserCustomModuleById(int userModuleID)
        {
            return AddOnDAL.GetUserCustomModuleById(userModuleID);
        }
        /// <summary>
        /// Updating Custom Module Icon
        /// </summary>
        /// <param name="userModuleID">userModuleID</param>
        /// <param name="isVisible">isVisible</param>
        /// <param name="tabName">tabName</param>
        /// <param name="appIcon">appIcon</param>
        /// <param name="onlyVisible">onlyVisible</param>
        /// <param name="cUserID">cUserID</param>
        public void UpdateCustomModuleIcon(int userModuleID, bool isVisible, string tabName, string appIcon, bool onlyVisible, int cUserID)
        {
            AddOnDAL.UpdateCustomModuleIcon(userModuleID, isVisible, tabName, appIcon, onlyVisible, cUserID);
        }
        /// <summary>
        /// Get the Active Forms by using UserModuleID and CustomID
        /// </summary>
        /// <param name="userModuleID">userModuleID</param>
        /// <param name="customID">customID</param>
        /// <returns>DataTable</returns>
        public DataTable GetActiveForms(int userModuleID, int? customID)
        {
            return AddOnDAL.GetActiveForms(userModuleID, customID);
        }
        /// <summary>
        /// Get Remaining Forms
        /// </summary>
        /// <param name="userModuleID">userModuleID</param>
        /// <param name="domainName">domainName</param>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetRemainingForms(int userModuleID, string domainName, int userID)
        {
            return AddOnDAL.GetRemainingForms(userModuleID, domainName, userID);
        }
        /// <summary>
        /// Inserting Purcahsed Forms
        /// </summary>
        /// <param name="formID">formID</param>
        /// <param name="userModuleID">userModuleID</param>
        /// <param name="moduleID">moduleID</param>
        /// <param name="createdUser">createdUser</param>
        /// <param name="isActive">isActive</param>
        public void InsertPurchasedForms(int formID, int userModuleID, int moduleID, int createdUser, bool isActive)
        {
            AddOnDAL.InsertPurchasedForms(formID, userModuleID, moduleID, createdUser, isActive);
        }
        /// <summary>
        /// Get Manage Content Modules
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="userModuleID">userModuleID</param>
        /// <returns>DataSet</returns>
        public DataSet GetManageAddOns(int userID, int? userModuleID)
        {
            return AddOnDAL.GetManageAddOns(userID, userModuleID);
        }
        /// <summary>
        /// Updating App Button Order
        /// </summary>
        /// <param name="userModuleID">userModuleID</param>
        /// <param name="OrderNo">OrderNo</param>
        /// <param name="cuserID">cuserID</param>
        /// <returns>Int</returns>
        public int UpdateAppButtnOrder(int userModuleID, int OrderNo, int cuserID)
        {
            return AddOnDAL.UpdateAppButtnOrder(userModuleID, OrderNo, cuserID);
        }
        /// <summary>
        /// Inserting default App buttons
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="domainName">domainName</param>
        /// <param name="cuserID">cuserID</param>
        public void InsertDefaultAppButtons(int profileID, int userID, string domainName, int cuserID)
        {
            AddOnDAL.InsertDefaultAppButtons(profileID, userID, domainName, cuserID);
        }
        /// <summary>
        /// Get Initial Content Modules
        /// </summary>
        /// <param name="domainName">domainName</param>
        /// <param name="buttonType">buttonType</param>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetInitialAddOns(string domainName, string buttonType, int userID)
        {
            return AddOnDAL.GetInitialAddOns(domainName, buttonType, userID);
        }
        /// <summary>
        /// Inserting Initial Content Modules
        /// </summary>
        /// <param name="defaultButtonID">defaultButtonID</param>
        /// <param name="moduleID">moduleID</param>
        /// <param name="userID">userID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="cuserID">cuserID</param>
        public void InsertInitialAddOns(int defaultButtonID, int moduleID, int userID, int profileID, int cuserID)
        {
            AddOnDAL.InsertInitialAddOns(defaultButtonID, moduleID, userID, profileID, cuserID);
        }
        /// <summary>
        /// Adding Additional Tab
        /// </summary>
        /// <param name="domainName">domainName</param>
        /// <param name="profileID">profileID</param>
        /// <param name="buttonType">buttonType</param>
        public void AddAdditionalTab(string domainName, int profileID, string buttonType)
        {
            AddOnDAL.AddAdditionalTab(domainName, profileID, buttonType);
        }

        #region ***************************   Call Index Add Ons  *******************************
        /// <summary>
        /// Get all manage call index Content Modules
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pCustomModuleId">pCustomModuleId</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllManageCallIndexAddOns(int pUserID, int pCustomModuleId)
        {
            return AddOnDAL.GetAllManageCallIndexAddOns(pUserID, pCustomModuleId);
        }
        /// <summary>
        /// Changing call Content Module Visiblity
        /// </summary>
        /// <param name="customId">customId</param>
        /// <param name="modifiedUser">modifiedUser</param>
        /// <returns>Int</returns>
        public int ChangeCallAddOnVisiblity(int customId, int modifiedUser)
        {
            return AddOnDAL.ChangeCallAddOnVisiblity(customId, modifiedUser);
        }
        /// <summary>
        /// Get Group Detailsby using UserModuleID
        /// </summary>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <returns>DataSet</returns>
        public DataSet GetGroupsData(int UserModuleID)
        {
            return AddOnDAL.GetGroupsData(UserModuleID);
        }
        /// <summary>
        /// Insert and Update Call Index Data
        /// </summary>
        /// <param name="CustomID">CustomID</param>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="UserID">UserID</param>
        /// <param name="Title">Title</param>
        /// <param name="ImageUrls">ImageUrls</param>
        /// <param name="MobileNumber">MobileNumber</param>
        /// <param name="IsAutoEmail">IsAutoEmail</param>
        /// <param name="Email_Description">Email_Description</param>
        /// <param name="Email_GroupIDs">Email_GroupIDs</param>
        /// <param name="IsAutoPushNotification">IsAutoPushNotification</param>
        /// <param name="PushNotification_Description">PushNotification_Description</param>
        /// <param name="PushNotification_GroupIDs">PushNotification_GroupIDs</param>
        /// <param name="IsAutoTextMessage">IsAutoTextMessage</param>
        /// <param name="SMS_Description">SMS_Description</param>
        /// <param name="SMS_GroupIDs">SMS_GroupIDs</param>
        /// <param name="IsGPSInformation">IsGPSInformation</param>
        /// <param name="IsAllPhoneInformation">IsAllPhoneInformation</param>
        /// <param name="IsActive">IsActive</param>
        /// <param name="CreatedUser">CreatedUser</param>
        /// <param name="ModifyUser">ModifyUser</param>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <param name="IsDeleted">IsDeleted</param>
        /// <param name="IsPublish">IsPublish</param>
        /// <param name="IsPublic">IsPublic</param>
        /// <param name="Email_Subject">Email_Subject</param>
        /// <param name="PushNotification_Subject">PushNotification_Subject</param>
        /// <param name="SMS_Subject">SMS_Subject</param>
        /// <param name="Description">Description</param>
        /// <param name="PreviewHtml">PreviewHtml</param>
        /// <param name="IsVisible">IsVisible</param>
        /// <returns>Int</returns>
        public int InsertUpdateCallIndexData(int CustomID, int ProfileID, int UserID, string Title, string ImageUrls, string MobileNumber, bool IsAutoEmail, string Email_Description, string Email_GroupIDs,
                     bool IsAutoPushNotification, string PushNotification_Description, string PushNotification_GroupIDs, bool IsAutoTextMessage, string SMS_Description, string SMS_GroupIDs,
                     bool IsGPSInformation, bool IsAllPhoneInformation, bool IsActive, int CreatedUser, int ModifyUser, int UserModuleID, bool IsDeleted, bool IsPublish,
                     bool IsPublic, string Email_Subject, string PushNotification_Subject, string SMS_Subject, string Description, string PreviewHtml, bool IsVisible, bool IsInitiatesPhoneCall, bool IsPredefinedMessage, bool IsUploadImage)
        {
            int returnID = AddOnDAL.InsertUpdateCallIndexData(CustomID, ProfileID, UserID, Title, ImageUrls, MobileNumber, IsAutoEmail, Email_Description, Email_GroupIDs, IsAutoPushNotification,
                    PushNotification_Description, PushNotification_GroupIDs, IsAutoTextMessage, SMS_Description, SMS_GroupIDs,
                    IsGPSInformation, IsAllPhoneInformation, IsActive, CreatedUser, ModifyUser, UserModuleID, IsDeleted, IsPublish,
                    IsPublic, Email_Subject, PushNotification_Subject, SMS_Subject, Description, PreviewHtml, IsVisible, IsInitiatesPhoneCall, IsPredefinedMessage, IsUploadImage);

            // Genarate App Thumb 
            objCommon.GenarateThumbnailForApp(returnID, ProfileID, "PrivateCallModules", ImageUrls);

            return returnID;

        }
        /// <summary>
        /// Get Call Index Buttons 
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="userModuleId">userModuleId</param>
        /// <returns>DataTable</returns>
        public DataTable GetCallIndex_Buttons(int pProfileID, int? userModuleId)
        {
            return AddOnDAL.GetCallIndex_Buttons(pProfileID, userModuleId);
        }
        /// <summary>
        /// Get call index details by using customID
        /// </summary>
        /// <param name="pCustomID">pCustomID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCallIndexDetailsByID(int pCustomID)
        {
            return AddOnDAL.GetCallIndexDetailsByID(pCustomID);
        }
        /// <summary>
        /// Delete Call Index by using customID
        /// </summary>
        /// <param name="pCustomID">pCustomID</param>
        public void DeleteCallIndexItem(int pCustomID, int UserID)
        {
            AddOnDAL.DeleteCallIndexItem(pCustomID, UserID);
        }
        /// <summary>
        /// Get Group names for send invitation
        /// </summary>
        /// <param name="pUserModuleID">pUserModuleID</param>
        /// <param name="pUserID">pUserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetGroupNamesForSendInvitation(int pUserModuleID, int pUserID)
        {
            return AddOnDAL.GetGroupNamesForSendInvitation(pUserModuleID, pUserID);
        }
        /// <summary>
        /// Get all contacts for send invitation
        /// </summary>
        /// <param name="pUserModuleID">pUserModuleID</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pGroupID">pGroupID</param>
        /// <param name="pValue">pValue</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllContactsForSendInvitation(int pUserModuleID, int pUserID, string pGroupID, string pValue)
        {
            return AddOnDAL.GetAllContactsForSendInvitation(pUserModuleID, pUserID, pGroupID, pValue);
        }
        /// <summary>
        /// Get call index groups by using UserModuleID
        /// </summary>
        /// <param name="userModuleId">userModuleId</param>
        /// <returns>DataSet</returns>
        public DataSet GetCallIndexGroups(int userModuleId)
        {
            return AddOnDAL.GetCallIndexGroups(userModuleId);
        }
        /// <summary>
        /// Adding Group
        /// </summary>
        /// <param name="GroupID">GroupID</param>
        /// <param name="GroupName">GroupName</param>
        /// <param name="GroupDescription">GroupDescription</param>
        /// <param name="IsActive">IsActive</param>
        /// <param name="IsDeleted">IsDeleted</param>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="CreatedUser">CreatedUser</param>
        /// <param name="UserID">UserID</param>
        /// <returns>Int</returns>
        public int AddGroup(int GroupID, string GroupName, string GroupDescription, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int CreatedUser, int UserID)
        {
            return AddOnDAL.AddGroup(GroupID, GroupName, GroupDescription, IsActive, IsDeleted, UserModuleID, ProfileID, CreatedUser, UserID);
        }
        /// <summary>
        /// Get Active Contacts by using UserModuleID and GroupID
        /// </summary>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <param name="GroupIDs">GroupIDs</param>
        /// <returns>DataTable</returns>
        public DataTable GetActiveContacts(int UserModuleID, string GroupIDs)
        {
            return AddOnDAL.GetActiveContacts(UserModuleID, GroupIDs);
        }

        public DataTable GetAllContacts(int UserModuleID)
        {
            return AddOnDAL.GetAllContacts(UserModuleID);
        }
        /// <summary>
        /// Deleting Group by using GroupID
        /// </summary>
        /// <param name="groupIds">groupIds</param>
        public void DeleteGroups(string groupIds)
        {
            AddOnDAL.DeleteGroups(groupIds);
        }
        /// <summary>
        /// Insert and Update Contacts
        /// </summary>
        /// <param name="contactID">contactID</param>
        /// <param name="FirstName">FirstName</param>
        /// <param name="LastName">LastName</param>
        /// <param name="EmailID">EmailID</param>
        /// <param name="CompanyName">CompanyName</param>
        /// <param name="Address">Address</param>
        /// <param name="City">City</param>
        /// <param name="State">State</param>
        /// <param name="Zipcode">Zipcode</param>
        /// <param name="Landline">Landline</param>
        /// <param name="MobileNumber">MobileNumber</param>
        /// <param name="FaxNumber">FaxNumber</param>
        /// <param name="IsActive">IsActive</param>
        /// <param name="IsDeleted">IsDeleted</param>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="UserID">UserID</param>
        /// <param name="CreatedUser">CreatedUser</param>
        /// <returns>Int</returns>
        public int InsertUpdateContacts(int contactID, string FirstName, string LastName, string EmailID, string CompanyName, string Address, string City, string State, string Zipcode, string Landline, string MobileNumber, string FaxNumber, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int UserID, int CreatedUser, string Position, string Organization, bool IsAllowedToSendIvitation, bool IsEmail_SMS_Unsubscribe)
        {
            return AddOnDAL.InsertUpdateContacts(contactID, FirstName, LastName, EmailID, CompanyName, Address, City, State, Zipcode, Landline, MobileNumber, FaxNumber, IsActive, IsDeleted, UserModuleID, ProfileID, UserID, CreatedUser, Position, Organization, IsAllowedToSendIvitation, IsEmail_SMS_Unsubscribe);
        }
        /// <summary>
        /// Insert Import Contacts
        /// </summary>
        /// <param name="contactID">contactID</param>
        /// <param name="FirstName">FirstName</param>
        /// <param name="LastName">LastName</param>
        /// <param name="EmailID">EmailID</param>
        /// <param name="CompanyName">CompanyName</param>
        /// <param name="Address">Address</param>
        /// <param name="City">City</param>
        /// <param name="State">State</param>
        /// <param name="Zipcode">Zipcode</param>
        /// <param name="Landline">Landline</param>
        /// <param name="MobileNumber">MobileNumber</param>
        /// <param name="FaxNumber">FaxNumber</param>
        /// <param name="IsActive">IsActive</param>
        /// <param name="IsDeleted">IsDeleted</param>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="UserID">UserID</param>
        /// <param name="CreatedUser">CreatedUser</param>
        /// <param name="groupId">groupId</param>
        /// <returns>Int</returns>
        public int InsertImportContacts(int contactID, string FirstName, string LastName, string EmailID, string CompanyName, string Address, string City, string State, string Zipcode, string Landline, string MobileNumber, string FaxNumber, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int UserID, int CreatedUser, int groupId, string Title, string Organization)
        {
            return AddOnDAL.InsertImportContacts(contactID, FirstName, LastName, EmailID, CompanyName, Address, City, State, Zipcode, Landline, MobileNumber, FaxNumber, IsActive, IsDeleted, UserModuleID, ProfileID, UserID, CreatedUser, groupId, Title, Organization);
        }
        /// <summary>
        /// Assign group to contactID
        /// </summary>
        /// <param name="assignID">assignID</param>
        /// <param name="GroupID">GroupID</param>
        /// <param name="contactID">contactID</param>
        /// <returns>Int</returns>
        public int AssignGroupContactID(int assignID, int GroupID, int contactID)
        {
            return AddOnDAL.AssignGroupContactID(assignID, GroupID, contactID);
        }
        /// <summary>
        /// Delete the contacts by using contactID
        /// </summary>
        /// <param name="contactIds">contactIds</param>
        /// <returns>Int</returns>
        public int DeleteContacts(string contactIds)
        {
            return AddOnDAL.DeleteContacts(contactIds);
        }
        /// <summary>
        /// Check the assign group to contact 
        /// </summary>
        /// <param name="contactID">contactID</param>
        /// <param name="GroupID">GroupID</param>
        /// <returns>Int</returns>
        public int CheckAssignGroupToContact(int contactID, int GroupID)
        {
            return AddOnDAL.CheckAssignGroupToContact(contactID, GroupID);
        }
        /// <summary>
        /// Search Email ID
        /// </summary>
        /// <param name="searchText">searchText</param>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <returns>DataTable</returns>
        public DataTable SearchEmailID(string searchText, int UserModuleID)
        {
            return AddOnDAL.SearchEmailID(searchText, UserModuleID);
        }
        /// <summary>
        /// Get Call Contact Groups
        /// </summary>
        /// <param name="contactId">contactId</param>
        /// <returns>String</returns>
        public string GetCallContactGroups(int contactId)
        {
            return AddOnDAL.GetCallContactGroups(contactId);
        }
        /// <summary>
        /// Get Group by using GroupID
        /// </summary>
        /// <param name="GroupID">GroupID</param>
        /// <returns>DataSet</returns>
        public DataSet GetGroupByID(int GroupID)
        {
            return AddOnDAL.GetGroupByID(GroupID);
        }
        /// <summary>
        /// Get Contact by using ContactID
        /// </summary>
        /// <param name="ContactID">ContactID</param>
        /// <returns>DataSet</returns>
        public DataSet GetContactByID(int ContactID)
        {
            return AddOnDAL.GetContactByID(ContactID);
        }
        /// <summary>
        /// Get Call Index by using CustomID
        /// </summary>
        /// <param name="CustomID">CustomID</param>
        /// <returns>DataSet</returns>
        public DataSet GetCallIndexByID(int CustomID)
        {
            return AddOnDAL.GetCallIndexByID(CustomID);
        }

        public DataTable GetGroupContactsByID(int CustomID)
        {
            return AddOnDAL.GetGroupContactsByID(CustomID);
        }
        /// <summary>
        /// Check the email exists
        /// </summary>
        /// <param name="EmailID">EmailID</param>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <param name="pContactID">pContactID</param>
        /// <returns>Int</returns>
        public int CheckEmailExists(string EmailID, int UserModuleID, int pContactID, string MobileNumber)
        {
            return AddOnDAL.CheckEmailExists(EmailID, UserModuleID, pContactID, MobileNumber);
        }
        /// <summary>
        /// update CallAddons order 
        /// </summary>
        /// <param name="customID">customID</param>
        /// <param name="OrderNo">OrderNo</param>
        /// <param name="ID">ID</param>
        public void UpdateCallAddonOrder(int customID, int OrderNo, int ID)
        {
            AddOnDAL.UpdateCallAddonOrder(customID, OrderNo, ID);
        }
        /// <summary>
        /// Get all call index Addons by order
        /// </summary>
        /// <param name="userModuleId">userModuleId</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllCallIndexAddOnsByorder(int userModuleId)
        {
            return AddOnDAL.GetAllCallIndexAddOnsByOrder(userModuleId);
        }
        /// <summary>
        /// Get private CallAddons buttons
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataSet</returns>
        public DataSet GetPrivateCallAddOnsButtons(int userID)
        {
            return AddOnDAL.GetPrivateCallAddOnsButtons(userID);
        }
        /// <summary>
        /// Get Call Module default records
        /// </summary>
        /// <param name="domainName">domainName</param>
        /// <returns>DataTable</returns>
        public DataTable GetCallModuleDefaultitems(string domainName, string pModuleType)
        {
            return AddOnDAL.GetCallModuleDefaultitems(domainName, pModuleType);
        }
        #endregion


        /// <summary>
        /// Get Active Groups with Including Not Assigned checkbox
        /// </summary>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <returns>DataSet</returns>
        public DataSet GetCallIndexActiveGroups(int UserModuleID)
        {
            return AddOnDAL.GetCallIndexActiveGroups(UserModuleID);
        }
        //------------------------------------Public Call AddOns---------------------------------
        #region
        /// <summary>
        /// Inserting public call index data
        /// </summary>
        /// <param name="CustomID"></param>
        /// <param name="ProfileID"></param>
        /// <param name="UserID"></param>
        /// <param name="Title"></param>
        /// <param name="ImageUrls"></param>
        /// <param name="MobileNumber"></param>
        /// <param name="IsAutoEmail"></param>
        /// <param name="Email_Description"></param>
        /// <param name="Email_GroupIDs"></param>
        /// <param name="IsAutoTextMessage"></param>
        /// <param name="SMS_Description"></param>
        /// <param name="SMS_GroupIDs"></param>
        /// <param name="IsGPSInformation"></param>
        /// <param name="IsAllPhoneInformation"></param>
        /// <param name="IsActive"></param>
        /// <param name="CreatedUser"></param>
        /// <param name="ModifyUser"></param>
        /// <param name="UserModuleID"></param>
        /// <param name="IsDeleted"></param>
        /// <param name="IsPublish"></param>
        /// <param name="IsPublic"></param>
        /// <param name="Email_Subject"></param>
        /// <param name="SMS_Subject"></param>
        /// <param name="Description"></param>
        /// <param name="PreviewHtml"></param>
        /// <param name="IsVisible"></param>
        /// <param name="IsInitiatesPhoneCall"></param>
        /// <param name="IsPredefinedMessage"></param>
        /// <param name="IsAnonymous"></param>
        /// <param name="IsUploadImage"></param>
        /// <returns></returns>
        public int InsertUpdatePublicCallIndexData(int CustomID, int ProfileID, int UserID, string Title, string ImageUrls, string MobileNumber, bool IsAutoEmail, string Email_Description, string Email_GroupIDs,
               bool IsAutoTextMessage, string SMS_Description, string SMS_GroupIDs, bool IsGPSInformation, bool IsAllPhoneInformation, bool IsActive, int CreatedUser, int ModifyUser, int UserModuleID, bool IsDeleted, bool IsPublish,
                   bool IsPublic, string Email_Subject, string SMS_Subject, string Description, string PreviewHtml, bool IsVisible, bool IsInitiatesPhoneCall, bool IsPredefinedMessage, bool IsAnonymous, bool IsUploadImage, int AppUserAnonymousType,int CategoryID)
        {
            int returnID = AddOnDAL.InsertUpdatePublicCallIndexData(CustomID, ProfileID, UserID, Title, ImageUrls, MobileNumber, IsAutoEmail, Email_Description, Email_GroupIDs,
                   IsAutoTextMessage, SMS_Description, SMS_GroupIDs, IsGPSInformation, IsAllPhoneInformation, IsActive, CreatedUser, ModifyUser, UserModuleID, IsDeleted, IsPublish,
                    IsPublic, Email_Subject, SMS_Subject, Description, PreviewHtml, IsVisible, IsInitiatesPhoneCall, IsPredefinedMessage, IsAnonymous, IsUploadImage, AppUserAnonymousType,CategoryID);

            // Genarate App Thumb 
            objCommon.GenarateThumbnailForPublicCallApp(returnID, ProfileID, "PublicCallModules", ImageUrls);
            if (returnID > 0)
            {
                // Update Long URL to Short URL
                string outerURL = objCommon.GetConfigSettings(Convert.ToString(ProfileID), "Paths", "RootPath");
                string ShortenURL = outerURL + "/OnlinePublicCallItem.aspx?CID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(CustomID)).Replace("=", "irhmalli").Replace("+", "irhPASS");

                ShortenURL = objCommon.longurlToshorturl(ShortenURL);
                CommonDAL.UpdateShortenURl(CustomID, ShortenURL, "PublicCallAddOns");
            }

            return returnID;

        }
        /// <summary>
        /// retreving public call index details by id
        /// </summary>
        /// <param name="CustomID"></param>
        /// <returns></returns>
        public DataSet GetPublicCallIndexByID(int CustomID)
        {
            return AddOnDAL.GetPublicCallIndexByID(CustomID);
        }
        /// <summary>
        /// retrieving public call index groups data
        /// </summary>
        /// <param name="UserModuleID"></param>
        /// <returns></returns>
        public DataSet GetPublicGroupsData(int UserModuleID)
        {
            return AddOnDAL.GetPublicGroupsData(UserModuleID);
        }
        /// <summary>
        /// checking whether the email exists or not for public call contacts
        /// </summary>
        /// <param name="EmailID"></param>
        /// <param name="UserModuleID"></param>
        /// <param name="pContactID"></param>
        /// <returns></returns>
        public int CheckEmailExistsForPublicCall(string EmailID, int UserModuleID, int pContactID, string PhoneNumber)
        {
            return AddOnDAL.CheckEmailExistsForPublicCall(EmailID, UserModuleID, pContactID, PhoneNumber);
        }
        /// <summary>
        /// getting contact groups for public call index data
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public string GetCallContactGroupsForPublicCallIndex(int contactId)
        {
            return AddOnDAL.GetCallContactGroupsForPublicCallIndex(contactId);
        }
        /// <summary>
        /// inserting contact details for public call index
        /// </summary>
        /// <param name="contactID"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="EmailID"></param>
        /// <param name="CompanyName"></param>
        /// <param name="Address"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Zipcode"></param>
        /// <param name="Landline"></param>
        /// <param name="MobileNumber"></param>
        /// <param name="FaxNumber"></param>
        /// <param name="IsActive"></param>
        /// <param name="IsDeleted"></param>
        /// <param name="UserModuleID"></param>
        /// <param name="ProfileID"></param>
        /// <param name="UserID"></param>
        /// <param name="CreatedUser"></param>
        /// <param name="Position"></param>
        /// <param name="Organization"></param>
        /// <param name="IsAllowedToSendIvitation"></param>
        /// <param name="IsEmail_SMS_Unsubscribe"></param>
        /// <returns></returns>
        public int InsertUpdatePublicCallContacts(int contactID, string FirstName, string LastName, string EmailID, string CompanyName, string Address, string City, string State, string Zipcode, string Landline, string MobileNumber, string FaxNumber, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int UserID, int CreatedUser, string Position, string Organization, bool IsAllowedToSendIvitation, bool IsEmail_SMS_Unsubscribe)
        {
            return AddOnDAL.InsertUpdatePublicCallContacts(contactID, FirstName, LastName, EmailID, CompanyName, Address, City, State, Zipcode, Landline, MobileNumber, FaxNumber, IsActive, IsDeleted, UserModuleID, ProfileID, UserID, CreatedUser, Position, Organization, IsAllowedToSendIvitation, IsEmail_SMS_Unsubscribe);
        }
        /// <summary>
        /// assigning group contact id for public call index
        /// </summary>
        /// <param name="assignID"></param>
        /// <param name="GroupID"></param>
        /// <param name="contactID"></param>
        /// <returns></returns>
        public int AssignPublicCallIndexGroupContactID(int assignID, int GroupID, int contactID)
        {
            return AddOnDAL.AssignPublicCallIndexGroupContactID(assignID, GroupID, contactID);
        }

        /// <summary>
        /// getting public call index groups
        /// </summary>
        /// <param name="userModuleId"></param>
        /// <returns></returns>
        public DataSet GetPublicCallIndexGroups(int userModuleId)
        {
            return AddOnDAL.GetPublicCallIndexGroups(userModuleId);
        }
        /// <summary>
        /// Adding group for public call index
        /// </summary>
        /// <param name="GroupID"></param>
        /// <param name="GroupName"></param>
        /// <param name="GroupDescription"></param>
        /// <param name="IsActive"></param>
        /// <param name="IsDeleted"></param>
        /// <param name="UserModuleID"></param>
        /// <param name="ProfileID"></param>
        /// <param name="CreatedUser"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int AddGroupForPublicCallIndex(int GroupID, string GroupName, string GroupDescription, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int CreatedUser, int UserID)
        {
            return AddOnDAL.AddGroupForPublicCallIndex(GroupID, GroupName, GroupDescription, IsActive, IsDeleted, UserModuleID, ProfileID, CreatedUser, UserID);
        }
        /// <summary>
        /// retrieve active contacts for public call Index
        /// </summary>
        /// <param name="UserModuleID"></param>
        /// <param name="GroupIDs"></param>
        /// <returns></returns>
        public DataTable GetActiveContactsForPublicCall(int UserModuleID, string GroupIDs)
        {
            return AddOnDAL.GetActiveContactsForPublicCall(UserModuleID, GroupIDs);
        }
        /// <summary>
        /// delete groups for public call index
        /// </summary>
        /// <param name="groupIds"></param>
        public void DeleteGroupsForPublicCallIndex(string groupIds)
        {
            AddOnDAL.DeleteGroupsForPublicCallIndex(groupIds);
        }

        public DataSet GetPublicCallIndexGroupByID(int GroupID)
        {
            return AddOnDAL.GetPublicCallIndexGroupByID(GroupID);
        }

        public DataSet GetPublicCallIndexContactByID(int ContactID)
        {
            return AddOnDAL.GetPublicCallIndexContactByID(ContactID);
        }

        public int DeletePublicCallIndexContacts(string contactIds)
        {
            return AddOnDAL.DeletePublicCallIndexContacts(contactIds);
        }

        public DataTable SearchPublicCallContactEmail(string searchText, int UserModuleID)
        {
            return AddOnDAL.SearchPublicCallContactEmail(searchText, UserModuleID);
        }

        public int InsertImportContactsForPublicCall(int contactID, string FirstName, string LastName, string EmailID, string CompanyName, string Address, string City, string State, string Zipcode, string Landline, string MobileNumber, string FaxNumber, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int UserID, int CreatedUser, int groupId, string Title, string Organization)
        {
            return AddOnDAL.InsertImportContactsForPublicCall(contactID, FirstName, LastName, EmailID, CompanyName, Address, City, State, Zipcode, Landline, MobileNumber, FaxNumber, IsActive, IsDeleted, UserModuleID, ProfileID, UserID, CreatedUser, groupId, Title, Organization);
        }

        //Getting Public CallIndex Buttons
        public DataTable GetPublicCallIndex_Buttons(int pProfileID, int? userModuleId)
        {
            return AddOnDAL.GetPublicCallIndex_Buttons(pProfileID, userModuleId);
        }
        public DataTable GetAllManagePublicCallIndexAddOns(int pUserID, int pCustomModuleId)
        {
            return AddOnDAL.GetAllManagePublicCallIndexAddOns(pUserID, pCustomModuleId);
        }
        public DataTable GetAllPublicCallIndexAddOnsByorder(int userModuleId)
        {
            return AddOnDAL.GetAllPublicCallIndexAddOnsByOrder(userModuleId);
        }
        public DataTable GetPublicCallIndexDetailsByID(int pCustomID)
        {
            return AddOnDAL.GetPublicCallIndexDetailsByID(pCustomID);
        }
        public int ChangePublicCallAddOnVisiblity(int customId, int modifiedUser)
        {
            return AddOnDAL.ChangePublicCallAddOnVisiblity(customId, modifiedUser);
        }
        public void DeletePublicCallIndexItem(int pCustomID, int UserID)
        {
            AddOnDAL.DeletePublicCallIndexItem(pCustomID, UserID);
        }

        public void UpdatePublicCallAddonOrder(int customID, int OrderNo, int ID)
        {
            AddOnDAL.UpdatePublicCallAddonOrder(customID, OrderNo, ID);
        }
        public DataTable GetPublicCallGroupContactsByID(int CustomID)
        {
            return AddOnDAL.GetPublicCallGroupContactsByID(CustomID);
        }
        #endregion

        public void InsertDefaultContact(int customid, int userid)
        {
            AddOnDAL.InsertDefaultContact(customid, userid);
        }

        public DataTable GetAppVerionDetailsByUMID(int pUserID, int pProfileID, int pUMID)
        {
            return AddOnDAL.GetAppVerionDetailsByUMID(pUserID, pProfileID, pUMID);

        }

        //Manage Contacts in SmartConnect Popup 
        public DataTable GetSmartConnectContactsbyUserModuleID(int UserModuleID,string SearchText="")
        {
            return AddOnDAL.GetSmartConnectContactsbyUserModuleID(UserModuleID, SearchText);
        }

        public int CheckPublicAssignGroupToContact(int chkContactId, int groupId, int UserModuleID)
        {
            return AddOnDAL.CheckPublicAssignGroupToContact(chkContactId, groupId, UserModuleID);
        }

        //Manage Contacts in Call Index Popup 
        public int CheckCallIndexAssignGroupToContact(int chkContactId, int groupId, int UserModuleID)
        {
            return AddOnDAL.CheckCallIndexAssignGroupToContact(chkContactId, groupId, UserModuleID);
        }

        public DataTable GetCallIndexContactsbyUserModuleID(int UserModuleID, string SearchText = "")
        {
            return AddOnDAL.GetCallIndexContactsbyUserModuleID(UserModuleID, SearchText);
        }

       
    }
}
