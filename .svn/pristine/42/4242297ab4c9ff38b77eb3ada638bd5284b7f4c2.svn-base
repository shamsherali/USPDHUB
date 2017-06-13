using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using UserFormsDAL;
using System.Xml.Linq;
using System.IO;
using System.Web;
using System.Data.SqlClient;
using System.Net;
using System.Xml;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data.SqlClient;

namespace UserFormsBLL
{
    public class CommonBLL
    {
        /// <summary>
        /// for deleting user profile image
        /// </summary>
        /// <param name="imageId">imageId</param>
        /// <param name="modifiedUser">modifiedUser</param>
        public void DeleteUserProfileImage(int imageId, int modifiedUser)
        {
            CommonDAL.DeleteUserProfileImage(imageId, modifiedUser);
        }
        /// <summary>
        /// for checking user profile image
        /// </summary>
        /// <param name="profileId">profileid</param>
        /// <param name="imgName">imgname</param>
        /// <returns>boolean</returns>
        public bool CheckUserProfileImage(int profileId, string imgName)
        {
            return CommonDAL.CheckUserProfileImage(profileId, imgName);
        }
        /// <summary>
        /// inserts amn image to user profile
        /// </summary>
        /// <param name="profileId">profileid</param>
        /// <param name="userId">userid</param>
        /// <param name="createdUser">createduser</param>
        /// <param name="imgPath">imgpath</param>
        /// <param name="imgName">imgname</param>
        /// <param name="imgDimension">imgdimension</param>
        public void InsertUserProfileImage(int profileId, int userId, int createdUser, string imgPath, string imgName, string imgDimension)
        {
            CommonDAL.InsertUserProfileImage(profileId, userId, createdUser, imgPath, imgName, imgDimension);
        }
        /// <summary>
        /// flips an image
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
        /// for saving flipped image
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
        /// retrieves user profile images
        /// </summary>
        /// <param name="profileId">profileId</param>
        /// <param name="searchImage">searchImage</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserProfileImages(int profileId, string searchImage)
        {
            return CommonDAL.GetUserProfileImages(profileId, searchImage);
        }
        /// <summary>
        /// adds ann access types to profiles
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
        /// retrieves access types of profiles by profile id and message type
        /// </summary>
        /// <param name="profileId">profileid</param>
        /// <param name="messagetype">mesagetype</param>
        /// <returns>datatable</returns>
        public DataTable GetProfileAccessTypes(int profileId, string messagetype)
        {
            return CommonDAL.GetProfileAccessTypes(profileId, messagetype);
        }
        /// <summary>
        /// inserts user's activity log 
        /// </summary>
        /// <param name="pDescription">Description</param>
        /// <param name="pNavigationLink">NavigationLink</param>
        /// <param name="pUserID">UserID</param>
        /// <param name="pProfileID">ProfileID</param>
        /// <param name="pCreatedDate">CreatedDate</param>
        /// <param name="pCreatedBy">CreatedBy</param>
        public void InsertUserActivityLog(string pDescription, string pNavigationLink, int pUserID, int pProfileID, DateTime pCreatedDate, int pCreatedBy)
        {
            CommonDAL.InsertUserActivityLog(pDescription, pNavigationLink, pUserID, pProfileID, pCreatedDate, pCreatedBy);
        }
        /// <summary>
        /// for retrieving custom form header
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>string</returns>
        public string GetCustomFormHeader(int userID)
        {
            return CommonDAL.GetCustomFormHeader(userID);
        }
        /// <summary>
        /// for retrieving verticl configs by type
        /// </summary>
        /// <param name="vertical">vertical</param>
        /// <param name="type">type</param>
        /// <returns>datatable</returns>
        public DataTable GetVerticalConfigsByType(string vertical, string type)
        {
            return CommonDAL.GetVerticalConfigsByType(vertical, type);
        }
        /// <summary>
        /// for retrieving domain details
        /// </summary>
        /// <param name="verticalDomain">verticalDomain</param>
        /// <returns>datatable</returns>
        public DataTable GetDomainDetails(string verticalDomain)
        {
            return CommonDAL.GetDomainDetails(verticalDomain);
        }
        /// <summary>
        /// for creating domain url
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>string</returns>
        public string CreateDomainUrl(string url)
        {
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
            return verticalDomain;
        }
        /// <summary>
        /// for getting location by ipadress
        /// </summary>
        /// <param name="ipaddress">ipaddress</param>
        /// <returns>data table</returns>
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
        /// get menu links
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable GetMasterMenuLinks()
        {
            return CommonDAL.GetMasterMenuLinks();
        }
        /// <summary>
        /// for getting parent menu links
        /// </summary>
        /// <param name="isLiteVersion">isLiteVersion</param>
        /// <returns>datatble</returns>
        public DataTable GetParentMenuLinks(bool isLiteVersion)
        {
            return CommonDAL.GetParentMenuLinks(isLiteVersion);
        }
        /// <summary>
        /// retrievig help master menu links
        /// </summary>
        /// <param name="isLiteVersion">isLiteVersion</param>
        /// <returns>datatable</returns>
        public DataTable GetHelpMasterMenuItems(bool isLiteVersion)
        {
            return CommonDAL.GetHelpMasterMenuItems(isLiteVersion);
        }
        /// <summary>
        /// for retrieving helpchildmenu for master id
        /// </summary>
        /// <param name="helpMasterID">helpMasterID</param>
        /// <returns>datatable</returns>
        public DataTable GetHelpChildMenuForMasterID(int helpMasterID)
        {
            return CommonDAL.GetHelpChildMenuForMasterID(helpMasterID);
        }
        /// <summary>
        /// getting help search details
        /// </summary>
        /// <param name="helpName">help name</param>
        /// <param name="isLiteVersion">isLiteVersion</param>
        /// <returns>list of strings</returns>
        public List<string> GetHelpSearchDetails(string helpName, bool isLiteVersion)
        {
            return CommonDAL.GetHelpSearchDetails(helpName, isLiteVersion);
        }
        /// <summary>
        /// get help menu details by helpid
        /// </summary>
        /// <param name="helpID">helpID</param>
        /// <returns>data table</returns>
        public DataTable GetHelpmenuDetailsbyHelpID(int helpID)
        {
            return CommonDAL.GetHelpmenuDetailsbyHelpID(helpID);
        }
        /// <summary>
        /// for returning user pernmissions
        /// </summary>
        /// <param name="AssociateID">AssociateID</param>
        /// <param name="moduleID">moduleID</param>
        /// <param name="moduleName">moduleName</param>
        /// <returns>string</returns>
        public string returnUserPermission(int AssociateID, int moduleID, string moduleName)
        {
            //USPD-1107 and USPD-1116 Permission related Changes
            string retValue = string.Empty;
            string ModuleName = string.Empty;
            string segName = string.Empty;
            AddOnBLL objAddOn = new AddOnBLL();
            BusinessBLL objBus = new BusinessBLL();
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
            else if (moduleID > 0)
            {
                dtAddOn = objAddOn.GetAddOnById(moduleID);
                if (dtAddOn.Rows.Count == 1)
                    ModuleName = dtAddOn.Rows[0]["TabName"].ToString();
            }
            else
                ModuleName = moduleName;
            DataTable dtpermissions = objBus.GetPermissionsByAssociateId(AssociateID);
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
                        moduleName == CommonModules.WebLinks || moduleName == CommonModules.SocialMedia)
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
                    if (segName == "CalendarAddOn" || segName == "AddOn" || segName == "PrivateAddOn")
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
        /// for replacing short url to html string
        /// </summary>
        /// <param name="pHtmlString">HtmlString</param>
        /// <returns>string</returns>
        public string ReplaceShortURltoHtmlString(string pHtmlString)
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

