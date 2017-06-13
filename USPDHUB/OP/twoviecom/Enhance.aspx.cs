using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.IO;

namespace USPDHUB.OP.twoviecom
{
    public partial class Enhance : System.Web.UI.Page
    {
        CommonBLL objCommon = new CommonBLL();
        AgencyBLL objAgency = new AgencyBLL();
        BusinessBLL objBus = new BusinessBLL();
        AdminBLL objAdmin = new AdminBLL();
        public string RootPath = "";
        public string DomainName = "";
        public int InquiryId = 0;
        public int promoPercent = 0;
        public string vertical = "twovie";
        public string PromoCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // *** Get Domain Name *** //
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            if (Request.QueryString["pcp"] != null)
            {
                promoPercent = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["pcp"].ToString()));
            }
            if (Request.QueryString["cd"] != null)
            {
                PromoCode = EncryptDecrypt.DESDecrypt(Request.QueryString["cd"].ToString());
            }
            if (Request.QueryString["iq"] != null)
            {
                InquiryId = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["iq"].ToString()));
            }
            else
                Response.Redirect("/default.aspx");
            if (!IsPostBack)
            {
                DataTable dtInquiry = objAgency.GetVerifyDetailsById(InquiryId);
                if (!string.IsNullOrEmpty(dtInquiry.Rows[0]["Parent_ProfileID"].ToString()))
                {
                    hdnIsSubAccount.Value = "1";
                    //rbYear.Checked = true;
                    //rbMonth.Checked = false;
                }                
                GetPaymentDetails();
            }

        }
        protected void Subscription_CheckedChanged(object sender, EventArgs e)
        {
            ClearData();
            GetPaymentDetails();
        }
        private void GetPaymentDetails()
        {
            hdnPlanPeriod.Value = "12"; // for 1 month
            decimal discount = 0.00M;
            decimal oneTimeSetupFee = 0.00M;
            pnlOneTimeSetup.Visible = false;
            decimal paymentAmount = 0.00M;
            if (hdnIsSubAccount.Value == "")
            {
                if (rbMonthNonBrand.Checked)
                {
                    hdnPlanPeriod.Value = "1"; // for 1 month  
                    paymentAmount = Convert.ToDecimal(ConfigurationManager.AppSettings["twoviepkg"]);
                }
                else if (rbAnnualNonBrand.Checked)
                    paymentAmount = Convert.ToDecimal(ConfigurationManager.AppSettings["twoviepkgAnnual"]);
                else
                {
                    pnlOneTimeSetup.Visible = true;
                    oneTimeSetupFee = Convert.ToDecimal(lblOneTimeFee.Text);
                    paymentAmount = Convert.ToDecimal(ConfigurationManager.AppSettings["twoviepkgBranded"]);
                }
            }
            else
                paymentAmount = Convert.ToDecimal(ConfigurationManager.AppSettings["twoviepkgSub"]);
            discount = Math.Round((paymentAmount * promoPercent) / 100, 0, MidpointRounding.AwayFromZero);
            lblsubscr1.Text = paymentAmount.ToString("0.00");
            lblDiscount.Text = discount.ToString("0.00");
            decimal totalbillAmount = paymentAmount - discount;
            lblSubTotal.Text = totalbillAmount.ToString("0.00");
            lblsubscAmount.Text = (oneTimeSetupFee + totalbillAmount).ToString();
        }
        protected void RbMonthCheckedChanged(object sender, EventArgs e)
        {
            ClearData();
            GetPaymentDetails();
        }
        private void ClearData()
        {
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
            DrpState.SelectedIndex = -1;
        }
        protected void PayButton_Click(object sender, EventArgs e)
        {
            string Firstname = string.Empty;
            string Lastname = string.Empty;
            string Address1 = string.Empty;
            string Address2 = string.Empty;
            string City = string.Empty;
            string State = string.Empty;
            string ZipCode = string.Empty;
            string Country = string.Empty;
            string CardTye = ddlCardType.SelectedValue;
            string CardNumber = string.Empty;
            string Cvvnumber = string.Empty;
            int ExpMonth = 0;
            int ExpYear = 0;
            string CVVNO = string.Empty;
            string Amount = string.Empty;
            string PaymentType = string.Empty;
            string CardExpDate = string.Empty;
            Firstname = txtfirstName.Text;
            Lastname = txtlastname.Text;
            Address1 = txtaddress1.Text;
            Address2 = txtaddress2.Text;
            City = txtcity.Text;
            State = DrpState.SelectedValue;
            ZipCode = txtzip.Text;
            Country = "United States";
            CardNumber = txtcreditCardNumber.Text;
            ExpMonth = Convert.ToInt32(txtexpmonth.Text);
            ExpYear = Convert.ToInt32(txtexpyear.Text);
            string AuthType = "AUTH_CAPTURE";
            decimal totalAmount = Convert.ToDecimal(lblsubscr1.Text);
            decimal billableAmount = Convert.ToDecimal(lblSubTotal.Text);
            Amount = lblsubscAmount.Text;
            Cvvnumber = txtcvv2Number.Text.Trim();
            CardExpDate = ExpMonth.ToString() + ExpYear.ToString();
            PaymentType = "Registration Transaction";
            string ResVal = string.Empty;
            if (Amount == "0.00" || Amount == "0")
            {
                AuthType = "AUTH_ONLY";
                Amount = "1";
            }
            decimal? oneTimesetupfee = null;
            if (rbAnnualBrand.Checked && hdnIsSubAccount.Value == "")
                oneTimesetupfee = Convert.ToDecimal(lblOneTimeFee.Text);
            decimal discountAmount = Convert.ToDecimal(lblDiscount.Text);
            bool isCard = true;
            int adminUserID = 0;

            int orderID = objAdmin.AddInquiryTransactions(InquiryId, Convert.ToInt32(hdnPlanPeriod.Value), totalAmount, discountAmount,
                billableAmount, Address1, Address2, City, State, ZipCode, EncryptDecrypt.DESEncrypt(CardNumber),
                Firstname, Lastname, ExpMonth, ExpYear, EncryptDecrypt.DESEncrypt(Cvvnumber), CardTye, Country, adminUserID, isCard, "", false, PromoCode, "", chkRcurring.Checked, oneTimesetupfee);

            AuthorizedNet ObjAuthorized = new AuthorizedNet();
            ResVal = ObjAuthorized.AdvanceIntegrationForAuthorizedNet(CardNumber, CardExpDate, Amount, Firstname, Lastname, Address1, State, ZipCode, PaymentType, Cvvnumber, AuthType);

            if (ResVal == "1")
            {
                if (orderID > 0)
                    objAdmin.UpdateInquiryTransaction(orderID, InquiryId, 0);
                UpdatePackage();
                string password = objCommon.GenerateRandomPassword();

                DataTable dtInquiryDetails = objAgency.GetAgencydetailsByAgencyID(InquiryId);

                if (dtInquiryDetails.Rows.Count > 0)
                {
                    string Address = Convert.ToString(dtInquiryDetails.Rows[0]["Address"]);
                    string CityName = Convert.ToString(dtInquiryDetails.Rows[0]["City"]);
                    string zipCode = Convert.ToString(dtInquiryDetails.Rows[0]["Zipcode"]);
                    string stateName = Convert.ToString(dtInquiryDetails.Rows[0]["State"]);

                    #region Getting Latidude & longtidude values
                    string fullAddress = Address + "," + CityName + "," + stateName + "," + zipCode;
                    Coordinate coordinates = Geocode.GetCoordinates(fullAddress);

                    double latitude1 = Convert.ToDouble(coordinates.Latitude);
                    double longitude1 = Convert.ToDouble(coordinates.Longitude);

                    #endregion

                    int profileId = objAgency.InsertUserDetails(latitude1, longitude1, EncryptDecrypt.DESEncrypt(password), InquiryId);
                    DataTable dtuserdetails = objBus.GetuserdetailsByProfileID(profileId);
                    string username = "";
                    if (dtuserdetails.Rows.Count > 0)
                        username = dtuserdetails.Rows[0]["Username"].ToString();
                    if (username != "")
                    {
                        string location = objCommon.GenerateInvoice(profileId, vertical, DomainName);
                        SendActivationEmail(username, password, location, DomainName);
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
                        Response.Redirect(secureRootPath + "/OP/" + DomainName + "/OrderCompleted.aspx?PID=" + EncryptDecrypt.DESEncrypt(profileId.ToString()));
                    }
                    else
                        lblErroMessage.Text = "A problem has been occurred while making data submission. Please email us to info@twovie.com";
                }
            }
            else
            {
                lblErroMessage.Text = "Credit card details are invalid.";
            }
        }
        private void UpdatePackage()
        {
            string package = "Premium Plus";
            if (rbAnnualBrand.Checked && hdnIsSubAccount.Value == "")
                package = "Premium Plus With Branded App";
            objAdmin.AddSubscriptionPackage(InquiryId, package);
        }
        
        protected void btncancelcreditcard_Click(object sender, EventArgs e)
        {
            objAgency.DeleteSelectedListing(InquiryId);
            Response.Redirect(RootPath + "/OP/" + DomainName + "/Default.aspx");
        }
        private void SendActivationEmail(string username, string password, string location, string verticalValue)
        {

            CommonBLL objCommon = new CommonBLL();
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
            msgbody = msgbody.Replace("#RootUrl#", RootPath);
            msgbody = msgbody.Replace("#msgBody#", content);
            msgbody = msgbody.Replace("#Link#", "<a href='" + RootPath + "/OP/" + verticalValue + "/Login.aspx' target='_blank'>Login</a>");
            msgbody = msgbody.Replace("#Email#", username);
            msgbody = msgbody.Replace("#Password#", password);
            re.Close();
            reDeclaimer = File.OpenText(strfilepath + "IncoiveAccounts.txt");
            string ccemail = string.Empty;
            while ((desclaimer = reDeclaimer.ReadLine()) != null)
            {
                ccemail = ccemail + desclaimer;
            }
            re.Dispose();
            reDeclaimer.Close();
            reDeclaimer.Dispose();
            UtilitiesBLL utlobj = new UtilitiesBLL();
            if (string.IsNullOrEmpty(location))
                utlobj.SendWowzzyEmail(FromInfo, username, "Account Details", msgbody, ccemail, "", verticalValue);
            else
                utlobj.SendWowzzyEmailWithAttachments(FromInfo, username, "Account Details", msgbody, ccemail, location, verticalValue);

        }
    }
}