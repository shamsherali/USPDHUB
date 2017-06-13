using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using stescodes;
using autoupdate;

public partial class Business_MyAccount_ImportContacts : BaseWeb
{
    public int UserID = 0;
    public int CUserID = 0;
    public static string GroupType = string.Empty;
    public string Filename = string.Empty;
    public string Filenametext = string.Empty;
    public string Filenametexttext = string.Empty;
    BusinessBLL objBus = new BusinessBLL();
    CommonBLL objCommon = new CommonBLL();
    public string ContactsUnlimited = string.Empty;
    int invalidids = 0;
    contactsgrabber cg = new contactsgrabber();
    List<contactdetails> listCd = new List<contactdetails>();
    updater updtr = new updater();
    int invalidGroupNames = 0;
    public int CheckMobile;

    public DataTable Dtpermissions = new DataTable();
    AgencyBLL agencyobj = new AgencyBLL();
    public string PermissionType = string.Empty;
    public int PermissionValue = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        lblError.Text = "";
        if (Session["userid"] == null)
        {
            string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
            Response.Redirect(urlinfo);
        }
        else
        {
            UserID = Convert.ToInt32(Session["UserID"].ToString());

            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                CUserID = Convert.ToInt32(Session["C_USER_ID"]);
            else
                CUserID = UserID;
        }
        CheckMobile = Convert.ToInt16(Session["CheckMobile"]);
        // *** Issue 1015 *** //
        if (!IsPostBack)
        {
            //roles & permissions..
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
            {
                hdnPermissionType.Value = objCommon.returnUserPermission(Convert.ToInt32(Session["C_USER_ID"]), 0, "Contacts");
                if (hdnPermissionType.Value == "A")
                {
                    UpdatePanel2.Visible = true;
                    UpdatePanel1.Visible = false;
                    lblerrormessage.Text = "<font face=arial size=2>You do not have permission to manage contacts.</font>";
                }
            }
            //ends here

            // Issue #466
            FillCheckBoxes();
            pnlmessage.Visible = false;
        }

