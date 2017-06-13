using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using USPDHUBBLL;

namespace USPDHUB.Admin
{
    public partial class ManagePromocodes : System.Web.UI.Page
    {
        int AdminUserID = 0;
        USPDHUBBLL.AdminBLL objAdminBLL = new USPDHUBBLL.AdminBLL();
        AgencyBLL agencyobj = new AgencyBLL();
        DataTable dtPromocodes = new DataTable("promocodes");

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";
                if (Session["adminuserid"] != null)
                {
                    AdminUserID = Convert.ToInt32(Session["adminuserid"]);
                }
                else
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }
               
                if (!IsPostBack)
                {
                    hdnarchive.Value = "NoArchive";
                    
                    FillData();
                    if (Session["PCSMsg"] != null)
                    {
                        lblmsg.Text = Convert.ToString(Session["PCSMsg"]);
                        Session["PCSMsg"] = "";
                    }


                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManagePromocodes.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void FillData()
        {
            try
            {
                
                dtPromocodes = objAdminBLL.GetAllPromocodes(AdminUserID, hdnarchive.Value);
               
                grdPromocodes.DataSource = dtPromocodes;
                grdPromocodes.DataBind();
                //binding verticals
                DataTable dtVerticals = agencyobj.GetActiveVerticals();
                ddlVerticals.DataSource = dtVerticals;
                ddlVerticals.DataTextField = "Vertical_Name";
                ddlVerticals.DataValueField = "Vertical_Value";
                ddlVerticals.DataBind();
                ddlVerticals.Items.Insert(0, new ListItem("All", "All"));

                

                if (dtPromocodes.Rows.Count > 0)
                {
                    btnExport.Visible = true;
                }
                else
                {
                    btnExport.Visible = false;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManagePromocodes.aspx.cs", "FillData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void btnCreatePromocode_Click(object sender, EventArgs e)
        {
            string urlinfo = Page.ResolveClientUrl("~/Admin/GeneratePromocode.aspx");
            Response.Redirect(urlinfo);
        }

        protected void grdPromocodes_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblExDate = (Label)e.Row.FindControl("lblPromoCode_ExpiryDate");
                    lblExDate.Text = Convert.ToDateTime(lblExDate.Text).ToShortDateString();

                    Label lblCreatedDate = (Label)e.Row.FindControl("lblCreatedDate");
                    lblCreatedDate.Text = Convert.ToDateTime(lblCreatedDate.Text).ToShortDateString();
                    Label lblSetupFee = (Label)e.Row.FindControl("lblSetupPrice");
                    if (lblSetupFee.Text != "")
                    {
                        Label lblSetupAmount = (Label)e.Row.FindControl("lblSetupAmount");
                        if (lblSetupAmount.Text != "")
                        {
                            Label lblSetupDiscount = (Label)e.Row.FindControl("lblSetupDiscount");
                            lblSetupDiscount.Text = (Convert.ToDecimal(lblSetupFee.Text) - Convert.ToDecimal(lblSetupAmount.Text)).ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManagePromocodes.aspx.cs", "grdPromocodes_OnRowDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void grdPromocodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPromocodes.PageIndex = e.NewPageIndex;
            FillData();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string ExcelFileName = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond;

                string fileName = "attachment; filename=" + ExcelFileName + ".xls";
                grdPromocodes.AllowPaging = false;
                FillData();
                grdPromocodes.HeaderRow.Font.Bold = true;
                grdPromocodes.HeaderRow.ForeColor = System.Drawing.Color.White;
                grdPromocodes.HeaderRow.BackColor = System.Drawing.Color.FromName("#657383");
                Response.Clear();
                Response.AddHeader("content-disposition", fileName);
                Response.ContentType = "application/vnd.ms-excel";

                StringWriter stw = new StringWriter();
                HtmlTextWriter htextw = new HtmlTextWriter(stw);

                grdPromocodes.RenderControl(htextw);
                Response.Write(stw.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManagePromocodes.aspx.cs", "btnExport_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //return;
        }
        protected void lnkCurrent_Click(object sender, EventArgs e)
        {
            lnkGetArchive.Text = "<img src='../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>";
            lnkCurrent.Text = "<img src='../Images/Dashboard/current_h.gif' title='Current' border='0'/>";
            hdnarchive.Value = "NoArchive";
            FillData();
        }
        protected void lnkGetArchive_Click(object sender, EventArgs e)
        {
            lnkGetArchive.Text = "<img src='../Images/Dashboard/archive.gif' title='Archive' border='0'/>";
            lnkCurrent.Text = "<img src='../Images/Dashboard/current.gif' title='Current' border='0'/>";
            hdnarchive.Value = "Archive";
            FillData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dtPromocodes = objAdminBLL.GetPromocodesBySearch(ddlVerticals.SelectedValue, txtSerach.Text.Trim(), hdnarchive.Value,txtFromDate.Text.Trim(), txtToDate.Text.Trim());
                grdPromocodes.DataSource = dtPromocodes;
                grdPromocodes.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                objInBuiltData.ErrorHandling("ERROR", "MAnagePromocodes.aspx.cs", "btnSearch_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }


        }
        protected void btnClear_Click(object sender, EventArgs e) {
            FillData();
            txtToDate.Text = "";
            txtFromDate.Text = "";
            txtSerach.Text = "";
        }

     

    }
}