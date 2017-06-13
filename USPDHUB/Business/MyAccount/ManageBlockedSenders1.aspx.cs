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
    public partial class ManageBlockedSenders1 : System.Web.UI.Page
    {
        BusinessBLL objBus = new BusinessBLL();
        public int UserID = 0;
        DataTable dtobj = new DataTable();
        DataTable dttips = new DataTable();
        public int NewslettersCount = 0;
        public int C_UserID = 0;
        public int ProfileID = 0;
        public int SortDir = 0;
        public int TipsCount = 0;
        public DataTable dtpermissions = new DataTable();
        AgencyBLL agencyobj = new AgencyBLL();
        CommonBLL objCommon = new CommonBLL();
        public string DisplayFeedTip = "Feedback";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                UserID = Convert.ToInt32(Session["userid"]);

                if (Session["ProfileID"] != null)
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);
                C_UserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
            }
            btnBlockUsers.Attributes.Add("onclick", "javascript:return Confirmationbox(this.form,'2')");
            if (Session["VerticalDomain"].ToString().ToLower().Contains("uspdhub"))
                DisplayFeedTip = "Tips";
            if (!IsPostBack)
            {
                hdnsortdire.Value = "";
                hdnsortcount.Value = "0";
                hdnsortdir.Value = "";
                hdnsortcnt.Value = "0";
                filldata();
                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "AppSettings");
                }
            }
        }
        protected void grdNewsletercontacts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbldescription = e.Row.FindControl("lbldescription") as Label;
                string[] data = lbldescription.Text.Split('|');
                lbldescription.Text = data[3].ToString();
                CheckBox headerchk = (CheckBox)grdNewsletercontacts.HeaderRow.FindControl("chkSelectAllMsgs");
                CheckBox childchk = (CheckBox)e.Row.FindControl("chkMessages");
                childchk.Attributes.Add("onclick", "javascript:SelectMsgscheckboxes('" + headerchk.ClientID + "')");
            }
        }

        protected void grdNewsletercontacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdNewsletercontacts.PageIndex = e.NewPageIndex;
            filldata();
        }

        protected void filldata()
        {
            dtobj = objBus.GetMobileAppAlerts(true, UserID, 1);
            NewslettersCount = dtobj.Rows.Count;
            Session["DtMobileAppAlerts"] = dtobj;
            grdNewsletercontacts.DataSource = dtobj;
            grdNewsletercontacts.DataBind();

            dttips = objBus.GetMobileTips(true, UserID, 1);
            TipsCount = dttips.Rows.Count;
            Session["dttips"] = dttips;
            GrdTips.DataSource = dttips;
            GrdTips.DataBind();
        }
        protected void lnkcontactname_Click(object sender, EventArgs e)
        {
            
        }

        protected void lnktips_Click(object sender, EventArgs e)
        {
           
        }
        protected void GrdTips_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                
                Label lbldescription = e.Row.FindControl("lbldescription") as Label;
                string[] data = lbldescription.Text.Split('|');
                lbldescription.Text = data[3].ToString();
                CheckBox headerchk = (CheckBox)GrdTips.HeaderRow.FindControl("chkSelectAllTips");
                CheckBox childchk = (CheckBox)e.Row.FindControl("chkTips");
                childchk.Attributes.Add("onclick", "javascript:SelectTipscheckboxes('" + headerchk.ClientID + "')");
            }
        }

        protected void GrdTips_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdTips.PageIndex = e.NewPageIndex;
            filldata();
        }

        protected void GrdTips_Sorting(object sender, GridViewSortEventArgs e)
        {

            SortDir = Convert.ToInt32(hdnsortcnt.Value);
            string SortExp = e.SortExpression.ToString();
            DataTable dttips = (DataTable)Session["dttips"];
            if (hdnsortdir.Value != "")
            {
                if (hdnsortdir.Value != SortExp)
                {
                    hdnsortdir.Value = SortExp;
                    SortDir = 0;
                    hdnsortcnt.Value = "0";
                }
            }
            else
            {
                hdnsortdir.Value = SortExp;
            }
            DataView Dvtips = new DataView(dttips);
            if (SortDir == 0)
            {
                if (SortExp == "DateSent")
                {
                    Dvtips.Sort = "CREATED_DT ASC";
                }
                else if (SortExp == "Blocked")
                {
                    Dvtips.Sort = "Device_Blocked ASC";
                }
                hdnsortcnt.Value = "1";
            }
            else
            {
                if (SortExp == "DateSent")
                {
                    Dvtips.Sort = "CREATED_DT desc";
                }
                else if (SortExp == "Blocked")
                {
                    Dvtips.Sort = "Device_Blocked desc";
                }
                hdnsortcnt.Value = "0";
            }

            Session["dttips"] = Dvtips.ToTable();
            TipsCount = dttips.Rows.Count;
            GrdTips.DataSource = Dvtips;
            GrdTips.DataBind();

            DataTable DtMobileAppAlerts = (DataTable)Session["DtMobileAppAlerts"];
            NewslettersCount = DtMobileAppAlerts.Rows.Count;
            grdNewsletercontacts.DataSource = DtMobileAppAlerts;
            grdNewsletercontacts.DataBind();
        }
        //Added for Check All in Messages and Tips 
        protected void ChkSelectAllMsgsCheckedChanged(object sender, EventArgs e)
        {

        }
        protected void ChkSelectAllTipsCheckedChanged(object sender, EventArgs e)
        {

        }
        protected void ChkMessagesCheckedChanged(object sender, EventArgs e)
        {

        }
        protected void ChkTipsCheckedChanged(object sender, EventArgs e)
        {

        }
        protected void btnBlockUsers_Click(object sender, EventArgs e)
        {
            int totalBlockedCount = 0;
            int updatedCount = 0;
            foreach (GridViewRow gvrow in grdNewsletercontacts.Rows)
            {
                CheckBox chkblock = (CheckBox)gvrow.FindControl("chkMessages");
                if (chkblock.Checked)
                {
                    int messageID = Convert.ToInt32(grdNewsletercontacts.DataKeys[gvrow.RowIndex].Value);
                    int updateCount = objBus.BlockUnBlockMessageSenders(messageID, false, C_UserID);
                    totalBlockedCount += 1;
                    if (updateCount > 0)
                        updatedCount += 1;
                }
            }
            foreach (GridViewRow gvrow in GrdTips.Rows)
            {
                CheckBox chkblock = (CheckBox)gvrow.FindControl("chkTips");
                if (chkblock.Checked)
                {
                    int messageID = Convert.ToInt32(GrdTips.DataKeys[gvrow.RowIndex].Value);
                    int updateCount = objBus.BlockUnBlockMessageSenders(messageID, false, C_UserID);
                    totalBlockedCount += 1;
                    if (updateCount > 0)
                        updatedCount += 1;
                }
            }
            lblmsg.Text = "<font size='2' color='green'>" + Resources.LabelMessages.UnblockedAllSenders.ToString() + "<font>";
            filldata();
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/AppManagement.aspx"));
        }
    }
}