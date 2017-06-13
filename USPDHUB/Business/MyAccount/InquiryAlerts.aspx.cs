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
    public partial class InquiryAlerts : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;
        public int BulletinsCount = 0;
        public int UpdatesCount = 0;
        public int EventCalendarCount = 0;
        public int CalendarAddOnCount = 0;
        DataTable dtobj = new DataTable();
        BulletinBLL objBulletin = new BulletinBLL();
        CommonBLL objCommon = new CommonBLL();
        BusinessBLL objBus = new BusinessBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                UserID = Convert.ToInt32(Session["userid"]);
                if (Session["ProfileID"] != null)
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    C_UserID = UserID;
            }
            btnDelete.Attributes.Add("onclick", "javascript:return Confirmationbox(this.form,'1')");


            if (!IsPostBack)
            {
                //roles & permissions..
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                {
                    hdnPermissionType.Value = "";
                    hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "ManageMessageReceipt");

                    if (hdnPermissionType.Value == "A")
                    {
                        UpdatePanel1.Visible = false;
                        UpdatePanel2.Visible = true;
                        lblerrormessage.Text = "<font face=arial size=2 color=red>You do not have permission to access email messages.</font>";
                        return;
                    }
                }


                filldata();
                FillCannedMessages();
                BindMessageTitles();
            }
        }

        private void FillCannedMessages()
        {
            DataTable dtCannedMessage = objBus.GetAllCannedMessages(ProfileID);
            rbCList.DataSource = dtCannedMessage;
            rbCList.DataTextField = "MessageText";
            rbCList.DataValueField = "MessageText";
            rbCList.DataBind();

        }
        private void BindMessageTitles()
        {
            lblBulletins.Text = objCommon.GetTabNameByType(UserID, "Bulletins");
            lblEventCalendar.Text = objCommon.GetTabNameByType(UserID, "EventCalendar");
        }
        protected void grdNewsletercontacts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblcreatedDate = e.Row.FindControl("lblCreateddate") as Label;
                if (Convert.ToString(dtobj.Rows[e.Row.RowIndex]["Created_Date"].ToString()) != "")
                {
                    DateTime dtCreatedDate = Convert.ToDateTime(dtobj.Rows[e.Row.RowIndex]["Created_Date"].ToString());
                    lblcreatedDate.Text = dtCreatedDate.ToShortDateString();
                }
                else
                    lblcreatedDate.Text = "";
                LinkButton lnk = e.Row.FindControl("lnkcontactname") as LinkButton;
                string ContactID = grdNewsletercontacts.DataKeys[e.Row.RowIndex].Value.ToString();
                lnk.CommandArgument = ContactID;
                Label lblchecked = e.Row.FindControl("lblchecked") as Label;
                if (lblchecked.Text == "False")
                    e.Row.CssClass = "UnreadInquiry";
                else
                    e.Row.CssClass = "readInquiry";
                Label lblReply = e.Row.FindControl("lblReply") as Label;
                Label lblEmail = e.Row.FindControl("lblUserEmail") as Label;
                //if(lblEmail.Text!="")
                //    lblReply.Text = "<a href=\"mailto:" + lblEmail.Text + "\"><img src=\"../../Images/Dashboard/reply.png\"/></a>";
                if (lblEmail.Text != "")
                {
                    //lblReply.Text = "<a href=\"mailto:" + lblEmail.Text + "\"><img src=\"../../Images/Dashboard/reply.png\"/></a>";
                    lblReply.Text = "<img id=\"imgReply\"  style=\"cursor:pointer;\" src=\"../../Images/Dashboard/reply.png\" onclick=\"ShowCannedMessage('" + lblEmail.Text.ToString() + "')\" />";
                }
                if (grdNewsletercontacts.EditIndex == -1)
                {
                    LinkButton Linkbtn = e.Row.FindControl("lnkdelete") as LinkButton;
                    if (Linkbtn != null)
                        Linkbtn.OnClientClick = "if (confirm('Are you sure you want to delete this Email Messages?') == false) return false;";
                }
                CheckBox headerchkBulletins = (CheckBox)grdNewsletercontacts.HeaderRow.FindControl("chkSelectAllBL");
                CheckBox childchkBulletins = (CheckBox)e.Row.FindControl("chkBL");
                childchkBulletins.Attributes.Add("onclick", "javascript:UnSelectHeaderCheckboxes('" + headerchkBulletins.ClientID + "','BL')");
            }
        }
        protected void grdUpdatescontacts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblcreatedDate = e.Row.FindControl("lblBUCreateddate") as Label;
                if (Convert.ToString(dtobj.Rows[e.Row.RowIndex]["Created_Date"].ToString()) != "")
                {
                    DateTime dtCreatedDate = Convert.ToDateTime(dtobj.Rows[e.Row.RowIndex]["Created_Date"].ToString());
                    lblcreatedDate.Text = dtCreatedDate.ToShortDateString();
                }
                else
                    lblcreatedDate.Text = "";
                LinkButton lnk = e.Row.FindControl("lnkBUcontactname") as LinkButton;
                string ContactID = grdUpdatescontacts.DataKeys[e.Row.RowIndex].Value.ToString();
                lnk.CommandArgument = ContactID;
                Label lblchecked = e.Row.FindControl("lblchecked") as Label;
                Label lblReply = e.Row.FindControl("lblReply") as Label;
                Label lblEmail = e.Row.FindControl("lblUserEmail") as Label;
                //if (lblEmail.Text != "")
                //    lblReply.Text = "<a href=\"mailto:" + lblEmail.Text + "\"><img src=\"../../Images/Dashboard/reply.png\"/></a>";
                if (lblEmail.Text != "")
                {
                    //lblReply.Text = "<a href=\"mailto:" + lblEmail.Text + "\"><img src=\"../../Images/Dashboard/reply.png\"/></a>";
                    lblReply.Text = "<img id=\"imgReply\"  style=\"cursor:pointer;\" src=\"../../Images/Dashboard/reply.png\" onclick=\"ShowCannedMessage('" + lblEmail.Text.ToString() + "')\" />";
                }
                if (lblchecked.Text == "False")
                    e.Row.CssClass = "UnreadInquiry";
                else
                    e.Row.CssClass = "readInquiry";
                if (grdNewsletercontacts.EditIndex == -1)
                {
                    LinkButton Linkbtn = e.Row.FindControl("lnkBUdelete") as LinkButton;
                    if (Linkbtn != null)
                        Linkbtn.OnClientClick = "if (confirm('Are you sure you want to delete this Email Messages?') == false) return false;";
                }
                CheckBox chkHeader = (CheckBox)grdUpdatescontacts.HeaderRow.FindControl("chkSelectAllBU");
                CheckBox chkHeaderChild = (CheckBox)e.Row.FindControl("chkBU");
                chkHeaderChild.Attributes.Add("onclick", "javascript:UnSelectHeaderCheckboxes('" + chkHeader.ClientID + "','BU')");
            }
        }
        protected void grdECcontacts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblcreatedDate = e.Row.FindControl("lblECCreateddate") as Label;
                if (Convert.ToString(dtobj.Rows[e.Row.RowIndex]["Created_Date"].ToString()) != "")
                {
                    DateTime dtCreatedDate = Convert.ToDateTime(dtobj.Rows[e.Row.RowIndex]["Created_Date"].ToString());
                    lblcreatedDate.Text = dtCreatedDate.ToShortDateString();
                }
                else
                    lblcreatedDate.Text = "";
                LinkButton lnk = e.Row.FindControl("lnkECcontactname") as LinkButton;
                string ContactID = grdECcontacts.DataKeys[e.Row.RowIndex].Value.ToString();
                lnk.CommandArgument = ContactID;
                Label lblchecked = e.Row.FindControl("lblchecked") as Label;
                Label lblReply = e.Row.FindControl("lblReply") as Label;
                Label lblEmail = e.Row.FindControl("lblUserEmail") as Label;
                //if (lblEmail.Text != "")
                //    lblReply.Text = "<a href=\"mailto:" + lblEmail.Text + "\"><img src=\"../../Images/Dashboard/reply.png\"/></a>";
                if (lblEmail.Text != "")
                {
                    //lblReply.Text = "<a href=\"mailto:" + lblEmail.Text + "\"><img src=\"../../Images/Dashboard/reply.png\"/></a>";
                    lblReply.Text = "<img id=\"imgReply\"  style=\"cursor:pointer;\" src=\"../../Images/Dashboard/reply.png\" onclick=\"ShowCannedMessage('" + lblEmail.Text.ToString() + "')\" />";
                }
                if (lblchecked.Text == "False")
                    e.Row.CssClass = "UnreadInquiry";
                else
                    e.Row.CssClass = "readInquiry";
                if (grdNewsletercontacts.EditIndex == -1)
                {
                    LinkButton Linkbtn = e.Row.FindControl("lnkECdelete") as LinkButton;
                    if (Linkbtn != null)
                        Linkbtn.OnClientClick = "if (confirm('Are you sure you want to delete this Email Messages?') == false) return false;";
                }
                CheckBox chkHeader = (CheckBox)grdECcontacts.HeaderRow.FindControl("chkSelectAllEC");
                CheckBox chkHeaderChild = (CheckBox)e.Row.FindControl("chkEC");
                chkHeaderChild.Attributes.Add("onclick", "javascript:UnSelectHeaderCheckboxes('" + chkHeader.ClientID + "','EC')");
            }
        }
        protected void grdCAcontacts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblcreatedDate = e.Row.FindControl("lblCACreateddate") as Label;
                if (Convert.ToString(dtobj.Rows[e.Row.RowIndex]["Created_Date"].ToString()) != "")
                {
                    DateTime dtCreatedDate = Convert.ToDateTime(dtobj.Rows[e.Row.RowIndex]["Created_Date"].ToString());
                    lblcreatedDate.Text = dtCreatedDate.ToShortDateString();
                }
                else
                    lblcreatedDate.Text = "";
                LinkButton lnk = e.Row.FindControl("lnkCAcontactname") as LinkButton;
                string ContactID = grdCAcontacts.DataKeys[e.Row.RowIndex].Value.ToString();
                lnk.CommandArgument = ContactID;
                Label lblchecked = e.Row.FindControl("lblchecked") as Label;
                Label lblReply = e.Row.FindControl("lblReply") as Label;
                Label lblEmail = e.Row.FindControl("lblUserEmail") as Label;
                if (lblEmail.Text != "")
                {
                    //lblReply.Text = "<a href=\"mailto:" + lblEmail.Text + "\"><img src=\"../../Images/Dashboard/reply.png\"/></a>";
                    lblReply.Text = "<img id=\"imgReply\"  style=\"cursor:pointer;\" src=\"../../Images/Dashboard/reply.png\" onclick=\"ShowCannedMessage('" + lblEmail.Text.ToString() + "')\" />";
                }
                if (lblchecked.Text == "False")
                    e.Row.CssClass = "UnreadInquiry";
                else
                    e.Row.CssClass = "readInquiry";
                if (grdNewsletercontacts.EditIndex == -1)
                {
                    LinkButton Linkbtn = e.Row.FindControl("lnkCAdelete") as LinkButton;
                    if (Linkbtn != null)
                        Linkbtn.OnClientClick = "if (confirm('Are you sure you want to delete this Email Messages?') == false) return false;";
                }
                CheckBox chkHeader = (CheckBox)grdCAcontacts.HeaderRow.FindControl("chkSelectAllCA");
                CheckBox chkHeaderChild = (CheckBox)e.Row.FindControl("chkCA");
                chkHeaderChild.Attributes.Add("onclick", "javascript:UnSelectHeaderCheckboxes('" + chkHeader.ClientID + "','CA')");
            }
        }
        protected void grdNewsletercontacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdNewsletercontacts.PageIndex = e.NewPageIndex;
            filldata();
        }
        protected void grdUpdatescontacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUpdatescontacts.PageIndex = e.NewPageIndex;
            filldata();
        }
        protected void grdECcontacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdECcontacts.PageIndex = e.NewPageIndex;
            filldata();
        }
        protected void grdCAcontacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCAcontacts.PageIndex = e.NewPageIndex;
            filldata();
        }
        protected void filldata()
        {
            dtobj = objCommon.GetEmailContacts(true, UserID);
            DataView dtview = new DataView(dtobj);
            dtview.RowFilter = "Contactus_Type='Bulletins'";
            DataTable dtNewsletter = dtview.ToTable();
            BulletinsCount = dtNewsletter.Rows.Count;
            dtview.RowFilter = "Contactus_Type='CustomModule'";
            DataTable dtUpdates = dtview.ToTable();
            UpdatesCount = dtUpdates.Rows.Count;
            dtview.RowFilter = "Contactus_Type='EventCalendar'";
            DataTable dtEventCalendar = dtview.ToTable();
            EventCalendarCount = dtEventCalendar.Rows.Count;
            dtview.RowFilter = "Contactus_Type=' " + WebConstants.Tab_CalendarAddOns + "'";
            DataTable dtCalendarAddOn = dtview.ToTable();
            CalendarAddOnCount = dtCalendarAddOn.Rows.Count;

            grdNewsletercontacts.DataSource = dtNewsletter;
            grdNewsletercontacts.DataBind();
            grdUpdatescontacts.DataSource = dtUpdates;
            grdUpdatescontacts.DataBind();
            grdECcontacts.DataSource = dtEventCalendar;
            grdECcontacts.DataBind();
            grdCAcontacts.DataSource = dtCalendarAddOn;
            grdCAcontacts.DataBind();
        }
        protected void lnkcontactname_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            int ContactID = Convert.ToInt32(lnk.CommandArgument.ToString());
            ShowContactusDetails(ContactID, "BL");
        }
        protected void lnkBUcontactname_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            int ContactID = Convert.ToInt32(lnk.CommandArgument.ToString());
            ShowContactusDetails(ContactID, "BU");
        }
        protected void lnkECcontactname_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            int ContactID = Convert.ToInt32(lnk.CommandArgument.ToString());
            ShowContactusDetails(ContactID, "EC");
        }
        protected void lnkCAcontactname_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            int ContactID = Convert.ToInt32(lnk.CommandArgument.ToString());
            ShowContactusDetails(ContactID, "CA");
        }
        protected void lnkdelete_Click(object sender, EventArgs e)
        {
            LinkButton lnkdel = sender as LinkButton;
            int ContactID = Convert.ToInt32(lnkdel.CommandArgument.ToString());
            int alrt = objCommon.DeleteEmailContact(ContactID);
            lblmsg.Text = "<font size='3' color='green'>The selected email messages has been deleted successfully.<b></b><font>";
            filldata();
        }
        protected void btnclose_Click(object sender, EventArgs e)
        {
            lblfn.Text = "";
            lblln.Text = "";
            lbladdress.Text = "";
            lblemail.Text = "";
            lblphone.Text = "";
            lbldescription.Text = "";
            ModalPopupExtender1.Hide();
            filldata();
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int MessagesCount = 0;
            foreach (GridViewRow gvrow in grdNewsletercontacts.Rows)
            {
                CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkBL");
                if (chkdelete.Checked)
                {
                    int messageID = Convert.ToInt32(grdNewsletercontacts.DataKeys[gvrow.RowIndex].Value);
                    objCommon.DeleteEmailContact(messageID);
                    MessagesCount = MessagesCount + 1;
                }
            }
            foreach (GridViewRow gvrow in grdUpdatescontacts.Rows)
            {
                CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkBU");
                if (chkdelete.Checked)
                {
                    int messageID = Convert.ToInt32(grdUpdatescontacts.DataKeys[gvrow.RowIndex].Value);
                    objCommon.DeleteEmailContact(messageID);
                    MessagesCount = MessagesCount + 1;
                }
            }
            foreach (GridViewRow gvrow in grdECcontacts.Rows)
            {
                CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkEC");
                if (chkdelete.Checked)
                {
                    int messageID = Convert.ToInt32(grdECcontacts.DataKeys[gvrow.RowIndex].Value);
                    objCommon.DeleteEmailContact(messageID);
                    MessagesCount = MessagesCount + 1;
                }
            }
            foreach (GridViewRow gvrow in grdCAcontacts.Rows)
            {
                CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkCA");
                if (chkdelete.Checked)
                {
                    int messageID = Convert.ToInt32(grdCAcontacts.DataKeys[gvrow.RowIndex].Value);
                    objCommon.DeleteEmailContact(messageID);
                    MessagesCount = MessagesCount + 1;
                }
            }
            if (MessagesCount > 0)
            {
                lblmsg.Text = "<font size='3' color='green'>" + Resources.LabelMessages.DeleteMessagesandTips.ToString() + "<font>";
            }
            filldata();
        }
        //Added for Check All in Messages and Tips 
        protected void ChkSelectAllBLCheckedChanged(object sender, EventArgs e)
        {

        }
        protected void ChkBLCheckedChanged(object sender, EventArgs e)
        {

        }
        protected void ChkSelectAllBUCheckedChanged(object sender, EventArgs e)
        {

        }
        protected void ChkBUCheckedChanged(object sender, EventArgs e)
        {

        }
        protected void ChkSelectAllECCheckedChanged(object sender, EventArgs e)
        {

        }
        protected void ChkECCheckedChanged(object sender, EventArgs e)
        {

        }
        protected void ChkSelectAllCACheckedChanged(object sender, EventArgs e)
        {

        }
        protected void ChkCACheckedChanged(object sender, EventArgs e)
        {

        }
        private void ShowContactusDetails(int ContactID, string ContactusType)
        {
            string firstname = string.Empty;
            string lastname = string.Empty;
            string Address = string.Empty;
            string ContEmail = string.Empty;
            string Phone = string.Empty;
            string Description = string.Empty;
            DataTable dtNLContact = new DataTable();
            dtNLContact = objCommon.SelectEmailContact(UserID, ContactID);
            if (dtNLContact.Rows.Count > 0)
            {
                firstname = lblfn.Text = dtNLContact.Rows[0]["First_Name"].ToString();
                lastname = lblln.Text = dtNLContact.Rows[0]["Last_Name"].ToString();
                Address = lbladdress.Text = dtNLContact.Rows[0]["User_Address"].ToString();
                ContEmail = lblemail.Text = dtNLContact.Rows[0]["User_Email"].ToString();
                Phone = lblphone.Text = dtNLContact.Rows[0]["User_Phone"].ToString();
                Description = lbldescription.Text = dtNLContact.Rows[0]["Description"].ToString();
                lblheader.Text = "Email Message Details";
                objCommon.AddandUpdateEmaiContacts(firstname, lastname, ContEmail, Address, Phone, Description, UserID, Convert.ToInt32(dtNLContact.Rows[0]["Schedule_ID"].ToString()), ContactusType, ContactID);
                ModalPopupExtender1.Show();
            }
            filldata();
        }
        protected void btnReply_OnClick(object sender, EventArgs e)
        {
            string command = "";
            if (RBNone.Checked)
            { command = "mailto:" + hdnSelectedContactMailID.Value.ToString() + "?body=" + ""; }
            else
            {
                command = "mailto:" + hdnSelectedContactMailID.Value.ToString() + "?body=" + rbCList.SelectedValue.ToString();
            }
            Process.Start(command);
            filldata();
        }

        protected void lnkCannedMessage_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ManageCannedMessage.aspx?PageName=Inquiry"));
        }
    }
}