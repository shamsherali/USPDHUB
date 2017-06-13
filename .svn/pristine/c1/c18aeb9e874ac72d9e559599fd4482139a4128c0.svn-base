using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using USPDHUBDAL;

namespace USPDHUBBLL
{
    public class CalendarAddOnBLL
    {
        CommonBLL objCommon = new CommonBLL();
        /// <summary>
        /// Insert Calendar Content Module Details
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        /// <param name="profileId">profileId</param>
        /// <param name="userId">userId</param>
        /// <param name="eventTitle">eventTitle</param>
        /// <param name="description">description</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="cUserId">cUserId</param>
        /// <param name="isCall">isCall</param>
        /// <param name="isContactUs">isContactUs</param>
        /// <param name="isPhotoCapture">isPhotoCapture</param>
        /// <param name="editHtml">editHtml</param>
        /// <param name="listDescription">listDescription</param>
        /// <param name="isPublished">isPublished</param>
        /// <param name="publishedBy">publishedBy</param>
        /// <param name="publishDate">publishDate</param>
        /// <param name="expDate">expDate</param>
        /// <param name="isRepeat">isRepeat</param>
        /// <param name="parentCalendarId">parentCalendarId</param>
        /// <param name="userModuleId">userModuleId</param>
        /// <returns>Int</returns>
        public int InsertCalendarAddOnDetails(int calendarId, int profileId, int userId, string eventTitle, string description, string startDate, string endDate,
                                                int cUserId, bool isCall, bool isContactUs, bool isPhotoCapture, string editHtml, string listDescription,
                                                bool isPublished, int? publishedBy, DateTime? publishDate, DateTime? expDate, bool isRepeat, int? parentCalendarId, int userModuleId)
        {
            description = objCommon.ReplaceShortURltoHtmlString(description);
            int returnId = CalendarAddOnDAL.InsertCalendarAddOnDetails(calendarId, profileId, userId, eventTitle, description, startDate, endDate, cUserId, isCall, isContactUs, isPhotoCapture, editHtml, listDescription, isPublished, publishedBy, publishDate, expDate, isRepeat, parentCalendarId, userModuleId);
            if (calendarId == 0)
            {
                // Update Long URL to Short URL
                string outerURL = objCommon.GetConfigSettings(Convert.ToString(profileId), "Paths", "RootPath");
                string bulletinURL = outerURL + "/printevents.aspx?CalT=1&EID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(returnId)).Replace("=", "irhmalli").Replace("+", "irhPASS");

                bulletinURL = objCommon.longurlToshorturl(bulletinURL);
                CommonDAL.UpdateShortenURl(profileId, bulletinURL, WebConstants.Tab_CalendarAddOns);
            }

            // Genarate App Thumb 
            objCommon.GenarateThumbnailForApp(returnId, profileId, "CalendarAddOns", description);

            return returnId;
        }

        /// <summary>
        /// Get Calendar Content Module Details
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        /// <returns>DataTable</returns>
        public DataTable GetCalendarAddOnDetails(int calendarId)
        {
            return CalendarAddOnDAL.GetCalendarAddOnDetails(calendarId);
        }

        /// <summary>
        /// Remove Google Events
        /// </summary>
        /// <param name="CalendarID">CalendarID</param>
        public void RemoveGoogleEvents(string CalendarID)
        {
            EventCalendarDAL.RemoveGoogleEvents(CalendarID);
        }

