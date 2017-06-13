using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using USPDHUBBLL;
using System.IO;
using System.Text;
using Winnovative.PdfCreator;
using System.Data;
using USPDHUBDAL;
using System.Text.RegularExpressions;

namespace USPDHUB.Admin
{
    public partial class UpgradeChequeProcess : System.Web.UI.Page
    {
        public int PID = 0;
        public string RootPath = "";
        AdminBLL objAdminBll = new AdminBLL();
        AgencyBLL objAgencyBll = new AgencyBLL();
        CommonBLL objCommonBll = new CommonBLL();
        UtilitiesBLL utlobj = new UtilitiesBLL();
        BusinessBLL objBus = new BusinessBLL();
        string salesCode="";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["adminuserid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["PID"].ToString()))
                {
                    PID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["PID"].ToString()));
                    hdnNotesCnt.Value = Convert.ToString(objAdminBll.GetNotesCountById(PID));

                    if (!string.IsNullOrEmpty(hdnNotesCnt.Value) && hdnNotesCnt.Value != "0")
                    {
                        lnkNotes.Visible = false;
                        lnkbNotes.Visible = true;
                    }
                }
                else
                    Response.Redirect("~/Admin/CustomerServiceNew.aspx?SearchSelectedValue=" + Request.QueryString["SearchSelectedValue"] + "&SearchInputValue=" + Request.QueryString["SearchInputValue"]);

