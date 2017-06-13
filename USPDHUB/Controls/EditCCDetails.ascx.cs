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
    public partial class EditCCDetails : System.Web.UI.UserControl
    {
        USPDHUBBLL.AdminBLL adminobj = new USPDHUBBLL.AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmsg.Visible = false;
            }

            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
            {
                lblerror.Text = "You have no privilages to update the credit card details, because your associated with another user.";
                PayButton.Visible = false;
            }
            else
            {
                PayButton.Visible = true;
                lblerror.Text = string.Empty;
            }

        }
        protected void PayButton_Click(object sender, EventArgs e)
        {
            //CC Details
            int orderID = Convert.ToInt32(Session["orderID"]);
            string CCNumber = EncryptDecrypt.DESEncrypt(txtcreditCardNumber.Text.Trim());
            string FirstName = txtfirstName.Text.Trim();
            string LastName = txtlastname.Text.Trim();
            int ExMonth = Convert.ToInt32(txtexpmonth.Text.Trim());
            int ExYear = Convert.ToInt32(txtexpyear.Text.Trim());
            string CCVNumber = EncryptDecrypt.DESEncrypt(Convert.ToString(txtcvv2Number.Text.Trim()));
            string CardType = Convert.ToString(ddlCardType.SelectedValue);

            //Billing Details
            string address1 = txtaddress1.Text.Trim();
            string address2 = txtaddress2.Text.Trim();
            string city = txtcity.Text.Trim();
            string state = DrpState.SelectedValue.ToString();
            string zipcode = txtzip.Text.Trim();

            string ResVal = string.Empty;
            string Amount = "1";
            string AuthType = "AUTH_ONLY";
            string CardExpDate = ExMonth.ToString() + ExYear.ToString();
            string PaymentType = "Card Valid";

            AuthorizedNet ObjAuthorized = new AuthorizedNet();
            ResVal = ObjAuthorized.AdvanceIntegrationForAuthorizedNet(CCNumber, CardExpDate, Amount, FirstName, LastName, address1, state, zipcode,
                PaymentType, CCVNumber, AuthType);

            if (ResVal == "1")
            {
                adminobj.UpdateCreditCardDetailsByUserID(Convert.ToInt32(Session["orderID"]), CCNumber, FirstName, LastName, ExMonth, ExYear,
                    CCVNumber, CardType, address1, address2, city, state, zipcode);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Validation", "alert('Your details successfully saved..');", true);
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "You have entered incorrect details. Please check the details once.";

                AjaxControlToolkit.ModalPopupExtender modal = this.Parent.FindControl("CCDetailsModalPopup") as AjaxControlToolkit.ModalPopupExtender;
                modal.Show();
            }

        }
        protected void btncancelcreditcard_Click(object sender, EventArgs e)
        {
            AjaxControlToolkit.ModalPopupExtender modal = this.Parent.FindControl("CCDetailsModalPopup") as AjaxControlToolkit.ModalPopupExtender;
            modal.Hide();
        }
    }
}