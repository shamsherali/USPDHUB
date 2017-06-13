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
    public partial class SendPSCInvitation : System.Web.UI.Page
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;

        public string RootPath = "";
        public string DomainName = "";
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public PrivateModuleBLL objPrivateModuleBLL = new PrivateModuleBLL();
        CommonBLL objCommonBLL = new CommonBLL();

        public int UserModuleID = 0;
        public int GroupID = 0;

        BusinessBLL busObj = new BusinessBLL();
        public string SelectedGroups = string.Empty;

        public DataTable DtpopupContacts = new DataTable();
        public DataTable DtContacts = new DataTable();


        public int CheckAllFlag = 0;
        public int DDlCheck = 0;
        public int SortDir = 0;
        public int CheckSelectAll = 0;
        PrivateSmartConnectBLL objPrivateSmartConnectBLL = new PrivateSmartConnectBLL();

        public string InvitateeUsername = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["userid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }

                // *** Get Domain Name *** //
                DomainName = Session["VerticalDomain"].ToString();
                RootPath = Session["RootPath"].ToString();


                UserModuleID = Convert.ToInt32(Session["CustomModuleID"]);
                UserID = Convert.ToInt32(Session["UserID"].ToString());
                ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
                C_UserID = UserID;
                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);


                if (!IsPostBack)
                {
                    InvitersUserDetails();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendPSCInvitation.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void InvitersUserDetails()
        {
            try
            {
                Session["ContactTable"] = null;
                hdnsortdire.Value = "";
                hdnsortcount.Value = "0";

                DtContacts = objPrivateSmartConnectBLL.GetAllContactsForSendInvitation(UserModuleID, "");
                grdusercontacts.DataSource = DtContacts;
                grdusercontacts.DataBind();
                Session["ContactTable"] = DtContacts;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendPSCInvitation.aspx.cs", "InvitersUserDetails", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }


        protected void btnSend_OnClick(object sender, EventArgs e)
        {
            try
            {
                lblmess.Text = "";
                string toEmailIDs = "";
                string status = "Invited";
                bool IsValid = false;
                DtContacts = Session["ContactTable"] as DataTable;
                if (DtContacts != null)
                {
                    //USPD-1317
                    CheckBox chkBxHeader = (CheckBox)this.grdusercontacts.HeaderRow.FindControl("chkSelectAll");
                    foreach (DataRow row in DtContacts.Rows)
                    {
                        if (chkBxHeader.Checked == true)
                        {
                            row["checkvalue"] = "1";
                        }
                        if (Convert.ToInt32(row["checkvalue"]) == 1)
                        {
                            IsValid = true;
                            toEmailIDs = Convert.ToString(row["EmailID"]);
                            string mobileNumber = Convert.ToString(row["MobileNumber"]);

                            // Invitess User Details
                            int inviteesID = objPrivateModuleBLL.Insert_Update_Invitees(Convert.ToString(row["FirstName"]), Convert.ToString(row["LastName"]),
                                toEmailIDs, ProfileID, UserModuleID, Convert.ToInt32(row["ContactID"]), ButtonTypes.PrivateSmartConnect);


                            string pOTP = Guid.NewGuid().ToString();
                            // Invitations Details
                            int invitationID = objPrivateModuleBLL.Insert_Update_Invitation(inviteesID, status, string.Empty, string.Empty, pOTP, string.Empty, 0, UserModuleID, ProfileID, mobileNumber, ButtonTypes.PrivateSmartConnect);


                            // Email Invitation & SMS Invitation
                            objCommonBLL.SendPrivateSmartConnect_InvitationMails(toEmailIDs, DomainName, invitationID.ToString(), ProfileID, "", UserID, RootPath, mobileNumber);

                        }
                        row["checkvalue"] = "0";
                    }
                }
                else
                {
                    IsValid = false;
                }
                if (IsValid)
                {
                    lblmess.Text = "<font color='green' size='3'>" + Resources.LabelMessages.PrivateInvitationSentMSG.ToString() + "</font>";
                    InvitersUserDetails();
                }
                else
                {
                    lblmess.Text = "<font color='red' size='3'>" + Resources.LabelMessages.PrivateInvitationPleaseSelectatleastMSG.ToString() + "</font>";
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendPSCInvitation.aspx.cs", "btnSend_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {

            Response.Redirect(RootPath + "/Business/MyAccount/SetupPSCInvitations.aspx");
        }

        protected void btnDashboard_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(RootPath + "/Business/MyAccount/default.aspx");
        }

        protected void grdusercontacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                // contacts grid view paging logic
                grdusercontacts.PageIndex = e.NewPageIndex;
                // assign session table
                DtpopupContacts = (DataTable)(Session["ContactTable"]);
                DtpopupContacts.PrimaryKey = new DataColumn[] { DtpopupContacts.Columns["ContactID"] };
                grdusercontacts.DataSource = DtpopupContacts;
                grdusercontacts.DataBind();
                Validateselection(DtpopupContacts);
                if (DtpopupContacts.Rows.Count > 0)
                {

                    // check for all contacts are selected ot not
                    if (Session["CheckAll"].ToString() == "0")
                    {
                        CheckBox chkBxHeader = (CheckBox)this.grdusercontacts.HeaderRow.FindControl("chkSelectAll");
                        chkBxHeader.Checked = false;
                    }
                    else
                    {
                        CheckBox chkBxHeader = (CheckBox)this.grdusercontacts.HeaderRow.FindControl("chkSelectAll");
                        chkBxHeader.Checked = true;
                    }

                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendPSCInvitation.aspx.cs", "grdusercontacts_PageIndexChanging", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void grdusercontacts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //// check for check box selection   
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chek = e.Row.FindControl("CheckBox1") as CheckBox;
                    CheckBox chkBxHeader = (CheckBox)this.grdusercontacts.HeaderRow.FindControl("chkSelectAll");
                    Label lblcheck = e.Row.FindControl("lblcheckvalue") as Label;

                    Label lblname = e.Row.FindControl("lblname") as Label;
                    string name = lblname.Text;

                    // check for all check box's selection
                    if (CheckAllFlag == 1)
                    {
                        chek.Checked = true;
                        chkBxHeader.Checked = true;
                    }
                    else
                    {
                    }

                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendPSCInvitation.aspx.cs", "grdusercontacts_RowDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void chkContact_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                lblmess.Text = "";
                if (Session["ContactTable"] == null)
                {
                    GetSelectedCheckValues();
                }

                // single check box selection
                DtpopupContacts = (DataTable)(Session["ContactTable"]);
                DtpopupContacts.PrimaryKey = new DataColumn[] { DtpopupContacts.Columns["RowRank"] };
                CheckBox chk = (CheckBox)sender;
                // find grid view selected
                GridViewRow gvr = (GridViewRow)chk.NamingContainer;
                int rowIndex = gvr.RowIndex;
                string strPrimaryKey = grdusercontacts.DataKeys[rowIndex]["RowRank"].ToString();
                DataRow drChecked;
                // find selected row from datatable
                drChecked = DtpopupContacts.Rows.Find(strPrimaryKey);
                if (drChecked != null)
                {
                    // update selected row check value
                    if (chk.Checked == true)
                    {
                        drChecked["checkvalue"] = "1";
                    }
                    else
                    {
                        drChecked["checkvalue"] = "0";
                        CheckBox chkBxHeader = (CheckBox)this.grdusercontacts.HeaderRow.FindControl("chkSelectAll");
                        chkBxHeader.Checked = false;
                    }

                }

                Validateselection(DtpopupContacts);

                Session["ContactTable"] = DtpopupContacts;
                grdusercontacts.DataSource = DtpopupContacts;
                grdusercontacts.DataBind();
                for (int i = 0; i < grdusercontacts.Rows.Count; i++)
                {
                    if (Convert.ToInt32(DtpopupContacts.Rows[i]["checkvalue"].ToString()) == 1)
                    {
                        count++;
                    }
                }
                if (count == grdusercontacts.Rows.Count)
                {
                    CheckBox chkBxHeader = (CheckBox)this.grdusercontacts.HeaderRow.FindControl("chkSelectAll");
                    chkBxHeader.Checked = true;
                    CheckSelectAll = 1;
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendPSCInvitation.aspx.cs", "chkContact_CheckedChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }



        protected void drpcheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // get selected groups contacts
                DtpopupContacts = (DataTable)(Session["ContactTable"]);
                int flag = 0;
                DDlCheck = 1;

                if (drpcheck.Items.Count > 0)
                {
                    for (int i = 0; i < drpcheck.Items.Count; i++)
                    {
                        if (drpcheck.Items[i].Selected == false)
                        {
                            flag = 1;
                        }
                        else
                        {
                            if (SelectedGroups != "")
                            {
                                SelectedGroups = SelectedGroups + "," + drpcheck.Items[i].Value.ToString();
                            }
                            else
                            {
                                SelectedGroups = drpcheck.Items[i].Value.ToString();
                                CheckSelectAll = 1;
                            }
                        }
                    }

                    if (grdusercontacts.Rows.Count != 0)
                    {
                        CheckBox chkBxHeader = (CheckBox)this.grdusercontacts.HeaderRow.FindControl("chkSelectAll");
                        chkBxHeader.Checked = true;
                        CheckSelectAll = 1;
                    }

                }
                if (flag == 1)
                {
                    chkall.Checked = false;
                    GetSelectedCheckValues();
                }
                else
                {
                    GetAllValuesforSelectAll();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendPSCInvitation.aspx.cs", "drpcheck_SelectedIndexChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void chkall_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // select all group contacts
                if (chkall.Checked == true)
                {
                    if (drpcheck.Items.Count > 0)
                    {
                        for (int i = 0; i < drpcheck.Items.Count; i++)
                        {
                            drpcheck.Items[i].Selected = false;

                        }
                    }
                    CheckAllFlag = 0;
                    GetAllValuesforSelectAll();
                }
                else
                {

                    grdusercontacts.DataSource = DtpopupContacts;
                    grdusercontacts.DataBind();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendPSCInvitation.aspx.cs", "chkall_CheckedChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void GetAllValuesforSelectAll()
        {
            try
            {
                // check for all select flag
                DtpopupContacts = DtContacts = objPrivateSmartConnectBLL.GetAllContactsForSendInvitation(UserModuleID, "ALL");

                grdusercontacts.DataSource = DtpopupContacts;
                grdusercontacts.DataBind();

                Session["ContactTable"] = DtpopupContacts;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendPSCInvitation.aspx.cs", "GetAllValuesforSelectAll", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

       
        private void GetSelectedCheckValues()
        {
            try
            {
                // check for all select flag
                DtContacts = objPrivateSmartConnectBLL.GetAllContactsForSendInvitation(UserModuleID, string.Empty);
                if (DtContacts.Rows.Count > 0)
                {
                    grdusercontacts.DataSource = DtContacts;
                    grdusercontacts.DataBind();
                    Session["ContactTable"] = DtContacts;
                }
                else
                {
                    grdusercontacts.DataSource = DtContacts;
                    grdusercontacts.DataBind();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendPSCInvitation.aspx.cs", "GetSelectedCheckValues", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // gridview select all check box
                CheckBox chkBxHeader = (CheckBox)this.grdusercontacts.HeaderRow.FindControl("chkSelectAll");
                if (chkBxHeader.Checked == true)
                {
                    CheckAllFlag = 1;
                    Session["CheckAll"] = 1;
                }
                else
                {
                    CheckAllFlag = 0;
                    Session["CheckAll"] = 0;
                }
                if (chkall.Checked == true)
                {
                    if (drpcheck.Items.Count > 0)
                    {
                        for (int i = 0; i < drpcheck.Items.Count; i++)
                        {
                            drpcheck.Items[i].Selected = false;
                        }
                    }
                    GetAllValuesforSelectAll();

                }
                else
                {
                    for (int i = 0; i < drpcheck.Items.Count; i++)
                    {
                        if (drpcheck.Items[i].Selected == true)
                        {

                            if (SelectedGroups != "")
                            {
                                SelectedGroups = SelectedGroups + "," + drpcheck.Items[i].Value.ToString();
                            }
                            else
                            {
                                SelectedGroups = drpcheck.Items[i].Value.ToString();
                            }
                        }

                    }
                    GetSelectedCheckValues();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendPSCInvitation.aspx.cs", "chkSelectAll_CheckedChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void grdusercontacts_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                // grid view sorting code
                SortDir = Convert.ToInt32(hdnsortcount.Value);
                string sortExp = e.SortExpression.ToString();
                DtpopupContacts = (DataTable)(Session["ContactTable"]);
                if (hdnsortdire.Value != "")
                {
                    if (hdnsortdire.Value != sortExp)
                    {
                        hdnsortdire.Value = sortExp;
                        SortDir = 0;
                        hdnsortcount.Value = "0";
                    }

                }
                else
                {
                    hdnsortdire.Value = sortExp;
                }
                DataView dv = new DataView(DtpopupContacts);
                if (SortDir == 0)
                {
                    if (sortExp == "Name")
                    {
                        dv.Sort = "name ASC";
                    }
                    else if (sortExp == "email")
                    {
                        dv.Sort = "email ASC";
                    }
                    else if (sortExp == "groupname")
                    {
                        dv.Sort = "groupname ASC";
                    }
                    hdnsortcount.Value = "1";
                }
                else
                {
                    if (sortExp == "Name")
                    {
                        dv.Sort = "name DESC";
                    }
                    else if (sortExp == "email")
                    {
                        dv.Sort = "email DESC";
                    }
                    else if (sortExp == "groupname")
                    {
                        dv.Sort = "groupname DESC";
                    }

                    hdnsortcount.Value = "0";
                }

                Session["ContactTable"] = dv.ToTable();
                grdusercontacts.DataSource = dv;
                grdusercontacts.DataBind();
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendPSCInvitation.aspx.cs", "grdusercontacts_Sorting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void Validateselection(DataTable dt)
        {
            DataRow[] dtsample;
            dtsample = dt.Select("checkvalue=0");
            if (dtsample.GetLength(0) > 0)
            {
                Session["CheckAll"] = "0";
            }
            else
            {
                Session["CheckAll"] = "1";
            }
        }

        protected void btnManageInvitations_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(RootPath + "/Business/MyAccount/ManagePSCInvitation.aspx?retflag=1");
        }


    }
}