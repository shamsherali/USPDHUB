using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using USPDHUBDAL;
using System.Xml.Linq;
using System.IO;
using System.Web;
using System.Data.SqlClient;
using System.Net;
using System.Xml;
using System.Text.RegularExpressions;
using System.Drawing;
using Twilio;
using Winnovative.HtmlToPdfClient;

namespace USPDHUBBLL
{
    public class CommonBLL
    {
        public string ErrorMessage = "ERROR";
        /// <summary>
        /// Archive Selected News letter
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="archiveFlag">archiveFlag</param>
        /// <param name="module">module</param>
        /// <param name="userID">userID</param>
        public void ArchiveSelectedNewsletter(int id, bool archiveFlag, string module, int userID)
        {
            CommonDAL.ArchiveSelectedNewsletter(id, archiveFlag, module, userID);
        }

        /// <summary>
        /// Get Scheduled Count
        /// </summary>
        /// <param name="detailID">detailID</param>
        /// <param name="flag">flag</param>
        /// <returns>String</returns>
        public string GetScheduledCount(int detailID, int flag)
        {
            return CommonDAL.GetScheduledCount(detailID, flag);
        }

        /// <summary>
        /// Remaining Scheduled Emails Count
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="totalEmails">totalEmails</param>
        /// <param name="remainingEmailCount">remainingEmailCount</param>
        public void RemainingScheduledEmailsCount(int userID, int profileID, int totalEmails, out int remainingEmailCount)
        {
            CommonDAL.RemainingScheduledEmailsCount(userID, profileID, totalEmails, out remainingEmailCount);
        }

        /// <summary>
        /// Get contact group name for EmailID
        /// </summary>
        /// <param name="emailID">emailID</param>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetcontactgroupnameforEmailID(string emailID, int userID)
        {
            return CommonDAL.GetcontactgroupnameforEmailID(emailID, userID);
        }

        /// <summary>
        /// Add and Update Email Contacts
        /// </summary>
        /// <param name="firstname">firstname</param>
        /// <param name="lastname">lastname</param>
        /// <param name="email">email</param>
        /// <param name="address">address</param>
        /// <param name="phone">phone</param>
        /// <param name="description">description</param>
        /// <param name="userid">userid</param>
        /// <param name="schID">schID</param>
        /// <param name="emailType">emailType</param>
        /// <param name="contactID">contactID</param>
        public void AddandUpdateEmaiContacts(string firstname, string lastname, string email, string address, string phone, string description, int userid, int schID, string emailType, int contactID)
        {
            CommonDAL.AddandUpdateEmaiContacts(firstname, lastname, email, address, phone, description, userid, schID, emailType, contactID);
        }

        /// <summary>
        /// Select Email Contact
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="contactID">contactID</param>
        /// <returns>DataTable</returns>
        public DataTable SelectEmailContact(int userID, int contactID)
        {
            return CommonDAL.SelectEmailContact(userID, contactID);
        }

        /// <summary>
        /// Delete Email Contact
        /// </summary>
        /// <param name="contactID">contactID</param>
        /// <returns>Int</returns>
        public int DeleteEmailContact(int contactID)
        {
            return CommonDAL.DeleteEmailContact(contactID);
        }

        /// <summary>
        /// Get Email Contacts
        /// </summary>
        /// <param name="flag">flag</param>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetEmailContacts(bool flag, int userID)
        {
            return CommonDAL.GetEmailContacts(flag, userID);
        }


        public DataTable GetPublicCallAlerts(int profileID)
        {
            return CommonDAL.GetPublicCallAlerts(profileID);
        }
        /// <summary>
        /// getting private call history details
        /// </summary>
        /// <param name="profileID"></param>
        /// <returns></returns>
        public DataTable GetPrivateCallAlerts(int profileID)
        {
            return CommonDAL.GetPrivateCallAlerts(profileID);
        }
        /// <summary>
        /// Update User Tracking
        /// </summary>
        /// <param name="schHisID">schHisID</param>
        /// <param name="emailType">emailType</param>
        /// <param name="countryCode">countryCode</param>
        /// <param name="countryName">countryName</param>
        /// <param name="cityName">cityName</param>
        /// <param name="regionCode">regionCode</param>
        /// <param name="regionName">regionName</param>
        /// <param name="zipCode">zipCode</param>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <param name="ipAddress">ipAddress</param>
        /// <param name="browser">browser</param>
        public void UpdateUserTracking(int schHisID, string emailType, string countryCode, string countryName, string cityName, string regionCode, string regionName, string zipCode, string latitude, string longitude, string ipAddress, string browser)
        {
            CommonDAL.UpdateUserTracking(schHisID, emailType, countryCode, countryName, cityName, regionCode, regionName, zipCode, latitude, longitude, ipAddress, browser);
        }

        /// <summary>
        /// Get Bulletin Categories By Vertical
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetBulletinCategoriesByVertical(int profileID, bool? contentModule = false)
        {
            return CommonDAL.GetBulletinCategoriesByVertical(profileID, contentModule);
        }

        /// <summary>
        /// Get Domain Details
        /// </summary>
        /// <param name="verticalDomain">verticalDomain</param>
        /// <returns>DataTable</returns>
        public DataTable GetDomainDetails(string verticalDomain)
        {
            return CommonDAL.GetDomainDetails(verticalDomain);
        }

        /// <summary>
        /// Get Vertical Configs By Type
        /// </summary>
        /// <param name="vertical">vertical</param>
        /// <param name="type">type</param>
        /// <returns>DataTable</returns>
        public DataTable GetVerticalConfigsByType(string vertical, string type)
        {
            return CommonDAL.GetVerticalConfigsByType(vertical, type);
        }

        /// <summary>
        /// Get Custom Form Header
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>String</returns>
        public string GetCustomFormHeader(int userID)
        {
            return CommonDAL.GetCustomFormHeader(userID);
        }

        /// <summary>
        /// Get Vertical Domain
        /// </summary>
        /// <param name="vertical">vertical</param>
        /// <returns>String</returns>
        public string GetVerticalDomain(string vertical)
        {
            return CommonDAL.GetVerticalDomain(vertical);
        }

        /// <summary>
        /// Get Domain Name By Country
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>String</returns>
        public string GetDomainNameByCountry(int userID)
        {
            return CommonDAL.GetDomainNameByCountry(userID);
        }

        /// <summary>
        /// Get Domain Name By Country Vertical
        /// </summary>
        /// <param name="vertical">vertical</param>
        /// <param name="country">country</param>
        /// <returns>String</returns>
        public string GetDomainNameByCountryVertical(string vertical, string country)
        {
            return CommonDAL.GetDomainNameByCountryVertical(vertical, country);
        }

        /// <summary>
        /// Get Content Items
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetContentItems()
        {
            return CommonDAL.GetContentItems();
        }

        /// <summary>
        /// Update Shorten URl
        /// </summary>
        /// <param name="insertedID">insertedID</param>
        /// <param name="shortenUrl">shortenUrl</param>
        /// <param name="type">type</param>
        public void UpdateShortenURl(int insertedID, string shortenUrl, string type)
        {
            CommonDAL.UpdateShortenURl(insertedID, shortenUrl, type);
        }

        /// <summary>
        /// Get Schedule Date In PST
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="dateScheduled">dateScheduled</param>
        /// <returns>DateTime</returns>
        public DateTime GetScheduleDateInPST(int profileID, DateTime dateScheduled)
        {
            return CommonDAL.GetScheduleDateInPST(profileID, dateScheduled);
        }

        /// <summary>
        /// Insert Update Auto Share Details
        /// </summary>
        /// <param name="contentType">contentType</param>
        /// <param name="contentID">contentID</param>
        /// <param name="send_Status">send_Status</param>
        /// <param name="send_Date">send_Date</param>
        /// <param name="media_Type">media_Type</param>
        /// <param name="userID">userID</param>
        /// <param name="createdUserId">createdUserId</param>
        /// <param name="contentTitle">contentTitle</param>
        public void InsertUpdateAutoShareDetails(string contentType, int contentID, int send_Status, DateTime send_Date, string media_Type, int userID, int createdUserId, string contentTitle)
        {
            EventCalendarDAL.InsertUpdateAutoShareDetails(contentType, contentID, send_Status, send_Date, media_Type, userID, createdUserId, contentTitle);
        }

        /// <summary>
        /// Update Sent Flag
        /// </summary>
        /// <param name="contentId">contentId</param>
        /// <param name="flag">flag</param>
        /// <param name="existingFlag">existingFlag</param>
        /// <param name="contentType">contentType</param>
        public void UpdateSentFlag(int contentId, int flag, int existingFlag, string contentType)
        {
            EventCalendarDAL.UpdateSentFlag(contentId, flag, existingFlag, contentType);
        }

        /// <summary>
        /// Check Auto Share Record Exists
        /// </summary>
        /// <param name="contentType">contentType</param>
        /// <param name="contentId">contentId</param>
        /// <param name="contentTitle">contentTitle</param>
        /// <returns>DataTable</returns>
        public DataTable CheckAutoShareRecordExists(string contentType, int contentId, string contentTitle)
        {
            return CommonDAL.CheckAutoShareRecordExists(contentType, contentId, contentTitle);
        }

        /// <summary>
        /// Get Player Video By Id
        /// </summary>
        /// <param name="videoId">videoId</param>
        /// <returns>String</returns>
        public string GetPlayerVideoById(int videoId)
        {
            return CommonDAL.GetPlayerVideoById(videoId);
        }

        /// <summary>
        /// Update Display Order Type
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pUserModuleID">pUserModuleID</param>
        /// <param name="pDispalyOrderType">pDispalyOrderType</param>
        /// <param name="pButtonType">pButtonType</param>
        public void UpdateDisplayOrderType(int pProfileID, int pUserModuleID, int pDispalyOrderType, string pButtonType)
        {
            CommonDAL.UpdateDisplayOrderType(pProfileID, pUserModuleID, pDispalyOrderType, pButtonType);
        }


        /// <summary>
        /// Get Help Search Details
        /// </summary>
        /// <param name="helpName">helpName</param>
        /// <returns>List</returns>

        public List<string> GetHelpSearchDetails(string helpName, bool isLiteVersion)
        {
            return CommonDAL.GetHelpSearchDetails(helpName, isLiteVersion);
        }

        /// <summary>
        /// Get Help Name By ID
        /// </summary>
        /// <param name="helpId">helpId</param>
        /// <returns>String</returns>
        public string GetHelpNameByID(int helpId)
        {
            return CommonDAL.GetHelpNameByID(helpId);
        }

        /// <summary>
        /// Get App Default Data For Web
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="isAll">isAll</param>
        /// <param name="searchTypes">searchTypes</param>
        /// <returns>DataTable</returns>
        public DataTable GetAppDefaultDataForWeb(int profileId, bool isAll, string searchTypes)
        {
            return CommonDAL.GetAppDefaultDataForWeb(profileId, isAll, searchTypes);
        }

        /// <summary>
        /// Add Profile Access Types
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="messageType">messageType</param>
        /// <param name="userId">userId</param>
        /// <param name="profileId">profileId</param>
        /// <param name="createdUser">createdUser</param>
        public void AddProfileAccessTypes(string message, string messageType, int userId, int profileId, int createdUser)
        {
            CommonDAL.AddProfileAccessTypes(message, messageType, userId, profileId, createdUser);
        }

        /// <summary>
        /// Get Profile Access Types
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="messagetype">messagetype</param>
        /// <returns>DataTable</returns>
        public DataTable GetProfileAccessTypes(int profileId, string messagetype)
        {
            return CommonDAL.GetProfileAccessTypes(profileId, messagetype);
        }

        /// <summary>
        /// Check User Profile Image
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="imgName">imgName</param>
        /// <returns>Boolean</returns>
        public bool CheckUserProfileImage(int profileId, string imgName)
        {
            return CommonDAL.CheckUserProfileImage(profileId, imgName);
        }

        /// <summary>
        /// Insert User Profile Image
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="userId">userId</param>
        /// <param name="createdUser">createdUser</param>
        /// <param name="imgPath">imgPath</param>
        /// <param name="imgName">imgName</param>
        /// <param name="imgDimension">imgDimension</param>
        public void InsertUserProfileImage(int profileId, int userId, int createdUser, string imgPath, string imgName, string imgDimension)
        {
            CommonDAL.InsertUserProfileImage(profileId, userId, createdUser, imgPath, imgName, imgDimension);
        }

        /// <summary>
        /// Get User Profile Images
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="searchImage">searchImage</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserProfileImages(int profileId, string searchImage)
        {
            return CommonDAL.GetUserProfileImages(profileId, searchImage);
        }

        /// <summary>
        /// Delete User Profile Image
        /// </summary>
        /// <param name="imageId">imageId</param>
        /// <param name="modifiedUser">modifiedUser</param>
        public void DeleteUserProfileImage(int imageId, int modifiedUser)
        {
            CommonDAL.DeleteUserProfileImage(imageId, modifiedUser);
        }

        /// <summary>
        /// Get Call Module Profile Images
        /// </summary>
        /// <param name="userModuleId">userModuleId</param>
        /// <param name="searchImage">searchImage</param>
        /// <returns>DataTable</returns>
        public DataTable GetCallModuleProfileImages(int userModuleId, string searchImage)
        {
            return CommonDAL.GetCallModuleProfileImages(userModuleId, searchImage);
        }

        /// <summary>
        /// Check Call Module Profile Image
        /// </summary>
        /// <param name="usermoduleId">usermoduleId</param>
        /// <param name="imgName">imgName</param>
        /// <returns>Boolean</returns>
        public bool CheckCallModuleProfileImage(int usermoduleId, string imgName)
        {
            return CommonDAL.CheckCallModuleProfileImage(usermoduleId, imgName);
        }

        /// <summary>
        /// Insert Call Module Profile Image
        /// </summary>
        /// <param name="usermoduleId">usermoduleId</param>
        /// <param name="profileId">profileId</param>
        /// <param name="userId">userId</param>
        /// <param name="createdUser">createdUser</param>
        /// <param name="imgPath">imgPath</param>
        /// <param name="imgName">imgName</param>
        /// <param name="imgDimension">imgDimension</param>
        public void InsertCallModuleProfileImage(int usermoduleId, int profileId, int userId, int createdUser, string imgPath, string imgName, string imgDimension)
        {
            CommonDAL.InsertCallModuleProfileImage(usermoduleId, profileId, userId, createdUser, imgPath, imgName, imgDimension);
        }

        /// <summary>
        /// Delete Call Module Profile Image
        /// </summary>
        /// <param name="imageId">imageId</param>
        /// <param name="modifiedUser">modifiedUser</param>
        public void DeleteCallModuleProfileImage(int imageId, int modifiedUser)
        {
            CommonDAL.DeleteCallModuleProfileImage(imageId, modifiedUser);
        }

