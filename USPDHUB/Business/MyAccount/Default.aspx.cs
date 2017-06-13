using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.IO;
using QRCoder;
using System.Drawing;
using System.Xml;
using System.Text;

public partial class Business_MyAccount_Default : BaseWeb
{
    public int ProfileStaticsCount = 0;
    public int ProfileUnqiqueVistits = 0;
    public int ActiveCouponsCount = 0;
    public int EmailCamapignCount = 0;
    public int ProfileIndustriesCount = 0;
    public int ProfileCitiesCount = 0;
    public int AffiliatesCount = 0;
    public int NewsletterActiveCount = 0;
    public int ProfileID = 0;
    public int UserID = 0;
    public string ProfileLastUpdated = string.Empty;
    public string ProfileLogoPath = string.Empty;
    public DataTable DtUpdatesProfiles = new DataTable();
    public string PercentageImageUrl = string.Empty;
    public string ResellerUrl = string.Empty;
    public string UniqueUrlText = string.Empty;
    public int CheckUnqiueFolder = 0;
    public int CheckResller = 0;
    public int CheckLogo = 0;
    public int Photoscount = 0;
    public int Videoscount = 0;
    public int Couponsscount = 0;
    public int Newslettercount = 0;
    public int Affiliatecount = 0;
    public int Activeeventscount = 0;
    public int Activebusinessupdatescount = 0;
    public int FreetrialRemainingdays = 0;
    string profileUrl = string.Empty;
    public DataTable DTMyProfileUpdates = new DataTable();
    public int FreeFlag = 0;
    AdminBLL adminobj = new AdminBLL();
    BusinessBLL busobj = new BusinessBLL();
    EventCalendarBLL objEventCalendar = new EventCalendarBLL();
    Consumer conObj = new Consumer();
    MenuDashBoard objMenuDash = new MenuDashBoard();
    BusinessUpdatesBLL objBusinessUpdates = new BusinessUpdatesBLL();
    AgencyBLL agencyobj = new AgencyBLL();
    AddOnBLL objAddOn = new AddOnBLL();
    CommonBLL cmbobj = new CommonBLL();

    USPDHUBBLL.MobileAppSettings objMobileApp = new USPDHUBBLL.MobileAppSettings();
    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
    public string ExpDaysalert = string.Empty;
    public string CCExpDaysalert = string.Empty;
    public string NotificationAlert = string.Empty;
    public bool IsContacts = true;
    public bool IsMedia = true;
    public bool Update = true;
    public bool IsUpdate = true;
    public bool Event = true;
    public bool IsEvent = true;
    public bool MobileApp = true;
    public bool IsMobileApp = true;
    public bool IsBulletins = true;
    public bool Bulletins = true;
    public bool Media = true;
    public bool Contacts = true;
    public bool Messages = true;
    public bool PushNotifications = true;
    public bool Surveys = true;
    public bool Home = true;
    public bool AboutUs = true;
    public bool WebLinks = true;
    public bool SocialMedia = true;
    public bool Gallery = true;
    public bool IsAppStastics = true;
    public bool PublicCallAddOn = true;
    public int CUserID = 0;
    public bool CheckProfile = true;
    public bool CheckDescription = true;
    public bool CheckAppSettings = true;
    DataTable dtpermissions = new DataTable();
    public string RootPath = "";
    public string DomainName = "";
    public string DomainNameenc = "";
    public string DisplayName = "";
    public string VerticalType = "";
    public string MemID = "";
    public string MemPID = "";
    public string CID = "";
    string xmlSettings = string.Empty;
    public bool IsDownloadAccess = true;
    public int AllowedMemory = 2;
    #region Tabs Button Name

    public string GalleryButtonName = "";
    public string UpdatesButtonName = "";
    public string EventButtonName = "";
    public string SurveyButtonName = "";
    public string BulletinsButtonName = "";
    public string NotificationButtonName = "";
    public string MessagesButtonName = "";

    #endregion

    public bool IsCustomModulAccess = false;
    public bool IsPrivateCustomModulAccess = false;
    public bool IsPrivateCallAccess = false;
    public bool IsPublicCallAccess = false;
    public bool IsCalendarAddOnsAccess = false;
    public bool IsPrivateSmartConnectAccess = false;
    public bool IsBannerAdsAccess = false;
    DataTable dtPurchaseAddOns = new DataTable("dtPurchaseAddOns");
    DataTable dtCustomModuleTemplates = new DataTable("dtCustomModuleTemplates");
    DataTable dtCustomModuleAppIcons = new DataTable("dtCustomModuleAppIcons");
    public bool IsAdmin = true;
    public bool IsShowUpgradeISAMessage = false;

    public string IsLiteVersionEncript = "";
    string emailInfo = "";
    string profileName = "";
    string UserId = "";
    string Parent_ProfileID = "";
    public bool GettingIsDescription = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // **************** Get Domain Name *******************
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            // btnPremium.ImageUrl = "~/images/Dashboard/Premium.png";
            //btnBrandedeApp.ImageUrl = "~/images/Dashboard/BrandedApp.png";
            //Making CustomModuleId Session Null For Private Module SMS Notification

