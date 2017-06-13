using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.NotificationHubs;
using System.Timers;
using System.IO;
using System.Data;
using SilentPushNotificationsBLL;
namespace SilentPushNotifications
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class SilentPushNotifications
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            //SilentPushNotifications objTimerScheduler = new SilentPushNotifications();
            //objTimerScheduler.Start();
            //Console.ReadLine();
            GetSilentPushDeviceIDs();
        }
        private System.Timers.Timer _timer;
        double interval = 60000;
        public void Start()
        {
            _timer = new System.Timers.Timer(interval);

            _timer.AutoReset = false;
            _timer.Enabled = true;
            _timer.Start();
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        }

        static NotificationsBLL objNotifications = new NotificationsBLL();
        public event EventHandler SchedulerFired;
        //public string logpath = "D:\\USPDhub2015\\SilentPushNotifications.txt";
        public int Hours = 1;
        public int LogID;
        public int RunTimeMinute = 0;
        private string _timeString;
        static string typeOfService = "SilentPushNotifications";

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
                DateTime LogDate;
                DateTime LogTime;
                //     TextWriter tw;
                // *** Hard coded to remove *** // 

                // write a line of text to the file 
                ErrorHandling("_timer_Elapsed", "Start of Engine. " + DateTime.Now.ToString(), "", "", "");

                // *** End Hard coded to remove *** /
                LogDate = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                LogTime = Convert.ToDateTime(System.DateTime.Now.ToShortTimeString());
                LogID = objNotifications.AddLogInDetails(LogDate, LogTime);

                try
                {

                }
                catch (Exception ex)
                {
                    ErrorHandling("ERROR - _timer_Elapsed", Convert.ToString(ex.Message),
                       Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), typeOfService);
                }

                DateTime LogOutDate;
                LogOutDate = Convert.ToDateTime(System.DateTime.Now.ToShortTimeString());
                objNotifications.AddLogOutDetails(LogID, LogOutDate);
                TimeSpan CheckTimeGap = LogOutDate - LogTime;
                RunTimeMinute = Convert.ToInt32(CheckTimeGap.TotalMinutes);
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
        private static void GetSilentPushDeviceIDs()
        {
            DataTable dtNotifications = objNotifications.GetScheduledSilentNotifications(DateTime.Now);
            if (dtNotifications.Rows.Count > 0)
            {
                SilentAzurePushNotifications(dtNotifications);
            }
        }

        private static void SilentAzurePushNotifications(DataTable dtNotifications)
        {
            int profileID = 0;
            StringBuilder strBuilder = new StringBuilder();
            StringBuilder strBuilderOld = new StringBuilder();
            string pemfile = string.Empty;
            string pemfileOld = string.Empty;
            string tabName = "";
            string windowsurl = "";
            string pushType = "silentpush";
            int pushTypeID = 0;
            string message = "";
            DateTime sentDate;
            int AppId = 0;
            string androidmessage = "";
            string windowsmsg = "";
            DataTable dthubdetails;
            string hubconnectionStrng = "";
            string hubName = "";
            for (int i = 0; i < dtNotifications.Rows.Count; i++)
            {
                profileID = Convert.ToInt32(dtNotifications.Rows[i]["Profile_Id"]);
                message = "New Content Available";
                sentDate = DateTime.Now;
                androidmessage = message + "##ProfileSeparator##" + profileID.ToString();
                windowsurl = "/Notifications.xaml?PID=" + profileID.ToString() + "&amp;SentDate=" + sentDate + "&amp;PushMessage=##WPMESSAGE##&amp;PushType=" + pushType + "&amp;PushTypeID=" + pushTypeID.ToString();
                windowsmsg = message;
                if (((windowsurl.Length - 13) + message.Length) > 256)
                    windowsmsg = message.Substring(0, 256 - (windowsurl.Length - 13));
                windowsurl = windowsurl.Replace("##WPMESSAGE##", windowsmsg);
                List<string> tags;
                dthubdetails = objNotifications.GetHubDetailsByProfileId(profileID);
                if (dthubdetails.Rows.Count > 0)
                {
                    for (int hc = 0; hc < dthubdetails.Rows.Count; hc++)
                    {
                        AppId = Convert.ToInt32(dthubdetails.Rows[hc]["App_ID"]);
                        int totalSlotCount = objNotifications.GetTotalSlotCountByAppID(profileID, AppId);
                        if (totalSlotCount > 0)
                        {
                            for (int k = 1; k <= totalSlotCount; k++)
                            {
                                tags = new List<string>();
                                tags.Add("SlotID:" + profileID + "_" + k);

                                hubconnectionStrng = Convert.ToString(dthubdetails.Rows[hc]["HubAccessKey"]);
                                hubName = Convert.ToString(dthubdetails.Rows[hc]["HubName"]);
                                if (hubconnectionStrng != "" && hubName != "")
                                {
                                    SendAzureHubAndroidNotifications(hubconnectionStrng, hubName, androidmessage, sentDate, profileID, pushType, pushTypeID, tabName, AppId, tags);
                                    SendAzureHubIPhoneNotifications(hubconnectionStrng, hubName, message, profileID, sentDate, pushType, pushTypeID, tabName, AppId, tags);
                                }
                            }//for loop
                        }
                    }
                }
            }

        }

        private static void SendAzureHubAndroidNotifications(string hubconnectionStrng, string hubName, string message, DateTime sentDate,
           int profileID, string pushType, int pushTypeID, string tabName, int appID, List<string> tags)
        {


            string Android_Str = "{'data':{'message':'" + message + "','PushNotificationType':'" + "silentpush" + "'}}";
            try
            {
                NotificationHubClient objNotificationHubClient =
                NotificationHubClient.CreateClientFromConnectionString(hubconnectionStrng, hubName);
                var result = objNotificationHubClient.SendGcmNativeNotificationAsync(Android_Str, tags);
                Task.WaitAll(result);
            }
            catch (Exception ex)
            {
                string str = "ProfileId:" + profileID + "  HubName:" + hubName + "  DateTime:" + DateTime.Now;
                objNotifications.InsertExceptionDetails("SendAzureHubAndroidNotifications()", Convert.ToString(ex.Message), Convert.ToString(ex.InnerException),
                    Convert.ToString(ex.Data), "SendAzureHubAndroidNotifications() :" + str);
            }
        }
        private static void SendAzureHubIPhoneNotifications(string hubconnectionStrng, string hubName, string message, int profileID, DateTime sentDate,
            string pushType, int pushTypeID, string tabName, int appID, List<string> tags)
        {

            try
            {

                // string json = "data={\"message\":\"" + message.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"," + "\"devices\":[" + deviceId + "]" + ",\"PemFile\":\"" + pemfile + "\",\"agencyId\":\"" + profileID.ToString() + "\",\"SentDate\":\"" + sentDate.ToString() + "\",\"PushType\":\"" + pushType + "\",\"PushTypeID\":\"" + pushTypeID.ToString() + "\",\"TabName\":\"" + tabName + "\"}";

                NotificationHubClient objNotificationHubClient = NotificationHubClient.CreateClientFromConnectionString(hubconnectionStrng, hubName);
                string IOS_Str = "{ \"aps\": { \"badge\" : 1,\"content-available\" : 1}, \"agencyId\":\"" + profileID + "\", \"SentDate\":\"" + sentDate + "\", \"PushType\":\"" + "silentpush" + "\", \"PushTypeID\":\"" + 0 + "\", \"TabName\":\"" + tabName + "\"  }";

                var result = objNotificationHubClient.SendAppleNativeNotificationAsync(IOS_Str, tags);
                Task.WaitAll(result);
            }
            catch (Exception ex)
            {
                string str = "ProfileId:" + profileID + "  HubName:" + hubName + "  DateTime:" + DateTime.Now;
                objNotifications.InsertExceptionDetails("SendAzureHubIPhoneNotifications()", Convert.ToString(ex.Message),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "SendAzureHubIPhoneNotifications() :" + str);

            }
        }
        private static void SendAzureHubWindowsNotifications(string hubconnectionStrng, string hubName, string message, string windowsurl,
            int profileID, int appID, List<string> tags)
        {
            NotificationHubClient objNotificationHubClient = NotificationHubClient.CreateClientFromConnectionString(hubconnectionStrng, hubName);
            try
            {

                string notificationData = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                        "<wp:Notification xmlns:wp=\"WPNotification\">" +
                                        "<wp:Toast>" +
                                        "<wp:Text2>" + message + "</wp:Text2>" +
                                        "<wp:Param>" + windowsurl + "</wp:Param>" +
                                        "</wp:Toast> " +
                                        "</wp:Notification>";

                var result = objNotificationHubClient.SendMpnsNativeNotificationAsync(notificationData, tags);
                Task.WaitAll(result);


            }
            catch (Exception ex)
            {
                string str = "ProfileId:" + profileID + "  HubName:" + hubName + "  DateTime:" + DateTime.Now;
                objNotifications.InsertExceptionDetails("SendAzureHubWindowsNotifications()", Convert.ToString(ex.Message), Convert.ToString(ex.InnerException),
                    Convert.ToString(ex.Data), "SendAzureHubWindowsNotifications() :" + str);
            }
        }

        //old code
        public static void ErrorHandling(string methodName, string message, string strackTrace, string innerException, string data)
        {

            objNotifications.InsertExceptionDetails(methodName, message, innerException, data, typeOfService);

        }
    }


}
