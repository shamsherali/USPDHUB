using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using USPDHUBDAL;
using System.Drawing;
using System.IO;
using System.Configuration;
using Winnovative.WnvHtmlConvert;
using Winnovative.HtmlToPdfClient;
using System.Net;
using System.Xml;
namespace USPDHUBBLL
{
    public class PrivateSmartConnectBLL
    {
        CommonBLL objCommon = new CommonBLL();
        /// <summary>
        /// Get all contacts for send invitation
        /// </summary>
        /// <param name="pUserModuleID">pUserModuleID</param> 
        /// <param name="pValue">pValue</param>
        /// <returns>DataTable</returns>

        public DataTable GetAllContactsForSendInvitation(int pUserModuleID, string pValue)
        {
            return PrivateSmartConnectDAL.GetAllContactsForPSCSendInvitation(pUserModuleID, pValue);
        }

        public DataTable GetPrivateSmartConnectCategoriesList(int ProfileID, int UserModuleID)
        {
            return PrivateSmartConnectDAL.GetPrivateSmartConnectCategoriesList(ProfileID, UserModuleID);
        }

        public DataTable GetPSCCallIndex_Buttons(int pProfileID, int? userModuleId)
        {
            return PrivateSmartConnectDAL.GetPSCCallIndex_Buttons(pProfileID, userModuleId);
        }
        public DataTable GetAllManagePSCCallIndexAddOns(int pUserID, int pCustomModuleId, string pCategoryIDs = "0")
        {
            return PrivateSmartConnectDAL.GetAllManagePSCCallIndexAddOns(pUserID, pCustomModuleId, pCategoryIDs);
        }

        public DataTable GetAllPSCCallIndexAddOnsByOrder(int userModuleId)
        {
            return PrivateSmartConnectDAL.GetAllPSCCallIndexAddOnsByOrder(userModuleId);
        }

        public DataTable GetPSCCallIndexByID(int CustomID)
        {
            return PrivateSmartConnectDAL.GetPSCCallIndexByID(CustomID);
        }
        public DataSet GetPSCCallGroupsData(int UserModuleID)
        {
            return PrivateSmartConnectDAL.GetPSCCallGroupsData(UserModuleID);
        }
        public DataTable GetActiveContactsForPSC(int UserModuleID, string GroupIDs)
        {
            return PrivateSmartConnectDAL.GetActiveContactsForPSC(UserModuleID, GroupIDs);
        }
        public DataTable GetPSCCallGroupContactsByID(int CustomID)
        {
            return PrivateSmartConnectDAL.GetPSCCallGroupContactsByID(CustomID);
        }

        public int InsertUpdatePSCCallIndexData(int CustomID, int ProfileID, int UserID, string Title, string ImageUrls, string MobileNumber, bool IsAutoEmail, string Email_Description, string Email_GroupIDs,
            bool IsAutoTextMessage, string SMS_Description, string SMS_GroupIDs, bool IsGPSInformation, bool IsAllPhoneInformation, bool IsActive, int CreatedUser, int ModifyUser, int UserModuleID, bool IsDeleted, bool IsPublish,
                bool IsPublic, string Email_Subject, string SMS_Subject, string Description, string PreviewHtml, bool IsVisible, bool IsInitiatesPhoneCall, bool IsCustomPredefinedMessage, bool IsUploadImage,
            int AppUserAnonymousType, int CategoryID, bool IsAutoPushNotification, string PushNotification_GroupIDs, string PushNotification_Description, string PushNotification_Subject, string AddressInfo, string GPS_Details,
            bool IsMessageMandatory, string DefaultMessage, bool IsLocationProximityOn, int ProximityRadius, string RadiusType, bool IsClickable)
        {
            int returnID = PrivateSmartConnectDAL.InsertUpdatePSCCallIndexData(CustomID, ProfileID, UserID, Title, ImageUrls, MobileNumber, IsAutoEmail, Email_Description, Email_GroupIDs,
                   IsAutoTextMessage, SMS_Description, SMS_GroupIDs, IsGPSInformation, IsAllPhoneInformation, IsActive, CreatedUser, ModifyUser, UserModuleID, IsDeleted, IsPublish,
                    IsPublic, Email_Subject, SMS_Subject, Description, PreviewHtml, IsVisible, IsInitiatesPhoneCall, IsCustomPredefinedMessage, IsUploadImage, AppUserAnonymousType, CategoryID, IsAutoPushNotification
                    , PushNotification_GroupIDs, PushNotification_Description, PushNotification_Subject, AddressInfo, GPS_Details,
                   IsMessageMandatory, DefaultMessage, IsLocationProximityOn, ProximityRadius, RadiusType, IsClickable);

            // Genarate App Thumb 
            objCommon.GenarateThumbnailForPSCApp(returnID, ProfileID, "PrivateSmartConnectModule", ImageUrls);
            if (returnID > 0)
            {
                // Update Long URL to Short URL
                string outerURL = objCommon.GetConfigSettings(Convert.ToString(ProfileID), "Paths", "RootPath");
                string ShortenURL = outerURL + "/OnlinePSCCallItem.aspx?CID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(CustomID)).Replace("=", "irhmalli").Replace("+", "irhPASS");

                ShortenURL = objCommon.longurlToshorturl(ShortenURL);
                CommonDAL.UpdateShortenURl(CustomID, ShortenURL, "PrivateSmartConnectAddOns");
            }

            return returnID;

        }


