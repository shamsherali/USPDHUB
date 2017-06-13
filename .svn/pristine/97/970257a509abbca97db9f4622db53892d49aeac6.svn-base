using System;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class IRHMServiceDAL
    {
        public static DataTable GetAllCategories()
        {
            DataTable vtable = new DataTable("Categories");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("M_GetAllCategories", sqlCon);
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

        public static DataTable GetSearchResult(string pKeyword, string pCatType, string platitude1, string plongitude1, string pRadius)
        {
            DataTable vtable = new DataTable("Search");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("M_GetSearchResult", sqlCon);
                sqlCmd.Parameters.AddWithValue("@Catname", pCatType.ToLower());
                sqlCmd.Parameters.AddWithValue("@Keyword", pKeyword);
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

        public static DataTable GetMobileAppSetting(int pUserID)
        {
            DataTable dtMSettings = new DataTable("MSettings");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {

                SqlCommand sqlCmd = new SqlCommand("M_GetMobileSettings", sqlCon);
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
                SqlCommand sqlCmd = new SqlCommand("m_GetMapViewDirection", sqlCon);
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
            bool activeflag, int msgID, int userID, int tType, string pSource, string pPhotoName, double pLatitude, double pLongitude, string pAddress)
        {
            DataTable vtable = new DataTable("consumer");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("m_ManageMessages1", sqlCon);
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
                SqlCommand sqlCmd = new SqlCommand("M_GetProfileDetails", sqlCon);
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

        public static DataTable GetProfiledetailsByBCode(string pBCode, int pProfileID, string pType, string latitude2, string longitude2, string radius)
        {
            // 1 means validate b code getting via business details by BCode
            // 2 means getting business details by profile id

            DataTable dtBusinessDetails = new DataTable("ProfileDetailsCode");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("M_GetProfilesDetailsByBCode", sqlCon);
                sqlCmd.Parameters.AddWithValue("@BCode", pBCode);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@Type", pType);
                sqlCmd.Parameters.AddWithValue("@latitude2", latitude2);
                sqlCmd.Parameters.AddWithValue("@longitude2", longitude2);
                sqlCmd.Parameters.AddWithValue("@Radius", radius);
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

        public static string InsertAppDeviceDetails(string pDeviceID, int pProfileID, string pDeviceType, string pBusinessName, string pAddress)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("M_InsertAppDeviceDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Device_ID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@Profile_ID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@Device_Type", pDeviceType);
                sqlCmd.Parameters.AddWithValue("@Business_Name", pBusinessName);
                sqlCmd.Parameters.AddWithValue("@Address", pBusinessName);
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

        public static string DeleteAppDeviceDetails(string pDeviceID, int pProfileID)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("M_DeleteAppDeviceDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Device_ID", pDeviceID);
                sqlCmd.Parameters.AddWithValue("@Profile_ID", pProfileID);
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
        public static DataTable GetDevicesforNotifications(int profileID)
        {
            DataTable dtDevices = new DataTable("devices");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Mob_GetFavoriteDevices", sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
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
        public static void AddPushNotifications(string message, int profileID, int createdUser, int totalDevices, int sentDevices, string deviceIDs, int flag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Mob_AddPushNotifications", sqlCon);
                sqlCmd.Parameters.AddWithValue("@Message", message);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", createdUser);
                sqlCmd.Parameters.AddWithValue("@TotalDevices", totalDevices);
                sqlCmd.Parameters.AddWithValue("@SentDevices", sentDevices);
                sqlCmd.Parameters.AddWithValue("@DeviceIDs", deviceIDs);
                sqlCmd.Parameters.AddWithValue("@Flag", flag);
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
        // *** End push Notifications methods *** //
        #endregion
    }
}
