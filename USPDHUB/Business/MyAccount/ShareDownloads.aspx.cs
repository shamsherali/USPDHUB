using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Configuration;
using USPDHUBBLL;
using System.Web.UI.HtmlControls;
using System.IO;


namespace USPDHUB.Business.MyAccount
{
    public partial class ShareDownloads : System.Web.UI.Page
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

                    string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
                    StreamReader re = File.OpenText(strfilepath + "ShareNotificationWizard.txt");
                    string msgbody = string.Empty;
                    string desclaimer = string.Empty;
                    while ((desclaimer = re.ReadLine()) != null)
                    {
                        msgbody = msgbody + desclaimer;
                    }
                    re.Close();
                    re.Dispose();
                    msgbody = msgbody.Replace("#SchoolName#", profilename);
                    msgbody = msgbody.Replace("#RootPath#", RootPath).Replace("<br/>", "\n");
                    txtmessage.Text = msgbody;
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ShareDownloads.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string toemail = txtTO.Text.Trim();
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
                toemail = toemail.Replace("\n", "");
                toemail = toemail.Replace("\r", "");
                toemail = toemail.Replace(" ", "");
                UtilitiesBLL utilobj = new UtilitiesBLL();
                string returnval = utilobj.SendWowzzyEmail(campaignEmailFrom, toemail, subject, body, "", hdnProfineName.Value, DomainName);
                lblmsg.Text = "Your email has been sent successfully.";
                txtSubject.Text = "";
                txtTO.Text = "";
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "ShareDownloads.aspx.cs", "btnsubmit_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
    }
}