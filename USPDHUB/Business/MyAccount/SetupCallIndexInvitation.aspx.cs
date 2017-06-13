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
    public partial class SetupCallIndexInvitation : System.Web.UI.Page
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public int CUserID = 0;
        public bool IsAdmin = true;
        public string DomainName = "";
        BusinessBLL objBus = new BusinessBLL();
        AgencyBLL objAgency = new AgencyBLL();
        CommonBLL objCommon = new CommonBLL();
        public bool IsDownloadAccess = true;
        public string RootPath = "";
        AddOnBLL objAddOn = new AddOnBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public int UserModuleID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }

                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();
                if (Session["CustomModuleID"] == null)
                { Response.Redirect(RootPath + "/Business/MyAccount/Default.aspx"); }
                UserModuleID = Convert.ToInt32(Session["CustomModuleID"]);
                if (!IsPostBack)
                {
                    hdnPrevioulUrl.Value = Request.UrlReferrer.ToString();
                    DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                    if (dtProfile.Rows.Count > 0)
                    {

                        hdnIsLiteVersion.Value = Convert.ToString(dtProfile.Rows[0]["IsLiteVersion"]);
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SetupCallIndexInvitation.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnSetupcontact_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(RootPath + "/Business/MyAccount/ManageCallIndexContacts.aspx?IsScr=1");
        }

        protected void btnSendInvitation_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(RootPath + "/Business/MyAccount/SendCallIndexInvitation.aspx");
        }

        protected void btnManageInvitation_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(RootPath + "/Business/MyAccount/ManageCallIndexInvitations.aspx");
        }
        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            //if (hdnPrevioulUrl.Value != "")
            //    Response.Redirect(hdnPrevioulUrl.Value);
            Response.Redirect(RootPath + "/Business/MyAccount/default.aspx");
        }
    }
}