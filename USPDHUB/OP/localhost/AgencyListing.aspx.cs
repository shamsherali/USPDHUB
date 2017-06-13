﻿using System;
using System.Configuration;
using USPDHUBBLL;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web;
using System.Data;
using System.Collections.Generic;

namespace USPDHUB.OP.localhost
{
    public partial class AgencyListing : System.Web.UI.Page
    {
        public string Email1 = string.Empty;
        public int ProfileID = 0;
        public string Address = string.Empty;
        public int AffiliateInvID = 0;
        public string GeneralTabInvID = string.Empty;
        public int UserID = 0;
        public string PromoCode = string.Empty;
        protected string RootPath = "";
        public string DomainName = "";
        CommonBLL objCommon = new CommonBLL();
        BusinessBLL objBus = new BusinessBLL();
        AgencyBLL objAgency = new AgencyBLL();
        public static string Country = "United States";
        public static string vertical = "localhost";
        public int promoDuration = 0;
        private string salesCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["AID"] != null && Request.QueryString["AID"].ToString() != "")
            {
                AffiliateInvID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["AID"].ToString().Replace("irhmalli", "=").Replace("irhPASS", "+")));
            }
            if (Request.QueryString["SC"] != null && Request.QueryString["SC"].ToString() != "")
            {
                salesCode = Request.QueryString["SC"].ToString();
            }
            if (Session["VerticalDomain"] != null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            if (!IsPostBack)
            {
                if (AffiliateInvID > 0)
                {
                    pnlParent.Visible = true;
                    txtPromoCode.Enabled = false;
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
                    DataTable dtAffiliate = objAgency.GetInvitationDetailsByID(AffiliateInvID);
                    if (dtAffiliate.Rows.Count > 0)
                    {
                        if ((Convert.ToBoolean(dtAffiliate.Rows[0]["IsValid"].ToString())) && (Convert.ToBoolean(dtAffiliate.Rows[0]["IsActivated"].ToString()) == false))
                        {
                            hdnProfileID.Value = dtAffiliate.Rows[0]["Parent_ProfileID"].ToString();
                            hdnIsPaid.Value = dtAffiliate.Rows[0]["IsPaid"].ToString();
                            txtEmail.Text = dtAffiliate.Rows[0]["Email_Address"].ToString();
                            lblParent.Text = dtAffiliate.Rows[0]["Profile_name"].ToString();
                        }
                        else
                        {
                            string status = "1"; // *** 1 means affiliate invitation has been cancelled *** //
                            if (Convert.ToBoolean(dtAffiliate.Rows[0]["IsActivated"].ToString()))
                                status = "2";
                            Response.Redirect(secureRootPath + "/Business/AffiliateStatus.aspx?AID=" + Request.QueryString["AID"].ToString() + "&sts=" + status);
                        }
                    }
                    else
                        Response.Redirect(secureRootPath + "/OP/" + DomainName + "/AgencyListing.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    if (txtEmail.Text.Contains(".lv") == false)
                    {
                        if (captcha.CheckCaptcha(txtcaptcha.Text.Trim()))
                        {

                            int checkUser = objBus.CheckUserNameandPasswordForVaildUser(txtEmail.Text.Trim(), vertical, Country);
                            int checkAgency = objAgency.ValidateAgencyEmailID(txtEmail.Text.Trim(), vertical, Country);
                            ////*DataTable dtPromocodeDetails = new DataTable("promocode");
                            ////*PromoCode = txtPromoCode.Text.Trim();
                            int? parentProfileID = null;
                            ////*int promoPercent = 0;

                            string date = string.Empty;
                            if (checkUser == 0)
                            {
                                if (checkAgency == 0)
                                {
                                    if (AffiliateInvID > 0)
                                        parentProfileID = Convert.ToInt32(hdnProfileID.Value);//checkParentProfile
                                    //if (PromoCode != string.Empty)
                                    //{
                                    //    dtPromocodeDetails = objAgency.CheckPromoCode(PromoCode, "uspdhub", true);
                                    //    if (dtPromocodeDetails.Rows.Count > 0)
                                    //    {
                                    //        promoPercent = Convert.ToInt32(dtPromocodeDetails.Rows[0]["Promocode_Value"]);
                                    //        if (!string.IsNullOrEmpty(dtPromocodeDetails.Rows[0]["Duration"].ToString()))
                                    //            promoDuration = Convert.ToInt32(dtPromocodeDetails.Rows[0]["Duration"].ToString());
                                    //    }
                                    //    else
                                    //    {
                                    //        lblErrorMSG.Text = "Please enter valid promo code.";
                                    //        PromoCode = string.Empty;
                                    //        return;
                                    //    }
                                    //}
                                    if (txtStartDate.Text != "" && txtStartDate.Text != null)
                                    {
                                        if (ddlHours.SelectedIndex > 0 && ddlMints.SelectedIndex > 0)
                                            date = txtStartDate.Text + " " + ddlHours.SelectedValue + ":" + ddlMints.SelectedValue;
                                    }
                                    int inquiryID = objAgency.AddAgencyUser(salesCode, txtAgencyname.Text, txtEmail.Text.Trim(), txtFirstName.Text.Trim(), txtphonenumber.Text, date, txtRemarks.Text.Trim(), 0, txtTitle.Text.Trim(), ddlHow.SelectedValue, vertical, PromoCode, parentProfileID, AffiliateInvID == 0 ? (int?)null : AffiliateInvID, "", Country);
                                    if (inquiryID > 0)
                                    {
                                        if (parentProfileID == null)
                                        {
                                            SendregistrationEmail(txtEmail.Text);
                                            SendAgencyInformation(date);
                                            Response.Redirect(RootPath + "/Business/OrderCompleted.aspx");
                                        }
                                        else
                                        {
                                            InsertUserDetails(inquiryID, parentProfileID, salesCode);
                                        }
                                    }
                                    else
                                        lblErrorMSG.Text = "<font color=red>A problem has been occurred while submitting the data. <br/>Please email us at support@uspdhub.com or Call us at 1-800-281-0263 Monday - Friday 8 a.m. - 5 p.m. PST</font>";
                                }
                                else
                                    lblUserNameCheck.Text = "<font color=red>Email address is already associated with another user.</font>";
                            }
                            else
                                lblUserNameCheck.Text = "<font color='red'>This email address is already in use, please enter different email address.</font>";
                        }
                        else
                            lblErrorMSG.Text = "<font color='red'>Please enter valid security code.</font>";
                    }
                    else
                    {
                    }
                    Random ran = new Random();
                    img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
                }
            }
            catch (Exception /*ex*/)
            {
                Random ran = new Random();
                img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
            }
        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(RootPath + "/OP/" + DomainName + "/Default.aspx");
        }
        private void InsertUserDetails(int inquiryId, int? parentProfileID,string salesCode)
        {
            int profileID = 0;
            int userID = 0;
            string username = "";
            int subPeriod = 12;
            decimal totalAmt = 0.00M;
            decimal billableAmt = 0.00M;
            decimal discount = 0.00M;
            decimal renewal = 0.00M;
            string password = objCommon.GenerateRandomPassword();

            profileID = objAgency.InsertNewSubcriptionUserDetails(0, 0, EncryptDecrypt.DESEncrypt(password), inquiryId, Convert.ToInt32(ProfileSubscriptionTypes.Premium));
            DataTable dtuserdetails = objBus.GetuserdetailsByProfileID(profileID);

            #region  // Parent Logo Copy to Sub APP Account

            if (parentProfileID != null)
            {
                if (parentProfileID != 0)
                {
                    objCommon.ParentLogoCopyToSubApp(Convert.ToInt32(parentProfileID), profileID, Convert.ToInt32(dtuserdetails.Rows[0]["User_ID"]));
                }
            }
            #endregion

            Session["ProfileID"] = profileID;
            username = txtEmail.Text.Trim();
            if (dtuserdetails.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dtuserdetails.Rows[0]["Username"].ToString()))
                    username = dtuserdetails.Rows[0]["Username"].ToString();
                userID = Convert.ToInt32(dtuserdetails.Rows[0]["User_ID"]);
            }
            #region Insert Tranaction Details (SubcriptionTypes Table)
            int subscriptionID = objBus.InsertUserSubscriptions(profileID, userID, subPeriod, totalAmt, discount, billableAmt, "", "", "", "", "", "", "", "", "", 0, 0, "", "", "", false);

            //Affilates Records
            DataTable dtInviationCodes = objAgency.GetInvitatioCodeDetailsByID(AffiliateInvID);
            totalAmt = discount = Convert.ToDecimal(dtInviationCodes.Rows[0]["Payment_Cost"]);
            billableAmt = (totalAmt - discount);

            int SID = 0;
            DataTable dtSubcriptions = objBus.GetStoreItems("New", DomainName.ToString());
            for (int i = 0; i < dtSubcriptions.Rows.Count; i++)
            {
                // Non-Branded Amount Year
                if (Convert.ToString(dtSubcriptions.Rows[i]["Type"]).Trim() == string.Empty &&
                    Convert.ToString(dtSubcriptions.Rows[i]["Subscription_period"]) == "12")
                {
                    SID = Convert.ToInt32(dtSubcriptions.Rows[i]["Subscription_ID"]);
                    break;
                }
            }

            // Insert Transction Details
            int subcriptionTypeID = objBus.InsertTransaction(profileID, userID, subscriptionID, 10000,
                                   Convert.ToDecimal(discount), Convert.ToDecimal(billableAmt),
                                   Convert.ToDecimal(totalAmt), userID, subPeriod, DateTime.Now.AddMonths(subPeriod), "",
                                   "", "", "", "",
                                   "", "", "", "", "", "", "", Convert.ToInt32(RequestCustomFormTypes.NewRegistration), subPeriod, 0, 0, "", "", "", salesCode);

            //get affilcate renwal cost
            DataTable dtAffilateDetails = objBus.GetAffilatesInvitationDetailsbyPID(Convert.ToInt32(parentProfileID));
            renewal = Convert.ToDecimal(dtAffilateDetails.Rows[0]["Payment_Cost"]);

            //Insert Order Details
            DateTime createDate = DateTime.Now;
            DateTime renewalDate = createDate.AddMonths(subPeriod);
            int? promoCodeId = null;
            objBus.InsertOrderDetails(ProfileID, userID, subcriptionTypeID, SID, totalAmt, discount,
                      billableAmt, createDate, userID, createDate, renewalDate, Convert.ToInt32(RequestCustomFormTypes.NewRegistration), null, null,
                      subPeriod, "", Convert.ToDecimal(renewal), false, promoCodeId, salesCode);
            SendActivationEmail(username, password, "", DomainName);
            objCommon.SendRepresentationEmail(profileID, DomainName);
            Response.Redirect(RootPath + "/OP/" + DomainName + "/OrderCompleted.aspx?PID=" + EncryptDecrypt.DESEncrypt(profileID.ToString()));
            #endregion
        }

        private void InsertTransctionDetails(int InquiryId, int? parentProfileID)
        {
            try
            {
                AdminBLL objAdminBll = new AdminBLL();
                decimal totalAmt = 0.00M;
                decimal billableAmt = 0.00M;
                decimal discount = 0.00M;
                int subPeriod = 12;
                if (promoDuration > 0)
                    subPeriod = promoDuration;
                if (parentProfileID == null)
                {
                    totalAmt = Convert.ToDecimal(ConfigurationManager.AppSettings["uspdhubpkg"]) * subPeriod;
                    discount = totalAmt;
                }
                int orderID = objAdminBll.AddInquiryTransactions(InquiryId, subPeriod, totalAmt, discount, billableAmt, "", "", "", "", "", "", "", "", 0, 0, "", "", "United States", 0, false, "", true, PromoCode, "", false, null);

                string password = objCommon.GenerateRandomPassword();
                int profileId = objAgency.InsertUserDetails(0, 0, EncryptDecrypt.DESEncrypt(password), InquiryId);
                DataTable dtuserdetails = objBus.GetuserdetailsByProfileID(profileId);
                if (dtuserdetails.Rows.Count > 0)
                {
                    string username = dtuserdetails.Rows[0]["Username"].ToString();
                    Session["UName"] = username;
                }

                SendActivationEmail(Convert.ToString(Session["EmailID"]), password, "", DomainName);

                Response.Redirect(RootPath + "/OP/" + DomainName + "/OrderCompleted.aspx?PID=" + EncryptDecrypt.DESEncrypt(profileId.ToString()));
            }
            catch (Exception /*ex*/)
            {

            }
        }
        private void SendActivationEmail(string username, string password, string location, string verticalValue)
        {
            string vertRootPath = "";
            DataTable dtConfigs = objCommon.GetVerticalConfigsByType(verticalValue, "Paths");
            if (dtConfigs.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigs.Rows)
                {
                    if (row[0].ToString() == "RootPath")
                        vertRootPath = row[1].ToString();
                }
            }
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
                content = content + input + "<BR/>";
            }
            msgbody = msgbody.Replace("#RootUrl#", vertRootPath);
            msgbody = msgbody.Replace("#msgBody#", content);
            msgbody = msgbody.Replace("#Link#", "<a href='" + vertRootPath + "/OP/" + verticalValue + "/Login.aspx' target='_blank'>Login</a>");
            msgbody = msgbody.Replace("#Email#", username);
            msgbody = msgbody.Replace("#Password#", password);
            re.Close();
            re.Dispose();
            reDeclaimer.Close();
            reDeclaimer.Dispose();
            string ccemail = string.Empty;
            UtilitiesBLL utlobj = new UtilitiesBLL();
            utlobj.SendWowzzyEmail(FromEmailsupport, username, "Account Details", msgbody, ccemail, "", verticalValue);
        }
        [WebMethod]
        public static string ServerSidefill(string emid)
        {
            BusinessBLL objWow = new BusinessBLL();
            AgencyBLL objAgency = new AgencyBLL();

            string typevalue = "";
            if (emid.Length > 0)
            {
                Regex rEMail = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (!rEMail.IsMatch(emid))
                {
                    typevalue = "3";
                }
                else
                {
                    try
                    {
                        int countUser;
                        countUser = objWow.CheckUserNameandPasswordForVaildUser(emid, vertical, Country);
                        int count = objAgency.ValidateAgencyEmailID(emid, vertical, Country);
                        /*string s = "SELECT COUNT(SuperAdmin_ID) FROM T_Users WHERE Username='" + emid + "'";
                        SqlConnection sqlCon = USPDHUBDAL.ConnectionManager.Instance.GetSQLConnection();
                        SqlCommand sqlCmd = new SqlCommand(s, sqlCon);
                        int count = Convert.ToInt32(sqlCmd.ExecuteScalar().ToString());
                        USPDHUBDAL.ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
                        */
                        if (count > 0)
                            typevalue = "4";
                        else
                        {
                            if (countUser == 0)
                            {
                                typevalue = "1";
                            }
                            else
                            {
                                typevalue = "2";
                            }
                        }
                    }
                    catch
                    {
                        typevalue = "3";
                    }

                }
            }
            return typevalue;

        }
        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod]
        public static List<string> GetProfiles(string prefixText)
        {
            BusinessBLL objBus = new BusinessBLL();
            DataTable dt = objBus.GetParentProfiles(prefixText);
            List<string> Profiles = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Profiles.Add(dt.Rows[i]["Profile_name"].ToString());
            }
            return Profiles;

        }
        private void SendregistrationEmail(string email1)
        {
            string emailInfo = "";
            DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
            if (dtConfigsemails.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigsemails.Rows)
                {
                    if (row[0].ToString() == "EmailInfo")
                        emailInfo = row[1].ToString();
                }
            }
            string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
            StreamReader re = File.OpenText(strfilepath + "AgencyInquiry.txt");
            StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
            string msgbody = string.Empty;
            string content = string.Empty;
            string desclaimer = string.Empty;
            while ((desclaimer = reDeclaimer.ReadLine()) != null)
            {
                msgbody = msgbody + desclaimer;
            }
            desclaimer = "";
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                content = content + input + "<BR/>";
            }
            re.Close();
            msgbody = msgbody.Replace("#RootUrl#", RootPath);
            msgbody = msgbody.Replace("#msgBody#", content);
            msgbody = msgbody.Replace("#Link#", "<a href='" + RootPath + "/Login.aspx?UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "' target=_new>Login</a>");
            msgbody = msgbody.Replace("#AddLink#", RootPath + "/Login.aspx?UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()));
            msgbody = msgbody.Replace("#Email#", email1);
            msgbody = msgbody.Replace("#Password#", string.Empty);
            reDeclaimer = File.OpenText(strfilepath + "AgencyListingCC.txt");
            string ccemail = string.Empty;
            while ((desclaimer = reDeclaimer.ReadLine()) != null)
            {
                ccemail = ccemail + desclaimer;
            }
            re.Dispose();
            reDeclaimer.Close();
            reDeclaimer.Dispose();
            USPDHUBBLL.UtilitiesBLL utlobj = new USPDHUBBLL.UtilitiesBLL();
            utlobj.SendWowzzyEmail(emailInfo, email1, "Agency Details", msgbody, ccemail, "", DomainName);

        }
        private void SendAgencyInformation(string date)
        {
            string emailInfo = "";
            DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
            if (dtConfigsemails.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigsemails.Rows)
                {
                    if (row[0].ToString() == "EmailInfo")
                        emailInfo = row[1].ToString();
                }
            }
            string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + " \\";
            StreamReader re = File.OpenText(strfilepath + "USPDHubInquiry.txt");
            StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
            string msgbody = string.Empty;
            string content = string.Empty;
            string desclaimer = string.Empty;
            while ((desclaimer = reDeclaimer.ReadLine()) != null)
            {
                msgbody = msgbody + desclaimer;
            }
            desclaimer = "";
            string input = string.Empty;
            while ((input = re.ReadLine()) != null)
            {
                content = content + input + "<BR/>";
            }
            re.Close();
            msgbody = msgbody.Replace("#RootUrl#", RootPath);
            msgbody = msgbody.Replace("#msgBody#", content);
            msgbody = msgbody.Replace("#AgencyName#", txtAgencyname.Text.Trim());
            msgbody = msgbody.Replace("#Name#", txtFirstName.Text.Trim());
            msgbody = msgbody.Replace("#Title#", txtTitle.Text.Trim());
            msgbody = msgbody.Replace("#HowIKnow#", ddlHow.SelectedValue);
            msgbody = msgbody.Replace("#Phone#", txtphonenumber.Text);
            msgbody = msgbody.Replace("#Email#", txtEmail.Text.Trim());
            msgbody = msgbody.Replace("#DateTime#", date);
            msgbody = msgbody.Replace("#Remarks#", txtRemarks.Text.Trim());
            reDeclaimer = File.OpenText(strfilepath + "AgencyInfoEmails.txt");
            string toEmails = string.Empty;
            while ((desclaimer = reDeclaimer.ReadLine()) != null)
            {
                toEmails = toEmails + desclaimer;
            }
            re.Dispose();
            reDeclaimer.Close();
            reDeclaimer.Dispose();
            UtilitiesBLL utlobj = new UtilitiesBLL();
            utlobj.SendWowzzyEmail(emailInfo, toEmails, "New agency sign up", msgbody, "", "", DomainName);
        }
    }
}