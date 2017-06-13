using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;

namespace USPDHUB.Business.MyAccount
{
    public partial class AutoSharing : System.Web.UI.Page
    {
        public string RootPath = "";
        public string DomainName = "";
        public int C_UserID = 0;
        public int UserID = 0;
        public int ProfileID = 0;

        public DataTable dtExistingFbUsersData = null;
        public DataTable dtExistingTwrUsersData = null;
        public SocialMediaAutoShareBLL fop = new SocialMediaAutoShareBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null)
                    Response.Redirect(Page.ResolveClientUrl("~/Login.aspx?sflag=1"));
                else
                {
                    UserID = Convert.ToInt32(Session["UserID"].ToString());
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                        C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        C_UserID = UserID;
                }
                DomainName = Session["VerticalDomain"].ToString();  // *** Get Domain Name *** //
                RootPath = Session["RootPath"].ToString();

                if (!IsPostBack)
                {
                    dtExistingFbUsersData = fop.GetExistingUserData(ProfileID); // Get Data After Details stored to DB
                    if (dtExistingFbUsersData.Rows.Count > 0)
                    {
                        ltrlFacebook.Text = "<img src='../../Images/Dashboard/Configured.png' alt='Configured'/>";
                        lnkFacebookStatus.Visible = true;
                    }
                    //else
                    //    ltrlFacebook.Text = "<img src='../../Images/Dashboard/NotConfigured.png'/>";

                    dtExistingTwrUsersData = fop.GetTwitterDataByUserID(ProfileID);
                    if (dtExistingTwrUsersData.Rows.Count > 0)
                    {
                        ltrlTwitter.Text = "<img src='../../Images/Dashboard/Configured.png' alt='Configured'/>";
                        lnkTwitterStatus.Visible = true;
                    }
                    //else
                    //    ltrlTwitter.Text = "<img src='../../Images/Dashboard/NotConfigured.png'/>";


                    if (Request.QueryString["fbRemove"] != null && Request.QueryString["fbRemove"] != "")
                    {
                        if (Convert.ToInt32(Request.QueryString["fbRemove"]) == 1)
                            lblMsg.Text = "<span style='color:green;'>Your facebook account has been removed successfully.</span>";
                    }
                    if (Request.QueryString["TwrRemove"] != null && Request.QueryString["TwrRemove"] != "")
                    {
                        if (Convert.ToInt32(Request.QueryString["TwrRemove"]) == 1)
                            lblMsg.Text = "<span style='color:green;'>Your twitter account has been removed successfully.</span>";
                    }
                    dtExistingFbUsersData = fop.GetExistingUserData(ProfileID);
                    if (dtExistingFbUsersData.Rows.Count == 0)
                        hdnIsAuth.Value = "false";
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AutoSharing.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkFacebook_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/AutoShareFacebook.aspx"));
        }
        protected void lnkTwitter_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/AutoShareTwitter.aspx"));
        }
        protected void lnkFacebookStatus_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/StatusReports.aspx?MediaType="+EncryptDecrypt.DESEncrypt("Facebook")));
        }
        protected void lnkTwitterStatus_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/StatusReports.aspx?MediaType=" + EncryptDecrypt.DESEncrypt("Twitter")));
        }
    }
}