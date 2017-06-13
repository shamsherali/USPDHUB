using System;
using System.Data;
using USPDHUBDAL;

namespace USPDHUBBLL
{
    public class EventCalendarBLL
    {
        CommonBLL objCommon = new CommonBLL();
        /// <summary>
        /// Insert Event Details
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="eventTitle">eventTitle</param>
        /// <param name="eventDesc">eventDesc</param>
        /// <param name="status">status</param>
        /// <param name="eventStartDate">eventStartDate</param>
        /// <param name="eventEndDate">eventEndDate</param>
        /// <param name="rsvpFlag">rsvpFlag</param>
        /// <param name="rsvpCount">rsvpCount</param>
        /// <param name="progressLevel">progressLevel</param>
        /// <param name="isPublic">isPublic</param>
        /// <param name="id">id</param>
        /// <param name="pEditHtml">pEditHtml</param>
        /// <param name="publishedBy">publishedBy</param>
        /// <param name="publishDate">publishDate</param>
        /// <param name="ListDescription">ListDescription</param>
        /// <param name="pExDate">pExDate</param>
        /// <param name="pIsCall">pIsCall</param>
        /// <param name="pIsContactUs">pIsContactUs</param>
        /// <param name="isRepeat">isRepeat</param>
        /// <param name="parentEventID">parentEventID</param>
        /// <returns>Int</returns>
        public int InsertEventDetails(int eventID, int profileID, int userID, string eventTitle, string eventDesc, bool status, string eventStartDate,
            string eventEndDate, bool rsvpFlag, int rsvpCount, bool progressLevel, bool isPublic, int id, string pEditHtml, int? publishedBy,
            DateTime? publishDate, string ListDescription, DateTime? pExDate, bool pIsCall, bool pIsContactUs, bool isRepeat, int? parentEventID)
        {
            // Get Shorten Url from Long Url
            eventDesc = objCommon.ReplaceShortURltoHtmlString(eventDesc);


            int EID = EventCalendarDAL.InsertEventDetails(eventID, profileID, userID, eventTitle, eventDesc, status, eventStartDate, eventEndDate,
                rsvpFlag, rsvpCount, progressLevel, isPublic, id, pEditHtml, publishedBy, publishDate, ListDescription, pExDate, pIsCall, pIsContactUs, isRepeat, parentEventID);

            #region MyRegion Update Long URL to Short URL

            if (eventID == 0)
            {
                // Update Long URL to Short URL
                string outerURL = objCommon.GetConfigSettings(Convert.ToString(profileID), "Paths", "RootPath");
                string bulletinURL = outerURL + "/printevents.aspx?EID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(EID)).Replace("=", "irhmalli").Replace("+", "irhPASS");

                bulletinURL = objCommon.longurlToshorturl(bulletinURL);
                CommonDAL.UpdateShortenURl(EID, bulletinURL, "EVENTS");
            }

            #endregion



            // Genarate App Thumb 
            objCommon.GenarateThumbnailForApp(EID, profileID, "Events", eventDesc);

            return EID;

        }
        /// <summary>
        /// Insert Gmail Event Details
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="eventTitle">eventTitle</param>
        /// <param name="eventDesc">eventDesc</param>
        /// <param name="status">status</param>
        /// <param name="eventStartDate">eventStartDate</param>
        /// <param name="eventEndDate">eventEndDate</param>
        /// <param name="rsvpFlag">rsvpFlag</param>
        /// <param name="rsvpCount">rsvpCount</param>
        /// <param name="progressLevel">progressLevel</param>
        /// <param name="isPublic">isPublic</param>
        /// <param name="id">id</param>
        /// <param name="pEditHtml">pEditHtml</param>
        /// <param name="publishedBy">publishedBy</param>
        /// <param name="publishDate">publishDate</param>
        /// <param name="Location">Location</param>
        /// <param name="Type">Type</param>
        /// <param name="CalID">CalID</param>
        /// <param name="CalendarName">CalendarName</param>
        /// <returns>Int</returns>
        public int InsertGMailEventDetails(int eventID, int profileID, int userID, string eventTitle, string eventDesc, bool status, string eventStartDate,
            string eventEndDate, bool rsvpFlag, int rsvpCount, bool progressLevel, bool isPublic, int id, string pEditHtml, int? publishedBy, DateTime? publishDate, string Location, string Type, string CalID, string CalendarName)
        {
            return EventCalendarDAL.InsertGMailEventDetails(eventID, profileID, userID, eventTitle, eventDesc, status, eventStartDate,
            eventEndDate, rsvpFlag, rsvpCount, progressLevel, isPublic, id, pEditHtml, publishedBy, publishDate, Location, Type, CalID, CalendarName);
        }

