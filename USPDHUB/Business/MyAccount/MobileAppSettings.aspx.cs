using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml.Linq;
using USPDHUBBLL;
using System.Collections.Generic;

namespace USPDHUB.Business.MyAccount
{
    public partial class MobileAppSettings : BaseWeb
    {
        private bool isEnableMobileApp = false;

        private bool isBusinessName = true;
        private bool isLogo = true;
        private bool isNotificaton = true;

        private bool isAddress = false;
        private bool isCity = false;
        private bool isState = false;
        private bool isCountry = false;
        private bool isZipcode = true;
        private bool isEmergencyNumber = false;

        private string emergencyPhoneNumber = "";

        private bool isPhoneNumber = false;
        public bool IsMainPH = false;

        private bool isAboutUs = false;
        private bool isUpdates = false;
        private bool isSocialMedia = false;
        private bool isWebLinks = false;
        private bool isPhotoAlbum = false;
        private bool isEvents = false;
        private bool isSurveys = false;
        private bool isBulletins = false;
        private bool isPushNotifications = false;

        private bool isContactUs = false;
        private bool isSubmitTip = false;
        private bool isPhotoCapture = false;
        private bool isGeoLocation = false;
        private bool isSharing = false;
        private bool isGPS = false;
        private bool isAnonymous = false;
        private bool IsContact_Tips_CustomMessage = false;

        public int UserID = 0;
        public int ProfileID = 0;
        public int CUserID = 0;              //Added By Venkat...
        string xmlSettings = string.Empty;
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        USPDHUBBLL.MobileAppSettings objMobileApp = new USPDHUBBLL.MobileAppSettings();
        BusinessBLL objBus = new BusinessBLL();
        public DataTable Dtpermissions = new DataTable();
        DataTable mastertabs = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        public string PermissionType = string.Empty;
        public int PermissionValue = 0;
        Consumer conobj = new Consumer();
        public string DomainName = "";
        CommonBLL objCommon = new CommonBLL();
        AddOnBLL objAddOn = new AddOnBLL();
        public string textDisplay = "feedback";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
                Response.Redirect(Page.ResolveClientUrl("~/login.aspx?sflag=1"));
            else
            {
                UserID = Convert.ToInt32(Session["UserID"]);
                DomainName = Session["VerticalDomain"].ToString();
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;

                if (Session["ProfileID"] != null)
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);
                // *** Make back button visible and disable by query string 26-03-2013 *** //
                if (!string.IsNullOrEmpty(Request.QueryString["Check"]))
                    btncancelupdate.Visible = false;
                else
                    btncancelupdate.Visible = true;
                /***Displaying Tips for USPD Domain & Feedback for remaining Domains ***/
                if (DomainName.ToLower().Contains("uspdhub"))
                {
                    textDisplay = "tips";

                }
              
