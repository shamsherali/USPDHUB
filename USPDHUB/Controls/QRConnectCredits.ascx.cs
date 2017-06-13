using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB.Controls
{
    public partial class QRConnectCredits : System.Web.UI.UserControl
    {
        CommonBLL objCommon = new CommonBLL();
        PrivateSmartConnectBLL objPSC = new PrivateSmartConnectBLL();

        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;
        public string DomainName = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            // ** Get Domain Name ** //
            DomainName = Session["VerticalDomain"].ToString();
            //RootPath = Session["RootPath"].ToString();

            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            C_UserID = UserID;


            DisplayUsageCreditsCount();
        }


        /*** Showing Total Credits - Usage Credits - ReamingQuntity ***/
        private void DisplayUsageCreditsCount()
        {
            DataTable dtUsageCredits = objPSC.GetQRConnectCredits_Usage_Details(ProfileID);
            if (dtUsageCredits.Rows.Count > 0)
            {
                lblTotal.Text = dtUsageCredits.Rows[0]["PurchaseAddOns"].ToString();
                lblSent.Text = dtUsageCredits.Rows[0]["SoldAddOns"].ToString();
                lblRemaining.Text = dtUsageCredits.Rows[0]["ReamingQuntity"].ToString();
            }

            // -- dtUsageCredits.Rows[0]["SoldAddOns"] -- dtUsageCredits.Rows[0]["ReamingQuntity"]
        }

        public bool IsCountsUpdate
        {
            set
            {
                if (value)
                {
                    ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                    DisplayUsageCreditsCount();
                }
            }
        }

        protected void lnkBuyMoreSMS1_OnClick(object sender, EventArgs e)
        {
            BusinessBLL objBus = new BusinessBLL();
            DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
            string packageID = EncryptDecrypt.DESEncrypt(dtProfile.Rows[0]["ProfileSubTypeID"].ToString());

            string redirectUrl = System.Configuration.ConfigurationManager.AppSettings["ShoppingCartRootPath"] + "/RedirectStore.aspx?MID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "&MPID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString()) + "&CID=" + EncryptDecrypt.DESEncrypt(C_UserID.ToString()) + "&VC=" + EncryptDecrypt.DESEncrypt(DomainName) + "&PackID=" + packageID;
            Response.Redirect(redirectUrl);

        }

    }
}