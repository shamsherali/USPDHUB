using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Facebook;
using System.Dynamic;
using USPDHUBDAL;
using Twitterizer;
using Tweetinvi;

namespace USPDHUBBLL
{
    public class SocialMediaAutoShareBLL
    {
        /// <summary>
        /// Add Facebook Profile Data
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="userId">userId</param>
        /// <param name="createduserId">createduserId</param>
        /// <param name="userAccessToken">userAccessToken</param>
        /// <param name="AppID">AppID</param>
        /// <param name="AppSecret">AppSecret</param>
        /// <param name="isAutoShare">isAutoShare</param>
        /// <param name="isDefault">isDefault</param>
        /// <returns>String</returns>
        public string AddFacebookProfileData(int profileID, int userId, int createduserId, string userAccessToken, string AppID, string AppSecret, bool isAutoShare, bool isDefault)
        {
            string name = "";
            string FBProfileId = "";
            string appAccessToken = "";
            try
            {
                //Retrieving Profile Details
                var client = new FacebookClient(userAccessToken);
                dynamic userDetails = client.Get("/me");
                name = userDetails.name;
                FBProfileId = userDetails.id;

                //Retrieving App Access Token
                var fb = new FacebookClient();
                dynamic appToken = fb.Get("oauth/access_token", new
                {
                    client_id = AppID,
                    client_secret = AppSecret,
                    grant_type = "client_credentials"
                });
                appAccessToken = appToken.access_token;
                SocialMediaAutoShareDAL.InsertFacebookProfileDate(profileID, userId, createduserId, name, FBProfileId, userAccessToken, appAccessToken, isAutoShare, isDefault); // Inserting FB User Data into Our DB
            }
            catch (Exception /*ex*/)
            {

            }
            return FBProfileId;
        }
        /// <summary>
        /// Add Facebook Pages Data
        /// </summary>
        /// <param name="userAccessToken">userAccessToken</param>
        /// <param name="AppID">AppID</param>
        /// <param name="AppSecret">AppSecret</param>
        /// <param name="FbWallID">FbWallID</param>
        /// <param name="isDefault">isDefault</param>
        /// <param name="ProfileID">ProfileID</param>
        public void AddFacebookPagesData(string userAccessToken, string AppID, string AppSecret, string FbWallID, bool isDefault, int ProfileID)
        {
            try
            {
                var client = new FacebookClient(userAccessToken);
                dynamic listOfPages = client.Get("/me/accounts");
                foreach (var page in listOfPages.data)
                {
                    var result = GetExtendedAccessToken(page.access_token, AppID, AppSecret);
                    var extendedToken = result.access_token;
                    SocialMediaAutoShareDAL.InsertFacebookPagesData(page.id, page.name, FbWallID, extendedToken, isDefault, ProfileID);
                }
            }
            catch (Exception /*ex*/)
            {

            }
        }

