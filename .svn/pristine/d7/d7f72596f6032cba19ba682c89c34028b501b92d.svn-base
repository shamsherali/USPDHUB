using System;
using System.Linq;
using System.Data;
using System.Configuration;
using USPDHUBDAL;
using System.Xml.Linq;

namespace USPDHUBBLL
{
    public class IRHMServiceBLL
    {
        /// <summary>
        /// Getting all categories
        /// </summary>
        /// <returns>return categories as xml string</returns>
        public string GetAllCategories()
        {
            string xmlcategories = string.Empty;
            DataTable dtCategories = IRHMServiceDAL.GetAllCategories();
            for (int i = 0; i < dtCategories.Rows.Count; i++)
            {
                string cateName = Convert.ToString(dtCategories.Rows[i]["Industry_name"]);
                cateName = ReplaceSpecialCharacter(cateName);

                xmlcategories = xmlcategories + "<Cat ID='" + Convert.ToString(dtCategories.Rows[i]["Industry_ID"]) + "' Name='" + cateName + "' />";
            }
            xmlcategories = "<Categories>" + xmlcategories + "</Categories>";
            return xmlcategories;
        }

        /// <summary>
        /// Search results getting business details based on 
        /// Business keyword OR Category type OR Latitide,Longitude,Radius
        /// </summary>
        /// <param name="pKeyword">param is pKeyword</param>
        /// <param name="pCatType">param is pCatType</param>
        /// <param name="platitude1">param is platitude1</param>
        /// <param name="plongitude1">param is plongitude1</param>
        /// <param name="pRadius">param is pRadius</param>
        /// <returns>return business details as XML string</returns>
        public string GetSearchResult(string pKeyword, string pCatType, string platitude1, string plongitude1, string pRadius)
        {
            string xmlSearchResult = string.Empty;
            DataTable dtSearchResult = IRHMServiceDAL.GetSearchResult(pKeyword, pCatType, platitude1, plongitude1, pRadius);


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

                xmlSearchResult = xmlSearchResult + "<Prof PID='" + Convert.ToString(dtSearchResult.Rows[i]["Profile_ID"]) + "'" +
                    " UID='" + Convert.ToString(dtSearchResult.Rows[i]["User_ID"]) + "'" +
                    " PName='" + ReplaceSpecialCharacter(Convert.ToString(dtSearchResult.Rows[i]["Profile_name"])) + "'" +
                    " BName='" + ReplaceSpecialCharacter(Convert.ToString(dtSearchResult.Rows[i]["Profile_displayname"])) + "'" +
                    " PLogo='" + ConfigurationManager.AppSettings.Get("OuterRootURL") + "/Upload/Logos/" + Convert.ToString(dtSearchResult.Rows[i]["Profile_ID"]) + "/" + Convert.ToString(dtSearchResult.Rows[i]["Profile_ID"]) + "_thumb.jpg'" +
                    " Address='" + ReplaceSpecialCharacter(address) + "'" +
                    " MobileNumber='" + Convert.ToString(dtSearchResult.Rows[i]["Mobile_Number"]) + "'" +
                    " IsContact='" + Convert.ToString(dtSearchResult.Rows[i]["Contact_Public_Flag"]) + "'" +
                    " EmailID='" + Convert.ToString(dtSearchResult.Rows[i]["User_email"]) + "'" +
                    " City='" + ReplaceSpecialCharacter(Convert.ToString(dtSearchResult.Rows[i]["Profile_City"])) + "'" +
                    " State='" + Convert.ToString(dtSearchResult.Rows[i]["Profile_State"]) + "'" +
                    " Zipcode='" + Convert.ToString(dtSearchResult.Rows[i]["Profile_Zipcode"]) + "'" +
                    " Country='" + Convert.ToString(dtSearchResult.Rows[i]["Profile_County"]) + "'" +
                      " Latitude='" + Convert.ToString(dtSearchResult.Rows[i]["latitude1"]) + "'" +
                      " Longitude='" + Convert.ToString(dtSearchResult.Rows[i]["longitude1"]) + "'" +
                      " " + HomeTabSettings(Convert.ToInt32(dtSearchResult.Rows[i]["Profile_ID"])) + " " +
                      " " + GetSelectedToolsSettings(Convert.ToInt32(dtSearchResult.Rows[i]["User_ID"]), false) + " " + "/>";

            }
            xmlSearchResult = "<BPDetails>" + xmlSearchResult + "</BPDetails>";

            return xmlSearchResult;
        }

        /// <summary>
        /// Home Tabs details like Home description  & image
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return home details as string</returns>
        public string HomeTabDetails(string pProfileID)
        {
            string description = "";

            DataTable dt = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
            if (dt.Rows.Count > 0)
            {
                string replaceText = @"<script language=""javascript"" type=""text/javascript"" src=""/B1D671CF-E532-4481-99AA-19F420D90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";
                string replaceText1 = @"<script language=javascript type=text/javascript src=""/b1d671cf-e532-4481-99aa-19f420d90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";

                description = Convert.ToString(dt.Rows[0]["Profile_Description"]).Replace(replaceText, string.Empty);
                description = description.Replace(replaceText1, string.Empty);
            }

            return description;
        }

        /// <summary>
        /// Getting About Us Details by Profile ID
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return about us details as XML string</returns>
        public string GetAboutUsDetails(string pProfileID)
        {
            string xmlAboutUs = string.Empty;
            DataTable dt = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
            if (dt.Rows.Count > 0)
            {
                string replaceText = @"<script language=""javascript"" type=""text/javascript"" src=""/B1D671CF-E532-4481-99AA-19F420D90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";
                string replaceText1 = @"<script language=javascript type=text/javascript src=""/b1d671cf-e532-4481-99aa-19f420d90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";


                string descrition = Convert.ToString(dt.Rows[0]["Profile_Aboutus"]).Replace(replaceText, string.Empty);
                descrition = descrition.Replace(replaceText1, string.Empty);

                xmlAboutUs = descrition;
            }

            return xmlAboutUs;
        }

