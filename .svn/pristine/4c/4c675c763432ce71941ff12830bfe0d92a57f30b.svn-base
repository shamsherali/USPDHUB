using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class BulletinDAL
    {
        /// <summary>
        /// For retrieving Bulletin categories
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="vertical">vertical</param>
        /// <returns>data table</returns>
        public static DataTable GetBulletinCategories(int userID, string vertical)
        {
            DataTable dtBulletinCat = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBulletinCategories", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtBulletinCat);

                return dtBulletinCat;
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
        /// For retrieving Bulletins
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="categoryID">categoryID</param>
        /// <param name="vertical">vertical</param>
        /// <returns>Data table</returns>
        public static DataTable GetBulletins(int userID, int categoryID, string vertical)
        {
            DataTable dtBulletins = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllBulletins", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CategoryID", categoryID);
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtBulletins);
                return dtBulletins;
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
        /// Foe checking the  bulletin
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="bulletinName">bulletinName</param>
        /// <param name="templateBid">templateBid</param>
        /// <param name="type">type</param>
        /// <returns></returns>
        public static DataTable CheckBulletin(int userID, string bulletinName, int templateBid, string type)
        {
            DataTable dtBulletin = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckBulletin", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@BulletinName", bulletinName);
                sqlCmd.Parameters.AddWithValue("@TemplateBID", templateBid);
                sqlCmd.Parameters.AddWithValue("@Type", type);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtBulletin);
                return dtBulletin;
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
        /// For filtering the bulletins
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="category">category</param>
        /// <param name="userID">userID</param>
        /// <returns>data table</returns>
        public static DataTable GetManageBulletins(int filter, string category, int userID)
        {
            DataTable dtManageBulletin = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetManageBulletins", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Filter", filter);
                sqlCmd.Parameters.AddWithValue("@Category", category);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtManageBulletin);
                return dtManageBulletin;
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
        /// For deleting bulletin
        /// </summary>
        /// <param name="bulletinID">bulletinID</param>
        public static void DeleteBulletin(int bulletinID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DeleteBulletin", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BulletinID", bulletinID);
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
        /// For copying Bulletin
        /// </summary>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="bulletinTitle">bulletinTitle</param>
        /// <param name="userID">userID</param>
        /// <returns>integer</returns>
        public static int CopyBulletin(int bulletinID, string bulletinTitle, int userID)
        {
            int copyBulletinID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CopyBulletin", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BulletinID", bulletinID);
                sqlCmd.Parameters.AddWithValue("@BulletinTitle", bulletinTitle);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                object obj = sqlCmd.ExecuteScalar();
                copyBulletinID = Convert.ToInt32(obj.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return copyBulletinID;
        }

        /// <summary>
        /// For renaming the content
        /// </summary>
        /// <param name="contentID">contentID</param>
        /// <param name="contentTitle">contentTitle</param>
        /// <param name="modifiedUser">modifiedUser</param>
        /// <param name="contentType">contentType</param>
        /// <returns>integer</returns>
        public static int RenameContent(int contentID, string contentTitle, int modifiedUser, string contentType,int profileid)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_RenameContent", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContentID", contentID);
                sqlCmd.Parameters.AddWithValue("@ContentTitle", contentTitle);
                sqlCmd.Parameters.AddWithValue("@ModifiedUser", modifiedUser);
                sqlCmd.Parameters.AddWithValue("@ContentType", contentType);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileid);
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

        /// <summary>
        /// For retrieving bulletins by id
        /// </summary>
        /// <param name="bulletinID">bulletinID</param>
        /// <returns>data table</returns>
        public static DataTable GetBulletinByID(int bulletinID)
        {
            DataTable dtBulletin = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBulletinByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BulletinID", bulletinID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtBulletin);
                return dtBulletin;
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
        /// fo getting label data of a bulletin
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetBulletinLabelData()
        {
            DataTable dtLabel = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBulletinLabelData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtLabel);
                return dtLabel;
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
        /// For retrieving bulletin label data by name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>Data Table</returns>
        public static DataTable GetBulletinLabelDataByName(string name)
        {
            DataTable dtLabel = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBulletinLabelDataByName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Name", name);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtLabel);
                return dtLabel;
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
        /// For retrieving bulletin details by id
        /// </summary>
        /// <param name="pBulletinID">pBulletinID</param>
        /// <returns>data table</returns>
        public static DataTable GetBulletinDetailsByID(int pBulletinID)
        {
            DataTable dtBulletins = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBulletinDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Bulletin_ID", pBulletinID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtBulletins);
                return dtBulletins;
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
        /// For Insserting and updating bulletins
        /// </summary>
        /// <param name="pBulletinID">bulletin id</param>
        /// <param name="pTemplateBid">pTemplateBid</param>
        /// <param name="pBulletinTitle">pBulletinTitle</param>
        /// <param name="pBulletinHtml">pBulletinHtml</param>
        /// <param name="pBulletinXml">pBulletinXml</param>
        /// <param name="pCreatedUser">pCreatedUser</param>
        /// <param name="pModifyUser">pModifyUser</param>
        /// <param name="pIsArchive">pIsArchive</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pIsCall">pIsCall</param>
        /// <param name="pIsPhotoCapture">pIsPhotoCapture</param>
        /// <param name="pIsContactUs">pIsContactUs</param>
        /// <param name="pIsPrivate">pIsPrivate</param>
        /// <param name="pExpiryDate">pExpiryDate</param>
        /// <param name="pPublishDate">pPublishDate</param>
        /// <param name="category">category</param>
        /// <param name="isPublic">isPublic</param>
        /// <param name="publishedBy">publishedBy</param>
        /// <param name="printerHtml">printerHtml</param>
        /// <param name="pCustomXML">pCustomXML</param>
        /// <param name="pListDescription">pListDescription</param>
        /// <param name="pIsDesktopPOC">pIsDesktopPOC</param>
        /// <returns>Integer</returns>
        public static int Insert_Update_BulletinDetails(int pBulletinID, int pTemplateBid, string pBulletinTitle, string pBulletinHtml, string pBulletinXml,
            int pCreatedUser, int pModifyUser, bool pIsArchive, int pUserID, int pProfileID, bool pIsCall, bool pIsPhotoCapture, bool pIsContactUs,
            bool pIsPrivate, DateTime? pExpiryDate, DateTime? pPublishDate, string category, bool isPublic, int? publishedBy, string printerHtml,
            string pCustomXML, string pListDescription, bool pIsDesktopPOC = false)
        {
            int bulletinID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_BulletinDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Bulletin_ID", pBulletinID);
                sqlCmd.Parameters.AddWithValue("@Template_BID", pTemplateBid);
                sqlCmd.Parameters.AddWithValue("@Bulletin_Title", pBulletinTitle);
                sqlCmd.Parameters.AddWithValue("@Bulletin_HTML", pBulletinHtml);
                sqlCmd.Parameters.AddWithValue("@Bulletin_XML", pBulletinXml);
                sqlCmd.Parameters.AddWithValue("@Created_User", pCreatedUser);
                sqlCmd.Parameters.AddWithValue("@Modified_User", pModifyUser);
                sqlCmd.Parameters.AddWithValue("@IsArchive", pIsArchive);
                sqlCmd.Parameters.AddWithValue("@User_ID", pUserID);
                sqlCmd.Parameters.AddWithValue("@Profile_ID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@IsCall", pIsCall);
                sqlCmd.Parameters.AddWithValue("@IsPhotoCapture", pIsPhotoCapture);
                sqlCmd.Parameters.AddWithValue("@IsContactUs", pIsContactUs);
                sqlCmd.Parameters.AddWithValue("@IsPrivate", pIsPrivate);
                sqlCmd.Parameters.AddWithValue("@Expiration_Date", pExpiryDate);
                sqlCmd.Parameters.AddWithValue("@Publish_Date", pPublishDate);
                sqlCmd.Parameters.AddWithValue("@Category", category);
                sqlCmd.Parameters.AddWithValue("@IsPublic", isPublic);
                sqlCmd.Parameters.AddWithValue("@Published_By", publishedBy);
                sqlCmd.Parameters.AddWithValue("@PrinterHtml", printerHtml);
                sqlCmd.Parameters.AddWithValue("@CustomXML", pCustomXML);
                sqlCmd.Parameters.AddWithValue("@ListDescription", pListDescription);
                sqlCmd.Parameters.AddWithValue("@IsDesktopPOC", pIsDesktopPOC);
                bulletinID = Convert.ToInt32(sqlCmd.ExecuteScalar());

                return bulletinID;
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
        /// For retrieving bulletins which are active based on profile id
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>Data table</returns>
        public static DataTable GetActiveBulletinsByProfileID(int pProfileID)
        {
            DataTable dtBulletins = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetActiveBulletinsByProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtBulletins);
                return dtBulletins;
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
        /// For retrieving bulletins
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>Data table</returns>
        public static DataTable GetBulletins(int userID)
        {
            DataTable dtBulletins = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBulletins", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtBulletins);
                return dtBulletins;
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
        /// For updating the order of bulletin
        /// </summary>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="orderNo">orderNo</param>
        /// <param name="id">id</param>
        /// <returns>Integer</returns>
        public static int UpdateBulletinsOrder(int bulletinID, int orderNo, int id)
        {
            int cnt = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateBulletinsOrder", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BulletinID", bulletinID);
                sqlCmd.Parameters.AddWithValue("@OrderNo", orderNo);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                cnt = sqlCmd.ExecuteNonQuery();
                return cnt;
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
        /// For updating the published bulletin
        /// </summary>
        /// <param name="flag">flag</param>
        /// <param name="userID">userID</param>
        /// <param name="mUserID">mUserID</param>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="publishDate">publishDate</param>
        /// <param name="isPublished">isPublished</param>
        public static void UpdateBulletinPublish(bool flag, int userID, int mUserID, int bulletinID, DateTime? publishDate, bool isPublished)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateBulletinPublish", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Flag", flag);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ModifiedUserID", mUserID);
                sqlCmd.Parameters.AddWithValue("@BulletinID", bulletinID);
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
        // *** Schedulling bulletins 24-06-2013 *** //

        /// <summary>
        /// for checking whether the bulletin is scheduled or not
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>Integer</returns>
        public static int CheckforBulletinSchedule(int userID)
        {
            int checkName = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetSchBulletinCount", sqlCon);
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

        /// <summary>
        /// For retrieving the scheduled date of a bulletin
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>String</returns>
        public static string GetBulletinMaxScheduleingDate(int userID)
        {
            string schDate = string.Empty;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBulletinMaxSchedulingDate", sqlCon);
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

        /// <summary>
        /// for checking the count of bulletin for sending date
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="eventSendingDate">eventSendingDate</param>
        /// <returns>Integer</returns>
        public static int CheckBulletinSendingCountforSendingDate(int userID, DateTime eventSendingDate)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckEmailsCountOnSendingDateForBulletin", sqlCon);
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

        /// <summary>
        /// for inserting details of scheduling of bulletin
        /// </summary>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="senderProfileID">bulletinID</param>
        /// <param name="senderUserID">senderUserID</param>
        /// <param name="schduleBulletinSubject">schduleBulletinSubject</param>
        /// <param name="receiverEmailID">receiverEmailID</param>
        /// <param name="sendingDate">sendingDate</param>
        /// <param name="scheduleDate">scheduleDate</param>
        /// <param name="sentFlag">sentFlag</param>
        /// <param name="isToday">isToday</param>
        /// <param name="groupID">groupID</param>
        /// <param name="contactuschecked">contactuschecked</param>
        /// <param name="shareBulletin">shareBulletin</param>
        /// <param name="id">id</param>
        /// <param name="verticalID">verticalID</param>
        /// <param name="storeLinksChecked">storeLinksChecked</param>
        /// <returns>Integer</returns>
        public static int InsertBulletinScheduleDetails(int bulletinID, int senderProfileID, int senderUserID, string schduleBulletinSubject, string receiverEmailID, DateTime sendingDate, DateTime scheduleDate, int sentFlag, bool isToday, string groupID, bool contactuschecked, string shareBulletin, int id, int verticalID, bool storeLinksChecked)
        {
            int scheduleEventID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertBulletinScheduleDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BulletinID", bulletinID);
                sqlCmd.Parameters.AddWithValue("@SenderProfileID", senderProfileID);
                sqlCmd.Parameters.AddWithValue("@SenderUserID", senderUserID);
                sqlCmd.Parameters.AddWithValue("@SchduleBulletinSubject", schduleBulletinSubject);
                sqlCmd.Parameters.AddWithValue("@ReceiverEmailID", receiverEmailID);
                sqlCmd.Parameters.AddWithValue("@SendingDate", sendingDate);
                sqlCmd.Parameters.AddWithValue("@ScheduleDate", scheduleDate);
                sqlCmd.Parameters.AddWithValue("@SentFlag", sentFlag);
                sqlCmd.Parameters.AddWithValue("@IsToday", isToday);
                sqlCmd.Parameters.AddWithValue("@Group_ID", groupID);
                sqlCmd.Parameters.AddWithValue("@Contactuschecked", contactuschecked);
                sqlCmd.Parameters.AddWithValue("@ShareBulletin", shareBulletin);
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
     
        /// <summary>
        /// For getting the bulletins selected for campaign based on dates
        /// </summary>
        /// <param name="bulletinID">bulletinID</param>
        /// <returns>Data table</returns>
        public static DataTable GetCampaignBulletinDetailsByDates(int bulletinID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetScheduledBulletinDetailsbyScheduledID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchHisID", bulletinID);
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

        /// <summary>
        /// For cancelling campaignBulletin 
        /// </summary>
        /// <param name="bulletinID">bulletinID</param>
        public static void CancelBulletinCampaign(int bulletinID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CancelBulletinCampaign", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchHisID", bulletinID);
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
        /// For retrieving bulletin details by bulletin id
        /// </summary>
        /// <param name="bulletinID">bulletinID</param>
        /// <returns>data table</returns>
        public static DataTable GetBulletinDetailsByBulletinID(int bulletinID)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBulletinMasterDetailsByBulletinID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BulletinID", bulletinID);
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

        /// <summary>
        /// To get the count  of bulletin for day by user id
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="sendingDate">sendingDate</param>
        /// <param name="bulletinID">bulletinID</param>
        /// <returns>Integer</returns>
        public static int GetBulletinCountforDayforUserDateAndBulletinID(int userID, DateTime sendingDate, int bulletinID)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBulletinCountforDayandUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@Date", sendingDate);
                sqlCmd.Parameters.AddWithValue("@SchID", bulletinID);
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

        /// <summary>
        /// For getting bulletinn details by scheduled id
        /// </summary>
        /// <param name="schID">schID</param>
        /// <returns>Datatable</returns>
        public static DataTable GetBulletinDetailsBySchID(int schID)
        {
            DataTable user = new DataTable("BusinessUpdatesInfo");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBulletinDetailsBySchID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@SchID", schID);
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

        /// <summary>
        /// for unsubscribing bulletin for scheduled id and user id
        /// </summary>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="userID">userID</param>
        /// <param name="userEmail">userEmail</param>
        /// <returns>Integer</returns>
        public static int UnsubscribeBulletinForSchMasterHisIDandUserID(int bulletinID, int userID, string userEmail)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UnSubscribeBulletinEmail", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@SchHisID", bulletinID);
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

        /*********************Entered By Suneel Kumar**************************/
        /// <summary>
        /// For retrieving send bulletins data by profile id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetSendBulletinsByProfileID(int profileID)
        {
            DataTable dtCoupons = new DataTable();
            SqlConnection objcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand objcmd = new SqlCommand();
                objcmd.Connection = objcon;
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.CommandText = "Usp_GetSentBusinessBulletins";
                objcmd.Parameters.AddWithValue("@profileid", profileID);
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

        /// <summary>
        /// For updating business bulletin status
        /// </summary>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="status">status</param>
        /// <param name="profileID">profileIDparam</param>
        /// <param name="id">id</param>
        /// <returns>Integer</returns>
        public static int UpdateBusinessBulletinStatus(int bulletinID, bool status, int profileID, int id)
        {
            int returnval = 1;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_UpdateBusinessBulletinStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BulletinId", bulletinID);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileID);
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

        /// <summary>
        /// for updating business bulletin details
        /// </summary>
        /// <param name="bulletinID">bulletinID</param>
        /// <returns>data table</returns>
        public static DataTable UpdateBusinessBulletinDetails(int bulletinID)
        {
            DataTable vtable = new DataTable("UpdateId");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[usp_GetBusinessBulletinWithBulletinId]", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Bulletin_ID", bulletinID);

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

        /// <summary>
        /// for getting opened mails for bulletinid
        /// </summary>
        /// <param name="mailID">mailID</param>
        /// <param name="mailType">mailType</param>
        /// <returns>Data table</returns>
        public static DataTable GetOpenedMailsForBulletinID(int mailID, string mailType)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetOpenedMailsForUpdateID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@MailID", mailID);
                sqlCmd.Parameters.AddWithValue("@MailType", mailType);
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

        /// <summary>
        /// For getting bulletin count
        /// </summary>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="flag">flag</param>
        /// <param name="profileID">profileID</param>
        /// <returns>data set</returns>
        public static DataSet GetBulletinsCounts(int bulletinID, int flag, int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBulletinsCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UpdateId", bulletinID);
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
        // To Get Opt Out Count Business Update Count
        /// <summary>
        /// for getting Opt Out Count Business Update Count
        /// </summary>
        /// <param name="bulletinID">bulletinID</param>
        /// <returns>data table</returns>
        public static DataTable GetOptOutCountForBulletinID(int bulletinID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetOptOutCountForBulletins", sqlCon);
                sqlCmd.Parameters.AddWithValue("@UpdateId", bulletinID);
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

        /// <summary>
        /// getting business bulletin details by business bulleinid
        /// </summary>
        /// <param name="bulletinID">bulletinID</param>
        /// <returns>data table</returns>
        public static DataTable GetBusinessBulletinDetailsByBusinessBulletinID(int bulletinID)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("[Usp_GetBusinessBulletinMasterDetailsByBusinessBulletinID]", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BulletinID", bulletinID);
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

        /// <summary>
        /// get bounceed emails for bulletinn id
        /// </summary>
        /// <param name="mailID">mailID</param>
        /// <param name="mailType">mailType</param>
        /// <returns>data table</returns>
        public static DataTable GetBouncedEMailsForBulletinID(int mailID, string mailType)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBouncedEmailsForUpdateID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@MailID", mailID);
                sqlCmd.Parameters.AddWithValue("@MailType", mailType);
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
        /****************************Entered By Suneel Kumar**********************************/

        #region Crisis Call Log Master Data ---- Regions & Agency & Officers

        /// <summary>
        /// to get caller agency by pid
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>data table</returns>
        public static DataTable GetCallerAgencyByPID(int pProfileID)
        {
            DataTable dtCallerAgency = new DataTable("calleragency");
            SqlConnection con = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetCallerTypeAgencyByProfileID", con);
                cmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtCallerAgency);
                return dtCallerAgency;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(con);
            }
        }

        /// <summary>
        /// for getting all regions 
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pType">pType</param>
        /// <returns>data table</returns>
        public static DataTable GetAllRegionsByPID(int pProfileID, string pType)
        {
            DataTable dtRegions = new DataTable("regions");
            SqlConnection con = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetAllRegions", con);
                cmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                cmd.Parameters.AddWithValue("@Type", pType);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtRegions);
                return dtRegions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(con);
            }
        }

        /// <summary>
        /// to get officers data by regionn name
        /// </summary>
        /// <param name="pRegionName">pRegionName</param>
        /// <returns>data table</returns>
        public static DataTable GetOfficersByRegionName(string pRegionName)
        {
            DataTable dtOfficer = new DataTable("officers");
            SqlConnection con = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_OfficersByRegionName", con);
                cmd.Parameters.AddWithValue("@Region_Name", pRegionName);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtOfficer);
                return dtOfficer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(con);
            }
        }



        #endregion

        /// <summary>
        /// to get bulletin categories data
        /// </summary>
        /// <param name="pVerticalCode">pVerticalCode</param>
        /// <returns>data table</returns>
        public static DataTable GetBulletinCategoriesData(string pVerticalCode)
        {
            DataTable dtLabel = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetBulletinCategoriesByVerticalName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Vertical", pVerticalCode);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtLabel);
                return dtLabel;
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
        /// For retrieving bulletin details by dates
        /// </summary>
        /// <param name="pFromDate">pFromDate</param>
        /// <param name="pToDate">pToDate</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>data table</returns>
        public static DataTable GetBulletinDetailsByDates(string pFromDate, string pToDate, int pProfileID)
        {
            DataTable dtBulletins = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBulletinDetailsByDates", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@fromDate", pFromDate);
                sqlCmd.Parameters.AddWithValue("@toDate", pToDate);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtBulletins);
                return dtBulletins;
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
        /// For inserting crisis log download details
        /// </summary>
        /// <param name="pStartDate">pStartDate</param>
        /// <param name="pEndDate">pEndDate</param>
        /// <param name="pIsActive">pIsActive</param>
        /// <param name="pUserID">pUserID</param>
        /// <returns>Integer</returns>
        public static int InsertCrisisLogDownloads(DateTime pStartDate, DateTime pEndDate, bool pIsActive, int pUserID)
        {
            int downloadID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertCrisisLogDownloads", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Start_Date", pStartDate);
                sqlCmd.Parameters.AddWithValue("@End_Date", pEndDate);
                sqlCmd.Parameters.AddWithValue("@IsActive", pIsActive);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                downloadID = Convert.ToInt32(sqlCmd.ExecuteScalar());

                return downloadID;
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
        /// Getting crisis log downloads details
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <returns>data table</returns>
        public static DataTable GetCrisiLogDownloads(int pUserID)
        {
            DataTable dtBulletins = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCrisisLogDownloads", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtBulletins);
                return dtBulletins;
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
        /// For getting officers type
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="DepartmentType">DepartmentType</param>
        /// <returns>data table </returns>
        public static DataTable GetOfficerTypes(int pProfileID, string DepartmentType)
        {
            DataTable dtOfficerTypes = new DataTable("dtOfficerTypes");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetOfficerType", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PID", pProfileID);
                cmd.Parameters.AddWithValue("@DepartmentType", DepartmentType);
                SqlDataAdapter adpter = new SqlDataAdapter(cmd);
                adpter.Fill(dtOfficerTypes);
                return dtOfficerTypes;
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
        /// for getting weekly crime details by dates
        /// </summary>
        /// <param name="pFromDate">pFromDate</param>
        /// <param name="pToDate">pToDate</param>
        /// <param name="pPID">pPID</param>
        /// <param name="pStatus">pStatus</param>
        /// <returns>data table</returns>
        public static DataTable GetCrimeWeeklyReportsDetailsByDates(DateTime pFromDate, DateTime pToDate, int pPID, bool pStatus)
        {
            DataTable dtCrimeReportDetails = new DataTable("dtCrime");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetCrimeDetailsReportsByDates", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FromDate", pFromDate);
                cmd.Parameters.AddWithValue("@ToDate", pToDate);
                cmd.Parameters.AddWithValue("@PID", pPID);
                cmd.Parameters.AddWithValue("@Status", pStatus);
                SqlDataAdapter adpter = new SqlDataAdapter(cmd);
                adpter.Fill(dtCrimeReportDetails);
                return dtCrimeReportDetails;
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
        /// For getting blank bulletin template details 
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>data table</returns>
        public static DataTable GetBulletinBlankTemplateDetails(string pProfileID)
        {
            DataTable dtBlankTemp = new DataTable("dtBlankTemp");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetBulletinBlankTemplateDetails", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PID", pProfileID);
                SqlDataAdapter adpter = new SqlDataAdapter(cmd);
                adpter.Fill(dtBlankTemp);
                return dtBlankTemp;
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


        #region POC DAL Methods
        /// <summary>
        /// For getting poc module content history
        /// </summary>
        /// <param name="pPID">pPID</param>
        /// <returns>data table</returns>
        public static DataTable GetPOC_ModuleContentHistory(int pPID)
        {
            DataTable dtModuleHistory = new DataTable("dtModuleHistory");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetPOC_ModuleContentHistory", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PID", pPID);
                SqlDataAdapter adpter = new SqlDataAdapter(cmd);
                adpter.Fill(dtModuleHistory);
                return dtModuleHistory;
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


        #region Favourite

        /// <summary>
        /// For getting favorite categories
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>data table</returns>
        public static DataTable GetFavoriteCategories(int userID)
        {
            DataTable dtBulletinCat = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetFavoriteCategories", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtBulletinCat);

                return dtBulletinCat;
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
        /// Retreiving available favorites
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>data ser</returns>
        public static DataSet GetAvailableFavorites(int userId)
        {
            DataSet dsAddFavs = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAvailableFavorites", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dsAddFavs);
                return dsAddFavs;
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
        /// for adding template to favorites categoery
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="userId">userId</param>
        /// <param name="createduser">createduser</param>
        /// <param name="templateId">templateId</param>
        /// <param name="moduleType">moduleType</param>
        /// <returns>integer</returns>
        public static int AddFavoriteTemplate(int profileId, int userId, int createduser, int templateId, string moduleType)
        {
            int tempfavid = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_AddFavourite", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileId);
                sqlCmd.Parameters.AddWithValue("@UserID", userId);
                sqlCmd.Parameters.AddWithValue("@TemplateID", templateId);
                sqlCmd.Parameters.AddWithValue("@ModuleType", moduleType);
                sqlCmd.Parameters.AddWithValue("@ModifiedUser", createduser);
                tempfavid = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return tempfavid;
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
        /// For retrieving bulletins in favorite categoery
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="categoryId">categoryId</param>
        /// <returns>Data table</returns>
        public static DataTable GetFavoriteBulletins(int userId, int categoryId)
        {
            DataTable dtFavBulletins = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetFavoriteBulletins", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userId);
                sqlCmd.Parameters.AddWithValue("@CategoryId", categoryId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtFavBulletins);
                return dtFavBulletins;
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
        /// For removing favorites list
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns>Datatable</returns>
        public static DataSet GetRemoveFavoritesList(int UserID)
        {
            DataSet dsRemoveFavs = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetRemoveFavoritesList", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dsRemoveFavs);
                return dsRemoveFavs;
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
        /// For removing a template from fvorites category
        /// </summary>
        /// <param name="TemplateId">TemplateId</param>
        public static void RemoveFavoriteTemplate(int TemplateId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_RemoveFavoriteTemplate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@TemplateID", TemplateId);
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

        /// <summary>
        /// For retrieving templates from all categories
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns></returns>
        public static DataSet GetAllCategoryTemplates(int UserID)
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAllCategoryTemplates", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(ds);
                return ds;
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
