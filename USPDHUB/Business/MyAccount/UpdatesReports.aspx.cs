using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.IO;
using System.Configuration;
using USPDHUBBLL;

public partial class Business_MyAccount_UpdatesReports : BaseWeb
{
    public static DataTable dtobj = new DataTable();
    BusinessUpdatesBLL ObjBusUpdates = new BusinessUpdatesBLL();
    BusinessBLL ObjBus = new BusinessBLL();
    CommonBLL ObjCommon = new CommonBLL();
    int ProfileID = 0;
    public int UserID = 0;
    public static DataTable DtHis = new DataTable();
    public int sentTotal = 0;
    public int openedTotal = 0;
    public int optOutTotal = 0;
    public int unOpenedTotal = 0;
    public static DataTable DtOptOuts = new DataTable();
    public int TotalScheduleAndSentCount = 0;
    public string archive = "";
    public int bouncedTotal = 0;
    public int C_UserID = 0;
    public string RootPath = "";
    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblmess.Text = "";
            if (Session["userid"] == null)
            {
                string urlinfo = Page.ResolveClientUrl("~/Login.aspx?sflag=1");
                Response.Redirect(urlinfo);
            }
            else
            {
                UserID = Convert.ToInt32(Session["UserID"].ToString());

                if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                    C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                else
                    C_UserID = UserID;
            }
            // *** Get Domain Name *** //
            RootPath = Session["RootPath"].ToString();
            if (Session["ProfileID"] != null)
                ProfileID = Convert.ToInt32(Session["ProfileID"]);
            if (!string.IsNullOrEmpty(Request.QueryString["Flag"]))
                archive = Request.QueryString["Flag"].ToString();
            else
                archive = "Current";
            if (!IsPostBack)
            {
                hdnUrl.Value = Request.UrlReferrer == null ? "" : Request.UrlReferrer.ToString();
                FillDatalist();
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "Page_Load", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    public void FillDatalist()
    {
        try
        {
            dtobj = ObjBusUpdates.GetSendUpdatesByProfileID(Convert.ToInt32(Session["ProfileID"]));
            dtobj.Columns.Add("IsSelected", typeof(string));
            dtobj = RemoveArchive(dtobj, archive);
            Session["ReportGrid"] = dtobj;
            if (dtobj.Rows.Count == 0)
            {
                btnExportSelected.Visible = false;
                btnConsolidatedeport.Visible = false;
                btnPrint.Visible = false;
            }
            else
            {
                btnExportSelected.Visible = true;
                btnConsolidatedeport.Visible = true;
                btnPrint.Visible = true;
            }
            gridUpdates.DataSource = dtobj;
            gridUpdates.DataBind();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "FillDatalist", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    private DataTable RemoveArchive(DataTable dt, string Archive)
    {
        // *** Get Newsletter without Achrive *** //
        DataTable DtData = dt;
        try
        {
            string SelectQuery = string.Empty;
            if (Archive == "Current")
            {
                SelectQuery = "IsArchive='True'";
            }
            else
            {
                SelectQuery = "IsArchive='False'";
            }
            DataRow[] DRSelectArcive;
            DRSelectArcive = DtData.Select(SelectQuery);
            DataTable dtupdatedarcive = DtData.Clone();
            foreach (DataRow dr in DRSelectArcive)
            {
                dtupdatedarcive.ImportRow(dr);
                DtData.Rows.Remove(dr);
            }
            DtData.AcceptChanges();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "RemoveArchive", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        return DtData;
    }
    protected void gridUpdates_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkName = e.Row.FindControl("lnkUpdateName") as LinkButton;
                Label lblSent = e.Row.FindControl("lblSent") as Label;
                Label lblopened = e.Row.FindControl("lblOpened") as Label;
                Label lbloptcount = e.Row.FindControl("lblOptOut") as Label;
                Label lblUnopened = e.Row.FindControl("lblUnopened") as Label;
                Label lblBounced = e.Row.FindControl("lblBounced") as Label;
                LinkButton lnkopened = e.Row.FindControl("lnkopen") as LinkButton;
                LinkButton lnkoptout = e.Row.FindControl("lnkoptout") as LinkButton;
                LinkButton lnkhis = e.Row.FindControl("lblhistroy") as LinkButton;
                LinkButton lnkBounced = e.Row.FindControl("lnkBounced") as LinkButton;
                //Sent
                //To get the Total of Sent Flyers shown in the footer
                string sent = lblSent.Text;
                string[] sentstrings1 = sent.Split('<');
                int sentflyer = Convert.ToInt32(sentstrings1[0]);
                sentTotal += sentflyer;

                //opened
                string opened = lblopened.Text;
                string[] openedstrings = opened.Split('<');
                int openedflyer = Convert.ToInt32(openedstrings[0]);
                openedTotal += openedflyer;

                //OptOut
                string optout = lbloptcount.Text;
                string[] optoutstrings = optout.Split('<');
                int optoutflyer = Convert.ToInt32(optoutstrings[0]);
                optOutTotal += optoutflyer;

                //UnOpened
                int unopenedpercent = 0;
                if (sentflyer != 0)
                    unopenedpercent = (100 * (sentflyer - openedflyer)) / sentflyer;
                lblUnopened.Text = (Convert.ToInt32(sentstrings1[0]) - Convert.ToInt32(openedstrings[0])) + "<br>" + unopenedpercent + "%";
                //Bounced
                string bounced = lblBounced.Text;
                string[] bouncedstrings = bounced.Split('<');
                int bouncedflyer = Convert.ToInt32(bouncedstrings[0]);
                bouncedTotal += bouncedflyer;
                //Status
                Label lblstatusflag = e.Row.FindControl("lblstatusflag") as Label;
                Label lblStatus = e.Row.FindControl("lblstatus") as Label;
                if (lblstatusflag.Text == "True")
                {
                    lblStatus.Text = "Active";
                }
                else
                {
                    lblStatus.Text = "Inactive";
                }

                //Sent Link

                if (sentflyer == 0)
                {
                    lblSent.Visible = true;
                    lnkhis.Visible = false;
                }
                else
                {
                    lnkhis.Visible = true;
                    lblSent.Visible = false;
                }

                //Opened Link

                if (openedflyer == 0)
                {

                    lblopened.Visible = true;
                    lnkopened.Visible = false;
                }
                else
                {

                    lnkopened.Visible = true;
                    lblopened.Visible = false;
                }

                //OptOut Link          
                if (optoutflyer == 0)
                {
                    lnkoptout.Visible = false;
                    lbloptcount.Visible = true;
                }
                else
                {
                    lbloptcount.Visible = false;
                    lnkoptout.Visible = true;
                }
                if (bouncedflyer == 0)
                {
                    lblBounced.Visible = true;
                    lnkBounced.Visible = false;
                }
                else
                {
                    lblBounced.Visible = false;
                    lnkBounced.Visible = true;
                }
                // *** Append update image ***
                Label lblupdateimg = e.Row.FindControl("lblUpdateimg") as Label;
                string UpdateID = lnkName.CommandArgument;
                if (File.Exists(Server.MapPath("~") + "\\Upload\\Updates\\" + ProfileID.ToString() + "\\" + UpdateID + ".jpg"))
                    lblupdateimg.Text = "<img src='" + RootPath + "/Upload/Updates/" + ProfileID.ToString() + "/" + UpdateID + ".jpg' border='0' width='100' height='50'/>";
                else
                    lblupdateimg.Text = "";
                string strScript = "SelectDeSelectHeader(" + ((CheckBox)e.Row.Cells[1].FindControl("chkUpdate")).ClientID + ");";
                ((CheckBox)e.Row.Cells[1].FindControl("chkUpdate")).Attributes.Add("onclick", strScript);

                Label lblScheduledCount = e.Row.FindControl("TotalScheduleCount") as Label;
                TotalScheduleAndSentCount += Convert.ToInt32(lblScheduledCount.Text);
            }

            //Footer
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                CheckBox chkheader = (CheckBox)gridUpdates.HeaderRow.FindControl("chkSelectAll");
                if (chkheader.Checked == true)
                {
                    TotalScheduleAndSentCount = Convert.ToInt32(hdnTotalUpdatesCount.Value);
                }

                Label lblsentTotal = e.Row.FindControl("lblsentTotal") as Label;
                if (sentTotal == 0)
                    lblsentTotal.Text = "0<br>0%";
                else
                {
                    if (TotalScheduleAndSentCount != 0)
                        lblsentTotal.Text = sentTotal + "<br>" + ((sentTotal * 100) / TotalScheduleAndSentCount) + "%";
                }

                Label lblOpenedTotal = e.Row.FindControl("lblOpenedTotal") as Label;
                if (openedTotal == 0)
                {
                    lblOpenedTotal.Text = "0<br>0%";
                }
                else
                {
                    if (sentTotal > 0)
                        lblOpenedTotal.Text = openedTotal + "<br>" + ((100 * openedTotal) / sentTotal) + "%";
                }

                Label lblOptOutTotal = e.Row.FindControl("lblOptOutTotal") as Label;
                if (optOutTotal == 0)
                {
                    lblOptOutTotal.Text = "0<br>0%";
                }
                else
                {
                    if (openedTotal > 0)
                        lblOptOutTotal.Text = optOutTotal + "<br>" + ((100 * optOutTotal) / openedTotal) + "%";
                }

                Label lblUnOpendTotal = e.Row.FindControl("lblUnOpendTotal") as Label;
                if (openedTotal == 0)
                    lblUnOpendTotal.Text = sentTotal + "<br>0%";
                else
                {
                    if (sentTotal > 0)
                        lblUnOpendTotal.Text = (sentTotal - openedTotal) + "<br>" + (100 - ((100 * openedTotal) / sentTotal)) + "%";
                }
                Label lblBouncedTotal = e.Row.FindControl("lblBouncedTotal") as Label;
                if (bouncedTotal == 0)
                    lblBouncedTotal.Text = "0<br>0%";
                else
                    lblBouncedTotal.Text = bouncedTotal + "<br>" + ((100 * bouncedTotal) / sentTotal) + "%";
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "gridUpdates_RowDataBound", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lblhistroy_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkHis = sender as LinkButton;
            DtHis = ObjBusUpdates.GetBusinessUpdateDetailsByBusinessUpdateID(Convert.ToInt32(lnkHis.CommandArgument));
            if (DtHis.Rows.Count > 0)
            {

                // *** Issue 1031 *** //
                //DataView dtcampview = DtHis.DefaultView;
                //dtcampview.Sort = "sent_Flag ASC";
                //DtHis = dtcampview.ToTable();
                DataView dtcampview = new DataView(DtHis, "sent_Flag=1", "sent_Flag ASC", DataViewRowState.CurrentRows);
                DtHis = dtcampview.ToTable();
                // *** End Issue 1031 ***  //
                grdviewsenthis.DataSource = DtHis;
                grdviewsenthis.DataBind();
                DataTable DtNewMaster = new DataTable();
                DtNewMaster = ObjBusUpdates.UpdateBusinessUpdateDetails(Convert.ToInt32(lnkHis.CommandArgument));
                if (DtNewMaster.Rows.Count > 0)
                {
                    lblviewsentnewlettername.Text = DtNewMaster.Rows[0]["UpdateTitle"].ToString();
                }
                ModalPopupExtender3.Show();
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "lblhistroy_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lnkopen_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton LnkOpenID = sender as LinkButton;
            DtOptOuts = ObjBusUpdates.GetOpenedMailsForUpdateID(Convert.ToInt32(LnkOpenID.CommandArgument), "BU");
            if (DtOptOuts.Rows.Count > 0)
            {
                grdmailopen.DataSource = DtOptOuts;
                grdmailopen.DataBind();
                ModalPopupExtender4.Show();
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "lnkopen_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void imclose_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void grdoptouts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdoptouts.PageIndex = e.NewPageIndex;
            grdoptouts.DataSource = DtOptOuts;
            grdoptouts.DataBind();
            ModalPopupExtender10.Show();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "grdoptouts_PageIndexChanging", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void lnkoptout_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton LnkOptOutID = sender as LinkButton;
            DtOptOuts = ObjBusUpdates.GetOptOutCountForUpdateID(Convert.ToInt32(LnkOptOutID.CommandArgument));
            if (DtOptOuts.Rows.Count > 0)
            {
                grdoptouts.DataSource = DtOptOuts;
                grdoptouts.DataBind();
                ModalPopupExtender10.Show();
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "lnkoptout_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void grdmailopen_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdmailopen.PageIndex = e.NewPageIndex;
            grdmailopen.DataSource = DtOptOuts;
            grdmailopen.DataBind();
            ModalPopupExtender4.Show();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "grdmailopen_PageIndexChanging", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void grdviewsenthis_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdviewsenthis.PageIndex = e.NewPageIndex;
            grdviewsenthis.DataSource = DtHis;
            grdviewsenthis.DataBind();
            ModalPopupExtender3.Show();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "grdviewsenthis_PageIndexChanging", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void gridUpdates_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable ds = (DataTable)Session["ReportGrid"];
            ds = RemoveArchive(ds, archive);
            Session["ReportGrid"] = ds;
            if (ds != null)
            {
                ds.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gridUpdates.DataSource = ds;
                gridUpdates.DataBind();
            }
            if (btnExportSelected.Text == "Export")
            {
                gridUpdates.FooterRow.Visible = true;
                btnConsolidatedeport.Visible = false;
                gridUpdates.Columns[1].Visible = false;
                gridUpdates.FooterRow.BorderColor = Color.Orange;
                gridUpdates.FooterRow.BorderWidth = 2;
                gridUpdates.FooterRow.Cells[0].Font.Size = 15;
                gridUpdates.FooterRow.Height = 60;
                lblConsolidated.Visible = true;
                ScrollDown.Focus();
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "gridUpdates_Sorting", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    private string GetSortDirection(string column)
    {
        string sortDirection = "ASC";
        try
        {
            string sortExpression = ViewState["SortExpression"] as string;
            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "GetSortDirection", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        return sortDirection;
    }

    protected void btnConsolidatedeport_Click(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkheader = (CheckBox)gridUpdates.HeaderRow.FindControl("chkSelectAll");
            if (chkheader.Checked == false)
            {
                DataTable dt = ((DataTable)Session["ReportGrid"]).Copy();
                foreach (GridViewRow grdrow in gridUpdates.Rows)
                {
                    int k = Convert.ToInt32(((LinkButton)grdrow.FindControl("lnkUpdateName")).CommandArgument);
                    DataRow[] dr = dt.Select("UpdateId=" + k);
                    if (((CheckBox)grdrow.FindControl("chkUpdate")).Checked)
                    {
                        dr[0]["IsSelected"] = "Yes";
                    }
                    else
                    {
                        dr[0]["IsSelected"] = "No";
                    }
                    dt.AcceptChanges();
                }
                DataRow[] DRSelect;
                DRSelect = dt.Select("IsSelected='No'");
                DataTable dtupdated = dt.Clone();
                foreach (DataRow dr in DRSelect)
                {
                    dtupdated.ImportRow(dr);
                    dt.Rows.Remove(dr);
                }

                dt.AcceptChanges();
                gridUpdates.DataSource = dt;
                gridUpdates.DataBind();
                Session["ReportGrid"] = dt;
            }
            gridUpdates.FooterRow.Visible = true;
            btnConsolidatedeport.Visible = false;
            btnExportSelected.Text = "Export";
            gridUpdates.Columns[1].Visible = false;
            gridUpdates.FooterRow.BorderColor = Color.Orange;
            gridUpdates.FooterRow.Cells[0].Font.Size = 15;
            gridUpdates.FooterRow.BorderWidth = 2;
            gridUpdates.FooterRow.Height = 60;
            lblConsolidated.Visible = true;
            ScrollDown.Focus();//To scroll down the Panel
            if (gridUpdates.Rows.Count == 0)
            {
                btnExportSelected.Visible = false;
                btnPrint.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "btnConsolidatedeport_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void btnExportSelected_Click(object sender, EventArgs e)
    {
        try
        {
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            foreach (DataControlField col in gridUpdates.Columns)
            {
                if (col.HeaderText == "Update Image")
                {
                    int colPos = gridUpdates.Columns.IndexOf(col);
                    gridUpdates.Columns[colPos].Visible = false;
                }
                if (col.HeaderText == "Select All")
                {
                    int colPos = gridUpdates.Columns.IndexOf(col);
                    gridUpdates.Columns[colPos].Visible = false;
                }
                if (col.HeaderText == "Update Title")
                {
                    int colPos = gridUpdates.Columns.IndexOf(col);
                    gridUpdates.Columns[colPos].Visible = false;
                }
                if (col.HeaderText == "Update Title1")
                {
                    int colPos = gridUpdates.Columns.IndexOf(col);
                    gridUpdates.Columns[colPos].Visible = true;
                    gridUpdates.HeaderRow.Cells[colPos].Text = "Update Title";
                }
                if (col.HeaderText == "Sent")
                {
                    int colPos = gridUpdates.Columns.IndexOf(col);
                    gridUpdates.Columns[colPos].Visible = false;
                }
                if (col.HeaderText == "Sent1")
                {
                    int colPos = gridUpdates.Columns.IndexOf(col);
                    gridUpdates.Columns[colPos].Visible = true;
                    gridUpdates.HeaderRow.Cells[colPos].Text = "Sent";
                }
                if (col.HeaderText == "Opened")
                {
                    int colPos = gridUpdates.Columns.IndexOf(col);
                    gridUpdates.Columns[colPos].Visible = false;
                }
                if (col.HeaderText == "Opened1")
                {
                    int colPos = gridUpdates.Columns.IndexOf(col);
                    gridUpdates.Columns[colPos].Visible = true;
                    gridUpdates.HeaderRow.Cells[colPos].Text = "Opened";
                }
                if (col.HeaderText == "Opt Out")
                {
                    int colPos = gridUpdates.Columns.IndexOf(col);
                    gridUpdates.Columns[colPos].Visible = false;
                }
                if (col.HeaderText == "Opt Out1")
                {
                    int colPos = gridUpdates.Columns.IndexOf(col);
                    gridUpdates.Columns[colPos].Visible = true;
                    gridUpdates.HeaderRow.Cells[colPos].Text = "Opt Out";
                }
                if (col.HeaderText == "Status")
                {
                    int colPos = gridUpdates.Columns.IndexOf(col);
                    gridUpdates.HeaderRow.Cells[colPos].Text = "Status";
                }
                if (col.HeaderText == "Posted On")
                {
                    int colPos = gridUpdates.Columns.IndexOf(col);
                    gridUpdates.HeaderRow.Cells[colPos].Text = "Posted On";
                }
            }
            for (int i = 0; i < gridUpdates.HeaderRow.Cells.Count; i++)
            {
                gridUpdates.HeaderRow.Cells[i].Style.Add("background-color", "#428AD7");
            }
            int removeColumns = 0;
            if (btnExportSelected.Text == "Export")
                gridUpdates.FooterRow.BorderWidth = 0;
            else
                removeColumns = 1;
            foreach (GridViewRow grdrow in gridUpdates.Rows)
            {
                if (removeColumns == 1)
                {
                    if (((CheckBox)grdrow.FindControl("chkUpdate")).Checked == false)
                    {
                        gridUpdates.Rows[grdrow.RowIndex].Visible = false;
                    }
                }
                grdrow.FindControl("lnkBounced").Visible = false;
                grdrow.FindControl("lblBounced").Visible = true;
            }
            gridUpdates.GridLines = GridLines.Both;
            gridUpdates.RenderControl(htextw);
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename= UpdatesReport.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(stw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "btnExportSelected_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    protected void lnkupdateName_Click(object sender, EventArgs e)
    {
        try
        {
            string PreviewHTML = string.Empty;
            string UnUsbscribeLink = string.Empty;
            LinkButton lnkdetails = sender as LinkButton;
            DataTable DtBusinessUpdateDetails = ObjBusUpdates.UpdateBusinessUpdateDetails(Convert.ToInt32(lnkdetails.CommandArgument));
            if (DtBusinessUpdateDetails.Rows.Count > 0)
            {
                PreviewHTML = DtBusinessUpdateDetails.Rows[0]["UpdatedText"].ToString();
                UnUsbscribeLink = UserProfileUnsubscribeLink();
                PreviewHTML = "<html><head></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='border: solid 2px #F4EBEB;'><tr><td colspan='2' style='padding:30px;'>" + PreviewHTML + "</td></tr></table></body></html>";
                lblPreviewHTML.Text = PreviewHTML;
                lblupdatename.Text = DtBusinessUpdateDetails.Rows[0]["UpdateTitle"].ToString();
                ModalPopupExtender2.Show();
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "lnkupdateName_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    private string UserProfileUnsubscribeLink()
    {
        string UnSubscribeLinkText = string.Empty;
        try
        {
            DataTable DtProfileAddress = new DataTable();
            DtProfileAddress = ObjBus.GetProfileDetailsByProfileID(ProfileID);
            string TotalAddress = string.Empty;
            string ProfileName = string.Empty;
            if (DtProfileAddress.Rows.Count > 0)
            {
                if (DtProfileAddress.Rows[0]["Profile_name"].ToString() != "")
                {
                    ProfileName = DtProfileAddress.Rows[0]["Profile_name"].ToString();
                }
                if (DtProfileAddress.Rows[0]["Profile_StreetAddress1"].ToString() != "")
                {
                    TotalAddress = DtProfileAddress.Rows[0]["Profile_StreetAddress1"].ToString();
                }
                if (DtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString() != "")
                {
                    if (TotalAddress != "")
                    {
                        TotalAddress = TotalAddress + ", " + DtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString();
                    }
                    else
                    {
                        TotalAddress = DtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString();
                    }
                }
                if (DtProfileAddress.Rows[0]["Profile_City"].ToString() != "")
                {
                    if (TotalAddress != "")
                    {
                        TotalAddress = TotalAddress + ", " + DtProfileAddress.Rows[0]["Profile_City"].ToString();
                    }
                    else
                    {
                        TotalAddress = DtProfileAddress.Rows[0]["Profile_City"].ToString();
                    }
                }
                if (DtProfileAddress.Rows[0]["Profile_State"].ToString() != "")
                {
                    if (TotalAddress != "")
                    {
                        TotalAddress = TotalAddress + ", " + DtProfileAddress.Rows[0]["Profile_State"].ToString();
                    }
                    else
                    {
                        TotalAddress = DtProfileAddress.Rows[0]["Profile_State"].ToString();
                    }
                }
                if (DtProfileAddress.Rows[0]["Profile_Zipcode"].ToString() != "")
                {
                    if (TotalAddress != "")
                    {
                        TotalAddress = TotalAddress + ", " + DtProfileAddress.Rows[0]["Profile_Zipcode"].ToString();
                    }
                    else
                    {
                        TotalAddress = DtProfileAddress.Rows[0]["Profile_Zipcode"].ToString();
                    }
                }
            }
            UnSubscribeLinkText = "This message was sent " + ProfileName + " to &#60;recipient's email address&#62;. It was sent from &#60;sender's email address&#62;" + TotalAddress + ". If you no longer wish to receive our updates, <a href='" + RootPath + "/Unsubscribeupdate.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "' target='_blank'>click here</a> to unsubscribe.";
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "UserProfileUnsubscribeLink", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        return UnSubscribeLinkText;
    }

    protected void lnkStatus_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkStatus = (LinkButton)sender;
            int i = 0;
            i = ObjBusUpdates.UpdateBusinessUpdateStatus(Convert.ToInt32(lnkStatus.CommandArgument), lnkStatus.Text == "Active" ? false : true, ProfileID, C_UserID);
            if (i > 0)
                lblmess.Text = "<font color='green'>Status Updated Successfully</font>";
            FillDatalist();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "lnkStatus_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void grdviewsenthis_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblstatus = e.Row.FindControl("Label2") as Label;
                if (lblstatus.Text == "1")
                {
                    lblstatus.Text = "Sent";
                }
                else if (lblstatus.Text == "0")
                {
                    lblstatus.Text = "Scheduled";
                }
                else if (lblstatus.Text == "2")
                {
                    lblstatus.Text = "Cancel";
                }
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "grdviewsenthis_RowDataBound", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string url = "";
        if (hdnUrl.Value == "")
            url = Page.ResolveClientUrl("~/Business/MyAccount/ManageUpdates.aspx");
        else
            url = hdnUrl.Value;
        Response.Redirect(url);
    }
    public string GetUpdatesCount(object id, object flag)
    {
        string value = string.Empty;
        try
        {
            DataSet ds = new DataSet();
            ds = ObjBusUpdates.GetUpdatesCounts(Convert.ToInt32(id), Convert.ToInt32(flag), ProfileID);
            int sentUpdates = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            int UpdatesPercent = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            hdnTotalUpdatesCount.Value = ds.Tables[0].Rows[0][2].ToString();

            value = sentUpdates + "<br>" + UpdatesPercent + "%";
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "GetUpdatesCount", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        return value;
    }

    public string GetSheduledCount(object id)
    {
        string value = string.Empty;
        try
        {

            value = ObjCommon.GetScheduledCount(Convert.ToInt32(id), 2);
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "GetSheduledCount", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
        return value;
    }
    protected void lnkBounced_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton LnKBouncedID = sender as LinkButton;
            DtOptOuts = ObjBusUpdates.GetBouncedEailsForUpdateID(Convert.ToInt32(LnKBouncedID.CommandArgument), "BU");
            Session["DtOptOuts"] = DtOptOuts;
            if (DtOptOuts.Rows.Count > 0)
            {
                grdBounced.PageIndex = 0;
                grdBounced.DataSource = DtOptOuts;
                grdBounced.DataBind();
                ModalPopupExtender1.Show();
            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "lnkBounced_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void grdBounced_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdBounced.PageIndex = e.NewPageIndex;
            grdBounced.DataSource = (DataTable)Session["DtOptOuts"];
            grdBounced.DataBind();
            ModalPopupExtender1.Show();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "UpdatesReports.aspx.cs", "grdBounced_PageIndexChanging", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
}