        /// <summary>
        /// Add Call Module Default Images
        /// </summary>
        /// <param name="userModuleID">userModuleID</param>
        /// <param name="profileId">profileId</param>
        /// <param name="userID">userID</param>
        /// <param name="cUserID">cUserID</param>
        public void AddCallModuleDefaultImages(int userModuleID, int profileId, int userID, int cUserID, string pModuleType)
        {
            CommonDAL.AddCallModuleDefaultImages(userModuleID, profileId, userID, cUserID, pModuleType);
        }
        public string GetTabNameByType(int userId, string tabType)
        {
            return CommonDAL.GetTabNameByType(userId, tabType);
        }
        #region
        /// <summary>
        /// Get Header For Bulletin Flyer
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="profileID">profileID</param>
        /// <returns>String</returns>
        public string GetHeaderForBulletinFlyer(int userID, int profileID)
        {
            string address = string.Empty;
            string xmlSettings = string.Empty;
            string strHeader = "";
            string strfilepath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\BulletinFlyerHeader.txt";
            System.IO.StreamReader re = System.IO.File.OpenText(strfilepath);
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                strHeader = strHeader + input;
            }
            re.Close();
            string RootPath = "";
            if (System.Web.HttpContext.Current.Session["RootPath"] == null)
            {
                System.Web.HttpContext.Current.Session["RootPath"] = GetConfigSettings(profileID.ToString(), "Paths", "RootPath");
            }
            RootPath = System.Web.HttpContext.Current.Session["RootPath"].ToString();
            strHeader = strHeader.Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);
            DataTable dtProfile = BusinessDAL.GetProfileDetailsByProfileID(profileID);
            if (dtProfile.Rows.Count > 0)
            {
                DataTable dtMobileAppSettings = USPDHUBDAL.MobileAppSettings.GetMobileAppSetting(userID);
                if (dtMobileAppSettings.Rows.Count > 0)
                {
                    InBuiltDataBLL objInbuilt = new InBuiltDataBLL();
                    xmlSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                    var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);

                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_name"].ToString()) && Convert.ToBoolean(xmlTools.Element("Tools").Attribute("BName").Value) == true)
                        strHeader = strHeader.Replace("#BusinessProfileName#", dtProfile.Rows[0]["Profile_name"].ToString());
                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_logo_path"].ToString()) && Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Logo").Value) == true)
                        strHeader = strHeader.Replace("#HeaderLogo#", objInbuilt.GetLogoPath(dtProfile.Rows[0]["Profile_logo_path"].ToString(), RootPath, profileID));
                    if (xmlTools.Element("Tools").Attribute("IsEmergencyNumber") != null)
                    {
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsEmergencyNumber").Value) == true)
                        {
                            strHeader = strHeader.Replace("#EmergencyNumber#", Convert.ToString(xmlTools.Element("Tools").Attribute("EmergencyNumber").Value));
                        }
                    }
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Address").Value))
                    {
                        address = dtProfile.Rows[0]["Profile_StreetAddress1"].ToString();
                        if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_StreetAddress2"].ToString()))
                            address += "," + dtProfile.Rows[0]["Profile_StreetAddress2"].ToString();
                    }
                    string city = "";
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("City").Value))
                        city = address += "<br/>" + dtProfile.Rows[0]["Profile_City"].ToString();
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("State").Value))
                    {
                        if (city == "")
                            address += "<br/>" + dtProfile.Rows[0]["Profile_State"].ToString();
                        else
                            address += ", " + dtProfile.Rows[0]["Profile_State"].ToString();
                    }
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("ZipCode").Value))
                        address += " " + dtProfile.Rows[0]["Profile_Zipcode"].ToString();
                }
            }
            strHeader = strHeader.Replace("#HeaderLogo#", "").Replace("#BusinessProfileName#", "").Replace("#EmergencyNumber#", "").Replace("#AgencyAddress#", address);
            re.Dispose();
            return strHeader;
        }

        /// <summary>
        /// Get Header For Bulletin PDF Print
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="IsWeeklyReport">IsWeeklyReport</param>
        /// <returns>String</returns>
        public string GetHeaderForBulletinPDFPrint(int userID, int profileID, bool IsWeeklyReport)
        {
            string address = string.Empty;
            string xmlSettings = string.Empty;
            string strHeader = "";
            string strfilepath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\CommonHeaderPDFPrint.txt";
            System.IO.StreamReader re = System.IO.File.OpenText(strfilepath);
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                strHeader = strHeader + input;
            }
            re.Close();
            string RootPath = "";
            if (System.Web.HttpContext.Current.Session["RootPath"] == null)
            {
                System.Web.HttpContext.Current.Session["RootPath"] = GetConfigSettings(profileID.ToString(), "Paths", "RootPath");
            }
            RootPath = System.Web.HttpContext.Current.Session["RootPath"].ToString();
            strHeader = strHeader.Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);
            DataTable dtProfile = BusinessDAL.GetProfileDetailsByProfileID(profileID);
            if (dtProfile.Rows.Count > 0)
            {
                DataTable dtMobileAppSettings = USPDHUBDAL.MobileAppSettings.GetMobileAppSetting(userID);
                if (dtMobileAppSettings.Rows.Count > 0)
                {
                    InBuiltDataBLL objInbuilt = new InBuiltDataBLL();
                    xmlSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                    var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);

                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_name"].ToString()) && Convert.ToBoolean(xmlTools.Element("Tools").Attribute("BName").Value) == true)
                        strHeader = strHeader.Replace("#BusinessProfileName#", dtProfile.Rows[0]["Profile_name"].ToString());
                    if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_logo_path"].ToString()) && Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Logo").Value) == true)
                        strHeader = strHeader.Replace("#HeaderLogo#", objInbuilt.GetLogoPath(dtProfile.Rows[0]["Profile_logo_path"].ToString(), RootPath, profileID));
                    if (xmlTools.Element("Tools").Attribute("IsEmergencyNumber") != null)
                    {
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsEmergencyNumber").Value) == true)
                        {
                            strHeader = strHeader.Replace("#EmergencyNumber#", Convert.ToString(xmlTools.Element("Tools").Attribute("EmergencyNumber").Value));
                        }
                    }
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Address").Value))
                    {
                        address = dtProfile.Rows[0]["Profile_StreetAddress1"].ToString();
                        if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_StreetAddress2"].ToString()))
                            address += "," + dtProfile.Rows[0]["Profile_StreetAddress2"].ToString();
                    }
                    string city = "";
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("City").Value))
                        city = address += "<br/>" + dtProfile.Rows[0]["Profile_City"].ToString();
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("State").Value))
                    {
                        if (city == "")
                            address += "<br/>" + dtProfile.Rows[0]["Profile_State"].ToString();
                        else
                            address += ", " + dtProfile.Rows[0]["Profile_State"].ToString();
                    }
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("ZipCode").Value))
                        address += " " + dtProfile.Rows[0]["Profile_Zipcode"].ToString();
                }
            }

            //Additional Logo
            string additionalLogoPath = RootPath + "/Upload/AdditionalLogos/" + profileID + "/" + profileID + ".jpg";

            string folderPath = System.Web.HttpContext.Current.Server.MapPath("/Upload/AdditionalLogos/" + profileID + "/" + profileID + ".jpg");
            if (File.Exists(folderPath) && IsWeeklyReport == true)
            {
                strHeader = strHeader.Replace("#AdditionalLogo#", "<img src='" + additionalLogoPath + "' border='0'  />");
            }
            else
            {
                strHeader = strHeader.Replace("#AdditionalLogo#", "");
            }

            strHeader = strHeader.Replace("#HeaderLogo#", "").Replace("#BusinessProfileName#", "").Replace("#EmergencyNumber#", "").Replace("#AgencyAddress#", address);
            re.Dispose();
            return strHeader;

        }
        /// <summary>
        /// Header for ALL Bulletins
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="IsWeeklyReport">IsWeeklyReport</param>
        /// <returns>String</returns>
        public string GetHeaderForBulletins(int userID, int profileID, bool IsWeeklyReport = false)
        {
            string address = string.Empty;
            string xmlSettings = string.Empty;
            string strHeader = "";
            string strfilepath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\CommonHeader.txt";
            System.IO.StreamReader re = System.IO.File.OpenText(strfilepath);
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                strHeader = strHeader + input;
            }
            re.Close();
            string RootPath = "";
            if (System.Web.HttpContext.Current.Session["RootPath"] == null)
            {
                System.Web.HttpContext.Current.Session["RootPath"] = GetConfigSettings(profileID.ToString(), "Paths", "RootPath");
            }
            RootPath = System.Web.HttpContext.Current.Session["RootPath"].ToString();
            strHeader = strHeader.Replace("#RootPath#", RootPath).Replace("#OuterRootUrl#", RootPath);

            //Additional Logo
            string additionalLogoPath = RootPath + "/Upload/AdditionalLogos/" + profileID + "/" + profileID + ".jpg";

            string folderPath = System.Web.HttpContext.Current.Server.MapPath("/Upload/AdditionalLogos/" + profileID + "/" + profileID + ".jpg");
            if (File.Exists(folderPath) && IsWeeklyReport == true)
            {
                strHeader = strHeader.Replace("#AdditionalLogo#", "<img src='" + additionalLogoPath + "' border='0'  />");
            }
            else
            {
                strHeader = strHeader.Replace("#AdditionalLogo#", "");
            }


            DataTable dtProfile = BusinessDAL.GetProfileDetailsByProfileID(profileID);
            if (dtProfile.Rows.Count > 0)
            {
                bool IsShortLogo = Convert.ToBoolean(dtProfile.Rows[0]["IsShortLogo"]);
                DataTable dtMobileAppSettings = USPDHUBDAL.MobileAppSettings.GetMobileAppSetting(userID);
                if (dtMobileAppSettings.Rows.Count > 0)
                {
                    InBuiltDataBLL objInbuilt = new InBuiltDataBLL();
                    xmlSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                    var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);

                    if (IsShortLogo)
                    {
                        if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_name"].ToString()) && Convert.ToBoolean(xmlTools.Element("Tools").Attribute("BName").Value) == true)
                            strHeader = strHeader.Replace("#BusinessProfileName#", dtProfile.Rows[0]["Profile_name"].ToString());
                        if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_logo_path"].ToString()) && Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Logo").Value) == true)
                            strHeader = strHeader.Replace("#HeaderLogo#", objInbuilt.GetLogoPath(dtProfile.Rows[0]["Profile_logo_path"].ToString(), RootPath, profileID));
                        if (xmlTools.Element("Tools").Attribute("IsEmergencyNumber") != null)
                        {
                            if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsEmergencyNumber").Value) == true)
                            {
                                strHeader = strHeader.Replace("#EmergencyNumber#", Convert.ToString(xmlTools.Element("Tools").Attribute("EmergencyNumber").Value));
                            }
                        }
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Address").Value))
                        {
                            address = dtProfile.Rows[0]["Profile_StreetAddress1"].ToString();
                            if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_StreetAddress2"].ToString()))
                                address += "," + dtProfile.Rows[0]["Profile_StreetAddress2"].ToString();
                        }
                        string city = "";
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("City").Value))
                            city = address += "<br/>" + dtProfile.Rows[0]["Profile_City"].ToString();
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("State").Value))
                        {
                            if (city == "")
                                address += "<br/>" + dtProfile.Rows[0]["Profile_State"].ToString();
                            else
                                address += ", " + dtProfile.Rows[0]["Profile_State"].ToString();
                        }
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("ZipCode").Value))
                            address += " " + dtProfile.Rows[0]["Profile_Zipcode"].ToString();

                        strHeader = strHeader.Replace("#BusinessProfileName#", "").Replace("#EmergencyNumber#", "").Replace("#AgencyAddress#", address);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_logo_path"].ToString()) && Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Logo").Value) == true)
                        {
                            strHeader = strHeader.Replace("#HeaderLogo#", objInbuilt.GetLogoPath(dtProfile.Rows[0]["Profile_logo_path"].ToString(), RootPath, profileID, false, IsWeeklyReport));
                        }
                        else
                        {
                            strHeader = strHeader.Replace("#HeaderLogo#", "");
                        }
                        strHeader = strHeader.Replace("#BusinessProfileName#", "").Replace("#EmergencyNumber#", "").Replace("#AgencyAddress#", "");
                    }
                }

            }
            strHeader = strHeader.Replace("#LongLogoMargin#", "").Replace("#HeaderLogo#", "").Replace("#BusinessProfileName#", "").Replace("#EmergencyNumber#", "").Replace("#AgencyAddress#", address);
            re.Dispose();
            return strHeader;

        }

        /// <summary>
        /// Get Logo Header Text
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pRootPath">pRootPath</param>
        /// <returns>String</returns>
        public string GetLogoHeaderText(int pUserID, int pProfileID, string pRootPath)
        {
            string logoPath = "";
            string profileName = "";
            string address = "";
            DataTable dtProfile = BusinessDAL.GetProfileDetailsByProfileID(pProfileID);
            string logourl = Convert.ToString(dtProfile.Rows[0]["Profile_logo_path"]);

            #region Logo Details
            string originalfilename = logourl;
            string extension = System.IO.Path.GetExtension(HttpContext.Current.Server.MapPath(originalfilename));
            string junk = ".";
            string[] ret = originalfilename.Split(junk.ToCharArray());
            string thumbimg1 = ret[0];
            thumbimg1 = thumbimg1 + "_thumb" + extension;
            string url = HttpContext.Current.Server.MapPath("~") + "\\Upload\\Logos\\" + pProfileID + "\\" + thumbimg1;
            FileInfo obj = new FileInfo(url);
            if (File.Exists(url))
            {
                if (obj.Exists)
                {
                    string imageDisID = Guid.NewGuid().ToString();
                    logoPath = pRootPath + "/Upload/Logos/" + pProfileID + "/" + thumbimg1 + "?Guid=" + imageDisID;
                }
                else
                {
                    string imageDisID = Guid.NewGuid().ToString();
                    logoPath = pRootPath + "/Upload/Logos/" + pProfileID + "/" + logourl + "?Guid=" + imageDisID;
                }
            }
            #endregion
            string strfilepath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\LogoHeaderText.txt";
            bool IsShortLogo = Convert.ToBoolean(dtProfile.Rows[0]["IsShortLogo"]);
            if (IsShortLogo)
            {
                address = GetBulletinFormHeader(pUserID, pProfileID);
                profileName = HttpContext.Current.Session["profilename"].ToString();
            }
            else
                strfilepath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\LongLogoHeaderText.txt";

            string strHeader = "";

            System.IO.StreamReader re = System.IO.File.OpenText(strfilepath);
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                strHeader = strHeader + input;
            }
            re.Dispose();
            re.Close();

            if (logoPath.Trim() != "")
            {
                logoPath = "<img src='" + logoPath + "' />";
            }
            strHeader = strHeader.Replace("#Logo#", logoPath);
            strHeader = strHeader.Replace("#ProfileName#", profileName).Replace("#ProfileAddress#", address);
            re.Dispose();
            return strHeader;
        }

        /// <summary>
        /// Get Bulletin Form Header
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="profileID">profileID</param>
        /// <returns>String</returns>
        public string GetBulletinFormHeader(int userID, int profileID)
        {
            string address = "";
            string xmlSettings = "";
            string header = "<span style=\"text-align: center;\">#AgencyAddress#</span><h4 style=\"font-size: 16px; line-height: 28px; font-weight: bold; color: #383838; text-align: center; margin: 0px; padding: 0px;\">#EmergencyNumber#</h4>";
            DataTable dtProfile = BusinessDAL.GetProfileDetailsByProfileID(profileID);
            if (dtProfile.Rows.Count > 0)
            {
                bool IsShortLogo = Convert.ToBoolean(dtProfile.Rows[0]["IsShortLogo"]);
                DataTable dtMobileAppSettings = USPDHUBDAL.MobileAppSettings.GetMobileAppSetting(userID);
                if (dtMobileAppSettings.Rows.Count > 0)
                {
                    if (IsShortLogo)
                    {
                        xmlSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                        var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                        if (xmlTools.Element("Tools").Attribute("IsEmergencyNumber") != null)
                        {
                            if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsEmergencyNumber").Value) == true)
                            {
                                header = header.Replace("#EmergencyNumber#", Convert.ToString(xmlTools.Element("Tools").Attribute("EmergencyNumber").Value));
                            }
                        }
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Address").Value))
                        {
                            address = dtProfile.Rows[0]["Profile_StreetAddress1"].ToString();
                            if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Profile_StreetAddress2"].ToString()))
                                address += "," + dtProfile.Rows[0]["Profile_StreetAddress2"].ToString();
                        }
                        string city = "";
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("City").Value))
                            city = address += "<br/>" + dtProfile.Rows[0]["Profile_City"].ToString();
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("State").Value))
                        {
                            if (city == "")
                                address += "<br/>" + dtProfile.Rows[0]["Profile_State"].ToString();
                            else
                                address += ", " + dtProfile.Rows[0]["Profile_State"].ToString();
                        }
                        if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("ZipCode").Value))
                            address += " " + dtProfile.Rows[0]["Profile_Zipcode"].ToString();
                    }
                    else
                    {
                        header = header.Replace("#EmergencyNumber#", "").Replace("#AgencyAddress#", address);
                    }
                }
            }
            header = header.Replace("#EmergencyNumber#", "").Replace("#AgencyAddress#", address);
            return header;
        }

        /// <summary>
        /// Generate Random Password
        /// </summary>
        /// <returns>String</returns>
        public string GenerateRandomPassword()
        {
            string s = "";
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder randomText = new StringBuilder();
            Random r = new Random();
            for (int j = 0; j < 6; j++)
            {
                randomText.Append(alphabets[r.Next(alphabets.Length)]);
            }
            for (int i = 0; i < 10; i++)
                s = randomText.ToString();
            return s;
        }

        /// <summary>
        /// Copy Logo
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="logo">logo</param>
        /// <param name="inqueryId">inqueryId</param>
        /// <returns>String</returns>
        public string CopyLogo(int profileid, string logo, int inqueryId)
        {
            string logopath = string.Empty;
            try
            {
                string extension = System.IO.Path.GetExtension(System.Web.HttpContext.Current.Server.MapPath(logo));
                string junk = ".";
                string[] ret = logo.Split(junk.ToCharArray());
                string thumbimg1 = ret[0];
                thumbimg1 = thumbimg1 + "_thumb" + extension;
                string url = System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\Inquires\\" + inqueryId + "\\" + thumbimg1;

                string saveFilePath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload";
                string folderPath = string.Empty;
                folderPath = saveFilePath + "\\Logos\\" + profileid;
                string destFile = System.IO.Path.Combine(folderPath, thumbimg1);
                string destinationFile = System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\Logos\\" + profileid + "\\" + profileid + "_thumb" + extension;
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }
                if (System.IO.File.Exists(destFile))
                {
                    System.IO.File.Delete(destFile);
                }
                if (System.IO.File.Exists(destinationFile))
                {
                    System.IO.File.Delete(destinationFile);
                }
                System.IO.File.Copy(url, destFile);

                string source = System.Web.HttpContext.Current.Server.MapPath("~") + "\\Upload\\Logos\\" + profileid;

                string dFilePath = string.Empty;
                dFilePath = folderPath + "\\" + inqueryId + "_thumb" + extension;
                if (File.Exists(dFilePath))
                {
                    FileInfo fi = new FileInfo(dFilePath);
                    fi.MoveTo(source + "\\" + profileid + "_thumb" + extension);
                    logopath = profileid + extension;
                }

            }
            catch (Exception /*ex*/)
            {
            }
            return logopath;
        }

        /// <summary>
        /// Generate Invoice
        /// </summary>
        /// <param name="profileid">profileid</param>
        /// <param name="vertical">vertical</param>
        /// <param name="domainName">domainName</param>
        /// <returns>String</returns>
        public string GenerateInvoice(int profileid, string vertical, string domainName)
        {
            BusinessBLL objBus = new BusinessBLL();
            DataTable dtInvoiceOrderDetails = new DataTable();
            dtInvoiceOrderDetails = objBus.GetDetailInvoicebyProfileID(profileid);
            string savelocation = string.Empty;
            //string invoiceID = string.Empty;
            DataTable dtprofileName = new DataTable();
            dtprofileName = objBus.GetProfileDetailsByProfileID(profileid);
            string profileBusinessName = string.Empty;
            if (dtprofileName.Rows.Count > 0)
            {
                profileBusinessName = dtprofileName.Rows[0]["Profile_Name"].ToString();

            }
            StringBuilder strhtml = new StringBuilder();
            if (dtInvoiceOrderDetails.Rows.Count > 0)
            {
                DataTable dtUserDetails = new DataTable();
                dtUserDetails = objBus.GetUserDetailsByUserID(Convert.ToInt32(dtInvoiceOrderDetails.Rows[0]["User_ID"].ToString()));
                string subStartDate = string.Empty;
                string subEndDate = string.Empty;
                decimal discAmt = 0.00M;
                decimal totalAmount = 0.00M;
                decimal totalBalCalAmt = 0.00M;
                string tools = string.Empty;
                string domainwithoutext = CommonDAL.GetVerticalDomain(vertical);
                string FromEmailsupport = "";
                DataTable dtConfigsemails = CommonDAL.GetVerticalConfigsByType(domainName, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailSupport")
                            FromEmailsupport = row[1].ToString();
                    }
                }
                string RootPath = "";
                DataTable dtConfigsemails1 = CommonDAL.GetVerticalConfigsByType(domainName, "Paths");
                if (dtConfigsemails1.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails1.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            RootPath = row[1].ToString();
                    }
                }
                if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Subscription_EndDate"].ToString()))
                {
                    subEndDate = Convert.ToDateTime(dtInvoiceOrderDetails.Rows[0]["Subscription_EndDate"]).AddDays(-1).ToShortDateString();
                }
                subStartDate = Convert.ToDateTime(dtInvoiceOrderDetails.Rows[0]["Created_Date"]).ToShortDateString();
                tools = dtInvoiceOrderDetails.Rows[0]["Subscription_Package"].ToString();
                totalAmount = totalBalCalAmt = Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["Total_Amount"].ToString());

                string subtype = string.Empty;
                if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Discount_Amount"].ToString()))
                    discAmt = Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["Discount_Amount"].ToString());
                // *** Fix For IRH-63 05-02-2013 *** //
                subtype = "Subscription for " + tools;
                if (tools.ToLower().Contains("branded"))
                    subtype = "Annual Subscription for Branded App";
                else if (!string.IsNullOrEmpty(dtprofileName.Rows[0]["Parent_ProfileID"].ToString()))
                    subtype = "Annual Subscription for Sub-App";
                strhtml.Append("<html><head>");
                strhtml.Append("<link href=" + System.Web.HttpContext.Current.Server.MapPath("~").ToString() + "\\css\\wowzzy_general.css rel='stylesheet' type='text/css' />");
                strhtml.Append("</head><body >");
                string logo = System.Web.HttpContext.Current.Server.MapPath("~") + "/Images/VerticalLogos/" + domainName + "logo.png";
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='800px' height='500px' class='inputgrid'>");
                strhtml.Append("<tr><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
                strhtml.Append("<tr><td><img src='" + logo + "'/></td></tr>");
                strhtml.Append("</table>");
                strhtml.Append("</td></tr>");
                strhtml.Append("<tr><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='800px' height='500px' bgcolor='#F0F7EC'>");
                strhtml.Append("<tr><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='inputgrid'>");
                strhtml.Append("<tr bgcolor='#3B86D4'><td><b>" + domainwithoutext + " Invoice ID: " + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + "</b></td><td align='right'><b>Profile reference No: " + dtInvoiceOrderDetails.Rows[0]["Profile_ID"].ToString() + "</b></td></tr>");
                if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["PurchaseOrder_No"].ToString()))
                {
                    strhtml.Append("<tr bgcolor='#3B86D4'><td></td><td align='right'><b>Purchase Order No: " + dtInvoiceOrderDetails.Rows[0]["PurchaseOrder_No"].ToString() + "</b></td></tr>");
                }
                strhtml.Append("</table>");
                strhtml.Append("</td></tr>");
                strhtml.Append("<tr><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
                strhtml.Append("<tr><td align='top'>" + "To:" + "<BR><b>" + profileBusinessName + "</b><BR>" + dtUserDetails.Rows[0]["firstname"].ToString() + "&nbsp;" + dtUserDetails.Rows[0]["lastname"].ToString() + "<BR>" + dtUserDetails.Rows[0]["User_address1"].ToString() + "<BR>" + dtUserDetails.Rows[0]["user_city"].ToString() + "<BR>" + dtUserDetails.Rows[0]["user_state"].ToString() + "<BR>" + dtUserDetails.Rows[0]["user_country"].ToString() + "<BR>" + dtUserDetails.Rows[0]["user_zipcode"].ToString() + "</td></tr>");
                strhtml.Append("</table>");
                strhtml.Append("</td></tr>");
                strhtml.Append("<tr bgcolor='#F0F7EC'><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='inputgrid'>");
                strhtml.Append("<colgroup><col width='180px'/><col width='100px'/><col width='*'/><col width='120'/><col width='100'/></colgroup>");
                strhtml.Append("<tr bgcolor='#3B86D4'>" + "<td>Description</td>" + "<td style='width:100px;'>Invoice Date</td><td>Subscription Period</td>" + "<td align='right'></td>" + "<td>Amount</td></tr>");
                strhtml.Append("<tr bgcolor='#F0F7EC'>" + "<td>" + subtype + "</td>" + "<td>" + subStartDate + "</td><td>" + subStartDate + " - " + subEndDate + "</td>" + "<td></td><td align='right'>" + "&nbsp;$" + totalAmount + "</td></tr>");
                string invoiceTotal = dtInvoiceOrderDetails.Rows[0]["OrderBillable_Amt"].ToString();
                if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["OneTimeSetup_Fee"].ToString()))
                {
                    totalBalCalAmt += Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["OneTimeSetup_Fee"].ToString());
                    invoiceTotal = (Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["OrderBillable_Amt"].ToString()) + Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["OneTimeSetup_Fee"].ToString())).ToString();
                    strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td>" + "One time setup fee" + "</td>" + "<td bgcolor='#F0F7EC' align='right'>" + "-" + "$" + dtInvoiceOrderDetails.Rows[0]["OneTimeSetup_Fee"].ToString() + "</td></tr>");
                }
                if (discAmt > 0)
                {
                    strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td>" + "Discount Amount" + "</td>" + "<td bgcolor='#F0F7EC' align='right'>" + "-" + "$" + discAmt + "</td></tr>");
                    strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td></td><td bgcolor='#F0F7EC' align='right'>" + "-------------" + "</td></tr>");
                }

                strhtml.Append("<tr bgcolor='#3B86D4'><td></td><td></td><td></td><td>Billing Amount</td>" + "<td align='right'>" + "&nbsp;$" + invoiceTotal + "</td></tr>");
                decimal dueAmt = 0.00M;
                dueAmt = totalBalCalAmt - (Convert.ToDecimal(invoiceTotal) + discAmt);
                strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td>Balance Due</td>" + "<td align='right'>" + "&nbsp;$" + dueAmt + "</td></tr>");
                strhtml.Append("</table>");
                strhtml.Append("</td></tr>");
                strhtml.Append("</td></tr>");
                strhtml.Append("</table>");
                strhtml.Append("</table>");
                strhtml.Append("NOTE: If you have any questions regarding this invoice, please email " + FromEmailsupport);
                strhtml.Append("</body>");
                strhtml.Append("</html>");


                string filepath = System.Web.HttpContext.Current.Server.MapPath("~");

                string filename = filepath + "/temp/" + domainwithoutext + "_Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".html";

                string hmtlfileurl = RootPath + "/temp/" + domainwithoutext + "_Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".html";

                string pdffilename = filepath + "/temp/" + domainwithoutext + "_Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".pdf";

                string pdfilenameval = domainwithoutext + "_Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".pdf";

                //string pdffileurl = System.Configuration.ConfigurationManager.AppSettings.Get("RootPath") + "/temp/" + "USPDhub_Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".pdf";
                //invoiceID = dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString();
                //StreamWriter textwriter = new StreamWriter(filename);
                //textwriter.Write(strhtml);
                //textwriter.Close();

                //Convert into the PDF ...

                /*
                //set the license key
                //issue 264, 266
                LicensingManager.LicenseKey = ConfigurationManager.AppSettings.Get("pdfkeyval");

                //create a PDF document
                Document document = new Document();

                //optional settings for the PDF document like margins, compression level,
                //security options, viewer preferences, document information, etc
                document.CompressionLevel = CompressionLevel.NormalCompression;
                document.Margins = new Margins(10, 10, 0, 0);
                document.Security.CanPrint = true;
                document.Security.UserPassword = "";
                document.DocumentInformation.Author = "Logictree IT Solutions, Inc";
                document.ViewerPreferences.HideToolbar = false;


                //Add a first page to the document. The next pages will inherit the settings from this page 
                PdfPage page = document.Pages.AddNewPage(PageSize.A4, new Margins(10, 10, 0, 0), PageOrientation.Portrait);

                // the code below can be used to create a page with default settings A4, document margins inherited, portrait orientation

                //PdfPage page = document.Pages.AddNewPage();

                // add a font to the document that can be used for the texts elements 

                PdfFont font = document.Fonts.Add(new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 10, System.Drawing.GraphicsUnit.Point));

                // the result of adding an element to a PDF page

                AddElementResult addResult;

                // Get the specified location and size of the rendered content

                // A negative value for width and height means to auto determine

                // The auto determined width is the available width in the PDF page

                // and the auto determined height is the height necessary to render all the content

                float xLocation = 5;

                float yLocation = 5;

                float width = -1;

                float height = -1;

                // convert HTML to PDF

                HtmlToPdfElement htmlToPdfElement;

                // convert a URL to PDF

                //string urlToConvert = hmtlfileurl;

                //htmlToPdfElement = new HtmlToPdfElement((xLocation, yLocation, width, height, urlToConvert);

                htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, width, height, strhtml.ToString(), null);

                // add theHTML to PDF converter element to page
                addResult = page.AddElement(htmlToPdfElement);
                savelocation = System.Web.HttpContext.Current.Server.MapPath("~").ToString() + "\\Upload\\Invoices\\" + pdfilenameval;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                document.Save(savelocation);

                */
                savelocation = System.Web.HttpContext.Current.Server.MapPath("~").ToString() + "\\Upload\\Invoices\\" + pdfilenameval;
                try
                {
                    // New Logic azure htmml to pdf

                    // Get the server IP and port
                    String serverIP = ConfigurationManager.AppSettings.Get("Winnovative_serverIP");
                    uint serverPort = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("Winnovative_serverPort"));

                    // Create a HTML to PDF converter object with default settings
                    HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter(serverIP, serverPort);
                    htmlToPdfConverter.LicenseKey = ConfigurationManager.AppSettings.Get("WinnovativePDFKey");
                    htmlToPdfConverter.HtmlViewerWidth = 650;
                    //htmlToImageConverter.HtmlViewerHeight = 200;
                    htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = Winnovative.HtmlToPdfClient.PdfPageSize.A4;
                    htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;
                    htmlToPdfConverter.PdfDocumentOptions.LeftMargin = 10;
                    htmlToPdfConverter.PdfDocumentOptions.TopMargin = 10;

                    htmlToPdfConverter.NavigationTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Winnovative_NavigationTimeout"));
                    htmlToPdfConverter.ConversionDelay = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Winnovative_ConversionDelay"));

                    // The buffer to receive the generated PDF document
                    byte[] outPdfBuffer = null;
                    string baseUrl = "";

                    // Convert a HTML string with a base URL to a PDF document in a memory buffer
                    outPdfBuffer = htmlToPdfConverter.ConvertHtml(strhtml.ToString(), baseUrl);
                    System.IO.File.WriteAllBytes(savelocation, outPdfBuffer);
                }
                catch (Exception ex)
                {
                    //Error 
                    ErrorHandling("ERROR", "CommonBLL.aspx.cs", "GenerateInvoice()", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }

                // document.Save(System.Web.HttpContext.Current.Response, false, pdfilenameval);
            }
            return savelocation;
        }

        /// <summary>
        /// Create Invoice Report
        /// </summary>
        /// <param name="OrderID">OrderID</param>
        /// <param name="Vertical">Vertical</param>
        /// <param name="DomainName">DomainName</param>
        /// <returns>String</returns>
        public string CreateInvoiceReport(int OrderID, string Vertical, string DomainName)
        {
            BusinessBLL objBus = new BusinessBLL();
            string savelocation = string.Empty;
            DataTable dtInvoiceOrderDetails = new DataTable();
            dtInvoiceOrderDetails = objBus.GetOrderIDInvoice(OrderID);
            DataTable dtOrderDetails = new DataTable();
            dtOrderDetails = objBus.GetOrderDetailsByOrderID(OrderID);
            String strhtml = "";
            decimal paidAmount = Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["PaidAmount"].ToString());
            if (dtInvoiceOrderDetails.Rows.Count > 0)
            {
                DataTable dtUserDetails = new DataTable();
                dtUserDetails = objBus.GetUserDetailsByUserID(Convert.ToInt32(dtInvoiceOrderDetails.Rows[0]["User_ID"].ToString()));
                decimal discAmt = 0.00M;
                decimal totalAmount = 0.00M;
                decimal totalBalCalAmt = 0.00M;
                string tools = string.Empty;
                string domainwithoutext = CommonDAL.GetVerticalDomain(Vertical);
                string FromEmailsupport = "";
                DataTable dtConfigsemails = CommonDAL.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailSupport")
                            FromEmailsupport = row[1].ToString();
                    }
                }
                string RootPath = "";
                DataTable dtConfigsemails1 = CommonDAL.GetVerticalConfigsByType(DomainName, "Paths");
                if (dtConfigsemails1.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails1.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            RootPath = row[1].ToString();
                    }
                }
                // start Change Invoice UI Format 
                DataTable dtprofileName = new DataTable();
                dtprofileName = objBus.GetProfileDetailsByProfileID(Convert.ToInt32(dtInvoiceOrderDetails.Rows[0]["Profile_ID"].ToString()));
                string profileBusinessName = string.Empty;
                if (dtprofileName.Rows.Count > 0)
                {
                    profileBusinessName = dtprofileName.Rows[0]["Profile_Name"].ToString();
                }
                string billinginfo = "";
                if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Billing_FirstName"].ToString()))
                {
                    if (profileBusinessName != "")
                        billinginfo = profileBusinessName + "<br/>";
                    billinginfo = billinginfo + dtInvoiceOrderDetails.Rows[0]["Billing_FirstName"].ToString();
                    billinginfo = billinginfo + " " + dtInvoiceOrderDetails.Rows[0]["Billing_LastName"].ToString();
                    billinginfo = billinginfo + "<br/>" + dtInvoiceOrderDetails.Rows[0]["Billing_Address1"].ToString();
                    if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Billing_Address2"].ToString()))
                        billinginfo = billinginfo + ", " + dtInvoiceOrderDetails.Rows[0]["Billing_Address2"].ToString();
                    billinginfo = billinginfo + "<br/>" + dtInvoiceOrderDetails.Rows[0]["Billing_City"].ToString();
                    billinginfo = billinginfo + ", " + dtInvoiceOrderDetails.Rows[0]["Billing_State"].ToString();
                    billinginfo = billinginfo + " " + dtInvoiceOrderDetails.Rows[0]["Billing_Zipcode"].ToString();
                    billinginfo = billinginfo + " " + dtInvoiceOrderDetails.Rows[0]["Billing_Country"].ToString();
                    if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Billing_Phone"].ToString()))
                        billinginfo = billinginfo + "<br/>" + dtInvoiceOrderDetails.Rows[0]["Billing_Phone"].ToString();
                    if (!string.IsNullOrEmpty(dtInvoiceOrderDetails.Rows[0]["Billing_Email"].ToString()))
                        billinginfo = billinginfo + "<br/>" + dtInvoiceOrderDetails.Rows[0]["Billing_Email"].ToString();
                }

                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\";
                StreamReader re = File.OpenText(strfilepath + "InoviceFormat.txt");
                string invoice_htmlText = string.Empty;
                string content = string.Empty;

                while ((content = re.ReadLine()) != null)
                {
                    invoice_htmlText = invoice_htmlText + content;
                }

                invoice_htmlText = invoice_htmlText.Replace("#Logo#", RootPath + "/Images/Dashboard/logictree_logo.png");
                invoice_htmlText = invoice_htmlText.Replace("#BillingAddress#", billinginfo);
                string dueDate = "";
                if (Convert.ToString(dtInvoiceOrderDetails.Rows[0]["Created_Date"]) == string.Empty)
                {
                    invoice_htmlText = invoice_htmlText.Replace("#InvoiceDate#", "&nbsp;");
                }
                else
                {
                    invoice_htmlText = invoice_htmlText.Replace("#InvoiceDate#", Convert.ToDateTime(dtInvoiceOrderDetails.Rows[0]["Created_Date"]).ToString("MMMM dd, yyyy"));
                    dueDate = "Net 30 " + Convert.ToDateTime(dtInvoiceOrderDetails.Rows[0]["Created_Date"]).AddDays(30).ToShortDateString();
                }
                invoice_htmlText = invoice_htmlText.Replace("#InvoiceNumber#", dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString());
                invoice_htmlText = invoice_htmlText.Replace("#PONumber#", Convert.ToString(dtInvoiceOrderDetails.Rows[0]["PurchaseOrder_No"]));
                int ordersCount = 0;
                string orderDetailsHTML = "";
                for (int i = 0; i < dtOrderDetails.Rows.Count; i++)
                {
                    orderDetailsHTML = orderDetailsHTML + "<tr><td style='border-left: 1px solid black; font-weight:normal;'>" + dtOrderDetails.Rows[i]["Email_Description"].ToString() + "</td>";
                    if (ordersCount == 0)
                        orderDetailsHTML = orderDetailsHTML + "<td style='border-left: 1px solid black; border-right: 1px solid black; padding-right: 10px; font-weight:normal;'><table width='100%'><tr><td align='left'>$</td><td align='right'>" + dtOrderDetails.Rows[i]["Total_Amount"].ToString() + "</td></tr></table></td></tr>";
                    else
                        orderDetailsHTML = orderDetailsHTML + "<td align='right' style='border-left: 1px solid black;  border-right: 1px solid black; padding-right: 10px; font-weight:normal;'>" + dtOrderDetails.Rows[i]["Total_Amount"].ToString() + "</td></tr>";
                    ordersCount += 1;
                    if (!string.IsNullOrEmpty(dtOrderDetails.Rows[i]["Discount_Code"].ToString()))
                        orderDetailsHTML = orderDetailsHTML + "<tr><td style='border-left: 1px solid black; font-weight:normal;'>" + dtOrderDetails.Rows[i]["Discount_Code"].ToString() + "  discount</td><td align='right' style='border-left: 1px solid black; border-right: 1px solid black; padding-right: 10px; font-weight:normal;'>(" + dtOrderDetails.Rows[i]["Discount_Amount"].ToString() + ")</td></tr>";
                    //" + "<td align='right' style='border-left: 1px solid black; padding-right: 10px; font-weight:normal;'>$" + dtOrderDetails.Rows[i]["Discount_Amount"].ToString() + "</td><td align='right' style='border-left: 1px solid black; padding-right: 10px; border-right: 1px solid black; font-weight:normal;'>$" + dtOrderDetails.Rows[i]["Billable_Amount"].ToString() + "</td>
                    discAmt = discAmt + Convert.ToDecimal(dtOrderDetails.Rows[i]["Discount_Amount"].ToString());
                    totalAmount = totalAmount + Convert.ToDecimal(dtOrderDetails.Rows[i]["Total_Amount"].ToString());
                    totalBalCalAmt = totalBalCalAmt + Convert.ToDecimal(dtOrderDetails.Rows[i]["Billable_Amount"].ToString());
                }
                decimal dueAmt = totalBalCalAmt - paidAmount;
                if (dueAmt > 0)
                {
                    invoice_htmlText = invoice_htmlText.Replace("#DueDateTitle#", Convert.ToString(dtInvoiceOrderDetails.Rows[0]["DueDateTitle"]));
                    invoice_htmlText = invoice_htmlText.Replace("#DueDate#", dueDate);
                }
                else
                {
                    invoice_htmlText = invoice_htmlText.Replace("#DueDateTitle#", "");
                    invoice_htmlText = invoice_htmlText.Replace("#DueDate#", "");

                }
                invoice_htmlText = invoice_htmlText.Replace("#OrderDetailsRows#", orderDetailsHTML);
                invoice_htmlText = invoice_htmlText.Replace("#TotalBill#", totalBalCalAmt.ToString()); // *** totalAmount.ToString() *** //
                invoice_htmlText = invoice_htmlText.Replace("#PaidBill#", totalBalCalAmt.ToString());
                invoice_htmlText = invoice_htmlText.Replace("#BalanceBill#", dueAmt.ToString());

                re.Close();

                // final HTML Invoice Format
                strhtml = invoice_htmlText;

                // END Change Invoice UI Format 

                string filepath = System.Web.HttpContext.Current.Server.MapPath("~");

                string filename = filepath + "/temp/" + domainwithoutext + "_Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".html";

                string hmtlfileurl = RootPath + "/temp/" + domainwithoutext + "_Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".html";

                string pdffilename = filepath + "/temp/" + domainwithoutext + "_Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".pdf";

                string pdfilenameval = domainwithoutext + "_Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".pdf";

                //string pdffileurl = System.Configuration.ConfigurationManager.AppSettings.Get("RootPath") + "/temp/" + "USPDhub_Invoice_" + dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString() + ".pdf";
                //invoiceID = dtInvoiceOrderDetails.Rows[0]["SubscriptionType_ID"].ToString();
                //StreamWriter textwriter = new StreamWriter(filename);
                //textwriter.Write(strhtml);
                //textwriter.Close();

                //Convert into the PDF ...

                /*
                //set the license key
                //issue 264, 266
                LicensingManager.LicenseKey = ConfigurationManager.AppSettings.Get("pdfkeyval");

                //create a PDF document
                Document document = new Document();

                //optional settings for the PDF document like margins, compression level,
                //security options, viewer preferences, document information, etc
                document.CompressionLevel = CompressionLevel.NormalCompression;
                document.Margins = new Margins(10, 10, 0, 0);
                document.Security.CanPrint = true;
                document.Security.UserPassword = "";
                document.DocumentInformation.Author = "Logictree IT Solutions, Inc";
                document.ViewerPreferences.HideToolbar = false;


                //Add a first page to the document. The next pages will inherit the settings from this page 
                PdfPage page = document.Pages.AddNewPage(PageSize.A4, new Margins(10, 10, 0, 0), PageOrientation.Portrait);

                // the code below can be used to create a page with default settings A4, document margins inherited, portrait orientation

                //PdfPage page = document.Pages.AddNewPage();

                // add a font to the document that can be used for the texts elements 

                PdfFont font = document.Fonts.Add(new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 10, System.Drawing.GraphicsUnit.Point));

                // the result of adding an element to a PDF page

                AddElementResult addResult;

                // Get the specified location and size of the rendered content

                // A negative value for width and height means to auto determine

                // The auto determined width is the available width in the PDF page

                // and the auto determined height is the height necessary to render all the content

                float xLocation = 5;

                float yLocation = 5;

                float width = -1;

                float height = -1;

                // convert HTML to PDF

                HtmlToPdfElement htmlToPdfElement;

                // convert a URL to PDF

                //string urlToConvert = hmtlfileurl;

                //htmlToPdfElement = new HtmlToPdfElement((xLocation, yLocation, width, height, urlToConvert);

                htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, width, height, strhtml.ToString(), null);

                // add theHTML to PDF converter element to page
                addResult = page.AddElement(htmlToPdfElement);
                savelocation = System.Web.HttpContext.Current.Server.MapPath("~").ToString() + "\\Upload\\Invoices\\" + pdfilenameval;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                document.Save(savelocation);
                re.Dispose();
                 */

                savelocation = System.Web.HttpContext.Current.Server.MapPath("~").ToString() + "\\Upload\\Invoices\\" + pdfilenameval;
                try
                {
                    // New Logic azure htmml to pdf

                    // Get the server IP and port
                    String serverIP = ConfigurationManager.AppSettings.Get("Winnovative_serverIP");
                    uint serverPort = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("Winnovative_serverPort"));

                    // Create a HTML to PDF converter object with default settings
                    HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter(serverIP, serverPort);
                    htmlToPdfConverter.LicenseKey = ConfigurationManager.AppSettings.Get("WinnovativePDFKey");
                    htmlToPdfConverter.HtmlViewerWidth = 650;
                    //htmlToImageConverter.HtmlViewerHeight = 200;
                    htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = Winnovative.HtmlToPdfClient.PdfPageSize.A4;
                    htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;
                    htmlToPdfConverter.PdfDocumentOptions.LeftMargin = 10;
                    htmlToPdfConverter.PdfDocumentOptions.TopMargin = 10;

                    htmlToPdfConverter.NavigationTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Winnovative_NavigationTimeout"));
                    htmlToPdfConverter.ConversionDelay = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Winnovative_ConversionDelay"));

                    // The buffer to receive the generated PDF document
                    byte[] outPdfBuffer = null;
                    string baseUrl = "";

                    // Convert a HTML string with a base URL to a PDF document in a memory buffer
                    outPdfBuffer = htmlToPdfConverter.ConvertHtml(strhtml.ToString(), baseUrl);
                    System.IO.File.WriteAllBytes(savelocation, outPdfBuffer);
                }
                catch (Exception ex)
                {
                    //Error 
                    ErrorHandling("ERROR", "CommonBLL", "CreateInvoiceReport", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }
            }
            return savelocation;
        }

        /// <summary>
        /// Build Survey Preview
        /// </summary>
        /// <param name="surveyId">surveyId</param>
        /// <returns>String</returns>
        public string BuildSurveyPreview(int surveyId)
        {
            DataTable dtQuestion = SurveyDAL.GetQuestionsBySurveyID(surveyId);
            string previewHtml = "<html><head></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='border: solid 2px #F4EBEB;'>";
            for (int i = 0; i < dtQuestion.Rows.Count; i++)
            {
                string Question = dtQuestion.Rows[i]["Text"].ToString();
                previewHtml = previewHtml + "<table><tr><td><b>Q" + (i + 1) + ":</b> " + Question + "</td></tr>";
                DataTable dtOptions = SurveyDAL.GetQuestionOptionsByQID(Convert.ToInt32(dtQuestion.Rows[i]["Question_ID"]));
                for (int j = 0; j < dtOptions.Rows.Count; j++)
                {
                    string Answer = dtOptions.Rows[j]["Answer_Option"].ToString();
                    previewHtml = previewHtml + "<tr><td style='padding-left:30px;'><b>" + (j + 1) + ":</b> " + Answer + "</td></tr>";  //<tr><td colspan='2' style='padding:30px;'>" + previewHtml + "</td></tr></table>";
                }
                previewHtml = previewHtml + "</table>";
            }
            previewHtml = previewHtml + "</table></body></html>";
            return previewHtml;
        }

        /// <summary>
        /// Get Previlages
        /// </summary>
        /// <param name="dtpermissions">dtpermissions</param>
        /// <param name="pagename">pagename</param>
        /// <returns>Int</returns>
        public int GetPrevilages(DataTable dtpermissions, string pagename) //Roles & Permissions...
        {
            int returnval = 0;
            if (dtpermissions.Rows.Count > 0)
            {
                for (int i = 0; i < dtpermissions.Rows.Count; i++)
                {
                    if ((dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == "Bulletins") && pagename.ToLower().ToString() == PageNames.BULLETINS)
                        returnval = returnval + 1;
                    else if ((dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == "EventCalendar") && pagename.ToLower().ToString() == PageNames.EVENTS)
                        returnval = returnval + 1;
                    else if ((dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == "App Settings") && (pagename.ToLower().ToString() == PageNames.APPSETTINGS || pagename.ToLower().ToString() == PageNames.MESSAGES || pagename.ToLower().ToString() == PageNames.MEDIA))
                        returnval = returnval + 1;
                    else if ((dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == "Contacts") && pagename.ToLower().ToString() == PageNames.CONTACTS)
                        returnval = returnval + 1;
                    else if ((dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == "Manage Buttons") && pagename.ToLower().ToString() == PageNames.MBUTTONS)
                        returnval = returnval + 1;
                    else if ((dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == "Push Notifications") && pagename.ToLower().ToString() == PageNames.PUSHNOTIFICATIONS)
                        returnval = returnval + 1;
                    else if ((dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == "Surveys") && pagename.ToLower().ToString() == PageNames.SURVEYS)
                        returnval = returnval + 1;
                    else if ((dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == "Manage Message Receipt") && pagename.ToLower().ToString() == PageNames.BLOCKEDSENDERS)
                        returnval = returnval + 1;

                }
            }
            return returnval;
        }
