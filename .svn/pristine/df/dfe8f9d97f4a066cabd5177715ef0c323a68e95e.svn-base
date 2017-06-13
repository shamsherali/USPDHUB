using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using USPDHUBDAL;
using System.Xml.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Configuration;

namespace USPDHUB
{
    public partial class OnlinePublicCallItem : System.Web.UI.Page
    {

        public int CustomID = 0;
        AddOnBLL objAddOn = new AddOnBLL();
        CommonBLL objCommon = new CommonBLL();
        public int HistoryID = 0;

        public int ProfileID = 0;
        public int UserID = 0;
        public bool IsFromEmail = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["CustomID"] != null && Request.QueryString["CustomID"] != "")
                {
                    string callid = Request.QueryString["CustomID"].ToString().Replace(" ", "+");
                    callid = callid.Replace("irhmalli", "=").Replace("irhPASS", "+");
                    int length = callid.Length;
                    if (callid[length - 1] != '=')
                    {
                        callid += '=';
                    }
                    callid = EncryptDecrypt.DESDecrypt(callid);
                    CustomID = Convert.ToInt32(callid);


                    string strHistoryid = Request.QueryString["CHID"].ToString().Replace(" ", "+");
                    strHistoryid = strHistoryid.Replace("irhmalli", "=").Replace("irhPASS", "+");
                    length = strHistoryid.Length;
                    if (strHistoryid[length - 1] != '=')
                    {
                        strHistoryid += '=';
                    }
                    strHistoryid = EncryptDecrypt.DESDecrypt(strHistoryid);
                    HistoryID = Convert.ToInt32(strHistoryid);


                    string strEmail = Request.QueryString["IsEmail"].ToString().Replace(" ", "+");
                    strEmail = strEmail.Replace("irhmalli", "=").Replace("irhPASS", "+");
                    length = strEmail.Length;
                    if (strEmail[length - 1] != '=')
                    {
                        strEmail += '=';
                    }
                    strEmail = EncryptDecrypt.DESDecrypt(strEmail);
                    IsFromEmail = Convert.ToBoolean(strEmail);
                }

                if (!IsPostBack)
                {
                    if (CustomID > 0)
                    {
                        DataTable dtItemDetails = AddOnDAL.GetPublicCallOnsDetailsByCustomID(CustomID);
                        if (dtItemDetails.Rows.Count > 0)
                        {
                            ProfileID = Convert.ToInt32(dtItemDetails.Rows[0]["ProfileID"]);
                            UserID = Convert.ToInt32(dtItemDetails.Rows[0]["UserID"]);
                        }

                        string previewHTML = string.Empty;
                        previewHTML = objCommon.GetHeaderForBulletins(UserID, ProfileID, false);
                        previewHTML = previewHTML.Replace("#BuildHtmlForForm#", BuildHTML());
                        lblCallItem.Text = previewHTML;

                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "OnlinePublicCallItem.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

            }
        }


