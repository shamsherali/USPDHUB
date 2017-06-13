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
    public partial class ManageContentWidget : System.Web.UI.Page
    {
        public int ProfileID = 0;
        public int UserID = 0;
        public int CUserID = 0;
        public bool IsAdmin = true;
        public string DomainName = "";
        public string DomainNameenc = "";
        public string MemID = "";
        public string MemPID = "";
        public string CID = "";
        BusinessBLL objBus = new BusinessBLL();
        AgencyBLL objAgency = new AgencyBLL();
        CommonBLL objCommon = new CommonBLL();
        public bool IsDownloadAccess = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                MemID = EncryptDecrypt.DESEncrypt(UserID.ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                MemPID = EncryptDecrypt.DESEncrypt(ProfileID.ToString());
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    CUserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    CUserID = UserID;
                CID = EncryptDecrypt.DESEncrypt(CUserID.ToString());
                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                DomainNameenc = EncryptDecrypt.DESEncrypt(DomainName);
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
                if (IsAdmin == false)
                {
                    Response.Redirect("WebWidget.aspx");
                }
            }

        }
    }
}