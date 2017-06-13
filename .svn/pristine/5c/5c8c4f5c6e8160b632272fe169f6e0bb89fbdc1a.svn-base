using System;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class EventCalendarDAL : DataAccess
    {

        public static int InsertEventDetails(int eventID, int profileID, int userID, string eventTitle, string eventDesc, bool status,
            string eventStartDate, string eventEndDate, bool rsvpFlag, int rsvpCount, bool progressLevel, bool isPublic, int id, string pEditHtml,
            int? publishedBy, DateTime? publishDate, string ListDescription, DateTime? pExDate, bool pIsCall, bool pIsContactUs, bool isRepeat, int? parentEventID)
        {
            DataTable vtable = new DataTable("EventCalendar");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertEventDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventId", eventID);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileID);
                sqlCmd.Parameters.AddWithValue("@UserId", userID);
                sqlCmd.Parameters.AddWithValue("@EventTitle", eventTitle);
                sqlCmd.Parameters.AddWithValue("@EventDesc", eventDesc);
                sqlCmd.Parameters.AddWithValue("@Status", status);
                sqlCmd.Parameters.AddWithValue("@EventStartDate", eventStartDate);
                sqlCmd.Parameters.AddWithValue("@EventEndDate", eventEndDate);
                sqlCmd.Parameters.AddWithValue("@RsvpFlag", rsvpFlag);
                sqlCmd.Parameters.AddWithValue("@RsvpCount", rsvpCount);
                sqlCmd.Parameters.AddWithValue("@IsPublished", progressLevel);
                sqlCmd.Parameters.AddWithValue("@IsPublic", isPublic);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.Parameters.AddWithValue("@EditHtml", pEditHtml);
                sqlCmd.Parameters.AddWithValue("@PublishedBy", publishedBy);
                sqlCmd.Parameters.AddWithValue("@publishDate", publishDate);
                sqlCmd.Parameters.AddWithValue("@ListDescription", ListDescription);
                sqlCmd.Parameters.AddWithValue("@ExDate", pExDate);
                sqlCmd.Parameters.AddWithValue("@IsCall", pIsCall);
                sqlCmd.Parameters.AddWithValue("@IsContactUs", pIsContactUs);
                sqlCmd.Parameters.AddWithValue("@IsRepeat", isRepeat);
                sqlCmd.Parameters.AddWithValue("@ParentEventID", parentEventID);
                if (eventID != 0)
                {
                    SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                    sqlAdptr.Fill(vtable);

                    returnval = eventID;
                }
                else
                {
                    returnval = Convert.ToInt32(sqlCmd.ExecuteScalar());
                }

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
        /***Added By Suneel *****/
        public static int InsertGMailEventDetails(int eventID, int profileID, int userID, string eventTitle, string eventDesc, bool status, string eventStartDate,
            string eventEndDate, bool rsvpFlag, int rsvpCount, bool progressLevel, bool isPublic, int id, string pEditHtml, int? publishedBy, DateTime? publishDate, string Location, string Type, string CalID, string CalendarName)
        {
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertGMailEventDetailsinManageList", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventId", eventID);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileID);
                sqlCmd.Parameters.AddWithValue("@UserId", userID);
                sqlCmd.Parameters.AddWithValue("@EventTitle", eventTitle);
                sqlCmd.Parameters.AddWithValue("@EventDesc", eventDesc);
                sqlCmd.Parameters.AddWithValue("@Status", status);
                sqlCmd.Parameters.AddWithValue("@EventStartDate", eventStartDate);
                sqlCmd.Parameters.AddWithValue("@EventEndDate", eventEndDate);
                sqlCmd.Parameters.AddWithValue("@RsvpFlag", rsvpFlag);
                sqlCmd.Parameters.AddWithValue("@RsvpCount", rsvpCount);
                sqlCmd.Parameters.AddWithValue("@IsPublished", progressLevel);
                sqlCmd.Parameters.AddWithValue("@IsPublic", isPublic);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.Parameters.AddWithValue("@EditHtml", pEditHtml);
                sqlCmd.Parameters.AddWithValue("@PublishedBy", publishedBy);
                sqlCmd.Parameters.AddWithValue("@publishDate", publishDate);
                sqlCmd.Parameters.AddWithValue("@Location", Location);
                sqlCmd.Parameters.AddWithValue("@Type", Type);
                sqlCmd.Parameters.AddWithValue("@CalendarID", CalID);
                sqlCmd.Parameters.AddWithValue("@CalendarName", CalendarName);
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
        public static void InsertUpdateGMailUserDetails(string userName, string password, bool Flag, bool Sync, int ProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertGMailEventDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", userName);
                sqlCmd.Parameters.AddWithValue("@Password", password);
                sqlCmd.Parameters.AddWithValue("@Flag", Flag);
                sqlCmd.Parameters.AddWithValue("@Sync", Sync);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Connection = sqlCon;
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

        /************************************************************/
        public static DataTable GetAllEventsByProfileId(int profileID)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllEventsByProfileId", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileID);
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
        /***********************Done By Suneel(below)************************/
        public static DataTable GetSendEventsByProfileID(int profileID)
        {
            DataTable dtCoupons = new DataTable();
            SqlConnection objcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand objcmd = new SqlCommand();
                objcmd.Connection = objcon;
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.CommandText = "usp_GetSentEventsByProfileId";
                objcmd.Parameters.AddWithValue("@Profile_ID", profileID);
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

        public static DataTable GetAllEventsByProfileId1(int profileID)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllEventsByProfileId1", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileID);
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
        public static DataTable GetCalendarEventDetails(int eventID)
        {
            DataTable vtable = new DataTable("EventId");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCalendarEventDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventId", eventID);

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
        public static int DeleteCalenderEvent(int eventID)
        {
            DataTable vtable = new DataTable("EventCalendar");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteCalenderEvent", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventId", eventID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
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

        public static DataTable GetAll3MontthsEventsByProfileId(int profileID)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAll3MonthsEventsByProfileId", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileID);
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
        public static DataTable GetAllEventsByProfileIdandSelectedMonth(int profileID, string selecteddate)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllEventsByProfileIdandSelectedmonth", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileID);
                sqlCmd.Parameters.AddWithValue("@selecteddate", selecteddate);
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

        public static DataTable usp_GetAllEventsByMonth_PID(int profileID, string selecteddate, string pType)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllEventsByMonth_PID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileID);
                sqlCmd.Parameters.AddWithValue("@selecteddate", selecteddate);
                sqlCmd.Parameters.AddWithValue("@Type", pType);
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

        // Check For Umlimted Email Users

        public static DataTable CheckForUnlimtedUserEmail(int userID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_CheckUnlimitedMailUser", sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
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

        // End for Check For Umlimted Email Users
        public static int CheckforBusinessEventSchedule(int userID)
        {
            int checkName = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetSchBusinessEventCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
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

        public static DataTable CheckForGoogleEvents(int ProfileID)
        {
            DataTable vtable = new DataTable("ProfileID");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetGoogleEventsCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
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

        public static DataTable GetBusinessEventDetails(int eventID)
        {
            DataTable vtable = new DataTable("EventID");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBusinessEventWithEventId", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventID", eventID);

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
        public static string GetBusinessEventMaxScheduleingDate(int userID)
        {
            string schDate = string.Empty;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBusinessEventMaxSchedulingDate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
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
        public static DataTable GetBusinessEventDetailsByBusinessEventID(int businessEventID)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBusinessEventMasterDetailsByBusinessEventID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BusinessEventID", businessEventID);
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
        public static int CheckEventSendingCountforSendingDate(int userID, DateTime eventSendingDate)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckEmailsCountOnSendingDateForEvent", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SendingDate", eventSendingDate);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
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
        public static int InsertBusinessEventScheduleDetails(int eventID, int senderProfileID, int senderUserID, string schduleEventSubject, string receiverEmailID, DateTime sendingDate, DateTime scheduleDate, int sentFlag, bool isToday, string groupID, bool contactuschecked, string shareEvent, int id, int verticalID, bool storeLinksChecked)
        {
            int scheduleEventID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertEventScheduleDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventID", eventID);
                sqlCmd.Parameters.AddWithValue("@SenderProfileID", senderProfileID);
                sqlCmd.Parameters.AddWithValue("@SenderUserID", senderUserID);
                sqlCmd.Parameters.AddWithValue("@SchduleEventSubject", schduleEventSubject);
                sqlCmd.Parameters.AddWithValue("@ReceiverEmailID", receiverEmailID);
                sqlCmd.Parameters.AddWithValue("@SendingDate", sendingDate);
                sqlCmd.Parameters.AddWithValue("@ScheduleDate", scheduleDate);
                sqlCmd.Parameters.AddWithValue("@SentFlag", sentFlag);
                sqlCmd.Parameters.AddWithValue("@IsToday", isToday);
                sqlCmd.Parameters.AddWithValue("@Group_ID", groupID);
                sqlCmd.Parameters.AddWithValue("@Contactuschecked", contactuschecked);
                sqlCmd.Parameters.AddWithValue("@ShareEvent", shareEvent);
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
        // To Get Opt Out Count Business Update Count
        public static DataTable GetOptOutCountForEventID(int eventID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetOptOutCountForEvents", sqlCon);
                sqlCmd.Parameters.AddWithValue("@EventID", eventID);
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
        // End

        public static int GetOptCountForEventHisID(int eventID, int userID)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllOptoutsCountforEventMasterID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@SchHisID", eventID);
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
        public static DataTable GetCampaignBusinessEventDetailsByDates(int eventID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetScheduledEventDetailsbyScheduledEventID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchHisID", eventID);
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
        public static int GetEventCountforDayforUserDateAndEventID(int userID, DateTime sendingDate, int eventID)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetEventCountforDayandUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@Date", sendingDate);
                sqlCmd.Parameters.AddWithValue("@SchID", eventID);
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
        public static void CancelEventCampaign(int eventID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CancelEventCampaign", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchHisID", eventID);
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
        public static int CheckEventCampaignCount(int eventID)
        {
            int checkName = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetEventCampaignCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventHisID", eventID);
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
        public static DataTable CheckEventCampaignSchedule(int eventID)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetEventCampaignSchedule", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventID", eventID);
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
        public static void DeleteEventTemplate(int eventID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DeleteEventTemplate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventID", eventID);
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

        public static DataTable GetFilteredEvents(int userID, string filterValue)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetFilteredEvents", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@FilterValue", filterValue);
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

        public static int UnsubscribeEventEmail(int eventID, int userID, string userEmail)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UnSubscribeEventEmail", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@SchHisID", eventID);
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
        public static DataTable GetEventCalendarDetailsBySchID(int schID)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetEventCalendarDetailsBySchID", sqlCon);
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

        //2/01/2012

        public static int UpdateBusinessEventStatus(int eventId, bool status, int profileId)
        {
            int returnval = 1;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_UpdateBusinessEventStatus", sqlCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@EventId", eventId);
                sqlCmd.Parameters.AddWithValue("@Status", status);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);

                sqlCmd.ExecuteNonQuery();
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
        public static DataSet GetEventsCounts(int eventID, int flag, int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetEventsCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Event_Id", eventID);
                sqlCmd.Parameters.AddWithValue("@flag", flag);
                sqlCmd.Parameters.AddWithValue("@profileId", profileID);
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
        public static void UpdateAutoEmailToAdminFalg(int userID, int id, string type, int userID1)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateAutoEmailToAdminFalg", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.Parameters.AddWithValue("@Type", type);
                sqlCmd.Parameters.AddWithValue("@USER_ID", userID1);
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
        public static void UpdatePublishedEvents(bool flag, int userID, int mUserID, int eventID, DateTime? publishDate, bool isPublished)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdatePublishedEvents", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Flag", flag);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ModifiedUserID", mUserID);
                sqlCmd.Parameters.AddWithValue("@EventId", eventID);
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
        public static void AddRepeatEventDetails(int eventID, int repeats, int repeatX, DateTime startsOn, int endsType, string endsAt, string repeatsOn, string repeatBy, int cUserID, string buttonType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertRepeatEventDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventID", eventID);
                sqlCmd.Parameters.AddWithValue("@Repeats", repeats);
                sqlCmd.Parameters.AddWithValue("@RepeatsX", repeatX);
                sqlCmd.Parameters.AddWithValue("@StartsOn", startsOn);
                sqlCmd.Parameters.AddWithValue("@EndsType", endsType);
                sqlCmd.Parameters.AddWithValue("@EndsAt", endsAt);
                sqlCmd.Parameters.AddWithValue("@RepeatsOn", repeatsOn);
                sqlCmd.Parameters.AddWithValue("@RepeatBy", repeatBy);
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
        public static DataTable GetRepeatEventByEventID(int eventID, string buttonType)
        {
            DataTable dtRepeat = new DataTable();
            SqlConnection objcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand objcmd = new SqlCommand();
                objcmd.Connection = objcon;
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.CommandText = "USP_GetRepeatEventByEventID";
                objcmd.Parameters.AddWithValue("@EventID", eventID);
                objcmd.Parameters.AddWithValue("@ButtonType", buttonType);
                SqlDataAdapter daCoupons = new SqlDataAdapter(objcmd);
                daCoupons.Fill(dtRepeat);
                return dtRepeat;

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
        public static void DeleteRepeat(int eventID, int userID, int deleteType, int cUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeleteRepeat", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventID", eventID);
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
        public static void AddRepeatEvents(int parentEventID, string[] str3ItemsArray, string[] strEndsOn, string repeatOn, string repeatBy, DateTime eventStartDate, DateTime eventEndDate, int cUserID)
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
                    sqlCmd.CommandText = "USP_InsertDailyEvents";
                else if (str3ItemsArray[0] == "1")
                    sqlCmd.CommandText = "USP_InsertWeeklyEvents";
                else if (str3ItemsArray[0] == "2")
                    sqlCmd.CommandText = "USP_InsertMonthlyEvents";
                else if (str3ItemsArray[0] == "3")
                    sqlCmd.CommandText = "USP_InsertYearlyEvents";

                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ParentEventID", parentEventID);
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
        public static void UpdateRepeatEvents(int parentEventID, int addFlag, DateTime startDate, DateTime endDate, int cUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = "USP_UpdateFollowingEvents";
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ParentEventID", parentEventID);
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
        public static void AddRepeatEventsForDaily()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertDailyEvents", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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
        public static void AddRepeatEventsForWeekly()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {

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
        public static void AddRepeatEventsForMonthly()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertMonthlyEvents", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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
        public static void AddRepeatEventsForYearly()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertYearlyEvents", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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
        public static void ChangeParentEvent(int eventID, bool isParent, int cUserID, string buttonType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_ChangeParentEvent", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventID", eventID);
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
        public static void UpdateContentForFollowing(int eventID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_UpdateContentForFollowing", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventId", eventID);
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
        public static void UpdateShowRepeat(int eventID, bool flag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_UpdateShowRepeat", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EventId", eventID);
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
        public static void InsertUpdateAutoShareDetails(string contentType, int contentID, int send_Status, DateTime send_Date, string media_Type, int userID, int createdUserId, string contentTitle)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertUpdateAutoShareDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@contentType", contentType);
                sqlCmd.Parameters.AddWithValue("@contentID", contentID);
                sqlCmd.Parameters.AddWithValue("@sendStatus", send_Status);
                sqlCmd.Parameters.AddWithValue("@sendDate", send_Date);
                sqlCmd.Parameters.AddWithValue("@mediaType", media_Type);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CreatedUserID", userID);
                sqlCmd.Parameters.AddWithValue("@ContentTitle", contentTitle);
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
        public static void UpdateSentFlag(int contentId, int flag, int existingFlag, string contentType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateSentFlagStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContentId", contentId);
                sqlCmd.Parameters.AddWithValue("@SentFlagStatus", flag);
                sqlCmd.Parameters.AddWithValue("@ExistingFlag", existingFlag);
                sqlCmd.Parameters.AddWithValue("@ContentType", contentType);
                sqlCmd.Parameters.AddWithValue("@MediaType", null);
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
        public static void RemoveGoogleEvents(string CalendarID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeleteGoogleEventsFromPresent", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CalendarID", CalendarID);
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
        public static void InsertLastSyncDate(int ProfileID, int UserID, int C_UserID, DateTime LastSyncDate, string calendarType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertLastSyncDate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", C_UserID);
                sqlCmd.Parameters.AddWithValue("@LastSyncDate", LastSyncDate);
                sqlCmd.Parameters.AddWithValue("@CalendarType", calendarType);
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
        public static DateTime GetLastSyncDate(int UserID)
        {
            DateTime lastSyncDate;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetLastSyncDate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.ExecuteNonQuery();
                lastSyncDate = Convert.ToDateTime(sqlCmd.ExecuteScalar());
                return lastSyncDate;
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
