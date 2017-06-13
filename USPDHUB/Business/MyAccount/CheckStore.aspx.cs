using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class CheckStore : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int CUserID = 0;
        BusinessBLL objBus = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public bool IsSubApp = false;
        public bool IsBrandedApp = false;
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
                if (!IsPostBack)
                {
                    DataTable dtProfile = objBus.GetProfileDetailsByProfileID(ProfileID);
                    if (dtProfile.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dtProfile.Rows[0]["Parent_ProfileID"].ToString()))
                            IsSubApp = true;
                        else if (Convert.ToBoolean(dtProfile.Rows[0]["IsBranded_App"].ToString()))
                            IsBrandedApp = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "CheckStore.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}