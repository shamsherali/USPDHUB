﻿using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using USPDHUBBLL;
using System.IO;
using System.Configuration;
using System.Drawing;

public partial class Business_MyAccount_EventsReports : BaseWeb
{
    public int ProfileID = 0;
    public int UserID = 0;
    public DataTable Dtobj = new DataTable();
    EventCalendarBLL objEvents = new EventCalendarBLL();
    CommonBLL objCommon = new CommonBLL();
    BusinessUpdatesBLL objUpdate = new BusinessUpdatesBLL();
    BusinessBLL objBus = new BusinessBLL();
    public DataTable DtHis = new DataTable();
    public DataTable DtOptOuts = new DataTable();
    public int SentTotal = 0;
    public int OpenedTotal = 0;
    public int OptOutTotal = 0;
    public int UnOpenedTotal = 0;
    public int TotalScheduleAndSentCount = 0;
    public string Archive = "";
    public int BouncedTotal = 0;
    public string RootPath = "";
    public string DomainName = "";
    protected void Page_Load(object sender, EventArgs e)
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
            ProfileID = Convert.ToInt32(Session["ProfileID"]);
        }
        // *** Get Domain Name *** //
        DomainName = Session["VerticalDomain"].ToString();
        RootPath = Session["RootPath"].ToString();
        if (!string.IsNullOrEmpty(Request.QueryString["Flag"]))
            Archive = Request.QueryString["Flag"].ToString();
        else
            Archive = "Current";

        if (!IsPostBack)
        {
            DataTable dttab = USPDHUBDAL.BusinessDAL.GetTabDetailsByModule("EventCalendar", 0, UserID);
            if (dttab.Rows.Count == 1)
            {
                hdnTabName.Value = dttab.Rows[0]["TabName"].ToString();
            }
            hdnUrl.Value = Request.UrlReferrer == null ? "" : Request.UrlReferrer.ToString();
            ProfileID = Convert.ToInt32(Session["ProfileID"]);
            FillDatalist();
        }
    }

    public void FillDatalist()
    {
        Dtobj = objEvents.GetSendEventsByProfileID(Convert.ToInt32(Session["ProfileID"]));
        Dtobj.Columns.Add("IsSelected", typeof(string));
        Dtobj = RemoveArchive(Dtobj, Archive);
        Session["ReportGrid"] = Dtobj;
        if (Dtobj.Rows.Count > 0)
        {
            btnConsolidatedeport.Visible = true;
            btnExportSelected.Visible = true;
            btnPrint.Visible = true;
        }
        else
        {
            btnConsolidatedeport.Visible = false;
            btnExportSelected.Visible = false;
            btnPrint.Visible = false;
        }
        GrdbusinessEvents.DataSource = Dtobj.DefaultView;
        GrdbusinessEvents.DataBind();
        if (GrdbusinessEvents.FooterRow != null)
            GrdbusinessEvents.FooterRow.Visible = false;
        btnConsolidatedeport.Visible = true;
        btnExportSelected.Text = "Export Selected";
        GrdbusinessEvents.Columns[1].Visible = true;
        lblConsolidated.Visible = false;
        btnBack.Visible = false;
    }

    private DataTable RemoveArchive(DataTable dt, string archive)
    {
        // *** Get Newsletter without Achrive *** //
        DataTable dtData = dt;
        string selectQuery = string.Empty;
        if (archive == "Current")
        {
            selectQuery = "IsArchive='True'";
        }
        else
        {
            selectQuery = "IsArchive='False'";
        }
        DataRow[] dRSelectArcive;
        dRSelectArcive = dtData.Select(selectQuery);
        DataTable dtupdatedarcive = dtData.Clone();
        foreach (DataRow dr in dRSelectArcive)
        {
            dtupdatedarcive.ImportRow(dr);
            dtData.Rows.Remove(dr);
        }
        dtData.AcceptChanges();
        return dtData;
    }

    protected void gridEvents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkEventName = e.Row.FindControl("lnkEventName") as LinkButton;
            Label lblSent = e.Row.FindControl("lblSent") as Label;
            Label lblopened = e.Row.FindControl("lblOpened") as Label;
            Label lbloptcount = e.Row.FindControl("lblOptOut") as Label;
            Label lblUnopened = e.Row.FindControl("lblUnopened") as Label;
            LinkButton lnkopened = e.Row.FindControl("lnkopen") as LinkButton;
            LinkButton lnkoptout = e.Row.FindControl("lnkoptout") as LinkButton;
            LinkButton lnkhis = e.Row.FindControl("lblhistroy") as LinkButton;
            Label lblBounced = e.Row.FindControl("lblBounced") as Label;
            LinkButton lnkBounced = e.Row.FindControl("lnkBounced") as LinkButton;
            //Sent
            //To get the Total of Sent Flyers shown in the footer
            string sent = lblSent.Text;
            string[] sentstrings1 = sent.Split('<');
            int sentflyer = Convert.ToInt32(sentstrings1[0]);
            SentTotal += sentflyer;

            //opened
            string opened = lblopened.Text;
            string[] openedstrings = opened.Split('<');
            int openedflyer = Convert.ToInt32(openedstrings[0]);
            OpenedTotal += openedflyer;

            //OptOut
            string optout = lbloptcount.Text;
            string[] optoutstrings = optout.Split('<');
            int optoutflyer = Convert.ToInt32(optoutstrings[0]);
            OptOutTotal += optoutflyer;

            //UnOpened
            int unopenedpercent = 0;
            if (sentflyer != 0)
                unopenedpercent = (100 * (sentflyer - openedflyer)) / sentflyer;
            lblUnopened.Text = (Convert.ToInt32(sentstrings1[0]) - Convert.ToInt32(openedstrings[0])) + "<br>" + unopenedpercent + "%";

            //Bounced
            string bounced = lblBounced.Text;
            string[] bouncedstrings = bounced.Split('<');
            int bouncedflyer = Convert.ToInt32(bouncedstrings[0]);
            BouncedTotal += bouncedflyer;

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
            Label lblEventimg = e.Row.FindControl("lblEventimg") as Label;
            string eventID = lnkEventName.CommandArgument;
            if (File.Exists(Server.MapPath("~") + "\\Upload\\Events\\" + ProfileID.ToString() + "\\" + eventID + ".jpg"))
                lblEventimg.Text = "<img src='" + RootPath + "/Upload/Events/" + ProfileID.ToString() + "/" + eventID + ".jpg' border='0' width='100' height='50'/>";
            else
                lblEventimg.Text = "";
            string strScript = "SelectDeSelectHeader(" + ((CheckBox)e.Row.Cells[1].FindControl("chkUpdate")).ClientID + ");";
            ((CheckBox)e.Row.Cells[1].FindControl("chkUpdate")).Attributes.Add("onclick", strScript);

            Label lblScheduledCount = e.Row.FindControl("TotalScheduleCount") as Label;
            TotalScheduleAndSentCount += Convert.ToInt32(lblScheduledCount.Text);
        }

        //Footer
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            CheckBox chkheader = (CheckBox)GrdbusinessEvents.HeaderRow.FindControl("chkSelectAll");
            if (chkheader.Checked == true)
            {
                TotalScheduleAndSentCount = Convert.ToInt32(hdnTotalEventsCount.Value);
            }

            Label lblsentTotal = e.Row.FindControl("lblsentTotal") as Label;
            if (SentTotal == 0)
                lblsentTotal.Text = "0<br>0%";
            else
            {
                if (TotalScheduleAndSentCount != 0)
                    lblsentTotal.Text = SentTotal + "<br>" + ((SentTotal * 100) / TotalScheduleAndSentCount) + "%";
            }

            Label lblOpenedTotal = e.Row.FindControl("lblOpenedTotal") as Label;
            if (OpenedTotal == 0)
            {
                lblOpenedTotal.Text = "0<br>0%";
            }
            else
            {
                if (SentTotal > 0)
                    lblOpenedTotal.Text = OpenedTotal + "<br>" + ((100 * OpenedTotal) / SentTotal) + "%";
            }

            Label lblOptOutTotal = e.Row.FindControl("lblOptOutTotal") as Label;
            if (OptOutTotal == 0)
            {
                lblOptOutTotal.Text = "0<br>0%";
            }
            else
            {
                if (OpenedTotal > 0)
                    lblOptOutTotal.Text = OptOutTotal + "<br>" + ((100 * OptOutTotal) / OpenedTotal) + "%";
            }

            Label lblUnOpendTotal = e.Row.FindControl("lblUnOpendTotal") as Label;
            if (OpenedTotal == 0)
                lblUnOpendTotal.Text = SentTotal + "<br>0%";
            else
            {
                if (SentTotal > 0)
                    lblUnOpendTotal.Text = (SentTotal - OpenedTotal) + "<br>" + (100 - ((100 * OpenedTotal) / SentTotal)) + "%";
            }
            Label lblBouncedTotal = e.Row.FindControl("lblBouncedTotal") as Label;
            if (BouncedTotal == 0)
                lblBouncedTotal.Text = "0<br>0%";
            else
                lblBouncedTotal.Text = BouncedTotal + "<br>" + ((100 * BouncedTotal) / SentTotal) + "%";
        }
    }

    protected void lblhistroy_Click(object sender, EventArgs e)
    {

        LinkButton lnkHis = sender as LinkButton;

        DtHis = objEvents.GetBusinessEventDetailsByBusinessEventID(Convert.ToInt32(lnkHis.CommandArgument));
        if (DtHis.Rows.Count > 0)
        {
            DataView dtcampview = new DataView(DtHis, "sent_Flag=1", "sent_Flag ASC", DataViewRowState.CurrentRows);
            DtHis = dtcampview.ToTable();
            grdviewsenthis.PageIndex = 0;
            grdviewsenthis.DataSource = dtcampview;
            grdviewsenthis.DataBind();

            DataTable dtEvents = new DataTable();
            dtEvents = objEvents.GetBusinessEventDetails(Convert.ToInt32(lnkHis.CommandArgument));
            if (dtEvents.Rows.Count > 0)
            {
                lblviewsentnewlettername.Text = dtEvents.Rows[0]["EventTitle"].ToString();
            }
            ModalPopupExtender3.Show();
        }
    }
    protected void grdviewsenthis_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // DtHis = (DataTable)Session["DtHis"];
        grdviewsenthis.PageIndex = e.NewPageIndex;
        grdviewsenthis.DataSource = DtHis;
        grdviewsenthis.DataBind();
        ModalPopupExtender3.Show();
    }
    protected void grdviewsenthis_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void lnkoptout_Click(object sender, EventArgs e)
    {
        LinkButton lnkOptOutID = sender as LinkButton;
        DtOptOuts = objEvents.GetOptOutCountForEventID(Convert.ToInt32(lnkOptOutID.CommandArgument));
        if (DtOptOuts.Rows.Count > 0)
        {
            grdoptouts.PageIndex = 0;
            grdoptouts.DataSource = DtOptOuts;
            grdoptouts.DataBind();

            ModalPopupExtender10.Show();
        }
    }
    protected void grdoptouts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdoptouts.PageIndex = e.NewPageIndex;
        grdoptouts.DataSource = DtOptOuts;
        grdoptouts.DataBind();
        ModalPopupExtender10.Show();
    }
    protected void lnkopen_Click(object sender, EventArgs e)
    {
        LinkButton LnkOpenID = sender as LinkButton;
        DtOptOuts = objUpdate.GetOpenedMailsForUpdateID(Convert.ToInt32(LnkOpenID.CommandArgument), "Event");
        if (DtOptOuts.Rows.Count > 0)
        {
            grdmailopen.PageIndex = 0;
            grdmailopen.DataSource = DtOptOuts;
            grdmailopen.DataBind();

            ModalPopupExtender4.Show();
        }
    }
    protected void grdmailopen_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdmailopen.PageIndex = e.NewPageIndex;
        grdmailopen.DataSource = DtOptOuts;
        grdmailopen.DataBind();
        ModalPopupExtender4.Show();
    }

    protected void lnkUpdateName_Click(object sender, EventArgs e)
    {
        string previewHtml = string.Empty;
        string unUsbscribeLink = string.Empty;
        LinkButton lnkdetails = sender as LinkButton;
        DataTable dtCalendarEventDetails = new DataTable();
        string dtEventStartDate = string.Empty;
        string dtEventEndDate = string.Empty;
        dtCalendarEventDetails = objEvents.GetCalendarEventDetails(Convert.ToInt32(lnkdetails.CommandArgument));
        if (dtCalendarEventDetails.Rows.Count > 0)
        {
            previewHtml = dtCalendarEventDetails.Rows[0]["EventDesc"].ToString();
            dtEventStartDate = Convert.ToDateTime(dtCalendarEventDetails.Rows[0]["EventStartDate"].ToString()).ToString("MMM dd yyyy hh:mm tt");

            if (Convert.ToDateTime(dtCalendarEventDetails.Rows[0]["EventStartDate"].ToString()) == Convert.ToDateTime(dtCalendarEventDetails.Rows[0]["EventEndDate"].ToString()))
                dtEventEndDate = Convert.ToDateTime(dtCalendarEventDetails.Rows[0]["EventStartDate"].ToString()).ToString("MMM dd yyyy") + " (All day)";
            else
            {
                string eventenddate = Convert.ToDateTime(dtCalendarEventDetails.Rows[0]["EventEndDate"].ToString()).ToString("MMM dd yyyy hh:mm tt");
                if (Convert.ToDateTime(dtCalendarEventDetails.Rows[0]["EventStartDate"].ToString()).Hour <= 0 && Convert.ToDateTime(dtCalendarEventDetails.Rows[0]["EventStartDate"].ToString()).Minute <= 0)
                    dtEventEndDate = Convert.ToDateTime(dtCalendarEventDetails.Rows[0]["EventStartDate"].ToString()).ToString("MMM dd yyyy");
                if (Convert.ToDateTime(dtCalendarEventDetails.Rows[0]["EventEndDate"].ToString()).Hour <= 0 && Convert.ToDateTime(dtCalendarEventDetails.Rows[0]["EventEndDate"].ToString()).Minute <= 0)
                    eventenddate = Convert.ToDateTime(dtCalendarEventDetails.Rows[0]["EventEndDate"].ToString()).ToString("MMM dd yyyy") + " (All day)";
                dtEventEndDate = dtEventEndDate + " to " + eventenddate;
            }

            unUsbscribeLink = UserProfileUnsubscribeLink();
            previewHtml = "<html><head></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='border: solid 2px #F4EBEB;'>  <tr><td colspan='2' style='padding:10px;'>" + dtEventEndDate + "</td></tr><tr><td colspan='2' style='padding:20px;'>" + previewHtml + "</td></tr><tr><td style='font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; padding:10px; border-top: solid 1px #F4EBEB;'>" + unUsbscribeLink + "</td><td align='right'style='font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; border-top: solid 1px #F4EBEB;'><a href='" + RootPath + "' target='_blank'><img src='" + RootPath + "/images/VerticalLogos/" + DomainName + "emailby.gif' border='0' /></a></td></tr></table></body></html>";
            lblPreviewHTML.Text = previewHtml;
            lblupdatename.Text = dtCalendarEventDetails.Rows[0]["EventTitle"].ToString();
            ModalPopupExtender2.Show();
        }
    }

    private string UserProfileUnsubscribeLink()
    {
        DataTable dtProfileAddress = new DataTable();
        dtProfileAddress = objBus.GetProfileDetailsByProfileID(ProfileID);
        string totalAddress = string.Empty;
        string unSubscribeLinkText = string.Empty;
        string profileName = string.Empty;
        if (dtProfileAddress.Rows.Count > 0)
        {
            if (dtProfileAddress.Rows[0]["Profile_name"].ToString() != "")
            {
                profileName = dtProfileAddress.Rows[0]["Profile_name"].ToString();
            }
            if (dtProfileAddress.Rows[0]["Profile_StreetAddress1"].ToString() != "")
            {
                totalAddress = dtProfileAddress.Rows[0]["Profile_StreetAddress1"].ToString();
            }
            if (dtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString() != "")
            {
                if (totalAddress != "")
                {
                    totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString();
                }
                else
                {
                    totalAddress = dtProfileAddress.Rows[0]["Profile_StreetAddress2"].ToString();
                }
            }
            if (dtProfileAddress.Rows[0]["Profile_City"].ToString() != "")
            {
                if (totalAddress != "")
                {
                    totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_City"].ToString();
                }
                else
                {
                    totalAddress = dtProfileAddress.Rows[0]["Profile_City"].ToString();
                }
            }
            if (dtProfileAddress.Rows[0]["Profile_State"].ToString() != "")
            {
                if (totalAddress != "")
                {
                    totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_State"].ToString();
                }
                else
                {
                    totalAddress = dtProfileAddress.Rows[0]["Profile_State"].ToString();
                }
            }
            if (dtProfileAddress.Rows[0]["Profile_Zipcode"].ToString() != "")
            {
                if (totalAddress != "")
                {
                    totalAddress = totalAddress + ", " + dtProfileAddress.Rows[0]["Profile_Zipcode"].ToString();
                }
                else
                {
                    totalAddress = dtProfileAddress.Rows[0]["Profile_Zipcode"].ToString();
                }
            }
        }
        unSubscribeLinkText = "This message was sent from " + profileName + " to &#60;recipient's email address&#62;. It was sent from &#60; sender's email address&#62;" + totalAddress + ". If you no longer wish to receive our events, <a href='" + RootPath + "/UnsubscribeEvent.aspx?ID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "' target='_blank'>click here</a> to unsubscribe.";
        return unSubscribeLinkText;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string url = "";
        if (hdnUrl.Value == "")
            url = Page.ResolveClientUrl("~/Business/MyAccount/ManageEventsCalendar.aspx");
        else
            url = hdnUrl.Value;
        Response.Redirect(url);
    }
    public string GetEventsCount(object id, object flag)
    {
        DataSet ds = new DataSet();
        ds = objEvents.GetEventsCounts(Convert.ToInt32(id), Convert.ToInt32(flag), ProfileID);
        int sentUpdates = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
        int updatesPercent = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
        hdnTotalEventsCount.Value = ds.Tables[0].Rows[0][2].ToString();
        string value = string.Empty;
        value = sentUpdates + "<br>" + updatesPercent + "%";
        return value;
    }

    public string GetSheduledCount(object id)
    {
        string value = string.Empty;
        value = objCommon.GetScheduledCount(Convert.ToInt32(id), 1);
        return value;
    }

    protected void gridEvents_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable ds = (DataTable)Session["ReportGrid"];
        ds = RemoveArchive(ds, Archive);
        Session["ReportGrid"] = ds;
        if (ds != null)
        {
            ds.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            GrdbusinessEvents.DataSource = ds;
            GrdbusinessEvents.DataBind();
        }
        if (btnExportSelected.Text == "Export")
        {
            GrdbusinessEvents.FooterRow.Visible = true;
            btnConsolidatedeport.Visible = false;
            GrdbusinessEvents.Columns[1].Visible = false;
            GrdbusinessEvents.FooterRow.BorderColor = Color.Orange;
            GrdbusinessEvents.FooterRow.BorderWidth = 2;
            GrdbusinessEvents.FooterRow.Cells[0].Font.Size = 15;
            GrdbusinessEvents.FooterRow.Height = 60;
            lblConsolidated.Visible = true;
            ScrollDown.Focus();
        }
    }

    private string GetSortDirection(string column)
    {
        string sortDirection = "ASC";
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
        return sortDirection;
    }

    protected void lnkEventName_Click(object sender, EventArgs e)
    {
        string previewHtml = string.Empty;
        string unUsbscribeLink = string.Empty;
        LinkButton lnkdetails = sender as LinkButton;
        DataTable dtCalendarEventDetails = new DataTable();
        string dtEventStartDate = string.Empty;
        string dtEventEndDate = string.Empty;


        dtCalendarEventDetails = objEvents.GetCalendarEventDetails(Convert.ToInt32(lnkdetails.CommandArgument));
        if (dtCalendarEventDetails.Rows.Count > 0)
        {
            previewHtml = dtCalendarEventDetails.Rows[0]["EventDesc"].ToString();

            dtEventStartDate = Convert.ToDateTime(dtCalendarEventDetails.Rows[0]["EventStartDate"].ToString()).ToString("MMM dd yyyy hh:mm tt");
            dtEventEndDate = Convert.ToDateTime(dtCalendarEventDetails.Rows[0]["EventEndDate"].ToString()).ToString("MMM dd yyyy hh:mm tt");
            unUsbscribeLink = UserProfileUnsubscribeLink();
            previewHtml = "<html><head></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='border: solid 2px #F4EBEB;'>  <tr><td colspan='2' style='padding:10px;'>" + dtEventStartDate + " to " + dtEventEndDate + "</td></tr><tr><td colspan='2' style='padding:20px;'>" + previewHtml + "</td></tr></table></body></html>";

            lblPreviewHTML.Text = previewHtml;

            lblupdatename.Text = dtCalendarEventDetails.Rows[0]["EventTitle"].ToString();
            ModalPopupExtender2.Show();
        }
    }
    protected void btnExportSelected_Click(object sender, EventArgs e)
    {
        StringWriter stw = new StringWriter();
        HtmlTextWriter htextw = new HtmlTextWriter(stw);
        foreach (DataControlField col in GrdbusinessEvents.Columns)
        {
            if (col.HeaderText == "Image")
            {
                int colPos = GrdbusinessEvents.Columns.IndexOf(col);
                GrdbusinessEvents.Columns[colPos].Visible = false;
            }
            if (col.HeaderText == "Select All")
            {
                int colPos = GrdbusinessEvents.Columns.IndexOf(col);
                GrdbusinessEvents.Columns[colPos].Visible = false;
            }
            if (col.HeaderText == "Title")
            {
                int colPos = GrdbusinessEvents.Columns.IndexOf(col);
                GrdbusinessEvents.Columns[colPos].Visible = false;
            }
            if (col.HeaderText == "Title1")
            {
                int colPos = GrdbusinessEvents.Columns.IndexOf(col);
                GrdbusinessEvents.Columns[colPos].Visible = true;
                GrdbusinessEvents.HeaderRow.Cells[colPos].Text = "Event Title";
            }
            if (col.HeaderText == "Sent")
            {
                int colPos = GrdbusinessEvents.Columns.IndexOf(col);
                GrdbusinessEvents.Columns[colPos].Visible = false;
            }
            if (col.HeaderText == "Sent1")
            {
                int colPos = GrdbusinessEvents.Columns.IndexOf(col);
                GrdbusinessEvents.Columns[colPos].Visible = true;
                GrdbusinessEvents.HeaderRow.Cells[colPos].Text = "Sent";
            }
            if (col.HeaderText == "Opened")
            {
                int colPos = GrdbusinessEvents.Columns.IndexOf(col);
                GrdbusinessEvents.Columns[colPos].Visible = false;
            }
            if (col.HeaderText == "Opened1")
            {
                int colPos = GrdbusinessEvents.Columns.IndexOf(col);
                GrdbusinessEvents.Columns[colPos].Visible = true;
                GrdbusinessEvents.HeaderRow.Cells[colPos].Text = "Opened";
            }
            if (col.HeaderText == "Opt Out")
            {
                int colPos = GrdbusinessEvents.Columns.IndexOf(col);
                GrdbusinessEvents.Columns[colPos].Visible = false;
            }
            if (col.HeaderText == "Opt Out1")
            {
                int colPos = GrdbusinessEvents.Columns.IndexOf(col);
                GrdbusinessEvents.Columns[colPos].Visible = true;
                GrdbusinessEvents.HeaderRow.Cells[colPos].Text = "Opt Out";
            }
            if (col.HeaderText == "Bounced Back")
            {
                int colPos = GrdbusinessEvents.Columns.IndexOf(col);
                GrdbusinessEvents.Columns[colPos].Visible = false;
            }
            if (col.HeaderText == "Bounced Back1")
            {
                int colPos = GrdbusinessEvents.Columns.IndexOf(col);
                GrdbusinessEvents.Columns[colPos].Visible = true;
                GrdbusinessEvents.HeaderRow.Cells[colPos].Text = "Bounced Back";
            }
            if (col.HeaderText == "Status")
            {
                int colPos = GrdbusinessEvents.Columns.IndexOf(col);
                GrdbusinessEvents.HeaderRow.Cells[colPos].Text = "Status";
            }
            if (col.HeaderText == "Start Date")
            {
                int colPos = GrdbusinessEvents.Columns.IndexOf(col);
                GrdbusinessEvents.HeaderRow.Cells[colPos].Text = "Start Date";
            }
        }
        for (int i = 0; i < GrdbusinessEvents.HeaderRow.Cells.Count; i++)
        {
            GrdbusinessEvents.HeaderRow.Cells[i].Style.Add("background-color", "#428AD7");
        }
        int removeColumns = 0;
        if (btnExportSelected.Text == "Export")
            GrdbusinessEvents.FooterRow.BorderWidth = 0;
        else
            removeColumns = 1;

        foreach (GridViewRow grdrow in GrdbusinessEvents.Rows)
        {
            if (removeColumns == 1)
            {
                if (((CheckBox)grdrow.FindControl("chkUpdate")).Checked == false)
                {
                    GrdbusinessEvents.Rows[grdrow.RowIndex].Visible = false;
                }
            }
            grdrow.FindControl("lnkBounced").Visible = false;
            grdrow.FindControl("lblBounced").Visible = true;
        }
        GrdbusinessEvents.GridLines = GridLines.Both;
        GrdbusinessEvents.RenderControl(htextw);
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename= EventsReport.xls");
        Response.ContentType = "application/vnd.ms-excel";
        Response.Write(stw.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    protected void btnConsolidatedeport_Click(object sender, EventArgs e)
    {

        CheckBox chkheader = (CheckBox)GrdbusinessEvents.HeaderRow.FindControl("chkSelectAll");
        if (chkheader.Checked == false)
        {
            DataTable dt = ((DataTable)Session["ReportGrid"]).Copy();
            foreach (GridViewRow grdrow in GrdbusinessEvents.Rows)
            {
                int k = Convert.ToInt32(((LinkButton)grdrow.FindControl("lnkEventName")).CommandArgument);
                DataRow[] dr = dt.Select("EventId=" + k);
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
            DataRow[] dRSelect;
            dRSelect = dt.Select("IsSelected='No'");
            DataTable dtupdated = dt.Clone();
            foreach (DataRow dr in dRSelect)
            {
                dtupdated.ImportRow(dr);
                dt.Rows.Remove(dr);
            }

            dt.AcceptChanges();
            GrdbusinessEvents.DataSource = dt;
            GrdbusinessEvents.DataBind();
            Session["ReportGrid"] = dt;
        }
        GrdbusinessEvents.FooterRow.Visible = true;
        btnConsolidatedeport.Visible = false;
        btnExportSelected.Text = "Export";
        GrdbusinessEvents.Columns[1].Visible = false;
        GrdbusinessEvents.FooterRow.BorderColor = Color.Orange;
        GrdbusinessEvents.FooterRow.Cells[0].Font.Size = 15;
        GrdbusinessEvents.FooterRow.BorderWidth = 2;
        GrdbusinessEvents.FooterRow.Height = 60;
        lblConsolidated.Visible = true;
        ScrollDown.Focus();//To scroll down the Panel
        if (GrdbusinessEvents.Rows.Count == 0)
        {
            btnExportSelected.Visible = false;
            btnPrint.Visible = false;
        }
        btnBack.Visible = false;
    }
    // **** Fox for IRH-90 20-12-2013 *** //
    protected void lnkBounced_Click(object sender, EventArgs e)
    {
        LinkButton lnKBouncedID = sender as LinkButton;
        DtOptOuts = objUpdate.GetBouncedEailsForUpdateID(Convert.ToInt32(lnKBouncedID.CommandArgument), "Event");
        Session["DtOptOuts"] = DtOptOuts;
        if (DtOptOuts.Rows.Count > 0)
        {
            grdBounced.PageIndex = 0;
            grdBounced.DataSource = DtOptOuts;
            grdBounced.DataBind();
            ModalPopupExtender1.Show();
        }
    }

    protected void grdBounced_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdBounced.PageIndex = e.NewPageIndex;
        grdBounced.DataSource = (DataTable)Session["DtOptOuts"];
        grdBounced.DataBind();
        ModalPopupExtender1.Show();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        FillDatalist();
    }
}