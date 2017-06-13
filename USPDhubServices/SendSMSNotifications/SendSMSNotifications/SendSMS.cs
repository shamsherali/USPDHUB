using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Configuration;
using Twilio;

namespace SendSMSNotifications
{
    public partial class SendSMS : ServiceBase
    {
    
    
        public SendSMS()
        {
            InitializeComponent();
            InitializeScheduler();

            //_timer = new System.Timers.Timer();
            //_timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        }
        private void InitializeScheduler()
        {
            TimerScheduler objScheduler = new TimerScheduler();
            objScheduler.Start();
        }
       

        protected override void OnStart(string[] args)
        {
            //_timer.Enabled = true;
        }

        protected override void OnStop()
        {
        }
#if fixme
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (SchedulerFired != null)
            {
                try
                {
                    SchedulerFired(this, null);
                }
                catch
                {

                }
            }
            else
            {
                _timer.Enabled = false;

                // Write code here


                _timer.Enabled = true;
            }
            _timer.Stop();
            System.Threading.Thread.Sleep(500);
            SetTimer();
        }
        private double GetNextInterval()
        {
            _timeString = System.DateTime.Now.ToShortTimeString();
            DateTime t = DateTime.Parse(_timeString);
            TimeSpan ts = new TimeSpan();
            ts = t - System.DateTime.Now;
            int AddMinutes = 2;
            string date = DateTime.Today.ToShortDateString();
            TimeSpan CheckTimeGap1;
            int nexthour = DateTime.Now.Hour * 60 + DateTime.Now.Minute + 2;
            CheckTimeGap1 = Convert.ToDateTime(date).AddMinutes(nexthour) - DateTime.Now;
            AddMinutes = Convert.ToInt32(CheckTimeGap1.TotalMinutes) + 1;

            if (ts.TotalMilliseconds < 0)
            {
                ts = t.AddMinutes(AddMinutes) - System.DateTime.Now;
            }
            return ts.TotalMilliseconds;
        }
        private void SetTimer()
        {
            double inter = (double)GetNextInterval();
            _timer.Interval = inter;
            _timer.Start();
        }

        private void SendingSMS(string pTextMessage, string pToPhoneNumber)
        {
            try
            {    // Find your Account Sid and Auth Token at twilio.com/user/account
                string AccountSid = ConfigurationManager.AppSettings.Get("SMSAccountSid").ToString();
                string AuthToken = ConfigurationManager.AppSettings.Get("SMSAuthToken").ToString();
                string FromNumber = ConfigurationManager.AppSettings.Get("FromNumber").ToString();
                string CountryPhoneCode = ConfigurationManager.AppSettings.Get("CountryPhoneCode").ToString();


                var twilio = new TwilioRestClient(AccountSid, AuthToken);
                var message = twilio.SendMessage(FromNumber, (CountryPhoneCode + pToPhoneNumber), pTextMessage, "");
            }
            catch (Exception ex)
            {
                    
            }
        }
#endif
    }
}
