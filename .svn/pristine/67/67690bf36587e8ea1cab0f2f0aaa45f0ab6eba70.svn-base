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
    public partial class DownloadManager : System.Web.UI.Page
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public int CUserID = 0;
        public bool IsAdmin = true;
        public string DomainName = "";        
        BusinessBLL objBus = new BusinessBLL();
        AgencyBLL objAgency = new AgencyBLL();
        CommonBLL objCommon = new CommonBLL();
        static InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public bool IsDownloadAccess = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                if (!IsPostBack)
                {
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    {
                        DataTable dtUser = objBus.GetUserDtlsByUserID(CUserID);
                        if (dtUser.Rows.Count > 0 && Convert.ToString(dtUser.Rows[0]["IsAssociate_SuperAdmin"].ToString()) != "")
                        {
                            if (Convert.ToBoolean(dtUser.Rows[0]["IsAssociate_SuperAdmin"].ToString()) == false)
                                IsAdmin = false;
                        }
                        bool installerFalg = false;
                        string Permission_Type = string.Empty;
                        Permission_Type = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Downloads");
                        if (Permission_Type == "P")
                        {
                            installerFalg = true;
                        }
                        IsDownloadAccess = installerFalg;
                    }
                    if (IsDownloadAccess == false)
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DownloadInstallers.aspx.cs", "Page_Load", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnTipsmanager_OnClick(object sender, EventArgs e)
        {
            try
            {
                DomainName = DomainName + "_DesktopAlerts.exe";
                string VirtualPath = Server.MapPath("~/Upload/DownloadInstallers/" + DomainName);
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + DomainName);
                Response.TransmitFile(VirtualPath);
            }
            catch (Exception ex)
            {
                objInBuiltData.ErrorHandling("ERROR", "DownloadInstallers.aspx.cs", "btnTipsmanager_OnClick", Convert.ToString(ex.Message),
                    Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}