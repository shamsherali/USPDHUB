using System;
using System.Configuration;
using USPDHUBBLL;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web;

public partial class Business_AgencyListing : System.Web.UI.Page
{
    public string Email1 = string.Empty;
    public int ProfileID = 0;

    public string Address = string.Empty;
    public string ResellerInvID = string.Empty;
    public string AffiliateInvID = string.Empty;
    public string GeneralTabInvID = string.Empty;
    public int UserID = 0;
    public string PromoCode = string.Empty;
    public string RootPath = "";
    public string DomainName = "";
    CommonBLL objCommon = new CommonBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            objCommon.CreateDomainUrl(url);
        }
        // *** Get Domain Name *** //
        DomainName = Session["Vertical"].ToString();
        RootPath = Session["RootPath"].ToString();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsValid)
            {
                if (txtEmail.Text.Contains(".lv") == false)
                {
                    if (captcha.CheckCaptcha(txtcaptcha.Text.Trim()))
                    {
                        BusinessBLL busobj = new BusinessBLL();
                        int checkUser = busobj.CheckUserNameandPasswordForVaildUser(txtEmail.Text.Trim());
                        if (checkUser == 0)
                        {
                            string date = string.Empty;
                            if (txtStartDate.Text != "" && txtStartDate.Text != null)
                            {
                                if (ddlHours.SelectedIndex > 0 && ddlMints.SelectedIndex > 0)
                                    date = txtStartDate.Text + " " + ddlHours.SelectedValue + ":" + ddlMints.SelectedValue;
                            }
                            AgencyBLL agonj = new AgencyBLL();
                            int count = agonj.AddAgencyUser(txtAgencyname.Text, txtEmail.Text.Trim(), txtFirstName.Text.Trim(), txtphonenumber.Text, date, txtRemarks.Text.Trim(), 0, txtTitle.Text.Trim(), ddlHow.SelectedValue, DomainName);
                            if (count > 0)
                            {
                                SendregistrationEmail(txtEmail.Text);
                                SendAgencyInformation(date);
                                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings.Get("RootPath") + "/Business/OrderCompleted.aspx");
                            }
                        }
                        else
                        {
                            lblUserNameCheck.Text = "<font color='red'>This email address is already in use, please enter different email address.</font>";
                        }
                    }
                    else
                    {
                        //lblShowError.Text = "Enter Correct Security Code.";
                    }
                }
                else
                {
                    //lblUserNameCheck.Text = ".lv domains will be invalid to register with wowzzy.com";
                }
                Random ran = new Random();
                img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
            }
        }
        catch (Exception /*ex*/)
        {
            //lblShowError.Text = "Enter Correct Security Code.";
            Random ran = new Random();
            img1.ImageUrl = "~/GenerateCaptcha.aspx?Id=" + ran.Next(1, 9).ToString();
        }
    }


    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(ConfigurationManager.AppSettings.Get("OuterRootURL") + "/Default.aspx");
    }

    [WebMethod]
    public static string ServerSidefill(string emid)
    {
        BusinessBLL objWow = new BusinessBLL();
        string typevalue = "";
        if (emid.Length > 0)
        {
            Regex rEMail = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (!rEMail.IsMatch(emid))
            {
                typevalue = "3";
            }
            else
            {
                try
                {
                    int countUser;
                    countUser = objWow.CheckUserNameandPasswordForVaildUser(emid);
                    string s = "SELECT COUNT(SuperAdmin_ID) FROM T_Users WHERE Username='" + emid + "'";
                    SqlConnection sqlCon = USPDHUBDAL.ConnectionManager.Instance.GetSQLConnection();
                    SqlCommand sqlCmd = new SqlCommand(s, sqlCon);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar().ToString());
                    USPDHUBDAL.ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
                    if (count > 0)
                        typevalue = "4";
                    else
                    {
                        if (countUser == 0)
                        {
                            typevalue = "1";
                        }
                        else
                        {
                            typevalue = "2";
                        }
                    }
                }
                catch
                {
                    typevalue = "3";
                }

            }
        }
        return typevalue;

    }

    private void SendregistrationEmail(string email1)
    {

        string strfilepath = Server.MapPath("~") + "\\EmailContent" + Session["Vertical"] + "\\";
        StreamReader re = File.OpenText(strfilepath + "AgencyInquiry.txt");
        StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
        string msgbody = string.Empty;
        string content = string.Empty;
        string desclaimer = string.Empty;
        while ((desclaimer = reDeclaimer.ReadLine()) != null)
        {
            msgbody = msgbody + desclaimer + "\n";
        }
        desclaimer = "";
        string input = string.Empty;
        while ((input = re.ReadLine()) != null)
        {
            content = content + input + "<BR/>";
        }
        re.Close();
        msgbody = msgbody.Replace("#RootUrl#", ConfigurationManager.AppSettings.Get("SRootPath"));
        msgbody = msgbody.Replace("#msgBody#", content);
        msgbody = msgbody.Replace("#Link#", "<a href='" + ConfigurationManager.AppSettings.Get("SRootPath") + "/Login.aspx?UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()) + "' target=_new>Member Login</a>");
        msgbody = msgbody.Replace("#AddLink#", ConfigurationManager.AppSettings.Get("SRootPath") + "/Login.aspx?UID=" + EncryptDecrypt.DESEncrypt(UserID.ToString()));
        msgbody = msgbody.Replace("#Email#", email1);
        msgbody = msgbody.Replace("#Password#", string.Empty);
        reDeclaimer = File.OpenText(strfilepath + "AgencyListingCC.txt");
        string ccemail = string.Empty;
        while ((desclaimer = reDeclaimer.ReadLine()) != null)
        {
            ccemail = ccemail + desclaimer;
        }
        reDeclaimer.Close();
        USPDHUBBLL.UtilitiesBLL utlobj = new USPDHUBBLL.UtilitiesBLL();
        utlobj.SendWowzzyEmail(ConfigurationManager.AppSettings.Get("Emailinfo1"), email1, "Agency Details", msgbody, ccemail, "", DomainName);

    }
    private void SendAgencyInformation(string date)
    {
        string strfilepath = Server.MapPath("~") + "\\EmailContent" + Session["Vertical"] + "\\";
        StreamReader re = File.OpenText(strfilepath + "USPDHubInquiry.txt");
        StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
        string msgbody = string.Empty;
        string content = string.Empty;
        string desclaimer = string.Empty;
        while ((desclaimer = reDeclaimer.ReadLine()) != null)
        {
            msgbody = msgbody + desclaimer + "\n";
        }
        desclaimer = "";
        string input = string.Empty;
        while ((input = re.ReadLine()) != null)
        {
            content = content + input + "<BR/>";
        }
        re.Close();
        msgbody = msgbody.Replace("#RootUrl#", System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath"));
        msgbody = msgbody.Replace("#msgBody#", content);
        msgbody = msgbody.Replace("#AgencyName#", txtAgencyname.Text.Trim());
        msgbody = msgbody.Replace("#Name#", txtFirstName.Text.Trim());
        msgbody = msgbody.Replace("#Title#", txtTitle.Text.Trim());
        msgbody = msgbody.Replace("#HowIKnow#", ddlHow.SelectedValue);
        msgbody = msgbody.Replace("#Phone#", txtphonenumber.Text);
        msgbody = msgbody.Replace("#Email#", txtEmail.Text.Trim());
        msgbody = msgbody.Replace("#DateTime#", date);
        msgbody = msgbody.Replace("#Remarks#", txtRemarks.Text.Trim());
        reDeclaimer = File.OpenText(strfilepath + "AgencyInfoEmails.txt");
        string toEmails = string.Empty;
        while ((desclaimer = reDeclaimer.ReadLine()) != null)
        {
            toEmails = toEmails + desclaimer;
        }
        reDeclaimer.Close();
        USPDHUBBLL.UtilitiesBLL utlobj = new USPDHUBBLL.UtilitiesBLL();
        utlobj.SendWowzzyEmail(ConfigurationManager.AppSettings.Get("Emailinfo1"), toEmails, "New agency sign up", msgbody, "", "", DomainName);
    }
}
