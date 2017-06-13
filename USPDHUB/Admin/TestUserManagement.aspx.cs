using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.IO;
using System.Configuration;
using System.Drawing;


namespace USPDHUB.Admin
{
    public partial class TestUserManagement : System.Web.UI.Page
    {
        public int AdminUserID = 0;
        public string Userid = string.Empty;
        public Boolean TypeOfBusiness = false;
        BusinessBLL busobj = new BusinessBLL();
        AdminBLL adminobj = new AdminBLL();
        AgencyBLL agencyobj = new AgencyBLL();
        public string RootPath = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["adminuserid"] != null)
                {
                    AdminUserID = Convert.ToInt32(Session["adminuserid"]);
                }
                else
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                RootPath = Session["RootPath"].ToString();

                if (ddloption.SelectedIndex <= 0)
                {
                    EmailREValidator.Visible = false;
                    TextREValidator.Visible = false;

                }
                if (!IsPostBack)
                {
                    FillGrid();// Populate Data in to ConsumersGrid
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        public void FillGrid()
        {
            try
            {
                //Populate Data in to ConsumersGrid
                if (ddloption.SelectedIndex <= 0)
                {
                    DataTable dtobj = new DataTable();

                    dtobj = adminobj.FillUsersData(true);
                    if (dtobj.Rows.Count <= 0)
                    {
                        btn_ExporttoExcel.Visible = false;
                        Button1.Visible = false;
                    }
                    else
                    {
                        btn_ExporttoExcel.Visible = true;
                        Button1.Visible = true;
                    }
                    Session["userstableTest"] = dtobj;
                    ConsumersGrid.DataSource = dtobj;
                    ConsumersGrid.DataBind();
                }
                else
                {
                    lblerr.Text = "";
                    //Search User data
                    DataTable stable = new DataTable("SearchData");
                    string searchText = txtsearch.Text.Trim();
                    string ddlSelectValue = ddloption.SelectedValue;
                    stable = adminobj.GetUsersData(searchText, ddlSelectValue, true, ddlVerticals.SelectedValue, ddlCountries.SelectedValue);
                    Session["userstableTest"] = stable;
                    if (stable.Rows.Count <= 0)
                    {
                        btn_ExporttoExcel.Visible = false;
                        Button1.Visible = false;
                    }
                    else
                    {
                        btn_ExporttoExcel.Visible = true;
                        Button1.Visible = true;
                    }
                    ConsumersGrid.DataSource = stable;
                    ConsumersGrid.DataBind();
                }
                DataTable dtverticals = agencyobj.GetActiveVerticals();
                ddlVerticals.DataSource = dtverticals;
                ddlVerticals.DataTextField = "Vertical_Name";
                ddlVerticals.DataValueField = "Vertical_Value";
                ddlVerticals.DataBind();
                ddlVerticals.Items.Insert(0, new ListItem("-- Select --", ""));
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "FillGrid", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnClientUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Admin/ConsumerManagement.aspx"));
        }
        protected void btnArchive_Click(object sender, EventArgs e)
        {
            try
            {
                int selUsersCount = 0;
                //Identify CheckBox is checked or not
                foreach (GridViewRow row in ConsumersGrid.Rows)
                {
                    if (((CheckBox)row.FindControl("CheckBox1")).Checked)
                    {
                        int uid = int.Parse(((Label)(ConsumersGrid.Rows[row.RowIndex].FindControl("Label1"))).Text);
                        int result = adminobj.ArchiveUser(uid, true);
                        selUsersCount++;
                    }
                }
                if (selUsersCount > 0)
                    lblerr.Text = "<Font face=arial color=green size=2>Selected user(s) have been marked as demo user(s) successfully.</font>";
                else
                    lblerr.Text = "<Font face=arial color=red size=2>No user found.</font>";
                FillGrid();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "btnArchive_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnRealUsers_Click(object sender, EventArgs e)
        {
            try
            {
                int selUsersCount = 0;
                //Identify CheckBox is checked or not
                foreach (GridViewRow row in ConsumersGrid.Rows)
                {
                    if (((CheckBox)row.FindControl("CheckBox1")).Checked)
                    {
                        int uid = int.Parse(((Label)(ConsumersGrid.Rows[row.RowIndex].FindControl("Label1"))).Text);
                        int result = adminobj.ArchiveUser(uid, false);
                        selUsersCount++;
                    }
                }
                if (selUsersCount > 0)
                    lblerr.Text = "<Font face=arial color=green size=2>Selected user(s) have been marked as real user(s) successfully.</font>";
                else
                    lblerr.Text = "<Font face=arial color=red size=2>No user found.</font>";
                FillGrid();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "btnRealUsers_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkClientAc_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnk = sender as LinkButton;
                string testuserID = lnk.CommandArgument;
                int result = adminobj.UpdateUserType(Convert.ToInt32(testuserID), false);
                if (result == 0)
                    lblerr.Text = "<Font face=arial color=green size=2>User has been changed successfully as client user.</font>";
                else
                    lblerr.Text = "<Font face=arial color=red size=2>No user found.</font>";
                FillGrid();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "lnkClientAc_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid == true)
                {
                    if (ddloption.SelectedIndex <= 0)
                    {
                        lblerr.Text = "<Font face=arial color=red size=2> Please Choose Search Option";
                    }
                    else
                    {
                        lblerr.Text = "";

                        BindSearchData();
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "btnsearch_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BindSearchData()
        {
            try
            {
                //Search User data
                DataTable stable = new DataTable("SearchData");
                string searchText = txtsearch.Text.Trim();
                string ddlSelectValue = ddloption.SelectedValue;
                stable = adminobj.GetUsersData(searchText, ddlSelectValue, true, ddlVerticals.SelectedValue, ddlCountries.SelectedValue);
                if (stable.Columns.Contains("Profile_zipcode"))
                {
                    stable.Columns["Profile_zipcode"].ColumnName = "User_zipcode";
                }
                //********************Checking for Real Users*********************//
                if (chkRealUsers.Checked)
                    for (int i = 0; i < stable.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(stable.Rows[i]["IsArchived"]) == true)    // if IsArchived is true then Demo Users
                            stable.Rows[i].Delete();
                    }
                //********************Checking for Real Users*********************//
                Session["userstableTest"] = stable;
                if (stable.Rows.Count <= 0)
                {
                    btn_ExporttoExcel.Visible = false;
                    Button1.Visible = false;
                }
                else
                {
                    btn_ExporttoExcel.Visible = true;
                    Button1.Visible = true;
                }
                ConsumersGrid.DataSource = stable;
                ConsumersGrid.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "BindSearchData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void DeleteUsersRecord(object sender, EventArgs e)
        {
            try
            {
                //Identify CheckBox is checked or not
                foreach (GridViewRow row in ConsumersGrid.Rows)
                {
                    if (((CheckBox)row.FindControl("CheckBox1")).Checked)
                    {
                        int uid = int.Parse(((Label)(ConsumersGrid.Rows[row.RowIndex].FindControl("Label1"))).Text);
                        int ConfirmDelete = 0;
                        #  region user tracking
                        // user tracking                           
                        string hostName = System.Net.Dns.GetHostName();
                        string localipaddress = string.Empty;
                        System.Net.IPHostEntry local = System.Net.Dns.GetHostEntry(hostName);
                        foreach (System.Net.IPAddress useripaddres in local.AddressList)
                        {
                            localipaddress = useripaddres.ToString();

                        }

                        # endregion
                        ConfirmDelete = adminobj.DeleteUsersRecord(uid, AdminUserID, localipaddress);
                        if (ConfirmDelete == 1)
                        {
                            lblerr.Text = "<Font face=arial color=green size=2>Selected user(s) have been deleted successfully.</font>";
                        }
                    }
                }
                FillGrid();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "DeleteUsersRecord", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void ConsumersGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //delete Record form ConsumersGrid
                int uid = int.Parse(((Label)(ConsumersGrid.Rows[e.RowIndex].FindControl("Label1"))).Text);
                AdminBLL adminObj = new AdminBLL();

                string hostName = System.Net.Dns.GetHostName();
                string localipaddress = string.Empty;
                System.Net.IPHostEntry local = System.Net.Dns.GetHostEntry(hostName);
                foreach (System.Net.IPAddress useripaddres in local.AddressList)
                {
                    localipaddress = useripaddres.ToString();

                }
                adminObj.DeleteUsersRecord(uid, AdminUserID, localipaddress);
                FillGrid();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "ConsumersGrid_RowDeleting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void ConsumersGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Edit Record in ConsumersGrid
            ConsumersGrid.EditIndex = e.NewEditIndex;
            FillGrid();
        }
        protected void ddloption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Search  Validations
                switch (ddloption.SelectedIndex)
                {
                    case 1:
                        if (ddloption.SelectedValue == "Firstname")
                        {
                            EmailREValidator.Visible = false;
                            TextREValidator.Visible = true;
                        }
                        break;
                    case 2:
                        if (ddloption.SelectedValue == "Lastname")
                        {
                            EmailREValidator.Visible = false;
                            TextREValidator.Visible = true;
                        }
                        break;
                    case 3:
                        if (ddloption.SelectedValue == "Email")
                        {
                            TextREValidator.Visible = false;
                            EmailREValidator.Visible = true;
                        }
                        break;
                    case 4:
                        if (ddloption.SelectedValue == "Business Name")
                        {
                            EmailREValidator.Visible = false;
                            TextREValidator.Visible = true;
                        }
                        break;
                    case 5:
                        if (ddloption.SelectedValue == "Zip code")
                        {
                            EmailREValidator.Visible = false;
                            TextREValidator.Visible = true;
                        }
                        break;
                    case 6:
                        if (ddloption.SelectedValue == "All")
                        {
                            EmailREValidator.Visible = false;
                            TextREValidator.Visible = false;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "ddloption_SelectedIndexChanged", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void ConsumersGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Cancle Record in ConsumersGrid
            ConsumersGrid.EditIndex = -1;
            FillGrid();
        }
        protected void ConsumersGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                #region Issue No : #108
                // Lavanya
                //06-01-09

                // Raise Alerts
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label lbltype = e.Row.FindControl("lbltype") as Label;
                    Label lblIsArchived = e.Row.FindControl("lblIsArchived") as Label;
                    if (lblIsArchived.Text != "" && Convert.ToBoolean(lblIsArchived.Text) == false)
                        e.Row.CssClass = "realusers";
                    Userid = ConsumersGrid.DataKeys[e.Row.RowIndex].Value.ToString();
                    DataTable dtprofiledetails = new DataTable();
                    DataTable dtuser = new DataTable();
                    dtuser = busobj.GetUserDetailsByUserID(int.Parse(Userid));
                    int roleid = Convert.ToInt32(dtuser.Rows[0]["Role_ID"].ToString());
                    if (dtuser.Rows.Count > 0)
                    {
                        bool isfree = false;
                        if (dtuser.Rows[0]["IsFree"] != null)
                        {
                            if (dtuser.Rows[0]["IsFree"].ToString() != "")
                            {
                                isfree = Convert.ToBoolean(dtuser.Rows[0]["IsFree"].ToString());
                            }
                        }
                        if (isfree == false)
                        {
                            if (roleid == 2)
                            {
                                lbltype.Text = "Paid Member";
                            }
                            if (roleid == 1)
                            {
                                lbltype.Text = "Free Listing";
                            }
                        }
                        else
                        {
                            lbltype.Text = "Free Listing";
                        }
                    }
                #endregion
                    dtprofiledetails = busobj.GetBusinessDeatilsByUserID(int.Parse(Userid));
                    if (dtprofiledetails.Rows.Count == 1)
                    {
                        string cities = "";
                        string categories = "";
                        Label lblprofilename = e.Row.FindControl("lblcompanyname") as Label;
                        lblprofilename.Text = dtprofiledetails.Rows[0]["Profile_Name"].ToString();
                        LinkButton lnk = e.Row.FindControl("lbtnpname") as LinkButton;
                        lnk.Text = dtprofiledetails.Rows[0]["Profile_Name"].ToString();
                        Label lblusername = e.Row.FindControl("Label4") as Label;
                        string profileid = dtprofiledetails.Rows[0]["Profile_ID"].ToString();
                        TypeOfBusiness = false;
                        if (TypeOfBusiness == true)
                        {
                            lnk.Visible = true;
                            lblprofilename.Visible = false;
                            lnk.CommandArgument = profileid;
                        }
                        else
                        {
                            if (cities.Length > 0 && categories.Length > 0 && lblusername.Text.Length > 0)
                            {
                                lnk.Visible = true;
                                lblprofilename.Visible = false;
                                lnk.CommandArgument = profileid;
                            }
                            else
                            {
                                lblprofilename.Visible = true;
                                lnk.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "ConsumersGrid_RowDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void ConsumersGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ConsumersGrid.PageIndex = e.NewPageIndex;
            ConsumersGrid.DataBind();
            FillGrid();
        }
        protected void ConsumersGrid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                string userID = ((Label)(ConsumersGrid.Rows[e.NewSelectedIndex].FindControl("Label1"))).Text;
                int roleID = 0;
                if (((Label)(ConsumersGrid.Rows[e.NewSelectedIndex].FindControl("Label7"))).Text == "Business")
                    roleID = 2;
                else if (((Label)(ConsumersGrid.Rows[e.NewSelectedIndex].FindControl("Label7"))).Text == "Consumer")
                    roleID = 1;
                else if (((Label)(ConsumersGrid.Rows[e.NewSelectedIndex].FindControl("Label7"))).Text == "AdminStaff")
                    roleID = 4;
                Response.Redirect("ModifyUserDetails.aspx?ID=" + userID + "&RoleID=" + roleID);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "ConsumersGrid_SelectedIndexChanging", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected string GetRoleName(int gval)
        {
            if (Convert.ToInt32(UtilitiesBLL.RoleTypes.Admin) == gval)
                return "Admin";
            else if (Convert.ToInt32(UtilitiesBLL.RoleTypes.AdminStaff) == gval)
                return "AdminStaff";
            else if (Convert.ToInt32(UtilitiesBLL.RoleTypes.Consumer) == gval)
                return "Consumer";
            else if (Convert.ToInt32(UtilitiesBLL.RoleTypes.Business) == gval)
                return "Business";
            else if (Convert.ToInt32(UtilitiesBLL.RoleTypes.Advertiser) == gval)
                return "Advertiser";
            else
                return string.Empty;

        }
        protected void btn_goDashboard(object sender, EventArgs e)
        {
            string dashboardurl = Page.ResolveClientUrl("~/Admin/Default.aspx");
            Response.Redirect(dashboardurl);
        }
        protected void lbtnpname_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton link = sender as LinkButton;
                DataTable dtobj = new DataTable();
                int proID = 0;
                string templatename = string.Empty;
                dtobj = busobj.GetProfileDetailsByProfileID(int.Parse(link.CommandArgument));
                if (dtobj.Rows.Count == 1)
                {
                    templatename = dtobj.Rows[0]["Templatename"].ToString();
                }
                if (templatename == "")
                {
                    templatename = "TEMPLATE1";
                }
                proID = int.Parse(link.CommandArgument);
                string urlinfo = Page.ResolveClientUrl("~/Profiles/default.aspx?PID=" + proID);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Open", "window.open('" + urlinfo + "')", true);
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "lbtnpname_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void grdExportexcel_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbltype = e.Row.FindControl("lbltype") as Label;
                    Userid = grdExportexcel.DataKeys[e.Row.RowIndex].Value.ToString();
                    DataTable dtprofiledetails = new DataTable();
                    DataTable dtuser = new DataTable();
                    dtuser = busobj.GetUserDetailsByUserID(int.Parse(Userid));
                    int roleid = Convert.ToInt32(dtuser.Rows[0]["Role_ID"].ToString());
                    if (dtuser.Rows.Count > 0)
                    {
                        bool isfree = false;
                        if (dtuser.Rows[0]["IsFree"] != null)
                        {
                            if (dtuser.Rows[0]["IsFree"].ToString() != "")
                            {
                                isfree = Convert.ToBoolean(dtuser.Rows[0]["IsFree"].ToString());
                            }
                        }
                        if (isfree == false)
                        {
                            if (roleid == 2)
                            {
                                lbltype.Text = "Paid Member";
                            }
                            if (roleid == 1)
                            {
                                lbltype.Text = "Free Listing";
                            }
                        }
                        else
                        {
                            lbltype.Text = "Free Listing";
                        }
                    }
                    dtprofiledetails = busobj.GetBusinessDeatilsByUserID(int.Parse(Userid));
                    if (dtprofiledetails.Rows.Count == 1)
                    {
                        Label lblprofilename = e.Row.FindControl("lblcompanyname") as Label;
                        lblprofilename.Text = dtprofiledetails.Rows[0]["Profile_Name"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "grdExportexcel_RowDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btn_ExporttoExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtexportexcel = new DataTable();
                dtexportexcel = (DataTable)Session["userstableTest"];
                if (dtexportexcel.Rows.Count > 0)
                {
                    string attachment = "attachment; filename=Usersdata.xls";
                    grdExportexcel.RowStyle.Wrap = false;
                    grdExportexcel.AlternatingRowStyle.Wrap = false;
                    grdExportexcel.DataSource = dtexportexcel;
                    grdExportexcel.DataBind();
                    grdExportexcel.HeaderRow.Font.Bold = true;
                    grdExportexcel.HeaderRow.ForeColor = Color.White;
                    grdExportexcel.HeaderRow.BackColor = Color.FromName("#8BE649");

                    //********************* Added for differentiating Real or Demo Accounts *********************//
                    for (int i = 0; i < grdExportexcel.Rows.Count; i++)
                    {
                        GridViewRow row = grdExportexcel.Rows[i];
                        if (dtexportexcel.Rows[i]["IsArchived"].ToString() != "" && Convert.ToBoolean(dtexportexcel.Rows[i]["IsArchived"].ToString()) == false)
                            row.BackColor = System.Drawing.Color.FromName("#AFC7C7");
                    }
                    //*******************************************************************************************//

                    Response.Clear();
                    Response.AddHeader("content-disposition", attachment);
                    Response.ContentType = "application/vnd.ms-excel";
                    StringWriter stw = new StringWriter();
                    HtmlTextWriter htextw = new HtmlTextWriter(stw);
                    grdExportexcel.RenderControl(htextw);
                    Response.Write(stw.ToString());
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "TestUserManagement.aspx.cs", "btn_ExporttoExcel_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            BindSearchData();
        }
        protected void deleteButton_Click(object sender, EventArgs e)
        {
            lblerr.Text = "<Font face=arial color=green size=2>Selected user has been deleted successfully.</font>";
        }
    }
}