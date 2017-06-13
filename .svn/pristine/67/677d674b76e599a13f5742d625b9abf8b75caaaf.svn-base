using System;
using System.Data;

namespace USPDHUBBLL
{
    public class Schedules
    {
        public Schedules()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        /// Check Appointment Availability details
        /// </summary>
        /// <param name="startTime">startTime</param>
        /// <param name="endTime">endTime</param>
        /// <param name="startDate">startDate</param>
        /// <param name="schProfileID">schProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable CheckAppointmentAvailabilitydetails(string startTime, string endTime, string startDate, int schProfileID)
        {
            return USPDHUBDAL.Schedules.CheckAppointmentAvailabilitydetails(startTime, endTime, startDate, schProfileID);
        }

        /// <summary>
        /// Get schedule Details1
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetscheduleDetails1(bool top5Flag, int userID)
        {
            return USPDHUBDAL.Schedules.GetscheduleDetails1(top5Flag, userID);
        }

        /// <summary>
        /// Get Business Scheduled Calendar
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessscheduleCalendar(bool top5Flag, int profileID)
        {
            return USPDHUBDAL.Schedules.GetBusinessscheduleCalendar(top5Flag, profileID);
        }

        /// <summary>
        /// Manage Schedule Appointment
        /// </summary>
        /// <param name="privacy">privacy</param>
        /// <param name="subject">subject</param>
        /// <param name="userid">userid</param>
        /// <param name="profileID">profileID</param>
        /// <param name="startdate">startdate</param>
        /// <param name="enddate">enddate</param>
        /// <param name="starthours">starthours</param>
        /// <param name="endhours">endhours</param>
        /// <param name="message">message</param>
        /// <param name="baccept">baccept</param>
        /// <param name="caccept">caccept</param>
        /// <param name="isactive">isactive</param>
        /// <param name="schduleID">schduleID</param>
        /// <param name="ttype">ttype</param>
        /// <param name="scheduleLocation">scheduleLocation</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int ManageScheduleAppointment(string privacy, string subject, int userid, int profileID, string startdate, string enddate, string starthours, string endhours, string message, bool baccept, bool caccept, bool isactive, int schduleID, int ttype, string scheduleLocation, int id)
        {
            return USPDHUBDAL.Schedules.ManageScheduleAppointment(privacy, subject, userid, profileID, startdate, enddate, starthours, endhours, message, baccept, caccept, isactive, schduleID, ttype, scheduleLocation, id);
        }

        /// <summary>
        /// Check Business Calendar
        /// </summary>
        /// <param name="dayval">dayval</param>
        /// <param name="starttime">starttime</param>
        /// <param name="endtime">endtime</param>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable CheckBusinessCalendar(string dayval, string starttime, string endtime, int profileID)
        {
            return USPDHUBDAL.Schedules.CheckBusinessCalendar(dayval, starttime, endtime, profileID);
        }

        /// <summary>
        /// Get Business Calendar Details
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessCalendarDetails(int profileID)
        {
            return USPDHUBDAL.Schedules.GetBusinessCalendarDetails(profileID);
        }

        /// <summary>
        /// Manage Business Calendar
        /// </summary>
        /// <param name="dayval">dayval</param>
        /// <param name="userID">userID</param>
        /// <param name="starttime">starttime</param>
        /// <param name="endtime">endtime</param>
        /// <param name="bRstarttime">bRstarttime</param>
        /// <param name="bRendtime">bRendtime</param>
        /// <param name="profileID">profileID</param>
        /// <param name="calendarID">calendarID</param>
        /// <param name="ttype">ttype</param>
        /// <param name="business24Hours">business24Hours</param>
        /// <returns>Int</returns>
        public int ManageBusinessCalendar(string dayval, int userID, string starttime, string endtime, string bRstarttime, string bRendtime, int profileID, int calendarID, int ttype, bool business24Hours)
        {
            return USPDHUBDAL.Schedules.ManageBusinessCalendar(dayval, userID, starttime, endtime, bRstarttime, bRendtime, profileID, calendarID, ttype, business24Hours);
        }

        /// <summary>
        /// Manage Business Calendar
        /// </summary>
        /// <param name="dayval">dayval</param>
        /// <param name="userID">userID</param>
        /// <param name="starttime">starttime</param>
        /// <param name="endtime">endtime</param>
        /// <param name="bRstarttime">bRstarttime</param>
        /// <param name="bRendtime">bRendtime</param>
        /// <param name="profileID">profileID</param>
        /// <param name="calendarID">calendarID</param>
        /// <param name="ttype">ttype</param>
        /// <param name="business24Hours">business24Hours</param>
        /// <param name="activeFlag">activeFlag</param>
        /// <param name="appointmentPerSlot">appointmentPerSlot</param>
        /// <param name="slotDuration">slotDuration</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int ManageBusinessCalendar1(string dayval, int userID, string starttime, string endtime, string bRstarttime, string bRendtime, int profileID, int calendarID, int ttype, bool business24Hours, bool activeFlag, int appointmentPerSlot, int slotDuration, int id)
        {
            return USPDHUBDAL.Schedules.ManageBusinessCalendar1(dayval, userID, starttime, endtime, bRstarttime, bRendtime, profileID, calendarID, ttype, business24Hours, activeFlag, appointmentPerSlot, slotDuration, id);
        }

