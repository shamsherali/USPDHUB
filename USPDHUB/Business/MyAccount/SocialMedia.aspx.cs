using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Configuration;

namespace USPDHUB.Business.MyAccount
{
    public partial class SocialMedia : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;
        public static DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        BusinessBLL objBus = new BusinessBLL();
        public DataTable dtUserDetails = new DataTable();
        public bool IsSuperAdmin = true;
        public bool IsParent = true;
        public bool IsBranded = false;
        public bool IsBlockedSendAccess = true;
        CommonBLL objCommon = new CommonBLL();
        USPDHUBBLL.MobileAppSettings objApp = new USPDHUBBLL.MobileAppSettings();
        public string titleName = "";
        public string DomainName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblsuccess.Text = "";
                if (Session["UserName"] == null)
                    Response.Redirect(Page.ResolveClientUrl("~/login.aspx?sflag=1"));
                else
                {
                    UserID = Convert.ToInt32(Session["UserID"]);
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);

                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                        C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        C_UserID = UserID;
                }

                DomainName = Session["VerticalDomain"].ToString();
                titleName = objApp.GetMobileAppSettingTabName(UserID, "SocialMedia", DomainName);
                lblTitle.Text = titleName;

                if (!IsPostBack)
                {
                    lblOff.Visible = true;
                    if (objCommon.DisplayOn_OffSettingsContent(UserID, "SocialMedia"))
                    {
                        lblOn.Visible = true;
                        lblOff.Visible = false;
                    }


                    DataTable dtProfiles = objBus.GetProfileDetailsByProfileID(ProfileID);
                    if (!string.IsNullOrEmpty(dtProfiles.Rows[0]["Parent_ProfileID"].ToString()))
                        IsParent = false;

                    if (Convert.ToBoolean(dtProfiles.Rows[0]["IsBranded_App"].ToString()))
                        IsBranded = true;



                    if (Session["C_USER_ID"] != null)
                    {
                        dtUserDetails = objBus.GetUserDtlsByUserID(Convert.ToInt32(Session["C_USER_ID"]));
                        if (!string.IsNullOrEmpty(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"].ToString()))
                            IsSuperAdmin = Convert.ToBoolean(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"]);
                        IsBlockedSendAccess = objCommon.GetPermissionAccess(Convert.ToInt32(Session["C_USER_ID"]), PageNames.BLOCKEDSENDERS);
                    }

                    GetSocialMediavalues();

                    //roles & permissions..
                    //USPD-1107 Permission related Changes
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        //hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                        hdnSocialMediaPermission.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "SocialMedia");
                        //if (hdnPermissionType.Value == "A" || string.IsNullOrEmpty(hdnPermissionType.Value))
                        if (string.IsNullOrEmpty(hdnSocialMediaPermission.Value))
                        {
                            txtfacebook.Enabled = txttwitter.Enabled = btnSubmt.Enabled = false;
                            lblsuccess.Text = "<font face=arial size=2 color=red>You do not have permission to access social media.</font>";
                        }
                    }
                    //ends here
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SocialMedia.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public void GetSocialMediavalues()
        {
            try
            {
                DataTable dtpdesc = objBus.Getprofiledescription(ProfileID);
                if (dtpdesc.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtpdesc.Rows[0]["Facebook_Link"].ToString()))
                        txtfacebook.Text = dtpdesc.Rows[0]["Facebook_Link"].ToString();
                    else
                        txtfacebook.Text = "http://";
                    if (!string.IsNullOrEmpty(dtpdesc.Rows[0]["Twitter_Link"].ToString()))
                        txttwitter.Text = dtpdesc.Rows[0]["Twitter_Link"].ToString();
                    else
                        txttwitter.Text = "http://";
                    if (!string.IsNullOrEmpty(dtpdesc.Rows[0]["Youtube_Link"].ToString()))
                        txtYoutube.Text = dtpdesc.Rows[0]["Youtube_Link"].ToString();
                    else
                        txtYoutube.Text = "http://";
                    if (!string.IsNullOrEmpty(dtpdesc.Rows[0]["Instagram_Link"].ToString()))
                        txtInstagram.Text = dtpdesc.Rows[0]["Instagram_Link"].ToString();
                    else
                        txtInstagram.Text = "http://";
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SocialMedia.aspx.cs", "GetSocialMediavalues", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnSubmt_Click(object sender, EventArgs e)
        {
            try
            {
                string Facebooklink = string.Empty;
                string fbfanpagelink = string.Empty;
                string Linkdinlink = string.Empty;
                string TwitterLink = string.Empty;
                string youtubeLink = string.Empty;
                string instagramLink = string.Empty;
                if (txtfacebook.Text.Trim().Length > 7)
                    Facebooklink = txtfacebook.Text.Trim();

                if (txttwitter.Text.Trim().Length > 7)
                    TwitterLink = txttwitter.Text.Trim();

                if (txtYoutube.Text.Trim().Length > 7)
                    youtubeLink = txtYoutube.Text.Trim();

                if (txtInstagram.Text.Trim().Length > 7)
                    instagramLink = txtInstagram.Text.Trim();

                objBus.UpdateSocialNetworks(ProfileID, Facebooklink, fbfanpagelink, Linkdinlink, TwitterLink, youtubeLink, instagramLink, C_UserID);
                if (txtfacebook.Text.Trim() == "")
                    txtfacebook.Text = "http://";

                if (txttwitter.Text.Trim() == "")
                    txttwitter.Text = "http://";

                if (txtYoutube.Text.Trim() == "")
                    youtubeLink = "http://";

                if (txtInstagram.Text.Trim() == "")
                    instagramLink = "http://";

                lblsuccess.Text = "<font color=green>Your social media links have been submitted successfully.</font>";
                objBus.Insert_SilentPushMessages(ProfileID, DateTime.Now, false, 0, "SocialMedia", "Update");
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SocialMedia.aspx.cs", "btnSubmt_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
    }
}