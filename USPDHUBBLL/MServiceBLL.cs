using System;
using System.Linq;
using System.Data;
using System.Configuration;
using USPDHUBDAL;
using System.Xml.Linq;
using System.IO;
using System.Web;
using System.Net.Mime;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace USPDHUBBLL
{
    public class MServiceBLL
    {
        public string ErrorMessage = "ERROR";

        public CommonBLL objCommonBLL = new CommonBLL();
        public DataTable dtConfigs = new DataTable("configsettings");

        /// <summary>
        /// Get Config Settings
        /// </summary>
        /// <param name="pProfileID">ProfileID</param>
        /// <param name="pType">Type</param>
        /// <param name="pConfigName">ConfigName</param>
        /// <returns>String</returns>
        public string GetConfigSettings(string pProfileID, string pType, string pConfigName)
        {
            string returnValue = "";
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetConfigSettings()", string.Empty, string.Empty, string.Empty, string.Empty);

                string verticalCode = MServiceDAL.GetVerticalNameByProfileID(Convert.ToInt32(pProfileID));


                DataTable dtProfileDetails = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
                string countryName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);


                string domain = objCommonBLL.GetDomainNameByCountryVertical(verticalCode, countryName.Trim());

                dtConfigs = objCommonBLL.GetVerticalConfigsByType(domain, pType);
                if (dtConfigs.Rows.Count > 0)
                {
                    for (int i = 0; i < dtConfigs.Rows.Count; i++)
                    {
                        if (Convert.ToString(dtConfigs.Rows[i]["Name"]) == pConfigName)
                        {
                            returnValue = Convert.ToString(dtConfigs.Rows[i]["Value"]).Trim();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetConfigSettings()", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                returnValue = ErrorMessage;
            }
            return returnValue;
        }

        #region Error Log
        /// <summary>
        /// Error Handling
        /// </summary>
        /// <param name="errorType">errorType</param>
        /// <param name="pPageName">PageName</param>
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

        /// <summary>
        /// Home Tabs details like Home description  & image
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return home details as string</returns>
        public string HomeTabDetails(string pProfileID, string pTabletName, string pDeviceWidth)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "HomeTabDetails()", string.Empty, string.Empty, string.Empty, string.Empty);


                string description = "";

                DataTable dt = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
                if (dt.Rows.Count > 0)
                {
                    string replaceText = @"<script language=""javascript"" type=""text/javascript"" src=""/B1D671CF-E532-4481-99AA-19F420D90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";
                    string replaceText1 = @"<script language=javascript type=text/javascript src=""/b1d671cf-e532-4481-99aa-19f420d90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";

                    description = Convert.ToString(dt.Rows[0]["Profile_Description"]).Replace(replaceText, string.Empty);
                    description = description.Replace(replaceText1, string.Empty);

                    description = BuildHeader().Replace("#BuildHtmlForForm#", description);
                    description = description.Replace("margin-left:20px;", "margin-left:0px;");
                    description = description.Replace("margin-left: 20px;", "margin-left: 0px;");
                }

                #region Device Width wise preview html data setting.

                ErrorHandling("LOG ", "MServiceBLL.cs", "HomeTabDetails()---pTabletName" + pTabletName, "pDeviceWidth" + pDeviceWidth,
                    string.Empty, string.Empty, string.Empty);

                if (Convert.ToString(pTabletName) != string.Empty)
                {
                    ErrorHandling("LOG ", "MServiceBLL.cs", "HomeTabDetails()", string.Empty, string.Empty, string.Empty, string.Empty);

                    description = ReplaceWidthTabletDevices(description, pTabletName, pDeviceWidth);
                }

                #endregion

                return description;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "HomeTabDetails()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting About Us Details by Profile ID
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return about us details as XML string</returns>
        public string GetAboutUsDetails(string pProfileID, string pTabletName, string pDeviceWidth)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetAboutUsDetails()", string.Empty, string.Empty, string.Empty, string.Empty);

                string xmlAboutUs = string.Empty;
                DataTable dt = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
                if (dt.Rows.Count > 0)
                {
                    string replaceText = @"<script language=""javascript"" type=""text/javascript"" src=""/B1D671CF-E532-4481-99AA-19F420D90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";
                    string replaceText1 = @"<script language=javascript type=text/javascript src=""/b1d671cf-e532-4481-99aa-19f420d90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";


                    string descrition = Convert.ToString(dt.Rows[0]["Profile_Aboutus"]).Replace(replaceText, string.Empty);
                    descrition = descrition.Replace(replaceText1, string.Empty);

                    descrition = BuildHeader().Replace("#BuildHtmlForForm#", descrition);
                    descrition = descrition.Replace("margin-left:20px;", "margin-left:0px;");
                    descrition = descrition.Replace("margin-left: 20px;", "margin-left: 0px;");

                    xmlAboutUs = descrition;
                }

                #region Device Width wise preview html data setting.

                if (Convert.ToString(pTabletName) != string.Empty)
                {
                    xmlAboutUs = ReplaceWidthTabletDevices(xmlAboutUs, pTabletName, pDeviceWidth);
                }

                #endregion

                return xmlAboutUs;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetAboutUsDetails()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting User Buy Tools & Business Tools Names & Icons Settings by Profile ID
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <param name="pIconSize">param is pIconSize</param>
        /// <returns>return tools as XML string</returns>
        public string GetSelectedTools(string pProfileID, string pIconSize, int pBrandedAppName, string pNewTabs, bool pIsNewIcons)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetSelectedTools()", string.Empty, string.Empty, string.Empty, string.Empty);

                string xmlSelectedTools = string.Empty;
                string address = string.Empty;
                bool showBulletins = false;

                ////Getting Update profile details by UserID
                //DataTable dtProfileDetails = USPDHUBDAL.MServiceDAL.GetProfileDetails(Convert.ToInt32(pUserID));
                // 2 Means getting details by Profile ID
                DataTable dtProfileDetails = USPDHUBDAL.MServiceDAL.GetProfiledetailsByBCode(string.Empty, Convert.ToInt32(pProfileID), "2", "0.0", "0.0", "0", "1");

                #region Address , Phome Number and Bulletins Display Settings

                if (Convert.ToString(dtProfileDetails.Rows[0]["Profile_StreetAddress2"]) == string.Empty)
                {
                    address = Convert.ToString(dtProfileDetails.Rows[0]["Profile_StreetAddress1"]);
                }
                else
                {
                    address = Convert.ToString(dtProfileDetails.Rows[0]["Profile_StreetAddress1"]) + ", " + Convert.ToString(dtProfileDetails.Rows[0]["Profile_StreetAddress2"]);
                }

                address = ReplaceSpecialCharacter(address);

                if (!string.IsNullOrEmpty(dtProfileDetails.Rows[0]["Package_Number"].ToString()))
                {
                    if (Convert.ToInt32(dtProfileDetails.Rows[0]["Package_Number"].ToString()) > 4)
                    {
                        showBulletins = true;
                    }
                }

                var toolsSettings1 = GetSelectedToolsSettings(Convert.ToInt32(dtProfileDetails.Rows[0]["User_ID"]), showBulletins);

                var phoneNumber = "";
                string toolsSettings = "<SubTools><Tools " + toolsSettings1 + "/></SubTools>";
                var xmlTools = XElement.Parse(toolsSettings, LoadOptions.PreserveWhitespace);

                //Getting mobile number based on mobile app settings Radio phone numbers
                if (xmlTools.Element("Tools").Attribute("IsMainPH") == null)
                {
                    phoneNumber = Convert.ToString(dtProfileDetails.Rows[0]["Mobile_Number"]);
                }
                else
                {
                    if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsMainPH").Value) == true)
                    {
                        phoneNumber = Convert.ToString(dtProfileDetails.Rows[0]["Mobile_Number"]);
                    }
                    else
                    {
                        phoneNumber = Convert.ToString(dtProfileDetails.Rows[0]["Alternate_Phone"]);
                    }
                }

                #endregion

                #region Agency Logo Path Assign

                string logoName = "";
                logoName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_logo_path"]);
                int logoprofileid = Convert.ToInt32(pProfileID);
                if (!string.IsNullOrEmpty(dtProfileDetails.Rows[0]["Parent_ProfileID"].ToString()))
                {
                    logoprofileid = Convert.ToInt32(dtProfileDetails.Rows[0]["Parent_ProfileID"].ToString());
                    DataTable dtparentProfile = USPDHUBDAL.MServiceDAL.GetProfiledetailsByBCode(string.Empty, logoprofileid, "2", "0.0", "0.0", "0", "1");
                    logoName = Convert.ToString(dtparentProfile.Rows[0]["Profile_logo_path"]);
                }

                string extension = System.IO.Path.GetExtension(logoName);
                if (logoName == string.Empty)
                {
                    extension = ".jpg";
                }

                string logoFullPath = "";

                string logoServerpath = HttpContext.Current.Server.MapPath("\\Upload\\Logos\\");
                logoServerpath = logoServerpath + logoprofileid + "\\" + logoprofileid + "_thumb" + extension;

                string outerURL = GetConfigSettings(Convert.ToString(dtProfileDetails.Rows[0]["Profile_ID"]), "Paths", "RootPath");

                if (File.Exists(logoServerpath) && logoName != string.Empty)
                {
                    logoFullPath = outerURL + "/Upload/Logos/" +
                      logoprofileid + "/" + logoprofileid + "_thumb" + extension;
                }
                else
                {
                    logoFullPath = outerURL + "/Upload/ComingSoonIcons/logo.png";
                }

                #endregion

                #region Agency Record checking Parent or Child

                bool isParent = true;
                if (Convert.ToString(dtProfileDetails.Rows[0]["Parent_ProfileID"]) == string.Empty)
                {
                    isParent = true;
                }
                else
                {
                    isParent = false;
                }

                #endregion


                string profileSettings = " P_PName='" + ReplaceSpecialCharacter(Convert.ToString(dtProfileDetails.Rows[0]["Profile_name"])) + "'" +
                           " P_BName='" + ReplaceSpecialCharacter(Convert.ToString(dtProfileDetails.Rows[0]["Profile_displayname"])) + "'" +
                           " P_Logo='" + logoFullPath + "'" +
                           " P_Address='" + address + "'" +
                           " P_MobileNumber='" + phoneNumber + "'" +
                           " P_City='" + ReplaceSpecialCharacter(Convert.ToString(dtProfileDetails.Rows[0]["Profile_City"])) + "'" +
                           " P_State='" + Convert.ToString(dtProfileDetails.Rows[0]["Profile_State"]) + "'" +
                           " P_Zipcode='" + Convert.ToString(dtProfileDetails.Rows[0]["Profile_Zipcode"]) + "'" +
                           " P_Country='" + Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]) + "'" +
                             " P_Latitude='" + Convert.ToString(dtProfileDetails.Rows[0]["latitude1"]) + "'" +
                             " P_Longitude='" + Convert.ToString(dtProfileDetails.Rows[0]["longitude1"]) + "'" +
                             " P_IsParent='" + isParent + "'" +
                             " P_AlternatePhone='" + phoneNumber + "'" +
                             " " + HomeTabSettings(Convert.ToInt32(dtProfileDetails.Rows[0]["Profile_ID"])) + " ";


                var profileTabsName = GetProfileTabsNames(Convert.ToInt32(dtProfileDetails.Rows[0]["Profile_ID"]), pIconSize, toolsSettings1,
                    showBulletins, Convert.ToString(dtProfileDetails.Rows[0]["User_email"]), Convert.ToString(dtProfileDetails.Rows[0]["Mobile_Number"]),
                    address, Convert.ToString(dtProfileDetails.Rows[0]["Profile_City"]), Convert.ToString(dtProfileDetails.Rows[0]["Profile_State"]),
                    Convert.ToString(dtProfileDetails.Rows[0]["Profile_Zipcode"]), pBrandedAppName, pNewTabs, pIsNewIcons);
                xmlSelectedTools = "<SubTools><Tools " + toolsSettings1 + profileSettings + " />" + profileTabsName + "</SubTools>";

                return xmlSelectedTools;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetSelectedTools()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting Active & Published Updates by Profile ID
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return updates details as XML string</returns>
        public string GetAllUpdates(string pProfileID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetAllUpdates()", string.Empty, string.Empty, string.Empty, string.Empty);

                string outerURL = GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");
                string xmlUpdates = string.Empty;
                DataTable dtUpdates = BusinessUpdatesDAL.GetActiveBusinessUpdates(Convert.ToInt32(pProfileID));

                #region Vertical Logo

                BusinessBLL objBusinessBLL = new BusinessBLL();
                var dtProfileDetails = objBusinessBLL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
                string verticalDomain = objCommonBLL.GetDomainNameByCountry(Convert.ToInt32(dtProfileDetails.Rows[0]["User_ID"]));
                string VerticalLogo = outerURL + "/images/VerticalLogos/" + verticalDomain + "logo.png";

                #endregion


                for (int i = 0; i < dtUpdates.Rows.Count; i++)
                {
                    string descrition = Convert.ToString(dtUpdates.Rows[i]["List_Description"]);
                    //REMOVE ALL HTML TAGS 
                    if (descrition.Trim() == string.Empty)
                    {
                        descrition = Convert.ToString(dtUpdates.Rows[i]["UpdatedText"]);
                    }
                    bool IsDescription = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("IsUpdateDescription"));
                    if (IsDescription)
                    {
                        //getting first paragraph
                        #region Paragraph lines

                        descrition = descrition.Replace("<BR>", "<br>");
                        var paras = descrition.Split(new string[] { "<br>" }, StringSplitOptions.None);
                        string firstPara = "";
                        if (paras.Count() > 0)
                        {
                            for (int k = 0; k < paras.Count(); k++)
                            {
                                firstPara = ReplaceSpecialCharacter(paras[k].ToString());
                                if (firstPara != "")
                                {
                                    firstPara = paras[k].ToString();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            firstPara = descrition;
                        }

                        firstPara = ReplaceSpecialCharacter(firstPara);
                        bool isValid = false;
                        if (firstPara.Length > 160)
                        {
                            for (int j = 140; j < 160; j++)
                            {
                                if (firstPara.Substring(0, j).EndsWith(" "))
                                {
                                    descrition = firstPara.Substring(0, j) + "...";
                                    isValid = true;
                                    break;
                                }
                            }

                            if (isValid == false)
                            {
                                descrition = firstPara.Substring(0, 140) + " ...";
                            }
                        }
                        else
                        {
                            descrition = firstPara;
                        }

                        #endregion
                        //descrition = ReplaceSpecialCharacter(descrition);
                    }
                    else
                    {
                        descrition = ReplaceSpecialCharacter(descrition);
                    }


                    string updateUrl = outerURL + "/OnlineUpdate.aspx?BID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(dtUpdates.Rows[i]["UpdateId"])).Replace("=", "irhmalli").Replace("+", "irhPASS");
                    //updateUrl = longurlToshorturl(updateUrl);
                    if (!string.IsNullOrEmpty(dtUpdates.Rows[i]["Shorten_Url"].ToString()))
                    {
                        updateUrl = dtUpdates.Rows[i]["Shorten_Url"].ToString();
                    }


                    xmlUpdates = xmlUpdates + "<Updates ID='" + Convert.ToString(dtUpdates.Rows[i]["UpdateId"]) + "' " +
                        " Title='" + ReplaceSpecialCharacter(Convert.ToString(dtUpdates.Rows[i]["UpdateTitle"])) + "'" +
                        " Description='" + descrition + "'" +
                        " Date='" + Convert.ToString(dtUpdates.Rows[i]["UpdateTime"]) + "' " +
                        " UpdateURL='" + updateUrl + "' " +
                        " VerticalLogo='" + VerticalLogo + "'  />";
                }
                xmlUpdates = "<BUpdates>" + xmlUpdates + "</BUpdates>";

                return xmlUpdates;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetAllUpdates()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting Update Description by Update ID
        /// </summary>
        /// <param name="pUpdateID">param is pUpdatedID</param>
        /// <returns>return updatedetails as string</returns>
        public string GetUpdateDetaisByID(string pUpdateID, string pTabletName, string pDeviceWidth)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetUpdateDetaisByID()", string.Empty, string.Empty, string.Empty, string.Empty);

                string updateDetails = string.Empty;
                DataTable dtUpdateDetails = BusinessUpdatesDAL.UpdateBusinessUpdateDetails(Convert.ToInt32(pUpdateID));

                string replaceText = @"<script language=""javascript"" type=""text/javascript"" src=""/B1D671CF-E532-4481-99AA-19F420D90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";
                string replaceText1 = @"<script language=javascript type=text/javascript src=""/b1d671cf-e532-4481-99aa-19f420d90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";

                updateDetails = Convert.ToString(dtUpdateDetails.Rows[0]["UpdatedText"]).Replace(replaceText, string.Empty);
                updateDetails = updateDetails.Replace(replaceText1, string.Empty);

                updateDetails = BuildHeader().Replace("#BuildHtmlForForm#", updateDetails);
                updateDetails = updateDetails.Replace("margin-left:20px;", "margin-left:0px;");
                updateDetails = updateDetails.Replace("margin-left: 20px;", "margin-left: 0px;");

                #region Device Width wise preview html data setting.

                if (Convert.ToString(pTabletName) != string.Empty)
                {
                    updateDetails = ReplaceWidthTabletDevices(updateDetails, pTabletName, pDeviceWidth);
                }

                #endregion

                return updateDetails;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetUpdateDetaisByID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }


        /// <summary>
        /// Getting All Photos by Profile ID
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return photo as XML string</returns>
        public string GetAllPhotosByProfileID(string pProfileID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetAllPhotosByProfileID()", string.Empty, string.Empty, string.Empty, string.Empty);

                string xmlPhotos = string.Empty;
                DataTable dtPhotos = BusinessDAL.GetProfilePhotosByProfileID(Convert.ToInt32(pProfileID));
                string outerURL = GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");
                for (int i = 0; i < dtPhotos.Rows.Count; i++)
                {
                    xmlPhotos = xmlPhotos + "<Photo ID='" + Convert.ToString(dtPhotos.Rows[i]["Profile_Photo_ID"]) + "'" +
                       " PNo='" + Convert.ToString(dtPhotos.Rows[i]["Photo_Num"]) + "'" +
                       " POrder='" + Convert.ToString(dtPhotos.Rows[i]["Image_OrderNo"]) + "'" +
                       " Path='" + outerURL + "/Upload/Photos/" + Convert.ToString(pProfileID) + "/" + Convert.ToString(dtPhotos.Rows[i]["Photo_image_path"]) + "'" +
                       " Caption='" + ReplaceSpecialCharacter(Convert.ToString(dtPhotos.Rows[i]["Photo_Desc"])) + "'   />";
                }

                xmlPhotos = "<Album>" + xmlPhotos + "</Album>";
                return xmlPhotos;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetAllPhotosByProfileID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting All Active & Published Events by Profile ID and Month
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <param name="pDateTime">param is pDateTime</param>
        /// <returns>return events as XML string</returns>
        public string GetAllEvents(string pProfileID, string pDateTime, string pType)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetAllEvents()", string.Empty, string.Empty, string.Empty, string.Empty);

                string xmlEvents = string.Empty;
                DataTable dtEvents = EventCalendarDAL.usp_GetAllEventsByMonth_PID(Convert.ToInt32(pProfileID), pDateTime, pType);

                string outerURL = GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");

                #region Vertical Logo

                BusinessBLL objBusinessBLL = new BusinessBLL();
                var dtProfileDetails = objBusinessBLL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
                string verticalDomain = objCommonBLL.GetDomainNameByCountry(Convert.ToInt32(dtProfileDetails.Rows[0]["User_ID"]));
                string VerticalLogo = outerURL + "/images/VerticalLogos/" + verticalDomain + "logo.png";

                #endregion

                for (int i = 0; i < dtEvents.Rows.Count; i++)
                {
                    string descrition = Convert.ToString(dtEvents.Rows[i]["List_Description"]);
                    if (descrition.Trim() == string.Empty)
                    {
                        descrition = Convert.ToString(dtEvents.Rows[i]["EventDesc"]);
                    }

                    bool IsDescription = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("IsUpdateDescription"));
                    if (IsDescription)
                    {
                        //REMOVE ALL HTML TAGS 
                        //descrition = ReplaceSpecialCharacter(descrition);
                        #region Paragraph lines

                        descrition = descrition.Replace("<BR>", "<br>");
                        var paras = descrition.Split(new string[] { "<br>" }, StringSplitOptions.None);
                        string firstPara = "";
                        if (paras.Count() > 0)
                        {
                            for (int k = 0; k < paras.Count(); k++)
                            {
                                firstPara = ReplaceSpecialCharacter(paras[k].ToString());
                                if (firstPara != "")
                                {
                                    firstPara = paras[k].ToString();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            firstPara = descrition;
                        }

                        firstPara = ReplaceSpecialCharacter(firstPara);
                        bool isValid = false;
                        if (firstPara.Length > 160)
                        {
                            for (int j = 140; j < 160; j++)
                            {
                                if (firstPara.Substring(0, j).EndsWith(" "))
                                {
                                    descrition = firstPara.Substring(0, j) + "...";
                                    isValid = true;
                                    break;
                                }
                            }

                            if (isValid == false)
                            {
                                descrition = firstPara.Substring(0, 140) + " ...";
                            }
                        }
                        else
                        {
                            descrition = firstPara;
                        }

                        #endregion
                    }
                    else
                    {
                        descrition = ReplaceSpecialCharacter(descrition);
                    }

                    string eventUrl = outerURL + "/OnlineEvent.aspx?TID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(dtEvents.Rows[i]["EventId"])).Replace("=", "irhmalli").Replace("+", "irhPASS");
                    //eventUrl = longurlToshorturl(eventUrl);
                    if (!string.IsNullOrEmpty(dtEvents.Rows[i]["Shorten_Url"].ToString()))
                    {
                        eventUrl = dtEvents.Rows[i]["Shorten_Url"].ToString();
                    }

                    xmlEvents = xmlEvents + "<Event ID='" + Convert.ToString(dtEvents.Rows[i]["EventId"]) + "' " +
                        " Title='" + ReplaceSpecialCharacter(Convert.ToString(dtEvents.Rows[i]["EventTitle"])) + "'" +
                        " Description='" + descrition + "'" +
                        " SDate='" + Convert.ToString(dtEvents.Rows[i]["EventStartDate"]) + "'" +
                        " EDate='" + Convert.ToString(dtEvents.Rows[i]["EventEndDate"]) + "'" +
                        " EventURL='" + eventUrl + "' " +
                        " VerticalLogo='" + VerticalLogo + "' />";
                }

                xmlEvents = "<BEvents>" + xmlEvents + "</BEvents>";

                return xmlEvents;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetAllEvents()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting Event Description by Event ID
        /// </summary>
        /// <param name="pEventID">param is pEventID</param>
        /// <returns>return event details as string</returns>
        public string GetEventDetailsByID(string pEventID, string pTabletName, string pDeviceWidth)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetEventDetailsByID()", string.Empty, string.Empty, string.Empty, string.Empty);

                string xmlEventDetails = string.Empty;
                DataTable dtEventDetails = EventCalendarDAL.GetCalendarEventDetails(Convert.ToInt32(pEventID));

                string replaceText = @"<script language=""javascript"" type=""text/javascript"" src=""/B1D671CF-E532-4481-99AA-19F420D90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";
                string replaceText1 = @"<script language=javascript type=text/javascript src=""/b1d671cf-e532-4481-99aa-19f420d90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";

                if (dtEventDetails.Rows.Count > 0)
                {
                    xmlEventDetails = Convert.ToString(dtEventDetails.Rows[0]["EventDesc"]).Replace(replaceText, string.Empty);
                    xmlEventDetails = xmlEventDetails.Replace(replaceText1, string.Empty);

                    xmlEventDetails = BuildHeader().Replace("#BuildHtmlForForm#", xmlEventDetails);
                    xmlEventDetails = xmlEventDetails.Replace("margin-left:20px;", "margin-left:0px;");
                    xmlEventDetails = xmlEventDetails.Replace("margin-left: 20px;", "margin-left: 0px;");
                }

                #region Device Width wise preview html data setting.

                if (Convert.ToString(pTabletName) != string.Empty)
                {
                    xmlEventDetails = ReplaceWidthTabletDevices(xmlEventDetails, pTabletName, pDeviceWidth);
                }

                #endregion

                return xmlEventDetails;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetEventDetailsByID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
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
        public string SendEmail(string pToEmailID, string pSubject, string pBody, string pUserName, string mobileNumber,
            string contactEmailID, string pProfileID, string pUserID, string pSourceType, string pPhotoName, double pLatitude,
            double pLongitude, string pAddress, bool pIsAnonymous, string pDeviceID, string pDeviceType, int pAppID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "SendEmail()", string.Empty, string.Empty, string.Empty, string.Empty);

                #region Get Current Address by Lati & Long

                string CurrentAddress = "";
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

                #endregion

                // Log
                ErrorHandling("LOG ", "MServiceBLL.cs", "SendEmail()", "CurrentAddress---" + CurrentAddress, string.Empty, string.Empty, string.Empty);


                //Sending email to Business User
                string message = string.Empty;
                string verticalCode = MServiceDAL.GetVerticalNameByProfileID(Convert.ToInt32(pProfileID));

                #region Email Body Reading

                DataTable dtProfileDetails = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
                string countryName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);

                CommonBLL objCommon = new CommonBLL();
                string domain = objCommon.GetDomainNameByCountryVertical(verticalCode, countryName.Trim()); //objCommon.GetVerticalDomain(verticalCode,);
                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + domain + "\\";

                StreamReader re = File.OpenText(strfilepath + "ContactUs.txt");
                string emailmessage = string.Empty;
                string content = string.Empty;

                while ((content = re.ReadLine()) != null)
                {
                    emailmessage = emailmessage + content + "<BR>";
                }

                emailmessage = emailmessage.Replace("#TimeSent#", DateTime.Now.ToString());
                emailmessage = emailmessage.Replace("#UserName#", pUserName);
                emailmessage = emailmessage.Replace("#PhoneNumber#", mobileNumber);
                emailmessage = emailmessage.Replace("#EmailID#", contactEmailID);
                emailmessage = emailmessage.Replace("#Body#", pBody);
                emailmessage = emailmessage.Replace("#Location#", CurrentAddress);
                re.Close();

                #endregion

                string Mobilemessage = string.Empty;
                Mobilemessage = pUserName + "|" + mobileNumber + "|" + contactEmailID + "|" + pBody;


                int _result = USPDHUBDAL.MServiceDAL.ManageMessage(Convert.ToInt32(pProfileID), 2, Convert.ToInt32(pUserID), pSubject, Mobilemessage, 0, true, 0,
                      Convert.ToInt32(pUserID), 1, pSourceType, pPhotoName, pLatitude, pLongitude, pAddress, pIsAnonymous,
                      pDeviceID, pDeviceType, pAppID);
                if (_result < 0)
                {
                    message = "One or more of the messages sent have been blocked and not delivered. To find out why blocking occurs please call our office.";

                    #region Custom Messages from Database by Profile ID & Message Type

                    DataTable dtCustomMessages = MServiceDAL.GetCustomMessagesByPID(Convert.ToInt32(pProfileID), "Blocked");
                    if (dtCustomMessages.Rows.Count > 0)
                    {
                        if (Convert.ToString(dtCustomMessages.Rows[0]["Custom_Message"]) != string.Empty)
                        {
                            message = Convert.ToString(dtCustomMessages.Rows[0]["Custom_Message"]);
                        }
                    }

                    #endregion

                    return message;
                }

                string attachmentFilePath = "";
                if (pPhotoName != "")
                {
                    //attachmentFilePath = HttpContext.Current.Server.MapPath("~/Upload/DevicePhotos/" + pProfileID + "/" + pPhotoName);
                    attachmentFilePath = ConfigurationManager.AppSettings.Get("AppContactUsPhotosFolderName") + "/Upload/DevicePhotos/" + pProfileID + "/" + pPhotoName;
                }

                string FromEmailsupport = GetConfigSettings(Convert.ToString(pProfileID), "EmailAccounts", "EmailInfo");
                // Log
                ErrorHandling("LOG ", "MServiceBLL.cs", "SendEmail()", "attachmentFilePath---" + attachmentFilePath, string.Empty, string.Empty, string.Empty);


                message = SendContactUsEmail(FromEmailsupport, pToEmailID, pSubject, emailmessage, string.Empty, "", attachmentFilePath,
                    Convert.ToString(pProfileID));

                re.Dispose();

                return message;

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "SendEmail()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Send Contact Us Email
        /// </summary>
        /// <param name="FromEmail">FromEmail</param>
        /// <param name="ToEmail">ToEmail</param>
        /// <param name="subject">subject</param>
        /// <param name="message">message</param>
        /// <param name="CCemail">CCemail</param>
        /// <param name="FromDisplayName">FromDisplayName</param>
        /// <param name="attachmentFilePath">attachmentFilePath</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>String</returns>
        private string SendContactUsEmail(string FromEmail, string ToEmail, string subject, string message, string CCemail,
         string FromDisplayName, string attachmentFilePath, string pProfileID)
        {
            string returnValue = "";
            try
            {
                System.Net.Mail.SmtpClient oSMTLClient = new System.Net.Mail.SmtpClient();
                oSMTLClient.Host = GetConfigSettings(Convert.ToString(pProfileID), "SMTPServer", "SmtpServerName");

                // oSMTLClient.Host = ConfigurationManager.AppSettings.Get("SmtpServerName");
                // oSMTLClient.Credentials = new System.Net.NetworkCredential(FromEmail, EncryptDecrypt.DESDecrypt(ConfigurationManager.AppSettings.Get("SmtpServer")));

                // Log
                ErrorHandling("LOG ", "MServiceBLL.cs", "SendContactUsEmail() 1", "oSMTLClient.Host---" + oSMTLClient.Host, string.Empty, string.Empty, string.Empty);

                /*** For Sendgrid SMTP Server Port  July 21 2016 Azure Deployement ***/
                string sendgridSMTPServer_Username = Convert.ToString(ConfigurationManager.AppSettings.Get("SendgridSMTPServer_Username"));
                oSMTLClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("SendgridSMTPServer_Port"));

                oSMTLClient.Credentials = new System.Net.NetworkCredential(sendgridSMTPServer_Username, EncryptDecrypt.DESDecrypt(GetConfigSettings(Convert.ToString(pProfileID), "SMTPServer", "SmtpServerCr")));
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.From = new System.Net.Mail.MailAddress(FromEmail, FromDisplayName);
                mailMessage.To.Add(ToEmail);
                if (CCemail != "") mailMessage.CC.Add(CCemail);
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = System.Net.Mail.MailPriority.Normal;
                mailMessage.Subject = subject;

                // Log
                ErrorHandling("LOG ", "MServiceBLL.cs", "SendContactUsEmail() 2", "Before Attachemnt ---" + attachmentFilePath, string.Empty, string.Empty, string.Empty);
                if (attachmentFilePath != "")
                {
                    System.Net.Mail.Attachment objAttachment = new System.Net.Mail.Attachment(attachmentFilePath, MediaTypeNames.Application.Octet);

                    // This is the problem code, to workaround the issue make sure you are not using Base64 as encoding
                    // attachment.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;



                    // Any of those two code section will work
                    objAttachment.TransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;

                    //objAttachment.TransferEncoding = System.Net.Mime.TransferEncoding.SevenBit;


                    // Log
                    ErrorHandling("LOG ", "MServiceBLL.cs", "SendContactUsEmail() 3 ", "After Attachment 1---" + string.Empty, string.Empty, string.Empty, string.Empty);
                    mailMessage.Attachments.Add(objAttachment);
                    ErrorHandling("LOG ", "MServiceBLL.cs", "SendContactUsEmail() 4", "After Attachment 2---" + string.Empty, string.Empty, string.Empty, string.Empty);
                }

                // Log
                ErrorHandling("LOG ", "MServiceBLL.cs", "SendContactUsEmail() 5", "Beofore Mail Sending ---" + oSMTLClient.Host, string.Empty, string.Empty, string.Empty);
                oSMTLClient.Send(mailMessage);
                // Log
                ErrorHandling("LOG ", "MServiceBLL.cs", "SendContactUsEmail() 6", "After mail sending---" + oSMTLClient.Host, string.Empty, string.Empty, string.Empty);

                returnValue = "SUCCESS";

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "SendContactUsEmail()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                returnValue = ErrorMessage;
            }
            return returnValue;
        }

        /// <summary>
        /// Getting Business details by Mapview direction (Latitude,longitude and Radius values)
        /// </summary>
        /// <param name="platitude1">param is platitude1</param>
        /// <param name="plongitude1">param is plongitude1</param>
        /// <param name="pRadius">param is pRadius</param>
        /// <returns>return business details as XML string</returns>
        public string MapViewDirection(string platitude1, string plongitude1, string pRadius)
        {
            string result = string.Empty;

            DataTable dtSearchResult = USPDHUBDAL.MServiceDAL.MapviewDirection(platitude1, plongitude1, pRadius);


            for (int i = 0; i < dtSearchResult.Rows.Count; i++)
            {

                string address = string.Empty;
                if (Convert.ToString(dtSearchResult.Rows[i]["Profile_StreetAddress2"]) == string.Empty)
                {
                    address = Convert.ToString(dtSearchResult.Rows[i]["Profile_StreetAddress1"]);
                }
                else
                {

                    address = Convert.ToString(dtSearchResult.Rows[i]["Profile_StreetAddress1"]) + ", " + Convert.ToString(dtSearchResult.Rows[i]["Profile_StreetAddress2"]);
                }

                string logoName = Convert.ToString(dtSearchResult.Rows[i]["Profile_logo_path"]);
                string extension = System.IO.Path.GetExtension(logoName);
                if (logoName == string.Empty)
                {
                    extension = ".jpg";
                }

                bool isParent = true;
                if (Convert.ToString(dtSearchResult.Rows[i]["Parent_ProfileID"]) == string.Empty)
                {
                    isParent = true;
                }
                else
                {
                    isParent = false;
                }

                string outerURL = GetConfigSettings(Convert.ToString(dtSearchResult.Rows[i]["Profile_ID"]), "Paths", "RootPath");
                string logoFullPath = outerURL + "/Upload/Logos/" +
                    Convert.ToString(dtSearchResult.Rows[i]["Profile_ID"]) + "/" + Convert.ToString(dtSearchResult.Rows[i]["Profile_ID"]) + "_thumb" + extension;

                result = result + "<Prof PID='" + Convert.ToString(dtSearchResult.Rows[i]["Profile_ID"]) + "'" +
                    " UID='" + Convert.ToString(dtSearchResult.Rows[i]["User_ID"]) + "'" +
                    " PName='" + ReplaceSpecialCharacter(Convert.ToString(dtSearchResult.Rows[i]["Profile_name"])) + "'" +
                    " BName='" + ReplaceSpecialCharacter(Convert.ToString(dtSearchResult.Rows[i]["Profile_displayname"])) + "'" +
                    " PLogo='" + logoFullPath + "'" +
                    " MobileNumber='" + Convert.ToString(dtSearchResult.Rows[i]["Mobile_Number"]) + "'" +

                    " EmailID='" + Convert.ToString(dtSearchResult.Rows[i]["Username"]) + "'" +
                    " Address='" + ReplaceSpecialCharacter(address) + "'" +
                    " Latitude='" + Convert.ToString(dtSearchResult.Rows[i]["latitude1"]) + "'" +
                    " Longitude='" + Convert.ToString(dtSearchResult.Rows[i]["longitude1"]) + "'" +
                    " P_IsParent='" + isParent + "'" +
                    " City='" + ReplaceSpecialCharacter(Convert.ToString(dtSearchResult.Rows[i]["Profile_City"])) + "'" +
                    " State='" + Convert.ToString(dtSearchResult.Rows[i]["Profile_State"]) + "'" +
                    " Zipcode='" + Convert.ToString(dtSearchResult.Rows[i]["Profile_Zipcode"]) + "'" +
                    " Country='" + Convert.ToString(dtSearchResult.Rows[i]["Profile_County"]) + "'" + "/>";

            }
            result = "<BPDetails>" + result + "</BPDetails>";
            return result;
        }

        /// <summary>
        /// Getting Social media links by Profile ID
        /// </summary>
        /// <param name="pProfileID">param is pProfilID</param>
        /// <returns>return social media links as XML string</returns>
        public string GetSocilMedialinks(string pProfileID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetSocilMedialinks()", string.Empty, string.Empty, string.Empty, string.Empty);

                string xmlSocialMedia = string.Empty;

                DataTable dtpdesc = BusinessDAL.Getprofiledescription(Convert.ToInt32(pProfileID));
                if (dtpdesc.Rows.Count > 0)
                {
                    xmlSocialMedia = xmlSocialMedia + "<Links FBProfileURL='" + Convert.ToString(dtpdesc.Rows[0]["Facebook_Link"]) + "'" +
                      " FBFanPageURL='" + Convert.ToString(dtpdesc.Rows[0]["Facebook_Link"]) + "'" +
                      " LinkedinURL='" + Convert.ToString(dtpdesc.Rows[0]["LinkedIn_Link"]) + "'" +
                      " TwitterURL='" + Convert.ToString(dtpdesc.Rows[0]["Twitter_Link"]) + "' />";
                }
                else
                {
                    xmlSocialMedia = "<Links FBProfileURL='' FBFanPageURL='' LinkedinURL='' TwitterURL=''  />";
                }

                xmlSocialMedia = "<SMedia>" + xmlSocialMedia + "</SMedia>";
                return xmlSocialMedia;

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetSocilMedialinks()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }

        }

        #region *******************   Inside methods private method   *************************

        /// <summary>
        /// Replace special characters.
        /// </summary>
        /// <param name="inputString">param is inputString</param>
        /// <returns>String</returns>
        public string ReplaceSpecialCharacter(string inputString)
        {
            inputString = inputString.Replace("<A href=\"http://tr\" target=_blank></A>&nbsp;", "");
            inputString = System.Text.RegularExpressions.Regex.Replace(inputString, "<[^>]*>", string.Empty);

            //inputString = inputString.Replace("'", " ");
            inputString = inputString.Replace("&nbsp;", " ");

            if (!inputString.Contains("&amp;"))
            {
                inputString = inputString.Replace("&", "&amp;");
                inputString = inputString.Replace("&amp;amp;", "&amp;");
                inputString = inputString.Replace("&amp;yen;", "&yen;");
            }
            inputString = inputString.Replace("'", "&apos;");
            inputString = inputString.Replace("&amp;apos;", "&apos;");

            if (inputString.StartsWith("&yen;"))
            {
                inputString = inputString.Substring(5, inputString.Length - 5);
            }
            return inputString.Trim();
        }

        /// <summary>
        /// Getting Profile Tab Names(Profile Tab Buttons in Business Home Page on Mobile App)
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <param name="pIconSize">param is pIconSize</param>
        /// <param name="pToolsSettings">param is pToolsSettings</param>
        /// <param name="ShowBulletins">param is ShowBulletins</param>
        /// <returns>return profile tab names</returns>

        // 24/04/2014 before
        public string GetProfileTabsNames_Old(int pProfileID, string pIconSize, string pToolsSettings, bool ShowBulletins,
            string pEmailID, string pPhoneNumber, string pStreetAddress, string pCity, string pState, string pZipcode, int pBrandedAppName,
            string pNewTabs, bool pIsNewIcons)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetProfileTabsNames(private method)", string.Empty, string.Empty, string.Empty, string.Empty);

                //Tab name Variables
                string callTab = "", contactUsTab = "", directionTab = "Directions", submitTipTab = "", notificationTab = "", homeTab = "", aboutTab = "",
                    updatesTab = "", mediasTab = "", eventsTab = "", surveyTab = "", bulletinTab = "", webLinksTab = "", socialTab = "";

                // Tab Icons Names
                string callTabIcon = "call";
                string contactUsTabIcon = "contact";
                string directionTabIcon = "directions";
                string submitTipTabIcon = "SubmitTip";
                string notificationTabIcon = "Notification";
                string homeTabIcon = "Home";
                string aboutTabIcon = "AboutUs";
                string updatesTabIcon = "Updates";
                string mediasTabIcon = "Media";
                string eventsTabIcon = "Events";
                string surveyTabIcon = "Survey";
                string bulletinsTabIcon = "Bulletins";
                string webLinkTabIcon = "WebLinks";
                string socialTabIcon = "Social";


                #region Default Tabs Names by Domain

                string verticalCodeFolderName = "";
                verticalCodeFolderName = MServiceDAL.GetVerticalNameByProfileID(pProfileID);
                DataTable dtProfileDetails = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
                string countryName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);
                string domain = objCommonBLL.GetDomainNameByCountryVertical(verticalCodeFolderName, countryName.Trim());

                DataTable DtDefaultTabsName = BusinessDAL.GetDefaultProfileTabNames(domain);
                if (DtDefaultTabsName.Rows.Count > 0)
                {
                    DataRow[] drCall = DtDefaultTabsName.Select("Tab_Parent='Call'");
                    if (drCall.Length > 0)
                    {
                        callTab = drCall[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drContact = DtDefaultTabsName.Select("Tab_Parent='ContactUs'");
                    if (drContact.Length > 0)
                    {
                        contactUsTab = drContact[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drTip = DtDefaultTabsName.Select("Tab_Parent='Tips'");
                    if (drTip.Length > 0)
                    {
                        submitTipTab = drTip[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drNotification = DtDefaultTabsName.Select("Tab_Parent='Notifications'");
                    if (drNotification.Length > 0)
                    {
                        notificationTab = drNotification[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drHome = DtDefaultTabsName.Select("Tab_Parent='Home'");
                    if (drHome.Length > 0)
                    {
                        homeTab = drHome[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drAboutUs = DtDefaultTabsName.Select("Tab_Parent='AboutUs'");
                    if (drAboutUs.Length > 0)
                    {
                        aboutTab = drAboutUs[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drUpdates = DtDefaultTabsName.Select("Tab_Parent='Updates'");
                    if (drUpdates.Length > 0)
                    {
                        updatesTab = drUpdates[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drMedia = DtDefaultTabsName.Select("Tab_Parent='Gallery'");
                    if (drMedia.Length > 0)
                    {
                        mediasTab = drMedia[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drEvents = DtDefaultTabsName.Select("Tab_Parent='Events'");
                    if (drEvents.Length > 0)
                    {
                        eventsTab = drEvents[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drSurveys = DtDefaultTabsName.Select("Tab_Parent='Surveys'");
                    if (drSurveys.Length > 0)
                    {
                        surveyTab = drSurveys[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drBulletins = DtDefaultTabsName.Select("Tab_Parent='Bulletins'");
                    if (drBulletins.Length > 0)
                    {
                        bulletinTab = drBulletins[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drWebLinks = DtDefaultTabsName.Select("Tab_Parent='WebLinks'");
                    if (drWebLinks.Length > 0)
                    {
                        webLinksTab = drWebLinks[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drSocialMedia = DtDefaultTabsName.Select("Tab_Parent='SocialMedia'");
                    if (drSocialMedia.Length > 0)
                    {
                        socialTab = drSocialMedia[0]["Tab_Name"].ToString();
                    }
                }


                #endregion


                string RootURL = "";
                string ServerIconPath = "";

                string outerURL = GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");
                //Note: only for this uspdhub news Icons
                if (pIsNewIcons)
                {
                    verticalCodeFolderName = verticalCodeFolderName + "_new";
                }
                //

                RootURL = outerURL + "/Upload/ProfileTabIcons/" + verticalCodeFolderName + "/" + pIconSize;
                ServerIconPath = HttpContext.Current.Server.MapPath("\\Upload\\ProfileTabIcons\\" + verticalCodeFolderName + "\\" + pIconSize);

                //ComingSoon Icon Path
                string defaultIconPath = outerURL + "/Upload/ComingSoonIcons/" + pIconSize + ".png";

                #region Tabs (Tools) Icons Path

                //Call Button
                if (File.Exists(ServerIconPath + "\\" + callTabIcon + "_n_" + pIconSize + ".png"))
                {
                    callTabIcon = RootURL + "/" + callTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    callTabIcon = defaultIconPath;
                }

                //Contact Us Button
                if (File.Exists(ServerIconPath + "\\" + contactUsTabIcon + "_n_" + pIconSize + ".png"))
                {
                    contactUsTabIcon = RootURL + "/" + contactUsTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    contactUsTabIcon = defaultIconPath;
                }
                //Direction Button
                if (File.Exists(ServerIconPath + "\\" + directionTabIcon + "_n_" + pIconSize + ".png"))
                {
                    directionTabIcon = RootURL + "/" + directionTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    directionTabIcon = defaultIconPath;
                }


                //Main Tools
                //Home Tab
                if (File.Exists(ServerIconPath + "\\" + homeTabIcon + "_n_" + pIconSize + ".png"))
                {
                    homeTabIcon = RootURL + "/" + homeTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    homeTabIcon = defaultIconPath;
                }
                //Notifications
                if (File.Exists(ServerIconPath + "\\" + notificationTabIcon + "_n_" + pIconSize + ".png"))
                {
                    notificationTabIcon = RootURL + "/" + notificationTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    notificationTabIcon = defaultIconPath;
                }
                //Submit Tip
                if (File.Exists(ServerIconPath + "\\" + submitTipTabIcon + "_n_" + pIconSize + ".png"))
                {
                    submitTipTabIcon = RootURL + "/" + submitTipTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    submitTipTabIcon = defaultIconPath;
                }
                //About Us
                if (File.Exists(ServerIconPath + "\\" + aboutTabIcon + "_n_" + pIconSize + ".png"))
                {
                    aboutTabIcon = RootURL + "/" + aboutTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    aboutTabIcon = defaultIconPath;
                }
                //Media 
                if (File.Exists(ServerIconPath + "\\" + mediasTabIcon + "_n_" + pIconSize + ".png"))
                {
                    mediasTabIcon = RootURL + "/" + mediasTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    mediasTabIcon = defaultIconPath;
                }
                //Updates
                if (File.Exists(ServerIconPath + "\\" + updatesTabIcon + "_n_" + pIconSize + ".png"))
                {
                    updatesTabIcon = RootURL + "/" + updatesTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    updatesTabIcon = defaultIconPath;
                }
                //Events
                if (File.Exists(ServerIconPath + "\\" + eventsTabIcon + "_n_" + pIconSize + ".png"))
                {
                    eventsTabIcon = RootURL + "/" + eventsTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    eventsTabIcon = defaultIconPath;
                }
                //Bulletins
                if (File.Exists(ServerIconPath + "\\" + bulletinsTabIcon + "_n_" + pIconSize + ".png"))
                {
                    bulletinsTabIcon = RootURL + "/" + bulletinsTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    bulletinsTabIcon = defaultIconPath;
                }
                //Weblink Tabs
                if (File.Exists(ServerIconPath + "\\" + webLinkTabIcon + "_n_" + pIconSize + ".png"))
                {
                    webLinkTabIcon = RootURL + "/" + webLinkTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    webLinkTabIcon = defaultIconPath;
                }
                //Social Media
                if (File.Exists(ServerIconPath + "\\" + socialTabIcon + "_n_" + pIconSize + ".png"))
                {
                    socialTabIcon = RootURL + "/" + socialTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    socialTabIcon = defaultIconPath;
                }
                //Survey 
                if (File.Exists(ServerIconPath + "\\" + surveyTabIcon + "_n_" + pIconSize + ".png"))
                {
                    surveyTabIcon = RootURL + "/" + surveyTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    surveyTabIcon = defaultIconPath;
                }

                #endregion


                string toolsSettings = "<SubTools><Tools " + pToolsSettings + "/></SubTools>";
                string childTabName = string.Empty;
                var XMLTools = XElement.Parse(toolsSettings, LoadOptions.PreserveWhitespace);

                #region User Tab Names

                //Home Tabs
                if (XMLTools.Element("Tools").Attribute("HomeTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("HomeTabName").Value).Trim() != string.Empty)
                    {
                        homeTab = Convert.ToString(XMLTools.Element("Tools").Attribute("HomeTabName").Value).Trim();
                    }
                }

                /*
              //Contact US
              if (XMLTools.Element("Tools").Attribute("ContactUsTabName") != null)
              {
                  if (Convert.ToString(XMLTools.Element("Tools").Attribute("ContactUsTabName").Value).Trim() != string.Empty)
                  {
                      contactUsTab = Convert.ToString(XMLTools.Element("Tools").Attribute("ContactUsTabName").Value).Trim();
                  }
              } 
                 * */


                //Submit Tip
                if (XMLTools.Element("Tools").Attribute("SubmitTipName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("SubmitTipName").Value).Trim() != string.Empty)
                    {
                        submitTipTab = Convert.ToString(XMLTools.Element("Tools").Attribute("SubmitTipName").Value).Trim();
                    }
                }


                //Notifications
                if (XMLTools.Element("Tools").Attribute("NotificationTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("NotificationTabName").Value).Trim() != string.Empty)
                    {
                        notificationTab = Convert.ToString(XMLTools.Element("Tools").Attribute("NotificationTabName").Value).Trim();
                    }
                }
                //About Us
                if (XMLTools.Element("Tools").Attribute("AboutUsTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("AboutUsTabName").Value).Trim() != string.Empty)
                    {
                        aboutTab = Convert.ToString(XMLTools.Element("Tools").Attribute("AboutUsTabName").Value).Trim();
                    }
                }
                //Updates
                if (XMLTools.Element("Tools").Attribute("UpdatesTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("UpdatesTabName").Value).Trim() != string.Empty)
                    {
                        updatesTab = Convert.ToString(XMLTools.Element("Tools").Attribute("UpdatesTabName").Value).Trim();
                    }
                }
                //Media OR Gallery
                if (XMLTools.Element("Tools").Attribute("MediaTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("MediaTabName").Value).Trim() != string.Empty)
                    {
                        mediasTab = Convert.ToString(XMLTools.Element("Tools").Attribute("MediaTabName").Value).Trim();
                    }
                }
                //Events
                if (XMLTools.Element("Tools").Attribute("EventsTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("EventsTabName").Value).Trim() != string.Empty)
                    {
                        eventsTab = Convert.ToString(XMLTools.Element("Tools").Attribute("EventsTabName").Value).Trim();
                    }
                }
                //Bulletins
                if (XMLTools.Element("Tools").Attribute("BulletinsTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("BulletinsTabName").Value).Trim() != string.Empty)
                    {
                        bulletinTab = Convert.ToString(XMLTools.Element("Tools").Attribute("BulletinsTabName").Value).Trim();
                    }
                }
                //Weblinks
                if (XMLTools.Element("Tools").Attribute("WeblinksTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("WeblinksTabName").Value).Trim() != string.Empty)
                    {
                        webLinksTab = Convert.ToString(XMLTools.Element("Tools").Attribute("WeblinksTabName").Value).Trim();
                    }
                }
                //Social Media
                if (XMLTools.Element("Tools").Attribute("SocialMediaTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("SocialMediaTabName").Value).Trim() != string.Empty)
                    {
                        socialTab = Convert.ToString(XMLTools.Element("Tools").Attribute("SocialMediaTabName").Value).Trim();
                    }
                }
                //Surveys
                if (XMLTools.Element("Tools").Attribute("SurveysTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("SurveysTabName").Value).Trim() != string.Empty)
                    {
                        surveyTab = Convert.ToString(XMLTools.Element("Tools").Attribute("SurveysTabName").Value).Trim();
                    }
                }

                #endregion


                #region Final XML Tabs Names,Icons Path and  Tab ID

                if (verticalCodeFolderName.ToLower().Contains("inschoolhub") || verticalCodeFolderName.ToLower().Contains("twovie")
                    || verticalCodeFolderName.ToLower().Contains("myyouth"))
                {

                    //Call Button
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsPhoneNumber").Value) == true && pPhoneNumber != string.Empty)
                    {  //callTab=
                        childTabName = childTabName + "<Tab ID='CallTab' Name='" + callTab + "' Icon='" + callTabIcon + "'/>";
                    }
                    //Submit a Tip Tab #3 (Tips & Feedback)
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSubmitTip") != null))
                    {
                        if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSubmitTip").Value) == true && pEmailID != string.Empty)
                        {
                            childTabName = childTabName + "<Tab ID='SubmitTipTab' Name='" + submitTipTab + "' Icon='" + submitTipTabIcon + "' />";
                        }
                    }
                    //Notifications Tab #2
                    childTabName = childTabName + "<Tab ID='NotificationTab' Name='" + notificationTab + "' Icon='" + notificationTabIcon + "'/>";
                    //Home Tab #1
                    childTabName = childTabName + "<Tab ID='HomeTab' Name='" + homeTab + "' Icon='" + homeTabIcon + "'/>";
                    //Updates Tab #5
                    DataTable dtUpdates = BusinessUpdatesDAL.GetActiveBusinessUpdates(Convert.ToInt32(pProfileID));
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsUpdates").Value) == true && dtUpdates.Rows.Count > 0)
                    {
                        childTabName = childTabName + "<Tab ID='UpdatesTab' Name='" + updatesTab + "' Icon='" + updatesTabIcon + "'/>";
                    }
                    //Survey Tab#10
                    bool IsSurveys = false;
                    if (XMLTools.Element("Tools").Attribute("IsSurveys") != null)
                    {
                        IsSurveys = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSurveys").Value);
                    }
                    if (pNewTabs.ToLower() == "Survey".ToLower() && IsSurveys == true)
                    {
                        childTabName = childTabName + "<Tab ID='SurveyTab' Name='" + surveyTab + "' Icon='" + surveyTabIcon + "'/>";
                    }

                    // Bulletins Tab #8
                    DataTable dtActiveBulletins = USPDHUBDAL.BulletinDAL.GetActiveBulletinsByProfileID(Convert.ToInt32(pProfileID));
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsBulletins").Value) == true && ShowBulletins == true && dtActiveBulletins.Rows.Count > 0)
                    {
                        childTabName = childTabName + "<Tab ID='BulletinsTab' Name='" + bulletinTab + "' Icon='" + bulletinsTabIcon + "'/>";
                    }
                    //About Us Tab #4
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsAboutUs").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='AboutUsTab' Name='" + aboutTab + "' Icon='" + aboutTabIcon + "'/>";
                    }
                    // Events Tab #7
                    DataTable dtEvents = EventCalendarDAL.GetAllEventsByProfileIdandSelectedMonth(Convert.ToInt32(pProfileID), DateTime.Now.ToShortDateString());
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsEvents").Value) == true && dtEvents.Rows.Count > 0)
                    {
                        childTabName = childTabName + "<Tab ID='EventsTab' Name='" + eventsTab + "' Icon='" + eventsTabIcon + "'/>";
                    }
                    //Contact Us Button
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsContatUs").Value) == true && pEmailID != string.Empty)
                    {
                        childTabName = childTabName + "<Tab ID='ContactTab' Name='" + contactUsTab + "' Icon='" + contactUsTabIcon + "'/>";
                    }
                    //Photo Album #6
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsPhotos").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='MediaTab' Name='" + mediasTab + "' Icon='" + mediasTabIcon + "'/>";
                    }
                    // Social Media Tab #10
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSocial").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='SocialTab' Name='" + socialTab + "' Icon='" + socialTabIcon + "'/>";
                    }

                    //Direction Button
                    if (pStreetAddress != string.Empty && pCity != string.Empty && pState != string.Empty && pZipcode != string.Empty)
                    {
                        childTabName = childTabName + "<Tab ID='DirectionTab' Name='" + directionTab + "' Icon='" + directionTabIcon + "'/>";
                    }
                    // Weblinks Tab #9
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsWebLinks").Value) == true && ShowBulletins == true)
                    {
                        childTabName = childTabName + "<Tab ID='WebLinksTab' Name='" + webLinksTab + "' Icon='" + webLinkTabIcon + "'/>";
                    }
                }
                else
                {
                    //Call Button
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsPhoneNumber").Value) == true && pPhoneNumber != string.Empty)
                    {
                        childTabName = childTabName + "<Tab ID='CallTab' Name='" + callTab + "' Icon='" + callTabIcon + "'/>";
                    }
                    //Contact Us Button
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsContatUs").Value) == true && pEmailID != string.Empty)
                    {
                        childTabName = childTabName + "<Tab ID='ContactTab' Name='" + contactUsTab + "' Icon='" + contactUsTabIcon + "'/>";
                    }
                    //Direction Button
                    if (pStreetAddress != string.Empty && pCity != string.Empty && pState != string.Empty && pZipcode != string.Empty)
                    {
                        childTabName = childTabName + "<Tab ID='DirectionTab' Name='" + directionTab + "' Icon='" + directionTabIcon + "'/>";
                    }
                    //Home Tab #1
                    childTabName = childTabName + "<Tab ID='HomeTab' Name='" + homeTab + "' Icon='" + homeTabIcon + "'/>";
                    //Notifications Tab #2
                    childTabName = childTabName + "<Tab ID='NotificationTab' Name='" + notificationTab + "' Icon='" + notificationTabIcon + "'/>";

                    //Submit a Tip Tab #3 (Tips & Feedback)
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSubmitTip") != null))
                    {
                        if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSubmitTip").Value) == true && pEmailID != string.Empty)
                        {
                            childTabName = childTabName + "<Tab ID='SubmitTipTab' Name='" + submitTipTab + "' Icon='" + submitTipTabIcon + "' />";
                        }
                    }
                    //About Us Tab #4
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsAboutUs").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='AboutUsTab' Name='" + aboutTab + "' Icon='" + aboutTabIcon + "'/>";
                    }
                    //Updates Tab #5
                    DataTable dtUpdates = BusinessUpdatesDAL.GetActiveBusinessUpdates(Convert.ToInt32(pProfileID));
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsUpdates").Value) == true && dtUpdates.Rows.Count > 0)
                    {
                        childTabName = childTabName + "<Tab ID='UpdatesTab' Name='" + updatesTab + "' Icon='" + updatesTabIcon + "'/>";
                    }
                    //Photo Album #6
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsPhotos").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='MediaTab' Name='" + mediasTab + "' Icon='" + mediasTabIcon + "'/>";
                    }
                    // Events Tab #7
                    DataTable dtEvents = EventCalendarDAL.GetAllEventsByProfileIdandSelectedMonth(Convert.ToInt32(pProfileID), DateTime.Now.ToShortDateString());
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsEvents").Value) == true && dtEvents.Rows.Count > 0)
                    {
                        childTabName = childTabName + "<Tab ID='EventsTab' Name='" + eventsTab + "' Icon='" + eventsTabIcon + "'/>";
                    }

                    //Survey Tab#11
                    bool IsSurveys = false;
                    if (XMLTools.Element("Tools").Attribute("IsSurveys") != null)
                    {
                        IsSurveys = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSurveys").Value);
                    }
                    if (pNewTabs.ToLower() == "Survey".ToLower() && IsSurveys == true)
                    {

                        childTabName = childTabName + "<Tab ID='SurveyTab' Name='" + surveyTab + "' Icon='" + surveyTabIcon + "'/>";
                    }

                    // Bulletins Tab #8
                    DataTable dtActiveBulletins = USPDHUBDAL.BulletinDAL.GetActiveBulletinsByProfileID(Convert.ToInt32(pProfileID));
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsBulletins").Value) == true && ShowBulletins == true && dtActiveBulletins.Rows.Count > 0)
                    {
                        childTabName = childTabName + "<Tab ID='BulletinsTab' Name='" + bulletinTab + "' Icon='" + bulletinsTabIcon + "'/>";
                    }
                    // Weblinks Tab #9
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsWebLinks").Value) == true && ShowBulletins == true)
                    {
                        childTabName = childTabName + "<Tab ID='WebLinksTab' Name='" + webLinksTab + "' Icon='" + webLinkTabIcon + "'/>";
                    }
                    // Social Media Tab #10
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSocial").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='SocialTab' Name='" + socialTab + "' Icon='" + socialTabIcon + "'/>";
                    }
                }

                #endregion

                return childTabName;

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetProfileTabsNames(private method)", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }

        }

        // 24/04/2014 from onwards:: for changes:: Show the Buleltins even though Bulletins Count=00
        /// <summary>
        /// Get Profile Tabs Names
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pIconSize">pIconSize</param>
        /// <param name="pToolsSettings">pToolsSettings</param>
        /// <param name="ShowBulletins">ShowBulletins</param>
        /// <param name="pEmailID">pEmailID</param>
        /// <param name="pPhoneNumber">pPhoneNumber</param>
        /// <param name="pStreetAddress">pStreetAddress</param>
        /// <param name="pCity">pCity</param>
        /// <param name="pState">pState</param>
        /// <param name="pZipcode">pZipcode</param>
        /// <param name="pBrandedAppName">pBrandedAppName</param>
        /// <param name="pNewTabs">pNewTabs</param>
        /// <param name="pIsNewIcons">pIsNewIcons</param>
        /// <returns>String</returns>
        public string GetProfileTabsNames(int pProfileID, string pIconSize, string pToolsSettings, bool ShowBulletins,
           string pEmailID, string pPhoneNumber, string pStreetAddress, string pCity, string pState, string pZipcode, int pBrandedAppName,
           string pNewTabs, bool pIsNewIcons)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetProfileTabsNames(private method)", string.Empty, string.Empty, string.Empty, string.Empty);

                //Tab name Variables
                string callTab = "", contactUsTab = "", directionTab = "Directions", submitTipTab = "", notificationTab = "", homeTab = "", aboutTab = "",
                    updatesTab = "", mediasTab = "", eventsTab = "", surveyTab = "", bulletinTab = "", webLinksTab = "", socialTab = "";

                // Tab Icons Names
                string callTabIcon = "call";
                string contactUsTabIcon = "contact";
                string directionTabIcon = "directions";
                string submitTipTabIcon = "SubmitTip";
                string notificationTabIcon = "Notification";
                string homeTabIcon = "Home";
                string aboutTabIcon = "AboutUs";
                string updatesTabIcon = "Updates";
                string mediasTabIcon = "Media";
                string eventsTabIcon = "Events";
                string surveyTabIcon = "Survey";
                string bulletinsTabIcon = "Bulletins";
                string webLinkTabIcon = "WebLinks";
                string socialTabIcon = "Social";


                #region Default Tabs Names by Domain

                string verticalCodeFolderName = "";
                verticalCodeFolderName = MServiceDAL.GetVerticalNameByProfileID(pProfileID);
                DataTable dtProfileDetails = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
                string countryName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);
                string domain = objCommonBLL.GetDomainNameByCountryVertical(verticalCodeFolderName, countryName.Trim());

                DataTable DtDefaultTabsName = BusinessDAL.GetDefaultProfileTabNames(domain);
                if (DtDefaultTabsName.Rows.Count > 0)
                {
                    DataRow[] drCall = DtDefaultTabsName.Select("Tab_Parent='Call'");
                    if (drCall.Length > 0)
                    {
                        callTab = drCall[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drContact = DtDefaultTabsName.Select("Tab_Parent='ContactUs'");
                    if (drContact.Length > 0)
                    {
                        contactUsTab = drContact[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drTip = DtDefaultTabsName.Select("Tab_Parent='Tips'");
                    if (drTip.Length > 0)
                    {
                        submitTipTab = drTip[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drNotification = DtDefaultTabsName.Select("Tab_Parent='Notifications'");
                    if (drNotification.Length > 0)
                    {
                        notificationTab = drNotification[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drHome = DtDefaultTabsName.Select("Tab_Parent='Home'");
                    if (drHome.Length > 0)
                    {
                        homeTab = drHome[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drAboutUs = DtDefaultTabsName.Select("Tab_Parent='AboutUs'");
                    if (drAboutUs.Length > 0)
                    {
                        aboutTab = drAboutUs[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drUpdates = DtDefaultTabsName.Select("Tab_Parent='Updates'");
                    if (drUpdates.Length > 0)
                    {
                        updatesTab = drUpdates[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drMedia = DtDefaultTabsName.Select("Tab_Parent='Gallery'");
                    if (drMedia.Length > 0)
                    {
                        mediasTab = drMedia[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drEvents = DtDefaultTabsName.Select("Tab_Parent='Events'");
                    if (drEvents.Length > 0)
                    {
                        eventsTab = drEvents[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drSurveys = DtDefaultTabsName.Select("Tab_Parent='Surveys'");
                    if (drSurveys.Length > 0)
                    {
                        surveyTab = drSurveys[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drBulletins = DtDefaultTabsName.Select("Tab_Parent='Bulletins'");
                    if (drBulletins.Length > 0)
                    {
                        bulletinTab = drBulletins[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drWebLinks = DtDefaultTabsName.Select("Tab_Parent='WebLinks'");
                    if (drWebLinks.Length > 0)
                    {
                        webLinksTab = drWebLinks[0]["Tab_Name"].ToString();
                    }
                    DataRow[] drSocialMedia = DtDefaultTabsName.Select("Tab_Parent='SocialMedia'");
                    if (drSocialMedia.Length > 0)
                    {
                        socialTab = drSocialMedia[0]["Tab_Name"].ToString();
                    }
                }


                #endregion


                string RootURL = "";
                string ServerIconPath = "";

                string outerURL = GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");
                //Note: only for this uspdhub news Icons
                if (pIsNewIcons)
                {
                    verticalCodeFolderName = verticalCodeFolderName + "_new";
                }
                //

                RootURL = outerURL + "/Upload/ProfileTabIcons/" + verticalCodeFolderName + "/" + pIconSize;
                ServerIconPath = HttpContext.Current.Server.MapPath("\\Upload\\ProfileTabIcons\\" + verticalCodeFolderName + "\\" + pIconSize);

                //ComingSoon Icon Path
                string defaultIconPath = outerURL + "/Upload/ComingSoonIcons/" + pIconSize + ".png";

                #region Tabs (Tools) Icons Path

                //Call Button
                if (File.Exists(ServerIconPath + "\\" + callTabIcon + "_n_" + pIconSize + ".png"))
                {
                    callTabIcon = RootURL + "/" + callTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    callTabIcon = defaultIconPath;
                }

                //Contact Us Button
                if (File.Exists(ServerIconPath + "\\" + contactUsTabIcon + "_n_" + pIconSize + ".png"))
                {
                    contactUsTabIcon = RootURL + "/" + contactUsTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    contactUsTabIcon = defaultIconPath;
                }
                //Direction Button
                if (File.Exists(ServerIconPath + "\\" + directionTabIcon + "_n_" + pIconSize + ".png"))
                {
                    directionTabIcon = RootURL + "/" + directionTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    directionTabIcon = defaultIconPath;
                }


                //Main Tools
                //Home Tab
                if (File.Exists(ServerIconPath + "\\" + homeTabIcon + "_n_" + pIconSize + ".png"))
                {
                    homeTabIcon = RootURL + "/" + homeTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    homeTabIcon = defaultIconPath;
                }
                //Notifications
                if (File.Exists(ServerIconPath + "\\" + notificationTabIcon + "_n_" + pIconSize + ".png"))
                {
                    notificationTabIcon = RootURL + "/" + notificationTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    notificationTabIcon = defaultIconPath;
                }
                //Submit Tip
                if (File.Exists(ServerIconPath + "\\" + submitTipTabIcon + "_n_" + pIconSize + ".png"))
                {
                    submitTipTabIcon = RootURL + "/" + submitTipTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    submitTipTabIcon = defaultIconPath;
                }
                //About Us
                if (File.Exists(ServerIconPath + "\\" + aboutTabIcon + "_n_" + pIconSize + ".png"))
                {
                    aboutTabIcon = RootURL + "/" + aboutTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    aboutTabIcon = defaultIconPath;
                }
                //Media 
                if (File.Exists(ServerIconPath + "\\" + mediasTabIcon + "_n_" + pIconSize + ".png"))
                {
                    mediasTabIcon = RootURL + "/" + mediasTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    mediasTabIcon = defaultIconPath;
                }
                //Updates
                if (File.Exists(ServerIconPath + "\\" + updatesTabIcon + "_n_" + pIconSize + ".png"))
                {
                    updatesTabIcon = RootURL + "/" + updatesTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    updatesTabIcon = defaultIconPath;
                }
                //Events
                if (File.Exists(ServerIconPath + "\\" + eventsTabIcon + "_n_" + pIconSize + ".png"))
                {
                    eventsTabIcon = RootURL + "/" + eventsTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    eventsTabIcon = defaultIconPath;
                }
                //Bulletins
                if (File.Exists(ServerIconPath + "\\" + bulletinsTabIcon + "_n_" + pIconSize + ".png"))
                {
                    bulletinsTabIcon = RootURL + "/" + bulletinsTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    bulletinsTabIcon = defaultIconPath;
                }
                //Weblink Tabs
                if (File.Exists(ServerIconPath + "\\" + webLinkTabIcon + "_n_" + pIconSize + ".png"))
                {
                    webLinkTabIcon = RootURL + "/" + webLinkTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    webLinkTabIcon = defaultIconPath;
                }
                //Social Media
                if (File.Exists(ServerIconPath + "\\" + socialTabIcon + "_n_" + pIconSize + ".png"))
                {
                    socialTabIcon = RootURL + "/" + socialTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    socialTabIcon = defaultIconPath;
                }
                //Survey 
                if (File.Exists(ServerIconPath + "\\" + surveyTabIcon + "_n_" + pIconSize + ".png"))
                {
                    surveyTabIcon = RootURL + "/" + surveyTabIcon + "_n_" + pIconSize + ".png";
                }
                else
                {
                    surveyTabIcon = defaultIconPath;
                }

                #endregion


                string toolsSettings = "<SubTools><Tools " + pToolsSettings + "/></SubTools>";
                string childTabName = string.Empty;
                var XMLTools = XElement.Parse(toolsSettings, LoadOptions.PreserveWhitespace);

                #region User Tab Names

                //Home Tabs
                if (XMLTools.Element("Tools").Attribute("HomeTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("HomeTabName").Value).Trim() != string.Empty)
                    {
                        homeTab = Convert.ToString(XMLTools.Element("Tools").Attribute("HomeTabName").Value).Trim();
                    }
                }

                /*
              //Contact US
              if (XMLTools.Element("Tools").Attribute("ContactUsTabName") != null)
              {
                  if (Convert.ToString(XMLTools.Element("Tools").Attribute("ContactUsTabName").Value).Trim() != string.Empty)
                  {
                      contactUsTab = Convert.ToString(XMLTools.Element("Tools").Attribute("ContactUsTabName").Value).Trim();
                  }
              } 
                 * */


                //Submit Tip
                if (XMLTools.Element("Tools").Attribute("SubmitTipName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("SubmitTipName").Value).Trim() != string.Empty)
                    {
                        submitTipTab = Convert.ToString(XMLTools.Element("Tools").Attribute("SubmitTipName").Value).Trim();
                    }
                }


                //Notifications
                if (XMLTools.Element("Tools").Attribute("NotificationTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("NotificationTabName").Value).Trim() != string.Empty)
                    {
                        notificationTab = Convert.ToString(XMLTools.Element("Tools").Attribute("NotificationTabName").Value).Trim();
                    }
                }
                //About Us
                if (XMLTools.Element("Tools").Attribute("AboutUsTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("AboutUsTabName").Value).Trim() != string.Empty)
                    {
                        aboutTab = Convert.ToString(XMLTools.Element("Tools").Attribute("AboutUsTabName").Value).Trim();
                    }
                }
                //Updates
                if (XMLTools.Element("Tools").Attribute("UpdatesTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("UpdatesTabName").Value).Trim() != string.Empty)
                    {
                        updatesTab = Convert.ToString(XMLTools.Element("Tools").Attribute("UpdatesTabName").Value).Trim();
                    }
                }
                //Media OR Gallery
                if (XMLTools.Element("Tools").Attribute("MediaTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("MediaTabName").Value).Trim() != string.Empty)
                    {
                        mediasTab = Convert.ToString(XMLTools.Element("Tools").Attribute("MediaTabName").Value).Trim();
                    }
                }
                //Events
                if (XMLTools.Element("Tools").Attribute("EventsTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("EventsTabName").Value).Trim() != string.Empty)
                    {
                        eventsTab = Convert.ToString(XMLTools.Element("Tools").Attribute("EventsTabName").Value).Trim();
                    }
                }
                //Bulletins
                if (XMLTools.Element("Tools").Attribute("BulletinsTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("BulletinsTabName").Value).Trim() != string.Empty)
                    {
                        bulletinTab = Convert.ToString(XMLTools.Element("Tools").Attribute("BulletinsTabName").Value).Trim();
                    }
                }
                //Weblinks
                if (XMLTools.Element("Tools").Attribute("WeblinksTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("WeblinksTabName").Value).Trim() != string.Empty)
                    {
                        webLinksTab = Convert.ToString(XMLTools.Element("Tools").Attribute("WeblinksTabName").Value).Trim();
                    }
                }
                //Social Media
                if (XMLTools.Element("Tools").Attribute("SocialMediaTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("SocialMediaTabName").Value).Trim() != string.Empty)
                    {
                        socialTab = Convert.ToString(XMLTools.Element("Tools").Attribute("SocialMediaTabName").Value).Trim();
                    }
                }
                //Surveys
                if (XMLTools.Element("Tools").Attribute("SurveysTabName") != null)
                {
                    if (Convert.ToString(XMLTools.Element("Tools").Attribute("SurveysTabName").Value).Trim() != string.Empty)
                    {
                        surveyTab = Convert.ToString(XMLTools.Element("Tools").Attribute("SurveysTabName").Value).Trim();
                    }
                }

                #endregion

                #region Final XML Tabs Names,Icons Path and  Tab ID

                if (verticalCodeFolderName.ToLower().Contains("inschoolhub") || verticalCodeFolderName.ToLower().Contains("twovie")
                    || verticalCodeFolderName.ToLower().Contains("myyouth"))
                {

                    //Call Button
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsPhoneNumber").Value) == true && pPhoneNumber != string.Empty)
                    {  //callTab=
                        childTabName = childTabName + "<Tab ID='CallTab' Name='" + callTab + "' Icon='" + callTabIcon + "'/>";
                    }
                    //Submit a Tip Tab #3 (Tips & Feedback)
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSubmitTip") != null))
                    {
                        if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSubmitTip").Value) == true && pEmailID != string.Empty)
                        {
                            childTabName = childTabName + "<Tab ID='SubmitTipTab' Name='" + submitTipTab + "' Icon='" + submitTipTabIcon + "' />";
                        }
                    }
                    //Notifications Tab #2
                    childTabName = childTabName + "<Tab ID='NotificationTab' Name='" + notificationTab + "' Icon='" + notificationTabIcon + "'/>";
                    //Home Tab #1
                    childTabName = childTabName + "<Tab ID='HomeTab' Name='" + homeTab + "' Icon='" + homeTabIcon + "'/>";

                    //Updates Tab #5                   
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsUpdates").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='UpdatesTab' Name='" + updatesTab + "' Icon='" + updatesTabIcon + "'/>";
                    }
                    //Survey Tab#10
                    bool IsSurveys = false;
                    if (XMLTools.Element("Tools").Attribute("IsSurveys") != null)
                    {
                        IsSurveys = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSurveys").Value);
                    }
                    if (pNewTabs.ToLower() == "Survey".ToLower() && IsSurveys == true)
                    {
                        childTabName = childTabName + "<Tab ID='SurveyTab' Name='" + surveyTab + "' Icon='" + surveyTabIcon + "'/>";
                    }

                    // Bulletins Tab #8
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsBulletins").Value) == true && ShowBulletins == true)
                    {
                        childTabName = childTabName + "<Tab ID='BulletinsTab' Name='" + bulletinTab + "' Icon='" + bulletinsTabIcon + "'/>";
                    }
                    //About Us Tab #4
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsAboutUs").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='AboutUsTab' Name='" + aboutTab + "' Icon='" + aboutTabIcon + "'/>";
                    }
                    // Events Tab #7
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsEvents").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='EventsTab' Name='" + eventsTab + "' Icon='" + eventsTabIcon + "'/>";
                    }
                    //Contact Us Button
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsContatUs").Value) == true && pEmailID != string.Empty)
                    {
                        childTabName = childTabName + "<Tab ID='ContactTab' Name='" + contactUsTab + "' Icon='" + contactUsTabIcon + "'/>";
                    }
                    //Photo Album #6
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsPhotos").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='MediaTab' Name='" + mediasTab + "' Icon='" + mediasTabIcon + "'/>";
                    }
                    // Social Media Tab #10
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSocial").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='SocialTab' Name='" + socialTab + "' Icon='" + socialTabIcon + "'/>";
                    }

                    //Direction Button
                    if (pStreetAddress != string.Empty && pCity != string.Empty && pState != string.Empty && pZipcode != string.Empty)
                    {
                        childTabName = childTabName + "<Tab ID='DirectionTab' Name='" + directionTab + "' Icon='" + directionTabIcon + "'/>";
                    }
                    // Weblinks Tab #9
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsWebLinks").Value) == true && ShowBulletins == true)
                    {
                        childTabName = childTabName + "<Tab ID='WebLinksTab' Name='" + webLinksTab + "' Icon='" + webLinkTabIcon + "'/>";
                    }
                }
                else if (verticalCodeFolderName.ToLower().Contains("uspdhub"))
                {
                    //Call Button
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsPhoneNumber").Value) == true && pPhoneNumber != string.Empty)
                    {
                        childTabName = childTabName + "<Tab ID='CallTab' Name='" + callTab + "' Icon='" + callTabIcon + "'/>";
                    }
                    //Contact Us Button
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsContatUs").Value) == true && pEmailID != string.Empty)
                    {
                        childTabName = childTabName + "<Tab ID='ContactTab' Name='" + contactUsTab + "' Icon='" + contactUsTabIcon + "'/>";
                    }
                    //Direction Button
                    if (pStreetAddress != string.Empty && pCity != string.Empty && pState != string.Empty && pZipcode != string.Empty)
                    {
                        childTabName = childTabName + "<Tab ID='DirectionTab' Name='" + directionTab + "' Icon='" + directionTabIcon + "'/>";
                    }
                    //Home Tab #1
                    childTabName = childTabName + "<Tab ID='HomeTab' Name='" + homeTab + "' Icon='" + homeTabIcon + "'/>";
                    //Notifications Tab #2
                    childTabName = childTabName + "<Tab ID='NotificationTab' Name='" + notificationTab + "' Icon='" + notificationTabIcon + "'/>";

                    //Submit a Tip Tab #3 (Tips & Feedback)
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSubmitTip") != null))
                    {
                        if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSubmitTip").Value) == true && pEmailID != string.Empty)
                        {
                            childTabName = childTabName + "<Tab ID='SubmitTipTab' Name='" + submitTipTab + "' Icon='" + submitTipTabIcon + "' />";
                        }
                    } // Bulletins Tab #8
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsBulletins").Value) == true && ShowBulletins == true)
                    {
                        childTabName = childTabName + "<Tab ID='BulletinsTab' Name='" + bulletinTab + "' Icon='" + bulletinsTabIcon + "'/>";
                    }
                    //Updates Tab #5
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsUpdates").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='UpdatesTab' Name='" + updatesTab + "' Icon='" + updatesTabIcon + "'/>";
                    }
                    //Photo Album #6
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsPhotos").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='MediaTab' Name='" + mediasTab + "' Icon='" + mediasTabIcon + "'/>";
                    }
                    // Events Tab #7
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsEvents").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='EventsTab' Name='" + eventsTab + "' Icon='" + eventsTabIcon + "'/>";
                    }

                    //Survey Tab#11
                    bool IsSurveys = false;
                    if (XMLTools.Element("Tools").Attribute("IsSurveys") != null)
                    {
                        IsSurveys = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSurveys").Value);
                    }
                    if (pNewTabs.ToLower() == "Survey".ToLower() && IsSurveys == true)
                    {

                        childTabName = childTabName + "<Tab ID='SurveyTab' Name='" + surveyTab + "' Icon='" + surveyTabIcon + "'/>";
                    }

                    //About Us Tab #4
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsAboutUs").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='AboutUsTab' Name='" + aboutTab + "' Icon='" + aboutTabIcon + "'/>";
                    }

                    // Weblinks Tab #9
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsWebLinks").Value) == true && ShowBulletins == true)
                    {
                        childTabName = childTabName + "<Tab ID='WebLinksTab' Name='" + webLinksTab + "' Icon='" + webLinkTabIcon + "'/>";
                    }
                    // Social Media Tab #10
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSocial").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='SocialTab' Name='" + socialTab + "' Icon='" + socialTabIcon + "'/>";
                    }
                }
                else
                {
                    //Call Button
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsPhoneNumber").Value) == true && pPhoneNumber != string.Empty)
                    {
                        childTabName = childTabName + "<Tab ID='CallTab' Name='" + callTab + "' Icon='" + callTabIcon + "'/>";
                    }
                    //Contact Us Button
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsContatUs").Value) == true && pEmailID != string.Empty)
                    {
                        childTabName = childTabName + "<Tab ID='ContactTab' Name='" + contactUsTab + "' Icon='" + contactUsTabIcon + "'/>";
                    }
                    //Direction Button
                    if (pStreetAddress != string.Empty && pCity != string.Empty && pState != string.Empty && pZipcode != string.Empty)
                    {
                        childTabName = childTabName + "<Tab ID='DirectionTab' Name='" + directionTab + "' Icon='" + directionTabIcon + "'/>";
                    }
                    //Home Tab #1
                    childTabName = childTabName + "<Tab ID='HomeTab' Name='" + homeTab + "' Icon='" + homeTabIcon + "'/>";
                    //Notifications Tab #2
                    childTabName = childTabName + "<Tab ID='NotificationTab' Name='" + notificationTab + "' Icon='" + notificationTabIcon + "'/>";

                    //Submit a Tip Tab #3 (Tips & Feedback)
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSubmitTip") != null))
                    {
                        if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSubmitTip").Value) == true && pEmailID != string.Empty)
                        {
                            childTabName = childTabName + "<Tab ID='SubmitTipTab' Name='" + submitTipTab + "' Icon='" + submitTipTabIcon + "' />";
                        }
                    }
                    //About Us Tab #4
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsAboutUs").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='AboutUsTab' Name='" + aboutTab + "' Icon='" + aboutTabIcon + "'/>";
                    }
                    //Updates Tab #5
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsUpdates").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='UpdatesTab' Name='" + updatesTab + "' Icon='" + updatesTabIcon + "'/>";
                    }
                    //Photo Album #6
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsPhotos").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='MediaTab' Name='" + mediasTab + "' Icon='" + mediasTabIcon + "'/>";
                    }
                    // Events Tab #7
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsEvents").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='EventsTab' Name='" + eventsTab + "' Icon='" + eventsTabIcon + "'/>";
                    }

                    //Survey Tab#11
                    bool IsSurveys = false;
                    if (XMLTools.Element("Tools").Attribute("IsSurveys") != null)
                    {
                        IsSurveys = Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSurveys").Value);
                    }
                    if (pNewTabs.ToLower() == "Survey".ToLower() && IsSurveys == true)
                    {

                        childTabName = childTabName + "<Tab ID='SurveyTab' Name='" + surveyTab + "' Icon='" + surveyTabIcon + "'/>";
                    }

                    // Bulletins Tab #8
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsBulletins").Value) == true && ShowBulletins == true)
                    {
                        childTabName = childTabName + "<Tab ID='BulletinsTab' Name='" + bulletinTab + "' Icon='" + bulletinsTabIcon + "'/>";
                    }
                    // Weblinks Tab #9
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsWebLinks").Value) == true && ShowBulletins == true)
                    {
                        childTabName = childTabName + "<Tab ID='WebLinksTab' Name='" + webLinksTab + "' Icon='" + webLinkTabIcon + "'/>";
                    }
                    // Social Media Tab #10
                    if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsSocial").Value) == true)
                    {
                        childTabName = childTabName + "<Tab ID='SocialTab' Name='" + socialTab + "' Icon='" + socialTabIcon + "'/>";
                    }
                }

                #endregion

                return childTabName;

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetProfileTabsNames(private method)", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }

        }


        /// <summary>
        /// Getting User Buy Tools
        /// </summary>
        /// <param name="pUserID">param is pUserID</param>
        /// <param name="ShowBulletins">param is ShowBulletins</param>
        /// <returns>return tools</returns>
        public string GetSelectedToolsSettings(int pUserID, bool ShowBulletins)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetSelectedToolsSettings( Line Number-- 889)", string.Empty, string.Empty, string.Empty, string.Empty);


                DataTable dtSelectedTools = USPDHUBDAL.MServiceDAL.GetMobileAppSetting(Convert.ToInt32(pUserID));

                string xmlSelectedTools = "";
                if (dtSelectedTools.Rows.Count <= 0)
                {
                    ;
                }
                else
                {
                    xmlSelectedTools = Convert.ToString(dtSelectedTools.Rows[0]["M_SettingValue"]);
                }
                if (ShowBulletins == false)
                {
                    xmlSelectedTools = xmlSelectedTools.Replace("IsPhotoCapture='True'", "IsPhotoCapture='False'");
                    xmlSelectedTools = xmlSelectedTools.Replace("IsPhotoCapture='true'", "IsPhotoCapture='False'");
                    xmlSelectedTools = xmlSelectedTools.Replace("IsGeoLocation='True'", "IsGeoLocation='False'");
                    xmlSelectedTools = xmlSelectedTools.Replace("IsGeoLocation='true'", "IsGeoLocation='False'");
                }
                xmlSelectedTools = xmlSelectedTools.Replace("BName", "IsPName");
                xmlSelectedTools = xmlSelectedTools.Replace("Logo", "IsLogo");
                xmlSelectedTools = xmlSelectedTools.Replace("Address", "IsAddress");
                xmlSelectedTools = xmlSelectedTools.Replace("City", "IsCity");
                xmlSelectedTools = xmlSelectedTools.Replace("State", "IsState");
                xmlSelectedTools = xmlSelectedTools.Replace("Country", "IsCountry");
                xmlSelectedTools = xmlSelectedTools.Replace("ZipCode", "IsZipCode");
                xmlSelectedTools = xmlSelectedTools.Replace("PhoneNumber", "IsPhoneNumber");
                xmlSelectedTools = xmlSelectedTools.Replace("EmailID=", "IsEmailID=");
                xmlSelectedTools = xmlSelectedTools.Replace("AboutUs=", "IsAboutUs=");
                xmlSelectedTools = xmlSelectedTools.Replace("Updates=", "IsUpdates=");
                xmlSelectedTools = xmlSelectedTools.Replace("Social=", "IsSocial=");
                xmlSelectedTools = xmlSelectedTools.Replace("Coupons=", "IsCoupons=");
                xmlSelectedTools = xmlSelectedTools.Replace("Photos=", "IsPhotos=");
                xmlSelectedTools = xmlSelectedTools.Replace("Events=", "IsEvents=");

                xmlSelectedTools = xmlSelectedTools.Replace("<SubTools><Tools", "");
                xmlSelectedTools = xmlSelectedTools.Replace("/></SubTools>", "");

                return xmlSelectedTools;

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetSelectedToolsSettings( Line Number-- 889)", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting Home Page Settings
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return home tab settings</returns>
        private string HomeTabSettings(int pProfileID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "HomeTabSettings( Line Number --  950)", string.Empty, string.Empty, string.Empty, string.Empty);


                string details = "";
                bool isHomeImage = false;
                string yearEstablished = string.Empty;
                string noOfEmployee = string.Empty;
                string memberShip = string.Empty;
                bool establishmentflag = false;
                bool noofemployeesflag = false;

                //Getting Home Page Images
                var dtobj = BusinessDAL.GetProfilePhotosByProfileID(Convert.ToInt32(pProfileID));

                string outerURL = GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");
                var uploadphotosPath = outerURL + "/Upload/Photos/" + pProfileID + "/";
                if (dtobj.Rows.Count > 0)
                {
                    if (dtobj.Rows[0]["Photo_Prime_Flag"].ToString() == "True")
                    {
                        uploadphotosPath = uploadphotosPath + dtobj.Rows[0]["Photo_image_path"].ToString();
                        isHomeImage = true;
                    }
                    else
                    {
                        isHomeImage = false;
                    }
                }
                else
                {
                    isHomeImage = false;
                }
                details = " IsHomeImage='" + isHomeImage + "' IsYearEst='" + establishmentflag + "'" +
                    " IsNoOfEmps='" + noofemployeesflag + "'   HomeImage='" + uploadphotosPath + "'  YearEst='" + yearEstablished + "'" +
                    " NoOfEmps='" + noOfEmployee + "' MemberType='" + ReplaceSpecialCharacter(memberShip) + "'     ";
                return details;

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "HomeTabSettings( Line Number --  950)", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }

        }

        /// <summary>
        /// Convert long url To short url
        /// </summary>
        /// <param name="longurl">longurl</param>
        /// <returns>String</returns>
        public string longurlToshorturl(string longurl)
        {
            ErrorHandling("LOG ", "MServiceBLL.cs", "longurlToshorturl", string.Empty, string.Empty, string.Empty, string.Empty);

            string shortURL = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/urlshortener/v1/url");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

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
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "longurlToshorturl", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        #endregion


        /// <summary>
        /// Getting business details by profile code & radius values
        /// </summary>
        /// <param name="pBCode">param is pBCode</param>
        /// <param name="latitude2">param is latitude2</param>
        /// <param name="longitude2">param is longitude2</param>
        /// <param name="radius">param is radius</param>
        /// <returns>return business details as XML string</returns>
        public string GetProfileDetailsByBCode(string pBCode, int pProfileID, string pType, string latitude2, string longitude2, string radius, string pVCode)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetProfileDetailsByBCode( Type = " + pType + ")", string.Empty, string.Empty, string.Empty, string.Empty);


                string xmlSearchResult = string.Empty;
                DataTable dtResult = USPDHUBDAL.MServiceDAL.GetProfiledetailsByBCode(pBCode, pProfileID, pType, latitude2, longitude2, radius, pVCode);

                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    #region Address , Email ID, Phome Number and Bulletins Display Settings

                    bool ShowBulletins = false;
                    if (!string.IsNullOrEmpty(dtResult.Rows[i]["Package_Number"].ToString()))
                    {
                        if (Convert.ToInt32(dtResult.Rows[i]["Package_Number"].ToString()) > 4)
                        {
                            ShowBulletins = true;
                        }
                    }
                    string address = string.Empty;
                    if (Convert.ToString(dtResult.Rows[i]["Profile_StreetAddress2"]) == string.Empty)
                    {
                        address = Convert.ToString(dtResult.Rows[i]["Profile_StreetAddress1"]);
                    }
                    else
                    {
                        address = Convert.ToString(dtResult.Rows[i]["Profile_StreetAddress1"]) + ", " + Convert.ToString(dtResult.Rows[i]["Profile_StreetAddress2"]);
                    }

                    string EmailID = string.Empty;
                    if (Convert.ToString(dtResult.Rows[i]["User_email"]) == string.Empty)
                    {
                        EmailID = Convert.ToString(dtResult.Rows[i]["Username"]); ;
                    }
                    else
                    {
                        EmailID = Convert.ToString(dtResult.Rows[i]["User_email"]);
                    }


                    var ToolsIcons = GetSelectedToolsSettings(Convert.ToInt32(dtResult.Rows[i]["User_ID"]), ShowBulletins);
                    var phoneNumber = "";


                    string toolsSettings = "<SubTools><Tools " + ToolsIcons + "/></SubTools>";
                    var XMLTools = XElement.Parse(toolsSettings, LoadOptions.PreserveWhitespace);

                    //Getting mobile number based on mobile app settings Radio phone numbers
                    if (XMLTools.Element("Tools").Attribute("IsMainPH") == null)
                    {
                        phoneNumber = Convert.ToString(dtResult.Rows[i]["Mobile_Number"]);
                    }
                    else
                    {
                        if (Convert.ToBoolean(XMLTools.Element("Tools").Attribute("IsMainPH").Value) == true)
                        {
                            phoneNumber = Convert.ToString(dtResult.Rows[i]["Mobile_Number"]);
                        }
                        else
                        {
                            phoneNumber = Convert.ToString(dtResult.Rows[i]["Alternate_Phone"]);
                        }
                    }

                    #endregion

                    #region Agency Logo Path Assign

                    string logoName = "";
                    logoName = Convert.ToString(dtResult.Rows[i]["Profile_logo_path"]);
                    int logoprofileid = Convert.ToInt32(dtResult.Rows[i]["Profile_ID"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(dtResult.Rows[i]["Parent_ProfileID"])))
                    {
                        logoprofileid = Convert.ToInt32(dtResult.Rows[i]["Parent_ProfileID"].ToString());
                        DataTable dtparentProfile = USPDHUBDAL.MServiceDAL.GetProfiledetailsByBCode(string.Empty, logoprofileid, "2", "0.0", "0.0", "0", "1");
                        logoName = Convert.ToString(dtparentProfile.Rows[0]["Profile_logo_path"]);
                    }
                    string extension = System.IO.Path.GetExtension(logoName);
                    if (logoName == string.Empty)
                    {
                        extension = ".jpg";
                    }
                    string outerURL = GetConfigSettings(Convert.ToString(dtResult.Rows[i]["Profile_ID"]), "Paths", "RootPath");
                    string logoFullPath = "";
                    string logoServerpath = HttpContext.Current.Server.MapPath("\\Upload\\Logos\\");
                    logoServerpath = logoServerpath + logoprofileid + "\\" + logoprofileid + "_thumb" + extension;
                    if (File.Exists(logoServerpath) && logoName != "")
                    {
                        logoFullPath = outerURL + "/Upload/Logos/" +
                          logoprofileid + "/" + logoprofileid + "_thumb" + extension;
                    }
                    else
                    {
                        logoFullPath = outerURL + "/Upload/ComingSoonIcons/logo.png";
                    }

                    #endregion

                    #region Agency Record checking Parent or Child

                    //Is Checking Is It Parent or Child
                    bool isParent = true;
                    if (Convert.ToString(dtResult.Rows[i]["Parent_ProfileID"]) == string.Empty)
                    {
                        isParent = true;
                    }
                    else
                    {
                        isParent = false;
                    }

                    #endregion


                    xmlSearchResult = xmlSearchResult + "<Prof PID='" + Convert.ToString(dtResult.Rows[i]["Profile_ID"]) + "'" +
                        " UID='" + Convert.ToString(dtResult.Rows[i]["User_ID"]) + "'" +
                        " P_PName='" + ReplaceSpecialCharacter(Convert.ToString(dtResult.Rows[i]["Profile_name"])) + "'" +
                        " P_BName='" + ReplaceSpecialCharacter(Convert.ToString(dtResult.Rows[i]["Profile_displayname"])) + "'" +
                        " P_Logo='" + logoFullPath + "'" +
                        " P_Address='" + ReplaceSpecialCharacter(address) + "'" +
                        " P_MobileNumber='" + phoneNumber + "'" +
                        " P_EmailID='" + EmailID + "'" +
                        " P_City='" + ReplaceSpecialCharacter(Convert.ToString(dtResult.Rows[i]["Profile_City"])) + "'" +
                        " P_State='" + Convert.ToString(dtResult.Rows[i]["Profile_State"]) + "'" +
                        " P_Zipcode='" + Convert.ToString(dtResult.Rows[i]["Profile_Zipcode"]) + "'" +
                        " P_Country='" + Convert.ToString(dtResult.Rows[i]["Profile_County"]) + "'" +
                          " P_Latitude='" + Convert.ToString(dtResult.Rows[i]["latitude1"]) + "'" +
                          " P_Longitude='" + Convert.ToString(dtResult.Rows[i]["longitude1"]) + "'" +
                          " P_IsParent='" + isParent + "'" +
                          " " + HomeTabSettings(Convert.ToInt32(dtResult.Rows[i]["Profile_ID"])) + " " +
                          " " + ToolsIcons + " " +
                          "/> ";
                }

                //--1 means validate b code getting via business details by BCode
                //--2 means getting business details by profile
                //--3 Means Getting child Records base parent profileIDs
                if (pType == "1" || pType == "3")
                {
                    xmlSearchResult = "<BPDetails>" + xmlSearchResult + "</BPDetails>" + GetBulletinCategories(pVCode);
                }
                else
                {
                    //here getting profile id based details                
                }
                return xmlSearchResult;

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetProfileDetailsByBCode( Type = " + pType + ")", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
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
        public string InsertAppDeviceDetails(string pDeviceID, int pProfileID, string pDeviceType, string pBusinessName, string pAddress, int pApp_ID)
        {
            return USPDHUBDAL.MServiceDAL.InsertAppDeviceDetails(pDeviceID, pProfileID, pDeviceType, pBusinessName, pAddress, pApp_ID);
        }

        /// <summary>
        /// Delete device details
        /// </summary>
        /// <param name="pDeviceID">param is pDeviceID</param>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return success or failure</returns>
        public string DeleteAppDeviceDetails(string pDeviceID, int pProfileID, int pApp_ID)
        {
            return USPDHUBDAL.MServiceDAL.DeleteAppDeviceDetails(pDeviceID, pProfileID, pApp_ID);
        }

        /// <summary>
        /// Getting all active & publish bulletins by profile id
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return bulletins as XML string</returns>
        public string GetActiveBulletinsByProfileID(int pProfileID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetActiveBulletinsByProfileID()", string.Empty, string.Empty, string.Empty, string.Empty);


                string xmlActiveBulletinsString = string.Empty;
                DataTable dtActiveBulletins = USPDHUBDAL.BulletinDAL.GetActiveBulletinsByProfileID(Convert.ToInt32(pProfileID));

                string outerURL = GetConfigSettings(Convert.ToString(pProfileID), "Paths", "RootPath");

                #region Vertical Logo

                BusinessBLL objBusinessBLL = new BusinessBLL();
                var dtProfileDetails = objBusinessBLL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
                string verticalDomain = objCommonBLL.GetDomainNameByCountry(Convert.ToInt32(dtProfileDetails.Rows[0]["User_ID"]));
                string VerticalLogo = outerURL + "/images/VerticalLogos/" + verticalDomain + "logo.png";

                #endregion

                for (int i = 0; i < dtActiveBulletins.Rows.Count; i++)
                {
                    string bulletinURL = outerURL + "/OnlineBulletin.aspx?BLID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(dtActiveBulletins.Rows[i]["Bulletin_ID"])).Replace("=", "irhmalli").Replace("+", "irhPASS");
                    //bulletinURL = longurlToshorturl(bulletinURL);

                    if (!string.IsNullOrEmpty(dtActiveBulletins.Rows[i]["Shorten_Url"].ToString()))
                    {
                        bulletinURL = dtActiveBulletins.Rows[i]["Shorten_Url"].ToString();
                    }

                    xmlActiveBulletinsString = xmlActiveBulletinsString + "<Details BulletinID='" + Convert.ToString(dtActiveBulletins.Rows[i]["Bulletin_ID"]) + "'" +
                        " Title='" + ReplaceSpecialCharacter(Convert.ToString(dtActiveBulletins.Rows[i]["Bulletin_Title"])) + "'" +
                        " IsAlternatePhone='" + Convert.ToString(dtActiveBulletins.Rows[i]["IsCall"]) + "' " +
                        " IsContactUs='" + Convert.ToString(dtActiveBulletins.Rows[i]["IsContactUs"]) + "' " +
                        " BulletinURL='" + bulletinURL + "' " +
                        " PublishDate='" + Convert.ToString(dtActiveBulletins.Rows[i]["Publish_Date"]) + "' " +
                        " CateName='" + ReplaceSpecialCharacter(Convert.ToString(dtActiveBulletins.Rows[i]["Bulletin_Category"])) + "' " +
                        " VerticalLogo='" + VerticalLogo + "' " +
                       " />";
                }
                xmlActiveBulletinsString = "<Bulletins>" + xmlActiveBulletinsString + "</Bulletins>";
                return xmlActiveBulletinsString;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetActiveBulletinsByProfileID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Getting all categories
        /// </summary>
        /// <returns>return categories as xml string</returns>
        public string GetBulletinCategories(string pVCode)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetBulletinCategories()", string.Empty, string.Empty, string.Empty, string.Empty);

                string xmlcategories = string.Empty;
                /*
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                DataTable dtLabelData = objInBuiltData.GetBulletinLabelData();
                DataRow[] drCate = dtLabelData.Select("Type='BulletinCategories'");

                xmlcategories = "<Cat  Name='All' />";
                foreach (DataRow row in drCate)
                {
                    string CateName = Convert.ToString(row[2].ToString());
                    CateName = ReplaceSpecialCharacter(CateName);
                    xmlcategories = xmlcategories + "<Cat  Name='" + CateName + "' />";
                }
                */
                DataTable dtLabelData = BulletinDAL.GetBulletinCategoriesData(pVCode);
                xmlcategories = "<Cat  Name='All' />";
                for (int i = 0; i < dtLabelData.Rows.Count; i++)
                {
                    string CateName = Convert.ToString(dtLabelData.Rows[i]["Category_Name"]);
                    CateName = ReplaceSpecialCharacter(CateName);
                    xmlcategories = xmlcategories + "<Cat  Name='" + CateName + "' />";
                }
                xmlcategories = "<Categories>" + xmlcategories + "</Categories>";
                return xmlcategories;

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetBulletinCategories()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }


        /// <summary>
        /// Getting bulletin html details by bulletin ID
        /// </summary>
        /// <param name="pBulletinID">param is pBulletinID</param>
        /// <returns>return bulletin html as string</returns>
        public string GetBulletinHTMLStringByID(int pBulletinID, string pTabletName, string pDeviceWidth)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetBulletinHTMLStringByID()", string.Empty, string.Empty, string.Empty, string.Empty);

                DataTable dtActiveBulletins = USPDHUBDAL.BulletinDAL.GetBulletinDetailsByID(Convert.ToInt32(pBulletinID));
                string htmlString = "";
                if (dtActiveBulletins.Rows.Count > 0)
                {
                    htmlString = BuildHeader().Replace("#BuildHtmlForForm#", Convert.ToString(dtActiveBulletins.Rows[0]["Bulletin_HTML"]));
                    htmlString = htmlString.Replace("margin-left:20px;", "margin-left:0px;");
                    htmlString = htmlString.Replace("margin-left: 20px;", "margin-left: 0px;");

                    #region Device Width wise preview html data setting.

                    if (Convert.ToString(pTabletName) != string.Empty)
                    {
                        htmlString = ReplaceWidthTabletDevices(htmlString, pTabletName, pDeviceWidth);
                    }

                    #endregion

                }
                return htmlString;

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetBulletinHTMLStringByID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Push Notifications
        /// </summary>
        /// <param name="pMessage">pMessage</param>
        /// <returns>String</returns>
        public string PushNotifications(string pMessage)
        {
            return pMessage;
        }

        /// <summary>
        /// Getting Weblinks by profile ID
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>return weblinks as XML string</returns>
        public string GetWebLinks(string pProfileID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetWebLinks()", string.Empty, string.Empty, string.Empty, string.Empty);

                string xmlWebLink = string.Empty;
                DataTable dtWebLinks = BusinessDAL.GetWebLinks(Convert.ToInt32(pProfileID));
                for (int i = 0; i < dtWebLinks.Rows.Count; i++)
                {
                    xmlWebLink = xmlWebLink + "<Link Name='" + ReplaceSpecialCharacter(Convert.ToString(dtWebLinks.Rows[i]["Link_Title"])) + "' URL='" + Convert.ToString(dtWebLinks.Rows[i]["Link_Url"]) + "' />";
                }

                xmlWebLink = "<WebLinks>" + xmlWebLink + "</WebLinks>";
                return xmlWebLink;

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetWebLinks()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }

        }

        /// <summary>
        /// Get Devices for Notifications
        /// </summary>
        /// <param name="ProfileID">ProfileID</param>
        /// <param name="pushTypeId">pushTypeId</param>
        /// <param name="pushType">pushType</param>
        /// <returns>DataTable</returns>
        public DataTable GetDevicesforNotifications(int ProfileID, int pushTypeId, string pushType)
        {
            return MServiceDAL.GetDevicesforNotifications(ProfileID, pushTypeId, pushType);
        }

        /// <summary>
        /// Save the Push Notification details
        /// </summary>
        /// <param name="Message">param is Message</param>
        /// <param name="ProfileID">param is ProfileID</param>
        /// <param name="CreatedUser">param is CreatedUser</param>
        /// <param name="TotalDevices">param is TotalDevices</param>
        /// <param name="SentDevices">param is SentDevices</param>
        /// <param name="DeviceIDs">param is DeviceIDs</param>
        /// <param name="Flag">param is Flag</param>
        public int AddPushNotifications(string message, int profileID, int createdUser, int totalDevices, int sentDevices, string deviceIDs, int flag, string type, int typeID, int sentFlag, DateTime dtSentDate, string notificationSendType, string messageSendType)
        {
            return MServiceDAL.AddPushNotifications(message, profileID, createdUser, totalDevices, sentDevices, deviceIDs, flag, type, typeID, sentFlag, dtSentDate, notificationSendType, messageSendType);
        }

        /// <summary>
        /// Cancel Notification Schedule
        /// </summary>
        /// <param name="pushNotifyID">pushNotifyID</param>
        /// <param name="modifiedUser">modifiedUser</param>
        public void CancelNotificationSchedule(int pushNotifyID, int modifiedUser)
        {
            MServiceDAL.CancelNotificationSchedule(pushNotifyID, modifiedUser);
        }
        /// <summary>
        /// Getting Push Notification by Profile ID & Device ID
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <param name="pDeviceID">param is pDeviceID</param>
        /// <returns>return details</returns>
        public string GetPushNotifications(string pProfileID, string pDeviceID, int pAppID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetPushNotification()", string.Empty, string.Empty, string.Empty, string.Empty);

                string xmlPushNotification = string.Empty;
                DataTable dtPushNotification = MServiceDAL.GetPushNotifications(Convert.ToInt32(pProfileID), pDeviceID, pAppID);

                // Type Means Like General, Bulletin, Update 
                // Type ID Means Bulletin ID, Update ID
                for (int i = 0; i < dtPushNotification.Rows.Count; i++)
                {
                    xmlPushNotification = xmlPushNotification + "<Notify PushNotifyID='" + Convert.ToString(dtPushNotification.Rows[i]["PushNotifyID"]) + "'" +
                        " Message='" + ReplaceSpecialCharacter(Convert.ToString(dtPushNotification.Rows[i]["Message"])) + "'" +
                        " SentDate='" + Convert.ToString(dtPushNotification.Rows[i]["Created_Date"]) + "' " +
                        " PushType='" + Convert.ToString(dtPushNotification.Rows[i]["Type"]) + "' " +
                        " PushTypeID='" + Convert.ToString(dtPushNotification.Rows[i]["Type_ID"]) + "' " +
                       " />";
                }
                xmlPushNotification = "<Notifications>" + xmlPushNotification + "</Notifications>";
                return xmlPushNotification;

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetPushNotification()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Add Header for Bulletin HTML String
        /// </summary>
        /// <returns>String</returns>
        private string BuildHeader()
        {
            string strHeader = "";
            string strfilepath = System.Web.HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\CommonHeaderM.txt";
            System.IO.StreamReader re = System.IO.File.OpenText(strfilepath);
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                strHeader = strHeader + input;
            }
            re.Close();
            re.Dispose();
            return strHeader;
        }

        /// <summary>
        /// Replace 300 to Table Device Width based on passing parameters
        /// </summary>
        /// <param name="pHtmlString">pHtmlString</param>
        /// <param name="pTabletName">pTabletName</param>
        /// <param name="pDeviceWidth">pDeviceWidth</param>
        /// <returns>String</returns>
        private string ReplaceWidthTabletDevices(string pHtmlString, string pTabletName, string pDeviceWidth)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "ReplaceWidthTabletDevices()----pHtmlString " + pHtmlString, string.Empty, string.Empty, string.Empty, string.Empty);

                if (pTabletName.ToLower() == "10tab")
                {
                    ErrorHandling("LOG ", "MServiceBLL.cs", "ReplaceWidthTabletDevices() 10tab ", string.Empty, string.Empty, string.Empty, string.Empty);

                    pHtmlString = pHtmlString.Replace("width: 300px;", "width:" + pDeviceWidth + "px;");
                    pHtmlString = pHtmlString.Replace("width:300px;", "width: " + pDeviceWidth + "px;");

                    pHtmlString = pHtmlString.Replace("Width: 300px;", "width:" + pDeviceWidth + "px;");
                    pHtmlString = pHtmlString.Replace("Width:300px;", "width: " + pDeviceWidth + "px;");

                    pHtmlString = pHtmlString.Replace("WIDTH: 300px;", "width:" + pDeviceWidth + "px;");
                    pHtmlString = pHtmlString.Replace("WIDTH:300px;", "width: " + pDeviceWidth + "px;");

                }
                if (pTabletName.ToLower() == "7tab")
                {
                    ErrorHandling("LOG ", "MServiceBLL.cs", "ReplaceWidthTabletDevices() 7tab ", string.Empty, string.Empty, string.Empty, string.Empty);

                    pHtmlString = pHtmlString.Replace("width: 300px;", "width:" + pDeviceWidth + "px;");
                    pHtmlString = pHtmlString.Replace("width:300px;", "width: " + pDeviceWidth + "px;");

                    pHtmlString = pHtmlString.Replace("Width: 300px;", "width:" + pDeviceWidth + "px;");
                    pHtmlString = pHtmlString.Replace("Width:300px;", "width: " + pDeviceWidth + "px;");

                    pHtmlString = pHtmlString.Replace("WIDTH: 300px;", "width:" + pDeviceWidth + "px;");
                    pHtmlString = pHtmlString.Replace("WIDTH:300px;", "width: " + pDeviceWidth + "px;");
                }
                return pHtmlString;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "ReplaceWidthTabletDevices()", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Get Agenecy Summary
        /// </summary>
        /// <param name="pProfileIDs">pProfileIDs</param>
        /// <param name="pDeviceID">pDeviceID</param>
        /// <param name="pAppID">pAppID</param>
        /// <returns>String</returns>
        public string GetAgenecySummary(string pProfileIDs, string pDeviceID, int pAppID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetAgenecySummary()", string.Empty, string.Empty, string.Empty, string.Empty);

                string result = string.Empty;

                pProfileIDs = pProfileIDs.Trim();

                if (pProfileIDs.StartsWith(","))
                {
                    pProfileIDs = pProfileIDs.Substring(1);
                }
                if (pProfileIDs.EndsWith(","))
                {
                    pProfileIDs = pProfileIDs.Remove(pProfileIDs.Length - 1);
                }

                ErrorHandling("LOG ", "MService.asmx", "GetAgenecySummary()", pProfileIDs, string.Empty, string.Empty, string.Empty);

                var ids = pProfileIDs.Split(',');
                string summary = "";

                DataTable mainTable = new DataTable("main");
                for (int i = 0; i < ids.Count(); i++)
                {
                    var dtResult = MServiceDAL.GetAgencySummary(Convert.ToInt32(ids[i]), pDeviceID, pAppID);

                    ErrorHandling("LOG ", "MService.asmx", "GetAgenecySummary()-- ProfileID:: " + ids[i], string.Empty, string.Empty, string.Empty, string.Empty);
                    ErrorHandling("LOG ", "MService.asmx", "GetAgenecySummary()-- dtResult Count:: " + dtResult.Rows.Count.ToString(), string.Empty, string.Empty, string.Empty, string.Empty);

                    if (mainTable.Columns.Count <= 0)
                    {
                        foreach (var column in dtResult.Columns)
                        {
                            mainTable.Columns.Add(column.ToString());
                        }
                    }

                    mainTable.Columns["PublishDate"].DataType = typeof(DateTime);
                    mainTable.Columns["SentTimeStamp"].DataType = typeof(DateTime);

                    //Adding Every Result from Profile IDs
                    for (int j = 0; j < dtResult.Rows.Count; j++)
                    {
                        DataRow newRow = mainTable.NewRow();
                        newRow["ID"] = dtResult.Rows[j]["ID"];
                        newRow["Title"] = dtResult.Rows[j]["Title"];
                        if (Convert.ToString(dtResult.Rows[j]["PublishDate"]) != "")
                        {
                            //Convert.ToDateTime(dtResult.Rows[j]["PublishDate"]).ToString("MM/dd/yyyy HH:mm:ss");
                            //newRow["PublishDate"] = Convert.ToDateTime(dtResult.Rows[j]["PublishDate"]).ToString("MM/dd/yyyy hh:mm:ss tt");
                            newRow["PublishDate"] = Convert.ToDateTime(dtResult.Rows[j]["PublishDate"]).ToString("MM/dd/yyyy HH:mm:ss");
                        }
                        else
                        {
                            newRow["PublishDate"] = dtResult.Rows[j]["PublishDate"];
                        }
                        newRow["MType"] = dtResult.Rows[j]["MType"];
                        newRow["Description"] = dtResult.Rows[j]["Description"];
                        newRow["PID"] = dtResult.Rows[j]["PID"];
                        newRow["AgencyName"] = dtResult.Rows[j]["AgencyName"];
                        newRow["IsCall"] = dtResult.Rows[j]["IsCall"];
                        newRow["IsContactUs"] = dtResult.Rows[j]["IsContactUs"];
                        newRow["EventStartDate"] = dtResult.Rows[j]["EventStartDate"];
                        newRow["EventEndDate"] = dtResult.Rows[j]["EventEndDate"];
                        newRow["SentTimeStamp"] = dtResult.Rows[j]["SentTimeStamp"];
                        newRow["IsNotification"] = dtResult.Rows[j]["IsNotification"];
                        newRow["TMessage"] = dtResult.Rows[j]["TMessage"];
                        newRow["Status"] = dtResult.Rows[j]["Status"];

                        mainTable.Rows.Add(newRow);
                    }

                    ErrorHandling("LOG ", "MService.asmx", "GetAgenecySummary()-- 1***mainTable Count:: " + mainTable.Rows.Count.ToString(), string.Empty, string.Empty, string.Empty, string.Empty);
                }


                DataView dv = new DataView(mainTable);
                dv.Sort = "PublishDate DESC";
                mainTable = dv.ToTable();
                ErrorHandling("LOG ", "MService.asmx", "GetAgenecySummary()-- 2***mainTable Count:: " + mainTable.Rows.Count.ToString(), string.Empty, string.Empty, string.Empty, string.Empty);

                //mainTable.DefaultView.Sort = "PublishDate desc";
                // DataRow[] dr = mainTable.Select("order by PublishDate desc");
                // mainTable = dr.CopyToDataTable();

                //Getting TOP *50 Rows from Table
                if (mainTable.Rows.Count > 50)
                {
                    mainTable = mainTable.AsEnumerable().Take(50).CopyToDataTable();
                }

                ErrorHandling("LOG ", "MService.asmx", "GetAgenecySummary()-- 3***mainTable Count:: " + mainTable.Rows.Count.ToString(), string.Empty, string.Empty, string.Empty, string.Empty);



                //Getting data
                for (int j = 0; j < mainTable.Rows.Count; j++)
                {
                    string description = Convert.ToString(mainTable.Rows[j]["Description"]);
                    string moduleType = Convert.ToString(mainTable.Rows[j]["MType"]);
                    string shareURL = "";

                    string outerURL = GetConfigSettings(Convert.ToString(mainTable.Rows[j]["PID"]), "Paths", "RootPath");

                    #region Paragraph lines

                    description = description.Replace("<BR>", "<br>");
                    var paras = description.Split(new string[] { "<br>" }, StringSplitOptions.None);
                    string firstPara = "";
                    if (paras.Count() > 0)
                    {
                        for (int k = 0; k < paras.Count(); k++)
                        {
                            firstPara = ReplaceSpecialCharacter(paras[k].ToString());
                            if (firstPara != "")
                            {
                                firstPara = paras[k].ToString();
                                break;
                            }
                        }
                    }
                    else
                    {
                        firstPara = description;
                    }

                    firstPara = ReplaceSpecialCharacter(firstPara);
                    bool IsValid = false;
                    if (firstPara.Length > 120)
                    {
                        for (int a = 100; a < 120; a++)
                        {
                            if (firstPara.Substring(0, a).EndsWith(" "))
                            {
                                description = firstPara.Substring(0, a) + "...";
                                IsValid = true;
                                break;
                            }
                        }

                        if (IsValid == false)
                        {
                            description = firstPara.Substring(0, 100) + " ...";
                        }
                    }
                    else
                    {
                        description = firstPara;
                    }

                    #endregion



                    #region Vertical Logo

                    BusinessBLL objBusinessBLL = new BusinessBLL();
                    var dtProfileDetails = objBusinessBLL.GetProfileDetailsByProfileID(Convert.ToInt32(mainTable.Rows[j]["PID"]));
                    string verticalDomain = objCommonBLL.GetDomainNameByCountry(Convert.ToInt32(dtProfileDetails.Rows[0]["User_ID"]));
                    string VerticalLogo = outerURL + "/images/VerticalLogos/" + verticalDomain + "logo.png";

                    #endregion

                    if (moduleType.ToLower() == "bulletin".ToLower())
                    {
                        shareURL = outerURL + "/OnlineBulletin.aspx?BLID="
                            + EncryptDecrypt.DESEncrypt(Convert.ToString(mainTable.Rows[j]["ID"])).Replace("=", "irhmalli").Replace("+", "irhPASS");
                    }
                    else if (moduleType.ToLower() == "update".ToLower())
                    {
                        shareURL = outerURL + "/OnlineUpdate.aspx?BID="
                            + EncryptDecrypt.DESEncrypt(Convert.ToString(mainTable.Rows[j]["ID"])).Replace("=", "irhmalli").Replace("+", "irhPASS");
                    }
                    else if (moduleType.ToLower() == "event".ToLower())
                    {
                        shareURL = outerURL + "/printevents.aspx?EID="
                            + EncryptDecrypt.DESEncrypt(Convert.ToString(mainTable.Rows[j]["ID"])).Replace("=", "irhmalli").Replace("+", "irhPASS");
                    }


                    var modifyDate = string.Empty;

                    if (Convert.ToString(mainTable.Rows[j]["SentTimeStamp"]) == "")
                    {
                        modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                    }
                    else
                    {
                        modifyDate = Convert.ToDateTime(mainTable.Rows[j]["SentTimeStamp"]).ToString("MM/dd/yyyy hh:mm:ss tt");
                    }

                    result = result + "<Details ID='" + Convert.ToString(mainTable.Rows[j]["ID"]) + "' " +
                                              " Title='" + ReplaceSpecialCharacter(Convert.ToString(mainTable.Rows[j]["Title"])) + "' " +
                                              " Publish_Date='" + Convert.ToString(mainTable.Rows[j]["PublishDate"]) + "' " +
                                              " MType='" + Convert.ToString(mainTable.Rows[j]["MType"]) + "' " +
                                              " Description='" + description + "' " +
                                              " PID='" + Convert.ToString(mainTable.Rows[j]["PID"]) + "' " +
                                              " PName='" + ReplaceSpecialCharacter(Convert.ToString(mainTable.Rows[j]["AgencyName"])) + "' " +
                                              " IsAlternatePhone='" + Convert.ToString(mainTable.Rows[j]["IsCall"]) + "' " +
                                              " IsContactUs='" + Convert.ToString(mainTable.Rows[j]["IsContactUs"]) + "' " +
                                              " EventSDate='" + Convert.ToString(mainTable.Rows[j]["EventStartDate"]) + "' " +
                                              " EventEndDate='" + Convert.ToString(mainTable.Rows[j]["EventEndDate"]) + "' " +
                                              " ShareURL='" + shareURL + "' " +
                                              " SentTimeStamp='" + modifyDate + "' " +
                                              " IsNotification='" + Convert.ToString(mainTable.Rows[j]["IsNotification"]) + "' " +
                                              " TMessage='" + Convert.ToString(mainTable.Rows[j]["TMessage"]) + "' " +
                                              " Status='" + Convert.ToString(mainTable.Rows[j]["Status"]) + "' " +
                                              " VerticalLogo='" + VerticalLogo + "' " +
                                              " />";
                }

                summary = "<AgencySummary>" + result + "</AgencySummary>";
                return summary;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetAgenecySummary()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Turn On/Off Push Notification
        /// </summary>
        /// <param name="pDeviceID">pDeviceID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pAppID">pAppID</param>
        /// <param name="pIsPushNotify">pIsPushNotify</param>
        /// <returns>String</returns>
        public string TurnOn_OffPushNotification(string pDeviceID, int pProfileID, int pAppID, bool pIsPushNotify)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "TurnOn_OffPushNotification()", string.Empty, string.Empty, string.Empty, string.Empty);
                MServiceDAL.TurnOn_OffPushNotification(pDeviceID, pProfileID, pAppID, pIsPushNotify);
                return "SUCEESS";
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "TurnOn_OffPushNotification()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Validate Mobile App Pin
        /// </summary>
        /// <param name="pAppName">pAppName</param>
        /// <param name="pPin">pPin</param>
        /// <returns>String</returns>
        public string ValidateMobileAppPin(string pAppName, string pPin)
        {
            return MServiceDAL.ValidateMobileAppPin(pAppName, pPin);
        }

        /// <summary>
        /// Get On/Off Push Notification
        /// </summary>
        /// <param name="pDeviceID">pDeviceID</param>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pAppID">pAppID</param>
        /// <returns>String</returns>
        public string GetOn_OffPushNotification(string pDeviceID, int pProfileID, int pAppID)
        {
            return MServiceDAL.GetOn_OffPushNotification(pDeviceID, pProfileID, pAppID);
        }

        /// <summary>
        /// Get Branded App ProfileIDs
        /// </summary>
        /// <param name="pAppName">pAppName</param>
        /// <returns>DataTable</returns>
        public DataTable GetBrandedAppProfileIDs(string pAppName)
        {
            return MServiceDAL.GetBrandedAppProfileIDs(pAppName);
        }


        #region ******************** Survey Methods   ****************************
        /// <summary>
        /// Get All Surveys
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pDeviceID">pDeviceID</param>
        /// <param name="pDeviceType">pDeviceType</param>
        /// <param name="pAppID">pAppID</param>
        /// <returns>String</returns>
        public string GetAllSurveys(int pProfileID, string pDeviceID, string pDeviceType, int pAppID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetAllSurveys()", string.Empty, string.Empty, string.Empty, string.Empty);

                string xmlSurveys = string.Empty;
                DataTable dtSurveysList = MServiceDAL.GetActiveSurveys(pProfileID);

                for (int i = 0; i < dtSurveysList.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtSurveysList.Rows[i]["QCount"]) > 0)
                    {
                        DataTable dtCompletedSurvey = MServiceDAL.GetSurveyStatusBySurveyID(Convert.ToInt32(dtSurveysList.Rows[i]["Survey_ID"]), pDeviceID, pDeviceType, pAppID);
                        var surveyStatus = "1";
                        var modifyDate = DateTime.Now.ToShortDateString();
                        if (dtCompletedSurvey.Rows.Count > 0)
                        {
                            surveyStatus = Convert.ToString(dtCompletedSurvey.Rows[0]["SurveyStatus"]);
                            modifyDate = Convert.ToString(dtCompletedSurvey.Rows[0]["Modified_Date"]);
                        }

                        xmlSurveys = xmlSurveys + "<SurveyDetails  SurveyID='" + Convert.ToString(dtSurveysList.Rows[i]["Survey_ID"]) + "' " +
                            " SurveyName='" + ReplaceSpecialCharacter(Convert.ToString(dtSurveysList.Rows[i]["Name"])) + "'" +
                            " Description='" + ReplaceSpecialCharacter(Convert.ToString(dtSurveysList.Rows[i]["Description"])) + "'" +
                            " SurveyType='" + Convert.ToString(dtSurveysList.Rows[i]["Type_Name"]) + "' " +
                            " ThanksMessage='" + ReplaceSpecialCharacter(Convert.ToString(dtSurveysList.Rows[i]["Thanks_Message"])) + "' " +
                            " ExDate='" + Convert.ToString(dtSurveysList.Rows[i]["Expiration_Date"]) + "' " +
                            " SurveyStatus='" + surveyStatus + "' " +
                            " SurveyCompletedDate='" + modifyDate + "' " +
                            "   />";
                    }
                }
                xmlSurveys = "<Surveys>" + xmlSurveys + "</Surveys>";

                return xmlSurveys;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetAllSurveys()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /// <summary>
        /// Get Questions Options By SurveyID
        /// </summary>
        /// <param name="pSID">pSID</param>
        /// <param name="pDeviceID">pDeviceID</param>
        /// <param name="pDeviceType">pDeviceType</param>
        /// <param name="pAppID">pAppID</param>
        /// <returns>String</returns>
        public string GetQuestions_OptionsBySID(int pSID, string pDeviceID, string pDeviceType, int pAppID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetQuestions_OptionsBySID()", string.Empty, string.Empty, string.Empty, string.Empty);
                string xmlQuestion_Answers = string.Empty;

                DataTable dtQuestions = MServiceDAL.GetActiveQuestions(pSID);
                for (int i = 0; i < dtQuestions.Rows.Count; i++)
                {
                    DataTable dtOptions = SurveyDAL.GetQuestionOptionsByQID(Convert.ToInt32(dtQuestions.Rows[i]["Question_ID"]));
                    string xmlOptions = "";
                    for (int j = 0; j < dtOptions.Rows.Count; j++)
                    {
                        xmlOptions = xmlOptions + "<Option ID='" + dtOptions.Rows[j]["Option_ID"] + "' " +
                            " OptionName='" + ReplaceSpecialCharacter(Convert.ToString(dtOptions.Rows[j]["Answer_Option"])) + "' " +
                            " OrderNo='" + Convert.ToString(dtOptions.Rows[j]["Order_No"]) + "' " +
                            "  />";
                    }

                    DataTable dtAnswers = MServiceDAL.GetSurveyAnswers(Convert.ToInt32(dtQuestions.Rows[i]["Question_ID"]), pDeviceID, pDeviceType, pAppID);

                    //
                    ErrorHandling("LOG ", "MServiceBLL.cs", "dtAnswers.Rows.Count()========" + dtAnswers.Rows.Count, string.Empty, string.Empty, string.Empty, string.Empty);

                    string answersStr = "";
                    for (int k = 0; k < dtAnswers.Rows.Count; k++)
                    {
                        answersStr = answersStr + "#yen;" + Convert.ToString(dtAnswers.Rows[k]["Answer"]);
                    }
                    //
                    ErrorHandling("LOG ", "MServiceBLL.cs", "answersStr========" + answersStr, string.Empty, string.Empty, string.Empty, string.Empty);

                    if (answersStr.StartsWith("#yen;"))
                    {
                        answersStr = answersStr.Substring(5);
                    }
                    //
                    ErrorHandling("LOG ", "MServiceBLL.cs", "answersStr========" + answersStr, string.Empty, string.Empty, string.Empty, string.Empty);

                    xmlQuestion_Answers = xmlQuestion_Answers + "<Question QID='" + dtQuestions.Rows[i]["Question_ID"] + "' " +
                        " QName='" + ReplaceSpecialCharacter(Convert.ToString(dtQuestions.Rows[i]["Text"])) + "' " +
                        " QType='" + ReplaceSpecialCharacter(Convert.ToString(dtQuestions.Rows[i]["Type_Name"])) + "' " +
                        " SelectedAnswer='" + ReplaceSpecialCharacter(answersStr) + "' " +
                          " IsRequired='" + Convert.ToBoolean(dtQuestions.Rows[i]["IsRequired"]) + "' " +
                          " RequiredMessage='" + ReplaceSpecialCharacter(Convert.ToString(dtQuestions.Rows[i]["Error_Message"])) + "' " +
                          " AnswersCheckType='" + ReplaceSpecialCharacter(Convert.ToString(dtQuestions.Rows[i]["Answers_CheckType"])) + "' " +
                          " AnswersCheckCount='" + Convert.ToString(dtQuestions.Rows[i]["Answers_CheckCount"]) + "' " +

                        " >" + xmlOptions + "</Question>";
                }

                xmlQuestion_Answers = "<SurveyQuestions>" + xmlQuestion_Answers + "</SurveyQuestions>";
                return xmlQuestion_Answers;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetQuestions_OptionsBySID()", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        /*
        public string InsertSurveyAnswers(string pAnswerString, string pDeviceID, string pDeviceType, int pAppID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "InsertSurveyAnswers()", string.Empty, string.Empty, string.Empty, string.Empty);

                var XMLAnswers = XElement.Parse(pAnswerString, LoadOptions.PreserveWhitespace);
                // Delete If Existed Answers by QID
                foreach (XElement ele in XMLAnswers.Elements())
                {
                    int QID = Convert.ToInt32(ele.Attribute("QID").Value);

                    MServiceDAL.DeleteSurveyAnswers(QID, pDeviceID, pDeviceType, pAppID);
                }
                // Insert Answers by QID
                foreach (XElement ele in XMLAnswers.Elements())
                {
                    int QID = Convert.ToInt32(ele.Attribute("QID").Value); 

                    string optionID = Convert.ToString(ele.Attribute("OptionIDs").Value);
                    string answerText = Convert.ToString(ele.Attribute("AnswerTexts").Value);

                    #region Remove Commas

                    if (optionID.StartsWith(","))
                    {
                        optionID = optionID.Substring(1);
                    }
                    if (optionID.EndsWith(","))
                    {
                        optionID = optionID.Remove(optionID.Length - 1);
                    }
                    if (answerText.StartsWith(","))
                    {
                        answerText = answerText.Substring(1);
                    }
                    if (answerText.EndsWith(","))
                    {
                        answerText = answerText.Remove(answerText.Length - 1);
                    }

                    #endregion

                    var optionIDS = optionID.ToString().Split(',');
                    var answersS = answerText.Split(',');
                    for (int i = 0; i < optionIDS.Count(); i++)
                    {
                        MServiceDAL.InsertSurveyAnswers(QID, Convert.ToInt32(optionIDS[i]), Convert.ToString(answersS[i]), pDeviceID, pDeviceType, pAppID);
                    }
                }

                return "SUCCESS";
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "InsertSurveyAnswers()", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }*/

        /// <summary>
        /// Insert Survey Answers
        /// </summary>
        /// <param name="pDeviceID">pDeviceID</param>
        /// <param name="pDeviceType">pDeviceType</param>
        /// <param name="pAppID">pAppID</param>
        /// <param name="pAnswerTexts">pAnswerTexts</param>
        /// <param name="pOptionIDs">pOptionIDs</param>
        /// <param name="pQID">pQID</param>
        /// <param name="pSurveyID">pSurveyID</param>
        /// <param name="pIsCompleted">pIsCompleted</param>
        /// <returns>String</returns>
        public string InsertSurveyAnswers(string pDeviceID, string pDeviceType, int pAppID, string pAnswerTexts, string pOptionIDs,
            int pQID, int pSurveyID, bool pIsCompleted)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "InsertSurveyAnswers()", string.Empty, string.Empty, string.Empty, string.Empty);

                if (pQID != 0)
                {
                    MServiceDAL.DeleteSurveyAnswers(pQID, pDeviceID, pDeviceType, pAppID);

                    // Insert Answers by QID

                    #region Remove Commas

                    if (pOptionIDs.StartsWith("#yen;"))
                    {
                        pOptionIDs = pOptionIDs.Substring(5);
                    }
                    if (pOptionIDs.EndsWith("#yen;"))
                    {
                        pOptionIDs = pOptionIDs.Remove(pOptionIDs.Length - 5);
                    }
                    if (pAnswerTexts.StartsWith("#yen;"))
                    {
                        pAnswerTexts = pAnswerTexts.Substring(5);
                    }
                    if (pAnswerTexts.EndsWith("#yen;"))
                    {
                        pAnswerTexts = pAnswerTexts.Remove(pAnswerTexts.Length - 5);
                    }

                    #endregion

                    if (pAnswerTexts.Trim() != string.Empty)
                    {
                        var optionIDS = pOptionIDs.ToString().Split(new string[] { "#yen;" }, StringSplitOptions.None);
                        var answersS = pAnswerTexts.ToString().Split(new string[] { "#yen;" }, StringSplitOptions.None);
                        for (int i = 0; i < optionIDS.Count(); i++)
                        {
                            MServiceDAL.InsertSurveyAnswers(pQID, Convert.ToInt32(optionIDS[i]), Convert.ToString(answersS[i]), pDeviceID, pDeviceType, pAppID, pSurveyID);
                        }
                    }
                }

                if (pIsCompleted)
                {
                    // Insert Survey Status from each device ... completed or in progree
                    MServiceDAL.InsertSurveyStatusfromDevice(pSurveyID, pDeviceID, pDeviceType, pAppID, pIsCompleted);
                }
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "InsertSurveyAnswers()", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }


        #endregion
        /// <summary>
        /// Get Web links Categories By PID
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <returns>String</returns>
        public string GetWeblinks_CategoriesByPID(int pProfileID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetWeblinks_CategoriesByPID()", string.Empty, string.Empty, string.Empty, string.Empty);

                string xmlWebLink = string.Empty;
                DataTable dtWebLinks = BusinessDAL.GetWebLinks(Convert.ToInt32(pProfileID));
                for (int i = 0; i < dtWebLinks.Rows.Count; i++)
                {
                    string catID = "0";
                    if (Convert.ToString(dtWebLinks.Rows[i]["Category_ID"]).Trim() != string.Empty)
                    {
                        catID = Convert.ToString(dtWebLinks.Rows[i]["Category_ID"]);
                    }
                    xmlWebLink = xmlWebLink + "<Link Name='" + ReplaceSpecialCharacter(Convert.ToString(dtWebLinks.Rows[i]["Link_Title"])) + "' " +
                    " URL='" + Convert.ToString(dtWebLinks.Rows[i]["Link_Url"]) + "' " +
                    " CategoryID='" + catID + "'  />";
                }

                string xmlWeblinkCategories = string.Empty;
                DataTable dtweblinkCategories = MServiceDAL.GetWeblinksCategories(pProfileID);
                for (int i = 0; i < dtweblinkCategories.Rows.Count; i++)
                {
                    xmlWeblinkCategories = xmlWeblinkCategories + "<Category  WeblinksCatID='" + Convert.ToString(dtweblinkCategories.Rows[i]["WeblinkCategory_ID"]) + "' " +
                            " WeblinksCatName='" + ReplaceSpecialCharacter(Convert.ToString(dtweblinkCategories.Rows[i]["Category_Name"])) + "'" +
                            "   />";
                }

                xmlWeblinkCategories = "<WeblinksCats>" + xmlWebLink + xmlWeblinkCategories + "</WeblinksCats>";

                return xmlWeblinkCategories;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetWeblinks_CategoriesByPID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }


        /*
        public string GetWeblinksCategories(int pProfileID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetWeblinksCategories()", string.Empty, string.Empty, string.Empty, string.Empty);

                string xmlWeblinkCategories = string.Empty;
                DataTable dtweblinkCategories = MServiceDAL.GetWeblinksCategories(pProfileID);
                for (int i = 0; i < dtweblinkCategories.Rows.Count; i++)
                {
                    xmlWeblinkCategories = xmlWeblinkCategories + "<Category  WeblinksCatID='" + Convert.ToString(dtweblinkCategories.Rows[i]["WeblinkCategory_ID"]) + "' " +
                            " WeblinksCatName='" + ReplaceSpecialCharacter(Convert.ToString(dtweblinkCategories.Rows[i]["Category_Name"])) + "'" +

                            "   />";
                }

                xmlWeblinkCategories = "<WeblinksCats>" + xmlWeblinkCategories + "</WeblinksCats>";

                return xmlWeblinkCategories;
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetWeblinksCategories()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        public string GetWeblinksByCategoryID(int pWeblinkCatID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetWeblinksByCategoryID()", string.Empty, string.Empty, string.Empty, string.Empty);

                string xmlWebLink = string.Empty;
                DataTable dtWebLinks = MServiceDAL.GetWeblinksByCatID(Convert.ToInt32(pWeblinkCatID));

                for (int i = 0; i < dtWebLinks.Rows.Count; i++)
                {
                    xmlWebLink = xmlWebLink + "<Link Name='" + ReplaceSpecialCharacter(Convert.ToString(dtWebLinks.Rows[i]["Link_Title"])) + "' URL='" + Convert.ToString(dtWebLinks.Rows[i]["Link_Url"]) + "' />";
                }

                xmlWebLink = "<WebLinks>" + xmlWebLink + "</WebLinks>";
                return xmlWebLink;

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetWeblinksByCategoryID()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }

        */

        // BUES Means:: Bulletins, Updates, Events, Surveys
        /// <summary>
        /// Get Push Notify Details of Bulletins,Updates,Events and Survey
        /// </summary>
        /// <param name="pProfileID">pProfileID</param>
        /// <param name="pTypeID">pTypeID</param>
        /// <param name="pTypeName">pTypeName</param>
        /// <param name="pDeviceID">pDeviceID</param>
        /// <param name="pAppID">pAppID</param>
        /// <returns>String</returns>
        public string GetPushNotifyDetails_BUES(int pProfileID, int pTypeID, string pTypeName, string pDeviceID, int pAppID)
        {
            try
            {
                ErrorHandling("LOG ", "MServiceBLL.cs", "GetPushNotifyDetails_BUES()", string.Empty, string.Empty, string.Empty, string.Empty);

                string result = string.Empty;
                DataTable mainTable = new DataTable("main");
                mainTable = MServiceDAL.GetPushNotifyDetails_BUES(pProfileID, pTypeID, pTypeName, pDeviceID, pAppID);

                //Getting data
                for (int j = 0; j < mainTable.Rows.Count; j++)
                {
                    string description = Convert.ToString(mainTable.Rows[j]["Description"]);
                    string moduleType = Convert.ToString(mainTable.Rows[j]["MType"]);
                    string shareURL = "";

                    string outerURL = GetConfigSettings(Convert.ToString(mainTable.Rows[j]["PID"]), "Paths", "RootPath");

                    #region Paragraph lines

                    description = description.Replace("<BR>", "<br>");
                    var paras = description.Split(new string[] { "<br>" }, StringSplitOptions.None);
                    string firstPara = "";
                    if (paras.Count() > 0)
                    {
                        for (int k = 0; k < paras.Count(); k++)
                        {
                            firstPara = ReplaceSpecialCharacter(paras[k].ToString());
                            if (firstPara != "")
                            {
                                firstPara = paras[k].ToString();
                                break;
                            }
                        }
                    }
                    else
                    {
                        firstPara = description;
                    }

                    firstPara = ReplaceSpecialCharacter(firstPara);
                    bool IsValid = false;
                    if (firstPara.Length > 120)
                    {
                        for (int a = 100; a < 120; a++)
                        {
                            if (firstPara.Substring(0, a).EndsWith(" "))
                            {
                                description = firstPara.Substring(0, a) + "...";
                                IsValid = true;
                                break;
                            }
                        }

                        if (IsValid == false)
                        {
                            description = firstPara.Substring(0, 100) + " ...";
                        }
                    }
                    else
                    {
                        description = firstPara;
                    }

                    #endregion


                    #region Vertical Logo

                    BusinessBLL objBusinessBLL = new BusinessBLL();
                    var dtProfileDetails = objBusinessBLL.GetProfileDetailsByProfileID(Convert.ToInt32(mainTable.Rows[j]["PID"]));
                    string verticalDomain = objCommonBLL.GetDomainNameByCountry(Convert.ToInt32(dtProfileDetails.Rows[0]["User_ID"]));
                    string VerticalLogo = outerURL + "/images/VerticalLogos/" + verticalDomain + "logo.png";

                    #endregion

                    if (moduleType.ToLower() == "bulletin".ToLower())
                    {
                        shareURL = outerURL + "/OnlineBulletin.aspx?BLID="
                            + EncryptDecrypt.DESEncrypt(Convert.ToString(mainTable.Rows[j]["ID"])).Replace("=", "irhmalli").Replace("+", "irhPASS");
                    }
                    else if (moduleType.ToLower() == "update".ToLower())
                    {
                        shareURL = outerURL + "/OnlineUpdate.aspx?BID="
                            + EncryptDecrypt.DESEncrypt(Convert.ToString(mainTable.Rows[j]["ID"])).Replace("=", "irhmalli").Replace("+", "irhPASS");
                    }
                    else if (moduleType.ToLower() == "event".ToLower())
                    {
                        shareURL = outerURL + "/printevents.aspx?EID="
                            + EncryptDecrypt.DESEncrypt(Convert.ToString(mainTable.Rows[j]["ID"])).Replace("=", "irhmalli").Replace("+", "irhPASS");
                    }


                    var modifyDate = string.Empty;

                    if (Convert.ToString(mainTable.Rows[j]["SentTimeStamp"]) == "")
                    {
                        modifyDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                    }
                    else
                    {
                        modifyDate = Convert.ToDateTime(mainTable.Rows[j]["SentTimeStamp"]).ToString("MM/dd/yyyy hh:mm:ss tt");
                    }

                    result = result + "<Details ID='" + Convert.ToString(mainTable.Rows[j]["ID"]) + "' " +
                                              " Title='" + ReplaceSpecialCharacter(Convert.ToString(mainTable.Rows[j]["Title"])) + "' " +
                                              " Publish_Date='" + Convert.ToString(mainTable.Rows[j]["PublishDate"]) + "' " +
                                              " MType='" + Convert.ToString(mainTable.Rows[j]["MType"]) + "' " +
                                              " Description='" + description + "' " +
                                              " PID='" + Convert.ToString(mainTable.Rows[j]["PID"]) + "' " +
                                              " PName='" + ReplaceSpecialCharacter(Convert.ToString(mainTable.Rows[j]["AgencyName"])) + "' " +
                                              " IsAlternatePhone='" + Convert.ToString(mainTable.Rows[j]["IsCall"]) + "' " +
                                              " IsContactUs='" + Convert.ToString(mainTable.Rows[j]["IsContactUs"]) + "' " +
                                              " EventSDate='" + Convert.ToString(mainTable.Rows[j]["EventStartDate"]) + "' " +
                                              " EventEndDate='" + Convert.ToString(mainTable.Rows[j]["EventEndDate"]) + "' " +
                                              " ShareURL='" + shareURL + "' " +
                                              " SentTimeStamp='" + modifyDate + "' " +
                                              " IsNotification='" + Convert.ToString(mainTable.Rows[j]["IsNotification"]) + "' " +
                                              " TMessage='" + Convert.ToString(mainTable.Rows[j]["TMessage"]) + "' " +
                                              " Status='" + Convert.ToString(mainTable.Rows[j]["Status"]) + "' " +
                                              " VerticalLogo='" + VerticalLogo + "' " +
                                              " />";
                }

                return "<PushNotifyDetails>" + result + "</PushNotifyDetails>";

            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR ", "MServiceBLL.cs", "GetPushNotifyDetails_BUES()", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ErrorMessage;
            }
        }
        /// <summary>
        /// Get Push Type Tab Name
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="pushType">pushType</param>
        /// <param name="pushID">pushID</param>
        /// <returns>String</returns>
        public string GetPushTypeTabName(int profileID, string pushType, int pushID)
        {
            return MServiceDAL.GetPushTypeTabName(profileID, pushType, pushID);
        }
    }

    /// <summary>
    /// Branded App Type
    /// </summary>
    public enum BrandedAppType : int
    {
        USPD = 1,
        PPD = 2,
    }

    /// <summary>
    /// Calendar
    /// </summary>
    public class Calendar
    {
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string EventTitle { get; set; }
        public string Description { get; set; }
    }


}
