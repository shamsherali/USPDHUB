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
    public partial class WebnairItems : System.Web.UI.Page
    {
        AdminBLL objAdminBll = new AdminBLL();
        public int SortDir = 0;
        DataTable dtWebnairs;
        DataTable dtRegs;
        CommonBLL objCommonBll = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnsortdire.Value = "";
                hdnsortcount.Value = "0";
                LoadWebnairs();
            }
        }
        private void LoadWebnairs()
        {
            try
            {
                dtWebnairs = objAdminBll.GetAllWebnairs();
                GrdWebnairs.DataSource = dtWebnairs;
                GrdWebnairs.DataBind();
                if (dtWebnairs.Rows.Count > 0)
                    Session["AdminWebnairs"] = dtWebnairs;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "WebnairItems.aspx.cs", "LoadWebnairs", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void GrdWebnairs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkRegs = e.Row.FindControl("lnkRegistrations") as LinkButton;
                    if (lnkRegs.Text == "0")
                        lnkRegs.Visible = false;
                    LinkButton lnkOpened = e.Row.FindControl("lnkOpened") as LinkButton;
                    if (lnkOpened.Text == "0")
                        lnkOpened.Visible = false;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "WebnairItems.aspx.cs", "GrdWebnairs_RowDataBound", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void GrdWebnairs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtWebnairs = (DataTable)Session["AdminWebnairs"];
                GrdWebnairs.PageIndex = e.NewPageIndex;
                GrdWebnairs.DataSource = dtWebnairs;
                GrdWebnairs.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "WebnairItems.aspx.cs", "GrdWebnairs_PageIndexChanging", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void GrdWebnairs_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortDir = Convert.ToInt32(hdnsortcount.Value);
                string SortExp = e.SortExpression.ToString();
                dtWebnairs = (DataTable)Session["AdminWebnairs"];
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
                DataView Dv = new DataView(dtWebnairs);
                if (SortDir == 0)
                {
                    if (SortExp == "Title")
                    {
                        Dv.Sort = "WebnairTitle desc";
                    }
                    else if (SortExp == "SentDate")
                    {
                        Dv.Sort = "SentDate desc";
                    }
                    else if (SortExp == "WebnairDate")
                    {
                        Dv.Sort = "WebnairDate desc";
                    }
                    else if (SortExp == "Location")
                    {
                        Dv.Sort = "Location desc";
                    }
                    else if (SortExp == "RegistrationCount")
                    {
                        Dv.Sort = "RegistrationCount desc";
                    }
                    hdnsortcount.Value = "1";
                }
                else
                {
                    if (SortExp == "Title")
                    {
                        Dv.Sort = "WebnairTitle ASC";
                    }
                    else if (SortExp == "SentDate")
                    {
                        Dv.Sort = "SentDate ASC";
                    }
                    else if (SortExp == "WebnairDate")
                    {
                        Dv.Sort = "WebnairDate ASC";
                    }
                    else if (SortExp == "Location")
                    {
                        Dv.Sort = "Location ASC";
                    }
                    else if (SortExp == "RegistrationCount")
                    {
                        Dv.Sort = "RegistrationCount ASC";
                    }
                    hdnsortcount.Value = "0";
                }
                Session["AdminWebnairs"] = Dv.ToTable();
                GrdWebnairs.DataSource = Dv;
                GrdWebnairs.DataBind();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "WebnairItems.aspx.cs", "GrdWebnairs_Sorting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkRegisrations_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkRegs = sender as LinkButton;
                string webnairtitle = "";
                dtRegs = objAdminBll.GetAllRegistrationsByTipId(Convert.ToInt32(lnkRegs.CommandArgument), out webnairtitle);
                if (dtRegs.Rows.Count > 0)
                {
                    lblWebnairTitle.Text = webnairtitle;
                    Session["Registrations"] = dtRegs;
                    GrdRegistrations.DataSource = dtRegs;
                    GrdRegistrations.DataBind();
                    ModalRegs.Show();
                    hdnPopsortdire.Value = "";
                    hdnPopsortcount.Value = "0";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "WebnairItems.aspx.cs", "lnkRegisrations_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void GrdRegistrations_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortDir = Convert.ToInt32(hdnPopsortcount.Value);
                string SortExp = e.SortExpression.ToString();
                dtRegs = (DataTable)Session["Registrations"];
                if (hdnPopsortdire.Value != "")
                {
                    if (hdnPopsortdire.Value != SortExp)
                    {
                        hdnPopsortdire.Value = SortExp;
                        SortDir = 0;
                        hdnPopsortcount.Value = "0";
                    }
                }
                else
                {
                    hdnPopsortdire.Value = SortExp;
                }
                DataView Dv = new DataView(dtRegs);
                if (SortDir == 0)
                {
                    if (SortExp == "FirstName")
                    {
                        Dv.Sort = "FirstName desc";
                    }
                    else if (SortExp == "LastName")
                    {
                        Dv.Sort = "LastName desc";
                    }
                    else if (SortExp == "EmailAddress")
                    {
                        Dv.Sort = "EmailAddress desc";
                    }
                    else if (SortExp == "CreatedDate")
                    {
                        Dv.Sort = "CreatedDate desc";
                    }
                    else if (SortExp == "PhoneNumber")
                    {
                        Dv.Sort = "PhoneNumber desc";
                    }
                    hdnPopsortcount.Value = "1";
                }
                else
                {
                    if (SortExp == "FirstName")
                    {
                        Dv.Sort = "FirstName ASC";
                    }
                    else if (SortExp == "LastName")
                    {
                        Dv.Sort = "LastName ASC";
                    }
                    else if (SortExp == "EmailAddress")
                    {
                        Dv.Sort = "EmailAddress ASC";
                    }
                    else if (SortExp == "CreatedDate")
                    {
                        Dv.Sort = "CreatedDate ASC";
                    }
                    else if (SortExp == "PhoneNumber")
                    {
                        Dv.Sort = "PhoneNumber ASC";
                    }
                    hdnPopsortcount.Value = "0";
                }
                Session["Registrations"] = Dv.ToTable();
                GrdRegistrations.DataSource = Dv;
                GrdRegistrations.DataBind();
                ModalRegs.Show();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "WebnairItems.aspx.cs", "GrdRegistrations_Sorting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void GrdRegistrations_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtRegs = (DataTable)Session["Registrations"];
                GrdRegistrations.PageIndex = e.NewPageIndex;
                GrdRegistrations.DataSource = dtRegs;
                GrdRegistrations.DataBind();
                ModalRegs.Show();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "WebnairItems.aspx.cs", "GrdRegistrations_PageIndexChanging", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtexportexcel = new DataTable();
                dtexportexcel = (DataTable)Session["Registrations"];
                if (dtexportexcel.Rows.Count > 0)
                {

                    //string attachment = "attachment; filename= "  + objCommonBll.MakeValidFileName(lblWebnairTitle.Text)  + ".xls";
                    grdExportexcel.RowStyle.Wrap = false;
                    grdExportexcel.AlternatingRowStyle.Wrap = false;
                    grdExportexcel.DataSource = dtexportexcel;
                    grdExportexcel.DataBind();
                    grdExportexcel.HeaderRow.Font.Bold = true;
                    grdExportexcel.HeaderRow.ForeColor = Color.White;
                    grdExportexcel.HeaderRow.BackColor = Color.FromName("#339A99");
                    //Response.Clear();
                    //Response.AddHeader("content-disposition", attachment);
                    //Response.ContentType = "application/vnd.ms-excel";
                    StringWriter stw = new StringWriter();
                    HtmlTextWriter htextw = new HtmlTextWriter(stw);
                    grdExportexcel.RenderControl(htextw);
                    //Response.Write(stw.ToString());
                    //Response.End();
                    //Response.Clear();

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
                    Response.AddHeader("content-disposition", "attachment; filename=" + objCommonBll.MakeValidFileName(lblWebnairTitle.Text) + " - Registrations.xls");
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
                objInBuiltData.ErrorHandling("ERROR", "WebnairItems.aspx.cs", "btnExport_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkOpened_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkOpenEmails = sender as LinkButton;
                string webnairtitle = "";
                dtRegs = objAdminBll.GetAllEmailsByTipId(Convert.ToInt32(lnkOpenEmails.CommandArgument), out webnairtitle);
                if (dtRegs.Rows.Count > 0)
                {
                    lblWTForOpen.Text = webnairtitle;
                    Session["OpenedEmails"] = dtRegs;
                    grdmailopen.DataSource = dtRegs;
                    grdmailopen.DataBind();
                    ModalViews.Show();
                    hdnPopsortdire.Value = "";
                    hdnPopsortcount.Value = "0";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "WebnairItems.aspx.cs", "lnkOpened_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void grdmailopen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtRegs = (DataTable)Session["OpenedEmails"];
                grdmailopen.PageIndex = e.NewPageIndex;
                grdmailopen.DataSource = dtRegs;
                grdmailopen.DataBind();
                ModalViews.Show();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "WebnairItems.aspx.cs", "grdmailopen_PageIndexChanging", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void grdmailopen_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortDir = Convert.ToInt32(hdnPopsortcount.Value);
                string SortExp = e.SortExpression.ToString();
                dtRegs = (DataTable)Session["OpenedEmails"];
                if (hdnPopsortdire.Value != "")
                {
                    if (hdnPopsortdire.Value != SortExp)
                    {
                        hdnPopsortdire.Value = SortExp;
                        SortDir = 0;
                        hdnPopsortcount.Value = "0";
                    }
                }
                else
                {
                    hdnPopsortdire.Value = SortExp;
                }
                DataView Dv = new DataView(dtRegs);
                if (SortDir == 0)
                {
                    if (SortExp == "ReceiverEmail")
                    {
                        Dv.Sort = "Receiver_EmailID desc";
                    }
                    else if (SortExp == "CityName")
                    {
                        Dv.Sort = "City_Name desc";
                    }
                    else if (SortExp == "CountryName")
                    {
                        Dv.Sort = "Country_Name desc";
                    }
                    else if (SortExp == "Browser")
                    {
                        Dv.Sort = "Browser desc";
                    }
                    else if (SortExp == "SentDate")
                    {
                        Dv.Sort = "Sending_Date desc";
                    }
                    else if (SortExp == "Browser")
                    {
                        Dv.Sort = "CreatedDate desc";
                    }
                    else if (SortExp == "SentDate")
                    {
                        Dv.Sort = "PhoneNumber desc";
                    }
                    else if (SortExp == "ModifiedDate")
                    {
                        Dv.Sort = "Modified_Date desc";
                    }
                    else if (SortExp == "RegionName")
                    {
                        Dv.Sort = "Region_Name desc";
                    }
                    else if (SortExp == "Zipcode")
                    {
                        Dv.Sort = "Zip_Code desc";
                    }
                    hdnPopsortcount.Value = "1";
                }
                else
                {
                    if (SortExp == "ReceiverEmail")
                    {
                        Dv.Sort = "Receiver_EmailID ASC";
                    }
                    else if (SortExp == "CityName")
                    {
                        Dv.Sort = "City_Name ASC";
                    }
                    else if (SortExp == "CountryName")
                    {
                        Dv.Sort = "Country_Name ASC";
                    }
                    else if (SortExp == "Browser")
                    {
                        Dv.Sort = "Browser ASC";
                    }
                    else if (SortExp == "SentDate")
                    {
                        Dv.Sort = "Sending_Date ASC";
                    }
                    else if (SortExp == "ModifiedDate")
                    {
                        Dv.Sort = "Modified_Date ASC";
                    }
                    else if (SortExp == "RegionName")
                    {
                        Dv.Sort = "Region_Name ASC";
                    }
                    else if (SortExp == "Zipcode")
                    {
                        Dv.Sort = "Zip_Code ASC";
                    }
                    hdnPopsortcount.Value = "0";
                }
                Session["OpenedEmails"] = Dv.ToTable();
                grdmailopen.DataSource = Dv;
                grdmailopen.DataBind();
                ModalViews.Show();
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "WebnairItems.aspx.cs", "grdmailopen_Sorting", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnOpenedExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtexportexcel = new DataTable();
                dtexportexcel = (DataTable)Session["OpenedEmails"];
                if (dtexportexcel.Rows.Count > 0)
                {
                    grdOpenExport.RowStyle.Wrap = false;
                    grdOpenExport.AlternatingRowStyle.Wrap = false;
                    grdOpenExport.DataSource = dtexportexcel;
                    grdOpenExport.DataBind();
                    grdOpenExport.HeaderRow.Font.Bold = true;
                    grdOpenExport.HeaderRow.ForeColor = Color.White;
                    grdOpenExport.HeaderRow.BackColor = Color.FromName("#339A99");
                    StringWriter stw = new StringWriter();
                    HtmlTextWriter htextw = new HtmlTextWriter(stw);
                    grdOpenExport.RenderControl(htextw);
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
                    Response.AddHeader("content-disposition", "attachment; filename=" + objCommonBll.MakeValidFileName(lblWTForOpen.Text) + " - Opened Emails.xls");
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
                objInBuiltData.ErrorHandling("ERROR", "WebnairItems.aspx.cs", "btnOpenedExport_Click", ex.Message,
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