        public string GetHeaderForOnline(int userID, int profileID)
        {
            try
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
                re.Dispose();
                string RootPath = objCommon.GetConfigSettings(ProfileID.ToString(), "Paths", "RootPath");
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
                return strHeader;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "OnlinePublicCallItem.aspx.cs", "GetHeaderForOnline", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

                return "";
            }
        }

        private string BuildHTML()
        {
            DataTable dtItemDetails = AddOnDAL.GetPublicCallOnsDetailsByCustomID(CustomID);


            string AppName = "";
            string TabName = "";
            string Caller_name = "";
            string Caller_EmailID = "";
            string Caller_PhoneNumber = "";
            string Caller_Address = "";
            string Caller_Location_time = DateTime.Now.ToString("MM/dd/yyyy hh:ss tt");
            string ItemTitle = "";
            double latitude = 0;
            double longtude = 0;
            string Email_Message = "";
            string dailNumber = "";
            string ProfileLogo = "";
            string companyName = "";
            string PreviewHtml = "";

            string outerURL = "";
            string pGPS_Details = "";
            string pContactName = "";
            string pContactEmail = "";
            string pContactPhoneNumber = "";
            string imageName = "";


            if (dtItemDetails.Rows.Count > 0)
            {
                // Call Item Details
                outerURL = objCommon.GetConfigSettings(ProfileID.ToString(), "Paths", "RootPath");

                dailNumber = Convert.ToString(dtItemDetails.Rows[0]["MobileNumber"]);
                if (IsFromEmail)
                    Email_Message = Convert.ToString(dtItemDetails.Rows[0]["Email_Description"]);
                else
                    Email_Message = Convert.ToString(dtItemDetails.Rows[0]["SMS_Description"]);
                ItemTitle = Convert.ToString(dtItemDetails.Rows[0]["Title"]);


                // Profile  Details (From User Details)
                DataTable dtCallerDetails = AddOnDAL.GetPubliceCallOns_SenderDetails("", 0, ProfileID, 0, CustomID);
                if (dtCallerDetails.Rows.Count > 0)
                {
                    AppName = Convert.ToString(dtCallerDetails.Rows[0]["AppName"]);
                    TabName = Convert.ToString(dtCallerDetails.Rows[0]["TabName"]);
                    ProfileLogo = Convert.ToString(dtCallerDetails.Rows[0]["ProfileLogoName"]);

                    companyName = Convert.ToString(dtCallerDetails.Rows[0]["CompanyName"]);
                }

                #region Logo

                string logoName = "";
                logoName = ProfileLogo;
                int logoprofileid = ProfileID;
                string extension = System.IO.Path.GetExtension(logoName);
                if (logoName == string.Empty)
                {
                    extension = ".jpg";
                }

                string logoFullPath = "";
                string logoServerpath = ConfigurationManager.AppSettings.Get("USPDVirtualFolderPath") + "\\Upload\\Logos\\";
                logoServerpath = logoServerpath + logoprofileid + "\\" + logoprofileid + "_thumb" + extension;
                if (File.Exists(logoServerpath) && logoName != "")
                {
                    logoFullPath = outerURL + "/Upload/Logos/" +
                      logoprofileid + "/" + logoprofileid + "_thumb" + extension;
                }
                else
                {
                    logoFullPath = "";
                }

                #endregion

                /**** Caller Details & History  ****/
                BusinessBLL objBus = new BusinessBLL();
                DataTable dtHistory = objBus.GetMobilePublicCallsHistory(false, HistoryID, ProfileID);
                if (dtHistory.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtItemDetails.Rows[0]["IsCustomPredefinedMessage"]))
                    {
                        Email_Message = dtHistory.Rows[0]["CustomPredefinedMessage"].ToString();
                    }

                    Caller_EmailID = dtHistory.Rows[0]["ContactEmail"].ToString().Replace("(null)", "").Replace("null", "");
                    Caller_PhoneNumber = dtHistory.Rows[0]["ContactPhoneNumber"].ToString().Replace("(null)", "").Replace("null", "");
                    Caller_name = dtHistory.Rows[0]["ContactName"].ToString().Replace("(null)", "").Replace("null", "");
                    imageName = Convert.ToString(dtHistory.Rows[0]["ImageName"]).Trim().Replace("(null)", "").Replace("null", "");
                    pGPS_Details = Convert.ToString(dtHistory.Rows[0]["GPS_Details"]);

                    Caller_Location_time = Convert.ToDateTime(dtHistory.Rows[0]["CreatedDate"]).ToString("MM/dd/yyyy hh:ss tt");
                    Caller_Address = Convert.ToString(dtHistory.Rows[0]["CurrentLocation"]).Trim();
                }


                #region Get Current Address by Lati & Long

                if (Caller_Address == string.Empty)
                {
                    if (pGPS_Details.Contains(","))
                    {
                        var values = pGPS_Details.Split(',');
                        latitude = Convert.ToDouble(values[0]);
                        longtude = Convert.ToDouble(values[1]);
                    }

                    string CurrentAddress = "";
                    XmlDocument doc = new XmlDocument();
                    doc.Load("http://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longtude + "&sensor=false");
                    XmlNode element = doc.SelectSingleNode("//GeocodeResponse/status");
                    if (element.InnerText == "ZERO_RESULTS")
                    {
                        Caller_Address = "";
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
                                    CurrentAddress = CurrentAddress + "," + " " + textdata[i].Trim().ToString();
                            }
                            Caller_Address = CurrentAddress + ".";
                        }
                    }
                }

                #endregion



                #region  Images Reading

                string ImageVirtualPath = ConfigurationManager.AppSettings.Get("AppContactUsPhotosFolderName") + "/PublicCallDirectoryTapImages/" + ProfileID + "/" + imageName;
                int width = 0;
                int height = 0;

                string imgTag = "";
                if (File.Exists(ImageVirtualPath))
                {
                    string ImgRootPath = ConfigurationManager.AppSettings.Get("AppContactusPhotoPath") + "/PublicCallDirectoryTapImages/" + ProfileID + "/" + imageName;


                    using (FileStream fs = new FileStream(ImageVirtualPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (System.Drawing.Image image = System.Drawing.Image.FromStream(fs))
                        {
                            height = image.Height;
                            width = image.Width;
                        }
                    }

                    if (width > 350 && height > 250)
                    {
                        imgTag = "<img src='" + ImgRootPath + "' Width='350' Height='250'  />";
                    }
                    else if (width > 350)
                    {
                        imgTag = "<img src='" + ImgRootPath + "' Width='350' />";
                    }
                    else if (height > 250)
                    {
                        imgTag = "<img src='" + ImgRootPath + "' Height='250' />";
                    }
                    else
                    {
                        imgTag = "<img src='" + ImgRootPath + "'  />";
                    }
                }

                #endregion

                string pBody = "";
                string emailFormat = "";
                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\";
                using (StreamReader re = File.OpenText(strfilepath + "PublicCallAddOns_OnlinePreview.txt"))
                {
                    string content = string.Empty;
                    while ((content = re.ReadLine()) != null)
                    {
                        emailFormat = emailFormat + content;
                    }
                    re.Close();
                }


                if (logoFullPath == "")
                    pBody = emailFormat.Replace("#ProfileLogo#", "");
                else
                    pBody = emailFormat.Replace("#ProfileLogo#", "<IMG SRC='" + logoFullPath + "' border='0' />");

                pBody = pBody.Replace("#AppName#", AppName);
                pBody = pBody.Replace("#TabName#", TabName);
                pBody = pBody.Replace("#ItemTitle#", ItemTitle);

                pBody = pBody.Replace("#Message#", Email_Message);
                pBody = pBody.Replace("#Name#", Caller_name);
                pBody = pBody.Replace("#Phone#", Caller_PhoneNumber);
                pBody = pBody.Replace("#EmailID#", Caller_EmailID);
                pBody = pBody.Replace("#Time#", Caller_Location_time.ToString());
                pBody = pBody.Replace("#Location#", Caller_Address);

                if (imgTag.ToString() == string.Empty)
                { pBody = pBody.Replace("#IMGSRC#", ""); }
                else
                { pBody = pBody.Replace("#IMGSRC#", imgTag); }


                PreviewHtml = pBody;
            }



            return PreviewHtml;
        }

    }
}