using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UserFormsDAL;

namespace UserFormsBLL
{
    public class AddOnBLL
    {
        CommonBLL objCommon = new CommonBLL();
        /// <summary>
        /// retrieving custom module by custom module id
        /// </summary>
        /// <param name="customModuleId">customModuleId</param>
        /// <returns>datatable</returns>
        public DataTable GetAddOnById(int customModuleId)
        {
            return AddOnDAL.GetAddOnById(customModuleId);
        }
        /// <summary>
        /// inserting updated item
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
        public int AddUpdateItem(int profileID, int userID, int cUserID, int customID, int customModuleId, int moduleID, string bulletinTitle, string bulletinHtml, string bulletinXml,
           bool isArchive, bool isCall, bool isPhotoCapture, bool isContactUs, DateTime? expiryDate, bool isPublished, DateTime? publishDate, int? publishedBy, string categoryName,
           string printerHtml = "", string customXML = "", string listDescription = "")
        {
            if (customXML == null)
            {
                customXML = "";
            }

            // Get Shorten Url from Long Url
            bulletinHtml = objCommon.ReplaceShortURltoHtmlString(bulletinHtml);


            int returnID = AddOnDAL.AddUpdateItem(profileID, userID, cUserID, customID, customModuleId, moduleID, bulletinTitle, bulletinHtml, bulletinXml,
                  isArchive, isCall, isPhotoCapture, isContactUs, expiryDate, isPublished, publishDate, publishedBy,categoryName, printerHtml, customXML, listDescription);

            #region MyRegion Update Long URL to Short URL

            if (customID == 0)
            {
                string outerURL = objCommon.GetConfigSettings(Convert.ToString(profileID), "Paths", "RootPath");
                string bulletinURL = outerURL + "/OnlineItem.aspx?CMID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(returnID)).Replace("=", "irhmalli").Replace("+", "irhPASS");

                bulletinURL = objCommon.longurlToshorturl(bulletinURL);
                CommonDAL.UpdateShortenURl(returnID, bulletinURL, "CUSTOMMODULE");
            }
            #endregion


            // Genarate App Thumb 
            objCommon.GenarateThumbnailForApp(returnID, profileID, "CustomModules", bulletinHtml);

            return returnID;
        }
        /// <summary>
        /// get bulletin details by moduleid
        /// </summary>
        /// <param name="moduleID">moduleID</param>
        /// <returns>data table</returns>
        public DataTable GetBulletinCustomDetails(int moduleID)
        {
            return AddOnDAL.GetBulletinCustomDetails(moduleID);
        }
        /// <summary>
        /// retrieving customm module details by custom id
        /// </summary>
        /// <param name="customID">customID</param>
        /// <returns>data table</returns>
        public DataTable GetCustomModuleByID(int customID)
        {
            return AddOnDAL.GetCustomModuleByID(customID);
        }
        
    }
}
