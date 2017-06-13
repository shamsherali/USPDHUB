using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using UserFormsBLL;
using System.Text;
using System.Web.Services;

namespace UserForms
{
    public partial class Default : BaseWeb
    {
        string DomainName = "";
        CommonBLL objCommon = new CommonBLL();
        BusinessBLL objBus = new BusinessBLL();
        BulletinBLL objBulletinBLL = new BulletinBLL();
        AddOnBLL objAddOnBLL = new AddOnBLL();
        public int ProfileID = 0;
        public int UserID = 0;
        public int CUserID = 0;
        string RedirectUrl = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                DomainName = objCommon.CreateDomainUrl(url);
            }
            DomainName = Convert.ToString(Session["VerticalDomain"]);
            if (Request.QueryString["sflag"] != null)
                Response.Redirect(Convert.ToString(Session["RootPath"]) + "/OP/" + DomainName + "/Login.aspx?sflag=1");
            Session["C_USER_ID"] = null;
            Session["C_USER_NAME"] = null;
            if (Request.QueryString["PID"] != null && Request.QueryString["UID"] != null)
            {
                Session["UserID"] = UserID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["UID"])));
                Session["ProfileID"] = ProfileID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["PID"])));
                if (Request.QueryString["CUID"] != null)
                {
                    if (EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["CUID"])) != string.Empty)
                    {
                        CUserID = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["CUID"])));
                        if (UserID != CUserID)
                        {
                            Session["C_USER_ID"] = CUserID;
                            DataTable dtAssociate = new DataTable();
                            dtAssociate = objBus.GetUserDtlsByUserID(CUserID);
                            if (dtAssociate != null && dtAssociate.Rows.Count > 0)
                            {
                                Session["C_USER_NAME"] = dtAssociate.Rows[0]["Username"].ToString();
                                Session["C_FIRST_NAME"] = dtAssociate.Rows[0]["Firstname"].ToString();
                                Session["C_LAST_NAME"] = dtAssociate.Rows[0]["Lastname"].ToString();
                            }
                        }
                    }
                }

                DataTable dtobj = objBus.GetUserDetailsByID(UserID);
                if (dtobj.Rows.Count > 0)
                {
                    Session["username"] = dtobj.Rows[0]["Username"].ToString();
                    Session["Name"] = dtobj.Rows[0]["firstname"].ToString();
                }
                if (Request.QueryString["TempID"] != null)
                    Session["TemplateBID"] = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["TempID"])));


                if (Request.QueryString["BName"] != null)
                    Session["BulletinName"] = EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["BName"]));

                if (Request.QueryString["BID"] != null)
                    Session["BulletinID"] = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["BID"])));
                else
                    Session["BulletinID"] = Request.QueryString["BID"];

                if (Request.QueryString["CMID"] != null)
                    Session["CustomModuleID"] = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["CMID"])));

                Session["RoleID"] = (int)UtilitiesBLL.RoleTypes.Business;
                DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                Session["profilename"] = Convert.ToString(dtProfile.Rows[0]["profile_name"]);

                if (Request.QueryString["CMID"] != null)
                {
                    if (Request.QueryString["TempID"] != null)
                        Session["FormID"] = Convert.ToInt32(EncryptDecrypt.DESDecrypt(Convert.ToString(Request.QueryString["TempID"])));
                    DataTable dtCustomDetails = objAddOnBLL.GetBulletinCustomDetails(Convert.ToInt32(Session["TemplateBID"]));
                    RedirectUrl = Page.ResolveClientUrl("" + dtCustomDetails.Rows[0]["NavigationUrl"].ToString());
                    Session["BulletinCategoryName"] = dtCustomDetails.Rows[0]["CategoryName"];
                }
                else
                {
                    DataTable dtTemplateDetails = objBulletinBLL.GetBulletinTemplateDetails(Convert.ToInt32(Session["TemplateBID"]));
                    RedirectUrl = Page.ResolveClientUrl("" + dtTemplateDetails.Rows[0]["Template"].ToString());
                    Session["BulletinCategoryName"] = dtTemplateDetails.Rows[0]["BulletinCategoryName"];
                }
                Response.Redirect(RedirectUrl);
            }
        }
        [WebMethod]
        public static string GetUserTimeZoneDashboard()
        {
            CommonBLL objCommon = new CommonBLL();
            int profileIDforAJAX = Convert.ToInt32(System.Web.HttpContext.Current.Session["ProfileID"]);
            DateTime dtNow = objCommon.ConvertToUserTimeZone(profileIDforAJAX);
            return Convert.ToString(dtNow);
        }
    }

}