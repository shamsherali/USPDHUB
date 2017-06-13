using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace USPDHUB.Business.MyAccount
{
    public partial class ManageCallIndexContacts : BaseWeb
    {
        AddOnBLL objAddOns = new AddOnBLL();
        public int UserID = 0;
        public int ProfileID = 0;
        public int UserModuleID = 0;
        public int C_UserID = 0;
        DataTable dtGroupNameList = new DataTable();
        public string groupIds = string.Empty;
        public string contactIds = string.Empty;
        public string Filename = string.Empty;
        public string Filenametext = string.Empty;
        public string Filenametexttext = string.Empty;
        int invalidids = 0;
        public int CheckAllFlag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            UserID = Convert.ToInt32(Session["UserID"].ToString());
            ProfileID = Convert.ToInt32(Session["ProfileID"].ToString());
            C_UserID = UserID;
            if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")
                C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
            if (Session["CustomModuleID"] != null)
                UserModuleID = Convert.ToInt32(Session["CustomModuleID"].ToString());
            if (!IsPostBack)
            {
                BindGroupsData();
            }
        }

        private void BindGroupsData()
        {
            try
            {
                DataSet dsGroups = new DataSet();
                dsGroups = objAddOns.GetCallIndexGroups(UserModuleID);
                GVGroupNames.DataSource = dsGroups.Tables[0];
                GVGroupNames.DataBind();
                //GVCallIndexContacts.DataSource = dsGroups.Tables[1];
                //GVCallIndexContacts.DataBind();
            }
            catch
            {
            }
        }

        protected void btnAddGroup_Click(object sender, EventArgs e)
        {
            txtcontactgroupname.Text = "";
            txtcontactgroupdes.Text = "";
            hdnGroupID.Value = "";
            btnAdd.Text = "Add";
            MPEGroups.Show();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int groupID = 0;
            if (!string.IsNullOrEmpty(hdnGroupID.Value))
                groupID = Convert.ToInt32(hdnGroupID.Value);

            if (groupID > 0)
            {
                objAddOns.AddGroup(groupID, txtcontactgroupname.Text, txtcontactgroupdes.Text, true, false, UserModuleID, ProfileID, C_UserID, UserID);
                hdnGroupID.Value = "";

            }
            else
            {
                objAddOns.AddGroup(groupID, txtcontactgroupname.Text, txtcontactgroupdes.Text, true, false, UserModuleID, ProfileID, C_UserID, UserID);

            }
            BindGroupsData();
            GVCallIndexContacts.DataBind();
        }
        protected void chkGroupName_CheckedChanged(object sender, EventArgs e)
        {
            int count = 0;
            CheckBox chkBxHeader = (CheckBox)GVGroupNames.HeaderRow.FindControl("chkAllGroup");
            foreach (GridViewRow grow in GVGroupNames.Rows)
            {

                CheckBox chkSelect = (CheckBox)grow.FindControl("chkGroupName");

                if (chkSelect.Checked)
                {
                    count++;
                    chkBxHeader.Checked = false;
                    if (groupIds != "")
                    {
                        groupIds = groupIds + "," + GVGroupNames.DataKeys[grow.RowIndex].Values[0].ToString();
                    }
                    else
                    {
                        groupIds = GVGroupNames.DataKeys[grow.RowIndex].Values[0].ToString();

                    }
                }
            }

            if (count == GVGroupNames.Rows.Count)
            {
                chkBxHeader.Checked = true;
            }


            dtGroupNameList = objAddOns.GetActiveContacts(UserModuleID, groupIds);
            GVCallIndexContacts.DataSource = dtGroupNameList;
            GVCallIndexContacts.DataBind();
        }

        protected void btnGroupDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow grow in GVGroupNames.Rows)
            {

                CheckBox chkdel = (CheckBox)grow.FindControl("chkGroupName");

                if (chkdel.Checked)
                {
                    if (groupIds != "")
                    {
                        groupIds = groupIds + "," + GVGroupNames.DataKeys[grow.RowIndex].Values[0].ToString();
                    }
                    else
                    {
                        groupIds = GVGroupNames.DataKeys[grow.RowIndex].Values[0].ToString();

                    }
                }
            }

            objAddOns.DeleteGroups(groupIds);
            BindGroupsData();
            GVCallIndexContacts.DataBind();
        }
        protected void lnkEditGroup_Click(object sender, EventArgs e)
        {

            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int GroupID = Convert.ToInt32(GVGroupNames.DataKeys[row.RowIndex].Values[0].ToString());
            DataSet ds = new DataSet();
            ds = objAddOns.GetGroupByID(GroupID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtcontactgroupname.Text = ds.Tables[0].Rows[0]["GroupName"].ToString();
                txtcontactgroupdes.Text = ds.Tables[0].Rows[0]["GroupDescription"].ToString();
                hdnGroupID.Value = Convert.ToString(GroupID);
                btnAdd.Text = "Update";
                MPEGroups.Show();
            }
        }
        protected void btnPnlCAddContact_Click(object sender, EventArgs e)
        {
            try
            {
                txtFirstname.Text = "";
                txtLastname.Text = "";
                txtEmail.Text = "";
                txtcompanyname.Text = "";
                txtAddress.Text = "";
                txtCity.Text = "";
                txtState.Text = "";
                txtZipcode.Text = "";
                txtPhone.Text = "";
                txtMobile.Text = "";
                txtFax.Text = "";
                txtPosition.Text = "";
                txtOrganization.Text = "";
                BindActiveGroups();
                hdnContactID.Value = "";
                btnContactAdd.Text = "Add";
                chkMobile.Checked = false;
                chkSendInvitation.Checked = false;
                MPEContacts.Show();
                lblmsg1.Text = "";
            }
            catch
            {
            }
        }

        private void BindActiveGroups()
        {
            DataSet dsGroups = new DataSet();
            //dsGroups = objAddOns.GetCallIndexGroups(UserModuleID);
            dsGroups = objAddOns.GetCallIndexActiveGroups(UserModuleID);
            if (dsGroups.Tables[0].Rows.Count > 0)
            {
                chkGroupList.DataSource = dsGroups.Tables[0];
                chkGroupList.DataTextField = "GroupName_Count";
                chkGroupList.DataValueField = "GroupID";
                chkGroupList.DataBind();
            }
        }

        protected void btnContactAdd_Click(object sender, EventArgs e)
        {
            string SelectedGroups = string.Empty;
            string UnCheckedGroups = string.Empty;
            int contactID = 0;
            int insertId = 0;
            string contactGroups = "";
            List<int> objExtContactgroups = new List<int>();
            if (!string.IsNullOrEmpty(hdnContactID.Value))
                contactID = Convert.ToInt32(hdnContactID.Value);
            int existingContactId = objAddOns.CheckEmailExists(txtEmail.Text.Trim(), UserModuleID, contactID,txtMobile.Text.Trim());
            if (existingContactId >= 0)
            {
                contactGroups = objAddOns.GetCallContactGroups(contactID);
                if (contactGroups != string.Empty)
                {
                    contactGroups = contactGroups.TrimEnd(',');
                    objExtContactgroups = contactGroups.Split(',').Select(int.Parse).ToList();
                }
                if (contactID == 0 && existingContactId > 0)
                    insertId = existingContactId;
                else if (existingContactId == 0)
                    insertId = contactID;
                insertId = objAddOns.InsertUpdateContacts(insertId, txtFirstname.Text, txtLastname.Text, txtEmail.Text, txtcompanyname.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZipcode.Text, txtPhone.Text, txtMobile.Text, txtFax.Text, true, false, UserModuleID, ProfileID, UserID, C_UserID, txtPosition.Text, txtOrganization.Text, chkSendInvitation.Checked, false);
                if (insertId > 0)
                {

                    if (chkGroupList.Items.Count > 0)
                    {
                        for (int i = 0; i < chkGroupList.Items.Count; i++)
                        {
                            if (chkGroupList.Items[i].Selected)
                            {
                                if (objExtContactgroups.Contains(Convert.ToInt32(chkGroupList.Items[i].Value.ToString())))
                                    objExtContactgroups.Remove(Convert.ToInt32(chkGroupList.Items[i].Value.ToString()));  
                                else
                                    objAddOns.AssignGroupContactID(0, Convert.ToInt32(chkGroupList.Items[i].Value), insertId);
                            }
                        }
                    }
                    if (contactID == 0 && existingContactId > 0)
                        objExtContactgroups = new List<int>();
                    if (objExtContactgroups.Count > 0)
                    {
                        for (int i = 0; i < objExtContactgroups.Count; i++)
                        {
                            objAddOns.AssignGroupContactID(1, objExtContactgroups[i], contactID);
                        }
                    }
                    hdnContactID.Value = "";
                    BindGroupsData();
                    GVCallIndexContacts.DataBind();
                    if (btnContactAdd.Text == "Add")
                        lblMsg.Text = "Contact Saved Successfully";
                    else
                        lblMsg.Text = "Contact Updated Successfully";
                }
                else
                {
                    MPEContacts.Show();
                }
            }
            else
            {
                if (existingContactId == -2)
                    lblmsg1.Text = "Email address or mobile number is already in use; please use a different one.";
                else if (existingContactId == -1)
                    lblmsg1.Text = "You cannot change the contact email address as this contact has already receive the invitation.";
                MPEContacts.Show();
            }

        }
        protected void btnDeleteContact_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow grow in GVCallIndexContacts.Rows)
            {
                CheckBox chkdel = (CheckBox)grow.FindControl("chkContactEmail");

                if (chkdel.Checked)
                {
                    if (contactIds != "")
                    {
                        contactIds = contactIds + "," + GVCallIndexContacts.DataKeys[grow.RowIndex].Values[0].ToString();
                    }
                    else
                    {
                        contactIds = GVCallIndexContacts.DataKeys[grow.RowIndex].Values[0].ToString();
                    }
                }
            }
            objAddOns.DeleteContacts(contactIds);
            BindGroupsData();
            GVCallIndexContacts.DataBind();
        }
        protected void lnkEditContact_Click(object sender, EventArgs e)
        {
            lblmsg1.Text = "";
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int ContactID = Convert.ToInt32(GVCallIndexContacts.DataKeys[row.RowIndex].Values[0].ToString());
            DataSet ds = new DataSet();
            ds = objAddOns.GetContactByID(ContactID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtFirstname.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastname.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                txtcompanyname.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                txtZipcode.Text = ds.Tables[0].Rows[0]["Zipcode"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["Landline"].ToString();
                txtMobile.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                txtFax.Text = ds.Tables[0].Rows[0]["FaxNumber"].ToString();
                txtPosition.Text = ds.Tables[0].Rows[0]["Position"].ToString();
                txtOrganization.Text = ds.Tables[0].Rows[0]["Organization"].ToString();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["IsAllowedToSendIvitation"].ToString()))
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsAllowedToSendIvitation"].ToString()) == true)
                    {
                        chkSendInvitation.Checked = true;
                    }
                    else
                    {
                        chkSendInvitation.Checked = false;
                    }
                }

                else
                {
                    chkSendInvitation.Checked = false;
                }
                //Contact Groups
                int GroupId, SelectedGroup;
                BindActiveGroups();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        GroupId = Convert.ToInt32(ds.Tables[1].Rows[i]["GroupID"].ToString());
                        for (int j = 0; j < chkGroupList.Items.Count; j++)
                        {
                            SelectedGroup = Convert.ToInt32(chkGroupList.Items[j].Value.ToString());
                            if (GroupId == SelectedGroup)
                            {
                                chkGroupList.Items[j].Selected = true;
                                break;
                            }
                        }
                    }
                }
                hdnContactID.Value = Convert.ToString(ContactID);
                btnContactAdd.Text = "Update";
                MPEContacts.Show();
                chkMobile.Checked = true;
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objAddOns.SearchEmailID(txtSearchContact.Text, UserModuleID);
                GVCallIndexContacts.DataSource = dt;
                GVCallIndexContacts.DataBind();
                txtSearchContact.Text = "";
            }
            catch
            {
            }
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
            DataSet dsGroups = new DataSet();
            dsGroups = objAddOns.GetCallIndexGroups(UserModuleID);
            ddlGroups.DataSource = dsGroups.Tables[0];
            ddlGroups.DataTextField = "GroupName";
            ddlGroups.DataValueField = "GroupID";
            ddlGroups.DataBind();
            ddlGroups.Items.Insert(0, new ListItem(" -- Select -- ", ""));
            modalImport.Show();
            lblError.Text = "";
            txtImportGroup.Text = "";
            pnlImportAddGroup.Visible = true;
            pnlCSV.Visible = false;
            pnlImportColumns.Visible = false;
        }
        protected void btnGroupNext_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            int groupId = 0;
            if (ddlGroups.SelectedValue != "")
            {
                groupId = Convert.ToInt32(ddlGroups.SelectedValue);
                hdnImportGroupName.Value = ddlGroups.SelectedItem.Text;
            }
            else
            {
                groupId = objAddOns.AddGroup(0, txtImportGroup.Text.Trim(), "", true, false, UserModuleID, ProfileID, C_UserID, UserID);
                if (groupId > 0)
                {
                    hdnImportGroupName.Value = txtImportGroup.Text.Trim();
                    BindGroupsData();
                }

            }
            if (groupId > 0)
            {
                hdnImportGroupId.Value = groupId.ToString();
                pnlCSV.Visible = true;
                pnlImportAddGroup.Visible = false;
            }
            modalImport.Show();
        }
        protected void CSVSubmit_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            int headerempty = 0;
            string fileext = string.Empty;
            if (FileUpload1.HasFile)
            {
                try
                {
                    Filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
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
                                ddlfirstname.DataSource = ddllastname.DataSource = ddlemail.DataSource = ddladdress.DataSource = ddlcity.DataSource = ddlstate.DataSource = ddlzipcode.DataSource = ddlphone.DataSource = ddlmobile.DataSource = ddlfax.DataSource = ddlcompanyname.DataSource = ddlTitle.DataSource = ddlOrg.DataSource = dtheaders;
                                ddlfirstname.DataTextField = ddllastname.DataTextField = ddlemail.DataTextField = ddladdress.DataTextField = ddlcity.DataTextField = ddlstate.DataTextField = ddlzipcode.DataTextField = ddlphone.DataTextField = ddlmobile.DataTextField = ddlfax.DataTextField = ddlcompanyname.DataTextField = ddlTitle.DataTextField = ddlOrg.DataTextField = "Select";
                                ddlfirstname.DataValueField = ddllastname.DataValueField = ddlemail.DataValueField = ddladdress.DataValueField = ddlcity.DataValueField = ddlstate.DataValueField = ddlzipcode.DataValueField = ddlphone.DataValueField = ddlmobile.DataValueField = ddlfax.DataValueField = ddlcompanyname.DataValueField = ddlTitle.DataValueField = ddlOrg.DataValueField = "Select";
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
                                ddlTitle.DataBind();
                                ddlOrg.DataBind();
                                string[] data;
                                while ((data = reader.GetCsvLine()) != null)
                                    dt.Rows.Add(data);
                                Session["datatablecsv"] = dt;
                                hdnCsvName.Value = Filename;
                                Filenametext = "<font size='3' color='green'>You have uploaded - </font><strong><font color='#3399CC', size='3'>" + Filename + ". </font></strong>" + "<font size='3' color='green'>Please </font>";
                                Filenametexttext = "<font size='3' color='green'> to change the file.</font>";
                                pnlImportColumns.Visible = true;
                                pnlCSV.Visible = false;
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
            modalImport.Show();
        }
        protected void lnkChangeFile_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            pnlCSV.Visible = true;
            pnlImportColumns.Visible = false;
            modalImport.Show();
        }
        protected void Submit1_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
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
            string usertitle = string.Empty;
            string userorg = string.Empty;

            dtdata = ((DataTable)Session["datatablecsv"]).Copy();
            try
            {
                useremail = ddlemail.SelectedItem.Text.ToString();
                if (dtdata.Columns.Contains("Email"))
                {
                    if (useremail != "Email" && useremail != "------- Select Appropriate Item ------")
                        dtdata.Columns[useremail].ColumnName = "EzCommonEmail";
                }
                else
                {
                    if (useremail != "------- Select Appropriate Item ------")
                        dtdata.Columns[useremail].ColumnName = "Email";
                    else
                        dtdata.Columns.Add("Email");
                }

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
                //Adding new Columns Title and Organization
                usertitle = ddlTitle.SelectedItem.Text.ToString();
                if (dtdata.Columns.Contains("Title"))
                {
                    if (usertitle != "Title" && usertitle != "------- Select Appropriate Item ------")
                        dtdata.Columns[usertitle].ColumnName = "EzTitle";
                }
                else
                {
                    if (usertitle != "------- Select Appropriate Item ------")
                        dtdata.Columns[usertitle].ColumnName = "Title";
                    else
                        dtdata.Columns.Add("Title");
                }
                userorg = ddlOrg.SelectedItem.Text.ToString();
                if (dtdata.Columns.Contains("Organization"))
                {
                    if (userorg != "Organization" && userorg != "------- Select Appropriate Item ------")
                        dtdata.Columns[userorg].ColumnName = "EzOrganization";
                }
                else
                {
                    if (userorg != "------- Select Appropriate Item ------")
                        dtdata.Columns[userorg].ColumnName = "Organization";
                    else
                        dtdata.Columns.Add("Organization");
                }

                int successCount = 0;
                if (dtdata.Rows.Count > 0)
                {
                    AddContacts(dtdata, out successCount);
                    if (invalidids == 0)
                    {
                        //lblMsg.Text = "Your contacts were successfully imported.";
                        lblMsg.Text = Resources.LabelMessages.ImportContactsSuccess.Replace("#successcount#", successCount.ToString());
                    }
                    else
                    {
                        lblMsg.Text = "<font size='2'><strong>Your contacts were successfully imported. However, " + invalidids + "  of them did not have valid email address(es) and could not be imported.</strong></font>";
                    }

                    BindGroupsData();
                    modalImport.Hide();
                }
                else
                {
                    lblError.Text = "There are no contacts in the uploaded CSV file. Please upload another CSV file.";
                    modalImport.Show();
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                modalImport.Show();
            }
        }
        protected void Cancelcontacts_Click(object sender, EventArgs e)
        {

        }
        private int AddContacts(DataTable dtcsvtable, out int successCount)
        {
            successCount = 0;
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
            string title = string.Empty;
            string organization = string.Empty;
            int flag = 0;
            string pattern = @"\d{3}\-\d{3}\-\d{4}";
            Regex reMobile = new Regex(pattern);
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
                phonenumber = dtcsvtable.Columns.Contains("EzPhoneNumber") ? dr["EzPhoneNumber"].ToString() : dr["Phone Number"].ToString();
                phonenumber = phonenumber.Replace("&nbsp;", "");
                mobilenumber = dtcsvtable.Columns.Contains("EzMobileNumber") ? dr["EzMobileNumber"].ToString() : dr["Mobile Number"].ToString();
                mobilenumber = mobilenumber.Replace("&nbsp;", "");
                mobilenumber = reMobile.IsMatch(mobilenumber) ? mobilenumber : "";
                faxnumber = dtcsvtable.Columns.Contains("EzFaxNumber") ? dr["EzFaxNumber"].ToString() : dr["Fax Number"].ToString();
                faxnumber = faxnumber.Replace("&nbsp;", "");
                companyname = dtcsvtable.Columns.Contains("EzCompanyName") ? dr["EzCompanyName"].ToString() : dr["Company Name"].ToString();
                companyname = companyname.Replace("&nbsp;", "");
                title = dtcsvtable.Columns.Contains("EzTitle") ? dr["EzTitle"].ToString() : dr["Title"].ToString();
                title = title.Replace("&nbsp;", "");
                organization = dtcsvtable.Columns.Contains("EzOrganization") ? dr["EzOrganization"].ToString() : dr["Organization"].ToString();
                organization = organization.Replace("&nbsp;", "");
                firstname = System.Text.RegularExpressions.Regex.Replace(firstname, @"[^\w\. ]", "");
                string split = "@";
                string[] names;
                names = firstname.Split(split.ToCharArray());
                email = email.Replace(" ", "");
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(email))
                {
                    objAddOns.InsertImportContacts(0, names[0].ToString(), lastname, email, companyname, address, city, state, zipcode, phonenumber, mobilenumber, faxnumber, true, false, UserModuleID, ProfileID, UserID, C_UserID, Convert.ToInt32(hdnImportGroupId.Value), title, organization);
                    successCount++;
                }
                else
                {
                    invalidids++;
                }
            }

            return flag;
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx"));
        }

        //Select All for Groups
        protected void chkAllGroup_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               
                CheckBox chkBxHeader = (CheckBox)this.GVGroupNames.HeaderRow.FindControl("chkAllGroup");
                if (chkBxHeader.Checked == true)
                {
                    foreach (GridViewRow grow in GVGroupNames.Rows)
                    {
                        CheckBox chkSelect = (CheckBox)grow.FindControl("chkGroupName");
                        chkSelect.Checked = true;
                        if (groupIds != "")
                        {
                            groupIds = groupIds + "," + GVGroupNames.DataKeys[grow.RowIndex].Values[0].ToString();
                        }
                        else
                        {
                            groupIds = GVGroupNames.DataKeys[grow.RowIndex].Values[0].ToString();

                        }
                    }

                }
                else
                {
                    foreach (GridViewRow grow in GVGroupNames.Rows)
                    {
                        CheckBox chkSelect = (CheckBox)grow.FindControl("chkGroupName");
                        chkSelect.Checked = false;
                    }
                }

                dtGroupNameList = objAddOns.GetActiveContacts(UserModuleID, groupIds);
                GVCallIndexContacts.DataSource = dtGroupNameList;
                GVCallIndexContacts.DataBind();
            }
            catch (Exception ex)
            {
            }
        }
       
    }
}