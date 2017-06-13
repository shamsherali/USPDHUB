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
    public partial class ManageBlockedSenders : BaseWeb
    {
        BusinessBLL objBus = new BusinessBLL();
        AgencyBLL agencyobj = new AgencyBLL();
        CommonBLL objCommon = new CommonBLL();
        public int UserID = 0;
        DataTable dtobj = new DataTable();
        DataTable dttips = new DataTable();
        public int NewslettersCount = 0;
        public int C_UserID = 0;
        public int ProfileID = 0;
        public int SortDir = 0;
        public int TipsCount = 0;
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
            lblmsg.Text = "";
            btnUnblockUsers.Attributes.Add("onclick", "javascript:return Confirmationbox(this.form,'2')");
            if (Session["VerticalDomain"].ToString().ToLower().Contains("uspdhub"))
                DisplayFeedTip = "Tips";
            if (!IsPostBack)
            {
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    string Permission_Type = string.Empty;
                    Permission_Type = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "ManageMessageReceipt");
                    if (Permission_Type == "A")
                    {
                        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
                    }

                    //if (string.IsNullOrEmpty(hdnPermissionType.Value))
                    //{
                    //    UpdatePanel1.Visible = false;
                    //    UpdatePanel2.Visible = true;
                    //    lblerrormessage.Text = "<font face=arial size=2 color=red>You do not have permission to access app messages.</font>";
                    //}
                }
                filldata();
                //hdnsortdire.Value = "";
                //hdnsortcount.Value = "0";
                //hdnsortdir.Value = "";
                //hdnsortcnt.Value = "0";     

            }
        }

        protected void gvDevices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                GridView gvDevMessages = e.Row.FindControl("gvDevMessages") as GridView;
                gvDevMessages.DataSource = drv.CreateChildView("relation");
                gvDevMessages.DataBind();
                CheckBox headerchk = (CheckBox)gvDevices.HeaderRow.FindControl("chkSelectAllMsgs");
                CheckBox childchk = (CheckBox)e.Row.FindControl("chkMessages");
                childchk.Attributes.Add("onclick", "javascript:SelectMsgscheckboxes('" + headerchk.ClientID + "')");
            }
        }
        protected void gvMessages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbldescription = e.Row.FindControl("lbldescription") as Label;
                string[] data = lbldescription.Text.Split('|');
                lbldescription.Text = data[3].ToString();
            }
        }
        protected void filldata()
        {
            DataSet dsobj = objBus.GetBlockedUsers(ProfileID);
            if (dsobj.Tables.Count > 0 && dsobj.Tables[0].Rows.Count > 0)
            {
                DataRelation relation;
                DataColumn table1Column;
                DataColumn table2Column;
                //retrieve column 
                table1Column = dsobj.Tables[0].Columns["Device_ID"];
                table2Column = dsobj.Tables[1].Columns["Device_ID"];
                //relating tables 
                relation = new DataRelation("relation", table1Column, table2Column);
                //assign relation to dataset 
                dsobj.Relations.Add(relation);
            }
            gvDevices.DataSource = dsobj;
            gvDevices.DataBind();

        }
        protected void btnUnblockUsers_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow gvrow in gvDevices.Rows)
            {
                CheckBox chkblock = (CheckBox)gvrow.FindControl("chkMessages");
                if (chkblock.Checked)
                {
                    string deviceID = Convert.ToString(gvDevices.DataKeys[gvrow.RowIndex].Value);
                    /*** SmartConnect OR Messages ***/
                    Label lblModuleType = (Label)gvrow.FindControl("lblModuleType");


                    int updateCount = objBus.BlockUnBlockMessageSenders(deviceID, ProfileID, false, C_UserID, lblModuleType.Text.Trim());

                }
            }
            lblmsg.Text = "<font size='2' color='green'>" + Resources.LabelMessages.UnblockedAllSenders.ToString() + "<font>";
            filldata();
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
    }
}