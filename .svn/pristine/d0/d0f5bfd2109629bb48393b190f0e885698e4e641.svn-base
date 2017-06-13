using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using USPDHUBBLL;
using Twitterizer;

namespace USPDHUB.Business.MyAccount
{
    public partial class AutoShareTwitter : System.Web.UI.Page
    {
        public string oauth_consumer_key = string.Empty; //ConfigurationManager.AppSettings.Get("TwitterConsumerID");   //Twitter App ConsumerID and Consumer Secret
        public string oauth_consumer_secret = string.Empty; //ConfigurationManager.AppSettings.Get("TwitterConsumerSecret");

        public string RootPath = "";
        public string DomainName = "";
        public int C_UserID = 0;
        public int UserID = 0;
        public int ProfileID = 0;
        public DataTable dtExistingTwrUsersData = null;
        public SocialMediaAutoShareBLL fop = new SocialMediaAutoShareBLL();
        InBuiltDataBLL objInBuiltData = new InBuiltDataBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
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

                #region Get Consumet Key and Secret
                if (DomainName.ToLower().Contains("uspdhub"))
                {
                    oauth_consumer_key = ConfigurationManager.AppSettings.Get("TwitterUSPDConsumerID");
                    oauth_consumer_secret = ConfigurationManager.AppSettings.Get("TwitterUSPDConsumerSecret");
                }
                else if (DomainName.ToLower().Contains("twovie"))
                {
                    oauth_consumer_key = ConfigurationManager.AppSettings.Get("TwitterTwovieConsumerID");
                    oauth_consumer_secret = ConfigurationManager.AppSettings.Get("TwitterTwovieConsumerSecret");
                }
                else if (DomainName.ToLower().Contains("myyouthhub"))
                {
                    oauth_consumer_key = ConfigurationManager.AppSettings.Get("TwitterMYHConsumerID");
                    oauth_consumer_secret = ConfigurationManager.AppSettings.Get("TwitterMYHConsumerSecret");
                }
                else if (DomainName.ToLower().Contains("inschoolhub"))
                {
                    oauth_consumer_key = ConfigurationManager.AppSettings.Get("TwitterISHConsumerID");
                    oauth_consumer_secret = ConfigurationManager.AppSettings.Get("TwitterISHConsumerSecret");
                }
                else
                {
                    oauth_consumer_key = ConfigurationManager.AppSettings.Get("TwitterConsumerID");   //Twitter App ConsumerID and Consumer Secret
                    oauth_consumer_secret = ConfigurationManager.AppSettings.Get("TwitterConsumerSecret");
                }
                #endregion

                if (!Page.IsPostBack)
                {
                    dtExistingTwrUsersData = fop.GetTwitterDataByUserID(ProfileID);
                    if (dtExistingTwrUsersData.Rows.Count == 0)
                        TwrAuthenticate();
                    if (dtExistingTwrUsersData.Rows.Count > 0)
                    {
                        btnRemoveTwrAccount.Visible = true;
                        lblTwrName.Text = dtExistingTwrUsersData.Rows[0]["TwitterScreenName"].ToString();
                        chkTwrDefaultShare.Checked = Convert.ToBoolean(dtExistingTwrUsersData.Rows[0]["IsAutoPost"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AutoShareTwitter.aspx.cs", "Page_Load", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnRemoveTwrAccount.Visible = true;
                dtExistingTwrUsersData = fop.GetTwitterDataByUserID(ProfileID);
                if (dtExistingTwrUsersData.Rows.Count > 0)
                    SetDefaults("updated");
                else
                {
                    SocialMediaAutoShareBLL twrShare = new SocialMediaAutoShareBLL();
                    TwitterPins TwPins = (TwitterPins)Session["Tokens"];
                    //twrShare.InsertTwitterData(tokens.Token.ToString(), tokens.TokenSecret.ToString(), tokens.ScreenName.ToString(), false, UserID, C_UserID, ProfileID);
                    twrShare.InsertTwitterData(TwPins.Token, TwPins.TokenSecret, TwPins.ScreenName, false, UserID, C_UserID, ProfileID);
                    Session.Remove("Tokens");
                    SetDefaults("saved");
                }
            }
            catch (Exception exception)
            {
                string msg = "Error at event 'btnSave_Click' in AutoShareTwitter.aspx Page :";
                msg += exception.Message;
                throw new Exception(msg);
             //Error 
                objInBuiltData.ErrorHandling("ERROR", "AutoShareTwitter.aspx.cs", "btnSave_Click", exception.Message,
                Convert.ToString(exception.StackTrace), Convert.ToString(exception.InnerException), Convert.ToString(exception.Data));
           
            }
        }
        private void SetDefaults(string message)
        {
            try
            {
                if (chkTwrDefaultShare.Checked)
                    fop.SetDefaultTwitter(C_UserID, true);
                else
                    fop.SetDefaultTwitter(C_UserID, false);
                lblMsg.Text = "<span style='color:green; font-size:14px;'>Your account has been " + message + " successfully.</span>";
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AutoShareTwitter.aspx.cs", "SetDefaults", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnRemoveTwrAccount_Click(object sender, EventArgs e)
        {
            try
            {

                fop.DeleteSocialMediaData(C_UserID, "Twitter");
                Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/AutoSharing.aspx?TwrRemove=1"));
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AutoShareTwitter.aspx.cs", "btnRemoveTwrAccount_Click", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        private void TwrAuthenticate()
        {
            try
            {
                if (Request["oauth_token"] == null)
                {
                    OAuthTokenResponse reqToken = OAuthUtility.GetRequestToken(oauth_consumer_key, oauth_consumer_secret, Request.Url.AbsoluteUri);
                    Response.Redirect(string.Format("https://twitter.com/oauth/authorize?oauth_token={0}", reqToken.Token));
                }
                else
                {
                    try
                    {
                        string requestToken = Request["oauth_token"].ToString();
                        string pin = Request["oauth_verifier"].ToString();
                        var tokens = OAuthUtility.GetAccessToken(oauth_consumer_key, oauth_consumer_secret, requestToken, pin);
                        TwitterPins Pins = new TwitterPins();
                        Pins.Token = tokens.Token.ToString();
                        Pins.TokenSecret = tokens.TokenSecret.ToString();
                        Pins.ScreenName = tokens.ScreenName.ToString();
                        Session["Tokens"] = Pins;
                        lblTwrName.Text = tokens.ScreenName.ToString();
                    }
                    catch (Exception ex)
                    {
                        string msg = "Error at method 'TwrAuthenticate()' in AutoShareTwitter.aspx Page :";
                        msg += ex.Message;
                        throw new Exception(msg);
                    }
                }
            }
            catch (Exception ex)
            {
                //Error 
                objInBuiltData.ErrorHandling("ERROR", "AutoShareTwitter.aspx.cs", "TwrAuthenticate", ex.Message,
                Convert.ToString(ex.StackTrace), Convert.ToString(ex.InnerException), Convert.ToString(ex.Data));
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Business/MyAccount/AutoSharing.aspx"));
        }
    }
    public class TwitterPins
    {
        public string Token { get; set; }
        public string TokenSecret { get; set; }
        public string ScreenName { get; set; }
    }
}