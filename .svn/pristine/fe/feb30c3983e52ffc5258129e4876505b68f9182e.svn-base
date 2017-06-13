using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
namespace USPDHUBDAL
{
    public class AddOnDAL
    {
        /// <summary>
        /// Gets the data from T_UserCustom_Modules 
        /// </summary>
        /// <param name="customModuleId">contains the user module id passed as refernce to get the values</param>
        /// <returns>table of User custom modules</returns>
        public static DataTable GetAddOnById(int customModuleId)
        {
            DataTable dtBulletinCat = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAddOnById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomModuleId", customModuleId);
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
        /// retrieves the details from T_Manage_CustomModule
        /// </summary>
        /// <param name="userID">passed as a reference, contains user id</param>
        /// <param name="customModuleId">contains custom module id</param>
        /// <returns>Table </returns>
        public static DataTable GetAllManageAddOns(int filter, string category, int userID, int customModuleId)
        {
            DataTable dtManageBulletin = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAllManageAddOns", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Filter", filter);
                sqlCmd.Parameters.AddWithValue("@Category", category);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CustomModuleId", customModuleId);
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
        /// Gets the custom modules based on Id's
        /// </summary>
        /// <param name="customID">passed as reference, contains custom id to retrieve the data</param>
        /// <returns>Table</returns>
        public static DataTable GetCustomModuleByID(int customID)
        {
            DataTable dtBulletin = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetCustomModuleByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", customID);
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
        /// Deletes the custom module based on id
        /// </summary>
        /// <param name="customID">passed as reference, contains id </param>
        public static void DeleteCustomModule(int customID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeleteCustomModule", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", customID);
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
        /// Updates the custom module
        /// </summary>
        /// <param name="flag">flag</param>
        /// <param name="userID">user ID</param>
        /// <param name="mUserID">modified user id</param>
        /// <param name="customID">custom id</param>
        /// <param name="publishDate">passed as reference, contains date of publish</param>
        /// <param name="isPublished">passed as reference, contains true or false</param>
        public static void UpdateCustomModulePublish(bool flag, int userID, int mUserID, int customID, DateTime? publishDate, bool isPublished)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_UpdateCustomModulePublish", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Flag", flag);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ModifiedUserID", mUserID);
                sqlCmd.Parameters.AddWithValue("@CustomID", customID);
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
        /// <summary>
        /// updates the order for custom module
        /// </summary>
        /// <param name="customID">contains custom module id</param>
        /// <param name="orderNo">Order No</param>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public static int UpdateOrder(int customID, int orderNo, int id)
        {
            int cnt = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateOrder", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", customID);
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
        /// Gets the published items based on id
        /// </summary>
        /// <param name="userID">contains user id</param>
        /// <param name="customModuleID">contains custom module id</param>
        /// <returns>table</returns>
        public static DataTable GetPublishedItemsByID(int userID, int customModuleID)
        {
            DataTable dtBulletins = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetPublishedItemsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CustomModuleID", customModuleID);
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
        /// Checking the availability of the bulletin when trying to create a new bulletin
        /// </summary>
        /// <param name="userID">user ID</param>
        /// <param name="bulletinName">Name of the bulletin</param>
        /// <param name="type">type(if it is check user tries to create a new bulletin</param>
        /// <param name="customModuleID"></param>
        /// <returns>Data Table</returns>
        public static DataTable CheckAvailability(int userID, string bulletinName, string type, int customModuleID)
        {
            DataTable dtBulletin = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckCMAvailability", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@BulletinName", bulletinName);
                sqlCmd.Parameters.AddWithValue("@Type", type);
                sqlCmd.Parameters.AddWithValue("@CustomModuleID", customModuleID);
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
        ///  Copies the Bulletin
        /// </summary>
        /// <param name="customID">custom is</param>
        /// <param name="bulletinTitle">title of the bulletin</param>
        /// <param name="userID">user id</param>
        /// <param name="cUserID">cuser id</param>
        /// <returns>returns integer value </returns>
        public static int CopyItem(int customID, string bulletinTitle, int userID, int cUserID)
        {
            int copyBulletinID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CopyItem", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", customID);
                sqlCmd.Parameters.AddWithValue("@BulletinTitle", bulletinTitle);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CUserID", cUserID);
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
        /// Gets the scheduled modules count
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="customModuleID">custom module id</param> 
        /// <returns>an integer</returns>
        public static int CheckforItemSchedule(int userID, int customModuleID)
        {
            int checkName = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetSchItemCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CustomModuleID", customModuleID);
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
        /// gets the scheduling date of custom module
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="customModuleID">custom module id</param>
        /// <returns>string containg date </returns>
        public static string GetItemMaxScheduleingDate(int userID, int customModuleID)
        {
            string schDate = string.Empty;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetItemMaxSchedulingDate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CustomModuleID", customModuleID);
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
        /// 
        /// </summary>
        /// <param name="userID">user id </param>
        /// <param name="eventSendingDate">date of sending event</param>
        /// <param name="customModuleID">custom module id</param>
        /// <returns>an integer</returns>
        public static int CheckItemSendingCountforSendingDate(int userID, DateTime eventSendingDate, int customModuleID)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckEmailsCountOnSendingDateForItem", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SendingDate", eventSendingDate);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@customModuleID", customModuleID);
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
        /// inserts the details of scheduled item 
        /// </summary>
        /// <param name="customID">passed as a reference ,contains costom id</param>
        /// <param name="senderProfileID">passed as a reference ,contains profile id of the sender</param>
        /// <param name="senderUserID">passed as a reference ,contains user id of the sender</param>
        /// <param name="schduleBulletinSubject">contans subject of scheduled bulletin</param>
        /// <param name="receiverEmailID">contains email id of receiver</param>
        /// <param name="sendingDate">date of sending</param>
        /// <param name="scheduleDate">date of schedule</param>
        /// <param name="sentFlag">flag</param>
        /// <param name="isToday">contains true or false for the value</param>
        /// <param name="groupID">group id</param>
        /// <param name="contactuschecked">contacts that were checked</param>
        /// <param name="shareBulletin">id</param>
        /// <param name="id">id</param>
        /// <param name="verticalID">vertical id</param>
        /// <param name="storeLinksChecked"></param>
        /// <returns>integer</returns>
        public static int InsertItemScheduleDetails(int customID, int senderProfileID, int senderUserID, string schduleBulletinSubject, string receiverEmailID, DateTime sendingDate, DateTime scheduleDate, int sentFlag, bool isToday, string groupID, bool contactuschecked, string shareBulletin, int id, int verticalID, bool storeLinksChecked)
        {
            int scheduleEventID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertItemScheduleDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", customID);
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
        /// unscbscribung from an item
        /// </summary>
        /// <param name="customID">custom id</param>
        /// <param name="userID">user id</param>
        /// <param name="userEmail">email of the user</param>
        /// <returns>an integer</returns>
        public static int UnsubscribeItemForSchMasterHisIDandUserID(int customID, int userID, string userEmail)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UnSubscribeItemEmail", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@SchHisID", customID);
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
        /// <summary>
        /// cancelling the scheduled item
        /// </summary>
        /// <param name="customID">customer id</param>
        public static void CancelItemCampaign(int customID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CancelItemCampaign", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchHisID", customID);
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
        /// Get the details of scheduled items by custom id 
        /// </summary>
        /// <param name="customID">custom id</param>
        /// <returns>data table</returns>
        public static DataTable GetScheduledDetailsByCustomID(int customID)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetScheduledDetailsByCustomID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", customID);
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
        /// retreiving the campaign item details by dates
        /// </summary>
        /// <param name="customID"> custom id</param>
        /// <returns> data table</returns>
        public static DataTable GetCampaignItemDetailsByDates(int customID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetScheduledItemDetailsbyScheduledID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchHisID", customID);
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
        /// Getting the count of scheduled module items per day and by id 
        /// </summary>
        /// <param name="userID">user idd</param>
        /// <param name="sendingDate">date of sending</param>
        /// <param name="customID">custom id</param>
        /// <returns>An Integer</returns>
        public static int GetItemCountforDayforUserDateAndCustomID(int userID, DateTime sendingDate, int customID)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetItemCountforDayandUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@Date", sendingDate);
                sqlCmd.Parameters.AddWithValue("@SchID", customID);
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
        /// Get the count of sent items based on profile id 
        /// </summary>
        /// <param name="profileID">profle id</param>
        /// <param name="customerModuleID">customer module id</param>
        /// <returns>data table</returns>
        public static DataTable GetSendItemsByProfileID(int profileID, int customerModuleID)
        {
            DataTable dtCoupons = new DataTable();
            SqlConnection objcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand objcmd = new SqlCommand();
                objcmd.Connection = objcon;
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.CommandText = "Usp_GetSentItems";
                objcmd.Parameters.AddWithValue("@profileid", profileID);
                objcmd.Parameters.AddWithValue("@CustomerModuleID", customerModuleID);
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
        /// getting count of optout(sendng of scheduled item) based on customer id
        /// </summary>
        /// <param name="customID">cutomer id</param>
        /// <returns>data table</returns>
        public static DataTable GetOptOutCountForItems(int customID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetOptOutCountForItems", sqlCon);
                sqlCmd.Parameters.AddWithValue("@CustomId", customID);
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
        /// getting count of scheduled custom modules
        /// </summary>
        /// <param name="customID">customid</param>
        /// <param name="flag">flag</param>
        /// <param name="profileID">profileid</param>
        /// <returns>data set</returns>
        public static DataSet GetItemsCount(int customID, int flag, int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetItemsCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomId", customID);
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

        /// <summary>
        /// Getting the details of items by scheduled id
        /// </summary>
        /// <param name="schID">scheduled id</param>
        /// <returns>data table</returns>
        public static DataTable GetItemDetailsBySchID(int schID)
        {
            DataTable user = new DataTable("BusinessUpdatesInfo");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetItemDetailsBySchID", sqlCon);
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
        /// Updating the added item in custom module
        /// </summary>
        /// <param name="profileID">profile id</param>
        /// <param name="userID">user id</param>
        /// <param name="cUserID">cuser id</param>
        /// <param name="customID">custom id</param>
        /// <param name="customModuleId">custom module id</param>
        /// <param name="moduleID">module id</param>
        /// <param name="bulletinTitle">Title of bulletin</param>
        /// <param name="bulletinHtml">html format of bulletin</param>
        /// <param name="bulletinXml">Xml format of bulletin</param>
        /// <param name="isArchive">contains whether the archive id true or false</param>
        /// <param name="isCall">is call</param>
        /// <param name="isPhotoCapture">is photo capture</param>
        /// <param name="isContactUs">is contact us</param>
        /// <param name="expiryDate">date of expiry</param>
        /// <param name="isPublished">contains true or false </param>
        /// <param name="publishDate">date od publish</param>
        /// <param name="publishedBy">published by</param>
        /// <param name="printerHtml">Html format or printing</param>
        /// <param name="customXML">xml format</param>
        /// <param name="listDescription">description list</param>
        /// <returns>Integer</returns>
        public static int AddUpdateItem(int profileID, int userID, int cUserID, int customID, int customModuleId, int moduleID, string bulletinTitle, string bulletinHtml, string bulletinXml,
            bool isArchive, bool isCall, bool isPhotoCapture, bool isContactUs, DateTime? expiryDate, bool isPublished, DateTime? publishDate, int? publishedBy,string categoryName,
            string printerHtml, string customXML, string listDescription)
        {
            int returnID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_AddUpdateItem", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);
                sqlCmd.Parameters.AddWithValue("@User_ID", userID);
                sqlCmd.Parameters.AddWithValue("@Created_User", cUserID);
                sqlCmd.Parameters.AddWithValue("@Custom_ID", customID);
                sqlCmd.Parameters.AddWithValue("@CustomModule_ID", customModuleId);
                sqlCmd.Parameters.AddWithValue("@ModuleID", moduleID);
                sqlCmd.Parameters.AddWithValue("@Bulletin_Title", bulletinTitle);
                sqlCmd.Parameters.AddWithValue("@Bulletin_HTML", bulletinHtml);
                sqlCmd.Parameters.AddWithValue("@Bulletin_XML", bulletinXml);
                sqlCmd.Parameters.AddWithValue("@IsArchive", isArchive);
                sqlCmd.Parameters.AddWithValue("@IsCall", isCall);
                sqlCmd.Parameters.AddWithValue("@IsPhotoCapture", isPhotoCapture);
                sqlCmd.Parameters.AddWithValue("@IsContactUs", isContactUs);
                sqlCmd.Parameters.AddWithValue("@Expiration_Date", expiryDate);
                sqlCmd.Parameters.AddWithValue("@IsPublished", isPublished);
                sqlCmd.Parameters.AddWithValue("@Publish_Date", publishDate);
                sqlCmd.Parameters.AddWithValue("@Published_By", publishedBy);
                sqlCmd.Parameters.AddWithValue("@PrinterHtml", printerHtml);
                sqlCmd.Parameters.AddWithValue("@CustomXML", customXML);
                sqlCmd.Parameters.AddWithValue("@ListDescription", listDescription);
                sqlCmd.Parameters.AddWithValue("@Bulletin_Category", categoryName);
                returnID = Convert.ToInt32(sqlCmd.ExecuteScalar());

                return returnID;
            }
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
        /// get custom modules of a user
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>data table</returns>
        public static DataTable GetUserCustomModules(int userID)
        {
            DataTable user = new DataTable("custommodules");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetUserCustomModules", sqlCon);
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

        /// <summary>
        /// get custom modules of a user based on user moduleid
        /// </summary>
        /// <param name="userModuleID">user module id</param>
        /// <returns>data table</returns>
        public static DataTable GetUserCustomModuleById(int userModuleID)
        {
            DataTable user = new DataTable("custommodule");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetUserCustomModuleById", sqlCon);
                sqlCmd.Parameters.AddWithValue("@CustomModuleId", userModuleID);
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
        /// Updating the app icon for custom module
        /// </summary>
        /// <param name="userModuleID">user module id</param>
        /// <param name="isVisible">is visible</param>
        /// <param name="tabName">name of the tab</param>
        /// <param name="appIcon">app icon</param>
        /// <param name="onlyVisible">oly visible</param>
        /// <param name="cUserID">cUserid</param>
        public static void UpdateCustomModuleIcon(int userModuleID, bool isVisible, string tabName, string appIcon, bool onlyVisible, int cUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_UpdateCustomModuleIcon", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleID", userModuleID);
                sqlCmd.Parameters.AddWithValue("@AppIcon", appIcon);
                sqlCmd.Parameters.AddWithValue("@TabName", tabName);
                sqlCmd.Parameters.AddWithValue("@IsVisible", isVisible);
                sqlCmd.Parameters.AddWithValue("@OnlyVisible", onlyVisible);
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

        /// <summary>
        /// Getting the list of forms that are active
        /// </summary>
        /// <param name="userModuleID">usermoduleid</param>
        /// <param name="customID">custom id</param>
        /// <returns>data table</returns>
        public static DataTable GetActiveForms(int userModuleID, int? customID)
        {
            DataTable user = new DataTable("activeforms");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetActiveForms", sqlCon);
                sqlCmd.Parameters.AddWithValue("@CustomModuleId", userModuleID);
                sqlCmd.Parameters.AddWithValue("@CustomID", customID);
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
        /// Getting the forms other than active forms
        /// </summary>
        /// <param name="userModuleID">user module id</param>
        /// <param name="domainName">name of the domain</param>
        /// <param name="userID">user id</param>
        /// <returns>data table</returns>
        public static DataTable GetRemainingForms(int userModuleID, string domainName, int userID)
        {
            DataTable user = new DataTable("remainingforms");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetRemainingForms", sqlCon);
                sqlCmd.Parameters.AddWithValue("@CustomModuleId", userModuleID);
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
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

        /// <summary>
        /// Inserting purchased forms into T_ManagePurchaseAddOns
        /// </summary>
        /// <param name="formID">form id</param>
        /// <param name="userModuleID">user module iduser module id</param>
        /// <param name="moduleID">module id</param>
        /// <param name="createdUser">created user</param>
        /// <param name="isActive">is active</param>
        public static void InsertPurchasedForms(int formID, int userModuleID, int moduleID, int createdUser, bool isActive)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertPurchasedForms", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", formID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", userModuleID);
                sqlCmd.Parameters.AddWithValue("@ModuleID", moduleID);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", createdUser);
                sqlCmd.Parameters.AddWithValue("@IsActivated", isActive);
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
        /// Getting the custom modules based on userid and user moduleid
        /// </summary>
        /// <param name="userID">userid</param>
        /// <param name="userModuleID">usermoduleid</param>
        /// <returns>dataset</returns>
        public static DataSet GetManageAddOns(int userID, int? userModuleID)
        {
            DataSet user = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetManageAddOns", sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", userModuleID);
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
        /// Updating the order of the app buttons
        /// </summary>
        /// <param name="userModuleID">user module id </param>
        /// <param name="orderNo">order no</param>
        /// <param name="cuserID">cuserid</param>
        /// <returns>An Integer</returns>
        public static int UpdateAppButtnOrder(int userModuleID, int orderNo, int cuserID)
        {
            int cnt = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateAppButtnOrder", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleID", userModuleID);
                sqlCmd.Parameters.AddWithValue("@OrderNo", orderNo);
                sqlCmd.Parameters.AddWithValue("@CUserID", cuserID);
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
        /// Insertig default app buttons
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="domainName">domainName</param>
        /// <param name="cuserID">cuserID</param>
        public static void InsertDefaultAppButtons(int profileID, int userID, string domainName, int cuserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertDefaultAppButtons", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
                sqlCmd.Parameters.AddWithValue("@CUserID", cuserID);
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
        /// getting thedefault button id
        /// </summary>
        /// <param name="domainName">domainName</param>
        /// <param name="buttonType">buttonType</param>
        /// <param name="userID">userID</param>
        /// <returns>data table</returns>
        public static DataTable GetInitialAddOns(string domainName, string buttonType, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable initialAddOns = new DataTable("InitialAddOns");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetInitialAddOns", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
                sqlCmd.Parameters.AddWithValue("@ButtonType", buttonType);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(initialAddOns);
                return initialAddOns;
            }
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
        /// Inserting intital addons
        /// </summary>
        /// <param name="defaultButtonID">defaultButtonID</param>
        /// <param name="moduleID">moduleID</param>
        /// <param name="userID">userID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="cuserID">cuserID</param>
        public static void InsertInitialAddOns(int defaultButtonID, int moduleID, int userID, int profileID, int cuserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertInitialAddOns", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DefaultButtonID", defaultButtonID);
                sqlCmd.Parameters.AddWithValue("@ModuleID", moduleID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CUserID", cuserID);
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
        /// Adding an aditional tab
        /// </summary>
        /// <param name="domainName">domainName</param>
        /// <param name="profileID">profileID</param>
        /// <param name="buttonType">buttonType</param>
        public static void AddAdditionalTab(string domainName, int profileID, string buttonType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_AddAdditionalTab", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ButtonType", buttonType);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
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



        #region ***************************   Call Index Add Ons  *******************************
        /// <summary>
        /// geeting call index modules
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pCustomModuleId">pCustomModuleId</param>
        /// <returns>data able/returns>
        public static DataTable GetAllManageCallIndexAddOns(int pUserID, int pCustomModuleId)
        {
            DataTable dtManageBulletin = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAllManageCallIndexAddOns", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@CustomModuleId", pCustomModuleId);
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
        /// changing the visibility of call module
        /// </summary>
        /// <param name="customId">customId</param>
        /// <param name="modifiedUser">modifiedUser</param>
        /// <returns>integer</returns>
        public static int ChangeCallAddOnVisiblity(int customId, int modifiedUser)
        {
            int _result = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ChangeCallAddOnVisiblity", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", customId);
                sqlCmd.Parameters.AddWithValue("@ModifiedUser", modifiedUser);
                _result = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return _result;

            }
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
        /// getting cal indx groups data
        /// </summary>
        /// <param name="UserModuleID">user moduleid</param>
        /// <returns>data set</returns>
        public static DataSet GetGroupsData(int UserModuleID)
        {
            DataSet dsGroup = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAllGroupNames", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dsGroup);
                return dsGroup;
            }
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
        /// inserting and updating call index data 
        /// </summary>
        /// <param name="CustomID">CustomID</param>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="UserID">UserID</param>
        /// <param name="Title">Title</param>
        /// <param name="ImageUrls">ImageUrls</param>
        /// <param name="MobileNumber">MobileNumber</param>
        /// <param name="IsAutoEmail">IsAutoEmail</param>
        /// <param name="Email_Description">Email_Description</param>
        /// <param name="Email_GroupIDs">Email_GroupIDs</param>
        /// <param name="IsAutoPushNotification">IsAutoPushNotification</param>
        /// <param name="PushNotification_Description">PushNotification_Description</param>
        /// <param name="PushNotification_GroupIDs">PushNotification_GroupIDs</param>
        /// <param name="IsAutoTextMessage">IsAutoTextMessage</param>
        /// <param name="SMS_Description">SMS_Description<param>
        /// <param name="SMS_GroupIDs">SMS_GroupIDs</param>
        /// <param name="IsGPSInformation">IsGPSInformation</param>
        /// <param name="IsAllPhoneInformation">IsAllPhoneInformation</param>
        /// <param name="IsActive">IsActive</param>
        /// <param name="CreatedUser">CreatedUser</param>
        /// <param name="ModifyUser">ModifyUser</param>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <param name="IsDeleted">IsDeleted</param>
        /// <param name="IsPublish">IsPublish</param>
        /// <param name="IsPublic"></param>
        /// <param name="Email_Subject">Email_Subject</param>
        /// <param name="PushNotification_Subject">PushNotification_Subject</param>
        /// <param name="SMS_Subject">SMS_Subject</param>
        /// <param name="Description">Description</param>
        /// <param name="PreviewHtml">PreviewHtml</param>
        /// <param name="IsVisible">IsVisible</param>
        /// <returns>An Integer</returns>
        public static int InsertUpdateCallIndexData(int CustomID, int ProfileID, int UserID, string Title, string ImageUrls, string MobileNumber, bool IsAutoEmail, string Email_Description, string Email_GroupIDs, bool IsAutoPushNotification, string PushNotification_Description, string PushNotification_GroupIDs, bool IsAutoTextMessage, string SMS_Description, string SMS_GroupIDs, bool IsGPSInformation, bool IsAllPhoneInformation, bool IsActive, int CreatedUser, int ModifyUser, int UserModuleID, bool IsDeleted, bool IsPublish, bool IsPublic, string Email_Subject, string PushNotification_Subject, string SMS_Subject, string Description, string PreviewHtml, bool IsVisible, bool IsInitiatesPhoneCall, bool IsPredefinedMessage, bool IsUploadImage)
        {
            int customID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertCallIndexData", sqlCon);
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
                sqlCmd.Parameters.AddWithValue("@IsAutoPushNotification", IsAutoPushNotification);
                sqlCmd.Parameters.AddWithValue("@PushNotification_Description", PushNotification_Description);
                sqlCmd.Parameters.AddWithValue("@PushNotification_GroupIDs", PushNotification_GroupIDs);
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
                sqlCmd.Parameters.AddWithValue("@PushNotification_Subject", PushNotification_Subject);
                sqlCmd.Parameters.AddWithValue("@SMS_Subject", SMS_Subject);
                sqlCmd.Parameters.AddWithValue("@Description", Description);
                sqlCmd.Parameters.AddWithValue("@Preview_HTML", PreviewHtml);
                sqlCmd.Parameters.AddWithValue("@IsVisible", IsVisible);
                sqlCmd.Parameters.AddWithValue("@IsInitiatesPhoneCall", IsInitiatesPhoneCall);
                sqlCmd.Parameters.AddWithValue("@IsPredefinedMessage", IsPredefinedMessage);
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

        /// <summary>
        /// getting the call index buttons
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="userModuleId">userModuleId</param>
        /// <returns>data tablt</returns>
        public static DataTable GetCallIndex_Buttons(int pProfileID, int? userModuleId)
        {
            DataTable dtCallIndex_Buttons = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetCallIndexButtons", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@UserModuleId", userModuleId);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dtCallIndex_Buttons);
                return dtCallIndex_Buttons;
            }
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
        /// Getting privatecall index details based on id
        /// </summary>
        /// <param name="pCustomID">pCustomID</param>
        /// <returns>data table</returns>
        public static DataTable GetCallIndexDetailsByID(int pCustomID)
        {
            DataTable dtCallIndexDetails = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetCallIndexDetailByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", pCustomID);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dtCallIndexDetails);
                return dtCallIndexDetails;
            }
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
        /// deleting private call index item based on customer id
        /// </summary>
        /// <param name="pCustomID"></param>
        public static void DeleteCallIndexItem(int pCustomID, int UserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeleteCallIndexItem", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", pCustomID);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
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
        /// Getting thr group names select for sending invitation
        /// </summary>
        /// <param name="pUserModuleID">pUserModuleID</param>
        /// <param name="pUserID">pUserID</param>
        /// <returns>data table</returns>
        public static DataTable GetGroupNamesForSendInvitation(int pUserModuleID, int pUserID)
        {
            DataTable vtable = new DataTable("vtable");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetGroupNamesForCallIndex", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", pUserModuleID);
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
        /// Geeting the contact details of contacts  for sending invitation
        /// </summary>
        /// <param name="pUserModuleID">pUserModuleID</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pGroupID">pGroupID</param>
        /// <param name="pValue">pValue</param>
        /// <returns>data table</returns>
        public static DataTable GetAllContactsForSendInvitation(int pUserModuleID, int pUserID, string pGroupID, string pValue)
        {
            DataTable vtable = new DataTable("vtable");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetContactsForCallIndex", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@GroupIDs", pGroupID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", pUserModuleID);
                sqlCmd.Parameters.AddWithValue("@VALUE", pValue);
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
        /// Get the groups or privte call index
        /// </summary>
        /// <param name="userModuleId">userModuleId</param>
        /// <returns>data set</returns>
        public static DataSet GetCallIndexGroups(int userModuleId)
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetCallIndexGroups", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleId", userModuleId);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(ds);
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
        /// <summary>
        /// Adding a group
        /// </summary>
        /// <param name="GroupID">GroupID</param>
        /// <param name="GroupName">GroupName</param>
        /// <param name="GroupDescription">GroupDescription</param>
        /// <param name="IsActive">IsActive</param>
        /// <param name="IsDeleted">IsDeleted</param>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="CreatedUser">CreatedUser</param>
        /// <param name="UserID">UserID</param>
        /// <returns>An Integer</returns>
        public static int AddGroup(int GroupID, string GroupName, string GroupDescription, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int CreatedUser, int UserID)
        {
            int groupID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_AddGroup", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@GroupID", GroupID);
                sqlCmd.Parameters.AddWithValue("@GroupName", GroupName);
                sqlCmd.Parameters.AddWithValue("@GroupDescription", GroupDescription);
                sqlCmd.Parameters.AddWithValue("@IsActive", IsActive);
                sqlCmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", CreatedUser);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                groupID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return groupID;
            }
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
        /// Getting the contacts which  are active based on groupid
        /// </summary>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <param name="GroupIDs">GroupIDs</param>
        /// <returns>data table</returns>
        public static DataTable GetActiveContacts(int UserModuleID, string GroupIDs)
        {

            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetActiveContacts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@GroupIDs", GroupIDs);
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
        /// <summary>
        /// for retrieving all contacts
        /// </summary>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <returns></returns>
        public static DataTable GetAllContacts(int UserModuleID)
        {

            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetContacts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);

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
        /// <summary>
        /// Deleting the contact groups
        /// </summary>
        /// <param name="groupIds">groupIds</param>
        public static void DeleteGroups(string groupIds)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeleteGroup", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@GroupIDs", groupIds);
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
        /// Inserting and updating the contacts
        /// </summary>
        /// <param name="contactID">contactID</param>
        /// <param name="FirstName">FirstName</param>
        /// <param name="LastName">LastName</param>
        /// <param name="EmailID">EmailID</param>
        /// <param name="CompanyName">CompanyName</param>
        /// <param name="Address">Address</param>
        /// <param name="City">City</param>
        /// <param name="State">State</param>
        /// <param name="Zipcode">Zipcode</param>
        /// <param name="Landline">Landline</param>
        /// <param name="MobileNumber">MobileNumber</param>
        /// <param name="FaxNumber">FaxNumber</param>
        /// <param name="IsActive">IsActive</param>
        /// <param name="IsDeleted">IsDeleted</param>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="UserID">UserID</param>
        /// <param name="CreatedUser">CreatedUser</param>
        /// <returns>An Integer</returns>
        public static int InsertUpdateContacts(int contactID, string FirstName, string LastName, string EmailID, string CompanyName, string Address, string City, string State, string Zipcode, string Landline, string MobileNumber, string FaxNumber, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int UserID, int CreatedUser, string Position, string Organization, bool IsAllowedToSendIvitation, bool IsEmail_SMS_Unsubscribe)
        {
            int CID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_AddContact", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);
                sqlCmd.Parameters.AddWithValue("@FirstName", FirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", LastName);
                sqlCmd.Parameters.AddWithValue("@EmailID", EmailID);
                sqlCmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                sqlCmd.Parameters.AddWithValue("@Address", Address);
                sqlCmd.Parameters.AddWithValue("@City", City);
                sqlCmd.Parameters.AddWithValue("@State", State);
                sqlCmd.Parameters.AddWithValue("@Zipcode", Zipcode);
                sqlCmd.Parameters.AddWithValue("@Landline", Landline);
                sqlCmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                sqlCmd.Parameters.AddWithValue("@FaxNumber", FaxNumber);
                sqlCmd.Parameters.AddWithValue("@IsActive", IsActive);
                sqlCmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", CreatedUser);
                sqlCmd.Parameters.AddWithValue("@Position", Position);
                sqlCmd.Parameters.AddWithValue("@Organization", Organization);
                sqlCmd.Parameters.AddWithValue("@IsAllowedToSendIvitation", IsAllowedToSendIvitation);
                sqlCmd.Parameters.AddWithValue("@IsEmail_SMS_Unsubscribe", IsEmail_SMS_Unsubscribe);
                CID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return CID;
            }
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
        /// Inserting and assigninng contacts to the group
        /// </summary>
        /// <param name="contactID">contactID</param>
        /// <param name="FirstName">FirstName</param>
        /// <param name="LastName">LastName</param>
        /// <param name="EmailID">EmailID</param>
        /// <param name="CompanyName">CompanyName</param>
        /// <param name="Address">Address</param>
        /// <param name="City">City</param>
        /// <param name="State">State</param>
        /// <param name="Zipcode">Zipcode</param>
        /// <param name="Landline">Landline</param>
        /// <param name="MobileNumber">MobileNumber</param>
        /// <param name="FaxNumber">FaxNumber</param>
        /// <param name="IsActive">IsActive</param>
        /// <param name="IsDeleted">IsDeleted</param>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="UserID">UserID</param>
        /// <param name="CreatedUser">CreatedUser</param>
        /// <param name="groupId">groupId</param>
        /// <returns>An Integer value</returns>
        public static int InsertImportContacts(int contactID, string FirstName, string LastName, string EmailID, string CompanyName, string Address, string City, string State, string Zipcode, string Landline, string MobileNumber, string FaxNumber, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int UserID, int CreatedUser, int groupId, string Title, string Organization)
        {
            int CID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertImportContacts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);
                sqlCmd.Parameters.AddWithValue("@FirstName", FirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", LastName);
                sqlCmd.Parameters.AddWithValue("@EmailID", EmailID);
                sqlCmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                sqlCmd.Parameters.AddWithValue("@Address", Address);
                sqlCmd.Parameters.AddWithValue("@City", City);
                sqlCmd.Parameters.AddWithValue("@State", State);
                sqlCmd.Parameters.AddWithValue("@Zipcode", Zipcode);
                sqlCmd.Parameters.AddWithValue("@Landline", Landline);
                sqlCmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                sqlCmd.Parameters.AddWithValue("@FaxNumber", FaxNumber);
                sqlCmd.Parameters.AddWithValue("@IsActive", IsActive);
                sqlCmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", CreatedUser);
                sqlCmd.Parameters.AddWithValue("@GroupId", groupId);
                sqlCmd.Parameters.AddWithValue("@Title", Title);
                sqlCmd.Parameters.AddWithValue("@Organization", Organization);
                CID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return CID;
            }
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
        /// Assigning group to contacts
        /// </summary>
        /// <param name="assignID">assignID</param>
        /// <param name="GroupID">GroupID</param>
        /// <param name="contactID">contactID</param>
        /// <returns>An Integer</returns>
        public static int AssignGroupContactID(int assignID, int GroupID, int contactID)
        {
            int AssignID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_AssignGroupContact", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Assign_Group_Contact_ID", assignID);
                sqlCmd.Parameters.AddWithValue("@GroupID", GroupID);
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);

                AssignID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return AssignID;
            }
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
        /// Deleting contacts
        /// </summary>
        /// <param name="contactIds">contactIds</param>
        /// <returns>An Integet</returns>
        public static int DeleteContacts(string contactIds)
        {
            int contactID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeleteContacts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactIDs", contactIds);
                contactID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return contactID;

            }
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
        /// Checking the group of contact it is assinged to
        /// </summary>
        /// <param name="contactID">contactID</param>
        /// <param name="GroupID">GroupID</param>
        /// <returns>An Integer</returns>
        public static int CheckAssignGroupToContact(int contactID, int GroupID)
        {
            int assignId = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_CheckAssignGroupToContact", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);
                sqlCmd.Parameters.AddWithValue("@GroupID", GroupID);
                assignId = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return assignId;
            }
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
        /// Searching an email id
        /// </summary>
        /// <param name="searchText">searchText</param>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <returns>data table</returns>
        public static DataTable SearchEmailID(string searchText, int UserModuleID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_SearchContactEmail", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SearchEmail", searchText);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
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

        /// <summary>
        /// Getting groups of all contacts
        /// </summary>
        /// <param name="contactId">contactId</param>
        /// <returns>string</returns>
        public static string GetCallContactGroups(int contactId)
        {
            string groupsList = "";
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetCallContactGroups", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@contactId", contactId);
                groupsList = Convert.ToString(sqlCmd.ExecuteScalar());
                return groupsList;
            }
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
        /// Getting contact groups by groupid
        /// </summary>
        /// <param name="GroupID">GroupID</param>
        /// <returns>data set</returns>
        public static DataSet GetGroupByID(int GroupID)
        {
            DataSet dsGroup = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetGroupDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@GroupID", GroupID);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dsGroup);
                return dsGroup;
            }
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
        /// getting contact by contact id
        /// </summary>
        /// <param name="ContactID">ContactID</param>
        /// <returns>data set</returns>
        public static DataSet GetContactByID(int ContactID)
        {
            DataSet dsContact = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetContactDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactID", ContactID);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dsContact);
                return dsContact;
            }
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
        /// getting call module by id
        /// </summary>
        /// <param name="CustomID">CustomID</param>
        /// <returns>data set</returns>
        public static DataSet GetCallIndexByID(int CustomID)
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetCallIndexDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", CustomID);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(ds);
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
        /// <summary>
        /// for retrieving contacts assigned to group
        /// </summary>
        /// <param name="CustomID">CustomID</param>
        /// <returns></returns>
        public static DataTable GetGroupContactsByID(int CustomID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetGroupContactsById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", CustomID);
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
        /// <summary>
        /// Checking whether the given email exists or not
        /// </summary>
        /// <param name="EmailID">EmailID</param>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <param name="pContactID">pContactID</param>
        /// <returns>An Integeer</returns>
        public static int CheckEmailExists(string EmailID, int UserModuleID, int pContactID, string MobileNumber)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckEmailExists", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailID", EmailID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@ContactID", pContactID);
                sqlCmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                result = Convert.ToInt32(sqlCmd.ExecuteScalar());
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
        /// Updating order number of an callindex
        /// </summary>
        /// <param name="customID">customID</param>
        /// <param name="orderNo">orderNo</param>
        /// <param name="modifiedUserId">modifiedUserId</param>
        public static void UpdateCallAddonOrder(int customID, int orderNo, int modifiedUserId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateCallAddonOrder", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", customID);
                sqlCmd.Parameters.AddWithValue("@OrderNo", orderNo);
                sqlCmd.Parameters.AddWithValue("@ModifiedUserId", modifiedUserId);
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
        /// /getting all call index modules
        /// </summary>
        /// <param name="userModuleId">userModuleId</param>
        /// <returns>data table</returns>
        public static DataTable GetAllCallIndexAddOnsByOrder(int userModuleId)
        {
            DataTable dTCallAddOns = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAllCallIndexAddOnsByOrder", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleId", userModuleId);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dTCallAddOns);
                return dTCallAddOns;
            }
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
        /// Gettind all private call modules buttons
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>data set</returns>
        public static DataSet GetPrivateCallAddOnsButtons(int userID)
        {
            DataSet user = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPrivateCallAddOnsButtons", sqlCon);
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

        /// <summary>
        /// Getting the default items of call modulex
        /// </summary>
        /// <param name="domainName">domainName</param>
        /// <returns></returns>
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

        /// <summary>
        /// Get Active Groups with Including Not Assigned checkbox
        /// </summary>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <returns>DataSet</returns>
        public static DataSet GetCallIndexActiveGroups(int UserModuleID)
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetCallIndexActiveGroups", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleId", UserModuleID);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(ds);
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
        //------------------------------------Public Call AddOns---------------------------------
        #region
        /// <summary>
        /// for inserting public call data
        /// </summary>
        /// <param name="CustomID"></param>
        /// <param name="ProfileID"></param>
        /// <param name="UserID"></param>
        /// <param name="Title"></param>
        /// <param name="ImageUrls"></param>
        /// <param name="MobileNumber"></param>
        /// <param name="IsAutoEmail"></param>
        /// <param name="Email_Description"></param>
        /// <param name="Email_GroupIDs"></param>
        /// <param name="IsAutoPushNotification"></param>
        /// <param name="PushNotification_Description"></param>
        /// <param name="PushNotification_GroupIDs"></param>
        /// <param name="IsAutoTextMessage"></param>
        /// <param name="SMS_Description"></param>
        /// <param name="SMS_GroupIDs"></param>
        /// <param name="IsGPSInformation"></param>
        /// <param name="IsAllPhoneInformation"></param>
        /// <param name="IsActive"></param>
        /// <param name="CreatedUser"></param>
        /// <param name="ModifyUser"></param>
        /// <param name="UserModuleID"></param>
        /// <param name="IsDeleted"></param>
        /// <param name="IsPublish"></param>
        /// <param name="IsPublic"></param>
        /// <param name="Email_Subject"></param>
        /// <param name="PushNotification_Subject"></param>
        /// <param name="SMS_Subject"></param>
        /// <param name="Description"></param>
        /// <param name="PreviewHtml"></param>
        /// <param name="IsVisible"></param>
        /// <param name="IsInitiatesPhoneCall"></param>
        /// <param name="IsPredefinedMessage"></param>
        /// <returns></returns>
        public static int InsertUpdatePublicCallIndexData(int CustomID, int ProfileID, int UserID, string Title, string ImageUrls, string MobileNumber, bool IsAutoEmail,
            string Email_Description, string Email_GroupIDs, bool IsAutoTextMessage, string SMS_Description, string SMS_GroupIDs, bool IsGPSInformation, bool IsAllPhoneInformation,
            bool IsActive, int CreatedUser, int ModifyUser, int UserModuleID, bool IsDeleted, bool IsPublish, bool IsPublic, string Email_Subject,
            string SMS_Subject, string Description, string PreviewHtml, bool IsVisible, bool IsInitiatesPhoneCall, bool IsPredefinedMessage, bool IsAnonymous, bool IsUploadImage, int AppUserAnonymousType,int CategoryID)
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
                sqlCmd.Parameters.AddWithValue("@AppUserAnonymousType", AppUserAnonymousType);
                sqlCmd.Parameters.AddWithValue("@CategoryID", CategoryID);
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
        /// <summary>
        /// retreving public call index details by id
        /// </summary>
        /// <param name="CustomID"></param>
        /// <returns></returns>
        public static DataSet GetPublicCallIndexByID(int CustomID)
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetPublicCallIndexDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", CustomID);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(ds);
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
        /// <summary>
        /// retrieving public call index groups data
        /// </summary>
        /// <param name="UserModuleID"></param>
        /// <returns></returns>
        public static DataSet GetPublicGroupsData(int UserModuleID)
        {
            DataSet dsGroup = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAllPublicCallGroupNames", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dsGroup);
                return dsGroup;
            }
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
        /// checking whether the email exists or not for public call contacts
        /// </summary>
        /// <param name="EmailID"></param>
        /// <param name="UserModuleID"></param>
        /// <param name="pContactID"></param>
        /// <returns></returns>
        public static int CheckEmailExistsForPublicCall(string EmailID, int UserModuleID, int pContactID, string PhoneNumber)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckEmailExistsForPublicCall", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailID", EmailID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@ContactID", pContactID);
                sqlCmd.Parameters.AddWithValue("@MobileNumber", PhoneNumber);
                result = Convert.ToInt32(sqlCmd.ExecuteScalar());
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

        public static string GetCallContactGroupsForPublicCallIndex(int contactId)
        {
            string groupsList = "";
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetCallContactGroupsForPublicCallIndex", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@contactId", contactId);
                groupsList = Convert.ToString(sqlCmd.ExecuteScalar());
                return groupsList;
            }
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
        /// insertinf contact details for public call index
        /// </summary>
        /// <param name="contactID"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="EmailID"></param>
        /// <param name="CompanyName"></param>
        /// <param name="Address"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Zipcode"></param>
        /// <param name="Landline"></param>
        /// <param name="MobileNumber"></param>
        /// <param name="FaxNumber"></param>
        /// <param name="IsActive"></param>
        /// <param name="IsDeleted"></param>
        /// <param name="UserModuleID"></param>
        /// <param name="ProfileID"></param>
        /// <param name="UserID"></param>
        /// <param name="CreatedUser"></param>
        /// <param name="Position"></param>
        /// <param name="Organization"></param>
        /// <param name="IsAllowedToSendIvitation"></param>
        /// <param name="IsEmail_SMS_Unsubscribe"></param>
        /// <returns></returns>
        public static int InsertUpdatePublicCallContacts(int contactID, string FirstName, string LastName, string EmailID, string CompanyName, string Address, string City, string State, string Zipcode, string Landline, string MobileNumber, string FaxNumber, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int UserID, int CreatedUser, string Position, string Organization, bool IsAllowedToSendIvitation, bool IsEmail_SMS_Unsubscribe)
        {
            int CID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_AddContactForPublicCallIndex", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);
                sqlCmd.Parameters.AddWithValue("@FirstName", FirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", LastName);
                sqlCmd.Parameters.AddWithValue("@EmailID", EmailID);
                sqlCmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                sqlCmd.Parameters.AddWithValue("@Address", Address);
                sqlCmd.Parameters.AddWithValue("@City", City);
                sqlCmd.Parameters.AddWithValue("@State", State);
                sqlCmd.Parameters.AddWithValue("@Zipcode", Zipcode);
                sqlCmd.Parameters.AddWithValue("@Landline", Landline);
                sqlCmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                sqlCmd.Parameters.AddWithValue("@FaxNumber", FaxNumber);
                sqlCmd.Parameters.AddWithValue("@IsActive", IsActive);
                sqlCmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", CreatedUser);
                sqlCmd.Parameters.AddWithValue("@Position", Position);
                sqlCmd.Parameters.AddWithValue("@Organization", Organization);
                sqlCmd.Parameters.AddWithValue("@IsAllowedToSendIvitation", IsAllowedToSendIvitation);
                sqlCmd.Parameters.AddWithValue("@IsEmail_SMS_Unsubscribe", IsEmail_SMS_Unsubscribe);
                CID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return CID;
            }
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
        /// assigning group contact id for publioc call
        /// </summary>
        /// <param name="assignID"></param>
        /// <param name="GroupID"></param>
        /// <param name="contactID"></param>
        /// <returns></returns>
        public static int AssignPublicCallIndexGroupContactID(int assignID, int GroupID, int contactID)
        {
            int AssignID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_AssignPublicCallGroupContact", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Assign_Group_Contact_ID", assignID);
                sqlCmd.Parameters.AddWithValue("@GroupID", GroupID);
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);

                AssignID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return AssignID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataSet GetPublicCallIndexGroups(int userModuleId)
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetPublicCallIndexGroups", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleId", userModuleId);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(ds);
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
        /// <summary>
        /// adding group for public call index
        /// </summary>
        /// <param name="GroupID"></param>
        /// <param name="GroupName"></param>
        /// <param name="GroupDescription"></param>
        /// <param name="IsActive"></param>
        /// <param name="IsDeleted"></param>
        /// <param name="UserModuleID"></param>
        /// <param name="ProfileID"></param>
        /// <param name="CreatedUser"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static int AddGroupForPublicCallIndex(int GroupID, string GroupName, string GroupDescription, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int CreatedUser, int UserID)
        {
            int groupID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_AddGroupForPublicCallIndex", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@GroupID", GroupID);
                sqlCmd.Parameters.AddWithValue("@GroupName", GroupName);
                sqlCmd.Parameters.AddWithValue("@GroupDescription", GroupDescription);
                sqlCmd.Parameters.AddWithValue("@IsActive", IsActive);
                sqlCmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", CreatedUser);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                groupID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return groupID;
            }
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
        /// retrieving active contacts for public call Index
        /// </summary>
        /// <param name="UserModuleID"></param>
        /// <param name="GroupIDs"></param>
        /// <returns></returns>
        public static DataTable GetActiveContactsForPublicCall(int UserModuleID, string GroupIDs)
        {

            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetActiveContactsForPublicCallIndex", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@GroupIDs", GroupIDs);
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
        /// <summary>
        /// delete groups by groupid for public call index
        /// </summary>
        /// <param name="groupIds"></param>
        public static void DeleteGroupsForPublicCallIndex(string groupIds)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeleteGroupForPublicCallIndex", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@GroupIDs", groupIds);
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
        /// getting public call index groups by id
        /// </summary>
        /// <param name="GroupID"></param>
        /// <returns></returns>
        public static DataSet GetPublicCallIndexGroupByID(int GroupID)
        {
            DataSet dsGroup = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetPublicCallGroupDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@GroupID", GroupID);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dsGroup);
                return dsGroup;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataSet GetPublicCallIndexContactByID(int ContactID)
        {
            DataSet dsContact = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetPublicCallIndexContactDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactID", ContactID);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dsContact);
                return dsContact;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static int DeletePublicCallIndexContacts(string contactIds)
        {
            int contactID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeletePublicCallIndexContacts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactIDs", contactIds);
                contactID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return contactID;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable SearchPublicCallContactEmail(string searchText, int UserModuleID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_SearchPublicCallContactEmail", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SearchEmail", searchText);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
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

        public static int InsertImportContactsForPublicCall(int contactID, string FirstName, string LastName, string EmailID, string CompanyName, string Address, string City, string State, string Zipcode, string Landline, string MobileNumber, string FaxNumber, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int UserID, int CreatedUser, int groupId, string Title, string Organization)
        {
            int CID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertImportContactsForPublicCall", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);
                sqlCmd.Parameters.AddWithValue("@FirstName", FirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", LastName);
                sqlCmd.Parameters.AddWithValue("@EmailID", EmailID);
                sqlCmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                sqlCmd.Parameters.AddWithValue("@Address", Address);
                sqlCmd.Parameters.AddWithValue("@City", City);
                sqlCmd.Parameters.AddWithValue("@State", State);
                sqlCmd.Parameters.AddWithValue("@Zipcode", Zipcode);
                sqlCmd.Parameters.AddWithValue("@Landline", Landline);
                sqlCmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                sqlCmd.Parameters.AddWithValue("@FaxNumber", FaxNumber);
                sqlCmd.Parameters.AddWithValue("@IsActive", IsActive);
                sqlCmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", CreatedUser);
                sqlCmd.Parameters.AddWithValue("@GroupId", groupId);
                sqlCmd.Parameters.AddWithValue("@Title", Title);
                sqlCmd.Parameters.AddWithValue("@Organization", Organization);
                CID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return CID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetPublicCallIndex_Buttons(int pProfileID, int? userModuleId)
        {
            DataTable dtPublicCallIndex_Buttons = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetPublicCallIndexButtons", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@UserModuleId", userModuleId);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dtPublicCallIndex_Buttons);
                return dtPublicCallIndex_Buttons;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetAllManagePublicCallIndexAddOns(int pUserID, int pCustomModuleId)
        {
            DataTable dtManageBulletin = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAllManagePublicCallIndexAddOns", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@CustomModuleId", pCustomModuleId);
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
        public static DataTable GetAllPublicCallIndexAddOnsByOrder(int userModuleId)
        {
            DataTable dTPublicCallAddOns = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAllPublicCallIndexAddOnsByOrder", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleId", userModuleId);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dTPublicCallAddOns);
                return dTPublicCallAddOns;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetPublicCallIndexDetailsByID(int pCustomID)
        {
            DataTable dtPublicCallIndexDetails = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetPublicCallIndexDetailByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", pCustomID);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dtPublicCallIndexDetails);
                return dtPublicCallIndexDetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static int ChangePublicCallAddOnVisiblity(int customId, int modifiedUser)
        {
            int _result = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ChangePublicCallAddOnVisiblity", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", customId);
                sqlCmd.Parameters.AddWithValue("@ModifiedUser", modifiedUser);
                _result = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return _result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static void DeletePublicCallIndexItem(int pCustomID, int UserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeletePublicCallIndexItem", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", pCustomID);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
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
        public static void UpdatePublicCallAddonOrder(int customID, int orderNo, int modifiedUserId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdatePublicCallAddonOrder", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", customID);
                sqlCmd.Parameters.AddWithValue("@OrderNo", orderNo);
                sqlCmd.Parameters.AddWithValue("@ModifiedUserId", modifiedUserId);
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
        public static DataTable GetPublicCallGroupContactsByID(int CustomID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetPublicCallGroupContactsById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomID", CustomID);
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

        public static DataTable GetPublicCallOnsDetailsByCustomID(int pCustomID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtItems = new DataTable("dtItems");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetPublicCallOnsDetailsByCustomID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@CustomID", pCustomID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtItems);

                return dtItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        // Public Calling User Details When Call
        public static DataTable GetPubliceCallOns_SenderDetails(string pUniqueID, int pAppID, int pPID, int pUserModuleID, int pPushTypeID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtItems = new DataTable("dtItems");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_PublicCallAddOns_SenderDetails", sqlCon);
                sqlCmd.Parameters.AddWithValue("@UniqueID", pUniqueID);
                sqlCmd.Parameters.AddWithValue("@AppID", pAppID);
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", pUserModuleID);
                sqlCmd.Parameters.AddWithValue("@CustomID", pPushTypeID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtItems);

                return dtItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static string GetDomainNameByCountryVertical(string vertical, string country)
        {
            return CommonDAL.GetDomainNameByCountryVertical(vertical, country);
        }

        #endregion

        public static void InsertDefaultContact(int customid, int userid)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertDefaultContact", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomId", customid);
                sqlCmd.Parameters.AddWithValue("@UserID", userid);
                sqlCmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

        }

        public static DataTable GetAppVerionDetailsByUMID(int pUserID, int pProfileID, int pUMID)
        {
            DataTable dtBulletinCat = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAppVersionDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@UMID", pUMID);
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

        // Calling User Details When Call
        public static DataTable GetPrivateCallOns_SenderDetails(string pUniqueID, int pAppID, int pPID, int pUserModuleID, int pPushTypeID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtItems = new DataTable("dtItems");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_PrivateAddOns_SenderDetails", sqlCon);
                sqlCmd.Parameters.AddWithValue("@UniqueID", pUniqueID);
                sqlCmd.Parameters.AddWithValue("@AppID", pAppID);
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", pUserModuleID);
                sqlCmd.Parameters.AddWithValue("@PrivateCallOns_CustomID", pPushTypeID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtItems);

                return dtItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetPrivateCallOnsDetailsByCustomID(int pCustomID, int pPushNotifyID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtItems = new DataTable("dtItems");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetCallOnsDetailsByCustomID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@CustomID", pCustomID);
                sqlCmd.Parameters.AddWithValue("@PushNotifyID", pPushNotifyID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtItems);

                return dtItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetPrivateCallOnsHistoryDetailsByCustomID(int pHistory)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtItems = new DataTable("dtItems");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPrivateCallOnsHistoryDetailsByCustomID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@HistoryID", pHistory);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtItems);

                return dtItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        //Manage Contacts in SmartConnect Popup
        public static DataTable GetSmartConnectContactsbyUserModuleID(int UserModuleID,string SearchText="")
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetSmartConnectContactsbyUserModuleID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@SearchText", SearchText);
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

        public static int CheckPublicAssignGroupToContact(int chkContactId, int groupId, int UserModuleID)
        {
            int assignId = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_CheckPublicAssignGroupToContact", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactID", chkContactId);
                sqlCmd.Parameters.AddWithValue("@GroupID", groupId);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                assignId = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return assignId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        //Manage Contacts in Call Index Popup 
        public static int CheckCallIndexAssignGroupToContact(int chkContactId, int groupId, int UserModuleID)
        {
            int assignId = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_CheckCallIndexAssignGroupToContact", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactID", chkContactId);
                sqlCmd.Parameters.AddWithValue("@GroupID", groupId);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                assignId = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return assignId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetCallIndexContactsbyUserModuleID(int UserModuleID, string SearchText = "")
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetCallIndexContactsbyUserModuleID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@SearchText", SearchText);
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
    

        //SmartConnect - Requires the app user to fill in Name, Phone and Email before submitting message.
        public enum AppUserAnonymousType : int
        {
            AppIdentityMandatory = 111,
            AppIdentityChoose = 112,
            AppAnonymous = 113

        }
    }
}
