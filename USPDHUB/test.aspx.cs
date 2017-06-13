using System;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using USPDHUBBLL;
using System.Xml;
using System.Collections.ObjectModel;
using System.Configuration;
using USPDHUBDAL;
using System.Web;
using System.Text.RegularExpressions;

namespace USPDHUB
{
    public partial class test : System.Web.UI.Page
    {
        MServiceBLL objMobile = new MServiceBLL();
        CommonBLL objCommon = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
              string previe =  StringReplaceUrl("<html><body><table><tr><td style=\"page-break-inside: avoid; width:300px; padding-bottom: 2px; text-align:center;\"><img style=\"vertical-align:bottom;\" src=\"http://www.uspdhub.com/Upload/Bulletins/Templates/10423/Template/otsd-preparathon-05-4X4-1_130916113417.jpg\" border=\"0\" width=\"280px\" height=\"279px\"></td></tr><tr><td><a target=\"_blank\" href=\"http://www.fema.gov/media-library/assets/documents/34330\" tabindex=\"0\">http://www.fema.gov/media-library/assets/documents/34330</a></td></tr></table></body></html>");
              previe = StringReplaceUrl(previe);
                //SendAndroidNotifications();
                DateTime dtSyncEndtime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(12);
                string pwd = "";// USPDHUBBLL.EncryptDecrypt.DESDecrypt("");
                pwd = USPDHUBBLL.EncryptDecrypt.DESEncrypt("0");
                previe = pwd;
                // *** Checking polyndrome *** //
                //string strFull = "MyName"; //"LIRIL";
                //string strfirst = "";
                //string strSecond = "";
                //int length = strFull.Length;
                //if (length > 2)
                //{ 
                //    length=length/2;
                //    for (int i = 0; i < length; i++)
                //    {
                //        strfirst = strfirst + strFull[i];
                //        strSecond = strSecond + strFull[strFull.Length - 1 - i];                    
                //    }
                //    if (strfirst == strSecond)
                //    {

                //    }
                //}
                // *** End checking polyndrome *** //
                string windowsmsg = " first this is the statement for testing windows message for pushnotification which ahas more than 200 characters. This is failed when we send from web to windows phone.this is the statement for testing windows message for pushnotification which ahas more than 200 characters. This is failed when we send from web to windows phone.this is the statement for testing windows message for pushnotification which ahas more than 200 characters. This is failed when we send from web to windows phone.";
                if (windowsmsg.Length > 200)
                    windowsmsg = windowsmsg.Substring(0, 200);
                //string msgbody = string.Empty;
                //string rootPath = "http://localhost:2107";
                //string type = "ET";
                //int bulletinID = 1354;
                //int userID = 325;
                //Label1.Text = rootPath + "/ApprovalProcess.aspx?TID=" + EncryptDecrypt.DESEncrypt(bulletinID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&UID=" + EncryptDecrypt.DESEncrypt(userID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&Type=" + type ;
                //Label2.Text = rootPath + "/ApprovalProcess.aspx?TID=" + EncryptDecrypt.DESEncrypt(bulletinID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&UID=" + EncryptDecrypt.DESEncrypt(userID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&Type=" + type ; //A for approve
                //Label3.Text = rootPath + "/ApprovalProcess.aspx?TID=" + EncryptDecrypt.DESEncrypt(bulletinID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&UID=" + EncryptDecrypt.DESEncrypt(userID.ToString()).Replace("=", "irhmalli").Replace("+", "irhPASS") + "&Type=" + type ;