        /// <summary>
        /// Insert Update Gmail User Details
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <param name="Flag">Flag</param>
        /// <param name="Sync">Sync</param>
        /// <param name="ProfileID">ProfileID</param>
        public void InsertUpdateGMailUserDetails(string userName, string password, bool Flag, bool Sync, int ProfileID)
        {
            EventCalendarDAL.InsertUpdateGMailUserDetails(userName, password, Flag, Sync, ProfileID);
        }

        /// <summary>
        /// Get All Events By ProfileId
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllEventsByProfileId(int profileID)
        {
            return EventCalendarDAL.GetAllEventsByProfileId(profileID);
        }

        /// <summary>
        /// Get All Events By ProfileId1
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllEventsByProfileId1(int profileID)
        {
            return EventCalendarDAL.GetAllEventsByProfileId1(profileID);
        }

        /// <summary>
        /// Delete Calender Event
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <returns>Int</returns>
        public int DeleteCalenderEvent(int eventID)
        {
            return EventCalendarDAL.DeleteCalenderEvent(eventID);
        }

        /// <summary>
        /// Get Calendar Event Details
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCalendarEventDetails(int eventID)
        {
            return EventCalendarDAL.GetCalendarEventDetails(eventID);
        }

        /// <summary>
        /// Get All 3 Montths Events By ProfileId
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAll3MontthsEventsByProfileId(int profileID)
        {
            return EventCalendarDAL.GetAll3MontthsEventsByProfileId(profileID);
        }

        /// <summary>
        /// Get All Events By ProfileId and SelectedMonth
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="selecteddate">selecteddate</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllEventsByProfileIdandSelectedMonth(int profileID, string selecteddate)
        {
            return EventCalendarDAL.GetAllEventsByProfileIdandSelectedMonth(profileID, selecteddate);
        }
       
        /// <summary>
        /// Check For Umlimted Email Users
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable CheckForUnlimtedUserEmail(int userID)
        {
            return EventCalendarDAL.CheckForUnlimtedUserEmail(userID);
        }

        /// <summary>
        /// Check For Google Events
        /// </summary>
        /// <param name="ProfileID">ProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable CheckForGoogleEvents(int ProfileID)
        {
            return EventCalendarDAL.CheckForGoogleEvents(ProfileID);
        }

        /// <summary>
        /// Check for Business Event Schedule
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int CheckforBusinessEventSchedule(int userID)
        {
            return EventCalendarDAL.CheckforBusinessEventSchedule(userID);
        }

        /// <summary>
        /// Get Business Event Details
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessEventDetails(int eventID)
        {
            return EventCalendarDAL.GetBusinessEventDetails(eventID);
        }

        /// <summary>
        /// Get Business Event Max Scheduleing Date
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>String</returns>
        public string GetBusinessEventMaxScheduleingDate(int userID)
        {
            return EventCalendarDAL.GetBusinessEventMaxScheduleingDate(userID);
        }

        /// <summary>
        /// Get Business Event Details By Business EventID
        /// </summary>
        /// <param name="businessEventID">businessEventID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessEventDetailsByBusinessEventID(int businessEventID)
        {
            return EventCalendarDAL.GetBusinessEventDetailsByBusinessEventID(businessEventID);
        }

        /// <summary>
        /// Check Event Sending Count for Sending Date
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="eventSendingDate">eventSendingDate</param>
        /// <returns>Int</returns>
        public int CheckEventSendingCountforSendingDate(int userID, DateTime eventSendingDate)
        {
            return EventCalendarDAL.CheckEventSendingCountforSendingDate(userID, eventSendingDate);
        }

