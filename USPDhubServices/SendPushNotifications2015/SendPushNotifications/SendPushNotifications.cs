using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using SendPushNotificationsBLL;
using Microsoft.Azure.NotificationHubs;
using System.Configuration;

namespace SendPushNotifications
{
    class SendPushNotifications
    {
        static void Main()
        {
            //var host = new JobHost();
            // The following code ensures that the WebJob will be running continuously
            //host.RunAndBlock();
            //SendPushNotifications objTimerScheduler = new SendPushNotifications();
            //objTimerScheduler.Start();
            //Console.ReadLine();

            SendAzureHubNotifications();
        }

        Timer objTimer = null;
        double interval = 60000;
        static NotificationsBLL objNotifications = new NotificationsBLL();
        //s public string logpath = "D:\\USPD\\SendNotifications.txt";
        public int LogID;
        private string _timeString;
        public void Start()
        {
            objTimer = new Timer(interval);
            objTimer.AutoReset = false;
            objTimer.Enabled = true;
            objTimer.Start();
            objTimer.Elapsed += new ElapsedEventHandler(objTimer_Elaspsed);
        }

        public void objTimer_Elaspsed(object sender, ElapsedEventArgs e)
        {
            objTimer.Enabled = false;
            DateTime LogDate;
            DateTime LogTime;
            //TextWriter tw;
            //// *** Hard coded to remove *** //
            //tw = new StreamWriter(logpath);

            //// write a line of text to the file
            //tw.WriteLine("Start of Engine start at: " + DateTime.Now.ToString());

            //// close the stream
            //tw.Close();
            //// *** End Hard coded to remove *** /
            //LogDate = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
            //LogTime = Convert.ToDateTime(System.DateTime.Now);
            //LogID = objNotifications.AddLogInDetails(LogDate, LogTime);

            try
            {
                SendAzureHubNotifications();
            }
            catch (Exception ex)
            {
                // *** Hard coded to remove *** //
                //tw = new StreamWriter(logpath);

                //// write a line of text to the file
                //tw.WriteLine(ex);

                //// close the stream
                //tw.Close();
                //// *** End Hard coded to remove *** //
            }
            DateTime LogOutDate;
            LogOutDate = Convert.ToDateTime(System.DateTime.Now);
            // objNotifications.AddLogOutDetails(LogID, LogOutDate);
            objTimer.Enabled = true;
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
            objTimer.Interval = inter;
            objTimer.Start();
        }

