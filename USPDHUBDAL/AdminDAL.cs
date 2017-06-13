using System;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class AdminDAL : DataAccess
    {
        /// <summary>
        /// Validating the customer
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>data table</returns>
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
        // Users Search
        /// <summary>
        /// Getting the dat aof user
        /// </summary>
        /// <param name="searchText">searchText</param>
        /// <param name="ddlSelectValue">ddlSelectValue</param>
        /// <param name="type">type</param>
        /// <param name="vertical">vertical</param>
        /// <param name="country">country</param>
        /// <returns>Data table</returns>
        public static DataTable GetUsersData(string searchText, string ddlSelectValue, bool type, string vertical, string country)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable stable = new DataTable("SearchData");
            try
            {

                if (ddlSelectValue == "Firstname" && searchText != "")
                {
                    SqlCommand sqlCmd = new SqlCommand("usp_AdminSearch", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Firstname", SqlDbType.VarChar, 200));
                    sqlAdptr.SelectCommand.Parameters["@Firstname"].Value = searchText;
                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Type", SqlDbType.Bit));
                    sqlAdptr.SelectCommand.Parameters["@Type"].Value = type;
                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Vertical", SqlDbType.VarChar, 100));
                    sqlAdptr.SelectCommand.Parameters["@Vertical"].Value = vertical;
                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 100));
                    sqlAdptr.SelectCommand.Parameters["@Country"].Value = country;
                    sqlAdptr.Fill(stable);

                }
                else
                    if (ddlSelectValue == "Lastname" && searchText != "")
                    {
                        SqlCommand sqlCmd = new SqlCommand("usp_AdminSearch", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                        sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Lastname", SqlDbType.VarChar, 50));
                        sqlAdptr.SelectCommand.Parameters["@Lastname"].Value = searchText;
                        sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Type", SqlDbType.Bit));
                        sqlAdptr.SelectCommand.Parameters["@Type"].Value = type;
                        sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Vertical", SqlDbType.VarChar, 100));
                        sqlAdptr.SelectCommand.Parameters["@Vertical"].Value = vertical;
                        sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 100));
                        sqlAdptr.SelectCommand.Parameters["@Country"].Value = country;
                        sqlAdptr.Fill(stable);

                    }
                    else
                        if (ddlSelectValue == "Email" && searchText != "")
                        {
                            SqlCommand sqlCmd = new SqlCommand("usp_AdminSearch", sqlCon);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                            sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 32));
                            sqlAdptr.SelectCommand.Parameters["@Email"].Value = searchText;
                            sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Type", SqlDbType.Bit));
                            sqlAdptr.SelectCommand.Parameters["@Type"].Value = type;
                            sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Vertical", SqlDbType.VarChar, 100));
                            sqlAdptr.SelectCommand.Parameters["@Vertical"].Value = vertical;
                            sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 100));
                            sqlAdptr.SelectCommand.Parameters["@Country"].Value = country;
                            sqlAdptr.Fill(stable);

                        }
                        //Issue 482
                        else
                            if (ddlSelectValue == "Business Name" && searchText != "")
                            {
                                SqlCommand sqlCmd = new SqlCommand("Usp_AdminSearchbyBusinessName", sqlCon);
                                sqlCmd.CommandType = CommandType.StoredProcedure;
                                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                                sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@SearchText", SqlDbType.VarChar, 500));
                                sqlAdptr.SelectCommand.Parameters["@SearchText"].Value = searchText;
                                sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@SearchType", SqlDbType.VarChar, 50));
                                sqlAdptr.SelectCommand.Parameters["@SearchType"].Value = "Businessname";
                                sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Type", SqlDbType.Bit));
                                sqlAdptr.SelectCommand.Parameters["@Type"].Value = type;
                                sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Vertical", SqlDbType.VarChar, 100));
                                sqlAdptr.SelectCommand.Parameters["@Vertical"].Value = vertical;
                                sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 100));
                                sqlAdptr.SelectCommand.Parameters["@Country"].Value = country;
                                sqlAdptr.Fill(stable);

                            }
                            else
                                if (ddlSelectValue == "Zip code" && searchText != "")
                                {
                                    SqlCommand sqlCmd = new SqlCommand("Usp_AdminSearchbyBusinessName", sqlCon);
                                    sqlCmd.CommandType = CommandType.StoredProcedure;
                                    SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@SearchText", SqlDbType.VarChar, 500));
                                    sqlAdptr.SelectCommand.Parameters["@SearchText"].Value = searchText;
                                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@SearchType", SqlDbType.VarChar, 50));
                                    sqlAdptr.SelectCommand.Parameters["@SearchType"].Value = "Zipcode";
                                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Type", SqlDbType.Bit));
                                    sqlAdptr.SelectCommand.Parameters["@Type"].Value = type;
                                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Vertical", SqlDbType.VarChar, 100));
                                    sqlAdptr.SelectCommand.Parameters["@Vertical"].Value = vertical;
                                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 100));
                                    sqlAdptr.SelectCommand.Parameters["@Country"].Value = country;
                                    sqlAdptr.Fill(stable);

                                }
                                else
                                {
                                    SqlCommand sqlCmd = new SqlCommand("Usp_AdminSearchbyBusinessName", sqlCon);
                                    sqlCmd.CommandType = CommandType.StoredProcedure;
                                    SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@SearchText", SqlDbType.VarChar, 500));
                                    sqlAdptr.SelectCommand.Parameters["@SearchText"].Value = "";
                                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@SearchType", SqlDbType.VarChar, 50));
                                    sqlAdptr.SelectCommand.Parameters["@SearchType"].Value = "";
                                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Type", SqlDbType.Bit));
                                    sqlAdptr.SelectCommand.Parameters["@Type"].Value = type;
                                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Vertical", SqlDbType.VarChar, 100));
                                    sqlAdptr.SelectCommand.Parameters["@Vertical"].Value = vertical;
                                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 100));
                                    sqlAdptr.SelectCommand.Parameters["@Country"].Value = country;
                                    sqlAdptr.Fill(stable);
                                }
                //End Issue 482
                return stable;
            }
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
        /// Adding a cutomer
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <param name="email">email</param>
        /// <param name="firstname">firstname</param>
        /// <param name="lastname">lastname</param>
        /// <param name="pswdQ1">pswdQ1</param>
        /// <param name="pswdA1">pswdA1</param>
        /// <param name="pswdQ2">pswdQ2</param>
        /// <param name="pswdA2">pswdA2</param>
        /// <param name="roleId">roleId</param>
        /// <param name="isActive">isActive</param>
        /// <param name="addr1">addr1</param>
        /// <param name="addr2">addr2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="country">country</param>
        /// <param name="status">status</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone">phone</param>
        /// <param name="userid">userid</param>
        /// <param name="isFree">isFree</param>
        /// <returns>An Integer</returns>
        public static int AddConsumer(string username, string password, string email, string firstname, string lastname, string pswdQ1, string pswdA1, string pswdQ2, string pswdA2, int roleId, bool isActive, string addr1, string addr2, string city, string state, string country, string status, string zipcode, string phone, int userid, bool isFree)
        {
            DataTable userTable = new DataTable("consumer");
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
                sqlCmd.Parameters.AddWithValue("@IsFree", isFree);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(userTable);
                if (userTable != null)
                {
                    returnval = Convert.ToInt32(userTable.Rows[0][0]);
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
        //public static DataTable GetUserDetails(string username)
        //{
        //    DataTable user = new DataTable("user");
        //    SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

        //    try
        //    {
        //        SqlCommand sqlCmd = new SqlCommand("usp_GetUserDetails", sqlCon);
        //        sqlCmd.CommandType = CommandType.StoredProcedure;
        //        sqlCmd.Parameters.AddWithValue("@UserName", username);
        //        SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
        //        sqlAdptr.Fill(user);

        //        return user;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
        //    }



        //}

        /// <summary>
        /// Getting user details by id
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>data table</returns>
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
        /// <summary>
        /// Get the details of Admin by ID
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>Data tabe</returns>
        public static DataTable GetAdminUserDetails(string username)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AdminUserDetails", sqlCon);
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
        //Industry Search

        /// <summary>
        /// To get the data of industry
        /// </summary>
        /// <param name="searchText">Text for searching</param>
        /// <param name="ddlSelectValue">ddlSelectValue</param>
        /// <returns>Data Table</returns>
        public static DataTable GetIndustryData(string searchText, string ddlSelectValue)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable stable = new DataTable("SearchData");
            try
            {

                if (ddlSelectValue == "Industryname")
                {
                    SqlCommand sqlCmd = new SqlCommand("usp_IndustrySearch", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Industryname", SqlDbType.VarChar, 200));
                    sqlAdptr.SelectCommand.Parameters["@Industryname"].Value = searchText;
                    sqlAdptr.Fill(stable);

                }
                else
                    if (ddlSelectValue == "ID")
                    {
                        SqlCommand sqlCmd = new SqlCommand("usp_IndustrySearch", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                        sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 50));
                        sqlAdptr.SelectCommand.Parameters["@id"].Value = searchText;
                        sqlAdptr.Fill(stable);

                    }


                return stable;
            }
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
        /// For filling industry data
        /// </summary>
        /// <returns>Data table</returns>
        public static DataTable FillIndustryData()
        {
            DataTable itable = new DataTable("IndustryData");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_IndustryGetdata", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(itable);
                return itable;
            }
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
        /// For filling subscription data
        /// </summary>
        /// <returns>Data table</returns>
        public static DataTable FillSubscriptionData()
        {
            DataTable stable = new DataTable("SubscriptionData");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSubscriptionData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(stable);
                return stable;
            }
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
        /// For filling user data
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>Data Table</returns>
        public static DataTable FillUsersData(bool type)
        {
            DataTable utable = new DataTable("UserData");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUsersData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlCmd.Parameters.AddWithValue("@Type", type);
                sqlAdptr.Fill(utable);
                return utable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }


        }
        // User Delete

        /// <summary>
        /// For deleting user record
        /// </summary>
        /// <param name="uid">uid</param>
        /// <param name="userID">userID</param>
        /// <param name="ipAddress">ipAddress</param>
        /// <returns></returns>
        public static int DeleteUsersRecord(int uid, int userID, string ipAddress)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UsersDeleteRecord", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Uid", uid);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@IpAddress", ipAddress);
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

        //Add Subscription 
        /// <summary>
        /// For Adding subscription
        /// </summary>
        /// <param name="subscriptionID">subscriptionID</param>
        /// <param name="subscriptionPeriod">subscriptionPeriod</param>
        /// <param name="subscriptionname">subscriptionname</param>
        /// <param name="subscriptiondesc">subscriptiondesc</param>
        /// <param name="subscriptionPrice">subscriptionPrice</param>
        /// <param name="subscriptionType">subscriptionType</param>
        /// <param name="userName">userName</param>
        /// <param name="activeFlag">activeFlag</param>
        public static void AddSubscription(string subscriptionID, string subscriptionPeriod, string subscriptionname, string subscriptiondesc, string subscriptionPrice, string subscriptionType, string userName, bool activeFlag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageSubscription", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Subscription_ID", subscriptionID);
                sqlCmd.Parameters.AddWithValue("@Subscription_Period", subscriptionPeriod);
                sqlCmd.Parameters.AddWithValue("@Subscription_name", subscriptionname);
                sqlCmd.Parameters.AddWithValue("@Subscription_desc", subscriptiondesc);
                sqlCmd.Parameters.AddWithValue("@Subscription_Price", subscriptionPrice);
                sqlCmd.Parameters.AddWithValue("@Subscription_Type", subscriptionType);
                sqlCmd.Parameters.AddWithValue("@UserName", userName);
                sqlCmd.Parameters.AddWithValue("@Active_flag", activeFlag);
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
        //add Industry 
        /// <summary>
        /// For adding new  industry
        /// </summary>
        /// <param name="industryid">industryid</param>
        /// <param name="industryName">industryName</param>
        /// <param name="industryCategory">industryCategory</param>
        /// <param name="userName">userName</param>
        /// <param name="industryDescription">industryDescription</param>
        /// <param name="industryKeyWord">industryKeyWord</param>
        /// <param name="activeFlag">activeFlag</param>
        public static void AddIndustry(string industryid, string industryName, string industryCategory, string userName, string industryDescription, string industryKeyWord, bool activeFlag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageIndustry", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Industry_ID", industryid);
                sqlCmd.Parameters.AddWithValue("@Industry_name", industryName);
                sqlCmd.Parameters.AddWithValue("@Industry_Category", industryCategory);
                sqlCmd.Parameters.AddWithValue("@UserName", userName);
                sqlCmd.Parameters.AddWithValue("@Industry_description", industryDescription);
                sqlCmd.Parameters.AddWithValue("@Industry_KeyWord", industryKeyWord);
                sqlCmd.Parameters.AddWithValue("@Active_flag", activeFlag);
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
        //Subscription
        /// <summary>
        /// For getting the subscription details
        /// </summary>
        /// <param name="typeId">typeId</param>
        /// <returns>Data table</returns>
        public static DataTable GetSubscriptionDetails(int typeId)
        {
            DataTable industry = new DataTable("Subscription");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSubscriptionDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@typeID", typeId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(industry);

                return industry;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }



        }
        //Industry Update
        /// <summary>
        /// For getting the industry details
        /// </summary>
        /// <param name="industryid">industryid</param>
        /// <returns>Data table</returns>
        public static DataTable GetIndustryDetails(string industryid)
        {
            DataTable industry = new DataTable("Industry");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetIndustryDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@industryid", industryid);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(industry);

                return industry;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }



        }

        //DiscountCode search
        /// <summary>
        /// For getting the details of discount
        /// </summary>
        /// <param name="searchCode">searchCode</param>
        /// <returns>Data table</returns>
        public static DataTable GetDiscountData(string searchCode)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtable = new DataTable("SearchData");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DiscountCodeSearch", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Discount_Code", SqlDbType.VarChar, 32));
                sqlAdptr.SelectCommand.Parameters["@Discount_Code"].Value = searchCode;
                sqlAdptr.Fill(dtable);

                return dtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        //DiscountCode Fill Data
        /// <summary>
        /// For fillig discout data 
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable FillDiscountData()
        {
            DataTable dtable = new DataTable("DiscountData");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetDiscountData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }


        }


        //Discount Code Details
        /// <summary>
        /// For getting discount code details
        /// </summary>
        /// <param name="discountCodeID">discountCodeID</param>
        /// <returns>data table</returns>
        public static DataTable GetDiscountCodeDetails(string discountCodeID)
        {
            DataTable discode = new DataTable("DiscountCode");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetDiscountCodeDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DiscountCodeID", discountCodeID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(discode);

                return discode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }



        // Start Bussiness Links 



        //Bussiness Link Name Search

        /// <summary>
        /// For searching the name of businesslinks
        /// </summary>
        /// <param name="searchName">searchName</param>
        /// <returns>data table</returns>
        public static DataTable BussinessLinkNameSearch(string searchName)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable btable = new DataTable("SearchBussinessname");
            try
            {

                SqlCommand sqlCmd = new SqlCommand("usp_BussinessLinkNameSearch", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@BLink_Name", SqlDbType.VarChar, 32));
                sqlAdptr.SelectCommand.Parameters["@BLink_Name"].Value = searchName;
                sqlAdptr.Fill(btable);



                return btable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }


        // Get Bussiness Link Data

        /// <summary>
        /// for getting bussiness data
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable FillBussinessData()
        {
            DataTable btable = new DataTable("bussinessLinkData");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBussinessData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(btable);
                return btable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }


        }

        // Insert Delete Bussiness Link 
        /// <summary>
        /// for inserting and deleting bussiness link data
        /// </summary>
        /// <param name="bLinkID">bussiness Link ID</param>
        /// <param name="bLinkName">bussiness Link Name</param>
        /// <param name="bLinkUrl">Bussiness link url</param>
        /// <param name="blinkDesc"> bussiness link description</param>
        /// <param name="userName">user name</param>
        /// <param name="activeFlag">flag</param>
        public static void AddBussinessLink(string bLinkID, string bLinkName, string bLinkUrl, string blinkDesc, string userName, bool activeFlag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageBussinessLink", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BLink_ID", bLinkID);
                sqlCmd.Parameters.AddWithValue("@BLink_Name", bLinkName);
                sqlCmd.Parameters.AddWithValue("@BLink_Url", bLinkUrl);
                sqlCmd.Parameters.AddWithValue("@Blink_Desc", blinkDesc);
                sqlCmd.Parameters.AddWithValue("@UserName", userName);
                sqlCmd.Parameters.AddWithValue("@Active_flag", activeFlag);
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


        //GetBussinessLinks Deatails

        /// <summary>
        /// Geting details of bussiness links
        /// </summary>
        /// <param name="bLinkID">bussiness linkid <param>
        /// <returns>A Data Table</returns>
        public static DataTable GetBusinessLinksDetails(string bLinkID)
        {
            DataTable bLinks = new DataTable("BusinessLinks");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBussinessLinksDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BLink_ID", bLinkID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(bLinks);

                return bLinks;
            }
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
        /// <param name="profileID"></param>
        /// <returns></returns>
        public static int UpdateInActiveflagByprofileID(int profileID)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateInActiveflagByprofileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
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


        public static int UpdateActiveflagByprofileID(int profileID)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateActiveflagByprofileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
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

        /// <summary>
        /// Getting the profile details by profile id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetProfileDetailsByProfileID(int profileID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBusinessProfileByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
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
        /// for updating details of business profiles
        /// </summary>
        /// <param name="buzname">business name</param>
        /// <param name="websitename">name of website</param>
        /// <param name="description">description </param>
        /// <param name="contactname">name of the contact</param>
        /// <param name="bdays">no. of bussinessdays</param>
        /// <param name="bhours">no.of bussiness hours</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="categories">catehories</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone1">phone number</param>
        /// <param name="fax">fax</param>
        /// <param name="templatename">template name</param>
        /// <param name="userid">userid</param>
        /// <param name="profileid">profile id</param>
        /// <returns>an integer</returns>
        public static int UpdateBusinessProfileDetails(string buzname, string websitename, string description, string contactname, string bdays, string bhours, string address1, string address2, string city, string state, string categories, string zipcode, string phone1, string fax, string templatename, int userid, int profileid)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateBusinessProfile", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profilename", buzname);
                sqlCmd.Parameters.AddWithValue("@Websitename", websitename);
                sqlCmd.Parameters.AddWithValue("@description", description);
                sqlCmd.Parameters.AddWithValue("@contactname", contactname);
                sqlCmd.Parameters.AddWithValue("@Bdays", bdays);
                sqlCmd.Parameters.AddWithValue("@Bhours", bhours);
                sqlCmd.Parameters.AddWithValue("@address1", address1);
                sqlCmd.Parameters.AddWithValue("@address2", address2);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@State", state);
                sqlCmd.Parameters.AddWithValue("@Categories", categories);
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipcode);
                sqlCmd.Parameters.AddWithValue("@phone1", phone1);
                sqlCmd.Parameters.AddWithValue("@fax", fax);
                sqlCmd.Parameters.AddWithValue("@templatename", templatename);
                sqlCmd.Parameters.AddWithValue("@UserID", userid);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileid);

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


        // Profiles FillData
        /// <summary>
        /// for filling the data of active profiles   
        /// </summary>
        /// <param name="isactive">passed as reference whether the profile is active or not</param>
        /// <returns>Data table</returns>
        public static DataTable FillProfileActiveData(int isactive)
        {
            DataTable dtable = new DataTable("DiscountData");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Fillprofilesearch", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Isactive", isactive);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }


        }
        //search in Active profiles
        /// <summary>
        /// sor searching the profiles which are inactive
        /// </summary>
        /// <param name="searchText">search text</param>
        /// <param name="ddlSelectValue"></param>
        /// <returns></returns>
        public static DataTable SearchInActiveprofiles(string searchText, string ddlSelectValue)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable stable = new DataTable("SearchData");
            try
            {

                if (ddlSelectValue == "Firstname")
                {
                    SqlCommand sqlCmd = new SqlCommand("usp_ProfileSearchByInActiveDetails", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Firstname", SqlDbType.VarChar, 200));
                    sqlAdptr.SelectCommand.Parameters["@Firstname"].Value = searchText;
                    sqlAdptr.Fill(stable);

                }
                else
                    if (ddlSelectValue == "Lastname")
                    {
                        SqlCommand sqlCmd = new SqlCommand("usp_ProfileSearchByInActiveDetails", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                        sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Lastname", SqlDbType.VarChar, 50));
                        sqlAdptr.SelectCommand.Parameters["@Lastname"].Value = searchText;
                        sqlAdptr.Fill(stable);

                    }
                    else
                        if (ddlSelectValue == "Profilename")
                        {
                            SqlCommand sqlCmd = new SqlCommand("usp_ProfileSearchByInActiveDetails", sqlCon);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                            sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Profilename", SqlDbType.VarChar, 32));
                            sqlAdptr.SelectCommand.Parameters["@Profilename"].Value = searchText;
                            sqlAdptr.Fill(stable);

                        }

                return stable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        // Search ActiveProfile Data
        /// <summary>
        /// sor searching the profiles which are active
        /// </summary>
        /// <param name="searchText">search text</param>
        /// <param name="ddlSelectValue"></param>
        /// <returns></returns>
        public static DataTable Searchprofiles(string searchText, string ddlSelectValue)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable stable = new DataTable("SearchData");
            try
            {

                if (ddlSelectValue == "Firstname")
                {
                    SqlCommand sqlCmd = new SqlCommand("usp_ProfileSearchByActiveDetails", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                    sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Firstname", SqlDbType.VarChar, 200));
                    sqlAdptr.SelectCommand.Parameters["@Firstname"].Value = searchText;
                    sqlAdptr.Fill(stable);

                }
                else
                    if (ddlSelectValue == "Lastname")
                    {
                        SqlCommand sqlCmd = new SqlCommand("usp_ProfileSearchByActiveDetails", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                        sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Lastname", SqlDbType.VarChar, 50));
                        sqlAdptr.SelectCommand.Parameters["@Lastname"].Value = searchText;
                        sqlAdptr.Fill(stable);

                    }
                    else
                        if (ddlSelectValue == "Profilename")
                        {
                            SqlCommand sqlCmd = new SqlCommand("usp_ProfileSearchByActiveDetails", sqlCon);
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                            sqlAdptr.SelectCommand.Parameters.Add(new SqlParameter("@Profilename", SqlDbType.VarChar, 32));
                            sqlAdptr.SelectCommand.Parameters["@Profilename"].Value = searchText;
                            sqlAdptr.Fill(stable);

                        }

                return stable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }


        public static DataTable FillAdsData()
        {
            DataTable atable = new DataTable("AdsData");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAdsData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(atable);
                return atable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }


        }



        // Insert Delete Ads Slots 
        public static void AddAdsSlots(string slotID, string pname, string maxislots, string avaliableslots, string slotcost, bool activeFlag, string userName)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageAdsData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@slots_ID", slotID);
                sqlCmd.Parameters.AddWithValue("@Page_Name", pname);
                sqlCmd.Parameters.AddWithValue("@Max_Slots", maxislots);
                sqlCmd.Parameters.AddWithValue("@Available_Slots", avaliableslots);
                sqlCmd.Parameters.AddWithValue("@Slot_Cost", slotcost);
                sqlCmd.Parameters.AddWithValue("@Active_flag", activeFlag);
                sqlCmd.Parameters.AddWithValue("@CREATED_USER", userName);
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
        //Get Deatils
        public static DataTable GetAdsDetails(string slotID)
        {
            DataTable atable = new DataTable("AdS");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAdsDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@slots_ID", slotID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(atable);

                return atable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }



        }

        public static DataTable FillWordFilterData()
        {
            DataTable wtable = new DataTable("WordFilterData");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetWordFilterData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(wtable);
                return wtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }


        }

              public static DataTable GetWordFilterDetails(string wordID)
        {
            DataTable wtable = new DataTable("word");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetWordFilterDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@word_ID", wordID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(wtable);

                return wtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }



        }

        //Admin Alerts Methods

        /// <summary>
        /// for getting templates which are active
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetActiveTemlates()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                DataTable dtTemplates = new DataTable();
                SqlCommand sqlCmd = new SqlCommand("Alrt_GetALLAlertTemplates");
                sqlCmd.Connection = sqlCon;
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                sqlDa.Fill(dtTemplates);
                return dtTemplates;
            }
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
        /// for adding a alert group to template
        /// </summary>
        /// <param name="templateId">templateId</param>
        /// <param name="alertGroup">alertGroup</param>
        /// <param name="subject">subject</param>
        /// <param name="eventname">eventname</param>
        /// <param name="message">message</param>
        /// <param name="fromdate">fromdate</param>
        /// <param name="todate">todate</param>
        /// <param name="destType">destType</param>
        /// <param name="userid">userid</param>
        /// <param name="eventWinner">eventWinner</param>
        /// <param name="filter">filter</param>
        /// <returns>integer</returns>
        public static int AddAlertTemplate(int templateId, string alertGroup, string subject, string eventname, string message, DateTime fromdate, DateTime todate, string destType, int userid, bool eventWinner, string filter)
        {
            DataTable vtable = new DataTable("admin");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Alrt_InsertAlertTemplate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Template_ID", templateId);
                sqlCmd.Parameters.AddWithValue("@AlertGroup", alertGroup);
                sqlCmd.Parameters.AddWithValue("@Subject", subject);
                sqlCmd.Parameters.AddWithValue("@Message", message);
                sqlCmd.Parameters.AddWithValue("@Fromdate", fromdate);
                sqlCmd.Parameters.AddWithValue("@Todate", todate);
                sqlCmd.Parameters.AddWithValue("@dest_Type", destType);
                sqlCmd.Parameters.AddWithValue("@userID", userid);
                sqlCmd.Parameters.AddWithValue("@event", eventname);
                sqlCmd.Parameters.AddWithValue("@filter", filter);
                sqlCmd.Parameters.AddWithValue("@EventWinner", eventWinner);
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

        /// <summary>
        /// Getting the names of the group
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable Getgroupnames()
        {
            DataTable vtable = new DataTable("groupnames");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Alrt_GetgroupNames", sqlCon);
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

        /// <summary>
        /// Getting the templates which arre active based on template id
        /// </summary>
        /// <param name="templateID">templateID</param>
        /// <returns>data table</returns>
        public static DataTable GetActiveTemplateByTemplateID(int templateID)
        {
            DataTable dtActiveTemplates = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Alrt_GetActiveTemplateByTemplateID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Template_ID", templateID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtActiveTemplates);

                return dtActiveTemplates;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        //Send Alerts to Rocklin  Users

        /// <summary>
        /// for sending alerts for Rocklin users
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable Rocklinusers()
        {
            DataTable itable = new DataTable("Rocklinuser");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Alrt_Getallrocklinusers", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(itable);
                return itable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        //Get Sales Report 

        /// <summary>
        /// getting the sales report
        /// </summary>
        /// <param name="sqlQuery">sqlQuery</param>
        /// <returns>DataTable</returns>
        public static DataTable Getsalesdetails(string sqlQuery)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetsalesReport", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Query", sqlQuery);

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
        /// Foe getting the name of the events
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable Geteventnames()
        {
            DataTable vtable = new DataTable("eventnames");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Getdistinctevents", sqlCon);
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

        //Get admin template by template Id

        /// <summary>
        /// getting the admin template by template id
        /// </summary>
        /// <param name="templateID">templateID</param>
        /// <returns>data table</returns>
        public static DataTable GetTemplateByTemplateID(int templateID)
        {
            DataTable dtActiveTemplates = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Alrt_GetTemplateByTemplateID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Template_ID", templateID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtActiveTemplates);

                return dtActiveTemplates;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetResellerDetailsbyUserProfileId(int profileId)
        {
            DataTable dtreseller = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetResellerDetailsbyUserProfile_ID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtreseller);

                return dtreseller;
            }
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
        /// For retrievng log in details of user based on user id
        /// </summary>
        /// <param name="userid">userid</param>
        /// <param name="fromdate">fromdate</param>
        /// <param name="todate">todate</param>
        /// <returns>data table</returns>
        public static DataTable GetLoginDetailsbyUserID(int userid, string fromdate, string todate)
        {
            DataTable dtlogin = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetLoginDetailsbyUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userid);
                sqlCmd.Parameters.AddWithValue("@Fromdate", fromdate);
                sqlCmd.Parameters.AddWithValue("@Todate", todate);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtlogin);
                return dtlogin;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }


        // Page Traffic Report

        public static DataTable GetPageTrafficReportForAdmin(string queryString)
        {
            DataTable dtlogin = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetProfileTrafficReportforAdmin", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@QueryString", queryString);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtlogin);
                return dtlogin;
            }
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
        /// For getting registration details by profile id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>dat table</returns>
        public static DataTable GetRegorderdetailsbyProfileID(int profileID)
        {
            DataTable dtdetails = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetRegOrderDetailsbyProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtdetails);
                return dtdetails;
            }
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
        /// for inserting and updating the bussiness type
        /// </summary>
        /// <param name="bid">bussiness id</param>
        /// <param name="businesstype">type of bussiness </param>
        /// <param name="status">status</param>
        /// <returns>tnteger</returns>
        public static int InsertUpdateBusinessType(int bid, string businesstype, bool status)
        {
            DataTable vtable = new DataTable("admin");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertUpdateBusinessType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BID", bid);
                sqlCmd.Parameters.AddWithValue("@Business_Type", businesstype);
                sqlCmd.Parameters.AddWithValue("@IsActive", status);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable != null)
                {
                    result = Convert.ToInt32(vtable.Rows[0][0]);
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

        /// <summary>
        /// for retrieveing the usability count of business types
        /// </summary>
        /// <param name="bid">bid</param>
        /// <returns>int</returns>
        public static int GetBusinessTypeUsabilityCount(int bid)
        {
            DataTable vtable = new DataTable("admin");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBusinessTypeUsabilityCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BID", bid);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable != null)
                {
                    result = Convert.ToInt32(vtable.Rows[0][0]);
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

        /// <summary>
        /// for retrieveing the usability count of business types based on bussiness id
        /// </summary>
        /// <param name="bid">bid</param>
        /// <returns>int</returns>
        public static DataTable GetBusinessTypedetailsByID(int bid)
        {
            DataTable dtdetails = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBusinessTypeDetailsbyID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BID", bid);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtdetails);
                return dtdetails;
            }
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
        /// Getting all business types
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetallBusinessTypes()
        {
            DataTable dtdetails = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetallBusinessTypes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtdetails);
                return dtdetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        // Start Get User Details based on registrtion type //

        /// <summary>
        /// For filling the user data
        /// </summary>
        /// <param name="regType">registration type</param>
        /// <returns>DataTable</returns>
        public static DataTable FillUsersData(int regType)
        {
            DataTable dtdetails = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBusinessesByRegType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@RegType", regType);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtdetails);
                return dtdetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        // End Get User Details based on registrtion type //        
        // *** From Anand *** //
       
        /// <summary>
        /// for getting the analysis report of user data
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable FillAnalysisUsersData()
        {
            DataTable utable = new DataTable("UserData");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DataAnalysisReport", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(utable);
                return utable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }


        }

        public static DataTable GetCustomerDeskNotesDetailsByUser_ID(int userID)
        {
            DataTable dtdetails = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetCustomerDeskNotesDetailsByUser_ID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@User_ID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtdetails);
                return dtdetails;
            }
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
        /// For Getting customer details
        /// </summary>
        /// <param name="queryUserID">queryUserID</param>
        /// <returns>data table</returns>
        public static DataTable GetMemberDetails(int queryUserID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            //SqlQuery = SqlQuery.Replace("'", "''");
            //SqlQuery = SqlQuery.Replace("''", "'");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CustomerDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@User_ID", queryUserID);

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
        /// for getting admin details
        /// </summary>
        /// <param name="queryUserID">queryUserID</param>
        /// <returns>returns</returns>
        public static DataTable GetAdminDetails(int queryUserID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAdminDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@User_ID", queryUserID);

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


        public static DataTable GetMemberDetails(int queryID, string queryUser)
        {

            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CustomerDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (queryID == 2)
                {

                    sqlCmd.Parameters.AddWithValue("@PhoneNo1", queryUser);
                    sqlCmd.Parameters.AddWithValue("@User_ID", null);
                    sqlCmd.Parameters.AddWithValue("@Firstname", null);
                    sqlCmd.Parameters.AddWithValue("@Lastname", null);
                    sqlCmd.Parameters.AddWithValue("@LoginName", null);
                    sqlCmd.Parameters.AddWithValue("@ProfileName", null);
                }
                if (queryID == 3)
                {
                    sqlCmd.Parameters.AddWithValue("@Firstname", queryUser);
                    sqlCmd.Parameters.AddWithValue("@User_ID", null);
                    sqlCmd.Parameters.AddWithValue("@PhoneNo1", null);
                    sqlCmd.Parameters.AddWithValue("@Lastname", null);
                    sqlCmd.Parameters.AddWithValue("@LoginName", null);
                    sqlCmd.Parameters.AddWithValue("@ProfileName", null);
                }
                else if (queryID == 4)
                {
                    sqlCmd.Parameters.AddWithValue("@Lastname", queryUser);
                    sqlCmd.Parameters.AddWithValue("@User_ID", null);
                    sqlCmd.Parameters.AddWithValue("@PhoneNo1", null);
                    sqlCmd.Parameters.AddWithValue("@Firstname", null);
                    sqlCmd.Parameters.AddWithValue("@LoginName", null);
                    sqlCmd.Parameters.AddWithValue("@ProfileName", null);
                }
                else if (queryID == 5)
                {
                    sqlCmd.Parameters.AddWithValue("@LoginName", queryUser);
                    sqlCmd.Parameters.AddWithValue("@User_ID", null);
                    sqlCmd.Parameters.AddWithValue("@PhoneNo1", null);
                    sqlCmd.Parameters.AddWithValue("@Firstname", null);
                    sqlCmd.Parameters.AddWithValue("@Lastname", null);
                    sqlCmd.Parameters.AddWithValue("@ProfileName", null);
                }
                else if (queryID == 6)
                {
                    sqlCmd.Parameters.AddWithValue("@ProfileName", queryUser);
                    sqlCmd.Parameters.AddWithValue("@User_ID", null);
                    sqlCmd.Parameters.AddWithValue("@PhoneNo1", null);
                    sqlCmd.Parameters.AddWithValue("@Firstname", null);
                    sqlCmd.Parameters.AddWithValue("@Lastname", null);
                    sqlCmd.Parameters.AddWithValue("@LoginName", null);
                }

                // sqlCmd.Parameters.AddWithValue("@Firstname", QueryUser_ID);

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

        //Getting profile id by User email
        /// </summary>
        /// <param name="uname">uname</param>
        /// <param name="vertical">vertical</param>
        /// <returns>data table</returns>
        public static DataTable GetProfileIDByUserEmail(string uname, string vertical)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            //SqlQuery = SqlQuery.Replace("'", "''");
            //SqlQuery = SqlQuery.Replace("''", "'");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetProfileIDUserIDByUserEmail", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserEmail", uname);
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
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

       
        public static void UpdateEzsmartSiteByprofileID(bool ezsmartflag, int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateEzsmartSiteFlag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ezsmartflag", ezsmartflag);
                sqlCmd.Parameters.AddWithValue("@profileid", profileID);
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
        /// Getting user details by profile id
        /// </summary>
        /// <param name="profileID"></param>
        /// <returns></returns>
        public static DataTable GetUserDetailsByProfileID(int profileID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CustomerDetailsbyProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@profileid", profileID);

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


        public static DataTable GetCustomerDeskNotesDetailsByProfileID(int profileID)
        {
            DataTable dtdetails = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetCustomerDeskNotesDetailsByProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtdetails);
                return dtdetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        #region             *** Payments Renuals ***

        /// <summary>
        /// Getting all subscriptions from given start and end date
        /// </summary>
        /// <param name="pStartDate">start date</param>
        /// <param name="pEndDate">end date</param>
        /// <returns></returns>
        public static DataTable GetAllSubcriptions(DateTime pStartDate, DateTime pEndDate)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConn = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetAllProfileSubcriptions", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@startdate", pStartDate);
                cmd.Parameters.AddWithValue("@enddate", pEndDate);
                SqlDataAdapter adpter = new SqlDataAdapter(cmd);
                adpter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlConn);
            }
        }

        /// <summary>
        /// for updating the renewal date of subscription
        /// </summary>
        /// <param name="pRenewalDate">renewal date</param>
        /// <param name="pOrderID">orderid</param>
        public static void UpdateSubcriptionRenewalDate(DateTime pRenewalDate, int pOrderID)
        {

            SqlConnection sqlConn = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Update_SubcritptionRenewalDate", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@renewalDate", pRenewalDate);
                cmd.Parameters.AddWithValue("@orderID", pOrderID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                ConnectionManager.Instance.ReleaseSQLConnection(sqlConn);
            }
        }

        #endregion


        #region         *** Update User Tools ***

        /// <summary>
        /// updating the selected user tools
        /// </summary>
        /// <param name="pUserID">userid</param>
        /// <param name="pIsWebsite">passed as a reference whether it is website or not</param>
        /// <param name="pIsFlyers">passed as a reference whether it is flyers or not</param>
        /// <param name="pIsUpdate">passed as a reference whether it is website or not</param>
        /// <param name="pIsCoupon">passed as a reference whether it has coupon or not</param>
        /// <param name="pIsEventCalendar">passed as a reference whether it is a calender event or not</param>
        /// <param name="pIsAppointmentCalendar">passed as a reference</param>
        /// <param name="pIsSocialmedia">passed as a reference </param>
        /// <param name="pIsCustomDomain">passed as a reference whether it is a custom domain or not</param>
        /// <param name="pTotalEmails">Number of emails</param>
        /// <param name="pSelectedEmailsCount">selected emails count</param>
        /// <param name="pModifyUser"></param>
        /// <param name="pTotalPrice">total price</param>
        /// <param name="pDiscount">discount</param>
        public static void UpdateSelectedUserTools(int pUserID, bool pIsWebsite, bool pIsFlyers, bool pIsUpdate, bool pIsCoupon,
            bool pIsEventCalendar, bool pIsAppointmentCalendar, bool pIsSocialmedia, bool pIsCustomDomain, int pTotalEmails,
            int pSelectedEmailsCount, string pModifyUser, decimal pTotalPrice, decimal pDiscount)
        {
            SqlConnection sqlConn = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateSelectedTools", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_ID", pUserID);
                cmd.Parameters.AddWithValue("@IsWebsite", pIsWebsite);
                cmd.Parameters.AddWithValue("@IsFlyers", pIsFlyers);
                cmd.Parameters.AddWithValue("@IsUpdate", pIsUpdate);
                cmd.Parameters.AddWithValue("@IsCoupon", pIsCoupon);
                cmd.Parameters.AddWithValue("@IsEventCalendar", pIsEventCalendar);
                cmd.Parameters.AddWithValue("@IsAppointmentCalendar", pIsAppointmentCalendar);
                cmd.Parameters.AddWithValue("@IsSocialMedia_Analytics", pIsSocialmedia);
                cmd.Parameters.AddWithValue("@IsCustomDomain", pIsCustomDomain);
                cmd.Parameters.AddWithValue("@Total_Emails", pTotalEmails);
                cmd.Parameters.AddWithValue("@Selected_EmailsCount", pSelectedEmailsCount);
                cmd.Parameters.AddWithValue("@Modified_User", pModifyUser);
                cmd.Parameters.AddWithValue("@Total_Price", pTotalPrice);
                cmd.Parameters.AddWithValue("@Discount", pDiscount);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                ConnectionManager.Instance.ReleaseSQLConnection(sqlConn);
            }
        }

        /// <summary>
        /// updating tools by user id
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>data table</returns>
        public static DataTable GetUpdateToolsByUserID(int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUpdateToolsByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@User_ID", userID);
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

        #endregion

        /// <summary>
        /// Getting passwords by user name
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>data table</returns>
        public static DataTable GetPasswordByUserName(string username)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPasswordByUserName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Username", username);
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
        /// for changing admin password
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>integer</returns>
        public static int ChangePasswordByAdmin(string username, string password)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ChangePasswordByAdmin", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Username", username);
                sqlCmd.Parameters.AddWithValue("@password", password);
                int result = sqlCmd.ExecuteNonQuery();
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


        public static int InsertCustomerDeskNotesDetails(int userID, string notes, string adminUserName, string notesBy)
        {
            DataTable vtable = new DataTable("admin");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertCustomerDeskNotesDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@User_ID", userID);
                sqlCmd.Parameters.AddWithValue("@Notes", notes);
                sqlCmd.Parameters.AddWithValue("@Notes_By", notesBy);
                sqlCmd.Parameters.AddWithValue("@AdminUserName", adminUserName);

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                //if (vtable != null)
                //{
                //    result = Convert.ToInt32(vtable.Rows[0][0]);
                //}

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

        //----------------- COONTACT US DETAILS

        /// <summary>
        /// fo inserting contact details 
        /// </summary>
        /// <param name="pName">name</param>
        /// <param name="pEmail">emil</param>
        /// <param name="pPhone">phone</param>
        /// <param name="pType">type</param>
        /// <param name="pSubject">subject</param>
        /// <param name="pComments">comments</param>
        /// <returns>integer</returns>
        public static int InsertContactUsDetails(string pName, string pEmail, string pPhone, string pType, string pSubject, string pComments)
        {

            int returnID = 0;
            try
            {
                SqlConnection sqlconn = ConnectionManager.Instance.GetSQLConnection();
                SqlCommand cmd = new SqlCommand("usp_InsertContactUsDetails", sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", pName);
                cmd.Parameters.AddWithValue("@Email", pEmail);
                cmd.Parameters.AddWithValue("@Phone", pPhone);
                cmd.Parameters.AddWithValue("@Type", pType);
                cmd.Parameters.AddWithValue("@Subject", pSubject);
                cmd.Parameters.AddWithValue("@Comments", pComments);
                returnID = cmd.ExecuteNonQuery();
                return returnID;
            }
            catch
            {
                return returnID;
            }
        }
        // *** Update User Type *** //
        /// <summary>
        /// for updating type of user
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="type">type</param>
        /// <returns>int</returns>
        public static int UpdateUserType(int userID, bool type)
        {

            int returnID = 0;
            try
            {
                SqlConnection sqlconn = ConnectionManager.Instance.GetSQLConnection();
                SqlCommand cmd = new SqlCommand("Usp_ChangeUserType", sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@Type", type);
                returnID = Convert.ToInt32(cmd.ExecuteScalar());
                return returnID;
            }
            catch
            {
                return returnID;
            }
        }
        // *** Start Sales Person Operations *** //
        public static DataTable GetSalesPerson()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllSalesPerson", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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
        public static DataTable GetSalesPersonByID(int salesPersonID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetSalesPersonByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SalesPersonID", salesPersonID);
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
        public static int CreateSalesPerson(int id, string name, string firstName, string lastName, string email, string phone, DateTime effectedDate, string comments, int commissionID, int? managerID, int? comsRate, string verticals)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int returnID = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CreateSalesPerson", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SalesPersonID", id);
                sqlCmd.Parameters.AddWithValue("@Name", name);
                sqlCmd.Parameters.AddWithValue("@FirstName", firstName);
                sqlCmd.Parameters.AddWithValue("@LastName", lastName);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.Parameters.AddWithValue("@Phone", phone);
                sqlCmd.Parameters.AddWithValue("@EffectedDate", effectedDate);
                sqlCmd.Parameters.AddWithValue("@Comments", comments);
                sqlCmd.Parameters.AddWithValue("@CommissionID", commissionID);
                sqlCmd.Parameters.AddWithValue("@ManagerID", managerID);
                sqlCmd.Parameters.AddWithValue("@Percentage", comsRate);
                sqlCmd.Parameters.AddWithValue("@Verticals", verticals);
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
        public static void DeleteSalesPerson(int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteSalesPerson", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", id);
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

        public static void UpdateReferBy(int pUserID, int pReferBy)
        {
            SqlConnection sqlconn = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateReferByPerson", sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_ID", pUserID);
                cmd.Parameters.AddWithValue("@Network_ID", pReferBy);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlconn);
            }
        }


        // *** End Sales Person Operations *** //
        /// <summary>
        /// Getting profile subscription of a user
        /// </summary>
        /// <param name="pUserID">user id</param>
        /// <returns>data table</returns>
        public static DataTable GetUserProfileSubcription(int pUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileSubcription", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
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
        /// updating the user subscriprtion reccursively
        /// </summary>
        /// <param name="pIsRecurring">passed as a reference whether it is recurring or not</param>
        /// <param name="pOrderID">orderid</param>
        public static void UpdateProfileSubcriptionRecurring(bool pIsRecurring, int pOrderID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateSubcriptionRecurring", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Order_ID", pOrderID);
                sqlCmd.Parameters.AddWithValue("@IsRecurring", pIsRecurring);
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
        /// get the details of the credit card by userid
        /// </summary>
        /// <param name="pUserID">userid</param>
        /// <returns>data table</returns>
        public static DataTable GetCreditCardDetailsByUserID(int pUserID)
        {
            SqlConnection sqlcon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCreditCardDetailsByUserID", sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlAdapter.Fill(dt);
                return dt;
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

        /// <summary>
        /// for updating credit card details of a user
        /// </summary>
        /// <param name="pOrderID">order id</param>
        /// <param name="pCCNumber">credit card number</param>
        /// <param name="pFirstName">first name</param>
        /// <param name="pLastName">LastName</param>
        /// <param name="pExMonth">expiration month</param>
        /// <param name="pExYear">expiration year</param>
        /// <param name="pCvvNumber">cvv number</param>
        /// <param name="pCardType">card type</param>
        /// <param name="pAddress1">address</param>
        /// <param name="pAddress2">address</param>
        /// <param name="pCity">city</param>
        /// <param name="pState">state</param>
        /// <param name="pZipcode">zip code</param>
        public static void UpdateCreditCardDetailsByUserID(int pOrderID, string pCCNumber, string pFirstName,
            string pLastName, int pExMonth, int pExYear, string pCvvNumber, string pCardType, string pAddress1,
            string pAddress2, string pCity, string pState, string pZipcode)
        {
            SqlConnection sqlcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateCreditCardDetailsByUserID", sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OrderID", pOrderID);
                sqlCmd.Parameters.AddWithValue("@ccNumber", pCCNumber);
                sqlCmd.Parameters.AddWithValue("@ccFirstName", pFirstName);
                sqlCmd.Parameters.AddWithValue("@ccLastName", pLastName);
                sqlCmd.Parameters.AddWithValue("@ccExpiryMonth", pExMonth);
                sqlCmd.Parameters.AddWithValue("@ccExpiryYear", pExYear);
                sqlCmd.Parameters.AddWithValue("@ccCVV", pCvvNumber);
                sqlCmd.Parameters.AddWithValue("@CardType", pCardType);
                sqlCmd.Parameters.AddWithValue("@Address1", pAddress1);
                sqlCmd.Parameters.AddWithValue("@Address2", pAddress2);
                sqlCmd.Parameters.AddWithValue("@City", pCity);
                sqlCmd.Parameters.AddWithValue("@State", pState);
                sqlCmd.Parameters.AddWithValue("@Zipcode", pZipcode);

                sqlCmd.ExecuteNonQuery();
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
      
        /// <summary>
        /// for getting active commissions
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetActiveCommissions()
        {
            SqlConnection sqlcon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetActiveCommissions", sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
                sqlAdapter.Fill(dt);
                return dt;
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

        /// <summary>
        /// for getting commissions report
        /// </summary>
        /// <param name="pSalesPersonID">sales person id</param>
        /// <param name="pStartDate">start date</param>
        /// <param name="pEndDate">end date</param>
        /// <returns></returns>
        public static DataTable GetCommissionReports(int pSalesPersonID, DateTime pStartDate, DateTime pEndDate)
        {
            DataTable dtCommissionReport = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCommissionReports", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SalesPersonID", pSalesPersonID);
                sqlCmd.Parameters.AddWithValue("@StartDate", pStartDate);
                sqlCmd.Parameters.AddWithValue("@ToDate", pEndDate);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtCommissionReport);

                return dtCommissionReport;
            }
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
        /// for inserting export details of a sales commission
        /// </summary>
        /// <param name="pSalesPersonID">sales person id</param>
        /// <param name="pStartDate">start date</param>
        /// <param name="pToDate">to date</param>
        /// <param name="pUserName">user name</param>
        /// <param name="pComments">comments</param>

        public static void InsertSalesCommissionExportDetails(int pSalesPersonID, DateTime pStartDate, DateTime pToDate, string pUserName, string pComments)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlComd = new SqlCommand("usp_InsertSalesCommissionExportDetails", sqlCon);
                sqlComd.CommandType = CommandType.StoredProcedure;
                sqlComd.Parameters.AddWithValue("@SalesPersonID", pSalesPersonID);
                sqlComd.Parameters.AddWithValue("@StartDate", pStartDate);
                sqlComd.Parameters.AddWithValue("@ToDate", pToDate);
                sqlComd.Parameters.AddWithValue("@Username", pUserName);
                sqlComd.Parameters.AddWithValue("@Comments", pComments);
                sqlComd.ExecuteNonQuery();
            }
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
        /// for retreiving the account details report
        /// </summary>
        /// <param name="pStartDate">start date</param>
        /// <param name="pEndDate">end date</param>
        /// <returns>data table</returns>
        public static DataTable GetAccountsDetailsReport(DateTime pStartDate, DateTime pEndDate)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtAccountReports = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_GetAccountingReport", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StartDate", pStartDate);
                cmd.Parameters.AddWithValue("@EndDate", pEndDate);
                SqlDataAdapter adpter = new SqlDataAdapter(cmd);
                adpter.Fill(dtAccountReports);
                return dtAccountReports;
            }
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
        /// for inserting export details of the account
        /// </summary>
        /// <param name="pStartDate">start date</param>
        /// <param name="pToDate">to date</param>
        /// <param name="pUserName">user name</param>
        /// <param name="pComments">comments</param>
        public static void InsertAccountExportDetails(DateTime pStartDate, DateTime pToDate, string pUserName, string pComments)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlComd = new SqlCommand("usp_InsertAccountDetailsExport", sqlCon);
                sqlComd.CommandType = CommandType.StoredProcedure;
                sqlComd.Parameters.AddWithValue("@StartDate", pStartDate);
                sqlComd.Parameters.AddWithValue("@ToDate", pToDate);
                sqlComd.Parameters.AddWithValue("@Username", pUserName);
                sqlComd.Parameters.AddWithValue("@Comments", pComments);
                sqlComd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        #region Payment Process

        /// <summary>
        /// for placing an enquiry of transaction
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="subPeriod">subPeriod</param>
        /// <param name="totalAmt"></param>
        /// <param name="discount">totalAmt</param>
        /// <param name="billableAmt">billable amount</param>
        /// <param name="address1">address</param>
        /// <param name="address2">address</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="ccnumber">credit card number</param>
        /// <param name="ccfirstname">first name</param>
        /// <param name="cclastname">lastname</param>
        /// <param name="ccmonth">month</param>
        /// <param name="ccyear">year</param>
        /// <param name="ccvv">cvv</param>
        /// <param name="cType">type</param>
        /// <param name="country">country</param>
        /// <param name="userID">user id</param>
        /// <param name="isCard">whether it is card or not</param>
        /// <param name="checkNumber">check number</param>
        /// <param name="status">status </param>
        /// <param name="discountCode">discount code</param>
        /// <param name="purchageOrderNo">purchase order number</param>
        /// <param name="isRecurring"></param>
        /// <param name="oneTimeSetupFee">oneTimeSetupFee</param>
        /// <returns>an integer</returns>
        public static int AddInquiryTransactions(int inquiryID, int subPeriod, decimal totalAmt, decimal discount, decimal billableAmt, string address1, string address2, string city, string state, string zipcode, string ccnumber, string ccfirstname, string cclastname, int ccmonth, int ccyear, string ccvv, string cType, string country, int userID, bool isCard, string checkNumber, bool status, string discountCode, string purchageOrderNo, bool isRecurring, decimal? oneTimeSetupFee)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable vtable = new DataTable("TransFailed");
            int returnval = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_AddTransactions", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InquiryID", inquiryID);
                sqlCmd.Parameters.AddWithValue("@SubPeriod", subPeriod);
                sqlCmd.Parameters.AddWithValue("@TotalAmount", totalAmt);
                sqlCmd.Parameters.AddWithValue("@Discount", discount);
                sqlCmd.Parameters.AddWithValue("@BillableAmount", billableAmt);
                sqlCmd.Parameters.AddWithValue("@address1", address1);
                sqlCmd.Parameters.AddWithValue("@address2", address2);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@statename", state);
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipcode);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                sqlCmd.Parameters.AddWithValue("@ccnumber", ccnumber);
                sqlCmd.Parameters.AddWithValue("@ccfirstname", ccfirstname);
                sqlCmd.Parameters.AddWithValue("@cclastname", cclastname);
                sqlCmd.Parameters.AddWithValue("@ccmonth", ccmonth);
                sqlCmd.Parameters.AddWithValue("@ccyear", ccyear);
                sqlCmd.Parameters.AddWithValue("@CCVV", ccvv);
                sqlCmd.Parameters.AddWithValue("@CType", cType);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@IsCard", isCard);
                sqlCmd.Parameters.AddWithValue("@CheckNumber", checkNumber);
                sqlCmd.Parameters.AddWithValue("@Status", status);
                sqlCmd.Parameters.AddWithValue("@DiscountCode", discountCode);
                sqlCmd.Parameters.AddWithValue("@PurchageOrderNo", purchageOrderNo);
                sqlCmd.Parameters.AddWithValue("@Recurring", isRecurring);
                sqlCmd.Parameters.AddWithValue("@OneTimesetpFee", oneTimeSetupFee);
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
       
        /// <summary>
        /// for updating inquiry of a transcation
        /// </summary>
        /// <param name="orderID">order id</param>
        /// <param name="inquiryID">inquiry id</param>
        /// <param name="userID">user id</param>
        public static void UpdateInquiryTransaction(int orderID, int inquiryID, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateInquiryTransaction", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OrderID", orderID);
                sqlCmd.Parameters.AddWithValue("@InquiryID", inquiryID);
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

        /// <summary>
        /// adding invoice
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="purchaseOrderNo">purchaseOrderNo</param>
        /// <param name="invoiceEmail">invoiceEmail</param>
        /// <param name="invoiceAmount">invoiceAmount</param>
        /// <param name="package">package</param>
        /// <param name="oneTimeSetupFee">oneTimeSetupFee</param>
        /// <param name="invoiceDiscount">invoiceDiscount</param>
        /// <param name="customNotes">customNotes</param>
        /// <returns></returns>
        public static int AddCheckInvoice(int inquiryID, string purchaseOrderNo, string invoiceEmail, decimal invoiceAmount, string package, decimal? oneTimeSetupFee, decimal invoiceDiscount, string customNotes, bool isUpgrade)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable vtable = new DataTable("TransFailed");
            int returnval = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_AddCheckInvoice", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InquiryID", inquiryID);
                sqlCmd.Parameters.AddWithValue("@PurchaseOrderNo", purchaseOrderNo);
                sqlCmd.Parameters.AddWithValue("@InvoiceEmail", invoiceEmail);
                sqlCmd.Parameters.AddWithValue("@InvoiceAmount", invoiceAmount);
                sqlCmd.Parameters.AddWithValue("@Package", package);
                sqlCmd.Parameters.AddWithValue("@OneTimeSetupFee", oneTimeSetupFee);
                sqlCmd.Parameters.AddWithValue("@InvoiceDiscount", invoiceDiscount);
                sqlCmd.Parameters.AddWithValue("@CustomNotes", customNotes);
                sqlCmd.Parameters.AddWithValue("@IsUpgrade", isUpgrade);
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
    
        /// <summary>
        /// adding subscription package 
        /// </summary>
        /// <param name="inquiryID">inquiry id</param>
        /// <param name="package">package</param>
        public static void AddSubscriptionPackage(int inquiryID, string package)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_AddSubscriptionPackage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InquiryID", inquiryID);
                sqlCmd.Parameters.AddWithValue("@Package", package);
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
        /// getting invoice for an inquiry
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <returns>data table</returns>
        public static DataTable GetInquiryInvoice(int inquiryID, bool isUpgrade)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtAccountReports = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_GetInquiryInvoice", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InquiryID", inquiryID);
                cmd.Parameters.AddWithValue("@IsUpgrade", isUpgrade);
                SqlDataAdapter adpter = new SqlDataAdapter(cmd);
                adpter.Fill(dtAccountReports);
                return dtAccountReports;
            }
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
        /// for updating  verifystatus
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="verifyStatus">verifyStatus</param>
        public static void UpdateVerifyStatus(int inquiryID, string verifyStatus, bool isUpgrade)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateVerifyStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InquiryID", inquiryID);
                sqlCmd.Parameters.AddWithValue("@VerifyStatus", verifyStatus);
                sqlCmd.Parameters.AddWithValue("@IsUpgrade", isUpgrade);
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
        /// for filling training users data
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable FillTrainingUsersData()
        {
            DataTable utable = new DataTable("UserData");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetTrainingUsersData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(utable);
                return utable;
            }
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
        /// retrieving notes count
        /// </summary>
        /// <param name="inquiryId">inquiryId</param>
        /// <returns>integer</returns>
        public static int GetNotesCountById(int inquiryId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int returnID = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetNotesCountById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InquiryId", inquiryId);
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
        #endregion
        // *** Start Sales Person Operations *** //
        /// <summary>
        /// Getting sales persons manager details
        /// </summary>
        /// <returns>datatable</returns>
        public static DataTable GetSalesPersonManagers()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllSalesPersonManagers", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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
        /// for checking the credentials of admin
        /// </summary>
        /// <param name="username">user name</param>
        /// <param name="password">password</param>
        /// <returns>integer</returns>
        public static int CheckAdminUser(string username, string password)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int validUser = 0; // *** 0 means in valid user *** //
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckAdminUser", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Username", username);
                sqlCmd.Parameters.AddWithValue("@Password", password);
                validUser = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return validUser;
            }
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
        /// for inserting promocode
        /// </summary>
        /// <param name="pDoaminName">domain name</param>
        /// <param name="isSingle">isSingle</param>
        /// <param name="pAllowedCount">allowed amount</param>
        /// <param name="isAutoGenerated">whether it is auto generted or not </param>
        /// <param name="pPromocodeName">name of promo code</param>
        /// <param name="productId">product id</param>
        /// <param name="productPrice">product price</param>
        /// <param name="productAmtCharged">amount charged for product</param>
        /// <param name="setupFee">setupfee</param>
        /// <param name="setupFeeCharged">setupFeeCharged</param>
        /// <param name="isLifeTime">isLifeTime</param>
        /// <param name="initialFirst">initialFirst</param>
        /// <param name="initialLast">initialLast</param>
        /// <param name="pPromocodeExDate">PromocodeExDate</param>
        /// <param name="pDescription">Description</param>
        /// <param name="pValidFor">valid for</param>
        /// <param name="pCreatedUser">created user</param>
        /// <param name="pDuration">duration</param>
        /// <param name="pIsProduct">product</param>
        /// <param name="isDollarAmount">dollar amount</param>
        /// <returns>string</returns>
        public static string InsertPromoCode(string pDoaminName, bool isSingle, int pAllowedCount, bool isAutoGenerated, string pPromocodeName, int productId, decimal productPrice, decimal productAmtCharged, decimal? setupFee, decimal? setupFeeCharged, bool isLifeTime, string initialFirst, string initialLast,
            DateTime pPromocodeExDate, string pDescription, int pValidFor, int pCreatedUser, int? pDuration, bool pIsProduct, bool isDollarAmount)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            string id = "0";
            try
            {
                SqlCommand sqlComd = new SqlCommand("usp_InsertPromocodes", sqlCon);
                sqlComd.CommandType = CommandType.StoredProcedure;
                sqlComd.Parameters.AddWithValue("@DoaminName", pDoaminName);
                sqlComd.Parameters.AddWithValue("@IsSingle", isSingle);
                sqlComd.Parameters.AddWithValue("@AllowedCount", pAllowedCount);
                sqlComd.Parameters.AddWithValue("@IsAutoGenerated", isAutoGenerated);
                sqlComd.Parameters.AddWithValue("@Promocode_Name", pPromocodeName);
                sqlComd.Parameters.AddWithValue("@ProductId", productId);
                sqlComd.Parameters.AddWithValue("@ProductPrice", productPrice);
                sqlComd.Parameters.AddWithValue("@ProductAmountCharged", productAmtCharged);
                sqlComd.Parameters.AddWithValue("@SetupFee", setupFee);
                sqlComd.Parameters.AddWithValue("@SetupFeeCharged", setupFeeCharged);
                sqlComd.Parameters.AddWithValue("@IsLifeTime", isLifeTime);
                sqlComd.Parameters.AddWithValue("@InitialFirst", initialFirst);
                sqlComd.Parameters.AddWithValue("@InitialLast", initialLast);
                sqlComd.Parameters.AddWithValue("@PromoCode_ExpiryDate", pPromocodeExDate);
                sqlComd.Parameters.AddWithValue("@Promocode_Desc", pDescription);
                sqlComd.Parameters.AddWithValue("@Promocode_ValidFor", pValidFor);
                sqlComd.Parameters.AddWithValue("@Created_User", pCreatedUser);                
                sqlComd.Parameters.AddWithValue("@Duration", pDuration);
                sqlComd.Parameters.AddWithValue("@IsProduct", pIsProduct);
                sqlComd.Parameters.AddWithValue("@IsDollarAmount", isDollarAmount);
                id = Convert.ToString(sqlComd.ExecuteScalar());
                return id;
            }
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
        /// for generating new code
        /// </summary>
        /// <returns>string</returns>
        public static string GenerateNewPromocode()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            string pcode = "";

            try
            {
                SqlCommand sqlComd = new SqlCommand("usp_GenerateNewPromocode", sqlCon);
                sqlComd.CommandType = CommandType.StoredProcedure;
                pcode = Convert.ToString(sqlComd.ExecuteScalar());
                return pcode;
            }
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
        /// retrieving all promocodes
        /// </summary>
        /// <param name="pUserID">userid</param>
        /// <param name="type">type</param>
        /// <returns>data table</returns>
        public static DataTable GetAllPromocodes(int pUserID, string type)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("dbo.usp_GetAllPromoCodes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
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
        /// for validating promocode
        /// </summary>
        /// <param name="promoCode">promocode</param>
        /// <param name="inquiryID">inquiry id</param>
        /// <returns></returns>
        public static DataTable ValidatePromoCode(string promoCode, int inquiryID, bool isUpgrade)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ValidatePromoCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PromoCode", promoCode);
                sqlCmd.Parameters.AddWithValue("@inquiryID", inquiryID);
                sqlCmd.Parameters.AddWithValue("@IsUpgrade", isUpgrade);
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
        /// retrieving bussiness access codes
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetBusinessAccessCodes()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAccessCodeInfo", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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
        /// for deleting access codes
        /// </summary>
        /// <param name="ProfileID">profile id</param>
        /// <param name="type">type</param>
        /// <param name="AccessCode">access code</param>
        /// <returns>integer</returns>
        public static int DeleteAccessCodes(int ProfileID, string type, string AccessCode)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int i = 1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteAccessCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@Type", type);
                sqlCmd.Parameters.AddWithValue("@AccessCode", AccessCode);
                sqlCmd.ExecuteNonQuery();
                return i;
            }
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
        /// for creating and updating access codes 
        /// </summary>
        /// <param name="ProfileID">profile id</param>
        /// <param name="AccessCode">access code</param>
        /// <param name="isDelete">whether is deleted or not</param>
        /// <returns>integer</returns>
        public static int CreateUpdateAccessCodes(int ProfileID, string AccessCode, bool isDelete)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int i = 1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CreateUpdateAccessCodes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@AccessCode", AccessCode);
                sqlCmd.Parameters.AddWithValue("@IsDelete", isDelete);
                sqlCmd.ExecuteNonQuery();
                return i;
            }
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
        /// getting customer service users
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetCSUsers()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCSUsers", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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
        /// for extending subscription period
        /// </summary>
        /// <param name="profileID">profileid</param>
        /// <param name="memberID">member id</param>
        /// <param name="updateRenewDate">updaterenewal date</param>
        /// <returns>integer</returns>
        public static int ExtendSubscriptionPeriod(int profileID, int memberID, DateTime updateRenewDate)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int i = 1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ExtendSubscriptionPeriod", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@MemberID", memberID);
                sqlCmd.Parameters.AddWithValue("@ExtendRenewDate", updateRenewDate);
                sqlCmd.ExecuteNonQuery();
                return i;
            }
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
        /// for storing preserving subscription renewal date
        /// </summary>
        /// <param name="textSubscription">subscription text</param>
        /// <param name="renewDate">renewal date</param>
        public static void PreserveSubscriptionRenewDates(string textSubscription, DateTime renewDate)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertLog", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@textSubscription", textSubscription);
                sqlCmd.Parameters.AddWithValue("@renewDate", renewDate);
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
        /// for checking admin user details
        /// </summary>
        /// <param name="username">user name</param>
        /// <returns>data table</returns>
        public static DataTable GetAdminUserDetailsCheck(string username)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AdminUserDetailsCheck", sqlCon);
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

        /// <summary>
        /// get admin details check
        /// </summary>
        /// <param name="AdminUserID">admin user id</param>
        /// <returns>data table</returns>
        public static DataTable GetAdminDetailsCheck(int AdminUserID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAdminDetailsCheck", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AdminID", AdminUserID);

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
        /// for retreiving latest login details of associates
        /// </summary>
        /// <param name="parentID">parent id</param>
        /// <param name="parentLastLogin">Paret last login</param>
        /// <returns>data table</returns>
        public static DataTable GetAssociateLatestLogin(int parentID, DateTime parentLastLogin)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetLatestLoginDateTime", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@parentID", parentID);
                sqlCmd.Parameters.AddWithValue("@parentLoginDate", parentLastLogin);
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
        // *** Archive User *** //
        /// <summary>
        /// for archiveing a user
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="type">type</param>
        /// <returns>integer</returns>
        public static int ArchiveUser(int userID, bool type)
        {

            int returnID = 0;
            try
            {
                SqlConnection sqlconn = ConnectionManager.Instance.GetSQLConnection();
                SqlCommand cmd = new SqlCommand("Usp_ArchiveUser", sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@Type", type);
                returnID = Convert.ToInt32(cmd.ExecuteScalar());
                return returnID;
            }
            catch
            {
                return returnID;
            }
        }
        /// <summary>
        /// checking for sub app 
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>string</returns>
        public static string CheckSubApp(int userId)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            //SqlQuery = SqlQuery.Replace("'", "''");
            //SqlQuery = SqlQuery.Replace("''", "'");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckSubApp", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserId", userId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable.Rows.Count > 0)
                {
                    string userID = vtable.Rows[0]["User_ID"].ToString();
                    return "Yes," + userID;
                }
                else
                    return "No";
            }
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
        /// retrieving all active sub apps
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetAllActiveSubApps()
        {
            DataTable dtActiveSubApps = new DataTable("dtactiveSubapps");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllActiveSubApps", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtActiveSubApps);

                return dtActiveSubApps;
            }
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
        /// getting customer desk notes report
        /// </summary>
        /// <param name="pSearchType">search type</param>
        /// <param name="pSearchStr">search string</param>
        /// <param name="pStartDate">start date</param>
        /// <param name="pEndDate">end date</param>
        /// <returns>data table</returns>
        public static DataTable GetCSNotesReportData(string pSearchType, string pSearchStr, DateTime pStartDate, DateTime pEndDate)
        {
            DataTable vtable = new DataTable("CSNotes");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCSNotesReportData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SearchTypeID", pSearchType);
                sqlCmd.Parameters.AddWithValue("@SearchStr", pSearchStr);
                sqlCmd.Parameters.AddWithValue("@FromDate", pStartDate);
                sqlCmd.Parameters.AddWithValue("@EndDate", pEndDate);
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
        /// get all webinars
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetAllWebnairs()
        {
            DataTable vtable = new DataTable("Webnairs");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllWebnairs", sqlCon);
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

        /// <summary>
        /// Get all registrations by tip id
        /// </summary>
        /// <param name="systemTipId">system tip id</param>
        /// <param name="webnairtitle">webinar article</param>
        /// <returns></returns>
        public static DataTable GetAllRegistrationsByTipId(int systemTipId, out string webnairtitle)
        {
            DataTable vtable = new DataTable("Registrations");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllRegistrationsByTipId", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SystemTipId", systemTipId);
                sqlCmd.Parameters.Add(new SqlParameter("@Webnairtitle", SqlDbType.VarChar, 500)).Direction = ParameterDirection.Output;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                webnairtitle = sqlCmd.Parameters["@Webnairtitle"].Value.ToString();
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
        /// getting all emails based on tip id
        /// </summary>
        /// <param name="systemTipId">system tip id</param>
        /// <param name="webnairtitle">webinar title</param>
        /// <returns></returns>
        public static DataTable GetAllEmailsByTipId(int systemTipId, out string webnairtitle)
        {
            DataTable vtable = new DataTable("Registrations");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllEmailsByTipId", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SystemTipId", systemTipId);
                sqlCmd.Parameters.Add(new SqlParameter("@Webnairtitle", SqlDbType.VarChar, 500)).Direction = ParameterDirection.Output;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                webnairtitle = sqlCmd.Parameters["@Webnairtitle"].Value.ToString();
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
        /// retrieving data of members whose subscription/membership ending
        /// </summary>
        /// <param name="fromDate">from date</param>
        /// <param name="toDate">ro date</param>
        /// <returns>data table</returns>
        public static DataTable GetExipirationMembers(DateTime fromDate, DateTime toDate)
        {
            DataTable vtable = new DataTable("ExpirationMembers");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetExipirationMembers", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FromDate", fromDate);
                sqlCmd.Parameters.AddWithValue("@ToDate", toDate);
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
        /// get the dat aof branded app users
        /// </summary>
        /// <param name="vertical">vertical</param>
        /// <param name=""userId>userId</param>
        /// <param name="profileName">profileName</param>
        /// <returns>data table</returns>
        public static DataTable GetBrandedAppUsers(string vertical, int? userId, string profileName)
        {
            DataTable vtable = new DataTable("ExpirationMembers");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBrandedAppUsers", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
                sqlCmd.Parameters.AddWithValue("@UserId", userId);
                sqlCmd.Parameters.AddWithValue("@ProfileName", profileName);
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
        /// updating app version of branded app 
        /// </summary>
        /// <param name="brandedOrderId">brandedOrderId</param>
        /// <param name="version">version</param>
        public static void UpdateMemberAppVersion(int brandedOrderId, string version)
        {
            SqlConnection sqlconn = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateMemberAppVersion", sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BrandedOrderId", brandedOrderId);
                cmd.Parameters.AddWithValue("@Version", version);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlconn);
            }
        }

        /// <summary>
        /// getting the data of additional request for branded app
        /// </summary>
        /// <param name="brandedAppOrderId">brandedAppOrderId</param>
        /// <returns>data table</returns>
        public static DataTable GetBrandedAppAdditionalRequest(int brandedAppOrderId)
        {
            DataTable dtAddRequests = new DataTable();
            SqlConnection sqlconn = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetBrandedAppAdditionalRequest", sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BrandedAppOrderId", brandedAppOrderId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(cmd);
                sqlAdptr.Fill(dtAddRequests);
                return dtAddRequests;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlconn);
            }
        }

        /// <summary>
        /// getting the data of additional request for branded app
        /// </summary>
        /// <param name="brandedAppRequestID">brandedAppRequestID</param>
        /// <returns>data table</returns>
        public static DataTable GetBrandedAppRequestByRequestID(int brandedAppRequestID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBrandedAppRequestByRequestID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BrandedAppRequestID", brandedAppRequestID);
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

        public static int InsertActivityLog(int activityId, string Title, string editHTML, string previewHtml, string DomainName, int? ProfileID, DateTime? expiryDate)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int returnID = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertActivityLog", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ActivityID", activityId);
                sqlCmd.Parameters.AddWithValue("@ActivityTitle", Title);
                sqlCmd.Parameters.AddWithValue("@EditPreviewHtml", editHTML);
                sqlCmd.Parameters.AddWithValue("@PreviewHtml", previewHtml);
                sqlCmd.Parameters.AddWithValue("@Vertical", DomainName);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);
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


        public static void DeleteActivityLog(int activityID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DeleteActivityLog", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ActivityID", activityID);

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


        #region Manage Sales Code
        public static DataTable GetManageSalesCode()
        {
            DataTable dtSalesCode = new DataTable();
            SqlConnection sqlconn = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("USP_GetManageSalesCode", sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(cmd);
                sqlAdptr.Fill(dtSalesCode);
                return dtSalesCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlconn);
            }
        }

        public static void DeleteSalesCode(int ConfigId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeleteSalesCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ConfigId", ConfigId);

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
        public static DataTable GetNamesByRoleID(int RoleId)
        {
            DataTable dtNames = new DataTable();
            SqlConnection sqlconn = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("USP_GetNamesByRoleID", sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleId", RoleId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(cmd);
                sqlAdptr.Fill(dtNames);
                return dtNames;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlconn);
            }
        }
        public static void InsertChannelPartnerDetails(string FirstName,string LastName,string CompanyName,string Address, string City,string State,int ZipCode,string EmailId,string WebSite,int RoleID,
            string PhoneNumber,string Extension)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertChannelPartnerDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FirstName", FirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", LastName);
                sqlCmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                sqlCmd.Parameters.AddWithValue("@Address", Address);
                sqlCmd.Parameters.AddWithValue("@City", City);
                sqlCmd.Parameters.AddWithValue("@State", State);
                sqlCmd.Parameters.AddWithValue("@Zipcode", ZipCode);
                sqlCmd.Parameters.AddWithValue("@EmailAddress ", EmailId);
                sqlCmd.Parameters.AddWithValue("@Website", WebSite);
                sqlCmd.Parameters.AddWithValue("@RoleId", RoleID);
                sqlCmd.Parameters.AddWithValue("@PhoneNumber ", PhoneNumber);
                sqlCmd.Parameters.AddWithValue("@PhoneExtension", Extension);

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


        public static int InsertSalesPersonDetails(string SalesCode, int LTManagerId, int LTManagerCommission, int ChannelPartnerId, int ChannelPartnerCommission, int ChannelManagerId,
            int ChannelManagerCommission, int ChannelAffiliateId, int ChannelAffiliateCommission, DateTime AgreementDate, DateTime AgreementExpiryDate, int UserID, string Notes, string CreatedByName, string ApprovedBy)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int ConfigID = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertSalesPersonDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SalesCode", SalesCode);
                sqlCmd.Parameters.AddWithValue("@LTManagerId", LTManagerId);
                sqlCmd.Parameters.AddWithValue("@LTManagerCommission", LTManagerCommission);
                sqlCmd.Parameters.AddWithValue("@ChannelPartnerId", ChannelPartnerId);
                sqlCmd.Parameters.AddWithValue("@ChannelPartnerCommission", ChannelPartnerCommission);
                sqlCmd.Parameters.AddWithValue("@ChannelManagerId", ChannelManagerId);
                sqlCmd.Parameters.AddWithValue("@ChannelManagerCommission", ChannelManagerCommission);
                sqlCmd.Parameters.AddWithValue("@ChannelAffiliateId ", ChannelAffiliateId);
                sqlCmd.Parameters.AddWithValue("@ChannelAffiliateCommission", ChannelAffiliateCommission);
                sqlCmd.Parameters.AddWithValue("@AgreementDate", AgreementDate);
                sqlCmd.Parameters.AddWithValue("@AgreementExpiryDate", AgreementExpiryDate);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@Notes", Notes);
                sqlCmd.Parameters.AddWithValue("@CreatedByName", CreatedByName);
                sqlCmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy);

                ConfigID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return ConfigID;
            }
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

        public static DataTable GetRecurringTransactionDetails()
        {
            DataTable vtable = new DataTable("ExpirationMembers");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("ser_getRecurringTransactionDetails", sqlCon);
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

        public static DataTable getBillMeProfileDetails()
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_getBillMeProfileDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
               
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
        public static DataTable getBillMedetailsbySubID(int SubcriptionID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_getBillMedetailsbySubID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SubscriptionId", SubcriptionID);
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
        public static void insertInvoiceSendHistory(int ProfileID, int UserID, decimal RenewalAmount,string InitialName,string Remarks)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertInvoiceSentDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@UserId", UserID);
                sqlCmd.Parameters.AddWithValue("@RenewalAmount", RenewalAmount);
                sqlCmd.Parameters.AddWithValue("@InitialName", InitialName);
                sqlCmd.Parameters.AddWithValue("@Remarks", Remarks);
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

        public static DataTable GetPromocodesBySearch(string Vertical, string SearchText, string TabValue, string fromDate, string toDate)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPromocodesBySearch", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Vertical", Vertical);
                sqlCmd.Parameters.AddWithValue("@SearchText", SearchText);
                sqlCmd.Parameters.AddWithValue("@TabValue", TabValue);
                sqlCmd.Parameters.AddWithValue("@FromDate", fromDate);
                sqlCmd.Parameters.AddWithValue("@ToDate", toDate);
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

        public static void ArchivePromocodes(bool IsArchive, int PromocodeID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdatePromocodesforArchive", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@IsArchive", IsArchive);
                sqlCmd.Parameters.AddWithValue("@PromoCodeId", PromocodeID);
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

        public static DataTable GetStoreItems_Renewal(int pProfileID)
        {
            DataTable dt = new DataTable("dtstore");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllModulesByProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
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
        public static int UpdatePackageItems(int pUserModuleID, DateTime pRenewalDate, int pProfileID, int pUserID, int orderDetailsID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int orderID = 0;
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand("USP_UpdatePackageItem_Renewal", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@UserModuleID", pUserModuleID);
                    sqlCmd.Parameters.AddWithValue("@RenewalDate", pRenewalDate);
                    sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                    sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                    orderID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                }
                return orderID;
            }
            catch (Exception ex)
            {
                CommonDAL.InsertErrorLog("ERROR", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "BusinessDAL", "InsertOrderDetails");
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetResellerDetailsByConfigID(int ConfigID)
        {

            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetResellerDetailsByConfigID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ConfigID", ConfigID);
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
