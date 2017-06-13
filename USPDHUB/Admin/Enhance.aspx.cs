using System;
using System.Data;
using System.Configuration;
using USPDHUBBLL;
using System.IO;
using System.Text;
using Winnovative.PdfCreator;

namespace USPDHUB.Admin
{
    public partial class Enhance : System.Web.UI.Page
    {
        public int InquiryId = 0;
        public string RootPath = "";
        AdminBLL objAdminBll = new AdminBLL();
        AgencyBLL objAgencyBll = new AgencyBLL();
        CommonBLL objCommonBll = new CommonBLL();
        UtilitiesBLL utlobj = new UtilitiesBLL();
        public int AdminUserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["adminuserid"] != null)
                    AdminUserID = Convert.ToInt32(Session["adminuserid"]);
                else
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
                {
                    InquiryId = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["ID"].ToString()));
                    hdnNotesCnt.Value = Convert.ToString(objAdminBll.GetNotesCountById(InquiryId));
                    if (!string.IsNullOrEmpty(hdnNotesCnt.Value) && hdnNotesCnt.Value != "0")
                    {
                        lnkNotes.Visible = false;
                        lnkbNotes.Visible = true;
                    }
                }
                else
                    Response.Redirect(Page.ResolveClientUrl("~/Admin/EnquiryListings.aspx"));

                if (!IsPostBack)
                {
                    DataTable dtoptionalDetails = objAgencyBll.GetVerifyDetailsById(InquiryId);
                    if (!string.IsNullOrEmpty(dtoptionalDetails.Rows[0]["PromoCode"].ToString()))
                    {
                        txtPromoCode.Text = dtoptionalDetails.Rows[0]["PromoCode"].ToString();
                        DataTable dtPromo = objAdminBll.ValidatePromoCode(dtoptionalDetails.Rows[0]["PromoCode"].ToString(), InquiryId, false);
                        if (dtPromo.Rows[0]["Valid"].ToString() == "1")
                            hdnPCPercent.Value = dtPromo.Rows[0]["Percentage"].ToString();
                    }
                    rbCard.Checked = true;
                    //rbMonth.Checked = true;
                    pnlCheck.Visible = false;
                    lnkProcessCheck.Visible = false;
                    lnkActivateAcnt.Visible = false;
                    pnlOneTimeSetup.Visible = false;
                    if (!string.IsNullOrEmpty(dtoptionalDetails.Rows[0]["Parent_ProfileID"].ToString()))
                    {
                        hdnIsSubAccount.Value = "1";
                        //rbMonth.Checked = false;
                        //rbYear.Checked = true;
                    }
                    hdnVertical.Value = dtoptionalDetails.Rows[0]["Vertical_Name"].ToString();
                    BindPackages();
                    CheckInvoiceData();
                    hdnpkgamt.Value = ddlSubscriptions.SelectedValue;
                    hdnDomain.Value = objCommonBll.GetDomainNameByCountryVertical(dtoptionalDetails.Rows[0]["Vertical_Name"].ToString(), dtoptionalDetails.Rows[0]["Country"].ToString());
                    if (rbCard.Checked)
                    {
                        if (ddlSubscriptions.SelectedItem.Text.Contains("Branded App"))
                        {
                            //rbMonth.Checked = false;
                            //rbYear.Checked = true;
                            pnlOneTimeSetup.Visible = true;
                        }
                        GetPaymentDetails();
                    }
                    else
                    {
                        if (ddlSubscriptions.SelectedItem.Text.Contains("Branded App"))
                            pnlcheckOneTimeFee.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BindPackages()
        {
            try
            {
                ddlSubscriptions.DataSource = objCommonBll.GetSubPackages(hdnIsSubAccount.Value, hdnVertical.Value);
                ddlSubscriptions.DataTextField = "Description";
                ddlSubscriptions.DataValueField = "Value";
                ddlSubscriptions.DataBind();
            }
            catch (Exception ex)
            {

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "BindPackages", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void CheckInvoiceData()
        {
            try
            {
                pnlcheckOneTimeFee.Visible = false;
                DataTable dtCheckInvoice = objAdminBll.GetInquiryInvoice(InquiryId,false);
                if (dtCheckInvoice.Rows.Count > 0)
                {
                    pnlCheckPayment.Visible = true;
                    ddlSubscriptions.SelectedValue = GetSubscriptionValues(dtCheckInvoice.Rows[0]["Subscription_Package"].ToString());
                    lblCheckSubAmount.Text = ddlSubscriptions.SelectedValue;
                    //if (hdnIsSubAccount.Value == "")
                    //    lblCheckSubAmount.Text = (Convert.ToDecimal(ddlSubscriptions.SelectedValue) * 12).ToString();
                    decimal checkDiscAmut = 0.00M;
                    if (hdnPCPercent.Value != "")
                        checkDiscAmut = Math.Round(Convert.ToDecimal(lblCheckSubAmount.Text) * Convert.ToInt32(hdnPCPercent.Value) / 100, 0, MidpointRounding.AwayFromZero);
                    lblCheckDiscount.Text = checkDiscAmut.ToString();
                    lblInvoiceDate.Text = dtCheckInvoice.Rows[0]["Modified_Date"].ToString();
                    lblInvoiceAmt.Text = dtCheckInvoice.Rows[0]["Invoice_Amount"].ToString();
                    lblCheckAmt.Text = dtCheckInvoice.Rows[0]["Invoice_Amount"].ToString();


                    if (ddlSubscriptions.SelectedItem.Text.Contains("Branded App"))
                    {
                        decimal oneTimeSetupFee = 0.00M;
                        if (!string.IsNullOrEmpty(dtCheckInvoice.Rows[0]["OneTimesSetup_Fee"].ToString()))
                            oneTimeSetupFee = Convert.ToDecimal(dtCheckInvoice.Rows[0]["OneTimesSetup_Fee"].ToString());
                        lblInvoiceAmt.Text = (Convert.ToDecimal(dtCheckInvoice.Rows[0]["Invoice_Amount"].ToString()) + oneTimeSetupFee).ToString();
                        lblCheckTotal.Text = (Convert.ToDecimal(dtCheckInvoice.Rows[0]["Invoice_Amount"].ToString()) + oneTimeSetupFee).ToString();
                    }
                    txtPurchaseOrder.Text = dtCheckInvoice.Rows[0]["PurchaseOrder_No"].ToString();
                    txtEmail.Text = dtCheckInvoice.Rows[0]["Invoice_Email"].ToString();
                    pnlNoCheck.Visible = false;
                    pnlCheck.Visible = true;
                    txtCheckAmt.Text = "";
                    lnkProcessCheck.Visible = true;
                    lnkCheckOut.Visible = false;
                    lnkActivateAcnt.Visible = false;
                    rbCheck.Checked = true;
                    rbCard.Checked = false;
                    rbFree.Checked = false;
                }
            }
            catch (Exception ex)
            {

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "CheckInvoiceData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void CheckInvoiceDataByPackage()
        {
            try
            {
                //if (hdnIsSubAccount.Value == "")
                //    lblCheckSubAmount.Text = (Convert.ToDecimal(ddlSubscriptions.SelectedValue) * 12).ToString();
                //else
                lblCheckSubAmount.Text = ddlSubscriptions.SelectedValue;
                decimal checkDiscAmut = 0.00M;
                if (hdnPCPercent.Value != "")
                    checkDiscAmut = Math.Round(Convert.ToDecimal(lblCheckSubAmount.Text) * Convert.ToInt32(hdnPCPercent.Value) / 100, 0, MidpointRounding.AwayFromZero);
                lblCheckDiscount.Text = checkDiscAmut.ToString();
                lblInvoiceAmt.Text = lblCheckAmt.Text = (Convert.ToDecimal(lblCheckSubAmount.Text) - checkDiscAmut).ToString();
                DataTable dtCheckInvoice = objAdminBll.GetInquiryInvoice(InquiryId,false);
                if (dtCheckInvoice.Rows.Count > 0)
                {
                    string subscriptionpkg = dtCheckInvoice.Rows[0]["Subscription_Package"].ToString();
                    if (ddlSubscriptions.SelectedItem.Text == subscriptionpkg)
                    {
                        pnlCheckPayment.Visible = true;
                        lblInvoiceDate.Text = dtCheckInvoice.Rows[0]["Modified_Date"].ToString();
                        lblInvoiceAmt.Text = dtCheckInvoice.Rows[0]["Invoice_Amount"].ToString();
                        ddlSubscriptions.SelectedValue = GetSubscriptionValues(dtCheckInvoice.Rows[0]["Subscription_Package"].ToString());
                        txtPurchaseOrder.Text = dtCheckInvoice.Rows[0]["PurchaseOrder_No"].ToString();
                        txtEmail.Text = dtCheckInvoice.Rows[0]["Invoice_Email"].ToString();
                    }
                    else
                        pnlCheckPayment.Visible = false;
                }
                else
                    pnlCheckPayment.Visible = false;
            }
            catch (Exception ex)
            {

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "CheckInvoiceDataByPackage", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void RbCardClick(object sender, EventArgs e)
        {
            try
            {
                ClearData();
                hdnpkgamt.Value = ddlSubscriptions.SelectedValue;
                if (rbCard.Checked)
                {
                    pnlOneTimeSetup.Visible = false;
                    //rbMonth.Visible = true;
                    //rbMonth.Checked = true;
                    //rbYear.Checked = false;
                    pnlCheck.Visible = false;
                    pnlCard.Visible = true;
                    hdnPlanPeriod.Value = "12"; // for annual
                    lnkCheckOut.Visible = true;
                    if (ddlSubscriptions.SelectedItem.Text.Contains("Branded App"))
                    {
                        //rbMonth.Checked = false;
                        //rbYear.Checked = true;
                        pnlOneTimeSetup.Visible = true;
                    }
                    else if (hdnIsSubAccount.Value == "")
                        hdnPlanPeriod.Value = "1"; // for 1 month  
                    //else if (hdnIsSubAccount.Value != "")
                    //{
                    //    rbMonth.Checked = false;
                    //    rbYear.Checked = true;
                    //}
                    GetPaymentDetails();
                }
                else if (rbCheck.Checked)
                {
                    pnlNoCheck.Visible = false;
                    pnlCheck.Visible = true;
                    txtCheckAmt.Text = "";
                    lnkProcessCheck.Visible = true;
                    pnlcheckOneTimeFee.Visible = false;
                    CheckInvoiceDataByPackage();
                    if (ddlSubscriptions.SelectedItem.Text.Contains("Branded App"))
                    {
                        pnlcheckOneTimeFee.Visible = true;
                        lblInvoiceAmt.Text = lblCheckTotal.Text = (Convert.ToDecimal(lblCheckOneTime.Text) + Convert.ToDecimal(lblCheckAmt.Text)).ToString();
                    }
                }
                else
                {
                    pnlPromo.Visible = false;
                    pnlCard.Visible = false;
                    lnkActivateAcnt.Visible = true;
                }
            }
            catch (Exception ex)
            {

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "RbCardClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void RbMonthCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ClearData();
                if (rbFree.Checked)
                {
                    pnlCard.Visible = false;
                    lnkActivateAcnt.Visible = true;
                }
                else
                {
                    lnkCheckOut.Visible = true;
                    GetPaymentDetails();
                }
            }
            catch (Exception ex)
            {

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "RbMonthCheckedChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetPaymentDetails()
        {
            try
            {
                int discountPercent = 0;
                if (hdnPCPercent.Value != "")
                    discountPercent = Convert.ToInt32(hdnPCPercent.Value);
                decimal discount = 0.00M;
                decimal paymentAmount = 0.00M;
                decimal paymentAmountPerYear = 0.00M;
                decimal paymentAmountperMonth = Convert.ToDecimal(hdnpkgamt.Value);
                //selectedMonths = 1;
                //hdnPlanPeriod.Value = "1"; // for 1 month
                //if (rbYear.Checked == true)
                //{
                //    selectedMonths = 12;
                //    hdnPlanPeriod.Value = "12"; // for 1 year                
                //}
                //if (hdnIsSubAccount.Value == "")
                //    paymentAmount = Convert.ToDecimal(paymentAmountperMonth * selectedMonths); // for selected months
                //else
                paymentAmount = Convert.ToDecimal(paymentAmountperMonth); // for selected months

                discount = Math.Round(paymentAmount * discountPercent / 100, 0, MidpointRounding.AwayFromZero);
                paymentAmountPerYear = Convert.ToDecimal(paymentAmount - discount);
                lblSubscAmount.Text = paymentAmount.ToString();
                lblDiscount.Text = discount.ToString();
                lblTotalAmt.Text = paymentAmountPerYear.ToString("0.00");
                if (ddlSubscriptions.SelectedItem.Text.Contains("Branded App"))
                {
                    lblTotalBllAmt.Text = (paymentAmountPerYear + Convert.ToDecimal(lblOneTimeFee.Text)).ToString("0.00");
                }
            }
            catch (Exception ex)
            {

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "GetPaymentDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void LnkCheckOutClick(object sender, EventArgs e)
        {
            try
            {
                string notes = "Payment Process";
                bool isCard = true;
                if (rbCheck.Checked)
                    isCard = false;
                if (lblTotalAmt.Text != "" && isCard)
                {
                    string firstname = txtfirstName.Text;
                    string lastname = txtlastname.Text;
                    string address1 = txtaddress1.Text;
                    string address2 = txtaddress2.Text;
                    string city = txtcity.Text;
                    string state = DrpState.SelectedValue;
                    string zipCode = txtzip.Text;
                    string country = "United States";
                    string cardTye = ddlCardType.SelectedValue;
                    string cardNumber = txtcreditCardNumber.Text;
                    string cvvnumber = txtcvv2Number.Text.Trim();
                    int expMonth = Convert.ToInt32(txtexpmonth.Text);
                    int expYear = Convert.ToInt32(txtexpyear.Text);
                    string amount = "0.00";
                    string paymentType = string.Empty;
                    string cardExpDate = string.Empty;
                    string authType = "AUTH_CAPTURE";
                    decimal? oneTimesetupfee = null;
                    decimal totalAmt = 0.00M;
                    if (ddlSubscriptions.SelectedItem.Text.Contains("Branded App"))
                    {
                        amount = (Convert.ToDecimal(lblTotalAmt.Text) + Convert.ToDecimal(lblOneTimeFee.Text)).ToString("0.00");
                        oneTimesetupfee = Convert.ToDecimal(lblOneTimeFee.Text);
                    }
                    else
                        amount = lblTotalAmt.Text;
                    totalAmt = Convert.ToDecimal(amount) + Convert.ToDecimal(lblDiscount.Text);
                    cardExpDate = expMonth.ToString() + expYear.ToString();
                    paymentType = "Registration Transaction";
                    string resVal = string.Empty;

                    if (amount == "0.00" || amount == "0")
                    {
                        authType = "AUTH_ONLY";
                        amount = "1";
                    }
                    int orderID = objAdminBll.AddInquiryTransactions(InquiryId, Convert.ToInt32(hdnPlanPeriod.Value), Convert.ToDecimal(lblSubscAmount.Text), Convert.ToDecimal(lblDiscount.Text), Convert.ToDecimal(lblTotalAmt.Text), address1, address2, city, state, zipCode, EncryptDecrypt.DESEncrypt(cardNumber), firstname, lastname, expMonth, expYear, EncryptDecrypt.DESEncrypt(cvvnumber), cardTye, country, AdminUserID, isCard, "", false, "", "", chkRecurring.Checked, oneTimesetupfee);
                    AuthorizedNet objAuthorized = new AuthorizedNet();
                    resVal = objAuthorized.AdvanceIntegrationForAuthorizedNet(cardNumber, cardExpDate, amount, firstname, lastname, address1, state, zipCode, paymentType, cvvnumber, authType);

                    if (resVal == "1")
                    {
                        notes = notes + "Succeeded.";
                        if (orderID > 0)
                            objAdminBll.UpdateInquiryTransaction(orderID, InquiryId, AdminUserID);
                        UpdatePackage(InquiryId);
                        objAdminBll.UpdateVerifyStatus(InquiryId, ConfigurationManager.AppSettings["verifystatuspaid"],false);
                        Session["Success"] = Resources.LabelMessages.CheckOutSuccess;
                        SendInvoiceDetails(InquiryId, cardNumber, lblSubscAmount.Text, lblDiscount.Text, lblTotalAmt.Text, firstname, lastname, address1, state, zipCode, orderID, oneTimesetupfee, totalAmt);
                        Response.Redirect(Page.ResolveClientUrl("~/Admin/EnquiryDetails.aspx?ID=" + EncryptDecrypt.DESEncrypt(InquiryId.ToString())));
                    }
                    else
                        notes = notes + "Failed.";
                    objAgencyBll.InsertEnquiryNotes(0, notes, "System", InquiryId, true);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "LnkCheckOutClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void LnkProcessCheckClick(object sender, EventArgs e)
        {
            try
            {
                string notes = "Check Process completed.";
                decimal totalAmount = Convert.ToDecimal(lblInvoiceAmt.Text);
                decimal billableAmount = Convert.ToDecimal(txtCheckAmt.Text.Trim());
                decimal? oneTimesetupfee = null;
                if (ddlSubscriptions.SelectedItem.Text.Contains("Branded App"))
                {
                    oneTimesetupfee = Convert.ToDecimal(lblOneTimeFee.Text);
                    if (billableAmount > oneTimesetupfee)
                        billableAmount = billableAmount - oneTimesetupfee.Value;
                    if (totalAmount > oneTimesetupfee)
                        totalAmount = totalAmount - oneTimesetupfee.Value;
                }

                string country = "United States";
                decimal discAmt = 0.00M;
                if (lblCheckDiscount.Text != "")
                    discAmt = Convert.ToDecimal(lblCheckDiscount.Text);
                int orderID = objAdminBll.AddInquiryTransactions(InquiryId, 12, totalAmount, discAmt, billableAmount, "", "", "", "", "", "", "", "", 0, 0, "", "Check", country, AdminUserID, false, txtCheckNum.Text.Trim(), true, "", txtPurchaseOrder.Text.Trim(), false, oneTimesetupfee);
                objAgencyBll.InsertEnquiryNotes(0, notes, "System", InquiryId, true);
                objAdminBll.UpdateVerifyStatus(InquiryId, ConfigurationManager.AppSettings["verifystatuspaid"],false);
                UpdatePackage(InquiryId);
                Session["Success"] = Resources.LabelMessages.CheckOutSuccess;
                SendInvoiceDetails(InquiryId, "", lblCheckSubAmount.Text, lblCheckDiscount.Text, billableAmount.ToString(), "", "", "", "", "", orderID, oneTimesetupfee, Convert.ToDecimal(lblInvoiceAmt.Text));
                Response.Redirect(Page.ResolveClientUrl("~/Admin/EnquiryDetails.aspx?ID=" + EncryptDecrypt.DESEncrypt(InquiryId.ToString())));
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "LnkProcessCheckClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void LnkActivateAcntClick(object sender, EventArgs e)
        {
            try
            {
                string address = "";
                string city = "";
                string state = "";
                string zipcode = "";
                DataTable dtVerifyDetails = objAgencyBll.GetVerifyDetailsById(InquiryId);
                if (dtVerifyDetails.Rows.Count == 1)
                {
                    address = dtVerifyDetails.Rows[0]["Address"].ToString();
                    city = dtVerifyDetails.Rows[0]["City"].ToString();
                    state = dtVerifyDetails.Rows[0]["State"].ToString();
                    zipcode = dtVerifyDetails.Rows[0]["Zipcode"].ToString();
                    #region Getting Latidude & longtidude values
                    string fullAddress = address + "," + city + "," + state + "," + zipcode;
                    Coordinate coordinates = Geocode.GetCoordinates(fullAddress);

                    double latitude1 = Convert.ToDouble(coordinates.Latitude);
                    double longitude1 = Convert.ToDouble(coordinates.Longitude);

                    #endregion
                    int orderID = objAdminBll.AddInquiryTransactions(InquiryId, Convert.ToInt32(hdnPlanPeriod.Value), 0.00M, 0.00M, 0.00M, "", "", "", "", "", "", "", "", 0, 0, "", "", "United States", AdminUserID, false, "", true, "FreeTrial", "", false, null);
                    if (orderID > 0)
                    {
                        UpdatePackage(InquiryId);
                        string password = objCommonBll.GenerateRandomPassword();
                        int profileId = objAgencyBll.InsertUserDetails(latitude1, longitude1, EncryptDecrypt.DESEncrypt(password), InquiryId);
                        if (profileId > 0)
                        {
                            objAgencyBll.InsertEnquiryNotes(0, "Freetrial success", "System", InquiryId, true);
                            string logopath = string.Empty;
                            logopath = dtVerifyDetails.Rows[0]["Logo"].ToString();
                            if (logopath != null && logopath != "")
                            {
                                string path = objCommonBll.CopyLogo(profileId, logopath, InquiryId);
                                if (path != null && path != "")
                                    objAgencyBll.UpdateLogoPath(profileId, path);
                            }
                            lnkActivateAcnt.Visible = false;
                            SendActivationEmail(dtVerifyDetails.Rows[0]["Email_Address"].ToString(), password);
                            Session["Success"] = "<font size='2' color='green'>Account has been activated successfully.</font>";
                            Response.Redirect(Page.ResolveClientUrl("~/Admin/EnquiryDetails.aspx?ID=" + EncryptDecrypt.DESEncrypt(InquiryId.ToString())));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "LnkActivateAcntClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void LnkInvoiceClick(object sender, EventArgs e)
        {
            try
            {
                decimal? oneTimeSetupFee = null;
                if (ddlSubscriptions.SelectedItem.Text.Contains("Branded App"))
                {
                    oneTimeSetupFee = Convert.ToDecimal(lblCheckOneTime.Text);
                }
                string purchaseOrderNo = txtPurchaseOrder.Text.Trim();
                int invoiceID = objAdminBll.AddCheckInvoice(InquiryId, purchaseOrderNo, txtEmail.Text.Trim(), Convert.ToDecimal(lblCheckAmt.Text), ddlSubscriptions.SelectedItem.Text, oneTimeSetupFee, Convert.ToDecimal(lblCheckDiscount.Text), "", false);
                objAdminBll.UpdateVerifyStatus(InquiryId, ConfigurationManager.AppSettings["verifystatusinvoice"],false);
                GenerateInvoice(invoiceID, oneTimeSetupFee);
                DataTable dtCheckInvoice = objAdminBll.GetInquiryInvoice(InquiryId, false);
                if (dtCheckInvoice.Rows.Count > 0)
                {
                    pnlCheckPayment.Visible = true;
                    lblInvoiceDate.Text = dtCheckInvoice.Rows[0]["Modified_Date"].ToString();
                    lblInvoiceAmt.Text = dtCheckInvoice.Rows[0]["Invoice_Amount"].ToString();
                    if (!string.IsNullOrEmpty(dtCheckInvoice.Rows[0]["OneTimesSetup_Fee"].ToString()))
                    {
                        lblInvoiceAmt.Text = (Convert.ToDecimal(dtCheckInvoice.Rows[0]["Invoice_Amount"].ToString()) + Convert.ToDecimal(dtCheckInvoice.Rows[0]["OneTimesSetup_Fee"].ToString())).ToString();
                    }
                }
                lblError.Text = "<font color='green' size='3'>Invoice has been created successfully and emailed.</font>";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "LnkInvoiceClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void LnkMainScreenClick(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Admin/EnquiryDetails.aspx?ID=" + EncryptDecrypt.DESEncrypt(InquiryId.ToString())));
        }
        protected void DdlSubscriptionsChanged(object sender, EventArgs e)
        {
            try
            {
                ClearData();
                hdnpkgamt.Value = ddlSubscriptions.SelectedValue;
                pnlOneTimeSetup.Visible = false;
                pnlcheckOneTimeFee.Visible = false;
                if (rbCheck.Checked)
                {
                    pnlNoCheck.Visible = false;
                    pnlCheck.Visible = true;
                    txtCheckAmt.Text = "";
                    lnkProcessCheck.Visible = true;
                    CheckInvoiceDataByPackage();
                    if (ddlSubscriptions.SelectedItem.Text.Contains("Branded App"))
                    {
                        pnlcheckOneTimeFee.Visible = true;
                        lblInvoiceAmt.Text = lblCheckTotal.Text = (Convert.ToDecimal(lblCheckOneTime.Text) + Convert.ToDecimal(lblCheckAmt.Text)).ToString();
                    }
                }
                else
                {
                    ResetData();
                    if (ddlSubscriptions.SelectedItem.Text.Contains("Branded App"))
                    {
                        //rbMonth.Checked = false;
                        //rbYear.Checked = true;
                        pnlOneTimeSetup.Visible = true;
                    }
                }
                GetPaymentDetails();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "DdlSubscriptionsChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void ResetData()
        {
            pnlCard.Visible = true;
            pnlCheck.Visible = false;
            rbCheck.Checked = false;
            rbFree.Checked = false;
            rbCard.Checked = true;
            //rbYear.Checked = false;
            //rbMonth.Checked = true;
            lnkCheckOut.Visible = true;
        }
        private void ClearData()
        {
            pnlPromo.Visible = true;
            pnlNoCheck.Visible = true;
            pnlCard.Visible = true;
            pnlCheck.Visible = false;
            lnkProcessCheck.Visible = false;
            lnkCheckOut.Visible = false;
            lnkActivateAcnt.Visible = false;
            ddlCardType.SelectedIndex = -1;
            txtfirstName.Text = "";
            txtlastname.Text = "";
            txtcreditCardNumber.Text = "";
            txtexpmonth.Text = "";
            txtexpyear.Text = "";
            txtcvv2Number.Text = "";
            txtaddress1.Text = "";
            txtaddress2.Text = "";
            txtcity.Text = "";
            txtzip.Text = "";
            txtPurchaseOrder.Text = "";
            txtEmail.Text = "";
            DrpState.SelectedIndex = -1;

        }
        private string GetSubscriptionPackage()
        {
            string package = "";
            string[] splitpackage = ddlSubscriptions.SelectedItem.Text.Split('-');
            package = splitpackage[0].Trim();
            return package;
        }
        private void GenerateInvoice(int invoiceID, decimal? oneTimeSetupFee)
        {
            try
            {
                string address = "";
                DataTable dtVerifyDetails = objAgencyBll.GetVerifyDetailsById(InquiryId);
                if (dtVerifyDetails.Rows.Count == 1)
                {
                    address = "<BR/><b>" + dtVerifyDetails.Rows[0]["Agency_Name"].ToString() + "</b><BR/>" + dtVerifyDetails.Rows[0]["Contact_Person"].ToString() + "<BR/>" + dtVerifyDetails.Rows[0]["Address"].ToString() + "<BR/>" + dtVerifyDetails.Rows[0]["City"].ToString() + "<BR/>" + dtVerifyDetails.Rows[0]["State"].ToString() + "<BR/>" + dtVerifyDetails.Rows[0]["Zipcode"].ToString();
                }
                string emailSupport = "";
                DataTable dtConfigs = objCommonBll.GetVerticalConfigsByType(hdnDomain.Value, "EmailAccounts");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "EmailSupport")
                            emailSupport = row[1].ToString();
                    }
                }
                string domain = objCommonBll.GetVerticalDomain(hdnVertical.Value);
                StringBuilder strhtml = new StringBuilder();
                string subtype = string.Empty;
                subtype = "Annual Subscription for Sub-App";
                if (subtype.ToLower().Contains("branded"))
                    subtype = "Annual Subscription for Branded App";
                strhtml.Append("<html><head>");
                strhtml.Append("<link href=" + Server.MapPath("~").ToString() + "\\css\\wowzzy_general.css rel='stylesheet' type='text/css' />");
                strhtml.Append("</head><body >");
                string logo = Server.MapPath("~") + "/Images/VerticalLogos/" + hdnDomain.Value + "logo.png";
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='800px' height='500px' class='inputgrid'>");
                strhtml.Append("<tr><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
                strhtml.Append("<tr><td><img src='" + logo + "'/></td></tr>");
                strhtml.Append("</table>");
                strhtml.Append("</td></tr>");
                strhtml.Append("<tr><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='800px' height='500px' bgcolor='#F0F7EC'>");
                strhtml.Append("<tr><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='inputgrid'>");
                strhtml.Append("<tr bgcolor='#3B86D4'><td><b>" + domain + " Invoice ID: " + invoiceID + "</b></td><td align='right'>");
                if (txtPurchaseOrder.Text.Trim() != "")
                {
                    strhtml.Append("Purchase Order No: " + txtPurchaseOrder.Text.Trim() + "</b>");
                }
                strhtml.Append("</td></tr>");
                strhtml.Append("</table>");
                strhtml.Append("</td></tr>");
                strhtml.Append("<tr><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
                strhtml.Append("<tr><td align='top'>" + "To:" + address + "</td></tr>");
                strhtml.Append("</table>");
                strhtml.Append("</td></tr>");
                strhtml.Append("<tr bgcolor='#F0F7EC'><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='inputgrid'>");
                strhtml.Append("<colgroup><col width='180px'/><col width='100px'/><col width='100px'/><col width='100px'/><col width='100px'/><col width='100px'/><col width='*'/></colgroup>");
                strhtml.Append("<tr bgcolor='#3B86D4'>" + "<td>Description</td>" + "<td>Invoice Date</td>" + "<td></td>" + "<td></td>" + "<td align='right'>Amount</td>" + "<td></td><td></td></tr>");

                strhtml.Append("<tr bgcolor='#F0F7EC'>" + "<td>" + subtype + "</td>" + "<td>" + DateTime.Today.ToShortDateString() + "</td>" + "<td></td>" + "<td></td>" + "<td align='right'></td><td></td><td></td></tr>");
                if (lblCheckDiscount.Text != "0.00")
                {
                    strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td></td>" + "<td>Subscription Amount</td><td bgcolor='#F0F7EC' align='right'>" + "&nbsp;$" + lblCheckSubAmount.Text + "</td><td></td></tr>");
                    strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td></td>" + "<td>Discount</td><td bgcolor='#F0F7EC' align='right'>" + "&nbsp;$" + lblCheckDiscount.Text + "</td><td></td></tr>");
                }
                strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td></td>" + "<td></td><td bgcolor='#F0F7EC' align='right'>" + "&nbsp;$" + lblCheckAmt.Text + "</td><td></td></tr>");
                string totalAmount = lblCheckAmt.Text;
                if (oneTimeSetupFee != null)
                {
                    totalAmount = (Convert.ToDecimal(lblCheckAmt.Text) + oneTimeSetupFee).ToString();
                    strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td></td>" + "<td>One time setup fee</td><td bgcolor='#F0F7EC' align='right'>" + "&nbsp;$" + oneTimeSetupFee + "</td><td></td></tr>");
                }
                strhtml.Append("<tr bgcolor='#3B86D4'><td></td><td></td><td></td><td>Total Amount</td>" + "<td></td><td align='right'>" + "&nbsp;$" + totalAmount + "</td><td></td></tr>");
                strhtml.Append("</table>");
                strhtml.Append("</td></tr>");
                strhtml.Append("</td></tr>");
                strhtml.Append("</table>");
                strhtml.Append("</table>");
                strhtml.Append("NOTE: If you have any questions regarding this invoice, please email " + emailSupport);
                strhtml.Append("</body>");
                strhtml.Append("</html>");


                string filepath = Server.MapPath("~");

                string filename = filepath + "/temp/" + domain + "_Invoice_" + invoiceID + ".html";

                string hmtlfileurl = ConfigurationManager.AppSettings.Get("RootPath") + "/temp/" + domain + "_Invoice_" + invoiceID + ".html";

                string pdffilename = filepath + "/temp/" + domain + "_Invoice_" + invoiceID + ".pdf";

                string pdfilenameval = domain + "_Invoice_" + invoiceID + ".pdf";

                string pdffileurl = ConfigurationManager.AppSettings.Get("RootPath") + "/temp/" + domain + "_Invoice_" + invoiceID + ".pdf";

                //***StreamWriter textwriter = new StreamWriter(filename);
                //***textwriter.Write(strhtml);
                //***textwriter.Close();

                //Convert into the PDF ...


                /*
                //set the license key
                //issue 264, 266
                LicensingManager.LicenseKey = ConfigurationManager.AppSettings.Get("pdfkeyval");

                //create a PDF document
                Document document = new Document();

                //optional settings for the PDF document like margins, compression level,
                //security options, viewer preferences, document information, etc
                document.CompressionLevel = CompressionLevel.NormalCompression;
                document.Margins = new Margins(10, 10, 0, 0);
                document.Security.CanPrint = true;
                document.Security.UserPassword = "";
                document.DocumentInformation.Author = "Logictree IT Solutions, Inc";
                document.ViewerPreferences.HideToolbar = false;


                //Add a first page to the document. The next pages will inherit the settings from this page 
                PdfPage page = document.Pages.AddNewPage(PageSize.A4, new Margins(10, 10, 0, 0), PageOrientation.Portrait);

                // the code below can be used to create a page with default settings A4, document margins inherited, portrait orientation

                //PdfPage page = document.Pages.AddNewPage();

                // add a font to the document that can be used for the texts elements 

                PdfFont font = document.Fonts.Add(new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 10, System.Drawing.GraphicsUnit.Point));

                // the result of adding an element to a PDF page

                AddElementResult addResult;

                // Get the specified location and size of the rendered content

                // A negative value for width and height means to auto determine

                // The auto determined width is the available width in the PDF page

                // and the auto determined height is the height necessary to render all the content

                float xLocation = 5;

                float yLocation = 5;

                float width = -1;

                float height = -1;

                // convert HTML to PDF

                HtmlToPdfElement htmlToPdfElement;

                // convert a URL to PDF

                //string urlToConvert = hmtlfileurl;

                //htmlToPdfElement = new HtmlToPdfElement((xLocation, yLocation, width, height, urlToConvert);

                htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, width, height, strhtml.ToString(), null);

                // add theHTML to PDF converter element to page
                addResult = page.AddElement(htmlToPdfElement);
                string savelocation = Server.MapPath("~").ToString() + "\\temp\\" + pdfilenameval;
                document.Save(savelocation);
                */

                string savelocation = Server.MapPath("~").ToString() + "\\temp\\" + pdfilenameval;
                objCommonBll.HtmlToPDF_Print(strhtml.ToString(), pdfilenameval, savelocation, false);


                string contactname = dtVerifyDetails.Rows[0]["Contact_Person"].ToString();
                if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["LastName"].ToString()))
                    contactname = contactname + " " + dtVerifyDetails.Rows[0]["LastName"].ToString();
                SendInvoiceEmail(txtEmail.Text, savelocation, contactname);
                // End of the Logic
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "GenerateInvoice", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void SendInvoiceDetails(int inquiryID, string cardNumber, string SubscAmount, string discount, string amount, string firstname, string lastname, string address1, string state, string zipCode, int orderID, decimal? oneTimeSetupFee, decimal totalAmt)
        {
            try
            {
                string address = "";
                string billingaddress = "";
                decimal dueAmt = 0.00M;
                decimal oneTimeSetupAmt = 0.00M;
                if (oneTimeSetupFee != null)
                    oneTimeSetupAmt = Convert.ToDecimal(oneTimeSetupFee);
                dueAmt = totalAmt - (Convert.ToDecimal(amount) + Convert.ToDecimal(discount) + oneTimeSetupAmt);
                DataTable dtVerifyDetails = objAgencyBll.GetVerifyDetailsById(inquiryID);
                if (dtVerifyDetails.Rows.Count == 1)
                {
                    address = "<BR><b>" + dtVerifyDetails.Rows[0]["Agency_Name"].ToString() + "</b><BR>" + dtVerifyDetails.Rows[0]["Contact_Person"].ToString() + "<BR>" + dtVerifyDetails.Rows[0]["Address"].ToString() + "<BR>" + dtVerifyDetails.Rows[0]["City"].ToString() + "<BR>" + dtVerifyDetails.Rows[0]["State"].ToString() + "<BR>" + dtVerifyDetails.Rows[0]["Zipcode"].ToString();
                }
                string emailSupport = "";
                DataTable dtConfigs = objCommonBll.GetVerticalConfigsByType(hdnDomain.Value, "EmailAccounts");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "EmailSupport")
                            emailSupport = row[1].ToString();
                    }
                }
                string domain = objCommonBll.GetVerticalDomain(hdnVertical.Value);
                cardNumber = (cardNumber.Length > 3) ? cardNumber.Substring(cardNumber.Length - 4, 4) : cardNumber;
                billingaddress = "<BR><b>" + firstname + " " + lastname + "</b><BR>Card No: XXXXXXXXXX" + cardNumber + "<BR>" + address1 + "<BR>" + state + "<BR>" + zipCode;
                StringBuilder strhtml = new StringBuilder();
                string subtype = string.Empty;

                subtype = "Annual Subscription for Sub-App";
                if (ddlSubscriptions.SelectedItem.Text.ToLower().Contains("branded"))
                    subtype = "Annual Subscription for Branded App";
                strhtml.Append("<html><head>");
                strhtml.Append("<link href=" + Server.MapPath("~").ToString() + "\\css\\wowzzy_general.css rel='stylesheet' type='text/css' />");
                strhtml.Append("</head><body >");
                string logo = Server.MapPath("~") + "/Images/VerticalLogos/" + hdnDomain.Value + "logo.png";
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='800px' height='500px' class='inputgrid'>");
                strhtml.Append("<tr><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
                strhtml.Append("<tr><td><img src='" + logo + "'/></td></tr>");
                strhtml.Append("</table>");
                strhtml.Append("</td></tr>");
                strhtml.Append("<tr><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='800px' height='500px' bgcolor='#F0F7EC'>");
                strhtml.Append("<tr><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='inputgrid'>");
                strhtml.Append("<tr bgcolor='#3B86D4'><td><b>" + domain + " Invoice ID: " + orderID + "</b></td><td align='right'>");
                strhtml.Append("</td></tr>");
                strhtml.Append("</table>");
                strhtml.Append("</td></tr>");
                strhtml.Append("<tr><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%'>");
                strhtml.Append("<tr><td width='50%'>" + "Agency Address:" + address + "</td><td width='50%'>" + "Billing Address:" + billingaddress + "</td></tr>");
                strhtml.Append("</table>");
                strhtml.Append("</td></tr>");
                strhtml.Append("<tr bgcolor='#F0F7EC'><td>");
                strhtml.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='inputgrid'>");
                strhtml.Append("<colgroup><col width='180px'/><col width='100px'/><col width='100px'/><col width='100px'/><col width='100px'/><col width='100px'/><col width='*'/></colgroup>");
                strhtml.Append("<tr bgcolor='#3B86D4'>" + "<td>Description</td>" + "<td>Invoice Date</td>" + "<td></td>" + "<td></td>" + "<td align='right'>Amount</td>" + "<td></td><td></td></tr>");

                strhtml.Append("<tr bgcolor='#F0F7EC'>" + "<td>" + subtype + "</td>" + "<td>" + DateTime.Today.ToShortDateString() + "</td>" + "<td></td>" + "<td></td>" + "<td align='right'></td><td></td><td></td></tr>");
                if (discount != "0.00")
                {
                    strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td></td><td>Subscription Amount</td><td align='right'>" + "&nbsp;$" + SubscAmount + "</td><td></td></tr>");
                    strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td></td><td>Discount</td><td align='right'>" + "&nbsp;$" + discount + "</td><td></td></tr>");
                }
                strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td></td><td></td><td bgcolor='#F0F7EC' align='right'>" + "&nbsp;$" + amount + "</td><td></td></tr>");
                string totalAmount = amount;
                if (oneTimeSetupFee != null)
                {
                    totalAmount = (Convert.ToDecimal(totalAmount) + oneTimeSetupFee).ToString();
                    strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td></td>" + "<td>One time setup fee</td><td bgcolor='#F0F7EC' align='right'>" + "&nbsp;$" + oneTimeSetupFee + "</td><td></td></tr>");
                }
                strhtml.Append("<tr bgcolor='#3B86D4'><td></td><td></td><td></td><td></td><td>Total Amount</td><td align='right'>" + "&nbsp;$" + totalAmount + "</td><td></td></tr>");
                strhtml.Append("<tr bgcolor='#F0F7EC'><td></td><td></td><td></td><td></td><td>Balance Due</td><td align='right'>" + "&nbsp;$" + dueAmt + "</td><td></td></tr>");
                strhtml.Append("</table>");
                strhtml.Append("</td></tr>");
                strhtml.Append("</td></tr>");
                strhtml.Append("</table>");
                strhtml.Append("</table>");
                strhtml.Append("NOTE: If you have any questions regarding this invoice, please email " + emailSupport);
                strhtml.Append("</body>");
                strhtml.Append("</html>");


                string filepath = Server.MapPath("~");

                string filename = filepath + "/temp/" + domain + "_Invoice_" + orderID + ".html";

                string hmtlfileurl = ConfigurationManager.AppSettings.Get("RootPath") + "/temp/" + domain + "_Invoice_" + orderID + ".html";

                string pdffilename = filepath + "/temp/" + domain + "_Invoice_" + orderID + ".pdf";

                string pdfilenameval = domain + "_Invoice_" + orderID + ".pdf";

                string pdffileurl = ConfigurationManager.AppSettings.Get("RootPath") + "/temp/" + domain + "_Invoice_" + orderID + ".pdf";

                //***StreamWriter textwriter = new StreamWriter(filename);
                //***textwriter.Write(strhtml);
                //***textwriter.Close();

                //Convert into the PDF ...

                /*
                //set the license key
                //issue 264, 266
                LicensingManager.LicenseKey = ConfigurationManager.AppSettings.Get("pdfkeyval");

                //create a PDF document
                Document document = new Document();

                //optional settings for the PDF document like margins, compression level,
                //security options, viewer preferences, document information, etc
                document.CompressionLevel = CompressionLevel.NormalCompression;
                document.Margins = new Margins(10, 10, 0, 0);
                document.Security.CanPrint = true;
                document.Security.UserPassword = "";
                document.DocumentInformation.Author = "Logictree IT Solutions, Inc";
                document.ViewerPreferences.HideToolbar = false;


                //Add a first page to the document. The next pages will inherit the settings from this page 
                PdfPage page = document.Pages.AddNewPage(PageSize.A4, new Margins(10, 10, 0, 0), PageOrientation.Portrait);

                // the code below can be used to create a page with default settings A4, document margins inherited, portrait orientation

                //PdfPage page = document.Pages.AddNewPage();

                // add a font to the document that can be used for the texts elements 

                PdfFont font = document.Fonts.Add(new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 10, System.Drawing.GraphicsUnit.Point));

                // the result of adding an element to a PDF page

                AddElementResult addResult;

                // Get the specified location and size of the rendered content

                // A negative value for width and height means to auto determine

                // The auto determined width is the available width in the PDF page

                // and the auto determined height is the height necessary to render all the content

                float xLocation = 5;

                float yLocation = 5;

                float width = -1;

                float height = -1;

                // convert HTML to PDF

                HtmlToPdfElement htmlToPdfElement;

                // convert a URL to PDF

                //string urlToConvert = hmtlfileurl;

                //htmlToPdfElement = new HtmlToPdfElement((xLocation, yLocation, width, height, urlToConvert);

                htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, width, height, strhtml.ToString(), null);

                // add theHTML to PDF converter element to page
                addResult = page.AddElement(htmlToPdfElement);
                string savelocation = Server.MapPath("~").ToString() + "\\temp\\" + pdfilenameval;
                document.Save(savelocation);
                 */

                string savelocation = Server.MapPath("~").ToString() + "\\temp\\" + pdfilenameval;
                objCommonBll.HtmlToPDF_Print(strhtml.ToString(), pdfilenameval, savelocation, false);

                SendPaymentEmail(savelocation);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "SendInvoiceDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void UpdatePackage(int inquiryID)
        {
            try
            {
                objAdminBll.AddSubscriptionPackage(inquiryID, GetSubscriptionPackage());
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "UpdatePackage", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void SendActivationEmail(string username, string password)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            try
            {
                string rootPath = "";
                DataTable dtConfigs = objCommonBll.GetVerticalConfigsByType(hdnDomain.Value, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            rootPath = row[1].ToString();
                    }
                }
                string FromEmailsupport = "";
                DataTable dtConfigsemails = objCommonBll.GetVerticalConfigsByType(hdnDomain.Value, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                            FromEmailsupport = row[1].ToString();
                    }
                }
                string strfilepath = Server.MapPath("~") + "\\EmailContent" + hdnDomain.Value + "\\";
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
                msgbody = msgbody.Replace("#RootUrl#", rootPath);
                msgbody = msgbody.Replace("#msgBody#", content);
                msgbody = msgbody.Replace("#Link#", "<a href='" + rootPath + "/OP/" + hdnDomain.Value + "/Login.aspx' target='_blank'>Login</a>");
                msgbody = msgbody.Replace("#Email#", username);
                msgbody = msgbody.Replace("#Password#", password);
                re.Close();
                re.Dispose();
                reDeclaimer.Close();
                reDeclaimer.Dispose();
                string ccemail = string.Empty;
                UtilitiesBLL utlobj = new UtilitiesBLL();
                string val = utlobj.SendWowzzyEmail(FromEmailsupport, username, "Account Details", msgbody, ccemail, "", hdnDomain.Value);
                objInBuiltData.ErrorHandling("ERROR", "enhance.aspx", "lnkActivate", val, "", "", "");
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "enhance.aspx", "lnkActivate", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void SendInvoiceEmail(string username, string attachment, string contactPerson)
        {
            try
            {
                string rootPath = "";
                DataTable dtConfigs = objCommonBll.GetVerticalConfigsByType(hdnDomain.Value, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            rootPath = row[1].ToString();
                    }
                }
                string FromEmailsupport = "";
                DataTable dtConfigsemails = objCommonBll.GetVerticalConfigsByType(hdnDomain.Value, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                            FromEmailsupport = row[1].ToString();
                    }
                }
                string strfilepath = Server.MapPath("~") + "\\EmailContent" + hdnDomain.Value + "\\";
                StreamReader re = File.OpenText(strfilepath + "CreateInvoice.txt");
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
                re.Close();
                re.Dispose();
                string ccemail = string.Empty;

                utlobj.SendWowzzyEmailWithAttachments(FromEmailsupport, username, "Agency Account Details", msgbody, ccemail, attachment, hdnDomain.Value);
                reDeclaimer = File.OpenText(strfilepath + "IncoiveAccounts.txt");
                string toEmails = string.Empty;
                while ((desclaimer = reDeclaimer.ReadLine()) != null)
                {
                    toEmails = toEmails + desclaimer;
                }
                reDeclaimer.Close();
                reDeclaimer.Dispose();
                utlobj.SendWowzzyEmailWithAttachments(FromEmailsupport, toEmails, "Agency Account Details", msgbody, ccemail, attachment, hdnDomain.Value);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "SendInvoiceEmail", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void SendPaymentEmail(string attachment)
        {
            try
            {
                CommonBLL objCommon = new CommonBLL();
                string strfilepath = Server.MapPath("~") + "\\EmailContent" + hdnDomain.Value + "\\";
                StreamReader re = File.OpenText(strfilepath + "Payment.txt");
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
                string vertRootPath = "";
                DataTable dtConfigs = objCommon.GetVerticalConfigsByType(hdnDomain.Value, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            vertRootPath = row[1].ToString();
                    }
                }
                string FromEmailsupport = "";
                DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(hdnDomain.Value, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                            FromEmailsupport = row[1].ToString();
                    }
                }
                msgbody = msgbody.Replace("#RootUrl#", vertRootPath);
                msgbody = msgbody.Replace("#msgBody#", content);
                re.Close();
                re.Dispose();
                reDeclaimer = File.OpenText(strfilepath + "IncoiveAccounts.txt");
                DataTable dtoptionalDetails = objAgencyBll.GetVerifyDetailsById(InquiryId);
                string username = dtoptionalDetails.Rows[0]["Email_Address"].ToString();
                string toEmails = string.Empty;
                while ((desclaimer = reDeclaimer.ReadLine()) != null)
                {
                    toEmails = toEmails + desclaimer;
                }
                reDeclaimer.Close();
                reDeclaimer.Dispose();
                utlobj.SendWowzzyEmailWithAttachments(FromEmailsupport, username, "Payment Details", msgbody, toEmails, attachment, hdnDomain.Value);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "SendPaymentEmail", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private string GetSubscriptionValues(string item)
        {
            switch (item)
            {
                case "Premium Plus - $74":
                    return "74.00";
                case "Premium Plus With Branded App - $99":
                    return "99.00";
                default:
                    return "";
            }
        }

        protected void ImgclseClick(object sender, EventArgs e)
        {
            try
            {
                hdnNotesCnt.Value = Convert.ToString(objAdminBll.GetNotesCountById(InquiryId));
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
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "ImgclseClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnValidatePromo_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPromo = objAdminBll.ValidatePromoCode(txtPromoCode.Text.Trim(), InquiryId, false);
                if (txtPromoCode.Text.Trim() != "")
                {
                    if (dtPromo.Rows[0]["Valid"].ToString() == "0")
                        lblError.Text = Resources.AdminResource.InvalidPromoode;
                    else
                        hdnPCPercent.Value = dtPromo.Rows[0]["Percentage"].ToString();
                }
                else
                    hdnPCPercent.Value = "";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "Enhance.aspx.cs", "btnValidatePromo_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}