        /// <summary>
        /// Insert Business Event Schedule Details
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <param name="senderProfileID">senderProfileID</param>
        /// <param name="senderUserID">senderUserID</param>
        /// <param name="schduleEventSubject">schduleEventSubject</param>
        /// <param name="receiverEmailID">receiverEmailID</param>
        /// <param name="sendingDate">sendingDate</param>
        /// <param name="scheduleDate">scheduleDate</param>
        /// <param name="sentFlag">sentFlag</param>
        /// <param name="isToday">isToday</param>
        /// <param name="groupID">groupID</param>
        /// <param name="contactusChecked">contactusChecked</param>
        /// <param name="shareEvent">shareEvent</param>
        /// <param name="id">id</param>
        /// <param name="verticalID">verticalID</param>
        /// <param name="storeLinksChecked">storeLinksChecked</param>
        /// <returns>Int</returns>
        public int InsertBusinessEventScheduleDetails(int eventID, int senderProfileID, int senderUserID, string schduleEventSubject, string receiverEmailID, DateTime sendingDate, DateTime scheduleDate, int sentFlag, bool isToday, string groupID, bool contactusChecked, string shareEvent, int id, int verticalID, bool storeLinksChecked)
        {
            return EventCalendarDAL.InsertBusinessEventScheduleDetails(eventID, senderProfileID, senderUserID, schduleEventSubject, receiverEmailID, sendingDate, scheduleDate, sentFlag, isToday, groupID, contactusChecked, shareEvent, id, verticalID, storeLinksChecked);
        }

        /// <summary>
        /// Get OptOut Count For EventID
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <returns>DataTable</returns>
        public DataTable GetOptOutCountForEventID(int eventID)
        {
            return EventCalendarDAL.GetOptOutCountForEventID(eventID);
        }

        /// <summary>
        /// Get Opt Count For Event ID
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int GetOptCountForEventHisID(int eventID, int userID)
        {
            return EventCalendarDAL.GetOptCountForEventHisID(eventID, userID);
        }

        /// <summary>
        /// Get Campaign Business Event Details By Dates
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCampaignBusinessEventDetailsByDates(int eventID)
        {
            return EventCalendarDAL.GetCampaignBusinessEventDetailsByDates(eventID);
        }

        /// <summary>
        /// Get Event Count for Day for User Date And EventID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="sendingDate">sendingDate</param>
        /// <param name="eventID">eventID</param>
        /// <returns>Int</returns>
        public int GetEventCountforDayforUserDateAndEventID(int userID, DateTime sendingDate, int eventID)
        {
            return EventCalendarDAL.GetEventCountforDayforUserDateAndEventID(userID, sendingDate, eventID);
        }

        /// <summary>
        /// Cancel Event Campaign
        /// </summary>
        /// <param name="eventID">eventID</param>
        public void CancelEventCampaign(int eventID)
        {
            EventCalendarDAL.CancelEventCampaign(eventID);

        }

        /// <summary>
        /// Check Event Campaign Count
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <returns>Int</returns>
        public int CheckEventCampaignCount(int eventID)
        {
            return EventCalendarDAL.CheckEventCampaignCount(eventID);
        }

        /// <summary>
        /// Check Event Campaign Schedule
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <returns>DataTable</returns>
        public DataTable CheckEventCampaignSchedule(int eventID)
        {
            return EventCalendarDAL.CheckEventCampaignSchedule(eventID);
        }

        /// <summary>
        /// Delete Event Template
        /// </summary>
        /// <param name="eventID">eventID</param>
        public void DeleteEventTemplate(int eventID)
        {
            EventCalendarDAL.DeleteEventTemplate(eventID);
        }

        /// <summary>
        /// Get Filtered Events
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="filterValue">filterValue</param>
        /// <returns>DataTable</returns>
        public DataTable GetFilteredEvents(int userID, string filterValue)
        {
            return EventCalendarDAL.GetFilteredEvents(userID, filterValue);
        }

        /// <summary>
        /// Unsubscribe Event Email
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <param name="userID">userID</param>
        /// <param name="userEmail">userEmail</param>
        /// <returns>Int</returns>
        public int UnsubscribeEventEmail(int eventID, int userID, string userEmail)
        {
            return EventCalendarDAL.UnsubscribeEventEmail(eventID, userID, userEmail);
        }
        // *** Issue 1247 *** //
        /// <summary>
        /// Get Event Calendar Details By SchID
        /// </summary>
        /// <param name="schID">schID</param>
        /// <returns>DataTable</returns>
        public DataTable GetEventCalendarDetailsBySchID(int schID)
        {
            return EventCalendarDAL.GetEventCalendarDetailsBySchID(schID);
        }