        public DataTable GetPSCContactsbyUserModuleID(int UserModuleID, string SearchText = "")
        {
            return PrivateSmartConnectDAL.GetPSCContactsbyUserModuleID(UserModuleID, SearchText);
        }

        public int CheckPSCAssignGroupToContact(int chkContactId, int groupId, int UserModuleID, int ProfileID)
        {
            return PrivateSmartConnectDAL.CheckPSCAssignGroupToContact(chkContactId, groupId, UserModuleID, ProfileID);
        }
        public DataSet GetPSCGroups(int userModuleId)
        {
            return PrivateSmartConnectDAL.GetPSCGroups(userModuleId);
        }
        public int CheckEmailExistsForPSC(string EmailID, int UserModuleID, int pContactID, string PhoneNumber)
        {
            return PrivateSmartConnectDAL.CheckEmailExistsForPSC(EmailID, UserModuleID, pContactID, PhoneNumber);
        }
        public string GetCallContactGroupsForPSC(int contactId)
        {
            return PrivateSmartConnectDAL.GetCallContactGroupsForPSC(contactId);
        }
        public int InsertUpdatePSCContacts(int contactID, string FirstName, string LastName, string EmailID, string CompanyName, string Address, string City, string State, string Zipcode, string Landline, string MobileNumber, string FaxNumber, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int UserID, int CreatedUser, string Position, string Organization, bool IsAllowedToSendIvitation, bool IsEmail_SMS_Unsubscribe)
        {
            return PrivateSmartConnectDAL.InsertUpdatePSCContacts(contactID, FirstName, LastName, EmailID, CompanyName, Address, City, State, Zipcode, Landline, MobileNumber, FaxNumber, IsActive, IsDeleted, UserModuleID, ProfileID, UserID, CreatedUser, Position, Organization, IsAllowedToSendIvitation, IsEmail_SMS_Unsubscribe);
        }
        public int AssignPSCGroupContactID(int assignID, int GroupID, int contactID, int UserModuleID, int ProfileID)
        {
            return PrivateSmartConnectDAL.AssignPSCGroupContactID(assignID, GroupID, contactID, UserModuleID, ProfileID);
        }


        /***************************** SmartConnect Categories April 18 2017 ************************************************/
        public DataTable GetPrivateSmartConnectCategories(int pUserModuleID, string pDomainName, int pProfileID)
        {
            return PrivateSmartConnectDAL.GetPrivateSmartConnectCategories(pUserModuleID, pDomainName, pProfileID);
        }

        public void DeletePrivateSmartConnectCategory(int pCategoryID, int pUserID, int pProfileID)
        {
            PrivateSmartConnectDAL.DeletePrivateSmartConnectCategory(pCategoryID, pUserID, pProfileID);
        }

        public int Insert_Update_PrivateSmartConnectCategory(int pCategoryID, string pCatName, string pDescription,
            int pUserModuleID, int pProfileID, int pUserID, string pCategoryType)
        {

            return PrivateSmartConnectDAL.Insert_Update_PrivateSmartConnectCategory(pCategoryID, pCatName, pDescription, pUserModuleID, pProfileID, pUserID, pCategoryType);
        }