                //SendWindowsNotification();
                try
                {


                    //string xml = "<Bulletins><CallLogDetails  BulletinName= '12/07/2013'    Associate1= 'Laura' LoginDate='12/09/2013'  LoginHour='6'  LoginMin='30' LoginSection='PM' LogOutDate='12/08/2013' LogOutHour='3' LogOutMin='15' LogOutSection='PM' TransferredPhoneTo='Nicole'  /> <ChildCallerDetails  FirstName='Frieda' LastName='Morales'  PhoneNumber='916-798-5865'  CallHour='2' CallMin='54' CallSection='PM' IsRequirefollowup='false' CallerType='Victim' CPSIsChildrenScene='false'  CPSIsChildrenHouseHold='false'  CallRequest='Legal,' Description='Frieda calling again to ask if she should be calling law enforcement since she believes that her husband has a gun and he is a felon. Stated that at a party she saw that her husband got a gun and said that it was for her, but she never saw it again. She recently messaged the friend who she thought her husband got the gun from and the friend confirmed that her husband had infact bought the gun from them. Frieda was encouraged to contact law enforcement.' /><ChildCallerDetails  FirstName='Frieda' LastName='Morales'  PhoneNumber='916-798-5865'  CallHour='11' CallMin='03' CallSection='AM' IsRequirefollowup='false' CallerType='Victim' CPSIsChildrenScene='false'  CPSIsChildrenHouseHold='false'  CallRequest='Legal,' Description='Frieda was requesting to speak with Nicole as follow up to some assistance she received with completing legal documents for custody and divorce. She explained that her husband had filed a TRO against her and currently has custody of their kids and she wanted to file on Monday. I contacted Nicole who was going to follow up with Frieda that afternoon. Returned call to Frieda to tell her to expect call from Nicole.' /><ChildCallerDetails  FirstName='Anastascia' LastName=''  PhoneNumber='916-617-7086'  CallHour='10' CallMin='21' CallSection='AM' IsRequirefollowup='false' CallerType='Victim' CPSIsChildrenScene='false'  CPSIsChildrenHouseHold='false'  CallRequest='Legal,' Description='Anastascia is a frequent caller to crisis line and today she called about wanting to really follow through with completing the paperwork for court for a custody agreement as she is tired of her daughters father trying to control her time with her daughter. I listened and encouraged her to come in if she can for legal support.' /><ChildCallerDetails  FirstName='Lisa' LastName=''  PhoneNumber='530-757-6438'  CallHour='9' CallMin='41' CallSection='PM' IsRequirefollowup='false' CallerType='Victim' CPSIsChildrenScene='false'  CPSIsChildrenHouseHold='false'  CallRequest='Counseling,Other,' Description='Lisa a current client of ACFP with Judi called because she was having flashbacks and was tired of them and thought that she should be over them by now. When I asked her about the flashbacks, she switched topics and said that she was really stressed about getting a notice from Sect. 8 that her rent would increase, I talked with her about whether she felt that the information that HUD had was correct and she said no. I encouraged her to get her information in order and place a call on Monday, and to focus on self care now since the rent was not something she could do anything about until Monday. She agreed to that. When I brought her back around to conversation about flashbacks she said that she had a incident last February and that she doesn t know why she can't move past it. She expressed that she has counseling with Judi Mon or Tues so I encouraged her to bring it up in counsel.' /> </Bulletins>";
                    //XmlDocument doc = new XmlDocument();
                    //                   doc.LoadXml(xml);
                }
                catch (Exception /*ex*/)
                {

                }
                TimeZoneInfo timezone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime dtUTCall = DateTime.UtcNow;
                DateTime dtNow = TimeZoneInfo.ConvertTimeFromUtc(dtUTCall, timezone);

                DateTime dateTime = Convert.ToDateTime("12/13/2013");

