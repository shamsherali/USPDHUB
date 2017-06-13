using System;
using System.Data;

namespace USPDHUBBLL
{
    public class Consumer
    {
        /// <summary>
        /// Validate Consumer
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>DataTable</returns>
        public DataTable ValidateConsumer(string username, string password)
        {
            return USPDHUBDAL.Consumer.ValidateConsumer(username, password);
        }

        /// <summary>
        /// Validate User By Details
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>DataTable</returns>
        public DataTable ValidateUserByDetails(string username)
        {
            return USPDHUBDAL.Consumer.ValidateUserByDetails(username);
        }

        /// <summary>
        /// Add Consumer
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <param name="email">email</param>
        /// <param name="firstname">firstname</param>
        /// <param name="lastname">lastname</param>
        /// <param name="pswdQ1">pswdQ1</param>
        /// <param name="pswdA1">pswdA1</param>
        /// <param name="pswdQ2">pswdQ2</param>
        /// <param name="pswdA2">pswdA2</param>
        /// <param name="roleId">roleId</param>
        /// <param name="isActive">isActive</param>
        /// <param name="addr1">addr1</param>
        /// <param name="addr2">addr2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="country">country</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone">phone</param>
        /// <param name="userid">userid</param>
        /// <param name="status">status</param>
        /// <returns>Int</returns>
        public int AddConsumer(string username, string password, string email, string firstname, string lastname, string pswdQ1, string pswdA1, string pswdQ2, string pswdA2, int roleId, bool isActive, string addr1, string addr2, string city, string state, string country, string zipcode, string phone, int userid, string status)
        {
            return USPDHUBDAL.Consumer.AddConsumer(username, password, email, firstname, lastname, pswdQ1, pswdA1, pswdQ2, pswdA2, roleId, isActive, addr1, addr2, city, state, country, zipcode, phone, userid, status);
        }

        /// <summary>
        /// Get User Details
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="domainName">domainName</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserDetails(string username, string domainName)
        {
            return USPDHUBDAL.Consumer.GetUserDetails(username, domainName);
        }
        public DataTable GetForgotDetails(string userName, string domainName)
        {
            return USPDHUBDAL.Consumer.GetForgotDetails(userName, domainName);
        }
        /// <summary>
        /// Get User Details By ID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserDetailsByID(int userID)
        {
            return USPDHUBDAL.Consumer.GetUserDetailsByID(userID);
        }

        /// <summary>
        /// Get Forum User Details
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>DataTable</returns>
        public DataTable GetForumUserDetails(string username)
        {
            return USPDHUBDAL.Consumer.GetForumUserDetails(username);
        }

        /// <summary>
        /// Get User Messages
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="userID">userID</param>
        /// <param name="totypeID">totypeID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserMessages(bool top5Flag, int userID, int totypeID)
        {
            return USPDHUBDAL.Consumer.GetUserMessages(top5Flag, userID, totypeID);
        }

        /// <summary>
        /// Get User Sent Messages
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="userID">userID</param>
        /// <param name="totypeID">totypeID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserSentMessages(bool top5Flag, int userID, int totypeID)
        {
            return USPDHUBDAL.Consumer.GetUserSentMessages(top5Flag, userID, totypeID);
        }

        /// <summary>
        /// Get Favorites
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetFavorites(bool top5Flag, int userID)
        {
            return USPDHUBDAL.Consumer.GetFavorites(top5Flag, userID);
        }

        /// <summary>
        /// Get System Alerts
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetSystemAlerts(bool top5Flag, int userID)
        {
            return USPDHUBDAL.Consumer.GetSystemAlerts(top5Flag, userID);
        }

        /// <summary>
        /// Get Saved Searches
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetSavedSearches(bool top5Flag, int userID)
        {
            return USPDHUBDAL.Consumer.GetSavedSearches(top5Flag, userID);
        }

        /// <summary>
        /// Delete Saved Searches
        /// </summary>
        /// <param name="msgid">msgid</param>
        /// <returns>Int</returns>
        public int DeleteSavedSearches(int msgid)
        {
            return USPDHUBDAL.Consumer.DeleteSavedSearches(msgid);
        }

