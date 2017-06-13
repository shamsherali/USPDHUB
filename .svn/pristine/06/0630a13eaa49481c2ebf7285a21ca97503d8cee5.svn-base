using System;
using System.Data;
using System.Configuration;
using USPDHUBBLL;
using System.IO;
using System.Data.SqlClient;

public partial class ForgotPassword : BaseWeb
{
    public string Urlreferer = string.Empty;
    public string RootPath = "";
    CommonBLL objCommon = new CommonBLL();
    public string DomainName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.UrlReferrer != null)
                Urlreferer = Request.UrlReferrer.ToString();
        }
        RootPath = Page.ResolveClientUrl("~");
    }
    protected void Sent_Password(object sender, EventArgs e)
    {
        try{

        string email = txtEmail.Text;

        Consumer conObj = new Consumer();
        DataTable dtobj = conObj.ValidateUserByDetails(email);
        if (dtobj.Rows.Count == 1)
        {
            SendForgotPasswordEmail(dtobj);
        }
        else
        {
            string s = "SELECT User_ID,Firstname,Lastname,Username,Password FROM T_Users WHERE Username='" + email + "' and Active_flag=1";   //Added by Venkat....
            SqlConnection sqlCon = USPDHUBDAL.ConnectionManager.Instance.GetSQLConnection();
            SqlCommand sqlCmd = new SqlCommand(s, sqlCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            DataTable ds = new DataTable();
            da.Fill(ds);
            USPDHUBDAL.ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            if (ds.Rows.Count > 0)
                SendForgotPasswordEmail(ds);
            else
                lblmsg.Text = "<font face=arial color=red size=2>The Login Name you have provided is incorrect, please try again.</font>";
        }
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "ForgotPassword.aspx.cs", "Sent_Password", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    private void SendForgotPasswordEmail(DataTable dtobj)
    {
        try{

        string email1 = string.Empty;
        string passcode = string.Empty;
        string name = string.Empty;
        string useremail = string.Empty;
        if (dtobj.Rows.Count > 0)
        {
            email1 = dtobj.Rows[0]["Username"].ToString();
            useremail = dtobj.Rows[0]["Username"].ToString();   //Added by Venkat....
            passcode = EncryptDecrypt.DESDecrypt(dtobj.Rows[0]["Password"].ToString());
            name = dtobj.Rows[0]["Firstname"].ToString() + " " + dtobj.Rows[0]["Lastname"].ToString();
        }
        if(Session["Vertical"]==null)
            Response.Redirect(Page.ResolveClientUrl("~/Default"));

        string strfilepath = Server.MapPath("~") + "\\EmailContent" + Session["Vertical"].ToString() + "\\";
        StreamReader re = File.OpenText(strfilepath + "ForgotPassword.txt");
        StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
        string msgbody = string.Empty;
        string content = string.Empty;
        string desclaimer = string.Empty;
        while ((desclaimer = reDeclaimer.ReadLine()) != null)
        {
            msgbody = msgbody + desclaimer + "\n";
        }
        string input = string.Empty;
        while ((input = re.ReadLine()) != null)
        {
            content = content + input + "<BR>";
        }
        msgbody = msgbody.Replace("#RootUrl#", RootPath);
        msgbody = msgbody.Replace("#msgBody#", content);
        msgbody = msgbody.Replace("#Name#", name);
        msgbody = msgbody.Replace("#Username#", email1);
        msgbody = msgbody.Replace("#Password#", passcode);
        re.Close();
        re.Dispose();
        reDeclaimer.Close();
        reDeclaimer.Dispose();
        string ccemail = string.Empty;
        UtilitiesBLL utlobj = new UtilitiesBLL();
        string emailInfo = "";
        DataTable dtConfigsemails = objCommon.GetVerticalConfigsByType(DomainName, "EmailAccounts");
        if (dtConfigsemails.Rows.Count > 0)
        {
            foreach (DataRow row in dtConfigsemails.Rows)
            {
                if (row[0].ToString() == "EmailInfo")
                    emailInfo = row[1].ToString();
            }
        }
        utlobj.SendWowzzyEmail(emailInfo, useremail, "User Account Details", msgbody, ccemail, "", Session["Vertical"].ToString());

        lblmsg.Text = "<font face=arial color=green size=2><b>Your password has been emailed to " + useremail + ".</b><br/>NOTE: If you do not see the email delivered to your \"inbox\", please check your junk mail folder before contacting customer service. </font>";

        txtEmail.Text = "";
        txtRFirstname.Text = "";
        txtRlastname.Text = "";
        }
        catch (Exception ex)
        {
            InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
            /*** Error Log ***/
            objInBuiltData.ErrorHandling("ERROR", "ForgotPassword.aspx.cs", "SendForgotPasswordEmail", ex.Message, Convert.ToString(ex.StackTrace),
                Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Urlreferer == "")
            Urlreferer = RootPath + "/login.aspx";
        Response.Redirect(Urlreferer);

    }
}