        lblmess.Text = "";
    }
    private void ChkStatus(Boolean chkst)
    {
        foreach (GridViewRow rw in grdmailcontacts.Rows)
        {
            CheckBox ck = (CheckBox)rw.FindControl("chkbx");
            ck.Checked = chkst;
        }
    }
    protected void btnmail_Click(object sender, EventArgs e)
    {
        string contactsLimitForUser = ConfigurationManager.AppSettings.Get("ContactsLimitForUser");
        int flag = 0;
        DataTable dtContacts = new DataTable();
        dtContacts = objBus.GetAllUserContactsbyUserID(UserID, 1, "ALL");
        int userContactsCount = 0;
        DataTable dtcsvtable = (DataTable)Session["finalcsvcontacts"];
        userContactsCount = dtContacts.Rows.Count + dtcsvtable.Rows.Count;
        GroupType = "CSV";
        if (ContactsUnlimited == "1")
        {
            flag = AddContacts();
        }
        else
        {
            if (userContactsCount < Convert.ToInt32(contactsLimitForUser.Replace(",", "")))
            {
                flag = AddContacts();
            }
            else
            {
                flag = 2; // For Contacts count exceeding 1,00,000
            }
        }

        if (flag == 0)
        {
            pnl2.Visible = false;
            pnlmessage.Visible = true;
            if (invalidids == 0 && invalidGroupNames == 0)
            {
                lblsuccessmess.Text = "Your contacts were successfully imported.";
            }
            else
            {
                lblsuccessmess.Text = "<font size='2'><strong>Your contacts were successfully imported. However, " + invalidids + "  of them did not have valid email address(es) or valid group name(s) and could not be imported.</strong></font>";
            }
            drpgroup.SelectedIndex = 0;
        }
        else if (flag == 2) // Contacts count exceeding 1,00,000
        {
            lblsuccessmess.Text = "<font  size='3' style='color:green'><b>Your contacts list has exceeded the " + contactsLimitForUser + " limit. Please call customer service at 1-866-676-7335 M-F 8 a.m. - 5 p.m. PST if you would like to add more contacts.</b></font>";
            pnl2.Visible = false;
            pnlmessage.Visible = true;
            drpgroup.SelectedIndex = 0;
            btnAddMoreContacts.Visible = false;
        }
        else
        {
            pnl2.Visible = false;
            pnlmessage.Visible = true;
            drpgroup.SelectedIndex = 0;
            string message = "<font size='2'><strong>One or more contacts have been imported to this group.";
            if (hdnGroupname.Value != "")
            {
                message = message.Replace("this group", "group(" + hdnGroupname.Value + ")");
                hdnGroupname.Value = "";
            }
            if (hdnGroupsCount.Value != "")
            {
                if (Convert.ToInt32(hdnGroupsCount.Value) > 1)
                    message = "One or more contacts have been imported to selected groups.</strong></font>";
            }

            if (invalidids == 0)
            {
                lblsuccessmess.Text = message;
            }
            else
            {
                lblsuccessmess.Text = message + invalidids + "  of them did not have valid email address(es) and could not be imported.</strong></font>";
            }
        }

    }
    private void FillCheckBoxes()
    {
        DataTable dtContactGroups = new DataTable();
        dtContactGroups = objBus.GetUserContactGroupNames(UserID);
        if (dtContactGroups.Rows.Count > 0)
        {
            string filterQuery = string.Empty;
            filterQuery = "contact_group_id='0' or contact_group_id='2' or contact_group_id='1' or contact_group_id='14' or Groupname='" + ConfigurationManager.AppSettings.Get("ReportsInquiryGroupName") + "'";
            DataRow[] dRRemove = dtContactGroups.Select(filterQuery);
            // remvoe default groups from table
            if (dRRemove != null)
            {
                for (int i = 0; i < dRRemove.Length; i++)
                {
                    dtContactGroups.Rows.Remove(dRRemove[i]);
                }
            }
            string selQueryGroups = "GroupType='privatemodulegroup'";
            if (Convert.ToBoolean(hdnIsPrivateModule.Value))
            {
                selQueryGroups = "GroupType='' OR GroupType='customgroup' OR GroupType IS NULL";
            }
            DataRow[] dRRemoveprivate = dtContactGroups.Select(selQueryGroups);
            // remvoe default groups from table
            if (dRRemoveprivate.Length > 0)
            {
                for (int i = 0; i < dRRemoveprivate.Length; i++)
                {
                    dtContactGroups.Rows.Remove(dRRemoveprivate[i]);
                }
            }
            drpgroup.DataSource = dtContactGroups;
            drpgroup.DataTextField = "Contact_Group_name";
            drpgroup.DataValueField = "Contact_Group_ID";
            drpgroup.DataBind();
            drpgroup.Items.Insert(0, new ListItem("--Select--", "0"));
            if (Session["PreviousSelGroup"] == null)
                Session["PreviousSelGroup"] = "13";
            drpgroup.SelectedValue = Session["PreviousSelGroup"].ToString();
        }

    }
    protected void grdmailcontacts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            CheckBox chk = e.Row.FindControl("chkSelectAll") as CheckBox;
            chk.Attributes.Add("onclick", "javascript:SelectAll('" + chk.ClientID + "')");
        }
    }
    protected void btnAddGroup_Click(object sender, EventArgs e)
    {
        bool IsSystemGroup = false;
        bool IsMasterGroup = false;
        int check = 0;
        check = objBus.CheckUserListingValidation(txtgroup.Text.Trim(), UserID);
        if (check == 0)
        {
            int maxContactGroupID = 0;
            // get Max contact group id for that user ID
            maxContactGroupID = objBus.GetMaximunContactGroupIDForUserID(UserID);
            // Add +1 to insert new contact group Id
            maxContactGroupID = maxContactGroupID + 1;
            // insert contact group for that userid
            objBus.InsertContactGroupName(maxContactGroupID, txtgroup.Text.Trim(), UserID, DateTime.Now, DateTime.Now, true, string.Empty, CUserID,
                ManageContactGroupTypes.CustomGroup.ToString(), 0, IsSystemGroup, IsMasterGroup);
            lblmess.Text = "<font  size='3' color=green><b>Your group has been added successfully.</b></font>";
            FillCheckBoxes();
            drpgroup.SelectedIndex = drpgroup.Items.IndexOf(drpgroup.Items.FindByText(txtgroup.Text + " ( 0 )"));
            txtgroup.Text = "";
            DataTable dtContactGroupsadded = new DataTable();
            dtContactGroupsadded = objBus.GetUserContactGroupNames(UserID);
            if (dtContactGroupsadded.Rows.Count > 0)
            {
                string filterQuery = string.Empty;
                filterQuery = "contact_group_id='0' or contact_group_id='1' or contact_group_id='14' or Groupname='" + ConfigurationManager.AppSettings.Get("ReportsInquiryGroupName") + "'";
                filterQuery = filterQuery + "  or contact_group_id='2'";
                DataRow[] dRRemove = dtContactGroupsadded.Select(filterQuery);
                // remvoe default groups from table
                if (dRRemove != null)
                {
                    for (int i = 0; i < dRRemove.Length; i++)
                    {
                        dtContactGroupsadded.Rows.Remove(dRRemove[i]);
                    }
                }
            }
            foreach (GridViewRow row in grdmailcontacts.Rows)
            {

                DropDownList drpcontacts = grdmailcontacts.Rows[row.RowIndex].FindControl("drplist") as DropDownList;
                if (drpcontacts != null)
                {

                    drpcontacts.DataSource = dtContactGroupsadded;
                    drpcontacts.DataTextField = "Contact_Group_name";
                    drpcontacts.DataValueField = "Contact_Group_ID";
                    drpcontacts.DataBind();
                    drpcontacts.Items.Insert(0, new ListItem("--Select--", "0"));

                }

            }
            AppenedGruopuToContacts();
        }
        else
        {
            lblmess.Text = "<font color=red>" + Resources.LabelMessages.DuplicateListingmessage + "</font>";
        }

    }
    protected void CSVSubmit_Click(object sender, EventArgs e)
    {
        int headerempty = 0;
        string fileext = string.Empty;
        if (FileUpload1.HasFile)
        {
            try
            {
                Filename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                fileext = Path.GetExtension(Filename);
                if (fileext == ".csv" || fileext == ".CSV")
                {
                    DataTable dt = new DataTable();
                    CSVReader reader = new CSVReader(FileUpload1.PostedFile.InputStream);
                    //get the header
                    string[] headers = reader.GetCsvLine();

                    DataTable dtheaders = new DataTable();
                    dtheaders.Columns.Add("Select");
                    DataRow drcon1 = dtheaders.NewRow();
                    drcon1["Select"] = "------- Select Appropriate Item ------";
                    dtheaders.Rows.Add(drcon1);
                    //add headers 
                    foreach (string strHeader in headers)
                    {
                        if (strHeader == "")
                            headerempty = 1;
                        dtheaders.Rows.Add(strHeader.Trim());
                        dt.Columns.Add(strHeader.Trim());
                    }
                    if (headerempty != 1)
                    {
                        if (dtheaders.Rows.Count > 1)
                        {
                            dtheaders.DefaultView.Sort = "Select ASC";
                            ddlfirstname.DataSource = ddllastname.DataSource = ddlemail.DataSource = ddladdress.DataSource = ddlcity.DataSource = ddlstate.DataSource = ddlzipcode.DataSource = ddlphone.DataSource = ddlmobile.DataSource = ddlfax.DataSource = ddlcompanyname.DataSource = ddlGroupName.DataSource = dtheaders;
                            ddlfirstname.DataTextField = ddllastname.DataTextField = ddlemail.DataTextField = ddladdress.DataTextField = ddlcity.DataTextField = ddlstate.DataTextField = ddlzipcode.DataTextField = ddlphone.DataTextField = ddlmobile.DataTextField = ddlfax.DataTextField = ddlcompanyname.DataTextField = ddlGroupName.DataTextField = "Select";
                            ddlfirstname.DataValueField = ddllastname.DataValueField = ddlemail.DataValueField = ddladdress.DataValueField = ddlcity.DataValueField = ddlstate.DataValueField = ddlzipcode.DataValueField = ddlphone.DataValueField = ddlmobile.DataValueField = ddlfax.DataValueField = ddlcompanyname.DataValueField = ddlGroupName.DataValueField = "Select";
                            ddlfirstname.DataBind();
                            ddllastname.DataBind();
                            ddlemail.DataBind();
                            ddladdress.DataBind();
                            ddlcity.DataBind();
                            ddlstate.DataBind();
                            ddlzipcode.DataBind();
                            ddlphone.DataBind();
                            ddlmobile.DataBind();
                            ddlfax.DataBind();
                            ddlcompanyname.DataBind();
                            ddlGroupName.DataBind();
                            string[] data;
                            while ((data = reader.GetCsvLine()) != null)
                                dt.Rows.Add(data);
                            Session["datatablecsv"] = dt;
                            hdnCsvName.Value = Filename;
                            Filenametext = "<font size='3' color='green'>You have uploaded - </font><strong><font color='#3399CC', size='3'>" + Filename + ". </font></strong>" + "<font size='3' color='green'>Please </font>";
                            Filenametexttext = "<font size='3' color='green'> to change the file.</font>";
                            pnlimpcolumns.Visible = true;
                            pnl1.Visible = false;
                        }
                        else
                        {
                            lblError.Text = "The file you have chosen has no data. Please upload another CSV file.";
                        }
                    }
                    else
                    {
                        lblError.Text = "Failed to import : " + "An exception has occured while processing your request. Please check the data in the uploaded file and try again.";
                    }
                }
                else
                    lblError.Text = "Please check the format of the file you have uploaded. Only CSV file is allowed.";

            }
            catch (Exception /*ex*/)
            {

                lblError.Text = "Failed to import : " + "An exception has occured while processing your request. Please check the data in the uploaded file and try again.";
            }
        }
        else
            lblError.Text = "Please select a file to upload";

    }
    protected void drpgroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        AppenedGruopuToContacts();
    }
    private void AppenedGruopuToContacts()
    {
        if (Session["pnlmailgrid"] != null)
        {
            if (Session["pnlmailgrid"].ToString() == "Yes")
            {
                foreach (GridViewRow grw in grdmailcontacts.Rows)
                {
                    DropDownList drp = (DropDownList)grw.FindControl("drplist");
                    if (drp != null)
                    {
                        drp.SelectedValue = drpgroup.SelectedValue;
                    }

                }
            }
        }
    }
    protected void btnAddMoreContacts_Click(object sender, EventArgs e)
    {
        pnl1.Visible = true;
        pnl2.Visible = false;
        pnlmessage.Visible = false;
        drpgroup.Visible = true;
        spnGrpContact.Visible = true;
        lblcsvcontacts.Text = "";
        chkauthorize.Checked = false;
        ddlGroupName.SelectedIndex = -1;
        hdnGroupsCount.Value = "";
        hdnCsvName.Value = "";
        hdnGroupname.Value = "";
        hdnContactscount.Value = "";
        tdSelectGroup.Visible = true;
        SelectGroupnone.Visible = false;
        Session["pnlmailgrid"] = null;
        FillCheckBoxes();
    }
    protected void btnDashBoard_Click(object sender, EventArgs e)
    {
        Session["pnlmailgrid"] = null;
        string urlinfo = Page.ResolveClientUrl("~/Business/MyAccount/managecontacts.aspx");
        Response.Redirect(urlinfo);
    }

    public void FillGridDropDown()
    {
        DataTable dtContactGroups = new DataTable();
        dtContactGroups = objBus.GetUserContactGroupNames(UserID);

        if (dtContactGroups.Rows.Count > 0)
        {
            string filterQuery = string.Empty;
            filterQuery = "contact_group_id='0' or contact_group_id='1' or contact_group_id='14' or Groupname='" + ConfigurationManager.AppSettings.Get("ReportsInquiryGroupName") + "'";
            filterQuery = filterQuery + " or contact_group_id='2'";
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
        if (Session["pnlmailgrid"] != null)
        {
            if (Session["pnlmailgrid"].ToString() == "Yes")
            {
                foreach (GridViewRow grw in grdmailcontacts.Rows)
                {
                    DropDownList drp = (DropDownList)grw.FindControl("drplist");
                    if (drp != null)
                    {
                        drp.DataSource = dtContactGroups;
                        drp.DataTextField = "Contact_Group_name";
                        drp.DataValueField = "Contact_Group_ID";
                        drp.DataBind();
                        drp.Items.Insert(0, new ListItem("--Select--", "0"));
                    }

                }
            }
        }
    }


    protected void btndashboard1_Click(object sender, EventArgs e)
    {
        string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/Default.aspx");
        Response.Redirect(urlinfo);
    }

    protected void btnwizard_Click(object sender, EventArgs e)
    {
        string urlinfo = Page.ResolveClientUrl("~/Business/Myaccount/ManageBusinessDetails.aspx");
        Response.Redirect(urlinfo);
    }

    protected void lnktestdownload_Click(object sender, EventArgs e)
    {
        string downloadFileName = Server.MapPath("~/temp/") + "test.xls";
        string name = Path.GetFileName(downloadFileName);
        string ext = Path.GetExtension(downloadFileName);
        string type = "";
        // set known types based on file extension  
        if (ext != null)
        {
            switch (ext.ToLower())
            {
                case ".htm":
                case ".html":
                    type = "text/HTML";
                    break;

                case ".txt":
                    type = "text/plain";
                    break;

                case ".doc":
                case ".rtf":
                    type = "Application/msword";
                    break;
            }
        }

        Response.AppendHeader("content-disposition",
            "attachment; filename=" + name);
        if (type != "")
            Response.ContentType = type;
        Response.WriteFile(downloadFileName);
        Response.End();



    }

    protected void Submit1_Click(object sender, EventArgs e)
    {
        DataTable dtdata = new DataTable();
        string userfn = string.Empty;
        string userln = string.Empty;
        string useremail = string.Empty;
        string useradd = string.Empty;
        string usercity = string.Empty;
        string userstate = string.Empty;
        string userzipcode = string.Empty;
        string userphone = string.Empty;
        string usermobile = string.Empty;
        string userfax = string.Empty;
        string usercompanyname = string.Empty;
        string usergroupname = string.Empty;

        dtdata = ((DataTable)Session["datatablecsv"]).Copy();
        try
        {
            useremail = ddlemail.SelectedItem.Text.ToString();
            if (dtdata.Columns.Contains("Email"))
            {
                if (useremail != "Email")
                    dtdata.Columns[useremail].ColumnName = "EzCommonEmail";
            }
            else
                dtdata.Columns[useremail].ColumnName = "Email";

            userfn = ddlfirstname.SelectedItem.Text.ToString();
            if (dtdata.Columns.Contains("First Name"))
            {
                if (userfn != "First Name" && userfn != "------- Select Appropriate Item ------")
                    dtdata.Columns[userfn].ColumnName = "EzFirstName";
            }
            else
            {
                if (userfn != "------- Select Appropriate Item ------")
                    dtdata.Columns[userfn].ColumnName = "First Name";
                else
                    dtdata.Columns.Add("First Name");
            }

            userln = ddllastname.SelectedItem.Text.ToString();
            if (dtdata.Columns.Contains("Last Name"))
            {
                if (userln != "Last Name" && userln != "------- Select Appropriate Item ------")
                    dtdata.Columns[userln].ColumnName = "EzLastName";
            }
            else
            {
                if (userln != "------- Select Appropriate Item ------")
                    dtdata.Columns[userln].ColumnName = "Last Name";
                else
                    dtdata.Columns.Add("Last Name");
            }

            usercompanyname = ddlcompanyname.SelectedItem.Text.ToString();
            if (dtdata.Columns.Contains("Company Name"))
            {
                if (usercompanyname != "Company Name" && usercompanyname != "------- Select Appropriate Item ------")
                    dtdata.Columns[usercompanyname].ColumnName = "EzCompanyName";
            }
            else
            {
                if (usercompanyname != "------- Select Appropriate Item ------")
                    dtdata.Columns[usercompanyname].ColumnName = "Company Name";
                else
                    dtdata.Columns.Add("Company Name");
            }

            useradd = ddladdress.SelectedItem.Text.ToString();
            if (dtdata.Columns.Contains("Address"))
            {
                if (useradd != "Address" && useradd != "------- Select Appropriate Item ------")
                    dtdata.Columns[useradd].ColumnName = "EzAddress";
            }
            else
            {
                if (useradd != "------- Select Appropriate Item ------")
                    dtdata.Columns[useradd].ColumnName = "Address";
                else
                    dtdata.Columns.Add("Address");
            }

            usercity = ddlcity.SelectedItem.Text.ToString();
            if (dtdata.Columns.Contains("City"))
            {
                if (usercity != "City" && usercity != "------- Select Appropriate Item ------")
                    dtdata.Columns[usercity].ColumnName = "EzCity";
            }
            else
            {
                if (usercity != "------- Select Appropriate Item ------")
                    dtdata.Columns[usercity].ColumnName = "City";
                else
                    dtdata.Columns.Add("City");
            }

            userstate = ddlstate.SelectedItem.Text.ToString();
            if (dtdata.Columns.Contains("State"))
            {
                if (userstate != "State" && userstate != "------- Select Appropriate Item ------")
                    dtdata.Columns[userstate].ColumnName = "EzState";
            }
            else
            {
                if (userstate != "------- Select Appropriate Item ------")
                    dtdata.Columns[userstate].ColumnName = "State";
                else
                    dtdata.Columns.Add("State");
            }

            userzipcode = ddlzipcode.SelectedItem.Text.ToString();
            if (dtdata.Columns.Contains("Zipcode"))
            {
                if (userzipcode != "Zipcode" && userzipcode != "------- Select Appropriate Item ------")
                    dtdata.Columns[userzipcode].ColumnName = "EzZipcode";
            }
            else
            {
                if (userzipcode != "------- Select Appropriate Item ------")
                    dtdata.Columns[userzipcode].ColumnName = "Zipcode";
                else
                    dtdata.Columns.Add("Zipcode");
            }

            userphone = ddlphone.SelectedItem.Text.ToString();
            if (dtdata.Columns.Contains("Phone Number"))
            {
                if (userphone != "Phone Number" && userphone != "------- Select Appropriate Item ------")
                    dtdata.Columns[userphone].ColumnName = "EzPhoneNumber";
            }
            else
            {
                if (userphone != "------- Select Appropriate Item ------")
                    dtdata.Columns[userphone].ColumnName = "Phone Number";
                else
                    dtdata.Columns.Add("Phone Number");
            }
            usermobile = ddlmobile.SelectedItem.Text.ToString();
            if (usermobile != "------- Select Appropriate Item ------")
            {
                CheckMobile = 1;
                Session["CheckMobile"] = CheckMobile;
            }
            else
            {
                CheckMobile = 0;
                Session["CheckMobile"] = CheckMobile;
            }
            if (dtdata.Columns.Contains("Mobile Number"))
            {
                if (usermobile != "Mobile Number" && usermobile != "------- Select Appropriate Item ------")
                    dtdata.Columns[usermobile].ColumnName = "EzMobileNumber";
            }
            else
            {
                if (usermobile != "------- Select Appropriate Item ------")
                    dtdata.Columns[usermobile].ColumnName = "Mobile Number";
                else
                    dtdata.Columns.Add("Mobile Number");
            }
            userfax = ddlfax.SelectedItem.Text.ToString();
            if (dtdata.Columns.Contains("Fax Number"))
            {
                if (userfax != "Fax Number" && userfax != "------- Select Appropriate Item ------")
                    dtdata.Columns[userfax].ColumnName = "EzFaxNumber";
            }
            else
            {
                if (userfax != "------- Select Appropriate Item ------")
                    dtdata.Columns[userfax].ColumnName = "Fax Number";
                else
                    dtdata.Columns.Add("Fax Number");
            }

            //issue 752 start
            usergroupname = ddlGroupName.SelectedItem.Text.ToString();
            if (dtdata.Columns.Contains("Group Name"))
            {
                if (usergroupname != "Group Name" && usergroupname != "------- Select Appropriate Item ------")
                    dtdata.Columns[usergroupname].ColumnName = "EzGroupName";
            }
            else
            {
                if (usergroupname != "------- Select Appropriate Item ------")
                    dtdata.Columns[usergroupname].ColumnName = "Group Name";
                else
                    dtdata.Columns.Add("Group Name");
            }
            //issue 752 end


            if (dtdata.Rows.Count > 0)
            {
                lblcsvcontacts.Text = "<font color='green' size='3'>The file you have uploaded has </font>" + "<font size='3' color='#3399CC'><b>" + dtdata.Rows.Count + "</b></font><font color='green' size='3'> contacts.</font>";
                pnlimpcolumns.Visible = false;
                pnl1.Visible = false;
                pnlmailgrid.Visible = false;
                pnlcsvgrd.Visible = true;

                chkauthorize.Checked = false;
                Session["finalcsvcontacts"] = dtdata;

                if (ddlGroupName.SelectedIndex > 0)
                {
                    tdSelectGroup.Visible = false;
                    SelectGroupnone.Visible = true;
                    // display selected groups and count of contacts
                    pnlSelectedGroups.Visible = true;

                    DataTable dtDistinct = dtdata.DefaultView.ToTable(true, "Group Name");

                    spnGroups.InnerHtml = "";
                    int cnt = 0;
                    for (int i = 0; i < dtDistinct.Rows.Count; i++)
                    {
                        cnt = dtdata.Select("[Group Name]='" + dtDistinct.Rows[i][0].ToString() + "'").Length;
                        spnGroups.InnerHtml += dtDistinct.Rows[i][0].ToString() + " (" + cnt + ")<br/>";
                    }
                    hdnGroupsCount.Value = dtDistinct.Rows.Count.ToString();
                    if (dtDistinct.Rows.Count == 1)
                        hdnGroupname.Value = dtDistinct.Rows[0][0].ToString();
                    lblOR.Visible = btncsvcontacts.Visible = drpgroup.Visible = spnGrpContact.Visible = false;
                    //btncsvGrpContact.Visible = true;
                }
                else
                {
                    tdSelectGroup.Visible = true;
                    SelectGroupnone.Visible = false;
                    pnl2.Visible = true;
                    lblOR.Visible = btncsvcontacts.Visible = drpgroup.Visible = spnGrpContact.Visible = true;
                    btncsvGrpContact.Visible = false;
                }
            }
            else
            {
                lblerrormsg.Text = "There are no contacts in the uploaded CSV file. Please upload another CSV file.";
            }

        }
        catch (Exception ex)
        {
            lblerrormsg.Text = ex.Message;
        }
    }
    protected void Cancelcontacts_Click(object sender, EventArgs e)
    {
        Session["pnlmailgrid"] = null;
        string urlimportcon = Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx");
        Response.Redirect(urlimportcon);
    }
    protected void lnkchangefile_Click(object sender, EventArgs e)
    {
        pnl1.Visible = true;
        pnlimpcolumns.Visible = false;
        pnlcsvservice.Visible = true;
    }
    private int AddContacts()
    {
        string firstname = string.Empty;
        string lastname = string.Empty;
        string address = string.Empty;
        string city = string.Empty;
        string state = string.Empty;
        string zipcode = string.Empty;
        string phonenumber = string.Empty;
        string mobilenumber = string.Empty;
        string faxnumber = string.Empty;
        string companyname = string.Empty;
        string groupName = string.Empty;
        int flag = 0;
        DataTable dtcsvtable = (DataTable)Session["finalcsvcontacts"];
        string pattern = @"\d{3}\-\d{3}\-\d{4}";
        Regex reMobile = new Regex(pattern);
        if (drpgroup.SelectedValue != "0" || ddlGroupName.SelectedIndex > 0)
        {
            foreach (DataRow dr in dtcsvtable.Rows)
            {
                string email = dtcsvtable.Columns.Contains("EzCommonEmail") ? dr["EzCommonEmail"].ToString() : dr["Email"].ToString();
                email = email.Replace("&nbsp;", "");
                firstname = dtcsvtable.Columns.Contains("EzFirstName") ? dr["EzFirstName"].ToString() : dr["First Name"].ToString();
                firstname = firstname.Replace("&nbsp;", "");
                lastname = dtcsvtable.Columns.Contains("EzLastName") ? dr["EzLastName"].ToString() : dr["Last Name"].ToString();
                lastname = lastname.Replace("&nbsp;", "");
                address = dtcsvtable.Columns.Contains("EzAddress") ? dr["EzAddress"].ToString() : dr["Address"].ToString();
                address = address.Replace("&nbsp;", "");
                city = dtcsvtable.Columns.Contains("EzCity") ? dr["EzCity"].ToString() : dr["City"].ToString();
                city = city.Replace("&nbsp;", "");
                state = dtcsvtable.Columns.Contains("EzState") ? dr["EzState"].ToString() : dr["State"].ToString();
                state = state.Replace("&nbsp;", "");
                zipcode = dtcsvtable.Columns.Contains("EzZipcode") ? dr["EzZipcode"].ToString() : dr["Zipcode"].ToString();
                zipcode = zipcode.Replace("&nbsp;", "");
                phonenumber = dtcsvtable.Columns.Contains("EzPhoneNumber") ? dr["EzPhoneNumber"].ToString() : dtcsvtable.Columns.Contains("Phone Number") ? dr["Phone Number"].ToString() : "";
                phonenumber = phonenumber.Replace("&nbsp;", "");
                if (chkMobile.Checked)
                {
                    mobilenumber = dtcsvtable.Columns.Contains("EzMobileNumber") ? dr["EzMobileNumber"].ToString() : dr["Mobile Number"].ToString();
                    mobilenumber = mobilenumber.Replace("&nbsp;", "");
                    mobilenumber = reMobile.IsMatch(mobilenumber) ? mobilenumber : "";
                }
                faxnumber = dtcsvtable.Columns.Contains("EzFaxNumber") ? dr["EzFaxNumber"].ToString() : dr["Fax Number"].ToString();
                faxnumber = faxnumber.Replace("&nbsp;", "");
                companyname = dtcsvtable.Columns.Contains("EzCompanyName") ? dr["EzCompanyName"].ToString() : dr["Company Name"].ToString();
                companyname = companyname.Replace("&nbsp;", "");
                groupName = dtcsvtable.Columns.Contains("EzGroupName") ? dr["EzGroupName"].ToString() : dr["Group Name"].ToString();
                groupName = groupName.Replace("&nbsp;", "") == "" ? "Not Grouped" : groupName.Replace("&nbsp;", "");
                firstname = System.Text.RegularExpressions.Regex.Replace(firstname, @"[^\w\. ]", "");
                string split = "@";
                string[] names;
                names = firstname.Split(split.ToCharArray());
                int checkEmailGroup = 0;
                //issue 752 start
                int groupID = 0;
                bool isGroupMatched = false;
                Regex objAlphaPattern = new Regex(@"^[a-zA-Z0-9 ]*$");
                if (ddlGroupName.SelectedIndex > 0)
                {
                    if (objAlphaPattern.IsMatch(groupName))
                    {
                        groupID = objBus.CheckGroupExistenceByGroupName(UserID, groupName);
                        checkEmailGroup = objBus.CheckUserContactValidation(groupID.ToString(), email, UserID);
                        isGroupMatched = true;
                    }
                }
                //issue 752 end
                else
                {
                    if (hdnGroupname.Value == "")
                    {
                        hdnGroupname.Value = drpgroup.SelectedItem.ToString().Split("(".ToCharArray())[0].Trim();
                    }
                    checkEmailGroup = objBus.CheckUserContactValidation(drpgroup.SelectedValue, email, UserID);
                    isGroupMatched = true;
                }
                if (checkEmailGroup == 0)
                {
                    email = email.Replace(" ", "");
                    string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                    Regex re = new Regex(strRegex);
                    if (isGroupMatched == true && re.IsMatch(email))
                    {
                        objBus.AddUserContactDetails(names[0].ToString(), lastname, email, address, city, state, zipcode, phonenumber, mobilenumber, faxnumber, GroupType, UserID, DateTime.Today, ddlGroupName.SelectedIndex > 0 ? groupID.ToString() : drpgroup.SelectedValue, companyname, CUserID);
                    }
                    else
                    {
                        invalidids++;
                    }
                }
                else
                {
                    flag = 1;
                }
            }
        }
        else
        {
            lblerrorgroup.Text = "Please select a group.";
        }

        return flag;
    }

    protected void btnRemap_Click(object sender, EventArgs e)
    {
        Filename = hdnCsvName.Value;
        pnlSelectedGroups.Visible = false;
        pnlimpcolumns.Visible = true;
        ddlfirstname.SelectedIndex = ddllastname.SelectedIndex = ddlemail.SelectedIndex = ddladdress.SelectedIndex = ddlcity.SelectedIndex = ddlstate.SelectedIndex = ddlzipcode.SelectedIndex = ddlphone.SelectedIndex = ddlmobile.SelectedIndex = ddlfax.SelectedIndex = ddlcompanyname.SelectedIndex = ddlGroupName.SelectedIndex = 0;
        Filenametext = "<font size='3' color='green'>You have uploaded - </font><strong><font color='#3399CC', size='3'>" + Filename + ". </font></strong>" + "<font size='3' color='green'>Please </font>";
        Filenametexttext = "<font size='3' color='green'> to change the file.</font>";
    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        pnl2.Visible = true;
        btncsvGrpContact.Visible = true;
        pnlSelectedGroups.Visible = false;
    }

    protected void btnyahoocancel_Click(object sender, EventArgs e)
    {
        string urlimportcon = Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx");
        Response.Redirect(urlimportcon);
    }
    protected void grdmailcontacts_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
