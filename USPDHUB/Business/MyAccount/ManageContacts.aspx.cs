using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.IO;
using System.Text;
using System.Drawing;

public partial class Business_MyAccount_ManageContacts : BaseWeb
{

    public int UserID = 0;
    public int CUserID = 0;
    DataTable dtContacts = new DataTable();
    DataTable dtpopupContacts = new DataTable();
    public int CheckAllFlag = 0;
    BusinessBLL busObj = new BusinessBLL();
    public string SelectedGroups = string.Empty;
    DataTable dtContacteDetails = new DataTable();
    public int SelectedContactsCount = 0;
    DataTable dtSelectedGroup = new DataTable();
    DataTable dtContactGroups = new DataTable();
    public int CheckPostback = 0;
    DataTable dtOptOuts = new DataTable();
    public int CheckAllFlagdup = 0;
    DataTable dtduplicatecon = new DataTable();
    public string UpdateContact = string.Empty;
    public string ContactsUnlimited = string.Empty;
    int totalPages = 0;
    int currentPage = 0;
    ArrayList ardup = new ArrayList();
    ArrayList arupdate = new ArrayList();
    protected string resetdata = "dfdf";

    public DataTable Dtpermissions = new DataTable();
    AgencyBLL agencyobj = new AgencyBLL();
    CommonBLL objCommon = new CommonBLL();
    public string PermissionType = string.Empty;
    public int PermissionValue = 0;
    public int? UserModuleID = null;
    AddOnBLL objAddOn = new AddOnBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        // Check for User Session
        if (Session["userid"] != null)
        {
            if (Session["UserID"].ToString() != "")
            {
                UserID = Convert.ToInt32(Session["UserID"].ToString());
            }

            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                CUserID = Convert.ToInt32(Session["C_USER_ID"]);
            else
                CUserID = UserID;
        }
        else
        {
            string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
            Response.Redirect(urlinfo);
        }
        // Clear Label Text
        lblcmessage.Text = "";
        lblnoduplicatescont.Text = "";
        lblContacts.Text = "";
        lblgroupName.Text = "";
        lblmore.Text = "";
        lblpageload.Text = "";
        lblheadingmoreconatacts.Text = "";
        lblerror.Text = "";
        btnDeleteaContact.Visible = false;
        btnDeleteGroup.Visible = false;
        grdusercontacts.Visible = true;

        // javascript Validaions
        for (int i = 0; i < 12; i++)
            txtPhone.Attributes.Add("onkeyup", "FormatPhoneNumber(this,event,1);");
        //txtPhone.Attributes.Add("onblur", "CheckPhoneOrFax(this,'1');");
        txtFax.Attributes.Add("onkeyup", "FormatPhoneNumber(this,event,2);");
        txtMobile.Attributes.Add("onkeyup", "FormatPhoneNumber(this,event,3);");
        txtZipcode.Attributes.Add("onblur", "CheckZipCode(this);");
        txtEmail.Attributes.Add("onblur", "CheckEmailID(this);");
        string theFunction = @"<script language=javascript>
          function textCounter(field, maxlimit) 
          {
                if (field.value.length > maxlimit)
                    field.value = field.value.substring(0, maxlimit);                
                }
            </script>";

        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ClientScriptFunction", theFunction);
        string theFunction1 = "javascript:textCounter(" + txtcontactgroupdes.ClientID + "," + txtcontactgroupdes.MaxLength + ");";
        txtcontactgroupdes.Attributes.Add("onKeyDown", theFunction1);
        txtcontactgroupdes.Attributes.Add("onKeyUp", theFunction1);

