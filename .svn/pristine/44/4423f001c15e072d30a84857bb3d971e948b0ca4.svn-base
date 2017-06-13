using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Services;
using USPDHUBBLL;
using System.Data;
using USPDHUBDAL;
using System.IO;
using System.Configuration;

namespace USPDHUB.Admin
{
    public partial class CreateFreeAccount : System.Web.UI.Page
    {
        AgencyBLL objAgency = new AgencyBLL();
        DataTable dtverticals = new DataTable();
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        public BusinessDAL.BillingInfo objBillingInfo;
        DataTable dtVerifyDetails = new DataTable();
        string salesCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindVerticalsDropdown();
                    objBillingInfo = new BusinessDAL.BillingInfo();
                    if (Request.QueryString["ID"] != null)
                    {
                        btnGotoAppStore.Visible = true;
                        hdnInquiryId.Value = EncryptDecrypt.DESDecrypt(Request.QueryString["ID"].ToString());
                        dtVerifyDetails = objAgency.GetVerifyDetailsById(Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["ID"].ToString())));
                        if (dtVerifyDetails.Rows.Count == 1)
                        {
                            salesCode = dtVerifyDetails.Rows[0]["SalesCode"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Agency_Name"].ToString()))
                                txtAgencyName.Text = dtVerifyDetails.Rows[0]["Agency_Name"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Contact_Person"].ToString()))
                                txtContactPerson.Text = dtVerifyDetails.Rows[0]["Contact_Person"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["LastName"].ToString()))
                                txtLastName.Text = dtVerifyDetails.Rows[0]["LastName"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Phone_Number"].ToString()))
                                objBillingInfo.Number = txtphonenumber.Text = dtVerifyDetails.Rows[0]["Phone_Number"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Email_Address"].ToString()))
                                objBillingInfo.BillingEmail = txtEmail.Text = dtVerifyDetails.Rows[0]["Email_Address"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["City"].ToString()))
                                objBillingInfo.City = txtCity.Text = dtVerifyDetails.Rows[0]["City"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Zipcode"].ToString()))
                                objBillingInfo.Zipcode = txtZipCode.Text = dtVerifyDetails.Rows[0]["Zipcode"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["State"].ToString()))
                                objBillingInfo.State = drpState.Text = dtVerifyDetails.Rows[0]["State"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Address"].ToString()))
                                objBillingInfo.Address1 = txtAgencyAddress.Text = dtVerifyDetails.Rows[0]["Address"].ToString();

                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Vertical_Name"].ToString()))
                            {
                                ddlVertical.SelectedValue = dtVerifyDetails.Rows[0]["Vertical_Name"].ToString();
                            }
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Country"].ToString()))
                            {
                                ddlCountry.SelectedValue = dtVerifyDetails.Rows[0]["Country"].ToString();
                            }
                        }
                    }
                    else
                        btnGotoAppStore.Visible = false;
                    hdnUserDomain.Value = objCommon.GetDomainNameByCountryVertical(ddlVertical.SelectedValue, ddlCountry.SelectedValue);
                    BindSubscriptionType();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CreateFreeAccount.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BindVerticalsDropdown()
        {
            try
            {
                dtverticals = objAgency.GetActiveVerticals();
                ddlVertical.DataSource = dtverticals;
                ddlVertical.DataTextField = "Vertical_Name";
                ddlVertical.DataValueField = "Vertical_Value";
                ddlVertical.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CreateFreeAccount.aspx.cs", "BindVerticalsDropdown", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void ddlVertical_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hdnUserDomain.Value = objCommon.GetDomainNameByCountryVertical(ddlVertical.SelectedValue, ddlCountry.SelectedValue);
                BindSubscriptionType();
                txtEmail.Text = "";
                lblUserNameCheck.Text = "";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CreateFreeAccount.aspx.cs", "ddlVertical_SelectedIndexChanged", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hdnUserDomain.Value = objCommon.GetDomainNameByCountryVertical(ddlVertical.SelectedValue, ddlCountry.SelectedValue);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CreateFreeAccount.aspx.cs", "ddlCountry_SelectedIndexChanged", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BindSubscriptionType()
        {
            try
            {
                DataTable dtPackages = objBus.GetPackageTypes(hdnUserDomain.Value);

                ddlSubscriptions.DataSource = dtPackages;
                ddlSubscriptions.DataTextField = "PackageName";
                ddlSubscriptions.DataValueField = "PackageID";
                ddlSubscriptions.DataBind();
                ddlSubscriptions.SelectedIndex = 0;
                CaliculateAmount();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CreateFreeAccount.aspx.cs", "BindSubscriptionType", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private int InsertAgencyDetails(int? parentProfileID)
        {
            int inquiryID = 0;
            try
            {
                string date = string.Empty;
                string remarks = string.Empty;
                string title = string.Empty;

                inquiryID = objAgency.AddAgencyUser(salesCode, txtAgencyName.Text, txtEmail.Text.Trim(), txtContactPerson.Text.Trim(), txtphonenumber.Text, "",
                    remarks, 0, title, "", ddlVertical.SelectedValue, "", parentProfileID, parentProfileID, txtLastName.Text.Trim(), ddlCountry.SelectedValue, txtAgencyAddress.Text.Trim(),
                    txtCity.Text.Trim(), drpState.Text.Trim(), txtZipCode.Text.Trim(),"",false,txtAgencyAddress2.Text.Trim());

            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CreateFreeAccount.aspx.cs", "InsertAgencyDetails", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return inquiryID;
        }
        protected void btnGotoStore(object sender, EventArgs e)
        {
            try
            {
                UpdateAgencyDetails();
                string adminDomainName = objCommon.CreateAdminDomain(HttpContext.Current.Request.Url.AbsoluteUri);
                string userDomainName = hdnUserDomain.Value;
                string urlRedirect = ConfigurationManager.AppSettings.Get("ShoppingCartRootPath") + "/Checkout/EnhanceSubcription.aspx?InqID=" + EncryptDecrypt.DESEncrypt(hdnInquiryId.Value) + "&Type=" + EncryptDecrypt.DESEncrypt("10000") + "&VC=" + EncryptDecrypt.DESEncrypt(userDomainName) + "&Username=" + EncryptDecrypt.DESEncrypt(txtEmail.Text.Trim()) + "&AVC=" + EncryptDecrypt.DESEncrypt(adminDomainName);
                Response.Redirect(urlRedirect);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CreateFreeAccount.aspx.cs", "btnGotoStore", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void UpdateAgencyDetails()
        {
            try
            {

                objAgency.UpdateAgencyDtlsById(Convert.ToInt32(hdnInquiryId.Value), txtAgencyName.Text, txtEmail.Text, txtContactPerson.Text, txtLastName.Text.Trim(), txtphonenumber.Text, drpState.Text, txtCity.Text, txtZipCode.Text, txtAgencyAddress.Text, "", null, "Verified", ddlVertical.SelectedValue, "", "", ddlCountry.SelectedValue, null, txtAgencyAddress2.Text.Trim());

            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CreateFreeAccount.aspx.cs", "UpdateAgencyDetails", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnActivateAccount(object sender, EventArgs e)
        {
            try
            {
                objBillingInfo = new BusinessDAL.BillingInfo();
                int subPeriod = 1;
                int subOrderID = 0;
                bool isSendEmail = false;
                int inquiryID = 0;
                if (hdnInquiryId.Value == "")
                    inquiryID = InsertAgencyDetails(null);
                else
                {
                    UpdateAgencyDetails();
                    inquiryID = Convert.ToInt32(hdnInquiryId.Value);
                }
                decimal totalAmt = 0.00M;
                decimal billableAmt = 0.00M;

                if (chkTurnOnOffEmails.Checked)
                    isSendEmail = true;
                else
                    isSendEmail = false;


                //  DataTable pkgDetails = objBus.GetSubscriptionByID(Convert.ToInt32(ddlSubscriptions.SelectedValue));
                if (subscrptnPeriodmnthly.Checked)
                {
                   objBillingInfo.SubPeriod= 1;
                   totalAmt = Convert.ToDecimal(lblMnthly.Text.Trim());
                }
                else
                {
                    objBillingInfo.SubPeriod = 12;
                    totalAmt = Convert.ToDecimal(lblyearly.Text.Trim());

                }
             
                // *** Checking if selected package has included branded app *** //
                bool isBranded = true;

                int profileID = 0;
                int userID = 0;
                string username = "";
                decimal discount = totalAmt;
                objBillingInfo.PackageID=Convert.ToInt32(ddlSubscriptions.SelectedValue);
                string Address = objBillingInfo.Address1 = txtAgencyAddress.Text.Trim();
                string Address2 = objBillingInfo.Address2 = txtAgencyAddress2.Text.Trim();
                string CityName = objBillingInfo.City = txtCity.Text.Trim();
                string zipCode = objBillingInfo.Zipcode = txtZipCode.Text.Trim();
                objBillingInfo.FirtstName = txtContactPerson.Text.Trim();
                string stateName = objBillingInfo.State = drpState.Text.Trim();
                objBillingInfo.Country = ddlCountry.SelectedValue;

                string password = objCommon.GenerateRandomPassword();
                string discountcode = "";

                #region Getting Latidude & longtidude values
                string fullAddress = Address + "," + CityName + "," + stateName + "," + zipCode;
                Coordinate coordinates = Geocode.GetCoordinates(fullAddress);
                double latitude1 = Convert.ToDouble(coordinates.Latitude);
                double longitude1 = Convert.ToDouble(coordinates.Longitude);
                #endregion
                profileID = objAgency.InsertNewSubcriptionUserDetails(latitude1, longitude1, EncryptDecrypt.DESEncrypt(password), inquiryID, Convert.ToInt32(ProfileSubscriptionTypes.Premium));

                DataTable dtuserdetails = objBus.GetuserdetailsByProfileID(profileID);

                username = txtEmail.Text.Trim();
                Boolean isLiteVersion = false;
                if (dtuserdetails.Rows.Count > 0)
                {
                    if (string.IsNullOrEmpty(dtuserdetails.Rows[0]["Username"].ToString()))
                        username = dtuserdetails.Rows[0]["Username"].ToString();
                    userID = Convert.ToInt32(dtuserdetails.Rows[0]["User_ID"]);
                    isLiteVersion = Convert.ToBoolean(dtuserdetails.Rows[0]["IsLiteVersion"]);
                }
                if (isSendEmail == false)
                    objAgency.UpdateAutoOnOff(userID, isSendEmail);
                #region Insert Tranaction Details (SubcriptionTypes Table)

                //int subscriptionID = objBus.InsertUserSubscriptions(profileID, userID, subPeriod, totalAmt, discount, billableAmt, "", "", "", "", "", "", "", "", "", 0, 0, "", "", "", false);


                //// Insert Transction Details
                int subcriptionTypeID = objBus.InsertTransaction(profileID, userID, 0, 10000,
                                       Convert.ToDecimal(discount), Convert.ToDecimal(billableAmt),
                                       Convert.ToDecimal(totalAmt), userID, objBillingInfo.SubPeriod, DateTime.Now.AddMonths(objBillingInfo.SubPeriod), "",
                                       "", "", "", "00/00",
                                       "", "", "", "", "", "", "", Convert.ToInt32(RequestCustomFormTypes.NewRegistration), objBillingInfo.SubPeriod, 0, 0, "", "", "", salesCode);
                
                #region Insert Order Details (T_OrderDetails table)
                
                DataTable dt = objBus.GetStoreItems_New("all",hdnUserDomain.Value, Convert.ToInt32(ddlSubscriptions.SelectedItem.Value), 0);
                DateTime createDate = DateTime.Now;
                objBillingInfo.StartDate = createDate;
                DateTime renewalDate = createDate.AddMonths(objBillingInfo.SubPeriod);
                objBillingInfo.RenewalDate = renewalDate;
                List<BusinessDAL.OrderDetails> objOrderDetails = new List<BusinessDAL.OrderDetails>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (dt.Rows[i]["listname"].ToString().Equals("cartlist"))
                    {
                        BusinessDAL.OrderDetails orderdetails = new BusinessDAL.OrderDetails();
                        orderdetails.SubscriptionID = Convert.ToInt32(dt.Rows[i]["Subscription_ID"].ToString());
                        orderdetails.RequestType = Convert.ToInt32(dt.Rows[i]["Request_Type"].ToString());
                        orderdetails.AccessType = Convert.ToString(dt.Rows[i]["AccessType"].ToString());
                        // orderdetails.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"].ToString());
                        totalAmt = subscrptnPeriodmnthly.Checked ? Convert.ToInt32(dt.Rows[i]["subscription_Cost"]) : Convert.ToInt32(dt.Rows[i]["Annual_Price"]);
                        orderdetails.RequestType = Convert.ToInt32(dt.Rows[i]["Request_Type"].ToString());
                        orderdetails.SubscriptionID = Convert.ToInt32(dt.Rows[i]["Subscription_ID"].ToString());
                        orderdetails.Total = totalAmt;
                        orderdetails.Discount = 0.00M;
                        orderdetails.Billable = totalAmt;
                        // orderdetails.Renewal = objBillingInfo.IsLifeTimeRenewal ? (Convert.ToDecimal(item.Price) - ((discount) / 100) * Convert.ToDecimal(item.Price)) : Convert.ToDecimal(item.Price);
                        orderdetails.DiscountCode = "FreeTrail";
                        orderdetails.SubscriptionPeriod = objBillingInfo.SubPeriod;
                        orderdetails.IsPackageItem = Convert.ToBoolean(dt.Rows[i]["IsPackageItem"]);
                        objOrderDetails.Add(orderdetails);
                    }

                }
                int? ParentOrderDetalsID = null;
                int orderDetailsID = 0;
                if (objOrderDetails.Count() > 0)
                {
                    if (objBillingInfo.PackageID == 0)
                    {
                        subOrderID = objBus.InsertUserSubscriptions(profileID, userID, objBillingInfo.SubPeriod, 0.00M, 0.00M, 0.00M, objBillingInfo.Address1,objBillingInfo.Address2, objBillingInfo.City,
                            objBillingInfo.State, objBillingInfo.Zipcode, objBillingInfo.Country, "", objBillingInfo.Name, "", objBillingInfo.Month == "" ? 0 : Convert.ToInt32(objBillingInfo.Month), objBillingInfo.Year == "" ? 0 : Convert.ToInt32(objBillingInfo.Year), objBillingInfo.Type, "", "", false);

                        //ParentOrderDetalsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, 0.00M, 0.00M, 0.00M,
                        //    createDate, userID, createDate, renewalDate, Convert.ToInt32(RequestCustomFormTypes.NewRegistration), null, null,
                        //    objBillingInfo.SubPeriod, objBillingInfo.PromoCode, 0.00M,false, null, salesCode, 1, objBillingInfo.PackageID,null);
                        ParentOrderDetalsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, 0, 0.00M, 0.00M, 0.00m, createDate,
                            userID, createDate, renewalDate, Convert.ToInt32(RequestCustomFormTypes.NewRegistration), null, null, objBillingInfo.SubPeriod, "", 0.00M, false, null, salesCode);
                    }
                    foreach (BusinessDAL.OrderDetails orderdetails in objOrderDetails)
                    {
                        orderDetailsID = 0;
                        if (orderdetails.Discount == 0)
                            orderdetails.Discount = 0.00M;
                        if (objBillingInfo.PackageID != 0 && orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.NewRegistration))
                        {
                            subOrderID = objBus.InsertUserSubscriptions(profileID, userID, objBillingInfo.SubPeriod, orderdetails.Total, orderdetails.Discount, orderdetails.Billable, objBillingInfo.Address1, objBillingInfo.Address2, objBillingInfo.City,
                                       objBillingInfo.State, objBillingInfo.Zipcode, objBillingInfo.Country, "", objBillingInfo.Name, "", Convert.ToInt32(objBillingInfo.Month), Convert.ToInt32(objBillingInfo.Year), "", "", objBillingInfo.PromoCode, objBillingInfo.IsRecurring);

                            ParentOrderDetalsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount,
                              orderdetails.Billable, createDate, userID, createDate, renewalDate, orderdetails.RequestType, null, null,
                              objBillingInfo.SubPeriod, objBillingInfo.PromoCode, Convert.ToDecimal(orderdetails.Renewal),
                              orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, salesCode, orderdetails.Quantity, objBillingInfo.PackageID, null);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.BrandedApp))
                        {
                            objBus.UpdateUserBrandedApp(profileID);

                            // Insert Branded App Order Status
                            objBus.Insert_Update_AppProcessStatus(0, userID, profileID, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.New), 0);

                            objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount,
                                orderdetails.Billable, createDate, userID, createDate, renewalDate, orderdetails.RequestType, null, null,
                                objBillingInfo.SubPeriod, objBillingInfo.PromoCode, Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme,
                                orderdetails.PromoCodeId, salesCode, orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);


                            // *** sending email to US team to notify for branded app *** //
                            //string DomainName = Session["VerticalDomain"].ToString();
                            string rootPath = ConfigurationManager.AppSettings["RootPath"];
                            DataTable dtProfileDetails = objBus.GetProfileDetailsByProfileID(profileID);
                            string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\EmailContent" + hdnUserDomain.Value + "\\";
                            #region Mail Body
                            StreamReader re = File.OpenText(strfilepath + "RequestBrandedApp.txt");
                            string emailmessage = string.Empty;
                            string content = string.Empty;
                            while ((content = re.ReadLine()) != null)
                            {
                                emailmessage = emailmessage + content + "<BR>";
                            }
                            emailmessage = emailmessage.Replace("#MemberID#", userID.ToString());
                            emailmessage = emailmessage.Replace("#ProfileName#", (string)dtProfileDetails.Rows[0]["Profile_name"]);
                            re.Close();
                            #endregion

                            #region Mail Header

                            StreamReader re1 = File.OpenText(strfilepath + "CommonNotes.txt");
                            string emailmessage1 = string.Empty;
                            string content1 = string.Empty;
                            while ((content1 = re1.ReadLine()) != null)
                            {
                                emailmessage1 = emailmessage1 + content1;
                            }
                            emailmessage1 = emailmessage1.Replace("#RootUrl#", rootPath);
                            emailmessage1 = emailmessage1.Replace("#msgBody#", emailmessage);
                            re1 = File.OpenText(strfilepath + "BrandedAppReqEmails.txt");
                            string toEmails = string.Empty;
                            while ((content1 = re1.ReadLine()) != null)
                            {
                                toEmails = toEmails + content1;
                            }
                            re1.Close();
                            #endregion
                            DataTable dtConfigs = objCommon.GetVerticalConfigsByType(hdnUserDomain.Value, "EmailAccounts");
                            string FromEmailsupport = "";
                            for (int i = 0; i < dtConfigs.Rows.Count; i++)
                            {
                                if (Convert.ToString(dtConfigs.Rows[i]["Name"]) == "EmailInfo")
                                {
                                    FromEmailsupport = Convert.ToString(dtConfigs.Rows[i]["Value"]);
                                    break;
                                }
                            }

                            objCommon.SendWowzzyEmail(FromEmailsupport, toEmails, "Requested for Branded App", emailmessage1,
                                string.Empty, "", hdnUserDomain.Value, profileID.ToString(), "");
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.BrandedFee))
                        {
                            objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount,
                                orderdetails.Billable, createDate, userID, createDate, renewalDate, orderdetails.RequestType, null, null,
                                objBillingInfo.SubPeriod, objBillingInfo.PromoCode, Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme,
                                orderdetails.PromoCodeId, salesCode, orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.ImageGalleryAddOns))
                        {
                            objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount,
                                orderdetails.Billable, DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                                orderdetails.Sub_SubscriptionID, 5000, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                                Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                                orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                            objBus.UpdateMemorySpace(profileID, userID, Convert.ToInt32(3000));
                            objBus.InsertPackageItem(hdnUserDomain.Value, "Gallery", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.Bulletins))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                            objBus.InsertPackageItem(hdnUserDomain.Value, "Bulletins", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.EventCalendar))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            objBus.InsertPackageItem(hdnUserDomain.Value, "EventCalendar", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.Home))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                            objBus.InsertPackageItem(hdnUserDomain.Value, "Home", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.AboutUs))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                            objBus.InsertPackageItem(hdnUserDomain.Value, "AboutUs", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.AddOns))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                                DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                                orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                                Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                                orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            if (orderdetails.IsPackageItem)
                                objBus.InsertPackageItem(hdnUserDomain.Value, "AddOn", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                            else
                                objBus.InsertPurchaseAddons(profileID, userID, userID, WebConstants.Purchase_ContentAddOns);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.PrivateAddOns))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                                  DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                                  orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                                  Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                                  orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            if (orderdetails.IsPackageItem)
                                objBus.InsertPackageItem(hdnUserDomain.Value, "PrivateAddOns", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                            else
                                objBus.InsertPurchaseAddons(profileID, userID, userID, USPDHUBBLL.WebConstants.Purchase_PrivateContentAddOns);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.PrivateCallAddOns))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                                DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                                orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                                Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                                orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            if (orderdetails.IsPackageItem)
                                objBus.InsertPackageItem(hdnUserDomain.Value, "PrivateCallAddOns", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                            else
                                objBus.InsertPurchaseAddons(profileID, userID, userID, USPDHUBBLL.WebConstants.Purchase_PrivateCallAddOns);


                            objBus.InsertSMSAddons(profileID, userID, orderDetailsID, ConfigurationManager.AppSettings["defaultSMSType"].ToString(), Convert.ToInt32(ConfigurationManager.AppSettings["defaultSMSQuantity"]));
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.PublicCallAddOns))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            if (orderdetails.IsPackageItem)
                            {
                                int UMID = objBus.InsertPackageItem(hdnUserDomain.Value, "PublicCallAddOns", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);

                                /*** Insert Smart Connect Default Items (Public Call Items)   ***/
                               // objCommon.InsertDefaultCallItems(UMID, profileID, userID, hdnUserDomain.Value);
                            }
                            else
                                objBus.InsertPurchaseAddons(profileID, userID, userID, USPDHUBBLL.WebConstants.Purchase_PublicCallAddOns);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.CalendarAddOns))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                                DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                                orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                                Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                                orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                            objBus.InsertPackageItem(hdnUserDomain.Value, "EventCalendar", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.BannerAds))
                        {
                            objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                                DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                                orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                                Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                                orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                            objBus.InsertPurchaseAddons(profileID, userID, userID, USPDHUBBLL.WebConstants.Purchase_BannerAds);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.SMSAddOns))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                                DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                                orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                                Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                                orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            BusinessDAL.SMSDetails objSMSBilling = new BusinessDAL.SMSDetails();
                            objSMSBilling = (BusinessDAL.SMSDetails)Session["SMSBilling"];

                            if (objSMSBilling != null)
                                objBus.InsertSMSAddons(profileID, userID, orderDetailsID, objSMSBilling.SMSType, objSMSBilling.SMSQuantity);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.SMSSetup))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            objBus.InsertSMSAddons(profileID, userID, orderDetailsID, ConfigurationManager.AppSettings["defaultSMSType"].ToString(), Convert.ToInt32(ConfigurationManager.AppSettings["defaultSMSQuantity"]));
                            objBus.EnableSMSSetup(profileID);

                            /*** Insert User Module Tab here ***/
                            string appIcon = "";
                            string tabName = "SMSSetup";
                            int UserModuleID = 0;
                            int module = 0;
                            /*UserModuleID = objCommon.InsertUserCustomModules(profileID, userID, userID, module, appIcon,
                                tabName, true, DateTime.Now, DateTime.Now, objBillingInfo.RenewalDate, "", false,
                                USPDHUBBLL.WebConstants.Purchase_SMSSetup, USPDHUBBLL.WebConstants.Purchase_SMSSetup, orderdetails.AccessType, orderDetailsID);*/

                        } /*** New Modules from here onwards***/
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.ScheduleEmailsSetup))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            /*** Insert User Module Tab here ***/
                            string appIcon = "";
                            string tabName = "Scheduled Modules";
                            int UserModuleID = 0;
                            int module = 0;
                            UserModuleID = objCommon.InsertUserCustomModules(profileID, userID, userID, module, appIcon,
                                tabName, true, DateTime.Now, DateTime.Now, objBillingInfo.RenewalDate, "", false,
                               USPDHUBBLL.WebConstants.Purchase_ScheduleAllModulesSetup, USPDHUBBLL.WebConstants.Purchase_ScheduleAllModulesSetup, orderdetails.AccessType, orderDetailsID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.WebLinksSetup))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                            objBus.InsertPackageItem(hdnUserDomain.Value, "WebLinks", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.SocialMediaAutoPostSetup))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                            /*** Insert User Module Tab here ***/
                            string appIcon = "";
                            string tabName = "AutoPost";
                            int UserModuleID = 0;
                            int module = 0;
                            UserModuleID = objCommon.InsertUserCustomModules(profileID, userID, userID, module, appIcon,
                                tabName, true, DateTime.Now, DateTime.Now, objBillingInfo.RenewalDate, "", false,
                                USPDHUBBLL.WebConstants.Purchase_SocialMediaAutoPostSetup, USPDHUBBLL.WebConstants.Purchase_SocialMediaAutoPostSetup, orderdetails.AccessType, orderDetailsID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.SocialMedia))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                            objBus.InsertPackageItem(hdnUserDomain.Value, "SocialMedia", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.SurveySetup))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                            objBus.InsertPackageItem(hdnUserDomain.Value, "Surveys", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.ContactUs_BlockSenderSetup))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                            objBus.InsertPackageItem(hdnUserDomain.Value, "Contact", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.Tips_BlockSenderSetup))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                                DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                                orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                                Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                                orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                            objBus.InsertPackageItem(hdnUserDomain.Value, "Tips", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.ManageLoginsSetup))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            /*** Insert User Module Tab here ***/
                            string appIcon = "";
                            string tabName = "Manage Logins";
                            int UserModuleID = 0;
                            int module = 0;
                            UserModuleID = objCommon.InsertUserCustomModules(profileID, userID, userID, module, appIcon,
                                tabName, true, DateTime.Now, DateTime.Now, objBillingInfo.RenewalDate, "", false,
                                USPDHUBBLL.WebConstants.Purchase_ManageLoginsSetup, USPDHUBBLL.WebConstants.Purchase_ManageLoginsSetup, orderdetails.AccessType, orderDetailsID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.PushNotifications))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                            objBus.InsertPackageItem(hdnUserDomain.Value, "Notifications", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.AppDisplayCustomization))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            /*** Insert User Module Tab here ***/
                            string appIcon = "";
                            string tabName = "App Diplay Setup";
                            int UserModuleID = 0;
                            int module = 0;
                            UserModuleID = objCommon.InsertUserCustomModules(profileID, userID, userID, module, appIcon,
                                tabName, true, DateTime.Now, DateTime.Now, objBillingInfo.RenewalDate,"", false,
                               USPDHUBBLL.WebConstants.Purchase_AppDisplayCustomizationSetup, USPDHUBBLL.WebConstants.Purchase_AppDisplayCustomizationSetup, orderdetails.AccessType, orderDetailsID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.OneTouchCallButton))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            objBus.InsertPackageItem(hdnUserDomain.Value, "Call", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.WidgetsResources))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            /*** Insert User Module Tab here ***/
                            string appIcon = "";
                            string tabName = "Widgets Resources";
                            int UserModuleID = 0;
                            int module = 0;
                            UserModuleID = objCommon.InsertUserCustomModules(profileID, userID, userID, module, appIcon,
                                tabName, true, DateTime.Now, DateTime.Now, objBillingInfo.RenewalDate, "", false,
                                USPDHUBBLL.WebConstants.Purchase_WidgetsResources, USPDHUBBLL.WebConstants.Purchase_WidgetsResources, orderdetails.AccessType, orderDetailsID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.ManageContacts_EmailReports))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            /*** Insert User Module Tab here ***/
                            string appIcon = "";
                            string tabName = "Contacts Reports";
                            int UserModuleID = 0;
                            int module = 0;
                            UserModuleID = objCommon.InsertUserCustomModules(profileID, userID, userID, module, appIcon,
                                tabName, true, DateTime.Now, DateTime.Now, objBillingInfo.RenewalDate, "", false,
                                USPDHUBBLL.WebConstants.Purchase_Contacts_Reports, USPDHUBBLL.WebConstants.Purchase_Contacts_Reports, orderdetails.AccessType, orderDetailsID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.Directions))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            objBus.InsertPackageItem(hdnUserDomain.Value, "Directions", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                        }
                        else if (orderdetails.RequestType == Convert.ToInt32(RequestCustomFormTypes.PrivateSmartConnectAddOns))
                        {
                            orderDetailsID = objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                              DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                              orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                              Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                              orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);

                            if (orderdetails.IsPackageItem)
                                objBus.InsertPackageItem(hdnUserDomain.Value, "PrivateSmartConnectAddOns", orderdetails.AccessType, orderDetailsID, objBillingInfo.RenewalDate, profileID, userID);
                            else
                                objBus.InsertPurchaseAddons(profileID, userID, userID, WebConstants.Purchase_PrivateSmartConnectAddOns);

                            objBus.InsertSMSAddons(profileID, userID, orderDetailsID, ConfigurationManager.AppSettings["defaultSMSType"].ToString(), Convert.ToInt32(ConfigurationManager.AppSettings["defaultSMSQuantity"]) * orderdetails.Quantity);
                        }
                        else
                        {
                            objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, orderdetails.SubscriptionID, orderdetails.Total, orderdetails.Discount, orderdetails.Billable,
                                DateTime.Now, userID, objBillingInfo.StartDate, objBillingInfo.RenewalDate, orderdetails.RequestType,
                                orderdetails.Sub_SubscriptionID, null, objBillingInfo.SubPeriod, objBillingInfo.PromoCode,
                                Convert.ToDecimal(orderdetails.Renewal), orderdetails.RenewalLifeIme, orderdetails.PromoCodeId, "",
                                orderdetails.Quantity, orderdetails.IsPackageItem ? objBillingInfo.PackageID : (int?)null, orderdetails.IsPackageItem ? ParentOrderDetalsID : null);
                        }
                    }
                }
                #endregion


                ////Insert Order Details
                //DateTime createDate = DateTime.Now;
                //DateTime renewalDate = createDate.AddMonths(subPeriod);
                //int? promoCodeId = null;
                //objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, Convert.ToInt32(ddlSubscriptions.SelectedValue), totalAmt, discount,
                //          billableAmt, createDate, userID, createDate, renewalDate, Convert.ToInt32(RequestCustomFormTypes.NewRegistration), null, null,
                //          subPeriod, discountcode, totalAmt, false, promoCodeId, salesCode);

                //if (isLiteVersion)
                //    objBus.InsertSMSAddons(profileID, userID, 0, ConfigurationManager.AppSettings["defaultLiteSMSType"].ToString(), Convert.ToInt32(ConfigurationManager.AppSettings["defaultLiteSMSQuantity"]));

                //if (isBranded)
                //{
                //    objBus.UpdateUserBrandedApp(profileID);
                //    objBus.Insert_Update_AppProcessStatus(0, userID, profileID, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                //                string.Empty, "", string.Empty, string.Empty, string.Empty, string.Empty, Convert.ToInt32(BusinessDAL.BranedAppProcessStatus.New), 0);

                //    if (hdnBrandedID.Value == "")
                //        hdnBrandedID.Value = "0";

                //    objBus.InsertOrderDetails(profileID, userID, subcriptionTypeID, Convert.ToInt32(hdnBrandedID.Value), Convert.ToDecimal(hdnBrandedAmt.Value), Convert.ToDecimal(hdnBrandedAmt.Value),
                //       0.00M, createDate, userID, createDate, renewalDate, Convert.ToInt32(RequestCustomFormTypes.BrandedApp), null, null,
                //       subPeriod, "", 0.00M, false, promoCodeId, salesCode);
                //}


                // Turn on/off auto email
                SendActivationEmail(username, password, "", hdnUserDomain.Value, isSendEmail);
                if (isSendEmail)
                    objCommon.SendRepresentationEmail(profileID, hdnUserDomain.Value);


                Session["Message"] = "New account has been created successfully.";
                if (hdnInquiryId.Value != "")
                    Response.Redirect("EnquiryListings.aspx");
                else
                    Response.Redirect("CustomerServiceNew.aspx");
                #endregion
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CreateFreeAccount.aspx.cs", "btnActivateAccount", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCancelAccount(object sender, EventArgs e)
        {
            Response.Redirect("CustomerServiceNew.aspx");
        }
        private void SendActivationEmail(string username, string password, string location, string verticalValue, bool isSendEmail)
        {
            try
            {

                CommonBLL objCommon = new CommonBLL();
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
                string FromEmailsupport = "";
                DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(verticalValue, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                            FromEmailsupport = row[1].ToString();
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
                string toEmails = username;
                if (isSendEmail == false)
                {
                    toEmails = "";
                    reDeclaimer = File.OpenText(strfilepath + "AutoEmails.txt");
                    while ((desclaimer = reDeclaimer.ReadLine()) != null)
                    {
                        toEmails = toEmails + desclaimer;
                    }
                    reDeclaimer.Close();
                    reDeclaimer.Dispose();
                }
                string ccemail = string.Empty;
                UtilitiesBLL utlobj = new UtilitiesBLL();
                utlobj.SendWowzzyEmail(FromEmailsupport, toEmails, "Account Details", msgbody, ccemail, "", verticalValue);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CreateFreeAccount.aspx.cs", "SendActivationEmail", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }



        [WebMethod]
        public static string ServerSidefill(string emid, string Countrys, string Verticals)
        {
            string typevalue = "";
            try
            {
                BusinessBLL objWow = new BusinessBLL();
                AgencyBLL objAgency = new AgencyBLL();
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
                            countUser = objWow.CheckUserNameandPasswordForVaildUser(emid, Verticals, Countrys);
                            int count = objAgency.ValidateAgencyEmailID(emid, Verticals, Countrys);
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
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CreateFreeAccount.aspx.cs", "ServerSidefill", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return typevalue;
        }

        //protected void subscrptnPeriodyrly_CheckedChanged(object sender, EventArgs e)
        //{
        //    objBus.CaliculateAmount(ddlSubscriptions.SelectedValue);
        //}

        protected void ddlSubscriptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            CaliculateAmount();
        }
        public void CaliculateAmount()
        {
            DataTable dt = new DataTable();
            dt = objBus.CaliculateAmount(Convert.ToInt32(ddlSubscriptions.SelectedValue));
            lblMnthly.Text = (dt.Rows[0][0]).ToString();
            lblyearly.Text = (dt.Rows[0][1]).ToString();
        }
    }
}