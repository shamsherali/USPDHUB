using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB.Admin
{
    public partial class ManageBrandedAppProcessStatus : System.Web.UI.Page
    {
        // hdnTabType.value 1: Customer Service like; New, Data Collection
        // hdnTabType.value 2: Engineering  like; Development, Device Testing, Submit to Store, Completed
        int UserID = 0;
        USPDHUBBLL.AdminBLL objAdminBLL = new USPDHUBBLL.AdminBLL();
        DataTable dtBrandedAppOrderStatus = new DataTable("BrandedAppOrderStatus");
        AgencyBLL agencyobj = new AgencyBLL();
        USPDHUBBLL.BusinessBLL objBusinessBLL = new USPDHUBBLL.BusinessBLL();

        public int SortDir = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                lblmsg.Text = "";
                if (Session["adminuserid"] != null)
                {
                    UserID = Convert.ToInt32(Session["adminuserid"]);
                }
                else
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }

                if (!IsPostBack)
                {
                    Session["BrandedApp_OrderId"] = null;
                    if (Request.QueryString["TabType"] == null)
                    {
                        hdnTabType.Value = "1";
                    }
                    else
                    {
                        hdnTabType.Value = Request.QueryString["TabType"].ToString();
                    }
                    LoadTabs();

                    FillData();
                    if (Session["Msg"] != null)
                    {
                        lblmsg.Text = Convert.ToString(Session["Msg"]);
                        Session["Msg"] = "";
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageBrandedAppProcessStatus.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void LoadTabs()
        {
            try
            {
                if (hdnTabType.Value == "1")
                {
                    lnkGetArchive.Text = "<img src='../Images/Dashboard/engineering_h.gif' title='Engineering' border='0'/>";
                    lnkCurrent.Text = "<img src='../Images/Dashboard/customerservice.gif' title='Customer Service' border='0'/>";
                    lnkCompleted.Text = "<img src='../Images/Dashboard/completed_h.gif' title='Completed' border='0'/>";
                }
                else if (hdnTabType.Value == "2")
                {
                    lnkGetArchive.Text = "<img src='../Images/Dashboard/engineering.gif' title='Engineering' border='0'/>";
                    lnkCurrent.Text = "<img src='../Images/Dashboard/customerservice_h.gif' title='Customer Service' border='0'/>";
                    lnkCompleted.Text = "<img src='../Images/Dashboard/completed_h.gif' title='Completed' border='0'/>";

                }
                else if (hdnTabType.Value == "3")
                {
                    lnkGetArchive.Text = "<img src='../Images/Dashboard/engineering_h.gif' title='Engineering' border='0'/>";
                    lnkCurrent.Text = "<img src='../Images/Dashboard/customerservice_h.gif' title='Customer Service' border='0'/>";
                    lnkCompleted.Text = "<img src='../Images/Dashboard/completed.gif' title='Completed' border='0'/>";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageBrandedAppProcessStatus.aspx.cs", "LoadTabs", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void FillData()
        {
            try
            {
                DataTable dtVerticals = agencyobj.GetActiveVerticals();
                ddlVerticals.DataSource = dtVerticals;
                ddlVerticals.DataTextField = "Vertical_Name";
                ddlVerticals.DataValueField = "Vertical_Value";
                ddlVerticals.DataBind();
                ddlVerticals.Items.Insert(0, new ListItem("All", "All"));

                dtBrandedAppOrderStatus = objBusinessBLL.GetManageBrandedAppOrderStatus(Convert.ToInt32(hdnTabType.Value),"","");
                grdProcessStatus.DataSource = dtBrandedAppOrderStatus;
                grdProcessStatus.DataBind();
                Session["dtBrandedAppOrderStatus"] = dtBrandedAppOrderStatus;
                hdnsortcount.Value = "0";
                if (hdnTabType.Value != "1")
                    grdProcessStatus.Columns[8].Visible = false;
                else
                    grdProcessStatus.Columns[8].Visible = true;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageBrandedAppProcessStatus.aspx.cs", "FillData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void grdProcessStatus_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblStatusID = e.Row.FindControl("lblStatusID") as Label;
                    LinkButton lnkDelete = e.Row.FindControl("lnkDeleteApp") as LinkButton;

                    if (hdnTabType.Value == "1")
                    {
                        lnkDelete.Visible = false;
                        if (Convert.ToInt32(lblStatusID.Text.Trim()) == Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.New))
                            lnkDelete.Visible = true;
                    }
                    if (hdnTabType.Value == "2" || hdnTabType.Value == "3")
                    {
                        LinkButton lnkManageRequest = e.Row.FindControl("lnkManageRequest") as LinkButton;
                        Label lblRequestCount = e.Row.FindControl("lblRequestCount") as Label;
                        Label lblBrandAppOrderID = e.Row.FindControl("lblBrandAppOrderID") as Label;
                        lnkManageRequest.Visible = true;
                        lnkManageRequest.Text = "<span style='color:red;text-decoration:underline;'>Manage Request(" + lblRequestCount.Text + ")</span>";
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageBrandedAppProcessStatus.aspx.cs", "grdProcessStatus_OnRowDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void grdProcessStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProcessStatus.PageIndex = e.NewPageIndex;
            FillData();
        }

        protected void grdProcessStatus_OnSorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortDir = Convert.ToInt32(hdnsortcount.Value);
                string SortExp = e.SortExpression.ToString();
                dtBrandedAppOrderStatus = (DataTable)Session["dtBrandedAppOrderStatus"];
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
                DataView Dv = new DataView(dtBrandedAppOrderStatus);
                if (SortDir == 0)
                {
                    if (SortExp == "ProfileID")
                    {
                        Dv.Sort = "ProfileID desc";
                    }
                    else if (SortExp == "UserID")
                    {
                        Dv.Sort = "UserID desc";
                    }
                    else if (SortExp == "Vertical_Name")
                    {
                        Dv.Sort = "Vertical_Name desc";
                    }
                    else if (SortExp == "Status_Name")
                    {
                        Dv.Sort = "StatusID desc";
                    }
                    hdnsortcount.Value = "1";
                }
                else
                {
                    if (SortExp == "ProfileID")
                    {
                        Dv.Sort = "ProfileID asc";
                    }
                    else if (SortExp == "UserID")
                    {
                        Dv.Sort = "UserID asc";
                    }
                    else if (SortExp == "Vertical_Name")
                    {
                        Dv.Sort = "Vertical_Name asc";
                    }
                    else if (SortExp == "Status_Name")
                    {
                        Dv.Sort = "StatusID asc";
                    }
                    hdnsortcount.Value = "0";
                }
                Session["dtBrandedAppOrderStatus"] = Dv.ToTable();
                grdProcessStatus.DataSource = Dv;
                grdProcessStatus.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageBrandedAppProcessStatus.aspx.cs", "grdProcessStatus_OnSorting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkEdit = (LinkButton)sender as LinkButton;
                int EditID = Convert.ToInt32(lnkEdit.CommandArgument);
                if (EditID > 0)
                {
                    Session["TabType"] = hdnTabType.Value;
                    string urlRedirect = "";
                    urlRedirect = Page.ResolveClientUrl("~/Admin/EditAppOrderStatus.aspx?OSID=" + EncryptDecrypt.DESEncrypt(EditID.ToString()) + "&TabType=" + hdnTabType.Value);
                    Response.Redirect(urlRedirect);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageBrandedAppProcessStatus.aspx.cs", "btnEdit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkDeleteApp_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkDeleteApp = (LinkButton)sender as LinkButton;
                int brandedOrderID = Convert.ToInt32(lnkDeleteApp.CommandArgument.ToString());
                objBusinessBLL.DeleteBrandedAppById(brandedOrderID);
                lblmsg.Text = "<span style='color:green;'>Requested Branded App has been deleted successfully.</span>";
                FillData();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageBrandedAppProcessStatus.aspx.cs", "lnkDeleteApp_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btnChangeStatus = (LinkButton)sender as LinkButton;
                string[] commandArgs = btnChangeStatus.CommandArgument.ToString().Split(new char[] { ',' });
                int BrandedApp_OrderID = Convert.ToInt32(commandArgs[0]);
                int StatusID = Convert.ToInt32(commandArgs[1]);
                if (BrandedApp_OrderID > 0)
                {
                    if (StatusID == Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.Developement))
                    {
                        objBusinessBLL.ChangeBrandedAppOrderStatus(BrandedApp_OrderID, Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.DeviceTesting));
                    }
                    else if (StatusID == Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.DeviceTesting))
                    {
                        objBusinessBLL.ChangeBrandedAppOrderStatus(BrandedApp_OrderID, Convert.ToInt32(USPDHUBDAL.BusinessDAL.BranedAppProcessStatus.SubmitStore));
                    }
                    lblmsg.Text = "<span style='color:green;'>App order status has been updated successfully.</span>";
                    FillData();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageBrandedAppProcessStatus.aspx.cs", "btnChangeStatus_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void lnkCustomerService_Click(object sender, EventArgs e)
        {
            hdnTabType.Value = "1";
            LoadTabs();
            FillData();
        }

        protected void lnkEngineering_Click(object sender, EventArgs e)
        {
            hdnTabType.Value = "2";
            LoadTabs();
            FillData();
        }

        protected void lnkCompleted_Click(object sender, EventArgs e)
        {
            hdnTabType.Value = "3";
            LoadTabs();
            FillData();
        }
        protected void lnkManageRequest_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnk = sender as LinkButton;
                Session["BrandedApp_OrderId"] = lnk.CommandArgument;
                DataTable dtAddRequests = objAdminBLL.GetBrandedAppAdditionalRequest(Convert.ToInt32(lnk.CommandArgument));
                if (dtAddRequests.Rows.Count > 0)
                {
                    MPERequestDetails.Show();
                }
                else
                    Response.Redirect("AdditionalBrandedRequests.aspx");
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageBrandedAppProcessStatus.aspx.cs", "lnkManageRequest_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            dtBrandedAppOrderStatus = objBusinessBLL.GetManageBrandedAppOrderStatus(Convert.ToInt32(hdnTabType.Value), txtSearch.Text.Trim(), ddlVerticals.SelectedValue);
            grdProcessStatus.DataSource = dtBrandedAppOrderStatus;
            grdProcessStatus.DataBind();
            Session["dtBrandedAppOrderStatus"] = dtBrandedAppOrderStatus;
            hdnsortcount.Value = "0";
            if (hdnTabType.Value != "1")
                grdProcessStatus.Columns[8].Visible = false;
            else
                grdProcessStatus.Columns[8].Visible = true;
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            FillData();
            txtSearch.Text = "";
        }
    }
}