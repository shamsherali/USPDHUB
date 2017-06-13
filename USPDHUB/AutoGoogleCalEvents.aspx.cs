using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using System.Net;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Web;
using USPDHUBBLL;

namespace USPDHUB
{
    public partial class AutoGoogleCalEvents : System.Web.UI.Page
    {
        CalendarService service;
        static string gFolder = System.Web.HttpContext.Current.Server.MapPath("/App_Data/MyGoogleStorage");
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            Random random = new Random();
            ClientSecrets secrets = new ClientSecrets
            {
                ClientId = "889028934349-boqc5bifbno8tivitv4neb5shheem7ft.apps.googleusercontent.com",
                ClientSecret = "-H_S5m3JbDvVeEZuiEqHBEG2"
            };
            string userEmail = "user"+Convert.ToString(random.Next(1000, 9999));
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, new string[] { CalendarService.Scope.Calendar }, userEmail, CancellationToken.None).Result;
            var initializer = new BaseClientService.Initializer();
            initializer.HttpClientInitializer = credential;
            initializer.ApplicationName = "MyAppTest";
            service = new CalendarService(initializer);

            IList<CalendarListEntry> list = service.CalendarList.List().Execute().Items;    // Fetch the list of calendar list            
            DisplayList(list);  // Display all calendars
            foreach (CalendarListEntry calendar in list)
            {
                DisplayFirstCalendarEvents(calendar);   // Display calendar's events
            }
            */
            try
            {
                IAuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow(
                new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = GetClientConfiguration().Secrets,
                    DataStore = new FileDataStore(gFolder),
                    Scopes = new[] { CalendarService.Scope.Calendar }
                });

                var uri = Request.Url.ToString();
                var code = Request["code"];
                string UserId = "user" + Guid.NewGuid();
                if (code != null)
                {
                    var token = flow.ExchangeCodeForTokenAsync(UserId, code,
                        uri.Substring(0, uri.IndexOf("?")), CancellationToken.None).Result;

                    // Extract the right state.
                    var oauthState = AuthWebUtility.ExtracRedirectFromState(
                        flow.DataStore, UserId, Request["state"]).Result;
                    Response.Redirect(oauthState);
                }
                else
                {
                    var result = new AuthorizationCodeWebApp(flow, uri, uri).AuthorizeAsync(UserId,
                        CancellationToken.None).Result;
                    if (result.RedirectUri != null)
                    {
                        // Redirect the user to the authorization server.
                        Response.Redirect(result.RedirectUri);
                    }
                    else
                    {
                        // The data store contains the user credential, so the user has been already authenticated.
                        service = new CalendarService(new BaseClientService.Initializer
                        {
                            ApplicationName = "MyAppTest",
                            HttpClientInitializer = result.Credential
                        });


                        IList<CalendarListEntry> list = service.CalendarList.List().Execute().Items;    // Fetch the list of calendar list            
                        DisplayList(list);  // Display all calendars
                        foreach (CalendarListEntry calendar in list)
                        {
                            DisplayFirstCalendarEvents(calendar);   // Display calendar's events
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AutoGoogleCalEvents.aspx.cs", "AutoGoogleCalEvents", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }


        public static GoogleClientSecrets GetClientConfiguration()
        {
            using (var stream = new FileStream(gFolder + @"\localhost_client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                return GoogleClientSecrets.Load(stream);
            }
        }


        private void DisplayList(IList<CalendarListEntry> list)  // Displays all calendars
        {
            Response.Write("Lists of calendars:<br/>");
            foreach (CalendarListEntry item in list)
            {
                Response.Write("<span style='padding-left:30px;'>Summary:       </span>" + item.Summary);
                Response.Write("<span style='padding-left:30px;'>Location:      </span>" + item.Location);
                Response.Write("<span style='padding-left:30px;'>TimeZone:      </span>" + item.TimeZone + "<br/>");
            }
        }


        private void DisplayFirstCalendarEvents(CalendarListEntry list)     // Displays the calendar's events
        {
            Response.Write(Environment.NewLine + "Maximum 5 first events from:" + list.Summary + "<br/>");
            EventsResource.ListRequest requeust = service.Events.List(list.Id);
            //requeust.MaxResults = 5;    //Set MaxResults and TimeMin with sample values
            requeust.TimeMin = new DateTime(2013, 01, 1, 00, 0, 0);
            foreach (Event calendarEvent in requeust.Execute().Items)   // Fetch the list of events
            {
                Response.Write("<span style='padding-left:30px;'>Summary:   </span>" + calendarEvent.Summary + "<br/>");

            }
        }
    }
}