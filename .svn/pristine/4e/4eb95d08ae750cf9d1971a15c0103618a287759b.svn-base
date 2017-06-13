using System;
using System.Linq;
using System.Web.UI;
using USPDHUBBLL;
using System.Configuration;
using System.Data;
using System.Web;

namespace USPDHUB.OP.uspdhubcom
{
    public partial class AddToolsold : System.Web.UI.Page
    {
        public string RootPath = "";
        public string DomainName = "";
        public int ProfileID = 0;
        public int UserID = 0;
        BusinessBLL objBus = new BusinessBLL();
        public bool Website = true;
        public bool Flyer = true;
        public bool Update = true;
        public bool Coupon = true;
        public bool Event = true;
        public bool Autosend = true;
        public bool Calendar = true;
        public bool SocialMedia = false;
        public bool Customdomain = false;
        public bool LiveChat = true;
        public bool PhoneSupport = true;
        public bool ContactManager = true;
        public int SelectedEmailsCount = 0;
        public int TotalEmailsCount = 0;
        public int SubPeriod = 0;
        public int RemainingMonths = 1;
        public string Expirationdate = string.Empty;
        public string UserPackage = string.Empty;
        public int PreviousAmount = 0;
        public int CurrentAmount = 0;
        public int TotalNoOfTools = 0;
        public string AffiliateID = string.Empty;
        public string EncryptAffilateID = string.Empty;
        public int UserPackegeNum = 0;
        public int PreviousPkgAmount = 0;
        public string UserPackageName = string.Empty;
        public string CurrentPackage = string.Empty;
        CommonBLL objCommon = new CommonBLL();
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
            if (!string.IsNullOrEmpty(Request.QueryString["PID"]))
            {
                ProfileID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["PID"].ToString()));
                if (Session["UserID"] != null)
                {
                    UserID = Convert.ToInt32(Session["UserID"].ToString());
                }
                else
                {
                    string urlinfo = RootPath + "/Login.aspx?sflag=1";
                    Response.Redirect(urlinfo);
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["AID"]))
            {
                EncryptAffilateID = Request.QueryString["AID"].ToString();
                AffiliateID = EncryptDecrypt.DESDecrypt(Request.QueryString["AID"].ToString().Replace("PLUS", "+").Replace("EQUAL", "="));
            }

            if (!IsPostBack)
            {
                if (Session["Tools"] != null)
                {
                    USPDHUBDAL.BusinessDAL.ToolsEntities tools = (USPDHUBDAL.BusinessDAL.ToolsEntities)Session["Tools"];
                    CurrentPackage = Enum.GetName(typeof(Packages), tools.PackageNumber);
                }
                if (ProfileID > 0)
                {
                    string imgurl = "~/images/Homepage/upgrade.png";
                    btnContinuePremiumPlus.ImageUrl = imgurl;
                    DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                    DataTable dt = objBus.GetOrderSubscriptionByProfileID(ProfileID);

                    if (dtProfile.Rows.Count > 0)
                    {
                        UserID = Convert.ToInt32(dtProfile.Rows[0]["User_ID"].ToString());
                        if (Session["Free"] == null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["Discount_Code"] != null && dt.Rows[0]["Discount_Code"].ToString() == "FreeTrial")
                                {
                                    CheckBasicMember();
                                }
                                else
                                {
                                    GetUserTools();
                                }
                            }
                            else
                                CheckBasicMember();
                        }
                        else
                            CheckBasicMember();
                    }
                    else
                        CheckBasicMember();
                }
                else
                    CheckBasicMember();

            }
        }

        private void CheckBasicMember()
        {
            string javaScript = "<script language=JavaScript>\n" +
                                    "GetTools();\n" +
                                "</script>";
            ClientScript.RegisterStartupScript(GetType(), "btnget_Click", javaScript);
        }

        private void GetUserTools()
        {
            GetSelectedTools();
        }

        private void GetSelectedTools()
        {
            DataTable dtSubscriptionDetails = new DataTable();
            dtSubscriptionDetails = objBus.Getorderidbyuserid(UserID);
            if (dtSubscriptionDetails.Rows.Count > 0)
            {
                DateTime renewalDate;
                string discountCode = string.Empty;
                renewalDate = Convert.ToDateTime(dtSubscriptionDetails.Rows[0]["subscription_renewal_date"].ToString());
                SubPeriod = Convert.ToInt32(dtSubscriptionDetails.Rows[0]["Subscription_period"].ToString());
                if (!string.IsNullOrEmpty(dtSubscriptionDetails.Rows[0]["Discount_Code"].ToString()))
                {
                    discountCode = dtSubscriptionDetails.Rows[0]["Discount_Code"].ToString();
                }
                if (renewalDate.Date > DateTime.Now.Date && discountCode != "FreeTrial")
                {
                    hdnRemainingdays.Value = "";
                    Expirationdate = renewalDate.ToShortDateString();
                    TimeSpan ts = renewalDate.AddDays(-1).Date.Subtract(DateTime.Now.Date);
                    hdnRemainingdays.Value = renewalDate.Date.Subtract(DateTime.Now.Date).Days.ToString();
                    TimeSpan usedDayts = DateTime.Now.Date.Subtract(Convert.ToDateTime(dtSubscriptionDetails.Rows[0]["CREATED_DT"].ToString()));
                    int usedDays = usedDayts.Days + 1;
                    decimal paidAmount = Convert.ToDecimal(dtSubscriptionDetails.Rows[0]["billable_Amount"].ToString());
                    if (usedDays > 0)
                    {
                        int totaldays = ts.Days + usedDays;
                        decimal userRemaingAmt = Math.Round((paidAmount * ts.Days / totaldays), 0, MidpointRounding.AwayFromZero);
                        hdnoldAmount.Value = userRemaingAmt.ToString();
                    }
                    DateTime date = DateTime.MinValue + ts;
                    RemainingMonths = date.Month - 1;
                    int remainingdays = date.Day - 1;
                    if (remainingdays > 0)
                        RemainingMonths += 1;
                    if (RemainingMonths <= 0)
                        RemainingMonths = 1;
                    DataTable dtSelectedTools = objBus.GetSelectedToolsByUserID(UserID);
                    if (dtSelectedTools.Rows.Count > 0)
                    {
                        UserPackage = dtSelectedTools.Rows[0]["Package_Number"] != null ? dtSelectedTools.Rows[0]["Package_Number"].ToString() : "";
                        if (UserPackage != "")
                        {
                            UserPackegeNum = Convert.ToInt32(UserPackage);
                            hdnSelcPkg.Value = UserPackegeNum.ToString();
                            PreviousPkgAmount = Convert.ToInt32(ConfigurationManager.AppSettings[hdnSelcPkg.Value]);
                            if (UserPackegeNum > 0)
                                UserPackageName = Enum.GetName(typeof(Packages), UserPackegeNum);
                        }
                    }
                }
            }
        }

        protected void btnContinue_Click(object sender, ImageClickEventArgs e)
        {
            string transactionQuery = string.Empty;
            USPDHUBDAL.BusinessDAL.ToolsEntities tools = new USPDHUBDAL.BusinessDAL.ToolsEntities();
            USPDHUBDAL.BusinessDAL.ToolsEntities updatedtools = new USPDHUBDAL.BusinessDAL.ToolsEntities();
            decimal discountPercent = 0.00M;
            if (hdnDiscountPercent.Value != "")
                discountPercent = Convert.ToDecimal(hdnDiscountPercent.Value);
            int freeEmails = Convert.ToInt32(ConfigurationManager.AppSettings.Get("FreeEmails"));
            if (hdnSelcPkg.Value == "5")
            {
                tools.PackageNumber = updatedtools.PackageNumber = 5;//*** if Selected package is Premium Plus ***//
                freeEmails = Convert.ToInt32(ConfigurationManager.AppSettings["PremiumEmails"]);
                transactionQuery = "INSERT INTO T_Transaction_History (Transaction_Tool,Transaction_TotalAmt,Transaction_Amount,Transaction_Discount,USER_ID,Transaction_Date) VALUES('Premium Plus',74.00," + Convert.ToDecimal(hdnAmount.Value) + "," + (discountPercent / 100) + ",#UserID#,#Date#)";
            }
            if (hdnSelcPkg.Value == "4")
            {
                tools.PackageNumber = updatedtools.PackageNumber = 4;//*** if Selected package is Premium ***//
                freeEmails = Convert.ToInt32(ConfigurationManager.AppSettings["PremiumEmails"]);
                transactionQuery = "INSERT INTO T_Transaction_History (Transaction_Tool,Transaction_TotalAmt,Transaction_Amount,Transaction_Discount,USER_ID,Transaction_Date) VALUES('Premium',54.00," + Convert.ToDecimal(hdnAmount.Value) + "," + (discountPercent / 100) + ",#UserID#,#Date#)";
            }
            else if (hdnSelcPkg.Value == "3")
            {
                tools.PackageNumber = updatedtools.PackageNumber = 3;//*** if Selected package is Pro ***//
                Calendar = false;
                transactionQuery = "INSERT INTO T_Transaction_History (Transaction_Tool,Transaction_TotalAmt,Transaction_Amount,Transaction_Discount,USER_ID,Transaction_Date) VALUES('Pro',39.00," + Convert.ToDecimal(hdnAmount.Value) + "," + (discountPercent / 100) + ",#UserID#,#Date#)";
            }
            else if (hdnSelcPkg.Value == "2")
            {
                tools.PackageNumber = updatedtools.PackageNumber = 2;//*** if Selected package is Plus ***//
                Coupon = false;
                Update = false;
                Event = false;
                Calendar = false;
                Autosend = false;
                transactionQuery = "INSERT INTO T_Transaction_History (Transaction_Tool,Transaction_TotalAmt,Transaction_Amount,Transaction_Discount,USER_ID,Transaction_Date) VALUES('Plus',17.00," + Convert.ToDecimal(hdnAmount.Value) + ",0.00,#UserID#,#Date#)";
            }
            else if (hdnSelcPkg.Value == "1")
            {
                tools.PackageNumber = updatedtools.PackageNumber = 1;//*** if Selected package is Basic ***//
                Website = false;
                Coupon = false;
                Update = false;
                Event = false;
                Calendar = false;
                Autosend = false;
                transactionQuery = "INSERT INTO T_Transaction_History (Transaction_Tool,Transaction_TotalAmt,Transaction_Amount,Transaction_Discount,USER_ID,Transaction_Date) VALUES('Basic',5.00," + Convert.ToDecimal(hdnAmount.Value) + ",0.00,#UserID#,#Date#)";
            }
            tools.IsWebsite = updatedtools.IsWebsite = Website;
            tools.IsContactManager = updatedtools.IsContactManager = ContactManager;
            tools.IsFlyers = updatedtools.IsFlyers = Flyer;
            tools.IsCoupon = updatedtools.IsCoupon = Coupon;
            tools.IsUpdate = updatedtools.IsUpdate = Update;
            tools.IsEventCalendar = updatedtools.IsEventCalendar = Event;
            tools.IsAutoSend = updatedtools.IsAutoSend = Autosend;
            tools.IsAppointmentCalendar = updatedtools.IsAppointmentCalendar = Calendar;
            tools.IsLiveChat = updatedtools.IsLiveChat = LiveChat;
            tools.IsPhoneSupport = updatedtools.IsPhoneSupport = PhoneSupport;
            tools.TotalEmails = updatedtools.TotalEmails = freeEmails;
            tools.SelectedEmailsCount = updatedtools.SelectedEmailsCount = 0;

            if (UserID > 0)
            {
                tools.UserID = UserID;
                updatedtools.UserID = UserID;
            }

            if (hdnAmount.Value != "")
                tools.Amount = hdnAmount.Value;
            else
                tools.Amount = tools.Amount = "0.00";
            if (hdnTotal.Value != "")
                tools.Total = hdnTotal.Value;
            else
                tools.Total = "0.00";

            tools.Discount = (Convert.ToDecimal(hdnTotal.Value) - Convert.ToDecimal(hdnAmount.Value)).ToString("0.00");


            tools.TransactionQuery = transactionQuery;
            Session["Tools"] = tools;
            updatedtools.Amount = hdnAmount.Value;
            updatedtools.Discount = "0.00";
            Session["Updatedtools"] = updatedtools;

            USPDHUBDAL.BusinessDAL.SubscriptionTypes objSubscriptions = new USPDHUBDAL.BusinessDAL.SubscriptionTypes();
            objSubscriptions.SubscriptionPrice = Convert.ToDecimal(hdnTotal.Value);
            objSubscriptions.BillableAmount = Convert.ToDecimal(hdnAmount.Value);
            objSubscriptions.DiscountAmount = Convert.ToDecimal(hdnTotal.Value) - Convert.ToDecimal(hdnAmount.Value);
            Session["PackageSubscriptions"] = objSubscriptions;

            if (ProfileID > 0)
            {
                if (hdnAmount.Value == "0.00")
                    Response.Redirect(RootPath + "/Business/MyAccount/Default.aspx");
                else
                    Response.Redirect(RootPath + "/Enhance.aspx?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString()) + "&U=T");
            }
            else
            {
                string str = string.Empty;
                str = RootPath + "/OP/" + DomainName + "/AgencyListing.aspx";
                Response.Redirect(str);
            }
        }
        protected void btn_Click(object sender, EventArgs e)
        {

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["tools"] = null;
            string redirectUrl = string.Empty;
            if (ProfileID > 0)
                redirectUrl = RootPath + "/Business/MyAccount/Default.aspx";
            else
                redirectUrl = RootPath + "/OP/" + DomainName + "/Default.aspx";
            Response.Redirect(redirectUrl);
        }
        enum Packages
        {
            Basic = 1,
            Plus,
            Pro,
            Premium,
            PremiumPlus
        }
    }
}