        /// <summary>
        /// Facebook Post To UserWall
        /// </summary>
        /// <param name="userWallID">userWallID</param>
        /// <param name="appToken">appToken</param>
        /// <param name="args">args</param>
        /// <returns>String</returns>
        public string FacebookPostToUserWall(string userWallID, string appToken, object args)
        {
            var fb = new FacebookClient();
            fb.AccessToken = appToken;
            string postId = "";

            try
            {
                var postID = fb.Post("/" + userWallID + "/feed", args);
                postId = postID.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
            return postId;
        }

        /// <summary>
        /// Facebook Post To UserPage
        /// </summary>
        /// <param name="pageId">pageId</param>
        /// <param name="args">args</param>
        /// <returns>String</returns>
        public string FacebookPostToUserPage(string pageId, object args)
        {
            string pageToken = SocialMediaAutoShareDAL.GetPageAccessTokenByPageID(pageId);
            var fb = new FacebookClient();
            fb.AccessToken = pageToken;
            string postId = "";

            try
            {
                if (pageId != "")
                {
                    var postID = fb.Post("/" + pageId + "/feed", args);
                    postId = postID.ToString();
                }
            }
            catch (Exception /*ex*/)
            {

            }
            return postId;
        }

        /// <summary>
        /// Get Extended Access Token
        /// </summary>
        /// <param name="shortLivedToken">shortLivedToken</param>
        /// <param name="appID">appID</param>
        /// <param name="appSecret">appSecret</param>
        /// <returns></returns>
        public dynamic GetExtendedAccessToken(string shortLivedToken, string appID, string appSecret)
        {
            dynamic result = new ExpandoObject();
            try
            {
                var api = new FacebookClient
                {
                    AccessToken = shortLivedToken,
                    AppId = appID,
                    AppSecret = appSecret
                };
                dynamic parameters = new ExpandoObject();
                parameters.grant_type = "fb_exchange_token";
                parameters.fb_exchange_token = shortLivedToken;
                parameters.client_id = appID;
                parameters.client_secret = appSecret;
                result = api.Get("oauth/access_token", parameters);
            }
            catch (Exception /*ex*/)
            {

            }
            finally
            {

            }
            return result;
        }

        /// <summary>
        /// Get Existing User Data
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetExistingUserData(int profileID)
        {
            return SocialMediaAutoShareDAL.GetExistingUserData(profileID);
        }

        /// <summary>
        /// Insert Twitter Data
        /// </summary>
        /// <param name="twrToken">twrToken</param>
        /// <param name="pin">pin</param>
        /// <param name="userName">userName</param>
        /// <param name="isAutoPost">isAutoPost</param>
        /// <param name="userId">userId</param>
        /// <param name="createdUserId">createdUserId</param>
        /// <param name="profileID">profileID</param>
        public void InsertTwitterData(string twrToken, string pin, string userName, bool isAutoPost, int userId, int createdUserId, int profileID)
        {
            SocialMediaAutoShareDAL.InsertTwitterData(twrToken, pin, userName, isAutoPost, userId, createdUserId, profileID);
        }

        /// <summary>
        /// Get Twitter Data By UserID
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetTwitterDataByUserID(int profileID)
        {
            return SocialMediaAutoShareDAL.GetTwitterDataByUserID(profileID);
        }

        /// <summary>
        /// Delete Social Media Data
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="mediaType">mediaType</param>
        public void DeleteSocialMediaData(int userID, string mediaType)
        {
            SocialMediaAutoShareDAL.DeleteSocialMediaData(userID, mediaType);
        }

        /// <summary>
        /// Facebook AutoShare
        /// </summary>
        /// <param name="profileID">profileID</param>
        /// <param name="description">description</param>
        /// <param name="title">title</param>
        /// <param name="url">url</param>
        public void FacebookAutoShare(int profileID, string description, string title, string url)
        {
            var args = new Dictionary<string, object>();
            args["message"] = description;
            args["name"] = title;
            args["link"] = url;
            string fbReturn = string.Empty;
            DataTable dtExistingFbUsersData = GetExistingUserData(profileID);
            if (dtExistingFbUsersData.Rows.Count > 0)
            {
                for (int i = 0; i < 1; i++) // To Share on Facebook Timeline
                {
                    if (Convert.ToBoolean(dtExistingFbUsersData.Rows[i]["IsAutoShare"].ToString()) == true)
                    {
                        if (Convert.ToBoolean(dtExistingFbUsersData.Rows[i]["IsDefault"].ToString()) == true)
                            FacebookPostToUserWall(dtExistingFbUsersData.Rows[0]["FbProfileID"].ToString(), dtExistingFbUsersData.Rows[0]["FbAppAccessToken"].ToString(), args);
                    }
                }
                for (int i = 0; i < dtExistingFbUsersData.Rows.Count; i++)  //To Share on Facebook Fan Pages.
                {
                    if (Convert.ToBoolean(dtExistingFbUsersData.Rows[i]["IsAutoShare"].ToString()) == true)
                    {
                        if (Convert.ToBoolean(dtExistingFbUsersData.Rows[i]["PageDefault"].ToString()) == true)
                            fbReturn = FacebookPostToUserPage(dtExistingFbUsersData.Rows[i]["PageId"].ToString(), args);
                    }
                }
            }
        }

        /// <summary>
        /// Twitter AutoShare
        /// </summary>
        /// <param name="appUserID">appUserID</param>
        /// <param name="description">description</param>
        /// <returns>Boolean</returns>
        public bool TwitterAutoShare(int appUserID, string description)
        {
            string oauth_consumer_key = ConfigurationManager.AppSettings.Get("TwitterConsumerID");   //Twitter App ConsumerID and Consumer Secret
            string oauth_consumer_secret = ConfigurationManager.AppSettings.Get("TwitterConsumerSecret");
            DataTable dtExistingTwrUsersData = GetTwitterDataByUserID(appUserID);
            TwitterCredentials.SetCredentials(dtExistingTwrUsersData.Rows[0]["TwitterAccessToken"].ToString(), dtExistingTwrUsersData.Rows[0]["TwitterPin"].ToString(), oauth_consumer_key, oauth_consumer_secret);
            var tweet = Tweet.PublishTweet(description);
            if (tweet == null)
                return false;
            else
                return true;


        }
        /// <summary>
        /// Set Default Facebook Wall
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="updateFlag">updateFlag</param>
        /// <param name="Type">Type</param>
        /// <param name="pageID">pageID</param>
        public void SetDefaultFBWall(string ID, bool updateFlag, string Type, string pageID)
        {
            SocialMediaAutoShareDAL.SetDefaultFBWall(ID, updateFlag, Type, pageID);
        }

        /// <summary>
        /// Set Default Twitter
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="isAutoShare">isAutoShare</param>
        public void SetDefaultTwitter(int userID, bool isAutoShare)
        {
            SocialMediaAutoShareDAL.SetDefaultTwitterWall(userID, isAutoShare);
        }

        /// <summary>
        /// Get Facebook Pages
        /// </summary>
        /// <param name="userAccessToken">userAccessToken</param>
        /// <param name="AppID">AppID</param>
        /// <param name="AppSecret">AppSecret</param>
        /// <param name="fbProfileID">fbProfileID</param>
        /// <returns>DataTable</returns>
        public DataTable GetFacebookPages(string userAccessToken, string AppID, string AppSecret, string fbProfileID)
        {
            DataTable dtFacebookPages = new DataTable();
            dtFacebookPages.Columns.Add("PageId");
            dtFacebookPages.Columns.Add("PageName");
            dtFacebookPages.Columns.Add("FbProfileID");
            List<string> lstPages = new List<string>();
            try
            {
                var client = new FacebookClient(userAccessToken);
                dynamic listOfPages = client.Get("/me/accounts");
                foreach (var page in listOfPages.data)
                {
                    var result = GetExtendedAccessToken(page.access_token, AppID, AppSecret);   //Get Extended Access Token For Facebook Pages.
                    var extendedToken = result.access_token;
                    if (!lstPages.Contains(page.id.ToString()))
                    {
                        DataRow row = dtFacebookPages.NewRow();
                        row["PageId"] = page.id;
                        row["PageName"] = page.name;
                        row["FbProfileID"] = fbProfileID;
                        dtFacebookPages.Rows.Add(row);
                        lstPages.Add(page.id.ToString());
                    }
                }
            }
            catch (Exception exGetFacebookPages)
            {
                string msg = "Error at method 'GetFacebookPages()' in SocialMediaAutoShareBLL.";
                msg += exGetFacebookPages.Message;
                throw new Exception(msg);
            }
            return dtFacebookPages;
        }

        /// <summary>
        /// Get Facebook ProfileId
        /// </summary>
        /// <param name="userAccessToken">userAccessToken</param>
        /// <returns>String</returns>
        public string GetFacebookProfileId(string userAccessToken)
        {
            string FBProfileId = string.Empty;
            try
            {
                //Retrieving Profile Details
                var client = new FacebookClient(userAccessToken);
                dynamic userDetails = client.Get("/me");
                FBProfileId = userDetails.id;
            }
            catch (Exception exGetFacebookProfileId)
            {
                string msg = "Error at method 'GetFacebookProfileId()' in SocialMediaAutoShareBLL.";
                msg += exGetFacebookProfileId.Message;
                throw new Exception(msg);
            }
            return FBProfileId;
        }
        /// <summary>
        /// Get Shared Media History
        /// </summary>
        /// <param name="UserID">UserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetSharedMediaHistory(int UserID)
        {
            return SocialMediaAutoShareDAL.GetSharedMediaHistory(UserID);
        }
    }
}
