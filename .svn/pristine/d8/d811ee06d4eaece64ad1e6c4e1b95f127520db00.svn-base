using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace USPDHUBDAL
{
    public class BusinessDAL : DataAccess
    {
        //Issue No: #85
        //27-12-08
        //Lavanya
        /// <summary>
        /// For validating tab invitations
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="email">email</param>
        /// <returns>Data table</returns>
        public static DataTable Validategtabinvitations(int profileid, string email)
        {
            DataTable dtinv = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_validategtabinvitation", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@profileID", profileid);
                sqlCmd.Parameters.AddWithValue("@email", email);
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


        public static DataTable Validateaffinvitations(int profileid, string email)
        {
            DataTable dtinv = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_validateaffinvitation", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@profileID", profileid);
                sqlCmd.Parameters.AddWithValue("@email", email);
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
        /// getting reviews by review id
        /// </summary>
        /// <param name="reviewid">reviewid</param>
        /// <returns>data table</returns>
        public static DataTable GetReviewsbyreviewid(int reviewid)
        {
            DataTable dtReviews = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetProfileReviewsbyReviewID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@ReviewID", reviewid);

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtReviews);

                return dtReviews;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

        }

        public static DataTable GetAffinvcount(int userid)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_Getinvitationscount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userid", userid);

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
        /// For getting subscriptions by type
        /// </summary>
        /// <param name="subtype">subtype</param>
        /// <returns>data table</returns>
        public static DataTable GetSubscriptionsbyType(int subtype)
        {
            DataTable subtypes = new DataTable("subtypes");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSubscriptionDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@typeID", subtype);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(subtypes);

                return subtypes;
            }
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
        /// For getting order subsciptions by profile id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetOrderSubscriptionByProfileID(int profileID)
        {
            DataTable subtypes = new DataTable("subtypes");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetOrderSubscriptionByProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(subtypes);

                return subtypes;
            }
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
        /// for adding a bussiness user
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
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone">phone</param>
        /// <param name="userid">userid</param>
        /// <param name="status">status</param>
        /// <param name="isFree">isFree</param>
        /// <returns>integer</returns>
        public static int AddBusinessUser(string username, string password, string email, string firstname, string lastname, string pswdQ1, string pswdA1, string pswdQ2, string pswdA2, int roleId, bool isActive, string addr1, string addr2, string city, string state, string country, string zipcode, string phone, int userid, string status, Boolean isFree)
        {
            DataTable vtable = new DataTable("business");
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
        /// For deleting subscription order
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <returns>integer</returns>
        public static int DeleteSubscriptionOrder(int orderID)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteProfileSubscriptionOrder", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OrderID", orderID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                //if (vtable != null)
                //{
                //  returnval = Convert.ToInt32(vtable.Rows[0][0]);
                //}

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
        /// For validating user
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>data table</returns>
        public static DataTable ValidateUser(string username, string password)
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

        /// <summary>
        /// For retrieving all main industry categories
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetAllMainIndustryCategories()
        {
            DataTable vtable = new DataTable("indus");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetMainIndustryCategories", sqlCon);
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
        /// for getting user details by user id
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>data table</returns>
        public static DataTable GetUserDetailsByUserID(int userID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserDetailsByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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

        /// <summary>
        /// adding a business profile
        /// </summary>
        /// <param name="buzname">business name</param>
        /// <param name="websitename">websitename</param>
        /// <param name="email">email</param>
        /// <param name="description">description</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="country">country</param>
        /// <param name="categories">categories</param>
        /// <param name="isActive">isActive</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone1">phone1</param>
        /// <param name="searchindustries">searchindustries</param>
        /// <param name="searchcities">searchcities</param>
        /// <param name="searchstates">searchstates</param>
        /// <param name="status">status</param>
        /// <param name="membership">membership</param>
        /// <param name="userid">userid</param>
        /// <param name="profileid">profileid</param>
        /// <param name="verificationtype">verificationtype</param>
        /// <param name="id">id</param>
        /// <returns>Integer</returns>
        public static int AddBusinessProfile(string buzname, string websitename, string email, string description, string address1, string address2, string city, string state, string country, string categories, bool isActive, string zipcode, string phone1, string searchindustries, string searchcities, string searchstates, string status, int membership, int userid, int profileid, string verificationtype, int id)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageBusinessProfile1", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profilename", buzname);
                sqlCmd.Parameters.AddWithValue("@Websitename", websitename);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.Parameters.AddWithValue("@description", description);
                sqlCmd.Parameters.AddWithValue("@address1", address1);
                sqlCmd.Parameters.AddWithValue("@address2", address2);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@State", state);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                sqlCmd.Parameters.AddWithValue("@Categories", categories);
                sqlCmd.Parameters.AddWithValue("@Catlistvals", searchindustries);
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipcode);
                sqlCmd.Parameters.AddWithValue("@phone1", phone1);
                sqlCmd.Parameters.AddWithValue("@Searchcities", searchcities);
                sqlCmd.Parameters.AddWithValue("@SearchStates", searchstates);
                sqlCmd.Parameters.AddWithValue("@status", status);
                sqlCmd.Parameters.AddWithValue("@membership", membership);
                sqlCmd.Parameters.AddWithValue("@UserID", userid);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileid);
                sqlCmd.Parameters.AddWithValue("@IsActive", isActive);
                sqlCmd.Parameters.AddWithValue("@Verificationtype", verificationtype);
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

        /// <summary>
        /// Foe retrieving profile details by profile id
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
        /// for getting subscription details by name 
        /// </summary>
        /// <param name="subname">subname</param>
        /// <returns>data table</returns>
        public static DataTable GetSubscriptionDetailsByName(string subname)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSubscriptionByName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Subname", subname);
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
        /// for getting discount details by discount code
        /// </summary>
        /// <param name="discCode">discCode</param>
        /// <returns>data table</returns>
        public static DataTable GetDiscountDetailsByCode(string discCode)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetDiscountDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DiscCode", discCode);
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
        /// for adding business profiles by order
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="subscribeID">subscribeID</param>
        /// <param name="price">price</param>
        /// <param name="ecitiescost">ecitiescost</param>
        /// <param name="einduscost">einduscost</param>
        /// <param name="discCode">discCode</param>
        /// <param name="discamt">discamt</param>
        /// <param name="totalamt">totalamt</param>
        /// <param name="taxamt">totalamt</param>
        /// <param name="billableamt">billableamt</param>
        /// <param name="period">period</param>
        /// <param name="startdate">startdate</param>
        /// <param name="enddate">enddate</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="country">country</param>
        /// <param name="ptype">ptype</param>
        /// <param name="ccnumber">card number</param>
        /// <param name="ccfirstname">first name on card</param>
        /// <param name="cclastname">last name on card</param>
        /// <param name="ccmonth">expiry month</param>
        /// <param name="ccyear">year</param>
        /// <param name="ccvv">cvv number</param>
        /// <param name="cType">card type</param>
        /// <param name="isRecurring">isRecurring</param>
        /// <returns>Integer</returns>
        public static int AddBusinessProfileOrder(int profileID, int userID, int subscribeID, decimal price, decimal ecitiescost, decimal einduscost, string discCode, decimal discamt, decimal totalamt, decimal taxamt, decimal billableamt, int period, string startdate, string enddate, string address1, string address2, string city, string state, string zipcode, string country, string ptype, string ccnumber, string ccfirstname, string cclastname, int ccmonth, int ccyear, string ccvv, string cType, bool isRecurring)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AddBusinessProfileOrder", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@SubcribeID", subscribeID);
                sqlCmd.Parameters.AddWithValue("@Price", price);
                sqlCmd.Parameters.AddWithValue("@Ecitycost", ecitiescost);
                sqlCmd.Parameters.AddWithValue("@EInduscost", einduscost);
                sqlCmd.Parameters.AddWithValue("@DiscCode", discCode);
                sqlCmd.Parameters.AddWithValue("@DiscAmount", discamt);
                sqlCmd.Parameters.AddWithValue("@totalamount", totalamt);
                sqlCmd.Parameters.AddWithValue("@Tax", taxamt);
                sqlCmd.Parameters.AddWithValue("@billAmount", billableamt);
                sqlCmd.Parameters.AddWithValue("@period", period);
                sqlCmd.Parameters.AddWithValue("@startdate", startdate);
                sqlCmd.Parameters.AddWithValue("@enddate", enddate);
                sqlCmd.Parameters.AddWithValue("@address1", address1);
                sqlCmd.Parameters.AddWithValue("@address2", address2);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@statename", state);
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipcode);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                sqlCmd.Parameters.AddWithValue("@ptype", ptype);
                sqlCmd.Parameters.AddWithValue("@ccnumber", ccnumber);
                sqlCmd.Parameters.AddWithValue("@ccfirstname", ccfirstname);
                sqlCmd.Parameters.AddWithValue("@cclastname", cclastname);
                sqlCmd.Parameters.AddWithValue("@ccmonth", ccmonth);
                sqlCmd.Parameters.AddWithValue("@ccyear", ccyear);
                sqlCmd.Parameters.AddWithValue("@CCVV", ccvv);
                sqlCmd.Parameters.AddWithValue("@CType", cType);
                sqlCmd.Parameters.AddWithValue("@IsRecurring", isRecurring);
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
        /// For updating bussiness profile status
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="isActive">isActive</param>
        /// <param name="strresponse">strresponse</param>
        /// <returnsinteger></returns>
        public static int UpdateBusinessProfileStatus(int orderID, int profileID, int userID, bool isActive, string strresponse)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpDateBusinessProfileOrderStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OrderID", orderID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@Isactive", isActive);
                sqlCmd.Parameters.AddWithValue("@Responsestr", strresponse);

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
        /// For updating view profile status
        /// </summary>
        /// <param name="ipaddress">ipaddress</param>
        /// <param name="profileID">profileID</param>
        /// <param name="sesID">sesID</param>
        /// <returns>Integer</returns>
        public static int UpdateViewProfileStats(string ipaddress, int profileID, string sesID)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertProfileStats", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@IPAddress", ipaddress);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@sesID", sesID);
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
        /// For retrieving profiles by id       
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <returns>Data table</returns>
        public static DataTable GetProfileOrderByID(int orderID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileOrderByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OrderID", orderID);
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
        /// For cancelling business registrtaions by id
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <returns>Integer</returns>
        public static int CancelBusinessRegistraionByID(int orderID)
        {
            int returnval = 0;
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CancelBusinessRegistrationByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OrderID", orderID);
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
        /// For retrieving business profiles by user id
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>Data table</returns>
        public static DataTable GetBusinessProfileByUserID(int userID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBusinessProfileByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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

        /// <summary>
        /// For retrieving business affiliates 
        /// </summary>
        /// <param name="top5Flag"top5Flag></param>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetBusinessAffiliates(bool top5Flag, int profileID)
        {
            DataTable affs = new DataTable("aff");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileAffiliates", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@top5flag", top5Flag);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(affs);

                return affs;
            }
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
        /// For retrieving business links
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetBusinessLinks(bool top5Flag, int profileID)
        {
            DataTable links = new DataTable("links");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileBusinessLinks", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@top5flag", top5Flag);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(links);

                return links;
            }
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
        /// Gor retrieving business names by profileid
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>string</returns>
        public static string GetBusinessNameByProfileID(int profileID)
        {
            string returnval = string.Empty;
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileNameByProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable != null && vtable.Rows.Count > 0)
                {
                    returnval = Convert.ToString(vtable.Rows[0][0]);
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
        /// For updating business profile details
        /// </summary>
        /// <param name="buzname">business name</param>
        /// <param name="description">description</param>
        /// <param name="contactname">contactname</param>
        /// <param name="bdays">bdays</param>
        /// <param name="bhours">bhours</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone1">phone1</param>
        /// <param name="extection">extection</param>
        /// <param name="fax">fax</param>
        /// <param name="userid">userid</param>
        /// <param name="profileid">profileid</param>
        /// <returns>Integer</returns>
        public static int UpdateBusinessProfileDetails(string buzname, string description, string contactname, string bdays, string bhours, string address1, string address2, string city, string state, string zipcode, string phone1, string extection, string fax, int userid, int profileid)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateBusinessProfile", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profilename", buzname);
                sqlCmd.Parameters.AddWithValue("@description", description);
                sqlCmd.Parameters.AddWithValue("@contactname", contactname);
                sqlCmd.Parameters.AddWithValue("@Bdays", bdays);
                sqlCmd.Parameters.AddWithValue("@Bhours", bhours);
                sqlCmd.Parameters.AddWithValue("@address1", address1);
                sqlCmd.Parameters.AddWithValue("@address2", address2);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@State", state);
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipcode);
                sqlCmd.Parameters.AddWithValue("@phone1", phone1);
                sqlCmd.Parameters.AddWithValue("@extenction", extection);
                sqlCmd.Parameters.AddWithValue("@fax", fax);
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

        /// <summary>
        /// For updating business profile logo
        /// </summary>
        /// <param name="logopath">logopath</param>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="id">id</param>
        /// <returns>Integer</returns>
        public static int UpdateBusinessProfileLogo(string logopath, int profileID, int userID, int id)
        {
            int returnval = 0;
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateBusinessLogo", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@LogoPath", logopath);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable != null && vtable.Rows.Count > 0)
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
        /// For managing business profile photos
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="photoname">photoname</param>
        /// <param name="photonum">photonum</param>
        /// <param name="imagepath">imagepath</param>
        /// <param name="primeflag">primeflag</param>
        /// <param name="isactive">isactive</param>
        /// <param name="userID">userID</param>
        /// <param name="photoIDval">photoIDval</param>
        /// <param name="tType">tType</param>
        /// <param name="imgdesc">imgdesc</param>
        /// <param name="imageOrderNo">imageOrderNo</param>
        /// <param name="id">id</param>
        /// <returns>Integer</returns>
        public static int ManageBusinessProfilePhotos(int profileID, string photoname, int photonum, string imagepath, bool primeflag,
            bool isactive, int userID, int photoIDval, int tType, string imgdesc, decimal imageOrderNo, int id)
        {
            int returnval = 0;
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageBusinessPhotos", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@Photoname", photoname);
                sqlCmd.Parameters.AddWithValue("@photonum", photonum);
                sqlCmd.Parameters.AddWithValue("@imagepath", imagepath);
                sqlCmd.Parameters.AddWithValue("@primeflag", primeflag);
                sqlCmd.Parameters.AddWithValue("@IsActive", isactive);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@PhotoID", photoIDval);
                sqlCmd.Parameters.AddWithValue("@TType", tType);
                sqlCmd.Parameters.AddWithValue("@imagedesc", imgdesc);
                sqlCmd.Parameters.AddWithValue("@ImageOrderNo", imageOrderNo);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable != null && vtable.Rows.Count > 0)
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
        /// For managing business profile videos
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="videoname">videoname</param>
        /// <param name="videopath">videopath</param>
        /// <param name="videotype">videotype</param>
        /// <param name="primeflag">primeflag</param>
        /// <param name="isactive">isactive</param>
        /// <param name="userID">userID</param>
        /// <param name="videoID">videoID</param>
        /// <param name="tType">tType</param>
        /// <param name="id">id</param>
        /// <returns>Integer</returns>
        public static int ManageBusinessProfileVideos(int profileID, string videoname, string videopath, string videotype, bool primeflag, bool isactive, int userID, int videoID, int tType, int id)
        {
            int returnval = 0;
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageBusinessVideo", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@Videoname", videoname);
                sqlCmd.Parameters.AddWithValue("@Videopath", videopath);
                sqlCmd.Parameters.AddWithValue("@VideoType", videotype);
                sqlCmd.Parameters.AddWithValue("@primeflag", primeflag);
                sqlCmd.Parameters.AddWithValue("@IsActive", isactive);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@VideoID", videoID);
                sqlCmd.Parameters.AddWithValue("@TType", tType);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable != null && vtable.Rows.Count > 0)
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
        /// For retrieving profile photos by profileid
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>Data table</returns>
        public static DataTable GetProfilePhotosByProfileID(int profileID, int galleryOrder = 1)
        {
            DataTable vtable = new DataTable("photos");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfilePhotosByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@OrderBy", galleryOrder);
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
        /// for retrieving profile videos by profile id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>Data table</returns>
        public static DataTable GetProfileVideosByProfileID(int profileID)
        {
            DataTable vtable = new DataTable("videos");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileVideosByID", sqlCon);
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
        /// for updating primary business profile photo
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="photonum">photonum</param>
        /// <param name="primeflag">primeflag</param>
        /// <param name="userID">userID</param>
        /// <returns>Integer</returns>
        public static int UpdatePrimaryBusinessProfilePhoto(int profileID, int photonum, bool primeflag, int userID)
        {
            int returnval = 0;
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdatePrimaryBusinessPhoto", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@photonum", photonum);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@primeflag", primeflag);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable != null && vtable.Rows.Count > 0)
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
        /// For retrieving profil id by userid
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>Integer</returns>
        public static int GetProfileIDByUserID(int userID)
        {
            int returnval = 0;
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileDetailsByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable != null && vtable.Rows.Count > 0)
                {
                    returnval = Convert.ToInt32(vtable.Rows[0]["Profile_ID"]);
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
        /// for retrieving profile messages
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="profileID">profileID</param>
        /// <returns>Data table</returns>
        public static DataTable GetProfileMessages(bool top5Flag, int profileID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileMessages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@top5flag", top5Flag);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);

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

        /// <summary>
        /// for retrieving messge details
        /// </summary>
        /// <param name="msgID">msgID</param>
        /// <returns>Data table</returns>
        public static DataTable GetMessageDetailsByID(int msgID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_MessageDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@msgID", msgID);
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

        /// <summary>
        /// for managing business messages
        /// </summary>
        /// <param name="toid">toid</param>
        /// <param name="totypeID">totypeID</param>
        /// <param name="fromID">fromID</param>
        /// <param name="subject">subject</param>
        /// <param name="message">message</param>
        /// <param name="replyid">replyid</param>
        /// <param name="activeflag">activeflag</param>
        /// <param name="msgID">msgID</param>
        /// <param name="userID">userID</param>
        /// <param name="tType">tType</param>
        /// <param name="id">id</param>
        /// <returns>Integer</returns>
        public static int ManageBusinessMessage(int toid, int totypeID, int fromID, string subject, string message, int replyid, bool activeflag, int msgID, int userID, int tType, int id)
        {
            DataTable vtable = new DataTable("consumer");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageBusinessMessages", sqlCon);
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

        /// <summary>
        /// for retrieving sent messages by profiles
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="profileID">profileID</param>
        /// <returns>Data table</returns>
        public static DataTable GetProfileSentMessages(bool top5Flag, int profileID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileSentMessages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@top5flag", top5Flag);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
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

        /// <summary>
        /// for updating bussiness read messages
        /// </summary>
        /// <param name="totypeID">totypeID</param>
        /// <param name="msgID">msgID</param>
        /// <returns>Integer</returns>
        public static int UpdateBusinessReadMessage(int totypeID, int msgID)
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

        /// <summary>
        /// For updating profile staticstics
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="iPaddress">iPaddress</param>
        /// <param name="addlvalue">addlvalue</param>
        /// <returns>Integer</returns>
        public static int UpdateProfileStatistics(int profileID, string iPaddress, string addlvalue)
        {
            DataTable vtable = new DataTable("stats");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AddProfileViewDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@IPAddress", iPaddress);
                sqlCmd.Parameters.AddWithValue("@AddlValues", addlvalue);
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
        /// for retrieving profile statistics
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetProfileStatistics(int profileID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileStatistics", sqlCon);
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
        /// for retrieving aff invitations by id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetAffInvitationsbyID(int profileID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAffiliateInvitationsByProfileID", sqlCon);
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
        /// for getting aff invitation details by invitation id
        /// </summary>
        /// <param name="invID">invID</param>
        /// <returns>data table</returns>
        public static DataTable GetAffInvDetailsbyInvitationID(int invID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAffInvitationsByInviteID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@invID", invID);

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
        /// For addin affiliate invitations
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="sendto">sendto</param>
        /// <param name="buzname">buzname</param>
        /// <param name="subject">subject</param>
        /// <param name="message">message</param>
        /// <param name="memberID">memberID</param>
        /// <param name="userID">userID</param>
        /// <param name="guID">guID</param>
        /// <returns>integer</returns>
        public static int AddAffiliateInvitation(int profileID, string sendto, string buzname, string subject, string message, int memberID, int userID, string guID)
        {
            DataTable vtable = new DataTable("stats");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AddAffiliateInvitation", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@Sendto", sendto);
                sqlCmd.Parameters.AddWithValue("@subject", subject);
                sqlCmd.Parameters.AddWithValue("@message", message);
                sqlCmd.Parameters.AddWithValue("@buzname", buzname);
                sqlCmd.Parameters.AddWithValue("@memberID", memberID);
                sqlCmd.Parameters.AddWithValue("@userID", userID);
                sqlCmd.Parameters.AddWithValue("@UniqueID", guID);
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
        /// Delete affiliate invitations
        /// </summary>
        /// <param name="inviteID">inviteID</param>
        /// <returns>integer</returns>
        public static int DeleteAffiliateInvitation(int inviteID)
        {
            DataTable vtable = new DataTable("stats");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteAffiliateInvitationByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InviteID", inviteID);


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
        //Add New TipOf The Week
        /// <summary>
        /// for adding tip of the week
        /// </summary>
        /// <param name="tipID">tipID</param>
        /// <param name="tipName">tipName</param>
        /// <param name="tipCategory">tipCategory</param>
        /// <param name="tipDescription">tipDescription</param>
        /// <param name="tipbroughtBy">tipbroughtBy</param>
        /// <param name="isActive">isActive</param>
        /// <param name="username">username</param>
        /// <returns>integer</returns>
        public static int AddNewTip(int tipID, string tipName, string tipCategory, string tipDescription, int tipbroughtBy, bool isActive, string username)
        {
            DataTable vtable = new DataTable();
            int returnvalue = 0;
            SqlConnection sqlcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("usp_ManageTipOfweek", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@TipID", tipID);
                sqlcmd.Parameters.AddWithValue("@TipName", tipName);
                sqlcmd.Parameters.AddWithValue("@TipCategory", tipCategory);
                sqlcmd.Parameters.AddWithValue("@TipDescription ", tipDescription);
                sqlcmd.Parameters.AddWithValue("@TipbroughtBy", tipbroughtBy);
                sqlcmd.Parameters.AddWithValue("@isActive", isActive);
                sqlcmd.Parameters.AddWithValue("@username", username);
                SqlDataAdapter sqlAdpt = new SqlDataAdapter(sqlcmd);
                sqlAdpt.Fill(vtable);
                if (vtable != null)
                {
                    returnvalue = Convert.ToInt32(vtable.Rows[0][0]);
                }

                return returnvalue;
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
        //Get Tip Of the week By pofile ID
        /// <summary>
        /// foe getting tip of th eweek by profile id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetAllTipOftheWeeks(int profileID)
        {
            DataTable tipstable = new DataTable("ProfileID");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllTipOftheWeeks", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(tipstable);
                return tipstable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

        }
        //Get Tip of the Week by TipID
        /// <summary>
        /// for retriving tip of the weekby tip id
        /// </summary>
        /// <param name="tipID">tipid</param>
        /// <returns></returns>
        public static DataTable GetTipOftheWeekByTipID(int tipID)
        {
            DataTable tipstable = new DataTable("Tipstable");
            SqlConnection sqlcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("usp_GetTipOfTheWeekByTipID", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@TipID", tipID);
                SqlDataAdapter sqladptr = new SqlDataAdapter(sqlcmd);
                sqladptr.Fill(tipstable);
                return tipstable;

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
        //Delete Tip Of The Week
        /// <summary>
        /// for deleting tip
        /// </summary>
        /// <param name="tipID">tipID</param>
        /// <returns>int</returns>
        public static int DeleteTip(int tipID)
        {
            int returnvalue = 0;
            DataTable dtable = new DataTable("deletetable");
            SqlConnection sqlcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("usp_DeleteTip", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@TipID", tipID);
                SqlDataAdapter sqladptr = new SqlDataAdapter(sqlcmd);
                sqladptr.Fill(dtable);
                if (dtable != null)
                {
                    returnvalue = Convert.ToInt32(dtable.Rows[0][0]);
                }
                return returnvalue;
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
        // Get Bussiness Link Data
        /// <summary>
        /// for retrieving full business data
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

        /// <summary>
        /// for searching business link name
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

        /// <summary>
        /// for retrirving business details by user id
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>data table</returns>
        public static DataTable GetBusinessDetailsByUserID(int userID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileDetailsByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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

        /// <summary>
        /// Inserting bussiness link data with profile id
        /// </summary>
        /// <param name="blinkName">blinkName</param>
        /// <param name="blinkUrl">blinkUrl</param>
        /// <param name="profileID">profileID</param>
        /// <param name="username">username</param>
        /// <param name="activeFlag">activeFlag</param>
        /// <returns>Integer</returns>
        public static int InsertBLinkDataWithProfileID(string blinkName, string blinkUrl, int profileID, string username, bool activeFlag)
        {
            int returnval = 0;
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertBLinkDataWithProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Blink_name", blinkName);
                sqlCmd.Parameters.AddWithValue("@Blink_Url", blinkUrl);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@CREATED_USER", username);
                sqlCmd.Parameters.AddWithValue("@Active_flag", activeFlag);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable != null && vtable.Rows.Count > 0)
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
        /// getting favorited links
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetFavoritesLinks(int profileID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetFavoritesLinks", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);
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

        /// <summary>
        /// for reviewing a profile
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>Data table</returns>
        public static DataTable GetReviewProfile(int profileid)
        {
            DataTable dtReviews = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileReviewsBusiness", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@profileid", profileid);

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtReviews);

                return dtReviews;
            }
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
        /// for getting a detailed invoice
        /// </summary>
        /// <param name="userid">userid</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDetailInvoice(int userid)
        {
            DataTable detailInv = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetDistinctInvoices", sqlCon);// *** Fis for IRH-45 05-02-2013  usp_GetInvoiceDetails*** //
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userid); // *** @user_id *** //
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(detailInv);

                return detailInv;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

        }

        public static DataTable GetInvoiceDetail_New(int profileID)
        {
            DataTable invoiceDetails = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetInvoiceDetails_New", sqlCon);// *** Fis for IRH-45 05-02-2013  usp_GetInvoiceDetails*** //
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID); // *** @user_id *** //
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(invoiceDetails);

                return invoiceDetails;
            }
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
        /// for getting detailed invoice by order id
        /// </summary>
        /// <param name="orderid">orderid</param>
        /// <returns>data table</returns>
        public static DataTable GetDetailInvoicebyOrderID(int orderid)
        {
            DataTable detailInv = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetInvoiceDetailsByID", sqlCon); // *** Fix For IRH-63 05-02-2013 usp_GetInvoiceDetailsByOrderid *** //
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OrderID", orderid); // *** @order_id *** //
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(detailInv);

                return detailInv;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

        }
        public static DataTable GetInvoiceDetailsBySubTypeID(int subscriptionTypeID)
        {
            DataTable subscriptiondetais = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetInvoiceDetailsByID_New", sqlCon); // *** Fix For IRH-63 05-02-2013 usp_GetInvoiceDetailsByOrderid *** //
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SubscriptionTypeID", subscriptionTypeID); // *** @order_id *** //
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(subscriptiondetais);

                return subscriptiondetais;
            }
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
        /// for inserting affiliate details
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="affilicateID">affilicateID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="affguid">affguid</param>
        /// <returns>Integer</returns>
        public static int InsertAffilicateDetails(int userID, int affilicateID, int profileID, string affguid)
        {
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable addAffDetail = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AddProfile_Affiliates", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@AffiliateID", affilicateID);
                sqlCmd.Parameters.AddWithValue("@UniqueID", affguid);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(addAffDetail);
                if (addAffDetail != null && addAffDetail.Rows.Count > 0)
                {
                    returnval = Convert.ToInt32(addAffDetail.Rows[0][0]);
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
        /// for updatingaffiliate accept flag
        /// </summary>
        /// <param name="affguid">affguid</param>
        /// <param name="profileID">profileID</param>
        /// <returns>Integer</returns>
        public static int UpdateAffiliateAcceptFlag(string affguid, int profileID)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateAffInvStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UniqueID", affguid.Trim());
                sqlCmd.Parameters.AddWithValue("@Receiveprofileid", profileID);
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
        /// for retrieving profile 
        /// </summary>
        /// <param name="invitationID">invitationID</param>
        /// <returns>Integer</returns>
        public static int GetReceiveProfileIDByInvitationID(int invitationID)
        {
            int profileID;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetReceiveprofileidByInvitationID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Invitation_ID", invitationID);
                profileID = (int)(sqlCmd.ExecuteScalar());
                return profileID;
            }
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
        /// for retriving affiliate details
        /// </summary>
        /// <param name="profileID">profile id</param>
        /// <returns>data table</returns>
        public static DataTable GetAffiliateDetails(int profileID)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable affDetail = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileAffiliates", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(affDetail);
                return affDetail;
            }
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
        /// for inserting afflicate invitation reecord
        /// </summary>
        /// <param name="buzname">buzname</param>
        /// <param name="websitename">websitename</param>
        /// <param name="email">email</param>
        /// <param name="description">description</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="country">country</param>
        /// <param name="categories">categories</param>
        /// <param name="isActive">isActive</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone1">phone1</param>
        /// <param name="searchindustries">searchindustries</param>
        /// <param name="searchcities">searchcities</param>
        /// <param name="searchstates">searchstates</param>
        /// <param name="status">status</param>
        /// <param name="membership">membership</param>
        /// <param name="userid">userid</param>
        /// <param name="profileid">profileid</param>
        /// <param name="affProfileID">affProfileID</param>
        /// <param name="leadCode">leadCode</param>
        /// <returns>integer</returns>
        public static int InsertAfflicateInvitationRecord(string buzname, string websitename, string email, string description, string address1, string address2, string city, string state, string country, string categories, bool isActive, string zipcode, string phone1, string searchindustries, string searchcities, string searchstates, string status, int membership, int userid, int profileid, int affProfileID, string leadCode)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AddAffiliateUserBusinessProfile1", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profilename", buzname);
                sqlCmd.Parameters.AddWithValue("@Websitename", websitename);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.Parameters.AddWithValue("@description", description);
                sqlCmd.Parameters.AddWithValue("@address1", address1);
                sqlCmd.Parameters.AddWithValue("@address2", address2);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@State", state);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                sqlCmd.Parameters.AddWithValue("@Categories", categories);
                sqlCmd.Parameters.AddWithValue("@Catlistvals", searchindustries);
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipcode);
                sqlCmd.Parameters.AddWithValue("@phone1", phone1);
                sqlCmd.Parameters.AddWithValue("@Searchcities", searchcities);
                sqlCmd.Parameters.AddWithValue("@SearchStates", searchstates);
                sqlCmd.Parameters.AddWithValue("@status", status);
                sqlCmd.Parameters.AddWithValue("@membership", membership);
                sqlCmd.Parameters.AddWithValue("@UserID", userid);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileid);
                sqlCmd.Parameters.AddWithValue("@IsActive", isActive);
                sqlCmd.Parameters.AddWithValue("@AffiliateProfileId", affProfileID);
                sqlCmd.Parameters.AddWithValue("@leadcode", leadCode);
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
        /// retrieving profile settings by profile id
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>data table</returns>
        public static DataTable GetProfileSettingsByprofileID(int profileid)
        {
            DataTable dtprofile = new DataTable();
            SqlConnection sqlcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("usp_GetProfileSettingsByprofileID", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@profileid", profileid);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlcmd);
                sqlAdptr.Fill(dtprofile);
                return dtprofile;
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
        /// for inserting profilr setting
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="addressflag">addressflag</param>
        /// <param name="cityflag">cityflag</param>
        /// <param name="stateflag">stateflag</param>
        /// <param name="zipflag">zipflag</param>
        /// <param name="contactflag">contactflag</param>
        /// <param name="faxflag">faxflag</param>
        /// <param name="reviewflag">reviewflag</param>
        /// <param name="joimailinglistflag">joimailinglistflag</param>
        /// <param name="generaltabflag">generaltabflag</param>
        /// <param name="tabname">tabname</param>
        /// <param name="settingsid">settingsid</param>
        /// <param name="addlDesc">addlDesc</param>
        /// <param name="businessdays">businessdays</param>
        /// <param name="bgmPlayerEnabled">bgmPlayerEnabled</param>
        /// <param name="bgMusicPalyOnOff">bgMusicPalyOnOff</param>
        /// <param name="eventCal">eventCal</param>
        /// <param name="id">id</param>
        /// <returns>Integer</returns>
        public static int InsertProfileSetting(int profileid, bool addressflag, bool cityflag, bool stateflag, bool zipflag, bool contactflag, bool faxflag, bool reviewflag, bool joimailinglistflag, bool generaltabflag, string tabname, int settingsid, bool addlDesc, bool businessdays, bool bgmPlayerEnabled, bool bgMusicPalyOnOff, bool eventCal, int id)
        {
            int returnval = 0;
            DataTable dtprofile = new DataTable();
            SqlConnection sqlcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("usp_InsertProfileSettings", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@profileid", profileid);
                sqlcmd.Parameters.AddWithValue("@addressflag", addressflag);
                sqlcmd.Parameters.AddWithValue("@cityflag", cityflag);
                sqlcmd.Parameters.AddWithValue("@stateflag", stateflag);
                sqlcmd.Parameters.AddWithValue("@zipflag", zipflag);
                sqlcmd.Parameters.AddWithValue("@contactflag", contactflag);
                sqlcmd.Parameters.AddWithValue("@faxflag", faxflag);
                sqlcmd.Parameters.AddWithValue("@reviewflag", reviewflag);
                sqlcmd.Parameters.AddWithValue("@joinmailinglistflag", joimailinglistflag);
                sqlcmd.Parameters.AddWithValue("@generaltabflag", generaltabflag);
                sqlcmd.Parameters.AddWithValue("@tabname", tabname);
                sqlcmd.Parameters.AddWithValue("@SettingsID", settingsid);
                sqlcmd.Parameters.AddWithValue("@AddlDesc", addlDesc);
                sqlcmd.Parameters.AddWithValue("@Businessdays", businessdays);
                sqlcmd.Parameters.AddWithValue("@BGMPlayerEnabled", bgmPlayerEnabled);
                sqlcmd.Parameters.AddWithValue("@BGMusicPalyOnOff", bgMusicPalyOnOff);
                sqlcmd.Parameters.AddWithValue("@EventCal", eventCal);
                sqlcmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlcmd);
                sqlAdptr.Fill(dtprofile);
                if (dtprofile != null && dtprofile.Rows.Count > 0)
                {
                    returnval = Convert.ToInt32(dtprofile.Rows[0][0]);
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
        /// <summary>
        /// for retrieving authenticated user profile
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <returns>data table</returns>
        public static DataTable GetAuthenticateUserProfileID(string emailID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable affProfileID = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserProfileIDtoAuthenticate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailID", emailID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(affProfileID);
                return affProfileID;
            }
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
        /// Get Affiliate Count profile
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>integer</returns>
        public static int GetAffiliateCountprofile(int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable affProfileID = new DataTable();
            int profileIDCount;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileAffiliatesCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@profileid", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(affProfileID);
                if (affProfileID != null)
                {
                    profileIDCount = Convert.ToInt32(affProfileID.Rows[0][0]);
                    return profileIDCount;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        //
        /// <summary>
        /// for retrieving profilr category
        /// </summary>
        /// <param name="industryName">industryName</param>
        /// <returns>string</returns>
        public static string GetProfileCategory(string industryName)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileIndustryCategory", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@industry_name", industryName);
                string industyname = (string)(sqlCmd.ExecuteScalar());
                return industyname;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }



        }
        /* public static void UpdateCitiesAndIndustries(int Profile_ID, int UserID, string Cities, string industries)
         {
             DataTable DetailInv = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

             try
             {
                 SqlCommand sqlCmd = new SqlCommand("usp_ManageBusinessCitiesAndIndustries", sqlCon);
             sqlCmd.CommandType = CommandType.StoredProcedure;
                       sqlCmd.Parameters.AddWithValue("@ProfileID", Profile_ID);
                   sqlCmd.Parameters.AddWithValue("@userID", UserID);
                 sqlCmd.Parameters.AddWithValue("@IndustryIDS", industries);
                 sqlCmd.Parameters.AddWithValue("@Searchcities", Cities);
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

         }*/

        // Start of issue 823
        /// <summary>
        /// For updating cities and industris
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="industries">industries</param>
        /// <param name="industryNames">industryNames</param>
        public static void UpdateCitiesAndIndustries(int profileID, int userID, string industries, string industryNames)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageBusinessCitiesAndIndustries2", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@userID", userID);
                sqlCmd.Parameters.AddWithValue("@IndustryIDS", industries);
                sqlCmd.Parameters.AddWithValue("@IndustryNames", industryNames);
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
        /// for updating cities and industries
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="cities">cities</param>
        /// <param name="searchstates">searchstates</param>
        /// <param name="searchcityState">searchcityState</param>
        /// <param name="zipcodes">zipcodes</param>
        public static void UpdateCitiesAndIndustries(int profileID, int userID, string cities, string searchstates, string searchcityState, string zipcodes)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageBusinessCitiesAndIndustries1", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@userID", userID);
                sqlCmd.Parameters.AddWithValue("@Searchcities", cities);
                sqlCmd.Parameters.AddWithValue("@Searchstates", searchstates);
                sqlCmd.Parameters.AddWithValue("@Searchcity_state", searchcityState);
                sqlCmd.Parameters.AddWithValue("@Searchzipcodes", zipcodes);
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
        // Start of issue 823
        /// <summary>
        /// for adding business profile 
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="subscribeID">subscribeID</param>
        /// <param name="price">price</param>
        /// <param name="ecitiescost">ecitiescost</param>
        /// <param name="einduscost">einduscost</param>
        /// <param name="discCode">discCode</param>
        /// <param name="discamt">discamt</param>
        /// <param name="totalamt">totalamt</param>
        /// <param name="taxamt">taxamt</param>
        /// <param name="billableamt">billableamt</param>
        /// <param name="period">period</param>
        /// <param name="startdate">startdate</param>
        /// <param name="enddate">enddate</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="country">country</param>
        /// <param name="ptype">ptype</param>
        /// <param name="ccnumber">ccnumber</param>
        /// <param name="ccname">ccname</param>
        /// <param name="ccmonth">ccmonth</param>
        /// <param name="ccyear">ccyear</param>
        /// <param name="flag">flag</param>
        /// <returns>integer </returns>
        public static int AddBusinessProfileOrder1(int profileID, int userID, int subscribeID, decimal price, decimal ecitiescost, decimal einduscost, string discCode, decimal discamt, decimal totalamt, decimal taxamt, decimal billableamt, int period, string startdate, string enddate, string address1, string address2, string city, string state, string zipcode, string country, string ptype, string ccnumber, string ccname, string ccmonth, string ccyear, Boolean flag)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AddBusinessProfileOrder1", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@SubcribeID", subscribeID);
                sqlCmd.Parameters.AddWithValue("@Price", price);
                sqlCmd.Parameters.AddWithValue("@Ecitycost", ecitiescost);
                sqlCmd.Parameters.AddWithValue("@EInduscost", einduscost);
                sqlCmd.Parameters.AddWithValue("@DiscCode", discCode);
                sqlCmd.Parameters.AddWithValue("@DiscAmount", discamt);
                sqlCmd.Parameters.AddWithValue("@totalamount", totalamt);
                sqlCmd.Parameters.AddWithValue("@Tax", taxamt);
                sqlCmd.Parameters.AddWithValue("@Active_flag", flag);
                sqlCmd.Parameters.AddWithValue("@billAmount", billableamt);
                sqlCmd.Parameters.AddWithValue("@period", period);
                sqlCmd.Parameters.AddWithValue("@startdate", Convert.ToDateTime(startdate));
                sqlCmd.Parameters.AddWithValue("@enddate", Convert.ToDateTime(enddate));
                sqlCmd.Parameters.AddWithValue("@address1", address1);
                sqlCmd.Parameters.AddWithValue("@address2", address2);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@statename", state);
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipcode);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                sqlCmd.Parameters.AddWithValue("@ptype", ptype);
                sqlCmd.Parameters.AddWithValue("@ccnumber", ccnumber);
                sqlCmd.Parameters.AddWithValue("@ccname", ccname);
                sqlCmd.Parameters.AddWithValue("@ccmonth", ccmonth);
                sqlCmd.Parameters.AddWithValue("@ccyear", ccyear);


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
        /// for retrieving profile details by profile id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetProfileDetailsByProfileID1(int profileID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileSubscriptionDetails", sqlCon);
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
        /// for verifying affiliate details by profile id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="affiliateID">affiliateID</param>
        /// <returns>Integer</returns>
        public static int VerifyAffiliateDetailsByProfileID(int profileID, int affiliateID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable affProfile = new DataTable();
            int profileIDCount = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_VerifyAffiliateProfile", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@AffiliateID", affiliateID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(affProfile);

                if (affProfile != null)
                {
                    if (affProfile.Rows.Count > 0)
                    {
                        profileIDCount = Convert.ToInt32(affProfile.Rows[0][0]);
                        return profileIDCount;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
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
        /// for activating user details
        /// </summary>
        /// <param name="userid">userid</param>
        /// <param name="flag">flag</param>
        public static void ActivateUserDetails(int userid, Boolean flag)
        {
            DataTable vtable = new DataTable("business");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {

                SqlCommand sqlCmd = new SqlCommand("usp_UpdateUserFlag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userID", userid);
                sqlCmd.Parameters.AddWithValue("@active_flag", flag);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
            }
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
        /// for getting profile id by user id
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>data table</returns>
        public static DataTable GetProfileIDByUserID1(int userID)
        {
            DataTable vtable = new DataTable("business");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileIDByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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

        //General Tab
        /// <summary>
        /// for gettig general tab invitations by id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetGeneraltabInvitationsbyID(int profileID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetGeneraltabInvitationsByProfileID", sqlCon);
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
        /// for adding general tab invitation
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="sendto">sendto</param>
        /// <param name="buzname">buzname</param>
        /// <param name="subject">subject</param>
        /// <param name="message">message</param>
        /// <param name="memberID">memberID</param>
        /// <param name="userID">userID</param>
        /// <param name="guID">guID</param>
        /// <returns>integer</returns>
        public static int AddGeneraltabInvitation(int profileID, string sendto, string buzname, string subject, string message, int memberID, int userID, string guID)
        {
            DataTable vtable = new DataTable("stats");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AddGeneraltabInvitation", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@Sendto", sendto);
                sqlCmd.Parameters.AddWithValue("@subject", subject);
                sqlCmd.Parameters.AddWithValue("@message", message);
                sqlCmd.Parameters.AddWithValue("@buzname", buzname);
                sqlCmd.Parameters.AddWithValue("@memberID", memberID);
                sqlCmd.Parameters.AddWithValue("@userID", userID);
                sqlCmd.Parameters.AddWithValue("@UniqueID", guID);
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
        /// for delting tab invitations
        /// </summary>
        /// <param name="inviteID">inviteID</param>
        /// <returns>intger</returns>
        public static int DeleteGeneraltabInvitation(int inviteID)
        {
            DataTable vtable = new DataTable("stats");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteGeneraltabInvitationByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InviteID", inviteID);


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
        /// for inserting general tab details
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="generaltabID">generaltabID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="uniqueID">uniqueID</param>
        /// <returns>integer</returns>
        public static int InsertGeneraltabDetails(int userID, int generaltabID, int profileID, string uniqueID)
        {
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable addGeneraltabDetail = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AddProfile_Generaltab", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@GeneraltabID", generaltabID);
                sqlCmd.Parameters.AddWithValue("@Gtabunique", uniqueID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(addGeneraltabDetail);
                if (sqlCmd != null && addGeneraltabDetail.Rows.Count > 0)
                {
                    returnval = Convert.ToInt32(addGeneraltabDetail.Rows[0][0]);
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
        /// fo retrieving general tab details
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetGeneraltabDetails(int profileID)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable affDetail = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileGeneraltab", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(affDetail);
                return affDetail;
            }
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
        /// for retrieving profile id by invitation id
        /// </summary>
        /// <param name="invitationID">invitationID</param>
        /// <returns>Integer</returns>
        public static int GetProfileIDByInvitationID(int invitationID)
        {
            int profileID;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetProfileIDByInvitationID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Invitation_ID", invitationID);
                profileID = (int)(sqlCmd.ExecuteScalar());
                return profileID;
            }
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
        /// for insertinf general tab invitation record
        /// </summary>
        /// <param name="buzname">buzname</param>
        /// <param name="websitename">websitename</param>
        /// <param name="email">email</param>
        /// <param name="description">description</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// 
        /// <param name="country">country</param>
        /// <param name="categories">categories</param>
        /// <param name="isActive">isActive</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone1">phone1</param>
        /// 
        /// <param name="searchindustries">searchindustries</param>
        /// <param name="searchcities">searchcities</param>
        /// <param name="searchstates">searchstates</param>
        /// <param name="status">status</param>
        /// <param name="membership">membership</param>
        /// <param name="userid">userid</param>
        /// <param name="profileid">profileid</param>
        /// <param name="generaltabProfileID">generaltabProfileID</param>
        /// <param name="uniqueID1">uniqueID1</param>
        /// <param name="leadcode">leadcode</param>
        /// <returns>Integer</returns>
        public static int InsertGeneraltabInvitationRecord(string buzname, string websitename, string email, string description, string address1, string address2, string city, string state, string country, string categories, bool isActive, string zipcode, string phone1, string searchindustries, string searchcities, string searchstates, string status, int membership, int userid, int profileid, int generaltabProfileID, string uniqueID1, string leadcode)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AddGeneraltabUserBusinessProfile1", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profilename", buzname);
                sqlCmd.Parameters.AddWithValue("@Websitename", websitename);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.Parameters.AddWithValue("@description", description);
                sqlCmd.Parameters.AddWithValue("@address1", address1);
                sqlCmd.Parameters.AddWithValue("@address2", address2);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@State", state);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                sqlCmd.Parameters.AddWithValue("@Categories", categories);
                sqlCmd.Parameters.AddWithValue("@Catlistvals", searchindustries);
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipcode);
                sqlCmd.Parameters.AddWithValue("@phone1", phone1);
                sqlCmd.Parameters.AddWithValue("@Searchcities", searchcities);
                sqlCmd.Parameters.AddWithValue("@SearchStates", searchstates);
                sqlCmd.Parameters.AddWithValue("@status", status);
                sqlCmd.Parameters.AddWithValue("@membership", membership);
                sqlCmd.Parameters.AddWithValue("@UserID", userid);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileid);
                sqlCmd.Parameters.AddWithValue("@IsActive", isActive);
                sqlCmd.Parameters.AddWithValue("@GeneraltabProfileId", generaltabProfileID);
                sqlCmd.Parameters.AddWithValue("@UniqueID", uniqueID1);
                sqlCmd.Parameters.AddWithValue("@leadcode", leadcode);
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
        /// for checking general tab details by profileid
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="generaltabID">generaltabID</param>
        /// <returns>Integer</returns>
        public static int VerifyGeneraltabDetailsByProfileID(int profileID, int generaltabID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable generaltabProfile = new DataTable();
            int profileIDCount = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_VerifyGeneraltabProfileDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@GeneraltabID", generaltabID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(generaltabProfile);

                if (generaltabProfile != null)
                {
                    if (generaltabProfile.Rows.Count > 0)
                    {
                        profileIDCount = Convert.ToInt32(generaltabProfile.Rows[0][0]);
                        return profileIDCount;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
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
        /// for checking business name
        /// </summary>
        /// <param name="profileCode">profileCode</param>
        /// <param name="profileID">profileID</param>
        /// <returns>Integer</returns>
        public static int CheckBuinessName(string profileCode, int profileID)
        {
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_CheckBusinessName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);
                sqlCmd.Parameters.AddWithValue("@Profile_Code", profileCode);
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

        /// <summary>
        /// For updating business names
        /// </summary>
        /// <param name="profileCode">profileCode</param>
        /// <param name="profileID">profileID</param>
        /// <param name="id">id</param>
        public static void UpdateBuinessName(string profileCode, int profileID, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_AddProfileCodeforBusiness", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);
                sqlCmd.Parameters.AddWithValue("@Profile_Code", profileCode);
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
        /// <summary>
        /// for getting state code for state
        /// </summary>
        /// <param name="stateName">stateName</param>
        /// <returns>string</returns>
        public static string GetStateCodeForState(string stateName)
        {
            string stateCode;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetStatecodeForStateName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@State_Name", stateName);
                stateCode = Convert.ToString(sqlCmd.ExecuteScalar());
                return stateCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();

            }
        }

        /// <summary>
        /// for updating accept flag in general tab
        /// </summary>
        /// <param name="gtabuniqueID">gtabuniqueID</param>
        /// <param name="profileID">profileID</param>
        /// <returns>Integer</returns>
        public static int UpdateAcceptflagingeneraltab(string gtabuniqueID, int profileID)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ActivateGtabUser", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Gtabunique", gtabuniqueID.Trim());
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


        //Html Convert Methods
        /// <summary>
        /// for getting all business categories
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetAllBusiness_Categories()
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable businessCateogry = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetDistinctIndustryName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(businessCateogry);
                return businessCateogry;
            }
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
        /// for retrieving sub categories of all business
        /// </summary>
        /// <param name="businessCategory">businessCategory</param>
        /// <returns>data table</returns>
        public static DataTable GetAllBusiness_Subcategory(string businessCategory)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable businessCateogry = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllBusinessNameofBusinessCategory", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Industry_Category", businessCategory);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(businessCateogry);
                return businessCateogry;
            }
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
        /// for getting all business profiles
        /// </summary>
        /// <returns>Data table</returns>
        public static DataTable GetAllBusinessProfiles()
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable businessCateogry = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_GetAllProfileDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(businessCateogry);
                return businessCateogry;
            }
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
        /// getting category name for category
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>string</returns>
        public static string GetCategorynameForCategoryID(int id)
        {
            string categoryName;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetIndustryNameForIndustryID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@IndustryID", id);
                categoryName = Convert.ToString(sqlCmd.ExecuteScalar());
                return categoryName;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();

            }
        }

        /// <summary>
        /// for reetrieving category id for category
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>data tble</returns>
        public static DataTable GetCategoryIDForCategoryName(string name)
        {
            DataTable categoryID = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetIndustryIdforIndustryName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@industry_name", name);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(categoryID);
                return categoryID;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();

            }
        }


        //Alerts Methods
        /// <summary>
        /// for deleting alerts
        /// </summary>
        /// <param name="alertID">alertID</param>
        /// <returns>Integer</returns>
        public static int Deletealert(int alertID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Alrt_DeleteAlert", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Alert_ID", alertID);
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
        /// <summary>
        /// for getting alert by alert id
        /// </summary>
        /// <param name="alertID">alertID</param>
        /// <returns>data table</returns>
        public static DataTable GetAlertByAlertID(int alertID)
        {
            DataTable subtypes = new DataTable("Alerts");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Alrt_GetAlertByAlertID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AlertID", alertID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(subtypes);

                return subtypes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }


        //New Registraion flow Methods
        /// <summary>
        /// for insering user activation code
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="userActivationCode">userActivationCode</param>
        public static void InsertUserActivationCode(int userID, string userActivationCode)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertUserActivationCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@user_ID", userID);
                sqlCmd.Parameters.AddWithValue("@Activation_Code", userActivationCode);
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
        /// for checking user activation code
        /// </summary>
        /// <param name="userActivationCode">userActivationCode</param>
        /// <returns>boolean</returns>
        public static Boolean CheckUserActivationCode(string userActivationCode)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            Boolean flag = false;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CheckUserAcivationCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Activation_Code", userActivationCode);
                flag = Convert.ToBoolean(sqlCmd.ExecuteScalar());
                return flag;
            }
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
        /// for retrieving user activation code
        /// </summary>
        /// <param name="userName">userName</param>
        /// <returns>string</returns>
        public static string GetUserActivationcode(string userName)
        {
            string activationCode = string.Empty;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserActivationcode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@username", userName);
                activationCode = Convert.ToString(sqlCmd.ExecuteScalar());
                return activationCode;
            }
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
        /// for enabling user flag
        /// </summary>
        /// <param name="activationCode">activationCode</param>
        public static void EnableUserFlag(string activationCode)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_EnableUserFlag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Activation_Code", activationCode);
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
        /// for checking user activatioin code for active profile
        /// </summary>
        /// <param name="userActivationCode">userActivationCode</param>
        /// <returns>integer</returns>
        public static int CheckUserActivationCodeForActivateProfile(string userActivationCode)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int flag = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CheckActivationCodeForActivateProfile", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Activation_Code", userActivationCode);
                flag = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return flag;
            }
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
        /// for checking user name and password for valid user
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="vertical">vertical</param>
        /// <param name="country">country</param>
        /// <returns>Integer</returns>
        public static int CheckUserNameandPasswordForVaildUser(string username, string vertical, string country)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int flag = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("CheckUserNameandPassword", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                flag = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return flag;
            }
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
        /// getting count from a referal friend
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>Integer</returns>
        public static int Getcountfromreferafriend(int profileID)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Getreferfriendstatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@profileID", profileID);
                int profID = (int)(sqlCmd.ExecuteScalar());
                return profID;
            }
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
        /// For retrieving user details by user activation code
        /// </summary>
        /// <param name="activationCode">activationCode</param>
        /// <returns>data table</returns>
        public static DataTable GetUserDetailsByUserActivationCode(string activationCode)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable subtypes = new DataTable("Alerts");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserdetialsBYActivationCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Activation_Code", activationCode);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(subtypes);
                return subtypes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        // Start of Issue 823
        /// <summary>
        /// for updating dash board  for cities and industries
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="cities">cities</param>
        /// <param name="states">states</param>
        /// <param name="zipcodes">zipcodes</param>
        /// <param name="cityStates">cityStates</param>
        public static void UpdateDBUpdateCitiesAndIndustries(int profileID, int userID, string cities, string states, string zipcodes, string cityStates)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageBusinessCitiesAndIndustries1", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@userID", userID);
                sqlCmd.Parameters.AddWithValue("@Searchcities", cities);
                sqlCmd.Parameters.AddWithValue("@Searchstates", states);
                sqlCmd.Parameters.AddWithValue("@Searchzipcodes", zipcodes);
                sqlCmd.Parameters.AddWithValue("@Searchcity_state", cityStates);
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
        /// for updating dash board  for cities and industries
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="industries">industries</param>
        /// <param name="industryNames">industryNames</param>
        public static void UpdateDBUpdateCitiesAndIndustries(int profileID, int userID, string industries, string industryNames)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageBusinessCitiesAndIndustries2", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@userID", userID);
                sqlCmd.Parameters.AddWithValue("@IndustryIDS", industries);
                sqlCmd.Parameters.AddWithValue("@IndustryNames", industryNames);
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
        //  End of Issue 823

        /// <summary>
        /// Checking user activation for registration
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>string</returns>
        public static string CheckUserActivationCodeForRegistration(int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            string flag = string.Empty;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("CheckUserActivationCodeForRegistration", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@User_id", userID);
                flag = sqlCmd.ExecuteScalar().ToString();
                return flag;
            }
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
        /// for adding a business user
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
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone">phone</param>
        /// <param name="userid">userid</param>
        /// <param name="status">status</param>
        /// <param name="forumUserName">forumUserName</param>
        /// <returns>Integer</returns>
        public static int AddBusinessUser1(string username, string password, string email, string firstname, string lastname, string pswdQ1, string pswdA1, string pswdQ2, string pswdA2, int roleId, bool isActive, string addr1, string addr2, string city, string state, string country, string zipcode, string phone, int userid, string status, string forumUserName)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageUser1", sqlCon);
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
                sqlCmd.Parameters.AddWithValue("@ForumUserName", forumUserName);
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
        /// for getting  a user name and password for user id
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>datatble</returns>
        public static DataTable GetUserNameAndPaswwordForUserID(int userID)
        {
            DataTable subtypes = new DataTable("Details");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUsernameandpasswordforUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(subtypes);

                return subtypes;
            }
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
        /// for retrieving all business users
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable Getallbusinessusers()
        {
            DataTable subtypes = new DataTable("subtypes");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Getalluserids", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(subtypes);

                return subtypes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        //Admin Alerts Dated October 17th 2008
        /// <summary>
        /// for retrieving order id based on user id
        /// </summary>
        /// <param name="userid">userid</param>
        /// <returns>data table</returns>
        public static DataTable Getorderidbyuserid(int userid)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetorderIDbyuserid", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userid", userid);
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
        /// for retrieving test user details by user id
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>data table</returns>
        public static DataTable GettestuserDetailsByUserID(int userID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GettestIDdetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userid", userID);
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

        //Business Payment On October 17 th
        /// <summary>
        /// for updating user profile orer
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="startDate">startDate</param>
        /// <param name="enddate">enddate</param>
        /// <param name="price">price</param>
        /// <param name="billAmount">billAmount</param>
        /// <param name="citiesAmount">citiesAmount</param>
        /// <param name="industriesamount">industriesamount</param>
        public static void UpdateUserProfileOrder(int orderID, string startDate, string enddate, decimal price, decimal billAmount, decimal citiesAmount, decimal industriesamount)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_updateuserprofileorder", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Order_ID", orderID);
                sqlCmd.Parameters.AddWithValue("@Price", price);
                sqlCmd.Parameters.AddWithValue("@billAmount", billAmount);
                sqlCmd.Parameters.AddWithValue("@StartDate", startDate);
                sqlCmd.Parameters.AddWithValue("@enddate", enddate);
                sqlCmd.Parameters.AddWithValue("@CitiesAmount", citiesAmount);
                sqlCmd.Parameters.AddWithValue("@IndustriesAmount", industriesamount);
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
        /// for updating profile order in registration
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="subscriptionAmount">subscriptionAmount</param>
        /// <param name="discountamt">discountamt</param>
        /// <param name="billableamt">billableamt</param>
        public static void UpdateProfileOrderInReg(int profileID, decimal subscriptionAmount, decimal discountamt, decimal billableamt)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateProfileSubcriptions", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@profileID", profileID);
                sqlCmd.Parameters.AddWithValue("@Discount", discountamt);
                sqlCmd.Parameters.AddWithValue("@billableamount", billableamt);
                sqlCmd.Parameters.AddWithValue("@SubscriptionPrice", subscriptionAmount);


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
        /// for getting latest profiles
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetLatestprofiles()
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetLatestProfileS", sqlCon);
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

        //Get top 1 review
        /// <summary>
        /// for getting top review
        /// </summary>
        /// <returnsdata table></returns>
        public static DataTable GettopReview()
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GettopReviews", sqlCon);
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
        //new profile
        /// <summary>
        /// for retrieving top 3 review profiles
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>data table</returns>
        public static DataTable GetTop3ReviewProfile(int profileid)
        {
            DataTable dtReviews = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_gettop3businessreviews", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@profileid", profileid);

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtReviews);

                return dtReviews;
            }
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
        /// for getting active coupons count
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>integer</returns>
        public static int Getactivecouponscount(int profileid)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_Getactivecouponscount", sqlCon);
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

        /// <summary>
        /// for retrieving agents count
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>Integer</returns>
        public static int Getagentscount(int profileid)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_Getacceptedgeneraltabinvitationcount", sqlCon);
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

        /// <summary>
        /// for retrieving top  3 affiliates
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>data table</returns>
        public static DataTable Gettop3Affiliates(int profileid)
        {

            DataTable vtable = new DataTable("business");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_Getacceptedaffiliatesinvitation", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@profileid", profileid);
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
        /// for retrieving affilites count
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>integer</returns>
        public static int Getaffiliatescount(int profileid)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_Getacceptedaffiliatesinvitationcount", sqlCon);
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
        /// <summary>
        /// for getting usere details by profile id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data  table</returns>
        public static DataTable GetuserdetailsByProfileID(int profileID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_Getuserdetailsbyprofileid", sqlCon);
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
        /// for retrieving profile description
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>

        public static DataTable Getprofiledescription(int profileID)
        {
            DataTable subtypes = new DataTable("subtypes");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_getprofiledescription", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@profile_ID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(subtypes);
                return subtypes;
            }
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
        /// for updating profile description
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="businessDuration">businessDuration</param>
        /// <param name="noOfEmp">noOfEmp</param>
        /// <param name="localMemberships">localMemberships</param>
        /// <param name="businessDescription">businessDescription</param>
        /// <param name="productDescription">productDescription</param>
        /// <param name="id">id</param>
        /// <returns>integer</returns>
        public static int Updateprofiledescription(int profileid, string businessDuration, int noOfEmp, string localMemberships, string businessDescription, string productDescription, int id)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_updateprofiledescription", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileid);
                sqlCmd.Parameters.AddWithValue("@Business_duration", businessDuration);
                sqlCmd.Parameters.AddWithValue("@No_Of_Emp", noOfEmp);
                sqlCmd.Parameters.AddWithValue("@Local_memberships", localMemberships);
                sqlCmd.Parameters.AddWithValue("@Business_description", businessDescription);
                sqlCmd.Parameters.AddWithValue("@Product_description", productDescription);
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


        //Get Tip By TipID
        /// <summary>
        /// for retrieving tip by tip id
        /// </summary>
        /// <param name="tipID">tipID</param>
        /// <returns>data table</returns>
        public static DataTable GetTipByTipID(int tipID)
        {
            DataTable vtable = new DataTable("business");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_getTipbyTipID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@TipID", tipID);
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

        //User tracking code
        /// <summary>
        /// for tracking user
        /// </summary>
        /// <param name="userid">userid</param>
        /// <param name="ipadress">ipadress</param>
        /// <param name="logintime">logintime</param>
        /// <param name="logouttime">logouttime</param>
        /// <param name="logindate">logindate</param>
        /// <param name="logoutdate">logoutdate</param>
        /// <param name="status">status</param>
        /// <param name="browser">browser</param>
        /// <param name="browserVersion">browserVersion</param>
        /// <returns>integer</returns>
        public static int Usertracking(int userid, string ipadress, string logintime, string logouttime, string logindate, string logoutdate, int status, string browser, string browserVersion)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UserTrack", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@user_id", userid);
                sqlCmd.Parameters.AddWithValue("@Ipaddress", ipadress);
                sqlCmd.Parameters.AddWithValue("@logindate", logindate);
                sqlCmd.Parameters.AddWithValue("@logintime", logintime);
                sqlCmd.Parameters.AddWithValue("@logoutdate", logoutdate);
                sqlCmd.Parameters.AddWithValue("@logouttime", logouttime);
                sqlCmd.Parameters.AddWithValue("@status", status);
                sqlCmd.Parameters.AddWithValue("@Browser", browser);
                sqlCmd.Parameters.AddWithValue("@BrowserVersion", browserVersion);
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
        //GetLastLoginDateandTime 
        /// <summary>
        /// for retrieing laaast log in time and daate of user
        /// </summary>
        /// <param name="userid">useriduserid</param>
        /// <returns>data table</returns>
        public static DataTable GetLastLoginByUserID(int userid)
        {
            DataTable vtable = new DataTable("LastLogin");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_getlastloginbyuserid", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@user_id", userid);
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
        //Get Total Profile Tips Count 
        /// <summary>for retrieving count of tips by profile id
        /// 
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>Integer</returns>
        public static int GetTipsCountbyProfileID(int profileID)
        {
            DataTable vtable = new DataTable("ProfileTips");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int returnval = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProileTipsCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);
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


        //Affiliates deletion by lavanya
        /// <summary>
        /// for deleting recieved affiliates
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="afffiliateid">afffiliateid</param>
        /// <returns>Integer</returns>
        public static int DeleteReceivedaffiliate(int profileid, int afffiliateid)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteRAffiliate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@profileid", profileid);
                sqlCmd.Parameters.AddWithValue("@receiveprofileid", afffiliateid);
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
        /// for retriving affiliate invitationsby id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetreceivedAffInvitationsbyID(int profileID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetreceivedInvitationsByProfileID", sqlCon);
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
        //----------- Add Business Contacts
        /// <summary>
        /// for adding business contacts
        /// </summary>
        /// <param name="firstname">firstname</param>
        /// <param name="lastname">lastname</param>
        /// <param name="email">email</param>
        /// <param name="address">address</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone">phone</param>
        /// <param name="mobile">mobile</param>
        /// <param name="fax">fax</param>
        /// <param name="sourcetype">sourcetype</param>
        /// <param name="userid">userid</param>
        /// <param name="importdate">importdate</param>
        /// <param name="contactgroupname">contactgroupname</param>
        /// <param name="companyname">companyname</param>
        /// <param name="id">id</param>
        public static void AddBusinessContacts(string firstname, string lastname, string email, string address, string city, string state, string zipcode, string phone, string mobile, string fax, string sourcetype, int userid, DateTime importdate, string contactgroupname, string companyname, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Add_UserContacts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@firstname", firstname);
                sqlCmd.Parameters.AddWithValue("@lastname", lastname);
                sqlCmd.Parameters.AddWithValue("@email", email);
                sqlCmd.Parameters.AddWithValue("@address", address);
                sqlCmd.Parameters.AddWithValue("@city", city);
                sqlCmd.Parameters.AddWithValue("@state", state);
                sqlCmd.Parameters.AddWithValue("@zipcode", zipcode);
                sqlCmd.Parameters.AddWithValue("@phone", phone);
                sqlCmd.Parameters.AddWithValue("@mobile", mobile);
                sqlCmd.Parameters.AddWithValue("@fax", fax);
                sqlCmd.Parameters.AddWithValue("@sourcetype", sourcetype);
                sqlCmd.Parameters.AddWithValue("@userid", userid);
                sqlCmd.Parameters.AddWithValue("@importdate", importdate);
                sqlCmd.Parameters.AddWithValue("@contactgroupname", contactgroupname);
                sqlCmd.Parameters.AddWithValue("@CompanyName", companyname);
                sqlCmd.Parameters.AddWithValue("@ID", id);
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

        /// <summary>
        /// for updating business contacts
        /// </summary>
        /// <param name="contactID">contactID</param>
        /// <param name="firstname">firstname</param>
        /// <param name="lastname">lastname</param>
        /// <param name="email">email</param>
        /// <param name="address">address</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone">phone</param>
        /// <param name="mobile">mobile</param>
        /// <param name="fax">fax</param>
        /// <param name="contactgroupname">contactgroupname</param>
        /// <param name="companyname">companyname</param>
        /// <param name="id">id</param>
        public static void UpdateBusinessContacts(int contactID, string firstname, string lastname, string email, string address, string city, string state, string zipcode, string phone, string mobile, string fax, string contactgroupname, string companyname, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Update_UserContact", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);
                sqlCmd.Parameters.AddWithValue("@firstname", firstname);
                sqlCmd.Parameters.AddWithValue("@lastname", lastname);
                sqlCmd.Parameters.AddWithValue("@email", email);
                sqlCmd.Parameters.AddWithValue("@address", address);
                sqlCmd.Parameters.AddWithValue("@city", city);
                sqlCmd.Parameters.AddWithValue("@state", state);
                sqlCmd.Parameters.AddWithValue("@zipcode", zipcode);
                sqlCmd.Parameters.AddWithValue("@phone", phone);
                sqlCmd.Parameters.AddWithValue("@mobile", mobile);
                sqlCmd.Parameters.AddWithValue("@fax", fax);
                sqlCmd.Parameters.AddWithValue("@contactgroupname", contactgroupname);
                sqlCmd.Parameters.AddWithValue("@CompanyName", companyname);
                sqlCmd.Parameters.AddWithValue("@ID", id);
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

        /// <summary>
        /// or dleting business contact
        /// </summary>
        /// <param name="contactID">contactID</param>
        public static void DeleteBuinessContact(int contactID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_delete_UserContact", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);
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

        /// <summary>
        /// for retrieving all user contacts
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="checkFlag">checkFlag</param>
        /// <param name="selectType">selectType</param>
        /// <returns>data table</returns>
        public static DataTable GetAllUserContacts(int userID, int checkFlag, string selectType)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetALLUser_Contacts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CheckFlag", checkFlag);
                sqlCmd.Parameters.AddWithValue("@CheckSelectALL", selectType);
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
        /// for retrieving all user details by type
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="checkFlag">checkFlag></param>
        /// <param name="selectType">selectType</param>
        /// <param name="isPrivateModule">isPrivateModule</param>
        /// <returns>datatable</returns>
        public static DataTable GetAllUserContactsbyType(int userID, int checkFlag, string selectType, bool isPrivateModule)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetALLUser_ContactsByType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CheckFlag", checkFlag);
                sqlCmd.Parameters.AddWithValue("@CheckSelectALL", selectType);
                sqlCmd.Parameters.AddWithValue("@IsPrivateModule", isPrivateModule);
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
        /// for retrieving user contact details
        /// </summary>
        /// <param name="contactID">contactID</param>
        /// <returns>data table</returns>
        public static DataTable GetUserContactDetails(int contactID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetuserContact", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);
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
        /// for retrievig user contact dtails by group name
        /// </summary>
        /// <param name="groupName">groupName</param>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetUserContactDetailsbyGroupName(string groupName, int userID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Getcontactdetailsbygroupname", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@GroupName", groupName);
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

        /// <summary>
        /// for inserting user contact usage
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="affiliateUsage">affiliateUsage</param>
        /// <param name="generalTabUsage">generalTabUsage</param>
        /// <param name="couponUsage">couponUsage</param>
        /// <param name="messageUsage">messageUsage</param>
        /// <param name="emailUsage">emailUsage</param>
        /// <param name="newsletterUsage">newsletterUsage</param>
        /// <param name="businessUpdateUsage"></param>
        /// <param name="usageDate">usageDate</param>
        /// <param name="id">id</param>
        public static void InsertUserContactUsage(int userID, int profileID, int affiliateUsage, int generalTabUsage, int couponUsage, int messageUsage, int emailUsage, int newsletterUsage, int businessUpdateUsage, DateTime usageDate, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertUserContactUsage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@profileID", profileID);
                sqlCmd.Parameters.AddWithValue("@AffiliateUsage", affiliateUsage);
                sqlCmd.Parameters.AddWithValue("@AssociateUsage", generalTabUsage);
                sqlCmd.Parameters.AddWithValue("@CouponUsage", couponUsage);
                sqlCmd.Parameters.AddWithValue("@MessageUsage", messageUsage);
                sqlCmd.Parameters.AddWithValue("@EmailUsage", emailUsage);
                sqlCmd.Parameters.AddWithValue("@NewsletterUsage", newsletterUsage);
                sqlCmd.Parameters.AddWithValue("@BusinessUpdateUsage", businessUpdateUsage);
                sqlCmd.Parameters.AddWithValue("@UsageDate", usageDate);
                sqlCmd.Parameters.AddWithValue("@ID", id);
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

        /// <summary>
        /// for updating user contact usage
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="affiliateUsage">affiliateUsage</param>
        /// <param name="generalTabUsage">generalTabUsage</param>
        /// <param name="couponUsage">couponUsage</param>
        /// <param name="messageUsage">messageUsage</param>
        /// <param name="emailUsage">emailUsage</param>
        /// <param name="newsletterUsage">newsletterUsage</param>
        /// <param name="businessUpdateUsage">businessUpdateUsage</param>
        /// <param name="usageDate">usageDate</param>
        /// <param name="id"></param>
        public static void UpdateUserContactUsage(int userID, int affiliateUsage, int generalTabUsage, int couponUsage, int messageUsage, int emailUsage, int newsletterUsage, int businessUpdateUsage, DateTime usageDate, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateUserContactUsage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@AffiliateUsage", affiliateUsage);
                sqlCmd.Parameters.AddWithValue("@AssociateUsage", generalTabUsage);
                sqlCmd.Parameters.AddWithValue("@CouponUsage", couponUsage);
                sqlCmd.Parameters.AddWithValue("@MessageUsage", messageUsage);
                sqlCmd.Parameters.AddWithValue("@EmailUsage", emailUsage);
                sqlCmd.Parameters.AddWithValue("@NewsletterUsage", newsletterUsage);
                sqlCmd.Parameters.AddWithValue("@BusinessUpdateUsage", businessUpdateUsage);
                sqlCmd.Parameters.AddWithValue("@UsageDate", usageDate);
                sqlCmd.Parameters.AddWithValue("@ID", id);
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

        /// <summary>
        /// for retrieving user contact detils by usage date
        /// </summary>
        /// <param name="usageDate">usageDate</param>
        /// <param name="userID">userID</param>
        /// <returns></returns>
        public static DataTable GetUserContactDetailsUsage(DateTime usageDate, int userID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CheckContactUsage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UsageDate", usageDate);
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

        /// <summary>
        /// for checking the contact of user
        /// </summary>
        /// <param name="groupName">groupName</param>
        /// <param name="email">email</param>
        /// <param name="userID">userID</param>
        /// <returns>Integer</returns>
        public static int CheckUserContactValidation(string groupName, string email, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int countvalue = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CheckDuplicatecontactingroup", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.Parameters.AddWithValue("@Group", groupName);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Connection = sqlCon;
                countvalue = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return countvalue;
        }
        //----------- End Business Contacts
        /// <summary>
        /// for inserting contact group name
        /// </summary>
        /// <param name="contactGroupID">contactGroupID</param>
        /// <param name="contactGroupname">contactGroupID</param>
        /// <param name="userID">userID</param>
        /// <param name="dateCreated">dateCreated</param>
        /// <param name="dateModified">dateModified</param>
        /// <param name="activeFlag">activeFlag</param>
        /// <param name="discription">discription</param>
        /// <param name="id">id</param>
        /// <param name="pGroupType">pGroupType</param>
        /// <param name="pUserModuleID">pUserModuleID</param>
        /// <param name="pIsSystemGroup">pIsSystemGroup</param>
        /// <param name="pIsMasterGroup">pIsMasterGroup</param>
        public static void InsertContactGroupName(int contactGroupID, string contactGroupname, int userID, DateTime dateCreated, DateTime dateModified,
            Boolean activeFlag, string discription, int id, string pGroupType, int pUserModuleID, bool pIsSystemGroup, bool pIsMasterGroup)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_AddContactGrouptoUserContacts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactGroupID", contactGroupID);
                sqlCmd.Parameters.AddWithValue("@ContactGroupname", contactGroupname);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@DateCreated", dateCreated);
                sqlCmd.Parameters.AddWithValue("@DateModified", dateModified);
                sqlCmd.Parameters.AddWithValue("@Active_Flag", activeFlag);
                sqlCmd.Parameters.AddWithValue("@Discription", discription);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.Parameters.AddWithValue("@GroupType", pGroupType);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", pUserModuleID);
                sqlCmd.Parameters.AddWithValue("@SystemGroup", pIsSystemGroup);
                sqlCmd.Parameters.AddWithValue("@IsMasterGroup", pIsMasterGroup);
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

        /// <summary>
        /// for updating contact group name
        /// </summary>
        /// <param name="contactGroupname">contactGroupname</param>
        /// <param name="contactGroupID">contactGroupID</param>
        /// <param name="dateModified">dateModified</param>
        /// <param name="activeFlag">activeFlag</param>
        /// <param name="discription">discription</param>
        /// <param name="id">id</param>
        public static void UpdateContactGroupName(string contactGroupname, int contactGroupID, DateTime dateModified, Boolean activeFlag, string discription, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateContactGroupName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactGroupname", contactGroupname);
                sqlCmd.Parameters.AddWithValue("@CID", contactGroupID);
                sqlCmd.Parameters.AddWithValue("@DateModified", dateModified);
                sqlCmd.Parameters.AddWithValue("@Active_Flag", activeFlag);
                sqlCmd.Parameters.AddWithValue("@Discription", discription);
                sqlCmd.Parameters.AddWithValue("@ID", id);
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

        /// <summary>
        /// for retrieving user contact group names
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>data table</returns>
        public static DataTable GetUserContactGroupNames(int userID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetUserContactGroupNames", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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

        /// <summary>
        /// for checking user listing valiation
        /// </summary>
        /// <param name="groupName">groupName</param>
        /// <param name="userID">userID</param>
        /// <returns>integer</returns>
        public static int CheckUserListingValidation(string groupName, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int countvalue = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckListingGroupName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@GroupName", groupName);
                sqlCmd.Connection = sqlCon;
                countvalue = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return countvalue;
        }

        /// <summary>
        /// for retrieving user contact group by group id
        /// </summary>
        /// <param name="cid">cid</param>
        /// <returns>data table</returns>
        public static DataTable GetUserContactGroupByGroupID(int cid)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetGroupDetailsByGroupID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CID", cid);
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
        //To Get Latest  sent invitation  by profile_id 
        /// <summary>
        /// getting new affilation invitation
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="username">username</param>
        /// <returns>data table</returns>
        public static DataTable Getnewaffiliateinvitation(int profileId, string username)
        {
            DataTable invsent = new DataTable();

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GeNewAffliateInvitation", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileId);
                sqlCmd.Parameters.AddWithValue("@username", username);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(invsent);
                return invsent;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        //Delete Affliate  Sender Invitation
        /// <summary>
        /// for deleting affiliation invitation
        /// </summary>
        /// <param name="uniqueID">uniqueID</param>
        public static void DeleteAffiliateInvitation(string uniqueID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_deleteSenderinvitation", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UniqueID", uniqueID);

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
        //-------------- Adding Reseller Code
        /// <summary>
        /// for inserting reseller code
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="resellerCode">resellerCode</param>
        /// <param name="dateCreated">dateCreated</param>
        public static void InsertResellerCode(int profileID, int userID, string resellerCode, DateTime dateCreated)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_AddResellerCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ResellerCode", resellerCode);
                sqlCmd.Parameters.AddWithValue("@CreatedDate", dateCreated);
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

        /// <summary>
        /// getting reseller code for profile id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetResellerCodeforProfileID(int profileID)
        {
            DataTable invsent = new DataTable();

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetResellerCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(invsent);
                return invsent;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        //-------------- End of Reseller Code
        //Pallavi
        //25-feb-2009
        /// <summary>
        /// getting replied messages count
        /// </summary>
        /// <param name="msgID">msgID</param>
        /// <returns>Integer</returns>
        public static int GetRepliedMessageCountByMsgID(int msgID)
        {


            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int repliedMsgCount = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_getReplyMsgCountbymsgid", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@Msg_ID", msgID);
                sqlCmd.Connection = sqlCon;
                repliedMsgCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return repliedMsgCount;
        }
        //-------------------  Reseller Track Code
        /// <summary>
        /// for inserting reseller tract
        /// </summary>
        /// <param name="clientIPAddress">clientIPAddress</param>
        /// <param name="sessionID">sessionID</param>
        /// <param name="trackingCode">trackingCode</param>
        /// <param name="dateCreated">dateCreated</param>
        public static void InsertResellerTrack(string clientIPAddress, string sessionID, string trackingCode, DateTime dateCreated)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_AddResellerTrackCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@VisitorIP", clientIPAddress);
                sqlCmd.Parameters.AddWithValue("@SessionID", sessionID);
                sqlCmd.Parameters.AddWithValue("@ResellerCode", trackingCode);
                sqlCmd.Parameters.AddWithValue("@ClickedDate", dateCreated);
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

        /// <summary>
        /// for deleting user contact group
        /// </summary>
        /// <param name="groupID">groupID</param>
        /// <param name="groupNameID">groupNameID</param>
        /// <param name="userID">userID</param>
        public static void DeleteUserContactGroup(int groupID, string groupNameID, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DeleteUserGroup", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CID", groupID);
                sqlCmd.Parameters.AddWithValue("@ContactGroupID", groupNameID);
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
        //end
        // ----------------- BuyAddons Transaction----------
        // Start of Issue 823
        /// <summary>
        /// for inseerting buy addons transsits
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="cities">cities</param>
        /// <param name="state">state</param>
        /// <param name="categories">categories</param>
        /// <param name="categorieIds">categorieIds</param>
        /// <param name="userid">userid</param>
        /// <param name="createdDate">createdDate</param>
        /// <param name="profileID">profileID</param>
        /// <param name="cityAmount">cityAmount</param>
        /// <param name="cityPrice">cityPrice</param>
        /// <param name="industryAmount">industryAmount</param>
        /// <param name="industryPrice">industryPrice</param>
        /// <param name="cityCount">cityCount</param>
        /// <param name="industryCount">industryCount</param>
        /// <param name="searchcityState">searchcityState</param>
        /// <param name="zipcodes">zipcodes</param>
        /// <returns>integer</returns>
        public static int InsertBuyAddonsTraans(int orderID, string cities, string state, string categories, string categorieIds, int userid, DateTime createdDate, int profileID, int cityAmount, string cityPrice, int industryAmount, string industryPrice, int cityCount, int industryCount, string searchcityState, string zipcodes)
        {
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable vtable = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertBuyAddonsTrans", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@orderid", orderID);
                sqlCmd.Parameters.AddWithValue("@cities", cities);
                sqlCmd.Parameters.AddWithValue("@States", state);
                sqlCmd.Parameters.AddWithValue("@Categories", categories);
                sqlCmd.Parameters.AddWithValue("@Categorieids", categorieIds);
                sqlCmd.Parameters.AddWithValue("@userid", userid);
                sqlCmd.Parameters.AddWithValue("@createdate", createdDate);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@CityAmount", cityAmount);
                sqlCmd.Parameters.AddWithValue("@CityPrice", cityPrice);
                sqlCmd.Parameters.AddWithValue("@IndustryAmount", industryAmount);
                sqlCmd.Parameters.AddWithValue("@IndustryPrice", industryPrice);
                sqlCmd.Parameters.AddWithValue("@Citycount", cityCount);
                sqlCmd.Parameters.AddWithValue("@IndustryCount", industryCount);
                sqlCmd.Parameters.AddWithValue("@searchcity_state", searchcityState);
                sqlCmd.Parameters.AddWithValue("@zipcodes", zipcodes);
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
        // End of Issue 823
        /// <summary>
        /// getting buy add ons transaction 
        /// </summary>
        /// <param name="orderno">orderno</param>
        /// <returns>data table</returns>
        public static DataTable GetBuyAdddonsTransaction(int orderno)
        {
            DataTable invsent = new DataTable();

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBuyTrans", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Orderno", orderno);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(invsent);
                return invsent;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        //-------------------End---------------------------

        /// <summary>
        /// getting zip codes by city and state
        /// </summary>
        /// <param name="cityname">cityname</param>
        /// <param name="statename">statename</param>
        /// <returns>data table</returns>
        public static DataTable Getzipcodesbycityandstate(string cityname, string statename)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable zipcodes = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_Getzipcodesbystateandcity", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@cityname", cityname);
                sqlCmd.Parameters.AddWithValue("@statename", statename);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(zipcodes);
                return zipcodes;
            }
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
        /// Get users for search update
        /// </summary>
        /// <returns><data table/returns>
        public static DataTable Getusersforsearchupdate()
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtusers = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_Getuserstoupdatesearch", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtusers);
                return dtusers;
            }
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
        /// Updating city state and zipcodes
        /// </summary>
        /// <param name="userid">userid</param>
        /// <param name="states">states</param>
        /// <param name="citystates">citystates</param>
        /// <param name="zipcodes">zipcodes</param>
        public static void Updatecitystateandzipcodes(int userid, string states, string citystates, string zipcodes)
        {
            DataTable vtable = new DataTable("business");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {

                SqlCommand sqlCmd = new SqlCommand("Usp_updatecitystateandzipcodes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userid", userid);
                sqlCmd.Parameters.AddWithValue("@searchstates", states);
                sqlCmd.Parameters.AddWithValue("@citystate", citystates);
                sqlCmd.Parameters.AddWithValue("@zipcodes", zipcodes);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
            }
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
        /// Get BuyAddons Transaction by OrderID
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetBuyAddonsTransactionbyOrderID(int orderID)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtusers = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBuyAddonsTransByOrderID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OrderID", orderID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtusers);
                return dtusers;
            }
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
        /// Get Profile id To Update Calendar details
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetProfileidToUpdateCalendardetails()
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtusers = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_Getprofileids_ToUpdateCalender", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtusers);
                return dtusers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        // -------------------- Start  Email Messages--------------------
        /// <summary>
        /// Inserting Email Message
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="toEmails">toEmails</param>
        /// <param name="subject">subject</param>
        /// <param name="message">message</param>
        /// <param name="sentDate">sentDate</param>
        /// <param name="attachment">attachment</param>
        /// <returns>integer</returns>
        public static int InsertEmailMessage(int userID, int profileID, string toEmails, string subject, string message, DateTime sentDate, string attachment)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int emailTableID = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertEmailMessage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userid", userID);
                sqlCmd.Parameters.AddWithValue("@profileid", profileID);
                sqlCmd.Parameters.AddWithValue("@ToEmails", toEmails);
                sqlCmd.Parameters.AddWithValue("@Subject", subject);
                sqlCmd.Parameters.AddWithValue("@Message", message);
                sqlCmd.Parameters.AddWithValue("@SentDate", sentDate);
                sqlCmd.Parameters.AddWithValue("@Attachment", attachment);
                sqlCmd.Connection = sqlCon;
                emailTableID = Convert.ToInt32(sqlCmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return emailTableID;
        }

        /// <summary>
        /// Deleting Email Message BY EmailID
        /// </summary>
        /// <param name="emailID">emailID</param>
        public static void DeleteEmailMessageBYEmailID(int emailID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DeleteUserEmailMessage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailID", emailID);
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

        /// <summary>
        /// Get Email Message by UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>data table</returns>
        public static DataTable GetEmailMessagebyUserID(int userID)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtusers = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetUserSentEmailMessagesbyUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtusers);
                return dtusers;
            }
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
        /// Get Email Message by EmailID
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <returns>data table</returns>
        public static DataTable GetEmailMessagebyEmailID(int emailID)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtusers = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetEmailMessagebyEmailID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailID", emailID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtusers);
                return dtusers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        // --------------------End  Email Messages--------------------
        /// <summary>
        /// Get User Details by user email
        /// </summary>
        /// <param name="useremail">useremail</param>
        /// <returns>data table</returns>
        public static DataTable GetUserDetailsbyuseremail(string useremail)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_Getuserdetails_byuseremail", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@useremail", useremail);
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
        //--------------------Start Update OnlineBusiness Account---------------------

        /// <summary>
        /// Update User Online Business Account
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="enabled">enabled</param>
        public static void UpdateUserOnlineBusinessAccount(int profileID, Boolean enabled)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateOnlineBusinessFlag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@Enabled", enabled);
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

        //--------------------End Update OnlineBusiness Account---------------------

        //----------------- Start URL Submitter Functionality------------------//
        /// <summary>
        /// Insert Submit Engine Details
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="name">name</param>
        /// <param name="url">url</param>
        /// <param name="logopath">logopath</param>
        /// <param name="pagerank">pagerank</param>
        /// <param name="status">status</param>
        public static void InsertSubmitEngineDetails(int category, string name, string url, string logopath, int pagerank, Boolean status)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertSubmitEngineDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Category", category);
                sqlCmd.Parameters.AddWithValue("@Name", name);
                sqlCmd.Parameters.AddWithValue("@URL", url);
                sqlCmd.Parameters.AddWithValue("@Logopath", logopath);
                sqlCmd.Parameters.AddWithValue("@Pagerank", pagerank);
                sqlCmd.Parameters.AddWithValue("@Status", status);
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

        /// <summary>
        /// Inserting Submit status
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="engineId">engineId</param>
        /// <param name="status">status</param>
        /// <param name="address">address</param>
        /// <param name="phone">phone</param>
        /// <param name="profilename">profilename</param>
        /// <param name="profileurl">profileurl</param>
        /// <param name="servicekeywords">servicekeywords</param>
        /// <param name="uniqueurl">uniqueurl</param>
        /// <param name="id">id</param>
        public static void InsertSubmitstatus(int profileid, int engineId, string status, string address, string phone, string profilename, string profileurl, string servicekeywords, string uniqueurl, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertSubmitstatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileid);
                sqlCmd.Parameters.AddWithValue("@Engine_ID", engineId);
                sqlCmd.Parameters.AddWithValue("@Status ", status);
                sqlCmd.Parameters.AddWithValue("@Address", address);
                sqlCmd.Parameters.AddWithValue("@Phone", phone);
                sqlCmd.Parameters.AddWithValue("@profilename", profilename);
                sqlCmd.Parameters.AddWithValue("@profileurl", profileurl);
                sqlCmd.Parameters.AddWithValue("@servicekeywords", servicekeywords);
                sqlCmd.Parameters.AddWithValue("@unique_URL", uniqueurl);
                sqlCmd.Parameters.AddWithValue("@ID", id);
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

        /// <summary>
        /// Get Submit engine details
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetSubmitenginedetails()
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtengine = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetsubmitEngines", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtengine);
                return dtengine;
            }
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
        /// Get Submit directories
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetSubmitdirectories()
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtengine = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_Getsubmitdirectories", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtengine);
                return dtengine;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        //--------------------------------GetUrlSubmissionReport------------------------------
        /// <summary>
        /// Get User Url Submisssion Report
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetUserUrlSubmisssionReport(int profileID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GETURLSubmissionReport", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
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
        /// Get Use rUrl Submisssion Details By EngineID
        /// </summary>
        /// <param name="engineID">engineID</param>
        /// <returns>data table<returns>
        public static DataTable GetUserUrlSubmisssionDetailsByEngineID(int engineID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetUrlDirectoryDetailsbyEngineID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EngineID", engineID);
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

        //--------------------------------GetUrlSubmissionReport------------------------------
        //----------------- End URL Submitter Functionality------------------


        //---------------Email Scheduling----------------------------------------

        /// <summary>
        /// Inserting EmailS chedule History
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="contactsCount">contactsCount</param>
        /// <param name="emailsCount">emailsCount</param>
        /// <param name="emailsTableID">emailsTableID</param>
        /// <param name="sendFlag">sendFlag</param>
        /// <param name="createddate">sendFlag</param>
        /// <param name="modifiedDate">modifiedDate</param>
        /// <returns>integer</returns>
        public static int InsertEmailScheduleHistory(int profileID, int userID, int contactsCount, int emailsCount, int emailsTableID, int sendFlag, DateTime createddate, DateTime modifiedDate)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int schID = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_InsertEmailHistory";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ContactCount", contactsCount);
                sqlCmd.Parameters.AddWithValue("@EmailCount", emailsCount);
                sqlCmd.Parameters.AddWithValue("@EmailID", emailsTableID);
                sqlCmd.Parameters.AddWithValue("@SentFlag", sendFlag);
                sqlCmd.Parameters.AddWithValue("@Createddate", createddate);
                sqlCmd.Parameters.AddWithValue("@ModifiedDate", modifiedDate);
                schID = Convert.ToInt32(sqlCmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return schID;

        }

        /// <summary>
        /// Inserting Scheduled Email
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="subject">subject</param>
        /// <param name="emails">emails</param>
        /// <param name="messages">messages</param>
        /// <param name="sendingDate">sendingDate</param>
        /// <param name="sentFlag">sentFlag</param>
        /// <param name="isAttachment">isAttachment</param>
        /// <param name="attachment">attachment</param>
        /// <param name="schHisID">schHisID</param>
        /// <param name="emailsTableID">emailsTableID</param>
        /// <param name="schduleDate">schduleDate</param>
        /// <param name="id">id</param>
        /// <returns>integer</returns>
        public static int InsertScheduledEmail(int profileID, int userID, string subject, string emails, string messages, DateTime sendingDate, int sentFlag, Boolean isAttachment, string attachment, int schHisID, int emailsTableID, DateTime schduleDate, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int schID = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_InsertEmailCampagin";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@Subject", subject);
                sqlCmd.Parameters.AddWithValue("@Emails", emails);
                sqlCmd.Parameters.AddWithValue("@Message", messages);
                sqlCmd.Parameters.AddWithValue("@SendingDate", sendingDate);
                sqlCmd.Parameters.AddWithValue("@SendFlag", sentFlag);
                sqlCmd.Parameters.AddWithValue("@IsAttachment", isAttachment);
                sqlCmd.Parameters.AddWithValue("@Attachment", attachment);
                sqlCmd.Parameters.AddWithValue("@SchHisID", schHisID);
                sqlCmd.Parameters.AddWithValue("@EmailID", emailsTableID);
                sqlCmd.Parameters.AddWithValue("@SchduleDate", schduleDate);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                schID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return schID;
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
        /// Get Scheduled Email Count
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>integer</returns>
        public static int GetSchEmailCount(int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int schCount = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_GetSchEmailCount";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                schCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return schCount;
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
        /// Get Campaign Email Count
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <returns></returns>
        public static int GetCampaignEmailCount(int emailID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int schCount = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_GetCampaignEmailCount";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailID ", emailID);
                schCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return schCount;
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
        /// getting campaign email details
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <returns>data table</returns>
        public static DataTable GetCampaignEmailDetails(int emailID)
        {
            DataTable user = new DataTable("user");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetScheduledEmailDetailsbyEmailID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailID", emailID);
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
        /// Get Schdule Email Count for Date
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="sendingDate">sendingDate</param>
        /// <param name="schID">schID</param>
        /// <returns>integer</returns>
        public static int GetSchduleEmailCountforDate(int userID, DateTime sendingDate, int schID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int schCount = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_GetEmailsCountforDayandUserID";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@Date", sendingDate);
                sqlCmd.Parameters.AddWithValue("@SchID", schID);
                schCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return schCount;
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
        /// Canceling Email Campaign
        /// </summary>
        /// <param name="schduleID">schduleID</param>
        public static void CancelEmailCampaign(int schduleID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_CancelEmailCampaign";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchID", schduleID);
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

        /// <summary>
        /// Updating Email Usage By UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="usageDate">usageDate</param>
        public static void UpdateEmailUsageByUserID(int userID, DateTime usageDate)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_UpdateEmailDayLimitCount";
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

        /// <summary>
        /// getting maximum schedule date for email
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>string</returns>
        public static string GetMaxSchDateforEmail(int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            string maxDate = string.Empty;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_GetEmailMaxSchedulingDate";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                maxDate = Convert.ToString(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return maxDate;

        }

        /// <summary>
        /// getting email sent history
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetEmailSentHistory(int emailID, int profileID)
        {
            DataTable vtable = new DataTable("Coupons");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetEmailSentHistory", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailID", emailID);
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
        /// Getting Email Schedule Count for EmailID
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <param name="profileID">profileID</param>
        /// <returns>integer</returns>
        public static int GetEmailScheuleCountforEmailID(int emailID, int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int count = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_GetEmailSentHistoryCount";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailID", emailID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return count;

        }


        //---------------Email Scheduling----------------------------------------


        //-------------- Check For Reaseller DiscountAmount-----------------------

        /// <summary>
        /// Getting Reseller Discount Amount
        /// </summary>
        /// <param name="resellerCode">resellerCode</param>
        /// <returns>decimal</returns>
        public static decimal GetResellerDiscountAmount(string resellerCode)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            decimal discountAmount = 0.00M;
            string value = string.Empty;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_CheckResellerDiscountAmount";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Reseller_Code", resellerCode);
                value = Convert.ToString(sqlCmd.ExecuteScalar());
                if (value != "")
                {
                    discountAmount = Convert.ToDecimal(value);
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return discountAmount;

        }


        //-------------- Check For Reaseller DiscountAmount-----------------------

        //-------------- Check For Email ID for Default Group -----------------------
        /// <summary>
        /// checking email id for defualt group
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <param name="userID">userID</param>
        /// <returns>Integer</returns>
        public static int CheckEmailIDForDefaultGroup(string emailID, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int checkID = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_CheckEmailIDForUserID";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Email", emailID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                checkID = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return checkID;

        }

        /// <summary>
        /// Checking For Email Opt Flag Count
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <param name="userID">userID</param>
        /// <returns>integer</returns>
        public static int CheckForEmailOptFlagCount(string emailID, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int checkID = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_CheckOptFlagForEmail";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Email", emailID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                checkID = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return checkID;

        }

        /// <summary>
        /// for unscubscribing emails
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <param name="userID">userID</param>
        public static void UnSubscribeUserEmails(string emailID, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_UnSubScribleEmail";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Email", emailID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
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

        /// <summary>
        /// Subscribed User Emails
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <param name="userID">userID</param>
        public static void SubscribeUserEmails(string emailID, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_SubScribleEmail";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Email", emailID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
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

        /// <summary>
        /// Adding UnGrouped Contacts Group
        /// </summary>
        /// <param name="userID">userID</param>
        public static void AddUnGroupedContactsGroup(int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_AddUserUngroupedContactsGroup";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
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

        /// <summary>
        /// Checking For Ungrouped Contacts Group
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>integer</returns>
        public static int CheckForUngroupedContactsGroup(int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int checkGroup = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_CheckForUserUnGroup";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                checkGroup = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return checkGroup;

        }

        //-------------- Check For Email ID for Default Group -----------------------
        /// <summary>
        /// Getting Pending Invitations by ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetPendingInvitationsbyProfileID(int profileID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetPendingAffiliateInvitaions", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);

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
        /// Deleting Affiliate
        /// </summary>
        /// <param name="profileAffiliateID">profileAffiliateID</param>
        /// <returns>Integer</returns>
        public static int DeleteAffiliate(int profileAffiliateID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DeleteAffiliatebyProfile_Affiliate_ID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_Affiliate_ID", profileAffiliateID);
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
        //********** New Affiliates Status ***************/
        /// <summary>
        /// Getting New Affiliates Count
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>Integer</returns>
        public static int GetNewAffiliatesCount(int profileID)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetNewAffiliatesCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                int profID = (int)(sqlCmd.ExecuteScalar());
                return profID;
            }
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
        /// Updating New Affiliate Status
        /// </summary>
        /// <param name="profileID">profileID</param>
        public static void UpdateNewAffiliateStatus(int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "usp_UpdateAffiliateStatus";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);

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

        //************************************//
        //*********** Update Second URL **************//
        /// <summary>
        /// Updatig Profiles Second Url
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="profileSecondUrl">profileSecondUrl</param>
        /// <param name="id">id</param>
        public static void UpdateProfileSecondUrl(int profileID, string profileSecondUrl, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_UpdateSecondURL";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@ProfileSecondURL", profileSecondUrl);
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

        //*********** Update Second URL **************//

        /// <summary>
        /// Geting General Tab Invitation Details By InvitationID
        /// </summary>
        /// <param name="invitationID">invitationID</param>
        /// <returns>Data table</returns>
        public static DataTable GetGeneralTabInvitationDetailsByInvitationID(int invitationID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetGeneralTabInvitationDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InvitationID", invitationID);

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

        /*********************** Monthly subscription Changes ********/
        /// <summary>
        /// Updating Subscription Type in Userstable
        /// </summary>
        /// <param name="subscriptionType">subscriptionType</param>
        /// <param name="userID">userID</param>
        /// <returns>integer</returns>
        public static int UpdateSubscriptionTypeinUserstable(int subscriptionType, int userID)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateSubscriptionTypeinUserstable", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Subscription_Type", subscriptionType);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
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
        /// Updating Profile Order details
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="enddate">enddate</param>
        /// <param name="subscriptionPeriod">subscriptionPeriod</param>
        /// <returns>integer</returns>
        public static int UpdateProfileOrderdetails(int orderID, string enddate, int subscriptionPeriod)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateSubscriptiondetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OrderID", orderID);
                sqlCmd.Parameters.AddWithValue("@Enddate", enddate);
                sqlCmd.Parameters.AddWithValue("@SubscriptionPeriod", subscriptionPeriod);
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

        /**********************  End Monthly subscription Changes *****/


        /**********************  Email Tracking Report  ***************/
        /// <summary>
        /// Inserting Email Tracking Histroy
        /// </summary>
        /// <param name="schID">schID</param>
        /// <param name="schHisID">schHisID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="emailID">emailID</param>
        /// <param name="address">address</param>
        /// <param name="browserType">browserType</param>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <param name="viewCount">viewCount</param>
        /// <param name="ipAddress">ipAddress</param>

        public static void InsertEmailTrackingHistroy(int schID, int schHisID, int profileID, string emailID, string address, string browserType, string latitude, string longitude, int viewCount, string ipAddress)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_InsertEmailReceiverTrack";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchID", schID);
                sqlCmd.Parameters.AddWithValue("@SchHisID", schHisID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@IPAddress", ipAddress);
                sqlCmd.Parameters.AddWithValue("@Email_ID", emailID);
                sqlCmd.Parameters.AddWithValue("@Address", address);
                sqlCmd.Parameters.AddWithValue("@BrowserType", browserType);
                sqlCmd.Parameters.AddWithValue("@Latitude", latitude);
                sqlCmd.Parameters.AddWithValue("@longitude", longitude);
                sqlCmd.Parameters.AddWithValue("@View_Count", viewCount);
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

        /// <summary>
        /// Updating Email Track View Count
        /// </summary>
        /// <param name="schID">schID</param>
        /// <param name="viewCount">viewCount</param>
        public static void UpdateEmailTrackViewCount(int schID, int viewCount)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_UpdateProfileViewCount";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchID", schID);
                sqlCmd.Parameters.AddWithValue("@View_Count", viewCount);
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
        /// <summary>
        /// Getting Email Receiver Track Rreport
        /// </summary>
        /// <param name="schID">schID</param>
        /// <returns>data table</returns>
        public static DataTable GetEmailReceiverTrackRreport(int schID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetEmailReceiverDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchID", schID);
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
        /// Geting Top Schedule Email ID for Email Track
        /// </summary>
        /// <returns>Integer</returns>
        public static int GetTopScheduleEmailIDforEmailTrack()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int schID = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_GetTopSchEmailIDForTrack";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                schID = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return schID;

        }
        /// <summary>
        /// Getting Email Schdule Details by SchduleID
        /// </summary>
        /// <param name="schID">schID</param>
        /// <returns>data table</returns>
        public static DataTable GetEmailSchduleDetailsbySchduleID(int schID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetEmailSchduleDetailsbySchduleID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchID", schID);
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
        /// Get Tracked Email Count For SchHisID
        /// </summary>
        /// <param name="schHisID">schHisID</param>
        /// <returns>integer</returns>
        public static int GetTrackedEmailCountForSchHisID(int schHisID)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetTrackedEmailCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchHisID", schHisID);
                int schID = (int)(sqlCmd.ExecuteScalar());
                return schID;
            }
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
        /// Updating Email Tracking Optout
        /// </summary>
        /// <param name="schID">schID</param>
        public static void UpdateEmailTrackingOptout(int schID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_UpdateEmailTrackOptOut";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchID", schID);
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

        /// <summary>
        /// Getting Email Track Opt Out Flag Count
        /// </summary>
        /// <param name="schHisID">schHisID</param>
        /// <returns>integer</returns>
        public static int GetEmailTrackOptOutFlagCount(string schHisID)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetEmailTrackOptOutFalg", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchHisID", schHisID);
                int count = (int)(sqlCmd.ExecuteScalar());
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


        /**********************  Email Tracking Report  ***************/
        /// <summary>
        /// Getting Affiliate by Profile_Affiliate_ID
        /// </summary>
        /// <param name="profileAffiliateID">profileAffiliateID</param>
        /// <returns>data table</returns>
        public static DataTable GetAffiliatebyProfile_Affiliate_ID(int profileAffiliateID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAffiliatebyProfile_Affiliate_ID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_Affiliate_ID", profileAffiliateID);
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
        /// Getting Aff Invitaion by Profile And ReceiveprofileIDs
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="receiveProfileID">receiveProfileID</param>
        /// <returns>data table</returns>
        public static DataTable GetAffInvbyProfileAndReceiveprofileIDs(int profileID, int receiveProfileID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAffInvbyProfileAndReceiveprofileIDs", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);
                sqlCmd.Parameters.AddWithValue("@ReceiveProfileID", receiveProfileID);
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
        /// Deleting Affiliate Invitation by InvitationID
        /// </summary>
        /// <param name="invitationID">invitationID</param>
        /// <returns>Integer</returns>
        public static int DeleteAffInvbyInvitationID(int invitationID)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DeleteAffInvitationbyInvitationID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@invitationID", invitationID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                //if (vtable != null)
                //{
                //  returnval = Convert.ToInt32(vtable.Rows[0][0]);
                //}

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
        /// Updating  new site Intiation
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="streetaddress">streetaddress</param>
        /// <param name="businessdesc">businessdesc</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="platitude1">platitude1</param>
        /// <param name="plongitude1">plongitude1</param>
        /// <param name="id">id</param>
        /// <returns>integer</returns>
        public static int UpdatenewsiteIntiation(int profileID, string streetaddress, string businessdesc, string city, string state, string country, string zipcode, double platitude1, double plongitude1, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_updateSiteIntiationvalue", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@StreetAddress", streetaddress);
                sqlCmd.Parameters.AddWithValue("@BusinessDesc", businessdesc);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@State", state);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipcode);
                sqlCmd.Parameters.AddWithValue("@latitude1", platitude1);
                sqlCmd.Parameters.AddWithValue("@longitude1", plongitude1);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                int count = (int)(sqlCmd.ExecuteScalar());
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
        /// Getting new General tab invitation
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="username">username</param>
        /// <returns>data table</returns>
        public static DataTable GetnewGeneraltabinvitation(int profileID, string username)
        {
            DataTable invsent = new DataTable();

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GeNewGTabInvitation", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);
                sqlCmd.Parameters.AddWithValue("@username", username);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(invsent);
                return invsent;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        //------------ Get User Contact Details By UserID and Email -------------------------
        /// <summary>
        /// Getting User Contact Details by UserID And Email
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="emailAddress">emailAddress</param>
        /// <returns>data table</returns>
        public static DataTable GetUserContactDetailsbyUserIDAndEmail(int userID, string emailAddress)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetUserContactDetailsByUserIDAndEmail", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@EmailAddress", emailAddress);
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

        //------------ Get User Contact Details By UserID and Email -------------------------

        //------------Confirmation Message Box------------------------------------------
        /// <summary>
        /// Getting Email Shedule History Count
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <returns>integer</returns>
        public static int GetEmailSheduledHistoryCount(int emailID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int schCount = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_GetEmailSheduledHistoryCount";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailID ", emailID);
                schCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return schCount;
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
        //------------Confirmation Message Box------------------------------------------

        //Start Issue 554
        /// <summary>
        /// Updating Status Flag
        /// </summary>
        /// <param name="orderID">orderID</param>
        /// <param name="flag">flag</param>
        public static void UpdateStatusFlag(int orderID, int flag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_updateStatusFlag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OrderID", orderID);
                sqlCmd.Parameters.AddWithValue("@Flag", flag);
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
        /// Getting Order id Details by Userid
        /// </summary>
        /// <param name="userid">userid</param>
        /// <returns>data table</returns>
        public static DataTable GetOrderidDetailsbyUserid(int userid)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetorderIDdetailsbyuserid", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userid", userid);
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

        //End Issue 554

        //Start ISSUE 557
        /// <summary>
        /// Getting Top1 Profile Photos By ProfileID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetTop1ProfilePhotosByProfileID(int profileID)
        {
            DataTable vtable = new DataTable("photos");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetTOP1ProfilePhotosByIDForDashboard", sqlCon);
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

        // End ISSUE 557


        // Unsubscrine Email Balst Opt Outs
        /// <summary>
        /// Unsubscribing Email Blast Eamils
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="schID">schID</param>
        /// <param name="emailAddress">emailAddress</param>
        /// <returns>integer</returns>
        public static int UnsubscrineEmailBlastEamils(int userID, int schID, string emailAddress)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int schCount = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_UnSubscribeEmailBlastEmails";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@SchHisID", schID);
                sqlCmd.Parameters.AddWithValue("@UserEmail", emailAddress);
                schCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return schCount;
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
        /// Getting Opt Out Count For EmailID
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <returns>data table</returns>
        public static DataTable GetOptOutCountForEmailID(int emailID)
        {
            DataTable vtable = new DataTable("photos");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetOptOutCountForEmailID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailID", emailID);
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


        // ENd


        //  Add User Default Contact Groups
        /// <summary>
        /// Adding User Default Contact Groups
        /// </summary>
        /// <param name="userID">userID</param>
        public static void AddUserDefaultContactGroups(int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_AddUserDefaultGroups", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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

        // End


        // Update User Free Flag
        /// <summary>
        /// Update User Free Flag
        /// </summary>
        /// <param name="userID">userID</param>
        public static void UpdateUserFreeFlag(int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_UpdateUserFreeFlag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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


        // End
        /// <summary>
        /// Getting Opt out Contacts
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="checkFlag">checkFlag</param>
        /// <returns></returns>
        public static DataTable GetOptoutContacts(int userID, int checkFlag)
        {
            DataTable vtable = new DataTable("Optout");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetUserOptoutContactNames", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CheckFlag", checkFlag);
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
        /// Inserting and Deleting OptContact
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="contactID">contactID</param>
        /// <param name="cEmail">cEmail</param>
        /// <param name="firstname">firstname</param>
        /// <param name="lastname">lastname</param>
        /// <param name="group">group</param>
        public static void InsertandDeleteOptContact(int profileID, int userID, int contactID, string cEmail, string firstname, string lastname, string group)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_Insert_Delete_UserContact", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);
                sqlCmd.Parameters.AddWithValue("@CEmail", cEmail);
                sqlCmd.Parameters.AddWithValue("@Cfirstname", firstname);
                sqlCmd.Parameters.AddWithValue("@Clastname", lastname);
                sqlCmd.Parameters.AddWithValue("@CGroup", group);
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

        /// <summary>
        /// Getting Contact GroupName
        /// </summary>
        /// <param name="groupID">groupID</param>
        /// <param name="userID">userID</param>
        /// <returns>string</returns>
        public static string GetContactGroupName(int groupID, int userID)
        {
            string returnval = string.Empty;
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetContactGroupName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@GroupID", groupID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable != null && vtable.Rows.Count > 0)
                {
                    returnval = Convert.ToString(vtable.Rows[0][0]);
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

        // To Get Profile Template For User
        /// <summary>
        /// Getting Profile Template For Templatename
        /// </summary>
        /// <param name="templateName">templateName</param>
        /// <returns></returns>
        public static DataTable GetProfileTemplateForTemplatename(string templateName)
        {
            DataTable vtable = new DataTable("Optout");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetProfileTemplateForUser", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@TemplateName", templateName);
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

        // End
        #region Business days and time settings
        // To fix Issue 621
        /// <summary>
        /// Getting Business Days and Timings
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetBusinessDaysandTimings(int profileID)
        {
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBusinessDaysandtimes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);

                return calendar;
            }
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
        /// for Managing Business Days and Times
        /// </summary>
        /// <param name="dayval">dayval</param>
        /// <param name="userID">userID</param>
        /// <param name="starttime">starttime</param>
        /// <param name="endtime">endtime</param>
        /// <param name="profileID">profileID</param>
        /// <param name="ttype">ttype</param>
        /// <param name="activeFlag">activeFlag</param>
        /// <param name="calendarID">calendarID</param>
        /// <param name="id">id</param>
        /// <returns>integer</returns>
        public static int ManageBusinessDaysandTimes(string dayval, int userID, string starttime, string endtime, int profileID, int ttype, bool activeFlag, int calendarID, int id)
        {
            DataTable calendar = new DataTable("calendar");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int returnval = 0;

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ManageBusinessDaysandTime", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userID", userID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@day", dayval);
                sqlCmd.Parameters.AddWithValue("@starttime", starttime);
                sqlCmd.Parameters.AddWithValue("@calendarID", calendarID);
                sqlCmd.Parameters.AddWithValue("@endtime", endtime);
                sqlCmd.Parameters.AddWithValue("@IsActive", activeFlag);
                sqlCmd.Parameters.AddWithValue("@TType", ttype);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(calendar);
                if (calendar != null)
                {
                    returnval = Convert.ToInt32(calendar.Rows[0][0]);
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

        #endregion


        // Get Max Contact Group ID
        /// <summary>
        /// Getting Maximun Contact GroupID For UserID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>integer</returns>
        public static int GetMaximunContactGroupIDForUserID(int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int maxID = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_GetMaxContactGroupID";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                maxID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return maxID;
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

        // End
        /// <summary>
        /// Getting User Contact Group Names Count
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>data table</returns>
        public static DataTable GetUserContactGroupNamesCount(int userID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetUserContactGroupNamesCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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
        /// <summary>
        /// Update Photo Desc by PhotoID
        /// </summary>
        /// <param name="photoID">photoID</param>
        /// <param name="photodesc">photodesc</param>
        /// <param name="profileid">profileid</param>
        /// <param name="id">id</param>
        /// <returns>integer</returns>
        public static int UpdatePhotoDescbyPhotoID(int photoID, string photodesc, int profileid, int id)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Updatephotodesc", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileid);
                sqlCmd.Parameters.AddWithValue("@Profile_Photo_ID", photoID);
                sqlCmd.Parameters.AddWithValue("@imagedesc", photodesc);
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

        //Balaji 20-06-2012 For FOr Image Order Number
        /// <summary>
        /// Updating Image Order Number
        /// </summary>
        /// <param name="photoID">photoID</param>
        /// <param name="imgorderno">imgorderno</param>
        /// <param name="profileid">profileid</param>
        /// <param name="id">id</param>
        /// <returns>integer</returns>
        public static int UpdateImageOrderNumber(int photoID, decimal imgorderno, int profileid, int id)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_UpdatePhotoOrder", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Profile_Photo_ID", photoID);
                cmd.Parameters.AddWithValue("@ProfileID", profileid);
                cmd.Parameters.AddWithValue("@Image_OrderNo", imgorderno);
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(cmd);
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
                ConnectionManager.Instance.ReleaseSQLConnection(sqlcon);
            }
        }

        //Balaji 22-06-2012
        /// <summary>
        /// Getting Max Image OrderNo
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>integer</returns>
        public static int GetMaxImageOrderNo(int profileID)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("GetMaxImageOrderNumber", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(cmd);
                sqlAdptr.Fill(vtable);
                if (vtable != null)
                {
                    if (vtable.Rows[0][0].ToString() == string.Empty)
                    {
                        returnval = 1;
                    }
                    else
                    {
                        returnval = Convert.ToInt32(vtable.Rows[0][0]);
                    }
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

        /// <summary>
        /// Getting Photo details By PhotoID
        /// </summary>
        /// <param name="photoID">photoID</param>
        /// <returns>data table</returns>
        public static DataTable GetPhotodetailsByPhotoID(int photoID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Getphotodetailsbyphotoid", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_Photo_ID", photoID);
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
        /// Updating Photo Primary flag by PhotoID
        /// </summary>
        /// <param name="photoID">photoID</param>
        /// <param name="primaryflag">primaryflag</param>
        /// <param name="profileid">profileid</param>
        /// <param name="id">id</param>
        /// <returns>integer</returns>
        public static int UpdatePhotoPrimaryflagbyPhotoID(int photoID, bool primaryflag, int profileid, int id)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Updatephotoprimaryflag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileid);
                sqlCmd.Parameters.AddWithValue("@Profile_Photo_ID", photoID);
                sqlCmd.Parameters.AddWithValue("@Photo_Prime_Flag", primaryflag);
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
        /// <summary>
        /// Updating Business Type
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="businessType">businessType</param>
        /// <param name="id">id</param>
        /// <returns>integer</returns>
        public static int UpdateBusinessType(int profileID, string businessType, int id)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateBusinessType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@BusinessType", businessType);
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
        /// <summary>
        /// Getting Business Types
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetBusinessTypes()
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBusinessdetails", sqlCon);
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

        //----------Moving Contacts from One Group to Another
        /// <summary>
        /// for Moving User Contacts From One Group to AnotherGroup
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="parentGroupID">parentGroupID</param>
        /// <param name="movingGroupID">movingGroupID</param>
        /// <param name="contactID">contactID</param>
        /// <param name="id">id</param>
        public static void MoveUserContactsFromOneGrouptoAnotherGroup(int userID, string parentGroupID, string movingGroupID, int contactID, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_MoveUserContactFromOneGrouptoAnother", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ParentGroupID", parentGroupID);
                sqlCmd.Parameters.AddWithValue("@MovingGroupID", movingGroupID);
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);
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
        /// <summary>
        /// Searching User Contacts On UserID and Email
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="emailAddress">emailAddress</param>
        /// <param name="searchGroup">searchGroup</param>
        /// <param name="checkFlag">checkFlag</param>
        /// <param name="isPrivateModule">isPrivateModule</param>
        /// <returns>data table</returns>
        public static DataTable SearchUserContactsOnUserIDandEmail(int userID, string emailAddress, string searchGroup, int checkFlag, bool isPrivateModule)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetUserSearchContacts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@SearchEmail", emailAddress);
                sqlCmd.Parameters.AddWithValue("@SearchGroup", searchGroup);
                sqlCmd.Parameters.AddWithValue("@CheckFlag", checkFlag);
                sqlCmd.Parameters.AddWithValue("@IsPrivateModule", isPrivateModule);
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
        /// Updating Year odEstablishment Flag
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="establishmentFlag">establishmentFlag</param>
        /// <param name="noofemp">noofemp</param>
        /// <param name="eventcalendarflag">eventcalendarflag</param>
        /// <param name="appointmentCaledar">appointmentCaledar</param>
        /// <param name="couponPage">couponPage</param>
        /// <param name="webAddress1">webAddress1</param>
        /// <param name="webAddress2">webAddress2</param>
        /// <param name="facebook">facebook</param>
        /// <param name="fanpage">fanpage</param>
        /// <param name="linkedin">linkedin</param>
        /// <param name="twitter">twitter</param>
        /// <param name="media">media</param>
        /// <param name="myNetwork">myNetwork</param>
        /// <param name="updates">updates</param>
        /// <param name="mobilePhone">mobilePhone</param>
        /// <param name="id">id</param>
        public static void UpdateYearodEstablishmentFlag(int profileID, bool establishmentFlag, bool noofemp, bool eventcalendarflag, bool appointmentCaledar, bool couponPage, bool webAddress1, bool webAddress2, bool facebook, bool fanpage, bool linkedin, bool twitter, bool media, bool myNetwork, bool updates, bool mobilePhone, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateYearofEstablimentflag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);
                sqlCmd.Parameters.AddWithValue("@Year_Established", establishmentFlag);
                sqlCmd.Parameters.AddWithValue("@Noofemp", noofemp);
                sqlCmd.Parameters.AddWithValue("@Eventcalendarflag", eventcalendarflag);
                sqlCmd.Parameters.AddWithValue("@AppointmentCaledar", appointmentCaledar);
                sqlCmd.Parameters.AddWithValue("@CouponPage", couponPage);
                sqlCmd.Parameters.AddWithValue("@WebAddress1", webAddress1);
                sqlCmd.Parameters.AddWithValue("@WebAddress2", webAddress2);
                sqlCmd.Parameters.AddWithValue("@Facebook", facebook);
                sqlCmd.Parameters.AddWithValue("@Fanpage", fanpage);
                sqlCmd.Parameters.AddWithValue("@Linkedin", linkedin);
                sqlCmd.Parameters.AddWithValue("@Twitter", twitter);
                sqlCmd.Parameters.AddWithValue("@Media", media);
                sqlCmd.Parameters.AddWithValue("@MyNetwork", myNetwork);
                sqlCmd.Parameters.AddWithValue("@Updates", updates);
                sqlCmd.Parameters.AddWithValue("@MobilePhone", mobilePhone);
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
        /// <summary>
        /// Getting Profile ID by RenewalID
        /// </summary>
        /// <param name="renewID">renewID</param>
        /// <returns></returns>
        public static DataTable GetProfileIDbyRenewalID(int renewID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetProfileIDby_Renualid", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@RenewID", renewID);
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

        // BG Music
        /// <summary>
        /// Inserting BGMusic File Details
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="bgMusicNum">bgMusicNum</param>
        /// <param name="profileBGMusicPath">profileBGMusicPath</param>
        /// <param name="bgMusicPrimeFlag"></param>
        /// <param name="statusFlag">statusFlag</param>
        /// <param name="playFile">playFile</param>
        /// <param name="id">id</param>
        /// <returns>integer</returns>
        public static int InsertBGMusicFileDetails(int profileID, int userID, int bgMusicNum, string profileBGMusicPath, bool bgMusicPrimeFlag, bool statusFlag, string playFile, int id)
        {
            int returnval = 0;
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertBGMusicFileDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);
                sqlCmd.Parameters.AddWithValue("@User_ID", userID);
                sqlCmd.Parameters.AddWithValue("@BGMusic_Num", bgMusicNum);
                sqlCmd.Parameters.AddWithValue("@Profile_BGMusic_path", profileBGMusicPath);
                sqlCmd.Parameters.AddWithValue("@BGMusic_Prime_Flag", bgMusicPrimeFlag);
                sqlCmd.Parameters.AddWithValue("@Status_Flag", statusFlag);
                sqlCmd.Parameters.AddWithValue("@PlayFile", playFile);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
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
        /// Getting background music file details
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetBGMusicFileDetails(int profileID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllBGMusicFileDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);
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
        /// Getting activate background music
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetActiveBGMusic(int profileID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetActiveBGMusic", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);

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
        /// for getting paly sequence active background music
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>dat atable</returns>
        public static DataTable GetPlaySequenceActiveBGMusic(int profileID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPlaySequenceActiveBGMusic", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);

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
        /// deleting user background music files
        /// </summary>
        /// <param name="bgMusicFileID">bgMusicFileID</param>
        /// <returns>integer</returns>
        public static int Delete_UserBGMusicFileDetails(int bgMusicFileID)
        {
            int returnval = 1;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Delete_UserBGMusicFileDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BGMusicFileID", bgMusicFileID);
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
        /// updating default background music by music id
        /// </summary>
        /// <param name="musicID">musicID</param>
        /// <param name="defaultFlag">defaultFlag</param>
        /// <param name="id">id</param>
        /// <returns>Integer</returns>
        public static int UpdateDefaultBGMusicByMusicID(int musicID, bool defaultFlag, int id)
        {
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateDefaultBGMusicByMusicID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BGMusicFileID", musicID);
                sqlCmd.Parameters.AddWithValue("@BGMusic_Prime_Flag", defaultFlag);
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
        /// Background music play list sequence
        /// </summary>
        /// <param name="bgMusicFileID">bgMusicFileID</param>
        /// <param name="bgMusicSeqNo">bgMusicSeqNo</param>
        /// <param name="id">id</param>
        /// <returns>Integer</returns>
        public static int BGMusicPlayListSequence(int bgMusicFileID, int bgMusicSeqNo, int id)
        {
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateBGMusicPlayListSequenceByMusicID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BGMusicFileID", bgMusicFileID);
                sqlCmd.Parameters.AddWithValue("@BGMusic_Num", bgMusicSeqNo);
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
        /// Profile update back ground music default play
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="defaultBGMusicPlay">defaultBGMusicPlay</param>
        /// <param name="id">id</param>
        /// <returns>integer</returns>
        public static int ProfileUpdateBGMusicDefaultPlay(int profileID, bool defaultBGMusicPlay, int id)
        {
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ProfileUpdateBGMusicDefaultPlay", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@DefaultBGMusicPlay", defaultBGMusicPlay);
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
        /// getting updated bg music for profile
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>datatable</returns>
        public static DataTable GetProfileUpdateBGMusicDefaultPlay(int profileID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileBGMusicDefaultPlay", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);
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
        /// Getting BG Music Path MusicID
        /// </summary>
        /// <param name="musicID">musicID</param>
        /// <returns>datatable</returns>
        public static DataTable GetBGMusicPathMusicID(int musicID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBGMusicPathMusicID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MusicID", musicID);
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
        // End BG MUsic
        //Start issue 766
        /// <summary>
        /// update flag for number of employees
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="noofEmployees">noofEmployees</param>
        public static void UpdateNoofEmployeesFlag(int profileID, bool noofEmployees)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateNoofEmployeesflag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);
                sqlCmd.Parameters.AddWithValue("@NoofEmployees", noofEmployees);
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
        //End Issue 766
        /// <summary>
        /// updating year odd establishment flag
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="establishmentflag">establishmentflag</param>
        public static void UpdateYearodEstablishmentFlag(int profileID, bool establishmentflag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateYearodEstablishmentFlag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileID);
                sqlCmd.Parameters.AddWithValue("@establishmentflag", establishmentflag);
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
        // Start: Get the duplicate contact email IDs by User_ID
        /// <summary>
        /// getting duplicate contact email id
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="checkvalue">checkvalue</param>
        /// <returns>data table</returns>
        public static DataTable GetDuplicateContactEmailIDsbyUserID(int userID, int checkvalue)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetDuplicateemailIDsbyUser_ID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@User_ID", userID);
                sqlCmd.Parameters.AddWithValue("@CheckFlag", checkvalue);
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
        //End: Get the duplicate contact email IDs by User_ID

        //Start: GNN Registration
        /// <summary>
        /// for updating network id
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="networkid">networkid</param>
        public static void UpdateNetworkIDbyUserID(int userID, int networkid)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateUsers_NetworkID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@User_ID", userID);
                sqlCmd.Parameters.AddWithValue("@NetworkID", networkid);
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
        // End: GNN Registration

        // ------------------------- NetWork Image ----------------------------- //
        /// <summary>
        /// for retrievig network details
        /// </summary>
        /// <param name="nid">nid</param>
        /// <returns>data table</returns>
        public static DataTable GetNetWorkDetailsByID(int nid)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetNetWorkDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@NID", nid);
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
        /// for updating event calender flag
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="eventcalendarflag">eventcalendarflag</param>
        public static void UpdateEventcalendarFlag(int profileID, bool eventcalendarflag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Updateeventcalendarflag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@Eventcalendarflag", eventcalendarflag);
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
        /// for updating audio flag
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="audioflag">audioflag</param>
        public static void UpdateAudioFlag(int profileID, bool audioflag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Updateaudiolag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@Audioflag", audioflag);
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









        //public static DataTable GetProfileLogoInfoByProfileID(int ProfileID)
        //{
        //    DataTable vtable = new DataTable("LogoInfo");
        //    SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

        //    try
        //    {
        //        SqlCommand sqlCmd = new SqlCommand("usp_GetProfileLogoInfoByProfileID", sqlCon);
        //        sqlCmd.CommandType = CommandType.StoredProcedure;
        //        sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
        //        SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
        //        sqlAdptr.Fill(vtable);

        //        return vtable;
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





        //public static DataTable GetTOP1ProfileAudioInfoByProfileID(int ProfileID)
        //{
        //    DataTable vtable = new DataTable("AudioInfo");
        //    SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

        //    try
        //    {
        //        SqlCommand sqlCmd = new SqlCommand("usp_GetTOP1ProfileAudioInfoByProfileID", sqlCon);
        //        sqlCmd.CommandType = CommandType.StoredProcedure;
        //        sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
        //        SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
        //        sqlAdptr.Fill(vtable);

        //        return vtable;
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
        /// for retrievg top 10 profile information based on profile id
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetTop1ProfileEventsInfoByProfileID(int profileID)
        {
            DataTable vtable = new DataTable("EventsInfo");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetTOP1ProfileEventsInfoByProfileID", sqlCon);
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
        /// for retrieving toop 10 business update info
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetTop1BusinessUpdatesInfoByProfileID(int profileID)
        {
            DataTable vtable = new DataTable("BusinessUpdates");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetTOP1ProfileBusinessUpdatesByProfileID", sqlCon);
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

        //Active Events Count
        /// <summary>
        /// for getting active events count
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <returns>int</returns>
        public static int GetActiveEventsCount(int profileid)
        {
            DataTable vtable = new DataTable("ActiveEvents");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetActiveEventsCountByProfileId", sqlCon);
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
        // *** Start Get Promocode Details *** //
        /// <summary>
        /// for retreving promo code details
        /// </summary>
        /// <param name="promoCode">promoCode</param>
        /// <param name="pricePlan">pricePlan</param>
        /// <returns>data table</returns>
        public static DataTable GetProMoCodeDetails(string promoCode, string pricePlan)
        {
            DataTable vtable = new DataTable("PromoCode");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProMoCodeDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PromoCode", promoCode);
                sqlCmd.Parameters.AddWithValue("@PricePlan", pricePlan);
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
        // *** End Get Promocode Details *** //

        // *** Issue 991 *** //
        /// <summary>
        /// for upsating about us details
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="aboutusText">aboutusText</param>
        /// <param name="id">id</param>
        /// <param name="pEditHtml">pEditHtml</param>
        public static void UpdateProfileAboutUsDetails(int profileID, string aboutusText, int id, string pEditHtml)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateProfileAboutUsDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@AboutUsText", aboutusText);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.Parameters.AddWithValue("@EditHTML", pEditHtml);
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
        /// for updating business profile details
        /// </summary>
        /// <param name="buzname">business name</param>
        /// <param name="description">description</param>
        /// <param name="contactname">contactname</param>
        /// <param name="bdays">bdays</param>
        /// <param name="bhours">bhours</param>
        /// <param name="address1">address1</param>
        /// <param name="address2">address2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone1">phone1</param>
        /// <param name="extection">extection</param>
        /// <param name="fax">fax</param>
        /// <param name="userid">userid</param>
        /// <param name="profileid">profileid</param>
        /// <param name="mobileNumber">mobileNumber</param>
        /// <param name="alternatePhone">alternatePhone</param>
        /// <param name="platitude1">platitude1</param>
        /// <param name="plongitude1">plongitude1</param>
        /// <param name="id">id</param>
        /// <param name="pDescriptionEditHtml">pDescriptionEditHtml</param>
        /// <param name="timezoneid">timezoneid</param>
        /// <returns>Integer</returns>
        public static int UpdateBusinessProfileDetails(string buzname, string description, string contactname, string bdays, string bhours,
            string address1, string address2, string city, string state, string country, string zipcode, string phone1, string extection, string fax, int userid,
            int profileid, string mobileNumber, string alternatePhone, double platitude1, double plongitude1, int id, string pDescriptionEditHtml, int timezoneid)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateBusinessProfileForezSmartSitename", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profilename", buzname);
                sqlCmd.Parameters.AddWithValue("@description", description);
                sqlCmd.Parameters.AddWithValue("@contactname", contactname);
                sqlCmd.Parameters.AddWithValue("@Bdays", bdays);
                sqlCmd.Parameters.AddWithValue("@Bhours", bhours);
                sqlCmd.Parameters.AddWithValue("@address1", address1);
                sqlCmd.Parameters.AddWithValue("@address2", address2);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@State", state);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipcode);
                sqlCmd.Parameters.AddWithValue("@phone1", phone1);
                sqlCmd.Parameters.AddWithValue("@extenction", extection);
                sqlCmd.Parameters.AddWithValue("@fax", fax);
                sqlCmd.Parameters.AddWithValue("@UserID", userid);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileid);
                sqlCmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                sqlCmd.Parameters.AddWithValue("@AlternatePhone", alternatePhone);
                sqlCmd.Parameters.AddWithValue("@latitude1", platitude1);
                sqlCmd.Parameters.AddWithValue("@longitude1", plongitude1);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.Parameters.AddWithValue("@Description_Edit_HTML", pDescriptionEditHtml);
                sqlCmd.Parameters.AddWithValue("@TimeZoneID", timezoneid);

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
        // *** Issue 991 *** //

        // issue 752 start
        // Get Contact Group ID by Group name
        /// <summary>
        /// for checking group existance by group id
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="groupName">groupName</param>
        /// <returns>Integer</returns>
        public static int CheckGroupExistenceByGroupName(int userID, string groupName)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int groupID = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "Usp_CheckGroupExistenceByGroupName";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Userid", userID);
                sqlCmd.Parameters.AddWithValue("@Grpnm", groupName);
                groupID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return groupID;
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

        // End
        // issue 752 end

        /// <summary>
        /// for updating photo primary flsg
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="primaryflag">primaryflag</param>
        /// <param name="id">id</param>
        public static void UpdatePhotoPrimaryflagByProfileID(int profileid, bool primaryflag, int id)
        {
            DataTable vtable = new DataTable("business");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DisablePrimaryImage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileid);
                sqlCmd.Parameters.AddWithValue("@Photo_Prime_Flag", primaryflag);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);


            }
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
        /// for retrieving duplicate contacts
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="checkvalue">checkvalue</param>
        /// <param name="pgNmb">pgNmb</param>
        /// <param name="isPrivateModule">isPrivateModule</param>
        /// <returns></returns>
        public static DataTable GetDuplicateContactsByUserID(int userID, int checkvalue, int pgNmb, bool isPrivateModule)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetDuplicateContactsByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@User_ID", userID);
                sqlCmd.Parameters.AddWithValue("@IsPrivateModule", isPrivateModule);
                sqlCmd.Parameters.AddWithValue("@CheckFlag", checkvalue);
                sqlCmd.Parameters.AddWithValue("@pgnmb", pgNmb);
                sqlCmd.Parameters.AddWithValue("@pagesize", ConfigurationManager.AppSettings["ContactsPageSize"]);
                sqlCmd.Parameters.AddWithValue("@pg", SqlDbType.Int);
                sqlCmd.Parameters["@pg"].Direction = ParameterDirection.Output;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                HttpContext.Current.Session["duppage"] = sqlCmd.Parameters["@pg"].Value;
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
        /// for retrieving profile reviews by id
        /// </summary>
        /// <param name="testimonialID">testimonialID</param>
        /// <returns>data table</returns>
        public static DataTable GetProfileReviewsByID(int testimonialID)
        {
            DataTable vtable = new DataTable("Testimonial");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetProfileReviewsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@TestimonialID", testimonialID);
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
        /// get reviews for user
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>data table</returns>
        public static DataTable GetRiveiwsForUser(int userID)
        {
            DataTable vtable = new DataTable("Testimonial");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetProfileReviewsByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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
        /// <summary>
        /// retrieving profile reviews for categoery
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="rating">rating</param>
        /// <param name="userID">userID</param>
        /// <returns>data table</returns>
        public static DataTable GetProfileReviewsForCategory(string category, int rating, int userID)
        {
            DataTable vtable = new DataTable("Testimonial");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetProfileReviewsForCategory", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Category", category);
                sqlCmd.Parameters.AddWithValue("@Rating", rating);
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
        /// <summary>
        /// changing to test account
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="flag">flag</param>
        public static void ChangeToTestAccount(int userID, int flag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_ChangeToTestAccount", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("User_Id", userID);
                cmd.Parameters.AddWithValue("flag", flag);
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
        /// <summary>
        /// retrieving created user
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>string</returns>
        public static string GetCreatedUser(int userID)
        {
            SqlConnection sqlcon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlcmd = new SqlCommand("usp_GetCreatedUser", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("User_Id", userID);
                string createdUser = sqlcmd.ExecuteScalar().ToString();
                return createdUser;
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
        /// Inserting Google Place Response Details
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="businessName">businessName</param>
        /// <param name="address">address</param>
        /// <param name="city">address</param>
        /// <param name="types">types</param>
        /// <param name="referenceKey">referenceKey</param>
        /// <param name="referenceID">referenceID</param>
        public static void InsertGooglePlaceResponseDetails(int userID, string businessName, string address, string city, string types, string referenceKey, string referenceID)
        {
            SqlConnection sqlcn = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertGooglePlaceResponseDetails", sqlcn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("UserID", userID);
                sqlCmd.Parameters.AddWithValue("BusinessName", businessName);
                sqlCmd.Parameters.AddWithValue("Address", address);
                sqlCmd.Parameters.AddWithValue("City", city);
                sqlCmd.Parameters.AddWithValue("Types", types);
                sqlCmd.Parameters.AddWithValue("ReferenceKey", referenceKey);
                sqlCmd.Parameters.AddWithValue("ReferenceID", referenceID);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlcn);
            }
        }
        /// <summary>
        /// Getting google places types
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetGooglePlacesTypes()
        {
            DataTable vtable = new DataTable("Types");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetGooglePlacesTypes", sqlCon);
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

        // for Temp Mailing List Adding in Public Site
        /// <summary>
        /// for adding tempoarary mailing list
        /// </summary>
        /// <param name="pUserID">user id</param>
        /// <param name="pMailingEmailID">mailing email id</param>
        public static void AddTempMailingList(int pUserID, string pMailingEmailID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Add_Temp_MailingList", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@Mailing_EmailID", pMailingEmailID);
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
        /// <summary>
        /// for retrieving temp mailing list details
        /// </summary>
        /// <param name="pUserID">userid</param>
        /// <returns>datatable</returns>
        public static DataTable GetTempMailingListDetails(int pUserID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetTempMailingListDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUserID"></param>
        public static void DeleteempMailingListDetails(int pUserID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteTempMailingListDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(msgs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        // *** Update Social Network links *** //
        public static void UpdateSocialNetworks(int profileid, string facebooklink, string fbfanpagelink, string linkdinlink, string twitterlink, string youtubeLink, string instagramLink, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_updateSocialNetworks", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileid);
                sqlCmd.Parameters.AddWithValue("@Facebooklink", facebooklink);
                sqlCmd.Parameters.AddWithValue("@fbfanpagelink", fbfanpagelink);
                sqlCmd.Parameters.AddWithValue("@Linkdinlink", linkdinlink);
                sqlCmd.Parameters.AddWithValue("@Twitterlink", twitterlink);
                sqlCmd.Parameters.AddWithValue("@YoutubeLink", youtubeLink);
                sqlCmd.Parameters.AddWithValue("@InstagramLink", instagramLink);
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

        public static int CheckCredentials(string name, string email)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckCredentials", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@name", name.Trim());
                sqlCmd.Parameters.AddWithValue("@Email", email.Trim());
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

        public static void InsertReportsInquiry(string name, string email)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertReportsInquiry", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@name", name);
                sqlCmd.Parameters.AddWithValue("@Email", email);
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

        public static int GetReportInquiryNameAndGroupID(string email, string groupName, out string firstname)
        {
            int contactID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetReportInquiryNameAndGroupID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@groupname", groupName);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.Parameters.Add(new SqlParameter("@First_Name", SqlDbType.VarChar, 200)).Direction = ParameterDirection.Output;
                contactID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                firstname = sqlCmd.Parameters["@First_Name"].Value.ToString();
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

        public static DataSet GetPricingAndMultiToolLabels()
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPricingAndMultiToolLabels", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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



        public static void InsertUserSelectedTools(ToolsEntities tools)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertUserSelectedTools", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@User_ID", tools.UserID);
                sqlCmd.Parameters.AddWithValue("@IsWebsite", tools.IsWebsite);
                sqlCmd.Parameters.AddWithValue("@IsFlyers", tools.IsFlyers);
                sqlCmd.Parameters.AddWithValue("@IsUpdate", tools.IsUpdate);
                sqlCmd.Parameters.AddWithValue("@IsCoupon", tools.IsCoupon);
                sqlCmd.Parameters.AddWithValue("@IsEventCalendar", tools.IsEventCalendar);
                sqlCmd.Parameters.AddWithValue("@IsAutoSend", tools.IsAutoSend);
                sqlCmd.Parameters.AddWithValue("@IsAppointmentCalendar", tools.IsAppointmentCalendar);
                sqlCmd.Parameters.AddWithValue("@IsSocialMedia_Analytics", tools.IsSocialMediaAnalytics);
                sqlCmd.Parameters.AddWithValue("@IsCustomDomain", tools.IsCustomDomain);
                sqlCmd.Parameters.AddWithValue("@Total_Emails", tools.TotalEmails);
                sqlCmd.Parameters.AddWithValue("@Selected_EmailsCount", tools.SelectedEmailsCount);
                sqlCmd.Parameters.AddWithValue("@IsLiveChat", tools.IsLiveChat);
                sqlCmd.Parameters.AddWithValue("@IsPhoneSupport", tools.IsPhoneSupport);
                sqlCmd.Parameters.AddWithValue("@IsContactManager", tools.IsContactManager);
                sqlCmd.Parameters.AddWithValue("@Package_Number", tools.PackageNumber);
                sqlCmd.Parameters.AddWithValue("@IsAccountSetup", tools.IsAccountSetup);
                sqlCmd.Parameters.AddWithValue("@IsCampaignSetup", tools.IsCampaignSetup);
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


        public static void InsertTransactionDetails(string transactionQuery)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertTransactionDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@TransactionQuery", transactionQuery);
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

        public static DataTable GetSelectedToolsByUserID(int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSelectedToolsByUserID", sqlCon);
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

        public static DataTable GetUpdatedSelectedToolsDetails(int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUpdatedSelectedToolsDetails", sqlCon);
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


        public static void UpdateNewlySelectedTools(ToolsEntities tools)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateNewlySelectedTools", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@User_ID", tools.UserID);
                sqlCmd.Parameters.AddWithValue("@IsWebsite", tools.IsWebsite);
                sqlCmd.Parameters.AddWithValue("@IsFlyers", tools.IsFlyers);
                sqlCmd.Parameters.AddWithValue("@IsUpdate", tools.IsUpdate);
                sqlCmd.Parameters.AddWithValue("@IsCoupon", tools.IsCoupon);
                sqlCmd.Parameters.AddWithValue("@IsEventCalendar", tools.IsEventCalendar);
                sqlCmd.Parameters.AddWithValue("@IsAutoSend", tools.IsAutoSend);
                sqlCmd.Parameters.AddWithValue("@IsAppointmentCalendar", tools.IsAppointmentCalendar);
                sqlCmd.Parameters.AddWithValue("@IsSocialMedia_Analytics", tools.IsSocialMediaAnalytics);
                sqlCmd.Parameters.AddWithValue("@IsCustomDomain", tools.IsCustomDomain);
                sqlCmd.Parameters.AddWithValue("@Total_Emails", tools.TotalEmails);
                sqlCmd.Parameters.AddWithValue("@Selected_EmailsCount", tools.SelectedEmailsCount);
                sqlCmd.Parameters.AddWithValue("@Total_Price", tools.Amount);
                sqlCmd.Parameters.AddWithValue("@Discount", tools.Discount);
                sqlCmd.Parameters.AddWithValue("@IsLiveChat", tools.IsLiveChat);
                sqlCmd.Parameters.AddWithValue("@IsPhoneSupport", tools.IsPhoneSupport);
                sqlCmd.Parameters.AddWithValue("@IsContactManager", tools.IsContactManager);
                sqlCmd.Parameters.AddWithValue("@Package_Number", tools.PackageNumber);
                sqlCmd.Parameters.AddWithValue("@IsAccountSetup", tools.IsAccountSetup);
                sqlCmd.Parameters.AddWithValue("@IsCampaignSetup", tools.IsCampaignSetup);
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

        public class ToolsEntities
        {
            public int UserID { get; set; }
            public bool IsWebsite { get; set; }
            public bool IsFlyers { get; set; }
            public bool IsUpdate { get; set; }
            public bool IsCoupon { get; set; }
            public bool IsEventCalendar { get; set; }
            public bool IsAutoSend { get; set; }
            public bool IsAppointmentCalendar { get; set; }
            public bool IsSocialMediaAnalytics { get; set; }
            public bool IsMedia { get; set; }
            public bool IsCustomDomain { get; set; }
            public bool IsUpgrades { get; set; }
            public bool IsMessages { get; set; }
            public int TotalEmails { get; set; }
            public int SelectedEmailsCount { get; set; }
            public string Total { get; set; }
            public string Discount { get; set; }
            public string Amount { get; set; }
            public string TransactionQuery { get; set; }
            public bool IsReports { get; set; }
            public bool IsLiveChat { get; set; }
            public bool IsPhoneSupport { get; set; }
            public bool IsContactManager { get; set; }
            public int PackageNumber { get; set; }
            public bool IsAccountSetup { get; set; }
            public bool IsCampaignSetup { get; set; }

        }
        public class SubscriptionTypes
        {
            public int ProfileID { get; set; }
            public int UserID { get; set; }
            public int SuscriptionType { get; set; }
            public decimal SubscriptionPrice { get; set; }
            public decimal DiscountAmount { get; set; }
            public decimal BillableAmount { get; set; }
        }
        public class BillingInfo
        {
            public string FirtstName { get; set; }
            public string LastName { get; set; }
            public string BillingEmail { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string CityCapital { get; set; }
            public string UserState { get; set; }
            public string Zipcode { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public int SubOrderID { get; set; }
            public bool IsEdited { get; set; }
            public string PromoCode { get; set; }
            public string Total { get; set; }
            public string BillableAmount { get; set; }
            public string Discount { get; set; }
            public string Type { get; set; }
            public string Number { get; set; }
            public string NumberC { get; set; }
            public string Month { get; set; }
            public string Year { get; set; }
            public string Name { get; set; }
            public bool IsCard { get; set; }
            public string ProfileIDC { get; set; }
            public string SubscriptionIDC { get; set; }
            public string OrderID { get; set; }
            public string OrderDescription { get; set; }
            public int SubApps { get; set; }
            public bool IsRecurring { get; set; }
            public int SubscriptionType { get; set; }
            public int SubPeriod { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime RenewalDate { get; set; }
            public int? PurchageOrderNo { get; set; }
            public bool IsLiteVersion { get; set; }
            public bool IsLiteUpgrade { get; set; }
            public List<OrderDetails> OrderDetailsList { get; set; }
            public string PayPalPairID { get; set; }
            public string PaymentMode { get; set; }
            public int PackageID { get; set; }
            public bool IsLifeTimeRenewal { get; set; }
        }
        public class OrderDetails
        {

            public int SubscriptionID { get; set; }
            public int? Sub_SubscriptionID { get; set; }
            public decimal Total { get; set; }
            public decimal Discount { get; set; }
            public decimal Billable { get; set; }
            public string DiscountCode { get; set; }
            public int RequestType { get; set; }
            public decimal Renewal { get; set; }
            public int? SubscriptionPeriod { get; set; }
            public int? MemorySize { get; set; }
            public int? PromoCodeId { get; set; }
            public bool RenewalLifeIme { get; set; }
            public string PayerId { get; set; }
            public int OrderId { get; set; }
            public string AccessType { get; set; }
            public int Quantity { get; set; }
            public int? ParentOrderDetalsID { get; set; }
            public bool IsPackageItem { get; set; }
        }
        public class AlternateCards
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }

        public class SubAppsBilling
        {
            public int NumberofSubApps { get; set; }
            public int SubAppsAmount { get; set; }
        }
        public class SubscriptionPackages
        {
            public int ID { get; set; }
            public string Description { get; set; }
        }
        /* ******************* domain registration ********************** */

        public static void UpdateDomainFlag(int userID, bool flag, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateDomainFlag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@Flag", flag);
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

        public static void UpdateForwardDomainFlag(int userID, bool flag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlComd = new SqlCommand("usp_UpdateForwardDomainFlag", sqlCon);
                sqlComd.CommandType = CommandType.StoredProcedure;
                sqlComd.Parameters.AddWithValue("@UserID", userID);
                sqlComd.Parameters.AddWithValue("@Flag", flag);
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


        public static DataTable GetItemsIDs(int profileID, int flag)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlComd = new SqlCommand("Usp_GetItemsIDs", sqlCon);
                sqlComd.CommandType = CommandType.StoredProcedure;
                sqlComd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlComd.Parameters.AddWithValue("@flag", flag);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlComd);
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

        public static DataTable CheckPaidItems(int profileID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlComd = new SqlCommand("USp_CheckPaidItems", sqlCon);
                sqlComd.CommandType = CommandType.StoredProcedure;
                sqlComd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlComd);
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
        public static void AddIncreasedEmailsLevel(int selectedEmailsCount, int userID, decimal subcost, int subPeriod, int cost)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlComd = new SqlCommand("Usp_IncreaseEmailsLevel", sqlCon);
                sqlComd.CommandType = CommandType.StoredProcedure;
                sqlComd.Parameters.AddWithValue("@UserID", userID);
                sqlComd.Parameters.AddWithValue("@SelectedEmailsCount", selectedEmailsCount);
                sqlComd.Parameters.AddWithValue("@subcost", subcost);
                sqlComd.Parameters.AddWithValue("@SubPeriod", subPeriod);
                sqlComd.Parameters.AddWithValue("@Cost", cost);
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
        public static void UpdateJoinMyMailingListText(int profileID, string joinMyMailingListText, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlComd = new SqlCommand("Usp_UpdateJoinMyMailingListText", sqlCon);
                sqlComd.CommandType = CommandType.StoredProcedure;
                sqlComd.Parameters.AddWithValue("@profileID", profileID);
                sqlComd.Parameters.AddWithValue("@joinMyMailingListText", joinMyMailingListText);
                sqlComd.Parameters.AddWithValue("@ID", id);
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
        public static int ValidatePromocode(string promocodeName)
        {
            int flag = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlComd = new SqlCommand("usp_ValidatePromocode", sqlCon);
                sqlComd.CommandType = CommandType.StoredProcedure;
                sqlComd.Parameters.AddWithValue("@Promocode_Name", promocodeName);
                flag = Convert.ToInt32(sqlComd.ExecuteScalar());
                return flag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static void UpdateDashbaordVideoCheck(int userID, bool flag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlComd = new SqlCommand("usp_UpdateDashbaordVideoCheck", sqlCon);
                sqlComd.CommandType = CommandType.StoredProcedure;
                sqlComd.Parameters.AddWithValue("@UserID", userID);
                sqlComd.Parameters.AddWithValue("@Flag", flag);
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

        //Used to get the Databoard Setting Details...
        public static DataTable GetDashboardSettingsDtls(int profileID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlComd = new SqlCommand("usp_GetDashboardSettingsDtlsByProfileID", sqlCon);
                sqlComd.CommandType = CommandType.StoredProcedure;
                sqlComd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlComd);
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

        //Used to insert/update the Databoard Setting Details...
        public static void InsertDashboardSettingsDtlst(ToolsEntities tools, bool isMobileApp, bool isBulletins, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateDashboardSettingsDtls", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", tools.UserID);
                sqlCmd.Parameters.AddWithValue("@IsWebsite", tools.IsWebsite);
                sqlCmd.Parameters.AddWithValue("@IsFlyers", tools.IsFlyers);
                sqlCmd.Parameters.AddWithValue("@IsUpdate", tools.IsUpdate);
                sqlCmd.Parameters.AddWithValue("@IsCoupon", tools.IsCoupon);
                sqlCmd.Parameters.AddWithValue("@IsEventCalendar", tools.IsEventCalendar);
                sqlCmd.Parameters.AddWithValue("@IsAutoSend", tools.IsAutoSend);
                sqlCmd.Parameters.AddWithValue("@IsAppointments", tools.IsAppointmentCalendar);
                sqlCmd.Parameters.AddWithValue("@IsSocialMedia", tools.IsSocialMediaAnalytics);
                sqlCmd.Parameters.AddWithValue("@IsContacts", tools.IsCustomDomain);
                sqlCmd.Parameters.AddWithValue("@SettingsId", tools.TotalEmails);
                sqlCmd.Parameters.AddWithValue("@IsReports", tools.IsReports);
                sqlCmd.Parameters.AddWithValue("@IsMedia", tools.IsMedia);
                sqlCmd.Parameters.AddWithValue("@IsUpgrades", tools.IsUpgrades);
                sqlCmd.Parameters.AddWithValue("@IsMessages", tools.IsMessages);
                sqlCmd.Parameters.AddWithValue("@IsMobileApp", isMobileApp);
                sqlCmd.Parameters.AddWithValue("@IsBulletins", isBulletins);
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
        // *** Insert Profile Tabs *** //
        public static void Inser_Update_ProfileTabs(int pProfileID, int pTabNo, string pTabName, string pTabID, int pOrderNo, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_ProfileTabs", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@TabNo", pTabNo);
                sqlCmd.Parameters.AddWithValue("@TabName", pTabName);
                sqlCmd.Parameters.AddWithValue("@TabID", pTabID);
                sqlCmd.Parameters.AddWithValue("@OrderNo", pOrderNo);
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

        public static DataTable GetProfileTabsByProfileID(int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileTabsByProfileID", sqlCon);
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

        public static DataTable GetProfileMastertabs(string pPageName)
        {
            SqlConnection sqlcon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetMasterTabs", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageNo", pPageName);
                SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                adptr.Fill(dt);

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
        // *** Remove Primary Falg Or Home Page Image *** //
        public static void RemovePrimaryFlag(int profileID, int imgNum, int photoID, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_RemovePrimaryFlag", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@ImageNum", imgNum);
                sqlCmd.Parameters.AddWithValue("@PhotoID", photoID);
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
        public static DataTable GetUserSubscriptionsByType(int userID, int subscType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetUserSubscriptionsByType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@SubscType", subscType);
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);

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
        // *** Insert Ad Ons *** //
        public static int Insert_UserAddOns(int profileID, int userID, decimal subscAmount, decimal discount, decimal billableAmount, int subscType, int subperiod, int purchageOrderID, decimal totalAmt, decimal totalBillableAmt, int type, DateTime endDate)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Inser_UserAddOns", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@SubscAmount", subscAmount);
                sqlCmd.Parameters.AddWithValue("@Discount", discount);
                sqlCmd.Parameters.AddWithValue("@BillableAmount", billableAmount);
                sqlCmd.Parameters.AddWithValue("@SubscType", subscType);
                sqlCmd.Parameters.AddWithValue("@Subperiod", subperiod);
                sqlCmd.Parameters.AddWithValue("@PurchageOrderID", purchageOrderID);
                sqlCmd.Parameters.AddWithValue("@OrderTotal", totalAmt);
                sqlCmd.Parameters.AddWithValue("@OrderBillableAmt", totalBillableAmt);
                sqlCmd.Parameters.AddWithValue("@Type", type);
                sqlCmd.Parameters.AddWithValue("@EndDate", endDate);
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
        public static DataTable GetPackageMenuLinks(int packageNumber, bool isLiteVersion, string VerticalName)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetPackageMenuLinks", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PackageNumber", packageNumber);
                sqlCmd.Parameters.AddWithValue("@IsLiteVersion", isLiteVersion);
                sqlCmd.Parameters.AddWithValue("@Vertical_Name", VerticalName);
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);

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
        public static DataTable GetChildMenuLinks(int parentId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetChildMenuLinks", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ParentId", parentId);
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);

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
        // *** Delete User when click on Cancel in payment page if user register first time *** //
        public static void DeleteNonRegisteredUser(int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DeleteNonRegisteredUser", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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
        // *** Fix for IRH-72 31-01-2013 *** //
        // *** Fix for IRH-72 31-01-2013 *** //
        public static void DeclineUserAppointment(int schID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DeclineAppointment", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SchID", schID);
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
        // *** Fix for IRH-45 04-02-2013 *** //
        public static DataTable GetPurchageOrderDetails(int userID, int purchageOrderID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetPurchageOrderDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@PurchageOrderID", purchageOrderID);
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);

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
        public static DataTable GetSalesPersonCommission(int purchaseSpid)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetSalesPersonCommission", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SalesPersonID", purchaseSpid);
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);

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
        public static void AddSalesReport(int orderID, decimal orderTotal, decimal billableAmount, int salesPersonID, decimal commissionAmount, int userID, DateTime transactionDate, int percentage)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_AddSalesReport", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OrderID ", orderID);
                sqlCmd.Parameters.AddWithValue("@OrderTotal ", orderTotal);
                sqlCmd.Parameters.AddWithValue("@BillableAmount", billableAmount);
                sqlCmd.Parameters.AddWithValue("@SalesPersonID", salesPersonID);
                sqlCmd.Parameters.AddWithValue("@CommissionAmount ", commissionAmount);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@TransactionDate", transactionDate);
                sqlCmd.Parameters.AddWithValue("@Percentage", percentage);
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
        public static int AddFailedTransactions(int profileID, int userID, int package, int emails, bool isAccoutSetup, bool isCampaignSetup, decimal totalAmount, decimal billableAmount, decimal discount)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable vtable = new DataTable("TransFailed");
            int returnval = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_AddFailedTransactions", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@Package", package);
                sqlCmd.Parameters.AddWithValue("@Emails", emails);
                sqlCmd.Parameters.AddWithValue("@IsAccoutSetup", isAccoutSetup);
                sqlCmd.Parameters.AddWithValue("@IsCampaignSetup", isCampaignSetup);
                sqlCmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                sqlCmd.Parameters.AddWithValue("@BillableAmount", billableAmount);
                sqlCmd.Parameters.AddWithValue("@Discount", discount);
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
        public static void UpdateFailedTransaction(int orderID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateFailedTransaction", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OrderID", orderID);
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
        public static void UpdateBusinessUniqueCode(string uniqueCode, int userID, int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateBusinessUniqueCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UniqueCode", uniqueCode);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
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

        public static DataTable GetWebLinks(int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetWebLinks", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileID);
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);

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


        public static DataTable GetWebLinksById(int linkID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetWebLinksById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@LinkID", linkID);
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);

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

        public static int CreateWebLinks(int linkID, string title, string linkUrl, int userid, int id,
            int flag, int profileID, int pCatID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int returnID = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_CreateWebLinks", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@LinkID", linkID);
                sqlCmd.Parameters.AddWithValue("@LTitle", title);
                sqlCmd.Parameters.AddWithValue("@LinkUrl", linkUrl);
                sqlCmd.Parameters.AddWithValue("@USERID", userid);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.Parameters.AddWithValue("@Flag", flag);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileID);
                sqlCmd.Parameters.AddWithValue("@WebLinkCatID", pCatID);
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
        // *** App Manage Buttons 25-03-2013 *** //
        public static DataTable GetManageButtonsByProfileID(int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Mob_GetManageButtonsByProfileID", sqlCon);
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

        public static DataTable GetMastermanageButtons(string pPageName, string domainName)
        {
            SqlConnection sqlcon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Mob_GetMasterManageButtons", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageNo", pPageName);
                cmd.Parameters.AddWithValue("@DomainName", domainName);
                SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                adptr.Fill(dt);

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
        public static void Inser_Update_ManageButtons(int pProfileID, int pTabNo, string pTabName, string pTabID, int pOrderNo, int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Mob_Insert_Update_ManageButtons", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@TabNo", pTabNo);
                sqlCmd.Parameters.AddWithValue("@TabName", pTabName);
                sqlCmd.Parameters.AddWithValue("@TabID", pTabID);
                sqlCmd.Parameters.AddWithValue("@OrderNo", pOrderNo);
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


        public static DataTable GetSendNotifications(int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Mob_GetSendNotifications", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileID);
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);

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
        public static DataTable GetMobileNewsletterAlerts(bool flag, int userID, int? blockedType = null, int ArchiveType = 0)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetMobileNewsletterAlerts", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@flag", flag);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@BlockedType", blockedType);
                sqlCmd.Parameters.AddWithValue("@Archive", ArchiveType);
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

        public static DataTable GetMobilePublicCallsHistory(bool pIsAllItems, int pHistoryID, int pProfileID, bool? IsRead = false, bool? IsArchive = false)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllPublicCallsHistory", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@IsAllItem", pIsAllItems);
                sqlCmd.Parameters.AddWithValue("@HistoryID", pHistoryID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@IsRead", IsRead);

                sqlCmd.Parameters.AddWithValue("@IsArchive", IsArchive);
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

        public static DataTable GetMobilePrivateCallsHistory(bool pIsAllItems, int pHistoryID, int pProfileID, bool? IsRead = false, int ArchiveType = 0)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllPrivateCallsHistory", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@IsAllItem", pIsAllItems);
                sqlCmd.Parameters.AddWithValue("@HistoryID", pHistoryID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@IsRead", IsRead);
                sqlCmd.Parameters.AddWithValue("@IsArchive", ArchiveType);
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

        public static void DeletePubicCallHistory(int historyID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeletePublicCallHistory", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@historyID", historyID);
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

        public static DataTable SelectMobileNewsletters(int userID, int contactID, bool flag, int id, string Archive)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "usp_SelectMobileNewsletters";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);
                sqlCmd.Parameters.AddWithValue("@flag", flag);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.Parameters.AddWithValue("@Archive", Archive);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(msgs);

                return msgs;
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

        public static DataTable GetMobileTips(bool flag, int userID, int? blockedType = null, int ArchiveType = 0)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetMobileTips", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@flag", flag);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@BlockedType", blockedType);
                sqlCmd.Parameters.AddWithValue("@ArchiveType", ArchiveType);
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

        public static DataTable SelectMobileTips(int userID, int contactID, bool flag, int id)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "usp_SelectMobileTips";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);
                sqlCmd.Parameters.AddWithValue("@flag", flag);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(msgs);

                return msgs;
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
        public static DataTable GetDashboardFlow(int userID, int loggedUser)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_GetDashboardFlow";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@LoggedUser", loggedUser);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(msgs);
                return msgs;
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
        public static void UpdateDashboardFlow(int userID, int type, int loggedUser)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_UPDATEDashboardFlow", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@Type", type);
                sqlCmd.Parameters.AddWithValue("@LoggedUser", loggedUser);
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

        public static DataTable GetDetailInvoicebyProfileID(int profileID)
        {
            DataTable detailInv = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetInvoiceDetailsByProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(detailInv);

                return detailInv;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

        }

        public static DataTable GetUserDtlsByUserID(int userID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserDtlsByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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


        //----------------- Desktop Notification ---------------
        public static DataTable GetMobileAppAlertsForDesktop(string pSource, int pUserID, int pRowCount)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetMobileAlertsForDesktop", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Source", pSource);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@RowsCount", pRowCount);
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

        // *** Added for multiple items deleting in Messages ***//
        public static int DeleteMessages(int messageID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 1;
            try
            {

                SqlCommand sqlCmd = new SqlCommand("usp_Delete_Messages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MessageID", messageID);
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
        public static DataTable GetPieChartData(int profileID, DateTime startDate, DateTime endDate, out int totalDownloads)
        {
            DataTable msgs = new DataTable("piechart");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPieChartData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@StartDate", startDate);
                sqlCmd.Parameters.AddWithValue("@EndDate", endDate);
                sqlCmd.Parameters.Add(new SqlParameter("@TotalDownloads", SqlDbType.Int)).Direction = ParameterDirection.Output;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(msgs);
                totalDownloads = Convert.ToInt32(sqlCmd.Parameters["@TotalDownloads"].Value.ToString());
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
        //Pie Chart for App Open Reports
        public static DataTable GetPieChartDataForOpenReport(int profileID, DateTime startDate, DateTime endDate, out int totalDownloads)
        {
            DataTable msgs = new DataTable("piechart");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPieChartDataForOpenReport", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@StartDate", startDate);
                sqlCmd.Parameters.AddWithValue("@EndDate", endDate);
                sqlCmd.Parameters.Add(new SqlParameter("@TotalDownloads", SqlDbType.Int)).Direction = ParameterDirection.Output;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(msgs);
                totalDownloads = Convert.ToInt32(sqlCmd.Parameters["@TotalDownloads"].Value.ToString());
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
        //Column Chart for Banner Ad Click Count Report
        public static DataSet GetPieChartDataForBannerAdReport(int profileID, DateTime startDate, DateTime endDate, int BannerId, out int totalDownloads)
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPieChartDataForBannerAdReport", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@StartDate", startDate);
                sqlCmd.Parameters.AddWithValue("@EndDate", endDate);
                sqlCmd.Parameters.AddWithValue("@BannerID", BannerId);
                sqlCmd.Parameters.Add(new SqlParameter("@TotalDownloads", SqlDbType.Int)).Direction = ParameterDirection.Output;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(ds);
                totalDownloads = Convert.ToInt32(sqlCmd.Parameters["@TotalDownloads"].Value.ToString());
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

        public static DataTable GetParentProfiles(string searchString)
        {
            DataTable msgs = new DataTable("profiles");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetParentProfiles", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SearchString", searchString);
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
        public static int CheckParentProfileExists(string profileName)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int flag = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CheckParentProfile", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileName", profileName);
                flag = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return flag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static int BlockUnBlockMessageSenders(int messageID, bool blockFlag, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int flag = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_BlockUnBlockMessageSenders", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MessageID", messageID);
                sqlCmd.Parameters.AddWithValue("@BlockFlag", blockFlag);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                flag = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return flag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static int BlockUnBlockMessageSenders(string deviceID, int profileID, bool blockFlag, int userID, string pModuleType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int flag = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_BlockUnBlockMessageSendersnew", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DeviceID", deviceID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@BlockFlag", blockFlag);
                sqlCmd.Parameters.AddWithValue("@ModuleType", pModuleType);
                flag = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return flag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static int BlockUnBlockSmartConnectSenders(int messageID, bool blockFlag, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int flag = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_BlockUnBlockSmartConnectSenders", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MessageID", messageID);
                sqlCmd.Parameters.AddWithValue("@BlockFlag", blockFlag);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                flag = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return flag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataSet GetBlockedUsers(int profileID)
        {
            DataSet msgs = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBlockedSenders", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
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
        public static DataTable GetTimeZones(string country)
        {
            DataTable TimeZones = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetTimeZonesByCountryName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CountryName", country);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(TimeZones);

                return TimeZones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static string UpdateTimeZoneID(int profileIDfromAJAX, int timeZoneSelectedValue)
        {
            string timezoneName = "";
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateTimeZoneID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", profileIDfromAJAX);
                sqlCmd.Parameters.AddWithValue("@TimeZone_ID", timeZoneSelectedValue);
                timezoneName = (string)sqlCmd.ExecuteScalar();
                return timezoneName;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetProfileSubcriptonsByDates(DateTime pStartDate, DateTime pEndDate)
        {
            DataTable dtProfileSubcriptions = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileSubcriptionsByDates", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@startdate", pStartDate);
                sqlCmd.Parameters.AddWithValue("@enddate", pEndDate);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtProfileSubcriptions);

                return dtProfileSubcriptions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetDefaultProfileTabNames(string DomainName)
        {
            DataTable dtDefaultProfileTabs = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetDefaultProfileTabs", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DomainName", DomainName);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtDefaultProfileTabs);

                return dtDefaultProfileTabs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetAlternateCards(int profileID)
        {
            DataTable dtAltCards = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAlternateCards", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtAltCards);

                return dtAltCards;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetExistedPreferredDetails(int preferredID)
        {
            DataTable dtAltCard = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetExistedPreferredDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PreferredID", preferredID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtAltCard);
                return dtAltCard;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static void Insert_CC_BillingDetails(string pCCNumber, int pExMonth, int pExYear, bool pIsDefaultCard, string pFirstName, string pLastName, string pAddress1,
            string pAddress2, string pCity, string pState, string pCountry, string pZipcode, long pPayementDetailsID, long pCustomerSubcriptionID, string pCardType,
           int pProfileID, int pSubOrderID, int pCVV)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_PaymentCard_Details", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CC_Number", pCCNumber);
                sqlCmd.Parameters.AddWithValue("@Expiration_Month", pExMonth);
                sqlCmd.Parameters.AddWithValue("@Expiration_Year", pExYear);
                sqlCmd.Parameters.AddWithValue("@Isdefault", pIsDefaultCard);
                sqlCmd.Parameters.AddWithValue("@Firtst_Name", pFirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", pLastName);
                sqlCmd.Parameters.AddWithValue("@Address1", pAddress1);
                sqlCmd.Parameters.AddWithValue("@Address2", pAddress2);
                sqlCmd.Parameters.AddWithValue("@City", pCity);
                sqlCmd.Parameters.AddWithValue("@State", pState);
                sqlCmd.Parameters.AddWithValue("@Country", pCountry);
                sqlCmd.Parameters.AddWithValue("@Zipcode", pZipcode);
                sqlCmd.Parameters.AddWithValue("@PaymentProfileID", pPayementDetailsID);
                sqlCmd.Parameters.AddWithValue("@CustomerSubscriptionID", pCustomerSubcriptionID);
                sqlCmd.Parameters.AddWithValue("@Card_Type", pCardType);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@SubOrderID", pSubOrderID);
                sqlCmd.Parameters.AddWithValue("@CC_CVV", pCVV);
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

        public static DataTable GetSubcription_PaymentCardDetails(int pID)
        {
            DataTable dtAltCard = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPaymentCardDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", pID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtAltCard);
                return dtAltCard;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static int Update_CC_BillingDetails(string firstName, string lastName, string addressOne, string addressTwo, string city, string state, string zipCode, int ProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateBillingInfo", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FirstName", firstName);
                sqlCmd.Parameters.AddWithValue("@LastName", lastName);
                sqlCmd.Parameters.AddWithValue("@Address1", addressOne);
                sqlCmd.Parameters.AddWithValue("@Address2", addressTwo);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@State", state);
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipCode);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
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


        public static int Insert_RequestCustomFormDetails(string pDescription, string pRemarks, string pFormType, int pProfileID, int pUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertRequestCustomForms", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Description", pDescription);
                sqlCmd.Parameters.AddWithValue("@Remarks", pRemarks);
                sqlCmd.Parameters.AddWithValue("@FormType", pFormType);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
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

        public static int InsertUserSubscriptions(int profileID, int userID, int subPeriod, decimal totalAmount, decimal discount, decimal billable, string address1, string address2, string city, string state, string zipCode, string country, string number, string firstname, string lastname, int month, int year, string type, string numberC, string discountCode, bool isRecurring)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertUserSubscription", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@Sub_Period", subPeriod);
                sqlCmd.Parameters.AddWithValue("@Total_Amount", totalAmount);
                sqlCmd.Parameters.AddWithValue("@Discount_Amount", discount);
                sqlCmd.Parameters.AddWithValue("@Billable_Amount", billable);
                sqlCmd.Parameters.AddWithValue("@Address1", address1);
                sqlCmd.Parameters.AddWithValue("@Address2", address2);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@State", state);
                sqlCmd.Parameters.AddWithValue("@Zipcode", zipCode);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                sqlCmd.Parameters.AddWithValue("@CC_Number", number);
                sqlCmd.Parameters.AddWithValue("@CC_FirstName", firstname);
                sqlCmd.Parameters.AddWithValue("@CC_LastName", lastname);
                sqlCmd.Parameters.AddWithValue("@cc_expire_Month", month);
                sqlCmd.Parameters.AddWithValue("@cc_expire_year", year);
                sqlCmd.Parameters.AddWithValue("@CC_CVV", numberC);
                sqlCmd.Parameters.AddWithValue("@Card_Type", type);
                sqlCmd.Parameters.AddWithValue("@DiscountCode", discountCode);
                sqlCmd.Parameters.AddWithValue("@IsRecurring", isRecurring);
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

        public static DataTable GetStoreItems(string pCategory, string pProductType)
        {
            DataTable dt = new DataTable("dtstore");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetStoreItems", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Category", pCategory);
                sqlCmd.Parameters.AddWithValue("@ProductType", pProductType);
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
        public static DataTable GetPackageTypes(string domainName)
        {
            DataTable dt = new DataTable("dtstore");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_getPackageTypes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
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

        public static int InsertTransaction(int profileID, int userID, int subOrderID, int subscrType, decimal discount,
            decimal billableAmt, decimal totalAmt, int cUserID, int subscrPeriod, DateTime expirationDate, string description,
            string discountCode, string cnumber, string cType, string cexpDate, string firstName, string lastName, string address1,
            string address2, string city, string state, string zipCode, int requestType, int subPeriod, long pPaymentProfileID, long pCustomerSubscriptionID, string purchageOrderNo, string billingPhone, string billingEmail, string salesCode)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int orderID = 0;
            try
            {
                salesCode = (salesCode.Trim() != "") ? salesCode : null;
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertStoreTransactionDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@SubOrderID", subOrderID);
                sqlCmd.Parameters.AddWithValue("@SubscriptionType", subscrType);
                sqlCmd.Parameters.AddWithValue("@Discount", discount);
                sqlCmd.Parameters.AddWithValue("@BillableAmt", billableAmt);
                sqlCmd.Parameters.AddWithValue("@TotalAmt", totalAmt);
                sqlCmd.Parameters.AddWithValue("@CUserID", cUserID);
                sqlCmd.Parameters.AddWithValue("@SubscrPeriod", subscrPeriod);
                sqlCmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                sqlCmd.Parameters.AddWithValue("@Description", description);
                sqlCmd.Parameters.AddWithValue("@DiscountCode", discountCode);
                sqlCmd.Parameters.AddWithValue("@CardNumber", cnumber);
                sqlCmd.Parameters.AddWithValue("@CardType", cType);
                sqlCmd.Parameters.AddWithValue("@CardExpiration", cexpDate);
                sqlCmd.Parameters.AddWithValue("@FirstName", firstName);
                sqlCmd.Parameters.AddWithValue("@LastName", lastName);
                sqlCmd.Parameters.AddWithValue("@Address1", address1);
                sqlCmd.Parameters.AddWithValue("@Address2", address2);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@State", state);
                sqlCmd.Parameters.AddWithValue("@ZipCode", zipCode);
                sqlCmd.Parameters.AddWithValue("@RequestType", requestType);
                sqlCmd.Parameters.AddWithValue("@SubPeriod", subPeriod);
                sqlCmd.Parameters.AddWithValue("@PaymentProfileID", pPaymentProfileID);
                sqlCmd.Parameters.AddWithValue("@CustomerSubscriptionID", pCustomerSubscriptionID);
                sqlCmd.Parameters.AddWithValue("@PurchageOrderNo", purchageOrderNo);
                sqlCmd.Parameters.AddWithValue("@BillingPhone", billingPhone);
                sqlCmd.Parameters.AddWithValue("@BillingEmail", billingEmail);
                sqlCmd.Parameters.AddWithValue("@SalesCode", salesCode);
                orderID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return orderID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }


        public static DataTable GetAffilatesInvitationDetailsbyPID(int pPID)
        {
            DataTable dt = new DataTable("dt");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAffilatesInvitationDetailsByPID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
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


        public static int InsertOrderDetails(int pProfileID, int pUserID, int pSubcriptionTypeID, int pSID, decimal pTotalAmount, decimal pDiscountAmount, decimal pBillableAmount,
            DateTime pCreatedDate, int pCreatedUser, DateTime pStartDate, DateTime pRenewalDate, int pRequestType, int? pSub_SID, int? reqSubApps,
            int pPeriod, string pPromocode, decimal pRenewalCost, bool isRenewLifeTime, int? promoCodeId, string salesCode, int pQuantity = 1, int? pPackageID = 102, int? pParentOrderDetailsID = null)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int orderID = 0;
            try
            {
                salesCode = (salesCode.Trim() != "") ? salesCode : null;
                SqlCommand sqlCmd = new SqlCommand("usp_InsertOrderDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@SubscriptionType_ID", pSubcriptionTypeID);
                sqlCmd.Parameters.AddWithValue("@Subscription_ID", pSID);
                sqlCmd.Parameters.AddWithValue("@Total_Amount", pTotalAmount);
                sqlCmd.Parameters.AddWithValue("@Discount_Amount", pDiscountAmount);
                sqlCmd.Parameters.AddWithValue("@Billable_Amount", pBillableAmount);
                sqlCmd.Parameters.AddWithValue("@Created_Date", pCreatedDate);
                sqlCmd.Parameters.AddWithValue("@Create_User", pCreatedUser);
                sqlCmd.Parameters.AddWithValue("@Start_Date", pStartDate);
                sqlCmd.Parameters.AddWithValue("@Renewal_Date", pRenewalDate);
                sqlCmd.Parameters.AddWithValue("@Request_Type", pRequestType);
                sqlCmd.Parameters.AddWithValue("@Sub_SID", pSub_SID);
                sqlCmd.Parameters.AddWithValue("@RequestedSubApps", reqSubApps);
                sqlCmd.Parameters.AddWithValue("@Subscription_Period", pPeriod);
                sqlCmd.Parameters.AddWithValue("@Discount_Code", pPromocode == null ? "" : pPromocode);
                sqlCmd.Parameters.AddWithValue("@Renewal_Cost", pRenewalCost);
                sqlCmd.Parameters.AddWithValue("@Renewal_LifeTime", isRenewLifeTime);
                sqlCmd.Parameters.AddWithValue("@PromoCodeId", promoCodeId);
                sqlCmd.Parameters.AddWithValue("@SalesCode", salesCode);
                sqlCmd.Parameters.AddWithValue("@Quantity", pQuantity);
                sqlCmd.Parameters.AddWithValue("@PackageID", pPackageID);
                sqlCmd.Parameters.AddWithValue("@ParentOrderDetailsID", pParentOrderDetailsID);
                orderID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return orderID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static void InsertSMSAddons(int profileID, int cUserID, int orderDetailsID, string smsType, int smsQuantity)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertSMSAddons", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@CUserID", cUserID);
                sqlCmd.Parameters.AddWithValue("@OrderDetailsID", orderDetailsID);
                sqlCmd.Parameters.AddWithValue("@SMSType", smsType);
                sqlCmd.Parameters.AddWithValue("@SMSQuantity", smsQuantity);
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

        public static void InsertOrderPayment(int orderID, decimal paymentAmount, decimal pendingAmount, string chequeNo, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertOrderPayment", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OrderID", orderID);
                sqlCmd.Parameters.AddWithValue("@PaymentAmount", paymentAmount);
                sqlCmd.Parameters.AddWithValue("@PendingAmount", pendingAmount);
                sqlCmd.Parameters.AddWithValue("@ChequeNo", chequeNo);
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
        public static DataTable GetSubscriptionByID(int subscrID)
        {
            DataTable dt = new DataTable("dtsubscription");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetSubscriptionByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SubscriptionID", subscrID);
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
        public static void UpdateUserBrandedApp(int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateBrandedApp", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
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
        public static DataTable GetOrderDetailsByOrderID(int OrderID)
        {
            DataTable detailInv = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetOrderDetailsByOrderID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OrderID", OrderID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(detailInv);

                return detailInv;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static void UpdateOrderDetails(int profileID, int userID, int orderID, int subPeriod)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateOrderDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@OrderID", orderID);
                sqlCmd.Parameters.AddWithValue("@SubPeriod", subPeriod);
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
        public static DataTable GetAllRFPCustomForm()
        {
            DataTable dt = new DataTable("dtCustomForms");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAll_RFPRequests", sqlCon);
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

        public static DataTable GetRFP_CustomDetailsByID(int pRFPID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetRFP_CustomDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@RFPID", pRFPID);
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
        public static int CheckUserNameandPasswordForCreateUser(string username)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int flag = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("CheckAdminUserNameandPassword", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                flag = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return flag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static void NewAdminUserInsertion(string firstName, string lastName, string userName, string pwd, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_NewAdminUserInsertion", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FirstName", firstName);
                sqlCmd.Parameters.AddWithValue("@LastName", lastName);
                sqlCmd.Parameters.AddWithValue("@UserName", userName);
                sqlCmd.Parameters.AddWithValue("@Password", pwd);
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

        public static DataTable GetBrandedAppProcessAllStatus()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtStatus = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBrandedAppProcessAllStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtStatus);

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

        public static void Insert_Update_AppProcessStatus(int pAppOrderID, int pUserID, int pProfileID, string pLogo, string pApp_Icon, string pApp_Description,
             string splashCotent, string appshortDesc, string pAppDisplayName, string pApp_Keywords, string pIOS_URL, string pAndroid_URL, string pWindows_URL, string pWebsite_URL,
            int pAppOrderStatusID, int? pAssignedCSID, string pAppStoreIcon, string pPrintableAppStoreIcon, string pBackgroundIcon, string pQRCode_StoreUrl)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_BrandedAppOrderStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AppOrderID", pAppOrderID);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@logo", pLogo);
                sqlCmd.Parameters.AddWithValue("@AppIcon", pApp_Icon);
                sqlCmd.Parameters.AddWithValue("@AppDescription", pApp_Description);
                sqlCmd.Parameters.AddWithValue("@SplashCotent", splashCotent);
                sqlCmd.Parameters.AddWithValue("@AppShortDescription", appshortDesc);
                sqlCmd.Parameters.AddWithValue("@AppKeywords", pApp_Keywords);
                sqlCmd.Parameters.AddWithValue("@IOS_URL", pIOS_URL);
                sqlCmd.Parameters.AddWithValue("@Android_URL", pAndroid_URL);
                sqlCmd.Parameters.AddWithValue("@Windows_URL", pWindows_URL);
                sqlCmd.Parameters.AddWithValue("@Website_URL", pWebsite_URL);
                sqlCmd.Parameters.AddWithValue("@AppOrderStatusID", pAppOrderStatusID);
                sqlCmd.Parameters.AddWithValue("@Assigned_CS", pAssignedCSID);
                sqlCmd.Parameters.AddWithValue("@AppStoreIcon", pAppStoreIcon);
                sqlCmd.Parameters.AddWithValue("@PrintableAppStoreIcon", pPrintableAppStoreIcon);
                sqlCmd.Parameters.AddWithValue("@AppDisplayName", pAppDisplayName);
                sqlCmd.Parameters.AddWithValue("@BackgroundIcon", pBackgroundIcon);
                sqlCmd.Parameters.AddWithValue("@QRCode_Store_Url", pQRCode_StoreUrl);
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
        public static void Insert_Update_CheckedAppProcessStatus(Boolean chkReplaceAppNameData, Boolean chkReplaceSlashData, Boolean chkReplaceShortDescData, Boolean chkReplaceDescData, Boolean chkReplaceKeyWordsData, Boolean chkLogo, Boolean chkAppIcon, Boolean chkBackIcon, Boolean chkReplaceAppUpdate, string AppDisplayName, string AppKeywords, string AppDescription, string SplashContent, string AppShortDescription, string AppUpdateNotes, string Logo, string App_Icon, string BackgroundIcon,
             int BrandedApp_OrderId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_CheckedBrandedAppOrderStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@chkReplaceAppNameData", chkReplaceAppNameData);
                sqlCmd.Parameters.AddWithValue("@chkReplaceSlashData", chkReplaceSlashData);
                sqlCmd.Parameters.AddWithValue("@chkReplaceShortDescData", chkReplaceShortDescData);
                sqlCmd.Parameters.AddWithValue("@chkReplaceDescData", chkReplaceDescData);
                sqlCmd.Parameters.AddWithValue("@chkReplaceKeyWordsData", chkReplaceKeyWordsData);
                sqlCmd.Parameters.AddWithValue("@chkLogo", chkLogo);
                sqlCmd.Parameters.AddWithValue("@chkAppIcon", chkAppIcon);
                sqlCmd.Parameters.AddWithValue("@chkBackIcon", chkBackIcon);
                sqlCmd.Parameters.AddWithValue("@AppDescription", AppDescription);
                sqlCmd.Parameters.AddWithValue("@SplashContent", SplashContent);
                sqlCmd.Parameters.AddWithValue("@AppShortDescription", AppShortDescription);
                sqlCmd.Parameters.AddWithValue("@AppKeywords", AppKeywords);
                sqlCmd.Parameters.AddWithValue("@AppDisplayName", AppDisplayName);
                sqlCmd.Parameters.AddWithValue("@Logo", Logo);
                sqlCmd.Parameters.AddWithValue("@App_Icon", App_Icon);
                sqlCmd.Parameters.AddWithValue("@BackgroundIcon", BackgroundIcon);
                sqlCmd.Parameters.AddWithValue("@BrandedApp_OrderId", BrandedApp_OrderId);
                sqlCmd.Parameters.AddWithValue("@chkReplaceAppUpdate", chkReplaceAppUpdate);
                sqlCmd.Parameters.AddWithValue("@AppUpdateNotes", AppUpdateNotes);
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

        public static void usp_Insert_Update_BrandedAppAdditionalStatus(int BrandedApp_OrderId, int StatusID, int BrandedApp_RequestID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {

                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_BrandedAppAdditionalStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BrandedApp_OrderId", BrandedApp_OrderId);
                sqlCmd.Parameters.AddWithValue("@StatusID", StatusID);
                sqlCmd.Parameters.AddWithValue("@BrandedApp_RequestID", BrandedApp_RequestID);
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
        public static DataTable GetManageBrandedAppOrderStatus(int pTabType, string pSearchText, string pVertical)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtManageAppStatus = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetManageBrandedAppProcessStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@TabType", pTabType);
                sqlCmd.Parameters.AddWithValue("@SearchText", pSearchText);
                sqlCmd.Parameters.AddWithValue("@Vertical", pVertical);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtManageAppStatus);

                return dtManageAppStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetBrandedAppOrderStatusDetails(int pAppOrderStatusID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtOrderStatus = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBrandedAppOrderStatusDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AppOrderStatusID", pAppOrderStatusID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtOrderStatus);

                return dtOrderStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static void ChangeBrandedAppOrderStatus(int pAppOrderID, int pStatusID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ChangeAppOrderStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AppStatusOrderID", pAppOrderID);
                sqlCmd.Parameters.AddWithValue("@StatusID", pStatusID);
                sqlCmd.Parameters.AddWithValue("@Assigned_CS", pStatusID);
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

        public static DataTable GetAppOrderStatusByStatusID(int pStatusID, int pTabType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtOrderStatus = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAppOrderStatusByStatusID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@StatuID", pStatusID);
                sqlCmd.Parameters.AddWithValue("@TabType", pTabType);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtOrderStatus);

                return dtOrderStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetStoreDetailsById(int UserId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtOrderStatus = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetStoreDetailsById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserId", UserId);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtOrderStatus);

                return dtOrderStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetWebLinksCategories(int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetWebLinksCategories", sqlCon);
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

        public static int Insert_Update_WeblinksCategory(int pWebLinkCatID, string pCatName, int pUserID, int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Insert_Update_Weblink_Categories", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@WeblinkCatID", pWebLinkCatID);
                sqlCmd.Parameters.AddWithValue("@CatName", pCatName);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
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

        public static DataTable GetManageWeblinksCategories(int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetManageWeblinksCategories", sqlCon);
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

        public static void DeleteWeblinkCategory(int pWeblinkCategoryID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteWeblinkCategory", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@WeblinkCatgoryID", pWeblinkCategoryID);
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

        public static DataTable GetWeblinkCategoryDetailsByID(int pWeblinkCategoryID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetWeblinksCategoryDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@WeblinkCatID", pWeblinkCategoryID);
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

        public static DataTable GetBrandedAppDeskNotes(int pBrandedAppOrderID)
        {
            DataTable dtdetails = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBrandedAppDeskNotesByAppID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EditBranedApp_ID", pBrandedAppOrderID);
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

        public static void InsertBrandedAppDeskNotes(int pBrandedAppID, string pNotes, string pNotes_by, string pAdminiUserName)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertBrandedAppDeskNotes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EditBranedApp_ID", pBrandedAppID);
                sqlCmd.Parameters.AddWithValue("@Notes", pNotes);
                sqlCmd.Parameters.AddWithValue("@Notes_By", pNotes_by);
                sqlCmd.Parameters.AddWithValue("@AdminUserName", pAdminiUserName);
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

        public static DataTable GetProfileDetails(string criteria, string criteriaType, string userType, bool isGenericApps, DateTime startDate, DateTime endDate)
        {
            DataTable msgs = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetMobileAppDownloadReports", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Vertical", criteria);
                sqlCmd.Parameters.AddWithValue("@CriteriaType", criteriaType);
                sqlCmd.Parameters.AddWithValue("@UserType", userType);
                sqlCmd.Parameters.AddWithValue("@isGenericApps", isGenericApps);
                sqlCmd.Parameters.AddWithValue("@startDate", startDate);
                sqlCmd.Parameters.AddWithValue("@endDate", endDate);
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

        public static DataTable SelectInquiryAlerts(int UserID, int ContactID)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "usp_Select_EmailContacts";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@ContactID", ContactID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(msgs);

                return msgs;
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
        public static int InsertUserCustomModules(int ProfileID, int UserID, int createdUser, int module, string appIcon,
            string tabName, bool isActive, DateTime createdDate, DateTime modifyDate, DateTime expiredDate, string pButtonType, string purchaseType, string manageUrl, bool isHasChilds)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertUserCustomModules", sqlCon);
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
        public static int CheckDefaultAddonForLite(int profileID, string buttonType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CheckDefaultAddonForLite", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@ButtonType", buttonType);
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
        public static DataTable DashboardIcons(int userID, bool isLitevVersion, string domain)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                if (!isLitevVersion)
                {
                    SqlCommand sqlCmd = new SqlCommand("usp_GetDashboardIcons", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@UserID", userID);
                    SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                    sqlAdptr.Fill(msgs);
                }
                else
                {
                    SqlCommand sqlCmd = new SqlCommand("usp_Lite_GetDashboardIcons", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@UserID", userID);
                    sqlCmd.Parameters.AddWithValue("@Domain", domain);
                    SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                    sqlAdptr.Fill(msgs);
                }


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

        public static void UpdateShortorLongLogo(int userID, bool isShortLogo)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ChangeLogoType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@IsShortLogo", isShortLogo);
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
        public static DataTable GetSendNotificationByID(int pushNotifyID)
        {
            DataTable msgs = new DataTable("Notification");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetPushNotificationByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PushNotifyID", pushNotifyID);
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

        public static void UpdateLaunchPlay(int userID, string playType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateLaunchPlay", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@PlayType", playType);
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

        public static DataTable GetTabDetailsByModule(string moduleType, int moduleID, int userID)
        {
            DataTable dtinv = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetTabDetailsByModule", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@ModuleType", moduleType);
                sqlCmd.Parameters.AddWithValue("@ManageID", moduleID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
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

        public static int UpdateWebLinksOrder(int LinkID, int orderNo, int id)
        {
            int cnt = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateWebLinksOrder", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@WebLinkID", LinkID);
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
        public static DataTable GetWebLinksByUserID(int UserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetWebLinksByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);

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
        public static DataTable GetCustomModulesByUserID(int UserID)     //UserPermissions-Suneel
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetCustomModulesByUserID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);

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
        public static void DeleteBrandedAppById(int brandedOrderId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteBrandedAppById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BrandedOrderId", brandedOrderId);
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
        public static DataTable GetAllParentDetails()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllParentUsers", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);

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

        public static DataTable GetAllApproveRejectCCUsers(int userID, int itemId, string itemType, int assocUser)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllApproveRejectCCUsers", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ItemID", itemId);
                sqlCmd.Parameters.AddWithValue("@ItemType", itemType);
                sqlCmd.Parameters.AddWithValue("@AssocUser", assocUser
                    );
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

        public static DataTable GetAllPublishersofItem(int userID, string itemType, int pCustomID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllPublishersofItem", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@ItemType", itemType);
                sqlCmd.Parameters.AddWithValue("@CustomID", pCustomID);
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

        public static DataTable GetAppStoresLinks(int pPID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtAppStoresLink = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAppStoreLinks", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtAppStoresLink);

                return dtAppStoresLink;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }


        public static DataTable GetUserContactGroupNamesForPrivateModule(int userID, string pGroupType, int pUserModuleID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetGroupNamesForPrivateModule", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@GroupType", pGroupType);
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

        public static DataTable GetAllUserContactsForPrivateModule(int userID, int checkFlag, string selectType, int pUserModuleID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetALLUser_ContactsForPrivateModule", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CheckFlag", checkFlag);
                sqlCmd.Parameters.AddWithValue("@CheckSelectALL", selectType);
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
        public static string CheckValidUserForWebnair(string emailAddress, int schId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckValidUserForWebnair", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailAddress", emailAddress);
                sqlCmd.Parameters.AddWithValue("@SystemScheduledId", schId);
                return Convert.ToString(sqlCmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static int InsertWebnairUser(int schId, string emailAddress, string firstName, string lastName, string phone)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertWebnairUser", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SystemScheduledId", schId);
                sqlCmd.Parameters.AddWithValue("@EmailAddress", emailAddress);
                sqlCmd.Parameters.AddWithValue("@FirstName", firstName);
                sqlCmd.Parameters.AddWithValue("@LastName", lastName);
                sqlCmd.Parameters.AddWithValue("@PhoneNumber", phone);
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
        public static DataTable GetWebnairDetails(int schId)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetWebnairDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SystemScheduledId", schId);
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
        public static void UpdateModifieddateforBGImages(int profileId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateModifieddateforBGImages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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
        public static void SaveProfileBGImage(int profileId, bool isActive, int modifiedUser)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_SaveProfileBGImage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@IsActive", isActive);
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
        #region  All Image Gallery Type Methods Nov (28/14)

        public static void InsertDefaultAlbums(int pPID, int pUserID)
        {
            SqlConnection sqlConn = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertDefaultAlbums", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            { ConnectionManager.Instance.ReleaseSQLConnection(sqlConn); }
        }


        public static int Insert_Update_AlbumDetails(int pAlbumID, int pPID, int pUserID, string pAlbumName, string pAlbumUniqueName, string pGalleryType)
        {
            SqlConnection sqlConn = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_AlbumDetails", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@AlbumName", pAlbumName);
                sqlCmd.Parameters.AddWithValue("@AlbumUniqueName", pAlbumUniqueName);
                sqlCmd.Parameters.AddWithValue("@GalleryType", pGalleryType);
                sqlCmd.Parameters.AddWithValue("@AlbumID", pAlbumID);
                return Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            { ConnectionManager.Instance.ReleaseSQLConnection(sqlConn); }
        }

        public static DataTable GetActiveAlbumsByGalleryType(int pPID, string pGalleryType)
        {
            DataTable dtActiveAlbums = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetActiveAlbumsByType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                sqlCmd.Parameters.AddWithValue("@GalleryType", pGalleryType);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtActiveAlbums);
                return dtActiveAlbums;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetAlbumDetailsByAlbumID(int pAlbumID)
        {
            DataTable dtAlbumDetails = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAlbumDetailsByAlbumID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AlbumID", pAlbumID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtAlbumDetails);
                return dtAlbumDetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static void DeleteAlbum(int pAlbumID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteAlbum", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AlbumID", pAlbumID);
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

        public static DataTable GetGalleryImagesByAlbumID(int pAlbumID)
        {
            DataTable dtGalleryImages = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GalleryImagesByAlbumID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AlbumID", pAlbumID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtGalleryImages);
                return dtGalleryImages;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }


        public static void InsertGalleryImages(string pImgName, string pImgUniqueName, string pImgCaption, int pAlbumID, int pOrderNo, int pUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertGalleryImages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ImgName", pImgName);
                sqlCmd.Parameters.AddWithValue("@ImgUniqueName", pImgUniqueName);
                sqlCmd.Parameters.AddWithValue("@ImgCaption", pImgCaption);
                sqlCmd.Parameters.AddWithValue("@AlbumID", pAlbumID);
                sqlCmd.Parameters.AddWithValue("@OrderNo", pOrderNo);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
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

        public static void DeleteGalleryImagesbyImgID(int pImgID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeletGalleryImagesByImgID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ImgID", pImgID);
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

        public static void Update_ImgOrderNo_ImgCaption(int pImgID, int pImgOrderNo, string pImgCaption, string pUpdateColumnName)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Update_ImgOrderNo_ImgCaption", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ImgID", pImgID);
                sqlCmd.Parameters.AddWithValue("@OrderNo", pImgOrderNo);
                sqlCmd.Parameters.AddWithValue("@ImgCaption", pImgCaption);
                sqlCmd.Parameters.AddWithValue("@Type", pUpdateColumnName);
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

        public static int CheckingExistedImgOrderNo(int pImgID, int pImgOrderNo, int pAlbumID, string pModeType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CheckingExistedImgOrderNo", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ImgID", pImgID);
                sqlCmd.Parameters.AddWithValue("@OrderNo", pImgOrderNo);
                sqlCmd.Parameters.AddWithValue("@AlbumID", pAlbumID);
                sqlCmd.Parameters.AddWithValue("@ModeType", pModeType);
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

        public static DataTable GetRootAlbumDetailsByGallerType(int pPID, string pGalleryType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtRootAlbumDetails = new DataTable();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAlbumIDbyGalleryType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@GalleryType", pGalleryType);
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtRootAlbumDetails);
                return dtRootAlbumDetails;
            }
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


        #region Canned Messages

        public static DataTable GetAllCannedMessages(int pPID)
        {
            DataTable vtable = new DataTable("stats");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllCannedMessages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
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

        public static int InsertCannedMessage(int CannedMessageID, int ProfileID, int UserID, string MessageText, int CUserID, int MUserID, DateTime CDate, DateTime MDate, bool IsDeleted)
        {
            int returnval = 0;
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_CannedMessage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CannedMessageID", CannedMessageID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@MessageText", MessageText);
                sqlCmd.Parameters.AddWithValue("@CUserID", CUserID);
                sqlCmd.Parameters.AddWithValue("@MUserID", MUserID);
                sqlCmd.Parameters.AddWithValue("@CDate", CDate);
                sqlCmd.Parameters.AddWithValue("@MDate", MDate);
                sqlCmd.Parameters.AddWithValue("@IsDeleted", IsDeleted);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable != null && vtable.Rows.Count > 0)
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

        public static DataSet GetMessageByCannedID(int CannedMessageID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetMessageByCannedID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CannedMessageID", CannedMessageID);

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


        #endregion
        public static DataTable GetUserBannerAds(int profileId, bool IsLiteVersion)
        {
            DataTable vtable = new DataTable("BannerAds");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetUserBannerAds", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                if (IsLiteVersion != false)
                    sqlCmd.Parameters.AddWithValue("@IsLiteVersion", IsLiteVersion);
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
        public static void UpdateBannerAdAppDisplay(int bananerAdId, bool updateFlag, int modifiedUser)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateBannerAdAppDisplay", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BananerAdId", bananerAdId);
                sqlCmd.Parameters.AddWithValue("@AppDisplay", updateFlag);
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
        public static void Insert_BannerAds(int bannerAdId, int profileId, int userId, string hyperlinkUrl, int orderNo, string adTimeSpan, bool isAppDisplay, int createdUser)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_BannerAds", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BannerAdId", bannerAdId);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@UserId", userId);
                sqlCmd.Parameters.AddWithValue("@HyperlinkUrl", hyperlinkUrl);
                sqlCmd.Parameters.AddWithValue("@OrderNo", orderNo);
                sqlCmd.Parameters.AddWithValue("@AdTimeSpan", adTimeSpan);
                sqlCmd.Parameters.AddWithValue("@IsAppDisplay", isAppDisplay);
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
        public static DataTable GetBannerAdById(int bannerAdId)
        {
            DataTable vtable = new DataTable("BannerAd");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBannerAdById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BannerAdId", bannerAdId);
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
        public static void UpdateBannerAdDelete(int bannerAdId, int modifiedUser)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateBannerAdDelete", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BannerAdId", bannerAdId);
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

        public static void UpdateSponsorAdDelete(int bannerAdId, int modifiedUser)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateSponsorAdDelete", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BannerAdId", bannerAdId);
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
        public static bool CheckingIsSponsorForBannerAds(int pAssociateUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CheckingIsSponsorForBannerAds", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AssociateUserID", pAssociateUserID);
                return Convert.ToBoolean(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public enum BranedAppProcessStatus : int
        {
            New = 1,
            DataCollection = 2,
            InDesigning = 3,
            DataCollectionAndInDesigning = 4,
            Developement = 5,
            DeviceTesting = 6,
            SubmitStore = 7,
            Completed = 8
        }
        #region Ser_SilentPushMessages
        public static void Insert_SilentPushMessages(int ProfileId, DateTime CreatedDate, bool Sent_Flag, int? ContentType_Id, string ContentType, string ActionType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Ser_InsertSilentPushMessages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_Id", ProfileId);
                sqlCmd.Parameters.AddWithValue("@Publish_Date", CreatedDate);
                sqlCmd.Parameters.AddWithValue("@Sent_Flag", Sent_Flag);
                sqlCmd.Parameters.AddWithValue("@ContentType_Id", (ContentType_Id.Value == 0) ? (object)DBNull.Value : ContentType_Id.Value);
                sqlCmd.Parameters.AddWithValue("@ContentType", ContentType);
                sqlCmd.Parameters.AddWithValue("@ActionType", ActionType);
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


        public static DataTable GetButtonDetails(int pInvitationID, string pUniqueID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtItems = new DataTable("dtItems");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetButtonTypeByInvitationID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@InvitationID", pInvitationID);
                sqlCmd.Parameters.AddWithValue("@UniqueID", pUniqueID);
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

        #endregion

        #region Check Branded App

        public static DataTable GetBusinessProfileByProfileID(int ProfileID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBusinessProfileByProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_ID", ProfileID);
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



        public static void Insert_Update_BrandedAppRequest(int pAppRequestID, int pAppOrderID, int pUserID, int pProfileID, string pLogo, string pApp_Icon, string pApp_Description, string pApp_SplashCotent, string appshortDesc, string pAppDisplayName, string pApp_Keywords, string pAppUpdate, int pAppOrderStatusID, int? pAssignedCSID, string pRequestAction, string pLogoNotes, string pAppNameNotes, string pSplashNotes, string pShortDescNotes, string pDescNotes, string pKeywordsNotes, string pAppUpdateNotes, string pAppStoreIcon, string pPrintableAppStoreIcon, string pBackgroundIcon)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_BrandedAppRequest", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BrandedApp_RequestID", pAppRequestID);
                sqlCmd.Parameters.AddWithValue("@BrandedApp_OrderID", pAppOrderID);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@logo", pLogo);
                sqlCmd.Parameters.AddWithValue("@AppIcon", pApp_Icon);
                sqlCmd.Parameters.AddWithValue("@AppDescription", pApp_Description);
                sqlCmd.Parameters.AddWithValue("@SplashCotent", pApp_SplashCotent);
                sqlCmd.Parameters.AddWithValue("@AppShortDescription", appshortDesc);
                sqlCmd.Parameters.AddWithValue("@AppKeywords", pApp_Keywords);
                sqlCmd.Parameters.AddWithValue("@AppUpdate", pAppUpdate);
                sqlCmd.Parameters.AddWithValue("@AppOrderStatusID", pAppOrderStatusID);
                sqlCmd.Parameters.AddWithValue("@Assigned_CS", pAssignedCSID);
                sqlCmd.Parameters.AddWithValue("@AppStoreIcon", pAppStoreIcon);
                sqlCmd.Parameters.AddWithValue("@PrintableAppStoreIcon", pPrintableAppStoreIcon);
                sqlCmd.Parameters.AddWithValue("@AppDisplayName", pAppDisplayName);
                sqlCmd.Parameters.AddWithValue("@BackgroundIcon", pBackgroundIcon);
                sqlCmd.Parameters.AddWithValue("@RequestAction", pRequestAction);
                sqlCmd.Parameters.AddWithValue("@LogoNotes", pLogoNotes);
                sqlCmd.Parameters.AddWithValue("@AppNameNotes", pAppNameNotes);
                sqlCmd.Parameters.AddWithValue("@SplashNotes", pSplashNotes);
                sqlCmd.Parameters.AddWithValue("@ShortDescNotes", pShortDescNotes);
                sqlCmd.Parameters.AddWithValue("@DescNotes", pDescNotes);
                sqlCmd.Parameters.AddWithValue("@KeywordsNotes", pKeywordsNotes);
                sqlCmd.Parameters.AddWithValue("@AppUpdateNotes", pAppUpdateNotes);
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

        public static object App_Icon { get; set; }

        public static DataTable GetAppOrderStatusByBrandedAppRequestID(int BrandedApp_RequestID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAppOrderStatusByBrandedAppRequestID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BrandedApp_RequestID", BrandedApp_RequestID);
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
        public static DataTable GetUniqueProfileID()
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUniqueProfileID", sqlCon);
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
        public static int GetCallTotalSMSOptIns(int profileId)
        {
            int totalSMSOptins = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCallTotalSMSOptIns", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                totalSMSOptins = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return totalSMSOptins;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetISAUpgradeUsers(int pProfileID)
        {
            DataTable dt = new DataTable("dtISAUpgradeUsers");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetISAUpgradeUsers", sqlCon);
                sqlCmd.Parameters.AddWithValue("@PID", pProfileID);
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

        public static int CheckUserNameandDomainForUpgradeUser(string username, string vertical, string country)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int flag = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("CheckUserNameandDomainName", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                flag = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return flag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static int ShowMessageForISAUpgrade(int pPID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int flag = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CheckUpgradeAccountShowMessage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                flag = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return flag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetWebLinksByCategoryID(int lnkWeblinkCategory_ID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetWebLinksByCategoryID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Category_ID", lnkWeblinkCategory_ID);
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);

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

        /*** July 26 2016  ***/

        public static void InsertApprovalProccessDetails(string Remarks, DateTime Publish_Date, int Uid, string Initials, int? UserID, int surveyID, string hdnProcess, string IDType, int BusinessUpdateID, int EventId, int CustomID, string CalenderType, int BulletinID)
        {
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertApprovalProccessDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Remarks ", Remarks);
                sqlCmd.Parameters.AddWithValue("@Publish_Date ", Publish_Date);
                sqlCmd.Parameters.AddWithValue("@Uid ", Uid);
                sqlCmd.Parameters.AddWithValue("@Initials ", Initials);
                sqlCmd.Parameters.AddWithValue("@UserId  ", UserID);
                sqlCmd.Parameters.AddWithValue("@surveyID ", surveyID);
                sqlCmd.Parameters.AddWithValue("@hdnProcess ", hdnProcess);
                sqlCmd.Parameters.AddWithValue("@IDType ", IDType);
                sqlCmd.Parameters.AddWithValue("@BusinessUpdateID ", BusinessUpdateID);
                sqlCmd.Parameters.AddWithValue("@EventId ", EventId);
                sqlCmd.Parameters.AddWithValue("@CustomID ", CustomID);
                sqlCmd.Parameters.AddWithValue("@CalenderType ", CalenderType);
                sqlCmd.Parameters.AddWithValue("@BulletinID ", BulletinID);
                returnval = Convert.ToInt32(sqlCmd.ExecuteScalar());



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable getManageContentActivityLogs(string vertical, int Start, int End, int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable("ManageContentActivityLog");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("dbo.Usp_GetManageContentActivityLogs_Dashboard", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@profileID", profileID);
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
                sqlCmd.Parameters.AddWithValue("@Start", Start);
                sqlCmd.Parameters.AddWithValue("@End", End);
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);
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


        public static DataTable GetManageLogByActivityID(int ActivityID, string DomainName = "")
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable("ManageContentActivityLog");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("dbo.Usp_GetManageContentActivityLogs", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ActivityID", ActivityID);
                sqlCmd.Parameters.AddWithValue("@DomainName", DomainName);
                SqlDataAdapter adptr = new SqlDataAdapter(sqlCmd);
                adptr.Fill(dt);
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


        public static DataTable GetSponsorAdUsers()
        {
            DataTable dt = new DataTable("dtSponsorAdUsers");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_getSponsorAdUsers", sqlCon);
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


        public static void UpdateRecurringDetails(int subOrderID, decimal discount, decimal billableAmt, decimal totalAmt, int cUserID, DateTime expirationDate, string discountCode, int subPeriod)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateRecurringDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SubOrderID", subOrderID);
                sqlCmd.Parameters.AddWithValue("@Discount", discount);
                sqlCmd.Parameters.AddWithValue("@BillableAmt", billableAmt);
                sqlCmd.Parameters.AddWithValue("@TotalAmt", totalAmt);
                sqlCmd.Parameters.AddWithValue("@CUserID", cUserID);
                sqlCmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                sqlCmd.Parameters.AddWithValue("@DiscountCode", discountCode);
                sqlCmd.Parameters.AddWithValue("@SubPeriod", subPeriod);
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
        public static void Insert_Update_AppProcessStatus(int pAppOrderID, int pUserID, int pProfileID, string pLogo, string pApp_Icon, string pApp_Description, string splashCotent, string appshortDesc,
            string pApp_Keywords, string pIOS_URL, string pAndroid_URL, string pWindows_URL, string pWebsite_URL, int pAppOrderStatusID, int pAssignedCSID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_BrandedAppOrderStatus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AppOrderID", pAppOrderID);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@logo", pLogo);
                sqlCmd.Parameters.AddWithValue("@AppIcon", pApp_Icon);
                sqlCmd.Parameters.AddWithValue("@AppDescription", pApp_Description);
                sqlCmd.Parameters.AddWithValue("@SplashCotent", splashCotent);
                sqlCmd.Parameters.AddWithValue("@AppShortDescription", appshortDesc);
                sqlCmd.Parameters.AddWithValue("@AppKeywords", pApp_Keywords);
                sqlCmd.Parameters.AddWithValue("@IOS_URL", pIOS_URL);
                sqlCmd.Parameters.AddWithValue("@Android_URL", pAndroid_URL);
                sqlCmd.Parameters.AddWithValue("@Windows_URL", pWindows_URL);
                sqlCmd.Parameters.AddWithValue("@Website_URL", pWebsite_URL);
                sqlCmd.Parameters.AddWithValue("@AppOrderStatusID", pAppOrderStatusID);
                sqlCmd.Parameters.AddWithValue("@Assigned_CS", pAssignedCSID);
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
        public static DataTable GetOrderDetailsByProfileID_RequestType(int pPID, int pRequestTypeID)
        {
            DataTable dtorderdetails = new DataTable("orderdetails");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetOrderDetailsByPID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                sqlCmd.Parameters.AddWithValue("@RequestType", pRequestTypeID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtorderdetails);
                return dtorderdetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }


        public static void UpdateSponsorAdAppDisplay(int bananerAdId, bool updateFlag, int modifiedUser, bool IsAdMob, int OrderNo, string ProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateSponsorAdAppDisplay", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BananerAdId", bananerAdId);
                sqlCmd.Parameters.AddWithValue("@AppDisplay", updateFlag);
                sqlCmd.Parameters.AddWithValue("@ModifiedUser", modifiedUser);
                sqlCmd.Parameters.AddWithValue("@IsAdMob", IsAdMob);
                sqlCmd.Parameters.AddWithValue("@OrderNo", OrderNo);
                sqlCmd.Parameters.AddWithValue("@ProfileID", int.Parse(ProfileID));
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


        public static void Insert_SponsorAds(int bannerAdId, int profileId, int userId, string hyperlinkUrl, int orderNo, string adTimeSpan, bool isAppDisplay, int createdUser, bool IsAdMob)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Sponsor", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BannerAdId", bannerAdId);
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
                sqlCmd.Parameters.AddWithValue("@UserId", userId);
                sqlCmd.Parameters.AddWithValue("@HyperlinkUrl", hyperlinkUrl);
                sqlCmd.Parameters.AddWithValue("@OrderNo", orderNo);
                sqlCmd.Parameters.AddWithValue("@AdTimeSpan", adTimeSpan);
                sqlCmd.Parameters.AddWithValue("@IsAppDisplay", isAppDisplay);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", createdUser);
                sqlCmd.Parameters.AddWithValue("@IsAdMob", IsAdMob);
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
        public static void InsertUpdateBillingInfo(string Name, string LastName, string BillingEmail, string Address1, string Address2, string CityCapital, string City, string Zipcode, int UserID, int ProfileID, int BillingInfoID, int AddressId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertUpdateBillingInfo", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Name", Name);
                sqlCmd.Parameters.AddWithValue("@LastName", LastName);
                sqlCmd.Parameters.AddWithValue("@MailID", BillingEmail);
                sqlCmd.Parameters.AddWithValue("@Address1", Address1);
                sqlCmd.Parameters.AddWithValue("@Address2", Address2);
                sqlCmd.Parameters.AddWithValue("@CityCapital", CityCapital);
                sqlCmd.Parameters.AddWithValue("@City", City);
                sqlCmd.Parameters.AddWithValue("@Zipcode", Zipcode);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@BillingInfoID", BillingInfoID);
                sqlCmd.Parameters.AddWithValue("@AddressID", AddressId);

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

        public static DataTable GetInvoiceDetailsbyUserID(int userid)
        {
            DataTable detailInv = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetInvoiceDetails", sqlCon);// *** Fis for IRH-45 05-02-2013  usp_GetInvoiceDetails*** //
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userid); // *** @user_id *** //
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(detailInv);

                return detailInv;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

        }

        #region Store Module Functionality
        public static bool CheckModulePermission(string ButtonType, int ProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_CheckModulePermission", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ButtonType", ButtonType);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                return Convert.ToBoolean(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static bool CheckModuleDisplayOnOff(int pUserID, string pButtonType, int pUserModuleID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CheckModule_On_Off", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@ButtonType", pButtonType);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", pUserModuleID);
                return Convert.ToBoolean(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static string CheckModuleDisplayType(int pUserID, string pButtonType, int pUserModuleID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CheckModuleOrderType", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@ButtonType", pButtonType);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", pUserModuleID);
                return Convert.ToString(sqlCmd.ExecuteScalar());
            }
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
        public static DataTable GetStoreItems_New(string pCategory, string pDomainName, int pPackageID, int pProfileID)
        {
            DataTable dt = new DataTable("dtstore");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetStoreItems_New", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Category", pCategory);
                sqlCmd.Parameters.AddWithValue("@DomainName", pDomainName);
                sqlCmd.Parameters.AddWithValue("@PackageID", pPackageID);
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

        public static DataTable CaliculateAmount(int PackageID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable("amount");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CaliculateAmount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PackageID", PackageID);
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
        public static void UpdateMemorySpace(int profileID, int createdUser, int size)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateMemorySpace", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", createdUser);
                sqlCmd.Parameters.AddWithValue("@MemorySize", size);
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


        public static int InsertPackageItem(string domainName, string buttonType, string accessType, int orderDetailsId, DateTime renewalDate, int profileID, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                using (SqlCommand sqlCmd = new SqlCommand("USP_InsertPackageItem", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
                    sqlCmd.Parameters.AddWithValue("@ButtonType", buttonType);
                    sqlCmd.Parameters.AddWithValue("@AccessType", accessType);
                    sqlCmd.Parameters.AddWithValue("@OrderDetailsId", orderDetailsId);
                    sqlCmd.Parameters.AddWithValue("@RenewalDate", renewalDate);
                    sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                    sqlCmd.Parameters.AddWithValue("@UserID", userID);
                    return Convert.ToInt32(sqlCmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                CommonDAL.InsertErrorLog("ERROR", Convert.ToString(ex.Message),
                        Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "BusinessDAL", "InsertPackageItem");
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static void InsertPurchaseAddons(int profileID, int userID, int cUserID, string purchaseType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertPurchaseAddons", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@CUserID", cUserID);
                sqlCmd.Parameters.AddWithValue("@PurchaseType", purchaseType);
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

        public class SMSDetails
        {
            public int SMSQuantity { get; set; }
            public decimal SMSCost { get; set; }
            public string SMSType { get; set; }
        }

        public static void EnableSMSSetup(int profileId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_EnableSMSSetup", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileId);
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

        public static DataTable GetSearchSubAppsByUserID_EmailID(int pUserID, string pEmailID, string pVertical)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable("dtsubapps");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSubAppsByUserID_EmailID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@EmailID", pEmailID);
                sqlCmd.Parameters.AddWithValue("@Vertical", pVertical);
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

        public static void InsertSubAppInvitationRequest(int pParentProfileID, int pProfileID, string pNotes, int pUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertSubAppInvitationRequest", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ParentProfileID", pParentProfileID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@Notes", pNotes);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
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

        public static DataTable GetSubAppsByInvitationID(int pProfileID, int pInvitationID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable("dtsubapps");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSubappInvitationsByInvitationID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@InvitationID", pInvitationID);
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

        public static void UpdateSubAppInvitationRequest(int pInvitationID, int pProfileID, string pStatus, string pNotes)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateSubAppInvitation", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InvitationID", pInvitationID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@Notes", pNotes);
                sqlCmd.Parameters.AddWithValue("@Status", pStatus);
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


        public static void DeletePrivateCallHistory(int historyID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeletePrivateCallHistory", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@historyID", historyID);
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


        public static DataTable GetSubAppsByParentID(int pParentProfileID, string searchTag, out int totalAffiliates)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable("dtsubapps");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSubAppsByParentID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ParentProfileID", pParentProfileID);
                sqlCmd.Parameters.AddWithValue("@SearchTag", searchTag);
                sqlCmd.Parameters.Add(new SqlParameter("@TotalAffiliates", SqlDbType.Int)).Direction = ParameterDirection.Output;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dt);
                totalAffiliates = Convert.ToInt32(sqlCmd.Parameters["@TotalAffiliates"].Value.ToString());
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

        public static DataTable GetBillInfoDetailsByProfileID(int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable("dtbillinfo");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBillInfoDetailsByProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@profileID", profileID);
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
        public static DataTable GetPaymentBillingInfo(int profileID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPaymentBillingInfo", sqlCon);
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
        public static bool ValidateUserSubApp(int profileId)
        {
            bool isSubApp = false;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ValidateUserSubApp", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileId);
                isSubApp = Convert.ToBoolean(sqlCmd.ExecuteScalar());

                return isSubApp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        /***************************** SmartConnect Categories Feb 06 2017 ************************************************/

        public static DataTable GetSmartConnectCategories(int pUserModuleID, string pDomainName, int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSmartConnectCategoriesByUMID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleID", pUserModuleID);
                sqlCmd.Parameters.AddWithValue("@DominaName", pDomainName);
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

        public static void DeleteSmartConnectCategory(int pCategoryID, int pUserID, int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteSmartConnectCategoryByCatID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CatgoryID", pCategoryID);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
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

        public static int Insert_Update_SmartConnectCategory(int pCategoryID, string pCatName, string pDescription,
            int pUserModuleID, int pProfileID, int pUserID, string pCategoryType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_SmartConnectCategory", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CatgoryID", pCategoryID);
                sqlCmd.Parameters.AddWithValue("@CategoryName", pCatName);
                sqlCmd.Parameters.AddWithValue("@Description", pDescription);
                sqlCmd.Parameters.AddWithValue("@UMID", pUserModuleID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@CateType", pCategoryType);
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

        public static DataTable GetSmartConnectCategoryDetailsByID(int pCategoryID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSmartConnectCategoryDetilsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CategoryID", pCategoryID);
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

        public static DataSet ViewMessageHistoryDetailsByID(int pMessageHistoryID, string pButtonType, int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetMessageDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MessageHistoryID", pMessageHistoryID);
                sqlCmd.Parameters.AddWithValue("@ButtonType", pButtonType);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
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

        public static DataTable GetAssociateUsersForMessageDetails(int pUserID, int pUMID, string pButtonType, int pMessageHistoryID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAssociateUsersForMessageDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@UMID", pUMID);
                sqlCmd.Parameters.AddWithValue("@ButtonType", pButtonType);
                sqlCmd.Parameters.AddWithValue("@MessageHistoryID", pMessageHistoryID);
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

        public static void Insert_ReplyHistory_Notes(string pNotes, string pReplyEmailIDs, int pUserID, int pMessageHistoryID, string pButtonType, bool pIsSender)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_ReplyHistoryNotes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Notes", pNotes);
                sqlCmd.Parameters.AddWithValue("@ReplyEmailIDs", pReplyEmailIDs);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@MessageHistoryID", pMessageHistoryID);
                sqlCmd.Parameters.AddWithValue("@ButtonType", pButtonType);
                sqlCmd.Parameters.AddWithValue("@IsSender", pIsSender);
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


        //Assigning Category to SmartConnect Messages
        public static void AssignCategoryMessage(int CallAddOnsHistoryID, int CategoryID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AssignCategoryMessage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CallAddOnsHistoryID", CallAddOnsHistoryID);
                sqlCmd.Parameters.AddWithValue("@CategoryID", CategoryID);
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
        //Search the SmartConnectMessage by using startdate,enddate,category,text
        public static DataSet GetSmartConnectSearch(string CategoryID, string searchText, int ProfileID, bool IsArchive, DateTime? startDate = null, DateTime? endDate = null)
        {
            DataSet dsSearch = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSmartConnectSearch", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                sqlCmd.Parameters.AddWithValue("@startDate", startDate);
                sqlCmd.Parameters.AddWithValue("@endDate", endDate);
                sqlCmd.Parameters.AddWithValue("@searchText", searchText);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@IsArchive", IsArchive);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dsSearch);

                return dsSearch;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetPieChartDataForSmartConnectMessages(int ProfileID, bool IsArchive, int? GraphCurrentArchive = null)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPieChartDataForSmartConnectMessages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@IsArchive", IsArchive);
                sqlCmd.Parameters.AddWithValue("@GraphType", GraphCurrentArchive);
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

        public static DataTable GetSmartConnectCategoriesList(int ProfileID, int UserModuleID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSmartConnectCategories", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
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
        public static DataTable GetModuleItemsCount(int ProfileID, int UserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetaModuleItemsCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PROFILEID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@USERID", UserID);
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

        public static DataTable GetContactsbyHistoryID(int HistoryID, string pButtonType)
        {

            DataTable dsSearch = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("getContactsbyHistoryID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@HistoryId", HistoryID);
                sqlCmd.Parameters.AddWithValue("@ButtonType", pButtonType);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dsSearch);

                return dsSearch;
            }
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


        public static int UserCustomizeSettings(int CustomizeSettingsID, int ProfileID, int UserID, string PageType, string XMLValue, int UserModuleID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertUserCustomizeSettings", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CustomizeSettingsID", CustomizeSettingsID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
                sqlCmd.Parameters.AddWithValue("@PageType", PageType);
                sqlCmd.Parameters.AddWithValue("@XMLValue", XMLValue);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
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

        public static DataTable GetReadPublicCalls(int ProfileID, bool IsRead, bool IsArchive)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetReadPublicCalls", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@IsRead", IsRead);
                sqlCmd.Parameters.AddWithValue("@IsArchive", IsArchive);
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

        public static DataTable GetDisplayReadFirst(int ProfileID, string PageType, int UserModuleID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserCustomizeSettings", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@PageType", PageType);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
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

        public static DataTable GetPrepoulatesettings(int ProfileID, string PageType)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetUserCustomizeSettings", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@PageType", PageType);
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
