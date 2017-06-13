using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;

namespace USPDHUB.Admin
{
    public partial class CommissionReport : System.Web.UI.Page
    {
        AdminBLL objAdmin = new AdminBLL();
        public decimal RevenueTotal = 0;
        public decimal CommissionAmountTotal = 0;
        public decimal BillableTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["adminuserid"] == null)
                {
                    string urlinfo = Page.ResolveClientUrl("~/Admin/AdminLogin.aspx?sflag=1");
                    Response.Redirect(urlinfo);
                }

                if (!IsPostBack)
                {
                    #region Getting & Binding SalesPerson Details

                    DataTable dtSalesPersons = objAdmin.GetSalesPerson();

                    //Adding All option
                    DataRow dr = dtSalesPersons.NewRow();
                    dr["SalePerson_ID"] = "0";
                    dr["Sales_Name"] = "All";
                    dtSalesPersons.Rows.Add(dr);

                    ddlSalesPerson.DataSource = dtSalesPersons;
                    ddlSalesPerson.DataTextField = "Sales_Name";
                    ddlSalesPerson.DataValueField = "SalePerson_ID";
                    ddlSalesPerson.DataBind();

                    ddlSalesPerson.SelectedValue = "0";
                    DataTable dt = new DataTable();
                    dgCommission.DataSource = dt;
                    dgCommission.DataBind();
                    #endregion
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CommissionReport.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void BtnSearchClick(object sender, EventArgs e)
        {
            try
            {
                int salesPersonID = Convert.ToInt32(ddlSalesPerson.SelectedValue);
                DateTime startDate = Convert.ToDateTime(txtStartDate.Text);
                DateTime toDate = Convert.ToDateTime(txtEndDate.Text);

                lblmess.ForeColor = System.Drawing.Color.Green;

                if (startDate.Date > toDate)
                {
                    lblmess.Text = "The end date should be later or equal to start date.";
                    lblmess.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    DataTable dtCommissionReports = objAdmin.GetCommissionReports(salesPersonID, startDate, toDate);

                    dgCommission.DataSource = dtCommissionReports;
                    dgCommission.DataBind();


                    SearchCount.Value = dtCommissionReports.Rows.Count.ToString();

                    if (dtCommissionReports.Rows.Count > 0)
                    {
                        ExportRow.Visible = true;
                    }
                    else
                    {
                        ExportRow.Visible = false;
                    }
                    lblmess.Text = "";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CommissionReport.aspx.cs", "BtnSearchClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void DgCommissionRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblOrderTotal = (Label)e.Row.FindControl("lblOrderTotal");
                    decimal price = Decimal.Parse(lblOrderTotal.Text);
                    RevenueTotal += price;

                    Label lblCommissionAmt = (Label)e.Row.FindControl("lblCommission_Amt");
                    var price1 = Decimal.Parse(lblCommissionAmt.Text);
                    CommissionAmountTotal += price1;

                    Label lblBillableAmount = (Label)e.Row.FindControl("lblBillable_Amount");
                    var price2 = Decimal.Parse(lblBillableAmount.Text);
                    BillableTotal += price2;

                    Label lblMonth = (Label)e.Row.FindControl("lblMonth");
                    DateTime month = Convert.ToDateTime(lblMonth.Text);
                    lblMonth.Text = month.ToShortDateString();


                    Label lblPercentage = (Label)e.Row.FindControl("lblPercentage");
                    string percentage = lblPercentage.Text;
                    lblPercentage.Text = percentage + "%";

                }


                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblRevenueTotal = (Label)e.Row.FindControl("lblRevenueTotal");
                    lblRevenueTotal.Text = "$ " + RevenueTotal.ToString();

                    Label lblCommissionAmtTotal = (Label)e.Row.FindControl("lblCommissionAmtTotal");
                    lblCommissionAmtTotal.Text = "$ " + CommissionAmountTotal;

                    Label lblBillableTotal = (Label)e.Row.FindControl("lblBillableTotal");
                    lblBillableTotal.Text = "$ " + BillableTotal;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CommissionReport.aspx.cs", "DgCommissionRowDataBound", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void BtnPrintClick(object sender, EventArgs e)
        {

        }

        protected void BtnSubmitOnClick(object sender, EventArgs e)
        {
            try
            {
                //Save Export Details
                objAdmin.InsertSalesCommissionExportDetails(Convert.ToInt32(ddlSalesPerson.SelectedValue), Convert.ToDateTime(txtStartDate.Text),
                    Convert.ToDateTime(txtEndDate.Text), txtUserName.Text.Trim(), txtNotes.Text);

                string sdate = Convert.ToDateTime(txtStartDate.Text).Month.ToString() + Convert.ToDateTime(txtStartDate.Text).Day.ToString() + Convert.ToDateTime(txtStartDate.Text).Year.ToString();
                string todate = Convert.ToDateTime(txtEndDate.Text).Month.ToString() + Convert.ToDateTime(txtEndDate.Text).Day.ToString() + Convert.ToDateTime(txtEndDate.Text).Year.ToString();

                string fileName = "attachment; filename=" + ddlSalesPerson.SelectedItem.Text.Trim() + "_" + sdate + "_" + todate + ".xls";
                dgCommission.HeaderRow.Font.Bold = true;
                dgCommission.HeaderRow.ForeColor = System.Drawing.Color.White;
                dgCommission.HeaderRow.BackColor = System.Drawing.Color.FromName("#657383");
                Response.Clear();
                Response.AddHeader("content-disposition", fileName);
                Response.ContentType = "application/vnd.ms-excel";

                StringWriter stw = new StringWriter();
                HtmlTextWriter htextw = new HtmlTextWriter(stw);

                dgCommission.RenderControl(htextw);
                Response.Write(stw.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "CommissionReport.aspx.cs", "BtnSubmitOnClick", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //return;
        }
    }
}