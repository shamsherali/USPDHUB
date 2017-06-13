using System;
using System.Data;
using UserFormsDAL;
using System.Configuration;


namespace UserFormsBLL
{
    public class UtilitiesBLL
    {
        public DataTable GetAllShortStatesByCountry(string countyname)
        {
            return UserFormsDAL.Utilities.GetAllShortStatesByCountry(countyname);
        }
        public UtilitiesBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public enum RoleTypes
        {
            Consumer = 1, Business, Admin, AdminStaff, Advertiser, Developer
        }
        public enum Statuses
        {
            Active, InActive, Suspend, Hold
        }

        public string SendWowzzyEmail(string fromEmail, string toEmail, string subject, string message, string cCemail, string fromDisplayName, string domainName)
        {
            try
            {
                System.Net.Mail.SmtpClient oSmtlClient = new System.Net.Mail.SmtpClient();
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                // *** Get SMTP server credentials *** //
                DataTable dtConfigs = CommonDAL.GetVerticalConfigsByType(domainName, "SMTPServer");
                string hostcr = "";
                if (dtConfigs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtConfigs.Rows)
                    {
                        if (row[0].ToString() == "SmtpServerName")
                            oSmtlClient.Host = row[1].ToString();
                        else if (row[0].ToString() == "SmtpServerCr")
                            hostcr = EncryptDecrypt.DESDecrypt(row[1].ToString());
                    }
                }
                
                

                string[] strto = toEmail.Split(',');
                for (int i = 0; i < strto.Length; i++)
                {
                    mailMessage.To.Add(new System.Net.Mail.MailAddress(strto[i].Trim()));
                }
                if (cCemail != "")
                {
                    string[] ccemails = cCemail.Split(',');
                    for (int i = 0; i < ccemails.Length; i++)
                    {
                        mailMessage.CC.Add(new System.Net.Mail.MailAddress(ccemails[i].Trim()));
                    }
                } 
                 
                /*** For Sendgrid SMTP Server Port  July 21 2016 Azure Deployement ***/
                string sendgridSMTPServer_Username = Convert.ToString(ConfigurationManager.AppSettings.Get("SendgridSMTPServer_Username"));
                oSmtlClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("SendgridSMTPServer_Port"));
                oSmtlClient.Credentials = new System.Net.NetworkCredential(sendgridSMTPServer_Username, hostcr);
                mailMessage.From = new System.Net.Mail.MailAddress(fromEmail, fromDisplayName);
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = System.Net.Mail.MailPriority.Normal;
                mailMessage.Subject = subject;
                oSmtlClient.Send(mailMessage);
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objError = new InBuiltDataBLL();
                objError.ErrorHandling("ERROR", "SendingEmails.aspx.cs", "btnSave_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                return ex.Message.ToString();
            }
        }
    }
}