            return pHtmlString;
        }
        /// <summary>
        /// for converting long url to short url
        /// </summary>
        /// <param name="longurl">longurl</param>
        /// <returns>string</returns>
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
                string responseText;

                using (var reader = new StreamReader(exception.Response.GetResponseStream()))
                {
                    responseText = reader.ReadToEnd();
                }
                ErrorHandling("ERROR ", "CommonBLL.cs", "longurlToshorturl", responseText,
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

        #region Error Log

        public void ErrorHandling(string errorType, string pPageName, string methodName, string message, string strackTrace, string innerException, string data)
        {
            bool isErrorLog = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("IsErrorLog"));

            if (isErrorLog == true || errorType != "LOG ")
            {
                string strLogFile = "";
                string errorLogFolder = ConfigurationManager.AppSettings.Get("USPDFolderPath") + "\\Upload\\ErrorLog\\";

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
        /// for getting configuration settings
        /// </summary>
        /// <param name="pProfileID">profileid</param>
        /// <param name="pType">type</param>
        /// <param name="pConfigName">configname</param>
        /// <returns>string</returns>
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
        ///for getting DomainName By Country and Vertical.
        /// </summary>
        /// <param name="vertical">vertical</param>
        /// <param name="country">country</param>
        /// <returns>string</returns>
        public string GetDomainNameByCountryVertical(string vertical, string country)
        {
            return CommonDAL.GetDomainNameByCountryVertical(vertical, country);
        }
        /// <summary>
        /// generates thumbnail for app
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

                string uspdUploadFolderPath = ConfigurationManager.AppSettings.Get("USPDFolderPath") + "/upload";
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
        /// for converting the timezone to user time zone
        /// </summary>
        /// <param name="profileID">profileid</param>
        /// <returns>datetime</returns>
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
            dtNow = TimeZoneInfo.ConvertTimeFromUtc(dtNow, TimeZoneInfo.FindSystemTimeZoneById(timeZone));
            return dtNow;
        }
        /// <summary>
        /// for retrieving the bulletin categories by vertical
        /// </summary>
        /// <param name="profileID">profileid</param>
        /// <returns></returns>
        public DataTable GetBulletinCategoriesByVertical(int profileID, bool? contentModule = false)
        {
            return CommonDAL.GetBulletinCategoriesByVertical(profileID, contentModule);
        }

        /// <summary>
        /// for checking whether the auto share record exists or not
        /// </summary>
        /// <param name="contentType">contentType</param>
        /// <param name="contentId">contentId</param>
        /// <param name="contentTitle">contentTitle</param>
        /// <returns>data table</returns>
        public DataTable CheckAutoShareRecordExists(string contentType, int contentId, string contentTitle)
        {
            return CommonDAL.CheckAutoShareRecordExists(contentType, contentId, contentTitle);
        }
        /// <summary>
        /// for retrieving the text for logo header
        /// </summary>
        /// <param name="pUserID">userid</param>
        /// <param name="pProfileID">profileid</param>
        /// <param name="pRootPath">rootpath</param>
        /// <returns>string</returns>
        public string GetLogoHeaderText(int pUserID, int pProfileID, string pRootPath)
        {
            string logoPath = "";
            string profileName = "";
            string address = "";
            DataTable dtProfile = BusinessDAL.GetProfileDetailsByProfileID(pProfileID);
            string logourl = Convert.ToString(dtProfile.Rows[0]["Profile_logo_path"]);

            #region Logo Details
            string originalfilename = logourl;
            string extension = System.IO.Path.GetExtension(originalfilename);
            string junk = ".";
            string[] ret = originalfilename.Split(junk.ToCharArray());
            string thumbimg1 = ret[0];
            thumbimg1 = thumbimg1 + "_thumb" + extension;
            string url = ConfigurationManager.AppSettings.Get("USPDFolderPath") + "\\Upload\\Logos\\" + pProfileID + "\\" + thumbimg1;
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
            string strfilepath = ConfigurationManager.AppSettings.Get("USPDFolderPath") + "\\BulletinPreview\\LogoHeaderText.txt";
            bool IsShortLogo = Convert.ToBoolean(dtProfile.Rows[0]["IsShortLogo"]);
            if (IsShortLogo)
            {
                address = GetBulletinFormHeader(pUserID, pProfileID);
                profileName = HttpContext.Current.Session["profilename"].ToString();
            }
            else
                strfilepath = ConfigurationManager.AppSettings.Get("USPDFolderPath") + "\\BulletinPreview\\LongLogoHeaderText.txt";

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
        /// for getting form header of a bulletin
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="profileID">profileID</param>
        /// <returns>string</returns>
        public string GetBulletinFormHeader(int userID, int profileID)
        {
            string address = "";
            string xmlSettings = "";
            string header = "<span style=\"text-align: center;\">#AgencyAddress#</span><h4 style=\"font-size: 16px; line-height: 28px; font-weight: bold; color: #383838; text-align: center; margin: 0px; padding: 0px;\">#EmergencyNumber#</h4>";
            DataTable dtProfile = BusinessDAL.GetProfileDetailsByProfileID(profileID);
            if (dtProfile.Rows.Count > 0)
            {
                bool IsShortLogo = Convert.ToBoolean(dtProfile.Rows[0]["IsShortLogo"]);
                DataTable dtMobileAppSettings = UserFormsDAL.MobileAppSettings.GetMobileAppSetting(userID);
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
        // Header for ALL Bulletins
        /// <summary>
        /// for getting a header for buuletins
        /// </summary>
        /// <param name="userID">userid</param>
        /// <param name="profileID">profileid</param>
        /// <param name="IsWeeklyReport">ISWeeklyReport</param>
        /// <returns>string</returns>
        public string GetHeaderForBulletins(int userID, int profileID, bool IsWeeklyReport = false)
        {
            string address = string.Empty;
            string xmlSettings = string.Empty;
            string strHeader = "";
            string strfilepath = ConfigurationManager.AppSettings.Get("USPDFolderPath") + "\\BulletinPreview\\CommonHeader.txt";
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
                DataTable dtMobileAppSettings = UserFormsDAL.MobileAppSettings.GetMobileAppSetting(userID);
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
        /// for sending authorized notifications
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="typeName">typeName</param>
        /// <param name="userID">userID</param>
        /// <param name="pUsername">username</param>
        /// <param name="pagename">pagename</param>
        /// <param name="domainName">domian name</param>
        /// <returns>string</returns>
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
        /// for getting content for the author
        /// </summary>
        /// <param name="typeName">typename</param>
        /// <param name="bulletinID">bulletinid</param>
        /// <param name="userID">userid</param>
        /// <returns>string</returns>
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
                    contentBody = dtContent.Rows[0]["EventDesc"].ToString();
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
        /// for retrieving author tab name
        /// </summary>
        /// <param name="typeName">typename</param>
        /// <param name="bulletinID">bulletinid</param>
        /// <param name="userID">userid</param>
        /// <param name="moduleName">modulename</param>
        /// <returns>string</returns>
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
        /// for retrieving the message body of an email
        /// </summary>
        /// <param name="userName"username></param>
        /// <param name="userID">userID</param>
        /// <param name="typeName">typeName</param>
        /// <param name="bulletinID">bulletinID</param>
        /// <param name="domainName">domainName</param>
        /// <param name="moduleName">moduleName</param>
        /// <returns>string</returns>
        private string GetEmailMessageBody(string userName, int userID, string typeName, int bulletinID, string domainName, string moduleName)
        {
            string rootPath = HttpContext.Current.Session["RootPath"].ToString();
            string strfilepath = ConfigurationManager.AppSettings.Get("USPDFolderPath") + "\\EmailContent" + domainName + "\\";
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
        /// for having an survey preview
        /// </summary>
        /// <param name="surveyId">surveyId</param>
        /// <returns>string</returns>
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
        /// for inserting and updating auto share details
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
        /// for updating sent flag
        /// </summary>
        /// <param name="contentId">contentId</param>
        /// <param name="flag">flag</param>
        /// <param name="existingFlag">flag</param>
        /// <param name="contentType">contentType</param>
        public void UpdateSentFlag(int contentId, int flag, int existingFlag, string contentType)
        {
            EventCalendarDAL.UpdateSentFlag(contentId, flag, existingFlag, contentType);
        }

        public DataTable CheckingModuleExists(int pProfileID, string pButtonType)
        {
            return CommonDAL.CheckingModuleExists(pProfileID, pButtonType);
        }

    }

    public static class ButtonTypes
    {
        public const string Tips = "Tips";
        public const string ContactUs = "Contact";
        public const string SmartConnect = "PublicCallAddOns";
        public const string PrivateCall = "PrivateCallAddOns";

    }

    public static class PageNames //Roles & Permissions...
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
    }

}
