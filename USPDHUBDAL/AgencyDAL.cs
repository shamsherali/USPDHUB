using System;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class AgencyDAL
    {
        /// <summary>
        /// Adding a user to agency
        /// </summary>
        /// <param name="agencyname">agencyname</param>
        /// <param name="email">email</param>
        /// <param name="firstname">firstname</param>
        /// <param name="phone">phone</param>
        /// <param name="date">date</param>
        /// <param name="remarks">remarks</param>
        /// <param name="id">id</param>
        /// <param name="title">title</param>
        /// <param name="howIKnow">howIKnow</param>
        /// <param name="vertical">vertical</param>
        /// <param name="promoCode">promoCode</param>
        /// <param name="parentProfileID">parentProfileID</param>
        /// <param name="affInvID">affInvID</param>
        /// <param name="pLastName">LastName</param>
        /// <param name="pCountry">Country</param>
        /// <param name="pAddress">Address</param>
        /// <param name="pCity">City</param>
        /// <param name="pState">State</param>
        /// <param name="pZipcode">Zipcode</param>
        /// <param name="pWebsiteURL">WebsiteURL</param>
        /// <returns>integer</returns>
        public static int AddAgencyUser(string agencyname, string email, string firstname, string phone, string date, string remarks,
            int id, string title, string howIKnow, string vertical, string promoCode, int? parentProfileID, int? affInvID, string pLastName,
            string pCountry, string pAddress, string pCity, string pState, string pZipcode, string pWebsiteURL,bool pIsLiteversion, string pSalesCode,string pAddress2)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                pSalesCode = (pSalesCode.Trim() != "" ? pSalesCode : null);
                SqlCommand sqlCmd = new SqlCommand("usp_ManageAgency", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@agencyname", agencyname);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.Parameters.AddWithValue("@FirstName", firstname);
                sqlCmd.Parameters.AddWithValue("@Phone", phone);
                sqlCmd.Parameters.AddWithValue("@date", date);
                sqlCmd.Parameters.AddWithValue("@remarks", remarks);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.Parameters.AddWithValue("@Title", title);
                sqlCmd.Parameters.AddWithValue("@HowIKnow", howIKnow);
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
                sqlCmd.Parameters.AddWithValue("@PromoCode", promoCode);
                sqlCmd.Parameters.AddWithValue("@ParentProfileID", parentProfileID);
                sqlCmd.Parameters.AddWithValue("@InvitationID", affInvID);
                sqlCmd.Parameters.AddWithValue("@LastName", pLastName);
                sqlCmd.Parameters.AddWithValue("@Country", pCountry);
                sqlCmd.Parameters.AddWithValue("@Address", pAddress);
                sqlCmd.Parameters.AddWithValue("@City", pCity);
                sqlCmd.Parameters.AddWithValue("@State", pState);
                sqlCmd.Parameters.AddWithValue("@Zipcode", pZipcode);
                sqlCmd.Parameters.AddWithValue("@WebsiteURL", pWebsiteURL);
                sqlCmd.Parameters.AddWithValue("@IsLiteVersion", pIsLiteversion);
                sqlCmd.Parameters.AddWithValue("@SalesCode", pSalesCode);
                sqlCmd.Parameters.AddWithValue("@Address2", pAddress2);
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
        public static void UpdateLiteVersion(int inquiryId, int flagType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_UpdateLiteVersion", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InquiryId", inquiryId);
                sqlCmd.Parameters.AddWithValue("@FlagType", flagType);
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
        /// Get the details of agency by agency id
        /// </summary>
        /// <param name="agencyID">agencyID</param>
        /// <returns>data table</returns>
        public static DataTable GetAgencydetailsByAgencyID(int agencyID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAgencydetailsByAgencyID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AgencyID", agencyID);
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
        /// for verifying listing details
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="type">type</param>
        /// <param name="vertical">vertical</param>
        /// <param name="country">country</param>
        /// <returns>datatable</returns>
        public static DataTable GetVerifyListingDtls(int inquiryID, string type, string vertical, string country)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_VERIFYLISTINGDTLS", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InquiryID", inquiryID);
                sqlCmd.Parameters.AddWithValue("@Type", type);
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
                sqlCmd.Parameters.AddWithValue("@Country", country);
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
        /// verifying the details based on id
        /// </summary>
        /// <param name="inquiryID">inquiry id</param>
        /// <returns>data table</returns>
        public static DataTable GetVerifyDetailsById(int inquiryID)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_VERIFYLISTINGDTLS", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InquiryID", inquiryID);
                sqlCmd.Parameters.AddWithValue("@Type", "");
                sqlCmd.Parameters.AddWithValue("@Vertical", "");
                sqlCmd.Parameters.AddWithValue("@Country", "");
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
        /// updating the agency details by agency id
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="agencyname">agencyname</param>
        /// <param name="email">email</param>
        /// <param name="firstname">firstname</param>
        /// <param name="lastname">lastname</param>
        /// <param name="phone">phone</param>
        /// <param name="state">state</param>
        /// <param name="city">city</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="address">address</param>
        /// <param name="websiteaddress">websiteaddress</param>
        /// <param name="salespersonsId">salespersonsId</param>
        /// <param name="status">status</param>
        /// <param name="vertical">vertical</param>
        /// <param name="title">title</param>
        /// <param name="howIKnow">howIKnow</param>
        /// <param name="country">country</param>
        /// <param name="parentProfileID">parentProfileID</param>
        /// <returns>integer</returns>
        public static int UpdateAgencyDtlsById(int inquiryID, string agencyname, string email, string firstname, string lastname, string phone, string state, string city, string zipcode, string address, string websiteaddress, int? salespersonsId, string status, string vertical, string title, string howIKnow, string country, int? parentProfileID,string address2)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 1;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateAgencyDtlsById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InquiryID", inquiryID);
                sqlCmd.Parameters.AddWithValue("@agencyname", agencyname);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.Parameters.AddWithValue("@FirstName", firstname);
                sqlCmd.Parameters.AddWithValue("@LastName", lastname);
                sqlCmd.Parameters.AddWithValue("@Phone", phone);
                sqlCmd.Parameters.AddWithValue("@State", state);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@Zipcode", zipcode);
                sqlCmd.Parameters.AddWithValue("@Address", address);
                sqlCmd.Parameters.AddWithValue("@WebsiteAddress", websiteaddress);
                sqlCmd.Parameters.AddWithValue("@salespersonId", salespersonsId);
                sqlCmd.Parameters.AddWithValue("@Status", status);
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
                sqlCmd.Parameters.AddWithValue("@Title", title);
                sqlCmd.Parameters.AddWithValue("@HowIKnow", howIKnow);
                sqlCmd.Parameters.AddWithValue("@Country", country);
                sqlCmd.Parameters.AddWithValue("@ParentProfileID", parentProfileID);
                sqlCmd.Parameters.AddWithValue("@Address2", address2);
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
        /// retrieving enquiry notes
        /// </summary>
        /// <param name="noteID">noteID</param>
        /// <param name="notetext">notetext</param>
        /// <param name="addedby">addedby</param>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="flag">flag</param>
        /// <returns>data table</returns>
        public static DataTable GetEnquiryNotes(int noteID, string notetext, string addedby, int inquiryID, bool flag)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetInquiryNotes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@NoteID", noteID);
                sqlCmd.Parameters.AddWithValue("@NoteText", notetext);
                sqlCmd.Parameters.AddWithValue("@AddedBy", addedby);
                sqlCmd.Parameters.AddWithValue("@InquiryID", inquiryID);
                sqlCmd.Parameters.AddWithValue("@flag", flag);
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
        /// inserting the enquiry notes with action date
        /// </summary>
        /// <param name="noteID">noteID</param>
        /// <param name="notetext">notetext</param>
        /// <param name="addedby">addedby</param>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="flag">flag</param>
        /// <param name="nextActDateTime">nextActDateTime</param>
        /// <returns>integer</returns>
        public static int InsertEnquiryNotesWithActioDate(int noteID, string notetext, string addedby, int inquiryID, bool flag, DateTime? nextActDateTime)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertInquiryNotesWithActionDate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@NoteID", noteID);
                sqlCmd.Parameters.AddWithValue("@NoteText", notetext);
                sqlCmd.Parameters.AddWithValue("@AddedBy", addedby);
                sqlCmd.Parameters.AddWithValue("@InquiryID", inquiryID);
                sqlCmd.Parameters.AddWithValue("@flag", flag);
                sqlCmd.Parameters.AddWithValue("@ActionDate", nextActDateTime);
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
        /// inserting enquiry notes
        /// </summary>
        /// <param name="noteID">noteID</param>
        /// <param name="notetext">notetext</param>
        /// <param name="addedby">addedby</param>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="flag">flag</param>
        /// <returns>integer</returns>
        public static int InsertEnquiryNotes(int noteID, string notetext, string addedby, int inquiryID, bool flag)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetInquiryNotes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@NoteID", noteID);
                sqlCmd.Parameters.AddWithValue("@NoteText", notetext);
                sqlCmd.Parameters.AddWithValue("@AddedBy", addedby);
                sqlCmd.Parameters.AddWithValue("@InquiryID", inquiryID);
                sqlCmd.Parameters.AddWithValue("@flag", flag);
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
        /// for inserting optional details
        /// </summary>
        /// <param name="facebook">facebook</param>
        /// <param name="twitter">twitter</param>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="logo">logo</param>
        /// <param name="flag">flag</param>
        /// <returns>int</returns>
        public static int InsertOptionalDtlsbyId(string facebook, string twitter, int inquiryID, string logo, bool flag)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 1;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertOptionalDtlsbyId", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Facebook", facebook);
                sqlCmd.Parameters.AddWithValue("@Twitter", twitter);
                sqlCmd.Parameters.AddWithValue("@InquiryID", inquiryID);
                sqlCmd.Parameters.AddWithValue("@logo", logo);
                sqlCmd.Parameters.AddWithValue("@flag", flag);
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
        /// inserting user details
        /// </summary>
        /// <param name="platitude1">platitude1</param>
        /// <param name="plongitude1">plongitude1</param>
        /// <param name="password">password</param>
        /// <param name="inquiryID">inquiryID</param>
        /// <returns>integer</returns>
        public static int InsertUserDetails(double platitude1, double plongitude1, string password, int inquiryID)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ActivateAccount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@latitude1", platitude1);
                sqlCmd.Parameters.AddWithValue("@longitude1", plongitude1);
                sqlCmd.Parameters.AddWithValue("@Password", password);
                sqlCmd.Parameters.AddWithValue("@InquiryId", inquiryID);
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

        // *** Start Sales Person Operations *** //

        /// <summary>
        /// retrieving sales person details
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetSalesPerson()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetSalesReps", sqlCon);
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
        /// for updating the path of logo
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="logopath">logopath</param>
        /// <returns>integer</returns>
        public static int UpdateLogoPath(int profileid, string logopath)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 1;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateLogoPath", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileid);
                sqlCmd.Parameters.AddWithValue("@logopath", logopath);
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
        /// for inserting training user dtails
        /// </summary>
        /// <param name="agencyname">agencyname</param>
        /// <param name="firstname">firstname</param>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <param name="address">address</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phoneno">phoneno</param>
        /// <param name="platitude1">platitude1</param>
        /// <param name="plongitude1">plongitude1</param>
        /// <param name="vertical">vertical</param>
        /// <returns>integeer</returns>
        public static int InsertTrainingUserDetails(string agencyname, string firstname, string username, string password, string address, string city, string state, string zipcode, string phoneno, double platitude1, double plongitude1, string vertical)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Training_useraccount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AgencyName", agencyname);
                sqlCmd.Parameters.AddWithValue("@FirstName", firstname);
                sqlCmd.Parameters.AddWithValue("@EmailID", username);
                sqlCmd.Parameters.AddWithValue("@Password", password);
                sqlCmd.Parameters.AddWithValue("@Address", address);
                sqlCmd.Parameters.AddWithValue("@City", city);
                sqlCmd.Parameters.AddWithValue("@State", state);
                sqlCmd.Parameters.AddWithValue("@Zipcode", zipcode);
                sqlCmd.Parameters.AddWithValue("@Phone", phoneno);
                sqlCmd.Parameters.AddWithValue("@latitude1", platitude1);
                sqlCmd.Parameters.AddWithValue("@longitude1", plongitude1);
                sqlCmd.Parameters.AddWithValue("@Vertical", vertical);
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
        /// getting the group types of agencies
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetGroupTypes()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetGroupTypes", sqlCon);
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
        /// inserting user permission details
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="pType">pType</param>
        /// <param name="settings">settings</param>
        /// <param name="permissionID">permissionID</param>
        /// <param name="associateID">associateID</param>
        /// <param name="isTipsAdmin">isTipsAdmin</param>
        /// <param name="createdBy">createdBy</param>
        /// <returns>integer</returns>
        public static int InsertUserPermissionDetails(int userID, string pType, int settings, int permissionID, int associateID, bool isTipsAdmin, int createdBy)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertUserPermissions", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Userid", userID);
                sqlCmd.Parameters.AddWithValue("@Type", pType);
                sqlCmd.Parameters.AddWithValue("@Settings", settings);
                sqlCmd.Parameters.AddWithValue("@Permission_ID", permissionID);
                sqlCmd.Parameters.AddWithValue("@AssociateID", associateID);
                sqlCmd.Parameters.AddWithValue("@IsTipsAdmin", isTipsAdmin);
                sqlCmd.Parameters.AddWithValue("@CreatedBy", createdBy);
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
        /// for retrieving permissions by id
        /// </summary>
        /// <param name="associateID">associateID</param>
        /// <returns>data table</returns>
        public static DataTable GetPermissionsById(int associateID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable("dtPermission");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPermissionsById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AssociateID", associateID);
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
        /// for deleting permissions
        /// </summary>
        /// <param name="permissionID">permissionID</param>
        /// <returns>integer</returns>
        public static int DeletePermissions(int permissionID)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 1;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeletePermisions", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Permission_ID", permissionID);
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
        /// getting active verticals
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetActiveVerticals()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAllActiveVerticals", sqlCon);
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
        /// for deleting selected listing
        /// </summary>
        /// <param name="listingID">listingID</param>
        public static void DeleteSelectedListing(int listingID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_DeleteSelectedListing", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ListingID", listingID);
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
        /// for validating the email of agency
        /// </summary>
        /// <param name="pEmailID">pEmailID</param>
        /// <param name="vertical">vertical</param>
        /// <param name="country">country</param>
        /// <returns>integer</returns>
        public static int ValidateAgencyEmailID(string pEmailID, string vertical, string country)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int flag = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ValidateAgencyEmailID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", pEmailID);
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
        /// getting the details of promocode
        /// </summary>
        /// <param name="pPromocode">Promocode</param>
        /// <returns>data table</returns>
        public static DataTable GetPromocodeDetails(string pPromocode)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPromocodeDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Promocode", pPromocode);
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
        // *** Checking User promo code *** //

        /// <summary>
        /// for checking the promocode
        /// </summary>
        /// <param name="promoCode">promoCode</param>
        /// <param name="domain">domain</param>
        /// <param name="checkVertical">checkVertical</param>
        /// <returns>data table</returns>
        public static DataTable CheckPromoCode(string promoCode, string domain, bool checkVertical)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable("promocode");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckPromoCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PromoCode", promoCode);
                sqlCmd.Parameters.AddWithValue("@Domain", domain);
                sqlCmd.Parameters.AddWithValue("@CheckVertical", checkVertical);
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
        /// get domain verticals
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetDomainVerticals()
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetDomainVerticals", sqlCon);
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
        /// for retrieving active invitations
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>data table</returns>
        public static DataTable GetActiveInvitations(int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetActiveInvitations", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
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
        /// for checking send invitation mails
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>data table</returns>
        public static int CheckSendInvitationEmail(string email)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int sentCount = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CheckSendInvitationEmail", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sentCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return sentCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        /// <summary>
        /// for getting code for invitation details by id
        /// </summary>
        /// <param name="invCodeID">invoice code id</param>
        /// <returns>data table</returns>
        public static DataTable GetInvitatioCodeDetailsByID(int invCodeID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetInvitatioCodeDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InvCodeID", invCodeID);
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
        /// for adding a invitation
        /// </summary>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <param name="email">email</param>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="invCodeID">invCodeID</param>
        /// <returns>integer</returns>
        public static int AddInvitation(string firstName, string lastName, string email, int profileID, int userID, int invCodeID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int affID = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AddInvitation", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FirstName", firstName);
                sqlCmd.Parameters.AddWithValue("@LastName", lastName);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@InvCodeID", invCodeID);
                affID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return affID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        /// <summary>
        /// for getting invitation details by id
        /// </summary>
        /// <param name="affiliateInvID">affiliateInvID</param>
        /// <returns>data table</returns>
        public static DataTable GetInvitationDetailsByID(int? affiliateInvID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetInvitationDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AffiliateInvID", affiliateInvID);
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
        /// for cancelling invitation
        /// </summary>
        /// <param name="affiliateID">affiliateID</param>
        /// <param name="userID">userID</param>
        public static void CancelInvitation(int affiliateID, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CancelInvitationCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AffiliateID", affiliateID);
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
        /// for generating sub app codes
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="createdUser">createdUser</param>
        /// <param name="count">count</param>
        /// <param name="isPaid">isPaid</param>
        /// <returns>integer</returns>
        public static int GenerateSubAppCodes(int profileID, int createdUser, int count, bool isPaid)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int sentCount = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GenerateSubAppCodes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@CreatedUser", createdUser);
                sqlCmd.Parameters.AddWithValue("@Count", count);
                sqlCmd.Parameters.AddWithValue("@IsPaid", isPaid);
                sentCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return sentCount;
        }

        /// <summary>
        /// for inserting new subscription details of user
        /// </summary>
        /// <param name="platitude1">latitude1</param>
        /// <param name="plongitude1">longitude1</param>
        /// <param name="password">password</param>
        /// <param name="inquiryID">inquiryID</param>
        /// <returns></returns>
        public static int InsertNewSubcriptionUserDetails(double platitude1, double plongitude1, string password, int inquiryID, int pProfileSubTypeID)
        {
            DataTable vtable = new DataTable("business");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_ActivateNewAccount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@latitude1", platitude1);
                sqlCmd.Parameters.AddWithValue("@longitude1", plongitude1);
                sqlCmd.Parameters.AddWithValue("@Password", password);
                sqlCmd.Parameters.AddWithValue("@InquiryId", inquiryID);
                sqlCmd.Parameters.AddWithValue("@ProfileSubTypeID", pProfileSubTypeID);
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
        /// For updating the subscription of agency
        /// </summary>
        /// <param name="inquiryID">inquiryID</param>
        /// <param name="orderID">orderID</param>
        /// <param name="subPeriod">subPeriod</param>
        /// <param name="branded">branded</param>
        /// <returns>An integer</returns>
        public static int UpdateAgencySubscription(int inquiryID, int orderID, int subPeriod, string branded, bool isUpgrade)
        {
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateAgencySubscription", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@InquiryID", inquiryID);
                sqlCmd.Parameters.AddWithValue("@OrderID", orderID);
                sqlCmd.Parameters.AddWithValue("@SubPeriod", subPeriod);
                sqlCmd.Parameters.AddWithValue("@Branded", branded);
                sqlCmd.Parameters.AddWithValue("@IsUpgrade", isUpgrade);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlCmd.ExecuteNonQuery();
                returnval = 1;
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
        /// For retreiving the type of data feed
        /// </summary>
        /// <param name="pProfileID">ProfileID</param>
        /// <param name="pFeedsType">FeedsType</param>
        /// <param name="moduleID">moduleID</param>
        /// <returns>Data table</returns>
        public static DataTable GetDataFeeds(int pProfileID, string pFeedsType, int moduleID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtDataFeeds = new DataTable("datafeeds");

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetDataFeeds", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@FeedsType", pFeedsType);
                sqlCmd.Parameters.AddWithValue("@ModuleID", moduleID);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(dtDataFeeds);
                return dtDataFeeds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

        }

        /// <summary>
        /// for retrieving profile types based on verticals
        /// </summary>
        /// <param name="vertical">vertical</param>
        /// <returns>Data table</returns>
        public static DataTable GetProfilesByVertical(string vertical)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtDataFeeds = new DataTable("datafeeds");

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfilesByVertical", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@vertical", vertical);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(dtDataFeeds);
                return dtDataFeeds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

        }

        // Tips Manager
        /// <summary>
        /// for getting audio tips
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pVerticalDomain">pVerticalDomain</param>
        /// <returns>data table</returns>
        public static DataTable GetAudio_TipsManager(int pProfileID, int pUserID, string pVerticalDomain)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtAudio = new DataTable("dtAudio");

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAudio_TipsManager", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@VerticalDomain", pVerticalDomain);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(dtAudio);
                return dtAudio;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        /// <summary>
        /// For Inserting and updating audio tips
        /// </summary>
        /// <param name="pAudioID">pAudioID</param>
        /// <param name="pPID">pPID</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pAudioName">pAudioName</param>
        /// <param name="pAudioFile">pAudioFile</param>
        /// <param name="pIsDefault">pIsDefault</param>
        /// <param name="pDefaultAudioID">pDefaultAudioID</param>
        /// <param name="pAudioType">pAudioType</param>
        public static void Insert_UpdateAudio_TipsManager(int pAudioID, int pPID, int pUserID, string pAudioName, string pAudioFile,
            bool pIsDefault, int pDefaultAudioID, string pAudioType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_UpdateAudio_TipsManager", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AudioID", pAudioID);
                sqlCmd.Parameters.AddWithValue("@PID", pPID);
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@AudioName", pAudioName);
                sqlCmd.Parameters.AddWithValue("@AudioFile", pAudioFile);
                sqlCmd.Parameters.AddWithValue("@IsDefault", pIsDefault);
                sqlCmd.Parameters.AddWithValue("@DefaultID", pDefaultAudioID);
                sqlCmd.Parameters.AddWithValue("@AudioType", pAudioType);
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
        /// For deleting audio tips maanager
        /// </summary>
        /// <param name="pAudioID">pAudioID</param>
        public static void DeleteAudio_TipsManager(int pAudioID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeleteTipsAudio", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AudioID", pAudioID);
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
        /// For getting additional modules data by profile id
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>data table</returns>
        public static DataTable GetPurchaseAddOnsByProfileID(int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtPurchaseAddOns = new DataTable("dtPurchaseAddOns");

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPurchaseAddOnsByProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pProfileID);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(dtPurchaseAddOns);
                return dtPurchaseAddOns;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        /// <summary>
        /// For getting custom module templates
        /// </summary>
        /// <param name="domainName">domainName</param>
        /// <param name="isTemplate">isTemplate</param>
        /// <returns>data table</returns>
        public static DataTable GetCustomModuleTemplates(string domainName, bool isTemplate)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtCustomModuleTemplates = new DataTable("dtCustomModuleTemplates");

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CustomModuleTemplates", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
                sqlCmd.Parameters.AddWithValue("@IsTemplate", isTemplate);
                adapter.Fill(dtCustomModuleTemplates);
                return dtCustomModuleTemplates;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        /// <summary>
        /// for automatic on off for an email
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="autoEmailOnOff">autoEmailOnOff</param>
        public static void UpdateAutoOnOff(int userID, bool autoEmailOnOff)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_UpdateAutoOnOff", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@AutoOnOff", autoEmailOnOff);
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
        /// For getting custom module App Icon
        /// </summary>
        /// <param name="moduleID">moduleID</param>
        /// <param name="domainName">domainName</param>
        /// <param name="pIsPrivate">pIsPrivate</param>
        /// <returns>datatable</returns>
        public static DataTable GetCustomModuleAppIcons(int moduleID, string domainName, bool pIsPrivate)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtCustomModuleAppIcons = new DataTable("dtCustomModuleAppIcons");

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CustomModuleAppIcons", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure; ;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
                sqlCmd.Parameters.AddWithValue("@ModuleID", moduleID);
                sqlCmd.Parameters.AddWithValue("@IsPrivate", pIsPrivate);
                adapter.Fill(dtCustomModuleAppIcons);
                return dtCustomModuleAppIcons;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        /// <summary>
        /// Get default audio file of a tips manager
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pVerticalDomain">pVerticalDomain</param>
        /// <returns>data table</returns>
        public static DataTable GetTipsManagerDefaultAudioFile(int pProfileID, string pVerticalDomain)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtAudio = new DataTable("dtAudio");

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetTipsManagerAudioDefaultByPID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@VerticalDomain", pVerticalDomain);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(dtAudio);
                return dtAudio;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        /// <summary>
        /// Get pin code of the app
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>data table</returns>
        public static DataTable GetAppPinCode(int userId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtUserAppDetails = new DataTable("dtUserAppDetails");

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAppPinCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure; ;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                sqlCmd.Parameters.AddWithValue("@UserId", userId);
                adapter.Fill(dtUserAppDetails);
                return dtUserAppDetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        /// <summary>
        /// for creating and updating pincode
        /// </summary>
        /// <param name="pinCode">pinCode</param>
        /// <param name="appName">appName</param>
        public static void CreateUpdatePinCode(string pinCode, string appName)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_CreateUpdatePinCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PinCode", pinCode);
                sqlCmd.Parameters.AddWithValue("@AppName", appName);
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
        /// For getting products based on domain
        /// </summary>
        /// <param name="domainName">domainName</param>
        /// <returns>data table</returns>
        public static DataTable GetProductsByDomain(string domainName)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtProducts = new DataTable("dtProducts");

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProductsByDomain", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure; ;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                sqlCmd.Parameters.AddWithValue("@DomainName", domainName);
                adapter.Fill(dtProducts);
                return dtProducts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        /// <summary>
        /// For inserting and updating user permissions
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="userModuleID">userModuleID</param>
        /// <param name="isAuthor">isAuthor</param>
        /// <param name="isPublisher">isPublisher</param>
        /// <param name="isReviewer">isReviewer</param>
        /// <param name="associateID">associateID</param>
        /// <param name="pageTitle">pageTitle</param>
        /// <param name="modifiedUser">modifiedUser</param>
        public static void InsertUpdateUserPermissions(int profileID, int userID, int? userModuleID, bool isAuthor, bool isPublisher, bool isReviewer, int associateID, string pageTitle, int modifiedUser,bool? IsDeleter=false)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertUpdate_UserPermissions", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", userModuleID);
                sqlCmd.Parameters.AddWithValue("@IsAuthor", isAuthor);
                sqlCmd.Parameters.AddWithValue("@IsPublisher", isPublisher);
                sqlCmd.Parameters.AddWithValue("@IsReviewer", isReviewer);
                sqlCmd.Parameters.AddWithValue("@AssociateID", associateID);
                sqlCmd.Parameters.AddWithValue("@PageTitle", pageTitle);
                sqlCmd.Parameters.AddWithValue("@ModifiedUser", modifiedUser);
                sqlCmd.Parameters.AddWithValue("@IsDeleter", IsDeleter);
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
        /// For deleting permissions based on associates
        /// </summary>
        /// <param name="associateUserID">associateUserID</param>
        public static void DeletePermissionsByAssociate(int associateUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeletePermissionsByAssociate", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AssociateID", associateUserID);
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
        /// For retrieving permissions based on associates
        /// </summary>
        /// <param name="associateUserID">associateUserID</param>
        /// <returns></returns>
        public static DataTable GetPermissionsByAssociateId(int associateUserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtAudio = new DataTable("dtAssociatePermission");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAssociatePermission", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AssocUserID", associateUserID);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(dtAudio);
                return dtAudio;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        /// <summary>
        /// For saving user permissions based on id
        /// </summary>
        /// <param name="associateID">associateID</param>
        /// <returns>Data table</returns>
        public static DataTable SaveUserPermissionsById(int associateID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable("dtPermission");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_SaveUserPermissionsById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@AssociateID", associateID);
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
        /// For getting permissions based on user module id
        /// </summary>
        /// <param name="userModuleId">userModuleId</param>
        /// <param name="assocUser">assocUser</param>
        /// <returns>Data table</returns>
        public static DataTable GetPermissionValueByUserModuleID(int userModuleId, int assocUser)
        {
            DataTable dt = new DataTable("dtPermission");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetPermissionValueByUserModuleID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserModuleId", userModuleId);
                sqlCmd.Parameters.AddWithValue("@AssocUserId", assocUser);
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
        public static DataTable GetSubAppsByPID(int profileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetAllSubAppsByPID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PID", profileID);
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

        public static DataTable GetProfileSubscriptionType()
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetProfileSubscriptionTypes", sqlCon);
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

        public static DataTable GetUpgradeInfoByProfileID(int profileId)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetUpgradeInfoByProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileId", profileId);
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