                DateTime dtUTC = TimeZoneInfo.ConvertTimeToUtc(dateTime, timezone);
                DateTime other = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
                DateTime dtNow1 = TimeZoneInfo.ConvertTimeFromUtc(dtUTC, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"));

                //string timestr = DateTime.Now.ToString("hh:mm:ss tt");
                //DateTime combinedDate = date.Add(TimeSpan.Parse(timestr));
                string message = "test \\ \" test";
                message = message.Replace("\\", "\\\\").Replace("\"", "\\\"");
                //ReadOnlyCollection<TimeZoneInfo> tzi;
                //tzi = TimeZoneInfo.GetSystemTimeZones();
                //foreach (TimeZoneInfo timeZone in tzi)
                //{
                //    string timezone = timeZone.DaylightName;
                //    TimeSpan offsetFromUtc = timeZone.BaseUtcOffset;
                //    string offsetString = String.Format("{0} hours, {1} minutes", offsetFromUtc.Hours, offsetFromUtc.Minutes);
                //}
                /// *** Google Calendar *** //
                //CalendarService myService = new CalendarService("exampleCo-exampleApp-1");
                //myService.setUserCredentials("malli.nookala@gmail.com", "XXXXX");

                //CalendarQuery query = new CalendarQuery();
                //query.Uri = new Uri("https://www.google.com/calendar/feeds/default/allcalendars/full");
                //CalendarFeed resultFeed = (CalendarFeed)myService.Query(query);


                //string CalendarID = "";


                //foreach (CalendarEntry entry in resultFeed.Entries)
                //{
                //    CalendarID = entry.EditUri.ToString().Substring(entry.EditUri.ToString().LastIndexOf("/") + 1);
                //    string caledarname = entry.Title.Text;
                //    string ThisFeedUri = "http://www.google.com/calendar/feeds/" + CalendarID + "/private/full";
                //    Uri postUri = new Uri(ThisFeedUri);
                //    EventQuery Query = new EventQuery(ThisFeedUri);
                //    EventFeed myResultsFeed = myService.Query(Query) as EventFeed;
                //}


                /// //string apiKey = "d4e19beca2cef7242b3c9e11f08bae1bc30ff72606e8d38b3b9982030aabc722";
                //string url = "http://api.ipinfodb.com/v3/ip-city/?key={0}&ip={1}&format=xml";
                //    //"http://api.ipinfodb.com/v2/ip_query.php?key={0}&ip={1}&timezone=true";

                //url = String.Format(url, apiKey, "115.112.184.252");

                //HttpWebRequest httpWRequest = (HttpWebRequest)WebRequest.Create(url);
                //try
                //{
                //    using (HttpWebResponse httpWResponse = (HttpWebResponse)httpWRequest.GetResponse())
                //    {
                //        XmlTextReader xtr = new XmlTextReader(httpWResponse.GetResponseStream());
                //        DataSet ds = new DataSet();
                //        ds.ReadXml(xtr);
                //      DataTable dt = ds.Tables[0];
                //    }
                //}
                //catch
                //{

                //}

                //SendAppNotifications(10001," text message");
                //FX9MT1

                //int count = 0;
                try
                {
                    //string GoogleAppID = "AIzaSyA3lGgQwAfMoWr004r4KPgr48PeTjzSMTo";
                    //WebRequest tRequest;
                    //tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
                    //tRequest.Method = "POST";
                    //tRequest.ContentType = "application/x-www-form-urlencoded";
                    //tRequest.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));
                    //String collaspeKey = Guid.NewGuid().ToString("n");
                    //String postData = string.Format("registration_id={0}&data.message={1}&collapse_key={2}", "APA91bE-immd0Q2uInbyXOOdbyJ4Xg6qV37S6jxEPbKQLCpIEwxNlJu2YhYcvsOTKltQe1G6Q_-uoYz26P1_mLbuZ7RkqV0EHiLEKZCULsxXFt13Sn_56xekYNzuZ-55-txHrTkKi85Nq5m1d2NL5QTdNwyDk1UreQ", "Testing for android", collaspeKey);
                    //Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    //tRequest.ContentLength = byteArray.Length;

                    //Stream dataStream = tRequest.GetRequestStream();
                    //dataStream.Write(byteArray, 0, byteArray.Length);
                    //dataStream.Close();

                    //WebResponse tResponse = tRequest.GetResponse();

                    //dataStream = tResponse.GetResponseStream();

                    //StreamReader tReader = new StreamReader(dataStream);

                    //String sResponseFromServer = tReader.ReadToEnd();
                    //tReader.Close();
                    //dataStream.Close();
                    //tResponse.Close();
                    //if (sResponseFromServer.Contains("id=0"))
                    //    count = 1;
                }
                catch (Exception /*ex*/)
                {

                }
            }
            catch (Exception ex)
            {

                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "test.aspx.cs", "Page_Load", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public string StringReplaceUrl(string pHtmlString)
        {
            if (pHtmlString.StartsWith("&lt;_"))
            {
                pHtmlString = pHtmlString.Replace("&lt;_", "<");
                pHtmlString = pHtmlString.Replace("&gt;_", ">");
                pHtmlString = pHtmlString.Replace("&quots;_", "'");
            }

            Regex urlRegEx = new Regex("http(s)?://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\/\\?\\.\\:\\;\'\\,]*)?", RegexOptions.IgnoreCase);
            MatchCollection urls = urlRegEx.Matches(pHtmlString);
            foreach (Match url in urls)
            {
                if (pHtmlString.IndexOf(url.ToString()) > 0)
                {
                    var isImgURL = pHtmlString.Substring(Convert.ToInt32(pHtmlString.IndexOf(url.ToString())) - 6, url.Length + 6);
                    if (!isImgURL.Contains("src") && isImgURL.Contains("href"))
                    {
                        if (!isImgURL.ToLower().Contains("upload/locatedimages"))
                        {
                            string shortUrl = objCommon.longurlToshorturl(Convert.ToString(url));
                            if (string.IsNullOrEmpty(shortUrl))
                                shortUrl = Convert.ToString(url);

                            pHtmlString = pHtmlString.Replace(Convert.ToString(url), "<a target='_blank' href='" + shortUrl + "'>" + shortUrl + "</a>");
                        }
                    }
                }
            }
            return pHtmlString;
        }
        protected void imgApprove_Click(object sender, EventArgs e)
        { }
        protected void imgReject_Click(object sender, EventArgs e)
        { }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //bool isRecurring = chkRecurring.Checked;
        }
        public void SendAppNotifications(int profileID, string message)
        {
            try
            {
                int totalSendCount = 0;
                string deviceIds = string.Empty;
                StringBuilder strBuilder = new StringBuilder();
                string pemfile = string.Empty;
                DataTable dtDevices = objMobile.GetDevicesforNotifications(profileID, 0, "General");
                if (dtDevices.Rows.Count > 0)
                {
                    totalSendCount = 0;
                    deviceIds = "";
                    int appId = 0;
                    int id = 0;
                    for (int i = 0; i < dtDevices.Rows.Count; i++)
                    {
                        int returnvalue = 0;
                        if (dtDevices.Rows[i]["Device_Type"].ToString().ToLower().Contains("android"))
                        {
                            if (!string.IsNullOrEmpty(dtDevices.Rows[i]["Device_ID"].ToString()))
                            {
                                returnvalue = SendAndroidNotifications();
                            }
                        }
                        else if (dtDevices.Rows[i]["Device_Type"].ToString().ToLower().Contains("iphone"))
                        {
                            if (appId != id && strBuilder.Length > 0)
                            {
                                SendIPhoneNotifications(strBuilder, message, pemfile);
                                id = Convert.ToInt32(dtDevices.Rows[i]["App_ID"].ToString());
                                strBuilder.Length = 0;
                            }
                            if (!string.IsNullOrEmpty(dtDevices.Rows[i]["Device_ID"].ToString()))
                            {
                                if (strBuilder.Length == 0)
                                {
                                    strBuilder.Append("\"" + dtDevices.Rows[i]["Device_ID"].ToString() + "\"");
                                    pemfile = dtDevices.Rows[i]["PemFile_Name"].ToString();
                                }
                                else
                                {
                                    strBuilder.Append(",\"" + dtDevices.Rows[i]["Device_ID"].ToString() + "\"");
                                    if (pemfile == "")
                                        pemfile = dtDevices.Rows[i]["PemFile_Name"].ToString();

                                }
                            }
                            appId = Convert.ToInt32(dtDevices.Rows[i]["App_ID"].ToString());
                        }
                        else if (dtDevices.Rows[i]["Device_Type"].ToString().ToLower().Contains("windowsphone"))
                        {
                            try
                            {

                            }
                            catch (Exception /*ex*/)
                            {

                            }
                        }

                        if (returnvalue == 1)
                        {
                            if (deviceIds == "")
                                deviceIds = "\"" + dtDevices.Rows[i]["BDID"].ToString() + "\"";
                            else
                                deviceIds = deviceIds + ",\"" + dtDevices.Rows[i]["BDID"].ToString() + "\"";
                        }
                        totalSendCount += returnvalue;
                    }
                    if (strBuilder.Length > 0)
                    {
                        SendIPhoneNotifications(strBuilder, message, pemfile);
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "test.aspx.cs", "SendAppNotifications", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private void SendWindowsNotification()
        {
            try
            {

                string message = "Over the years of developing software for many different inrealized the need for an affordable, easy to use two way communication system designed for law enforcement agencies with all the features on one platform. USPDhub is the result of that knowledge. LogicTree IT continues to develop new features based on requests from agencies and makes them available through USPDhub.";
                string altmessage = "Over the years of developing software for many different inrealized the need for an affordable, easy to use two way communication system designed for law enforcement agencies with all the features on one platform. USPDhub is the result of that knowledge. LogicTree IT continues to develop new features based on requests from agencies and makes them available through USPDhub.";
                string channelURI = "http://am3.notify.live.net/throttledthirdparty/01.00/AQHvAdl9LqWbR5IQc_9U-VHUAgAAAAADmgAAAAQUZm52OkJCMjg1QTg1QkZDMkUxREQFBkVVTk8wMQ";
                string windowsurl = "/Notifications.xaml?PID=10222&amp;SentDate=" + DateTime.Now + "&amp;PushMessage=##WPMESSAGE##&amp;PushType=General&amp;PushTypeID=3944&amp;TabName=General";
                string windowsmsg = message;
                if (((windowsurl.Length - 13) + message.Length) > 256)
                    windowsmsg = message.Substring(0, 256 - (windowsurl.Length - 13));
                windowsurl = windowsurl.Replace("##WPMESSAGE##", windowsmsg);
                altmessage = altmessage.Substring(0, 250);
                int length = windowsurl.Length;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(channelURI);
                request.Method = "POST";
                request.ContentType = "text/xml";
                request.Headers = new WebHeaderCollection();
                request.Headers.Add("X-NotificationClass", "2");
                request.Headers.Add("X-WindowsPhone-Target", "toast");
                string notificationData = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                        "<wp:Notification xmlns:wp=\"WPNotification\">" +
                                        "<wp:Toast>" +
                                        "<wp:Text2>" + altmessage + "</wp:Text2>" +
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
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "test.aspx.cs", "SendWindowsNotification", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

        private int SendAndroidNotifications()
        {
            int count = 0;
            try
            {
                string GoogleAppID = "AIzaSyA3lGgQwAfMoWr004r4KPgr48PeTjzSMTo";
                WebRequest tRequest;
                tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
                tRequest.Method = "POST";
                tRequest.ContentType = "application/x-www-form-urlencoded";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));
                String collaspeKey = Guid.NewGuid().ToString("n");
                String postData = string.Format("registration_id={0}&data.message={1}&data.SentDate=" + DateTime.Now + "&data.ProfileID=10271&collapse_key={2}", "APA91bHr6bio8ok870zFS8Y6fXGjiGYUolsIvRrmwx1a0QoQ4OsxCGHSuU10cPysPenwYh9j6ZxlxDk6LjiM-ZZIN55gTqG_mBI3a-kkg9GLVdJgt401oceMmMdbOigjBPrduzxA2Pgv", "teesting for android", collaspeKey);
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
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "test.aspx.cs", "SendAndroidNotifications", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            return count;
        }

        private void SendIPhoneNotifications(StringBuilder strBuilder, string message, string pemfile)
        {

            ErrorHandling("Sending Iphone Notification", "SendIPhoneNotifications", "WindowsPhone", strBuilder.ToString() + "- " + pemfile, "", "", "");
            try
            {
                HttpWebResponse objHttpWebResponse = null;
                UTF8Encoding encoding;

                HttpWebRequest objHttpWebRequest;
                objHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://excove.net/uspdhub/pushnotification.php");
                objHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
                objHttpWebRequest.PreAuthenticate = true;

                objHttpWebRequest.Method = "POST";
                string json = "data={\"message\":\"" + message + "\"," + "\"devices\":[" + strBuilder.ToString() + "]" + ",\"PemFile\":\"" + pemfile + "\"}";
                //Prepare the request stream       
                encoding = new UTF8Encoding();
                Stream objStream = objHttpWebRequest.GetRequestStream();
                Byte[] buffer = encoding.GetBytes(json);
                // Post the request 
                objStream.Write(buffer, 0, buffer.Length);
                objStream.Close();
                objHttpWebResponse = (HttpWebResponse)objHttpWebRequest.GetResponse();

                encoding = new UTF8Encoding();

                objHttpWebResponse.Close();

                objHttpWebRequest = null;
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "test.aspx.cs", "SendIPhoneNotifications", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        public void ErrorHandling(string errorType, string pPageName, string methodName, string message, string strackTrace, string innerException, string data)
        {

            string strLogFile = "";
            string errorLogFolder = Server.MapPath("~") + "\\Upload\\ErrorLog\\";

            if (!Directory.Exists(errorLogFolder))
            {
                Directory.CreateDirectory(errorLogFolder);
            }

            strLogFile = errorLogFolder + "\\SendWindowsNotificatioons.txt";

            StreamWriter oSW;
            if (File.Exists(strLogFile))
            {
                oSW = new StreamWriter(strLogFile, true);
            }
            else
            {
                oSW = File.CreateText(strLogFile);
            }

            oSW.WriteLine("================================" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "================================");
            oSW.WriteLine(" ");
            oSW.WriteLine("Type : " + errorType);
            oSW.WriteLine(" ");
            oSW.WriteLine("Page Name : " + pPageName);
            oSW.WriteLine(" ");
            oSW.WriteLine("Method Name : " + methodName);
            oSW.WriteLine(" ");
            oSW.WriteLine("MESSAGE : " + message);
            oSW.WriteLine(" ");
            oSW.WriteLine("STACKTRACE : " + strackTrace);
            oSW.WriteLine(" ");
            oSW.WriteLine("INNEREXCEPTION : " + innerException);
            oSW.WriteLine(" ");
            oSW.WriteLine("DATA : " + data);
            oSW.WriteLine(" ");
            oSW.Close();
            oSW.Dispose();

        }
    }
}