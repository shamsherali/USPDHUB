using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Configuration;
using USPDHUBBLL;
using System.Web.UI.HtmlControls;

public partial class Business_MyAccount_ShareEmail : System.Web.UI.Page
{
    public string Message = string.Empty;
    public int UserID = 0;
    public int ProfileID = 0;
    string profilename = string.Empty;
    string eventid = string.Empty;
    string calendarId = string.Empty;
    string newsletterID = string.Empty;
    string busUpdateID = string.Empty;
    string couponID = string.Empty;
    string bulletinID = string.Empty;
    string customID = string.Empty;
    BusinessBLL busobj = new BusinessBLL();
    CommonBLL objCommon = new CommonBLL();
    InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
    public string RootPath = "";
    public string DomainName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DomainName = objCommon.CreateDomainUrl(HttpContext.Current.Request.Url.AbsoluteUri);
            RootPath = Session["RootPath"].ToString();
            lblmsg.Text = "";
            if (Session["userid"] != null)
            {
                UserID = Convert.ToInt32(Session["UserID"]);
            }
            if (Session["ProfileID"] != null)
                ProfileID = Convert.ToInt32(Session["ProfileID"]);


            if (Request.QueryString["EC"] != null) // Event Calendar
            {
                if (Request.QueryString["EC"].ToString() != "")
                {
                    eventid = Request.QueryString["EC"].ToString().Replace(" ", "+");
                }
            }
            if (Request.QueryString["CA"] != null) // Event Calendar
            {
                if (Request.QueryString["CA"].ToString() != "")
                {
                    calendarId = Request.QueryString["CA"].ToString().Replace(" ", "+");
                }
            }
            if (Request.QueryString["BU"] != null) // Business Updates
            {
                if (Request.QueryString["BU"].ToString() != "")
                {
                    busUpdateID = Request.QueryString["BU"].ToString().Replace(" ", "+");
                }
            }
            if (Request.QueryString["BL"] != null) // Bulletins
            {
                if (Request.QueryString["BL"].ToString() != "")
                {
                    bulletinID = Request.QueryString["BL"].ToString().Replace(" ", "+");
                }
            }
            if (Request.QueryString["CM"] != null) // Bulletins
            {
                if (Request.QueryString["CM"].ToString() != "")
                {
                    customID = Request.QueryString["CM"].ToString().Replace(" ", "+");
                }
            }
            if (!IsPostBack)
            {
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
                if (UserID != 0)
                {
                    DataTable dtuser = new DataTable();
                    dtuser = busobj.GetUserDetailsByUserID(UserID);
                    if (dtuser.Rows.Count > 0)
                    {
                        txtfrom.Text = dtuser.Rows[0]["Username"].ToString().Trim();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["Email"]))
                    {
                        txtfrom.Text = EncryptDecrypt.DESDecrypt(Request.QueryString["Email"].ToString());
                    }
                }
                DataTable dtprofile = new DataTable();
                dtprofile = busobj.GetProfileDetailsByProfileID(ProfileID);
                if (dtprofile.Rows.Count > 0)
                {
                    profilename = dtprofile.Rows[0]["Profile_name"].ToString();
                    hdnProfineName.Value = profilename;
                }
                string bodymessage = string.Empty;
                bodymessage = bodymessage + "Site Name: " + profilename;

                string url = RootPath;
                if (eventid.Length > 0)
                {
                    //bodymessage = bodymessage + "\n\nClick the link below to view the Event.\n";
                    url = url + "/printevents.aspx?EID=" + eventid;
                }
                if (calendarId.Length > 0)
                {
                    //bodymessage = bodymessage + "\n\nClick the link below to view the Event.\n";
                    url = url + "/printevents.aspx?CalId=1&EID=" + eventid;
                }
                if (busUpdateID.Length > 0)
                {
                    //bodymessage = bodymessage + "\n\nClick the link below to view the Update.\n";
                    url = url + "/OnlineUpdate.aspx?BID=" + busUpdateID;
                }
                if (bulletinID.Length > 0)
                {
                    //bodymessage = bodymessage + "\n\nClick the link below to view the Bulletin.\n";
                    url = url + "/OnlineBulletin.aspx?BLID=" + bulletinID;
                }
                if (customID.Length > 0)
                {
                    //bodymessage = bodymessage + "\n\nClick the link below to view the Bulletin.\n";
                    url = url + "/OnlineItem.aspx?CMID=" + customID;
                }
                bodymessage = bodymessage + "\n\nClick the link below to view this email.\n";
                bodymessage = bodymessage + "\n" + url + "\n\nIf the above link does not work, simply copy and paste the address into your browser. ";
                txtmessage.Text = bodymessage;

            }
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ShareEmail.aspx.cs", "Page_Load", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        //Captcha Code..!

        //string captcha = string.Empty;
        //if (Session["ImageString"] != null)
        //{
        //    if (Session["ImageString"].ToString() != "")
        //    {
        //        captcha = Session["ImageString"].ToString();
        //    }
        //}
        //string captchtxt = txtcaptcha.Text.Trim();
        //if (captcha == captchtxt)
        //{
        try
        {
            string toemail = txtTO.Text.Trim();
            string cC = txtCC.Text.Trim();
            string subject = txtSubject.Text.Trim();
            string body = txtmessage.Text.Trim();
            body = body.Replace("\n", "<br/>");
            string campaignEmailFrom = "";
            DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
            if (dtConfigsemails.Rows.Count > 0)
            {
                foreach (DataRow row in dtConfigsemails.Rows)
                {
                    if (row[0].ToString() == "EmailFrom")
                        campaignEmailFrom = row[1].ToString();
                }
            }
            UtilitiesBLL utilobj = new UtilitiesBLL();
            string returnval = utilobj.SendWowzzyEmail(campaignEmailFrom, toemail, subject, body, cC, hdnProfineName.Value, DomainName);
            if (returnval == "SUCCESS")
            {
                lblmsg.Text = "Your email has been sent successfully.";
                txtCC.Text = "";
                txtSubject.Text = "";
                txtTO.Text = "";
            }
            else
            {
                lblmsg.Text = "Sorry, we are unable to process your request. Please try again. ";
            }
            //}
            //else
            //{
            //    lblmsg.Text = "<font color='red' size=2>Enter correct security code.</font>";
            //}
            //txtcaptcha.Text = "";
            //Random ran = new Random();
            //img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
        }
        catch (Exception ex)
        {
            //Error 
            objInBuiltData.ErrorHandling("ERROR", "ShareEmail.aspx.cs", "btnsubmit_Click", ex.Message,
            Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
}