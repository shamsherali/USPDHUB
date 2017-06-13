using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using USPDHUBDAL;

namespace USPDHUB.Business.MyAccount
{
    public partial class Thankyou : System.Web.UI.Page
    {

        public int UserID = 0;
        public int ProfileID = 0;
        public int CUserID = 0;
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommonBll = new CommonBLL();
        public int RequestType = 1;
        BusinessDAL.BillingInfo objBillingInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtConfigs = objCommonBll.GetVerticalConfigsByType(Session["VerticalDomain"].ToString(), "EmailAccounts");
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "EmailSupport")
                            hdnSupport.Value = row[1].ToString();
                    }
                }
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
                if (Request.QueryString["Type"] == null || Request.QueryString["Type"].ToString().Trim() == "" || Session["BillingInfo"] == null)
                    Response.Redirect("CheckStore.aspx");
                else
                    RequestType = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Request.QueryString["Type"].ToString()));

                if (!IsPostBack)
                {
                    objBillingInfo = (BusinessDAL.BillingInfo)Session["BillingInfo"];
                    lblOrderNum.Text = objBillingInfo.OrderID;
                    lblOrderTotal.Text = (Convert.ToDecimal(objBillingInfo.Total) - Convert.ToDecimal(objBillingInfo.Discount)).ToString();
                    lblOrderDate.Text = objCommonBll.ConvertToUserTimeZone(ProfileID).ToShortDateString();
                    string number = EncryptDecrypt.DESDecrypt(objBillingInfo.Number);
                    if (number.Length > 4)
                        lblPaidWith.Text = "############" + number.Substring(number.Length - 4);
                    else
                        lblPaidWith.Text = "############" + number;
                    number = "";
                    string billinginfo = "";
                    lblFirstName.Text = objBillingInfo.FirtstName;
                    billinginfo = objBillingInfo.FirtstName;
                    billinginfo = billinginfo + " " + objBillingInfo.LastName;
                    billinginfo = billinginfo + "<br/>" + objBillingInfo.Address1;
                    billinginfo = billinginfo + ", " + objBillingInfo.Address2;
                    billinginfo = billinginfo + "<br/>" + objBillingInfo.City;
                    billinginfo = billinginfo + ", " + objBillingInfo.State;
                    billinginfo = billinginfo + " " + objBillingInfo.Zipcode;
                    billinginfo = billinginfo + "<br/>United States";
                    lblBilling.Text = billinginfo;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "Thankyou.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
    }
}