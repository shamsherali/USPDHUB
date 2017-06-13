using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;

namespace USPDHUB.ProfileIframes
{
    public partial class SMSContactManagement : System.Web.UI.Page
    {
        public DataTable DtpopupContacts = new DataTable();
        public DataTable DtContacts = new DataTable();
        public int UserID = 0;
        public int CheckAllFlag = 0;
        public int DDlCheck = 0;
        public int SortDir = 0;
        public int CheckSelectAll = 0;
        BusinessBLL busObj = new BusinessBLL();
        public string SelectedGroups = string.Empty;



        protected void Page_Load(object sender, EventArgs e)
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
                    DataTable DtContactGroups = new DataTable();
                    DtContactGroups = busObj.GetUserContactGroupNames(UserID);

                    if (DtContactGroups.Rows.Count > 0)
                    {
                        // Remove for general tab and affiliate groups
                        string FilterRows = string.Empty;
                        FilterRows = "contact_group_name='Generaltab'";
                        // check for affiiate page
                        if (Session["Aff"] != null)
                        {
                            FilterRows = FilterRows + " or contact_group_name='Affiliates'";
                        }
                        // reomve un selected groups
                        DataRow[] drr = DtContactGroups.Select(FilterRows);
                        for (int i = 0; i < drr.Length; i++)
                        {
                            DtContactGroups.Rows.Remove(drr[i]);
                        }

                        //  Sort Contacts Groups
                        DataView DV = new DataView(DtContactGroups);
                        DV.Sort = "Contact_Group_Name ASC";
                        DtContactGroups = DV.ToTable();

                        // End
                        drpcheck.DataSource = DtContactGroups;
                        drpcheck.DataTextField = "Contact_Group_name";
                        drpcheck.DataValueField = "Contact_Group_ID";
                        drpcheck.DataBind();
                        Session["CheckAll"] = "0";

                    }

