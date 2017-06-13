using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Facebook;
using System.Net;
using System.IO;
using USPDHUBBLL;
using System.Data;
using Newtonsoft.Json;

namespace USPDHUB
{
    public partial class AutoShareToBook : System.Web.UI.Page
    {
        string appID = string.Empty;    //Facebook App ID and Secret
        string appSecret = string.Empty;
        string fbScope = "public_profile,publish_actions,publish_stream,manage_pages";
        string DomainName = "";
        SocialMediaAutoShareBLL fop = new SocialMediaAutoShareBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            DomainName = "localhost";
            GetFacebookAppDetails();
            if (Request["code"] == null)
                Response.Redirect("https://graph.facebook.com/oauth/authorize?client_id=" + appID + "&redirect_uri=" + Request.Url.AbsoluteUri + "&scope=" + fbScope);
            else
                ShareOnFacebook();
        }
        private void GetFacebookAppDetails()
        {
            try
            {
                if (DomainName.ToLower().Contains("uspdhub"))
                {
                    appID = ConfigurationManager.AppSettings.Get("FacebookUSPDAppID");
                    appSecret = ConfigurationManager.AppSettings.Get("FacebookUSPDAppSecret");
                }
                else if (DomainName.ToLower().Contains("twovie"))
                {
                    appID = ConfigurationManager.AppSettings.Get("FacebookTwovieAppID");
                    appSecret = ConfigurationManager.AppSettings.Get("FacebookTwovieAppSecret");
                }
                else if (DomainName.ToLower().Contains("myyouthhub"))
                {
                    appID = ConfigurationManager.AppSettings.Get("FacebookMYHAppID");
                    appSecret = ConfigurationManager.AppSettings.Get("FacebookMYHAppSecret");
                }
                else if (DomainName.ToLower().Contains("inschoolhub"))
                {
                    appID = ConfigurationManager.AppSettings.Get("FacebookISHAppID");
                    appSecret = ConfigurationManager.AppSettings.Get("FacebookISHAppSecret");
                }
                else
                {
                    appID = ConfigurationManager.AppSettings.Get("FacebookAppID");    //Facebook App ID and Secret
                    appSecret = ConfigurationManager.AppSettings.Get("FacebookAppSecret");
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AutoShareToBook.aspx.cs", "GetFacebookAppDetails", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void ShareOnFacebook()
        {
            try
            {
                int pageCount = 0;
                Dictionary<string, string> tokens = new Dictionary<string, string>();
                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}", appID, Request.Url.AbsoluteUri, fbScope, Request["code"].ToString(), appSecret);
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string vals = reader.ReadToEnd();
                    tokens = JsonConvert.DeserializeObject<Dictionary<string, string>>(vals);
                    //foreach (string token in vals.Split('&'))
                    //    tokens.Add(token.Substring(0, token.IndexOf("=")), token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                }
                Dictionary<string, string> fbPages = new Dictionary<string, string>();
                string access_token = tokens["access_token"];
                string fbProfileID = fop.GetFacebookProfileId(tokens["access_token"]);
                var client = new FacebookClient(access_token);
                dynamic listOfPages1 = client.Get("/me/accounts");
                foreach (var page in listOfPages1.data)
                {
                    fbPages.Add(page.id, page.name);
                }
                //DataTable dtFbPages = fop.GetFacebookPages(tokens["access_token"], appID, appSecret, fbProfileID);
                //var client = new FacebookClient(access_token);
                dynamic userDetails = client.Get("/me");
                var FBID = userDetails.id;

                //Get List Of Facebook Pages

                dynamic listOfPages = client.Get("/me/accounts");
                foreach (var page in listOfPages.data)
                {
                    fbPages.Add(page.id, page.name);
                    pageCount++;
                }
                if (pageCount == 0)
                {

                }
                else
                {
                    Session["DataCollections"] = listOfPages;
                }
            }
            catch (Exception ex)
            {
                InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();
                /*** Error Log ***/
                objInBuiltData.ErrorHandling("ERROR", "AutoShareToBook.aspx.cs", "ShareOnFacebook", ex.Message, Convert.ToString(ex.StackTrace),
                    Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }

    }
}