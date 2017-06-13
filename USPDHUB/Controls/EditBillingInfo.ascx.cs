using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using USPDHUBDAL;

namespace USPDHUB.Controls
{
    public partial class EditBillingInfo : System.Web.UI.UserControl
    {
        public int ProfileID = 0;

        BusinessBLL objBus = new BusinessBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            if (!IsPostBack)
            {
                DataTable dtSubscription = objBus.GetSubcription_PaymentCardDetails(ProfileID);
                if (dtSubscription.Rows.Count > 0)
                {
                    txtfirstName.Text = dtSubscription.Rows[0]["Firtst_Name"].ToString();
                    txtlastname.Text = dtSubscription.Rows[0]["LastName"].ToString();
                    txtaddress1.Text = dtSubscription.Rows[0]["Address1"].ToString();
                    txtaddress2.Text = dtSubscription.Rows[0]["Address2"].ToString();
                    txtcity.Text = dtSubscription.Rows[0]["City"].ToString();
                    ddlState.Items.FindByText(dtSubscription.Rows[0]["State"].ToString()).Selected = true;
                    txtzip.Text = dtSubscription.Rows[0]["Zipcode"].ToString();
                }
            }
        }

    }
}