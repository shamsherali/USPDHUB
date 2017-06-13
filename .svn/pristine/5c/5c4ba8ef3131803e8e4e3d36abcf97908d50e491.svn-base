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
    public partial class UpgradeModuleExpiryDate : System.Web.UI.Page
    {
        string DomainName = "";
        CommonBLL objCommon = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            string ProfileID = string.Empty;
            int UserID = 0;
            int subtype;

          
            //if (Request.QueryString["SubType"].ToString() != null)
            //    subtype = Convert.ToInt32(Request.QueryString["SubType"]);
            // 
            if (!IsPostBack)
            {
                if (Request.QueryString["ProfileID"].ToString() != null)
                    ProfileID = Request.QueryString["ProfileID"].ToString();
                if (Request.QueryString["UserId"].ToString() != null)
                    UserID = Convert.ToInt32(Request.QueryString["UserId"]);
                hdnProfileID.Value = ProfileID;

            }
            // hdnExpiryDate.Value = txtEndDate.Text;
        }

        // Loading Cart items
        [WebMethod(EnableSession = true)]
        public static List<USPDHUBBLL.CartList> getProductsList(string pIsSignup, string pProfileID)
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


                objlist.Add(cart);

            }
            return objlist;
        }

        [WebMethod(EnableSession = true)]
        public static string saveCart_ProductList(List<USPDHUBBLL.CartList> pcartlist, string ExpiryDate, string ProfileID)
        {

            USPDHUBBLL.BusinessBLL objBusiness = new USPDHUBBLL.BusinessBLL();
            HttpContext.Current.Session["CartList"] = pcartlist;
            string result = "success";
            for (int i = 0; i < pcartlist.Count; i++)
            {

                AdminBLL objAdmin = new AdminBLL();
                objAdmin.UpdatePackageItems(pcartlist[i].UserModuleID, Convert.ToDateTime(ExpiryDate), Convert.ToInt32(ProfileID), 0, pcartlist[i].OrderDetails_ID);
                
            }
            return result;
        }


        [WebMethod(EnableSession = true)]
        public static string helloworld(string a)
        {
            string result = a;

            return result;
        }
    }
}