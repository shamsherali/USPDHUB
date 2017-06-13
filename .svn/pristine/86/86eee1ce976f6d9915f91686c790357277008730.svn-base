using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace UserFormsDAL
{
    public class MobileAppSettings
    {
       /// <summary>
       /// retrieves mobile app settings
       /// </summary>
       /// <param name="pUserID">userid</param>
       /// <returns>datatable</returns>
        public static DataTable GetMobileAppSetting(int pUserID)
        {
            DataTable dtMSettings = new DataTable("MSettings");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {

                SqlCommand sqlCmd = new SqlCommand("usp_M_GetMobileSettings", sqlCon);
                sqlCmd.Parameters.AddWithValue("@User_ID", pUserID);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtMSettings);

                return dtMSettings;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

        }
        /// <summary>
        /// retreving all categories of bulletins
        /// </summary>
        /// <returns>data table</returns>
        public static DataTable GetAllCategories()
        {
            DataTable vtable = new DataTable("Categories");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("M_GetAllCategories", sqlCon);
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
        /// getting search result.
        /// </summary>
        /// <param name="pKeyword">keyword</param>
        /// <param name="pCatType">type</param>
        /// <returns>datatable</returns>
        public static DataTable GetSearchResult(string pKeyword, string pCatType)
        {
            DataTable vtable = new DataTable("Search");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("M_GetSearchResult", sqlCon);
                sqlCmd.Parameters.AddWithValue("@Catname", pCatType.ToLower());
                sqlCmd.Parameters.AddWithValue("@Keyword", pKeyword);
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
        /// for inserting mobile app setings
        /// </summary>
        /// <param name="pSettingID">settings id</param>
        /// <param name="pPSettingsValue">settings value</param>
        /// <param name="pUserID">userid</param>
        /// <param name="pEnableMobileApp">enable mobile app</param>
        /// <param name="id">id</param>
        /// <param name="pEmergencyNumber">emergency number</param>
        /// <param name="pAlternatePH">alternateph</param>
        /// <returns>integer</returns>
        public static int InsertMobileAppSettings(int pSettingID, string pPSettingsValue, int pUserID, bool pEnableMobileApp,
          int id, string pEmergencyNumber, string pAlternatePH)
        {
            int settingID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_M_Insert_Update_Settings", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@M_SettingID", pSettingID);
                sqlCmd.Parameters.AddWithValue("@M_SettingValue", pPSettingsValue);
                sqlCmd.Parameters.AddWithValue("@User_ID", pUserID);
                sqlCmd.Parameters.AddWithValue("@EnableMobileApp", pEnableMobileApp);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.Parameters.AddWithValue("@Emergency_Number", pEmergencyNumber);
                sqlCmd.Parameters.AddWithValue("@AlternatePhone", pAlternatePH);
                settingID = Convert.ToInt32(sqlCmd.ExecuteScalar());
                return settingID;

            }
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
