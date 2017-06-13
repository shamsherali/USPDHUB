using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using USPDHUBBLL;
using System.Net;
using System.IO;
using Facebook;
using Newtonsoft.Json;

namespace USPDHUB.Business.MyAccount
{
    public partial class AutoShareFacebook : System.Web.UI.Page
    {
        public string appID = string.Empty;    //Facebook App ID and Secret
        public string appSecret = string.Empty;
        public string fbScope = ConfigurationManager.AppSettings.Get("FBScopes"); //"public_profile,publish_actions,publish_stream,manage_pages";

        public string RootPath = "";
        public string DomainName = "";
        public int C_UserID = 0;
        public int UserID = 0;
        public int ProfileID = 0;
        public string AccessToken = string.Empty;

        public DataTable dtExistingFbUsersData = null;
        public SocialMediaAutoShareBLL fop = new SocialMediaAutoShareBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

        public Dictionary<string, string> tokens = new Dictionary<string, string>();


        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            try
            {
                if (Session["userid"] == null)
                    Response.Redirect(Page.ResolveClientUrl("~/Login.aspx?sflag=1"));
                else
                {
                    UserID = Convert.ToInt32(Session["UserID"].ToString());
                    ProfileID = Convert.ToInt32(Session["ProfileID"]);
                    if (Session["C_USER_ID"] != null && Session["C_USER_ID"].ToString() != "")  //Added By Venkat...
                        C_UserID = Convert.ToInt32(Session["C_USER_ID"]);
                    else
                        C_UserID = UserID;
                }
                DomainName = Session["VerticalDomain"].ToString();  // *** Get Domain Name *** //
                RootPath = Session["RootPath"].ToString();



                #region AppDetails
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
                #endregion End AppDetails

                if (!Page.IsPostBack)
                {
                    dtExistingFbUsersData = fop.GetExistingUserData(ProfileID);
                    if (dtExistingFbUsersData.Rows.Count == 0)
                        FbAuthenticate();
                    if (dtExistingFbUsersData.Rows.Count > 0)
                    {
                        btnRemoveAccount.Visible = true;
                        BindFacebookPages(dtExistingFbUsersData, "");
                        lblfbProfileName.Text = dtExistingFbUsersData.Rows[0]["FbUserName"].ToString();
                        chkDefaultShare.Checked = Convert.ToBoolean(dtExistingFbUsersData.Rows[0]["IsAutoShare"].ToString());
                        bool isSelected = Convert.ToBoolean(dtExistingFbUsersData.Rows[0]["IsDefault"]);
                        if (isSelected)
                        {
                            foreach (ListItem item in chkFbPages.Items)
                                if (item.Text == "Your Timeline")
                                    item.Selected = true;
                        }

                        for (int i = 0; i < dtExistingFbUsersData.Rows.Count; i++)
                        {
                            bool isSelectedPage = false;
                            if (dtExistingFbUsersData.Rows[i]["PageDefault"].ToString() != null && dtExistingFbUsersData.Rows[i]["PageDefault"].ToString() != "")
                                isSelectedPage = Convert.ToBoolean(dtExistingFbUsersData.Rows[i]["PageDefault"]);
                            if (isSelectedPage)
                            {
                                foreach (ListItem item in chkFbPages.Items)
                                    if (item.Text == dtExistingFbUsersData.Rows[i]["PageName"].ToString())
                                        item.Selected = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AutoShareFacebook.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void FbAuthenticate()
        {
            try
            {
                if (dtExistingFbUsersData.Rows.Count == 0)
                {
                    if (Request["code"] == null)
                        Response.Redirect("https://graph.facebook.com/oauth/authorize?client_id=" + appID + "&redirect_uri=" + Request.Url.AbsoluteUri + "&scope=" + fbScope);
                    else
                    {
                        try
                        {
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
                            string fbProfileID = fop.GetFacebookProfileId(tokens["access_token"]);
                            DataTable dtFbPages = fop.GetFacebookPages(tokens["access_token"], appID, appSecret, fbProfileID);
                            Session["UserAccessToken"] = tokens["access_token"];
                            BindFacebookPages(dtFbPages, fbProfileID);
                            var client = new FacebookClient(tokens["access_token"]);
                            dynamic userDetails = client.Get("/me");
                            lblfbProfileName.Text = userDetails.name;
                            Session["tempToken"] = Session["UserAccessToken"];
                            //string logOutUrl = "https://www.facebook.com/logout.php?next=" + "http://localhost:2107/Business/Myaccount/AutoSharing.aspx" + "&access_token=" + tokens["access_token"];
                        }
                        catch (Exception /*ex*/)
                        {
                            Response.Redirect(RootPath + "/Business/MyAccount/AutoShareFacebook.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AutoShareFacebook.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnRemoveAccount.Visible = true;
                dtExistingFbUsersData = fop.GetExistingUserData(ProfileID);
                if (dtExistingFbUsersData.Rows.Count > 0)
                    SetDefaults("updated");
                else
                {
                    string accessToken = (string)Session["UserAccessToken"];
                    string fbProfileID = fop.AddFacebookProfileData(ProfileID, UserID, C_UserID, accessToken, appID, appSecret, false, false);
                    fop.AddFacebookPagesData(accessToken, appID, appSecret, fbProfileID, false, ProfileID);
                    Session.Remove("UserAccessToken");
                    SetDefaults("saved");
                }
            }
            catch (Exception ex)
            {
                string msg = "Error at event 'btnSave_Click' in AutoShareFacebook.aspx Page <br/> :";
                msg += ex.Message;
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AutoShareFacebook.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));

                //throw new Exception(msg);
            }
        }
        private void SetDefaults(string message)
        {
            try
            {
                if (chkDefaultShare.Checked)
                {
                    fop.SetDefaultFBWall(Convert.ToString(UserID), true, "FacebookAutoShare", null);
                }
                else
                    fop.SetDefaultFBWall(Convert.ToString(UserID), false, "FacebookAutoShare", null);
                foreach (ListItem li in chkFbPages.Items)
                {
                    if (li.Selected)
                    {
                        if (li.Text == "Your Timeline")
                            fop.SetDefaultFBWall(Convert.ToString(UserID), true, "Your Timeline", null);
                        else
                            fop.SetDefaultFBWall(Convert.ToString(ProfileID), true, "FacebookPages", li.Value.ToString());
                    }
                    else
                    {
                        if (li.Text == "Your Timeline")
                            fop.SetDefaultFBWall(Convert.ToString(UserID), false, "Your Timeline", null);
                        else
                            fop.SetDefaultFBWall(Convert.ToString(ProfileID), false, "FacebookPages", li.Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AutoShareFacebook.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
            lblMsg.Text = "<span style='color:green;font-size:14px;'>Your account has been " + message + " successfully.</span>";
        }
        protected void btnRemoveAccount_Click(object sender, EventArgs e)
        {
            try
            {
                fop.DeleteSocialMediaData(C_UserID, "Facebook");

                string redirectUrl = RootPath + "/Business/Myaccount/AutoSharing.aspx?fbRemove=1";
                if (Session["tempToken"] != null)
                {
                    var oauth = new Facebook.FacebookClient(Session["tempToken"].ToString());

                    var logoutParameters = new Dictionary<string, object>
                  {
                      {"access_token",  Session["tempToken"].ToString()},
                      { "next", redirectUrl}
                  };

                    redirectUrl = Convert.ToString(oauth.GetLogoutUrl(logoutParameters));
                }
                Session.Remove("tempToken");
                Response.Redirect(redirectUrl);
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AutoShareFacebook.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }

        }
        private void BindFacebookPages(DataTable dtExistingFbUsersData, string fbprofileId)
        {
            try
            {
                bool isBindFbPages = true;
                if (dtExistingFbUsersData.Rows.Count == 1)
                {
                    string facebookPageName = dtExistingFbUsersData.Rows[0]["PageName"].ToString();
                    string facebookPageID = dtExistingFbUsersData.Rows[0]["PageId"].ToString();
                    if (string.IsNullOrEmpty(facebookPageName) || string.IsNullOrEmpty(facebookPageID))
                        isBindFbPages = false;
                }
                if (isBindFbPages)
                {
                    chkFbPages.DataSource = dtExistingFbUsersData;
                    chkFbPages.DataTextField = "PageName"; // the items to be displayed in the list items
                    chkFbPages.DataValueField = "PageId"; // the id of the items displayed
                    chkFbPages.DataBind();
                }
                if (dtExistingFbUsersData.Rows.Count == 0 && fbprofileId != "")
                {
                    chkFbPages.Items.Insert(0, new ListItem("Your Timeline", fbprofileId));
                }
                else
                    chkFbPages.Items.Insert(0, new ListItem("Your Timeline", dtExistingFbUsersData.Rows[0]["FbProfileID"].ToString()));

            }
            catch (Exception ex)
            {
                string msg = "Error at method 'BindFacebookPages' in AutoShareFacebook.aspx Page <br/> :";
                msg += ex.Message;
                throw new Exception(msg);
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/AutoSharing.aspx"));
        }
    }
}