        private static void SendAzureHubNotifications()
        {
            DataTable dtNotifications = objNotifications.GetScheduledNotifications(DateTime.Now);
            if (dtNotifications.Rows.Count > 0)
            {
                int appID = 0;
                int profileID = 0;
                int pushNotifyID = 0;
                string pushType = "";
                int pushTypeID = 0;
                string tabName = "";
                string message = "";
                string windowsurl = "";
                DataTable dtDevices;
                DateTime sentDate;
                DataTable dthubdetails;
                string hubconnectionStrng = "";
                string hubName = "";
                string buttonType = "";
                for (int i = 0; i < dtNotifications.Rows.Count; i++)
                {
                    profileID = Convert.ToInt32(dtNotifications.Rows[i]["Profile_ID"]);
                    pushNotifyID = Convert.ToInt32(dtNotifications.Rows[i]["PushNotifyID"]);                    
                    pushType = "General";
                    buttonType = "General";
                    pushTypeID = 0;
                    tabName = "";
                    string androidmessage = "";
                    string windowsmsg = "";
                    if (!string.IsNullOrEmpty(Convert.ToString(dtNotifications.Rows[i]["Type"])))
                    {
                        pushType = Convert.ToString(dtNotifications.Rows[i]["Type"]);
                        buttonType = Convert.ToString(dtNotifications.Rows[i]["UMButtonType"]);
                        pushTypeID = Convert.ToInt32(dtNotifications.Rows[i]["Type_ID"]);
                    }
                    if (pushType != "General")
                    {
                        tabName = objNotifications.GetPushTypeTabName(profileID, pushType, pushTypeID);
                    }
                    // *** Update Sent Flag *** //
                    objNotifications.UpdateSentFlag(pushNotifyID);
                    message = Convert.ToString(dtNotifications.Rows[i]["Message"]);
                    androidmessage = message + "##ProfileSeparator##" + profileID.ToString();
                    sentDate = Convert.ToDateTime(dtNotifications.Rows[i]["Sending_Date"]);
                    windowsurl = "/Notifications.xaml?PID=" + profileID + "&amp;SentDate=" + sentDate + "&amp;PushMessage=##WPMESSAGE##&amp;PushType=" + pushType + "&amp;PushTypeID=" + pushTypeID.ToString() + "&amp;TabName=" + tabName;
                    windowsmsg = message;
                    if (((windowsurl.Length - 13) + message.Length) > 256)
                        windowsmsg = message.Substring(0, 256 - (windowsurl.Length - 13));
                    windowsurl = windowsurl.Replace("##WPMESSAGE##", windowsmsg);
                    if (!buttonType.ToLower().Contains("private"))
                    {
                        objNotifications.UpdatePushNotificationDevices(profileID, pushNotifyID, pushType, pushTypeID);
                        List<string> tags;
                        dthubdetails = objNotifications.GetHubDetailsByProfileId(profileID);
                        if (dthubdetails.Rows.Count > 0)
                        {
                            for (int hc = 0; hc < dthubdetails.Rows.Count; hc++)
                            {
                                appID = Convert.ToInt32(dthubdetails.Rows[hc]["App_ID"]);
                                int totalSlotCount = objNotifications.GetTotalSlotCountByAppID(profileID, appID);
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
                                            SendAzureHubAndroidNotifications(hubconnectionStrng, hubName, androidmessage, sentDate, profileID, pushType, pushTypeID, tabName, appID, tags);
                                            SendAzureHubIPhoneNotifications(hubconnectionStrng, hubName, message, profileID, sentDate, pushType, pushTypeID, tabName, appID, tags);
                                            SendAzureHubWindowsNotifications(hubconnectionStrng, hubName, windowsmsg, windowsurl, profileID, appID, tags);
                                        } // *** End of k for loop *** //
                                    }
                                }
                            } // *** End of hc for loop *** //
                        }
                    }
                    else  // *** Sending push for Private Module & Private Call *** //
                    {                        
                        dtDevices = objNotifications.GetPrivateMobileDevices(profileID, pushNotifyID, pushType, pushTypeID);
                        List<string> tags;
                        for (int j = 0; j < dtDevices.Rows.Count; j++)
                        {
                            int BDID = Convert.ToInt32(dtDevices.Rows[j]["BDID"]);
                            tags = new List<string>();
                            tags.Add("BDID:" + BDID);
                            hubconnectionStrng = Convert.ToString(dtDevices.Rows[j]["HubAccessKey"]);
                            hubName = Convert.ToString(dtDevices.Rows[j]["HubName"]);
                            if (hubconnectionStrng != "" && hubName != "")
                            {
                                SendAzureHubAndroidNotifications(hubconnectionStrng, hubName, androidmessage, sentDate, profileID, pushType, pushTypeID, tabName, appID, tags);
                                SendAzureHubIPhoneNotifications(hubconnectionStrng, hubName, message, profileID, sentDate, pushType, pushTypeID, tabName, appID, tags);
                                SendAzureHubWindowsNotifications(hubconnectionStrng, hubName, windowsmsg, windowsurl, profileID, appID, tags);
                            }
                        } // *** End of j for loop *** //
                    }
                } // *** End of i for loop *** //
            }
        }
        private static void SendAzureHubAndroidNotifications(string hubconnectionStrng, string hubName, string message, DateTime sentDate,
            int profileID, string pushType, int pushTypeID, string tabName, int appID, List<string> tags)
        {
            string Android_Str = "{'data':{'message':'" + message + "','SentDate':'" + sentDate + "','ProfileID':'" + profileID + "','PushTypeID':'" + pushTypeID + "','PushType':'" + pushType + "','TabName':'" + tabName + "'}}";
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

                NotificationHubClient objNotificationHubClient = NotificationHubClient.CreateClientFromConnectionString(hubconnectionStrng, hubName);

                string IOS_Str = "{ \"aps\": { \"alert\":\"" + message + "\",\"sound\":\"" + "default" + "\" }, \"agencyId\":\"" + profileID + "\", \"SentDate\":\"" + sentDate + "\", \"PushType\":\"" + pushType + "\", \"PushTypeID\":\"" + pushTypeID + "\", \"TabName\":\"" + tabName + "\"  }";

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
                    string pUniqueDeviceID = "";
                    string pBDID = "";
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
                            AppId = Convert.ToInt32(dtDevices.Rows[i]["App_ID"].ToString());


                            for (int j = 0; j < dtDevices.Rows.Count; j++)
                            {
                                int returnvalue = 0;
                                if (dtDevices.Rows[j]["Device_Type"].ToString().ToLower().Contains("android"))
                                {
                                    if (!string.IsNullOrEmpty(Convert.ToString(dtDevices.Rows[j]["AppVersion"])))
                                        appVersion = Convert.ToString(dtDevices.Rows[j]["AppVersion"]);
                                    if (!string.IsNullOrEmpty(dtDevices.Rows[j]["Device_ID"].ToString()))
                                    {
                                        returnvalue = SendAndroidNotifications(dtDevices.Rows[j]["Device_ID"].ToString(), dtDevices.Rows[j]["UniqueDeviceID"].ToString(), androidmessage, sentDate, profileID, pushType, pushTypeID, tabName, AppId, dtDevices.Rows[j]["BDID"].ToString(), appVersion);
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
                                        if (!string.IsNullOrEmpty(Convert.ToString(dtDevices.Rows[j]["UniqueDeviceID"])))
                                            pUniqueDeviceID = Convert.ToString(dtDevices.Rows[j]["UniqueDeviceID"]);
                                        if (!string.IsNullOrEmpty(Convert.ToString(dtDevices.Rows[j]["BDID"])))
                                            pBDID = Convert.ToString(dtDevices.Rows[j]["BDID"]);
                                        if ((AppId != ID || iphoneDevicesCount >= 25) && strBuilder.Length > 0)
                                        {
                                            SendIPhoneNotifications(strBuilder, message, pemfile, profileID, sentDate, pushType, pushTypeID, tabName, AppId, dtDevices.Rows[j]["UniqueDeviceID"].ToString(), dtDevices.Rows[j]["BDID"].ToString(), appVersion);
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

                                            SendIPhoneNotifications(strBuilderOld, message, pemfileOld, profileID, sentDate, pushType, pushTypeID, tabName, AppId, dtDevices.Rows[j]["UniqueDeviceID"].ToString(), dtDevices.Rows[j]["BDID"].ToString(), appVersion);
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
                                    windowsurl = "/Notifications.xaml?PID=" + profileID + "&amp;SentDate=" + sentDate + "&amp;PushMessage=##WPMESSAGE##&amp;PushType=" + pushType + "&amp;PushTypeID=" + pushTypeID.ToString();
                                    if (appVersion != "")
                                    {
                                        windowsurl = windowsurl + "&amp;TabName=" + tabName;
                                    }
                                    windowsmsg = message;
                                    if (((windowsurl.Length - 13) + message.Length) > 256)
                                        windowsmsg = message.Substring(0, 256 - (windowsurl.Length - 13));
                                    windowsurl = windowsurl.Replace("##WPMESSAGE##", windowsmsg);

                                    SendWindowsNotifications(Convert.ToString(dtDevices.Rows[j]["Device_ID"]), message, windowsurl, AppId, dtDevices.Rows[j]["UniqueDeviceID"].ToString(), dtDevices.Rows[j]["BDID"].ToString(), appVersion, profileID);

                                    //TextWriter tw;

                                    //// *** Hard coded to remove *** //
                                    //tw = new StreamWriter(logpath);

                                    //// write a line of text to the file
                                    //tw.WriteLine(ex);

                                    //// close the stream
                                    //tw.Close();
                                    //// *** End Hard coded to remove *** //

                                }

                            }
                            if (strBuilder.Length > 0)
                            {
                                SendIPhoneNotifications(strBuilder, message, pemfile, profileID, sentDate, pushType, pushTypeID, tabName, AppId, pUniqueDeviceID, pBDID, appVersion);
                            }
                            if (strBuilderOld.Length > 0)
                            {
                                SendIPhoneNotifications(strBuilderOld, message, pemfileOld, profileID, sentDate, pushType, pushTypeID, tabName, AppId, pUniqueDeviceID, pBDID, appVersion);
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
                objNotifications.InsertExceptionDetails("SendNotifications()", Convert.ToString(ex.Message), Convert.ToString(ex.InnerException),
                    Convert.ToString(ex.Data), "GeneralPushNotifications");

                //TextWriter tw;

                //// *** Hard coded to remove *** //
                //tw = new StreamWriter(logpath);

                //// write a line of text to the file
                //tw.WriteLine(ex);

                //// close the stream
                //tw.Close();
                // *** End Hard coded to remove *** //
            }
        }
        private int SendAndroidNotifications(string DeviceID, string pUniqueDeviceID, string message, DateTime sentDate, int profileID, string pushType, int pushTypeID, string tabName, int AppId, string pBDID, string pAppVersion)
        {
            int availableSlot = objNotifications.GetNHPushAvailableSlot(profileID, AppId);
            int count = 0;
            // adding tags
            List<string> tags = new List<string>();
            tags.Add("PID:" + profileID);
            tags.Add("AppID:" + AppId);
            tags.Add("UniqueID:" + pUniqueDeviceID);
            tags.Add("AppVersion:" + pAppVersion);
            tags.Add("BDID:" + pBDID);
            tags.Add("SlotID:" + profileID + "_" + availableSlot);


            string Android_Str = "{'data':{'message':'" + message + "','SentDate':'" + sentDate + "','ProfileID':'" + profileID + "','PushTypeID':'" + pushTypeID + "','PushType':'" + pushType + "','TabName':'" + tabName + "'}}";


            try
            {
                DataTable dthubdetails;
                dthubdetails = objNotifications.GetHubDetails(AppId);
                string connectionStrng = Convert.ToString(dthubdetails.Rows[0]["HubAccessKey"]);
                string hubName = Convert.ToString(dthubdetails.Rows[0]["HubName"]);
                NotificationHubClient objNotificationHubClient =
                NotificationHubClient.CreateClientFromConnectionString(connectionStrng, hubName);

                var result = objNotificationHubClient.SendGcmNativeNotificationAsync(Android_Str, tags);
                Task.WaitAll(result);
            }
            catch (Exception ex)
            {
                string str = "ProfileId:" + profileID + "  AppID:" + AppId + "  UniqueDeviceId:" + pUniqueDeviceID + "  BDID:" + pBDID;
                objNotifications.InsertExceptionDetails("SendAndroidNotifications()", Convert.ToString(ex.Message), Convert.ToString(ex.InnerException),
                    Convert.ToString(ex.Data), "GeneralPushNotifications() :" + str);

                // *** End Hard coded to remove *** //
            }
            return count;
        }
        private void SendIPhoneNotifications(StringBuilder strBuilder, string message, string pemfile, int profileID, DateTime sentDate, string pushType, int pushTypeID, string tabName, int AppId, string pUniqueDeviceID, string pBDID, string pAppVersion)
        {
            int availableSlot = objNotifications.GetNHPushAvailableSlot(profileID, AppId);

            DataTable dthubdetails;
            List<string> tags = new List<string>();
            tags.Add("PID:" + profileID);
            tags.Add("AppID:" + AppId);
            tags.Add("UniqueID:" + pUniqueDeviceID);
            tags.Add("AppVersion:" + pAppVersion);
            tags.Add("BDID:" + pBDID);
            tags.Add("SlotID:" + profileID + "_" + availableSlot);


            try
            {
                dthubdetails = objNotifications.GetHubDetails(AppId);
                string connectionStrng = Convert.ToString(dthubdetails.Rows[0]["HubAccessKey"]);
                string hubName = Convert.ToString(dthubdetails.Rows[0]["HubName"]);
                NotificationHubClient objNotificationHubClient = NotificationHubClient.CreateClientFromConnectionString(connectionStrng, hubName);

                string IOS_Str = "{ \"aps\": { \"alert\":\"" + message + "\",\"sound\":\"" + "default" + "\" }, \"agencyId\":\"" + profileID + "\", \"SentDate\":\"" + sentDate + "\", \"PushType\":\"" + pushType + "\", \"PushTypeID\":\"" + pushTypeID + "\", \"TabName\":\"" + tabName + "\"  }";

                var result = objNotificationHubClient.SendAppleNativeNotificationAsync(IOS_Str, tags);
                Task.WaitAll(result);
            }
            catch (Exception ex)
            {
                string str = "ProfileId:" + profileID + "  AppID:" + AppId + "  UniqueDeviceId:" + pUniqueDeviceID + "  BDID:" + pBDID;
                objNotifications.InsertExceptionDetails("SendIPhoneNotifications()", Convert.ToString(ex.Message),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data), "GeneralPushNotifications() :" + str);

            }
        }

        private void SendWindowsNotifications(string deviceId, string message, string windowsurl, int AppId, string pUniqueDeviceID, string pBDID, string pAppVersion, int profileID)
        {
            int availableSlot = objNotifications.GetNHPushAvailableSlot(profileID, AppId);

            DataTable dthubdetails;
            List<string> tags = new List<string>();
            //replacement done as /,+,== are not allowed in tag registartion
            string UniqueId = pUniqueDeviceID;
            UniqueId = UniqueId.Replace("/", "@");
            UniqueId = UniqueId.Replace("+", "#");
            UniqueId = UniqueId.Replace("=", ":");
            tags.Add("PID:" + profileID);
            tags.Add("AppID:" + AppId);
            tags.Add("UniqueID:" + UniqueId);
            tags.Add("AppVersion:" + pAppVersion);
            tags.Add("BDID:" + pBDID);
            tags.Add("SlotID:" + profileID + "_" + availableSlot);


            dthubdetails = objNotifications.GetHubDetails(AppId);
            string connectionStrng = Convert.ToString(dthubdetails.Rows[0]["HubAccessKey"]);
            string hubName = Convert.ToString(dthubdetails.Rows[0]["HubName"]);
            NotificationHubClient objNotificationHubClient = NotificationHubClient.CreateClientFromConnectionString(connectionStrng, hubName);



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
                string str = "ProfileId:" + profileID + "  AppID:" + AppId + "  UniqueDeviceId:" + pUniqueDeviceID + "  BDID:" + pBDID;
                objNotifications.InsertExceptionDetails("SendWindowsNotifications()", Convert.ToString(ex.Message), Convert.ToString(ex.InnerException),
                    Convert.ToString(ex.Data), "GeneralPushNotifications() :" + str);

                // *** End Hard coded to remove *** //
            }
        }

        private void ErrorHandling(string pMessage)
        {
            //    StreamWriter oSW;
            //    if (File.Exists(logpath))
            //    {
            //        oSW = new StreamWriter(logpath, true);
            //    }
            //    else
            //    {
            //        oSW = File.CreateText(logpath);
            //    }
            //    oSW.WriteLine("================================" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "================================");
            //    oSW.WriteLine(" ");
            //    oSW.WriteLine("Log Message : " + pMessage);
            //    oSW.WriteLine(" ");
            //    oSW.Close();
        }
    }
}