        public DataTable GetPrivateSmartConnectCategoryDetailsByID(int pCategoryID)
        {
            return PrivateSmartConnectDAL.GetPrivateSmartConnectCategoryDetailsByID(pCategoryID);
        }


        public DataSet GetPSCGroupByID(int GroupID)
        {
            return PrivateSmartConnectDAL.GetPSCGroupByID(GroupID);
        }

        public void DeletePscindexItem(int pCustomID, int UserID)
        {
            PrivateSmartConnectDAL.DeletePscindexItem(pCustomID, UserID);
        }
        public int CheckAssignGroupToContactforPSC(int chkContactId, int groupId, int UserModuleID)
        {
            return PrivateSmartConnectDAL.CheckAssignGroupToContactforPSC(chkContactId, groupId, UserModuleID);
        }
        public int AddGroup(int GroupID, string GroupName, string GroupDescription, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int CreatedUser, int UserID)
        {
            return PrivateSmartConnectDAL.AddGroup(GroupID, GroupName, GroupDescription, IsActive, IsDeleted, UserModuleID, ProfileID, CreatedUser, UserID);
        }
        public void UpdatePSCAddonOrder(int customID, int OrderNo, int ID)
        {
            PrivateSmartConnectDAL.UpdatePSCAddonOrder(customID, OrderNo, ID);
        }



