using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Configuration;
using USPDHUBBLL;
using USPDHUBDAL;

namespace USPDHUB.Business.MyAccount
{
    public partial class EnhanceBill : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;

        public string RootPath = "";
        public string DomainName = "";


        public int CUserID = 0;
        BusinessBLL objBus = new BusinessBLL();
        AgencyBLL objAgency = new AgencyBLL();
        public bool IsSubApp = false;
        public bool IsBrandedApp = false;
        public int RequestType = 1;

        string totalamt = "0";
        public static string vertical = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());

            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();


            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                CUserID = Convert.ToInt32(Session["C_USER_ID"]);
            else
                CUserID = UserID;
            if (Request.QueryString["Type"] == null || Request.QueryString["Type"].ToString().Trim() == "")
                Response.Redirect("CheckStore.aspx");
            else
                RequestType = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["Type"].ToString()));
            lblPromoError.Text = "";
            if (!IsPostBack)
            {
                // Get Subcription Details 
                DataTable dtSubscription = objBus.GetOrderSubscriptionByProfileID(ProfileID);

                BusinessDAL.BillingInfo objBillingInfo = new BusinessDAL.BillingInfo();
                DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                if (dtProfile.Rows.Count > 0)
                    hdnVertical.Value = dtProfile.Rows[0]["Vertical_Name"].ToString();

                if (RequestType == 3) // *** 3 means requested for branded app *** //
                {
                    totalamt = ConfigurationManager.AppSettings["OneTimeSetupFee"];
                }
                else if (RequestType == 2)// *** 3 means requested for sub accounts *** //
                {
                    if (Session["SubAppsBilling"] != null)
                    {
                        BusinessDAL.SubAppsBilling objSubAppsBilling = (BusinessDAL.SubAppsBilling)Session["SubAppsBilling"];
                        totalamt = objSubAppsBilling.SubAppsAmount.ToString();
                        objBillingInfo.SubApps = objSubAppsBilling.NumberofSubApps;
                    }
                    else
                        Response.Redirect("CheckStore.aspx");
                }
                else if (RequestType == 1) // *** 1 means requested for renewal *** //
                {
                    DomainName = "twovie";
                    // amount from web.config
                    if (DomainName.ToLower().Contains("uspdhub") || DomainName.ToLower().Contains("localhost"))
                    {
                        totalamt = ConfigurationManager.AppSettings.Get("uspdhubpkgBranded");
                    }
                    else if (DomainName.ToLower().Contains("inschoolhubcom"))
                    {
                        totalamt = ConfigurationManager.AppSettings.Get("InSchoolHubYearPackage");
                    }
                    //else if (DomainName.ToLower().Contains("inschoolhubin"))
                    //{
                    //    totalamt = ConfigurationManager.AppSettings.Get("InSchoolHubYearPackage");
                    //}
                    else if (DomainName.ToLower().Contains("twovie"))
                    {
                        //1 Month 
                        if (Convert.ToString(dtSubscription.Rows[0]["fullperiod"]) == "1" && Convert.ToString(dtSubscription.Rows[0]["Discount_Code"]) != string.Empty)
                        {
                            totalamt = ConfigurationManager.AppSettings.Get("twoviepkg");
                        }
                        else if (Convert.ToString(dtSubscription.Rows[0]["fullperiod"]) == "12" && Convert.ToString(dtSubscription.Rows[0]["Discount_Code"]) != string.Empty)
                        {
                            totalamt = ConfigurationManager.AppSettings.Get("twoviepkgAnnual");
                        }
                        else
                        {
                            pnlTwovieSucription.Visible = true;
                            GetpkgDetails();
                        }
                    }
                }

                if (!totalamt.EndsWith(".00"))
                {
                    totalamt = totalamt.ToString() + ".00";
                }
                lblTotal.Text = hdnTotal.Value = totalamt.ToString();
                GetPaymentDetails();

                if (dtSubscription.Rows.Count > 0)
                {
                    objBillingInfo.SubOrderID = Convert.ToInt32(dtSubscription.Rows[0]["Order_ID"].ToString());
                    if (!string.IsNullOrEmpty(dtSubscription.Rows[0]["CC_number"].ToString()))
                    {
                        string billinginfo = "";
                        billinginfo = objBillingInfo.FirtstName = dtSubscription.Rows[0]["cc_name"].ToString();
                        billinginfo = billinginfo + " " + dtSubscription.Rows[0]["cc_lastname"].ToString();
                        objBillingInfo.LastName = dtSubscription.Rows[0]["cc_lastname"].ToString();
                        billinginfo = billinginfo + "<br/>" + dtSubscription.Rows[0]["billing_address1"].ToString();
                        objBillingInfo.Address1 = dtSubscription.Rows[0]["billing_address1"].ToString();
                        billinginfo = billinginfo + ", " + dtSubscription.Rows[0]["billing_address2"].ToString();
                        objBillingInfo.Address2 = dtSubscription.Rows[0]["billing_address2"].ToString();
                        billinginfo = billinginfo + "<br/>" + dtSubscription.Rows[0]["billing_city"].ToString();
                        objBillingInfo.City = dtSubscription.Rows[0]["billing_city"].ToString();
                        billinginfo = billinginfo + ", " + dtSubscription.Rows[0]["billing_state"].ToString();
                        objBillingInfo.State = dtSubscription.Rows[0]["billing_state"].ToString();
                        billinginfo = billinginfo + " " + dtSubscription.Rows[0]["billing_zipcode"].ToString();
                        objBillingInfo.Zipcode = dtSubscription.Rows[0]["billing_zipcode"].ToString();
                        billinginfo = billinginfo + "<br/>United States";
                        lblBilling.Text = billinginfo;
                    }
                }
                
                Session["BillingInfo"] = objBillingInfo;
                DataTable dtCards = objBus.GetAlternateCards(ProfileID);
                if (dtCards.Rows.Count > 0)
                {
                    List<BusinessDAL.AlternateCards> objPrefCards = new List<BusinessDAL.AlternateCards>();
                    for (int i = 0; i < dtCards.Rows.Count; i++)
                    {
                        objPrefCards.Add(new BusinessDAL.AlternateCards
                        {
                            Text = dtCards.Rows[i]["Card_Type"].ToString() + " - ending with" + EncryptDecrypt.DESDecrypt(dtCards.Rows[i]["CC_Number"].ToString()),
                            Value = dtCards.Rows[i]["Alternate_ID"].ToString()
                        });
                    }
                    ddlPreferred.DataSource = objPrefCards;
                    ddlPreferred.DataTextField = "Text";
                    ddlPreferred.DataValueField = "Value";
                    ddlPreferred.DataBind();
                }
                else
                {
                    rbPreferred.Checked = false;
                    rbCard.Checked = true;
                    pnlCard.Style.Add(HtmlTextWriterStyle.Display, "block");
                }
            }
            lblBillEditMsg.Text = "";
            Button btnUpdate = (Button)editBillInfo.FindControl("btnUpdate");
            btnUpdate.Click += new EventHandler(editBillInfo_btnUpdate_Click);
        }

        protected void editBillInfo_btnUpdate_Click(object sender, EventArgs e)
        {
            TextBox txtfirstName = (TextBox)editBillInfo.FindControl("txtfirstName");
            TextBox txtlastname = (TextBox)editBillInfo.FindControl("txtlastname");
            TextBox txtaddress1 = (TextBox)editBillInfo.FindControl("txtaddress1");
            TextBox txtaddress2 = (TextBox)editBillInfo.FindControl("txtaddress2");
            TextBox txtcity = (TextBox)editBillInfo.FindControl("txtcity");
            TextBox txtzip = (TextBox)editBillInfo.FindControl("txtzip");
            DropDownList ddlState = (DropDownList)editBillInfo.FindControl("ddlState");

            string firstName = txtfirstName.Text;
            string lastName = txtlastname.Text;
            string addressOne = txtaddress1.Text;
            string addressTwo = txtaddress2.Text;
            string city = txtcity.Text;
            string state = ddlState.SelectedItem.ToString();
            string zipCode = txtzip.Text;
            int updateBillInfoStatus = objBus.Update_CC_BillingDetails(firstName, lastName, addressOne, addressTwo, city, state, zipCode, ProfileID);
            if (updateBillInfoStatus == 1)
                lblBillEditMsg.Text = "<span style='color:green;'>Your billing information has updated successfully.</span>";
            else
                lblBillEditMsg.Text = "";
        }

        public string GetPaymentDetails()
        {
            return "";
        }

        protected void lnkContinue_Click(object sender, EventArgs e)
        {
            BusinessDAL.BillingInfo objBillingInfo;
            if (Session["BillingInfo"] != null)
                objBillingInfo = (BusinessDAL.BillingInfo)Session["BillingInfo"];
            else
                objBillingInfo = new BusinessDAL.BillingInfo();
            string type = "";
            string number = "";
            string month = "";
            string year = "";
            bool isValid = true;
            string errorMsg = "";
            if (rbCard.Checked)
            {
                type = ddlCardType.SelectedValue;
                number = EncryptDecrypt.DESEncrypt(txtCard.Text.Trim());
                month = ddlMonth.SelectedValue;
                year = ddlYear.SelectedValue;
                objBillingInfo.Name = txtName.Text.Trim();
                objBillingInfo.NumberC = EncryptDecrypt.DESEncrypt(txtNumber.Text.Trim());
                objBillingInfo.IsCard = true;
                // *** Checking enter details are valid or not *** //
                string resVal = string.Empty;
                string amount = "1";
                string authType = "AUTH_ONLY";
                string cardExpDate = month + year;
                string paymentType = "Card Valid";

                AuthorizedNet ObjAuthorized = new AuthorizedNet();
                resVal = ObjAuthorized.AdvanceIntegrationForAuthorizedNet(number, cardExpDate, amount, txtName.Text.Trim(), "", "", "", "",
                    paymentType, txtNumber.Text.Trim(), authType);
                resVal = "1";
                if (resVal != "1")
                {
                    isValid = false;
                    txtCard.Text = "";
                    txtName.Text = "";
                    txtNumber.Text = "";
                    ddlCardType.SelectedIndex = 0;
                    ddlMonth.SelectedIndex = 0;
                    ddlYear.SelectedIndex = 0;
                    errorMsg = "You have entered incorrect details. Please check the details once.";
                }
            }
            else
            {
                string preferedcard = ddlPreferred.SelectedValue;
                DataTable dtPreferred = objBus.GetExistedPreferredDetails(Convert.ToInt32(preferedcard));
                if (dtPreferred.Rows.Count > 0 && (!string.IsNullOrEmpty(dtPreferred.Rows[0]["PaymentProfileID"].ToString())) && (!string.IsNullOrEmpty(dtPreferred.Rows[0]["CustomerSubscriptionID"].ToString())))
                {
                    type = dtPreferred.Rows[0]["Card_Type"].ToString();
                    number = dtPreferred.Rows[0]["CC_Number"].ToString();
                    month = dtPreferred.Rows[0]["Expiration_Month"].ToString();
                    year = dtPreferred.Rows[0]["Expiration_Year"].ToString();
                    objBillingInfo.ProfileIDC = dtPreferred.Rows[0]["PaymentProfileID"].ToString();
                    objBillingInfo.SubscriptionIDC = dtPreferred.Rows[0]["CustomerSubscriptionID"].ToString();
                }
                else
                {
                    isValid = false;
                    errorMsg = "There is information is availble for the selected preferred card.";
                }
            }
            if (isValid)
            {
                objBillingInfo.Type = type;
                objBillingInfo.Number = number;
                objBillingInfo.Month = month;
                objBillingInfo.Year = year;
                objBillingInfo.Total = hdnTotal.Value;
                objBillingInfo.Discount = lblDiscount.Text;
                string desc = "";
                if (RequestType == 3)
                    desc = "Branded App";
                else if (RequestType == 2)
                    desc = "Sub App(s)";
                else if (RequestType == 1)
                    desc = "Renewal";
                objBillingInfo.OrderDescription = desc;
                Session["BillingInfo"] = objBillingInfo;
                Response.Redirect("ReviewOrder.aspx?Type=" + Request.QueryString["Type"].ToString());
            }
            else
                lblError.Text = errorMsg;
        }

        protected void btnValidatePromo_Click(object sender, EventArgs e)
        {
            string promoCode = txtPromo.Text.Trim();
            DataTable dtPromocodeDetails = objAgency.CheckPromoCode(promoCode, hdnVertical.Value, true);
            if (dtPromocodeDetails.Rows.Count > 0)
            {
                int promoPercent = Convert.ToInt32(dtPromocodeDetails.Rows[0]["Promocode_Value"].ToString());
                decimal totalCost = Convert.ToDecimal(hdnTotal.Value);
                decimal discount = 0.00M;
                discount = Math.Round((totalCost * promoPercent) / 100, 0, MidpointRounding.AwayFromZero);
                lblTotal.Text = (totalCost - discount).ToString();
                lblDiscount.Text = discount.ToString();
                BusinessDAL.BillingInfo objBillingInfo;
                if (Session["BillingInfo"] != null)
                    objBillingInfo = (BusinessDAL.BillingInfo)Session["BillingInfo"];
                else
                    objBillingInfo = new BusinessDAL.BillingInfo();
                objBillingInfo.PromoCode = promoCode;
                Session["BillingInfo"] = objBillingInfo;
            }
            else
            {
                lblPromoError.Text = "Please enter a valid promo code.";
                txtPromo.Text = "";
            }
        }

        protected void ImcloseClick(object sender, EventArgs e)
        {
            mpeEditBillInfo.Hide();
        }
       
        protected void lnkEditBillInfo_Click(object sender, EventArgs e)
        {
            mpeEditBillInfo.Show();
        }

        //Balaji
        protected void Subscription_CheckedChanged(object sender, EventArgs e)
        {
            GetpkgDetails();
        }

        private void GetpkgDetails()
        {
            if (rbMonthNonBrand.Checked)
            {
                hdnPlanPeriod.Value = "1"; // for 1 month  
                totalamt = ConfigurationManager.AppSettings["twoviepkg"];
            }
            else if (rbAnnualNonBrand.Checked)
            {
                hdnPlanPeriod.Value = "12"; // for 12 month   annual
                totalamt = ConfigurationManager.AppSettings["twoviepkgAnnual"];
            }
            else
            {
                totalamt = ConfigurationManager.AppSettings["twoviepkgBranded"];
            }

            if (!totalamt.EndsWith(".00"))
            {
                totalamt = totalamt.ToString() + ".00";
            }
            lblTotal.Text = hdnTotal.Value = totalamt.ToString();
        }

    }
}