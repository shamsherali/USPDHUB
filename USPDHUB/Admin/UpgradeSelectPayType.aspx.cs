using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Configuration;
using System.IO;
using USPDHUBDAL;

namespace USPDHUB.Admin
{
    public partial class UpgradeSelectPayType : System.Web.UI.Page
    {
        public int AdminUserID = 0;
        CommonBLL objCommon = new CommonBLL();
        AgencyBLL objAgency = new AgencyBLL();
        BusinessBLL objBus = new BusinessBLL();
        AdminBLL objAdmin = new AdminBLL();
        public int PID = 0;
        DataTable dtVerifyDetails = new DataTable();
        public string DomainName = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                PID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["PID"].ToString()));
                DataTable dtProfileDetails = objBus.GetProfileDetailsByProfileID(PID);
                string vertical = Convert.ToString(dtProfileDetails.Rows[0]["Vertical_Name"]);
                string country = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);
                DomainName = objCommon.GetDomainNameByCountryVertical(vertical, country);

                if (!IsPostBack)
                {
                    if (Session["ChequePaySuccess"] != null)
                    {
                        lblError.Text = "<font size='2' color='green'>" + Convert.ToString(Session["ChequePaySuccess"]) + "</font>";
                        Session["ChequePaySuccess"] = null;
                    }
                    DataTable dtoptionalDetails = objAgency.GetUpgradeInfoByProfileID(PID);
                    if (dtoptionalDetails.Rows.Count > 0 && !string.IsNullOrEmpty(dtoptionalDetails.Rows[0]["Status"].ToString()))
                    {
                        if (Convert.ToString(dtoptionalDetails.Rows[0]["Status"]) == ConfigurationManager.AppSettings["verifystatuspaid"])
                        {
                            pnlSelectPay.Visible = false;
                            pnlActivate.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "UpgradeSelectPayType.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCard_Click(object sender, EventArgs e)
        {
            try
            {
                string urlRedirect = ConfigurationManager.AppSettings.Get("ShoppingCartRootPath") + "/RedirectPage.aspx?MID=" + Request.QueryString["UID"] + "&MPID=" + Request.QueryString["PID"] + "&CID=" + Request.QueryString["UID"] + "&VC=" + EncryptDecrypt.DESEncrypt(DomainName) + "&ReqType=1&isug=true";
                Response.Redirect(urlRedirect);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "UpgradeSelectPayType.aspx.cs", "btnCard_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBill_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Admin/UpgradeChequeprocess.aspx?PID=" + EncryptDecrypt.DESEncrypt(PID.ToString())) + "&SearchSelectedValue=" + Request.QueryString["SearchSelectedValue"] + "&SearchInputValue=" + Request.QueryString["SearchInputValue"]);
        }
        protected void btnActivatePremium_Click(object sender, EventArgs e)
        {
            DataTable dtProfileDetails = objBus.GetProfileDetailsByProfileID(PID);
            string vertical = Convert.ToString(dtProfileDetails.Rows[0]["Vertical_Name"]);
            string country = Convert.ToString(dtProfileDetails.Rows[0]["Profile_County"]);
            int createdUserID = Convert.ToInt32(dtProfileDetails.Rows[0]["User_ID"]);
            DataTable dtVerifyDetails = objAgency.GetUpgradeInfoByProfileID(PID);
            string promoCode = Convert.ToString(dtVerifyDetails.Rows[0]["PromoCode"]);
            int orderID = Convert.ToInt32(dtVerifyDetails.Rows[0]["SubscriptionType_ID"].ToString());
            int subPeriod = Convert.ToInt32(dtVerifyDetails.Rows[0]["Subscription_Period"].ToString());
            DataTable dtInvoiceOrderDetails = objBus.GetOrderIDInvoice(orderID);
            decimal total = Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["Total_Amount"].ToString());
            decimal discount = Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["Discount_Amount"].ToString());
            decimal billableAmt = Convert.ToDecimal(dtInvoiceOrderDetails.Rows[0]["OrderBillable_Amt"].ToString());
            // *** Upgrade subscription ***//           
            DataTable dtProfileSubscription = objBus.GetOrderSubscriptionByProfileID(PID);
            int subOrderID = Convert.ToInt32(dtProfileSubscription.Rows[0]["Order_ID"].ToString());
            DateTime renewalDate = DateTime.Today.AddMonths(subPeriod);
            // **** If anyone change this method please check the recurring windows service for the same methods *** //
            objBus.UpdateRecurringDetails(subOrderID, discount,
                                    billableAmt, total, createdUserID, renewalDate, promoCode, subPeriod);
            objAgency.UpdateLiteVersion(PID, 2); // *** 2 means upgrading from lite vrsion to full *** //
            if (Convert.ToString(dtVerifyDetails.Rows[0]["Subscription_Package"]).ToLower().Contains("branded"))
            {
                objBus.UpdateUserBrandedApp(PID);
                // Insert Branded App Order Status
                objBus.Insert_Update_AppProcessStatus(0, createdUserID, PID, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                    string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Convert.ToInt32(BusinessDAL.BranedAppProcessStatus.New), 0);
            }
            objBus.UpdateOrderDetails(PID, createdUserID, orderID, subPeriod);
            string domainName = objCommon.GetDomainNameByCountryVertical(vertical, country);
            string location = objCommon.CreateInvoiceReport(orderID, vertical, domainName);
            // *** Send Email *** //
            DataTable dtUsers = objBus.GetUserDetailsByUserID(createdUserID);
            if (dtUsers.Rows.Count > 0)
                SendActivationEmail(Convert.ToString(dtUsers.Rows[0]["Username"]), location, domainName);
        }
        private void SendActivationEmail(string username, string location, string domain)
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
                StreamReader re = File.OpenText(strfilepath + "AgencyUpgrade.txt");
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
                re.Close();
                re.Dispose();
                reDeclaimer.Close();
                reDeclaimer.Dispose();
                string ccemail = string.Empty;
                UtilitiesBLL utlobj = new UtilitiesBLL();
                if (string.IsNullOrEmpty(location))
                    utlobj.SendWowzzyEmail(FromEmailsupport, username, "Account Upgrade", msgbody, ccemail, "", domain);
                else
                    utlobj.SendWowzzyEmailWithAttachments(FromEmailsupport, username, "Account Upgrade", msgbody, ccemail, location, domain);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "UpgradeSelectPayTypoe.aspx.cs", "SendActivationEmail", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}