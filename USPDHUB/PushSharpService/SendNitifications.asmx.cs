using System;
using System.Linq;
using System.Web.Services;
using System.IO;
using System.Text;
using System.Data;
using USPDHUBBLL;
using System.Configuration;
using System.Net;

namespace USPDHUB.PushSharpService
{
    /// <summary>
    /// Summary description for SendNitifications
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SendNitifications : System.Web.Services.WebService
    {
        MServiceBLL objMobile = new MServiceBLL();
        [WebMethod]
        public void SendAppNotifications(int _ProfileID, string message, DateTime _sentdate, string _pushType, int _pushTypeID)
        {
            try
            {
                // *** If anyone change the code here please make changes in windows service as well *** //
                message = message.Replace("&", "and").Replace("<", "");
                int totalSendCount = 0;
                string DeviceIDS = string.Empty;
                string appVersion = "";
                StringBuilder strBuilder = new StringBuilder();
                StringBuilder strBuilderOld = new StringBuilder();
                string pemfile = string.Empty;
                string pemfileOld = string.Empty;
                string DeviceIDSOld = string.Empty;
                string tabName = "";
                string windowsurl = "";
                string altMessage = "";
                if (_pushType != "General")
                {
                    tabName = objMobile.GetPushTypeTabName(_ProfileID, _pushType, _pushTypeID);
                }
                DataTable dtDevices = objMobile.GetDevicesforNotifications(_ProfileID, _pushTypeID, _pushType);

                if (dtDevices.Rows.Count > 0)
                {
                    totalSendCount = 0;
                    DeviceIDS = "";
                    int AppId = 0;
                    int ID = 0;
                    int AppIdOld = 0;
                    int IDOld = 0;
                    string androidmessage = message + "##ProfileSeparator##" + _ProfileID.ToString();
                    string windowsmsg = "";
                    int iphoneDevicesCount = 0;
                    int iphoneDevicesCountOld = 0;
                    for (int i = 0; i < dtDevices.Rows.Count; i++)
                    {
                        int returnvalue = 0;
                        if (dtDevices.Rows[i]["Device_Type"].ToString().ToLower().Contains("android"))
                        {
                            if (!string.IsNullOrEmpty(dtDevices.Rows[i]["Device_ID"].ToString()))
                            {
                                returnvalue = SendAndroidNotifications(dtDevices.Rows[i]["Device_ID"].ToString(), androidmessage, _sentdate, _ProfileID, _pushType, _pushTypeID, tabName);
                            }
                        }
                        else if (dtDevices.Rows[i]["Device_Type"].ToString().ToLower().Contains("iphone"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(dtDevices.Rows[i]["AppVersion"])))
                                appVersion = Convert.ToString(dtDevices.Rows[i]["AppVersion"]);
                            else
                                appVersion = "";
                            if (appVersion != "")
                            {
                                AppId = Convert.ToInt32(dtDevices.Rows[i]["App_ID"].ToString());
                                if (ID == 0)
                                    ID = AppId;
                                if ((AppId != ID || iphoneDevicesCount >= 25) && strBuilder.Length > 0)
                                {
                                    SendIPhoneNotifications(strBuilder, message, pemfile, _ProfileID, _sentdate, _pushType, _pushTypeID, tabName);
                                    iphoneDevicesCount = 0;
                                    ID = AppId;
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
                                iphoneDevicesCount += 1;
                            }
                            else
                            {
                                AppIdOld = Convert.ToInt32(dtDevices.Rows[i]["App_ID"].ToString());
                                if (IDOld == 0)
                                    IDOld = AppIdOld;
                                if ((AppIdOld != IDOld || iphoneDevicesCountOld >= 25) && strBuilderOld.Length > 0)
                                {
                                    SendIPhoneNotifications(strBuilderOld, message, pemfileOld, _ProfileID, _sentdate, _pushType, _pushTypeID, tabName);
                                    iphoneDevicesCountOld = 0;
                                    IDOld = AppIdOld;
                                    strBuilderOld.Length = 0;
                                }
                                if (!string.IsNullOrEmpty(dtDevices.Rows[i]["Device_ID"].ToString()))
                                {
                                    if (strBuilderOld.Length == 0)
                                    {
                                        strBuilderOld.Append("\"" + dtDevices.Rows[i]["Device_ID"].ToString() + "\"");
                                        pemfileOld = dtDevices.Rows[i]["PemFile_Name"].ToString().Replace(".pem", "1.pem");
                                    }
                                    else
                                    {
                                        strBuilderOld.Append(",\"" + dtDevices.Rows[i]["Device_ID"].ToString() + "\"");
                                        if (pemfileOld == "")
                                            pemfileOld = dtDevices.Rows[i]["PemFile_Name"].ToString().Replace(".pem", "1.pem");
                                    }
                                }
                                iphoneDevicesCountOld += 1;
                            }
                        }
                        else if (dtDevices.Rows[i]["Device_Type"].ToString().ToLower().Contains("windowsphone"))
                        {
                            appVersion = Convert.ToString(dtDevices.Rows[i]["AppVersion"]);
                            altMessage = message;
                            if (message.Length > 250)
                                altMessage = message.Substring(0, 250);
                            windowsurl = "/Notifications.xaml?PID=" + _ProfileID.ToString() + "&amp;SentDate=" + _sentdate + "&amp;PushMessage=##WPMESSAGE##&amp;PushType=" + _pushType + "&amp;PushTypeID=" + _pushTypeID.ToString();
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
                                string channelURI = dtDevices.Rows[i]["Device_ID"].ToString();
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
                            catch (Exception /*ex*/)
                            {
                                //string msg = "";
                                //ErrorHandling("Sending Windows Notification", "Service", "WindowsPhone", ex.Message.ToString(), "", "", "");
                            }
                        }

                        if (returnvalue == 1)
                        {
                            if (DeviceIDS == "")
                                DeviceIDS = "\"" + dtDevices.Rows[i]["BDID"].ToString() + "\"";
                            else
                                DeviceIDS = DeviceIDS + ",\"" + dtDevices.Rows[i]["BDID"].ToString() + "\"";
                        }
                        totalSendCount += returnvalue;
                    }
                    if (strBuilder.Length > 0)
                    {
                        SendIPhoneNotifications(strBuilder, message, pemfile, _ProfileID, _sentdate, _pushType, _pushTypeID, tabName);
                    }
                    if (strBuilderOld.Length > 0)
                    {
                        SendIPhoneNotifications(strBuilderOld, message, pemfileOld, _ProfileID, _sentdate, _pushType, _pushTypeID, tabName);
                    }
                }
            }
            catch (Exception /*ex*/)
            {

            }
        }
        private int SendAndroidNotifications(string DeviceID, string message, DateTime sentDate, int profileID, string pushType, int pushTypeID, string tabName)
        {
            int count = 0;
            try
            {
                string GoogleAppID = ConfigurationManager.AppSettings["AndroidAPI"];
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
            catch (Exception /*ex*/)
            {

            }
            return count;
        }
        private void SendIPhoneNotifications(StringBuilder strBuilder, string message, string pemfile, int profileID, DateTime sentDate, string pushType, int pushTypeID, string tabName)
        {

            try
            {
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
            }
            catch (Exception /*ex*/)
            {

            }
        }
        public void ErrorHandling(string ErrorType, string pPageName, string MethodName, string Message, string StrackTrace, string InnerException, string Data)
        {
            string strLogFile = "";
            string ErrorLogFolder = Server.MapPath("~") + "\\Upload\\ErrorLog\\";

            if (!Directory.Exists(ErrorLogFolder))
            {
                Directory.CreateDirectory(ErrorLogFolder);
            }

            strLogFile = ErrorLogFolder + "\\SendWindowsNotificatioons.txt";

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
            oSW.WriteLine("Type : " + ErrorType);
            oSW.WriteLine(" ");
            oSW.WriteLine("Page Name : " + pPageName);
            oSW.WriteLine(" ");
            oSW.WriteLine("Method Name : " + MethodName);
            oSW.WriteLine(" ");
            oSW.WriteLine("MESSAGE : " + Message);
            oSW.WriteLine(" ");
            oSW.WriteLine("STACKTRACE : " + StrackTrace);
            oSW.WriteLine(" ");
            oSW.WriteLine("INNEREXCEPTION : " + InnerException);
            oSW.WriteLine(" ");
            oSW.WriteLine("DATA : " + Data);
            oSW.WriteLine(" ");
            oSW.Close();
        }



    }
}