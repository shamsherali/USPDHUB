using System;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class BusinessUpdatesDAL : DataAccess
    {
        public static DataTable GetAllBusinessUpdates(int profileid)
        {
            DataTable dtinv = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllBusinessUpdates", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@profileid", profileid);

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

        public static DataTable GetActiveBusinessUpdates(int profileid)
        {
            DataTable dtinv = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetActiveBusinessUpdates", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@profileid", profileid);

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

        //-----------------------Inserting new business update record------------------------------------------------------------------

        public static int InsertBusinessUpdateDetails(int updateID, int profileID, string title, string businessType, bool status, string businessdesc,
            string updateName)
        {
            int returnval = 1;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertBusinessUpdateDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UpdateId", updateID);
                sqlCmd.Parameters.AddWithValue("@Profileid", profileID);
                sqlCmd.Parameters.AddWithValue("@updateText", businessdesc);
                sqlCmd.Parameters.AddWithValue("@updateType", businessType);
                sqlCmd.Parameters.AddWithValue("@updateTitle", title);
                sqlCmd.Parameters.AddWithValue("@UpdateName", updateName);
                sqlCmd.Parameters.AddWithValue("@status", status);
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
        //----------editing business udpates---------------

        public static DataTable UpdateBusinessUpdateDetails(int updateID)
        {
            DataTable vtable = new DataTable("UpdateId");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBusinessUpdateWithUpdateId", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UpdateId", updateID);

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





        //--------------ends editing business updates---------------------

        public static int DeleteBusinessUpdateDetails(int updateId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 1;
            try
            {

                SqlCommand sqlCmd = new SqlCommand("usp_Delete_BusinessUpdateDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UpdateId", updateId);
                sqlCmd.ExecuteNonQuery();
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


        public static DataTable UpdateBusinessUpdatesText(int updateId)
        {
            DataTable vtable = new DataTable("UpdateId");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUpdateBusinessUpdatesText", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UpdateId", updateId);

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
        public static int StatusBusinessUpdateDetails(int updateId, bool statusChg)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 1;
            try
            {

                SqlCommand sqlCmd = new SqlCommand("usp_StatusChg_BusinessUpdateDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UpdateId", updateId);
                sqlCmd.Parameters.AddWithValue("@Status", statusChg);
                sqlCmd.ExecuteNonQuery();
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

        // --------------------------------- Adding Contact Management to BusinessUpdate Module -----------------------------------//


        public static int InsertBusinessUpdateScheduleDetails(int businessUpdateID, int senderProfileID, int senderUserID, string businessUpdateSubject, string receiverEmailID, DateTime sendingDate, DateTime scheduleDate, int sentFlag, bool isToday, bool contactuschecked, string shareUpdate, int id, int verticalID)
        {
            int scheduleID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertBusinessUpdateSchduleDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BusinessUpdateId", businessUpdateID);
                sqlCmd.Parameters.AddWithValue("@SenderProfileID", senderProfileID);
                sqlCmd.Parameters.AddWithValue("@SenderUserID", senderUserID);
                sqlCmd.Parameters.AddWithValue("@BusinessUpdateSubject", businessUpdateSubject);
                sqlCmd.Parameters.AddWithValue("@ReceiverEmailID", receiverEmailID);
                sqlCmd.Parameters.AddWithValue("@SendingDate", sendingDate);
                sqlCmd.Parameters.AddWithValue("@ScheduleDate", scheduleDate);
                sqlCmd.Parameters.AddWithValue("@SentFlag", sentFlag);
                sqlCmd.Parameters.AddWithValue("@IsToday", isToday);
                sqlCmd.Parameters.AddWithValue("@Contactuschecked", contactuschecked);
                sqlCmd.Parameters.AddWithValue("@ShareUpdate", shareUpdate);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.Parameters.AddWithValue("@VerticalID", verticalID);
                scheduleID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return scheduleID;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static int CheckforBusinessUpdateSchedule(int userID)
        {
            int checkName = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetSchBusinessUpdateCount", sqlCon);
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
        public static string GetBusinessUpdateMaxScheduleingDate(int userID)
        {
            string schDate = string.Empty;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBusinessUpdateMaxSchedulingDate", sqlCon);
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
        public static void CancelBusinessUpdateCampaign(int businessUpdateID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CancelBusinessUpdateCampaign", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchHisID", businessUpdateID);
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
        public static void UpdateBusinessUpdateUsageByUserID(int userID, DateTime usageDate)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_UpdateBusinessUpdateDayLimitCount";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@UsageDate", usageDate);
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
        public static DataTable GetCampaignBusinessDetailsByDates(int businessUpdateID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetScheduledBusinessUpdateDetailsbyScheduledID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchHisID", businessUpdateID);
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
        public static int GetBusinessupdateCountforDayforUserDateAndUpdateID(int userID, DateTime sendingDate, int businessUpdateID)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBusinessUpdateCountforDayandUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@Date", sendingDate);
                sqlCmd.Parameters.AddWithValue("@SchID", businessUpdateID);
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

        public static int UnsubscribeBusinessUpdateForSchMasterHisIDandUserID(int businessUpdateID, int userID, string userEmail)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UnSubscribeBusinessEmail", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@SchHisID", businessUpdateID);
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

        public static int GetOptCountForBusinessUpdateHisID(int businessUpdateID, int userID)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllOptoutsCountforBusinessUpdateMasterID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@SchHisID", businessUpdateID);
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
        public static void UpdateBusinessUpdateMasterSentCount(int userID, int businessUpdateID, int totalCount, int selectedCount, DateTime sendingDate, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_UpdateMasterBusinessUpdateSchCount";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchHisID", businessUpdateID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@TotalCount", totalCount);
                sqlCmd.Parameters.AddWithValue("@SelectedCount", selectedCount);
                sqlCmd.Parameters.AddWithValue("@SentDate", sendingDate);
                sqlCmd.Parameters.AddWithValue("@ID", id);
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
        public static int CheckBusinessUpdatesSendingCountforSendingDate(int userID, DateTime businessUpdateSendingDate)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckEmailsCountOnSendingDateForBusinessUpdate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SendingDate", businessUpdateSendingDate);
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
        public static void UpdateBusinessUpdateSendingDate(int businessUpdateID, DateTime sendindDate)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateBusinessUpdateSendingDate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BusinessUpdateId", businessUpdateID);
                sqlCmd.Parameters.AddWithValue("@SendingDate", sendindDate);
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

        public static int CheckBusinessUpdateCampaignCount(int businessUpdateID)
        {
            int checkName = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBusinessUpdateCampaignCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BusinessUpdateHisID", businessUpdateID);
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

        public static DataTable GetBusinessUpdateDetailsByBusinessUpdateID(int businessUpdateID)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBusinessUpdateMasterDetailsByBusinessUpdateID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BusinessUpdateID", businessUpdateID);
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

        public static int CheckForUnsentBusinessUpdateEmailsforDelete(int businessUpdateID, int userID)
        {
            int checkName = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckUnsentEmailsforBusinessUpdateDelete", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BusinessUpdateID", businessUpdateID);
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

        public static int GetMaxBusinessUpdateUpdateID()
        {
            int checkName = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetMaxBusinessUpdateIDForBusinessUpdate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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

        // --------------------------------- Adding Contact Management to BusinessUpdate Module -----------------------------------//

        // To Get Opt Out Count Business Update Count
        public static DataTable GetOptOutCountForUpdateID(int businessUpdateID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetOptOutCountForBusinessUpdates", sqlCon);
                sqlCmd.Parameters.AddWithValue("@UpdateId", businessUpdateID);
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

        // ------------------------------- User Mail Opened ------------------------------
        public static int GetOpenedMailsForID(int moduleID, int userID, string mailType)
        {
            int count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetOpenedMailsForID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ModuleID", moduleID);
                sqlCmd.Parameters.AddWithValue("@MailType", mailType);
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
        public static DataTable GetOpenedMailsForUpdateID(int mailID, string mailType)
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


        public static DataTable GetTop1ProfileBusinessUpdatesInfoByProfileID(int profileID)
        {
            DataTable user = new DataTable("BusinessUpdatesInfo");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetTOP1ProfileBusinessUpdatesInfoByProfileID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
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


        //Active Business Updates Count

        public static int GetActiveBusinessUpdatesCount(int profileid)
        {
            DataTable vtable = new DataTable("ActiveBusinessUpdates");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetActiveBusinessUpdatesCountByProfileId", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@profileid", profileid);
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


        //issue 1095

        public static int UpdateBusinessUpdateStatus(int updateId, bool status, int profileId, int id)
        {
            int returnval = 1;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_UpdateBusinessUpdateStatus", sqlCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@UpdateId", updateId);
                sqlCmd.Parameters.AddWithValue("@Status", status);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
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

        // *** Issue 1247 *** //
        public static DataTable GetBusinessUpdateDetailsBySchID(int schID)
        {
            DataTable user = new DataTable("BusinessUpdatesInfo");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBusinessUpdateDetailsBySchID", sqlCon);
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
        public static int InsertBusinessUpdateDetailsNew(int updateId, int profileid, string title, bool status, string businessdesc, string updateName,
            bool progressLevel, bool isPublic, int id, DateTime? pPublishDate, string pEditHtml, int? publishedBy, string pListDescription,
            DateTime? pExDate, bool pIsCall, bool pIsContactUs, bool pIsDesktopPOC = false)
        {
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertBusinessUpdateDetailsNew", sqlCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@UpdateId", updateId);
                sqlCmd.Parameters.AddWithValue("@Profileid", profileid);
                sqlCmd.Parameters.AddWithValue("@updateText", businessdesc);
                sqlCmd.Parameters.AddWithValue("@updateTitle", title);
                sqlCmd.Parameters.AddWithValue("@UpdateName", updateName);
                sqlCmd.Parameters.AddWithValue("@status", status);
                sqlCmd.Parameters.AddWithValue("@IsPublished", progressLevel);
                sqlCmd.Parameters.AddWithValue("@IsPublic", isPublic);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.Parameters.AddWithValue("@Publish_Date", pPublishDate);
                sqlCmd.Parameters.AddWithValue("@EditHTML", pEditHtml);
                sqlCmd.Parameters.AddWithValue("@Published_By", publishedBy);
                sqlCmd.Parameters.AddWithValue("@ListDescription", pListDescription);
                sqlCmd.Parameters.AddWithValue("@ExDate", pExDate);
                sqlCmd.Parameters.AddWithValue("@IsCall", pIsCall);
                sqlCmd.Parameters.AddWithValue("@IsContactUs", pIsContactUs);
                sqlCmd.Parameters.AddWithValue("@IsDesktopPOC", pIsDesktopPOC);
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

        public static DataSet GetUpdatesCounts(int updateID, int flag, int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetUpdatesCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UpdateId", updateID);
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

        public static DataTable GetSendUpdatesByProfileID(int profileID)
        {
            DataTable dtCoupons = new DataTable();
            SqlConnection objcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand objcmd = new SqlCommand();
                objcmd.Connection = objcon;
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.CommandText = "Usp_GetSentBusinessUpdates";
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
        // *** Get Update Schedule Emails Count *** //
        public static DataTable CheckBusinessUpdateCampaignCountByID(int updateID, string moduleType)
        {
            DataTable dtSchUpdates = new DataTable();
            SqlConnection objcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand objcmd = new SqlCommand();
                objcmd.Connection = objcon;
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.CommandText = "Usp_GetSchedulesEmailsByUpateID";
                objcmd.Parameters.AddWithValue("@UpdateID", updateID);
                objcmd.Parameters.AddWithValue("@ModuleType", moduleType);
                SqlDataAdapter daUpdates = new SqlDataAdapter(objcmd);
                daUpdates.Fill(dtSchUpdates);
                return dtSchUpdates;

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

        public static bool CheckUpdateNameAvailable(string updateName, int userID)
        {
            bool checkCampaignName = false;
            using (SqlConnection conn = ConnectionManager.Instance.GetSQLConnection())
            {
                using (SqlCommand cmd = new SqlCommand("usp_CheckUpdateNameAvailable", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Update_Name", updateName);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    try
                    {
                        checkCampaignName = Convert.ToBoolean(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        ConnectionManager.Instance.ReleaseSQLConnection(conn);
                    }
                }
            }
            return checkCampaignName;
        }

        public static int CopyUpdateDetails(int senderUserID, int oldUpdateId, string updateName)
        {
            int currentUpdateID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlComd = new SqlCommand("Usp_CopyUpdateDetails", sqlCon);
                sqlComd.CommandType = CommandType.StoredProcedure;
                sqlComd.Parameters.AddWithValue("@Sender_UserID", senderUserID);
                sqlComd.Parameters.AddWithValue("@OldUpdateId", oldUpdateId);
                sqlComd.Parameters.AddWithValue("@Update_Name", updateName);
                currentUpdateID = Convert.ToInt32(sqlComd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return currentUpdateID;
        }
        public static DataTable GetBouncedEailsForUpdateID(int mailID, string mailType)
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

        public static void UpdatePublishedUpdates(bool flag, int userID, int mUserID, int updateId, DateTime? publishDate, bool isPublished)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdatePublishedUpdates", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Flag", flag);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ModifiedUserID", mUserID);
                sqlCmd.Parameters.AddWithValue("@UpdateId", updateId);
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

        public static DataTable GetUpdates(int userID)
        {
            DataTable dtBulletins = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetUpdates", sqlCon);
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
        public static int UpdateBusinessUpdatesOrder(int updateID, int orderNo, int id)
        {
            int cnt = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateBusinessUpdatesOrder", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UpdateID", updateID);
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
    }
}
