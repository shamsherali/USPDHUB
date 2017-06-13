using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using USPDHUBBLL;
using System.IO;

namespace USPDHUB.OP.inschoolhubcom
{
    public partial class Enhance : System.Web.UI.Page
    {
        public string promoCode = "";
        public int inquiryID = 0;
        public int PromoCodeAmount = 0;

        public int TotalPackage = 0;

        public string Upgrading = string.Empty;
        string PricePlan = string.Empty;
        public string RightContentVisible = string.Empty;
        public string EmailContentPath = string.Empty;

        AgencyBLL agencyobj = new AgencyBLL();
        CommonBLL objCommonBll = new CommonBLL();

        public string RootPath = "";
        public string DomainName = "";
        CommonBLL objCommon = new CommonBLL();
        BusinessBLL objBusinessBLL = new BusinessBLL();

        DataTable dtPromocodeDetails = new DataTable("dtpromocode");
        AdminBLL objAdminBll = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Get Domain Name *** //
                if (Session["VerticalDomain"] == null)
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    objCommon.CreateDomainUrl(url);
                }
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                if (!IsPostBack)
                {
                    if (Request.QueryString["InqID"] != null)
                    {
                        hdnInquiryID.Value = EncryptDecrypt.DESDecrypt(Request.QueryString["InqID"].ToString());
                        inquiryID = Convert.ToInt32(hdnInquiryID.Value);
                    }
                    if (Request.QueryString["PC"] != null)
                    {
                        hdnPromocode.Value = EncryptDecrypt.DESDecrypt(Request.QueryString["PC"].ToString());
                    }
                    GetPaymentDetails();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void PayButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(hdnInquiryID.Value) != string.Empty)
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
                string totalAmount = lblsubscr1.Text;
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
                if (hdnIsSubAccount.Value == "")
                    oneTimesetupfee = Convert.ToDecimal(lblOneTimeFee.Text);
                decimal discountAmount = Convert.ToDecimal(lblDiscount.Text);

                if (Convert.ToString(hdnPromocode.Value) != string.Empty)
                {
                    promoCode = Convert.ToString(hdnPromocode.Value);
                }

                int InquiryId = Convert.ToInt32(hdnInquiryID.Value);
                hdnPlanPeriod.Value = "12";
                bool isCard = true;
                int adminUserID = 0;

                int orderID = objAdminBll.AddInquiryTransactions(InquiryId, Convert.ToInt32(hdnPlanPeriod.Value), Convert.ToDecimal(totalAmount), discountAmount,
                    billableAmount, Address1, Address2, City, State, ZipCode, EncryptDecrypt.DESEncrypt(CardNumber),
                    Firstname, Lastname, ExpMonth, ExpYear, EncryptDecrypt.DESEncrypt(Cvvnumber), CardTye, Country, adminUserID, isCard, "", false, promoCode, "", chkRcurring.Checked, oneTimesetupfee);

                AuthorizedNet ObjAuthorized = new AuthorizedNet();
                ResVal = ObjAuthorized.AdvanceIntegrationForAuthorizedNet(CardNumber, CardExpDate, Amount, Firstname, Lastname, Address1, State, ZipCode, PaymentType, Cvvnumber, AuthType);
               
