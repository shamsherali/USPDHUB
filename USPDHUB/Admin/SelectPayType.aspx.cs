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
using System.Text.RegularExpressions;

namespace USPDHUB.Admin
{
    public partial class SelectPayType : System.Web.UI.Page
    {
        public int AdminUserID = 0;
        CommonBLL objCommon = new CommonBLL();
        AgencyBLL objAgency = new AgencyBLL();
        BusinessBLL objBus = new BusinessBLL();
        AdminBLL objAdmin = new AdminBLL();
        public int InquiryId = 0;
        DataTable dtVerifyDetails = new DataTable();
        public string DomainName = "";
        string salesCode = "";
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
                InquiryId = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["ID"].ToString()));
                if (Request.QueryString["src"] != null)
                {
                    if (EncryptDecrypt.DESDecrypt(Request.QueryString["src"].ToString()).Equals("edetails") && Convert.ToBoolean(Session["IsLiteversion"]))
                    {
                        btnBill.Visible = false;
                    }
                }
                if (!IsPostBack)
                {
                    lnkActivateAcnt.Visible = false;
                    lnkMainScreen1.Visible = false;
                    dtVerifyDetails = objAgency.GetVerifyDetailsById(Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["ID"].ToString())));
                    hdnDomain.Value = objCommon.GetDomainNameByCountryVertical(dtVerifyDetails.Rows[0]["Vertical_Name"].ToString(), dtVerifyDetails.Rows[0]["Country"].ToString());
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SelectPayType.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCard_Click(object sender, EventArgs e)
        {
            try
            {
                dtVerifyDetails = objAgency.GetVerifyDetailsById(Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["ID"].ToString())));
                if (Convert.ToString(hdnDomain.Value).Trim() == string.Empty)
                    hdnDomain.Value = objCommon.GetDomainNameByCountryVertical(dtVerifyDetails.Rows[0]["Vertical_Name"].ToString(), dtVerifyDetails.Rows[0]["Country"].ToString());

                string username = dtVerifyDetails.Rows[0]["Email_Address"].ToString();

                string adminDomainName = objCommon.CreateAdminDomain(HttpContext.Current.Request.Url.AbsoluteUri);
                string urlRedirect = ConfigurationManager.AppSettings.Get("ShoppingCartRootPath") + "/Checkout/EnhanceSubcription.aspx?InqID=" + EncryptDecrypt.DESEncrypt(InquiryId.ToString()) + "&Type=" + EncryptDecrypt.DESEncrypt("10000") + "&VC=" + EncryptDecrypt.DESEncrypt(hdnDomain.Value) + "&Username=" + EncryptDecrypt.DESEncrypt(username) + "&AVC=" + EncryptDecrypt.DESEncrypt(adminDomainName) + "&Lite=" + EncryptDecrypt.DESEncrypt(Session["IsLiteversion"].ToString());
                Response.Redirect(urlRedirect);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SelectPayType.aspx.cs", "btnCard_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnBill_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Admin/Chequeprocess.aspx?ID=" + EncryptDecrypt.DESEncrypt(InquiryId.ToString())));
        }
        protected void btnFree_Click(object sender, EventArgs e)
        {
            lnkActivateAcnt.Visible = true;
            lnkMainScreen1.Visible = true;
            pnlSubscriptions.Visible = true;
            pnlSelectPay.Visible = false;
            LoadpkgDetails();
        }
        protected void lnkMainScreen_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Admin/EnquiryDetails.aspx?ID=" + EncryptDecrypt.DESEncrypt(InquiryId.ToString())));
        }
        private void LoadpkgDetails()
        {
            try
            {
                DataTable dtSucriptions = new DataTable();

                if (Convert.ToBoolean(Session["IsLiteversion"]))
                    dtSucriptions = objBus.GetStoreItems("NewLite", hdnDomain.Value);
                else
                    dtSucriptions = objBus.GetStoreItems("New", hdnDomain.Value);

                List<USPDHUBDAL.BusinessDAL.SubscriptionPackages> scriptionList = new List<USPDHUBDAL.BusinessDAL.SubscriptionPackages>();
                for (int i = 0; i < dtSucriptions.Rows.Count; i++)
                {
                    if (Convert.ToString(dtSucriptions.Rows[i]["Type"]).ToLower() != "setup")
                    {
                        scriptionList.Add(new USPDHUBDAL.BusinessDAL.SubscriptionPackages
                        {
                            ID = Convert.ToInt32(dtSucriptions.Rows[i]["Subscription_ID"]),
                            Description = Regex.Replace(Regex.Replace(Convert.ToString(dtSucriptions.Rows[i]["Title"]), "</?(a|A).*?>", ""), "</?(img|IMG).*?>", "")
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
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SelectPayType.aspx.cs", "LoadpkgDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkActivateAcnt_Click(object sender, EventArgs e)
        {
            try
            {
                string address = "";
                string city = "";
                string state = "";
                string zipcode = "";
                dtVerifyDetails = objAgency.GetVerifyDetailsById(InquiryId);
                int subscriptionID = Convert.ToInt32(ddlSubscriptions.SelectedValue);
                DataTable dtSubscription = objBus.GetSubscriptionByID(subscriptionID);
                int subPeriod = Convert.ToInt32(dtSubscription.Rows[0]["Subscription_period"].ToString());
                decimal renewal = Convert.ToDecimal(dtSubscription.Rows[0]["Subscription_Cost"].ToString());
                if (dtVerifyDetails.Rows.Count == 1)
                {
                    salesCode = dtVerifyDetails.Rows[0]["SalesCode"].ToString();
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
                    string discountcode = "FreeTrial";
                    string password = objCommon.GenerateRandomPassword();
                    int profileID = 0;

                    if (Convert.ToBoolean(Session["IsLiteversion"]))
                    {
                        discountcode = "";
                        profileID = objAgency.InsertNewSubcriptionUserDetails(latitude1, longitude1, EncryptDecrypt.DESEncrypt(password), InquiryId, Convert.ToInt32(ProfileSubscriptionTypes.SponsoredLite));
                    }
                    else
                        profileID = objAgency.InsertNewSubcriptionUserDetails(latitude1, longitude1, EncryptDecrypt.DESEncrypt(password), InquiryId, Convert.ToInt32(ProfileSubscriptionTypes.Premium));
                    if (profileID > 0)
                    {
                        DataTable dtuserdetails = objBus.GetProfileDetailsByProfileID(profileID);
                        int createdUserID = Convert.ToInt32(dtuserdetails.Rows[0]["User_ID"]);
                        Boolean isLiteVersion = Convert.ToBoolean(dtuserdetails.Rows[0]["IsLiteVersion"]);
                        int orderID = objBus.InsertTransaction(profileID, createdUserID, 0, 10000,
                                       renewal, 0.00M, renewal, createdUserID, subPeriod, DateTime.Now.AddMonths(subPeriod), "",
                                       discountcode, "", "", "", "", "", "", "", "", "", "", Convert.ToInt32(RequestCustomFormTypes.NewRegistration), subPeriod, 0, 0, "", "", "", salesCode);
                        if (orderID > 0)
                        {
                            objAgency.InsertEnquiryNotes(0, "Freetrial success", "System", InquiryId, true);
                            string logopath = string.Empty;
                            logopath = dtVerifyDetails.Rows[0]["Logo"].ToString();
                            if (logopath != null && logopath != "")
                            {
                                string path = objCommon.CopyLogo(profileID, logopath, InquiryId);
                                if (path != null && path != "")
                                    objAgency.UpdateLogoPath(profileID, path);
                            }
                            lnkActivateAcnt.Visible = false;
                            lnkMainScreen1.Visible = false;
                            int? promoCodeId = null;
                            SendActivationEmail(dtVerifyDetails.Rows[0]["Email_Address"].ToString(), password);
                            Session["Success"] = "<font size='2' color='green'>Account has been activated successfully.</font>";
                            int subscriptionOrderID = objBus.InsertUserSubscriptions(profileID, createdUserID, subPeriod, renewal, renewal, 0.00M, "", "", "", "", "", "", "", "", "", 0, 0, "", "", discountcode, false);

                            objBus.InsertOrderDetails(profileID, createdUserID, orderID, subscriptionID, renewal, renewal,
                               0.00M, DateTime.Now, createdUserID, DateTime.Now, DateTime.Now.AddMonths(subPeriod), Convert.ToInt32(RequestCustomFormTypes.NewRegistration), null, null,
                               subPeriod, discountcode, renewal, false, promoCodeId, salesCode);
                            if (isLiteVersion)
                                objBus.InsertSMSAddons(profileID, createdUserID, 0, ConfigurationManager.AppSettings["defaultLiteSMSType"].ToString(), Convert.ToInt32(ConfigurationManager.AppSettings["defaultLiteSMSQuantity"]));

                            if (Convert.ToString(dtSubscription.Rows[0]["Type"]).ToLower() == "branded")
                            {
                                objBus.UpdateUserBrandedApp(profileID);
                                // Insert Branded App Order Status
                                objBus.Insert_Update_AppProcessStatus(0, createdUserID, profileID, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                    string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Convert.ToInt32(BusinessDAL.BranedAppProcessStatus.New), 0, string.Empty, string.Empty);

                                objBus.InsertOrderDetails(profileID, createdUserID, orderID, Convert.ToInt32(hdnSetupSID.Value), Convert.ToDecimal(hdnSetupFee.Value), Convert.ToDecimal(hdnSetupFee.Value),
                                0.00M, DateTime.Now, createdUserID, DateTime.Now, DateTime.Now.AddMonths(subPeriod), Convert.ToInt32(RequestCustomFormTypes.BrandedApp), null, null,
                                subPeriod, discountcode, Convert.ToDecimal(hdnSetupFee.Value), false, promoCodeId, salesCode);
                            }

                            objBus.InsertOrderPayment(orderID, 0.00M, 0.00M, "", AdminUserID);
                            objCommon.SendRepresentationEmail(profileID, hdnDomain.Value);
                            Response.Redirect(Page.ResolveClientUrl("~/Admin/EnquiryDetails.aspx?ID=" + EncryptDecrypt.DESEncrypt(InquiryId.ToString())));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message.ToString();

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SelectPayType.aspx.cs", "lnkActivateAcnt_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void SendActivationEmail(string username, string password)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            try
            {
                string rootPath = "";
                DataTable dtConfigs = objCommon.GetVerticalConfigsByType(hdnDomain.Value, "Paths");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "RootPath")
                            rootPath = row[1].ToString();
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
    }
}