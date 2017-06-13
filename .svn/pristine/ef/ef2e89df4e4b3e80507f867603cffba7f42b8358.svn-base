using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using SendSMSNotificationsBLL;
using System.Configuration;
using Twilio;
using System.Data;
using System.IO;

namespace SendSMSNotifications
{
    class TimerScheduler
    {
        Timer objTimer = null;
        double interval = 30000;
        SMSBLL objSMSBll = new SMSBLL();
      //  public string logpath = "C:\\inetpub\\wwwroot\\USPDHub\\SendSMSNotifications";
        public int LogID;
        public void Start()
        {
            SendSMS();
        }
       
        private void SendSMS()
        {
            try
            {    // Find your Account Sid and Auth Token at twilio.com/user/account
                string AccountSid = ConfigurationManager.AppSettings.Get("SMSAccountSid").ToString();
                string AuthToken = ConfigurationManager.AppSettings.Get("SMSAuthToken").ToString();
                string FromNumber = ConfigurationManager.AppSettings.Get("FromNumber").ToString();
                string CountryPhoneCode = ConfigurationManager.AppSettings.Get("CountryPhoneCode").ToString();


                var twilio = new TwilioRestClient(AccountSid, AuthToken);
                DataTable dtSMSNotifications = objSMSBll.GetSheduledSMSNotifications();
                if (dtSMSNotifications.Rows.Count > 0)
                {
                    for (int i = 0; i < dtSMSNotifications.Rows.Count; i++)
                    {
                        try
                        {
                            CountryPhoneCode = Convert.ToString(dtSMSNotifications.Rows[i]["Country_Code"]);
                            var message = twilio.SendMessage(FromNumber, (CountryPhoneCode + Convert.ToString(dtSMSNotifications.Rows[i]["Mobile"])), Convert.ToString(dtSMSNotifications.Rows[i]["Message"]), "");
                        }
                        catch (Exception ex)
                        {
                            ErrorHandling("ERROR - SendSMS2", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                               Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
                        }
                        objSMSBll.UpdateSMSSentStatus(Convert.ToInt32(dtSMSNotifications.Rows[i]["SMS_ID"]));
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandling("ERROR - SendSMS1", Convert.ToString(ex.Message), Convert.ToString(ex.StackTrace),
                   Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        public void ErrorHandling(string methodName, string message, string strackTrace, string innerException, string data)
        {

            objSMSBll.InsertExceptionDetails(methodName, Convert.ToString(message), "SendSMS", Convert.ToString(innerException),
                    Convert.ToString(data));


        }
    }
}