                if (ResVal == "1")
                {
                    if (orderID > 0)
                        objAdminBll.UpdateInquiryTransaction(orderID, InquiryId, 0);
                    UpdatePackage(InquiryId);
                    string password = objCommonBll.GenerateRandomPassword();

                    AgencyBLL objAgencyBLL = new AgencyBLL();
                    DataTable dtInquiryDetails = objAgencyBLL.GetAgencydetailsByAgencyID(InquiryId);

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

                        int profileId = agencyobj.InsertUserDetails(latitude1, longitude1, EncryptDecrypt.DESEncrypt(password), InquiryId);
                        DataTable dtuserdetails = objBusinessBLL.GetuserdetailsByProfileID(profileId);

                        if (dtuserdetails.Rows.Count > 0)
                        {
                            string username = dtuserdetails.Rows[0]["Username"].ToString();
                            Session["UName"] = username;
                        }
                        string location = objCommon.GenerateInvoice(profileId, "inschoolhub", DomainName);
                        SendActivationEmail(Convert.ToString(Session["EmailID"]), password, location, DomainName);
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
                        Response.Redirect(secureRootPath + "/OP/" + Session["VerticalDomain"] + "/OrderCompleted.aspx?PID=" + EncryptDecrypt.DESEncrypt(profileId.ToString()));
                    }
                    ClearControls();
                }
                else
                {
                    lblErroMessage.Text = "Credit card details are invalid.";
                }

            }
        }
        private void UpdatePackage(int inquiryID)
        {
            objAdminBll.AddSubscriptionPackage(inquiryID, "Premium Plus");
        }
        protected void btncancelcreditcard_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(hdnInquiryID.Value) != string.Empty)
            {
                agencyobj.DeleteSelectedListing(Convert.ToInt32(hdnInquiryID.Value));
            }
            Response.Redirect(RootPath + "/OP/" + Session["VerticalDomain"] + "/Default.aspx");
        }

        private void GetPaymentDetails()
        {
            string PromoCode = string.Empty;
            decimal Discount = 0.00M;
            decimal PaymentAmount = 0.00M;
            decimal oneTimeSetupFee = 0.00M;
            pnlOneTimeSetup.Visible = false;
            hdnPlan.Value = PricePlan;
            PaymentAmount = Convert.ToInt32(ConfigurationManager.AppSettings.Get("InSchoolHubYearPackage"));
            DataTable dtInquiry = agencyobj.GetVerifyDetailsById(Convert.ToInt32(hdnInquiryID.Value));
            if (!string.IsNullOrEmpty(dtInquiry.Rows[0]["Parent_ProfileID"].ToString()))
            {
                PaymentAmount = Convert.ToInt32(ConfigurationManager.AppSettings.Get("InSchoolHubYearPackageSub"));
                hdnIsSubAccount.Value = "1";
            }
            else
            {
                pnlOneTimeSetup.Visible = true;
                oneTimeSetupFee = Convert.ToDecimal(lblOneTimeFee.Text);
            }
            if (hdnPromocode.Value != "")
            {
                dtPromocodeDetails = agencyobj.GetPromocodeDetails(hdnPromocode.Value);
                if (dtPromocodeDetails.Rows.Count > 0)
                {
                    int discountPercentage = Convert.ToInt32(dtPromocodeDetails.Rows[0]["Promocode_Value"]);
                    Discount = Math.Round((PaymentAmount * discountPercentage) / 100, 2);
                }
            }
            lblsubscr1.Text = PaymentAmount.ToString("0.00");
            lblDiscount.Text = Discount.ToString("0.00");
            decimal totalbillAmount = PaymentAmount - Discount;
            lblSubTotal.Text = totalbillAmount.ToString();
            lblsubscAmount.Text = (oneTimeSetupFee + totalbillAmount).ToString();
        }

        private void ClearControls()
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
            lblPromoerror.Text = "";
        }

        public string Packages(int value)
        {
            string PkgName = "";
            switch (value)
            {
                case 1:
                    PkgName = "Basic";
                    break;
                case 2:
                    PkgName = "Plus";
                    break;
                case 3:
                    PkgName = "Pro";
                    break;
                case 4:
                    PkgName = "Premium";
                    break;
                case 5:
                    PkgName = "Premium Plus";
                    break;
            }
            return PkgName;
        }

        private void SendActivationEmail(string username, string password, string location, string verticalValue)
        {

            CommonBLL objCommon = new CommonBLL();
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
            msgbody = msgbody.Replace("#RootUrl#", RootPath);
            msgbody = msgbody.Replace("#msgBody#", content);
            msgbody = msgbody.Replace("#Link#", "<a href='" + RootPath + "/OP/" + verticalValue + "/Login.aspx' target='_blank'>Login</a>");
            msgbody = msgbody.Replace("#Email#", username);
            msgbody = msgbody.Replace("#Password#", password);
            re.Close();
            re.Dispose();
            reDeclaimer = File.OpenText(strfilepath + "IncoiveAccounts.txt");
            string ccemail = string.Empty;
            while ((desclaimer = reDeclaimer.ReadLine()) != null)
            {
                ccemail = ccemail + desclaimer;
            }
            reDeclaimer.Close();
            reDeclaimer.Dispose();
            UtilitiesBLL utlobj = new UtilitiesBLL();
            if (string.IsNullOrEmpty(location))
                utlobj.SendWowzzyEmail(FromEmailsupport, username, "Account Details", msgbody, ccemail, "", verticalValue);
            else
                utlobj.SendWowzzyEmailWithAttachments(FromEmailsupport, username, "Account Details", msgbody, ccemail, location, verticalValue);

        }
    }
}