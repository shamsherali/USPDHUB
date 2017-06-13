using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.Drawing;
using System.IO;

namespace USPDHUB.Admin
{
    public partial class ExpirationMembers : System.Web.UI.Page
    {
        AdminBLL objAdminBll = new AdminBLL();
        public int SortDir = 0;
        DataTable dtMembers;
        CommonBLL objCommonBll = new CommonBLL();
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
                    hdnsortdire.Value = "";
                    hdnsortcount.Value = "0";
                    btnExport.Visible = false;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ExpirationMembers.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BindData();
        }
        protected void BindData()
        {
            try
            {
                Session["ExpiredMembers"] = null;
                DateTime dtFrom = Convert.ToDateTime(txtStartDate.Text.Trim());
                DateTime dtTo = Convert.ToDateTime(txtEndDate.Text.Trim());
                dtMembers = objAdminBll.GetExipirationMembers(dtFrom, dtTo);
                btnExport.Visible = false;
                if (dtMembers.Rows.Count > 0)
                {
                    Session["ExpiredMembers"] = dtMembers;
                    btnExport.Visible = true;
                }
                GrdExpMembers.DataSource = dtMembers;
                GrdExpMembers.DataBind();
            }
            catch (Exception filldataEx)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ExpirationMembers.aspx.cs", "BindData", filldataEx.Message,
                Convert.ToString(filldataEx.StackTrace), Convert.ToString(filldataEx.InnerException), Convert.ToString(filldataEx.Data));

                throw new Exception(filldataEx.Message);
            }
        }
        protected void GrdExpMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtMembers = (DataTable)Session["ExpiredMembers"];
                GrdExpMembers.PageIndex = e.NewPageIndex;
                GrdExpMembers.DataSource = dtMembers;
                GrdExpMembers.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ExpirationMembers.aspx.cs", "GrdExpMembers_PageIndexChanging", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void GrdExpMembers_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortDir = Convert.ToInt32(hdnsortcount.Value);
                string SortExp = e.SortExpression.ToString();
                dtMembers = (DataTable)Session["ExpiredMembers"];
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
                DataView Dv = new DataView(dtMembers);
                if (SortDir == 0)
                {
                    if (SortExp == "UserID")
                    {
                        Dv.Sort = "User_ID desc";
                    }
                    else if (SortExp == "ProfileName")
                    {
                        Dv.Sort = "Profile_name desc";
                    }
                    else if (SortExp == "ExpirationDate")
                    {
                        Dv.Sort = "subscription_renewal_date desc";
                    }
                    hdnsortcount.Value = "1";
                }
                else
                {
                    if (SortExp == "UserID")
                    {
                        Dv.Sort = "User_ID ASC";
                    }
                    else if (SortExp == "ProfileName")
                    {
                        Dv.Sort = "Profile_name ASC";
                    }
                    else if (SortExp == "ExpirationDate")
                    {
                        Dv.Sort = "subscription_renewal_date ASC";
                    }
                    hdnsortcount.Value = "0";
                }
                Session["ExpiredMembers"] = Dv.ToTable();
                GrdExpMembers.DataSource = Dv;
                GrdExpMembers.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ExpirationMembers.aspx.cs", "GrdExpMembers_Sorting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtexportexcel = new DataTable();
                dtexportexcel = (DataTable)Session["ExpiredMembers"];
                if (dtexportexcel != null && dtexportexcel.Rows.Count > 0)
                {
                    grdExportexcel.RowStyle.Wrap = false;
                    grdExportexcel.AlternatingRowStyle.Wrap = false;
                    grdExportexcel.DataSource = dtexportexcel;
                    grdExportexcel.DataBind();
                    grdExportexcel.HeaderRow.Font.Bold = true;
                    grdExportexcel.HeaderRow.ForeColor = Color.White;
                    grdExportexcel.HeaderRow.BackColor = Color.FromName("#339A99");
                    StringWriter stw = new StringWriter();
                    HtmlTextWriter htextw = new HtmlTextWriter(stw);
                    grdExportexcel.RenderControl(htextw);
                    Response.Write("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
                    Response.Write("<head>");
                    Response.Write("<!--[if gte mso 9]><xml>");
                    Response.Write("<x:ExcelWorkbook>");
                    Response.Write("<x:ExcelWorksheets>");
                    Response.Write("<x:ExcelWorksheet>");
                    Response.Write("<x:Name>App Downloads</x:Name>");
                    Response.Write("<x:WorksheetOptions>");
                    Response.Write("<x:Print>");
                    Response.Write("<x:ValidPrinterInfo/>");
                    Response.Write("</x:Print>");
                    Response.Write("</x:WorksheetOptions>");
                    Response.Write("</x:ExcelWorksheet>");
                    Response.Write("</x:ExcelWorksheets>");
                    Response.Write("</x:ExcelWorkbook>");
                    Response.Write("</xml>");
                    Response.Write("<![endif]--> ");
                    Response.Write("</head>");
                    Response.Write("<body>");
                    Response.Write(stw.ToString());
                    Response.AddHeader("content-disposition", "attachment; filename=" + objCommonBll.MakeValidFileName(txtStartDate.Text.Trim() + " - " + txtEndDate.Text.Trim()) + " Expiration Members.xls");
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = "application/vnd.xls";
                    Response.Write("</body>");
                    Response.Write("</html>");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ExpirationMembers.aspx.cs", "btnExport_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}