        /// <summary>
        /// Getting User Buy Tools & Business Tools Names & Icons Settings by Profile ID
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <param name="pIconSize">param is pIconSize</param>
        /// <returns>return tools as XML string</returns>
        public string GetSelectedTools(string pProfileID, string pIconSize)
        {
            string xmlSelectedTools = string.Empty;
            string address = string.Empty;
            bool showBulletins = false;
            ////Getting Update profile details by UserID
            //DataTable dtProfileDetails = LT.InReachHub.DAL.IRHMServiceDAL.GetProfileDetails(Convert.ToInt32(pUserID));
            // 2 Means getting details by Profile ID
            DataTable dtProfileDetails = IRHMServiceDAL.GetProfiledetailsByBCode(string.Empty, Convert.ToInt32(pProfileID), "2", "0.0", "0.0", "0");
            if (Convert.ToString(dtProfileDetails.Rows[0]["Profile_StreetAddress2"]) == string.Empty)
            {
                address = Convert.ToString(dtProfileDetails.Rows[0]["Profile_StreetAddress1"]);
            }
            else
            {
                address = Convert.ToString(dtProfileDetails.Rows[0]["Profile_StreetAddress1"]) + ", " + Convert.ToString(dtProfileDetails.Rows[0]["Profile_StreetAddress2"]);
            }
            if (!string.IsNullOrEmpty(dtProfileDetails.Rows[0]["Package_Number"].ToString()))
            {
                if (Convert.ToInt32(dtProfileDetails.Rows[0]["Package_Number"].ToString()) > 4)
                {
                    showBulletins = true;
                }
            }
            string profileSettings = " P_PName='" + ReplaceSpecialCharacter(Convert.ToString(dtProfileDetails.Rows[0]["Profile_name"])) + "'" +
                       " P_BName='" + ReplaceSpecialCharacter(Convert.ToString(dtProfileDetails.Rows[0]["Profile_displayname"])) + "'" +
                       " P_Address='" + address + "'" +
                       " P_MobileNumber='" + Convert.ToString(dtProfileDetails.Rows[0]["Mobile_Number"]) + "'" +
                       " P_City='" + Convert.ToString(dtProfileDetails.Rows[0]["Profile_City"]) + "'" +
                       " P_State='" + Convert.ToString(dtProfileDetails.Rows[0]["Profile_State"]) + "'" +
                       " P_Zipcode='" + Convert.ToString(dtProfileDetails.Rows[0]["Profile_Zipcode"]) + "'" +
                       " P_Country='" + Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]) + "'" +
                         " P_Latitude='" + Convert.ToString(dtProfileDetails.Rows[0]["latitude1"]) + "'" +
                         " P_Longitude='" + Convert.ToString(dtProfileDetails.Rows[0]["longitude1"]) + "'" +
                         " P_AlternatePhone='" + Convert.ToString(dtProfileDetails.Rows[0]["Alternate_Phone"]) + "'" +
                         " " + HomeTabSettings(Convert.ToInt32(dtProfileDetails.Rows[0]["Profile_ID"])) + " ";

            var toolsSettings = GetSelectedToolsSettings(Convert.ToInt32(dtProfileDetails.Rows[0]["User_ID"]), showBulletins);
            var profileTabsName = GetProfileTabsNames(Convert.ToInt32(dtProfileDetails.Rows[0]["Profile_ID"]), pIconSize, toolsSettings, showBulletins);
            xmlSelectedTools = "<SubTools><Tools " + toolsSettings + profileSettings + " />" + profileTabsName + "</SubTools>";

            return xmlSelectedTools;
        }

        /// <summary>
        /// Getting Active & Published Updates by Profile ID
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return updates details as XML string</returns>
        public string GetAllUpdates(string pProfileID)
        {
            string xmlUpdates = string.Empty;
            DataTable dtUpdates = BusinessUpdatesDAL.GetActiveBusinessUpdates(Convert.ToInt32(pProfileID));

            string replaceText = @"<script language=""javascript"" type=""text/javascript"" src=""/B1D671CF-E532-4481-99AA-19F420D90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";
            string replaceText1 = @"<script language=javascript type=text/javascript src=""/b1d671cf-e532-4481-99aa-19f420d90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";

            for (int i = 0; i < dtUpdates.Rows.Count; i++)
            {
                string descrition = Convert.ToString(dtUpdates.Rows[i]["UpdatedText"]).Replace(replaceText, string.Empty);
                descrition = descrition.Replace(replaceText1, string.Empty);
                //REMOVE ALL HTML TAGS 

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
                if (firstPara.Length > 120)
                {
                    for (int j = 100; j < 120; j++)
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
                        descrition = firstPara.Substring(0, 100) + " ...";
                    }
                }
                else
                {
                    descrition = firstPara;
                }

                #endregion
                //descrition = ReplaceSpecialCharacter(descrition);

                string updateUrl = System.Configuration.ConfigurationManager.AppSettings.Get("OuterRootURL") + "/OnlineBusinessUpdate.aspx?BID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(dtUpdates.Rows[i]["UpdateId"])).Replace("=", "irhmalli").Replace("+", "irhPASS");

                xmlUpdates = xmlUpdates + "<Updates ID='" + Convert.ToString(dtUpdates.Rows[i]["UpdateId"]) + "' " +
                    " Title='" + ReplaceSpecialCharacter(Convert.ToString(dtUpdates.Rows[i]["UpdateTitle"])) + "'" +
                    " Description='" + descrition + "'" +
                    " Date='" + Convert.ToString(dtUpdates.Rows[i]["UpdateTime"]) + "' " +
                    " UpdateURL='" + updateUrl + "' />";
            }
            xmlUpdates = "<BUpdates>" + xmlUpdates + "</BUpdates>";

            return xmlUpdates;
        }

        /// <summary>
        /// Getting Update Description by Update ID
        /// </summary>
        /// <param name="pUpdateID">param is pUpdatedID</param>
        /// <returns>return updatedetails as string</returns>
        public string GetUpdateDetaisByID(string pUpdateID)
        {
            string updateDetails = string.Empty;
            DataTable dtUpdateDetails = BusinessUpdatesDAL.UpdateBusinessUpdateDetails(Convert.ToInt32(pUpdateID));

            string replaceText = @"<script language=""javascript"" type=""text/javascript"" src=""/B1D671CF-E532-4481-99AA-19F420D90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";
            string replaceText1 = @"<script language=javascript type=text/javascript src=""/b1d671cf-e532-4481-99aa-19f420d90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";

            updateDetails = Convert.ToString(dtUpdateDetails.Rows[0]["UpdatedText"]).Replace(replaceText, string.Empty);
            updateDetails = updateDetails.Replace(replaceText1, string.Empty);

            return updateDetails;
        }

        /// <summary>
        /// Getting All Photos by Profile ID
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return photo as XML string</returns>
        public string GetAllPhotosByProfileID(string pProfileID)
        {
            string xmlPhotos = string.Empty;
            DataTable dtPhotos = BusinessDAL.GetProfilePhotosByProfileID(Convert.ToInt32(pProfileID));

            for (int i = 0; i < dtPhotos.Rows.Count; i++)
            {
                xmlPhotos = xmlPhotos + "<Photo ID='" + Convert.ToString(dtPhotos.Rows[i]["Profile_Photo_ID"]) + "'" +
                   " PNo='" + Convert.ToString(dtPhotos.Rows[i]["Photo_Num"]) + "'" +
                   " POrder='" + Convert.ToString(dtPhotos.Rows[i]["Image_OrderNo"]) + "'" +
                   " Path='" + ConfigurationManager.AppSettings.Get("OuterRootURL") + "/Upload/Photos/" + Convert.ToString(pProfileID) + "/" + Convert.ToString(dtPhotos.Rows[i]["Photo_image_path"]) + "'" +
                   " Caption='" + ReplaceSpecialCharacter(Convert.ToString(dtPhotos.Rows[i]["Photo_Desc"])) + "'   />";
            }

            xmlPhotos = "<Album>" + xmlPhotos + "</Album>";
            return xmlPhotos;
        }

        /// <summary>
        /// Getting All Active & Published Events by Profile ID and Month
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <param name="pDateTime">param is pDateTime</param>
        /// <returns>return events as XML string</returns>
        public string GetAllEvents(string pProfileID, string pDateTime)
        {
            string xmlEvents = string.Empty;

            DataTable dtEvents = EventCalendarDAL.GetAllEventsByProfileIdandSelectedMonth(Convert.ToInt32(pProfileID), pDateTime);

            string replaceText = @"<script language=""javascript"" type=""text/javascript"" src=""/B1D671CF-E532-4481-99AA-19F420D90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";
            string replaceText1 = @"<script language=javascript type=text/javascript src=""/b1d671cf-e532-4481-99aa-19f420d90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";

            for (int i = 0; i < dtEvents.Rows.Count; i++)
            {
                string descrition = Convert.ToString(dtEvents.Rows[i]["EventDesc"]).Replace(replaceText, string.Empty);
                descrition = descrition.Replace(replaceText1, string.Empty);


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
                if (firstPara.Length > 120)
                {
                    for (int j = 100; j < 120; j++)
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
                        descrition = firstPara.Substring(0, 100) + " ...";
                    }
                }
                else
                {
                    descrition = firstPara;
                }

                #endregion

                string eventUrl = System.Configuration.ConfigurationManager.AppSettings.Get("OuterRootURL") + "/ProfileIframes/printevents.aspx?EID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(dtEvents.Rows[i]["EventId"])).Replace("=", "irhmalli").Replace("+", "irhPASS");
                xmlEvents = xmlEvents + "<Event ID='" + Convert.ToString(dtEvents.Rows[i]["EventId"]) + "' " +
                    " Title='" + ReplaceSpecialCharacter(Convert.ToString(dtEvents.Rows[i]["EventTitle"])) + "'" +
                    " Description='" + descrition + "'" +
                    " SDate='" + Convert.ToString(dtEvents.Rows[i]["EventStartDate"]) + "'" +
                    " EDate='" + Convert.ToString(dtEvents.Rows[i]["EventEndDate"]) + "'" +
                    " EventURL='" + eventUrl + "' />";
            }

            xmlEvents = "<BEvents>" + xmlEvents + "</BEvents>";

            return xmlEvents;
        }

        /// <summary>
        /// Getting Event Description by Event ID
        /// </summary>
        /// <param name="pEventID">param is pEventID</param>
        /// <returns>return event details as string</returns>
        public string GetEventDetailsByID(string pEventID)
        {
            string xmlEventDetails = string.Empty;
            DataTable dtEventDetails = EventCalendarDAL.GetCalendarEventDetails(Convert.ToInt32(pEventID));

            string replaceText = @"<script language=""javascript"" type=""text/javascript"" src=""/B1D671CF-E532-4481-99AA-19F420D90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";
            string replaceText1 = @"<script language=javascript type=text/javascript src=""/b1d671cf-e532-4481-99aa-19f420d90332/netdefender/hui/ndhui.js?0=0&amp;0=0&amp;0=0""></script>";

            if (dtEventDetails.Rows.Count > 0)
            {
                xmlEventDetails = Convert.ToString(dtEventDetails.Rows[0]["EventDesc"]).Replace(replaceText, string.Empty);
                xmlEventDetails = xmlEventDetails.Replace(replaceText1, string.Empty);
            }
            return xmlEventDetails;
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
            string contactEmailID, string pProfileID, string pUserID, string pSourceType, string pPhotoName, double pLatitude, double pLongitude, string pAddress)
        {

            //Sending email to Business User
            string message = string.Empty;
            UtilitiesBLL utlObj = new UtilitiesBLL();

            string emailmessage = "<html><head>";
            emailmessage = emailmessage + "<link href=" + System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath") + "/css/wowzzy_general.css rel='stylesheet' type='text/css' />";
            emailmessage = emailmessage + "</head><body><table width='100%' border='0' align='center' style='padding:10px;'>" +
             "   <tr><td>User name: " + pUserName + "</td></tr>" +
             "   <tr><td>Phone number: " + mobileNumber + "</td></tr>" +
               "   <tr><td>Email ID: " + contactEmailID + "</td></tr>" +
                "   <tr><td></br></td></tr>" +
            "<tr><td>";
            emailmessage = emailmessage + pBody + "</td></tr></table></body></html>";

            string mobilemessage = string.Empty;
            mobilemessage = pUserName + "|" + mobileNumber + "|" + contactEmailID + "|" + pBody;

            IRHMServiceDAL.ManageMessage(Convert.ToInt32(pProfileID), 2, Convert.ToInt32(pUserID), pSubject, mobilemessage, 0, true, 0,
                Convert.ToInt32(pUserID), 1, pSourceType, pPhotoName, pLatitude, pLongitude, pAddress);


            string fromEmailsupport = ConfigurationManager.AppSettings.Get("Emailinfo1");
           
            return message;
        }
        /*
        public string RedeemCoupon(string printdate, int couponID, string pIPAddress)
        {
            DataTable dtcoupons = new DataTable();
            Coupons coupns = new Coupons();
            dtcoupons = coupns.GetCouponDetailsByCouponID(couponID);
            string errorMSG = string.Empty;
            int CouponPrintstatus = 0;
            int MaxAllowed = 0;

            string xmlMessage = string.Empty;

            int printCouponCount = 0;

            if (dtcoupons.Rows.Count == 1)
            {
                errorMSG = string.Empty;
                MaxAllowed = int.Parse(dtcoupons.Rows[0]["Max_Allowed"].ToString());

                //coupns.InsertCouponUsage(0, pIPAddress, 0, couponID, printdate, true);
                errorMSG = "Success";

                
                CouponPrintstatus = coupns.CheckCouponPrintStatus(pIPAddress, couponID);

                if (CouponPrintstatus < MaxAllowed)
                {
                    errorMSG = string.Empty;
                    //string URL = System.Configuration.ConfigurationManager.AppSettings.Get("OuterRootURL") + "/Coupons/MyAccount/PrintPreview.aspx?CID=" + couponID.ToString() + "&PID=" + ProfileID.ToString();
                    // ScriptManager.RegisterClientScriptBlock(lblerrormesage, this.GetType(), "Print", "window.open('" + URL + "');", true);

                    coupns.InsertCouponUsage(0, pIPAddress, 0, couponID, printdate, true);
                    errorMSG = "Success";

                    printCouponCount = MaxAllowed - coupns.GetPrintCoupons(couponID).Rows.Count;

                }

                if (CouponPrintstatus >= MaxAllowed)
                {
                    errorMSG = "We are sorry but this coupon has already exceeded the maximum print limit.";
                }
                 
            }

            xmlMessage = "<result msg='" + errorMSG + "'  />";

            return xmlMessage;
        }
*/

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

            DataTable dtSearchResult = IRHMServiceDAL.MapviewDirection(platitude1, plongitude1, pRadius);


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

                result = result + "<Prof PID='" + Convert.ToString(dtSearchResult.Rows[i]["Profile_ID"]) + "'" +
                    " UID='" + Convert.ToString(dtSearchResult.Rows[i]["User_ID"]) + "'" +
                    " PName='" + ReplaceSpecialCharacter(Convert.ToString(dtSearchResult.Rows[i]["Profile_name"])) + "'" +
                    " BName='" + ReplaceSpecialCharacter(Convert.ToString(dtSearchResult.Rows[i]["Profile_displayname"])) + "'" +
                    " PLogo='" + ConfigurationManager.AppSettings.Get("OuterRootURL") + "/Upload/Logos/" + Convert.ToString(dtSearchResult.Rows[i]["Profile_ID"]) + "/" + Convert.ToString(dtSearchResult.Rows[i]["Profile_ID"]) + "_thumb.jpg'" +
                     " MobileNumber='" + Convert.ToString(dtSearchResult.Rows[i]["Mobile_Number"]) + "'" +

                    " EmailID='" + Convert.ToString(dtSearchResult.Rows[i]["Username"]) + "'" +
                    " Address='" + ReplaceSpecialCharacter(address) + "'" +
                    " Latitude='" + Convert.ToString(dtSearchResult.Rows[i]["latitude1"]) + "'" +
                      " Longitude='" + Convert.ToString(dtSearchResult.Rows[i]["longitude1"]) + "'" +
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
            string xmlSocialMedia = string.Empty;

            DataTable dtpdesc = BusinessDAL.Getprofiledescription(Convert.ToInt32(pProfileID));
            if (dtpdesc.Rows.Count > 0)
            {
                xmlSocialMedia = xmlSocialMedia + "<Links FBProfileURL='" + Convert.ToString(dtpdesc.Rows[0]["Facebook_Link"]) + "'" +
                  " FBFanPageURL='" + Convert.ToString(dtpdesc.Rows[0]["Facebook_Fanpage"]) + "'" +
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

        #region *******************   Inside methods private method   *************************

        /// <summary>
        /// Replace special characters.
        /// </summary>
        /// <param name="inputString">param is inputString</param>
        /// <returns></returns>
        private string ReplaceSpecialCharacter(string inputString)
        {
            inputString = inputString.Replace("<A href=\"http://tr\" target=_blank></A>&nbsp;", "");
            inputString = System.Text.RegularExpressions.Regex.Replace(inputString, "<[^>]*>", string.Empty);

            inputString = inputString.Replace("'", " ");

            if (!inputString.Contains("&amp;"))
            {
                inputString = inputString.Replace("&", "&amp;");
                inputString = inputString.Replace("&amp;amp;", "&amp;");
                inputString = inputString.Replace("&amp;yen;", "&yen;");
            }

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
        private string GetProfileTabsNames(int pProfileID, string pIconSize, string pToolsSettings, bool showBulletins)
        {
            string profileTabsNames = string.Empty;
            BusinessBLL busobj = new BusinessBLL();


            string homeTab = "Home";
            string aboutTab = "About Us";
            string mediasTab = "Media";
            string updatesTab = "Updates";
            string couponsTab = "Coupons";
            string eventsTab = "Events";
            string bulletinTab = "Bulletins";
            string webLinksTab = "Web Links";
            string socialTab = "Social";

            string homeTabIcon = "Home";
            string aboutTabIcon = "AboutUs";
            string mediasTabIcon = "Media";
            string updatesTabIcon = "Updates";
            string couponsTabIcon = "Coupons";
            string eventsTabIcon = "Events";
            string bulletinsTabIcon = "Bulletins";
            string webLinkTabIcon = "WebLinks";
            string socialTabIcon = "Social";

            //DataTable dtProfileTabs = busobj.GetProfileTabsByProfileID(pProfileID);
            DataTable dtProfileTabs = busobj.GetManageButtonsByProfileID(pProfileID);

            if (dtProfileTabs.Rows.Count > 0)
            {
                DataRow[] drHome = dtProfileTabs.Select("Tab_ID='Page1'");
                if (drHome.Length > 0)
                {
                    homeTab = drHome[0]["Tab_Name"].ToString();
                    homeTabIcon = drHome[0]["Image_Name"].ToString();
                }
                DataRow[] drAboutus = dtProfileTabs.Select("Tab_ID='Page2'");
                if (drAboutus.Length > 0)
                {
                    aboutTab = drAboutus[0]["Tab_Name"].ToString();
                    aboutTabIcon = drAboutus[0]["Image_Name"].ToString();
                }
                DataRow[] drMedia = dtProfileTabs.Select("Tab_ID='Page3'");
                if (drMedia.Length > 0)
                {
                    mediasTab = drMedia[0]["Tab_Name"].ToString();
                    mediasTabIcon = drMedia[0]["Image_Name"].ToString();
                }
                DataRow[] drUpdates = dtProfileTabs.Select("Tab_ID='Page4'");
                if (drUpdates.Length > 0)
                {
                    updatesTab = drUpdates[0]["Tab_Name"].ToString();
                    updatesTabIcon = drUpdates[0]["Image_Name"].ToString();
                }
                DataRow[] drCoupons = dtProfileTabs.Select("Tab_ID='Page5'");
                if (drCoupons.Length > 0)
                {
                    couponsTab = drCoupons[0]["Tab_Name"].ToString();
                    couponsTabIcon = drCoupons[0]["Image_Name"].ToString();
                }
                DataRow[] drEvents = dtProfileTabs.Select("Tab_ID='Page6'");
                if (drEvents.Length > 0)
                {
                    eventsTab = drEvents[0]["Tab_Name"].ToString();
                    eventsTabIcon = drEvents[0]["Image_Name"].ToString();
                }
                DataRow[] drBulletins = dtProfileTabs.Select("Tab_ID='Page7'");
                if (drBulletins.Length > 0)
                {
                    bulletinTab = drBulletins[0]["Tab_Name"].ToString();
                    bulletinsTabIcon = drBulletins[0]["Image_Name"].ToString();
                }
                DataRow[] drWebLinks = dtProfileTabs.Select("Tab_ID='Page8'");
                if (drWebLinks.Length > 0)
                {
                    webLinksTab = drWebLinks[0]["Tab_Name"].ToString();
                    webLinkTabIcon = drWebLinks[0]["Image_Name"].ToString();
                }
            }

            string rootUrl = ConfigurationManager.AppSettings.Get("OuterRootURL") + "/Upload/ProfileTabIcons/" + pIconSize;

            homeTabIcon = rootUrl + "/" + homeTabIcon + "_n_" + pIconSize + ".png";
            aboutTabIcon = rootUrl + "/" + aboutTabIcon + "_n_" + pIconSize + ".png";
            mediasTabIcon = rootUrl + "/" + mediasTabIcon + "_n_" + pIconSize + ".png";
            updatesTabIcon = rootUrl + "/" + updatesTabIcon + "_n_" + pIconSize + ".png";
            couponsTabIcon = rootUrl + "/" + couponsTabIcon + "_n_" + pIconSize + ".png";
            eventsTabIcon = rootUrl + "/" + eventsTabIcon + "_n_" + pIconSize + ".png";
            bulletinsTabIcon = rootUrl + "/" + bulletinsTabIcon + "_n_" + pIconSize + ".png";
            webLinkTabIcon = rootUrl + "/" + webLinkTabIcon + "_n_" + pIconSize + ".png";
            socialTabIcon = rootUrl + "/" + socialTabIcon + "_n_" + pIconSize + ".png";

            string toolsSettings = "<SubTools><Tools " + pToolsSettings + "/></SubTools>";
            string childTabName = string.Empty;
            var xmlTools = XElement.Parse(toolsSettings, LoadOptions.PreserveWhitespace);
            //Convert.ToBoolean(XMLTools.Element("Tools").Attribute("BName").Value);

            childTabName = childTabName + "<Tab ID='HomeTab' Name='" + homeTab + "' Icon='" + homeTabIcon + "'/>";
            //Tabs Count total 9

            if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsAboutUs").Value) == true)
            {
                childTabName = childTabName + "<Tab ID='AboutUsTab' Name='" + aboutTab + "' Icon='" + aboutTabIcon + "'/>";
            }
            if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsUpdates").Value) == true)
            {
                childTabName = childTabName + "<Tab ID='UpdatesTab' Name='" + updatesTab + "' Icon='" + updatesTabIcon + "'/>";
            }
            if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsCoupons").Value) == true)
            {
                childTabName = childTabName + "<Tab ID='CouponsTab' Name='" + couponsTab + "' Icon='" + couponsTabIcon + "'/>";
            }
            if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsPhotos").Value) == true)
            {
                childTabName = childTabName + "<Tab ID='MediaTab' Name='" + mediasTab + "' Icon='" + mediasTabIcon + "'/>";
            }
            if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsEvents").Value) == true)
            {
                childTabName = childTabName + "<Tab ID='EventsTab' Name='" + eventsTab + "' Icon='" + eventsTabIcon + "'/>";
            }
            if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsBulletins").Value) == true && showBulletins == true)
            {
                childTabName = childTabName + "<Tab ID='BulletinsTab' Name='" + bulletinTab + "' Icon='" + bulletinsTabIcon + "'/>";
            }
            if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsWebLinks").Value) == true && showBulletins == true)
            {
                childTabName = childTabName + "<Tab ID='WebLinksTab' Name='" + webLinksTab + "' Icon='" + webLinkTabIcon + "'/>";
            }

            if (Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsSocial").Value) == true)
            {
                childTabName = childTabName + "<Tab ID='SocialTab' Name='" + socialTab + "' Icon='" + socialTabIcon + "'/>";
            }

            profileTabsNames = childTabName;
            return profileTabsNames;

        }

        /// <summary>
        /// Getting User Buy Tools
        /// </summary>
        /// <param name="pUserID">param is pUserID</param>
        /// <param name="ShowBulletins">param is ShowBulletins</param>
        /// <returns>return tools</returns>
        private string GetSelectedToolsSettings(int pUserID, bool showBulletins)
        {
            DataTable dtSelectedTools = IRHMServiceDAL.GetMobileAppSetting(Convert.ToInt32(pUserID));

            string xmlSelectedTools = "";
            if (dtSelectedTools.Rows.Count <= 0)
            {
                xmlSelectedTools = "<SubTools><Tools BName='True' Logo='True'  Address='False'  City='False'  State='False' Country='False' ZipCode='True' " +
                    " PhoneNumber='False'  AboutUs='False'  Updates='False'   Social='False' Coupons='False'  Photos='False' Events='False' " +
                    " IsBulletins='False'   IsContatUs='False'    IsPhotoCapture='False' IsWebLinks='False' IsGeoLocation='False' /></SubTools>";
            }
            else
            {
                xmlSelectedTools = Convert.ToString(dtSelectedTools.Rows[0]["M_SettingValue"]);
            }
            if (showBulletins == false)
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
            xmlSelectedTools = xmlSelectedTools.Replace("EmailID", "IsEmailID");
            xmlSelectedTools = xmlSelectedTools.Replace("AboutUs", "IsAboutUs");
            xmlSelectedTools = xmlSelectedTools.Replace("Updates", "IsUpdates");
            xmlSelectedTools = xmlSelectedTools.Replace("Social", "IsSocial");
            xmlSelectedTools = xmlSelectedTools.Replace("Coupons", "IsCoupons");
            xmlSelectedTools = xmlSelectedTools.Replace("Photos", "IsPhotos");
            xmlSelectedTools = xmlSelectedTools.Replace("Events", "IsEvents");

            xmlSelectedTools = xmlSelectedTools.Replace("<SubTools><Tools", "");
            xmlSelectedTools = xmlSelectedTools.Replace("/></SubTools>", "");

            return xmlSelectedTools;
        }

        /// <summary>
        /// Getting Home Page Settings
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return home tab settings</returns>
        private string HomeTabSettings(int pProfileID)
        {
            string details = "";

            bool isHomeImage = false;

            string yearEstablished = string.Empty;
            string noOfEmployee = string.Empty;
            string memberShip = string.Empty;

            bool establishmentflag = false;
            bool noofemployeesflag = false;


            //Getting Home Page Images
            var dtobj = BusinessDAL.GetProfilePhotosByProfileID(Convert.ToInt32(pProfileID));
            var uploadphotosPath = System.Configuration.ConfigurationManager.AppSettings.Get("OuterRootUrl") + "/Upload/Photos/" + pProfileID + "/";
            if (dtobj.Rows.Count > 0)
            {
                if (dtobj.Rows[0]["PrimaryImage_Flag"].ToString() == "True" && dtobj.Rows[0]["Photo_Prime_Flag"].ToString() == "True")
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

            // // *** Profile Additional Description *** //
            // Start: To assign privacy settings 
            DataTable dataobj = BusinessDAL.GetProfileSettingsByprofileID(Convert.ToInt32(pProfileID));
            if (dataobj.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dataobj.Rows[0]["Year_Established"]) == true)
                {
                    establishmentflag = true;
                }
                else
                {
                    establishmentflag = false;
                }
            }
            if (dataobj.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dataobj.Rows[0]["No_of_Employees"]) == true)
                {
                    noofemployeesflag = true;
                }
                else
                {
                    noofemployeesflag = false;
                }
            }

            var dtpdesc = BusinessDAL.Getprofiledescription(Convert.ToInt32(pProfileID));
            if (dtpdesc.Rows.Count > 0)
            {
                if (dtpdesc.Rows[0]["Local_memberships"].ToString() != "")
                {
                    memberShip = dtpdesc.Rows[0]["Local_memberships"].ToString();
                }
                if (dtpdesc.Rows[0]["No_Of_Emp"].ToString() != "")
                {
                    noOfEmployee = Convert.ToString(dtpdesc.Rows[0]["No_Of_Emp"].ToString());
                }
                if (dtpdesc.Rows[0]["Business_duration"].ToString() != "")
                {
                    yearEstablished = Convert.ToString(dtpdesc.Rows[0]["Business_duration"].ToString());
                }
            }


            details = " IsHomeImage='" + isHomeImage + "' IsYearEst='" + establishmentflag + "'" +
                " IsNoOfEmps='" + noofemployeesflag + "'   HomeImage='" + uploadphotosPath + "'  YearEst='" + yearEstablished + "'" +
                " NoOfEmps='" + noOfEmployee + "' MemberType='" + ReplaceSpecialCharacter(memberShip) + "'     ";

            return details;

        }

        #endregion

        #region 1.1 Version new methods

        /// <summary>
        /// Getting business details by profile code & radius values
        /// </summary>
        /// <param name="pBCode">param is pBCode</param>
        /// <param name="latitude2">param is latitude2</param>
        /// <param name="longitude2">param is longitude2</param>
        /// <param name="radius">param is radius</param>
        /// <returns>return business details as XML string</returns>
        public string GetProfileDetailsByBCode(string pBCode, int pProfileID, string pType, string latitude2, string longitude2, string radius)
        {
            string xmlSearchResult = string.Empty;
            DataTable dtResult = IRHMServiceDAL.GetProfiledetailsByBCode(pBCode, pProfileID, pType, latitude2, longitude2, radius);

            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                bool showBulletins = false;
                if (!string.IsNullOrEmpty(dtResult.Rows[0]["Package_Number"].ToString()))
                {
                    if (Convert.ToInt32(dtResult.Rows[0]["Package_Number"].ToString()) > 4)
                    {
                        showBulletins = true;
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

                string emailID = string.Empty;
                if (Convert.ToString(dtResult.Rows[i]["User_email"]) == string.Empty)
                {
                    emailID = Convert.ToString(dtResult.Rows[i]["Username"]);
                }
                else
                {
                    emailID = Convert.ToString(dtResult.Rows[i]["User_email"]);
                }

                xmlSearchResult = xmlSearchResult + "<Prof PID='" + Convert.ToString(dtResult.Rows[i]["Profile_ID"]) + "'" +
                    " UID='" + Convert.ToString(dtResult.Rows[i]["User_ID"]) + "'" +
                    " P_PName='" + ReplaceSpecialCharacter(Convert.ToString(dtResult.Rows[i]["Profile_name"])) + "'" +
                    " P_BName='" + ReplaceSpecialCharacter(Convert.ToString(dtResult.Rows[i]["Profile_displayname"])) + "'" +
                    " P_Logo='" + ConfigurationManager.AppSettings.Get("OuterRootURL") + "/Upload/Logos/" + Convert.ToString(dtResult.Rows[i]["Profile_ID"]) + "/" + Convert.ToString(dtResult.Rows[i]["Profile_ID"]) + "_thumb.jpg'" +
                    " P_Address='" + ReplaceSpecialCharacter(address) + "'" +
                    " P_MobileNumber='" + Convert.ToString(dtResult.Rows[i]["Mobile_Number"]) + "'" +
                    " P_EmailID='" + emailID + "'" +
                    " P_City='" + ReplaceSpecialCharacter(Convert.ToString(dtResult.Rows[i]["Profile_City"])) + "'" +
                    " P_State='" + Convert.ToString(dtResult.Rows[i]["Profile_State"]) + "'" +
                    " P_Zipcode='" + Convert.ToString(dtResult.Rows[i]["Profile_Zipcode"]) + "'" +
                    " P_Country='" + Convert.ToString(dtResult.Rows[i]["Profile_County"]) + "'" +
                      " P_Latitude='" + Convert.ToString(dtResult.Rows[i]["latitude1"]) + "'" +
                      " P_Longitude='" + Convert.ToString(dtResult.Rows[i]["longitude1"]) + "'" +
                      " " + HomeTabSettings(Convert.ToInt32(dtResult.Rows[i]["Profile_ID"])) + " " +
                    // " " + SpiltSelectedToolsSettings(Convert.ToInt32(dtResult.Rows[i]["User_ID"]), ShowBulletins) + " " +
                      " " + GetSelectedToolsSettings(Convert.ToInt32(dtResult.Rows[i]["User_ID"]), showBulletins) + " " + "/>";

            }

            if (pType == "1")
            {
                xmlSearchResult = "<BPDetails>" + xmlSearchResult + "</BPDetails>";
            }
            else
            {
                //here getting profile id based details                
            }
            return xmlSearchResult;
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
        public string InsertAppDeviceDetails(string pDeviceID, int pProfileID, string pDeviceType, string pBusinessName, string pAddress)
        {
            return IRHMServiceDAL.InsertAppDeviceDetails(pDeviceID, pProfileID, pDeviceType, pBusinessName, pAddress);
        }

        /// <summary>
        /// Delete device details
        /// </summary>
        /// <param name="pDeviceID">param is pDeviceID</param>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return success or failure</returns>
        public string DeleteAppDeviceDetails(string pDeviceID, int pProfileID)
        {
            return IRHMServiceDAL.DeleteAppDeviceDetails(pDeviceID, pProfileID);
        }

        /// <summary>
        /// Getting all active & publish bulletins by profile id
        /// </summary>
        /// <param name="pProfileID">param is pProfileID</param>
        /// <returns>return bulletins as XML string</returns>
        public string GetActiveBulletinsByProfileID(int pProfileID)
        {
            string xmlActiveBulletinsString = string.Empty;
            DataTable dtActiveBulletins = BulletinDAL.GetActiveBulletinsByProfileID(Convert.ToInt32(pProfileID));

            for (int i = 0; i < dtActiveBulletins.Rows.Count; i++)
            {
                string bulletinUrl = System.Configuration.ConfigurationManager.AppSettings.Get("OuterRootURL") + "/OnlineBulletin.aspx?BLID=" + EncryptDecrypt.DESEncrypt(Convert.ToString(dtActiveBulletins.Rows[i]["Bulletin_ID"])).Replace("=", "irhmalli").Replace("+", "irhPASS");

                xmlActiveBulletinsString = xmlActiveBulletinsString + "<Details BulletinID='" + Convert.ToString(dtActiveBulletins.Rows[i]["Bulletin_ID"]) + "'" +
                    " Title='" + ReplaceSpecialCharacter(Convert.ToString(dtActiveBulletins.Rows[i]["Bulletin_Title"])) + "'" +
                    " IsAlternatePhone='" + Convert.ToString(dtActiveBulletins.Rows[i]["IsCall"]) + "' " +
                    " IsContactUs='" + Convert.ToString(dtActiveBulletins.Rows[i]["IsContactUs"]) + "' " +
                    " BulletinURL='" + bulletinUrl + "' " +
                   " />";
            }
            xmlActiveBulletinsString = "<Bulletins>" + xmlActiveBulletinsString + "</Bulletins>";
            return xmlActiveBulletinsString;
        }

        /// <summary>
        /// Getting bulletin html details by bulletin ID
        /// </summary>
        /// <param name="pBulletinID">param is pBulletinID</param>
        /// <returns>return bulletin html as string</returns>
        public string GetBulletinHtmlStringByID(int pBulletinID)
        {
            DataTable dtActiveBulletins = BulletinDAL.GetBulletinDetailsByID(Convert.ToInt32(pBulletinID));
            string htmlString = BuildHeader().Replace("#BuildHtmlForForm#", Convert.ToString(dtActiveBulletins.Rows[0]["Bulletin_HTML"]));
            htmlString = htmlString.Replace("margin-left:20px;", "margin-left:0px;");
            htmlString = htmlString.Replace("margin-left: 20px;", "margin-left: 0px;");
            return htmlString;
        }

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
            string xmlWebLink = string.Empty;
            DataTable dtWebLinks = BusinessDAL.GetWebLinks(Convert.ToInt32(pProfileID));

            for (int i = 0; i < dtWebLinks.Rows.Count; i++)
            {
                xmlWebLink = xmlWebLink + "<Link Name='" + Convert.ToString(dtWebLinks.Rows[i]["Link_Title"]) + "' URL='" + Convert.ToString(dtWebLinks.Rows[i]["Link_Url"]) + "' />";
            }

            xmlWebLink = "<WebLinks>" + xmlWebLink + "</WebLinks>";
            return xmlWebLink;


            /*
            string webLinkName1 = string.Empty;
            string webLinkName2 = string.Empty;

            string webLinkURL1 = string.Empty;
            string webLinkURL2 = string.Empty;


            DataTable dtProfileDetails = BusinessDAL.GetProfileDetailsByProfileID(Convert.ToInt32(pProfileID));
            

            if (Convert.ToString(dtProfileDetails.Rows[0]["Profile_website_url"]) != "http://" && Convert.ToString(dtProfileDetails.Rows[0]["Profile_website_url"]) != string.Empty)
            {
                webLinkURL1 = Convert.ToString(dtProfileDetails.Rows[0]["Profile_website_url"]);
            }
            if (Convert.ToString(dtProfileDetails.Rows[0]["Profile_cor_url"]) != "http://" && Convert.ToString(dtProfileDetails.Rows[0]["Profile_cor_url"]) != string.Empty)
            {
                webLinkURL2 = Convert.ToString(dtProfileDetails.Rows[0]["Profile_cor_url"]);
            }

            webLinkName1 = Convert.ToString(dtProfileDetails.Rows[0]["WebLink1_Name"]);
            webLinkName2 = Convert.ToString(dtProfileDetails.Rows[0]["WebLink2_Name"]);

            if (webLinkName1 == string.Empty)
            {
                webLinkName1 = webLinkURL1;
            }
            if (webLinkName2 == string.Empty)
            {
                webLinkName2 = webLinkURL2;
            }

            if (webLinkURL1 != string.Empty)
            {
                xmlWebLink = "<Link Name='" + webLinkName1 + "' URL='" + webLinkURL1 + "' />";
            }
            if (webLinkURL2 != string.Empty)
            {
                xmlWebLink = xmlWebLink + "<Link Name='" + webLinkName2 + "' URL='" + webLinkURL2 + "' />"; ;
            }

            xmlWebLink = "<WebLinks>" + xmlWebLink + "</WebLinks>";
            */


        }

        public DataTable GetDevicesforNotifications(int profileID)
        {
            return IRHMServiceDAL.GetDevicesforNotifications(profileID);
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
        public void AddPushNotifications(string message, int profileID, int createdUser, int totalDevices, int sentDevices, string deviceIDs, int flag)
        {
            IRHMServiceDAL.AddPushNotifications(message, profileID, createdUser, totalDevices, sentDevices, deviceIDs, flag);
        }

        /// <summary>
        /// Add Header for Bulletin HTML String
        /// </summary>
        /// <returns></returns>
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

        #endregion
    }
}
