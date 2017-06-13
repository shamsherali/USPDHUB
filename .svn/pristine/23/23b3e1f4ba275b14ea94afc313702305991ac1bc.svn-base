using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NotificationHub_POC
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  /*

             IList<RegistrationDescription> ios_List = list.Result.ToList().Where(row => row.ETag == "1").ToList();



            //  Tags Property for Conditional wise... For Push or get data
            if (pDevicetype == "IOS")
            {
                // 9201a182403e97d155ed69c88599cec3002a919642999e6dbfd5dbd2ac247132

                //List<string> tags = new List<string>();
                //tags.Add("PID:10001,UID:125");

                // Max Tags 20
                List<string> tags = new List<string>();
                tags.Add("PID:10002,AppID:1");

                var output = objNotificationHubClient.GetRegistrationsByTagAsync("AppID:1", 10);
                Task.WaitAll(output);


                var res = objNotificationHubClient.CreateAppleNativeRegistrationAsync(pDevicePushToken, tags);
                Task.WaitAll(res);




                string json = "{ \"aps\": { \"alert\":\"" + pPushMessage+"   -   "+DateTime.Now + "\",\"sound\":\"" + "default" + "\" }, \"PushType\":\"" + "systempush" + "\", \"TabName\":\"" + "Quote of Day" + "\", \"message\":\"" + "Quote of Day" + "\", \"body\":\"" + "Quote of Day" + "\"  }";


                string reque = "{ \"aps\": { \"alert\": \"Good evening!\"}}";


                
                 //Send Push Notification only one device by using Tag other all device will be sent messages
                var temp = objNotificationHubClient.SendAppleNativeNotificationAsync(json, "AppID:1");
                Task.WaitAll(temp);

            }
            else if (pDevicetype == "Android")
            {
                // cn_9JG6wQTQ:APA91bGLci0JYIePKLociRx81sOgCbcC0JGbCASU_Qk8esqRtfeCAIdtEDqyYHzXyPoUHQwIJSbBf8s-ZsWO5e0Sj91buCdkY3NzGF9gNPj7xXIi8L81w1y1qLO6WcveDfWNa-6Kmrm7
                var res = objNotificationHubClient.CreateGcmNativeRegistrationAsync(pDevicePushToken, null);
                Task.WaitAll(res);

                //"{ 'data':{ 'message' : 'hello world'  } }"
                var temp = hub1.SendGcmNativeNotificationAsync("{'data':{'message':'"+ pPushMessage + "','ProfileID':'10151'}}");
                Task.WaitAll(temp);
            }
            else if (pDevicetype == "Windows")
            {
               // pDevicePushToken = "http://s.notify.live.net/u/1/hk2/H2QAAAAsB4Sp_34lPouMh4_5jIyC3VidWFKcBtxnaJ6p_QfvnEAdf8J1VSKjZLgXcgrTapj_0mKkG9JgLBGkXd9k9yn5VdCfKwea23CQORik4jVWXIHPemcHKIUc_Qa757Iuw6U/d2luZG93c3Bob25lZGVmYXVsdA/Is86_pWTQU-wxbLEM5lhEw/QtIhRo-KyTZsRLPjwEq-f4sb040";



                // http://s.notify.live.net/u/1/hk2/H2QAAAAsB4Sp_34lPouMh4_5jIyC3VidWFKcBtxnaJ6p_QfvnEAdf8J1VSKjZLgXcgrTapj_0mKkG9JgLBGkXd9k9yn5VdCfKwea23CQORik4jVWXIHPemcHKIUc_Qa757Iuw6U/d2luZG93c3Bob25lZGVmYXVsdA/Is86_pWTQU-wxbLEM5lhEw/QtIhRo-KyTZsRLPjwEq-f4sb040

             

                var res = hub1.CreateMpnsNativeRegistrationAsync(pDevicePushToken);

                Task.WaitAll(res);

                string pWindowsUrl = "/Notifications.xaml?PushNotificationType=systempush&amp;message=hai&amp;QuotesTitle=quote of the day";
                string requestFormat = "<?xml version='1.0' encoding='utf-8'?><wp:Notification xmlns:wp='WPNotification'><wp:Toast>"
              + "<wp:Text1></wp:Text1> <wp:Param>" + pWindowsUrl + "</wp:Param> </wp:Toast></wp:Notification>";


                var temp = objNotificationHubClient.SendMpnsNativeNotificationAsync(requestFormat);
                Task.WaitAll(temp);



            }

            */

        }
    }
}