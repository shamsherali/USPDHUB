using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class PrivateSmartConnectDAL
    {
        /// <summary>
        /// Geeting the contact details of contacts  for sending invitation
        /// </summary>
        /// <param name="pUserModuleID">pUserModuleID</param> 
        /// <param name="pValue">pValue</param>
        /// <returns>data table</returns>
        public static DataTable GetAllContactsForPSCSendInvitation(int pUserModuleID, string pValue)
        {
            DataTable vtable = new DataTable("vtable");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetContactsForPrivateSmartConnect", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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



        public static DataTable GetPrivateSmartConnectCategoriesList(int ProfileID, int UserModuleID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPrivateSmartConnectCategories", sqlCon);
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
        public static DataTable GetPSCCallIndex_Buttons(int pProfileID, int? userModuleId)
        {
            DataTable dtPublicCallIndex_Buttons = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetPSCCallIndexButtons", sqlCon);
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

        public static DataTable GetAllManagePSCCallIndexAddOns(int pUserID, int pCustomModuleId, string pCategoryIDs)
        {
            DataTable dtManageBulletin = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAllManagePSCCallIndexAddOns", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", pUserID);
                sqlCmd.Parameters.AddWithValue("@CustomModuleId", pCustomModuleId);
                sqlCmd.Parameters.AddWithValue("@CategoryIds", pCategoryIDs);
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

        public static DataTable GetAllPSCCallIndexAddOnsByOrder(int userModuleId)
        {
            DataTable dTPublicCallAddOns = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAllPSCCallIndexAddOnsByOrder", sqlCon);
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

        public static DataTable GetPSCCallIndexByID(int CustomID)
        {
            DataTable ds = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetPSCCallIndexDetailsByID", sqlCon);
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
        public static DataSet GetPSCCallGroupsData(int UserModuleID)
        {
            DataSet dsGroup = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetAllPSCCallGroupNames", sqlCon);
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

        public static DataTable GetActiveContactsForPSC(int UserModuleID, string GroupIDs)
        {

            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetActiveContactsforPSC", sqlCon);
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
        public static DataTable GetPSCCallGroupContactsByID(int CustomID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetPSCCallGroupContactsById", sqlCon);
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

        public static int InsertUpdatePSCCallIndexData(int CustomID, int ProfileID, int UserID, string Title, string ImageUrls, string MobileNumber, bool IsAutoEmail,
        string Email_Description, string Email_GroupIDs, bool IsAutoTextMessage, string SMS_Description, string SMS_GroupIDs, bool IsGPSInformation, bool IsAllPhoneInformation,
        bool IsActive, int CreatedUser, int ModifyUser, int UserModuleID, bool IsDeleted, bool IsPublish, bool IsPublic, string Email_Subject,
        string SMS_Subject, string Description, string PreviewHtml, bool IsVisible, bool IsInitiatesPhoneCall, bool IsCustomPredefinedMessage, bool IsUploadImage, int AppUserAnonymousType,
            int CategoryID, bool IsAutoPushNotification, string PushNotification_GroupIDs, string PushNotification_Description, string PushNotification_Subject, string AddressInfo, string GPS_Details,
            bool IsMessageMandatory, string DefaultMessage, bool IsLocationProximityOn, int ProximityRadius, string RadiusType, bool IsClickable)
        {
            int customID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_InsertUpdatePSCCallIndexData", sqlCon);
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
                sqlCmd.Parameters.AddWithValue("@IsUploadImage", IsUploadImage);
                sqlCmd.Parameters.AddWithValue("@AppUserAnonymousType", AppUserAnonymousType);
                sqlCmd.Parameters.AddWithValue("@IsAutoPushNotification", IsAutoPushNotification);
                sqlCmd.Parameters.AddWithValue("@PushNotification_Description", PushNotification_Description);
                sqlCmd.Parameters.AddWithValue("@PushNotification_GroupIDs", PushNotification_GroupIDs);
                sqlCmd.Parameters.AddWithValue("@PushNotification_Subject", PushNotification_Subject);
                sqlCmd.Parameters.AddWithValue("@IsCustomPredefinedMessage", IsCustomPredefinedMessage);
                sqlCmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                sqlCmd.Parameters.AddWithValue("@AddressInfo", AddressInfo);
                sqlCmd.Parameters.AddWithValue("@GPS_Details", GPS_Details);
                sqlCmd.Parameters.AddWithValue("@IsMessageMandatory", IsMessageMandatory);
                sqlCmd.Parameters.AddWithValue("@DefaultMessage", DefaultMessage);
                sqlCmd.Parameters.AddWithValue("@IsLocationProximityOn", IsLocationProximityOn);
                sqlCmd.Parameters.AddWithValue("@ProximityRadius", ProximityRadius);
                sqlCmd.Parameters.AddWithValue("@RadiusType", RadiusType);
                sqlCmd.Parameters.AddWithValue("@IsClickable", IsClickable);
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

        public static DataTable GetPSCContactsbyUserModuleID(int UserModuleID, string SearchText = "")
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetPSCContactsbyUserModuleID", sqlCon);
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
        public static int CheckPSCAssignGroupToContact(int chkContactId, int groupId, int UserModuleID, int ProfileID)
        {
            int assignId = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_CheckPSCAssignGroupToContact", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ContactID", chkContactId);
                sqlCmd.Parameters.AddWithValue("@GroupID", groupId);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
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

        public static DataSet GetPSCGroups(int userModuleId)
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetPSCIndexGroups", sqlCon);
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

        public static int CheckEmailExistsForPSC(string EmailID, int UserModuleID, int pContactID, string PhoneNumber)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int result = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckEmailExistsForPSC", sqlCon);
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
        public static string GetCallContactGroupsForPSC(int contactId)
        {
            string groupsList = "";
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetCallContactGroupsForPSC", sqlCon);
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
        public static int InsertUpdatePSCContacts(int contactID, string FirstName, string LastName, string EmailID, string CompanyName, string Address, string City, string State, string Zipcode, string Landline, string MobileNumber, string FaxNumber, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int UserID, int CreatedUser, string Position, string Organization, bool IsAllowedToSendIvitation, bool IsEmail_SMS_Unsubscribe)
        {
            int CID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_AddContactForPSC", sqlCon);
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

        public static int AssignPSCGroupContactID(int assignID, int GroupID, int contactID, int UserModuleID, int ProfileID)
        {
            int AssignID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_AssignPSCGroupContact", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Assign_Group_Contact_ID", assignID);
                sqlCmd.Parameters.AddWithValue("@GroupID", GroupID);
                sqlCmd.Parameters.AddWithValue("@ContactID", contactID);
                sqlCmd.Parameters.AddWithValue("@UserModuleID", UserModuleID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
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

        /***************************** SmartConnect Categories April 18 2017 ************************************************/

        public static DataTable GetPrivateSmartConnectCategories(int pUserModuleID, string pDomainName, int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPrivateSmartConnectCategoriesByUMID", sqlCon);
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

        public static void DeletePrivateSmartConnectCategory(int pCategoryID, int pUserID, int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeletePSCCategoryByCatID", sqlCon);
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

        public static int Insert_Update_PrivateSmartConnectCategory(int pCategoryID, string pCatName, string pDescription,
            int pUserModuleID, int pProfileID, int pUserID, string pCategoryType)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_PSCCategory", sqlCon);
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

        public static DataTable GetPrivateSmartConnectCategoryDetailsByID(int pCategoryID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPSCCategoryDetilsByID", sqlCon);
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

        public static DataSet GetPSCGroupByID(int GroupID)
        {
            DataSet dsGroup = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetPSCGroupDetailsByID", sqlCon);
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
        public static void DeletePscindexItem(int pCustomID, int UserID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeletePSCCallIndexItem", sqlCon);
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
        public static int CheckAssignGroupToContactforPSC(int chkContactId, int groupId, int UserModuleID)
        {
            int assignId = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_CheckAssignGroupToContactforPSC", sqlCon);
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

        public static int AddGroup(int GroupID, string GroupName, string GroupDescription, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int CreatedUser, int UserID)
        {
            int groupID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_AddGroupForPSC", sqlCon);
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

        public static DataTable GetPSCCallOnsHistoryDetailsByCustomID(int pHistory,bool pIsFromEmail)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtItems = new DataTable("dtItems");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPSCCallOnsHistoryDetailsByCustomID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@HistoryID", pHistory);
                sqlCmd.Parameters.AddWithValue("@IsFromEmail", pIsFromEmail);
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

        public static DataTable GetPSC_SenderDetails(string pUniqueID, int pAppID, int pPID, int pUserModuleID, int pPushTypeID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtItems = new DataTable("dtItems");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_PSC_SenderDetails", sqlCon);
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

        public static DataTable GetPSCDetailsByCustomID(int pCustomID, int pPushNotifyID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            DataTable dtItems = new DataTable("dtItems");
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_m_GetPSCDetailsByCustomID", sqlCon);
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

        public static void UpdatePSCAddonOrder(int customID, int orderNo, int modifiedUserId)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdatePSCAddonOrder", sqlCon);
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


        public static int AddGroupForPSC(int GroupID, string GroupName, string GroupDescription, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int CreatedUser, int UserID)
        {
            int groupID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_AddGroupForPSC", sqlCon);
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
        public static void DeleteGroupsForPSC(string groupIds)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeleteGroupForPSC", sqlCon);
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
        public static DataSet GetGroupByIDForPSC(int GroupID)
        {
            DataSet dsGroup = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetGroupDetailsByIDForPSC", sqlCon);
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
        public static DataSet GetPSCActiveGroups(int UserModuleID)
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetPSCActiveGroups", sqlCon);
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
        public static int DeleteContactsForPSC(string contactIds)
        {
            int contactID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_DeleteContactsForPSC", sqlCon);
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
        public static DataSet GetContactByIDForPSC(int ContactID)
        {
            DataSet dsContact = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetContactDetailsByIDForPSC", sqlCon);
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
        public static DataTable SearchEmailIDForPSC(string searchText, int UserModuleID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_SearchContactEmailForPSC", sqlCon);
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
        public static int InsertImportContactsForPSC(int contactID, string FirstName, string LastName, string EmailID, string CompanyName, string Address, string City, string State, string Zipcode, string Landline, string MobileNumber, string FaxNumber, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int UserID, int CreatedUser, int groupId, string Title, string Organization)
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
        /// Get Private SmartConnect Calls History
        /// </summary>
        /// <param name="pIsAllItems"></param>
        /// <param name="pHistoryID"></param>
        /// <param name="pProfileID"></param>
        /// <param name="IsRead"></param>
        /// <param name="IsArchive"></param>
        /// <param name="pUserModuleID"></param>
        /// <returns></returns>
        public static DataTable GetPSC_CallsHistory(bool pIsAllItems, int pHistoryID, int pProfileID, int pUserModuleID = 0, bool? IsRead = false, bool? IsArchive = false)
        {
            DataTable msgs = new DataTable("msg");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllPSCCallsHistory", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@IsAllItem", pIsAllItems);
                sqlCmd.Parameters.AddWithValue("@HistoryID", pHistoryID);
                sqlCmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@IsRead", IsRead);
                sqlCmd.Parameters.AddWithValue("@IsArchive", IsArchive);
                sqlCmd.Parameters.AddWithValue("@UMID", pUserModuleID);
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

        public static DataTable GetPieChartDataForPSCMessages(int ProfileID, bool IsArchive, int pUMID = 0, int? GraphCurrentArchive = null)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPieChartDataForPSCMessages", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@IsArchive", IsArchive);
                sqlCmd.Parameters.AddWithValue("@UMID", pUMID);
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

        public static void DeletePSCCallHistory(int historyID, int pProfileID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_DeletePSCCallHistory", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@HistoryID", historyID);
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

        //Assigning Category to SmartConnect Messages
        public static void AssignCategoryForPSCMessage(int CallAddOnsHistoryID, int CategoryID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AssignCategoryForPSCMessage", sqlCon);
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

        //Search the Private SmartConnectMessage by using startdate,enddate,category,text
        public static DataSet GetPSCMessagesSearch(string CategoryID, string searchText, int ProfileID,
            bool IsArchive, int pUMID = 0, DateTime? startDate = null, DateTime? endDate = null)
        {
            DataSet dsSearch = new DataSet();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPSCMessagesSearch", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                sqlCmd.Parameters.AddWithValue("@startDate", startDate);
                sqlCmd.Parameters.AddWithValue("@endDate", endDate);
                sqlCmd.Parameters.AddWithValue("@searchText", searchText);
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@IsArchive", IsArchive);
                sqlCmd.Parameters.AddWithValue("@UMID", pUMID);
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
        public static int BlockUnBlockPSCSenders(int messageID, bool blockFlag, int userID)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            int flag = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_BlockUnBlockPSCSenders", sqlCon);
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

        public static DataTable GetRead_Unread_PSCCalls(int ProfileID, bool IsRead, bool IsArchive, int pUMID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetReadUnreadPSCCalls", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
                sqlCmd.Parameters.AddWithValue("@IsRead", IsRead);
                sqlCmd.Parameters.AddWithValue("@IsArchive", IsArchive);
                sqlCmd.Parameters.AddWithValue("@UMID", pUMID);
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

        public static int ChangePSCCallAddOnVisiblity(int customId, int modifiedUser)
        {
            int _result = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_ChangePSCCallAddOnVisiblity", sqlCon);
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

        public static DataTable GetAllPSCModulesbyProfileID(int ProfileID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetAllPSCModulesbyProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", ProfileID);
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

        public static DataTable GetQRConnectCredits_Usage_Details(int pProfileID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetPrivateQRConnectCreditsDetails", sqlCon);
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


        public static int CopyQRConnect(int bulletinID, string bulletinTitle, int userID)
        {
            int copyBulletinID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CopyQRConnect", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@QRConnectID ", bulletinID);
                sqlCmd.Parameters.AddWithValue("@QRConnectTitle", bulletinTitle);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                copyBulletinID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                
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


        public static int CheckforDuplicateTitle(string Title)
        {
            int Count = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_CheckDuplicateTitleforPSC", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Title", Title);
                Count = Convert.ToInt32(sqlCmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
            return Count;
        }

    }
}
