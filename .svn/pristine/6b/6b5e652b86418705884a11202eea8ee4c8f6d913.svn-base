using System;
using System.Linq;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB
{
    public partial class OnlineCalendar : System.Web.UI.Page
    {
        public int CalendarId = 0;
        CalendarAddOnBLL objCalendarAddOn = new CalendarAddOnBLL();
        CommonBLL objCommonBLL = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["TID"] != null && Request.QueryString["TID"] != "")
                {
                    string eid = Request.QueryString["TID"].ToString().Replace(" ", "+");
                    eid = eid.Replace("irhmalli", "=").Replace("irhPASS", "+");
                    CalendarId = Convert.ToInt32(EncryptDecrypt.DESDecrypt(eid));
                }

                if (!IsPostBack)
                {
                    if (CalendarId > 0)
                    {
                        DataTable dtCalendar = objCalendarAddOn.GetCalendarAddOnDetails(CalendarId);
                        if (dtCalendar.Rows.Count > 0)
                        {
                            DateTime startDate = DateTime.Parse(dtCalendar.Rows[0]["EventStartDate"].ToString());
                            DateTime endDate = DateTime.Parse(dtCalendar.Rows[0]["EventEndDate"].ToString());
                            string eventdate = startDate.ToString("MMM dd yyyy hh:mm tt");
                            string eventEndDate = endDate.ToString("MMM dd yyyy hh:mm tt");

                            if (startDate.Hour <= 0 && startDate.Minute <= 0)
                                eventdate = startDate.ToString("MMM dd yyyy");
                            if (endDate.Hour <= 0 && endDate.Minute <= 0)
                                eventEndDate = endDate.ToString("MMM dd yyyy");

                            lblstartdate.Text = eventdate;
                            lbleventEndDate.Text = eventEndDate;
                            lbleventName.Text = dtCalendar.Rows[0]["EventTitle"].ToString();

                            string htmlString = dtCalendar.Rows[0]["EventDesc"].ToString();
                            lblbulletin.Text = objCommonBLL.ReplaceShortURltoHtmlString(htmlString);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "OnlineCalendar.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

                lblbulletin.Text = ex.Message;
            }
        }
    }
}