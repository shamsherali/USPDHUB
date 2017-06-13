using System;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class CalendarAddOnDAL : DataAccess
    {
        public static int InsertCalendarAddOnDetails(int calendarId, int profileId, int userId, string eventTitle, string description, string startDate, string endDate,
                                                int cUserId, bool isCall, bool isContactUs, bool isPhotoCapture, string editHtml, string listDescription,
                                                bool isPublished, int? publishedBy, DateTime? publishDate, DateTime? expDate, bool isRepeat, int? parentCalendarId, int userModuleId)
        {
            DataTable vtable = new DataTable("CalendarAddOn");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertCalendarAddOnDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@UserId", userId);
                sqlCmd.Parameters.AddWithValue("@EventTitle", eventTitle);
                sqlCmd.Parameters.AddWithValue("@EventDesc", description);
                sqlCmd.Parameters.AddWithValue("@EventStartDate", startDate);
                sqlCmd.Parameters.AddWithValue("@EventEndDate", endDate);
                sqlCmd.Parameters.AddWithValue("@IsPublished", isPublished);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", cUserId);
                sqlCmd.Parameters.AddWithValue("@EditHtml", editHtml);
                sqlCmd.Parameters.AddWithValue("@PublishedBy", publishedBy);
                sqlCmd.Parameters.AddWithValue("@publishDate", publishDate);
                sqlCmd.Parameters.AddWithValue("@ListDescription", listDescription);
                sqlCmd.Parameters.AddWithValue("@ExDate", expDate);
                sqlCmd.Parameters.AddWithValue("@IsCall", isCall);
                sqlCmd.Parameters.AddWithValue("@IsContactUs", isContactUs);
                sqlCmd.Parameters.AddWithValue("@IsPhotoCapture", isPhotoCapture);
                sqlCmd.Parameters.AddWithValue("@IsRepeat", isRepeat);
                sqlCmd.Parameters.AddWithValue("@ParentCalendarId", parentCalendarId);
                sqlCmd.Parameters.AddWithValue("@UserModuleId", userModuleId);
                returnval = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return returnval;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetCalendarAddOnDetails(int calendarId)
        {
            DataTable dtCalendar = new DataTable("CalendarAddOn");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCalendarAddOnDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtCalendar);
                return dtCalendar;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static void UpdateShowRepeatByAddOn(int calendarId, bool flag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_UpdateShowRepeatByAddOn", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                sqlCmd.Parameters.AddWithValue("@Flag", flag);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static void AddRepeatEventsForCalendarAddOn(int parentCalendarId, string[] str3ItemsArray, string[] strEndsOn, string repeatOn, string repeatBy, DateTime eventStartDate, DateTime eventEndDate, int cUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                DateTime? untilDate = null;
                int? occuranceX = null;
                if (strEndsOn[0] == "1")
                    occuranceX = Convert.ToInt32(strEndsOn[1]);
                else
                    untilDate = Convert.ToDateTime(strEndsOn[1]);
                SqlCommand sqlCmd = new SqlCommand();
                if (str3ItemsArray[0] == "0")
                    sqlCmd.CommandText = "USP_InsertDailyEventsForCalendar";
                else if (str3ItemsArray[0] == "1")
                    sqlCmd.CommandText = "USP_InsertWeeklyEventsForCalendar";
                else if (str3ItemsArray[0] == "2")
                    sqlCmd.CommandText = "USP_InsertMonthlyEventsForCalendar";
                else if (str3ItemsArray[0] == "3")
                    sqlCmd.CommandText = "USP_InsertYearlyEventsForCalendar";

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ParentCalendarId", parentCalendarId);
                sqlCmd.Parameters.AddWithValue("@RepeatType", strEndsOn[0]);
                sqlCmd.Parameters.AddWithValue("@StartDate", eventStartDate);
                sqlCmd.Parameters.AddWithValue("@EndDate", eventEndDate);
                sqlCmd.Parameters.AddWithValue("@EveryX", str3ItemsArray[1]);
                sqlCmd.Parameters.AddWithValue("@UntilDate", untilDate);
                sqlCmd.Parameters.AddWithValue("@OccuranceX", occuranceX);
                if (str3ItemsArray[0] == "1")
                    sqlCmd.Parameters.AddWithValue("@RepeatOn", repeatOn);
                if (str3ItemsArray[0] == "2" || str3ItemsArray[0] == "3")
                    sqlCmd.Parameters.AddWithValue("@RepeatBy", Convert.ToInt32(repeatBy));
                sqlCmd.Parameters.AddWithValue("@CUserID", cUserID);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static void UpdateRepeatCalendarDetails(int parentCalendarId, int addFlag, DateTime startDate, DateTime endDate, int cUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = "USP_UpdateCalendarFollowingEvents";
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ParentCalendarId", parentCalendarId);
                sqlCmd.Parameters.AddWithValue("@AddFlag", addFlag);
                sqlCmd.Parameters.AddWithValue("@StartDate", startDate);
                sqlCmd.Parameters.AddWithValue("@EndDate", endDate);
                sqlCmd.Parameters.AddWithValue("@CUserID", cUserID);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static void DeleteRepeatForCalendar(int calendarId, int userID, int deleteType, int cUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeleteRepeatForCalendar", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@DeleteType", deleteType);
                sqlCmd.Parameters.AddWithValue("@CUserID", cUserID);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static void ChangeParentCalendar(int calendarId, bool isParent, int cUserID, string buttonType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_ChangeParentCalendar", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                sqlCmd.Parameters.AddWithValue("@IsParent", isParent);
                sqlCmd.Parameters.AddWithValue("@CUserID", cUserID);
                sqlCmd.Parameters.AddWithValue("@ButtonType", buttonType);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static void UpdateContentForCalFollowing(int calendarId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_UpdateContentForCalFollowing", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetAllCalendarsByProfileId(int profileId, int calendarAddOnId)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllCalendarsByProfileId", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@CalendarAddOnId", calendarAddOnId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                return vtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static int InsertGMailCalendarDetails(int calendarID, int profileID, int userID, string eventTitle, string eventDesc, string eventStartDate,
            string eventEndDate, bool isPublish, int createdUser, string pEditHtml, int? publishedBy, DateTime? publishDate, string Location, string Type, string googleCalID, string googleCalendarName, int calendarAddOnId)
        {
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertGMailEventDetailsinManageList", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarID", calendarID);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileID);
                sqlCmd.Parameters.AddWithValue("@UserId", userID);
                sqlCmd.Parameters.AddWithValue("@EventTitle", eventTitle);
                sqlCmd.Parameters.AddWithValue("@EventDesc", eventDesc);
                sqlCmd.Parameters.AddWithValue("@EventStartDate", eventStartDate);
                sqlCmd.Parameters.AddWithValue("@EventEndDate", eventEndDate);
                sqlCmd.Parameters.AddWithValue("@IsPublished", isPublish);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", createdUser);
                sqlCmd.Parameters.AddWithValue("@EditHtml", pEditHtml);
                sqlCmd.Parameters.AddWithValue("@PublishedBy", publishedBy);
                sqlCmd.Parameters.AddWithValue("@publishDate", publishDate);
                sqlCmd.Parameters.AddWithValue("@Location", Location);
                sqlCmd.Parameters.AddWithValue("@Type", Type);
                sqlCmd.Parameters.AddWithValue("@GoogleCalendarID", googleCalID);
                sqlCmd.Parameters.AddWithValue("@GoogleCalendarName", googleCalendarName);
                sqlCmd.Parameters.AddWithValue("@CalendarAddOnId", calendarAddOnId);
                returnval = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return returnval;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static int CheckCalendarCampaignCount(int calendarId)
        {
            int checkName = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetCalendarCampaignCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                checkName = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return checkName;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetScheduledItemsByCalendarId(int calendarId)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetScheduledItemsByCalendarId", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                return vtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetAllCalendarsByPreview(int profileId, int calendarAddOnId)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllCalendarsByPreview", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@CalendarAddOnId", calendarAddOnId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                return vtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetAll3MontthsCalendarsByPreview(int profileId, int calendarAddOnId)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAll3MontthsCalendarsByPreview", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@CalendarAddOnId", calendarAddOnId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                return vtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetAllCalendarsBySelectedMonth(int profileId, string selectedDate, int calendarAddOnId)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllCalendarsBySelectedMonth", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@SelectedDate", selectedDate);
                sqlCmd.Parameters.AddWithValue("@CalendarAddOnId", calendarAddOnId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                return vtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static void UpdateCalendarPublish(bool flag, int userID, int createdUser, int calendarId, DateTime? publishDate, bool isPublished)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateCalendarPublish", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Flag", flag);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ModifiedUserID", createdUser);
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                sqlCmd.Parameters.AddWithValue("@PublishDate", publishDate);
                sqlCmd.Parameters.AddWithValue("@IsPublished", isPublished);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static void DeleteCalendarById(int calendarId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DeleteCalendarById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static string GetCalendarMaxScheduledDate(int userId)
        {
            string schDate = string.Empty;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetCalendarMaxScheduledDate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserId", userId);
                schDate = Convert.ToString(sqlCmd.ExecuteScalar());
                return schDate;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static int CheckforCalendarSchedule(int userId)
        {
            int checkName = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckforCalendarSchedule", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserId", userId);
                checkName = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return checkName;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetCalendarCampaignByDates(int calendarId)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetCalendarCampaignByDates", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(user);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static int GetCalendarCountForSendingDate(int userId, DateTime sendingDate, int calendarId)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetCalendarCountForSendingDate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserId", userId);
                sqlCmd.Parameters.AddWithValue("@Date", sendingDate);
                sqlCmd.Parameters.AddWithValue("@SchId", calendarId);
                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return count;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static void CancelCalendarCampaign(int calendarId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CancelCalendarCampaign", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchHisID", calendarId);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetSendCalendarsByProfileID(int profileIdD)
        {
            DataTable dtCoupons = new DataTable();
            SqlConnection objcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand objcmd = new SqlCommand();
                objcmd.Connection = objcon;
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.CommandText = "usp_GetSendCalendarsByProfileID";
                objcmd.Parameters.AddWithValue("@Profile_ID", profileIdD);
                SqlDataAdapter daCoupons = new SqlDataAdapter(objcmd);
                daCoupons.Fill(dtCoupons);
                return dtCoupons;

            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(objcon);
            }

        }
        public static DataSet GetCalendarReportCounts(int calendarId, int flag, int profileId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetCalendarReportCounts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                sqlCmd.Parameters.AddWithValue("@flag", flag);
                sqlCmd.Parameters.AddWithValue("@profileId", profileId);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetOptOutCountForCalendarId(int calendarId)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetOptOutCountForCalendarId", sqlCon);
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(user);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static int CheckCalendarSendingCountforSendingDate(int userID, DateTime calSendingDate, int calAddOnId)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckEmailsCountOnSendingDateForCalendar", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SendingDate", calSendingDate);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CalendarAddOnId", calAddOnId);
                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return count;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static int CheckforCalendarSchedule(int userID, int calAddOnId)
        {
            int checkName = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetScheduledCalendarCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CalendarAddOnId", calAddOnId);
                checkName = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return checkName;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static int InsertCalendarScheduleDetails(int calendarId, int senderProfileID, int senderUserID, string schduleSubject, string receiverEmailID, DateTime sendingDate, DateTime scheduleDate, int sentFlag, bool isToday, string groupID, bool contactuschecked, string shareCalendar, int id, int verticalID, bool storeLinksChecked)
        {
            int scheduleEventID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertCalendarScheduleDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarId", calendarId);
                sqlCmd.Parameters.AddWithValue("@SenderProfileID", senderProfileID);
                sqlCmd.Parameters.AddWithValue("@SenderUserID", senderUserID);
                sqlCmd.Parameters.AddWithValue("@SchduleSubject", schduleSubject);
                sqlCmd.Parameters.AddWithValue("@ReceiverEmailID", receiverEmailID);
                sqlCmd.Parameters.AddWithValue("@SendingDate", sendingDate);
                sqlCmd.Parameters.AddWithValue("@ScheduleDate", scheduleDate);
                sqlCmd.Parameters.AddWithValue("@SentFlag", sentFlag);
                sqlCmd.Parameters.AddWithValue("@IsToday", isToday);
                sqlCmd.Parameters.AddWithValue("@Group_ID", groupID);
                sqlCmd.Parameters.AddWithValue("@Contactuschecked", contactuschecked);
                sqlCmd.Parameters.AddWithValue("@ShareCalendar", shareCalendar);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.Parameters.AddWithValue("@VerticalID", verticalID);
                sqlCmd.Parameters.AddWithValue("@StoreLinksChecked", storeLinksChecked);
                scheduleEventID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return scheduleEventID;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetCalendarDetailsBySchID(int schID)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetCalendarDetailsBySchID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchID", schID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                return vtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static int UnsubscribeCalendarEmail(int calendarId, int userID, string userEmail)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UnSubscribeCalendarEmail", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@SchHisID", calendarId);
                sqlCmd.Parameters.AddWithValue("@UserEmail", userEmail);
                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return count;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
    }
}
