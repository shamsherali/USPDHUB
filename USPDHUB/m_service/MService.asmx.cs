using System;
using System.Linq;
using System.Web.Services;
using System.Configuration;
using System.IO;
using System.Data;
using USPDHUBDAL;
using System.Data.SqlClient;
using USPDHUBBLL;
using System.Collections.Generic;
using System.Web;

namespace USPDHUB.m_service
{
    /// <summary>
    /// Summary description for MService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MService : System.Web.Services.WebService
    {
        #region ******************** Verticals Names&IDs & AppIDs&Names && Branded Apps Names(Mobile App favourites Profile IDs) ********************

        // Vertical Codes
        // 1: USPD
        // 2: nonprofit
        // 3: inschoolhub
        // 4: twovie

        // App IDs
        // 1: USPD
        // 2: PPD
        // 3: AgencyTraining
        // 4: InSchoolHub
        // 5: TwoVie
        // 6: DVRT
        // 7: Milestones
        // 8: LakeStreetPD

        //AppNames for Mobile App Favourites ProfileIDS (Only Branded Apps) :: GetBrandedAppFavorites
        // ******************  Branded Apps Names ***************************
        // PPDHub == Paradise Police Department
        // AgencyTraining == OWN App for Demo
        // DVRT == DVRT
        // MileStonesCDCI == MileStonesCDCI
        // LakeStreetPD == LakeStreetPD

        #endregion


        USPDHUBBLL.MServiceBLL objServiceBLL = new USPDHUBBLL.MServiceBLL();

        public string ErrorMessage = "ERROR";


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        /// <summary>
        /// Home Tabs details like Home description  & image
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return home details as string</returns>
        [WebMethod]
        public string HomeTabDetails(string pProfileID, string pTabletName = "", string pDeviceWidth = "")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "HomeTabDetails()", string.Empty, string.Empty, string.Empty, string.Empty);
                if (pTabletName == null)
                {
                    pTabletName = string.Empty;
                    pDeviceWidth = string.Empty;
                }
                return objServiceBLL.HomeTabDetails(pProfileID, pTabletName, pDeviceWidth);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "HomeTabDetails()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting About Us Details by Profile ID
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return about us details as XML string</returns>
        [WebMethod]
        public string GetAboutUsDetails(string pProfileID, string pTabletName = "", string pDeviceWidth = "")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetAboutUsDetails()", string.Empty, string.Empty, string.Empty, string.Empty);
                if (pTabletName == null)
                {
                    pTabletName = string.Empty;
                    pDeviceWidth = string.Empty;
                }
                return objServiceBLL.GetAboutUsDetails(pProfileID, pTabletName, pDeviceWidth);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetAboutUsDetails()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting User Buy Tools & Business Tools Names & Icons Settings by Profile ID
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <param name="pIconSize">param is pIconSize</param>
        /// <returns>return tools as XML string</returns>
        [WebMethod]
        public string GetSelectedTools(string pProfileID, string pIconSize, string pAppID = "1", string pNewTabs = "Survey", bool pIsNewIcons = false)
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetSelectedTools()", string.Empty, string.Empty, string.Empty, string.Empty);
                if (pNewTabs == null)
                {
                    pNewTabs = "";
                }                
                return objServiceBLL.GetSelectedTools(pProfileID, pIconSize, GetBrandedAppID(pAppID), Convert.ToString(pNewTabs), pIsNewIcons);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetSelectedTools()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting Active & Published Updates by Profile ID
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return updates details as XML string</returns>
        [WebMethod]
        public string GetAllUpdates(string pProfileID)
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetAllUpdates()", string.Empty, string.Empty, string.Empty, string.Empty);

