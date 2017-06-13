using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ResellersBLL;
using System.Data;
using ResellerModels;
using System.Configuration;
using System.IO;

namespace Resellers
{
    public partial class SMBResellers : System.Web.UI.Page
    {
        InquiryBLL objInquiryBLL = new InquiryBLL();
        CommonBLL objCommonBLL = new CommonBLL();
        public string DomainName = "";

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
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    if (captcha.CheckCaptcha(txtcaptcha.Text.Trim()))
                    {
                        DataTable dtResellerInfo = objInquiryBLL.GetResellerInfo(hdnResellerName.Value);
                        if (dtResellerInfo.Rows.Count > 0)
                        {
                            Inquiry objInquiry = new Inquiry();
                            objInquiry.ResellerId = Convert.ToInt32(dtResellerInfo.Rows[0]["ResellerId"]);
                            objInquiry.Name = txtAgencyname.Text.Trim();
                            objInquiry.BusinessName = txtBusinessName.Text.Trim();
                            objInquiry.PhoneNumer = txtphonenumber.Text.Trim();
                            objInquiry.EmailAddress = txtEmail.Text.Trim();
                            objInquiry.City = txtCity.Text.Trim();
                            objInquiry.State = drpState.SelectedValue;
                            if (ddlDays.SelectedValue != "" && ddlDays.SelectedValue != "D")
                            {
                                //if (timePick.Value != "")
                                //    objInquiry.BestDayTime = ddlDays.SelectedValue + " " + timePick.Value;
                                objInquiry.BestDayTime = ddlDays.SelectedValue;
                            }
                            int inquryId = objCommonBLL.SaveResellerInquiry(dtResellerInfo, objInquiry, DomainName);
                            lblErrorMSG.Text = "<font color='green'>" + Resources.UserMessages.ReferralSubmitSuccess + "</font>";
                            txtAgencyname.Text = "";
                            txtBusinessName.Text = "";
                            txtphonenumber.Text = "";
                            txtEmail.Text = "";
                            txtCity.Text = "";
                            drpState.SelectedIndex = 0;
                            ddlDays.SelectedIndex = 0;
                            txtcaptcha.Text = "";
                            //timePick.Value = "";
                        }
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Javascript", "<script type='text/javascript'>LoadTimer()</script>", false);
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