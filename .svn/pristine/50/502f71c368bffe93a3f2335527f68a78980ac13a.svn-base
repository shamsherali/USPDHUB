using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;

namespace USPDHUB.Business.MyAccount
{
    public partial class LiteDashboard : BaseWeb
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public int CUserID = 0;
        public bool CheckProfile = true;
        public bool CheckDescription = true;
        public bool CheckAppSettings = true;
        public bool PushNotifications = true;
        public bool AboutUs = true;
        public bool IsAppStastics = true;
        public string RootPath = "";
        public string DomainName = "";
        public string DomainNameenc = "";
        public string VerticalType = "";
        public string ExpDaysalert = "";
        public string DisplayName = "";
        public int FreeFlag = 0;
        public int FreetrialRemainingdays = 0;
        Consumer _objConsumer = new Consumer();
        BusinessBLL _objBusiness = new BusinessBLL();
        AgencyBLL _objAgency = new AgencyBLL();
        CommonBLL _objCommon = new CommonBLL();
        SMSBLL _objSMS = new SMSBLL();
        AddOnBLL _objAddOn = new AddOnBLL();
        InBuiltDataBLL _objInBuiltData = new InBuiltDataBLL();
        DataTable dtpermissions = new DataTable();
        StringBuilder strNotifications = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                CUserID = Convert.ToInt32(Session["C_USER_ID"]);
            else
                CUserID = UserID;
            DomainName = Session["VerticalDomain"].ToString();
            DomainNameenc = EncryptDecrypt.DESEncrypt(DomainName);
            RootPath = Session["RootPath"].ToString();
            GetUpdatedProfileDetails();
            if (!IsPostBack)
            {
                //CREATED_DT
                DataTable dtProfile = _objBusiness.GetProfileDetailsByProfileID(ProfileID);
                if (!Convert.ToBoolean(dtProfile.Rows[0]["IsLiteVersion"]))
                    Response.Redirect("Default.aspx");
                ddlTimeZones.SelectedValue = dtProfile.Rows[0]["TimeZoneID"].ToString();
                Session["IsLiteVersion"] = Convert.ToBoolean(dtProfile.Rows[0]["IsLiteVersion"]);
                hdnTimeZoneID.Value = dtProfile.Rows[0]["Display_Value"].ToString();
                DataTable dtobj = new DataTable();
                dtobj = _objConsumer.GetUserDetailsByID(UserID);
                Session["BusinessUserFirstName"] = dtobj.Rows[0]["Firstname"].ToString();
                _objAddOn.InsertDefaultAppButtons(ProfileID, UserID, DomainName, CUserID);
                AddDefaultCallAddOnForLite();
                # region Check for User Name and For Free User
                // *** Start Checking for User Name and For Free User ***               
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
                // *** Adding page title and meta keys for page *** //
                DataTable dtConfigPageKeys1 = _objCommon.GetVerticalConfigsByType(DomainName, "VerticalNames");
                if (dtConfigPageKeys1.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigPageKeys1.Rows)
                    {
                        if (row[0].ToString() == "DisplayLogin")
                            VerticalType = row[1].ToString().ToLower();
                    }
                }