                    // All Page load method (i.e get all selected groups contacts)
                    GetAllValuesforSelectAll();
                }
            }
        }
        protected void grdusercontacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // contacts  paging logic
            grdusercontacts.PageIndex = e.NewPageIndex;

            // assign session table
            DtpopupContacts = (DataTable)(Session["ContactTable"]);
            DtpopupContacts.PrimaryKey = new DataColumn[] { DtpopupContacts.Columns["ContactID"] };
            grdusercontacts.DataSource = DtpopupContacts;
            grdusercontacts.DataBind();

            validateselection(DtpopupContacts);

            if (DtpopupContacts.Rows.Count > 0)
            {
                // check for all contacts are selected OR not
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

                if (CheckSelectAll == 1)
                {
                    chkBxHeader.Checked = true;
                    chek.Checked = true;
                }

            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            // single check box selection
            DtpopupContacts = (DataTable)(Session["ContactTable"]);
            DtpopupContacts.PrimaryKey = new DataColumn[] { DtpopupContacts.Columns["ContactID"] };

            CheckBox chk = (CheckBox)sender;
            // find grid view selected
            GridViewRow gvr = (GridViewRow)chk.NamingContainer;
            int rowIndex = gvr.RowIndex;
            string strPrimaryKey = grdusercontacts.DataKeys[rowIndex]["contactid"].ToString();
            DataRow DrChecked;
            // find selected row from datatable
            DrChecked = DtpopupContacts.Rows.Find(strPrimaryKey);
            if (DrChecked != null)
            {
                // update selected row check value
                if (chk.Checked == true)
                {
                    DrChecked["checkvalue"] = "1";

                }
                else
                {
                    DrChecked["checkvalue"] = "0";
                    CheckBox chkBxHeader = (CheckBox)this.grdusercontacts.HeaderRow.FindControl("chkSelectAll");
                    chkBxHeader.Checked = false;
                }
            }

            validateselection(DtpopupContacts);
        }

        protected void drpcheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get selected groups contacts
            DtpopupContacts = (DataTable)(Session["ContactTable"]);
            int Flag = 0;
            DDlCheck = 1;

            if (drpcheck.Items.Count > 0)
            {
                for (int i = 0; i < drpcheck.Items.Count; i++)
                {
                    if (drpcheck.Items[i].Selected == false)
                    {
                        Flag = 1;
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
            if (Flag == 1)
            {
                chkall.Checked = false;
                GetSelectedCheckValues();
            }
            else
            {
                for (int i = 0; i < drpcheck.Items.Count; i++)
                {
                    drpcheck.Items[i].Selected = false;
                }
                chkall.Checked = true;
                GetAllValuesforSelectAll();

            }
            // *** Start of issue 1257 ***//
            if (CheckSelectAll == 1)
            {
                DtpopupContacts = (DataTable)(Session["ContactTable"]);
                if (DtpopupContacts != null)
                {
                    foreach (DataRow row in DtpopupContacts.Rows)
                    {
                        row["checkvalue"] = "1";
                    }
                }

            }
            // *** End of issue 1257 ***//
        }

        protected void chkall_CheckedChanged(object sender, EventArgs e)
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
                btnContinue.Visible = false;
                btnpopcancel.Visible = false;
                grdusercontacts.DataSource = DtpopupContacts;
                grdusercontacts.DataBind();
            }

        }

        private void GetAllValuesforSelectAll()
        {
            // Get all groups contacts
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

        private void GetAllContactDetialstoTable()
        {
            // check for all select flag
            var dt = busObj.GetAllUserContactsbyUserID(UserID, CheckAllFlag, "ALL");
            if (dt.Rows.Count > 0)
            {
                DataRow[] set = dt.Select("Mobile not like ''");
                if (set.Length > 0)
                {
                    DtContacts = set.CopyToDataTable();
                }
            }

            if (DtContacts.Rows.Count > 0)
            {
                btnContinue.Visible = true;
                btnpopcancel.Visible = true;
                DtpopupContacts.Rows.Clear();
                DtpopupContacts = DtContacts;
                // add primary key to table
                DtpopupContacts.PrimaryKey = new DataColumn[] { DtpopupContacts.Columns["ContactID"] };

                // remove unselected groups
                string FilterRows = string.Empty;
                FilterRows = "groupname='Generaltab'";
                if (Session["Aff"] != null)
                {
                    FilterRows = FilterRows + " or groupname='Affiliates'";
                }
                DataRow[] drr = DtpopupContacts.Select(FilterRows);
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

        private void GetSelectedCheckValues()
        {
            // check for all select flag
            var dt = busObj.GetAllUserContactsbyUserID(UserID, CheckAllFlag, SelectedGroups);
            if (dt.Rows.Count > 0)
            {
                DataRow[] set = dt.Select("Mobile not like ''");
                if (set.Length > 0)
                {
                    DtContacts = set.CopyToDataTable();
                }
            }


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

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
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

        protected void grdusercontacts_Sorting(object sender, GridViewSortEventArgs e)
        {
            // grid view sorting code
            SortDir = Convert.ToInt32(hdnsortcount.Value);
            string SortExp = e.SortExpression.ToString();
            DtpopupContacts = (DataTable)(Session["ContactTable"]);
            if (hdnsortdire.Value != "")
            {
                if (hdnsortdire.Value != SortExp)
                {
                    hdnsortdire.Value = SortExp;
                    SortDir = 0;
                    hdnsortcount.Value = "0";
                }
            }
            else
            {
                hdnsortdire.Value = SortExp;
            }

            DataView Dv = new DataView(DtpopupContacts);
            if (SortDir == 0)
            {

                if (SortExp == "Phone")
                {
                    Dv.Sort = "Phone ASC";
                }
                hdnsortcount.Value = "1";
            }
            else
            {
                if (SortExp == "Phone")
                {
                    Dv.Sort = "Phone DESC";
                }

                hdnsortcount.Value = "0";
            }

            Dv.Table.PrimaryKey = new DataColumn[] { DtpopupContacts.Columns["ContactID"] };
            Session["ContactTable"] = Dv.ToTable();
            grdusercontacts.DataSource = Dv;
            grdusercontacts.DataBind();

            if (Session["CheckAll"].ToString() == "1")
            {
                CheckBox chkBxHeader = (CheckBox)this.grdusercontacts.HeaderRow.FindControl("chkSelectAll");
                chkBxHeader.Checked = true;
            }
        }

        protected void validateselection(DataTable dt)
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

    }
}