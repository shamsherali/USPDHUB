using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class PrintInquiries : System.Web.UI.Page
    {
        BusinessBLL objBus = new BusinessBLL();
        public int UserID = 0;
        public int C_UserID = 0;
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public int ProfileID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                if (Session["userid"] != null)
                {
                    UserID = Convert.ToInt32(Session["userid"]);

                    if (Session["ProfileID"] != null)
                        ProfileID = Convert.ToInt32(Session["ProfileID"]);

                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                        C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        C_UserID = UserID;
                }
                if (!IsPostBack)
                {
                    if (Request.QueryString["CID"].ToString() != null && Request.QueryString["CID"].ToString() != "")
                    {
                        if (Request.QueryString["Type"].ToString() != null && Request.QueryString["Type"].ToString() != "")
                        {
                            ShowInquiryDetails(Convert.ToInt32(Request.QueryString["CID"].ToString()), Request.QueryString["Type"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "PrintInquiries.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void ShowInquiryDetails(int userContactID, string inquiryType)
        {
            try
            {
                cleardata();
                DataTable dtInquiryDetails = new DataTable();
                dtInquiryDetails = objBus.SelectInquiryAlerts(UserID, userContactID);
                if (inquiryType == "BL")
                    lblmess.Text = "Bulletins:";
                else if (inquiryType == "BU")
                    lblmess.Text = "Content Module:";
                else if (inquiryType == "EC")
                    lblmess.Text = "EventCalendar:";
                else if (inquiryType == "CA")
                    lblmess.Text = "Calendar AddOn:";

                if (dtInquiryDetails.Rows.Count > 0)
                {
                    lblfn.Text = dtInquiryDetails.Rows[0]["First_Name"].ToString() + dtInquiryDetails.Rows[0]["Last_Name"].ToString();
                    lblemail.Text = dtInquiryDetails.Rows[0]["User_Email"].ToString();
                    lblphone.Text = dtInquiryDetails.Rows[0]["User_Phone"].ToString();
                    lbldescription.Text = dtInquiryDetails.Rows[0]["Description"].ToString();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "PrintInquiries.aspx.cs", "ShowInquiryDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void cleardata()
        {
            lbldescription.Text = lblemail.Text = "";
            lblphone.Text = "";
            lblfn.Text = "";
        }
    }
}