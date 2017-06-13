using System;
using System.Configuration;
using USPDHUBBLL;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web;
using System.Data;
using System.Collections.Generic;

namespace USPDHUB.OP.twoviecom
{
    public partial class AgencyListing : System.Web.UI.Page
    {
        public string Email1 = string.Empty;
        public int ProfileID = 0;
        public string Address = string.Empty;
        public int AffiliateInvID = 0;
        public int UserID = 0;
        public string PromoCode = string.Empty;
        public string RootPath = "";
        public string DomainName = "";
        public static string Country = string.Empty;
        public static string vertical = "twovie";
        CommonBLL objCommon = new CommonBLL();
        AgencyBLL objAgency = new AgencyBLL();
        BusinessBLL objBus = new BusinessBLL();
        AdminBLL objAdminBll = new AdminBLL();
        public int promoDuration = 0;
        private string salesCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["packId"] != null)
            {
                hdnPackgeID.Value = EncryptDecrypt.DESDecrypt(Request.QueryString["packId"].ToString());
            }
            if (Request.QueryString["AID"] != null && Request.QueryString["AID"].ToString() != "")
            {
                AffiliateInvID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["AID"].ToString().Replace("irhmalli", "=").Replace("irhPASS", "+")));
            }
            if (Request.QueryString["SC"] != null && Request.QueryString["SC"].ToString() != "")
            {
                salesCode = Request.QueryString["SC"].ToString();
            }
            // *** Get Domain Name *** //
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            lblErrorMSG.Text = "";
            lblUserNameCheck.Text = "";
            
            if (!IsPostBack)
            {
                BindCountry();
                if (Request.QueryString["SCT"] != null)
                {
                    string packageType = EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["SCT"]));
                    hdnPackageType.Value = packageType;
                }

                if (AffiliateInvID > 0)
                {
                    pnlParent.Visible = true;
                    string secureRootPath = RootPath;
                    DataTable dtConfigs = objCommon.GetVerticalConfigsByType(DomainName, "Paths");
                    if (dtConfigs.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtConfigs.Rows)
                        {
                            if (row[0].ToString() == "SRootPath")
                                secureRootPath = row[1].ToString();
                        }
                    }
                    DataTable dtAffiliate = objAgency.GetInvitationDetailsByID(AffiliateInvID);
                    if (dtAffiliate.Rows.Count > 0)
                    {
                        
                        if ((Convert.ToBoolean(dtAffiliate.Rows[0]["IsValid"].ToString())) && (Convert.ToBoolean(dtAffiliate.Rows[0]["IsActivated"].ToString()) == false))
                        {
                            hdnProfileID.Value = dtAffiliate.Rows[0]["Parent_ProfileID"].ToString();
                            hdnIsPaid.Value = dtAffiliate.Rows[0]["IsPaid"].ToString();
                            txtFirstName.Text = dtAffiliate.Rows[0]["First_Name"].ToString();
                            if (!string.IsNullOrEmpty(dtAffiliate.Rows[0]["Last_Name"].ToString()))
                                txtLastName.Text = dtAffiliate.Rows[0]["Last_Name"].ToString();
                            txtEmail.Text = dtAffiliate.Rows[0]["Email_Address"].ToString();
                            lblParent.Text = dtAffiliate.Rows[0]["Profile_name"].ToString();
                        }
                        else
                        {
                            string status = "1"; // *** 1 means affiliate invitation has been cancelled *** //
                            if (Convert.ToBoolean(dtAffiliate.Rows[0]["IsActivated"].ToString()))
                                status = "2";
                            Response.Redirect(secureRootPath + "/Business/AffiliateStatus.aspx?AID=" + Request.QueryString["AID"].ToString() + "&sts=" + status);
                        }
                    }
                    else
                        Response.Redirect(secureRootPath + "/OP/" + DomainName + "/AgencyListing.aspx");
                }
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
            Country = ddlCountry.SelectedItem.Text.ToString().Trim();
            //ddlCountry.Items.Insert(0, "Select Country");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    if (txtEmail.Text.Contains(".lv") == false)
                    {
                        if (captcha.CheckCaptcha(txtcaptcha.Text.Trim()))
                        {
                            int checkUser = objBus.CheckUserNameandPasswordForVaildUser(txtEmail.Text.Trim(), vertical, Country);
                            int checkAgency = objAgency.ValidateAgencyEmailID(txtEmail.Text.Trim(), vertical, Country);

                            ////* PromoCode = txtPromoCode.Text.Trim();
                            bool isPromo = true;
                            ////* int promoPercent = 0;

                            int inquiryId = 0;
                            int? parentProfileID = null;
                            if (checkUser == 0)
                            {
                                if (checkAgency == 0)
                                {
                                    if (AffiliateInvID > 0)
                                        parentProfileID = Convert.ToInt32(hdnProfileID.Value);
                                    ////*   if (PromoCode != string.Empty)
                                    ////* {
                                    ////*    DataTable dtPromocodeDetails = objAgency.CheckPromoCode(PromoCode, vertical, true);
                                    ////*   if (dtPromocodeDetails.Rows.Count > 0)
                                    ////* {
                                    ////* promoPercent = Convert.ToInt32(dtPromocodeDetails.Rows[0]["Promocode_Value"]);
                                    ////* if (!string.IsNullOrEmpty(dtPromocodeDetails.Rows[0]["Duration"].ToString()))
                                    ////* promoDuration = Convert.ToInt32(dtPromocodeDetails.Rows[0]["Duration"].ToString());
                                    ////* }
                                    ////* else
                                    ////* isPromo = false;
                                    ////*  }
                                    if (isPromo)
                                    {
                                        inquiryId = InsertAgencyDetails(parentProfileID);
                                        if (inquiryId > 0)
                                        {
                                            // Save User Activity Log
                                            objCommon.InsertUserActivityLog("Newly signed up as <b>" + txtAgencyname.Text.Trim() + "</b>", string.Empty, UserID, ProfileID, DateTime.Now, UserID);


                                            string secureRootPath = RootPath;
                                            DataTable dtConfigs = objCommon.GetVerticalConfigsByType(DomainName, "Paths");
                                            if (dtConfigs.Rows.Count > 0)
                                            {
                                                foreach (DataRow row in dtConfigs.Rows)
                                                {
                                                    if (row[0].ToString() == "SRootPath")
                                                        secureRootPath = row[1].ToString();
                                                }
                                            }
                                            if (parentProfileID == null)
                                            {
                                                //string urlRedirect = secureRootPath + "/OP/" + Session["VerticalDomain"] + "/Enhance.aspx?iq=" + EncryptDecrypt.DESEncrypt(inquiryId.ToString());
                                                //string urlRedirect = ConfigurationManager.AppSettings.Get("ShoppingCartRootPath") + "/Checkout/EnhanceSubcription.aspx?InqID=" + EncryptDecrypt.DESEncrypt(inquiryId.ToString()) + "&Type=" + EncryptDecrypt.DESEncrypt("10000") + "&VC=" + EncryptDecrypt.DESEncrypt(Session["VerticalDomain"].ToString()) + "&Username=" + EncryptDecrypt.DESEncrypt(txtEmail.Text.Trim()) + "&Lite=" + EncryptDecrypt.DESEncrypt(hdnIsLite.Value);
                                                //Response.Redirect(urlRedirect);

                                                string urlRedirect = ConfigurationManager.AppSettings.Get("ShoppingCartRootPath") + "/RedirectStore.aspx?InqID=" + EncryptDecrypt.DESEncrypt(inquiryId.ToString())
                                                + "&VC=" + EncryptDecrypt.DESEncrypt(Session["VerticalDomain"].ToString())
                                                + "&Username=" + EncryptDecrypt.DESEncrypt(txtEmail.Text.Trim())
                                                + "&IsSignUp=" + EncryptDecrypt.DESEncrypt("true") + "&PackID=" + EncryptDecrypt.DESEncrypt(hdnPackgeID.Value);
                                                Response.Redirect(urlRedirect);

                                            }
                                            else
                                                InsertUserDetails(inquiryId, parentProfileID, salesCode); 
                                        }
                                        else
                                            lblErrorMSG.Text = "<font color=red>A problem has been occurred while submitting the data. <br/>Please email us at support@twovie.com or Call us at 1-800-281-0263 Monday - Friday 8 a.m. - 5 p.m. PST</font>";
                                    }
                                    else
                                        lblErrorMSG.Text = "Please enter valid promo code.";

                                }
                                else
                                    lblUserNameCheck.Text = "<font color=red>Email address is already associated with another user.</font>";
                            }
                            else
                                lblUserNameCheck.Text = "<font color='red'>This email address is already in use, please enter different email address.</font>";
                        }
                        else
                            lblErrorMSG.Text = "<font color='red'>Please enter valid security code.</font>";
                    }
                    Random ran = new Random();
                    img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
                }
            }
            catch (Exception /*ex*/)
            {
                Random ran = new Random();
                img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
            }
        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(RootPath + "/OP/" + DomainName + "/Default.aspx");
        }
        private int InsertAgencyDetails(int? parentProfileID)
        {
            string date = string.Empty;
            string remarks = string.Empty;
            string title = string.Empty;
            int InquiryID = objAgency.AddAgencyUser(salesCode, txtAgencyname.Text, txtEmail.Text.Trim(), txtFirstName.Text.Trim(), txtphonenumber.Text, date,
                remarks, 0, title, ddlHow.SelectedValue, vertical, PromoCode, parentProfileID, AffiliateInvID == 0 ? (int?)null : AffiliateInvID, txtLastName.Text.Trim(), Country, txtAddress.Text.Trim(),
                                        txtCity.Text.Trim(), txtState.Text.Trim() , txtzipcode.Text.Trim(), string.Empty, Convert.ToBoolean(hdnIsLite.Value));

            if (InquiryID > 0)
                Session["EmailID"] = txtEmail.Text.Trim();
            return InquiryID;
        }

        private void InsertUserDetails(int inquiryId, int? parentProfileID, string salesCode)
        {
            int profileID = 0;
            int userID = 0;
            string username = "";
            int subPeriod = 12;
            decimal totalAmt = 0.00M;
            decimal billableAmt = 0.00M;
            decimal discount = 0.00M;
            decimal renewal = 0.00M;
            string Address = txtAddress.Text.Trim();
            string CityName = txtCity.Text.Trim();
            string zipCode = txtzipcode.Text.Trim();
            string stateName = txtState.Text.Trim();
            string countryName = ddlCountry.SelectedItem.Text.Trim().ToString();
            string password = objCommon.GenerateRandomPassword();

            #region Getting Latidude & longtidude values
            string fullAddress = Address + "," + CityName + "," + stateName + "," + countryName + "," + zipCode;
            Coordinate coordinates = Geocode.GetCoordinates(fullAddress);
            double latitude1 = Convert.ToDouble(coordinates.Latitude);
            double longitude1 = Convert.ToDouble(coordinates.Longitude);
            #endregion
            profileID = objAgency.InsertNewSubcriptionUserDetails(latitude1, longitude1, EncryptDecrypt.DESEncrypt(password), inquiryId, Convert.ToInt32(ProfileSubscriptionTypes.Premium));
            DataTable dtuserdetails = objBus.GetuserdetailsByProfileID(profileID);

            #region  // Parent Logo Copy to Sub APP Account

            if (parentProfileID != null)
            {
                if (parentProfileID != 0)
                {
                    objCommon.ParentLogoCopyToSubApp(Convert.ToInt32(parentProfileID), profileID, Convert.ToInt32(dtuserdetails.Rows[0]["User_ID"]));
                }
            }
            #endregion


            Session["ProfileID"] = profileID;
            username = txtEmail.Text.Trim();
            if (dtuserdetails.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dtuserdetails.Rows[0]["Username"].ToString()))
                    username = dtuserdetails.Rows[0]["Username"].ToString();
                userID = Convert.ToInt32(dtuserdetails.Rows[0]["User_ID"]);
            }
            #region Insert Tranaction Details (SubcriptionTypes Table)
            int subscriptionID = objBus.InsertUserSubscriptions(profileID, userID, subPeriod, totalAmt, discount, billableAmt, "", "", "", "", "", "", "", "", "", 0, 0, "", "", "", false);

            //Affilates Records
            DataTable dtInviationCodes = objAgency.GetInvitatioCodeDetailsByID(AffiliateInvID);
            totalAmt = discount = Convert.ToDecimal(dtInviationCodes.Rows[0]["Payment_Cost"]);
            billableAmt = (totalAmt - discount);

            int SID = 0;
            DataTable dtSubcriptions = objBus.GetStoreItems("New", DomainName.ToString());
            for (int i = 0; i < dtSubcriptions.Rows.Count; i++)
            {
                // Non-Branded Amount Year
                if (Convert.ToString(dtSubcriptions.Rows[i]["Type"]).Trim() == string.Empty &&
                    Convert.ToString(dtSubcriptions.Rows[i]["Subscription_period"]) == "12")
                {
                    SID = Convert.ToInt32(dtSubcriptions.Rows[i]["Subscription_ID"]);
                    break;
                }
            }

            // Insert Transction Details
            int subcriptionTypeID = objBus.InsertTransaction(profileID, userID, subscriptionID, 10000,
                                   Convert.ToDecimal(discount), Convert.ToDecimal(billableAmt),
                                   Convert.ToDecimal(totalAmt), userID, subPeriod, DateTime.Now.AddMonths(subPeriod), "",
                                   "", "", "", "",
                                   "", "", "", "", "", "", "", Convert.ToInt32(RequestCustomFormTypes.NewRegistration), subPeriod, 0, 0, "", "", "", salesCode);

            //objBillingInfo.OrderID = orderID.ToString();
            //get affilcate renwal cost
            DataTable dtAffilateDetails = objBus.GetAffilatesInvitationDetailsbyPID(Convert.ToInt32(parentProfileID));
            renewal = Convert.ToDecimal(dtAffilateDetails.Rows[0]["Payment_Cost"]);

            //Insert Order Details
            DateTime createDate = DateTime.Now;
            DateTime renewalDate = createDate.AddMonths(subPeriod);
            int? promoCodeId = null;
            objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, SID, totalAmt, discount,
                      billableAmt, createDate, userID, createDate, renewalDate, Convert.ToInt32(RequestCustomFormTypes.NewRegistration), null, null,
                      subPeriod, "", Convert.ToDecimal(renewal), false, promoCodeId, salesCode);
            SendActivationEmail(username, password, "", DomainName);
            objCommon.SendRepresentationEmail(profileID, DomainName);
            Response.Redirect(RootPath + "/OP/" + DomainName + "/OrderCompleted.aspx?PID=" + EncryptDecrypt.DESEncrypt(profileID.ToString()));
            #endregion
        }
        private void InsertTransctionDetails(int inquiryId, int? parentProfileID)
        {
            try
            {
                decimal totalAmt = 0.00M;
                decimal billableAmt = 0.00M;
                decimal discount = 0.00M;
                int subPeriod = 12;
                if (promoDuration > 0)
                    subPeriod = promoDuration;
                discount = totalAmt;
                int orderID = objAdminBll.AddInquiryTransactions(inquiryId, subPeriod, totalAmt, discount, billableAmt, "", "", "", "", "", "", "", "", 0, 0, "", "", "United States", 0, false, "", true, PromoCode, "", false, null);
                string password = objCommon.GenerateRandomPassword();

                string Address = txtAddress.Text.Trim();
                string CityName = txtCity.Text.Trim();
                string zipCode = txtzipcode.Text.Trim();
                string stateName = txtState.Text.Trim();
                string countryName = ddlCountry.SelectedItem.Text.Trim().ToString();

                #region Getting Latidude & longtidude values
                string fullAddress = Address + "," + CityName + "," + stateName + "," + countryName + "," + zipCode;
                Coordinate coordinates = Geocode.GetCoordinates(fullAddress);

                double latitude1 = Convert.ToDouble(coordinates.Latitude);
                double longitude1 = Convert.ToDouble(coordinates.Longitude);

                #endregion

                int profileId = objAgency.InsertUserDetails(latitude1, longitude1, EncryptDecrypt.DESEncrypt(password), inquiryId);
                DataTable dtuserdetails = objBus.GetuserdetailsByProfileID(profileId);
                string username = txtEmail.Text.Trim();
                if (dtuserdetails.Rows.Count > 0)
                {
                    username = dtuserdetails.Rows[0]["Username"].ToString();
                    Session["UName"] = username;
                }

                SendActivationEmail(username, password, "", DomainName);
                objCommon.GenerateInvoice(profileId, vertical, DomainName);
                Response.Redirect(RootPath + "/OP/" + Session["VerticalDomain"] + "/OrderCompleted.aspx?PID=" + EncryptDecrypt.DESEncrypt(profileId.ToString()));
            }
            catch (Exception /*ex*/)
            {

            }

        }
        private void SendActivationEmail(string username, string password, string location, string verticalValue)
        {
            string vertRootPath = "";
            DataTable dtConfigs = objCommon.GetVerticalConfigsByType(verticalValue, "Paths");
            if (dtConfigs.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigs.Rows)
                {
                    if (row[0].ToString() == "RootPath")
                        vertRootPath = row[1].ToString();
                }
            }
            string FromInfo = "";
            DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(verticalValue, "EmailAccounts");
            if (dtConfigsemails.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigsemails.Rows)
                {
                    if (row[0].ToString() == "EmailInfo")
                        FromInfo = row[1].ToString();
                }
            }
            string strfilepath = Server.MapPath("~") + "\\EmailContent" + verticalValue + "\\";
            StreamReader re = File.OpenText(strfilepath + "AgencyActivationCode.txt");
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
            msgbody = msgbody.Replace("#RootUrl#", vertRootPath);
            msgbody = msgbody.Replace("#msgBody#", content);
            msgbody = msgbody.Replace("#Link#", "<a href='" + vertRootPath + "/OP/" + verticalValue + "/Login.aspx' target='_blank'>Login</a>");
            msgbody = msgbody.Replace("#Email#", username);
            msgbody = msgbody.Replace("#Password#", password);
            re.Close();
            re.Dispose();
            reDeclaimer.Close();
            reDeclaimer.Dispose();
            string ccemail = string.Empty;
            UtilitiesBLL utlobj = new UtilitiesBLL();
            if (string.IsNullOrEmpty(location))
                utlobj.SendWowzzyEmail(FromInfo, username, "Account Details", msgbody, ccemail, "", verticalValue);
            else
                utlobj.SendWowzzyEmailWithAttachments(FromInfo, username, "Account Details", msgbody, ccemail, location, verticalValue);

        }
        [WebMethod]
        public static string ServerSidefill(string emid)
        {
            BusinessBLL objWow = new BusinessBLL();
            AgencyBLL objAgency = new AgencyBLL();

            string typevalue = "";
            if (emid.Length > 0)
            {
                Regex rEMail = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (!rEMail.IsMatch(emid))
                {
                    typevalue = "3";
                }
                else
                {
                    try
                    {
                        int countUser;
                        countUser = objWow.CheckUserNameandPasswordForVaildUser(emid, vertical, Country);
                        int count = objAgency.ValidateAgencyEmailID(emid, vertical, Country);
                        /*
                        string s = "SELECT COUNT(SuperAdmin_ID) FROM T_Users WHERE Username='" + emid + "'";
                        SqlConnection sqlCon = USPDHUBDAL.ConnectionManager.Instance.GetSQLConnection();
                        SqlCommand sqlCmd = new SqlCommand(s, sqlCon);
                        int count = Convert.ToInt32(sqlCmd.ExecuteScalar().ToString());
                        USPDHUBDAL.ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
                         */
                        if (count > 0)
                            typevalue = "4";
                        else
                        {
                            if (countUser == 0)
                            {
                                typevalue = "1";
                            }
                            else
                            {
                                typevalue = "2";
                            }
                        }
                    }
                    catch
                    {
                        typevalue = "3";
                    }

                }
            }
            return typevalue;

        }
        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod]
        public static List<string> GetProfiles(string prefixText)
        {
            BusinessBLL objBus = new BusinessBLL();
            DataTable dt = objBus.GetParentProfiles(prefixText);
            List<string> Profiles = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Profiles.Add(dt.Rows[i]["Profile_name"].ToString());
            }
            return Profiles;

        }
    }
}