                return objServiceBLL.GetAllUpdates(pProfileID);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetAllUpdates()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }


        /// <summary>
        /// Getting Update Description by Update ID
        /// </summary>
        /// <param name="pUpdateID">param is pUpdatedID</param>
        /// <returns>return updatedetails as string</returns>
        [WebMethod]
        public string GetUpdateDetaisByID(string pUpdateID, string pTabletName = "", string pDeviceWidth = "")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetUpdateDetaisByID()", string.Empty, string.Empty, string.Empty, string.Empty);
                if (pTabletName == null)
                {
                    pTabletName = string.Empty;
                    pDeviceWidth = string.Empty;
                }
                return objServiceBLL.GetUpdateDetaisByID(pUpdateID, pTabletName, pDeviceWidth);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetUpdateDetaisByID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting All Photos by Profile ID
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return photo as XML string</returns>
        [WebMethod]
        public string GetAllPhotosByProfileID(string pProfileID)
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetAllPhotosByProfileID()", string.Empty, string.Empty, string.Empty, string.Empty);

                return objServiceBLL.GetAllPhotosByProfileID(pProfileID);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetAllPhotosByProfileID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting All Active & Published Events by Profile ID and Month
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <param name="pDateTime">param is pDateTime</param>
        /// <returns>return events as XML string</returns>
        [WebMethod]
        public string GetAllEvents(string pProfileID, string pDateTime, string pType = "1")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetAllEvents()", string.Empty, string.Empty, string.Empty, string.Empty);
                if (pType == null || pType == "")
                { pType = "1"; }
                return objServiceBLL.GetAllEvents(pProfileID, pDateTime, pType);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetAllEvents()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting Event Description by Event ID
        /// </summary>
        /// <param name="pEventID">param is pEventID</param>
        /// <returns>return event details as string</returns>
        [WebMethod]
        public string GetEventDetailsByID(string pEventID, string pTabletName = "", string pDeviceWidth = "")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetEventDetailsByID()", string.Empty, string.Empty, string.Empty, string.Empty);
                if (pTabletName == null)
                {
                    pTabletName = string.Empty;
                    pDeviceWidth = string.Empty;
                }
                return objServiceBLL.GetEventDetailsByID(pEventID, pTabletName, pDeviceWidth);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetEventDetailsByID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Save the contact details & sending email to business user & upload user image
        /// </summary>
        /// <param name="pToEmailID">param is pToEmailID</param>
        /// <param name="pSubject">param is pSubject</param>
        /// <param name="pBody">param is pBody</param>
        /// <param name="pUserName">param is pUserName</param>
        /// <param name="mobileNumber">param is mobileNumber</param>
        /// <param name="contactEmailID">param is contactEmailID</param>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <param name="pUserID">param is pUserID</param>
        /// <param name="pSourceType">param is pSourceType</param>
        /// <param name="pLatitude">param is pLatitude</param>
        /// <param name="pLongitude">param is pLongitude</param>
        /// <param name="pPhotoBytes">param is pPhotoBytes</param>
        /// <param name="pAddress">param is pAddress</param>
        /// <returns>return Success or Failure</returns>
        [WebMethod]
        public string SendEmail(string pToEmailID, string pSubject, string pBody, string pUserName, string mobileNumber,
            string contactEmailID, string pProfileID, string pUserID, byte[] pPhotoBytes, string pSourceType, string pLatitude,
            string pLongitude, string pAddress, bool pIsAnonymous, string pDeviceID = "", string pDeviceType = "", string pAppID = "")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "SendEmail() 1 ", string.Empty, string.Empty, string.Empty, string.Empty);

                string pPhotoName = string.Empty;
                //AppContactusPhotoPath
                //string strTempFolderName = Server.MapPath("~/Upload/DevicePhotos/" + pProfileID);
                string strTempFolderName = ConfigurationManager.AppSettings.Get("AppContactUsPhotosFolderName") + "/Upload/DevicePhotos/" + pProfileID;
                if (!Directory.Exists(strTempFolderName))
                {
                    Directory.CreateDirectory(strTempFolderName);
                }
                if (pPhotoBytes != null)
                {
                    if (pPhotoBytes.Length > 4)
                    {
                        pPhotoName = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".jpg";
                    }
                }

                ErrorHandling("LOG ", "MService.asmx", "SendEmail() 2", pSourceType, string.Empty, string.Empty, string.Empty);

                if (pSourceType.Contains(","))
                {
                    var details = pSourceType.Split(',');
                    pSourceType = details[0].ToString();
                    pPhotoName = details[1].ToString();
                }

                #region Bytes Image convert to Image & Uploading to DevicePhotos Folder in Upload folder

                if (pPhotoBytes != null)
                {
                    if (pPhotoBytes.Length > 4)
                    {
                        //Bytes Convert to Image
                        string strPhotoPath = strTempFolderName + "\\" + pPhotoName;

                        using (MemoryStream stream = new MemoryStream(pPhotoBytes))
                        {
                            System.Drawing.Image newImage;
                            newImage = System.Drawing.Image.FromStream(stream);
                            newImage.Save(strPhotoPath);
                            stream.Flush();
                            stream.Close();
                            stream.Dispose();
                        }
                    }
                }

                #endregion

                if (string.IsNullOrEmpty(pAppID))
                {
                    pAppID = "1";
                }
                if (string.IsNullOrEmpty(pDeviceID))
                {
                    pDeviceID = null;
                }
                if (string.IsNullOrEmpty(pDeviceType))
                {
                    pDeviceType = string.Empty;
                }

                string result = objServiceBLL.SendEmail(pToEmailID, pSubject, pBody, pUserName, mobileNumber, contactEmailID, pProfileID,
                    pUserID, pSourceType, pPhotoName, Convert.ToDouble(pLatitude), Convert.ToDouble(pLongitude), pAddress, pIsAnonymous,
                    pDeviceID, pDeviceType, Convert.ToInt32(pAppID));



                return result;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "SendEmail()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting Business details by Mapview direction (Latitude,longitude and Radius values)
        /// </summary>
        /// <param name="platitude1">param is platitude1</param>
        /// <param name="plongitude1">param is plongitude1</param>
        /// <param name="pRadius">param is pRadius</param>
        /// <returns>return business details as XML string</returns>
        [WebMethod]
        public string MapViewDirection(string platitude1, string plongitude1, string pRadius)
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "MapViewDirection()", string.Empty, string.Empty, string.Empty, string.Empty);

                return objServiceBLL.MapViewDirection(platitude1, plongitude1, pRadius);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "MapViewDirection()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting Social media links by Profile ID
        /// </summary>
        /// <param name="pProfileID">param is pProfilID</param>
        /// <returns>return social media links as XML string</returns>
        [WebMethod]
        public string GetSocilMedialinks(string pProfileID)
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetSocilMedialinks()", string.Empty, string.Empty, string.Empty, string.Empty);

                return objServiceBLL.GetSocilMedialinks(pProfileID);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetSocilMedialinks()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }


        /// <summary>
        /// Getting business details by profile code & radius values
        /// </summary>
        /// <param name="pBCode">param is pBCode</param>
        /// <param name="latitude2">param is latitude2</param>
        /// <param name="longitude2">param is longitude2</param>
        /// <param name="radius">param is radius</param>
        /// <returns>return business details as XML string</returns>
        [WebMethod]
        public string GetProfileDetailsByBCode(string pBCode, string latitude2, string longitude2, string radius, string pVCode = "")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetProfileDetailsByBCode()", string.Empty, string.Empty, string.Empty, string.Empty);
                if (pVCode == "" || pVCode == null)
                { pVCode = "1"; }
                // pVCode 1: Police Department Vertical Code
                // 1 Means getting details by Business Code
                return objServiceBLL.GetProfileDetailsByBCode(pBCode, 0, "1", latitude2, longitude2, radius, pVCode);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetProfileDetailsByBCode()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting business details by profile ids
        /// </summary>
        /// <param name="pBCode">param is pProfileIDs</param> 
        /// <returns>return business details as XML string</returns>
        [WebMethod]
        public string GetFavoritesProfileDetails(string pProfileIDs)
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetFavoritesProfileDetails()", string.Empty, string.Empty, string.Empty, string.Empty);

                string result = string.Empty;
                string xmlResult = "";
                pProfileIDs = pProfileIDs.Trim();

                if (pProfileIDs.StartsWith(","))
                {
                    pProfileIDs = pProfileIDs.Substring(1);
                }
                if (pProfileIDs.EndsWith(","))
                {
                    pProfileIDs = pProfileIDs.Remove(pProfileIDs.Length - 1);
                }

                ErrorHandling("LOG ", "MService.asmx", "GetFavoritesProfileDetails()", pProfileIDs, string.Empty, string.Empty, string.Empty);

                string pVerticalCode = "";

                var ids = pProfileIDs.Split(',');
                for (int i = 0; i < ids.Count(); i++)
                {
                    pVerticalCode = MServiceDAL.GetVerticalNameByProfileID(Convert.ToInt32(ids[i].ToString()));
                    // 2 Means getting details by Profile ID
                    xmlResult = objServiceBLL.GetProfileDetailsByBCode(string.Empty, Convert.ToInt32(ids[i].ToString()), "2", "0.0", "0.0", "0", "1");
                    result = result + xmlResult;
                }

                result = "<BPDetails>" + result + "</BPDetails>" + objServiceBLL.GetBulletinCategories(pVerticalCode);
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetFavoritesProfileDetails()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Save device details for push notifications
        /// </summary>
        /// <param name="pDeviceID">param is pDeviceID</param>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <param name="pDeviceType">param is pDeviceType</param>
        /// <param name="pBusinessName">param is pBusinessName</param>
        /// <param name="pAddress">param is pAddress</param>
        /// <returns>return success or failure</returns>
        [WebMethod]
        public string InsertAppDeviceDetails(string pDeviceID, string pProfileID, string pDeviceType, string pBusinessName, string pAddress, string pAppID = "1")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "InsertAppDeviceDetails(AppID=" + pAppID + ")", string.Empty, string.Empty, string.Empty, string.Empty);


                return objServiceBLL.InsertAppDeviceDetails(pDeviceID, Convert.ToInt32(pProfileID), pDeviceType, pBusinessName, pAddress, GetBrandedAppID(pAppID));
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "InsertAppDeviceDetails()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        //For Demo Account App 
        [WebMethod]
        public string InsertDemoACAppDeviceDetails(string pDeviceID, string pProfileIDs, string pDeviceType, string pBusinessNames, string pAddress, string pAppID = "1")
        {
            string result = string.Empty;
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "InsertDemoACAppDeviceDetails(AppID=" + pAppID + ")", string.Empty, string.Empty, string.Empty, string.Empty);

                //Ids
                pProfileIDs = pProfileIDs.Trim();
                if (pProfileIDs.StartsWith(","))
                {
                    pProfileIDs = pProfileIDs.Substring(1);
                }
                if (pProfileIDs.EndsWith(","))
                {
                    pProfileIDs = pProfileIDs.Remove(pProfileIDs.Length - 1);
                }
                //Names
                pBusinessNames = pBusinessNames.Trim();
                if (pBusinessNames.StartsWith(","))
                {
                    pBusinessNames = pBusinessNames.Substring(1);
                }
                if (pBusinessNames.EndsWith(","))
                {
                    pBusinessNames = pBusinessNames.Remove(pBusinessNames.Length - 1);
                }

                var bNames = pBusinessNames.Split(',');
                var ids = pProfileIDs.Split(',');
                for (int i = 0; i < ids.Count(); i++)
                {
                    InsertAppDeviceDetails(pDeviceID, ids[i].ToString(), pDeviceType, bNames[i].ToString(), pAddress, GetBrandedAppID(pAppID).ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "InsertDemoACAppDeviceDetails()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Delete device details 
        /// </summary>
        /// <param name="pDeviceID">param is pDeviceID</param>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return success or failure</returns>
        [WebMethod]
        public string DeleteAppDeviceDetails(string pDeviceID, string pProfileID, string pAppID = "1")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "DeleteAppDeviceDetails()", string.Empty, string.Empty, string.Empty, string.Empty);

                return objServiceBLL.DeleteAppDeviceDetails(pDeviceID, Convert.ToInt32(pProfileID), GetBrandedAppID(pAppID));
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "DeleteAppDeviceDetails()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Delete All device details 
        /// </summary>
        /// <param name="pDeviceID">param is pDeviceID</param>
        /// <returns>return success or failure</returns>
        [WebMethod]
        public string DeleteAllFavoritesByDeviceID(string pDeviceID, string pAppID = "1")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "DeleteAllFavoritesByDeviceID()", string.Empty, string.Empty, string.Empty, string.Empty);

                return objServiceBLL.DeleteAppDeviceDetails(pDeviceID, 0, GetBrandedAppID(pAppID));
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "DeleteAllFavoritesByDeviceID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting all active & publish bulletins by profile id
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return bulletins as XML string</returns>
        [WebMethod]
        public string GetActiveBulletinsByProfileID(string pProfileID)
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetActiveBulletinsByProfileID()", string.Empty, string.Empty, string.Empty, string.Empty);

                return objServiceBLL.GetActiveBulletinsByProfileID(Convert.ToInt32(pProfileID));
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetActiveBulletinsByProfileID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting Bulletin HTML String by Bulletin ID
        /// </summary>
        /// <param name="pBulletinID">param is pBulletinID</param>
        /// <returns>return html string</returns>
        [WebMethod]
        public string GetBulletinHTMLStringByID(string pBulletinID, string pTabletName = "", string pDeviceWidth = "")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetBulletinHTMLStringByID()", string.Empty, string.Empty, string.Empty, string.Empty);
                if (pTabletName == null)
                {
                    pTabletName = string.Empty;
                    pDeviceWidth = string.Empty;
                }
                return objServiceBLL.GetBulletinHTMLStringByID(Convert.ToInt32(pBulletinID), pTabletName, pDeviceWidth);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetBulletinHTMLStringByID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting Weblinks by profile ID
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>return weblinks as XML string</returns>
        [WebMethod]
        public string GetWebLinks(string pProfileID)
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetWebLinks()", string.Empty, string.Empty, string.Empty, string.Empty);

                return objServiceBLL.GetWebLinks(pProfileID);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetWebLinks()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting Push Notification by Profile ID & Device ID
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <param name="pDeviceID">param is pDeviceID</param>
        /// <returns>return details</returns>
        [WebMethod]
        public string GetPushNotifications(string pProfileID, string pDeviceID, string pAppID = "1")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetPushNotification()", string.Empty, string.Empty, string.Empty, string.Empty);

                return objServiceBLL.GetPushNotifications(pProfileID, pDeviceID, GetBrandedAppID(pAppID));
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetPushNotification()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        [WebMethod]
        public string GetBusinessSummaryDetails(string pProfileIDs, string pDeviceID, string pAppID = "1")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetBusinessSummaryDetails()", string.Empty, string.Empty, string.Empty, string.Empty);

                return objServiceBLL.GetAgenecySummary(pProfileIDs, pDeviceID, GetBrandedAppID(pAppID));


            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetBusinessSummaryDetails()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        [WebMethod]
        public string TurnOn_OffPushNotification(string pDeviceID, string pProfileID, string pAppID = "1", string pIsPushNotify = "False")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "TurnOn_OffPushNotification()", string.Empty, string.Empty, string.Empty, string.Empty);

                string pProfileIDs = pProfileID.Trim();
                if (pProfileIDs.StartsWith(","))
                {
                    pProfileIDs = pProfileIDs.Substring(1);
                }
                if (pProfileIDs.EndsWith(","))
                {
                    pProfileIDs = pProfileIDs.Remove(pProfileIDs.Length - 1);
                }

                var ids = pProfileIDs.Split(',');
                for (int i = 0; i < ids.Count(); i++)
                {
                    objServiceBLL.TurnOn_OffPushNotification(pDeviceID, Convert.ToInt32(ids[i]), GetBrandedAppID(pAppID), Convert.ToBoolean(pIsPushNotify));
                }

                return "";
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "TurnOn_OffPushNotification()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        [WebMethod]
        public string GetOn_OffPushNotification(string pDeviceID, string pProfileID, string pAppID = "1")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetOn_OffPushNotification()", string.Empty, string.Empty, string.Empty, string.Empty);

                return objServiceBLL.GetOn_OffPushNotification(pDeviceID, Convert.ToInt32(pProfileID), GetBrandedAppID(pAppID));

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetOn_OffPushNotification()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        [WebMethod]
        public string ValidateMobileAppPin(string pAppName, string pPin)
        {
            return objServiceBLL.ValidateMobileAppPin(pAppName, pPin);
        }

        [WebMethod]
        public string GetBrandedAppFavorites(string pAppName)
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetBrandedAppFavorites()", string.Empty, string.Empty, string.Empty, string.Empty);

                DataTable dtProfileIDs = objServiceBLL.GetBrandedAppProfileIDs(pAppName);

                string pVerticalCode = "";

                string xmlResult = string.Empty;
                string result = string.Empty;
                for (int i = 0; i < dtProfileIDs.Rows.Count; i++)
                {
                    pVerticalCode = MServiceDAL.GetVerticalNameByProfileID(Convert.ToInt32(dtProfileIDs.Rows[i]["Profile_ID"]));
                    // 2 Means getting details by Profile ID
                    xmlResult = objServiceBLL.GetProfileDetailsByBCode(string.Empty, Convert.ToInt32(dtProfileIDs.Rows[i]["Profile_ID"]), "2", "0.0", "0.0", "0", "1");
                    result = result + xmlResult;
                }

                result = "<BPDetails>" + result + "</BPDetails>" + objServiceBLL.GetBulletinCategories(pVerticalCode);
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetBrandedAppFavorites()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        private int GetBrandedAppID(string pAppID)
        {
            int resultID = (int)USPDHUBBLL.BrandedAppType.USPD;
            if (pAppID == "" || pAppID == "0" || pAppID == null)
            {
                resultID = (int)USPDHUBBLL.BrandedAppType.USPD;
            }
            else
            {
                resultID = Convert.ToInt32(pAppID);
            }
            return resultID;
        }

        #region Survey Methods

        [WebMethod]
        public string GetAllSurveys(string pProfileID, string pDeviceID, string pDeviceType, string pAppID)
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetAllSurveys()", string.Empty, string.Empty, string.Empty, string.Empty);
                return objServiceBLL.GetAllSurveys(Convert.ToInt32(pProfileID), pDeviceID, pDeviceType, Convert.ToInt32(GetBrandedAppID(pAppID)));
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetAllSurveys()", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        [WebMethod]
        public string GetQuestion_Options(int pSID, string pDeviceID, string pDeviceType, string pAppID = "1")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetQuestion_Options()", string.Empty, string.Empty, string.Empty, string.Empty);
                return objServiceBLL.GetQuestions_OptionsBySID(Convert.ToInt32(pSID), pDeviceID, pDeviceType, Convert.ToInt32(GetBrandedAppID(pAppID)));
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetQuestion_Options()", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        [WebMethod]
        public string InsertSurveyAnswers(string pDeviceID, string pDeviceType, string pAnswerTexts, string pOptionIDs,
            string pQID, string pAppID = "1", string pSurveyID = "", string pIsCompleted = "False")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "InsertSurveyAnswers()", string.Empty, string.Empty, string.Empty, string.Empty);
                return objServiceBLL.InsertSurveyAnswers(pDeviceID, pDeviceType, GetBrandedAppID(pAppID), pAnswerTexts, pOptionIDs,
                    Convert.ToInt32(pQID), Convert.ToInt32(pSurveyID), Convert.ToBoolean(pIsCompleted));
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "InsertSurveyAnswers()", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        #endregion

        [WebMethod]
        public string GetChildAgenciesByParentID(string pProfileID, string pVerticalCode = "")
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "GetChildAgenciesByParentID()", string.Empty, string.Empty, string.Empty, string.Empty);
                if (pVerticalCode == "" || pVerticalCode == null)
                { pVerticalCode = "1"; }

                //--1 means validate b code getting via business details by BCode
                //--2 means getting business details by profile
                //--3 Means Getting child Records based parent profileID

                string pBCode = string.Empty;
                string latitude2 = "0";
                string longitude2 = "";
                string radius = "0";

                return objServiceBLL.GetProfileDetailsByBCode(pBCode, Convert.ToInt32(pProfileID), "3", latitude2, longitude2, radius, pVerticalCode);
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "GetChildAgenciesByParentID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        [WebMethod]
        public string CheckLogin(string pUsername, string pPassword, string pDomainName)
        {
            try
            {
                ErrorHandling("LOG ", "MService.asmx", "CheckLogin()--1", string.Empty, string.Empty, string.Empty, string.Empty);
                // pPassword = EncryptDecrypt.DESDecrypt(pPassword);

                int UserID = 0;
                int RoleID = 0;

                USPDHUBBLL.Consumer conobj = new USPDHUBBLL.Consumer();
                BusinessBLL busobj = new BusinessBLL();

                ErrorHandling("LOG ", "MService.asmx", "CheckLogin()--2 == pUsername: " + pUsername + " pPassword: " + pPassword + " pDomainName: " + pDomainName,
                    string.Empty, string.Empty, string.Empty, string.Empty);

                string result = "SUCCESS";
                DataTable dtobj = USPDHUBDAL.Consumer.GetUserDetails(pUsername, pDomainName);
                if (dtobj != null)
                {
                    ErrorHandling("LOG ", "MService.asmx", "CheckLogin()--3 dtobj.Rows.Count: " + dtobj.Rows.Count, string.Empty, string.Empty, string.Empty, string.Empty);
                    if (dtobj.Rows.Count == 0)
                    {
                        DataTable dtAssociate = conobj.GetAssociateUserDetails(pUsername, pDomainName);
                        if (dtAssociate != null && dtAssociate.Rows.Count > 0)
                        {
                            dtobj = conobj.GetUserDetailsByID(Convert.ToInt32(dtAssociate.Rows[0]["SuperAdmin_ID"].ToString()));
                        }
                    } //Ends here...

                    if (dtobj.Rows.Count == 1)
                    {
                        if (Convert.ToBoolean(dtobj.Rows[0]["Active_flag"]) == true)
                        {
                            int code = 1;
                            string passcod = string.Empty;

                            passcod = EncryptDecrypt.DESDecrypt(dtobj.Rows[0]["Password"].ToString());
                            pPassword = EncryptDecrypt.DESDecrypt(pPassword);
                            code = pPassword.CompareTo(passcod.ToString());

                            ErrorHandling("LOG ", "MService.asmx", "CheckLogin()--4 Original_PWD: " + passcod, string.Empty, string.Empty, string.Empty, string.Empty);
                            ErrorHandling("LOG ", "MService.asmx", "CheckLogin()--5 UserInput_PWD: " + pPassword, string.Empty, string.Empty, string.Empty, string.Empty);

                            ErrorHandling("LOG ", "MService.asmx", "CheckLogin()--6 code: " + code, string.Empty, string.Empty, string.Empty, string.Empty);

                            if (code == 0)
                            {
                                UserID = Convert.ToInt32(dtobj.Rows[0]["User_ID"]);
                                RoleID = Convert.ToInt32(dtobj.Rows[0]["Role_ID"]);


                                # region For Business User
                                if (RoleID == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business)
                                {
                                    //Populate the profile details
                                    DataTable bustabobj = new DataTable();
                                    bustabobj = busobj.GetBusinessProfileByUserID(UserID);
                                    if (bustabobj.Rows.Count == 0)
                                    {
                                        result = "Your Account Registration is incomplete. Please <a href='ClearBusinessAccount.aspx?userid=" + pUsername + "'>click here</a> to start new Registration...!";
                                    }
                                    else if (bustabobj.Rows.Count == 1)
                                    {
                                    }
                                    else
                                    {
                                        result = "This User has multiple Profiles Exists. Please contact customer support (support@uspdhub.com). </font>";
                                    }
                                }
                                # endregion
                                else if (RoleID == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Consumer)
                                {
                                    result = "Invalid login name. Please check your login name.";
                                }
                                else
                                {
                                    result = "Can not Recognize User. Please contact Customer support.";
                                }
                            }
                            else
                                result = "Invalid password; please try again.";
                        }
                        else
                        {
                            if (Convert.ToInt32(HttpContext.Current.Session["RoleID"]) == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business)
                            {
                                string activationCode = string.Empty;
                                activationCode = busobj.CheckUserActivationCodeForRegistration(Convert.ToInt32(dtobj.Rows[0]["User_ID"].ToString()));
                                if (activationCode != "")
                                {
                                    result = "Your account is not yet activated. Please check your email (<b style='color:Green'> " + dtobj.Rows[0]["username"].ToString() + "</b> ) to activate your USPDhub<sup style=\"font-size:12px;\">&reg;</sup> Account.";
                                }
                                else
                                {
                                    int listingProfileID = 0;
                                    listingProfileID = busobj.GetProfileIDByUserID(Convert.ToInt32(dtobj.Rows[0]["User_ID"].ToString()));
                                    if (listingProfileID > 0)
                                    { }
                                    else
                                    {
                                        result = "Your Account Registration is incomplete. Please <a href='ClearBusinessAccount.aspx?userid=" + pUsername + "'>click here</a> to start new Registration...!";
                                    }
                                }
                            }
                            else
                            {
                                result = "Hurry, Now USPDhub<sup style=\"font-size:12px;\">&reg;</sup> offering FOREVER FREE LISTING, Please <a href='ClearBusinessAccount.aspx?userid=" + pUsername + "'>click here</a> to start new Registration...!";
                            }
                        }
                    }
                    else
                        result = "Invalid login name or password, please try again.";
                }
                else
                {
                    result = "Invalid Login Name & Password.";
                }
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MService.asmx", "CheckLogin()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }


        [WebMethod]
        public string GetWeblinks_CategoriesByPID(string pProfileID)
        {

            return objServiceBLL.GetWeblinks_CategoriesByPID(Convert.ToInt32(pProfileID));
        }

        [WebMethod]
        // BUES Means:: Bulletins, Updates, Events, Surveys
        public string GetPushNotifyDetails_BUES(string pProfileID, string pTypeID, string pTypeName, string pDeviceID, string pAppID)
        {
            return objServiceBLL.GetPushNotifyDetails_BUES(Convert.ToInt32(pProfileID), Convert.ToInt32(pTypeID), pTypeName, pDeviceID, Convert.ToInt32(pAppID));
        }

        /*
        [WebMethod]
        public string GetWeblinksCategories(string pProfileID)
        {
            return objServiceBLL.GetWeblinksCategories(Convert.ToInt32(pProfileID));
        }

        [WebMethod]
        public string GetWeblinksByCatID(string pWebLinkCategoryID)
        {
            return objServiceBLL.GetWeblinksByCategoryID(Convert.ToInt32(pWebLinkCategoryID));
        }

        */

        #region Error Log

        public void ErrorHandling(string errorType, string pPageName, string methodName, string message, string strackTrace, string innerException, string data)
        {
            bool isErrorLog = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("IsErrorLog"));

            if (isErrorLog == true || errorType != "LOG ")
            {
                string strLogFile = "";
                string errorLogFolder = Server.MapPath("~") + "\\Upload\\ErrorLog\\";

                if (!Directory.Exists(errorLogFolder))
                {
                    Directory.CreateDirectory(errorLogFolder);
                }

                strLogFile = errorLogFolder + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "_ErrorLog.txt";

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
    }
}

