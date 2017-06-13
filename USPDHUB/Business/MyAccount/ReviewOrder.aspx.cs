using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using USPDHUBDAL;
using AnetApi.Schema;

namespace USPDHUB.Business.MyAccount
{
    public partial class ReviewOrder : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int CUserID = 0;
        BusinessBLL objBus = new BusinessBLL();
        AgencyBLL objAgency = new AgencyBLL();
        public bool IsSubApp = false;
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public bool IsBrandedApp = false;
        public int RequestType = 1;
        BusinessDAL.BillingInfo objBillingInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
                if (Request.QueryString["Type"] == null || Request.QueryString["Type"].ToString().Trim() == "" || Session["BillingInfo"] == null)
                    Response.Redirect("CheckStore.aspx");
                else
                    RequestType = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["Type"].ToString()));

                if (!IsPostBack)
                {
                    DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                    if (dtProfile.Rows.Count > 0)
                        hdnVertical.Value = dtProfile.Rows[0]["Vertical_Name"].ToString();
                    objBillingInfo = (BusinessDAL.BillingInfo)Session["BillingInfo"];
                    lblPlaceTotal.Text = (Convert.ToDecimal(objBillingInfo.Total) - Convert.ToDecimal(objBillingInfo.Discount)).ToString();
                    lblPlaceDiscount.Text = objBillingInfo.Discount;
                    string billinginfo = "";
                    billinginfo = objBillingInfo.FirtstName;
                    billinginfo = billinginfo + " " + objBillingInfo.LastName;
                    billinginfo = billinginfo + "<br/>" + objBillingInfo.Address1;
                    billinginfo = billinginfo + ", " + objBillingInfo.Address2;
                    billinginfo = billinginfo + "<br/>" + objBillingInfo.City;
                    billinginfo = billinginfo + ", " + objBillingInfo.State;
                    billinginfo = billinginfo + " " + objBillingInfo.Zipcode;
                    billinginfo = billinginfo + "<br/>United States";
                    lblBilling.Text = billinginfo;
                    string payInfo = "";
                    payInfo = objBillingInfo.Type;
                    string number = EncryptDecrypt.DESDecrypt(objBillingInfo.Number);
                    if (number.Length > 4)
                        payInfo = payInfo + "<br/>############" + number.Substring(number.Length - 4);
                    else
                        payInfo = payInfo + "<br/>############" + number;
                    number = "";
                    lblCheck.Text = payInfo;
                    lblValid.Text = objBillingInfo.Month + "/" + objBillingInfo.Year;
                }

                lblBillEditMsg.Text = "";
                Button btnUpdate = (Button)editBillInfo.FindControl("btnUpdate");
                btnUpdate.Click += new EventHandler(editBillInfo_btnUpdate_Click);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ReviewOrder.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        void editBillInfo_btnUpdate_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ReviewOrder.aspx.cs", "editBillInfo_btnUpdate_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
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

        protected void lnkPlaceOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string ErrorMessage = "";
                string StatusCode = "";

                objBillingInfo = (BusinessDAL.BillingInfo)Session["BillingInfo"];
                int orderID = 0;
                string reslVal = "";
                AuthorizedNet ObjAuthorized = new AuthorizedNet();
                string paymentType = objBillingInfo.OrderDescription + "Transaction";
                string AuthType = "AUTH_CAPTURE";

                // Note: before live mode ::: (XmlAPIUtilities)in this give == API Login Key 

                if (objBillingInfo.IsCard)
                {
                    reslVal = ObjAuthorized.AdvanceIntegrationForAuthorizedNet(EncryptDecrypt.DESDecrypt(objBillingInfo.Number), objBillingInfo.Month + objBillingInfo.Year,
                        lblPlaceTotal.Text, objBillingInfo.FirtstName, objBillingInfo.LastName, objBillingInfo.Address1, objBillingInfo.State, objBillingInfo.Zipcode,
                        objBillingInfo.Type, EncryptDecrypt.DESDecrypt(objBillingInfo.NumberC), AuthType);

                    if (reslVal != "1")
                    {
                        UserID = Convert.ToInt32(Session["UserID"].ToString());
                        ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());

                        var dtuserdetails = objBus.GetuserdetailsByProfileID(ProfileID);
                        DataTable dtpaymentdetails = new DataTable("dt1");

                        // Success Message:  Successful.
                        // A duplicate record with ID 23759193 already exists.
                        // Fail Mes:  ErrorMessage (this is have error text)
                        long paymentDetailsID = 0;
                        long customerSubcriptionID = ObjAuthorized.CreateCustomerProfile(Convert.ToString(dtuserdetails.Rows[0]["Username"]), "",
                            out ErrorMessage, out StatusCode);
                        if (customerSubcriptionID > 0 || ErrorMessage.Contains("already exists."))
                        {
                            if (ErrorMessage.Contains("already exists."))
                            {
                                dtpaymentdetails = objBus.GetSubcription_PaymentCardDetails(ProfileID);
                                customerSubcriptionID = Convert.ToInt64(dtpaymentdetails.Rows[0]["CustomerSubscriptionID"]);
                            }
                            string number = EncryptDecrypt.DESDecrypt(objBillingInfo.Number);
                            paymentDetailsID = ObjAuthorized.CreateCustomerPaymentProfile(customerSubcriptionID, number, (objBillingInfo.Year + "-" + objBillingInfo.Month),
                               objBillingInfo.NumberC, out ErrorMessage, out StatusCode);

                            if (paymentDetailsID > 0)
                            {
                                #region Last Four Digits of CC

                                string payInfo = "";
                                if (number.Length > 4)
                                    payInfo = EncryptDecrypt.DESEncrypt(number.Substring(number.Length - 4));
                                else
                                    payInfo = EncryptDecrypt.DESEncrypt(number);

                                #endregion
                                // Insert Billing Details & paymentID
                                objBus.Insert_CC_BillingDetails(payInfo, Convert.ToInt32(objBillingInfo.Month), Convert.ToInt32(objBillingInfo.Year),
                                    objBillingInfo.IsCard, objBillingInfo.FirtstName, objBillingInfo.LastName, objBillingInfo.Address1, objBillingInfo.Address2, objBillingInfo.City,
                                    objBillingInfo.State, "Unites States", objBillingInfo.Zipcode, paymentDetailsID, customerSubcriptionID, objBillingInfo.Type,
                                    ProfileID, objBillingInfo.SubOrderID, Convert.ToInt32(objBillingInfo.NumberC));


                            }
                            else
                            {
                                //ErrorMessage
                            }
                        }
                        else
                        {
                            //ErrorMessage
                        }

                    }
                }
                else
                {
                    // Get the profile for this customer
                    DataTable dtPaymentCardDetails = objBus.GetSubcription_PaymentCardDetails(ProfileID);
                    customerProfileMaskedType profile = ObjAuthorized.GetCustomerProfile(Convert.ToInt64(dtPaymentCardDetails.Rows[0]["CustomerSubscriptionID"]));

                    string invoiceNumber = ProfileID + "_" + DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year;
                    // Transction amount
                    bool _result = ObjAuthorized.CreateTransaction(Convert.ToInt64(dtPaymentCardDetails.Rows[0]["CustomerSubscriptionID"]),
                        Convert.ToInt64(dtPaymentCardDetails.Rows[0]["PaymentProfileID"]), Convert.ToDecimal(objBillingInfo.Total), invoiceNumber);

                    //reslVal = ObjAuthorized.CIMAuthorizedNet();
                }
                objBillingInfo.OrderID = orderID.ToString();
                Response.Redirect("ThankYou.aspx?Type=" + Request.QueryString["Type"].ToString());
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ReviewOrder.aspx.cs", "lnkPlaceOrder_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

    }
}