using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace UserFormsDAL
{
    public class BulletinDAL
    {
        /// <summary>
        /// for getting weekly crime report details by dates
        /// </summary>
        /// <param name="pFromDate">pFromDate</param>
        /// <param name="pToDate">pToDate</param>
        /// <param name="pPID">pPID</param>
        /// <param name="pStatus">pStatus</param>
        /// <returns>Table</returns>
        public static DataTable GetCrimeWeeklyReportsDetailsByDates(DateTime pFromDate, DateTime pToDate, int pPID, bool pStatus,bool pArchive)
        {
            DataTable dtCrimeReportDetails = new DataTable("dtCrime");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetCrimeDetailsReportsByDates", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FromDate", pFromDate);
                cmd.Parameters.AddWithValue("@ToDate", pToDate);
                cmd.Parameters.AddWithValue("@PID", pPID);
                cmd.Parameters.AddWithValue("@Status", pStatus);
                cmd.Parameters.AddWithValue("@IsArchive", pArchive);
                SqlDataAdapter adpter = new SqlDataAdapter(cmd);
                adpter.Fill(dtCrimeReportDetails);
                return dtCrimeReportDetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        /// <summary>
        /// getting all the region details by profile id
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pType">pType</param>
        /// <returns>Table</returns>
        public static DataTable GetAllRegionsByPID(int pProfileID, string pType)
        {
            DataTable dtRegions = new DataTable("regions");
            SqlConnection con = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetAllRegions", con);
                cmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                cmd.Parameters.AddWithValue("@Type", pType);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtRegions);
                return dtRegions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(con);
            }
        }
        /// <summary>
        /// retrieving officers details by region name
        /// </summary>
        /// <param name="pRegionName">regionname</param>
        /// <returns>datatable</returns>
        public static DataTable GetOfficersByRegionName(string pRegionName)
        {
            DataTable dtOfficer = new DataTable("officers");
            SqlConnection con = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_OfficersByRegionName", con);
                cmd.Parameters.AddWithValue("@Region_Name", pRegionName);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtOfficer);
                return dtOfficer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(con);
            }
        }
        /// <summary>
        /// retrieving caller agency details by profileid
        /// </summary>
        /// <param name="pProfileID">profileid</param>
        /// <returns>table</returns>
        public static DataTable GetCallerAgencyByPID(int pProfileID)
        {
            DataTable dtCallerAgency = new DataTable("calleragency");
            SqlConnection con = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetCallerTypeAgencyByProfileID", con);
                cmd.Parameters.AddWithValue("@ProfileID", pProfileID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtCallerAgency);
                return dtCallerAgency;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(con);
            }
        }
        /// <summary>
        /// retrieving officer types 
        /// </summary>
        /// <param name="pProfileID">profileid</param>
        /// <param name="DepartmentType">department type</param>
        /// <returns>table</returns>
        public static DataTable GetOfficerTypes(int pProfileID, string DepartmentType)
        {
            DataTable dtOfficerTypes = new DataTable("dtOfficerTypes");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetOfficerType", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PID", pProfileID);
                cmd.Parameters.AddWithValue("@DepartmentType", DepartmentType);
                SqlDataAdapter adpter = new SqlDataAdapter(cmd);
                adpter.Fill(dtOfficerTypes);
                return dtOfficerTypes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }

        }
        /// <summary>
        /// retrieving bulletien details by bulletin id
        /// </summary>
        /// <param name="pBulletinID">bulletinid</param>
        /// <returns>datatable</returns>
        public static DataTable GetBulletinDetailsByID(int pBulletinID)
        {
            DataTable dtBulletins = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetBulletinDetailsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Bulletin_ID", pBulletinID);
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
        /// for inserting and updating bulletin details
        /// </summary>
        /// <param name="pBulletinID">BulletinID</param>
        /// <param name="pTemplateBid">pTemplateBid</param>
        /// <param name="pBulletinTitle">pBulletinTitle</param>
        /// <param name="pBulletinHtml">pBulletinHtml</param>
        /// <param name="pBulletinXml">pBulletinXml</param>
        /// <param name="pCreatedUser">pCreatedUser</param>
        /// <param name="pModifyUser">pModifyUser</param>
        /// <param name="pIsArchive">pIsArchive</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pIsCall">pIsCall</param>
        /// <param name="pIsPhotoCapture">pIsPhotoCapture</param>
        /// <param name="pIsContactUs">pIsContactUs</param>
        /// <param name="pIsPrivate">pIsPrivate</param>
        /// <param name="pExpiryDate">pExpiryDate</param>
        /// <param name="pPublishDate">pPublishDate</param>
        /// <param name="category">category</param>
        /// <param name="isPublic">isPublic</param>
        /// <param name="publishedBy">publishedBy</param>
        /// <param name="printerHtml">printerHtml</param>
        /// <param name="pCustomXML">pCustomXML</param>
        /// <param name="pListDescription">pListDescription</param>
        /// <param name="pIsDesktopPOC">pIsDesktopPOC</param>
        /// <returns>integer</returns>
        public static int Insert_Update_BulletinDetails(int pBulletinID, int pTemplateBid, string pBulletinTitle, string pBulletinHtml, string pBulletinXml,
            int pCreatedUser, int pModifyUser, bool pIsArchive, int pUserID, int pProfileID, bool pIsCall, bool pIsPhotoCapture, bool pIsContactUs,
            bool pIsPrivate, DateTime? pExpiryDate, DateTime? pPublishDate, string category, bool isPublic, int? publishedBy, string printerHtml,
            string pCustomXML, string pListDescription, bool pIsDesktopPOC = false)
        {
            int bulletinID = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Insert_Update_BulletinDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Bulletin_ID", pBulletinID);
                sqlCmd.Parameters.AddWithValue("@Template_BID", pTemplateBid);
                sqlCmd.Parameters.AddWithValue("@Bulletin_Title", pBulletinTitle);
                sqlCmd.Parameters.AddWithValue("@Bulletin_HTML", pBulletinHtml);
                sqlCmd.Parameters.AddWithValue("@Bulletin_XML", pBulletinXml);
                sqlCmd.Parameters.AddWithValue("@Created_User", pCreatedUser);
                sqlCmd.Parameters.AddWithValue("@Modified_User", pModifyUser);
                sqlCmd.Parameters.AddWithValue("@IsArchive", pIsArchive);
                sqlCmd.Parameters.AddWithValue("@User_ID", pUserID);
                sqlCmd.Parameters.AddWithValue("@Profile_ID", pProfileID);
                sqlCmd.Parameters.AddWithValue("@IsCall", pIsCall);
                sqlCmd.Parameters.AddWithValue("@IsPhotoCapture", pIsPhotoCapture);
                sqlCmd.Parameters.AddWithValue("@IsContactUs", pIsContactUs);
                sqlCmd.Parameters.AddWithValue("@IsPrivate", pIsPrivate);
                sqlCmd.Parameters.AddWithValue("@Expiration_Date", pExpiryDate);
                sqlCmd.Parameters.AddWithValue("@Publish_Date", pPublishDate);
                sqlCmd.Parameters.AddWithValue("@Category", category);
                sqlCmd.Parameters.AddWithValue("@IsPublic", isPublic);
                sqlCmd.Parameters.AddWithValue("@Published_By", publishedBy);
                sqlCmd.Parameters.AddWithValue("@PrinterHtml", printerHtml);
                sqlCmd.Parameters.AddWithValue("@CustomXML", pCustomXML);
                sqlCmd.Parameters.AddWithValue("@ListDescription", pListDescription);
                sqlCmd.Parameters.AddWithValue("@IsDesktopPOC", pIsDesktopPOC);
                bulletinID = Convert.ToInt32(sqlCmd.ExecuteScalar());

                return bulletinID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        /// <summary>
        /// retrieving bulletins by id
        /// </summary>
        /// <param name="bulletinID">bulletin id</param>
        /// <returns>datatable</returns>
        public static DataTable GetBulletinByID(int bulletinID)
        {
            DataTable dtBulletin = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBulletinByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@BulletinID", bulletinID);
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
        /// retrieving label data of a bulletin
        /// </summary>
        /// <returns>datatable</returns>
        public static DataTable GetBulletinLabelData()
        {
            DataTable dtLabel = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetBulletinLabelData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(dtLabel);
                return dtLabel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        /// <summary>
        /// retreving template details of a bulletin
        /// </summary>
        /// <param name="pTemplateID">templateid</param>
        /// <returns>data table</returns>
        public static DataTable GetBulletinTemplateDetails(int pTemplateID)
        {
            DataTable dtBulletins = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("GetBulletinTemplateDetailsbyTemplateID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@TemplateID", pTemplateID);
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
        /// for checking bulletin
        /// </summary>
        /// <param name="userID">userid</param>
        /// <param name="bulletinName">bulletinname</param>
        /// <param name="templateBid">templatebid</param>
        /// <param name="type">type</param>
        /// <returns>datatable</returns>
        public static DataTable CheckBulletin(int userID, string bulletinName, int templateBid, string type)
        {
            DataTable dtBulletin = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_CheckBulletin", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@BulletinName", bulletinName);
                sqlCmd.Parameters.AddWithValue("@TemplateBID", templateBid);
                sqlCmd.Parameters.AddWithValue("@Type", type);
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

    }
}
