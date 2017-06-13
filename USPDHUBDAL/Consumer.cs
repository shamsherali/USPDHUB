using System;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class Consumer : DataAccess
    {

        public static DataTable ValidateConsumer(string username, string password)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ValidateUser", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@username", username);
                sqlCmd.Parameters.AddWithValue("@password", password);
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
        public static DataTable ValidateUserByDetails(string username)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ValidateUserByDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@username", username);
                //sqlCmd.Parameters.AddWithValue("@firstname", firstname);
                //sqlCmd.Parameters.AddWithValue("@lastname", lastname);
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
        public static int AddConsumer(string username, string password, string email, string firstname, string lastname, string pswdQ1, string pswdA1, string pswdQ2, string pswdA2, int roleId, bool isActive, string addr1, string addr2, string city, string state, string country, string zipcode, string phone, int userid, string status)
        {
            DataTable vtable = new DataTable("consumer");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageUser", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                sqlCmd.Parameters.AddWithValue("@Password", password);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.Parameters.AddWithValue("@FirstName", firstname);
                sqlCmd.Parameters.AddWithValue("@LastName", lastname);
                sqlCmd.Parameters.AddWithValue("@PswdQ1", pswdQ1);
                sqlCmd.Parameters.AddWithValue("@PswdA1", pswdA1);
                sqlCmd.Parameters.AddWithValue("@PswdQ2", pswdQ2);
                sqlCmd.Parameters.AddWithValue("@PswdA2", pswdA2);
                sqlCmd.Parameters.AddWithValue("@RoleId", roleId);
                sqlCmd.Parameters.AddWithValue("@IsActive", isActive);
                sqlCmd.Parameters.AddWithValue("@Address1", addr1);
                sqlCmd.Parameters.AddWithValue("@Address2", addr2);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@State", state);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                sqlCmd.Parameters.AddWithValue("@status", status);
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipcode);
                sqlCmd.Parameters.AddWithValue("@Phone", phone);
                sqlCmd.Parameters.AddWithValue("@UserID", userid);
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
        public static DataTable GetUserDetails(string username, string domainName)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
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
        public static DataTable GetForgotDetails(string username, string domainName)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetForgotDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
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
        public static DataTable GetUserDetailsByID(int userID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserDetailsByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
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
        public static DataTable GetForumUserDetails(string username)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetForumUserDetailsByUsername", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", username);
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
        public static DataTable GetUserMessages(bool top5Flag, int userID, int totypeID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetMessages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@top5flag", top5Flag);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ToTypeID", totypeID);
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
        public static DataTable GetUserSentMessages(bool top5Flag, int userID, int totypeID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSentMessages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@top5flag", top5Flag);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ToTypeID", totypeID);
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
        public static DataTable GetFavorites(bool top5Flag, int userID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetFavorites", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@top5flag", top5Flag);
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
        public static DataTable GetSystemAlerts(bool top5Flag, int userID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSystemAlerts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@top5flag", top5Flag);
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
        public static DataTable GetSavedSearches(bool top5Flag, int userID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSavedSearches", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@top5flag", top5Flag);
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
        public static int DeleteSavedSearches(int msgid)
        {
            DataTable dt = new DataTable("consumer");
            int returnval = 0;
            SqlConnection sqlcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("usp_DeleteSavedMessage", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Saved_ID", msgid);
                SqlDataAdapter sqladptr = new SqlDataAdapter(sqlcmd);
                sqladptr.Fill(dt);
                if (dt != null)
                {
                    returnval = Convert.ToInt32(dt.Rows[0][0]);
                }
                return returnval;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlcon);
            }

        }
        public static int ManageMessage(int toid, int totypeID, int fromID, string subject, string message, int replyid, bool activeflag, int msgID, int userID, int tType, int id)
        {
            DataTable vtable = new DataTable("consumer");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageMessages", sqlCon);
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
        public static int ManageFavoriteDetails(string fname, int profileID, int userid, int ttype, int favoriteID)
        {
            DataTable vtable = new DataTable("consumer");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageFavorites", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@name", fname);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userid);
                sqlCmd.Parameters.AddWithValue("@TType", ttype);
                sqlCmd.Parameters.AddWithValue("@FavoriteID", favoriteID);
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
        public static int ManageSavedSearchDetails(string sName, string criteria, int userID, int ttype, int searchID)
        {
            DataTable vtable = new DataTable("consumer");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageSavedSearches", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@name", sName);
                sqlCmd.Parameters.AddWithValue("@Criteria", criteria);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@TType", ttype);
                sqlCmd.Parameters.AddWithValue("@SearchID", searchID);
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
        public static int ManageBusinessReviewDetails(int reviewerID, string reviewname, int profileID, int rating1, int rating2, int rating3, string description, int avgrating, int userID, int ttype, int reviewID, string phone, string email)
        {
            DataTable vtable = new DataTable("consumer");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageBusinessReview", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@reviewerID", reviewerID);
                sqlCmd.Parameters.AddWithValue("@reviewername", reviewname);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@rating1", rating1);
                sqlCmd.Parameters.AddWithValue("@rating2", rating2);
                sqlCmd.Parameters.AddWithValue("@rating3", rating3);
                sqlCmd.Parameters.AddWithValue("@reviewdesc", description);
                sqlCmd.Parameters.AddWithValue("@Avgrating", avgrating);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@TType", ttype);
                sqlCmd.Parameters.AddWithValue("@ReviewID", reviewID);
                sqlCmd.Parameters.AddWithValue("@Reviewphone", phone);
                sqlCmd.Parameters.AddWithValue("@ReviewEmail", email);
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
        public static DataTable GetUserSentMessages(bool top5Flag, int userID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserSentMessages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@top5flag", top5Flag);
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
        public static int UpdateUserReadMessage(int totypeID, int msgID)
        {
            DataTable vtable = new DataTable("consumer");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateMessage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ToTypeID", totypeID);
                sqlCmd.Parameters.AddWithValue("@MsgID", msgID);
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

        public static int UpdateUserPassword(int userid, string newpassword, int passwordChanged)
        {
            DataTable vtable = new DataTable("consumer");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateUserPassword", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@password", newpassword);
                sqlCmd.Parameters.AddWithValue("@UserID", userid);
                sqlCmd.Parameters.AddWithValue("@Password_Changed", passwordChanged);
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
        public static DataTable GetTipsForSelect()
        {
            DataTable DsTipsSelected = new DataTable();
            SqlConnection objConn = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand objcmd = new SqlCommand("usp_GetTipCategoryName", objConn);
                objcmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter objAdpt = new SqlDataAdapter(objcmd);
                objAdpt.Fill(DsTipsSelected);
                return DsTipsSelected;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(objConn);
            }
        }
        public static DataTable GetTipsCategory(string tipCategory)
        {
            DataTable dtTipsCategory = new DataTable();
            SqlConnection objConn = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand objcmd = new SqlCommand("usp_GetTipCategoryes", objConn);
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@Tip_Category", tipCategory);
                SqlDataAdapter objAdpt = new SqlDataAdapter(objcmd);
                objAdpt.Fill(dtTipsCategory);
                return dtTipsCategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(objConn);
            }
        }

        public static int ModifyConsumer(string username, string email, string firstname, string lastname, int roleId, bool isActive, string addr1, string addr2, string city, string state, string country, string zipcode, string phone, int userid, string status, int profileID)
        {
            DataTable vtable = new DataTable("consumer");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ModifyUserdetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", username);

                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.Parameters.AddWithValue("@FirstName", firstname);
                sqlCmd.Parameters.AddWithValue("@LastName", lastname);
                sqlCmd.Parameters.AddWithValue("@RoleId", roleId);
                sqlCmd.Parameters.AddWithValue("@IsActive", isActive);
                sqlCmd.Parameters.AddWithValue("@Address1", addr1);
                sqlCmd.Parameters.AddWithValue("@Address2", addr2);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@State", state);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                sqlCmd.Parameters.AddWithValue("@status", status);
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipcode);
                sqlCmd.Parameters.AddWithValue("@Phone", phone);
                sqlCmd.Parameters.AddWithValue("@UserID", userid);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileID);
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

        // Start Issue 849
        public static DataTable ValidateSavedSearch(string searchname, int userID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ValidateSavedSearchesByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Search_Name", searchname);
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

        // End Issue 849
        public static DataTable GetAssociateUserDetails(string userName, string domainName)
        {
            DataTable msgs = new DataTable("Associate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAssociateUserDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", userName);
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
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
        // ASSOCIATE LOGIN
        public static int Insert_Update_AssociateLogin(string pFirstname, string pLastname, string pUsername, string pPassword, string pUserStatus,
            int pCreatedUser, int pSuperAdminID, bool pIsAssociateSuperAdmin, int pUserID)
        {
            int associateUserID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_AssociateLogin", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Firstname", pFirstname);
                sqlCmd.Parameters.AddWithValue("@Lastname", pLastname);
                sqlCmd.Parameters.AddWithValue("@Username", pUsername);
                sqlCmd.Parameters.AddWithValue("@Password", pPassword);
                sqlCmd.Parameters.AddWithValue("@User_Status", pUserStatus);
                sqlCmd.Parameters.AddWithValue("@CREATED_USER", pCreatedUser);
                sqlCmd.Parameters.AddWithValue("@SuperAdmin_Id", pSuperAdminID);
                sqlCmd.Parameters.AddWithValue("@IsAssociate_SuperAdmin", pIsAssociateSuperAdmin);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                associateUserID = Convert.ToInt32(sqlCmd.ExecuteScalar());

                return associateUserID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetManageAssociates(int pUserID, string searchTag, out int totalAssociates)
        {
            DataTable dt = new DataTable("ManageAssociate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetManageAssociates", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@SearchTag", searchTag);
                sqlCmd.Parameters.Add(new SqlParameter("@TotalAssociates", SqlDbType.Int)).Direction = ParameterDirection.Output;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dt);
                totalAssociates = Convert.ToInt32(sqlCmd.Parameters["@TotalAssociates"].Value.ToString());
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

        public static DataTable GetActiveAssociates(int pUserID)
        {
            DataTable dt = new DataTable("ActiveAssociate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetActiveAssociates", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
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

        public static void ChangeloginID(string username, int userID)
        {
            DataTable vtable = new DataTable("consumer");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ChangeLoginID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", username);
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

    }
}
