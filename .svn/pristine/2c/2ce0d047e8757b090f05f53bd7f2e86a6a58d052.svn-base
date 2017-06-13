using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ResellersDAL;
using System.Configuration;

namespace ResellersBLL
{
    public class UtilitiesBLL
    {
        public string SendOutEmail(string fromEmail, string toEmail, string subject, string message, string cCemail, string fromDisplayName, string domainName)
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
               
            }
            return "Failed";
        }
    }
}