        //2/01/2012
        /// <summary>
        /// Update Business Event Status
        /// </summary>
        /// <param name="eventId">eventId</param>
        /// <param name="status">status</param>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int UpdateBusinessEventStatus(int eventId, bool status, int profileID)
        {
            return EventCalendarDAL.UpdateBusinessEventStatus(eventId, status, profileID);
        }

        /// <summary>
        /// Get Events Counts
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <param name="flag">flag</param>
        /// <param name="profileID">profileID</param>
        /// <returns>DataSet</returns>
        public DataSet GetEventsCounts(int eventID, int flag, int profileID)
        {
            return EventCalendarDAL.GetEventsCounts(eventID, flag, profileID);
        }

        /// <summary>
        /// Get Send Events By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetSendEventsByProfileID(int profileID)
        {
            return EventCalendarDAL.GetSendEventsByProfileID(profileID);
        }

        /// <summary>
        /// Update Auto Email To Admin Falg
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="eventID">eventID</param>
        /// <param name="type">type</param>
        /// <param name="id">id</param>
        public void UpdateAutoEmailToAdminFalg(int userID, int eventID, string type, int id)
        {
            EventCalendarDAL.UpdateAutoEmailToAdminFalg(userID, eventID, type, id);
        }

        /// <summary>
        /// Update Published Events
        /// </summary>
        /// <param name="flag">flag</param>
        /// <param name="userID">userID</param>
        /// <param name="mUserID">mUserID</param>
        /// <param name="eventID">eventID</param>
        /// <param name="publishDate">publishDate</param>
        /// <param name="isPublished">isPublished</param>
        public void UpdatePublishedEvents(bool flag, int userID, int mUserID, int eventID, DateTime? publishDate, bool isPublished)
        {
            EventCalendarDAL.UpdatePublishedEvents(flag, userID, mUserID, eventID, publishDate, isPublished);
        }

        /// <summary>
        /// Add Repeat Event Details
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <param name="repeats">repeats</param>
        /// <param name="repeatX">repeatX</param>
        /// <param name="startsOn">startsOn</param>
        /// <param name="endsType">endsType</param>
        /// <param name="endsAt">endsAt</param>
        /// <param name="repeatsOn">repeatsOn</param>
        /// <param name="repeatBy">repeatBy</param>
        /// <param name="cUserID">cUserID</param>
        /// <param name="buttonType">buttonType</param>
        public void AddRepeatEventDetails(int eventID, int repeats, int repeatX, DateTime startsOn, int endsType, string endsAt, string repeatsOn, string repeatBy, int cUserID, string buttonType)
        {
            EventCalendarDAL.AddRepeatEventDetails(eventID, repeats, repeatX, startsOn, endsType, endsAt, repeatsOn, repeatBy, cUserID, buttonType);
        }

        /// <summary>
        /// Get Repeat Event By EventID
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <param name="buttonType">buttonType</param>
        /// <returns>DataTable</returns>
        public DataTable GetRepeatEventByEventID(int eventID, string buttonType)
        {
            return EventCalendarDAL.GetRepeatEventByEventID(eventID, buttonType);
        }

        /// <summary>
        /// Delete Repeat
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <param name="userID">userID</param>
        /// <param name="deleteType">deleteType</param>
        /// <param name="cUserID">cUserID</param>
        public void DeleteRepeat(int eventID, int userID, int deleteType, int cUserID)
        {
            EventCalendarDAL.DeleteRepeat(eventID, userID, deleteType, cUserID);
        }

        /// <summary>
        /// Add Repeat Events
        /// </summary>
        /// <param name="parentEventID">parentEventID</param>
        /// <param name="str3ItemsArray">str3ItemsArray</param>
        /// <param name="strEndsOn">strEndsOn</param>
        /// <param name="repeatOn">repeatOn</param>
        /// <param name="repeatBy">repeatBy</param>
        /// <param name="eventStartDate">eventStartDate</param>
        /// <param name="eventEndDate">eventEndDate</param>
        /// <param name="cUserID">cUserID</param>
        public void AddRepeatEvents(int parentEventID, string[] str3ItemsArray, string[] strEndsOn, string repeatOn, string repeatBy, DateTime eventStartDate, DateTime eventEndDate, int cUserID)
        {
            EventCalendarDAL.AddRepeatEvents(parentEventID, str3ItemsArray, strEndsOn, repeatOn, repeatBy, eventStartDate, eventEndDate, cUserID);
        }