        /// <summary>
        /// Insert Gmail Calendar Details
        /// </summary>
        /// <param name="calendarID">calendarID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="eventTitle">eventTitle</param>
        /// <param name="eventDesc">eventTitle</param>
        /// <param name="eventStartDate">eventStartDate</param>
        /// <param name="eventEndDate">eventEndDate</param>
        /// <param name="isPublish">isPublish</param>
        /// <param name="id">id</param>
        /// <param name="pEditHtml">pEditHtml</param>
        /// <param name="publishedBy">publishedBy</param>
        /// <param name="publishDate">publishDate</param>
        /// <param name="Location">Location</param>
        /// <param name="Type">Type</param>
        /// <param name="googleCalID">googleCalID</param>
        /// <param name="googleCalendarName">googleCalendarName</param>
        /// <param name="calendarAddOnId">calendarAddOnId</param>
        /// <returns>Int</returns>
        public int InsertGMailCalendarDetails(int calendarID, int profileID, int userID, string eventTitle, string eventDesc, string eventStartDate,
            string eventEndDate, bool isPublish, int id, string pEditHtml, int? publishedBy, DateTime? publishDate, string Location, string Type, string googleCalID, string googleCalendarName, int calendarAddOnId)
        {
            return CalendarAddOnDAL.InsertGMailCalendarDetails(calendarID, profileID, userID, eventTitle, eventDesc, eventStartDate,
            eventEndDate, isPublish, id, pEditHtml, publishedBy, publishDate, Location, Type, googleCalID, googleCalendarName, calendarAddOnId);
        }

        /// <summary>
        /// Get All Events By ProfileId
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllEventsByProfileId(int profileId)
        {
            return EventCalendarDAL.GetAllEventsByProfileId(profileId);
        }

        /// <summary>
        /// Update Show Repeat By Content Module
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        /// <param name="flag">flag</param>
        public void UpdateShowRepeatByAddOn(int calendarId, bool flag)
        {
            CalendarAddOnDAL.UpdateShowRepeatByAddOn(calendarId, flag);
        }

        /// <summary>
        /// Add Repeat Events For Calendar Content Module
        /// </summary>
        /// <param name="parentCalendarId">parentCalendarId</param>
        /// <param name="str3ItemsArray">str3ItemsArray</param>
        /// <param name="strEndsOn">strEndsOn</param>
        /// <param name="repeatOn">repeatOn</param>
        /// <param name="repeatBy">repeatBy</param>
        /// <param name="eventStartDate">eventStartDate</param>
        /// <param name="eventEndDate">eventEndDate</param>
        /// <param name="cUserID">cUserID</param>
        public void AddRepeatEventsForCalendarAddOn(int parentCalendarId, string[] str3ItemsArray, string[] strEndsOn, string repeatOn, string repeatBy, DateTime eventStartDate, DateTime eventEndDate, int cUserID)
        {
            CalendarAddOnDAL.AddRepeatEventsForCalendarAddOn(parentCalendarId, str3ItemsArray, strEndsOn, repeatOn, repeatBy, eventStartDate, eventEndDate, cUserID);
        }

        /// <summary>
        /// Update Repeat Calendar Details
        /// </summary>
        /// <param name="parentCalendarId">parentCalendarId</param>
        /// <param name="addFlag">addFlag</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="cUserID">cUserID</param>
        public void UpdateRepeatCalendarDetails(int parentCalendarId, int addFlag, DateTime startDate, DateTime endDate, int cUserID)
        {
            CalendarAddOnDAL.UpdateRepeatCalendarDetails(parentCalendarId, addFlag, startDate, endDate, cUserID);
        }

        /// <summary>
        /// Delete Repeat For Calendar
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        /// <param name="userID">userID</param>
        /// <param name="deleteType">deleteType</param>
        /// <param name="cUserID">cUserID</param>
        public void DeleteRepeatForCalendar(int calendarId, int userID, int deleteType, int cUserID)
        {
            CalendarAddOnDAL.DeleteRepeatForCalendar(calendarId, userID, deleteType, cUserID);
        }

        /// <summary>
        /// Change Parent Calendar
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        /// <param name="isParent">isParent</param>
        /// <param name="cUserID">cUserID</param>
        public void ChangeParentCalendar(int calendarId, bool isParent, int cUserID)
        {
            CalendarAddOnDAL.ChangeParentCalendar(calendarId, isParent, cUserID, WebConstants.Tab_CalendarAddOns);
        }

        /// <summary>
        /// Update Content For Call Following
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        public void UpdateContentForCalFollowing(int calendarId)
        {
            CalendarAddOnDAL.UpdateContentForCalFollowing(calendarId);
        }