#if fixme 
        // *** Fixed for JIRA 330 in 1.6. After that users getting issues, going email to author and published by is parent user instead of actual published userid. So, we are commenting this for referrence. *** //
        public string SendAuthorNotifications(string username, int bulletinID, string typeName, int userID, string pUsername, string pagename, string domainName) //Roles & Permissions...
        {
            string returnval = string.Empty;
            try
            {
                string ss = "SELECT a.Associate_ID,a.Permission_Type as Permission_Type,b.Username as Username,a.Permission_Values as Permission_Values FROM T_Associate_Permissions a, T_Users b WHERE a.Created_User=" + userID + " and a.Associate_ID=b.User_ID and Permission_Type='P' and Active_flag=1";
                SqlConnection sqlCon = USPDHUBDAL.ConnectionManager.Instance.GetSQLConnection();
                SqlCommand sqlCmd = new SqlCommand(ss, sqlCon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCmd;
                DataTable ds = new DataTable();
                da.Fill(ds);
                string msgBody = GetEmailMessageBody(userID, typeName, bulletinID, domainName);
                BusinessBLL objBusiness = new BusinessBLL();
                var dtUserDetails = objBusiness.GetUserDetailsByUserID(userID);
                string AuthorName = "";
                if (dtUserDetails.Rows.Count > 0)
                {
                    AuthorName = dtUserDetails.Rows[0]["Firstname"] + " " + dtUserDetails.Rows[0]["Lastname"];
                }
                UtilitiesBLL utlobj = new UtilitiesBLL();
                string FromEmailInfo = "";
                DataTable dtConfigsemails = CommonDAL.GetVerticalConfigsByType(domainName, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                        {
                            FromEmailInfo = row[1].ToString();
                            break;
                        }
                    }
                }
                if (typeName == PageNames.BULLETIN)
                    returnval = utlobj.SendWowzzyEmail(FromEmailInfo, pUsername, "Bulletin Created By " + AuthorName, msgBody, "", "", domainName);
                else if (typeName == PageNames.UPDATE)
                    returnval = utlobj.SendWowzzyEmail(FromEmailInfo, pUsername, "Update Created By " + AuthorName, msgBody, "", "", domainName);
                else if (typeName == PageNames.EVENT)
                    returnval = utlobj.SendWowzzyEmail(FromEmailInfo, pUsername, "Event Created By " + AuthorName, msgBody, "", "", domainName);
                else if (typeName == PageNames.SURVEY)
                    returnval = utlobj.SendWowzzyEmail(FromEmailInfo, pUsername, "Survey Created By " + AuthorName, msgBody, "", "", domainName);
                USPDHUBDAL.ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);

                string ccEmailIds = "";

                if (ds.Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        if (ds.Rows[i]["Username"].ToString() != username)
                        {
                            if (!string.IsNullOrEmpty((ds.Rows[i]["Permission_Values"].ToString())))
                            {
                                int val = 0;
                                int permissionValue = Convert.ToInt32(ds.Rows[i]["Permission_Values"].ToString());
                                if (Convert.ToBoolean(permissionValue & Constants.BULLETINS))
                                    val = val + 1;
                                else if (Convert.ToBoolean(permissionValue & Constants.UPDATES))
                                    val = val + 1;
                                else if (Convert.ToBoolean(permissionValue & Constants.EVENTS))
                                    val = val + 1;
                                else if (Convert.ToBoolean(permissionValue & Constants.SURVEYS))
                                    val = val + 1;
                                if (val > 0)
                                {
                                    string publishedUser = ds.Rows[i]["Username"].ToString();
                                    ccEmailIds = ccEmailIds + "," + publishedUser;
                                }
                            }
                        }
                    }
                }


                if (ccEmailIds.StartsWith(","))
                {
                    ccEmailIds = ccEmailIds.Substring(1);
                }
                if (ccEmailIds.EndsWith(","))
                {
                    ccEmailIds = ccEmailIds.Remove(ccEmailIds.Length - 1);
                }
                if (ccEmailIds.Trim() != string.Empty)
                {
                    int publishedUserID = 0;
                    //msgBody = GetEmailMessageBody(publishedUserID, typeName, bulletinID, domainName);
                    if (typeName == PageNames.BULLETIN)
                        returnval = utlobj.SendWowzzyEmail(FromEmailInfo, username, "Bulletin Created By " + AuthorName, msgBody, ccEmailIds, "", domainName);
                    else if (typeName == PageNames.UPDATE)
                        returnval = utlobj.SendWowzzyEmail(FromEmailInfo, username, "Update Created By " + AuthorName, msgBody, ccEmailIds, "", domainName);
                    else if (typeName == PageNames.EVENT)
                        returnval = utlobj.SendWowzzyEmail(FromEmailInfo, username, "Event Created By " + AuthorName, msgBody, ccEmailIds, "", domainName);
                    else if (typeName == PageNames.SURVEY)
                        returnval = utlobj.SendWowzzyEmail(FromEmailInfo, username, "Survey Created By " + AuthorName, msgBody, ccEmailIds, "", domainName);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnval;
        }
