using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LeadsBLL;
using System.Data;
using LeadsModels;
using System.Configuration;
using System.IO;

namespace LeadsApplication
{
    public partial class ContactInfo : System.Web.UI.Page
    {
        InquiryBLL objInquiryBLL = new InquiryBLL();
        CommonBLL objCommonBLL = new CommonBLL();
        public string DomainName = "";
        public string LogoName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommonBLL.CreateDomainUrl(url);
            }
            // *** Get Domain Name *** //
            DomainName = Session["VerticalDomain"].ToString();
            lblErrorMSG.Text = "";
            LogoName = DomainName + "logo.png";
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["camp"] != null && Convert.ToString(Request.QueryString["camp"]) != "")
                    {
                        hdnResellerName.Value = EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["camp"]));
                    }
                }
                catch (Exception ex)
                {
                    lblErrorMSG.Text = "<font color='red'>" + Resources.UserMessages.URLWrong + "</font>";
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int resellerId = 0;
                if (IsValid)
                {
                    if (captcha.CheckCaptcha(txtcaptcha.Text.Trim()))
                    {
                        DataTable dtResellerInfo = objInquiryBLL.GetResellerInfo(hdnResellerName.Value);
                        if (dtResellerInfo.Rows.Count > 0)
                        {
                            resellerId = Convert.ToInt32(dtResellerInfo.Rows[0]["ResellerId"]);
                        }
                        Inquiry objInquiry = new Inquiry();
                        objInquiry.ResellerId = resellerId;
                        objInquiry.ReferralURL = hdnResellerName.Value;
                        objInquiry.Name = txtAgencyname.Text.Trim();
                        objInquiry.BusinessName = txtBusinessName.Text.Trim();
                        objInquiry.PhoneNumer = txtphonenumber.Text.Trim();
                        objInquiry.EmailAddress = txtEmail.Text.Trim();
                        objInquiry.City = txtCity.Text.Trim();
                        objInquiry.State = drpState.SelectedValue;
                        if (ddlDays.SelectedValue != "" && ddlDays.SelectedValue != "D")
                        {
                            objInquiry.BestDayTime = ddlDays.SelectedValue;
                        }
                        int inquryId = objCommonBLL.SaveContactInquiry(dtResellerInfo, objInquiry, DomainName);
                        lblErrorMSG.Text = "<font color='green'>" + Resources.UserMessages.ReferralSubmitSuccess + "</font>";
                        txtAgencyname.Text = "";
                        txtBusinessName.Text = "";
                        txtphonenumber.Text = "";
                        txtEmail.Text = "";
                        txtCity.Text = "";
                        drpState.SelectedIndex = 0;
                        ddlDays.SelectedIndex = 0;
                        txtcaptcha.Text = "";
                    }
                    else
                        lblErrorMSG.Text = "<font color='red'>Please enter valid security code.</font>";
                }
                Random ran = new Random();
                img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
            }
            catch (Exception ex)
            {
                lblErrorMSG.Text = Resources.UserMessages.ReferralSubmitFailed;
                Random ran = new Random();
                img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
            }
        }
    }
}