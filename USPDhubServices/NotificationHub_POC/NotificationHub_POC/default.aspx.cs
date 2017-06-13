using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace NotificationHub_POC
{
    public partial class _default : System.Web.UI.Page
    {
        public string PushType = "General";
        public int PushTypeID = 0;
        string regId = "";
        string NotificationHubConnStr = ConfigurationManager.AppSettings.Get("NotificationHubConnStr");
        string NotificationHub_Name = ConfigurationManager.AppSettings.Get("NotificationHub_Name");
        int PID = Convert.ToInt32(ConfigurationManager.AppSettings.Get("PID"));
        int UID = Convert.ToInt32(ConfigurationManager.AppSettings.Get("UID"));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
                LoadProfileName();
                DataTable dtProfileTabs = MServiceDAL.GetProfileTabsByProfileID(PID, "", 0);
                ddlTabName.DataSource = dtProfileTabs;
                ddlTabName.DataTextField = "TabName";
                ddlTabName.DataValueField = "UserModuleID";
                ddlTabName.DataBind();
            }
        }
        private void LoadProfileName()
        {
            DataTable dtProfile = MServiceDAL.GetProfileDetailsByProfileID(PID);
            if (dtProfile.Rows.Count > 0)
            {
                txtPushMesssage.Text = dtProfile.Rows[0]["Profile_name"].ToString();
            }
        }
        private void insertDevices()
        {
            NotificationHubClient objNotificationHubClient =
                                NotificationHubClient.CreateClientFromConnectionString(NotificationHubConnStr, NotificationHub_Name);
            for (int i = 1; i <= 500; i++)
            {
                List<string> parameters = new List<string>();
                // ***  Start of Common tags for all device id's *** //
                parameters.Add("PID:" + "10151");
                parameters.Add("AppID:" + "54");
                parameters.Add("UniqueID:" + "81b346d47c5db692");
                parameters.Add("AppVersion:" + "2.7.5");
                parameters.Add("BDID:" + i);
                parameters.Add("SlotID:" + "10151_1");
                var response = objNotificationHubClient.CreateGcmNativeRegistrationAsync("APA91bH2qvUjPWVPWKFaMD2zpVyBWsfnAiVQQDQ0W5zI1ct4UGnWz27ztSn5haEzcoK4utKYPJIu7eeFSLsBru - Zdr4dKbn52fCBnDzXE - h3r0S8DOJZ3H6fkO - lIp93EreTdFZ4xhPY", parameters);
                Task.WaitAll(response);

            }

        }

        //method to get bulk registrations using tags
        public async Task<List<RegistrationDescription>> GetAllRegisteredDevicesAsync()
        {
            NotificationHubClient objNotificationHubClient =
                                     NotificationHubClient.CreateClientFromConnectionString(NotificationHubConnStr, NotificationHub_Name);

            var allRegistrations = await objNotificationHubClient.GetRegistrationsByTagAsync("PID:10271", 10000);

            var continuationToken = allRegistrations.ContinuationToken;
            var registrationsList = new List<RegistrationDescription>();
            if (allRegistrations.ToList().Count() > 0)
                registrationsList.AddRange(allRegistrations);
            //foreach (var objRegistration in allRegistrations.ToList())
            //{
            //    await objNotificationHubClient.DeleteRegistrationAsync(objRegistration);
            //}
            while (!string.IsNullOrWhiteSpace(continuationToken))
            {
                var otherRegistrations = await objNotificationHubClient.GetRegistrationsByTagAsync("PID:10151", continuationToken, 10000);
                registrationsList.AddRange(otherRegistrations);
                //foreach (var objRegistration in otherRegistrations.ToList())
                //{                    
                //    await objNotificationHubClient.DeleteRegistrationAsync(objRegistration);
                //}
                continuationToken = otherRegistrations.ContinuationToken;
            }

            return registrationsList;
        }

        protected void lnkActivatePrivate_Click(object sender, EventArgs e)
        {
            NotificationHubClient objNotificationHubClient =
                                NotificationHubClient.CreateClientFromConnectionString(NotificationHubConnStr, NotificationHub_Name);
            string pDeviceID = "APA91bH2qvUjPWVPWKFaMD2zpVyBWsfnAiVQQDQ0W5zI1ct4UGnWz27ztSn5haEzcoK4utKYPJIu7eeFSLsBru-Zdr4dKbn52fCBnDzXE-h3r0S8DOJZ3H6fkO-lIp93EreTdFZ4xhPY";
            List<string> parameters = new List<string>();
            // ***  Start of Common tags for all device id's *** //
            parameters.Add("PID:" + PID);
            parameters.Add("AppID:" + "54");
            parameters.Add("UniqueID:" + "");
            parameters.Add("AppVersion:" + "2.7.5");
            parameters.Add("BDID:" + "0");
            // ***  End of Common tags for all device id's *** //
            parameters.Add("UMID:" + "12");

            var list = objNotificationHubClient.GetRegistrationsByChannelAsync(pDeviceID, 100000);
            Task.WaitAll(list);
            if (list.Result.ToList().Count > 0)
            {
                foreach (var objReg1 in list.Result.ToList())
                {
                    string type = objReg1.GetType().Name;
                    if (objReg1.Tags.Contains("PID:10151") && objReg1.Tags.Contains("AppID:100"))
                    {
                        regId = objReg1.RegistrationId;

                        if (type == "AppleRegistrationDescription")
                        {
                            RegistrationDescription objReg = new AppleRegistrationDescription(pDeviceID, parameters);
                            objReg.RegistrationId = regId;
                            var respon = objNotificationHubClient.CreateOrUpdateRegistrationAsync(objReg);
                            Task.WaitAll(respon);
                        }
                        else if (type == "GcmRegistrationDescription")
                        {
                            RegistrationDescription objReg = new GcmRegistrationDescription(pDeviceID, parameters);
                            objReg.RegistrationId = regId;
                            var respon = objNotificationHubClient.CreateOrUpdateRegistrationAsync(objReg);
                            Task.WaitAll(respon);
                        }
                        else
                        {
                            RegistrationDescription objReg = new MpnsRegistrationDescription(pDeviceID, parameters);
                            objReg.RegistrationId = regId;
                            var respon = objNotificationHubClient.CreateOrUpdateRegistrationAsync(objReg);
                            Task.WaitAll(respon);
                        }
                        break;
                    }
                }
            }
            else
            {
                int availableSlot = 1;
                parameters.Add("SlotID:" + PID + "_" + availableSlot);
                var response = objNotificationHubClient.CreateGcmNativeRegistrationAsync(pDeviceID, parameters);
                Task.WaitAll(response);

            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            // Tag Single Tag
            // Tag Express means multiple tags like && and, || OR  PID:10151&&UniqueID:3abc4c09e584d008

            NotificationHubClient objNotificationHubClient =
            NotificationHubClient.CreateClientFromConnectionString(NotificationHubConnStr, NotificationHub_Name);

            if (ddlTabName.SelectedValue != "")
            {
                DataTable dtTabDetails = MServiceDAL.GetUsermoduleDetailsByID(Convert.ToInt32(ddlTabName.SelectedValue));
            }

            string pPushMessage = txtPushMesssage.Text.Trim();
            string pushSendType = "PushNotification";
            int pushID = MServiceDAL.AddPushNotifications(pPushMessage, PID, UID, 0, 0, "", 0, PushType, PushTypeID, 1, DateTime.Now, pushSendType);

            string tags = "PID:" + PID;

            
            #region IOS Push
            //string IOS_Str = "{ \"aps\": { \"alert\":\"" + pPushMessage + "\",\"sound\":\"" + "default" + "\" }, \"PushType\":\"" + "systempush" + "\", \"TabName\":\"" + "Quote of Day" + "\", \"message\":\"" + "Quote of Day" + "\", \"body\":\"" + "Quote of Day" + "\"  }";
            string IOS_Str = "{ \"aps\": { \"alert\":\"" + pPushMessage + "\",\"sound\":\"" + "default" + "\" }, \"agencyId\":\"" + PID + "\", \"SentDate\":\"" + DateTime.Now + "\", \"PushType\":\"" + "General" + "\", \"PushTypeID\":\"" + "0" + "\", \"TabName\":\"" + "" + "\"  }";

            var result = objNotificationHubClient.SendAppleNativeNotificationAsync(IOS_Str, tags);
            Task.WaitAll(result);
            #endregion

            #region Android Push
            string Android_Str = "{'data':{'message':'" + pPushMessage + "','SentDate':'" + DateTime.Now + "','ProfileID':'" + PID + "','PushTypeID':'" + 0 + "','PushType':'" + "General" + "','TabName':'" + "" + "'}}";
            var androidresult = objNotificationHubClient.SendGcmNativeNotificationAsync(Android_Str, tags);
            Task.WaitAll(androidresult);
            #endregion

            #region Windows Push
            string pWindowsUrl = "";
            pWindowsUrl = "/Notifications.xaml?PID=" + PID + "&amp;SentDate=" + DateTime.Now + "&amp;PushMessage=" + pPushMessage + "&amp;PushType=" + "General" + "&amp;PushTypeID=" + "0";
            string notificationData = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                                             "<wp:Notification xmlns:wp=\"WPNotification\">" +
                                                             "<wp:Toast>" +
                                                             "<wp:Text2>" + pPushMessage + "</wp:Text2>" +
                                                             "<wp:Param>" + pWindowsUrl + "</wp:Param>" +
                                                             "</wp:Toast> " +
                                                             "</wp:Notification>";
            var temp = objNotificationHubClient.SendMpnsNativeNotificationAsync(notificationData, tags);
            Task.WaitAll(temp);
            #endregion

            lblMessage.Text = "<font color='green'>" + ConfigurationManager.AppSettings.Get("SuccessMSG") + "</font>";
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            // insertDevices();
            var getList = GetAllRegisteredDevicesAsync();
            lblList.Text = getList.Result.Count.ToString();

        }

        //scheduling Push
        protected void btnschedule_Click(object sender, EventArgs e)
        {
            NotificationHubClient objNotificationHubClient =
            NotificationHubClient.CreateClientFromConnectionString(NotificationHubConnStr, NotificationHub_Name);
            Notification notification = new AppleNotification("{\"aps\":{\"alert\":\"Scheduled Push!\"}}");
            var scheduled = objNotificationHubClient.ScheduleNotificationAsync(notification, new DateTime(2016, 2, 24, 9, 30, 0));
            Task.WaitAll(scheduled);

        }
    }
}