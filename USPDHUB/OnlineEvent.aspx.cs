using System;
using System.Linq;
using System.Data;
using USPDHUBBLL;

namespace USPDHUB
{
    public partial class OnlineEvent : System.Web.UI.Page
    {
        public int EventId = 0;
        EventCalendarBLL adminobj = new EventCalendarBLL();
        CommonBLL objCommonBLL = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["TID"] != null && Request.QueryString["TID"] != "")
                {
                    string eid = Request.QueryString["TID"].ToString().Replace(" ", "+");
                    eid = eid.Replace("irhmalli", "=").Replace("irhPASS", "+");
                    EventId = Convert.ToInt32(EncryptDecrypt.DESDecrypt(eid));
                }

                if (!IsPostBack)
                {
                    if (EventId > 0)
                    {
                        DataTable dtBulletin = adminobj.GetCalendarEventDetails(EventId);
                        if (dtBulletin.Rows.Count > 0)
                        {
                            DateTime startDate = DateTime.Parse(dtBulletin.Rows[0]["EventStartDate"].ToString());
                            DateTime endDate = DateTime.Parse(dtBulletin.Rows[0]["EventEndDate"].ToString());
                            string eventdate = startDate.ToString("MMM dd yyyy hh:mm tt");
                            string eventEndDate = endDate.ToString("MMM dd yyyy hh:mm tt");

                            if (startDate.Hour <= 0 && startDate.Minute <= 0)
                                eventdate = startDate.ToString("MMM dd yyyy");
                            if (endDate.Hour <= 0 && endDate.Minute <= 0)
                                eventEndDate = endDate.ToString("MMM dd yyyy");

                            lblstartdate.Text = eventdate;
                            lbleventEndDate.Text = eventEndDate;
                            lbleventName.Text = dtBulletin.Rows[0]["EventTitle"].ToString();

                            string htmlString= dtBulletin.Rows[0]["EventDesc"].ToString();
                            lblbulletin.Text = objCommonBLL.ReplaceShortURltoHtmlString(htmlString);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "OnlineEvent.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

                lblbulletin.Text = ex.Message;
            }
        }
    }
}