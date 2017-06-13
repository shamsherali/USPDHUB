using System;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class Schedules : DataAccess
    {
        public Schedules()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static DataTable CheckAppointmentAvailabilitydetails(string startTime, string endTime, string startDate, int schProfileID)
        {
            DataTable availability = new DataTable("Availability");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetScheduleSlotAvilabilitydetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@Sch_Start_Time", startTime.Trim());
                sqlCmd.Parameters.AddWithValue("@Sch_End_Time", endTime.Trim());
                sqlCmd.Parameters.AddWithValue("@Sch_Profile_ID", schProfileID);
                sqlCmd.Parameters.AddWithValue("@Sch_Start_Date", startDate);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(availability);

                return availability;
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

        public static DataTable GetscheduleDetails1(bool top5Flag, int userID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSheduleAppointments", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userId", userID);
                sqlCmd.Parameters.AddWithValue("@top5flag", top5Flag);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(msgs);

                return msgs;
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
        public static DataTable GetBusinessscheduleCalendar(bool top5Flag, int profileID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBusinessSheduleAppointments", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userId", profileID);
                sqlCmd.Parameters.AddWithValue("@top5flag", top5Flag);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(msgs);

                return msgs;
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
        public static int ManageScheduleAppointment(string privacy, string subject, int userid, int profileID, string startdate, string enddate, string starthours, string endhours, string message, bool baccept, bool caccept, bool isactive, int schduleID, int ttype, string scheduleLocation, int id)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageSchduleAppointments", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@privacy", privacy);
                sqlCmd.Parameters.AddWithValue("@subject", subject);
                sqlCmd.Parameters.AddWithValue("@userID", userid);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@startdate", startdate);
                sqlCmd.Parameters.AddWithValue("@enddate", enddate);
                sqlCmd.Parameters.AddWithValue("@starttime", starthours);
                sqlCmd.Parameters.AddWithValue("@endtime", endhours);
                sqlCmd.Parameters.AddWithValue("@Message", message);
                sqlCmd.Parameters.AddWithValue("@baccept", baccept);
                sqlCmd.Parameters.AddWithValue("@caccept", caccept);
                sqlCmd.Parameters.AddWithValue("@IsActive", isactive);
                sqlCmd.Parameters.AddWithValue("@ScheduleID", schduleID);
                sqlCmd.Parameters.AddWithValue("@TType", ttype);
                sqlCmd.Parameters.AddWithValue("@Schedule_location", scheduleLocation);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable != null)
                {
                    returnval = Convert.ToInt32(vtable.Rows[0][0]);
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
        public static DataTable CheckBusinessCalendar(string dayval, string starttime, string endtime, int profileID)
        {
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCheckBusinessShedule1", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@dayval", dayval);
                sqlCmd.Parameters.AddWithValue("@starttime", starttime);
                sqlCmd.Parameters.AddWithValue("@endtime", endtime);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);

                return calendar;
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
        public static DataTable GetBusinessCalendarDetails(int profileID)
        {
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCalendarEnableDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);

                return calendar;
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

        public static int ManageBusinessCalendar(string dayval, int userID, string starttime, string endtime, string bRstarttime, string bRendtime, int profileID, int calendarID, int ttype, bool business24Hours)
        {
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int returnval = 0;

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageBusinessCalendar", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userID", userID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@day", dayval);
                sqlCmd.Parameters.AddWithValue("@starttime", starttime);
                sqlCmd.Parameters.AddWithValue("@endtime", endtime);
                sqlCmd.Parameters.AddWithValue("@Brkstarttime", bRstarttime);
                sqlCmd.Parameters.AddWithValue("@Brkendtime", bRendtime);
                sqlCmd.Parameters.AddWithValue("@IsActive", 1);
                sqlCmd.Parameters.AddWithValue("@calendarID", calendarID);
                sqlCmd.Parameters.AddWithValue("@TType", ttype);
                sqlCmd.Parameters.AddWithValue("@Business_24hours", business24Hours);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);
                if (calendar != null)
                {
                    returnval = Convert.ToInt32(calendar.Rows[0][0]);
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
        public static int ManageBusinessCalendar1(string dayval, int userID, string starttime, string endtime, string bRstarttime, string bRendtime, int profileID, int calendarID, int ttype, bool business24Hours, bool activeFlag, int appointmentPerSlot, int slotDuration, int id)
        {
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int returnval = 0;

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageBusinessCalendar1", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userID", userID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@day", dayval);
                sqlCmd.Parameters.AddWithValue("@starttime", starttime);
                sqlCmd.Parameters.AddWithValue("@endtime", endtime);
                sqlCmd.Parameters.AddWithValue("@Brkstarttime", bRstarttime);
                sqlCmd.Parameters.AddWithValue("@Brkendtime", bRendtime);
                sqlCmd.Parameters.AddWithValue("@IsActive", activeFlag);
                sqlCmd.Parameters.AddWithValue("@calendarID", calendarID);
                sqlCmd.Parameters.AddWithValue("@TType", ttype);
                sqlCmd.Parameters.AddWithValue("@Business_24hours", business24Hours);
                sqlCmd.Parameters.AddWithValue("@AppointmentPerSlot", appointmentPerSlot);
                sqlCmd.Parameters.AddWithValue("@Slot_Duration", slotDuration);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);
                if (calendar != null)
                {
                    returnval = Convert.ToInt32(calendar.Rows[0][0]);
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
        public static DataTable GetBusinessAppointmentsByDate(int profileID, string startdate, string enddate)
        {
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBusinessAppointmentsByDate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@userID", profileID);
                sqlCmd.Parameters.AddWithValue("@startdate", startdate);
                sqlCmd.Parameters.AddWithValue("@enddate", enddate);

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);

                return calendar;
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
        public static DataTable GetAllBusinessAppointments(int profileID)
        {
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllBusinessAppointments", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@userID", profileID);

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);

                return calendar;
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
        public static DataTable GetConsumerAppointmentsByDate(int userID, string startdate, string enddate)
        {
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetConsumerAppointmentsByDate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@userID", userID);
                sqlCmd.Parameters.AddWithValue("@startdate", startdate);
                sqlCmd.Parameters.AddWithValue("@enddate", enddate);

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);

                return calendar;
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
        public static DataTable GetAllConsumerAppointments(int userID)
        {
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllConsumerAppointments", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@userID", userID);

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);

                return calendar;
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
        public static int AcceptBusinessAppintment(int apptID, int utype,int id)
        {
            int returnval = 0;
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AcceptSchduleAppointment", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@ApptID", apptID);
                sqlCmd.Parameters.AddWithValue("@UType", utype);
                sqlCmd.Parameters.AddWithValue("@ID", id);

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);
                if (calendar != null)
                {
                    returnval = Convert.ToInt32(calendar.Rows[0][0]);
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
        public static int DeleteBusinessAppintment(int apptID, int utype, int userID)
        {
            int returnval = 0;
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteSchduleAppointment", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@UType", utype);
                sqlCmd.Parameters.AddWithValue("@userID", userID);
                sqlCmd.Parameters.AddWithValue("@ScheduleID", apptID);


                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);
                if (calendar != null)
                {
                    returnval = Convert.ToInt32(calendar.Rows[0][0]);
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
        public static DataTable GetAppointmentDetailsByID(int schID)
        {
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAppointmentDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@SchID", schID);

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);

                return calendar;
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
        public static int DeleteManageCalendar(int profileID)
        {
            int returnval = 0;
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteManageCalendar", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);
                if (calendar != null)
                {
                    returnval = Convert.ToInt32(calendar.Rows[0][0]);
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

        public static DataTable CheckAppointmentAvailability(string startTime, string endTime, string startDate, int schProfileID)
        {
            DataTable availability = new DataTable("Availability");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetScheduleSlotAvilability", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@Sch_Start_Time", startTime.Trim());
                sqlCmd.Parameters.AddWithValue("@Sch_End_Time", endTime.Trim());
                sqlCmd.Parameters.AddWithValue("@Sch_Profile_ID", schProfileID);
                sqlCmd.Parameters.AddWithValue("@Sch_Start_Date", startDate);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(availability);

                return availability;
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

        public static DataTable CheckUserAppointmentAvailability(string startTime, string endTime, string startDate, int schUserID)
        {
            DataTable availability = new DataTable("Availability");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CheckUserScheduleSlotAvilability", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@Sch_Start_Time", startTime.Trim());
                sqlCmd.Parameters.AddWithValue("@Sch_End_Time", endTime.Trim());
                sqlCmd.Parameters.AddWithValue("@Sch_user_ID", schUserID);
                sqlCmd.Parameters.AddWithValue("@Sch_Start_Date", startDate);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(availability);

                return availability;
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
        public static DataTable CheckAppointmentslotavailability(int profileId, string startTime, string endTime, string startDate)
        {


            DataTable availability = new DataTable("Availability");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckAppointmentSlotAvailability", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@Sch_Start_Time", startTime.Trim());
                sqlCmd.Parameters.AddWithValue("@Sch_End_Time", endTime.Trim());
                sqlCmd.Parameters.AddWithValue("@Sch_Profile_ID", profileId);
                sqlCmd.Parameters.AddWithValue("@Schedule_Date", startDate);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(availability);

                return availability;
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
        public static DataTable GetAllBusinessCalendarDetails(int profileID)
        {
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllCalendarDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);

                return calendar;
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
        public static int UpdateBusinessCalendarStatus(int cID, int profileID, bool activeFlag,int id)
        {
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateBusinessCalendarStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@C_ID", cID);
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);
                sqlCmd.Parameters.AddWithValue("@Active_flag", activeFlag);
                sqlCmd.Parameters.AddWithValue("@ID", id);
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



    }
}
