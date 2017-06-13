using System;
using System.Data;
using System.Configuration;
using USPDHUBBLL;
using System.IO;
using System.Data.SqlClient;
using System.Web;

namespace USPDHUB.OP.inschoolhubin
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        public string Urlreferer = string.Empty;
        public string RootPath = "";
        public string DomainName = "";
        CommonBLL objCommon = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null)
                    Urlreferer = Request.UrlReferrer.ToString();
            }
            // *** Get Domain Name *** //
            if (Session["VerticalDomain"] == null)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                objCommon.CreateDomainUrl(url);
            }
            DomainName = Session["VerticalDomain"].ToString();
            RootPath = Session["RootPath"].ToString();
        }
        protected void Sent_Password(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            Consumer conObj = new Consumer();
            DataTable dtobj = conObj.GetForgotDetails(email, DomainName);
            if (dtobj.Rows.Count == 1)
            {
                SendForgotPasswordEmail(dtobj);
            }
            else
            {
                lblmsg.Text = "<font face=arial color=red size=2>The Login Name you have provided is incorrect, please try again.</font>";
            }
        }

        private void SendForgotPasswordEmail(DataTable dtobj)
        {

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
            string strfilepath = Server.MapPath("~") + "\\EmailContent" + DomainName + "\\";
            StreamReader re = File.OpenText(strfilepath + "ForgotPassword.txt");
            StreamReader reDeclaimer = File.OpenText(strfilepath + "CommonNotes.txt");
            string msgbody = string.Empty;
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
            utlobj.SendWowzzyEmail(emailInfo, useremail, "User Account Details", msgbody, ccemail, "", DomainName);

            lblmsg.Text = "<font face=arial color=green size=2><b>Your password has been emailed to " + useremail + ".</b><br/>NOTE: If you do not see the email delivered to your \"inbox\", please check your junk mail folder before contacting customer service. </font>";

            txtEmail.Text = "";
            txtRFirstname.Text = "";
            txtRlastname.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Urlreferer == "")
                Urlreferer = RootPath + "/OP/" + DomainName + "/login.aspx";
            Response.Redirect(Urlreferer);

        }
    }
}