#endif
        /// <summary>
        /// Send Author Notifications
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="typeName">typeName</param>
        /// <param name="userID">userID</param>
        /// <param name="pUsername">pUsername</param>
        /// <param name="pagename">pagename</param>
        /// <param name="domainName">domainName</param>
        /// <returns>String</returns>
        public string SendAuthorNotifications(string username, int bulletinID, string typeName, int userID, string pUsername, string pagename, string domainName) //Roles & Permissions...
        {
            string returnval = string.Empty;
            try
            {
                BusinessBLL objBusiness = new BusinessBLL();
                DataTable ds = objBusiness.GetAllPublishersofItem(userID, typeName, bulletinID);
                var dtUserDetails = objBusiness.GetUserDetailsByUserID(Convert.ToInt32(HttpContext.Current.Session["C_USER_ID"].ToString()));
                string AuthorName = "";
                if (dtUserDetails.Rows.Count > 0)
                {
                    AuthorName = dtUserDetails.Rows[0]["Firstname"] + " " + dtUserDetails.Rows[0]["Lastname"];
                }
                UtilitiesBLL utlobj = new UtilitiesBLL();
                string FromEmailInfo = "";
                DataTable dtConfigsemails = CommonDAL.GetVerticalConfigsByType(domainName, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                        {
                            FromEmailInfo = row[1].ToString();
                            break;
                        }
                    }
                }
                string strContent = GetAuthorContent(typeName, bulletinID, userID);
                string moduleName = "Content";
                if (PageNames.SURVEY == typeName)
                { moduleName = typeName; }
                moduleName = GetAuthotTabName(typeName, bulletinID, userID, moduleName);
                string msgBody = GetEmailMessageBody(username, userID, typeName, bulletinID, domainName, moduleName).Replace("#ContentBody#", strContent);
                returnval = utlobj.SendWowzzyEmail(FromEmailInfo, pUsername, moduleName + " Created By " + AuthorName, msgBody, "", "", domainName);
                if (ds.Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        if (ds.Rows[i]["Username"].ToString() != username)
                        {
                            string publishedUser = ds.Rows[i]["Username"].ToString();
                            int publishedUserID = Convert.ToInt32(ds.Rows[i]["User_ID"].ToString());
                            msgBody = GetEmailMessageBody(username, publishedUserID, typeName, bulletinID, domainName, moduleName).Replace("#ContentBody#", strContent);
                            returnval = utlobj.SendWowzzyEmail(FromEmailInfo, publishedUser, moduleName + " Created By " + AuthorName, msgBody, "", "", domainName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnval;
        }

        /// <summary>
        /// Send Representation Email
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="verticalValue">verticalValue</param>
        public void SendRepresentationEmail(int profileID, string verticalValue)
        {
            string displayName = "";
            DataTable dtConfigs = CommonDAL.GetVerticalConfigsByType(verticalValue, "VerticalNames");
            if (dtConfigs.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigs.Rows)
                {
                    if (row[0].ToString() == "NameForDisplay")
                    {
                        displayName = row[1].ToString();
                        break;
                    }
                }
            }
            string FromEmailsupport = "";
            DataTable dtConfigsemails = CommonDAL.GetVerticalConfigsByType(verticalValue, "EmailAccounts");
            if (dtConfigsemails.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigsemails.Rows)
                {
                    if (row[0].ToString() == "EmailInfo")
                    {
                        FromEmailsupport = row[1].ToString();
                        break;
                    }
                }
            }
            string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + verticalValue + "\\";
            StreamReader re = File.OpenText(strfilepath + "Representation.txt");
            StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
            string msgbody = string.Empty;
            string content = string.Empty;
            string desclaimer = string.Empty;
            while ((desclaimer = reDeclaimer.ReadLine()) != null)
            {
                msgbody = msgbody + desclaimer;
            }
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                content = content + input + "<BR>";
            }
            DataTable dtuserdetails = BusinessDAL.GetuserdetailsByProfileID(profileID);
            if (dtuserdetails.Rows.Count > 0)
            {
                DataTable dtProfile = BusinessDAL.GetProfileDetailsByProfileID(profileID);
                msgbody = msgbody.Replace("#msgBody#", content);
                msgbody = msgbody.Replace("##DomainName##", displayName);
                msgbody = msgbody.Replace("##ProfileName##", dtProfile.Rows[0]["Profile_name"].ToString());
                msgbody = msgbody.Replace("##FirstName##", dtuserdetails.Rows[0]["Firstname"].ToString());
                re.Close();
                reDeclaimer.Close();
                string ccemail = string.Empty;

                UtilitiesBLL utlobj = new UtilitiesBLL();
                utlobj.SendWowzzyEmail(FromEmailsupport, dtuserdetails.Rows[0]["Username"].ToString(), "Account Representative Details", msgbody, ccemail, "", verticalValue);
                re.Dispose();
                reDeclaimer.Dispose();
            }
        }

        /// <summary>
        /// Get Email Message Body
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="userID">userID</param>
        /// <param name="typeName">typeName</param>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="domainName">domainName</param>
        /// <param name="moduleName">moduleName</param>
        /// <returns>String</returns>
        private string GetEmailMessageBody(string userName, int userID, string typeName, int bulletinID, string domainName, string moduleName)
        {
            string rootPath = HttpContext.Current.Session["RootPath"].ToString();
            string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + domainName + "\\";
            StreamReader re = File.OpenText(strfilepath + "AuthorNotification.txt");
            StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
            string msgbody = string.Empty;
            string content = string.Empty;
            string desclaimer = string.Empty;
            while ((desclaimer = reDeclaimer.ReadLine()) != null)
            {
                msgbody = msgbody + desclaimer;
            }
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                content = content + input + "<BR>";
            }
            string type = "";
            if (typeName == PageNames.BULLETIN)
                type = "BL";
            else if (typeName == PageNames.UPDATE)
                type = "BU";
            else if (typeName == PageNames.EVENT)
                type = "ET";
            else if (typeName == PageNames.SURVEY)
                type = "SU";
            else if (typeName == PageNames.CustomModule)
                type = "CM";
            else if (typeName == PageNames.CALENDARADDON)
                type = "CA";
            msgbody = msgbody.Replace("#RootUrl#", rootPath);
            msgbody = msgbody.Replace("#msgBody#", content);
            msgbody = msgbody.Replace("#Type#", moduleName);
            msgbody = msgbody.Replace("#Username#", userName);
            msgbody = msgbody.Replace("#Link#", "<a href='" + rootPath + "/ApprovalProcess.aspx?TID=" + EncryptDecrypt.DESEncrypt(bulletinID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&UID=" + EncryptDecrypt.DESEncrypt(userID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&Type=" + type + "&CUserID=" + EncryptDecrypt.DESEncrypt(HttpContext.Current.Session["C_USER_ID"].ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "' target='_blank'><img src='" + rootPath + "/Images/preview_btn.gif'/></a>");
            msgbody = msgbody.Replace("#Link1#", "<a href='" + rootPath + "/ApprovalProcess.aspx?TID=" + EncryptDecrypt.DESEncrypt(bulletinID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&UID=" + EncryptDecrypt.DESEncrypt(userID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&Type=" + type + "&CUserID=" + EncryptDecrypt.DESEncrypt(HttpContext.Current.Session["C_USER_ID"].ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "' target='_blank'><img src='" + rootPath + "/Images/approve_btn.gif'/></a>"); //A for approve
            msgbody = msgbody.Replace("#Link2#", "<a href='" + rootPath + "/ApprovalProcess.aspx?TID=" + EncryptDecrypt.DESEncrypt(bulletinID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&UID=" + EncryptDecrypt.DESEncrypt(userID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&Type=" + type + "&CUserID=" + EncryptDecrypt.DESEncrypt(HttpContext.Current.Session["C_USER_ID"].ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "' target='_blank'><img src='" + rootPath + "/Images/reject_btn.gif'/></a>");
            re.Close();
            reDeclaimer.Close();
            re.Dispose();
            reDeclaimer.Dispose();
            return msgbody;
        }
        /// <summary>
        /// Send Approve Email To Author
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="typeName">typeName</param>
        /// <param name="userID">userID</param>
        /// <param name="pUsername">pUsername</param>
        /// <param name="pagename">pagename</param>
        /// <param name="domainName">domainName</param>
        /// <returns>String</returns>
        public string SendApproveEmailToAuthor(string username, int bulletinID, string typeName, int userID, int pUserID,
            string pagename, string domainName, string pTitle, string remarks, string initials, int processType, int assocUser) //Roles & Permissions...
        {
            string returnval = string.Empty;
            try
            {
                BusinessBLL objBusiness = new BusinessBLL();
                DataTable ds = objBusiness.GetAllApproveRejectCCUsers(pUserID, bulletinID, typeName, assocUser);
                var dtUserDetails = objBusiness.GetUserDtlsByUserID(userID);
                string AuthorName = "";
                if (dtUserDetails.Rows.Count > 0)
                {
                    AuthorName = dtUserDetails.Rows[0]["Firstname"] + " " + dtUserDetails.Rows[0]["Lastname"];
                }
                var dtSuperAdminUser = objBusiness.GetUserDtlsByUserID(pUserID);
                string toEmail = "";
                if (dtSuperAdminUser.Rows.Count > 0)
                {
                    toEmail = dtSuperAdminUser.Rows[0]["Username"].ToString();
                }
                UtilitiesBLL utlobj = new UtilitiesBLL();
                string FromEmailInfo = "";
                DataTable dtConfigsemails = CommonDAL.GetVerticalConfigsByType(domainName, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                        {
                            FromEmailInfo = row[1].ToString();
                            break;
                        }
                    }
                }

                string ccEmailIds = "";
                if (ds.Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        string publishedUser = ds.Rows[i]["Username"].ToString();
                        if (!ccEmailIds.Contains(publishedUser))
                        {
                            if (ccEmailIds != "")
                                ccEmailIds = ccEmailIds + "," + publishedUser;
                            else
                                ccEmailIds = publishedUser;
                        }
#if fixme
                        if (!string.IsNullOrEmpty((ds.Rows[i]["Permission_Values"].ToString())))
                        {
                            int val = 0;
                            int permissionValue = Convert.ToInt32(ds.Rows[i]["Permission_Values"].ToString());
                            if (Convert.ToBoolean(permissionValue & Constants.BULLETINS))
                                val = val + 1;
                            else if (Convert.ToBoolean(permissionValue & Constants.UPDATES))
                                val = val + 1;
                            else if (Convert.ToBoolean(permissionValue & Constants.EVENTS))
                                val = val + 1;
                            else if (Convert.ToBoolean(permissionValue & Constants.SURVEYS))
                                val = val + 1;
                            if (val > 0)
                            {
                                // *** here goes above code when clients wants to send only to the publisher instead of all associates - USPD 556 *** //
                            }
                        }
#endif
                    }
                }

                string strContent = GetAuthorContent(typeName, bulletinID, userID);
                string moduleName = "Content";
                moduleName = GetAuthotTabName(typeName, bulletinID, userID, moduleName);
                int publishedUserID = userID;
                string msgBody = "";
                string subject = "Approved By ";
                if (processType == Convert.ToInt32(ApprovalProcessTypes.Rejected))
                    subject = "Rejected By ";
                msgBody = GetApprovedMessageBody(publishedUserID, typeName, bulletinID, domainName, pTitle, username, processType, remarks, initials, moduleName).Replace("#ContentBody#", strContent);
                returnval = utlobj.SendWowzzyEmail(FromEmailInfo, toEmail, moduleName + " " + subject + AuthorName, msgBody, ccEmailIds, "", domainName);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objError = new InBuiltDataBLL();
                objError.ErrorHandling("ERROR", "ApprovalProcess.aspx.cs", "btnSave_Click", "Exception " + ex.Message.ToString(),
              "SendApproveEmailToAuthor", "", "");
            }
            return returnval;
        }

        /// <summary>
        /// Get Author Content
        /// </summary>
        /// <param name="typeName">typeName</param>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="userID">userID</param>
        /// <returns>String</returns>
        public string GetAuthorContent(string typeName, int bulletinID, int userID)
        {
            string contentBody = string.Empty;
            DataTable dtContent;

            if (typeName == PageNames.BULLETIN)
            {
                dtContent = BulletinDAL.GetBulletinByID(bulletinID);
                if (dtContent.Rows.Count > 0)
                {
                    contentBody = dtContent.Rows[0]["Bulletin_HTML"].ToString();
                }
            }
            else if (typeName == PageNames.UPDATE)
            {
                dtContent = BusinessUpdatesDAL.UpdateBusinessUpdateDetails(bulletinID);
                if (dtContent.Rows.Count > 0)
                {
                    contentBody = dtContent.Rows[0]["UpdatedText"].ToString();
                }
            }
            else if (typeName == PageNames.EVENT)
            {
                dtContent = EventCalendarDAL.GetCalendarEventDetails(bulletinID);
                if (dtContent.Rows.Count > 0)
                {
                    DateTime StartDate = DateTime.Parse(dtContent.Rows[0]["EventStartDate"].ToString());
                    DateTime EndDate = DateTime.Parse(dtContent.Rows[0]["EventEndDate"].ToString());
                    contentBody = "<br />Event Name:" + dtContent.Rows[0]["EventTitle"].ToString() + "<br /><br />";
                    contentBody = contentBody + "Event Start Date:" + StartDate.ToString("MMM dd yyyy hh:mm tt") + "<br /><br />";
                    contentBody = contentBody + "Event End Date:" + EndDate.ToString("MMM dd yyyy hh:mm tt") + "<br /><br />";
                    contentBody = contentBody + dtContent.Rows[0]["EventDesc"].ToString();
                }
            }
            else if (typeName == PageNames.SURVEY)
            {
                contentBody = BuildSurveyPreview(bulletinID);
            }
            else if (typeName == PageNames.CustomModule)
            {
                dtContent = AddOnDAL.GetCustomModuleByID(bulletinID);
                if (dtContent.Rows.Count > 0)
                {
                    contentBody = dtContent.Rows[0]["Bulletin_HTML"].ToString();
                }
            }
            else if (typeName == PageNames.CALENDARADDON)
            {
                dtContent = CalendarAddOnDAL.GetCalendarAddOnDetails(bulletinID);
                if (dtContent.Rows.Count > 0)
                {
                    contentBody = dtContent.Rows[0]["EventDesc"].ToString();
                }
            }
            return contentBody;
        }

        /// <summary>
        /// Get Author Tab Name
        /// </summary>
        /// <param name="typeName">typeName</param>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="userID">userID</param>
        /// <param name="moduleName">moduleName</param>
        /// <returns>String</returns>
        public string GetAuthotTabName(string typeName, int bulletinID, int userID, string moduleName)
        {
            if (typeName == PageNames.BULLETIN)
            {
                DataTable dttab = BusinessDAL.GetTabDetailsByModule("Bulletins", bulletinID, userID);
                if (dttab.Rows.Count > 0)
                    moduleName = dttab.Rows[0]["TabName"].ToString();
            }
            else if (typeName == PageNames.UPDATE)
            {
                DataTable dttab = BusinessDAL.GetTabDetailsByModule("Updates", bulletinID, userID);
                if (dttab.Rows.Count > 0)
                    moduleName = dttab.Rows[0]["TabName"].ToString();
            }
            else if (typeName == PageNames.EVENT)
            {
                DataTable dttab = BusinessDAL.GetTabDetailsByModule("EventCalendar", bulletinID, userID);
                if (dttab.Rows.Count > 0)
                    moduleName = dttab.Rows[0]["TabName"].ToString();
            }
            else if (typeName == PageNames.SURVEY)
            {
                DataTable dttab = BusinessDAL.GetTabDetailsByModule("Surveys", bulletinID, userID);
                if (dttab.Rows.Count > 0)
                    moduleName = dttab.Rows[0]["TabName"].ToString();
            }
            else if (typeName == PageNames.CALENDARADDON)
            {
                DataTable dttab = BusinessDAL.GetTabDetailsByModule(WebConstants.Tab_CalendarAddOns, bulletinID, userID);
                if (dttab.Rows.Count > 0)
                    moduleName = dttab.Rows[0]["TabName"].ToString();
            }
            else
            {
                DataTable dttab = BusinessDAL.GetTabDetailsByModule(WebConstants.Tab_ContentAddOns, bulletinID, userID);
                if (dttab.Rows.Count > 0)
                    moduleName = dttab.Rows[0]["TabName"].ToString();
            }
            return moduleName;
        }
        /// <summary>
        /// Get Approved Message Body
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="typeName">typeName</param>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="domainName">domainName</param>
        /// <returns>String</returns>
        public string GetApprovedMessageBody(int userID, string typeName, int bulletinID, string domainName, string pTitle, string pApproveName, int processType, string remarks, string initial, string moduleName)
        {
            string rootPath = HttpContext.Current.Session["RootPath"].ToString();
            string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + domainName + "\\";
            StreamReader re;
            if (processType == Convert.ToInt32(ApprovalProcessTypes.Approved))
                re = File.OpenText(strfilepath + "ApprovedNotification.txt");
            else
                re = File.OpenText(strfilepath + "RejectedNotification.txt");
            StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
            string msgbody = string.Empty;
            string content = string.Empty;
            string desclaimer = string.Empty;
            while ((desclaimer = reDeclaimer.ReadLine()) != null)
            {
                msgbody = msgbody + desclaimer;
            }
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                content = content + input + "<BR>";
            }
            msgbody = msgbody.Replace("#RootUrl#", rootPath);
            msgbody = msgbody.Replace("#msgBody#", content);
            msgbody = msgbody.Replace("#Type#", moduleName);
            msgbody = msgbody.Replace("#Title#", pTitle);
            msgbody = msgbody.Replace("#Username#", pApproveName);
            msgbody = msgbody.Replace("#Initiails#", initial);
            msgbody = msgbody.Replace("#Remarks#", remarks);
            re.Close();
            reDeclaimer.Close();
            re.Dispose();
            reDeclaimer.Dispose();
            return msgbody;
        }

        /// <summary>
        /// Create Admin Domain
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>String</returns>
        public string CreateAdminDomain(string url)
        {
            string adminurl = url;
            string adminhost = new System.Uri(adminurl).Host.ToLower();
            int index = adminhost.LastIndexOf('.'), last = 3;
            while (index > 0 && index >= last - 3)
            {
                last = index;
                index = adminhost.LastIndexOf('.', last - 1);
            }
            string admindomain = adminhost.Substring(index + 1);
            string[] domainarray = admindomain.Split('.');
            string adminDomainName = admindomain.Replace(".", "");
            return adminDomainName;
        }

        /// <summary>
        /// Create Domain Url String
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>String</returns>
        public string CreateDomainUrlString(string url)
        {
            string host = new System.Uri(url).Host.ToLower();
            int index = host.LastIndexOf('.'), last = 3;
            while (index > 0 && index >= last - 3)
            {
                last = index;
                index = host.LastIndexOf('.', last - 1);
            }
            string domain = host.Substring(index + 1);
            string[] domainarray = domain.Split('.');
            string verticalDomain = domain.Replace(".", "");
            return verticalDomain;
        }

        /// <summary>
        /// Get Domain Url WithOut
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>String</returns>
        public string GetDomainUrlWithOut(string url)
        {
            if (url.ToLower().Contains("inschoolhub") && Convert.ToBoolean(ConfigurationManager.AppSettings["CheckInschoolHubCountry"]))
            {
                string ipaddress;
                ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ipaddress == "" || ipaddress == null)
                    ipaddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                DataTable dt = GetLocation(ipaddress);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string countryName = dt.Rows[0]["CountryName"].ToString();
                        if (countryName.ToLower().Contains("india"))
                            url = "http://www.inschoolhub.in";
                        else
                            url = "http://www.inschoolhub.com";
                    }
                }
            }
            string host = new System.Uri(url).Host.ToLower();
            int index = host.LastIndexOf('.'), last = 3;
            while (index > 0 && index >= last - 3)
            {
                last = index;
                index = host.LastIndexOf('.', last - 1);
            }
            string domain = host.Substring(index + 1);
            string[] domainarray = domain.Split('.');
            string verticalDomain = Convert.ToString(domain[0]);
            return verticalDomain;
        }

        /// <summary>
        /// Create Domain Url
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>String</returns>
        public string CreateDomainUrl(string url)
        {
            //http://localhost:12345/site/page.aspx?q1=1&q2=2

            //Value of HttpContext.Current.Request.Url.Host
            //localhost

            //Value of HttpContext.Current.Request.Url.Authority
            //localhost:12345

            //Value of HttpContext.Current.Request.Url.AbsolutePath
            ///site/page.aspx

            //Value of HttpContext.Current.Request.ApplicationPath
            ///site

            //Value of HttpContext.Current.Request.Url.AbsoluteUri
            //http://localhost:12345/site/page.aspx?q1=1&q2=2

            //Value of HttpContext.Current.Request.RawUrl
            ///site/page.aspx?q1=1&q2=2

            //Value of HttpContext.Current.Request.Url.PathAndQuery
            ///site/page.aspx?q1=1&q2=2
            if (url.ToLower().Contains("inschoolhub") && Convert.ToBoolean(ConfigurationManager.AppSettings["CheckInschoolHubCountry"]))
            {
                string ipaddress;
                ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ipaddress == "" || ipaddress == null)
                    ipaddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                DataTable dt = GetLocation(ipaddress);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string countryName = dt.Rows[0]["CountryName"].ToString();
                        if (countryName.ToLower().Contains("india"))
                            url = "http://www.inschoolhub.in";
                        else
                            url = "http://www.inschoolhub.com";
                    }
                }
            }
            string host = new System.Uri(url).Host.ToLower();
            int index = host.LastIndexOf('.'), last = 3;
            while (index > 0 && index >= last - 3)
            {
                last = index;
                index = host.LastIndexOf('.', last - 1);
            }
            string domain = host.Substring(index + 1);
            string[] domainarray = domain.Split('.');
            string verticalDomain = domain.Replace(".", "");
            if (verticalDomain != "")
            {
                HttpContext.Current.Session["VerticalDomain"] = verticalDomain;
                DataTable dtConfigs = CommonDAL.GetVerticalConfigsByType(verticalDomain, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            HttpContext.Current.Session["RootPath"] = row[1].ToString();
                    }
                }
            }

            //HttpContext.Current.Session["VerticalDomain"] = "uspdhubcom";
            //HttpContext.Current.Session["RootPath"] = "http://localhost:2107";

            return verticalDomain;
        }

        /// <summary>
        /// Get Location
        /// </summary>
        /// <param name="ipaddress">ipaddress</param>
        /// <returns>DataTable</returns>
        public DataTable GetLocation(string ipaddress)
        {
            string apiKey = "d4e19beca2cef7242b3c9e11f08bae1bc30ff72606e8d38b3b9982030aabc722";
            string url = "http://api.ipinfodb.com/v3/ip-city/?key={0}&ip={1}&format=xml"; //  *** version 1.3 *** //
            //"http://api.ipinfodb.com/v2/ip_query.php?key={0}&ip={1}&timezone=true";   // *** This is deprecated *** //

            url = String.Format(url, apiKey, ipaddress);

            HttpWebRequest httpWRequest = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                using (HttpWebResponse httpWResponse = (HttpWebResponse)httpWRequest.GetResponse())
                {
                    XmlTextReader xtr = new XmlTextReader(httpWResponse.GetResponseStream());
                    DataSet ds = new DataSet();
                    ds.ReadXml(xtr);
                    return ds.Tables[0];
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Get Sub Packages
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="vertical">vertical</param>
        /// <returns>List</returns>
        public List<SubPackages> GetSubPackages(string value, string vertical = "")
        {
            List<SubPackages> objPackage = new List<SubPackages>();
            if (value == "")
            {
                //objPackage.Add(new SubPackages
                //{
                //    Description = "Premium Plus - $74",
                //    Value = "74.00"
                //});
                if (vertical.ToLower().Contains("twovie"))
                {
                    objPackage.Add(new SubPackages
                    {
                        Description = "Premium Plus - $" + ConfigurationManager.AppSettings["twoviepkg"],
                        Value = ConfigurationManager.AppSettings["twoviepkg"] + ".00"
                    });
                    objPackage.Add(new SubPackages
                    {
                        Description = "Premium Plus With Branded App - $" + ConfigurationManager.AppSettings["twoviepkgBranded"],
                        Value = ConfigurationManager.AppSettings["twoviepkgBranded"] + ".00"
                    });
                }
                else
                {
                    objPackage.Add(new SubPackages
                    {
                        Description = "Premium Plus With Branded App - $" + ConfigurationManager.AppSettings["uspdhubpkgBranded"],
                        Value = ConfigurationManager.AppSettings["uspdhubpkgBranded"] + ".00"
                    });
                }
            }
            else
            {
                if (vertical.ToLower().Contains("inschool"))
                {
                    objPackage.Add(new SubPackages
                    {
                        Description = "Sub App - $" + ConfigurationManager.AppSettings["InSchoolHubYearPackageSub"],
                        Value = ConfigurationManager.AppSettings["InSchoolHubYearPackageSub"] + ".00"
                    });
                }
                else
                {
                    objPackage.Add(new SubPackages
                    {
                        Description = "Sub App - $" + ConfigurationManager.AppSettings["uspdhubpkgSub"],
                        Value = ConfigurationManager.AppSettings["uspdhubpkgSub"] + ".00"
                    });
                }
            }
            return objPackage;
        }

        /// <summary>
        /// Get Social Description
        /// </summary>
        /// <param name="description">description</param>
        /// <returns>String</returns>
        public string GetSocialDescription(string description)
        {
            string socialDesc = "";
            //getting first paragraph
            #region Paragraph lines

            description = description.Replace("<BR>", "<br>");
            var paras = description.Split(new string[] { "<br>" }, StringSplitOptions.None);
            string firstPara = "";
            if (paras.Length > 0)
            {
                for (int k = 0; k < paras.Length; k++)
                {
                    firstPara = ReplaceSpecialCharacter(paras[k].ToString());
                    if (firstPara != "")
                    {
                        socialDesc = paras[k].ToString();
                        break;
                    }
                }
            }
            else
            {
                socialDesc = description;
            }

            firstPara = ReplaceSpecialCharacter(firstPara);
            bool isValid = false;
            if (firstPara.Length > 160)
            {
                for (int j = 140; j < 160; j++)
                {
                    if (firstPara.Substring(0, j).EndsWith(" "))
                    {
                        socialDesc = firstPara.Substring(0, j);
                        isValid = true;
                        break;
                    }
                }

                if (isValid == false)
                {
                    socialDesc = firstPara.Substring(0, 140);
                }
            }
            else
            {
                socialDesc = firstPara;
            }
            return socialDesc;
            #endregion
            //descrition = ReplaceSpecialCharacter(descrition);
        }

        /// <summary>
        /// Replace Special Character
        /// </summary>
        /// <param name="inputString">inputString</param>
        /// <returns>String</returns>
        public string ReplaceSpecialCharacter(string inputString)
        {
            inputString = inputString.Replace("<A href=\"http://tr\" target=_blank></A>&nbsp;", "");
            inputString = System.Text.RegularExpressions.Regex.Replace(inputString, "<[^>]*>", " ");

            inputString = inputString.Replace("'", " ");
            inputString = inputString.Replace("&nbsp;", " ");
            inputString = inputString.Replace("&amp;", "and");
            inputString = inputString.Replace("&", "and");
            inputString = inputString.Replace("&amp;amp;", "and");
            inputString = inputString.Replace("&amp;yen;", "and");

            if (inputString.StartsWith("&yen;"))
            {
                inputString = inputString.Substring(5, inputString.Length - 5);
            }
            return inputString.Trim();
        }

        /// <summary>
        /// long url To short url
        /// </summary>
        /// <param name="longurl">longurl</param>
        /// <returns>String</returns>
        public string longurlToshorturl(string longurl)
        {
            longurl = longurl.Replace("&amp;", "&");
            ErrorHandling("LOG ", "CommonBLL.cs", "longurlToshorturl", string.Empty, string.Empty, string.Empty, string.Empty);

            string key = ConfigurationManager.AppSettings.Get("GoogleKeyShortenUrl");
            string shortURL = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/urlshortener/v1/url?key=" + key);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.ServicePoint.Expect100Continue = false;
            httpWebRequest.Headers.Add("Cache-Control", "no-cache");
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"longUrl\":\"" + longurl + "\"}";
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    shortURL = responseText.Split(',')[1].ToString().Substring(9);
                    shortURL = shortURL.Replace("\"", "");
                    streamReader.Close();
                    streamReader.Dispose();
                }
                return shortURL;
            }
            catch (WebException exception)
            {
                //using (var reader = new StreamReader(exception.Response.GetResponseStream()))
                //{
                //    responseText = reader.ReadToEnd();
                //}
                ErrorHandling("ERROR ", "CommonBLL.cs", "longurlToshorturl", "",
                    Convert.ToString(exception.StackTrace), Convert.ToString(exception.InnerException), Convert.ToString(exception.Data));
                return shortURL;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "CommonBLL.cs", "longurlToshorturl", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return shortURL;
            }
        }

        /// <summary>
        /// Get Config Settings
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pType">pType</param>
        /// <param name="pConfigName">pConfigName</param>
        /// <returns>String</returns>
        public string GetConfigSettings(string pProfileID, string pType, string pConfigName)
        {
            string returnValue = "";
            string verticalCode = MServiceDAL.GetVerticalNameByProfileID(Convert.ToInt32(pProfileID));

            DataTable dtProfileDetails = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
            string countryName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);

            string domain = GetDomainNameByCountryVertical(verticalCode, countryName.Trim());

            var dtConfigs = GetVerticalConfigsByType(domain, pType);
            if (dtConfigs.Rows.Count > 0)
            {
                for (int i = 0; i < dtConfigs.Rows.Count; i++)
                {
                    if (Convert.ToString(dtConfigs.Rows[i]["Name"]).ToLower() == pConfigName.ToLower())
                    {
                        returnValue = Convert.ToString(dtConfigs.Rows[i]["Value"]).Trim();
                        break;
                    }
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Send Wowzzy Email
        /// </summary>
        /// <param name="fromEmail">fromEmail</param>
        /// <param name="toEmail">toEmail</param>
        /// <param name="subject">subject</param>
        /// <param name="message">message</param>
        /// <param name="cCemail">cCemail</param>
        /// <param name="fromDisplayName">fromDisplayName</param>
        /// <param name="domainName">domainName</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="attachmentFilePath">attachmentFilePath</param>
        /// <returns>String</returns>
        public string SendWowzzyEmail(string fromEmail, string toEmail, string subject, string message, string cCemail,
            string fromDisplayName, string domainName, string pProfileID, string attachmentFilePath)
        {
            string returnValue = "";
            try
            {
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                System.Net.Mail.SmtpClient oSMTLClient = new System.Net.Mail.SmtpClient();
                DataTable dtConfigs = GetVerticalConfigsByType(domainName, "SMTPServer");
                for (int i = 0; i < dtConfigs.Rows.Count; i++)
                {
                    if (Convert.ToString(dtConfigs.Rows[i]["Name"]) == "SmtpServerName")
                    {
                        oSMTLClient.Host = Convert.ToString(dtConfigs.Rows[i]["Value"]);
                        break;
                    }
                }

                string serverPWD = "";
                for (int i = 0; i < dtConfigs.Rows.Count; i++)
                {
                    if (Convert.ToString(dtConfigs.Rows[i]["Name"]) == "SmtpServerCr")
                    {
                        serverPWD = Convert.ToString(dtConfigs.Rows[i]["Value"]);
                        break;
                    }
                }
                string[] strto = toEmail.Split(',');
                for (int i = 0; i < strto.Length; i++)
                {
                    mailMessage.To.Add(new System.Net.Mail.MailAddress(strto[i].Trim()));
                }
                if (cCemail != "")
                {
                    string[] ccemails = cCemail.Split(',');
                    for (int i = 0; i < ccemails.Length; i++)
                    {
                        mailMessage.CC.Add(new System.Net.Mail.MailAddress(ccemails[i].Trim()));
                    }
                }
                // Attachement
                if (attachmentFilePath.Trim() != "")
                {
                    System.Net.Mail.Attachment objAttachment = new System.Net.Mail.Attachment(attachmentFilePath);
                    //objAttachment.TransferEncoding = System.Net.Mime.TransferEncoding.SevenBit;
                    mailMessage.Attachments.Add(objAttachment);
                }


                /*** For Sendgrid SMTP Server Port  July 21 2016 Azure Deployement ***/
                string sendgridSMTPServer_Username = Convert.ToString(ConfigurationManager.AppSettings.Get("SendgridSMTPServer_Username"));
                oSMTLClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("SendgridSMTPServer_Port"));

                oSMTLClient.Credentials = new System.Net.NetworkCredential(sendgridSMTPServer_Username, EncryptDecrypt.DESDecrypt(serverPWD));
                mailMessage.From = new System.Net.Mail.MailAddress(fromEmail, fromDisplayName);
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = System.Net.Mail.MailPriority.Normal;
                mailMessage.Subject = subject;
                oSMTLClient.Send(mailMessage);
                returnValue = "SUCCESS";

            }
            catch (Exception ex)
            {
                returnValue = ex.Message;
            }
            return returnValue;
        }




        /// <summary>
        /// Insert User Activity Log
        /// </summary>
        /// <param name="pDescription">pDescription</param>
        /// <param name="pNavigationLink">pNavigationLink</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pCreatedDate">pCreatedDate</param>
        /// <param name="pCreatedBy">pCreatedBy</param>
        public void InsertUserActivityLog(string pDescription, string pNavigationLink, int pUserID, int pProfileID, DateTime pCreatedDate, int pCreatedBy)
        {
            CommonDAL.InsertUserActivityLog(pDescription, pNavigationLink, pUserID, pProfileID, pCreatedDate, pCreatedBy);
        }
        #region Error Log
        /// <summary>
        /// Error Handling
        /// </summary>
        /// <param name="errorType">errorType</param>
        /// <param name="pPageName">pPageName</param>
        /// <param name="methodName">methodName</param>
        /// <param name="message">message</param>
        /// <param name="strackTrace">strackTrace</param>
        /// <param name="innerException">innerException</param>
        /// <param name="data">data</param>
        public void ErrorHandling(string errorType, string pPageName, string methodName, string message, string strackTrace, string innerException, string data)
        {
            bool isErrorLog = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("IsErrorLog"));

            if (isErrorLog == true || errorType != "LOG ")
            {
                string strLogFile = "";
                string errorLogFolder = HttpContext.Current.Server.MapPath("~") + "\\Upload\\ErrorLog\\";

                if (!Directory.Exists(errorLogFolder))
                {
                    Directory.CreateDirectory(errorLogFolder);
                }

                strLogFile = errorLogFolder + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "_CommonBLL_ErrorLog.txt";

                StreamWriter oSW;
                if (File.Exists(strLogFile))
                {
                    oSW = new StreamWriter(strLogFile, true);
                }
                else
                {
                    oSW = File.CreateText(strLogFile);
                }

                oSW.WriteLine("================================" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "================================");
                oSW.WriteLine(" ");
                oSW.WriteLine("Type : " + errorType);
                oSW.WriteLine(" ");
                oSW.WriteLine("Page Name : " + pPageName);
                oSW.WriteLine(" ");
                oSW.WriteLine("Method Name : " + methodName);
                oSW.WriteLine(" ");
                oSW.WriteLine("MESSAGE : " + message);
                oSW.WriteLine(" ");
                oSW.WriteLine("STACKTRACE : " + strackTrace);
                oSW.WriteLine(" ");
                oSW.WriteLine("INNEREXCEPTION : " + innerException);
                oSW.WriteLine(" ");
                oSW.WriteLine("DATA : " + data);
                oSW.WriteLine(" ");
                oSW.Close();
            }
        }

        #endregion

        /// <summary>
        /// Get Permission Access
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="pageName">pageName</param>
        /// <returns>Boolean</returns>
        public bool GetPermissionAccess(int userID, string pageName)
        {
            bool permissionFlag = false;
            DataTable dtpermissions = AgencyDAL.GetPermissionsById(userID);
            if (dtpermissions.Rows.Count > 0) //roles & permissions...
            {
                int val = GetPrevilages(dtpermissions, pageName);
                if (val > 0)
                    permissionFlag = true;
            }
            return permissionFlag;
        }

        /// <summary>
        /// Convert To User TimeZone
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DateTime</returns>
        public DateTime ConvertToUserTimeZone(int profileID)
        {
            DataTable dtprofile = BusinessDAL.GetProfileDetailsByProfileID(profileID);
            string timeZone = "Pacific Standard Time";
            if (dtprofile.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtprofile.Rows[0]["Time_ZoneId"].ToString()))
                    timeZone = dtprofile.Rows[0]["Time_ZoneId"].ToString();
            }
            DateTime dtNow = DateTime.UtcNow;
            TimeZoneInfo zoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            int zoneHours = zoneInfo.BaseUtcOffset.Hours;
            int zoneMins = zoneInfo.BaseUtcOffset.Minutes;
            //dtNow = TimeZoneInfo.ConvertTimeFromUtc(dtNow, TimeZoneInfo.FindSystemTimeZoneById(timeZone));
            dtNow = dtNow.AddHours(zoneHours).AddMinutes(zoneMins);
            return dtNow;
        }

        /// <summary>
        /// Convert User TimeZone To PST
        /// </summary>
        /// <param name="dtuserDate">dtuserDate</param>
        /// <returns>DateTime</returns>
        public DateTime ConvertUserTimeZoneToPST(DateTime dtuserDate)
        {
            string timeZone = "Pacific Standard Time";
            DateTime dtNow = DateTime.UtcNow;
            dtNow = TimeZoneInfo.ConvertTimeFromUtc(dtuserDate, TimeZoneInfo.FindSystemTimeZoneById(timeZone));
            return dtNow;
        }

        /// <summary>
        /// Display On/Off Settings Content
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pButtonType">pButtonType</param>
        /// <returns>Boolean</returns>
        public bool DisplayOn_OffSettingsContent(int pUserID, string pButtonType, int pUserModuleID = 0)
        {
            bool returnValue = BusinessDAL.CheckModuleDisplayOnOff(pUserID, pButtonType, pUserModuleID);


            /*
            AddOnBLL objAddOn = new AddOnBLL();
            DataTable dtAppSettings = new DataTable("dtapp");
            DataSet dtAddOns = objAddOn.GetManageAddOns(pUserID, null);
            if (dtAddOns.Tables.Count > 0 && dtAddOns.Tables[0].Rows.Count > 0)
            {
                DataRelation relation;
                DataColumn table1Column;
                DataColumn table2Column;
                //retrieve column 
                table1Column = dtAddOns.Tables[0].Columns["UserModuleID"];
                table2Column = dtAddOns.Tables[1].Columns["UserModuleID"];
                //relating tables 
                relation = new DataRelation("relation", table1Column, table2Column);
                //assign relation to dataset 
                dtAddOns.Relations.Add(relation);

                dtAppSettings = dtAddOns.Tables[0];
            }
            if (dtAppSettings.Rows.Count > 0)
            {
                var rows = dtAppSettings.Select("ButtonType='" + pButtonType + "' AND IsVisible='True' ");
                if (rows.Length > 0)
                    returnValue = true;
            }
            */

            return returnValue;
        }

        /// <summary>
        /// Display Order Type
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pButtonType">pButtonType</param>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <returns>String</returns>
        public string DisplayOrderType(int pUserID, string pButtonType, int UserModuleID = 0)
        {
            string returnValue = BusinessDAL.CheckModuleDisplayType(pUserID, pButtonType, UserModuleID);
            return returnValue;
        }
        /// <summary>
        ///  Parent Logo Copy to Sub app Account User
        /// </summary>
        /// <param name="pParentPID">pParentPID</param>
        /// <param name="pSubApp_PID">pSubApp_PID</param>
        public void ParentLogoCopyToSubApp(int pParentPID, int pSubApp_PID, int pSubApp_UserID)
        {
            BusinessBLL busobj = new BusinessBLL();
            string logoExtension = "";
            bool IsShortLogo = true;

            DataTable dtParentProfileDetails = busobj.GetProfileDetailsByProfileID(Convert.ToInt32(pParentPID));
            string logoFileName = Convert.ToString(dtParentProfileDetails.Rows[0]["Profile_logo_path"]);
            IsShortLogo = Convert.ToBoolean(dtParentProfileDetails.Rows[0]["IsShortLogo"]);

            if (logoFileName != string.Empty)
            {
                logoExtension = Path.GetExtension(logoFileName);
                if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("~") + "\\Upload\\Logos\\" + +pSubApp_PID))
                {
                    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~") + "\\Upload\\Logos\\" + +pSubApp_PID);
                }

                string parentLogo = HttpContext.Current.Server.MapPath("~") + "\\Upload\\Logos\\" + +pParentPID + "\\" + pParentPID + "_thumb" + logoExtension;
                string subAppLogo = HttpContext.Current.Server.MapPath("~") + "\\Upload\\Logos\\" + +pSubApp_PID + "\\" + pSubApp_PID + "_thumb" + logoExtension;

                try
                {
                    if (File.Exists(parentLogo))
                    {
                        File.Copy(parentLogo, subAppLogo, true);
                    }
                }
                catch (Exception /*ex*/)
                { }


                string photoFileName = pSubApp_PID + logoExtension;

                busobj.UpdateBusinessProfileLogo(photoFileName, pSubApp_PID, pSubApp_UserID, pSubApp_UserID);
                busobj.UpdateShortorLongLogo(pSubApp_UserID, IsShortLogo);

            }// END Logo File                 

        }

        /// <summary>
        /// Get Event Adjust Date
        /// </summary>
        /// <param name="dtStartDateTime">dtStartDateTime</param>
        /// <param name="dtEndDateTime">dtEndDateTime</param>
        /// <returns>String</returns>
        public string GetEventAdjustDate(DateTime dtStartDateTime, DateTime dtEndDateTime)
        {
            string fullDate = string.Empty;
            /****/
            if (dtStartDateTime == dtEndDateTime)
            {
                fullDate = dtStartDateTime.ToString("MMM dd yyyy") + " (All day)";
            }
            else
            {
                string startDateTime = dtStartDateTime.ToString("MMM dd yyyy hh:mm tt");
                string endDateTime = dtEndDateTime.ToString("MMM dd yyyy hh:mm tt");
                if (dtStartDateTime.Hour <= 0 && dtStartDateTime.Minute <= 0)
                    startDateTime = dtStartDateTime.ToString("MMM dd yyyy");

                if (dtEndDateTime.Hour <= 0 && dtEndDateTime.Minute <= 0)
                    endDateTime = dtEndDateTime.ToString("MMM dd yyyy") + " (All day)";
                fullDate = startDateTime + " to " + endDateTime;
            }
            return fullDate;
        }
        #endregion

        /// <summary>
        /// Replace Short URl to Html String
        /// </summary>
        /// <param name="pHtmlString">pHtmlString</param>
        /// <returns>String</returns>
        public string ReplaceShortURltoHtmlString(string pHtmlString)
        {
            try
            {
                if (pHtmlString.StartsWith("&lt;_"))
                {
                    pHtmlString = pHtmlString.Replace("&lt;_", "<");
                    pHtmlString = pHtmlString.Replace("&gt;_", ">");
                    pHtmlString = pHtmlString.Replace("&quots;_", "'");
                }

                Regex urlRegEx = new Regex("http(s)?://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\/\\?\\.\\:\\;\'\\,]*)?", RegexOptions.IgnoreCase);
                MatchCollection urls = urlRegEx.Matches(pHtmlString);
                foreach (Match url in urls)
                {
                    if (pHtmlString.IndexOf(url.ToString()) > 0)
                    {
                        var isImgURL = pHtmlString.Substring(Convert.ToInt32(pHtmlString.IndexOf(url.ToString())) - 8, url.Length + 8);
                        if (!isImgURL.Contains("src") && !isImgURL.Contains(".png") && !isImgURL.Contains(".jpeg")
                            && !isImgURL.Contains(".jpg") && !isImgURL.Contains(".gif") && !isImgURL.Contains(".bmp")
                            && !isImgURL.Contains(".tiff") && !isImgURL.Contains(".exif") && !isImgURL.Contains(".bpg"))
                        {
                            if (!isImgURL.ToLower().Contains("upload/locatedimages")
                                && !isImgURL.ToLower().Contains("upload/logo")
                                && !isImgURL.ToLower().Contains("videoformat"))
                            {
                                /*
                                string shortUrl = longurlToshorturl(Convert.ToString(url));
                                if (string.IsNullOrEmpty(shortUrl))
                                    shortUrl = Convert.ToString(url);

                                if (shortUrl.Contains("+target="))
                                {
                                    shortUrl = shortUrl.Replace("+target=", "");
                                }

                                if (isImgURL.Contains("href"))
                                    pHtmlString = pHtmlString.Replace(Convert.ToString(url), shortUrl);
                                else
                                    pHtmlString = pHtmlString.Replace(Convert.ToString(url), "<a target='_blank' href='" + shortUrl + "'>" + shortUrl + "</a>");
                                /*/

                                /*** Links Convert to Hyper Links Only for Textblock & { ock; } means textblock adding time span checking ***/
                                if (isImgURL.Contains("href"))
                                {
                                    string shortUrl = longurlToshorturl(Convert.ToString(url));
                                    if (string.IsNullOrEmpty(shortUrl))
                                        shortUrl = Convert.ToString(url);

                                    if (shortUrl.Contains("+target="))
                                    {
                                        shortUrl = shortUrl.Replace("+target=", "");
                                    }
                                    pHtmlString = pHtmlString.Replace(Convert.ToString(url), shortUrl);
                                }
                                else if (isImgURL.Contains("ock;"))
                                {
                                    string shortUrl = longurlToshorturl(Convert.ToString(url));
                                    if (string.IsNullOrEmpty(shortUrl))
                                        shortUrl = Convert.ToString(url);

                                    if (shortUrl.Contains("+target="))
                                    {
                                        shortUrl = shortUrl.Replace("+target=", "");
                                    }

                                    pHtmlString = pHtmlString.Replace("block;\">" + Convert.ToString(url), "block;\"><a target='_blank' href='" + shortUrl + "'>" + shortUrl + "</a>");
                                    pHtmlString = pHtmlString.Replace("block; \">" + Convert.ToString(url), "block;\"><a target='_blank' href='" + shortUrl + "'>" + shortUrl + "</a>");

                                }//

                            }
                        }


                    }
                }



            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "ReplaceShortURltoHtmlString.cs", "CommonBLL()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return pHtmlString;
        }

        /// <summary>
        /// Make Valid File Name
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <returns>String</returns>
        public string MakeValidFileName(string fileName)
        {
            string invalidChars = Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0}]+", invalidChars);
            fileName = Regex.Replace(fileName, invalidReStr, "_").Replace(";", "").Replace(",", "");
            return fileName;
        }

        /// <summary>
        /// Genarate Thumbnail For App
        /// </summary>
        /// <param name="moduleID">moduleID</param>
        /// <param name="profileID">profileID</param>
        /// <param name="moduleType">moduleType</param>
        /// <param name="htmlString">htmlString</param>
        public void GenarateThumbnailForApp(int moduleID, int profileID, string moduleType, string htmlString)
        {
            try
            {
                ErrorHandling("LOG ", "CommonBLL.cs", "GenarateThumbnailForApp()", string.Empty, string.Empty, string.Empty, string.Empty);


                string uspdUploadFolderPath = HttpContext.Current.Server.MapPath("~/upload");
                string rootPath = GetConfigSettings(Convert.ToString(profileID), "Paths", "RootPath");
                string thumbVirtualPath = uspdUploadFolderPath + "/AppThumbs/" + moduleType + "/" + profileID;

                if (!Directory.Exists(thumbVirtualPath))
                {
                    Directory.CreateDirectory(thumbVirtualPath);
                }

                //List<Uri> links = new List<Uri>();
                string imagePath = "";
                string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>"; //<\s*?img\s+[^>]*?\s*src\s*=\s*(["'])((\\?+.)*?)\1[^>]*?>
                MatchCollection matchesImgSrc = Regex.Matches(htmlString, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in matchesImgSrc)
                {
                    imagePath = m.Groups[1].Value;
                    if (imagePath.ToLower().Contains("images/located.png") || imagePath.ToLower().Contains("images/cleared.png"))
                    {

                    }
                    else
                    { break; }
                }
                if (htmlString.StartsWith("http"))
                { imagePath = htmlString; }

                thumbVirtualPath = thumbVirtualPath + "/" + moduleID + ".jpg";
                try
                {
                    if (File.Exists(thumbVirtualPath))
                    {
                        File.Delete(thumbVirtualPath);
                    }
                }
                catch (Exception /*ex*/)
                { }


                int width = Int32.Parse(ConfigurationManager.AppSettings.Get("AppThumbWidth"));
                int height = Int32.Parse(ConfigurationManager.AppSettings.Get("AppThumbHeight"));

                // Folder Names:: CustomModules   or  Bulletins  or  Events  or CalendarAddOns
                string image = string.Empty;
                image = imagePath;
                if (image == "")   //if image exists in html string
                {
                    /*
                    image = uspdUploadFolderPath + "/Upload/" + moduleType + "/" + profileID + "/" + moduleID + ".jpg";
                    if (File.Exists(image))
                    {
                        //Creating thumbnai
                        System.Drawing.Image img = System.Drawing.Image.FromFile(image);
                        System.Drawing.Image thumb = img.GetThumbnailImage(100, 100, null, IntPtr.Zero);
                        img.Dispose();

                        thumb.Save(thumbVirtualPath);
                    }

                    */
                }
                else
                {
                    string imgName = Path.GetFileName(image);

                    string FOlderPath = imagePath.ToLower().Substring(imagePath.ToLower().LastIndexOf("upload"));
                    FOlderPath = FOlderPath.Replace("upload", "");

                    string imgFullPath = uspdUploadFolderPath + FOlderPath;

                    if (File.Exists(imgFullPath))
                    {
                        //Creating thumbnai
                        System.Drawing.Image img = System.Drawing.Image.FromFile(imgFullPath);
                        System.Drawing.Image thumb = img.GetThumbnailImage(width, height, null, IntPtr.Zero);
                        img.Dispose();

                        thumb.Save(thumbVirtualPath);
                    }

                }

                //imgRootPath = rootPath + "/Upload/AppThumbs/" + moduleType + "/" + profileID + "/" + moduleID + ".jpg?GUID=" + Guid.NewGuid();

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "CommonBLL.cs", "GenarateThumbnailForApp()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        /// <summary>
        /// User Permission return
        /// </summary>
        /// <param name="AssociateID">AssociateID</param>
        /// <param name="moduleID">moduleID</param>
        /// <param name="moduleName">moduleName</param>
        /// <returns>String</returns>
        public string returnUserPermission(int AssociateID, int moduleID, string moduleName)
        {
            //USPD-1107 and USPD-1116 Permission related Changes
            string retValue = string.Empty;
            string ModuleName = string.Empty;
            string segName = string.Empty;
            AddOnBLL objAddOn = new AddOnBLL();
            AgencyBLL agencyobj = new AgencyBLL();
            DataTable dtAddOn = new DataTable();
            if (moduleName == "Bulletins") //Bulletins
                ModuleName = "Bulletins";
            else if (moduleName == "Events")    //EventCalendar
                ModuleName = "EventCalendar";
            else if (moduleName == "Surveys")   //Surveys
                ModuleName = "Surveys";
            else if (moduleName == "AppSettings") //SocialMedia
                ModuleName = CommonModules.AppSettings;//"App Settings";
            else if (moduleName == "ManageButtons")
                ModuleName = CommonModules.ManageButtons;//"Manage Buttons";
            else if (moduleName == "PushNotifications")
                ModuleName = CommonModules.PushNotifications;//"Push Notifications";
            else if (moduleName == "Contacts")
                ModuleName = CommonModules.Contacts;//"Contacts";
            else if (moduleName == "ManageMessageReceipt")
                ModuleName = CommonModules.ManageMessageReceipt; //"Manage Message Receipt";
            else if (moduleName == "Downloads")
                ModuleName = CommonModules.Downloads;//"Downloads";
            else if (moduleName == "PrivateInvitation")
                ModuleName = CommonModules.PrivateAddOnInvs; //"Access Private AddOn Invitations";
            else if (moduleName == CommonModules.AccessMarketPlace)
                ModuleName = CommonModules.AccessMarketPlace; //"Access MarketPlace";
            else if (moduleName == CommonModules.ManageAssociates)
                ModuleName = CommonModules.ManageAssociates; //"Access Manage Associates";
            else if (moduleName == CommonModules.AppBackgroundImage)
                ModuleName = CommonModules.AppBackgroundImage; //"App Background Image";
            else if (moduleName == CommonModules.Home)
                ModuleName = CommonModules.Home;//"Home";
            else if (moduleName == CommonModules.AboutUs)
                ModuleName = CommonModules.AboutUs;//"Our Mission";
            else if (moduleName == CommonModules.WebLinks)
                ModuleName = CommonModules.WebLinks;//"Links";
            else if (moduleName == CommonModules.SocialMedia)
                ModuleName = CommonModules.SocialMedia;//"Social";
            else if (moduleName == CommonModules.PublicCallAddOns)
                ModuleName = CommonModules.PublicCallAddOns;
            else if (moduleName == CommonModules.SmartConnectCategories)
                ModuleName = CommonModules.SmartConnectCategories;//"SmartConnect Categories"
            else if (moduleID > 0)
            {
                dtAddOn = objAddOn.GetAddOnById(moduleID);
                if (dtAddOn.Rows.Count == 1)
                    ModuleName = dtAddOn.Rows[0]["TabName"].ToString();
            }
            else
                ModuleName = moduleName;
            DataTable dtpermissions = agencyobj.GetPermissionsByAssociateId(AssociateID);
            if (dtpermissions.Rows.Count > 0)
            {
                for (int i = 0; i < dtpermissions.Rows.Count; i++)
                {
                    segName = dtpermissions.Rows[i]["ButtonType"].ToString().Trim();
                    if (moduleName == "AppSettings" || moduleName == "ManageButtons" ||
                        moduleName == "PushNotifications" || moduleName == "Contacts" ||
                        moduleName == "ManageMessageReceipt" || moduleName == "Downloads" || moduleName == "PrivateInvitation" ||
                        moduleName == CommonModules.AccessMarketPlace || moduleName == CommonModules.ManageAssociates ||
                        moduleName == CommonModules.AppBackgroundImage || moduleName == CommonModules.Home || moduleName == CommonModules.AboutUs ||
                        moduleName == CommonModules.WebLinks || moduleName == CommonModules.SocialMedia || moduleName == CommonModules.BillingHistory || moduleName == CommonModules.SmartConnectCategories)
                    {
                        if (segName == ModuleName)
                        {
                            if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                                retValue = "P";
                            else
                                retValue = "A";
                            break;
                        }
                    }
                    if (segName == "CalendarAddOn" || segName == "AddOn" || segName == "PrivateAddOn" || segName == "PrivateCallAddOns" || segName == "PublicCallAddOns" || segName == "PrivateSmartConnectAddOns")
                    {
                        if (dtpermissions.Rows[i]["ModuleName"].ToString().Trim() == ModuleName)
                        {
                            if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                                retValue = "A";
                            if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                                retValue = "P";
                            break;
                        }
                    }
                    if (segName == ModuleName)
                    {
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsAuthor"].ToString()))
                            retValue = "A";
                        if (Convert.ToBoolean(dtpermissions.Rows[i]["IsPublisher"].ToString()))
                            retValue = "P";
                        break;
                    }
                }
            }
            return retValue;
        }

        /// <summary>
        /// Send Private Module Invitation Mails
        /// </summary>
        /// <param name="toEmailIDs">toEmailIDs</param>
        /// <param name="DomainName">DomainName</param>
        /// <param name="pInvitationID">pInvitationID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="TabName">TabName</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pRootPath">pRootPath</param>
        /// <param name="pToMobileNumber">pToMobileNumber</param>
        /// <returns>String</returns>
        public string SendPrivateModule_InvitationMails(string toEmailIDs, string DomainName, string pInvitationID,
            int pProfileID, string TabName, int pUserID, string pRootPath, string pToMobileNumber, bool IsPrivateCall = false)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

            try
            {
                string result = "";

                BusinessBLL objBusinessBLL = new BusinessBLL();
                string AppStore_AppName = "";
                string CountryPhoneCode = "";
                string ProfileName = "";

                DataTable dtStoreDetails = objBusinessBLL.GetStoreDetailsById(pUserID);
                if (dtStoreDetails.Rows.Count > 0)
                {
                    AppStore_AppName = Convert.ToString(dtStoreDetails.Rows[0]["App_DisplayName"]);
                }

                DataTable dtProfileDetails = objBusinessBLL.GetProfileDetailsByProfileID(pProfileID);

                if (dtProfileDetails.Rows.Count > 0)
                {
                    CountryPhoneCode = Convert.ToString(dtProfileDetails.Rows[0]["Country_Code"]);
                    ProfileName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_name"]);
                }

                /*
                StreamReader re = File.OpenText(strfilepath + "PrivateModuleSendInvitation.txt");
                StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
                string msgbody = string.Empty;
                string content = string.Empty;
                string desclaimer = string.Empty;
                while ((desclaimer = reDeclaimer.ReadLine()) != null)
                {
                    msgbody = msgbody + desclaimer;
                }

                msgbody = msgbody.Replace("nowrap", "");
                msgbody = msgbody.Replace("width=\"470px\"", "width=\"100%\" style=\"max-width:470px;\"");

                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    content = content + input + "<BR>";
                }
                */

                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
                StreamReader re = null;
                if (IsPrivateCall)
                    re = File.OpenText(strfilepath + "PrivateCallSMSInvitation.txt");
                else
                    re = File.OpenText(strfilepath + "PrivateModuleSMSInvitation.txt");
                string content = string.Empty;
                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    content = content + input;
                }

                string AppUniqueName = "";

                DataTable dtAppDisplayName = PrivateModuleDAL.GetAppDisplayName(pProfileID);
                if (dtAppDisplayName.Rows.Count > 0)
                {
                    AppUniqueName = Convert.ToString(dtAppDisplayName.Rows[0]["App_Name"]);
                }
                else
                {
                    AppUniqueName = HttpContext.Current.Session["VerticalDomain"].ToString();
                }

                pToMobileNumber = pToMobileNumber.Replace(" ", "");

                //***  ppdhub://?InvitationID=D/xP9Y7JPEc=&Status=gEOz4I+vQqVdAbpWEFEmEQ==
                string AcceptedLink = pRootPath + "/PrivateModuleInvitationResponse.aspx?AppName=" + AppUniqueName + "&InvitationID=" + EncryptDecrypt.DESEncrypt(pInvitationID)
                    + "&Status=" + EncryptDecrypt.DESEncrypt(PrivateModule_InvitedStatus.AcceptedStatus.ToString()) + "&PID=" + EncryptDecrypt.DESEncrypt(pProfileID.ToString()) + "&MobileNumber=" + (EncryptDecrypt.DESEncrypt(pToMobileNumber).ToString());

                //AppUniqueName.ToLower() + "://?InvitationID=" + EncryptDecrypt.DESEncrypt(pInvitationID) + "&Status=" + EncryptDecrypt.DESEncrypt(PrivateModule_InvitedStatus.AcceptedStatus.ToString()); ;
                // string RejectedLink = pRootPath + "/PrivateModuleInvitationResponse.aspx?AppName=" + AppUniqueName + "&InvitationID=" + EncryptDecrypt.DESEncrypt(pInvitationID) + "&Status=" + EncryptDecrypt.DESEncrypt(PrivateModule_InvitedStatus.CancelledStatus.ToString()) + "&PID=" + EncryptDecrypt.DESEncrypt(pProfileID.ToString());


                AcceptedLink = longurlToshorturl(AcceptedLink);
                string InstallLink = GetMobileAppUrl(DomainName, pProfileID);


                content = content.Replace("#ProfileName#", ProfileName);
                content = content.Replace("#InstallationLink#", InstallLink);
                content = content.Replace("#SetupLink#", AcceptedLink);

                #region Email Invitaion

                /*
                 * 
                msgbody = msgbody.Replace("#msgBody#", content);
                msgbody = msgbody.Replace("#ProfileName#", ProfileName);
                msgbody = msgbody.Replace("#AppName#", AppStore_AppName);

                msgbody = msgbody.Replace("#AppInstallLink#", "<a target='_blank' href='" + InstallLink + "'><IMG src='" + pRootPath + "/Images/installapp.png'/></a>");
                msgbody = msgbody.Replace("#SetupLink#", "<a target='_new' href='" + AcceptedLink + "'><IMG onclick='window.open(" + AcceptedLink + ")' src='" + pRootPath + "/Images/setup.png'/></a>");
                msgbody = msgbody.Replace("#NoThanksLink#", "<a target='_new' href='" + RejectedLink + "'><IMG onclick='window.open(" + RejectedLink + ")' src='" + pRootPath + "/Images/decline.png'/></a>");

                string pBody = msgbody;
                string pSubject = "Email Invitation to view PRIVATE Button.";

                // *** Get SMTP server credentials *** //
                DataTable dtConfigs = CommonDAL.GetVerticalConfigsByType(DomainName, "SMTPServer");
                string host = ConfigurationManager.AppSettings.Get("SmtpServerName");
                string hostcr = EncryptDecrypt.DESDecrypt(ConfigurationManager.AppSettings.Get("SmtpServer"));
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "SmtpServerName")
                            host = row[1].ToString();
                        else if (row[0].ToString() == "SmtpServerCr")
                            hostcr = EncryptDecrypt.DESDecrypt(row[1].ToString());

                    }
                }

                string FromEmailInfo = "";
                string fromDisplayName = "";

                DataTable dtConfigsemails = CommonDAL.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                        {
                            FromEmailInfo = row[1].ToString();
                            break;
                        }
                    }
                }

                System.Net.Mail.SmtpClient oSmtlClient = new System.Net.Mail.SmtpClient();
                oSmtlClient.Host = host;
                oSmtlClient.Credentials = new System.Net.NetworkCredential(FromEmailInfo, hostcr);
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.From = new System.Net.Mail.MailAddress(FromEmailInfo, fromDisplayName);

                string[] strto = toEmailIDs.Split(',');
                for (int i = 0; i < strto.Length; i++)
                {
                    mailMessage.To.Add(new System.Net.Mail.MailAddress(strto[i].Trim()));
                }

                mailMessage.Body = pBody;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = System.Net.Mail.MailPriority.Normal;
                mailMessage.Subject = pSubject;
                oSmtlClient.Send(mailMessage);

                */
                #endregion

                try
                {

                    result = SendOTPMessage(CountryPhoneCode, pToMobileNumber, content, pProfileID, "SMS Invitation");
                    //  result = "Success";
                }
                catch (Exception ex)
                {
                    //Error 
                    objInBuiltData.ErrorHandling("ERROR", "2CommonBLL.cs", "SendPrivateModule_InvitationMails", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                    result = "Failure";
                }
                return result;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "3CommonBLL.cs", "SendPrivateModule_InvitationMails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

                return "";
            }


        }

        public string SendOTPMessage(string CountryPhoneCode, string pToMobileNumber, string content, int pProfileID, string methodName)
        {
            string result = "success";
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            // Find your Account Sid and Auth Token at twilio.com/user/account
            string AccountSid = ConfigurationManager.AppSettings.Get("SMSAccountSid").ToString();
            string AuthToken = ConfigurationManager.AppSettings.Get("SMSAuthToken").ToString();
            string FromNumber = ConfigurationManager.AppSettings.Get("FromNumber").ToString();

            try
            {
                var twilio = new TwilioRestClient(AccountSid, AuthToken);
                var message = twilio.SendMessage(FromNumber, (CountryPhoneCode + pToMobileNumber), content, "");

                CommonDAL.Insert_OTP_Logs(content, pProfileID, 0, "", pToMobileNumber, "", "", methodName);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "1CommonBLL.cs", "sendMessage", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                result = "Error";
            }
            return result;
        }

        /// <summary>
        /// Get Mobile App Url
        /// </summary>
        /// <param name="domainName">domainName</param>
        /// <param name="profileId">profileId</param>
        /// <returns>String</returns>
        private string GetMobileAppUrl(string domainName, int profileId)
        {
            DataTable dtAppStoresLinks = BusinessDAL.GetAppStoresLinks(profileId);
            bool isAppUrlExists = true;
            string storeUrl = "";
            if (dtAppStoresLinks.Rows.Count > 0)
            {
                storeUrl = Convert.ToString(dtAppStoresLinks.Rows[0]["Store_Url"]).Trim();
                if (storeUrl != "")
                    isAppUrlExists = false;
            }
            if (isAppUrlExists)
            {
                if (domainName.ToLower().Contains("uspdhub"))
                    storeUrl = ConfigurationManager.AppSettings["USPDhubAppurl"];
                else if (domainName.ToLower().Contains("inschoolhub"))
                    storeUrl = ConfigurationManager.AppSettings["InSchoolHubAppurl"];
                else if (domainName.ToLower().Contains("twovie"))
                    storeUrl = ConfigurationManager.AppSettings["TwoVieAppurl"];
                else if (domainName.ToLower().Contains("myyouthhub"))
                    storeUrl = ConfigurationManager.AppSettings["MyYouthHubAppurl"];
                else if (domainName.ToLower().Contains("inschoolalert"))
                    storeUrl = ConfigurationManager.AppSettings["inSchoolAlertLiteAppurl"];
            }

            CommonDAL.Insert_OTP_Logs(storeUrl, 0, 0, "", "", "", "", "StoreUrl");

            return storeUrl;
        }

        /// <summary>
        /// Get Image Rotate Flip
        /// </summary>
        /// <param name="FUUserImages">FUUserImages</param>
        /// <param name="saveimagepath">saveimagepath</param>
        /// <param name="isSaveImage">isSaveImage</param>
        public void GetImageRotateFlip(System.Web.UI.WebControls.FileUpload FUUserImages, string saveimagepath, bool isSaveImage)
        {
            try
            {
                if (FUUserImages.PostedFile != null)
                {
                    string FileName = FUUserImages.FileName;
                    byte[] imageData = new byte[FUUserImages.PostedFile.ContentLength];
                    FUUserImages.PostedFile.InputStream.Read(imageData, 0, FUUserImages.PostedFile.ContentLength);

                    MemoryStream ms = new MemoryStream(imageData);
                    Image originalImage = Image.FromStream(ms);
                    SaveFlipImage(originalImage, saveimagepath, isSaveImage);
                }
            }
            catch { }
        }

        /// <summary>
        /// Get Image Rotate Flip By Path
        /// </summary>
        /// <param name="imgPath">imgPath</param>
        /// <param name="saveimagepath">saveimagepath</param>
        /// <param name="isSaveImage">isSaveImage</param>
        public void GetImageRotateFlipByPath(string imgPath, string saveimagepath, bool isSaveImage)
        {
            try
            {
                byte[] imageData = File.ReadAllBytes(imgPath);
                MemoryStream ms = new MemoryStream(imageData);
                Image originalImage = Image.FromStream(ms);
                SaveFlipImage(originalImage, saveimagepath, isSaveImage);

            }
            catch { }
        }

        /// <summary>
        /// Save Flip Image
        /// </summary>
        /// <param name="originalImage">originalImage</param>
        /// <param name="saveimagepath">saveimagepath</param>
        /// <param name="isSaveImage">isSaveImage</param>
        public void SaveFlipImage(Image originalImage, string saveimagepath, bool isSaveImage)
        {
            try
            {
                if (originalImage.PropertyIdList.Contains(0x0112))
                {
                    int rotationValue = originalImage.GetPropertyItem(0x0112).Value[0];
                    switch (rotationValue)
                    {
                        case 1: // landscape, do nothing
                            break;

                        case 8: // rotated 90 right
                            // de-rotate:
                            originalImage.RotateFlip(rotateFlipType: RotateFlipType.Rotate270FlipNone);
                            break;

                        case 3: // bottoms up
                            originalImage.RotateFlip(rotateFlipType: RotateFlipType.Rotate180FlipNone);
                            break;

                        case 6: // rotated 90 left
                            originalImage.RotateFlip(rotateFlipType: RotateFlipType.Rotate90FlipNone);
                            break;
                    }
                    isSaveImage = true;

                }
                if (isSaveImage)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    originalImage.Save(saveimagepath);
                }
            }
            catch { }
        }

        /// <summary>
        /// Get Call Preview Text
        /// </summary>
        /// <returns>String</returns>
        public string GetCallPreviewText()
        {
            try
            {
                string str = "";
                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\CallIndexPreview.txt";
                StreamReader re = File.OpenText(strfilepath);
                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    str = str + input;
                }
                re.Close();
                re.Dispose();

                return str;
            }
            catch (Exception /*ex*/)
            {
                return "";
            }
        }

        public string GetPublicCallPreviewText()
        {
            try
            {
                string str = "";
                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\PublicCallIndexPreview.txt";
                StreamReader re = File.OpenText(strfilepath);
                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    str = str + input;
                }
                re.Close();
                re.Dispose();

                return str;
            }
            catch (Exception /*ex*/)
            {
                return "";
            }
        }

        public void GenarateThumbnailForPublicCallApp(int moduleID, int profileID, string moduleType, string htmlString)
        {
            try
            {
                ErrorHandling("LOG ", "CommonBLL.cs", "GenarateThumbnailForPublicCallApp()", string.Empty, string.Empty, string.Empty, string.Empty);


                string uspdUploadFolderPath = HttpContext.Current.Server.MapPath("~/upload");
                string rootPath = GetConfigSettings(Convert.ToString(profileID), "Paths", "RootPath");
                string thumbVirtualPath = uspdUploadFolderPath + "/AppThumbs/" + moduleType + "/" + profileID;

                if (!Directory.Exists(thumbVirtualPath))
                {
                    Directory.CreateDirectory(thumbVirtualPath);
                }

                //List<Uri> links = new List<Uri>();
                string imagePath = "";
                string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>"; //<\s*?img\s+[^>]*?\s*src\s*=\s*(["'])((\\?+.)*?)\1[^>]*?>
                MatchCollection matchesImgSrc = Regex.Matches(htmlString, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in matchesImgSrc)
                {
                    imagePath = m.Groups[1].Value;
                    if (imagePath.ToLower().Contains("images/located.png") || imagePath.ToLower().Contains("images/cleared.png"))
                    {

                    }
                    else
                    { break; }
                }
                if (htmlString.StartsWith("http"))
                { imagePath = htmlString; }

                thumbVirtualPath = thumbVirtualPath + "/" + moduleID + ".jpg";
                try
                {
                    if (File.Exists(thumbVirtualPath))
                    {
                        File.Delete(thumbVirtualPath);
                    }
                }
                catch (Exception /*ex*/)
                { }


                int width = Int32.Parse(ConfigurationManager.AppSettings.Get("AppThumbWidth"));
                int height = Int32.Parse(ConfigurationManager.AppSettings.Get("AppThumbHeight"));

                // Folder Names:: CustomModules   or  Bulletins  or  Events  or CalendarAddOns
                string image = string.Empty;
                image = imagePath;
                if (image == "")   //if image exists in html string
                {
                    /*
                    image = uspdUploadFolderPath + "/Upload/" + moduleType + "/" + profileID + "/" + moduleID + ".jpg";
                    if (File.Exists(image))
                    {
                        //Creating thumbnai
                        System.Drawing.Image img = System.Drawing.Image.FromFile(image);
                        System.Drawing.Image thumb = img.GetThumbnailImage(100, 100, null, IntPtr.Zero);
                        img.Dispose();

                        thumb.Save(thumbVirtualPath);
                    }

                    */
                }
                else
                {
                    string imgName = Path.GetFileName(image);

                    string FOlderPath = imagePath.ToLower().Substring(imagePath.ToLower().LastIndexOf("upload"));
                    FOlderPath = FOlderPath.Replace("upload", "");

                    string imgFullPath = uspdUploadFolderPath + FOlderPath;

                    if (File.Exists(imgFullPath))
                    {
                        //Creating thumbnai
                        System.Drawing.Image img = System.Drawing.Image.FromFile(imgFullPath);
                        System.Drawing.Image thumb = img.GetThumbnailImage(width, height, null, IntPtr.Zero);
                        img.Dispose();

                        thumb.Save(thumbVirtualPath);
                    }

                }

                //imgRootPath = rootPath + "/Upload/AppThumbs/" + moduleType + "/" + profileID + "/" + moduleID + ".jpg?GUID=" + Guid.NewGuid();

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "CommonBLL.cs", "GenarateThumbnailForApp()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public DataTable GetCallModuleDefaultitems(string domainName, string pModuleType)
        {
            return CommonDAL.GetCallModuleDefaultitems(domainName, pModuleType);
        }
        public int InsertUpdatePublicCallIndexData(int CustomID, int ProfileID, int UserID, string Title, string ImageUrls, string MobileNumber, bool IsAutoEmail, string Email_Description, string Email_GroupIDs,
           bool IsAutoTextMessage, string SMS_Description, string SMS_GroupIDs, bool IsGPSInformation, bool IsAllPhoneInformation, bool IsActive, int CreatedUser, int ModifyUser, int UserModuleID, bool IsDeleted, bool IsPublish,
               bool IsPublic, string Email_Subject, string SMS_Subject, string Description, string PreviewHtml, bool IsVisible, bool IsInitiatesPhoneCall, bool IsPredefinedMessage, bool IsAnonymous, bool IsUploadImage)
        {
            int returnID = CommonDAL.InsertUpdatePublicCallIndexData(CustomID, ProfileID, UserID, Title, ImageUrls, MobileNumber, IsAutoEmail, Email_Description, Email_GroupIDs,
                   IsAutoTextMessage, SMS_Description, SMS_GroupIDs, IsGPSInformation, IsAllPhoneInformation, IsActive, CreatedUser, ModifyUser, UserModuleID, IsDeleted, IsPublish,
                    IsPublic, Email_Subject, SMS_Subject, Description, PreviewHtml, IsVisible, IsInitiatesPhoneCall, IsPredefinedMessage, IsAnonymous, IsUploadImage);

            // Genarate App Thumb 
            GenarateThumbnailForPublicCallApp(returnID, ProfileID, "PublicCallModules", ImageUrls);
            if (returnID > 0)
            {
                // Update Long URL to Short URL
                string outerURL = GetConfigSettings(Convert.ToString(ProfileID), "Paths", "RootPath");
                string ShortenURL = outerURL + "/OnlinePublicCallItem.aspx?CID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(CustomID)).Replace("=", "irhmalli").Replace("+", "irhPASS");

                ShortenURL = longurlToshorturl(ShortenURL);
                CommonDAL.UpdateShortenURl(CustomID, ShortenURL, "PublicCallAddOns");
            }

            return returnID;

        }

        public void InsertDefaultCallItems(int UserModuleID, int ProfileID, int UserID, string DomainName)
        {
            CommonBLL cmbobj = new CommonBLL();
            int GroupID = 0;


            string callModuleDirectory = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "/Upload/PublicCallModules/" + ProfileID;
            try
            {
                if (!System.IO.Directory.Exists(callModuleDirectory))
                {
                    System.IO.Directory.CreateDirectory(callModuleDirectory);
                }
                callModuleDirectory = callModuleDirectory + "/" + UserModuleID;
                if (!System.IO.Directory.Exists(callModuleDirectory))
                {
                    System.IO.Directory.CreateDirectory(callModuleDirectory);
                }
                string sourcePath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "/Upload/DefaultPublicCallModules/" + DomainName;
                string fileName = "";
                string destFile = "";
                if (Directory.Exists(sourcePath))
                {
                    foreach (var srcPath in Directory.GetFiles(sourcePath))
                    {
                        fileName = System.IO.Path.GetFileName(srcPath);
                        destFile = System.IO.Path.Combine(callModuleDirectory, fileName);
                        File.Copy(srcPath, destFile, true);
                    }
                }

                string RootPath = cmbobj.GetConfigSettings(ProfileID.ToString(), "Paths", "RootPath"); ;
                cmbobj.AddCallModuleDefaultImages(UserModuleID, ProfileID, UserID, UserID, WebConstants.Purchase_PublicCallAddOns);
                DataTable dtCallModuleDefaultItems = cmbobj.GetCallModuleDefaultitems(DomainName, WebConstants.Purchase_PublicCallAddOns);
                if (dtCallModuleDefaultItems.Rows.Count > 0)
                {
                    bool IsIntiatePhoneCall = true;
                    bool IsCustomPredefinedMessage = false;

                    string imagePath = RootPath + "/Upload/PublicCallModules/" + ProfileID + "/" + UserModuleID + "/";
                    bool IsAnonymous = false; bool IsUploadImage = false;
                    for (int i = 0; i < dtCallModuleDefaultItems.Rows.Count; i++)
                    {
                        cmbobj.InsertUpdatePublicCallIndexData(0, ProfileID, UserID, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["CallTitle"]), imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["MobileNumber"]), false,
                            Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailDescription"]), GroupID.ToString(),
                                 false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSDescription"]), GroupID.ToString(), false, false,
                                true, UserID, UserID, UserModuleID, false, false, false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailSubject"]),
                                Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["Description"]),
                                Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PreviewHtml"]).Replace("##Rootpath##", RootPath).Replace("##ImagePathUrl##", imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"])),
                                false, IsIntiatePhoneCall, IsCustomPredefinedMessage, IsAnonymous, IsUploadImage);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonDAL.InsertErrorLog("ERROR", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "ReviewMembership.aspx.cs", "InsertDefaultCallItems");
            }
        }

        public int InsertUserCustomModules(int ProfileID, int UserID, int createdUser, int module, string appIcon, string tabName, bool isActive,
          DateTime createdDate, DateTime modifyDate, DateTime expiredDate, string manageUrl, bool isHasChilds, string pButtonType, string purchaseType, string pAccessType = "", int pOrderDetailsID = 0)
        {
            return CommonDAL.InsertUserCustomModules(ProfileID, UserID, createdUser, module, appIcon, tabName, isActive, createdDate, modifyDate, expiredDate, pButtonType, purchaseType, manageUrl, isHasChilds, pAccessType, pOrderDetailsID);
        }

        /// <summary>
        /// Send Private Module Invitation Mails
        /// </summary>
        /// <param name="toEmailIDs">toEmailIDs</param>
        /// <param name="DomainName">DomainName</param>
        /// <param name="pInvitationID">pInvitationID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="TabName">TabName</param>
        /// <param name="pUserID">pUserID</param>
        /// <param name="pRootPath">pRootPath</param>
        /// <param name="pToMobileNumber">pToMobileNumber</param>
        /// <returns>String</returns>
        public string SendPrivateSmartConnect_InvitationMails(string toEmailIDs, string DomainName, string pInvitationID,
            int pProfileID, string TabName, int pUserID, string pRootPath, string pToMobileNumber)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

            try
            {
                string result = "";

                BusinessBLL objBusinessBLL = new BusinessBLL();
                string AppStore_AppName = "";
                string CountryPhoneCode = "";
                string ProfileName = "";

                DataTable dtStoreDetails = objBusinessBLL.GetStoreDetailsById(pUserID);
                if (dtStoreDetails.Rows.Count > 0)
                {
                    AppStore_AppName = Convert.ToString(dtStoreDetails.Rows[0]["App_DisplayName"]);
                }

                DataTable dtProfileDetails = objBusinessBLL.GetProfileDetailsByProfileID(pProfileID);

                if (dtProfileDetails.Rows.Count > 0)
                {
                    CountryPhoneCode = Convert.ToString(dtProfileDetails.Rows[0]["Country_Code"]);
                    ProfileName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_name"]);
                }


                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
                StreamReader re = null;
                re = File.OpenText(strfilepath + "PrivateSCSMSInvitation.txt");
                string content = string.Empty;
                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    content = content + input;
                }

                string AppUniqueName = "";

                DataTable dtAppDisplayName = PrivateModuleDAL.GetAppDisplayName(pProfileID);
                if (dtAppDisplayName.Rows.Count > 0)
                {
                    AppUniqueName = Convert.ToString(dtAppDisplayName.Rows[0]["App_Name"]);
                }
                else
                {
                    AppUniqueName = HttpContext.Current.Session["VerticalDomain"].ToString();
                }

                pToMobileNumber = pToMobileNumber.Replace(" ", "");

                //***  ppdhub://?InvitationID=D/xP9Y7JPEc=&Status=gEOz4I+vQqVdAbpWEFEmEQ==
                string AcceptedLink = pRootPath + "/PrivateModuleInvitationResponse.aspx?AppName=" + AppUniqueName + "&InvitationID=" + EncryptDecrypt.DESEncrypt(pInvitationID)
                    + "&Status=" + EncryptDecrypt.DESEncrypt(PrivateModule_InvitedStatus.AcceptedStatus.ToString()) + "&PID=" + EncryptDecrypt.DESEncrypt(pProfileID.ToString()) + "&MobileNumber=" + (EncryptDecrypt.DESEncrypt(pToMobileNumber).ToString());

                //AppUniqueName.ToLower() + "://?InvitationID=" + EncryptDecrypt.DESEncrypt(pInvitationID) + "&Status=" + EncryptDecrypt.DESEncrypt(PrivateModule_InvitedStatus.AcceptedStatus.ToString()); ;
                // string RejectedLink = pRootPath + "/PrivateModuleInvitationResponse.aspx?AppName=" + AppUniqueName + "&InvitationID=" + EncryptDecrypt.DESEncrypt(pInvitationID) + "&Status=" + EncryptDecrypt.DESEncrypt(PrivateModule_InvitedStatus.CancelledStatus.ToString()) + "&PID=" + EncryptDecrypt.DESEncrypt(pProfileID.ToString());


                AcceptedLink = longurlToshorturl(AcceptedLink);
                string InstallLink = GetMobileAppUrl(DomainName, pProfileID);


                content = content.Replace("#ProfileName#", ProfileName);
                content = content.Replace("#InstallationLink#", InstallLink);
                content = content.Replace("#SetupLink#", AcceptedLink);



                try
                {

                    result = SendOTPMessage(CountryPhoneCode, pToMobileNumber, content, pProfileID, "SMS Invitation");
                    //  result = "Success";
                }
                catch (Exception ex)
                {
                    //Error 
                    objInBuiltData.ErrorHandling("ERROR", "2CommonBLL.cs", "SendPrivateSmartConnect_InvitationMails", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                    result = "Failure";
                }
                return result;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "3CommonBLL.cs", "SendPrivateModule_InvitationMails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

                return "";
            }


        }


        #region Demo Videos
        /// <summary>
        /// Get All Videos
        /// </summary>
        /// <param name="searchVideo">searchVideo</param>
        /// <param name="domainName">domainName</param>
        /// <param name="start">start</param>
        /// <param name="end">end</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllVideos(string searchVideo, string domainName, int start, int end, string isLiteVersion)
        {
            return CommonDAL.GetAllVideos(searchVideo, domainName, start, end, isLiteVersion);
        }

        /// <summary>
        /// Insert Help Video Views
        /// </summary>
        /// <param name="videoId">videoId</param>
        /// <param name="profileId">profileId</param>
        public void InsertHelpVideoViews(int videoId, int profileId)
        {
            CommonDAL.InsertHelpVideoViews(videoId, profileId);
        }
        /// <summary>
        /// Get Lite Videos
        /// </summary>
        /// <param name="videoType">videoType</param>
        /// <param name="domainName">domainName</param>
        /// <returns>DataTable</returns>
        public DataTable GetLiteVideosByType(string videoType, string domainName)
        {
            return CommonDAL.GetLiteVideosByType(videoType, domainName);
        }
        #endregion


        #region Build WaterMark Image like Located & Cleared images



        #endregion



        #region Html to PDF print

        public string HtmlToPDF_Print(string pHtmlStr, string pTitle, string pPdfFileSavePath = "", bool pIsFileOpen = true)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            try
            {
                // New Logic azure htmml to pdf

                // Get the server IP and port
                String serverIP = ConfigurationManager.AppSettings.Get("Winnovative_serverIP");
                uint serverPort = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("Winnovative_serverPort"));

                // Create a HTML to PDF converter object with default settings
                HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter(serverIP, serverPort);
                htmlToPdfConverter.LicenseKey = ConfigurationManager.AppSettings.Get("WinnovativePDFKey");
                htmlToPdfConverter.HtmlViewerWidth = 650;
                //htmlToImageConverter.HtmlViewerHeight = 200;
                htmlToPdfConverter.PdfDocumentOptions.PdfPageSize = Winnovative.HtmlToPdfClient.PdfPageSize.A4;
                htmlToPdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;
                htmlToPdfConverter.PdfDocumentOptions.LeftMargin = 10;
                htmlToPdfConverter.PdfDocumentOptions.RightMargin = 10;
                htmlToPdfConverter.PdfDocumentOptions.TopMargin = 10;

                htmlToPdfConverter.NavigationTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Winnovative_NavigationTimeout"));
                htmlToPdfConverter.ConversionDelay = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Winnovative_ConversionDelay"));

                // The buffer to receive the generated PDF document
                byte[] outPdfBuffer = null;
                string baseUrl = "";

                string pdfilenameval = pTitle.ToString() + ".pdf"; ;
                if (pPdfFileSavePath.Trim() == string.Empty)
                {
                    pdfilenameval = pTitle.ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf"; ;
                    pPdfFileSavePath = HttpContext.Current.Server.MapPath("~/Upload/").ToString() + pdfilenameval;
                }

                if (!pdfilenameval.ToLower().EndsWith(".pdf"))
                { pdfilenameval = pdfilenameval + ".pdf"; }
                if (!pPdfFileSavePath.ToLower().EndsWith(".pdf"))
                { pPdfFileSavePath = pPdfFileSavePath + ".pdf"; }

                // Convert a HTML string with a base URL to a PDF document in a memory buffer
                outPdfBuffer = htmlToPdfConverter.ConvertHtml(pHtmlStr.ToString(), baseUrl);
                System.IO.File.WriteAllBytes(pPdfFileSavePath, outPdfBuffer);


                if (pIsFileOpen)
                {
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=" + pdfilenameval);
                    HttpContext.Current.Response.ContentType = "application/octet-stream"; ;
                    HttpContext.Current.Response.WriteFile(pPdfFileSavePath);
                    HttpContext.Current.Response.End();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "CommonBLL.cs", "HtmlToPDF_Print()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return "";
        }



        #endregion


        public string RemoveSpecialCharacters(string pValue)
        {
            pValue = Regex.Replace(pValue, @"[^0-9a-zA-Z.]+", "");
            return pValue;
        }

        public DataTable GetCountries()
        {
            return CommonDAL.GetCountries();
        }

        public bool IsPackageIncludeSetting(string pSettingName)
        {
            /*** <Settings IsLongLogo='false'  GettingIsDescription='false'  /> ***/


            bool returnValue = false;
            if (HttpContext.Current.Session["PackageSettings"] != null)
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(HttpContext.Current.Session["PackageSettings"].ToString());
                if (xmldoc.SelectSingleNode("Settings/@" + pSettingName) != null)
                {
                    returnValue = Convert.ToBoolean(xmldoc.SelectSingleNode("Settings/@" + pSettingName).Value);
                }
            }


            return returnValue;
        }

        public void InsertErrorLog(string pErrorType, string pMessage,
                 string pStrackTrace, string pInnerException, string pData, string pPageName, string pMethodName)
        {
            CommonDAL.InsertErrorLog(pErrorType, pMessage, pStrackTrace, pInnerException, pData, pPageName, pMethodName);
        }


        public string GetAddressByLatitude_Longitude(string pLatitude, string pLongitude)
        {
            string CurrentAddress = "";

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("http://maps.googleapis.com/maps/api/geocode/xml?latlng=" + pLatitude + "," + pLongitude + "&sensor=false");
                XmlNode element = doc.SelectSingleNode("//GeocodeResponse/status");
                if (element.InnerText == "ZERO_RESULTS")
                {
                    CurrentAddress = "";
                }
                else
                {
                    element = doc.SelectSingleNode("//GeocodeResponse/result/formatted_address");
                    if (((element).InnerText) != null && ((element).InnerText) != "")
                    {
                        string text = (element).InnerText;
                        string[] textdata = text.Split(',');
                        for (int i = 0; i < textdata.Length; i++)
                        {
                            if (CurrentAddress == "")
                                CurrentAddress = textdata[i].Trim().ToString();
                            else if ((textdata.Length - 2) == i)
                                CurrentAddress = CurrentAddress + "," + " " + textdata[i].Trim().ToString();
                            else
                                CurrentAddress = CurrentAddress + "," + "<br/>" + textdata[i].Trim().ToString();
                        }
                        CurrentAddress = CurrentAddress + ".";
                    }
                }
            }
            catch (Exception ex)
            {
                CurrentAddress = "";
                ErrorHandling("ERROR ", "CommonBLL.cs", "GetAddressByLatitude_Longitude()", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

            }
            return CurrentAddress;

        } //


        public DataTable GetSystemImages(string ModuleName, string DomainName)
        {
            return CommonDAL.GetSystemImages(ModuleName, DomainName);
        }

        public DataTable GetAllAppMessagesCountForDashboard(int pUserID, int pProfileID)
        {
            return CommonDAL.GetAllAppMessagesCountForDashboard(pUserID, pProfileID);
        }

        #region ----------Private SmartConnect--------
        public string GetPSCCallPreviewText()
        {
            try
            {
                string str = "";
                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\PSCCallIndexPreview.txt";
                StreamReader re = File.OpenText(strfilepath);
                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    str = str + input;
                }
                re.Close();
                re.Dispose();

                return str;
            }
            catch (Exception /*ex*/)
            {
                return "";
            }
        }
        public void GenarateThumbnailForPSCApp(int moduleID, int profileID, string moduleType, string htmlString)
        {
            try
            {
                ErrorHandling("LOG ", "CommonBLL.cs", "GenarateThumbnailForPSCApp()", string.Empty, string.Empty, string.Empty, string.Empty);


                string uspdUploadFolderPath = HttpContext.Current.Server.MapPath("~/upload");
                string rootPath = GetConfigSettings(Convert.ToString(profileID), "Paths", "RootPath");
                string thumbVirtualPath = uspdUploadFolderPath + "/AppThumbs/" + moduleType + "/" + profileID;

                if (!Directory.Exists(thumbVirtualPath))
                {
                    Directory.CreateDirectory(thumbVirtualPath);
                }

                //List<Uri> links = new List<Uri>();
                string imagePath = "";
                string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>"; //<\s*?img\s+[^>]*?\s*src\s*=\s*(["'])((\\?+.)*?)\1[^>]*?>
                MatchCollection matchesImgSrc = Regex.Matches(htmlString, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in matchesImgSrc)
                {
                    imagePath = m.Groups[1].Value;
                    if (imagePath.ToLower().Contains("images/located.png") || imagePath.ToLower().Contains("images/cleared.png"))
                    {

                    }
                    else
                    { break; }
                }
                if (htmlString.StartsWith("http"))
                { imagePath = htmlString; }

                thumbVirtualPath = thumbVirtualPath + "/" + moduleID + ".jpg";
                try
                {
                    if (File.Exists(thumbVirtualPath))
                    {
                        File.Delete(thumbVirtualPath);
                    }
                }
                catch (Exception /*ex*/)
                { }


                int width = Int32.Parse(ConfigurationManager.AppSettings.Get("AppThumbWidth"));
                int height = Int32.Parse(ConfigurationManager.AppSettings.Get("AppThumbHeight"));

                // Folder Names:: CustomModules   or  Bulletins  or  Events  or CalendarAddOns
                string image = string.Empty;
                image = imagePath;
                if (image == "")   //if image exists in html string
                {
                    /*
                    image = uspdUploadFolderPath + "/Upload/" + moduleType + "/" + profileID + "/" + moduleID + ".jpg";
                    if (File.Exists(image))
                    {
                        //Creating thumbnai
                        System.Drawing.Image img = System.Drawing.Image.FromFile(image);
                        System.Drawing.Image thumb = img.GetThumbnailImage(100, 100, null, IntPtr.Zero);
                        img.Dispose();

                        thumb.Save(thumbVirtualPath);
                    }

                    */
                }
                else
                {
                    string imgName = Path.GetFileName(image);

                    string FOlderPath = imagePath.ToLower().Substring(imagePath.ToLower().LastIndexOf("upload"));
                    FOlderPath = FOlderPath.Replace("upload", "");

                    string imgFullPath = uspdUploadFolderPath + FOlderPath;

                    if (File.Exists(imgFullPath))
                    {
                        //Creating thumbnai
                        System.Drawing.Image img = System.Drawing.Image.FromFile(imgFullPath);
                        System.Drawing.Image thumb = img.GetThumbnailImage(width, height, null, IntPtr.Zero);
                        img.Dispose();

                        thumb.Save(thumbVirtualPath);
                    }

                }

                //imgRootPath = rootPath + "/Upload/AppThumbs/" + moduleType + "/" + profileID + "/" + moduleID + ".jpg?GUID=" + Guid.NewGuid();

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "CommonBLL.cs", "GenarateThumbnailForApp()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public string GetQRCodePreviewText()
        {
            try
            {
                string str = "";
                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\QRCodeImagePreview.txt";
                StreamReader re = File.OpenText(strfilepath);
                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    str = str + input;
                }
                re.Close();
                re.Dispose();

                return str;
            }
            catch (Exception /*ex*/)
            {
                return "";
            }
        }
        #endregion


        public void UpdatePrivateQRConnectCreditsReduceUsage(int ProfileID, int usageReduceQuantity)
        {
            CommonDAL.UpdatePrivateQRConnectCreditsReduceUsage(ProfileID, usageReduceQuantity);
        }


        public DataTable GetSocialShareDetails(int UserId, string MediaType)
        {
            return CommonDAL.GetSocialShareDetails(UserId, MediaType);
        }

        public void UpdateSocialShareStatus(int UserID, int StatusFlag, string MediaType,int ContentID,int SentFlag)
        {
            CommonDAL.UpdateSocialShareStatus(UserID, StatusFlag, MediaType, ContentID,SentFlag);
        }
    }

    /// <summary>
    /// Roles & Permissions...
    /// </summary>
    public static class Constants
    {
        public const int BULLETINS = 1;
        public const int UPDATES = 2;
        public const int EVENTS = 4;
        public const int NOTIFICATIONS = 8;
        public const int MBUTTONS = 16;
        public const int APPSETTINGS = 32;
        public const int CONTACTS = 64;
        public const int SURVEYS = 128;
        public const int BLOCKEDSENDERS = 256;
        public const int DOWNLOADS = 512;
    }

    /// <summary>
    /// Roles & Permissions...
    /// </summary>
    public static class PageNames
    {
        public const string BULLETINS = "bulletins";
        public const string UPDATES = "updates";
        public const string EVENTS = "event calendar";
        public const string APPSETTINGS = "mobile app";
        public const string CONTACTS = "contacts";
        public const string MESSAGES = "messages";
        public const string MEDIA = "gallery";
        public const string CPASSWORD = "change password";
        public const string CINFORMATION = "contact information";
        public const string BULLETIN = "Bulletin";
        public const string UPDATE = "Update";
        public const string EVENT = "Event";
        public const string CHMESSAGE = "chief's message";
        public const string MPERSON = "missing person";
        public const string SVEHICLE = "stolen vehicle";
        public const string PACTIVITY = "police activity";
        public const string SNOTIFICATION = "school notification";
        public const string TALERT = "traffice alert/bulletin";
        public const string WANTED = "wanted";
        public const string PRELEASE = "press release";
        public const string PUSHNOTIFICATIONS = "push notifications";
        public const string SURVEYS = "surveys";
        public const string SURVEY = "survey";
        public const string BLOCKEDSENDERS = "blocked senders";
        public const string DOWNLOADS = "downloads";
        public const string CustomModule = "custom module";
        public const string CALENDARADDON = "calendar addon";
        public const string MBUTTONS = "app buttons";
        public const string ManageAssociates = "manage associates";
    }
    /// <summary>
    /// Sub Packages
    /// </summary>
    public class SubPackages
    {
        public string Description { get; set; }
        public string Value { get; set; }
    }

    /// <summary>
    /// Image Gallery Types
    /// </summary>
    public static class ImageGalleryTypes
    {
        public const string MasterGalleryType = "mastergallery";
        public const string AppGalleryType = "appgallery";
        public const string ContentGalleryType = "contentgallery";
    }

    /// <summary>
    /// Manage Contact Group Types
    /// </summary>
    public static class ManageContactGroupTypes
    {
        public const string SystemGroup = "systemgroup";
        public const string CustomGroup = "customgroup";
        public const string PrivateModuleGroup = "privatemodulegroup";
    }

    /// <summary>
    /// Private Module Invited Status
    /// </summary>
    public static class PrivateModule_InvitedStatus
    {
        public const string InvitedStatus = "Invited";
        public const string AcceptedStatus = "Accepted";
        public const string CancelledStatus = "Declined";
        public const string EnabledStatus = "Enabled";
        public const string DisabledStatus = "Disabled";
    }

    /// <summary>
    /// Request Custom Form Types
    /// </summary>
    //public enum RequestCustomFormTypes : int
    //{
    //    SubscriptionRenewal = 10001,
    //    CustomForm = 10002,
    //    SubApps = 10003,
    //    BrandedApp = 10004,
    //    CustomLogo = 10005,
    //    CustomModule = 10006,
    //    NewRegistration = 10000,
    //    AddOns = 10007,
    //    MemorySpace = 10008,
    //    CalendarAddOns = 10009,
    //    PrivateAddOns = 10010,
    //    BannerAds = 10011,
    //    PrivateCallAddOns = 10012,
    //    SMSAddOns = 20001,
    //    SMSSetup = 30001,
    //    ScheduleEmailsSetup = 40001,
    //    WebLinksSetup = 40002,
    //    SocialMediaAutoPostSetup = 40003,
    //    ImageGalleryAddOns = 40004,
    //    SurveySetup = 40005,
    //    ContactUs_BlockSenderSetup = 40006,
    //    ManageLoginsSetup = 40007,
    //    PushNotifications = 40008,
    //    Bulletins = 40009,
    //    Tips_BlockSenderSetup = 40010,
    //    SocialMedia = 40011,
    //    BrandedFee = 40012,
    //    Home = 40013,
    //    AboutUs = 40014,
    //    AppDisplayCustomization = 40015,
    //    OneTouchCallButton = 40016,
    //    WidgetsResources = 40017,
    //    Directions = 40018
    //}
    public enum RequestCustomFormTypes : int
    {
        SubscriptionRenewal = 10001,
        CustomForm = 10002,
        SubApps = 10003,
        BrandedApp = 10004,
        CustomLogo = 10005,
        CustomModule = 10006,
        NewRegistration = 10000,
        AddOns = 10007,
        MemorySpace = 10008,
        CalendarAddOns = 10009,
        PrivateAddOns = 10010,
        BannerAds = 10011,
        PrivateCallAddOns = 10012,
        PublicCallAddOns = 10013,
        SMSAddOns = 20001,
        SMSSetup = 30001,
        ScheduleEmailsSetup = 40001,
        WebLinksSetup = 40002,
        SocialMediaAutoPostSetup = 40003,
        ImageGalleryAddOns = 40004,
        SurveySetup = 40005,
        ContactUs_BlockSenderSetup = 40006,
        ManageLoginsSetup = 40007,
        PushNotifications = 40008,
        Bulletins = 40009,
        Tips_BlockSenderSetup = 40010,
        SocialMedia = 40011,
        BrandedFee = 40012,
        Home = 40013,
        AboutUs = 40014,
        AppDisplayCustomization = 40015,
        OneTouchCallButton = 40016,
        WidgetsResources = 40017,
        Directions = 40018,
        ManageContacts_EmailReports = 40019,
        EventCalendar = 40020,
        PrivateSmartConnectAddOns = 40021
    }

    /// <summary>
    /// Approval Process Types
    /// </summary>
    public enum ApprovalProcessTypes : int
    {
        Approved = 1,
        Rejected = 2,
    }

    /// <summary>
    ///  
    /// </summary>

    public class PaymentModes
    {
        public const string PayPal = "PayPal";
        public const string CreditCard = "CreditCard";
        public const string ECS = "ECS";
        public const string Check = "check";
        public const string BillMe = "BillMe";
    }

    /// <summary>
    /// Common Modules
    /// </summary>
    public static class CommonModules
    {
        public const string ManageMessageReceipt = "Manage Message Receipt";
        public const string PrivateAddOnInvs = "Access Private AddOn Invitations";
        public const string PushNotifications = "Push Notifications";
        public const string ManageButtons = "Manage Buttons";
        public const string AppSettings = "App Settings";
        public const string Contacts = "Contacts";
        public const string ReceiveFeedbackTips = "Receive Feedback/Tips";
        public const string Downloads = "Downloads";
        public const string AccessMarketPlace = "Access Market Place";
        public const string ManageAssociates = "Manage Associates";
        public const string AppBackgroundImage = "App Background Image";
        public const string BannerAds = "BannerAds";
        //USPD-1107 and USPD-1116 Permission related Changes
        public const string Home = "Home";
        public const string AboutUs = "AboutUs";
        public const string WebLinks = "WebLinks";
        public const string SocialMedia = "SocialMedia";
        public const string ReceiveTips = "Receive Tips";
        public const string Gallery = "Gallery";
        public const string BillingHistory = "Billing History";
        public const string ReleaseHistory = "Release History";
        public const string AppStatistics = "App Statistics";
        public const string PublicCallAddOns = "PublicCallAddOns";
        public const string SmartConnectCategories = "SmartConnectCategories";
       
    }

    public enum Role : int
    {
        LTRoleID = 10,
        CMRoleID = 20,
        CPRoleID = 30,
        CARoleID = 40,
    }

    public static class PackageIncludeSettingsAttributes
    {
        public const string IsLongLogo = "IsLongLogo";
        public const string GettingIsDescription = "GettingIsDescription";
    }



    public enum ProfileSubscriptionTypes : int
    {
        Premium = 101,
        PaidLite = 102,
        SponsoredLite = 103,
        Basic = 102,
        Custom = 103,
        Premium_Twovie = 104,
        Basic_Twovie = 105,
        Custom_Twovie = 106,
        Premium_MyYouthHub = 107,
        Basic_MyYouthHub = 108,
        Custom_MyYouthHub = 109,
        Premium_InSchoolHub = 110,
        Basic_InSchoolHub = 111,
        Custom_InSchoolHub = 112
    }

    public static class SmartConnectCategoryType
    {
        public const string NotAssigned = "System";
        public const string User = "User";
    }

    public static class ButtonTypes
    {
        public const string Tips = "Tips";
        public const string ContactUs = "Contact";
        public const string SmartConnect = "PublicCallAddOns";
        public const string PrivateCall = "PrivateCallAddOns";
        public const string PrivateSmartConnect = "PrivateSmartConnectAddOns";
        public const string PrivateModule = "PrivateAddOns";

    }
}
