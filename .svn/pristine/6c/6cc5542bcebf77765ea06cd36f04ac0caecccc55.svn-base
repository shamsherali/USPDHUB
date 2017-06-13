using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using USPDHUBBLL;
using AnetApi.Schema;
using System.Web.UI.WebControls;

namespace USPDHUB.Business.MyAccount
{
    public partial class ChangeBillingInformation : System.Web.UI.Page
    {
        BusinessBLL objBus = new BusinessBLL();
        public int UserID = 0;
        public int ProfileID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] != null && Session["UserID"].ToString() != "")
                {
                    UserID = Convert.ToInt32(Session["UserID"]);
                    if (Session["ProfileID"] != null)
                    {
                        ProfileID = Convert.ToInt32(Session["ProfileID"]);
                    }
                }
                else
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                if (!IsPostBack)
                {
                    FillBillingInfo();
                }
            }
            catch (Exception ex) { }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            objBus.InsertUpdateBillingInfo(txtfirstName.Text, txtlastname.Text, txtEmail.Text, txtaddress1.Text, txtaddress2.Text, txtcity.Text, txtState.Text.Trim(),
                                            txtzip.Text, UserID, ProfileID, 0, Convert.ToInt32(hdnAddress.Value));
            UpdateCustomerProfile(ProfileID, txtEmail.Text, txtaddress1.Text, txtaddress2.Text, txtcity.Text, txtState.Text.Trim(),
                                              txtzip.Text);
            lblBillEditMsg.Text = "<span style='color:green;'>Your billing information details have updated successfully.</span>";
        }

        public void FillBillingInfo()
        {
            DataTable dtBillingInfo = objBus.GetPaymentBillingInfo(ProfileID);
            if (dtBillingInfo.Rows.Count == 0)
            {
                DataTable dt = objBus.GetOrderSubscriptionByProfileID(ProfileID);
                DataTable dtUser = objBus.GetUserDetailsByUserID(UserID);

                txtfirstName.Text = dt.Rows[0]["cc_name"].ToString();
                txtlastname.Text = dt.Rows[0]["cc_lastname"].ToString();
                txtEmail.Text = dtUser.Rows[0]["Username"].ToString();
                txtVerBillingEmail.Text = dtUser.Rows[0]["Username"].ToString();
                txtaddress1.Text = dt.Rows[0]["billing_address1"].ToString();
                txtaddress2.Text = dt.Rows[0]["billing_address2"].ToString();
                txtcity.Text = dt.Rows[0]["billing_city"].ToString();
                txtState.Text = dt.Rows[0]["billing_state"].ToString();
                txtzip.Text = Convert.ToInt32(dt.Rows[0]["billing_zipcode"]).ToString();
            }
            else
            {
                txtfirstName.Text = dtBillingInfo.Rows[0]["FirstName"].ToString();
                txtlastname.Text = dtBillingInfo.Rows[0]["LastName"].ToString();
                txtEmail.Text = dtBillingInfo.Rows[0]["BillingEmail"].ToString();
                txtVerBillingEmail.Text = dtBillingInfo.Rows[0]["BillingEmail"].ToString();
                txtaddress1.Text = dtBillingInfo.Rows[0]["Address1"].ToString();
                txtaddress2.Text = dtBillingInfo.Rows[0]["Address2"].ToString();
                txtState.Text = dtBillingInfo.Rows[0]["City"].ToString();
                txtcity.Text = dtBillingInfo.Rows[0]["CityCapital"].ToString();
                txtzip.Text = Convert.ToInt32(dtBillingInfo.Rows[0]["Zipcode"]).ToString();
                hdnAddress.Value = dtBillingInfo.Rows[0]["AddressID"].ToString() == "" ? "0" : dtBillingInfo.Rows[0]["AddressID"].ToString();

            }

        }

        public void UpdateCustomerProfile(int ProfileID, string BillingEmail, string Address1, string Address2, string City, string State, string ZipCode)
        {
            AuthorizedNet objAuthorize = new AuthorizedNet();
            CommonBLL objCommonBLL = new CommonBLL();
            DataTable dtpaymentdetails = objBus.GetSubcription_PaymentCardDetails(ProfileID);
            if (dtpaymentdetails.Rows.Count > 0)
            {
                try
                {
                    long customerSubcriptionID = Convert.ToInt64(dtpaymentdetails.Rows[0]["CustomerSubscriptionID"]);
                    /*** Billing Email update ***/
                    //for updating billing email.
                    customerProfileMaskedType profile = GetCustomerProfile(customerSubcriptionID);
                    objAuthorize.UpdateCustomerProfile(profile, BillingEmail);

                    /*** for updating shipping address ***/
                    objAuthorize.UpdateCustomerAddress(Convert.ToInt64(profile.customerProfileId), Address1, Address2, City, State, ZipCode, hdnAddress.Value);
                }
                catch (Exception ex) {
                    objCommonBLL.InsertErrorLog("LOG", "UpdateCustomerProfile() -  Message: " + ex.Message, "", "", "", "ChangeBillingInformation.aspx.cs", "btnUpdate_Click");
                }
            }

        }
       
        public static customerProfileMaskedType GetCustomerProfile(long profile_id)
        {
            customerProfileMaskedType out_profile = null;

            getCustomerProfileRequest request = new getCustomerProfileRequest();
            XmlAPIUtilities.PopulateMerchantAuthentication((ANetApiRequest)request);
            request.customerProfileId = profile_id.ToString();

            System.Xml.XmlDocument response_xml = null;
            bool bResult = XmlAPIUtilities.PostRequest(request, out response_xml);
            object response = null;
            getCustomerProfileResponse api_response = null;

            if (bResult) bResult = XmlAPIUtilities.ProcessXmlResponse(response_xml, out response);
            if (!(response is getCustomerProfileResponse))
            {
                ANetApiResponse ErrorResponse = (ANetApiResponse)response;
                Console.WriteLine(String.Format("Retrieved Profile\n	 code: {0}\n	  msg: {1}", ErrorResponse.messages.message[0].code, ErrorResponse.messages.message[0].text));
                return out_profile;
            }
            if (bResult) api_response = (getCustomerProfileResponse)response;
            if (api_response != null)
            {
                out_profile = api_response.profile;
                Console.WriteLine("Retrieved Profile #" + profile_id);
                Console.WriteLine(String.Format("	 code: {0}\n	  msg: {1}", api_response.messages.message[0].code, api_response.messages.message[0].text));
            }

            return out_profile;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }

    }
}