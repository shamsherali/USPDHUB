using System;
using System.Linq;
using System.Configuration;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class AppManagement : BaseWeb
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public string EZSmartSiteUrl = string.Empty;
        public string Upgradeurl = string.Empty;

        public bool ShowBulletins = false;
        public string RootPath = "";
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        BusinessBLL objBus = new BusinessBLL();
        CommonBLL objCommon = new CommonBLL();
        public DataTable dtUserDetails = new DataTable();
        public bool IsSuperAdmin = true;
        public bool IsParent = true;
        public bool IsBranded = false;
        public bool IsBlockedSendAccess = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // *** Chcking for user session ***
                if (Session["UserID"] == null || Session["ProfileID"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                RootPath = Session["RootPath"].ToString();
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                Upgradeurl = "<a href=" + "\\'" + RootPath + "/Business/UpgradeTools.aspx?PID=" + EncryptDecrypt.DESEncrypt(ProfileID.ToString()) + "&U=T" + "\\'" + "><img src=" + "\\'" + RootPath + "/images/btn_upgrade1.gif" + "\\'" + " border=" + "\\'0\\' /></a>";
                if (!IsPostBack)
                {
                    if (Session["C_USER_ID"] != null)
                    {
                        dtUserDetails = objBus.GetUserDtlsByUserID(Convert.ToInt32(Session["C_USER_ID"]));
                        if (!string.IsNullOrEmpty(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"].ToString()))
                            IsSuperAdmin = Convert.ToBoolean(dtUserDetails.Rows[0]["IsAssociate_SuperAdmin"]);
                        IsBlockedSendAccess = objCommon.GetPermissionAccess(Convert.ToInt32(Session["C_USER_ID"]), PageNames.BLOCKEDSENDERS);
                    }

                    DataTable dtSelectedTools = objBus.GetSelectedToolsByUserID(UserID);
                    if (dtSelectedTools.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dtSelectedTools.Rows[0]["Package_Number"].ToString()))
                        {
                            if (Convert.ToInt32(dtSelectedTools.Rows[0]["Package_Number"].ToString()) > 4)
                                ShowBulletins = true;
                        }
                    }
                    DataTable dtProfiles = objBus.GetProfileDetailsByProfileID(ProfileID);
                    if (!string.IsNullOrEmpty(dtProfiles.Rows[0]["Parent_ProfileID"].ToString()))
                        IsParent = false;
                    if (Convert.ToBoolean(dtProfiles.Rows[0]["IsBranded_App"].ToString()))
                        IsBranded = true;


                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AppManagement.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
    }
}