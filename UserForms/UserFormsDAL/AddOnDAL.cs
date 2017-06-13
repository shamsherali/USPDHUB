using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace UserFormsDAL
{
    public class AddOnDAL
    {
        /// <summary>
        /// for retrieving AddOn  by custom module id
        /// </summary>
        /// <param name="customModuleId">customModuleId</param>
        /// <returns>Table</returns>
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
        /// for retrieving custom module by cutomid
        /// </summary>
        /// <param name="customID">customid</param>
        /// <returns>datatable</returns>
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
        /// for adding updated item 
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userID">userID</param>
        /// <param name="cUserID">cUserID</param>
        /// <param name="customID">customID</param>
        /// <param name="customModuleId">customModuleId</param>
        /// <param name="moduleID">moduleID</param>
        /// <param name="bulletinTitle">bulletinTitle</param>
        /// <param name="bulletinHtml">bulletinHtml</param>
        /// <param name="bulletinXml">bulletinXml</param>
        /// <param name="isArchive">isArchive</param>
        /// <param name="isCall">isCall</param>
        /// <param name="isPhotoCapture">isPhotoCapture</param>
        /// <param name="isContactUs">isContactUs</param>
        /// <param name="expiryDate">expiryDate</param>
        /// <param name="isPublished">isPublished</param>
        /// <param name="publishDate">publishDate</param>
        /// <param name="publishedBy">publishedBy</param>
        /// <param name="printerHtml">printerHtml</param>
        /// <param name="customXML">customXML</param>
        /// <param name="listDescription">listDescription</param>
        /// <returns>integer</returns>
        public static int AddUpdateItem(int profileID, int userID, int cUserID, int customID, int customModuleId, int moduleID, string bulletinTitle, string bulletinHtml, string bulletinXml,
           bool isArchive, bool isCall, bool isPhotoCapture, bool isContactUs, DateTime? expiryDate, bool isPublished, DateTime? publishDate, int? publishedBy, string categoryName,
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
        /// retrieving bullitien details by custom module id
        /// </summary>
        /// <param name="moduleID">moduleID</param>
        /// <returns>Datatable</returns>
        public static DataTable GetBulletinCustomDetails(int moduleID)
        {
            DataTable dtBulletins = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("GetBulletinDetailsbyCustomModuleID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ModuleID", moduleID);
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
    }
}