                if (!IsPostBack)
                {

                    try
                    {

                        DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                        //if (Convert.ToBoolean(dtProfile.Rows[0]["IsLiteVersion"]))
                        //    pnlActions.Attributes.Add("style", "display:none");
                        if (DomainName.ToLower().Contains("localhost") || DomainName.ToLower().Contains("uspdhub"))
                        {
                            chkEmergencyNumber.Checked = true;
                        }
                        else
                        {
                            chkEmergencyNumber.Checked = false;
                        }

                        // *** Adding communication email field 30-05-2013 *** //
                        DataTable dtobj = conobj.GetUserDetails(Session["username"].ToString(), DomainName);
                        txtCommEmail.Text = Session["username"].ToString();
                        if (dtobj.Rows.Count > 0)
                            txtCommEmail.Text = dtobj.Rows[0]["User_email"].ToString();
                        Session["SettingID"] = 0;

                        chkBusinessName.Checked = true;
                        chkLogo.Checked = true;
                        //chkZipcode.Checked = true;

                        //Calling Javascript function For Checkboxes True OR False                    
                        var dtProfileDetails = objBus.GetProfileDetailsByProfileID(ProfileID);

                        string EmergncyNumber = "";
                        DataTable dtDefaultProfileTabs = objBus.GetDefaultProfileTabNames(DomainName);
                        for (int k = 0; k < dtDefaultProfileTabs.Rows.Count; k++)
                        {
                            if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "EmergencyNumber")
                                EmergncyNumber = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                        }

                        //Getting Mobile App Settings
                        DataTable dtMobileAppSettings = objMobileApp.GetMobileAppSetting(UserID);
                       if (dtMobileAppSettings.Rows.Count > 0)
                        {
                            xmlSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                            Session["SettingID"] = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingID"]);
                            var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                            //BUSINESS DETAILS
                            chkBusinessName.Checked = isBusinessName = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("BName").Value);
                            chkLogo.Checked = isLogo = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Logo").Value);
                            chkAddress.Checked = isAddress = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Address").Value);
                            chkCity.Checked = isCity = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("City").Value);
                            chkState.Checked = isState = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("State").Value);
                            chkCountry.Checked = isCountry = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Country").Value);
                            chkZipcode.Checked = isZipcode = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("ZipCode").Value);
                            if (xmlTools.Element("Tools").Attribute("IsEmergencyNumber") != null)
                                chkEmergencyNumber.Checked = isEmergencyNumber = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsEmergencyNumber").Value);

                            //CONTACT DETAILS     
                            bool isPhone = false;
                            if (xmlTools.Element("Tools").Attribute("PhoneNumber").Value != null)
                                isPhone = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("PhoneNumber").Value);
                            chkPhonenumber.Checked = isPhoneNumber = isPhone;
                            chkContactUs.Checked = isContactUs = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsContatUs").Value);
                            if (xmlTools.Element("Tools").Attribute("IsPushNotifications") != null)
                                chkPushNotifications.Checked = isPushNotifications = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsPushNotifications").Value);
                            if (xmlTools.Element("Tools").Attribute("IsPhotoCapture") != null)
                                chkPhotoCapture.Checked = isPhotoCapture = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsPhotoCapture").Value);
                            if (xmlTools.Element("Tools").Attribute("IsGeoLocation") != null)
                                chkGeoLocation.Checked = isGeoLocation = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsGeoLocation").Value);

                            if (xmlTools.Element("Tools").Attribute("IsMainPH") != null)
                                IsMainPH = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsMainPH").Value);

                            //chkSharing.Checked = true;
                            if (xmlTools.Element("Tools").Attribute("IsSharing") != null)
                                chkSharing.Checked = isSharing = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsSharing").Value);

                            //chkGPS.Checked = true;
                            if (xmlTools.Element("Tools").Attribute("IsGPS") != null)
                                chkGPS.Checked = isGPS = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsGPS").Value);

                            //chkAnonymous.Checked = true;
                            if (xmlTools.Element("Tools").Attribute("IsAnonymous") != null)
                                chkAnonymous.Checked = isAnonymous = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsAnonymous").Value);

                            if (xmlTools.Element("Tools").Attribute("IsContact_Tips_CustomMessage") != null)
                                chkContact_Tip_CustomMessage.Checked = IsContact_Tips_CustomMessage = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsContact_Tips_CustomMessage").Value);

                            if (xmlTools.Element("Tools").Attribute("Contact_Tips_CustomMessage") != null)
                                txtContact_Tip_CustomMessage.Text = RevertSpecialCharacters(Convert.ToString(xmlTools.Element("Tools").Attribute("Contact_Tips_CustomMessage").Value));

                            string alternatePH = "";
                            string mainPhoneNumber = "";
                            if (dtProfileDetails.Rows.Count > 0)
                            {
                                alternatePH = Convert.ToString(dtProfileDetails.Rows[0]["Alternate_Phone"]);
                                mainPhoneNumber = Convert.ToString(dtProfileDetails.Rows[0]["Profile_Phone1"]);
                            }
                            lblPhoneNumber.Text = "(" + mainPhoneNumber + ")";
                            if (IsMainPH)
                            {
                                rbmainph.Checked = true;
                            }
                            else
                            {
                                txtalternateph.Text = alternatePH;
                                rbalterph.Checked = true;
                            }
                            if (xmlTools.Element("Tools").Attribute("EmergencyNumber") != null)
                                txtEmrgncyNumber.Text = RevertSpecialCharacters(Convert.ToString(xmlTools.Element("Tools").Attribute("EmergencyNumber").Value));
                            else
                                txtEmrgncyNumber.Text = RevertSpecialCharacters(EmergncyNumber);
                        }


                        #region selected package based on tools enabled

                        DataTable packageDetails = objBus.GetSelectedToolsByUserID(UserID);
                        if (packageDetails.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(packageDetails.Rows[0]["Package_Number"].ToString()))
                            {
                                hdnPackageNumber.Value = packageDetails.Rows[0]["Package_Number"].ToString();
                                if (Convert.ToInt32(packageDetails.Rows[0]["Package_Number"].ToString()) <= 4)
                                {
                                    chkPhotoCapture.Checked = isPhotoCapture = false;
                                    chkGeoLocation.Checked = isGeoLocation = false;
                                }
                            }
                        }

                        #endregion

                        if (dtProfileDetails.Rows.Count > 0)
                        {
                            if (Convert.ToString(dtProfileDetails.Rows[0]["EnableMobileApp"]) == string.Empty)
                                Chkmain.Checked = isEnableMobileApp = true;
                            else
                                Chkmain.Checked = isEnableMobileApp = Convert.ToBoolean(dtProfileDetails.Rows[0]["EnableMobileApp"]);
                        }
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>MakeDefaultSettings(" + isEnableMobileApp.ToString().ToLower() + ")</script>", false);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Javascript", "CallFunctionFromServerSide(" + isEnableMobileApp.ToString().ToLower() + ")", true);

                        #region  //roles & permissions..

                        //roles & permissions..
                        if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                        {
                            hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                            if (hdnPermissionType.Value == "A")
                            {
                                btnUpdate.Enabled = false;
                                lblstatusmessage.Text = "<font face=arial size=2 color=red>You do not have permission to update mobile app settings.</font>";
                            }
                        }//ends here


                        #endregion

                    }
                    catch (Exception ex)
                    {
                        /*** Error Log ***/
                        objInBuiltData.ErrorHandling("ERROR", "MobileAppSettings.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                            Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                    }

                } /*** END Postback***/
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int roleId = (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business;
                string status = USPDHUBBLL.UtilitiesBLL.Statuses.Active.ToString();
                if (Chkmain.Checked == true) isEnableMobileApp = true; else isEnableMobileApp = false;
                if (chkBusinessName.Checked == true) isBusinessName = true; else isBusinessName = false;
                if (chkLogo.Checked == true) isLogo = true; else isLogo = false;
                if (chkAddress.Checked == true) isAddress = true; else isAddress = false;
                if (chkCity.Checked == true) isCity = true; else isCity = false;
                if (chkState.Checked == true) isState = true; else isState = false;
                if (chkCountry.Checked == true) isCountry = true; else isCountry = false;
                if (chkZipcode.Checked == true) isZipcode = true; else isZipcode = false;
                if (chkEmergencyNumber.Checked == true) isEmergencyNumber = true; else isEmergencyNumber = false;
                if (chkPhonenumber.Checked == true) isPhoneNumber = true; else isPhoneNumber = false;
                if (chkContactUs.Checked == true) isContactUs = true; else isContactUs = false;
                if (chkPhotoCapture.Checked == true) isPhotoCapture = true; else isPhotoCapture = false;
                if (chkGeoLocation.Checked == true) isGeoLocation = true; else isGeoLocation = false;

                if (chkSharing.Checked == true) isSharing = true; else isSharing = false;
                if (chkGPS.Checked == true) isGPS = true; else isGPS = false;
                if (chkAnonymous.Checked == true) isAnonymous = true; else isAnonymous = false;
                if (chkContact_Tip_CustomMessage.Checked == true) IsContact_Tips_CustomMessage = true; else IsContact_Tips_CustomMessage = false;


                if (rbmainph.Checked)
                    IsMainPH = true;
                DataSet dtAddOns = objAddOn.GetManageAddOns(UserID, null);
                string aboutUsTabName = "";
                string updatesTabName = "";
                string galleryTabName = "";
                string eventsTabName = "";
                string bulletinsTabName = "";
                string weblinksTabName = "";
                string socialMediaTabName = "";
                string surveysTabName = "";
                string notification = "";
                string submitTip = "";
                if (dtAddOns.Tables.Count > 0 && dtAddOns.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dtAddOns.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToString(dtAddOns.Tables[0].Rows[i]["ButtonType"]) == "Contact")
                        {
                            isContactUs = Convert.ToBoolean(dtAddOns.Tables[0].Rows[i]["IsVisible"]);
                        }
                        if (Convert.ToString(dtAddOns.Tables[0].Rows[i]["ButtonType"]) == "Call")
                        {
                            isPhoneNumber = Convert.ToBoolean(dtAddOns.Tables[0].Rows[i]["IsVisible"]);
                        }
                        if (Convert.ToString(dtAddOns.Tables[0].Rows[i]["ButtonType"]) == "AboutUs")
                        {
                            isAboutUs = Convert.ToBoolean(dtAddOns.Tables[0].Rows[i]["IsVisible"]);
                            aboutUsTabName = Convert.ToString(dtAddOns.Tables[0].Rows[i]["TabName"]);
                        }
                        if (Convert.ToString(dtAddOns.Tables[0].Rows[i]["ButtonType"]) == "Updates")
                        {
                            isUpdates = Convert.ToBoolean(dtAddOns.Tables[0].Rows[i]["IsVisible"]);
                            updatesTabName = Convert.ToString(dtAddOns.Tables[0].Rows[i]["TabName"]);
                        }
                        if (Convert.ToString(dtAddOns.Tables[0].Rows[i]["ButtonType"]) == "Gallery")
                        {
                            isPhotoAlbum = Convert.ToBoolean(dtAddOns.Tables[0].Rows[i]["IsVisible"]);
                            galleryTabName = Convert.ToString(dtAddOns.Tables[0].Rows[i]["TabName"]);
                        }
                        if (Convert.ToString(dtAddOns.Tables[0].Rows[i]["ButtonType"]) == "EventCalendar")
                        {
                            isEvents = Convert.ToBoolean(dtAddOns.Tables[0].Rows[i]["IsVisible"]);
                            eventsTabName = Convert.ToString(dtAddOns.Tables[0].Rows[i]["TabName"]);
                        }
                        if (Convert.ToString(dtAddOns.Tables[0].Rows[i]["ButtonType"]) == "Bulletins")
                        {
                            isBulletins = Convert.ToBoolean(dtAddOns.Tables[0].Rows[i]["IsVisible"]);
                            bulletinsTabName = Convert.ToString(dtAddOns.Tables[0].Rows[i]["TabName"]);
                        }
                        if (Convert.ToString(dtAddOns.Tables[0].Rows[i]["ButtonType"]) == "WebLinks")
                        {
                            isWebLinks = Convert.ToBoolean(dtAddOns.Tables[0].Rows[i]["IsVisible"]);
                            weblinksTabName = Convert.ToString(dtAddOns.Tables[0].Rows[i]["TabName"]);
                        }
                        if (Convert.ToString(dtAddOns.Tables[0].Rows[i]["ButtonType"]) == "SocialMedia")
                        {
                            isSocialMedia = Convert.ToBoolean(dtAddOns.Tables[0].Rows[i]["IsVisible"]);
                            socialMediaTabName = Convert.ToString(dtAddOns.Tables[0].Rows[i]["TabName"]);
                        }
                        if (Convert.ToString(dtAddOns.Tables[0].Rows[i]["ButtonType"]) == "Surveys")
                        {
                            isSurveys = Convert.ToBoolean(dtAddOns.Tables[0].Rows[i]["IsVisible"]);
                            surveysTabName = Convert.ToString(dtAddOns.Tables[0].Rows[i]["TabName"]);
                        }
                        if (Convert.ToString(dtAddOns.Tables[0].Rows[i]["ButtonType"]) == "Notifications")
                        {
                            isNotificaton = Convert.ToBoolean(dtAddOns.Tables[0].Rows[i]["IsVisible"]);
                            notification = Convert.ToString(dtAddOns.Tables[0].Rows[i]["TabName"]);
                        }
                        if (Convert.ToString(dtAddOns.Tables[0].Rows[i]["ButtonType"]) == "Tips")
                        {
                            isSubmitTip = Convert.ToBoolean(dtAddOns.Tables[0].Rows[i]["IsVisible"]);
                            submitTip = Convert.ToString(dtAddOns.Tables[0].Rows[i]["TabName"]);
                        }
                    }
                }

                xmlSettings = "<Tools BName='" + isBusinessName + "' Logo='" + isLogo + "'  Address='" + isAddress + "'  City='" + isCity + "'  State='" + isState + "' Country='" + isCountry + "' ZipCode='" + isZipcode + "'" +
                "  PhoneNumber='" + isPhoneNumber + "'  AboutUs='" + isAboutUs + "'  Updates='" + isUpdates + "' " +
                "  Social='" + isSocialMedia + "'   Photos='" + isPhotoAlbum + "' Events='" + isEvents + "' " +
                " IsSurveys='" + isSurveys + "'  IsBulletins='" + isBulletins + "'   IsContatUs='" + isContactUs + "'   " +
                " IsPhotoCapture='" + isPhotoCapture + "' IsWebLinks='" + isWebLinks + "' IsGeoLocation='" + isGeoLocation + "'  " +
                " IsSharing='" + isSharing + "'  IsAnonymous='" + isAnonymous + "'  " +
                " IsEmergencyNumber='" + isEmergencyNumber + "' EmergencyNumber='" + ReplaceSpecialCharacters(txtEmrgncyNumber.Text.Trim()) + "' " +
                " IsMainPH='" + IsMainPH + "' IsSubmitTip='" + isSubmitTip + "' HomeTabName='Home' ContactUsTabName='Contact Us'" +
                " IsNotificaton='" + isNotificaton + "' NotificationTabName='" + notification + "' AboutUsTabName='" + aboutUsTabName + "' " +
                " UpdatesTabName='" + updatesTabName + "' MediaTabName='" + galleryTabName + "'  EventsTabName='" + eventsTabName + "' " +
                " BulletinsTabName='" + bulletinsTabName + "' WeblinksTabName='" + weblinksTabName + "' SocialMediaTabName='" + socialMediaTabName + "' " +
                " SurveysTabName='" + surveysTabName + "' SubmitTipName='" + submitTip + "' IsContact_Tips_CustomMessage='" + IsContact_Tips_CustomMessage + "' " +
                " Contact_Tips_CustomMessage='" + ReplaceSpecialCharacters(txtContact_Tip_CustomMessage.Text.Trim()) + "'   />";

                xmlSettings = "<SubTools>" + xmlSettings + "</SubTools>";

                Session["SettingID"] = objMobileApp.InsertMobileAppSettings(Convert.ToInt32(Session["SettingID"]), xmlSettings, Convert.ToInt32(Session["UserID"]), isEnableMobileApp, CUserID, emergencyPhoneNumber, txtalternateph.Text.Trim());

                // *** Submiting communication email *** //
                try
                {
                    DataTable dtobj = conobj.GetUserDetails(Session["username"].ToString(), DomainName);
                    if (dtobj.Rows.Count > 0)
                        conobj.ModifyConsumer(Session["username"].ToString(), txtCommEmail.Text.Trim(), dtobj.Rows[0]["Firstname"].ToString(), dtobj.Rows[0]["Lastname"].ToString(), roleId, true, dtobj.Rows[0]["User_address1"].ToString(), dtobj.Rows[0]["User_address2"].ToString(), dtobj.Rows[0]["User_city"].ToString(), dtobj.Rows[0]["User_state"].ToString(), "USA", dtobj.Rows[0]["User_zipcode"].ToString(), dtobj.Rows[0]["User_phone"].ToString(), UserID, status, ProfileID);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                lblstatusmessage.Text = "Settings have been updated successfully.";
                objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "MobileAppSettings", "Update");
                uppnlpopup1.Focus();
                if (btncancelupdate.Visible == false)
                {
                    objBus.UpdateDashboardFlow(UserID, 3, CUserID);
                    Session["DashboardFlow"] = "1";
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
                }
                ScriptManager.RegisterStartupScript(btnUpdate, this.GetType(), "Script", "DisableCommunication()", true);
            }
            catch (Exception ex)
            {
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "MobileAppSettings.aspx.cs", "btnUpdate_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btncancelupdate_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }

        public string ReplaceSpecialCharacters(string inputString)
        {

            inputString = inputString.Replace("&", "&amp;");
            inputString = inputString.Replace("&amp;amp;", "&amp;");


            inputString = inputString.Replace("'", "&apos;");
            inputString = inputString.Replace("&amp;apos;", "&apos;");

            inputString = inputString.Replace("<", "&lt;");

            inputString = inputString.Replace(">", "&gt;");

            return inputString;
        }

        public string RevertSpecialCharacters(string inputString)
        {

            inputString = inputString.Replace("&amp;", "&");

            inputString = inputString.Replace("&apos;", "'");

            inputString = inputString.Replace("&lt;", "<");

            inputString = inputString.Replace("&gt;", ">");

            return inputString;
        }
    }
}