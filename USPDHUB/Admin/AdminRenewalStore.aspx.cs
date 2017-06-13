using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Web.Services;
using System.Data;

namespace USPDHUB.Admin
{
    public partial class AdminRenewalStore : System.Web.UI.Page
    {
        string DomainName = "";
        CommonBLL objCommon = new CommonBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ProfileID"] != null)
                    hdnProfileID.Value = EncryptDecrypt.DESDecrypt(Request.QueryString["ProfileID"].ToString());
                if (Request.QueryString["SelectedValue"] != null)
                    Session["SelectedValue"] =  EncryptDecrypt.DESDecrypt(Request.QueryString["SelectedValue"].ToString());
                if (Request.QueryString["SelectedText"] != null)
                    Session["SelectedText"] = EncryptDecrypt.DESDecrypt(Request.QueryString["SelectedText"].ToString());
                if (Request.QueryString["MemID"] != null)
                    lblMemberID.Text = EncryptDecrypt.DESDecrypt(Request.QueryString["MemID"].ToString());
                if (Request.QueryString["ProfileName"] != null)
                    lblProfileName.Text = EncryptDecrypt.DESDecrypt(Request.QueryString["ProfileName"].ToString());
               
            }
        }

        // Loading Cart items
        [WebMethod(EnableSession = true)]
        public static List<USPDHUBBLL.CartList> GetProductsList(string pProfileID)
        {
            bool isRenewal = false;
            AdminBLL objAdmin = new AdminBLL();
            USPDHUBBLL.BusinessBLL objBusiness = new USPDHUBBLL.BusinessBLL();

            DataTable dt = new DataTable("Products");
            DataTable dtcount = new DataTable();
            // int packageid = (pPackageid != "") ? Convert.ToInt32(pPackageid) : 0;
            int profileid = (pProfileID != "") ? Convert.ToInt32(pProfileID) : 0;


            isRenewal = true;
            dt = objAdmin.GetStoreItems_Renewal(profileid);// get domain name from customer service page and pass it. static value for testing
            //  dtcount = objAdmin.GetPurchaseAddOnsCount(profileid);


            List<USPDHUBBLL.CartList> objlist = new List<USPDHUBBLL.CartList>();
            int Quantity = 1;
          
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                USPDHUBBLL.CartList cart = new USPDHUBBLL.CartList();
                cart.Subscription_ID = Convert.ToInt32(dt.Rows[i]["Subscription_ID"].ToString());
                cart.ItemTitle = dt.Rows[i]["Title"].ToString();
                cart.ItemDescription = dt.Rows[i]["Description"].ToString();
                cart.Quantity = Quantity;
                cart.Request_Type = Convert.ToInt32(dt.Rows[i]["Request_Type"].ToString());
                cart.Price = isRenewal ? dt.Rows[i]["Price"].ToString() : dt.Rows[i]["Subscription_Cost"].ToString();
                cart.Annual_Price = isRenewal ? dt.Rows[i]["Price"].ToString() : dt.Rows[i]["Annual_Price"].ToString();
                cart.ListName = dt.Rows[i]["listname"].ToString();
                cart.AccessType = dt.Rows[i]["AccessType"].ToString();
                cart.ToolTip = dt.Rows[i]["ToolTip"].ToString();
                string strType = dt.Rows[i]["Type"].ToString();
                string Store_Image_Icon = dt.Rows[i]["Store_Image_Icon"].ToString();
                cart.ImageUrl = "../Images/cart_images/" + Store_Image_Icon;
                cart.Renewal_Date = dt.Rows[i]["Renewal_Date"].ToString();
                cart.ModuleType = dt.Rows[i]["Type"].ToString();
                string strGroup_Name = dt.Rows[i]["Group_Name"].ToString();
                cart.Group_Name = strGroup_Name;
                if (dt.Columns.Contains("Monthly_Price"))
                    cart.Monthly_Price = dt.Rows[i]["Monthly_Price"].ToString();
                cart.AllowMultiple = Convert.ToBoolean(dt.Rows[i]["IsAllowMultiple"].ToString());
                if (dt.Columns.Contains("IsDefaultItem"))
                    cart.IsDefaultItem = Convert.ToBoolean(dt.Rows[i]["IsDefaultItem"]);
                if (dt.Columns.Contains("UserModuleID"))
                    cart.UserModuleID = Convert.ToInt32(dt.Rows[i]["UserModuleID"]);
                if (dt.Columns.Contains("Order_Details_ID"))
                    cart.OrderDetails_ID = Convert.ToInt32(dt.Rows[i]["Order_Details_ID"]);
                cart.Subscription_Period = Convert.ToInt32(dt.Rows[i]["Subscription_period"]);
                cart.IsPackageItem = Convert.ToBoolean(Convert.ToString(dt.Rows[i]["IsPackageItem"]));

                objlist.Add(cart);

            }
            return objlist;
        }

        [WebMethod(EnableSession = true)]
        public static string SaveCart_ProductList(object pExpiryDate, string pProfileID, List<USPDHUBBLL.CartList> pCartList)
        {

            USPDHUBBLL.BusinessBLL objBusiness = new USPDHUBBLL.BusinessBLL();
            HttpContext.Current.Session["CartList"] = pCartList;
            string result = "success";
            for (int i = 0; i < pCartList.Count; i++)
            {

                AdminBLL objAdmin = new AdminBLL();
                objAdmin.UpdatePackageItems(pCartList[i].UserModuleID, Convert.ToDateTime(pExpiryDate), Convert.ToInt32(pProfileID), 0, pCartList[i].OrderDetails_ID);

            }
            return result;
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string urlinfo = Page.ResolveClientUrl("~/Admin/CustomerServiceNew.aspx?SelectedValue=" + EncryptDecrypt.DESEncrypt(Session["SelectedValue"].ToString()) +"&SelectedText=" +EncryptDecrypt.DESEncrypt(Session["SelectedText"].ToString()));
            Response.Redirect(urlinfo);
        }
    }
}