                if (!IsPostBack)
                {
                    pnlCheckPayment.Visible = false;
                    pnlcheckOneTimeFee.Visible = false;
                    DataTable dtoptionalDetails = objAgencyBll.GetUpgradeInfoByProfileID(PID);
                    if (dtoptionalDetails.Rows.Count > 0 && !string.IsNullOrEmpty(dtoptionalDetails.Rows[0]["PromoCode"].ToString()))
                    {
                        txtPromoCode.Text = dtoptionalDetails.Rows[0]["PromoCode"].ToString();
                        DataTable dtPromo = objAdminBll.ValidatePromoCode(dtoptionalDetails.Rows[0]["PromoCode"].ToString(), PID, true);
                        if (dtPromo.Rows[0]["Valid"].ToString() == "1")
                            hdnPCPercent.Value = dtPromo.Rows[0]["Percentage"].ToString();
                    }
                    DataTable dtProfileDetails = objBus.GetProfileDetailsByProfileID(PID);
                    hdnVertical.Value = dtProfileDetails.Rows[0]["Vertical_Name"].ToString();
                    hdnDomain.Value = objCommonBll.GetDomainNameByCountryVertical(dtProfileDetails.Rows[0]["Vertical_Name"].ToString(), dtProfileDetails.Rows[0]["Profile_County"].ToString());
                    LoadpkgDetails();
                    DataTable dtOrderDetails = objBus.GetOrderDetailsByProfileID_RequestType(PID, Convert.ToInt32(RequestCustomFormTypes.SubscriptionRenewal));
                    if (dtOrderDetails.Rows.Count == 0)
                    {
                        dtOrderDetails = objBus.GetOrderDetailsByProfileID_RequestType(PID, Convert.ToInt32(RequestCustomFormTypes.NewRegistration));
                    }
                    if (dtOrderDetails.Rows.Count > 0)
                    {
                        int subPeriod = Convert.ToInt32(dtOrderDetails.Rows[0]["Subscription_Period"]);
                        DateTime timeRenewal = Convert.ToDateTime(dtOrderDetails.Rows[0]["Renewal_Date"]);
                        if (timeRenewal > DateTime.Now)
                        {
                            DateTime timeStart = timeRenewal.AddMonths(-subPeriod);
                            int totalDays = (int)(timeRenewal - timeStart).TotalDays;
                            int remaingDays = (int)(timeRenewal - DateTime.Now).TotalDays;
                            if (remaingDays <= totalDays)
                            {
                                decimal paidAmount = Math.Round((remaingDays * Convert.ToDecimal(dtOrderDetails.Rows[0]["Billable_Amount"])) / totalDays, 0);
                                if (paidAmount > 0)
                                {
                                    lblCredit.Text = string.Format("{0:#.##}", paidAmount);
                                    pnlCredit.Visible = true;
                                }
                            }
                        }
                    }
                    if (dtoptionalDetails.Rows.Count > 0 && !string.IsNullOrEmpty(dtoptionalDetails.Rows[0]["SubscriptionType_ID"].ToString()))
                    {
                        pnlCheckPayment.Visible = true;
                        CheckInvoiceData(Convert.ToInt32(dtoptionalDetails.Rows[0]["SubscriptionType_ID"].ToString()));
                    }
                    else
                    {
                        BindSubscription();                        
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "ChequeProcess.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderID"></param>
        private void CheckInvoiceData(int orderID)
        {
            try
            {
                DataTable dtOrderDetails = objBus.GetOrderDetailsByOrderID(orderID);
                DataTable dtOrder = objBus.GetOrderIDInvoice(orderID);
                BusinessDAL.BillingInfo objBillingInfo = new BusinessDAL.BillingInfo();
                List<BusinessDAL.OrderDetails> objOrderDetails = new List<BusinessDAL.OrderDetails>();
                for (int i = 0; i < dtOrderDetails.Rows.Count; i++)
                {
                    salesCode = dtOrderDetails.Rows[i]["SalesCode"].ToString();
                    if (Convert.ToInt32(dtOrderDetails.Rows[i]["Request_Type"].ToString()) == Convert.ToInt32(RequestCustomFormTypes.NewRegistration))
                    {
                        ddlSubscriptions.SelectedValue = dtOrderDetails.Rows[i]["Subscription_ID"].ToString();
                        lblCheckSubAmount.Text = dtOrderDetails.Rows[i]["Total_Amount"].ToString();
                        BusinessDAL.OrderDetails objList = new BusinessDAL.OrderDetails();
                        objList.RequestType = Convert.ToInt32(RequestCustomFormTypes.NewRegistration);
                        objList.SubscriptionID = Convert.ToInt32(dtOrderDetails.Rows[i]["Subscription_ID"].ToString());
                        objList.Discount = Convert.ToDecimal(dtOrderDetails.Rows[i]["Discount_Amount"].ToString());
                        objList.Total = Convert.ToDecimal(lblCheckSubAmount.Text);
                        objList.Billable = Convert.ToDecimal(dtOrderDetails.Rows[i]["Billable_Amount"].ToString());
                        objList.Renewal = Convert.ToDecimal(dtOrderDetails.Rows[i]["Renewal_Cost"].ToString());
                        objList.DiscountCode = dtOrderDetails.Rows[i]["Discount_Code"].ToString();
                        if (!string.IsNullOrEmpty(dtOrderDetails.Rows[i]["PromoCodeId"].ToString()))
                            objList.PromoCodeId = Convert.ToInt32(dtOrderDetails.Rows[i]["PromoCodeId"].ToString());
                        objList.RenewalLifeIme = Convert.ToBoolean(dtOrderDetails.Rows[i]["Renewal_LifeTime"].ToString());
                        objOrderDetails.Add(objList);
                    }
                    else if (Convert.ToInt32(dtOrderDetails.Rows[i]["Request_Type"].ToString()) == Convert.ToInt32(RequestCustomFormTypes.BrandedApp))
                    {
                        pnlcheckOneTimeFee.Visible = true;
                        lblCheckOneTime.Text = dtOrderDetails.Rows[i]["Total_Amount"].ToString();
                        pnlcheckOneTimeFee.Visible = true;
                        lblCheckOneTime.Text = hdnSetupFee.Value;
                        BusinessDAL.OrderDetails objList = new BusinessDAL.OrderDetails();
                        objList.RequestType = Convert.ToInt32(RequestCustomFormTypes.BrandedApp);
                        objList.SubscriptionID = Convert.ToInt32(hdnSetupSID.Value);
                        objList.Discount = Convert.ToDecimal(dtOrderDetails.Rows[i]["Discount_Amount"].ToString());
                        objList.Total = Convert.ToDecimal(lblCheckOneTime.Text);
                        objList.Billable = Convert.ToDecimal(dtOrderDetails.Rows[i]["Billable_Amount"].ToString());
                        objList.Renewal = 0.00M;
                        objList.DiscountCode = dtOrderDetails.Rows[i]["Discount_Code"].ToString();
                        if (!string.IsNullOrEmpty(dtOrderDetails.Rows[i]["PromoCodeId"].ToString()))
                            objList.PromoCodeId = Convert.ToInt32(dtOrderDetails.Rows[i]["PromoCodeId"].ToString());
                        objList.RenewalLifeIme = Convert.ToBoolean(dtOrderDetails.Rows[i]["Renewal_LifeTime"].ToString());
                        objOrderDetails.Add(objList);
                    }
                }
                objBillingInfo.OrderDetailsList = objOrderDetails;
                Session["BillingInfo"] = objBillingInfo;
                lblCheckSub.Text = (Convert.ToDecimal(lblCheckSubAmount.Text) + Convert.ToDecimal(lblCheckOneTime.Text)).ToString();
                lblCheckDiscount.Text = dtOrder.Rows[0]["Discount_Amount"].ToString();
                lblCheckTotal.Text = lblInvoiceAmt.Text = dtOrder.Rows[0]["OrderBillable_Amt"].ToString();
                lblInvoiceDate.Text = dtOrder.Rows[0]["CREATED_Date"].ToString();
                txtContactName.Text = dtOrder.Rows[0]["Billing_FirstName"].ToString();
                txtLastName.Text = dtOrder.Rows[0]["Billing_LastName"].ToString();
                txtAddress.Text = dtOrder.Rows[0]["Billing_Address1"].ToString();
                txtCity.Text = dtOrder.Rows[0]["Billing_City"].ToString();
                ddlState.SelectedValue = dtOrder.Rows[0]["Billing_State"].ToString();
                txtzip.Text = dtOrder.Rows[0]["Billing_Zipcode"].ToString();
                txtPhone.Text = dtOrder.Rows[0]["Billing_Phone"].ToString();
                txtEmailID.Text = dtOrder.Rows[0]["Billing_Email"].ToString();
                DataTable dtCheckInvoice = objAdminBll.GetInquiryInvoice(PID, true);
                if (dtCheckInvoice.Rows.Count > 0)
                {
                    txtPurchaseOrder.Text = dtCheckInvoice.Rows[0]["PurchaseOrder_No"].ToString();
                    txtEmail.Text = dtCheckInvoice.Rows[0]["Invoice_Email"].ToString();
                    txtCustomNotes.Text = Convert.ToString(dtCheckInvoice.Rows[0]["Custom_Notes"]);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "ChequeProcess.aspx.cs", "CheckInvoiceData", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void LoadpkgDetails()
        {
            try
            {
                DataTable dtSucriptions = new DataTable();
                dtSucriptions = objBus.GetStoreItems("New", hdnDomain.Value);


                List<BusinessDAL.SubscriptionPackages> scriptionList = new List<BusinessDAL.SubscriptionPackages>();
                for (int i = 0; i < dtSucriptions.Rows.Count; i++)
                {
                    if (Convert.ToString(dtSucriptions.Rows[i]["Type"]).ToLower() != "setup")
                    {
                        scriptionList.Add(new BusinessDAL.SubscriptionPackages
                        {
                            ID = Convert.ToInt32(dtSucriptions.Rows[i]["Subscription_ID"]),
                            Description = Regex.Replace(Convert.ToString(dtSucriptions.Rows[i]["Title"]), "<.*[a-z]?>", "").Trim()
                           // Description = Regex.Replace(Regex.Replace(Convert.ToString(dtSucriptions.Rows[i]["Title"]), "</?(a|A).*?>", ""), "</?(img|IMG).*?>", "")
                        });
                       
                    }
                    else if (Convert.ToString(dtSucriptions.Rows[i]["Type"]).ToLower() == "setup")
                    {
                        hdnSetupFee.Value = Convert.ToString(dtSucriptions.Rows[i]["Subscription_Cost"]);
                        hdnSetupSID.Value = Convert.ToString(dtSucriptions.Rows[i]["Subscription_ID"]);
                    }
                }
                ddlSubscriptions.DataSource = scriptionList;
                ddlSubscriptions.DataTextField = "Description";
                ddlSubscriptions.DataValueField = "ID";
                ddlSubscriptions.DataBind();
                ddlSubscriptions.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "ChequeProcess.aspx.cs", "LoadpkgDetails", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void BindSubscription()
        {
            try
            {
                int subscriptionID = Convert.ToInt32(ddlSubscriptions.SelectedValue);
                DataTable dtSubscription = objBus.GetSubscriptionByID(subscriptionID);
                lblCheckSubAmount.Text = dtSubscription.Rows[0]["Subscription_Cost"].ToString();
                BusinessDAL.BillingInfo objBillingInfo;
                if (Session["BillingInfo"] != null)
                    objBillingInfo = (BusinessDAL.BillingInfo)Session["BillingInfo"];
                else
                    objBillingInfo = new BusinessDAL.BillingInfo();
                hdnProductId.Value = "";
                if (!string.IsNullOrEmpty(Convert.ToString(dtSubscription.Rows[0]["ProductId"])))
                    hdnProductId.Value = Convert.ToString(dtSubscription.Rows[0]["ProductId"]);
                List<BusinessDAL.OrderDetails> objOrderDetails = new List<BusinessDAL.OrderDetails>();
                BusinessDAL.OrderDetails objList;
                objList = new BusinessDAL.OrderDetails();
                objList.RequestType = Convert.ToInt32(RequestCustomFormTypes.NewRegistration);
                objList.SubscriptionID = subscriptionID;
                objList.Discount = 0.00M;
                objList.Total = Convert.ToDecimal(lblCheckSubAmount.Text);
                objList.Billable = Convert.ToDecimal(lblCheckSubAmount.Text) - Convert.ToDecimal(lblCredit.Text);
                objList.Renewal = Convert.ToDecimal(lblCheckSubAmount.Text);
                objList.DiscountCode = txtPromoCode.Text;
                objOrderDetails.Add(objList);
                if (Convert.ToString(dtSubscription.Rows[0]["Type"]).ToLower() == "branded")
                {
                    pnlcheckOneTimeFee.Visible = true;
                    lblCheckOneTime.Text = hdnSetupFee.Value;
                    objList = new BusinessDAL.OrderDetails();
                    objList.RequestType = Convert.ToInt32(RequestCustomFormTypes.BrandedApp);
                    objList.SubscriptionID = Convert.ToInt32(hdnSetupSID.Value);
                    objList.Discount = 0.00M;
                    objList.Total = Convert.ToDecimal(hdnSetupFee.Value);
                    objList.Billable = Convert.ToDecimal(hdnSetupFee.Value);
                    objList.Renewal = Convert.ToDecimal(hdnSetupFee.Value);
                    objList.DiscountCode = txtPromoCode.Text;
                    objOrderDetails.Add(objList);
                }
                objBillingInfo.OrderDetailsList = objOrderDetails;
                Session["BillingInfo"] = objBillingInfo;
                lblCheckSub.Text = (Convert.ToDecimal(lblCheckSubAmount.Text) + Convert.ToDecimal(lblCheckOneTime.Text)).ToString();
                lblCheckTotal.Text = (Convert.ToDecimal(lblCheckSubAmount.Text) + Convert.ToDecimal(lblCheckOneTime.Text) - Convert.ToDecimal(lblCredit.Text)).ToString();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "ChequeProcess.aspx.cs", "BindSubscription", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSubscriptions_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            lblCheckOneTime.Text = "0.00";
            lblCheckDiscount.Text = "0.00";
            txtPromoCode.Text = "";
            pnlcheckOneTimeFee.Visible = false;
            pnlCheckPayment.Visible = false;
            BindSubscription();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkInvoice_OnClick(object sender, EventArgs e)
        {
            try
            {

                BusinessDAL.BillingInfo objBillingInfo = (BusinessDAL.BillingInfo)Session["BillingInfo"];
                List<BusinessDAL.OrderDetails> objOrderDetails = objBillingInfo.OrderDetailsList;
                string branded = "";
                if (objOrderDetails.Count > 0)
                {
                    string discountCode = objBillingInfo.PromoCode;
                    int subscriptionID = Convert.ToInt32(ddlSubscriptions.SelectedValue);
                    DataTable dtSubscription = objBus.GetSubscriptionByID(subscriptionID);
                    int subPeriod = Convert.ToInt32(dtSubscription.Rows[0]["Subscription_period"].ToString());
                    if (dtSubscription.Rows[0]["Type"].ToString() == "branded")
                    {
                        branded = "Branded App";
                    }
                    int subcriptionTypeID = objBus.InsertTransaction(0, 0, 0, 10000,
                                           Convert.ToDecimal(lblCheckDiscount.Text), Convert.ToDecimal(lblCheckTotal.Text),
                                           Convert.ToDecimal(lblCheckSubAmount.Text) + Convert.ToDecimal(lblCheckOneTime.Text), 0, subPeriod, DateTime.Now.AddMonths(subPeriod), "",
                                           objBillingInfo.PromoCode, "", "Cheque", "",
                                           txtContactName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(), "", txtCity.Text.Trim(), ddlState.SelectedValue, txtzip.Text.Trim(), Convert.ToInt32(RequestCustomFormTypes.NewRegistration), subPeriod, 0, 0, txtPurchaseOrder.Text.Trim(), txtPhone.Text.Trim(), txtEmailID.Text.Trim(), salesCode);
                    objAgencyBll.UpdateAgencySubscription(PID, subcriptionTypeID, subPeriod, branded, true);
                    foreach (BusinessDAL.OrderDetails order in objOrderDetails)
                    {
                        objBus.InsertOrderDetails(0, 0, subcriptionTypeID, order.SubscriptionID, order.Total, order.Discount,
                                           order.Billable, DateTime.Now, 0, DateTime.Now, DateTime.Now.AddMonths(subPeriod), Convert.ToInt32(RequestCustomFormTypes.NewRegistration), null, null,
                                           subPeriod, order.DiscountCode, order.Renewal, order.RenewalLifeIme, order.PromoCodeId, salesCode);

                    }
                    string purchaseOrderNo = txtPurchaseOrder.Text.Trim();
                    int invoiceID = objAdminBll.AddCheckInvoice(PID, purchaseOrderNo, txtEmail.Text.Trim(), Convert.ToDecimal(lblCheckTotal.Text), ddlSubscriptions.SelectedValue, 0.00M, Convert.ToDecimal(lblCheckDiscount.Text), txtCustomNotes.Text.Trim(), true);
                    GenerateInvoice(subcriptionTypeID);
                    DataTable dtCheckInvoice = objAdminBll.GetInquiryInvoice(PID, true);
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

                }
            }
            catch (Exception ex)
            {
                objCommonBll.ErrorHandling("ERROR", "UpgradeCheckProcess.aspx", "lnkInvoice_OnClick", Convert.ToString(ex.Message),
                        Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkPreview_OnClick(object sender, EventArgs e)
        {
            try
            {
                string address = "";
                DataTable dtVerifyDetails = objAgencyBll.GetVerifyDetailsById(PID);
                if (dtVerifyDetails.Rows.Count == 1)
                {
                    address = "<BR/><b>" + dtVerifyDetails.Rows[0]["Agency_Name"].ToString() + "</b><BR/>";
                }
                address = address + txtContactName.Text.Trim() + (txtLastName.Text.Trim() == "" ? "" : " " + txtLastName.Text.Trim()) + "<BR/>" + txtAddress.Text.Trim() + "<BR/>" + txtCity.Text.Trim() + "," + ddlState.SelectedValue + " " + txtzip.Text.Trim() + "<BR/>" + txtPhone.Text.Trim() + "<BR/>" + txtEmailID.Text.Trim();
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
                String strhtml = "";
                string subtype = string.Empty;
                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\";
                StreamReader re = File.OpenText(strfilepath + "InoviceFormat.txt");
                string invoice_htmlText = string.Empty;
                string content = string.Empty;

                while ((content = re.ReadLine()) != null)
                {
                    invoice_htmlText = invoice_htmlText + content;
                }

                string RootPath = "";
                dtConfigs = objCommonBll.GetVerticalConfigsByType(hdnDomain.Value, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            RootPath = row[1].ToString();
                    }
                }

                invoice_htmlText = invoice_htmlText.Replace("#Logo#", RootPath + "/Images/Dashboard/logictree_logo.png");
                invoice_htmlText = invoice_htmlText.Replace("#BillingAddress#", address);
                invoice_htmlText = invoice_htmlText.Replace("#InvoiceDate#", DateTime.Now.ToString("MMMM dd, yyyy"));
                invoice_htmlText = invoice_htmlText.Replace("#InvoiceNumber#", "");
                invoice_htmlText = invoice_htmlText.Replace("#PONumber#", Convert.ToString(txtPurchaseOrder.Text.Trim()));
                invoice_htmlText = invoice_htmlText.Replace("Paid ", "");
                invoice_htmlText = invoice_htmlText.Replace("Balance ", "");
                invoice_htmlText = invoice_htmlText.Replace("#DueDateTitle#", "");
                invoice_htmlText = invoice_htmlText.Replace("#DueDate#", "");
                invoice_htmlText = invoice_htmlText.Replace("#CustomNotes#", txtCustomNotes.Text.Trim());
                string orderDetailsHTML = "";
                BusinessDAL.BillingInfo objBillingInfo = (BusinessDAL.BillingInfo)Session["BillingInfo"];
                List<BusinessDAL.OrderDetails> objOrderDetails = objBillingInfo.OrderDetailsList;
                int ordersCount = 0;
                foreach (BusinessDAL.OrderDetails order in objOrderDetails)
                {
                    DataTable dtOrder = objBus.GetSubscriptionByID(order.SubscriptionID);
                    orderDetailsHTML = orderDetailsHTML + "<tr><td style='border-left: 1px solid black; font-weight:normal;'>" + dtOrder.Rows[0]["Email_Description"].ToString() + "</td>";
                    if (ordersCount == 0)
                        orderDetailsHTML = orderDetailsHTML + "<td style='border-left: 1px solid black; border-right: 1px solid black; padding-right: 10px; font-weight:normal;'><table width='100%'><tr><td align='left'>$</td><td align='right'>" + order.Total + "</td></tr></table></td></tr>";
                    else
                        orderDetailsHTML = orderDetailsHTML + "<td align='right' style='border-left: 1px solid black; border-right: 1px solid black; padding-right: 10px; font-weight:normal;'>" + order.Total + "</td></tr>";
                    ordersCount += 1;
                    if (!string.IsNullOrEmpty(order.DiscountCode))
                        orderDetailsHTML = orderDetailsHTML + "<tr><td style='border-left: 1px solid black; font-weight:normal;'>" + order.DiscountCode + " discount</td>" + "<td align='right' style='border-left: 1px solid black; border-right: 1px solid black; padding-right: 10px; font-weight:normal;'>(" + order.Discount + ")</td></tr>";
                    //" + "<td align='right' style='border-left: 1px solid black; padding-right: 10px; font-weight:normal;'>$" + order.Discount + "</td><td align='right' style='border-left: 1px solid black; padding-right: 10px; border-right: 1px solid black; font-weight:normal;'>$" + order.Billable + "</td>
                }
                invoice_htmlText = invoice_htmlText.Replace("#OrderDetailsRows#", orderDetailsHTML);
                invoice_htmlText = invoice_htmlText.Replace("#TotalBill#", lblCheckTotal.Text);
                invoice_htmlText = invoice_htmlText.Replace("$#PaidBill#", "");
                invoice_htmlText = invoice_htmlText.Replace("$#BalanceBill#", "");
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "ChequeProcess.aspx.cs", "lnkPreview_OnClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        private void GenerateInvoice(int orderID)
        {
            try
            {
                string address = "";
                DataTable dtVerifyDetails = objBus.GetProfileDetailsByProfileID(PID);
                if (dtVerifyDetails.Rows.Count == 1)
                {
                    address = "<BR/><b>" + dtVerifyDetails.Rows[0]["Profile_name"].ToString() + "</b><BR/>";
                }
                address = address + txtContactName.Text.Trim() + (txtLastName.Text.Trim() == "" ? "" : " " + txtLastName.Text.Trim()) + "<BR/>" + txtAddress.Text.Trim() + "<BR/>" + txtCity.Text.Trim() + "," + ddlState.SelectedValue + " " + txtzip.Text.Trim() + "<BR/>" + txtPhone.Text.Trim() + "<BR/>" + txtEmailID.Text.Trim();
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
                String strhtml = "";
                string subtype = string.Empty;
                string strfilepath = HttpContext.Current.Server.MapPath("~") + "\\BulletinPreview\\";
                StreamReader re = File.OpenText(strfilepath + "InoviceFormat.txt");
                string invoice_htmlText = string.Empty;
                string content = string.Empty;

                while ((content = re.ReadLine()) != null)
                {
                    invoice_htmlText = invoice_htmlText + content;
                }

                string RootPath = "";
                dtConfigs = objCommonBll.GetVerticalConfigsByType(hdnDomain.Value, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            RootPath = row[1].ToString();
                    }
                }

                invoice_htmlText = invoice_htmlText.Replace("#Logo#", RootPath + "/Images/Dashboard/logictree_logo.png");
                invoice_htmlText = invoice_htmlText.Replace("#BillingAddress#", address);
                invoice_htmlText = invoice_htmlText.Replace("#InvoiceDate#", DateTime.Now.ToString("MMMM dd, yyyy"));
                invoice_htmlText = invoice_htmlText.Replace("#InvoiceNumber#", orderID.ToString());
                invoice_htmlText = invoice_htmlText.Replace("#PONumber#", Convert.ToString(txtPurchaseOrder.Text.Trim()));
                invoice_htmlText = invoice_htmlText.Replace("Paid ", "");
                invoice_htmlText = invoice_htmlText.Replace("Balance ", "");
                invoice_htmlText = invoice_htmlText.Replace("#DueDateTitle#", "");
                invoice_htmlText = invoice_htmlText.Replace("#DueDate#", "");
                invoice_htmlText = invoice_htmlText.Replace("#CustomNotes#", txtCustomNotes.Text.Trim());
                string orderDetailsHTML = "";
                BusinessDAL.BillingInfo objBillingInfo = (BusinessDAL.BillingInfo)Session["BillingInfo"];
                List<BusinessDAL.OrderDetails> objOrderDetails = objBillingInfo.OrderDetailsList;
                int ordersCount = 0;
                foreach (BusinessDAL.OrderDetails order in objOrderDetails)
                {
                    DataTable dtOrder = objBus.GetSubscriptionByID(order.SubscriptionID);
                    orderDetailsHTML = orderDetailsHTML + "<tr><td style='border-left: 1px solid black; font-weight:normal;'>" + dtOrder.Rows[0]["Email_Description"].ToString() + "</td>";
                    if (ordersCount == 0)
                        orderDetailsHTML = orderDetailsHTML + "<td style='border-left: 1px solid black; border-right: 1px solid black; padding-right: 10px; font-weight:normal;'><table width='100%'><tr><td align='left'>$</td><td align='right'>" + order.Total + "</td></tr></table></td></tr>";
                    else
                        orderDetailsHTML = orderDetailsHTML + "<td align='right' style='border-left: 1px solid black; border-right: 1px solid black; padding-right: 10px; font-weight:normal;'>" + order.Total + "</td></tr>";
                    ordersCount += 1;
                    if (!string.IsNullOrEmpty(order.DiscountCode))
                        orderDetailsHTML = orderDetailsHTML + "<tr><td style='border-left: 1px solid black; font-weight:normal;'>" + order.DiscountCode + " discount</td>" + "<td align='right' style='border-left: 1px solid black; border-right: 1px solid black; padding-right: 10px; font-weight:normal;'>(" + order.Discount + ")</td></tr>";
                }
                invoice_htmlText = invoice_htmlText.Replace("#OrderDetailsRows#", orderDetailsHTML);
                invoice_htmlText = invoice_htmlText.Replace("#TotalBill#", lblCheckTotal.Text);
                invoice_htmlText = invoice_htmlText.Replace("$#PaidBill#", "");
                invoice_htmlText = invoice_htmlText.Replace("$#BalanceBill#", "");

                re.Close();
                re.Dispose();
                // final HTML Invoice Format
                strhtml = invoice_htmlText;



                string filepath = Server.MapPath("~");

                string filename = filepath + "/temp/" + domain + "_Invoice_" + orderID + ".html";

                string hmtlfileurl = ConfigurationManager.AppSettings.Get("RootPath") + "/temp/" + domain + "_Invoice_" + orderID + ".html";

                string pdffilename = filepath + "/temp/" + domain + "_Invoice_" + orderID + ".pdf";

                string pdfilenameval = domain + "_Invoice_" + orderID + ".pdf";

                string pdffileurl = ConfigurationManager.AppSettings.Get("RootPath") + "/temp/" + domain + "_Invoice_" + orderID + ".pdf";

                string savelocation = Server.MapPath("~").ToString() + "\\temp\\" + pdfilenameval;
                objCommonBll.HtmlToPDF_Print(strhtml.ToString(), pdfilenameval, savelocation, false);

                lblInvoicePreview.Text = strhtml;
                lblInvoiceEmailtTo.Text = txtEmail.Text;
                ModalInvoicePop.Show();
                string contactname = dtVerifyDetails.Rows[0]["Contact_Person"].ToString();
                if (!string.IsNullOrEmpty(dtVerifyDetails.Rows[0]["LastName"].ToString()))
                    contactname = contactname + " " + dtVerifyDetails.Rows[0]["LastName"].ToString();
                hdnContactname.Value = contactname;
                hdnInvoiceLocation.Value = savelocation;
            }
            catch (Exception ex)
            {
                objCommonBll.ErrorHandling("ERROR", "UpgradeCheckProcess.aspx", "GenerateInvoice", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        protected void lnkSendInvoice_OnClick(object sender, EventArgs e)
        {
            SendInvoiceEmail(lblInvoiceEmailtTo.Text, hdnInvoiceLocation.Value, hdnContactname.Value);
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
                msgbody = msgbody.Replace("#Name#", contactPerson);
                re.Close();
                re.Dispose();
                string ccemail = string.Empty;

                utlobj.SendWowzzyEmailWithAttachments(FromEmailsupport, username, "Upgrade Account Details", msgbody, ccemail, attachment, hdnDomain.Value);
                reDeclaimer = File.OpenText(strfilepath + "IncoiveAccounts.txt");
                string toEmails = string.Empty;
                while ((desclaimer = reDeclaimer.ReadLine()) != null)
                {
                    toEmails = toEmails + desclaimer;
                }
                reDeclaimer.Close();
                reDeclaimer.Dispose();
                utlobj.SendWowzzyEmailWithAttachments(FromEmailsupport, toEmails, "Upgrade Account Details", msgbody, ccemail, attachment, hdnDomain.Value);
                lblError.Text = "<font color='green' size='3'>Invoice has been created successfully and emailed.</font>";
                ModalInvoicePop.Hide();
            }
            catch (Exception ex)
            {
                objCommonBll.ErrorHandling("ERROR", "UpgradeChequeProcess.aspx", "SendInvoiceEmail", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        protected void lnkProcessCheck_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dtVerifyDetails = objAgencyBll.GetUpgradeInfoByProfileID(PID);
                int orderID = Convert.ToInt32(dtVerifyDetails.Rows[0]["SubscriptionType_ID"].ToString());
                int adminUserID = Convert.ToInt32(Session["adminuserid"]);
                decimal totalAmount = Convert.ToDecimal(lblInvoiceAmt.Text);
                decimal billableAmount = Convert.ToDecimal(txtCheckAmt.Text.Trim());
                objAdminBll.UpdateVerifyStatus(PID, ConfigurationManager.AppSettings["verifystatuspaid"], true);
                if (billableAmount<=totalAmount)
                {
                    objBus.InsertOrderPayment(orderID, billableAmount, (totalAmount - billableAmount), txtCheckNum.Text.Trim(), adminUserID);
                    Session["ChequePaySuccess"] = Resources.LabelMessages.CheckOutSuccess;
                    Response.Redirect("~/Admin/UpgradeChequeprocess.aspx?PID=" + EncryptDecrypt.DESEncrypt(PID.ToString()) + "&SearchSelectedValue=" + Request.QueryString["SearchSelectedValue"] + "&SearchInputValue=" + Request.QueryString["SearchInputValue"]);
                }
                else
                {
                    lblError.Text = "Enter check amount less than or equal to invoice amount.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "ChequeProcess.aspx.cs", "lnkProcessCheck_OnClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        protected void lnkback_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/CustomerServiceNew.aspx?SearchSelectedValue=" + Request.QueryString["SearchSelectedValue"] + "&SearchInputValue=" + Request.QueryString["SearchInputValue"]);
        }


        protected void btnValidatePromo_Click(object sender, EventArgs e)
        {
            try
            {
                string promoCode = txtPromoCode.Text.Trim();
                decimal totalCost = Convert.ToDecimal(lblCheckSubAmount.Text) + Convert.ToDecimal(lblCheckOneTime.Text);
                decimal totalDiscount = 0.00M;
                decimal productPrice = 0.00M;
                decimal productDicount = 0.00M;
                decimal? setupFee = null;
                decimal setupFeeDiscount = 0.00M;
                int? productId = null;
                bool isRenewLifeTime = false;
                int? promocodeId = null;
                DataTable dtPromocodeDetails = objAgencyBll.CheckPromoCode(promoCode, hdnVertical.Value, true);
                BusinessDAL.BillingInfo objBillingInfo;
                if (Session["BillingInfo"] != null)
                    objBillingInfo = (BusinessDAL.BillingInfo)Session["BillingInfo"];
                else
                    objBillingInfo = new BusinessDAL.BillingInfo();
                List<USPDHUBDAL.BusinessDAL.OrderDetails> objOrdersList = objBillingInfo.OrderDetailsList;
                bool isPromocodeValid = false;
                decimal selProdPrice = 0.00M;
                if (dtPromocodeDetails.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dtPromocodeDetails.Rows[0]["ProductId"])))
                    {
                        productId = Convert.ToInt32(dtPromocodeDetails.Rows[0]["ProductId"]);
                        if (hdnProductId.Value != "" && Convert.ToUInt32(hdnProductId.Value) == productId)
                        {
                            productPrice = Convert.ToDecimal(dtPromocodeDetails.Rows[0]["Product_Price"]);
                            if (objOrdersList.Count > 0)
                            {
                                selProdPrice = objOrdersList.Where(x => x.RequestType == Convert.ToInt32(RequestCustomFormTypes.NewRegistration)).FirstOrDefault().Total;
                                if (selProdPrice == productPrice)
                                    isPromocodeValid = true;
                                if (objOrdersList.Count > 1 && isPromocodeValid)
                                {
                                    decimal selSetupPrice = objOrdersList.Where(x => x.RequestType == Convert.ToInt32(RequestCustomFormTypes.BrandedApp)).FirstOrDefault().Total;
                                    if (!string.IsNullOrEmpty(Convert.ToString(dtPromocodeDetails.Rows[0]["SetupFee"])))
                                        setupFee = Convert.ToDecimal(dtPromocodeDetails.Rows[0]["SetupFee"]);
                                    if (selSetupPrice == setupFee)
                                        setupFeeDiscount = selSetupPrice - Convert.ToDecimal(dtPromocodeDetails.Rows[0]["SetupFee_Charged"]);
                                    else
                                        isPromocodeValid = false;
                                }
                            }
                        }
                    }
                }
                if (isPromocodeValid)
                {
                    productDicount = selProdPrice - Convert.ToDecimal(dtPromocodeDetails.Rows[0]["Amount_Charged"]);
                    isRenewLifeTime = Convert.ToBoolean(dtPromocodeDetails.Rows[0]["Renewal_LifeTime"]);
                    promocodeId = Convert.ToInt32(dtPromocodeDetails.Rows[0]["Promocode_ID"]);
                }
                else
                {
                    promoCode = "";
                    lblError.Text = "Please enter a valid promo code.";
                    txtPromoCode.Text = "";
                    BindSubscription();
                }
                if (objOrdersList.Count > 0 && isPromocodeValid)
                {
                    List<BusinessDAL.OrderDetails> objUpdatedOrdersList = new List<BusinessDAL.OrderDetails>();
                    BusinessDAL.OrderDetails objList;
                    foreach (BusinessDAL.OrderDetails order in objOrdersList)
                    {
                        objList = new BusinessDAL.OrderDetails();
                        objList.SubscriptionID = order.SubscriptionID;
                        objList.RequestType = order.RequestType;
                        objList.Total = order.Total;
                        objList.DiscountCode = "";
                        objList.PromoCodeId = promocodeId;
                        objList.RenewalLifeIme = isRenewLifeTime;
                        // *** Calculating the discount for individual transaction *** //
                        if (order.RequestType == Convert.ToInt32(RequestCustomFormTypes.NewRegistration))
                        {
                            objList.Discount = productDicount;
                            objList.Billable = Convert.ToDecimal(order.Total - productDicount);
                            objList.Renewal = isRenewLifeTime == false ? order.Total : objList.Billable;
                            totalDiscount = totalDiscount + productDicount;
                        }
                        else if (order.RequestType == Convert.ToInt32(RequestCustomFormTypes.BrandedApp))
                        {
                            objList.Discount = setupFeeDiscount;
                            objList.Billable = Convert.ToDecimal(order.Total - setupFeeDiscount);
                            objList.Renewal = isRenewLifeTime == false ? order.Total : objList.Billable;
                            totalDiscount = totalDiscount + setupFeeDiscount;
                        }
                        // *** End of calculating the discount for individual transaction*** //
                        objList.DiscountCode = promoCode;
                        objUpdatedOrdersList.Add(objList);
                    }
                    objBillingInfo.OrderDetailsList = objUpdatedOrdersList;
                    lblCheckTotal.Text = (totalCost - totalDiscount).ToString();
                    lblCheckDiscount.Text = totalDiscount.ToString();
                    objBillingInfo.PromoCode = promoCode;
                    Session["BillingInfo"] = objBillingInfo;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "ChequeProcess.aspx.cs", "btnValidatePromo_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

    }
}