        /// <summary>
        /// Get All Calendars By ProfileId
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="calendarAddOnId">calendarAddOnId</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllCalendarsByProfileId(int profileID, int calendarAddOnId)
        {
            return CalendarAddOnDAL.GetAllCalendarsByProfileId(profileID, calendarAddOnId);
        }

        /// <summary>
        /// Check Calendar Campaign Count
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        /// <returns>Int</returns>
        public int CheckCalendarCampaignCount(int calendarId)
        {
            return CalendarAddOnDAL.CheckCalendarCampaignCount(calendarId);
        }

        /// <summary>
        /// Get Scheduled Items By CalendarId
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        /// <returns>DataTable</returns>
        public DataTable GetScheduledItemsByCalendarId(int calendarId)
        {
            return CalendarAddOnDAL.GetScheduledItemsByCalendarId(calendarId);
        }

        /// <summary>
        /// Get All Calendars By Preview
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="calendarAddOnId">calendarAddOnId</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllCalendarsByPreview(int profileId, int calendarAddOnId)
        {
            return CalendarAddOnDAL.GetAllCalendarsByPreview(profileId, calendarAddOnId);
        }

        /// <summary>
        /// Get All 3 Months Calendars By Preview
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="calendarAddOnId">calendarAddOnId</param>
        /// <returns>DataTable</returns>
        public DataTable GetAll3MontthsCalendarsByPreview(int profileId, int calendarAddOnId)
        {
            return CalendarAddOnDAL.GetAll3MontthsCalendarsByPreview(profileId, calendarAddOnId);
        }

        /// <summary>
        /// Get All Calendars By Selected Month
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="selectedDate">selectedDate</param>
        /// <param name="calendarAddOnId">calendarAddOnId</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllCalendarsBySelectedMonth(int profileId, string selectedDate, int calendarAddOnId)
        {
            return CalendarAddOnDAL.GetAllCalendarsBySelectedMonth(profileId, selectedDate, calendarAddOnId);
        }

        /// <summary>
        /// Update Calendar Publish
        /// </summary>
        /// <param name="flag">flag</param>
        /// <param name="userID">userID</param>
        /// <param name="createdUser">createdUser</param>
        /// <param name="calendarId">calendarId</param>
        /// <param name="publishDate">publishDate</param>
        /// <param name="isPublished">isPublished</param>
        public void UpdateCalendarPublish(bool flag, int userID, int createdUser, int calendarId, DateTime? publishDate, bool isPublished)
        {
            CalendarAddOnDAL.UpdateCalendarPublish(flag, userID, createdUser, calendarId, publishDate, isPublished);
        }

        /// <summary>
        /// Delete Calendar By Id
        /// </summary>
        /// <param name="calendarIdD">calendarIdD</param>
        public void DeleteCalendarById(int calendarIdD)
        {
            CalendarAddOnDAL.DeleteCalendarById(calendarIdD);
        }

        /// <summary>
        /// Get Calendar Max Scheduled Date
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>String</returns>
        public string GetCalendarMaxScheduledDate(int userId)
        {
            return CalendarAddOnDAL.GetCalendarMaxScheduledDate(userId);
        }

        /// <summary>
        /// Check for Calendar Schedule
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>Int</returns>
        public int CheckforCalendarSchedule(int userId)
        {
            return CalendarAddOnDAL.CheckforCalendarSchedule(userId);
        }

        /// <summary>
        /// Get Calendar Campaign By Dates
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        /// <returns>DataTable</returns>
        public DataTable GetCalendarCampaignByDates(int calendarId)
        {
            return CalendarAddOnDAL.GetCalendarCampaignByDates(calendarId);
        }

        /// <summary>
        /// Get Calendar Count For Sending Date
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="sendingDate">sendingDate</param>
        /// <param name="calendarId">calendarId</param>
        /// <returns>Int</returns>
        public int GetCalendarCountForSendingDate(int userId, DateTime sendingDate, int calendarId)
        {
            return CalendarAddOnDAL.GetCalendarCountForSendingDate(userId, sendingDate, calendarId);
        }

        /// <summary>
        /// Cancel Calendar Campaign
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        public void CancelCalendarCampaign(int calendarId)
        {
            CalendarAddOnDAL.CancelCalendarCampaign(calendarId);
        }

