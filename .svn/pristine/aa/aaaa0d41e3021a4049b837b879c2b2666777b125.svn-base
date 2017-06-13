using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.Data;
using System.IO;

namespace USPDHUB.Admin
{
    public partial class SubappsManagement : System.Web.UI.Page
    {
        public int UserID = 0;
        public string Userid = string.Empty;
        public Boolean TypeOfBusiness = false;

        AdminBLL adminobj = new AdminBLL();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridData();
            }
        }

        private void BindGridData()
        {
            try
            {
                DataTable dtActiveSubApps = adminobj.GetAllActiveSubApps();

                SubappsGrid.DataSource = null;
                SubappsGrid.DataSource = dtActiveSubApps;
                SubappsGrid.DataBind();

                dummyGridview.DataSource = null;
                dummyGridview.DataSource = dtActiveSubApps;
                dummyGridview.DataBind();

                if (dtActiveSubApps.Rows.Count > 0)
                {
                    btnExportDown.Visible = true;
                    btnExportUp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SubappsManagement.aspx.cs", "BindGridData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void SubappsGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SubappsGrid.PageIndex = e.NewPageIndex;
            SubappsGrid.DataBind();


            BindGridData();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            ApplyGrouping();
            base.Render(writer);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void BtnExport_OnClick(object sender, EventArgs e)
        {
            try
            {
                string ExcelFileName = "subapps";// DateTime.Now.ToString("yyyymmddhhss") + "" + DateTime.Now.Millisecond;

                string fileName = "attachment; filename=" + ExcelFileName + ".xls";
                SubappsGrid.AllowPaging = false;

                SubappsGrid.HeaderRow.Font.Bold = true;
                SubappsGrid.HeaderRow.ForeColor = System.Drawing.Color.White;
                SubappsGrid.HeaderRow.BackColor = System.Drawing.Color.FromName("#8BE649");
                Response.Clear();
                Response.AddHeader("content-disposition", fileName);
                Response.ContentType = "application/vnd.ms-excel";

                StringWriter stw = new StringWriter();
                HtmlTextWriter htextw = new HtmlTextWriter(stw);

                ApplyGrouping();
                dummyGridview.RenderControl(htextw);
                Response.Write(stw.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SubappsManagement.aspx.cs", "BtnExport_OnClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        //

        private void ApplyGrouping()
        {
            try
            {
                string lastSubCategory = String.Empty;
                Table gridTable = (Table)SubappsGrid.Controls[0];
                foreach (GridViewRow gvr in SubappsGrid.Rows)
                {
                    HiddenField hfSubCategory = gvr.FindControl("hdnParentProfileID") as
                                                HiddenField;

                    Label lblParentProfileName = gvr.FindControl("lblParent_ProfileName") as Label;
                    Label lblParent_UserID = gvr.FindControl("lblParent_UserID") as Label;

                    string currSubCategory = hfSubCategory.Value;
                    if (lastSubCategory.CompareTo(currSubCategory) != 0)
                    {
                        int rowIndex = gridTable.Rows.GetRowIndex(gvr);
                        // Add new group header row
                        GridViewRow headerRow = new GridViewRow(rowIndex, rowIndex,
                            DataControlRowType.DataRow, DataControlRowState.Normal);
                        TableCell headerCell = new TableCell();
                        headerCell.ColumnSpan = SubappsGrid.Columns.Count;
                        DataTable dtProfileDetails = adminobj.GetProfileDetailsByProfileID(Convert.ToInt32(currSubCategory));

                        string parent_UserID = "";
                        string parent_ProfileName = "";
                        if (dtProfileDetails.Rows.Count > 0)
                        {
                            parent_ProfileName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_name"]);
                            parent_UserID = Convert.ToString(dtProfileDetails.Rows[0]["User_ID"]);
                        }

                        string htmlStr = @"<table  cellspacing='0' cellpadding='0' border='0' style='background-color: lightgray;' width='100%'>
                                                            <tr>
                                                                <td style='width: 174px; border:0px;'>
                                                                    " + currSubCategory + @"
                                                                </td>
                                                                <td style='width: 180px; border:0px;'>
                                                                   " + parent_UserID + @"
                                                                </td>
                                                                <td style='width: 180px; border:0px;'>
                                                                   " + parent_ProfileName + @"
                                                                </td><td>&nbsp;</td>
                                                            </tr>
                                                        </table>";

                        headerCell.Text = string.Format(htmlStr);
                        headerCell.Font.Bold = true;

                        headerCell.CssClass = "GroupHeaderRowStyle";
                        // Add header Cell to header Row, and header Row to gridTable
                        headerRow.Cells.Add(headerCell);
                        gridTable.Controls.AddAt(rowIndex, headerRow);
                        // Update lastValue
                        lastSubCategory = currSubCategory;
                    }
                }

                // Excel Sheet Grid
                lastSubCategory = String.Empty;
                gridTable = (Table)dummyGridview.Controls[0];
                foreach (GridViewRow gvr in dummyGridview.Rows)
                {
                    HiddenField hfSubCategory = gvr.FindControl("hdnParentProfileID") as
                                                HiddenField;

                    Label lblParentProfileName = gvr.FindControl("lblParent_ProfileName") as Label;
                    Label lblParent_UserID = gvr.FindControl("lblParent_UserID") as Label;

                    string currSubCategory = hfSubCategory.Value;
                    if (lastSubCategory.CompareTo(currSubCategory) != 0)
                    {
                        int rowIndex = gridTable.Rows.GetRowIndex(gvr);
                        // Add new group header row
                        GridViewRow headerRow = new GridViewRow(rowIndex, rowIndex,
                            DataControlRowType.DataRow, DataControlRowState.Normal);
                        TableCell headerCell = new TableCell();
                        headerCell.ColumnSpan = dummyGridview.Columns.Count;
                        DataTable dtProfileDetails = adminobj.GetProfileDetailsByProfileID(Convert.ToInt32(currSubCategory));

                        string parent_UserID = "";
                        string parent_ProfileName = "";
                        if (dtProfileDetails.Rows.Count > 0)
                        {
                            parent_ProfileName = Convert.ToString(dtProfileDetails.Rows[0]["Profile_name"]);
                            parent_UserID = Convert.ToString(dtProfileDetails.Rows[0]["User_ID"]);
                        }

                        string htmlStr = @"<table  cellspacing='0' cellpadding='0' border='0' style='background-color: #808080;' width='100%'>
                                                            <tr>
                                                                <td style='width: 174px; border:0px;'>
                                                                    " + currSubCategory + @"
                                                                </td>
                                                                <td style='width: 180px; border:0px;'>
                                                                   " + parent_UserID + @"
                                                                </td>
                                                                <td style='width: 180px; border:0px;'>
                                                                   " + parent_ProfileName + @"
                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                        </table>";

                        headerCell.Text = string.Format(htmlStr);
                        headerCell.Font.Bold = true;

                        headerCell.CssClass = "GroupHeaderRowStyle";
                        // Add header Cell to header Row, and header Row to gridTable
                        headerRow.Cells.Add(headerCell);
                        gridTable.Controls.AddAt(rowIndex, headerRow);
                        // Update lastValue
                        lastSubCategory = currSubCategory;
                    }
                } //
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "SubappsManagement.aspx.cs", "ApplyGrouping", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

    }
}