using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBDAL;
using System.Configuration;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class SendInvitationPrivateModule : BaseWeb
    {
        public int UserID = 0;
        public int ProfileID = 0;
        public int C_UserID = 0;

        public string RootPath = "";
        public string DomainName = "";

        public USPDHUBBLL.PrivateModuleBLL objPrivateModuleBLL = new USPDHUBBLL.PrivateModuleBLL();
        CommonBLL objCommonBLL = new CommonBLL();

        public int UserModuleID = 0;
        public int GroupID = 0;

        BusinessBLL busObj = new BusinessBLL();
        public string SelectedGroups = string.Empty;

        public DataTable DtpopupContacts = new DataTable();
        public DataTable DtContacts = new DataTable();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

        public int CheckAllFlag = 0;
        public int DDlCheck = 0;
        public int SortDir = 0;
        public int CheckSelectAll = 0;
        AddOnBLL objAddOn = new AddOnBLL();

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
                    DataTable dtAddOn = objAddOn.GetAddOnById(UserModuleID);
                    ltrlTitleImage.Text = "<img style='width:auto;height:auto;vertical-align:middle' src='../../Images/CustomModulesAppIcons/" + dtAddOn.Rows[0]["AppIcon"].ToString() + ".png'/>";
                    if (dtAddOn.Rows.Count == 1)
                    {
                        hdnAddOnName.Value = dtAddOn.Rows[0]["TabName"].ToString();
                        if (dtAddOn.Rows[0]["ButtonType"].ToString() == WebConstants.Tab_PrivateContentAddOns)
                        {
                            //hdnIsPrivateModule.Value = "1";
                        }
                    }


                    InvitersUserDetails();
                }

            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitationPrivateModule.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        private void InvitersUserDetails()
        {
            try
            {
                Session["ContactTable"] = null;
                // Hdn control for Sorting
                hdnsortdire.Value = "";
                hdnsortcount.Value = "0";
                // default check all groups
                // chkall.Checked = true;
                // add contact group to check box list
                DataTable dtContactGroups = new DataTable();
                dtContactGroups = busObj.GetUserContactGroupNamesForPrivateModule(UserID, ManageContactGroupTypes.PrivateModuleGroup.ToString(), UserModuleID);
                if (dtContactGroups.Rows.Count > 0)
                {
                    DataView dV = new DataView(dtContactGroups);
                    dV.Sort = "Contact_Group_name ASC";
                    dtContactGroups = dV.ToTable();

                    // End
                    drpcheck.DataSource = dtContactGroups;
                    drpcheck.DataTextField = "Contact_Group_name";
                    drpcheck.DataValueField = "Contact_Group_ID";
                    drpcheck.DataBind();
                    Session["CheckAll"] = "0";

                }
                DtContacts = busObj.GetAllUserContactsForPrivateModule(0, CheckAllFlag, "ALL", UserModuleID);
                grdusercontacts.DataSource = DtpopupContacts;
                grdusercontacts.DataBind();
                Session["ContactTable"] = DtpopupContacts;
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitationPrivateModule.aspx.cs", "InvitersUserDetails", ex.Message,
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
                foreach (DataRow row in DtContacts.Rows)
                {
                    if (Convert.ToInt32(row["checkvalue"]) == 1)
                    {
                        string mobileNumber = Convert.ToString(row["MobileNumber"]);
                        toEmailIDs = Convert.ToString(row["Email"]);
                        IsValid = true;


                        // Invitess User Details
                        int inviteesID = objPrivateModuleBLL.Insert_Update_Invitees(Convert.ToString(row["Firstname"]), Convert.ToString(row["LastName"]),
                            toEmailIDs, ProfileID, UserModuleID, Convert.ToInt32(row["ContactID"]), ButtonTypes.PrivateModule);


                        string pOTP = Guid.NewGuid().ToString();

                        // Invitations Details
                        int invitationID = objPrivateModuleBLL.Insert_Update_Invitation(inviteesID, status, string.Empty, string.Empty, pOTP, string.Empty, 0, UserModuleID, ProfileID, mobileNumber, ButtonTypes.PrivateModule);


                        //Invitation Email & SMS Invitation
                        objCommonBLL.SendPrivateModule_InvitationMails(toEmailIDs, DomainName, invitationID.ToString(), ProfileID, "", UserID, RootPath, mobileNumber);

                    }
                    row["checkvalue"] = "0";
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
                objInBuiltData.ErrorHandling("ERROR", "SendInvitationPrivateModule.aspx.cs", "btnSend_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {

            Response.Redirect(RootPath + "/Business/MyAccount/SetupInvitation.aspx");
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
                objInBuiltData.ErrorHandling("ERROR", "SendInvitationPrivateModule.aspx.cs", "grdusercontacts_PageIndexChanging", ex.Message,
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
                        if (Convert.ToBoolean(lblcheck.Text))// == "1")
                        {
                            chek.Checked = true;
                        }
                        else
                        {
                            chek.Checked = false;

                        }
                    }
                    // *** Start of issue 1257 ***//
                    // *** Uncomment benow if condition if bydefault need to check the all contacts by selecting  groups *** //
                    //if (CheckSelectAll == 1)
                    //{
                    //    chkBxHeader.Checked = true;
                    //    chek.Checked = true;
                    //}
                    // *** End of issue 1257 ***//
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitationPrivateModule.aspx.cs", "grdusercontacts_RowDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lblmess.Text = "";

                // single check box selection
                DtpopupContacts = (DataTable)(Session["ContactTable"]);
                DtpopupContacts.PrimaryKey = new DataColumn[] { DtpopupContacts.Columns["ContactID"] };
                CheckBox chk = (CheckBox)sender;
                // find grid view selected
                GridViewRow gvr = (GridViewRow)chk.NamingContainer;
                int rowIndex = gvr.RowIndex;
                string strPrimaryKey = grdusercontacts.DataKeys[rowIndex]["contactid"].ToString();
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
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitationPrivateModule.aspx.cs", "CheckBox1_CheckedChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void drpcheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // get selected groups contacts
                DtpopupContacts = (DataTable)(Session["ContactTable"]);
                int flag = 1;
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
                                // *** Start of issue 1257 ***//
                                CheckSelectAll = 1;
                                // *** Start of issue 1257 ***//
                            }
                        }
                    }
                    // *** Start of issue 1257 ***//
                    if (grdusercontacts.Rows.Count != 0)
                    {
                        CheckBox chkBxHeader = (CheckBox)this.grdusercontacts.HeaderRow.FindControl("chkSelectAll");
                        chkBxHeader.Checked = true;
                        CheckSelectAll = 1;
                    }
                    // *** End of issue 1257 ***//
                }
                if (flag == 1)
                {
                    chkall.Checked = false;
                    GetSelectedCheckValues();
                }
                else
                {
                    //for (int i = 0; i < drpcheck.Items.Count; i++)
                    //{
                    //    drpcheck.Items[i].Selected = false;
                    //}
                    //chkall.Checked = true;
                    //GetAllValuesforSelectAll();

                }
                // *** Start of issue 1257 ***//
                if (CheckSelectAll == 1)
                {
                    /*
                    DtpopupContacts = (DataTable)(Session["ContactTable"]);
                    if (DtpopupContacts != null)
                    {
                        foreach (DataRow row in DtpopupContacts.Rows)
                        {
                            row["checkvalue"] = "1";
                        }
                    }
                    */

                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitationPrivateModule.aspx.cs", "drpcheck_SelectedIndexChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            // *** End of issue 1257 ***//
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
                objInBuiltData.ErrorHandling("ERROR", "SendInvitationPrivateModule.aspx.cs", "chkall_CheckedChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }

        private void GetAllValuesforSelectAll()
        {
            try
            {
                // get all groups contacts
                GetAllContactDetialstoTable();
                if (DtpopupContacts.Rows.Count > 0)
                {
                    grdusercontacts.DataSource = DtpopupContacts;
                    grdusercontacts.DataBind();

                    Session["ContactTable"] = DtpopupContacts;
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
                objInBuiltData.ErrorHandling("ERROR", "SendInvitationPrivateModule.aspx.cs", "GetAllValuesforSelectAll", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void GetAllContactDetialstoTable()
        {
            try
            {
                // check for all select flag
                DtContacts = busObj.GetAllUserContactsForPrivateModule(UserID, CheckAllFlag, "ALL", UserModuleID); //busObj.GetAllUserContactsbyUserID(UserID, CheckAllFlag, "ALL");
                if (DtContacts.Rows.Count > 0)
                {
                    DtpopupContacts.Rows.Clear();
                    DtpopupContacts = DtContacts;
                    // add primary key to table
                    DtpopupContacts.PrimaryKey = new DataColumn[] { DtpopupContacts.Columns["ContactID"] };
                    // remove unselected groups
                    string filterRows = string.Empty;
                    filterRows = "groupname='General Tab'";
                    if (Session["Aff"] != null)
                    {
                        filterRows = filterRows + " or groupname='Affiliates'";
                    }
                    DataRow[] drr = DtpopupContacts.Select(filterRows);
                    for (int i = 0; i < drr.Length; i++)
                    {
                        DtpopupContacts.Rows.Remove(drr[i]);
                    }

                    //// Get Only Private Module Contacts
                    DataRow[] drr1 = DtpopupContacts.Select("GroupType='privatemodulegroup'");
                    if (drr1.Length > 0)
                    {
                        DtpopupContacts = drr1.CopyToDataTable();
                    }
                    else
                    {
                        DtpopupContacts = new DataTable();
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitationPrivateModule.aspx.cs", "GetAllContactDetialstoTable", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void GetSelectedCheckValues()
        {
            try
            {
                // check for all select flag
                DtContacts = busObj.GetAllUserContactsForPrivateModule(UserID, CheckAllFlag, SelectedGroups, UserModuleID); //busObj.GetAllUserContactsbyUserID(UserID, CheckAllFlag, SelectedGroups);
                if (DtContacts.Rows.Count > 0)
                {
                    if (DtpopupContacts != null)
                        DtpopupContacts.Rows.Clear();
                    DtpopupContacts = DtContacts;
                    // add primary key to table
                    DtpopupContacts.PrimaryKey = new DataColumn[] { DtpopupContacts.Columns["ContactID"] };
                    grdusercontacts.DataSource = DtpopupContacts;
                    grdusercontacts.DataBind();
                    Session["ContactTable"] = DtpopupContacts;

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
                objInBuiltData.ErrorHandling("ERROR", "SendInvitationPrivateModule.aspx.cs", "GetSelectedCheckValues", ex.Message,
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
                objInBuiltData.ErrorHandling("ERROR", "SendInvitationPrivateModule.aspx.cs", "chkSelectAll_CheckedChanged", ex.Message,
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
                dv.Table.PrimaryKey = new DataColumn[] { DtpopupContacts.Columns["ContactID"] };
                Session["ContactTable"] = dv.ToTable();
                grdusercontacts.DataSource = dv;
                grdusercontacts.DataBind();
                if (Session["CheckAll"].ToString() == "1")
                {
                    /*
                    CheckBox chkBxHeader = (CheckBox)this.grdusercontacts.HeaderRow.FindControl("chkSelectAll");
                    chkBxHeader.Checked = true;
                    */
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SendInvitationPrivateModule.aspx.cs", "grdusercontacts_Sorting", ex.Message,
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

        protected void btnSepupInvitations_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(RootPath + "/Business/MyAccount/ManagePrivateInvitations.aspx?retflag=1");
        }

    }
}