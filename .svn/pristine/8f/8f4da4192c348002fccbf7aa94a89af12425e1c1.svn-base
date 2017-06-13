using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserFormsDAL;
using System.Data;

namespace UserFormsBLL
{
    public class BulletinBLL
    {
        CommonBLL objCommon = new CommonBLL();

        /// <summary>
        /// retrieving weekly crime reports by dates
        /// </summary>
        /// <param name="pFromDate">from dates</param>
        /// <param name="pToDate">to date</param>
        /// <param name="pPID">pid</param>
        /// <param name="pStatus">status</param>
        /// <returns>data table</returns>
        public DataTable GetCrimeWeeklyReportsDetailsByDates(DateTime pFromDate, DateTime pToDate, int pPID, bool pStatus,bool pArchive)
        {
            return BulletinDAL.GetCrimeWeeklyReportsDetailsByDates(pFromDate, pToDate, pPID, pStatus, pArchive);

        }
        /// <summary>
        /// for retrieving the details of caller agency by profileid
        /// </summary>
        /// <param name="pProfileID">profileid</param>
        /// <returns>datatable</returns>
        public DataTable GetCallerAgencyByPID(int pProfileID)
        {
            return BulletinDAL.GetCallerAgencyByPID(pProfileID);
        }
        /// <summary>
        /// retrieva all regions by profile id
        /// </summary>
        /// <param name="pProfileID">profileid</param>
        /// <param name="pType">type</param>
        /// <returns>data table</returns>
        public DataTable GetAllRegionsByPID(int pProfileID, string pType)
        {
            return BulletinDAL.GetAllRegionsByPID(pProfileID, pType);
        }

        /// <summary>
        /// get the details of officers by region name
        /// </summary>
        /// <param name="pRegionName">region name</param>
        /// <returns>data table</returns>
        public DataTable GetOfficersByRegionName(string pRegionName)
        {
            return BulletinDAL.GetOfficersByRegionName(pRegionName);
        }
        /// <summary>
        /// retrieving the details of officers type
        /// </summary>
        /// <param name="pProfileID">profileid</param>
        /// <param name="DepartmentType">department type</param>
        /// <returns></returns>
        public DataTable GetOfficerTypes(int pProfileID, string DepartmentType)
        {
            return BulletinDAL.GetOfficerTypes(pProfileID, DepartmentType);
        }
        /// <summary>
        /// retrieves the bulletin details by bulletin id
        /// </summary>
        /// <param name="pBulletinID">bulletinid</param>
        /// <returns>datatable</returns>
        public DataTable GetBulletinDetailsByID(int pBulletinID)
        {
            return BulletinDAL.GetBulletinDetailsByID(pBulletinID);
        }
        /// <summary>
        /// for inserting and updating bulletin details by id
        /// </summary>
        /// <param name="pBulletinID">BulletinID</param>
        /// <param name="pTemplateBID">TemplateBID</param>
        /// <param name="pBulletinTitle">BulletinTitle</param>
        /// <param name="pBulletinHTML">BulletinHTML</param>
        /// <param name="pBulletinXML">BulletinXML</param>
        /// <param name="pCreatedUser">CreatedUser</param>
        /// <param name="pModifyUser">ModifyUser</param>
        /// <param name="pIsArchive">IsArchive</param>
        /// <param name="pUserID">UserID</param>
        /// <param name="pProfileID">ProfileID</param>
        /// <param name="pIsCall">IsCall</param>
        /// <param name="pIsPhotoCapture">IsPhotoCapture</param>
        /// <param name="pIsContactUs">IsContactUs</param>
        /// <param name="pIsPrivate">IsPrivate</param>
        /// <param name="pExpiryDate">ExpiryDate</param>
        /// <param name="pPublishDate">PublishDate</param>
        /// <param name="Category">Category</param>
        /// <param name="IsPublic">IsPublic</param>
        /// <param name="PublishedBy">PublishedBy</param>
        /// <param name="printerHtml">printerHtml</param>
        /// <param name="pCustomXML">CustomXML</param>
        /// <param name="pListDescription">ListDescription</param>
        /// <returns>integer</returns>
        public int Insert_Update_BulletinDetails(int pBulletinID, int pTemplateBID, string pBulletinTitle, string pBulletinHTML, string pBulletinXML,
            int pCreatedUser, int pModifyUser, bool pIsArchive, int pUserID, int pProfileID, bool pIsCall, bool pIsPhotoCapture, bool pIsContactUs,
            bool pIsPrivate, DateTime? pExpiryDate, DateTime? pPublishDate, string Category, bool IsPublic, int? PublishedBy,
            string printerHtml = "", string pCustomXML = "", string pListDescription = "")
        {
            if (pCustomXML == null)
            {
                pCustomXML = "";
            }

            // Get Shorten Url from Long Url
            pBulletinHTML = objCommon.ReplaceShortURltoHtmlString(pBulletinHTML);


            int BID = BulletinDAL.Insert_Update_BulletinDetails(pBulletinID, pTemplateBID, pBulletinTitle, pBulletinHTML, pBulletinXML, pCreatedUser, pModifyUser,
                pIsArchive, pUserID, pProfileID, pIsCall, pIsPhotoCapture, pIsContactUs, pIsPrivate, pExpiryDate, pPublishDate, Category, IsPublic,
                PublishedBy, printerHtml, pCustomXML, pListDescription);

            #region MyRegion Update Long URL to Short URL
            if (pBulletinID == 0)
            {
                // Update Long URL to Short URL
                string outerURL = objCommon.GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");
                string bulletinURL = outerURL + "/OnlineBulletin.aspx?BLID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(BID)).Replace("=", "irhmalli").Replace("+", "irhPASS");

                bulletinURL = objCommon.longurlToshorturl(bulletinURL);
                CommonDAL.UpdateShortenURl(BID, bulletinURL, "BULLETINS");
            }
            #endregion

            // Genarate App Thumb 
            objCommon.GenarateThumbnailForApp(BID, pProfileID, "Bulletins", pBulletinHTML);

            return BID;
        }

        /// <summary>
        /// gets the template details of bulletins
        /// </summary>
        /// <param name="pTemplateID">templateid</param>
        /// <returns>datatable</returns>
        public   DataTable GetBulletinTemplateDetails(int pTemplateID)
        {
            return BulletinDAL.GetBulletinTemplateDetails(pTemplateID);
        }
        /// <summary>
        /// for checking bulletin
        /// </summary>
        /// <param name="UserID">userid</param>
        /// <param name="BulletinName">bulletinname</param>
        /// <param name="TemplateBID">templatebid</param>
        /// <param name="Type">type</param>
        /// <returns>datatble</returns>
        public DataTable CheckBulletin(int UserID, string BulletinName, int TemplateBID, string Type)
        {
            return BulletinDAL.CheckBulletin(UserID, BulletinName, TemplateBID, Type);
        }
      

    }
}
