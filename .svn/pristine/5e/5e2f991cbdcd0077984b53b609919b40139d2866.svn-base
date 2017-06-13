using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.IO;
using System.Drawing;



namespace UserFormsDAL
{
    public class CommonDAL
    {
        /// <summary>
        /// for deleting user profile images
        /// </summary>
        /// <param name="imageId">imageId</param>
        /// <param name="modifiedUser">modifiedUser</param>
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
        /// <summary>
        /// for checking user's profile image
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="imgPath">imgPath</param>
        /// <returns>boolean</returns>
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
        /// <summary>
        /// inserting user's profile images.
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="userId">userId</param>
        /// <param name="createdUser">createdUser</param>
        /// <param name="imgPath">imgPath</param>
        /// <param name="imgName">imgName</param>
        /// <param name="imgDimension">imgDimension</param>
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
        /// <summary>
        /// for retrieving user profile images
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="searchImage">searchImage</param>
        /// <returns>data table</returns>
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
        /// <summary>
        /// adding access types to profiles
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="messageType">messageType</param>
        /// <param name="userId">userId</param>
        /// <param name="profileId">profileId</param>
        /// <param name="createdUser">createdUser</param>
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
        /// <summary>
        /// retrieving access types for profiles
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="messageType">messageType</param>
        /// <returns>data table</returns>
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
        /// <summary>
        /// for inserting user activity log
        /// </summary>
        /// <param name="pDescription">Description</param>
        /// <param name="pNavigationLink">NavigationLink</param>
        /// <param name="pUserID">UserID</param>
        /// <param name="pProfileID">ProfileID</param>
        /// <param name="pCreatedDate">CreatedDate</param>
        /// <param name="pCreatedBy">CreatedBy</param>
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
        /// <summary>
        /// retrieving header for the custom form.
        /// </summary>
        /// <param name="userID">userid</param>
        /// <returns>string</returns>
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
        /// <summary>
        /// retrieve vertical configs by type
        /// </summary>
        /// <param name="verticalDomain">verticalDomain</param>
        /// <param name="type">type</param>
        /// <returns>data table</returns>
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
        /// <summary>
        /// retrieving domain details
        /// </summary>
        /// <param name="verticalDomain">verticalDomain</param>
        /// <returns>data table</returns>
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
        /// <summary>
        /// getting master menu links
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetMasterMenuLinks()
        {
            DataTable dtinv = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetMasterMenuDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtinv);

                return dtinv;
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
        /// <summary>
        /// getting parent menu links
        /// </summary>
        /// <param name="isLiteVersion">isLiteVersion</param>
        /// <returns>datatable</returns>
        public static DataTable GetParentMenuLinks(bool isLiteVersion)
        {
            DataTable dtinv = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetParentMenuDetails", sqlCon);
                sqlCmd.Parameters.AddWithValue("@IsLiteVersion", isLiteVersion);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtinv);

                return dtinv;
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
        /// <summary>
        /// retrievig help master menu links
        /// </summary>
        /// <param name="isLiteVersion">isLiteVersion</param>
        /// <returns>datatable</returns>
        public static DataTable GetHelpMasterMenuItems(bool isLiteVersion)
        {
            DataTable dtHelpMaster = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllMenuMasterLinks", sqlCon);
                sqlCmd.Parameters.AddWithValue("@IsLiteVersion", isLiteVersion);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtHelpMaster);
                return dtHelpMaster;
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
        /// <summary>
        /// for retrieving helpchildmenu for master id
        /// </summary>
        /// <param name="helpMasterID">helpMasterID</param>
        /// <returns>datatable</returns>
        public static DataTable GetHelpChildMenuForMasterID(int helpMasterID)
        {
            DataTable dtHelpChild = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllMenuChildLinksForMasterID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@MasterID", helpMasterID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtHelpChild);
                return dtHelpChild;
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
        /// <summary>
        /// getting help search details
        /// </summary>
        /// <param name="helpName">help name</param>
        /// <param name="isLiteVersion">isLiteVersion</param>
        /// <returns>list of strings</returns>
        public static List<string> GetHelpSearchDetails(string helpName, bool isLiteVersion)
        {
            List<string> empResult = new List<string>();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetHelpMatchedRecords", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SearchHelpName", helpName);
                sqlCmd.Parameters.AddWithValue("@IsLiteVersion", isLiteVersion);
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
        /// <summary>
        /// get help menu details by helpid
        /// </summary>
        /// <param name="helpID">helpID</param>
        /// <returns>data table</returns>
        public static DataTable GetHelpmenuDetailsbyHelpID(int helpID)
        {
            DataTable dtHelpChild = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetHelpMenuDetailsbyHelpID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@Help_ID", helpID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtHelpChild);
                return dtHelpChild;
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
        /// <summary>
        ///for getting DomainName By Country and Vertical.
        /// </summary>
        /// <param name="vertical">vertical</param>
        /// <param name="country">country</param>
        /// <returns>string</returns>
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
        /// <summary>
        /// for updating shorten URL.
        /// </summary>
        /// <param name="insertedID">insertedID</param>
        /// <param name="shortenUrl">shortenUrl</param>
        /// <param name="type">type</param>
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
        /// <summary>
        /// for retrieving bulletin categories by vertical
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>datatable</returns>
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
        /// <summary>
        /// for checking whether the auto share record exists or not
        /// </summary>
        /// <param name="contentType">contentType</param>
        /// <param name="contentId">contentId</param>
        /// <param name="contentTitle">contentTitle</param>
        /// <returns>data table</returns>
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

        public static DataTable CheckingModuleExists(int pProfileID, string pButtonType)
        {
            DataTable dt = new DataTable("dt");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckingModuleExists", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@ButtonType", pButtonType);
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
       
    }
}