        /// <summary>
        /// Update Repeat Events
        /// </summary>
        /// <param name="parentEventID">parentEventID</param>
        /// <param name="addFlag">addFlag</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="cUserID">cUserID</param>
        public void UpdateRepeatEvents(int parentEventID, int addFlag, DateTime startDate, DateTime endDate, int cUserID)
        {
            EventCalendarDAL.UpdateRepeatEvents(parentEventID, addFlag, startDate, endDate, cUserID);
        }

        /// <summary>
        /// Add Repeat Events For Daily
        /// </summary>
        public void AddRepeatEventsForDaily()
        {
            EventCalendarDAL.AddRepeatEventsForDaily();
        }

        /// <summary>
        /// Add Repeat Events For Weekly
        /// </summary>
        public void AddRepeatEventsForWeekly()
        {
            EventCalendarDAL.AddRepeatEventsForWeekly();
        }

        /// <summary>
        /// Add Repeat Events For Monthly
        /// </summary>
        public void AddRepeatEventsForMonthly()
        {
            EventCalendarDAL.AddRepeatEventsForMonthly();
        }

        /// <summary>
        /// Add Repeat Events For Yearly
        /// </summary>
        public void AddRepeatEventsForYearly()
        {
            EventCalendarDAL.AddRepeatEventsForYearly();
        }

        /// <summary>
        /// Change Parent Event
        /// </summary>
        /// <param name="eventID">eventID</param>
        /// <param name="isParent">isParent</param>
        /// <param name="cUserID">cUserID</param>
        public void ChangeParentEvent(int eventID, bool isParent, int cUserID)
        {
            EventCalendarDAL.ChangeParentEvent(eventID, isParent, cUserID, WebConstants.Tab_EventCalendar);
        }

        /// <summary>
        /// Update Content For Following
        /// </summary>
        /// <param name="eventID">eventID</param>
        public void UpdateContentForFollowing(int eventID)
        {
            EventCalendarDAL.UpdateContentForFollowing(eventID);
        }

        /// <summary>
        /// Update Show Repeat
        /// </summary>
        /// <param name="evnetId">evnetId</param>
        /// <param name="flag">flag</param>
        public void UpdateShowRepeat(int evnetId, bool flag)
        {
            EventCalendarDAL.UpdateShowRepeat(evnetId, flag);
        }

        /// <summary>
        /// Insert Update Auto Share Details
        /// </summary>
        /// <param name="contentType">contentType</param>
        /// <param name="contentID">contentID</param>
        /// <param name="send_Status">send_Status</param>
        /// <param name="send_Date">send_Date</param>
        /// <param name="media_Type">media_Type</param>
        /// <param name="userID">userID</param>
        /// <param name="createdUserId">createdUserId</param>
        /// <param name="contentTitle">contentTitle</param>
        public void InsertUpdateAutoShareDetails(string contentType, int contentID, int send_Status, DateTime send_Date, string media_Type, int userID, int createdUserId, string contentTitle)
        {
            EventCalendarDAL.InsertUpdateAutoShareDetails(contentType, contentID, send_Status, send_Date, media_Type, userID, createdUserId, contentTitle);
        }

        /// <summary>
        /// Update Sent Flag
        /// </summary>
        /// <param name="contentId">contentId</param>
        /// <param name="flag">flag</param>
        /// <param name="existingFlag">existingFlag</param>
        /// <param name="contentType">contentType</param>
        public void UpdateSentFlag(int contentId, int flag, int existingFlag, string contentType)
        {
            EventCalendarDAL.UpdateSentFlag(contentId, flag, existingFlag, contentType);
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
        /// Insert Last Sync Date
        /// </summary>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="UserID">UserID</param>
        /// <param name="C_UserID">C_UserID</param>
        /// <param name="LastSyncDate">LastSyncDate</param>
        /// <param name="calendarType">calendarType</param>
        public void InsertLastSyncDate(int ProfileID, int UserID, int C_UserID, DateTime LastSyncDate, string calendarType)
        {
            EventCalendarDAL.InsertLastSyncDate(ProfileID, UserID, C_UserID, LastSyncDate, calendarType);
        }

        /// <summary>
        /// Get Last Sync Date
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns>DateTime</returns>
        public DateTime GetLastSyncDate(int UserID)
        {
            return EventCalendarDAL.GetLastSyncDate(UserID);
        }
    }
}
