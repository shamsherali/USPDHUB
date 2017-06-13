using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace USPDHUBDAL
{
    public class CommonDAL
    {
        // ***Archive the selected type *** //
        public static void ArchiveSelectedNewsletter(int id, bool archiveFlag, string module, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_ArchiveNewsletterByNewsDetailedID";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.Parameters.AddWithValue("@ArchiveFlag", archiveFlag);
                sqlCmd.Parameters.AddWithValue("@Module", module);
                sqlCmd.Parameters.AddWithValue("@USERID", userID);
                sqlCmd.ExecuteNonQuery();
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
        public static string GetScheduledCount(int DetailID, int flag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetScheduledCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@newsletterdetail_id", DetailID);
                sqlCmd.Parameters.AddWithValue("@flag", flag);
                int ScheduleCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return ScheduleCount.ToString();
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
        public static void RemainingScheduledEmailsCount(int user_id, int profile_id, int TotalEmails, out int RemainingEmailCount)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_RemainingScheduledEmailsCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@user_id", user_id);
                sqlCmd.Parameters.AddWithValue("@profile_id", profile_id);
                sqlCmd.Parameters.AddWithValue("@TotalEmails", TotalEmails);
                sqlCmd.Parameters.Add(new SqlParameter("@totalcount", 0)).Direction = ParameterDirection.Output;
                sqlCmd.ExecuteScalar();
                RemainingEmailCount = Convert.ToInt32(sqlCmd.Parameters["@totalcount"].Value);

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
        public static DataTable GetcontactgroupnameforEmailID(string EmailID, int userID)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetContactgroupforEmailID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailID", EmailID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
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
        public static void AddandUpdateEmaiContacts(string firstname, string lastname, string email, string address, string phone, string description, int userid, int SchID, string EmailType, int ContactID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Add_ContactsEmailDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@firstname", firstname);
                sqlCmd.Parameters.AddWithValue("@lastname", lastname);
                sqlCmd.Parameters.AddWithValue("@email", email);
                sqlCmd.Parameters.AddWithValue("@address", address);
                sqlCmd.Parameters.AddWithValue("@phone", phone);
                sqlCmd.Parameters.AddWithValue("@description", description);
                sqlCmd.Parameters.AddWithValue("@userid", userid);
                sqlCmd.Parameters.AddWithValue("@SchID", SchID);
                sqlCmd.Parameters.AddWithValue("@EmailType", EmailType);
                sqlCmd.Parameters.AddWithValue("@ContactID", ContactID);
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
        public static DataTable SelectEmailContact(int userID, int contactID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection SqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "usp_Select_EmailContacts";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlCmd.Parameters.AddWithValue("@ContactID", contactID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(SqlCmd);
                sqlAdptr.Fill(msgs);

                return msgs;
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(SqlCon);
            }

        }
        public static int DeleteEmailContact(int contactID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DeleteEmailContact", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);
                result = (int)sqlCmd.ExecuteNonQuery();
                sqlCmd.Parameters.Clear();
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
        public static DataTable GetEmailContacts(bool flag, int userID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetEmailContacts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@flag", flag);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
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
        public static void UpdateUserTracking(int SchHisID, string EmailType, string CountryCode, string CountryName, string CityName, string RegionCode, string RegionName, string ZipCode, string Latitude, string Longitude, string IPAddress, string Browser)
        {
            SqlConnection SqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Usp_UpdateUserTracking";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@SchHisID", SchHisID);
                SqlCmd.Parameters.AddWithValue("@EmailType", EmailType);
                SqlCmd.Parameters.AddWithValue("@CountryCode", CountryCode);
                SqlCmd.Parameters.AddWithValue("@CountryName", CountryName);
                SqlCmd.Parameters.AddWithValue("@CityName", CityName);
                SqlCmd.Parameters.AddWithValue("@RegionCode", RegionCode);
                SqlCmd.Parameters.AddWithValue("@RegionName", RegionName);
                SqlCmd.Parameters.AddWithValue("@ZipCode", ZipCode);
                SqlCmd.Parameters.AddWithValue("@Latitude", Latitude);
                SqlCmd.Parameters.AddWithValue("@Longitude", Longitude);
                SqlCmd.Parameters.AddWithValue("@IPAddress", IPAddress);
                SqlCmd.Parameters.AddWithValue("@Browser", Browser);
                SqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(SqlCon);
            }

        }
        public static DataTable GetBulletinCategoriesByVertical(int profileID, bool? contentModule = false)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBulletinCategoriesByVertical", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@ContentModule", contentModule);
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
        public static DataTable GetDomainDetails(string verticalDomain)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetDoaminDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@VerticalDomain", verticalDomain);
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
        public static DataTable GetVerticalConfigsByType(string verticalDomain, string type)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetDomainConfigsByType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@VerticalDomain", verticalDomain);
                sqlCmd.Parameters.AddWithValue("@Type", type);
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
        public static string GetCustomFormHeader(int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCustomFormHeader", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                string formHeader = Convert.ToString(sqlCmd.ExecuteScalar());
                return formHeader;
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
        public static string GetVerticalDomain(string vertical)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetVerticalDomain", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
                string formHeader = Convert.ToString(sqlCmd.ExecuteScalar());
                return formHeader;
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
        public static string GetDomainNameByCountry(int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetDomainNameByCountry", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                string formHeader = Convert.ToString(sqlCmd.ExecuteScalar());
                return formHeader;
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
        public static string GetDomainNameByCountryVertical(string vertical, string country)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetDomainNameByCountryVertical", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                string formHeader = Convert.ToString(sqlCmd.ExecuteScalar());
                return formHeader;
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
        public static string GetVerticalNameByProfileID(int profileID)
        {
            string verticalName = "";
            DataTable vtable = new DataTable("getverticalname");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetVerticalNameByPID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@PID", profileID);
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
        public static void UpdateShortenURl(int insertedID, string shortenUrl, string type)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateShortenURL", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", insertedID);
                sqlCmd.Parameters.AddWithValue("@ShortenUrl", shortenUrl);
                sqlCmd.Parameters.AddWithValue("@Type", type);
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
        public static DateTime GetScheduleDateInPST(int profileID, DateTime dateScheduled)
        {
            DateTime dtSchedule = dateScheduled;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetScheduleDateInPST", sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@DateScheduled", dateScheduled);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                dtSchedule = Convert.ToDateTime(sqlCmd.ExecuteScalar());
                return dtSchedule;
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


        public static void InsertUserActivityLog(string pDescription, string pNavigationLink, int pUserID, int pProfileID, DateTime pCreatedDate, int pCreatedBy)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertUserActivityLog", sqlCon);
                sqlCmd.Parameters.AddWithValue("@Description", pDescription);
                sqlCmd.Parameters.AddWithValue("@NavigationLink", pNavigationLink);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@CreatedDate", pCreatedDate);
                sqlCmd.Parameters.AddWithValue("@CreatedBy", pCreatedBy);
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

        public static DataTable GetContentItems()
        {
            DataTable dtGetShareItems = new DataTable("Notification");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetContentShareItems", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtGetShareItems);
                return dtGetShareItems;
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
        public static void InsertUpdateAutoShareDetails(string contentType, int contentID, int send_Status, DateTime send_Date, string media_Type, int userID)
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
        public static DataTable CheckAutoShareRecordExists(string contentType, int contentId, string contentTitle)
        {
            DataTable dtAutoShareItems = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAutoShareRecordExists", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContentType", contentType);
                sqlCmd.Parameters.AddWithValue("@ContentID", contentId);
                sqlCmd.Parameters.AddWithValue("@ContentTitle", contentTitle);
                SqlDataAdapter daAutoShareItems = new SqlDataAdapter(sqlCmd);
                daAutoShareItems.Fill(dtAutoShareItems);
                return dtAutoShareItems;
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
        public static string GetPlayerVideoById(int videoId)
        {
            string returnval = "";
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetPlayerVideoById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@VideoId", videoId);
                returnval = Convert.ToString(sqlCmd.ExecuteScalar());
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

        public static void UpdateDisplayOrderType(int pProfileID, int pUserModuleID, int pDispalyOrderType, string pButtonType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateDisplayOrderType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", pUserModuleID);
                sqlCmd.Parameters.AddWithValue("@DisplayOrderType", pDispalyOrderType);
                sqlCmd.Parameters.AddWithValue("@ButtonType", pButtonType);
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
        public static List<string> GetHelpSearchDetails(string helpName, bool isLiteversion)
        {
            List<string> empResult = new List<string>();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                //"select Top 10 EmployeeName from Employee where EmployeeName LIKE ''+@SearchEmpName+'%'";
                SqlCommand sqlCmd = new SqlCommand("usp_GetHelpMatchedRecords", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SearchHelpName", helpName);
                sqlCmd.Parameters.AddWithValue("@IsLiteVersion", isLiteversion);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    empResult.Add(dr["Help_Name"].ToString());
                }
                return empResult;
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
        public static string GetHelpNameByID(int helpId)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetHelpNameByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Help_ID", helpId);
                string helpName = Convert.ToString(sqlCmd.ExecuteScalar());
                return helpName;
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
        public static DataTable GetAppDefaultDataForWeb(int profileId, bool isAll, string searchTypes)
        {
            DataTable dtAutoShareItems = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAppDefaultDataForWeb", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@IsAll", isAll);
                sqlCmd.Parameters.AddWithValue("@SearchTypes", searchTypes);
                SqlDataAdapter daAutoShareItems = new SqlDataAdapter(sqlCmd);
                daAutoShareItems.Fill(dtAutoShareItems);
                return dtAutoShareItems;
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
        public static void AddProfileAccessTypes(string message, string messageType, int userId, int profileId, int createdUser)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_AddProfileAccessTypes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Message", message);
                sqlCmd.Parameters.AddWithValue("@MessageType", messageType);
                sqlCmd.Parameters.AddWithValue("@UserId", userId);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", createdUser);
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
        public static DataTable GetProfileAccessTypes(int profileId, string messageType)
        {
            DataTable dtAutoShareItems = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetProfileAccessTypes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@MessageType", messageType);
                SqlDataAdapter daAutoShareItems = new SqlDataAdapter(sqlCmd);
                daAutoShareItems.Fill(dtAutoShareItems);
                return dtAutoShareItems;
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
        public static bool CheckUserProfileImage(int profileId, string imgPath)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            bool result = false;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckUserProfileImage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@ImagePath", imgPath);
                result = Convert.ToBoolean(sqlCmd.ExecuteNonQuery());
                sqlCmd.Parameters.Clear();
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
        public static void InsertUserProfileImage(int profileId, int userId, int createdUser, string imgPath, string imgName, string imgDimension)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertUserProfileImages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@UserId", userId);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", createdUser);
                sqlCmd.Parameters.AddWithValue("@ImagePath", imgPath);
                sqlCmd.Parameters.AddWithValue("@ImageName", imgName);
                sqlCmd.Parameters.AddWithValue("@ImageDimension", imgDimension);
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
        public static DataTable GetUserProfileImages(int profileId, string searchImage)
        {
            DataTable dtImages = new DataTable("UserProfileImages");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetUserProfileImages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@SearchImage", searchImage);
                SqlDataAdapter daAutoShareItems = new SqlDataAdapter(sqlCmd);
                daAutoShareItems.Fill(dtImages);
                return dtImages;
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
        public static void DeleteUserProfileImage(int imageId, int modifiedUser)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DeleteUserProfileImage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ImageId", imageId);
                sqlCmd.Parameters.AddWithValue("@ModifiedUser", modifiedUser);
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
        public static DataTable GetCallModuleProfileImages(int userModuleId, string searchImage)
        {
            DataTable dtImages = new DataTable("CallModuleProfileImages");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetCallModuleProfileImages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleId", userModuleId);
                sqlCmd.Parameters.AddWithValue("@SearchImage", searchImage);
                SqlDataAdapter daAutoShareItems = new SqlDataAdapter(sqlCmd);
                daAutoShareItems.Fill(dtImages);
                return dtImages;
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
        public static bool CheckCallModuleProfileImage(int userModuleId, string imgPath)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            bool result = false;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckCallModuleProfileImage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleId", userModuleId);
                sqlCmd.Parameters.AddWithValue("@ImagePath", imgPath);
                result = Convert.ToBoolean(sqlCmd.ExecuteNonQuery());
                sqlCmd.Parameters.Clear();
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
        public static void InsertCallModuleProfileImage(int usermoduleId, int profileId, int userId, int createdUser, string imgPath, string imgName, string imgDimension)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertCallModuleProfileImages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleId", usermoduleId);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@UserId", userId);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", createdUser);
                sqlCmd.Parameters.AddWithValue("@ImagePath", imgPath);
                sqlCmd.Parameters.AddWithValue("@ImageName", imgName);
                sqlCmd.Parameters.AddWithValue("@ImageDimension", imgDimension);
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
        public static void DeleteCallModuleProfileImage(int imageId, int modifiedUser)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DeleteCallModuleProfileImage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ImageId", imageId);
                sqlCmd.Parameters.AddWithValue("@ModifiedUser", modifiedUser);
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
        #region Demo Videos
        public static DataTable GetAllVideos(string searchVideo, string domainName, int start, int end, string isLiteVersion)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllVideos", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SearchVideo", searchVideo);
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
                sqlCmd.Parameters.AddWithValue("@START", start);
                sqlCmd.Parameters.AddWithValue("@END", end);
                sqlCmd.Parameters.AddWithValue("@IsLiteVersion", isLiteVersion);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dt);
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
        public static void InsertHelpVideoViews(int videoId, int profileId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertHelpVideoViews", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@VideoId", videoId);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
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
        public static DataTable GetLiteVideosByType(string videoType, string domainName)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetLiteVideosByType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@VideoType", videoType);
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dt);
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
        #endregion
        public static void AddCallModuleDefaultImages(int userModuleID, int profileId, int userID, int cUserID, string pModuleType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_AddCallModuleDefaultImages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleID", userModuleID);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CUserID", cUserID);
                sqlCmd.Parameters.AddWithValue("@ModuleType", pModuleType);
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

        public static void Insert_OTP_Logs(string pOTP, int pPID, int pAppID, string pUniqueID, string pMobileNumber,
            string pName, string pEmailID, string pModuleType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_Insert_OTP_Log", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OTP", pOTP);
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                sqlCmd.Parameters.AddWithValue("@AppID", pAppID);
                sqlCmd.Parameters.AddWithValue("@UniqueID", pUniqueID);
                sqlCmd.Parameters.AddWithValue("@MobileNumber", pMobileNumber);
                sqlCmd.Parameters.AddWithValue("@Name", pName);
                sqlCmd.Parameters.AddWithValue("@EmailID", pEmailID);
                sqlCmd.Parameters.AddWithValue("@ModuleType", pModuleType);
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

        public static DataTable GetCountries()
        {
            DataTable dtCountry = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetCountry", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dtCountry);
                return dtCountry;
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

        public static DataTable GetPublicCallAlerts(int profileID)
        {

            DataTable alerts = new DataTable("alerts");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPublicCallAlerts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(alerts);

                return alerts;
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
        public static DataTable GetPrivateCallAlerts(int profileID)
        {

            DataTable alerts = new DataTable("alerts");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPrivateCallAlerts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(alerts);

                return alerts;
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

        public static void InsertExceptionDetails(string errorType, string pPageName, string methodName, string message, string strackTrace,
          string innerException, string data)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertErrorLogDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Type", errorType);
                sqlCmd.Parameters.AddWithValue("@PageName", pPageName);
                sqlCmd.Parameters.AddWithValue("@MethodName", methodName);
                sqlCmd.Parameters.AddWithValue("@Message", message);
                sqlCmd.Parameters.AddWithValue("@StackTrace", strackTrace);
                sqlCmd.Parameters.AddWithValue("@InnerExeception", innerException);
                sqlCmd.Parameters.AddWithValue("@Data", data);
                sqlCmd.Parameters.AddWithValue("@ProjectSource", "Web");
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

        public static DataTable GetCallModuleDefaultitems(string domainName, string pModuleType)
        {
            DataTable dtDafaultCallAddOns = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetCallModuleDefaultItems", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
                sqlCmd.Parameters.AddWithValue("@ModuleType", pModuleType);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dtDafaultCallAddOns);
                return dtDafaultCallAddOns;
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


        public static int InsertUpdatePublicCallIndexData(int CustomID, int ProfileID, int UserID, string Title, string ImageUrls, string MobileNumber, bool IsAutoEmail,
         string Email_Description, string Email_GroupIDs, bool IsAutoTextMessage, string SMS_Description, string SMS_GroupIDs, bool IsGPSInformation, bool IsAllPhoneInformation,
         bool IsActive, int CreatedUser, int ModifyUser, int UserModuleID, bool IsDeleted, bool IsPublish, bool IsPublic, string Email_Subject,
         string SMS_Subject, string Description, string PreviewHtml, bool IsVisible, bool IsInitiatesPhoneCall, bool IsPredefinedMessage, bool IsAnonymous, bool IsUploadImage)
        {
            int customID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertPublicCallIndexData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", CustomID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@Title", Title);
                sqlCmd.Parameters.AddWithValue("@ImageUrls", ImageUrls);
                sqlCmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                sqlCmd.Parameters.AddWithValue("@IsAutoEmail", IsAutoEmail);
                sqlCmd.Parameters.AddWithValue("@Email_Description", Email_Description);
                sqlCmd.Parameters.AddWithValue("@Email_GroupIDs", Email_GroupIDs);
                sqlCmd.Parameters.AddWithValue("@IsAutoTextMessage", IsAutoTextMessage);
                sqlCmd.Parameters.AddWithValue("@SMS_Description", SMS_Description);
                sqlCmd.Parameters.AddWithValue("@SMS_GroupIDs", SMS_GroupIDs);
                sqlCmd.Parameters.AddWithValue("@IsGPSInformation", IsGPSInformation);
                sqlCmd.Parameters.AddWithValue("@IsAllPhoneInformation", IsAllPhoneInformation);
                sqlCmd.Parameters.AddWithValue("@IsActive", IsActive);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", CreatedUser);
                sqlCmd.Parameters.AddWithValue("@ModifyUser", ModifyUser);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);
                sqlCmd.Parameters.AddWithValue("@IsPublish", IsPublish);
                sqlCmd.Parameters.AddWithValue("@IsPublic", IsPublic);
                sqlCmd.Parameters.AddWithValue("@Email_Subject", Email_Subject);
                sqlCmd.Parameters.AddWithValue("@SMS_Subject", SMS_Subject);
                sqlCmd.Parameters.AddWithValue("@Description", Description);
                sqlCmd.Parameters.AddWithValue("@Preview_HTML", PreviewHtml);
                sqlCmd.Parameters.AddWithValue("@IsVisible", IsVisible);
                sqlCmd.Parameters.AddWithValue("@IsInitiatesPhoneCall", IsInitiatesPhoneCall);
                sqlCmd.Parameters.AddWithValue("@IsPredefinedMessage", IsPredefinedMessage);
                sqlCmd.Parameters.AddWithValue("@IsAnonymous", IsAnonymous);
                sqlCmd.Parameters.AddWithValue("@IsUploadImage", IsUploadImage);
                customID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return customID;

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


        public static int InsertUserCustomModules(int ProfileID, int UserID, int createdUser, int module, string appIcon,
            string tabName, bool isActive, DateTime createdDate, DateTime modifyDate, DateTime expiredDate, string pButtonType,
            string purchaseType, string manageUrl, bool isHasChilds, string pAccessType, int pOrderDetailsID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                using (SqlCommand sqlCmd = new SqlCommand("usp_InsertUserCustomModules", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                    sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                    sqlCmd.Parameters.AddWithValue("@CreatedUser", createdUser);
                    sqlCmd.Parameters.AddWithValue("@ModuleID", module);
                    sqlCmd.Parameters.AddWithValue("@appIcon", appIcon);
                    sqlCmd.Parameters.AddWithValue("@tabName", tabName);
                    sqlCmd.Parameters.AddWithValue("@IsActive", isActive);
                    sqlCmd.Parameters.AddWithValue("@createdDate", createdDate);
                    sqlCmd.Parameters.AddWithValue("@modifyDate", modifyDate);
                    sqlCmd.Parameters.AddWithValue("@expiredDate", expiredDate);
                    sqlCmd.Parameters.AddWithValue("@ButtonType", pButtonType);
                    sqlCmd.Parameters.AddWithValue("@PurchaseType", purchaseType);
                    sqlCmd.Parameters.AddWithValue("@ManageUrl", manageUrl);
                    sqlCmd.Parameters.AddWithValue("@IsHasChilds", isHasChilds);
                    sqlCmd.Parameters.AddWithValue("@AccessType", pAccessType);
                    sqlCmd.Parameters.AddWithValue("@OrderDetailsID", pOrderDetailsID);
                    return Convert.ToInt32(sqlCmd.ExecuteScalar());
                }

            }
            catch (Exception ex)
            {
                InsertErrorLog("ERROR", Convert.ToString(ex.Message),
                      Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "CommonDAL", "InsertUserCustomModules");
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static void InsertErrorLog(string pErrorType, string pMessage,
         string pStrackTrace, string pInnerException, string pData, string pPageName, string pMethodName)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertErrorLog", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@LogType", pErrorType);
                sqlCmd.Parameters.AddWithValue("@Message", pMessage);
                sqlCmd.Parameters.AddWithValue("@StackTrace", pStrackTrace);
                sqlCmd.Parameters.AddWithValue("@InnerExpception", pInnerException);
                sqlCmd.Parameters.AddWithValue("@Data", pData);
                sqlCmd.Parameters.AddWithValue("@PageName", pPageName);
                sqlCmd.Parameters.AddWithValue("@MethodName", pMethodName);
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
        public static string GetTabNameByType(int userId, string tabType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetTabNameByType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserId", userId);
                sqlCmd.Parameters.AddWithValue("@TabType", tabType);
                return Convert.ToString(sqlCmd.ExecuteScalar());
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


        public static DataTable GetSystemImages(string ModuleName, string DomainName)
        {
            DataTable dtSysImages = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetSystemImages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ModuleName", ModuleName);
                sqlCmd.Parameters.AddWithValue("@DomainName", DomainName);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dtSysImages);
                return dtSysImages;
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

        public static DataTable GetAllAppMessagesCountForDashboard(int pUserID, int pProfileID)
        {
            DataTable dtCounts = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllAppMessagesCountForDashboard", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dtCounts);
                return dtCounts;
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



        public static void UpdatePrivateQRConnectCreditsReduceUsage(int ProfileID, int usageReduceQuantity)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdatePrivateQRConnectCreditsReduceUsage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@UsageReduceQuantity", usageReduceQuantity);
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


        public static DataTable GetSocialShareDetails(int UserID, string MediaType)
        {
            DataTable dtStatus = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSocialShareDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@MediaType", MediaType);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dtStatus);
                return dtStatus;
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
        public static void UpdateSocialShareStatus(int UserID, int StatusFlag, string MediaType, int ContentID,int SentFlag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateSocialShareStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@MediaType", MediaType);
                sqlCmd.Parameters.AddWithValue("@StatusFlag", StatusFlag);
                sqlCmd.Parameters.AddWithValue("@ContentID", ContentID);
                sqlCmd.Parameters.AddWithValue("@SentFlag", SentFlag);
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
    }
}
