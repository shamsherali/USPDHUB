using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using USPDHUBBLL;

public partial class ContactUser : System.Web.UI.Page
{
    public int UserID = 0;
    public int SchID = 0;
    public string EmailType = string.Empty;
    public string RootPath = "";
    public string DomainName = "";
    CommonBLL objCommon = new CommonBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                Session["VerticalDomain"] = objCommon.CreateDomainUrl(url);
            }
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
            if (Request.QueryString["ID"] != null)
            {
                if (Request.QueryString["ID"].ToString() != "")
                {
                    string ID = EncryptDecrypt.DESDecrypt(Request.QueryString["ID"].ToString());
                    UserID = Convert.ToInt32(ID);
                }
            }
            if (Request.QueryString["SID"] != null)
            {
                if (Request.QueryString["SID"].ToString() != "")
                {
                    string ID = EncryptDecrypt.DESDecrypt(Request.QueryString["SID"].ToString());
                    SchID = Convert.ToInt32(ID);
                }
            }
            if (Request.QueryString["ET"] != null)
            {
                if (Request.QueryString["ET"].ToString() != "")
                {
                    EmailType = Request.QueryString["ET"].ToString();
                }
            }
            txtphone.Attributes.Add("onblur", "CheckPhoneOrFax(this,'1');");
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
            objInBuiltData.ErrorHandling("ERROR", "ContactUser.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btnAddDetails_OnClick(object sender, EventArgs e)
    {
        try
        {
            if (UserID != 0 && SchID != 0 && EmailType != "")
            {
                Consumer ObjConsumer = new Consumer();
                objCommon.AddandUpdateEmaiContacts(txtfirstname.Text.Trim(), txtlastname.Text.Trim(), txtemail.Text.Trim(), txtaddress.Text.Trim(), txtphone.Text.Trim(), txtdescription.Text.Trim(), UserID, SchID, EmailType, 0);
                DataTable dtUserDetails = ObjConsumer.GetUserDetailsByID(UserID);
                string UserEmail = dtUserDetails.Rows[0]["Username"].ToString();
                string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
                StreamReader re = File.OpenText(strfilepath + "ContactUsNotification.txt");
                string msgbody = string.Empty;
                string ContactUsername = txtfirstname.Text;
                if (txtlastname.Text.Trim() != "")
                {
                    ContactUsername = ContactUsername + " " + txtlastname.Text;
                }
                StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
                string content = string.Empty;
                string desclaimer = string.Empty;
                while ((desclaimer = reDeclaimer.ReadLine()) != null)
                {
                    msgbody = msgbody + desclaimer;
                }
                string input = string.Empty;
                while ((input = re.ReadLine()) != null)
                {
                    content = content + input + "<BR>";
                }

                msgbody = msgbody.Replace("#RootUrl#", RootPath);
                msgbody = msgbody.Replace("#msgBody#", content);

                msgbody = msgbody.Replace("#Link#", "<a href='" + RootPath + "/Login.aspx?UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "' target=_new>Login</a>");
                msgbody = msgbody.Replace("#AddLink#", RootPath + "/Login.aspx?UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()));
                msgbody = msgbody.Replace("#Email#", dtUserDetails.Rows[0]["Username"].ToString());
                msgbody = msgbody.Replace("#Password#", dtUserDetails.Rows[0]["Password"].ToString());
                msgbody = msgbody.Replace("#Firstname#", ContactUsername);
                re.Close();
                re.Dispose();
                reDeclaimer.Close();
                reDeclaimer.Dispose();
                string ccemail = string.Empty;
                string returnval = string.Empty;
                UtilitiesBLL utlobj = new UtilitiesBLL();
                string FromEmailInfo = "";
                DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
                if (dtConfigsemails.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigsemails.Rows)
                    {
                        if (row[0].ToString() == "EmailInfo")
                            FromEmailInfo = row[1].ToString();
                    }
                }
                returnval = utlobj.SendWowzzyEmail(FromEmailInfo, UserEmail, "Inquiry Notification", msgbody, ccemail, "", DomainName);
                lblContacts.Text = "<font  size='3' style='color:green'><b>Your message has been submitted successfully.</b></font>";
                txtfirstname.Text = "";
                txtlastname.Text = "";
                txtemail.Text = "";
                txtaddress.Text = "";
                txtphone.Text = "";
                txtdescription.Text = "";
            }
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "ContactUser.aspx.cs", "btnAddDetails_OnClick", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }
    protected void btnCancel_OnClick(object sender, EventArgs e)
    {
        txtfirstname.Text = "";
        txtlastname.Text = "";
        txtemail.Text = "";
        txtaddress.Text = "";
        txtphone.Text = "";
        txtdescription.Text = "";
        string urlinfo = RootPath + "/Default.aspx";
        Response.Redirect(urlinfo);
    }
}