        /// <summary>
        /// Manage Message
        /// </summary>
        /// <param name="toid">toid</param>
        /// <param name="totypeID">totypeID</param>
        /// <param name="fromID">fromID</param>
        /// <param name="subject">subject</param>
        /// <param name="message">message</param>
        /// <param name="replyid">replyid</param>
        /// <param name="activeflag">activeflag</param>
        /// <param name="msgID">msgID</param>
        /// <param name="userID">userID</param>
        /// <param name="tType">tType</param>
        /// <param name="id">id</param>
        /// <returns>Int</returns>
        public int ManageMessage(int toid, int totypeID, int fromID, string subject, string message, int replyid, bool activeflag, int msgID, int userID, int tType, int id)
        {
            return USPDHUBDAL.Consumer.ManageMessage(toid, totypeID, fromID, subject, message, replyid, activeflag, msgID, userID, tType, id);
        }

        /// <summary>
        /// Manage Favorite Details
        /// </summary>
        /// <param name="fname">fname</param>
        /// <param name="profileID">profileID</param>
        /// <param name="userid">userid</param>
        /// <param name="ttype">ttype</param>
        /// <param name="favoriteID">favoriteID</param>
        /// <returns>Int</returns>
        public int ManageFavoriteDetails(string fname, int profileID, int userid, int ttype, int favoriteID)
        {
            return USPDHUBDAL.Consumer.ManageFavoriteDetails(fname, profileID, userid, ttype, favoriteID);
        }

        /// <summary>
        /// Manage Business Review Details
        /// </summary>
        /// <param name="reviewerID">reviewerID</param>
        /// <param name="reviewname">reviewname</param>
        /// <param name="profileID">profileID</param>
        /// <param name="rating1">rating1</param>
        /// <param name="rating2">rating2</param>
        /// <param name="rating3">rating3</param>
        /// <param name="description">description</param>
        /// <param name="avgrating">avgrating</param>
        /// <param name="userID">userID</param>
        /// <param name="ttype">ttype</param>
        /// <param name="reviewID">reviewID</param>
        /// <param name="phone">phone</param>
        /// <param name="email">email</param>
        /// <returns>Int</returns>
        public int ManageBusinessReviewDetails(int reviewerID, string reviewname, int profileID, int rating1, int rating2, int rating3, string description, int avgrating, int userID, int ttype, int reviewID, string phone, string email)
        {
            return USPDHUBDAL.Consumer.ManageBusinessReviewDetails(reviewerID, reviewname, profileID, rating1, rating2, rating3, description, avgrating, userID, ttype, reviewID, phone, email);
        }

        /// <summary>
        /// Manage Saved Search Details
        /// </summary>
        /// <param name="sName">sName</param>
        /// <param name="criteria">criteria</param>
        /// <param name="userid">userid</param>
        /// <param name="ttype">ttype</param>
        /// <param name="searchID">searchID</param>
        /// <returns>Int</returns>
        public int ManageSavedSearchDetails(string sName, string criteria, int userid, int ttype, int searchID)
        {
            return USPDHUBDAL.Consumer.ManageSavedSearchDetails(sName, criteria, userid, ttype, searchID);
        }

        /// <summary>
        /// Get User Sent Messages
        /// </summary>
        /// <param name="top5Flag">top5Flag</param>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable GetUserSentMessages(bool top5Flag, int userID)
        {
            return USPDHUBDAL.Consumer.GetUserSentMessages(top5Flag, userID);
        }

        /// <summary>
        /// Update User Read Message
        /// </summary>
        /// <param name="totypeID">totypeID</param>
        /// <param name="msgID">msgID</param>
        /// <returns>Int</returns>
        public int UpdateUserReadMessage(int totypeID, int msgID)
        {
            return USPDHUBDAL.Consumer.UpdateUserReadMessage(totypeID, msgID);
        }

        /// <summary>
        /// Update User Password
        /// </summary>
        /// <param name="userid">userid</param>
        /// <param name="newpassword">newpassword</param>
        /// <param name="passwordChanged">passwordChanged</param>
        /// <returns>Int</returns>
        public int UpdateUserPassword(int userid, string newpassword, int passwordChanged)
        {
            return USPDHUBDAL.Consumer.UpdateUserPassword(userid, newpassword, passwordChanged);
        }

