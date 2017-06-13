using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class MServiceDAL
    {
        public static DataTable GetMobileAppSetting(int pUserID)
        {
            DataTable dtMSettings = new DataTable("MSettings");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {

                SqlCommand sqlCmd = new SqlCommand("usp_M_GetMobileSettings", sqlCon);
                sqlCmd.Parameters.AddWithValue("@User_ID", pUserID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtMSettings);

                return dtMSettings;
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

        public static DataTable MapviewDirection(string platitude1, string plongitude1, string pRadius)
        {
            DataTable vtable = new DataTable("Search");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_M_GetMapViewDirection", sqlCon);
                sqlCmd.Parameters.AddWithValue("@latitude2", platitude1);
                sqlCmd.Parameters.AddWithValue("@longitude2", plongitude1);
                sqlCmd.Parameters.AddWithValue("@Radius", pRadius);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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


        public static int ManageMessage(int toid, int totypeID, int fromID, string subject, string message, int replyid,
            bool activeflag, int msgID, int userID, int tType, string pSource, string pPhotoName, double pLatitude,
            double pLongitude, string pAddress, bool pIsAnonymous, string pDeviceID, string pDeviceType, int pAppID)
        {
            DataTable vtable = new DataTable("MobileMessages");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_M_ManageMessages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ToID", toid);
                sqlCmd.Parameters.AddWithValue("@ToTypeID", totypeID);
                sqlCmd.Parameters.AddWithValue("@FromID", fromID);
                sqlCmd.Parameters.AddWithValue("@Subject", subject);
                sqlCmd.Parameters.AddWithValue("@Message", message);
                sqlCmd.Parameters.AddWithValue("@RplyID", replyid);
                sqlCmd.Parameters.AddWithValue("@IsActive", activeflag);
                sqlCmd.Parameters.AddWithValue("@MsgID", msgID);
                sqlCmd.Parameters.AddWithValue("@userID", userID);
                sqlCmd.Parameters.AddWithValue("@TType", tType);
                sqlCmd.Parameters.AddWithValue("@Source", pSource);
                sqlCmd.Parameters.AddWithValue("@PhotoName", pPhotoName);
                sqlCmd.Parameters.AddWithValue("@Latitude1", pLatitude);
                sqlCmd.Parameters.AddWithValue("@Longitude1", pLongitude);
                sqlCmd.Parameters.AddWithValue("@Address", pAddress);
                sqlCmd.Parameters.AddWithValue("@IsAnonymous", pIsAnonymous);
                sqlCmd.Parameters.AddWithValue("@Device_ID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@Device_Type", pDeviceType);
                sqlCmd.Parameters.AddWithValue("@App_ID", pAppID);
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


        public static DataTable GetProfileDetails(int pUserID)
        {
            DataTable vtable = new DataTable("ProfileDetails");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_M_GetProfileDetails", sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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

        #region 1.1 Version new methods

        public static DataTable GetProfiledetailsByBCode(string pBCode, int pProfileID, string pType, string latitude2, string longitude2, string radius, string pVCode)
        {
            // 1 means validate b code getting via business details by BCode
            // 2 means getting business details by profile id

            DataTable dtBusinessDetails = new DataTable("ProfileDetailsCode");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_M_GetProfilesDetailsByBCode", sqlCon);
                sqlCmd.Parameters.AddWithValue("@BCode", pBCode);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@Type", pType);
                sqlCmd.Parameters.AddWithValue("@latitude2", latitude2);
                sqlCmd.Parameters.AddWithValue("@longitude2", longitude2);
                sqlCmd.Parameters.AddWithValue("@Radius", radius);
                sqlCmd.Parameters.AddWithValue("@VCode", pVCode);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtBusinessDetails);

                return dtBusinessDetails;
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

        public static string InsertAppDeviceDetails(string pDeviceID, int pProfileID, string pDeviceType, string pBusinessName, string pAddress, int pAppID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_M_InsertAppDeviceDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Device_ID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@Profile_ID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@Device_Type", pDeviceType);
                sqlCmd.Parameters.AddWithValue("@Business_Name", pBusinessName);
                sqlCmd.Parameters.AddWithValue("@Address", pBusinessName);
                sqlCmd.Parameters.AddWithValue("@App_ID", pAppID);
                Convert.ToInt32(sqlCmd.ExecuteScalar());
                return "SUCCESS";
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

        public static string DeleteAppDeviceDetails(string pDeviceID, int pProfileID, int pAppID)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_M_DeleteAppDeviceDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Device_ID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@Profile_ID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@App_ID", pAppID);
                sqlCmd.ExecuteNonQuery();
                return "SUCCESS";
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


        // *** Start push Notifications methods *** //
        public static DataTable GetDevicesforNotifications(int profileID, int pushTypeId, string pushType)
        {
            DataTable dtDevices = new DataTable("devices");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Mob_GetFavoriteDevices", sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@PushTypeId", pushTypeId);
                sqlCmd.Parameters.AddWithValue("@PushType", pushType);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtDevices);

                return dtDevices;
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

        public static int AddPushNotifications(string message, int profileID, int createdUser, int totalDevices, int sentDevices, string deviceIDs, int flag, string type, int typeID, int sentFlag, DateTime dtSentDate, string notificationSendType, string messageSendType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Mob_AddPushNotifications", sqlCon);
                sqlCmd.Parameters.AddWithValue("@Message", message);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", createdUser);
                sqlCmd.Parameters.AddWithValue("@TotalDevices", totalDevices);
                sqlCmd.Parameters.AddWithValue("@SentDevices", sentDevices);
                sqlCmd.Parameters.AddWithValue("@DeviceIDs", deviceIDs);
                sqlCmd.Parameters.AddWithValue("@Flag", flag);
                sqlCmd.Parameters.AddWithValue("@Type", type);
                sqlCmd.Parameters.AddWithValue("@TypeID", typeID);
                sqlCmd.Parameters.AddWithValue("@SentFlag", sentFlag);
                sqlCmd.Parameters.AddWithValue("@SendingDate", dtSentDate);
                sqlCmd.Parameters.AddWithValue("@NotificationSendType", notificationSendType);
                sqlCmd.Parameters.AddWithValue("@MessageSendType", messageSendType);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                return Convert.ToInt32(sqlCmd.ExecuteScalar());
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
        // *** End push Notifications methods *** //

        public static void CancelNotificationSchedule(int pushNotifyID, int modifiedUser)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Mob_CancelNotificationSchedule", sqlCon);
                sqlCmd.Parameters.AddWithValue("@PushNotifyID", pushNotifyID);
                sqlCmd.Parameters.AddWithValue("@ModifiedUser", modifiedUser);
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

        public static DataTable GetPushNotifications(int pProfileID, string pDeviceID, int pAppID)
        {
            DataTable dtDevices = new DataTable("devicess");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetPushNotifications", sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@Device_ID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@App_ID", pAppID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtDevices);

                return dtDevices;
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

        public static DataTable GetAgencySummary(int pProfileID, string pDeviceID, int pAppID)
        {
            DataTable dtBusinessDetails = new DataTable("agencysummary");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_AgencySummary", sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@Device_ID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@App_ID", pAppID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtBusinessDetails);

                return dtBusinessDetails;
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

        public static void TurnOn_OffPushNotification(string pDeviceID, int pProfileID, int pAppID, bool pIsPushNotify)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_OnOff_PushNotification", sqlCon);
                sqlCmd.Parameters.AddWithValue("@Device_ID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@Profile_ID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@App_ID", pAppID);
                sqlCmd.Parameters.AddWithValue("@IsSendPushNotification", pIsPushNotify);
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

        #endregion

        public static string GetVerticalNameByProfileID(int pProfileID)
        {
            string verticalName = "USPD";
            DataTable vtable = new DataTable("getverticalname");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetVerticalNameByPID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@PID", pProfileID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                if (vtable.Rows.Count > 0)
                {
                    verticalName = Convert.ToString(vtable.Rows[0]["Vertical_Name"]);
                }
                return verticalName;
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

        public static string ValidateMobileAppPin(string pAppName, string pPin)
        {
            string result = "";
            DataTable vtable = new DataTable("validatepin");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_ValidateAppPin", sqlCon);
                sqlCmd.Parameters.AddWithValue("@App_Name", pAppName);
                sqlCmd.Parameters.AddWithValue("@Password", pPin);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                int value = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (value > 0)
                {
                    result = "SUCCESS";
                }
                else
                {
                    result = "FAIL";
                }
                return result;
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
        public static string GetOn_OffPushNotification(string pDeviceID, int pProfileID, int pAppID)
        {
            string result = "True";
            DataTable vtable = new DataTable("GetPushNotificationSetting");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetOn_OffPushNotification", sqlCon);
                sqlCmd.Parameters.AddWithValue("@Device_ID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@Profile_ID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@App_ID", pAppID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable.Rows.Count > 0)
                {
                    result = Convert.ToString(vtable.Rows[0]["IsSendPushNotification"]);
                }
                return result;
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

        public static DataTable GetBrandedAppProfileIDs(string pAppName)
        {

            DataTable vtable = new DataTable("brandedAppPIDs");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("m_usp_GetBrandedAppProfileIDs", sqlCon);
                sqlCmd.Parameters.AddWithValue("@AppName", pAppName);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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


        //----
        public static DataTable GetActiveSurveys(int pProfileID)
        {
            DataTable dtActiveSurvey = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_M_GetMangeSurveys", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtActiveSurvey);
                return dtActiveSurvey;
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

        public static DataTable GetActiveQuestions(int pSID)
        {
            DataTable dtActiveQuestion = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_M_GetQuestionsBySurveyID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SurveyID", pSID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtActiveQuestion);
                return dtActiveQuestion;
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

        public static DataTable GetSurveyAnswers(int pQID, string pDeviceID, string pDeviceType, int pAppID)
        {
            DataTable dtAnswers = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetSurveyAnswers", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@QuestionID", pQID);
                sqlCmd.Parameters.AddWithValue("@Device_ID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@Device_Type", pDeviceType);
                sqlCmd.Parameters.AddWithValue("@AppID", pAppID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtAnswers);
                return dtAnswers;
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

        public static int InsertSurveyAnswers(int pQID, int pOptionID, string pAnswer, string pDeviceID, string pDeviceType, int pAppID, int pSurveyID)
        {
            int answerID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_InsertSurveyAnswers", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@QuestionID", pQID);
                sqlCmd.Parameters.AddWithValue("@OptionID", pOptionID);
                sqlCmd.Parameters.AddWithValue("@Answer", pAnswer);
                sqlCmd.Parameters.AddWithValue("@Device_ID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@Device_Type", pDeviceType);
                sqlCmd.Parameters.AddWithValue("@AppID", pAppID);
                sqlCmd.Parameters.AddWithValue("@SurveyID", pSurveyID);
                Convert.ToInt32(sqlCmd.ExecuteScalar());
                return answerID;
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

        public static void DeleteSurveyAnswers(int pQID, string pDeviceID, string pDeviceType, int pAppID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_DeleteSurveyAnswers", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@QuestionID", pQID);
                sqlCmd.Parameters.AddWithValue("@Device_ID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@Device_Type", pDeviceType);
                sqlCmd.Parameters.AddWithValue("@AppID", pAppID);
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

        public static DataTable GetSurveyStatusBySurveyID(int pSurveyID, string pDeviceID, string pDeviceType, int pAppID)
        {
            DataTable DtSurveyCompletedDetails = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_SurveyStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Device_ID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@Device_Type", pDeviceType);
                sqlCmd.Parameters.AddWithValue("@AppID", pAppID);
                sqlCmd.Parameters.AddWithValue("@SurveyID", pSurveyID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(DtSurveyCompletedDetails);
                return DtSurveyCompletedDetails;
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

        public static void InsertSurveyStatusfromDevice(int pSurveyID, string pDeviceID, string pDeviceType, int pAppID, bool pIsCompleted)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_InsertSurveyStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Device_ID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@Device_Type", pDeviceType);
                sqlCmd.Parameters.AddWithValue("@AppID", pAppID);
                sqlCmd.Parameters.AddWithValue("@SurveyID", pSurveyID);
                sqlCmd.Parameters.AddWithValue("@Status", pIsCompleted);
                Convert.ToInt32(sqlCmd.ExecuteNonQuery());
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

        public static DataTable GetCustomMessagesByPID(int pProfileID, string pMessageType)
        {
            DataTable dtCustomMessages = new DataTable("CustomMessage");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetCustomMessagesByPID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@Type", pMessageType);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtCustomMessages);
                return dtCustomMessages;
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

        // 06/05/2014
        public static DataTable GetWeblinksCategories(int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetWebLinksCategories", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pProfileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dt);
                return dt;
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

        public static DataTable GetWeblinksByCatID(int pCatID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetWebLinksByCatID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CatID", pCatID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dt);
                return dt;
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

        // BUES Means:: Bulletins, Updates, Events, Surveys
        public static DataTable GetPushNotifyDetails_BUES(int pProfileID, int pTypeID, string pTypName, string pDeviceID, int pAppID)
        {
            DataTable dtDetails = new DataTable("details");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetPushNotifyDetails_BUE", sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@TypeName", pTypName);
                sqlCmd.Parameters.AddWithValue("@TypeID", pTypeID);
                sqlCmd.Parameters.AddWithValue("@DeviceID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@AppID", pAppID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtDetails);

                return dtDetails;
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
        public static string GetPushTypeTabName(int profileID, string pushType, int pushID)
        {
            string tabName = "";
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPushTypeTabName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@PushType", pushType);
                sqlCmd.Parameters.AddWithValue("@PushTypeID", pushID);
                tabName = Convert.ToString(sqlCmd.ExecuteScalar());
                return tabName;
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