        /// <summary>
        /// Get Send Calendars By ProfileID
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <returns>DataTable</returns>
        public DataTable GetSendCalendarsByProfileID(int profileId)
        {
            return CalendarAddOnDAL.GetSendCalendarsByProfileID(profileId);
        }

        /// <summary>
        /// Get Calendar Report Counts
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        /// <param name="flag">flag</param>
        /// <param name="profileId">profileId</param>
        /// <returns>DataSet</returns>
        public DataSet GetCalendarReportCounts(int calendarId, int flag, int profileId)
        {
            return CalendarAddOnDAL.GetCalendarReportCounts(calendarId, flag, profileId);
        }

        /// <summary>
        /// Get OptOut Count For CalendarId
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        /// <returns>DataTable</returns>
        public DataTable GetOptOutCountForCalendarId(int calendarId)
        {
            return CalendarAddOnDAL.GetOptOutCountForCalendarId(calendarId);
        }

        /// <summary>
        /// Check Calendar Sending Count for Sending Date
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="calSendingDate">calSendingDate</param>
        /// <param name="calAddOnId">calAddOnId</param>
        /// <returns>Int</returns>
        public int CheckCalendarSendingCountforSendingDate(int userID, DateTime calSendingDate, int calAddOnId)
        {
            return CalendarAddOnDAL.CheckCalendarSendingCountforSendingDate(userID, calSendingDate, calAddOnId);
        }

        /// <summary>
        /// Check for Calendar Schedule
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="calAddOnId">calAddOnId</param>
        /// <returns>Int</returns>
        public int CheckforCalendarSchedule(int userID, int calAddOnId)
        {
            return CalendarAddOnDAL.CheckforCalendarSchedule(userID, calAddOnId);
        }

        /// <summary>
        /// Insert Calendar Schedule Details
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        /// <param name="senderProfileID">senderProfileID</param>
        /// <param name="senderUserID">senderUserID</param>
        /// <param name="schduleSubject">schduleSubject</param>
        /// <param name="receiverEmailID">receiverEmailID</param>
        /// <param name="sendingDate">sendingDate</param>
        /// <param name="scheduleDate">scheduleDate</param>
        /// <param name="sentFlag">sentFlag</param>
        /// <param name="isToday">isToday</param>
        /// <param name="groupID">groupID</param>
        /// <param name="contactusChecked">contactusChecked</param>
        /// <param name="shareCalendar">shareCalendar</param>
        /// <param name="id">id</param>
        /// <param name="verticalID">verticalID</param>
        /// <param name="storeLinksChecked">storeLinksChecked</param>
        /// <returns>Int</returns>
        public int InsertCalendarScheduleDetails(int calendarId, int senderProfileID, int senderUserID, string schduleSubject, string receiverEmailID, DateTime sendingDate, DateTime scheduleDate, int sentFlag, bool isToday, string groupID, bool contactusChecked, string shareCalendar, int id, int verticalID, bool storeLinksChecked)
        {
            return CalendarAddOnDAL.InsertCalendarScheduleDetails(calendarId, senderProfileID, senderUserID, schduleSubject, receiverEmailID, sendingDate, scheduleDate, sentFlag, isToday, groupID, contactusChecked, shareCalendar, id, verticalID, storeLinksChecked);
        }

        /// <summary>
        /// Get Calendar Details By Scheduled ID
        /// </summary>
        /// <param name="schID">schID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCalendarDetailsBySchID(int schID)
        {
            return CalendarAddOnDAL.GetCalendarDetailsBySchID(schID);
        }

        /// <summary>
        /// Unsubscribe Calendar Email
        /// </summary>
        /// <param name="calendarId">calendarId</param>
        /// <param name="userID">userID</param>
        /// <param name="userEmail">userEmail</param>
        /// <returns>Int</returns>
        public int UnsubscribeCalendarEmail(int calendarId, int userID, string userEmail)
        {
            return CalendarAddOnDAL.UnsubscribeCalendarEmail(calendarId, userID, userEmail);
        }
    }
}