        /// <summary>
        /// Get Selected Tips
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetSelectedTips()
        {
            return USPDHUBDAL.Consumer.GetTipsForSelect();
        }

        /// <summary>
        /// Get Category Tips
        /// </summary>
        /// <param name="tipCategory">tipCategory</param>
        /// <returns>DataTable</returns>
        public DataTable GetCategoryTips(string tipCategory)
        {
            return USPDHUBDAL.Consumer.GetTipsCategory(tipCategory);
        }

        /// <summary>
        /// Modify Consumer
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="email">email</param>
        /// <param name="firstname">firstname</param>
        /// <param name="lastname">lastname</param>
        /// <param name="roleId">roleId</param>
        /// <param name="isActive">isActive</param>
        /// <param name="addr1">addr1</param>
        /// <param name="addr2">addr2</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="country">country</param>
        /// <param name="zipcode">zipcode</param>
        /// <param name="phone">phone</param>
        /// <param name="userid">userid</param>
        /// <param name="status">status</param>
        /// <param name="profileID">profileID</param>
        /// <returns>Int</returns>
        public int ModifyConsumer(string username, string email, string firstname, string lastname, int roleId, bool isActive, string addr1, string addr2, string city, string state, string country, string zipcode, string phone, int userid, string status, int profileID)
        {
            return USPDHUBDAL.Consumer.ModifyConsumer(username, email, firstname, lastname, roleId, isActive, addr1, addr2, city, state, country, zipcode, phone, userid, status, profileID);
        }
        // Start Issue 849
        /// <summary>
        /// Validate Saved Search
        /// </summary>
        /// <param name="searchname">searchname</param>
        /// <param name="userID">userID</param>
        /// <returns>DataTable</returns>
        public DataTable ValidateSavedSearch(string searchname, int userID)
        {
            return USPDHUBDAL.Consumer.ValidateSavedSearch(searchname, userID);
        }
        // End Issue 849
        /// <summary>
        /// Get Associate user details by username
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="domainName">domainName</param>
        /// <returns>DataTable</returns>
        public DataTable GetAssociateUserDetails(string username, string domainName)
        {
            return USPDHUBDAL.Consumer.GetAssociateUserDetails(username, domainName);
        }

        /// <summary>
        /// Insert and Update Associate Login
        /// </summary>
        /// <param name="pFirstname">pFirstname</param>
        /// <param name="pLastname">pLastname</param>
        /// <param name="pUsername">pUsername</param>
        /// <param name="pPassword">pPassword</param>
        /// <param name="pUserStatus">pUserStatus</param>
        /// <param name="pCreatedUser">pCreatedUser</param>
        /// <param name="pSuperAdminID">pSuperAdminID</param>
        /// <param name="pIsAssociateSuperAdmin">pIsAssociateSuperAdmin</param>
        /// <param name="pUserID">pUserID</param>
        /// <returns>Int</returns>
        public int Insert_Update_AssociateLogin(string pFirstname, string pLastname, string pUsername, string pPassword, string pUserStatus,
           int pCreatedUser, int pSuperAdminID, bool pIsAssociateSuperAdmin, int pUserID)
        {
            return USPDHUBDAL.Consumer.Insert_Update_AssociateLogin(pFirstname, pLastname, pUsername,
                pPassword, pUserStatus, pCreatedUser, pSuperAdminID, pIsAssociateSuperAdmin, pUserID);
        }

        /// <summary>
        /// Get Manage Associates
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetManageAssociates(int pUserID, string searchTag, out int totalAssociates)
        {
            return USPDHUBDAL.Consumer.GetManageAssociates(pUserID, searchTag, out totalAssociates);
        }

        /// <summary>
        /// Get Active Associates
        /// </summary>
        /// <param name="pUserID">pUserID</param>
        /// <returns>DataTable</returns>
        public DataTable GetActiveAssociates(int pUserID)
        {
            return USPDHUBDAL.Consumer.GetActiveAssociates(pUserID);
        }

        /// <summary>
        /// Change loginID
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="userID">userID</param>
        public void ChangeloginID(string username, int userID)
        {
            USPDHUBDAL.Consumer.ChangeloginID(username, userID);

        }
    }
}