        // *** Issue 1015 *** //
        if (!IsPostBack)
        {
            Session["PreviousSelGroup"] = "13";

            if (Request.QueryString["IsScr"] != null && Convert.ToString(Request.QueryString["IsScr"]) == "1")
                hdnIsPrivateModule.Value = "true";
            //roles & permissions..
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Contacts");
                if (hdnPermissionType.Value == "A")
                {
                    UpdatePanel2.Visible = true;
                    uppnlpopup.Visible = false;
                    lblerrormessage.Text = "<font face=arial size=2>You do not have permission to manage contacts.</font>";
                }
            }
            //ends here
            if (Convert.ToBoolean(hdnIsPrivateModule.Value))
            {
                btndelete.CssClass = btnupdate.CssClass = btnPnlCAddContact.CssClass = btnduplicate.CssClass = lnkImportContactsmore.CssClass = btnAddEditContactGroup.CssClass = btnAddGroup.CssClass = btnAddUpdateContact.CssClass = btnDeleteGroup.CssClass = btnDeleteaContact.CssClass = BtnDeleteContacts.CssClass = btnMoveGroupContacts.CssClass = lnkExport.CssClass = "mailbtnP";
                btnsearch.CssClass = "seachareabtnP";
                UserModuleID = Convert.ToInt32(Session["CustomModuleID"]);

                DataTable dtAddOn = objAddOn.GetAddOnById(Convert.ToInt32(UserModuleID));
                if (dtAddOn.Rows.Count == 1)
                {
                    lblButtonName.Text = dtAddOn.Rows[0]["TabName"].ToString();
                }
            }
            PostbackData();
            Session["PgNmb"] = 1;
        }
        if (this.Page.Request.Form["__EVENTTARGET"] != null && this.Page.Request.Form["__EVENTTARGET"].Contains("pgdupnmb") == true)
        {
            string name = Request.Params.Get("__EVENTTARGET");
            string cntnue = Request.Params.Get("__EVENTARGUMENT");
            if (cntnue == "p")
                hdnCurPg.Value = (int.Parse(hdnCurPg.Value) - 1).ToString();
            else if (cntnue == "n")
                hdnCurPg.Value = (int.Parse(hdnCurPg.Value) + 1).ToString();
            Session["PgNmb"] = hdnPrevPg.Value = name.Replace("pgdupnmb", "");
            BindDuplicateRecords();

        }
        Page.ClientScript.RegisterStartupScript(typeof(Page), System.DateTime.Now.Ticks.ToString(), "scrollTo();", true);
    }

    private void PostbackData()
    {
        Session["ContactTable"] = null;
        Session["GroupsTable"] = null;
        // Hide Panel on Page Load
        PnlAddEditContacts.Visible = false;
        PnlAddEditGroups.Visible = false;
        PnlMoreContacts.Visible = true;
        PnlActions.Visible = false;
        // Assign Text to Buttons
        CheckPostback = 1;
        btnAddEditContactGroup.Text = "Add a Group";
        btnAddUpdateContact.Text = "Add Contact";
        lblheadingmoreconatacts.Text = "Total Contacts";
        LoadInitialData("-2"); // *** All Groups *** //
        hdnContactID.Value = "";
        hdnGroupID.Value = "";
        hdnGroupName.Value = "";
        hdnCheckContactCount.Value = "";
    }

    private void LoadInitialData(string group)
    {
        DataTable dtTempPrivateGroups = new DataTable();
        hdnSearchText.Value = "";
        DataTable dtBuiltinAllGroups1 = new DataTable();
        dtContactGroups = busObj.GetUserContactGroupNames(UserID);
        if (dtContactGroups.Rows.Count > 0)
        {
            // Remove for general tab and affiliate groups
            string filterRows = string.Empty;
            filterRows = "contact_group_id='2' ";
            DataRow[] drr = dtContactGroups.Select(filterRows);
            for (int i = 0; i < drr.Length; i++)
            {
                dtContactGroups.Rows.Remove(drr[i]);
            }
            dtBuiltinAllGroups1 = dtContactGroups;
            //  Sort Contacts Groups            

            DataView dV = new DataView(dtContactGroups);
            dV.Sort = "Contact_Group_Name ASC";
            dtContactGroups = dV.ToTable();
            // End           
            dtContactGroups.PrimaryKey = new DataColumn[] { dtContactGroups.Columns["contact_group_id"] };
            Session["GroupsTable"] = dtContactGroups;
            // *** commented as Us team wants to add contacts to Un Group *** //
            //DataRow DRUnGrouped = DtContactGroups.Rows.Find("13");
            //DtContactGroups.Rows.Remove(DRUnGrouped);
            DataRow drOptOut = dtContactGroups.Rows.Find("0");
            if (hdnGroupID.Value != "0")
                dtContactGroups.Rows.Remove(drOptOut);
            DataRow[] drSystemgroups = dtContactGroups.Select("contact_group_id='0' or Groupname='" + ConfigurationManager.AppSettings.Get("ReportsInquiryGroupName") + "'");
            for (int k = 0; k < drSystemgroups.Length; k++)
            {

                dtContactGroups.Rows.Remove(drSystemgroups[k]);
            }

            // Before Remove Private Assign to All Groups Temp table
            dtTempPrivateGroups = dtContactGroups;

            if (group == "-1")
            {
                // *** if any system group is existed in the groups *** //
                DataRow[] drfindSysgroups = dtContactGroups.Select("IsSystem_Group='True'");
                for (int k = 0; k < drfindSysgroups.Length; k++)
                {
                    if (drfindSysgroups[k].ItemArray[1].ToString() != "13")
                    {
                        if (Convert.ToString(drfindSysgroups[k]["GroupType"]) != "privatemodulegroup")
                            dtContactGroups.Rows.Remove(drfindSysgroups[k]);
                    }
                }
            }


            SelectPreviousGroup();
            // *** if any system group is existed in the groups *** //
            DataRow[] drmovegroups = dtContactGroups.Select("IsSystem_Group='True'");
            for (int k = 0; k < drmovegroups.Length; k++)
            {
                if (Convert.ToString(drmovegroups[k]["GroupType"]) != "privatemodulegroup")
                {
                    dtContactGroups.Rows.Remove(drmovegroups[k]);
                }
            }
            string selQueryGroups = "GroupType='' OR GroupType='customgroup' OR GroupType IS NULL";
            if (Convert.ToBoolean(hdnIsPrivateModule.Value))
            {
                selQueryGroups = "GroupType='privatemodulegroup'";
            }
            var rows1 = dtContactGroups.Select(selQueryGroups);
            DataTable dt = new DataTable("dt");
            if (rows1.Length > 0)
            {
                dt = rows1.CopyToDataTable();
            }

            DDLMovingGroup.DataSource = dt;
            DDLContactGroups.DataSource = dt;
#if fixme
            if (hdnGroupType.Value == ManageContactGroupTypes.PrivateModuleGroup.ToString())
            {
                var rows1 = dtContactGroups.Select("GroupType='privatemodulegroup' ");
                DataTable dt = new DataTable("dt");
                if (rows1.Length > 0)
                {
                    dt = rows1.CopyToDataTable();
                }

                DDLMovingGroup.DataSource = dt;
                DDLContactGroups.DataSource = dt;
            }
            else
            {
                var rows1 = dtContactGroups.Select("GroupType='' OR GroupType='customgroup' OR GroupType IS NULL ");
                DataTable dt = new DataTable("dt");
                if (rows1.Length > 0)
                {
                    dt = rows1.CopyToDataTable();
                }
                DDLMovingGroup.DataSource = dt;
                DDLContactGroups.DataSource = dt;
            }
#endif
            // Move Contact Group
            DDLMovingGroup.DataTextField = "Contact_Group_name";
            DDLMovingGroup.DataValueField = "Contact_Group_ID";
            DDLMovingGroup.DataBind();
            DDLMovingGroup.Items.Insert(0, new ListItem("Select a group", ""));


            // Add Contact Group
            //DDLContactGroups.DataSource = dtContactGroups;
            DDLContactGroups.DataTextField = "Contact_Group_name";
            DDLContactGroups.DataValueField = "Contact_Group_ID";
            DDLContactGroups.DataBind();
            DDLContactGroups.Items.Insert(0, new ListItem("Select a group", ""));

            selQueryGroups = "GroupType='' OR GroupType='customgroup' OR GroupType IS NULL";
            if (Convert.ToBoolean(hdnIsPrivateModule.Value))
            {
                selQueryGroups = "GroupType='privatemodulegroup' ";
            }
            var rows2 = dtBuiltinAllGroups1.Select(selQueryGroups);
            DataTable dtBuiltinAllGroups = new DataTable("dt");
            if (rows2.Length > 0)
            {
                dtBuiltinAllGroups = rows2.CopyToDataTable();
            }
            DataView dV1 = new DataView(dtBuiltinAllGroups);
            DataTable dtBuiltinGroups = new DataTable();
            if (dV1.Count > 0)
            {
                dV1.Sort = "Contact_Group_name ASC";
                dtBuiltinAllGroups = dV1.ToTable();
                dtBuiltinAllGroups.PrimaryKey = new DataColumn[] { dtBuiltinAllGroups.Columns["contact_group_id"] };
                // End         

                // ***  Start Jira Issue IRH-9 09/01/2013 *** //
                DataRow[] drAffiliates = dtBuiltinAllGroups.Select("contact_group_id='1'");
                for (int af = 0; af < drAffiliates.Length; af++)
                {
                    dtBuiltinAllGroups.Rows.Remove(drAffiliates[af]);
                }
            }
            // *** End Jira Issue IRH-9 09/01/2013 *** //
            dtBuiltinGroups = dtBuiltinAllGroups.Clone();

            if (hdnGroupID.Value != "")
            {
                if (hdnGroupID.Value != "0")
                {
                    SelectedGroups = hdnGroupID.Value;
                    GetSelectedCheckValues();
                }
                DataRow dRSelected = dtBuiltinAllGroups.Rows.Find(hdnGroupID.Value);
                if (dRSelected != null)
                {
                    dRSelected["Contact_Group_name"] = "<font style='color:#4BB4D2; font-size:13px; font-weight:bold;'>" + dRSelected["Contact_Group_name"].ToString() + "</font>";
                    hdnGroupName.Value = dRSelected["Contact_Group_name"].ToString();
                }
                lnkgroupAll.Attributes.Add("style", "font-family:Arial;  font-size:12px; color:#101010; font-weight:normal; text-align:left; text-decoration:none;");
            }
            else if (hdnGroupID.Value != "ALL")
            {
                if (CheckPostback == 0)
                {
                    lnkgroupAll.Attributes.Add("style", "color:#4BB4D2; font-size:13px; font-weight:bold;");
                }
                GetAllContactDetialstoTable();
                lblheadingmoreconatacts.Text = "Total Contacts";
                int groupsCount = dtBuiltinAllGroups.Rows.Count - 1;
                if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                    groupsCount = dtBuiltinAllGroups.Rows.Count;
                lblmorecontacts.Text = "You have " + dtpopupContacts.Rows.Count.ToString() + " contact(s) " + (dtpopupContacts.Rows.Count == 0 ? "and " : "in ") + groupsCount.ToString() + (groupsCount == 1 ? "group." : " groups.");
            }

            if (dtBuiltinAllGroups.Rows.Count > 0)
            {
                DataRow[] drBuitInGroups = dtBuiltinAllGroups.Select("IsSystem_Group='True' or Groupname='" + ConfigurationManager.AppSettings.Get("ReportsInquiryGroupName") + "'  or GroupType='" + ManageContactGroupTypes.PrivateModuleGroup.ToString() + "'");
                for (int k = 0; k < drBuitInGroups.Length; k++)
                {
                    if (Convert.ToString(drBuitInGroups[k]["GroupType"]) != ManageContactGroupTypes.PrivateModuleGroup.ToString())
                    {
                        dtBuiltinGroups.ImportRow(drBuitInGroups[k]);
                    }
                    dtBuiltinAllGroups.Rows.Remove(drBuitInGroups[k]);
                }
            }
            // System Groups
            DataView dvBuiltinGroups = new DataView(dtBuiltinGroups);
            if (dvBuiltinGroups.Count > 0)
                dvBuiltinGroups.Sort = "Groupname ASC";
            dtBuiltinGroups = dvBuiltinGroups.ToTable();
            GrdBuiltinGroups.DataSource = dtBuiltinGroups;
            GrdBuiltinGroups.DataBind();

            // Custom Groups
            dgContactGroups.DataSource = dtBuiltinAllGroups;
            dgContactGroups.DataBind();


            // Private Module Groups
            DataTable dtPrivateGroups = new DataTable("dtprivate");
            var rows = dtTempPrivateGroups.Select("GroupType='" + ManageContactGroupTypes.PrivateModuleGroup.ToString() + "'");
            if (rows.Length > 0)
            {
                dtPrivateGroups = rows.CopyToDataTable();

                if (hdnGroupID.Value != "" && hdnGroupID.Value != "0")
                {
                    dtPrivateGroups.PrimaryKey = new DataColumn[] { dtPrivateGroups.Columns["contact_group_id"] };
                    DataRow dRSelected = dtPrivateGroups.Rows.Find(hdnGroupID.Value);
                    if (dRSelected != null)
                    {
                        dRSelected["Contact_Group_name"] = "<font style='color:#4BB4D2; font-size:13px; font-weight:bold;'>" + dRSelected["Contact_Group_name"].ToString() + "</font>";
                        hdnGroupName.Value = dRSelected["Contact_Group_name"].ToString();
                    }
                }
            }

            dgPrivateModuleGroup.DataSource = dtPrivateGroups;
            dgPrivateModuleGroup.DataBind();

            ddlGroup1.DataSource = dtPrivateGroups;
            ddlGroup1.DataTextField = "Contact_Group_name";
            ddlGroup1.DataValueField = "Contact_Group_ID";
            ddlGroup1.DataBind();

        }
    }
    private void LoadGroups(string group)
    {
        DataTable dtGroups = busObj.GetUserContactGroupNames(UserID);
        if (dtGroups.Rows.Count > 0)
        {
            // Remove for general tab and affiliate groups
            string filterRows = string.Empty;
            filterRows = "contact_group_id='2'";
            DataRow[] drr = dtGroups.Select(filterRows);
            for (int i = 0; i < drr.Length; i++)
            {
                dtGroups.Rows.Remove(drr[i]);
            }
            //  Sort Contacts Groups            

            DataView dV = new DataView(dtGroups);
            dV.Sort = "Contact_Group_Name ASC";
            dtGroups = dV.ToTable();
            // End           
            dtGroups.PrimaryKey = new DataColumn[] { dtGroups.Columns["contact_group_id"] };
            DataRow[] drSystemgroups = dtGroups.Select("Groupname='" + ConfigurationManager.AppSettings.Get("ReportsInquiryGroupName") + "'");
            for (int k = 0; k < drSystemgroups.Length; k++)
            {
                dtGroups.Rows.Remove(drSystemgroups[k]);
            }
            // *** if any system group is existed in the groups *** //
            if (group != "")
            {
                DataRow[] drfindSysgroups = dtGroups.Select("IsSystem_Group='True' and contact_group_id<>'" + group + "'");
                for (int k = 0; k < drfindSysgroups.Length; k++)
                {
                    dtGroups.Rows.Remove(drfindSysgroups[k]);
                }
            }
            string selPrivateGrops = "GroupType='privatemodulegroup'";
            if (hdnGroupType.Value == ManageContactGroupTypes.PrivateModuleGroup.ToString())
            {
                selPrivateGrops = "GroupType<>'privatemodulegroup' or  GroupType Is NULL";
            }
            DataRow[] drfindPrivategroups = dtGroups.Select(selPrivateGrops);
            for (int k = 0; k < drfindPrivategroups.Length; k++)
            {
                dtGroups.Rows.Remove(drfindPrivategroups[k]);
            }
            DDLContactGroups.DataSource = dtGroups;
            DDLContactGroups.DataTextField = "Contact_Group_name";
            DDLContactGroups.DataValueField = "Contact_Group_ID";
            DDLContactGroups.DataBind();
        }
    }
    private void SelectPreviousGroup()
    {
        // *** Issue 1492 *** //
        if (Session["PreviousSelGroup"] != null)
        {
            ListItem value = DDLContactGroups.Items.FindByValue(Session["PreviousSelGroup"].ToString());
            if (value != null)
                DDLContactGroups.SelectedValue = Session["PreviousSelGroup"].ToString();
        }
    }
    private void GetAllContactDetialstoTable()
    {

        // Get All Contacts
        // check for all select flag
        dtContacts = busObj.GetAllUserContactsbyUserIDbyType(UserID, CheckAllFlag, "ALL", Convert.ToBoolean(hdnIsPrivateModule.Value));
        if (dtContacts.Rows.Count > 0)
        {
            dtpopupContacts.Rows.Clear();
            dtpopupContacts = dtContacts;
            // add primary key to table
            dtpopupContacts.PrimaryKey = new DataColumn[] { dtpopupContacts.Columns["ContactID"] };
            // remove unselected groups
            string filterRows = string.Empty;
            filterRows = "groupname='2' or Contact_Group_ID='1' or Contact_Group_ID='0'"; // *** Included  or Contact_Group_ID='1' for Jira Issue IRH-9 *** //
            DataRow[] drr = dtpopupContacts.Select(filterRows);
            for (int i = 0; i < drr.Length; i++)
            {
                dtpopupContacts.Rows.Remove(drr[i]);
            }
            DataView dV = new DataView(dtpopupContacts);
            dV.Sort = "Email ASC";
            dtpopupContacts = dV.ToTable();
            if (CheckPostback == 0)
            {
                if (dtpopupContacts.Rows.Count > 0)
                {
                    grdusercontacts.DataSource = dtpopupContacts;
                    grdusercontacts.DataBind();
                    Session["ContactTable"] = dtpopupContacts;
                }
                else
                {
                    grdusercontacts.DataSource = dtpopupContacts;
                    grdusercontacts.DataBind();
                }
            }
            else
            {
                grdusercontacts.Visible = false;
                lblpageload.Text = "Click on a group to view your contacts.";
            }
        }
        // End
    }

    private void GetSelectedCheckValues()
    {

        // check for all select flag
        dtContacts = busObj.GetAllUserContactsbyUserIDbyType(UserID, CheckAllFlag, SelectedGroups, Convert.ToBoolean(hdnIsPrivateModule.Value));
        BindContacts(dtContacts);
        GetGroupDetailsByGroupID();
    }
    private void BindContacts(DataTable dtContacts)
    {
        if (dtContacts.Rows.Count > 0)
        {
            dtpopupContacts.Rows.Clear();
            dtpopupContacts = dtContacts;
            // add primary key to table
            dtpopupContacts.PrimaryKey = new DataColumn[] { dtpopupContacts.Columns["ContactID"] };
            DataView dV = new DataView(dtpopupContacts);
            dV.Sort = "Email ASC";
            dtpopupContacts = dV.ToTable();
            grdusercontacts.DataSource = dtpopupContacts;
            grdusercontacts.DataBind();
            Session["ContactTable"] = dtpopupContacts;
            hdnCheckContactCount.Value = "1";
        }
        else
        {
            grdusercontacts.DataSource = dtContacts;
            grdusercontacts.DataBind();
            PnlAddEditGroups.Visible = true;
            PnlAddEditContacts.Visible = false;
            PnlActions.Visible = false;
            PnlMoreContacts.Visible = false;
            hdnCheckContactCount.Value = "";
        }

    }

    // Check box list for groups Selections contacts

    protected void btnAddUpdateContact_Click(object sender, EventArgs e)
    {
        int contactsLimitForUser = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ContactsLimitForUser").Replace(",", ""));
        if (btnAddUpdateContact.Text == "Add")
        {
            if (ContactsUnlimited == "1")
            {
                AddContacts();
            }
            else
            {
                dtContacts = busObj.GetAllUserContactsbyUserIDbyType(UserID, CheckAllFlag, "ALL", Convert.ToBoolean(hdnIsPrivateModule.Value));
                if (dtContacts.Rows.Count < contactsLimitForUser)
                {
                    AddContacts();
                }
                else
                {
                    lblContacts.Text = "<font  size='3' style='color:green'><b>You cannot add more than" + ConfigurationManager.AppSettings.Get("ContactsLimitForUser") + " contacts.</b></font>";
                    ClearContactControls();
                    chkauthorize.Checked = false;
                    chkMobile.Checked = false;
                    DDLContactGroups.SelectedIndex = -1;
                }
            }
        }
        else if (btnAddUpdateContact.Text == "Update")
        {
            int checkEmailGroup = busObj.CheckUserContactValidation(DDLContactGroups.SelectedValue, txtEmail.Text.Trim(), UserID);

            /*if (chkMobile.Checked)
            {
                ScriptManager.RegisterClientScriptBlock(btnPnlCAddContact, GetType(), "JScript1", "ShowDiv();", true);
            }
            else
                txtMobile.Text = "";
            */

            if (checkEmailGroup == 0)
            {
                int optFlag = busObj.CheckForEmailOptFlagCount(txtEmail.Text.Trim(), Convert.ToInt32(Session["UserID"].ToString()));
                if (optFlag == 0)
                {
                    busObj.UpdateBusinessUserContacts(Convert.ToInt32(hdnContactID.Value), txtFirstname.Text.Trim(), txtLastname.Text.Trim(), txtEmail.Text.Trim(), txtAddress.Text.Trim(), txtCity.Text.Trim(), txtState.Text.Trim(), txtZipcode.Text.Trim(), txtPhone.Text.Trim(), txtMobile.Text.Trim(), txtFax.Text.Trim(), DDLContactGroups.SelectedValue, txtcompanyname.Text.Trim(), CUserID);
                    lblContacts.Text = "<font  size='3' style='color:green'><b>Your contact has been updated successfully.</b></font>";
                    lblgroupName.Text = "<font  size='3' style='color:green'><b>Your contact has been updated successfully.</b></font>";
                    resetdata = txtFirstname.Text.Trim();
                    resetdata = resetdata + ",|" + txtLastname.Text.Trim();
                    resetdata = resetdata + ",|" + txtEmail.Text.Trim();
                    resetdata = resetdata + ",|" + txtcompanyname.Text.Trim();
                    resetdata = resetdata + ",|" + txtAddress.Text.Trim();
                    resetdata = resetdata + ",|" + txtCity.Text.Trim();
                    resetdata = resetdata + ",|" + txtState.Text.Trim();
                    resetdata = resetdata + ",|" + txtZipcode.Text.Trim();
                    resetdata = resetdata + ",|" + txtPhone.Text.Trim();
                    resetdata = resetdata + ",|" + txtFax.Text.Trim();
                    resetdata = resetdata + ",|" + txtMobile.Text.Trim();
                    resetdata = resetdata + ",|" + DDLContactGroups.SelectedIndex;
                    hdnreset.Value = resetdata;
                    LoadInitialData("-2");
                    ClearContactControls();
                }
                else
                    lblContacts.Text = "<font  size='3' style='color:red'><b>This contact opted-out.</b></font>";
                btnDeleteaContact.Visible = true;
                UpdateContact = "1";
            }
            else
            {
                DataTable dtContactdetails = new DataTable();
                dtContactdetails = busObj.GetUserContactDetailsbyContactID(Convert.ToInt32(hdnContactID.Value));
                string checkName = string.Empty;
                string checkGroupName = string.Empty;
                if (dtContactdetails.Rows.Count > 0)
                {
                    checkGroupName = dtContactdetails.Rows[0]["Contact_Group_Name"].ToString();
                    checkName = dtContactdetails.Rows[0]["Email"].ToString();
                    if (checkGroupName == DDLContactGroups.SelectedValue)
                    {
                        if (checkName == txtEmail.Text.Trim())
                        {

                            int optFlag = busObj.CheckForEmailOptFlagCount(txtEmail.Text.Trim(), Convert.ToInt32(Session["UserID"].ToString()));
                            if (optFlag == 0)
                            {
                                busObj.UpdateBusinessUserContacts(Convert.ToInt32(hdnContactID.Value), txtFirstname.Text.Trim(), txtLastname.Text.Trim(), txtEmail.Text.Trim(), txtAddress.Text.Trim(), txtCity.Text.Trim(), txtState.Text.Trim(), txtZipcode.Text.Trim(), txtPhone.Text.Trim(), txtMobile.Text.Trim(), txtFax.Text.Trim(), DDLContactGroups.SelectedValue, txtcompanyname.Text.Trim(), CUserID);
                                lblContacts.Text = "<font  size='3' style='color:green'><b>Your contact has been updated successfully.</b></font>";
                                resetdata = txtFirstname.Text.Trim();
                                resetdata = resetdata + ",|" + txtLastname.Text.Trim();
                                resetdata = resetdata + ",|" + txtEmail.Text.Trim();
                                resetdata = resetdata + ",|" + txtcompanyname.Text.Trim();
                                resetdata = resetdata + ",|" + txtAddress.Text.Trim();
                                resetdata = resetdata + ",|" + txtCity.Text.Trim();
                                resetdata = resetdata + ",|" + txtState.Text.Trim();
                                resetdata = resetdata + ",|" + txtZipcode.Text.Trim();
                                resetdata = resetdata + ",|" + txtPhone.Text.Trim();
                                resetdata = resetdata + ",|" + txtFax.Text.Trim();
                                resetdata = resetdata + ",|" + txtMobile.Text.Trim();
                                resetdata = resetdata + ",|" + DDLContactGroups.SelectedIndex;
                                hdnreset.Value = resetdata;
                            }
                            else
                                lblerror.Text = "<font  size='3' style='color:red'><b>This contact opted-out.</b></font>";
                            UpdateContact = "1";
                            btnAddUpdateContact.Text = "Update";
                            btnDeleteaContact.Visible = true;
                        }
                        else
                        {
                            UpdateContact = "1";
                            btnDeleteaContact.Visible = true;
                            lblContacts.Text = "<font  size='3' style='color:green'><b>This email address already exists in this group, please choose another group.</b></font>";
                        }
                    }
                    else
                    {
                        UpdateContact = "1";
                        btnDeleteaContact.Visible = true;
                        lblContacts.Text = "<font  size='3' style='color:green'><b>This email address already exists in this group, please choose another group.</b></font>";
                    }
                }
            }
        }
    }

    protected void btnAddEditContactGroup_Click(object sender, EventArgs e)
    {
        bool IsSystemGroup = false;
        bool IsMasterGroup = false;
        int check = 0;
        if (btnAddEditContactGroup.Text == "Add")
        {
            // Add Contact Group 
            // Call Add Contact Group Method            
            int maxContactGroupID = 0;
            // Check for Contact Group is already exsists
            check = busObj.CheckUserListingValidation(txtcontactgroupname.Text.Trim(), UserID);
            if (check == 0)
            {
                // get Max contact group id for that user ID
                maxContactGroupID = busObj.GetMaximunContactGroupIDForUserID(UserID);
                // Add +1 to insert new contact group Id
                maxContactGroupID = maxContactGroupID + 1;
                // insert contact group for that userid
                busObj.InsertContactGroupName(maxContactGroupID, txtcontactgroupname.Text.Trim(), UserID, DateTime.Now, DateTime.Now, true,
                    txtcontactgroupdes.Text.Trim(), CUserID, ManageContactGroupTypes.CustomGroup.ToString(), 0, IsSystemGroup, IsMasterGroup);
                hdnContactID.Value = "";
                hdnGroupID.Value = "";
                hdnGroupName.Value = "";
                ClearGroupControls();
                LoadInitialData("-2");
                lblgroupName.Text = "<font  size='3' style='color:green'><b>Your group has been added successfully.</b></font>";
            }
            else
            {
                lblgroupName.Text = "<font  size='3' style='color:green'><b>Duplicate group name. Please choose a different name and try again.</b></font>";
            }
        }
        else if (btnAddEditContactGroup.Text == "Update")
        {
            check = busObj.CheckUserListingValidation(txtcontactgroupname.Text.Trim(), UserID);
            if (check == 0)
            {
                busObj.UpdateContactGroupName(txtcontactgroupname.Text.Trim(), Convert.ToInt32(hdnGroupprimarykey.Value), DateTime.Today, true, txtcontactgroupdes.Text.Trim(), CUserID);
                lblgroupName.Text = "<font  size='3' style='color:green'><b>Your group has been updated successfully.</b></font>";
                LoadInitialData("-2");
            }
            else
            {
                DataTable dtContactdetails = new DataTable();
                dtContactdetails = busObj.GetUserContactGroupDetailsByGroupID(Convert.ToInt32(hdnGroupprimarykey.Value));
                string checkName = string.Empty;
                if (dtContactdetails.Rows.Count > 0)
                {
                    checkName = dtContactdetails.Rows[0]["Contact_Group_name"].ToString();
                    if (checkName.ToUpper() == txtcontactgroupname.Text.Trim().ToUpper())
                    {
                        busObj.UpdateContactGroupName(txtcontactgroupname.Text.Trim(), Convert.ToInt32(hdnGroupprimarykey.Value), DateTime.Today, true, txtcontactgroupdes.Text.Trim(), CUserID);
                        lblgroupName.Text = "<font  size='3' style='color:green'><b>Your group has been updated successfully.</b></font>";
                        LoadInitialData("-2");
                        btnAddEditContactGroup.Text = "Update";

                    }
                    else
                    {
                        lblgroupName.Text = "<font  size='3' style='color:green'><b>Duplicate group name. Please choose a different name and try again.</b></font>";
                    }
                }
                btnDeleteGroup.Visible = true;
            }
        }
    }

    protected void lnkgroup_Click(object sender, EventArgs e)
    {
        lblMoveMessage.Text = "";
        hdnGroupID.Value = "";
        txtSearchContact.Text = "";

        LinkButton lnkcontactgroup = sender as LinkButton;
        Label lblGroupType = new Label();
        Label lblIsMasterGroup = new Label();

        if (lnkcontactgroup.Text.ToLower() == "all")
        {
            ContentPlaceHolder gvr = (ContentPlaceHolder)lnkcontactgroup.NamingContainer;
            lblGroupType = gvr.FindControl("lblGType") as Label;
            lblIsMasterGroup = gvr.FindControl("lblIsMasterGroup") as Label;

        }
        else
        {
            GridViewRow gvr = (GridViewRow)lnkcontactgroup.NamingContainer;
            lblGroupType = gvr.FindControl("lblGType") as Label;
            lblIsMasterGroup = gvr.FindControl("lblIsMasterGroup") as Label;

            GridView grid = gvr.NamingContainer as GridView;
            Session["PreviousSelGroup"] = grid.DataKeys[gvr.RowIndex].Value;
        }
        //string emailID = (string)GrdInviters.DataKeys[gvr.RowIndex].Value;

        if (lblIsMasterGroup != null)
        {
            hdnIsMasterGroup.Value = lblIsMasterGroup.Text;
            hdnGroupType.Value = lblGroupType.Text;
        }

        if (lnkcontactgroup.CommandArgument == "ALL")
        {
            GetAllContactDetialstoTable();
            ClearContactControls();
            btnAddUpdateContact.Text = "Add";
            PnlAddEditGroups.Visible = false;
            PnlAddEditContacts.Visible = false;
            PnlMoreContacts.Visible = true;
            PnlActions.Visible = false;
            lblheadingmoreconatacts.Text = "Total Contacts";
            hdnGroupID.Value = "";
            hdnGroupprimarykey.Value = "";
            hdnGroupName.Value = "";
        }
        else if (lnkcontactgroup.CommandArgument == "0")
        {
            ClearGroupControls();
            dtpopupContacts = busObj.GetOptoutContacts(UserID, 0);
            grdusercontacts.DataSource = dtpopupContacts;
            grdusercontacts.DataBind();
            Session["ContactTable"] = dtpopupContacts;
            hdnGroupID.Value = "0";
            hdnGroupprimarykey.Value = "";
            hdnGroupName.Value = "";
            PnlAddEditGroups.Visible = true;
            btnAddEditContactGroup.Text = "Add";
            PnlAddEditContacts.Visible = false;
            PnlMoreContacts.Visible = false;
            PnlActions.Visible = false;
            dtOptOuts = busObj.GetOptoutContacts(UserID, 0);
            if (dtOptOuts.Rows.Count > 0)
            {
                txtcontactgroupname.Text = "Opt-out ( " + dtOptOuts.Rows.Count.ToString() + " )";
                txtcontactgroupdes.Text = "Individuals that have unsubscribed from receiving your emails.";
            }
            else
            {
                txtcontactgroupname.Text = "Opt-out ( 0 )";
                txtcontactgroupdes.Text = "Individuals that have unsubscribed from receiving your emails.";
            }
            btnAddEditContactGroup.Text = "Update";
            btnAddEditContactGroup.Visible = false;
        } // Checking Private Module Groups
        else if (lblGroupType.Text == ManageContactGroupTypes.PrivateModuleGroup.ToString())
        {
            ClearGroupControls();
            dtpopupContacts = busObj.GetOptoutContacts(UserID, 0);
            grdusercontacts.DataSource = dtpopupContacts;
            grdusercontacts.DataBind();
            Session["ContactTable"] = dtpopupContacts;
            hdnGroupID.Value = "0";
            hdnGroupprimarykey.Value = "";
            hdnGroupName.Value = "";
            PnlAddEditGroups.Visible = true;
            btnAddEditContactGroup.Text = "Add";
            PnlAddEditContacts.Visible = false;
            PnlMoreContacts.Visible = false;
            PnlActions.Visible = false;
            dtOptOuts = busObj.GetOptoutContacts(UserID, 0);

            txtcontactgroupname.Text = lnkcontactgroup.Text;

            btnAddEditContactGroup.Text = "Update";


            SelectedGroups = lnkcontactgroup.CommandArgument;
            hdnGroupprimarykey.Value = lnkcontactgroup.ToolTip;
            hdnGroupName.Value = lnkcontactgroup.Text;
            hdnGroupID.Value = SelectedGroups;
            GetSelectedCheckValues();


            if (Convert.ToBoolean(lblIsMasterGroup.Text))
            { btnAddEditContactGroup.Visible = false; }
            else
            {
                btnAddEditContactGroup.Visible = true;
            }
            btnDeleteGroup.Visible = false;

        }
        else
        {
            ClearGroupControls();
            SelectedGroups = lnkcontactgroup.CommandArgument;
            hdnGroupprimarykey.Value = lnkcontactgroup.ToolTip;
            hdnGroupName.Value = lnkcontactgroup.Text;
            hdnGroupID.Value = SelectedGroups;
            GetSelectedCheckValues();
            PnlAddEditGroups.Visible = true;
            PnlAddEditContacts.Visible = false;
            PnlMoreContacts.Visible = false;
            PnlActions.Visible = false;
        }
        LoadInitialData("-2");
    }

    private void GetGroupDetailsByGroupID()
    {
        if (hdnGroupprimarykey.Value != "")
        {
            dtSelectedGroup = busObj.GetUserContactGroupDetailsByGroupID(Convert.ToInt32(hdnGroupprimarykey.Value));
            if (dtSelectedGroup.Rows.Count > 0)
            {
                txtcontactgroupname.Text = dtSelectedGroup.Rows[0]["Contact_Group_name"].ToString();
                resetdata = dtSelectedGroup.Rows[0]["Contact_Group_name"].ToString();
                txtcontactgroupdes.Text = dtSelectedGroup.Rows[0]["Description"].ToString();
                resetdata = resetdata + "," + dtSelectedGroup.Rows[0]["Description"].ToString();
                hdnreset.Value = resetdata;
                btnAddEditContactGroup.Visible = true;
                btnAddEditContactGroup.Text = "Update";
                btnDeleteGroup.Visible = true;
                if (hdnGroupID.Value != "")
                {
                    if (hdnGroupID.Value != "1" & hdnGroupID.Value != "13" & hdnGroupID.Value != "14" & hdnGroupID.Value != "0" & txtcontactgroupname.Text != ConfigurationManager.AppSettings.Get("ReportsInquiryGroupName"))
                    {
                        btnAddEditContactGroup.Visible = true;
                        btnDeleteGroup.Visible = true;

                    }
                    else
                    {
                        btnAddEditContactGroup.Visible = false;
                        btnDeleteGroup.Visible = false;
                    }
                }
            }
        }
        else
        {
            LoadInitialData("-2");
        }

        if (hdnGroupType.Value == ManageContactGroupTypes.PrivateModuleGroup.ToString())
        {
            if (Convert.ToBoolean(hdnIsMasterGroup.Value))
            {
                btnAddEditContactGroup.Visible = false;
            }
            else
            {
                btnAddEditContactGroup.Visible = true;
            }
            btnDeleteGroup.Visible = false;
        }
    }

    protected void chkcontact_CheckedChanged(object sender, EventArgs e)
    {
        ClearContactControls();
        CheckBox chkContact = sender as CheckBox;
        string contactID = chkContact.ToolTip;
        dtpopupContacts = (DataTable)(Session["ContactTable"]);
        dtpopupContacts.PrimaryKey = new DataColumn[] { dtpopupContacts.Columns["ContactID"] };
        DataRow checkedRow = dtpopupContacts.Rows.Find(contactID);
        if (chkContact.Checked == true)
        {
            checkedRow["checkvalue"] = "1";
            PnlAddEditContacts.Visible = true;
            PnlAddEditGroups.Visible = false;
            PnlMoreContacts.Visible = false;
            PnlActions.Visible = false;
            dtContacteDetails = busObj.GetUserContactDetailsbyContactID(Convert.ToInt32(contactID));
            if (dtContacteDetails.Rows.Count > 0)
            {
                hdnContactID.Value = contactID;
                txtFirstname.Text = dtContacteDetails.Rows[0]["Firstname"].ToString();
                txtLastname.Text = dtContacteDetails.Rows[0]["LastName"].ToString();
                txtEmail.Text = dtContacteDetails.Rows[0]["Email"].ToString();
                txtAddress.Text = dtContacteDetails.Rows[0]["Address"].ToString();
                txtCity.Text = dtContacteDetails.Rows[0]["City"].ToString();
                txtState.Text = dtContacteDetails.Rows[0]["State"].ToString();
                txtZipcode.Text = dtContacteDetails.Rows[0]["Zipcode"].ToString();
                txtPhone.Text = dtContacteDetails.Rows[0]["Phone"].ToString();
                txtFax.Text = dtContacteDetails.Rows[0]["Fax"].ToString();
                txtMobile.Text = dtContacteDetails.Rows[0]["Mobile"] == null ? "" : dtContacteDetails.Rows[0]["Mobile"].ToString();
                if (txtMobile.Text.Trim() != "")
                {
                    chkMobile.Checked = true;
                    ScriptManager.RegisterClientScriptBlock(btnPnlCAddContact, GetType(), "JScript1", "ShowDiv();", true);
                }
                txtcompanyname.Text = dtContacteDetails.Rows[0]["CompanyName"].ToString();
                if (dtContacteDetails.Rows[0]["Opt_Flag"].ToString() != "")
                {
                    if (Convert.ToBoolean(dtContacteDetails.Rows[0]["Opt_Flag"].ToString()) == true)
                    {
                        btnDeleteaContact.Visible = false;
                        btnAddUpdateContact.Visible = false;
                        btnAddUpdateContact.Text = "Update";
                    }
                    else
                    {
                        btnDeleteaContact.Visible = true;
                        btnAddUpdateContact.Visible = true;
                        btnAddUpdateContact.Text = "Update";
                    }
                }
                else
                {
                    btnAddUpdateContact.Text = "Update";
                    btnAddUpdateContact.Visible = true;
                    btnDeleteaContact.Visible = true;
                }
                UpdateContact = "1";
            }
        }
        else
        {
            checkedRow["checkvalue"] = "0";
        }
        Session["ContactTable"] = dtpopupContacts;
        DataRow[] checkSelected;
        checkSelected = dtpopupContacts.Select("checkvalue='1'");
        if (checkSelected.Length == 1)
        {
            PnlAddEditGroups.Visible = false;
            PnlMoreContacts.Visible = false;
            PnlAddEditContacts.Visible = true;
            dtContacteDetails = busObj.GetUserContactDetailsbyContactID(Convert.ToInt32(checkSelected[0]["ContactID"].ToString()));
            if (dtContacteDetails.Rows.Count > 0)
            {
                hdnContactID.Value = contactID;
                txtFirstname.Text = dtContacteDetails.Rows[0]["Firstname"].ToString();
                txtLastname.Text = dtContacteDetails.Rows[0]["LastName"].ToString();
                txtEmail.Text = dtContacteDetails.Rows[0]["Email"].ToString();
                txtAddress.Text = dtContacteDetails.Rows[0]["Address"].ToString();
                txtCity.Text = dtContacteDetails.Rows[0]["City"].ToString();
                txtState.Text = dtContacteDetails.Rows[0]["State"].ToString();
                txtZipcode.Text = dtContacteDetails.Rows[0]["Zipcode"].ToString();
                txtPhone.Text = dtContacteDetails.Rows[0]["Phone"].ToString();
                txtFax.Text = dtContacteDetails.Rows[0]["Fax"].ToString();
                txtMobile.Text = dtContacteDetails.Rows[0]["Mobile"] == null ? "" : dtContacteDetails.Rows[0]["Mobile"].ToString();
                if (txtMobile.Text.Trim() != "")
                {
                    chkMobile.Checked = true;
                    ScriptManager.RegisterClientScriptBlock(btnPnlCAddContact, GetType(), "JScript1", "ShowDiv();", true);
                }
                LoadGroups(dtContacteDetails.Rows[0]["Contact_Group_Name"].ToString());
                if (DDLContactGroups.Items.FindByValue(Convert.ToString(dtContacteDetails.Rows[0]["Contact_Group_Name"])) != null)
                    DDLContactGroups.SelectedValue = Convert.ToString(dtContacteDetails.Rows[0]["Contact_Group_Name"]);
                else if (DDLContactGroups.Items.Count > 0)
                    DDLContactGroups.SelectedIndex = 0;
                if (hdnGroupID.Value != "0")
                {
                    btnDeleteaContact.Visible = true;
                    btnAddUpdateContact.Visible = true;
                }
                else
                {
                    btnAddUpdateContact.Visible = false;
                    btnDeleteaContact.Visible = true;
                }
                UpdateContact = "1";
            }
        }
        else if (checkSelected.Length > 0)
        {
            PnlAddEditContacts.Visible = false;
            PnlMoreContacts.Visible = true;
            PnlActions.Visible = true;
            lblheadingmoreconatacts.Text = "Selected Contacts";
            PnlAddEditGroups.Visible = false;
            if (hdnGroupID.Value == "0")
            {
                PnlActions.Visible = false;
            }
            else
            {
                PnlActions.Visible = true;
            }
            if (hdnGroupName.Value != "")
            {
                lblmorecontacts.Text = "You have selected " + checkSelected.Length + " contact(s) from <font style='color:#4BB4D2;'>" + hdnGroupName.Value + "</font> group.";
            }
            else
            {
                lblmorecontacts.Text = "You have selected " + checkSelected.Length + " contact(s).";
            }
        }
        else if (checkSelected.Length == 0)
        {
            PnlAddEditContacts.Visible = false;
            PnlMoreContacts.Visible = false;
            PnlAddEditGroups.Visible = true;
            PnlActions.Visible = false;
            GetGroupDetailsByGroupID();
        }
        CheckBox checkHeader = grdusercontacts.HeaderRow.FindControl("chkSelectAll") as CheckBox;
        if (checkSelected.Length == dtpopupContacts.Rows.Count)
        {
            checkHeader.Checked = true;
        }
        else
        {
            checkHeader.Checked = false;
        }
        // *** Issue 1129 *** //
        if (dtContacteDetails.Rows.Count > 0)
        {
            resetdata = dtContacteDetails.Rows[0]["Firstname"].ToString();
            resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["LastName"].ToString();
            resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["Email"].ToString();
            resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["CompanyName"].ToString();
            resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["Address"].ToString();
            resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["City"].ToString();
            resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["State"].ToString();
            resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["Zipcode"].ToString();
            resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["Phone"].ToString();
            resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["Fax"].ToString();
            string mobileNum = dtContacteDetails.Rows[0]["Mobile"] == null ? "" : dtContacteDetails.Rows[0]["Mobile"].ToString();
            resetdata = resetdata + ",|" + mobileNum;
            if (dtContacteDetails.Rows[0]["Contact_Group_Name"].ToString() != "2")
            {
                if (dtContacteDetails.Rows[0]["Contact_Group_Name"].ToString() != "0")
                {
                    resetdata = resetdata + ",|" + DDLContactGroups.SelectedIndex.ToString();
                }
            }
            hdnreset.Value = resetdata;
        }
        // *** End Issue 1129 *** //
    }

    protected void grdusercontacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdusercontacts.PageIndex = e.NewPageIndex;
        dtpopupContacts = (DataTable)(Session["ContactTable"]);
        grdusercontacts.DataSource = dtpopupContacts;
        grdusercontacts.DataBind();
        DataRow[] drSelected = dtpopupContacts.Select("checkvalue='0'");
        CheckBox chkHeader = grdusercontacts.HeaderRow.FindControl("chkSelectAll") as CheckBox;
        if (drSelected.Length > 0)
        {
            chkHeader.Checked = false;
        }
        else
        {
            chkHeader.Checked = true;
        }
    }

    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = sender as CheckBox;
        if (chkAll.Checked == true)
        {
            CheckAllFlag = 1;
        }
        else
        {
            CheckAllFlag = 0;
        }
        if (hdnSearchText.Value != "")
        {
            if (hdnGroupID.Value != "")
            {
                dtpopupContacts = busObj.SearchUserContactsOnUserIDandEmail(UserID, hdnSearchText.Value, hdnGroupID.Value, CheckAllFlag, Convert.ToBoolean(hdnIsPrivateModule.Value));
            }
            else
            {
                dtpopupContacts = busObj.SearchUserContactsOnUserIDandEmail(UserID, hdnSearchText.Value, "ALL", CheckAllFlag, Convert.ToBoolean(hdnIsPrivateModule.Value));
            }
        }
        else
        {
            if (hdnGroupID.Value != "")
            {
                dtpopupContacts = busObj.GetAllUserContactsbyUserIDbyType(UserID, CheckAllFlag, hdnGroupID.Value, Convert.ToBoolean(hdnIsPrivateModule.Value));
            }
            else
            {
                dtpopupContacts = busObj.GetAllUserContactsbyUserIDbyType(UserID, CheckAllFlag, "ALL", Convert.ToBoolean(hdnIsPrivateModule.Value));
            }
        }
        Session["ContactTable"] = dtpopupContacts;
        grdusercontacts.DataSource = dtpopupContacts;
        grdusercontacts.DataBind();
        CheckBox checkHeader = grdusercontacts.HeaderRow.FindControl("chkSelectAll") as CheckBox;
        if (CheckAllFlag == 1)
        {
            checkHeader.Checked = true;
        }
        else
        {
            checkHeader.Checked = false;
        }
        DataRow[] checkSelected;
        checkSelected = dtpopupContacts.Select("checkvalue='1'");
        if (checkSelected.Length == 1)
        {
            PnlAddEditGroups.Visible = false;
            PnlMoreContacts.Visible = false;
            PnlAddEditContacts.Visible = true;
            PnlActions.Visible = false;
            btnDeleteaContact.Visible = true;
            dtContacteDetails = busObj.GetUserContactDetailsbyContactID(Convert.ToInt32(checkSelected[0]["ContactID"].ToString()));
            if (dtContacteDetails.Rows.Count > 0)
            {
                hdnContactID.Value = checkSelected[0]["ContactID"].ToString();
                // *** Start Issue 1129 *** //
                resetdata = dtContacteDetails.Rows[0]["Firstname"].ToString();
                resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["LastName"].ToString();
                resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["Email"].ToString();
                resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["CompanyName"].ToString();
                resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["Address"].ToString();
                resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["City"].ToString();
                resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["State"].ToString();
                resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["Zipcode"].ToString();
                resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["Phone"].ToString();
                resetdata = resetdata + ",|" + dtContacteDetails.Rows[0]["Fax"].ToString();
                string mobileNum = dtContacteDetails.Rows[0]["Mobile"] == null ? "" : dtContacteDetails.Rows[0]["Mobile"].ToString();
                resetdata = resetdata + ",|" + mobileNum;
                // *** End Issue 1129 *** //

                txtFirstname.Text = dtContacteDetails.Rows[0]["Firstname"].ToString();
                txtLastname.Text = dtContacteDetails.Rows[0]["LastName"].ToString();
                txtEmail.Text = dtContacteDetails.Rows[0]["Email"].ToString();
                txtAddress.Text = dtContacteDetails.Rows[0]["Address"].ToString();
                txtCity.Text = dtContacteDetails.Rows[0]["City"].ToString();
                txtState.Text = dtContacteDetails.Rows[0]["State"].ToString();
                txtZipcode.Text = dtContacteDetails.Rows[0]["Zipcode"].ToString();
                txtPhone.Text = dtContacteDetails.Rows[0]["Phone"].ToString();
                txtFax.Text = dtContacteDetails.Rows[0]["Fax"].ToString();
                txtMobile.Text = dtContacteDetails.Rows[0]["Mobile"].ToString();
                if (txtMobile.Text.Trim() != "")
                {
                    chkMobile.Checked = true;
                    ScriptManager.RegisterClientScriptBlock(btnPnlCAddContact, GetType(), "JScript1", "ShowDiv();", true);
                }
                if (dtContacteDetails.Rows[0]["Contact_Group_Name"].ToString() != "2")
                {
                    if (dtContacteDetails.Rows[0]["Contact_Group_Name"].ToString() != "13")
                    {
                        DDLContactGroups.SelectedValue = dtContacteDetails.Rows[0]["Contact_Group_Name"].ToString();
                    }
                }
                resetdata = resetdata + ",|" + DDLContactGroups.SelectedIndex.ToString();
                btnAddUpdateContact.Text = "Update";
                if (hdnGroupID.Value != "0")
                {
                    btnDeleteaContact.Visible = true;
                    btnAddUpdateContact.Visible = true;
                }
                else
                {
                    btnAddUpdateContact.Visible = false;
                    btnDeleteaContact.Visible = false;
                }
                UpdateContact = "1";

            }
        }
        else if (checkSelected.Length > 0)
        {
            PnlAddEditContacts.Visible = false;
            PnlAddEditGroups.Visible = false;
            PnlMoreContacts.Visible = true;
            PnlActions.Visible = true;
            lblheadingmoreconatacts.Text = "Selected Contacts";
            if (hdnGroupName.Value != "")
            {
                lblmorecontacts.Text = "You have selected " + checkSelected.Length + " contact(s) from <font style='color:#4BB4D2;'>" + hdnGroupName.Value + "</font> group.";
            }
            else
            {
                if (hdnSearchText.Value != "")
                {
                    lblmorecontacts.Text = "" + dtpopupContacts.Rows.Count.ToString() + " contact(s) matched your search criteria.";
                }
                else
                {
                    lblmorecontacts.Text = "You have selected " + checkSelected.Length + " contact(s).";
                }
            }
            if (hdnGroupID.Value == "0")
            {
                PnlActions.Visible = false;
            }
            else
            {
                PnlActions.Visible = true;
            }
        }
        else if (checkSelected.Length == 0)
        {
            if (hdnGroupID.Value != "")
            {
                PnlAddEditContacts.Visible = false;
                PnlMoreContacts.Visible = false;
                PnlAddEditGroups.Visible = true;
                PnlActions.Visible = false;
                GetGroupDetailsByGroupID();
            }
            else
            {
                PnlAddEditContacts.Visible = false;
                PnlMoreContacts.Visible = true;
                PnlAddEditGroups.Visible = false;
                PnlActions.Visible = true;
                lblheadingmoreconatacts.Text = "Total Contacts";
                dtContactGroups = (DataTable)Session["GroupsTable"];
                if (hdnSearchText.Value != "")
                {
                    lblmorecontacts.Text = "" + dtpopupContacts.Rows.Count.ToString() + " contact(s) matched your search criteria.";
                }
                else
                {
                    lblmorecontacts.Text = "You have " + dtpopupContacts.Rows.Count.ToString() + " contact(s) " + (dtpopupContacts.Rows.Count == 0 ? "and " : "in ") + (Convert.ToInt32(dtContactGroups.Rows.Count.ToString()) - 1).ToString() + (dtContactGroups.Rows.Count == 1 ? "group." : " groups.");
                }
            }
        }

    }

    protected void BtnDeleteContacts_Click(object sender, EventArgs e)
    {

        int contactID = 0;
        DataRow[] drDeleteRows;
        dtpopupContacts = (DataTable)(Session["ContactTable"]);
        if (dtpopupContacts.Rows.Count > 0)
        {
            drDeleteRows = dtpopupContacts.Select("checkvalue='1'");
            if (drDeleteRows != null)
            {
                for (int i = 0; i < drDeleteRows.Length; i++)
                {
                    contactID = Convert.ToInt32(drDeleteRows[i]["ContactID"].ToString());
                    busObj.DeleteUserContact(contactID);
                }
                ClearContactControls();
                LoadInitialData("-2");
                if (drDeleteRows.Length == 1)
                {
                    lblgroupName.Text = "<font  size='3' style='color:green'><b>Your contact has been deleted successfully.</b></font>";
                }
                else
                {
                    lblmore.Text = "<font  size='3' style='color:green'><b>Your contacts have been deleted successfully.</b></font>";
                }
            }
        }

    }

    private void ClearContactControls()
    {
        txtFirstname.Text = "";
        txtLastname.Text = "";
        txtEmail.Text = "";
        txtCity.Text = "";
        txtState.Text = "";
        txtZipcode.Text = "";
        txtPhone.Text = "";
        txtMobile.Text = "";
        txtZipcode.Text = "";
        txtFax.Text = "";
        txtAddress.Text = "";
        txtcompanyname.Text = "";
        hdnreset.Value = "";
        chkMobile.Checked = false;
    }

    private void ClearGroupControls()
    {
        txtcontactgroupdes.Text = "";
        txtcontactgroupname.Text = "";
        hdnreset.Value = "";
    }

    protected void btnAddGroup_Click(object sender, EventArgs e)
    {
        ClearGroupControls();
        PnlAddEditContacts.Visible = false;
        PnlActions.Visible = false;
        PnlAddEditGroups.Visible = true;
        btnAddEditContactGroup.Text = "Add";
        btnAddEditContactGroup.Visible = true;
        PnlMoreContacts.Visible = false;
        hdnContactID.Value = "";
        hdnGroupID.Value = "";
        hdnGroupName.Value = "";
        hdnreset.Value = ",";
    }

    protected void btnAddContact_Click(object sender, EventArgs e)
    {
        ClearContactControls();
        LoadInitialData("-1");
        PnlAddEditGroups.Visible = false;
        PnlAddEditContacts.Visible = true;
        btnAddUpdateContact.Text = "Add";
        btnAddUpdateContact.Visible = true;
        PnlMoreContacts.Visible = false;
        PnlActions.Visible = false;
        SelectPreviousGroup();
        hdnreset.Value = ",|,|,|,|,|,|,|,|,|,|,|" + DDLContactGroups.SelectedIndex.ToString();
    }

    protected void btnDeleteGroup_Click(object sender, EventArgs e)
    {

        if (hdnGroupprimarykey.Value != "" && hdnGroupID.Value != "")
        {
            busObj.DeleteUserContactGroup(Convert.ToInt32(hdnGroupprimarykey.Value), hdnGroupID.Value, UserID);
            // *** issue 1492 *** //
            if (Session["PreviousSelGroup"] != null)
            {
                if (hdnGroupID.Value == Session["PreviousSelGroup"].ToString())
                {
                    Session["PreviousSelGroup"] = "13";
                    DDLContactGroups.SelectedIndex = -1;
                }
            }
            hdnContactID.Value = "";
            hdnGroupID.Value = "";
            hdnGroupName.Value = "";
            PnlAddEditContacts.Visible = false;
            PnlAddEditGroups.Visible = false;
            PnlMoreContacts.Visible = true;
            PnlActions.Visible = false;
            PostbackData();
            lblmore.Text = "<font  size='3' style='color:green'><b>Your group has been deleted successfully.</b></font>";
        }
    }

    protected void btnMoveGroupContacts_Click(object sender, EventArgs e)
    {

        dtpopupContacts = (DataTable)Session["ContactTable"];
        string parentGroupID = string.Empty;
        string movingGroupID = string.Empty;
        int contactID = 0;
        string emailAddress = string.Empty;
        string checkParentID = string.Empty;
        int checkDuplicate = 0;
        parentGroupID = hdnGroupID.Value;
        movingGroupID = DDLMovingGroup.SelectedValue;
        int checkUserMovingGroup = 0;
        DataRow[] drMovingRows = dtpopupContacts.Select("checkvalue='1'");
        if (drMovingRows.Length > 0)
        {
            for (int i = 0; i < drMovingRows.Length; i++)
            {
                checkParentID = drMovingRows[i]["Contact_Group_ID"].ToString();
                if (checkParentID != movingGroupID)
                {
                    emailAddress = drMovingRows[i]["Email"].ToString();
                    checkUserMovingGroup = busObj.CheckUserContactValidation(movingGroupID, emailAddress.Trim(), UserID);
                    if (checkUserMovingGroup == 0)
                    {
                        if (parentGroupID == "")
                        {
                            parentGroupID = checkParentID;
                        }
                        else
                        {
                            parentGroupID = drMovingRows[i]["Contact_Group_ID"].ToString();
                        }
                        contactID = Convert.ToInt32(drMovingRows[i]["ContactID"].ToString());
                        busObj.MoveUserContactsFromOneGrouptoAnotherGroup(UserID, parentGroupID, movingGroupID, contactID, CUserID);
                    }
                    else
                    {
                        checkDuplicate = 1;
                    }
                }
            }
            if (checkDuplicate == 0)
            {
                if (drMovingRows.Length == 1)
                {
                    lblgroupName.Text = "<font  size='3' style='color:green'><b>Your contact has been moved successfully.</b></font>";
                }
                else
                {
                    lblgroupName.Text = "<font  size='3' style='color:green'><b>Your contacts have been moved successfully.</b></font>";
                }
            }
            else
            {
                // Content changes 17/08/2010
                lblgroupName.Text = "<font  size='3' style='color:green'><b>Your contacts have been moved successfully from one group to another. However, one or more of them were not moved because they are already present in that group.</b></font>";
            }
        }
        hdnGroupID.Value = movingGroupID;
        hdnGroupName.Value = DDLMovingGroup.SelectedItem.Text;
        GetContactGroupIDByGroupName();
        GetGroupDetailsByGroupID();
        LoadInitialData("-2");
        PnlAddEditContacts.Visible = false;
        PnlAddEditGroups.Visible = true;
        PnlMoreContacts.Visible = false;
        PnlActions.Visible = false;
    }

    protected void lnkImportContacts_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/ImportContacts.aspx" + (Convert.ToBoolean(hdnIsPrivateModule.Value) ? "?IsScr=1" : "")));
    }

    protected void BtnExportContacts_Click(object sender, EventArgs e)
    {
        dtpopupContacts = ((DataTable)Session["ContactTable"]).Copy();
        dtpopupContacts.PrimaryKey = null;
        DataRow[] drMovingRows = dtpopupContacts.Select("checkvalue='0'");
        foreach (DataRow dRRemove in drMovingRows)
        {
            dtpopupContacts.Rows.Remove(dRRemove);
        }
        dtpopupContacts.Columns.Remove("checkvalue");
        dtpopupContacts.Columns.Remove("ContactID");
        dtpopupContacts.Columns.Remove("Contact_Group_ID");
        dtpopupContacts.Columns.Remove("User_ID");
        string attachment = "attachment; filename=" + Session["BusinessUserFirstName"].ToString() + " Contacts.xls";
        GridView grid = new GridView();
        grid.AutoGenerateColumns = false;
        BoundField bfield1 = new BoundField();
        bfield1.DataField = "name";
        bfield1.HeaderText = "Name";
        grid.Columns.Add(bfield1);
        BoundField bfield2 = new BoundField();
        bfield2.DataField = "Email";
        bfield2.HeaderText = "Email";
        grid.Columns.Add(bfield2);
        BoundField bfield3 = new BoundField();
        bfield3.DataField = "groupname";
        bfield3.HeaderText = "Group Name";
        grid.Columns.Add(bfield3);
        BoundField bfield4 = new BoundField();
        bfield4.DataField = "CompanyName";
        bfield4.HeaderText = "Company Name";
        grid.Columns.Add(bfield4);
        BoundField bfield5 = new BoundField();
        bfield5.DataField = "Address";
        bfield5.HeaderText = "Address";
        grid.Columns.Add(bfield5);
        BoundField bfield6 = new BoundField();
        bfield6.DataField = "City";
        bfield6.HeaderText = "City";
        grid.Columns.Add(bfield6);
        BoundField bfield7 = new BoundField();
        bfield7.DataField = "State";
        bfield7.HeaderText = "State";
        grid.Columns.Add(bfield7);
        BoundField bfield8 = new BoundField();
        bfield8.DataField = "Zipcode";
        bfield8.HeaderText = "Zip Code";
        grid.Columns.Add(bfield8);
        BoundField bfield9 = new BoundField();
        bfield9.DataField = "Phone";
        bfield9.HeaderText = "Landline";
        grid.Columns.Add(bfield9);
        BoundField bfield10 = new BoundField();
        bfield10.DataField = "Mobile";
        bfield10.HeaderText = "Mobile";
        grid.Columns.Add(bfield10);
        BoundField bfield11 = new BoundField();
        bfield11.DataField = "Fax";
        bfield11.HeaderText = "Fax";
        grid.Columns.Add(bfield11);
        grid.RowStyle.Wrap = true;
        grid.AlternatingRowStyle.Wrap = true;
        grid.DataSource = dtpopupContacts;
        grid.DataBind();
        grid.HeaderRow.Font.Bold = true;
        grid.HeaderRow.ForeColor = Color.White;
        grid.HeaderRow.BackColor = Color.FromName("#657383");
        Response.Clear();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter stw = new StringWriter();
        HtmlTextWriter htextw = new HtmlTextWriter(stw);
        grid.RenderControl(htextw);
        Response.Write(stw.ToString());
        Response.End();
    }

    public void CheckContactUser()
    {
        string searchName = string.Empty;
        searchName = txtSearchContact.Text.Trim();
        string searchGroup = string.Empty;
        if (searchName != "")
        {
            searchName = "%" + searchName + "%";
            if (hdnGroupID.Value == "")
            {
                searchGroup = "ALL";
            }
            else
            {
                searchGroup = hdnGroupID.Value;
            }
            hdnSearchText.Value = searchName;
            dtpopupContacts = busObj.SearchUserContactsOnUserIDandEmail(UserID, searchName, searchGroup, 0, Convert.ToBoolean(hdnIsPrivateModule.Value));
            if (dtpopupContacts.Rows.Count > 0)
            {
                DataView dV = new DataView(dtpopupContacts);
                dV.Sort = "Email ASC";
                dtpopupContacts = dV.ToTable();
                Session["ContactTable"] = dtpopupContacts;
                grdusercontacts.DataSource = dtpopupContacts;
                grdusercontacts.DataBind();
                PnlAddEditContacts.Visible = false;
                PnlAddEditGroups.Visible = false;
                PnlMoreContacts.Visible = true;
                PnlActions.Visible = true;
                lblheadingmoreconatacts.Text = "Total Contacts";
                if (dtpopupContacts.Rows.Count > 1)
                {
                    lblmorecontacts.Text = "" + dtpopupContacts.Rows.Count.ToString() + " contacts matched your search criteria.";
                }
                else
                {
                    lblmorecontacts.Text = "" + dtpopupContacts.Rows.Count.ToString() + " contact matched your search criteria.";
                }
                txtSearchContact.Focus();
            }
            else
            {
                grdusercontacts.DataSource = dtpopupContacts;
                grdusercontacts.DataBind();
                PnlAddEditContacts.Visible = false;
                PnlAddEditGroups.Visible = false;
                PnlMoreContacts.Visible = true;
                PnlActions.Visible = false;
                lblheadingmoreconatacts.Text = "";
                lblmorecontacts.Text = "";
            }
        }
    }

    protected void btnDeleteaContact_Click(object sender, EventArgs e)
    {
        busObj.DeleteUserContact(Convert.ToInt32(hdnContactID.Value));
        ClearContactControls();
        lblContacts.Text = "";
        lblContacts.Text = "<font  size='3' style='color:green'><b>Your contact has been deleted successfully.</b></font>";
        LoadInitialData("-2");
        btnAddUpdateContact.Text = "Add";
        if (hdnGroupID.Value == "0")
        {
            dtContacts = busObj.GetAllUserContactsbyUserIDbyType(UserID, CheckAllFlag, "0", Convert.ToBoolean(hdnIsPrivateModule.Value));
            BindContacts(dtContacts);
        }
    }

    private void GetContactGroupIDByGroupName()
    {
        dtContactGroups = (DataTable)Session["GroupsTable"];
        if (dtContactGroups.Rows.Count > 0)
        {
            DataRow drGroup = dtContactGroups.Rows.Find(hdnGroupID.Value);
            if (drGroup != null)
            {
                hdnGroupprimarykey.Value = drGroup["CID"].ToString();
            }
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        CheckContactUser();
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        ModalPopupExtender1.Show();
        CheckBox chk = (CheckBox)sender;
        GridViewRow gvr = (GridViewRow)chk.NamingContainer;
        int rowIndex = gvr.RowIndex;
        string dupContactID = Grdduplicate.DataKeys[rowIndex]["ContactID"].ToString();
        DropDownList drpDup = (DropDownList)Grdduplicate.Rows[rowIndex].FindControl("ddlCGroup");
        if (Session["dupchk"] != null)
        {
            ardup = (ArrayList)Session["dupchk"];
            arupdate = (ArrayList)Session["dupupdate"];
        }

        if (chk.Checked == true)
        {
            ardup.Add(dupContactID);
            arupdate.Add(drpDup.SelectedValue);
        }
        else
        {
            ardup.Remove(dupContactID);
            arupdate.RemoveAt(ardup.IndexOf(dupContactID));
        }
        Session["dupchk"] = ardup;
        Session["dupupdate"] = arupdate;
    }
    protected void btnduplicate_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Show();
        Session["groups"] = FillDropdown();
        Grdduplicate.DataSource = null;
        Grdduplicate.DataBind();
        Session["PgNmb"] = 1;
        hdnCurPg.Value = "1";
        hdnPrevPg.Value = "1";
        Session["dupchk"] = ardup;
        Session["dupupdate"] = arupdate;
        BindDuplicateRecords();
    }

    protected void GetSelectedContacts()
    {
        if (Session["dupchk"] != null)
        {
            ardup = (ArrayList)Session["dupchk"];
            arupdate = (ArrayList)Session["dupupdate"];
            foreach (GridViewRow row in Grdduplicate.Rows)
            {
                bool chk = ((CheckBox)row.FindControl("CheckBox1")).Checked;
                int cid = int.Parse(((Label)(Grdduplicate.Rows[row.RowIndex].FindControl("lblcontactID"))).Text);
                string ncgid = ((DropDownList)row.FindControl("ddlCGroup")).SelectedValue;
                if (chk == true)
                {
                    if (ardup.Contains(cid))
                        arupdate[ardup.IndexOf(cid)] = ncgid;
                    else
                    {
                        ardup.Add(cid);
                        arupdate.Add(ncgid);
                    }
                }
                else
                {
                    if (ardup.Contains(cid))
                    {
                        arupdate.RemoveAt(ardup.IndexOf(cid));
                        ardup.Remove(cid);
                    }
                }
            }
        }
        Session["dupchk"] = ardup;
        Session["dupupdate"] = arupdate;
    }
    protected void BindDuplicateRecords()
    {
        GetSelectedContacts();
        dtduplicatecon = busObj.GetDuplicateContactsByUserID(UserID, 0, int.Parse(Session["PgNmb"].ToString()), Convert.ToBoolean(hdnIsPrivateModule.Value));
        int totDupPages = int.Parse(Session["duppage"].ToString());
        StringBuilder str = new StringBuilder();
        str.Append("<table><tr>");
        int i;
        if (dtduplicatecon.Rows.Count > 0)
        {
            ModalPopupExtender1.Show();
            if (totDupPages > 1)
            {
                if (totDupPages > 10)
                {
                    if (totDupPages % 10 == 0)
                        totalPages = totDupPages / 10;
                    else
                        totalPages = totDupPages / 10 + 1;
                }

                currentPage = int.Parse(hdnCurPg.Value) - 1;

                if (currentPage != 0)
                    str.Append("<td><a runat=\"server\" href=\"javascript:__doPostBack('pgdupnmb" + currentPage * 10 + "','p')\" >...</a></td>");

                for (i = (currentPage * 10) + 1; i <= (currentPage * 10) + 10; i++)
                {
                    str.Append("<td><a id=\"pgdupnmb" + i.ToString() + "\" ");
                    if (i == int.Parse(hdnPrevPg.Value))
                        str.Append("style=\"text-decoration:none;\" ");
                    str.Append(" runat=\"server\" href=\"javascript:__doPostBack('pgdupnmb" + i.ToString() + "','')\" >" + i.ToString() + "</a></td>");

                    if (i == totDupPages)
                        break;
                }

                if (totDupPages > 10 && (currentPage + 1) != totalPages)
                    str.Append("<td><a runat=\"server\" href=\"javascript:__doPostBack('pgdupnmb" + i + "','n')\" >...</a></td>");

                str.Append("</tr></table>");
                dvPaging.InnerHtml = str.ToString();
            }
            Session["Duplicatecontacts"] = dtduplicatecon;
            Grdduplicate.DataSource = dtduplicatecon;
            Grdduplicate.DataBind();

            btndelete.Visible = true;
            btnupdate.Visible = true;
        }
        else
        {
            btndelete.Visible = false;
            btnupdate.Visible = false;
            lblnoduplicatescont.Text = "There are no duplicates in your contacts at this time.";
            ModalPopupExtender1.Hide();
        }
    }
    protected void lnkclose_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Hide();
        string url;
        if (Request.QueryString["IsScr"] != null && Convert.ToString(Request.QueryString["IsScr"]) == "1")
        {
            url = Page.ResolveClientUrl("~/Business/Myaccount/Managecontacts.aspx?IsScr=1");
            Response.Redirect(url);
        }
        else
        {
            url = Page.ResolveClientUrl("~/Business/Myaccount/Managecontacts.aspx");
            Response.Redirect(url);
        }

    }
    protected void Grdduplicate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet dsGroups = (DataSet)Session["groups"];
        DataTable dtGenericGroups = dsGroups.Tables[0];
        DataTable dtPrivateGroups = dsGroups.Tables[1];

        //// check for check box selection   
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chek = e.Row.FindControl("CheckBox1") as CheckBox;
            Label lblcDroupID = e.Row.FindControl("lblcontactgroupID") as Label;
            int groupID = Convert.ToInt32(lblcDroupID.Text);
            lblcDroupID.Visible = false;
            Label lblGroupType = e.Row.FindControl("lblIsPrivate") as Label;

            DropDownList ddl = e.Row.FindControl("ddlCGroup") as DropDownList;
            if (lblGroupType.Text.ToLower() == "privatemodulegroup")
                ddl.DataSource = dtPrivateGroups;
            else
                ddl.DataSource = dtGenericGroups;
            ddl.DataTextField = "Groupname";
            ddl.DataValueField = "Contact_Group_ID";
            ddl.DataBind();
            ddl.SelectedValue = groupID.ToString();
            // check for all check box's selection

            int dupcontact = int.Parse(Grdduplicate.DataKeys[e.Row.RowIndex]["ContactID"].ToString());
            if (CheckAllFlagdup == 1)
            {
                chek.Checked = true;
            }
            else
            {
                if (Session["dupchk"] != null)
                {
                    ardup = (ArrayList)Session["dupchk"];
                    arupdate = (ArrayList)Session["dupupdate"];
                }
                if (ardup.Contains(dupcontact))
                {
                    chek.Checked = true;
                    ddl.SelectedValue = arupdate[ardup.IndexOf(dupcontact)].ToString();
                }
                else
                {
                    chek.Checked = false;
                }
            }
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {

        ModalPopupExtender1.Show();
        GetSelectedContacts();
        ardup = (ArrayList)Session["dupchk"];
        for (int i = 0; i < ardup.Count; i++)
        {
            int Cid = int.Parse(ardup[i].ToString());
            busObj.DeleteUserContact(Cid);
        }
        Session["dupchk"] = null;
        Session["dupupdate"] = null;
        ardup.Clear();
        arupdate.Clear();
        BindDuplicateRecords();
        lblcmessage.Text = "Selected contact(s) have been deleted successfully.";
        hdncheck.Value = "";
        hdncheckchange.Value = "1";

    }

    protected DataSet FillDropdown()
    {
        DataSet dsGroups = new DataSet();
        DataTable dtContactGroups = new DataTable("GenericGroups");
        dtContactGroups = busObj.GetUserContactGroupNames(UserID);
        if (dtContactGroups.Rows.Count > 0)
        {
            string filterQuery = string.Empty;
            filterQuery = "contact_group_id='2'";
            DataRow[] dRRemove = dtContactGroups.Select(filterQuery);
            // remvoe default groups from table
            if (dRRemove != null)
            {
                for (int i = 0; i < dRRemove.Length; i++)
                {
                    dtContactGroups.Rows.Remove(dRRemove[i]);
                }
            }
        }
        DataView dV = new DataView(dtContactGroups);
        dV.Sort = "Groupname ASC";
        dtContactGroups = dV.ToTable();
        string selPrivateGrops = "GroupType='privatemodulegroup'";
        DataRow[] drfindPrivategroups = dtContactGroups.Select(selPrivateGrops);
        DataTable dtPrivateGroups = new DataTable("PrivateGroups");
        if (drfindPrivategroups.Length > 0)
            dtPrivateGroups = drfindPrivategroups.CopyToDataTable();
        for (int k = 0; k < drfindPrivategroups.Length; k++)
        {
            dtContactGroups.Rows.Remove(drfindPrivategroups[k]);
        }
        dsGroups.Tables.Add(dtContactGroups);
        dsGroups.Tables.Add(dtPrivateGroups);
        return dsGroups;
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Show();
        GetSelectedContacts();
        if (hdncheck.Value != "")
        {
            int validate = 0;
            int validate1 = 0;
            ardup = (ArrayList)Session["dupchk"];
            arupdate = (ArrayList)Session["dupupdate"];
            for (int i = 0; i < ardup.Count; i++)
            {
                int cid = int.Parse(ardup[i].ToString());
                string ncgid = arupdate[i].ToString();
                DataTable dtdetails = new DataTable();
                dtdetails = busObj.GetUserContactDetailsbyContactID(cid);
                string firstname = dtdetails.Rows[0]["Firstname"].ToString();
                string lastname = dtdetails.Rows[0]["LastName"].ToString();
                string email = dtdetails.Rows[0]["Email"].ToString();
                string address = dtdetails.Rows[0]["Address"].ToString();
                string city = dtdetails.Rows[0]["City"].ToString();
                string state = dtdetails.Rows[0]["State"].ToString();
                string zipcode = dtdetails.Rows[0]["Zipcode"].ToString();
                string phone = dtdetails.Rows[0]["Phone"].ToString();
                string fax = dtdetails.Rows[0]["Fax"].ToString();
                string mobile = dtdetails.Rows[0]["Mobile"] == null ? "" : dtdetails.Rows[0]["Mobile"].ToString();
                string oldgroup = dtdetails.Rows[0]["Contact_Group_Name"].ToString();
                string companyname = dtdetails.Rows[0]["CompanyName"].ToString();

                if (dtdetails.Rows.Count > 0)
                {
                    if (oldgroup.Trim() != ncgid.Trim())
                    {
                        int checkEmailGroup = busObj.CheckUserContactValidation(ncgid, email, UserID);
                        if (checkEmailGroup == 0)
                        {
                            busObj.UpdateBusinessUserContacts(cid, firstname, lastname, email, address, city, state, zipcode, phone, mobile, fax, ncgid, companyname, CUserID);
                            validate1++;
                        }
                        else
                        {
                            validate++;
                        }
                    }
                }
            }
            if (validate == 0)
            {
                lblcmessage.Text = "Your contact(s) have been moved to the selected group(s) successfully.";
            }
            else
            {
                if (validate1 > 0)
                {
                    lblcmessage.Text = "Your contact(s) have been moved successfully to the selected group(s). However, one or more of them were not moved because they are already present in that group.";
                }
                else
                {
                    lblcmessage.Text = "Your contact(s) were not moved to the selected group(s) because they are already present in the selected group(s).";
                }
            }

            hdncheck.Value = "";
            ardup.Clear();
            arupdate.Clear();
            Session["dupchk"] = null;
            Session["dupupdate"] = null;
            BindDuplicateRecords();
        }
        else
        {
            lblcmessage.Text = "Please change at least one contact group and try again.";
        }
        hdncheckchange.Value = "1";
    }
    private void AddContacts()
    {
        int checkEmailGroup = busObj.CheckUserContactValidation(DDLContactGroups.SelectedValue, txtEmail.Text.Trim(), UserID);
        if (checkEmailGroup == 0)
        {
            /*
            if (!chkMobile.Checked)
                txtMobile.Text = "";
            */
            int optFlag = busObj.CheckForEmailOptFlagCount(txtEmail.Text.Trim(), Convert.ToInt32(Session["UserID"].ToString()));
            if (optFlag == 0)
            {
                busObj.AddUserContactDetails(txtFirstname.Text.Trim(), txtLastname.Text.Trim(), txtEmail.Text.Trim(), txtAddress.Text.Trim(), txtCity.Text.Trim(), txtState.Text.Trim(), txtZipcode.Text.Trim(), txtPhone.Text.Trim(), txtMobile.Text.Trim(), txtFax.Text.Trim(), "Self", UserID, DateTime.Now, DDLContactGroups.SelectedValue, txtcompanyname.Text.Trim(), CUserID);
                lblContacts.Text = "<font  size='3' style='color:green'><b>Your contact has been added successfully.</b></font>";
            }
            else
                lblerror.Text = "<font  size='3' style='color:red'><b>This contact opted-out.</b></font>";
            Session["PreviousSelGroup"] = DDLContactGroups.SelectedValue;
            chkauthorize.Checked = false;
            chkMobile.Checked = false;
            ClearContactControls();
            LoadInitialData("-1");
        }
        else
        {
            lblContacts.Text = "<font  size='3' style='color:green'><b>This email address is already present in this group, please choose another group.</b></font>";
        }
    }

    protected void ddlCGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        ModalPopupExtender1.Show();
        DropDownList drpDup = (DropDownList)sender;
        GridViewRow gvr = (GridViewRow)drpDup.NamingContainer;
        int rowIndex = gvr.RowIndex;
        string dupContactID = Grdduplicate.DataKeys[rowIndex]["ContactID"].ToString();
        CheckBox chk = (CheckBox)Grdduplicate.Rows[rowIndex].FindControl("CheckBox1");
        if (chk.Checked == true)
        {
            if (Session["dupchk"] != null)
            {
                ardup = (ArrayList)Session["dupchk"];
                arupdate = (ArrayList)Session["dupupdate"];
            }
            arupdate.RemoveAt(ardup.IndexOf(dupContactID));
            arupdate.Add(drpDup.SelectedValue);
        }
        Session["dupupdate"] = arupdate;
    }
    protected void btndashboard_Click(object sender, EventArgs e)
    {
        string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/Default.aspx");
        Response.Redirect(urlinfo);
    }

    protected void btmMoveContact_OnClick(object sender, EventArgs e)
    {
        bool IsCheckedALL = false;
        foreach (GridViewRow row in grdusercontacts.Rows)
        {
            CheckBox chk = row.FindControl("chkcontact") as CheckBox;
            int ContactID = Convert.ToInt32(chk.ToolTip);
            if (chk.Checked)
            {
                IsCheckedALL = true;
                busObj.MoveUserContactsFromOneGrouptoAnotherGroup(UserID, hdnGroupID.Value, ddlGroup1.SelectedValue, ContactID, CUserID);
            }
        }

        if (IsCheckedALL == false)
        {
            lblMoveMessage.Text = "<font  size='3' style='color:red'><b>You must select a contact to move another group.</b></font>";

        }
        else
        {
            lblMoveMessage.Text = "<font  size='3' style='color:green'><b>Your contact(s) have been moved successfully.</b></font>";
        }

        LoadInitialData("-2");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(hdnIsPrivateModule.Value) == true)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/SetupInvitation.aspx?UMID=" + Session["CustomModuleID"].ToString()));
        }
        
    }


}