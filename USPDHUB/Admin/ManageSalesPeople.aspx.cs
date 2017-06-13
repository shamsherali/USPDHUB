using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.UI;
using USPDHUBBLL;

namespace USPDHUB.Admin
{
    public partial class ManageSalesPeople : System.Web.UI.Page
    {
        DataTable dtSalesPerson = new DataTable();
        AdminBLL objAdmin = new AdminBLL();
        AgencyBLL objAgency = new AgencyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblerror.Text = "";
                lblSuccess.Text = "";
                if (Session["adminuserid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
                if (!IsPostBack)
                {
                    LoadSalesPerson();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageSalesPeople.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void LoadSalesPerson()
        {
            try
            {
                dtSalesPerson = objAdmin.GetSalesPerson();
                Session["DtSalesPerson"] = dtSalesPerson;
                SalesPersonGrid.DataSource = dtSalesPerson;
                SalesPersonGrid.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageSalesPeople.aspx.cs", "LoadSalesPerson", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void SalesPersonGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtSalesPerson = (DataTable)Session["DtSalesPerson"];
                SalesPersonGrid.PageIndex = e.NewPageIndex;
                SalesPersonGrid.DataSource = dtSalesPerson;
                SalesPersonGrid.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageSalesPeople.aspx.cs", "SalesPersonGrid_PageIndexChanging", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void SalesPersonGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.CompareTo("Delete") == 0)//Update Process
                {
                    int salePid = Convert.ToInt32(e.CommandArgument);
                    //Delete Process.
                    objAdmin.DeleteSalePerson(salePid);
                    lblSuccess.Text = "<font size='3' color='green'>Sales person has been deleted successfully.</font>";
                    LoadSalesPerson();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageSalesPeople.aspx.cs", "SalesPersonGrid_RowCommand", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void SalesPersonGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void BtnSumbitClick(object sender, EventArgs e)
        {
            try
            {
                if (txtEffectedDate.Text.Trim() != "")
                {
                    if ((DateTime.Compare(Convert.ToDateTime(txtEffectedDate.Text.Trim()), DateTime.Today) < 0) && hdnSPID.Value == "0")
                    {
                        lblerror.Text = "<font size='2' color='red'>Please select the effected date later or equal to current date.</font>";
                        mpeSalesPerson.Show();
                    }
                    else
                    {
                        string firstname = txtFirstName.Text.Trim();
                        string lastname = txtLastName.Text.Trim();
                        int iD = 0;
                        int? comsRate = null;
                        string name = firstname;
                        if (lastname != "")
                            name = name + " " + lastname;
                        string email = txtEmail.Text.Trim();
                        string phone = txtPhone.Text.Trim();
                        DateTime dteffecteddate = Convert.ToDateTime(txtEffectedDate.Text.Trim());
                        string comments = txtComments.Text.Trim();
                        int commissionid = Convert.ToInt32(ddlCommission.SelectedValue);
                        int? managerid = null;
                        if (Convert.ToInt32(ddlManager.SelectedValue) > 0)
                            managerid = Convert.ToInt32(ddlManager.SelectedValue);
                        if (hdnSPID.Value != "")
                            iD = Convert.ToInt32(hdnSPID.Value);
                        if (hdnComsRate.Value != "")
                            comsRate = Convert.ToInt32(hdnComsRate.Value);
                        int id = objAdmin.CreateSalesPerson(iD, name, firstname, lastname, email, phone, dteffecteddate, comments, commissionid, managerid, comsRate, hdnVerticals.Value);
                        if (id > 0)
                        {
                            if (iD == 0)
                                lblSuccess.Text = "<font size='2' color='green'>Sales person has been added successfully.</font>";
                            else
                                lblSuccess.Text = "<font size='2' color='green'>Sales person has been updated successfully.</font>";
                            LoadSalesPerson();
                            mpeSalesPerson.Hide();
                        }
                        else
                        {
                            lblerror.Text = "<font size='2' color='red'>A sales person has already been available with this email.</font>";
                            mpeSalesPerson.Show();
                        }
                    }
                }
                else
                    mpeSalesPerson.Show();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageSalesPeople.aspx.cs", "BtnSumbitClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtnAddNewClick(object sender, EventArgs e)
        {
            ClearValues();
            BindData(0, 0, 0);
            btnSumbit.Text = "Add Sales Person";
            txtFirstName.Focus();
            mpeSalesPerson.Show();
        }
        private void ClearValues()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtEffectedDate.Text = "";
            ddlCommission.SelectedIndex = 0;
            ddlManager.SelectedIndex = 0;
            txtComments.Text = "";
            hdnComsRate.Value = "";
            hdnSPID.Value = "0";
        }
        protected void ImgCloseClick(object sender, EventArgs e)
        {
            LoadSalesPerson();
        }
        protected void BtnEditClick(object sender, EventArgs e)
        {
            try
            {
                ClearValues();
                LinkButton lnkEdit = (LinkButton)sender;
                int salePid = Convert.ToInt32(lnkEdit.CommandArgument);
                DataTable dtSP = objAdmin.GetSalesPersonByID(salePid);
                if (dtSP.Rows.Count == 1)
                {
                    txtFirstName.Text = dtSP.Rows[0]["Sales_Firstname"].ToString();
                    txtLastName.Text = (!string.IsNullOrEmpty(dtSP.Rows[0]["Sales_Lastname"].ToString())) ? dtSP.Rows[0]["Sales_Lastname"].ToString() : "";
                    txtEmail.Text = dtSP.Rows[0]["Email"].ToString();
                    txtPhone.Text = (!string.IsNullOrEmpty(dtSP.Rows[0]["Contact_Phone"].ToString())) ? dtSP.Rows[0]["Contact_Phone"].ToString() : "";
                    txtEffectedDate.Text = Convert.ToDateTime(dtSP.Rows[0]["Effected_Date"]).ToShortDateString();
                    txtComments.Text = "";
                    int managerID = (!string.IsNullOrEmpty(dtSP.Rows[0]["Manager_ID"].ToString())) ? Convert.ToInt32(dtSP.Rows[0]["Manager_ID"].ToString()) : 0;
                    int commissionID = (!string.IsNullOrEmpty(dtSP.Rows[0]["CommissionID"].ToString())) ? Convert.ToInt32(dtSP.Rows[0]["CommissionID"].ToString()) : 0;
                    CheckVerticalAll.Checked = false;
                    BindData(salePid, managerID, commissionID);
                    hdnSPID.Value = salePid.ToString();
                    hdnComsRate.Value = (!string.IsNullOrEmpty(dtSP.Rows[0]["Percentage"].ToString())) ? dtSP.Rows[0]["Percentage"].ToString() : "";
                    hdnVerticals.Value = dtSP.Rows[0]["Verticals"].ToString();
                    ScriptManager.RegisterStartupScript(btnSumbit, this.GetType(), "CheckVerticals", "CheckVerticals();", true);
                    mpeSalesPerson.Show();
                    btnSumbit.Text = "Update Sales Person";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageSalesPeople.aspx.cs", "BtnEditClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void BindData(int salePersonID, int managerID, int commissionID)
        {
            try
            {
                DataTable dtCommissions = objAdmin.GetActiveCommissions();
                if (dtCommissions.Rows.Count > 0)
                {
                    if (commissionID > 0)
                    {
                        string select = "Commission_ID='" + commissionID + "'";
                        DataRow[] drr = dtCommissions.Select(select);
                        if (drr.Length == 0)
                            commissionID = 0;
                    }
                    ddlCommission.DataSource = dtCommissions;
                    ddlCommission.DataTextField = "LevelBind";
                    ddlCommission.DataValueField = "Commission_ID";
                    ddlCommission.DataBind();
                }
                ddlCommission.Items.Insert(0, new ListItem("-- Select --", "0"));
                dtSalesPerson = objAdmin.GetSalesPersonMaangers();
                if (dtSalesPerson.Rows.Count > 0)
                {
                    if (managerID > 0)
                    {
                        string select = "SalePerson_ID=" + managerID;
                        DataRow[] drr = dtSalesPerson.Select(select);
                        if (drr.Length == 0)
                            managerID = 0;
                    }
                    if (dtSalesPerson.Rows.Count > 0)
                    {
                        ddlManager.DataSource = dtSalesPerson;
                        ddlManager.DataTextField = "Sales_Name";
                        ddlManager.DataValueField = "SalePerson_ID";
                        ddlManager.DataBind();
                    }
                }
                ddlManager.Items.Insert(0, new ListItem("-- Select --", "0"));
                ddlManager.SelectedValue = managerID.ToString();
                if (commissionID > 0)
                    ddlCommission.SelectedValue = commissionID.ToString();
                DataTable dtVerticals = objAgency.GetActiveVerticals();
                CheckVerticals.DataSource = dtVerticals;
                CheckVerticals.DataTextField = "Vertical_Name";
                CheckVerticals.DataValueField = "Vertical_ID";
                CheckVerticals.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageSalesPeople.aspx.cs", "BindData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void CheckVerticals_DataBound(object sender, EventArgs e)
        {
            CheckBoxList chkList = (CheckBoxList)(sender);
            foreach (ListItem item in chkList.Items)
            {
                item.Attributes.Add("ValueField", item.Value);
            }
        }
        protected string GetCommission(object percentage, object cPercentage)
        {
            if (!string.IsNullOrEmpty(percentage.ToString()))
                return percentage.ToString();
            else
                return cPercentage.ToString();

        }
        protected string GetManager(object managerID)
        {
            string manager = "";
            try
            {
                if (!string.IsNullOrEmpty(managerID.ToString()))
                {
                    if (dtSalesPerson.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(managerID) > 0)
                        {
                            string select = "SalePerson_ID=" + managerID;
                            DataRow[] drr = dtSalesPerson.Select(select);
                            for (int i = 0; i < drr.Length; i++)
                            {
                                manager = dtSalesPerson.Rows[i]["Sales_Name"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageSalesPeople.aspx.cs", "GetManager", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return manager;
        }
    }
}