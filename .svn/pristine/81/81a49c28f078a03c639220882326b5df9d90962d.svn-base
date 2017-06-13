using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;

namespace USPDHUB.Business.MyAccount
{
    public partial class ContactManagement : System.Web.UI.Page
    {
        public DataTable DtpopupContacts = new DataTable();
        public DataTable DtContacts = new DataTable();
        public int UserID = 0;
        public int CheckAllFlag = 0;
        public int DDlCheck = 0;
        public int SortDir = 0;
        public int CheckSelectAll = 0;
        BusinessBLL busObj = new BusinessBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
        public string SelectedGroups = string.Empty;

        AddOnBLL objAddOn = new AddOnBLL();
        public int UserModuleID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Check for Session
                if (Session["UserID"] != null)
                {
                    UserID = Convert.ToInt32(Session["UserID"].ToString());
                }
                if (!IsPostBack)
                {

                    if (Session["NoContact"] == null)
                    {
                        Session["ContactTable"] = null;
                        // Hdn control for Sorting
                        hdnsortdire.Value = "";
                        hdnsortcount.Value = "0";
                        // default check all groups
                        chkall.Checked = true;
                        // add contact group to check box list
                        DataTable dtContactGroups = new DataTable();
                        dtContactGroups = busObj.GetUserContactGroupNames(UserID);
                        if (dtContactGroups.Rows.Count > 0)
                        {
                            DataTable dtNormalGroups = new DataTable("dt1");
                            dtNormalGroups = busObj.GetUserContactGroupNames(UserID);

                            // Remove for general tab and affiliate groups
                            string filterRows = string.Empty;
                            filterRows = "Groupname='General Tab' or Groupname='Opt-out' or GroupType='" + ManageContactGroupTypes.PrivateModuleGroup.ToString() + "' or GroupType='smsgroup'";

                            // check for affiiate page
                            if (Session["Aff"] != null)
                            {
                                filterRows = filterRows + " or groupname='Affiliates'";
                            }
                            // reomve un selected groups
                            DataRow[] drr = dtNormalGroups.Select(filterRows);
                            for (int i = 0; i < drr.Length; i++)
                            {
                                dtNormalGroups.Rows.Remove(drr[i]);
                            }
                            //  Sort Contacts Groups             

                            DataView dV = new DataView(dtNormalGroups);
                            dV.Sort = "Contact_Group_Name ASC";
                            dtNormalGroups = dV.ToTable();

                            // End
                            drpcheck.DataSource = dtNormalGroups;
                            drpcheck.DataTextField = "Contact_Group_name";
                            drpcheck.DataValueField = "Contact_Group_ID";
                            drpcheck.DataBind();
                            Session["CheckAll"] = "0";

                            DataTable dtPrivateGroups = new DataTable("dt2");
                            var rows = dtContactGroups.Select("GroupType='" + ManageContactGroupTypes.PrivateModuleGroup.ToString() + "'");
                            if (rows.Length > 0)
                            {
                                dtPrivateGroups = rows.CopyToDataTable();
                                dV = new DataView(dtPrivateGroups);
                                dV.Sort = "Contact_Group_Name ASC";
                                dtPrivateGroups = dV.ToTable();
                            }
                            if (dtPrivateGroups.Rows.Count > 0)
                            {
                                myPanel.Visible = true;
                                drpcheck_private.DataSource = dtPrivateGroups;
                                drpcheck_private.DataTextField = "Contact_Group_name";
                                drpcheck_private.DataValueField = "Contact_Group_ID";
                                drpcheck_private.DataBind();
                            }
                            else
                                myPanel.Visible = false;

                        }
                        SelectGroups(true); // *** 1294 *** //
                        // All Page load method (i.e get all selected groups contacts)
                        GetAllValuesforSelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ContactManagement.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void SelectGroups(bool checkFlag)
        {
            for (int i = 0; i < drpcheck.Items.Count; i++)
            {
                drpcheck.Items[i].Selected = checkFlag;
            }
            for (int i = 0; i < drpcheck_private.Items.Count; i++)
            {
                drpcheck_private.Items[i].Selected = checkFlag;
            }
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
                objInBuiltData.ErrorHandling("ERROR", "ContactManagement.aspx.cs", "grdusercontacts_PageIndexChanging", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void imclose_Click(object sender, ImageClickEventArgs e)
        {
            // popup close button
            DtpopupContacts.Dispose();
        }
        protected void btnpopcancel_Click(object sender, EventArgs e)
        {
            //popup cancel button     
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            // btn continue logic
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
                    // check for all check box's selection
                    if (CheckAllFlag == 1)
                    {
                        chek.Checked = true;
                        chkBxHeader.Checked = true;
                    }
                    else
                    {
                        if (lblcheck.Text == "1")
                        {
                            chek.Checked = true;
                        }
                        else
                        {
                            chek.Checked = false;

                        }
                    }
                    // *** Start of issue 1257 ***//
                    if (CheckSelectAll == 1)
                    {
                        chkBxHeader.Checked = true;
                        chek.Checked = true;
                    }
                    // *** End of issue 1257 ***//
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ContactManagement.aspx.cs", "grdusercontacts_RowDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ContactManagement.aspx.cs", "CheckBox1_CheckedChanged", ex.Message,
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

                if (drpcheck.Items.Count > 0 || drpcheck_private.Items.Count > 0)
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
                    for (int i = 0; i < drpcheck_private.Items.Count; i++)
                    {
                        if (drpcheck_private.Items[i].Selected == false)
                        {
                            flag = 1;
                        }
                        else
                        {
                            if (SelectedGroups != "")
                            {
                                SelectedGroups = SelectedGroups + "," + drpcheck_private.Items[i].Value.ToString();
                            }
                            else
                            {
                                SelectedGroups = drpcheck_private.Items[i].Value.ToString();
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
                    for (int i = 0; i < drpcheck.Items.Count; i++)
                    {
                        drpcheck.Items[i].Selected = true; // *** 1294 *** //
                    }
                    for (int i = 0; i < drpcheck_private.Items.Count; i++)
                    {
                        drpcheck_private.Items[i].Selected = true; // *** 1294 *** //
                    }
                    chkall.Checked = true;
                    GetAllValuesforSelectAll();

                }
                // *** Start of issue 1257 ***//
                if (CheckSelectAll == 1)
                {
                    DtpopupContacts = (DataTable)(Session["ContactTable"]);
                    foreach (DataRow row in DtpopupContacts.Rows)
                    {
                        row["checkvalue"] = "1";
                    }

                }
                // *** End of issue 1257 ***//
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ContactManagement.aspx.cs", "drpcheck_SelectedIndexChanged", ex.Message,
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
                    SelectGroups(true);
                    CheckAllFlag = 0;
                    GetAllValuesforSelectAll();
                }
                else
                {
                    SelectGroups(false);
                    btnContinue.Visible = false;
                    btnpopcancel.Visible = false;
                    grdusercontacts.DataSource = DtpopupContacts;
                    grdusercontacts.DataBind();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ContactManagement.aspx.cs", "chkall_CheckedChanged", ex.Message,
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
                    btnContinue.Visible = true;
                    btnpopcancel.Visible = true;
                    Session["ContactTable"] = DtpopupContacts;
                }
                else
                {
                    grdusercontacts.DataSource = DtpopupContacts;
                    grdusercontacts.DataBind();
                    btnContinue.Visible = false;
                    btnpopcancel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ContactManagement.aspx.cs", "GetAllValuesforSelectAll", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetAllContactDetialstoTable()
        {
            try
            {
                // check for all select flag
                DtContacts = busObj.GetAllUserContactsbyUserID(UserID, CheckAllFlag, "ALL");
                if (DtContacts.Rows.Count > 0)
                {

                    btnContinue.Visible = true;
                    btnpopcancel.Visible = true;
                    DtpopupContacts.Rows.Clear();
                    DtpopupContacts = DtContacts;
                    // add primary key to table
                    DtpopupContacts.PrimaryKey = new DataColumn[] { DtpopupContacts.Columns["ContactID"] };
                    // remove unselected groups
                    string filterRows = string.Empty;

                    /*
                    if (hdnButtonType.Value == WebConstants.Tab_PrivateContentAddOns)
                    { filterRows = "Groupname='General Tab' or Groupname='Opt-out' or GroupType='' or GroupType IS NULL or GroupType='customgroup' "; }
                    else
                    { filterRows = "groupname='General Tab'  or GroupType='" + ManageContactGroupTypes.PrivateModuleGroup.ToString() + "'"; }
                    */

                    filterRows = "Groupname='General Tab' or Groupname='Opt-out'";
                    if (Session["Aff"] != null)
                    {
                        filterRows = filterRows + " or groupname='Affiliates'";
                    }
                    DataRow[] drr = DtpopupContacts.Select(filterRows);
                    for (int i = 0; i < drr.Length; i++)
                    {
                        DtpopupContacts.Rows.Remove(drr[i]);
                    }
                }
                else
                {
                    btnContinue.Visible = false;
                    btnpopcancel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ContactManagement.aspx.cs", "GetAllContactDetialstoTable", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void GetSelectedCheckValues()
        {
            try
            {
                // check for all select flag
                DtContacts = busObj.GetAllUserContactsbyUserID(UserID, CheckAllFlag, SelectedGroups);
                if (DtContacts.Rows.Count > 0)
                {
                    DtpopupContacts.Rows.Clear();
                    DtpopupContacts = DtContacts;
                    // add primary key to table
                    DtpopupContacts.PrimaryKey = new DataColumn[] { DtpopupContacts.Columns["ContactID"] };
                    grdusercontacts.DataSource = DtpopupContacts;
                    grdusercontacts.DataBind();
                    Session["ContactTable"] = DtpopupContacts;
                    btnContinue.Visible = true;
                    btnpopcancel.Visible = true;
                }
                else
                {
                    grdusercontacts.DataSource = DtContacts;
                    grdusercontacts.DataBind();
                    btnContinue.Visible = false;
                    btnpopcancel.Visible = false;

                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ContactManagement.aspx.cs", "GetSelectedCheckValues", ex.Message,
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
                    for (int i = 0; i < drpcheck_private.Items.Count; i++)
                    {
                        if (drpcheck_private.Items[i].Selected == true)
                        {
                            if (SelectedGroups != "")
                            {
                                SelectedGroups = SelectedGroups + "," + drpcheck_private.Items[i].Value.ToString();
                            }
                            else
                            {
                                SelectedGroups = drpcheck_private.Items[i].Value.ToString();
                            }
                        }

                    }
                    GetSelectedCheckValues();
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ContactManagement.aspx.cs", "chkSelectAll_CheckedChanged", ex.Message,
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
                    CheckBox chkBxHeader = (CheckBox)this.grdusercontacts.HeaderRow.FindControl("chkSelectAll");
                    chkBxHeader.Checked = true;
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ContactManagement.aspx.cs", "grdusercontacts_Sorting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void Validateselection(DataTable dt)
        {
            try
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
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ContactManagement.aspx.cs", "Validateselection", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}