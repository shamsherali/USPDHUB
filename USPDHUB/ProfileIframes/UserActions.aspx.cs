using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using USPDHUBBLL;
using System.IO;
using DayPilot.Web.Ui.Events;
using DayPilot.Web.Ui.Events.Bubble;
public partial class ProfileIframes_UserActions : System.Web.UI.Page
{
    public string Hdnvalue = string.Empty;
    public int ProfileID = 0;
    public bool Isfree = false;
    public int PageReviewImg = 0;
    BusinessBLL busobj = new BusinessBLL();
    string imagepath = string.Empty;
    string templatename = string.Empty;
    public string RootPath = "";
    public string DomainName = "";
    CommonBLL objCommon = new CommonBLL();
    EventCalendarBLL objevent = new EventCalendarBLL();
    CalendarAddOnBLL objCalendarAddOn = new CalendarAddOnBLL();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["VerticalDomain"] != null)
            Page.Theme = Session["VerticalDomain"].ToString();
        else
            Page.Theme = "Template1";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        // *** Get Domain Name *** //
        DomainName = Session["VerticalDomain"].ToString();
        RootPath = Session["RootPath"].ToString();
        if (Request.QueryString["Svalue"] != null)
        {
            if (Request.QueryString["Svalue"].ToString() == "10")
            {
                pnleventcalendar.Visible = true;
                pnldaypilot.Visible = true;
            }
            if (Request.QueryString["PID"] != null)
            {
                ProfileID = Convert.ToInt32(Request.QueryString["PID"].ToString());
            }
            Displaylogo(ProfileID);
            imagepath = Page.ResolveClientUrl("~/App_Themes/images/" + Page.Theme);
            Session["hdnValue"] = Request.QueryString["Svalue"].ToString();
            DayPilotMonth1.DataSource = LoadEventcalendar(ProfileID);
            DayPilotNavigator1.DataSource = LoadEventcalendar(ProfileID);
            DataBind();
            string selecteddate = string.Empty;
            if (Session["selectedmonth"] != null)
            {
                if (Session["selectedmonth"].ToString() != "")
                {
                    selecteddate = Session["selectedmonth"].ToString();
                    selecteddate = Convert.ToDateTime(selecteddate).ToShortDateString();
                }
            }
            if (selecteddate == "")
            {
                selecteddate = DateTime.Now.ToShortDateString();
            }
            Bindevents(Getalleventsbyselectedmonth(ProfileID, selecteddate));
            if (!IsPostBack)
            {
                Session["selectedmonth"] = null;
                btnview.Text = "List View";
                btnview1.Text = "List View";
                pnllist.Visible = false;
                pnldaypilot.Visible = true;
            }
        }
    }
    protected void Displaylogo(int profileID)
    {
        DataTable dtprofile = new DataTable();
        dtprofile = busobj.GetProfileDetailsByProfileID(profileID);
        string businessname = string.Empty;
        string logourl = string.Empty;
        if (dtprofile.Rows.Count > 0)
        {
            if (dtprofile.Rows[0]["Profile_logo_path"].ToString() != "")
            {
                logourl = dtprofile.Rows[0]["Profile_logo_path"].ToString();
                if (logourl.Trim().Length > 3)
                {
                    string originalfilename = logourl;
                    string extension = System.IO.Path.GetExtension(Server.MapPath(originalfilename));

                    string junk = ".";
                    string[] ret = originalfilename.Split(junk.ToCharArray());
                    string thumbimg1 = ret[0];
                    thumbimg1 = thumbimg1 + "_thumb" + extension;
                    string url = Server.MapPath("~") + "\\Upload\\Logos\\" + profileID + "\\" + thumbimg1;
                    FileInfo obj = new FileInfo(url);

                    if (obj.Exists)
                    {
                        tdlogo.Visible = true;
                        logourl = RootPath + "/Upload/Logos/" + profileID + "/" + thumbimg1;
                    }
                    else
                    {
                        tdlogo.Visible = false;
                        logourl = RootPath + "/Upload/Logos/" + profileID + "/" + logourl;
                    }
                }
                else // No image
                {
                    tdlogo.Visible = false;
                    logourl = RootPath + "/images/blank.gif";
                }
            }
            else // no image... hide the logo 
            {
                tdlogo.Visible = false;
                logourl = RootPath + "/images/blank.gif";
            }
            businessname = dtprofile.Rows[0]["Profile_name"].ToString();
            imglogo.ImageUrl = logourl;
            lblbusinessname.Text = businessname;
        }
    }
    protected DataTable LoadEventcalendar(int profileID)
    {

        DataTable dtevent = new DataTable();
        if (Request.QueryString["CalId"] != null)
        {
            if (Session["CalendarAddOnID"] != null)
                dtevent = objCalendarAddOn.GetAllCalendarsByPreview(profileID, Convert.ToInt32(Session["CalendarAddOnID"]));
        }
        else
            dtevent = objevent.GetAllEventsByProfileId1(profileID);
        dtevent = RemovePrivate(dtevent);
        return dtevent;
    }
    private DataTable RemovePrivate(DataTable dt)
    {
        // *** Get Newsletter without Achrive *** //
        DataTable dtData = dt;
        string selectQuery = string.Empty;
        selectQuery = "IsPublished<>'True'";
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
    protected DataTable Getall3Monthsevents(int profileID)
    {
        DataTable dtevent = new DataTable();
        if (Request.QueryString["CalId"] != null)
        {
            if (Session["CalendarAddOnID"] != null)
                dtevent = objCalendarAddOn.GetAll3MontthsCalendarsByPreview(profileID, Convert.ToInt32(Session["CalendarAddOnID"]));
        }
        else
            dtevent = objevent.GetAll3MontthsEventsByProfileId(profileID);
        return dtevent;
    }
    protected DataTable Getalleventsbyselectedmonth(int profileID, string selecteddate)
    {

        DataTable dtevent = new DataTable();
        if (Request.QueryString["CalId"] != null)
        {
            if (Session["CalendarAddOnID"] != null)
                dtevent = objCalendarAddOn.GetAllCalendarsBySelectedMonth(profileID, selecteddate, Convert.ToInt32(Session["CalendarAddOnID"]));
        }
        else
            dtevent = objevent.GetAllEventsByProfileIdandSelectedMonth(profileID, selecteddate);
        return dtevent;
    }
    protected void DayPilotCalendar1_EventMenuClick(object sender, EventMenuClickEventArgs e)
    {
    }
    protected void DayPilotMonth1_EventMove(object sender, EventMoveEventArgs e)
    {
    }
    protected void DayPilotMonth1_EventResize(object sender, EventResizeEventArgs e)
    {
    }

    protected void DayPilotMonth1_TimeRangeSelected(object sender, TimeRangeSelectedEventArgs e)
    {
    }
    protected void DayPilotMonth1_BeforeEventRender(object sender, DayPilot.Web.Ui.Events.Month.BeforeEventRenderEventArgs e)
    {
        if (e.Value == "12")
        {
            e.ContextMenuClientName = "menu2";
        }
    }

    protected void DayPilotBubble1_RenderContent(object sender, RenderEventArgs e)
    {
        if (e is RenderEventBubbleEventArgs)
        {
            RenderEventBubbleEventArgs re = e as RenderEventBubbleEventArgs;
            DataTable dtdetails = new DataTable();
            if (Request.QueryString["CalId"] != null)
            {
                if (Session["CalendarAddOnID"] != null)
                    dtdetails = objCalendarAddOn.GetCalendarAddOnDetails(Convert.ToInt32(re.Value));
            }
            else
                dtdetails = objevent.GetCalendarEventDetails(Convert.ToInt32(re.Value));
            string desc = string.Empty;
            if (dtdetails.Rows.Count > 0)
            {
                desc = dtdetails.Rows[0]["EventDesc"].ToString();

            }

            re.InnerHTML = "<b>Event details</b><br />" + desc + "";
        }
    }

    protected void DayPilotNavigator1_VisibleRangeChanged(object sender, EventArgs e)
    {
        DayPilotNavigator1.DataSource = LoadEventcalendar(ProfileID);
        DayPilotNavigator1.DataBind();
    }
    protected void DayPilotMonth1_BeforeCellRender(object sender, DayPilot.Web.Ui.Events.Month.BeforeCellRenderEventArgs e)
    {
    }
    protected void DayPilotMonth1_EventClick(object sender, EventClickEventArgs e)
    {
        string eventid = e.Value;
        string url = RootPath + "/printevents.aspx?PFlag=1&EID=" + eventid;
        if (Request.QueryString["CalId"] != null)
        {
            if (Session["CalendarAddOnID"] != null)
                url = url + "&CalId=1";
        }
        OpenNewWindow(url);

    }
    protected void DayPilotMonth1_Command(object sender, DayPilot.Web.Ui.Events.CommandEventArgs e)
    {
        Session["selectedmonth"] = e.Data["start"].ToString();
        switch (e.Command)
        {
            case "navigate":
                DayPilotMonth1.StartDate = (DateTime)e.Data["start"];
                DayPilotMonth1.DataSource = LoadEventcalendar(ProfileID);
                DayPilotMonth1.DataBind();
                DayPilotMonth1.Update();
                break;
            case "filter":
                DayPilotMonth1.DataSource = LoadEventcalendar(ProfileID);
                DayPilotMonth1.DataBind();
                DayPilotMonth1.Update();
                break;
        }
    }

    public void OpenNewWindow(string url)
    {

        ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}','PrintWindow','width=700,height=424,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes');</script>", url));

    }

    #region Bind list view
    protected void Bindevents(DataTable dtevents)
    {
        Session["events"] = dtevents;
        grdevents.DataSource = dtevents;
        grdevents.DataBind();
    }
    protected void grdevents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdevents.PageIndex = e.NewPageIndex;
        pnldaypilot.Visible = false;
        grdevents.DataSource = (DataTable)Session["events"];
        grdevents.DataBind();

    }

    protected void grdevents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbleventdate = e.Row.FindControl("lbleventdate") as Label;
            Label lbleventtitle = e.Row.FindControl("lbleventtitle") as Label;
            Label lblviewdetails = e.Row.FindControl("lblviewdetails") as Label;
            Label lblstartdate = e.Row.FindControl("lblstartdate") as Label;
            Label lblenddate = e.Row.FindControl("lblenddate") as Label;
            string eventdate = objCommon.GetEventAdjustDate(Convert.ToDateTime(lblstartdate.Text), Convert.ToDateTime(lblenddate.Text));

            lbleventdate.Text = eventdate;
            string eventid = lblviewdetails.Text;
            string eventtitile = lbleventtitle.Text;
            string url = RootPath + "/printevents.aspx?PFlag=1&EID=" + eventid;
            if (Request.QueryString["CalId"] != null)
            {
                if (Session["CalendarAddOnID"] != null)
                    url = url + "&CalId=1";
            }
            lblviewdetails.Text = "<a href='#' onclick=javascript:openwindow('" + url + "') width='700px' height='424px' color='black' >View details</a>";
            lbleventtitle.Text = "<a href='#' onclick=javascript:openwindow('" + url + "') width='700px' height='424px'>" + eventtitile + "</a>";
        }
    }
    protected void btnview_Click(object sender, EventArgs e)
    {
        if (btnview.Text == "List View")
        {
            pnldaypilot.Visible = false;
            pnllist.Visible = true;
            btnview.Text = "Calendar View";
            btnview1.Text = "Calendar View";
        }
        else
        {
            pnldaypilot.Visible = true;
            pnllist.Visible = false;
            btnview.Text = "List View";
            btnview1.Text = "List View";
        }
    }
    protected void btnview1_Click(object sender, EventArgs e)
    {
        if (btnview1.Text == "List View")
        {
            pnldaypilot.Visible = false;
            pnllist.Visible = true;
            btnview1.Text = "Calendar View";
            btnview.Text = "Calendar View";
        }
        else
        {
            pnldaypilot.Visible = true;
            pnllist.Visible = false;
            btnview1.Text = "List View";
            btnview.Text = "List View";
        }
    }
    #endregion

}
