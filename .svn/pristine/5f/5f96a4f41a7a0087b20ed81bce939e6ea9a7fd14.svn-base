using System;
using USPDHUBBLL;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Web;

namespace USPDHUB
{
    public partial class UnsubscribeCalendar : System.Web.UI.Page
    {
        public string DomainName = "";
        public int UserID = 0;
        public int CalendarId = 0;
        CommonBLL objCommon = new CommonBLL();
        CalendarAddOnBLL objCalendarAddOn = new CalendarAddOnBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    objCommon.CreateDomainUrl(url);
                }
                DomainName = Session["VerticalDomain"].ToString();
                if (Request.QueryString["ID"] != null)
                {
                    if (Request.QueryString["ID"].ToString() != "")
                    {
                        string id = EncryptDecrypt.DESDecrypt(Request.QueryString["ID"].ToString());
                        UserID = Convert.ToInt32(id);
                    }
                }
                if (Request.QueryString["SID"] != null)
                {
                    if (Request.QueryString["SID"].ToString() != "")
                    {
                        string id = EncryptDecrypt.DESDecrypt(Request.QueryString["SID"].ToString());
                        CalendarId = Convert.ToInt32(id);
                    }
                }
                // *** Adding page title and meta keys for page *** //
                DataTable dtConfigPageKeys = objCommon.GetVerticalConfigsByType(DomainName, "DashboardKeys");
                if (dtConfigPageKeys.Rows.Count > 0)
                {
                    HtmlMeta htmlMeta = new HtmlMeta();
                    foreach (DataRow row in dtConfigPageKeys.Rows)
                    {
                        if (row[0].ToString() == "Title")
                            this.Page.Title = row[1].ToString();
                        else if (row[0].ToString() == "author")
                            htmlMeta.Attributes.Add("author", row[1].ToString());
                        else if (row[0].ToString() == "description")
                            htmlMeta.Attributes.Add("description", row[1].ToString());
                        else if (row[0].ToString() == "keywords")
                            htmlMeta.Attributes.Add("keywords", row[1].ToString());
                    }
                    HtmlHead header = new HtmlHead();
                    header.Controls.Add(htmlMeta);
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "UnsubscribeCalendar.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void lnkUnsubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                int checkValue = 0;

                string emailAddress = string.Empty;
                emailAddress = txtusername.Text;
                checkValue = objCalendarAddOn.UnsubscribeCalendarEmail(CalendarId, UserID, emailAddress);
                if (checkValue > 0)
                {
                    lblmess.Text = "You have been successfully removed from this subscriber list.";

                }
                else
                {
                    lblmess.Text = "This email address is not in the subscriber list.";
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "UnsubscribeCalendar.aspx.cs", "lnkUnsubscribe_Click", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}