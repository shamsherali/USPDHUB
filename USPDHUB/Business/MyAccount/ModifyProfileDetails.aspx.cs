using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using USPDHUBBLL;
using Winnovative.WnvHtmlConvert;
using System.Text;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Xml.Linq;

public partial class Business_MyAccount_ModifyProfileDetails : BaseWeb
{
    public int UserID = 0;
    public int ProfileID = 0;
    BusinessBLL _objBus = new BusinessBLL();
    public int C_UserID = 0;
    public static DataTable dtpermissions = new DataTable();
    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
    AgencyBLL agencyobj = new AgencyBLL();
    CommonBLL objCommon = new CommonBLL();
    public string DomainName = "";
    USPDHUBBLL.MobileAppSettings objMobileApp = new USPDHUBBLL.MobileAppSettings();
    string xmlSettings = string.Empty;
    Consumer conobj = new Consumer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] == null)
                Response.Redirect(Page.ResolveClientUrl("~/login.aspx?sflag=1"));
            else
            {
                UserID = Convert.ToInt32(Session["UserID"]);
                if (Session["ProfileID"] != null)
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);

                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    C_UserID = UserID;
            }
            // *** Make back button visible and disable by query string 26-03-2013 *** //
            if (!string.IsNullOrEmpty(Request.QueryString["App"] as string))
                btnBack.Visible = true;
            else
                btnBack.Visible = false;

            lblstatusmessage.Text = "";
            DomainName = Session["VerticalDomain"].ToString();
           
            if (!IsPostBack)
            {
                BindCountry();
                // *** Adding page title and meta keys for page *** //
                DataTable dtConfigPageKeys = objCommon.GetVerticalConfigsByType(DomainName, "VerticalNames");
                if (dtConfigPageKeys.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigPageKeys.Rows)
                    {
                        if (row[0].ToString() == "NameForDisplay")
                            hdnVerticalName.Value = row[1].ToString();
                    }
                }
                LoadIntialSubscriptionvalues();
                if (Session["ProfileUpdate"] != null && Session["ProfileUpdate"].ToString() != "")
                {
                    lblstatusmessage.Text = Session["ProfileUpdate"].ToString();
                    Session["ProfileUpdate"] = null;
                }

                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                    if (hdnPermissionType.Value == "A")
                    {
                        btncontinue.Enabled = false;
                        lblstatusmessage.Text = "<font face=arial size=2 color=red>You do not have permission to update app details.</font>";
                    }
                }
                //ends here
                //Updating the dashboard flow without cliking the update button
                if (!string.IsNullOrEmpty(Request.QueryString["Check"] as string)) 
                {
                    if (UpdateProfileDeatils())
                    {
                        _objBus.UpdateDashboardFlow(UserID, 1, C_UserID);
                        
                    }
                 
                }
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyProfileDetails.aspx.cs", "Page_Load", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private void BindCountry()
    {
        DataTable dtCountry = new DataTable();
        dtCountry = objCommon.GetCountries();
        ddlCountry.DataSource = dtCountry;
        ddlCountry.DataTextField = "Country_Name";
        ddlCountry.DataValueField = "Country_Name";
        ddlCountry.DataBind();
       
        //ddlCountry.Items.Insert(0, "Select Country");
    }
    private void LoadIntialSubscriptionvalues()
    {
        try
        {
            string days = string.Empty;
            string hours = string.Empty;
            DataTable dtobj = _objBus.GetProfileDetailsByProfileID(ProfileID);
            if (dtobj.Rows.Count == 1)
            {
                // Check For Type of Business
                txtBusinessname.Text = dtobj.Rows[0]["Profile_name"].ToString();
                hdncontactname.Value = dtobj.Rows[0]["Profile_Contact_Name"].ToString();
                txtaddress1.Text = dtobj.Rows[0]["Profile_StreetAddress1"].ToString();
                txtaddress2.Text = dtobj.Rows[0]["Profile_StreetAddress2"].ToString();
                txtcity.Text = dtobj.Rows[0]["Profile_City"].ToString();
                txtState.Text = dtobj.Rows[0]["Profile_State"].ToString();
                
                if (dtobj.Rows[0]["Profile_County"].ToString() != "")
                {
                    ddlCountry.SelectedValue = dtobj.Rows[0]["Profile_County"].ToString();
                }
                else
                {
                    DataTable dtobj1 = _objBus.GetUserDetailsByUserID(UserID);
                    if (dtobj1.Rows.Count == 1)
                    {
                        ddlCountry.SelectedValue = dtobj1.Rows[0]["User_Country"].ToString();
                    }
                }

                hdnIsLiteVersion.Value = Convert.ToString(dtobj.Rows[0]["IsLiteVersion"]);

                txtzipcode.Text = dtobj.Rows[0]["Profile_Zipcode"].ToString();
                txtphonenumber.Text = dtobj.Rows[0]["Profile_Phone1"].ToString();
                //txtAlternateCall.Text = dtobj.Rows[0]["Profile_Phone1"].ToString();
                string TimezoneID = dtobj.Rows[0]["TimeZoneID"].ToString();
                ddlTimeZone.SelectedValue = TimezoneID;
                // *** Issue 1186 *** //
                if (dtobj.Rows[0]["Mobile_Number"] != null)
                    txtmobile.Text = dtobj.Rows[0]["Mobile_Number"].ToString();
                // *** Fix for IRHM 1.1 Web changes 25-02-2013 *** //
                if (!string.IsNullOrEmpty(dtobj.Rows[0]["Alternate_Phone"].ToString()))
                    txtAlternateCall.Text = dtobj.Rows[0]["Alternate_Phone"].ToString();

                if (dtobj.Rows[0]["Profile_Phone2"].ToString().Length > 0)
                {
                    txtextenction.Text = dtobj.Rows[0]["Profile_Phone2"].ToString();
                }
                txtfaxnumber.Text = dtobj.Rows[0]["Profile_Fax"].ToString();
                lbllastmodified.Text = dtobj.Rows[0]["MODIFIED_DT"].ToString();
            }
            string url = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
            //string countryValue = "United States";
            //if (url.Contains(ConfigurationManager.AppSettings["UrlInschoolIndia"]))
            //    countryValue = "India";
            string countryValue = ddlCountry.SelectedItem.Text.ToString().Trim();
            // *** Binding Time Zones *** //
            DataTable dtTimeZones = _objBus.GetTimeZones(countryValue);
            if (dtTimeZones.Rows.Count > 0)
            {
                ddlTimeZone.DataSource = dtTimeZones;
                ddlTimeZone.DataTextField = "Display_Name";
                ddlTimeZone.DataValueField = "TimeZone_ID";
                ddlTimeZone.DataBind();
            }

            LoadMobileAppSettings();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyProfileDetails.aspx.cs", "LoadIntialSubscriptionvalues", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private void LoadMobileAppSettings()
    {
        try
        {
            DataTable dtMobileAppSettings = objMobileApp.GetMobileAppSetting(UserID);
            if (dtMobileAppSettings.Rows.Count > 0)
            {
                xmlSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                Session["SettingID"] = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingID"]);
                var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                bool isMainPH = false;
                //CONTACT DETAILS           
                if (xmlTools.Element("Tools").Attribute("IsMainPH") != null)
                    isMainPH = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsMainPH").Value);

                if (isMainPH)
                    rbPhone.Checked = true;
                else
                    rbAlternate.Checked = true;
            }
            // *** Adding communication email field 30-05-2013 *** //
            DataTable dtobj = conobj.GetUserDetails(Session["username"].ToString(), DomainName);
            txtCommEmail.Text = Session["username"].ToString();
            if (dtobj.Rows.Count > 0)
                txtCommEmail.Text = dtobj.Rows[0]["User_email"].ToString();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyProfileDetails.aspx.cs", "LoadMobileAppSettings", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void Modify_Profile(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/BUsiness/MyAccount/Default.aspx"));

    }
    protected void Modify_Continue(object sender, EventArgs e)
    {
        try
        {
            if (UpdateProfileDeatils())
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Check"] as string))
                {
                    _objBus.UpdateDashboardFlow(UserID, 1, C_UserID);
                    Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
                }
                Session["ProfileUpdate"] = "Your changes have been updated successfully.";
                _objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "ProfileAddres_Call", "Update");
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ModifyProfileDetails.aspx") + (!string.IsNullOrEmpty(Request.QueryString["App"] as string) ? "?App=" + Request.QueryString["App"] : ""));
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyProfileDetails.aspx.cs", "Modify_Continue", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private bool UpdateProfileDeatils()
    {
        string businessname = txtBusinessname.Text.Trim();
        string contactname = hdncontactname.Value;
        string address1 = txtaddress1.Text;
        string address2 = txtaddress2.Text;
        string cityname = txtcity.Text;
        string statename = txtState.Text;
        //if (drpState.SelectedValue != "0")
        //    statename = drpState.SelectedItem.Text.ToString().Trim();
        //else
        //    statename = "";
        string countryname = string.Empty;
        countryname = ddlCountry.SelectedItem.Text.ToString().Trim();
        //if (ddlCountry.SelectedValue != "0")
        //    countryname = ddlCountry.SelectedItem.Text.ToString().Trim();
        //else
        //    countryname = "";
        int timezoneid = 0;
        if (ddlTimeZone.SelectedValue != "0")
            timezoneid = Convert.ToInt32(ddlTimeZone.SelectedValue);
        string zipcode = txtzipcode.Text;
        string days = string.Empty;
        string extenction = string.Empty;
        extenction = txtextenction.Text.ToString();
        string businessdesc = string.Empty;
        string businessduration = string.Empty;
        int noofemp = 0;
        string bussmission = string.Empty;
        string Corevalues = string.Empty;
        string productdesc = string.Empty;
        string localmembership = string.Empty;

        string phonenum = txtphonenumber.Text.Trim();
        string mobilenum = txtmobile.Text.Trim();
        string faxnumber = txtfaxnumber.Text;
        // *** Fix for IRHM 1.1 Web Changes 25-02-2013 *** //
        string alternatephone = txtAlternateCall.Text;
        // *** Issue 1133 *** //
        businessduration = "";
        productdesc = "";
        localmembership = "";
        string noofemployees = "";
        if (noofemployees.Length > 0)
        {
            noofemp = Convert.ToInt32(noofemployees);
        }
        DataTable dtobj = _objBus.GetProfileDetailsByProfileID(ProfileID);
        string description_EditHTML = "";
        bool isMobileAppEnabled = true;
        if (dtobj.Rows.Count > 0)
        {
            businessdesc = dtobj.Rows[0]["Profile_Description"].ToString();
            description_EditHTML = dtobj.Rows[0]["Description_Edit_HTML"].ToString();
            if (Convert.ToString(dtobj.Rows[0]["EnableMobileApp"]) != string.Empty)
                isMobileAppEnabled = Convert.ToBoolean(dtobj.Rows[0]["EnableMobileApp"]);
        }
        int updateflag = 0;
        int updatedesc = 0;
        int bushours = 1;

        if (bushours > 0)
        {
            #region Getting Latidude & longtidude values
            //Getting Latidude & longtidude values
            string fullAddress = txtaddress1.Text.Trim() + "," + txtcity.Text.Trim() + "," + txtState.Text.Trim() + "," + countryname + "," + txtzipcode.Text.Trim();
            Coordinate coordinates = Geocode.GetCoordinates(fullAddress);
            double latitude1 = Convert.ToDouble(coordinates.Latitude);
            double longitude1 = Convert.ToDouble(coordinates.Longitude);
            #endregion

            //Update Profile Details
            updateflag = _objBus.UpdateBusinessProfileDetails(businessname, businessdesc, contactname, "", "", address1, address2, cityname, statename,countryname,
                 zipcode, phonenum, extenction, faxnumber, UserID, ProfileID, mobilenum, alternatephone, latitude1, longitude1, C_UserID, description_EditHTML, timezoneid);

            updatedesc = _objBus.Updateprofiledescription(ProfileID, businessduration, noofemp, localmembership, businessdesc, productdesc, C_UserID);
            Session["firstname"] = businessname;
            Session["profilename"] = businessname;
            UpdateMobileAppSettings(isMobileAppEnabled);
            // Save User Activity Log
            objCommon.InsertUserActivityLog("has updated his profile name as <b>" + Session["profilename"] + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);


        }
        if (updateflag > 0 && updatedesc > 0 && bushours > 0)
        {
            return true;
        }
        else
            return false;
    }
    private void UpdateMobileAppSettings(bool isMobileAppEnabled)
    {
        try
        {
            int roleId = (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business;
            string status = USPDHUBBLL.UtilitiesBLL.Statuses.Active.ToString();
            string EmergncyNumber = "";
            DataTable dtDefaultProfileTabs = _objBus.GetDefaultProfileTabNames(DomainName);
            for (int k = 0; k < dtDefaultProfileTabs.Rows.Count; k++)
            {
                if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "EmergencyNumber")
                    EmergncyNumber = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
            }
            bool isBusinessName = false;
            bool isLogo = false;
            bool isAddress = false;
            bool isCity = false;
            bool isState = false;
            bool isCountry = false;
            bool isZipcode = false;
            bool isEmergencyNumber = false;
            bool isPhone = false;
            bool isPhoneNumber = false;
            bool isContactUs = false;
            bool isPushNotifications = false;
            bool isPhotoCapture = false;
            bool isGeoLocation = false;
            bool isSharing = false;
            bool isGPS = false;
            bool isAnonymous = false;
            DataTable dtMobileAppSettings = objMobileApp.GetMobileAppSetting(UserID);
            int settingID = 0;
            if (dtMobileAppSettings.Rows.Count > 0)
            {
                xmlSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                settingID = Convert.ToInt32(dtMobileAppSettings.Rows[0]["M_SettingID"]);
                var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);
                //BUSINESS DETAILS
                isBusinessName = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("BName").Value);
                isLogo = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Logo").Value);
                isAddress = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Address").Value);
                isCity = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("City").Value);
                isState = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("State").Value);
                isCountry = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("Country").Value);
                isZipcode = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("ZipCode").Value);
                if (xmlTools.Element("Tools").Attribute("IsEmergencyNumber") != null)
                    isEmergencyNumber = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsEmergencyNumber").Value);

                if (xmlTools.Element("Tools").Attribute("PhoneNumber").Value != null)
                    isPhone = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("PhoneNumber").Value);
                isPhoneNumber = isPhone;
                isContactUs = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsContatUs").Value);
                if (xmlTools.Element("Tools").Attribute("IsPushNotifications") != null)
                    isPushNotifications = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsPushNotifications").Value);
                if (xmlTools.Element("Tools").Attribute("IsPhotoCapture") != null)
                    isPhotoCapture = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsPhotoCapture").Value);
                if (xmlTools.Element("Tools").Attribute("IsGeoLocation") != null)
                    isGeoLocation = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsGeoLocation").Value);


                if (xmlTools.Element("Tools").Attribute("IsSharing") != null)
                    isSharing = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsSharing").Value);

                if (xmlTools.Element("Tools").Attribute("IsGPS") != null)
                    isGPS = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsGPS").Value);


                if (xmlTools.Element("Tools").Attribute("IsAnonymous") != null)
                    isAnonymous = Convert.ToBoolean(xmlTools.Element("Tools").Attribute("IsAnonymous").Value);


                if (xmlTools.Element("Tools").Attribute("EmergencyNumber") != null)
                    EmergncyNumber = Convert.ToString(xmlTools.Element("Tools").Attribute("EmergencyNumber").Value);

            }

            AddOnBLL objAddOn = new AddOnBLL();
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
            bool isAboutUs = false;
            bool isUpdates = false;
            bool isPhotoAlbum = false;
            bool isEvents = false;
            bool isBulletins = false;
            bool isWebLinks = false;
            bool isSocialMedia = false;
            bool isSurveys = false;
            bool isNotificaton = false;
            bool isSubmitTip = false;
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
            " IsEmergencyNumber='" + isEmergencyNumber + "' EmergencyNumber='" + EmergncyNumber + "' " +
            " IsMainPH='" + rbPhone.Checked + "' IsSubmitTip='" + isSubmitTip + "' HomeTabName='Home' ContactUsTabName='Contact Us'" +
            " IsNotificaton='" + isNotificaton + "' NotificationTabName='" + notification + "' AboutUsTabName='" + aboutUsTabName + "' " +
            " UpdatesTabName='" + updatesTabName + "' MediaTabName='" + galleryTabName + "'  EventsTabName='" + eventsTabName + "' " +
            " BulletinsTabName='" + bulletinsTabName + "' WeblinksTabName='" + weblinksTabName + "' SocialMediaTabName='" + socialMediaTabName + "' " +
            " SurveysTabName='" + surveysTabName + "' SubmitTipName='" + submitTip + "'/>";

            xmlSettings = "<SubTools>" + xmlSettings + "</SubTools>";

            Session["SettingID"] = objMobileApp.InsertMobileAppSettings(settingID, xmlSettings, UserID, isMobileAppEnabled, C_UserID, EmergncyNumber, txtAlternateCall.Text.Trim());

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
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyProfileDetails.aspx.cs", "UpdateMobileAppSettings", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(Request.QueryString["App"] as string) && Request.QueryString["App"].ToString() == "2")
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageAppButtons.aspx"));
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ModifyProfileDetails.aspx.cs", "btnBack_Click", ex.Message,
             Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btndashboard_Click(object sender, EventArgs e)
    {
        string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/Default.aspx");
        Response.Redirect(urlinfo);
    }
}