        /// <summary>
        /// Adding Group
        /// </summary>
        /// <param name="GroupID">GroupID</param>
        /// <param name="GroupName">GroupName</param>
        /// <param name="GroupDescription">GroupDescription</param>
        /// <param name="IsActive">IsActive</param>
        /// <param name="IsDeleted">IsDeleted</param>
        /// <param name="UserModuleID">UserModuleID</param>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="CreatedUser">CreatedUser</param>
        /// <param name="UserID">UserID</param>
        /// <returns>Int</returns>
        public int AddGroupForPSC(int GroupID, string GroupName, string GroupDescription, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int CreatedUser, int UserID)
        {
            return PrivateSmartConnectDAL.AddGroupForPSC(GroupID, GroupName, GroupDescription, IsActive, IsDeleted, UserModuleID, ProfileID, CreatedUser, UserID);
        }
        public void DeleteGroupsForPSC(string groupIds)
        {
            PrivateSmartConnectDAL.DeleteGroupsForPSC(groupIds);
        }
        public DataSet GetGroupByIDForPSC(int GroupID)
        {
            return PrivateSmartConnectDAL.GetGroupByIDForPSC(GroupID);
        }
        public DataSet GetPSCActiveGroups(int UserModuleID)
        {
            return PrivateSmartConnectDAL.GetPSCActiveGroups(UserModuleID);
        }
        public int DeleteContactsForPSC(string contactIds)
        {
            return PrivateSmartConnectDAL.DeleteContactsForPSC(contactIds);
        }
        public DataSet GetContactByIDForPSC(int ContactID)
        {
            return PrivateSmartConnectDAL.GetContactByIDForPSC(ContactID);
        }
        public DataTable SearchEmailIDForPSC(string searchText, int UserModuleID)
        {
            return PrivateSmartConnectDAL.SearchEmailIDForPSC(searchText, UserModuleID);
        }
        public int InsertImportContactsForPSC(int contactID, string FirstName, string LastName, string EmailID, string CompanyName, string Address, string City, string State, string Zipcode, string Landline, string MobileNumber, string FaxNumber, bool IsActive, bool IsDeleted, int UserModuleID, int ProfileID, int UserID, int CreatedUser, int groupId, string Title, string Organization)
        {
            return PrivateSmartConnectDAL.InsertImportContactsForPSC(contactID, FirstName, LastName, EmailID, CompanyName, Address, City, State, Zipcode, Landline, MobileNumber, FaxNumber, IsActive, IsDeleted, UserModuleID, ProfileID, UserID, CreatedUser, groupId, Title, Organization);
        }
        public void CreateImage(string path, int profileID, int userID, int CustomID, string html)
        {
            try
            {
                // Get the server IP and port
                string serverIP = ConfigurationManager.AppSettings.Get("Winnovative_serverIP");
                uint serverPort = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("Winnovative_serverPort"));

                // Create a HTML to Image converter object with default settings
                HtmlToImageConverter htmlToImageConverter = new HtmlToImageConverter(serverIP, serverPort);

                // Set license key received after purchase to use the converter in licensed mode
                // Leave it not set to use the converter in demo mode
                htmlToImageConverter.LicenseKey = ConfigurationManager.AppSettings.Get("WinnovativePDFKey");

                // Set HTML Viewer width in pixels which is the equivalent in converter of the browser window width
                htmlToImageConverter.HtmlViewerWidth = 600;
                // Set if the created image has a transparent background
                htmlToImageConverter.TransparentBackground = false;

                htmlToImageConverter.NavigationTimeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Winnovative_NavigationTimeout"));
                htmlToImageConverter.ConversionDelay = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Winnovative_ConversionDelay"));
                string strhtml = html;
                // byte[] buffer = System.Text.Encoding.UTF8.GetBytes(strhtml.ToString());
                string saveFilePath = path + profileID.ToString();
                if (!System.IO.Directory.Exists(saveFilePath))
                {
                    System.IO.Directory.CreateDirectory(saveFilePath);
                }
                string savelocation = saveFilePath + "\\" + CustomID.ToString() + ".jpg";
                string tempimagepath = path + profileID.ToString() + "\\" + profileID.ToString() + userID.ToString() + ".jpg";
                if (File.Exists(savelocation))
                {
                    File.Delete(savelocation);
                }
                string baseUrl = "";

                htmlToImageConverter.ConvertHtmlToFile(html, baseUrl, Winnovative.HtmlToPdfClient.ImageType.Jpeg, tempimagepath);

                string srcfile = tempimagepath;
                string destfile = savelocation;
                int thumbWidth = Convert.ToInt32(ConfigurationManager.AppSettings.Get("QRsrcWidth"));
                System.Drawing.Image image = System.Drawing.Image.FromFile(srcfile);
                int srcWidth = Convert.ToInt32(ConfigurationManager.AppSettings.Get("QRsrcWidth"));
                int srcHeight = Convert.ToInt32(ConfigurationManager.AppSettings.Get("QRsrcHeight"));
                Decimal sizeRatio = ((Decimal)srcHeight / srcWidth);
                int thumbHeight = Decimal.ToInt32(sizeRatio * thumbWidth);
                Bitmap bmp = new Bitmap(srcWidth, srcHeight);
                System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, srcWidth, srcHeight);
                gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);
                bmp.Save(destfile);
                bmp.Dispose();
                image.Dispose();
                if (File.Exists(tempimagepath))
                {
                    File.Delete(tempimagepath);
                }

            }
            catch (Exception ex)
            {
                //Error 
                InBuiltDataBLL objbuiltbll = new InBuiltDataBLL();
                objbuiltbll.ErrorHandling("ERROR", "InBuiltDataBLL", "CreateImage", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

            }
        }

        public DataTable GetPSC_CallsHistory(bool pIsAllItems, int pHistoryID, int pProfileID,int pUserModuleID = 0, bool? IsRead = false, bool? IsArchive = false)
        {
            return PrivateSmartConnectDAL.GetPSC_CallsHistory(pIsAllItems, pHistoryID, pProfileID,pUserModuleID, IsRead, IsArchive );
        }
        public DataTable GetPieChartDataForPSCMessages(int ProfileID, bool IsArchive,int pUMID = 0, int? GraphCurrentArchive = null)
        {
            return PrivateSmartConnectDAL.GetPieChartDataForPSCMessages(ProfileID, IsArchive,pUMID, GraphCurrentArchive);
        }

        public void DeletePSCCallHistory(int pHistoryID,int pProfileID)
        {
            PrivateSmartConnectDAL.DeletePSCCallHistory(pHistoryID, pProfileID);
        }
        //Assigning Category to SmartConnect Messages
        public void AssignCategoryForPSCMessage(int CallAddOnsHistoryID, int CategoryID)
        {
            PrivateSmartConnectDAL.AssignCategoryForPSCMessage(CallAddOnsHistoryID, CategoryID);
        }
        //Search the Private SmartConnectMessage by using startdate,enddate,category,text
        public DataSet GetPSCMessagesSearch(string CategoryID, string searchText, int ProfileID, bool IsArchive,int pUMID = 0,
            DateTime? startDate = null, DateTime? endDate = null)
        {
            return PrivateSmartConnectDAL.GetPSCMessagesSearch(CategoryID, searchText, ProfileID, IsArchive, pUMID, startDate, endDate);
        }

        /// <summary>
        /// Block UnBlock Message Senders
        /// </summary>
        /// <param name="messageID">messageID</param>
        /// <param name="blockFlag">blockFlag</param>
        /// <param name="userID">userID</param>
        /// <returns>Int</returns>
        public int BlockUnBlockPSCSenders(int messageID, bool blockFlag, int userID)
        {
            return PrivateSmartConnectDAL.BlockUnBlockPSCSenders(messageID, blockFlag, userID);
        }
        public DataTable GetRead_Unread_PSCCalls(int ProfileID, bool IsRead, bool IsArchive, int pUMID)
        {
            return PrivateSmartConnectDAL.GetRead_Unread_PSCCalls(ProfileID, IsRead, IsArchive, pUMID);
        }
        public int ChangePSCCallAddOnVisiblity(int customId, int modifiedUser)
        {
            return PrivateSmartConnectDAL.ChangePSCCallAddOnVisiblity(customId, modifiedUser);
        }

        public string FindCoordinates(string Address)
        {
            string Coordinates = "";
            DataTable dtCoordinates = new DataTable();
            string url = "http://maps.google.com/maps/api/geocode/xml?address=" + Address + "&sensor=false";
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);
                    if (dsResult.GetXml().Contains("ZERO_RESULTS"))
                    {

                        return Coordinates = "ZERO_RESULTS";
                    }
                    else
                    {
                        dtCoordinates.Columns.AddRange(new DataColumn[2] { 
                        new DataColumn("Latitude",typeof(string)),
                        new DataColumn("Longitude",typeof(string)) });
                        foreach (DataRow row in dsResult.Tables["result"].Rows)
                        {
                            string geometry_id = dsResult.Tables["geometry"].Select("result_id = " + row["result_id"].ToString())[0]["geometry_id"].ToString();
                            DataRow location = dsResult.Tables["location"].Select("geometry_id = " + geometry_id)[0];
                            dtCoordinates.Rows.Add(location["lat"], location["lng"]);
                        }
                        return Coordinates = dtCoordinates.Rows[0]["Latitude"] + "," + dtCoordinates.Rows[0]["Longitude"];
                    }

                }
            }



        }
        public DataTable GetAllPSCModulesbyProfileID(int ProfileID)
        {
            return PrivateSmartConnectDAL.GetAllPSCModulesbyProfileID(ProfileID);
        }

        public   DataTable GetQRConnectCredits_Usage_Details(int pProfileID)
        {
            return PrivateSmartConnectDAL.GetQRConnectCredits_Usage_Details(pProfileID);
        }

        public int CopyQRConnect(int QRConnectID, string QRConnectTitle, int UserID, int pProfileID)
        {
            int copyNewBID = PrivateSmartConnectDAL.CopyQRConnect(QRConnectID, QRConnectTitle, UserID);

            #region MyRegion Update Long URL to Short URL

            // Update Long URL to Short URL
            string outerURL = objCommon.GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");
            string ShortenURL = outerURL + "/OnlinePSCCallItem.aspx?CID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(QRConnectID)).Replace("=", "irhmalli").Replace("+", "irhPASS");

            ShortenURL = objCommon.longurlToshorturl(ShortenURL);
            CommonDAL.UpdateShortenURl(QRConnectID, ShortenURL, "PrivateSmartConnectAddOns");

            #endregion

            #region    Genarate  Thumb

            DataTable dtCopyBulletinDetails = GetPSCCallIndexByID(copyNewBID);
            if (dtCopyBulletinDetails.Rows.Count > 0)
            {
                // Genarate App Thumb 
                objCommon.GenarateThumbnailForApp(copyNewBID, pProfileID, "Bulletins", dtCopyBulletinDetails.Rows[0]["ImageUrls"].ToString());

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Web Thumb
              //  objInBuiltData.CreateImage(HttpContext.Current.Server.MapPath("~") + "\\Upload\\Bulletins\\", pProfileID, UserID, copyNewBID, dtCopyBulletinDetails.Rows[0]["Bulletin_HTML"].ToString());
            }

            #endregion

            return copyNewBID;
        }


        public int CheckforDuplicateTitle(string Title)
        {
            return PrivateSmartConnectDAL.CheckforDuplicateTitle(Title);
        
        }
    }
}
