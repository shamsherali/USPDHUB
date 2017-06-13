using System;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class ezSmartSiteWizard : DataAccess
    {
        public static void InsertBusinessContactDetails(int profileID, string contactName, string businessName, string contactEmail)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertUpdateContactInformation", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@ConatactName", contactName);
                sqlCmd.Parameters.AddWithValue("@BusinessName", businessName);
                sqlCmd.Parameters.AddWithValue("@ContactEmail", contactEmail);
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
        // Insert Update Business Address
        public static void InsertBusinessAddress(int profileID, string streetAddress1, string streetAddress2, string profileCity, string profileState, string profileZipCode, string phoneNumber, string extNo, string faxNo, string webSiteUrl1, string webSiteUrl2)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertUpdateBusinessAddress", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@ProfileStreetAddress1", streetAddress1);
                sqlCmd.Parameters.AddWithValue("@ProfileStreetAddress2", streetAddress2);
                sqlCmd.Parameters.AddWithValue("@ProfileCity", profileCity);
                sqlCmd.Parameters.AddWithValue("@ProfileState", profileState);
                sqlCmd.Parameters.AddWithValue("@ProfileZipCode", profileZipCode);
                sqlCmd.Parameters.AddWithValue("@PhoneNo", phoneNumber);
                sqlCmd.Parameters.AddWithValue("@ExtNo", extNo);
                sqlCmd.Parameters.AddWithValue("@FaxNo", faxNo);
                sqlCmd.Parameters.AddWithValue("@ProfileWebsiteURL1", webSiteUrl1);
                sqlCmd.Parameters.AddWithValue("@ProfileWebsiteURL2", webSiteUrl2);
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

        // Insert Update Business Hours
        public static void InsertBusinessHours(int profileID, string profileBusinessHours, string profileBusinessDays, string businessKeywords)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertUpdateBusinessHours", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@ProfileBusinessHours", profileBusinessHours);
                sqlCmd.Parameters.AddWithValue("@ProfileBusinessDays", profileBusinessDays);
                sqlCmd.Parameters.AddWithValue("@ProfileKeyWords", businessKeywords);
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

        // Insert Update Business Description
        public static void InsertBusinessDescription(int profileID, string profileBusinessDescription, string noOfEmployess, string businessDuration, string profileMission, string profileCoreValues, string businessDescription, string profileEntity)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertUpdateBusinessDescription", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@ProfileDescription", profileBusinessDescription);
                sqlCmd.Parameters.AddWithValue("@NoOfEmployess", noOfEmployess);
                sqlCmd.Parameters.AddWithValue("@BusinessDuration", businessDuration);
                sqlCmd.Parameters.AddWithValue("@ProfileMission", profileMission);
                sqlCmd.Parameters.AddWithValue("@ProfileCoreValues", profileCoreValues);
                sqlCmd.Parameters.AddWithValue("@BusinessDescription", businessDescription);
                sqlCmd.Parameters.AddWithValue("@ProfileEntity", profileEntity);
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

        // Insert Update Business Membership
        public static void InsertBusinessMembership(int profileID, string profileLocalMembership)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertUpdateBusinessMembership", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@ProfileLocalMembership", profileLocalMembership);
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
        // Insert ezSmart Site Wizard
        public static void InsertezSmartSiteWizard(int userID, int wizardMode)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertUpdateWizardMode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@WizardMode", wizardMode);
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
        // Insert ezSmart Site Wizard
        public static void InsertezSmartSiteOption(int userID, int wizardOption)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_InsertUpdateWizardOption", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@WizardOption", wizardOption);
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

        //Get ezSmart Site Templates

        public static DataTable GetezSmartSiteMasterTemplates()
        {
            DataTable dtMasterTemp = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetUserMasterProfileTempaltes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtMasterTemp);
                return dtMasterTemp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable GetezSmartSiteChildTemplatesForMasterID(int masterID)
        {
            DataTable dtChildTemp = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetChildTemplatesForMasterID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@MasterTEMPID", masterID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtChildTemp);
                return dtChildTemp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        // Emd

        // Update ezSmart Site Template Name

        public static void UpdateezSmartSiteTemaplteForProfileID(int profileID, string templateName,int id)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateTemplateforProfileID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
                sqlCmd.Parameters.AddWithValue("@TemplateName", templateName);
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
        // End

        // Get ezSmart Site Template Details for Template Name
        public static DataTable GetezSmartSiteTemplateDetailsForTemplateName(string templatename)
        {
            DataTable dtChildTemp = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetSelectedTemplateDetails", sqlCon);
                sqlCmd.Parameters.AddWithValue("@TemplateName", templatename);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtChildTemp);
                return dtChildTemp;
            }
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

        // Help Menu
        public static DataTable GetHelpMasterMenuItems(bool isLiteVersion,string VerticalName)
        {
            DataTable dtHelpMaster = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllMenuMasterLinks", sqlCon);
                sqlCmd.Parameters.AddWithValue("@IsLiteVersion", isLiteVersion);
                sqlCmd.Parameters.AddWithValue("@Vertical_Name", VerticalName);
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
        public static void UpdateHelpContentbyHelpID(int helpID, string helpcontent, string helpVideo)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateHelpcontentbyHelpID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Help_ID", helpID);
                sqlCmd.Parameters.AddWithValue("@Help_content", helpcontent);
                sqlCmd.Parameters.AddWithValue("@Video_File", helpVideo);
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

        public static DataTable PopulateUserContacts(string emailAddress)
        {
            DataTable dtHelpChild = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_PopulateUserContactForEmail", sqlCon);
                sqlCmd.Parameters.AddWithValue("@EmailText", emailAddress);
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
        // End
        #region Glossary module
        public static DataTable GetGlossaryMasterMenuItems()
        {
            DataTable dtHelpMaster = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllMenuMasterGlossaryLinks", sqlCon);
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
        public static DataTable GetGlossaryChildMenuForMasterID(int glossaryMasterID)
        {
            DataTable dtHelpChild = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetAllGlossaryMenuChildLinksForMasterID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@MasterID", glossaryMasterID);
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
        public static DataTable GetGlossarymenuDetailsbyGlossaryID(int glossaryID)
        {
            DataTable dtHelpChild = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetGlossaryMenuDetailsbyGlossaryID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@Glossary_ID", glossaryID);
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
        public static void UpdateGlossaryContentbyGlossaryID(int glossaryID, string glossarycontent)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UpdateGlossarycontentbyGlossaryID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Glossary_ID", glossaryID);
                sqlCmd.Parameters.AddWithValue("@Glossary_content", glossarycontent);
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
        public static DataTable CheckEzsmartsiteStatus(int profileid)
        {
            DataTable dtEzsmartsite = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetEzsmartSiteStatusByProfileID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@Profileid", profileid);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtEzsmartsite);
                return dtEzsmartsite;
            }
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

      
    }
}
