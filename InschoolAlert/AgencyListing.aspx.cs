using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.Services;
using System.Text.RegularExpressions;
using USPDHUBBLL;


namespace InschoolAlert
{
    public partial class AgencyListing : System.Web.UI.Page
    {
        BusinessBLL _objBusiness = new BusinessBLL();
        AgencyBLL _objAgency = new AgencyBLL();
        CommonBLL _objCommon = new CommonBLL();
        public static string Country = "United States";
        public static string Vertical = "inschoolhub";
        public static string SubVertical = "inschoolalert";
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["VerticalDomain"] = "inschoolalertcom";
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
                            int checkUser = _objBusiness.CheckUserNameandPasswordForVaildUser(txtEmail.Text.Trim(), Vertical, Country);
                            int checkAgency = _objAgency.ValidateAgencyEmailID(txtEmail.Text.Trim(), Vertical, Country);
                            bool isPromo = true;

                            int inquiryId = 0;
                            int? parentProfileID = null;
                            if (checkUser == 0)
                            {
                                if (checkAgency == 0)
                                {
                                    if (isPromo)
                                    {
                                        inquiryId = InsertAgencyDetails(parentProfileID);
                                        if (inquiryId > 0)
                                        {
                                            _objAgency.UpdateLiteVersion(inquiryId, 1); // *** @FlagType = 1 means new registration ***  //
                                            string urlRedirect = ConfigurationManager.AppSettings.Get("ShoppingCartRootPath") + "/Checkout/EnhanceSubcription.aspx?InqID=" + EncryptDecrypt.DESEncrypt(inquiryId.ToString()) + "&Type=" + EncryptDecrypt.DESEncrypt("10000") + "&VC=" + EncryptDecrypt.DESEncrypt(Session["VerticalDomain"].ToString()) + "&Username=" + EncryptDecrypt.DESEncrypt(txtEmail.Text.Trim()) + "&IsLiteVersion=" + EncryptDecrypt.DESEncrypt("true");
                                            Response.Redirect(urlRedirect);
                                        }
                                        else
                                            lblErrorMSG.Text = "<font color=red>A problem has been occurred while submitting the data. <br/>Please email us at support@inschoolhub.com or Call us at 1-800-281-0263 Monday - Friday 8 a.m. - 5 p.m. PST</font>";
                                    }
                                    else
                                        lblErrorMSG.Text = "Please enter valid promo code.";
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
        private int InsertAgencyDetails(int? parentProfileID)
        {
            string date = string.Empty;
            string remarks = string.Empty;
            string title = string.Empty;

            int InquiryID = _objAgency.AddAgencyUser(txtAgencyname.Text, txtEmail.Text.Trim(), txtFirstName.Text.Trim(), "", date,
                remarks, 0, title, "", SubVertical, "", parentProfileID, null, txtLastName.Text.Trim(), Country, "",
                                        "", "", txtzipcode.Text.Trim());
            return InquiryID;
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
                        countUser = objWow.CheckUserNameandPasswordForVaildUser(emid, Vertical, Country);
                        int count = objAgency.ValidateAgencyEmailID(emid, Vertical, Country);
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
    }
}