using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;
using SendPushNotificationsBLL;
using System.Net;
using System.Configuration;

namespace SendPushNotifications
{
    public partial class SendPushNotifications : ServiceBase
    {
        public SendPushNotifications()
        {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            InitializeComponent();
        }
        private System.Timers.Timer _timer;
        NotificationsBLL objNotifications = new NotificationsBLL();
        public event EventHandler SchedulerFired;
        public string logpath = "C:\\inetpub\\wwwroot\\USPDHub\\SendNotifications.txt";
        public int Hours = 1;
        public int LogID;
        public int RunTimeMinute = 0;
        private string _timeString;
        protected override void OnStart(string[] args)
        {
            _timer.Enabled = true;
        }
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
                TextWriter tw;
                // *** Hard coded to remove *** //
                tw = new StreamWriter(logpath);

                // write a line of text to the file
                tw.WriteLine("Start of Engine." + DateTime.Now.ToString());

                // close the stream
                tw.Close();
                // *** End Hard coded to remove *** /
                LogDate = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                LogTime = Convert.ToDateTime(System.DateTime.Now.ToShortTimeString());
                LogID = objNotifications.AddLogInDetails(LogDate, LogTime);

                try
                {
                    this.SendNotifications();
                }
                catch (Exception ex)
                {
                    // *** Hard coded to remove *** //
                    tw = new StreamWriter(logpath);

                    // write a line of text to the file
                    tw.WriteLine(ex);

                    // close the stream
                    tw.Close();
                    // *** End Hard coded to remove *** //
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
        private void SendNotifications()
        {
            try
            {
                DataTable dtNotifications = objNotifications.GetScheduledNotifications(DateTime.Now);
                if (dtNotifications.Rows.Count > 0)
                {
                    DataTable dtDevices;
                    int profileID = 0;
                    int pushNotifyID = 0;
                    string appVersion = "";
                    StringBuilder strBuilder = new StringBuilder();
                    StringBuilder strBuilderOld = new StringBuilder();
                    string pemfile = string.Empty;
                    string pemfileOld = string.Empty;
                    string tabName = "";
                    string windowsurl = "";
                    string altMessage = "";
                    string pushType = "";
                    int pushTypeID = 0;
                    string message = "";
                    DateTime sentDate;
                    int AppId = 0;
                    int ID = 0;
                    int AppIdOld = 0;
                    int IDOld = 0;
                    string androidmessage = "";
                    string windowsmsg = "";
                    int iphoneDevicesCount = 0;
                    int iphoneDevicesCountOld = 0;
                    for (int i = 0; i < dtNotifications.Rows.Count; i++)
                    {
                        profileID = Convert.ToInt32(dtNotifications.Rows[i]["Profile_ID"]);
                        pushNotifyID = Convert.ToInt32(dtNotifications.Rows[i]["PushNotifyID"]);
                        pushType = "General";
                        pushTypeID = 0;
                        tabName = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(dtNotifications.Rows[i]["Type"])))
                        {
                            pushType = Convert.ToString(dtNotifications.Rows[i]["Type"]);
                            pushTypeID = Convert.ToInt32(dtNotifications.Rows[i]["Type_ID"]);
                        }
                        dtDevices = objNotifications.GetMobileDevices(profileID, pushNotifyID, pushType, pushTypeID);
                        if (dtDevices.Rows.Count > 0)
                        {

                            if (pushType != "General")
                            {
                                tabName = objNotifications.GetPushTypeTabName(profileID, pushType, pushTypeID);
                            }
                            message = Convert.ToString(dtNotifications.Rows[i]["Message"]);
                            androidmessage = message + "##ProfileSeparator##" + profileID.ToString();
                            sentDate = Convert.ToDateTime(dtNotifications.Rows[i]["Sending_Date"]);
                            for (int j = 0; j < dtDevices.Rows.Count; j++)
                            {
                                int returnvalue = 0;
                                if (dtDevices.Rows[j]["Device_Type"].ToString().ToLower().Contains("android"))
                                {
                                    if (!string.IsNullOrEmpty(dtDevices.Rows[j]["Device_ID"].ToString()))
                                    {
                                        returnvalue = SendAndroidNotifications(dtDevices.Rows[j]["Device_ID"].ToString(), androidmessage, sentDate, profileID, pushType, pushTypeID, tabName);
                                    }
                                }
                                else if (dtDevices.Rows[j]["Device_Type"].ToString().ToLower().Contains("iphone"))
                                {
                                    if (!string.IsNullOrEmpty(Convert.ToString(dtDevices.Rows[j]["AppVersion"])))
                                        appVersion = Convert.ToString(dtDevices.Rows[j]["AppVersion"]);
                                    else
                                        appVersion = "";
                                    if (appVersion != "")
                                    {
                                        AppId = Convert.ToInt32(dtDevices.Rows[j]["App_ID"].ToString());
                                        if (ID == 0)
                                            ID = AppId;
                                        if ((AppId != ID || iphoneDevicesCount >= 25) && strBuilder.Length > 0)
                                        {
                                            SendIPhoneNotifications(strBuilder, message, pemfile, profileID, sentDate, pushType, pushTypeID, tabName);
                                            iphoneDevicesCount = 0;
                                            ID = AppId;
                                            strBuilder.Length = 0;
                                        }
                                        if (!string.IsNullOrEmpty(dtDevices.Rows[j]["Device_ID"].ToString()))
                                        {
                                            if (strBuilder.Length == 0)
                                            {
                                                strBuilder.Append("\"" + dtDevices.Rows[j]["Device_ID"].ToString() + "\"");
                                                pemfile = dtDevices.Rows[j]["PemFile_Name"].ToString();
                                            }
                                            else
                                            {
                                                strBuilder.Append(",\"" + dtDevices.Rows[j]["Device_ID"].ToString() + "\"");
                                                if (pemfile == "")
                                                    pemfile = dtDevices.Rows[j]["PemFile_Name"].ToString();
                                            }
                                        }
                                        iphoneDevicesCount += 1;
                                    }
                                    else
                                    {
                                        AppIdOld = Convert.ToInt32(dtDevices.Rows[j]["App_ID"].ToString());
                                        if (IDOld == 0)
                                            IDOld = AppIdOld;
                                        if ((AppIdOld != IDOld || iphoneDevicesCountOld >= 25) && strBuilderOld.Length > 0)
                                        {
                                            SendIPhoneNotifications(strBuilderOld, message, pemfileOld, profileID, sentDate, pushType, pushTypeID, tabName);
                                            iphoneDevicesCountOld = 0;
                                            IDOld = AppIdOld;
                                            strBuilderOld.Length = 0;
                                        }
                                        if (!string.IsNullOrEmpty(dtDevices.Rows[j]["Device_ID"].ToString()))
                                        {
                                            if (strBuilderOld.Length == 0)
                                            {
                                                strBuilderOld.Append("\"" + dtDevices.Rows[j]["Device_ID"].ToString() + "\"");
                                                pemfileOld = dtDevices.Rows[j]["PemFile_Name"].ToString().Replace(".pem", "1.pem");
                                            }
                                            else
                                            {
                                                strBuilderOld.Append(",\"" + dtDevices.Rows[j]["Device_ID"].ToString() + "\"");
                                                if (pemfileOld == "")
                                                    pemfileOld = dtDevices.Rows[j]["PemFile_Name"].ToString().Replace(".pem", "1.pem");
                                            }
                                        }
                                        iphoneDevicesCountOld += 1;
                                    }
                                }
                                else if (dtDevices.Rows[j]["Device_Type"].ToString().ToLower().Contains("windowsphone"))
                                {
                                    appVersion = Convert.ToString(dtDevices.Rows[j]["AppVersion"]);
                                    altMessage = message;
                                    if (message.Length > 250)
                                        altMessage = message.Substring(0, 250);
                                    windowsurl = "/Notifications.xaml?PID=" + profileID.ToString() + "&amp;SentDate=" + sentDate + "&amp;PushMessage=##WPMESSAGE##&amp;PushType=" + pushType + "&amp;PushTypeID=" + pushTypeID.ToString();
                                    if (appVersion != "")
                                    {
                                        windowsurl = windowsurl + "&amp;TabName=" + tabName;
                                    }
                                    windowsmsg = message;
                                    if (((windowsurl.Length - 13) + message.Length) > 256)
                                        windowsmsg = message.Substring(0, 256 - (windowsurl.Length - 13));
                                    windowsurl = windowsurl.Replace("##WPMESSAGE##", windowsmsg);
                                    try
                                    {
                                        string channelURI = dtDevices.Rows[j]["Device_ID"].ToString();
                                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(channelURI);
                                        request.Method = "POST";
                                        request.ContentType = "text/xml";
                                        request.Headers = new WebHeaderCollection();
                                        request.Headers.Add("X-NotificationClass", "2");
                                        request.Headers.Add("X-WindowsPhone-Target", "toast");
                                        string notificationData = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                                                "<wp:Notification xmlns:wp=\"WPNotification\">" +
                                                                "<wp:Toast>" +
                                                                "<wp:Text2>" + altMessage + "</wp:Text2>" +
                                                                "<wp:Param>" + windowsurl + "</wp:Param>" +
                                                                "</wp:Toast> " +
                                                                "</wp:Notification>";
                                        byte[] contents = Encoding.Default.GetBytes(notificationData);
                                        request.ContentLength = contents.Length;
                                        using (Stream requestStream = request.GetRequestStream())
                                        {
                                            requestStream.Write(contents, 0, contents.Length);
                                        }
                                        string notificationStatus;
                                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                                        {
                                            notificationStatus = response.Headers["X-NotificationStatus"];
                                            string notificationChannelStatus = response.Headers["X-SubscriptionStatus"];
                                            string deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        TextWriter tw;

                                        // *** Hard coded to remove *** //
                                        tw = new StreamWriter(logpath);

                                        // write a line of text to the file
                                        tw.WriteLine(ex);

                                        // close the stream
                                        tw.Close();
                                        // *** End Hard coded to remove *** //
                                    }
                                }

                            }
                            if (strBuilder.Length > 0)
                            {
                                SendIPhoneNotifications(strBuilder, message, pemfile, profileID, sentDate, pushType, pushTypeID, tabName);
                            }
                            if (strBuilderOld.Length > 0)
                            {
                                SendIPhoneNotifications(strBuilderOld, message, pemfileOld, profileID, sentDate, pushType, pushTypeID, tabName);
                            }
                        }
                        AppId = 0;
                        ID = 0;
                        AppIdOld = 0;
                        IDOld = 0;
                        objNotifications.UpdateSentFlag(pushNotifyID);
                    }
                }
            }
            catch (Exception ex)
            {
                TextWriter tw;

                // *** Hard coded to remove *** //
                tw = new StreamWriter(logpath);

                // write a line of text to the file
                tw.WriteLine(ex);

                // close the stream
                tw.Close();
                // *** End Hard coded to remove *** //
            }
        }
        private int SendAndroidNotifications(string DeviceID, string message, DateTime sentDate, int profileID, string pushType, int pushTypeID, string tabName)
        {

            TextWriter tw;
            StreamReader streamReader;

            // *** Hard coded to remove *** //
            tw = new StreamWriter(logpath);

            // write a line of text to the file
            tw.WriteLine(DeviceID);

            // close the stream
            tw.Close();
            // *** End Hard coded to remove *** //
            int count = 0;
            try
            {
                string GoogleAppID = ConfigurationSettings.AppSettings["AndroidAPI"];
                WebRequest tRequest;
                tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
                tRequest.Method = "POST";
                tRequest.ContentType = "application/x-www-form-urlencoded";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));
                String collaspeKey = Guid.NewGuid().ToString("n");
                String postData = string.Format("registration_id={0}&data.message={1}&data.SentDate={2}&data.ProfileID={3}&data.PushTypeID={4}&data.PushType={5}&data.TabName={6}&collapse_key={7}", DeviceID, message, sentDate, profileID, pushTypeID, pushType, tabName, collaspeKey);
                Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                tRequest.ContentLength = byteArray.Length;

                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                String sResponseFromServer = tReader.ReadToEnd();
                tReader.Close();
                dataStream.Close();
                tResponse.Close();
                if (sResponseFromServer.Contains("id=0"))
                    count = 1;
                tReader.Dispose();
                dataStream.Dispose();
            }
            catch (Exception ex)
            {

                // *** Hard coded to remove *** //
                tw = new StreamWriter(logpath);

                // write a line of text to the file
                tw.WriteLine(ex);

                // close the stream
                tw.Close();
                // *** End Hard coded to remove *** //
            }
            return count;
        }
        private void SendIPhoneNotifications(StringBuilder strBuilder, string message, string pemfile, int profileID, DateTime sentDate, string pushType,
            int pushTypeID, string tabName)
        {

            try
            {

                #region  Google APNS

                /*
                 * Need to update server key(API Key) in ios app code changes 
                 * Upload to p12 file to google developer 
                   
                 
                 
                 
              string GoogleAppID = ConfigurationSettings.AppSettings["IOSAPI_LTSchool"];

              HttpWebRequest objHttpWebRequest;
              objHttpWebRequest = (HttpWebRequest)WebRequest.Create("https://gcm-http.googleapis.com/gcm/send");
              objHttpWebRequest.ContentType = "application/json";
              objHttpWebRequest.PreAuthenticate = true;
              objHttpWebRequest.Headers.Add(string.Format("Authorization:key={0}", GoogleAppID));
              objHttpWebRequest.Method = "POST";

              string json = " { " +
" \"to\" : \"" + strBuilder.ToString() + "\"" +
" \"notification\" : { " +
  " \"body\" : \"" + message + "\" ," +
  " \"agencyId\" : \"" + profileID + "\" ," +
  " \"SentDate\" : \"" + sentDate.ToString() + "\" ," +
  " \"PushType\" : \"" + pushType + "\" ," +
  " \"PushTypeID\" : \"" + pushTypeID + "\" ," +
  " \"TabName\" : \"" + tabName + "\" " +
  "}" +
"}";


              //Prepare the request stream       
              UTF8Encoding encoding = new UTF8Encoding();
              Stream objStream = objHttpWebRequest.GetRequestStream();
              Byte[] Buffer = encoding.GetBytes(json);
              // Post the request 
              objStream.Write(Buffer, 0, Buffer.Length);
              objStream.Close();
              HttpWebResponse objHttpWebResponse = (HttpWebResponse)objHttpWebRequest.GetResponse();

              encoding = new UTF8Encoding();
              StreamReader objStreamReader = new StreamReader(objHttpWebResponse.GetResponseStream(), encoding);
              string strResponse = objStreamReader.ReadToEnd();
              objHttpWebResponse.Close();
              objHttpWebRequest = null;
              objStreamReader.Close();
              objStreamReader.Dispose();

               */

                #endregion


                #region PHP

                 
                HttpWebResponse objHttpWebResponse = null;
                UTF8Encoding encoding;
                string strResponse = "";

                HttpWebRequest objHttpWebRequest;
                objHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://excove.net/uspdhub/pushnotification.php");
                objHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
                objHttpWebRequest.PreAuthenticate = true;

                objHttpWebRequest.Method = "POST";
                string json = "data={\"message\":\"" + message.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"," + "\"devices\":[" + strBuilder.ToString() + "]" + ",\"PemFile\":\"" + pemfile + "\",\"agencyId\":\"" + profileID.ToString() + "\",\"SentDate\":\"" + sentDate.ToString() + "\",\"PushType\":\"" + pushType + "\",\"PushTypeID\":\"" + pushTypeID.ToString() + "\",\"TabName\":\"" + tabName + "\"}";
                //Prepare the request stream       
                encoding = new UTF8Encoding();
                Stream objStream = objHttpWebRequest.GetRequestStream();
                Byte[] Buffer = encoding.GetBytes(json);
                // Post the request 
                objStream.Write(Buffer, 0, Buffer.Length);
                objStream.Close();
                objHttpWebResponse = (HttpWebResponse)objHttpWebRequest.GetResponse();

                encoding = new UTF8Encoding();
                StreamReader objStreamReader = new StreamReader(objHttpWebResponse.GetResponseStream(), encoding);
                strResponse = objStreamReader.ReadToEnd();
                objHttpWebResponse.Close();
                objHttpWebRequest = null;
                objStreamReader.Close();
                objStreamReader.Dispose();


                

                #endregion

            }
            catch (Exception ex)
            {
                TextWriter tw;

                // *** Hard coded to remove *** //
                tw = new StreamWriter(logpath);

                // write a line of text to the file
                tw.WriteLine(ex);

                // close the stream
                tw.Close();
                // *** End Hard coded to remove *** //
            }
        }
        protected override void OnStop()
        {
        }
    }
}
