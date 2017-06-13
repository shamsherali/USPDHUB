using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using USPDHUBBLL;
using System.IO;
using System.Text;
using System.Drawing;

namespace USPDHUB.Admin
{
    public partial class ManageAccessCodes : System.Web.UI.Page
    {
        public int UserID = 0;
        public string Userid = string.Empty;
        public Boolean TypeOfBusiness = false;
        BusinessBLL busobj = new BusinessBLL();
        AdminBLL adminobj = new AdminBLL();
        AgencyBLL agencyobj = new AgencyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridData();
            }
        }
        protected void BindGridData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = adminobj.GetBusinessAccessCodes();
                PincodeGrid.DataSource = dt;
                PincodeGrid.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageAccessCodes.aspx.cs", "BindGridData", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void PincodeGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int ProfileID = Convert.ToInt32(PincodeGrid.DataKeys[e.RowIndex].Values["Profile_ID"].ToString());
                adminobj.DeleteAccessCodes(ProfileID, "Delete", "");
                BindGridData();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageAccessCodes.aspx.cs", "PincodeGrid_RowDeleting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void PincodeGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            PincodeGrid.EditIndex = e.NewEditIndex;
            BindGridData();
        }
        protected void PincodeGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            PincodeGrid.EditIndex = -1;
            BindGridData();
        }

        protected void EditUsersRecord(object sender, EventArgs e)
        {
            try
            {
                Session["ID"] = "";
                lblSuccMsg.Text = "";
                txtEditPinCode.Text = "";
                LinkButton EditButton = sender as LinkButton;
                GridViewRow gvrow = (GridViewRow)EditButton.NamingContainer;
                string requestor = "";
                int ProfileId = 0;
                if (gvrow != null)
                {
                    var lblgridAccessCode = gvrow.FindControl("lblgridAccessCode") as Label;
                    var lblProfile_ID = gvrow.FindControl("lblgridProfile") as Label;
                    requestor = lblgridAccessCode.Text;
                    ProfileId = Convert.ToInt32(lblProfile_ID.Text.ToString());
                    Session["ID"] = ProfileId;
                }
                txtEditPinCode.Text = requestor;
                this.ModalPopupExtender2.Show();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageAccessCodes.aspx.cs", "EditUsersRecord", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void DeleteUsersRecord(object sender, EventArgs e)
        {
            try
            {
                lblerr.Text = "";
                int ConfirmDelete = 0;
                foreach (GridViewRow row in PincodeGrid.Rows)
                {
                    if (((CheckBox)row.FindControl("CheckBox1")).Checked)
                    {
                        int ProfileID = int.Parse(((Label)(PincodeGrid.Rows[row.RowIndex].FindControl("lblgridProfile"))).Text);
                        int result = adminobj.DeleteAccessCodes(ProfileID, "Delete", "");
                        ConfirmDelete = ConfirmDelete + result;
                    }
                }
                if (ConfirmDelete != 0)
                {
                    lblerr.Text = "<Font face=arial color=green size=2>Selected pin code(s) have been deleted successfully.</font>";
                }
                BindGridData();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageAccessCodes.aspx.cs", "DeleteUsersRecord", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btn_goDashboard(object sender, EventArgs e)
        {
            string dashboardurl = Page.ResolveClientUrl("~/Admin/Default.aspx");
            Response.Redirect(dashboardurl);
        }
        protected void deleteButton_Click(object sender, EventArgs e)
        {
            lblerr.Text = "";
            lblerr.Text = "<Font face=arial color=green size=2>Selected pin code has been deleted successfully.</font>";
        }
        protected void btnUpdate_popupClick(object sender, EventArgs e)
        {
            try
            {
                int profileID = (int)Session["ID"];
                int result = 0;
                lblSuccMsg.Text = "";
                if (!string.IsNullOrEmpty(txtEditPinCode.Text))
                {
                    result = adminobj.DeleteAccessCodes(profileID, "Edit", txtEditPinCode.Text.ToString());
                    BindGridData();
                    if (result == 1)
                    {
                        lblSuccMsg.Text = "<Font face=arial color=green size=2>Selected pin code has been updated successfully.</font>";
                        ModalPopupExtender2.Show();
                    }
                }
                else
                {
                    lblSuccMsg.Text = "<Font face=arial color=green size=2>Please enter a valid pincode.</font>";
                    ModalPopupExtender2.Show();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageAccessCodes.aspx.cs", "btnUpdate_popupClick", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void ImcloseClick(object sender, EventArgs e)
        {

        }

        protected void PincodeGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PincodeGrid.PageIndex = e.NewPageIndex;
            PincodeGrid.DataBind();
            BindGridData();
        }

        //********************************************************************************//
        //********************* Export all Gridview Records to Excel *********************//
        //********************************************************************************//
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string ExcelFileName = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond;

                string fileName = "attachment; filename=" + ExcelFileName + ".xls";
                PincodeGrid.AllowPaging = false;
                BindGridData();
                PincodeGrid.HeaderRow.Font.Bold = true;
                PincodeGrid.HeaderRow.ForeColor = System.Drawing.Color.White;
                PincodeGrid.HeaderRow.BackColor = System.Drawing.Color.FromName("#8BE649");
                Response.Clear();
                Response.AddHeader("content-disposition", fileName);
                Response.ContentType = "application/vnd.ms-excel";

                StringWriter stw = new StringWriter();
                HtmlTextWriter htextw = new HtmlTextWriter(stw);

                PincodeGrid.RenderControl(htextw);
                Response.Write(stw.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageAccessCodes.aspx.cs", "btnExport_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        //********************************************************************************//
        //************************ Print all Gridview Records ****************************//
        //********************************************************************************//
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PincodeGrid.AllowPaging = false;
                PincodeGrid.DataBind();
                BindGridData();
                PincodeGrid.HeaderRow.Font.Bold = true;
                PincodeGrid.HeaderRow.ForeColor = System.Drawing.Color.White;
                PincodeGrid.HeaderRow.BackColor = System.Drawing.Color.FromName("#8BE649");
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                PincodeGrid.RenderControl(hw);
                string gridHTML = sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload = new function(){");
                sb.Append("var printWin = window.open('', '', 'left=0");
                sb.Append(",top=0,width=1000,height=600,status=0');");
                sb.Append("printWin.document.write(\"");
                sb.Append(gridHTML);
                sb.Append("\");");
                sb.Append("printWin.document.close();");
                sb.Append("printWin.focus();");
                sb.Append("printWin.print();");
                sb.Append("printWin.close();};");
                sb.Append("</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
                PincodeGrid.AllowPaging = true;
                PincodeGrid.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ManageAccessCodes.aspx.cs", "btnPrint_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}