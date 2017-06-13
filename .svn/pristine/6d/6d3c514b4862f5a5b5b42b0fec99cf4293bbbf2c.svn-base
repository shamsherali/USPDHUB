using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class SocialMediaAutoShareDAL
    {
        public static void InsertFacebookProfileDate(int profileID, int userId, int createduserId, string fbUserName, string fbProfileID, string fbUserAccessToken, string fbAppAcessToken, bool isAutoShare, bool isDefault)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertFacebookData", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AppProfileID", profileID);
                cmd.Parameters.AddWithValue("@AppUserID", userId);
                cmd.Parameters.AddWithValue("@CreateduserId", createduserId);
                cmd.Parameters.AddWithValue("@Username", fbUserName);
                cmd.Parameters.AddWithValue("@ProfileId", fbProfileID);
                cmd.Parameters.AddWithValue("@UserToken", fbUserAccessToken);
                cmd.Parameters.AddWithValue("@AppToken", fbAppAcessToken);
                cmd.Parameters.AddWithValue("@IsAutoShare", isAutoShare);
                cmd.Parameters.AddWithValue("@IsDefault", isDefault);
                cmd.ExecuteNonQuery();
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

        public static void InsertFacebookPagesData(string fbPageID, string fbPageName, string fbProfileID, string extendedPageToken, bool isDefault, int ProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertFBPagesData", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageId", fbPageID);
                cmd.Parameters.AddWithValue("@PageName", fbPageName);
                cmd.Parameters.AddWithValue("@UserId", fbProfileID);
                cmd.Parameters.AddWithValue("@PageToken", extendedPageToken);
                cmd.Parameters.AddWithValue("@IsDefault", isDefault);
                cmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                cmd.ExecuteNonQuery();
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

        public static DataTable GetExistingUserData(int profileID)
        {
            DataTable dtUserData = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetExistingUserData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@profileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtUserData);
                return dtUserData;
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
        public static string GetPageAccessTokenByPageID(string pageId)
        {
            string facebookPageId = string.Empty;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetFbPageAccessTokenByPageId", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FbPageId", pageId);
                facebookPageId = Convert.ToString(sqlCmd.ExecuteScalar());
                return facebookPageId;
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

        public static void InsertTwitterData(string twrToken, string pin, string userName, bool isAutoPost, int userId, int createdUserId, int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertTwitterData", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccessToken", twrToken);
                cmd.Parameters.AddWithValue("@Pin", pin);
                cmd.Parameters.AddWithValue("@TwitterName", userName);
                cmd.Parameters.AddWithValue("@IsAutoPost", isAutoPost);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ProfileID", profileID);
                cmd.Parameters.AddWithValue("@CreatedUserId", createdUserId);
                cmd.ExecuteNonQuery();
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

        public static DataTable GetTwitterDataByUserID(int profileID)
        {
            DataTable dtUserData = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetTwitterDataByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@profileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtUserData);
                return dtUserData;
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

        public static void DeleteSocialMediaData(int userID, string mediaType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_DeleteSocialUserData", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@MediaType", mediaType);
                cmd.ExecuteNonQuery();
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

        public static void SetDefaultFBWall(string ID, bool updateFlag, string type, string pageID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateFlagData", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Flag", updateFlag);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@PageID", pageID);
                cmd.ExecuteNonQuery();
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
        public static void SetDefaultTwitterWall(int userID, bool isAutoShare)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_TwitterUpdateFlagData", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@Flag", isAutoShare);
                cmd.ExecuteNonQuery();
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
        public static DataTable GetSharedMediaHistory(int UserID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_SharedMediaHistory", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
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