        /// <summary>
        /// Get Business Appointments By Date
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="startdate">startdate</param>
        /// <param name="enddate">enddate</param>
        /// <returns>DataTable</returns>
        public DataTable GetBusinessAppointmentsByDate(int profileID, string startdate, string enddate)
        {
            return USPDHUBDAL.Schedules.GetBusinessAppointmentsByDate(profileID, startdate, enddate);

        }

        /// <summary>
        /// Get Consumer Appointments By Date
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="startdate">startdate</param>
        /// <param name="enddate">enddate</param>
        /// <returns>DataTable</returns>
        public DataTable GetConsumerAppointmentsByDate(int userID, string startdate, string enddate)
        {
            return USPDHUBDAL.Schedules.GetConsumerAppointmentsByDate(userID, startdate, enddate);

        }

        /// <summary>
        /// Get All Consumer Appointments
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllConsumerAppointments(int userID)
        {
            return USPDHUBDAL.Schedules.GetAllConsumerAppointments(userID);
        }

        /// <summary>
        /// Get All Business Appointments
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllBusinessAppointments(int profileID)
        {
            return USPDHUBDAL.Schedules.GetAllBusinessAppointments(profileID);
        }

        /// <summary>
        /// Accept Business Appointment
        /// </summary>
        /// <param name="apptID">apptID</param>
        /// <param name="utype">utype</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int AcceptBusinessAppintment(int apptID, int utype, int id)
        {
            return USPDHUBDAL.Schedules.AcceptBusinessAppintment(apptID, utype, id);
        }

        /// <summary>
        /// Delete Business Appointment
        /// </summary>
        /// <param name="apptID">apptID</param>
        /// <param name="utype">utype</param>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int DeleteBusinessAppintment(int apptID, int utype, int userID)
        {
            return USPDHUBDAL.Schedules.DeleteBusinessAppintment(apptID, utype, userID);
        }

        /// <summary>
        /// Get Appointment Details By Scheduled ID
        /// </summary>
        /// <param name="schID">schID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAppointmentDetailsByID(int schID)
        {
            return USPDHUBDAL.Schedules.GetAppointmentDetailsByID(schID);
        }

        /// <summary>
        /// Delete Manage Calendar
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int DeleteManageCalendar(int profileID)
        {
            return USPDHUBDAL.Schedules.DeleteManageCalendar(profileID);
        }

        /// <summary>
        /// Check Appointment Availability
        /// </summary>
        /// <param name="startTime">startTime</param>
        /// <param name="endTime">endTime</param>
        /// <param name="startDate">startDate</param>
        /// <param name="schProfileID">schProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable CheckAppointmentAvailability(string startTime, string endTime, string startDate, int schProfileID)
        {
            return USPDHUBDAL.Schedules.CheckAppointmentAvailability(startTime, endTime, startDate, schProfileID);
        }

        /// <summary>
        /// Check User Appointment Availability
        /// </summary>
        /// <param name="startTime">startTime</param>
        /// <param name="endTime">endTime</param>
        /// <param name="startDate">startDate</param>
        /// <param name="schUserID">schUserID</param>
        /// <returns>DataTable</returns>
        public DataTable CheckUserAppointmentAvailability(string startTime, string endTime, string startDate, int schUserID)
        {
            return USPDHUBDAL.Schedules.CheckUserAppointmentAvailability(startTime, endTime, startDate, schUserID);
        }

        /// <summary>
        /// Check Appointments lot availability
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="startTime">startTime</param>
        /// <param name="endTime">endTime</param>
        /// <param name="startDate">startDate</param>
        /// <returns>DataTable</returns>
        public DataTable CheckAppointmentslotavailability(int profileId, string startTime, string endTime, string startDate)
        {
            return USPDHUBDAL.Schedules.CheckAppointmentslotavailability(profileId, startTime, endTime, startDate);
        }

        /// <summary>
        /// Get All Business Calendar Details
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllBusinessCalendarDetails(int profileID)
        {
            return USPDHUBDAL.Schedules.GetAllBusinessCalendarDetails(profileID);
        }

        /// <summary>
        /// Update Business Calendar Status
        /// </summary>
        /// <param name="cID">cID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="activeFlag">activeFlag</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int UpdateBusinessCalendarStatus(int cID, int profileID, bool activeFlag, int id)
        {
            return USPDHUBDAL.Schedules.UpdateBusinessCalendarStatus(cID, profileID, activeFlag, id);
        }
    }
}