                DateTime dt = Convert.ToDateTime(dtProfile.Rows[0]["CREATED_DT"]).AddDays(Convert.ToInt32(ConfigurationManager.AppSettings.Get("DownloadPDFExpiryDays")));
                if (dt > DateTime.Now)
                {
                    lblDownloadExpiry.Text = "Yes";
                }
                lblTotalSMSOptIns.Text = Convert.ToString(_objBusiness.GetCallTotalSMSOptIns(ProfileID));
                CheckDashboardFlow();
                SMSSentCount();
                GetCallAddOnId();
            }
            # region Check For User Subscription
            // *** Get User SubscriptionDetails and show expiration ***
            // *** if Paid user ***
            if (FreeFlag == 0)
            {
                int expdays = 0;
                DataTable dtSubscriptionDetails = new DataTable();
                dtSubscriptionDetails = _objBusiness.GetOrderSubscriptionByProfileID(Convert.ToInt32(Session["ProfileID"].ToString()));
                if (dtSubscriptionDetails.Rows.Count > 0)
                {
                    DateTime renewalDate;
                    renewalDate = Convert.ToDateTime(dtSubscriptionDetails.Rows[0]["subscription_renewal_date"].ToString());
                    DateTime currentDate = DateTime.Now.Date;
                    TimeSpan rnts = renewalDate.Subtract(currentDate);
                    int nODays = rnts.Days;
                    if (dtSubscriptionDetails.Rows[0]["fullperiod"].ToString() == "1")
                    {
                        expdays = Convert.ToInt32(ConfigurationManager.AppSettings.Get("NotificationsDaysForMonth"));
                    }
                    else
                    {
                        expdays = Convert.ToInt32(ConfigurationManager.AppSettings.Get("NotificationsDaysForYear"));
                    }
                    // *** Start Issue 1169 *** //
                    if (Session["Renewal"] != null && Session["Renewal"].ToString() == "1")
                    {
                        ExpDaysalert = "1";
                        hdnEpireStatus.Value = "true";
                        // *** 1199  *** //
                        if (!string.IsNullOrEmpty(dtSubscriptionDetails.Rows[0]["Discount_Code"].ToString()))
                        {
                            if (dtSubscriptionDetails.Rows[0]["Discount_Code"].ToString() == "FreeTrial")
                                strNotifications.Append("<p><img src=\"" + RootPath + "/images/liteimages/star.png\" />Your Free Trial Period has expired. <a href='" + ConfigurationManager.AppSettings.Get("ShoppingCartRootPath") + "/RedirectPage.aspx?MID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&MPID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString()) + "&CID=" + EncryptDecrypt.DESEncrypt(CUserID.ToString()) + "&VC=" + EncryptDecrypt.DESEncrypt(DomainName) + "&ReqType=1' style='color:Red;'" + ">Click here</a> to renew.</p>");
                            else
                                strNotifications.Append("<p><img src=\"" + RootPath + "/images/liteimages/star.png\" />Your subscription has expired. <a href='" + ConfigurationManager.AppSettings.Get("ShoppingCartRootPath") + "/RedirectPage.aspx?MID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&MPID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString()) + "&CID=" + EncryptDecrypt.DESEncrypt(CUserID.ToString()) + "&VC=" + EncryptDecrypt.DESEncrypt(DomainName) + "&ReqType=1' style='color:Red;'" + ">Click here</a> to renew.</p>");
                        }
                        else
                            strNotifications.Append("<p><img src=\"" + RootPath + "/images/liteimages/star.png\" />Your subscription has expired. <a href='" + ConfigurationManager.AppSettings.Get("ShoppingCartRootPath") + "/RedirectPage.aspx?MID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&MPID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString()) + "&CID=" + EncryptDecrypt.DESEncrypt(CUserID.ToString()) + "&VC=" + EncryptDecrypt.DESEncrypt(DomainName) + "&ReqType=1' style='color:Red;'" + ">Click here</a> to renew.</p>");
                    }
                    else if (!string.IsNullOrEmpty(dtSubscriptionDetails.Rows[0]["Discount_Code"].ToString()))
                    {
                        if (dtSubscriptionDetails.Rows[0]["Discount_Code"].ToString() == "FreeTrial")
                        {
                            FreetrialRemainingdays = nODays;
                            if (FreetrialRemainingdays == 0)
                            {
                                Session["Free"] = "1";
                                Session["Renewal"] = "1";
                                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
                            }
                            if (FreetrialRemainingdays == 1)
                            {
                                strNotifications.Append("<p><img src=\"" + RootPath + "/images/liteimages/star.png\" />Trial (" + nODays + " day remaining)</p>");
                            }
                            else
                            {
                                strNotifications.Append("<p><img src=\"" + RootPath + "/images/liteimages/star.png\" />Trial (" + nODays + " days remaining)</p>");
                            }
                        }
                    }
                    else if (nODays <= expdays)
                    {
                        if (Session["Renewal"] == null)
                        {
                            //********************* Changed the text "Click Live Help" to Chat now! on 07/31/2014 *********************//
                            strNotifications.Append("<p><img src=\"" + RootPath + "/images/liteimages/star.png\" />" + Resources.LabelMessages.RenewalAlert.Replace("#RenewalDate#", renewalDate.Date.ToString("MM/dd/yyyy")) + "</p>");
                        }
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
                                // *** Adding page title and meta keys for page *** //
                                DataTable dtConfigPageKeys = _objCommon.GetVerticalConfigsByType(DomainName, "VerticalNames");
                                if (dtConfigPageKeys.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dtConfigPageKeys.Rows)
                                    {
                                        if (row[0].ToString() == "NameForDisplay")
                                            DisplayName = row[1].ToString();
                                    }
                                }
                                strNotifications.Append("<p><img src=\"" + RootPath + "/images/liteimages/star.png\" />Your credit card ending with " + ccnumber + " will be expiring soon. To avoid any disruption to your " + DisplayName + "<sup style='font-size: 12px;'>&reg;</sup> membership. <span><a id='cc' href='javascript:void(0);' onclick='fireServerButtonEvent()' runat='server' >Click Here</a></span> to update your card information.</p>");
                            }
                        }
                    }
                }
            }
            // End
            // *** Notification Alert *** //
            ltrNotifications.Text = strNotifications.ToString();
            // *** End Notification Alert *** //
            # endregion
            DataTable dtLUser = _objBusiness.GetUserDtlsByUserID(CUserID);
            if (Convert.ToBoolean(dtLUser.Rows[0]["IsLaunchPlay"].ToString()) == true)
                hdnLaunchPlay.Value = "Yes";
            else
                hdnLaunchPlay.Value = "No";
        }
        private void SMSSentCount()
        {
            DataTable dtSMSCount = new DataTable();
            dtSMSCount = _objSMS.GetAllSMSCount(ProfileID);
            if (dtSMSCount.Rows.Count > 0)
            {
                foreach (DataRow row in dtSMSCount.Rows)
                {
                    string temp = row.Field<int>("Remaining_SMS_Count").ToString();
                    if (Convert.ToInt32(temp) <= 0)
                        lblRemainingSMS.Text = "0";
                    else
                        lblRemainingSMS.Text = row.Field<int>("Remaining_SMS_Count").ToString();
                }
            }
        }
        private void AddDefaultCallAddOnForLite()
        {
            int callAddOnCount = _objBusiness.CheckDefaultAddonForLite(ProfileID, WebConstants.Tab_PrivateCallAddOns);
            if (callAddOnCount == 0)
            {
                DataTable dtSubscriptionDetails = new DataTable();
                DateTime renewalDate = DateTime.Now.AddYears(1);
                dtSubscriptionDetails = _objBusiness.GetOrderSubscriptionByProfileID(Convert.ToInt32(Session["ProfileID"].ToString()));
                if (dtSubscriptionDetails.Rows.Count > 0)
                {
                    renewalDate = Convert.ToDateTime(dtSubscriptionDetails.Rows[0]["subscription_renewal_date"].ToString());
                }
                int UserModuleID = _objBusiness.InsertUserCustomModules(ProfileID, UserID, CUserID, 0, Convert.ToString(ConfigurationManager.AppSettings["DefaultCallAddonIcon"]), Convert.ToString(ConfigurationManager.AppSettings["DefaultCallAddonName"]), true, DateTime.Now, DateTime.Now, renewalDate, "/Business/MyAccount/" + WebConstants.ManageUrl_PrivateCallAddOns, false, WebConstants.Tab_PrivateCallAddOns, WebConstants.Purchase_PrivateCallAddOns);
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
                    _objCommon.AddCallModuleDefaultImages(UserModuleID, ProfileID, UserID, CUserID, WebConstants.Purchase_PrivateCallAddOns);
                    DataTable dtCallModuleDefaultItems = _objAddOn.GetCallModuleDefaultitems(DomainName, WebConstants.Purchase_PrivateCallAddOns);
                    if (dtCallModuleDefaultItems.Rows.Count > 0)
                    {
                        bool IsIntiatePhoneCall = true;
                        bool IsCustomPredefinedMessage = false;
                        string imagePath = RootPath + "/Upload/CallModule/" + ProfileID + "/" + UserModuleID + "/";
                        for (int i = 0; i < dtCallModuleDefaultItems.Rows.Count; i++)
                        {
                            _objAddOn.InsertUpdateCallIndexData(0, ProfileID, UserID, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["CallTitle"]), imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["MobileNumber"]), false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailDescription"]), "0",
                                    false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PushNotificationDescription"]), "0", false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSDescription"]), "0", false, false,
                                    true, CUserID, CUserID, UserModuleID, false, false, false, Convert.ToString(dtCallModuleDefaultItems.Rows[i]["EmailSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PushNotificationSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["SMSSubject"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["Description"]), Convert.ToString(dtCallModuleDefaultItems.Rows[i]["PreviewHtml"]).Replace("##Rootpath##", RootPath).Replace("##ImagePathUrl##", imagePath + Convert.ToString(dtCallModuleDefaultItems.Rows[i]["ImagePath"])), false, IsIntiatePhoneCall, IsCustomPredefinedMessage,false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _objInBuiltData.ErrorHandling("ERROR", "LiteDashboard.aspx.cs", "AddDefaultCallAddOnForLite()", ex.Message,
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                }
            }
        }
        private void GetCallAddOnId()
        {
            DataTable dtCustomModules = _objBusiness.DashboardIcons(UserID);
            string filterQuery = string.Empty;
            filterQuery = "ButtonType='CallDirectory' or ButtonType='" + WebConstants.Tab_PrivateCallAddOns + "'";
            DataRow[] dRRemove = dtCustomModules.Select(filterQuery);
            DataTable dtAddButtons = new DataTable();
            if (dRRemove.Length > 0)
            {
                hdnCallAddOnId.Value = Convert.ToString(dRRemove[0]["UserModuleID"]);
            }
        }
        private void CheckDashboardFlow()
        {
            DataTable dtCheckFlow = _objBusiness.GetDashboardFlow(UserID, CUserID);
            if (dtCheckFlow.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtCheckFlow.Rows[0]["IsCompleted"].ToString()) == false)
                {
                    CheckProfile = Convert.ToBoolean(dtCheckFlow.Rows[0]["IsProfile"].ToString());
                    CheckAppSettings = Convert.ToBoolean(dtCheckFlow.Rows[0]["IsAppSettings"].ToString());
                }
            }
            // *** Checking for user permissions *** //
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Roles & permissions
            {
                dtpermissions = _objAgency.GetPermissionsById(Convert.ToInt32(Session["C_USER_ID"]));
                PushNotifications = false;
                AboutUs = false;
                IsAppStastics = false;
            }
            if (dtpermissions.Rows.Count > 0 && Session["Free"] == null) //roles & permissions...
            {
                string val = _objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "PushNotifications");
                if (val == "P")
                    PushNotifications = true;
                val = _objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AboutUs");
                if (val == "P")
                    AboutUs = true;
                val = _objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, CommonModules.AppStatistics.ToString());
                if (val == "P")
                    IsAppStastics = true;
            }
        }
        private void GetUpdatedProfileDetails()
        {
            // *** Binding Time Zones *** //
            string url = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
            string countryValue = "United States";
            if (url.Contains(ConfigurationManager.AppSettings["UrlInschoolIndia"]))
                countryValue = "India";
            DataTable dtTimeZones = _objBusiness.GetTimeZones(countryValue);
            if (dtTimeZones.Rows.Count > 0)
            {
                ddlTimeZones.DataSource = dtTimeZones;
                ddlTimeZones.DataTextField = "Display_Name";
                ddlTimeZones.DataValueField = "TimeZone_ID";
                ddlTimeZones.DataBind();
            }
        }
        protected void lnkBuyMore_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigurationManager.AppSettings["ShoppingCartRootPath"] + "/RedirectPage.aspx?MID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&MPID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString()) + "&CID=" + EncryptDecrypt.DESEncrypt(CUserID.ToString()) + "&VC=" + EncryptDecrypt.DESEncrypt(DomainName) + "&ReqType=4&RType=4");
        }
        protected void lnkInvitations_Click(object sender, EventArgs e)
        {
            if (hdnCallAddOnId.Value != "")
            {
                Session["CustomModuleID"] = hdnCallAddOnId.Value;
                Response.Redirect("SetupCallIndexInvitation.aspx?Manage=1");
            }
        }
        protected void lnkContacts_Click(object sender, EventArgs e)
        {
            if (hdnCallAddOnId.Value != "")
            {
                Session["CustomModuleID"] = hdnCallAddOnId.Value;
                Response.Redirect(RootPath + "/Business/MyAccount/ManageCallIndexContacts.aspx?IsScr=1");
            }
        }
        protected void lnkUpdateCredicard_OnClick(object sender, EventArgs e)
        {
            DataTable dtCreditCardDetails = _objBusiness.GetOrderSubscriptionByProfileID(Convert.ToInt32(Session["ProfileID"].ToString()));

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

        protected void lnkDownload_OnClick(object sender, EventArgs e)
        {
            // Write Your Stuff here for QR Code Download as Image.
            try
            {
                string WelcomekitFOlderPath = Server.MapPath("~/Upload/WelcomeKitPDFs/WelcomeKit.pdf");
                if (File.Exists(WelcomekitFOlderPath))
                {
                    Response.ContentType = "image/jpg";
                    Response.AddHeader("Content-Disposition", "attachment;filename=\"WelcomeKit.pdf" + "\"");
                    Response.TransmitFile(WelcomekitFOlderPath);
                    Response.End();
                }
            }
            catch (Exception /*ex*/)
            {

            }
        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static VideoDetails[] BindVideosData(string VideoType)
        {
            CommonBLL objCommonBLL = new CommonBLL();
            DataTable dtActivityLogs = new DataTable();
            List<VideoDetails> details = new List<VideoDetails>();
            CommonBLL objVideos = new CommonBLL();
            DataTable dt = new DataTable();
            string domain = "";

            if (HttpContext.Current.Session["VerticalDomain"] != null)
                domain = HttpContext.Current.Session["VerticalDomain"].ToString();
            dt = objVideos.GetLiteVideosByType(VideoType, domain);

            foreach (DataRow dtrow in dt.Rows)
            {
                VideoDetails user = new VideoDetails();
                user.Url = dtrow["Url"].ToString();
                user.VideoID = dtrow["VideoID"].ToString();
                user.Thumb_Url = HttpContext.Current.Session["RootPath"].ToString() + "/Upload/HowToVideosThumbs/" + dtrow["Thumb_Url"].ToString();
                user.Title = dtrow["Title"].ToString();
                details.Add(user);
            }


            return details.ToArray();

        }
        public class VideoDetails
        {
            public string Url { get; set; }
            public string VideoID { get; set; }
            public string Thumb_Url { get; set; }
            public string Title { get; set; }
            public string TotalVideoCount { get; set; }

        }
    }
}