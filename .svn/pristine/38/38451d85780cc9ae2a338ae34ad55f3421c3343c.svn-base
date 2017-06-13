using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using USPDHUBDAL;
using System.IO;
using System.Data.SqlClient;
using System.Web.Services;
using System.Collections.Generic;

namespace USPDHUB.Admin
{
    public partial class EnquiryDetails : System.Web.UI.Page
    {
        public int AdminUserID = 0;
        public int UserID = 0;
        DataTable dtVerifyDetails = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        CommonBLL objCommonBll = new CommonBLL();
        AdminBLL admnobj = new AdminBLL();
        public int InquiryId = 0;
        public DataTable Dtsales = new DataTable();
        DataTable dtverticals = new DataTable();
        public int ProfileID = 0;
        USPDHUBBLL.Consumer conobj = new USPDHUBBLL.Consumer();
        BusinessBLL busobj = new BusinessBLL();
        public string Urlinfo = string.Empty;
        public int CheckRenewalValue = 0;
        public string Renew = string.Empty;
        public bool Redirectflag = true;

        public bool IsLiteversion = false;
        public int ProfileSubType = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["adminuserid"] != null)
                {
                    AdminUserID = Convert.ToInt32(Session["adminuserid"]);
                }
                else
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }

                if (!string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
                {
                    InquiryId = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["ID"].ToString()));
                    hdnNotesCnt.Value = Convert.ToString(admnobj.GetNotesCountById(InquiryId));
                    if (!string.IsNullOrEmpty(hdnNotesCnt.Value) && hdnNotesCnt.Value != "0")
                    {
                        lnkNotes.Visible = false;
                        lnkbNotes.Visible = true;
                    }
                }

                if (!IsPostBack)
                {
                    #region Getting Sales Persons
                    Dtsales = agencyobj.GetSalesPerson();
                    ddlSalesRep.DataSource = Dtsales;
                    ddlSalesRep.DataTextField = "Sales_Name";
                    ddlSalesRep.DataValueField = "SalePerson_ID";
                    ddlSalesRep.DataBind();
                    ddlSalesRep.Items.Insert(0, new ListItem("-- Select --", "0"));
                    #endregion
                    // *** Gettting Active Verticals *** //
                    dtverticals = agencyobj.GetActiveVerticals();
                    ddlVertical.DataSource = dtverticals;
                    ddlVertical.DataTextField = "Vertical_Name";
                    ddlVertical.DataValueField = "Vertical_Value";
                    ddlVertical.DataBind();


                    if (!string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
                    {
                        hdnInquiryId.Value = EncryptDecrypt.DESDecrypt(Request.QueryString["ID"].ToString());
                        dtVerifyDetails = agencyobj.GetVerifyDetailsById(Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["ID"].ToString())));
                        if (dtVerifyDetails.Rows.Count == 1)
                        {
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Agency_Name"].ToString()))
                                txtAgencyName.Text = dtVerifyDetails.Rows[0]["Agency_Name"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Contact_Person"].ToString()))
                                txtContactPerson.Text = dtVerifyDetails.Rows[0]["Contact_Person"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["LastName"].ToString()))
                                txtLastName.Text = dtVerifyDetails.Rows[0]["LastName"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Title"].ToString()))
                                txtTitle.Text = dtVerifyDetails.Rows[0]["Title"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["HowIKnow"].ToString()))
                                ddlHow.SelectedValue = dtVerifyDetails.Rows[0]["HowIKnow"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Phone_Number"].ToString()))
                                txtphonenumber.Text = dtVerifyDetails.Rows[0]["Phone_Number"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Email_Address"].ToString()))
                                txtEmail.Text = dtVerifyDetails.Rows[0]["Email_Address"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["City"].ToString()))
                                txtCity.Text = dtVerifyDetails.Rows[0]["City"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Zipcode"].ToString()))
                                txtZipCode.Text = dtVerifyDetails.Rows[0]["Zipcode"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["State"].ToString()))
                                drpState.SelectedValue = dtVerifyDetails.Rows[0]["State"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Address"].ToString()))
                                txtAgencyAddress.Text = dtVerifyDetails.Rows[0]["Address"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Website_Address"].ToString()))
                                txtWebsiteAddress.Text = dtVerifyDetails.Rows[0]["Website_Address"].ToString();
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Inquiry_Status"].ToString()))
                            {
                                if (dtVerifyDetails.Rows[0]["Inquiry_Status"].ToString() == "1")
                                {
                                    lnkActivateAcnt.Visible = true;
                                    lnkPayment.Visible = false;
                                }
                                else if (dtVerifyDetails.Rows[0]["Inquiry_Status"].ToString() == "2")
                                {
                                    lnkPayment.Visible = false;
                                    lnkcancel.Visible = true;
                                }
                            }
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["SalesPersonID"].ToString()))
                            {
                                ddlSalesRep.SelectedValue = dtVerifyDetails.Rows[0]["SalesPersonID"].ToString();
                            }
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Vertical_Name"].ToString()))
                            {
                                ddlVertical.SelectedValue = dtVerifyDetails.Rows[0]["Vertical_Name"].ToString();
                            }
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Country"].ToString()))
                            {
                                ddlCountry.SelectedValue = dtVerifyDetails.Rows[0]["Country"].ToString();
                            }
                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["Parent_ProfileID"].ToString()))
                            {
                                pnlParent.Visible = true;
                                hdnParent.Value = dtVerifyDetails.Rows[0]["Parent_ProfileID"].ToString();
                                DataTable dtprofile = busobj.GetProfileDetailsByProfileID(Convert.ToInt32(dtVerifyDetails.Rows[0]["Parent_ProfileID"].ToString()));
                                lblParent.Text = dtprofile.Rows[0]["Profile_name"].ToString();
                            }

                            if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["IsLiteVersion"].ToString()))
                            {
                                if (Convert.ToBoolean(dtVerifyDetails.Rows[0]["IsLiteVersion"]))
                                {
                                    lblSubType.Text = "Basic";
                                    Session["IsLiteversion"] = IsLiteversion = true;
                                }
                                else
                                {
                                    Session["IsLiteversion"] = IsLiteversion = false;
                                    lblSubType.Text = "Premium";
                                }
                            }
                        }
                    }
                    if (Session["Success"] != null)
                    {
                        lblSuccess.Text = "<font size='2' color='green'>" + Session["Success"] + "</font>";
                        Session["Success"] = null;
                    }
                }
                txtAgencyName.Focus();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryDetails.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        //protected void btncancel_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect(RootPath + "/Admin/Default.aspx");
        //}
        protected void LnkBackClick(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Admin/EnquiryListings.aspx"));
        }
        protected void LnkAddClick(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Admin/AdditionalDetails.aspx?ID=" + EncryptDecrypt.DESEncrypt(hdnInquiryId.Value)));
        }
        protected void LnkSubmitClick(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    int i = InsertDetails();
                    if (i == 1)
                    {
                        lblSuccess.Text = "<font size='2' color='green'>Verification details have been saved successfully.</font>";
                        //Session["Success"]
                        //Response.Redirect(Page.ResolveClientUrl("~/Admin/AdditionalDetails.aspx?ID=" + EncryptDecrypt.DESEncrypt(hdnInquiryId.Value)));
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryDetails.aspx.cs", "LnkSubmitClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void LnkPaymentClick(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    int i = InsertDetails();
                    if (i == 1)
                    {
                        dtVerifyDetails = agencyobj.GetVerifyDetailsById(Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["ID"].ToString())));
                        if (string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["SubscriptionType_ID"].ToString()))
                            Response.Redirect(Page.ResolveClientUrl("~/Admin/SelectPayType.aspx?ID=" + EncryptDecrypt.DESEncrypt(InquiryId.ToString()) + "&src=" + EncryptDecrypt.DESEncrypt("edetails")));
                        else
                            Response.Redirect(Page.ResolveClientUrl("~/Admin/ChequeProcess.aspx?ID=" + EncryptDecrypt.DESEncrypt(InquiryId.ToString())));
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryDetails.aspx.cs", "LnkPaymentClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void LnkActivateAcntClick(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    int i = InsertDetails();
                    if (i == 1)
                    {
                        string password = objCommonBll.GenerateRandomPassword();

                        #region Getting Latidude & longtidude values
                        string fullAddress = txtAgencyAddress.Text + "," + txtCity.Text + "," + drpState.SelectedValue + "," + txtZipCode.Text;
                        Coordinate coordinates = Geocode.GetCoordinates(fullAddress);

                        double latitude1 = Convert.ToDouble(coordinates.Latitude);
                        double longitude1 = Convert.ToDouble(coordinates.Longitude);
                        #endregion

                        int profileID = 0;
                        if (Convert.ToBoolean(Session["IsLiteversion"]))
                            profileID = agencyobj.InsertNewSubcriptionUserDetails(latitude1, longitude1, EncryptDecrypt.DESEncrypt(password), InquiryId, Convert.ToInt32(ProfileSubscriptionTypes.PaidLite));
                        else
                            profileID = agencyobj.InsertNewSubcriptionUserDetails(latitude1, longitude1, EncryptDecrypt.DESEncrypt(password), InquiryId, Convert.ToInt32(ProfileSubscriptionTypes.Premium));

                        int createdUserID = 0;
                        DataTable dtuserdetails = busobj.GetProfileDetailsByProfileID(profileID);
                        Boolean isLiteVersion = false;
                        if (dtuserdetails.Rows.Count > 0)
                        {
                            createdUserID = Convert.ToInt32(dtuserdetails.Rows[0]["User_ID"]);
                            if (Convert.ToBoolean(dtuserdetails.Rows[0]["IsBranded_App"].ToString()) == true)
                                busobj.Insert_Update_AppProcessStatus(0, createdUserID, profileID, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                            string.Empty, "", string.Empty, string.Empty, string.Empty, string.Empty, Convert.ToInt32(BusinessDAL.BranedAppProcessStatus.New), 0);

                            isLiteVersion = Convert.ToBoolean(dtuserdetails.Rows[0]["IsLiteVersion"]);
                        }
                        if (profileID > 0)
                        {

                            dtVerifyDetails = agencyobj.GetVerifyDetailsById(InquiryId);

                            int orderID = Convert.ToInt32(dtVerifyDetails.Rows[0]["SubscriptionType_ID"].ToString());
                            int subPeriod = Convert.ToInt32(dtVerifyDetails.Rows[0]["Subscription_Period"].ToString());
                            DataTable dtInvoiceOrderDetails = busobj.GetOrderIDInvoice(orderID);
                            decimal total = Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["Total_Amount"].ToString());
                            decimal discount = Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["Discount_Amount"].ToString());
                            decimal billableAmt = Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["OrderBillable_Amt"].ToString());
                            int subscriptionID = busobj.InsertUserSubscriptions(profileID, createdUserID, subPeriod, total, discount, billableAmt, "", "", "", "", "", "", "", "", "", 0, 0, "", "", "", false);
                            
                            string logopath = string.Empty;

                            if (dtVerifyDetails.Rows.Count == 1)
                                logopath = dtVerifyDetails.Rows[0]["Logo"].ToString();
                            if (!string.IsNullOrEmpty(logopath))
                            {
                                string path = objCommonBll.CopyLogo(profileID, logopath, InquiryId);
                                if (!string.IsNullOrEmpty(path))
                                    agencyobj.UpdateLogoPath(profileID, path);
                            }
                            busobj.UpdateOrderDetails(profileID, createdUserID, orderID, subPeriod);

                            if (isLiteVersion)
                                busobj.InsertSMSAddons(profileID, createdUserID, 0, ConfigurationManager.AppSettings["defaultLiteSMSType"].ToString(), Convert.ToInt32(ConfigurationManager.AppSettings["defaultLiteSMSQuantity"]));


                            string domainName = objCommonBll.GetDomainNameByCountryVertical(ddlVertical.SelectedValue, ddlCountry.SelectedValue);
                            string location = objCommonBll.CreateInvoiceReport(orderID, ddlVertical.SelectedValue, domainName);
                            SendActivationEmail(txtEmail.Text, password, "", domainName);
                            objCommonBll.SendRepresentationEmail(profileID, domainName);
                            SendInvoiceEmail(domainName, dtInvoiceOrderDetails.Rows[0]["Billing_Email"].ToString(), location, (dtInvoiceOrderDetails.Rows[0]["Billing_FirstName"].ToString() + dtInvoiceOrderDetails.Rows[0]["Billing_LastName"].ToString()));
                            lnkActivateAcnt.Visible = false;
                            lnkcancel.Visible = true;
                            lblSuccess.Text = "<font size='2' color='green'>Account has been activated successfully.</font>";
                            lnkPayment.Visible = false;
                            // *** Save Billing Information
                            busobj.InsertUpdateBillingInfo(dtInvoiceOrderDetails.Rows[0]["Billing_FirstName"].ToString(), dtInvoiceOrderDetails.Rows[0]["Billing_LastName"].ToString(), dtInvoiceOrderDetails.Rows[0]["Billing_Email"].ToString(), dtInvoiceOrderDetails.Rows[0]["Billing_Address1"].ToString(), "", dtInvoiceOrderDetails.Rows[0]["Billing_State"].ToString(), dtInvoiceOrderDetails.Rows[0]["Billing_City"].ToString(),
                                                dtInvoiceOrderDetails.Rows[0]["Billing_Zipcode"].ToString(), UserID, ProfileID, 0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryDetails.aspx.cs", "LnkActivateAcntClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public int InsertDetails()
        {
            try
            {
                int? salespersonsId = null;
                string status = string.Empty;
                dtVerifyDetails = agencyobj.GetVerifyDetailsById(Convert.ToInt32(hdnInquiryId.Value));
                if (dtVerifyDetails.Rows.Count == 1)
                {
                    hdnFlag.Value = dtVerifyDetails.Rows[0]["Verified_Status"].ToString();
                }

                if (hdnFlag.Value.ToLower().ToString() == "unverified" || string.IsNullOrEmpty(hdnFlag.Value))
                    status = "Verified";
                else
                    status = hdnFlag.Value;

                salespersonsId = Convert.ToInt32(ddlSalesRep.SelectedValue) > 0 ? Convert.ToInt32(ddlSalesRep.SelectedValue) : salespersonsId;
                int i = agencyobj.UpdateAgencyDtlsById(Convert.ToInt32(hdnInquiryId.Value), txtAgencyName.Text, txtEmail.Text, txtContactPerson.Text, txtLastName.Text.Trim(), txtphonenumber.Text, drpState.SelectedValue, txtCity.Text, txtZipCode.Text, txtAgencyAddress.Text, txtWebsiteAddress.Text, salespersonsId, status, ddlVertical.SelectedValue, txtTitle.Text, ddlHow.SelectedValue, ddlCountry.SelectedValue, hdnParent.Value == "" ? (int?)null : Convert.ToInt32(hdnParent.Value));
                return i;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryDetails.aspx.cs", "InsertDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return 0;
            }

        }

        private void SendActivationEmail(string username, string password, string location, string domain)
        {
            try
            {
                CommonBLL objCommon = new CommonBLL();
                string vertRootPath = "";
                DataTable dtConfigs = objCommon.GetVerticalConfigsByType(domain, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            vertRootPath = row[1].ToString();
                    }
                }
                string FromEmailsupport = "";
                DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(domain, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailFrom")
                            FromEmailsupport = row[1].ToString();
                    }
                }
                string strfilepath = Server.MapPath("~") + "\\EmailContent" + domain + "\\";
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
                msgbody = msgbody.Replace("#Link#", "<a href='" + vertRootPath + "/OP/" + domain + "/Login.aspx' target='_blank'>Login</a>");
                msgbody = msgbody.Replace("#Email#", username);
                msgbody = msgbody.Replace("#Password#", password);
                re.Close();
                re.Dispose();
                reDeclaimer.Close();
                reDeclaimer.Dispose();
                string ccemail = string.Empty;
                UtilitiesBLL utlobj = new UtilitiesBLL();
                if (string.IsNullOrEmpty(location))
                    utlobj.SendWowzzyEmail(FromEmailsupport, username, "Account Details", msgbody, ccemail, "", domain);
                else
                    utlobj.SendWowzzyEmailWithAttachments(FromEmailsupport, username, "Account Details", msgbody, ccemail, location, domain);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryDetails.aspx.cs", "SendActivationEmail", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void SendInvoiceEmail(string domainName, string username, string attachment, string contactPerson)
        {
            try
            {
                string rootPath = "";
                DataTable dtConfigs = objCommonBll.GetVerticalConfigsByType(domainName, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            rootPath = row[1].ToString();
                    }
                }
                string FromEmailsupport = "";
                DataTable dtConfigsemails = objCommonBll.GetVerticalConfigsByType(domainName, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                            FromEmailsupport = row[1].ToString();
                    }
                }
                string strfilepath = Server.MapPath("~") + "\\EmailContent" + domainName + "\\";
                StreamReader re = File.OpenText(strfilepath + "CheckInvoice.txt");
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
                msgbody = msgbody.Replace("#RootUrl#", rootPath);
                msgbody = msgbody.Replace("#msgBody#", content);
                msgbody = msgbody.Replace("#ContactPerson#", contactPerson);
                msgbody = msgbody.Replace("#Name#", contactPerson);
                re.Close();
                re.Dispose();
                reDeclaimer.Close();
                reDeclaimer.Dispose();
                UtilitiesBLL utlobj = new UtilitiesBLL();
                utlobj.SendWowzzyEmailWithAttachments(FromEmailsupport, username, "Invoice Details", msgbody, "", attachment, domainName);                
            }
            catch (Exception ex)
            {
                
            }
        }
        protected void ImgclseClick(object sender, EventArgs e)
        {
            try
            {
                hdnNotesCnt.Value = Convert.ToString(admnobj.GetNotesCountById(InquiryId));
                if (!string.IsNullOrEmpty(hdnNotesCnt.Value) && hdnNotesCnt.Value != "0")
                {
                    lnkNotes.Visible = false;
                    lnkbNotes.Visible = true;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryDetails.aspx.cs", "ImgclseClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void LnkcancelClick(object sender, EventArgs e)
        {
            try
            {
                string username = string.Empty;
                string passcode = string.Empty;
                username = txtEmail.Text;
                int roleID = 0;
                if (username == ConfigurationManager.AppSettings.Get("AdminUserID").ToString() && passcode == ConfigurationManager.AppSettings.Get("AdminPassword").ToString())
                {
                    //Check for userID  And password is it admin type..
                    lblSuccess.Text = "<font face=arial color=red size=2>Invalid login name & password, please try again </font>";
                }
                else
                {
                    Session["HelpCheck"] = "1";
                    string domainName = objCommonBll.GetDomainNameByCountryVertical(ddlVertical.SelectedValue, ddlCountry.SelectedValue);
                    DataTable dtConfigs = objCommonBll.GetVerticalConfigsByType(domainName, "Paths");
                    if (dtConfigs.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtConfigs.Rows)
                        {
                            if (row[0].ToString() == "RootPath")
                            {
                                Urlinfo = row[1].ToString();
                                break;
                            }
                        }
                    }
                    DataTable dtobj = conobj.GetUserDetails(username, domainName);
                    if (dtobj != null)
                    {
                        Session["C_USER_ID"] = null;

                        if (dtobj.Rows.Count == 1)
                        {
                            if (Convert.ToBoolean(dtobj.Rows[0]["Active_flag"]) == true)
                            {
                                //Assign to Session variables 
                                Session["UserID"] = dtobj.Rows[0]["User_ID"].ToString();
                                UserID = Convert.ToInt32(dtobj.Rows[0]["User_ID"]);
                                Session["username"] = dtobj.Rows[0]["Username"].ToString(); //added by venkat
                                Session["Name"] = dtobj.Rows[0]["firstname"].ToString();
                                Session["RoleID"] = dtobj.Rows[0]["Role_ID"].ToString();
                                roleID = Convert.ToInt32(dtobj.Rows[0]["Role_ID"]);

                                #  region user tracking
                                // user tracking    
                                string date = string.Empty;
                                string time = string.Empty;
                                date = System.DateTime.Now.ToShortDateString();
                                time = System.DateTime.Now.ToShortTimeString();
                                string ipaddress = Request.Params["REMOTE_ADDR"].ToString();
                                // *** Issue 1106 *** //
                                string userLoginBrowser = Request.Browser.Browser.ToString();
                                string userBrowserVer = Request.Browser.Version.ToString();
                                busobj.Usertracking(UserID, ipaddress, time, "", date, "", 1, userLoginBrowser, userBrowserVer);

                                # endregion

                                # region For Business User
                                if (roleID == (int)USPDHUBBLL.UtilitiesBLL.RoleTypes.Business)
                                {
                                    //Populate the profile details
                                    DataTable bustabobj = new DataTable();
                                    bustabobj = busobj.GetBusinessProfileByUserID(UserID);
                                    if (bustabobj.Rows.Count == 0)
                                    {
                                        Redirectflag = false;
                                        Session["ProfileID"] = null;
                                        Session["UserID"] = null;
                                        Session["BusinessType"] = null;
                                    }
                                    else if (bustabobj.Rows.Count == 1)
                                    {
                                        // Get the ProfileID for further propogations         
                                        ProfileID = Convert.ToInt32(bustabobj.Rows[0]["Profile_ID"]);
                                        Session["UserID"] = UserID.ToString();
                                        Session["ProfileID"] = ProfileID.ToString();
                                        Session["Generaltab"] = "";
                                        Session["UserLogin"] = "1";
                                        Session["firstname"] = bustabobj.Rows[0]["Profile_name"].ToString();//First name having business name.

                                        //Start get business type
                                        Session["BusinessType"] = "Agency";
                                        // End get business type

                                        // Get User Subscription Details
                                        DataTable dtSubscriptionDetails = new DataTable();
                                        dtSubscriptionDetails = busobj.Getorderidbyuserid(UserID);
                                        if (dtSubscriptionDetails.Rows.Count > 0)
                                        {
                                            DateTime renewalDate;
                                            renewalDate = Convert.ToDateTime(dtSubscriptionDetails.Rows[0]["subscription_renewal_date"].ToString());
                                            if (renewalDate.Date > DateTime.Now.Date)
                                            {

                                                //Urlinfo = Urlinfo + "/Business/MyAccount/Default.aspx";
                                            }
                                            else
                                            {
                                                Renew = "1";
                                                GetFreeUserDetails();
                                            }
                                        }
                                        else
                                        {
                                            GetFreeUserDetails();
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                                # endregion
                                //  if user user renewal date is greater than today date
                                if (CheckRenewalValue == 0)
                                {
                                    if (Convert.ToInt32(Session["RoleID"]) == (int)UtilitiesBLL.RoleTypes.Business)
                                    {
                                        string urlinforforroot = Urlinfo + "/login.aspx?UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&flag=1&al=1";
                                        string fullUrl = "window.open('" + urlinforforroot + "', '_blank', '')";
                                        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullUrl, true);
                                    }
                                }
                            }
                        }
                        else
                        { }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryDetails.aspx.cs", "LnkcancelClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void GetFreeUserDetails()
        {
            try
            {
                // Check For Free User
                DataTable dtobj = busobj.GetUserDetailsByUserID(UserID);
                if (dtobj.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtobj.Rows[0]["IsFree"].ToString()) == true)
                        Session["Free"] = "1";
                    if (Renew == "1")
                    {
                        Session["Free"] = "1";
                        Session["Renewal"] = "1";
                    }
                    Urlinfo = Session["RootPath"].ToString() + "/Business/MyAccount/Default.aspx";
                    string fullUrl = "window.open('" + Urlinfo + "', '_blank', '')";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullUrl, true);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryDetails.aspx.cs", "GetFreeUserDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod]
        public static List<string> GetProfiles(string prefixText)
        {
            List<string> Profiles = new List<string>();
            try
            {
                BusinessBLL objBus = new BusinessBLL();
                DataTable dt = objBus.GetParentProfiles(prefixText);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Profiles.Add(dt.Rows[i]["Profile_name"].ToString());
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "EnquiryDetails.aspx.cs", "GetProfiles", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return Profiles;

        }
    }
}