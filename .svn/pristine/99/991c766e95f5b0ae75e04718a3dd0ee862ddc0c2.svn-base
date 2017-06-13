using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.Diagnostics;

namespace USPDHUB.Business.MyAccount
{
    public partial class SharedMediaHistory : System.Web.UI.Page
    {
        public int UserID = 0;
        SocialMediaAutoShareBLL obj = new SocialMediaAutoShareBLL();
        DataTable dtSharedHistory = new DataTable();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] != null)
                {
                    UserID = Convert.ToInt32(Session["userid"]);

                }
                if (!IsPostBack)
                {
                    FillSharedHistory();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SharedMediaHistory.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void FillSharedHistory()
        {
            try
            {
                dtSharedHistory = obj.GetSharedMediaHistory(UserID);
                gvSharedHistory.DataSource = dtSharedHistory;
                gvSharedHistory.DataBind();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SharedMediaHistory.aspx.cs", "FillSharedHistory", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnGoDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
        protected void gvSharedHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSharedHistory.PageIndex = e.NewPageIndex;
            FillSharedHistory();
        }
    }
}