            Session["CustomModuleID"] = null;
            // *** Chcking for user session ***
            if (Session["UserID"] == null || Session["ProfileID"] == null)
            {
                string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                Response.Redirect(urlinfo);
            }
            else
            {
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                MemID = EncryptDecrypt.DESEncrypt(UserID.ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                lblSubAppInvitation.Text = "";

                if (!IsPostBack)
                {
                    Session["searchedKeywords"] = null;
                    DataTable dtProfile = busobj.GetProfileDetailsByProfileID(ProfileID);
                    if (dtProfile.Rows[0]["Parent_ProfileID"] != null)
                    { Parent_ProfileID = dtProfile.Rows[0]["Parent_ProfileID"].ToString(); }

                    UserId = dtProfile.Rows[0]["User_ID"].ToString();
                    profileName = dtProfile.Rows[0]["Profile_Name"].ToString();
                    //getProfileDetails(ProfileID);
                    Session["IsLiteVersion"] = "false";
                    if (dtProfile.Rows.Count > 0)
                    {
                        Session["IsLiteVersion"] = dtProfile.Rows[0]["IsLiteVersion"].ToString();
                        hdnPackageID.Value = EncryptDecrypt.DESEncrypt(dtProfile.Rows[0]["ProfileSubTypeID"].ToString());
                    }
                    else
                        hdnPackageID.Value = EncryptDecrypt.DESEncrypt("0");
                    Session["PackageSettings"] = Convert.ToString(dtProfile.Rows[0]["PackageSettings"]);
                    GettingIsDescription = cmbobj.IsPackageIncludeSetting(PackageIncludeSettingsAttributes.GettingIsDescription);

                    /*
                    if (Convert.ToBoolean(dtProfile.Rows[0]["IsLiteVersion"]) && DomainName.ToLower().Equals("inschoolalertcom"))
                        Response.Redirect("LiteDashboard.aspx");
                    else
                        Session["IsLiteVersion"] = dtProfile.Rows[0]["IsLiteVersion"].ToString();
                    */
                }
                MemPID = EncryptDecrypt.DESEncrypt(ProfileID.ToString());
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
                CID = EncryptDecrypt.DESEncrypt(CUserID.ToString());
            }

            if (Session["IsLiteVersion"] != null)
                IsLiteVersionEncript = EncryptDecrypt.DESEncrypt(Session["IsLiteVersion"].ToString());
          


            # region Dash Board Alerts

            try
            {
                // *** Counting all notifications ***
                DataTable dtalerts = new DataTable();
                dtalerts = conObj.GetSystemAlerts(false, UserID);
                lblalerts.Text = dtalerts.Rows.Count.ToString();

                // *** Counting Newsletter Email Contacts ***
                DataTable dtEmailcontacts = new DataTable();
                dtEmailcontacts = cmbobj.GetEmailContacts(false, UserID);
                lblEmailContacts.Text = dtEmailcontacts.Rows.Count.ToString();


                /*** Getting All App Related Messages Count ***/
                DataTable dtAppMessagesCount = cmbobj.GetAllAppMessagesCountForDashboard(UserID, ProfileID);
                // *** Counting Mobile Newsletter alerts - Contact Us *** 
                lblmobilenewsletter.Text = dtAppMessagesCount.Rows[0]["ContactMessagesCount"].ToString();
                // *** Counting Mobile Newsletter alerts - Tips *** 
                lblmobiletips.Text = dtAppMessagesCount.Rows[0]["TipsMessagesCounts"].ToString();
                // *** Private Calls Count *** 
                lblPrivateCallAlert.Text = dtAppMessagesCount.Rows[0]["PrivateCallMessagesCount"].ToString();
                // *** Public Calls Count - SmartConnect *** 
                lblPublicCallAlert.Text = dtAppMessagesCount.Rows[0]["PublicCallMessagesCount"].ToString();
                // ***Private SmartConnect Count **--
                lblPSCMessagesCount.Text = dtAppMessagesCount.Rows[0]["PSCMessageCount"].ToString();


                // *** Notification Alert *** //
                if (ExpDaysalert != "" || CCExpDaysalert != "" || FreeFlag != 0 || dtalerts.Rows.Count != 0 || lblmobilenewsletter.Text != "0" ||
                    lblmobiletips.Text != "0" || dtEmailcontacts.Rows.Count != 0 || lblMasterGalMemory.Text != ""
                    || lblPublicCallAlert.Text != "0" || lblPSCMessagesCount.Text != "0" || lblPrivateCallAlert.Text != "0")
                {
                    NotificationAlert = "1";
                }
                // *** End Notification Alert *** //
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "Dash Board Alerts -- Line: 286", Convert.ToString(ex.Message),
                  Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }


            // *** Counting Master Library memory usage ***
            string path = Server.MapPath("~") + "//UpLoad//MasterGallery//" + ProfileID;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            DirectoryInfo info = new DirectoryInfo(path);
            long size = 0;
            long filesize = 0;
            foreach (string file in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
            {
                filesize = new FileInfo(file).Length;
                size += filesize;
            }
            double size1 = Math.Round((double)size / (double)(1024 * 1024 * 1024), 2);// +" MB";

            var dtProfileDetails = busobj.GetProfileDetailsByProfileID(ProfileID);
            if (dtProfileDetails.Rows.Count > 0)
            {
                AllowedMemory = Convert.ToInt32(dtProfileDetails.Rows[0]["MasterGallery_Memory"]);
            }
            double percentSize = Math.Round((size1 * 100) / AllowedMemory, 0);
            if (percentSize >= 80)
                lblMasterGalMemory.Text = percentSize.ToString();
            
            # endregion

         

            // *** Get Domain Name *** //            
            DomainNameenc = EncryptDecrypt.DESEncrypt(DomainName);
            DataTable objectDt = new DataTable();
            objectDt = conObj.GetUserDetailsByID(UserID);
            Session["BusinessUserFirstName"] = objectDt.Rows[0]["Firstname"].ToString();

            // *** Adding page title and meta keys for page *** //
            DataTable dtConfigPageKeys = cmbobj.GetVerticalConfigsByType(DomainName, "VerticalNames");
            if (dtConfigPageKeys.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigPageKeys.Rows)
                {
                    if (row[0].ToString() == "NameForDisplay")
                        DisplayName = row[1].ToString();
                }
            }
            # region Check for New User
            // *** Check For New User ***
            DataTable dtprofile = new DataTable();
            dtprofile = busobj.GetBusinessDeatilsByUserID(UserID);
            if (dtprofile.Rows.Count > 0)
            {
                DataTable dtobjforpasswprd = new DataTable();
                int passwordchanged = 0;
                dtobjforpasswprd = conObj.GetUserDetailsByID(UserID);
                if (dtobjforpasswprd.Rows.Count > 0)
                {
                    if (dtobjforpasswprd.Rows[0]["Password_Changed"].ToString().Length > 0)
                    {
                        if ((Convert.ToInt32(dtobjforpasswprd.Rows[0]["Password_Changed"].ToString()) == 1))
                        {
                            passwordchanged = 1;
                        }
                    }
                }
                if (passwordchanged == 0)
                {
                    string urlpasswordredirection = Page.ResolveClientUrl("~/Business/MyAccount/Changepassword.aspx?CPD=ActivateUser");
                    Response.Redirect(urlpasswordredirection);
                }
            }


            // End

            # endregion

            # region Check for User Name and For Free User
            // *** Start Checking for User Name and For Free User ***
            DataTable dtobj = new DataTable();
            dtobj = conObj.GetUserDetailsByID(UserID);
            if (dtobj.Rows.Count == 1)
            {
                if (!string.IsNullOrEmpty(Session["Firstname"] as string))
                {
                    string tmpfirstname = Session["Firstname"].ToString().Substring(0, 1).ToUpper() + Session["Firstname"].ToString().Substring(1, Session["Firstname"].ToString().Length - 1);
                    Session["Firstname"] = tmpfirstname;
                }
                if (dtobj.Rows[0]["IsFree"].ToString() != "")
                {
                    if (Convert.ToBoolean(dtobj.Rows[0]["IsFree"].ToString()) == true)
                    {
                        FreeFlag = 1;
                    }
                }
            }
            //  *** End Checking for User Name and For Free User ***

            # endregion
            DataTable dtLUser = busobj.GetUserDtlsByUserID(CUserID);
            # region Play Video After 2.0 Move
            if (Convert.ToBoolean(dtLUser.Rows[0]["IsLaunchPlay"].ToString()) == true)
                hdnLaunchPlay.Value = "Yes";
            else
                hdnLaunchPlay.Value = "No";
            # endregion Play Video After 2.0 Move
            if (Session["UserLogin"] != null)
            {
                if (Convert.ToBoolean(dtLUser.Rows[0]["IsVersionPlay"].ToString()) == true)
                    hdnVersionPlay.Value = "Yes";
                else
                    hdnVersionPlay.Value = "No";
                Session["UserLogin"] = null;
            }

            
            # region Check For User Subscription

            // *** Get User SubscriptionDetails and show expiration ***
            // *** if Paid user ***
            if (FreeFlag == 0)
            {
                int expdays = 0;
                DataTable dtSubscriptionDetails = new DataTable();
                dtSubscriptionDetails = busobj.GetOrderSubscriptionByProfileID(Convert.ToInt32(Session["ProfileID"].ToString()));
                if (dtSubscriptionDetails.Rows.Count > 0)
                {
                    DateTime renewalDate;
                    renewalDate = Convert.ToDateTime(dtSubscriptionDetails.Rows[0]["subscription_renewal_date"].ToString());
                    DateTime currentDate = DateTime.Now.Date;
                    TimeSpan rnts = renewalDate.Subtract(currentDate);
                    int nODays = rnts.Days;
                    if (dtSubscriptionDetails.Rows[0]["fullperiod"].ToString() == "1")
                        expdays = Convert.ToInt32(ConfigurationManager.AppSettings.Get("NotificationsDaysForMonth"));
                    else
                        expdays = Convert.ToInt32(ConfigurationManager.AppSettings.Get("NotificationsDaysForYear"));
                    // *** Start Issue 1169 *** //
                    if (Session["Renewal"] != null && Session["Renewal"].ToString() == "1")
                    {
                        ExpDaysalert = "1";
                        // *** 1199  *** //
                        if (Convert.ToString(dtSubscriptionDetails.Rows[0]["Discount_Code"]) == "FreeTrial")
                            lblrenew.Text = "Your Free Trial Period has expired. <a href='" + ConfigurationManager.AppSettings.Get("ShoppingCartRootPath") + "/RedirectStore.aspx?MID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&MPID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString()) + "&CID=" + EncryptDecrypt.DESEncrypt(CUserID.ToString()) + "&VC=" + EncryptDecrypt.DESEncrypt(DomainName) + "&type=renewal' style='color:Red;'" + ">Click here</a> to renew.";
                        else
                            lblrenew.Text = "Your subscription has expired. <a href='" + ConfigurationManager.AppSettings.Get("ShoppingCartRootPath") + "/RedirectStore.aspx?MID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&MPID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString()) + "&CID=" + EncryptDecrypt.DESEncrypt(CUserID.ToString()) + "&VC=" + EncryptDecrypt.DESEncrypt(DomainName) + "&type=renewal' style='color:Red;'" + ">Click here</a> to renew.";
                    }
                    else if (!string.IsNullOrEmpty(dtSubscriptionDetails.Rows[0]["Discount_Code"].ToString()))
                    {
                        if (dtSubscriptionDetails.Rows[0]["Discount_Code"].ToString() == "FreeTrial")
                        {
                            FreetrialRemainingdays = nODays;
                            if (FreetrialRemainingdays <= 0)
                            {
                                Session["Free"] = "1";
                                Session["Renewal"] = "1";
                                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
                            }
                            NotificationAlert = "1";
                            lblremainingdays.Text = "Trial (" + nODays + " " + (FreetrialRemainingdays == 1 ? "day" : "days") + " remaining)";
                        }
                    }
                    if (Session["Renewal"] == null && nODays <= expdays)
                    {
                        if (dtSubscriptionDetails.Rows[0]["Card_Type"].ToString() == PaymentModes.BillMe.ToString())
                            lblrenew.Text = Resources.LabelMessages.RenewalAlertCheckProcess.Replace("#RenewalDate#", renewalDate.Date.ToString("MM/dd/yyyy"));
                        else
                            lblrenew.Text = Resources.LabelMessages.RenewalAlert.Replace("#RenewalDate#", renewalDate.Date.ToString("MM/dd/yyyy"));

                        ExpDaysalert = "1";
                    }

                    // *** End Issue 1169 *** //
                    if (dtSubscriptionDetails.Rows[0]["CC_number"].ToString() != "")
                    {
                        string ccnumber = EncryptDecrypt.DESDecrypt(dtSubscriptionDetails.Rows[0]["CC_number"].ToString());
                        if (ccnumber.Length >= 16)
                        {
                            ccnumber = ccnumber.Substring(ccnumber.Length - 4);
                            DateTime ccexpdate = Convert.ToDateTime(dtSubscriptionDetails.Rows[0]["cc_expire_month"].ToString() + "/01/" + dtSubscriptionDetails.Rows[0]["cc_expire_year"].ToString());
                            TimeSpan expts = ccexpdate.Subtract(currentDate);
                            int ccexpdays = expts.Days;
                            if (ccexpdays <= 30)
                            {
                                CCExpDaysalert = "1";
                                lblccexpdate.Text = "Your credit card ending with " + ccnumber + " will be expiring soon. To avoid any disruption to your " + DisplayName + "<sup style='font-size: 12px;'>&reg;</sup> membership. <span><a id='cc' href='javascript:void(0);' onclick='fireServerButtonEvent()' runat='server' >Click Here</a></span> to update your card information.";
                            }
                        }
                    }
                }
            }
            else
            {
                // *** Notifications Changes **** //
                lblfreealert.Text = "Upgrade to take advantage of all the " + DisplayName + "<sup style='font-size:12px;'>&reg;</sup> tools.";
                // *** End Notifications Changes **** //
            }

            // End
         
            # endregion

            GetUpdatedProfileDetails();
            GetDashboardSettingsDtls();
            rightbox.Visible = true;
            if (!IsPostBack)
            {
                //if (Convert.ToBoolean(Session["IsLiteVersion"]) && DomainName.ToLower().Contains("inschoolhub"))
                //{
                //    AddDefaultCallAddOnForLite();
                //}

                #region Display Message for inschool alert upgrade to inschool hub redirect time & only first time  -- April 21 2016

                //IsShowUpgradeISAMessage = Convert.ToBoolean(busobj.ShowMessageForISAUpgrade(ProfileID));

                #endregion


                #region  Checking Banner Ads Permission Create Sponsor

                bool isSponsor = busobj.CheckingIsSponsorForBannerAds(CUserID);
                if (isSponsor)
                    Session["IsSponsor"] = true;

                #endregion

                #region Default Root Folder Creation
                // Nov 28/14 Balaji
                busobj.InsertDefaultAlbums(ProfileID, UserID);

                string RootFolder = Server.MapPath("~/Upload/MasterGallery/") + ProfileID;
                if (!Directory.Exists(RootFolder))
                {
                    Directory.CreateDirectory(RootFolder);
                }
                RootFolder = Server.MapPath("~/Upload/AppGallery/") + ProfileID;
                if (!Directory.Exists(RootFolder))
                {
                    Directory.CreateDirectory(RootFolder);
                }
                RootFolder = Server.MapPath("~/Upload/ContentGallery/") + ProfileID;
                if (!Directory.Exists(RootFolder))
                {
                    Directory.CreateDirectory(RootFolder);
                }

                #endregion


                //objAddOn.InsertDefaultAppButtons(ProfileID, UserID, DomainName, CUserID);
                objAddOn.AddAdditionalTab(DomainName, ProfileID, "SubApps");
                Session["Tools"] = null;
                Session["PackageSubscriptions"] = null;
                GetDashboardSettingsDtls1(ProfileID);
                // *** DisplayAccessCode(); ***//
                CheckDashboardFlow();
                // *** Adding page title and meta keys for page *** //
                DataTable dtConfigPageKeys1 = cmbobj.GetVerticalConfigsByType(DomainName, "VerticalNames");
                if (dtConfigPageKeys1.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigPageKeys1.Rows)
                    {
                        if (row[0].ToString() == "DisplayLogin")
                            VerticalType = row[1].ToString().ToLower();
                    }
                }
                //BindChart();
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    IsAdmin = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, CommonModules.AccessMarketPlace) == "P" ? true : false;
                    bool installerFalg = false;
                    string Permission_Type = string.Empty;
                    Permission_Type = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Downloads");
                    if (Permission_Type == "P")
                    {
                        installerFalg = true;
                    }
                    IsDownloadAccess = installerFalg;
                }

                // Custom Module Installation Link
                dtPurchaseAddOns = agencyobj.GetPurchaseAddOnsByProfileID(ProfileID);
                if (dtPurchaseAddOns.Rows.Count > 0)
                {
                    DataTable dtStoreItems = busobj.GetStoreItems("Store", DomainName);
                    for (int i = 0; i < dtPurchaseAddOns.Rows.Count; i++)
                    {
                        if (Convert.ToString(dtPurchaseAddOns.Rows[i]["PurchaseType"]) == WebConstants.Purchase_ContentAddOns && Convert.ToInt32(dtPurchaseAddOns.Rows[i]["PurchaseAddOns"]) > Convert.ToInt32(dtPurchaseAddOns.Rows[i]["SoldAddOns"]))
                        {
                            IsCustomModulAccess = true;
                            string filterRows = "Type='" + WebConstants.Store_ContentAddOns + "'";
                            DataRow[] drAddOn = dtStoreItems.Select(filterRows);
                            if (drAddOn.Length > 0)
                                hdnAddOnName.Value = Convert.ToString(drAddOn[0]["Title"]);
                        }
                        else if (Convert.ToString(dtPurchaseAddOns.Rows[i]["PurchaseType"]) == WebConstants.Purchase_PrivateContentAddOns && Convert.ToInt32(dtPurchaseAddOns.Rows[i]["PurchaseAddOns"]) > Convert.ToInt32(dtPurchaseAddOns.Rows[i]["SoldAddOns"]))
                        {
                            IsPrivateCustomModulAccess = true;
                            string filterRows = "Type='" + WebConstants.Store_PrivateContentAddOns + "'";
                            DataRow[] drAddOn = dtStoreItems.Select(filterRows);
                            if (drAddOn.Length > 0)
                                hdnPrivateAddOnName.Value = Convert.ToString(drAddOn[0]["Title"]);
                        }
                        else if (Convert.ToString(dtPurchaseAddOns.Rows[i]["PurchaseType"]) == WebConstants.Purchase_PrivateCallAddOns && Convert.ToInt32(dtPurchaseAddOns.Rows[i]["PurchaseAddOns"]) > Convert.ToInt32(dtPurchaseAddOns.Rows[i]["SoldAddOns"]))
                        {
                            IsPrivateCallAccess = true;
                            string filterRows = "Type='" + WebConstants.Store_PrivateCalltAddOns + "'";
                            DataRow[] drAddOn = dtStoreItems.Select(filterRows);
                            if (drAddOn.Length > 0)
                                hdnPrivateCallAddOnName.Value = Convert.ToString(drAddOn[0]["Title"]);
                        }
                        else if (Convert.ToString(dtPurchaseAddOns.Rows[i]["PurchaseType"]) == WebConstants.Purchase_PublicCallAddOns && Convert.ToInt32(dtPurchaseAddOns.Rows[i]["PurchaseAddOns"]) > Convert.ToInt32(dtPurchaseAddOns.Rows[i]["SoldAddOns"]))
                        {
                            IsPublicCallAccess = true;
                            string filterRows = "Type='" + WebConstants.Store_PublicCallAddOns + "'";
                            DataRow[] drAddOn = dtStoreItems.Select(filterRows);
                            if (drAddOn.Length > 0)
                                hdnPublicCallAddOnName.Value = Convert.ToString(drAddOn[0]["Title"]);
                        }
                        else if (Convert.ToString(dtPurchaseAddOns.Rows[i]["PurchaseType"]) == WebConstants.Purchase_PrivateSmartConnectAddOns && Convert.ToInt32(dtPurchaseAddOns.Rows[i]["PurchaseAddOns"]) > Convert.ToInt32(dtPurchaseAddOns.Rows[i]["SoldAddOns"]))
                        {
                            IsPrivateSmartConnectAccess = true;
                            string filterRows = "Type='" + WebConstants.Store_PrivateSmartConnectAddOns + "'";
                            DataRow[] drAddOn = dtStoreItems.Select(filterRows);
                            if (drAddOn.Length > 0)
                                hdnPrivateSmartConnectAddOnsName.Value = Convert.ToString(drAddOn[0]["Title"]);
                        }
                        else if (Convert.ToString(dtPurchaseAddOns.Rows[i]["PurchaseType"]) == WebConstants.Purchase_CalendarAddOns && Convert.ToInt32(dtPurchaseAddOns.Rows[i]["PurchaseAddOns"]) > Convert.ToInt32(dtPurchaseAddOns.Rows[i]["SoldAddOns"]))
                        {
                            IsCalendarAddOnsAccess = true;
                            string filterRows = "Type='" + WebConstants.Store_CalendarAddOns + "'";
                            DataRow[] drAddOn = dtStoreItems.Select(filterRows);
                            if (drAddOn.Length > 0)
                                hdnCalendarAddOnName.Value = Convert.ToString(drAddOn[0]["Title"]);
                        }
                        else if (Convert.ToString(dtPurchaseAddOns.Rows[i]["PurchaseType"]) == WebConstants.Purchase_BannerAds && Convert.ToInt32(dtPurchaseAddOns.Rows[i]["PurchaseAddOns"]) > Convert.ToInt32(dtPurchaseAddOns.Rows[i]["SoldAddOns"]))
                        {
                            IsBannerAdsAccess = true;
                            string filterRows = "Type='" + WebConstants.Store_BannerAds + "'";
                            DataRow[] drAddOn = dtStoreItems.Select(filterRows);
                            if (drAddOn.Length > 0)
                                hdnBannerAdsName.Value = Convert.ToString(drAddOn[0]["Title"]);
                        }
                    }
                    if (IsCustomModulAccess || IsPrivateCustomModulAccess)
                    {
                        dtCustomModuleTemplates = agencyobj.GetCustomModuleTemplates(DomainName, true); // *** Get only content template *** //
                        if (dtCustomModuleTemplates.Rows.Count == 1)
                        {
                            hdnModuleTemplateID.Value = Convert.ToString(dtCustomModuleTemplates.Rows[0]["ModuleID"]);
                        }
                    }
                }

            }


            /**** Sub-App Invitation List ****/
            StringBuilder strBuilder = new StringBuilder();
            DataTable dtSubAppsRequest = busobj.GetSubAppsByInvitationID(ProfileID, 0);
            for (int i = 0; i < dtSubAppsRequest.Rows.Count; i++)
            {
                if (i == 0)
                {
                    strBuilder.AppendLine("<div class=\"rowbg\"><div class=\"icon\">");
                    strBuilder.AppendLine("<img src=\"/images/Dashboard/star.png\" width=\"23\" height=\"22\" alt=\"icon\" /></div>");
                    strBuilder.AppendLine("  <strong> Affiliate App Invitation</strong> </br></br>");
                }
                strBuilder.AppendLine("<div style='margin-left: 55px;'>By accepting this invitation your App will be linked to <strong>" + dtSubAppsRequest.Rows[i]["ParentProfileName"].ToString() + "</strong> and be available for display in it's Favorites. <a style='color:Red;' href=\"javascript:InvitationConfirm('" + dtSubAppsRequest.Rows[i]["Affiliate_ID"].ToString() + "','" + dtSubAppsRequest.Rows[i]["ParentProfileName"].ToString().Replace("'", "\\'") + "','" + dtSubAppsRequest.Rows[i]["ParentUserID"].ToString() + "','" + dtSubAppsRequest.Rows[i]["Affiliate_ID"].ToString() + "','" + dtSubAppsRequest.Rows[i]["Notes"].ToString().Replace("'", "\\'") + "')\">Click here</a> to activate. </div> </br>");

                if (i == dtSubAppsRequest.Rows.Count - 1)
                {
                    strBuilder.AppendLine("</div>");
                }

            }
            lblSubAppInvitation.Text = strBuilder.ToString();
            GetDashboardCustomModules();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "Page_Load", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    private void AddDefaultCallAddOnForLite()
    {
        int callAddOnCount = busobj.CheckDefaultAddonForLite(ProfileID, WebConstants.Tab_PrivateCallAddOns);
        if (callAddOnCount == 0)
        {
            DataTable dtSubscriptionDetails = new DataTable();
            DateTime renewalDate = DateTime.Now.AddYears(1);
            dtSubscriptionDetails = busobj.GetOrderSubscriptionByProfileID(Convert.ToInt32(Session["ProfileID"].ToString()));
            if (dtSubscriptionDetails.Rows.Count > 0)
            {
                renewalDate = Convert.ToDateTime(dtSubscriptionDetails.Rows[0]["subscription_renewal_date"].ToString());
            }
            int UserModuleID = busobj.InsertUserCustomModules(ProfileID, UserID, CUserID, 0, Convert.ToString(ConfigurationManager.AppSettings["DefaultCallAddonIcon"]), Convert.ToString(ConfigurationManager.AppSettings["DefaultCallAddonName"]), true, DateTime.Now, DateTime.Now, renewalDate, "/Business/MyAccount/" + WebConstants.ManageUrl_PrivateCallAddOns, false, WebConstants.Tab_PrivateCallAddOns, WebConstants.Purchase_PrivateCallAddOns);
            string callModuleDirectory = Server.MapPath("~/Upload/CallModule/" + ProfileID);
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
                string sourcePath = Server.MapPath("~/Upload/DefaultCallModule/" + DomainName);
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

                cmbobj.AddCallModuleDefaultImages(UserModuleID, ProfileID, UserID, CUserID, WebConstants.Purchase_PrivateCallAddOns);
                DataTable dtCallModuleDefaultItems = objAddOn.GetCallModuleDefaultitems(DomainName, WebConstants.Purchase_PrivateCallAddOns);
                if (dtCallModuleDefaultItems.Rows.Count > 0)
                {
                    bool IsIntiatePhoneCall = true;
                    bool IsCustomPredefinedMessage = false;
                    string imagePath = RootPath + "/Upload/CallModule/" + ProfileID + "/" + UserModuleID + "/";
                    for (int i = 0; i < dtCallModuleDefaultItems.Rows.Count; i++)
                    {
                        objAddOn.InsertUpdateCallIndexData(0, ProfileID, UserID, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["CallTitle"]), imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["MobileNumber"]), false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailDescription"]), "0",
                                false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PushNotificationDescription"]), "0", false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSDescription"]), "0", false, false,
                                true, CUserID, CUserID, UserModuleID, false, false, false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PushNotificationSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["Description"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PreviewHtml"]).Replace("##Rootpath##", RootPath).Replace("##ImagePathUrl##", imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"])), false, IsIntiatePhoneCall, IsCustomPredefinedMessage,false);
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "LiteDashboard.aspx.cs", "AddDefaultCallAddOnForLite()", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }

    public static long GetDirectorySize(string path)
    {
        long size = 0;
        try
        {
            string[] files = Directory.GetFiles(path);
            string[] subdirectories = Directory.GetDirectories(path);

            // files.Sum(x => new FileInfo(x).Length);
            foreach (string s in subdirectories)
                size += GetDirectorySize(s);
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "Page_Load", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        return size;
    }
    private void GetToolTips()
    {
        try
        {
            var dtProfileDetails = busobj.GetProfileDetailsByProfileID(ProfileID);

            //default profile tabs start//
            string aboutus = "", updates = "", media = "", events = "", bulletins = "", weblinks = "", socialmedia = "", surveys = "", Notifications = "";
            string tip = "", EmergncyNumber = "";

            DataTable dtDefaultProfileTabs = busobj.GetDefaultProfileTabNames(DomainName);
            for (int k = 0; k < dtDefaultProfileTabs.Rows.Count; k++)
            {
                if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "AboutUs")
                    aboutus = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "Updates")
                    updates = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "Gallery")
                    media = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "Events")
                    events = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "Bulletins")
                    bulletins = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "WebLinks")
                    weblinks = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "SocialMedia")
                    socialmedia = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "Surveys")
                    surveys = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "Notifications")
                    Notifications = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "Tips")
                    tip = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
                else if (dtDefaultProfileTabs.Rows[k]["Tab_Parent"].ToString() == "EmergencyNumber")
                    EmergncyNumber = dtDefaultProfileTabs.Rows[k]["Tab_Name"].ToString();
            }


            DataTable dtMobileAppSettings = objMobileApp.GetMobileAppSetting(UserID);
            if (dtMobileAppSettings.Rows.Count > 0)
            {
                xmlSettings = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingValue"]);
                Session["SettingID"] = Convert.ToString(dtMobileAppSettings.Rows[0]["M_SettingID"]);
                var xmlTools = XElement.Parse(xmlSettings, LoadOptions.PreserveWhitespace);

                //CONTACT DETAILS
                if (xmlTools.Element("Tools").Attribute("NotificationTabName") != null)
                    NotificationButtonName = Convert.ToString(xmlTools.Element("Tools").Attribute("NotificationTabName").Value);
                else
                    NotificationButtonName = Notifications;

                //NotificationButtonName = "(" + lblImg9.ToolTip + ")";

                //lblImg1.ToolTip = "Contacts";


                //TOOLS            
                if (xmlTools.Element("Tools").Attribute("UpdatesTabName") != null)
                    UpdatesButtonName = Convert.ToString(xmlTools.Element("Tools").Attribute("UpdatesTabName").Value);
                else
                    UpdatesButtonName = updates;

                //UpdatesButtonName = "(" + lblImg3.ToolTip + ")";


                if (xmlTools.Element("Tools").Attribute("MediaTabName") != null)
                    GalleryButtonName = Convert.ToString(xmlTools.Element("Tools").Attribute("MediaTabName").Value);
                else
                    GalleryButtonName = media;

                //GalleryButtonName = "(" + lblImg2.ToolTip + ")";



                if (xmlTools.Element("Tools").Attribute("EventsTabName") != null)
                    EventButtonName = Convert.ToString(xmlTools.Element("Tools").Attribute("EventsTabName").Value);
                else
                    EventButtonName = events;

                //EventButtonName = "(" + lblImg4.ToolTip + ")";



                if (xmlTools.Element("Tools").Attribute("SurveysTabName") != null)
                    SurveyButtonName = Convert.ToString(xmlTools.Element("Tools").Attribute("SurveysTabName").Value);
                else
                    SurveyButtonName = surveys;

                // SurveyButtonName = "(" + lblImg5.ToolTip + ")";



                if (xmlTools.Element("Tools").Attribute("BulletinsTabName") != null)
                    BulletinsButtonName = Convert.ToString(xmlTools.Element("Tools").Attribute("BulletinsTabName").Value);
                else
                    BulletinsButtonName = bulletins;
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "GetToolTips", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private void CheckDashboardFlow()
    {
        try
        {
            DataTable dtCheckFlow = busobj.GetDashboardFlow(UserID, CUserID);
            if (dtCheckFlow.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtCheckFlow.Rows[0]["IsCompleted"].ToString()) == false)
                {
                    rightbox.Visible = false;
                    CheckProfile = Convert.ToBoolean(dtCheckFlow.Rows[0]["IsProfile"].ToString());
                    CheckDescription = Convert.ToBoolean(dtCheckFlow.Rows[0]["IsDescription"].ToString());
                    CheckAppSettings = Convert.ToBoolean(dtCheckFlow.Rows[0]["IsAppSettings"].ToString());
                }
            }
            // *** Checking for user permissions *** //
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Roles & permissions
            {
                dtpermissions = agencyobj.GetPermissionsById(Convert.ToInt32(Session["C_USER_ID"]));
                Update = false;
                Event = false;
                Bulletins = false;
                MobileApp = false;
                Contacts = false;
                PushNotifications = false;
                Surveys = false;
                Home = false;
                AboutUs = false;
                WebLinks = false;
                SocialMedia = false;
                Gallery = false;
                IsAppStastics = false;
                PublicCallAddOn = false;
            }
            //USPD-1107 and USPD-1116 Permission related Changes
            if (dtpermissions.Rows.Count > 0 && Session["Free"] == null) //roles & permissions...
            {
                string val = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Bulletins");
                if (!string.IsNullOrEmpty(val))
                    Bulletins = true;
                val = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Events");
                if (!string.IsNullOrEmpty(val))
                    Event = true;
                val = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                if (val == "P")
                    MobileApp = true;
                val = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Contacts");
                if (val == "P")
                    Contacts = true;
                val = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "PushNotifications");
                if (val == "P")
                    PushNotifications = true;
                val = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Surveys");
                if (!string.IsNullOrEmpty(val))
                    Surveys = true;
                val = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Home");
                if (val == "P")
                    Home = true;
                val = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AboutUs");
                if (val == "P")
                    AboutUs = true;
                val = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "WebLinks");
                if (val == "P")
                    WebLinks = true;
                val = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "SocialMedia");
                if (val == "P")
                    SocialMedia = true;
                val = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Gallery");
                if (val == "P")
                    Gallery = true;
                val = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, CommonModules.AppStatistics.ToString());
                if (val == "P")
                    IsAppStastics = true;
                val = cmbobj.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, CommonModules.PublicCallAddOns.ToString());
                if (val == "P")
                    PublicCallAddOn = true;
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "CheckDashboardFlow", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void lnkUpdateCredicard_OnClick(object sender, EventArgs e)
    {
        try
        {
            DataTable dtCreditCardDetails = busobj.GetOrderSubscriptionByProfileID(Convert.ToInt32(Session["ProfileID"].ToString()));

            if (dtCreditCardDetails.Rows.Count > 0)
            {
                //CC Details
                DropDownList ddlCardType = CCDetails1.FindControl("ddlCardType") as DropDownList;
                TextBox txtfirstName = CCDetails1.FindControl("txtfirstName") as TextBox;
                TextBox txtlastname = CCDetails1.FindControl("txtlastname") as TextBox;
                AjaxControlToolkit.TextBoxWatermarkExtender waterCCNumber = CCDetails1.FindControl("waterCCNumber") as AjaxControlToolkit.TextBoxWatermarkExtender;
                TextBox txtcreditCardNumber = CCDetails1.FindControl("txtcreditCardNumber") as TextBox;
                TextBox txtexpmonth = CCDetails1.FindControl("txtexpmonth") as TextBox;
                TextBox txtexpyear = CCDetails1.FindControl("txtexpyear") as TextBox;
                TextBox txtcvv2Number = CCDetails1.FindControl("txtcvv2Number") as TextBox;


                ddlCardType.SelectedValue = Convert.ToString(dtCreditCardDetails.Rows[0]["Card_Type"]);
                txtfirstName.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["cc_name"]);
                txtlastname.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["cc_lastname"]);

                string cCNumber = EncryptDecrypt.DESDecrypt(Convert.ToString(dtCreditCardDetails.Rows[0]["CC_number"]));
                if (cCNumber.Length >= 4)
                {
                    cCNumber = "xxxx xxxx xxxx " + cCNumber.Substring(cCNumber.Length - 4).ToString();
                    txtcreditCardNumber.Text = cCNumber;
                    waterCCNumber.WatermarkText = cCNumber;
                }
                else
                {
                    txtcreditCardNumber.Text = " ";
                    waterCCNumber.WatermarkText = "xxxx xxxx xxxx 1234";
                }


                txtexpmonth.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["cc_expire_month"]);
                txtexpyear.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["cc_expire_year"]);
                txtcvv2Number.Text = EncryptDecrypt.DESDecrypt(Convert.ToString(dtCreditCardDetails.Rows[0]["cc_cvv"]));

                Session["orderID"] = Convert.ToString(dtCreditCardDetails.Rows[0]["Order_ID"]);

                //Billing Details
                TextBox txtAddress1 = (TextBox)CCDetails1.FindControl("txtaddress1");
                TextBox txtAddress2 = (TextBox)CCDetails1.FindControl("txtaddress2");
                TextBox txtCity = (TextBox)CCDetails1.FindControl("txtcity");
                DropDownList drpState = (DropDownList)CCDetails1.FindControl("DrpState");
                TextBox txtZipcode = (TextBox)CCDetails1.FindControl("txtzip");

                txtAddress1.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["billing_address1"]);
                txtAddress2.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["billing_address2"]);
                txtCity.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["billing_city"]);
                drpState.SelectedValue = Convert.ToString(dtCreditCardDetails.Rows[0]["billing_state"]);
                txtZipcode.Text = Convert.ToString(dtCreditCardDetails.Rows[0]["billing_zipcode"]);
            }

            CCDetailsModalPopup.Show();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "lnkUpdateCredicard_OnClick", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    //Used to get the Databoard Setting Details...
    private void GetDashboardSettingsDtls()
    {
        try
        {
            DataTable dtSelectedTools = busobj.GetSelectedToolsByUserID(UserID);
            if (dtSelectedTools.Rows.Count > 0)
            {
                if (Session["Free"] == null)
                {
                    Update = Convert.ToBoolean(dtSelectedTools.Rows[0]["IsUpdate"].ToString());
                    Event = Convert.ToBoolean(dtSelectedTools.Rows[0]["IsEventCalendar"].ToString());
                    MobileApp = (string.IsNullOrEmpty(dtSelectedTools.Rows[0]["Package_Number"].ToString())) ? false : Convert.ToInt32(dtSelectedTools.Rows[0]["Package_Number"].ToString()) >= 4 ? true : false;
                    Bulletins = (string.IsNullOrEmpty(dtSelectedTools.Rows[0]["Package_Number"].ToString())) ? false : Convert.ToInt32(dtSelectedTools.Rows[0]["Package_Number"].ToString()) >= 5 ? true : false;
                    Surveys = (string.IsNullOrEmpty(dtSelectedTools.Rows[0]["Package_Number"].ToString())) ? false : Convert.ToInt32(dtSelectedTools.Rows[0]["Package_Number"].ToString()) >= 5 ? true : false;
                }
                else
                {
                    Settings(false);
                }
            }
            else
            {
                if (Session["Free"] != null)
                    Settings(false);
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "GetDashboardSettingsDtls", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private void Settings(bool flag)
    {
        Update = flag;
        Event = flag;
        MobileApp = flag;
        Bulletins = flag;
        Surveys = flag;
        PushNotifications = flag;
        Home = flag;
        AboutUs = flag;
        WebLinks = flag;
        SocialMedia = flag;
        Gallery = flag;
    }
    # region Get Profile Updated Details
    private void GetUpdatedProfileDetails()
    {
        try
        {
            // *** Binding Time Zones *** //
            string url = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
            string countryValue = "United States";
            if (url.Contains(ConfigurationManager.AppSettings["UrlInschoolIndia"]))
                countryValue = "India";
            DataTable dtTimeZones = busobj.GetTimeZones(countryValue);
            if (dtTimeZones.Rows.Count > 0)
            {
                ddlTimeZones.DataSource = dtTimeZones;
                ddlTimeZones.DataTextField = "Display_Name";
                ddlTimeZones.DataValueField = "TimeZone_ID";
                ddlTimeZones.DataBind();
            }
            // *** Start changes to fix Issue in displaying latest details ***
            #region MyUpdates

            DTMyProfileUpdates.Columns.Add("UpdatedText", typeof(string));
            DTMyProfileUpdates.Columns.Add("ModifiedDate", typeof(DateTime));
            DataTable dtprofiledetails = new DataTable();
            dtprofiledetails = busobj.GetProfileDetailsByProfileID(ProfileID);
            ddlTimeZones.SelectedValue = dtprofiledetails.Rows[0]["TimeZoneID"].ToString();
            string profileName = string.Empty;
            if (dtprofiledetails.Rows.Count > 0)
            {
                profileName = dtprofiledetails.Rows[0]["Profile_Name"].ToString();
                hdnTimeZoneID.Value = dtprofiledetails.Rows[0]["Display_Value"].ToString();
            }
            profileUrl = RootPath + "/Profiles/default.aspx?PID=" + ProfileID;

            #region photos
            DataTable dtphotos = new DataTable();
            dtphotos = busobj.GetTop1ProfilePhotosByProfileID(ProfileID);
            if (dtphotos.Rows.Count > 0)
            {
                string date1 = dtphotos.Rows[0]["MODIFIED_DT"].ToString();
                string updatedtext = string.Empty;
                date1 = Convert.ToDateTime(date1).ToString();
                updatedtext = "<span class='blue'><a href=" + profileUrl + "  target='_blank'>" + profileName + "</a></span> added new Images on " + Convert.ToDateTime(date1).ToShortDateString();
                DataRow dr = DTMyProfileUpdates.NewRow();
                dr["UpdatedText"] = updatedtext.ToString();
                dr["ModifiedDate"] = Convert.ToDateTime(date1);
                DTMyProfileUpdates.Rows.Add(dr);
            }
            #endregion

            #region videos
            DataTable dtvideos = new DataTable();
            dtvideos = busobj.GetProfileVideosByProfileID(ProfileID);

            if (dtvideos.Rows.Count > 0)
            {

                string date1 = dtvideos.Rows[0]["MODIFIED_DT"].ToString();
                string updatedtext = string.Empty;
                date1 = Convert.ToDateTime(date1).ToString();
                updatedtext = "<span class='blue'><a href=" + profileUrl + " target='_blank'>" + profileName + "</a></span> added new Video on " + Convert.ToDateTime(date1).ToShortDateString();
                DataRow dr = DTMyProfileUpdates.NewRow();
                dr["UpdatedText"] = updatedtext.ToString();
                dr["ModifiedDate"] = Convert.ToDateTime(date1);
                DTMyProfileUpdates.Rows.Add(dr);
            }
            #endregion

            #region EventsInfo
            DataTable dtEventsInfo = new DataTable();
            dtEventsInfo = busobj.GetTop1ProfileEventsInfoByProfileID(ProfileID);

            if (dtEventsInfo.Rows.Count > 0)
            {

                string date1 = dtEventsInfo.Rows[0]["CreatedDate"].ToString();
                string updatedtext = string.Empty;
                date1 = Convert.ToDateTime(date1).ToString();
                updatedtext = "<span class='blue'><a href=" + profileUrl + " target='_blank'>" + profileName + "</a></span> added an Event  on " + Convert.ToDateTime(date1).ToShortDateString();
                DataRow dr = DTMyProfileUpdates.NewRow();
                dr["UpdatedText"] = updatedtext.ToString();
                dr["ModifiedDate"] = Convert.ToDateTime(date1);
                DTMyProfileUpdates.Rows.Add(dr);

            }
            #endregion


            #region BusinessUpdatesInfo
            DataTable dtBusinessUpdatesInfo = new DataTable();
            dtBusinessUpdatesInfo = objBusinessUpdates.GetTop1ProfileBusinessUpdatesInfoByProfileID(ProfileID);
            if (dtBusinessUpdatesInfo.Rows.Count > 0)
            {

                string date1 = dtBusinessUpdatesInfo.Rows[0]["MODIFIED_DATE"].ToString();
                string updatedtext = string.Empty;

                if ((date1 != null) && (date1 != ""))
                {

                    date1 = Convert.ToDateTime(date1).ToString();
                    updatedtext = "<span class='blue'><a href=" + profileUrl + " target='_blank'>" + profileName + "</a></span> has published an Update on " + Convert.ToDateTime(date1).ToShortDateString();
                    DataRow dr = DTMyProfileUpdates.NewRow();
                    dr["UpdatedText"] = updatedtext.ToString();
                    dr["ModifiedDate"] = Convert.ToDateTime(date1);
                    DTMyProfileUpdates.Rows.Add(dr);
                }
                else
                {

                    updatedtext = "<span class='blue'><a href=" + profileUrl + " target='_blank'>" + profileName + "</a></span> has updated Details ";
                    DataRow dr = DTMyProfileUpdates.NewRow();
                    dr["UpdatedText"] = updatedtext.ToString();
                    dr["ModifiedDate"] = DBNull.Value;
                    DTMyProfileUpdates.Rows.Add(dr);
                }


            }
            #endregion

            #endregion
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "GetUpdatedProfileDetails", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    # endregion


    # region renewal the Business profile
    protected void btnrenew_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string orderID = string.Empty;
            DataTable dtOrderID = new DataTable();
            dtOrderID = busobj.Getorderidbyuserid(Convert.ToInt32(Session["UserID"].ToString()));
            if (dtOrderID.Rows.Count > 0)
            {
                orderID = dtOrderID.Rows[0]["Order_ID"].ToString();
                Response.Redirect(Page.ResolveClientUrl("~/Business/UpgradeTools.aspx?RNID=" + EncryptDecrypt.DESEncrypt(orderID.ToString())));
            }
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "btnrenew_Click", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    # endregion


    //DASHBOARD SETTING IN MODAL POPUP
    protected void linkmanage_Click(object sender, EventArgs e)
    {
        try
        {
            GetDashboardSettingsDtls1(ProfileID);
            popnewsletterimage.Show();
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "linkmanage_Click", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    //Used to get the Databoard Setting Details...
    private void GetDashboardSettingsDtls1(int profileid)
    {
        try
        {
            DataTable dt = new DataTable();


            dt = busobj.GetDashboardSettingsDtls(profileid);
            if (dt.Rows.Count > 0)
            {
                SettingsId.Value = dt.Rows[0]["Setting_ID"].ToString();
                chkContacts.Checked = Convert.ToBoolean(dt.Rows[0]["IsContacts"].ToString());
                chkUpdates.Checked = Convert.ToBoolean(dt.Rows[0]["IsUpdate"].ToString());
                chkEventCalendar.Checked = Convert.ToBoolean(dt.Rows[0]["IsEvent"].ToString());
                chkMobileApp.Checked = Convert.ToBoolean(dt.Rows[0]["IsMobileApp"].ToString());
                chkBulletins.Checked = Convert.ToBoolean(dt.Rows[0]["IsBulletins"].ToString());
                if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["IsMedia"])))
                {
                    chkMedia.Checked = true;
                }
                else
                {
                    chkMedia.Checked = Convert.ToBoolean(dt.Rows[0]["IsMedia"].ToString());
                }

            }
            hdnsettings.Value = chkContacts.Checked + "," + chkUpdates.Checked + "," + chkEventCalendar.Checked + "," + chkMedia.Checked + "," + chkMobileApp.Checked + "," + chkBulletins.Checked;
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "GetDashboardSettingsDtls1", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            USPDHUBDAL.BusinessDAL.ToolsEntities tools = new USPDHUBDAL.BusinessDAL.ToolsEntities();
            tools.UserID = ProfileID;
            if (SettingsId.Value == "") SettingsId.Value = "0";
            tools.TotalEmails = Convert.ToInt32(SettingsId.Value);
            tools.IsUpdate = Convert.ToBoolean(chkUpdates.Checked.ToString());
            tools.IsWebsite = false;
            tools.IsSocialMediaAnalytics = false;
            tools.IsEventCalendar = Convert.ToBoolean(chkEventCalendar.Checked.ToString());
            tools.IsMedia = Convert.ToBoolean(chkMedia.Checked.ToString());
            IsMobileApp = Convert.ToBoolean(chkMobileApp.Checked.ToString());
            IsBulletins = Convert.ToBoolean(chkBulletins.Checked.ToString());
            busobj.InsertDashboardSettingsDtls(tools, IsMobileApp, IsBulletins, CUserID);
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "btnSubmit_Click", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        popnewsletterimage.Hide();
    }

    private void BindChart()
    {
        try
        {
            int count = 0;
            //int openCount = 0;
            DataTable dtProfiles = busobj.GetProfileDetailsByProfileID(ProfileID);
            int totalDownloads = 0;
            //int totalAppOpenCount = 0;
            #region User Sing Up Date wise Count
            DateTime signUpDate = Convert.ToDateTime(dtProfiles.Rows[0]["CREATED_DT"]);
            DataTable dtPieChart1 = busobj.GetPieChartData(ProfileID, signUpDate, DateTime.Now, out totalDownloads);
            int iphoneDownloads = Convert.ToInt32(dtPieChart1.Rows[0]["Iphone_Downloads"].ToString());
            int androidDownloads = Convert.ToInt32(dtPieChart1.Rows[0]["Android_Downloads"].ToString());
            int windowsDownloads = Convert.ToInt32(dtPieChart1.Rows[0]["Windows_Downloads"].ToString());
            count = iphoneDownloads + androidDownloads + windowsDownloads;
            lblTotalCount.Text = Resources.ProfileAccessMessages.AppUsageTitle + count.ToString();

            //DataTable dtPieChartOpen = busobj.GetPieChartDataForOpenReport(ProfileID, signUpDate, DateTime.Now, out totalAppOpenCount);
            //int iphoneOpen = Convert.ToInt32(dtPieChartOpen.Rows[0]["Iphone_Downloads"].ToString());
            //int androidOpen = Convert.ToInt32(dtPieChartOpen.Rows[0]["Android_Downloads"].ToString());
            //int windowsOpen = Convert.ToInt32(dtPieChartOpen.Rows[0]["Windows_Downloads"].ToString());
            //openCount = iphoneOpen + androidOpen + windowsOpen;
            //lblAppOpenCount.Text = Resources.ProfileAccessMessages.AppOpenTitle + openCount.ToString();
            #endregion

            List<PieChart> listPieChart = new List<PieChart>();
            if (count > 0)
            {
                listPieChart.Add(new PieChart
                {
                    PlatForms = "Apple",
                    Downloads = iphoneDownloads
                });
                listPieChart.Add(new PieChart
                {
                    PlatForms = "Android",
                    Downloads = androidDownloads
                });
                listPieChart.Add(new PieChart
                {
                    PlatForms = "Windows",
                    Downloads = windowsDownloads
                });

            }

            chartAppUsage.DataSource = listPieChart;
            chartAppUsage.Series["Legend"].XValueMember = "PlatForms";
            chartAppUsage.Series["Legend"].YValueMembers = "Downloads";
            chartAppUsage.DataBind();
            chartAppUsage.Series["Legend"].LegendText = "#AXISLABEL";
            chartAppUsage.Series["Legend"].Label = "#VALY (#PERCENT{P0})";
            foreach (System.Web.UI.DataVisualization.Charting.DataPoint dp in chartAppUsage.Series["Legend"].Points)
                dp.IsEmpty = (dp.YValues[0] == 0) ? true : false;

            //List<PieChart> listPieChartOpen = new List<PieChart>();
            //if (openCount > 0)
            //{
            //    listPieChartOpen.Add(new PieChart
            //    {
            //        PlatForms = "Apple",
            //        Downloads = iphoneOpen
            //    });
            //    listPieChartOpen.Add(new PieChart
            //    {
            //        PlatForms = "Android",
            //        Downloads = androidOpen
            //    });
            //    listPieChartOpen.Add(new PieChart
            //    {
            //        PlatForms = "Windows",
            //        Downloads = windowsOpen
            //    });
            //}

            //chartAppOpen.DataSource = listPieChartOpen;
            //chartAppOpen.Series["Legend"].XValueMember = "PlatForms";
            //chartAppOpen.Series["Legend"].YValueMembers = "Downloads";
            //chartAppOpen.DataBind();
            //chartAppOpen.Series["Legend"].LegendText = "#AXISLABEL";
            //chartAppOpen.Series["Legend"].Label = "#VALY (#PERCENT{P0})";
            //foreach (System.Web.UI.DataVisualization.Charting.DataPoint dp in chartAppOpen.Series["Legend"].Points)
            //    dp.IsEmpty = (dp.YValues[0] == 0) ? true : false;
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "BindChart", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    /********************************* commented by suneel *****************************
    protected void btnSubmitCode_Click(object sender, EventArgs e)
    {
        int accessCode = adminobj.CreateUpdateAccessCodes(ProfileID, txtAccessCode.Text.Trim());
        if (accessCode == 1)
        {
            if (lblHeading.Text == "Update Access Code")
                lblerror.Text = "<Font face=arial color=green size=2><b>Access code has been updated successfully.</b></font>";
            else
                lblerror.Text = "<Font face=arial color=green size=2><b>Access code has been created successfully.</b></font>";
        }
        DisplayAccessCode();
        mpeAccessCode.Show();
    }
    private void DisplayAccessCode()
    {
        /////////////////////////////////Creating Access Code Functionality/////////////////////////////////
        DataTable dtAccessCode = new DataTable();
        dtAccessCode = adminobj.GetMemberDetails(Convert.ToInt32(UserID));
        if (!string.IsNullOrEmpty(dtAccessCode.Rows[0]["Access_Code"].ToString()))
        {
            lnkSearchCode.Text = "Update Access Code";
            lblHeading.Text = "Update Access Code";
            txtAccessCode.Text = dtAccessCode.Rows[0]["Access_Code"].ToString();
            hdnAccessCode.Value = dtAccessCode.Rows[0]["Access_Code"].ToString();
        }
        else
        {
            lnkSearchCode.Text = "Create Access Code";
            lblHeading.Text = "Create Access Code";
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
    }
    ********************************************** commented by suneel *****************************/
    public class PieChart
    {
        public string PlatForms { get; set; }
        public int Downloads { get; set; }
    }

    [WebMethod]
    public static string GetProfileID(string selZoneID)
    {
        try
        {
            BusinessBLL obBus = new BusinessBLL();
            int profileIDforAJAX = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
            int timeZoneSelectedValue = Convert.ToInt32(selZoneID);
            string shortenZone = obBus.UpdateTimeZoneID(profileIDforAJAX, timeZoneSelectedValue);
            return shortenZone;
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "GetProfileID", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            return string.Empty;
        }

    }
    [WebMethod]
    public static string GetUserTimeZoneDashboard()
    {
        try
        {
            CommonBLL objCommon = new CommonBLL();
            int profileIDforAJAX = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
            DateTime dtNow = objCommon.ConvertToUserTimeZone(profileIDforAJAX);
            return Convert.ToString(dtNow);
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "GetUserTimeZoneDashboard", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            return string.Empty;
        }
    }

    //private void urlShortcutToDesktop(string linkName, string linkUrl)
    //{
    //    try
    //    {
    //        String FileName = "USPDHub.url";
    //        String FilePath = Server.MapPath("~/Upload/USPDHub.url");
    //        using (StreamWriter writer = new StreamWriter(FilePath))
    //        {
    //            writer.WriteLine("[InternetShortcut]");
    //            writer.WriteLine("URL=" + linkUrl);
    //            writer.Flush();
    //        }
    //        // System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
    //        Response.ClearContent();
    //        Response.Clear();
    //        Response.ClearHeaders();
    //        Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
    //        Response.TransmitFile(FilePath);
    //        Response.Flush();
    //        Response.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.Message.ToString();
    //    }
    //}


    protected void lnkNext_Click(object sender, EventArgs e)
    {
        try
        {
            lblAddOnNamePro.Text = hdnSelModulePopup.Value == WebConstants.Purchase_ContentAddOns ? hdnAddOnName.Value : hdnPrivateAddOnName.Value;
            ModalCustomModule.Show();
            pnlTemplates.Style.Add("display", "none");
            pnlNameandTab.Style.Add("display", "none");
            pnlProgress.Style.Add("display", "block");
            int module = 0;
            if (hdnSelModulePopup.Value != WebConstants.Purchase_PrivateCallAddOns && hdnSelModulePopup.Value != WebConstants.Purchase_PublicCallAddOns && hdnSelModulePopup.Value != WebConstants.Purchase_PrivateSmartConnectAddOns)
                module = Convert.ToInt32(hdnModuleTemplateID.Value);
            string appIcon = Convert.ToString(hdnModuleAppButton.Value);
            string tabName = Convert.ToString(hdnModuleAppName.Value);
            int UserModuleID = 0;
            int GroupID = 0;
            if (hdnSelModulePopup.Value == WebConstants.Purchase_PrivateCallAddOns)
            {
                UserModuleID = busobj.InsertUserCustomModules(ProfileID, UserID, CUserID, module, appIcon, tabName, true, DateTime.Now, DateTime.Now, DateTime.Now.AddYears(1), "/Business/MyAccount/" + WebConstants.ManageUrl_PrivateCallAddOns, false, WebConstants.Tab_PrivateCallAddOns, WebConstants.Purchase_PrivateCallAddOns);
                string callModuleDirectory = Server.MapPath("~/Upload/CallModule/" + ProfileID);
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

                    string sourcePath = Server.MapPath("~/Upload/DefaultCallModule/" + DomainName);
                    string fileName = "";
                    string destFile = "";

                    /*
                   if (Directory.Exists(sourcePath))
                   {
                       foreach (var srcPath in Directory.GetFiles(sourcePath))
                       {
                           fileName = System.IO.Path.GetFileName(srcPath);
                           destFile = System.IO.Path.Combine(callModuleDirectory, fileName);
                           File.Copy(srcPath, destFile, true);
                       }
                   }
                   cmbobj.AddCallModuleDefaultImages(UserModuleID, ProfileID, UserID, CUserID, WebConstants.Purchase_PrivateCallAddOns);
                   */

                    DataTable dtCallModuleDefaultItems = objAddOn.GetCallModuleDefaultitems(DomainName, WebConstants.Purchase_PrivateCallAddOns);
                    if (dtCallModuleDefaultItems.Rows.Count > 0)
                    {

                        bool IsIntiatePhoneCall = true;
                        bool IsCustomPredefinedMessage = false;
                        string imagePath = RootPath + "/Upload/CallModule/" + ProfileID + "/" + UserModuleID + "/";
                        for (int i = 0; i < dtCallModuleDefaultItems.Rows.Count; i++)
                        {
                            try
                            {
                                string srcPath = sourcePath + "/" + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"]);
                                if (File.Exists(srcPath))
                                {
                                    destFile = System.IO.Path.Combine(callModuleDirectory, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"]));
                                    File.Copy(srcPath, destFile, true);
                                }
                            }
                            catch (Exception ex)
                            { }
                            objAddOn.InsertUpdateCallIndexData(0, ProfileID, UserID, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["CallTitle"]), imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["MobileNumber"]), false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailDescription"]), GroupID.ToString(),
                                    false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PushNotificationDescription"]), GroupID.ToString(), false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSDescription"]), GroupID.ToString(), false, false,
                                    true, CUserID, CUserID, UserModuleID, false, false, false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PushNotificationSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["Description"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PreviewHtml"]).Replace("##Rootpath##", RootPath).Replace("##ImagePathUrl##", imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"])), false, IsIntiatePhoneCall, IsCustomPredefinedMessage,false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "lnkNext_Click()", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }
            }
            else if (hdnSelModulePopup.Value == WebConstants.Purchase_PublicCallAddOns)
            {
                UserModuleID = busobj.InsertUserCustomModules(ProfileID, UserID, CUserID, module, appIcon, tabName, true, DateTime.Now, DateTime.Now, DateTime.Now.AddYears(1), "/Business/MyAccount/" + WebConstants.ManageUrl_PublicCallAddOns, false, WebConstants.Tab_PublicCallAddOns, WebConstants.Purchase_PublicCallAddOns);
                string callModuleDirectory = Server.MapPath("~/Upload/CallModule/" + ProfileID);
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
                    /*
                    string sourcePath = Server.MapPath("~/Upload/DefaultPublicCallModules/" + DomainName);
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
                    cmbobj.AddCallModuleDefaultImages(UserModuleID, ProfileID, UserID, CUserID, WebConstants.Purchase_PublicCallAddOns);
                     */
                    DataTable dtCallModuleDefaultItems = objAddOn.GetCallModuleDefaultitems(DomainName, WebConstants.Purchase_PublicCallAddOns);
                    if (dtCallModuleDefaultItems.Rows.Count > 0)
                    {
                        bool IsIntiatePhoneCall = true;
                        bool IsCustomPredefinedMessage = false;
                        string imagePath = RootPath + "/Upload/CallModule/" + ProfileID + "/" + UserModuleID + "/";
                        bool IsAnonymous = false; bool IsUploadImage = false;
                        int AppUserAnonymousType = Convert.ToInt32(USPDHUBDAL.AddOnDAL.AppUserAnonymousType.AppIdentityChoose);
                        for (int i = 0; i < dtCallModuleDefaultItems.Rows.Count; i++)
                        {
                            objAddOn.InsertUpdatePublicCallIndexData(0, ProfileID, UserID, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["CallTitle"]), imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["MobileNumber"]), false,
                                Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailDescription"]), GroupID.ToString(),
                                     false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSDescription"]), GroupID.ToString(), false, false,
                                    true, CUserID, CUserID, UserModuleID, false, false, false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailSubject"]),
                                    Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["Description"]),
                                    Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PreviewHtml"]).Replace("##Rootpath##", RootPath).Replace("##ImagePathUrl##", imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"])),
                                    false, IsIntiatePhoneCall, IsCustomPredefinedMessage, IsAnonymous, IsUploadImage, AppUserAnonymousType, 0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "lnkNext_Click()", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }
            }
            else if (hdnSelModulePopup.Value == WebConstants.Purchase_PrivateSmartConnectAddOns)
            {
                UserModuleID = busobj.InsertUserCustomModules(ProfileID, UserID, CUserID, module, appIcon, tabName, true, DateTime.Now, DateTime.Now,
                    DateTime.Now.AddYears(1), "/Business/MyAccount/" + WebConstants.ManageUrl_PrivateSmartConnectAddOns, false, WebConstants.Tab_PrivateSmartConnectAddOns, WebConstants.Purchase_PrivateSmartConnectAddOns);
                string callModuleDirectory = Server.MapPath("~/Upload/CallModule/" + ProfileID);
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

                    DataTable dtCallModuleDefaultItems = objAddOn.GetCallModuleDefaultitems(DomainName, WebConstants.Purchase_PrivateSmartConnectAddOns);
                    PrivateSmartConnectBLL PSCBLL = new PrivateSmartConnectBLL();
                    if (dtCallModuleDefaultItems.Rows.Count > 0)
                    {
                        bool IsIntiatePhoneCall = true;
                        bool IsCustomPredefinedMessage = false;
                        string imagePath = RootPath + "/Upload/CallModule/" + ProfileID + "/" + UserModuleID + "/";
                        bool IsUploadImage = false;
                        int AppUserAnonymousType = Convert.ToInt32(USPDHUBDAL.AddOnDAL.AppUserAnonymousType.AppIdentityChoose);
                        for (int i = 0; i < dtCallModuleDefaultItems.Rows.Count; i++)
                        {
                            PSCBLL.InsertUpdatePSCCallIndexData(0, ProfileID, UserID, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["CallTitle"]), imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["MobileNumber"]), false,
                                Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailDescription"]), GroupID.ToString(),
                                     false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSDescription"]), GroupID.ToString(), false, false,
                                    true, CUserID, CUserID, UserModuleID, false, false, false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailSubject"]),
                                    Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["Description"]),
                                    Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PreviewHtml"]).Replace("##Rootpath##", RootPath).Replace("##ImagePathUrl##", imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"])),
                                    false, IsIntiatePhoneCall, IsCustomPredefinedMessage, IsUploadImage, AppUserAnonymousType, 0,
                                    false, GroupID.ToString(), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PushNotificationDescription"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PushNotificationSubject"]), "", "",
                                    false, "", false, Convert.ToInt32(string.Empty), "Feets",false);
                    
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "lnkNext_Click()", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }
            }
            else if (hdnSelModulePopup.Value == WebConstants.Purchase_ContentAddOns)
            {
                UserModuleID = busobj.InsertUserCustomModules(ProfileID, UserID, CUserID, module, appIcon, tabName, true, DateTime.Now, DateTime.Now, DateTime.Now.AddYears(1), "/Business/MyAccount/" + WebConstants.ManageUrl_ContentAddOns, true, WebConstants.Tab_ContentAddOns, WebConstants.Purchase_ContentAddOns);
            } // Private Module 
            else if (hdnSelModulePopup.Value == WebConstants.Purchase_PrivateContentAddOns)
            {
                UserModuleID = busobj.InsertUserCustomModules(ProfileID, UserID, CUserID, module, appIcon, tabName, true, DateTime.Now, DateTime.Now, DateTime.Now.AddYears(1), "/Business/MyAccount/" + WebConstants.ManageUrl_PrivateContentAddOns, true, WebConstants.Tab_PrivateContentAddOns, WebConstants.Purchase_PrivateContentAddOns);


                #region Add Group Name to Manage Contatcs below Private Module Groups

                // Check for Contact Group is already exsists
                var check = busobj.CheckUserListingValidation(tabName, UserID);
                if (check == 0)
                {

                    // Insert Master Group
                    var maxContactGroupID = 0;
                    bool IsSystemGroup = false;
                    bool IsMasterGroup = true;
                    string MasterGroupName = "Common";
                    check = busobj.CheckUserListingValidation(MasterGroupName, UserID);

                    if (check == 0)
                    {
                        maxContactGroupID = busobj.GetMaximunContactGroupIDForUserID(UserID);
                        maxContactGroupID = maxContactGroupID + 1;

                        busobj.InsertContactGroupName(maxContactGroupID, MasterGroupName, UserID, DateTime.Now, DateTime.Now, true, string.Empty, CUserID,
                           ManageContactGroupTypes.PrivateModuleGroup.ToString(), UserModuleID, IsSystemGroup, IsMasterGroup);
                    }


                    // Group Name as Tab Name
                    // get Max contact group id for that user ID
                    maxContactGroupID = busobj.GetMaximunContactGroupIDForUserID(UserID);
                    // Add +1 to insert new contact group Id
                    maxContactGroupID = maxContactGroupID + 1;
                    // insert contact group for that userid
                    IsMasterGroup = false;
                    busobj.InsertContactGroupName(maxContactGroupID, tabName, UserID, DateTime.Now, DateTime.Now, true, string.Empty, CUserID,
                        ManageContactGroupTypes.PrivateModuleGroup.ToString(), UserModuleID, IsSystemGroup, IsMasterGroup);

                }


                #endregion


            }
            System.Threading.Thread.Sleep(3000);
            pnlProgress.Style.Add("display", "none");
            pnlSuccess.Style.Add("display", "block");
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "CrisisCallReport.aspx.cs", "lnkNext_Click", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void lnkAddCalendar_Click(object sender, EventArgs e)
    {
        try
        {
            ModalCalendorAddons.Show();
            pnlCalNameTab.Style.Add("display", "none");
            pnlCalProgress.Style.Add("display", "block");
            string appIcon = Convert.ToString(hdnModuleAppButton.Value);
            string tabName = Convert.ToString(hdnModuleAppName.Value);
            busobj.InsertUserCustomModules(ProfileID, UserID, CUserID, 0, appIcon, tabName, true, DateTime.Now, DateTime.Now, DateTime.Now.AddYears(1), "/Business/MyAccount/" + WebConstants.ManageUrl_CalendarAddOns, false, WebConstants.Tab_CalendarAddOns, WebConstants.Purchase_CalendarAddOns);
            System.Threading.Thread.Sleep(3000);
            pnlCalProgress.Style.Add("display", "none");
            pnlCalSuccess.Style.Add("display", "block");
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "CrisisCallReport.aspx.cs", "lnkAddCalendar_Click", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void lnkAddBannerAd_Click(object sender, EventArgs e)
    {
        try
        {
            ModalBannerAds.Show();
            pnlBannerAdTabName.Style.Add("display", "none");
            pnlBannerAdProgress.Style.Add("display", "block");
            string appIcon = Convert.ToString(hdnModuleAppButton.Value);
            string tabName = Convert.ToString(hdnModuleAppName.Value);
            busobj.InsertUserCustomModules(ProfileID, UserID, CUserID, 0, appIcon, tabName, true, DateTime.Now, DateTime.Now, DateTime.Now.AddYears(1), "/Business/MyAccount/" + WebConstants.ManageUrl_BannerAds, false, WebConstants.Tab_BannerAds, WebConstants.Purchase_BannerAds);
            System.Threading.Thread.Sleep(3000);
            pnlBannerAdProgress.Style.Add("display", "none");
            pnlBannerAdSuccess.Style.Add("display", "block");
        }
        catch (Exception ex)
        {
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "lnkAddBannerAd_Click", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private void GetDashboardCustomModules()
    {
        try
        {
            string strDomainname = (DomainName.ToLower().Equals("inschoolhubcom")) ? "inschoolhubcom" : null;
            string html = "";
            string navigatonUrl = "";
            string msg = Resources.LabelMessages.CustomModuleExpired;
            DataTable dtCustomModules = new DataTable();
            dtCustomModules = busobj.DashboardIcons(UserID);
            string filterQuery = string.Empty;
            filterQuery = "ButtonType='Call' or ButtonType='Contact' or ButtonType='Directions' or ButtonType='Tips' or Buttontype='SubApps' or ButtonType='" + WebConstants.Tab_BannerAds + "'";
            DataRow[] dRRemove = dtCustomModules.Select(filterQuery);
            DataTable dtAddButtons = new DataTable();
            if (dRRemove.Length > 0)
            {
                dtAddButtons = dRRemove.CopyToDataTable();
                for (int i = 0; i < dRRemove.Length; i++)
                {
                    dtCustomModules.Rows.Remove(dRRemove[i]);
                }
            }
            // Checking Sponsor sesstion value
            //USPD-1107 Permission related Changes
            string buttonVisibleClass = "";
            if (Session["IsSponsor"] == null)
            {
                for (int i = 0; i < dtCustomModules.Rows.Count; i++)
                {
                    navigatonUrl = dtCustomModules.Rows[i]["NavigationUrl"].ToString();
                    navigatonUrl = navigatonUrl.Replace("#UMID#", dtCustomModules.Rows[i]["UserModuleID"].ToString());
                    navigatonUrl = Page.ResolveClientUrl("~" + navigatonUrl);
                    if (Convert.ToBoolean(Session["IsLiteVersion"]) == true)
                        html = html + "<li class='litequicklnkmargin'><label title='" + dtCustomModules.Rows[i]["ToolTip"].ToString() + "'  id='lblImg" + (i + 10) + "'>";
                    else
                        html = html + "<li><label title='" + dtCustomModules.Rows[i]["ToolTip"].ToString() + "'  id='lblImg" + (i + 10) + "'>";
                    buttonVisibleClass = " appvisible";
                    if (!string.IsNullOrEmpty(Convert.ToString(dtCustomModules.Rows[i]["IsVisible"])))
                    {
                        if (!Convert.ToBoolean(dtCustomModules.Rows[i]["IsVisible"]))
                            buttonVisibleClass = " appnotvisible";
                    }
                    if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "Notifications")
                    {
                        if (PushNotifications)
                            html = html + "<a href='" + navigatonUrl + "'>";
                        else
                            html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "Bulletins")
                    {
                        if (IsBulletins == true && Bulletins == true)
                            html = html + "<a href='" + navigatonUrl + "'>";
                        else
                            html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "Surveys")
                    {
                        if (Surveys)
                            html = html + "<a href='" + navigatonUrl + "'>";
                        else
                            html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "EventCalendar")
                    {
                        if (IsEvent == true && Event == true)
                            html = html + "<a href='" + navigatonUrl + "'>";
                        else
                            html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "Updates")
                    {
                        if (IsUpdate == true && Update == true)
                            html = html + "<a href='" + navigatonUrl + "'>";
                        else
                            html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "Gallery")
                    {
                        if (Gallery == true)
                            html = html + "<a href='" + navigatonUrl + "'>";
                        else
                            html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == WebConstants.Tab_ContentAddOns)
                    {
                        bool isAuthor = false;
                        bool isPublisher = false;
                        DataTable dtUserPer = agencyobj.GetPermissionValueByUserModuleID(Convert.ToInt32(dtCustomModules.Rows[i]["UserModuleID"].ToString()), CUserID);
                        if (dtUserPer.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dtUserPer.Rows[0]["IsAuthor"].ToString()))
                                isAuthor = Convert.ToBoolean(dtUserPer.Rows[0]["IsAuthor"]);
                            if (!string.IsNullOrEmpty(dtUserPer.Rows[0]["IsPublisher"].ToString()))
                                isPublisher = Convert.ToBoolean(dtUserPer.Rows[0]["IsPublisher"]);
                        }
                        if (Session["C_USER_ID"] == null || Session["C_USER_ID"].ToString() == "")
                        {
                            isAuthor = true;
                            isPublisher = true;
                        }
                        if (Convert.ToString(dtCustomModules.Rows[i]["ExpiredDate"]) == "" || DateTime.Now <= Convert.ToDateTime(dtCustomModules.Rows[i]["ExpiredDate"]))
                        {
                            if (isAuthor == true || isPublisher)
                                html = html + "<a href='" + navigatonUrl + "'>";
                            else
                                html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                        }
                        else
                            html = html + "<a href=\"javascript:alert('" + msg + "');\">";

                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == WebConstants.Tab_PrivateContentAddOns
                        || Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == WebConstants.Tab_PrivateCallAddOns
                        || Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == WebConstants.Tab_PrivateSmartConnectAddOns
                        )
                    {
                        bool isAuthor = false;
                        bool isPublisher = false;
                        DataTable dtUserPer = agencyobj.GetPermissionValueByUserModuleID(Convert.ToInt32(dtCustomModules.Rows[i]["UserModuleID"].ToString()), CUserID);
                        if (dtUserPer.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dtUserPer.Rows[0]["IsAuthor"].ToString()))
                                isAuthor = Convert.ToBoolean(dtUserPer.Rows[0]["IsAuthor"]);
                            if (!string.IsNullOrEmpty(dtUserPer.Rows[0]["IsPublisher"].ToString()))
                                isPublisher = Convert.ToBoolean(dtUserPer.Rows[0]["IsPublisher"]);
                        }
                        if (Session["C_USER_ID"] == null || Session["C_USER_ID"].ToString() == "")
                        {
                            isAuthor = true;
                            isPublisher = true;
                        }
                        if (Convert.ToString(dtCustomModules.Rows[i]["ExpiredDate"]) == "" || DateTime.Now <= Convert.ToDateTime(dtCustomModules.Rows[i]["ExpiredDate"]))
                        {
                            if (isAuthor == true || isPublisher)
                            {
                                html = html + "<a href='" + navigatonUrl + "'>";
                            }
                            else
                                html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                        }
                        else
                            html = html + "<a href=\"javascript:alert('" + msg + "');\">";

                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == WebConstants.Tab_PublicCallAddOns)
                    {
                        bool isAuthor = false;
                        bool isPublisher = false;
                        DataTable dtUserPer = agencyobj.GetPermissionValueByUserModuleID(Convert.ToInt32(dtCustomModules.Rows[i]["UserModuleID"].ToString()), CUserID);
                        if (dtUserPer.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dtUserPer.Rows[0]["IsAuthor"].ToString()))
                                isAuthor = Convert.ToBoolean(dtUserPer.Rows[0]["IsAuthor"]);
                            if (!string.IsNullOrEmpty(dtUserPer.Rows[0]["IsPublisher"].ToString()))
                                isPublisher = Convert.ToBoolean(dtUserPer.Rows[0]["IsPublisher"]);
                        }
                        if (Session["C_USER_ID"] == null || Session["C_USER_ID"].ToString() == "")
                        {
                            isAuthor = true;
                            isPublisher = true;
                        }
                        if (Convert.ToString(dtCustomModules.Rows[i]["ExpiredDate"]) == "" || DateTime.Now <= Convert.ToDateTime(dtCustomModules.Rows[i]["ExpiredDate"]))
                        {
                            if (isAuthor == true || isPublisher)
                            {
                                html = html + "<a href='" + navigatonUrl + "'>";
                            }
                            else
                                html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                        }
                        else
                            html = html + "<a href=\"javascript:alert('" + msg + "');\">";

                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == WebConstants.Tab_CalendarAddOns)
                    {
                        bool isAuthor = false;
                        bool isPublisher = false;
                        DataTable dtUserPer = agencyobj.GetPermissionValueByUserModuleID(Convert.ToInt32(dtCustomModules.Rows[i]["UserModuleID"].ToString()), CUserID);
                        if (dtUserPer.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dtUserPer.Rows[0]["IsAuthor"].ToString()))
                                isAuthor = Convert.ToBoolean(dtUserPer.Rows[0]["IsAuthor"]);
                            if (!string.IsNullOrEmpty(dtUserPer.Rows[0]["IsPublisher"].ToString()))
                                isPublisher = Convert.ToBoolean(dtUserPer.Rows[0]["IsPublisher"]);
                        }
                        if (Session["C_USER_ID"] == null || Session["C_USER_ID"].ToString() == "")
                        {
                            isAuthor = true;
                            isPublisher = true;
                        }
                        if (Convert.ToString(dtCustomModules.Rows[i]["ExpiredDate"]) == "" || DateTime.Now <= Convert.ToDateTime(dtCustomModules.Rows[i]["ExpiredDate"]))
                        {
                            if (isAuthor == true || isPublisher)
                                html = html + "<a href='" + navigatonUrl + "'>";
                            else
                                html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                        }
                        else
                            html = html + "<a href=\"javascript:alert('" + msg + "');\">";

                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "Home")
                    {
                        if (Home)
                            html = html + "<a href='" + navigatonUrl + "'>";
                        else
                            html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "AboutUs")
                    {
                        if (AboutUs)
                            html = html + "<a href='" + navigatonUrl + "'>";
                        else
                            html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "WebLinks")
                    {
                        if (WebLinks)
                            html = html + "<a href='" + navigatonUrl + "'>";
                        else
                            html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "SocialMedia")
                    {
                        if (SocialMedia)
                            html = html + "<a href='" + navigatonUrl + "'>";
                        else
                            html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "CallDirectory")
                    {
                        html = html + "<a href='" + navigatonUrl + "'>";
                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle appvisible'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    else if (Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]) == "Messages")
                    {
                        html = html + "<a href='" + navigatonUrl + "'>";
                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle appvisible'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    }
                    //else
                    //{
                    //    string buttonType = Convert.ToString(dtCustomModules.Rows[i]["ButtonType"]);
                    //    if (buttonType == "AboutUs" || buttonType == "WebLinks" || buttonType == "SocialMedia" || buttonType == "Home")
                    //    {
                    //        if (MobileApp == true && IsMobileApp == true)
                    //            html = html + "<a href='" + navigatonUrl + "'>";
                    //        else
                    //         html = html + "<a href='javascript:CallAlert(\"" + dtCustomModules.Rows[i]["TabName"].ToString() + "\")';>";
                    //        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                    //        html = html + "<div class='QuicklinksNamesStyle'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    //    }
                    //    else if (navigatonUrl.ToLower().Contains("default.aspx"))
                    //    {
                    //        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtCustomModules.Rows[i]["AppIcon"].ToString() + ".png' class='image6' />";
                    //        html = html + "<div class='QuicklinksNamesStyle'>" + dtCustomModules.Rows[i]["TabName"].ToString() + "</div><label></li>";
                    //    }
                    //}
                }
            }
            if (dtAddButtons.Rows.Count > 0)
            {
                for (int j = 0; j < dtAddButtons.Rows.Count; j++)
                {
                    buttonVisibleClass = " appvisible";
                    if (!string.IsNullOrEmpty(Convert.ToString(dtAddButtons.Rows[j]["IsVisible"])))
                    {
                        if (!Convert.ToBoolean(dtCustomModules.Rows[j]["IsVisible"]))
                            buttonVisibleClass = " appnotvisible";
                    }
                    if (Convert.ToString(dtAddButtons.Rows[j]["ButtonType"]) == WebConstants.Tab_BannerAds)
                    {
                        navigatonUrl = dtAddButtons.Rows[j]["NavigationUrl"].ToString();
                        navigatonUrl = navigatonUrl.Replace("#UMID#", dtAddButtons.Rows[j]["UserModuleID"].ToString());
                        navigatonUrl = Page.ResolveClientUrl("~" + navigatonUrl);
                        html = html + "<li><label title='" + dtAddButtons.Rows[j]["TabName"].ToString() + "'  id='lblImg" + (dtCustomModules.Rows.Count + 10) + "'>";
                        bool isPublisher = false;
                        DataTable dtUserPer = agencyobj.GetPermissionValueByUserModuleID(Convert.ToInt32(dtAddButtons.Rows[j]["UserModuleID"].ToString()), CUserID);
                        if (dtUserPer.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dtUserPer.Rows[0]["IsPublisher"].ToString()))
                                isPublisher = Convert.ToBoolean(dtUserPer.Rows[0]["IsPublisher"]);
                        }
                        if (Session["C_USER_ID"] == null || Session["C_USER_ID"].ToString() == "")
                            isPublisher = true;
                        if (Convert.ToString(dtAddButtons.Rows[j]["ExpiredDate"]) == "" || DateTime.Now <= Convert.ToDateTime(dtAddButtons.Rows[j]["ExpiredDate"]))
                        {
                            if (isPublisher)
                                html = html + "<a href='" + navigatonUrl + "'>";
                            else
                                html = html + "<a href='javascript:CallAlert(\"" + dtAddButtons.Rows[j]["TabName"].ToString() + "\")';>";
                        }
                        else
                            html = html + "<a href=\"javascript:alert('" + msg + "');\">";

                        html = html + "<img src='/images/Dashboard/CustomModulesDashboardIcons/" + dtAddButtons.Rows[j]["AppIcon"].ToString() + ".png' class='image6' /></a>";
                        html = html + "<div class='QuicklinksNamesStyle" + buttonVisibleClass + "'>" + dtAddButtons.Rows[j]["TabName"].ToString() + "</div><label></li>";
                        break;
                    }
                }
            }
            ltrlAdditems.Text = html;
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "GetDashboardCustomModules", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    public class AppIcons
    {
        public string AppIcon { get; set; }
        public string ModuleID { get; set; }
        public string ImagePath { get; set; }
    }
    [WebMethod(EnableSession = true)]
    public static AppIcons[] BindAppIcons(string moduleID, string purchaseType)
    {
        List<AppIcons> details = new List<AppIcons>();
        try
        {
            string rootPath = HttpContext.Current.Session["RootPath"].ToString();
            DataTable dtAppIcons = new DataTable();

            string domainName = HttpContext.Current.Session["VerticalDomain"].ToString();
            AgencyBLL agencyobj = new AgencyBLL();
            bool isPrivate = purchaseType == WebConstants.Purchase_PrivateContentAddOns ? true : false;
            if (purchaseType == WebConstants.Purchase_PrivateCallAddOns || purchaseType == WebConstants.Purchase_PrivateSmartConnectAddOns)
                isPrivate = true;
            if (moduleID != "")
            {
                dtAppIcons = agencyobj.GetCustomModuleAppIcons(Convert.ToInt32(moduleID), domainName, isPrivate);
                foreach (DataRow dtrow in dtAppIcons.Rows)
                {
                    AppIcons appIcon = new AppIcons();
                    appIcon.AppIcon = dtrow["AppIcon"].ToString();
                    appIcon.ModuleID = moduleID;
                    appIcon.ImagePath = rootPath + "/Images/CustomModulesAppIcons/" + dtrow["AppIcon"].ToString() + ".png"; ;
                    details.Add(appIcon);
                }
            }
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "BindAppIcons", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        return details.ToArray();
    }
    [WebMethod]
    public static string UpdateLaunchPlay(string playType)
    {
        try
        {
            BusinessBLL obBus = new BusinessBLL();
            int lUserID = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserID"]);
            if (System.Web.HttpContext.Current.Session["C_USER_ID"] != null)
                lUserID = Convert.ToInt32(System.Web.HttpContext.Current.Session["C_USER_ID"]);
            obBus.UpdateLaunchPlay(lUserID, playType);
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            objInBuiltData.ErrorHandling("ERROR", "Default.aspx.cs", "UpdateLaunchPlay", Convert.ToString(ex.Message),
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        return "1";
    }
    [WebMethod(EnableSession = true)]
    public static List<ContentActivity> GetContentActivityLog(int Start, int End)
    {
        List<ContentActivity> list = new List<ContentActivity>();
        BusinessBLL business = new BusinessBLL();
        string profileID = HttpContext.Current.Session["ProfileID"].ToString();
        string vertical = HttpContext.Current.Session["VerticalDomain"].ToString();
        DataTable dt = business.getManageContentActivityLogs(vertical, Start, End, int.Parse(profileID));
        if (dt != null && dt.Rows.Count > 0)
        {
            ContentActivity obj;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                obj = new ContentActivity();
                obj.ID = int.Parse(dt.Rows[i]["ActivityID"].ToString());
                obj.Title = dt.Rows[i]["ActivityTitle"].ToString();
                obj.PreviewHTML = dt.Rows[i]["PreviewHtml"].ToString();
                obj.ModifiedDate = dt.Rows[i]["ModifiedDate"].ToString();
                list.Add(obj);
            }
        }
        return list;
    }

    //protected void btnPremium_Click(object sender, EventArgs e)
    //{


    //    ModalPremium.Show();
    //}
    protected void btnSubmitPremium_Click(object sender, EventArgs e)
    {
        string PreferedDate = "";
        DataTable dtProfile = busobj.GetProfileDetailsByProfileID(ProfileID);
        if (dtProfile.Rows.Count > 0)
        {
            profileName = dtProfile.Rows[0]["Profile_Name"].ToString();
            UserId = dtProfile.Rows[0]["User_ID"].ToString();
        }

        DataTable dtConfigsemails = cmbobj.GetVerticalConfigsByType(DomainName, "EmailAccounts");
        if (dtConfigsemails.Rows.Count > 0)
        {
            foreach (DataRow row in dtConfigsemails.Rows)
            {
                if (row[0].ToString() == "EmailInfo")
                    emailInfo = row[1].ToString();
            }
        }
        string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + " \\";
        StreamReader re = File.OpenText(strfilepath + "UpgradePremiumContent.txt");
        StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
        string msgbody = string.Empty;
        string content = string.Empty;
        string desclaimer = string.Empty;
        while ((desclaimer = reDeclaimer.ReadLine()) != null)
        {
            msgbody = msgbody + desclaimer;
        }
        desclaimer = "";
        string input = string.Empty;
        while ((input = re.ReadLine()) != null)
        {
            content = content + input + "<BR/>";
        }
        re.Close();
        re.Dispose();
        msgbody = msgbody.Replace("#RootUrl#", RootPath);
        msgbody = msgbody.Replace("#msgBody#", content);
        msgbody = msgbody.Replace("#Name#", profileName);
        msgbody = msgbody.Replace("#UserId#", UserId);
        msgbody = msgbody.Replace("#AgencyName#", txtProfileName.Text.Trim());
        msgbody = msgbody.Replace("#ContactName#", txtCntctName.Text.Trim());
        msgbody = msgbody.Replace("#PhoneNumber#", txtNumber.Text.Trim());
        if (txtPreferedDate.Text.Trim() != "" && txtHours.Text.Trim() != "" && txtMinutes.Text.Trim() != "")
        {
            PreferedDate = txtPreferedDate.Text.Trim().PadRight(30) + " " + txtHours.Text.Trim() + ":" + txtMinutes.Text.Trim().PadRight(30) + ddlFromSS.SelectedValue;
        }
        else if (txtPreferedDate.Text.Trim() != "" && txtHours.Text.Trim() != "")
        {
            PreferedDate = txtPreferedDate.Text.Trim().PadRight(30) + " " + txtHours.Text.Trim() + ":00".PadRight(30) + ddlFromSS.SelectedValue;
        }
        else
        {
            PreferedDate = txtPreferedDate.Text.Trim();
        }
        msgbody = msgbody.Replace("#Date#", PreferedDate);
        //msgbody = msgbody.Replace("#time#", txtHours.Text.Trim());
        //msgbody = msgbody.Replace("#min# ", txtMinutes.Text.Trim());
        //msgbody = msgbody.Replace("#am#", ddlFromSS.SelectedValue);
        msgbody = msgbody.Replace("#Email#", txtMail.Text);

        msgbody = msgbody.Replace("#Remarks#", lblRemarks.Text.Trim());
        reDeclaimer = File.OpenText(strfilepath + "UpgradeInfoMails.txt");
        string toEmails = string.Empty;
        while ((desclaimer = reDeclaimer.ReadLine()) != null)
        {
            toEmails = toEmails + desclaimer;
        }
        re.Close();
        re.Dispose();
        string ccemail = string.Empty;
        while ((desclaimer = reDeclaimer.ReadLine()) != null)
        {
            ccemail = ccemail + desclaimer;
        }
        re.Dispose();
        reDeclaimer.Close();
        reDeclaimer.Dispose();
        UtilitiesBLL utlobj = new UtilitiesBLL();
        utlobj.SendWowzzyEmail(emailInfo, toEmails, "Request for Upgrade to Premium Membership", msgbody, "", "", DomainName);
        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
    "alert('We received your request. Customer service  will call you soon.');", true);
    }

    protected void btnSubmitBrandedApp_Click(object sender, EventArgs e)
    {
        string emailInfo = "";
        string profileName = "";
        string UserId = "";
        string PreferedDate = "";
        DataTable dtProfile = busobj.GetProfileDetailsByProfileID(ProfileID);
        if (dtProfile.Rows.Count > 0)
        {
            profileName = dtProfile.Rows[0]["Profile_Name"].ToString();
            UserId = dtProfile.Rows[0]["User_ID"].ToString();
        }
        DataTable dtConfigsemails = cmbobj.GetVerticalConfigsByType(DomainName, "EmailAccounts");
        if (dtConfigsemails.Rows.Count > 0)
        {
            foreach (DataRow row in dtConfigsemails.Rows)
            {
                if (row[0].ToString() == "EmailInfo")
                    emailInfo = row[1].ToString();
            }
        }
        string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + " \\";
        StreamReader re = File.OpenText(strfilepath + "BrandedAppContent.txt");
        StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
        string msgbody = string.Empty;
        string content = string.Empty;
        string desclaimer = string.Empty;
        while ((desclaimer = reDeclaimer.ReadLine()) != null)
        {
            msgbody = msgbody + desclaimer;
        }
        desclaimer = "";
        string input = string.Empty;
        while ((input = re.ReadLine()) != null)
        {
            content = content + input + "<BR/>";
        }
        re.Close();
        re.Dispose();
        msgbody = msgbody.Replace("#RootUrl#", RootPath);
        msgbody = msgbody.Replace("#msgBody#", content);
        msgbody = msgbody.Replace("#Name#", profileName);
        msgbody = msgbody.Replace("#UserId#", UserId);
        msgbody = msgbody.Replace("#AgencyName#", txtbrndProfilename.Text.Trim());
        msgbody = msgbody.Replace("#ContactName#", txtbrndcntct.Text.Trim());
        msgbody = msgbody.Replace("#PhoneNumber#", txtbrndnum.Text.Trim());
        if (txtprfrdDate.Text.Trim() != "" && txthrs.Text.Trim() != "" && txtmns.Text.Trim() != "")
        {
            PreferedDate = txtprfrdDate.Text.Trim().PadRight(30) + " " + txthrs.Text.Trim() + ":" + txtmns.Text.Trim().PadRight(30) + ddlam.SelectedValue;
        }
        else if (txtprfrdDate.Text.Trim() != "" && txthrs.Text.Trim() != "")
        {
            PreferedDate = txtprfrdDate.Text.Trim().PadRight(30) + " " + txthrs.Text.Trim() + ":00".PadRight(30) + ddlam.SelectedValue;
        }
        else
        {
            PreferedDate = txtprfrdDate.Text.Trim();
        }
        msgbody = msgbody.Replace("#Date#", PreferedDate);
        //msgbody = msgbody.Replace("#time#", txthrs.Text.Trim());
        //msgbody = msgbody.Replace("#min# ", txtmns.Text.Trim());
        //msgbody = msgbody.Replace("#am#", ddlam.SelectedValue);
        msgbody = msgbody.Replace("#Email#", txtbrndmail.Text.ToString());


        msgbody = msgbody.Replace("#Remarks#", txtRemarks.Text.Trim());
        reDeclaimer = File.OpenText(strfilepath + "BrandedInfoMails.txt");
        string toEmails = string.Empty;
        while ((desclaimer = reDeclaimer.ReadLine()) != null)
        {
            toEmails = toEmails + desclaimer;
        }
        re.Close();
        re.Dispose();
        string ccemail = string.Empty;
        while ((desclaimer = reDeclaimer.ReadLine()) != null)
        {
            ccemail = ccemail + desclaimer;
        }
        re.Dispose();
        reDeclaimer.Close();
        reDeclaimer.Dispose();
        UtilitiesBLL utlobj = new UtilitiesBLL();
        utlobj.SendWowzzyEmail(emailInfo, toEmails, "Request for Branded App", msgbody, "", "", DomainName);
        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
    "alert('We received your request. Customer service  will call you soon.');", true);

    }

    protected void lnkPremium_OnClick(object sender, EventArgs e)
    {
        getProfileDetails();
        ModalPremium.Show();
    }

    protected void lnkBrandedApp_OnClick(object sender, EventArgs e)
    {
        getProfileDetails();
        ModalBrandedApp.Show();
    }

    protected void btnAccept_OnClick(object sender, EventArgs e)
    {
        busobj.UpdateSubAppInvitationRequest(Convert.ToInt32(hdnInvitationID.Value), ProfileID, "Accepted", txtNotes.Text.Trim());

        /*** Sending Approve email ***/
        SendingSubAppEMail_Approve_Rejected("Accepted");

        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
    }

    protected void lnkDecline_OnClick(object sender, EventArgs e)
    {
        busobj.UpdateSubAppInvitationRequest(Convert.ToInt32(hdnInvitationID.Value), ProfileID, "Declined", txtNotes.Text.Trim());

        /*** Sending Rejected email ***/
        SendingSubAppEMail_Approve_Rejected("Declined");

        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
    }


    private void SendingSubAppEMail_Approve_Rejected(string pStatus)
    {
        string emailInfo = "";
        DataTable dtConfigsemails = cmbobj.GetVerticalConfigsByType(DomainName, "EmailAccounts");
        if (dtConfigsemails.Rows.Count > 0)
        {
            foreach (DataRow row in dtConfigsemails.Rows)
            {
                if (row[0].ToString() == "EmailInfo")
                    emailInfo = row[1].ToString();
            }
        }
        string secureRootPath = cmbobj.GetConfigSettings(Session["ProfileID"].ToString(), "Paths", "RootPath");

        string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
        StreamReader re = File.OpenText(strfilepath + "SubAppInvitationApprove_RejectedEmail.txt");
        string msgbody = string.Empty;
        string content = string.Empty;
        string input = string.Empty;
        while ((input = re.ReadLine()) != null)
        {
            msgbody = msgbody + input;
        }
        re.Close();
        re.Dispose();

        DataTable dtProfileDetails = busobj.GetProfileDetailsByProfileID(ProfileID);

        #region Logo Binding
        string logourl = string.Empty;

        if (dtProfileDetails.Rows[0]["Profile_logo_path"].ToString().Length > 0)
            logourl = dtProfileDetails.Rows[0]["Profile_logo_path"].ToString();
        if (logourl.Length > 0)
        {
            string originalfilename = logourl;
            string extension = System.IO.Path.GetExtension(Server.MapPath(originalfilename));

            string junk = ".";
            string[] ret = originalfilename.Split(junk.ToCharArray());
            string thumbimg1 = ret[0];
            thumbimg1 = thumbimg1 + "_thumb" + extension;
            string url = Server.MapPath("~") + "\\Upload\\Logos\\" + ProfileID + "\\" + thumbimg1;
            FileInfo obj = new FileInfo(url);


            if (obj.Exists)
            {
                string imageDisID = Guid.NewGuid().ToString();
                logourl = secureRootPath + "/Upload/Logos/" + ProfileID + "/" + thumbimg1 + "?Guid=" + imageDisID;

            }
            else
            {
                string imageDisID = Guid.NewGuid().ToString();
                logourl = secureRootPath + "/Upload/Logos/" + ProfileID + "/" + logourl + "?Guid=" + imageDisID;

            }
        }

        #endregion

        DataTable dtParentProfile = busobj.GetProfileDetailsByProfileID(Convert.ToInt32(dtProfileDetails.Rows[0]["Parent_ProfileID"]));

        msgbody = msgbody.Replace("#Status#", pStatus);
        msgbody = msgbody.Replace("#ProfileLogo#", "<IMG SRC='" + logourl + "' border='0' />");
        msgbody = msgbody.Replace("#AppName#", dtProfileDetails.Rows[0]["Profile_name"].ToString());
        msgbody = msgbody.Replace("#Time#", DateTime.Now.ToString("MM/dd/yyyy HH:mm tt"));
        msgbody = msgbody.Replace("#Notes#", txtNotes.Text.Trim());
        msgbody = msgbody.Replace("#AgencyOwnerEmailID#", dtProfileDetails.Rows[0]["Username"].ToString());
        //msgbody = msgbody.Replace("#LoginLink#", "<a href='" + secureRootPath + "/OP/" + DomainName + "/login.aspx" + "' target=_new>" + secureRootPath + "/OP/" + DomainName + "/login.aspx</a>");


        USPDHUBBLL.UtilitiesBLL utlobj = new USPDHUBBLL.UtilitiesBLL();
        utlobj.SendWowzzyEmail(emailInfo, dtParentProfile.Rows[0]["Username"].ToString(), pStatus + " Sub-App Invitation from " + dtProfileDetails.Rows[0]["Profile_name"].ToString(), msgbody, "", "", DomainName);

    }

    public void getProfileDetails()
    {
        lblRemarks.Text = "";
        txtRemarks.Text = "";

        txtprfrdDate.Text = "";
        txthrs.Text = "";
        txtmns.Text = "";

        txtPreferedDate.Text = "";
        txtHours.Text = "";
        txtMinutes.Text = "";

        DataTable dtProfile = busobj.GetProfileDetailsByProfileID(ProfileID);
        if (dtProfile.Rows.Count > 0)
        {
            txtProfileName.Text = profileName = dtProfile.Rows[0]["Profile_Name"].ToString();

            txtCntctName.Text = dtProfile.Rows[0]["Profile_Contact_Name"].ToString();
            txtNumber.Text = dtProfile.Rows[0]["Profile_Phone1"].ToString();
            txtMail.Text = Session["Username"].ToString();
            txtbrndcntct.Text = dtProfile.Rows[0]["Profile_Contact_Name"].ToString();
            txtbrndProfilename.Text = profileName = dtProfile.Rows[0]["Profile_Name"].ToString();
            txtbrndnum.Text = dtProfile.Rows[0]["Profile_Phone1"].ToString();
            txtbrndcntct.Text = dtProfile.Rows[0]["Profile_Contact_Name"].ToString();
            txtbrndmail.Text = Session["Username"].ToString();

        }
    }

}
public class ContentActivity
{
    public int ID;
    public string Title;
    public string PreviewHTML;
    public string ModifiedDate;
}
