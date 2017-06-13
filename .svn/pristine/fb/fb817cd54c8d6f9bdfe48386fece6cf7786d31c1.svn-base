using System;
using System.Data;
using System.Configuration;
using USPDHUBBLL;
using System.IO;
using System.Web;

namespace USPDHUB
{
    public partial class printevents : System.Web.UI.Page
    {
        EventCalendarBLL objevent = new EventCalendarBLL();
        CalendarAddOnBLL objCalendarAddOn = new CalendarAddOnBLL();
        CommonBLL objCommon = new CommonBLL();
        public int ProfileID = 0;
        BusinessBLL busobj = new BusinessBLL();
        string eventid = string.Empty;
        DataTable dtdetails = new DataTable();
        string templatename = string.Empty;
        protected bool logoflag = false;
        public string RootPath = "";
        public string DomainName = "";
        public string CalendarAddonHas = "";
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // *** Get Domain Name *** //
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            DomainName = objCommon.CreateDomainUrl(url);
            RootPath = Session["RootPath"].ToString();
            try
            {
                lblmessage.Text = "";

                if (Request.QueryString["CalId"] != null)
                    CalendarAddonHas = "&CalId=1";
                if (Request.QueryString["EID"] != null)
                {
                    if (Request.QueryString["EID"].ToString() != "")
                    {
                        if (Request.QueryString["PFlag"] != null)
                        {
                            if (Request.QueryString["PFlag"].ToString() != "")
                            {
                                eventid = Request.QueryString["EID"].ToString().Replace(" ", "+");
                                eventid = eventid.Replace("irhmalli", "=").Replace("irhPASS", "+");
                            }
                            else
                            {
                                eventid = Request.QueryString["EID"].ToString().Replace(" ", "+");
                                eventid = eventid.Replace("irhmalli", "=").Replace("irhPASS", "+");
                                int length = eventid.Length;
                                if (eventid[length - 1] != '=')
                                {
                                    eventid += '=';
                                    Response.Redirect(Page.ResolveClientUrl("~/printevents.aspx?EID=" + eventid + CalendarAddonHas));
                                }
                                eventid = EncryptDecrypt.DESDecrypt(eventid);
                            }
                        }
                        else
                        {
                            eventid = Request.QueryString["EID"].ToString().Replace(" ", "+");
                            eventid = eventid.Replace("irhmalli", "=").Replace("irhPASS", "+");
                            int length = eventid.Length;
                            if (eventid[length - 1] != '=')
                            {
                                eventid += '=';
                                Response.Redirect(Page.ResolveClientUrl("~/printevents.aspx?EID=" + eventid + CalendarAddonHas));
                            }
                            eventid = EncryptDecrypt.DESDecrypt(eventid);
                        }
                    }
                }
                int eventID = 0;
                eventID = Convert.ToInt32(eventid);
                if (CalendarAddonHas != "")
                    dtdetails = objCalendarAddOn.GetCalendarAddOnDetails(eventID);
                else
                    dtdetails = objevent.GetCalendarEventDetails(eventID);
                if (dtdetails.Rows.Count > 0)
                {
                    string profileid = dtdetails.Rows[0]["ProfileId"].ToString();
                    ProfileID = Convert.ToInt32(profileid);
                }
                DataTable dtprofiledetails1 = new DataTable();
                dtprofiledetails1 = busobj.GetProfileDetailsByProfileID(ProfileID);
                if (dtprofiledetails1.Rows.Count > 0)
                {
                    if (dtprofiledetails1.Rows[0]["Templatename"].ToString() != "")
                    {
                        templatename = dtprofiledetails1.Rows[0]["Templatename"].ToString();
                    }
                    else
                    {
                        templatename = "Template1";
                    }
                    Session["tempname"] = templatename;

                }
                Page.Theme = templatename;
                tbltitle.Visible = true;
                tbldetails.Visible = true;
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
                tbltitle.Visible = false;
                tbldetails.Visible = false;

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "printevents.aspx.cs", "Page_PreInit", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblmessage.Text = "";
                if (Request.QueryString["CalId"] != null)
                    CalendarAddonHas = "&CalId=1";
                if (Request.QueryString["EID"] != null)
                {
                    if (Request.QueryString["EID"].ToString() != "")
                    {
                        if (Request.QueryString["PFlag"] != null)
                        {
                            if (Request.QueryString["PFlag"].ToString() != "")
                            {
                                eventid = Request.QueryString["EID"].ToString().Replace(" ", "+");
                            }
                            else
                            {
                                eventid = Request.QueryString["EID"].ToString();
                                eventid = eventid.Replace("irhmalli", "=").Replace("irhPASS", "+");
                                int length = eventid.Length;
                                if (eventid[length - 1] != '=')
                                {
                                    eventid += '=';
                                    Response.Redirect(Page.ResolveClientUrl("~/printevents.aspx?EID=" + eventid + CalendarAddonHas));
                                }
                                eventid = EncryptDecrypt.DESDecrypt(eventid);
                            }
                        }
                        else
                        {
                            eventid = Request.QueryString["EID"].ToString();
                            eventid = eventid.Replace("irhmalli", "=").Replace("irhPASS", "+");
                            int length = eventid.Length;
                            if (eventid[length - 1] != '=')
                            {
                                eventid += '=';
                                Response.Redirect(Page.ResolveClientUrl("~/printevents.aspx?EID=" + eventid + CalendarAddonHas));
                            }
                            eventid = EncryptDecrypt.DESDecrypt(eventid);
                        }

                    }
                }
                DataTable dtdetails = new DataTable();
                if (CalendarAddonHas != "")
                    dtdetails = objCalendarAddOn.GetCalendarAddOnDetails(int.Parse(eventid));
                else
                    dtdetails = objevent.GetCalendarEventDetails(int.Parse(eventid));
                if (dtdetails.Rows.Count > 0)
                {
                    string profileid = string.Empty;
                    lbltitle.Text = dtdetails.Rows[0]["EventTitle"].ToString();
                    string htmlString = dtdetails.Rows[0]["EventDesc"].ToString();
                    lbldesc.Text = objCommon.ReplaceShortURltoHtmlString(htmlString);
                    profileid = dtdetails.Rows[0]["ProfileId"].ToString();
                    ProfileID = Convert.ToInt32(profileid);
                    string eventdate = string.Empty;
                    eventdate = Convert.ToDateTime(dtdetails.Rows[0]["EventStartDate"].ToString()).ToString("MMM dd yyyy hh:mm tt");
                    string eventenddate = Convert.ToDateTime(dtdetails.Rows[0]["EventEndDate"].ToString()).ToString("MMM dd yyyy hh:mm tt");
                    if (eventdate == eventenddate)
                        eventdate = Convert.ToDateTime(dtdetails.Rows[0]["EventStartDate"].ToString()).ToString("MMM dd yyyy") + " (All day)";
                    else
                    {
                        if (Convert.ToDateTime(dtdetails.Rows[0]["EventStartDate"].ToString()).Hour <= 0 && Convert.ToDateTime(dtdetails.Rows[0]["EventStartDate"].ToString()).Minute <= 0)
                            eventdate = Convert.ToDateTime(dtdetails.Rows[0]["EventStartDate"].ToString()).ToString("MMM dd yyyy");
                        if (Convert.ToDateTime(dtdetails.Rows[0]["EventEndDate"].ToString()).Hour <= 0 && Convert.ToDateTime(dtdetails.Rows[0]["EventEndDate"].ToString()).Minute <= 0)
                            eventenddate = Convert.ToDateTime(dtdetails.Rows[0]["EventEndDate"].ToString()).ToString("MMM dd yyyy") + " (All day)";
                        eventdate = eventdate + " to " + eventenddate;
                    }
                    lblSevntdate.Text = eventdate;

                    DataTable dtprofile = new DataTable();
                    dtprofile = busobj.GetProfileDetailsByProfileID(int.Parse(profileid));
                    string businessname = string.Empty;
                    string logourl = string.Empty;
                    if (dtprofile.Rows.Count > 0)
                    {
                        bool IsShortLogo = Convert.ToBoolean(dtprofile.Rows[0]["IsShortLogo"]);

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
                                string url = Server.MapPath("~") + "\\Upload\\Logos\\" + ProfileID + "\\" + thumbimg1;
                                FileInfo obj = new FileInfo(url);

                                if (obj.Exists)
                                {
                                    logoflag = true;
                                    logourl = RootPath + "/Upload/Logos/" + ProfileID + "/" + thumbimg1;
                                }
                                else
                                {
                                    logourl = RootPath + "/Upload/Logos/" + ProfileID + "/" + logourl;
                                }
                            }
                            else // No image
                            {
                                logourl = RootPath + "/images/blank.gif";
                            }
                        }
                        else // no image... hide the logo 
                        {
                            logourl = RootPath + "/images/blank.gif";
                        }
                        businessname = dtprofile.Rows[0]["Profile_name"].ToString();
                        imglogo.ImageUrl = logourl + "?id=" + Guid.NewGuid();

                        if (IsShortLogo)
                        {
                            lblbusinesssname.Visible = true;
                            lblbusinesssname.Text = businessname;
                        }
                        else
                        {
                            lblbusinesssname.Visible = false;
                        }
                    }
                }
                tbltitle.Visible = true;
                tbldetails.Visible = true;
                if (Request.QueryString["printflag"] != null)
                {
                    if (Request.QueryString["printflag"].ToString() == "1")
                    {
                        imgbtnprint.Visible = false;
                    }
                }
                else
                {
                    imgbtnprint.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
                tbltitle.Visible = false;
                tbldetails.Visible = false;

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "printevents.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
    }
}