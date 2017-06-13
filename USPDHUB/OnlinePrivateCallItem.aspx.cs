using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.IO;
using System.Data;
using USPDHUBDAL;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;

namespace USPDHUB
{
    public partial class OnlinePrivateCallItem : System.Web.UI.Page
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
                        DataTable dtItemDetails = AddOnDAL.GetCallIndexByID(CustomID).Tables[0];
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
                objInBuiltData.ErrorHandling("ERROR", "OnlinePrivateCallItem.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

            }
        }


       

        private string BuildHTML()
        {
            string AppName = "";
            string TabName = "";
            string Caller_name = "";
            string Caller_EmailID = "";
            string Caller_PhoneNumber = "";
            string Caller_Address = "";
            DateTime Caller_Location_time = DateTime.Now;

            string ItemTitle = "";

            double latitude = 0;
            double longtude = 0;




            bool IsSMS = false;
            string SMS_Subect = "";
            string SMS_Message = "";
            string sms_GroupIDs = "";

            bool IsGPS = false;

            bool IsCustomPredefinedMessage = false;
            string appCustomPredefinedMessage = "";

            string dailNumber = "";
            string ProfileLogo = "";
            string companyName = "";

            string pGPS_Details = "";
            int appID = 0;
            string uniqueDeviceID = "";
            string CustomPredefinedMessage = "";



            /*** Call Item History Details ***/
            DataTable dtHistory = AddOnDAL.GetPrivateCallOnsHistoryDetailsByCustomID(HistoryID);
            if (dtHistory.Rows.Count > 0)
            {
                pGPS_Details = dtHistory.Rows[0]["GPS_Details"].ToString();
                appID = Convert.ToInt32(dtHistory.Rows[0]["AppID"]);
                uniqueDeviceID = dtHistory.Rows[0]["UniqueDeviceID"].ToString();
                CustomPredefinedMessage = Convert.ToString(dtHistory.Rows[0]["CustomPredefinedMessage"]);
                Caller_Location_time = Convert.ToDateTime(dtHistory.Rows[0]["CreatedDate"]);
                Caller_Address = Convert.ToString(dtHistory.Rows[0]["CurrentLocation"]).Trim();
            }

            // Profile  Details (From User Details)
            DataTable dtCallerDetails = AddOnDAL.GetPrivateCallOns_SenderDetails(uniqueDeviceID, appID, ProfileID, 0, CustomID);
            if (dtCallerDetails.Rows.Count > 0)
            {
                AppName = Convert.ToString(dtCallerDetails.Rows[0]["AppName"]);
                TabName = Convert.ToString(dtCallerDetails.Rows[0]["TabName"]);
                ProfileLogo = Convert.ToString(dtCallerDetails.Rows[0]["ProfileLogoName"]);

                Caller_name = Convert.ToString(dtCallerDetails.Rows[0]["Name"]);
                Caller_PhoneNumber = Convert.ToString(dtCallerDetails.Rows[0]["MobileNumber"]);
                Caller_EmailID = Convert.ToString(dtCallerDetails.Rows[0]["EmailID"]); 
                companyName = Convert.ToString(dtCallerDetails.Rows[0]["CompanyName"]);
            }

            #region Logo

            string outerURL = objCommon.GetConfigSettings(ProfileID.ToString(), "Paths", "RootPath");
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

            /**** Item Details  ****/
            BusinessBLL objBus = new BusinessBLL();
            DataTable dtItemDetails = AddOnDAL.GetPrivateCallOnsDetailsByCustomID(CustomID, 0);
            if (dtItemDetails.Rows.Count > 0)
            { 
                dailNumber = Convert.ToString(dtItemDetails.Rows[0]["MobileNumber"]);

                SMS_Subect = Convert.ToString(dtItemDetails.Rows[0]["SMS_Subject"]);
                if (IsFromEmail)
                    SMS_Message = Convert.ToString(dtItemDetails.Rows[0]["Email_Description"]);
                else
                    SMS_Message = Convert.ToString(dtItemDetails.Rows[0]["SMS_Description"]);
                 
                if (CustomPredefinedMessage == string.Empty)
                    CustomPredefinedMessage = SMS_Message;

                ItemTitle = Convert.ToString(dtItemDetails.Rows[0]["Title"]);

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


            string pBody = "";
            string emailFormat = "";
            string buttonTitle = "";          
            string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\";

            using (StreamReader re = File.OpenText(strfilepath + "PrivateCallAddOns_OnlinePreview.txt"))
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
            pBody = pBody.Replace("#Message#", CustomPredefinedMessage);

            pBody = pBody.Replace("#Name#", Caller_name);
            pBody = pBody.Replace("#Phone#", Caller_PhoneNumber);
            pBody = pBody.Replace("#EmailID#", Caller_EmailID);
            pBody = pBody.Replace("#Time#", Caller_Location_time.ToString());
            pBody = pBody.Replace("#Location#", Caller_Address);
            pBody = pBody.Replace("#CompanyName#", companyName);

            return pBody;
        }

    }
}